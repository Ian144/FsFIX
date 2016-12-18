module Conversions

open System

let bytesToStr bs = System.Text.Encoding.UTF8.GetString(bs)


let bytesToInt32 = bytesToStr >> System.Convert.ToInt32 

let bytesToUInt32 = bytesToStr >> System.Convert.ToUInt32


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


let private sToB (ss:string) = System.Text.Encoding.UTF8.GetBytes ss



[<AbstractClass;Sealed>]
type ToBytes private () =
    static member Convert (str:string) = sToB str
    static member Convert (ii:int32)   = sprintf "%d" ii |> sToB     
    static member Convert (ui:uint32)  = sprintf "%d" ui |> sToB     
    static member Convert (dd:decimal) = sprintf "%.32f" dd |> sToB  // todo: is "%.32f" ok for Decimal->string conversion, how does fix represent such types? what is thier byte representation
    static member Convert (bb:bool)    = if bb then "1"B else "0"B   // todo: confirm this is how FIX sends bools down the wire
    static member Convert (bs:byte []) = bs
    

