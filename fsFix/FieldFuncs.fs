module FieldFuncs

open System
open Conversions

open FIXDateTime


// todo: microbenchmark inlining these read funcs
let ReadSingleCaseDUIntField (pos:int) (bs:byte[]) fldCtor =
    let pos2, valIn = FIXBufUtils.readValAfterTagValSep pos bs
    let tmp = Conversions.bytesToInt32 valIn
    let fld = fldCtor tmp
    pos2, fld



let ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) fldCtor =
    let pos2, valIn = FIXBufUtils.readValAfterTagValSep pos bs
    let tmp = Conversions.bytesToDecimal valIn
    let fld = fldCtor tmp
    pos2, fld 




let ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) fldCtor =
    let pos2, valIn = FIXBufUtils.readValAfterTagValSep pos bs
    let tmp = Conversions.bytesToBool valIn
    let fld = fldCtor tmp
    pos2, fld 



let ReadSingleCaseDUStrField (pos:int) (bs:byte[]) fldCtor =
    let pos2, valIn = FIXBufUtils.readValAfterTagValSep pos bs
    let tmp = Conversions.bytesToStr valIn
    let fld = fldCtor tmp
    pos2, fld


let ReadSingleCaseDUDataField (pos:int) (bs:byte[]) fldCtor =
    let pos2, bs = FIXBufUtils.readValAfterTagValSep pos bs
    let fld = fldCtor bs
    pos2, fld


let ReadSingleCaseUTCTimeOnlyField  (pos:int) (bs:byte[]) fldCtor =
    let pos2 = FIXBufUtils.findNextFieldTermOrEnd pos bs
    let tm = FIXDateTime.fromBytes bs pos pos2
    pos2,  fldCtor tm


// all compound fields are of type data (i.e. byte[])
let ReadLengthDataCompoundField (strTagExpected:byte[]) (pos:int) (bs:byte[]) fldCtor =
    let nextFieldBeg, lenBytes = FIXBufUtils.readValAfterTagValSep pos bs
    let strLen = Conversions.bytesToInt32 lenBytes
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    let strFieldBegin, strTagBytes = FIXBufUtils.readTagAfterFieldDelim nextFieldBeg bs
    if strTagExpected <> strTagBytes then failwith "ReadLengthDataCompoundField, unexpected string field tag"
    let nextFieldTermPos2, bs = FIXBufUtils.readNBytesVal strFieldBegin strLen bs
    nextFieldTermPos2, fldCtor bs



// todo: how could one func replace the WriteFieldXXX funcs
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
    nextFreeIdx3 + 1 // +1 to move past the delimeter



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
    nextFreeIdx3 + 1 // +1 to move past the delimeter



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
    nextFreeIdx3 + 1 // +1 to move past the delimeter



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
    nextFreeIdx3 + 1 // +1 to move past the delimeter


let inline WriteFieldUTCTimeOnly
        (dest:byte []) 
        (nextFreeIdx:int) 
        (tag:byte[]) 
        (fieldIn:^T) : int = 
    let tm = (^T :(member Value:UTCTimeOnly) fieldIn)
    Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
    let nextFreeIdx2 = nextFreeIdx + tag.Length
    let nextFreeIdx3 =  FIXDateTime.writeBytes tm dest nextFreeIdx2
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    nextFreeIdx3 + 1 // +1 to move past the delimeter




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
    nextFreeIdx3 + 1 // +1 to move past the delimeter


// compound write, of a compound length data field
let inline WriteFieldLengthData (lenTag:byte[]) (dataTag:byte[]) (dest:byte []) (nextFreeIdx:int) (fieldIn:^T) : int =
    let dataBs = (^T :(member Value:byte[]) fieldIn)
    // write the len part of the field
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert dataBs.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to move past the delimeter
    // write the data part of the compound field
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to move past the delimeter
















