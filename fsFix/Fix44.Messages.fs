module Fix44.Messages

open Fix44.Fields
open Fix44.CompoundItems



// message
type Heartbeat = {
    TestReqID: TestReqID option
    }

// message
type Logon = {
    EncryptMethod: EncryptMethod
    HeartBtInt: HeartBtInt
    MaxMessageSize: MaxMessageSize option
    MsgDirection: MsgDirection option
    NextExpectedMsgSeqNum: NextExpectedMsgSeqNum option
    NoMsgTypesGrp: NoMsgTypesGrp option // group
    Password: Password option
    RawData: RawData option
    RawDataLength: RawDataLength option
    RefMsgType: RefMsgType option
    ResetSeqNumFlag: ResetSeqNumFlag option
    TestMessageIndicator: TestMessageIndicator option
    Username: Username option
    }

// message
type TestRequest = {
    TestReqID: TestReqID
    }

// message
type ResendRequest = {
    BeginSeqNo: BeginSeqNo
    EndSeqNo: EndSeqNo
    }

// message
type Reject = {
    EncodedText: EncodedText option
    RefMsgType: RefMsgType option
    RefSeqNum: RefSeqNum
    RefTagID: RefTagID option
    SessionRejectReason: SessionRejectReason option
    Text: Text option
    }

// message
type SequenceReset = {
    GapFillFlag: GapFillFlag option
    NewSeqNo: NewSeqNo
    }

// message
type Logout = {
    EncodedText: EncodedText option
    Text: Text option
    }

// message
type BusinessMessageReject = {
    BusinessRejectReason: BusinessRejectReason
    BusinessRejectRefID: BusinessRejectRefID option
    EncodedText: EncodedText option
    RefMsgType: RefMsgType
    RefSeqNum: RefSeqNum option
    Text: Text option
    }

// message
type UserRequest = {
    NewPassword: NewPassword option
    Password: Password option
    RawData: RawData option
    RawDataLength: RawDataLength option
    UserRequestID: UserRequestID
    UserRequestType: UserRequestType
    Username: Username
    }

// message
type UserResponse = {
    UserRequestID: UserRequestID
    UserStatus: UserStatus option
    UserStatusText: UserStatusText option
    Username: Username
    }

// message
type Advertisement = {
    AdvId: AdvId
    AdvRefID: AdvRefID option
    AdvSide: AdvSide
    AdvTransType: AdvTransType
    Advertisement_NoUnderlyings_NoUnderlyingsGrp: Advertisement_NoUnderlyings_NoUnderlyingsGrp option // group
    Currency: Currency option
    EncodedText: EncodedText option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LastMkt: LastMkt option
    NoLegsGrp: NoLegsGrp option // group
    Price: Price option
    QtyType: QtyType option
    Quantity: Quantity
    Text: Text option
    TradeDate: TradeDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    URLLink: URLLink option
    UnderlyingInstrument: UnderlyingInstrument // component
    }

// message
type IndicationOfInterest = {
    Currency: Currency option
    EncodedText: EncodedText option
    FinancingDetails: FinancingDetails option // component
    IOINaturalFlag: IOINaturalFlag option
    IOIQltyInd: IOIQltyInd option
    IOIQty: IOIQty
    IOIQualifier: IOIQualifier option
    IOIRefID: IOIRefID option
    IOITransType: IOITransType
    IOIid: IOIid
    IndicationOfInterest_NoLegs_NoLegsGrp: IndicationOfInterest_NoLegs_NoLegsGrp option // group
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LegIOIQty: LegIOIQty option
    LegStipulations: LegStipulations option // component
    NoIOIQualifiersGrp: NoIOIQualifiersGrp option // group
    NoRoutingIDsGrp: NoRoutingIDsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrderQtyData: OrderQtyData option // component
    Price: Price option
    PriceType: PriceType option
    QtyType: QtyType option
    RoutingID: RoutingID option
    RoutingType: RoutingType option
    Side: Side
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    Text: Text option
    TransactTime: TransactTime option
    URLLink: URLLink option
    UnderlyingInstrument: UnderlyingInstrument option // component
    ValidUntilTime: ValidUntilTime option
    YieldData: YieldData option // component
    }

// message
type News = {
    EncodedHeadline: EncodedHeadline option
    EncodedText: EncodedText option
    Headline: Headline
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    LinesOfTextGrp: LinesOfTextGrp // group
    NoLegsGrp: NoLegsGrp option // group
    NoRelatedSymGrp: NoRelatedSymGrp option // group
    NoRoutingIDsGrp: NoRoutingIDsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrigTime: OrigTime option
    RawData: RawData option
    RawDataLength: RawDataLength option
    RoutingID: RoutingID option
    RoutingType: RoutingType option
    Text: Text
    URLLink: URLLink option
    UnderlyingInstrument: UnderlyingInstrument option // component
    Urgency: Urgency option
    }

// message
type Email = {
    ClOrdID: ClOrdID option
    EmailThreadID: EmailThreadID
    EmailType: EmailType
    EncodedSubject: EncodedSubject option
    EncodedText: EncodedText option
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    LinesOfTextGrp: LinesOfTextGrp // group
    NoLegsGrp: NoLegsGrp option // group
    NoRelatedSymGrp: NoRelatedSymGrp option // group
    NoRoutingIDsGrp: NoRoutingIDsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrderID: OrderID option
    OrigTime: OrigTime option
    RawData: RawData option
    RawDataLength: RawDataLength option
    RoutingID: RoutingID option
    RoutingType: RoutingType option
    Subject: Subject
    Text: Text
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type QuoteRequest = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    ClOrdID: ClOrdID option
    Currency: Currency option
    EncodedText: EncodedText option
    ExpireTime: ExpireTime option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    LegQty: LegQty option
    LegSettlDate: LegSettlDate option
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegSwapType: LegSwapType option
    NestedParties: NestedParties option // component
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrdType: OrdType option
    OrderCapacity: OrderCapacity option
    OrderQty2: OrderQty2 option
    OrderQtyData: OrderQtyData option // component
    Parties: Parties option // component
    PrevClosePx: PrevClosePx option
    Price2: Price2 option
    Price: Price option
    PriceType: PriceType option
    QtyType: QtyType option
    QuotePriceType: QuotePriceType option
    QuoteQualifier: QuoteQualifier option
    QuoteReqID: QuoteReqID
    QuoteRequestType: QuoteRequestType option
    QuoteRequest_NoLegs_NoLegsGrp: QuoteRequest_NoLegs_NoLegsGrp option // group
    QuoteRequest_NoRelatedSym_NoRelatedSymGrp: QuoteRequest_NoRelatedSym_NoRelatedSymGrp // group
    QuoteType: QuoteType option
    RFQReqID: RFQReqID option
    SettlDate2: SettlDate2 option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    Text: Text option
    TradeOriginationDate: TradeOriginationDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    UnderlyingInstrument: UnderlyingInstrument option // component
    ValidUntilTime: ValidUntilTime option
    YieldData: YieldData option // component
    }

// message
type QuoteResponse = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    BidForwardPoints2: BidForwardPoints2 option
    BidForwardPoints: BidForwardPoints option
    BidPx: BidPx option
    BidSize: BidSize option
    BidSpotRate: BidSpotRate option
    BidYield: BidYield option
    ClOrdID: ClOrdID option
    CommType: CommType option
    Commission: Commission option
    Currency: Currency option
    CustOrderCapacity: CustOrderCapacity option
    EncodedText: EncodedText option
    ExDestination: ExDestination option
    FinancingDetails: FinancingDetails option // component
    IOIid: IOIid option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    LegBidPx: LegBidPx option
    LegOfferPx: LegOfferPx option
    LegPriceType: LegPriceType option
    LegQty: LegQty option
    LegSettlDate: LegSettlDate option
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegSwapType: LegSwapType option
    MidPx: MidPx option
    MidYield: MidYield option
    MinBidSize: MinBidSize option
    MinOfferSize: MinOfferSize option
    MktBidPx: MktBidPx option
    MktOfferPx: MktOfferPx option
    NestedParties: NestedParties option // component
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OfferForwardPoints2: OfferForwardPoints2 option
    OfferForwardPoints: OfferForwardPoints option
    OfferPx: OfferPx option
    OfferSize: OfferSize option
    OfferSpotRate: OfferSpotRate option
    OfferYield: OfferYield option
    OrdType: OrdType option
    OrderCapacity: OrderCapacity option
    OrderQty2: OrderQty2 option
    OrderQtyData: OrderQtyData option // component
    Parties: Parties option // component
    Price: Price option
    PriceType: PriceType option
    QuoteID: QuoteID option
    QuoteQualifier: QuoteQualifier option
    QuoteRespID: QuoteRespID
    QuoteRespType: QuoteRespType
    QuoteResponse_NoLegs_NoLegsGrp: QuoteResponse_NoLegs_NoLegsGrp option // group
    QuoteType: QuoteType option
    SettlCurrBidFxRate: SettlCurrBidFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    SettlCurrOfferFxRate: SettlCurrOfferFxRate option
    SettlDate2: SettlDate2 option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    Text: Text option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    UnderlyingInstrument: UnderlyingInstrument option // component
    ValidUntilTime: ValidUntilTime option
    YieldData: YieldData option // component
    }

// message
type QuoteRequestReject = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    Currency: Currency option
    EncodedText: EncodedText option
    ExpireTime: ExpireTime option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    LegQty: LegQty option
    LegSettlDate: LegSettlDate option
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegSwapType: LegSwapType option
    NestedParties: NestedParties option // component
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrdType: OrdType option
    OrderQty2: OrderQty2 option
    OrderQtyData: OrderQtyData option // component
    Parties: Parties option // component
    PrevClosePx: PrevClosePx option
    Price2: Price2 option
    Price: Price option
    PriceType: PriceType option
    QtyType: QtyType option
    QuotePriceType: QuotePriceType option
    QuoteQualifier: QuoteQualifier option
    QuoteReqID: QuoteReqID
    QuoteRequestRejectReason: QuoteRequestRejectReason
    QuoteRequestReject_NoLegs_NoLegsGrp: QuoteRequestReject_NoLegs_NoLegsGrp option // group
    QuoteRequestReject_NoRelatedSym_NoRelatedSymGrp: QuoteRequestReject_NoRelatedSym_NoRelatedSymGrp // group
    QuoteRequestType: QuoteRequestType option
    QuoteType: QuoteType option
    RFQReqID: RFQReqID option
    SettlDate2: SettlDate2 option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    Text: Text option
    TradeOriginationDate: TradeOriginationDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    UnderlyingInstrument: UnderlyingInstrument option // component
    YieldData: YieldData option // component
    }

// message
type RFQRequest = {
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    NoLegsGrp: NoLegsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    PrevClosePx: PrevClosePx option
    QuoteRequestType: QuoteRequestType option
    QuoteType: QuoteType option
    RFQReqID: RFQReqID
    RFQRequest_NoRelatedSym_NoRelatedSymGrp: RFQRequest_NoRelatedSym_NoRelatedSymGrp // group
    SubscriptionRequestType: SubscriptionRequestType option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type Quote = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    BidForwardPoints2: BidForwardPoints2 option
    BidForwardPoints: BidForwardPoints option
    BidPx: BidPx option
    BidSize: BidSize option
    BidSpotRate: BidSpotRate option
    BidYield: BidYield option
    CommType: CommType option
    Commission: Commission option
    Currency: Currency option
    CustOrderCapacity: CustOrderCapacity option
    EncodedText: EncodedText option
    ExDestination: ExDestination option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    LegBidPx: LegBidPx option
    LegOfferPx: LegOfferPx option
    LegPriceType: LegPriceType option
    LegQty: LegQty option
    LegSettlDate: LegSettlDate option
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegSwapType: LegSwapType option
    MidPx: MidPx option
    MidYield: MidYield option
    MinBidSize: MinBidSize option
    MinOfferSize: MinOfferSize option
    MktBidPx: MktBidPx option
    MktOfferPx: MktOfferPx option
    NestedParties: NestedParties option // component
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OfferForwardPoints2: OfferForwardPoints2 option
    OfferForwardPoints: OfferForwardPoints option
    OfferPx: OfferPx option
    OfferSize: OfferSize option
    OfferSpotRate: OfferSpotRate option
    OfferYield: OfferYield option
    OrdType: OrdType option
    OrderCapacity: OrderCapacity option
    OrderQty2: OrderQty2 option
    OrderQtyData: OrderQtyData option // component
    Parties: Parties option // component
    PriceType: PriceType option
    QuoteID: QuoteID
    QuoteQualifier: QuoteQualifier option
    QuoteReqID: QuoteReqID option
    QuoteRespID: QuoteRespID option
    QuoteResponseLevel: QuoteResponseLevel option
    QuoteType: QuoteType option
    Quote_NoLegs_NoLegsGrp: Quote_NoLegs_NoLegsGrp option // group
    SettlCurrBidFxRate: SettlCurrBidFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    SettlCurrOfferFxRate: SettlCurrOfferFxRate option
    SettlDate2: SettlDate2 option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    Text: Text option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    UnderlyingInstrument: UnderlyingInstrument option // component
    ValidUntilTime: ValidUntilTime option
    YieldData: YieldData option // component
    }

// message
type QuoteCancel = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    NoLegsGrp: NoLegsGrp option // group
    NoQuoteEntriesGrp: NoQuoteEntriesGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    Parties: Parties option // component
    QuoteCancelType: QuoteCancelType
    QuoteID: QuoteID
    QuoteReqID: QuoteReqID option
    QuoteResponseLevel: QuoteResponseLevel option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type QuoteStatusRequest = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    NoLegsGrp: NoLegsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    Parties: Parties option // component
    QuoteID: QuoteID option
    QuoteStatusReqID: QuoteStatusReqID option
    SubscriptionRequestType: SubscriptionRequestType option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type QuoteStatusReport = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    BidForwardPoints2: BidForwardPoints2 option
    BidForwardPoints: BidForwardPoints option
    BidPx: BidPx option
    BidSize: BidSize option
    BidSpotRate: BidSpotRate option
    BidYield: BidYield option
    CommType: CommType option
    Commission: Commission option
    Currency: Currency option
    CustOrderCapacity: CustOrderCapacity option
    EncodedText: EncodedText option
    ExDestination: ExDestination option
    ExpireTime: ExpireTime option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSettlDate: LegSettlDate option
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegSwapType: LegSwapType option
    MidPx: MidPx option
    MidYield: MidYield option
    MinBidSize: MinBidSize option
    MinOfferSize: MinOfferSize option
    MktBidPx: MktBidPx option
    MktOfferPx: MktOfferPx option
    NestedParties: NestedParties option // component
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OfferForwardPoints2: OfferForwardPoints2 option
    OfferForwardPoints: OfferForwardPoints option
    OfferPx: OfferPx option
    OfferSize: OfferSize option
    OfferSpotRate: OfferSpotRate option
    OfferYield: OfferYield option
    OrdType: OrdType option
    OrderQty2: OrderQty2 option
    OrderQtyData: OrderQtyData option // component
    Parties: Parties option // component
    Price: Price option
    PriceType: PriceType option
    QuoteID: QuoteID
    QuoteQualifier: QuoteQualifier option
    QuoteReqID: QuoteReqID option
    QuoteRespID: QuoteRespID option
    QuoteStatus: QuoteStatus option
    QuoteStatusReport_NoLegs_NoLegsGrp: QuoteStatusReport_NoLegs_NoLegsGrp option // group
    QuoteStatusReqID: QuoteStatusReqID option
    QuoteType: QuoteType option
    SettlCurrBidFxRate: SettlCurrBidFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    SettlCurrOfferFxRate: SettlCurrOfferFxRate option
    SettlDate2: SettlDate2 option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    Text: Text option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    UnderlyingInstrument: UnderlyingInstrument option // component
    ValidUntilTime: ValidUntilTime option
    YieldData: YieldData option // component
    }

// message
type MassQuote = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    BidForwardPoints2: BidForwardPoints2 option
    BidForwardPoints: BidForwardPoints option
    BidPx: BidPx option
    BidSize: BidSize option
    BidSpotRate: BidSpotRate option
    BidYield: BidYield option
    Currency: Currency option
    DefBidSize: DefBidSize option
    DefOfferSize: DefOfferSize option
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    LastFragment: LastFragment option
    MassQuote_NoQuoteEntries_NoQuoteEntriesGrp: MassQuote_NoQuoteEntries_NoQuoteEntriesGrp // group
    MidPx: MidPx option
    MidYield: MidYield option
    NoLegsGrp: NoLegsGrp option // group
    NoQuoteSetsGrp: NoQuoteSetsGrp // group
    OfferForwardPoints2: OfferForwardPoints2 option
    OfferForwardPoints: OfferForwardPoints option
    OfferPx: OfferPx option
    OfferSize: OfferSize option
    OfferSpotRate: OfferSpotRate option
    OfferYield: OfferYield option
    OrdType: OrdType option
    OrderQty2: OrderQty2 option
    Parties: Parties option // component
    QuoteEntryID: QuoteEntryID
    QuoteID: QuoteID
    QuoteReqID: QuoteReqID option
    QuoteResponseLevel: QuoteResponseLevel option
    QuoteSetID: QuoteSetID
    QuoteSetValidUntilTime: QuoteSetValidUntilTime option
    QuoteType: QuoteType option
    SettlDate2: SettlDate2 option
    SettlDate: SettlDate option
    TotNoQuoteEntries: TotNoQuoteEntries
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    UnderlyingInstrument: UnderlyingInstrument option // component
    ValidUntilTime: ValidUntilTime option
    }

// message
type MassQuoteAcknowledgement = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    BidForwardPoints2: BidForwardPoints2 option
    BidForwardPoints: BidForwardPoints option
    BidPx: BidPx option
    BidSize: BidSize option
    BidSpotRate: BidSpotRate option
    BidYield: BidYield option
    Currency: Currency option
    EncodedText: EncodedText option
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    LastFragment: LastFragment option
    MassQuoteAcknowledgement_NoQuoteEntries_NoQuoteEntriesGrp: MassQuoteAcknowledgement_NoQuoteEntries_NoQuoteEntriesGrp option // group
    MassQuoteAcknowledgement_NoQuoteSets_NoQuoteSetsGrp: MassQuoteAcknowledgement_NoQuoteSets_NoQuoteSetsGrp option // group
    MidPx: MidPx option
    MidYield: MidYield option
    NoLegsGrp: NoLegsGrp option // group
    OfferForwardPoints2: OfferForwardPoints2 option
    OfferForwardPoints: OfferForwardPoints option
    OfferPx: OfferPx option
    OfferSize: OfferSize option
    OfferSpotRate: OfferSpotRate option
    OfferYield: OfferYield option
    OrdType: OrdType option
    OrderQty2: OrderQty2 option
    Parties: Parties option // component
    QuoteEntryID: QuoteEntryID option
    QuoteEntryRejectReason: QuoteEntryRejectReason option
    QuoteID: QuoteID option
    QuoteRejectReason: QuoteRejectReason option
    QuoteReqID: QuoteReqID option
    QuoteResponseLevel: QuoteResponseLevel option
    QuoteSetID: QuoteSetID option
    QuoteStatus: QuoteStatus
    QuoteType: QuoteType option
    SettlDate2: SettlDate2 option
    SettlDate: SettlDate option
    Text: Text option
    TotNoQuoteEntries: TotNoQuoteEntries option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    UnderlyingInstrument: UnderlyingInstrument option // component
    ValidUntilTime: ValidUntilTime option
    }

// message
type MarketDataRequest = {
    AggregatedBook: AggregatedBook option
    ApplQueueAction: ApplQueueAction option
    ApplQueueMax: ApplQueueMax option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    MDEntryType: MDEntryType
    MDImplicitDelete: MDImplicitDelete option
    MDReqID: MDReqID
    MDUpdateType: MDUpdateType option
    MarketDataRequest_NoRelatedSym_NoRelatedSymGrp: MarketDataRequest_NoRelatedSym_NoRelatedSymGrp // group
    MarketDepth: MarketDepth
    NoLegsGrp: NoLegsGrp option // group
    NoMDEntryTypesGrp: NoMDEntryTypesGrp // group
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OpenCloseSettlFlag: OpenCloseSettlFlag option
    Scope: Scope option
    SubscriptionRequestType: SubscriptionRequestType
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type MarketDataSnapshotFullRefresh = {
    ApplQueueDepth: ApplQueueDepth option
    ApplQueueResolution: ApplQueueResolution option
    CorporateAction: CorporateAction option
    Currency: Currency option
    DeskID: DeskID option
    EncodedText: EncodedText option
    ExecInst: ExecInst option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    FinancialStatus: FinancialStatus option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LocationID: LocationID option
    MDEntryBuyer: MDEntryBuyer option
    MDEntryDate: MDEntryDate option
    MDEntryOriginator: MDEntryOriginator option
    MDEntryPositionNo: MDEntryPositionNo option
    MDEntryPx: MDEntryPx option
    MDEntrySeller: MDEntrySeller option
    MDEntrySize: MDEntrySize option
    MDEntryTime: MDEntryTime option
    MDEntryType: MDEntryType
    MDMkt: MDMkt option
    MDReqID: MDReqID option
    MinQty: MinQty option
    NetChgPrevDay: NetChgPrevDay option
    NoLegsGrp: NoLegsGrp option // group
    NoMDEntriesGrp: NoMDEntriesGrp // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    NumberOfOrders: NumberOfOrders option
    OpenCloseSettlFlag: OpenCloseSettlFlag option
    OrderID: OrderID option
    PriceDelta: PriceDelta option
    QuoteCondition: QuoteCondition option
    QuoteEntryID: QuoteEntryID option
    Scope: Scope option
    SellerDays: SellerDays option
    Text: Text option
    TickDirection: TickDirection option
    TimeInForce: TimeInForce option
    TradeCondition: TradeCondition option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type MarketDataIncrementalRefresh = {
    ApplQueueDepth: ApplQueueDepth option
    ApplQueueResolution: ApplQueueResolution option
    CorporateAction: CorporateAction option
    Currency: Currency option
    DeleteReason: DeleteReason option
    DeskID: DeskID option
    EncodedText: EncodedText option
    ExecInst: ExecInst option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    FinancialStatus: FinancialStatus option
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    LocationID: LocationID option
    MDEntryBuyer: MDEntryBuyer option
    MDEntryDate: MDEntryDate option
    MDEntryID: MDEntryID option
    MDEntryOriginator: MDEntryOriginator option
    MDEntryPositionNo: MDEntryPositionNo option
    MDEntryPx: MDEntryPx option
    MDEntryRefID: MDEntryRefID option
    MDEntrySeller: MDEntrySeller option
    MDEntrySize: MDEntrySize option
    MDEntryTime: MDEntryTime option
    MDEntryType: MDEntryType option
    MDMkt: MDMkt option
    MDReqID: MDReqID option
    MDUpdateAction: MDUpdateAction
    MarketDataIncrementalRefresh_NoMDEntries_NoMDEntriesGrp: MarketDataIncrementalRefresh_NoMDEntries_NoMDEntriesGrp // group
    MinQty: MinQty option
    NetChgPrevDay: NetChgPrevDay option
    NoLegsGrp: NoLegsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    NumberOfOrders: NumberOfOrders option
    OpenCloseSettlFlag: OpenCloseSettlFlag option
    OrderID: OrderID option
    PriceDelta: PriceDelta option
    QuoteCondition: QuoteCondition option
    QuoteEntryID: QuoteEntryID option
    Scope: Scope option
    SellerDays: SellerDays option
    Text: Text option
    TickDirection: TickDirection option
    TimeInForce: TimeInForce option
    TradeCondition: TradeCondition option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type MarketDataRequestReject = {
    AltMDSourceID: AltMDSourceID option
    EncodedText: EncodedText option
    MDReqID: MDReqID
    MDReqRejReason: MDReqRejReason option
    NoAltMDSourceGrp: NoAltMDSourceGrp option // group
    Text: Text option
    }

// message
type SecurityDefinitionRequest = {
    Currency: Currency option
    EncodedText: EncodedText option
    ExpirationCycle: ExpirationCycle option
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    InstrumentLeg: InstrumentLeg option // component
    NoLegsGrp: NoLegsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    SecurityReqID: SecurityReqID
    SecurityRequestType: SecurityRequestType
    SubscriptionRequestType: SubscriptionRequestType option
    Text: Text option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type SecurityDefinition = {
    Currency: Currency option
    EncodedText: EncodedText option
    ExpirationCycle: ExpirationCycle option
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    InstrumentLeg: InstrumentLeg option // component
    MinTradeVol: MinTradeVol option
    NoLegsGrp: NoLegsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    RoundLot: RoundLot option
    SecurityReqID: SecurityReqID
    SecurityResponseID: SecurityResponseID
    SecurityResponseType: SecurityResponseType
    Text: Text option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type SecurityTypeRequest = {
    EncodedText: EncodedText option
    Product: Product option
    SecurityReqID: SecurityReqID
    SecuritySubType: SecuritySubType option
    SecurityType: SecurityType option
    Text: Text option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    }

// message
type SecurityTypes = {
    CFICode: CFICode option
    EncodedText: EncodedText option
    LastFragment: LastFragment option
    NoSecurityTypesGrp: NoSecurityTypesGrp option // group
    Product: Product option
    SecurityReqID: SecurityReqID
    SecurityResponseID: SecurityResponseID
    SecurityResponseType: SecurityResponseType
    SecuritySubType: SecuritySubType option
    SecurityType: SecurityType option
    SubscriptionRequestType: SubscriptionRequestType option
    Text: Text option
    TotNoSecurityTypes: TotNoSecurityTypes option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    }

// message
type SecurityListRequest = {
    Currency: Currency option
    EncodedText: EncodedText option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    InstrumentLeg: InstrumentLeg option // component
    NoLegsGrp: NoLegsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    SecurityListRequestType: SecurityListRequestType
    SecurityReqID: SecurityReqID
    SubscriptionRequestType: SubscriptionRequestType option
    Text: Text option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type SecurityList = {
    Currency: Currency option
    EncodedText: EncodedText option
    ExpirationCycle: ExpirationCycle option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    InstrumentLeg: InstrumentLeg option // component
    LastFragment: LastFragment option
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegSwapType: LegSwapType option
    MinTradeVol: MinTradeVol option
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    RoundLot: RoundLot option
    SecurityList_NoLegs_NoLegsGrp: SecurityList_NoLegs_NoLegsGrp option // group
    SecurityList_NoRelatedSym_NoRelatedSymGrp: SecurityList_NoRelatedSym_NoRelatedSymGrp option // group
    SecurityReqID: SecurityReqID
    SecurityRequestResult: SecurityRequestResult
    SecurityResponseID: SecurityResponseID
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    Text: Text option
    TotNoRelatedSym: TotNoRelatedSym option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    YieldData: YieldData option // component
    }

// message
type DerivativeSecurityListRequest = {
    Currency: Currency option
    EncodedText: EncodedText option
    SecurityListRequestType: SecurityListRequestType
    SecurityReqID: SecurityReqID
    SecuritySubType: SecuritySubType option
    SubscriptionRequestType: SubscriptionRequestType option
    Text: Text option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type DerivativeSecurityList = {
    Currency: Currency option
    DerivativeSecurityList_NoRelatedSym_NoRelatedSymGrp: DerivativeSecurityList_NoRelatedSym_NoRelatedSymGrp option // group
    EncodedText: EncodedText option
    ExpirationCycle: ExpirationCycle option
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    InstrumentLeg: InstrumentLeg option // component
    LastFragment: LastFragment option
    NoLegsGrp: NoLegsGrp option // group
    SecurityReqID: SecurityReqID
    SecurityRequestResult: SecurityRequestResult
    SecurityResponseID: SecurityResponseID
    Text: Text option
    TotNoRelatedSym: TotNoRelatedSym option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type SecurityStatusRequest = {
    Currency: Currency option
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    InstrumentLeg: InstrumentLeg option // component
    NoLegsGrp: NoLegsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    SecurityStatusReqID: SecurityStatusReqID
    SubscriptionRequestType: SubscriptionRequestType
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type SecurityStatus = {
    Adjustment: Adjustment option
    BuyVolume: BuyVolume option
    CorporateAction: CorporateAction option
    Currency: Currency option
    DueToRelated: DueToRelated option
    EncodedText: EncodedText option
    FinancialStatus: FinancialStatus option
    HaltReason: HaltReason option
    HighPx: HighPx option
    InViewOfCommon: InViewOfCommon option
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    InstrumentLeg: InstrumentLeg option // component
    LastPx: LastPx option
    LowPx: LowPx option
    NoLegsGrp: NoLegsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    SecurityStatusReqID: SecurityStatusReqID option
    SecurityTradingStatus: SecurityTradingStatus option
    SellVolume: SellVolume option
    Text: Text option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    UnderlyingInstrument: UnderlyingInstrument option // component
    UnsolicitedIndicator: UnsolicitedIndicator option
    }

// message
type TradingSessionStatusRequest = {
    SubscriptionRequestType: SubscriptionRequestType
    TradSesMethod: TradSesMethod option
    TradSesMode: TradSesMode option
    TradSesReqID: TradSesReqID
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    }

// message
type TradingSessionStatus = {
    EncodedText: EncodedText option
    Text: Text option
    TotalVolumeTraded: TotalVolumeTraded option
    TradSesCloseTime: TradSesCloseTime option
    TradSesEndTime: TradSesEndTime option
    TradSesMethod: TradSesMethod option
    TradSesMode: TradSesMode option
    TradSesOpenTime: TradSesOpenTime option
    TradSesPreCloseTime: TradSesPreCloseTime option
    TradSesReqID: TradSesReqID option
    TradSesStartTime: TradSesStartTime option
    TradSesStatus: TradSesStatus
    TradSesStatusRejReason: TradSesStatusRejReason option
    TradingSessionID: TradingSessionID
    TradingSessionSubID: TradingSessionSubID option
    UnsolicitedIndicator: UnsolicitedIndicator option
    }

// message
type NewOrderSingle = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocID: AllocID option
    AllocQty: AllocQty option
    AllocSettlCurrency: AllocSettlCurrency option
    BookingType: BookingType option
    BookingUnit: BookingUnit option
    CancellationRights: CancellationRights option
    CashMargin: CashMargin option
    ClOrdID: ClOrdID
    ClOrdLinkID: ClOrdLinkID option
    ClearingFeeIndicator: ClearingFeeIndicator option
    CommissionData: CommissionData option // component
    ComplianceID: ComplianceID option
    CoveredOrUncovered: CoveredOrUncovered option
    Currency: Currency option
    CustOrderCapacity: CustOrderCapacity option
    DayBookingInst: DayBookingInst option
    Designation: Designation option
    DiscretionInstructions: DiscretionInstructions option // component
    EffectiveTime: EffectiveTime option
    EncodedText: EncodedText option
    ExDestination: ExDestination option
    ExecInst: ExecInst option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    FinancingDetails: FinancingDetails option // component
    ForexReq: ForexReq option
    GTBookingInst: GTBookingInst option
    HandlInst: HandlInst option
    IOIid: IOIid option
    IndividualAllocID: IndividualAllocID option
    Instrument: Instrument // component
    LocateReqd: LocateReqd option
    MaxFloor: MaxFloor option
    MaxShow: MaxShow option
    MinQty: MinQty option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    NestedParties: NestedParties option // component
    NoAllocsGrp: NoAllocsGrp option // group
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrdType: OrdType
    OrderCapacity: OrderCapacity option
    OrderQty2: OrderQty2 option
    OrderQtyData: OrderQtyData // component
    OrderRestrictions: OrderRestrictions option
    ParticipationRate: ParticipationRate option
    Parties: Parties option // component
    PegInstructions: PegInstructions option // component
    PositionEffect: PositionEffect option
    PreallocMethod: PreallocMethod option
    PrevClosePx: PrevClosePx option
    Price2: Price2 option
    Price: Price option
    PriceType: PriceType option
    ProcessCode: ProcessCode option
    QtyType: QtyType option
    QuoteID: QuoteID option
    RegistID: RegistID option
    SecondaryClOrdID: SecondaryClOrdID option
    SettlCurrency: SettlCurrency option
    SettlDate2: SettlDate2 option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side
    SolicitedFlag: SolicitedFlag option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    StopPx: StopPx option
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    Text: Text option
    TimeInForce: TimeInForce option
    TradeDate: TradeDate option
    TradeOriginationDate: TradeOriginationDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime
    UnderlyingInstrument: UnderlyingInstrument option // component
    YieldData: YieldData option // component
    }

// message
type ExecutionReport = {
    Account: Account option
    AccountType: AccountType option
    AccruedInterestAmt: AccruedInterestAmt option
    AccruedInterestRate: AccruedInterestRate option
    AcctIDSource: AcctIDSource option
    AvgPx: AvgPx
    BasisFeatureDate: BasisFeatureDate option
    BasisFeaturePrice: BasisFeaturePrice option
    BookingType: BookingType option
    BookingUnit: BookingUnit option
    CancellationRights: CancellationRights option
    CashMargin: CashMargin option
    ClOrdID: ClOrdID option
    ClOrdLinkID: ClOrdLinkID option
    ClearingFeeIndicator: ClearingFeeIndicator option
    CommissionData: CommissionData option // component
    ComplianceID: ComplianceID option
    Concession: Concession option
    ContAmtCurr: ContAmtCurr option
    ContAmtType: ContAmtType option
    ContAmtValue: ContAmtValue option
    ContraBroker: ContraBroker option
    ContraLegRefID: ContraLegRefID option
    ContraTradeQty: ContraTradeQty option
    ContraTradeTime: ContraTradeTime option
    ContraTrader: ContraTrader option
    CopyMsgIndicator: CopyMsgIndicator option
    CrossID: CrossID option
    CrossType: CrossType option
    CumQty: CumQty
    Currency: Currency option
    CustOrderCapacity: CustOrderCapacity option
    DayAvgPx: DayAvgPx option
    DayBookingInst: DayBookingInst option
    DayCumQty: DayCumQty option
    DayOrderQty: DayOrderQty option
    Designation: Designation option
    DiscretionInstructions: DiscretionInstructions option // component
    DiscretionPrice: DiscretionPrice option
    EffectiveTime: EffectiveTime option
    EncodedText: EncodedText option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    EndCash: EndCash option
    ExDate: ExDate option
    ExecID: ExecID
    ExecInst: ExecInst option
    ExecPriceAdjustment: ExecPriceAdjustment option
    ExecPriceType: ExecPriceType option
    ExecRefID: ExecRefID option
    ExecRestatementReason: ExecRestatementReason option
    ExecType: ExecType
    ExecValuationPoint: ExecValuationPoint option
    ExecutionReport_NoLegs_NoLegsGrp: ExecutionReport_NoLegs_NoLegsGrp option // group
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    FinancingDetails: FinancingDetails option // component
    GTBookingInst: GTBookingInst option
    GrossTradeAmt: GrossTradeAmt option
    HandlInst: HandlInst option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    InterestAtMaturity: InterestAtMaturity option
    LastCapacity: LastCapacity option
    LastForwardPoints2: LastForwardPoints2 option
    LastForwardPoints: LastForwardPoints option
    LastLiquidityInd: LastLiquidityInd option
    LastMkt: LastMkt option
    LastParPx: LastParPx option
    LastPx: LastPx option
    LastQty: LastQty option
    LastRptRequested: LastRptRequested option
    LastSpotRate: LastSpotRate option
    LeavesQty: LeavesQty
    LegCoveredOrUncovered: LegCoveredOrUncovered option
    LegLastPx: LegLastPx option
    LegPositionEffect: LegPositionEffect option
    LegPrice: LegPrice option
    LegQty: LegQty option
    LegRefID: LegRefID option
    LegSettlDate: LegSettlDate option
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegSwapType: LegSwapType option
    ListID: ListID option
    MassStatusReqID: MassStatusReqID option
    MaxFloor: MaxFloor option
    MaxShow: MaxShow option
    MinQty: MinQty option
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeBasis: MiscFeeBasis option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    MultiLegReportingType: MultiLegReportingType option
    NestedParties: NestedParties option // component
    NetMoney: NetMoney option
    NoContAmtsGrp: NoContAmtsGrp option // group
    NoContraBrokersGrp: NoContraBrokersGrp option // group
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    NumDaysInterest: NumDaysInterest option
    OrdRejReason: OrdRejReason option
    OrdStatus: OrdStatus
    OrdStatusReqID: OrdStatusReqID option
    OrdType: OrdType option
    OrderCapacity: OrderCapacity option
    OrderID: OrderID
    OrderQty2: OrderQty2 option
    OrderQtyData: OrderQtyData option // component
    OrderRestrictions: OrderRestrictions option
    OrigClOrdID: OrigClOrdID option
    OrigCrossID: OrigCrossID option
    ParticipationRate: ParticipationRate option
    Parties: Parties option // component
    PegInstructions: PegInstructions option // component
    PeggedPrice: PeggedPrice option
    PositionEffect: PositionEffect option
    PreallocMethod: PreallocMethod option
    Price: Price option
    PriceImprovement: PriceImprovement option
    PriceType: PriceType option
    PriorityIndicator: PriorityIndicator option
    QtyType: QtyType option
    QuoteRespID: QuoteRespID option
    RegistID: RegistID option
    ReportToExch: ReportToExch option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryExecID: SecondaryExecID option
    SecondaryOrderID: SecondaryOrderID option
    SettlCurrAmt: SettlCurrAmt option
    SettlCurrFxRate: SettlCurrFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    SettlCurrency: SettlCurrency option
    SettlDate2: SettlDate2 option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side
    SolicitedFlag: SolicitedFlag option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    StartCash: StartCash option
    Stipulations: Stipulations option // component
    StopPx: StopPx option
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    TargetStrategyPerformance: TargetStrategyPerformance option
    Text: Text option
    TimeBracket: TimeBracket option
    TimeInForce: TimeInForce option
    TotNumReports: TotNumReports option
    TotalTakedown: TotalTakedown option
    TradeDate: TradeDate option
    TradeOriginationDate: TradeOriginationDate option
    TradedFlatSwitch: TradedFlatSwitch option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransBkdTime: TransBkdTime option
    TransactTime: TransactTime option
    UnderlyingInstrument: UnderlyingInstrument option // component
    UnderlyingLastPx: UnderlyingLastPx option
    UnderlyingLastQty: UnderlyingLastQty option
    WorkingIndicator: WorkingIndicator option
    YieldData: YieldData option // component
    }

// message
type DontKnowTrade = {
    DKReason: DKReason
    EncodedText: EncodedText option
    ExecID: ExecID
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LastPx: LastPx option
    LastQty: LastQty option
    NoLegsGrp: NoLegsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrderID: OrderID
    OrderQtyData: OrderQtyData // component
    SecondaryOrderID: SecondaryOrderID option
    Side: Side
    Text: Text option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type OrderCancelReplaceRequest = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocID: AllocID option
    AllocQty: AllocQty option
    AllocSettlCurrency: AllocSettlCurrency option
    BookingType: BookingType option
    BookingUnit: BookingUnit option
    CancellationRights: CancellationRights option
    CashMargin: CashMargin option
    ClOrdID: ClOrdID
    ClOrdLinkID: ClOrdLinkID option
    ClearingFeeIndicator: ClearingFeeIndicator option
    CommissionData: CommissionData option // component
    ComplianceID: ComplianceID option
    CoveredOrUncovered: CoveredOrUncovered option
    Currency: Currency option
    CustOrderCapacity: CustOrderCapacity option
    DayBookingInst: DayBookingInst option
    Designation: Designation option
    DiscretionInstructions: DiscretionInstructions option // component
    EffectiveTime: EffectiveTime option
    EncodedText: EncodedText option
    ExDestination: ExDestination option
    ExecInst: ExecInst option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    FinancingDetails: FinancingDetails option // component
    ForexReq: ForexReq option
    GTBookingInst: GTBookingInst option
    HandlInst: HandlInst option
    IndividualAllocID: IndividualAllocID option
    Instrument: Instrument // component
    ListID: ListID option
    LocateReqd: LocateReqd option
    MaxFloor: MaxFloor option
    MaxShow: MaxShow option
    MinQty: MinQty option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    NestedParties: NestedParties option // component
    NoAllocsGrp: NoAllocsGrp option // group
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrdType: OrdType
    OrderCapacity: OrderCapacity option
    OrderID: OrderID option
    OrderQty2: OrderQty2 option
    OrderQtyData: OrderQtyData // component
    OrderRestrictions: OrderRestrictions option
    OrigClOrdID: OrigClOrdID
    OrigOrdModTime: OrigOrdModTime option
    ParticipationRate: ParticipationRate option
    Parties: Parties option // component
    PegInstructions: PegInstructions option // component
    PositionEffect: PositionEffect option
    PreallocMethod: PreallocMethod option
    Price2: Price2 option
    Price: Price option
    PriceType: PriceType option
    QtyType: QtyType option
    RegistID: RegistID option
    SecondaryClOrdID: SecondaryClOrdID option
    SettlCurrency: SettlCurrency option
    SettlDate2: SettlDate2 option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side
    SolicitedFlag: SolicitedFlag option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    StopPx: StopPx option
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    Text: Text option
    TimeInForce: TimeInForce option
    TradeDate: TradeDate option
    TradeOriginationDate: TradeOriginationDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime
    UnderlyingInstrument: UnderlyingInstrument option // component
    YieldData: YieldData option // component
    }

// message
type OrderCancelRequest = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    ClOrdID: ClOrdID
    ClOrdLinkID: ClOrdLinkID option
    ComplianceID: ComplianceID option
    EncodedText: EncodedText option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument // component
    ListID: ListID option
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrderID: OrderID option
    OrderQtyData: OrderQtyData // component
    OrigClOrdID: OrigClOrdID
    OrigOrdModTime: OrigOrdModTime option
    Parties: Parties option // component
    SecondaryClOrdID: SecondaryClOrdID option
    Side: Side
    Text: Text option
    TransactTime: TransactTime
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type OrderCancelReject = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    ClOrdID: ClOrdID
    ClOrdLinkID: ClOrdLinkID option
    CxlRejReason: CxlRejReason option
    CxlRejResponseTo: CxlRejResponseTo
    EncodedText: EncodedText option
    ListID: ListID option
    OrdStatus: OrdStatus
    OrderID: OrderID
    OrigClOrdID: OrigClOrdID
    OrigOrdModTime: OrigOrdModTime option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryOrderID: SecondaryOrderID option
    Text: Text option
    TradeDate: TradeDate option
    TradeOriginationDate: TradeOriginationDate option
    TransactTime: TransactTime option
    WorkingIndicator: WorkingIndicator option
    }

// message
type OrderStatusRequest = {
    Account: Account option
    AcctIDSource: AcctIDSource option
    ClOrdID: ClOrdID
    ClOrdLinkID: ClOrdLinkID option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrdStatusReqID: OrdStatusReqID option
    OrderID: OrderID option
    Parties: Parties option // component
    SecondaryClOrdID: SecondaryClOrdID option
    Side: Side
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type OrderMassCancelRequest = {
    ClOrdID: ClOrdID
    EncodedText: EncodedText option
    Instrument: Instrument option // component
    MassCancelRequestType: MassCancelRequestType
    SecondaryClOrdID: SecondaryClOrdID option
    Side: Side option
    Text: Text option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type OrderMassCancelReport = {
    AffectedOrderID: AffectedOrderID option
    AffectedSecondaryOrderID: AffectedSecondaryOrderID option
    ClOrdID: ClOrdID option
    EncodedText: EncodedText option
    Instrument: Instrument option // component
    MassCancelRejectReason: MassCancelRejectReason option
    MassCancelRequestType: MassCancelRequestType
    MassCancelResponse: MassCancelResponse
    NoAffectedOrdersGrp: NoAffectedOrdersGrp option // group
    OrderID: OrderID
    OrigClOrdID: OrigClOrdID option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryOrderID: SecondaryOrderID option
    Side: Side option
    Text: Text option
    TotalAffectedOrders: TotalAffectedOrders option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type OrderMassStatusRequest = {
    Account: Account option
    AcctIDSource: AcctIDSource option
    Instrument: Instrument option // component
    MassStatusReqID: MassStatusReqID
    MassStatusReqType: MassStatusReqType
    Parties: Parties option // component
    Side: Side option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type NewOrderCross = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocID: AllocID option
    AllocQty: AllocQty option
    AllocSettlCurrency: AllocSettlCurrency option
    BookingType: BookingType option
    BookingUnit: BookingUnit option
    CancellationRights: CancellationRights option
    CashMargin: CashMargin option
    ClOrdID: ClOrdID
    ClOrdLinkID: ClOrdLinkID option
    ClearingFeeIndicator: ClearingFeeIndicator option
    CommissionData: CommissionData option // component
    ComplianceID: ComplianceID option
    CoveredOrUncovered: CoveredOrUncovered option
    CrossID: CrossID
    CrossPrioritization: CrossPrioritization
    CrossType: CrossType
    Currency: Currency option
    CustOrderCapacity: CustOrderCapacity option
    DayBookingInst: DayBookingInst option
    Designation: Designation option
    DiscretionInstructions: DiscretionInstructions option // component
    EffectiveTime: EffectiveTime option
    EncodedText: EncodedText option
    ExDestination: ExDestination option
    ExecInst: ExecInst option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    ForexReq: ForexReq option
    GTBookingInst: GTBookingInst option
    HandlInst: HandlInst option
    IOIid: IOIid option
    IndividualAllocID: IndividualAllocID option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LocateReqd: LocateReqd option
    MaxFloor: MaxFloor option
    MaxShow: MaxShow option
    MinQty: MinQty option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    NestedParties: NestedParties option // component
    NoAllocsGrp: NoAllocsGrp option // group
    NoLegsGrp: NoLegsGrp option // group
    NoSidesGrp: NoSidesGrp // group
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrdType: OrdType
    OrderCapacity: OrderCapacity option
    OrderQtyData: OrderQtyData // component
    OrderRestrictions: OrderRestrictions option
    ParticipationRate: ParticipationRate option
    Parties: Parties option // component
    PegInstructions: PegInstructions option // component
    PositionEffect: PositionEffect option
    PreallocMethod: PreallocMethod option
    PrevClosePx: PrevClosePx option
    Price: Price option
    PriceType: PriceType option
    ProcessCode: ProcessCode option
    QtyType: QtyType option
    QuoteID: QuoteID option
    RegistID: RegistID option
    SecondaryClOrdID: SecondaryClOrdID option
    SettlCurrency: SettlCurrency option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side
    SideComplianceID: SideComplianceID option
    SolicitedFlag: SolicitedFlag option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    StopPx: StopPx option
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    Text: Text option
    TimeInForce: TimeInForce option
    TradeDate: TradeDate option
    TradeOriginationDate: TradeOriginationDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime
    UnderlyingInstrument: UnderlyingInstrument option // component
    YieldData: YieldData option // component
    }

// message
type CrossOrderCancelReplaceRequest = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocID: AllocID option
    AllocQty: AllocQty option
    AllocSettlCurrency: AllocSettlCurrency option
    BookingType: BookingType option
    BookingUnit: BookingUnit option
    CancellationRights: CancellationRights option
    CashMargin: CashMargin option
    ClOrdID: ClOrdID
    ClOrdLinkID: ClOrdLinkID option
    ClearingFeeIndicator: ClearingFeeIndicator option
    CommissionData: CommissionData option // component
    ComplianceID: ComplianceID option
    CoveredOrUncovered: CoveredOrUncovered option
    CrossID: CrossID
    CrossOrderCancelReplaceRequest_NoSides_NoSidesGrp: CrossOrderCancelReplaceRequest_NoSides_NoSidesGrp // group
    CrossPrioritization: CrossPrioritization
    CrossType: CrossType
    Currency: Currency option
    CustOrderCapacity: CustOrderCapacity option
    DayBookingInst: DayBookingInst option
    Designation: Designation option
    DiscretionInstructions: DiscretionInstructions option // component
    EffectiveTime: EffectiveTime option
    EncodedText: EncodedText option
    ExDestination: ExDestination option
    ExecInst: ExecInst option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    ForexReq: ForexReq option
    GTBookingInst: GTBookingInst option
    HandlInst: HandlInst option
    IOIid: IOIid option
    IndividualAllocID: IndividualAllocID option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LocateReqd: LocateReqd option
    MaxFloor: MaxFloor option
    MaxShow: MaxShow option
    MinQty: MinQty option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    NestedParties: NestedParties option // component
    NoAllocsGrp: NoAllocsGrp option // group
    NoLegsGrp: NoLegsGrp option // group
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrdType: OrdType
    OrderCapacity: OrderCapacity option
    OrderID: OrderID option
    OrderQtyData: OrderQtyData // component
    OrderRestrictions: OrderRestrictions option
    OrigClOrdID: OrigClOrdID
    OrigCrossID: OrigCrossID
    OrigOrdModTime: OrigOrdModTime option
    ParticipationRate: ParticipationRate option
    Parties: Parties option // component
    PegInstructions: PegInstructions option // component
    PositionEffect: PositionEffect option
    PreallocMethod: PreallocMethod option
    PrevClosePx: PrevClosePx option
    Price: Price option
    PriceType: PriceType option
    ProcessCode: ProcessCode option
    QtyType: QtyType option
    QuoteID: QuoteID option
    RegistID: RegistID option
    SecondaryClOrdID: SecondaryClOrdID option
    SettlCurrency: SettlCurrency option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side
    SideComplianceID: SideComplianceID option
    SolicitedFlag: SolicitedFlag option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    StopPx: StopPx option
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    Text: Text option
    TimeInForce: TimeInForce option
    TradeDate: TradeDate option
    TradeOriginationDate: TradeOriginationDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime
    UnderlyingInstrument: UnderlyingInstrument option // component
    YieldData: YieldData option // component
    }

// message
type CrossOrderCancelRequest = {
    ClOrdID: ClOrdID
    ClOrdLinkID: ClOrdLinkID option
    ComplianceID: ComplianceID option
    CrossID: CrossID
    CrossOrderCancelRequest_NoSides_NoSidesGrp: CrossOrderCancelRequest_NoSides_NoSidesGrp // group
    CrossPrioritization: CrossPrioritization
    CrossType: CrossType
    EncodedText: EncodedText option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    NoLegsGrp: NoLegsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrderID: OrderID option
    OrderQtyData: OrderQtyData // component
    OrigClOrdID: OrigClOrdID
    OrigCrossID: OrigCrossID
    OrigOrdModTime: OrigOrdModTime option
    Parties: Parties option // component
    SecondaryClOrdID: SecondaryClOrdID option
    Side: Side
    Text: Text option
    TradeDate: TradeDate option
    TradeOriginationDate: TradeOriginationDate option
    TransactTime: TransactTime
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type NewOrderMultileg = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocID: AllocID option
    AllocQty: AllocQty option
    AllocSettlCurrency: AllocSettlCurrency option
    BookingType: BookingType option
    BookingUnit: BookingUnit option
    CancellationRights: CancellationRights option
    CashMargin: CashMargin option
    ClOrdID: ClOrdID
    ClOrdLinkID: ClOrdLinkID option
    ClearingFeeIndicator: ClearingFeeIndicator option
    CommissionData: CommissionData option // component
    ComplianceID: ComplianceID option
    CoveredOrUncovered: CoveredOrUncovered option
    Currency: Currency option
    CustOrderCapacity: CustOrderCapacity option
    DayBookingInst: DayBookingInst option
    Designation: Designation option
    DiscretionInstructions: DiscretionInstructions option // component
    EffectiveTime: EffectiveTime option
    EncodedText: EncodedText option
    ExDestination: ExDestination option
    ExecInst: ExecInst option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    ForexReq: ForexReq option
    GTBookingInst: GTBookingInst option
    HandlInst: HandlInst option
    IOIid: IOIid option
    IndividualAllocID: IndividualAllocID option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LegAllocAccount: LegAllocAccount option
    LegAllocAcctIDSource: LegAllocAcctIDSource option
    LegAllocQty: LegAllocQty option
    LegCoveredOrUncovered: LegCoveredOrUncovered option
    LegIndividualAllocID: LegIndividualAllocID option
    LegPositionEffect: LegPositionEffect option
    LegPrice: LegPrice option
    LegQty: LegQty option
    LegRefID: LegRefID option
    LegSettlCurrency: LegSettlCurrency option
    LegSettlDate: LegSettlDate option
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegSwapType: LegSwapType option
    LocateReqd: LocateReqd option
    MaxFloor: MaxFloor option
    MaxShow: MaxShow option
    MinQty: MinQty option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    MultiLegRptTypeReq: MultiLegRptTypeReq option
    NestedParties2: NestedParties2 option // component
    NestedParties3: NestedParties3 option // component
    NestedParties: NestedParties option // component
    NewOrderMultileg_NoAllocs_NoAllocsGrp: NewOrderMultileg_NoAllocs_NoAllocsGrp option // group
    NewOrderMultileg_NoLegs_NoLegsGrp: NewOrderMultileg_NoLegs_NoLegsGrp // group
    NoLegAllocsGrp: NoLegAllocsGrp option // group
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrdType: OrdType
    OrderCapacity: OrderCapacity option
    OrderQtyData: OrderQtyData // component
    OrderRestrictions: OrderRestrictions option
    ParticipationRate: ParticipationRate option
    Parties: Parties option // component
    PegInstructions: PegInstructions option // component
    PositionEffect: PositionEffect option
    PreallocMethod: PreallocMethod option
    PrevClosePx: PrevClosePx option
    Price: Price option
    PriceType: PriceType option
    ProcessCode: ProcessCode option
    QtyType: QtyType option
    QuoteID: QuoteID option
    RegistID: RegistID option
    SecondaryClOrdID: SecondaryClOrdID option
    SettlCurrency: SettlCurrency option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side
    SolicitedFlag: SolicitedFlag option
    StopPx: StopPx option
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    Text: Text option
    TimeInForce: TimeInForce option
    TradeDate: TradeDate option
    TradeOriginationDate: TradeOriginationDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type MultilegOrderCancelReplaceRequest = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocID: AllocID option
    AllocQty: AllocQty option
    AllocSettlCurrency: AllocSettlCurrency option
    BookingType: BookingType option
    BookingUnit: BookingUnit option
    CancellationRights: CancellationRights option
    CashMargin: CashMargin option
    ClOrdID: ClOrdID
    ClOrdLinkID: ClOrdLinkID option
    ClearingFeeIndicator: ClearingFeeIndicator option
    CommissionData: CommissionData option // component
    ComplianceID: ComplianceID option
    CoveredOrUncovered: CoveredOrUncovered option
    Currency: Currency option
    CustOrderCapacity: CustOrderCapacity option
    DayBookingInst: DayBookingInst option
    Designation: Designation option
    DiscretionInstructions: DiscretionInstructions option // component
    EffectiveTime: EffectiveTime option
    EncodedText: EncodedText option
    ExDestination: ExDestination option
    ExecInst: ExecInst option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    ForexReq: ForexReq option
    GTBookingInst: GTBookingInst option
    HandlInst: HandlInst option
    IOIid: IOIid option
    IndividualAllocID: IndividualAllocID option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LegAllocAccount: LegAllocAccount option
    LegAllocAcctIDSource: LegAllocAcctIDSource option
    LegAllocQty: LegAllocQty option
    LegCoveredOrUncovered: LegCoveredOrUncovered option
    LegIndividualAllocID: LegIndividualAllocID option
    LegPositionEffect: LegPositionEffect option
    LegPrice: LegPrice option
    LegQty: LegQty option
    LegRefID: LegRefID option
    LegSettlCurrency: LegSettlCurrency option
    LegSettlDate: LegSettlDate option
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegSwapType: LegSwapType option
    LocateReqd: LocateReqd option
    MaxFloor: MaxFloor option
    MaxShow: MaxShow option
    MinQty: MinQty option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    MultiLegRptTypeReq: MultiLegRptTypeReq option
    MultilegOrderCancelReplaceRequest_NoAllocs_NoAllocsGrp: MultilegOrderCancelReplaceRequest_NoAllocs_NoAllocsGrp option // group
    MultilegOrderCancelReplaceRequest_NoLegs_NoLegsGrp: MultilegOrderCancelReplaceRequest_NoLegs_NoLegsGrp // group
    NestedParties2: NestedParties2 option // component
    NestedParties3: NestedParties3 option // component
    NestedParties: NestedParties option // component
    NoLegAllocsGrp: NoLegAllocsGrp option // group
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrdType: OrdType
    OrderCapacity: OrderCapacity option
    OrderID: OrderID option
    OrderQtyData: OrderQtyData // component
    OrderRestrictions: OrderRestrictions option
    OrigClOrdID: OrigClOrdID
    OrigOrdModTime: OrigOrdModTime option
    ParticipationRate: ParticipationRate option
    Parties: Parties option // component
    PegInstructions: PegInstructions option // component
    PositionEffect: PositionEffect option
    PreallocMethod: PreallocMethod option
    PrevClosePx: PrevClosePx option
    Price: Price option
    PriceType: PriceType option
    ProcessCode: ProcessCode option
    QtyType: QtyType option
    QuoteID: QuoteID option
    RegistID: RegistID option
    SecondaryClOrdID: SecondaryClOrdID option
    SettlCurrency: SettlCurrency option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side
    SolicitedFlag: SolicitedFlag option
    StopPx: StopPx option
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    Text: Text option
    TimeInForce: TimeInForce option
    TradeDate: TradeDate option
    TradeOriginationDate: TradeOriginationDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type BidRequest = {
    Account: Account option
    AcctIDSource: AcctIDSource option
    BasisPxType: BasisPxType
    BidDescriptor: BidDescriptor option
    BidDescriptorType: BidDescriptorType option
    BidID: BidID option
    BidRequestTransType: BidRequestTransType
    BidTradeType: BidTradeType
    BidType: BidType
    ClientBidID: ClientBidID
    CrossPercent: CrossPercent option
    Currency: Currency option
    EFPTrackingError: EFPTrackingError option
    EncodedText: EncodedText option
    ExchangeForPhysical: ExchangeForPhysical option
    FairValue: FairValue option
    ForexReq: ForexReq option
    IncTaxInd: IncTaxInd option
    LiquidityIndType: LiquidityIndType option
    LiquidityNumSecurities: LiquidityNumSecurities option
    LiquidityPctHigh: LiquidityPctHigh option
    LiquidityPctLow: LiquidityPctLow option
    LiquidityValue: LiquidityValue option
    ListID: ListID option
    ListName: ListName option
    NetGrossInd: NetGrossInd option
    NoBidComponentsGrp: NoBidComponentsGrp option // group
    NoBidDescriptorsGrp: NoBidDescriptorsGrp option // group
    NumBidders: NumBidders option
    NumTickets: NumTickets option
    OutMainCntryUIndex: OutMainCntryUIndex option
    OutsideIndexPct: OutsideIndexPct option
    ProgPeriodInterval: ProgPeriodInterval option
    ProgRptReqs: ProgRptReqs option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side option
    SideValue1: SideValue1 option
    SideValue2: SideValue2 option
    SideValueInd: SideValueInd option
    StrikeTime: StrikeTime option
    Text: Text option
    TotNoRelatedSym: TotNoRelatedSym
    TradeDate: TradeDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    ValueOfFutures: ValueOfFutures option
    WtAverageLiquidity: WtAverageLiquidity option
    }

// message
type BidResponse = {
    BidID: BidID option
    BidResponse_NoBidComponents_NoBidComponentsGrp: BidResponse_NoBidComponents_NoBidComponentsGrp // group
    ClientBidID: ClientBidID option
    CommissionData: CommissionData // component
    Country: Country option
    EncodedText: EncodedText option
    FairValue: FairValue option
    ListID: ListID option
    NetGrossInd: NetGrossInd option
    Price: Price option
    PriceType: PriceType option
    SettlDate: SettlDate option
    SettlType: SettlType option
    Side: Side option
    Text: Text option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    }

// message
type NewOrderList = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocID: AllocID option
    AllocQty: AllocQty option
    AllocSettlCurrency: AllocSettlCurrency option
    AllowableOneSidednessCurr: AllowableOneSidednessCurr option
    AllowableOneSidednessPct: AllowableOneSidednessPct option
    AllowableOneSidednessValue: AllowableOneSidednessValue option
    BidID: BidID option
    BidType: BidType
    BookingType: BookingType option
    BookingUnit: BookingUnit option
    CancellationRights: CancellationRights option
    CashMargin: CashMargin option
    ClOrdID: ClOrdID
    ClOrdLinkID: ClOrdLinkID option
    ClearingFeeIndicator: ClearingFeeIndicator option
    ClientBidID: ClientBidID option
    CommissionData: CommissionData option // component
    ComplianceID: ComplianceID option
    CoveredOrUncovered: CoveredOrUncovered option
    Currency: Currency option
    CustOrderCapacity: CustOrderCapacity option
    DayBookingInst: DayBookingInst option
    Designation: Designation option
    DiscretionInstructions: DiscretionInstructions option // component
    EffectiveTime: EffectiveTime option
    EncodedListExecInst: EncodedListExecInst option
    EncodedText: EncodedText option
    ExDestination: ExDestination option
    ExecInst: ExecInst option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    ForexReq: ForexReq option
    GTBookingInst: GTBookingInst option
    HandlInst: HandlInst option
    IOIid: IOIid option
    IndividualAllocID: IndividualAllocID option
    Instrument: Instrument // component
    LastFragment: LastFragment option
    ListExecInst: ListExecInst option
    ListExecInstType: ListExecInstType option
    ListID: ListID
    ListSeqNo: ListSeqNo
    LocateReqd: LocateReqd option
    MaxFloor: MaxFloor option
    MaxShow: MaxShow option
    MinQty: MinQty option
    MoneyLaunderingStatus: MoneyLaunderingStatus option
    NestedParties: NestedParties option // component
    NewOrderList_NoOrders_NoOrdersGrp: NewOrderList_NoOrders_NoOrdersGrp // group
    NoAllocsGrp: NoAllocsGrp option // group
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrdType: OrdType option
    OrderCapacity: OrderCapacity option
    OrderQty2: OrderQty2 option
    OrderQtyData: OrderQtyData // component
    OrderRestrictions: OrderRestrictions option
    ParticipationRate: ParticipationRate option
    Parties: Parties option // component
    PegInstructions: PegInstructions option // component
    PositionEffect: PositionEffect option
    PreallocMethod: PreallocMethod option
    PrevClosePx: PrevClosePx option
    Price2: Price2 option
    Price: Price option
    PriceType: PriceType option
    ProcessCode: ProcessCode option
    ProgPeriodInterval: ProgPeriodInterval option
    ProgRptReqs: ProgRptReqs option
    QtyType: QtyType option
    QuoteID: QuoteID option
    RegistID: RegistID option
    SecondaryClOrdID: SecondaryClOrdID option
    SettlCurrency: SettlCurrency option
    SettlDate2: SettlDate2 option
    SettlDate: SettlDate option
    SettlInstMode: SettlInstMode option
    SettlType: SettlType option
    Side: Side
    SideValueInd: SideValueInd option
    SolicitedFlag: SolicitedFlag option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    Stipulations: Stipulations option // component
    StopPx: StopPx option
    TargetStrategy: TargetStrategy option
    TargetStrategyParameters: TargetStrategyParameters option
    Text: Text option
    TimeInForce: TimeInForce option
    TotNoOrders: TotNoOrders
    TradeDate: TradeDate option
    TradeOriginationDate: TradeOriginationDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    UnderlyingInstrument: UnderlyingInstrument option // component
    YieldData: YieldData option // component
    }

// message
type ListStrikePrice = {
    ClOrdID: ClOrdID option
    Currency: Currency option
    EncodedText: EncodedText option
    Instrument: Instrument // component
    LastFragment: LastFragment option
    ListID: ListID
    ListStrikePrice_NoUnderlyings_NoUnderlyingsGrp: ListStrikePrice_NoUnderlyings_NoUnderlyingsGrp option // group
    NoStrikesGrp: NoStrikesGrp // group
    PrevClosePx: PrevClosePx option
    Price: Price
    SecondaryClOrdID: SecondaryClOrdID option
    Side: Side option
    Text: Text option
    TotNoStrikes: TotNoStrikes
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type ListStatus = {
    AvgPx: AvgPx
    ClOrdID: ClOrdID
    CumQty: CumQty
    CxlQty: CxlQty
    EncodedListStatusText: EncodedListStatusText option
    EncodedText: EncodedText option
    LastFragment: LastFragment option
    LeavesQty: LeavesQty
    ListID: ListID
    ListOrderStatus: ListOrderStatus
    ListStatusText: ListStatusText option
    ListStatusType: ListStatusType
    ListStatus_NoOrders_NoOrdersGrp: ListStatus_NoOrders_NoOrdersGrp // group
    NoRpts: NoRpts
    OrdRejReason: OrdRejReason option
    OrdStatus: OrdStatus
    RptSeq: RptSeq
    SecondaryClOrdID: SecondaryClOrdID option
    Text: Text option
    TotNoOrders: TotNoOrders
    TransactTime: TransactTime option
    WorkingIndicator: WorkingIndicator option
    }

// message
type ListExecute = {
    BidID: BidID option
    ClientBidID: ClientBidID option
    EncodedText: EncodedText option
    ListID: ListID
    Text: Text option
    TransactTime: TransactTime
    }

// message
type ListCancelRequest = {
    EncodedText: EncodedText option
    ListID: ListID
    Text: Text option
    TradeDate: TradeDate option
    TradeOriginationDate: TradeOriginationDate option
    TransactTime: TransactTime
    }

// message
type ListStatusRequest = {
    EncodedText: EncodedText option
    ListID: ListID
    Text: Text option
    }

// message
type AllocationInstruction = {
    AccruedInterestAmt: AccruedInterestAmt option
    AccruedInterestAmt: AccruedInterestAmt option
    AccruedInterestRate: AccruedInterestRate option
    AllocAccount: AllocAccount
    AllocAccruedInterestAmt: AllocAccruedInterestAmt option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocAvgPx: AllocAvgPx option
    AllocCancReplaceReason: AllocCancReplaceReason option
    AllocHandlInst: AllocHandlInst option
    AllocID: AllocID
    AllocInterestAtMaturity: AllocInterestAtMaturity option
    AllocIntermedReqType: AllocIntermedReqType option
    AllocLinkID: AllocLinkID option
    AllocLinkType: AllocLinkType option
    AllocNetMoney: AllocNetMoney option
    AllocNoOrdersType: AllocNoOrdersType
    AllocPrice: AllocPrice option
    AllocQty: AllocQty option
    AllocSettlCurrAmt: AllocSettlCurrAmt option
    AllocSettlCurrency: AllocSettlCurrency option
    AllocSettlInstType: AllocSettlInstType option
    AllocText: AllocText option
    AllocTransType: AllocTransType
    AllocType: AllocType
    AllocationInstruction_NoAllocs_NoAllocsGrp: AllocationInstruction_NoAllocs_NoAllocsGrp option // group
    AllocationInstruction_NoExecs_NoExecsGrp: AllocationInstruction_NoExecs_NoExecsGrp option // group
    AutoAcceptIndicator: AutoAcceptIndicator option
    AvgParPx: AvgParPx option
    AvgPx: AvgPx
    AvgPxPrecision: AvgPxPrecision option
    BookingRefID: BookingRefID option
    BookingType: BookingType option
    ClOrdID: ClOrdID option
    ClearingFeeIndicator: ClearingFeeIndicator option
    ClearingInstruction: ClearingInstruction option
    CommissionData: CommissionData option // component
    Concession: Concession option
    Currency: Currency option
    EncodedAllocText: EncodedAllocText option
    EncodedText: EncodedText option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    EndCash: EndCash option
    ExecID: ExecID option
    FinancingDetails: FinancingDetails option // component
    GrossTradeAmt: GrossTradeAmt option
    IndividualAllocID: IndividualAllocID option
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    InstrumentLeg: InstrumentLeg option // component
    InterestAtMaturity: InterestAtMaturity option
    LastCapacity: LastCapacity option
    LastFragment: LastFragment option
    LastMkt: LastMkt option
    LastParPx: LastParPx option
    LastPx: LastPx option
    LastQty: LastQty option
    LegalConfirm: LegalConfirm option
    ListID: ListID option
    MatchStatus: MatchStatus option
    MatchType: MatchType option
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeBasis: MiscFeeBasis option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    NestedParties2: NestedParties2 option // component
    NestedParties: NestedParties option // component
    NetMoney: NetMoney option
    NoClearingInstructions: NoClearingInstructions option
    NoLegsGrp: NoLegsGrp option // group
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    NoOrdersGrp: NoOrdersGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    NotifyBrokerOfCredit: NotifyBrokerOfCredit option
    NumDaysInterest: NumDaysInterest option
    OrderAvgPx: OrderAvgPx option
    OrderBookingQty: OrderBookingQty option
    OrderID: OrderID option
    OrderQty: OrderQty option
    Parties: Parties option // component
    PositionEffect: PositionEffect option
    PreviouslyReported: PreviouslyReported option
    PriceType: PriceType option
    ProcessCode: ProcessCode option
    QtyType: QtyType option
    Quantity: Quantity
    RefAllocID: RefAllocID option
    ReversalIndicator: ReversalIndicator option
    SecondaryAllocID: SecondaryAllocID option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryExecID: SecondaryExecID option
    SecondaryOrderID: SecondaryOrderID option
    SettlCurrAmt: SettlCurrAmt option
    SettlCurrFxRate: SettlCurrFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    SettlCurrency: SettlCurrency option
    SettlDate: SettlDate option
    SettlInstMode: SettlInstMode option
    SettlInstructionsData: SettlInstructionsData option // component
    SettlType: SettlType option
    Side: Side
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    StartCash: StartCash option
    Stipulations: Stipulations option // component
    Text: Text option
    TotNoAllocs: TotNoAllocs option
    TotalAccruedInterestAmt: TotalAccruedInterestAmt option
    TotalTakedown: TotalTakedown option
    TradeDate: TradeDate
    TradeOriginationDate: TradeOriginationDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    UnderlyingInstrument: UnderlyingInstrument option // component
    YieldData: YieldData option // component
    }

// message
type AllocationInstructionAck = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocID: AllocID
    AllocIntermedReqType: AllocIntermedReqType option
    AllocPrice: AllocPrice option
    AllocRejCode: AllocRejCode option
    AllocStatus: AllocStatus
    AllocText: AllocText option
    AllocType: AllocType option
    AllocationInstructionAck_NoAllocs_NoAllocsGrp: AllocationInstructionAck_NoAllocs_NoAllocsGrp option // group
    EncodedAllocText: EncodedAllocText option
    EncodedText: EncodedText option
    IndividualAllocID: IndividualAllocID option
    IndividualAllocRejCode: IndividualAllocRejCode option
    MatchStatus: MatchStatus option
    Parties: Parties option // component
    Product: Product option
    SecondaryAllocID: SecondaryAllocID option
    SecurityType: SecurityType option
    Text: Text option
    TradeDate: TradeDate option
    TransactTime: TransactTime
    }

// message
type AllocationReport = {
    AccruedInterestAmt: AccruedInterestAmt option
    AccruedInterestRate: AccruedInterestRate option
    AllocAccount: AllocAccount
    AllocAccruedInterestAmt: AllocAccruedInterestAmt option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocAvgPx: AllocAvgPx option
    AllocCancReplaceReason: AllocCancReplaceReason option
    AllocHandlInst: AllocHandlInst option
    AllocID: AllocID option
    AllocInterestAtMaturity: AllocInterestAtMaturity option
    AllocIntermedReqType: AllocIntermedReqType option
    AllocLinkID: AllocLinkID option
    AllocLinkType: AllocLinkType option
    AllocNetMoney: AllocNetMoney option
    AllocNoOrdersType: AllocNoOrdersType
    AllocPrice: AllocPrice option
    AllocQty: AllocQty
    AllocRejCode: AllocRejCode option
    AllocReportID: AllocReportID
    AllocReportRefID: AllocReportRefID option
    AllocReportType: AllocReportType
    AllocSettlCurrAmt: AllocSettlCurrAmt option
    AllocSettlCurrency: AllocSettlCurrency option
    AllocSettlInstType: AllocSettlInstType option
    AllocStatus: AllocStatus
    AllocText: AllocText option
    AllocTransType: AllocTransType
    AllocationReport_NoAllocs_NoAllocsGrp: AllocationReport_NoAllocs_NoAllocsGrp // group
    AllocationReport_NoExecs_NoExecsGrp: AllocationReport_NoExecs_NoExecsGrp option // group
    AutoAcceptIndicator: AutoAcceptIndicator option
    AvgParPx: AvgParPx option
    AvgPx: AvgPx
    AvgPxPrecision: AvgPxPrecision option
    BookingRefID: BookingRefID option
    BookingType: BookingType option
    ClOrdID: ClOrdID option
    ClearingFeeIndicator: ClearingFeeIndicator option
    ClearingInstruction: ClearingInstruction option
    CommissionData: CommissionData option // component
    Concession: Concession option
    Currency: Currency option
    EncodedAllocText: EncodedAllocText option
    EncodedText: EncodedText option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    EndCash: EndCash option
    ExecID: ExecID option
    FinancingDetails: FinancingDetails option // component
    GrossTradeAmt: GrossTradeAmt option
    IndividualAllocID: IndividualAllocID option
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    InstrumentLeg: InstrumentLeg option // component
    InterestAtMaturity: InterestAtMaturity option
    LastCapacity: LastCapacity option
    LastFragment: LastFragment option
    LastMkt: LastMkt option
    LastParPx: LastParPx option
    LastPx: LastPx option
    LastQty: LastQty option
    LegalConfirm: LegalConfirm option
    ListID: ListID option
    MatchStatus: MatchStatus option
    MatchType: MatchType option
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeBasis: MiscFeeBasis option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    NestedParties2: NestedParties2 option // component
    NestedParties: NestedParties option // component
    NetMoney: NetMoney option
    NoClearingInstructionsGrp: NoClearingInstructionsGrp option // group
    NoLegsGrp: NoLegsGrp option // group
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    NoOrdersGrp: NoOrdersGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    NotifyBrokerOfCredit: NotifyBrokerOfCredit option
    NumDaysInterest: NumDaysInterest option
    OrderAvgPx: OrderAvgPx option
    OrderBookingQty: OrderBookingQty option
    OrderID: OrderID option
    OrderQty: OrderQty option
    Parties: Parties option // component
    PositionEffect: PositionEffect option
    PreviouslyReported: PreviouslyReported option
    PriceType: PriceType option
    ProcessCode: ProcessCode option
    QtyType: QtyType option
    Quantity: Quantity
    RefAllocID: RefAllocID option
    ReversalIndicator: ReversalIndicator option
    SecondaryAllocID: SecondaryAllocID option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryExecID: SecondaryExecID option
    SecondaryOrderID: SecondaryOrderID option
    SettlCurrAmt: SettlCurrAmt option
    SettlCurrFxRate: SettlCurrFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    SettlCurrency: SettlCurrency option
    SettlDate: SettlDate option
    SettlInstructionsData: SettlInstructionsData option // component
    SettlType: SettlType option
    Side: Side
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    StartCash: StartCash option
    Stipulations: Stipulations option // component
    Text: Text option
    TotNoAllocs: TotNoAllocs option
    TotalAccruedInterestAmt: TotalAccruedInterestAmt option
    TotalTakedown: TotalTakedown option
    TradeDate: TradeDate
    TradeOriginationDate: TradeOriginationDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    UnderlyingInstrument: UnderlyingInstrument option // component
    YieldData: YieldData option // component
    }

// message
type AllocationReportAck = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocID: AllocID
    AllocIntermedReqType: AllocIntermedReqType option
    AllocPrice: AllocPrice option
    AllocRejCode: AllocRejCode option
    AllocReportID: AllocReportID
    AllocReportType: AllocReportType option
    AllocStatus: AllocStatus
    AllocText: AllocText option
    AllocationReportAck_NoAllocs_NoAllocsGrp: AllocationReportAck_NoAllocs_NoAllocsGrp option // group
    EncodedAllocText: EncodedAllocText option
    EncodedText: EncodedText option
    IndividualAllocID: IndividualAllocID option
    IndividualAllocRejCode: IndividualAllocRejCode option
    MatchStatus: MatchStatus option
    Parties: Parties option // component
    Product: Product option
    SecondaryAllocID: SecondaryAllocID option
    SecurityType: SecurityType option
    Text: Text option
    TradeDate: TradeDate option
    TransactTime: TransactTime
    }

// message
type Confirmation = {
    AccruedInterestAmt: AccruedInterestAmt option
    AccruedInterestRate: AccruedInterestRate option
    AllocAccount: AllocAccount
    AllocAccountType: AllocAccountType option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocID: AllocID option
    AllocQty: AllocQty
    AvgParPx: AvgParPx option
    AvgPx: AvgPx
    AvgPxPrecision: AvgPxPrecision option
    ClOrdID: ClOrdID option
    CommissionData: CommissionData option // component
    Concession: Concession option
    ConfirmID: ConfirmID
    ConfirmRefID: ConfirmRefID option
    ConfirmReqID: ConfirmReqID option
    ConfirmStatus: ConfirmStatus
    ConfirmTransType: ConfirmTransType
    ConfirmType: ConfirmType
    CopyMsgIndicator: CopyMsgIndicator option
    Currency: Currency option
    EncodedText: EncodedText option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    EndCash: EndCash option
    ExDate: ExDate option
    FinancingDetails: FinancingDetails option // component
    GrossTradeAmt: GrossTradeAmt
    IndividualAllocID: IndividualAllocID option
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    InstrumentLeg: InstrumentLeg option // component
    InterestAtMaturity: InterestAtMaturity option
    LastMkt: LastMkt option
    LegalConfirm: LegalConfirm option
    ListID: ListID option
    MaturityNetMoney: MaturityNetMoney option
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeBasis: MiscFeeBasis option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    NestedParties2: NestedParties2 option // component
    NetMoney: NetMoney
    NoCapacitiesGrp: NoCapacitiesGrp // group
    NoLegsGrp: NoLegsGrp // group
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    NoOrdersGrp: NoOrdersGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp // group
    NumDaysInterest: NumDaysInterest option
    OrderAvgPx: OrderAvgPx option
    OrderBookingQty: OrderBookingQty option
    OrderCapacity: OrderCapacity
    OrderCapacityQty: OrderCapacityQty
    OrderID: OrderID option
    OrderQty: OrderQty option
    OrderRestrictions: OrderRestrictions option
    Parties: Parties option // component
    PriceType: PriceType option
    ProcessCode: ProcessCode option
    QtyType: QtyType option
    ReportedPx: ReportedPx option
    SecondaryAllocID: SecondaryAllocID option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryOrderID: SecondaryOrderID option
    SettlCurrAmt: SettlCurrAmt option
    SettlCurrFxRate: SettlCurrFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    SettlCurrency: SettlCurrency option
    SettlDate: SettlDate option
    SettlInstructionsData: SettlInstructionsData option // component
    SettlType: SettlType option
    SharedCommission: SharedCommission option
    Side: Side
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    StartCash: StartCash option
    Stipulations: Stipulations option // component
    Text: Text option
    TotalTakedown: TotalTakedown option
    TradeDate: TradeDate
    TransactTime: TransactTime
    TrdRegTimestamps: TrdRegTimestamps option // component
    UnderlyingInstrument: UnderlyingInstrument option // component
    YieldData: YieldData option // component
    }

// message
type ConfirmationAck = {
    AffirmStatus: AffirmStatus
    ConfirmID: ConfirmID
    ConfirmRejReason: ConfirmRejReason option
    EncodedText: EncodedText option
    MatchStatus: MatchStatus option
    Text: Text option
    TradeDate: TradeDate
    TransactTime: TransactTime
    }

// message
type ConfirmationRequest = {
    AllocAccount: AllocAccount option
    AllocAccountType: AllocAccountType option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocID: AllocID option
    ClOrdID: ClOrdID option
    ConfirmReqID: ConfirmReqID
    ConfirmType: ConfirmType
    EncodedText: EncodedText option
    IndividualAllocID: IndividualAllocID option
    ListID: ListID option
    NestedParties2: NestedParties2 option // component
    NoOrdersGrp: NoOrdersGrp option // group
    OrderAvgPx: OrderAvgPx option
    OrderBookingQty: OrderBookingQty option
    OrderID: OrderID option
    OrderQty: OrderQty option
    SecondaryAllocID: SecondaryAllocID option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryOrderID: SecondaryOrderID option
    Text: Text option
    TransactTime: TransactTime
    }

// message
type SettlementInstructions = {
    CFICode: CFICode option
    CardExpDate: CardExpDate option
    CardHolderName: CardHolderName option
    CardIssNum: CardIssNum option
    CardNumber: CardNumber option
    CardStartDate: CardStartDate option
    ClOrdID: ClOrdID option
    EffectiveTime: EffectiveTime option
    EncodedText: EncodedText option
    ExpireTime: ExpireTime option
    LastUpdateTime: LastUpdateTime option
    NoSettlInstGrp: NoSettlInstGrp option // group
    Parties: Parties option // component
    PaymentDate: PaymentDate option
    PaymentMethod: PaymentMethod option
    PaymentRef: PaymentRef option
    PaymentRemitterID: PaymentRemitterID option
    Product: Product option
    SecurityType: SecurityType option
    SettlInstID: SettlInstID option
    SettlInstMode: SettlInstMode
    SettlInstMsgID: SettlInstMsgID
    SettlInstRefID: SettlInstRefID option
    SettlInstReqID: SettlInstReqID option
    SettlInstReqRejCode: SettlInstReqRejCode option
    SettlInstSource: SettlInstSource option
    SettlInstTransType: SettlInstTransType option
    SettlInstructionsData: SettlInstructionsData option // component
    Side: Side option
    Text: Text option
    TransactTime: TransactTime
    }

// message
type SettlementInstructionRequest = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    CFICode: CFICode option
    EffectiveTime: EffectiveTime option
    ExpireTime: ExpireTime option
    LastUpdateTime: LastUpdateTime option
    Parties: Parties option // component
    Product: Product option
    SecurityType: SecurityType option
    SettlInstReqID: SettlInstReqID
    Side: Side option
    StandInstDbID: StandInstDbID option
    StandInstDbName: StandInstDbName option
    StandInstDbType: StandInstDbType option
    TransactTime: TransactTime
    }

// message
type TradeCaptureReportRequest = {
    ClOrdID: ClOrdID option
    ClearingBusinessDate: ClearingBusinessDate option
    EncodedText: EncodedText option
    ExecID: ExecID option
    ExecType: ExecType option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    InstrumentLeg: InstrumentLeg option // component
    MatchStatus: MatchStatus option
    MultiLegReportingType: MultiLegReportingType option
    NoDatesGrp: NoDatesGrp option // group
    NoLegsGrp: NoLegsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrderID: OrderID option
    Parties: Parties option // component
    ResponseDestination: ResponseDestination option
    ResponseTransportType: ResponseTransportType option
    SecondaryTradeReportID: SecondaryTradeReportID option
    SecondaryTrdType: SecondaryTrdType option
    Side: Side option
    SubscriptionRequestType: SubscriptionRequestType option
    Text: Text option
    TimeBracket: TimeBracket option
    TradeDate: TradeDate option
    TradeInputDevice: TradeInputDevice option
    TradeInputSource: TradeInputSource option
    TradeLinkID: TradeLinkID option
    TradeReportID: TradeReportID option
    TradeRequestID: TradeRequestID
    TradeRequestType: TradeRequestType
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime option
    TransferReason: TransferReason option
    TrdMatchID: TrdMatchID option
    TrdSubType: TrdSubType option
    TrdType: TrdType option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type TradeCaptureReportRequestAck = {
    EncodedText: EncodedText option
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    MultiLegReportingType: MultiLegReportingType option
    NoLegsGrp: NoLegsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    ResponseDestination: ResponseDestination option
    ResponseTransportType: ResponseTransportType option
    SubscriptionRequestType: SubscriptionRequestType option
    Text: Text option
    TotNumTradeReports: TotNumTradeReports option
    TradeRequestID: TradeRequestID
    TradeRequestResult: TradeRequestResult
    TradeRequestStatus: TradeRequestStatus
    TradeRequestType: TradeRequestType
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type TradeCaptureReport = {
    Account: Account option
    AccountType: AccountType option
    AccruedInterestAmt: AccruedInterestAmt option
    AccruedInterestRate: AccruedInterestRate option
    AcctIDSource: AcctIDSource option
    AllocID: AllocID option
    AvgPx: AvgPx option
    AvgPxIndicator: AvgPxIndicator option
    ClOrdID: ClOrdID option
    ClearingBusinessDate: ClearingBusinessDate option
    ClearingFeeIndicator: ClearingFeeIndicator option
    ClearingInstruction: ClearingInstruction option
    CommissionData: CommissionData option // component
    ComplianceID: ComplianceID option
    Concession: Concession option
    ContAmtCurr: ContAmtCurr option
    ContAmtType: ContAmtType option
    ContAmtValue: ContAmtValue option
    CopyMsgIndicator: CopyMsgIndicator option
    Currency: Currency option
    CustOrderCapacity: CustOrderCapacity option
    EncodedText: EncodedText option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    EndCash: EndCash option
    ExDate: ExDate option
    ExchangeRule: ExchangeRule option
    ExecID: ExecID option
    ExecInst: ExecInst option
    ExecRestatementReason: ExecRestatementReason option
    ExecType: ExecType option
    FinancingDetails: FinancingDetails option // component
    GrossTradeAmt: GrossTradeAmt option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    InterestAtMaturity: InterestAtMaturity option
    LastForwardPoints: LastForwardPoints option
    LastMkt: LastMkt option
    LastParPx: LastParPx option
    LastPx: LastPx
    LastQty: LastQty
    LastRptRequested: LastRptRequested option
    LastSpotRate: LastSpotRate option
    LegCoveredOrUncovered: LegCoveredOrUncovered option
    LegLastPx: LegLastPx option
    LegPositionEffect: LegPositionEffect option
    LegPrice: LegPrice option
    LegQty: LegQty option
    LegRefID: LegRefID option
    LegSettlDate: LegSettlDate option
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegSwapType: LegSwapType option
    ListID: ListID option
    MatchStatus: MatchStatus option
    MatchType: MatchType option
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeBasis: MiscFeeBasis option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MultiLegReportingType: MultiLegReportingType option
    NestedParties: NestedParties option // component
    NetMoney: NetMoney option
    NoClearingInstructionsGrp: NoClearingInstructionsGrp option // group
    NoContAmtsGrp: NoContAmtsGrp option // group
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    NumDaysInterest: NumDaysInterest option
    OddLot: OddLot option
    OrdStatus: OrdStatus option
    OrdType: OrdType option
    OrderCapacity: OrderCapacity option
    OrderID: OrderID
    OrderInputDevice: OrderInputDevice option
    OrderQtyData: OrderQtyData option // component
    OrderRestrictions: OrderRestrictions option
    Parties: Parties option // component
    PositionAmountData: PositionAmountData option // component
    PositionEffect: PositionEffect option
    PreallocMethod: PreallocMethod option
    PreviouslyReported: PreviouslyReported
    PriceType: PriceType option
    ProcessCode: ProcessCode option
    PublishTrdIndicator: PublishTrdIndicator option
    QtyType: QtyType option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryExecID: SecondaryExecID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    SecondaryTradeReportRefID: SecondaryTradeReportRefID option
    SecondaryTrdType: SecondaryTrdType option
    SettlCurrAmt: SettlCurrAmt option
    SettlCurrFxRate: SettlCurrFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    SettlCurrency: SettlCurrency option
    SettlDate: SettlDate option
    SettlType: SettlType option
    ShortSaleReason: ShortSaleReason option
    Side: Side
    SideMultiLegReportingType: SideMultiLegReportingType option
    SolicitedFlag: SolicitedFlag option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    StartCash: StartCash option
    Stipulations: Stipulations option // component
    SubscriptionRequestType: SubscriptionRequestType option
    Text: Text option
    TimeBracket: TimeBracket option
    TotNumTradeReports: TotNumTradeReports option
    TotalTakedown: TotalTakedown option
    TradeAllocIndicator: TradeAllocIndicator option
    TradeCaptureReport_NoLegs_NoLegsGrp: TradeCaptureReport_NoLegs_NoLegsGrp option // group
    TradeCaptureReport_NoSides_NoSidesGrp: TradeCaptureReport_NoSides_NoSidesGrp // group
    TradeDate: TradeDate
    TradeInputDevice: TradeInputDevice option
    TradeInputSource: TradeInputSource option
    TradeLegRefID: TradeLegRefID option
    TradeLinkID: TradeLinkID option
    TradeReportID: TradeReportID
    TradeReportRefID: TradeReportRefID option
    TradeReportTransType: TradeReportTransType option
    TradeReportType: TradeReportType option
    TradeRequestID: TradeRequestID option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransBkdTime: TransBkdTime option
    TransactTime: TransactTime
    TransferReason: TransferReason option
    TrdMatchID: TrdMatchID option
    TrdRegTimestamps: TrdRegTimestamps option // component
    TrdSubType: TrdSubType option
    TrdType: TrdType option
    UnderlyingInstrument: UnderlyingInstrument option // component
    UnderlyingTradingSessionID: UnderlyingTradingSessionID option
    UnderlyingTradingSessionSubID: UnderlyingTradingSessionSubID option
    UnsolicitedIndicator: UnsolicitedIndicator option
    YieldData: YieldData option // component
    }

// message
type TradeCaptureReportAck = {
    Account: Account option
    AccountType: AccountType option
    AcctIDSource: AcctIDSource option
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocQty: AllocQty option
    AllocSettlCurrency: AllocSettlCurrency option
    ClearingFeeIndicator: ClearingFeeIndicator option
    CustOrderCapacity: CustOrderCapacity option
    EncodedText: EncodedText option
    ExecID: ExecID option
    ExecType: ExecType
    IndividualAllocID: IndividualAllocID option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    LegCoveredOrUncovered: LegCoveredOrUncovered option
    LegLastPx: LegLastPx option
    LegPositionEffect: LegPositionEffect option
    LegPrice: LegPrice option
    LegQty: LegQty option
    LegRefID: LegRefID option
    LegSettlDate: LegSettlDate option
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegSwapType: LegSwapType option
    NestedParties2: NestedParties2 option // component
    NestedParties: NestedParties option // component
    OrderCapacity: OrderCapacity option
    OrderRestrictions: OrderRestrictions option
    PositionEffect: PositionEffect option
    PreallocMethod: PreallocMethod option
    ResponseDestination: ResponseDestination option
    ResponseTransportType: ResponseTransportType option
    SecondaryExecID: SecondaryExecID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    SecondaryTradeReportRefID: SecondaryTradeReportRefID option
    SecondaryTrdType: SecondaryTrdType option
    SubscriptionRequestType: SubscriptionRequestType option
    Text: Text option
    TradeCaptureReportAck_NoAllocs_NoAllocsGrp: TradeCaptureReportAck_NoAllocs_NoAllocsGrp option // group
    TradeCaptureReportAck_NoLegs_NoLegsGrp: TradeCaptureReportAck_NoLegs_NoLegsGrp option // group
    TradeLinkID: TradeLinkID option
    TradeReportID: TradeReportID
    TradeReportRefID: TradeReportRefID option
    TradeReportRejectReason: TradeReportRejectReason option
    TradeReportTransType: TradeReportTransType option
    TradeReportType: TradeReportType option
    TransactTime: TransactTime option
    TransferReason: TransferReason option
    TrdMatchID: TrdMatchID option
    TrdRegTimestamps: TrdRegTimestamps option // component
    TrdRptStatus: TrdRptStatus option
    TrdSubType: TrdSubType option
    TrdType: TrdType option
    }

// message
type RegistrationInstructions = {
    Account: Account option
    AcctIDSource: AcctIDSource option
    CashDistribAgentAcctName: CashDistribAgentAcctName option
    CashDistribAgentAcctNumber: CashDistribAgentAcctNumber option
    CashDistribAgentCode: CashDistribAgentCode option
    CashDistribAgentName: CashDistribAgentName option
    CashDistribCurr: CashDistribCurr option
    CashDistribPayRef: CashDistribPayRef option
    ClOrdID: ClOrdID option
    DateOfBirth: DateOfBirth option
    DistribPaymentMethod: DistribPaymentMethod option
    DistribPercentage: DistribPercentage option
    InvestorCountryOfResidence: InvestorCountryOfResidence option
    MailingDtls: MailingDtls option
    MailingInst: MailingInst option
    NestedParties: NestedParties option // component
    NoDistribInstsGrp: NoDistribInstsGrp option // group
    NoRegistDtlsGrp: NoRegistDtlsGrp option // group
    OwnerType: OwnerType option
    OwnershipType: OwnershipType option
    Parties: Parties option // component
    RegistAcctType: RegistAcctType option
    RegistDtls: RegistDtls option
    RegistEmail: RegistEmail option
    RegistID: RegistID
    RegistRefID: RegistRefID
    RegistTransType: RegistTransType
    TaxAdvantageType: TaxAdvantageType option
    }

// message
type RegistrationInstructionsResponse = {
    Account: Account option
    AcctIDSource: AcctIDSource option
    ClOrdID: ClOrdID option
    Parties: Parties option // component
    RegistID: RegistID
    RegistRefID: RegistRefID
    RegistRejReasonCode: RegistRejReasonCode option
    RegistRejReasonText: RegistRejReasonText option
    RegistStatus: RegistStatus
    RegistTransType: RegistTransType
    }

// message
type PositionMaintenanceRequest = {
    Account: Account
    AccountType: AccountType
    AcctIDSource: AcctIDSource option
    AdjustmentType: AdjustmentType option
    ClearingBusinessDate: ClearingBusinessDate
    ContraryInstructionIndicator: ContraryInstructionIndicator option
    Currency: Currency option
    EncodedText: EncodedText option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    NoLegsGrp: NoLegsGrp option // group
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrigPosReqRefID: OrigPosReqRefID option
    Parties: Parties // component
    PosMaintAction: PosMaintAction
    PosMaintRptRefID: PosMaintRptRefID option
    PosReqID: PosReqID
    PosTransType: PosTransType
    PositionQty: PositionQty // component
    PriorSpreadIndicator: PriorSpreadIndicator option
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    Text: Text option
    ThresholdAmount: ThresholdAmount option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type PositionMaintenanceReport = {
    Account: Account
    AccountType: AccountType
    AcctIDSource: AcctIDSource option
    AdjustmentType: AdjustmentType option
    ClearingBusinessDate: ClearingBusinessDate
    Currency: Currency option
    EncodedText: EncodedText option
    Instrument: Instrument // component
    InstrumentLeg: InstrumentLeg option // component
    NoLegsGrp: NoLegsGrp option // group
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrigPosReqRefID: OrigPosReqRefID
    Parties: Parties option // component
    PosMaintAction: PosMaintAction
    PosMaintResult: PosMaintResult option
    PosMaintRptID: PosMaintRptID
    PosMaintStatus: PosMaintStatus
    PosReqID: PosReqID option
    PosTransType: PosTransType
    PositionAmountData: PositionAmountData // component
    PositionQty: PositionQty // component
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    Text: Text option
    ThresholdAmount: ThresholdAmount option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type RequestForPositions = {
    Account: Account
    AccountType: AccountType
    AcctIDSource: AcctIDSource option
    ClearingBusinessDate: ClearingBusinessDate
    Currency: Currency option
    EncodedText: EncodedText option
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    MatchStatus: MatchStatus option
    NoLegsGrp: NoLegsGrp option // group
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    Parties: Parties // component
    PosReqID: PosReqID
    PosReqType: PosReqType
    ResponseDestination: ResponseDestination option
    ResponseTransportType: ResponseTransportType option
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    SubscriptionRequestType: SubscriptionRequestType option
    Text: Text option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type RequestForPositionsAck = {
    Account: Account
    AccountType: AccountType
    AcctIDSource: AcctIDSource option
    Currency: Currency option
    EncodedText: EncodedText option
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    NoLegsGrp: NoLegsGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    Parties: Parties // component
    PosMaintRptID: PosMaintRptID
    PosReqID: PosReqID option
    PosReqResult: PosReqResult
    PosReqStatus: PosReqStatus
    ResponseDestination: ResponseDestination option
    ResponseTransportType: ResponseTransportType option
    Text: Text option
    TotalNumPosReports: TotalNumPosReports option
    UnderlyingInstrument: UnderlyingInstrument option // component
    UnsolicitedIndicator: UnsolicitedIndicator option
    }

// message
type PositionReport = {
    Account: Account
    AccountType: AccountType
    AcctIDSource: AcctIDSource option
    ClearingBusinessDate: ClearingBusinessDate
    Currency: Currency option
    DeliveryDate: DeliveryDate option
    EncodedText: EncodedText option
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    NoLegsGrp: NoLegsGrp option // group
    Parties: Parties // component
    PosMaintRptID: PosMaintRptID
    PosReqID: PosReqID option
    PosReqResult: PosReqResult
    PosReqType: PosReqType option
    PositionAmountData: PositionAmountData // component
    PositionQty: PositionQty // component
    PositionReport_NoUnderlyings_NoUnderlyingsGrp: PositionReport_NoUnderlyings_NoUnderlyingsGrp option // group
    PriorSettlPrice: PriorSettlPrice
    RegistStatus: RegistStatus option
    SettlPrice: SettlPrice
    SettlPriceType: SettlPriceType
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    SubscriptionRequestType: SubscriptionRequestType option
    Text: Text option
    TotalNumPosReports: TotalNumPosReports option
    UnderlyingInstrument: UnderlyingInstrument option // component
    UnderlyingSettlPrice: UnderlyingSettlPrice
    UnderlyingSettlPriceType: UnderlyingSettlPriceType
    UnsolicitedIndicator: UnsolicitedIndicator option
    }

// message
type AssignmentReport = {
    Account: Account option
    AccountType: AccountType
    AsgnRptID: AsgnRptID
    AssignmentMethod: AssignmentMethod
    AssignmentUnit: AssignmentUnit option
    ClearingBusinessDate: ClearingBusinessDate
    Currency: Currency option
    EncodedText: EncodedText option
    ExerciseMethod: ExerciseMethod
    ExpireDate: ExpireDate option
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    LastRptRequested: LastRptRequested option
    NoLegs: NoLegs option
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OpenInterest: OpenInterest
    Parties: Parties // component
    PositionAmountData: PositionAmountData // component
    PositionQty: PositionQty // component
    SettlPrice: SettlPrice
    SettlPriceType: SettlPriceType
    SettlSessID: SettlSessID
    SettlSessSubID: SettlSessSubID
    Text: Text option
    ThresholdAmount: ThresholdAmount option
    TotNumAssignmentReports: TotNumAssignmentReports option
    UnderlyingInstrument: UnderlyingInstrument option // component
    UnderlyingSettlPrice: UnderlyingSettlPrice
    }

// message
type CollateralRequest = {
    Account: Account option
    AccountType: AccountType option
    AccruedInterestAmt: AccruedInterestAmt option
    CashOutstanding: CashOutstanding option
    ClOrdID: ClOrdID option
    ClearingBusinessDate: ClearingBusinessDate option
    CollAction: CollAction option
    CollAsgnReason: CollAsgnReason
    CollReqID: CollReqID
    CollateralRequest_NoUnderlyings_NoUnderlyingsGrp: CollateralRequest_NoUnderlyings_NoUnderlyingsGrp option // group
    Currency: Currency option
    EncodedText: EncodedText option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    EndCash: EndCash option
    ExecID: ExecID option
    ExpireTime: ExpireTime option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    MarginExcess: MarginExcess option
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeBasis: MiscFeeBasis option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    NoExecsGrp: NoExecsGrp option // group
    NoLegs: NoLegs option
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    NoTradesGrp: NoTradesGrp option // group
    OrderID: OrderID option
    Parties: Parties option // component
    Price: Price option
    PriceType: PriceType option
    QtyType: QtyType option
    Quantity: Quantity option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    SettlDate: SettlDate option
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    Side: Side option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    StartCash: StartCash option
    Stipulations: Stipulations option // component
    Text: Text option
    TotalNetValue: TotalNetValue option
    TradeReportID: TradeReportID option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime
    TrdRegTimestamps: TrdRegTimestamps option // component
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type CollateralAssignment = {
    Account: Account option
    AccountType: AccountType option
    AccruedInterestAmt: AccruedInterestAmt option
    CashOutstanding: CashOutstanding option
    ClOrdID: ClOrdID option
    ClearingBusinessDate: ClearingBusinessDate option
    CollAction: CollAction option
    CollAsgnID: CollAsgnID
    CollAsgnReason: CollAsgnReason
    CollAsgnRefID: CollAsgnRefID option
    CollAsgnTransType: CollAsgnTransType
    CollReqID: CollReqID option
    CollateralAssignment_NoUnderlyings_NoUnderlyingsGrp: CollateralAssignment_NoUnderlyings_NoUnderlyingsGrp option // group
    Currency: Currency option
    EncodedText: EncodedText option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    EndCash: EndCash option
    ExecID: ExecID option
    ExpireTime: ExpireTime option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    MarginExcess: MarginExcess option
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeBasis: MiscFeeBasis option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    NoExecsGrp: NoExecsGrp option // group
    NoLegs: NoLegs option
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    NoTradesGrp: NoTradesGrp option // group
    OrderID: OrderID option
    Parties: Parties option // component
    Price: Price option
    PriceType: PriceType option
    QtyType: QtyType option
    Quantity: Quantity option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    SettlDate: SettlDate option
    SettlInstructionsData: SettlInstructionsData option // component
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    Side: Side option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    StartCash: StartCash option
    Stipulations: Stipulations option // component
    Text: Text option
    TotalNetValue: TotalNetValue option
    TradeReportID: TradeReportID option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TransactTime: TransactTime
    TrdRegTimestamps: TrdRegTimestamps option // component
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type CollateralResponse = {
    Account: Account option
    AccountType: AccountType option
    AccruedInterestAmt: AccruedInterestAmt option
    CashOutstanding: CashOutstanding option
    ClOrdID: ClOrdID option
    CollAction: CollAction option
    CollAsgnID: CollAsgnID
    CollAsgnReason: CollAsgnReason
    CollAsgnRejectReason: CollAsgnRejectReason option
    CollAsgnRespType: CollAsgnRespType
    CollAsgnTransType: CollAsgnTransType option
    CollReqID: CollReqID option
    CollRespID: CollRespID
    CollateralResponse_NoUnderlyings_NoUnderlyingsGrp: CollateralResponse_NoUnderlyings_NoUnderlyingsGrp option // group
    Currency: Currency option
    EncodedText: EncodedText option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    EndCash: EndCash option
    ExecID: ExecID option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    MarginExcess: MarginExcess option
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeBasis: MiscFeeBasis option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    NoExecsGrp: NoExecsGrp option // group
    NoLegs: NoLegs option
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    NoTradesGrp: NoTradesGrp option // group
    OrderID: OrderID option
    Parties: Parties option // component
    Price: Price option
    PriceType: PriceType option
    QtyType: QtyType option
    Quantity: Quantity option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    SettlDate: SettlDate option
    Side: Side option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    StartCash: StartCash option
    Stipulations: Stipulations option // component
    Text: Text option
    TotalNetValue: TotalNetValue option
    TradeReportID: TradeReportID option
    TransactTime: TransactTime
    TrdRegTimestamps: TrdRegTimestamps option // component
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type CollateralReport = {
    Account: Account option
    AccountType: AccountType option
    AccruedInterestAmt: AccruedInterestAmt option
    CashOutstanding: CashOutstanding option
    ClOrdID: ClOrdID option
    ClearingBusinessDate: ClearingBusinessDate option
    CollInquiryID: CollInquiryID option
    CollRptID: CollRptID
    CollStatus: CollStatus
    Currency: Currency option
    EncodedText: EncodedText option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    EndCash: EndCash option
    ExecID: ExecID option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    LastRptRequested: LastRptRequested option
    MarginExcess: MarginExcess option
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeBasis: MiscFeeBasis option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    NoExecsGrp: NoExecsGrp option // group
    NoLegs: NoLegs option
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    NoTradesGrp: NoTradesGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrderID: OrderID option
    Parties: Parties option // component
    Price: Price option
    PriceType: PriceType option
    QtyType: QtyType option
    Quantity: Quantity option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    SettlDate: SettlDate option
    SettlInstructionsData: SettlInstructionsData option // component
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    Side: Side option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    StartCash: StartCash option
    Stipulations: Stipulations option // component
    Text: Text option
    TotNumReports: TotNumReports option
    TotalNetValue: TotalNetValue option
    TradeReportID: TradeReportID option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TrdRegTimestamps: TrdRegTimestamps option // component
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type CollateralInquiry = {
    Account: Account option
    AccountType: AccountType option
    AccruedInterestAmt: AccruedInterestAmt option
    CashOutstanding: CashOutstanding option
    ClOrdID: ClOrdID option
    ClearingBusinessDate: ClearingBusinessDate option
    CollInquiryID: CollInquiryID option
    CollInquiryQualifier: CollInquiryQualifier option
    Currency: Currency option
    EncodedText: EncodedText option
    EndAccruedInterestAmt: EndAccruedInterestAmt option
    EndCash: EndCash option
    ExecID: ExecID option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    MarginExcess: MarginExcess option
    NoCollInquiryQualifierGrp: NoCollInquiryQualifierGrp option // group
    NoExecsGrp: NoExecsGrp option // group
    NoLegs: NoLegs option
    NoTradesGrp: NoTradesGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrderID: OrderID option
    Parties: Parties option // component
    Price: Price option
    PriceType: PriceType option
    QtyType: QtyType option
    Quantity: Quantity option
    ResponseDestination: ResponseDestination option
    ResponseTransportType: ResponseTransportType option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    SettlDate: SettlDate option
    SettlInstructionsData: SettlInstructionsData option // component
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    Side: Side option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    StartCash: StartCash option
    Stipulations: Stipulations option // component
    SubscriptionRequestType: SubscriptionRequestType option
    Text: Text option
    TotalNetValue: TotalNetValue option
    TradeReportID: TradeReportID option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TrdRegTimestamps: TrdRegTimestamps option // component
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// message
type NetworkStatusRequest = {
    DeskID: DeskID option
    LocationID: LocationID option
    NetworkRequestID: NetworkRequestID
    NetworkRequestType: NetworkRequestType
    NoCompIDsGrp: NoCompIDsGrp option // group
    RefCompID: RefCompID option
    RefSubID: RefSubID option
    }

// message
type NetworkStatusResponse = {
    DeskID: DeskID option
    LastNetworkResponseID: LastNetworkResponseID option
    LocationID: LocationID option
    NetworkRequestID: NetworkRequestID option
    NetworkResponseID: NetworkResponseID option
    NetworkStatusResponseType: NetworkStatusResponseType
    NetworkStatusResponse_NoCompIDs_NoCompIDsGrp: NetworkStatusResponse_NoCompIDs_NoCompIDsGrp // group
    RefCompID: RefCompID option
    RefSubID: RefSubID option
    StatusText: StatusText option
    StatusValue: StatusValue option
    }

// message
type CollateralInquiryAck = {
    Account: Account option
    AccountType: AccountType option
    ClOrdID: ClOrdID option
    ClearingBusinessDate: ClearingBusinessDate option
    CollInquiryID: CollInquiryID
    CollInquiryQualifier: CollInquiryQualifier option
    CollInquiryResult: CollInquiryResult option
    CollInquiryStatus: CollInquiryStatus
    Currency: Currency option
    EncodedText: EncodedText option
    ExecID: ExecID option
    FinancingDetails: FinancingDetails option // component
    Instrument: Instrument option // component
    InstrumentLeg: InstrumentLeg option // component
    NoCollInquiryQualifierGrp: NoCollInquiryQualifierGrp option // group
    NoExecsGrp: NoExecsGrp option // group
    NoLegs: NoLegs option
    NoTradesGrp: NoTradesGrp option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    OrderID: OrderID option
    Parties: Parties option // component
    QtyType: QtyType option
    Quantity: Quantity option
    ResponseDestination: ResponseDestination option
    ResponseTransportType: ResponseTransportType option
    SecondaryClOrdID: SecondaryClOrdID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    SettlDate: SettlDate option
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    Text: Text option
    TotNumReports: TotNumReports option
    TradeReportID: TradeReportID option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    }
