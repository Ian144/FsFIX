open System


open System.Xml.Linq
open System.Xml.XPath
open System.IO

open FIXGenTypes
open FieldGenerator






let fixSpecXmlFile = """C:\Users\Ian\Documents\GitHub\quickfixn\spec\fix\FIX44.xml"""


let MkOutpath flName = 
    sprintf """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\%s""" flName





[<EntryPoint>]
let main _ = 

    let fixXml = IO.File.ReadAllText(fixSpecXmlFile)
    let doc = XDocument.Parse fixXml

    let xpthFields = doc.XPathSelectElement "fix/fields"
    use swFixFields = new StreamWriter (MkOutpath "Fix44.Fields.fs")
    use swFieldReadWriteFuncs = new StreamWriter (MkOutpath "Fix44.FieldReadWriteFuncs.fs")
    
    printfn "reading and generating FIX field source"
    let fieldData = FieldGenerator.ParseFieldData2 xpthFields 
    let lenFieldNames, mergedFields = FieldGenerator.MergeLenFields fieldData
    FieldGenerator.Gen mergedFields swFixFields swFieldReadWriteFuncs

    printfn "reading components"
    let xpthMsgs = doc.XPathSelectElement "fix/components"
    let components = ComponentGenerator.Read xpthMsgs

    // make a map of component name to component
    // used for marrying up component refs with components
    let cmpNameMap = components 
                        |> List.map (fun cmp -> cmp.CName, cmp)
                        |> Map.ofList

    printfn "reading messages"
    let xpthMsgs = doc.XPathSelectElement "fix/messages"
    let msgs = MessageGenerator.Read xpthMsgs

    // all groups and components, nested to any degree

    printfn "merging groups"

    let allCompoundItems = 
        [   for msg in msgs do
            yield! CompoundItemFuncs.recursivelyGetAllCompoundItems cmpNameMap msg.Items    ]
    
    let allGrps = CompoundItemFuncs.extractGroups allCompoundItems

    // a map of group longname (a compound name based on its parentage) to a merge target
    let groupMerges = GroupUtils.makeMergeMap allGrps
    
    groupMerges 
        |> List.sortBy (fun (_,grp) -> grp.GName)
        |> List.iter (fun (ln,grp) -> printfn "group merge: %A -> %A" ln grp.GName)

    
    let groupMergeMap = groupMerges |> Map.ofList
    

    printfn "applying group merge"
    // will the groups refered to by level0 groups still point to the old groups
    let groupsAfterMerge =
        [   for oldGrp in allGrps do
            let longName = GroupUtils.makeLongName oldGrp
            if groupMergeMap.ContainsKey longName then
                yield groupMergeMap.[longName] 
            else
                yield oldGrp
            ] |> List.distinct // 'distinct' so there is only one instance of each merge group

    printfn "updating components to use merged groups"  
    let componentsAfterGroupMerge = 
            [   for comp in components do
                let items2 = 
                    [   for itm in comp.Items do
                        let itm2 = GroupUtils.updateItemIfMergeableGroup groupMergeMap itm
                        if GroupUtils.excludeFieldsFilter lenFieldNames itm2 then
                            yield itm2  ]
                yield {comp with Items = items2}    ]

    let cmpNameMapAfterGroupMerge = componentsAfterGroupMerge 
                                        |> List.map (fun cmp -> cmp.CName, cmp)
                                        |> Map.ofList

    printfn "updating messages to use merged groups"  
    printfn "\t\t\t\tERROR: application of the group merge to msgs should be done recursively"    
    printfn "\t\t\t\tERROR: application of the group merge to msgs should be done recursively"    
    printfn "\t\t\t\tERROR: application of the group merge to msgs should be done recursively"    
    printfn "\t\t\t\tERROR: application of the group merge to msgs should be done recursively"    

    let msgsAfterGroupMerge =
            [   for msg in msgs do
                let items2 = 
                    [   for itm in msg.Items do
                         // this does not recurse into nested groups
                        let itm2 = GroupUtils.updateItemIfMergeableGroup groupMergeMap itm
                        if GroupUtils.excludeFieldsFilter lenFieldNames itm2 then
                            yield itm2  ]
                yield {msg with Items = items2}   ]


    let allCompoundItemsAfterGroupMerge = 
        [   for msg in msgsAfterGroupMerge do
            yield! CompoundItemFuncs.recursivelyGetAllCompoundItems cmpNameMapAfterGroupMerge msg.Items    ]



    //#### generate combined component+group definitions

    // extract the components and groups refered to in messages
    // these will in-turn contain nested components and groups (NOPE, ComponentRefs in msgs do not contain nested components
    // group definitions are nested, component definitions are not (components are defined in their own xml element, groups are defined in messages and components)
    let constrainedCompoundItemsInDepOrder  = allCompoundItemsAfterGroupMerge
                                                |> (DependencyConstraintSolver.ConstrainGroupDependencyOrder cmpNameMapAfterGroupMerge)


//    // get the compound items from the messages
//    // flatten the compound items
//    // get compound items in dependency order
//    // must write compound items in same source file, as some components will depend on groups and visa versa
//
//
//
//
//
//
//
////    let depOrderGroups = GroupGenerator.GetGroupsInDependencyOrder allGrps
//
////    printfn "generating group source"
//    use swGroups = new StreamWriter (MkOutpath "Fix44.CompoundItems.fs")
//    use swGroupWriteFuncs = new StreamWriter (MkOutpath "Fix44.GroupWriteFuncs.fs")
////    use swGroupFactoryFuncs = new StreamWriter (MkOutpath "Fix44.GroupFactoryFuncs.fs")
//    CompoundItemGenerator.Gen constrainedCompoundItemsInDepOrder swGroups swGroupWriteFuncs

//    GroupGenerator.GenFactoryFuncs depOrderGroups swGroupFactoryFuncs


    0 // return an integer exit code
