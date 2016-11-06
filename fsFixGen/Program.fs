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
    use swFieldReadFuncs = new StreamWriter (MkOutpath "Fix44.FieldReadFuncs.fs")
    use swFieldWriteFuncs = new StreamWriter (MkOutpath "Fix44.FieldWriteFuncs.fs")
    use swFieldDU = new StreamWriter (MkOutpath "Fix44.FieldDU.fs")
    
    printfn "reading and generating FIX field source"
    let fields = FieldGenerator.ParseFieldData xpthFields 
    let lenFieldNames, mergedFields = FieldGenerator.MergeLenFields fields
    FieldGenerator.Gen mergedFields swFixFields swFieldReadFuncs swFieldWriteFuncs  swFieldDU

    // make a map of field name to field definition
    // used to connect a field reference in a msg etc, with the field definition
    let fieldNameMap = fields 
                        |> List.map (fun fld -> fld.Name, fld )
                        |> Map.ofList


    printfn "read header"
    let xpthHrd = doc.XPathSelectElement "fix/header"
    let hdr = HeaderTrailerGenerator.ReadHeader lenFieldNames xpthHrd
    
    printfn "read trailer"
    let xpthTrl = doc.XPathSelectElement "fix/trailer"
    let trl = HeaderTrailerGenerator.ReadTrailer lenFieldNames xpthTrl

    printfn "reading components"
    let xpthMsgs = doc.XPathSelectElement "fix/components"
    let components = ComponentGenerator.Read xpthMsgs


    // make a map of component name to component.
    // used for marrying up componentRefs with components.
    let cmpNameMap = components 
                        |> List.map (fun cmp -> cmp.CName, cmp)
                        |> Map.ofList


    printfn "reading messages"
    let xpthMsgs = doc.XPathSelectElement "fix/messages"
    let msgs = MessageGenerator.Read xpthMsgs


    printfn "merging groups"
    let headerTrailerCompoundItems = CompoundItemFuncs.recursivelyGetAllCompoundItems cmpNameMap (hdr.HItems @ trl.TItems)
    let msgCompoundItems = 
        [   for msg in msgs do
            yield! CompoundItemFuncs.recursivelyGetAllCompoundItems cmpNameMap msg.Items    ]
    let allCompoundItems = headerTrailerCompoundItems @ msgCompoundItems
    let allGrps = CompoundItemFuncs.extractGroups allCompoundItems


    // a map of group long name (a compound name based on its parentage) to a merge target
    let groupMerges = GroupUtils.makeMergeMap allGrps
    
    groupMerges 
        |> List.sortBy (fun (ln,_) -> ln)
        |> List.iter (fun (GroupLongName ln,grp) -> printfn "    group merge: %s -> %s" ln grp.GName)
    
    let groupMergeMap = groupMerges |> Map.ofList

    printfn "updating components to use merged groups"  
    let componentsAfterGroupMerge = 
            [   for comp in components do
                let items2 = comp.Items // FIXItems are trees, groups can contain components and other groups
                                |> FIXItem.map (FIXItem.updateItemIfMergeableGroup groupMergeMap) 
                                |> FIXItem.filter (FIXItem.excludeFieldsFilter lenFieldNames)
                yield {comp with Items = items2}    ]

    let cmpNameMapAfterGroupMerge = componentsAfterGroupMerge 
                                        |> List.map (fun cmp -> cmp.CName, cmp)
                                        |> Map.ofList

    
    printfn "updating header and trailer to use merged groups"  // there is only one group in the header, none in the trailer. 
    let hdrItemsAfterGroupMerge = hdr.HItems |> FIXItem.map (FIXItem.updateItemIfMergeableGroup groupMergeMap)
    let hdrAfterGroupMerge = {hdr with HItems = hdrItemsAfterGroupMerge}
    printfn "generating header and trailer F# types"
    use swHdrTrlr = new StreamWriter (MkOutpath "Fix44.HeaderTrailer.fs")
    HeaderTrailerGenerator.genHeader swHdrTrlr hdrAfterGroupMerge trl

    printfn "updating messages to use merged groups"  
    let msgsAfterGroupMerge =
            [   for msg in msgs do
                let items2 =  msg.Items 
                                |> FIXItem.map (FIXItem.updateItemIfMergeableGroup groupMergeMap)
                                |> FIXItem.filter (FIXItem.excludeFieldsFilter lenFieldNames)
                yield {msg with Items = items2}   ]


    printfn "determining dependency order for groups and components"
    let msgCompoundItemsAfterGroupMerge = 
        [   for msg in msgsAfterGroupMerge do
            yield! CompoundItemFuncs.recursivelyGetAllCompoundItems cmpNameMapAfterGroupMerge msg.Items    ]
        |> List.distinct 
    
    let hdrCompoundItemsAfterGroupMerge = hdrAfterGroupMerge.HItems |> CompoundItemFuncs.recursivelyGetAllCompoundItems cmpNameMapAfterGroupMerge
    let allCompoundItemsAfterGroupMerge = msgCompoundItemsAfterGroupMerge @ hdrCompoundItemsAfterGroupMerge

    // extract the components and groups refered to in messages
    // these will in-turn contain nested components and groups (NOPE, ComponentRefs in msgs do not contain nested components
    // group definitions are nested, component definitions are not (components are defined in their own xml element, groups are defined in messages and components)
    let constrainedCompoundItemsInDepOrder  = allCompoundItemsAfterGroupMerge
                                                |> List.distinct
                                                |> (DependencyConstraintSolver.ConstrainGroupDependencyOrder cmpNameMapAfterGroupMerge)

    printfn "calculating group and component dependency order"
    constrainedCompoundItemsInDepOrder
        |> List.map CompoundItemFuncs.getNameAndTypeStr
        |> List.iter (printfn "    %s")

    printfn "generating group and component writing functions in dependency order"
    use swCompoundItems = new StreamWriter (MkOutpath "Fix44.CompoundItems.fs")
    use swCompoundItemDU = new StreamWriter (MkOutpath "Fix44.CompoundItemDU.fs")
    CompoundItemGenerator.Gen cmpNameMapAfterGroupMerge constrainedCompoundItemsInDepOrder swCompoundItems swCompoundItemDU
    use swGroupWriteFuncs = new StreamWriter (MkOutpath "Fix44.CompoundItemWriteFuncs.fs")
    do CompoundItemGenerator.GenWriteFuncs constrainedCompoundItemsInDepOrder swGroupWriteFuncs
        // make a map of field name to field definition
    // used to connect a field reference in a msg etc, with the field definition
    printfn "generating group and component reading functions in dependency order"
    use swGroupReadFuncs = new StreamWriter (MkOutpath "Fix44.CompoundItemReadFuncs.fs")
    do CompoundItemGenerator.GenReadFuncs fieldNameMap constrainedCompoundItemsInDepOrder swGroupReadFuncs


    printfn "generating message F# types"
    use swMsgs = new StreamWriter (MkOutpath "Fix44.Messages.fs")
    MessageGenerator.Gen msgsAfterGroupMerge swMsgs


    printfn "generating message writer funcs"
    use swMsgFuncs = new StreamWriter (MkOutpath "Fix44.MsgWriteFuncs.fs")
    MessageGenerator.GenWriteFuncs hdrItemsAfterGroupMerge msgsAfterGroupMerge swMsgFuncs

    0 // exit code
