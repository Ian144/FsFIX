module FieldFuncs

open System




// todo: microbenchmark inlining this func
let ReadSingleCaseDUIntField (pos:int) (bs:byte[]) fldCtor =
    let pos2, valIn = ReadWriteFuncs.readValAfterTagValSep pos bs
    let tmp = ReadWriteFuncs.bytesToInt32 valIn
    let fld = fldCtor tmp
    pos2 + 1, fld // +1 to advance the position to after the field separator


// todo: microbenchmark inlining this func
let ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) fldCtor =
    let pos2, valIn = ReadWriteFuncs.readValAfterTagValSep pos bs
    let tmp = ReadWriteFuncs.bytesToDecimal valIn
    let fld = fldCtor tmp
    pos2 + 1, fld 


// todo: microbenchmark inlining this func
let ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) fldCtor =
    let pos2, valIn = ReadWriteFuncs.readValAfterTagValSep pos bs
    let tmp = ReadWriteFuncs.bytesToBool valIn
    let fld = fldCtor tmp
    pos2 + 1, fld 


// todo: microbenchmark inlining this func
let ReadSingleCaseDUStrField (pos:int) (bs:byte[]) fldCtor =
    let pos2, valIn = ReadWriteFuncs.readValAfterTagValSep pos bs
    let tmp = ReadWriteFuncs.bytesToStr valIn
    let fld = fldCtor tmp
    pos2 + 1, fld // +1 to advance the position to after the field separator


// todo: microbenchmark inlining this func
let ReadLengthStringCompoundField (strTagExpected:byte[]) (pos:int) (bs:byte[]) fldCtor =
    let nextFieldTermPos, lenBytes = ReadWriteFuncs.readValAfterTagValSep pos bs
    let strLen = ReadWriteFuncs.bytesToInt32 lenBytes
    let nextFieldBeg = nextFieldTermPos + 1
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    let strFieldTagValSepPos, strTagBytes = ReadWriteFuncs.readTagAfterFieldDelim nextFieldBeg bs
    if strTagExpected <> strTagBytes then failwith "ReadLengthStringCompoundField, unexpected string field tag"
    let strFieldBegin = strFieldTagValSepPos + 1
    let nextFieldTermPos2, strBytes = ReadWriteFuncs.readNBytesVal strFieldBegin strLen bs
    let str = ReadWriteFuncs.bytesToStr strBytes
    nextFieldTermPos2, fldCtor str
