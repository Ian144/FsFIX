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
    let funcSig = sprintf "let Read%s (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) =" msg.MName
    sw.WriteLine funcSig
    let readFIXItemStrs = CommonGenerator.genItemListReaderStrsIdx fieldNameMap compNameMap msg.MName msg.Items
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
    sw.WriteLine "open OneOrTwo"
    sw.WriteLine "open ReaderUtils"
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.FieldReaders"
    sw.WriteLine "open Fix44.CompoundItems"
    sw.WriteLine "open Fix44.CompoundItemReaders"
    sw.WriteLine "open Fix44.Messages"
    sw.WriteLine ""
    sw.WriteLine ""
    xs |> List.iter (genMsgReaderFunc fieldNameMap compNameMap sw)




let GenMessageDU (msgs:Msg list) (sw:StreamWriter) =

    // write the 'group/component' DU, used only in property based tests
    sw.WriteLine "module Fix44.MessageDU"
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
    sw.WriteLine "let ReadMessage selector bs (index:FIXBufIndexer.FixBufIndex) ="
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


    // create the 'ReadMessage' DU function that keys off a msg tag
//   sw.WriteLine "let ReadMessageDU tag bs (index:FIXBufIndexer.FixBufIndex) ="
//    msgs |> List.iter (fun msg ->
//                let ss = sprintf "    | \"%s\"B   ->  Read%s bs index |> FIXMessage.%s"  msg.Tag msg.MName msg.MName
//                sw.WriteLine ss )
//    let ss1  = "    | invalidTag   ->"
//    let ss2  = "        let ss = sprintf \"received unknown message type tag: %A\" invalidTag"
//    let ss3  = "        failwith ss"
//    sw.WriteLine ss1
//    sw.WriteLine ss2
//    sw.WriteLine ss3
    
    sw.WriteLine "let ReadMessageDU (tag:Fix44.Fields.MsgType) bs (index:FIXBufIndexer.FixBufIndex) ="
    sw.WriteLine "    match tag with"
    msgs |> List.iter (fun msg ->
                //let ss = sprintf "    | \"%s\"B   ->  Read%s bs index |> FIXMessage.%s"  msg.Tag msg.MName msg.MName
                let ss = sprintf "    | Fix44.Fields.MsgType.%s   ->  Read%s bs index |> FIXMessage.%s"  msg.MName msg.MName msg.MName
                sw.WriteLine ss )
    let ss1  = "    | invalidTag   ->"
    let ss2  = "        // FIX4.4.xml (the quickfix.net version at least) does not define and XMLMessage, for which there is a Fix44.Fields.MsgType DU case"
    let ss2  = "        let ss = sprintf \"received unknown message type tag: %A\" invalidTag"
    let ss3  = "        failwith ss"
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
