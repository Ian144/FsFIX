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
 

module MonthYearUnitTests

open Xunit
open Swensen.Unquote



[<Fact>]
let ``make invalid MonthYear bad day`` () =
    let bs = [| yield! "201612AB"B; yield 1uy  |] // MonthYear.read  requires a FIX field separator
    let len = bs.Length - 1
    raisesWith<System.Exception> <@ MonthYear.read bs 0 len@> (fun e -> <@ e.Message = "invalid MonthYear: 201612AB" @>)



[<Fact>]
let ``make invalid MonthYear bad day2`` () =
    let bs = [| yield! "201612"B; yield 0uy; yield 0uy; yield 1uy |] // MonthYear.read  requires a FIX field separator
    let len = bs.Length - 1
    raisesWith<System.Exception> <@ MonthYear.read bs 0 len@> (fun e -> <@ e.Message.Contains "invalid MonthYear" @>)



[<Fact>]
let ``make invalid MonthYear bad month`` () =
    let bs = [| yield! "2016"B; yield 0uy; yield 0uy; yield! "31"B; yield 1uy |] // MonthYear.read  requires a FIX field separator
    let len = bs.Length - 1
    raisesWith<System.Exception> <@ MonthYear.read bs 0 len@> (fun e -> <@ e.Message.Contains "invalid MonthYear" @>)


[<Fact>]
let ``make invalid MonthYear bad month 2`` () =
    let bs = [| yield! "201600"B; yield 1uy |] // MonthYear.read  requires a FIX field separator
    let len = bs.Length - 1
    raisesWith<System.Exception> <@ MonthYear.read bs 0 len@> (fun e -> <@ e.Message = "invalid MonthYear: 2016-0" @>)


//[<Fact>]
let ``make invalid MonthYear bad year`` () =
    let bs = [| yield! "201A1231"B; yield 1uy |] // MonthYear.read  requires a FIX field separator
    let len = bs.Length - 1
    raisesWith<System.Exception> <@ MonthYear.read bs 0 len@> (fun e -> <@ e.Message = "invalid MonthYear: 201A1231" @>)