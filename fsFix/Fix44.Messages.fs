module Fix44.Messages

open Fix44.Fields
open Fix44.CompoundItems



type Heartbeat = {
    TestReqID: TestReqID option
    }

type Logon = {
    EncryptMethod: EncryptMethod
    HeartBtInt: HeartBtInt
    RawDataLength: RawDataLength option
    RawData: RawData option
    ResetSeqNumFlag: ResetSeqNumFlag option
    NextExpectedMsgSeqNum: NextExpectedMsgSeqNum option
    MaxMessageSize: MaxMessageSize option
    NoMsgTypesGrp: NoMsgTypesGrp option // group
    RefMsgType: RefMsgType option
    MsgDirection: MsgDirection option
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
    RawDataLength: RawDataLength option
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
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    Advertisement_NoUnderlyings_NoUnderlyingsGrp: Advertisement_NoUnderlyings_NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument // component
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
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    Side: Side
    QtyType: QtyType option
    OrderQtyData: OrderQtyData option // component
    IOIQty: IOIQty
    Currency: Currency option
    Stipulations: Stipulations option // component
    IndicationOfInterest_NoLegs_NoLegsGrp: IndicationOfInterest_NoLegs_NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    LegIOIQty: LegIOIQty option
    LegStipulations: LegStipulations option // component
    PriceType: PriceType option
    Price: Price option
    ValidUntilTime: ValidUntilTime option
    IOIQltyInd: IOIQltyInd option
    IOINaturalFlag: IOINaturalFlag option
    NoIOIQualifiersGrp: NoIOIQualifiersGrp option // group
    IOIQualifier: IOIQualifier option
    Text: Text option
    EncodedText: EncodedText option
    TransactTime: TransactTime option
    URLLink: URLLink option
    NoRoutingIDsGrp: NoRoutingIDsGrp option // group
    RoutingType: RoutingType option
    RoutingID: RoutingID option
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    YieldData: YieldData option // component
    }

type News = {
    OrigTime: OrigTime option
    Urgency: Urgency option
    Headline: Headline
    EncodedHeadline: EncodedHeadline option
    NoRoutingIDsGrp: NoRoutingIDsGrp option // group
    RoutingType: RoutingType option
    RoutingID: RoutingID option
    NoRelatedSymGrp: NoRelatedSymGrp option // group
    Instrument: Instrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    LinesOfTextGrp: LinesOfTextGrp // group
    Text: Text
    EncodedText: EncodedText option
    URLLink: URLLink option
    RawDataLength: RawDataLength option
    RawData: RawData option
    }

type Email = {
    EmailThreadID: EmailThreadID
    EmailType: EmailType
    OrigTime: OrigTime option
    Subject: Subject
    EncodedSubject: EncodedSubject option
    NoRoutingIDsGrp: NoRoutingIDsGrp option // group
    RoutingType: RoutingType option
    RoutingID: RoutingID option
    NoRelatedSymGrp: NoRelatedSymGrp option // group
    Instrument: Instrument option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    OrderID: OrderID option
    ClOrdID: ClOrdID option
    LinesOfTextGrp: LinesOfTextGrp // group
    Text: Text
    EncodedText: EncodedText option
    RawDataLength: RawDataLength option
    RawData: RawData option
    }

type QuoteRequest = {
    QuoteReqID: QuoteReqID
    RFQReqID: RFQReqID option
    ClOrdID: ClOrdID option
    OrderCapacity: OrderCapacity option
    QuoteRequest_NoRelatedSym_NoRelatedSymGrp: QuoteRequest_NoRelatedSym_NoRelatedSymGrp // group
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    PrevClosePx: PrevClosePx option
    QuoteRequestType: QuoteRequestType option
    QuoteType: QuoteType option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TradeOriginationDate: TradeOriginationDate option
    Side: Side option
    QtyType: QtyType option
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
    QuoteRequest_NoLegs_NoLegsGrp: QuoteRequest_NoLegs_NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegStipulations: LegStipulations option // component
    NestedParties: NestedParties option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp option // group
    QuoteQualifier: QuoteQualifier option
    QuotePriceType: QuotePriceType option
    OrdType: OrdType option
    ValidUntilTime: ValidUntilTime option
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

type QuoteResponse = {
    QuoteRespID: QuoteRespID
    QuoteID: QuoteID option
    QuoteRespType: QuoteRespType
    ClOrdID: ClOrdID option
    OrderCapacity: OrderCapacity option
    IOIid: IOIid option
    QuoteType: QuoteType option
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp option // group
    QuoteQualifier: QuoteQualifier option
    Parties: Parties option // component
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
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
    QuoteResponse_NoLegs_NoLegsGrp: QuoteResponse_NoLegs_NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegStipulations: LegStipulations option // component
    NestedParties: NestedParties option // component
    LegPriceType: LegPriceType option
    LegBidPx: LegBidPx option
    LegOfferPx: LegOfferPx option
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
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
    QuoteRequestReject_NoRelatedSym_NoRelatedSymGrp: QuoteRequestReject_NoRelatedSym_NoRelatedSymGrp // group
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    PrevClosePx: PrevClosePx option
    QuoteRequestType: QuoteRequestType option
    QuoteType: QuoteType option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TradeOriginationDate: TradeOriginationDate option
    Side: Side option
    QtyType: QtyType option
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
    QuoteRequestReject_NoLegs_NoLegsGrp: QuoteRequestReject_NoLegs_NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegStipulations: LegStipulations option // component
    NestedParties: NestedParties option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp option // group
    QuoteQualifier: QuoteQualifier option
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
    RFQRequest_NoRelatedSym_NoRelatedSymGrp: RFQRequest_NoRelatedSym_NoRelatedSymGrp // group
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    PrevClosePx: PrevClosePx option
    QuoteRequestType: QuoteRequestType option
    QuoteType: QuoteType option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    SubscriptionRequestType: SubscriptionRequestType option
    }

type Quote = {
    QuoteReqID: QuoteReqID option
    QuoteID: QuoteID
    QuoteRespID: QuoteRespID option
    QuoteType: QuoteType option
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp option // group
    QuoteQualifier: QuoteQualifier option
    QuoteResponseLevel: QuoteResponseLevel option
    Parties: Parties option // component
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
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
    Quote_NoLegs_NoLegsGrp: Quote_NoLegs_NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegStipulations: LegStipulations option // component
    NestedParties: NestedParties option // component
    LegPriceType: LegPriceType option
    LegBidPx: LegBidPx option
    LegOfferPx: LegOfferPx option
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
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
    NoQuoteEntriesGrp: NoQuoteEntriesGrp option // group
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    }

type QuoteStatusRequest = {
    QuoteStatusReqID: QuoteStatusReqID option
    QuoteID: QuoteID option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
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
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
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
    QuoteStatusReport_NoLegs_NoLegsGrp: QuoteStatusReport_NoLegs_NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegStipulations: LegStipulations option // component
    NestedParties: NestedParties option // component
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp option // group
    QuoteQualifier: QuoteQualifier option
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
    NoQuoteSetsGrp: NoQuoteSetsGrp // group
    QuoteSetID: QuoteSetID
    UnderlyingInstrument: UnderlyingInstrument option // component
    QuoteSetValidUntilTime: QuoteSetValidUntilTime option
    TotNoQuoteEntries: TotNoQuoteEntries
    LastFragment: LastFragment option
    MassQuote_NoQuoteEntries_NoQuoteEntriesGrp: MassQuote_NoQuoteEntries_NoQuoteEntriesGrp // group
    QuoteEntryID: QuoteEntryID
    Instrument: Instrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    BidPx: BidPx option
    OfferPx: OfferPx option
    BidSize: BidSize option
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
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    SettlDate: SettlDate option
    OrdType: OrdType option
    SettlDate2: SettlDate2 option
    OrderQty2: OrderQty2 option
    BidForwardPoints2: BidForwardPoints2 option
    OfferForwardPoints2: OfferForwardPoints2 option
    Currency: Currency option
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
    MassQuoteAcknowledgement_NoQuoteSets_NoQuoteSetsGrp: MassQuoteAcknowledgement_NoQuoteSets_NoQuoteSetsGrp option // group
    QuoteSetID: QuoteSetID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    TotNoQuoteEntries: TotNoQuoteEntries option
    LastFragment: LastFragment option
    MassQuoteAcknowledgement_NoQuoteEntries_NoQuoteEntriesGrp: MassQuoteAcknowledgement_NoQuoteEntries_NoQuoteEntriesGrp option // group
    QuoteEntryID: QuoteEntryID option
    Instrument: Instrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    BidPx: BidPx option
    OfferPx: OfferPx option
    BidSize: BidSize option
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
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    SettlDate: SettlDate option
    OrdType: OrdType option
    SettlDate2: SettlDate2 option
    OrderQty2: OrderQty2 option
    BidForwardPoints2: BidForwardPoints2 option
    OfferForwardPoints2: OfferForwardPoints2 option
    Currency: Currency option
    QuoteEntryRejectReason: QuoteEntryRejectReason option
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
    NoMDEntryTypesGrp: NoMDEntryTypesGrp // group
    MDEntryType: MDEntryType
    MarketDataRequest_NoRelatedSym_NoRelatedSymGrp: MarketDataRequest_NoRelatedSym_NoRelatedSymGrp // group
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    ApplQueueAction: ApplQueueAction option
    ApplQueueMax: ApplQueueMax option
    }

type MarketDataSnapshotFullRefresh = {
    MDReqID: MDReqID option
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    FinancialStatus: FinancialStatus option
    CorporateAction: CorporateAction option
    NetChgPrevDay: NetChgPrevDay option
    NoMDEntriesGrp: NoMDEntriesGrp // group
    MDEntryType: MDEntryType
    MDEntryPx: MDEntryPx option
    Currency: Currency option
    MDEntrySize: MDEntrySize option
    MDEntryDate: MDEntryDate option
    MDEntryTime: MDEntryTime option
    TickDirection: TickDirection option
    MDMkt: MDMkt option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    QuoteCondition: QuoteCondition option
    TradeCondition: TradeCondition option
    MDEntryOriginator: MDEntryOriginator option
    LocationID: LocationID option
    DeskID: DeskID option
    OpenCloseSettlFlag: OpenCloseSettlFlag option
    TimeInForce: TimeInForce option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    MinQty: MinQty option
    ExecInst: ExecInst option
    SellerDays: SellerDays option
    OrderID: OrderID option
    QuoteEntryID: QuoteEntryID option
    MDEntryBuyer: MDEntryBuyer option
    MDEntrySeller: MDEntrySeller option
    NumberOfOrders: NumberOfOrders option
    MDEntryPositionNo: MDEntryPositionNo option
    Scope: Scope option
    PriceDelta: PriceDelta option
    Text: Text option
    EncodedText: EncodedText option
    ApplQueueDepth: ApplQueueDepth option
    ApplQueueResolution: ApplQueueResolution option
    }

type MarketDataIncrementalRefresh = {
    MDReqID: MDReqID option
    MarketDataIncrementalRefresh_NoMDEntries_NoMDEntriesGrp: MarketDataIncrementalRefresh_NoMDEntries_NoMDEntriesGrp // group
    MDUpdateAction: MDUpdateAction
    DeleteReason: DeleteReason option
    MDEntryType: MDEntryType option
    MDEntryID: MDEntryID option
    MDEntryRefID: MDEntryRefID option
    Instrument: Instrument option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    FinancialStatus: FinancialStatus option
    CorporateAction: CorporateAction option
    MDEntryPx: MDEntryPx option
    Currency: Currency option
    MDEntrySize: MDEntrySize option
    MDEntryDate: MDEntryDate option
    MDEntryTime: MDEntryTime option
    TickDirection: TickDirection option
    MDMkt: MDMkt option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    QuoteCondition: QuoteCondition option
    TradeCondition: TradeCondition option
    MDEntryOriginator: MDEntryOriginator option
    LocationID: LocationID option
    DeskID: DeskID option
    OpenCloseSettlFlag: OpenCloseSettlFlag option
    TimeInForce: TimeInForce option
    ExpireDate: ExpireDate option
    ExpireTime: ExpireTime option
    MinQty: MinQty option
    ExecInst: ExecInst option
    SellerDays: SellerDays option
    OrderID: OrderID option
    QuoteEntryID: QuoteEntryID option
    MDEntryBuyer: MDEntryBuyer option
    MDEntrySeller: MDEntrySeller option
    NumberOfOrders: NumberOfOrders option
    MDEntryPositionNo: MDEntryPositionNo option
    Scope: Scope option
    PriceDelta: PriceDelta option
    NetChgPrevDay: NetChgPrevDay option
    Text: Text option
    EncodedText: EncodedText option
    ApplQueueDepth: ApplQueueDepth option
    ApplQueueResolution: ApplQueueResolution option
    }

type MarketDataRequestReject = {
    MDReqID: MDReqID
    MDReqRejReason: MDReqRejReason option
    NoAltMDSourceGrp: NoAltMDSourceGrp option // group
    AltMDSourceID: AltMDSourceID option
    Text: Text option
    EncodedText: EncodedText option
    }

type SecurityDefinitionRequest = {
    SecurityReqID: SecurityReqID
    SecurityRequestType: SecurityRequestType
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    Currency: Currency option
    Text: Text option
    EncodedText: EncodedText option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    ExpirationCycle: ExpirationCycle option
    SubscriptionRequestType: SubscriptionRequestType option
    }

type SecurityDefinition = {
    SecurityReqID: SecurityReqID
    SecurityResponseID: SecurityResponseID
    SecurityResponseType: SecurityResponseType
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    Currency: Currency option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Text: Text option
    EncodedText: EncodedText option
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
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
    NoSecurityTypesGrp: NoSecurityTypesGrp option // group
    SecurityType: SecurityType option
    SecuritySubType: SecuritySubType option
    Product: Product option
    CFICode: CFICode option
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
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
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
    SecurityList_NoRelatedSym_NoRelatedSymGrp: SecurityList_NoRelatedSym_NoRelatedSymGrp option // group
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    Currency: Currency option
    Stipulations: Stipulations option // component
    SecurityList_NoLegs_NoLegsGrp: SecurityList_NoLegs_NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    SpreadOrBenchmarkCurveData: SpreadOrBenchmarkCurveData option // component
    YieldData: YieldData option // component
    RoundLot: RoundLot option
    MinTradeVol: MinTradeVol option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    ExpirationCycle: ExpirationCycle option
    Text: Text option
    EncodedText: EncodedText option
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
    DerivativeSecurityList_NoRelatedSym_NoRelatedSymGrp: DerivativeSecurityList_NoRelatedSym_NoRelatedSymGrp option // group
    Instrument: Instrument option // component
    Currency: Currency option
    ExpirationCycle: ExpirationCycle option
    InstrumentExtension: InstrumentExtension option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Text: Text option
    EncodedText: EncodedText option
    }

type SecurityStatusRequest = {
    SecurityStatusReqID: SecurityStatusReqID
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    Currency: Currency option
    SubscriptionRequestType: SubscriptionRequestType
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    }

type SecurityStatus = {
    SecurityStatusReqID: SecurityStatusReqID option
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
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
    NoAllocsGrp: NoAllocsGrp option // group
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties: NestedParties option // component
    AllocQty: AllocQty option
    SettlType: SettlType option
    SettlDate: SettlDate option
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    HandlInst: HandlInst option
    ExecInst: ExecInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    ExDestination: ExDestination option
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    ProcessCode: ProcessCode option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
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
    NoContraBrokersGrp: NoContraBrokersGrp option // group
    ContraBroker: ContraBroker option
    ContraTrader: ContraTrader option
    ContraTradeQty: ContraTradeQty option
    ContraTradeTime: ContraTradeTime option
    ContraLegRefID: ContraLegRefID option
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
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
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
    NoContAmtsGrp: NoContAmtsGrp option // group
    ContAmtType: ContAmtType option
    ContAmtValue: ContAmtValue option
    ContAmtCurr: ContAmtCurr option
    ExecutionReport_NoLegs_NoLegsGrp: ExecutionReport_NoLegs_NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegStipulations: LegStipulations option // component
    LegPositionEffect: LegPositionEffect option
    LegCoveredOrUncovered: LegCoveredOrUncovered option
    NestedParties: NestedParties option // component
    LegRefID: LegRefID option
    LegPrice: LegPrice option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegLastPx: LegLastPx option
    CopyMsgIndicator: CopyMsgIndicator option
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
    }

type DontKnowTrade = {
    OrderID: OrderID
    SecondaryOrderID: SecondaryOrderID option
    ExecID: ExecID
    DKReason: DKReason
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
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
    NoAllocsGrp: NoAllocsGrp option // group
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties: NestedParties option // component
    AllocQty: AllocQty option
    SettlType: SettlType option
    SettlDate: SettlDate option
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    HandlInst: HandlInst option
    ExecInst: ExecInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    ExDestination: ExDestination option
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
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
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
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
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
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
    NoAffectedOrdersGrp: NoAffectedOrdersGrp option // group
    OrigClOrdID: OrigClOrdID option
    AffectedOrderID: AffectedOrderID option
    AffectedSecondaryOrderID: AffectedSecondaryOrderID option
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
    NoSidesGrp: NoSidesGrp // group
    Side: Side
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
    NoAllocsGrp: NoAllocsGrp option // group
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties: NestedParties option // component
    AllocQty: AllocQty option
    QtyType: QtyType option
    OrderQtyData: OrderQtyData // component
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
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    SolicitedFlag: SolicitedFlag option
    SideComplianceID: SideComplianceID option
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    SettlType: SettlType option
    SettlDate: SettlDate option
    HandlInst: HandlInst option
    ExecInst: ExecInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    ExDestination: ExDestination option
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
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
    CrossOrderCancelReplaceRequest_NoSides_NoSidesGrp: CrossOrderCancelReplaceRequest_NoSides_NoSidesGrp // group
    Side: Side
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
    NoAllocsGrp: NoAllocsGrp option // group
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties: NestedParties option // component
    AllocQty: AllocQty option
    QtyType: QtyType option
    OrderQtyData: OrderQtyData // component
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
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    SolicitedFlag: SolicitedFlag option
    SideComplianceID: SideComplianceID option
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    SettlType: SettlType option
    SettlDate: SettlDate option
    HandlInst: HandlInst option
    ExecInst: ExecInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    ExDestination: ExDestination option
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
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
    CrossOrderCancelRequest_NoSides_NoSidesGrp: CrossOrderCancelRequest_NoSides_NoSidesGrp // group
    Side: Side
    OrigClOrdID: OrigClOrdID
    ClOrdID: ClOrdID
    SecondaryClOrdID: SecondaryClOrdID option
    ClOrdLinkID: ClOrdLinkID option
    OrigOrdModTime: OrigOrdModTime option
    Parties: Parties option // component
    TradeOriginationDate: TradeOriginationDate option
    TradeDate: TradeDate option
    OrderQtyData: OrderQtyData // component
    ComplianceID: ComplianceID option
    Text: Text option
    EncodedText: EncodedText option
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
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
    NewOrderMultileg_NoAllocs_NoAllocsGrp: NewOrderMultileg_NoAllocs_NoAllocsGrp option // group
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties3: NestedParties3 option // component
    AllocQty: AllocQty option
    SettlType: SettlType option
    SettlDate: SettlDate option
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    HandlInst: HandlInst option
    ExecInst: ExecInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    ExDestination: ExDestination option
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    ProcessCode: ProcessCode option
    Side: Side
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    PrevClosePx: PrevClosePx option
    NewOrderMultileg_NoLegs_NoLegsGrp: NewOrderMultileg_NoLegs_NoLegsGrp // group
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegStipulations: LegStipulations option // component
    NoLegAllocsGrp: NoLegAllocsGrp option // group
    LegAllocAccount: LegAllocAccount option
    LegIndividualAllocID: LegIndividualAllocID option
    NestedParties2: NestedParties2 option // component
    LegAllocQty: LegAllocQty option
    LegAllocAcctIDSource: LegAllocAcctIDSource option
    LegSettlCurrency: LegSettlCurrency option
    LegPositionEffect: LegPositionEffect option
    LegCoveredOrUncovered: LegCoveredOrUncovered option
    NestedParties: NestedParties option // component
    LegRefID: LegRefID option
    LegPrice: LegPrice option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
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
    MultilegOrderCancelReplaceRequest_NoAllocs_NoAllocsGrp: MultilegOrderCancelReplaceRequest_NoAllocs_NoAllocsGrp option // group
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties3: NestedParties3 option // component
    AllocQty: AllocQty option
    SettlType: SettlType option
    SettlDate: SettlDate option
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    HandlInst: HandlInst option
    ExecInst: ExecInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    ExDestination: ExDestination option
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    ProcessCode: ProcessCode option
    Side: Side
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    PrevClosePx: PrevClosePx option
    MultilegOrderCancelReplaceRequest_NoLegs_NoLegsGrp: MultilegOrderCancelReplaceRequest_NoLegs_NoLegsGrp // group
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegStipulations: LegStipulations option // component
    NoLegAllocsGrp: NoLegAllocsGrp option // group
    LegAllocAccount: LegAllocAccount option
    LegIndividualAllocID: LegIndividualAllocID option
    NestedParties2: NestedParties2 option // component
    LegAllocQty: LegAllocQty option
    LegAllocAcctIDSource: LegAllocAcctIDSource option
    LegSettlCurrency: LegSettlCurrency option
    LegPositionEffect: LegPositionEffect option
    LegCoveredOrUncovered: LegCoveredOrUncovered option
    NestedParties: NestedParties option // component
    LegRefID: LegRefID option
    LegPrice: LegPrice option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
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
    NoBidDescriptorsGrp: NoBidDescriptorsGrp option // group
    BidDescriptorType: BidDescriptorType option
    BidDescriptor: BidDescriptor option
    SideValueInd: SideValueInd option
    LiquidityValue: LiquidityValue option
    LiquidityNumSecurities: LiquidityNumSecurities option
    LiquidityPctLow: LiquidityPctLow option
    LiquidityPctHigh: LiquidityPctHigh option
    EFPTrackingError: EFPTrackingError option
    FairValue: FairValue option
    OutsideIndexPct: OutsideIndexPct option
    ValueOfFutures: ValueOfFutures option
    NoBidComponentsGrp: NoBidComponentsGrp option // group
    ListID: ListID option
    Side: Side option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    NetGrossInd: NetGrossInd option
    SettlType: SettlType option
    SettlDate: SettlDate option
    Account: Account option
    AcctIDSource: AcctIDSource option
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
    BidResponse_NoBidComponents_NoBidComponentsGrp: BidResponse_NoBidComponents_NoBidComponentsGrp // group
    CommissionData: CommissionData // component
    ListID: ListID option
    Country: Country option
    Side: Side option
    Price: Price option
    PriceType: PriceType option
    FairValue: FairValue option
    NetGrossInd: NetGrossInd option
    SettlType: SettlType option
    SettlDate: SettlDate option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Text: Text option
    EncodedText: EncodedText option
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
    NewOrderList_NoOrders_NoOrdersGrp: NewOrderList_NoOrders_NoOrdersGrp // group
    ClOrdID: ClOrdID
    SecondaryClOrdID: SecondaryClOrdID option
    ListSeqNo: ListSeqNo
    ClOrdLinkID: ClOrdLinkID option
    SettlInstMode: SettlInstMode option
    Parties: Parties option // component
    TradeOriginationDate: TradeOriginationDate option
    TradeDate: TradeDate option
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    DayBookingInst: DayBookingInst option
    BookingUnit: BookingUnit option
    AllocID: AllocID option
    PreallocMethod: PreallocMethod option
    NoAllocsGrp: NoAllocsGrp option // group
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties: NestedParties option // component
    AllocQty: AllocQty option
    SettlType: SettlType option
    SettlDate: SettlDate option
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    HandlInst: HandlInst option
    ExecInst: ExecInst option
    MinQty: MinQty option
    MaxFloor: MaxFloor option
    ExDestination: ExDestination option
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    ProcessCode: ProcessCode option
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    PrevClosePx: PrevClosePx option
    Side: Side
    SideValueInd: SideValueInd option
    LocateReqd: LocateReqd option
    TransactTime: TransactTime option
    Stipulations: Stipulations option // component
    QtyType: QtyType option
    OrderQtyData: OrderQtyData // component
    OrdType: OrdType option
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
    Designation: Designation option
    }

type ListStrikePrice = {
    ListID: ListID
    TotNoStrikes: TotNoStrikes
    LastFragment: LastFragment option
    NoStrikesGrp: NoStrikesGrp // group
    Instrument: Instrument // component
    ListStrikePrice_NoUnderlyings_NoUnderlyingsGrp: ListStrikePrice_NoUnderlyings_NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    PrevClosePx: PrevClosePx option
    ClOrdID: ClOrdID option
    SecondaryClOrdID: SecondaryClOrdID option
    Side: Side option
    Price: Price
    Currency: Currency option
    Text: Text option
    EncodedText: EncodedText option
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
    ListStatus_NoOrders_NoOrdersGrp: ListStatus_NoOrders_NoOrdersGrp // group
    ClOrdID: ClOrdID
    SecondaryClOrdID: SecondaryClOrdID option
    CumQty: CumQty
    OrdStatus: OrdStatus
    WorkingIndicator: WorkingIndicator option
    LeavesQty: LeavesQty
    CxlQty: CxlQty
    AvgPx: AvgPx
    OrdRejReason: OrdRejReason option
    Text: Text option
    EncodedText: EncodedText option
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
    NoOrdersGrp: NoOrdersGrp option // group
    ClOrdID: ClOrdID option
    OrderID: OrderID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    ListID: ListID option
    NestedParties2: NestedParties2 option // component
    OrderQty: OrderQty option
    OrderAvgPx: OrderAvgPx option
    OrderBookingQty: OrderBookingQty option
    AllocationInstruction_NoExecs_NoExecsGrp: AllocationInstruction_NoExecs_NoExecsGrp option // group
    LastQty: LastQty option
    ExecID: ExecID option
    SecondaryExecID: SecondaryExecID option
    LastPx: LastPx option
    LastParPx: LastParPx option
    LastCapacity: LastCapacity option
    PreviouslyReported: PreviouslyReported option
    ReversalIndicator: ReversalIndicator option
    MatchType: MatchType option
    Side: Side
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
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
    AllocationInstruction_NoAllocs_NoAllocsGrp: AllocationInstruction_NoAllocs_NoAllocsGrp option // group
    AllocAccount: AllocAccount
    AllocAcctIDSource: AllocAcctIDSource option
    MatchStatus: MatchStatus option
    AllocPrice: AllocPrice option
    AllocQty: AllocQty option
    IndividualAllocID: IndividualAllocID option
    ProcessCode: ProcessCode option
    NestedParties: NestedParties option // component
    NotifyBrokerOfCredit: NotifyBrokerOfCredit option
    AllocHandlInst: AllocHandlInst option
    AllocText: AllocText option
    EncodedAllocText: EncodedAllocText option
    CommissionData: CommissionData option // component
    AllocAvgPx: AllocAvgPx option
    AllocNetMoney: AllocNetMoney option
    SettlCurrAmt: SettlCurrAmt option
    AllocSettlCurrAmt: AllocSettlCurrAmt option
    SettlCurrency: SettlCurrency option
    AllocSettlCurrency: AllocSettlCurrency option
    SettlCurrFxRate: SettlCurrFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    AccruedInterestAmt: AccruedInterestAmt option
    AllocAccruedInterestAmt: AllocAccruedInterestAmt option
    AllocInterestAtMaturity: AllocInterestAtMaturity option
    SettlInstMode: SettlInstMode option
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
    NoClearingInstructions: NoClearingInstructions option
    ClearingInstruction: ClearingInstruction option
    ClearingFeeIndicator: ClearingFeeIndicator option
    AllocSettlInstType: AllocSettlInstType option
    SettlInstructionsData: SettlInstructionsData option // component
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
    AllocationInstructionAck_NoAllocs_NoAllocsGrp: AllocationInstructionAck_NoAllocs_NoAllocsGrp option // group
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocPrice: AllocPrice option
    IndividualAllocID: IndividualAllocID option
    IndividualAllocRejCode: IndividualAllocRejCode option
    AllocText: AllocText option
    EncodedAllocText: EncodedAllocText option
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
    NoOrdersGrp: NoOrdersGrp option // group
    ClOrdID: ClOrdID option
    OrderID: OrderID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    ListID: ListID option
    NestedParties2: NestedParties2 option // component
    OrderQty: OrderQty option
    OrderAvgPx: OrderAvgPx option
    OrderBookingQty: OrderBookingQty option
    AllocationReport_NoExecs_NoExecsGrp: AllocationReport_NoExecs_NoExecsGrp option // group
    LastQty: LastQty option
    ExecID: ExecID option
    SecondaryExecID: SecondaryExecID option
    LastPx: LastPx option
    LastParPx: LastParPx option
    LastCapacity: LastCapacity option
    PreviouslyReported: PreviouslyReported option
    ReversalIndicator: ReversalIndicator option
    MatchType: MatchType option
    Side: Side
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
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
    AllocationReport_NoAllocs_NoAllocsGrp: AllocationReport_NoAllocs_NoAllocsGrp // group
    AllocAccount: AllocAccount
    AllocAcctIDSource: AllocAcctIDSource option
    MatchStatus: MatchStatus option
    AllocPrice: AllocPrice option
    AllocQty: AllocQty
    IndividualAllocID: IndividualAllocID option
    ProcessCode: ProcessCode option
    NestedParties: NestedParties option // component
    NotifyBrokerOfCredit: NotifyBrokerOfCredit option
    AllocHandlInst: AllocHandlInst option
    AllocText: AllocText option
    EncodedAllocText: EncodedAllocText option
    CommissionData: CommissionData option // component
    AllocAvgPx: AllocAvgPx option
    AllocNetMoney: AllocNetMoney option
    SettlCurrAmt: SettlCurrAmt option
    AllocSettlCurrAmt: AllocSettlCurrAmt option
    SettlCurrency: SettlCurrency option
    AllocSettlCurrency: AllocSettlCurrency option
    SettlCurrFxRate: SettlCurrFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    AllocAccruedInterestAmt: AllocAccruedInterestAmt option
    AllocInterestAtMaturity: AllocInterestAtMaturity option
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
    NoClearingInstructionsGrp: NoClearingInstructionsGrp option // group
    ClearingInstruction: ClearingInstruction option
    ClearingFeeIndicator: ClearingFeeIndicator option
    AllocSettlInstType: AllocSettlInstType option
    SettlInstructionsData: SettlInstructionsData option // component
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
    AllocationReportAck_NoAllocs_NoAllocsGrp: AllocationReportAck_NoAllocs_NoAllocsGrp option // group
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocPrice: AllocPrice option
    IndividualAllocID: IndividualAllocID option
    IndividualAllocRejCode: IndividualAllocRejCode option
    AllocText: AllocText option
    EncodedAllocText: EncodedAllocText option
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
    NoOrdersGrp: NoOrdersGrp option // group
    ClOrdID: ClOrdID option
    OrderID: OrderID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    ListID: ListID option
    NestedParties2: NestedParties2 option // component
    OrderQty: OrderQty option
    OrderAvgPx: OrderAvgPx option
    OrderBookingQty: OrderBookingQty option
    AllocID: AllocID option
    SecondaryAllocID: SecondaryAllocID option
    IndividualAllocID: IndividualAllocID option
    TransactTime: TransactTime
    TradeDate: TradeDate
    TrdRegTimestamps: TrdRegTimestamps option // component
    Instrument: Instrument // component
    InstrumentExtension: InstrumentExtension option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp // group
    InstrumentLeg: InstrumentLeg option // component
    YieldData: YieldData option // component
    AllocQty: AllocQty
    QtyType: QtyType option
    Side: Side
    Currency: Currency option
    LastMkt: LastMkt option
    NoCapacitiesGrp: NoCapacitiesGrp // group
    OrderCapacity: OrderCapacity
    OrderRestrictions: OrderRestrictions option
    OrderCapacityQty: OrderCapacityQty
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
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
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
    NoOrdersGrp: NoOrdersGrp option // group
    ClOrdID: ClOrdID option
    OrderID: OrderID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    ListID: ListID option
    NestedParties2: NestedParties2 option // component
    OrderQty: OrderQty option
    OrderAvgPx: OrderAvgPx option
    OrderBookingQty: OrderBookingQty option
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
    NoSettlInstGrp: NoSettlInstGrp option // group
    SettlInstID: SettlInstID option
    SettlInstTransType: SettlInstTransType option
    SettlInstRefID: SettlInstRefID option
    Parties: Parties option // component
    Side: Side option
    Product: Product option
    SecurityType: SecurityType option
    CFICode: CFICode option
    EffectiveTime: EffectiveTime option
    ExpireTime: ExpireTime option
    LastUpdateTime: LastUpdateTime option
    SettlInstructionsData: SettlInstructionsData option // component
    PaymentMethod: PaymentMethod option
    PaymentRef: PaymentRef option
    CardHolderName: CardHolderName option
    CardNumber: CardNumber option
    CardStartDate: CardStartDate option
    CardExpDate: CardExpDate option
    CardIssNum: CardIssNum option
    PaymentDate: PaymentDate option
    PaymentRemitterID: PaymentRemitterID option
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
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    NoDatesGrp: NoDatesGrp option // group
    TradeDate: TradeDate option
    TransactTime: TransactTime option
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
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
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
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
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
    TradeCaptureReport_NoLegs_NoLegsGrp: TradeCaptureReport_NoLegs_NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegStipulations: LegStipulations option // component
    LegPositionEffect: LegPositionEffect option
    LegCoveredOrUncovered: LegCoveredOrUncovered option
    NestedParties: NestedParties option // component
    LegRefID: LegRefID option
    LegPrice: LegPrice option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegLastPx: LegLastPx option
    TransactTime: TransactTime
    TrdRegTimestamps: TrdRegTimestamps option // component
    SettlType: SettlType option
    SettlDate: SettlDate option
    MatchStatus: MatchStatus option
    MatchType: MatchType option
    TradeCaptureReport_NoSides_NoSidesGrp: TradeCaptureReport_NoSides_NoSidesGrp // group
    Side: Side
    OrderID: OrderID
    SecondaryOrderID: SecondaryOrderID option
    ClOrdID: ClOrdID option
    SecondaryClOrdID: SecondaryClOrdID option
    ListID: ListID option
    Parties: Parties option // component
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    ProcessCode: ProcessCode option
    OddLot: OddLot option
    NoClearingInstructionsGrp: NoClearingInstructionsGrp option // group
    ClearingInstruction: ClearingInstruction option
    ClearingFeeIndicator: ClearingFeeIndicator option
    TradeInputSource: TradeInputSource option
    TradeInputDevice: TradeInputDevice option
    OrderInputDevice: OrderInputDevice option
    Currency: Currency option
    ComplianceID: ComplianceID option
    SolicitedFlag: SolicitedFlag option
    OrderCapacity: OrderCapacity option
    OrderRestrictions: OrderRestrictions option
    CustOrderCapacity: CustOrderCapacity option
    OrdType: OrdType option
    ExecInst: ExecInst option
    TransBkdTime: TransBkdTime option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    TimeBracket: TimeBracket option
    CommissionData: CommissionData option // component
    GrossTradeAmt: GrossTradeAmt option
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
    NetMoney: NetMoney option
    SettlCurrAmt: SettlCurrAmt option
    SettlCurrency: SettlCurrency option
    SettlCurrFxRate: SettlCurrFxRate option
    SettlCurrFxRateCalc: SettlCurrFxRateCalc option
    PositionEffect: PositionEffect option
    Text: Text option
    EncodedText: EncodedText option
    SideMultiLegReportingType: SideMultiLegReportingType option
    NoContAmtsGrp: NoContAmtsGrp option // group
    ContAmtType: ContAmtType option
    ContAmtValue: ContAmtValue option
    ContAmtCurr: ContAmtCurr option
    Stipulations: Stipulations option // component
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
    ExchangeRule: ExchangeRule option
    TradeAllocIndicator: TradeAllocIndicator option
    PreallocMethod: PreallocMethod option
    AllocID: AllocID option
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
    TradeCaptureReportAck_NoLegs_NoLegsGrp: TradeCaptureReportAck_NoLegs_NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegStipulations: LegStipulations option // component
    LegPositionEffect: LegPositionEffect option
    LegCoveredOrUncovered: LegCoveredOrUncovered option
    NestedParties: NestedParties option // component
    LegRefID: LegRefID option
    LegPrice: LegPrice option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegLastPx: LegLastPx option
    ClearingFeeIndicator: ClearingFeeIndicator option
    OrderCapacity: OrderCapacity option
    OrderRestrictions: OrderRestrictions option
    CustOrderCapacity: CustOrderCapacity option
    Account: Account option
    AcctIDSource: AcctIDSource option
    AccountType: AccountType option
    PositionEffect: PositionEffect option
    PreallocMethod: PreallocMethod option
    TradeCaptureReportAck_NoAllocs_NoAllocsGrp: TradeCaptureReportAck_NoAllocs_NoAllocsGrp option // group
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties2: NestedParties2 option // component
    AllocQty: AllocQty option
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
    NoRegistDtlsGrp: NoRegistDtlsGrp option // group
    RegistDtls: RegistDtls option
    RegistEmail: RegistEmail option
    MailingDtls: MailingDtls option
    MailingInst: MailingInst option
    NestedParties: NestedParties option // component
    OwnerType: OwnerType option
    DateOfBirth: DateOfBirth option
    InvestorCountryOfResidence: InvestorCountryOfResidence option
    NoDistribInstsGrp: NoDistribInstsGrp option // group
    DistribPaymentMethod: DistribPaymentMethod option
    DistribPercentage: DistribPercentage option
    CashDistribCurr: CashDistribCurr option
    CashDistribAgentName: CashDistribAgentName option
    CashDistribAgentCode: CashDistribAgentCode option
    CashDistribAgentAcctNumber: CashDistribAgentAcctNumber option
    CashDistribPayRef: CashDistribPayRef option
    CashDistribAgentAcctName: CashDistribAgentAcctName option
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
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
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
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
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
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    ClearingBusinessDate: ClearingBusinessDate
    SettlSessID: SettlSessID option
    SettlSessSubID: SettlSessSubID option
    NoTradingSessionsGrp: NoTradingSessionsGrp option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
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
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
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
    NoLegsGrp: NoLegsGrp option // group
    InstrumentLeg: InstrumentLeg option // component
    PositionReport_NoUnderlyings_NoUnderlyingsGrp: PositionReport_NoUnderlyings_NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    UnderlyingSettlPrice: UnderlyingSettlPrice
    UnderlyingSettlPriceType: UnderlyingSettlPriceType
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
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
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
    NoExecsGrp: NoExecsGrp option // group
    ExecID: ExecID option
    NoTradesGrp: NoTradesGrp option // group
    TradeReportID: TradeReportID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    SettlDate: SettlDate option
    Quantity: Quantity option
    QtyType: QtyType option
    Currency: Currency option
    NoLegs: NoLegs option
    InstrumentLeg: InstrumentLeg option // component
    CollateralRequest_NoUnderlyings_NoUnderlyingsGrp: CollateralRequest_NoUnderlyings_NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    CollAction: CollAction option
    MarginExcess: MarginExcess option
    TotalNetValue: TotalNetValue option
    CashOutstanding: CashOutstanding option
    TrdRegTimestamps: TrdRegTimestamps option // component
    Side: Side option
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
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
    NoExecsGrp: NoExecsGrp option // group
    ExecID: ExecID option
    NoTradesGrp: NoTradesGrp option // group
    TradeReportID: TradeReportID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    SettlDate: SettlDate option
    Quantity: Quantity option
    QtyType: QtyType option
    Currency: Currency option
    NoLegs: NoLegs option
    InstrumentLeg: InstrumentLeg option // component
    CollateralAssignment_NoUnderlyings_NoUnderlyingsGrp: CollateralAssignment_NoUnderlyings_NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    CollAction: CollAction option
    MarginExcess: MarginExcess option
    TotalNetValue: TotalNetValue option
    CashOutstanding: CashOutstanding option
    TrdRegTimestamps: TrdRegTimestamps option // component
    Side: Side option
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
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
    NoExecsGrp: NoExecsGrp option // group
    ExecID: ExecID option
    NoTradesGrp: NoTradesGrp option // group
    TradeReportID: TradeReportID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    SettlDate: SettlDate option
    Quantity: Quantity option
    QtyType: QtyType option
    Currency: Currency option
    NoLegs: NoLegs option
    InstrumentLeg: InstrumentLeg option // component
    CollateralResponse_NoUnderlyings_NoUnderlyingsGrp: CollateralResponse_NoUnderlyings_NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    CollAction: CollAction option
    MarginExcess: MarginExcess option
    TotalNetValue: TotalNetValue option
    CashOutstanding: CashOutstanding option
    TrdRegTimestamps: TrdRegTimestamps option // component
    Side: Side option
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
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
    NoExecsGrp: NoExecsGrp option // group
    ExecID: ExecID option
    NoTradesGrp: NoTradesGrp option // group
    TradeReportID: TradeReportID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    SettlDate: SettlDate option
    Quantity: Quantity option
    QtyType: QtyType option
    Currency: Currency option
    NoLegs: NoLegs option
    InstrumentLeg: InstrumentLeg option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    MarginExcess: MarginExcess option
    TotalNetValue: TotalNetValue option
    CashOutstanding: CashOutstanding option
    TrdRegTimestamps: TrdRegTimestamps option // component
    Side: Side option
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
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
    NoCollInquiryQualifierGrp: NoCollInquiryQualifierGrp option // group
    CollInquiryQualifier: CollInquiryQualifier option
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
    NoExecsGrp: NoExecsGrp option // group
    ExecID: ExecID option
    NoTradesGrp: NoTradesGrp option // group
    TradeReportID: TradeReportID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    SettlDate: SettlDate option
    Quantity: Quantity option
    QtyType: QtyType option
    Currency: Currency option
    NoLegs: NoLegs option
    InstrumentLeg: InstrumentLeg option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
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
    NoCompIDsGrp: NoCompIDsGrp option // group
    RefCompID: RefCompID option
    RefSubID: RefSubID option
    LocationID: LocationID option
    DeskID: DeskID option
    }

type NetworkStatusResponse = {
    NetworkStatusResponseType: NetworkStatusResponseType
    NetworkRequestID: NetworkRequestID option
    NetworkResponseID: NetworkResponseID option
    LastNetworkResponseID: LastNetworkResponseID option
    NetworkStatusResponse_NoCompIDs_NoCompIDsGrp: NetworkStatusResponse_NoCompIDs_NoCompIDsGrp // group
    RefCompID: RefCompID option
    RefSubID: RefSubID option
    LocationID: LocationID option
    DeskID: DeskID option
    StatusValue: StatusValue option
    StatusText: StatusText option
    }

type CollateralInquiryAck = {
    CollInquiryID: CollInquiryID
    CollInquiryStatus: CollInquiryStatus
    CollInquiryResult: CollInquiryResult option
    NoCollInquiryQualifierGrp: NoCollInquiryQualifierGrp option // group
    CollInquiryQualifier: CollInquiryQualifier option
    TotNumReports: TotNumReports option
    Parties: Parties option // component
    Account: Account option
    AccountType: AccountType option
    ClOrdID: ClOrdID option
    OrderID: OrderID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    NoExecsGrp: NoExecsGrp option // group
    ExecID: ExecID option
    NoTradesGrp: NoTradesGrp option // group
    TradeReportID: TradeReportID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    SettlDate: SettlDate option
    Quantity: Quantity option
    QtyType: QtyType option
    Currency: Currency option
    NoLegs: NoLegs option
    InstrumentLeg: InstrumentLeg option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
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
