﻿(*
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
 






module TZDateTime

open FIXDateTime




// TZTimeOnly  - NOT USED IN FIX4.4
//
// string field representing the time represented based on ISO 8601. This is the time with a UTC offset to allow identification of local time and timezone of that time.
// Format is HH:MM[:SS][Z [ + - hh[:mm]]] where HH = 00-23 hours, MM = 00-59 minutes, SS = 00-59 seconds, hh = 01-12 offset hours, mm = 00-59 offset minutes.
// Example: 07:39Z is 07:39 UTC
// Example: 02:39-05 is five hours behind UTC, thus Eastern Time
// Example: 15:39+08 is eight hours ahead of UTC, Hong Kong/Singapore time
// Example: 13:09+05:30 is 5.5 hours ahead of UTC, India time
//
// oddly documentation does not mention leap seconds
type TZOffset = private
                    | UTC
                    | PosOffsetHH of Hours:int 
                    | NegOffsetHH of Hours:int
                    | PosOffsetHHmm of Hours:int * Minutes:int 
                    | NegOffsetHHmm of Hours:int * Minutes:int 
                    override this.ToString() = 
                        match this with
                        | UTC                   -> "UTC"
                        | PosOffsetHH hh        -> sprintf "PosOffsetHH %d" hh
                        | NegOffsetHH hh        -> sprintf "NegOffsetHH %d" hh
                        | PosOffsetHHmm (hh,mm) -> sprintf "PosOffsetHHmm %d:%d" hh mm
                        | NegOffsetHHmm (hh,mm) -> sprintf "NegOffsetHHmm %d:%d" hh mm

type TZTimeOnly =  private 
                    | TZTimeOnly    of Offset:TZOffset * Hours:int * Minutes:int
                    | TZTimeOnlySS  of Offset:TZOffset * Hours:int * Minutes:int * Seconds:int





[<AbstractClass;Sealed>]
type MakeTZOffset private () =
    static member Make (dir:byte) = 
        match dir with 
        | 90uy  ->  TZOffset.UTC    // match 'Z'
        | _     ->  failwithf "invalid TZOffset %c" (System.Convert.ToChar dir)

    static member Make (dir:byte, hh:int) = 
                    let valid = hh > 0 && hh <= 12 
                    match dir, valid with
                    | 43uy, true    ->  PosOffsetHH hh // +
                    | 45uy, true    ->  NegOffsetHH hh // -
                    | _,    _       ->  failwithf "invalid TZOffset, %c-%d" (System.Convert.ToChar dir) hh
    static member Make (dir:byte, hh:int, mm:int) = 
                    let valid = hh > 0 && hh <= 12 && mm >= 0 && mm < 60
                    match dir, valid with
                    | 43uy,  true   ->  PosOffsetHHmm ( hh, mm) // +
                    | 45uy,  true   ->  NegOffsetHHmm ( hh, mm) // -
                    | _,    _       ->  failwithf "invalid TZOffset, %c-%d:%d" (System.Convert.ToChar dir) hh mm



let private validateHH (bs:byte[]) (pos:int) =
    let lenOK = bs.Length > pos + 2
    if not (lenOK) then
        failwith "invalid TZOffset" // todo, check for non-int bytes. Not an issue for FIX4.4, which does not use TZOffset. used for FIX5.0+

let private validateHHmm (bs:byte[]) (pos:int) =
    let lenOK = bs.Length > pos + 5
    if not (lenOK) then
        failwith "invalid TZOffset" // todo, check for non-int bytes. Not an issue for FIX4.4, which does not use TZOffset. used for FIX5.0+


let private readNonUTC (isPositiveOffset:bool) (bs:byte[]) (pos:int) =
    let isHHmm = bs.Length > (pos+3) && bs.[pos+3] = 58uy // if there is a ':' 3 chars hence
    if isHHmm then
        validateHHmm bs pos
        let hh, mm = FIXDateTime.readHHMMints bs (pos+1)
        match isPositiveOffset with
        | true  -> pos+6, MakeTZOffset.Make (43uy, hh, mm)
        | false -> pos+6, MakeTZOffset.Make (45uy, hh, mm)
    else
        // is an hour only offset (no minutes component)
        validateHH bs pos
        let hhD1 = bs.[pos+1] - 48uy |> int
        let hhD2 = bs.[pos+2] - 48uy |> int
        let hh = hhD1 * 10 + hhD2
        match isPositiveOffset with
        | true  -> pos+3, MakeTZOffset.Make (43uy, hh)
        | false -> pos+3, MakeTZOffset.Make (45uy, hh)
        

let readTZOffset (bs:byte[]) (pos:int) =
    let nextFieldSepOrEnd = FIXBuf.findNextFieldTermOrEnd bs pos
    if bs.[pos] = 90uy then // next byte is a 'Z', meaning UTC offset
        (pos+1), TZOffset.UTC
    elif bs.[pos] = 43uy then // positive offset
        readNonUTC true bs pos
    elif bs.[pos] = 45uy then // negative offset
        readNonUTC false bs pos
    else
        failwithf "invalid TZOffset starting at pos: %d" pos



let writeTZOffset (bs:byte[]) (pos:int) (offSet:TZOffset) : int =
    match offSet with 
    | UTC                       ->  bs.[pos] <- 90uy; (pos + 1)     // write Z
    | PosOffsetHH hh            ->  bs.[pos] <- 43uy                // write +
                                    FIXDateTime.write2ByteInt bs (pos+1) hh
                                    (pos + 3)
    | NegOffsetHH hh            ->  bs.[pos] <- 45uy                // write -
                                    FIXDateTime.write2ByteInt bs (pos+1) hh
                                    (pos + 3)
    | NegOffsetHHmm (hh, mm)    ->  bs.[pos] <- 45uy
                                    FIXDateTime.write2ByteInt bs (pos+1) hh
                                    bs.[pos+3] <- 58uy
                                    FIXDateTime.write2ByteInt bs (pos+4) mm
                                    (pos + 6)
    | PosOffsetHHmm (hh, mm)    ->  bs.[pos] <- 43uy
                                    FIXDateTime.write2ByteInt bs (pos+1) hh
                                    bs.[pos+3] <- 58uy
                                    FIXDateTime.write2ByteInt bs (pos+4) mm
                                    (pos + 6)



// no leapsecond support according to http://www.fixtradingcommunity.org/FIXimate/FIXimate3.0/en/FIX.5.0SP2/fix_datatypes.html
[<AbstractClass;Sealed>]
type MakeTZTimeOnly private () =
    static member Make (offset:TZOffset, hh:int, mm:int) =
        let valid = hh >= 0 && hh <= 23 && mm >= 0 && mm <= 59
        match valid with
        | true  -> TZTimeOnly (offset, hh, mm)
        | false -> failwithf "invalid TZTimeOnly, %d:%d" hh mm
                   
    static member Make (offset:TZOffset, hh:int, mm:int, ss:int) =
        let valid = hh >= 0 && hh <= 23 && mm >= 0 && mm <= 59 && ss >= 0 && ss <= 59
        match valid with
        | true  -> TZTimeOnlySS (offset, hh, mm, ss)
        | false -> failwithf "invalid TZTimeOnly, %d:%d:%d" hh mm ss
                   


let inline private isOffsetMarker (bb:byte) = 
    match bb with 
    | 90uy | 43uy | 45uy    -> true
    | _                     -> false


// throw if not found
// only look 5 and 8 bytes ahead, TZ is either hh:mm or hh:mm:ss
let inline private findOffsetMarker (bs:byte[]) (pos:int) =
    if bs.[pos+5] |> isOffsetMarker then
        5
    elif bs.[pos+8] |> isOffsetMarker then
        8
    else
        failwith "could not find offset market in TZTimeOnly"


let readTZTimeOnly (bs:byte[]) (pos:int) (len:int) =
    let offSetMarkerPos = findOffsetMarker bs pos
    match offSetMarkerPos with 
    | 5 ->  let hh, mm = FIXDateTime.readHHMMints bs pos
            let posOut, offset = readTZOffset bs (pos+5)
            MakeTZTimeOnly.Make (offset, hh, mm)
    | 8 ->  let hh, mm, ss = FIXDateTime.readHHMMSSints bs pos
            let posOut, offset = readTZOffset bs (pos+8)
            MakeTZTimeOnly.Make (offset, hh, mm, ss)
    | n ->  failwithf "invalid offset marker reading TZTimeOnly: %d" n


let writeTZTimeOnly (bs:byte[]) (pos:int) (tm:TZTimeOnly) : int =
    match tm with 
    | TZTimeOnly    (offset, hh, mm)    ->
        write2ByteInt bs pos hh
        bs.[pos + 2] <- 58uy // write the ':'
        write2ByteInt bs (pos+3) mm
        writeTZOffset bs (pos+5) offset
    | TZTimeOnlySS  (offset, hh, mm, ss) -> 
        write2ByteInt bs pos hh
        bs.[pos + 2] <- 58uy // write the ':'
        write2ByteInt bs (pos+3) mm
        bs.[pos + 5] <- 58uy // write the ':'
        write2ByteInt bs (pos+6) ss
        writeTZOffset bs (pos+8) offset



