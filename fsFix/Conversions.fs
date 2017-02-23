(*
 * Copyright (C) 2016-2017 Ian Spratt <ian144@hotmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301, USA.
 *
 *)
 
module Conversions

open System


let bytesToStr bs pos len = System.Text.Encoding.ASCII.GetString (bs, pos, len)

    
let bytesToChar (bs:byte[]) pos len = 
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




let private sToB (ss:string) = System.Text.Encoding.ASCII.GetBytes ss


//todo: consider how to avoid allocation by writing into a pre-allocated array at a give postion
[<AbstractClass;Sealed>]
type ToBytes private () =
    static member Convert (str:string) = sToB str
    static member Convert (ii:int32)   = sprintf "%d" ii |> sToB     
    static member Convert (ui:uint32)  = sprintf "%d" ui |> sToB     
    static member Convert (dd:decimal) = sprintf "%.15f" dd |> sToB  // see http://www.onixs.biz/fix-dictionary/4.4/
    static member Convert (bb:bool)    = if bb then "Y"B else "N"B
    static member Convert (bs:byte []) = bs
    

