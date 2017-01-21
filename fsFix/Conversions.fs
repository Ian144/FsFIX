module Conversions

open System


let bytesToStr bs pos len = System.Text.Encoding.UTF8.GetString (bs, pos, len)

// todo: UTF8 chars may be more than one byte long, deal with this
let bytesToChar (bs:byte[]) pos len = 
    //let cs = System.Text.Encoding.UTF8.GetChars(bs, pos, len)
    if len = 1 then
        let b = bs.[pos]
        char (b)
    else
        failwithf "should be single char at pos: %d, len: %d" pos len


// todo: replace with an impl the reads the int directly from the byte array without a tmp string
let bytesToInt32 bs pos len =
    let ss = bytesToStr bs pos len
    System.Convert.ToInt32 ss


// todo: replace with an impl the reads the uint directly from the byte array without a tmp string
let bytesToUInt32 bs pos len =
    let ss = bytesToStr bs pos len
    System.Convert.ToUInt32 ss

let bytesToBool (bs:byte[]) (pos:int) =
    match bs.[pos] with
    | 89uy ->  true  // Y
    | 78uy ->  false  // N
    | _ ->  failwithf "invalid value for bool field: %d, should be 89 (Y) or 78 (N)" bs.[pos]

// todo: replace with impl that reads the decimal directly with the tmp string
let bytesToDecimal (bs:byte[]) pos len = 
    let ss = bytesToStr bs pos len
    match Decimal.TryParse(ss) with
    | false, _  -> failwithf "invalid value for decimal field: %s" ss
    | true, dd  -> dd




let private sToB (ss:string) = System.Text.Encoding.UTF8.GetBytes ss


//todo: consider how to avoid allocation by writing into a pre-allocated array at a give postion
[<AbstractClass;Sealed>]
type ToBytes private () =
    static member Convert (str:string) = sToB str
    static member Convert (ii:int32)   = sprintf "%d" ii |> sToB     
    static member Convert (ui:uint32)  = sprintf "%d" ui |> sToB     
    static member Convert (dd:decimal) = sprintf "%.15f" dd |> sToB  // see http://www.onixs.biz/fix-dictionary/4.4/
    static member Convert (bb:bool)    = if bb then "Y"B else "N"B
    static member Convert (bs:byte []) = bs
    

