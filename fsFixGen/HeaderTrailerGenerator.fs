module HeaderTrailerGenerator

open System.Xml.Linq
open System.IO

open FIXGenTypes


let ReadHeader (excludeFieldNames:Set<string>) (xl:XElement) : Header =
    let items = ParsingFuncs.ReadItems ["Header"] xl |> List.filter (FIXItem.excludeFieldsFilter excludeFieldNames)
    {HItems = items}



let ReadTrailer (excludeFieldNames:Set<string>) (xl:XElement)  =
    let items = ParsingFuncs.ReadItems ["Trailer"] xl |> List.filter (FIXItem.excludeFieldsFilter excludeFieldNames)
    {TItems = items}



let genHeader (sw:StreamWriter) (hdr:Header) (trailer:Trailer) : unit =
    // generate the group write functions todo: generate group read funcs
    sw.WriteLine "module Fix44.HeaderTrailer"
    sw.WriteLine ""
    sw.WriteLine ""
    sw.WriteLine "open OneOrTwo"
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.CompoundItems"

    sw.WriteLine ""
    sw.Write "type Header = {"
    sw.WriteLine ""
    hdr.HItems |> (CommonGenerator.writeFIXItemList sw)
    sw.Write  "    }"
    sw.WriteLine ""

    sw.WriteLine ""
    sw.Write "type Trailer = {"
    sw.WriteLine ""
    trailer.TItems |> (CommonGenerator.writeFIXItemList sw)
    sw.Write  "    }"
    sw.WriteLine ""


