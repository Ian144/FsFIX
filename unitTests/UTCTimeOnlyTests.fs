module UTCTimeOnlyTests

open Xunit
open Swensen.Unquote


open Fix44.FieldReadFuncs



[<Fact>]
let ``read valid hhmmss from bytes`` () =
    let uto = FIXDateTime.fromBytes "23:59:59"B 0
    let expected = FIXDateTime.MakeUTCTimeOnly.Make (23, 59, 59)
    expected =| uto
    