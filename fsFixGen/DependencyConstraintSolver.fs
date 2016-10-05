[<RequireQualifiedAccess>]
module DependencyConstraintSolver


open FIXGenTypes



let private makeGroupOrderConstraints (grps:Group list) = 
    [   for grp in grps do
        let subGroups = grp.Items |> GroupUtils.extractGroups
        for depGrp in subGroups do
        yield (grp.GName, depGrp.GName) ]



let private buildDependencyTree (mapIn:Map<string, string list>) (grp,depGrp) = 
    if mapIn.ContainsKey grp then
        let curDeps = mapIn.[grp]
        let newDeps = depGrp::curDeps
        mapIn.Add (grp, newDeps)
    else
        mapIn.Add (grp, [depGrp])



// turns a dependency tree into a list
let private listifyDependencyTree (grp:string) (mapIn:Map<string, string list>) =
    let rec listifyDependencyTreeInner (grp:string) (mapIn:Map<string, string list>) =
        let getVals (gn:string) (mp:Map<string, string list>) = if mp.ContainsKey gn then  mp.[gn] else []
        [   for depGrp in getVals grp mapIn do
            yield depGrp
            yield! listifyDependencyTreeInner depGrp mapIn ]
    grp :: listifyDependencyTreeInner grp mapIn



// returns a list of all groups, with groups that are depended upon earlier in the list than groups that depend on them.   
let ConstrainGroupDependencyOrder (grps:Group list) = 
    let constraints = makeGroupOrderConstraints grps

    // a group name is a root if it is not referred to as a dependency
    let nonRootGroups = constraints |> List.map snd |> Set.ofList
    let roots = constraints |> List.map fst |> List.filter (nonRootGroups.Contains >> not) |> List.distinct

    // a constrained group is referred to in a constraint
    let constrainedGroupSet = (constraints |> List.map fst) @ (constraints |> List.map snd) |> Set.ofList

    // an unconstrained group is one that is not in the constrained group set
    let unConstrainedGroups =  grps |> List.filter (fun grp -> constrainedGroupSet |> (Set.contains grp.GName) |> not)

    // the dependency tree is represented a Map<string, string list> where the strings are group names
    // the key is group that depends on the list of groups in the map value
    let dependencyTree = constraints |> List.fold buildDependencyTree Map.empty

    let dependencies = 
        [   for root in roots do
            yield! listifyDependencyTree root dependencyTree ]
        |> List.rev // otherwise the dependencies would appear after the groups depending on them
        |> List.distinct // only the first instance of a group name is required, there will be more than one if more than one group dependency tree refers to the same group

    // make a map of group name to Group objects
    let grpNameToGrpMap = 
            grps 
            |> List.map (fun grpGen -> grpGen.GName, grpGen) 
            |> Map.ofList

    // re-order the grps list to be in dependency order
    let constrainedGroupsInDepOrder = dependencies |> List.map (fun grpName -> grpNameToGrpMap.[grpName])
    
    constrainedGroupsInDepOrder @ unConstrainedGroups

