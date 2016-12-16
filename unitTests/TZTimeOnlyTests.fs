module TZTimeOnlyTests

open Xunit
open Swensen.Unquote


[<Fact>]
let ``read UTC offset from bytes`` () =

    let outPos, offset = FIXDateTime.readTZOffset "Z"B 0
    let expected = FIXDateTime.MakeTZOffset.Make 90uy
    expected =! offset
    1 =! outPos

[<Fact>]
let ``read +HH offset from bytes`` () =
    let posOut, offset = FIXDateTime.readTZOffset "+01"B 0
    let expected = FIXDateTime.MakeTZOffset.Make (43uy, 1)
    expected =! offset


[<Fact>]
let ``read invalid +HH offset from bytes`` () =
    try
        FIXDateTime.readTZOffset "+1"B 0   |> ignore
        false
    with
    | _ -> true

[<Fact>]
let ``read invalid +HH offset from bytes 2`` () =
    try
        FIXDateTime.readTZOffset "+13"B 0   |> ignore
        false
    with
    | _ -> true




[<Fact>]
let ``read +HHmm offset from bytes`` () =
    let posOut, offset = FIXDateTime.readTZOffset "+01:30"B 0
    let expected = FIXDateTime.MakeTZOffset.Make (43uy, 1, 30)
    expected =! offset


[<Fact>]
let ``read invalid +HHmm offset from bytes`` () =
    try
        FIXDateTime.readTZOffset "+01:6"B 0   |> ignore
        false
    with
    | _ -> true

[<Fact>]
let ``read invalid +HHmm offset from bytes 2`` () =
    try
        FIXDateTime.readTZOffset "+01:60"B 0   |> ignore
        false
    with
    | _ -> true






[<Fact>]
let ``write UTC TZOffset to bytes`` () =
    let offset = FIXDateTime.MakeTZOffset.Make 90uy
    let expected = "Z"B
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 offset
    expected.Length =! posOut
    expected =! bs



[<Fact>]
let ``write +hh TZOffset to bytes`` () =
    let offset = FIXDateTime.MakeTZOffset.Make (43uy, 12)
    let expected = "+12"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 offset
    expected.Length =! posOut
    expected =! bs


[<Fact>]
let ``write +hh TZOffset to bytes2`` () =
    let offset = FIXDateTime.MakeTZOffset.Make (43uy, 1)
    let expected = "+01"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 offset
    expected.Length =! posOut
    expected =! bs


[<Fact>]
let ``write +HHmm TZOffset to bytes`` () =
    let offset = FIXDateTime.MakeTZOffset.Make (43uy, 1, 59)
    let expected = "+01:59"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 offset
    expected =! bs
    expected.Length =! posOut


[<Fact>]
let ``write +HHmm TZOffset to bytes 2`` () =
    let offset = FIXDateTime.MakeTZOffset.Make (43uy, 1, 00)
    let expected = "+01:00"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 offset
    expected =! bs
    expected.Length =! posOut



[<Fact>]
let ``write -hh TZOffset to bytes`` () =
    let offset = FIXDateTime.MakeTZOffset.Make (45uy, 12)
    let expected = "-12"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 offset
    expected.Length =! posOut
    expected =! bs


[<Fact>]
let ``write -hh TZOffset to bytes2`` () =
    let offset = FIXDateTime.MakeTZOffset.Make (45uy, 1)
    let expected = "-01"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 offset
    expected.Length =! posOut
    expected =! bs


[<Fact>]
let ``write -HHmm TZOffset to bytes`` () =
    let offset = FIXDateTime.MakeTZOffset.Make (45uy, 1, 59)
    let expected = "-01:59"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 offset
    expected =! bs
    expected.Length =! posOut


[<Fact>]
let ``write -HHmm TZOffset to bytes 2`` () =
    let offset = FIXDateTime.MakeTZOffset.Make (45uy, 1, 00)
    let expected = "-01:00"B    
    let bs = Array.zeroCreate<byte> expected.Length
    let posOut = FIXDateTime.writeTZOffset bs 0 offset
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
        let offset = FIXDateTime.MakeTZOffset.Make (43uy, 0) // 0 hours is not allowed
        false
    with
    |   ex -> true


[<Fact>]
let ``read invalid neg offset hours from bytes`` () =
    try
        let offset = FIXDateTime.MakeTZOffset.Make (45uy, 0) // 0 hours is not allowed
        false
    with
    |   ex -> true




[<Fact>]
let ``read invalid pos offset hours from bytes 2`` () =
    try
        let offset = FIXDateTime.MakeTZOffset.Make (43uy, 13) // 13 hours is not allowed
        false
    with
    |   ex -> true


[<Fact>]
let ``read invalid neg offset hours from bytes 2`` () =
    try
        let offset = FIXDateTime.MakeTZOffset.Make (45uy, 13) // 13 hours is not allowed
        false
    with
    |   ex -> true



[<Fact>]
let ``read invalid pos offset mins from bytes`` () =
    try
        let offset = FIXDateTime.MakeTZOffset.Make (43uy, 1, -1) // -1 mins is not allowed
        false
    with
    |   ex -> true


[<Fact>]
let ``read invalid neg offset mins from bytes`` () =
    try
        let offset = FIXDateTime.MakeTZOffset.Make (45uy, 1, -1) // -1 mins is not allowed
        false
    with
    |   ex -> true




[<Fact>]
let ``read invalid pos offset mins from bytes 2`` () =
    try
        let offset = FIXDateTime.MakeTZOffset.Make (43uy, 1, 60) // 60 mins is not allowed
        false
    with
    |   ex -> true


[<Fact>]
let ``read invalid neg offset mins from bytes 2`` () =
    try
        let offset = FIXDateTime.MakeTZOffset.Make (45uy, 1, 60) // 60 mins is not allowed
        false
    with
    |   ex -> true









