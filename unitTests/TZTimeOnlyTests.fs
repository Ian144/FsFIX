module TZTimeOnlyTests

open Xunit
open Swensen.Unquote


[<Fact>]
let ``read UTC hh:mm `` () =
    let bs = "03:00Z"B
    let outPos, tm = TZDateTime.readTZTimeOnly bs 0
    let offset = TZDateTime.MakeTZOffset.Make 90uy // 90uy is Z
    let expected = TZDateTime.MakeTZTimeOnly.Make (offset, 3, 0)
    expected =! tm
    bs.Length =! outPos


[<Fact>]
let ``read UTC hh:mm:ss `` () =
    let bs = "03:00:00Z"B
    let outPos, tm = TZDateTime.readTZTimeOnly bs 0
    let offset = TZDateTime.MakeTZOffset.Make 90uy // 90uy is Z
    let expected = TZDateTime.MakeTZTimeOnly.Make (offset, 3, 0, 0)
    expected =! tm
    bs.Length =! outPos



[<Fact>]
let ``read invalid offset marker from bytes`` () =
    try
        TZDateTime.readTZTimeOnly "03:03*06"B 0   |> ignore
        false
    with
    | _ -> true



[<Fact>]
let ``read invalid hours from bytes`` () =
    try
        TZDateTime.readTZTimeOnly "25:00Z06"B 0   |> ignore
        false
    with
    | _ -> true


[<Fact>]
let ``read invalid mins from bytes`` () =
    try
        TZDateTime.readTZTimeOnly "00:60Z06"B 0   |> ignore
        false
    with
    | _ -> true