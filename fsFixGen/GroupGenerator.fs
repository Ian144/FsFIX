module GroupGenerator

open System.Xml.Linq
open System.Xml.XPath
open System.IO

open ParsingFuncs
open FIXGenTypes



let extractGroups (itms:FIXItem list) : Group list =
    let extractGroup (itm:FIXItem) =
        match itm with 
        | FIXItem.Group grp -> Some grp
        | _                 -> None
    itms |> List.choose extractGroup



let rec flattenGroups (groups:Group list) = 
    [   for group in groups do
        let subGroups = group.Items |> extractGroups
        yield! flattenGroups subGroups 
        yield group ]



let private xmakeGroupCompoundName (grp:Group) : string =
    let parents = grp.Parents 
    let groupName = grp.GName
    let subNames = parents @ [groupName] |> List.toArray
    Utils.joinStrs "_" subNames




let writeComponent (xx:Component) (sw:StreamWriter) = 
    sw.WriteLine "\n    // component"
    let ss = sprintf "type %s = {\n" xx.CName.Value // different from write gropu
    sw.Write ss
    let groupDefStrs = 
        xx.Items
            |> List.map (fun item ->
                match item with
                | FIXItem.Field fld     ->  match fld.Required with
                                            | Required.Required     ->  sprintf "    %s: %s" fld.FName fld.FName
                                            | Required.NotRequired  ->  sprintf "    %s: %s option" fld.FName fld.FName
                | FIXItem.Component cmp ->  match cmp.Required with
                                            | Required.Required     ->  sprintf "    %s: %s // component" cmp.CRName.Value cmp.CRName.Value
                                            | Required.NotRequired  ->  sprintf "    %s: %s option // component" cmp.CRName.Value cmp.CRName.Value
                | FIXItem.Group grp     ->  match grp.Required with
                                            | Required.Required     ->  sprintf "    %sGrp: %sGrp // group" grp.GName grp.GName
                                            | Required.NotRequired  ->  sprintf "    %sGrp: %sGrp option // group" grp.GName grp.GName

                ) // end List.map
            
    groupDefStrs |> List.iter sw.WriteLine
    sw.Write  "    }\n"
    ()



let writeGroup (grp:Group) (sw:StreamWriter) = 
    sw.WriteLine "\n    // group"
    let ss = sprintf "type %sGrp = {\n" grp.GName
    sw.Write ss
    let groupDefStrs = 
        grp.Items
            |> List.map (fun item ->
                match item with
                | FIXItem.Field fld     ->  match fld.Required with
                                            | Required.Required     ->  sprintf "    %s: %s" fld.FName fld.FName
                                            | Required.NotRequired  ->  sprintf "    %s: %s option" fld.FName fld.FName
                | FIXItem.Component cmp ->  match cmp.Required with
                                            | Required.Required     ->  sprintf "    %s: %s // component" cmp.CRName.Value cmp.CRName.Value
                                            | Required.NotRequired  ->  sprintf "    %s: %s option // component" cmp.CRName.Value cmp.CRName.Value
                | FIXItem.Group grp     ->  match grp.Required with
                                            | Required.Required     ->  sprintf "    %sGrp: %sGrp // group" grp.GName grp.GName
                                            | Required.NotRequired  ->  sprintf "    %sGrp: %sGrp option // group" grp.GName grp.GName

                ) // end List.map
            
    groupDefStrs |> List.iter sw.WriteLine
    sw.Write  "    }\n"
    ()


//let private writeGroups (allGroups:Group list) (sw:StreamWriter) =
//    allGroups |> List.iter (fun grp ->
//            sw.WriteLine "\n"
//            let ss = sprintf "type %sGrp = {\n" grp.GName
//            sw.Write ss
//            let groupDefStrs = 
//                grp.Items
//                    |> List.map (fun item ->
//                        match item with
//                        | FIXItem.Field fld     ->  match fld.Required with
//                                                    | Required.Required     ->  sprintf "    %s: %s" fld.FName fld.FName
//                                                    | Required.NotRequired  ->  sprintf "    %s: %s option" fld.FName fld.FName
//                        | FIXItem.Component cmp ->  match cmp.Required with
//                                                    | Required.Required     ->  sprintf "    %s: %s // component" cmp.CRName.Value cmp.CRName.Value
//                                                    | Required.NotRequired  ->  sprintf "    %s: %s option // component" cmp.CRName.Value cmp.CRName.Value
//                        | FIXItem.Group grp     ->  match grp.Required with
//                                                    | Required.Required     ->  sprintf "    %s: %s // group" grp.GName grp.GName
//                                                    | Required.NotRequired  ->  sprintf "    %s: %s option // group" grp.GName grp.GName
//
//                        ) // end List.map
//            
//            groupDefStrs |> List.iter sw.WriteLine
//            sw.Write  "    }"
//            ) // end outer List.iter



let private genGroupWriterFunc (sw:StreamWriter) (grp:Group) =
    let grpName = grp.GName
    let funcSig = sprintf "let Write%sGrp (strm:System.IO.Stream) (grp:%sGrp) =" grpName grpName 
    sw.WriteLine funcSig
    // todo: check the fix spec re`garding required fields in groups that might be optional? how can reading work if fields can be missing?
    let writeGroupFuncStrs = 
        grp.Items |> List.map (fun item ->
                    match item with
                    | FIXItem.Field fld     ->  match fld.Required with
                                                | Required.Required     ->  sprintf "    Write%s strm grp.%s" fld.FName fld.FName
                                                | Required.NotRequired  ->  sprintf "    grp.%s |> Option.iter (Write%s strm)" fld.FName fld.FName
                    | FIXItem.Component cmp ->  "grp component writer func not implemented"
                    | FIXItem.Group grp     ->  "grp subgroup writer func not implemented"
                    ) // end List.map
    writeGroupFuncStrs |> List.iter sw.WriteLine
    sw.WriteLine ""
    sw.WriteLine ""



//let private  GenFactoryFuncs (grps:GroupGen list) (sw:StreamWriter) =
//    sw.WriteLine "module Fix44.GroupFactoryFuncs"
//    sw.WriteLine ""
//    sw.WriteLine "open FixTypes"
//    sw.WriteLine "open Fix44.Fields"
//    sw.WriteLine "open Fix44.Groups"
//    sw.WriteLine "open Fix44.FieldReadWriteFuncs"
//    sw.WriteLine ""
//    sw.WriteLine ""
//    CommonGenerators.GenFactoryFuncGroups grps sw



// groups are defined in component and message elements.
// groups can contain sub-groups.
// groups with the same name in different messages or components may or may not contain the same fields.
// groups with the same name containing the same fields and subgroups should be merged into a single group.
// groups which are a dependency of other groups should appear before the other groups in the f# souce file, or there will be a compile error.
//let GetGroupsInDependencyOrder (compoundItems:CompoundItem list) =
//
//    let cis = compoundItems
//    // flatten the compound items so that all are represented in the list directly, not just as children of groups in the list
//
////    let flattenedGroups = 
////            grps 
////            |> flattenGroups  
//////            |> List.sortByDescending (fun grp -> (grp.Parents.Length, makeGroupCompoundName grp)) 
////            |> List.distinctBy makeGroupCompoundName // the same component nested in N different messages would result in N definitions for contained groups without this distinct
////
////    // Group the groups, many groups are identical except they have different parents
////    // i.e. they are defined inside a different message or component, but have the same name and contain the same fields, components and sub-groups.
////    // If the group refered to in a msg is one of an identical set, then only one group definition needs to be created.
////    let groupedGroups = flattenedGroups |> List.groupBy (fun grp -> {grp with Parents = []})
////
////    // A 'parent based' long name is still required, if there is more than one grouping for a given group GName, to distinguish between the different groups
////    // i.e. there may be two (or more) sets of NoLegs groups, because there are two (or more) sets of fields for NoLegs groups
////    // The group-grouping (apologies for that) with the largest number of mergeable groups is selected in the event of a clash.
////    let groupedGroups2 = groupedGroups 
////                            |> List.groupBy (fun (keyGroup, _) -> keyGroup.GName) // group a second time, to bring together group mergings for groups of the same name (but with different field sets)
////                            |> List.map (fun (_, grpMerges) ->  
////                                    let maxNumMerges = grpMerges |> List.maxBy (fun (_, grps) -> grps.Length)
////                                    maxNumMerges )
////    let mergedGroups = 
////        [   for (keyGroup, _) in groupedGroups2 do
////            yield keyGroup ]
////
////    // make a map of group 'long name' to group short name, for those groups that can be merged
////    let mergableGroupNameMap = 
////        [   for (keyGrp, gs) in groupedGroups2 do
////            for grp in gs do
////            let longName = makeGroupCompoundName grp
////            yield longName, keyGrp.GName
////        ] |> Map.ofList
////
////    
////    let getNameToUse grp = 
////        let longName = makeGroupCompoundName grp
////        match mergableGroupNameMap.TryFind longName with
////        | Some commonName   -> commonName
////        | None              -> longName
////        
////
////    let groupsThatCantBeMerged = flattenedGroups |> List.filter ( fun grp -> 
////                                    let longName = makeGroupCompoundName grp
////                                    mergableGroupNameMap.ContainsKey longName |> not )
////
////    let gs = (mergedGroups @ groupsThatCantBeMerged)
////
////    let repointedGroups = 
////        [   for grp in gs do 
////            let name = getNameToUse grp
//////            let subGroups = grp.Items |> extractGroups |> List.map (fun subGrp -> {CountFieldName = subGrp.GName; SubGroupName = subGrp.GName})
////            yield { grp with GName = name} 
////            ] |> List.sort
////
////    DependencyConstraintSolver.ConstrainGroupDependencyOrder repointedGroups
//    []
//



//let Gen (groups:Group list) (swGroups:StreamWriter) (swGenGroupWriteFuncs:StreamWriter) =
//    swGroups.WriteLine "module Fix44.Groups"
//    swGroups.WriteLine ""
//    swGroups.WriteLine "open Fix44.Fields"
//    writeGroups groups swGroups
//
//    swGroups.WriteLine ""
//    swGroups.WriteLine ""
//    swGroups.WriteLine ""
//    swGroups.WriteLine ""
//
//    // write the 'group' DU
//    swGroups.WriteLine  "type FIXGroup ="
//    groups 
//    |> List.sort
//    |> List.iter (fun grp ->
//            let ss  = sprintf "    | %sGrp of %sGrp" grp.GName grp.GName
//            swGroups.WriteLine ss  )
//
//    // generate the group write functions todo: generate group read funcs
//    swGenGroupWriteFuncs.WriteLine "module Fix44.GroupWriteFuncs"
//    swGenGroupWriteFuncs.WriteLine ""
//    swGenGroupWriteFuncs.WriteLine "open Fix44.Fields"
//    swGenGroupWriteFuncs.WriteLine "open Fix44.Groups"
//    swGenGroupWriteFuncs.WriteLine "open Fix44.FieldReadWriteFuncs"
//    swGenGroupWriteFuncs.WriteLine ""
//    swGenGroupWriteFuncs.WriteLine ""
//    groups |> List.iter (genWriteGroupFunction swGenGroupWriteFuncs)
