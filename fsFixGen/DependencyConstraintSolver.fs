[<RequireQualifiedAccess>]
module DependencyConstraintSolver


open FIXGenTypes


// compoundItems must be flattened by this stage, don't recurse into the compoundItem trees
let private makeConstraints (componentNameMap:Map<ComponentName,Component>) (compoundItems:CompoundItem list) = 
    [   for itm in compoundItems do
        let subItms = itm |> CompoundItemFuncs.getSubCompoundItems componentNameMap
        for subItm in subItms do
        let itemName = CompoundItemFuncs.getName itm
        let subItemName = CompoundItemFuncs.getName subItm
        yield (itemName, subItemName) ]



let private buildDependencyTree (mapIn:Map<string, string list>) (grp,depGrp) = 
    if mapIn.ContainsKey grp then
        let curDeps = mapIn.[grp]
        let newDeps = depGrp::curDeps
        mapIn.Add (grp, newDeps)
    else
        mapIn.Add (grp, [depGrp])



// Turns a dependency tree into a string list (the strings are either group or component names)
// Dependents are after dependees (real word?), the results of this need to be reversed when generating
// compound items F# code
let private listifyDependencyTree (compoundItemName:string) (mapIn:Map<string, string list>) =
    let rec listifyDependencyTreeInner (grp:string) (mapIn:Map<string, string list>) =
        let getVals (gn:string) (mp:Map<string, string list>) = if mp.ContainsKey gn then mp.[gn] else []
        [   for depGrp in getVals grp mapIn do
            yield depGrp
            yield! listifyDependencyTreeInner depGrp mapIn ]
    compoundItemName::listifyDependencyTreeInner compoundItemName mapIn



//    missing NoSettlPartyIDs
//    missing NoSettlPartySubIDs
//    missing NoUnderlyingStips
//    <component name="UnderlyingStipulations">
//      <group name="NoUnderlyingStips" required="N">
//        <field name="UnderlyingStipType" required="N" />
//        <field name="UnderlyingStipValue" required="N" />
//      </group>
//    </component>    
//
//    dependencies |> List.iter (fun depName -> 
//                        if not (nameToItemMap.ContainsKey depName) then
//                            printfn "missing %s" depName
//        )
//
//
//    dependencies |> List.iter (fun depName -> 
//                        if (nameToItemMap.ContainsKey depName) then
//                            printfn "not missing %s" depName
//        )

// nested components (will be component references in my type model)
//    </component>
//    <component name="PositionQty">
//        <component name="NestedParties" required="N" />
//    </component>
//    <component name="PositionAmountData">
//    </component>
//    <component name="TrdRegTimestamps">
//    </component>
//    <component name="SettlInstructionsData">
//        <component name="SettlParties" required="N" />
//    </component>


// returns a list of all groups, with groups that are depended upon earlier in the list than groups that depend on them.   
let ConstrainGroupDependencyOrder (componentNameMap:Map<ComponentName,Component>) (compoundItems:CompoundItem list) = 
    let constraints = makeConstraints componentNameMap compoundItems

    // a group name is a root if it is not referred to as a dependency
    let dependencies = constraints |> List.map snd |> Set.ofList
    let roots = constraints |> List.map fst |> List.filter (dependencies.Contains >> not) |> List.distinct

    // a constrained item is referred to in a constraint either as a dependency or a dependent
    let constrainedSet = (constraints |> List.map fst) @ (constraints |> List.map snd) |> Set.ofList

    // an unconstrained group is one that is not in the constrained group set
    let unConstrained =  compoundItems 
                            |> List.filter (fun ci ->   let name = CompoundItemFuncs.getName ci
                                                        constrainedSet |> (Set.contains name) |> not)

    // the dependency tree is represented a Map<string, string list> where the strings are group names
    // the key is group that depends on the list of groups in the map value
    let dependencyTree = constraints |> List.fold buildDependencyTree Map.empty

    let dependencies = 
        [   for root in roots do
            yield! listifyDependencyTree root dependencyTree ]
        |> List.rev // otherwise the dependencies would appear after the groups depending on them
        |> List.distinct // only the first instance of a group name is required, there will be more than one if more than one group dependency tree refers to the same group

    // make a map of item name to item
    let nameToItemMap = 
            compoundItems 
            |> List.map (fun ci -> (CompoundItemFuncs.getName ci), ci)
            |> Map.ofList


    // re-order the grps list to be in dependency order
    let constrainedItemsInDepOrder = dependencies |> List.map (fun itemName -> nameToItemMap.[itemName])

    constrainedItemsInDepOrder @ unConstrained

    