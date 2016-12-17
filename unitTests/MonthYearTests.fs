module MonthYearTests

open Xunit
open Swensen.Unquote





[<Fact>]
let ``make invalid MonthYear bad day`` () =
    try
        let bs = [| yield! "201612AB"B; yield 1uy  |] // MonthYear.read  requires a FIX field separator
        let offset = MonthYear.read bs 0
        false
    with
    |   ex -> true


[<Fact>]
let ``make invalid MonthYear bad day2`` () =
    try
        let bs = [| yield! "201612"B; yield 0uy; yield 0uy; yield 1uy |] // MonthYear.read  requires a FIX field separator
        let offset = MonthYear.read bs 0
        false
    with
    |   ex -> true



[<Fact>]
let ``make invalid MonthYear bad month`` () =
    try
        let bs = [| yield! "2016"B; yield 0uy; yield 0uy; yield! "31"B; yield 1uy |] // MonthYear.read  requires a FIX field separator
        let offset = MonthYear.read bs 0
        false
    with
    |   ex -> true


[<Fact>]
let ``make invalid MonthYear bad year`` () =
    try
        let bs = [| yield! "201A1231"B; yield 1uy |] // MonthYear.read  requires a FIX field separator
        let offset = MonthYear.read bs 0
        false
    with
    |   ex -> 
            true