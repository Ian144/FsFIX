module FIXBufIndexer.Test

open Xunit
open Swensen.Unquote

open FIXBufIndexer

let convFieldSep (bb:byte) = 
    match bb with 
    | 124uy -> 1uy
    | n     -> n





//// compound write, of a length field and the corresponding string field
//let WriteRawData (dest:byte []) (pos:int) (fld:RawData) : int =
//    WriteFieldLengthData dest pos "95="B "96="B fld




[<Fact>]
let ``index simple FIX buf, including len+data field RawData`` () =
    // 95=5|96=xx|xx contains the field seperator (between xx's), position should not matter
    let fixBuf = "95=5|96=xx|xx|8=FIX.4.4|9=61|35=A|49=FUND|56=BROKER|34=1|52=20170104-06:22:00|98=0|108=30|10=157"B |> Array.map convFieldSep

    let actualIndex = FIXBufIndexer.Index fixBuf
    
    let expectedIndex = [|  
        FIXBufIndexer.FieldPos( 13625, 3, 1) // rawdata len
        FIXBufIndexer.FieldPos( 13881, 8, 5) // rawdata body
        FIXBufIndexer.FieldPos( 56, 2, 7)
        FIXBufIndexer.FieldPos( 57, 12, 2)
        FIXBufIndexer.FieldPos( 13619, 18, 1)
        FIXBufIndexer.FieldPos( 14644, 23, 4)
        FIXBufIndexer.FieldPos( 13877, 31, 6)
        FIXBufIndexer.FieldPos( 13363, 41, 1)
        FIXBufIndexer.FieldPos( 12853, 46, 17)
        FIXBufIndexer.FieldPos( 14393, 67, 1)
        FIXBufIndexer.FieldPos( 3682353, 73, 2)
        FIXBufIndexer.FieldPos( 12337, 79, 3)
        |]

    expectedIndex =! actualIndex




[<Fact>]
let ``reconstruct FIX buf from index, contains len+data fields`` () =
    // 95=5|96=xx|xx contains the field seperator
    let fixBuf = "8=FIX.4.4|9=61|35=A|49=FUND|56=BROKER|34=1|52=20170104-06:22:00|98=0|95=5|96=xx|xx|108=30|10=157"B |> Array.map convFieldSep
    let index = FIXBufIndexer.Index fixBuf
    let fixBuf2 = FIXBufIndexer.reconstructFromIndex fixBuf index
    fixBuf =! fixBuf2



[<Fact>]
let ``index simple FIX buf, no len+data fields`` () =
    let fixBuf = "8=FIX.4.4|9=61|35=A|49=FUND|56=BROKER|34=1|52=20170104-06:22:00|98=0|108=30|10=157"B |> Array.map convFieldSep

    let actualIndex = FIXBufIndexer.Index fixBuf
    
    let expectedIndex = [|  
        FIXBufIndexer.FieldPos( 56, 2, 7)
        FIXBufIndexer.FieldPos( 57, 12, 2)
        FIXBufIndexer.FieldPos( 13619, 18, 1)
        FIXBufIndexer.FieldPos( 14644, 23, 4)
        FIXBufIndexer.FieldPos( 13877, 31, 6)
        FIXBufIndexer.FieldPos( 13363, 41, 1)
        FIXBufIndexer.FieldPos( 12853, 46, 17)
        FIXBufIndexer.FieldPos( 14393, 67, 1)
        FIXBufIndexer.FieldPos( 3682353, 73, 2)
        FIXBufIndexer.FieldPos( 12337, 79, 3)
        |]

    expectedIndex =! actualIndex



[<Fact>]
let ``reconstruct FIX buf from index, no len+data fields`` () =
    let fixBuf = "8=FIX.4.4|9=61|35=A|49=FUND|56=BROKER|34=1|52=20170104-06:22:00|98=0|108=30|10=157"B |> Array.map convFieldSep
    let index = FIXBufIndexer.Index fixBuf
    let fixBuf2 = FIXBufIndexer.reconstructFromIndex fixBuf index
    fixBuf =! fixBuf2
