module MessageGenerator

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
        yield {MName = msgName; Type = msgType; Cat = msgCat; Items = items}
    ]
