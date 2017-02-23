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
 

module FIXDateTime

let inline validate_HHmmss (hh, mm, ss)         = hh >= 0 && hh <= 23 && mm >= 0 && mm <= 59 && ss >= 0 && ss <= 59
let inline validate_HHmmss_sss (hh, mm, ss, ms) = validate_HHmmss (hh, mm, ss) && ms >= 0 && ms <= 999
let inline validate_yyyyMMdd (yy, mm, dd)       = yy >= 0 && yy <= 9999 && 1 >= 0 && mm <= 12 && dd >= 01 && dd <= 31 

let inline validate_yyyyMMdd_HHmmss_sss (yy, mth, dd, hh, mm, ss, ms)   = validate_yyyyMMdd (yy, mth, dd) && validate_HHmmss_sss(hh, mm, ss, ms)
let inline validate_yyyyMMdd_HHmmss   (yy, mth, dd, hh, mm, ss)         = validate_yyyyMMdd (yy, mth, dd) && validate_HHmmss(hh, mm, ss)

let inline validate_HHmm (hh, mm) = hh >= 0 && hh <= 23 && mm >= 0 && mm <= 59


let inline write2ByteInt (bs:byte[]) (pos:int) (n:int) : unit =
    let d1 = (n / 10) 
    let d2 = n - (d1 * 10)
    let b1 = (d1 + 48) |> byte
    let b2 = (d2 + 48) |> byte
    bs.[pos  ] <- b1
    bs.[pos+1] <- b2


let inline write3ByteInt (bs:byte[]) (pos:int) (n:int) : unit =
    let d1 = (n / 100) 
    let n2 = n - (d1 * 100) 
    let d2 = n2 / 10
    let d3 = n2 - (d2 * 10)
    let b1 = (d1 + 48) |> byte
    let b2 = (d2 + 48) |> byte
    let b3 = (d3 + 48) |> byte
    bs.[pos  ] <- b1
    bs.[pos+1] <- b2
    bs.[pos+2] <- b3



let inline write4ByteInt (bs:byte[]) (pos:int) (n:int) : unit =
    let d1 = (n / 1000) 
    let n2 = n - (d1 * 1000) 
    let d2 = n2 / 100
    let n3 = n2 - (d2 * 100)
    let d3 = n3 / 10
    let d4 = n3 - (d3 * 10)
    let b1 = (d1 + 48) |> byte
    let b2 = (d2 + 48) |> byte
    let b3 = (d3 + 48) |> byte
    let b4 = (d4 + 48) |> byte
    bs.[pos  ] <- b1
    bs.[pos+1] <- b2
    bs.[pos+2] <- b3
    bs.[pos+3] <- b4



let inline bytes2ToInt (bs:byte[]) (pos:int) : int =
    let d1 = bs.[pos  ] - 48uy |> int
    let d2 = bs.[pos+1] - 48uy |> int
    d1 * 10 + d2



let inline bytes3ToInt (bs:byte[]) (pos:int) : int =
    let d1 = bs.[pos  ] - 48uy |> int
    let d2 = bs.[pos+1] - 48uy |> int
    let d3 = bs.[pos+2] - 48uy |> int
    d1 * 100 + d2 * 10 + d3

let inline bytes4ToInt (bs:byte[]) (pos:int) : int =
    let d1 = bs.[pos  ] - 48uy |> int
    let d2 = bs.[pos+1] - 48uy |> int
    let d3 = bs.[pos+2] - 48uy |> int
    let d4 = bs.[pos+3] - 48uy |> int
    d1 * 1000 + d2 * 100 + d3 * 10 + d4


let inline readHHMMints (bs:byte[]) (begPos:int) = 
    let hh = bytes2ToInt bs begPos
    let mm = bytes2ToInt bs (begPos + 3) // skip the :
    hh, mm


let inline readHHMMSSints (bs:byte[]) (begPos:int) = 
    let hh = bytes2ToInt bs begPos
    let mm = bytes2ToInt bs (begPos + 3) // skip the :
    let ss = bytes2ToInt bs (begPos + 6) // skip the :
    hh, mm, ss


let inline readHHMMSSMS (bs:byte[]) (begPos:int) =
    let hh = bytes2ToInt bs begPos
    let mm = bytes2ToInt bs (begPos + 3)
    let ss = bytes2ToInt bs (begPos + 6)
    let ms = bytes3ToInt bs (begPos + 9)
    hh, mm, ss, ms



let inline readTimestampInts (bs:byte[]) (begPos:int) = 
    let yy  = bytes4ToInt bs begPos
    let mth = bytes2ToInt bs (begPos + 4)
    let dd  = bytes2ToInt bs (begPos + 6)
    let hh  = bytes2ToInt bs (begPos + 9)
    let mm  = bytes2ToInt bs (begPos + 12)
    let ss  = bytes2ToInt bs (begPos + 15)
    yy, mth, dd, hh, mm, ss


let inline readTimestampMsInts (bs:byte[]) (begPos:int) =
    let yy  = bytes4ToInt bs begPos
    let mth = bytes2ToInt bs (begPos + 4)
    let dd  = bytes2ToInt bs (begPos + 6)
    let hh  = bytes2ToInt bs (begPos + 9)
    let mm  = bytes2ToInt bs (begPos + 12)
    let ss  = bytes2ToInt bs (begPos + 15)
    let ms  = bytes3ToInt bs (begPos + 18)
    yy, mth, dd, hh, mm, ss, ms


let inline readYYYYmmDDints (bs:byte[]) (begPos:int) =
    let yy = bytes4ToInt bs begPos
    let mm = bytes2ToInt bs (begPos + 4)
    let dd = bytes2ToInt bs (begPos + 6)
    yy, mm, dd