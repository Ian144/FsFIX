[<RequireQualifiedAccess>]
module FIXSpecReader

open System.Xml.Linq

open FIXGenTypes






let GetAttributeStr (xl:XElement) (name:string) = 
    let xname = XName.Get name
    let tmp = xl.Attribute xname
    tmp.Value


let MkRequired (str:string) =
    match str with
    | "Y"   -> Required.Required
    | "N"   -> Required.NotRequired
    | _     -> failwith (sprintf "invalid required string: %s" str)


let rec ReadGroup (parents:string list) (el:XElement) =
    let reqStr = GetAttributeStr el "required"
    let req = MkRequired reqStr
    let name = GetAttributeStr el "name"
    let items = ReadItems parents el
    { GName = name; Parents = parents; Required = req; Items = items}


// create a FIXItem from field, component or group XML element, from fix spec xml of the form below
//    <field name="TransactTime" required="N" />
//    <component name="SpreadOrBenchmarkCurveData" required="N" />
//    <group name="NoRoutingIDs" required="N">
//        <field name="RoutingType" required="N" />
//        <field name="RoutingID" required="N" />
//    </group>
//
// not a total function, fails fast if FIX xml cannot be parsed
and ReadFIXItem (parents:string list) (el:XElement) : FIXItem =
    let itemTypeStr = el.Name.ToString()
    let reqStr = GetAttributeStr el "required"
    let req = MkRequired reqStr
    match itemTypeStr with
    | "field"       ->  let fName =  GetAttributeStr el "name"
                        FIXItem.FieldRef {FName = fName; Required = req}
    | "component"   ->  let cmpName =  GetAttributeStr el "name" |> ComponentName
                        FIXItem.ComponentRef {CRName=cmpName; Required=req}
    | "group"       ->  let grp = ReadGroup parents el
                        FIXItem.Group grp
    | _             ->  failwith (sprintf "invalid msg item name: %s" itemTypeStr)

and ReadItems (parents:string list) (parentXL:XElement) =
    [    for el in parentXL.Elements() do
         yield ReadFIXItem parents el    ]


