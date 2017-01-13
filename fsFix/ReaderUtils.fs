module ReaderUtils






let ReadFieldIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (tagInt:int) readFunc = 
    let fieldPosArr = index.FieldPosArr
    let tagIdx = FIXBufIndexer.FindFieldIdx index tagInt
    if tagIdx = -1 then 
//        let sExpTag = System.Text.Encoding.UTF8.GetString expectedTag
        let msg = sprintf "field not found, tag: %s" "XXX"
        failwith msg
    let fpData = fieldPosArr.[tagIdx]
    readFunc bs fpData.Pos fpData.Len


let ReadOptionalFieldIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (tagInt:int) readFunc = 
    let fieldPosArr = index.FieldPosArr
    let tagIdx = FIXBufIndexer.FindFieldIdx index tagInt
    if tagIdx = -1 then 
        Option.None
    else
        let fpData = fieldPosArr.[tagIdx]
        let fld = readFunc bs fpData.Pos fpData.Len
        Option.Some fld


// the int that readFunc returns is the consecutively next index pos in the FIX buffer field index array 
// todo, consider replacing the accumulating list with an array
let rec readGrpInnerIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (nextFieldIndexPos:int) (acc:'grp list) (recursionCount:uint32) (readFunc: byte[]->FIXBufIndexer.FixBufIndex->int->int*'grp) =
    match recursionCount with
    | 0u    ->  nextFieldIndexPos, (acc |> List.rev)
    | _     ->  let nextFieldIndexPos2, grpInstance = readFunc bs index nextFieldIndexPos 
                readGrpInnerIdx bs index nextFieldIndexPos2 (grpInstance::acc) (recursionCount-1u) readFunc


// the tagInt is the tag of the "number group repeats" field, which can be anywhere in the buffer/index
// the rest of the group fields must come consecutively after this point
let ReadGroupIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (numFieldTagInt:int) readFunc =
    let fieldPosArr = index.FieldPosArr
    let numFieldIndex = FIXBufIndexer.FindFieldIdx index numFieldTagInt
    if numFieldIndex = -1 then 
        let msg = sprintf "group num field not found, tag: %s" "XXX" //todo: fix XXX
        failwith msg
    let numFieldData = fieldPosArr.[numFieldIndex]
    let numRepeats = Conversions.bytesToUInt32Idx bs numFieldData.Pos numFieldData.Len
    readGrpInnerIdx bs index numFieldIndex [] numRepeats readFunc




let ReadNoSidesGroupIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (numFieldTagInt:int) readFunc =
    let fieldPosArr = index.FieldPosArr
    let numFieldIndex = FIXBufIndexer.FindFieldIdx index numFieldTagInt
    if numFieldIndex = -1 then 
        let msg = sprintf "group num field not found, tag: %s" "XXX" //todo: fix XXX
        failwith msg
    let numFieldData = fieldPosArr.[numFieldIndex]
    let numRepeats = Conversions.bytesToUInt32Idx bs numFieldData.Pos numFieldData.Len
    match numRepeats with
    | 1u  -> let pos4, grp = readFunc bs index (numFieldIndex+1) // the group must start after the num field
             OneOrTwo.One grp
    | 2u  -> let nextFieldIndex, grp1 = readFunc bs index (numFieldIndex+1) // the group must start after the num field
             let _, grp2 = readFunc bs index nextFieldIndex
             OneOrTwo.Two (grp1, grp2)
    | x   -> failwith (sprintf "ReadNoSidesGroup invalid num repeats, must be 1 or 2, was: %A"  x)



let ReadOptionalGroupIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (numFieldTagInt:int) (pos:int) (numFieldTag:byte[]) readFunc: 'grp list option =
    let fieldPosArr = index.FieldPosArr
    let numFieldIdx = FIXBufIndexer.FindFieldIdx index numFieldTagInt
    if numFieldIdx = -1 then 
        Option.None // the optional group is not present
    else
        // the optional group is present, so read the number of repeats, then read each instance of the repeating group
        let fpData = fieldPosArr.[numFieldIdx]
        let numRepeats = Conversions.bytesToUInt32Idx bs fpData.Pos fpData.Len        
        let firstGrpFieldIdx = numFieldIdx + 1 // group fields follow the num group repeats field
        let _, gs = readGrpInnerIdx bs index firstGrpFieldIdx [] numRepeats readFunc
        Option.Some gs


let ReadComponentIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) readFunc = 
    readFunc bs index


// the first field of an optional component is required, so the component is present if the first field is present
let ReadOptionalComponent (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (firstFieldTagInt:int) readFunc =
    let fieldPosArr = index.FieldPosArr
    let numFieldIdx = FIXBufIndexer.FindFieldIdx index firstFieldTagInt
    if numFieldIdx = -1 then 
        Option.None // the optional component is not present
    else
        let comp = readFunc bs index
        Option.Some comp


//------------------------------------------------------------------------------------------------------------------



let ReadField (bs:byte[]) (pos:int) (ss:string) (expectedTag:byte[]) readFunc = 
    let pos2, tag = FIXBuf.readTag bs pos
    if tag <> expectedTag then 
        let sExpTag = System.Text.Encoding.UTF8.GetString expectedTag
        let sActTag = System.Text.Encoding.UTF8.GetString tag
        let msg = sprintf "when reading %s: expected tag: %s, actual: %s" ss sExpTag sActTag
        failwith msg
    let pos3, fld = readFunc bs pos2
    pos3, fld


let ReadOptionalField (bs:byte[]) (pos:int) (expectedTag:byte[]) readFunc : int * 'b option = 
    match FIXBuf.readTagOpt bs pos with
    | Some (pos2, tag)  ->     
        if tag = expectedTag then 
            let pos3, fld = readFunc bs pos2
            pos3, Some fld
        else
            pos, None   // return the original pos, the next read op will re-read it
    | None -> pos, None   // return the original pos, the next read op will re-read it



let rec readGrpInner (bs:byte[]) (pos:int) (acc: 'grp list) (recursionCount:uint32) (readFunc: byte [] -> int -> int * 'grp) =
    match recursionCount with
    | 0u    ->  pos, (acc |> List.rev)
    | _     ->  let pos2, grpInstance = readFunc bs pos 
                readGrpInner bs pos2 (grpInstance::acc) (recursionCount-1u) readFunc


let ReadGroup (bs:byte[]) (pos:int) (ss:string) (numTag:byte[]) readFunc =
    let pos2, tag = FIXBuf.readTag bs pos
    if tag <> numTag then
        let msg = sprintf "when reading %s: expected tag: %A, actual: %A" ss numTag tag
        failwith msg
    let pos3, numRepeatBs = FIXBuf.readValAfterTagValSep bs pos2
    let numRepeats = Conversions.bytesToUInt32 numRepeatBs
    let pos4, gs = readGrpInner bs pos3 [] numRepeats readFunc
    let gsRev = gs
    pos4, gsRev


let ReadNoSidesGroup (bs:byte[]) (pos:int) (ss:string) (numTag:byte[]) readFunc =
    let pos2, tag = FIXBuf.readTag bs pos
    if tag <> numTag then
        let msg = sprintf "ReadNoSidesGroup, when reading %s: expected tag: %A, actual: %A" ss numTag tag
        failwith msg
    let pos3, numRepeatBs = FIXBuf.readValAfterTagValSep bs pos2
    match numRepeatBs with
    | "1"B  ->  let pos4, grp = readFunc bs pos3
                pos4, OneOrTwo.One grp
    | "2"B  ->  let pos4, grp1 = readFunc bs pos3
                let pos5, grp2 = readFunc bs pos4 
                pos5, OneOrTwo.Two (grp1, grp2)
    | x     ->  failwith (sprintf "ReadNoSidesGroup invalid num repeats, must be 1 or 2, was: %A"  x)



let ReadOptionalGroup (bs:byte[]) (pos:int) (numFieldTag:byte[]) (readFunc:byte[] -> int -> int * 'grp) : int * 'grp list option =
    match FIXBuf.readTagOpt bs pos with
    | Some (pos2, tag)  ->
        if tag = numFieldTag then 
            let pos3, numRepeatBs = FIXBuf.readValAfterTagValSep bs pos2
            let numRepeats = Conversions.bytesToUInt32 numRepeatBs
            let pos4, gs = readGrpInner bs pos3 [] numRepeats readFunc
            let gsRev = gs
            pos4, Some gsRev
        else
            pos, None   // return the original pos, the next read op will re-read it
    | None  -> pos, None




let ReadComponent (bs:byte[]) (pos:int) (ss:string) readFunc = 
    let pos3, fld = readFunc bs pos
    pos3, fld


// the first field of an optional component is required, so the component is present if the first field is present
let ReadOptionalComponent (bs:byte[]) (pos:int) (expectedTag:byte[]) readFunc = 
    match FIXBuf.readTagOpt bs pos with
    | Some (_, tag)  ->
        if tag = expectedTag then 
            let pos2, cmp = readFunc bs pos // this will read the tag again, will live with this inefficiency until it proves costly, if ever
            pos2, Some cmp
        else
            pos, None   // return the original pos, the next read op will re-read it
    | None -> pos, None

