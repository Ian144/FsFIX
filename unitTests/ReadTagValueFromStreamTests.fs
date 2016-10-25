module ReadTagValueTests

open System.IO
open Xunit
open Fix44.Fields
open Fix44.FieldReadWriteFuncs
open TestUtils




[<Fact>]
let ``single field then checksum`` () =

    let inBuf = [| 
            yield! "8=XXXX"B; yield 1uy 
            yield! "10=128"B; yield 1uy // the byte representation of the checksum field
            yield! "8=YYYY"B; yield 1uy // this field should not be read
        |]

    use ms = new MemoryStream ()
    ms.Write (inBuf, 0, inBuf.Length)
    let xx = ms.Seek(0L, SeekOrigin.Begin) 

    let tagVals = ReadWriteFuncs.ReadTagValuesUntilChecksum ms

    Assert.Equal (2, tagVals.Length) // the 3rd field should be ignored, the first two must be read
    
    let tv1 = tagVals |> Array.head
    let tv2 = tagVals |> Array.skip 1 |> Array.head
    Assert.True ( "8"B      = tv1.Tag,      "m1" )
    Assert.True ( "XXXX"B   = tv1.Value,    "m2")
    Assert.True ( "10"B     = tv2.Tag,      "m3")
    Assert.True ( "128"B    = tv2.Value,    "m4")

    



// todo: unit test checksum
