module FieldRead.Tests


open Xunit

open Fix44.Fields
open Fix44.FieldReadWriteFuncs
open Swensen.Unquote


[<Fact>]
let ``read single case DU`` () =
    let input = [| yield! "1=AccountStr"B; yield 1uy |]
    let pos = 2 // the tag and the the tag value separator have been read
    let posOut, fld = ReadAccount pos input
    test<@ input.Length = posOut @>
    test<@ (Account.Account "AccountStr") = fld @>


[<Fact>]
let ``read multicase DU case Buy`` () =
    let input = [| yield! "3=B"B; yield 1uy |]
    let pos = 2 // the tag and the the tag value separator have been read
    let posOut, fld = ReadAdvSide pos input
    test<@ input.Length = posOut @>
    test<@ AdvSide.Buy = fld @>


[<Fact>]
let ``read multicase DU case 1`` () =
    let input = [| yield! "3=S"B; yield 1uy |]
    let pos = 2 // the tag and the the tag value separator have been read
    let posOut, fld = ReadAdvSide pos input
    test<@ input.Length = posOut @>
    test<@ AdvSide.Sell = fld @>


[<Fact>]
let ``read multicase DU case Cross`` () =
    let input = [| yield! "3=X"B; yield 1uy |]
    let pos = 2 // the tag and the the tag value separator have been read
    let posOut, fld = ReadAdvSide pos input
    test<@ input.Length = posOut @>
    test<@ AdvSide.Cross = fld @>


[<Fact>]
let ``read multicase DU case Trade`` () =
    let input = [| yield! "3=T"B; yield 1uy |]
    let pos = 2 // the tag and the the tag value separator have been read
    let posOut, fld = ReadAdvSide pos input
    test<@ input.Length = posOut @>
    test<@ AdvSide.Trade = fld @>


[<Fact>]
let ``read multicase DU case invalid`` () =
    let input = [| yield! "3=TT"B; yield 1uy |]
    let pos = 2 // the tag and the the tag value separator have been read
    try
        ReadAdvSide pos input |> ignore
    with
        | ex -> test<@ "ReadAdvSide unknown fix tag: [|84uy; 84uy|]" = ex.Message @>



[<Fact>]
let ``read len+str pair`` () =
    let input = [|  yield! "90=8"B; yield 1uy           // SecureDataLen
                    yield! "91=ABCDEFGH"B; yield 1uy|]  // SecureData, that has not been encrypted
    let pos = 2 // the tag and the the tag value separator have been read
    let posOut, fld = ReadSecureData pos input
    test<@ input.Length = posOut @>
    test<@ (SecureData.SecureData "ABCDEFGH") = fld @>



    test<@ false @>

[<Fact>]
let ``read len+str pair, containing a field seperator in the string`` () =
    test<@ false @>

[<Fact>]
let ``read len+str pair, containing a tag-value seperator in the string`` () =
    test<@ false @>

[<Fact>]
let ``read RawDataLength`` () = 
    test<@ false @>

[<Fact>]
let ``read RawDataLength + RawData pair, containing a field seperator in the string`` () = 
    test<@ false @>

[<Fact>]
let ``read RawDataLength + RawData pair, containing a tag-value seperator in the string`` () =
    test<@ false @>