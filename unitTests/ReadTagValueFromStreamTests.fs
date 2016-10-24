module ReadTagValueTests

open System.IO
open Xunit
open Fix44.Fields
open Fix44.FieldReadWriteFuncs


[<Fact>]
let ``single field then checksum`` () =

    // 
    let inBuf = [| 
            yield! "8=XXXX"B; yield 1uy 
            yield! "10=128"B; yield 1uy // the byte representation of the checksum field
            yield! "8=YYYY"B; yield 1uy // this field should not be read
        |]

    use ms = new MemoryStream ()
    ms.Write (inBuf, 0, inBuf.Length)

    let tagVals = ReadWriteFuncs.ReadTagValuesUntilChecksum ms

    Assert.Equal (2, tagVals.Length) // the 3rd field should be ignored, the first two must be read
    
    let tv1 = tagVals |> Array.head
    Assert.True ("8"B = tv1.Tag)
    Assert.True ("XXXX"B = tv1.Value)

    let tv2 = tagVals |> Array.skip 1 |> Array.head
    Assert.True ("10"B = tv1.Tag)
    Assert.True ("123"B = tv1.Value)

    



// todo: unit test checksum
