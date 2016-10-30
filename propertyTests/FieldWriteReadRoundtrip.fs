module FieldWriteReadRoundtrip

open FsCheck
open FsCheck.Xunit

open Fix44.FieldDU

open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs

// strings stored in FIX do not contain field terminators, 
//let genAlphaChar = Gen.choose(32,255) |> Gen.map char 
let genAlphaChar = Gen.choose(65,127) |> Gen.map char 
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



let ReadTradeCaptureReportNoSidesGrp pos (bs:byte[])  =
    let pos, tag = FIXBufUtils.readTag pos bs
    let pos, side = Fix44.FieldReadFuncs.ReadSide (pos+1) bs
    let pos, tag = FIXBufUtils.readTag pos bs
    let pos, orderID = Fix44.FieldReadFuncs.ReadOrderID (pos+1) bs
    //let pos, SecondaryOrderID = OptionalTagLookAhead tagSecOrderID ReadSecondaryOrderID
    let grp = 
        {
            Side = side
            OrderID = orderID    //#### state monad to thread thru the updating pos?? 
            SecondaryOrderID = None // : SecondaryOrderID option
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

    grp = grp