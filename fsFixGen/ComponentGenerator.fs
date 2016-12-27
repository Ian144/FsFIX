module ComponentGenerator


open System.Xml.Linq
open System.Xml.XPath
open FIXGenTypes



//todo: this file is not doing generation, give it a different name

let Read (parentXL:XElement) =
    let compsXL = parentXL.XPathSelectElements "component"
    [   for compXL in compsXL do
        let compName = FIXSpecReader.GetAttributeStr compXL "name" 
        let items = FIXSpecReader.ReadItems [compName] compXL
        yield {CName = ComponentName compName; Items = items}
    ]











