module FieldRead.Tests


open Xunit

open Fix44.Fields
open Fix44.FieldReaders
open Swensen.Unquote


let private indexSingleField bs = 
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs bs.Length
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)
    let fpData = fieldPosArr.[0]
    fpData.Pos, fpData.Len



[<Fact>]
let ``read single case DU`` () =
    let bs = [| yield! "1=AccountStr"B; yield 1uy |]
    let pos, len = indexSingleField bs
    let fld = ReadAccountIdx bs pos len
    (Account.Account "AccountStr") =! fld


[<Fact>]
let ``read multicase DU case Buy`` () =
    let bs = [| yield! "3=B"B; yield 1uy |]
    let pos, len = indexSingleField bs
    let fld = ReadAdvSideIdx bs pos len
    AdvSide.Buy =! fld


[<Fact>]
let ``read multicase DU case 1`` () =
    let bs = [| yield! "3=S"B; yield 1uy |]
    let pos, len = indexSingleField bs
    let fld = ReadAdvSideIdx bs pos len
    AdvSide.Sell =! fld


[<Fact>]
let ``read multicase DU case Cross`` () =
    let bs = [| yield! "3=X"B; yield 1uy |]
    let pos, len = indexSingleField bs
    let fld = ReadAdvSideIdx bs pos len
    AdvSide.Cross =! fld


[<Fact>]
let ``read multicase DU case Trade`` () =
    let bs = [| yield! "3=T"B; yield 1uy |]
    let pos, len = indexSingleField bs
    let fld = ReadAdvSideIdx bs pos len
    AdvSide.Trade =! fld


[<Fact>]
let ``read multicase DU case invalid`` () =
    let bs = [| yield! "3=TT"B; yield 1uy |]
    let pos, len = indexSingleField bs
    try
        ReadAdvSideIdx bs pos len |> ignore
        true =! false
    with
        | ex -> "ReadAdvSide unknown fix tag: [|84uy; 84uy|]" =! ex.Message



[<Fact>]
let ``read compound len+str pair`` () =
    let bs = [|  yield! "90=8"B; yield 1uy           // SecureDataLen, containing the length of the data in SecureData
                 yield! "91=ABCDEFGH"B; yield 1uy|]  // SecureData
    let pos, len = indexSingleField bs
    let fld = ReadSecureDataIdx bs pos len
    (SecureData.SecureData "ABCDEFGH"B) =! fld


[<Fact>]
let ``read compound len+str pair, containing a field seperator in the string`` () =
    let valToRead = [|yield! "ABCD"B; yield 1uy; yield! "EFGH"B; |] // contains a field seperator
    
    let bs = [| yield! "90=9"B; yield 1uy                       // SecureDataLen, containing the length of the data in SecureData
                yield! "91="B;  yield! valToRead; yield 1uy |]  // SecureData
    let pos,len = indexSingleField bs
    let fld = ReadSecureDataIdx bs pos len
    SecureData.SecureData valToRead =! fld


[<Fact>]
let ``read compound len+str pair, containing a tag-value seperator in the string`` () =
    let bs = [|  yield! "90=9"B; yield 1uy           // SecureDataLen, containing the length of the data in SecureData
                 yield! "91=ABCD=EFGH"B; yield 1uy|]  // SecureData
    let pos,len = indexSingleField bs
    let fld = ReadSecureDataIdx bs pos len
    SecureData.SecureData "ABCD=EFGH"B =! fld



[<Fact>]
let ``read RawDataLength`` () = 
    let bs = [| yield! "95=6"B; yield 1uy            // raw data length
                yield! "96=aaaaaa"B; yield 1uy |]    // raw data 
    let pos, len = indexSingleField bs
    let fld = ReadRawDataIdx bs pos len
    RawData.RawData "aaaaaa"B =! fld


[<Fact>]
let ``read RawDataLength + RawData pair, containing a field seperator in the string`` () = 
    let bs = [| yield! "95=7"B; yield 1uy            // raw data length
                yield! "96=aaa=aaa"B; yield 1uy |]    // raw data 
    let pos, len = indexSingleField bs
    let fld = ReadRawDataIdx bs pos len
    RawData.RawData "aaa=aaa"B =! fld


[<Fact>]
let ``read RawDataLength + RawData pair, containing a tag-value seperator in the string`` () =
    let valToRead = [|yield! "ABCD"B; yield 1uy; yield! "EFGH"B; |] // contains a field seperator
    let bs = [|  yield! "95=9"B; yield 1uy                          // SecureDataLen, containing the length of the data in SecureData
                 yield! "96="B; yield! valToRead; yield 1uy |]      // SecureData
    let pos, len = indexSingleField bs
    let fld = ReadRawDataIdx bs pos len
    RawData.RawData valToRead =! fld



[<Fact>]
let ``read RawDataLength + RawData pair USING INDEX, containing a tag-value seperator in the string`` () =
    let valToRead = [|yield! "ABCD"B; yield 1uy; yield! "EFGH"B; |] // contains a field seperator
    let bs = [|  yield! "95=9"B; yield 1uy                          // SecureDataLen, containing the length of the data in SecureData
                 yield! "96="B; yield! valToRead; yield 1uy |]      // SecureData
    let pos, len = indexSingleField bs
    let fld = ReadRawDataIdx bs pos len
    RawData.RawData valToRead =! fld
    