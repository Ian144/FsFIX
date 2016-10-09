[<RequireQualifiedAccess>]
module FIXItem

open FIXGenTypes


let rec map (funcx:FIXItem -> FIXItem) (xs:FIXItem list) : FIXItem list =
    [   for x in xs do
        let x2 = funcx x
        match x2 with
        | FIXItem.Field _           ->  yield x2
        | FIXItem.Component _cmp    ->  yield x2
        | FIXItem.Group grp         ->  let subItems = map funcx grp.Items
                                        yield FIXItem.Group {grp with Items = subItems} ]       
    

let rec filter (predicate:FIXItem -> bool) (xs:FIXItem list) : FIXItem list =
    let xs2 = xs |> List.filter predicate
    [   for x2 in xs2 do
        match x2 with
        | FIXItem.Field _       ->  yield x2
        | FIXItem.Component _   ->  yield x2
        | FIXItem.Group grp     ->  let subItems = filter predicate grp.Items
                                    yield FIXItem.Group {grp with Items = subItems} ] 



let updateItemIfMergeableGroup (grpMergeMap:Map<GroupLongName,Group>) (item:FIXItem) =
    match item with
    | FIXItem.Group grp     ->  let longName = GroupUtils.makeLongName grp
                                if grpMergeMap.ContainsKey longName then
                                    let grp = {grpMergeMap.[longName] with Required = grp.Required} 
                                    FIXItem.Group grp
                                else
                                    item
    | FIXItem.Component _   ->  item
    | FIXItem.Field _       ->  item



let excludeFieldsFilter (excludeFieldNames:Set<string>) (item:FIXItem) =
    match item with
    | FIXItem.Group _       ->  true
    | FIXItem.Component _   ->  true
    | FIXItem.Field fld     ->  Set.contains fld.FName excludeFieldNames |> not

