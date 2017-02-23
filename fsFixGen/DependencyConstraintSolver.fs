(*
 * Copyright (C) 2016-2017 Ian Spratt <ian144@hotmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301, USA.
 *
 *)
 

[<RequireQualifiedAccess>]
module DependencyConstraintSolver


open FIXGenTypes


// compoundItems must be flattened by this stage, so there is no need to recurse into the compoundItem trees
let private makeConstraints (componentNameMap:Map<ComponentName,Component>) (compoundItems:CompoundItem list) = 
    [   for itm in compoundItems do
        let subItms = itm |> CompoundItem.getSubCompoundItems componentNameMap
        for subItm in subItms do
        let itemName = CompoundItem.getName itm
        let subItemName = CompoundItem.getName subItm
        yield (itemName, subItemName) ]



let private buildDependencyTree (mapIn:Map<string, string list>) (grp,depGrp) = 
    if mapIn.ContainsKey grp then
        let curDeps = mapIn.[grp]
        let newDeps = depGrp::curDeps
        mapIn.Add (grp, newDeps)
    else
        mapIn.Add (grp, [depGrp])



// Turns a dependency tree into a string list, the strings are either group or component names.
// Dependencies are after dependees (a real word?), so the results of this func need to be reversed when generating
// compound item F# definitions, or there will be definition order related compile errors.
let private traverseDependencyTreeBottomFirst (compoundItemName:string) (mapIn:Map<string, string list>) =
    let rec listifyDependencyTreeInner (grp:string) (mapIn:Map<string, string list>) =
        let getVals (gn:string) (mp:Map<string, string list>) = if mp.ContainsKey gn then mp.[gn] else []
        [   for depGrp in getVals grp mapIn do
            yield depGrp
            yield! listifyDependencyTreeInner depGrp mapIn ]
    compoundItemName::listifyDependencyTreeInner compoundItemName mapIn




// returns a list of all compoundItems, with items that are depended upon earlier in the list than items that depend on them.   
let ConstrainGroupDependencyOrder (componentNameMap:Map<ComponentName,Component>) (compoundItems:CompoundItem list) = 
    let compoundItems = compoundItems |> List.distinct
    let constraints = makeConstraints componentNameMap compoundItems

    // a group name is a root if it is not referred to as a dependency
    let dependencies = constraints |> List.map snd |> Set.ofList
    let roots = constraints |> List.map fst |> List.filter (dependencies.Contains >> not) |> List.distinct

    // a constrained item is referred to in a constraint either as a dependency or a dependent
    let constrainedSet = (constraints |> List.map fst) @ (constraints |> List.map snd) |> Set.ofList

    // an unconstrained group is one that is not in the constrained group set
    let unConstrained =  compoundItems 
                            |> List.filter (fun ci ->   let name = CompoundItem.getName ci
                                                        constrainedSet |> (Set.contains name) |> not)

    // The dependency tree is represented a Map<string, string list> where the strings are group names
    // the key is group that depends on the list of groups in the map value.
    // The dependency tree is represented as a Map<string, string list>, where the string values are the names of groups or components.
    // Using the raw string type instead of single case DUs because there are already different single case DUs for component names (may create one for groups)
    let dependencyTree = constraints |> List.fold buildDependencyTree Map.empty

    let dependencies = 
        [ for root in roots do
              yield! traverseDependencyTreeBottomFirst root dependencyTree ]
        |> List.rev // otherwise the dependencies would appear after the groups depending on them
        |> List.distinct // only the first instance of a group name is required, there will be more than one if more than one group dependency tree refers to the same group

    // make a map of item name to item
    let nameToItemMap = 
            compoundItems 
            |> List.map (fun ci -> (CompoundItem.getName ci), ci)
            |> Map.ofList

    // re-order the grps list to be in dependency order
    let constrainedItemsInDepOrder = dependencies |> List.map (fun itemName -> nameToItemMap.[itemName])

    constrainedItemsInDepOrder @ unConstrained

    