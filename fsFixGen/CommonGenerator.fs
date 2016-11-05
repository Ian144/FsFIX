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



// writes both sub-groups embedded in groups and groups embedded in msgs
let private genWriteGroup (parent:string) (grp:Group) = 
    let (GroupLongName longName) = GroupUtils.makeLongName grp
    let countFieldName = grp.GName  // a groups shortName is that of the field containing the count
    let isNoSides = countFieldName.Contains "NoSides"
    if isNoSides then   // return a literal list of strings
        [
                       "    let noSidesField =";
            (sprintf   "        match %s.%sGrp with" parent longName);
                       "        | OneOrTwo.One _ -> NoSides.OneSide";
                       "        | OneOrTwo.Two _ -> NoSides.BothSides";
                       "    let nextFreeIdx = WriteNoSides dest nextFreeIdx noSidesField";
            (sprintf   "    let nextFreeIdx = xx.%sGrp |> OneOrTwo.fold (Write%sGrp dest) nextFreeIdx  // group" longName longName);
        ]
    else
        [
            (sprintf   "    let numGrps = %s.%sGrp.Length" parent longName)
            (sprintf   "    let nextFreeIdx = Write%s dest nextFreeIdx (Fix44.Fields.%s numGrps) // write the 'num group repeats' field") countFieldName countFieldName
            (sprintf   "    let nextFreeIdx =  %s.%sGrp |> List.fold (fun accFreeIdx gg -> Write%sGrp dest accFreeIdx gg) nextFreeIdx") parent longName longName

//            (sprintf   "    let numGrps = %s.%sGrp.Length" parent longName)
//            (sprintf   "    Write%s strm (Fix44.Fields.%s numGrps) // write the 'num group repeats' field" countFieldName countFieldName)
//            (sprintf   "    %s.%sGrp |> List.iter (fun gg -> Write%sGrp strm gg)" parent longName longName)
        ]



let private genWriteOptionalGroup (parent:string) (grp:Group) = 
    let (GroupLongName longName) = GroupUtils.makeLongName grp

    let countFieldName = grp.GName  // a groups shortName is that of the field containing the count
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
            (sprintf   "        xx.%sGrp |> OneOrTwo.fold (Write%sGrp strm)   // group" longName longName);
        ]
    else
        [
            (sprintf "    // group (apologies for this nested fold code, will refactor when I think of something better)")
            (sprintf "    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:%sGrp list) ->" longName)
            (sprintf "                                        let numGrps = gs.Length")
            (sprintf "                                        let innerNextFreeIdx2 = Write%s dest innerNextFreeIdx (Fix44.Fields.%s numGrps) // write the 'num group repeats' field") countFieldName countFieldName
            (sprintf "                                        List.fold (fun accFreeIdx gg -> Write%sGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx") longName
            (sprintf "                                  nextFreeIdx") 
            (sprintf "                                  xx.%sGrp  // end Option.fold" longName)
//            (sprintf   "    xx.%sGrp |> Option.iter (fun gs ->     // group" longName );
//            (sprintf   "        let numGrps = gs.Length");
//            (sprintf   "        Write%s strm (Fix44.Fields.%s numGrps) // write the 'num group repeats' field" countFieldName countFieldName);
//            (sprintf   "        gs |> List.iter (fun gg -> Write%sGrp strm gg)    ) // end Option.iter" longName);
        ]



let genItemListWriterStrs (items:FIXItem list) =
    items |> List.collect (fun item ->
        match item with
        | FIXItem.Field fld         ->  let name = fld.FName
                                        match fld.Required with
                                        | Required.Required     ->  [   sprintf "    let nextFreeIdx = Write%s dest nextFreeIdx xx.%s" name name ]
                                        | Required.NotRequired  ->  [   sprintf "    let nextFreeIdx = Option.fold (Write%s dest) nextFreeIdx xx.%s" name name ]
        | FIXItem.ComponentRef cmp  ->  let (ComponentName name) = cmp.CRName
                                        match cmp.Required with
                                        | Required.Required     ->  [   sprintf "    let nextFreeIdx = Write%s dest nextFreeIdx xx.%s   // component" name name ]
                                        | Required.NotRequired  ->  [   sprintf "    let nextFreeIdx = Option.fold (Write%s dest) nextFreeIdx xx.%s    // component option" name name ]
        | FIXItem.Group grp         ->  match grp.Required with
                                        | Required.Required     ->  genWriteGroup "xx" grp
                                        | Required.NotRequired  ->  genWriteOptionalGroup "xx" grp
        ) // end List.collect



let genItemListReaderStrs  (fieldNameMap:Map<string,SimpleField>)  (parentName:string) (items:FIXItem list) =
    items |> List.collect (fun item ->
        match item with
        | FIXItem.Field fld         ->  let name = fld.FName
                                        let simpleField = fieldNameMap.[name] // the program is broken if this does not succeed, so fail fast
                                        let tag = simpleField.Tag
                                        let lcase1Name = Utils.lCaseFirstChar name
                                        match fld.Required with
                                        | Required.Required     ->  [   sprintf "    let pos, %s = ReadField \"Read%s\" pos \"%d\"B bs Read%s" lcase1Name parentName tag name ]
                                        | Required.NotRequired  ->  [   sprintf "    let pos, %s = ReadOptionalField pos \"%d\"B bs Read%s" lcase1Name tag name ]
        | FIXItem.ComponentRef cmp  ->  let (ComponentName name) = cmp.CRName
                                        match cmp.Required with
                                        | Required.Required     ->  [] // [   sprintf "    let pos = Write%s dest pos xx.%s   // component" name name ]
                                        | Required.NotRequired  ->  [] // [   sprintf "    let pos = Option.fold (Write%s dest) pos xx.%s    // component option" name name ]
        | FIXItem.Group grp         ->  match grp.Required with
                                        | Required.Required     ->  [] // genWriteGroup "xx" grp
                                        | Required.NotRequired  ->  [] // genWriteOptionalGroup "xx" grp
        ) // end List.collect

//let genItemListReaderFieldApplicationStrs (parentName:string) (items:FIXItem list) =
//    items |> List.collect (fun item ->
//        match item with
//        | FIXItem.Field fld         ->  let name = fld.FName
//                                        let lcase1Name = Utils.lCaseFirstChar name
//                                        match fld.Required with
//                                        | Required.Required     ->  [   sprintf "    let pos, %s = ReadField \"Read%s\" pos \"tag\"B bs Fix44.FieldReadFuncs.%s" lcase1Name parentName name ]
//                                        | Required.NotRequired  ->  [   sprintf "    let pos, %s = ReadOptionalField pos \"tag\"B bs Fix44.FieldReadFuncs.%s" lcase1Name name ]
//        | FIXItem.ComponentRef cmp  ->  let (ComponentName name) = cmp.CRName
//                                        match cmp.Required with
//                                        | Required.Required     ->  [] // [   sprintf "    let pos = Write%s dest pos xx.%s   // component" name name ]
//                                        | Required.NotRequired  ->  [] // [   sprintf "    let pos = Option.fold (Write%s dest) pos xx.%s    // component option" name name ]
//        | FIXItem.Group grp         ->  match grp.Required with
//                                        | Required.Required     ->  [] // genWriteGroup "xx" grp
//                                        | Required.NotRequired  ->  [] // genWriteOptionalGroup "xx" grp
//        ) // end List.collect



//    items
//        |> List.map (fun item ->
//                match item with
//                | FIXItem.Field fld         ->  let name = fld.FName
//                                                let lcase1Name = Utils.lCaseFirstChar name
//                                                match fld.Required with
//                                                | Required.Required     ->  [   sprintf "    let pos, %s = ReadField \"Read%s\" pos \"tag\"B bs Fix44.FieldReadFuncs.%s" lcase1Name parentName name ]
//                                                | Required.NotRequired  ->  [   sprintf "    let pos, %s = ReadOptionalField pos \"tag\"B bs Fix44.FieldReadFuncs.%s" lcase1Name name ]
//                | FIXItem.ComponentRef cmp  ->  let (ComponentName name) = cmp.CRName
//                                                match cmp.Required with
//                                                | Required.Required     ->  [] // [   sprintf "    let pos = Write%s dest pos xx.%s   // component" name name ]
//                                                | Required.NotRequired  ->  [] // [   sprintf "    let pos = Option.fold (Write%s dest) pos xx.%s    // component option" name name ]
//                | FIXItem.Group grp         ->  match grp.Required with
//                                                | Required.Required     ->  [] // genWriteGroup "xx" grp
//                                                | Required.NotRequired  ->  [] // genWriteOptionalGroup "xx" grp
//                ) // end List.map
//        |> List.concat // flatten the 'string list list' into a 'string list'


