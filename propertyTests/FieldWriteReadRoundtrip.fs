module FieldWriteReadRoundtrip

open FsCheck
open FsCheck.Xunit

open Fix44.FieldDU

open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs

// strings stored in FIX do not contain field terminators, 
let genAlphaChar = Gen.choose(32,255) |> Gen.map char 
//let genAlphaChar = Gen.choose(65,90) |> Gen.map char 
//let genAlphaCharArray = Gen.arrayOfLength 16 genAlphaChar 
let genAlphaString = 
        gen{
            let! len = Gen.choose(0, 9999)
            let! chars = Gen.arrayOfLength len genAlphaChar
            return System.String chars
        }



type ArbOverrides() =
    static member String() =
            Arb.fromGen genAlphaString


 
type PropertyTestAttribute() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 1000,
        Verbose = true,
        QuietOnSuccess = true)



[<PropertyTestAttribute>]
let ``PosMaintRptID  write-read roundtrip`` (pmri:Fix44.Fields.PosMaintRptID) =
    let fieldIn = FIXField.PosMaintRptID pmri
    let bs = Array.zeroCreate<byte> (1024 * 64)
    WriteField bs 0 fieldIn |> ignore
    let _, fieldOut = ReadField 0 bs
    let ok = fieldIn = fieldOut
    if not ok then
        printf ""
    ok


[<PropertyTestAttribute>]
let ``field write-read roundtrip`` (fieldIn:FIXField) =
    let bs = Array.zeroCreate<byte> (1024 * 64)
    WriteField bs 0 fieldIn |> ignore
    let _, fieldOut = ReadField 0 bs
    let ok = fieldIn = fieldOut
    if not ok then
        printf ""
    ok



let ReadField (ss:string) (pos:int) (expectedTag:byte[]) (bs:byte[]) readFunc = 
    let pos2, tag = FIXBufUtils.readTag pos bs
    if tag <> expectedTag then 
        let msg = sprintf "when reading %s: expected tag: %A, actual: %A" ss expectedTag tag
        failwith msg
    let pos3, fld = readFunc pos2 bs
    pos3, fld


let inline ReadOptionalField (pos:int) (expectedTag:byte[]) (bs:byte[]) readFunc = 
    let pos2, tag = FIXBufUtils.readTag pos bs
    if tag = expectedTag then 
        let pos3, fld = readFunc pos2 bs
        pos3, Some fld
    else
        pos, None   // return the original pos, the next readoptional will re-read it



//let ReadNoCapacitiesGrp (pos:int) (bs:byte []) : int * NoCapacitiesGrp  =
//    let pos, orderCapacity = ReadField "ReadNoCapacities" pos "528"B bs Fix44.FieldReadFuncs.ReadOrderCapacity
//    let pos, orderRestrictions = ReadOptionalField pos "529"B bs Fix44.FieldReadFuncs.ReadOrderRestrictions
//    let pos, orderCapacityQty = ReadField "ReadNoCapacities" pos "863"B bs Fix44.FieldReadFuncs.ReadOrderCapacityQty
//    let grp = 
//        {
//            OrderCapacity = orderCapacity
//            OrderRestrictions = orderRestrictions
//            OrderCapacityQty = orderCapacityQty
//        }
//    pos, grp

// contains a single required component
let ReadNoStrikesGrp (pos:int) (bs:byte []) : int * NoStrikesGrp  =
    let pos, instrument = Fix44.CompoundItemReadFuncs.ReadInstrument pos bs
    let ci:NoStrikesGrp = {
            Instrument = instrument
    }
    pos, ci



[<PropertyTestAttribute>]
let ``NoCapacitiesGrp write-read roundtrip`` (grp:NoCapacitiesGrp) =
    printfn "%A" grp
    let bs = Array.zeroCreate<byte> (1024 * 16)
    let endPos = WriteNoCapacitiesGrp  bs 0 grp
    let posOut, grpOut = Fix44.CompoundItemReadFuncs.ReadNoCapacitiesGrp 0 bs
    let ok = endPos = posOut
    // test<@ endPos = posOut @>
    grp = grpOut










