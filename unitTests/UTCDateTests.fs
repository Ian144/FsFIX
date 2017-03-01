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
 
module UTCDateUnitTests

open Xunit
open Swensen.Unquote



[<Fact>]
let ``write valid yyyyddmm to bytes`` () =
    let xIn = UTCDateTime.MakeUTCDate (1999, 12, 31)
    let bs = Array.zeroCreate<byte> 8
    let posOut = UTCDateTime.writeUTCDate xIn bs 0
    let expected = "19991231"B
    posOut =! 8
    expected =! bs


[<Fact>]
let ``read valid hhmmss from bytes`` () =
    let dt = UTCDateTime.readUTCDate "19991231"B 0 8
    let expected = UTCDateTime.MakeUTCDate (1999, 12, 31)
    expected =! dt


[<Fact>]
let ``make invalid year UTCDate`` () =
    try
        UTCDateTime.MakeUTCDate (99999, 12, 31) |> ignore
        Xunit.Assert.True false // MakeUTCDate should throw
    with
    |   ex -> () // todo replace with unquote raiseWith 


[<Fact>]
let ``make invalid month UTCDate`` () =
    try
        UTCDateTime.MakeUTCDate (2016, 13, 31) |> ignore
        Xunit.Assert.True false // MakeUTCDate should throw
    with
    |   ex -> () // todo replace with unquote raiseWith


[<Fact>]
let ``make invalid month 2 UTCDate`` () =
    try
        UTCDateTime.MakeUTCDate (2016, 0, 31) |> ignore
        Xunit.Assert.True false // MakeUTCDate should throw
    with
    |   ex -> () // todo replace with unquote raiseWith


[<Fact>]
let ``make invalid day UTCDate`` () =
    try
        UTCDateTime.MakeUTCDate (2016, 01, 32) |> ignore
        Xunit.Assert.True false // MakeUTCDate should throw
    with
    |   ex -> () // todo replace with unquote raiseWith


[<Fact>]
let ``make invalid day 2 UTCDate`` () =
    try
        UTCDateTime.MakeUTCDate (2016, 01, 0) |> ignore
        Xunit.Assert.True false // MakeUTCDate should throw
    with
    |   ex -> () // todo replace with unquote raiseWith








