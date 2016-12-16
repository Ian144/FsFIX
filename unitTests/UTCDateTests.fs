module UTCDateTests

open Xunit
open Swensen.Unquote



[<Fact>]
let ``write valid yyyyddmm to bytes`` () =
    let xIn = UTCDateTimex.MakeUTCDate (1999, 12, 31)
    let bs = Array.zeroCreate<byte> 8
    let posOut = UTCDateTimex.writeUTCDate xIn bs 0
    let expected = "19991231"B
    posOut =! 8
    expected =! bs


[<Fact>]
let ``read valid hhmmss from bytes`` () =
    let dt = UTCDateTimex.readUTCDate "19991231"B 0 8
    let expected = UTCDateTimex.MakeUTCDate (1999, 12, 31)
    expected =! dt


[<Fact>]
let ``make invalid year UTCDate`` () =
    try
        UTCDateTimex.MakeUTCDate (99999, 12, 31) |> ignore
        false // MakeUTCDate should throw
    with
    |   ex -> true


[<Fact>]
let ``make invalid month UTCDate`` () =
    try
        UTCDateTimex.MakeUTCDate (2016, 13, 31) |> ignore
        false // MakeUTCDate should throw
    with
    |   ex -> true


[<Fact>]
let ``make invalid month 2 UTCDate`` () =
    try
        UTCDateTimex.MakeUTCDate (2016, 0, 31) |> ignore
        false // MakeUTCDate should throw
    with
    |   ex -> true


[<Fact>]
let ``make invalid day UTCDate`` () =
    try
        UTCDateTimex.MakeUTCDate (2016, 01, 32) |> ignore
        false // MakeUTCDate should throw
    with
    |   ex -> true


[<Fact>]
let ``make invalid day 2 UTCDate`` () =
    try
        UTCDateTimex.MakeUTCDate (2016, 01, 0) |> ignore
        false // MakeUTCDate should throw
    with
    |   ex -> true








