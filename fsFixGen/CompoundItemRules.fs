[<RequireQualifiedAccess>]
module CompoundItemRules


open FIXGenTypes


 

let private setRequired (fi:FIXItem)  =
    match fi with
    | FIXItem.FieldRef fld      ->  FIXItem.FieldRef { fld with Required = Required }
    | FIXItem.ComponentRef cr   ->  FIXItem.ComponentRef { cr with Required = Required }
    | FIXItem.Group grp         ->  failwith "subgroup needs to be set to required" // not sure if this can happen, so intentionally failing if it does, might not be an error though 
                                    FIXItem.Group { grp with Required = Required }


let ensureGroupFirstItemIsRequired (cmpItem:CompoundItem) : CompoundItem list =
    match cmpItem with 
    | Component _   ->  [cmpItem]
    | Group gg      ->  let firstItem = gg.Items.Head
                        match FIXItem.getIsRequired firstItem with
                        | true  ->  [cmpItem]
                        | false ->  let hd = gg.Items.Head
                                    let tl = gg.Items.Tail
                                    let hd2 = setRequired hd
                                    let items2 = hd2 :: tl
                                    [{ gg with Items = items2} |> CompoundItem.Group]
                                    
