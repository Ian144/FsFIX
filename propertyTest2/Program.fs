open FsCheck
open Swensen.Unquote

open Fix44.FieldDU

open Fix44.FieldDU
//open Fix44.FieldReadFuncs
open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs
open Fix44.CompoundItemDU



let genAlphaChar = Gen.choose(32,255) |> Gen.map char 
//let genAlphaChar = Gen.choose(65,90) |> Gen.map char 
//let genAlphaCharArray = Gen.arrayOfLength 16 genAlphaChar 
let genAlphaString = 
        gen{
            let! len = Gen.choose(4, 64)
            let! chars = Gen.arrayOfLength len genAlphaChar
            return System.String chars
        }





type ArbOverrides() =
    static member String() = Arb.fromGen genAlphaString
//        Arb.Default.String()
//        |> Arb.filter (fun ss -> not (isNull ss) && ss.Length > 0 && StringIsAlpha(ss) )



Arb.register<ArbOverrides>() |> ignore




let bufSize = 1024 * 64 // so as not to go into the LOH



let propWriteReadPosMaintRptID (pmri:Fix44.Fields.PosMaintRptID) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = Fix44.FieldWriteFuncs.WritePosMaintRptID bs 0 pmri
    let posSep = FIXBufUtils.findNextTagValSep 0 bs
    let posR, pmriOut = Fix44.FieldReadFuncs.ReadPosMaintRptID (posSep+1) bs
    posW =! posR
    pmri =! pmriOut  




let propWriteReadFields (fieldIn:FIXField) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteField bs 0 fieldIn
    let posR, fieldOut = ReadField 0 bs
    posW =! posR
    fieldIn =! fieldOut  





let propWriteReadNoCapacitiesGrp (grpIn:NoCapacitiesGrp ) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteNoCapacitiesGrp  bs 0 grpIn
    let posR, grpOut = Fix44.CompoundItemReadFuncs.ReadNoCapacitiesGrp 0 bs
    posW =! posR
    grpIn =! grpOut  






let propWriteReadUnderlyingStipulationsGrp (usIn:NoUnderlyingStipsGrp ) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteNoUnderlyingStipsGrp bs 0 usIn
    let posR, usOut = Fix44.CompoundItemReadFuncs.ReadNoUnderlyingStipsGrp 0 bs
    posW =! posR
    usIn =! usOut



let propWriteReadUnderlyingStipulations (usIn:UnderlyingStipulations) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteUnderlyingStipulations  bs 0 usIn
    let posR, usOut = Fix44.CompoundItemReadFuncs.ReadUnderlyingStipulations 0 bs
    usIn =! usOut
    posW =! posR


let propWriteReadUnderlyingInstument (usIn:UnderlyingInstrument) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteUnderlyingInstrument  bs 0 usIn
    let posR, usOut = Fix44.CompoundItemReadFuncs.ReadUnderlyingInstrument 0 bs
    posW =! posR
    usIn =! usOut         





let propWriteReadNoSidesGrp (gIn:NoSidesGrp ) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteNoSidesGrp bs 0 gIn
    let posR, gOut = Fix44.CompoundItemReadFuncs.ReadNoSidesGrp 0 bs
    posW =! posR
    gIn =! gOut





let propWriteReadCompoundItem (ciIn:FIXGroup) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteCITest  bs 0 ciIn
    let posR, ciOut =  ReadCITest ciIn 0 bs
    posW =! posR
    ciIn =! ciOut




let propWriteReadInstrumentLegFG (usIn:InstrumentLegFG) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteInstrumentLegFG  bs 0 usIn
    let posR, usOut = Fix44.CompoundItemReadFuncs.ReadInstrumentLegFG 0 bs
    posW =! posR
    usIn =! usOut






let config = {  Config.Quick with 
//                    EveryShrink = (sprintf "%A" )
//                    Replay = Some (Random.StdGen (310046944,296129814))
//                    StartSize = 64
                    EndSize = 8

//                    MaxFail = 10000
                    MaxTest = 100 }



#nowarn "52"
let WaitForExitCmd () = 
    while stdin.Read() <> 88 do // 88 is 'X'
        ()




//Check.One (config, propWriteReadPosMaintRptID)
Check.One (config, propWriteReadFields)
Check.One (config, propWriteReadNoCapacitiesGrp)
Check.One (config, propWriteReadUnderlyingStipulationsGrp)
Check.One (config, propWriteReadUnderlyingStipulations)
Check.One (config, propWriteReadUnderlyingInstument)
Check.One (config, propWriteReadNoSidesGrp)
Check.One (config, propWriteReadCompoundItem)
Check.One (config, propWriteReadInstrumentLegFG)

