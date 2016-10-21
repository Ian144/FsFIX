module CommonGenerator

open System.IO

open FIXGenTypes



// used for building the FIXItem definition string for messages, groups and components
let private makeItemStr (item:FIXItem) = 
    match item with
    | FIXItem.Field fld     ->      match fld.Required with
                                    | Required.Required     ->  sprintf "    %s: %s" fld.FName fld.FName
                                    | Required.NotRequired  ->  sprintf "    %s: %s option" fld.FName fld.FName
    | FIXItem.ComponentRef cmp ->   let (ComponentName nm) = cmp.CRName
                                    match cmp.Required with
                                    | Required.Required     ->  sprintf "    %s: %s // component" nm nm 
                                    | Required.NotRequired  ->  sprintf "    %s: %s option // component" nm nm
    | FIXItem.Group grp     ->      let (GroupLongName grpNameInner) = GroupUtils.makeLongName grp
                                    let isSidesGroup = grp.GName = "NoSides"
                                    match isSidesGroup, grp.Required with
                                    | false, Required.Required     ->  sprintf "    %sGrp: %sGrp list // group" grpNameInner grpNameInner
                                    | false, Required.NotRequired  ->  sprintf "    %sGrp: %sGrp list option // group" grpNameInner grpNameInner
                                    | true,  Required.Required     ->  sprintf "    %sGrp: %sGrp OneOrTwo // group" grpNameInner grpNameInner
                                    | true,  Required.NotRequired  ->  sprintf "    %sGrp: %sGrp OneOrTwo option // group" grpNameInner grpNameInner
    


let writeFIXItemList (sw : StreamWriter) (items : FIXItem list) = 
    items
    |> List.map makeItemStr
    |> List.iter sw.WriteLine



let private getGroupContainerType (grp:Group) = 
    if grp.GName.Contains "NoSides" then
        "OneOrTwo.iter"
    else
        "List.iter" // todo, consider changing the default group container type to array for better cache locality


// writes both sub-groups embedded in groups and groups embedded in msgs
let private genWriteGroup (parent:string) (grp:Group) = 
    let (GroupLongName longName) = GroupUtils.makeLongName grp
    let countFieldName = grp.GName  // a groups shortName is that of the field containing the count
    let grpIterFunc = getGroupContainerType grp
    let isNoSides = countFieldName.Contains "NoSides"
    if isNoSides then   // return a literal list of strings
        [
                       "    let noSidesField =  // ####";
            (sprintf   "        match %s.%sGrp with" parent longName);
                       "        | OneOrTwo.One _ -> NoSides.OneSide";
                       "        | OneOrTwo.Two _ -> NoSides.BothSides";
                       "    WriteNoSides strm noSidesField";
            (sprintf   "    xx.%sGrp |> %s (Write%sGrp strm)   // group" longName grpIterFunc longName);
        ]
    else
        [
            (sprintf   "    let numGrps = %s.%sGrp.Length" parent longName)
            (sprintf   "    Write%s strm (Fix44.Fields.%s numGrps) // write the 'num group repeats' field" countFieldName countFieldName)
            (sprintf   "    %s.%sGrp |> List.iter (fun gg -> Write%sGrp strm gg)" parent longName longName)
        ]



let private genWriteOptionalGroup (parent:string) (grp:Group) = 
    let (GroupLongName longName) = GroupUtils.makeLongName grp
    let countFieldName = grp.GName  // a groups shortName is that of the field containing the count
    let grpIterFunc = getGroupContainerType grp
    let isNoSides = countFieldName.Contains "NoSides" 
    if isNoSides then
        [
            (sprintf   "    xx.%sGrp |> Option.iter (fun gs ->     // group" longName );
                       "        let noSidesField =";
            (sprintf   "            match %s.%sGrp with" parent longName);
                       "            | One _ -> NoSides.OneSide";
                       "            | Two _ -> NoSides.BothSides";
                       "        WriteNoSides strm noSidesField";
            (sprintf   "        %s.NoSidesGrp |> FixTypes.OneOrTwoIter (WriteNoSidesGrp strm)" parent);
            (sprintf   "        xx.%sGrp |> %s (Write%sGrp strm)   // group" longName grpIterFunc longName);
        ]
    else
        [
            (sprintf   "    xx.%sGrp |> Option.iter (fun gs ->     // group" longName );
            (sprintf   "        let numGrps = gs.Length");
            (sprintf   "        Write%s strm (Fix44.Fields.%s numGrps) // write the 'num group repeats' field" countFieldName countFieldName);
            (sprintf   "        gs |> List.iter (fun gg -> Write%sGrp strm gg)    ) // end Option.iter" longName);
        ]



let genItemListWriterStrs (items:FIXItem list) =
    items 
        |> List.map (fun item ->
                match item with
                | FIXItem.Field fld         ->  match fld.Required with
                                                | Required.Required     ->  [sprintf "    Write%s strm xx.%s" fld.FName fld.FName]
                                                | Required.NotRequired  ->  [sprintf "    xx.%s |> Option.iter (Write%s strm)" fld.FName fld.FName]
                | FIXItem.ComponentRef cmp  ->  let (ComponentName name) = cmp.CRName
                                                match cmp.Required with
                                                | Required.Required     ->  [sprintf "    Write%s strm xx.%s    // component" name name]
                                                | Required.NotRequired  ->  [sprintf "    xx.%s |> Option.iter (Write%s strm) // component" name name]
                | FIXItem.Group grp         ->  match grp.Required with
                                                | Required.Required     ->  genWriteGroup "xx" grp
                                                | Required.NotRequired  ->  genWriteOptionalGroup "xx" grp
                ) // end List.map
        |> List.concat // flatten the 'string list list' into a 'string list'


