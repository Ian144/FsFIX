module FieldWriteReadRoundtrip

open FsCheck
open FsCheck.Xunit

open Fix44.FieldDU

open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs

// strings stored in FIX do not contain field terminators, 
//let genAlphaChar = Gen.choose(32,255) |> Gen.map char 
let genAlphaChar = Gen.choose(65,90) |> Gen.map char 
let genAlphaCharArray = Gen.arrayOfLength 16 genAlphaChar 
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
        MaxTest = 100,
        Verbose = true,
        QuietOnSuccess = true)



[<PropertyTestAttribute>]
let ``write-read roundtrip`` (fieldIn:FIXField) =
    let bs = Array.zeroCreate<byte> 2048
    WriteField bs 0 fieldIn |> ignore
    let _, fieldOut = ReadField 0 bs
    fieldIn = fieldOut


let MakeNoNested2PartyIDs () = {
        NoNested2PartyIDsGrp.Nested2PartyID = None
        NoNested2PartyIDsGrp.Nested2PartyIDSource = None
        NoNested2PartyIDsGrp.Nested2PartyRole = None
        NoNested2PartySubIDsGrp = Some []
    }


let ReadField (ss:string) (pos:int) (expectedTag:byte[]) (bs:byte[]) readFunc = 
    let pos2, tag = FIXBufUtils.readTag pos bs
    if tag <> expectedTag then 
        let msg = sprintf "when reading %s: expected tag: %A, actual: %A" ss expectedTag tag
        failwith msg
    let pos3, fld = readFunc pos2 bs
    pos3, fld

// ####
// how do i get the tag? do readfuncs need to be tupled with thier tags?
// ReadOptionalField re-reads the tag each time it is called and returns None
let inline ReadOptionalField (pos:int) (expectedTag:byte[]) (bs:byte[]) readFunc = 
    let pos2, tag = FIXBufUtils.readTag pos bs
    if tag = expectedTag then 
        let pos3, fld = readFunc pos2 bs
        pos3, Some fld
    else
        pos, None   // return the original pos, the next readoptional will re-read it



let ReadTradeCaptureReportNoSidesGrp pos (bs:byte[]) =
    let pos, side       = ReadField "ReadTradeCaptureReportNoSidesGrp" pos "54"B bs Fix44.FieldReadFuncs.ReadSide 
    let pos, orderID    = ReadField "ReadTradeCaptureReportNoSidesGrp" pos "37"B bs Fix44.FieldReadFuncs.ReadOrderID
    let pos, secondaryOrderID = ReadOptionalField pos "198"B bs Fix44.FieldReadFuncs.ReadSecondaryOrderID
    let grp = 
        {
            Side = side
            OrderID = orderID
            SecondaryOrderID = secondaryOrderID
            ClOrdID = None // : ClOrdID option
            SecondaryClOrdID = None // : SecondaryClOrdID option
            ListID = None // : ListID option
            Parties = None // : Parties option // component
            Account = None // : Account option
            AcctIDSource = None // : AcctIDSource option
            AccountType = None // : AccountType option
            ProcessCode = None // : ProcessCode option
            OddLot = None // : OddLot option
            NoClearingInstructionsGrp = None // : NoClearingInstructionsGrp list option // group
            ClearingFeeIndicator = None // : ClearingFeeIndicator option
            TradeInputSource = None // : TradeInputSource option
            TradeInputDevice = None // : TradeInputDevice option
            OrderInputDevice = None // : OrderInputDevice option
            Currency = None // : Currency option
            ComplianceID = None // : ComplianceID option
            SolicitedFlag = None // : SolicitedFlag option
            OrderCapacity = None // : OrderCapacity option
            OrderRestrictions = None // : OrderRestrictions option
            CustOrderCapacity = None // : CustOrderCapacity option
            OrdType = None // : OrdType option
            ExecInst = None // : ExecInst option
            TransBkdTime = None // : TransBkdTime option
            TradingSessionID = None // : TradingSessionID option
            TradingSessionSubID = None // : TradingSessionSubID option
            TimeBracket = None // : TimeBracket option
            CommissionData = None // : CommissionData option // component
            GrossTradeAmt = None // : GrossTradeAmt option
            NumDaysInterest = None // : NumDaysInterest option
            ExDate = None // : ExDate option
            AccruedInterestRate = None // : AccruedInterestRate option
            AccruedInterestAmt = None // : AccruedInterestAmt option
            InterestAtMaturity = None // : InterestAtMaturity option
            EndAccruedInterestAmt = None // : EndAccruedInterestAmt option
            StartCash = None // : StartCash option
            EndCash = None // : EndCash option
            Concession = None // : Concession option
            TotalTakedown = None // : TotalTakedown option
            NetMoney = None // : NetMoney option
            SettlCurrAmt = None // : SettlCurrAmt option
            SettlCurrency = None // : SettlCurrency option
            SettlCurrFxRate = None // : SettlCurrFxRate option
            SettlCurrFxRateCalc = None // : SettlCurrFxRateCalc option
            PositionEffect = None // : PositionEffect option
            Text = None // : Text option
            EncodedText = None // : EncodedText option
            SideMultiLegReportingType = None // : SideMultiLegReportingType option
            NoContAmtsGrp = None // : NoContAmtsGrp list option // group
            Stipulations = None // : Stipulations option // component
            NoMiscFeesGrp = None // : NoMiscFeesGrp list option // group
            ExchangeRule = None // : ExchangeRule option
            TradeAllocIndicator = None // : TradeAllocIndicator option
            PreallocMethod = None // : PreallocMethod option
            AllocID = None // : AllocID option
        }
    pos, grp


[<PropertyTestAttribute>]
let ``TradeCaptureReport_NoSidesGrp write-read roundtrip`` (grp:TradeCaptureReport_NoSidesGrp) =
    printfn "%A" grp
    let bs = Array.zeroCreate<byte> (1024 * 16)
    let endPos = WriteTradeCaptureReport_NoSidesGrp  bs 0 grp

    let posOut, grpOut = ReadTradeCaptureReportNoSidesGrp 0 bs

    // test<@ endPos = posOut @>

    grp = grpOut