module RawField

open System
open Conversions

open UTCDateTime
open LocalMktDate





// todo: microbenchmark inlining these read funcs OR manually inline them
let ReadFieldIntIdx bs pos len fldCtor =
    Conversions.bytesToInt32Idx bs pos len |> fldCtor


let ReadFieldUIntIdx bs pos len fldCtor =
    Conversions.bytesToUInt32Idx bs pos len |> fldCtor


let ReadFieldCharIdx bs pos len fldCtor =
    Conversions.bytesToCharIdx bs pos len |> fldCtor


let ReadFieldDecimalIdx bs pos len fldCtor =
    Conversions.bytesToDecimalIdx bs pos len |> fldCtor


let ReadFieldBoolIdx bs pos (len:int) fldCtor =
    Conversions.bytesToBoolIdx bs pos |> fldCtor


let ReadFieldStrIdx bs pos len fldCtor =
    Conversions.bytesToStrIdx bs pos len |> fldCtor

// todo: ReadFieldDataIdx allocates
let ReadFieldDataIdx bs pos len fldCtor =
    let subArray = Array.zeroCreate<byte> len
    Array.Copy(bs, pos, subArray, 0, len)
    fldCtor subArray


let ReadFieldUTCTimeOnlyIdx bs pos len fldCtor =
    UTCDateTime.readUTCTimeOnly bs pos (pos+len) |> fldCtor


let ReadFieldUTCDateIdx bs pos len fldCtor =
    UTCDateTime.readUTCDate bs pos (pos+len) |> fldCtor


let ReadFieldLocalMktDateIdx bs pos len fldCtor =
    LocalMktDate.readLocalMktDate bs pos (pos+len) |> fldCtor


let ReadFieldUTCTimestampIdx bs pos len fldCtor =
    UTCDateTime.readUTCTimestamp bs pos (pos+len) |> fldCtor


let ReadFieldTZTimeOnlyIdx bs pos (len:int) fldCtor = 
    TZDateTime.readTZTimeOnly bs pos |> fldCtor


let ReadFieldMonthYearIdx bs pos (len:int) fldCtor =
    MonthYear.read bs pos |> fldCtor
    

// pos is pointing to the the begining of the length value
let ReadLengthDataCompoundFieldIdx (bs:byte[]) (pos:int) (len:int) (strTagExpected:byte[]) fldCtor =
    let nextFieldBeg, lenBytes = FIXBuf.readValAfterTagValSep bs (pos-1) // todo: temporary hack to allow 
    let lenXXX = Conversions.bytesToInt32 lenBytes
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    let strFieldBegin, strTagBytes = FIXBuf.readTagAfterFieldDelim bs nextFieldBeg
    if strTagExpected <> strTagBytes then failwith "ReadLengthDataCompoundField, unexpected string field tag" //todo: add a better error msg
    let _, bs = FIXBuf.readNBytesVal strFieldBegin lenXXX bs
    fldCtor bs



//----------------

let ReadFieldInt (bs:byte[]) (pos:int) fldCtor =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let tmp = Conversions.bytesToInt32 valIn
    let fld = fldCtor tmp
    pos2, fld



let ReadFieldUint32 (bs:byte[]) (pos:int) fldCtor =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    //let tmp2 = System.BitConverter.ToUInt32 (valIn, 0)
    let tmp = Conversions.bytesToUInt32 valIn
    let fld = fldCtor tmp
    pos2, fld


let ReadFieldChar (bs:byte[]) (pos:int) fldCtor =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let cc =
        match valIn.Length with
        | 1 ->  valIn.[0] |> char
        | n ->  let msg = sprintf "invalid length for char field: %d" n
                failwith msg
    pos2, fldCtor cc



let ReadFieldDecimal (bs:byte[]) (pos:int) fldCtor =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let tmp = Conversions.bytesToDecimal valIn
    let fld = fldCtor tmp
    pos2, fld 




let ReadFieldBool (bs:byte[]) (pos:int) fldCtor =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let tmp = Conversions.bytesToBool valIn
    let fld = fldCtor tmp
    pos2, fld 



let ReadFieldStr (bs:byte[]) (pos:int) fldCtor =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let tmp = Conversions.bytesToStr valIn
    let fld = fldCtor tmp
    pos2, fld


let ReadFieldData (bs:byte[]) (pos:int) fldCtor =
    let pos2, bs = FIXBuf.readValAfterTagValSep bs pos
    let fld = fldCtor bs
    pos2, fld


let ReadFieldUTCTimeOnly (bs:byte[]) (pos:int) fldCtor =
    let pos2 = FIXBuf.findNextFieldTermOrEnd bs pos
    let tm = UTCDateTime.readUTCTimeOnly bs pos pos2
    pos2 + 1,  fldCtor tm // +1 to move one past the field terminator (it does not matter if the 'endPos' is past the end of the array, it is similar to an end() iterator in C++ STL)


let ReadFieldUTCDate (bs:byte[]) (pos:int) fldCtor =
    let pos2 = FIXBuf.findNextFieldTermOrEnd bs pos
    let dt = UTCDateTime.readUTCDate bs pos pos2
    pos2 + 1,  fldCtor dt // +1 to move one past the field terminator (it does not matter if the 'endPos' is past the end of the array, it is similar to an end() iterator in C++ STL)

let ReadFieldLocalMktDate (bs:byte[]) (pos:int) fldCtor =
    let pos2 = FIXBuf.findNextFieldTermOrEnd bs pos
    let dt = LocalMktDate.readLocalMktDate bs pos pos2
    pos2 + 1,  fldCtor dt // +1 to move one past the field terminator (it does not matter if the 'endPos' is past the end of the array, it is similar to an end() iterator in C++ STL)



let ReadFieldUTCTimestamp (bs:byte[]) (pos:int) fldCtor =
    let pos2 = FIXBuf.findNextFieldTermOrEnd bs pos
    let dt = UTCDateTime.readUTCTimestamp bs pos pos2
    pos2 + 1,  fldCtor dt // +1 to move one past the field terminator (it does not matter if the 'endPos' is past the end of the array, it is similar to an end() iterator in C++ STL)

// not used in FIX4.4, so not tested at the time of writing
// TZDateTime.readTZTimeOnly has been tested
let ReadSingleCaseTZTimeOnlyField (bs:byte[]) (pos:int) fldCtor =
    let pos2 = FIXBuf.findNextFieldTermOrEnd bs pos
    let dt = TZDateTime.readTZTimeOnly bs pos //pos2
    pos2 + 1,  fldCtor dt // +1 to move one past the field terminator (it does not matter if the 'endPos' is past the end of the array, it is similar to an end() iterator in C++ STL)


let ReadFieldMonthYear (bs:byte[]) (pos:int) fldCtor =
//    let pos2 = FIXBuf.findNextFieldTermOrEnd bs pos
    let pos2, dt = MonthYear.read bs pos //pos2
    pos2 + 1, fldCtor dt // +1 to move one past the field terminator (it does not matter if the 'endPos' is past the end of the array, it is similar to an end() iterator in C++ STL)


// all compound fields are of type data (i.e. byte[])
let ReadLengthDataCompoundField (bs:byte[]) (pos:int) (strTagExpected:byte[]) fldCtor =
    let nextFieldBeg, lenBytes = FIXBuf.readValAfterTagValSep bs pos
    let strLen = Conversions.bytesToInt32 lenBytes
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    let strFieldBegin, strTagBytes = FIXBuf.readTagAfterFieldDelim bs nextFieldBeg
    if strTagExpected <> strTagBytes then failwith "ReadLengthDataCompoundField, unexpected string field tag"
    let nextFieldTermPos2, bs = FIXBuf.readNBytesVal strFieldBegin strLen bs
    nextFieldTermPos2, fldCtor bs



// todo: how could one func replace the WriteFieldXXX funcs
let inline WriteFieldInt (bs:byte []) (pos:int) (tag:byte[]) (fieldIn:^T) : int = 
    let vv = (^T :(member Value:int) fieldIn)
    Buffer.BlockCopy (tag, 0, bs, pos, tag.Length)
    let pos2 = pos + tag.Length
    let valBytes = Conversions.ToBytes.Convert(vv)
    Buffer.BlockCopy (valBytes, 0, bs, pos2, valBytes.Length)
    let pos3 = pos2 + valBytes.Length
    bs.[pos3] <- 1uy // write the SOH field delimeter
    pos3 + 1 // +1 to move past the delimeter


let inline WriteFieldUint32 (bs:byte []) (pos:int) (tag:byte[]) (fieldIn:^T) : int = 
    let vv = (^T :(member Value:uint32) fieldIn)
    Buffer.BlockCopy (tag, 0, bs, pos, tag.Length)
    let pos2 = pos + tag.Length
    let valBytes = Conversions.ToBytes.Convert vv
    Buffer.BlockCopy (valBytes, 0, bs, pos2, valBytes.Length)
    let pos3 = pos2 + valBytes.Length
    bs.[pos3] <- 1uy // write the SOH field delimeter
    pos3 + 1 // +1 to move past the delimeter


let inline WriteFieldChar (bs:byte []) (pos:int) (tag:byte[]) (fieldIn:^T) : int = 
    let cc = (^T :(member Value:char) fieldIn)
    Buffer.BlockCopy (tag, 0, bs, pos, tag.Length)
    let pos2 = pos + tag.Length
    let valBytes = [|byte(cc)|]
    Buffer.BlockCopy (valBytes, 0, bs, pos2, valBytes.Length)
    let pos3 = pos2 + valBytes.Length
    bs.[pos3] <- 1uy // write the SOH field delimeter
    pos3 + 1 // +1 to move past the delimeter


let inline WriteFieldDecimal (bs:byte []) (pos:int) (tag:byte[]) (fieldIn:^T) : int = 
    let vv = (^T :(member Value:decimal) fieldIn)
    Buffer.BlockCopy (tag, 0, bs, pos, tag.Length)
    let pos2 = pos + tag.Length
    let valBytes = Conversions.ToBytes.Convert(vv)
    Buffer.BlockCopy (valBytes, 0, bs, pos2, valBytes.Length)
    let pos3 = pos2 + valBytes.Length
    bs.[pos3] <- 1uy // write the SOH field delimeter
    pos3 + 1 // +1 to move past the delimeter



let inline WriteFieldBool (bs:byte []) (pos:int) (tag:byte[]) (fieldIn:^T) : int = 
    let vv = (^T :(member Value:bool) fieldIn)
    Buffer.BlockCopy (tag, 0, bs, pos, tag.Length)
    let pos2 = pos + tag.Length
    let valBytes = Conversions.ToBytes.Convert(vv)
    Buffer.BlockCopy (valBytes, 0, bs, pos2, valBytes.Length)
    let pos3 = pos2 + valBytes.Length
    bs.[pos3] <- 1uy // write the SOH field delimeter
    pos3 + 1 // +1 to move past the delimeter



let inline WriteFieldStr (bs:byte []) (pos:int) (tag:byte[]) (fieldIn:^T) : int = 
    let strVal = (^T :(member Value:string) fieldIn)
    Buffer.BlockCopy (tag, 0, bs, pos, tag.Length)
    let pos2 = pos + tag.Length
    let valBytes = Conversions.ToBytes.Convert(strVal)
    Buffer.BlockCopy (valBytes, 0, bs, pos2, valBytes.Length)
    let pos3 = pos2 + valBytes.Length
    bs.[pos3] <- 1uy // write the SOH field delimeter
    pos3 + 1 // +1 to move past the delimeter


let inline WriteFieldUTCTimeOnly (bs:byte []) (pos:int) (tag:byte[]) (fieldIn:^T) : int = 
    let tm = (^T :(member Value:UTCTimeOnly) fieldIn)
    Buffer.BlockCopy (tag, 0, bs, pos, tag.Length)
    let pos2 = pos + tag.Length
    let pos3 =  UTCDateTime.writeUTCTimeOnly tm bs pos2
    bs.[pos3] <- 1uy // write the SOH field delimeter
    pos3 + 1 // +1 to move past the delimeter


let inline WriteFieldUTCDate (bs:byte []) (pos:int) (tag:byte[]) (fieldIn:^T) : int = 
    let tm = (^T :(member Value:UTCDate) fieldIn)
    Buffer.BlockCopy (tag, 0, bs, pos, tag.Length)
    let pos2 = pos + tag.Length
    let pos3 =  UTCDateTime.writeUTCDate tm bs pos2
    bs.[pos3] <- 1uy // write the SOH field delimeter
    pos3 + 1 // +1 to move past the delimeter

let inline WriteFieldLocalMktDate (bs:byte []) (pos:int) (tag:byte[]) (fieldIn:^T) : int = 
    let tm = (^T :(member Value:LocalMktDate) fieldIn)
    Buffer.BlockCopy (tag, 0, bs, pos, tag.Length)
    let pos2 = pos + tag.Length
    let pos3 =  LocalMktDate.writeLocalMktDate tm bs pos2
    bs.[pos3] <- 1uy // write the SOH field delimeter
    pos3 + 1 // +1 to move past the delimeter

let inline WriteFieldUTCTimestamp (bs:byte []) (pos:int) (tag:byte[]) (fieldIn:^T) : int = 
    let tm = (^T :(member Value:UTCTimestamp) fieldIn)
    Buffer.BlockCopy (tag, 0, bs, pos, tag.Length)
    let pos2 = pos + tag.Length
    let pos3 =  UTCDateTime.writeUTCTimestamp tm bs pos2
    bs.[pos3] <- 1uy // write the SOH field delimeter
    pos3 + 1 // +1 to move past the delimeter


// not used in FIX4.4, so not tested at the time of writing
// functions called by TZDateTime.writeTZTimeOnly have been tested
let inline WriteFieldTZTimeOnly (bs:byte []) (pos:int) (tag:byte[]) (fieldIn:^T) : int = 
    let tm = (^T :(member Value:TZDateTime.TZTimeOnly) fieldIn)
    Buffer.BlockCopy (tag, 0, bs, pos, tag.Length)
    let pos2 = pos + tag.Length
    let pos3 =  TZDateTime.writeTZTimeOnly bs pos2 tm
    bs.[pos3] <- 1uy // write the SOH field delimeter
    pos3 + 1 // +1 to move past the delimeter



let inline WriteFieldMonthYear (bs:byte []) (pos:int) (tag:byte[]) (fieldIn:^T) : int = 
    let tm = (^T :(member Value:MonthYear.MonthYear) fieldIn)
    Buffer.BlockCopy (tag, 0, bs, pos, tag.Length)
    let pos2 = pos + tag.Length
    let pos3 =  MonthYear.write bs pos2 tm
    bs.[pos3] <- 1uy // write the SOH field delimeter
    pos3 + 1 // +1 to move past the delimeter



let inline WriteFieldData (bs:byte []) (pos:int) (tag:byte[]) (fieldIn:^T) : int = 
    let strVal = (^T :(member Value:string) fieldIn)
    Buffer.BlockCopy (tag, 0, bs, pos, tag.Length)
    let pos2 = pos + tag.Length
    let valBytes = Conversions.ToBytes.Convert(strVal)
    Buffer.BlockCopy (valBytes, 0, bs, pos2, valBytes.Length)
    let pos3 = pos2 + valBytes.Length
    bs.[pos3] <- 1uy // write the SOH field delimeter
    pos3 + 1 // +1 to move past the delimeter


// compound write, of a compound length+data field
let inline WriteFieldLengthData (bs:byte []) (pos:int) (lenTag:byte[]) (dataTag:byte[]) (fieldIn:^T) : int =
    let dataBs = (^T :(member Value:byte[]) fieldIn)
    // write the len part of the field
    Buffer.BlockCopy (lenTag, 0, bs, pos, lenTag.Length)
    let pos2 = pos + lenTag.Length
    let lenBs = ToBytes.Convert dataBs.Length
    Buffer.BlockCopy (lenBs, 0, bs, pos2, lenBs.Length)
    let pos3 = pos2 + lenBs.Length
    bs.[pos3] <- 1uy // write the SOH field delimeter
    let pos4 = pos3 + 1 // +1 to move past the delimeter
    // write the data part of the compound field
    Buffer.BlockCopy (dataTag, 0, bs, pos4, dataTag.Length)
    let pos5 = pos4 + dataTag.Length
    Buffer.BlockCopy (dataBs, 0, bs, pos5, dataBs.Length)
    let pos6 = pos5 + dataBs.Length
    bs.[pos6] <- 1uy // write the SOH field delimeter
    pos6 + 1 // +1 to move past the delimeter
















