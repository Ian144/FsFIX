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


let private genMsgWriterFunc (sw:StreamWriter) (msg:Msg) =
    let name = msg.MName
    let funcSig = sprintf "let Write%s (strm:System.IO.Stream) (grp:%s) =" name name  // todo, don't call a component instance a group
    sw.WriteLine funcSig
    let writeGroupFuncStrs = CommonGenerator.genItemListWriterStrs msg.Items
    writeGroupFuncStrs |> List.iter sw.WriteLine
    sw.WriteLine ""
    sw.WriteLine ""


let GenWriteFuncs (groups:Msg list) (sw:StreamWriter) =
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
    groups |> List.iter (genMsgWriterFunc sw)  


