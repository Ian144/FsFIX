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
 
module UTCTimeOnlyUnitTests

open Xunit
open Swensen.Unquote



[<Fact>]
let ``write valid hhmmss to bytes`` () =
    let timeIn = UTCDateTime.MakeUTCTimeOnly.Make (23, 59, 59)
    let bs = Array.zeroCreate<byte> 8
    let posOut = UTCDateTime.writeUTCTimeOnly timeIn bs 0
    let expected = "23:59:59"B
    posOut =! 8
    expected =! bs


[<Fact>]
let ``write valid hhmmssNNN to bytes`` () =
    let timeIn = UTCDateTime.MakeUTCTimeOnly.Make (23, 59, 59, 123)
    let bs = Array.zeroCreate<byte> 12
    let posOut = UTCDateTime.writeUTCTimeOnly timeIn bs 0
    let expected = "23:59:59.123"B
    posOut =! 12
    expected =! bs


[<Fact>]
let ``read valid hhmmss from bytes`` () =
    let uto = UTCDateTime.readUTCTimeOnly "23:59:59"B 0 8
    let expected = UTCDateTime.MakeUTCTimeOnly.Make (23, 59, 59)
    expected =! uto



[<Fact>]
let ``read valid hhmmss midnight from bytes`` () =
    let uto = UTCDateTime.readUTCTimeOnly "00:00:00"B 0 8
    let expected = UTCDateTime.MakeUTCTimeOnly.Make (00, 00, 00)
    expected =! uto


[<Fact>]
let ``read valid leapsecond hhmmss from bytes`` () =
    let uto = UTCDateTime.readUTCTimeOnly "23:59:60"B 0 8
    let expected = UTCDateTime.MakeUTCTimeOnly.Make (23, 59, 60)
    expected =! uto


[<Fact>]
let ``read valid leapsecond hhmmssMMM from bytes`` () =
    let bs = "23:59:60.999"B
    let uto = UTCDateTime.readUTCTimeOnly bs  0 bs.Length
    let expected = UTCDateTime.MakeUTCTimeOnly.Make (23, 59, 60, 999)
    expected =! uto



[<Fact>]
let ``read invalid leapsecond hhmmssMMM from bytes`` () =
    let bs = "23:58:60.999"B // leapseconds only occur in the last minute of the day
    raisesWith<System.Exception> <@ UTCDateTime.readUTCTimeOnly bs  0 bs.Length @> (fun e -> <@ e.Message = "invalid UTCTimeOnly" @>)
