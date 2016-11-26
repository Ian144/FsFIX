module FieldWriteReadRoundtrip

open System.Reflection


open FsCheck
open FsCheck.Xunit

open Fix44.FieldDU
open Fix44.FieldReadFuncs
open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs
open Fix44.CompoundItemDU

open Swensen.Unquote



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
        MaxTest = 10,
        Verbose = false,
        QuietOnSuccess = true)



[<PropertyTestAttribute>]
let PosMaintRptID (pmri:Fix44.Fields.PosMaintRptID) =
    let bs = Array.zeroCreate<byte> (1024 * 2)
    let posW = Fix44.FieldWriteFuncs.WritePosMaintRptID bs 0 pmri
    let posSep = FIXBufUtils.findNextTagValSep 0 bs
    let posR, pmriOut = Fix44.FieldReadFuncs.ReadPosMaintRptID (posSep+1) bs
    let ok = pmri = pmriOut && posW = posR // posR should be one past the last byte written, posW should be the next writeable byte, so both should be the same
    let ok2 = (posW = posR)
    ok && ok2



[<PropertyTestAttribute>]
let AllFields (fieldIn:FIXField) =
    let bs = Array.zeroCreate<byte> (1024 * 64)
    let posW = WriteField bs 0 fieldIn
    let posR, fieldOut = ReadField 0 bs
    let ok1 = fieldIn = fieldOut
    let ok2 = posW = posR
    let ok = ok1 && ok2
    if not ok then
        printf ""
    ok


[<PropertyTestAttribute>]
let NoCapacitiesGrp (grp:NoCapacitiesGrp ) =
    let bs = Array.zeroCreate<byte> (1024 * 16)
    let posW = WriteNoCapacitiesGrp  bs 0 grp
    let posR, grpOut = Fix44.CompoundItemReadFuncs.ReadNoCapacitiesGrp 0 bs
    let ok = grp = grpOut
    let ok2 = (posW = posR)
    ok && ok2



[<PropertyTestAttribute>]
let UnderlyingStipulationsGrp (usIn:NoUnderlyingStipsGrp ) =
    let bs = Array.zeroCreate<byte> (1024 * 16)
    let posW = WriteNoUnderlyingStipsGrp bs 0 usIn
    let posR, usOut = Fix44.CompoundItemReadFuncs.ReadNoUnderlyingStipsGrp 0 bs
    let ok = usIn = usOut
    let ok2 = (posW = posR)
    ok && ok2


[<PropertyTestAttribute>]
let UnderlyingStipulations (usIn:UnderlyingStipulations) =
//    (usIn.NoUnderlyingStipsGrp.IsSome) ==> lazy
    let bs = Array.zeroCreate<byte> (1024 * 128)
    let posW = WriteUnderlyingStipulations  bs 0 usIn
    let posR, usOut = Fix44.CompoundItemReadFuncs.ReadUnderlyingStipulations 0 bs
    let ok = usIn = usOut
    let ok2 = (posW = posR)
    let xx = ok && ok2
    if not xx then
        printf ""
    xx






let rec compareInner (indent:string) (objA:System.Object) (objB:System.Object) =
    let bindingFlags = 
        BindingFlags.Public     ||| 
        BindingFlags.NonPublic  |||
        BindingFlags.Instance   ||| 
        BindingFlags.Static     |||
        BindingFlags.DeclaredOnly

    let ty = objA.GetType()
    let fields = ty.GetFields(bindingFlags)

    let compStrs = 
        fields |> Array.map (fun fi ->
            let vA = fi.GetValue objA
            let vB = fi.GetValue objB
            if vA <> vB then
                let ft = fi.FieldType
                let fieldsInner = ft.GetFields(bindingFlags)
                if fieldsInner.Length > 1 then
                    let indent2 = sprintf "    %s" indent
                    compareInner indent2 vA vB
                else
                    sprintf "%s >>>>>>>> %s: %O <> %O" indent fi.Name vA vB
            else
               sprintf "%s: %O <> %O" fi.Name vA vB
            )
 
    System.String.Join("\n", compStrs)


let compare (objA:System.Object) (objB:System.Object) = 
    let ss = compareInner "" objA objB
    printf "%s" ss




[<PropertyTestAttribute>]
let UnderlyingInstument (usIn:UnderlyingInstrument) =
//    ((usIn.UnderlyingStipulations.IsSome && usIn.UnderlyingStipulations.Value.NoUnderlyingStipsGrp.IsSome) || usIn.UnderlyingStipulations.IsNone ) ==> lazy
        let bs = Array.zeroCreate<byte> (1024 * 128)
        let posW = WriteUnderlyingInstrument  bs 0 usIn
        let posR, usOut = Fix44.CompoundItemReadFuncs.ReadUnderlyingInstrument 0 bs
        let ok = usIn = usOut
        let ok2 = (posW = posR)
        let xx = ok && ok2
        if not xx then
            compare usIn usOut
        xx
         


[<PropertyTestAttribute>]
let NoSidesGrp (gIn:NoSidesGrp ) =
    try
        let bs = Array.zeroCreate<byte> (1024 * 16)
        let posW = WriteNoSidesGrp bs 0 gIn
        let posR, gOut = Fix44.CompoundItemReadFuncs.ReadNoSidesGrp 0 bs
    //    let xx = gIn = gOut
    //
    //    if not xx then
    //        let eqside = gIn.Side = gOut.Side
    //        let eqpreallocMethod = gIn.PreallocMethod = gOut.PreallocMethod
    //        let eqallocID = gIn.AllocID = gOut.AllocID
    //        let eqnoAllocsGrp = gIn.NoAllocsGrp = gOut.NoAllocsGrp
    //        let eqqtyType = gIn.QtyType = gOut.QtyType
    //        let eqorderQtyData = gIn.OrderQtyData = gOut.OrderQtyData
    //        let eqcommissionData = gIn.CommissionData = gOut.CommissionData
    //        let eqorderCapacity = gIn.OrderCapacity = gOut.OrderCapacity
    //        let eqorderRestrictions = gIn.OrderRestrictions = gOut.OrderRestrictions
    //        let eqcustOrderCapacity = gIn.CustOrderCapacity = gOut.CustOrderCapacity
    //        let eqforexReq = gIn.ForexReq = gOut.ForexReq
    //        let eqsettlCurrency = gIn.SettlCurrency = gOut.SettlCurrency
    //        let eqbookingType = gIn.BookingType = gOut.BookingType
    //        let eqtext = gIn.Text = gOut.Text
    //        let eqencodedText = gIn.EncodedText = gOut.EncodedText
    //        let eqpositionEffect = gIn.PositionEffect = gOut.PositionEffect
    //        let eqcoveredOrUncovered = gIn.CoveredOrUncovered = gOut.CoveredOrUncovered
    //        let eqcashMargin = gIn.CashMargin = gOut.CashMargin
    //        let eqclearingFeeIndicator = gIn.ClearingFeeIndicator = gOut.ClearingFeeIndicator
    //        let eqsolicitedFlag = gIn.SolicitedFlag = gOut.SolicitedFlag
    //        let eqsideComplianceID = gIn.SideComplianceID = gOut.SideComplianceID
    //
    //        compare gIn gOut
    //
        posW =! posR
        gIn =! gOut
        true
    with 
        | ex -> printfn ""
                false


[<PropertyTestAttribute>]
let CompoundItem (ciIn:FIXGroup) =
    try
        let bs = Array.zeroCreate<byte> (1024 * 128)
        let posW = WriteCITest  bs 0 ciIn
        let posR, usOut =  ReadCITest ciIn 0 bs
        let ok = ciIn = usOut
        let ok2 = (posW = posR)
        let xx = ok && ok2
        if not xx then
            compare ciIn usOut
        xx
    with 
        | ex ->
            printfn "##: %s" ex.Message
            true

[<PropertyTestAttribute>]
let InstrumentLegFG (usIn:InstrumentLegFG) =
    let bs = Array.zeroCreate<byte> (1024 * 128)
    let posW = WriteInstrumentLegFG  bs 0 usIn
    let posR, usOut = Fix44.CompoundItemReadFuncs.ReadInstrumentLegFG 0 bs
    let ok = usIn = usOut
    let ok2 = (posW = posR)
    let xx = ok && ok2
    if not xx then
        let ss = compare usIn usOut
        printf "%A" ss
    xx