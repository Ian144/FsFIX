(*
 * Copyright (C) 2016-2017 Ian Spratt <ian144@hotmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301, USA.
 *
 *)
 
module BenchMsgs

open Fix44.Fields
open Fix44.CompoundItems
open Fix44.CompoundItemFactoryFuncs
open Fix44.Messages
open Fix44.MessageFactoryFuncs



let logonMsg = 
    let mkRawData = NonEmptyByteArray.Make >> RawData
    {
        EncryptMethod = EncryptMethod.NoneOther
        HeartBtInt = HeartBtInt.HeartBtInt 30
        RawData = "some data, some more data"B |> mkRawData |> Option.Some
        ResetSeqNumFlag = ResetSeqNumFlag.ResetSeqNumFlag false |> Option.Some
        NextExpectedMsgSeqNum = NextExpectedMsgSeqNum.NextExpectedMsgSeqNum 99u |> Option.Some
        MaxMessageSize = MaxMessageSize.MaxMessageSize 256u |> Option.Some
        NoMsgTypesGrp = Option.None
        TestMessageIndicator = TestMessageIndicator.TestMessageIndicator true |> Option.Some
        Username = Some (Username "fred blogs")
        Password = Some (Password "sdlkjfsdkj")
    }



let quoteStatusRequestIncGroup = 
    let qsr = MkQuoteStatusRequest(
                MkInstrument (Fix44.Fields.Symbol "ABCDE"),
                MkFinancingDetails (),
                MkParties () )    
    let sToOptLegSym = LegSymbolSfx >> Some 
    let legA = {    MkInstrumentLegFG (LegSymbol "BCDEF") with LegSymbolSfx = "PQRS" |> sToOptLegSym }
    let legB = {    MkInstrumentLegFG (LegSymbol "CDEFG") with LegSymbolSfx = "QRST" |> sToOptLegSym }
    let legC = {    MkInstrumentLegFG (LegSymbol "DEFGH") with LegSymbolSfx = "RSTU" |> sToOptLegSym }
    let legsGrp = [legA; legB; legC] |> List.map MkNoLegsGrp |> Some
    {qsr with NoLegsGrp = legsGrp}


let quoteStatusRequestIncNestedGroup = 
    let qsr = MkQuoteStatusRequest(
                MkInstrument (Fix44.Fields.Symbol "ABCDE"),
                MkFinancingDetails (),
                MkParties () )

    let sToOptLegSecAltIdSrc = LegSecurityAltIDSource >> Some
    let innerGrp1 = { MkNoLegSecurityAltIDGrp (LegSecurityAltID "12345") with LegSecurityAltIDSource = sToOptLegSecAltIdSrc "QWERTYU" }
    let innerGrp2 = { MkNoLegSecurityAltIDGrp (LegSecurityAltID "23456") with LegSecurityAltIDSource = sToOptLegSecAltIdSrc "ASDFGHJ" }
    let innerGrp3 = { MkNoLegSecurityAltIDGrp (LegSecurityAltID "34567") with LegSecurityAltIDSource = sToOptLegSecAltIdSrc "ZXCVBNM" }
    let innerGrp4 = { MkNoLegSecurityAltIDGrp (LegSecurityAltID "45678") with LegSecurityAltIDSource = sToOptLegSecAltIdSrc "POIUYTR" }

    let sToOptLegSym = LegSymbolSfx >> Some 
    let legA = {    MkInstrumentLegFG (LegSymbol "BCDEF") 
                    with 
                        LegSymbolSfx = "PQRS" |> sToOptLegSym 
                        NoLegSecurityAltIDGrp  =  [innerGrp1;innerGrp2] |> Some  }
    
    let legB = {    MkInstrumentLegFG (LegSymbol "CDEFG") 
                    with 
                        LegSymbolSfx = "QRST" |> sToOptLegSym 
                        NoLegSecurityAltIDGrp  =  [innerGrp3] |> Some  }

    let legC = {    MkInstrumentLegFG (LegSymbol "DEFGH") 
                    with 
                        LegSymbolSfx = "RSTU" |> sToOptLegSym
                        NoLegSecurityAltIDGrp  =  [innerGrp4] |> Some  }
    
    let legsGrp = [legA; legB; legC] |> List.map MkNoLegsGrp |> Some
    {qsr with NoLegsGrp = legsGrp}



let marketDataRequest =

//  quickFix Java vs the equivalent fsFix F#
//    MDReqID reqId = new MDReqID("MDRQ-" + String.valueOf(System.currentTimeMillis()));
//    MarketDepth depthType = new MarketDepth(1);
//    MDUpdateType updateType = new MDUpdateType(MDUpdateType.INCREMENTAL_REFRESH);
//    MarketDataRequest mdr = new MarketDataRequest(reqId, subscriptionType, depthType);
//    mdr.setField(updateType);
//    MarketDataRequest.NoRelatedSym instruments = new MarketDataRequest.NoRelatedSym();
//    instruments.set(new Symbol(currencyPair));
//    mdr.addGroup(instruments);
//    mdr.setField(new NoMDEntryTypes(2));
//    MarketDataRequest.NoMDEntryTypes group = new MarketDataRequest.NoMDEntryTypes();
//    group.set(new MDEntryType(MDEntryType.BID));
//    group.set(new MDEntryType(MDEntryType.OFFER));
//    mdr.addGroup(group);
    let ms = System.DateTimeOffset.Now.ToUnixTimeMilliseconds()
    let mdr = MkMarketDataRequest(
                MDReqID (sprintf "MDRQ-%d" ms),
                SubscriptionRequestType.SnapshotPlusUpdates,
                MarketDepth 1,
                [MDEntryType.Bid; MDEntryType.Offer] |> List.map MkNoMDEntryTypesGrp,
                [MkInstrument (Fix44.Fields.Symbol "EUR/USD")] |> List.map MkMarketDataRequestNoRelatedSymGrp
                )
    
    mdr



// automatically generated by fscheck, hence the rather wacky values
let newOrderMultileg:NewOrderMultileg =

    let localMktDate = LocalMktDate.MakeLocalMktDate(2017,01,22)
    let monthYear = MonthYear.MakeMonthYear.Make(2017,01,MonthYear.W1)
    let utcTimeStamp = UTCDateTime.MakeUTCTimestamp.Make(2017, 01, 22, 06, 54, 00)

    let instrument: Instrument =
         {Symbol = (Fix44.Fields.Symbol "RSWQE")
          SymbolSfx = Some WhenIssued
          SecurityID = Some (SecurityID "FJXY")
          SecurityIDSource = Some SecurityIDSource.Valoren
          NoSecurityAltIDGrp = Some []
          Product = None
          CFICode = Some (CFICode "WAUIJ")
          SecurityType = Some TreasuryInflationProtectedSecurities
          SecuritySubType = Some (SecuritySubType "JXYCWAL")
          MaturityMonthYear = Some (MaturityMonthYear monthYear)
          MaturityDate = Some (MaturityDate localMktDate)
          PutOrCall = Some PutOrCall.Put
          CouponPaymentDate = Some (CouponPaymentDate localMktDate)
          IssueDate = None
          RepoCollateralSecurityType = Some (RepoCollateralSecurityType "0") // quickfixJ
    //      RepoCollateralSecurityType = Some (RepoCollateralSecurityType 0) // quickfixN
          RepurchaseTerm = Some (RepurchaseTerm 1)
          RepurchaseRate = Some (RepurchaseRate -5534023222112865484.7M)
          Factor = Some (Factor 79228162477.370849433239945M)
          CreditRating = Some (CreditRating "ESTXRVJK")
          InstrRegistry = Some (InstrRegistry "YSWHLF")
          CountryOfIssue = Some (CountryOfIssue "IMGKYZT")
          StateOrProvinceOfIssue = None
          LocaleOfIssue = Some (LocaleOfIssue "VZNO")
          RedemptionDate = Some (RedemptionDate localMktDate)
          StrikePrice = Some (StrikePrice 79228162458924105376.710262785M)
          StrikeCurrency = Some (StrikeCurrency "CWKL")
          OptAttribute = Some (OptAttribute '4')
          ContractMultiplier = Some (ContractMultiplier -3689348814312413.5939M)
          CouponRate = Some (CouponRate -792281.625142643375807M)
          SecurityExchange = None
          Issuer = Some (Issuer "GHBFTU")
          EncodedIssuer ="aa"B |> NonEmptyByteArray.Make |> EncodedIssuer |> Some
          SecurityDesc = Some (SecurityDesc "QUOJDHBP")
          EncodedSecurityDesc = "aa"B |> NonEmptyByteArray.Make |> EncodedSecurityDesc |> Some
          Pool = Some (Pool "DRSWQEF")
          ContractSettlMonth = None
          CPProgram = Some (CPProgram -2)
          CPRegType = Some (CPRegType "UVZTX")
          NoEventsGrp = Some []
          DatedDate = Some (DatedDate localMktDate)
          InterestAccrualDate = Some (InterestAccrualDate localMktDate )
          }

    let msg =
       {ClOrdID = ClOrdID "PZXWQ"
        SecondaryClOrdID = Some (SecondaryClOrdID "EFZDRSMQ")
        ClOrdLinkID = None
        Parties = {NoPartyIDsGrp = Some []}
        TradeOriginationDate = Some (TradeOriginationDate localMktDate)
        TradeDate = Some (TradeDate localMktDate)
        Account = Some (Account "PKNOIWA")
        AcctIDSource = Some Tfm
        AccountType = Some AccountType.AccountIsCarriedOnNonCustomerSideOfBooks
        DayBookingInst = Some CanTriggerBookingWithoutReferenceToTheOrderInitiator
        BookingUnit = Some AggregatePartialExecutionsOnThisOrderAndBookOneTradePerOrder
        PreallocMethod = None
        AllocID = Some (AllocID "ZNOSMQBF")
        NewOrderMultilegNoAllocsGrp = Some []
        SettlType = Some TPlus5
        SettlDate = Some (SettlDate localMktDate)
        CashMargin = Some MarginOpen
        ClearingFeeIndicator = Some Firms106hAnd106j
        HandlInst = Some ManualOrder
        ExecInst = None
        MinQty = Some (MinQty 792281624589241053767102627.85M)
        MaxFloor = Some (MaxFloor 3.689348814312414M)
        ExDestination = Some (ExDestination "UYJN")
        NoTradingSessionsGrp = Some []
        ProcessCode = Some Regular
        Side = Lend
        Instrument = instrument
        NoUnderlyingsGrp = None
        PrevClosePx = Some (PrevClosePx -7922816249581759353.2719300611M)
        NewOrderMultilegNoLegsGrp = []
        LocateReqd = Some (LocateReqd false)
        TransactTime = TransactTime utcTimeStamp
        QtyType = Some Contracts
        OrderQtyData =
         {OrderQty = None
          CashOrderQty = Some (CashOrderQty -0.000000003689349M)
          OrderPercent = Some (OrderPercent -5534.023223401355674M)
          RoundingDirection = Some RoundDown
          RoundingModulus = Some (RoundingModulus 792281.624958175935327M)}
        OrdType = NextFundValuationPoint
        PriceType = None
        Price = Some (Fix44.Fields.Price 36.893488143124136M)
        StopPx = Some (StopPx 79228162477370849459009.748992M)
        Currency = Some (Fix44.Fields.Currency "USD")
        ComplianceID = Some (ComplianceID "NHVWAUY")
        SolicitedFlag = Some (SolicitedFlag true)
        IOIID = Some (IOIID "ALPJNB") // quickfixJ
    //    IOIid = Some (IOIid "ALPJNB") // quickfixN
        QuoteID = Some (QuoteID "KOCDXBP")
        TimeInForce = None
        EffectiveTime =
         Some (EffectiveTime utcTimeStamp)
        ExpireDate = Some (ExpireDate localMktDate)
        ExpireTime = Some (ExpireTime utcTimeStamp)
        GTBookingInst = Some AccumulateUntilVerballyNotifiedOtherwise
        CommissionData = {Commission = Some (Commission -79228.162495817593533M)
                          CommType = Some PercentageWaivedCashDiscount
                          CommCurrency = Some (CommCurrency "VZTHIMGU")
                          FundRenewWaiv = Some No}
        OrderCapacity = None
        OrderRestrictions = Some ForeignEntity
        CustOrderCapacity = Some AllOther
        ForexReq = Some (ForexReq true)
        SettlCurrency = Some (SettlCurrency "ZTXLMG")
        BookingType = Some RegularBooking
        Text = Some (Fix44.Fields.Text "MGBVZT")
        EncodedText = "aa"B |> NonEmptyByteArray.Make |> EncodedText |> Some
        PositionEffect = Some Close
        CoveredOrUncovered = Some Covered
        MaxShow = Some (MaxShow -792281.624773708494590M)
        PegInstructions =
         {PegOffsetValue = Some (PegOffsetValue -79228162477370849.454714781696M)
          PegMoveType = None
          PegOffsetType = Some PegOffsetType.BasisPoints
          PegLimitType = Some PegLimitType.OrWorse
          PegRoundDirection = Some PegRoundDirection.MorePassive
          PegScope = Some PegScope.Local}
        DiscretionInstructions =
         {DiscretionInst = Some RelatedToVwap
          DiscretionOffsetValue =
           Some (DiscretionOffsetValue -79228162514264337580659048.449M)
          DiscretionMoveType = Some Fixed
          DiscretionOffsetType = Some Price
          DiscretionLimitType = Some OrBetter
          DiscretionRoundDirection = Some MoreAggressive
          DiscretionScope = Some Local}
        TargetStrategy = Some (TargetStrategy -3)
        TargetStrategyParameters = Some (TargetStrategyParameters "UOSMHBFZ")
        ParticipationRate = Some (ParticipationRate -55.340232221128655M)
        CancellationRights = Some NoExecutionOnly
        MoneyLaunderingStatus = Some ExemptBelowTheLimit
        RegistID = Some (RegistID "EFJDHS")
        Designation = None
        MultiLegRptTypeReq = Some ReportByMultilegSecurityAndByInstrumentLegsBelongingToTheMultilegSecurity}
    msg

