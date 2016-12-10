module UTCTimeOnlyTests

open Xunit
open Swensen.Unquote



[<Fact>]
let ``write valid hhmmss from bytes`` () =
    let timeIn = FIXDateTime.MakeUTCTimeOnly.Make (23, 59, 59)
    let bs = Array.zeroCreate<byte> 8
    let posOut = FIXDateTime.writeBytes timeIn bs 0
    let expected = "23:59:59"B
    posOut =! 8
    expected =! bs

[<Fact>]
let ``write valid hhmmssNNN from bytes`` () =
    let timeIn = FIXDateTime.MakeUTCTimeOnly.Make (23, 59, 59, 123)
    let bs = Array.zeroCreate<byte> 12
    let posOut = FIXDateTime.writeBytes timeIn bs 0
    let expected = "23:59:59.123"B
    posOut =! 12
    expected =! bs


[<Fact>]
let ``read valid hhmmss from bytes`` () =
    let uto = FIXDateTime.fromBytes "23:59:59"B 0 8
    let expected = FIXDateTime.MakeUTCTimeOnly.Make (23, 59, 59)
    expected =! uto



[<Fact>]
let ``read valid hhmmss midnight from bytes`` () =
    let uto = FIXDateTime.fromBytes "00:00:00"B 0 8
    let expected = FIXDateTime.MakeUTCTimeOnly.Make (00, 00, 00)
    expected =! uto


[<Fact>]
let ``read valid leapsecond hhmmss from bytes`` () =
    let uto = FIXDateTime.fromBytes "23:59:60"B 0 8
    let expected = FIXDateTime.MakeUTCTimeOnly.Make (23, 59, 60)
    expected =! uto


[<Fact>]
let ``read valid leapsecond hhmmssMMM from bytes`` () =
    let bs = "23:59:60.999"B
    let uto = FIXDateTime.fromBytes bs  0 bs.Length
    let expected = FIXDateTime.MakeUTCTimeOnly.Make (23, 59, 60, 999)
    expected =! uto



[<Fact>]
let ``read invalid leapsecond hhmmssMMM from bytes`` () =
    try
        let bs = "23:58:60.999"B // leapseconds only occur in the last minute of the day
        let uto = FIXDateTime.fromBytes bs  0 bs.Length
        false // FIXDateTime.fromBytes should throw
    with
    | ex -> true