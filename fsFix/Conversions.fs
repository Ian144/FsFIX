module Conversions

open System

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
    

