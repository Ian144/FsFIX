module CompoundItemGenerator

open System.IO
open ParsingFuncs
open FIXGenTypes








let Gen (cmpItems:CompoundItem list) (swCompItms:StreamWriter) (swGenGroupWriteFuncs:StreamWriter) =
    swCompItms.WriteLine "module Fix44.CompoundItems"
    swCompItms.WriteLine ""
    swCompItms.WriteLine "open Fix44.Fields"
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""
    cmpItems |> List.iter (fun ci ->
                    match ci with
                    | CompoundItem.Group    grp     -> GroupGenerator.writeGroup grp swCompItms
                    | CompoundItem.Component comp   -> GroupGenerator.writeComponent comp swCompItms    )
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

//    // generate the group write functions todo: generate group read funcs
//    swGenGroupWriteFuncs.WriteLine "module Fix44.GroupWriteFuncs"
//    swGenGroupWriteFuncs.WriteLine ""
//    swGenGroupWriteFuncs.WriteLine "open Fix44.Fields"
//    swGenGroupWriteFuncs.WriteLine "open Fix44.Groups"
//    swGenGroupWriteFuncs.WriteLine "open Fix44.FieldReadWriteFuncs"
//    swGenGroupWriteFuncs.WriteLine ""
//    swGenGroupWriteFuncs.WriteLine ""
//    groups |> List.iter (genWriteGroupFunction swGenGroupWriteFuncs)