﻿(*
 * Copyright (C) 2016-2017 Ian Spratt <ian144@hotmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301, USA.
 *
 *)
 
[<RequireQualifiedAccess>]
module MessageGenerator

open System.IO
open System.Xml.Linq
open System.Xml.XPath

open FIXGenTypes



let Read (parentXL:XElement) =
    let msgsXL = parentXL.XPathSelectElements "message"
    [   for msgXL in msgsXL do
        let msgName = FIXSpecReader.GetAttributeStr msgXL "name" 
        let msgType = FIXSpecReader.GetAttributeStr msgXL "msgtype"
        let msgCat = FIXSpecReader.GetAttributeStr msgXL "msgcat"
        let items = FIXSpecReader.ReadItems [msgName] msgXL
        yield {MName = msgName; Tag = msgType; Cat = msgCat; Items = items}
    ]



let private writeMsg (sw:StreamWriter) (msg:Msg)  = 
    sw.WriteLine ""
    sw.WriteLine (sprintf "//%s" msg.Cat)
    let ss = sprintf "type %s = {" msg.MName
    sw.Write ss
    sw.WriteLine ""
    msg.Items |> (CommonGenerator.writeFIXItemList sw)
    sw.Write  "    }"
    sw.WriteLine ""


let Gen (msgs:Msg list) (sw:StreamWriter) =
    sw.WriteLine "module Fix44.Messages"
    sw.WriteLine ""
    sw.WriteLine "// **** this file is generated by fsFixGen ****"
    sw.WriteLine ""
    sw.WriteLine "open OneOrTwo"
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.CompoundItems"
    sw.WriteLine ""
    sw.WriteLine ""

    msgs |> List.iter (writeMsg sw)


let private makeParamStr (fi:FIXItem) =
    let typeName = fi |> FIXItem.getName
    let valName  = typeName |> StringEx.lCaseFirstChar
    sprintf "(%s:%s)" valName typeName


let private makeFuncSig (requiredHdrItems:FIXItem list) (msg:Msg) =
    let name = msg.MName
    let paramStr = requiredHdrItems |> List.map makeParamStr
    let allParamStr = paramStr |> StringEx.join " "
    let funcSig = sprintf "let Write%s (dest:byte []) (nextFreeIdx:int) %s (xx:%s) = " name allParamStr name
    funcSig


let private genFieldInitStrs (items:FIXItem list) =
    items |> List.map (fun fi -> 
        let fieldName = fi |> FIXItem.getNameLN
        let varName = fieldName |> StringEx.lCaseFirstChar |> CommonGenerator.fixYield
        sprintf "        %s = %s" fieldName varName )


let private genMsgWriterFunc (requiredHdrItems:FIXItem list) (sw:StreamWriter) (msg:Msg) =
    let name = msg.MName
    let cmnt = sprintf "// tag: %s" msg.Tag
    sw.WriteLine cmnt
    let funcSig = makeFuncSig [] msg
    sw.WriteLine funcSig
    let writeGroupFuncStrs = CommonGenerator.genItemListWriterStrs msg.Items
    writeGroupFuncStrs |> List.iter sw.WriteLine
    sw.WriteLine "    nextFreeIdx"
    sw.WriteLine ""
    sw.WriteLine ""


let GenWriteFuncs (hdrItems:FIXItem list) (groups:Msg list) (sw:StreamWriter) =
    let requiredHdrFields, optionalHdrFields = hdrItems |> List.partition FIXItem.getIsRequired

    // generate the group write functions todo: generate group read funcs
    sw.WriteLine "module Fix44.MsgWriters"
    sw.WriteLine ""
    sw.WriteLine "// **** this file is generated by fsFixGen ****"
    sw.WriteLine ""
    sw.WriteLine "open OneOrTwo"
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.FieldWriters"
    sw.WriteLine "open Fix44.CompoundItems"
    sw.WriteLine "open Fix44.CompoundItemWriters"
    sw.WriteLine "open Fix44.Messages"
    sw.WriteLine ""
    sw.WriteLine ""
    groups |> List.iter (genMsgWriterFunc requiredHdrFields sw)  




let private genMsgReaderFunc (fieldNameMap:Map<string,Field>) (compNameMap:Map<ComponentName,Component>) (sw:StreamWriter) (msg:Msg) = 
    let funcSig = sprintf "let Read%s (bs:byte[]) (index:FIXBufIndexer.IndexData) =" msg.MName
    sw.WriteLine funcSig
    let readFIXItemStrs = CommonGenerator.genItemListReaderStrs fieldNameMap compNameMap msg.MName msg.Items
    readFIXItemStrs |> List.iter sw.WriteLine
    let fieldInitStrs = genFieldInitStrs msg.Items
    sw.WriteLine (sprintf "    let ci:%s = {" msg.MName)
    fieldInitStrs |> List.iter sw.WriteLine
    sw.WriteLine "    }"
    sw.WriteLine "    ci"
    sw.WriteLine ""
    sw.WriteLine ""

// In FIX4.4 AllocationInstruction and SettlementInstruction msgs have contain optional fields which are also contained within groups in the msg.
// Reading groups first (which includes blanking their field index entries) to avoid the reading in the groups instance of the field when searching for the outer msg instance.
let private genMsgReaderFuncReadGroupsFirst (fieldNameMap:Map<string,Field>) (compNameMap:Map<ComponentName,Component>) (sw:StreamWriter) (msg:Msg) = 
    let funcSig = sprintf "let Read%s (bs:byte[]) (index:FIXBufIndexer.IndexData) =" msg.MName
    sw.WriteLine funcSig
    let groupItems, nonGroupItems = msg.Items |> List.partition FIXItem.isGroup
    let allItems = groupItems @ nonGroupItems
    let readFIXItemStrs = CommonGenerator.genItemListReaderStrs fieldNameMap compNameMap msg.MName allItems
    readFIXItemStrs |> List.iter sw.WriteLine
    let fieldInitStrs = genFieldInitStrs msg.Items
    sw.WriteLine (sprintf "    let ci:%s = {" msg.MName)
    fieldInitStrs |> List.iter sw.WriteLine
    sw.WriteLine "    }"
    sw.WriteLine "    ci"
    sw.WriteLine ""
    sw.WriteLine ""




let GenReadFuncs (fieldNameMap:Map<string,Field>) (compNameMap:Map<ComponentName,Component>) (hdrItems:FIXItem list) (xs:Msg list) (sw:StreamWriter) =
    // let requiredHdrFields, optionalHdrFields = hdrItems |> List.partition FIXItem.getIsRequired
    // generate the group write functions todo: generate group read funcs
    sw.WriteLine "module Fix44.MsgReaders"
    sw.WriteLine ""
    sw.WriteLine "// **** this file is generated by fsFixGen ****"
    sw.WriteLine ""
    sw.WriteLine "open OneOrTwo"
    sw.WriteLine "open GenericReaders"
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.FieldReaders"
    sw.WriteLine "open Fix44.CompoundItems"
    sw.WriteLine "open Fix44.CompoundItemReaders"
    sw.WriteLine "open Fix44.Messages"
    sw.WriteLine ""
    sw.WriteLine ""
    xs |> List.iter (genMsgReaderFuncReadGroupsFirst fieldNameMap compNameMap sw)




let GenMessageDU (msgs:Msg list) (sw:StreamWriter) =
    // write the 'group/component' DU, used only in property based tests
    sw.WriteLine "module Fix44.MessageDU"
    sw.WriteLine ""
    sw.WriteLine "// **** this file is generated by fsFixGen ****"
    sw.WriteLine ""
    sw.WriteLine "open Fix44.Messages"
    sw.WriteLine "open Fix44.MsgWriters"
    sw.WriteLine "open Fix44.MsgReaders"
    sw.WriteLine ""
    sw.WriteLine ""

    sw.WriteLine  "type FIXMessage ="
    let names = msgs |> List.map (fun msg -> msg.MName) |> List.sort 
    names |> List.iter (fun name ->
            let ss  = sprintf "    | %s of %s" name name
            sw.WriteLine ss  )
    sw.WriteLine ""
    sw.WriteLine ""
    sw.WriteLine ""

    // create the 'WriteMessage' DU function, probably will only used in property tests
    sw.WriteLine "let WriteMessage dest nextFreeIdx msg ="
    sw.WriteLine "    match msg with"
    names |> List.iter (fun strName ->
                let ss  = sprintf "    | %s msg -> Write%s dest nextFreeIdx msg" strName strName
                sw.WriteLine ss  )
    sw.WriteLine ""
    sw.WriteLine ""
    sw.WriteLine ""

    // create the 'TestReadMessage DU function, probably will only used in property based tests
    sw.WriteLine "let ReadMessage selector bs (index:FIXBufIndexer.IndexData) ="
    sw.WriteLine "    match selector with"
    names |> List.iter (fun strName ->
                let ss1  = sprintf "    | %s _ ->" strName
                let ss2  = sprintf "        let msg = Read%s bs index" strName
                let ss3 =  sprintf "        msg |> FIXMessage.%s" strName
                sw.WriteLine ss1
                sw.WriteLine ss2
                sw.WriteLine ss3 ) // end List.iter
    sw.WriteLine ""
    sw.WriteLine ""
    sw.WriteLine ""
    
    sw.WriteLine "let ReadMessageDU (tag:Fix44.Fields.MsgType) bs (index:FIXBufIndexer.IndexData) ="
    sw.WriteLine "    match tag with"
    msgs |> List.iter (fun msg ->
                //let ss = sprintf "    | \"%s\"B   ->  Read%s bs index |> FIXMessage.%s"  msg.Tag msg.MName msg.MName
                let ss = sprintf "    | Fix44.Fields.MsgType.%s   ->  Read%s bs index |> FIXMessage.%s"  msg.MName msg.MName msg.MName
                sw.WriteLine ss )
    let ss1  = "    | invalidTag   ->"
    let ss2  = "        // FIX4.4.xml (the quickfix.net version at least) does not define and XMLMessage, for which there is a Fix44.Fields.MsgType DU case"
    let ss3  = "        failwithf \"received unknown message type tag: %A\" invalidTag"
    sw.WriteLine ss1
    sw.WriteLine ss2
    sw.WriteLine ss3

    sw.WriteLine ""
    sw.WriteLine ""
    sw.WriteLine ""

    sw.WriteLine "let GetTag (msg:FIXMessage) ="
    sw.WriteLine "    match msg with"
    let xs = msgs |> List.map (fun msg -> sprintf "    | %s _   -> \"%s\"B" msg.MName msg.Tag )
    xs |> List.iter sw.WriteLine



let GenFactoryFuncs (msgs:Msg list) (sw:StreamWriter) =
    sw.WriteLine "module Fix44.MessageFactoryFuncs"
    sw.WriteLine ""
    sw.WriteLine "// **** this file is generated by fsFixGen ****"
    sw.WriteLine ""
    sw.WriteLine "open OneOrTwo"
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.CompoundItems"
    sw.WriteLine "open Fix44.Messages"
    sw.WriteLine ""
    sw.WriteLine ""
    msgs |> List.iter (fun msg -> CompoundItem.GenFactoryFuncs msg.MName msg.Items sw)