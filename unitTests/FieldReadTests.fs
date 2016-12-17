module FieldRead.Tests


open Xunit

open Fix44.Fields
open Fix44.FieldReadFuncs
open Swensen.Unquote


[<Fact>]
let ``read single case DU`` () =
    let input = [| yield! "1=AccountStr"B; yield 1uy |]
    let pos = 2 // the tag and the the tag value separator have been read
    let posOut, fld = ReadAccount input pos 
    input.Length =! posOut
    (Account.Account "AccountStr") =! fld


[<Fact>]
let ``read multicase DU case Buy`` () =
    let input = [| yield! "3=B"B; yield 1uy |]
    let pos = 2 // the tag and the the tag value separator have been read
    let posOut, fld = ReadAdvSide input pos 
    input.Length =! posOut
    AdvSide.Buy =! fld


[<Fact>]
let ``read multicase DU case 1`` () =
    let input = [| yield! "3=S"B; yield 1uy |]
    let pos = 2 // the tag and the the tag value separator have been read
    let posOut, fld = ReadAdvSide input pos 
    input.Length =! posOut
    AdvSide.Sell =! fld


[<Fact>]
let ``read multicase DU case Cross`` () =
    let input = [| yield! "3=X"B; yield 1uy |]
    let pos = 2 // the tag and the the tag value separator have been read
    let posOut, fld = ReadAdvSide input pos 
    input.Length =! posOut
    AdvSide.Cross =! fld


[<Fact>]
let ``read multicase DU case Trade`` () =
    let input = [| yield! "3=T"B; yield 1uy |]
    let pos = 2 // the tag and the the tag value separator have been read
    let posOut, fld = ReadAdvSide input pos 
    input.Length =! posOut
    AdvSide.Trade =! fld


[<Fact>]
let ``read multicase DU case invalid`` () =
    let input = [| yield! "3=TT"B; yield 1uy |]
    let pos = 2 // the tag and the the tag value separator have been read
    try
        ReadAdvSide input pos |> ignore
    with
        | ex -> "ReadAdvSide unknown fix tag: [|84uy; 84uy|]" =! ex.Message



[<Fact>]
let ``read compound len+str pair`` () =
    let input = [|  yield! "90=8"B; yield 1uy           // SecureDataLen, containing the length of the data in SecureData
                    yield! "91=ABCDEFGH"B; yield 1uy|]  // SecureData, that has not been encrypted
    let pos = 3 // the tag and the the tag value separator have been read
    let posOut, fld = ReadSecureData input pos 
    (SecureData.SecureData "ABCDEFGH"B) =! fld
    input.Length =! posOut


[<Fact>]
let ``read compound len+str pair, containing a field seperator in the string`` () =
    let valToRead = [|yield! "ABCD"B; yield 1uy; yield! "EFGH"B; |] // contains a field seperator
    
    let input = [|  yield! "90=9"B; yield 1uy           // SecureDataLen, containing the length of the data in SecureData
                    yield! "91="B; yield! valToRead; yield 1uy |]  // SecureData, that has not been encrypted
    let pos = 3 // the tag and the the tag value separator have been read
    let posOut, fld = ReadSecureData input pos 
    SecureData.SecureData valToRead =! fld
    input.Length =! posOut


[<Fact>]
let ``read compound len+str pair, containing a tag-value seperator in the string`` () =

    let input = [|  yield! "90=9"B; yield 1uy           // SecureDataLen, containing the length of the data in SecureData
                    yield! "91=ABCD=EFGH"B; yield 1uy|]  // SecureData, that has not been encrypted
    let pos = 3 // the tag and the the tag value separator have been read
    let posOut, fld = ReadSecureData input pos 
    SecureData.SecureData "ABCD=EFGH"B =! fld
    input.Length =! posOut


[<Fact>]
let ``read RawDataLength`` () = 
    let input = [| yield! "95=6"B; yield 1uy            // raw data length
                   yield! "96=aaaaaa"B; yield 1uy |]    // raw data 
    let pos = 3 // the tag and the the tag value separator have been read
    let posOut, fld = ReadRawData input pos 
    RawData.RawData "aaaaaa"B =! fld
    input.Length =! posOut


[<Fact>]
let ``read RawDataLength + RawData pair, containing a field seperator in the string`` () = 
    let input = [| yield! "95=7"B; yield 1uy            // raw data length
                   yield! "96=aaa=aaa"B; yield 1uy |]    // raw data 
    let pos = 3 // the tag and the the tag value separator have been read
    let posOut, fld = ReadRawData input pos 
    RawData.RawData "aaa=aaa"B =! fld
    input.Length =! posOut


[<Fact>]
let ``read RawDataLength + RawData pair, containing a tag-value seperator in the string`` () =
    let valToRead = [|yield! "ABCD"B; yield 1uy; yield! "EFGH"B; |] // contains a field seperator
    let input = [|  yield! "95=9"B; yield 1uy           // SecureDataLen, containing the length of the data in SecureData
                    yield! "96="B; yield! valToRead; yield 1uy |]  // SecureData, that has not been encrypted
    let pos = 3 // the tag and the the tag value separator have been read
    let posOut, fld = ReadRawData input pos 
    RawData.RawData valToRead =! fld
    input.Length =! posOut
