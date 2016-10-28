module FieldFuncs

open System




// todo: microbenchmark inlining this func
let ReadSingleCaseDUIntField (pos:int) (bs:byte[]) fldCtor =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let tmp = Conversions.bytesToInt32 valIn
    let fld = fldCtor tmp
    pos2 + 1, fld // +1 to advance the position to after the field separator


// todo: microbenchmark inlining this func
let ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) fldCtor =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let tmp = Conversions.bytesToDecimal valIn
    let fld = fldCtor tmp
    pos2 + 1, fld 


// todo: microbenchmark inlining this func
let ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) fldCtor =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let tmp = Conversions.bytesToBool valIn
    let fld = fldCtor tmp
    pos2 + 1, fld 


// todo: microbenchmark inlining this func
let ReadSingleCaseDUStrField (pos:int) (bs:byte[]) fldCtor =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let tmp = Conversions.bytesToStr valIn
    let fld = fldCtor tmp
    pos2 + 1, fld // +1 to advance the position to after the field separator


// todo: microbenchmark inlining this func
let ReadLengthStringCompoundField (strTagExpected:byte[]) (pos:int) (bs:byte[]) fldCtor =
    let nextFieldTermPos, lenBytes = ByteArrayUtils.readValAfterTagValSep pos bs
    let strLen = Conversions.bytesToInt32 lenBytes
    let nextFieldBeg = nextFieldTermPos + 1
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    let strFieldTagValSepPos, strTagBytes = ByteArrayUtils.readTagAfterFieldDelim nextFieldBeg bs
    if strTagExpected <> strTagBytes then failwith "ReadLengthStringCompoundField, unexpected string field tag"
    let strFieldBegin = strFieldTagValSepPos + 1
    let nextFieldTermPos2, strBytes = ByteArrayUtils.readNBytesVal strFieldBegin strLen bs
    let str = Conversions.bytesToStr strBytes
    nextFieldTermPos2 + 1, fldCtor str
