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



[<Fact>]
let ``read msg`` () =

    let input = [| 
        yield! "8=FIX.4.2"B
        yield 1uy
        yield! "9=178"B
        yield 1uy
        yield! "35=8"B
        yield 1uy
        yield! "49=PHLX"B
        yield 1uy
        yield! "56=PERS"B
        yield 1uy
        yield! "52=20071123-05:30:00.000"B
        yield 1uy
        yield! "11=ATOMNOCCC9990900"B
        yield 1uy
        yield! "20=3"B
        yield 1uy
        yield! "150=E"B
        yield 1uy
        yield! "39=E"B
        yield 1uy
        yield! "55=MSFT"B
        yield 1uy
        yield! "167=CS"B
        yield 1uy
        yield! "54=1"B
        yield 1uy
        yield! "38=15"B
        yield 1uy
        yield! "40=2"B
        yield 1uy
        yield! "44=15"B
        yield 1uy
        yield! "58=PHLX EQUITY TESTING"B
        yield 1uy
        yield! "59=0"B
        yield 1uy
        yield! "47=C"B
        yield 1uy
        yield! "32=0"B
        yield 1uy
        yield! "31=0"B
        yield 1uy
        yield! "151=15"B
        yield 1uy
        yield! "14=0"B
        yield 1uy
        yield! "6=0"B
        yield 1uy
        yield! "10=074"B
        yield 1uy
     |]


    let expectedOutput = [| 
        yield! "35=8"B
        yield 1uy
        yield! "49=PHLX"B
        yield 1uy
        yield! "56=PERS"B
        yield 1uy
        yield! "52=20071123-05:30:00.000"B
        yield 1uy
        yield! "11=ATOMNOCCC9990900"B
        yield 1uy
        yield! "20=3"B
        yield 1uy
        yield! "150=E"B
        yield 1uy
        yield! "39=E"B
        yield 1uy
        yield! "55=MSFT"B
        yield 1uy
        yield! "167=CS"B
        yield 1uy
        yield! "54=1"B
        yield 1uy
        yield! "38=15"B
        yield 1uy
        yield! "40=2"B
        yield 1uy
        yield! "44=15"B
        yield 1uy
        yield! "58=PHLX EQUITY TESTING"B
        yield 1uy
        yield! "59=0"B
        yield 1uy
        yield! "47=C"B
        yield 1uy
        yield! "32=0"B
        yield 1uy
        yield! "31=0"B
        yield 1uy
        yield! "151=15"B
        yield 1uy
        yield! "14=0"B
        yield 1uy
        yield! "6=0"B
        yield 1uy
     |]

    use ms = new MemoryStream ()
    ms.Write (input, 0, input.Length)
    ms.Seek(0L, SeekOrigin.Begin) |> ignore

    //let fld = Fix44.FieldReadWriteFuncs.ReadField ms


    let output = ReadWriteFuncs.ReadMsgBytes ms
    test<@ expectedOutput = output @>


// todo: test read msg with a fake checksum field inside a rawdata field, and no actual checksum page, because the bytes have not been received yes
// todo: test read msg, whereby more than one socket read is required to succeed
// todo: as above but with timeout
// todo: unit test checksum
