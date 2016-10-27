module ReadWriteFuncs

open System
open System.IO



let findNextFieldTerm (pos:int) (bs:byte[]) =
    let mutable found = false
    let mutable ctr = pos
    while (ctr < bs.Length && (not found)) do
        if bs.[ctr] = 1uy then
            found <- true
        else
            ctr <- ctr + 1
    if found then ctr else -1


/// assumes and checks that the prev byte pointed to by pos is a tag=value separator (i.e. an '=)
/// returns the index of first char after the field value and the value itself
let readValAfterTagValSep (pos:int) (bs:byte[]) =
    // byte value of '=' is 61
    if bs.[pos-1] <> 61uy then failwith "readValAfterFieldSep, prev byte is not a tag value separator"
    let fldTermPos = findNextFieldTerm pos bs
    if fldTermPos = -1 then failwith "could not find next field separator"
    let valLen = fldTermPos - pos // -1 because the field term should not be included in the val
    let bsVal = Array.zeroCreate<byte> valLen
    Buffer.BlockCopy (bs, pos, bsVal, 0, valLen) // pos+1 because the field value does not include the separator
    fldTermPos, bsVal
    

let bytesToStr bs = System.Text.Encoding.UTF8.GetString(bs)

let bytesToInt32 = bytesToStr >> System.Convert.ToInt32 

let bytesToBool (bs:byte[]) = 
    let ii = bytesToInt32 bs
    match ii with
    | 0 ->  false
    | 1 ->  true
    | _ ->  failwith (sprintf "invalid value for bool field: %d" ii) 

    
let bytesToDecimal (bs:byte[]) = 
    let ss = bs |> bytesToStr
    match Decimal.TryParse(ss) with
    | false, _  -> failwith (sprintf "invalid value for decimal field: %s" ss) 
    | true, dd  -> dd


let private bytesToInt32ArSeg (bs:ArraySegment<byte>) = 
    let mutable (ii:int) = 0
    // todo: consider endianess
    for ctr = bs.Offset + bs.Count to bs.Offset do
        ii <- ii + int(bs.Array.[ctr])
    ii

let private sToB (ss:string) = System.Text.Encoding.UTF8.GetBytes ss


// function overloading in F#
[<AbstractClass;Sealed>]
type ToBytes private () =
    static member Convert (str:string) = sToB str
    static member Convert (ii:int32)   = sprintf "%d" ii |> sToB     // todo: what is FIX byte representation endianness
    static member Convert (dd:decimal) = sprintf "%.32f" dd |> sToB  // todo: is "%.32f" ok for Decimal->string conversion, how does fix represent such types? what is thier byte representation
    static member Convert (bb:bool)    = if bb then "1"B else "0"B   // todo: confirm this is how FIX sends bools down the wire


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




let checkSumLen = 6

// todo: careful not to confuse rawData with a checksum
let findCheckSumPos (pos:int) (bs:byte[]) =
    let mutable found = false
    let mutable ctr = pos - checkSumLen
    while ctr >= 0 && (not found)  do
        if bs.[ctr] = 49uy && bs.[ctr+1] = 48uy && bs.[ctr+2] = 61uy then
            found <- true
        else
            ctr <- ctr - 1
    ctr // will be -1 if 


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


//read
//    fields upto MsgLen
//    msgLen bytes
//    fields until checksum
let ReadMsgBytes (src:Stream) = 
    let hdr = ReadTagValuesUntilBodyLength src
    let bodyLengthField = hdr |> List.rev |> List.head // bad taste warning
    let bodyLen = bodyLengthField.Value |> bytesToInt32 
    let bsBody = ReadNBytes bodyLen src
    let trailer = ReadTagValuesUntilCheckSum src
    let checkSumField = trailer |> List.rev |> List.head // bad taste warning
    let expectedCheckSum = checkSumField.Value |> bytesToInt32 
    let calculatedCheckSum = calcCheckSum bsBody
    if expectedCheckSum <> calculatedCheckSum then failwith "checksum validation failure"
    bsBody



//separate reading N bytes from parsing a correct msg body
//does my 'one byte at a time' thing 
//    enable simpler logic by not having any issue with partial reads needing to be followed by more reads?
//      might be OK for 
// break up bsBody in to an array of Segements (use ResizeArray<byte>?) 
//modify Fix44.FieldReadWriteFuncs.ReadField to take two byte arrays, or an ArraySegment
