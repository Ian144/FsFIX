module MessageGenerator

open System.IO
open System.Xml.Linq
open System.Xml.XPath

open ParsingFuncs
open FIXGenTypes



let Read (parentXL:XElement) =
    let msgsXL = parentXL.XPathSelectElements "message"
    [   for msgXL in msgsXL do
        let msgName = gas msgXL "name" 
        let msgType = gas msgXL "msgtype"
        let msgCat = gas msgXL "msgcat"
        let items = ParsingFuncs.ReadItems [msgName] msgXL
        yield {MName = msgName; Tag = msgType; Cat = msgCat; Items = items}
    ]



let private writeMsg (sw:StreamWriter) (msg:Msg)  = 
    sw.WriteLine ""
    let ss = sprintf "type %s = {" msg.MName
    sw.Write ss
    sw.WriteLine ""
    msg.Items |> (CommonGenerator.writeFIXItemList sw)
    sw.Write  "    }"
    sw.WriteLine ""


let Gen (msgs:Msg list) (sw:StreamWriter) =
    sw.WriteLine "module Fix44.Messages"
    sw.WriteLine ""
    sw.WriteLine "open OneOrTwo"
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.CompoundItems"
    sw.WriteLine ""
    sw.WriteLine ""

    msgs |> List.iter (writeMsg sw)


let private makeParamStr (fi:FIXItem) =
    let typeName = fi |> FIXItem.getName
    let valName  = typeName |> Utils.lCaseFirstChar
    sprintf "(%s:%s)" valName typeName


let private makeFuncSig (requiredHdrItems:FIXItem list) (msg:Msg) =
    let name = msg.MName
    let paramStr = requiredHdrItems |> List.map makeParamStr
    let allParamStr = paramStr |> Utils.joinStrs " "
    let funcSig = sprintf "let Write%s (dest:byte []) (nextFreeIdx:int) %s (xx:%s) = " name allParamStr name
    funcSig


let private genMsgWriterFunc (requiredHdrItems:FIXItem list) (sw:StreamWriter) (msg:Msg) =
    let name = msg.MName
    let cmnt = sprintf "// tag: %s" msg.Tag
    sw.WriteLine cmnt
    let funcSig = makeFuncSig requiredHdrItems msg
    sw.WriteLine funcSig
    let writeGroupFuncStrs = CommonGenerator.genItemListWriterStrs msg.Items
    writeGroupFuncStrs |> List.iter sw.WriteLine
    sw.WriteLine "    nextFreeIdx"
    sw.WriteLine ""
    sw.WriteLine ""


let GenWriteFuncs (hdrItems:FIXItem list) (groups:Msg list) (sw:StreamWriter) =
    let requiredHdrFields, optionalHdrFields = hdrItems |> List.partition FIXItem.getIsRequired

    // generate the group write functions todo: generate group read funcs
    sw.WriteLine "module Fix44.MsgWriteFuncs"
    sw.WriteLine ""
    sw.WriteLine "open OneOrTwo"
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.FieldReadWriteFuncs"
    sw.WriteLine "open Fix44.CompoundItems"
    sw.WriteLine "open Fix44.CompoundItemWriteFuncs"
    sw.WriteLine "open Fix44.Messages"
    sw.WriteLine ""
    sw.WriteLine ""
    groups |> List.iter (genMsgWriterFunc requiredHdrFields sw)  


