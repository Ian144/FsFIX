module ReadTagValue.Tests

open System.IO
open Xunit
open Swensen.Unquote



[<Fact>]
let ``single field then checksum then another field, should not read last field`` () =
    let inBuf = [| 
            yield! "8=XXXX"B; yield 1uy 
            yield! "10=128"B; yield 1uy // the byte representation of the checksum field
            yield! "8=YYYY"B; yield 1uy // this field should not be read
        |]
    use ms = new MemoryStream ()
    ms.Write (inBuf, 0, inBuf.Length)
    ms.Seek(0L, SeekOrigin.Begin) |> ignore
    let tagVals = ReadWriteFuncs.ReadTagValuesUntilChecksum ms
    let expectedNumTagValues = 2 // the 3rd field should be ignored, the first two must be read
    test<@ expectedNumTagValues = tagVals.Length @>
    Assert.Equal (2, tagVals.Length) 
    let tv1 = tagVals |> Array.head
    let tv2 = tagVals |> Array.skip 1 |> Array.head
    test <@  "8"B    = tv1.Tag @>
    test <@  "XXXX"B = tv1.Value @>
    test <@  "10"B   = tv2.Tag @>
    test <@  "128"B  = tv2.Value @>



[<Fact>]
let ``two fields then checksum then another field, should not read last field`` () =
    let inBuf = [| 
            yield! "8=XXXX"B; yield 1uy 
            yield! "8=ZZZZ"B; yield 1uy 
            yield! "10=128"B; yield 1uy // the byte representation of the checksum field
            yield! "8=YYYY"B; yield 1uy // this field should not be read
        |]
    use ms = new MemoryStream ()
    ms.Write (inBuf, 0, inBuf.Length)
    ms.Seek(0L, SeekOrigin.Begin) |> ignore
    let tagVals = ReadWriteFuncs.ReadTagValuesUntilChecksum ms
    let expectedNumTagValues = 3
    test<@ expectedNumTagValues = tagVals.Length @>
    let tv1 = tagVals |> Array.head
    let tv2 = tagVals |> Array.skip 1 |> Array.head
    let tvCheckSum = tagVals |> Array.skip 2 |> Array.head
    test <@ "8"B      = tv1.Tag @>
    test <@ "XXXX"B   = tv1.Value @>
    test <@ "8"B      = tv2.Tag @>
    test <@ "ZZZZ"B   = tv2.Value @>
    test <@ "10"B     = tvCheckSum.Tag @>
    test <@ "128"B    = tvCheckSum.Value @>

    

[<Fact>]
let ``RawDataLength then RawData containing field terminator`` () =
    let inBuf = [| 
            yield! "95=7"B; yield 1uy 
            yield! "96=aaa|aaa"B; yield 1uy // raw data containing field terminator
            yield! "10=000"B; yield 1uy     // the checksum field
        |]
    use ms = new MemoryStream ()
    ms.Write (inBuf, 0, inBuf.Length)
    ms.Seek(0L, SeekOrigin.Begin) |> ignore
    let tagVals = ReadWriteFuncs.ReadTagValuesUntilChecksum ms
    let expectedNumTagValues = 3
    test<@ expectedNumTagValues = tagVals.Length @>
    let tv1 = tagVals |> Array.head
    let tv2 = tagVals |> Array.skip 1 |> Array.head
    let tvCheckSum = tagVals |> Array.skip 2 |> Array.head
    test <@ "95"B      = tv1.Tag @>
    test <@ "7"B   = tv1.Value @>
    test <@ "96"B      = tv2.Tag @>
    test <@ "aaa|aaa"B   = tv2.Value @>
    test <@ "10"B     = tvCheckSum.Tag @>
    test <@ "000"B    = tvCheckSum.Value @>

[<Fact>]
let ``RawDataLength then RawData containing tag-value separator`` () =
    let inBuf = [| 
            yield! "95=7"B; yield 1uy       // raw data length
            yield! "96=aaa=aaa"B; yield 1uy // raw data containing tag-value separator
            yield! "10=000"B; yield 1uy     // the checksum field
        |]
    use ms = new MemoryStream ()
    ms.Write (inBuf, 0, inBuf.Length)
    ms.Seek(0L, SeekOrigin.Begin) |> ignore
    let tagVals = ReadWriteFuncs.ReadTagValuesUntilChecksum ms
    let expectedNumTagValues = 3
    test<@ expectedNumTagValues = tagVals.Length @>
    let tv1 = tagVals |> Array.head
    let tv2 = tagVals |> Array.skip 1 |> Array.head
    let tvCheckSum = tagVals |> Array.skip 2 |> Array.head
    test <@ "95"B      = tv1.Tag @>
    test <@ "7"B   = tv1.Value @>
    test <@ "96"B      = tv2.Tag @>
    test <@ "aaa=aaa"B   = tv2.Value @>
    test <@ "10"B     = tvCheckSum.Tag @>
    test <@ "000"B    = tvCheckSum.Value @>



// todo: unit test checksum
