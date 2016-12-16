module TZTimeOnlyTests

open Xunit
open Swensen.Unquote



[<Fact>]
let ``write UTC TZOffset to bytes`` () =
    let timeIn = FIXDateTime.MakeTZOffset.Make 90uy
    let expected = "Z"B
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 timeIn
    expected.Length =! posOut
    expected =! bs



[<Fact>]
let ``write +hh TZOffset to bytes`` () =
    let timeIn = FIXDateTime.MakeTZOffset.Make (43uy, 12)
    let expected = "+12"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 timeIn
    expected.Length =! posOut
    expected =! bs


[<Fact>]
let ``write +hh TZOffset to bytes2`` () =
    let timeIn = FIXDateTime.MakeTZOffset.Make (43uy, 1)
    let expected = "+01"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 timeIn
    expected.Length =! posOut
    expected =! bs


[<Fact>]
let ``write +HHmm TZOffset to bytes`` () =
    let timeIn = FIXDateTime.MakeTZOffset.Make (43uy, 1, 59)
    let expected = "+01:59"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 timeIn
    expected =! bs
    expected.Length =! posOut


[<Fact>]
let ``write +HHmm TZOffset to bytes 2`` () =
    let timeIn = FIXDateTime.MakeTZOffset.Make (43uy, 1, 00)
    let expected = "+01:00"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 timeIn
    expected =! bs
    expected.Length =! posOut



[<Fact>]
let ``write -hh TZOffset to bytes`` () =
    let timeIn = FIXDateTime.MakeTZOffset.Make (45uy, 12)
    let expected = "-12"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 timeIn
    expected.Length =! posOut
    expected =! bs


[<Fact>]
let ``write -hh TZOffset to bytes2`` () =
    let timeIn = FIXDateTime.MakeTZOffset.Make (45uy, 1)
    let expected = "-01"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 timeIn
    expected.Length =! posOut
    expected =! bs


[<Fact>]
let ``write -HHmm TZOffset to bytes`` () =
    let timeIn = FIXDateTime.MakeTZOffset.Make (45uy, 1, 59)
    let expected = "-01:59"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 timeIn
    expected =! bs
    expected.Length =! posOut


[<Fact>]
let ``write -HHmm TZOffset to bytes 2`` () =
    let timeIn = FIXDateTime.MakeTZOffset.Make (45uy, 1, 00)
    let expected = "-01:00"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 timeIn
    expected =! bs
    expected.Length =! posOut



[<Fact>]
let ``read invalid UTC offset from bytes`` () =
    try
        FIXDateTime.MakeTZOffset.Make 91uy |> ignore // 90uy is not 'Z'
        false
    with
    |   ex -> true



[<Fact>]
let ``read invalid pos offset hours from bytes`` () =
    try
        let timeIn = FIXDateTime.MakeTZOffset.Make (43uy, 0) // 0 hours is not allowed
        false
    with
    |   ex -> true


[<Fact>]
let ``read invalid neg offset hours from bytes`` () =
    try
        let timeIn = FIXDateTime.MakeTZOffset.Make (45uy, 0) // 0 hours is not allowed
        false
    with
    |   ex -> true




[<Fact>]
let ``read invalid pos offset hours from bytes 2`` () =
    try
        let timeIn = FIXDateTime.MakeTZOffset.Make (43uy, 13) // 13 hours is not allowed
        false
    with
    |   ex -> true


[<Fact>]
let ``read invalid neg offset hours from bytes 2`` () =
    try
        let timeIn = FIXDateTime.MakeTZOffset.Make (45uy, 13) // 13 hours is not allowed
        false
    with
    |   ex -> true





[<Fact>]
let ``read invalid pos offset mins from bytes`` () =
    try
        let timeIn = FIXDateTime.MakeTZOffset.Make (43uy, 1, -1) // -1 mins is not allowed
        false
    with
    |   ex -> true


[<Fact>]
let ``read invalid neg offset mins from bytes`` () =
    try
        let timeIn = FIXDateTime.MakeTZOffset.Make (45uy, 1, -1) // -1 mins is not allowed
        false
    with
    |   ex -> true




[<Fact>]
let ``read invalid pos offset mins from bytes 2`` () =
    try
        let timeIn = FIXDateTime.MakeTZOffset.Make (43uy, 1, 60) // 60 mins is not allowed
        false
    with
    |   ex -> true


[<Fact>]
let ``read invalid neg offset mins from bytes 2`` () =
    try
        let timeIn = FIXDateTime.MakeTZOffset.Make (45uy, 1, 60) // 60 mins is not allowed
        false
    with
    |   ex -> true









