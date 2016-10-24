module FieldWriteTests

open Xunit

open Fix44.Fields
open Fix44.FieldReadWriteFuncs



[<Fact>]
let ``write single-case DU test`` () =
    let beginString:BeginString = BeginString.BeginString "FIX.4.4"

    let dest = Array.zeroCreate<byte> 32
    let endPos = WriteBeginString dest 0 beginString

    let expectedBytesWritten = [| yield! "8=FIX.4.4"B; yield 1uy |] // 1uy is the FIX delimiter
    let dest2 = dest |> Array.take expectedBytesWritten.Length
    let arraysEq = expectedBytesWritten = dest2
    Assert.True (arraysEq, "unexpected bytes written by WriteBeginString")
    Assert.Equal (10, endPos)