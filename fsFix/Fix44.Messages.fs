module Fix44.Messages

open OneOrTwo
open Fix44.Fields
open Fix44.CompoundItems



type Heartbeat = {
    TestReqID: TestReqID option
    }

type Logon = {
    EncryptMethod: EncryptMethod
    HeartBtInt: HeartBtInt
    RawData: RawData option
    ResetSeqNumFlag: ResetSeqNumFlag option
    NextExpectedMsgSeqNum: NextExpectedMsgSeqNum option
    MaxMessageSize: MaxMessageSize option
    NoMsgTypesGrp: NoMsgTypesGrp list option // group
    TestMessageIndicator: TestMessageIndicator option
    Username: Username option
    Password: Password option
    }

type TestRequest = {
    TestReqID: TestReqID
    }

type ResendRequest = {
    BeginSeqNo: BeginSeqNo
    EndSeqNo: EndSeqNo
    }

type Reject = {
    RefSeqNum: RefSeqNum
    RefTagID: RefTagID option
    RefMsgType: RefMsgType option
    SessionRejectReason: SessionRejectReason option
    Text: Text option
    EncodedText: EncodedText option
    }

type SequenceReset = {
    GapFillFlag: GapFillFlag option
    NewSeqNo: NewSeqNo
    }

type Logout = {
    Text: Text option
    EncodedText: EncodedText option
    }

type BusinessMessageReject = {
    RefSeqNum: RefSeqNum option
    RefMsgType: RefMsgType
    BusinessRejectRefID: BusinessRejectRefID option
    BusinessRejectReason: BusinessRejectReason
    Text: Text option
    EncodedText: EncodedText option
    }

type UserRequest = {
    UserRequestID: UserRequestID
    UserRequestType: UserRequestType
    Username: Username
    Password: Password option
    NewPassword: NewPassword option
    RawData: RawData option
    }

type UserResponse = {
    UserRequestID: UserRequestID
    Username: Username
    UserStatus: UserStatus option
    UserStatusText: UserStatusText option
    }

type Advertisement = {
    AdvId: AdvId
    AdvTransType: AdvTransType
    AdvRefID: AdvRefID option
    Instrument: Instrument // component
    NoLegsGrp: NoLegsGrp list option // group
    AdvertisementNoUnderlyingsGrp: AdvertisementNoUnderlyingsGrp list option // group
    AdvSide: AdvSide
    Quantity: Quantity
    QtyType: QtyType option
    Price: Price option
    Currency: Currency option
    TradeDate: TradeDate option
    TransactTime: TransactTime option
    Text: Text option
    EncodedText: EncodedText option
    URLLink: URLLink option
    LastMkt: LastMkt option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    }

type IndicationOfInterest = {
    IOIid: IOIid
    IOITransType: IOITransType
    IOIRefID: IOIRefID option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    Side: Side
    QtyType: QtyType option
    OrderQtyData: OrderQtyData option // component
    IOIQty: IOIQty
    Currency: Currency option
    Stipulations: Stipulations option // component
    IndicationOfInterestNoLegsGrp: IndicationOfInterestNoLegsGrp list option // group
    PriceType: PriceType option
    Price: Price option
    ValidUntilTime: ValidUntilTime option
    IOIQltyInd: IOIQltyInd option
    IOINaturalFlag: IOINaturalFlag option
    NoIOIQualifiersGrp: NoIOIQualifiersGrp list option // group
    Text: Text option
    EncodedText: EncodedText option
    TransactTime: TransactTime option
    URLLink: URLLink option
    NoRoutingIDsGrp: NoRoutingIDsGrp list option // group
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    YieldData: YieldData option // component
    }

type News = {
    OrigTime: OrigTime option
    Urgency: Urgency option
    Headline: Headline
    EncodedHeadline: EncodedHeadline option
    NoRoutingIDsGrp: NoRoutingIDsGrp list option // group
    NoRelatedSymGrp: NoRelatedSymGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    LinesOfTextGrp: LinesOfTextGrp list // group
    URLLink: URLLink option
    RawData: RawData option
    }

type Email = {
    EmailThreadID: EmailThreadID
    EmailType: EmailType
    OrigTime: OrigTime option
    Subject: Subject
    EncodedSubject: EncodedSubject option
    NoRoutingIDsGrp: NoRoutingIDsGrp list option // group
    NoRelatedSymGrp: NoRelatedSymGrp list option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    OrderID: OrderID option
    ClOrdID: ClOrdID option
    LinesOfTextGrp: LinesOfTextGrp list // group
    RawData: RawData option
    }

type QuoteRequest = {
    QuoteReqID: QuoteReqID
    RFQReqID: RFQReqID option
    ClOrdID: ClOrdID option
    OrderCapacity: OrderCapacity option
    QuoteRequestNoRelatedSymGrp: QuoteRequestNoRelatedSymGrp list // group
    Text: Text option
    EncodedText: EncodedText option
    }

type QuoteResponse = {
    QuoteRespID: QuoteRespID
    QuoteID: QuoteID option
    QuoteRespType: QuoteRespType
    ClOrdID: ClOrdID option
    OrderCapacity: OrderCapacity option
    IOIid: IOIid option
    QuoteType: QuoteType option
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp list option // group
    Parties: Parties option // component
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    Side: Side option
    OrderQtyData: OrderQtyData option // component
    SettlType: SettlType option
    SettlDate: SettlDate option
    SettlDate2: SettlDate2 option
    OrderQty2: OrderQty2 option
    Currency: Currency option
    Stipulations: Stipulations option // component
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    QuoteResponseNoLegsGrp: QuoteResponseNoLegsGrp list option // group
    BidPx: BidPx option
    OfferPx: OfferPx option
    MktBidPx: MktBidPx option
    MktOfferPx: MktOfferPx option
    MinBidSize: MinBidSize option
    BidSize: BidSize option
    MinOfferSize: MinOfferSize option
    OfferSize: OfferSize option
    ValidUntilTime: ValidUntilTime option
    BidSpotRate: BidSpotRate option
    OfferSpotRate: OfferSpotRate option
    BidForwardPoints: BidForwardPoints option
    OfferForwardPoints: OfferForwardPoints option
    MidPx: MidPx option
    BidYield: BidYield option
    MidYield: MidYield option
    OfferYield: OfferYield option
    TransactTime: TransactTime option
    OrdType: OrdType option
    BidForwardPoints2: BidForwardPoints2 option
    OfferForwardPoints2: OfferForwardPoints2 option
    SettlCurrBidFxRate: SettlCurrBidFxRate option
    SettlCurrOfferFxRate: SettlCurrOfferFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    Commission: Commission option
    CommType: CommType option
    CustOrderCapacity: CustOrderCapacity option
    ExDestination: ExDestination option
    Text: Text option
    EncodedText: EncodedText option
    Price: Price option
    PriceType: PriceType option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    YieldData: YieldData option // component
    }

type QuoteRequestReject = {
    QuoteReqID: QuoteReqID
    RFQReqID: RFQReqID option
    QuoteRequestRejectReason: QuoteRequestRejectReason
    QuoteRequestRejectNoRelatedSymGrp: QuoteRequestRejectNoRelatedSymGrp list // group
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp list option // group
    QuotePriceType: QuotePriceType option
    OrdType: OrdType option
    ExpireTime: ExpireTime option
    TransactTime: TransactTime option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    PriceType: PriceType option
    Price: Price option
    Price2: Price2 option
    YieldData: YieldData option // component
    Parties: Parties option // component
    Text: Text option
    EncodedText: EncodedText option
    }

type RFQRequest = {
    RFQReqID: RFQReqID
    RFQRequestNoRelatedSymGrp: RFQRequestNoRelatedSymGrp list // group
    SubscriptionRequestType: SubscriptionRequestType option
    }

type Quote = {
    QuoteReqID: QuoteReqID option
    QuoteID: QuoteID
    QuoteRespID: QuoteRespID option
    QuoteType: QuoteType option
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp list option // group
    QuoteResponseLevel: QuoteResponseLevel option
    Parties: Parties option // component
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    Side: Side option
    OrderQtyData: OrderQtyData option // component
    SettlType: SettlType option
    SettlDate: SettlDate option
    SettlDate2: SettlDate2 option
    OrderQty2: OrderQty2 option
    Currency: Currency option
    Stipulations: Stipulations option // component
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    QuoteNoLegsGrp: QuoteNoLegsGrp list option // group
    BidPx: BidPx option
    OfferPx: OfferPx option
    MktBidPx: MktBidPx option
    MktOfferPx: MktOfferPx option
    MinBidSize: MinBidSize option
    BidSize: BidSize option
    MinOfferSize: MinOfferSize option
    OfferSize: OfferSize option
    ValidUntilTime: ValidUntilTime option
    BidSpotRate: BidSpotRate option
    OfferSpotRate: OfferSpotRate option
    BidForwardPoints: BidForwardPoints option
    OfferForwardPoints: OfferForwardPoints option
    MidPx: MidPx option
    BidYield: BidYield option
    MidYield: MidYield option
    OfferYield: OfferYield option
    TransactTime: TransactTime option
    OrdType: OrdType option
    BidForwardPoints2: BidForwardPoints2 option
    OfferForwardPoints2: OfferForwardPoints2 option
    SettlCurrBidFxRate: SettlCurrBidFxRate option
    SettlCurrOfferFxRate: SettlCurrOfferFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    CommType: CommType option
    Commission: Commission option
    CustOrderCapacity: CustOrderCapacity option
    ExDestination: ExDestination option
    OrderCapacity: OrderCapacity option
    PriceType: PriceType option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    YieldData: YieldData option // component
    Text: Text option
    EncodedText: EncodedText option
    }

type QuoteCancel = {
    QuoteReqID: QuoteReqID option
    QuoteID: QuoteID
    QuoteCancelType: QuoteCancelType
    QuoteResponseLevel: QuoteResponseLevel option
    Parties: Parties option // component
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    NoQuoteEntriesGrp: NoQuoteEntriesGrp list option // group
    }

type QuoteStatusRequest = {
    QuoteStatusReqID: QuoteStatusReqID option
    QuoteID: QuoteID option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    Parties: Parties option // component
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    SubscriptionRequestType: SubscriptionRequestType option
    }

type QuoteStatusReport = {
    QuoteStatusReqID: QuoteStatusReqID option
    QuoteReqID: QuoteReqID option
    QuoteID: QuoteID
    QuoteRespID: QuoteRespID option
    QuoteType: QuoteType option
    Parties: Parties option // component
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    Side: Side option
    OrderQtyData: OrderQtyData option // component
    SettlType: SettlType option
    SettlDate: SettlDate option
    SettlDate2: SettlDate2 option
    OrderQty2: OrderQty2 option
    Currency: Currency option
    Stipulations: Stipulations option // component
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    QuoteStatusReportNoLegsGrp: QuoteStatusReportNoLegsGrp list option // group
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp list option // group
    ExpireTime: ExpireTime option
    Price: Price option
    PriceType: PriceType option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    YieldData: YieldData option // component
    BidPx: BidPx option
    OfferPx: OfferPx option
    MktBidPx: MktBidPx option
    MktOfferPx: MktOfferPx option
    MinBidSize: MinBidSize option
    BidSize: BidSize option
    MinOfferSize: MinOfferSize option
    OfferSize: OfferSize option
    ValidUntilTime: ValidUntilTime option
    BidSpotRate: BidSpotRate option
    OfferSpotRate: OfferSpotRate option
    BidForwardPoints: BidForwardPoints option
    OfferForwardPoints: OfferForwardPoints option
    MidPx: MidPx option
    BidYield: BidYield option
    MidYield: MidYield option
    OfferYield: OfferYield option
    TransactTime: TransactTime option
    OrdType: OrdType option
    BidForwardPoints2: BidForwardPoints2 option
    OfferForwardPoints2: OfferForwardPoints2 option
    SettlCurrBidFxRate: SettlCurrBidFxRate option
    SettlCurrOfferFxRate: SettlCurrOfferFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    CommType: CommType option
    Commission: Commission option
    CustOrderCapacity: CustOrderCapacity option
    ExDestination: ExDestination option
    QuoteStatus: QuoteStatus option
    Text: Text option
    EncodedText: EncodedText option
    }

type MassQuote = {
    QuoteReqID: QuoteReqID option
    QuoteID: QuoteID
    QuoteType: QuoteType option
    QuoteResponseLevel: QuoteResponseLevel option
    Parties: Parties option // component
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    DefBidSize: DefBidSize option
    DefOfferSize: DefOfferSize option
    NoQuoteSetsGrp: NoQuoteSetsGrp list // group
    }

type MassQuoteAcknowledgement = {
    QuoteReqID: QuoteReqID option
    QuoteID: QuoteID option
    QuoteStatus: QuoteStatus
    QuoteRejectReason: QuoteRejectReason option
    QuoteResponseLevel: QuoteResponseLevel option
    QuoteType: QuoteType option
    Parties: Parties option // component
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    Text: Text option
    EncodedText: EncodedText option
    MassQuoteAcknowledgementNoQuoteSetsGrp: MassQuoteAcknowledgementNoQuoteSetsGrp list option // group
    }

type MarketDataRequest = {
    MDReqID: MDReqID
    SubscriptionRequestType: SubscriptionRequestType
    MarketDepth: MarketDepth
    MDUpdateType: MDUpdateType option
    AggregatedBook: AggregatedBook option
    OpenCloseSettlFlag: OpenCloseSettlFlag option
    Scope: Scope option
    MDImplicitDelete: MDImplicitDelete option
    NoMDEntryTypesGrp: NoMDEntryTypesGrp list // group
    MarketDataRequestNoRelatedSymGrp: MarketDataRequestNoRelatedSymGrp list // group
    NoTradingSessionsGrp: NoTradingSessionsGrp list option // group
    ApplQueueAction: ApplQueueAction option
    ApplQueueMax: ApplQueueMax option
    }

type MarketDataSnapshotFullRefresh = {
    MDReqID: MDReqID option
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    FinancialStatus: FinancialStatus option
    CorporateAction: CorporateAction option
    NetChgPrevDay: NetChgPrevDay option
    NoMDEntriesGrp: NoMDEntriesGrp list // group
    ApplQueueDepth: ApplQueueDepth option
    ApplQueueResolution: ApplQueueResolution option
    }

type MarketDataIncrementalRefresh = {
    MDReqID: MDReqID option
    MarketDataIncrementalRefreshNoMDEntriesGrp: MarketDataIncrementalRefreshNoMDEntriesGrp list // group
    ApplQueueDepth: ApplQueueDepth option
    ApplQueueResolution: ApplQueueResolution option
    }

type MarketDataRequestReject = {
    MDReqID: MDReqID
    MDReqRejReason: MDReqRejReason option
    NoAltMDSourceGrp: NoAltMDSourceGrp list option // group
    Text: Text option
    EncodedText: EncodedText option
    }

type SecurityDefinitionRequest = {
    SecurityReqID: SecurityReqID
    SecurityRequestType: SecurityRequestType
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    Currency: Currency option
    Text: Text option
    EncodedText: EncodedText option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    NoLegsGrp: NoLegsGrp list option // group
    ExpirationCycle: ExpirationCycle option
    SubscriptionRequestType: SubscriptionRequestType option
    }

type SecurityDefinition = {
    SecurityReqID: SecurityReqID
    SecurityResponseID: SecurityResponseID
    SecurityResponseType: SecurityResponseType
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    Currency: Currency option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Text: Text option
    EncodedText: EncodedText option
    NoLegsGrp: NoLegsGrp list option // group
    ExpirationCycle: ExpirationCycle option
    RoundLot: RoundLot option
    MinTradeVol: MinTradeVol option
    }

type SecurityTypeRequest = {
    SecurityReqID: SecurityReqID
    Text: Text option
    EncodedText: EncodedText option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Product: Product option
    SecurityType: SecurityType option
    SecuritySubType: SecuritySubType option
    }

type SecurityTypes = {
    SecurityReqID: SecurityReqID
    SecurityResponseID: SecurityResponseID
    SecurityResponseType: SecurityResponseType
    TotNoSecurityTypes: TotNoSecurityTypes option
    LastFragment: LastFragment option
    NoSecurityTypesGrp: NoSecurityTypesGrp list option // group
    Text: Text option
    EncodedText: EncodedText option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    SubscriptionRequestType: SubscriptionRequestType option
    }

type SecurityListRequest = {
    SecurityReqID: SecurityReqID
    SecurityListRequestType: SecurityListRequestType
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    Currency: Currency option
    Text: Text option
    EncodedText: EncodedText option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    SubscriptionRequestType: SubscriptionRequestType option
    }

type SecurityList = {
    SecurityReqID: SecurityReqID
    SecurityResponseID: SecurityResponseID
    SecurityRequestResult: SecurityRequestResult
    TotNoRelatedSym: TotNoRelatedSym option
    LastFragment: LastFragment option
    SecurityListNoRelatedSymGrp: SecurityListNoRelatedSymGrp list option // group
    }

type DerivativeSecurityListRequest = {
    SecurityReqID: SecurityReqID
    SecurityListRequestType: SecurityListRequestType
    UnderlyingInstrument: UnderlyingInstrument option // component
    SecuritySubType: SecuritySubType option
    Currency: Currency option
    Text: Text option
    EncodedText: EncodedText option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    SubscriptionRequestType: SubscriptionRequestType option
    }

type DerivativeSecurityList = {
    SecurityReqID: SecurityReqID
    SecurityResponseID: SecurityResponseID
    SecurityRequestResult: SecurityRequestResult
    UnderlyingInstrument: UnderlyingInstrument option // component
    TotNoRelatedSym: TotNoRelatedSym option
    LastFragment: LastFragment option
    DerivativeSecurityListNoRelatedSymGrp: DerivativeSecurityListNoRelatedSymGrp list option // group
    }

type SecurityStatusRequest = {
    SecurityStatusReqID: SecurityStatusReqID
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    Currency: Currency option
    SubscriptionRequestType: SubscriptionRequestType
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    }

type SecurityStatus = {
    SecurityStatusReqID: SecurityStatusReqID option
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    Currency: Currency option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnsolicitedIndicator: UnsolicitedIndicator option
    SecurityTradingStatus: SecurityTradingStatus option
    FinancialStatus: FinancialStatus option
    CorporateAction: CorporateAction option
    HaltReason: HaltReason option
    InViewOfCommon: InViewOfCommon option
    DueToRelated: DueToRelated option
    BuyVolume: BuyVolume option
    SellVolume: SellVolume option
    HighPx: HighPx option
    LowPx: LowPx option
    LastPx: LastPx option
    TransactTime: TransactTime option
    Adjustment: Adjustment option
    Text: Text option
    EncodedText: EncodedText option
    }

type TradingSessionStatusRequest = {
    TradSesReqID: TradSesReqID
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TradSesMethod: TradSesMethod option
    TradSesMode: TradSesMode option
    SubscriptionRequestType: SubscriptionRequestType
    }

type TradingSessionStatus = {
    TradSesReqID: TradSesReqID option
    TradingSessionID: TradingSessionID
    TradingSessionSubID: TradingSessionSubID option
    TradSesMethod: TradSesMethod option
    TradSesMode: TradSesMode option
    UnsolicitedIndicator: UnsolicitedIndicator option
    TradSesStatus: TradSesStatus
    TradSesStatusRejReason: TradSesStatusRejReason option
    TradSesStartTime: TradSesStartTime option
    TradSesOpenTime: TradSesOpenTime option
    TradSesPreCloseTime: TradSesPreCloseTime option
    TradSesCloseTime: TradSesCloseTime option
    TradSesEndTime: TradSesEndTime option
    TotalVolumeTraded: TotalVolumeTraded option
    Text: Text option
    EncodedText: EncodedText option
    }

type NewOrderSingle = {
    ClOrdID: ClOrdID
    SecondaryClOrdID: SecondaryClOrdID option
    ClOrdLinkID: ClOrdLinkID option
    Parties: Parties option // component
    TradeOriginationDate: TradeOriginationDate option
    TradeDate: TradeDate option
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    DayBookingInst: DayBookingInst option
    BookingUnit: BookingUnit option
    PreallocMethod: PreallocMethod option
    AllocID: AllocID option
    NoAllocsGrp: NoAllocsGrp list option // group
    SettlType: SettlType option
    SettlDate: SettlDate option
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    HandlInst: HandlInst option
    ExecInst: ExecInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    ExDestination: ExDestination option
    NoTradingSessionsGrp: NoTradingSessionsGrp list option // group
    ProcessCode: ProcessCode option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    PrevClosePx: PrevClosePx option
    Side: Side
    LocateReqd: LocateReqd option
    TransactTime: TransactTime
    Stipulations: Stipulations option // component
    QtyType: QtyType option
    OrderQtyData: OrderQtyData // component
    OrdType: OrdType
    PriceType: PriceType option
    Price: Price option
    StopPx: StopPx option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    YieldData: YieldData option // component
    Currency: Currency option
    ComplianceID: ComplianceID option
    SolicitedFlag: SolicitedFlag option
    IOIid: IOIid option
    QuoteID: QuoteID option
    TimeInForce: TimeInForce option
    EffectiveTime: EffectiveTime option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    GTBookingInst: GTBookingInst option
    CommissionData: CommissionData option // component
    OrderCapacity: OrderCapacity option
    OrderRestrictions: OrderRestrictions option
    CustOrderCapacity: CustOrderCapacity option
    ForexReq: ForexReq option
    SettlCurrency: SettlCurrency option
    BookingType: BookingType option
    Text: Text option
    EncodedText: EncodedText option
    SettlDate2: SettlDate2 option
    OrderQty2: OrderQty2 option
    Price2: Price2 option
    PositionEffect: PositionEffect option
    CoveredOrUncovered: CoveredOrUncovered option
    MaxShow: MaxShow option
    PegInstructions: PegInstructions option // component
    DiscretionInstructions: DiscretionInstructions option // component
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    ParticipationRate: ParticipationRate option
    CancellationRights: CancellationRights option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    RegistID: RegistID option
    Designation: Designation option
    }

type ExecutionReport = {
    OrderID: OrderID
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryExecID: SecondaryExecID option
    ClOrdID: ClOrdID option
    OrigClOrdID: OrigClOrdID option
    ClOrdLinkID: ClOrdLinkID option
    QuoteRespID: QuoteRespID option
    OrdStatusReqID: OrdStatusReqID option
    MassStatusReqID: MassStatusReqID option
    TotNumReports: TotNumReports option
    LastRptRequested: LastRptRequested option
    Parties: Parties option // component
    TradeOriginationDate: TradeOriginationDate option
    NoContraBrokersGrp: NoContraBrokersGrp list option // group
    ListID: ListID option
    CrossID: CrossID option
    OrigCrossID: OrigCrossID option
    CrossType: CrossType option
    ExecID: ExecID
    ExecRefID: ExecRefID option
    ExecType: ExecType
    OrdStatus: OrdStatus
    WorkingIndicator: WorkingIndicator option
    OrdRejReason: OrdRejReason option
    ExecRestatementReason: ExecRestatementReason option
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    DayBookingInst: DayBookingInst option
    BookingUnit: BookingUnit option
    PreallocMethod: PreallocMethod option
    SettlType: SettlType option
    SettlDate: SettlDate option
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    Side: Side
    Stipulations: Stipulations option // component
    QtyType: QtyType option
    OrderQtyData: OrderQtyData option // component
    OrdType: OrdType option
    PriceType: PriceType option
    Price: Price option
    StopPx: StopPx option
    PegInstructions: PegInstructions option // component
    DiscretionInstructions: DiscretionInstructions option // component
    PeggedPrice: PeggedPrice option
    DiscretionPrice: DiscretionPrice option
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    ParticipationRate: ParticipationRate option
    TargetStrategyPerformance: TargetStrategyPerformance option
    Currency: Currency option
    ComplianceID: ComplianceID option
    SolicitedFlag: SolicitedFlag option
    TimeInForce: TimeInForce option
    EffectiveTime: EffectiveTime option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    ExecInst: ExecInst option
    OrderCapacity: OrderCapacity option
    OrderRestrictions: OrderRestrictions option
    CustOrderCapacity: CustOrderCapacity option
    LastQty: LastQty option
    UnderlyingLastQty: UnderlyingLastQty option
    LastPx: LastPx option
    UnderlyingLastPx: UnderlyingLastPx option
    LastParPx: LastParPx option
    LastSpotRate: LastSpotRate option
    LastForwardPoints: LastForwardPoints option
    LastMkt: LastMkt option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TimeBracket: TimeBracket option
    LastCapacity: LastCapacity option
    LeavesQty: LeavesQty
    CumQty: CumQty
    AvgPx: AvgPx
    DayOrderQty: DayOrderQty option
    DayCumQty: DayCumQty option
    DayAvgPx: DayAvgPx option
    GTBookingInst: GTBookingInst option
    TradeDate: TradeDate option
    TransactTime: TransactTime option
    ReportToExch: ReportToExch option
    CommissionData: CommissionData option // component
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    YieldData: YieldData option // component
    GrossTradeAmt: GrossTradeAmt option
    NumDaysInterest: NumDaysInterest option
    ExDate: ExDate option
    AccruedInterestRate: AccruedInterestRate option
    AccruedInterestAmt: AccruedInterestAmt option
    InterestAtMaturity: InterestAtMaturity option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    StartCash: StartCash option
    EndCash: EndCash option
    TradedFlatSwitch: TradedFlatSwitch option
    BasisFeatureDate: BasisFeatureDate option
    BasisFeaturePrice: BasisFeaturePrice option
    Concession: Concession option
    TotalTakedown: TotalTakedown option
    NetMoney: NetMoney option
    SettlCurrAmt: SettlCurrAmt option
    SettlCurrency: SettlCurrency option
    SettlCurrFxRate: SettlCurrFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    HandlInst: HandlInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    PositionEffect: PositionEffect option
    MaxShow: MaxShow option
    BookingType: BookingType option
    Text: Text option
    EncodedText: EncodedText option
    SettlDate2: SettlDate2 option
    OrderQty2: OrderQty2 option
    LastForwardPoints2: LastForwardPoints2 option
    MultiLegReportingType: MultiLegReportingType option
    CancellationRights: CancellationRights option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    RegistID: RegistID option
    Designation: Designation option
    TransBkdTime: TransBkdTime option
    ExecValuationPoint: ExecValuationPoint option
    ExecPriceType: ExecPriceType option
    ExecPriceAdjustment: ExecPriceAdjustment option
    PriorityIndicator: PriorityIndicator option
    PriceImprovement: PriceImprovement option
    LastLiquidityInd: LastLiquidityInd option
    NoContAmtsGrp: NoContAmtsGrp list option // group
    ExecutionReportNoLegsGrp: ExecutionReportNoLegsGrp list option // group
    CopyMsgIndicator: CopyMsgIndicator option
    NoMiscFeesGrp: NoMiscFeesGrp list option // group
    }

type DontKnowTrade = {
    OrderID: OrderID
    SecondaryOrderID: SecondaryOrderID option
    ExecID: ExecID
    DKReason: DKReason
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    Side: Side
    OrderQtyData: OrderQtyData // component
    LastQty: LastQty option
    LastPx: LastPx option
    Text: Text option
    EncodedText: EncodedText option
    }

type OrderCancelReplaceRequest = {
    OrderID: OrderID option
    Parties: Parties option // component
    TradeOriginationDate: TradeOriginationDate option
    TradeDate: TradeDate option
    OrigClOrdID: OrigClOrdID
    ClOrdID: ClOrdID
    SecondaryClOrdID: SecondaryClOrdID option
    ClOrdLinkID: ClOrdLinkID option
    ListID: ListID option
    OrigOrdModTime: OrigOrdModTime option
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    DayBookingInst: DayBookingInst option
    BookingUnit: BookingUnit option
    PreallocMethod: PreallocMethod option
    AllocID: AllocID option
    NoAllocsGrp: NoAllocsGrp list option // group
    SettlType: SettlType option
    SettlDate: SettlDate option
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    HandlInst: HandlInst option
    ExecInst: ExecInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    ExDestination: ExDestination option
    NoTradingSessionsGrp: NoTradingSessionsGrp list option // group
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    Side: Side
    TransactTime: TransactTime
    QtyType: QtyType option
    OrderQtyData: OrderQtyData // component
    OrdType: OrdType
    PriceType: PriceType option
    Price: Price option
    StopPx: StopPx option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    YieldData: YieldData option // component
    PegInstructions: PegInstructions option // component
    DiscretionInstructions: DiscretionInstructions option // component
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    ParticipationRate: ParticipationRate option
    ComplianceID: ComplianceID option
    SolicitedFlag: SolicitedFlag option
    Currency: Currency option
    TimeInForce: TimeInForce option
    EffectiveTime: EffectiveTime option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    GTBookingInst: GTBookingInst option
    CommissionData: CommissionData option // component
    OrderCapacity: OrderCapacity option
    OrderRestrictions: OrderRestrictions option
    CustOrderCapacity: CustOrderCapacity option
    ForexReq: ForexReq option
    SettlCurrency: SettlCurrency option
    BookingType: BookingType option
    Text: Text option
    EncodedText: EncodedText option
    SettlDate2: SettlDate2 option
    OrderQty2: OrderQty2 option
    Price2: Price2 option
    PositionEffect: PositionEffect option
    CoveredOrUncovered: CoveredOrUncovered option
    MaxShow: MaxShow option
    LocateReqd: LocateReqd option
    CancellationRights: CancellationRights option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    RegistID: RegistID option
    Designation: Designation option
    }

type OrderCancelRequest = {
    OrigClOrdID: OrigClOrdID
    OrderID: OrderID option
    ClOrdID: ClOrdID
    SecondaryClOrdID: SecondaryClOrdID option
    ClOrdLinkID: ClOrdLinkID option
    ListID: ListID option
    OrigOrdModTime: OrigOrdModTime option
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    Parties: Parties option // component
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    Side: Side
    TransactTime: TransactTime
    OrderQtyData: OrderQtyData // component
    ComplianceID: ComplianceID option
    Text: Text option
    EncodedText: EncodedText option
    }

type OrderCancelReject = {
    OrderID: OrderID
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    ClOrdID: ClOrdID
    ClOrdLinkID: ClOrdLinkID option
    OrigClOrdID: OrigClOrdID
    OrdStatus: OrdStatus
    WorkingIndicator: WorkingIndicator option
    OrigOrdModTime: OrigOrdModTime option
    ListID: ListID option
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    TradeOriginationDate: TradeOriginationDate option
    TradeDate: TradeDate option
    TransactTime: TransactTime option
    CxlRejResponseTo: CxlRejResponseTo
    CxlRejReason: CxlRejReason option
    Text: Text option
    EncodedText: EncodedText option
    }

type OrderStatusRequest = {
    OrderID: OrderID option
    ClOrdID: ClOrdID
    SecondaryClOrdID: SecondaryClOrdID option
    ClOrdLinkID: ClOrdLinkID option
    Parties: Parties option // component
    OrdStatusReqID: OrdStatusReqID option
    Account: Account option
    AcctIDSource: AcctIDSource option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    Side: Side
    }

type OrderMassCancelRequest = {
    ClOrdID: ClOrdID
    SecondaryClOrdID: SecondaryClOrdID option
    MassCancelRequestType: MassCancelRequestType
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Instrument: Instrument option // component
    UnderlyingInstrument: UnderlyingInstrument option // component
    Side: Side option
    TransactTime: TransactTime
    Text: Text option
    EncodedText: EncodedText option
    }

type OrderMassCancelReport = {
    ClOrdID: ClOrdID option
    SecondaryClOrdID: SecondaryClOrdID option
    OrderID: OrderID
    SecondaryOrderID: SecondaryOrderID option
    MassCancelRequestType: MassCancelRequestType
    MassCancelResponse: MassCancelResponse
    MassCancelRejectReason: MassCancelRejectReason option
    TotalAffectedOrders: TotalAffectedOrders option
    NoAffectedOrdersGrp: NoAffectedOrdersGrp list option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Instrument: Instrument option // component
    UnderlyingInstrument: UnderlyingInstrument option // component
    Side: Side option
    TransactTime: TransactTime option
    Text: Text option
    EncodedText: EncodedText option
    }

type OrderMassStatusRequest = {
    MassStatusReqID: MassStatusReqID
    MassStatusReqType: MassStatusReqType
    Parties: Parties option // component
    Account: Account option
    AcctIDSource: AcctIDSource option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Instrument: Instrument option // component
    UnderlyingInstrument: UnderlyingInstrument option // component
    Side: Side option
    }

type NewOrderCross = {
    CrossID: CrossID
    CrossType: CrossType
    CrossPrioritization: CrossPrioritization
    NoSidesGrp: NoSidesGrp OneOrTwo // group
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    SettlType: SettlType option
    SettlDate: SettlDate option
    HandlInst: HandlInst option
    ExecInst: ExecInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    ExDestination: ExDestination option
    NoTradingSessionsGrp: NoTradingSessionsGrp list option // group
    ProcessCode: ProcessCode option
    PrevClosePx: PrevClosePx option
    LocateReqd: LocateReqd option
    TransactTime: TransactTime
    Stipulations: Stipulations option // component
    OrdType: OrdType
    PriceType: PriceType option
    Price: Price option
    StopPx: StopPx option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    YieldData: YieldData option // component
    Currency: Currency option
    ComplianceID: ComplianceID option
    IOIid: IOIid option
    QuoteID: QuoteID option
    TimeInForce: TimeInForce option
    EffectiveTime: EffectiveTime option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    GTBookingInst: GTBookingInst option
    MaxShow: MaxShow option
    PegInstructions: PegInstructions option // component
    DiscretionInstructions: DiscretionInstructions option // component
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    ParticipationRate: ParticipationRate option
    CancellationRights: CancellationRights option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    RegistID: RegistID option
    Designation: Designation option
    }

type CrossOrderCancelReplaceRequest = {
    OrderID: OrderID option
    CrossID: CrossID
    OrigCrossID: OrigCrossID
    CrossType: CrossType
    CrossPrioritization: CrossPrioritization
    CrossOrderCancelReplaceRequestNoSidesGrp: CrossOrderCancelReplaceRequestNoSidesGrp OneOrTwo // group
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    SettlType: SettlType option
    SettlDate: SettlDate option
    HandlInst: HandlInst option
    ExecInst: ExecInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    ExDestination: ExDestination option
    NoTradingSessionsGrp: NoTradingSessionsGrp list option // group
    ProcessCode: ProcessCode option
    PrevClosePx: PrevClosePx option
    LocateReqd: LocateReqd option
    TransactTime: TransactTime
    Stipulations: Stipulations option // component
    OrdType: OrdType
    PriceType: PriceType option
    Price: Price option
    StopPx: StopPx option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    YieldData: YieldData option // component
    Currency: Currency option
    ComplianceID: ComplianceID option
    IOIid: IOIid option
    QuoteID: QuoteID option
    TimeInForce: TimeInForce option
    EffectiveTime: EffectiveTime option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    GTBookingInst: GTBookingInst option
    MaxShow: MaxShow option
    PegInstructions: PegInstructions option // component
    DiscretionInstructions: DiscretionInstructions option // component
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    ParticipationRate: ParticipationRate option
    CancellationRights: CancellationRights option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    RegistID: RegistID option
    Designation: Designation option
    }

type CrossOrderCancelRequest = {
    OrderID: OrderID option
    CrossID: CrossID
    OrigCrossID: OrigCrossID
    CrossType: CrossType
    CrossPrioritization: CrossPrioritization
    CrossOrderCancelRequestNoSidesGrp: CrossOrderCancelRequestNoSidesGrp OneOrTwo // group
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    TransactTime: TransactTime
    }

type NewOrderMultileg = {
    ClOrdID: ClOrdID
    SecondaryClOrdID: SecondaryClOrdID option
    ClOrdLinkID: ClOrdLinkID option
    Parties: Parties option // component
    TradeOriginationDate: TradeOriginationDate option
    TradeDate: TradeDate option
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    DayBookingInst: DayBookingInst option
    BookingUnit: BookingUnit option
    PreallocMethod: PreallocMethod option
    AllocID: AllocID option
    NewOrderMultilegNoAllocsGrp: NewOrderMultilegNoAllocsGrp list option // group
    SettlType: SettlType option
    SettlDate: SettlDate option
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    HandlInst: HandlInst option
    ExecInst: ExecInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    ExDestination: ExDestination option
    NoTradingSessionsGrp: NoTradingSessionsGrp list option // group
    ProcessCode: ProcessCode option
    Side: Side
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    PrevClosePx: PrevClosePx option
    NewOrderMultilegNoLegsGrp: NewOrderMultilegNoLegsGrp list // group
    LocateReqd: LocateReqd option
    TransactTime: TransactTime
    QtyType: QtyType option
    OrderQtyData: OrderQtyData // component
    OrdType: OrdType
    PriceType: PriceType option
    Price: Price option
    StopPx: StopPx option
    Currency: Currency option
    ComplianceID: ComplianceID option
    SolicitedFlag: SolicitedFlag option
    IOIid: IOIid option
    QuoteID: QuoteID option
    TimeInForce: TimeInForce option
    EffectiveTime: EffectiveTime option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    GTBookingInst: GTBookingInst option
    CommissionData: CommissionData option // component
    OrderCapacity: OrderCapacity option
    OrderRestrictions: OrderRestrictions option
    CustOrderCapacity: CustOrderCapacity option
    ForexReq: ForexReq option
    SettlCurrency: SettlCurrency option
    BookingType: BookingType option
    Text: Text option
    EncodedText: EncodedText option
    PositionEffect: PositionEffect option
    CoveredOrUncovered: CoveredOrUncovered option
    MaxShow: MaxShow option
    PegInstructions: PegInstructions option // component
    DiscretionInstructions: DiscretionInstructions option // component
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    ParticipationRate: ParticipationRate option
    CancellationRights: CancellationRights option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    RegistID: RegistID option
    Designation: Designation option
    MultiLegRptTypeReq: MultiLegRptTypeReq option
    }

type MultilegOrderCancelReplaceRequest = {
    OrderID: OrderID option
    OrigClOrdID: OrigClOrdID
    ClOrdID: ClOrdID
    SecondaryClOrdID: SecondaryClOrdID option
    ClOrdLinkID: ClOrdLinkID option
    OrigOrdModTime: OrigOrdModTime option
    Parties: Parties option // component
    TradeOriginationDate: TradeOriginationDate option
    TradeDate: TradeDate option
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    DayBookingInst: DayBookingInst option
    BookingUnit: BookingUnit option
    PreallocMethod: PreallocMethod option
    AllocID: AllocID option
    MultilegOrderCancelReplaceRequestNoAllocsGrp: MultilegOrderCancelReplaceRequestNoAllocsGrp list option // group
    SettlType: SettlType option
    SettlDate: SettlDate option
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    HandlInst: HandlInst option
    ExecInst: ExecInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    ExDestination: ExDestination option
    NoTradingSessionsGrp: NoTradingSessionsGrp list option // group
    ProcessCode: ProcessCode option
    Side: Side
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    PrevClosePx: PrevClosePx option
    MultilegOrderCancelReplaceRequestNoLegsGrp: MultilegOrderCancelReplaceRequestNoLegsGrp list // group
    LocateReqd: LocateReqd option
    TransactTime: TransactTime
    QtyType: QtyType option
    OrderQtyData: OrderQtyData // component
    OrdType: OrdType
    PriceType: PriceType option
    Price: Price option
    StopPx: StopPx option
    Currency: Currency option
    ComplianceID: ComplianceID option
    SolicitedFlag: SolicitedFlag option
    IOIid: IOIid option
    QuoteID: QuoteID option
    TimeInForce: TimeInForce option
    EffectiveTime: EffectiveTime option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    GTBookingInst: GTBookingInst option
    CommissionData: CommissionData option // component
    OrderCapacity: OrderCapacity option
    OrderRestrictions: OrderRestrictions option
    CustOrderCapacity: CustOrderCapacity option
    ForexReq: ForexReq option
    SettlCurrency: SettlCurrency option
    BookingType: BookingType option
    Text: Text option
    EncodedText: EncodedText option
    PositionEffect: PositionEffect option
    CoveredOrUncovered: CoveredOrUncovered option
    MaxShow: MaxShow option
    PegInstructions: PegInstructions option // component
    DiscretionInstructions: DiscretionInstructions option // component
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    ParticipationRate: ParticipationRate option
    CancellationRights: CancellationRights option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    RegistID: RegistID option
    Designation: Designation option
    MultiLegRptTypeReq: MultiLegRptTypeReq option
    }

type BidRequest = {
    BidID: BidID option
    ClientBidID: ClientBidID
    BidRequestTransType: BidRequestTransType
    ListName: ListName option
    TotNoRelatedSym: TotNoRelatedSym
    BidType: BidType
    NumTickets: NumTickets option
    Currency: Currency option
    SideValue1: SideValue1 option
    SideValue2: SideValue2 option
    NoBidDescriptorsGrp: NoBidDescriptorsGrp list option // group
    NoBidComponentsGrp: NoBidComponentsGrp list option // group
    LiquidityIndType: LiquidityIndType option
    WtAverageLiquidity: WtAverageLiquidity option
    ExchangeForPhysical: ExchangeForPhysical option
    OutMainCntryUIndex: OutMainCntryUIndex option
    CrossPercent: CrossPercent option
    ProgRptReqs: ProgRptReqs option
    ProgPeriodInterval: ProgPeriodInterval option
    IncTaxInd: IncTaxInd option
    ForexReq: ForexReq option
    NumBidders: NumBidders option
    TradeDate: TradeDate option
    BidTradeType: BidTradeType
    BasisPxType: BasisPxType
    StrikeTime: StrikeTime option
    Text: Text option
    EncodedText: EncodedText option
    }

type BidResponse = {
    BidID: BidID option
    ClientBidID: ClientBidID option
    BidResponseNoBidComponentsGrp: BidResponseNoBidComponentsGrp list // group
    }

type NewOrderList = {
    ListID: ListID
    BidID: BidID option
    ClientBidID: ClientBidID option
    ProgRptReqs: ProgRptReqs option
    BidType: BidType
    ProgPeriodInterval: ProgPeriodInterval option
    CancellationRights: CancellationRights option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    RegistID: RegistID option
    ListExecInstType: ListExecInstType option
    ListExecInst: ListExecInst option
    EncodedListExecInst: EncodedListExecInst option
    AllowableOneSidednessPct: AllowableOneSidednessPct option
    AllowableOneSidednessValue: AllowableOneSidednessValue option
    AllowableOneSidednessCurr: AllowableOneSidednessCurr option
    TotNoOrders: TotNoOrders
    LastFragment: LastFragment option
    NewOrderListNoOrdersGrp: NewOrderListNoOrdersGrp list // group
    }

type ListStrikePrice = {
    ListID: ListID
    TotNoStrikes: TotNoStrikes
    LastFragment: LastFragment option
    NoStrikesGrp: NoStrikesGrp list // group
    ListStrikePriceNoUnderlyingsGrp: ListStrikePriceNoUnderlyingsGrp list option // group
    }

type ListStatus = {
    ListID: ListID
    ListStatusType: ListStatusType
    NoRpts: NoRpts
    ListOrderStatus: ListOrderStatus
    RptSeq: RptSeq
    ListStatusText: ListStatusText option
    EncodedListStatusText: EncodedListStatusText option
    TransactTime: TransactTime option
    TotNoOrders: TotNoOrders
    LastFragment: LastFragment option
    ListStatusNoOrdersGrp: ListStatusNoOrdersGrp list // group
    }

type ListExecute = {
    ListID: ListID
    ClientBidID: ClientBidID option
    BidID: BidID option
    TransactTime: TransactTime
    Text: Text option
    EncodedText: EncodedText option
    }

type ListCancelRequest = {
    ListID: ListID
    TransactTime: TransactTime
    TradeOriginationDate: TradeOriginationDate option
    TradeDate: TradeDate option
    Text: Text option
    EncodedText: EncodedText option
    }

type ListStatusRequest = {
    ListID: ListID
    Text: Text option
    EncodedText: EncodedText option
    }

type AllocationInstruction = {
    AllocID: AllocID
    AllocTransType: AllocTransType
    AllocType: AllocType
    SecondaryAllocID: SecondaryAllocID option
    RefAllocID: RefAllocID option
    AllocCancReplaceReason: AllocCancReplaceReason option
    AllocIntermedReqType: AllocIntermedReqType option
    AllocLinkID: AllocLinkID option
    AllocLinkType: AllocLinkType option
    BookingRefID: BookingRefID option
    AllocNoOrdersType: AllocNoOrdersType
    NoOrdersGrp: NoOrdersGrp list option // group
    AllocationInstructionNoExecsGrp: AllocationInstructionNoExecsGrp list option // group
    PreviouslyReported: PreviouslyReported option
    ReversalIndicator: ReversalIndicator option
    MatchType: MatchType option
    Side: Side
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    Quantity: Quantity
    QtyType: QtyType option
    LastMkt: LastMkt option
    TradeOriginationDate: TradeOriginationDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    PriceType: PriceType option
    AvgPx: AvgPx
    AvgParPx: AvgParPx option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Currency: Currency option
    AvgPxPrecision: AvgPxPrecision option
    Parties: Parties option // component
    TradeDate: TradeDate
    TransactTime: TransactTime option
    SettlType: SettlType option
    SettlDate: SettlDate option
    BookingType: BookingType option
    GrossTradeAmt: GrossTradeAmt option
    Concession: Concession option
    TotalTakedown: TotalTakedown option
    NetMoney: NetMoney option
    PositionEffect: PositionEffect option
    AutoAcceptIndicator: AutoAcceptIndicator option
    Text: Text option
    EncodedText: EncodedText option
    NumDaysInterest: NumDaysInterest option
    AccruedInterestRate: AccruedInterestRate option
    AccruedInterestAmt: AccruedInterestAmt option
    TotalAccruedInterestAmt: TotalAccruedInterestAmt option
    InterestAtMaturity: InterestAtMaturity option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    StartCash: StartCash option
    EndCash: EndCash option
    LegalConfirm: LegalConfirm option
    Stipulations: Stipulations option // component
    YieldData: YieldData option // component
    TotNoAllocs: TotNoAllocs option
    LastFragment: LastFragment option
    AllocationInstructionNoAllocsGrp: AllocationInstructionNoAllocsGrp list option // group
    }

type AllocationInstructionAck = {
    AllocID: AllocID
    Parties: Parties option // component
    SecondaryAllocID: SecondaryAllocID option
    TradeDate: TradeDate option
    TransactTime: TransactTime
    AllocStatus: AllocStatus
    AllocRejCode: AllocRejCode option
    AllocType: AllocType option
    AllocIntermedReqType: AllocIntermedReqType option
    MatchStatus: MatchStatus option
    Product: Product option
    SecurityType: SecurityType option
    Text: Text option
    EncodedText: EncodedText option
    AllocationInstructionAckNoAllocsGrp: AllocationInstructionAckNoAllocsGrp list option // group
    }

type AllocationReport = {
    AllocReportID: AllocReportID
    AllocID: AllocID option
    AllocTransType: AllocTransType
    AllocReportRefID: AllocReportRefID option
    AllocCancReplaceReason: AllocCancReplaceReason option
    SecondaryAllocID: SecondaryAllocID option
    AllocReportType: AllocReportType
    AllocStatus: AllocStatus
    AllocRejCode: AllocRejCode option
    RefAllocID: RefAllocID option
    AllocIntermedReqType: AllocIntermedReqType option
    AllocLinkID: AllocLinkID option
    AllocLinkType: AllocLinkType option
    BookingRefID: BookingRefID option
    AllocNoOrdersType: AllocNoOrdersType
    NoOrdersGrp: NoOrdersGrp list option // group
    AllocationReportNoExecsGrp: AllocationReportNoExecsGrp list option // group
    PreviouslyReported: PreviouslyReported option
    ReversalIndicator: ReversalIndicator option
    MatchType: MatchType option
    Side: Side
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    Quantity: Quantity
    QtyType: QtyType option
    LastMkt: LastMkt option
    TradeOriginationDate: TradeOriginationDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    PriceType: PriceType option
    AvgPx: AvgPx
    AvgParPx: AvgParPx option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Currency: Currency option
    AvgPxPrecision: AvgPxPrecision option
    Parties: Parties option // component
    TradeDate: TradeDate
    TransactTime: TransactTime option
    SettlType: SettlType option
    SettlDate: SettlDate option
    BookingType: BookingType option
    GrossTradeAmt: GrossTradeAmt option
    Concession: Concession option
    TotalTakedown: TotalTakedown option
    NetMoney: NetMoney option
    PositionEffect: PositionEffect option
    AutoAcceptIndicator: AutoAcceptIndicator option
    Text: Text option
    EncodedText: EncodedText option
    NumDaysInterest: NumDaysInterest option
    AccruedInterestRate: AccruedInterestRate option
    AccruedInterestAmt: AccruedInterestAmt option
    TotalAccruedInterestAmt: TotalAccruedInterestAmt option
    InterestAtMaturity: InterestAtMaturity option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    StartCash: StartCash option
    EndCash: EndCash option
    LegalConfirm: LegalConfirm option
    Stipulations: Stipulations option // component
    YieldData: YieldData option // component
    TotNoAllocs: TotNoAllocs option
    LastFragment: LastFragment option
    AllocationReportNoAllocsGrp: AllocationReportNoAllocsGrp list // group
    }

type AllocationReportAck = {
    AllocReportID: AllocReportID
    AllocID: AllocID
    Parties: Parties option // component
    SecondaryAllocID: SecondaryAllocID option
    TradeDate: TradeDate option
    TransactTime: TransactTime
    AllocStatus: AllocStatus
    AllocRejCode: AllocRejCode option
    AllocReportType: AllocReportType option
    AllocIntermedReqType: AllocIntermedReqType option
    MatchStatus: MatchStatus option
    Product: Product option
    SecurityType: SecurityType option
    Text: Text option
    EncodedText: EncodedText option
    AllocationReportAckNoAllocsGrp: AllocationReportAckNoAllocsGrp list option // group
    }

type Confirmation = {
    ConfirmID: ConfirmID
    ConfirmRefID: ConfirmRefID option
    ConfirmReqID: ConfirmReqID option
    ConfirmTransType: ConfirmTransType
    ConfirmType: ConfirmType
    CopyMsgIndicator: CopyMsgIndicator option
    LegalConfirm: LegalConfirm option
    ConfirmStatus: ConfirmStatus
    Parties: Parties option // component
    NoOrdersGrp: NoOrdersGrp list option // group
    AllocID: AllocID option
    SecondaryAllocID: SecondaryAllocID option
    IndividualAllocID: IndividualAllocID option
    TransactTime: TransactTime
    TradeDate: TradeDate
    TrdRegTimestamps: TrdRegTimestamps option // component
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list // group
    NoLegsGrp: NoLegsGrp list // group
    YieldData: YieldData option // component
    AllocQty: AllocQty
    QtyType: QtyType option
    Side: Side
    Currency: Currency option
    LastMkt: LastMkt option
    NoCapacitiesGrp: NoCapacitiesGrp list // group
    AllocAccount: AllocAccount
    AllocAcctIDSource: AllocAcctIDSource option
    AllocAccountType: AllocAccountType option
    AvgPx: AvgPx
    AvgPxPrecision: AvgPxPrecision option
    PriceType: PriceType option
    AvgParPx: AvgParPx option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    ReportedPx: ReportedPx option
    Text: Text option
    EncodedText: EncodedText option
    ProcessCode: ProcessCode option
    GrossTradeAmt: GrossTradeAmt
    NumDaysInterest: NumDaysInterest option
    ExDate: ExDate option
    AccruedInterestRate: AccruedInterestRate option
    AccruedInterestAmt: AccruedInterestAmt option
    InterestAtMaturity: InterestAtMaturity option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    StartCash: StartCash option
    EndCash: EndCash option
    Concession: Concession option
    TotalTakedown: TotalTakedown option
    NetMoney: NetMoney
    MaturityNetMoney: MaturityNetMoney option
    SettlCurrAmt: SettlCurrAmt option
    SettlCurrency: SettlCurrency option
    SettlCurrFxRate: SettlCurrFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    SettlType: SettlType option
    SettlDate: SettlDate option
    SettlInstructionsData: SettlInstructionsData option // component
    CommissionData: CommissionData option // component
    SharedCommission: SharedCommission option
    Stipulations: Stipulations option // component
    NoMiscFeesGrp: NoMiscFeesGrp list option // group
    }

type ConfirmationAck = {
    ConfirmID: ConfirmID
    TradeDate: TradeDate
    TransactTime: TransactTime
    AffirmStatus: AffirmStatus
    ConfirmRejReason: ConfirmRejReason option
    MatchStatus: MatchStatus option
    Text: Text option
    EncodedText: EncodedText option
    }

type ConfirmationRequest = {
    ConfirmReqID: ConfirmReqID
    ConfirmType: ConfirmType
    NoOrdersGrp: NoOrdersGrp list option // group
    AllocID: AllocID option
    SecondaryAllocID: SecondaryAllocID option
    IndividualAllocID: IndividualAllocID option
    TransactTime: TransactTime
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocAccountType: AllocAccountType option
    Text: Text option
    EncodedText: EncodedText option
    }

type SettlementInstructions = {
    SettlInstMsgID: SettlInstMsgID
    SettlInstReqID: SettlInstReqID option
    SettlInstMode: SettlInstMode
    SettlInstReqRejCode: SettlInstReqRejCode option
    Text: Text option
    EncodedText: EncodedText option
    SettlInstSource: SettlInstSource option
    ClOrdID: ClOrdID option
    TransactTime: TransactTime
    NoSettlInstGrp: NoSettlInstGrp list option // group
    }

type SettlementInstructionRequest = {
    SettlInstReqID: SettlInstReqID
    TransactTime: TransactTime
    Parties: Parties option // component
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    Side: Side option
    Product: Product option
    SecurityType: SecurityType option
    CFICode: CFICode option
    EffectiveTime: EffectiveTime option
    ExpireTime: ExpireTime option
    LastUpdateTime: LastUpdateTime option
    StandInstDbType: StandInstDbType option
    StandInstDbName: StandInstDbName option
    StandInstDbID: StandInstDbID option
    }

type TradeCaptureReportRequest = {
    TradeRequestID: TradeRequestID
    TradeRequestType: TradeRequestType
    SubscriptionRequestType: SubscriptionRequestType option
    TradeReportID: TradeReportID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    ExecID: ExecID option
    ExecType: ExecType option
    OrderID: OrderID option
    ClOrdID: ClOrdID option
    MatchStatus: MatchStatus option
    TrdType: TrdType option
    TrdSubType: TrdSubType option
    TransferReason: TransferReason option
    SecondaryTrdType: SecondaryTrdType option
    TradeLinkID: TradeLinkID option
    TrdMatchID: TrdMatchID option
    Parties: Parties option // component
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    NoDatesGrp: NoDatesGrp list option // group
    ClearingBusinessDate: ClearingBusinessDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TimeBracket: TimeBracket option
    Side: Side option
    MultiLegReportingType: MultiLegReportingType option
    TradeInputSource: TradeInputSource option
    TradeInputDevice: TradeInputDevice option
    ResponseTransportType: ResponseTransportType option
    ResponseDestination: ResponseDestination option
    Text: Text option
    EncodedText: EncodedText option
    }

type TradeCaptureReportRequestAck = {
    TradeRequestID: TradeRequestID
    TradeRequestType: TradeRequestType
    SubscriptionRequestType: SubscriptionRequestType option
    TotNumTradeReports: TotNumTradeReports option
    TradeRequestResult: TradeRequestResult
    TradeRequestStatus: TradeRequestStatus
    Instrument: Instrument option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoLegsGrp: NoLegsGrp list option // group
    MultiLegReportingType: MultiLegReportingType option
    ResponseTransportType: ResponseTransportType option
    ResponseDestination: ResponseDestination option
    Text: Text option
    EncodedText: EncodedText option
    }

type TradeCaptureReport = {
    TradeReportID: TradeReportID
    TradeReportTransType: TradeReportTransType option
    TradeReportType: TradeReportType option
    TradeRequestID: TradeRequestID option
    TrdType: TrdType option
    TrdSubType: TrdSubType option
    SecondaryTrdType: SecondaryTrdType option
    TransferReason: TransferReason option
    ExecType: ExecType option
    TotNumTradeReports: TotNumTradeReports option
    LastRptRequested: LastRptRequested option
    UnsolicitedIndicator: UnsolicitedIndicator option
    SubscriptionRequestType: SubscriptionRequestType option
    TradeReportRefID: TradeReportRefID option
    SecondaryTradeReportRefID: SecondaryTradeReportRefID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    TradeLinkID: TradeLinkID option
    TrdMatchID: TrdMatchID option
    ExecID: ExecID option
    OrdStatus: OrdStatus option
    SecondaryExecID: SecondaryExecID option
    ExecRestatementReason: ExecRestatementReason option
    PreviouslyReported: PreviouslyReported
    PriceType: PriceType option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    OrderQtyData: OrderQtyData option // component
    QtyType: QtyType option
    YieldData: YieldData option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    UnderlyingTradingSessionID: UnderlyingTradingSessionID option
    UnderlyingTradingSessionSubID: UnderlyingTradingSessionSubID option
    LastQty: LastQty
    LastPx: LastPx
    LastParPx: LastParPx option
    LastSpotRate: LastSpotRate option
    LastForwardPoints: LastForwardPoints option
    LastMkt: LastMkt option
    TradeDate: TradeDate
    ClearingBusinessDate: ClearingBusinessDate option
    AvgPx: AvgPx option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    AvgPxIndicator: AvgPxIndicator option
    PositionAmountData: PositionAmountData option // component
    MultiLegReportingType: MultiLegReportingType option
    TradeLegRefID: TradeLegRefID option
    TradeCaptureReportNoLegsGrp: TradeCaptureReportNoLegsGrp list option // group
    TransactTime: TransactTime
    TrdRegTimestamps: TrdRegTimestamps option // component
    SettlType: SettlType option
    SettlDate: SettlDate option
    MatchStatus: MatchStatus option
    MatchType: MatchType option
    TradeCaptureReportNoSidesGrp: TradeCaptureReportNoSidesGrp OneOrTwo // group
    CopyMsgIndicator: CopyMsgIndicator option
    PublishTrdIndicator: PublishTrdIndicator option
    ShortSaleReason: ShortSaleReason option
    }

type TradeCaptureReportAck = {
    TradeReportID: TradeReportID
    TradeReportTransType: TradeReportTransType option
    TradeReportType: TradeReportType option
    TrdType: TrdType option
    TrdSubType: TrdSubType option
    SecondaryTrdType: SecondaryTrdType option
    TransferReason: TransferReason option
    ExecType: ExecType
    TradeReportRefID: TradeReportRefID option
    SecondaryTradeReportRefID: SecondaryTradeReportRefID option
    TrdRptStatus: TrdRptStatus option
    TradeReportRejectReason: TradeReportRejectReason option
    SecondaryTradeReportID: SecondaryTradeReportID option
    SubscriptionRequestType: SubscriptionRequestType option
    TradeLinkID: TradeLinkID option
    TrdMatchID: TrdMatchID option
    ExecID: ExecID option
    SecondaryExecID: SecondaryExecID option
    Instrument: Instrument // component
    TransactTime: TransactTime option
    TrdRegTimestamps: TrdRegTimestamps option // component
    ResponseTransportType: ResponseTransportType option
    ResponseDestination: ResponseDestination option
    Text: Text option
    EncodedText: EncodedText option
    TradeCaptureReportAckNoLegsGrp: TradeCaptureReportAckNoLegsGrp list option // group
    ClearingFeeIndicator: ClearingFeeIndicator option
    OrderCapacity: OrderCapacity option
    OrderRestrictions: OrderRestrictions option
    CustOrderCapacity: CustOrderCapacity option
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    PositionEffect: PositionEffect option
    PreallocMethod: PreallocMethod option
    TradeCaptureReportAckNoAllocsGrp: TradeCaptureReportAckNoAllocsGrp list option // group
    }

type RegistrationInstructions = {
    RegistID: RegistID
    RegistTransType: RegistTransType
    RegistRefID: RegistRefID
    ClOrdID: ClOrdID option
    Parties: Parties option // component
    Account: Account option
    AcctIDSource: AcctIDSource option
    RegistAcctType: RegistAcctType option
    TaxAdvantageType: TaxAdvantageType option
    OwnershipType: OwnershipType option
    NoRegistDtlsGrp: NoRegistDtlsGrp list option // group
    NoDistribInstsGrp: NoDistribInstsGrp list option // group
    }

type RegistrationInstructionsResponse = {
    RegistID: RegistID
    RegistTransType: RegistTransType
    RegistRefID: RegistRefID
    ClOrdID: ClOrdID option
    Parties: Parties option // component
    Account: Account option
    AcctIDSource: AcctIDSource option
    RegistStatus: RegistStatus
    RegistRejReasonCode: RegistRejReasonCode option
    RegistRejReasonText: RegistRejReasonText option
    }

type PositionMaintenanceRequest = {
    PosReqID: PosReqID
    PosTransType: PosTransType
    PosMaintAction: PosMaintAction
    OrigPosReqRefID: OrigPosReqRefID option
    PosMaintRptRefID: PosMaintRptRefID option
    ClearingBusinessDate: ClearingBusinessDate
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    Parties: Parties // component
    Account: Account
    AcctIDSource: AcctIDSource option
    AccountType: AccountType
    Instrument: Instrument // component
    Currency: Currency option
    NoLegsGrp: NoLegsGrp list option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoTradingSessionsGrp: NoTradingSessionsGrp list option // group
    TransactTime: TransactTime
    PositionQty: PositionQty // component
    AdjustmentType: AdjustmentType option
    ContraryInstructionIndicator: ContraryInstructionIndicator option
    PriorSpreadIndicator: PriorSpreadIndicator option
    ThresholdAmount: ThresholdAmount option
    Text: Text option
    EncodedText: EncodedText option
    }

type PositionMaintenanceReport = {
    PosMaintRptID: PosMaintRptID
    PosTransType: PosTransType
    PosReqID: PosReqID option
    PosMaintAction: PosMaintAction
    OrigPosReqRefID: OrigPosReqRefID
    PosMaintStatus: PosMaintStatus
    PosMaintResult: PosMaintResult option
    ClearingBusinessDate: ClearingBusinessDate
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    Parties: Parties option // component
    Account: Account
    AcctIDSource: AcctIDSource option
    AccountType: AccountType
    Instrument: Instrument // component
    Currency: Currency option
    NoLegsGrp: NoLegsGrp list option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    NoTradingSessionsGrp: NoTradingSessionsGrp list option // group
    TransactTime: TransactTime
    PositionQty: PositionQty // component
    PositionAmountData: PositionAmountData // component
    AdjustmentType: AdjustmentType option
    ThresholdAmount: ThresholdAmount option
    Text: Text option
    EncodedText: EncodedText option
    }

type RequestForPositions = {
    PosReqID: PosReqID
    PosReqType: PosReqType
    MatchStatus: MatchStatus option
    SubscriptionRequestType: SubscriptionRequestType option
    Parties: Parties // component
    Account: Account
    AcctIDSource: AcctIDSource option
    AccountType: AccountType
    Instrument: Instrument option // component
    Currency: Currency option
    NoLegsGrp: NoLegsGrp list option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    ClearingBusinessDate: ClearingBusinessDate
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    NoTradingSessionsGrp: NoTradingSessionsGrp list option // group
    TransactTime: TransactTime
    ResponseTransportType: ResponseTransportType option
    ResponseDestination: ResponseDestination option
    Text: Text option
    EncodedText: EncodedText option
    }

type RequestForPositionsAck = {
    PosMaintRptID: PosMaintRptID
    PosReqID: PosReqID option
    TotalNumPosReports: TotalNumPosReports option
    UnsolicitedIndicator: UnsolicitedIndicator option
    PosReqResult: PosReqResult
    PosReqStatus: PosReqStatus
    Parties: Parties // component
    Account: Account
    AcctIDSource: AcctIDSource option
    AccountType: AccountType
    Instrument: Instrument option // component
    Currency: Currency option
    NoLegsGrp: NoLegsGrp list option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    ResponseTransportType: ResponseTransportType option
    ResponseDestination: ResponseDestination option
    Text: Text option
    EncodedText: EncodedText option
    }

type PositionReport = {
    PosMaintRptID: PosMaintRptID
    PosReqID: PosReqID option
    PosReqType: PosReqType option
    SubscriptionRequestType: SubscriptionRequestType option
    TotalNumPosReports: TotalNumPosReports option
    UnsolicitedIndicator: UnsolicitedIndicator option
    PosReqResult: PosReqResult
    ClearingBusinessDate: ClearingBusinessDate
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    Parties: Parties // component
    Account: Account
    AcctIDSource: AcctIDSource option
    AccountType: AccountType
    Instrument: Instrument option // component
    Currency: Currency option
    SettlPrice: SettlPrice
    SettlPriceType: SettlPriceType
    PriorSettlPrice: PriorSettlPrice
    NoLegsGrp: NoLegsGrp list option // group
    PositionReportNoUnderlyingsGrp: PositionReportNoUnderlyingsGrp list option // group
    PositionQty: PositionQty // component
    PositionAmountData: PositionAmountData // component
    RegistStatus: RegistStatus option
    DeliveryDate: DeliveryDate option
    Text: Text option
    EncodedText: EncodedText option
    }

type AssignmentReport = {
    AsgnRptID: AsgnRptID
    TotNumAssignmentReports: TotNumAssignmentReports option
    LastRptRequested: LastRptRequested option
    Parties: Parties // component
    Account: Account option
    AccountType: AccountType
    Instrument: Instrument option // component
    Currency: Currency option
    NoLegs: NoLegs option
    InstrumentLeg: InstrumentLeg option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    PositionQty: PositionQty // component
    PositionAmountData: PositionAmountData // component
    ThresholdAmount: ThresholdAmount option
    SettlPrice: SettlPrice
    SettlPriceType: SettlPriceType
    UnderlyingSettlPrice: UnderlyingSettlPrice
    ExpireDate: ExpireDate option
    AssignmentMethod: AssignmentMethod
    AssignmentUnit: AssignmentUnit option
    OpenInterest: OpenInterest
    ExerciseMethod: ExerciseMethod
    SettlSessID: SettlSessID
    SettlSessSubID: SettlSessSubID
    ClearingBusinessDate: ClearingBusinessDate
    Text: Text option
    EncodedText: EncodedText option
    }

type CollateralRequest = {
    CollReqID: CollReqID
    CollAsgnReason: CollAsgnReason
    TransactTime: TransactTime
    ExpireTime: ExpireTime option
    Parties: Parties option // component
    Account: Account option
    AccountType: AccountType option
    ClOrdID: ClOrdID option
    OrderID: OrderID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    NoExecsGrp: NoExecsGrp list option // group
    NoTradesGrp: NoTradesGrp list option // group
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    SettlDate: SettlDate option
    Quantity: Quantity option
    QtyType: QtyType option
    Currency: Currency option
    NoLegs: NoLegs option
    InstrumentLeg: InstrumentLeg option // component
    CollateralRequestNoUnderlyingsGrp: CollateralRequestNoUnderlyingsGrp list option // group
    MarginExcess: MarginExcess option
    TotalNetValue: TotalNetValue option
    CashOutstanding: CashOutstanding option
    TrdRegTimestamps: TrdRegTimestamps option // component
    Side: Side option
    NoMiscFeesGrp: NoMiscFeesGrp list option // group
    Price: Price option
    PriceType: PriceType option
    AccruedInterestAmt: AccruedInterestAmt option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    StartCash: StartCash option
    EndCash: EndCash option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    ClearingBusinessDate: ClearingBusinessDate option
    Text: Text option
    EncodedText: EncodedText option
    }

type CollateralAssignment = {
    CollAsgnID: CollAsgnID
    CollReqID: CollReqID option
    CollAsgnReason: CollAsgnReason
    CollAsgnTransType: CollAsgnTransType
    CollAsgnRefID: CollAsgnRefID option
    TransactTime: TransactTime
    ExpireTime: ExpireTime option
    Parties: Parties option // component
    Account: Account option
    AccountType: AccountType option
    ClOrdID: ClOrdID option
    OrderID: OrderID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    NoExecsGrp: NoExecsGrp list option // group
    NoTradesGrp: NoTradesGrp list option // group
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    SettlDate: SettlDate option
    Quantity: Quantity option
    QtyType: QtyType option
    Currency: Currency option
    NoLegs: NoLegs option
    InstrumentLeg: InstrumentLeg option // component
    CollateralAssignmentNoUnderlyingsGrp: CollateralAssignmentNoUnderlyingsGrp list option // group
    MarginExcess: MarginExcess option
    TotalNetValue: TotalNetValue option
    CashOutstanding: CashOutstanding option
    TrdRegTimestamps: TrdRegTimestamps option // component
    Side: Side option
    NoMiscFeesGrp: NoMiscFeesGrp list option // group
    Price: Price option
    PriceType: PriceType option
    AccruedInterestAmt: AccruedInterestAmt option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    StartCash: StartCash option
    EndCash: EndCash option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    SettlInstructionsData: SettlInstructionsData option // component
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    ClearingBusinessDate: ClearingBusinessDate option
    Text: Text option
    EncodedText: EncodedText option
    }

type CollateralResponse = {
    CollRespID: CollRespID
    CollAsgnID: CollAsgnID
    CollReqID: CollReqID option
    CollAsgnReason: CollAsgnReason
    CollAsgnTransType: CollAsgnTransType option
    CollAsgnRespType: CollAsgnRespType
    CollAsgnRejectReason: CollAsgnRejectReason option
    TransactTime: TransactTime
    Parties: Parties option // component
    Account: Account option
    AccountType: AccountType option
    ClOrdID: ClOrdID option
    OrderID: OrderID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    NoExecsGrp: NoExecsGrp list option // group
    NoTradesGrp: NoTradesGrp list option // group
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    SettlDate: SettlDate option
    Quantity: Quantity option
    QtyType: QtyType option
    Currency: Currency option
    NoLegs: NoLegs option
    InstrumentLeg: InstrumentLeg option // component
    CollateralResponseNoUnderlyingsGrp: CollateralResponseNoUnderlyingsGrp list option // group
    MarginExcess: MarginExcess option
    TotalNetValue: TotalNetValue option
    CashOutstanding: CashOutstanding option
    TrdRegTimestamps: TrdRegTimestamps option // component
    Side: Side option
    NoMiscFeesGrp: NoMiscFeesGrp list option // group
    Price: Price option
    PriceType: PriceType option
    AccruedInterestAmt: AccruedInterestAmt option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    StartCash: StartCash option
    EndCash: EndCash option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    Text: Text option
    EncodedText: EncodedText option
    }

type CollateralReport = {
    CollRptID: CollRptID
    CollInquiryID: CollInquiryID option
    CollStatus: CollStatus
    TotNumReports: TotNumReports option
    LastRptRequested: LastRptRequested option
    Parties: Parties option // component
    Account: Account option
    AccountType: AccountType option
    ClOrdID: ClOrdID option
    OrderID: OrderID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    NoExecsGrp: NoExecsGrp list option // group
    NoTradesGrp: NoTradesGrp list option // group
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    SettlDate: SettlDate option
    Quantity: Quantity option
    QtyType: QtyType option
    Currency: Currency option
    NoLegs: NoLegs option
    InstrumentLeg: InstrumentLeg option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    MarginExcess: MarginExcess option
    TotalNetValue: TotalNetValue option
    CashOutstanding: CashOutstanding option
    TrdRegTimestamps: TrdRegTimestamps option // component
    Side: Side option
    NoMiscFeesGrp: NoMiscFeesGrp list option // group
    Price: Price option
    PriceType: PriceType option
    AccruedInterestAmt: AccruedInterestAmt option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    StartCash: StartCash option
    EndCash: EndCash option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    SettlInstructionsData: SettlInstructionsData option // component
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    ClearingBusinessDate: ClearingBusinessDate option
    Text: Text option
    EncodedText: EncodedText option
    }

type CollateralInquiry = {
    CollInquiryID: CollInquiryID option
    NoCollInquiryQualifierGrp: NoCollInquiryQualifierGrp list option // group
    SubscriptionRequestType: SubscriptionRequestType option
    ResponseTransportType: ResponseTransportType option
    ResponseDestination: ResponseDestination option
    Parties: Parties option // component
    Account: Account option
    AccountType: AccountType option
    ClOrdID: ClOrdID option
    OrderID: OrderID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    NoExecsGrp: NoExecsGrp list option // group
    NoTradesGrp: NoTradesGrp list option // group
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    SettlDate: SettlDate option
    Quantity: Quantity option
    QtyType: QtyType option
    Currency: Currency option
    NoLegs: NoLegs option
    InstrumentLeg: InstrumentLeg option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    MarginExcess: MarginExcess option
    TotalNetValue: TotalNetValue option
    CashOutstanding: CashOutstanding option
    TrdRegTimestamps: TrdRegTimestamps option // component
    Side: Side option
    Price: Price option
    PriceType: PriceType option
    AccruedInterestAmt: AccruedInterestAmt option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    StartCash: StartCash option
    EndCash: EndCash option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    SettlInstructionsData: SettlInstructionsData option // component
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    ClearingBusinessDate: ClearingBusinessDate option
    Text: Text option
    EncodedText: EncodedText option
    }

type NetworkStatusRequest = {
    NetworkRequestType: NetworkRequestType
    NetworkRequestID: NetworkRequestID
    NoCompIDsGrp: NoCompIDsGrp list option // group
    }

type NetworkStatusResponse = {
    NetworkStatusResponseType: NetworkStatusResponseType
    NetworkRequestID: NetworkRequestID option
    NetworkResponseID: NetworkResponseID option
    LastNetworkResponseID: LastNetworkResponseID option
    NetworkStatusResponseNoCompIDsGrp: NetworkStatusResponseNoCompIDsGrp list // group
    }

type CollateralInquiryAck = {
    CollInquiryID: CollInquiryID
    CollInquiryStatus: CollInquiryStatus
    CollInquiryResult: CollInquiryResult option
    NoCollInquiryQualifierGrp: NoCollInquiryQualifierGrp list option // group
    TotNumReports: TotNumReports option
    Parties: Parties option // component
    Account: Account option
    AccountType: AccountType option
    ClOrdID: ClOrdID option
    OrderID: OrderID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    NoExecsGrp: NoExecsGrp list option // group
    NoTradesGrp: NoTradesGrp list option // group
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    SettlDate: SettlDate option
    Quantity: Quantity option
    QtyType: QtyType option
    Currency: Currency option
    NoLegs: NoLegs option
    InstrumentLeg: InstrumentLeg option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    ClearingBusinessDate: ClearingBusinessDate option
    ResponseTransportType: ResponseTransportType option
    ResponseDestination: ResponseDestination option
    Text: Text option
    EncodedText: EncodedText option
    }
