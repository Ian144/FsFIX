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
 
module TZTimeOnlyTests

open Xunit
open Swensen.Unquote


[<Fact>]
let ``read UTC hh:mm `` () =
    let bs = "03:00Z"B
    let tm = TZDateTime.readTZTimeOnly bs 0 bs.Length
    let offset = TZDateTime.MakeTZOffset.Make 90uy // 90uy is Z
    let expected = TZDateTime.MakeTZTimeOnly.Make (offset, 3, 0)
    expected =! tm


[<Fact>]
let ``read UTC hh:mm:ss `` () =
    let bs = "03:00:00Z"B
    let tm = TZDateTime.readTZTimeOnly bs 0 bs.Length
    let offset = TZDateTime.MakeTZOffset.Make 90uy // 90uy is Z
    let expected = TZDateTime.MakeTZTimeOnly.Make (offset, 3, 0, 0)
    expected =! tm


[<Fact>]
let ``read invalid offset marker from bytes`` () =
    try
        let bs = "03:03*06"B
        TZDateTime.readTZTimeOnly bs 0 bs.Length  |> ignore
        Xunit.Assert.True false
    with
    | _ -> () // todo replace with unquote raiseWith



[<Fact>]
let ``read invalid hours from bytes`` () =
    try
        let bs = "25:00Z06"B
        TZDateTime.readTZTimeOnly bs 0 bs.Length |> ignore
        Xunit.Assert.True false
    with
    | _ -> () // todo replace with unquote raiseWith


[<Fact>]
let ``read invalid mins from bytes`` () =
    try
        let bs = "00:60Z06"B
        TZDateTime.readTZTimeOnly bs 0 bs.Length |> ignore
        Xunit.Assert.True false
    with
    | _ -> () // todo replace with unquote raiseWith