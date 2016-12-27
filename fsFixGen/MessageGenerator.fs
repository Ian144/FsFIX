[<RequireQualifiedAccess>]
module MessageGenerator

open System.IO
open System.Xml.Linq
open System.Xml.XPath

open FIXGenTypes



let Read (parentXL:XElement) =
    let msgsXL = parentXL.XPathSelectElements "message"
    [   for msgXL in msgsXL do
        let msgName = ParsingFuncs.gas msgXL "name" 
        let msgType = ParsingFuncs.gas msgXL "msgtype"
        let msgCat = ParsingFuncs.gas msgXL "msgcat"
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
    let valName  = typeName |> StringEx.lCaseFirstChar
    sprintf "(%s:%s)" valName typeName


let private makeFuncSig (requiredHdrItems:FIXItem list) (msg:Msg) =
    let name = msg.MName
    let paramStr = requiredHdrItems |> List.map makeParamStr
    let allParamStr = paramStr |> StringEx.join " "
    let funcSig = sprintf "let Write%s (dest:byte []) (nextFreeIdx:int) %s (xx:%s) = " name allParamStr name
    funcSig


// todo: put both versions of this in CommonGenerator
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
    sw.WriteLine "module Fix44.MsgWriteFuncs"
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
    let funcSig = sprintf "let Read%s (bs:byte []) (pos:int) : int * %s  =" msg.MName msg.MName
    sw.WriteLine funcSig
    let readFIXItemStrs = CommonGenerator.genItemListReaderStrs fieldNameMap compNameMap msg.MName msg.Items
    readFIXItemStrs |> List.iter sw.WriteLine
    let fieldInitStrs = genFieldInitStrs msg.Items
    sw.WriteLine (sprintf "    let ci:%s = {" msg.MName)
    fieldInitStrs |> List.iter sw.WriteLine
    sw.WriteLine "    }"
    sw.WriteLine "    pos, ci"
    sw.WriteLine ""
    sw.WriteLine ""


let GenReadFuncs (fieldNameMap:Map<string,Field>) (compNameMap:Map<ComponentName,Component>) (hdrItems:FIXItem list) (xs:Msg list) (sw:StreamWriter) =
    // let requiredHdrFields, optionalHdrFields = hdrItems |> List.partition FIXItem.getIsRequired
    // generate the group write functions todo: generate group read funcs
    sw.WriteLine "module Fix44.MsgReadFuncs"
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
    sw.WriteLine "open Fix44.MsgWriteFuncs"
    sw.WriteLine "open Fix44.MsgReadFuncs"
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
    sw.WriteLine "let ReadMessage (selector:FIXMessage) bs pos ="
    sw.WriteLine "    match selector with"
    names |> List.iter (fun strName ->
                let ss1  = sprintf "    | %s _ ->" strName
                let ss2  = sprintf "        let pos, msg = Read%s  bs pos" strName
                let ss3 =  sprintf "        pos, msg |> FIXMessage.%s" strName
                sw.WriteLine ss1
                sw.WriteLine ss2
                sw.WriteLine ss3 ) // end List.iter
    sw.WriteLine ""
    sw.WriteLine ""
    sw.WriteLine ""


    // create the 'ReadMessage' DU function that keys off a msg tag
    sw.WriteLine "let ReadMessageDU (tag:byte []) bs pos ="
    sw.WriteLine "    match tag with"
    msgs |> List.iter (fun msg ->
                let ss1  = sprintf "    | \"%s\"B   ->" msg.Tag
                let ss2  = sprintf "        let pos, msg = Read%s bs pos" msg.MName
                let ss3 =  sprintf "        pos, msg |> FIXMessage.%s" msg.MName
                sw.WriteLine ss1
                sw.WriteLine ss2
                sw.WriteLine ss3 ) // end List.iter
    let ss1  = "    | invalidTag   ->"
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
