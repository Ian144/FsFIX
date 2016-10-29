module FieldWriteReadRoundtrip

open FsCheck
open FsCheck.Xunit

open Fix44.FieldDU



// strings stored in FIX do not contain field terminators, 
let genAlphaChar = Gen.choose(32,255) |> Gen.map char 
let genAlphaCharArray = Gen.arrayOf genAlphaChar 
let genAlphaString = 
        gen{
            let! chars = genAlphaCharArray
            return System.String chars
        }



type ArbOverrides() =
    static member String() =
            Arb.fromGen genAlphaString


 
type PropertyTestAttribute() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 10000,
        Verbose = false,
        QuietOnSuccess = true)



[<PropertyTestAttribute>]
let ``write-read roundtrip`` (fieldIn:FIXField) =
    let bs = Array.zeroCreate<byte> 2048
    WriteField bs 0 fieldIn |> ignore
    let _, fieldOut = ReadField 0 bs
    fieldIn = fieldOut
