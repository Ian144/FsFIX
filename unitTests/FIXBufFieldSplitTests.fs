module FIXBufSplitter.Test

open Xunit
open Swensen.Unquote

open FIXBufSplitter

let convFieldSep (bb:byte) = 
    match bb with 
    | 124uy -> 01uy
    | n     -> n








[<Fact>]
let ``split simple FIX buf, no groups or len+data fields`` () =
    let fixBuf = "8=FIX.4.4|9=61|35=A|49=FUND|56=BROKER|34=1|52=20170104-06:22:00|98=0|108=30|10=157"B |> Array.map convFieldSep
    let ss = FIXBuf.toS fixBuf fixBuf.Length
    
    let actual = FIXBufSplitter.Split fixBuf

    let expected = [|  
            FIXBufSplitter.FieldPos(0, 0, 0)
        |]

    true =! false
