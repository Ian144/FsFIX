module MessageGenerator

open System.IO
open System.Xml.Linq
open System.Xml.XPath

open ParsingFuncs
open FIXGenTypes






//let GenWriteMsgFunction (sw:StreamWriter) (msg:Msg) =
//    let funcSig = sprintf "let Write%s (strm:Stream) (msg:%s) =" msg.Name msg.Name 
//    sw.WriteLine funcSig
//    msg.Fields |> List.iter (genWriteField sw)
//
//    if msg.Groups |> List.isEmpty |> not then  
//        sw.WriteLine ""
//        sw.WriteLine "    // write groups" // todo: deal with optional groups, if the group is optional maybe the 'NoGroupX' count field does not need to be written, what if the number of groups is zero
//        msg.Groups 
//        |> List.sort 
//        |> List.map (fun gg -> {CountFieldName = gg.Name; SubGroupName = gg.Name})
//        |> List.iter (CommonGenerators.writeSubGroup "msg" sw)
//
//    sw.WriteLine ""
//    sw.WriteLine ""
//
//let GenWriteFuncs (msgs:MsgExp list) (sw:StreamWriter) =
//    sw.WriteLine "module Fix44.MsgWriteFuncs"
//    sw.WriteLine ""
//    sw.WriteLine ""
//    sw.WriteLine "open Fix44.Fields"
//    sw.WriteLine "open Fix44.Groups"
//    sw.WriteLine "open Fix44.Messages"
//    sw.WriteLine "open Fix44.FieldReadWriteFuncs"
//    sw.WriteLine "open Fix44.GroupWriteFuncs"
//    sw.WriteLine "open FixTypes"
//    sw.WriteLine "open System.IO"
//    sw.WriteLine ""
//    sw.WriteLine ""
//
//    msgs |> List.iter (fun msg ->
//        sw.WriteLine ""
//        sw.WriteLine ""
//        GenWriteMsgFunction sw msg
//    )


let writeMsg (sw:StreamWriter) (msg:Msg)  = 

//    if msg.MName = "AllocationInstruction" then
//        let itms2 = msg.Items |> FIXItem.filter (fun fi -> (FIXItem.getName fi) = "AccruedInterestAmt")
//        printfn ""

    sw.WriteLine ""
    let ss = sprintf "type %s = {" msg.MName
    sw.Write ss
    sw.WriteLine ""
    let itemsSorted = msg.Items |> List.sortBy CommonGenerator.makeItemStr
    itemsSorted |> (CommonGenerator.writeFIXItemList sw)
    sw.Write  "    }"
    sw.WriteLine ""


let Gen (msgs:Msg list) (sw:StreamWriter) =
    sw.WriteLine "module Fix44.Messages"
    sw.WriteLine ""
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.CompoundItems"
//    sw.WriteLine "open FixTypes"
    sw.WriteLine ""
    sw.WriteLine ""

    msgs |> List.iter (writeMsg sw)






let Read (parentXL:XElement) =
    let msgsXL = parentXL.XPathSelectElements "message"
    [   for msgXL in msgsXL do
        let msgName = gas msgXL "name" 
        let msgType = gas msgXL "msgtype"
        let msgCat = gas msgXL "msgcat"
        if msgName = "AllocationInstruction" then
            printfn ""
        let items = ParsingFuncs.ReadItems [msgName] msgXL
        yield {MName = msgName; Type = msgType; Cat = msgCat; Items = items}
    ]
