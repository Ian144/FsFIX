module ReadWriteFuncs

open System.IO





let delim = [|1uy|]


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
        | -1    ->  let buf = Array.zeroCreate<byte> 999
                    let n = strm.Read(buf, 0, buf.Length)
                    failwith "unexpected end of stream"
        |  1    ->  []
        | b     ->  b :: innerRead () 

    let chars = innerRead() |> List.map System.Convert.ToChar |> Array.ofList
    System.String chars

