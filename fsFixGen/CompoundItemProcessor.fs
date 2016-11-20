module CompoundItemProcessor

open System.IO

open FIXGenTypes


/// extract groups from messages, components and the header
/// merge identical groups
/// apply the merges to messages, components and the header
/// apply rules to groups
///    ensure groups first item is always required
///    ensure components that are the first item of a group have a first item that is required
/// sort the groups and components so that dependents appear before dependee's, so that when they are all written to a source file 
let Process (hdr:Header) (trl:Trailer) (components:Component list) (msgs:Msg list) (lenFieldNames:Set<string>) = 

    let cmpNameMap = components |> List.map (fun cmp -> cmp.CName, cmp) |> Map.ofList

    printfn "collate all groups"
    let headerTrailerCompoundItems = CompoundItemFuncs.recursivelyGetAllCompoundItems cmpNameMap (hdr.HItems @ trl.TItems)
    let msgCompoundItems = 
        [   for msg in msgs do
            yield! CompoundItemFuncs.recursivelyGetAllCompoundItems cmpNameMap msg.Items    ]
    let allCompoundItems = headerTrailerCompoundItems @ msgCompoundItems
    let allGrps = CompoundItemFuncs.extractGroups allCompoundItems

    printfn "merge groups where possible"
    let groupMerges = GroupUtils.makeMergeMap allGrps     // a map of group long name (a compound name based on its parentage) to a merge target
    
    printfn "groups merges found"
    groupMerges |> List.sortBy (fun (ln,_) -> ln) |> List.iter (fun (GroupLongName ln,grp) -> printfn "    group merge: %s -> %s" ln grp.GName)
    
    let groupMergeMap = groupMerges |> Map.ofList

    printfn "updating components to use merged groups"  
    let componentsAfterGroupMerge = 
            [   for comp in components do
                let items2 = comp.Items // FIXItems are trees, groups can contain components and other groups
                                |> FIXItem.map (FIXItem.updateItemIfMergeableGroup groupMergeMap) 
                                |> FIXItem.filter (FIXItem.excludeFieldsFilter lenFieldNames)
                yield {comp with Items = items2}    ]

    let cmpNameMapAfterGroupMerge = componentsAfterGroupMerge |> List.map (fun cmp -> cmp.CName, cmp) |> Map.ofList
    
    printfn "updating header and trailer to use merged groups"  // there is only one group in the header, none in the trailer. 
    let hdrItemsAfterGroupMerge = hdr.HItems |> FIXItem.map (FIXItem.updateItemIfMergeableGroup groupMergeMap)
    let hdrAfterGroupMerge = {hdr with HItems = hdrItemsAfterGroupMerge}
    
    printfn "generating header and trailer F# types"
    use swHdrTrlr = new StreamWriter (Utils.MkOutpath "Fix44.HeaderTrailer.fs")
    HeaderTrailerGenerator.genHeader swHdrTrlr hdrAfterGroupMerge trl

    printfn "updating messages to use merged groups"  
    let msgsAfterGroupMerge =
            [   for msg in msgs do
                let items2 =  msg.Items 
                                |> FIXItem.map (FIXItem.updateItemIfMergeableGroup groupMergeMap)
                                |> FIXItem.filter (FIXItem.excludeFieldsFilter lenFieldNames)
                yield {msg with Items = items2}   ]

    let msgCompoundItemsAfterGroupMerge = 
        [   for msg in msgsAfterGroupMerge do
            yield! CompoundItemFuncs.recursivelyGetAllCompoundItems cmpNameMapAfterGroupMerge msg.Items    ]
        |> List.distinct 
    
    let hdrCompoundItemsAfterGroupMerge = hdrAfterGroupMerge.HItems |> CompoundItemFuncs.recursivelyGetAllCompoundItems cmpNameMapAfterGroupMerge
    
    let allCompItems2 = msgCompoundItemsAfterGroupMerge @ hdrCompoundItemsAfterGroupMerge

    printfn "GROUP RULE: ensure groups first item is always required"    
    let allCompItems3 = allCompItems2 |> List.collect CompoundItemRules.ensureGroupFirstItemIsRequired
    
    printfn "GROUP RULE: ensure components that are the first item of a group have a first item that is required"
    let allCompItems4 = allCompItems3 |> List.collect (CompoundItemRules.ensureIfGroupFirstItemIsComponentThenComponentFirstItemIsRequired cmpNameMapAfterGroupMerge)


    let mapX = allCompItems4 |> CompoundItemFuncs.extractComponents |> List.map (fun cmp -> cmp.CName, cmp) |> Map.ofList


    printfn "COMPONENT RULE: if an optional component contains just a single optional group then replace the component with the group"
    let allCompItems5 = allCompItems4 |> List.map (CompoundItemRules.elideComponentsContainingASingleOptionalGroup mapX)


    let allCompItemsProcessed = allCompItems5

    let cmpNameMapAfterGroupRulesApplied = allCompItemsProcessed
                                        |> CompoundItemFuncs.extractComponents 
                                        |> List.map (fun cmp -> cmp.CName, cmp)
                                        |> Map.ofList

    printfn "calculating group and component dependency order"
    let constrainedCompoundItemsInDepOrder  = allCompItemsProcessed
                                                |> List.distinct
                                                |> (DependencyConstraintSolver.ConstrainGroupDependencyOrder cmpNameMapAfterGroupRulesApplied)
    
    printfn "groups and components in dependency order"    
    constrainedCompoundItemsInDepOrder
        |> List.map CompoundItemFuncs.getNameAndTypeStr
        |> List.iter (printfn "    %s")

    hdrItemsAfterGroupMerge, constrainedCompoundItemsInDepOrder, msgsAfterGroupMerge, cmpNameMapAfterGroupRulesApplied
