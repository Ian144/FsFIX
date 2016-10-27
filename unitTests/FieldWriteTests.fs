module FieldWrite.Test

open Xunit

open Fix44.Fields
open Fix44.FieldReadWriteFuncs
open Swensen.Unquote



[<Fact>]
let ``write single-case DU`` () =
    let beginString:BeginString = BeginString.BeginString "FIX.4.4"

    let dest = Array.zeroCreate<byte> 32
    let endPos = WriteBeginString dest 0 beginString

    let expectedBytesWritten = [| yield! "8=FIX.4.4"B; yield 1uy |] // 1uy is the FIX delimiter
    let dest2 = dest |> Array.take expectedBytesWritten.Length
    let arraysEq = expectedBytesWritten = dest2
    Assert.True (arraysEq, "unexpected bytes written by WriteBeginString")
    Assert.Equal (10, endPos)


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
    Assert.True (arraysEq, "unexpected bytes written by WriteBeginString")
    Assert.Equal (20, endPos2)


// todo: unit test checksum
// todo: unit test write multicase DU
// todo: unit test write len+str pair
// todo: unit test write RawDataLength+RawData 



[<Fact>]
let ``test checksum calc`` () =
    test<@ false @>


[<Fact>]
let ``write multicase DU`` () =
    test<@ false @>
    
    
[<Fact>]
let ``test  write len+str pair`` () =
    test<@ false @>

[<Fact>]
let ``test  write len+str pair, contains field seperator`` () =
    test<@ false @>

[<Fact>]
let ``test  write len+str pair, contains tag-value seperator`` () =
    test<@ false @>


[<Fact>]
let ``test write RawDataLength+RawData `` () =
    test<@ false @>

[<Fact>]
let ``test write RawDataLength+RawData, contains field seperator `` () =
    test<@ false @>

[<Fact>]
let ``test write RawDataLength+RawData, contains tag-value seperator `` () =
    test<@ false @>

