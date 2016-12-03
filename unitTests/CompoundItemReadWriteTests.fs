module CompoundItemReadWriteTests

open Xunit
open Swensen.Unquote

open Fix44.Fields
open Fix44.CompoundItems
open Fix44.CompoundItemReadFuncs
open Fix44.CompoundItemWriteFuncs
open Fix44.Messages
open Fix44.MsgReadFuncs
open Fix44.MsgWriteFuncs




[<Fact>]
let MassQuoteNoQuoteEntriesGrp () =

    let bs = Array.zeroCreate<byte> 1024

    let xIn:MassQuoteNoQuoteEntriesGrp =
                 {  QuoteEntryID = QuoteEntryID "GKCO"
                    Instrument = None
                    NoLegsGrp = None
                    BidPx = None
                    OfferPx = None
                    BidSize = None
                    OfferSize = None
                    ValidUntilTime = None
                    BidSpotRate = None
                    OfferSpotRate = None
                    BidForwardPoints = None
                    OfferForwardPoints = None
                    MidPx = None
                    BidYield = None
                    MidYield = None
                    OfferYield = None
                    TransactTime = None
                    TradingSessionID = None
                    TradingSessionSubID = None
                    SettlDate = None
                    OrdType = None
                    SettlDate2 = None
                    OrderQty2 = None
                    BidForwardPoints2 = None
                    OfferForwardPoints2 = None
                    Currency = None    } 

    let posW = WriteMassQuoteNoQuoteEntriesGrp  bs 0 xIn
    let posR, xOut = ReadMassQuoteNoQuoteEntriesGrp 0 bs
    posW =! posR
    xIn =! xOut





//[<Fact>]
//let MsgNewOrderCross () =
//
//    let bs = Array.zeroCreate<byte> (1024 * 8)
//
//
//    let orderQtyData = 
//            {   OrderQty          = None
//                CashOrderQty      = None
//                OrderPercent      = None
//                RoundingDirection = None
//                RoundingModulus   = None}
//    
//    let commissionData:CommissionData = 
//            {   Commission      = None
//                CommType        = None
//                CommCurrency    = None
//                FundRenewWaiv   = None }
//
//    let noSidesGrp:NoSidesGrp = 
//            {   Side = CrossShortExempt
//                ClOrdID = ClOrdID "QUOCDH"
//                SecondaryClOrdID = None
//                ClOrdLinkID = None
//                NoPartyIDsGrp = None
//                TradeOriginationDate = None
//                TradeDate = None
//                Account = None
//                AcctIDSource = None
//                AccountType = None
//                DayBookingInst = None
//                BookingUnit = None
//                PreallocMethod = None
//                AllocID = None
//                NoAllocsGrp = None
//                QtyType = None
//                OrderQtyData = orderQtyData
//                CommissionData = commissionData
//                OrderCapacity = None
//                OrderRestrictions = None
//                CustOrderCapacity = None
//                ForexReq = None
//                SettlCurrency = None
//                BookingType = None
//                Text = None
//                EncodedText = None
//                PositionEffect = None
//                CoveredOrUncovered = None
//                CashMargin = None
//                ClearingFeeIndicator = None
//                SolicitedFlag = None
//                SideComplianceID = None
//               }
//
//    let instrument:Instrument = 
//                      {Symbol = (Fix44.Fields.Symbol "EFJDH")
//                       SymbolSfx = None
//                       SecurityID = None
//                       SecurityIDSource = None
//                       NoSecurityAltIDGrp = None
//                       Product = None
//                       CFICode = None
//                       SecurityType = None
//                       SecuritySubType = None
//                       MaturityMonthYear = None
//                       MaturityDate = None
//                       PutOrCall = None
//                       CouponPaymentDate = None
//                       IssueDate = None
//                       RepoCollateralSecurityType = None
//                       RepurchaseTerm = None
//                       RepurchaseRate = None
//                       Factor = None
//                       CreditRating = None
//                       InstrRegistry = None
//                       CountryOfIssue = None
//                       StateOrProvinceOfIssue = None
//                       LocaleOfIssue = None
//                       RedemptionDate = None
//                       StrikePrice = None
//                       StrikeCurrency = None
//                       OptAttribute = None
//                       ContractMultiplier = None
//                       CouponRate = None
//                       SecurityExchange = None
//                       Issuer = None
//                       EncodedIssuer = None
//                       SecurityDesc = None
//                       EncodedSecurityDesc = None
//                       Pool = None
//                       ContractSettlMonth = None
//                       CPProgram = None
//                       CPRegType = None
//                       NoEventsGrp = None
//                       DatedDate = None
//                       InterestAccrualDate = None}
//
//
//    let msg:NewOrderCross =
//        {CrossID = CrossID "JUYSWK"
//         CrossType = CrossTradeWhichIsExecutedCompletelyOrNot
//         CrossPrioritization = BuySideIsPrioritized
//         NoSidesGrp = OneOrTwo.One noSidesGrp
//         Instrument = instrument
//         NoUnderlyingsGrp = None
//         NoLegsGrp = None
//         SettlType = None
//         SettlDate = None
//         HandlInst = None
//         ExecInst = None
//         MinQty = None
//         MaxFloor = None
//         ExDestination = None
//         NoTradingSessionsGrp = None
//         ProcessCode = None
//         PrevClosePx = None
//         LocateReqd = None
//         TransactTime = TransactTime "MGKV"
//         Stipulations = None
//         OrdType = OnBasis
//         PriceType = None
//         Price = None
//         StopPx = None
//         SpreadOrBenchmarkCurveData = None
//         YieldData = None
//         Currency = None
//         ComplianceID = None
//         IOIid = None
//         QuoteID = None
//         TimeInForce = None
//         EffectiveTime = None
//         ExpireDate = None
//         ExpireTime = None
//         GTBookingInst = None
//         MaxShow = None
//         PegInstructions =  {   PegOffsetValue = None
//                                PegMoveType = None
//                                PegOffsetType = None
//                                PegLimitType = None
//                                PegRoundDirection = None
//                                PegScope = None}
//         DiscretionInstructions = None
//         TargetStrategy = None
//         TargetStrategyParameters = None
//         ParticipationRate = None
//         CancellationRights = None
//         MoneyLaunderingStatus = None
//         RegistID = None
//         Designation = None}
//
//    let posW = Fix44.MsgWriteFuncs.WriteNewOrderCross bs 0 msg
//    let posR, msgOut = Fix44.MsgReadFuncs.ReadNewOrderCross 0 bs
//    posW =! posR
//    msg =! msgOut