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





// Will consider a non-allocating bytesToInt32, such as bytesToInt32Direct.
// benchmarkdotnet shows that while bytesToInt32Direct is faster than bytesToInt32, but that bytesToInt32 takes 100's of nanoseconds which may not be a significant part of reading a FIX message.
//
//                                    Method |        Mean |    StdErr |     StdDev |      Median |
//------------------------------------------ |------------ |---------- |----------- |------------ |
//                       BytesToIntViaString | 164.5883 ns | 1.9717 ns | 19.7175 ns | 154.2573 ns | equivalent to bytesToInt32
//                BytesToIntDirectNoChecking |   8.4745 ns | 0.2718 ns |  2.7182 ns |   7.2195 ns |
//              BytesToIntDirectWithChecking |   8.6798 ns | 0.2012 ns |  2.0115 ns |   7.5519 ns | equivalent to bytesToInt32Direct below
// BytesToIntDirectWithCheckingBadBranchPred |   9.1458 ns | 0.1299 ns |  1.2986 ns |   8.4423 ns |

let bytesToInt32 (bs:byte array) (pos:int) (len:int) =
    let mutable num = 0
    let mutable ctr = pos
    let endPos = pos + len // one after the last valid position
    let mutable b = bs.[ctr]
    if b <> 45uy then 
        // first byte is not a minus sign
        while ctr < endPos do
            b <- bs.[ctr]
            if b > 47uy && b < 58uy then
                num <- num * 10 + int32 (b - 48uy);
                ctr <- ctr + 1;
            else
                failwithf "bytesToInt32, byte should be a digit: %d" b
        num
    else
        // first byte is a minus sign
        ctr <- ctr + 1
        while ctr <> endPos do
            b <- bs.[ctr]
            if b > 47uy && b < 58uy then
                num <- num * 10 + int32 (b - 48uy);
                ctr <- ctr + 1;
            else
                failwithf "bytesToInt32, byte should be a digit: %d" b
        num * -1


let bytesToUInt32 (bs:byte array) (pos:int) (len:int) =
    let mutable num = 0u
    let mutable ctr = pos
    let endPos = pos + len // one after the last valid position
    let mutable b = bs.[ctr]
    while ctr < endPos do
        if b > 47uy && b < 58uy then
            num <- num * 10u + uint32 (b - 48uy);
            ctr <- ctr + 1;
        else
            failwithf "bytesToUInt32, byte should be a digit: %d" b
    num


////// todo: replace with an impl the reads the int directly from the byte array without a tmp string
//let bytesToInt32 bs pos len =
//    let ss = bytesToStr bs pos len
//    System.Convert.ToInt32 ss
//
//
//// todo: replace with an impl the reads the uint directly from the byte array without a tmp string
//let bytesToUInt32 bs pos len =
//    let ss = bytesToStr bs pos len
//    System.Convert.ToUInt32 ss

let bytesToBool (bs:byte[]) (pos:int) = 
    match bs.[pos] with
    | 89uy ->  true  // Y
    | 78uy ->  false  // N
    | _ ->  failwithf "invalid value for bool field: %d, should be 89 (Y) or 78 (N)" bs.[pos]

// todo: replace with impl that reads the decimal directly with the tmp string
let bytesToDecimal (bs:byte[]) pos len = 
    let ss = System.Text.Encoding.ASCII.GetString (bs, pos, len)
    Convert.ToDecimal ss 



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
    

