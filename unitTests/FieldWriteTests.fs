module FieldWrite.Test

open Xunit
open Swensen.Unquote

open Fix44.Fields
open Fix44.FieldReadFuncs
open Fix44.FieldWriteFuncs




[<Fact>]
let ``write single-case DU`` () =
    let beginString:BeginString = BeginString.BeginString "FIX.4.4"
    let dest = Array.zeroCreate<byte> 32
    let endPos = WriteBeginString dest 0 beginString
    let expectedBytesWritten = [| yield! "8=FIX.4.4"B; yield 1uy |] // 1uy is the FIX delimiter
    let dest2 = dest |> Array.take expectedBytesWritten.Length
    test<@ expectedBytesWritten = dest2 @>
    test<@ 10 = endPos @>


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
    test<@ expectedBytesWritten = dest2 @>
    test<@ 20 = endPos2 @>


[<Fact>]
let ``write multicase DU`` () =
    let fld = AdvSide.Buy 
    let dest = Array.zeroCreate<byte> 32
    let endPos = WriteAdvSide dest 0 fld
    let expectedBytesWritten  = [|yield! "4=B"B; yield 1uy; |]
    let dest2 = dest |> Array.take expectedBytesWritten.Length
    test<@ expectedBytesWritten = dest2 @>
    test<@ expectedBytesWritten.Length = endPos @>
    
    
[<Fact>]
let ``write len+data pair`` () =
    let fld = RawData.RawData "12345678"B
    let dest = Array.zeroCreate<byte> 32
    let endPos = WriteRawData dest 0 fld
    let expectedBytesWritten  =  [| yield! "95=8"B; yield 1uy           // length is 8
                                    yield! "96=12345678"B; yield 1uy |]
    let dest2 = dest |> Array.take expectedBytesWritten.Length
    test<@ expectedBytesWritten = dest2 @>
    test<@ expectedBytesWritten.Length = endPos @>


[<Fact>]
let ``write len+str pair, contains field seperator`` () =
    let fld = RawData.RawData [| yield! "1234"B;  yield 1uy; yield! "5678"B |]
    let dest = Array.zeroCreate<byte> 32
    let endPos = WriteRawData dest 0 fld
    let expectedBytesWritten  =  [| yield! "95=9"B; yield 1uy   // length is 9
                                    yield! "96=1234"B; yield 1uy; yield! "5678"B; yield 1uy |]
    let dest2 = dest |> Array.take expectedBytesWritten.Length
    test<@ expectedBytesWritten = dest2 @>
    test<@ expectedBytesWritten.Length = endPos @>


[<Fact>]
let ``write len+str pair, contains tag-value seperator`` () =
    let fld = RawData.RawData "1234=5678"B
    let dest = Array.zeroCreate<byte> 32
    let endPos = WriteRawData dest 0 fld
    let expectedBytesWritten  =  [| yield! "95=9"B; yield 1uy   // length is 9
                                    yield! "96=1234=5678"B; yield 1uy |]
    let dest2 = dest |> Array.take expectedBytesWritten.Length
    test<@ expectedBytesWritten = dest2 @>
    test<@ expectedBytesWritten.Length = endPos @>



//[<Fact>]
//let ``test checksum calc`` () =
//    test<@ false @>