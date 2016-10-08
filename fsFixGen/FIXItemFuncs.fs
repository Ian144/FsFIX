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
        | FIXItem.Field _           ->  yield x2
        | FIXItem.Component _cmp    ->  yield x2
        | FIXItem.Group grp         ->  let subItems = filter predicate grp.Items
                                        yield FIXItem.Group {grp with Items = subItems} ] 