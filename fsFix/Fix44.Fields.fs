module Fix44.Fields


open UTCDateTime
open MonthYear


type Account =
    |Account of string
     member x.Value = let (Account v) = x in v


type AdvId =
    |AdvId of string
     member x.Value = let (AdvId v) = x in v


type AdvRefID =
    |AdvRefID of string
     member x.Value = let (AdvRefID v) = x in v


type AdvSide =
    | Buy
    | Sell
    | Cross
    | Trade


type AdvTransType =
    | New
    | Cancel
    | Replace


type AvgPx =
    |AvgPx of decimal
     member x.Value = let (AvgPx v) = x in v


type BeginSeqNo =
    |BeginSeqNo of uint32
     member x.Value = let (BeginSeqNo v) = x in v


type BeginString =
    |BeginString of string
     member x.Value = let (BeginString v) = x in v


type BodyLength =
    |BodyLength of uint32
     member x.Value = let (BodyLength v) = x in v


type CheckSum =
    |CheckSum of string
     member x.Value = let (CheckSum v) = x in v


type ClOrdID =
    |ClOrdID of string
     member x.Value = let (ClOrdID v) = x in v


type Commission =
    |Commission of decimal
     member x.Value = let (Commission v) = x in v


type CommType =
    | PerUnit
    | Percentage
    | Absolute
    | PercentageWaivedCashDiscount
    | PercentageWaivedEnhancedUnits
    | PointsPerBondOrOrContract


type CumQty =
    |CumQty of decimal
     member x.Value = let (CumQty v) = x in v


type Currency =
    |Currency of string
     member x.Value = let (Currency v) = x in v


type EndSeqNo =
    |EndSeqNo of uint32
     member x.Value = let (EndSeqNo v) = x in v


type ExecID =
    |ExecID of string
     member x.Value = let (ExecID v) = x in v


type ExecInst =
    | NotHeld
    | Work
    | GoAlong
    | OverTheDay
    | Held
    | ParticipateDontInitiate
    | StrictScale
    | TryToScale
    | StayOnBidside
    | StayOnOfferside
    | NoCross
    | OkToCross
    | CallFirst
    | PercentOfVolume
    | DoNotIncrease
    | DoNotReduce
    | AllOrNone
    | ReinstateOnSystemFailure
    | InstitutionsOnly
    | ReinstateOnTradingHalt
    | CancelOnTradingHalt
    | LastPeg
    | MidPrice
    | NonNegotiable
    | OpeningPeg
    | MarketPeg
    | CancelOnSystemFailure
    | PrimaryPeg
    | Suspend
    | FixedPegToLocalBestBidOrOfferAtTimeOfOrder
    | CustomerDisplayInstruction
    | Netting
    | PegToVwap
    | TradeAlong
    | TryToStop
    | CancelIfNotBest
    | TrailingStopPeg
    | StrictLimit
    | IgnorePriceValidityChecks
    | PegToLimitPrice
    | WorkToTargetStrategy


type ExecRefID =
    |ExecRefID of string
     member x.Value = let (ExecRefID v) = x in v


type HandlInst =
    | AutomatedExecutionOrderPrivate
    | AutomatedExecutionOrderPublic
    | ManualOrder


type SecurityIDSource =
    | Cusip
    | Sedol
    | Quik
    | IsinNumber
    | RicCode
    | IsoCurrencyCode
    | IsoCountryCode
    | ExchangeSymbol
    | ConsolidatedTapeAssociation
    | BloombergSymbol
    | Wertpapier
    | Dutch
    | Valoren
    | Sicovam
    | Belgian
    | Common
    | ClearingHouseClearingOrganization
    | IsdaFpmlProductSpecification
    | OptionsPriceReportingAuthority


type IOIid =
    |IOIid of string
     member x.Value = let (IOIid v) = x in v


type IOIQltyInd =
    | Low
    | Medium
    | High


type IOIRefID =
    |IOIRefID of string
     member x.Value = let (IOIRefID v) = x in v


type IOIQty =
    |IOIQty of string
     member x.Value = let (IOIQty v) = x in v


type IOITransType =
    | New
    | Cancel
    | Replace


type LastCapacity =
    | Agent
    | CrossAsAgent
    | CrossAsPrincipal
    | Principal


type LastMkt =
    |LastMkt of string
     member x.Value = let (LastMkt v) = x in v


type LastPx =
    |LastPx of decimal
     member x.Value = let (LastPx v) = x in v


type LastQty =
    |LastQty of decimal
     member x.Value = let (LastQty v) = x in v


type LinesOfText =
    |LinesOfText of int
     member x.Value = let (LinesOfText v) = x in v


type MsgSeqNum =
    |MsgSeqNum of uint32
     member x.Value = let (MsgSeqNum v) = x in v


type MsgType =
    | Heartbeat
    | TestRequest
    | ResendRequest
    | Reject
    | SequenceReset
    | Logout
    | IndicationOfInterest
    | Advertisement
    | ExecutionReport
    | OrderCancelReject
    | Logon
    | News
    | Email
    | OrderSingle
    | OrderList
    | OrderCancelRequest
    | OrderCancelReplaceRequest
    | OrderStatusRequest
    | AllocationInstruction
    | ListCancelRequest
    | ListExecute
    | ListStatusRequest
    | ListStatus
    | AllocationInstructionAck
    | DontKnowTrade
    | QuoteRequest
    | Quote
    | SettlementInstructions
    | MarketDataRequest
    | MarketDataSnapshotFullRefresh
    | MarketDataIncrementalRefresh
    | MarketDataRequestReject
    | QuoteCancel
    | QuoteStatusRequest
    | MassQuoteAcknowledgement
    | SecurityDefinitionRequest
    | SecurityDefinition
    | SecurityStatusRequest
    | SecurityStatus
    | TradingSessionStatusRequest
    | TradingSessionStatus
    | MassQuote
    | BusinessMessageReject
    | BidRequest
    | BidResponse
    | ListStrikePrice
    | XmlMessage
    | RegistrationInstructions
    | RegistrationInstructionsResponse
    | OrderMassCancelRequest
    | OrderMassCancelReport
    | NewOrderCross
    | CrossOrderCancelReplaceRequest
    | CrossOrderCancelRequest
    | SecurityTypeRequest
    | SecurityTypes
    | SecurityListRequest
    | SecurityList
    | DerivativeSecurityListRequest
    | DerivativeSecurityList
    | NewOrderMultileg
    | MultilegOrderCancelReplace
    | TradeCaptureReportRequest
    | TradeCaptureReport
    | OrderMassStatusRequest
    | QuoteRequestReject
    | RfqRequest
    | QuoteStatusReport
    | QuoteResponse
    | Confirmation
    | PositionMaintenanceRequest
    | PositionMaintenanceReport
    | RequestForPositions
    | RequestForPositionsAck
    | PositionReport
    | TradeCaptureReportRequestAck
    | TradeCaptureReportAck
    | AllocationReport
    | AllocationReportAck
    | ConfirmationAck
    | SettlementInstructionRequest
    | AssignmentReport
    | CollateralRequest
    | CollateralAssignment
    | CollateralResponse
    | CollateralReport
    | CollateralInquiry
    | NetworkStatusRequest
    | NetworkStatusResponse
    | UserRequest
    | UserResponse
    | CollateralInquiryAck
    | ConfirmationRequest


type NewSeqNo =
    |NewSeqNo of uint32
     member x.Value = let (NewSeqNo v) = x in v


type OrderID =
    |OrderID of string
     member x.Value = let (OrderID v) = x in v


type OrderQty =
    |OrderQty of decimal
     member x.Value = let (OrderQty v) = x in v


type OrdStatus =
    | New
    | PartiallyFilled
    | Filled
    | DoneForDay
    | Canceled
    | Replaced
    | PendingCancel
    | Stopped
    | Rejected
    | Suspended
    | PendingNew
    | Calculated
    | Expired
    | AcceptedForBidding
    | PendingReplace


type OrdType =
    | Market
    | Limit
    | Stop
    | StopLimit
    | MarketOnClose
    | WithOrWithout
    | LimitOrBetter
    | LimitWithOrWithout
    | OnBasis
    | OnClose
    | LimitOnClose
    | ForexMarket
    | PreviouslyQuoted
    | PreviouslyIndicated
    | ForexLimit
    | ForexSwap
    | ForexPreviouslyQuoted
    | Funari
    | MarketIfTouched
    | MarketWithLeftoverAsLimit
    | PreviousFundValuationPoint
    | NextFundValuationPoint
    | Pegged


type OrigClOrdID =
    |OrigClOrdID of string
     member x.Value = let (OrigClOrdID v) = x in v


type OrigTime =
    |OrigTime of UTCTimestamp
     member x.Value = let (OrigTime v) = x in v


type PossDupFlag =
    |PossDupFlag of bool
     member x.Value = let (PossDupFlag v) = x in v


type Price =
    |Price of decimal
     member x.Value = let (Price v) = x in v


type RefSeqNum =
    |RefSeqNum of uint32
     member x.Value = let (RefSeqNum v) = x in v


type SecurityID =
    |SecurityID of string
     member x.Value = let (SecurityID v) = x in v


type SenderCompID =
    |SenderCompID of string
     member x.Value = let (SenderCompID v) = x in v


type SenderSubID =
    |SenderSubID of string
     member x.Value = let (SenderSubID v) = x in v


type SendingTime =
