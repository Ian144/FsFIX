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
 
module TZOffsetUnitTests

open Xunit
open Swensen.Unquote


[<Fact>]
let ``read UTC offset from bytes`` () =

    let outPos, offset = TZDateTime.readTZOffset "Z"B 0
    let expected = TZDateTime.MakeTZOffset.Make 90uy
    expected =! offset
    1 =! outPos

[<Fact>]
let ``read pos HH offset from bytes`` () =
    let posOut, offset = TZDateTime.readTZOffset "+01"B 0
    let expected = TZDateTime.MakeTZOffset.Make (43uy, 1)
    expected =! offset


[<Fact>]
let ``read invalid pos HH offset from bytes`` () =
    try
        TZDateTime.readTZOffset "+1"B 0   |> ignore
        false
    with
    | _ -> true

[<Fact>]
let ``read invalid pos HH offset from bytes 2`` () =
    try
        TZDateTime.readTZOffset "+13"B 0   |> ignore
        false
    with
    | _ -> true



[<Fact>]
let ``read pos HHmm offset from bytes`` () =
    let posOut, offset = TZDateTime.readTZOffset "+01:30"B 0
    let expected = TZDateTime.MakeTZOffset.Make (43uy, 1, 30)
    expected =! offset


[<Fact>]
let ``read invalid pos HHmm offset from bytes`` () =
    try
        TZDateTime.readTZOffset "+01:6"B 0   |> ignore
        false
    with
    | _ -> true

[<Fact>]
let ``read invalid pos HHmm offset from bytes 2`` () =
    try
        TZDateTime.readTZOffset "+01:60"B 0   |> ignore
        false
    with
    | _ -> true



[<Fact>]
let ``write UTC TZOffset to bytes`` () =
    let offset = TZDateTime.MakeTZOffset.Make 90uy
    let expected = "Z"B
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = TZDateTime.writeTZOffset bs 0 offset
    expected.Length =! posOut
    expected =! bs



[<Fact>]
let ``write pos hh TZOffset to bytes`` () =
    let offset = TZDateTime.MakeTZOffset.Make (43uy, 12)
    let expected = "+12"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = TZDateTime.writeTZOffset bs 0 offset
    expected.Length =! posOut
    expected =! bs


[<Fact>]
let ``write pos hh TZOffset to bytes2`` () =
    let offset = TZDateTime.MakeTZOffset.Make (43uy, 1)
    let expected = "+01"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = TZDateTime.writeTZOffset bs 0 offset
    expected.Length =! posOut
    expected =! bs


[<Fact>]
let ``write pos HHmm TZOffset to bytes`` () =
    let offset = TZDateTime.MakeTZOffset.Make (43uy, 1, 59)
    let expected = "+01:59"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = TZDateTime.writeTZOffset bs 0 offset
    expected =! bs
    expected.Length =! posOut


[<Fact>]
let ``write pos HHmm TZOffset to bytes 2`` () =
    let offset = TZDateTime.MakeTZOffset.Make (43uy, 1, 00)
    let expected = "+01:00"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = TZDateTime.writeTZOffset bs 0 offset
    expected =! bs
    expected.Length =! posOut



[<Fact>]
let ``write neg HH TZOffset to bytes`` () =
    let offset = TZDateTime.MakeTZOffset.Make (45uy, 12)
    let expected = "-12"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = TZDateTime.writeTZOffset bs 0 offset
    expected.Length =! posOut
    expected =! bs


[<Fact>]
let ``write neg HH TZOffset to bytes2`` () =
    let offset = TZDateTime.MakeTZOffset.Make (45uy, 1)
    let expected = "-01"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = TZDateTime.writeTZOffset bs 0 offset
    expected.Length =! posOut
    expected =! bs


[<Fact>]
let ``write neg HHmm TZOffset to bytes`` () =
    let offset = TZDateTime.MakeTZOffset.Make (45uy, 1, 59)
    let expected = "-01:59"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = TZDateTime.writeTZOffset bs 0 offset
    expected =! bs
    expected.Length =! posOut


[<Fact>]
let ``write neg HHmm TZOffset to bytes 2`` () =
    let offset = TZDateTime.MakeTZOffset.Make (45uy, 1, 00)
    let expected = "-01:00"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = TZDateTime.writeTZOffset bs 0 offset
    expected =! bs
    expected.Length =! posOut


[<Fact>]
let ``make invalid UTC offset`` () =
    try
        TZDateTime.MakeTZOffset.Make 91uy |> ignore // 90uy is not 'Z'
        false
    with
    |   ex -> true



[<Fact>]
let ``make invalid neg offset hours`` () =
    try
        let offset = TZDateTime.MakeTZOffset.Make (45uy, 0) // 0 hours is not allowed
        false
    with
    |   ex -> true


[<Fact>]
let ``make invalid neg offset hours 2`` () =
    try
        let offset = TZDateTime.MakeTZOffset.Make (45uy, 13) // 13 hours is not allowed
        false
    with
    |   ex -> true



[<Fact>]
let ``make invalid pos offset hours`` () =
    try
        let offset = TZDateTime.MakeTZOffset.Make (43uy, 0) // 0 hours is not allowed
        false
    with
    |   ex -> true



[<Fact>]
let ``make invalid pos offset hours 2`` () =
    try
        let offset = TZDateTime.MakeTZOffset.Make (43uy, 13) // 13 hours is not allowed
        false
    with
    |   ex -> true



[<Fact>]
let ``make invalid pos offset mins`` () =
    try
        let offset = TZDateTime.MakeTZOffset.Make (43uy, 1, -1) // -1 mins is not allowed
        false
    with
    |   ex -> true


[<Fact>]
let ``make invalid neg offset mins`` () =
    try
        let offset = TZDateTime.MakeTZOffset.Make (45uy, 1, -1) // -1 mins is not allowed
        false
    with
    |   ex -> true


[<Fact>]
let ``make invalid pos offset mins 2`` () =
    try
        let offset = TZDateTime.MakeTZOffset.Make (43uy, 1, 60) // 60 mins is not allowed
        false
    with
    |   ex -> true


[<Fact>]
let ``make invalid neg offset mins 2`` () =
    try
        let offset = TZDateTime.MakeTZOffset.Make (45uy, 1, 60) // 60 mins is not allowed
        false
    with
    |   ex -> true









