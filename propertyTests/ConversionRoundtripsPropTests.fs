module ConversionRoundtripsPropTests

open FsCheck
open FsCheck.Xunit
open Swensen.Unquote

open Conversions



open PropTestParams



[<PropTestByteArrayConversions>]
let Uint32ConversionRoundtrip (ui:uint32) =
    let bs = Conversions.ToBytes.Convert ui
    let uiOut = Conversions.bytesToUInt32 bs 0 bs.Length
    uiOut =! ui




[<PropTestByteArrayConversions>]
let Int32ConversionRoundtrip (ii:int32) =
    let bs = Conversions.ToBytes.Convert ii
    let uiOut = Conversions.bytesToInt32 bs 0 bs.Length
    ii =! uiOut



// EndSize = System.Int32.MaxValue, as set for PropTest above, makes this test very slow to run due to the huge strings created
[<PropTest>]
let StringConversionRoundtrip (nnss:NonNull<string>) =
    let ss = nnss.Get
    let bs = Conversions.ToBytes.Convert ss
    let ssOut = Conversions.bytesToStr bs 0 bs.Length
    ss =! ssOut


[<PropTestByteArrayConversions>]
let DecimalConversionRoundtrip (xxIn:decimal) =
    let dd = System.Math.Round(xxIn,15)
    let bs = Conversions.ToBytes.Convert dd
    let ddOut = Conversions.bytesToDecimal bs 0 bs.Length
    dd =! ddOut

