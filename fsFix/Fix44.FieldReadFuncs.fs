module Fix44.FieldReadFuncs


open System
open System.IO
open Fix44.Fields
open Conversions
open FieldFuncs


let ReadAccount (pos:int) (bs:byte[]) : (int*Account) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Account.Account


let ReadAdvId (pos:int) (bs:byte[]) : (int*AdvId) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AdvId.AdvId


let ReadAdvRefID (pos:int) (bs:byte[]) : (int*AdvRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AdvRefID.AdvRefID


let ReadAdvSide (pos:int) (bs:byte[]) : (int * AdvSide) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"B"B -> AdvSide.Buy
        |"S"B -> AdvSide.Sell
        |"X"B -> AdvSide.Cross
        |"T"B -> AdvSide.Trade
        | x -> failwith (sprintf "ReadAdvSide unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadAdvTransType (pos:int) (bs:byte[]) : (int * AdvTransType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"N"B -> AdvTransType.New
        |"C"B -> AdvTransType.Cancel
        |"R"B -> AdvTransType.Replace
        | x -> failwith (sprintf "ReadAdvTransType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadAvgPx (pos:int) (bs:byte[]) : (int*AvgPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) AvgPx.AvgPx


let ReadBeginSeqNo (pos:int) (bs:byte[]) : (int*BeginSeqNo) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) BeginSeqNo.BeginSeqNo


let ReadBeginString (pos:int) (bs:byte[]) : (int*BeginString) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) BeginString.BeginString


let ReadBodyLength (pos:int) (bs:byte[]) : (int*BodyLength) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) BodyLength.BodyLength


let ReadCheckSum (pos:int) (bs:byte[]) : (int*CheckSum) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CheckSum.CheckSum


let ReadClOrdID (pos:int) (bs:byte[]) : (int*ClOrdID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ClOrdID.ClOrdID


let ReadCommission (pos:int) (bs:byte[]) : (int*Commission) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) Commission.Commission


let ReadCommType (pos:int) (bs:byte[]) : (int * CommType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> CommType.PerUnit
        |"2"B -> CommType.Percentage
        |"3"B -> CommType.Absolute
        |"4"B -> CommType.PercentageWaivedCashDiscount
        |"5"B -> CommType.PercentageWaivedEnhancedUnits
        |"6"B -> CommType.PointsPerBondOrOrContract
        | x -> failwith (sprintf "ReadCommType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCumQty (pos:int) (bs:byte[]) : (int*CumQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) CumQty.CumQty


let ReadCurrency (pos:int) (bs:byte[]) : (int*Currency) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Currency.Currency


let ReadEndSeqNo (pos:int) (bs:byte[]) : (int*EndSeqNo) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) EndSeqNo.EndSeqNo


let ReadExecID (pos:int) (bs:byte[]) : (int*ExecID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ExecID.ExecID


let ReadExecInst (pos:int) (bs:byte[]) : (int * ExecInst) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> ExecInst.NotHeld
        |"2"B -> ExecInst.Work
        |"3"B -> ExecInst.GoAlong
        |"4"B -> ExecInst.OverTheDay
        |"5"B -> ExecInst.Held
        |"6"B -> ExecInst.ParticipateDontInitiate
        |"7"B -> ExecInst.StrictScale
        |"8"B -> ExecInst.TryToScale
        |"9"B -> ExecInst.StayOnBidside
        |"0"B -> ExecInst.StayOnOfferside
        |"A"B -> ExecInst.NoCross
        |"B"B -> ExecInst.OkToCross
        |"C"B -> ExecInst.CallFirst
        |"D"B -> ExecInst.PercentOfVolume
        |"E"B -> ExecInst.DoNotIncrease
        |"F"B -> ExecInst.DoNotReduce
        |"G"B -> ExecInst.AllOrNone
        |"H"B -> ExecInst.ReinstateOnSystemFailure
        |"I"B -> ExecInst.InstitutionsOnly
        |"J"B -> ExecInst.ReinstateOnTradingHalt
        |"K"B -> ExecInst.CancelOnTradingHalt
        |"L"B -> ExecInst.LastPeg
        |"M"B -> ExecInst.MidPrice
        |"N"B -> ExecInst.NonNegotiable
        |"O"B -> ExecInst.OpeningPeg
        |"P"B -> ExecInst.MarketPeg
        |"Q"B -> ExecInst.CancelOnSystemFailure
        |"R"B -> ExecInst.PrimaryPeg
        |"S"B -> ExecInst.Suspend
        |"T"B -> ExecInst.FixedPegToLocalBestBidOrOfferAtTimeOfOrder
        |"U"B -> ExecInst.CustomerDisplayInstruction
        |"V"B -> ExecInst.Netting
        |"W"B -> ExecInst.PegToVwap
        |"X"B -> ExecInst.TradeAlong
        |"Y"B -> ExecInst.TryToStop
        |"Z"B -> ExecInst.CancelIfNotBest
        |"a"B -> ExecInst.TrailingStopPeg
        |"b"B -> ExecInst.StrictLimit
        |"c"B -> ExecInst.IgnorePriceValidityChecks
        |"d"B -> ExecInst.PegToLimitPrice
        |"e"B -> ExecInst.WorkToTargetStrategy
        | x -> failwith (sprintf "ReadExecInst unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadExecRefID (pos:int) (bs:byte[]) : (int*ExecRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ExecRefID.ExecRefID


let ReadHandlInst (pos:int) (bs:byte[]) : (int * HandlInst) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> HandlInst.AutomatedExecutionOrderPrivate
        |"2"B -> HandlInst.AutomatedExecutionOrderPublic
        |"3"B -> HandlInst.ManualOrder
        | x -> failwith (sprintf "ReadHandlInst unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSecurityIDSource (pos:int) (bs:byte[]) : (int * SecurityIDSource) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> SecurityIDSource.Cusip
        |"2"B -> SecurityIDSource.Sedol
        |"3"B -> SecurityIDSource.Quik
        |"4"B -> SecurityIDSource.IsinNumber
        |"5"B -> SecurityIDSource.RicCode
        |"6"B -> SecurityIDSource.IsoCurrencyCode
        |"7"B -> SecurityIDSource.IsoCountryCode
        |"8"B -> SecurityIDSource.ExchangeSymbol
        |"9"B -> SecurityIDSource.ConsolidatedTapeAssociation
        |"A"B -> SecurityIDSource.BloombergSymbol
        |"B"B -> SecurityIDSource.Wertpapier
        |"C"B -> SecurityIDSource.Dutch
        |"D"B -> SecurityIDSource.Valoren
        |"E"B -> SecurityIDSource.Sicovam
        |"F"B -> SecurityIDSource.Belgian
        |"G"B -> SecurityIDSource.Common
        |"H"B -> SecurityIDSource.ClearingHouseClearingOrganization
        |"I"B -> SecurityIDSource.IsdaFpmlProductSpecification
        |"J"B -> SecurityIDSource.OptionsPriceReportingAuthority
        | x -> failwith (sprintf "ReadSecurityIDSource unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadIOIid (pos:int) (bs:byte[]) : (int*IOIid) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) IOIid.IOIid


let ReadIOIQltyInd (pos:int) (bs:byte[]) : (int * IOIQltyInd) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"L"B -> IOIQltyInd.Low
        |"M"B -> IOIQltyInd.Medium
        |"H"B -> IOIQltyInd.High
        | x -> failwith (sprintf "ReadIOIQltyInd unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadIOIRefID (pos:int) (bs:byte[]) : (int*IOIRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) IOIRefID.IOIRefID


let ReadIOIQty (pos:int) (bs:byte[]) : (int*IOIQty) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) IOIQty.IOIQty


let ReadIOITransType (pos:int) (bs:byte[]) : (int * IOITransType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"N"B -> IOITransType.New
        |"C"B -> IOITransType.Cancel
        |"R"B -> IOITransType.Replace
        | x -> failwith (sprintf "ReadIOITransType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadLastCapacity (pos:int) (bs:byte[]) : (int * LastCapacity) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> LastCapacity.Agent
        |"2"B -> LastCapacity.CrossAsAgent
        |"3"B -> LastCapacity.CrossAsPrincipal
        |"4"B -> LastCapacity.Principal
        | x -> failwith (sprintf "ReadLastCapacity unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadLastMkt (pos:int) (bs:byte[]) : (int*LastMkt) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LastMkt.LastMkt


let ReadLastPx (pos:int) (bs:byte[]) : (int*LastPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LastPx.LastPx


let ReadLastQty (pos:int) (bs:byte[]) : (int*LastQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LastQty.LastQty


let ReadLinesOfText (pos:int) (bs:byte[]) : (int*LinesOfText) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LinesOfText.LinesOfText


let ReadMsgSeqNum (pos:int) (bs:byte[]) : (int*MsgSeqNum) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) MsgSeqNum.MsgSeqNum


let ReadMsgType (pos:int) (bs:byte[]) : (int * MsgType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> MsgType.Heartbeat
        |"1"B -> MsgType.TestRequest
        |"2"B -> MsgType.ResendRequest
        |"3"B -> MsgType.Reject
        |"4"B -> MsgType.SequenceReset
        |"5"B -> MsgType.Logout
        |"6"B -> MsgType.IndicationOfInterest
        |"7"B -> MsgType.Advertisement
        |"8"B -> MsgType.ExecutionReport
        |"9"B -> MsgType.OrderCancelReject
        |"A"B -> MsgType.Logon
        |"B"B -> MsgType.News
        |"C"B -> MsgType.Email
        |"D"B -> MsgType.OrderSingle
        |"E"B -> MsgType.OrderList
        |"F"B -> MsgType.OrderCancelRequest
        |"G"B -> MsgType.OrderCancelReplaceRequest
        |"H"B -> MsgType.OrderStatusRequest
        |"J"B -> MsgType.AllocationInstruction
        |"K"B -> MsgType.ListCancelRequest
        |"L"B -> MsgType.ListExecute
        |"M"B -> MsgType.ListStatusRequest
        |"N"B -> MsgType.ListStatus
        |"P"B -> MsgType.AllocationInstructionAck
        |"Q"B -> MsgType.DontKnowTrade
        |"R"B -> MsgType.QuoteRequest
        |"S"B -> MsgType.Quote
        |"T"B -> MsgType.SettlementInstructions
        |"V"B -> MsgType.MarketDataRequest
        |"W"B -> MsgType.MarketDataSnapshotFullRefresh
        |"X"B -> MsgType.MarketDataIncrementalRefresh
        |"Y"B -> MsgType.MarketDataRequestReject
        |"Z"B -> MsgType.QuoteCancel
        |"a"B -> MsgType.QuoteStatusRequest
        |"b"B -> MsgType.MassQuoteAcknowledgement
        |"c"B -> MsgType.SecurityDefinitionRequest
        |"d"B -> MsgType.SecurityDefinition
        |"e"B -> MsgType.SecurityStatusRequest
        |"f"B -> MsgType.SecurityStatus
        |"g"B -> MsgType.TradingSessionStatusRequest
        |"h"B -> MsgType.TradingSessionStatus
        |"i"B -> MsgType.MassQuote
        |"j"B -> MsgType.BusinessMessageReject
        |"k"B -> MsgType.BidRequest
        |"l"B -> MsgType.BidResponse
        |"m"B -> MsgType.ListStrikePrice
        |"n"B -> MsgType.XmlMessage
        |"o"B -> MsgType.RegistrationInstructions
        |"p"B -> MsgType.RegistrationInstructionsResponse
        |"q"B -> MsgType.OrderMassCancelRequest
        |"r"B -> MsgType.OrderMassCancelReport
        |"s"B -> MsgType.NewOrderCross
        |"t"B -> MsgType.CrossOrderCancelReplaceRequest
        |"u"B -> MsgType.CrossOrderCancelRequest
        |"v"B -> MsgType.SecurityTypeRequest
        |"w"B -> MsgType.SecurityTypes
        |"x"B -> MsgType.SecurityListRequest
        |"y"B -> MsgType.SecurityList
        |"z"B -> MsgType.DerivativeSecurityListRequest
        |"AA"B -> MsgType.DerivativeSecurityList
        |"AB"B -> MsgType.NewOrderMultileg
        |"AC"B -> MsgType.MultilegOrderCancelReplace
        |"AD"B -> MsgType.TradeCaptureReportRequest
        |"AE"B -> MsgType.TradeCaptureReport
        |"AF"B -> MsgType.OrderMassStatusRequest
        |"AG"B -> MsgType.QuoteRequestReject
        |"AH"B -> MsgType.RfqRequest
        |"AI"B -> MsgType.QuoteStatusReport
        |"AJ"B -> MsgType.QuoteResponse
        |"AK"B -> MsgType.Confirmation
        |"AL"B -> MsgType.PositionMaintenanceRequest
        |"AM"B -> MsgType.PositionMaintenanceReport
        |"AN"B -> MsgType.RequestForPositions
        |"AO"B -> MsgType.RequestForPositionsAck
        |"AP"B -> MsgType.PositionReport
        |"AQ"B -> MsgType.TradeCaptureReportRequestAck
        |"AR"B -> MsgType.TradeCaptureReportAck
        |"AS"B -> MsgType.AllocationReport
        |"AT"B -> MsgType.AllocationReportAck
        |"AU"B -> MsgType.ConfirmationAck
        |"AV"B -> MsgType.SettlementInstructionRequest
        |"AW"B -> MsgType.AssignmentReport
        |"AX"B -> MsgType.CollateralRequest
        |"AY"B -> MsgType.CollateralAssignment
        |"AZ"B -> MsgType.CollateralResponse
        |"BA"B -> MsgType.CollateralReport
        |"BB"B -> MsgType.CollateralInquiry
        |"BC"B -> MsgType.NetworkStatusRequest
        |"BD"B -> MsgType.NetworkStatusResponse
        |"BE"B -> MsgType.UserRequest
        |"BF"B -> MsgType.UserResponse
        |"BG"B -> MsgType.CollateralInquiryAck
        |"BH"B -> MsgType.ConfirmationRequest
        | x -> failwith (sprintf "ReadMsgType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNewSeqNo (pos:int) (bs:byte[]) : (int*NewSeqNo) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NewSeqNo.NewSeqNo


let ReadOrderID (pos:int) (bs:byte[]) : (int*OrderID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) OrderID.OrderID


let ReadOrderQty (pos:int) (bs:byte[]) : (int*OrderQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) OrderQty.OrderQty


let ReadOrdStatus (pos:int) (bs:byte[]) : (int * OrdStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> OrdStatus.New
        |"1"B -> OrdStatus.PartiallyFilled
        |"2"B -> OrdStatus.Filled
        |"3"B -> OrdStatus.DoneForDay
        |"4"B -> OrdStatus.Canceled
        |"5"B -> OrdStatus.Replaced
        |"6"B -> OrdStatus.PendingCancel
        |"7"B -> OrdStatus.Stopped
        |"8"B -> OrdStatus.Rejected
        |"9"B -> OrdStatus.Suspended
        |"A"B -> OrdStatus.PendingNew
        |"B"B -> OrdStatus.Calculated
        |"C"B -> OrdStatus.Expired
        |"D"B -> OrdStatus.AcceptedForBidding
        |"E"B -> OrdStatus.PendingReplace
        | x -> failwith (sprintf "ReadOrdStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadOrdType (pos:int) (bs:byte[]) : (int * OrdType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> OrdType.Market
        |"2"B -> OrdType.Limit
        |"3"B -> OrdType.Stop
        |"4"B -> OrdType.StopLimit
        |"5"B -> OrdType.MarketOnClose
        |"6"B -> OrdType.WithOrWithout
        |"7"B -> OrdType.LimitOrBetter
        |"8"B -> OrdType.LimitWithOrWithout
        |"9"B -> OrdType.OnBasis
        |"A"B -> OrdType.OnClose
        |"B"B -> OrdType.LimitOnClose
        |"C"B -> OrdType.ForexMarket
        |"D"B -> OrdType.PreviouslyQuoted
        |"E"B -> OrdType.PreviouslyIndicated
        |"F"B -> OrdType.ForexLimit
        |"G"B -> OrdType.ForexSwap
        |"H"B -> OrdType.ForexPreviouslyQuoted
        |"I"B -> OrdType.Funari
        |"J"B -> OrdType.MarketIfTouched
        |"K"B -> OrdType.MarketWithLeftoverAsLimit
        |"L"B -> OrdType.PreviousFundValuationPoint
        |"M"B -> OrdType.NextFundValuationPoint
        |"P"B -> OrdType.Pegged
        | x -> failwith (sprintf "ReadOrdType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadOrigClOrdID (pos:int) (bs:byte[]) : (int*OrigClOrdID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) OrigClOrdID.OrigClOrdID


let ReadOrigTime (pos:int) (bs:byte[]) : (int*OrigTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) OrigTime.OrigTime


let ReadPossDupFlag (pos:int) (bs:byte[]) : (int*PossDupFlag) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) PossDupFlag.PossDupFlag


let ReadPrice (pos:int) (bs:byte[]) : (int*Price) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) Price.Price


let ReadRefSeqNum (pos:int) (bs:byte[]) : (int*RefSeqNum) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) RefSeqNum.RefSeqNum


let ReadSecurityID (pos:int) (bs:byte[]) : (int*SecurityID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecurityID.SecurityID


let ReadSenderCompID (pos:int) (bs:byte[]) : (int*SenderCompID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SenderCompID.SenderCompID


let ReadSenderSubID (pos:int) (bs:byte[]) : (int*SenderSubID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SenderSubID.SenderSubID


let ReadSendingTime (pos:int) (bs:byte[]) : (int*SendingTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SendingTime.SendingTime


let ReadQuantity (pos:int) (bs:byte[]) : (int*Quantity) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) Quantity.Quantity


let ReadSide (pos:int) (bs:byte[]) : (int * Side) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> Side.Buy
        |"2"B -> Side.Sell
        |"3"B -> Side.BuyMinus
        |"4"B -> Side.SellPlus
        |"5"B -> Side.SellShort
        |"6"B -> Side.SellShortExempt
        |"7"B -> Side.Undisclosed
        |"8"B -> Side.Cross
        |"9"B -> Side.CrossShort
        |"A"B -> Side.CrossShortExempt
        |"B"B -> Side.AsDefined
        |"C"B -> Side.Opposite
        |"D"B -> Side.Subscribe
        |"E"B -> Side.Redeem
        |"F"B -> Side.Lend
        |"G"B -> Side.Borrow
        | x -> failwith (sprintf "ReadSide unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSymbol (pos:int) (bs:byte[]) : (int*Symbol) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Symbol.Symbol


let ReadTargetCompID (pos:int) (bs:byte[]) : (int*TargetCompID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TargetCompID.TargetCompID


let ReadTargetSubID (pos:int) (bs:byte[]) : (int*TargetSubID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TargetSubID.TargetSubID


let ReadText (pos:int) (bs:byte[]) : (int*Text) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Text.Text


let ReadTimeInForce (pos:int) (bs:byte[]) : (int * TimeInForce) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> TimeInForce.Day
        |"1"B -> TimeInForce.GoodTillCancel
        |"2"B -> TimeInForce.AtTheOpening
        |"3"B -> TimeInForce.ImmediateOrCancel
        |"4"B -> TimeInForce.FillOrKill
        |"5"B -> TimeInForce.GoodTillCrossing
        |"6"B -> TimeInForce.GoodTillDate
        |"7"B -> TimeInForce.AtTheClose
        | x -> failwith (sprintf "ReadTimeInForce unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTransactTime (pos:int) (bs:byte[]) : (int*TransactTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TransactTime.TransactTime


let ReadUrgency (pos:int) (bs:byte[]) : (int * Urgency) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> Urgency.Normal
        |"1"B -> Urgency.Flash
        |"2"B -> Urgency.Background
        | x -> failwith (sprintf "ReadUrgency unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadValidUntilTime (pos:int) (bs:byte[]) : (int*ValidUntilTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ValidUntilTime.ValidUntilTime


let ReadSettlType (pos:int) (bs:byte[]) : (int * SettlType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> SettlType.Regular
        |"1"B -> SettlType.Cash
        |"2"B -> SettlType.NextDay
        |"3"B -> SettlType.TPlus2
        |"4"B -> SettlType.TPlus3
        |"5"B -> SettlType.TPlus4
        |"6"B -> SettlType.Future
        |"7"B -> SettlType.WhenAndIfIssued
        |"8"B -> SettlType.SellersOption
        |"9"B -> SettlType.TPlus5
        | x -> failwith (sprintf "ReadSettlType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSettlDate (pos:int) (bs:byte[]) : (int*SettlDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SettlDate.SettlDate


let ReadSymbolSfx (pos:int) (bs:byte[]) : (int * SymbolSfx) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"WI"B -> SymbolSfx.WhenIssued
        |"CD"B -> SymbolSfx.AEucpWithLumpSumInterest
        | x -> failwith (sprintf "ReadSymbolSfx unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadListID (pos:int) (bs:byte[]) : (int*ListID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ListID.ListID


let ReadListSeqNo (pos:int) (bs:byte[]) : (int*ListSeqNo) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) ListSeqNo.ListSeqNo


let ReadTotNoOrders (pos:int) (bs:byte[]) : (int*TotNoOrders) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotNoOrders.TotNoOrders


let ReadListExecInst (pos:int) (bs:byte[]) : (int*ListExecInst) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ListExecInst.ListExecInst


let ReadAllocID (pos:int) (bs:byte[]) : (int*AllocID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AllocID.AllocID


let ReadAllocTransType (pos:int) (bs:byte[]) : (int * AllocTransType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> AllocTransType.New
        |"1"B -> AllocTransType.Replace
        |"2"B -> AllocTransType.Cancel
        | x -> failwith (sprintf "ReadAllocTransType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadRefAllocID (pos:int) (bs:byte[]) : (int*RefAllocID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) RefAllocID.RefAllocID


let ReadNoOrders (pos:int) (bs:byte[]) : (int*NoOrders) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoOrders.NoOrders


let ReadAvgPxPrecision (pos:int) (bs:byte[]) : (int*AvgPxPrecision) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) AvgPxPrecision.AvgPxPrecision


let ReadTradeDate (pos:int) (bs:byte[]) : (int*TradeDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradeDate.TradeDate


let ReadPositionEffect (pos:int) (bs:byte[]) : (int * PositionEffect) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"O"B -> PositionEffect.Open
        |"C"B -> PositionEffect.Close
        |"R"B -> PositionEffect.Rolled
        |"F"B -> PositionEffect.Fifo
        | x -> failwith (sprintf "ReadPositionEffect unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoAllocs (pos:int) (bs:byte[]) : (int*NoAllocs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoAllocs.NoAllocs


let ReadAllocAccount (pos:int) (bs:byte[]) : (int*AllocAccount) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AllocAccount.AllocAccount


let ReadAllocQty (pos:int) (bs:byte[]) : (int*AllocQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) AllocQty.AllocQty


let ReadProcessCode (pos:int) (bs:byte[]) : (int * ProcessCode) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> ProcessCode.Regular
        |"1"B -> ProcessCode.SoftDollar
        |"2"B -> ProcessCode.StepIn
        |"3"B -> ProcessCode.StepOut
        |"4"B -> ProcessCode.SoftDollarStepIn
        |"5"B -> ProcessCode.SoftDollarStepOut
        |"6"B -> ProcessCode.PlanSponsor
        | x -> failwith (sprintf "ReadProcessCode unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoRpts (pos:int) (bs:byte[]) : (int*NoRpts) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoRpts.NoRpts


let ReadRptSeq (pos:int) (bs:byte[]) : (int*RptSeq) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) RptSeq.RptSeq


let ReadCxlQty (pos:int) (bs:byte[]) : (int*CxlQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) CxlQty.CxlQty


let ReadNoDlvyInst (pos:int) (bs:byte[]) : (int*NoDlvyInst) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoDlvyInst.NoDlvyInst


let ReadAllocStatus (pos:int) (bs:byte[]) : (int * AllocStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> AllocStatus.Accepted
        |"1"B -> AllocStatus.BlockLevelReject
        |"2"B -> AllocStatus.AccountLevelReject
        |"3"B -> AllocStatus.Received
        |"4"B -> AllocStatus.Incomplete
        |"5"B -> AllocStatus.RejectedByIntermediary
        | x -> failwith (sprintf "ReadAllocStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadAllocRejCode (pos:int) (bs:byte[]) : (int * AllocRejCode) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> AllocRejCode.UnknownAccount
        |"1"B -> AllocRejCode.IncorrectQuantity
        |"2"B -> AllocRejCode.IncorrectAveragePrice
        |"3"B -> AllocRejCode.UnknownExecutingBrokerMnemonic
        |"4"B -> AllocRejCode.CommissionDifference
        |"5"B -> AllocRejCode.UnknownOrderid
        |"6"B -> AllocRejCode.UnknownListid
        |"7"B -> AllocRejCode.Other
        |"8"B -> AllocRejCode.IncorrectAllocatedQuantity
        |"9"B -> AllocRejCode.CalculationDifference
        |"10"B -> AllocRejCode.UnknownOrStaleExecId
        |"11"B -> AllocRejCode.MismatchedDataValue
        |"12"B -> AllocRejCode.UnknownClordid
        |"13"B -> AllocRejCode.WarehouseRequestRejected
        | x -> failwith (sprintf "ReadAllocRejCode unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


// compound read
let ReadSignature (pos:int) (bs:byte[]) : (int * Signature) =
    ReadLengthDataCompoundField "89"B (pos:int) (bs:byte[]) Signature.Signature


// compound read
let ReadSecureData (pos:int) (bs:byte[]) : (int * SecureData) =
    ReadLengthDataCompoundField "91"B (pos:int) (bs:byte[]) SecureData.SecureData


let ReadEmailType (pos:int) (bs:byte[]) : (int * EmailType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> EmailType.New
        |"1"B -> EmailType.Reply
        |"2"B -> EmailType.AdminReply
        | x -> failwith (sprintf "ReadEmailType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


// compound read
let ReadRawData (pos:int) (bs:byte[]) : (int * RawData) =
    ReadLengthDataCompoundField "96"B (pos:int) (bs:byte[]) RawData.RawData


let ReadPossResend (pos:int) (bs:byte[]) : (int*PossResend) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) PossResend.PossResend


let ReadEncryptMethod (pos:int) (bs:byte[]) : (int * EncryptMethod) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> EncryptMethod.NoneOther
        |"1"B -> EncryptMethod.Pkcs
        |"2"B -> EncryptMethod.Des
        |"3"B -> EncryptMethod.PkcsDes
        |"4"B -> EncryptMethod.PgpDes
        |"5"B -> EncryptMethod.PgpDesMd5
        |"6"B -> EncryptMethod.PemDesMd5
        | x -> failwith (sprintf "ReadEncryptMethod unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadStopPx (pos:int) (bs:byte[]) : (int*StopPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) StopPx.StopPx


let ReadExDestination (pos:int) (bs:byte[]) : (int*ExDestination) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ExDestination.ExDestination


let ReadCxlRejReason (pos:int) (bs:byte[]) : (int * CxlRejReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> CxlRejReason.TooLateToCancel
        |"1"B -> CxlRejReason.UnknownOrder
        |"2"B -> CxlRejReason.BrokerExchangeOption
        |"3"B -> CxlRejReason.OrderAlreadyInPendingCancelOrPendingReplaceStatus
        |"4"B -> CxlRejReason.UnableToProcessOrderMassCancelRequest
        |"5"B -> CxlRejReason.OrigordmodtimeDidNotMatchLastTransacttimeOfOrder
        |"6"B -> CxlRejReason.DuplicateClordidReceived
        |"99"B -> CxlRejReason.Other
        | x -> failwith (sprintf "ReadCxlRejReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadOrdRejReason (pos:int) (bs:byte[]) : (int * OrdRejReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> OrdRejReason.BrokerExchangeOption
        |"1"B -> OrdRejReason.UnknownSymbol
        |"2"B -> OrdRejReason.ExchangeClosed
        |"3"B -> OrdRejReason.OrderExceedsLimit
        |"4"B -> OrdRejReason.TooLateToEnter
        |"5"B -> OrdRejReason.UnknownOrder
        |"6"B -> OrdRejReason.DuplicateOrder
        |"7"B -> OrdRejReason.DuplicateOfAVerballyCommunicatedOrder
        |"8"B -> OrdRejReason.StaleOrder
        |"9"B -> OrdRejReason.TradeAlongRequired
        |"10"B -> OrdRejReason.InvalidInvestorId
        |"11"B -> OrdRejReason.UnsupportedOrderCharacteristic
        |"12"B -> OrdRejReason.SurveillenceOption
        |"13"B -> OrdRejReason.IncorrectQuantity
        |"14"B -> OrdRejReason.IncorrectAllocatedQuantity
        |"15"B -> OrdRejReason.UnknownAccount
        |"99"B -> OrdRejReason.Other
        | x -> failwith (sprintf "ReadOrdRejReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadIOIQualifier (pos:int) (bs:byte[]) : (int * IOIQualifier) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"A"B -> IOIQualifier.AllOrNone
        |"B"B -> IOIQualifier.MarketOnClose
        |"C"B -> IOIQualifier.AtTheClose
        |"D"B -> IOIQualifier.Vwap
        |"I"B -> IOIQualifier.InTouchWith
        |"L"B -> IOIQualifier.Limit
        |"M"B -> IOIQualifier.MoreBehind
        |"O"B -> IOIQualifier.AtTheOpen
        |"P"B -> IOIQualifier.TakingAPosition
        |"Q"B -> IOIQualifier.AtTheMarket
        |"R"B -> IOIQualifier.ReadyToTrade
        |"S"B -> IOIQualifier.PortfolioShown
        |"T"B -> IOIQualifier.ThroughTheDay
        |"V"B -> IOIQualifier.Versus
        |"W"B -> IOIQualifier.IndicationWorkingAway
        |"X"B -> IOIQualifier.CrossingOpportunity
        |"Y"B -> IOIQualifier.AtTheMidpoint
        |"Z"B -> IOIQualifier.PreOpen
        | x -> failwith (sprintf "ReadIOIQualifier unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadWaveNo (pos:int) (bs:byte[]) : (int*WaveNo) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) WaveNo.WaveNo


let ReadIssuer (pos:int) (bs:byte[]) : (int*Issuer) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Issuer.Issuer


let ReadSecurityDesc (pos:int) (bs:byte[]) : (int*SecurityDesc) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecurityDesc.SecurityDesc


let ReadHeartBtInt (pos:int) (bs:byte[]) : (int*HeartBtInt) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) HeartBtInt.HeartBtInt


let ReadMinQty (pos:int) (bs:byte[]) : (int*MinQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) MinQty.MinQty


let ReadMaxFloor (pos:int) (bs:byte[]) : (int*MaxFloor) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) MaxFloor.MaxFloor


let ReadTestReqID (pos:int) (bs:byte[]) : (int*TestReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TestReqID.TestReqID


let ReadReportToExch (pos:int) (bs:byte[]) : (int*ReportToExch) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) ReportToExch.ReportToExch


let ReadLocateReqd (pos:int) (bs:byte[]) : (int*LocateReqd) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) LocateReqd.LocateReqd


let ReadOnBehalfOfCompID (pos:int) (bs:byte[]) : (int*OnBehalfOfCompID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) OnBehalfOfCompID.OnBehalfOfCompID


let ReadOnBehalfOfSubID (pos:int) (bs:byte[]) : (int*OnBehalfOfSubID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) OnBehalfOfSubID.OnBehalfOfSubID


let ReadQuoteID (pos:int) (bs:byte[]) : (int*QuoteID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) QuoteID.QuoteID


let ReadNetMoney (pos:int) (bs:byte[]) : (int*NetMoney) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NetMoney.NetMoney


let ReadSettlCurrAmt (pos:int) (bs:byte[]) : (int*SettlCurrAmt) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) SettlCurrAmt.SettlCurrAmt


let ReadSettlCurrency (pos:int) (bs:byte[]) : (int*SettlCurrency) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SettlCurrency.SettlCurrency


let ReadForexReq (pos:int) (bs:byte[]) : (int*ForexReq) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) ForexReq.ForexReq


let ReadOrigSendingTime (pos:int) (bs:byte[]) : (int*OrigSendingTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) OrigSendingTime.OrigSendingTime


let ReadGapFillFlag (pos:int) (bs:byte[]) : (int*GapFillFlag) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) GapFillFlag.GapFillFlag


let ReadNoExecs (pos:int) (bs:byte[]) : (int*NoExecs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoExecs.NoExecs


let ReadExpireTime (pos:int) (bs:byte[]) : (int*ExpireTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ExpireTime.ExpireTime


let ReadDKReason (pos:int) (bs:byte[]) : (int * DKReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"A"B -> DKReason.UnknownSymbol
        |"B"B -> DKReason.WrongSide
        |"C"B -> DKReason.QuantityExceedsOrder
        |"D"B -> DKReason.NoMatchingOrder
        |"E"B -> DKReason.PriceExceedsLimit
        |"F"B -> DKReason.CalculationDifference
        |"Z"B -> DKReason.Other
        | x -> failwith (sprintf "ReadDKReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadDeliverToCompID (pos:int) (bs:byte[]) : (int*DeliverToCompID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) DeliverToCompID.DeliverToCompID


let ReadDeliverToSubID (pos:int) (bs:byte[]) : (int*DeliverToSubID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) DeliverToSubID.DeliverToSubID


let ReadIOINaturalFlag (pos:int) (bs:byte[]) : (int*IOINaturalFlag) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) IOINaturalFlag.IOINaturalFlag


let ReadQuoteReqID (pos:int) (bs:byte[]) : (int*QuoteReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) QuoteReqID.QuoteReqID


let ReadBidPx (pos:int) (bs:byte[]) : (int*BidPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) BidPx.BidPx


let ReadOfferPx (pos:int) (bs:byte[]) : (int*OfferPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) OfferPx.OfferPx


let ReadBidSize (pos:int) (bs:byte[]) : (int*BidSize) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) BidSize.BidSize


let ReadOfferSize (pos:int) (bs:byte[]) : (int*OfferSize) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) OfferSize.OfferSize


let ReadNoMiscFees (pos:int) (bs:byte[]) : (int*NoMiscFees) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoMiscFees.NoMiscFees


let ReadMiscFeeAmt (pos:int) (bs:byte[]) : (int*MiscFeeAmt) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) MiscFeeAmt.MiscFeeAmt


let ReadMiscFeeCurr (pos:int) (bs:byte[]) : (int*MiscFeeCurr) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MiscFeeCurr.MiscFeeCurr


let ReadMiscFeeType (pos:int) (bs:byte[]) : (int * MiscFeeType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> MiscFeeType.Regulatory
        |"2"B -> MiscFeeType.Tax
        |"3"B -> MiscFeeType.LocalCommission
        |"4"B -> MiscFeeType.ExchangeFees
        |"5"B -> MiscFeeType.Stamp
        |"6"B -> MiscFeeType.Levy
        |"7"B -> MiscFeeType.Other
        |"8"B -> MiscFeeType.Markup
        |"9"B -> MiscFeeType.ConsumptionTax
        |"10"B -> MiscFeeType.PerTransaction
        |"11"B -> MiscFeeType.Conversion
        |"12"B -> MiscFeeType.Agent
        | x -> failwith (sprintf "ReadMiscFeeType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPrevClosePx (pos:int) (bs:byte[]) : (int*PrevClosePx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) PrevClosePx.PrevClosePx


let ReadResetSeqNumFlag (pos:int) (bs:byte[]) : (int*ResetSeqNumFlag) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) ResetSeqNumFlag.ResetSeqNumFlag


let ReadSenderLocationID (pos:int) (bs:byte[]) : (int*SenderLocationID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SenderLocationID.SenderLocationID


let ReadTargetLocationID (pos:int) (bs:byte[]) : (int*TargetLocationID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TargetLocationID.TargetLocationID


let ReadOnBehalfOfLocationID (pos:int) (bs:byte[]) : (int*OnBehalfOfLocationID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) OnBehalfOfLocationID.OnBehalfOfLocationID


let ReadDeliverToLocationID (pos:int) (bs:byte[]) : (int*DeliverToLocationID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) DeliverToLocationID.DeliverToLocationID


let ReadNoRelatedSym (pos:int) (bs:byte[]) : (int*NoRelatedSym) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoRelatedSym.NoRelatedSym


let ReadSubject (pos:int) (bs:byte[]) : (int*Subject) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Subject.Subject


let ReadHeadline (pos:int) (bs:byte[]) : (int*Headline) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Headline.Headline


let ReadURLLink (pos:int) (bs:byte[]) : (int*URLLink) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) URLLink.URLLink


let ReadExecType (pos:int) (bs:byte[]) : (int * ExecType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> ExecType.New
        |"1"B -> ExecType.PartialFill
        |"2"B -> ExecType.Fill
        |"3"B -> ExecType.DoneForDay
        |"4"B -> ExecType.Canceled
        |"5"B -> ExecType.Replace
        |"6"B -> ExecType.PendingCancel
        |"7"B -> ExecType.Stopped
        |"8"B -> ExecType.Rejected
        |"9"B -> ExecType.Suspended
        |"A"B -> ExecType.PendingNew
        |"B"B -> ExecType.Calculated
        |"C"B -> ExecType.Expired
        |"D"B -> ExecType.Restated
        |"E"B -> ExecType.PendingReplace
        |"F"B -> ExecType.Trade
        |"G"B -> ExecType.TradeCorrect
        |"H"B -> ExecType.TradeCancel
        |"I"B -> ExecType.OrderStatus
        | x -> failwith (sprintf "ReadExecType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadLeavesQty (pos:int) (bs:byte[]) : (int*LeavesQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LeavesQty.LeavesQty


let ReadCashOrderQty (pos:int) (bs:byte[]) : (int*CashOrderQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) CashOrderQty.CashOrderQty


let ReadAllocAvgPx (pos:int) (bs:byte[]) : (int*AllocAvgPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) AllocAvgPx.AllocAvgPx


let ReadAllocNetMoney (pos:int) (bs:byte[]) : (int*AllocNetMoney) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) AllocNetMoney.AllocNetMoney


let ReadSettlCurrFxRate (pos:int) (bs:byte[]) : (int*SettlCurrFxRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) SettlCurrFxRate.SettlCurrFxRate


let ReadSettlCurrFxRateCalc (pos:int) (bs:byte[]) : (int * SettlCurrFxRateCalc) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"M"B -> SettlCurrFxRateCalc.Multiply
        |"D"B -> SettlCurrFxRateCalc.Divide
        | x -> failwith (sprintf "ReadSettlCurrFxRateCalc unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNumDaysInterest (pos:int) (bs:byte[]) : (int*NumDaysInterest) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NumDaysInterest.NumDaysInterest


let ReadAccruedInterestRate (pos:int) (bs:byte[]) : (int*AccruedInterestRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) AccruedInterestRate.AccruedInterestRate


let ReadAccruedInterestAmt (pos:int) (bs:byte[]) : (int*AccruedInterestAmt) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) AccruedInterestAmt.AccruedInterestAmt


let ReadSettlInstMode (pos:int) (bs:byte[]) : (int * SettlInstMode) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> SettlInstMode.Default
        |"1"B -> SettlInstMode.StandingInstructionsProvided
        |"4"B -> SettlInstMode.SpecificOrderForASingleAccount
        |"5"B -> SettlInstMode.RequestReject
        | x -> failwith (sprintf "ReadSettlInstMode unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadAllocText (pos:int) (bs:byte[]) : (int*AllocText) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AllocText.AllocText


let ReadSettlInstID (pos:int) (bs:byte[]) : (int*SettlInstID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SettlInstID.SettlInstID


let ReadSettlInstTransType (pos:int) (bs:byte[]) : (int * SettlInstTransType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"N"B -> SettlInstTransType.New
        |"C"B -> SettlInstTransType.Cancel
        |"R"B -> SettlInstTransType.Replace
        |"T"B -> SettlInstTransType.Restate
        | x -> failwith (sprintf "ReadSettlInstTransType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadEmailThreadID (pos:int) (bs:byte[]) : (int*EmailThreadID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) EmailThreadID.EmailThreadID


let ReadSettlInstSource (pos:int) (bs:byte[]) : (int * SettlInstSource) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> SettlInstSource.BrokersInstructions
        |"2"B -> SettlInstSource.InstitutionsInstructions
        |"3"B -> SettlInstSource.Investor
        | x -> failwith (sprintf "ReadSettlInstSource unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSecurityType (pos:int) (bs:byte[]) : (int * SecurityType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"EUSUPRA"B -> SecurityType.EuroSupranationalCoupons
        |"FAC"B -> SecurityType.FederalAgencyCoupon
        |"FADN"B -> SecurityType.FederalAgencyDiscountNote
        |"PEF"B -> SecurityType.PrivateExportFunding
        |"SUPRA"B -> SecurityType.UsdSupranationalCoupons
        |"FUT"B -> SecurityType.Future
        |"OPT"B -> SecurityType.Option
        |"CORP"B -> SecurityType.CorporateBond
        |"CPP"B -> SecurityType.CorporatePrivatePlacement
        |"CB"B -> SecurityType.ConvertibleBond
        |"DUAL"B -> SecurityType.DualCurrency
        |"EUCORP"B -> SecurityType.EuroCorporateBond
        |"XLINKD"B -> SecurityType.IndexedLinked
        |"STRUCT"B -> SecurityType.StructuredNotes
        |"YANK"B -> SecurityType.YankeeCorporateBond
        |"FOR"B -> SecurityType.ForeignExchangeContract
        |"CS"B -> SecurityType.CommonStock
        |"PS"B -> SecurityType.PreferredStock
        |"BRADY"B -> SecurityType.BradyBond
        |"EUSOV"B -> SecurityType.EuroSovereigns
        |"TBOND"B -> SecurityType.UsTreasuryBond
        |"TINT"B -> SecurityType.InterestStripFromAnyBondOrNote
        |"TIPS"B -> SecurityType.TreasuryInflationProtectedSecurities
        |"TCAL"B -> SecurityType.PrincipalStripOfACallableBondOrNote
        |"TPRN"B -> SecurityType.PrincipalStripFromANonCallableBondOrNote
        |"TNOTE"B -> SecurityType.UsTreasuryNote
        |"TBILL"B -> SecurityType.UsTreasuryBill
        |"REPO"B -> SecurityType.Repurchase
        |"FORWARD"B -> SecurityType.Forward
        |"BUYSELL"B -> SecurityType.BuySellback
        |"SECLOAN"B -> SecurityType.SecuritiesLoan
        |"SECPLEDGE"B -> SecurityType.SecuritiesPledge
        |"TERM"B -> SecurityType.TermLoan
        |"RVLV"B -> SecurityType.RevolverLoan
        |"RVLVTRM"B -> SecurityType.RevolverTermLoan
        |"BRIDGE"B -> SecurityType.BridgeLoan
        |"LOFC"B -> SecurityType.LetterOfCredit
        |"SWING"B -> SecurityType.SwingLineFacility
        |"DINP"B -> SecurityType.DebtorInPossession
        |"DEFLTED"B -> SecurityType.Defaulted
        |"WITHDRN"B -> SecurityType.Withdrawn
        |"REPLACD"B -> SecurityType.Replaced
        |"MATURED"B -> SecurityType.Matured
        |"AMENDED"B -> SecurityType.AmendedAndRestated
        |"RETIRED"B -> SecurityType.Retired
        |"BA"B -> SecurityType.BankersAcceptance
        |"BN"B -> SecurityType.BankNotes
        |"BOX"B -> SecurityType.BillOfExchanges
        |"CD"B -> SecurityType.CertificateOfDeposit
        |"CL"B -> SecurityType.CallLoans
        |"CP"B -> SecurityType.CommercialPaper
        |"DN"B -> SecurityType.DepositNotes
        |"EUCD"B -> SecurityType.EuroCertificateOfDeposit
        |"EUCP"B -> SecurityType.EuroCommercialPaper
        |"LQN"B -> SecurityType.LiquidityNote
        |"MTN"B -> SecurityType.MediumTermNotes
        |"ONITE"B -> SecurityType.Overnight
        |"PN"B -> SecurityType.PromissoryNote
        |"PZFJ"B -> SecurityType.PlazosFijos
        |"STN"B -> SecurityType.ShortTermLoanNote
        |"TD"B -> SecurityType.TimeDeposit
        |"XCN"B -> SecurityType.ExtendedCommNote
        |"YCD"B -> SecurityType.YankeeCertificateOfDeposit
        |"ABS"B -> SecurityType.AssetBackedSecurities
        |"CMBS"B -> SecurityType.CorpMortgageBackedSecurities
        |"CMO"B -> SecurityType.CollateralizedMortgageObligation
        |"IET"B -> SecurityType.IoetteMortgage
        |"MBS"B -> SecurityType.MortgageBackedSecurities
        |"MIO"B -> SecurityType.MortgageInterestOnly
        |"MPO"B -> SecurityType.MortgagePrincipalOnly
        |"MPP"B -> SecurityType.MortgagePrivatePlacement
        |"MPT"B -> SecurityType.MiscellaneousPassThrough
        |"PFAND"B -> SecurityType.Pfandbriefe
        |"TBA"B -> SecurityType.ToBeAnnounced
        |"AN"B -> SecurityType.OtherAnticipationNotes
        |"COFO"B -> SecurityType.CertificateOfObligation
        |"COFP"B -> SecurityType.CertificateOfParticipation
        |"GO"B -> SecurityType.GeneralObligationBonds
        |"MT"B -> SecurityType.MandatoryTender
        |"RAN"B -> SecurityType.RevenueAnticipationNote
        |"REV"B -> SecurityType.RevenueBonds
        |"SPCLA"B -> SecurityType.SpecialAssessment
        |"SPCLO"B -> SecurityType.SpecialObligation
        |"SPCLT"B -> SecurityType.SpecialTax
        |"TAN"B -> SecurityType.TaxAnticipationNote
        |"TAXA"B -> SecurityType.TaxAllocation
        |"TECP"B -> SecurityType.TaxExemptCommercialPaper
        |"TRAN"B -> SecurityType.TaxAndRevenueAnticipationNote
        |"VRDN"B -> SecurityType.VariableRateDemandNote
        |"WAR"B -> SecurityType.Warrant
        |"MF"B -> SecurityType.MutualFund
        |"MLEG"B -> SecurityType.MultiLegInstrument
        |"NONE"B -> SecurityType.NoSecurityType
        |"?"B -> SecurityType.Wildcard
        | x -> failwith (sprintf "ReadSecurityType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadEffectiveTime (pos:int) (bs:byte[]) : (int*EffectiveTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) EffectiveTime.EffectiveTime


let ReadStandInstDbType (pos:int) (bs:byte[]) : (int * StandInstDbType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> StandInstDbType.Other
        |"1"B -> StandInstDbType.DtcSid
        |"2"B -> StandInstDbType.ThomsonAlert
        |"3"B -> StandInstDbType.AGlobalCustodian
        |"4"B -> StandInstDbType.Accountnet
        | x -> failwith (sprintf "ReadStandInstDbType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadStandInstDbName (pos:int) (bs:byte[]) : (int*StandInstDbName) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) StandInstDbName.StandInstDbName


let ReadStandInstDbID (pos:int) (bs:byte[]) : (int*StandInstDbID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) StandInstDbID.StandInstDbID


let ReadSettlDeliveryType (pos:int) (bs:byte[]) : (int * SettlDeliveryType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> SettlDeliveryType.VersusPayment
        |"1"B -> SettlDeliveryType.Free
        |"2"B -> SettlDeliveryType.TriParty
        |"3"B -> SettlDeliveryType.HoldInCustody
        | x -> failwith (sprintf "ReadSettlDeliveryType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadBidSpotRate (pos:int) (bs:byte[]) : (int*BidSpotRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) BidSpotRate.BidSpotRate


let ReadBidForwardPoints (pos:int) (bs:byte[]) : (int*BidForwardPoints) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) BidForwardPoints.BidForwardPoints


let ReadOfferSpotRate (pos:int) (bs:byte[]) : (int*OfferSpotRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) OfferSpotRate.OfferSpotRate


let ReadOfferForwardPoints (pos:int) (bs:byte[]) : (int*OfferForwardPoints) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) OfferForwardPoints.OfferForwardPoints


let ReadOrderQty2 (pos:int) (bs:byte[]) : (int*OrderQty2) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) OrderQty2.OrderQty2


let ReadSettlDate2 (pos:int) (bs:byte[]) : (int*SettlDate2) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SettlDate2.SettlDate2


let ReadLastSpotRate (pos:int) (bs:byte[]) : (int*LastSpotRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LastSpotRate.LastSpotRate


let ReadLastForwardPoints (pos:int) (bs:byte[]) : (int*LastForwardPoints) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LastForwardPoints.LastForwardPoints


let ReadAllocLinkID (pos:int) (bs:byte[]) : (int*AllocLinkID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AllocLinkID.AllocLinkID


let ReadAllocLinkType (pos:int) (bs:byte[]) : (int * AllocLinkType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> AllocLinkType.FXNetting
        |"1"B -> AllocLinkType.FXSwap
        | x -> failwith (sprintf "ReadAllocLinkType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSecondaryOrderID (pos:int) (bs:byte[]) : (int*SecondaryOrderID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecondaryOrderID.SecondaryOrderID


let ReadNoIOIQualifiers (pos:int) (bs:byte[]) : (int*NoIOIQualifiers) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoIOIQualifiers.NoIOIQualifiers


let ReadMaturityMonthYear (pos:int) (bs:byte[]) : (int*MaturityMonthYear) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MaturityMonthYear.MaturityMonthYear


let ReadPutOrCall (pos:int) (bs:byte[]) : (int * PutOrCall) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> PutOrCall.Put
        |"1"B -> PutOrCall.Call
        | x -> failwith (sprintf "ReadPutOrCall unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadStrikePrice (pos:int) (bs:byte[]) : (int*StrikePrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) StrikePrice.StrikePrice


let ReadCoveredOrUncovered (pos:int) (bs:byte[]) : (int * CoveredOrUncovered) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> CoveredOrUncovered.Covered
        |"1"B -> CoveredOrUncovered.Uncovered
        | x -> failwith (sprintf "ReadCoveredOrUncovered unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadOptAttribute (pos:int) (bs:byte[]) : (int*OptAttribute) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) OptAttribute.OptAttribute


let ReadSecurityExchange (pos:int) (bs:byte[]) : (int*SecurityExchange) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecurityExchange.SecurityExchange


let ReadNotifyBrokerOfCredit (pos:int) (bs:byte[]) : (int*NotifyBrokerOfCredit) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) NotifyBrokerOfCredit.NotifyBrokerOfCredit


let ReadAllocHandlInst (pos:int) (bs:byte[]) : (int * AllocHandlInst) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> AllocHandlInst.Match
        |"2"B -> AllocHandlInst.Forward
        |"3"B -> AllocHandlInst.ForwardAndMatch
        | x -> failwith (sprintf "ReadAllocHandlInst unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMaxShow (pos:int) (bs:byte[]) : (int*MaxShow) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) MaxShow.MaxShow


let ReadPegOffsetValue (pos:int) (bs:byte[]) : (int*PegOffsetValue) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) PegOffsetValue.PegOffsetValue


// compound read
let ReadXmlData (pos:int) (bs:byte[]) : (int * XmlData) =
    ReadLengthDataCompoundField "213"B (pos:int) (bs:byte[]) XmlData.XmlData


let ReadSettlInstRefID (pos:int) (bs:byte[]) : (int*SettlInstRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SettlInstRefID.SettlInstRefID


let ReadNoRoutingIDs (pos:int) (bs:byte[]) : (int*NoRoutingIDs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoRoutingIDs.NoRoutingIDs


let ReadRoutingType (pos:int) (bs:byte[]) : (int * RoutingType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> RoutingType.TargetFirm
        |"2"B -> RoutingType.TargetList
        |"3"B -> RoutingType.BlockFirm
        |"4"B -> RoutingType.BlockList
        | x -> failwith (sprintf "ReadRoutingType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadRoutingID (pos:int) (bs:byte[]) : (int*RoutingID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) RoutingID.RoutingID


let ReadSpread (pos:int) (bs:byte[]) : (int*Spread) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) Spread.Spread


let ReadBenchmarkCurveCurrency (pos:int) (bs:byte[]) : (int*BenchmarkCurveCurrency) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) BenchmarkCurveCurrency.BenchmarkCurveCurrency


let ReadBenchmarkCurveName (pos:int) (bs:byte[]) : (int * BenchmarkCurveName) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"MuniAAA"B -> BenchmarkCurveName.Muniaaa
        |"FutureSWAP"B -> BenchmarkCurveName.Futureswap
        |"LIBID"B -> BenchmarkCurveName.Libid
        |"LIBOR"B -> BenchmarkCurveName.Libor
        |"OTHER"B -> BenchmarkCurveName.Other
        |"SWAP"B -> BenchmarkCurveName.Swap
        |"Treasury"B -> BenchmarkCurveName.Treasury
        |"Euribor"B -> BenchmarkCurveName.Euribor
        |"Pfandbriefe"B -> BenchmarkCurveName.Pfandbriefe
        |"EONIA"B -> BenchmarkCurveName.Eonia
        |"SONIA"B -> BenchmarkCurveName.Sonia
        |"EUREPO"B -> BenchmarkCurveName.Eurepo
        | x -> failwith (sprintf "ReadBenchmarkCurveName unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadBenchmarkCurvePoint (pos:int) (bs:byte[]) : (int*BenchmarkCurvePoint) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) BenchmarkCurvePoint.BenchmarkCurvePoint


let ReadCouponRate (pos:int) (bs:byte[]) : (int*CouponRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) CouponRate.CouponRate


let ReadCouponPaymentDate (pos:int) (bs:byte[]) : (int*CouponPaymentDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CouponPaymentDate.CouponPaymentDate


let ReadIssueDate (pos:int) (bs:byte[]) : (int*IssueDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) IssueDate.IssueDate


let ReadRepurchaseTerm (pos:int) (bs:byte[]) : (int*RepurchaseTerm) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) RepurchaseTerm.RepurchaseTerm


let ReadRepurchaseRate (pos:int) (bs:byte[]) : (int*RepurchaseRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) RepurchaseRate.RepurchaseRate


let ReadFactor (pos:int) (bs:byte[]) : (int*Factor) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) Factor.Factor


let ReadTradeOriginationDate (pos:int) (bs:byte[]) : (int*TradeOriginationDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradeOriginationDate.TradeOriginationDate


let ReadExDate (pos:int) (bs:byte[]) : (int*ExDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ExDate.ExDate


let ReadContractMultiplier (pos:int) (bs:byte[]) : (int*ContractMultiplier) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) ContractMultiplier.ContractMultiplier


let ReadNoStipulations (pos:int) (bs:byte[]) : (int*NoStipulations) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoStipulations.NoStipulations


let ReadStipulationType (pos:int) (bs:byte[]) : (int * StipulationType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"AMT"B -> StipulationType.Amt
        |"AUTOREINV"B -> StipulationType.AutoReinvestmentAtOrBetter
        |"BANKQUAL"B -> StipulationType.BankQualified
        |"BGNCON"B -> StipulationType.BargainConditions
        |"COUPON"B -> StipulationType.CouponRange
        |"CURRENCY"B -> StipulationType.IsoCurrencyCode
        |"CUSTOMDATE"B -> StipulationType.CustomStartEndDate
        |"GEOG"B -> StipulationType.GeographicsAndPercentRange
        |"HAIRCUT"B -> StipulationType.ValuationDiscount
        |"INSURED"B -> StipulationType.Insured
        |"ISSUE"B -> StipulationType.YearOrYearMonthOfIssue
        |"ISSUER"B -> StipulationType.IssuersTicker
        |"ISSUESIZE"B -> StipulationType.IssueSizeRange
        |"LOOKBACK"B -> StipulationType.LookbackDays
        |"LOT"B -> StipulationType.ExplicitLotIdentifier
        |"LOTVAR"B -> StipulationType.LotVariance
        |"MAT"B -> StipulationType.MaturityYearAndMonth
        |"MATURITY"B -> StipulationType.MaturityRange
        |"MAXSUBS"B -> StipulationType.MaximumSubstitutions
        |"MINQTY"B -> StipulationType.MinimumQuantity
        |"MININCR"B -> StipulationType.MinimumIncrement
        |"MINDNOM"B -> StipulationType.MinimumDenomination
        |"PAYFREQ"B -> StipulationType.PaymentFrequencyCalendar
        |"PIECES"B -> StipulationType.NumberOfPieces
        |"PMAX"B -> StipulationType.PoolsMaximum
        |"PPM"B -> StipulationType.PoolsPerMillion
        |"PPL"B -> StipulationType.PoolsPerLot
        |"PPT"B -> StipulationType.PoolsPerTrade
        |"PRICE"B -> StipulationType.PriceRange
        |"PRICEFREQ"B -> StipulationType.PricingFrequency
        |"PROD"B -> StipulationType.ProductionYear
        |"PROTECT"B -> StipulationType.CallProtection
        |"PURPOSE"B -> StipulationType.Purpose
        |"PXSOURCE"B -> StipulationType.BenchmarkPriceSource
        |"RATING"B -> StipulationType.RatingSourceAndRange
        |"RESTRICTED"B -> StipulationType.Restricted
        |"SECTOR"B -> StipulationType.MarketSector
        |"SECTYPE"B -> StipulationType.SecuritytypeIncludedOrExcluded
        |"STRUCT"B -> StipulationType.Structure
        |"SUBSFREQ"B -> StipulationType.SubstitutionsFrequency
        |"SUBSLEFT"B -> StipulationType.SubstitutionsLeft
        |"TEXT"B -> StipulationType.FreeformText
        |"TRDVAR"B -> StipulationType.TradeVariance
        |"WAC"B -> StipulationType.WeightedAverageCoupon
        |"WAL"B -> StipulationType.WeightedAverageLifeCoupon
        |"WALA"B -> StipulationType.WeightedAverageLoanAge
        |"WAM"B -> StipulationType.WeightedAverageMaturity
        |"WHOLE"B -> StipulationType.WholePool
        |"YIELD"B -> StipulationType.YieldRange
        |"SMM"B -> StipulationType.SingleMonthlyMortality
        |"CPR"B -> StipulationType.ConstantPrepaymentRate
        |"CPY"B -> StipulationType.ConstantPrepaymentYield
        |"CPP"B -> StipulationType.ConstantPrepaymentPenalty
        |"ABS"B -> StipulationType.AbsolutePrepaymentSpeed
        |"MPR"B -> StipulationType.MonthlyPrepaymentRate
        |"PSA"B -> StipulationType.PercentOfBmaPrepaymentCurve
        |"PPC"B -> StipulationType.PercentOfProspectusPrepaymentCurve
        |"MHP"B -> StipulationType.PercentOfManufacturedHousingPrepaymentCurve
        |"HEP"B -> StipulationType.FinalCprOfHomeEquityPrepaymentCurve
        | x -> failwith (sprintf "ReadStipulationType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadStipulationValue (pos:int) (bs:byte[]) : (int * StipulationValue) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"CD"B -> StipulationValue.SpecialCumDividend
        |"XD"B -> StipulationValue.SpecialExDividend
        |"CC"B -> StipulationValue.SpecialCumCoupon
        |"XC"B -> StipulationValue.SpecialExCoupon
        |"CB"B -> StipulationValue.SpecialCumBonus
        |"XB"B -> StipulationValue.SpecialExBonus
        |"CR"B -> StipulationValue.SpecialCumRights
        |"XR"B -> StipulationValue.SpecialExRights
        |"CP"B -> StipulationValue.SpecialCumCapitalRepayments
        |"XP"B -> StipulationValue.SpecialExCapitalRepayments
        |"CS"B -> StipulationValue.CashSettlement
        |"SP"B -> StipulationValue.SpecialPrice
        |"TR"B -> StipulationValue.ReportForEuropeanEquityMarketSecurities
        |"GD"B -> StipulationValue.GuaranteedDelivery
        | x -> failwith (sprintf "ReadStipulationValue unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadYieldType (pos:int) (bs:byte[]) : (int * YieldType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"AFTERTAX"B -> YieldType.AfterTaxYield
        |"ANNUAL"B -> YieldType.AnnualYield
        |"ATISSUE"B -> YieldType.YieldAtIssue
        |"AVGMATURITY"B -> YieldType.YieldToAverageMaturity
        |"BOOK"B -> YieldType.BookYield
        |"CALL"B -> YieldType.YieldToNextCall
        |"CHANGE"B -> YieldType.YieldChangeSinceClose
        |"CLOSE"B -> YieldType.ClosingYield
        |"COMPOUND"B -> YieldType.CompoundYield
        |"CURRENT"B -> YieldType.CurrentYield
        |"GROSS"B -> YieldType.TrueGrossYield
        |"GOVTEQUIV"B -> YieldType.GovernmentEquivalentYield
        |"INFLATION"B -> YieldType.YieldWithInflationAssumption
        |"INVERSEFLOATER"B -> YieldType.InverseFloaterBondYield
        |"LASTCLOSE"B -> YieldType.MostRecentClosingYield
        |"LASTMONTH"B -> YieldType.ClosingYieldMostRecentMonth
        |"LASTQUARTER"B -> YieldType.ClosingYieldMostRecentQuarter
        |"LASTYEAR"B -> YieldType.ClosingYieldMostRecentYear
        |"LONGAVGLIFE"B -> YieldType.YieldToLongestAverageLife
        |"MARK"B -> YieldType.MarkToMarketYield
        |"MATURITY"B -> YieldType.YieldToMaturity
        |"NEXTREFUND"B -> YieldType.YieldToNextRefund
        |"OPENAVG"B -> YieldType.OpenAverageYield
        |"PUT"B -> YieldType.YieldToNextPut
        |"PREVCLOSE"B -> YieldType.PreviousCloseYield
        |"PROCEEDS"B -> YieldType.ProceedsYield
        |"SEMIANNUAL"B -> YieldType.SemiAnnualYield
        |"SHORTAVGLIFE"B -> YieldType.YieldToShortestAverageLife
        |"SIMPLE"B -> YieldType.SimpleYield
        |"TAXEQUIV"B -> YieldType.TaxEquivalentYield
        |"TENDER"B -> YieldType.YieldToTenderDate
        |"TRUE"B -> YieldType.TrueYield
        |"VALUE1_32"B -> YieldType.YieldValueOf132
        |"WORST"B -> YieldType.YieldToWorst
        | x -> failwith (sprintf "ReadYieldType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadYield (pos:int) (bs:byte[]) : (int*Yield) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) Yield.Yield


let ReadTotalTakedown (pos:int) (bs:byte[]) : (int*TotalTakedown) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotalTakedown.TotalTakedown


let ReadConcession (pos:int) (bs:byte[]) : (int*Concession) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) Concession.Concession


let ReadRepoCollateralSecurityType (pos:int) (bs:byte[]) : (int*RepoCollateralSecurityType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) RepoCollateralSecurityType.RepoCollateralSecurityType


let ReadRedemptionDate (pos:int) (bs:byte[]) : (int*RedemptionDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) RedemptionDate.RedemptionDate


let ReadUnderlyingCouponPaymentDate (pos:int) (bs:byte[]) : (int*UnderlyingCouponPaymentDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingCouponPaymentDate.UnderlyingCouponPaymentDate


let ReadUnderlyingIssueDate (pos:int) (bs:byte[]) : (int*UnderlyingIssueDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingIssueDate.UnderlyingIssueDate


let ReadUnderlyingRepoCollateralSecurityType (pos:int) (bs:byte[]) : (int*UnderlyingRepoCollateralSecurityType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) UnderlyingRepoCollateralSecurityType.UnderlyingRepoCollateralSecurityType


let ReadUnderlyingRepurchaseTerm (pos:int) (bs:byte[]) : (int*UnderlyingRepurchaseTerm) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) UnderlyingRepurchaseTerm.UnderlyingRepurchaseTerm


let ReadUnderlyingRepurchaseRate (pos:int) (bs:byte[]) : (int*UnderlyingRepurchaseRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) UnderlyingRepurchaseRate.UnderlyingRepurchaseRate


let ReadUnderlyingFactor (pos:int) (bs:byte[]) : (int*UnderlyingFactor) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) UnderlyingFactor.UnderlyingFactor


let ReadUnderlyingRedemptionDate (pos:int) (bs:byte[]) : (int*UnderlyingRedemptionDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingRedemptionDate.UnderlyingRedemptionDate


let ReadLegCouponPaymentDate (pos:int) (bs:byte[]) : (int*LegCouponPaymentDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegCouponPaymentDate.LegCouponPaymentDate


let ReadLegIssueDate (pos:int) (bs:byte[]) : (int*LegIssueDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegIssueDate.LegIssueDate


let ReadLegRepoCollateralSecurityType (pos:int) (bs:byte[]) : (int*LegRepoCollateralSecurityType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LegRepoCollateralSecurityType.LegRepoCollateralSecurityType


let ReadLegRepurchaseTerm (pos:int) (bs:byte[]) : (int*LegRepurchaseTerm) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LegRepurchaseTerm.LegRepurchaseTerm


let ReadLegRepurchaseRate (pos:int) (bs:byte[]) : (int*LegRepurchaseRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegRepurchaseRate.LegRepurchaseRate


let ReadLegFactor (pos:int) (bs:byte[]) : (int*LegFactor) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegFactor.LegFactor


let ReadLegRedemptionDate (pos:int) (bs:byte[]) : (int*LegRedemptionDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegRedemptionDate.LegRedemptionDate


let ReadCreditRating (pos:int) (bs:byte[]) : (int*CreditRating) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CreditRating.CreditRating


let ReadUnderlyingCreditRating (pos:int) (bs:byte[]) : (int*UnderlyingCreditRating) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingCreditRating.UnderlyingCreditRating


let ReadLegCreditRating (pos:int) (bs:byte[]) : (int*LegCreditRating) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegCreditRating.LegCreditRating


let ReadTradedFlatSwitch (pos:int) (bs:byte[]) : (int*TradedFlatSwitch) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) TradedFlatSwitch.TradedFlatSwitch


let ReadBasisFeatureDate (pos:int) (bs:byte[]) : (int*BasisFeatureDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) BasisFeatureDate.BasisFeatureDate


let ReadBasisFeaturePrice (pos:int) (bs:byte[]) : (int*BasisFeaturePrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) BasisFeaturePrice.BasisFeaturePrice


let ReadMDReqID (pos:int) (bs:byte[]) : (int*MDReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MDReqID.MDReqID


let ReadSubscriptionRequestType (pos:int) (bs:byte[]) : (int * SubscriptionRequestType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> SubscriptionRequestType.Snapshot
        |"1"B -> SubscriptionRequestType.SnapshotPlusUpdates
        |"2"B -> SubscriptionRequestType.DisablePreviousSnapshotPlusUpdateRequest
        | x -> failwith (sprintf "ReadSubscriptionRequestType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMarketDepth (pos:int) (bs:byte[]) : (int*MarketDepth) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) MarketDepth.MarketDepth


let ReadMDUpdateType (pos:int) (bs:byte[]) : (int * MDUpdateType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> MDUpdateType.FullRefresh
        |"1"B -> MDUpdateType.IncrementalRefresh
        | x -> failwith (sprintf "ReadMDUpdateType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadAggregatedBook (pos:int) (bs:byte[]) : (int*AggregatedBook) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) AggregatedBook.AggregatedBook


let ReadNoMDEntryTypes (pos:int) (bs:byte[]) : (int*NoMDEntryTypes) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoMDEntryTypes.NoMDEntryTypes


let ReadNoMDEntries (pos:int) (bs:byte[]) : (int*NoMDEntries) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoMDEntries.NoMDEntries


let ReadMDEntryType (pos:int) (bs:byte[]) : (int * MDEntryType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> MDEntryType.Bid
        |"1"B -> MDEntryType.Offer
        |"2"B -> MDEntryType.Trade
        |"3"B -> MDEntryType.IndexValue
        |"4"B -> MDEntryType.OpeningPrice
        |"5"B -> MDEntryType.ClosingPrice
        |"6"B -> MDEntryType.SettlementPrice
        |"7"B -> MDEntryType.TradingSessionHighPrice
        |"8"B -> MDEntryType.TradingSessionLowPrice
        |"9"B -> MDEntryType.TradingSessionVwapPrice
        |"A"B -> MDEntryType.Imbalance
        |"B"B -> MDEntryType.TradeVolume
        |"C"B -> MDEntryType.OpenInterest
        | x -> failwith (sprintf "ReadMDEntryType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMDEntryPx (pos:int) (bs:byte[]) : (int*MDEntryPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) MDEntryPx.MDEntryPx


let ReadMDEntrySize (pos:int) (bs:byte[]) : (int*MDEntrySize) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) MDEntrySize.MDEntrySize


let ReadMDEntryDate (pos:int) (bs:byte[]) : (int*MDEntryDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MDEntryDate.MDEntryDate


let ReadMDEntryTime (pos:int) (bs:byte[]) : (int*MDEntryTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MDEntryTime.MDEntryTime


let ReadTickDirection (pos:int) (bs:byte[]) : (int * TickDirection) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> TickDirection.PlusTick
        |"1"B -> TickDirection.ZeroPlusTick
        |"2"B -> TickDirection.MinusTick
        |"3"B -> TickDirection.ZeroMinusTick
        | x -> failwith (sprintf "ReadTickDirection unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMDMkt (pos:int) (bs:byte[]) : (int*MDMkt) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MDMkt.MDMkt


let ReadQuoteCondition (pos:int) (bs:byte[]) : (int * QuoteCondition) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"A"B -> QuoteCondition.OpenActive
        |"B"B -> QuoteCondition.ClosedInactive
        |"C"B -> QuoteCondition.ExchangeBest
        |"D"B -> QuoteCondition.ConsolidatedBest
        |"E"B -> QuoteCondition.Locked
        |"F"B -> QuoteCondition.Crossed
        |"G"B -> QuoteCondition.Depth
        |"H"B -> QuoteCondition.FastTrading
        |"I"B -> QuoteCondition.NonFirm
        | x -> failwith (sprintf "ReadQuoteCondition unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTradeCondition (pos:int) (bs:byte[]) : (int * TradeCondition) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"A"B -> TradeCondition.CashMarket
        |"B"B -> TradeCondition.AveragePriceTrade
        |"C"B -> TradeCondition.CashTrade
        |"D"B -> TradeCondition.NextDayMarket
        |"E"B -> TradeCondition.OpeningReopeningTradeDetail
        |"F"B -> TradeCondition.IntradayTradeDetail
        |"G"B -> TradeCondition.Rule127
        |"H"B -> TradeCondition.Rule155
        |"I"B -> TradeCondition.SoldLast
        |"J"B -> TradeCondition.NextDayTrade
        |"K"B -> TradeCondition.Opened
        |"L"B -> TradeCondition.Seller
        |"M"B -> TradeCondition.Sold
        |"N"B -> TradeCondition.StoppedStock
        |"P"B -> TradeCondition.ImbalanceMoreBuyers
        |"Q"B -> TradeCondition.ImbalanceMoreSellers
        |"R"B -> TradeCondition.OpeningPrice
        | x -> failwith (sprintf "ReadTradeCondition unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMDEntryID (pos:int) (bs:byte[]) : (int*MDEntryID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MDEntryID.MDEntryID


let ReadMDUpdateAction (pos:int) (bs:byte[]) : (int * MDUpdateAction) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> MDUpdateAction.New
        |"1"B -> MDUpdateAction.Change
        |"2"B -> MDUpdateAction.Delete
        | x -> failwith (sprintf "ReadMDUpdateAction unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMDEntryRefID (pos:int) (bs:byte[]) : (int*MDEntryRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MDEntryRefID.MDEntryRefID


let ReadMDReqRejReason (pos:int) (bs:byte[]) : (int * MDReqRejReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> MDReqRejReason.UnknownSymbol
        |"1"B -> MDReqRejReason.DuplicateMdreqid
        |"2"B -> MDReqRejReason.InsufficientBandwidth
        |"3"B -> MDReqRejReason.InsufficientPermissions
        |"4"B -> MDReqRejReason.UnsupportedSubscriptionrequesttype
        |"5"B -> MDReqRejReason.UnsupportedMarketdepth
        |"6"B -> MDReqRejReason.UnsupportedMdupdatetype
        |"7"B -> MDReqRejReason.UnsupportedAggregatedbook
        |"8"B -> MDReqRejReason.UnsupportedMdentrytype
        |"9"B -> MDReqRejReason.UnsupportedTradingsessionid
        |"A"B -> MDReqRejReason.UnsupportedScope
        |"B"B -> MDReqRejReason.UnsupportedOpenclosesettleflag
        |"C"B -> MDReqRejReason.UnsupportedMdimplicitdelete
        | x -> failwith (sprintf "ReadMDReqRejReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMDEntryOriginator (pos:int) (bs:byte[]) : (int*MDEntryOriginator) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MDEntryOriginator.MDEntryOriginator


let ReadLocationID (pos:int) (bs:byte[]) : (int*LocationID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LocationID.LocationID


let ReadDeskID (pos:int) (bs:byte[]) : (int*DeskID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) DeskID.DeskID


let ReadDeleteReason (pos:int) (bs:byte[]) : (int * DeleteReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> DeleteReason.CancelationTradeBust
        |"1"B -> DeleteReason.Error
        | x -> failwith (sprintf "ReadDeleteReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadOpenCloseSettlFlag (pos:int) (bs:byte[]) : (int * OpenCloseSettlFlag) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> OpenCloseSettlFlag.DailyOpenCloseSettlementEntry
        |"1"B -> OpenCloseSettlFlag.SessionOpenCloseSettlementEntry
        |"2"B -> OpenCloseSettlFlag.DeliverySettlementEntry
        |"3"B -> OpenCloseSettlFlag.ExpectedEntry
        |"4"B -> OpenCloseSettlFlag.EntryFromPreviousBusinessDay
        |"5"B -> OpenCloseSettlFlag.TheoreticalPriceValue
        | x -> failwith (sprintf "ReadOpenCloseSettlFlag unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSellerDays (pos:int) (bs:byte[]) : (int*SellerDays) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) SellerDays.SellerDays


let ReadMDEntryBuyer (pos:int) (bs:byte[]) : (int*MDEntryBuyer) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MDEntryBuyer.MDEntryBuyer


let ReadMDEntrySeller (pos:int) (bs:byte[]) : (int*MDEntrySeller) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MDEntrySeller.MDEntrySeller


let ReadMDEntryPositionNo (pos:int) (bs:byte[]) : (int*MDEntryPositionNo) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) MDEntryPositionNo.MDEntryPositionNo


let ReadFinancialStatus (pos:int) (bs:byte[]) : (int * FinancialStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> FinancialStatus.Bankrupt
        |"2"B -> FinancialStatus.PendingDelisting
        | x -> failwith (sprintf "ReadFinancialStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCorporateAction (pos:int) (bs:byte[]) : (int * CorporateAction) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"A"B -> CorporateAction.ExDividend
        |"B"B -> CorporateAction.ExDistribution
        |"C"B -> CorporateAction.ExRights
        |"D"B -> CorporateAction.New
        |"E"B -> CorporateAction.ExInterest
        | x -> failwith (sprintf "ReadCorporateAction unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadDefBidSize (pos:int) (bs:byte[]) : (int*DefBidSize) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) DefBidSize.DefBidSize


let ReadDefOfferSize (pos:int) (bs:byte[]) : (int*DefOfferSize) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) DefOfferSize.DefOfferSize


let ReadNoQuoteEntries (pos:int) (bs:byte[]) : (int*NoQuoteEntries) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoQuoteEntries.NoQuoteEntries


let ReadNoQuoteSets (pos:int) (bs:byte[]) : (int*NoQuoteSets) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoQuoteSets.NoQuoteSets


let ReadQuoteStatus (pos:int) (bs:byte[]) : (int * QuoteStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> QuoteStatus.Accepted
        |"1"B -> QuoteStatus.CanceledForSymbol
        |"2"B -> QuoteStatus.CanceledForSecurityType
        |"3"B -> QuoteStatus.CanceledForUnderlying
        |"4"B -> QuoteStatus.CanceledAll
        |"5"B -> QuoteStatus.Rejected
        |"6"B -> QuoteStatus.RemovedFromMarket
        |"7"B -> QuoteStatus.Expired
        |"8"B -> QuoteStatus.Query
        |"9"B -> QuoteStatus.QuoteNotFound
        |"10"B -> QuoteStatus.Pending
        |"11"B -> QuoteStatus.Pass
        |"12"B -> QuoteStatus.LockedMarketWarning
        |"13"B -> QuoteStatus.CrossMarketWarning
        |"14"B -> QuoteStatus.CanceledDueToLockMarket
        |"15"B -> QuoteStatus.CanceledDueToCrossMarket
        | x -> failwith (sprintf "ReadQuoteStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadQuoteCancelType (pos:int) (bs:byte[]) : (int * QuoteCancelType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> QuoteCancelType.CancelForSymbol
        |"2"B -> QuoteCancelType.CancelForSecurityType
        |"3"B -> QuoteCancelType.CancelForUnderlyingSymbol
        |"4"B -> QuoteCancelType.CancelAllQuotes
        | x -> failwith (sprintf "ReadQuoteCancelType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadQuoteEntryID (pos:int) (bs:byte[]) : (int*QuoteEntryID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) QuoteEntryID.QuoteEntryID


let ReadQuoteRejectReason (pos:int) (bs:byte[]) : (int * QuoteRejectReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> QuoteRejectReason.UnknownSymbol
        |"2"B -> QuoteRejectReason.ExchangeClosed
        |"3"B -> QuoteRejectReason.QuoteRequestExceedsLimit
        |"4"B -> QuoteRejectReason.TooLateToEnter
        |"5"B -> QuoteRejectReason.UnknownQuote
        |"6"B -> QuoteRejectReason.DuplicateQuote
        |"7"B -> QuoteRejectReason.InvalidBidAskSpread
        |"8"B -> QuoteRejectReason.InvalidPrice
        |"9"B -> QuoteRejectReason.NotAuthorizedToQuoteSecurity
        |"99"B -> QuoteRejectReason.Other
        | x -> failwith (sprintf "ReadQuoteRejectReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadQuoteResponseLevel (pos:int) (bs:byte[]) : (int * QuoteResponseLevel) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> QuoteResponseLevel.NoAcknowledgement
        |"1"B -> QuoteResponseLevel.AcknowledgeOnlyNegativeOrErroneousQuotes
        |"2"B -> QuoteResponseLevel.AcknowledgeEachQuoteMessages
        | x -> failwith (sprintf "ReadQuoteResponseLevel unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadQuoteSetID (pos:int) (bs:byte[]) : (int*QuoteSetID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) QuoteSetID.QuoteSetID


let ReadQuoteRequestType (pos:int) (bs:byte[]) : (int * QuoteRequestType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> QuoteRequestType.Manual
        |"2"B -> QuoteRequestType.Automatic
        | x -> failwith (sprintf "ReadQuoteRequestType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTotNoQuoteEntries (pos:int) (bs:byte[]) : (int*TotNoQuoteEntries) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotNoQuoteEntries.TotNoQuoteEntries


let ReadUnderlyingSecurityIDSource (pos:int) (bs:byte[]) : (int*UnderlyingSecurityIDSource) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingSecurityIDSource.UnderlyingSecurityIDSource


let ReadUnderlyingIssuer (pos:int) (bs:byte[]) : (int*UnderlyingIssuer) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingIssuer.UnderlyingIssuer


let ReadUnderlyingSecurityDesc (pos:int) (bs:byte[]) : (int*UnderlyingSecurityDesc) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingSecurityDesc.UnderlyingSecurityDesc


let ReadUnderlyingSecurityExchange (pos:int) (bs:byte[]) : (int*UnderlyingSecurityExchange) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingSecurityExchange.UnderlyingSecurityExchange


let ReadUnderlyingSecurityID (pos:int) (bs:byte[]) : (int*UnderlyingSecurityID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingSecurityID.UnderlyingSecurityID


let ReadUnderlyingSecurityType (pos:int) (bs:byte[]) : (int*UnderlyingSecurityType) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingSecurityType.UnderlyingSecurityType


let ReadUnderlyingSymbol (pos:int) (bs:byte[]) : (int*UnderlyingSymbol) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingSymbol.UnderlyingSymbol


let ReadUnderlyingSymbolSfx (pos:int) (bs:byte[]) : (int*UnderlyingSymbolSfx) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingSymbolSfx.UnderlyingSymbolSfx


let ReadUnderlyingMaturityMonthYear (pos:int) (bs:byte[]) : (int*UnderlyingMaturityMonthYear) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingMaturityMonthYear.UnderlyingMaturityMonthYear


let ReadUnderlyingPutOrCall (pos:int) (bs:byte[]) : (int * UnderlyingPutOrCall) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> UnderlyingPutOrCall.Put
        |"1"B -> UnderlyingPutOrCall.Call
        | x -> failwith (sprintf "ReadUnderlyingPutOrCall unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadUnderlyingStrikePrice (pos:int) (bs:byte[]) : (int*UnderlyingStrikePrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) UnderlyingStrikePrice.UnderlyingStrikePrice


let ReadUnderlyingOptAttribute (pos:int) (bs:byte[]) : (int*UnderlyingOptAttribute) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) UnderlyingOptAttribute.UnderlyingOptAttribute


let ReadUnderlyingCurrency (pos:int) (bs:byte[]) : (int*UnderlyingCurrency) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingCurrency.UnderlyingCurrency


let ReadSecurityReqID (pos:int) (bs:byte[]) : (int*SecurityReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecurityReqID.SecurityReqID


let ReadSecurityRequestType (pos:int) (bs:byte[]) : (int * SecurityRequestType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> SecurityRequestType.RequestSecurityIdentityAndSpecifications
        |"1"B -> SecurityRequestType.RequestSecurityIdentityForTheSpecificationsProvided
        |"2"B -> SecurityRequestType.RequestListSecurityTypes
        |"3"B -> SecurityRequestType.RequestListSecurities
        | x -> failwith (sprintf "ReadSecurityRequestType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSecurityResponseID (pos:int) (bs:byte[]) : (int*SecurityResponseID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecurityResponseID.SecurityResponseID


let ReadSecurityResponseType (pos:int) (bs:byte[]) : (int * SecurityResponseType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> SecurityResponseType.AcceptSecurityProposalAsIs
        |"2"B -> SecurityResponseType.AcceptSecurityProposalWithRevisionsAsIndicatedInTheMessage
        |"3"B -> SecurityResponseType.ListOfSecurityTypesReturnedPerRequest
        |"4"B -> SecurityResponseType.ListOfSecuritiesReturnedPerRequest
        |"5"B -> SecurityResponseType.RejectSecurityProposal
        |"6"B -> SecurityResponseType.CanNotMatchSelectionCriteria
        | x -> failwith (sprintf "ReadSecurityResponseType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSecurityStatusReqID (pos:int) (bs:byte[]) : (int*SecurityStatusReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecurityStatusReqID.SecurityStatusReqID


let ReadUnsolicitedIndicator (pos:int) (bs:byte[]) : (int*UnsolicitedIndicator) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) UnsolicitedIndicator.UnsolicitedIndicator


let ReadSecurityTradingStatus (pos:int) (bs:byte[]) : (int * SecurityTradingStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> SecurityTradingStatus.OpeningDelay
        |"2"B -> SecurityTradingStatus.TradingHalt
        |"3"B -> SecurityTradingStatus.Resume
        |"4"B -> SecurityTradingStatus.NoOpenNoResume
        |"5"B -> SecurityTradingStatus.PriceIndication
        |"6"B -> SecurityTradingStatus.TradingRangeIndication
        |"7"B -> SecurityTradingStatus.MarketImbalanceBuy
        |"8"B -> SecurityTradingStatus.MarketImbalanceSell
        |"9"B -> SecurityTradingStatus.MarketOnCloseImbalanceBuy
        |"10"B -> SecurityTradingStatus.MarketOnCloseImbalanceSell
        |"11"B -> SecurityTradingStatus.NotAssigned
        |"12"B -> SecurityTradingStatus.NoMarketImbalance
        |"13"B -> SecurityTradingStatus.NoMarketOnCloseImbalance
        |"14"B -> SecurityTradingStatus.ItsPreOpening
        |"15"B -> SecurityTradingStatus.NewPriceIndication
        |"16"B -> SecurityTradingStatus.TradeDisseminationTime
        |"17"B -> SecurityTradingStatus.ReadyToTradeStartOfSession
        |"18"B -> SecurityTradingStatus.NotAvailableForTradingEndOfSession
        |"19"B -> SecurityTradingStatus.NotTradedOnThisMarket
        |"20"B -> SecurityTradingStatus.UnknownOrInvalid
        |"21"B -> SecurityTradingStatus.PreOpen
        |"22"B -> SecurityTradingStatus.OpeningRotation
        |"23"B -> SecurityTradingStatus.FastMarket
        | x -> failwith (sprintf "ReadSecurityTradingStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadHaltReason (pos:int) (bs:byte[]) : (int * HaltReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"I"B -> HaltReason.OrderImbalance
        |"X"B -> HaltReason.EquipmentChangeover
        |"P"B -> HaltReason.NewsPending
        |"D"B -> HaltReason.NewsDissemination
        |"E"B -> HaltReason.OrderInflux
        |"M"B -> HaltReason.AdditionalInformation
        | x -> failwith (sprintf "ReadHaltReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadInViewOfCommon (pos:int) (bs:byte[]) : (int*InViewOfCommon) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) InViewOfCommon.InViewOfCommon


let ReadDueToRelated (pos:int) (bs:byte[]) : (int*DueToRelated) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) DueToRelated.DueToRelated


let ReadBuyVolume (pos:int) (bs:byte[]) : (int*BuyVolume) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) BuyVolume.BuyVolume


let ReadSellVolume (pos:int) (bs:byte[]) : (int*SellVolume) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) SellVolume.SellVolume


let ReadHighPx (pos:int) (bs:byte[]) : (int*HighPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) HighPx.HighPx


let ReadLowPx (pos:int) (bs:byte[]) : (int*LowPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LowPx.LowPx


let ReadAdjustment (pos:int) (bs:byte[]) : (int * Adjustment) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> Adjustment.Cancel
        |"2"B -> Adjustment.Error
        |"3"B -> Adjustment.Correction
        | x -> failwith (sprintf "ReadAdjustment unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTradSesReqID (pos:int) (bs:byte[]) : (int*TradSesReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradSesReqID.TradSesReqID


let ReadTradingSessionID (pos:int) (bs:byte[]) : (int*TradingSessionID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradingSessionID.TradingSessionID


let ReadContraTrader (pos:int) (bs:byte[]) : (int*ContraTrader) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ContraTrader.ContraTrader


let ReadTradSesMethod (pos:int) (bs:byte[]) : (int * TradSesMethod) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> TradSesMethod.Electronic
        |"2"B -> TradSesMethod.OpenOutcry
        |"3"B -> TradSesMethod.TwoParty
        | x -> failwith (sprintf "ReadTradSesMethod unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTradSesMode (pos:int) (bs:byte[]) : (int * TradSesMode) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> TradSesMode.Testing
        |"2"B -> TradSesMode.Simulated
        |"3"B -> TradSesMode.Production
        | x -> failwith (sprintf "ReadTradSesMode unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTradSesStatus (pos:int) (bs:byte[]) : (int * TradSesStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> TradSesStatus.Unknown
        |"1"B -> TradSesStatus.Halted
        |"2"B -> TradSesStatus.Open
        |"3"B -> TradSesStatus.Closed
        |"4"B -> TradSesStatus.PreOpen
        |"5"B -> TradSesStatus.PreClose
        |"6"B -> TradSesStatus.RequestRejected
        | x -> failwith (sprintf "ReadTradSesStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTradSesStartTime (pos:int) (bs:byte[]) : (int*TradSesStartTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradSesStartTime.TradSesStartTime


let ReadTradSesOpenTime (pos:int) (bs:byte[]) : (int*TradSesOpenTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradSesOpenTime.TradSesOpenTime


let ReadTradSesPreCloseTime (pos:int) (bs:byte[]) : (int*TradSesPreCloseTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradSesPreCloseTime.TradSesPreCloseTime


let ReadTradSesCloseTime (pos:int) (bs:byte[]) : (int*TradSesCloseTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradSesCloseTime.TradSesCloseTime


let ReadTradSesEndTime (pos:int) (bs:byte[]) : (int*TradSesEndTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradSesEndTime.TradSesEndTime


let ReadNumberOfOrders (pos:int) (bs:byte[]) : (int*NumberOfOrders) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NumberOfOrders.NumberOfOrders


let ReadMessageEncoding (pos:int) (bs:byte[]) : (int * MessageEncoding) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"ISO-2022-JP"B -> MessageEncoding.Iso2022Jp
        |"EUC-JP"B -> MessageEncoding.EucJp
        |"SHIFT_JIS"B -> MessageEncoding.ShiftJis
        |"UTF-8"B -> MessageEncoding.Utf8
        | x -> failwith (sprintf "ReadMessageEncoding unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


// compound read
let ReadEncodedIssuer (pos:int) (bs:byte[]) : (int * EncodedIssuer) =
    ReadLengthDataCompoundField "349"B (pos:int) (bs:byte[]) EncodedIssuer.EncodedIssuer


// compound read
let ReadEncodedSecurityDesc (pos:int) (bs:byte[]) : (int * EncodedSecurityDesc) =
    ReadLengthDataCompoundField "351"B (pos:int) (bs:byte[]) EncodedSecurityDesc.EncodedSecurityDesc


// compound read
let ReadEncodedListExecInst (pos:int) (bs:byte[]) : (int * EncodedListExecInst) =
    ReadLengthDataCompoundField "353"B (pos:int) (bs:byte[]) EncodedListExecInst.EncodedListExecInst


// compound read
let ReadEncodedText (pos:int) (bs:byte[]) : (int * EncodedText) =
    ReadLengthDataCompoundField "355"B (pos:int) (bs:byte[]) EncodedText.EncodedText


// compound read
let ReadEncodedSubject (pos:int) (bs:byte[]) : (int * EncodedSubject) =
    ReadLengthDataCompoundField "357"B (pos:int) (bs:byte[]) EncodedSubject.EncodedSubject


// compound read
let ReadEncodedHeadline (pos:int) (bs:byte[]) : (int * EncodedHeadline) =
    ReadLengthDataCompoundField "359"B (pos:int) (bs:byte[]) EncodedHeadline.EncodedHeadline


// compound read
let ReadEncodedAllocText (pos:int) (bs:byte[]) : (int * EncodedAllocText) =
    ReadLengthDataCompoundField "361"B (pos:int) (bs:byte[]) EncodedAllocText.EncodedAllocText


// compound read
let ReadEncodedUnderlyingIssuer (pos:int) (bs:byte[]) : (int * EncodedUnderlyingIssuer) =
    ReadLengthDataCompoundField "363"B (pos:int) (bs:byte[]) EncodedUnderlyingIssuer.EncodedUnderlyingIssuer


// compound read
let ReadEncodedUnderlyingSecurityDesc (pos:int) (bs:byte[]) : (int * EncodedUnderlyingSecurityDesc) =
    ReadLengthDataCompoundField "365"B (pos:int) (bs:byte[]) EncodedUnderlyingSecurityDesc.EncodedUnderlyingSecurityDesc


let ReadAllocPrice (pos:int) (bs:byte[]) : (int*AllocPrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) AllocPrice.AllocPrice


let ReadQuoteSetValidUntilTime (pos:int) (bs:byte[]) : (int*QuoteSetValidUntilTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) QuoteSetValidUntilTime.QuoteSetValidUntilTime


let ReadQuoteEntryRejectReason (pos:int) (bs:byte[]) : (int * QuoteEntryRejectReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> QuoteEntryRejectReason.UnknownSymbol
        |"2"B -> QuoteEntryRejectReason.ExchangeClosed
        |"3"B -> QuoteEntryRejectReason.QuoteExceedsLimit
        |"4"B -> QuoteEntryRejectReason.TooLateToEnter
        |"5"B -> QuoteEntryRejectReason.UnknownQuote
        |"6"B -> QuoteEntryRejectReason.DuplicateQuote
        |"7"B -> QuoteEntryRejectReason.InvalidBidAskSpread
        |"8"B -> QuoteEntryRejectReason.InvalidPrice
        |"9"B -> QuoteEntryRejectReason.NotAuthorizedToQuoteSecurity
        | x -> failwith (sprintf "ReadQuoteEntryRejectReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadLastMsgSeqNumProcessed (pos:int) (bs:byte[]) : (int*LastMsgSeqNumProcessed) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LastMsgSeqNumProcessed.LastMsgSeqNumProcessed


let ReadRefTagID (pos:int) (bs:byte[]) : (int*RefTagID) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) RefTagID.RefTagID


let ReadRefMsgType (pos:int) (bs:byte[]) : (int*RefMsgType) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) RefMsgType.RefMsgType


let ReadSessionRejectReason (pos:int) (bs:byte[]) : (int * SessionRejectReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> SessionRejectReason.InvalidTagNumber
        |"1"B -> SessionRejectReason.RequiredTagMissing
        |"2"B -> SessionRejectReason.TagNotDefinedForThisMessageType
        |"3"B -> SessionRejectReason.UndefinedTag
        |"4"B -> SessionRejectReason.TagSpecifiedWithoutAValue
        |"5"B -> SessionRejectReason.ValueIsIncorrect
        |"6"B -> SessionRejectReason.IncorrectDataFormatForValue
        |"7"B -> SessionRejectReason.DecryptionProblem
        |"8"B -> SessionRejectReason.SignatureProblem
        |"9"B -> SessionRejectReason.CompidProblem
        |"10"B -> SessionRejectReason.SendingtimeAccuracyProblem
        |"11"B -> SessionRejectReason.InvalidMsgtype
        |"12"B -> SessionRejectReason.XmlValidationError
        |"13"B -> SessionRejectReason.TagAppearsMoreThanOnce
        |"14"B -> SessionRejectReason.TagSpecifiedOutOfRequiredOrder
        |"15"B -> SessionRejectReason.RepeatingGroupFieldsOutOfOrder
        |"16"B -> SessionRejectReason.IncorrectNumingroupCountForRepeatingGroup
        |"17"B -> SessionRejectReason.NonDataValueIncludesFieldDelimiter
        |"99"B -> SessionRejectReason.Other
        | x -> failwith (sprintf "ReadSessionRejectReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadBidRequestTransType (pos:int) (bs:byte[]) : (int * BidRequestTransType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"N"B -> BidRequestTransType.New
        |"C"B -> BidRequestTransType.Cancel
        | x -> failwith (sprintf "ReadBidRequestTransType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadContraBroker (pos:int) (bs:byte[]) : (int*ContraBroker) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ContraBroker.ContraBroker


let ReadComplianceID (pos:int) (bs:byte[]) : (int*ComplianceID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ComplianceID.ComplianceID


let ReadSolicitedFlag (pos:int) (bs:byte[]) : (int*SolicitedFlag) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) SolicitedFlag.SolicitedFlag


let ReadExecRestatementReason (pos:int) (bs:byte[]) : (int * ExecRestatementReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> ExecRestatementReason.GtCorporateAction
        |"1"B -> ExecRestatementReason.GtRenewalRestatement
        |"2"B -> ExecRestatementReason.VerbalChange
        |"3"B -> ExecRestatementReason.RepricingOfOrder
        |"4"B -> ExecRestatementReason.BrokerOption
        |"5"B -> ExecRestatementReason.PartialDeclineOfOrderqty
        |"6"B -> ExecRestatementReason.CancelOnTradingHalt
        |"7"B -> ExecRestatementReason.CancelOnSystemFailure
        |"8"B -> ExecRestatementReason.MarketOption
        |"9"B -> ExecRestatementReason.CanceledNotBest
        | x -> failwith (sprintf "ReadExecRestatementReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadBusinessRejectRefID (pos:int) (bs:byte[]) : (int*BusinessRejectRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) BusinessRejectRefID.BusinessRejectRefID


let ReadBusinessRejectReason (pos:int) (bs:byte[]) : (int * BusinessRejectReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> BusinessRejectReason.Other
        |"1"B -> BusinessRejectReason.UnkownId
        |"2"B -> BusinessRejectReason.UnknownSecurity
        |"3"B -> BusinessRejectReason.UnsupportedMessageType
        |"4"B -> BusinessRejectReason.ApplicationNotAvailable
        |"5"B -> BusinessRejectReason.ConditionallyRequiredFieldMissing
        |"6"B -> BusinessRejectReason.NotAuthorized
        |"7"B -> BusinessRejectReason.DelivertoFirmNotAvailableAtThisTime
        | x -> failwith (sprintf "ReadBusinessRejectReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadGrossTradeAmt (pos:int) (bs:byte[]) : (int*GrossTradeAmt) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) GrossTradeAmt.GrossTradeAmt


let ReadNoContraBrokers (pos:int) (bs:byte[]) : (int*NoContraBrokers) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoContraBrokers.NoContraBrokers


let ReadMaxMessageSize (pos:int) (bs:byte[]) : (int*MaxMessageSize) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) MaxMessageSize.MaxMessageSize


let ReadNoMsgTypes (pos:int) (bs:byte[]) : (int*NoMsgTypes) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoMsgTypes.NoMsgTypes


let ReadMsgDirection (pos:int) (bs:byte[]) : (int * MsgDirection) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"S"B -> MsgDirection.Send
        |"R"B -> MsgDirection.Receive
        | x -> failwith (sprintf "ReadMsgDirection unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoTradingSessions (pos:int) (bs:byte[]) : (int*NoTradingSessions) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoTradingSessions.NoTradingSessions


let ReadTotalVolumeTraded (pos:int) (bs:byte[]) : (int*TotalVolumeTraded) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) TotalVolumeTraded.TotalVolumeTraded


let ReadDiscretionInst (pos:int) (bs:byte[]) : (int * DiscretionInst) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> DiscretionInst.RelatedToDisplayedPrice
        |"1"B -> DiscretionInst.RelatedToMarketPrice
        |"2"B -> DiscretionInst.RelatedToPrimaryPrice
        |"3"B -> DiscretionInst.RelatedToLocalPrimaryPrice
        |"4"B -> DiscretionInst.RelatedToMidpointPrice
        |"5"B -> DiscretionInst.RelatedToLastTradePrice
        |"6"B -> DiscretionInst.RelatedToVwap
        | x -> failwith (sprintf "ReadDiscretionInst unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadDiscretionOffsetValue (pos:int) (bs:byte[]) : (int*DiscretionOffsetValue) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) DiscretionOffsetValue.DiscretionOffsetValue


let ReadBidID (pos:int) (bs:byte[]) : (int*BidID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) BidID.BidID


let ReadClientBidID (pos:int) (bs:byte[]) : (int*ClientBidID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ClientBidID.ClientBidID


let ReadListName (pos:int) (bs:byte[]) : (int*ListName) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ListName.ListName


let ReadTotNoRelatedSym (pos:int) (bs:byte[]) : (int*TotNoRelatedSym) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotNoRelatedSym.TotNoRelatedSym


let ReadBidType (pos:int) (bs:byte[]) : (int * BidType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> BidType.NonDisclosed
        |"2"B -> BidType.DisclosedStyle
        |"3"B -> BidType.NoBiddingProcess
        | x -> failwith (sprintf "ReadBidType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNumTickets (pos:int) (bs:byte[]) : (int*NumTickets) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NumTickets.NumTickets


let ReadSideValue1 (pos:int) (bs:byte[]) : (int*SideValue1) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) SideValue1.SideValue1


let ReadSideValue2 (pos:int) (bs:byte[]) : (int*SideValue2) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) SideValue2.SideValue2


let ReadNoBidDescriptors (pos:int) (bs:byte[]) : (int*NoBidDescriptors) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoBidDescriptors.NoBidDescriptors


let ReadBidDescriptorType (pos:int) (bs:byte[]) : (int * BidDescriptorType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> BidDescriptorType.Sector
        |"2"B -> BidDescriptorType.Country
        |"3"B -> BidDescriptorType.Index
        | x -> failwith (sprintf "ReadBidDescriptorType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadBidDescriptor (pos:int) (bs:byte[]) : (int*BidDescriptor) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) BidDescriptor.BidDescriptor


let ReadSideValueInd (pos:int) (bs:byte[]) : (int * SideValueInd) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> SideValueInd.Sidevalue1
        |"2"B -> SideValueInd.Sidevalue2
        | x -> failwith (sprintf "ReadSideValueInd unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadLiquidityPctLow (pos:int) (bs:byte[]) : (int*LiquidityPctLow) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LiquidityPctLow.LiquidityPctLow


let ReadLiquidityPctHigh (pos:int) (bs:byte[]) : (int*LiquidityPctHigh) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LiquidityPctHigh.LiquidityPctHigh


let ReadLiquidityValue (pos:int) (bs:byte[]) : (int*LiquidityValue) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LiquidityValue.LiquidityValue


let ReadEFPTrackingError (pos:int) (bs:byte[]) : (int*EFPTrackingError) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) EFPTrackingError.EFPTrackingError


let ReadFairValue (pos:int) (bs:byte[]) : (int*FairValue) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) FairValue.FairValue


let ReadOutsideIndexPct (pos:int) (bs:byte[]) : (int*OutsideIndexPct) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) OutsideIndexPct.OutsideIndexPct


let ReadValueOfFutures (pos:int) (bs:byte[]) : (int*ValueOfFutures) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) ValueOfFutures.ValueOfFutures


let ReadLiquidityIndType (pos:int) (bs:byte[]) : (int * LiquidityIndType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> LiquidityIndType.FivedayMovingAverage
        |"2"B -> LiquidityIndType.TwentydayMovingAverage
        |"3"B -> LiquidityIndType.NormalMarketSize
        |"4"B -> LiquidityIndType.Other
        | x -> failwith (sprintf "ReadLiquidityIndType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadWtAverageLiquidity (pos:int) (bs:byte[]) : (int*WtAverageLiquidity) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) WtAverageLiquidity.WtAverageLiquidity


let ReadExchangeForPhysical (pos:int) (bs:byte[]) : (int*ExchangeForPhysical) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) ExchangeForPhysical.ExchangeForPhysical


let ReadOutMainCntryUIndex (pos:int) (bs:byte[]) : (int*OutMainCntryUIndex) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) OutMainCntryUIndex.OutMainCntryUIndex


let ReadCrossPercent (pos:int) (bs:byte[]) : (int*CrossPercent) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) CrossPercent.CrossPercent


let ReadProgRptReqs (pos:int) (bs:byte[]) : (int * ProgRptReqs) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> ProgRptReqs.BuysideExplicitlyRequestsStatusUsingStatusrequest
        |"2"B -> ProgRptReqs.SellsidePeriodicallySendsStatusUsingListstatus
        |"3"B -> ProgRptReqs.RealTimeExecutionReports
        | x -> failwith (sprintf "ReadProgRptReqs unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadProgPeriodInterval (pos:int) (bs:byte[]) : (int*ProgPeriodInterval) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) ProgPeriodInterval.ProgPeriodInterval


let ReadIncTaxInd (pos:int) (bs:byte[]) : (int * IncTaxInd) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> IncTaxInd.Net
        |"2"B -> IncTaxInd.Gross
        | x -> failwith (sprintf "ReadIncTaxInd unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNumBidders (pos:int) (bs:byte[]) : (int*NumBidders) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NumBidders.NumBidders


let ReadBidTradeType (pos:int) (bs:byte[]) : (int * BidTradeType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"R"B -> BidTradeType.RiskTrade
        |"G"B -> BidTradeType.VwapGuarantee
        |"A"B -> BidTradeType.Agency
        |"J"B -> BidTradeType.GuaranteedClose
        | x -> failwith (sprintf "ReadBidTradeType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadBasisPxType (pos:int) (bs:byte[]) : (int * BasisPxType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"2"B -> BasisPxType.ClosingPriceAtMorningSession
        |"3"B -> BasisPxType.ClosingPrice
        |"4"B -> BasisPxType.CurrentPrice
        |"5"B -> BasisPxType.Sq
        |"6"B -> BasisPxType.VwapThroughADay
        |"7"B -> BasisPxType.VwapThroughAMorningSession
        |"8"B -> BasisPxType.VwapThroughAnAfternoonSession
        |"9"B -> BasisPxType.VwapThroughADayExceptYori
        |"A"B -> BasisPxType.VwapThroughAMorningSessionExceptYori
        |"B"B -> BasisPxType.VwapThroughAnAfternoonSessionExceptYori
        |"C"B -> BasisPxType.Strike
        |"D"B -> BasisPxType.Open
        |"Z"B -> BasisPxType.Others
        | x -> failwith (sprintf "ReadBasisPxType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoBidComponents (pos:int) (bs:byte[]) : (int*NoBidComponents) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoBidComponents.NoBidComponents


let ReadCountry (pos:int) (bs:byte[]) : (int*Country) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Country.Country


let ReadTotNoStrikes (pos:int) (bs:byte[]) : (int*TotNoStrikes) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotNoStrikes.TotNoStrikes


let ReadPriceType (pos:int) (bs:byte[]) : (int * PriceType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> PriceType.Percentage
        |"2"B -> PriceType.PerUnit
        |"3"B -> PriceType.FixedAmount
        |"4"B -> PriceType.Discount
        |"5"B -> PriceType.Premium
        |"6"B -> PriceType.Spread
        |"7"B -> PriceType.TedPrice
        |"8"B -> PriceType.TedYield
        |"9"B -> PriceType.Yield
        |"10"B -> PriceType.FixedCabinetTradePrice
        |"11"B -> PriceType.VariableCabinetTradePrice
        | x -> failwith (sprintf "ReadPriceType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadDayOrderQty (pos:int) (bs:byte[]) : (int*DayOrderQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) DayOrderQty.DayOrderQty


let ReadDayCumQty (pos:int) (bs:byte[]) : (int*DayCumQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) DayCumQty.DayCumQty


let ReadDayAvgPx (pos:int) (bs:byte[]) : (int*DayAvgPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) DayAvgPx.DayAvgPx


let ReadGTBookingInst (pos:int) (bs:byte[]) : (int * GTBookingInst) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> GTBookingInst.BookOutAllTradesOnDayOfExecution
        |"1"B -> GTBookingInst.AccumulateExecutionsUntilOrderIsFilledOrExpires
        |"2"B -> GTBookingInst.AccumulateUntilVerballyNotifiedOtherwise
        | x -> failwith (sprintf "ReadGTBookingInst unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoStrikes (pos:int) (bs:byte[]) : (int*NoStrikes) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoStrikes.NoStrikes


let ReadListStatusType (pos:int) (bs:byte[]) : (int * ListStatusType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> ListStatusType.Ack
        |"2"B -> ListStatusType.Response
        |"3"B -> ListStatusType.Timed
        |"4"B -> ListStatusType.Execstarted
        |"5"B -> ListStatusType.Alldone
        |"6"B -> ListStatusType.Alert
        | x -> failwith (sprintf "ReadListStatusType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNetGrossInd (pos:int) (bs:byte[]) : (int * NetGrossInd) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> NetGrossInd.Net
        |"2"B -> NetGrossInd.Gross
        | x -> failwith (sprintf "ReadNetGrossInd unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadListOrderStatus (pos:int) (bs:byte[]) : (int * ListOrderStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> ListOrderStatus.Inbiddingprocess
        |"2"B -> ListOrderStatus.Receivedforexecution
        |"3"B -> ListOrderStatus.Executing
        |"4"B -> ListOrderStatus.Canceling
        |"5"B -> ListOrderStatus.Alert
        |"6"B -> ListOrderStatus.AllDone
        |"7"B -> ListOrderStatus.Reject
        | x -> failwith (sprintf "ReadListOrderStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadExpireDate (pos:int) (bs:byte[]) : (int*ExpireDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ExpireDate.ExpireDate


let ReadListExecInstType (pos:int) (bs:byte[]) : (int * ListExecInstType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> ListExecInstType.Immediate
        |"2"B -> ListExecInstType.WaitForExecuteInstruction
        |"3"B -> ListExecInstType.ExchangeSwitchCivOrderSellDriven
        |"4"B -> ListExecInstType.ExchangeSwitchCivOrderBuyDrivenCashTopUp
        |"5"B -> ListExecInstType.ExchangeSwitchCivOrderBuyDrivenCashWithdraw
        | x -> failwith (sprintf "ReadListExecInstType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCxlRejResponseTo (pos:int) (bs:byte[]) : (int * CxlRejResponseTo) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> CxlRejResponseTo.OrderCancelRequest
        |"2"B -> CxlRejResponseTo.OrderCancelReplaceRequest
        | x -> failwith (sprintf "ReadCxlRejResponseTo unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadUnderlyingCouponRate (pos:int) (bs:byte[]) : (int*UnderlyingCouponRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) UnderlyingCouponRate.UnderlyingCouponRate


let ReadUnderlyingContractMultiplier (pos:int) (bs:byte[]) : (int*UnderlyingContractMultiplier) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) UnderlyingContractMultiplier.UnderlyingContractMultiplier


let ReadContraTradeQty (pos:int) (bs:byte[]) : (int*ContraTradeQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) ContraTradeQty.ContraTradeQty


let ReadContraTradeTime (pos:int) (bs:byte[]) : (int*ContraTradeTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ContraTradeTime.ContraTradeTime


let ReadLiquidityNumSecurities (pos:int) (bs:byte[]) : (int*LiquidityNumSecurities) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LiquidityNumSecurities.LiquidityNumSecurities


let ReadMultiLegReportingType (pos:int) (bs:byte[]) : (int * MultiLegReportingType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> MultiLegReportingType.SingleSecurity
        |"2"B -> MultiLegReportingType.IndividualLegOfAMultiLegSecurity
        |"3"B -> MultiLegReportingType.MultiLegSecurity
        | x -> failwith (sprintf "ReadMultiLegReportingType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadStrikeTime (pos:int) (bs:byte[]) : (int*StrikeTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) StrikeTime.StrikeTime


let ReadListStatusText (pos:int) (bs:byte[]) : (int*ListStatusText) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ListStatusText.ListStatusText


// compound read
let ReadEncodedListStatusText (pos:int) (bs:byte[]) : (int * EncodedListStatusText) =
    ReadLengthDataCompoundField "446"B (pos:int) (bs:byte[]) EncodedListStatusText.EncodedListStatusText


let ReadPartyIDSource (pos:int) (bs:byte[]) : (int * PartyIDSource) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"B"B -> PartyIDSource.Bic
        |"C"B -> PartyIDSource.GenerallyAcceptedMarketParticipantIdentifier
        |"D"B -> PartyIDSource.ProprietaryCustomCode
        |"E"B -> PartyIDSource.IsoCountryCode
        |"F"B -> PartyIDSource.SettlementEntityLocation
        |"G"B -> PartyIDSource.Mic
        |"H"B -> PartyIDSource.CsdParticipantMemberCode
        |"1"B -> PartyIDSource.KoreanInvestorId
        |"2"B -> PartyIDSource.TaiwaneseQualifiedForeignInvestorIdQfiiFid
        |"3"B -> PartyIDSource.TaiwaneseTradingAccount
        |"4"B -> PartyIDSource.MalaysianCentralDepositoryNumber
        |"5"B -> PartyIDSource.ChineseBShare
        |"6"B -> PartyIDSource.UkNationalInsuranceOrPensionNumber
        |"7"B -> PartyIDSource.UsSocialSecurityNumber
        |"8"B -> PartyIDSource.UsEmployerIdentificationNumber
        |"9"B -> PartyIDSource.AustralianBusinessNumber
        |"A"B -> PartyIDSource.AustralianTaxFileNumber
        |"I"B -> PartyIDSource.DirectedBroker
        | x -> failwith (sprintf "ReadPartyIDSource unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPartyID (pos:int) (bs:byte[]) : (int*PartyID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) PartyID.PartyID


let ReadNetChgPrevDay (pos:int) (bs:byte[]) : (int*NetChgPrevDay) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) NetChgPrevDay.NetChgPrevDay


let ReadPartyRole (pos:int) (bs:byte[]) : (int * PartyRole) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> PartyRole.ExecutingFirm
        |"2"B -> PartyRole.BrokerOfCredit
        |"3"B -> PartyRole.ClientId
        |"4"B -> PartyRole.ClearingFirm
        |"5"B -> PartyRole.InvestorId
        |"6"B -> PartyRole.IntroducingFirm
        |"7"B -> PartyRole.EnteringFirm
        |"8"B -> PartyRole.LocateLendingFirm
        |"9"B -> PartyRole.FundManagerClientId
        |"10"B -> PartyRole.SettlementLocation
        |"11"B -> PartyRole.OrderOriginationTrader
        |"12"B -> PartyRole.ExecutingTrader
        |"13"B -> PartyRole.OrderOriginationFirm
        |"14"B -> PartyRole.GiveupClearingFirm
        |"15"B -> PartyRole.CorrespondantClearingFirm
        |"16"B -> PartyRole.ExecutingSystem
        |"17"B -> PartyRole.ContraFirm
        |"18"B -> PartyRole.ContraClearingFirm
        |"19"B -> PartyRole.SponsoringFirm
        |"20"B -> PartyRole.UnderlyingContraFirm
        |"21"B -> PartyRole.ClearingOrganization
        |"22"B -> PartyRole.Exchange
        |"24"B -> PartyRole.CustomerAccount
        |"25"B -> PartyRole.CorrespondentClearingOrganization
        |"26"B -> PartyRole.CorrespondentBroker
        |"27"B -> PartyRole.BuyerSeller
        |"28"B -> PartyRole.Custodian
        |"29"B -> PartyRole.Intermediary
        |"30"B -> PartyRole.Agent
        |"31"B -> PartyRole.SubCustodian
        |"32"B -> PartyRole.Beneficiary
        |"33"B -> PartyRole.InterestedParty
        |"34"B -> PartyRole.RegulatoryBody
        |"35"B -> PartyRole.LiquidityProvider
        |"36"B -> PartyRole.EnteringTrader
        |"37"B -> PartyRole.ContraTrader
        |"38"B -> PartyRole.PositionAccount
        | x -> failwith (sprintf "ReadPartyRole unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoPartyIDs (pos:int) (bs:byte[]) : (int*NoPartyIDs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoPartyIDs.NoPartyIDs


let ReadNoSecurityAltID (pos:int) (bs:byte[]) : (int*NoSecurityAltID) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoSecurityAltID.NoSecurityAltID


let ReadSecurityAltID (pos:int) (bs:byte[]) : (int*SecurityAltID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecurityAltID.SecurityAltID


let ReadSecurityAltIDSource (pos:int) (bs:byte[]) : (int*SecurityAltIDSource) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecurityAltIDSource.SecurityAltIDSource


let ReadNoUnderlyingSecurityAltID (pos:int) (bs:byte[]) : (int*NoUnderlyingSecurityAltID) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoUnderlyingSecurityAltID.NoUnderlyingSecurityAltID


let ReadUnderlyingSecurityAltID (pos:int) (bs:byte[]) : (int*UnderlyingSecurityAltID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingSecurityAltID.UnderlyingSecurityAltID


let ReadUnderlyingSecurityAltIDSource (pos:int) (bs:byte[]) : (int*UnderlyingSecurityAltIDSource) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingSecurityAltIDSource.UnderlyingSecurityAltIDSource


let ReadProduct (pos:int) (bs:byte[]) : (int * Product) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> Product.Agency
        |"2"B -> Product.Commodity
        |"3"B -> Product.Corporate
        |"4"B -> Product.Currency
        |"5"B -> Product.Equity
        |"6"B -> Product.Government
        |"7"B -> Product.Index
        |"8"B -> Product.Loan
        |"9"B -> Product.Moneymarket
        |"10"B -> Product.Mortgage
        |"11"B -> Product.Municipal
        |"12"B -> Product.Other
        |"13"B -> Product.Financing
        | x -> failwith (sprintf "ReadProduct unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCFICode (pos:int) (bs:byte[]) : (int*CFICode) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CFICode.CFICode


let ReadUnderlyingProduct (pos:int) (bs:byte[]) : (int*UnderlyingProduct) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) UnderlyingProduct.UnderlyingProduct


let ReadUnderlyingCFICode (pos:int) (bs:byte[]) : (int*UnderlyingCFICode) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingCFICode.UnderlyingCFICode


let ReadTestMessageIndicator (pos:int) (bs:byte[]) : (int*TestMessageIndicator) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) TestMessageIndicator.TestMessageIndicator


let ReadQuantityType (pos:int) (bs:byte[]) : (int * QuantityType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> QuantityType.Shares
        |"2"B -> QuantityType.Bonds
        |"3"B -> QuantityType.Currentface
        |"4"B -> QuantityType.Originalface
        |"5"B -> QuantityType.Currency
        |"6"B -> QuantityType.Contracts
        |"7"B -> QuantityType.Other
        |"8"B -> QuantityType.Par
        | x -> failwith (sprintf "ReadQuantityType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadBookingRefID (pos:int) (bs:byte[]) : (int*BookingRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) BookingRefID.BookingRefID


let ReadIndividualAllocID (pos:int) (bs:byte[]) : (int*IndividualAllocID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) IndividualAllocID.IndividualAllocID


let ReadRoundingDirection (pos:int) (bs:byte[]) : (int * RoundingDirection) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> RoundingDirection.RoundToNearest
        |"1"B -> RoundingDirection.RoundDown
        |"2"B -> RoundingDirection.RoundUp
        | x -> failwith (sprintf "ReadRoundingDirection unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadRoundingModulus (pos:int) (bs:byte[]) : (int*RoundingModulus) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) RoundingModulus.RoundingModulus


let ReadCountryOfIssue (pos:int) (bs:byte[]) : (int*CountryOfIssue) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CountryOfIssue.CountryOfIssue


let ReadStateOrProvinceOfIssue (pos:int) (bs:byte[]) : (int*StateOrProvinceOfIssue) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) StateOrProvinceOfIssue.StateOrProvinceOfIssue


let ReadLocaleOfIssue (pos:int) (bs:byte[]) : (int*LocaleOfIssue) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LocaleOfIssue.LocaleOfIssue


let ReadNoRegistDtls (pos:int) (bs:byte[]) : (int*NoRegistDtls) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoRegistDtls.NoRegistDtls


let ReadMailingDtls (pos:int) (bs:byte[]) : (int*MailingDtls) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MailingDtls.MailingDtls


let ReadInvestorCountryOfResidence (pos:int) (bs:byte[]) : (int*InvestorCountryOfResidence) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) InvestorCountryOfResidence.InvestorCountryOfResidence


let ReadPaymentRef (pos:int) (bs:byte[]) : (int*PaymentRef) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) PaymentRef.PaymentRef


let ReadDistribPaymentMethod (pos:int) (bs:byte[]) : (int * DistribPaymentMethod) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> DistribPaymentMethod.Crest
        |"2"B -> DistribPaymentMethod.Nscc
        |"3"B -> DistribPaymentMethod.Euroclear
        |"4"B -> DistribPaymentMethod.Clearstream
        |"5"B -> DistribPaymentMethod.Cheque
        |"6"B -> DistribPaymentMethod.TelegraphicTransfer
        |"7"B -> DistribPaymentMethod.Fedwire
        |"8"B -> DistribPaymentMethod.DirectCredit
        |"9"B -> DistribPaymentMethod.AchCredit
        |"10"B -> DistribPaymentMethod.Bpay
        |"11"B -> DistribPaymentMethod.HighValueClearingSystem
        |"12"B -> DistribPaymentMethod.ReinvestInFund
        | x -> failwith (sprintf "ReadDistribPaymentMethod unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCashDistribCurr (pos:int) (bs:byte[]) : (int*CashDistribCurr) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CashDistribCurr.CashDistribCurr


let ReadCommCurrency (pos:int) (bs:byte[]) : (int*CommCurrency) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CommCurrency.CommCurrency


let ReadCancellationRights (pos:int) (bs:byte[]) : (int * CancellationRights) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"Y"B -> CancellationRights.Yes
        |"N"B -> CancellationRights.NoExecutionOnly
        |"M"B -> CancellationRights.NoWaiverAgreement
        |"O"B -> CancellationRights.NoInstitutional
        | x -> failwith (sprintf "ReadCancellationRights unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMoneyLaunderingStatus (pos:int) (bs:byte[]) : (int * MoneyLaunderingStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"Y"B -> MoneyLaunderingStatus.Passed
        |"N"B -> MoneyLaunderingStatus.NotChecked
        |"1"B -> MoneyLaunderingStatus.ExemptBelowTheLimit
        |"2"B -> MoneyLaunderingStatus.ExemptClientMoneyTypeExemption
        |"3"B -> MoneyLaunderingStatus.ExemptAuthorisedCreditOrFinancialInstitution
        | x -> failwith (sprintf "ReadMoneyLaunderingStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMailingInst (pos:int) (bs:byte[]) : (int*MailingInst) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MailingInst.MailingInst


let ReadTransBkdTime (pos:int) (bs:byte[]) : (int*TransBkdTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TransBkdTime.TransBkdTime


let ReadExecPriceType (pos:int) (bs:byte[]) : (int * ExecPriceType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"B"B -> ExecPriceType.BidPrice
        |"C"B -> ExecPriceType.CreationPrice
        |"D"B -> ExecPriceType.CreationPricePlusAdjustmentPercent
        |"E"B -> ExecPriceType.CreationPricePlusAdjustmentAmount
        |"O"B -> ExecPriceType.OfferPrice
        |"P"B -> ExecPriceType.OfferPriceMinusAdjustmentPercent
        |"Q"B -> ExecPriceType.OfferPriceMinusAdjustmentAmount
        |"S"B -> ExecPriceType.SinglePrice
        | x -> failwith (sprintf "ReadExecPriceType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadExecPriceAdjustment (pos:int) (bs:byte[]) : (int*ExecPriceAdjustment) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) ExecPriceAdjustment.ExecPriceAdjustment


let ReadDateOfBirth (pos:int) (bs:byte[]) : (int*DateOfBirth) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) DateOfBirth.DateOfBirth


let ReadTradeReportTransType (pos:int) (bs:byte[]) : (int * TradeReportTransType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> TradeReportTransType.New
        |"1"B -> TradeReportTransType.Cancel
        |"2"B -> TradeReportTransType.Replace
        |"3"B -> TradeReportTransType.Release
        |"4"B -> TradeReportTransType.Reverse
        | x -> failwith (sprintf "ReadTradeReportTransType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCardHolderName (pos:int) (bs:byte[]) : (int*CardHolderName) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CardHolderName.CardHolderName


let ReadCardNumber (pos:int) (bs:byte[]) : (int*CardNumber) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CardNumber.CardNumber


let ReadCardExpDate (pos:int) (bs:byte[]) : (int*CardExpDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CardExpDate.CardExpDate


let ReadCardIssNum (pos:int) (bs:byte[]) : (int*CardIssNum) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CardIssNum.CardIssNum


let ReadPaymentMethod (pos:int) (bs:byte[]) : (int * PaymentMethod) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> PaymentMethod.Crest
        |"2"B -> PaymentMethod.Nscc
        |"3"B -> PaymentMethod.Euroclear
        |"4"B -> PaymentMethod.Clearstream
        |"5"B -> PaymentMethod.Cheque
        |"6"B -> PaymentMethod.TelegraphicTransfer
        |"7"B -> PaymentMethod.Fedwire
        |"8"B -> PaymentMethod.DebitCard
        |"9"B -> PaymentMethod.DirectDebit
        |"10"B -> PaymentMethod.DirectCredit
        |"11"B -> PaymentMethod.CreditCard
        |"12"B -> PaymentMethod.AchDebit
        |"13"B -> PaymentMethod.AchCredit
        |"14"B -> PaymentMethod.Bpay
        |"15"B -> PaymentMethod.HighValueClearingSystem
        | x -> failwith (sprintf "ReadPaymentMethod unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadRegistAcctType (pos:int) (bs:byte[]) : (int*RegistAcctType) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) RegistAcctType.RegistAcctType


let ReadDesignation (pos:int) (bs:byte[]) : (int*Designation) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Designation.Designation


let ReadTaxAdvantageType (pos:int) (bs:byte[]) : (int * TaxAdvantageType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> TaxAdvantageType.NNone
        |"1"B -> TaxAdvantageType.MaxiIsa
        |"2"B -> TaxAdvantageType.Tessa
        |"3"B -> TaxAdvantageType.MiniCashIsa
        |"4"B -> TaxAdvantageType.MiniStocksAndSharesIsa
        |"5"B -> TaxAdvantageType.MiniInsuranceIsa
        |"6"B -> TaxAdvantageType.CurrentYearPayment
        |"7"B -> TaxAdvantageType.PriorYearPayment
        |"8"B -> TaxAdvantageType.AssetTransfer
        |"9"B -> TaxAdvantageType.EmployeePriorYear
        |"999"B -> TaxAdvantageType.Other
        | x -> failwith (sprintf "ReadTaxAdvantageType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadRegistRejReasonText (pos:int) (bs:byte[]) : (int*RegistRejReasonText) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) RegistRejReasonText.RegistRejReasonText


let ReadFundRenewWaiv (pos:int) (bs:byte[]) : (int * FundRenewWaiv) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"Y"B -> FundRenewWaiv.Yes
        |"N"B -> FundRenewWaiv.No
        | x -> failwith (sprintf "ReadFundRenewWaiv unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCashDistribAgentName (pos:int) (bs:byte[]) : (int*CashDistribAgentName) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CashDistribAgentName.CashDistribAgentName


let ReadCashDistribAgentCode (pos:int) (bs:byte[]) : (int*CashDistribAgentCode) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CashDistribAgentCode.CashDistribAgentCode


let ReadCashDistribAgentAcctNumber (pos:int) (bs:byte[]) : (int*CashDistribAgentAcctNumber) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CashDistribAgentAcctNumber.CashDistribAgentAcctNumber


let ReadCashDistribPayRef (pos:int) (bs:byte[]) : (int*CashDistribPayRef) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CashDistribPayRef.CashDistribPayRef


let ReadCashDistribAgentAcctName (pos:int) (bs:byte[]) : (int*CashDistribAgentAcctName) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CashDistribAgentAcctName.CashDistribAgentAcctName


let ReadCardStartDate (pos:int) (bs:byte[]) : (int*CardStartDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CardStartDate.CardStartDate


let ReadPaymentDate (pos:int) (bs:byte[]) : (int*PaymentDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) PaymentDate.PaymentDate


let ReadPaymentRemitterID (pos:int) (bs:byte[]) : (int*PaymentRemitterID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) PaymentRemitterID.PaymentRemitterID


let ReadRegistStatus (pos:int) (bs:byte[]) : (int * RegistStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"A"B -> RegistStatus.Accepted
        |"R"B -> RegistStatus.Rejected
        |"H"B -> RegistStatus.Held
        |"N"B -> RegistStatus.Reminder
        | x -> failwith (sprintf "ReadRegistStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadRegistRejReasonCode (pos:int) (bs:byte[]) : (int * RegistRejReasonCode) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> RegistRejReasonCode.InvalidUnacceptableAccountType
        |"2"B -> RegistRejReasonCode.InvalidUnacceptableTaxExemptType
        |"3"B -> RegistRejReasonCode.InvalidUnacceptableOwnershipType
        |"4"B -> RegistRejReasonCode.InvalidUnacceptableNoRegDetls
        |"5"B -> RegistRejReasonCode.InvalidUnacceptableRegSeqNo
        |"6"B -> RegistRejReasonCode.InvalidUnacceptableRegDtls
        |"7"B -> RegistRejReasonCode.InvalidUnacceptableMailingDtls
        |"8"B -> RegistRejReasonCode.InvalidUnacceptableMailingInst
        |"9"B -> RegistRejReasonCode.InvalidUnacceptableInvestorId
        |"10"B -> RegistRejReasonCode.InvalidUnacceptableInvestorIdSource
        |"11"B -> RegistRejReasonCode.InvalidUnacceptableDateOfBirth
        |"12"B -> RegistRejReasonCode.InvalidUnacceptableInvestorCountryOfResidence
        |"13"B -> RegistRejReasonCode.InvalidUnacceptableNodistribinstns
        |"14"B -> RegistRejReasonCode.InvalidUnacceptableDistribPercentage
        |"15"B -> RegistRejReasonCode.InvalidUnacceptableDistribPaymentMethod
        |"16"B -> RegistRejReasonCode.InvalidUnacceptableCashDistribAgentAcctName
        |"17"B -> RegistRejReasonCode.InvalidUnacceptableCashDistribAgentCode
        |"18"B -> RegistRejReasonCode.InvalidUnacceptableCashDistribAgentAcctNum
        |"99"B -> RegistRejReasonCode.Other
        | x -> failwith (sprintf "ReadRegistRejReasonCode unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadRegistRefID (pos:int) (bs:byte[]) : (int*RegistRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) RegistRefID.RegistRefID


let ReadRegistDtls (pos:int) (bs:byte[]) : (int*RegistDtls) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) RegistDtls.RegistDtls


let ReadNoDistribInsts (pos:int) (bs:byte[]) : (int*NoDistribInsts) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoDistribInsts.NoDistribInsts


let ReadRegistEmail (pos:int) (bs:byte[]) : (int*RegistEmail) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) RegistEmail.RegistEmail


let ReadDistribPercentage (pos:int) (bs:byte[]) : (int*DistribPercentage) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) DistribPercentage.DistribPercentage


let ReadRegistID (pos:int) (bs:byte[]) : (int*RegistID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) RegistID.RegistID


let ReadRegistTransType (pos:int) (bs:byte[]) : (int * RegistTransType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> RegistTransType.New
        |"1"B -> RegistTransType.Replace
        |"2"B -> RegistTransType.Cancel
        | x -> failwith (sprintf "ReadRegistTransType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadExecValuationPoint (pos:int) (bs:byte[]) : (int*ExecValuationPoint) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ExecValuationPoint.ExecValuationPoint


let ReadOrderPercent (pos:int) (bs:byte[]) : (int*OrderPercent) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) OrderPercent.OrderPercent


let ReadOwnershipType (pos:int) (bs:byte[]) : (int * OwnershipType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"J"B -> OwnershipType.JointInvestors
        |"T"B -> OwnershipType.TenantsInCommon
        |"2"B -> OwnershipType.JointTrustees
        | x -> failwith (sprintf "ReadOwnershipType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoContAmts (pos:int) (bs:byte[]) : (int*NoContAmts) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoContAmts.NoContAmts


let ReadContAmtType (pos:int) (bs:byte[]) : (int * ContAmtType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> ContAmtType.CommissionAmount
        |"2"B -> ContAmtType.CommissionPercent
        |"3"B -> ContAmtType.InitialChargeAmount
        |"4"B -> ContAmtType.InitialChargePercent
        |"5"B -> ContAmtType.DiscountAmount
        |"6"B -> ContAmtType.DiscountPercent
        |"7"B -> ContAmtType.DilutionLevyAmount
        |"8"B -> ContAmtType.DilutionLevyPercent
        |"9"B -> ContAmtType.ExitChargeAmount
        | x -> failwith (sprintf "ReadContAmtType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadContAmtValue (pos:int) (bs:byte[]) : (int*ContAmtValue) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) ContAmtValue.ContAmtValue


let ReadContAmtCurr (pos:int) (bs:byte[]) : (int*ContAmtCurr) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ContAmtCurr.ContAmtCurr


let ReadOwnerType (pos:int) (bs:byte[]) : (int * OwnerType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> OwnerType.IndividualInvestor
        |"2"B -> OwnerType.PublicCompany
        |"3"B -> OwnerType.PrivateCompany
        |"4"B -> OwnerType.IndividualTrustee
        |"5"B -> OwnerType.CompanyTrustee
        |"6"B -> OwnerType.PensionPlan
        |"7"B -> OwnerType.CustodianUnderGiftsToMinorsAct
        |"8"B -> OwnerType.Trusts
        |"9"B -> OwnerType.Fiduciaries
        |"10"B -> OwnerType.NetworkingSubAccount
        |"11"B -> OwnerType.NonProfitOrganization
        |"12"B -> OwnerType.CorporateBody
        |"13"B -> OwnerType.Nominee
        | x -> failwith (sprintf "ReadOwnerType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPartySubID (pos:int) (bs:byte[]) : (int*PartySubID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) PartySubID.PartySubID


let ReadNestedPartyID (pos:int) (bs:byte[]) : (int*NestedPartyID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) NestedPartyID.NestedPartyID


let ReadNestedPartyIDSource (pos:int) (bs:byte[]) : (int*NestedPartyIDSource) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NestedPartyIDSource.NestedPartyIDSource


let ReadSecondaryClOrdID (pos:int) (bs:byte[]) : (int*SecondaryClOrdID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecondaryClOrdID.SecondaryClOrdID


let ReadSecondaryExecID (pos:int) (bs:byte[]) : (int*SecondaryExecID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecondaryExecID.SecondaryExecID


let ReadOrderCapacity (pos:int) (bs:byte[]) : (int * OrderCapacity) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"A"B -> OrderCapacity.Agency
        |"G"B -> OrderCapacity.Proprietary
        |"I"B -> OrderCapacity.Individual
        |"P"B -> OrderCapacity.Principal
        |"R"B -> OrderCapacity.RisklessPrincipal
        |"W"B -> OrderCapacity.AgentForOtherMember
        | x -> failwith (sprintf "ReadOrderCapacity unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadOrderRestrictions (pos:int) (bs:byte[]) : (int * OrderRestrictions) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> OrderRestrictions.ProgramTrade
        |"2"B -> OrderRestrictions.IndexArbitrage
        |"3"B -> OrderRestrictions.NonIndexArbitrage
        |"4"B -> OrderRestrictions.CompetingMarketMaker
        |"5"B -> OrderRestrictions.ActingAsMarketMakerOrSpecialistInTheSecurity
        |"6"B -> OrderRestrictions.ActingAsMarketMakerOrSpecialistInTheUnderlyingSecurityOfADerivativeSecurity
        |"7"B -> OrderRestrictions.ForeignEntity
        |"8"B -> OrderRestrictions.ExternalMarketParticipant
        |"9"B -> OrderRestrictions.ExternalInterConnectedMarketLinkage
        |"A"B -> OrderRestrictions.RisklessArbitrage
        | x -> failwith (sprintf "ReadOrderRestrictions unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMassCancelRequestType (pos:int) (bs:byte[]) : (int * MassCancelRequestType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> MassCancelRequestType.CancelOrdersForASecurity
        |"2"B -> MassCancelRequestType.CancelOrdersForAnUnderlyingSecurity
        |"3"B -> MassCancelRequestType.CancelOrdersForAProduct
        |"4"B -> MassCancelRequestType.CancelOrdersForACficode
        |"5"B -> MassCancelRequestType.CancelOrdersForASecuritytype
        |"6"B -> MassCancelRequestType.CancelOrdersForATradingSession
        |"7"B -> MassCancelRequestType.CancelAllOrders
        | x -> failwith (sprintf "ReadMassCancelRequestType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMassCancelResponse (pos:int) (bs:byte[]) : (int * MassCancelResponse) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> MassCancelResponse.CancelRequestRejected
        |"1"B -> MassCancelResponse.CancelOrdersForASecurity
        |"2"B -> MassCancelResponse.CancelOrdersForAnUnderlyingSecurity
        |"3"B -> MassCancelResponse.CancelOrdersForAProduct
        |"4"B -> MassCancelResponse.CancelOrdersForACficode
        |"5"B -> MassCancelResponse.CancelOrdersForASecuritytype
        |"6"B -> MassCancelResponse.CancelOrdersForATradingSession
        |"7"B -> MassCancelResponse.CancelAllOrders
        | x -> failwith (sprintf "ReadMassCancelResponse unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMassCancelRejectReason (pos:int) (bs:byte[]) : (int * MassCancelRejectReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> MassCancelRejectReason.MassCancelNotSupported
        |"1"B -> MassCancelRejectReason.InvalidOrUnknownSecurity
        |"2"B -> MassCancelRejectReason.InvalidOrUnknownUnderlying
        |"3"B -> MassCancelRejectReason.InvalidOrUnknownProduct
        |"4"B -> MassCancelRejectReason.InvalidOrUnknownCficode
        |"5"B -> MassCancelRejectReason.InvalidOrUnknownSecurityType
        |"6"B -> MassCancelRejectReason.InvalidOrUnknownTradingSession
        |"99"B -> MassCancelRejectReason.Other
        | x -> failwith (sprintf "ReadMassCancelRejectReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTotalAffectedOrders (pos:int) (bs:byte[]) : (int*TotalAffectedOrders) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotalAffectedOrders.TotalAffectedOrders


let ReadNoAffectedOrders (pos:int) (bs:byte[]) : (int*NoAffectedOrders) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoAffectedOrders.NoAffectedOrders


let ReadAffectedOrderID (pos:int) (bs:byte[]) : (int*AffectedOrderID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AffectedOrderID.AffectedOrderID


let ReadAffectedSecondaryOrderID (pos:int) (bs:byte[]) : (int*AffectedSecondaryOrderID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AffectedSecondaryOrderID.AffectedSecondaryOrderID


let ReadQuoteType (pos:int) (bs:byte[]) : (int * QuoteType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> QuoteType.Indicative
        |"1"B -> QuoteType.Tradeable
        |"2"B -> QuoteType.RestrictedTradeable
        |"3"B -> QuoteType.Counter
        | x -> failwith (sprintf "ReadQuoteType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNestedPartyRole (pos:int) (bs:byte[]) : (int*NestedPartyRole) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NestedPartyRole.NestedPartyRole


let ReadNoNestedPartyIDs (pos:int) (bs:byte[]) : (int*NoNestedPartyIDs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoNestedPartyIDs.NoNestedPartyIDs


let ReadTotalAccruedInterestAmt (pos:int) (bs:byte[]) : (int*TotalAccruedInterestAmt) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotalAccruedInterestAmt.TotalAccruedInterestAmt


let ReadMaturityDate (pos:int) (bs:byte[]) : (int*MaturityDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MaturityDate.MaturityDate


let ReadUnderlyingMaturityDate (pos:int) (bs:byte[]) : (int*UnderlyingMaturityDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingMaturityDate.UnderlyingMaturityDate


let ReadInstrRegistry (pos:int) (bs:byte[]) : (int*InstrRegistry) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) InstrRegistry.InstrRegistry


let ReadCashMargin (pos:int) (bs:byte[]) : (int * CashMargin) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> CashMargin.Cash
        |"2"B -> CashMargin.MarginOpen
        |"3"B -> CashMargin.MarginClose
        | x -> failwith (sprintf "ReadCashMargin unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNestedPartySubID (pos:int) (bs:byte[]) : (int*NestedPartySubID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) NestedPartySubID.NestedPartySubID


let ReadScope (pos:int) (bs:byte[]) : (int * Scope) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> Scope.Local
        |"2"B -> Scope.National
        |"3"B -> Scope.Global
        | x -> failwith (sprintf "ReadScope unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMDImplicitDelete (pos:int) (bs:byte[]) : (int*MDImplicitDelete) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) MDImplicitDelete.MDImplicitDelete


let ReadCrossID (pos:int) (bs:byte[]) : (int*CrossID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CrossID.CrossID


let ReadCrossType (pos:int) (bs:byte[]) : (int * CrossType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> CrossType.CrossTradeWhichIsExecutedCompletelyOrNot
        |"2"B -> CrossType.CrossTradeWhichIsExecutedPartiallyAndTheRestIsCancelled
        |"3"B -> CrossType.CrossTradeWhichIsPartiallyExecutedWithTheUnfilledPortionsRemainingActive
        |"4"B -> CrossType.CrossTradeIsExecutedWithExistingOrdersWithTheSamePrice
        | x -> failwith (sprintf "ReadCrossType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCrossPrioritization (pos:int) (bs:byte[]) : (int * CrossPrioritization) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> CrossPrioritization.NNone
        |"1"B -> CrossPrioritization.BuySideIsPrioritized
        |"2"B -> CrossPrioritization.SellSideIsPrioritized
        | x -> failwith (sprintf "ReadCrossPrioritization unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadOrigCrossID (pos:int) (bs:byte[]) : (int*OrigCrossID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) OrigCrossID.OrigCrossID


let ReadNoSides (pos:int) (bs:byte[]) : (int * NoSides) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> NoSides.OneSide
        |"2"B -> NoSides.BothSides
        | x -> failwith (sprintf "ReadNoSides unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadUsername (pos:int) (bs:byte[]) : (int*Username) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Username.Username


let ReadPassword (pos:int) (bs:byte[]) : (int*Password) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Password.Password


let ReadNoLegs (pos:int) (bs:byte[]) : (int*NoLegs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoLegs.NoLegs


let ReadLegCurrency (pos:int) (bs:byte[]) : (int*LegCurrency) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegCurrency.LegCurrency


let ReadTotNoSecurityTypes (pos:int) (bs:byte[]) : (int*TotNoSecurityTypes) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotNoSecurityTypes.TotNoSecurityTypes


let ReadNoSecurityTypes (pos:int) (bs:byte[]) : (int*NoSecurityTypes) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoSecurityTypes.NoSecurityTypes


let ReadSecurityListRequestType (pos:int) (bs:byte[]) : (int * SecurityListRequestType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> SecurityListRequestType.Symbol
        |"1"B -> SecurityListRequestType.SecuritytypeAndOrCficode
        |"2"B -> SecurityListRequestType.Product
        |"3"B -> SecurityListRequestType.Tradingsessionid
        |"4"B -> SecurityListRequestType.AllSecurities
        | x -> failwith (sprintf "ReadSecurityListRequestType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSecurityRequestResult (pos:int) (bs:byte[]) : (int * SecurityRequestResult) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> SecurityRequestResult.ValidRequest
        |"1"B -> SecurityRequestResult.InvalidOrUnsupportedRequest
        |"2"B -> SecurityRequestResult.NoInstrumentsFoundThatMatchSelectionCriteria
        |"3"B -> SecurityRequestResult.NotAuthorizedToRetrieveInstrumentData
        |"4"B -> SecurityRequestResult.InstrumentDataTemporarilyUnavailable
        |"5"B -> SecurityRequestResult.RequestForInstrumentDataNotSupported
        | x -> failwith (sprintf "ReadSecurityRequestResult unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadRoundLot (pos:int) (bs:byte[]) : (int*RoundLot) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) RoundLot.RoundLot


let ReadMinTradeVol (pos:int) (bs:byte[]) : (int*MinTradeVol) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) MinTradeVol.MinTradeVol


let ReadMultiLegRptTypeReq (pos:int) (bs:byte[]) : (int * MultiLegRptTypeReq) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> MultiLegRptTypeReq.ReportByMulitlegSecurityOnly
        |"1"B -> MultiLegRptTypeReq.ReportByMultilegSecurityAndByInstrumentLegsBelongingToTheMultilegSecurity
        |"2"B -> MultiLegRptTypeReq.ReportByInstrumentLegsBelongingToTheMultilegSecurityOnly
        | x -> failwith (sprintf "ReadMultiLegRptTypeReq unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadLegPositionEffect (pos:int) (bs:byte[]) : (int*LegPositionEffect) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LegPositionEffect.LegPositionEffect


let ReadLegCoveredOrUncovered (pos:int) (bs:byte[]) : (int*LegCoveredOrUncovered) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LegCoveredOrUncovered.LegCoveredOrUncovered


let ReadLegPrice (pos:int) (bs:byte[]) : (int*LegPrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegPrice.LegPrice


let ReadTradSesStatusRejReason (pos:int) (bs:byte[]) : (int * TradSesStatusRejReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> TradSesStatusRejReason.UnknownOrInvalidTradingsessionid
        | x -> failwith (sprintf "ReadTradSesStatusRejReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTradeRequestID (pos:int) (bs:byte[]) : (int*TradeRequestID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradeRequestID.TradeRequestID


let ReadTradeRequestType (pos:int) (bs:byte[]) : (int * TradeRequestType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> TradeRequestType.AllTrades
        |"1"B -> TradeRequestType.MatchedTradesMatchingCriteriaProvidedOnRequest
        |"2"B -> TradeRequestType.UnmatchedTradesThatMatchCriteria
        |"3"B -> TradeRequestType.UnreportedTradesThatMatchCriteria
        |"4"B -> TradeRequestType.AdvisoriesThatMatchCriteria
        | x -> failwith (sprintf "ReadTradeRequestType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPreviouslyReported (pos:int) (bs:byte[]) : (int*PreviouslyReported) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) PreviouslyReported.PreviouslyReported


let ReadTradeReportID (pos:int) (bs:byte[]) : (int*TradeReportID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradeReportID.TradeReportID


let ReadTradeReportRefID (pos:int) (bs:byte[]) : (int*TradeReportRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradeReportRefID.TradeReportRefID


let ReadMatchStatus (pos:int) (bs:byte[]) : (int * MatchStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> MatchStatus.ComparedMatchedOrAffirmed
        |"1"B -> MatchStatus.UncomparedUnmatchedOrUnaffirmed
        |"2"B -> MatchStatus.AdvisoryOrAlert
        | x -> failwith (sprintf "ReadMatchStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadMatchType (pos:int) (bs:byte[]) : (int*MatchType) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MatchType.MatchType


let ReadOddLot (pos:int) (bs:byte[]) : (int*OddLot) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) OddLot.OddLot


let ReadNoClearingInstructions (pos:int) (bs:byte[]) : (int*NoClearingInstructions) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoClearingInstructions.NoClearingInstructions


let ReadClearingInstruction (pos:int) (bs:byte[]) : (int * ClearingInstruction) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> ClearingInstruction.ProcessNormally
        |"1"B -> ClearingInstruction.ExcludeFromAllNetting
        |"2"B -> ClearingInstruction.BilateralNettingOnly
        |"3"B -> ClearingInstruction.ExClearing
        |"4"B -> ClearingInstruction.SpecialTrade
        |"5"B -> ClearingInstruction.MultilateralNetting
        |"6"B -> ClearingInstruction.ClearAgainstCentralCounterparty
        |"7"B -> ClearingInstruction.ExcludeFromCentralCounterparty
        |"8"B -> ClearingInstruction.ManualMode
        |"9"B -> ClearingInstruction.AutomaticPostingMode
        |"10"B -> ClearingInstruction.AutomaticGiveUpMode
        |"11"B -> ClearingInstruction.QualifiedServiceRepresentative
        |"12"B -> ClearingInstruction.CustomerTrade
        |"13"B -> ClearingInstruction.SelfClearing
        | x -> failwith (sprintf "ReadClearingInstruction unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTradeInputSource (pos:int) (bs:byte[]) : (int*TradeInputSource) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradeInputSource.TradeInputSource


let ReadTradeInputDevice (pos:int) (bs:byte[]) : (int*TradeInputDevice) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradeInputDevice.TradeInputDevice


let ReadNoDates (pos:int) (bs:byte[]) : (int*NoDates) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoDates.NoDates


let ReadAccountType (pos:int) (bs:byte[]) : (int * AccountType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> AccountType.AccountIsCarriedOnCustomerSideOfBooks
        |"2"B -> AccountType.AccountIsCarriedOnNonCustomerSideOfBooks
        |"3"B -> AccountType.HouseTrader
        |"4"B -> AccountType.FloorTrader
        |"6"B -> AccountType.AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined
        |"7"B -> AccountType.AccountIsHouseTraderAndIsCrossMargined
        |"8"B -> AccountType.JointBackofficeAccount
        | x -> failwith (sprintf "ReadAccountType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCustOrderCapacity (pos:int) (bs:byte[]) : (int * CustOrderCapacity) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> CustOrderCapacity.MemberTradingForTheirOwnAccount
        |"2"B -> CustOrderCapacity.ClearingFirmTradingForItsProprietaryAccount
        |"3"B -> CustOrderCapacity.MemberTradingForAnotherMember
        |"4"B -> CustOrderCapacity.AllOther
        | x -> failwith (sprintf "ReadCustOrderCapacity unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadClOrdLinkID (pos:int) (bs:byte[]) : (int*ClOrdLinkID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ClOrdLinkID.ClOrdLinkID


let ReadMassStatusReqID (pos:int) (bs:byte[]) : (int*MassStatusReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) MassStatusReqID.MassStatusReqID


let ReadMassStatusReqType (pos:int) (bs:byte[]) : (int * MassStatusReqType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> MassStatusReqType.StatusForOrdersForASecurity
        |"2"B -> MassStatusReqType.StatusForOrdersForAnUnderlyingSecurity
        |"3"B -> MassStatusReqType.StatusForOrdersForAProduct
        |"4"B -> MassStatusReqType.StatusForOrdersForACficode
        |"5"B -> MassStatusReqType.StatusForOrdersForASecuritytype
        |"6"B -> MassStatusReqType.StatusForOrdersForATradingSession
        |"7"B -> MassStatusReqType.StatusForAllOrders
        |"8"B -> MassStatusReqType.StatusForOrdersForAPartyid
        | x -> failwith (sprintf "ReadMassStatusReqType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadOrigOrdModTime (pos:int) (bs:byte[]) : (int*OrigOrdModTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) OrigOrdModTime.OrigOrdModTime


let ReadLegSettlType (pos:int) (bs:byte[]) : (int*LegSettlType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LegSettlType.LegSettlType


let ReadLegSettlDate (pos:int) (bs:byte[]) : (int*LegSettlDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegSettlDate.LegSettlDate


let ReadDayBookingInst (pos:int) (bs:byte[]) : (int * DayBookingInst) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> DayBookingInst.CanTriggerBookingWithoutReferenceToTheOrderInitiator
        |"1"B -> DayBookingInst.SpeakWithOrderInitiatorBeforeBooking
        |"2"B -> DayBookingInst.Accumulate
        | x -> failwith (sprintf "ReadDayBookingInst unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadBookingUnit (pos:int) (bs:byte[]) : (int * BookingUnit) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> BookingUnit.EachPartialExecutionIsABookableUnit
        |"1"B -> BookingUnit.AggregatePartialExecutionsOnThisOrderAndBookOneTradePerOrder
        |"2"B -> BookingUnit.AggregateExecutionsForThisSymbolSideAndSettlementDate
        | x -> failwith (sprintf "ReadBookingUnit unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPreallocMethod (pos:int) (bs:byte[]) : (int * PreallocMethod) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> PreallocMethod.ProRata
        |"1"B -> PreallocMethod.DoNotProRata
        | x -> failwith (sprintf "ReadPreallocMethod unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadUnderlyingCountryOfIssue (pos:int) (bs:byte[]) : (int*UnderlyingCountryOfIssue) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingCountryOfIssue.UnderlyingCountryOfIssue


let ReadUnderlyingStateOrProvinceOfIssue (pos:int) (bs:byte[]) : (int*UnderlyingStateOrProvinceOfIssue) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingStateOrProvinceOfIssue.UnderlyingStateOrProvinceOfIssue


let ReadUnderlyingLocaleOfIssue (pos:int) (bs:byte[]) : (int*UnderlyingLocaleOfIssue) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingLocaleOfIssue.UnderlyingLocaleOfIssue


let ReadUnderlyingInstrRegistry (pos:int) (bs:byte[]) : (int*UnderlyingInstrRegistry) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingInstrRegistry.UnderlyingInstrRegistry


let ReadLegCountryOfIssue (pos:int) (bs:byte[]) : (int*LegCountryOfIssue) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegCountryOfIssue.LegCountryOfIssue


let ReadLegStateOrProvinceOfIssue (pos:int) (bs:byte[]) : (int*LegStateOrProvinceOfIssue) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegStateOrProvinceOfIssue.LegStateOrProvinceOfIssue


let ReadLegLocaleOfIssue (pos:int) (bs:byte[]) : (int*LegLocaleOfIssue) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegLocaleOfIssue.LegLocaleOfIssue


let ReadLegInstrRegistry (pos:int) (bs:byte[]) : (int*LegInstrRegistry) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegInstrRegistry.LegInstrRegistry


let ReadLegSymbol (pos:int) (bs:byte[]) : (int*LegSymbol) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegSymbol.LegSymbol


let ReadLegSymbolSfx (pos:int) (bs:byte[]) : (int*LegSymbolSfx) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegSymbolSfx.LegSymbolSfx


let ReadLegSecurityID (pos:int) (bs:byte[]) : (int*LegSecurityID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegSecurityID.LegSecurityID


let ReadLegSecurityIDSource (pos:int) (bs:byte[]) : (int*LegSecurityIDSource) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegSecurityIDSource.LegSecurityIDSource


let ReadNoLegSecurityAltID (pos:int) (bs:byte[]) : (int*NoLegSecurityAltID) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoLegSecurityAltID.NoLegSecurityAltID


let ReadLegSecurityAltID (pos:int) (bs:byte[]) : (int*LegSecurityAltID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegSecurityAltID.LegSecurityAltID


let ReadLegSecurityAltIDSource (pos:int) (bs:byte[]) : (int*LegSecurityAltIDSource) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegSecurityAltIDSource.LegSecurityAltIDSource


let ReadLegProduct (pos:int) (bs:byte[]) : (int*LegProduct) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LegProduct.LegProduct


let ReadLegCFICode (pos:int) (bs:byte[]) : (int*LegCFICode) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegCFICode.LegCFICode


let ReadLegSecurityType (pos:int) (bs:byte[]) : (int*LegSecurityType) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegSecurityType.LegSecurityType


let ReadLegMaturityMonthYear (pos:int) (bs:byte[]) : (int*LegMaturityMonthYear) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegMaturityMonthYear.LegMaturityMonthYear


let ReadLegMaturityDate (pos:int) (bs:byte[]) : (int*LegMaturityDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegMaturityDate.LegMaturityDate


let ReadLegStrikePrice (pos:int) (bs:byte[]) : (int*LegStrikePrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegStrikePrice.LegStrikePrice


let ReadLegOptAttribute (pos:int) (bs:byte[]) : (int*LegOptAttribute) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LegOptAttribute.LegOptAttribute


let ReadLegContractMultiplier (pos:int) (bs:byte[]) : (int*LegContractMultiplier) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegContractMultiplier.LegContractMultiplier


let ReadLegCouponRate (pos:int) (bs:byte[]) : (int*LegCouponRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegCouponRate.LegCouponRate


let ReadLegSecurityExchange (pos:int) (bs:byte[]) : (int*LegSecurityExchange) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegSecurityExchange.LegSecurityExchange


let ReadLegIssuer (pos:int) (bs:byte[]) : (int*LegIssuer) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegIssuer.LegIssuer


// compound read
let ReadEncodedLegIssuer (pos:int) (bs:byte[]) : (int * EncodedLegIssuer) =
    ReadLengthDataCompoundField "619"B (pos:int) (bs:byte[]) EncodedLegIssuer.EncodedLegIssuer


let ReadLegSecurityDesc (pos:int) (bs:byte[]) : (int*LegSecurityDesc) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegSecurityDesc.LegSecurityDesc


// compound read
let ReadEncodedLegSecurityDesc (pos:int) (bs:byte[]) : (int * EncodedLegSecurityDesc) =
    ReadLengthDataCompoundField "622"B (pos:int) (bs:byte[]) EncodedLegSecurityDesc.EncodedLegSecurityDesc


let ReadLegRatioQty (pos:int) (bs:byte[]) : (int*LegRatioQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegRatioQty.LegRatioQty


let ReadLegSide (pos:int) (bs:byte[]) : (int*LegSide) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LegSide.LegSide


let ReadTradingSessionSubID (pos:int) (bs:byte[]) : (int*TradingSessionSubID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradingSessionSubID.TradingSessionSubID


let ReadAllocType (pos:int) (bs:byte[]) : (int * AllocType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> AllocType.Calculated
        |"2"B -> AllocType.Preliminary
        |"5"B -> AllocType.ReadyToBookSingleOrder
        |"7"B -> AllocType.WarehouseInstruction
        |"8"B -> AllocType.RequestToIntermediary
        | x -> failwith (sprintf "ReadAllocType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoHops (pos:int) (bs:byte[]) : (int*NoHops) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoHops.NoHops


let ReadHopCompID (pos:int) (bs:byte[]) : (int*HopCompID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) HopCompID.HopCompID


let ReadHopSendingTime (pos:int) (bs:byte[]) : (int*HopSendingTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) HopSendingTime.HopSendingTime


let ReadHopRefID (pos:int) (bs:byte[]) : (int*HopRefID) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) HopRefID.HopRefID


let ReadMidPx (pos:int) (bs:byte[]) : (int*MidPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) MidPx.MidPx


let ReadBidYield (pos:int) (bs:byte[]) : (int*BidYield) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) BidYield.BidYield


let ReadMidYield (pos:int) (bs:byte[]) : (int*MidYield) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) MidYield.MidYield


let ReadOfferYield (pos:int) (bs:byte[]) : (int*OfferYield) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) OfferYield.OfferYield


let ReadClearingFeeIndicator (pos:int) (bs:byte[]) : (int * ClearingFeeIndicator) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"B"B -> ClearingFeeIndicator.CboeMember
        |"C"B -> ClearingFeeIndicator.NonMemberAndCustomer
        |"E"B -> ClearingFeeIndicator.EquityMemberAndClearingMember
        |"F"B -> ClearingFeeIndicator.FullAndAssociateMemberTradingForOwnAccountAndAsFloorBrokers
        |"H"B -> ClearingFeeIndicator.Firms106hAnd106j
        |"I"B -> ClearingFeeIndicator.GimIdemAndComMembershipInterestHolders
        |"L"B -> ClearingFeeIndicator.LesseeAnd106fEmployees
        |"M"B -> ClearingFeeIndicator.AllOtherOwnershipTypes
        | x -> failwith (sprintf "ReadClearingFeeIndicator unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadWorkingIndicator (pos:int) (bs:byte[]) : (int*WorkingIndicator) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) WorkingIndicator.WorkingIndicator


let ReadLegLastPx (pos:int) (bs:byte[]) : (int*LegLastPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegLastPx.LegLastPx


let ReadPriorityIndicator (pos:int) (bs:byte[]) : (int * PriorityIndicator) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> PriorityIndicator.PriorityUnchanged
        |"1"B -> PriorityIndicator.LostPriorityAsResultOfOrderChange
        | x -> failwith (sprintf "ReadPriorityIndicator unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPriceImprovement (pos:int) (bs:byte[]) : (int*PriceImprovement) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) PriceImprovement.PriceImprovement


let ReadPrice2 (pos:int) (bs:byte[]) : (int*Price2) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) Price2.Price2


let ReadLastForwardPoints2 (pos:int) (bs:byte[]) : (int*LastForwardPoints2) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LastForwardPoints2.LastForwardPoints2


let ReadBidForwardPoints2 (pos:int) (bs:byte[]) : (int*BidForwardPoints2) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) BidForwardPoints2.BidForwardPoints2


let ReadOfferForwardPoints2 (pos:int) (bs:byte[]) : (int*OfferForwardPoints2) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) OfferForwardPoints2.OfferForwardPoints2


let ReadRFQReqID (pos:int) (bs:byte[]) : (int*RFQReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) RFQReqID.RFQReqID


let ReadMktBidPx (pos:int) (bs:byte[]) : (int*MktBidPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) MktBidPx.MktBidPx


let ReadMktOfferPx (pos:int) (bs:byte[]) : (int*MktOfferPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) MktOfferPx.MktOfferPx


let ReadMinBidSize (pos:int) (bs:byte[]) : (int*MinBidSize) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) MinBidSize.MinBidSize


let ReadMinOfferSize (pos:int) (bs:byte[]) : (int*MinOfferSize) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) MinOfferSize.MinOfferSize


let ReadQuoteStatusReqID (pos:int) (bs:byte[]) : (int*QuoteStatusReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) QuoteStatusReqID.QuoteStatusReqID


let ReadLegalConfirm (pos:int) (bs:byte[]) : (int*LegalConfirm) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) LegalConfirm.LegalConfirm


let ReadUnderlyingLastPx (pos:int) (bs:byte[]) : (int*UnderlyingLastPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) UnderlyingLastPx.UnderlyingLastPx


let ReadUnderlyingLastQty (pos:int) (bs:byte[]) : (int*UnderlyingLastQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) UnderlyingLastQty.UnderlyingLastQty


let ReadLegRefID (pos:int) (bs:byte[]) : (int*LegRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegRefID.LegRefID


let ReadContraLegRefID (pos:int) (bs:byte[]) : (int*ContraLegRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ContraLegRefID.ContraLegRefID


let ReadSettlCurrBidFxRate (pos:int) (bs:byte[]) : (int*SettlCurrBidFxRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) SettlCurrBidFxRate.SettlCurrBidFxRate


let ReadSettlCurrOfferFxRate (pos:int) (bs:byte[]) : (int*SettlCurrOfferFxRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) SettlCurrOfferFxRate.SettlCurrOfferFxRate


let ReadQuoteRequestRejectReason (pos:int) (bs:byte[]) : (int * QuoteRequestRejectReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> QuoteRequestRejectReason.UnknownSymbol
        |"2"B -> QuoteRequestRejectReason.ExchangeClosed
        |"3"B -> QuoteRequestRejectReason.QuoteRequestExceedsLimit
        |"4"B -> QuoteRequestRejectReason.TooLateToEnter
        |"5"B -> QuoteRequestRejectReason.InvalidPrice
        |"6"B -> QuoteRequestRejectReason.NotAuthorizedToRequestQuote
        |"7"B -> QuoteRequestRejectReason.NoMatchForInquiry
        |"8"B -> QuoteRequestRejectReason.NoMarketForInstrument
        |"9"B -> QuoteRequestRejectReason.NoInventory
        |"10"B -> QuoteRequestRejectReason.Pass
        |"99"B -> QuoteRequestRejectReason.Other
        | x -> failwith (sprintf "ReadQuoteRequestRejectReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSideComplianceID (pos:int) (bs:byte[]) : (int*SideComplianceID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SideComplianceID.SideComplianceID


let ReadAcctIDSource (pos:int) (bs:byte[]) : (int * AcctIDSource) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> AcctIDSource.Bic
        |"2"B -> AcctIDSource.SidCode
        |"3"B -> AcctIDSource.Tfm
        |"4"B -> AcctIDSource.Omgeo
        |"5"B -> AcctIDSource.DtccCode
        |"99"B -> AcctIDSource.Other
        | x -> failwith (sprintf "ReadAcctIDSource unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadAllocAcctIDSource (pos:int) (bs:byte[]) : (int*AllocAcctIDSource) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) AllocAcctIDSource.AllocAcctIDSource


let ReadBenchmarkPrice (pos:int) (bs:byte[]) : (int*BenchmarkPrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) BenchmarkPrice.BenchmarkPrice


let ReadBenchmarkPriceType (pos:int) (bs:byte[]) : (int*BenchmarkPriceType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) BenchmarkPriceType.BenchmarkPriceType


let ReadConfirmID (pos:int) (bs:byte[]) : (int*ConfirmID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ConfirmID.ConfirmID


let ReadConfirmStatus (pos:int) (bs:byte[]) : (int * ConfirmStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> ConfirmStatus.Received
        |"2"B -> ConfirmStatus.MismatchedAccount
        |"3"B -> ConfirmStatus.MissingSettlementInstructions
        |"4"B -> ConfirmStatus.Confirmed
        |"5"B -> ConfirmStatus.RequestRejected
        | x -> failwith (sprintf "ReadConfirmStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadConfirmTransType (pos:int) (bs:byte[]) : (int * ConfirmTransType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> ConfirmTransType.New
        |"1"B -> ConfirmTransType.Replace
        |"2"B -> ConfirmTransType.Cancel
        | x -> failwith (sprintf "ReadConfirmTransType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadContractSettlMonth (pos:int) (bs:byte[]) : (int*ContractSettlMonth) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ContractSettlMonth.ContractSettlMonth


let ReadDeliveryForm (pos:int) (bs:byte[]) : (int * DeliveryForm) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> DeliveryForm.Bookentry
        |"2"B -> DeliveryForm.Bearer
        | x -> failwith (sprintf "ReadDeliveryForm unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadLastParPx (pos:int) (bs:byte[]) : (int*LastParPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LastParPx.LastParPx


let ReadNoLegAllocs (pos:int) (bs:byte[]) : (int*NoLegAllocs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoLegAllocs.NoLegAllocs


let ReadLegAllocAccount (pos:int) (bs:byte[]) : (int*LegAllocAccount) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegAllocAccount.LegAllocAccount


let ReadLegIndividualAllocID (pos:int) (bs:byte[]) : (int*LegIndividualAllocID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegIndividualAllocID.LegIndividualAllocID


let ReadLegAllocQty (pos:int) (bs:byte[]) : (int*LegAllocQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegAllocQty.LegAllocQty


let ReadLegAllocAcctIDSource (pos:int) (bs:byte[]) : (int*LegAllocAcctIDSource) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegAllocAcctIDSource.LegAllocAcctIDSource


let ReadLegSettlCurrency (pos:int) (bs:byte[]) : (int*LegSettlCurrency) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegSettlCurrency.LegSettlCurrency


let ReadLegBenchmarkCurveCurrency (pos:int) (bs:byte[]) : (int*LegBenchmarkCurveCurrency) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegBenchmarkCurveCurrency.LegBenchmarkCurveCurrency


let ReadLegBenchmarkCurveName (pos:int) (bs:byte[]) : (int*LegBenchmarkCurveName) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegBenchmarkCurveName.LegBenchmarkCurveName


let ReadLegBenchmarkCurvePoint (pos:int) (bs:byte[]) : (int*LegBenchmarkCurvePoint) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegBenchmarkCurvePoint.LegBenchmarkCurvePoint


let ReadLegBenchmarkPrice (pos:int) (bs:byte[]) : (int*LegBenchmarkPrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegBenchmarkPrice.LegBenchmarkPrice


let ReadLegBenchmarkPriceType (pos:int) (bs:byte[]) : (int*LegBenchmarkPriceType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LegBenchmarkPriceType.LegBenchmarkPriceType


let ReadLegBidPx (pos:int) (bs:byte[]) : (int*LegBidPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegBidPx.LegBidPx


let ReadLegIOIQty (pos:int) (bs:byte[]) : (int*LegIOIQty) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegIOIQty.LegIOIQty


let ReadNoLegStipulations (pos:int) (bs:byte[]) : (int*NoLegStipulations) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoLegStipulations.NoLegStipulations


let ReadLegOfferPx (pos:int) (bs:byte[]) : (int*LegOfferPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegOfferPx.LegOfferPx


let ReadLegOrderQty (pos:int) (bs:byte[]) : (int*LegOrderQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegOrderQty.LegOrderQty


let ReadLegPriceType (pos:int) (bs:byte[]) : (int*LegPriceType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) LegPriceType.LegPriceType


let ReadLegQty (pos:int) (bs:byte[]) : (int*LegQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LegQty.LegQty


let ReadLegStipulationType (pos:int) (bs:byte[]) : (int*LegStipulationType) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegStipulationType.LegStipulationType


let ReadLegStipulationValue (pos:int) (bs:byte[]) : (int*LegStipulationValue) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegStipulationValue.LegStipulationValue


let ReadLegSwapType (pos:int) (bs:byte[]) : (int * LegSwapType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> LegSwapType.ParForPar
        |"2"B -> LegSwapType.ModifiedDuration
        |"4"B -> LegSwapType.Risk
        |"5"B -> LegSwapType.Proceeds
        | x -> failwith (sprintf "ReadLegSwapType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPool (pos:int) (bs:byte[]) : (int*Pool) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Pool.Pool


let ReadQuotePriceType (pos:int) (bs:byte[]) : (int * QuotePriceType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> QuotePriceType.Percent
        |"2"B -> QuotePriceType.PerShare
        |"3"B -> QuotePriceType.FixedAmount
        |"4"B -> QuotePriceType.Discount
        |"5"B -> QuotePriceType.Premium
        |"6"B -> QuotePriceType.BasisPointsRelativeToBenchmark
        |"7"B -> QuotePriceType.TedPrice
        |"8"B -> QuotePriceType.TedYield
        |"9"B -> QuotePriceType.YieldSpread
        |"10"B -> QuotePriceType.Yield
        | x -> failwith (sprintf "ReadQuotePriceType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadQuoteRespID (pos:int) (bs:byte[]) : (int*QuoteRespID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) QuoteRespID.QuoteRespID


let ReadQuoteRespType (pos:int) (bs:byte[]) : (int * QuoteRespType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> QuoteRespType.HitLift
        |"2"B -> QuoteRespType.Counter
        |"3"B -> QuoteRespType.Expired
        |"4"B -> QuoteRespType.Cover
        |"5"B -> QuoteRespType.DoneAway
        |"6"B -> QuoteRespType.Pass
        | x -> failwith (sprintf "ReadQuoteRespType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadQuoteQualifier (pos:int) (bs:byte[]) : (int*QuoteQualifier) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) QuoteQualifier.QuoteQualifier


let ReadYieldRedemptionDate (pos:int) (bs:byte[]) : (int*YieldRedemptionDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) YieldRedemptionDate.YieldRedemptionDate


let ReadYieldRedemptionPrice (pos:int) (bs:byte[]) : (int*YieldRedemptionPrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) YieldRedemptionPrice.YieldRedemptionPrice


let ReadYieldRedemptionPriceType (pos:int) (bs:byte[]) : (int*YieldRedemptionPriceType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) YieldRedemptionPriceType.YieldRedemptionPriceType


let ReadBenchmarkSecurityID (pos:int) (bs:byte[]) : (int*BenchmarkSecurityID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) BenchmarkSecurityID.BenchmarkSecurityID


let ReadReversalIndicator (pos:int) (bs:byte[]) : (int*ReversalIndicator) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) ReversalIndicator.ReversalIndicator


let ReadYieldCalcDate (pos:int) (bs:byte[]) : (int*YieldCalcDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) YieldCalcDate.YieldCalcDate


let ReadNoPositions (pos:int) (bs:byte[]) : (int*NoPositions) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoPositions.NoPositions


let ReadPosType (pos:int) (bs:byte[]) : (int * PosType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"TQ"B -> PosType.TransactionQuantity
        |"IAS"B -> PosType.IntraSpreadQty
        |"IES"B -> PosType.InterSpreadQty
        |"FIN"B -> PosType.EndOfDayQty
        |"SOD"B -> PosType.StartOfDayQty
        |"EX"B -> PosType.OptionExerciseQty
        |"AS"B -> PosType.OptionAssignment
        |"TX"B -> PosType.TransactionFromExercise
        |"TA"B -> PosType.TransactionFromAssignment
        |"PIT"B -> PosType.PitTradeQty
        |"TRF"B -> PosType.TransferTradeQty
        |"ETR"B -> PosType.ElectronicTradeQty
        |"ALC"B -> PosType.AllocationTradeQty
        |"PA"B -> PosType.AdjustmentQty
        |"ASF"B -> PosType.AsOfTradeQty
        |"DLV"B -> PosType.DeliveryQty
        |"TOT"B -> PosType.TotalTransactionQty
        |"XM"B -> PosType.CrossMarginQty
        |"SPL"B -> PosType.IntegralSplit
        | x -> failwith (sprintf "ReadPosType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadLongQty (pos:int) (bs:byte[]) : (int*LongQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) LongQty.LongQty


let ReadShortQty (pos:int) (bs:byte[]) : (int*ShortQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) ShortQty.ShortQty


let ReadPosQtyStatus (pos:int) (bs:byte[]) : (int * PosQtyStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> PosQtyStatus.Submitted
        |"1"B -> PosQtyStatus.Accepted
        |"2"B -> PosQtyStatus.Rejected
        | x -> failwith (sprintf "ReadPosQtyStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPosAmtType (pos:int) (bs:byte[]) : (int * PosAmtType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"FMTM"B -> PosAmtType.FinalMarkToMarketAmount
        |"IMTM"B -> PosAmtType.IncrementalMarkToMarketAmount
        |"TVAR"B -> PosAmtType.TradeVariationAmount
        |"SMTM"B -> PosAmtType.StartOfDayMarkToMarketAmount
        |"PREM"B -> PosAmtType.PremiumAmount
        |"CRES"B -> PosAmtType.CashResidualAmount
        |"CASH"B -> PosAmtType.CashAmount
        |"VADJ"B -> PosAmtType.ValueAdjustedAmount
        | x -> failwith (sprintf "ReadPosAmtType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPosAmt (pos:int) (bs:byte[]) : (int*PosAmt) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) PosAmt.PosAmt


let ReadPosTransType (pos:int) (bs:byte[]) : (int * PosTransType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> PosTransType.Exercise
        |"2"B -> PosTransType.DoNotExercise
        |"3"B -> PosTransType.PositionAdjustment
        |"4"B -> PosTransType.PositionChangeSubmissionMarginDisposition
        |"5"B -> PosTransType.Pledge
        | x -> failwith (sprintf "ReadPosTransType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPosReqID (pos:int) (bs:byte[]) : (int*PosReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) PosReqID.PosReqID


let ReadNoUnderlyings (pos:int) (bs:byte[]) : (int*NoUnderlyings) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoUnderlyings.NoUnderlyings


let ReadPosMaintAction (pos:int) (bs:byte[]) : (int * PosMaintAction) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> PosMaintAction.New
        |"2"B -> PosMaintAction.Replace
        |"3"B -> PosMaintAction.Cancel
        | x -> failwith (sprintf "ReadPosMaintAction unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadOrigPosReqRefID (pos:int) (bs:byte[]) : (int*OrigPosReqRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) OrigPosReqRefID.OrigPosReqRefID


let ReadPosMaintRptRefID (pos:int) (bs:byte[]) : (int*PosMaintRptRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) PosMaintRptRefID.PosMaintRptRefID


let ReadClearingBusinessDate (pos:int) (bs:byte[]) : (int*ClearingBusinessDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ClearingBusinessDate.ClearingBusinessDate


let ReadSettlSessID (pos:int) (bs:byte[]) : (int*SettlSessID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SettlSessID.SettlSessID


let ReadSettlSessSubID (pos:int) (bs:byte[]) : (int*SettlSessSubID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SettlSessSubID.SettlSessSubID


let ReadAdjustmentType (pos:int) (bs:byte[]) : (int * AdjustmentType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> AdjustmentType.ProcessRequestAsMarginDisposition
        |"1"B -> AdjustmentType.DeltaPlus
        |"2"B -> AdjustmentType.DeltaMinus
        |"3"B -> AdjustmentType.Final
        | x -> failwith (sprintf "ReadAdjustmentType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadContraryInstructionIndicator (pos:int) (bs:byte[]) : (int*ContraryInstructionIndicator) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) ContraryInstructionIndicator.ContraryInstructionIndicator


let ReadPriorSpreadIndicator (pos:int) (bs:byte[]) : (int*PriorSpreadIndicator) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) PriorSpreadIndicator.PriorSpreadIndicator


let ReadPosMaintRptID (pos:int) (bs:byte[]) : (int*PosMaintRptID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) PosMaintRptID.PosMaintRptID


let ReadPosMaintStatus (pos:int) (bs:byte[]) : (int * PosMaintStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> PosMaintStatus.Accepted
        |"1"B -> PosMaintStatus.AcceptedWithWarnings
        |"2"B -> PosMaintStatus.Rejected
        |"3"B -> PosMaintStatus.Completed
        |"4"B -> PosMaintStatus.CompletedWithWarnings
        | x -> failwith (sprintf "ReadPosMaintStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPosMaintResult (pos:int) (bs:byte[]) : (int * PosMaintResult) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> PosMaintResult.SuccessfulCompletionNoWarningsOrErrors
        |"1"B -> PosMaintResult.Rejected
        |"99"B -> PosMaintResult.Other
        | x -> failwith (sprintf "ReadPosMaintResult unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPosReqType (pos:int) (bs:byte[]) : (int * PosReqType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> PosReqType.Positions
        |"1"B -> PosReqType.Trades
        |"2"B -> PosReqType.Exercises
        |"3"B -> PosReqType.Assignments
        | x -> failwith (sprintf "ReadPosReqType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadResponseTransportType (pos:int) (bs:byte[]) : (int * ResponseTransportType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> ResponseTransportType.Inband
        |"1"B -> ResponseTransportType.OutOfBand
        | x -> failwith (sprintf "ReadResponseTransportType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadResponseDestination (pos:int) (bs:byte[]) : (int*ResponseDestination) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ResponseDestination.ResponseDestination


let ReadTotalNumPosReports (pos:int) (bs:byte[]) : (int*TotalNumPosReports) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotalNumPosReports.TotalNumPosReports


let ReadPosReqResult (pos:int) (bs:byte[]) : (int * PosReqResult) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> PosReqResult.ValidRequest
        |"1"B -> PosReqResult.InvalidOrUnsupportedRequest
        |"2"B -> PosReqResult.NoPositionsFoundThatMatchCriteria
        |"3"B -> PosReqResult.NotAuthorizedToRequestPositions
        |"4"B -> PosReqResult.RequestForPositionNotSupported
        |"99"B -> PosReqResult.Other
        | x -> failwith (sprintf "ReadPosReqResult unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPosReqStatus (pos:int) (bs:byte[]) : (int * PosReqStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> PosReqStatus.Completed
        |"1"B -> PosReqStatus.CompletedWithWarnings
        |"2"B -> PosReqStatus.Rejected
        | x -> failwith (sprintf "ReadPosReqStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSettlPrice (pos:int) (bs:byte[]) : (int*SettlPrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) SettlPrice.SettlPrice


let ReadSettlPriceType (pos:int) (bs:byte[]) : (int * SettlPriceType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> SettlPriceType.Final
        |"2"B -> SettlPriceType.Theoretical
        | x -> failwith (sprintf "ReadSettlPriceType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadUnderlyingSettlPrice (pos:int) (bs:byte[]) : (int*UnderlyingSettlPrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) UnderlyingSettlPrice.UnderlyingSettlPrice


let ReadUnderlyingSettlPriceType (pos:int) (bs:byte[]) : (int*UnderlyingSettlPriceType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) UnderlyingSettlPriceType.UnderlyingSettlPriceType


let ReadPriorSettlPrice (pos:int) (bs:byte[]) : (int*PriorSettlPrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) PriorSettlPrice.PriorSettlPrice


let ReadNoQuoteQualifiers (pos:int) (bs:byte[]) : (int*NoQuoteQualifiers) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoQuoteQualifiers.NoQuoteQualifiers


let ReadAllocSettlCurrency (pos:int) (bs:byte[]) : (int*AllocSettlCurrency) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AllocSettlCurrency.AllocSettlCurrency


let ReadAllocSettlCurrAmt (pos:int) (bs:byte[]) : (int*AllocSettlCurrAmt) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) AllocSettlCurrAmt.AllocSettlCurrAmt


let ReadInterestAtMaturity (pos:int) (bs:byte[]) : (int*InterestAtMaturity) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) InterestAtMaturity.InterestAtMaturity


let ReadLegDatedDate (pos:int) (bs:byte[]) : (int*LegDatedDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegDatedDate.LegDatedDate


let ReadLegPool (pos:int) (bs:byte[]) : (int*LegPool) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegPool.LegPool


let ReadAllocInterestAtMaturity (pos:int) (bs:byte[]) : (int*AllocInterestAtMaturity) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) AllocInterestAtMaturity.AllocInterestAtMaturity


let ReadAllocAccruedInterestAmt (pos:int) (bs:byte[]) : (int*AllocAccruedInterestAmt) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) AllocAccruedInterestAmt.AllocAccruedInterestAmt


let ReadDeliveryDate (pos:int) (bs:byte[]) : (int*DeliveryDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) DeliveryDate.DeliveryDate


let ReadAssignmentMethod (pos:int) (bs:byte[]) : (int * AssignmentMethod) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"R"B -> AssignmentMethod.Random
        |"P"B -> AssignmentMethod.Prorata
        | x -> failwith (sprintf "ReadAssignmentMethod unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadAssignmentUnit (pos:int) (bs:byte[]) : (int*AssignmentUnit) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) AssignmentUnit.AssignmentUnit


let ReadOpenInterest (pos:int) (bs:byte[]) : (int*OpenInterest) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) OpenInterest.OpenInterest


let ReadExerciseMethod (pos:int) (bs:byte[]) : (int * ExerciseMethod) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"A"B -> ExerciseMethod.Automatic
        |"M"B -> ExerciseMethod.Manual
        | x -> failwith (sprintf "ReadExerciseMethod unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTotNumTradeReports (pos:int) (bs:byte[]) : (int*TotNumTradeReports) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotNumTradeReports.TotNumTradeReports


let ReadTradeRequestResult (pos:int) (bs:byte[]) : (int * TradeRequestResult) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> TradeRequestResult.Successful
        |"1"B -> TradeRequestResult.InvalidOrUnknownInstrument
        |"2"B -> TradeRequestResult.InvalidTypeOfTradeRequested
        |"3"B -> TradeRequestResult.InvalidParties
        |"4"B -> TradeRequestResult.InvalidTransportTypeRequested
        |"5"B -> TradeRequestResult.InvalidDestinationRequested
        |"8"B -> TradeRequestResult.TraderequesttypeNotSupported
        |"9"B -> TradeRequestResult.UnauthorizedForTradeCaptureReportRequest
        |"10"B -> TradeRequestResult.Yield
        | x -> failwith (sprintf "ReadTradeRequestResult unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTradeRequestStatus (pos:int) (bs:byte[]) : (int * TradeRequestStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> TradeRequestStatus.Accepted
        |"1"B -> TradeRequestStatus.Completed
        |"2"B -> TradeRequestStatus.Rejected
        | x -> failwith (sprintf "ReadTradeRequestStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTradeReportRejectReason (pos:int) (bs:byte[]) : (int * TradeReportRejectReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> TradeReportRejectReason.Successful
        |"1"B -> TradeReportRejectReason.InvalidPartyInformation
        |"2"B -> TradeReportRejectReason.UnknownInstrument
        |"3"B -> TradeReportRejectReason.UnauthorizedToReportTrades
        |"4"B -> TradeReportRejectReason.InvalidTradeType
        |"10"B -> TradeReportRejectReason.Yield
        | x -> failwith (sprintf "ReadTradeReportRejectReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSideMultiLegReportingType (pos:int) (bs:byte[]) : (int * SideMultiLegReportingType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> SideMultiLegReportingType.SingleSecurity
        |"2"B -> SideMultiLegReportingType.IndividualLegOfAMultiLegSecurity
        |"3"B -> SideMultiLegReportingType.MultiLegSecurity
        | x -> failwith (sprintf "ReadSideMultiLegReportingType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoPosAmt (pos:int) (bs:byte[]) : (int*NoPosAmt) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoPosAmt.NoPosAmt


let ReadAutoAcceptIndicator (pos:int) (bs:byte[]) : (int*AutoAcceptIndicator) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) AutoAcceptIndicator.AutoAcceptIndicator


let ReadAllocReportID (pos:int) (bs:byte[]) : (int*AllocReportID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AllocReportID.AllocReportID


let ReadNoNested2PartyIDs (pos:int) (bs:byte[]) : (int*NoNested2PartyIDs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoNested2PartyIDs.NoNested2PartyIDs


let ReadNested2PartyID (pos:int) (bs:byte[]) : (int*Nested2PartyID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Nested2PartyID.Nested2PartyID


let ReadNested2PartyIDSource (pos:int) (bs:byte[]) : (int*Nested2PartyIDSource) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) Nested2PartyIDSource.Nested2PartyIDSource


let ReadNested2PartyRole (pos:int) (bs:byte[]) : (int*Nested2PartyRole) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) Nested2PartyRole.Nested2PartyRole


let ReadNested2PartySubID (pos:int) (bs:byte[]) : (int*Nested2PartySubID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Nested2PartySubID.Nested2PartySubID


let ReadBenchmarkSecurityIDSource (pos:int) (bs:byte[]) : (int*BenchmarkSecurityIDSource) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) BenchmarkSecurityIDSource.BenchmarkSecurityIDSource


let ReadSecuritySubType (pos:int) (bs:byte[]) : (int*SecuritySubType) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecuritySubType.SecuritySubType


let ReadUnderlyingSecuritySubType (pos:int) (bs:byte[]) : (int*UnderlyingSecuritySubType) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingSecuritySubType.UnderlyingSecuritySubType


let ReadLegSecuritySubType (pos:int) (bs:byte[]) : (int*LegSecuritySubType) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegSecuritySubType.LegSecuritySubType


let ReadAllowableOneSidednessPct (pos:int) (bs:byte[]) : (int*AllowableOneSidednessPct) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) AllowableOneSidednessPct.AllowableOneSidednessPct


let ReadAllowableOneSidednessValue (pos:int) (bs:byte[]) : (int*AllowableOneSidednessValue) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) AllowableOneSidednessValue.AllowableOneSidednessValue


let ReadAllowableOneSidednessCurr (pos:int) (bs:byte[]) : (int*AllowableOneSidednessCurr) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AllowableOneSidednessCurr.AllowableOneSidednessCurr


let ReadNoTrdRegTimestamps (pos:int) (bs:byte[]) : (int*NoTrdRegTimestamps) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoTrdRegTimestamps.NoTrdRegTimestamps


let ReadTrdRegTimestamp (pos:int) (bs:byte[]) : (int*TrdRegTimestamp) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TrdRegTimestamp.TrdRegTimestamp


let ReadTrdRegTimestampType (pos:int) (bs:byte[]) : (int * TrdRegTimestampType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> TrdRegTimestampType.ExecutionTime
        |"2"B -> TrdRegTimestampType.TimeIn
        |"3"B -> TrdRegTimestampType.TimeOut
        |"4"B -> TrdRegTimestampType.BrokerReceipt
        |"5"B -> TrdRegTimestampType.BrokerExecution
        | x -> failwith (sprintf "ReadTrdRegTimestampType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTrdRegTimestampOrigin (pos:int) (bs:byte[]) : (int*TrdRegTimestampOrigin) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TrdRegTimestampOrigin.TrdRegTimestampOrigin


let ReadConfirmRefID (pos:int) (bs:byte[]) : (int*ConfirmRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ConfirmRefID.ConfirmRefID


let ReadConfirmType (pos:int) (bs:byte[]) : (int * ConfirmType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> ConfirmType.Status
        |"2"B -> ConfirmType.Confirmation
        |"3"B -> ConfirmType.ConfirmationRequestRejected
        | x -> failwith (sprintf "ReadConfirmType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadConfirmRejReason (pos:int) (bs:byte[]) : (int * ConfirmRejReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> ConfirmRejReason.MismatchedAccount
        |"2"B -> ConfirmRejReason.MissingSettlementInstructions
        |"99"B -> ConfirmRejReason.Other
        | x -> failwith (sprintf "ReadConfirmRejReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadBookingType (pos:int) (bs:byte[]) : (int * BookingType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> BookingType.RegularBooking
        |"1"B -> BookingType.Cfd
        |"2"B -> BookingType.TotalReturnSwap
        | x -> failwith (sprintf "ReadBookingType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadIndividualAllocRejCode (pos:int) (bs:byte[]) : (int*IndividualAllocRejCode) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) IndividualAllocRejCode.IndividualAllocRejCode


let ReadSettlInstMsgID (pos:int) (bs:byte[]) : (int*SettlInstMsgID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SettlInstMsgID.SettlInstMsgID


let ReadNoSettlInst (pos:int) (bs:byte[]) : (int*NoSettlInst) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoSettlInst.NoSettlInst


let ReadLastUpdateTime (pos:int) (bs:byte[]) : (int*LastUpdateTime) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LastUpdateTime.LastUpdateTime


let ReadAllocSettlInstType (pos:int) (bs:byte[]) : (int * AllocSettlInstType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> AllocSettlInstType.UseDefaultInstructions
        |"1"B -> AllocSettlInstType.DeriveFromParametersProvided
        |"2"B -> AllocSettlInstType.FullDetailsProvided
        |"3"B -> AllocSettlInstType.SsiDbIdsProvided
        |"4"B -> AllocSettlInstType.PhoneForInstructions
        | x -> failwith (sprintf "ReadAllocSettlInstType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoSettlPartyIDs (pos:int) (bs:byte[]) : (int*NoSettlPartyIDs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoSettlPartyIDs.NoSettlPartyIDs


let ReadSettlPartyID (pos:int) (bs:byte[]) : (int*SettlPartyID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SettlPartyID.SettlPartyID


let ReadSettlPartyIDSource (pos:int) (bs:byte[]) : (int*SettlPartyIDSource) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) SettlPartyIDSource.SettlPartyIDSource


let ReadSettlPartyRole (pos:int) (bs:byte[]) : (int*SettlPartyRole) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) SettlPartyRole.SettlPartyRole


let ReadSettlPartySubID (pos:int) (bs:byte[]) : (int*SettlPartySubID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SettlPartySubID.SettlPartySubID


let ReadSettlPartySubIDType (pos:int) (bs:byte[]) : (int*SettlPartySubIDType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) SettlPartySubIDType.SettlPartySubIDType


let ReadDlvyInstType (pos:int) (bs:byte[]) : (int * DlvyInstType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"S"B -> DlvyInstType.Securities
        |"C"B -> DlvyInstType.Cash
        | x -> failwith (sprintf "ReadDlvyInstType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTerminationType (pos:int) (bs:byte[]) : (int * TerminationType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> TerminationType.Overnight
        |"2"B -> TerminationType.Term
        |"3"B -> TerminationType.Flexible
        |"4"B -> TerminationType.Open
        | x -> failwith (sprintf "ReadTerminationType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNextExpectedMsgSeqNum (pos:int) (bs:byte[]) : (int*NextExpectedMsgSeqNum) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NextExpectedMsgSeqNum.NextExpectedMsgSeqNum


let ReadOrdStatusReqID (pos:int) (bs:byte[]) : (int*OrdStatusReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) OrdStatusReqID.OrdStatusReqID


let ReadSettlInstReqID (pos:int) (bs:byte[]) : (int*SettlInstReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SettlInstReqID.SettlInstReqID


let ReadSettlInstReqRejCode (pos:int) (bs:byte[]) : (int * SettlInstReqRejCode) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> SettlInstReqRejCode.UnableToProcessRequest
        |"1"B -> SettlInstReqRejCode.UnknownAccount
        |"2"B -> SettlInstReqRejCode.NoMatchingSettlementInstructionsFound
        |"99"B -> SettlInstReqRejCode.Other
        | x -> failwith (sprintf "ReadSettlInstReqRejCode unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSecondaryAllocID (pos:int) (bs:byte[]) : (int*SecondaryAllocID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecondaryAllocID.SecondaryAllocID


let ReadAllocReportType (pos:int) (bs:byte[]) : (int * AllocReportType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"3"B -> AllocReportType.SellsideCalculatedUsingPreliminary
        |"4"B -> AllocReportType.SellsideCalculatedWithoutPreliminary
        |"5"B -> AllocReportType.WarehouseRecap
        |"8"B -> AllocReportType.RequestToIntermediary
        | x -> failwith (sprintf "ReadAllocReportType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadAllocReportRefID (pos:int) (bs:byte[]) : (int*AllocReportRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AllocReportRefID.AllocReportRefID


let ReadAllocCancReplaceReason (pos:int) (bs:byte[]) : (int * AllocCancReplaceReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> AllocCancReplaceReason.OriginalDetailsIncompleteIncorrect
        |"2"B -> AllocCancReplaceReason.ChangeInUnderlyingOrderDetails
        | x -> failwith (sprintf "ReadAllocCancReplaceReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCopyMsgIndicator (pos:int) (bs:byte[]) : (int*CopyMsgIndicator) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) CopyMsgIndicator.CopyMsgIndicator


let ReadAllocAccountType (pos:int) (bs:byte[]) : (int * AllocAccountType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> AllocAccountType.AccountIsCarriedOnCustomerSideOfBooks
        |"2"B -> AllocAccountType.AccountIsCarriedOnNonCustomerSideOfBooks
        |"3"B -> AllocAccountType.HouseTrader
        |"4"B -> AllocAccountType.FloorTrader
        |"6"B -> AllocAccountType.AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined
        |"7"B -> AllocAccountType.AccountIsHouseTraderAndIsCrossMargined
        |"8"B -> AllocAccountType.JointBackofficeAccount
        | x -> failwith (sprintf "ReadAllocAccountType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadOrderAvgPx (pos:int) (bs:byte[]) : (int*OrderAvgPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) OrderAvgPx.OrderAvgPx


let ReadOrderBookingQty (pos:int) (bs:byte[]) : (int*OrderBookingQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) OrderBookingQty.OrderBookingQty


let ReadNoSettlPartySubIDs (pos:int) (bs:byte[]) : (int*NoSettlPartySubIDs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoSettlPartySubIDs.NoSettlPartySubIDs


let ReadNoPartySubIDs (pos:int) (bs:byte[]) : (int*NoPartySubIDs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoPartySubIDs.NoPartySubIDs


let ReadPartySubIDType (pos:int) (bs:byte[]) : (int*PartySubIDType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) PartySubIDType.PartySubIDType


let ReadNoNestedPartySubIDs (pos:int) (bs:byte[]) : (int*NoNestedPartySubIDs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoNestedPartySubIDs.NoNestedPartySubIDs


let ReadNestedPartySubIDType (pos:int) (bs:byte[]) : (int*NestedPartySubIDType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NestedPartySubIDType.NestedPartySubIDType


let ReadNoNested2PartySubIDs (pos:int) (bs:byte[]) : (int*NoNested2PartySubIDs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoNested2PartySubIDs.NoNested2PartySubIDs


let ReadNested2PartySubIDType (pos:int) (bs:byte[]) : (int*Nested2PartySubIDType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) Nested2PartySubIDType.Nested2PartySubIDType


let ReadAllocIntermedReqType (pos:int) (bs:byte[]) : (int * AllocIntermedReqType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> AllocIntermedReqType.PendingAccept
        |"2"B -> AllocIntermedReqType.PendingRelease
        |"3"B -> AllocIntermedReqType.PendingReversal
        |"4"B -> AllocIntermedReqType.Accept
        |"5"B -> AllocIntermedReqType.BlockLevelReject
        |"6"B -> AllocIntermedReqType.AccountLevelReject
        | x -> failwith (sprintf "ReadAllocIntermedReqType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadUnderlyingPx (pos:int) (bs:byte[]) : (int*UnderlyingPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) UnderlyingPx.UnderlyingPx


let ReadPriceDelta (pos:int) (bs:byte[]) : (int*PriceDelta) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) PriceDelta.PriceDelta


let ReadApplQueueMax (pos:int) (bs:byte[]) : (int*ApplQueueMax) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) ApplQueueMax.ApplQueueMax


let ReadApplQueueDepth (pos:int) (bs:byte[]) : (int*ApplQueueDepth) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) ApplQueueDepth.ApplQueueDepth


let ReadApplQueueResolution (pos:int) (bs:byte[]) : (int * ApplQueueResolution) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> ApplQueueResolution.NoActionTaken
        |"1"B -> ApplQueueResolution.QueueFlushed
        |"2"B -> ApplQueueResolution.OverlayLast
        |"3"B -> ApplQueueResolution.EndSession
        | x -> failwith (sprintf "ReadApplQueueResolution unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadApplQueueAction (pos:int) (bs:byte[]) : (int * ApplQueueAction) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> ApplQueueAction.NoActionTaken
        |"1"B -> ApplQueueAction.QueueFlushed
        |"2"B -> ApplQueueAction.OverlayLast
        |"3"B -> ApplQueueAction.EndSession
        | x -> failwith (sprintf "ReadApplQueueAction unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoAltMDSource (pos:int) (bs:byte[]) : (int*NoAltMDSource) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoAltMDSource.NoAltMDSource


let ReadAltMDSourceID (pos:int) (bs:byte[]) : (int*AltMDSourceID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AltMDSourceID.AltMDSourceID


let ReadSecondaryTradeReportID (pos:int) (bs:byte[]) : (int*SecondaryTradeReportID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecondaryTradeReportID.SecondaryTradeReportID


let ReadAvgPxIndicator (pos:int) (bs:byte[]) : (int * AvgPxIndicator) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> AvgPxIndicator.NoAveragePricing
        |"1"B -> AvgPxIndicator.TradeIsPartOfAnAveragePriceGroupIdentifiedByTheTradelinkid
        |"2"B -> AvgPxIndicator.LastTradeInTheAveragePriceGroupIdentifiedByTheTradelinkid
        | x -> failwith (sprintf "ReadAvgPxIndicator unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTradeLinkID (pos:int) (bs:byte[]) : (int*TradeLinkID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradeLinkID.TradeLinkID


let ReadOrderInputDevice (pos:int) (bs:byte[]) : (int*OrderInputDevice) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) OrderInputDevice.OrderInputDevice


let ReadUnderlyingTradingSessionID (pos:int) (bs:byte[]) : (int*UnderlyingTradingSessionID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingTradingSessionID.UnderlyingTradingSessionID


let ReadUnderlyingTradingSessionSubID (pos:int) (bs:byte[]) : (int*UnderlyingTradingSessionSubID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingTradingSessionSubID.UnderlyingTradingSessionSubID


let ReadTradeLegRefID (pos:int) (bs:byte[]) : (int*TradeLegRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TradeLegRefID.TradeLegRefID


let ReadExchangeRule (pos:int) (bs:byte[]) : (int*ExchangeRule) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ExchangeRule.ExchangeRule


let ReadTradeAllocIndicator (pos:int) (bs:byte[]) : (int * TradeAllocIndicator) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> TradeAllocIndicator.AllocationNotRequired
        |"1"B -> TradeAllocIndicator.AllocationRequired
        |"2"B -> TradeAllocIndicator.UseAllocationProvidedWithTheTrade
        | x -> failwith (sprintf "ReadTradeAllocIndicator unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadExpirationCycle (pos:int) (bs:byte[]) : (int * ExpirationCycle) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> ExpirationCycle.ExpireOnTradingSessionClose
        |"1"B -> ExpirationCycle.ExpireOnTradingSessionOpen
        | x -> failwith (sprintf "ReadExpirationCycle unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTrdType (pos:int) (bs:byte[]) : (int * TrdType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> TrdType.RegularTrade
        |"1"B -> TrdType.BlockTrade
        |"2"B -> TrdType.Efp
        |"3"B -> TrdType.Transfer
        |"4"B -> TrdType.LateTrade
        |"5"B -> TrdType.TTrade
        |"6"B -> TrdType.WeightedAveragePriceTrade
        |"7"B -> TrdType.BunchedTrade
        |"8"B -> TrdType.LateBunchedTrade
        |"9"B -> TrdType.PriorReferencePriceTrade
        |"10"B -> TrdType.AfterHoursTrade
        | x -> failwith (sprintf "ReadTrdType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTrdSubType (pos:int) (bs:byte[]) : (int*TrdSubType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TrdSubType.TrdSubType


let ReadTransferReason (pos:int) (bs:byte[]) : (int*TransferReason) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TransferReason.TransferReason


let ReadAsgnReqID (pos:int) (bs:byte[]) : (int*AsgnReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AsgnReqID.AsgnReqID


let ReadTotNumAssignmentReports (pos:int) (bs:byte[]) : (int*TotNumAssignmentReports) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotNumAssignmentReports.TotNumAssignmentReports


let ReadAsgnRptID (pos:int) (bs:byte[]) : (int*AsgnRptID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AsgnRptID.AsgnRptID


let ReadThresholdAmount (pos:int) (bs:byte[]) : (int*ThresholdAmount) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) ThresholdAmount.ThresholdAmount


let ReadPegMoveType (pos:int) (bs:byte[]) : (int * PegMoveType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> PegMoveType.Floating
        |"1"B -> PegMoveType.Fixed
        | x -> failwith (sprintf "ReadPegMoveType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPegOffsetType (pos:int) (bs:byte[]) : (int * PegOffsetType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> PegOffsetType.Price
        |"1"B -> PegOffsetType.BasisPoints
        |"2"B -> PegOffsetType.Ticks
        |"3"B -> PegOffsetType.PriceTierLevel
        | x -> failwith (sprintf "ReadPegOffsetType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPegLimitType (pos:int) (bs:byte[]) : (int * PegLimitType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> PegLimitType.OrBetter
        |"1"B -> PegLimitType.Strict
        |"2"B -> PegLimitType.OrWorse
        | x -> failwith (sprintf "ReadPegLimitType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPegRoundDirection (pos:int) (bs:byte[]) : (int * PegRoundDirection) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> PegRoundDirection.MoreAggressive
        |"2"B -> PegRoundDirection.MorePassive
        | x -> failwith (sprintf "ReadPegRoundDirection unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPeggedPrice (pos:int) (bs:byte[]) : (int*PeggedPrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) PeggedPrice.PeggedPrice


let ReadPegScope (pos:int) (bs:byte[]) : (int * PegScope) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> PegScope.Local
        |"2"B -> PegScope.National
        |"3"B -> PegScope.Global
        |"4"B -> PegScope.NationalExcludingLocal
        | x -> failwith (sprintf "ReadPegScope unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadDiscretionMoveType (pos:int) (bs:byte[]) : (int * DiscretionMoveType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> DiscretionMoveType.Floating
        |"1"B -> DiscretionMoveType.Fixed
        | x -> failwith (sprintf "ReadDiscretionMoveType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadDiscretionOffsetType (pos:int) (bs:byte[]) : (int * DiscretionOffsetType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> DiscretionOffsetType.Price
        |"1"B -> DiscretionOffsetType.BasisPoints
        |"2"B -> DiscretionOffsetType.Ticks
        |"3"B -> DiscretionOffsetType.PriceTierLevel
        | x -> failwith (sprintf "ReadDiscretionOffsetType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadDiscretionLimitType (pos:int) (bs:byte[]) : (int * DiscretionLimitType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> DiscretionLimitType.OrBetter
        |"1"B -> DiscretionLimitType.Strict
        |"2"B -> DiscretionLimitType.OrWorse
        | x -> failwith (sprintf "ReadDiscretionLimitType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadDiscretionRoundDirection (pos:int) (bs:byte[]) : (int * DiscretionRoundDirection) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> DiscretionRoundDirection.MoreAggressive
        |"2"B -> DiscretionRoundDirection.MorePassive
        | x -> failwith (sprintf "ReadDiscretionRoundDirection unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadDiscretionPrice (pos:int) (bs:byte[]) : (int*DiscretionPrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) DiscretionPrice.DiscretionPrice


let ReadDiscretionScope (pos:int) (bs:byte[]) : (int * DiscretionScope) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> DiscretionScope.Local
        |"2"B -> DiscretionScope.National
        |"3"B -> DiscretionScope.Global
        |"4"B -> DiscretionScope.NationalExcludingLocal
        | x -> failwith (sprintf "ReadDiscretionScope unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTargetStrategy (pos:int) (bs:byte[]) : (int*TargetStrategy) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TargetStrategy.TargetStrategy


let ReadTargetStrategyParameters (pos:int) (bs:byte[]) : (int*TargetStrategyParameters) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TargetStrategyParameters.TargetStrategyParameters


let ReadParticipationRate (pos:int) (bs:byte[]) : (int*ParticipationRate) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) ParticipationRate.ParticipationRate


let ReadTargetStrategyPerformance (pos:int) (bs:byte[]) : (int*TargetStrategyPerformance) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) TargetStrategyPerformance.TargetStrategyPerformance


let ReadLastLiquidityInd (pos:int) (bs:byte[]) : (int * LastLiquidityInd) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> LastLiquidityInd.AddedLiquidity
        |"2"B -> LastLiquidityInd.RemovedLiquidity
        |"3"B -> LastLiquidityInd.LiquidityRoutedOut
        | x -> failwith (sprintf "ReadLastLiquidityInd unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadPublishTrdIndicator (pos:int) (bs:byte[]) : (int*PublishTrdIndicator) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) PublishTrdIndicator.PublishTrdIndicator


let ReadShortSaleReason (pos:int) (bs:byte[]) : (int * ShortSaleReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> ShortSaleReason.DealerSoldShort
        |"1"B -> ShortSaleReason.DealerSoldShortExempt
        |"2"B -> ShortSaleReason.SellingCustomerSoldShort
        |"3"B -> ShortSaleReason.SellingCustomerSoldShortExempt
        |"4"B -> ShortSaleReason.QualifedServiceRepresentativeOrAutomaticGiveupContraSideSoldShort
        |"5"B -> ShortSaleReason.QsrOrAguContraSideSoldShortExempt
        | x -> failwith (sprintf "ReadShortSaleReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadQtyType (pos:int) (bs:byte[]) : (int * QtyType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> QtyType.Units
        |"1"B -> QtyType.Contracts
        | x -> failwith (sprintf "ReadQtyType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSecondaryTrdType (pos:int) (bs:byte[]) : (int*SecondaryTrdType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) SecondaryTrdType.SecondaryTrdType


let ReadTradeReportType (pos:int) (bs:byte[]) : (int * TradeReportType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> TradeReportType.Submit
        |"1"B -> TradeReportType.Alleged
        |"2"B -> TradeReportType.Accept
        |"3"B -> TradeReportType.Decline
        |"4"B -> TradeReportType.Addendum
        |"5"B -> TradeReportType.NoWas
        |"6"B -> TradeReportType.TradeReportCancel
        |"7"B -> TradeReportType.LockedInTradeBreak
        | x -> failwith (sprintf "ReadTradeReportType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadAllocNoOrdersType (pos:int) (bs:byte[]) : (int * AllocNoOrdersType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> AllocNoOrdersType.NotSpecified
        |"1"B -> AllocNoOrdersType.ExplicitListProvided
        | x -> failwith (sprintf "ReadAllocNoOrdersType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadSharedCommission (pos:int) (bs:byte[]) : (int*SharedCommission) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) SharedCommission.SharedCommission


let ReadConfirmReqID (pos:int) (bs:byte[]) : (int*ConfirmReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) ConfirmReqID.ConfirmReqID


let ReadAvgParPx (pos:int) (bs:byte[]) : (int*AvgParPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) AvgParPx.AvgParPx


let ReadReportedPx (pos:int) (bs:byte[]) : (int*ReportedPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) ReportedPx.ReportedPx


let ReadNoCapacities (pos:int) (bs:byte[]) : (int*NoCapacities) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoCapacities.NoCapacities


let ReadOrderCapacityQty (pos:int) (bs:byte[]) : (int*OrderCapacityQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) OrderCapacityQty.OrderCapacityQty


let ReadNoEvents (pos:int) (bs:byte[]) : (int*NoEvents) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoEvents.NoEvents


let ReadEventType (pos:int) (bs:byte[]) : (int * EventType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> EventType.Put
        |"2"B -> EventType.Call
        |"3"B -> EventType.Tender
        |"4"B -> EventType.SinkingFundCall
        |"99"B -> EventType.Other
        | x -> failwith (sprintf "ReadEventType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadEventDate (pos:int) (bs:byte[]) : (int*EventDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) EventDate.EventDate


let ReadEventPx (pos:int) (bs:byte[]) : (int*EventPx) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) EventPx.EventPx


let ReadEventText (pos:int) (bs:byte[]) : (int*EventText) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) EventText.EventText


let ReadPctAtRisk (pos:int) (bs:byte[]) : (int*PctAtRisk) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) PctAtRisk.PctAtRisk


let ReadNoInstrAttrib (pos:int) (bs:byte[]) : (int*NoInstrAttrib) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoInstrAttrib.NoInstrAttrib


let ReadInstrAttribType (pos:int) (bs:byte[]) : (int * InstrAttribType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> InstrAttribType.Flat
        |"2"B -> InstrAttribType.ZeroCoupon
        |"3"B -> InstrAttribType.InterestBearing
        |"4"B -> InstrAttribType.NoPeriodicPayments
        |"5"B -> InstrAttribType.VariableRate
        |"6"B -> InstrAttribType.LessFeeForPut
        |"7"B -> InstrAttribType.SteppedCoupon
        |"8"B -> InstrAttribType.CouponPeriod
        |"9"B -> InstrAttribType.WhenAndIfIssued
        |"10"B -> InstrAttribType.OriginalIssueDiscount
        |"11"B -> InstrAttribType.CallablePuttable
        |"12"B -> InstrAttribType.EscrowedToMaturity
        |"13"B -> InstrAttribType.EscrowedToRedemptionDate
        |"14"B -> InstrAttribType.PreRefunded
        |"15"B -> InstrAttribType.InDefault
        |"16"B -> InstrAttribType.Unrated
        |"17"B -> InstrAttribType.Taxable
        |"18"B -> InstrAttribType.Indexed
        |"19"B -> InstrAttribType.SubjectToAlternativeMinimumTax
        |"20"B -> InstrAttribType.OriginalIssueDiscountPrice
        |"21"B -> InstrAttribType.CallableBelowMaturityValue
        |"22"B -> InstrAttribType.CallableWithoutNoticeByMailToHolderUnlessRegistered
        |"99"B -> InstrAttribType.Text
        | x -> failwith (sprintf "ReadInstrAttribType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadInstrAttribValue (pos:int) (bs:byte[]) : (int*InstrAttribValue) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) InstrAttribValue.InstrAttribValue


let ReadDatedDate (pos:int) (bs:byte[]) : (int*DatedDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) DatedDate.DatedDate


let ReadInterestAccrualDate (pos:int) (bs:byte[]) : (int*InterestAccrualDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) InterestAccrualDate.InterestAccrualDate


let ReadCPProgram (pos:int) (bs:byte[]) : (int*CPProgram) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) CPProgram.CPProgram


let ReadCPRegType (pos:int) (bs:byte[]) : (int*CPRegType) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CPRegType.CPRegType


let ReadUnderlyingCPProgram (pos:int) (bs:byte[]) : (int*UnderlyingCPProgram) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingCPProgram.UnderlyingCPProgram


let ReadUnderlyingCPRegType (pos:int) (bs:byte[]) : (int*UnderlyingCPRegType) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingCPRegType.UnderlyingCPRegType


let ReadUnderlyingQty (pos:int) (bs:byte[]) : (int*UnderlyingQty) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) UnderlyingQty.UnderlyingQty


let ReadTrdMatchID (pos:int) (bs:byte[]) : (int*TrdMatchID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TrdMatchID.TrdMatchID


let ReadSecondaryTradeReportRefID (pos:int) (bs:byte[]) : (int*SecondaryTradeReportRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) SecondaryTradeReportRefID.SecondaryTradeReportRefID


let ReadUnderlyingDirtyPrice (pos:int) (bs:byte[]) : (int*UnderlyingDirtyPrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) UnderlyingDirtyPrice.UnderlyingDirtyPrice


let ReadUnderlyingEndPrice (pos:int) (bs:byte[]) : (int*UnderlyingEndPrice) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) UnderlyingEndPrice.UnderlyingEndPrice


let ReadUnderlyingStartValue (pos:int) (bs:byte[]) : (int*UnderlyingStartValue) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) UnderlyingStartValue.UnderlyingStartValue


let ReadUnderlyingCurrentValue (pos:int) (bs:byte[]) : (int*UnderlyingCurrentValue) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) UnderlyingCurrentValue.UnderlyingCurrentValue


let ReadUnderlyingEndValue (pos:int) (bs:byte[]) : (int*UnderlyingEndValue) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) UnderlyingEndValue.UnderlyingEndValue


let ReadNoUnderlyingStips (pos:int) (bs:byte[]) : (int*NoUnderlyingStips) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoUnderlyingStips.NoUnderlyingStips


let ReadUnderlyingStipType (pos:int) (bs:byte[]) : (int*UnderlyingStipType) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingStipType.UnderlyingStipType


let ReadUnderlyingStipValue (pos:int) (bs:byte[]) : (int*UnderlyingStipValue) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingStipValue.UnderlyingStipValue


let ReadMaturityNetMoney (pos:int) (bs:byte[]) : (int*MaturityNetMoney) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) MaturityNetMoney.MaturityNetMoney


let ReadMiscFeeBasis (pos:int) (bs:byte[]) : (int * MiscFeeBasis) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> MiscFeeBasis.Absolute
        |"1"B -> MiscFeeBasis.PerUnit
        |"2"B -> MiscFeeBasis.Percentage
        | x -> failwith (sprintf "ReadMiscFeeBasis unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTotNoAllocs (pos:int) (bs:byte[]) : (int*TotNoAllocs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotNoAllocs.TotNoAllocs


let ReadLastFragment (pos:int) (bs:byte[]) : (int*LastFragment) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) LastFragment.LastFragment


let ReadCollReqID (pos:int) (bs:byte[]) : (int*CollReqID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CollReqID.CollReqID


let ReadCollAsgnReason (pos:int) (bs:byte[]) : (int * CollAsgnReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> CollAsgnReason.Initial
        |"1"B -> CollAsgnReason.Scheduled
        |"2"B -> CollAsgnReason.TimeWarning
        |"3"B -> CollAsgnReason.MarginDeficiency
        |"4"B -> CollAsgnReason.MarginExcess
        |"5"B -> CollAsgnReason.ForwardCollateralDemand
        |"6"B -> CollAsgnReason.EventOfDefault
        |"7"B -> CollAsgnReason.AdverseTaxEvent
        | x -> failwith (sprintf "ReadCollAsgnReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCollInquiryQualifier (pos:int) (bs:byte[]) : (int * CollInquiryQualifier) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> CollInquiryQualifier.Tradedate
        |"1"B -> CollInquiryQualifier.GcInstrument
        |"2"B -> CollInquiryQualifier.Collateralinstrument
        |"3"B -> CollInquiryQualifier.SubstitutionEligible
        |"4"B -> CollInquiryQualifier.NotAssigned
        |"5"B -> CollInquiryQualifier.PartiallyAssigned
        |"6"B -> CollInquiryQualifier.FullyAssigned
        |"7"B -> CollInquiryQualifier.OutstandingTrades
        | x -> failwith (sprintf "ReadCollInquiryQualifier unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoTrades (pos:int) (bs:byte[]) : (int*NoTrades) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoTrades.NoTrades


let ReadMarginRatio (pos:int) (bs:byte[]) : (int*MarginRatio) =
    ReadSingleCaseDUDecimalField (pos:int) (bs:byte[]) MarginRatio.MarginRatio


let ReadMarginExcess (pos:int) (bs:byte[]) : (int*MarginExcess) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) MarginExcess.MarginExcess


let ReadTotalNetValue (pos:int) (bs:byte[]) : (int*TotalNetValue) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotalNetValue.TotalNetValue


let ReadCashOutstanding (pos:int) (bs:byte[]) : (int*CashOutstanding) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) CashOutstanding.CashOutstanding


let ReadCollAsgnID (pos:int) (bs:byte[]) : (int*CollAsgnID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CollAsgnID.CollAsgnID


let ReadCollAsgnTransType (pos:int) (bs:byte[]) : (int * CollAsgnTransType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> CollAsgnTransType.New
        |"1"B -> CollAsgnTransType.Replace
        |"2"B -> CollAsgnTransType.Cancel
        |"3"B -> CollAsgnTransType.Release
        |"4"B -> CollAsgnTransType.Reverse
        | x -> failwith (sprintf "ReadCollAsgnTransType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCollRespID (pos:int) (bs:byte[]) : (int*CollRespID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CollRespID.CollRespID


let ReadCollAsgnRespType (pos:int) (bs:byte[]) : (int * CollAsgnRespType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> CollAsgnRespType.Received
        |"1"B -> CollAsgnRespType.Accepted
        |"2"B -> CollAsgnRespType.Declined
        |"3"B -> CollAsgnRespType.Rejected
        | x -> failwith (sprintf "ReadCollAsgnRespType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCollAsgnRejectReason (pos:int) (bs:byte[]) : (int * CollAsgnRejectReason) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> CollAsgnRejectReason.UnknownDeal
        |"1"B -> CollAsgnRejectReason.UnknownOrInvalidInstrument
        |"2"B -> CollAsgnRejectReason.UnauthorizedTransaction
        |"3"B -> CollAsgnRejectReason.InsufficientCollateral
        |"4"B -> CollAsgnRejectReason.InvalidTypeOfCollateral
        |"5"B -> CollAsgnRejectReason.ExcessiveSubstitution
        |"99"B -> CollAsgnRejectReason.Other
        | x -> failwith (sprintf "ReadCollAsgnRejectReason unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCollAsgnRefID (pos:int) (bs:byte[]) : (int*CollAsgnRefID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CollAsgnRefID.CollAsgnRefID


let ReadCollRptID (pos:int) (bs:byte[]) : (int*CollRptID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CollRptID.CollRptID


let ReadCollInquiryID (pos:int) (bs:byte[]) : (int*CollInquiryID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) CollInquiryID.CollInquiryID


let ReadCollStatus (pos:int) (bs:byte[]) : (int * CollStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> CollStatus.Unassigned
        |"1"B -> CollStatus.PartiallyAssigned
        |"2"B -> CollStatus.AssignmentProposed
        |"3"B -> CollStatus.Assigned
        |"4"B -> CollStatus.Challenged
        | x -> failwith (sprintf "ReadCollStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadTotNumReports (pos:int) (bs:byte[]) : (int*TotNumReports) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) TotNumReports.TotNumReports


let ReadLastRptRequested (pos:int) (bs:byte[]) : (int*LastRptRequested) =
    ReadSingleCaseDUBoolField (pos:int) (bs:byte[]) LastRptRequested.LastRptRequested


let ReadAgreementDesc (pos:int) (bs:byte[]) : (int*AgreementDesc) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AgreementDesc.AgreementDesc


let ReadAgreementID (pos:int) (bs:byte[]) : (int*AgreementID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AgreementID.AgreementID


let ReadAgreementDate (pos:int) (bs:byte[]) : (int*AgreementDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AgreementDate.AgreementDate


let ReadStartDate (pos:int) (bs:byte[]) : (int*StartDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) StartDate.StartDate


let ReadEndDate (pos:int) (bs:byte[]) : (int*EndDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) EndDate.EndDate


let ReadAgreementCurrency (pos:int) (bs:byte[]) : (int*AgreementCurrency) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) AgreementCurrency.AgreementCurrency


let ReadDeliveryType (pos:int) (bs:byte[]) : (int * DeliveryType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> DeliveryType.VersusPayment
        |"1"B -> DeliveryType.Free
        |"2"B -> DeliveryType.TriParty
        |"3"B -> DeliveryType.HoldInCustody
        | x -> failwith (sprintf "ReadDeliveryType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadEndAccruedInterestAmt (pos:int) (bs:byte[]) : (int*EndAccruedInterestAmt) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) EndAccruedInterestAmt.EndAccruedInterestAmt


let ReadStartCash (pos:int) (bs:byte[]) : (int*StartCash) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) StartCash.StartCash


let ReadEndCash (pos:int) (bs:byte[]) : (int*EndCash) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) EndCash.EndCash


let ReadUserRequestID (pos:int) (bs:byte[]) : (int*UserRequestID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UserRequestID.UserRequestID


let ReadUserRequestType (pos:int) (bs:byte[]) : (int * UserRequestType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> UserRequestType.Logonuser
        |"2"B -> UserRequestType.Logoffuser
        |"3"B -> UserRequestType.Changepasswordforuser
        |"4"B -> UserRequestType.RequestIndividualUserStatus
        | x -> failwith (sprintf "ReadUserRequestType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNewPassword (pos:int) (bs:byte[]) : (int*NewPassword) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) NewPassword.NewPassword


let ReadUserStatus (pos:int) (bs:byte[]) : (int * UserStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> UserStatus.LoggedIn
        |"2"B -> UserStatus.NotLoggedIn
        |"3"B -> UserStatus.UserNotRecognised
        |"4"B -> UserStatus.PasswordIncorrect
        |"5"B -> UserStatus.PasswordChanged
        |"6"B -> UserStatus.Other
        | x -> failwith (sprintf "ReadUserStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadUserStatusText (pos:int) (bs:byte[]) : (int*UserStatusText) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UserStatusText.UserStatusText


let ReadStatusValue (pos:int) (bs:byte[]) : (int * StatusValue) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> StatusValue.Connected
        |"2"B -> StatusValue.NotConnectedDownExpectedUp
        |"3"B -> StatusValue.NotConnectedDownExpectedDown
        |"4"B -> StatusValue.InProcess
        | x -> failwith (sprintf "ReadStatusValue unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadStatusText (pos:int) (bs:byte[]) : (int*StatusText) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) StatusText.StatusText


let ReadRefCompID (pos:int) (bs:byte[]) : (int*RefCompID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) RefCompID.RefCompID


let ReadRefSubID (pos:int) (bs:byte[]) : (int*RefSubID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) RefSubID.RefSubID


let ReadNetworkResponseID (pos:int) (bs:byte[]) : (int*NetworkResponseID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) NetworkResponseID.NetworkResponseID


let ReadNetworkRequestID (pos:int) (bs:byte[]) : (int*NetworkRequestID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) NetworkRequestID.NetworkRequestID


let ReadLastNetworkResponseID (pos:int) (bs:byte[]) : (int*LastNetworkResponseID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LastNetworkResponseID.LastNetworkResponseID


let ReadNetworkRequestType (pos:int) (bs:byte[]) : (int * NetworkRequestType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> NetworkRequestType.Snapshot
        |"2"B -> NetworkRequestType.Subscribe
        |"4"B -> NetworkRequestType.StopSubscribing
        |"8"B -> NetworkRequestType.LevelOfDetail
        | x -> failwith (sprintf "ReadNetworkRequestType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoCompIDs (pos:int) (bs:byte[]) : (int*NoCompIDs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoCompIDs.NoCompIDs


let ReadNetworkStatusResponseType (pos:int) (bs:byte[]) : (int * NetworkStatusResponseType) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> NetworkStatusResponseType.Full
        |"2"B -> NetworkStatusResponseType.IncrementalUpdate
        | x -> failwith (sprintf "ReadNetworkStatusResponseType unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadNoCollInquiryQualifier (pos:int) (bs:byte[]) : (int*NoCollInquiryQualifier) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoCollInquiryQualifier.NoCollInquiryQualifier


let ReadTrdRptStatus (pos:int) (bs:byte[]) : (int * TrdRptStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> TrdRptStatus.Accepted
        |"1"B -> TrdRptStatus.Rejected
        | x -> failwith (sprintf "ReadTrdRptStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadAffirmStatus (pos:int) (bs:byte[]) : (int * AffirmStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"1"B -> AffirmStatus.Received
        |"2"B -> AffirmStatus.ConfirmRejected
        |"3"B -> AffirmStatus.Affirmed
        | x -> failwith (sprintf "ReadAffirmStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadUnderlyingStrikeCurrency (pos:int) (bs:byte[]) : (int*UnderlyingStrikeCurrency) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) UnderlyingStrikeCurrency.UnderlyingStrikeCurrency


let ReadLegStrikeCurrency (pos:int) (bs:byte[]) : (int*LegStrikeCurrency) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegStrikeCurrency.LegStrikeCurrency


let ReadTimeBracket (pos:int) (bs:byte[]) : (int*TimeBracket) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) TimeBracket.TimeBracket


let ReadCollAction (pos:int) (bs:byte[]) : (int * CollAction) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> CollAction.Retain
        |"1"B -> CollAction.Add
        |"2"B -> CollAction.Remove
        | x -> failwith (sprintf "ReadCollAction unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCollInquiryStatus (pos:int) (bs:byte[]) : (int * CollInquiryStatus) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> CollInquiryStatus.Accepted
        |"1"B -> CollInquiryStatus.AcceptedWithWarnings
        |"2"B -> CollInquiryStatus.Completed
        |"3"B -> CollInquiryStatus.CompletedWithWarnings
        |"4"B -> CollInquiryStatus.Rejected
        | x -> failwith (sprintf "ReadCollInquiryStatus unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadCollInquiryResult (pos:int) (bs:byte[]) : (int * CollInquiryResult) =
    let pos2, valIn = ByteArrayUtils.readValAfterTagValSep pos bs
    let fld = 
        match valIn with
        |"0"B -> CollInquiryResult.Successful
        |"1"B -> CollInquiryResult.InvalidOrUnknownInstrument
        |"2"B -> CollInquiryResult.InvalidOrUnknownCollateralType
        |"3"B -> CollInquiryResult.InvalidParties
        |"4"B -> CollInquiryResult.InvalidTransportTypeRequested
        |"5"B -> CollInquiryResult.InvalidDestinationRequested
        |"6"B -> CollInquiryResult.NoCollateralFoundForTheTradeSpecified
        |"7"B -> CollInquiryResult.NoCollateralFoundForTheOrderSpecified
        |"8"B -> CollInquiryResult.CollateralInquiryTypeNotSupported
        |"9"B -> CollInquiryResult.UnauthorizedForCollateralInquiry
        |"99"B -> CollInquiryResult.Other
        | x -> failwith (sprintf "ReadCollInquiryResult unknown fix tag: %A"  x) 
    pos2 + 1, fld  // +1 to advance the position to after the field separator


let ReadStrikeCurrency (pos:int) (bs:byte[]) : (int*StrikeCurrency) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) StrikeCurrency.StrikeCurrency


let ReadNoNested3PartyIDs (pos:int) (bs:byte[]) : (int*NoNested3PartyIDs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoNested3PartyIDs.NoNested3PartyIDs


let ReadNested3PartyID (pos:int) (bs:byte[]) : (int*Nested3PartyID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Nested3PartyID.Nested3PartyID


let ReadNested3PartyIDSource (pos:int) (bs:byte[]) : (int*Nested3PartyIDSource) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) Nested3PartyIDSource.Nested3PartyIDSource


let ReadNested3PartyRole (pos:int) (bs:byte[]) : (int*Nested3PartyRole) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) Nested3PartyRole.Nested3PartyRole


let ReadNoNested3PartySubIDs (pos:int) (bs:byte[]) : (int*NoNested3PartySubIDs) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) NoNested3PartySubIDs.NoNested3PartySubIDs


let ReadNested3PartySubID (pos:int) (bs:byte[]) : (int*Nested3PartySubID) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) Nested3PartySubID.Nested3PartySubID


let ReadNested3PartySubIDType (pos:int) (bs:byte[]) : (int*Nested3PartySubIDType) =
    ReadSingleCaseDUIntField (pos:int) (bs:byte[]) Nested3PartySubIDType.Nested3PartySubIDType


let ReadLegContractSettlMonth (pos:int) (bs:byte[]) : (int*LegContractSettlMonth) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegContractSettlMonth.LegContractSettlMonth


let ReadLegInterestAccrualDate (pos:int) (bs:byte[]) : (int*LegInterestAccrualDate) =
    ReadSingleCaseDUStrField (pos:int) (bs:byte[]) LegInterestAccrualDate.LegInterestAccrualDate


