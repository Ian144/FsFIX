module CompoundItemGenerator

open System.IO
open FIXGenTypes





let private writeComponent (cmp:Component) (sw:StreamWriter) = 
    sw.WriteLine ""
    sw.WriteLine "// component"
    let (ComponentName name) = cmp.CName
    let ss = sprintf "type %s = {"  name// different from write group
    sw.Write ss
    sw.WriteLine ""
    cmp.Items |> (CommonGenerator.writeFIXItemList sw)
    sw.Write  "    }"
    sw.WriteLine ""


// todo: use static class + overloading, dictionary of operations or ^t + member constraints to write a single type generator function for components, groups and messages
let private writeGroup (grp:Group) (sw:StreamWriter) = 
    sw.WriteLine ""
    sw.WriteLine "// group"
    let (GroupLongName grpName) = GroupUtils.makeLongName grp // merged groups have an empty parent list, so the long name is correct
    let ss = sprintf "type %sGrp = {" grpName
    sw.Write ss
    sw.WriteLine ""
    grp.Items |> (CommonGenerator.writeFIXItemList sw)
    sw.Write  "    }"
    sw.WriteLine ""


let Gen (cmpItems:CompoundItem list) (swCompItms:StreamWriter) =
    swCompItms.WriteLine "module Fix44.CompoundItems"
    swCompItms.WriteLine ""
    swCompItms.WriteLine "open Fix44.Fields"
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""
    cmpItems |> List.iter (fun ci ->
                    match ci with
                    | CompoundItem.Group    grp     -> writeGroup grp swCompItms
                    | CompoundItem.Component comp   -> writeComponent comp swCompItms    )
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""

    // write the 'group' DU
    let groups = cmpItems |> CompoundItemFuncs.extractGroups
    swCompItms.WriteLine  "type FIXGroup ="
    groups 
    |> List.map GroupUtils.makeLongName
    |> List.sort 
    |> List.iter (fun grpLngName ->
            let (GroupLongName strName) = grpLngName
            let ss  = sprintf "    | %sGrp of %sGrp" strName strName
            swCompItms.WriteLine ss  )



let getGroupContainerType (grp:Group) = 
    if grp.GName.Contains "NoLegs" then
        "OneOrTwo.iter"
    else
        "List.iter" // todo, consider changing the default group container type to array for better cache locality


// writes both sub-groups embedded in groups and groups embedded in msgs
let writeSubGroup (parent:string) (sw:StreamWriter) (grp:Group) = 
    let (GroupLongName groupLongName) = GroupUtils.makeLongName grp
    let countFieldName = grp.GName  // a groups shortName is that of the field containing the count
    let isNoSides = countFieldName = "NoSides"
    if isNoSides then               // todo, consider adding a bool tag to fields to indicate if they are a
        sw.WriteLine            "    let noSidesField ="
        sw.WriteLine (sprintf   "        match %s.NoSidesGrp with" parent)
        sw.WriteLine            "        | One _ -> NoSides.OneSide"
        sw.WriteLine            "        | Two _ -> NoSides.BothSides"
        sw.WriteLine            "    WriteNoSides strm noSidesField"
        sw.WriteLine (sprintf   "    %s.NoSidesGrp |> FixTypes.OneOrTwoIter (WriteNoSidesGrp strm)" parent)
    else
        sw.WriteLine (sprintf   "    if (%s.%sGrp |> List.isEmpty |> not) then " parent groupLongName)
        sw.WriteLine (sprintf   "        let numGrps = %s.%sGrp.Length" parent groupLongName)
        sw.WriteLine (sprintf   "        Write%s strm (Fix44.Fields.%s numGrps) // write the 'num group repeats' field" countFieldName countFieldName)
        sw.WriteLine (sprintf   "        %s.%sGrp |> List.iter (fun gg -> Write%sGrp strm gg)" parent groupLongName groupLongName)



let private genItemListWriterStrs (items:FIXItem list) =
    items |> List.map (fun item ->
                match item with
                | FIXItem.Field fld         ->  match fld.Required with
                                                | Required.Required     ->  sprintf "    Write%s strm grp.%s" fld.FName fld.FName
                                                | Required.NotRequired  ->  sprintf "    grp.%s |> Option.iter (Write%s strm)" fld.FName fld.FName
                | FIXItem.ComponentRef cmp  ->  let (ComponentName name) = cmp.CRName
                                                match cmp.Required with
                                                | Required.Required     ->  sprintf "    Write%s strm grp.%s    // component" name name
                                                | Required.NotRequired  ->  sprintf "    grp.%s |> Option.iter (Write%s strm) // component" name name
                | FIXItem.Group grp         ->  let (GroupLongName name) = GroupUtils.makeLongName grp
                                                let grpIterFunc = getGroupContainerType grp
                                                match grp.Required with
                                                | Required.Required     ->  sprintf "    grp.%sGrp |> %s (Write%sGrp strm)   // group" name grpIterFunc name
                                                | Required.NotRequired  ->  sprintf "    grp.%sGrp |> Option.iter (fun xs -> xs |> %s (Write%sGrp strm))    // group WRITE THE NOGROUP FIELD" name grpIterFunc name
                ) // end List.map



let private genGroupWriterFunc (sw:StreamWriter) (grp:Group) =
    sw.WriteLine "// group"
    let (GroupLongName grpName) = GroupUtils.makeLongName grp
    let funcSig = sprintf "let Write%sGrp (strm:System.IO.Stream) (grp:%sGrp) =" grpName grpName 
    sw.WriteLine funcSig
    // todo: check the fix spec regarding required fields in groups that might be optional? how can reading work if fields can be missing?
    let writeGroupFuncStrs = genItemListWriterStrs grp.Items
    writeGroupFuncStrs |> List.iter sw.WriteLine
    sw.WriteLine ""
    sw.WriteLine ""

let private genComponentWriterFunc (sw:StreamWriter) (cmp:Component) =
    sw.WriteLine "// component"
    let (ComponentName name) = cmp.CName
    let funcSig = sprintf "let Write%s (strm:System.IO.Stream) (grp:%s) =" name name  // todo, don't call a component instance a group
    sw.WriteLine funcSig
    let writeGroupFuncStrs = genItemListWriterStrs cmp.Items
    writeGroupFuncStrs |> List.iter sw.WriteLine
    sw.WriteLine ""
    sw.WriteLine ""



let private funcx (sw:StreamWriter) (ci:CompoundItem) =
    match ci with
    | CompoundItem.Group grp        -> genGroupWriterFunc sw grp
    | CompoundItem.Component cmp    -> genComponentWriterFunc sw cmp
    


let GenWriteFuncs (groups:CompoundItem list) (sw:StreamWriter) =
    // generate the group write functions todo: generate group read funcs
    sw.WriteLine "module Fix44.CompoundItemWriteFuncs"
    sw.WriteLine ""
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.FieldReadWriteFuncs"
    sw.WriteLine "open Fix44.CompoundItems"
    sw.WriteLine "open OneOrTwo"
    sw.WriteLine ""
    sw.WriteLine ""
    groups |> List.iter (funcx sw)  


