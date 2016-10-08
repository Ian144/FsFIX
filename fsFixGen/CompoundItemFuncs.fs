[<RequireQualifiedAccess>]
module CompoundItemFuncs

open FIXGenTypes




let private extractCompoundItems (componentNameMap:Map<ComponentName,Component>) (itms:FIXItem list) : CompoundItem list =
    let extract (itm:FIXItem) : CompoundItem option =
        match itm with 
        | FIXItem.Group     group   ->  Some (CompoundItem.Group group)
        | FIXItem.Component cmpRef  ->  let componentName = cmpRef.CRName 
                                        let comp = componentNameMap.[componentName] 
                                        Some (CompoundItem.Component comp)
        | FIXItem.Field _           ->  None
    itms |> List.choose extract 


let getSubCompoundItems (componentNameMap:Map<ComponentName,Component>) (ci:CompoundItem) : CompoundItem list = 
    match ci with
    | CompoundItem.Component cmp    -> cmp.Items |> (extractCompoundItems componentNameMap)
    | CompoundItem.Group grp        -> grp.Items |> (extractCompoundItems componentNameMap)


let rec private flattenCompoundItems (componentNameMap:Map<ComponentName,Component>) (compoundItems:CompoundItem list) : CompoundItem list  = 
    [   for ci in compoundItems do
        let subItems = getSubCompoundItems componentNameMap ci
        let subSubItems = flattenCompoundItems componentNameMap subItems
        yield! subSubItems
        yield! subItems
        yield ci ]


// compound items are either groups or components, both of which may contain nested components and groups (nested to an arbitrary degree) 
let recursivelyGetAllCompoundItems (componentNameMap:Map<ComponentName,Component>) (itms:FIXItem list) : CompoundItem list =
    let level0CompoundItems = extractCompoundItems componentNameMap itms
    flattenCompoundItems componentNameMap level0CompoundItems |> List.distinct


let getName (ci:CompoundItem) =
    match ci with
    | CompoundItem.Component cmp    -> cmp.CName.Value
    | CompoundItem.Group grp        -> grp.GName
    

let extractGroups (cis:CompoundItem list) : Group list =
    let extractGroup ci =
        match ci with
        | CompoundItem.Group grp    -> Some grp
        | CompoundItem.Component _  -> None
    cis |> List.choose extractGroup



