[<RequireQualifiedAccess>]
module CompoundItemFuncs

open FIXGenTypes




let extractCompoundItems (componentNameMap:Map<ComponentName,Component>) (itms:FIXItem list) : CompoundItem list =
    let extract (itm:FIXItem) : CompoundItem option =
        match itm with 
        | FIXItem.Group     group   ->  Some (CompoundItem.Group group)
        | FIXItem.Component cmpRef  ->  let componentName = cmpRef.CRName 
                                        let comp = componentNameMap.[componentName] 
                                        Some (CompoundItem.Component comp)
        | FIXItem.Field _           ->  None
    let xx = itms |> List.choose extract
    xx



//let extractLevel1GroupsFromComponents (cmps:Component list) = 
//    [   for cmp in cmps do
//        yield! cmp.Items |> extractGroups ]
//
//    
//
//let extractLevel1GroupsFromMsgs (msg:Msg list) = 
//    [   for cmp in msg do
//        yield! cmp.Items |> extractGroups ]


let getSubCompoundItems (componentNameMap:Map<ComponentName,Component>) (ci:CompoundItem) : CompoundItem  list = 
    match ci with
    | CompoundItem.Component cmp    -> cmp.Items |> (extractCompoundItems componentNameMap)
    | CompoundItem.Group grp        -> grp.Items |> (extractCompoundItems componentNameMap)



let rec flattenCompoundItems (componentNameMap:Map<ComponentName,Component>) (compoundItems:CompoundItem list) : CompoundItem list  = 
    [   for ci in compoundItems do
        let subItems = getSubCompoundItems componentNameMap ci
        let subSubItems = flattenCompoundItems componentNameMap subItems
        yield! subSubItems
        yield! subItems
        yield ci ]


let getName (ci:CompoundItem) =
    match ci with
    | CompoundItem.Component cmp    -> cmp.CName.Value
    | CompoundItem.Group grp        -> grp.GName
    

let isGroup  (ci:CompoundItem) =
    match ci with
    | CompoundItem.Group grp        -> true
    | CompoundItem.Component cmp    -> false
