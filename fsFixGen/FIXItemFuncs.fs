[<RequireQualifiedAccess>]
module FIXItem

open FIXGenTypes

// FIXItems are trees
let rec map (funcx:FIXItem -> FIXItem) (xs:FIXItem list) : FIXItem list =
    [   for x in xs do
        let x2 = funcx x
        match x2 with
        | FIXItem.FieldRef _        ->  yield x2
        | FIXItem.ComponentRef _    ->  yield x2
        | FIXItem.Group grp         ->  let subItems = map funcx grp.Items
                                        yield FIXItem.Group {grp with Items = subItems} ]       
    

let rec filter (predicate:FIXItem -> bool) (xs:FIXItem list) : FIXItem list =
    let xs2 = xs |> List.filter predicate
    [   for x2 in xs2 do
        match x2 with
        | FIXItem.FieldRef _        ->  yield x2
        | FIXItem.ComponentRef _    ->  yield x2
        | FIXItem.Group grp         ->  let subItems = filter predicate grp.Items
                                        yield FIXItem.Group {grp with Items = subItems} ] 



let updateItemIfMergeableGroup (grpMergeMap:Map<GroupLongName,Group>) (item:FIXItem) =
    match item with
    | FIXItem.Group grp         ->  let longName = GroupUtils.makeLongName grp
                                    if grpMergeMap.ContainsKey longName then
                                        let grp = {grpMergeMap.[longName] with Required = grp.Required} 
                                        FIXItem.Group grp
                                    else
                                        item
    | FIXItem.ComponentRef _    ->  item
    | FIXItem.FieldRef _        ->  item


     
let excludeFieldsFilter (excludeFieldNames:Set<string>) (item:FIXItem) =
    match item with
    | FIXItem.Group _           ->  true
    | FIXItem.ComponentRef _    ->  true
    | FIXItem.FieldRef fld      ->  Set.contains fld.FName excludeFieldNames |> not



let getName (fi:FIXItem) =
    match fi with
    | FIXItem.FieldRef fld      ->  fld.FName
    | FIXItem.ComponentRef cmp  ->  let (ComponentName nm) = cmp.CRName
                                    nm
    | FIXItem.Group grp         ->  grp.GName


let getNameLN (fi:FIXItem) =
    match fi with
    | FIXItem.FieldRef fld      ->  fld.FName
    | FIXItem.ComponentRef cmp  ->  let (ComponentName nm) = cmp.CRName
                                    nm
    | FIXItem.Group grp         ->  let (GroupLongName nm) = GroupUtils.makeLongName grp
                                    sprintf "%sGrp" nm

let getIsRequired (fi:FIXItem) =
    match fi with
    | FIXItem.FieldRef fld      ->  fld.Required = Required.Required
    | FIXItem.ComponentRef cmp  ->  cmp.Required = Required.Required
    | FIXItem.Group grp         ->  grp.Required = Required.Required



let rec getTag (fieldNameMap:Map<string,Field>) (compNameMap:Map<ComponentName,Component>) (fi:FIXItem) = 
    match fi with
    | FIXItem.FieldRef fldRef   ->  
        let fld = fieldNameMap.[fldRef.FName]
        match fld with
        | SimpleField sf -> sf.Tag
        | CompoundField cf -> cf.LenField.Tag
    | FIXItem.ComponentRef cr   ->  
        let cmp = compNameMap.[cr.CRName]
        let firstItem = cmp.Items.Head // program is in an errored state if this fails, hence failing fast
        getTag fieldNameMap compNameMap firstItem
    | FIXItem.Group grp ->
        // the groups short name is that of the 'NoGROUPNAME' field, which holds the number of group elements
        let numFld = fieldNameMap.[grp.GName]
        match numFld with
        | SimpleField sf -> sf.Tag
        | CompoundField cf -> failwith "invalid field type for group number field"























