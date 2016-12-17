module TZTimeOnlyTests

open Xunit
open Swensen.Unquote


[<Fact>]
let ``read UTC offset from bytes`` () =

    let outPos, offset = TZDateTime.readTZOffset "Z"B 0
    let expected = TZDateTime.MakeTZOffset.Make 90uy
    expected =! offset
    1 =! outPos


[<Fact>]
let ``read invalid +HH offset from bytes 2`` () =
    try
        TZDateTime.readTZOffset "+13"B 0   |> ignore
        false
    with
    | _ -> true



