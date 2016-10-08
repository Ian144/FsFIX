module Fix44.Groups

open Fix44.Fields


type NoClearingInstructionsGrp = {
    ClearingInstruction: ClearingInstruction option
    }

type NoContAmtsGrp = {
    ContAmtType: ContAmtType option
    ContAmtValue: ContAmtValue option
    ContAmtCurr: ContAmtCurr option
    }

type NoMiscFeesGrp = {
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
    }

type NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties: NestedParties option // component
    AllocQty: AllocQty option
    }

type TradeCaptureReport_NoSides_NoSidesGrp = {
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
    NoClearingInstructions: NoClearingInstructions option // group
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
    EncodedTextLen: EncodedTextLen option
    EncodedText: EncodedText option
    SideMultiLegReportingType: SideMultiLegReportingType option
    NoContAmts: NoContAmts option // group
    ContAmtType: ContAmtType option
    ContAmtValue: ContAmtValue option
    ContAmtCurr: ContAmtCurr option
    Stipulations: Stipulations option // component
    NoMiscFees: NoMiscFees option // group
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
    ExchangeRule: ExchangeRule option
    TradeAllocIndicator: TradeAllocIndicator option
    PreallocMethod: PreallocMethod option
    AllocID: AllocID option
    NoAllocs: NoAllocs option // group
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties2: NestedParties2 option // component
    AllocQty: AllocQty option
    }

type NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

type NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    }

type SecurityList_NoRelatedSym_NoRelatedSymGrp = {
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyings: NoUnderlyings option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    Currency: Currency option
    Stipulations: Stipulations option // component
    NoLegs: NoLegs option // group
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
    EncodedTextLen: EncodedTextLen option
    EncodedText: EncodedText option
    }

type RFQRequest_NoRelatedSym_NoRelatedSymGrp = {
    Instrument: Instrument // component
    NoUnderlyings: NoUnderlyings option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegs: NoLegs option // group
    InstrumentLeg: InstrumentLeg option // component
    PrevClosePx: PrevClosePx option
    QuoteRequestType: QuoteRequestType option
    QuoteType: QuoteType option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    }

type NoQuoteQualifiersGrp = {
    QuoteQualifier: QuoteQualifier option
    }

type QuoteRequest_NoRelatedSym_NoRelatedSymGrp = {
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyings: NoUnderlyings option // group
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
    NoLegs: NoLegs option // group
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegStipulations: LegStipulations option // component
    NestedParties: NestedParties option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    NoQuoteQualifiers: NoQuoteQualifiers option // group
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
    }

type QuoteRequestReject_NoRelatedSym_NoRelatedSymGrp = {
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyings: NoUnderlyings option // group
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
    NoLegs: NoLegs option // group
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegStipulations: LegStipulations option // component
    NestedParties: NestedParties option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    }

type NoSidesGrp = {
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
    NoAllocs: NoAllocs option // group
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
    EncodedTextLen: EncodedTextLen option
    EncodedText: EncodedText option
    PositionEffect: PositionEffect option
    CoveredOrUncovered: CoveredOrUncovered option
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    SolicitedFlag: SolicitedFlag option
    SideComplianceID: SideComplianceID option
    }

type NoSettlPartySubIDsGrp = {
    SettlPartySubID: SettlPartySubID option
    SettlPartySubIDType: SettlPartySubIDType option
    }

type NoSettlPartyIDsGrp = {
    SettlPartyID: SettlPartyID option
    SettlPartyIDSource: SettlPartyIDSource option
    SettlPartyRole: SettlPartyRole option
    NoSettlPartySubIDs: NoSettlPartySubIDs option // group
    SettlPartySubID: SettlPartySubID option
    SettlPartySubIDType: SettlPartySubIDType option
    }

type NoQuoteEntriesGrp = {
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyings: NoUnderlyings option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegs: NoLegs option // group
    InstrumentLeg: InstrumentLeg option // component
    }

type NoQuoteSetsGrp = {
    QuoteSetID: QuoteSetID
    UnderlyingInstrument: UnderlyingInstrument option // component
    QuoteSetValidUntilTime: QuoteSetValidUntilTime option
    TotNoQuoteEntries: TotNoQuoteEntries
    LastFragment: LastFragment option
    NoQuoteEntries: NoQuoteEntries // group
    QuoteEntryID: QuoteEntryID
    Instrument: Instrument option // component
    NoLegs: NoLegs option // group
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

type NoPartySubIDsGrp = {
    PartySubID: PartySubID option
    PartySubIDType: PartySubIDType option
    }

type NoPartyIDsGrp = {
    PartyID: PartyID option
    PartyIDSource: PartyIDSource option
    PartyRole: PartyRole option
    NoPartySubIDs: NoPartySubIDs option // group
    PartySubID: PartySubID option
    PartySubIDType: PartySubIDType option
    }

type NoNestedPartySubIDsGrp = {
    NestedPartySubID: NestedPartySubID option
    NestedPartySubIDType: NestedPartySubIDType option
    }

type NoNestedPartyIDsGrp = {
    NestedPartyID: NestedPartyID option
    NestedPartyIDSource: NestedPartyIDSource option
    NestedPartyRole: NestedPartyRole option
    NoNestedPartySubIDs: NoNestedPartySubIDs option // group
    NestedPartySubID: NestedPartySubID option
    NestedPartySubIDType: NestedPartySubIDType option
    }

type NoNested3PartySubIDsGrp = {
    Nested3PartySubID: Nested3PartySubID option
    Nested3PartySubIDType: Nested3PartySubIDType option
    }

type NoNested3PartyIDsGrp = {
    Nested3PartyID: Nested3PartyID option
    Nested3PartyIDSource: Nested3PartyIDSource option
    Nested3PartyRole: Nested3PartyRole option
    NoNested3PartySubIDs: NoNested3PartySubIDs option // group
    Nested3PartySubID: Nested3PartySubID option
    Nested3PartySubIDType: Nested3PartySubIDType option
    }

type NoNested2PartySubIDsGrp = {
    Nested2PartySubID: Nested2PartySubID option
    Nested2PartySubIDType: Nested2PartySubIDType option
    }

type NoNested2PartyIDsGrp = {
    Nested2PartyID: Nested2PartyID option
    Nested2PartyIDSource: Nested2PartyIDSource option
    Nested2PartyRole: Nested2PartyRole option
    NoNested2PartySubIDs: NoNested2PartySubIDs option // group
    Nested2PartySubID: Nested2PartySubID option
    Nested2PartySubIDType: Nested2PartySubIDType option
    }

type NoLegAllocsGrp = {
    LegAllocAccount: LegAllocAccount option
    LegIndividualAllocID: LegIndividualAllocID option
    NestedParties2: NestedParties2 option // component
    LegAllocQty: LegAllocQty option
    LegAllocAcctIDSource: LegAllocAcctIDSource option
    LegSettlCurrency: LegSettlCurrency option
    }

type NewOrderMultileg_NoLegs_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegStipulations: LegStipulations option // component
    NoLegAllocs: NoLegAllocs option // group
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
    }

type NoTradingSessionsGrp = {
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    }

type NewOrderList_NoOrders_NoOrdersGrp = {
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
    NoAllocs: NoAllocs option // group
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
    NoTradingSessions: NoTradingSessions option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    ProcessCode: ProcessCode option
    Instrument: Instrument // component
    NoUnderlyings: NoUnderlyings option // group
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
    EncodedTextLen: EncodedTextLen option
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

type MultilegOrderCancelReplaceRequest_NoLegs_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegStipulations: LegStipulations option // component
    NoLegAllocs: NoLegAllocs option // group
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
    }

type MassQuote_NoQuoteEntries_NoQuoteEntriesGrp = {
    QuoteEntryID: QuoteEntryID
    Instrument: Instrument option // component
    NoLegs: NoLegs option // group
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

type MassQuoteAcknowledgement_NoQuoteSets_NoQuoteSetsGrp = {
    QuoteSetID: QuoteSetID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    TotNoQuoteEntries: TotNoQuoteEntries option
    LastFragment: LastFragment option
    NoQuoteEntries: NoQuoteEntries option // group
    QuoteEntryID: QuoteEntryID option
    Instrument: Instrument option // component
    NoLegs: NoLegs option // group
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

type MassQuoteAcknowledgement_NoQuoteEntries_NoQuoteEntriesGrp = {
    QuoteEntryID: QuoteEntryID option
    Instrument: Instrument option // component
    NoLegs: NoLegs option // group
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

type MarketDataRequest_NoRelatedSym_NoRelatedSymGrp = {
    Instrument: Instrument // component
    NoUnderlyings: NoUnderlyings option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegs: NoLegs option // group
    InstrumentLeg: InstrumentLeg option // component
    }

type MarketDataIncrementalRefresh_NoMDEntries_NoMDEntriesGrp = {
    MDUpdateAction: MDUpdateAction
    DeleteReason: DeleteReason option
    MDEntryType: MDEntryType option
    MDEntryID: MDEntryID option
    MDEntryRefID: MDEntryRefID option
    Instrument: Instrument option // component
    NoUnderlyings: NoUnderlyings option // group
    UnderlyingInstrument: UnderlyingInstrument option // component
    NoLegs: NoLegs option // group
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
    EncodedTextLen: EncodedTextLen option
    EncodedText: EncodedText option
    }

type DerivativeSecurityList_NoRelatedSym_NoRelatedSymGrp = {
    Instrument: Instrument option // component
    Currency: Currency option
    ExpirationCycle: ExpirationCycle option
    InstrumentExtension: InstrumentExtension option // component
    NoLegs: NoLegs option // group
    InstrumentLeg: InstrumentLeg option // component
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Text: Text option
    EncodedTextLen: EncodedTextLen option
    EncodedText: EncodedText option
    }

type CrossOrderCancelReplaceRequest_NoSides_NoSidesGrp = {
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
    NoAllocs: NoAllocs option // group
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
    EncodedTextLen: EncodedTextLen option
    EncodedText: EncodedText option
    PositionEffect: PositionEffect option
    CoveredOrUncovered: CoveredOrUncovered option
    CashMargin: CashMargin option
    ClearingFeeIndicator: ClearingFeeIndicator option
    SolicitedFlag: SolicitedFlag option
    SideComplianceID: SideComplianceID option
    }

type AllocationReport_NoAllocs_NoAllocsGrp = {
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
    EncodedAllocTextLen: EncodedAllocTextLen option
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
    NoMiscFees: NoMiscFees option // group
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
    NoClearingInstructions: NoClearingInstructions option // group
    ClearingInstruction: ClearingInstruction option
    ClearingFeeIndicator: ClearingFeeIndicator option
    AllocSettlInstType: AllocSettlInstType option
    SettlInstructionsData: SettlInstructionsData option // component
    }

type AllocationInstruction_NoAllocs_NoAllocsGrp = {
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
    EncodedAllocTextLen: EncodedAllocTextLen option
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
    NoMiscFees: NoMiscFees option // group
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

type Advertisement_NoUnderlyings_NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument // component
    }

type AllocationInstructionAck_NoAllocs_NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocPrice: AllocPrice option
    IndividualAllocID: IndividualAllocID option
    IndividualAllocRejCode: IndividualAllocRejCode option
    AllocText: AllocText option
    EncodedAllocTextLen: EncodedAllocTextLen option
    EncodedAllocText: EncodedAllocText option
    }

type AllocationInstruction_NoExecs_NoExecsGrp = {
    LastQty: LastQty option
    ExecID: ExecID option
    SecondaryExecID: SecondaryExecID option
    LastPx: LastPx option
    LastParPx: LastParPx option
    LastCapacity: LastCapacity option
    }

type AllocationReportAck_NoAllocs_NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocPrice: AllocPrice option
    IndividualAllocID: IndividualAllocID option
    IndividualAllocRejCode: IndividualAllocRejCode option
    AllocText: AllocText option
    EncodedAllocTextLen: EncodedAllocTextLen option
    EncodedAllocText: EncodedAllocText option
    }

type AllocationReport_NoExecs_NoExecsGrp = {
    LastQty: LastQty option
    ExecID: ExecID option
    SecondaryExecID: SecondaryExecID option
    LastPx: LastPx option
    LastParPx: LastParPx option
    LastCapacity: LastCapacity option
    }

type BidResponse_NoBidComponents_NoBidComponentsGrp = {
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
    EncodedTextLen: EncodedTextLen option
    EncodedText: EncodedText option
    }

type CollateralAssignment_NoUnderlyings_NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument option // component
    CollAction: CollAction option
    }

type CollateralRequest_NoUnderlyings_NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument option // component
    CollAction: CollAction option
    }

type CollateralResponse_NoUnderlyings_NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument option // component
    CollAction: CollAction option
    }

type Confirmation_NoLegs_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    }

type Confirmation_NoUnderlyings_NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

type CrossOrderCancelRequest_NoSides_NoSidesGrp = {
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
    EncodedTextLen: EncodedTextLen option
    EncodedText: EncodedText option
    }

type ExecutionReport_NoLegs_NoLegsGrp = {
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
    }

type IndicationOfInterest_NoLegs_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegIOIQty: LegIOIQty option
    LegStipulations: LegStipulations option // component
    }

type LinesOfTextGrp = {
    Text: Text
    EncodedTextLen: EncodedTextLen option
    EncodedText: EncodedText option
    }

type ListStatus_NoOrders_NoOrdersGrp = {
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
    EncodedTextLen: EncodedTextLen option
    EncodedText: EncodedText option
    }

type ListStrikePrice_NoUnderlyings_NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument option // component
    PrevClosePx: PrevClosePx option
    ClOrdID: ClOrdID option
    SecondaryClOrdID: SecondaryClOrdID option
    Side: Side option
    Price: Price
    Currency: Currency option
    Text: Text option
    EncodedTextLen: EncodedTextLen option
    EncodedText: EncodedText option
    }

type MultilegOrderCancelReplaceRequest_NoAllocs_NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties3: NestedParties3 option // component
    AllocQty: AllocQty option
    }

type NetworkStatusResponse_NoCompIDs_NoCompIDsGrp = {
    RefCompID: RefCompID option
    RefSubID: RefSubID option
    LocationID: LocationID option
    DeskID: DeskID option
    StatusValue: StatusValue option
    StatusText: StatusText option
    }

type NewOrderMultileg_NoAllocs_NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties3: NestedParties3 option // component
    AllocQty: AllocQty option
    }

type NoAffectedOrdersGrp = {
    OrigClOrdID: OrigClOrdID option
    AffectedOrderID: AffectedOrderID option
    AffectedSecondaryOrderID: AffectedSecondaryOrderID option
    }

type NoAltMDSourceGrp = {
    AltMDSourceID: AltMDSourceID option
    }

type NoBidComponentsGrp = {
    ListID: ListID option
    Side: Side option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    NetGrossInd: NetGrossInd option
    SettlType: SettlType option
    SettlDate: SettlDate option
    Account: Account option
    AcctIDSource: AcctIDSource option
    }

type NoBidDescriptorsGrp = {
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
    }

type NoCapacitiesGrp = {
    OrderCapacity: OrderCapacity
    OrderRestrictions: OrderRestrictions option
    OrderCapacityQty: OrderCapacityQty
    }

type NoCollInquiryQualifierGrp = {
    CollInquiryQualifier: CollInquiryQualifier option
    }

type NoCompIDsGrp = {
    RefCompID: RefCompID option
    RefSubID: RefSubID option
    LocationID: LocationID option
    DeskID: DeskID option
    }

type NoContraBrokersGrp = {
    ContraBroker: ContraBroker option
    ContraTrader: ContraTrader option
    ContraTradeQty: ContraTradeQty option
    ContraTradeTime: ContraTradeTime option
    ContraLegRefID: ContraLegRefID option
    }

type NoDatesGrp = {
    TradeDate: TradeDate option
    TransactTime: TransactTime option
    }

type NoDistribInstsGrp = {
    DistribPaymentMethod: DistribPaymentMethod option
    DistribPercentage: DistribPercentage option
    CashDistribCurr: CashDistribCurr option
    CashDistribAgentName: CashDistribAgentName option
    CashDistribAgentCode: CashDistribAgentCode option
    CashDistribAgentAcctNumber: CashDistribAgentAcctNumber option
    CashDistribPayRef: CashDistribPayRef option
    CashDistribAgentAcctName: CashDistribAgentAcctName option
    }

type NoDlvyInstGrp = {
    SettlInstSource: SettlInstSource option
    DlvyInstType: DlvyInstType option
    SettlParties: SettlParties option // component
    }

type NoEventsGrp = {
    EventType: EventType option
    EventDate: EventDate option
    EventPx: EventPx option
    EventText: EventText option
    }

type NoExecsGrp = {
    ExecID: ExecID option
    }

type NoIOIQualifiersGrp = {
    IOIQualifier: IOIQualifier option
    }

type NoInstrAttribGrp = {
    InstrAttribType: InstrAttribType option
    InstrAttribValue: InstrAttribValue option
    }

type NoLegSecurityAltIDGrp = {
    LegSecurityAltID: LegSecurityAltID option
    LegSecurityAltIDSource: LegSecurityAltIDSource option
    }

type NoLegStipulationsGrp = {
    LegStipulationType: LegStipulationType option
    LegStipulationValue: LegStipulationValue option
    }

type NoMDEntriesGrp = {
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
    EncodedTextLen: EncodedTextLen option
    EncodedText: EncodedText option
    }

type NoMDEntryTypesGrp = {
    MDEntryType: MDEntryType
    }

type NoMsgTypesGrp = {
    RefMsgType: RefMsgType option
    MsgDirection: MsgDirection option
    }

type NoOrdersGrp = {
    ClOrdID: ClOrdID option
    OrderID: OrderID option
    SecondaryOrderID: SecondaryOrderID option
    SecondaryClOrdID: SecondaryClOrdID option
    ListID: ListID option
    NestedParties2: NestedParties2 option // component
    OrderQty: OrderQty option
    OrderAvgPx: OrderAvgPx option
    OrderBookingQty: OrderBookingQty option
    }

type NoPosAmtGrp = {
    PosAmtType: PosAmtType
    PosAmt: PosAmt
    }

type NoPositionsGrp = {
    PosType: PosType option
    LongQty: LongQty option
    ShortQty: ShortQty option
    PosQtyStatus: PosQtyStatus option
    NestedParties: NestedParties option // component
    }

type NoRegistDtlsGrp = {
    RegistDtls: RegistDtls option
    RegistEmail: RegistEmail option
    MailingDtls: MailingDtls option
    MailingInst: MailingInst option
    NestedParties: NestedParties option // component
    OwnerType: OwnerType option
    DateOfBirth: DateOfBirth option
    InvestorCountryOfResidence: InvestorCountryOfResidence option
    }

type NoRelatedSymGrp = {
    Instrument: Instrument option // component
    }

type NoRoutingIDsGrp = {
    RoutingType: RoutingType option
    RoutingID: RoutingID option
    }

type NoSecurityAltIDGrp = {
    SecurityAltID: SecurityAltID option
    SecurityAltIDSource: SecurityAltIDSource option
    }

type NoSecurityTypesGrp = {
    SecurityType: SecurityType option
    SecuritySubType: SecuritySubType option
    Product: Product option
    CFICode: CFICode option
    }

type NoSettlInstGrp = {
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

type NoStipulationsGrp = {
    StipulationType: StipulationType option
    StipulationValue: StipulationValue option
    }

type NoStrikesGrp = {
    Instrument: Instrument // component
    }

type NoTradesGrp = {
    TradeReportID: TradeReportID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    }

type NoTrdRegTimestampsGrp = {
    TrdRegTimestamp: TrdRegTimestamp option
    TrdRegTimestampType: TrdRegTimestampType option
    TrdRegTimestampOrigin: TrdRegTimestampOrigin option
    }

type NoUnderlyingSecurityAltIDGrp = {
    UnderlyingSecurityAltID: UnderlyingSecurityAltID option
    UnderlyingSecurityAltIDSource: UnderlyingSecurityAltIDSource option
    }

type NoUnderlyingStipsGrp = {
    UnderlyingStipType: UnderlyingStipType option
    UnderlyingStipValue: UnderlyingStipValue option
    }

type PositionReport_NoUnderlyings_NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument option // component
    UnderlyingSettlPrice: UnderlyingSettlPrice
    UnderlyingSettlPriceType: UnderlyingSettlPriceType
    }

type QuoteRequestReject_NoLegs_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegStipulations: LegStipulations option // component
    NestedParties: NestedParties option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    }

type QuoteRequest_NoLegs_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegStipulations: LegStipulations option // component
    NestedParties: NestedParties option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    }

type QuoteResponse_NoLegs_NoLegsGrp = {
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
    }

type QuoteStatusReport_NoLegs_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegStipulations: LegStipulations option // component
    NestedParties: NestedParties option // component
    }

type Quote_NoLegs_NoLegsGrp = {
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
    }

type SecurityList_NoLegs_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    }

type TradeCaptureReportAck_NoAllocs_NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties2: NestedParties2 option // component
    AllocQty: AllocQty option
    }

type TradeCaptureReportAck_NoLegs_NoLegsGrp = {
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
    }

type TradeCaptureReport_NoAllocs_NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties2: NestedParties2 option // component
    AllocQty: AllocQty option
    }

type TradeCaptureReport_NoLegs_NoLegsGrp = {
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
    }



type FIXGroup =
    | Advertisement_NoUnderlyings_NoUnderlyingsGrp of Advertisement_NoUnderlyings_NoUnderlyingsGrp
    | AllocationInstructionAck_NoAllocs_NoAllocsGrp of AllocationInstructionAck_NoAllocs_NoAllocsGrp
    | AllocationInstruction_NoAllocs_NoAllocsGrp of AllocationInstruction_NoAllocs_NoAllocsGrp
    | AllocationInstruction_NoExecs_NoExecsGrp of AllocationInstruction_NoExecs_NoExecsGrp
    | AllocationReportAck_NoAllocs_NoAllocsGrp of AllocationReportAck_NoAllocs_NoAllocsGrp
    | AllocationReport_NoAllocs_NoAllocsGrp of AllocationReport_NoAllocs_NoAllocsGrp
    | AllocationReport_NoExecs_NoExecsGrp of AllocationReport_NoExecs_NoExecsGrp
    | BidResponse_NoBidComponents_NoBidComponentsGrp of BidResponse_NoBidComponents_NoBidComponentsGrp
    | CollateralAssignment_NoUnderlyings_NoUnderlyingsGrp of CollateralAssignment_NoUnderlyings_NoUnderlyingsGrp
    | CollateralRequest_NoUnderlyings_NoUnderlyingsGrp of CollateralRequest_NoUnderlyings_NoUnderlyingsGrp
    | CollateralResponse_NoUnderlyings_NoUnderlyingsGrp of CollateralResponse_NoUnderlyings_NoUnderlyingsGrp
    | Confirmation_NoLegs_NoLegsGrp of Confirmation_NoLegs_NoLegsGrp
    | Confirmation_NoUnderlyings_NoUnderlyingsGrp of Confirmation_NoUnderlyings_NoUnderlyingsGrp
    | CrossOrderCancelReplaceRequest_NoSides_NoSidesGrp of CrossOrderCancelReplaceRequest_NoSides_NoSidesGrp
    | CrossOrderCancelRequest_NoSides_NoSidesGrp of CrossOrderCancelRequest_NoSides_NoSidesGrp
    | DerivativeSecurityList_NoRelatedSym_NoRelatedSymGrp of DerivativeSecurityList_NoRelatedSym_NoRelatedSymGrp
    | ExecutionReport_NoLegs_NoLegsGrp of ExecutionReport_NoLegs_NoLegsGrp
    | IndicationOfInterest_NoLegs_NoLegsGrp of IndicationOfInterest_NoLegs_NoLegsGrp
    | LinesOfTextGrp of LinesOfTextGrp
    | ListStatus_NoOrders_NoOrdersGrp of ListStatus_NoOrders_NoOrdersGrp
    | ListStrikePrice_NoUnderlyings_NoUnderlyingsGrp of ListStrikePrice_NoUnderlyings_NoUnderlyingsGrp
    | MarketDataIncrementalRefresh_NoMDEntries_NoMDEntriesGrp of MarketDataIncrementalRefresh_NoMDEntries_NoMDEntriesGrp
    | MarketDataRequest_NoRelatedSym_NoRelatedSymGrp of MarketDataRequest_NoRelatedSym_NoRelatedSymGrp
    | MassQuoteAcknowledgement_NoQuoteEntries_NoQuoteEntriesGrp of MassQuoteAcknowledgement_NoQuoteEntries_NoQuoteEntriesGrp
    | MassQuoteAcknowledgement_NoQuoteSets_NoQuoteSetsGrp of MassQuoteAcknowledgement_NoQuoteSets_NoQuoteSetsGrp
    | MassQuote_NoQuoteEntries_NoQuoteEntriesGrp of MassQuote_NoQuoteEntries_NoQuoteEntriesGrp
    | MultilegOrderCancelReplaceRequest_NoAllocs_NoAllocsGrp of MultilegOrderCancelReplaceRequest_NoAllocs_NoAllocsGrp
    | MultilegOrderCancelReplaceRequest_NoLegs_NoLegsGrp of MultilegOrderCancelReplaceRequest_NoLegs_NoLegsGrp
    | NetworkStatusResponse_NoCompIDs_NoCompIDsGrp of NetworkStatusResponse_NoCompIDs_NoCompIDsGrp
    | NewOrderList_NoOrders_NoOrdersGrp of NewOrderList_NoOrders_NoOrdersGrp
    | NewOrderMultileg_NoAllocs_NoAllocsGrp of NewOrderMultileg_NoAllocs_NoAllocsGrp
    | NewOrderMultileg_NoLegs_NoLegsGrp of NewOrderMultileg_NoLegs_NoLegsGrp
    | NoAffectedOrdersGrp of NoAffectedOrdersGrp
    | NoAllocsGrp of NoAllocsGrp
    | NoAltMDSourceGrp of NoAltMDSourceGrp
    | NoBidComponentsGrp of NoBidComponentsGrp
    | NoBidDescriptorsGrp of NoBidDescriptorsGrp
    | NoCapacitiesGrp of NoCapacitiesGrp
    | NoClearingInstructionsGrp of NoClearingInstructionsGrp
    | NoCollInquiryQualifierGrp of NoCollInquiryQualifierGrp
    | NoCompIDsGrp of NoCompIDsGrp
    | NoContAmtsGrp of NoContAmtsGrp
    | NoContraBrokersGrp of NoContraBrokersGrp
    | NoDatesGrp of NoDatesGrp
    | NoDistribInstsGrp of NoDistribInstsGrp
    | NoDlvyInstGrp of NoDlvyInstGrp
    | NoEventsGrp of NoEventsGrp
    | NoExecsGrp of NoExecsGrp
    | NoIOIQualifiersGrp of NoIOIQualifiersGrp
    | NoInstrAttribGrp of NoInstrAttribGrp
    | NoLegAllocsGrp of NoLegAllocsGrp
    | NoLegSecurityAltIDGrp of NoLegSecurityAltIDGrp
    | NoLegStipulationsGrp of NoLegStipulationsGrp
    | NoLegsGrp of NoLegsGrp
    | NoMDEntriesGrp of NoMDEntriesGrp
    | NoMDEntryTypesGrp of NoMDEntryTypesGrp
    | NoMiscFeesGrp of NoMiscFeesGrp
    | NoMsgTypesGrp of NoMsgTypesGrp
    | NoNested2PartyIDsGrp of NoNested2PartyIDsGrp
    | NoNested2PartySubIDsGrp of NoNested2PartySubIDsGrp
    | NoNested3PartyIDsGrp of NoNested3PartyIDsGrp
    | NoNested3PartySubIDsGrp of NoNested3PartySubIDsGrp
    | NoNestedPartyIDsGrp of NoNestedPartyIDsGrp
    | NoNestedPartySubIDsGrp of NoNestedPartySubIDsGrp
    | NoOrdersGrp of NoOrdersGrp
    | NoPartyIDsGrp of NoPartyIDsGrp
    | NoPartySubIDsGrp of NoPartySubIDsGrp
    | NoPosAmtGrp of NoPosAmtGrp
    | NoPositionsGrp of NoPositionsGrp
    | NoQuoteEntriesGrp of NoQuoteEntriesGrp
    | NoQuoteQualifiersGrp of NoQuoteQualifiersGrp
    | NoQuoteSetsGrp of NoQuoteSetsGrp
    | NoRegistDtlsGrp of NoRegistDtlsGrp
    | NoRelatedSymGrp of NoRelatedSymGrp
    | NoRoutingIDsGrp of NoRoutingIDsGrp
    | NoSecurityAltIDGrp of NoSecurityAltIDGrp
    | NoSecurityTypesGrp of NoSecurityTypesGrp
    | NoSettlInstGrp of NoSettlInstGrp
    | NoSettlPartyIDsGrp of NoSettlPartyIDsGrp
    | NoSettlPartySubIDsGrp of NoSettlPartySubIDsGrp
    | NoSidesGrp of NoSidesGrp
    | NoStipulationsGrp of NoStipulationsGrp
    | NoStrikesGrp of NoStrikesGrp
    | NoTradesGrp of NoTradesGrp
    | NoTradingSessionsGrp of NoTradingSessionsGrp
    | NoTrdRegTimestampsGrp of NoTrdRegTimestampsGrp
    | NoUnderlyingSecurityAltIDGrp of NoUnderlyingSecurityAltIDGrp
    | NoUnderlyingStipsGrp of NoUnderlyingStipsGrp
    | NoUnderlyingsGrp of NoUnderlyingsGrp
    | PositionReport_NoUnderlyings_NoUnderlyingsGrp of PositionReport_NoUnderlyings_NoUnderlyingsGrp
    | QuoteRequestReject_NoLegs_NoLegsGrp of QuoteRequestReject_NoLegs_NoLegsGrp
    | QuoteRequestReject_NoRelatedSym_NoRelatedSymGrp of QuoteRequestReject_NoRelatedSym_NoRelatedSymGrp
    | QuoteRequest_NoLegs_NoLegsGrp of QuoteRequest_NoLegs_NoLegsGrp
    | QuoteRequest_NoRelatedSym_NoRelatedSymGrp of QuoteRequest_NoRelatedSym_NoRelatedSymGrp
    | QuoteResponse_NoLegs_NoLegsGrp of QuoteResponse_NoLegs_NoLegsGrp
    | QuoteStatusReport_NoLegs_NoLegsGrp of QuoteStatusReport_NoLegs_NoLegsGrp
    | Quote_NoLegs_NoLegsGrp of Quote_NoLegs_NoLegsGrp
    | RFQRequest_NoRelatedSym_NoRelatedSymGrp of RFQRequest_NoRelatedSym_NoRelatedSymGrp
    | SecurityList_NoLegs_NoLegsGrp of SecurityList_NoLegs_NoLegsGrp
    | SecurityList_NoRelatedSym_NoRelatedSymGrp of SecurityList_NoRelatedSym_NoRelatedSymGrp
    | TradeCaptureReportAck_NoAllocs_NoAllocsGrp of TradeCaptureReportAck_NoAllocs_NoAllocsGrp
    | TradeCaptureReportAck_NoLegs_NoLegsGrp of TradeCaptureReportAck_NoLegs_NoLegsGrp
    | TradeCaptureReport_NoAllocs_NoAllocsGrp of TradeCaptureReport_NoAllocs_NoAllocsGrp
    | TradeCaptureReport_NoLegs_NoLegsGrp of TradeCaptureReport_NoLegs_NoLegsGrp
    | TradeCaptureReport_NoSides_NoSidesGrp of TradeCaptureReport_NoSides_NoSidesGrp
