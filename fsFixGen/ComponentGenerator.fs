module ComponentGenerator




open System.Xml.Linq
open System.Xml.XPath

open ParsingFuncs
open FIXGenTypes




let Read (parentXL:XElement) =
    let compsXL = parentXL.XPathSelectElements "component"
    [   for compXL in compsXL do
        let compName = gas compXL "name" 
        let items = ParsingFuncs.ReadItems [compName] compXL
        yield {CName = ComponentName compName; Items = items}
    ]