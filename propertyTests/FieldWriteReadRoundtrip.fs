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
        MaxTest = 10000,
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
    let pos, side = ReadField "ReadTradeCaptureReportNoSidesGrp" pos "54"B bs Fix44.FieldReadFuncs.ReadSide 
    let pos, orderID = ReadField "ReadTradeCaptureReportNoSidesGrp" pos "37"B bs Fix44.FieldReadFuncs.ReadOrderID
    let pos, secondaryOrderID = ReadOptionalField pos "198"B bs Fix44.FieldReadFuncs.ReadSecondaryOrderID
    let pos, clOrdID = ReadOptionalField pos "11"B bs Fix44.FieldReadFuncs.ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "198"B bs Fix44.FieldReadFuncs.ReadSecondaryClOrdID
    let pos, listID = ReadOptionalField pos "66"B bs Fix44.FieldReadFuncs.ReadListID
    //let pos, parties = ReadOptionalField pos ""B bs Fix44.FieldReadFuncs.ReadParties // component
    let pos, account = ReadOptionalField pos "1"B bs Fix44.FieldReadFuncs.ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "660"B bs Fix44.FieldReadFuncs.ReadAcctIDSource
    let pos, accountType = ReadOptionalField pos "581"B bs Fix44.FieldReadFuncs.ReadAccountType
    let pos, processCode = ReadOptionalField pos "81"B bs Fix44.FieldReadFuncs.ReadProcessCode
    let pos, oddLot = ReadOptionalField pos "575"B bs Fix44.FieldReadFuncs.ReadOddLot
    //let pos, noClearingInstructionsGrp = ReadOptionalField pos "576"B bs Fix44.FieldReadFuncs.ReadNoClearingInstructionsGrp
    let pos, clearingFeeIndicator = ReadOptionalField pos "635"B bs Fix44.FieldReadFuncs.ReadClearingFeeIndicator
    let pos, tradeInputSource = ReadOptionalField pos "578"B bs Fix44.FieldReadFuncs.ReadTradeInputSource
    let pos, tradeInputDevice = ReadOptionalField pos "579"B bs Fix44.FieldReadFuncs.ReadTradeInputDevice
    let pos, orderInputDevice = ReadOptionalField pos "821"B bs Fix44.FieldReadFuncs.ReadOrderInputDevice
    let pos, currency = ReadOptionalField pos "918"B bs Fix44.FieldReadFuncs.ReadCurrency
    let pos, complianceID = ReadOptionalField pos "376"B bs Fix44.FieldReadFuncs.ReadComplianceID
    let pos, solicitedFlag = ReadOptionalField pos "377"B bs Fix44.FieldReadFuncs.ReadSolicitedFlag
    let pos, orderCapacity = ReadOptionalField pos "528"B bs Fix44.FieldReadFuncs.ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField pos "529"B bs Fix44.FieldReadFuncs.ReadOrderRestrictions
    let pos, custOrderCapacity = ReadOptionalField pos "582"B bs Fix44.FieldReadFuncs.ReadCustOrderCapacity
    let pos, ordType = ReadOptionalField pos "40"B bs Fix44.FieldReadFuncs.ReadOrdType
    let pos, execInst = ReadOptionalField pos "18"B bs Fix44.FieldReadFuncs.ReadExecInst
    let pos, transBkdTime = ReadOptionalField pos "483"B bs Fix44.FieldReadFuncs.ReadTransBkdTime
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    let pos, timeBracket = ReadOptionalField pos "943"B bs Fix44.FieldReadFuncs.ReadTimeBracket
//    let pos, commissionData = ReadOptionalField pos "12"B bs Fix44.FieldReadFuncs.ReadCommissionData // component
    let pos, grossTradeAmt = ReadOptionalField pos "381"B bs Fix44.FieldReadFuncs.ReadGrossTradeAmt
    let pos, numDaysInterest = ReadOptionalField pos "157"B bs Fix44.FieldReadFuncs.ReadNumDaysInterest
    let pos, exDate = ReadOptionalField pos "230"B bs Fix44.FieldReadFuncs.ReadExDate
    let pos, accruedInterestRate = ReadOptionalField pos "158"B bs Fix44.FieldReadFuncs.ReadAccruedInterestRate
    let pos, accruedInterestAmt = ReadOptionalField pos "159"B bs Fix44.FieldReadFuncs.ReadAccruedInterestAmt
    let pos, interestAtMaturity = ReadOptionalField pos "738"B bs Fix44.FieldReadFuncs.ReadInterestAtMaturity
    let pos, endAccruedInterestAmt = ReadOptionalField pos "920"B bs Fix44.FieldReadFuncs.ReadEndAccruedInterestAmt
    let pos, startCash = ReadOptionalField pos "921"B bs Fix44.FieldReadFuncs.ReadStartCash
    let pos, endCash = ReadOptionalField pos "922"B bs Fix44.FieldReadFuncs.ReadEndCash
    let pos, concession = ReadOptionalField pos "238"B bs Fix44.FieldReadFuncs.ReadConcession
    let pos, totalTakedown = ReadOptionalField pos "237"B bs Fix44.FieldReadFuncs.ReadTotalTakedown
    let pos, netMoney = ReadOptionalField pos "118"B bs Fix44.FieldReadFuncs.ReadNetMoney
    let pos, settlCurrAmt = ReadOptionalField pos "119"B bs Fix44.FieldReadFuncs.ReadSettlCurrAmt
    let pos, settlCurrency = ReadOptionalField pos "120"B bs Fix44.FieldReadFuncs.ReadSettlCurrency
    let pos, settlCurrFxRate = ReadOptionalField pos "155"B bs Fix44.FieldReadFuncs.ReadSettlCurrFxRate
    let pos, settlCurrFxRateCalc = ReadOptionalField pos "156"B bs Fix44.FieldReadFuncs.ReadSettlCurrFxRateCalc
    let pos, positionEffect = ReadOptionalField pos "564"B bs Fix44.FieldReadFuncs.ReadPositionEffect
    let pos, text = ReadOptionalField pos "58"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs Fix44.FieldReadFuncs.ReadEncodedText // compound field
    let pos, sideMultiLegReportingType = ReadOptionalField pos "752"B bs Fix44.FieldReadFuncs.ReadSideMultiLegReportingType
    //let pos, noContAmtsGrp = ReadOptionalField pos "518"B bs Fix44.FieldReadFuncs.ReadNoContAmtsGrp // a group #####
//    let pos, stipulations = ReadOptionalField pos "683"B bs Fix44.FieldReadFuncs.ReadStipulations // component
//    let pos, noMiscFeesGrp = ReadOptionalField pos "136"B bs Fix44.FieldReadFuncs.ReadNoMiscFeesGrp // group
    let pos, exchangeRule = ReadOptionalField pos "825"B bs Fix44.FieldReadFuncs.ReadExchangeRule
    let pos, tradeAllocIndicator = ReadOptionalField pos "826"B bs Fix44.FieldReadFuncs.ReadTradeAllocIndicator
    let pos, preallocMethod = ReadOptionalField pos "591"B bs Fix44.FieldReadFuncs.ReadPreallocMethod
    let pos, allocID = ReadOptionalField pos "672"B bs Fix44.FieldReadFuncs.ReadAllocID
    let grp = 
        {
            Side = side
            OrderID = orderID
            SecondaryOrderID = secondaryOrderID
            ClOrdID = clOrdID
            SecondaryClOrdID = secondaryClOrdID
            ListID = listID
            Parties = None //parties
            Account = account
            AcctIDSource = acctIDSource
            AccountType = accountType
            ProcessCode = processCode
            OddLot = oddLot
            NoClearingInstructionsGrp = None// noClearingInstructionsGrp
            ClearingFeeIndicator = clearingFeeIndicator
            TradeInputSource = tradeInputSource
            TradeInputDevice = tradeInputDevice
            OrderInputDevice = orderInputDevice
            Currency = currency
            ComplianceID = complianceID
            SolicitedFlag = solicitedFlag
            OrderCapacity = orderCapacity
            OrderRestrictions = orderRestrictions
            CustOrderCapacity = custOrderCapacity
            OrdType = ordType
            ExecInst = execInst
            TransBkdTime = transBkdTime
            TradingSessionID = tradingSessionID
            TradingSessionSubID = tradingSessionSubID
            TimeBracket = timeBracket
            CommissionData = None //commissionData
            GrossTradeAmt = grossTradeAmt
            NumDaysInterest = numDaysInterest
            ExDate = exDate
            AccruedInterestRate = accruedInterestRate
            AccruedInterestAmt = accruedInterestAmt
            InterestAtMaturity = interestAtMaturity
            EndAccruedInterestAmt = endAccruedInterestAmt
            StartCash = startCash
            EndCash = endCash
            Concession = concession
            TotalTakedown = totalTakedown
            NetMoney = netMoney
            SettlCurrAmt = settlCurrAmt
            SettlCurrency = settlCurrency
            SettlCurrFxRate = settlCurrFxRate
            SettlCurrFxRateCalc = settlCurrFxRateCalc
            PositionEffect = positionEffect
            Text = text
            EncodedText = encodedText
            SideMultiLegReportingType = sideMultiLegReportingType
            NoContAmtsGrp = None // noContAmtsGrp
            Stipulations = None //stipulations
            NoMiscFeesGrp = None //noMiscFeesGrp
            ExchangeRule = exchangeRule
            TradeAllocIndicator = tradeAllocIndicator
            PreallocMethod = preallocMethod
            AllocID = allocID
        }
    pos, grp



[<PropertyTestAttribute>]
let ``TradeCaptureReport_NoSidesGrp write-read roundtrip`` (grp:TradeCaptureReport_NoSidesGrp) =
    printfn "%A" grp
    let bs = Array.zeroCreate<byte> (1024 * 16)
    let endPos = WriteTradeCaptureReport_NoSidesGrp  bs 0 grp
    let posOut, grpOut = ReadTradeCaptureReportNoSidesGrp 0 bs
    let allRead = endPos = posOut
    //test<@ endPos = posOut @>
    grp = grpOut




let ReadNoCapacitiesGrp pos (bs:byte[]) =
    let pos, orderCapacity      = ReadField "ReadNoCapacitiesGrp" pos "528"B bs Fix44.FieldReadFuncs.ReadOrderCapacity 
    let pos, orderRestrictions  = ReadOptionalField pos "529"B bs Fix44.FieldReadFuncs.ReadOrderRestrictions
    let pos, orderCapacityQty   = ReadField "ReadNoCapacitiesGrp" pos "863"B bs Fix44.FieldReadFuncs.ReadOrderCapacityQty
    let grp = 
        {
            OrderCapacity = orderCapacity
            OrderRestrictions = orderRestrictions
            OrderCapacityQty = orderCapacityQty
        }
    pos, grp




[<PropertyTestAttribute>]
let ``NoCapacitiesGrp write-read roundtrip`` (grp:NoCapacitiesGrp) =
    printfn "%A" grp
    let bs = Array.zeroCreate<byte> (1024 * 16)
    let endPos = WriteNoCapacitiesGrp  bs 0 grp
    let posOut, grpOut = ReadNoCapacitiesGrp 0 bs
    let ok = endPos = posOut
    // test<@ endPos = posOut @>
    grp = grpOut










