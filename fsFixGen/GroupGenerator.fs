module GroupGenerator

open System.Xml.Linq
open System.Xml.XPath

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



let private makeGroupCompoundName (grp:Group) : string =
    let parents = grp.Parents 
    let groupName = grp.GName
    let subNames = parents @ [groupName] |> List.toArray
    Utils.joinStrs "_" subNames




// groups are defined in component and message elements.
// groups can contain sub-groups.
// groups with the same name in different messages or components may or may not contain the same fields.
// groups with the same name containing the same fields and subgroups should be merged into a single group.
// groups which are a dependency of other groups should appear before the other groups in the f# souce file, or there will be a compile error.
let GetGroupsInDependencyOrder (grps:Group list) =

    // flatten the groups such that all groups are represented in the list directly, not just as children of groups in the list
    let flattenedGroups = 
            grps 
            |> flattenGroups  
//            |> List.sortByDescending (fun grp -> (grp.Parents.Length, makeGroupCompoundName grp)) 
            |> List.distinctBy makeGroupCompoundName // the same component nested in N different messages would result in N definitions for contained groups without this distinct

    // Group the groups, many groups are identical except they have different parents
    // i.e. they are defined inside a different message or component, but have the same name and contain the same fields, components and sub-groups.
    // If the group refered to in a msg is one of an identical set, then only one group definition needs to be created.
    let groupedGroups = flattenedGroups |> List.groupBy (fun grp -> {grp with Parents = []})

    // A 'parent based' long name is still required, if there is more than one grouping for a given group GName, to distinguish between the different groups
    // i.e. there may be two (or more) sets of NoLegs groups, because there are two (or more) sets of fields for NoLegs groups
    // The group-grouping (apologies for that) with the largest number of mergeable groups is selected in the event of a clash.
    let groupedGroups2 = groupedGroups 
                            |> List.groupBy (fun (keyGroup, _) -> keyGroup.GName) // group a second time, to bring together group mergings for groups of the same name (but with different field sets)
                            |> List.map ( fun (_, grpMerges) ->  
                                    let maxNumMerges = grpMerges |> List.maxBy (fun (_, grps) -> grps.Length)
                                    maxNumMerges    )
    let mergedGroups = 
        [   for (keyGroup, _) in groupedGroups2 do
            yield keyGroup ]

    // make a map of group 'long name' to group short name, for those groups that can be merged
    let mergableGroupNameMap = 
        [   for (keyGrp, gs) in groupedGroups2 do
            for grp in gs do
            let longName = makeGroupCompoundName grp
            yield longName, keyGrp.GName
        ] |> Map.ofList

    
    let getNameToUse grp = 
        let longName = makeGroupCompoundName grp
        match mergableGroupNameMap.TryFind longName with
        | Some commonName   -> commonName
        | None              -> longName
        

    let groupsThatCantBeMerged = flattenedGroups |> List.filter ( fun grp -> 
                                    let longName = makeGroupCompoundName grp
                                    mergableGroupNameMap.ContainsKey longName |> not )

    let gs = (mergedGroups @ groupsThatCantBeMerged)

    let repointedGroups = 
        [   for grp in gs do 
            let name = getNameToUse grp
//            let subGroups = grp.Items |> extractGroups |> List.map (fun subGrp -> {CountFieldName = subGrp.GName; SubGroupName = subGrp.GName})
            yield { grp with GName = name} 
            ] |> List.sort

    let dependencyOrderGroups  = DependencyConstraintSolver.ConstrainGroupDependencyOrder repointedGroups
    dependencyOrderGroups
