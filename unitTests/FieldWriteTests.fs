module FieldWriteUnitTests

open Xunit
open Swensen.Unquote

open Fix44.Fields
open Fix44.FieldReaders
open Fix44.FieldWriters




[<Fact>]
let ``write single-case DU`` () =
    let beginString:BeginString = BeginString.BeginString "FIX.4.4"
    let dest = Array.zeroCreate<byte> 32
    let endPos = WriteBeginString dest 0 beginString
    let expectedBytesWritten = [| yield! "8=FIX.4.4"B; yield 1uy |] // 1uy is the FIX delimiter
    let dest2 = dest |> Array.take expectedBytesWritten.Length
    expectedBytesWritten =! dest2
    10 =! endPos


/// test that no part of the first is overwritten by the second
[<Fact>]
let ``write single-case DU twice`` () =
    let beginString:BeginString = BeginString.BeginString "FIX.4.4"
    let dest = Array.zeroCreate<byte> 32
    let endPos = WriteBeginString dest 0 beginString
    let endPos2 = WriteBeginString dest endPos beginString
    let expectedBytesWritten = [| yield! "8=FIX.4.4"B; yield 1uy; yield! "8=FIX.4.4"B; yield 1uy; |] // 1uy is the FIX delimiter
    let dest2 = dest |> Array.take expectedBytesWritten.Length
    let arraysEq = expectedBytesWritten = dest2
    expectedBytesWritten =! dest2
    20 =! endPos2


[<Fact>]
let ``write multicase DU`` () =
    let fld = AdvSide.Buy 
    let dest = Array.zeroCreate<byte> 32
    let endPos = WriteAdvSide dest 0 fld
    let expectedBytesWritten  = [|yield! "4=B"B; yield 1uy; |]
    let dest2 = dest |> Array.take expectedBytesWritten.Length
    expectedBytesWritten =! dest2
    expectedBytesWritten.Length =! endPos
    

let mkRawData = NonEmptyByteArray.Make >> RawData

    
[<Fact>]
let ``write len+data pair`` () =
    let fld = mkRawData "12345678"B
    let dest = Array.zeroCreate<byte> 32
    let endPos = WriteRawData dest 0 fld
    let expectedBytesWritten  =  [| yield! "95=8"B; yield 1uy           // length is 8
                                    yield! "96=12345678"B; yield 1uy |]
    let dest2 = dest |> Array.take expectedBytesWritten.Length
    expectedBytesWritten =! dest2
    expectedBytesWritten.Length =! endPos


[<Fact>]
let ``write len+str pair, contains field seperator`` () =
    let fld = mkRawData [| yield! "1234"B;  yield 1uy; yield! "5678"B |]
    let dest = Array.zeroCreate<byte> 32
    let endPos = WriteRawData dest 0 fld
    let expectedBytesWritten  =  [| yield! "95=9"B; yield 1uy   // length is 9
                                    yield! "96=1234"B; yield 1uy; yield! "5678"B; yield 1uy |]
    let dest2 = dest |> Array.take expectedBytesWritten.Length
    expectedBytesWritten =! dest2
    expectedBytesWritten.Length =! endPos


[<Fact>]
let ``write len+str pair, contains tag-value seperator`` () =
    let fld = mkRawData "1234=5678"B
    let dest = Array.zeroCreate<byte> 32
    let endPos = WriteRawData dest 0 fld
    let expectedBytesWritten  =  [| yield! "95=9"B; yield 1uy   // length is 9
                                    yield! "96=1234=5678"B; yield 1uy |]
    let dest2 = dest |> Array.take expectedBytesWritten.Length
    expectedBytesWritten =! dest2
    expectedBytesWritten.Length =! endPos



//[<Fact>]
//let ``test checksum calc`` () =
//    false 