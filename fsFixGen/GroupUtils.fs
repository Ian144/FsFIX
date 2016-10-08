[<RequireQualifiedAccess>]
module GroupUtils

open FIXGenTypes




let private extractGroups (itms:FIXItem list) : Group list =
    let extractGroup (itm:FIXItem) =
        match itm with 
        | FIXItem.Group grp -> Some grp
        | _                 -> None
    itms |> List.choose extractGroup



let rec private flattenGroups (groups:Group list) = 
    [   for group in groups do
        let subGroups = group.Items |> extractGroups
        yield! flattenGroups subGroups 
        yield group ]



let makeLongName (grp:Group) : GroupLongName =
    let parents = grp.Parents 
    let groupName = grp.GName
    let subNames = parents @ [groupName] |> List.toArray
    let tmp = Utils.joinStrs "_" subNames
    GroupLongName tmp



// groups are defined in component and message elements.
// groups can contain sub-groups.
// groups with the same name in different messages or components may or may not contain the same fields, components and sub-groups.
// groups with the same name containing the same fields and subgroups should be merged into a single group.
// groups which are a dependency of other groups should appear before the other groups in the f# souce file, or there will be a compile error.
let makeMergeMap (grps:Group list) : (GroupLongName*Group) list=

    // flatten the group list so that all are represented in the list directly, not just as children of groups in the list
    let flattenedGroups = 
            grps 
            |> flattenGroups  
            |> List.distinctBy makeLongName // the same component nested in N different messages would result in N definitions for contained groups without this distinct

    // Group the groups ignoring the parentage. Group parents can be messages, components or other groups (they can be nested). 
    // Many groups are identical except they have different parents i.e. they are defined inside a different message or component, but have the same name and contain the same fields, components and sub-groups.
    // For identical sets of groups only one F# group definition needs to be generated.
    // A 'parent based' long name is still required if there is more than one grouping for a given group GName, to distinguish between the different groups,
    //     i.e. there may be two (or more) sets of NoLegs groups, because there are two (or more) sets of fields+components for NoLegs groups
    // The group-grouping (apologies for that) with the largest number of mergeable groups is selected in the event of a clash.
    let mergeables = flattenedGroups 
                            |> List.groupBy (fun grp -> {grp with Parents = []})    // groupBy ignoring parentage, these groups are potentially mergeable
                            |> List.groupBy (fun (keyGroup, _) -> keyGroup.GName)   // groupBy a second time to bring together mergings for groups of the same name but with different field sets
                            |> List.map (fun (_, grpMerges) ->                      // select the grouping for a given name that has the most members
                                    let maxNumMerges = grpMerges |> List.maxBy (fun (_, grps) -> grps.Length)
                                    maxNumMerges )

    [   for (keyGrp, gs) in mergeables do
        let keyGrp2 = {keyGrp with Parents = []}    // so that the long_name of the group is the same as the short name, merged groups do not required a long_name to differentiate them from other groups with the same short name
        for grp in gs do
        let longName = makeLongName grp
        yield longName, keyGrp2  ]




let updateItemIfMergeableGroup (grpMergeMap:Map<GroupLongName,Group>) (item:FIXItem) =
    match item with
    | FIXItem.Group grp     ->  let longName = makeLongName grp
                                if grpMergeMap.ContainsKey longName then
                                    FIXItem.Group grpMergeMap.[longName]
                                else
                                    item
    | FIXItem.Component _   ->  item
    | FIXItem.Field _       ->  item



let excludeFieldsFilter (excludeFieldNames:Set<string>) (item:FIXItem) =
    match item with
    | FIXItem.Group _       ->  false
    | FIXItem.Component _   ->  false
    | FIXItem.Field fld     ->  Set.contains fld.FName excludeFieldNames


