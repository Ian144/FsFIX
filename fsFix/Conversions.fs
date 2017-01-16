module Conversions

open System


let bytesToStrIdx bs pos len = System.Text.Encoding.UTF8.GetString (bs, pos, len)

// UTF-8 is a variable length encoding with a minimum of 8 bits per character. Characters with higher code points will take up to 32 bits, hence the len
// replace with an impl that does not allocate a tmp array
let bytesToCharIdx bs pos len = 
    let cs = System.Text.Encoding.UTF8.GetChars(bs, pos, len)
    if cs.Length <> 1 then
        let msg = sprintf "should be single char at pos: %d, len: %d" pos len
        failwith msg
    cs.[0]

// todo: replace with an impl the reads the int directly from the byte array without a tmp string
let bytesToInt32Idx bs pos len =
    let ss = bytesToStrIdx bs pos len
    System.Convert.ToInt32 ss


// todo: replace with an impl the reads the uint directly from the byte array without a tmp string
let bytesToUInt32Idx bs pos len =
    let ss = bytesToStrIdx bs pos len
    System.Convert.ToUInt32 ss

let bytesToBoolIdx (bs:byte[]) (pos:int) =
    match bs.[pos] with
    | 89uy ->  true  // Y
    | 78uy ->  false  // N
    | _ ->  failwith (sprintf "invalid value for bool field: %d, should be 89 (Y) or 78 (N)" bs.[pos]) 

// todo: replace with impl that reads the decimal directly with the tmp string
let bytesToDecimalIdx (bs:byte[]) pos len = 
    let ss = bytesToStrIdx bs pos len
    match Decimal.TryParse(ss) with
    | false, _  -> failwith (sprintf "invalid value for decimal field: %s" ss) 
    | true, dd  -> dd






let bytesToStr bs = System.Text.Encoding.UTF8.GetString(bs)

let bytesToInt32 = bytesToStr >> System.Convert.ToInt32 

let bytesToUInt32 = bytesToStr >> System.Convert.ToUInt32


let bytesToBool (bs:byte[]) =
    match bs with
    | "N"B ->  false
    | "Y"B ->  true
    | _ ->  failwith (sprintf "invalid value for bool field: %A" bs) 
    

let bytesToDecimal (bs:byte[]) = 
    let ss = bs |> bytesToStr
    match Decimal.TryParse(ss) with
    | false, _  -> failwith (sprintf "invalid value for decimal field: %s" ss) 
    | true, dd  -> dd


let private sToB (ss:string) = System.Text.Encoding.UTF8.GetBytes ss




[<AbstractClass;Sealed>]
type ToBytes private () =
    static member Convert (str:string) = sToB str
    static member Convert (ii:int32)   = sprintf "%d" ii |> sToB     
    static member Convert (ui:uint32)  = sprintf "%d" ui |> sToB     
    static member Convert (dd:decimal) = sprintf "%.15f" dd |> sToB  // see http://www.onixs.biz/fix-dictionary/4.4/
    static member Convert (bb:bool)    = if bb then "Y"B else "N"B
    static member Convert (bs:byte []) = bs
    

