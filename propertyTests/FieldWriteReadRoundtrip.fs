module FieldWriteReadRoundtrip

open FsCheck
open FsCheck.Xunit

open Fix44.FieldDU
open Fix44.FieldReadFuncs
open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs

// strings stored in FIX do not contain field terminators, 
//let genAlphaChar = Gen.choose(32,255) |> Gen.map char 
let genAlphaChar = Gen.choose(65,90) |> Gen.map char 
//let genAlphaCharArray = Gen.arrayOfLength 16 genAlphaChar 
let genAlphaString = 
        gen{
            let! len = Gen.choose(4, 8)
            let! chars = Gen.arrayOfLength len genAlphaChar
            return System.String chars
        }



type ArbOverrides() =
    static member String() =
            Arb.fromGen genAlphaString


 
type PropertyTestAttribute() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 100,
        Verbose = true,
        QuietOnSuccess = true)



[<PropertyTestAttribute>]
let ``PosMaintRptID  write-read roundtrip`` (pmri:Fix44.Fields.PosMaintRptID) =
    let bs = Array.zeroCreate<byte> (1024 * 1)
    let posW = Fix44.FieldWriteFuncs.WritePosMaintRptID bs 0 pmri
    let posSep = FIXBufUtils.findNextTagValSep 0 bs
    let posR, pmriOut = Fix44.FieldReadFuncs.ReadPosMaintRptID (posSep+1) bs
    let ok = pmri = pmriOut && posW = posR // posR should be one past the last byte written, posW should be the next writeable byte, so both should be the same
    let ok2 = (posW = posR)
    ok && ok2


[<PropertyTestAttribute>]
let ``field write-read roundtrip`` (fieldIn:FIXField) =
    let bs = Array.zeroCreate<byte> (1024 * 64)
    let posW = WriteField bs 0 fieldIn
    let posR, fieldOut = ReadField 0 bs
    let ok = fieldIn = fieldOut
    if not ok then
        printf ""
    ok


[<PropertyTestAttribute>]
let ``NoCapacitiesGrp write-read roundtrip`` (grp:NoCapacitiesGrp ) =
    let bs = Array.zeroCreate<byte> (1024 * 16)
    let endPos = WriteNoCapacitiesGrp  bs 0 grp
    let posOut, grpOut = Fix44.CompoundItemReadFuncs.ReadNoCapacitiesGrp 0 bs
    grp = grpOut //&& endPos = posOut



[<PropertyTestAttribute>]
let ``UnderlyingStipulationsGrp write-read roundtrip`` (usIn:NoUnderlyingStipsGrp ) =
    let bs = Array.zeroCreate<byte> (1024 * 16)
    let posW = WriteNoUnderlyingStipsGrp bs 0 usIn
    let posR, usOut = Fix44.CompoundItemReadFuncs.ReadNoUnderlyingStipsGrp 0 bs
    let ok = usIn = usOut //&& endPos = posOut
    let ok2 = (posW = posR)
    ok && ok2


[<PropertyTestAttribute>]
let ``UnderlyingStipulations write-read roundtrip`` (usIn:UnderlyingStipulations) =
    (usIn.NoUnderlyingStipsGrp.IsSome) ==> lazy
        let bs = Array.zeroCreate<byte> (1024 * 16)
        let posW = WriteUnderlyingStipulations  bs 0 usIn
        let posR, usOut = Fix44.CompoundItemReadFuncs.ReadUnderlyingStipulations 0 bs
        let ok = usIn = usOut
        let ok2 = (posW = posR)
        let xx = ok && ok2
        if not xx then
            printf ""
        xx



