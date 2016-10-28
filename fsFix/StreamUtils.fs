module StreamUtils

open System
open System.IO

open Conversions




type Stream with
    member this.Write bs = this.Write(bs, 0, bs.Length)

// todo: CrapReadUntilDelim needs to be replaced with something less crap, that does not read one byte at a time
// todo: return byte arrays, or views into a byte array instead of a string
let CrapReadUntilDelim (strm:Stream) : string =
    let rec innerRead () : int list =
        match strm.ReadByte() with    // annoyingly ReadByte returns an int32
        | -1    ->  failwith "unexpected end of stream"
        | 1     ->  []
        | b     ->  b :: innerRead () 
    let chars = innerRead() |> List.map System.Convert.ToChar |> Array.ofList
    System.String chars


let CrapReadUntilDelim2 (strm:Stream) : byte[] =
    let rec innerRead () : byte list =
        match strm.ReadByte() with    // annoyingly ReadByte returns an int32
        | -1    ->  failwith "unexpected end of stream"
        | 1     ->  []  // 1 is the field deliminator
        | ii    ->  byte(ii) :: innerRead () 
    innerRead() |> Array.ofList

let CrapReadUntilEq (strm:Stream) : byte[] =
    let rec innerRead () : byte list =
        match strm.ReadByte() with    // annoyingly ReadByte returns an int32
        | -1    ->  failwith "unexpected end of stream"
        | 61    ->  []  // 61 is '=', the tag value seperator
        | ii    ->  byte(ii) :: innerRead () 
    innerRead() |> Array.ofList


type TagValue = { Tag:byte[]; Value:byte[]}


let findIdx (bs:byte []) =
    let mutable ctr = 0
    while (bs.[ctr] <> 61uy) && ctr < bs.Length do
        ctr <- ctr + 1
    if ctr = bs.Length then failwith "could not find '=' in tag val pair"
    ctr


let parseTagValue (bs:byte[]) =
    let eqPos = findIdx bs
    let tag = bs |> Array.take (eqPos)
    let value = bs |> Array.skip (eqPos + 1)
    {Tag=tag; Value=value}
    

let rec ReadTagValuesUntilChecksumInner (src:Stream) : TagValue list = 
    let tagVal = CrapReadUntilDelim2 src |> parseTagValue
    match tagVal.Tag with 
    | "10"B ->  [tagVal]
    | "95"B ->  let lenVal = bytesToInt32 tagVal.Value
                let rawDataTag  = CrapReadUntilEq src // read what should be the tag of the raw data field, also reads the tag-val seperator '=' and throw it away
                if rawDataTag <> "96"B then failwith "unexpected field tag following RawDataLength"
                let arr = Array.zeroCreate<byte> lenVal
                let lenRead = src.Read (arr, 0, lenVal) // todo: network streams may require more than one read to pull in all of the data
                if (lenRead <> lenVal) then failwith "failed to read all of raw data"
                let rawData = {Tag="96"B; Value=arr}
                let bb = src.ReadByte() // read the field delimator of the next field
                if bb <> 1 then failwith "invalid tag-value seperator" // 61 is equals, ReadByte returns an Int32
                tagVal ::rawData :: ReadTagValuesUntilChecksumInner src
    | _     ->  tagVal :: ReadTagValuesUntilChecksumInner src


let rec ReadTagValuesUntilBodyLength (src:Stream) : TagValue list = 
    let tagVal = CrapReadUntilDelim2 src |> parseTagValue
    match tagVal.Tag with 
    | "9"B ->  [tagVal]
    | _     ->  tagVal :: ReadTagValuesUntilBodyLength src

let rec ReadTagValuesUntilCheckSum (src:Stream) : TagValue list = 
    let tagVal = CrapReadUntilDelim2 src |> parseTagValue
    match tagVal.Tag with 
    | "10"B ->  [tagVal]
    | _     ->  tagVal :: ReadTagValuesUntilCheckSum src



let ReadTagValuesUntilChecksum (src:System.IO.Stream) : TagValue array = 
    let tvs = ReadTagValuesUntilChecksumInner  src
    tvs |> Array.ofList



// the checksum value is always three digits long, as is the tag
//let checkSumLen = 6
//
//// todo: careful not to confuse rawData with a checksum
//let findCheckSumPos (pos:int) (bs:byte[]) =
//    let mutable found = false
//    let mutable ctr = pos - checkSumLen
//    while ctr >= 0 && (not found)  do
//        if bs.[ctr] = 49uy && bs.[ctr+1] = 48uy && bs.[ctr+2] = 61uy then
//            found <- true
//        else
//            ctr <- ctr - 1
//    ctr // will be -1 if 


// todo: deal with partial bytes from previous reads
//          use two arrays, read all from the first - the socket array
// todo: deal with partial bytes remaining 

let ReadNBytes (rcvBufSz:int) (strm:Stream) = 
    let rec readInner (strm:Stream) (totalBytesToRead:int) (byteArray:byte array) =
        let mutable maxNumBytesToRead = if totalBytesToRead > rcvBufSz then rcvBufSz else totalBytesToRead
        let mutable totalSoFar = 0
        while totalSoFar < totalBytesToRead do
            let numBytesRead = strm.Read (byteArray, totalSoFar, maxNumBytesToRead)            
            totalSoFar <- totalSoFar + numBytesRead
            let numBytesRemaining = totalBytesToRead - totalSoFar
            maxNumBytesToRead <- if numBytesRemaining > rcvBufSz then rcvBufSz else numBytesRemaining
    let lenToRead = rcvBufSz
    let byteArr = Array.zeroCreate<byte> lenToRead
    do readInner strm lenToRead byteArr
    byteArr



let calcCheckSum (arr:byte[])  =
    let mutable (sum:byte) = 0uy
    for ctr = 0 to (arr.Length - 1) do
        sum <- sum + arr.[ctr]
    int (sum)


// read
//     fields upto MsgLen
//     msgLen bytes
//     fields until checksum
let ReadMsgBytes (src:Stream) = 
    let hdr = ReadTagValuesUntilBodyLength src
    let bodyLengthField = hdr |> List.rev |> List.head //todo: ugly and probably slow code ReadingMsgBytes
    let bodyLen = bodyLengthField.Value |> bytesToInt32 
    let bsBody = ReadNBytes bodyLen src
    let trailer = ReadTagValuesUntilCheckSum src
    let checkSumField = trailer |> List.rev |> List.head //todo: ugly and probably slow code ReadingMsgBytes
    let expectedCheckSum = checkSumField.Value |> bytesToInt32 
    let calculatedCheckSum = calcCheckSum bsBody
    if expectedCheckSum <> calculatedCheckSum then failwith "checksum validation failure"
    bsBody

