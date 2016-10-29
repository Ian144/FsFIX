module FieldFuncs

open System
open Conversions

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


let ReadSingleCaseDUDataField (pos:int) (bs:byte[]) fldCtor =
    let pos2, bs = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = fldCtor bs
    pos2 + 1, fld // +1 to advance the position to after the field separator


// todo: microbenchmark inlining this func
// all compound fields are of type data
let ReadLengthDataCompoundField (strTagExpected:byte[]) (pos:int) (bs:byte[]) fldCtor =
    let nextFieldTermPos, lenBytes = ByteArrayUtils.readValAfterTagValSep pos bs
    let strLen = Conversions.bytesToInt32 lenBytes
    let nextFieldBeg = nextFieldTermPos + 1
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    let strFieldTagValSepPos, strTagBytes = ByteArrayUtils.readTagAfterFieldDelim nextFieldBeg bs
    if strTagExpected <> strTagBytes then failwith "ReadLengthDataCompoundField, unexpected string field tag"
    let strFieldBegin = strFieldTagValSepPos + 1
    let nextFieldTermPos2, bs = ByteArrayUtils.readNBytesVal strFieldBegin strLen bs
    nextFieldTermPos2 + 1, fldCtor bs



let inline WriteFieldInt
        (dest:byte []) 
        (nextFreeIdx:int) 
        (tag:byte[]) 
        (fieldIn:^T) : int = 
    let vv = (^T :(member Value:int) fieldIn)
    Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
    let nextFreeIdx2 = nextFreeIdx + tag.Length
    let bs = Conversions.ToBytes.Convert(vv)
    Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + bs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    nextFreeIdx3 + 1 // +1 to include the delimeter


let inline WriteFieldDecimal
        (dest:byte []) 
        (nextFreeIdx:int) 
        (tag:byte[]) 
        (fieldIn:^T) : int = 
    let vv = (^T :(member Value:decimal) fieldIn)
    Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
    let nextFreeIdx2 = nextFreeIdx + tag.Length
    let bs = Conversions.ToBytes.Convert(vv)
    Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + bs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    nextFreeIdx3 + 1 // +1 to include the delimeter


let inline WriteFieldBool
        (dest:byte []) 
        (nextFreeIdx:int) 
        (tag:byte[]) 
        (fieldIn:^T) : int = 
    let vv = (^T :(member Value:bool) fieldIn)
    Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
    let nextFreeIdx2 = nextFreeIdx + tag.Length
    let bs = Conversions.ToBytes.Convert(vv)
    Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + bs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    nextFreeIdx3 + 1 // +1 to include the delimeter

// todo: how could one func replace the WriteFieldXXX funcs

let inline WriteFieldStr 
        (dest:byte []) 
        (nextFreeIdx:int) 
        (tag:byte[]) 
        (fieldIn:^T) : int = 
    let strVal = (^T :(member Value:string) fieldIn)
    Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
    let nextFreeIdx2 = nextFreeIdx + tag.Length
    let bs = Conversions.ToBytes.Convert(strVal)
    Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + bs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    nextFreeIdx3 + 1 // +1 to include the delimeter



let inline WriteFieldData
        (dest:byte []) 
        (nextFreeIdx:int) 
        (tag:byte[]) 
        (fieldIn:^T) : int = 
    let strVal = (^T :(member Value:string) fieldIn)
    Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
    let nextFreeIdx2 = nextFreeIdx + tag.Length
    let bs = Conversions.ToBytes.Convert(strVal)
    Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + bs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    nextFreeIdx3 + 1 // +1 to include the delimeter



