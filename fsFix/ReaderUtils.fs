module ReaderUtils








// https://software.intel.com/en-us/articles/branch-and-loop-reorganization-to-prevent-mispredicts
// Static branch prediction is used when there is no data collected by the microprocessor when it encounters a branch, which is typically the first time a branch is encountered. 
// The rules are simple:
//  A forward branch defaults to not taken
//  A backward branch defaults to taken
// In order to effectively write your code to take advantage of these rules, when writing if-else or switch statements, check the most common cases first and work progressively 
// down to the least common.


let ReadFieldIdx bs (index:FIXBufIndexer.FixBufIndex) tag readFunc = 
    let fieldPosArr = index.FieldPosArr
    let tagIdx = FIXBufIndexer.FindFieldIdx index index.EndPos tag
    if tagIdx <> -1 then 
        let fpData = fieldPosArr.[tagIdx]
        index.LastReadIdx <- tagIdx
        readFunc bs fpData.Pos fpData.Len
    else
        let msg = sprintf "field not found, tag: %s" "XXX"
        failwith msg


// todo: currently giving the ordered read functions a different signature to the unordered by adding an unused bool param, to find errors in code generation where the wrong one is called at compile time
let ReadFieldIdxOrdered  (_:bool) bs (index:FIXBufIndexer.FixBufIndex) tag readFunc =
    let nextFieldIdx = index.LastReadIdx + 1
    let fpData = index.FieldPosArr.[nextFieldIdx]
    if fpData.Tag = tag then
        index.LastReadIdx <- nextFieldIdx
        readFunc bs fpData.Pos fpData.Len // this is the expected case
    else
        let msg = sprintf "field not found, tag: %d at field pos: %d" tag nextFieldIdx
        failwith msg


let ReadOptionalFieldIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (tag:int) readFunc = 
    let fieldPosArr = index.FieldPosArr
    let tagIdx = FIXBufIndexer.FindFieldIdx index index.EndPos tag
    if tagIdx = -1 then // no preference as to wether the common case is Option.None or not
        Option.None
    else
        index.LastReadIdx <- tagIdx
        let fpData = fieldPosArr.[tagIdx]
        let fld = readFunc bs fpData.Pos fpData.Len
        Option.Some fld

// todo: currently giving the ordered read functions a different signature to the unordered by adding an unused bool param, to find errors in code generation where the wrong one is called at compile time
let ReadOptionalFieldIdxOrdered (_:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (tag:int) readFunc = 
    let nextFieldIdx = index.LastReadIdx + 1
    let fpData = index.FieldPosArr.[nextFieldIdx]
    if fpData.Tag = tag then // no preference as to wether the common case is Option.None or not
        index.LastReadIdx <- nextFieldIdx
        let fld = readFunc bs fpData.Pos fpData.Len
        Option.Some fld
    else
        Option.None





// the int that readFunc returns is the consecutively next index pos in the FIX buffer field index array 
// todo, consider replacing the accumulating list with an array
let rec readGrpInnerIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (acc:'grp list) (recursionCount:uint32) (readFunc: byte[]->FIXBufIndexer.FixBufIndex->'grp) =
    match recursionCount with
    | 0u    ->  acc |> List.rev // without this the last group in the fix buffer would be first in the list, todo: fix this possible perf issue
    | _     ->  let grpInstance = readFunc bs index
                readGrpInnerIdx bs index (grpInstance::acc) (recursionCount-1u) readFunc


// the tag is the tag of the "number group repeats" field, which can be anywhere in the buffer/index
// the rest of the group fields must come consecutively after this point
let ReadGroupIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (numFieldTag:int) readFunc =
    let fieldPosArr = index.FieldPosArr
    let numFieldIndex = FIXBufIndexer.FindFieldIdx index index.EndPos numFieldTag
    if numFieldIndex <> -1 then 
        let numFieldData = fieldPosArr.[numFieldIndex]
        index.LastReadIdx <- numFieldIndex
        let numRepeats = Conversions.bytesToUInt32Idx bs numFieldData.Pos numFieldData.Len
        readGrpInnerIdx bs index [] numRepeats readFunc
    else
        let msg = sprintf "group num field not found, tag: %s" "XXX" //todo: fix XXX
        failwith msg




let ReadNoSidesGroupIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (numFieldTag:int) readFunc =
    let fieldPosArr = index.FieldPosArr
    let numFieldIndex = FIXBufIndexer.FindFieldIdx index index.EndPos numFieldTag
    if numFieldIndex = -1 then 
        let msg = sprintf "group num field not found, tag: %s" "XXX" //todo: fix XXX
        failwith msg
    let numFieldData = fieldPosArr.[numFieldIndex]
    index.LastReadIdx <- numFieldIndex
    let numRepeats = Conversions.bytesToUInt32Idx bs numFieldData.Pos numFieldData.Len
    match numRepeats with
    | 1u  -> let grp = readFunc bs index // the group must start after the num field
             OneOrTwo.One grp
    | 2u  -> let grp1 = readFunc bs index
             let grp2 = readFunc bs index
             OneOrTwo.Two (grp1, grp2)
    | x   -> failwith (sprintf "ReadNoSidesGroup invalid num repeats, must be 1 or 2, was: %d" x)



let ReadOptionalGroupIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (numFieldTag:int) readFunc: 'grp list option =
    let nextFieldIdx = index.LastReadIdx + 1 // if the group exists the num field must be here
    let fpData = index.FieldPosArr.[nextFieldIdx]
    if fpData.Tag = numFieldTag then
        index.LastReadIdx <- nextFieldIdx
        let numRepeats = Conversions.bytesToUInt32Idx bs fpData.Pos fpData.Len        
        readGrpInnerIdx bs index [] numRepeats readFunc |> Option.Some
    else
        Option.None // the optional group is not present


let ReadOptionalGroupIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (numFieldTag:int) readFunc: 'grp list option =
    let fieldPosArr = index.FieldPosArr
    let numFieldIdx = FIXBufIndexer.FindFieldIdx index index.EndPos numFieldTag
    if numFieldIdx = -1 then 
        Option.None // the optional group is not present
    else
        // the optional group is present, so read the number of repeats, then read each instance of the repeating group
        let fpData = fieldPosArr.[numFieldIdx]
        index.LastReadIdx <- numFieldIdx
        let numRepeats = Conversions.bytesToUInt32Idx bs fpData.Pos fpData.Len
        let gs = readGrpInnerIdx bs index [] numRepeats readFunc
        Option.Some gs


let ReadComponentIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) readFunc = 
    readFunc bs index


// the first field of an optional component is required, so the component is present if the first field is present
let ReadOptionalComponentIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (firstFieldTag:int) readFunc =
    let numFieldIdx = FIXBufIndexer.FindFieldIdx index index.EndPos firstFieldTag
    if numFieldIdx = -1 then 
        Option.None // the optional component is not present
    else
        let comp = readFunc bs index
        Option.Some comp


// todo: currently giving the ordered read functions a different signature to the unordered by adding an unused bool param, to find errors in code generation where the wrong one is called at compile time
let ReadComponentIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) readFunc = 
    readFunc bb bs index

// todo: currently giving the ordered read functions a different signature to the unordered by adding an unused bool param, to find errors in code generation where the wrong one is called at compile time
// the first field of an optional component is required (code generation always sets this to be the case, ignoring FIX spec xml), so the component is present if the first field is present
let ReadOptionalComponentIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) (firstFieldTag:int) readFunc =
    let nextFieldIdx = index.LastReadIdx + 1
    let fpData = index.FieldPosArr.[nextFieldIdx]
    if fpData.Tag = firstFieldTag then 
        let comp = readFunc bb bs index
        Option.Some comp
    else
        Option.None // the optional component is not present

