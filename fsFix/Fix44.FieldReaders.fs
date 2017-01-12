module Fix44.FieldReaders


open System
open System.IO
open Fix44.Fields
open Conversions
open RawField


// todo: is this function, and all like it, neccessary
let ReadHeartBtIntIdx (bs:byte[]) (pos:int) (len:int): HeartBtInt =
    ReadFieldIntIdx bs pos len HeartBtInt.HeartBtInt


let ReadEncryptMethodIdx (bs:byte[]) (pos:int) (len:int): EncryptMethod =
    //let valIn = FIXBuf.readValAfterTagValSep bs pos len
    let valTag = FIXBufIndexer.convTagToInt bs pos (pos+len)
    match valTag with
    |48 -> EncryptMethod.NoneOther
    |49 -> EncryptMethod.Pkcs
    |50 -> EncryptMethod.Des
    |51 -> EncryptMethod.PkcsDes
    |52 -> EncryptMethod.PgpDes
    |53 -> EncryptMethod.PgpDesMd5
    |54 -> EncryptMethod.PemDesMd5
    | x -> let msg = sprintf "ReadEncryptMethod unknown fix tag: %A" x
           failwith msg




let ReadAccount (bs:byte[]) (pos:int): (int*Account) =
    ReadFieldStr bs pos Account.Account


let ReadAdvId (bs:byte[]) (pos:int): (int*AdvId) =
    ReadFieldStr bs pos AdvId.AdvId


let ReadAdvRefID (bs:byte[]) (pos:int): (int*AdvRefID) =
    ReadFieldStr bs pos AdvRefID.AdvRefID


let ReadAdvSide (bs:byte[]) (pos:int) : (int * AdvSide) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"B"B -> AdvSide.Buy
        |"S"B -> AdvSide.Sell
        |"X"B -> AdvSide.Cross
        |"T"B -> AdvSide.Trade
        | x -> failwith (sprintf "ReadAdvSide unknown fix tag: %A"  x) 
    pos2, fld


let ReadAdvTransType (bs:byte[]) (pos:int) : (int * AdvTransType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"N"B -> AdvTransType.New
        |"C"B -> AdvTransType.Cancel
        |"R"B -> AdvTransType.Replace
        | x -> failwith (sprintf "ReadAdvTransType unknown fix tag: %A"  x) 
    pos2, fld


let ReadAvgPx (bs:byte[]) (pos:int): (int*AvgPx) =
    ReadFieldDecimal bs pos AvgPx.AvgPx


let ReadBeginSeqNo (bs:byte[]) (pos:int): (int*BeginSeqNo) =
    ReadFieldUint32 bs pos BeginSeqNo.BeginSeqNo


let ReadBeginString (bs:byte[]) (pos:int): (int*BeginString) =
    ReadFieldStr bs pos BeginString.BeginString


let ReadBodyLength (bs:byte[]) (pos:int): (int*BodyLength) =
    ReadFieldUint32 bs pos BodyLength.BodyLength


let ReadCheckSum (bs:byte[]) (pos:int): (int*CheckSum) =
    ReadFieldStr bs pos CheckSum.CheckSum


let ReadClOrdID (bs:byte[]) (pos:int): (int*ClOrdID) =
    ReadFieldStr bs pos ClOrdID.ClOrdID


let ReadCommission (bs:byte[]) (pos:int): (int*Commission) =
    ReadFieldDecimal bs pos Commission.Commission


let ReadCommType (bs:byte[]) (pos:int) : (int * CommType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> CommType.PerUnit
        |"2"B -> CommType.Percentage
        |"3"B -> CommType.Absolute
        |"4"B -> CommType.PercentageWaivedCashDiscount
        |"5"B -> CommType.PercentageWaivedEnhancedUnits
        |"6"B -> CommType.PointsPerBondOrOrContract
        | x -> failwith (sprintf "ReadCommType unknown fix tag: %A"  x) 
    pos2, fld


let ReadCumQty (bs:byte[]) (pos:int): (int*CumQty) =
    ReadFieldDecimal bs pos CumQty.CumQty


let ReadCurrency (bs:byte[]) (pos:int): (int*Currency) =
    ReadFieldStr bs pos Currency.Currency


let ReadEndSeqNo (bs:byte[]) (pos:int): (int*EndSeqNo) =
    ReadFieldUint32 bs pos EndSeqNo.EndSeqNo


let ReadExecID (bs:byte[]) (pos:int): (int*ExecID) =
    ReadFieldStr bs pos ExecID.ExecID


let ReadExecInst (bs:byte[]) (pos:int) : (int * ExecInst) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadExecRefID (bs:byte[]) (pos:int): (int*ExecRefID) =
    ReadFieldStr bs pos ExecRefID.ExecRefID


let ReadHandlInst (bs:byte[]) (pos:int) : (int * HandlInst) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> HandlInst.AutomatedExecutionOrderPrivate
        |"2"B -> HandlInst.AutomatedExecutionOrderPublic
        |"3"B -> HandlInst.ManualOrder
        | x -> failwith (sprintf "ReadHandlInst unknown fix tag: %A"  x) 
    pos2, fld


let ReadSecurityIDSource (bs:byte[]) (pos:int) : (int * SecurityIDSource) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadIOIid (bs:byte[]) (pos:int): (int*IOIid) =
    ReadFieldStr bs pos IOIid.IOIid


let ReadIOIQltyInd (bs:byte[]) (pos:int) : (int * IOIQltyInd) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"L"B -> IOIQltyInd.Low
        |"M"B -> IOIQltyInd.Medium
        |"H"B -> IOIQltyInd.High
        | x -> failwith (sprintf "ReadIOIQltyInd unknown fix tag: %A"  x) 
    pos2, fld


let ReadIOIRefID (bs:byte[]) (pos:int): (int*IOIRefID) =
    ReadFieldStr bs pos IOIRefID.IOIRefID


let ReadIOIQty (bs:byte[]) (pos:int): (int*IOIQty) =
    ReadFieldStr bs pos IOIQty.IOIQty


let ReadIOITransType (bs:byte[]) (pos:int) : (int * IOITransType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"N"B -> IOITransType.New
        |"C"B -> IOITransType.Cancel
        |"R"B -> IOITransType.Replace
        | x -> failwith (sprintf "ReadIOITransType unknown fix tag: %A"  x) 
    pos2, fld


let ReadLastCapacity (bs:byte[]) (pos:int) : (int * LastCapacity) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> LastCapacity.Agent
        |"2"B -> LastCapacity.CrossAsAgent
        |"3"B -> LastCapacity.CrossAsPrincipal
        |"4"B -> LastCapacity.Principal
        | x -> failwith (sprintf "ReadLastCapacity unknown fix tag: %A"  x) 
    pos2, fld


let ReadLastMkt (bs:byte[]) (pos:int): (int*LastMkt) =
    ReadFieldStr bs pos LastMkt.LastMkt


let ReadLastPx (bs:byte[]) (pos:int): (int*LastPx) =
    ReadFieldDecimal bs pos LastPx.LastPx


let ReadLastQty (bs:byte[]) (pos:int): (int*LastQty) =
    ReadFieldDecimal bs pos LastQty.LastQty


let ReadLinesOfText (bs:byte[]) (pos:int): (int*LinesOfText) =
    ReadFieldInt bs pos LinesOfText.LinesOfText


let ReadMsgSeqNum (bs:byte[]) (pos:int): (int*MsgSeqNum) =
    ReadFieldUint32 bs pos MsgSeqNum.MsgSeqNum


let ReadMsgType (bs:byte[]) (pos:int) : (int * MsgType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadNewSeqNo (bs:byte[]) (pos:int): (int*NewSeqNo) =
    ReadFieldUint32 bs pos NewSeqNo.NewSeqNo


let ReadOrderID (bs:byte[]) (pos:int): (int*OrderID) =
    ReadFieldStr bs pos OrderID.OrderID


let ReadOrderQty (bs:byte[]) (pos:int): (int*OrderQty) =
    ReadFieldDecimal bs pos OrderQty.OrderQty


let ReadOrdStatus (bs:byte[]) (pos:int) : (int * OrdStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadOrdType (bs:byte[]) (pos:int) : (int * OrdType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadOrigClOrdID (bs:byte[]) (pos:int): (int*OrigClOrdID) =
    ReadFieldStr bs pos OrigClOrdID.OrigClOrdID


let ReadOrigTime (bs:byte[]) (pos:int): (int*OrigTime) =
    ReadFieldUTCTimestamp bs pos OrigTime.OrigTime


let ReadPossDupFlag (bs:byte[]) (pos:int): (int*PossDupFlag) =
    ReadFieldBool bs pos PossDupFlag.PossDupFlag


let ReadPrice (bs:byte[]) (pos:int): (int*Price) =
    ReadFieldDecimal bs pos Price.Price


let ReadRefSeqNum (bs:byte[]) (pos:int): (int*RefSeqNum) =
    ReadFieldUint32 bs pos RefSeqNum.RefSeqNum


let ReadSecurityID (bs:byte[]) (pos:int): (int*SecurityID) =
    ReadFieldStr bs pos SecurityID.SecurityID


let ReadSenderCompID (bs:byte[]) (pos:int): (int*SenderCompID) =
    ReadFieldStr bs pos SenderCompID.SenderCompID


let ReadSenderSubID (bs:byte[]) (pos:int): (int*SenderSubID) =
    ReadFieldStr bs pos SenderSubID.SenderSubID


let ReadSendingTime (bs:byte[]) (pos:int): (int*SendingTime) =
    ReadFieldUTCTimestamp bs pos SendingTime.SendingTime


let ReadQuantity (bs:byte[]) (pos:int): (int*Quantity) =
    ReadFieldDecimal bs pos Quantity.Quantity


let ReadSide (bs:byte[]) (pos:int) : (int * Side) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadSymbol (bs:byte[]) (pos:int): (int*Symbol) =
    ReadFieldStr bs pos Symbol.Symbol


let ReadTargetCompID (bs:byte[]) (pos:int): (int*TargetCompID) =
    ReadFieldStr bs pos TargetCompID.TargetCompID


let ReadTargetSubID (bs:byte[]) (pos:int): (int*TargetSubID) =
    ReadFieldStr bs pos TargetSubID.TargetSubID


let ReadText (bs:byte[]) (pos:int): (int*Text) =
    ReadFieldStr bs pos Text.Text


let ReadTimeInForce (bs:byte[]) (pos:int) : (int * TimeInForce) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadTransactTime (bs:byte[]) (pos:int): (int*TransactTime) =
    ReadFieldUTCTimestamp bs pos TransactTime.TransactTime


let ReadUrgency (bs:byte[]) (pos:int) : (int * Urgency) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> Urgency.Normal
        |"1"B -> Urgency.Flash
        |"2"B -> Urgency.Background
        | x -> failwith (sprintf "ReadUrgency unknown fix tag: %A"  x) 
    pos2, fld


let ReadValidUntilTime (bs:byte[]) (pos:int): (int*ValidUntilTime) =
    ReadFieldUTCTimestamp bs pos ValidUntilTime.ValidUntilTime


let ReadSettlType (bs:byte[]) (pos:int) : (int * SettlType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadSettlDate (bs:byte[]) (pos:int): (int*SettlDate) =
    ReadFieldLocalMktDate bs pos SettlDate.SettlDate


let ReadSymbolSfx (bs:byte[]) (pos:int) : (int * SymbolSfx) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"WI"B -> SymbolSfx.WhenIssued
        |"CD"B -> SymbolSfx.AEucpWithLumpSumInterest
        | x -> failwith (sprintf "ReadSymbolSfx unknown fix tag: %A"  x) 
    pos2, fld


let ReadListID (bs:byte[]) (pos:int): (int*ListID) =
    ReadFieldStr bs pos ListID.ListID


let ReadListSeqNo (bs:byte[]) (pos:int): (int*ListSeqNo) =
    ReadFieldInt bs pos ListSeqNo.ListSeqNo


let ReadTotNoOrders (bs:byte[]) (pos:int): (int*TotNoOrders) =
    ReadFieldInt bs pos TotNoOrders.TotNoOrders


let ReadListExecInst (bs:byte[]) (pos:int): (int*ListExecInst) =
    ReadFieldStr bs pos ListExecInst.ListExecInst


let ReadAllocID (bs:byte[]) (pos:int): (int*AllocID) =
    ReadFieldStr bs pos AllocID.AllocID


let ReadAllocTransType (bs:byte[]) (pos:int) : (int * AllocTransType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> AllocTransType.New
        |"1"B -> AllocTransType.Replace
        |"2"B -> AllocTransType.Cancel
        | x -> failwith (sprintf "ReadAllocTransType unknown fix tag: %A"  x) 
    pos2, fld


let ReadRefAllocID (bs:byte[]) (pos:int): (int*RefAllocID) =
    ReadFieldStr bs pos RefAllocID.RefAllocID


let ReadNoOrders (bs:byte[]) (pos:int): (int*NoOrders) =
    ReadFieldInt bs pos NoOrders.NoOrders


let ReadAvgPxPrecision (bs:byte[]) (pos:int): (int*AvgPxPrecision) =
    ReadFieldInt bs pos AvgPxPrecision.AvgPxPrecision


let ReadTradeDate (bs:byte[]) (pos:int): (int*TradeDate) =
    ReadFieldLocalMktDate bs pos TradeDate.TradeDate


let ReadPositionEffect (bs:byte[]) (pos:int) : (int * PositionEffect) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"O"B -> PositionEffect.Open
        |"C"B -> PositionEffect.Close
        |"R"B -> PositionEffect.Rolled
        |"F"B -> PositionEffect.Fifo
        | x -> failwith (sprintf "ReadPositionEffect unknown fix tag: %A"  x) 
    pos2, fld


let ReadNoAllocs (bs:byte[]) (pos:int): (int*NoAllocs) =
    ReadFieldInt bs pos NoAllocs.NoAllocs


let ReadAllocAccount (bs:byte[]) (pos:int): (int*AllocAccount) =
    ReadFieldStr bs pos AllocAccount.AllocAccount


let ReadAllocQty (bs:byte[]) (pos:int): (int*AllocQty) =
    ReadFieldDecimal bs pos AllocQty.AllocQty


let ReadProcessCode (bs:byte[]) (pos:int) : (int * ProcessCode) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadNoRpts (bs:byte[]) (pos:int): (int*NoRpts) =
    ReadFieldInt bs pos NoRpts.NoRpts


let ReadRptSeq (bs:byte[]) (pos:int): (int*RptSeq) =
    ReadFieldInt bs pos RptSeq.RptSeq


let ReadCxlQty (bs:byte[]) (pos:int): (int*CxlQty) =
    ReadFieldDecimal bs pos CxlQty.CxlQty


let ReadNoDlvyInst (bs:byte[]) (pos:int): (int*NoDlvyInst) =
    ReadFieldInt bs pos NoDlvyInst.NoDlvyInst


let ReadAllocStatus (bs:byte[]) (pos:int) : (int * AllocStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> AllocStatus.Accepted
        |"1"B -> AllocStatus.BlockLevelReject
        |"2"B -> AllocStatus.AccountLevelReject
        |"3"B -> AllocStatus.Received
        |"4"B -> AllocStatus.Incomplete
        |"5"B -> AllocStatus.RejectedByIntermediary
        | x -> failwith (sprintf "ReadAllocStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadAllocRejCode (bs:byte[]) (pos:int) : (int * AllocRejCode) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


// compound read
let ReadSignature (bs:byte[]) (pos:int) : (int * Signature) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "89"B Signature.Signature


// compound read
let ReadSecureData (bs:byte[]) (pos:int) : (int * SecureData) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "91"B SecureData.SecureData


let ReadEmailType (bs:byte[]) (pos:int) : (int * EmailType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> EmailType.New
        |"1"B -> EmailType.Reply
        |"2"B -> EmailType.AdminReply
        | x -> failwith (sprintf "ReadEmailType unknown fix tag: %A"  x) 
    pos2, fld


// compound read
let ReadRawData (bs:byte[]) (pos:int) : (int * RawData) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "96"B RawData.RawData


let ReadPossResend (bs:byte[]) (pos:int): (int*PossResend) =
    ReadFieldBool bs pos PossResend.PossResend


let ReadEncryptMethod (bs:byte[]) (pos:int) : (int * EncryptMethod) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadStopPx (bs:byte[]) (pos:int): (int*StopPx) =
    ReadFieldDecimal bs pos StopPx.StopPx


let ReadExDestination (bs:byte[]) (pos:int): (int*ExDestination) =
    ReadFieldStr bs pos ExDestination.ExDestination


let ReadCxlRejReason (bs:byte[]) (pos:int) : (int * CxlRejReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadOrdRejReason (bs:byte[]) (pos:int) : (int * OrdRejReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadIOIQualifier (bs:byte[]) (pos:int) : (int * IOIQualifier) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadWaveNo (bs:byte[]) (pos:int): (int*WaveNo) =
    ReadFieldStr bs pos WaveNo.WaveNo


let ReadIssuer (bs:byte[]) (pos:int): (int*Issuer) =
    ReadFieldStr bs pos Issuer.Issuer


let ReadSecurityDesc (bs:byte[]) (pos:int): (int*SecurityDesc) =
    ReadFieldStr bs pos SecurityDesc.SecurityDesc


let ReadHeartBtInt (bs:byte[]) (pos:int): (int*HeartBtInt) =
    ReadFieldInt bs pos HeartBtInt.HeartBtInt


let ReadMinQty (bs:byte[]) (pos:int): (int*MinQty) =
    ReadFieldDecimal bs pos MinQty.MinQty


let ReadMaxFloor (bs:byte[]) (pos:int): (int*MaxFloor) =
    ReadFieldDecimal bs pos MaxFloor.MaxFloor


let ReadTestReqID (bs:byte[]) (pos:int): (int*TestReqID) =
    ReadFieldStr bs pos TestReqID.TestReqID


let ReadReportToExch (bs:byte[]) (pos:int): (int*ReportToExch) =
    ReadFieldBool bs pos ReportToExch.ReportToExch


let ReadLocateReqd (bs:byte[]) (pos:int): (int*LocateReqd) =
    ReadFieldBool bs pos LocateReqd.LocateReqd


let ReadOnBehalfOfCompID (bs:byte[]) (pos:int): (int*OnBehalfOfCompID) =
    ReadFieldStr bs pos OnBehalfOfCompID.OnBehalfOfCompID


let ReadOnBehalfOfSubID (bs:byte[]) (pos:int): (int*OnBehalfOfSubID) =
    ReadFieldStr bs pos OnBehalfOfSubID.OnBehalfOfSubID


let ReadQuoteID (bs:byte[]) (pos:int): (int*QuoteID) =
    ReadFieldStr bs pos QuoteID.QuoteID


let ReadNetMoney (bs:byte[]) (pos:int): (int*NetMoney) =
    ReadFieldDecimal bs pos NetMoney.NetMoney


let ReadSettlCurrAmt (bs:byte[]) (pos:int): (int*SettlCurrAmt) =
    ReadFieldDecimal bs pos SettlCurrAmt.SettlCurrAmt


let ReadSettlCurrency (bs:byte[]) (pos:int): (int*SettlCurrency) =
    ReadFieldStr bs pos SettlCurrency.SettlCurrency


let ReadForexReq (bs:byte[]) (pos:int): (int*ForexReq) =
    ReadFieldBool bs pos ForexReq.ForexReq


let ReadOrigSendingTime (bs:byte[]) (pos:int): (int*OrigSendingTime) =
    ReadFieldUTCTimestamp bs pos OrigSendingTime.OrigSendingTime


let ReadGapFillFlag (bs:byte[]) (pos:int): (int*GapFillFlag) =
    ReadFieldBool bs pos GapFillFlag.GapFillFlag


let ReadNoExecs (bs:byte[]) (pos:int): (int*NoExecs) =
    ReadFieldInt bs pos NoExecs.NoExecs


let ReadExpireTime (bs:byte[]) (pos:int): (int*ExpireTime) =
    ReadFieldUTCTimestamp bs pos ExpireTime.ExpireTime


let ReadDKReason (bs:byte[]) (pos:int) : (int * DKReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadDeliverToCompID (bs:byte[]) (pos:int): (int*DeliverToCompID) =
    ReadFieldStr bs pos DeliverToCompID.DeliverToCompID


let ReadDeliverToSubID (bs:byte[]) (pos:int): (int*DeliverToSubID) =
    ReadFieldStr bs pos DeliverToSubID.DeliverToSubID


let ReadIOINaturalFlag (bs:byte[]) (pos:int): (int*IOINaturalFlag) =
    ReadFieldBool bs pos IOINaturalFlag.IOINaturalFlag


let ReadQuoteReqID (bs:byte[]) (pos:int): (int*QuoteReqID) =
    ReadFieldStr bs pos QuoteReqID.QuoteReqID


let ReadBidPx (bs:byte[]) (pos:int): (int*BidPx) =
    ReadFieldDecimal bs pos BidPx.BidPx


let ReadOfferPx (bs:byte[]) (pos:int): (int*OfferPx) =
    ReadFieldDecimal bs pos OfferPx.OfferPx


let ReadBidSize (bs:byte[]) (pos:int): (int*BidSize) =
    ReadFieldDecimal bs pos BidSize.BidSize


let ReadOfferSize (bs:byte[]) (pos:int): (int*OfferSize) =
    ReadFieldDecimal bs pos OfferSize.OfferSize


let ReadNoMiscFees (bs:byte[]) (pos:int): (int*NoMiscFees) =
    ReadFieldInt bs pos NoMiscFees.NoMiscFees


let ReadMiscFeeAmt (bs:byte[]) (pos:int): (int*MiscFeeAmt) =
    ReadFieldDecimal bs pos MiscFeeAmt.MiscFeeAmt


let ReadMiscFeeCurr (bs:byte[]) (pos:int): (int*MiscFeeCurr) =
    ReadFieldStr bs pos MiscFeeCurr.MiscFeeCurr


let ReadMiscFeeType (bs:byte[]) (pos:int) : (int * MiscFeeType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadPrevClosePx (bs:byte[]) (pos:int): (int*PrevClosePx) =
    ReadFieldDecimal bs pos PrevClosePx.PrevClosePx


let ReadResetSeqNumFlag (bs:byte[]) (pos:int): (int*ResetSeqNumFlag) =
    ReadFieldBool bs pos ResetSeqNumFlag.ResetSeqNumFlag


let ReadSenderLocationID (bs:byte[]) (pos:int): (int*SenderLocationID) =
    ReadFieldStr bs pos SenderLocationID.SenderLocationID


let ReadTargetLocationID (bs:byte[]) (pos:int): (int*TargetLocationID) =
    ReadFieldStr bs pos TargetLocationID.TargetLocationID


let ReadOnBehalfOfLocationID (bs:byte[]) (pos:int): (int*OnBehalfOfLocationID) =
    ReadFieldStr bs pos OnBehalfOfLocationID.OnBehalfOfLocationID


let ReadDeliverToLocationID (bs:byte[]) (pos:int): (int*DeliverToLocationID) =
    ReadFieldStr bs pos DeliverToLocationID.DeliverToLocationID


let ReadNoRelatedSym (bs:byte[]) (pos:int): (int*NoRelatedSym) =
    ReadFieldInt bs pos NoRelatedSym.NoRelatedSym


let ReadSubject (bs:byte[]) (pos:int): (int*Subject) =
    ReadFieldStr bs pos Subject.Subject


let ReadHeadline (bs:byte[]) (pos:int): (int*Headline) =
    ReadFieldStr bs pos Headline.Headline


let ReadURLLink (bs:byte[]) (pos:int): (int*URLLink) =
    ReadFieldStr bs pos URLLink.URLLink


let ReadExecType (bs:byte[]) (pos:int) : (int * ExecType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadLeavesQty (bs:byte[]) (pos:int): (int*LeavesQty) =
    ReadFieldDecimal bs pos LeavesQty.LeavesQty


let ReadCashOrderQty (bs:byte[]) (pos:int): (int*CashOrderQty) =
    ReadFieldDecimal bs pos CashOrderQty.CashOrderQty


let ReadAllocAvgPx (bs:byte[]) (pos:int): (int*AllocAvgPx) =
    ReadFieldDecimal bs pos AllocAvgPx.AllocAvgPx


let ReadAllocNetMoney (bs:byte[]) (pos:int): (int*AllocNetMoney) =
    ReadFieldDecimal bs pos AllocNetMoney.AllocNetMoney


let ReadSettlCurrFxRate (bs:byte[]) (pos:int): (int*SettlCurrFxRate) =
    ReadFieldDecimal bs pos SettlCurrFxRate.SettlCurrFxRate


let ReadSettlCurrFxRateCalc (bs:byte[]) (pos:int) : (int * SettlCurrFxRateCalc) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"M"B -> SettlCurrFxRateCalc.Multiply
        |"D"B -> SettlCurrFxRateCalc.Divide
        | x -> failwith (sprintf "ReadSettlCurrFxRateCalc unknown fix tag: %A"  x) 
    pos2, fld


let ReadNumDaysInterest (bs:byte[]) (pos:int): (int*NumDaysInterest) =
    ReadFieldInt bs pos NumDaysInterest.NumDaysInterest


let ReadAccruedInterestRate (bs:byte[]) (pos:int): (int*AccruedInterestRate) =
    ReadFieldDecimal bs pos AccruedInterestRate.AccruedInterestRate


let ReadAccruedInterestAmt (bs:byte[]) (pos:int): (int*AccruedInterestAmt) =
    ReadFieldDecimal bs pos AccruedInterestAmt.AccruedInterestAmt


let ReadSettlInstMode (bs:byte[]) (pos:int) : (int * SettlInstMode) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> SettlInstMode.Default
        |"1"B -> SettlInstMode.StandingInstructionsProvided
        |"4"B -> SettlInstMode.SpecificOrderForASingleAccount
        |"5"B -> SettlInstMode.RequestReject
        | x -> failwith (sprintf "ReadSettlInstMode unknown fix tag: %A"  x) 
    pos2, fld


let ReadAllocText (bs:byte[]) (pos:int): (int*AllocText) =
    ReadFieldStr bs pos AllocText.AllocText


let ReadSettlInstID (bs:byte[]) (pos:int): (int*SettlInstID) =
    ReadFieldStr bs pos SettlInstID.SettlInstID


let ReadSettlInstTransType (bs:byte[]) (pos:int) : (int * SettlInstTransType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"N"B -> SettlInstTransType.New
        |"C"B -> SettlInstTransType.Cancel
        |"R"B -> SettlInstTransType.Replace
        |"T"B -> SettlInstTransType.Restate
        | x -> failwith (sprintf "ReadSettlInstTransType unknown fix tag: %A"  x) 
    pos2, fld


let ReadEmailThreadID (bs:byte[]) (pos:int): (int*EmailThreadID) =
    ReadFieldStr bs pos EmailThreadID.EmailThreadID


let ReadSettlInstSource (bs:byte[]) (pos:int) : (int * SettlInstSource) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> SettlInstSource.BrokersInstructions
        |"2"B -> SettlInstSource.InstitutionsInstructions
        |"3"B -> SettlInstSource.Investor
        | x -> failwith (sprintf "ReadSettlInstSource unknown fix tag: %A"  x) 
    pos2, fld


let ReadSecurityType (bs:byte[]) (pos:int) : (int * SecurityType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadEffectiveTime (bs:byte[]) (pos:int): (int*EffectiveTime) =
    ReadFieldUTCTimestamp bs pos EffectiveTime.EffectiveTime


let ReadStandInstDbType (bs:byte[]) (pos:int) : (int * StandInstDbType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> StandInstDbType.Other
        |"1"B -> StandInstDbType.DtcSid
        |"2"B -> StandInstDbType.ThomsonAlert
        |"3"B -> StandInstDbType.AGlobalCustodian
        |"4"B -> StandInstDbType.Accountnet
        | x -> failwith (sprintf "ReadStandInstDbType unknown fix tag: %A"  x) 
    pos2, fld


let ReadStandInstDbName (bs:byte[]) (pos:int): (int*StandInstDbName) =
    ReadFieldStr bs pos StandInstDbName.StandInstDbName


let ReadStandInstDbID (bs:byte[]) (pos:int): (int*StandInstDbID) =
    ReadFieldStr bs pos StandInstDbID.StandInstDbID


let ReadSettlDeliveryType (bs:byte[]) (pos:int) : (int * SettlDeliveryType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> SettlDeliveryType.VersusPayment
        |"1"B -> SettlDeliveryType.Free
        |"2"B -> SettlDeliveryType.TriParty
        |"3"B -> SettlDeliveryType.HoldInCustody
        | x -> failwith (sprintf "ReadSettlDeliveryType unknown fix tag: %A"  x) 
    pos2, fld


let ReadBidSpotRate (bs:byte[]) (pos:int): (int*BidSpotRate) =
    ReadFieldDecimal bs pos BidSpotRate.BidSpotRate


let ReadBidForwardPoints (bs:byte[]) (pos:int): (int*BidForwardPoints) =
    ReadFieldDecimal bs pos BidForwardPoints.BidForwardPoints


let ReadOfferSpotRate (bs:byte[]) (pos:int): (int*OfferSpotRate) =
    ReadFieldDecimal bs pos OfferSpotRate.OfferSpotRate


let ReadOfferForwardPoints (bs:byte[]) (pos:int): (int*OfferForwardPoints) =
    ReadFieldDecimal bs pos OfferForwardPoints.OfferForwardPoints


let ReadOrderQty2 (bs:byte[]) (pos:int): (int*OrderQty2) =
    ReadFieldDecimal bs pos OrderQty2.OrderQty2


let ReadSettlDate2 (bs:byte[]) (pos:int): (int*SettlDate2) =
    ReadFieldLocalMktDate bs pos SettlDate2.SettlDate2


let ReadLastSpotRate (bs:byte[]) (pos:int): (int*LastSpotRate) =
    ReadFieldDecimal bs pos LastSpotRate.LastSpotRate


let ReadLastForwardPoints (bs:byte[]) (pos:int): (int*LastForwardPoints) =
    ReadFieldDecimal bs pos LastForwardPoints.LastForwardPoints


let ReadAllocLinkID (bs:byte[]) (pos:int): (int*AllocLinkID) =
    ReadFieldStr bs pos AllocLinkID.AllocLinkID


let ReadAllocLinkType (bs:byte[]) (pos:int) : (int * AllocLinkType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> AllocLinkType.FXNetting
        |"1"B -> AllocLinkType.FXSwap
        | x -> failwith (sprintf "ReadAllocLinkType unknown fix tag: %A"  x) 
    pos2, fld


let ReadSecondaryOrderID (bs:byte[]) (pos:int): (int*SecondaryOrderID) =
    ReadFieldStr bs pos SecondaryOrderID.SecondaryOrderID


let ReadNoIOIQualifiers (bs:byte[]) (pos:int): (int*NoIOIQualifiers) =
    ReadFieldInt bs pos NoIOIQualifiers.NoIOIQualifiers


let ReadMaturityMonthYear (bs:byte[]) (pos:int): (int*MaturityMonthYear) =
    ReadFieldMonthYear bs pos MaturityMonthYear.MaturityMonthYear


let ReadPutOrCall (bs:byte[]) (pos:int) : (int * PutOrCall) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> PutOrCall.Put
        |"1"B -> PutOrCall.Call
        | x -> failwith (sprintf "ReadPutOrCall unknown fix tag: %A"  x) 
    pos2, fld


let ReadStrikePrice (bs:byte[]) (pos:int): (int*StrikePrice) =
    ReadFieldDecimal bs pos StrikePrice.StrikePrice


let ReadCoveredOrUncovered (bs:byte[]) (pos:int) : (int * CoveredOrUncovered) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> CoveredOrUncovered.Covered
        |"1"B -> CoveredOrUncovered.Uncovered
        | x -> failwith (sprintf "ReadCoveredOrUncovered unknown fix tag: %A"  x) 
    pos2, fld


let ReadOptAttribute (bs:byte[]) (pos:int): (int*OptAttribute) =
    ReadFieldChar bs pos OptAttribute.OptAttribute


let ReadSecurityExchange (bs:byte[]) (pos:int): (int*SecurityExchange) =
    ReadFieldStr bs pos SecurityExchange.SecurityExchange


let ReadNotifyBrokerOfCredit (bs:byte[]) (pos:int): (int*NotifyBrokerOfCredit) =
    ReadFieldBool bs pos NotifyBrokerOfCredit.NotifyBrokerOfCredit


let ReadAllocHandlInst (bs:byte[]) (pos:int) : (int * AllocHandlInst) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> AllocHandlInst.Match
        |"2"B -> AllocHandlInst.Forward
        |"3"B -> AllocHandlInst.ForwardAndMatch
        | x -> failwith (sprintf "ReadAllocHandlInst unknown fix tag: %A"  x) 
    pos2, fld


let ReadMaxShow (bs:byte[]) (pos:int): (int*MaxShow) =
    ReadFieldDecimal bs pos MaxShow.MaxShow


let ReadPegOffsetValue (bs:byte[]) (pos:int): (int*PegOffsetValue) =
    ReadFieldDecimal bs pos PegOffsetValue.PegOffsetValue


// compound read
let ReadXmlData (bs:byte[]) (pos:int) : (int * XmlData) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "213"B XmlData.XmlData


let ReadSettlInstRefID (bs:byte[]) (pos:int): (int*SettlInstRefID) =
    ReadFieldStr bs pos SettlInstRefID.SettlInstRefID


let ReadNoRoutingIDs (bs:byte[]) (pos:int): (int*NoRoutingIDs) =
    ReadFieldInt bs pos NoRoutingIDs.NoRoutingIDs


let ReadRoutingType (bs:byte[]) (pos:int) : (int * RoutingType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> RoutingType.TargetFirm
        |"2"B -> RoutingType.TargetList
        |"3"B -> RoutingType.BlockFirm
        |"4"B -> RoutingType.BlockList
        | x -> failwith (sprintf "ReadRoutingType unknown fix tag: %A"  x) 
    pos2, fld


let ReadRoutingID (bs:byte[]) (pos:int): (int*RoutingID) =
    ReadFieldStr bs pos RoutingID.RoutingID


let ReadSpread (bs:byte[]) (pos:int): (int*Spread) =
    ReadFieldDecimal bs pos Spread.Spread


let ReadBenchmarkCurveCurrency (bs:byte[]) (pos:int): (int*BenchmarkCurveCurrency) =
    ReadFieldStr bs pos BenchmarkCurveCurrency.BenchmarkCurveCurrency


let ReadBenchmarkCurveName (bs:byte[]) (pos:int) : (int * BenchmarkCurveName) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadBenchmarkCurvePoint (bs:byte[]) (pos:int): (int*BenchmarkCurvePoint) =
    ReadFieldStr bs pos BenchmarkCurvePoint.BenchmarkCurvePoint


let ReadCouponRate (bs:byte[]) (pos:int): (int*CouponRate) =
    ReadFieldDecimal bs pos CouponRate.CouponRate


let ReadCouponPaymentDate (bs:byte[]) (pos:int): (int*CouponPaymentDate) =
    ReadFieldLocalMktDate bs pos CouponPaymentDate.CouponPaymentDate


let ReadIssueDate (bs:byte[]) (pos:int): (int*IssueDate) =
    ReadFieldLocalMktDate bs pos IssueDate.IssueDate


let ReadRepurchaseTerm (bs:byte[]) (pos:int): (int*RepurchaseTerm) =
    ReadFieldInt bs pos RepurchaseTerm.RepurchaseTerm


let ReadRepurchaseRate (bs:byte[]) (pos:int): (int*RepurchaseRate) =
    ReadFieldDecimal bs pos RepurchaseRate.RepurchaseRate


let ReadFactor (bs:byte[]) (pos:int): (int*Factor) =
    ReadFieldDecimal bs pos Factor.Factor


let ReadTradeOriginationDate (bs:byte[]) (pos:int): (int*TradeOriginationDate) =
    ReadFieldLocalMktDate bs pos TradeOriginationDate.TradeOriginationDate


let ReadExDate (bs:byte[]) (pos:int): (int*ExDate) =
    ReadFieldLocalMktDate bs pos ExDate.ExDate


let ReadContractMultiplier (bs:byte[]) (pos:int): (int*ContractMultiplier) =
    ReadFieldDecimal bs pos ContractMultiplier.ContractMultiplier


let ReadNoStipulations (bs:byte[]) (pos:int): (int*NoStipulations) =
    ReadFieldInt bs pos NoStipulations.NoStipulations


let ReadStipulationType (bs:byte[]) (pos:int) : (int * StipulationType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadStipulationValue (bs:byte[]) (pos:int) : (int * StipulationValue) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadYieldType (bs:byte[]) (pos:int) : (int * YieldType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadYield (bs:byte[]) (pos:int): (int*Yield) =
    ReadFieldDecimal bs pos Yield.Yield


let ReadTotalTakedown (bs:byte[]) (pos:int): (int*TotalTakedown) =
    ReadFieldDecimal bs pos TotalTakedown.TotalTakedown


let ReadConcession (bs:byte[]) (pos:int): (int*Concession) =
    ReadFieldDecimal bs pos Concession.Concession


let ReadRepoCollateralSecurityType (bs:byte[]) (pos:int): (int*RepoCollateralSecurityType) =
    ReadFieldInt bs pos RepoCollateralSecurityType.RepoCollateralSecurityType


let ReadRedemptionDate (bs:byte[]) (pos:int): (int*RedemptionDate) =
    ReadFieldLocalMktDate bs pos RedemptionDate.RedemptionDate


let ReadUnderlyingCouponPaymentDate (bs:byte[]) (pos:int): (int*UnderlyingCouponPaymentDate) =
    ReadFieldLocalMktDate bs pos UnderlyingCouponPaymentDate.UnderlyingCouponPaymentDate


let ReadUnderlyingIssueDate (bs:byte[]) (pos:int): (int*UnderlyingIssueDate) =
    ReadFieldLocalMktDate bs pos UnderlyingIssueDate.UnderlyingIssueDate


let ReadUnderlyingRepoCollateralSecurityType (bs:byte[]) (pos:int): (int*UnderlyingRepoCollateralSecurityType) =
    ReadFieldInt bs pos UnderlyingRepoCollateralSecurityType.UnderlyingRepoCollateralSecurityType


let ReadUnderlyingRepurchaseTerm (bs:byte[]) (pos:int): (int*UnderlyingRepurchaseTerm) =
    ReadFieldInt bs pos UnderlyingRepurchaseTerm.UnderlyingRepurchaseTerm


let ReadUnderlyingRepurchaseRate (bs:byte[]) (pos:int): (int*UnderlyingRepurchaseRate) =
    ReadFieldDecimal bs pos UnderlyingRepurchaseRate.UnderlyingRepurchaseRate


let ReadUnderlyingFactor (bs:byte[]) (pos:int): (int*UnderlyingFactor) =
    ReadFieldDecimal bs pos UnderlyingFactor.UnderlyingFactor


let ReadUnderlyingRedemptionDate (bs:byte[]) (pos:int): (int*UnderlyingRedemptionDate) =
    ReadFieldLocalMktDate bs pos UnderlyingRedemptionDate.UnderlyingRedemptionDate


let ReadLegCouponPaymentDate (bs:byte[]) (pos:int): (int*LegCouponPaymentDate) =
    ReadFieldLocalMktDate bs pos LegCouponPaymentDate.LegCouponPaymentDate


let ReadLegIssueDate (bs:byte[]) (pos:int): (int*LegIssueDate) =
    ReadFieldLocalMktDate bs pos LegIssueDate.LegIssueDate


let ReadLegRepoCollateralSecurityType (bs:byte[]) (pos:int): (int*LegRepoCollateralSecurityType) =
    ReadFieldInt bs pos LegRepoCollateralSecurityType.LegRepoCollateralSecurityType


let ReadLegRepurchaseTerm (bs:byte[]) (pos:int): (int*LegRepurchaseTerm) =
    ReadFieldInt bs pos LegRepurchaseTerm.LegRepurchaseTerm


let ReadLegRepurchaseRate (bs:byte[]) (pos:int): (int*LegRepurchaseRate) =
    ReadFieldDecimal bs pos LegRepurchaseRate.LegRepurchaseRate


let ReadLegFactor (bs:byte[]) (pos:int): (int*LegFactor) =
    ReadFieldDecimal bs pos LegFactor.LegFactor


let ReadLegRedemptionDate (bs:byte[]) (pos:int): (int*LegRedemptionDate) =
    ReadFieldLocalMktDate bs pos LegRedemptionDate.LegRedemptionDate


let ReadCreditRating (bs:byte[]) (pos:int): (int*CreditRating) =
    ReadFieldStr bs pos CreditRating.CreditRating


let ReadUnderlyingCreditRating (bs:byte[]) (pos:int): (int*UnderlyingCreditRating) =
    ReadFieldStr bs pos UnderlyingCreditRating.UnderlyingCreditRating


let ReadLegCreditRating (bs:byte[]) (pos:int): (int*LegCreditRating) =
    ReadFieldStr bs pos LegCreditRating.LegCreditRating


let ReadTradedFlatSwitch (bs:byte[]) (pos:int): (int*TradedFlatSwitch) =
    ReadFieldBool bs pos TradedFlatSwitch.TradedFlatSwitch


let ReadBasisFeatureDate (bs:byte[]) (pos:int): (int*BasisFeatureDate) =
    ReadFieldLocalMktDate bs pos BasisFeatureDate.BasisFeatureDate


let ReadBasisFeaturePrice (bs:byte[]) (pos:int): (int*BasisFeaturePrice) =
    ReadFieldDecimal bs pos BasisFeaturePrice.BasisFeaturePrice


let ReadMDReqID (bs:byte[]) (pos:int): (int*MDReqID) =
    ReadFieldStr bs pos MDReqID.MDReqID


let ReadSubscriptionRequestType (bs:byte[]) (pos:int) : (int * SubscriptionRequestType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> SubscriptionRequestType.Snapshot
        |"1"B -> SubscriptionRequestType.SnapshotPlusUpdates
        |"2"B -> SubscriptionRequestType.DisablePreviousSnapshotPlusUpdateRequest
        | x -> failwith (sprintf "ReadSubscriptionRequestType unknown fix tag: %A"  x) 
    pos2, fld


let ReadMarketDepth (bs:byte[]) (pos:int): (int*MarketDepth) =
    ReadFieldInt bs pos MarketDepth.MarketDepth


let ReadMDUpdateType (bs:byte[]) (pos:int) : (int * MDUpdateType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> MDUpdateType.FullRefresh
        |"1"B -> MDUpdateType.IncrementalRefresh
        | x -> failwith (sprintf "ReadMDUpdateType unknown fix tag: %A"  x) 
    pos2, fld


let ReadAggregatedBook (bs:byte[]) (pos:int): (int*AggregatedBook) =
    ReadFieldBool bs pos AggregatedBook.AggregatedBook


let ReadNoMDEntryTypes (bs:byte[]) (pos:int): (int*NoMDEntryTypes) =
    ReadFieldInt bs pos NoMDEntryTypes.NoMDEntryTypes


let ReadNoMDEntries (bs:byte[]) (pos:int): (int*NoMDEntries) =
    ReadFieldInt bs pos NoMDEntries.NoMDEntries


let ReadMDEntryType (bs:byte[]) (pos:int) : (int * MDEntryType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadMDEntryPx (bs:byte[]) (pos:int): (int*MDEntryPx) =
    ReadFieldDecimal bs pos MDEntryPx.MDEntryPx


let ReadMDEntrySize (bs:byte[]) (pos:int): (int*MDEntrySize) =
    ReadFieldDecimal bs pos MDEntrySize.MDEntrySize


let ReadMDEntryDate (bs:byte[]) (pos:int): (int*MDEntryDate) =
    ReadFieldUTCDate bs pos MDEntryDate.MDEntryDate


let ReadMDEntryTime (bs:byte[]) (pos:int): (int*MDEntryTime) =
    ReadFieldUTCTimeOnly bs pos MDEntryTime.MDEntryTime


let ReadTickDirection (bs:byte[]) (pos:int) : (int * TickDirection) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> TickDirection.PlusTick
        |"1"B -> TickDirection.ZeroPlusTick
        |"2"B -> TickDirection.MinusTick
        |"3"B -> TickDirection.ZeroMinusTick
        | x -> failwith (sprintf "ReadTickDirection unknown fix tag: %A"  x) 
    pos2, fld


let ReadMDMkt (bs:byte[]) (pos:int): (int*MDMkt) =
    ReadFieldStr bs pos MDMkt.MDMkt


let ReadQuoteCondition (bs:byte[]) (pos:int) : (int * QuoteCondition) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadTradeCondition (bs:byte[]) (pos:int) : (int * TradeCondition) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadMDEntryID (bs:byte[]) (pos:int): (int*MDEntryID) =
    ReadFieldStr bs pos MDEntryID.MDEntryID


let ReadMDUpdateAction (bs:byte[]) (pos:int) : (int * MDUpdateAction) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> MDUpdateAction.New
        |"1"B -> MDUpdateAction.Change
        |"2"B -> MDUpdateAction.Delete
        | x -> failwith (sprintf "ReadMDUpdateAction unknown fix tag: %A"  x) 
    pos2, fld


let ReadMDEntryRefID (bs:byte[]) (pos:int): (int*MDEntryRefID) =
    ReadFieldStr bs pos MDEntryRefID.MDEntryRefID


let ReadMDReqRejReason (bs:byte[]) (pos:int) : (int * MDReqRejReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadMDEntryOriginator (bs:byte[]) (pos:int): (int*MDEntryOriginator) =
    ReadFieldStr bs pos MDEntryOriginator.MDEntryOriginator


let ReadLocationID (bs:byte[]) (pos:int): (int*LocationID) =
    ReadFieldStr bs pos LocationID.LocationID


let ReadDeskID (bs:byte[]) (pos:int): (int*DeskID) =
    ReadFieldStr bs pos DeskID.DeskID


let ReadDeleteReason (bs:byte[]) (pos:int) : (int * DeleteReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> DeleteReason.CancelationTradeBust
        |"1"B -> DeleteReason.Error
        | x -> failwith (sprintf "ReadDeleteReason unknown fix tag: %A"  x) 
    pos2, fld


let ReadOpenCloseSettlFlag (bs:byte[]) (pos:int) : (int * OpenCloseSettlFlag) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> OpenCloseSettlFlag.DailyOpenCloseSettlementEntry
        |"1"B -> OpenCloseSettlFlag.SessionOpenCloseSettlementEntry
        |"2"B -> OpenCloseSettlFlag.DeliverySettlementEntry
        |"3"B -> OpenCloseSettlFlag.ExpectedEntry
        |"4"B -> OpenCloseSettlFlag.EntryFromPreviousBusinessDay
        |"5"B -> OpenCloseSettlFlag.TheoreticalPriceValue
        | x -> failwith (sprintf "ReadOpenCloseSettlFlag unknown fix tag: %A"  x) 
    pos2, fld


let ReadSellerDays (bs:byte[]) (pos:int): (int*SellerDays) =
    ReadFieldInt bs pos SellerDays.SellerDays


let ReadMDEntryBuyer (bs:byte[]) (pos:int): (int*MDEntryBuyer) =
    ReadFieldStr bs pos MDEntryBuyer.MDEntryBuyer


let ReadMDEntrySeller (bs:byte[]) (pos:int): (int*MDEntrySeller) =
    ReadFieldStr bs pos MDEntrySeller.MDEntrySeller


let ReadMDEntryPositionNo (bs:byte[]) (pos:int): (int*MDEntryPositionNo) =
    ReadFieldInt bs pos MDEntryPositionNo.MDEntryPositionNo


let ReadFinancialStatus (bs:byte[]) (pos:int) : (int * FinancialStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> FinancialStatus.Bankrupt
        |"2"B -> FinancialStatus.PendingDelisting
        | x -> failwith (sprintf "ReadFinancialStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadCorporateAction (bs:byte[]) (pos:int) : (int * CorporateAction) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"A"B -> CorporateAction.ExDividend
        |"B"B -> CorporateAction.ExDistribution
        |"C"B -> CorporateAction.ExRights
        |"D"B -> CorporateAction.New
        |"E"B -> CorporateAction.ExInterest
        | x -> failwith (sprintf "ReadCorporateAction unknown fix tag: %A"  x) 
    pos2, fld


let ReadDefBidSize (bs:byte[]) (pos:int): (int*DefBidSize) =
    ReadFieldDecimal bs pos DefBidSize.DefBidSize


let ReadDefOfferSize (bs:byte[]) (pos:int): (int*DefOfferSize) =
    ReadFieldDecimal bs pos DefOfferSize.DefOfferSize


let ReadNoQuoteEntries (bs:byte[]) (pos:int): (int*NoQuoteEntries) =
    ReadFieldInt bs pos NoQuoteEntries.NoQuoteEntries


let ReadNoQuoteSets (bs:byte[]) (pos:int): (int*NoQuoteSets) =
    ReadFieldInt bs pos NoQuoteSets.NoQuoteSets


let ReadQuoteStatus (bs:byte[]) (pos:int) : (int * QuoteStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadQuoteCancelType (bs:byte[]) (pos:int) : (int * QuoteCancelType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> QuoteCancelType.CancelForSymbol
        |"2"B -> QuoteCancelType.CancelForSecurityType
        |"3"B -> QuoteCancelType.CancelForUnderlyingSymbol
        |"4"B -> QuoteCancelType.CancelAllQuotes
        | x -> failwith (sprintf "ReadQuoteCancelType unknown fix tag: %A"  x) 
    pos2, fld


let ReadQuoteEntryID (bs:byte[]) (pos:int): (int*QuoteEntryID) =
    ReadFieldStr bs pos QuoteEntryID.QuoteEntryID


let ReadQuoteRejectReason (bs:byte[]) (pos:int) : (int * QuoteRejectReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadQuoteResponseLevel (bs:byte[]) (pos:int) : (int * QuoteResponseLevel) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> QuoteResponseLevel.NoAcknowledgement
        |"1"B -> QuoteResponseLevel.AcknowledgeOnlyNegativeOrErroneousQuotes
        |"2"B -> QuoteResponseLevel.AcknowledgeEachQuoteMessages
        | x -> failwith (sprintf "ReadQuoteResponseLevel unknown fix tag: %A"  x) 
    pos2, fld


let ReadQuoteSetID (bs:byte[]) (pos:int): (int*QuoteSetID) =
    ReadFieldStr bs pos QuoteSetID.QuoteSetID


let ReadQuoteRequestType (bs:byte[]) (pos:int) : (int * QuoteRequestType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> QuoteRequestType.Manual
        |"2"B -> QuoteRequestType.Automatic
        | x -> failwith (sprintf "ReadQuoteRequestType unknown fix tag: %A"  x) 
    pos2, fld


let ReadTotNoQuoteEntries (bs:byte[]) (pos:int): (int*TotNoQuoteEntries) =
    ReadFieldInt bs pos TotNoQuoteEntries.TotNoQuoteEntries


let ReadUnderlyingSecurityIDSource (bs:byte[]) (pos:int): (int*UnderlyingSecurityIDSource) =
    ReadFieldStr bs pos UnderlyingSecurityIDSource.UnderlyingSecurityIDSource


let ReadUnderlyingIssuer (bs:byte[]) (pos:int): (int*UnderlyingIssuer) =
    ReadFieldStr bs pos UnderlyingIssuer.UnderlyingIssuer


let ReadUnderlyingSecurityDesc (bs:byte[]) (pos:int): (int*UnderlyingSecurityDesc) =
    ReadFieldStr bs pos UnderlyingSecurityDesc.UnderlyingSecurityDesc


let ReadUnderlyingSecurityExchange (bs:byte[]) (pos:int): (int*UnderlyingSecurityExchange) =
    ReadFieldStr bs pos UnderlyingSecurityExchange.UnderlyingSecurityExchange


let ReadUnderlyingSecurityID (bs:byte[]) (pos:int): (int*UnderlyingSecurityID) =
    ReadFieldStr bs pos UnderlyingSecurityID.UnderlyingSecurityID


let ReadUnderlyingSecurityType (bs:byte[]) (pos:int): (int*UnderlyingSecurityType) =
    ReadFieldStr bs pos UnderlyingSecurityType.UnderlyingSecurityType


let ReadUnderlyingSymbol (bs:byte[]) (pos:int): (int*UnderlyingSymbol) =
    ReadFieldStr bs pos UnderlyingSymbol.UnderlyingSymbol


let ReadUnderlyingSymbolSfx (bs:byte[]) (pos:int): (int*UnderlyingSymbolSfx) =
    ReadFieldStr bs pos UnderlyingSymbolSfx.UnderlyingSymbolSfx


let ReadUnderlyingMaturityMonthYear (bs:byte[]) (pos:int): (int*UnderlyingMaturityMonthYear) =
    ReadFieldMonthYear bs pos UnderlyingMaturityMonthYear.UnderlyingMaturityMonthYear


let ReadUnderlyingPutOrCall (bs:byte[]) (pos:int) : (int * UnderlyingPutOrCall) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> UnderlyingPutOrCall.Put
        |"1"B -> UnderlyingPutOrCall.Call
        | x -> failwith (sprintf "ReadUnderlyingPutOrCall unknown fix tag: %A"  x) 
    pos2, fld


let ReadUnderlyingStrikePrice (bs:byte[]) (pos:int): (int*UnderlyingStrikePrice) =
    ReadFieldDecimal bs pos UnderlyingStrikePrice.UnderlyingStrikePrice


let ReadUnderlyingOptAttribute (bs:byte[]) (pos:int): (int*UnderlyingOptAttribute) =
    ReadFieldChar bs pos UnderlyingOptAttribute.UnderlyingOptAttribute


let ReadUnderlyingCurrency (bs:byte[]) (pos:int): (int*UnderlyingCurrency) =
    ReadFieldStr bs pos UnderlyingCurrency.UnderlyingCurrency


let ReadSecurityReqID (bs:byte[]) (pos:int): (int*SecurityReqID) =
    ReadFieldStr bs pos SecurityReqID.SecurityReqID


let ReadSecurityRequestType (bs:byte[]) (pos:int) : (int * SecurityRequestType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> SecurityRequestType.RequestSecurityIdentityAndSpecifications
        |"1"B -> SecurityRequestType.RequestSecurityIdentityForTheSpecificationsProvided
        |"2"B -> SecurityRequestType.RequestListSecurityTypes
        |"3"B -> SecurityRequestType.RequestListSecurities
        | x -> failwith (sprintf "ReadSecurityRequestType unknown fix tag: %A"  x) 
    pos2, fld


let ReadSecurityResponseID (bs:byte[]) (pos:int): (int*SecurityResponseID) =
    ReadFieldStr bs pos SecurityResponseID.SecurityResponseID


let ReadSecurityResponseType (bs:byte[]) (pos:int) : (int * SecurityResponseType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> SecurityResponseType.AcceptSecurityProposalAsIs
        |"2"B -> SecurityResponseType.AcceptSecurityProposalWithRevisionsAsIndicatedInTheMessage
        |"3"B -> SecurityResponseType.ListOfSecurityTypesReturnedPerRequest
        |"4"B -> SecurityResponseType.ListOfSecuritiesReturnedPerRequest
        |"5"B -> SecurityResponseType.RejectSecurityProposal
        |"6"B -> SecurityResponseType.CanNotMatchSelectionCriteria
        | x -> failwith (sprintf "ReadSecurityResponseType unknown fix tag: %A"  x) 
    pos2, fld


let ReadSecurityStatusReqID (bs:byte[]) (pos:int): (int*SecurityStatusReqID) =
    ReadFieldStr bs pos SecurityStatusReqID.SecurityStatusReqID


let ReadUnsolicitedIndicator (bs:byte[]) (pos:int): (int*UnsolicitedIndicator) =
    ReadFieldBool bs pos UnsolicitedIndicator.UnsolicitedIndicator


let ReadSecurityTradingStatus (bs:byte[]) (pos:int) : (int * SecurityTradingStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadHaltReason (bs:byte[]) (pos:int) : (int * HaltReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"I"B -> HaltReason.OrderImbalance
        |"X"B -> HaltReason.EquipmentChangeover
        |"P"B -> HaltReason.NewsPending
        |"D"B -> HaltReason.NewsDissemination
        |"E"B -> HaltReason.OrderInflux
        |"M"B -> HaltReason.AdditionalInformation
        | x -> failwith (sprintf "ReadHaltReason unknown fix tag: %A"  x) 
    pos2, fld


let ReadInViewOfCommon (bs:byte[]) (pos:int): (int*InViewOfCommon) =
    ReadFieldBool bs pos InViewOfCommon.InViewOfCommon


let ReadDueToRelated (bs:byte[]) (pos:int): (int*DueToRelated) =
    ReadFieldBool bs pos DueToRelated.DueToRelated


let ReadBuyVolume (bs:byte[]) (pos:int): (int*BuyVolume) =
    ReadFieldDecimal bs pos BuyVolume.BuyVolume


let ReadSellVolume (bs:byte[]) (pos:int): (int*SellVolume) =
    ReadFieldDecimal bs pos SellVolume.SellVolume


let ReadHighPx (bs:byte[]) (pos:int): (int*HighPx) =
    ReadFieldDecimal bs pos HighPx.HighPx


let ReadLowPx (bs:byte[]) (pos:int): (int*LowPx) =
    ReadFieldDecimal bs pos LowPx.LowPx


let ReadAdjustment (bs:byte[]) (pos:int) : (int * Adjustment) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> Adjustment.Cancel
        |"2"B -> Adjustment.Error
        |"3"B -> Adjustment.Correction
        | x -> failwith (sprintf "ReadAdjustment unknown fix tag: %A"  x) 
    pos2, fld


let ReadTradSesReqID (bs:byte[]) (pos:int): (int*TradSesReqID) =
    ReadFieldStr bs pos TradSesReqID.TradSesReqID


let ReadTradingSessionID (bs:byte[]) (pos:int): (int*TradingSessionID) =
    ReadFieldStr bs pos TradingSessionID.TradingSessionID


let ReadContraTrader (bs:byte[]) (pos:int): (int*ContraTrader) =
    ReadFieldStr bs pos ContraTrader.ContraTrader


let ReadTradSesMethod (bs:byte[]) (pos:int) : (int * TradSesMethod) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> TradSesMethod.Electronic
        |"2"B -> TradSesMethod.OpenOutcry
        |"3"B -> TradSesMethod.TwoParty
        | x -> failwith (sprintf "ReadTradSesMethod unknown fix tag: %A"  x) 
    pos2, fld


let ReadTradSesMode (bs:byte[]) (pos:int) : (int * TradSesMode) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> TradSesMode.Testing
        |"2"B -> TradSesMode.Simulated
        |"3"B -> TradSesMode.Production
        | x -> failwith (sprintf "ReadTradSesMode unknown fix tag: %A"  x) 
    pos2, fld


let ReadTradSesStatus (bs:byte[]) (pos:int) : (int * TradSesStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadTradSesStartTime (bs:byte[]) (pos:int): (int*TradSesStartTime) =
    ReadFieldUTCTimestamp bs pos TradSesStartTime.TradSesStartTime


let ReadTradSesOpenTime (bs:byte[]) (pos:int): (int*TradSesOpenTime) =
    ReadFieldUTCTimestamp bs pos TradSesOpenTime.TradSesOpenTime


let ReadTradSesPreCloseTime (bs:byte[]) (pos:int): (int*TradSesPreCloseTime) =
    ReadFieldUTCTimestamp bs pos TradSesPreCloseTime.TradSesPreCloseTime


let ReadTradSesCloseTime (bs:byte[]) (pos:int): (int*TradSesCloseTime) =
    ReadFieldUTCTimestamp bs pos TradSesCloseTime.TradSesCloseTime


let ReadTradSesEndTime (bs:byte[]) (pos:int): (int*TradSesEndTime) =
    ReadFieldUTCTimestamp bs pos TradSesEndTime.TradSesEndTime


let ReadNumberOfOrders (bs:byte[]) (pos:int): (int*NumberOfOrders) =
    ReadFieldInt bs pos NumberOfOrders.NumberOfOrders


let ReadMessageEncoding (bs:byte[]) (pos:int) : (int * MessageEncoding) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"ISO-2022-JP"B -> MessageEncoding.Iso2022Jp
        |"EUC-JP"B -> MessageEncoding.EucJp
        |"SHIFT_JIS"B -> MessageEncoding.ShiftJis
        |"UTF-8"B -> MessageEncoding.Utf8
        | x -> failwith (sprintf "ReadMessageEncoding unknown fix tag: %A"  x) 
    pos2, fld


// compound read
let ReadEncodedIssuer (bs:byte[]) (pos:int) : (int * EncodedIssuer) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "349"B EncodedIssuer.EncodedIssuer


// compound read
let ReadEncodedSecurityDesc (bs:byte[]) (pos:int) : (int * EncodedSecurityDesc) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "351"B EncodedSecurityDesc.EncodedSecurityDesc


// compound read
let ReadEncodedListExecInst (bs:byte[]) (pos:int) : (int * EncodedListExecInst) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "353"B EncodedListExecInst.EncodedListExecInst


// compound read
let ReadEncodedText (bs:byte[]) (pos:int) : (int * EncodedText) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "355"B EncodedText.EncodedText


// compound read
let ReadEncodedSubject (bs:byte[]) (pos:int) : (int * EncodedSubject) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "357"B EncodedSubject.EncodedSubject


// compound read
let ReadEncodedHeadline (bs:byte[]) (pos:int) : (int * EncodedHeadline) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "359"B EncodedHeadline.EncodedHeadline


// compound read
let ReadEncodedAllocText (bs:byte[]) (pos:int) : (int * EncodedAllocText) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "361"B EncodedAllocText.EncodedAllocText


// compound read
let ReadEncodedUnderlyingIssuer (bs:byte[]) (pos:int) : (int * EncodedUnderlyingIssuer) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "363"B EncodedUnderlyingIssuer.EncodedUnderlyingIssuer


// compound read
let ReadEncodedUnderlyingSecurityDesc (bs:byte[]) (pos:int) : (int * EncodedUnderlyingSecurityDesc) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "365"B EncodedUnderlyingSecurityDesc.EncodedUnderlyingSecurityDesc


let ReadAllocPrice (bs:byte[]) (pos:int): (int*AllocPrice) =
    ReadFieldDecimal bs pos AllocPrice.AllocPrice


let ReadQuoteSetValidUntilTime (bs:byte[]) (pos:int): (int*QuoteSetValidUntilTime) =
    ReadFieldUTCTimestamp bs pos QuoteSetValidUntilTime.QuoteSetValidUntilTime


let ReadQuoteEntryRejectReason (bs:byte[]) (pos:int) : (int * QuoteEntryRejectReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadLastMsgSeqNumProcessed (bs:byte[]) (pos:int): (int*LastMsgSeqNumProcessed) =
    ReadFieldUint32 bs pos LastMsgSeqNumProcessed.LastMsgSeqNumProcessed


let ReadRefTagID (bs:byte[]) (pos:int): (int*RefTagID) =
    ReadFieldInt bs pos RefTagID.RefTagID


let ReadRefMsgType (bs:byte[]) (pos:int): (int*RefMsgType) =
    ReadFieldStr bs pos RefMsgType.RefMsgType


let ReadSessionRejectReason (bs:byte[]) (pos:int) : (int * SessionRejectReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadBidRequestTransType (bs:byte[]) (pos:int) : (int * BidRequestTransType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"N"B -> BidRequestTransType.New
        |"C"B -> BidRequestTransType.Cancel
        | x -> failwith (sprintf "ReadBidRequestTransType unknown fix tag: %A"  x) 
    pos2, fld


let ReadContraBroker (bs:byte[]) (pos:int): (int*ContraBroker) =
    ReadFieldStr bs pos ContraBroker.ContraBroker


let ReadComplianceID (bs:byte[]) (pos:int): (int*ComplianceID) =
    ReadFieldStr bs pos ComplianceID.ComplianceID


let ReadSolicitedFlag (bs:byte[]) (pos:int): (int*SolicitedFlag) =
    ReadFieldBool bs pos SolicitedFlag.SolicitedFlag


let ReadExecRestatementReason (bs:byte[]) (pos:int) : (int * ExecRestatementReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadBusinessRejectRefID (bs:byte[]) (pos:int): (int*BusinessRejectRefID) =
    ReadFieldStr bs pos BusinessRejectRefID.BusinessRejectRefID


let ReadBusinessRejectReason (bs:byte[]) (pos:int) : (int * BusinessRejectReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadGrossTradeAmt (bs:byte[]) (pos:int): (int*GrossTradeAmt) =
    ReadFieldDecimal bs pos GrossTradeAmt.GrossTradeAmt


let ReadNoContraBrokers (bs:byte[]) (pos:int): (int*NoContraBrokers) =
    ReadFieldInt bs pos NoContraBrokers.NoContraBrokers


let ReadMaxMessageSize (bs:byte[]) (pos:int): (int*MaxMessageSize) =
    ReadFieldUint32 bs pos MaxMessageSize.MaxMessageSize


let ReadNoMsgTypes (bs:byte[]) (pos:int): (int*NoMsgTypes) =
    ReadFieldInt bs pos NoMsgTypes.NoMsgTypes


let ReadMsgDirection (bs:byte[]) (pos:int) : (int * MsgDirection) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"S"B -> MsgDirection.Send
        |"R"B -> MsgDirection.Receive
        | x -> failwith (sprintf "ReadMsgDirection unknown fix tag: %A"  x) 
    pos2, fld


let ReadNoTradingSessions (bs:byte[]) (pos:int): (int*NoTradingSessions) =
    ReadFieldInt bs pos NoTradingSessions.NoTradingSessions


let ReadTotalVolumeTraded (bs:byte[]) (pos:int): (int*TotalVolumeTraded) =
    ReadFieldDecimal bs pos TotalVolumeTraded.TotalVolumeTraded


let ReadDiscretionInst (bs:byte[]) (pos:int) : (int * DiscretionInst) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadDiscretionOffsetValue (bs:byte[]) (pos:int): (int*DiscretionOffsetValue) =
    ReadFieldDecimal bs pos DiscretionOffsetValue.DiscretionOffsetValue


let ReadBidID (bs:byte[]) (pos:int): (int*BidID) =
    ReadFieldStr bs pos BidID.BidID


let ReadClientBidID (bs:byte[]) (pos:int): (int*ClientBidID) =
    ReadFieldStr bs pos ClientBidID.ClientBidID


let ReadListName (bs:byte[]) (pos:int): (int*ListName) =
    ReadFieldStr bs pos ListName.ListName


let ReadTotNoRelatedSym (bs:byte[]) (pos:int): (int*TotNoRelatedSym) =
    ReadFieldInt bs pos TotNoRelatedSym.TotNoRelatedSym


let ReadBidType (bs:byte[]) (pos:int) : (int * BidType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> BidType.NonDisclosed
        |"2"B -> BidType.DisclosedStyle
        |"3"B -> BidType.NoBiddingProcess
        | x -> failwith (sprintf "ReadBidType unknown fix tag: %A"  x) 
    pos2, fld


let ReadNumTickets (bs:byte[]) (pos:int): (int*NumTickets) =
    ReadFieldInt bs pos NumTickets.NumTickets


let ReadSideValue1 (bs:byte[]) (pos:int): (int*SideValue1) =
    ReadFieldDecimal bs pos SideValue1.SideValue1


let ReadSideValue2 (bs:byte[]) (pos:int): (int*SideValue2) =
    ReadFieldDecimal bs pos SideValue2.SideValue2


let ReadNoBidDescriptors (bs:byte[]) (pos:int): (int*NoBidDescriptors) =
    ReadFieldInt bs pos NoBidDescriptors.NoBidDescriptors


let ReadBidDescriptorType (bs:byte[]) (pos:int) : (int * BidDescriptorType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> BidDescriptorType.Sector
        |"2"B -> BidDescriptorType.Ccountry
        |"3"B -> BidDescriptorType.Index
        | x -> failwith (sprintf "ReadBidDescriptorType unknown fix tag: %A"  x) 
    pos2, fld


let ReadBidDescriptor (bs:byte[]) (pos:int): (int*BidDescriptor) =
    ReadFieldStr bs pos BidDescriptor.BidDescriptor


let ReadSideValueInd (bs:byte[]) (pos:int) : (int * SideValueInd) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> SideValueInd.Sidevalue1
        |"2"B -> SideValueInd.Sidevalue2
        | x -> failwith (sprintf "ReadSideValueInd unknown fix tag: %A"  x) 
    pos2, fld


let ReadLiquidityPctLow (bs:byte[]) (pos:int): (int*LiquidityPctLow) =
    ReadFieldDecimal bs pos LiquidityPctLow.LiquidityPctLow


let ReadLiquidityPctHigh (bs:byte[]) (pos:int): (int*LiquidityPctHigh) =
    ReadFieldDecimal bs pos LiquidityPctHigh.LiquidityPctHigh


let ReadLiquidityValue (bs:byte[]) (pos:int): (int*LiquidityValue) =
    ReadFieldDecimal bs pos LiquidityValue.LiquidityValue


let ReadEFPTrackingError (bs:byte[]) (pos:int): (int*EFPTrackingError) =
    ReadFieldDecimal bs pos EFPTrackingError.EFPTrackingError


let ReadFairValue (bs:byte[]) (pos:int): (int*FairValue) =
    ReadFieldDecimal bs pos FairValue.FairValue


let ReadOutsideIndexPct (bs:byte[]) (pos:int): (int*OutsideIndexPct) =
    ReadFieldDecimal bs pos OutsideIndexPct.OutsideIndexPct


let ReadValueOfFutures (bs:byte[]) (pos:int): (int*ValueOfFutures) =
    ReadFieldDecimal bs pos ValueOfFutures.ValueOfFutures


let ReadLiquidityIndType (bs:byte[]) (pos:int) : (int * LiquidityIndType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> LiquidityIndType.FivedayMovingAverage
        |"2"B -> LiquidityIndType.TwentydayMovingAverage
        |"3"B -> LiquidityIndType.NormalMarketSize
        |"4"B -> LiquidityIndType.Other
        | x -> failwith (sprintf "ReadLiquidityIndType unknown fix tag: %A"  x) 
    pos2, fld


let ReadWtAverageLiquidity (bs:byte[]) (pos:int): (int*WtAverageLiquidity) =
    ReadFieldDecimal bs pos WtAverageLiquidity.WtAverageLiquidity


let ReadExchangeForPhysical (bs:byte[]) (pos:int): (int*ExchangeForPhysical) =
    ReadFieldBool bs pos ExchangeForPhysical.ExchangeForPhysical


let ReadOutMainCntryUIndex (bs:byte[]) (pos:int): (int*OutMainCntryUIndex) =
    ReadFieldDecimal bs pos OutMainCntryUIndex.OutMainCntryUIndex


let ReadCrossPercent (bs:byte[]) (pos:int): (int*CrossPercent) =
    ReadFieldDecimal bs pos CrossPercent.CrossPercent


let ReadProgRptReqs (bs:byte[]) (pos:int) : (int * ProgRptReqs) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> ProgRptReqs.BuysideExplicitlyRequestsStatusUsingStatusrequest
        |"2"B -> ProgRptReqs.SellsidePeriodicallySendsStatusUsingListstatus
        |"3"B -> ProgRptReqs.RealTimeExecutionReports
        | x -> failwith (sprintf "ReadProgRptReqs unknown fix tag: %A"  x) 
    pos2, fld


let ReadProgPeriodInterval (bs:byte[]) (pos:int): (int*ProgPeriodInterval) =
    ReadFieldInt bs pos ProgPeriodInterval.ProgPeriodInterval


let ReadIncTaxInd (bs:byte[]) (pos:int) : (int * IncTaxInd) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> IncTaxInd.Net
        |"2"B -> IncTaxInd.Gross
        | x -> failwith (sprintf "ReadIncTaxInd unknown fix tag: %A"  x) 
    pos2, fld


let ReadNumBidders (bs:byte[]) (pos:int): (int*NumBidders) =
    ReadFieldInt bs pos NumBidders.NumBidders


let ReadBidTradeType (bs:byte[]) (pos:int) : (int * BidTradeType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"R"B -> BidTradeType.RiskTrade
        |"G"B -> BidTradeType.VwapGuarantee
        |"A"B -> BidTradeType.Agency
        |"J"B -> BidTradeType.GuaranteedClose
        | x -> failwith (sprintf "ReadBidTradeType unknown fix tag: %A"  x) 
    pos2, fld


let ReadBasisPxType (bs:byte[]) (pos:int) : (int * BasisPxType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadNoBidComponents (bs:byte[]) (pos:int): (int*NoBidComponents) =
    ReadFieldInt bs pos NoBidComponents.NoBidComponents


let ReadCountry (bs:byte[]) (pos:int): (int*Country) =
    ReadFieldStr bs pos Country.Country


let ReadTotNoStrikes (bs:byte[]) (pos:int): (int*TotNoStrikes) =
    ReadFieldInt bs pos TotNoStrikes.TotNoStrikes


let ReadPriceType (bs:byte[]) (pos:int) : (int * PriceType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadDayOrderQty (bs:byte[]) (pos:int): (int*DayOrderQty) =
    ReadFieldDecimal bs pos DayOrderQty.DayOrderQty


let ReadDayCumQty (bs:byte[]) (pos:int): (int*DayCumQty) =
    ReadFieldDecimal bs pos DayCumQty.DayCumQty


let ReadDayAvgPx (bs:byte[]) (pos:int): (int*DayAvgPx) =
    ReadFieldDecimal bs pos DayAvgPx.DayAvgPx


let ReadGTBookingInst (bs:byte[]) (pos:int) : (int * GTBookingInst) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> GTBookingInst.BookOutAllTradesOnDayOfExecution
        |"1"B -> GTBookingInst.AccumulateExecutionsUntilOrderIsFilledOrExpires
        |"2"B -> GTBookingInst.AccumulateUntilVerballyNotifiedOtherwise
        | x -> failwith (sprintf "ReadGTBookingInst unknown fix tag: %A"  x) 
    pos2, fld


let ReadNoStrikes (bs:byte[]) (pos:int): (int*NoStrikes) =
    ReadFieldInt bs pos NoStrikes.NoStrikes


let ReadListStatusType (bs:byte[]) (pos:int) : (int * ListStatusType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> ListStatusType.Ack
        |"2"B -> ListStatusType.Response
        |"3"B -> ListStatusType.Timed
        |"4"B -> ListStatusType.Execstarted
        |"5"B -> ListStatusType.Alldone
        |"6"B -> ListStatusType.Alert
        | x -> failwith (sprintf "ReadListStatusType unknown fix tag: %A"  x) 
    pos2, fld


let ReadNetGrossInd (bs:byte[]) (pos:int) : (int * NetGrossInd) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> NetGrossInd.Net
        |"2"B -> NetGrossInd.Gross
        | x -> failwith (sprintf "ReadNetGrossInd unknown fix tag: %A"  x) 
    pos2, fld


let ReadListOrderStatus (bs:byte[]) (pos:int) : (int * ListOrderStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadExpireDate (bs:byte[]) (pos:int): (int*ExpireDate) =
    ReadFieldLocalMktDate bs pos ExpireDate.ExpireDate


let ReadListExecInstType (bs:byte[]) (pos:int) : (int * ListExecInstType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> ListExecInstType.Immediate
        |"2"B -> ListExecInstType.WaitForExecuteInstruction
        |"3"B -> ListExecInstType.ExchangeSwitchCivOrderSellDriven
        |"4"B -> ListExecInstType.ExchangeSwitchCivOrderBuyDrivenCashTopUp
        |"5"B -> ListExecInstType.ExchangeSwitchCivOrderBuyDrivenCashWithdraw
        | x -> failwith (sprintf "ReadListExecInstType unknown fix tag: %A"  x) 
    pos2, fld


let ReadCxlRejResponseTo (bs:byte[]) (pos:int) : (int * CxlRejResponseTo) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> CxlRejResponseTo.OrderCancelRequest
        |"2"B -> CxlRejResponseTo.OrderCancelReplaceRequest
        | x -> failwith (sprintf "ReadCxlRejResponseTo unknown fix tag: %A"  x) 
    pos2, fld


let ReadUnderlyingCouponRate (bs:byte[]) (pos:int): (int*UnderlyingCouponRate) =
    ReadFieldDecimal bs pos UnderlyingCouponRate.UnderlyingCouponRate


let ReadUnderlyingContractMultiplier (bs:byte[]) (pos:int): (int*UnderlyingContractMultiplier) =
    ReadFieldDecimal bs pos UnderlyingContractMultiplier.UnderlyingContractMultiplier


let ReadContraTradeQty (bs:byte[]) (pos:int): (int*ContraTradeQty) =
    ReadFieldDecimal bs pos ContraTradeQty.ContraTradeQty


let ReadContraTradeTime (bs:byte[]) (pos:int): (int*ContraTradeTime) =
    ReadFieldUTCTimestamp bs pos ContraTradeTime.ContraTradeTime


let ReadLiquidityNumSecurities (bs:byte[]) (pos:int): (int*LiquidityNumSecurities) =
    ReadFieldInt bs pos LiquidityNumSecurities.LiquidityNumSecurities


let ReadMultiLegReportingType (bs:byte[]) (pos:int) : (int * MultiLegReportingType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> MultiLegReportingType.SingleSecurity
        |"2"B -> MultiLegReportingType.IndividualLegOfAMultiLegSecurity
        |"3"B -> MultiLegReportingType.MultiLegSecurity
        | x -> failwith (sprintf "ReadMultiLegReportingType unknown fix tag: %A"  x) 
    pos2, fld


let ReadStrikeTime (bs:byte[]) (pos:int): (int*StrikeTime) =
    ReadFieldUTCTimestamp bs pos StrikeTime.StrikeTime


let ReadListStatusText (bs:byte[]) (pos:int): (int*ListStatusText) =
    ReadFieldStr bs pos ListStatusText.ListStatusText


// compound read
let ReadEncodedListStatusText (bs:byte[]) (pos:int) : (int * EncodedListStatusText) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "446"B EncodedListStatusText.EncodedListStatusText


let ReadPartyIDSource (bs:byte[]) (pos:int) : (int * PartyIDSource) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadPartyID (bs:byte[]) (pos:int): (int*PartyID) =
    ReadFieldStr bs pos PartyID.PartyID


let ReadNetChgPrevDay (bs:byte[]) (pos:int): (int*NetChgPrevDay) =
    ReadFieldDecimal bs pos NetChgPrevDay.NetChgPrevDay


let ReadPartyRole (bs:byte[]) (pos:int) : (int * PartyRole) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadNoPartyIDs (bs:byte[]) (pos:int): (int*NoPartyIDs) =
    ReadFieldInt bs pos NoPartyIDs.NoPartyIDs


let ReadNoSecurityAltID (bs:byte[]) (pos:int): (int*NoSecurityAltID) =
    ReadFieldInt bs pos NoSecurityAltID.NoSecurityAltID


let ReadSecurityAltID (bs:byte[]) (pos:int): (int*SecurityAltID) =
    ReadFieldStr bs pos SecurityAltID.SecurityAltID


let ReadSecurityAltIDSource (bs:byte[]) (pos:int): (int*SecurityAltIDSource) =
    ReadFieldStr bs pos SecurityAltIDSource.SecurityAltIDSource


let ReadNoUnderlyingSecurityAltID (bs:byte[]) (pos:int): (int*NoUnderlyingSecurityAltID) =
    ReadFieldInt bs pos NoUnderlyingSecurityAltID.NoUnderlyingSecurityAltID


let ReadUnderlyingSecurityAltID (bs:byte[]) (pos:int): (int*UnderlyingSecurityAltID) =
    ReadFieldStr bs pos UnderlyingSecurityAltID.UnderlyingSecurityAltID


let ReadUnderlyingSecurityAltIDSource (bs:byte[]) (pos:int): (int*UnderlyingSecurityAltIDSource) =
    ReadFieldStr bs pos UnderlyingSecurityAltIDSource.UnderlyingSecurityAltIDSource


let ReadProduct (bs:byte[]) (pos:int) : (int * Product) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadCFICode (bs:byte[]) (pos:int): (int*CFICode) =
    ReadFieldStr bs pos CFICode.CFICode


let ReadUnderlyingProduct (bs:byte[]) (pos:int): (int*UnderlyingProduct) =
    ReadFieldInt bs pos UnderlyingProduct.UnderlyingProduct


let ReadUnderlyingCFICode (bs:byte[]) (pos:int): (int*UnderlyingCFICode) =
    ReadFieldStr bs pos UnderlyingCFICode.UnderlyingCFICode


let ReadTestMessageIndicator (bs:byte[]) (pos:int): (int*TestMessageIndicator) =
    ReadFieldBool bs pos TestMessageIndicator.TestMessageIndicator


let ReadQuantityType (bs:byte[]) (pos:int) : (int * QuantityType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadBookingRefID (bs:byte[]) (pos:int): (int*BookingRefID) =
    ReadFieldStr bs pos BookingRefID.BookingRefID


let ReadIndividualAllocID (bs:byte[]) (pos:int): (int*IndividualAllocID) =
    ReadFieldStr bs pos IndividualAllocID.IndividualAllocID


let ReadRoundingDirection (bs:byte[]) (pos:int) : (int * RoundingDirection) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> RoundingDirection.RoundToNearest
        |"1"B -> RoundingDirection.RoundDown
        |"2"B -> RoundingDirection.RoundUp
        | x -> failwith (sprintf "ReadRoundingDirection unknown fix tag: %A"  x) 
    pos2, fld


let ReadRoundingModulus (bs:byte[]) (pos:int): (int*RoundingModulus) =
    ReadFieldDecimal bs pos RoundingModulus.RoundingModulus


let ReadCountryOfIssue (bs:byte[]) (pos:int): (int*CountryOfIssue) =
    ReadFieldStr bs pos CountryOfIssue.CountryOfIssue


let ReadStateOrProvinceOfIssue (bs:byte[]) (pos:int): (int*StateOrProvinceOfIssue) =
    ReadFieldStr bs pos StateOrProvinceOfIssue.StateOrProvinceOfIssue


let ReadLocaleOfIssue (bs:byte[]) (pos:int): (int*LocaleOfIssue) =
    ReadFieldStr bs pos LocaleOfIssue.LocaleOfIssue


let ReadNoRegistDtls (bs:byte[]) (pos:int): (int*NoRegistDtls) =
    ReadFieldInt bs pos NoRegistDtls.NoRegistDtls


let ReadMailingDtls (bs:byte[]) (pos:int): (int*MailingDtls) =
    ReadFieldStr bs pos MailingDtls.MailingDtls


let ReadInvestorCountryOfResidence (bs:byte[]) (pos:int): (int*InvestorCountryOfResidence) =
    ReadFieldStr bs pos InvestorCountryOfResidence.InvestorCountryOfResidence


let ReadPaymentRef (bs:byte[]) (pos:int): (int*PaymentRef) =
    ReadFieldStr bs pos PaymentRef.PaymentRef


let ReadDistribPaymentMethod (bs:byte[]) (pos:int) : (int * DistribPaymentMethod) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadCashDistribCurr (bs:byte[]) (pos:int): (int*CashDistribCurr) =
    ReadFieldStr bs pos CashDistribCurr.CashDistribCurr


let ReadCommCurrency (bs:byte[]) (pos:int): (int*CommCurrency) =
    ReadFieldStr bs pos CommCurrency.CommCurrency


let ReadCancellationRights (bs:byte[]) (pos:int) : (int * CancellationRights) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"Y"B -> CancellationRights.Yes
        |"N"B -> CancellationRights.NoExecutionOnly
        |"M"B -> CancellationRights.NoWaiverAgreement
        |"O"B -> CancellationRights.NoInstitutional
        | x -> failwith (sprintf "ReadCancellationRights unknown fix tag: %A"  x) 
    pos2, fld


let ReadMoneyLaunderingStatus (bs:byte[]) (pos:int) : (int * MoneyLaunderingStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"Y"B -> MoneyLaunderingStatus.Passed
        |"N"B -> MoneyLaunderingStatus.NotChecked
        |"1"B -> MoneyLaunderingStatus.ExemptBelowTheLimit
        |"2"B -> MoneyLaunderingStatus.ExemptClientMoneyTypeExemption
        |"3"B -> MoneyLaunderingStatus.ExemptAuthorisedCreditOrFinancialInstitution
        | x -> failwith (sprintf "ReadMoneyLaunderingStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadMailingInst (bs:byte[]) (pos:int): (int*MailingInst) =
    ReadFieldStr bs pos MailingInst.MailingInst


let ReadTransBkdTime (bs:byte[]) (pos:int): (int*TransBkdTime) =
    ReadFieldUTCTimestamp bs pos TransBkdTime.TransBkdTime


let ReadExecPriceType (bs:byte[]) (pos:int) : (int * ExecPriceType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadExecPriceAdjustment (bs:byte[]) (pos:int): (int*ExecPriceAdjustment) =
    ReadFieldDecimal bs pos ExecPriceAdjustment.ExecPriceAdjustment


let ReadDateOfBirth (bs:byte[]) (pos:int): (int*DateOfBirth) =
    ReadFieldLocalMktDate bs pos DateOfBirth.DateOfBirth


let ReadTradeReportTransType (bs:byte[]) (pos:int) : (int * TradeReportTransType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> TradeReportTransType.New
        |"1"B -> TradeReportTransType.Cancel
        |"2"B -> TradeReportTransType.Replace
        |"3"B -> TradeReportTransType.Release
        |"4"B -> TradeReportTransType.Reverse
        | x -> failwith (sprintf "ReadTradeReportTransType unknown fix tag: %A"  x) 
    pos2, fld


let ReadCardHolderName (bs:byte[]) (pos:int): (int*CardHolderName) =
    ReadFieldStr bs pos CardHolderName.CardHolderName


let ReadCardNumber (bs:byte[]) (pos:int): (int*CardNumber) =
    ReadFieldStr bs pos CardNumber.CardNumber


let ReadCardExpDate (bs:byte[]) (pos:int): (int*CardExpDate) =
    ReadFieldLocalMktDate bs pos CardExpDate.CardExpDate


let ReadCardIssNum (bs:byte[]) (pos:int): (int*CardIssNum) =
    ReadFieldStr bs pos CardIssNum.CardIssNum


let ReadPaymentMethod (bs:byte[]) (pos:int) : (int * PaymentMethod) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadRegistAcctType (bs:byte[]) (pos:int): (int*RegistAcctType) =
    ReadFieldStr bs pos RegistAcctType.RegistAcctType


let ReadDesignation (bs:byte[]) (pos:int): (int*Designation) =
    ReadFieldStr bs pos Designation.Designation


let ReadTaxAdvantageType (bs:byte[]) (pos:int) : (int * TaxAdvantageType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadRegistRejReasonText (bs:byte[]) (pos:int): (int*RegistRejReasonText) =
    ReadFieldStr bs pos RegistRejReasonText.RegistRejReasonText


let ReadFundRenewWaiv (bs:byte[]) (pos:int) : (int * FundRenewWaiv) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"Y"B -> FundRenewWaiv.Yes
        |"N"B -> FundRenewWaiv.No
        | x -> failwith (sprintf "ReadFundRenewWaiv unknown fix tag: %A"  x) 
    pos2, fld


let ReadCashDistribAgentName (bs:byte[]) (pos:int): (int*CashDistribAgentName) =
    ReadFieldStr bs pos CashDistribAgentName.CashDistribAgentName


let ReadCashDistribAgentCode (bs:byte[]) (pos:int): (int*CashDistribAgentCode) =
    ReadFieldStr bs pos CashDistribAgentCode.CashDistribAgentCode


let ReadCashDistribAgentAcctNumber (bs:byte[]) (pos:int): (int*CashDistribAgentAcctNumber) =
    ReadFieldStr bs pos CashDistribAgentAcctNumber.CashDistribAgentAcctNumber


let ReadCashDistribPayRef (bs:byte[]) (pos:int): (int*CashDistribPayRef) =
    ReadFieldStr bs pos CashDistribPayRef.CashDistribPayRef


let ReadCashDistribAgentAcctName (bs:byte[]) (pos:int): (int*CashDistribAgentAcctName) =
    ReadFieldStr bs pos CashDistribAgentAcctName.CashDistribAgentAcctName


let ReadCardStartDate (bs:byte[]) (pos:int): (int*CardStartDate) =
    ReadFieldLocalMktDate bs pos CardStartDate.CardStartDate


let ReadPaymentDate (bs:byte[]) (pos:int): (int*PaymentDate) =
    ReadFieldLocalMktDate bs pos PaymentDate.PaymentDate


let ReadPaymentRemitterID (bs:byte[]) (pos:int): (int*PaymentRemitterID) =
    ReadFieldStr bs pos PaymentRemitterID.PaymentRemitterID


let ReadRegistStatus (bs:byte[]) (pos:int) : (int * RegistStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"A"B -> RegistStatus.Accepted
        |"R"B -> RegistStatus.Rejected
        |"H"B -> RegistStatus.Held
        |"N"B -> RegistStatus.Reminder
        | x -> failwith (sprintf "ReadRegistStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadRegistRejReasonCode (bs:byte[]) (pos:int) : (int * RegistRejReasonCode) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadRegistRefID (bs:byte[]) (pos:int): (int*RegistRefID) =
    ReadFieldStr bs pos RegistRefID.RegistRefID


let ReadRegistDtls (bs:byte[]) (pos:int): (int*RegistDtls) =
    ReadFieldStr bs pos RegistDtls.RegistDtls


let ReadNoDistribInsts (bs:byte[]) (pos:int): (int*NoDistribInsts) =
    ReadFieldInt bs pos NoDistribInsts.NoDistribInsts


let ReadRegistEmail (bs:byte[]) (pos:int): (int*RegistEmail) =
    ReadFieldStr bs pos RegistEmail.RegistEmail


let ReadDistribPercentage (bs:byte[]) (pos:int): (int*DistribPercentage) =
    ReadFieldDecimal bs pos DistribPercentage.DistribPercentage


let ReadRegistID (bs:byte[]) (pos:int): (int*RegistID) =
    ReadFieldStr bs pos RegistID.RegistID


let ReadRegistTransType (bs:byte[]) (pos:int) : (int * RegistTransType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> RegistTransType.New
        |"1"B -> RegistTransType.Replace
        |"2"B -> RegistTransType.Cancel
        | x -> failwith (sprintf "ReadRegistTransType unknown fix tag: %A"  x) 
    pos2, fld


let ReadExecValuationPoint (bs:byte[]) (pos:int): (int*ExecValuationPoint) =
    ReadFieldUTCTimestamp bs pos ExecValuationPoint.ExecValuationPoint


let ReadOrderPercent (bs:byte[]) (pos:int): (int*OrderPercent) =
    ReadFieldDecimal bs pos OrderPercent.OrderPercent


let ReadOwnershipType (bs:byte[]) (pos:int) : (int * OwnershipType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"J"B -> OwnershipType.JointInvestors
        |"T"B -> OwnershipType.TenantsInCommon
        |"2"B -> OwnershipType.JointTrustees
        | x -> failwith (sprintf "ReadOwnershipType unknown fix tag: %A"  x) 
    pos2, fld


let ReadNoContAmts (bs:byte[]) (pos:int): (int*NoContAmts) =
    ReadFieldInt bs pos NoContAmts.NoContAmts


let ReadContAmtType (bs:byte[]) (pos:int) : (int * ContAmtType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadContAmtValue (bs:byte[]) (pos:int): (int*ContAmtValue) =
    ReadFieldDecimal bs pos ContAmtValue.ContAmtValue


let ReadContAmtCurr (bs:byte[]) (pos:int): (int*ContAmtCurr) =
    ReadFieldStr bs pos ContAmtCurr.ContAmtCurr


let ReadOwnerType (bs:byte[]) (pos:int) : (int * OwnerType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadPartySubID (bs:byte[]) (pos:int): (int*PartySubID) =
    ReadFieldStr bs pos PartySubID.PartySubID


let ReadNestedPartyID (bs:byte[]) (pos:int): (int*NestedPartyID) =
    ReadFieldStr bs pos NestedPartyID.NestedPartyID


let ReadNestedPartyIDSource (bs:byte[]) (pos:int): (int*NestedPartyIDSource) =
    ReadFieldChar bs pos NestedPartyIDSource.NestedPartyIDSource


let ReadSecondaryClOrdID (bs:byte[]) (pos:int): (int*SecondaryClOrdID) =
    ReadFieldStr bs pos SecondaryClOrdID.SecondaryClOrdID


let ReadSecondaryExecID (bs:byte[]) (pos:int): (int*SecondaryExecID) =
    ReadFieldStr bs pos SecondaryExecID.SecondaryExecID


let ReadOrderCapacity (bs:byte[]) (pos:int) : (int * OrderCapacity) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"A"B -> OrderCapacity.Agency
        |"G"B -> OrderCapacity.Proprietary
        |"I"B -> OrderCapacity.Individual
        |"P"B -> OrderCapacity.Principal
        |"R"B -> OrderCapacity.RisklessPrincipal
        |"W"B -> OrderCapacity.AgentForOtherMember
        | x -> failwith (sprintf "ReadOrderCapacity unknown fix tag: %A"  x) 
    pos2, fld


let ReadOrderRestrictions (bs:byte[]) (pos:int) : (int * OrderRestrictions) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadMassCancelRequestType (bs:byte[]) (pos:int) : (int * MassCancelRequestType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadMassCancelResponse (bs:byte[]) (pos:int) : (int * MassCancelResponse) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadMassCancelRejectReason (bs:byte[]) (pos:int) : (int * MassCancelRejectReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadTotalAffectedOrders (bs:byte[]) (pos:int): (int*TotalAffectedOrders) =
    ReadFieldInt bs pos TotalAffectedOrders.TotalAffectedOrders


let ReadNoAffectedOrders (bs:byte[]) (pos:int): (int*NoAffectedOrders) =
    ReadFieldInt bs pos NoAffectedOrders.NoAffectedOrders


let ReadAffectedOrderID (bs:byte[]) (pos:int): (int*AffectedOrderID) =
    ReadFieldStr bs pos AffectedOrderID.AffectedOrderID


let ReadAffectedSecondaryOrderID (bs:byte[]) (pos:int): (int*AffectedSecondaryOrderID) =
    ReadFieldStr bs pos AffectedSecondaryOrderID.AffectedSecondaryOrderID


let ReadQuoteType (bs:byte[]) (pos:int) : (int * QuoteType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> QuoteType.Indicative
        |"1"B -> QuoteType.Tradeable
        |"2"B -> QuoteType.RestrictedTradeable
        |"3"B -> QuoteType.Counter
        | x -> failwith (sprintf "ReadQuoteType unknown fix tag: %A"  x) 
    pos2, fld


let ReadNestedPartyRole (bs:byte[]) (pos:int): (int*NestedPartyRole) =
    ReadFieldInt bs pos NestedPartyRole.NestedPartyRole


let ReadNoNestedPartyIDs (bs:byte[]) (pos:int): (int*NoNestedPartyIDs) =
    ReadFieldInt bs pos NoNestedPartyIDs.NoNestedPartyIDs


let ReadTotalAccruedInterestAmt (bs:byte[]) (pos:int): (int*TotalAccruedInterestAmt) =
    ReadFieldDecimal bs pos TotalAccruedInterestAmt.TotalAccruedInterestAmt


let ReadMaturityDate (bs:byte[]) (pos:int): (int*MaturityDate) =
    ReadFieldLocalMktDate bs pos MaturityDate.MaturityDate


let ReadUnderlyingMaturityDate (bs:byte[]) (pos:int): (int*UnderlyingMaturityDate) =
    ReadFieldLocalMktDate bs pos UnderlyingMaturityDate.UnderlyingMaturityDate


let ReadInstrRegistry (bs:byte[]) (pos:int): (int*InstrRegistry) =
    ReadFieldStr bs pos InstrRegistry.InstrRegistry


let ReadCashMargin (bs:byte[]) (pos:int) : (int * CashMargin) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> CashMargin.Cash
        |"2"B -> CashMargin.MarginOpen
        |"3"B -> CashMargin.MarginClose
        | x -> failwith (sprintf "ReadCashMargin unknown fix tag: %A"  x) 
    pos2, fld


let ReadNestedPartySubID (bs:byte[]) (pos:int): (int*NestedPartySubID) =
    ReadFieldStr bs pos NestedPartySubID.NestedPartySubID


let ReadScope (bs:byte[]) (pos:int) : (int * Scope) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> Scope.Local
        |"2"B -> Scope.National
        |"3"B -> Scope.Global
        | x -> failwith (sprintf "ReadScope unknown fix tag: %A"  x) 
    pos2, fld


let ReadMDImplicitDelete (bs:byte[]) (pos:int): (int*MDImplicitDelete) =
    ReadFieldBool bs pos MDImplicitDelete.MDImplicitDelete


let ReadCrossID (bs:byte[]) (pos:int): (int*CrossID) =
    ReadFieldStr bs pos CrossID.CrossID


let ReadCrossType (bs:byte[]) (pos:int) : (int * CrossType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> CrossType.CrossTradeWhichIsExecutedCompletelyOrNot
        |"2"B -> CrossType.CrossTradeWhichIsExecutedPartiallyAndTheRestIsCancelled
        |"3"B -> CrossType.CrossTradeWhichIsPartiallyExecutedWithTheUnfilledPortionsRemainingActive
        |"4"B -> CrossType.CrossTradeIsExecutedWithExistingOrdersWithTheSamePrice
        | x -> failwith (sprintf "ReadCrossType unknown fix tag: %A"  x) 
    pos2, fld


let ReadCrossPrioritization (bs:byte[]) (pos:int) : (int * CrossPrioritization) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> CrossPrioritization.NNone
        |"1"B -> CrossPrioritization.BuySideIsPrioritized
        |"2"B -> CrossPrioritization.SellSideIsPrioritized
        | x -> failwith (sprintf "ReadCrossPrioritization unknown fix tag: %A"  x) 
    pos2, fld


let ReadOrigCrossID (bs:byte[]) (pos:int): (int*OrigCrossID) =
    ReadFieldStr bs pos OrigCrossID.OrigCrossID


let ReadNoSides (bs:byte[]) (pos:int) : (int * NoSides) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> NoSides.OneSide
        |"2"B -> NoSides.BothSides
        | x -> failwith (sprintf "ReadNoSides unknown fix tag: %A"  x) 
    pos2, fld


let ReadUsername (bs:byte[]) (pos:int): (int*Username) =
    ReadFieldStr bs pos Username.Username


let ReadPassword (bs:byte[]) (pos:int): (int*Password) =
    ReadFieldStr bs pos Password.Password


let ReadNoLegs (bs:byte[]) (pos:int): (int*NoLegs) =
    ReadFieldInt bs pos NoLegs.NoLegs


let ReadLegCurrency (bs:byte[]) (pos:int): (int*LegCurrency) =
    ReadFieldStr bs pos LegCurrency.LegCurrency


let ReadTotNoSecurityTypes (bs:byte[]) (pos:int): (int*TotNoSecurityTypes) =
    ReadFieldInt bs pos TotNoSecurityTypes.TotNoSecurityTypes


let ReadNoSecurityTypes (bs:byte[]) (pos:int): (int*NoSecurityTypes) =
    ReadFieldInt bs pos NoSecurityTypes.NoSecurityTypes


let ReadSecurityListRequestType (bs:byte[]) (pos:int) : (int * SecurityListRequestType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> SecurityListRequestType.Symbol
        |"1"B -> SecurityListRequestType.SecuritytypeAndOrCficode
        |"2"B -> SecurityListRequestType.Product
        |"3"B -> SecurityListRequestType.Tradingsessionid
        |"4"B -> SecurityListRequestType.AllSecurities
        | x -> failwith (sprintf "ReadSecurityListRequestType unknown fix tag: %A"  x) 
    pos2, fld


let ReadSecurityRequestResult (bs:byte[]) (pos:int) : (int * SecurityRequestResult) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> SecurityRequestResult.ValidRequest
        |"1"B -> SecurityRequestResult.InvalidOrUnsupportedRequest
        |"2"B -> SecurityRequestResult.NoInstrumentsFoundThatMatchSelectionCriteria
        |"3"B -> SecurityRequestResult.NotAuthorizedToRetrieveInstrumentData
        |"4"B -> SecurityRequestResult.InstrumentDataTemporarilyUnavailable
        |"5"B -> SecurityRequestResult.RequestForInstrumentDataNotSupported
        | x -> failwith (sprintf "ReadSecurityRequestResult unknown fix tag: %A"  x) 
    pos2, fld


let ReadRoundLot (bs:byte[]) (pos:int): (int*RoundLot) =
    ReadFieldDecimal bs pos RoundLot.RoundLot


let ReadMinTradeVol (bs:byte[]) (pos:int): (int*MinTradeVol) =
    ReadFieldDecimal bs pos MinTradeVol.MinTradeVol


let ReadMultiLegRptTypeReq (bs:byte[]) (pos:int) : (int * MultiLegRptTypeReq) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> MultiLegRptTypeReq.ReportByMulitlegSecurityOnly
        |"1"B -> MultiLegRptTypeReq.ReportByMultilegSecurityAndByInstrumentLegsBelongingToTheMultilegSecurity
        |"2"B -> MultiLegRptTypeReq.ReportByInstrumentLegsBelongingToTheMultilegSecurityOnly
        | x -> failwith (sprintf "ReadMultiLegRptTypeReq unknown fix tag: %A"  x) 
    pos2, fld


let ReadLegPositionEffect (bs:byte[]) (pos:int): (int*LegPositionEffect) =
    ReadFieldChar bs pos LegPositionEffect.LegPositionEffect


let ReadLegCoveredOrUncovered (bs:byte[]) (pos:int): (int*LegCoveredOrUncovered) =
    ReadFieldInt bs pos LegCoveredOrUncovered.LegCoveredOrUncovered


let ReadLegPrice (bs:byte[]) (pos:int): (int*LegPrice) =
    ReadFieldDecimal bs pos LegPrice.LegPrice


let ReadTradSesStatusRejReason (bs:byte[]) (pos:int) : (int * TradSesStatusRejReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> TradSesStatusRejReason.UnknownOrInvalidTradingsessionid
        | x -> failwith (sprintf "ReadTradSesStatusRejReason unknown fix tag: %A"  x) 
    pos2, fld


let ReadTradeRequestID (bs:byte[]) (pos:int): (int*TradeRequestID) =
    ReadFieldStr bs pos TradeRequestID.TradeRequestID


let ReadTradeRequestType (bs:byte[]) (pos:int) : (int * TradeRequestType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> TradeRequestType.AllTrades
        |"1"B -> TradeRequestType.MatchedTradesMatchingCriteriaProvidedOnRequest
        |"2"B -> TradeRequestType.UnmatchedTradesThatMatchCriteria
        |"3"B -> TradeRequestType.UnreportedTradesThatMatchCriteria
        |"4"B -> TradeRequestType.AdvisoriesThatMatchCriteria
        | x -> failwith (sprintf "ReadTradeRequestType unknown fix tag: %A"  x) 
    pos2, fld


let ReadPreviouslyReported (bs:byte[]) (pos:int): (int*PreviouslyReported) =
    ReadFieldBool bs pos PreviouslyReported.PreviouslyReported


let ReadTradeReportID (bs:byte[]) (pos:int): (int*TradeReportID) =
    ReadFieldStr bs pos TradeReportID.TradeReportID


let ReadTradeReportRefID (bs:byte[]) (pos:int): (int*TradeReportRefID) =
    ReadFieldStr bs pos TradeReportRefID.TradeReportRefID


let ReadMatchStatus (bs:byte[]) (pos:int) : (int * MatchStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> MatchStatus.ComparedMatchedOrAffirmed
        |"1"B -> MatchStatus.UncomparedUnmatchedOrUnaffirmed
        |"2"B -> MatchStatus.AdvisoryOrAlert
        | x -> failwith (sprintf "ReadMatchStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadMatchType (bs:byte[]) (pos:int): (int*MatchType) =
    ReadFieldStr bs pos MatchType.MatchType


let ReadOddLot (bs:byte[]) (pos:int): (int*OddLot) =
    ReadFieldBool bs pos OddLot.OddLot


let ReadNoClearingInstructions (bs:byte[]) (pos:int): (int*NoClearingInstructions) =
    ReadFieldInt bs pos NoClearingInstructions.NoClearingInstructions


let ReadClearingInstruction (bs:byte[]) (pos:int) : (int * ClearingInstruction) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadTradeInputSource (bs:byte[]) (pos:int): (int*TradeInputSource) =
    ReadFieldStr bs pos TradeInputSource.TradeInputSource


let ReadTradeInputDevice (bs:byte[]) (pos:int): (int*TradeInputDevice) =
    ReadFieldStr bs pos TradeInputDevice.TradeInputDevice


let ReadNoDates (bs:byte[]) (pos:int): (int*NoDates) =
    ReadFieldInt bs pos NoDates.NoDates


let ReadAccountType (bs:byte[]) (pos:int) : (int * AccountType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadCustOrderCapacity (bs:byte[]) (pos:int) : (int * CustOrderCapacity) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> CustOrderCapacity.MemberTradingForTheirOwnAccount
        |"2"B -> CustOrderCapacity.ClearingFirmTradingForItsProprietaryAccount
        |"3"B -> CustOrderCapacity.MemberTradingForAnotherMember
        |"4"B -> CustOrderCapacity.AllOther
        | x -> failwith (sprintf "ReadCustOrderCapacity unknown fix tag: %A"  x) 
    pos2, fld


let ReadClOrdLinkID (bs:byte[]) (pos:int): (int*ClOrdLinkID) =
    ReadFieldStr bs pos ClOrdLinkID.ClOrdLinkID


let ReadMassStatusReqID (bs:byte[]) (pos:int): (int*MassStatusReqID) =
    ReadFieldStr bs pos MassStatusReqID.MassStatusReqID


let ReadMassStatusReqType (bs:byte[]) (pos:int) : (int * MassStatusReqType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadOrigOrdModTime (bs:byte[]) (pos:int): (int*OrigOrdModTime) =
    ReadFieldUTCTimestamp bs pos OrigOrdModTime.OrigOrdModTime


let ReadLegSettlType (bs:byte[]) (pos:int): (int*LegSettlType) =
    ReadFieldChar bs pos LegSettlType.LegSettlType


let ReadLegSettlDate (bs:byte[]) (pos:int): (int*LegSettlDate) =
    ReadFieldLocalMktDate bs pos LegSettlDate.LegSettlDate


let ReadDayBookingInst (bs:byte[]) (pos:int) : (int * DayBookingInst) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> DayBookingInst.CanTriggerBookingWithoutReferenceToTheOrderInitiator
        |"1"B -> DayBookingInst.SpeakWithOrderInitiatorBeforeBooking
        |"2"B -> DayBookingInst.Accumulate
        | x -> failwith (sprintf "ReadDayBookingInst unknown fix tag: %A"  x) 
    pos2, fld


let ReadBookingUnit (bs:byte[]) (pos:int) : (int * BookingUnit) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> BookingUnit.EachPartialExecutionIsABookableUnit
        |"1"B -> BookingUnit.AggregatePartialExecutionsOnThisOrderAndBookOneTradePerOrder
        |"2"B -> BookingUnit.AggregateExecutionsForThisSymbolSideAndSettlementDate
        | x -> failwith (sprintf "ReadBookingUnit unknown fix tag: %A"  x) 
    pos2, fld


let ReadPreallocMethod (bs:byte[]) (pos:int) : (int * PreallocMethod) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> PreallocMethod.ProRata
        |"1"B -> PreallocMethod.DoNotProRata
        | x -> failwith (sprintf "ReadPreallocMethod unknown fix tag: %A"  x) 
    pos2, fld


let ReadUnderlyingCountryOfIssue (bs:byte[]) (pos:int): (int*UnderlyingCountryOfIssue) =
    ReadFieldStr bs pos UnderlyingCountryOfIssue.UnderlyingCountryOfIssue


let ReadUnderlyingStateOrProvinceOfIssue (bs:byte[]) (pos:int): (int*UnderlyingStateOrProvinceOfIssue) =
    ReadFieldStr bs pos UnderlyingStateOrProvinceOfIssue.UnderlyingStateOrProvinceOfIssue


let ReadUnderlyingLocaleOfIssue (bs:byte[]) (pos:int): (int*UnderlyingLocaleOfIssue) =
    ReadFieldStr bs pos UnderlyingLocaleOfIssue.UnderlyingLocaleOfIssue


let ReadUnderlyingInstrRegistry (bs:byte[]) (pos:int): (int*UnderlyingInstrRegistry) =
    ReadFieldStr bs pos UnderlyingInstrRegistry.UnderlyingInstrRegistry


let ReadLegCountryOfIssue (bs:byte[]) (pos:int): (int*LegCountryOfIssue) =
    ReadFieldStr bs pos LegCountryOfIssue.LegCountryOfIssue


let ReadLegStateOrProvinceOfIssue (bs:byte[]) (pos:int): (int*LegStateOrProvinceOfIssue) =
    ReadFieldStr bs pos LegStateOrProvinceOfIssue.LegStateOrProvinceOfIssue


let ReadLegLocaleOfIssue (bs:byte[]) (pos:int): (int*LegLocaleOfIssue) =
    ReadFieldStr bs pos LegLocaleOfIssue.LegLocaleOfIssue


let ReadLegInstrRegistry (bs:byte[]) (pos:int): (int*LegInstrRegistry) =
    ReadFieldStr bs pos LegInstrRegistry.LegInstrRegistry


let ReadLegSymbol (bs:byte[]) (pos:int): (int*LegSymbol) =
    ReadFieldStr bs pos LegSymbol.LegSymbol


let ReadLegSymbolSfx (bs:byte[]) (pos:int): (int*LegSymbolSfx) =
    ReadFieldStr bs pos LegSymbolSfx.LegSymbolSfx


let ReadLegSecurityID (bs:byte[]) (pos:int): (int*LegSecurityID) =
    ReadFieldStr bs pos LegSecurityID.LegSecurityID


let ReadLegSecurityIDSource (bs:byte[]) (pos:int): (int*LegSecurityIDSource) =
    ReadFieldStr bs pos LegSecurityIDSource.LegSecurityIDSource


let ReadNoLegSecurityAltID (bs:byte[]) (pos:int): (int*NoLegSecurityAltID) =
    ReadFieldInt bs pos NoLegSecurityAltID.NoLegSecurityAltID


let ReadLegSecurityAltID (bs:byte[]) (pos:int): (int*LegSecurityAltID) =
    ReadFieldStr bs pos LegSecurityAltID.LegSecurityAltID


let ReadLegSecurityAltIDSource (bs:byte[]) (pos:int): (int*LegSecurityAltIDSource) =
    ReadFieldStr bs pos LegSecurityAltIDSource.LegSecurityAltIDSource


let ReadLegProduct (bs:byte[]) (pos:int): (int*LegProduct) =
    ReadFieldInt bs pos LegProduct.LegProduct


let ReadLegCFICode (bs:byte[]) (pos:int): (int*LegCFICode) =
    ReadFieldStr bs pos LegCFICode.LegCFICode


let ReadLegSecurityType (bs:byte[]) (pos:int): (int*LegSecurityType) =
    ReadFieldStr bs pos LegSecurityType.LegSecurityType


let ReadLegMaturityMonthYear (bs:byte[]) (pos:int): (int*LegMaturityMonthYear) =
    ReadFieldMonthYear bs pos LegMaturityMonthYear.LegMaturityMonthYear


let ReadLegMaturityDate (bs:byte[]) (pos:int): (int*LegMaturityDate) =
    ReadFieldLocalMktDate bs pos LegMaturityDate.LegMaturityDate


let ReadLegStrikePrice (bs:byte[]) (pos:int): (int*LegStrikePrice) =
    ReadFieldDecimal bs pos LegStrikePrice.LegStrikePrice


let ReadLegOptAttribute (bs:byte[]) (pos:int): (int*LegOptAttribute) =
    ReadFieldChar bs pos LegOptAttribute.LegOptAttribute


let ReadLegContractMultiplier (bs:byte[]) (pos:int): (int*LegContractMultiplier) =
    ReadFieldDecimal bs pos LegContractMultiplier.LegContractMultiplier


let ReadLegCouponRate (bs:byte[]) (pos:int): (int*LegCouponRate) =
    ReadFieldDecimal bs pos LegCouponRate.LegCouponRate


let ReadLegSecurityExchange (bs:byte[]) (pos:int): (int*LegSecurityExchange) =
    ReadFieldStr bs pos LegSecurityExchange.LegSecurityExchange


let ReadLegIssuer (bs:byte[]) (pos:int): (int*LegIssuer) =
    ReadFieldStr bs pos LegIssuer.LegIssuer


// compound read
let ReadEncodedLegIssuer (bs:byte[]) (pos:int) : (int * EncodedLegIssuer) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "619"B EncodedLegIssuer.EncodedLegIssuer


let ReadLegSecurityDesc (bs:byte[]) (pos:int): (int*LegSecurityDesc) =
    ReadFieldStr bs pos LegSecurityDesc.LegSecurityDesc


// compound read
let ReadEncodedLegSecurityDesc (bs:byte[]) (pos:int) : (int * EncodedLegSecurityDesc) =
    ReadLengthDataCompoundField (bs:byte[]) (pos:int) "622"B EncodedLegSecurityDesc.EncodedLegSecurityDesc


let ReadLegRatioQty (bs:byte[]) (pos:int): (int*LegRatioQty) =
    ReadFieldDecimal bs pos LegRatioQty.LegRatioQty


let ReadLegSide (bs:byte[]) (pos:int): (int*LegSide) =
    ReadFieldChar bs pos LegSide.LegSide


let ReadTradingSessionSubID (bs:byte[]) (pos:int): (int*TradingSessionSubID) =
    ReadFieldStr bs pos TradingSessionSubID.TradingSessionSubID


let ReadAllocType (bs:byte[]) (pos:int) : (int * AllocType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> AllocType.Calculated
        |"2"B -> AllocType.Preliminary
        |"5"B -> AllocType.ReadyToBookSingleOrder
        |"7"B -> AllocType.WarehouseInstruction
        |"8"B -> AllocType.RequestToIntermediary
        | x -> failwith (sprintf "ReadAllocType unknown fix tag: %A"  x) 
    pos2, fld


let ReadNoHops (bs:byte[]) (pos:int): (int*NoHops) =
    ReadFieldInt bs pos NoHops.NoHops


let ReadHopCompID (bs:byte[]) (pos:int): (int*HopCompID) =
    ReadFieldStr bs pos HopCompID.HopCompID


let ReadHopSendingTime (bs:byte[]) (pos:int): (int*HopSendingTime) =
    ReadFieldUTCTimestamp bs pos HopSendingTime.HopSendingTime


let ReadHopRefID (bs:byte[]) (pos:int): (int*HopRefID) =
    ReadFieldUint32 bs pos HopRefID.HopRefID


let ReadMidPx (bs:byte[]) (pos:int): (int*MidPx) =
    ReadFieldDecimal bs pos MidPx.MidPx


let ReadBidYield (bs:byte[]) (pos:int): (int*BidYield) =
    ReadFieldDecimal bs pos BidYield.BidYield


let ReadMidYield (bs:byte[]) (pos:int): (int*MidYield) =
    ReadFieldDecimal bs pos MidYield.MidYield


let ReadOfferYield (bs:byte[]) (pos:int): (int*OfferYield) =
    ReadFieldDecimal bs pos OfferYield.OfferYield


let ReadClearingFeeIndicator (bs:byte[]) (pos:int) : (int * ClearingFeeIndicator) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadWorkingIndicator (bs:byte[]) (pos:int): (int*WorkingIndicator) =
    ReadFieldBool bs pos WorkingIndicator.WorkingIndicator


let ReadLegLastPx (bs:byte[]) (pos:int): (int*LegLastPx) =
    ReadFieldDecimal bs pos LegLastPx.LegLastPx


let ReadPriorityIndicator (bs:byte[]) (pos:int) : (int * PriorityIndicator) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> PriorityIndicator.PriorityUnchanged
        |"1"B -> PriorityIndicator.LostPriorityAsResultOfOrderChange
        | x -> failwith (sprintf "ReadPriorityIndicator unknown fix tag: %A"  x) 
    pos2, fld


let ReadPriceImprovement (bs:byte[]) (pos:int): (int*PriceImprovement) =
    ReadFieldDecimal bs pos PriceImprovement.PriceImprovement


let ReadPrice2 (bs:byte[]) (pos:int): (int*Price2) =
    ReadFieldDecimal bs pos Price2.Price2


let ReadLastForwardPoints2 (bs:byte[]) (pos:int): (int*LastForwardPoints2) =
    ReadFieldDecimal bs pos LastForwardPoints2.LastForwardPoints2


let ReadBidForwardPoints2 (bs:byte[]) (pos:int): (int*BidForwardPoints2) =
    ReadFieldDecimal bs pos BidForwardPoints2.BidForwardPoints2


let ReadOfferForwardPoints2 (bs:byte[]) (pos:int): (int*OfferForwardPoints2) =
    ReadFieldDecimal bs pos OfferForwardPoints2.OfferForwardPoints2


let ReadRFQReqID (bs:byte[]) (pos:int): (int*RFQReqID) =
    ReadFieldStr bs pos RFQReqID.RFQReqID


let ReadMktBidPx (bs:byte[]) (pos:int): (int*MktBidPx) =
    ReadFieldDecimal bs pos MktBidPx.MktBidPx


let ReadMktOfferPx (bs:byte[]) (pos:int): (int*MktOfferPx) =
    ReadFieldDecimal bs pos MktOfferPx.MktOfferPx


let ReadMinBidSize (bs:byte[]) (pos:int): (int*MinBidSize) =
    ReadFieldDecimal bs pos MinBidSize.MinBidSize


let ReadMinOfferSize (bs:byte[]) (pos:int): (int*MinOfferSize) =
    ReadFieldDecimal bs pos MinOfferSize.MinOfferSize


let ReadQuoteStatusReqID (bs:byte[]) (pos:int): (int*QuoteStatusReqID) =
    ReadFieldStr bs pos QuoteStatusReqID.QuoteStatusReqID


let ReadLegalConfirm (bs:byte[]) (pos:int): (int*LegalConfirm) =
    ReadFieldBool bs pos LegalConfirm.LegalConfirm


let ReadUnderlyingLastPx (bs:byte[]) (pos:int): (int*UnderlyingLastPx) =
    ReadFieldDecimal bs pos UnderlyingLastPx.UnderlyingLastPx


let ReadUnderlyingLastQty (bs:byte[]) (pos:int): (int*UnderlyingLastQty) =
    ReadFieldDecimal bs pos UnderlyingLastQty.UnderlyingLastQty


let ReadLegRefID (bs:byte[]) (pos:int): (int*LegRefID) =
    ReadFieldStr bs pos LegRefID.LegRefID


let ReadContraLegRefID (bs:byte[]) (pos:int): (int*ContraLegRefID) =
    ReadFieldStr bs pos ContraLegRefID.ContraLegRefID


let ReadSettlCurrBidFxRate (bs:byte[]) (pos:int): (int*SettlCurrBidFxRate) =
    ReadFieldDecimal bs pos SettlCurrBidFxRate.SettlCurrBidFxRate


let ReadSettlCurrOfferFxRate (bs:byte[]) (pos:int): (int*SettlCurrOfferFxRate) =
    ReadFieldDecimal bs pos SettlCurrOfferFxRate.SettlCurrOfferFxRate


let ReadQuoteRequestRejectReason (bs:byte[]) (pos:int) : (int * QuoteRequestRejectReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadSideComplianceID (bs:byte[]) (pos:int): (int*SideComplianceID) =
    ReadFieldStr bs pos SideComplianceID.SideComplianceID


let ReadAcctIDSource (bs:byte[]) (pos:int) : (int * AcctIDSource) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> AcctIDSource.Bic
        |"2"B -> AcctIDSource.SidCode
        |"3"B -> AcctIDSource.Tfm
        |"4"B -> AcctIDSource.Omgeo
        |"5"B -> AcctIDSource.DtccCode
        |"99"B -> AcctIDSource.Other
        | x -> failwith (sprintf "ReadAcctIDSource unknown fix tag: %A"  x) 
    pos2, fld


let ReadAllocAcctIDSource (bs:byte[]) (pos:int): (int*AllocAcctIDSource) =
    ReadFieldInt bs pos AllocAcctIDSource.AllocAcctIDSource


let ReadBenchmarkPrice (bs:byte[]) (pos:int): (int*BenchmarkPrice) =
    ReadFieldDecimal bs pos BenchmarkPrice.BenchmarkPrice


let ReadBenchmarkPriceType (bs:byte[]) (pos:int): (int*BenchmarkPriceType) =
    ReadFieldInt bs pos BenchmarkPriceType.BenchmarkPriceType


let ReadConfirmID (bs:byte[]) (pos:int): (int*ConfirmID) =
    ReadFieldStr bs pos ConfirmID.ConfirmID


let ReadConfirmStatus (bs:byte[]) (pos:int) : (int * ConfirmStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> ConfirmStatus.Received
        |"2"B -> ConfirmStatus.MismatchedAccount
        |"3"B -> ConfirmStatus.MissingSettlementInstructions
        |"4"B -> ConfirmStatus.Confirmed
        |"5"B -> ConfirmStatus.RequestRejected
        | x -> failwith (sprintf "ReadConfirmStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadConfirmTransType (bs:byte[]) (pos:int) : (int * ConfirmTransType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> ConfirmTransType.New
        |"1"B -> ConfirmTransType.Replace
        |"2"B -> ConfirmTransType.Cancel
        | x -> failwith (sprintf "ReadConfirmTransType unknown fix tag: %A"  x) 
    pos2, fld


let ReadContractSettlMonth (bs:byte[]) (pos:int): (int*ContractSettlMonth) =
    ReadFieldMonthYear bs pos ContractSettlMonth.ContractSettlMonth


let ReadDeliveryForm (bs:byte[]) (pos:int) : (int * DeliveryForm) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> DeliveryForm.Bookentry
        |"2"B -> DeliveryForm.Bearer
        | x -> failwith (sprintf "ReadDeliveryForm unknown fix tag: %A"  x) 
    pos2, fld


let ReadLastParPx (bs:byte[]) (pos:int): (int*LastParPx) =
    ReadFieldDecimal bs pos LastParPx.LastParPx


let ReadNoLegAllocs (bs:byte[]) (pos:int): (int*NoLegAllocs) =
    ReadFieldInt bs pos NoLegAllocs.NoLegAllocs


let ReadLegAllocAccount (bs:byte[]) (pos:int): (int*LegAllocAccount) =
    ReadFieldStr bs pos LegAllocAccount.LegAllocAccount


let ReadLegIndividualAllocID (bs:byte[]) (pos:int): (int*LegIndividualAllocID) =
    ReadFieldStr bs pos LegIndividualAllocID.LegIndividualAllocID


let ReadLegAllocQty (bs:byte[]) (pos:int): (int*LegAllocQty) =
    ReadFieldDecimal bs pos LegAllocQty.LegAllocQty


let ReadLegAllocAcctIDSource (bs:byte[]) (pos:int): (int*LegAllocAcctIDSource) =
    ReadFieldStr bs pos LegAllocAcctIDSource.LegAllocAcctIDSource


let ReadLegSettlCurrency (bs:byte[]) (pos:int): (int*LegSettlCurrency) =
    ReadFieldStr bs pos LegSettlCurrency.LegSettlCurrency


let ReadLegBenchmarkCurveCurrency (bs:byte[]) (pos:int): (int*LegBenchmarkCurveCurrency) =
    ReadFieldStr bs pos LegBenchmarkCurveCurrency.LegBenchmarkCurveCurrency


let ReadLegBenchmarkCurveName (bs:byte[]) (pos:int): (int*LegBenchmarkCurveName) =
    ReadFieldStr bs pos LegBenchmarkCurveName.LegBenchmarkCurveName


let ReadLegBenchmarkCurvePoint (bs:byte[]) (pos:int): (int*LegBenchmarkCurvePoint) =
    ReadFieldStr bs pos LegBenchmarkCurvePoint.LegBenchmarkCurvePoint


let ReadLegBenchmarkPrice (bs:byte[]) (pos:int): (int*LegBenchmarkPrice) =
    ReadFieldDecimal bs pos LegBenchmarkPrice.LegBenchmarkPrice


let ReadLegBenchmarkPriceType (bs:byte[]) (pos:int): (int*LegBenchmarkPriceType) =
    ReadFieldInt bs pos LegBenchmarkPriceType.LegBenchmarkPriceType


let ReadLegBidPx (bs:byte[]) (pos:int): (int*LegBidPx) =
    ReadFieldDecimal bs pos LegBidPx.LegBidPx


let ReadLegIOIQty (bs:byte[]) (pos:int): (int*LegIOIQty) =
    ReadFieldStr bs pos LegIOIQty.LegIOIQty


let ReadNoLegStipulations (bs:byte[]) (pos:int): (int*NoLegStipulations) =
    ReadFieldInt bs pos NoLegStipulations.NoLegStipulations


let ReadLegOfferPx (bs:byte[]) (pos:int): (int*LegOfferPx) =
    ReadFieldDecimal bs pos LegOfferPx.LegOfferPx


let ReadLegOrderQty (bs:byte[]) (pos:int): (int*LegOrderQty) =
    ReadFieldDecimal bs pos LegOrderQty.LegOrderQty


let ReadLegPriceType (bs:byte[]) (pos:int): (int*LegPriceType) =
    ReadFieldInt bs pos LegPriceType.LegPriceType


let ReadLegQty (bs:byte[]) (pos:int): (int*LegQty) =
    ReadFieldDecimal bs pos LegQty.LegQty


let ReadLegStipulationType (bs:byte[]) (pos:int): (int*LegStipulationType) =
    ReadFieldStr bs pos LegStipulationType.LegStipulationType


let ReadLegStipulationValue (bs:byte[]) (pos:int): (int*LegStipulationValue) =
    ReadFieldStr bs pos LegStipulationValue.LegStipulationValue


let ReadLegSwapType (bs:byte[]) (pos:int) : (int * LegSwapType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> LegSwapType.ParForPar
        |"2"B -> LegSwapType.ModifiedDuration
        |"4"B -> LegSwapType.Risk
        |"5"B -> LegSwapType.Proceeds
        | x -> failwith (sprintf "ReadLegSwapType unknown fix tag: %A"  x) 
    pos2, fld


let ReadPool (bs:byte[]) (pos:int): (int*Pool) =
    ReadFieldStr bs pos Pool.Pool


let ReadQuotePriceType (bs:byte[]) (pos:int) : (int * QuotePriceType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadQuoteRespID (bs:byte[]) (pos:int): (int*QuoteRespID) =
    ReadFieldStr bs pos QuoteRespID.QuoteRespID


let ReadQuoteRespType (bs:byte[]) (pos:int) : (int * QuoteRespType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> QuoteRespType.HitLift
        |"2"B -> QuoteRespType.Counter
        |"3"B -> QuoteRespType.Expired
        |"4"B -> QuoteRespType.Cover
        |"5"B -> QuoteRespType.DoneAway
        |"6"B -> QuoteRespType.Pass
        | x -> failwith (sprintf "ReadQuoteRespType unknown fix tag: %A"  x) 
    pos2, fld


let ReadQuoteQualifier (bs:byte[]) (pos:int): (int*QuoteQualifier) =
    ReadFieldChar bs pos QuoteQualifier.QuoteQualifier


let ReadYieldRedemptionDate (bs:byte[]) (pos:int): (int*YieldRedemptionDate) =
    ReadFieldLocalMktDate bs pos YieldRedemptionDate.YieldRedemptionDate


let ReadYieldRedemptionPrice (bs:byte[]) (pos:int): (int*YieldRedemptionPrice) =
    ReadFieldDecimal bs pos YieldRedemptionPrice.YieldRedemptionPrice


let ReadYieldRedemptionPriceType (bs:byte[]) (pos:int): (int*YieldRedemptionPriceType) =
    ReadFieldInt bs pos YieldRedemptionPriceType.YieldRedemptionPriceType


let ReadBenchmarkSecurityID (bs:byte[]) (pos:int): (int*BenchmarkSecurityID) =
    ReadFieldStr bs pos BenchmarkSecurityID.BenchmarkSecurityID


let ReadReversalIndicator (bs:byte[]) (pos:int): (int*ReversalIndicator) =
    ReadFieldBool bs pos ReversalIndicator.ReversalIndicator


let ReadYieldCalcDate (bs:byte[]) (pos:int): (int*YieldCalcDate) =
    ReadFieldLocalMktDate bs pos YieldCalcDate.YieldCalcDate


let ReadNoPositions (bs:byte[]) (pos:int): (int*NoPositions) =
    ReadFieldInt bs pos NoPositions.NoPositions


let ReadPosType (bs:byte[]) (pos:int) : (int * PosType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadLongQty (bs:byte[]) (pos:int): (int*LongQty) =
    ReadFieldDecimal bs pos LongQty.LongQty


let ReadShortQty (bs:byte[]) (pos:int): (int*ShortQty) =
    ReadFieldDecimal bs pos ShortQty.ShortQty


let ReadPosQtyStatus (bs:byte[]) (pos:int) : (int * PosQtyStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> PosQtyStatus.Submitted
        |"1"B -> PosQtyStatus.Accepted
        |"2"B -> PosQtyStatus.Rejected
        | x -> failwith (sprintf "ReadPosQtyStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadPosAmtType (bs:byte[]) (pos:int) : (int * PosAmtType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadPosAmt (bs:byte[]) (pos:int): (int*PosAmt) =
    ReadFieldDecimal bs pos PosAmt.PosAmt


let ReadPosTransType (bs:byte[]) (pos:int) : (int * PosTransType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> PosTransType.Exercise
        |"2"B -> PosTransType.DoNotExercise
        |"3"B -> PosTransType.PositionAdjustment
        |"4"B -> PosTransType.PositionChangeSubmissionMarginDisposition
        |"5"B -> PosTransType.Pledge
        | x -> failwith (sprintf "ReadPosTransType unknown fix tag: %A"  x) 
    pos2, fld


let ReadPosReqID (bs:byte[]) (pos:int): (int*PosReqID) =
    ReadFieldStr bs pos PosReqID.PosReqID


let ReadNoUnderlyings (bs:byte[]) (pos:int): (int*NoUnderlyings) =
    ReadFieldInt bs pos NoUnderlyings.NoUnderlyings


let ReadPosMaintAction (bs:byte[]) (pos:int) : (int * PosMaintAction) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> PosMaintAction.New
        |"2"B -> PosMaintAction.Replace
        |"3"B -> PosMaintAction.Cancel
        | x -> failwith (sprintf "ReadPosMaintAction unknown fix tag: %A"  x) 
    pos2, fld


let ReadOrigPosReqRefID (bs:byte[]) (pos:int): (int*OrigPosReqRefID) =
    ReadFieldStr bs pos OrigPosReqRefID.OrigPosReqRefID


let ReadPosMaintRptRefID (bs:byte[]) (pos:int): (int*PosMaintRptRefID) =
    ReadFieldStr bs pos PosMaintRptRefID.PosMaintRptRefID


let ReadClearingBusinessDate (bs:byte[]) (pos:int): (int*ClearingBusinessDate) =
    ReadFieldLocalMktDate bs pos ClearingBusinessDate.ClearingBusinessDate


let ReadSettlSessID (bs:byte[]) (pos:int): (int*SettlSessID) =
    ReadFieldStr bs pos SettlSessID.SettlSessID


let ReadSettlSessSubID (bs:byte[]) (pos:int): (int*SettlSessSubID) =
    ReadFieldStr bs pos SettlSessSubID.SettlSessSubID


let ReadAdjustmentType (bs:byte[]) (pos:int) : (int * AdjustmentType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> AdjustmentType.ProcessRequestAsMarginDisposition
        |"1"B -> AdjustmentType.DeltaPlus
        |"2"B -> AdjustmentType.DeltaMinus
        |"3"B -> AdjustmentType.Final
        | x -> failwith (sprintf "ReadAdjustmentType unknown fix tag: %A"  x) 
    pos2, fld


let ReadContraryInstructionIndicator (bs:byte[]) (pos:int): (int*ContraryInstructionIndicator) =
    ReadFieldBool bs pos ContraryInstructionIndicator.ContraryInstructionIndicator


let ReadPriorSpreadIndicator (bs:byte[]) (pos:int): (int*PriorSpreadIndicator) =
    ReadFieldBool bs pos PriorSpreadIndicator.PriorSpreadIndicator


let ReadPosMaintRptID (bs:byte[]) (pos:int): (int*PosMaintRptID) =
    ReadFieldStr bs pos PosMaintRptID.PosMaintRptID


let ReadPosMaintStatus (bs:byte[]) (pos:int) : (int * PosMaintStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> PosMaintStatus.Accepted
        |"1"B -> PosMaintStatus.AcceptedWithWarnings
        |"2"B -> PosMaintStatus.Rejected
        |"3"B -> PosMaintStatus.Completed
        |"4"B -> PosMaintStatus.CompletedWithWarnings
        | x -> failwith (sprintf "ReadPosMaintStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadPosMaintResult (bs:byte[]) (pos:int) : (int * PosMaintResult) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> PosMaintResult.SuccessfulCompletionNoWarningsOrErrors
        |"1"B -> PosMaintResult.Rejected
        |"99"B -> PosMaintResult.Other
        | x -> failwith (sprintf "ReadPosMaintResult unknown fix tag: %A"  x) 
    pos2, fld


let ReadPosReqType (bs:byte[]) (pos:int) : (int * PosReqType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> PosReqType.Positions
        |"1"B -> PosReqType.Trades
        |"2"B -> PosReqType.Exercises
        |"3"B -> PosReqType.Assignments
        | x -> failwith (sprintf "ReadPosReqType unknown fix tag: %A"  x) 
    pos2, fld


let ReadResponseTransportType (bs:byte[]) (pos:int) : (int * ResponseTransportType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> ResponseTransportType.Inband
        |"1"B -> ResponseTransportType.OutOfBand
        | x -> failwith (sprintf "ReadResponseTransportType unknown fix tag: %A"  x) 
    pos2, fld


let ReadResponseDestination (bs:byte[]) (pos:int): (int*ResponseDestination) =
    ReadFieldStr bs pos ResponseDestination.ResponseDestination


let ReadTotalNumPosReports (bs:byte[]) (pos:int): (int*TotalNumPosReports) =
    ReadFieldInt bs pos TotalNumPosReports.TotalNumPosReports


let ReadPosReqResult (bs:byte[]) (pos:int) : (int * PosReqResult) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> PosReqResult.ValidRequest
        |"1"B -> PosReqResult.InvalidOrUnsupportedRequest
        |"2"B -> PosReqResult.NoPositionsFoundThatMatchCriteria
        |"3"B -> PosReqResult.NotAuthorizedToRequestPositions
        |"4"B -> PosReqResult.RequestForPositionNotSupported
        |"99"B -> PosReqResult.Other
        | x -> failwith (sprintf "ReadPosReqResult unknown fix tag: %A"  x) 
    pos2, fld


let ReadPosReqStatus (bs:byte[]) (pos:int) : (int * PosReqStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> PosReqStatus.Completed
        |"1"B -> PosReqStatus.CompletedWithWarnings
        |"2"B -> PosReqStatus.Rejected
        | x -> failwith (sprintf "ReadPosReqStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadSettlPrice (bs:byte[]) (pos:int): (int*SettlPrice) =
    ReadFieldDecimal bs pos SettlPrice.SettlPrice


let ReadSettlPriceType (bs:byte[]) (pos:int) : (int * SettlPriceType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> SettlPriceType.Final
        |"2"B -> SettlPriceType.Theoretical
        | x -> failwith (sprintf "ReadSettlPriceType unknown fix tag: %A"  x) 
    pos2, fld


let ReadUnderlyingSettlPrice (bs:byte[]) (pos:int): (int*UnderlyingSettlPrice) =
    ReadFieldDecimal bs pos UnderlyingSettlPrice.UnderlyingSettlPrice


let ReadUnderlyingSettlPriceType (bs:byte[]) (pos:int): (int*UnderlyingSettlPriceType) =
    ReadFieldInt bs pos UnderlyingSettlPriceType.UnderlyingSettlPriceType


let ReadPriorSettlPrice (bs:byte[]) (pos:int): (int*PriorSettlPrice) =
    ReadFieldDecimal bs pos PriorSettlPrice.PriorSettlPrice


let ReadNoQuoteQualifiers (bs:byte[]) (pos:int): (int*NoQuoteQualifiers) =
    ReadFieldInt bs pos NoQuoteQualifiers.NoQuoteQualifiers


let ReadAllocSettlCurrency (bs:byte[]) (pos:int): (int*AllocSettlCurrency) =
    ReadFieldStr bs pos AllocSettlCurrency.AllocSettlCurrency


let ReadAllocSettlCurrAmt (bs:byte[]) (pos:int): (int*AllocSettlCurrAmt) =
    ReadFieldDecimal bs pos AllocSettlCurrAmt.AllocSettlCurrAmt


let ReadInterestAtMaturity (bs:byte[]) (pos:int): (int*InterestAtMaturity) =
    ReadFieldDecimal bs pos InterestAtMaturity.InterestAtMaturity


let ReadLegDatedDate (bs:byte[]) (pos:int): (int*LegDatedDate) =
    ReadFieldLocalMktDate bs pos LegDatedDate.LegDatedDate


let ReadLegPool (bs:byte[]) (pos:int): (int*LegPool) =
    ReadFieldStr bs pos LegPool.LegPool


let ReadAllocInterestAtMaturity (bs:byte[]) (pos:int): (int*AllocInterestAtMaturity) =
    ReadFieldDecimal bs pos AllocInterestAtMaturity.AllocInterestAtMaturity


let ReadAllocAccruedInterestAmt (bs:byte[]) (pos:int): (int*AllocAccruedInterestAmt) =
    ReadFieldDecimal bs pos AllocAccruedInterestAmt.AllocAccruedInterestAmt


let ReadDeliveryDate (bs:byte[]) (pos:int): (int*DeliveryDate) =
    ReadFieldLocalMktDate bs pos DeliveryDate.DeliveryDate


let ReadAssignmentMethod (bs:byte[]) (pos:int) : (int * AssignmentMethod) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"R"B -> AssignmentMethod.Random
        |"P"B -> AssignmentMethod.Prorata
        | x -> failwith (sprintf "ReadAssignmentMethod unknown fix tag: %A"  x) 
    pos2, fld


let ReadAssignmentUnit (bs:byte[]) (pos:int): (int*AssignmentUnit) =
    ReadFieldDecimal bs pos AssignmentUnit.AssignmentUnit


let ReadOpenInterest (bs:byte[]) (pos:int): (int*OpenInterest) =
    ReadFieldDecimal bs pos OpenInterest.OpenInterest


let ReadExerciseMethod (bs:byte[]) (pos:int) : (int * ExerciseMethod) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"A"B -> ExerciseMethod.Automatic
        |"M"B -> ExerciseMethod.Manual
        | x -> failwith (sprintf "ReadExerciseMethod unknown fix tag: %A"  x) 
    pos2, fld


let ReadTotNumTradeReports (bs:byte[]) (pos:int): (int*TotNumTradeReports) =
    ReadFieldInt bs pos TotNumTradeReports.TotNumTradeReports


let ReadTradeRequestResult (bs:byte[]) (pos:int) : (int * TradeRequestResult) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadTradeRequestStatus (bs:byte[]) (pos:int) : (int * TradeRequestStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> TradeRequestStatus.Accepted
        |"1"B -> TradeRequestStatus.Completed
        |"2"B -> TradeRequestStatus.Rejected
        | x -> failwith (sprintf "ReadTradeRequestStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadTradeReportRejectReason (bs:byte[]) (pos:int) : (int * TradeReportRejectReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> TradeReportRejectReason.Successful
        |"1"B -> TradeReportRejectReason.InvalidPartyInformation
        |"2"B -> TradeReportRejectReason.UnknownInstrument
        |"3"B -> TradeReportRejectReason.UnauthorizedToReportTrades
        |"4"B -> TradeReportRejectReason.InvalidTradeType
        |"10"B -> TradeReportRejectReason.Yield
        | x -> failwith (sprintf "ReadTradeReportRejectReason unknown fix tag: %A"  x) 
    pos2, fld


let ReadSideMultiLegReportingType (bs:byte[]) (pos:int) : (int * SideMultiLegReportingType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> SideMultiLegReportingType.SingleSecurity
        |"2"B -> SideMultiLegReportingType.IndividualLegOfAMultiLegSecurity
        |"3"B -> SideMultiLegReportingType.MultiLegSecurity
        | x -> failwith (sprintf "ReadSideMultiLegReportingType unknown fix tag: %A"  x) 
    pos2, fld


let ReadNoPosAmt (bs:byte[]) (pos:int): (int*NoPosAmt) =
    ReadFieldInt bs pos NoPosAmt.NoPosAmt


let ReadAutoAcceptIndicator (bs:byte[]) (pos:int): (int*AutoAcceptIndicator) =
    ReadFieldBool bs pos AutoAcceptIndicator.AutoAcceptIndicator


let ReadAllocReportID (bs:byte[]) (pos:int): (int*AllocReportID) =
    ReadFieldStr bs pos AllocReportID.AllocReportID


let ReadNoNested2PartyIDs (bs:byte[]) (pos:int): (int*NoNested2PartyIDs) =
    ReadFieldInt bs pos NoNested2PartyIDs.NoNested2PartyIDs


let ReadNested2PartyID (bs:byte[]) (pos:int): (int*Nested2PartyID) =
    ReadFieldStr bs pos Nested2PartyID.Nested2PartyID


let ReadNested2PartyIDSource (bs:byte[]) (pos:int): (int*Nested2PartyIDSource) =
    ReadFieldChar bs pos Nested2PartyIDSource.Nested2PartyIDSource


let ReadNested2PartyRole (bs:byte[]) (pos:int): (int*Nested2PartyRole) =
    ReadFieldInt bs pos Nested2PartyRole.Nested2PartyRole


let ReadNested2PartySubID (bs:byte[]) (pos:int): (int*Nested2PartySubID) =
    ReadFieldStr bs pos Nested2PartySubID.Nested2PartySubID


let ReadBenchmarkSecurityIDSource (bs:byte[]) (pos:int): (int*BenchmarkSecurityIDSource) =
    ReadFieldStr bs pos BenchmarkSecurityIDSource.BenchmarkSecurityIDSource


let ReadSecuritySubType (bs:byte[]) (pos:int): (int*SecuritySubType) =
    ReadFieldStr bs pos SecuritySubType.SecuritySubType


let ReadUnderlyingSecuritySubType (bs:byte[]) (pos:int): (int*UnderlyingSecuritySubType) =
    ReadFieldStr bs pos UnderlyingSecuritySubType.UnderlyingSecuritySubType


let ReadLegSecuritySubType (bs:byte[]) (pos:int): (int*LegSecuritySubType) =
    ReadFieldStr bs pos LegSecuritySubType.LegSecuritySubType


let ReadAllowableOneSidednessPct (bs:byte[]) (pos:int): (int*AllowableOneSidednessPct) =
    ReadFieldDecimal bs pos AllowableOneSidednessPct.AllowableOneSidednessPct


let ReadAllowableOneSidednessValue (bs:byte[]) (pos:int): (int*AllowableOneSidednessValue) =
    ReadFieldDecimal bs pos AllowableOneSidednessValue.AllowableOneSidednessValue


let ReadAllowableOneSidednessCurr (bs:byte[]) (pos:int): (int*AllowableOneSidednessCurr) =
    ReadFieldStr bs pos AllowableOneSidednessCurr.AllowableOneSidednessCurr


let ReadNoTrdRegTimestamps (bs:byte[]) (pos:int): (int*NoTrdRegTimestamps) =
    ReadFieldInt bs pos NoTrdRegTimestamps.NoTrdRegTimestamps


let ReadTrdRegTimestamp (bs:byte[]) (pos:int): (int*TrdRegTimestamp) =
    ReadFieldUTCTimestamp bs pos TrdRegTimestamp.TrdRegTimestamp


let ReadTrdRegTimestampType (bs:byte[]) (pos:int) : (int * TrdRegTimestampType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> TrdRegTimestampType.ExecutionTime
        |"2"B -> TrdRegTimestampType.TimeIn
        |"3"B -> TrdRegTimestampType.TimeOut
        |"4"B -> TrdRegTimestampType.BrokerReceipt
        |"5"B -> TrdRegTimestampType.BrokerExecution
        | x -> failwith (sprintf "ReadTrdRegTimestampType unknown fix tag: %A"  x) 
    pos2, fld


let ReadTrdRegTimestampOrigin (bs:byte[]) (pos:int): (int*TrdRegTimestampOrigin) =
    ReadFieldStr bs pos TrdRegTimestampOrigin.TrdRegTimestampOrigin


let ReadConfirmRefID (bs:byte[]) (pos:int): (int*ConfirmRefID) =
    ReadFieldStr bs pos ConfirmRefID.ConfirmRefID


let ReadConfirmType (bs:byte[]) (pos:int) : (int * ConfirmType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> ConfirmType.Status
        |"2"B -> ConfirmType.Confirmation
        |"3"B -> ConfirmType.ConfirmationRequestRejected
        | x -> failwith (sprintf "ReadConfirmType unknown fix tag: %A"  x) 
    pos2, fld


let ReadConfirmRejReason (bs:byte[]) (pos:int) : (int * ConfirmRejReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> ConfirmRejReason.MismatchedAccount
        |"2"B -> ConfirmRejReason.MissingSettlementInstructions
        |"99"B -> ConfirmRejReason.Other
        | x -> failwith (sprintf "ReadConfirmRejReason unknown fix tag: %A"  x) 
    pos2, fld


let ReadBookingType (bs:byte[]) (pos:int) : (int * BookingType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> BookingType.RegularBooking
        |"1"B -> BookingType.Cfd
        |"2"B -> BookingType.TotalReturnSwap
        | x -> failwith (sprintf "ReadBookingType unknown fix tag: %A"  x) 
    pos2, fld


let ReadIndividualAllocRejCode (bs:byte[]) (pos:int): (int*IndividualAllocRejCode) =
    ReadFieldInt bs pos IndividualAllocRejCode.IndividualAllocRejCode


let ReadSettlInstMsgID (bs:byte[]) (pos:int): (int*SettlInstMsgID) =
    ReadFieldStr bs pos SettlInstMsgID.SettlInstMsgID


let ReadNoSettlInst (bs:byte[]) (pos:int): (int*NoSettlInst) =
    ReadFieldInt bs pos NoSettlInst.NoSettlInst


let ReadLastUpdateTime (bs:byte[]) (pos:int): (int*LastUpdateTime) =
    ReadFieldUTCTimestamp bs pos LastUpdateTime.LastUpdateTime


let ReadAllocSettlInstType (bs:byte[]) (pos:int) : (int * AllocSettlInstType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> AllocSettlInstType.UseDefaultInstructions
        |"1"B -> AllocSettlInstType.DeriveFromParametersProvided
        |"2"B -> AllocSettlInstType.FullDetailsProvided
        |"3"B -> AllocSettlInstType.SsiDbIdsProvided
        |"4"B -> AllocSettlInstType.PhoneForInstructions
        | x -> failwith (sprintf "ReadAllocSettlInstType unknown fix tag: %A"  x) 
    pos2, fld


let ReadNoSettlPartyIDs (bs:byte[]) (pos:int): (int*NoSettlPartyIDs) =
    ReadFieldInt bs pos NoSettlPartyIDs.NoSettlPartyIDs


let ReadSettlPartyID (bs:byte[]) (pos:int): (int*SettlPartyID) =
    ReadFieldStr bs pos SettlPartyID.SettlPartyID


let ReadSettlPartyIDSource (bs:byte[]) (pos:int): (int*SettlPartyIDSource) =
    ReadFieldChar bs pos SettlPartyIDSource.SettlPartyIDSource


let ReadSettlPartyRole (bs:byte[]) (pos:int): (int*SettlPartyRole) =
    ReadFieldInt bs pos SettlPartyRole.SettlPartyRole


let ReadSettlPartySubID (bs:byte[]) (pos:int): (int*SettlPartySubID) =
    ReadFieldStr bs pos SettlPartySubID.SettlPartySubID


let ReadSettlPartySubIDType (bs:byte[]) (pos:int): (int*SettlPartySubIDType) =
    ReadFieldInt bs pos SettlPartySubIDType.SettlPartySubIDType


let ReadDlvyInstType (bs:byte[]) (pos:int) : (int * DlvyInstType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"S"B -> DlvyInstType.Securities
        |"C"B -> DlvyInstType.Cash
        | x -> failwith (sprintf "ReadDlvyInstType unknown fix tag: %A"  x) 
    pos2, fld


let ReadTerminationType (bs:byte[]) (pos:int) : (int * TerminationType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> TerminationType.Overnight
        |"2"B -> TerminationType.Term
        |"3"B -> TerminationType.Flexible
        |"4"B -> TerminationType.Open
        | x -> failwith (sprintf "ReadTerminationType unknown fix tag: %A"  x) 
    pos2, fld


let ReadNextExpectedMsgSeqNum (bs:byte[]) (pos:int): (int*NextExpectedMsgSeqNum) =
    ReadFieldUint32 bs pos NextExpectedMsgSeqNum.NextExpectedMsgSeqNum


let ReadOrdStatusReqID (bs:byte[]) (pos:int): (int*OrdStatusReqID) =
    ReadFieldStr bs pos OrdStatusReqID.OrdStatusReqID


let ReadSettlInstReqID (bs:byte[]) (pos:int): (int*SettlInstReqID) =
    ReadFieldStr bs pos SettlInstReqID.SettlInstReqID


let ReadSettlInstReqRejCode (bs:byte[]) (pos:int) : (int * SettlInstReqRejCode) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> SettlInstReqRejCode.UnableToProcessRequest
        |"1"B -> SettlInstReqRejCode.UnknownAccount
        |"2"B -> SettlInstReqRejCode.NoMatchingSettlementInstructionsFound
        |"99"B -> SettlInstReqRejCode.Other
        | x -> failwith (sprintf "ReadSettlInstReqRejCode unknown fix tag: %A"  x) 
    pos2, fld


let ReadSecondaryAllocID (bs:byte[]) (pos:int): (int*SecondaryAllocID) =
    ReadFieldStr bs pos SecondaryAllocID.SecondaryAllocID


let ReadAllocReportType (bs:byte[]) (pos:int) : (int * AllocReportType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"3"B -> AllocReportType.SellsideCalculatedUsingPreliminary
        |"4"B -> AllocReportType.SellsideCalculatedWithoutPreliminary
        |"5"B -> AllocReportType.WarehouseRecap
        |"8"B -> AllocReportType.RequestToIntermediary
        | x -> failwith (sprintf "ReadAllocReportType unknown fix tag: %A"  x) 
    pos2, fld


let ReadAllocReportRefID (bs:byte[]) (pos:int): (int*AllocReportRefID) =
    ReadFieldStr bs pos AllocReportRefID.AllocReportRefID


let ReadAllocCancReplaceReason (bs:byte[]) (pos:int) : (int * AllocCancReplaceReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> AllocCancReplaceReason.OriginalDetailsIncompleteIncorrect
        |"2"B -> AllocCancReplaceReason.ChangeInUnderlyingOrderDetails
        | x -> failwith (sprintf "ReadAllocCancReplaceReason unknown fix tag: %A"  x) 
    pos2, fld


let ReadCopyMsgIndicator (bs:byte[]) (pos:int): (int*CopyMsgIndicator) =
    ReadFieldBool bs pos CopyMsgIndicator.CopyMsgIndicator


let ReadAllocAccountType (bs:byte[]) (pos:int) : (int * AllocAccountType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadOrderAvgPx (bs:byte[]) (pos:int): (int*OrderAvgPx) =
    ReadFieldDecimal bs pos OrderAvgPx.OrderAvgPx


let ReadOrderBookingQty (bs:byte[]) (pos:int): (int*OrderBookingQty) =
    ReadFieldDecimal bs pos OrderBookingQty.OrderBookingQty


let ReadNoSettlPartySubIDs (bs:byte[]) (pos:int): (int*NoSettlPartySubIDs) =
    ReadFieldInt bs pos NoSettlPartySubIDs.NoSettlPartySubIDs


let ReadNoPartySubIDs (bs:byte[]) (pos:int): (int*NoPartySubIDs) =
    ReadFieldInt bs pos NoPartySubIDs.NoPartySubIDs


let ReadPartySubIDType (bs:byte[]) (pos:int): (int*PartySubIDType) =
    ReadFieldInt bs pos PartySubIDType.PartySubIDType


let ReadNoNestedPartySubIDs (bs:byte[]) (pos:int): (int*NoNestedPartySubIDs) =
    ReadFieldInt bs pos NoNestedPartySubIDs.NoNestedPartySubIDs


let ReadNestedPartySubIDType (bs:byte[]) (pos:int): (int*NestedPartySubIDType) =
    ReadFieldInt bs pos NestedPartySubIDType.NestedPartySubIDType


let ReadNoNested2PartySubIDs (bs:byte[]) (pos:int): (int*NoNested2PartySubIDs) =
    ReadFieldInt bs pos NoNested2PartySubIDs.NoNested2PartySubIDs


let ReadNested2PartySubIDType (bs:byte[]) (pos:int): (int*Nested2PartySubIDType) =
    ReadFieldInt bs pos Nested2PartySubIDType.Nested2PartySubIDType


let ReadAllocIntermedReqType (bs:byte[]) (pos:int) : (int * AllocIntermedReqType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> AllocIntermedReqType.PendingAccept
        |"2"B -> AllocIntermedReqType.PendingRelease
        |"3"B -> AllocIntermedReqType.PendingReversal
        |"4"B -> AllocIntermedReqType.Accept
        |"5"B -> AllocIntermedReqType.BlockLevelReject
        |"6"B -> AllocIntermedReqType.AccountLevelReject
        | x -> failwith (sprintf "ReadAllocIntermedReqType unknown fix tag: %A"  x) 
    pos2, fld


let ReadUnderlyingPx (bs:byte[]) (pos:int): (int*UnderlyingPx) =
    ReadFieldDecimal bs pos UnderlyingPx.UnderlyingPx


let ReadPriceDelta (bs:byte[]) (pos:int): (int*PriceDelta) =
    ReadFieldDecimal bs pos PriceDelta.PriceDelta


let ReadApplQueueMax (bs:byte[]) (pos:int): (int*ApplQueueMax) =
    ReadFieldInt bs pos ApplQueueMax.ApplQueueMax


let ReadApplQueueDepth (bs:byte[]) (pos:int): (int*ApplQueueDepth) =
    ReadFieldInt bs pos ApplQueueDepth.ApplQueueDepth


let ReadApplQueueResolution (bs:byte[]) (pos:int) : (int * ApplQueueResolution) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> ApplQueueResolution.NoActionTaken
        |"1"B -> ApplQueueResolution.QueueFlushed
        |"2"B -> ApplQueueResolution.OverlayLast
        |"3"B -> ApplQueueResolution.EndSession
        | x -> failwith (sprintf "ReadApplQueueResolution unknown fix tag: %A"  x) 
    pos2, fld


let ReadApplQueueAction (bs:byte[]) (pos:int) : (int * ApplQueueAction) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> ApplQueueAction.NoActionTaken
        |"1"B -> ApplQueueAction.QueueFlushed
        |"2"B -> ApplQueueAction.OverlayLast
        |"3"B -> ApplQueueAction.EndSession
        | x -> failwith (sprintf "ReadApplQueueAction unknown fix tag: %A"  x) 
    pos2, fld


let ReadNoAltMDSource (bs:byte[]) (pos:int): (int*NoAltMDSource) =
    ReadFieldInt bs pos NoAltMDSource.NoAltMDSource


let ReadAltMDSourceID (bs:byte[]) (pos:int): (int*AltMDSourceID) =
    ReadFieldStr bs pos AltMDSourceID.AltMDSourceID


let ReadSecondaryTradeReportID (bs:byte[]) (pos:int): (int*SecondaryTradeReportID) =
    ReadFieldStr bs pos SecondaryTradeReportID.SecondaryTradeReportID


let ReadAvgPxIndicator (bs:byte[]) (pos:int) : (int * AvgPxIndicator) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> AvgPxIndicator.NoAveragePricing
        |"1"B -> AvgPxIndicator.TradeIsPartOfAnAveragePriceGroupIdentifiedByTheTradelinkid
        |"2"B -> AvgPxIndicator.LastTradeInTheAveragePriceGroupIdentifiedByTheTradelinkid
        | x -> failwith (sprintf "ReadAvgPxIndicator unknown fix tag: %A"  x) 
    pos2, fld


let ReadTradeLinkID (bs:byte[]) (pos:int): (int*TradeLinkID) =
    ReadFieldStr bs pos TradeLinkID.TradeLinkID


let ReadOrderInputDevice (bs:byte[]) (pos:int): (int*OrderInputDevice) =
    ReadFieldStr bs pos OrderInputDevice.OrderInputDevice


let ReadUnderlyingTradingSessionID (bs:byte[]) (pos:int): (int*UnderlyingTradingSessionID) =
    ReadFieldStr bs pos UnderlyingTradingSessionID.UnderlyingTradingSessionID


let ReadUnderlyingTradingSessionSubID (bs:byte[]) (pos:int): (int*UnderlyingTradingSessionSubID) =
    ReadFieldStr bs pos UnderlyingTradingSessionSubID.UnderlyingTradingSessionSubID


let ReadTradeLegRefID (bs:byte[]) (pos:int): (int*TradeLegRefID) =
    ReadFieldStr bs pos TradeLegRefID.TradeLegRefID


let ReadExchangeRule (bs:byte[]) (pos:int): (int*ExchangeRule) =
    ReadFieldStr bs pos ExchangeRule.ExchangeRule


let ReadTradeAllocIndicator (bs:byte[]) (pos:int) : (int * TradeAllocIndicator) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> TradeAllocIndicator.AllocationNotRequired
        |"1"B -> TradeAllocIndicator.AllocationRequired
        |"2"B -> TradeAllocIndicator.UseAllocationProvidedWithTheTrade
        | x -> failwith (sprintf "ReadTradeAllocIndicator unknown fix tag: %A"  x) 
    pos2, fld


let ReadExpirationCycle (bs:byte[]) (pos:int) : (int * ExpirationCycle) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> ExpirationCycle.ExpireOnTradingSessionClose
        |"1"B -> ExpirationCycle.ExpireOnTradingSessionOpen
        | x -> failwith (sprintf "ReadExpirationCycle unknown fix tag: %A"  x) 
    pos2, fld


let ReadTrdType (bs:byte[]) (pos:int) : (int * TrdType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadTrdSubType (bs:byte[]) (pos:int): (int*TrdSubType) =
    ReadFieldInt bs pos TrdSubType.TrdSubType


let ReadTransferReason (bs:byte[]) (pos:int): (int*TransferReason) =
    ReadFieldStr bs pos TransferReason.TransferReason


let ReadAsgnReqID (bs:byte[]) (pos:int): (int*AsgnReqID) =
    ReadFieldStr bs pos AsgnReqID.AsgnReqID


let ReadTotNumAssignmentReports (bs:byte[]) (pos:int): (int*TotNumAssignmentReports) =
    ReadFieldInt bs pos TotNumAssignmentReports.TotNumAssignmentReports


let ReadAsgnRptID (bs:byte[]) (pos:int): (int*AsgnRptID) =
    ReadFieldStr bs pos AsgnRptID.AsgnRptID


let ReadThresholdAmount (bs:byte[]) (pos:int): (int*ThresholdAmount) =
    ReadFieldDecimal bs pos ThresholdAmount.ThresholdAmount


let ReadPegMoveType (bs:byte[]) (pos:int) : (int * PegMoveType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> PegMoveType.Floating
        |"1"B -> PegMoveType.Fixed
        | x -> failwith (sprintf "ReadPegMoveType unknown fix tag: %A"  x) 
    pos2, fld


let ReadPegOffsetType (bs:byte[]) (pos:int) : (int * PegOffsetType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> PegOffsetType.Price
        |"1"B -> PegOffsetType.BasisPoints
        |"2"B -> PegOffsetType.Ticks
        |"3"B -> PegOffsetType.PriceTierLevel
        | x -> failwith (sprintf "ReadPegOffsetType unknown fix tag: %A"  x) 
    pos2, fld


let ReadPegLimitType (bs:byte[]) (pos:int) : (int * PegLimitType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> PegLimitType.OrBetter
        |"1"B -> PegLimitType.Strict
        |"2"B -> PegLimitType.OrWorse
        | x -> failwith (sprintf "ReadPegLimitType unknown fix tag: %A"  x) 
    pos2, fld


let ReadPegRoundDirection (bs:byte[]) (pos:int) : (int * PegRoundDirection) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> PegRoundDirection.MoreAggressive
        |"2"B -> PegRoundDirection.MorePassive
        | x -> failwith (sprintf "ReadPegRoundDirection unknown fix tag: %A"  x) 
    pos2, fld


let ReadPeggedPrice (bs:byte[]) (pos:int): (int*PeggedPrice) =
    ReadFieldDecimal bs pos PeggedPrice.PeggedPrice


let ReadPegScope (bs:byte[]) (pos:int) : (int * PegScope) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> PegScope.Local
        |"2"B -> PegScope.National
        |"3"B -> PegScope.Global
        |"4"B -> PegScope.NationalExcludingLocal
        | x -> failwith (sprintf "ReadPegScope unknown fix tag: %A"  x) 
    pos2, fld


let ReadDiscretionMoveType (bs:byte[]) (pos:int) : (int * DiscretionMoveType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> DiscretionMoveType.Floating
        |"1"B -> DiscretionMoveType.Fixed
        | x -> failwith (sprintf "ReadDiscretionMoveType unknown fix tag: %A"  x) 
    pos2, fld


let ReadDiscretionOffsetType (bs:byte[]) (pos:int) : (int * DiscretionOffsetType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> DiscretionOffsetType.Price
        |"1"B -> DiscretionOffsetType.BasisPoints
        |"2"B -> DiscretionOffsetType.Ticks
        |"3"B -> DiscretionOffsetType.PriceTierLevel
        | x -> failwith (sprintf "ReadDiscretionOffsetType unknown fix tag: %A"  x) 
    pos2, fld


let ReadDiscretionLimitType (bs:byte[]) (pos:int) : (int * DiscretionLimitType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> DiscretionLimitType.OrBetter
        |"1"B -> DiscretionLimitType.Strict
        |"2"B -> DiscretionLimitType.OrWorse
        | x -> failwith (sprintf "ReadDiscretionLimitType unknown fix tag: %A"  x) 
    pos2, fld


let ReadDiscretionRoundDirection (bs:byte[]) (pos:int) : (int * DiscretionRoundDirection) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> DiscretionRoundDirection.MoreAggressive
        |"2"B -> DiscretionRoundDirection.MorePassive
        | x -> failwith (sprintf "ReadDiscretionRoundDirection unknown fix tag: %A"  x) 
    pos2, fld


let ReadDiscretionPrice (bs:byte[]) (pos:int): (int*DiscretionPrice) =
    ReadFieldDecimal bs pos DiscretionPrice.DiscretionPrice


let ReadDiscretionScope (bs:byte[]) (pos:int) : (int * DiscretionScope) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> DiscretionScope.Local
        |"2"B -> DiscretionScope.National
        |"3"B -> DiscretionScope.Global
        |"4"B -> DiscretionScope.NationalExcludingLocal
        | x -> failwith (sprintf "ReadDiscretionScope unknown fix tag: %A"  x) 
    pos2, fld


let ReadTargetStrategy (bs:byte[]) (pos:int): (int*TargetStrategy) =
    ReadFieldInt bs pos TargetStrategy.TargetStrategy


let ReadTargetStrategyParameters (bs:byte[]) (pos:int): (int*TargetStrategyParameters) =
    ReadFieldStr bs pos TargetStrategyParameters.TargetStrategyParameters


let ReadParticipationRate (bs:byte[]) (pos:int): (int*ParticipationRate) =
    ReadFieldDecimal bs pos ParticipationRate.ParticipationRate


let ReadTargetStrategyPerformance (bs:byte[]) (pos:int): (int*TargetStrategyPerformance) =
    ReadFieldDecimal bs pos TargetStrategyPerformance.TargetStrategyPerformance


let ReadLastLiquidityInd (bs:byte[]) (pos:int) : (int * LastLiquidityInd) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> LastLiquidityInd.AddedLiquidity
        |"2"B -> LastLiquidityInd.RemovedLiquidity
        |"3"B -> LastLiquidityInd.LiquidityRoutedOut
        | x -> failwith (sprintf "ReadLastLiquidityInd unknown fix tag: %A"  x) 
    pos2, fld


let ReadPublishTrdIndicator (bs:byte[]) (pos:int): (int*PublishTrdIndicator) =
    ReadFieldBool bs pos PublishTrdIndicator.PublishTrdIndicator


let ReadShortSaleReason (bs:byte[]) (pos:int) : (int * ShortSaleReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> ShortSaleReason.DealerSoldShort
        |"1"B -> ShortSaleReason.DealerSoldShortExempt
        |"2"B -> ShortSaleReason.SellingCustomerSoldShort
        |"3"B -> ShortSaleReason.SellingCustomerSoldShortExempt
        |"4"B -> ShortSaleReason.QualifedServiceRepresentativeOrAutomaticGiveupContraSideSoldShort
        |"5"B -> ShortSaleReason.QsrOrAguContraSideSoldShortExempt
        | x -> failwith (sprintf "ReadShortSaleReason unknown fix tag: %A"  x) 
    pos2, fld


let ReadQtyType (bs:byte[]) (pos:int) : (int * QtyType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> QtyType.Units
        |"1"B -> QtyType.Contracts
        | x -> failwith (sprintf "ReadQtyType unknown fix tag: %A"  x) 
    pos2, fld


let ReadSecondaryTrdType (bs:byte[]) (pos:int): (int*SecondaryTrdType) =
    ReadFieldInt bs pos SecondaryTrdType.SecondaryTrdType


let ReadTradeReportType (bs:byte[]) (pos:int) : (int * TradeReportType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadAllocNoOrdersType (bs:byte[]) (pos:int) : (int * AllocNoOrdersType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> AllocNoOrdersType.NotSpecified
        |"1"B -> AllocNoOrdersType.ExplicitListProvided
        | x -> failwith (sprintf "ReadAllocNoOrdersType unknown fix tag: %A"  x) 
    pos2, fld


let ReadSharedCommission (bs:byte[]) (pos:int): (int*SharedCommission) =
    ReadFieldDecimal bs pos SharedCommission.SharedCommission


let ReadConfirmReqID (bs:byte[]) (pos:int): (int*ConfirmReqID) =
    ReadFieldStr bs pos ConfirmReqID.ConfirmReqID


let ReadAvgParPx (bs:byte[]) (pos:int): (int*AvgParPx) =
    ReadFieldDecimal bs pos AvgParPx.AvgParPx


let ReadReportedPx (bs:byte[]) (pos:int): (int*ReportedPx) =
    ReadFieldDecimal bs pos ReportedPx.ReportedPx


let ReadNoCapacities (bs:byte[]) (pos:int): (int*NoCapacities) =
    ReadFieldInt bs pos NoCapacities.NoCapacities


let ReadOrderCapacityQty (bs:byte[]) (pos:int): (int*OrderCapacityQty) =
    ReadFieldDecimal bs pos OrderCapacityQty.OrderCapacityQty


let ReadNoEvents (bs:byte[]) (pos:int): (int*NoEvents) =
    ReadFieldInt bs pos NoEvents.NoEvents


let ReadEventType (bs:byte[]) (pos:int) : (int * EventType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> EventType.Put
        |"2"B -> EventType.Call
        |"3"B -> EventType.Tender
        |"4"B -> EventType.SinkingFundCall
        |"99"B -> EventType.Other
        | x -> failwith (sprintf "ReadEventType unknown fix tag: %A"  x) 
    pos2, fld


let ReadEventDate (bs:byte[]) (pos:int): (int*EventDate) =
    ReadFieldLocalMktDate bs pos EventDate.EventDate


let ReadEventPx (bs:byte[]) (pos:int): (int*EventPx) =
    ReadFieldDecimal bs pos EventPx.EventPx


let ReadEventText (bs:byte[]) (pos:int): (int*EventText) =
    ReadFieldStr bs pos EventText.EventText


let ReadPctAtRisk (bs:byte[]) (pos:int): (int*PctAtRisk) =
    ReadFieldDecimal bs pos PctAtRisk.PctAtRisk


let ReadNoInstrAttrib (bs:byte[]) (pos:int): (int*NoInstrAttrib) =
    ReadFieldInt bs pos NoInstrAttrib.NoInstrAttrib


let ReadInstrAttribType (bs:byte[]) (pos:int) : (int * InstrAttribType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadInstrAttribValue (bs:byte[]) (pos:int): (int*InstrAttribValue) =
    ReadFieldStr bs pos InstrAttribValue.InstrAttribValue


let ReadDatedDate (bs:byte[]) (pos:int): (int*DatedDate) =
    ReadFieldLocalMktDate bs pos DatedDate.DatedDate


let ReadInterestAccrualDate (bs:byte[]) (pos:int): (int*InterestAccrualDate) =
    ReadFieldLocalMktDate bs pos InterestAccrualDate.InterestAccrualDate


let ReadCPProgram (bs:byte[]) (pos:int): (int*CPProgram) =
    ReadFieldInt bs pos CPProgram.CPProgram


let ReadCPRegType (bs:byte[]) (pos:int): (int*CPRegType) =
    ReadFieldStr bs pos CPRegType.CPRegType


let ReadUnderlyingCPProgram (bs:byte[]) (pos:int): (int*UnderlyingCPProgram) =
    ReadFieldStr bs pos UnderlyingCPProgram.UnderlyingCPProgram


let ReadUnderlyingCPRegType (bs:byte[]) (pos:int): (int*UnderlyingCPRegType) =
    ReadFieldStr bs pos UnderlyingCPRegType.UnderlyingCPRegType


let ReadUnderlyingQty (bs:byte[]) (pos:int): (int*UnderlyingQty) =
    ReadFieldDecimal bs pos UnderlyingQty.UnderlyingQty


let ReadTrdMatchID (bs:byte[]) (pos:int): (int*TrdMatchID) =
    ReadFieldStr bs pos TrdMatchID.TrdMatchID


let ReadSecondaryTradeReportRefID (bs:byte[]) (pos:int): (int*SecondaryTradeReportRefID) =
    ReadFieldStr bs pos SecondaryTradeReportRefID.SecondaryTradeReportRefID


let ReadUnderlyingDirtyPrice (bs:byte[]) (pos:int): (int*UnderlyingDirtyPrice) =
    ReadFieldDecimal bs pos UnderlyingDirtyPrice.UnderlyingDirtyPrice


let ReadUnderlyingEndPrice (bs:byte[]) (pos:int): (int*UnderlyingEndPrice) =
    ReadFieldDecimal bs pos UnderlyingEndPrice.UnderlyingEndPrice


let ReadUnderlyingStartValue (bs:byte[]) (pos:int): (int*UnderlyingStartValue) =
    ReadFieldDecimal bs pos UnderlyingStartValue.UnderlyingStartValue


let ReadUnderlyingCurrentValue (bs:byte[]) (pos:int): (int*UnderlyingCurrentValue) =
    ReadFieldDecimal bs pos UnderlyingCurrentValue.UnderlyingCurrentValue


let ReadUnderlyingEndValue (bs:byte[]) (pos:int): (int*UnderlyingEndValue) =
    ReadFieldDecimal bs pos UnderlyingEndValue.UnderlyingEndValue


let ReadNoUnderlyingStips (bs:byte[]) (pos:int): (int*NoUnderlyingStips) =
    ReadFieldInt bs pos NoUnderlyingStips.NoUnderlyingStips


let ReadUnderlyingStipType (bs:byte[]) (pos:int): (int*UnderlyingStipType) =
    ReadFieldStr bs pos UnderlyingStipType.UnderlyingStipType


let ReadUnderlyingStipValue (bs:byte[]) (pos:int): (int*UnderlyingStipValue) =
    ReadFieldStr bs pos UnderlyingStipValue.UnderlyingStipValue


let ReadMaturityNetMoney (bs:byte[]) (pos:int): (int*MaturityNetMoney) =
    ReadFieldDecimal bs pos MaturityNetMoney.MaturityNetMoney


let ReadMiscFeeBasis (bs:byte[]) (pos:int) : (int * MiscFeeBasis) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> MiscFeeBasis.Absolute
        |"1"B -> MiscFeeBasis.PerUnit
        |"2"B -> MiscFeeBasis.Percentage
        | x -> failwith (sprintf "ReadMiscFeeBasis unknown fix tag: %A"  x) 
    pos2, fld


let ReadTotNoAllocs (bs:byte[]) (pos:int): (int*TotNoAllocs) =
    ReadFieldInt bs pos TotNoAllocs.TotNoAllocs


let ReadLastFragment (bs:byte[]) (pos:int): (int*LastFragment) =
    ReadFieldBool bs pos LastFragment.LastFragment


let ReadCollReqID (bs:byte[]) (pos:int): (int*CollReqID) =
    ReadFieldStr bs pos CollReqID.CollReqID


let ReadCollAsgnReason (bs:byte[]) (pos:int) : (int * CollAsgnReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadCollInquiryQualifier (bs:byte[]) (pos:int) : (int * CollInquiryQualifier) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadNoTrades (bs:byte[]) (pos:int): (int*NoTrades) =
    ReadFieldInt bs pos NoTrades.NoTrades


let ReadMarginRatio (bs:byte[]) (pos:int): (int*MarginRatio) =
    ReadFieldDecimal bs pos MarginRatio.MarginRatio


let ReadMarginExcess (bs:byte[]) (pos:int): (int*MarginExcess) =
    ReadFieldDecimal bs pos MarginExcess.MarginExcess


let ReadTotalNetValue (bs:byte[]) (pos:int): (int*TotalNetValue) =
    ReadFieldDecimal bs pos TotalNetValue.TotalNetValue


let ReadCashOutstanding (bs:byte[]) (pos:int): (int*CashOutstanding) =
    ReadFieldDecimal bs pos CashOutstanding.CashOutstanding


let ReadCollAsgnID (bs:byte[]) (pos:int): (int*CollAsgnID) =
    ReadFieldStr bs pos CollAsgnID.CollAsgnID


let ReadCollAsgnTransType (bs:byte[]) (pos:int) : (int * CollAsgnTransType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> CollAsgnTransType.New
        |"1"B -> CollAsgnTransType.Replace
        |"2"B -> CollAsgnTransType.Cancel
        |"3"B -> CollAsgnTransType.Release
        |"4"B -> CollAsgnTransType.Reverse
        | x -> failwith (sprintf "ReadCollAsgnTransType unknown fix tag: %A"  x) 
    pos2, fld


let ReadCollRespID (bs:byte[]) (pos:int): (int*CollRespID) =
    ReadFieldStr bs pos CollRespID.CollRespID


let ReadCollAsgnRespType (bs:byte[]) (pos:int) : (int * CollAsgnRespType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> CollAsgnRespType.Received
        |"1"B -> CollAsgnRespType.Accepted
        |"2"B -> CollAsgnRespType.Declined
        |"3"B -> CollAsgnRespType.Rejected
        | x -> failwith (sprintf "ReadCollAsgnRespType unknown fix tag: %A"  x) 
    pos2, fld


let ReadCollAsgnRejectReason (bs:byte[]) (pos:int) : (int * CollAsgnRejectReason) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadCollAsgnRefID (bs:byte[]) (pos:int): (int*CollAsgnRefID) =
    ReadFieldStr bs pos CollAsgnRefID.CollAsgnRefID


let ReadCollRptID (bs:byte[]) (pos:int): (int*CollRptID) =
    ReadFieldStr bs pos CollRptID.CollRptID


let ReadCollInquiryID (bs:byte[]) (pos:int): (int*CollInquiryID) =
    ReadFieldStr bs pos CollInquiryID.CollInquiryID


let ReadCollStatus (bs:byte[]) (pos:int) : (int * CollStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> CollStatus.Unassigned
        |"1"B -> CollStatus.PartiallyAssigned
        |"2"B -> CollStatus.AssignmentProposed
        |"3"B -> CollStatus.Assigned
        |"4"B -> CollStatus.Challenged
        | x -> failwith (sprintf "ReadCollStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadTotNumReports (bs:byte[]) (pos:int): (int*TotNumReports) =
    ReadFieldInt bs pos TotNumReports.TotNumReports


let ReadLastRptRequested (bs:byte[]) (pos:int): (int*LastRptRequested) =
    ReadFieldBool bs pos LastRptRequested.LastRptRequested


let ReadAgreementDesc (bs:byte[]) (pos:int): (int*AgreementDesc) =
    ReadFieldStr bs pos AgreementDesc.AgreementDesc


let ReadAgreementID (bs:byte[]) (pos:int): (int*AgreementID) =
    ReadFieldStr bs pos AgreementID.AgreementID


let ReadAgreementDate (bs:byte[]) (pos:int): (int*AgreementDate) =
    ReadFieldLocalMktDate bs pos AgreementDate.AgreementDate


let ReadStartDate (bs:byte[]) (pos:int): (int*StartDate) =
    ReadFieldLocalMktDate bs pos StartDate.StartDate


let ReadEndDate (bs:byte[]) (pos:int): (int*EndDate) =
    ReadFieldLocalMktDate bs pos EndDate.EndDate


let ReadAgreementCurrency (bs:byte[]) (pos:int): (int*AgreementCurrency) =
    ReadFieldStr bs pos AgreementCurrency.AgreementCurrency


let ReadDeliveryType (bs:byte[]) (pos:int) : (int * DeliveryType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> DeliveryType.VersusPayment
        |"1"B -> DeliveryType.Free
        |"2"B -> DeliveryType.TriParty
        |"3"B -> DeliveryType.HoldInCustody
        | x -> failwith (sprintf "ReadDeliveryType unknown fix tag: %A"  x) 
    pos2, fld


let ReadEndAccruedInterestAmt (bs:byte[]) (pos:int): (int*EndAccruedInterestAmt) =
    ReadFieldDecimal bs pos EndAccruedInterestAmt.EndAccruedInterestAmt


let ReadStartCash (bs:byte[]) (pos:int): (int*StartCash) =
    ReadFieldDecimal bs pos StartCash.StartCash


let ReadEndCash (bs:byte[]) (pos:int): (int*EndCash) =
    ReadFieldDecimal bs pos EndCash.EndCash


let ReadUserRequestID (bs:byte[]) (pos:int): (int*UserRequestID) =
    ReadFieldStr bs pos UserRequestID.UserRequestID


let ReadUserRequestType (bs:byte[]) (pos:int) : (int * UserRequestType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> UserRequestType.Logonuser
        |"2"B -> UserRequestType.Logoffuser
        |"3"B -> UserRequestType.Changepasswordforuser
        |"4"B -> UserRequestType.RequestIndividualUserStatus
        | x -> failwith (sprintf "ReadUserRequestType unknown fix tag: %A"  x) 
    pos2, fld


let ReadNewPassword (bs:byte[]) (pos:int): (int*NewPassword) =
    ReadFieldStr bs pos NewPassword.NewPassword


let ReadUserStatus (bs:byte[]) (pos:int) : (int * UserStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> UserStatus.LoggedIn
        |"2"B -> UserStatus.NotLoggedIn
        |"3"B -> UserStatus.UserNotRecognised
        |"4"B -> UserStatus.PasswordIncorrect
        |"5"B -> UserStatus.PasswordChanged
        |"6"B -> UserStatus.Other
        | x -> failwith (sprintf "ReadUserStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadUserStatusText (bs:byte[]) (pos:int): (int*UserStatusText) =
    ReadFieldStr bs pos UserStatusText.UserStatusText


let ReadStatusValue (bs:byte[]) (pos:int) : (int * StatusValue) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> StatusValue.Connected
        |"2"B -> StatusValue.NotConnectedDownExpectedUp
        |"3"B -> StatusValue.NotConnectedDownExpectedDown
        |"4"B -> StatusValue.InProcess
        | x -> failwith (sprintf "ReadStatusValue unknown fix tag: %A"  x) 
    pos2, fld


let ReadStatusText (bs:byte[]) (pos:int): (int*StatusText) =
    ReadFieldStr bs pos StatusText.StatusText


let ReadRefCompID (bs:byte[]) (pos:int): (int*RefCompID) =
    ReadFieldStr bs pos RefCompID.RefCompID


let ReadRefSubID (bs:byte[]) (pos:int): (int*RefSubID) =
    ReadFieldStr bs pos RefSubID.RefSubID


let ReadNetworkResponseID (bs:byte[]) (pos:int): (int*NetworkResponseID) =
    ReadFieldStr bs pos NetworkResponseID.NetworkResponseID


let ReadNetworkRequestID (bs:byte[]) (pos:int): (int*NetworkRequestID) =
    ReadFieldStr bs pos NetworkRequestID.NetworkRequestID


let ReadLastNetworkResponseID (bs:byte[]) (pos:int): (int*LastNetworkResponseID) =
    ReadFieldStr bs pos LastNetworkResponseID.LastNetworkResponseID


let ReadNetworkRequestType (bs:byte[]) (pos:int) : (int * NetworkRequestType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> NetworkRequestType.Snapshot
        |"2"B -> NetworkRequestType.Subscribe
        |"4"B -> NetworkRequestType.StopSubscribing
        |"8"B -> NetworkRequestType.LevelOfDetail
        | x -> failwith (sprintf "ReadNetworkRequestType unknown fix tag: %A"  x) 
    pos2, fld


let ReadNoCompIDs (bs:byte[]) (pos:int): (int*NoCompIDs) =
    ReadFieldInt bs pos NoCompIDs.NoCompIDs


let ReadNetworkStatusResponseType (bs:byte[]) (pos:int) : (int * NetworkStatusResponseType) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> NetworkStatusResponseType.Full
        |"2"B -> NetworkStatusResponseType.IncrementalUpdate
        | x -> failwith (sprintf "ReadNetworkStatusResponseType unknown fix tag: %A"  x) 
    pos2, fld


let ReadNoCollInquiryQualifier (bs:byte[]) (pos:int): (int*NoCollInquiryQualifier) =
    ReadFieldInt bs pos NoCollInquiryQualifier.NoCollInquiryQualifier


let ReadTrdRptStatus (bs:byte[]) (pos:int) : (int * TrdRptStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> TrdRptStatus.Accepted
        |"1"B -> TrdRptStatus.Rejected
        | x -> failwith (sprintf "ReadTrdRptStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadAffirmStatus (bs:byte[]) (pos:int) : (int * AffirmStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"1"B -> AffirmStatus.Received
        |"2"B -> AffirmStatus.ConfirmRejected
        |"3"B -> AffirmStatus.Affirmed
        | x -> failwith (sprintf "ReadAffirmStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadUnderlyingStrikeCurrency (bs:byte[]) (pos:int): (int*UnderlyingStrikeCurrency) =
    ReadFieldStr bs pos UnderlyingStrikeCurrency.UnderlyingStrikeCurrency


let ReadLegStrikeCurrency (bs:byte[]) (pos:int): (int*LegStrikeCurrency) =
    ReadFieldStr bs pos LegStrikeCurrency.LegStrikeCurrency


let ReadTimeBracket (bs:byte[]) (pos:int): (int*TimeBracket) =
    ReadFieldStr bs pos TimeBracket.TimeBracket


let ReadCollAction (bs:byte[]) (pos:int) : (int * CollAction) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> CollAction.Retain
        |"1"B -> CollAction.Add
        |"2"B -> CollAction.Remove
        | x -> failwith (sprintf "ReadCollAction unknown fix tag: %A"  x) 
    pos2, fld


let ReadCollInquiryStatus (bs:byte[]) (pos:int) : (int * CollInquiryStatus) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
    let fld = 
        match valIn with
        |"0"B -> CollInquiryStatus.Accepted
        |"1"B -> CollInquiryStatus.AcceptedWithWarnings
        |"2"B -> CollInquiryStatus.Completed
        |"3"B -> CollInquiryStatus.CompletedWithWarnings
        |"4"B -> CollInquiryStatus.Rejected
        | x -> failwith (sprintf "ReadCollInquiryStatus unknown fix tag: %A"  x) 
    pos2, fld


let ReadCollInquiryResult (bs:byte[]) (pos:int) : (int * CollInquiryResult) =
    let pos2, valIn = FIXBuf.readValAfterTagValSep bs pos
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
    pos2, fld


let ReadStrikeCurrency (bs:byte[]) (pos:int): (int*StrikeCurrency) =
    ReadFieldStr bs pos StrikeCurrency.StrikeCurrency


let ReadNoNested3PartyIDs (bs:byte[]) (pos:int): (int*NoNested3PartyIDs) =
    ReadFieldInt bs pos NoNested3PartyIDs.NoNested3PartyIDs


let ReadNested3PartyID (bs:byte[]) (pos:int): (int*Nested3PartyID) =
    ReadFieldStr bs pos Nested3PartyID.Nested3PartyID


let ReadNested3PartyIDSource (bs:byte[]) (pos:int): (int*Nested3PartyIDSource) =
    ReadFieldChar bs pos Nested3PartyIDSource.Nested3PartyIDSource


let ReadNested3PartyRole (bs:byte[]) (pos:int): (int*Nested3PartyRole) =
    ReadFieldInt bs pos Nested3PartyRole.Nested3PartyRole


let ReadNoNested3PartySubIDs (bs:byte[]) (pos:int): (int*NoNested3PartySubIDs) =
    ReadFieldInt bs pos NoNested3PartySubIDs.NoNested3PartySubIDs


let ReadNested3PartySubID (bs:byte[]) (pos:int): (int*Nested3PartySubID) =
    ReadFieldStr bs pos Nested3PartySubID.Nested3PartySubID


let ReadNested3PartySubIDType (bs:byte[]) (pos:int): (int*Nested3PartySubIDType) =
    ReadFieldInt bs pos Nested3PartySubIDType.Nested3PartySubIDType


let ReadLegContractSettlMonth (bs:byte[]) (pos:int): (int*LegContractSettlMonth) =
    ReadFieldMonthYear bs pos LegContractSettlMonth.LegContractSettlMonth


let ReadLegInterestAccrualDate (bs:byte[]) (pos:int): (int*LegInterestAccrualDate) =
    ReadFieldLocalMktDate bs pos LegInterestAccrualDate.LegInterestAccrualDate


