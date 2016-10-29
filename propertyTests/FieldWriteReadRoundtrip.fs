module FieldWriteReadRoundtrip



open FsCheck
open FsCheck.Xunit



//let genNonEmptyBytes = 
//    gen{
//        let! arraySize = Gen.choose (1, 32)
//        let! bs = Gen.arrayOfLength arraySize Arb.generate<byte>
//        return bs
//    }    
//
//type ArbOverridesAsyncRead() =
//    static member NonEmptyByteArray() = Arb.fromGenShrink (genNonEmptyBytes, ArraySubSeqs)
//    static member Ints() = Arb.fromGen (Gen.choose(1, 128*1024))



let genAlphaChar = Gen.choose(32,255) |> Gen.map char 
let genAlphaCharArray = Gen.arrayOf genAlphaChar 
let genAlphaString = 
        gen{
            let! chars = genAlphaCharArray
            return System.String chars
        }



type ArbOverrides() =
    static member String() =
//            Arb.from<NonNull<string>>
            Arb.fromGen genAlphaString


 
type PropertyTestAttribute() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
//        Replay = Some (Random.StdGen (1338710834,296222476)),
//        Replay = "(Random.StdGen (310046944,296129814))",
        MaxTest = 10000,
        Verbose = true,
        QuietOnSuccess = false)




[<PropertyTestAttribute>]
let ``write-read roundtrip`` (fieldIn:Fix44.Fields.FIXField) =
    let bs = Array.zeroCreate<byte> 2048
    Fix44.FieldReadWriteFuncs.WriteField bs 0 fieldIn |> ignore
    let _, fieldOut = Fix44.FieldReadWriteFuncs.ReadField 0 bs
    fieldIn = fieldOut
