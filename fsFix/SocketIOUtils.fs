module ReadWriteFuncs

open System.IO



let private bytesToStr bs = System.Text.Encoding.UTF8.GetString(bs)

let private bytesToInt32 = bytesToStr >> System.Convert.ToInt32 




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
        | 61    ->  [] 
        | ii    ->  byte(ii) :: innerRead () 
    innerRead() |> Array.ofList


type TagValue = {Tag:byte[]; Value:byte[]}


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

let ReadTagValuesUntilChecksum (src:System.IO.Stream) : TagValue array = 
    let tvs = ReadTagValuesUntilChecksumInner  src
    tvs |> Array.ofList
