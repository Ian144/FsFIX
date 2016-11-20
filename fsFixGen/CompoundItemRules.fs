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


let private makeComponentWithFirstItemRequired (cmp:Component) : Component = 
    let hd = cmp.Items.Head
    let tl = cmp.Items.Tail
    let hd2 = setRequired hd
    let (ComponentName name) = cmp.CName
    let name2 = sprintf "%sFG" name |> ComponentName
    {CName = name2; Items = hd2::tl}


let private isFirstItemRequired (cmp:Component) : bool = 
    cmp.Items.Head |> FIXItem.getIsRequired


// if neccessary this will create a new component with a first item that is required
// the name of the new component will be that of the original component suffixed with FG
// a new group will reference the ...FG component
// the orginal component will be left unaffected
let ensureIfGroupFirstItemIsComponentThenComponentFirstItemIsRequired (cmpNameMap:Map<ComponentName,Component>) (cmpItem:CompoundItem) : CompoundItem list =
    match cmpItem with 
    | Component _   ->  [cmpItem]
    | Group gg      ->  let firstItem = gg.Items.Head
                        match firstItem with
                        | FIXItem.FieldRef _        ->  [cmpItem]
                        | FIXItem.Group   _         ->  [cmpItem]
                        | FIXItem.ComponentRef cr   ->  let cmp = cmpNameMap.[cr.CRName]
                                                        let firstItemRequired =  cmp.Items.Head |> FIXItem.getIsRequired
                                                        match firstItemRequired with
                                                        | true  -> [cmpItem]
                                                        | false -> 
                                                            let cmp2 = makeComponentWithFirstItemRequired cmp 
                                                            let cr2 = {CRName = cmp2.CName; Required = Required.Required} |> FIXItem.ComponentRef
                                                            let cmp2Ci = cmp2 |> CompoundItem.Component
                                                            let items2 = cr2 :: gg.Items.Tail
                                                            let gg2 = {gg with Items = items2} |> CompoundItem.Group
                                                            [cmp2Ci; gg2]



let elideOptionalComponentsContainingASingleOptionalGroupInner (cmpNameMap:Map<ComponentName,Component>) (fi:FIXItem) : FIXItem =
    match fi with
    | FIXItem.FieldRef _        ->  fi
    | FIXItem.Group   _         ->  fi
    | FIXItem.ComponentRef cr   ->  let cmp = cmpNameMap.[cr.CRName]
                                    let xs = cmp.Items
                                    match xs.Length with
                                    | 1 ->  match FIXItem.isGroup xs.Head, FIXItem.getIsRequired fi, FIXItem.getIsRequired xs.Head with
                                            | true, false, false    -> xs.Head
                                            | _                     -> fi
                                    | _ ->  fi



let elideComponentsContainingASingleOptionalGroup (cmpNameMap:Map<ComponentName,Component>) (cmpItem:CompoundItem) : CompoundItem =
    match cmpItem with 
    | Component cmp ->  let items2 = cmp.Items |> List.map (elideOptionalComponentsContainingASingleOptionalGroupInner cmpNameMap)
                        Component {cmp with Items = items2}
    | Group gg      ->  let items2 = gg.Items |> List.map (elideOptionalComponentsContainingASingleOptionalGroupInner cmpNameMap)
                        Group {gg with Items = items2}

