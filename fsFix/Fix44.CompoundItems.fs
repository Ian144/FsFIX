module Fix44.CompoundItems

open Fix44.Fields





// group
type NoUnderlyingSecurityAltIDGrp = {
    UnderlyingSecurityAltID: UnderlyingSecurityAltID option
    UnderlyingSecurityAltIDSource: UnderlyingSecurityAltIDSource option
    }

// group
type NoUnderlyingStipsGrp = {
    UnderlyingStipType: UnderlyingStipType option
    UnderlyingStipValue: UnderlyingStipValue option
    }

// component
type UnderlyingStipulations = {
    NoUnderlyingStipsGrp: NoUnderlyingStipsGrp option // group
    }

// component
type UnderlyingInstrument = {
    UnderlyingSymbol: UnderlyingSymbol
    UnderlyingSymbolSfx: UnderlyingSymbolSfx option
    UnderlyingSecurityID: UnderlyingSecurityID option
    UnderlyingSecurityIDSource: UnderlyingSecurityIDSource option
    NoUnderlyingSecurityAltIDGrp: NoUnderlyingSecurityAltIDGrp option // group
    UnderlyingProduct: UnderlyingProduct option
    UnderlyingCFICode: UnderlyingCFICode option
    UnderlyingSecurityType: UnderlyingSecurityType option
    UnderlyingSecuritySubType: UnderlyingSecuritySubType option
    UnderlyingMaturityMonthYear: UnderlyingMaturityMonthYear option
    UnderlyingMaturityDate: UnderlyingMaturityDate option
    UnderlyingPutOrCall: UnderlyingPutOrCall option
    UnderlyingCouponPaymentDate: UnderlyingCouponPaymentDate option
    UnderlyingIssueDate: UnderlyingIssueDate option
    UnderlyingRepoCollateralSecurityType: UnderlyingRepoCollateralSecurityType option
    UnderlyingRepurchaseTerm: UnderlyingRepurchaseTerm option
    UnderlyingRepurchaseRate: UnderlyingRepurchaseRate option
    UnderlyingFactor: UnderlyingFactor option
    UnderlyingCreditRating: UnderlyingCreditRating option
    UnderlyingInstrRegistry: UnderlyingInstrRegistry option
    UnderlyingCountryOfIssue: UnderlyingCountryOfIssue option
    UnderlyingStateOrProvinceOfIssue: UnderlyingStateOrProvinceOfIssue option
    UnderlyingLocaleOfIssue: UnderlyingLocaleOfIssue option
    UnderlyingRedemptionDate: UnderlyingRedemptionDate option
    UnderlyingStrikePrice: UnderlyingStrikePrice option
    UnderlyingStrikeCurrency: UnderlyingStrikeCurrency option
    UnderlyingOptAttribute: UnderlyingOptAttribute option
    UnderlyingContractMultiplier: UnderlyingContractMultiplier option
    UnderlyingCouponRate: UnderlyingCouponRate option
    UnderlyingSecurityExchange: UnderlyingSecurityExchange option
    UnderlyingIssuer: UnderlyingIssuer option
    EncodedUnderlyingIssuer: EncodedUnderlyingIssuer option
    UnderlyingSecurityDesc: UnderlyingSecurityDesc option
    EncodedUnderlyingSecurityDesc: EncodedUnderlyingSecurityDesc option
    UnderlyingCPProgram: UnderlyingCPProgram option
    UnderlyingCPRegType: UnderlyingCPRegType option
    UnderlyingCurrency: UnderlyingCurrency option
    UnderlyingQty: UnderlyingQty option
    UnderlyingPx: UnderlyingPx option
    UnderlyingDirtyPrice: UnderlyingDirtyPrice option
    UnderlyingEndPrice: UnderlyingEndPrice option
    UnderlyingStartValue: UnderlyingStartValue option
    UnderlyingCurrentValue: UnderlyingCurrentValue option
    UnderlyingEndValue: UnderlyingEndValue option
    UnderlyingStipulations: UnderlyingStipulations option // component
    }

// group
type CollateralResponse_NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument option // component
    CollAction: CollAction option
    }

// group
type CollateralAssignment_NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument option // component
    CollAction: CollAction option
    }

// group
type CollateralRequest_NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument option // component
    CollAction: CollAction option
    }

// group
type PositionReport_NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument option // component
    UnderlyingSettlPrice: UnderlyingSettlPrice
    UnderlyingSettlPriceType: UnderlyingSettlPriceType
    }

// group
type NoNestedPartySubIDsGrp = {
    NestedPartySubID: NestedPartySubID option
    NestedPartySubIDType: NestedPartySubIDType option
    }

// group
type NoNestedPartyIDsGrp = {
    NestedPartyID: NestedPartyID option
    NestedPartyIDSource: NestedPartyIDSource option
    NestedPartyRole: NestedPartyRole option
    NoNestedPartySubIDsGrp: NoNestedPartySubIDsGrp option // group
    }

// component
type NestedParties = {
    NoNestedPartyIDsGrp: NoNestedPartyIDsGrp option // group
    }

// group
type NoPositionsGrp = {
    PosType: PosType option
    LongQty: LongQty option
    ShortQty: ShortQty option
    PosQtyStatus: PosQtyStatus option
    NestedParties: NestedParties option // component
    }

// component
type PositionQty = {
    NoPositionsGrp: NoPositionsGrp // group
    }

// group
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

// group
type NoNested2PartySubIDsGrp = {
    Nested2PartySubID: Nested2PartySubID option
    Nested2PartySubIDType: Nested2PartySubIDType option
    }

// group
type NoNested2PartyIDsGrp = {
    Nested2PartyID: Nested2PartyID option
    Nested2PartyIDSource: Nested2PartyIDSource option
    Nested2PartyRole: Nested2PartyRole option
    NoNested2PartySubIDsGrp: NoNested2PartySubIDsGrp option // group
    }

// component
type NestedParties2 = {
    NoNested2PartyIDsGrp: NoNested2PartyIDsGrp option // group
    }

// group
type TradeCaptureReportAck_NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties2: NestedParties2 option // component
    AllocQty: AllocQty option
    }

// group
type NoLegSecurityAltIDGrp = {
    LegSecurityAltID: LegSecurityAltID option
    LegSecurityAltIDSource: LegSecurityAltIDSource option
    }

// component
type InstrumentLeg = {
    LegSymbol: LegSymbol option
    LegSymbolSfx: LegSymbolSfx option
    LegSecurityID: LegSecurityID option
    LegSecurityIDSource: LegSecurityIDSource option
    NoLegSecurityAltIDGrp: NoLegSecurityAltIDGrp option // group
    LegProduct: LegProduct option
    LegCFICode: LegCFICode option
    LegSecurityType: LegSecurityType option
    LegSecuritySubType: LegSecuritySubType option
    LegMaturityMonthYear: LegMaturityMonthYear option
    LegMaturityDate: LegMaturityDate option
    LegCouponPaymentDate: LegCouponPaymentDate option
    LegIssueDate: LegIssueDate option
    LegRepoCollateralSecurityType: LegRepoCollateralSecurityType option
    LegRepurchaseTerm: LegRepurchaseTerm option
    LegRepurchaseRate: LegRepurchaseRate option
    LegFactor: LegFactor option
    LegCreditRating: LegCreditRating option
    LegInstrRegistry: LegInstrRegistry option
    LegCountryOfIssue: LegCountryOfIssue option
    LegStateOrProvinceOfIssue: LegStateOrProvinceOfIssue option
    LegLocaleOfIssue: LegLocaleOfIssue option
    LegRedemptionDate: LegRedemptionDate option
    LegStrikePrice: LegStrikePrice option
    LegStrikeCurrency: LegStrikeCurrency option
    LegOptAttribute: LegOptAttribute option
    LegContractMultiplier: LegContractMultiplier option
    LegCouponRate: LegCouponRate option
    LegSecurityExchange: LegSecurityExchange option
    LegIssuer: LegIssuer option
    EncodedLegIssuer: EncodedLegIssuer option
    LegSecurityDesc: LegSecurityDesc option
    EncodedLegSecurityDesc: EncodedLegSecurityDesc option
    LegRatioQty: LegRatioQty option
    LegSide: LegSide option
    LegCurrency: LegCurrency option
    LegPool: LegPool option
    LegDatedDate: LegDatedDate option
    LegContractSettlMonth: LegContractSettlMonth option
    LegInterestAccrualDate: LegInterestAccrualDate option
    }

// group
type NoLegStipulationsGrp = {
    LegStipulationType: LegStipulationType option
    LegStipulationValue: LegStipulationValue option
    }

// component
type LegStipulations = {
    NoLegStipulationsGrp: NoLegStipulationsGrp option // group
    }

// group
type TradeCaptureReportAck_NoLegsGrp = {
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

// group
type NoPartySubIDsGrp = {
    PartySubID: PartySubID option
    PartySubIDType: PartySubIDType option
    }

// group
type NoPartyIDsGrp = {
    PartyID: PartyID option
    PartyIDSource: PartyIDSource option
    PartyRole: PartyRole option
    NoPartySubIDsGrp: NoPartySubIDsGrp option // group
    }

// component
type Parties = {
    NoPartyIDsGrp: NoPartyIDsGrp option // group
    }

// group
type NoClearingInstructionsGrp = {
    ClearingInstruction: ClearingInstruction option
    }

// component
type CommissionData = {
    Commission: Commission option
    CommType: CommType option
    CommCurrency: CommCurrency option
    FundRenewWaiv: FundRenewWaiv option
    }

// group
type NoContAmtsGrp = {
    ContAmtType: ContAmtType option
    ContAmtValue: ContAmtValue option
    ContAmtCurr: ContAmtCurr option
    }

// group
type NoStipulationsGrp = {
    StipulationType: StipulationType option
    StipulationValue: StipulationValue option
    }

// component
type Stipulations = {
    NoStipulationsGrp: NoStipulationsGrp option // group
    }

// group
type NoMiscFeesGrp = {
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
    }

// group
type TradeCaptureReport_NoSidesGrp = {
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
    Stipulations: Stipulations option // component
    NoMiscFeesGrp: NoMiscFeesGrp option // group
    ExchangeRule: ExchangeRule option
    TradeAllocIndicator: TradeAllocIndicator option
    PreallocMethod: PreallocMethod option
    AllocID: AllocID option
    }

// group
type TradeCaptureReport_NoLegsGrp = {
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

// group
type NoPosAmtGrp = {
    PosAmtType: PosAmtType
    PosAmt: PosAmt
    }

// component
type PositionAmountData = {
    NoPosAmtGrp: NoPosAmtGrp // group
    }

// group
type NoSettlPartySubIDsGrp = {
    SettlPartySubID: SettlPartySubID option
    SettlPartySubIDType: SettlPartySubIDType option
    }

// group
type NoSettlPartyIDsGrp = {
    SettlPartyID: SettlPartyID option
    SettlPartyIDSource: SettlPartyIDSource option
    SettlPartyRole: SettlPartyRole option
    NoSettlPartySubIDsGrp: NoSettlPartySubIDsGrp option // group
    }

// component
type SettlParties = {
    NoSettlPartyIDsGrp: NoSettlPartyIDsGrp option // group
    }

// group
type NoDlvyInstGrp = {
    SettlInstSource: SettlInstSource option
    DlvyInstType: DlvyInstType option
    SettlParties: SettlParties option // component
    }

// component
type SettlInstructionsData = {
    SettlDeliveryType: SettlDeliveryType option
    StandInstDbType: StandInstDbType option
    StandInstDbName: StandInstDbName option
    StandInstDbID: StandInstDbID option
    NoDlvyInstGrp: NoDlvyInstGrp option // group
    }

// group
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

// group
type NoTrdRegTimestampsGrp = {
    TrdRegTimestamp: TrdRegTimestamp option
    TrdRegTimestampType: TrdRegTimestampType option
    TrdRegTimestampOrigin: TrdRegTimestampOrigin option
    }

// component
type TrdRegTimestamps = {
    NoTrdRegTimestampsGrp: NoTrdRegTimestampsGrp // group
    }

// group
type AllocationReport_NoAllocsGrp = {
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
    NoClearingInstructionsGrp: NoClearingInstructionsGrp option // group
    ClearingFeeIndicator: ClearingFeeIndicator option
    AllocSettlInstType: AllocSettlInstType option
    SettlInstructionsData: SettlInstructionsData option // component
    }

// group
type AllocationInstruction_NoAllocsGrp = {
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
    NoClearingInstructions: NoClearingInstructions option
    ClearingInstruction: ClearingInstruction option
    ClearingFeeIndicator: ClearingFeeIndicator option
    AllocSettlInstType: AllocSettlInstType option
    SettlInstructionsData: SettlInstructionsData option // component
    }

// group
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

// group
type ListStrikePrice_NoUnderlyingsGrp = {
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

// group
type NoSecurityAltIDGrp = {
    SecurityAltID: SecurityAltID option
    SecurityAltIDSource: SecurityAltIDSource option
    }

// group
type NoEventsGrp = {
    EventType: EventType option
    EventDate: EventDate option
    EventPx: EventPx option
    EventText: EventText option
    }

// component
type Instrument = {
    Symbol: Symbol
    SymbolSfx: SymbolSfx option
    SecurityID: SecurityID option
    SecurityIDSource: SecurityIDSource option
    NoSecurityAltIDGrp: NoSecurityAltIDGrp option // group
    Product: Product option
    CFICode: CFICode option
    SecurityType: SecurityType option
    SecuritySubType: SecuritySubType option
    MaturityMonthYear: MaturityMonthYear option
    MaturityDate: MaturityDate option
    PutOrCall: PutOrCall option
    CouponPaymentDate: CouponPaymentDate option
    IssueDate: IssueDate option
    RepoCollateralSecurityType: RepoCollateralSecurityType option
    RepurchaseTerm: RepurchaseTerm option
    RepurchaseRate: RepurchaseRate option
    Factor: Factor option
    CreditRating: CreditRating option
    InstrRegistry: InstrRegistry option
    CountryOfIssue: CountryOfIssue option
    StateOrProvinceOfIssue: StateOrProvinceOfIssue option
    LocaleOfIssue: LocaleOfIssue option
    RedemptionDate: RedemptionDate option
    StrikePrice: StrikePrice option
    StrikeCurrency: StrikeCurrency option
    OptAttribute: OptAttribute option
    ContractMultiplier: ContractMultiplier option
    CouponRate: CouponRate option
    SecurityExchange: SecurityExchange option
    Issuer: Issuer option
    EncodedIssuer: EncodedIssuer option
    SecurityDesc: SecurityDesc option
    EncodedSecurityDesc: EncodedSecurityDesc option
    Pool: Pool option
    ContractSettlMonth: ContractSettlMonth option
    CPProgram: CPProgram option
    CPRegType: CPRegType option
    NoEventsGrp: NoEventsGrp option // group
    DatedDate: DatedDate option
    InterestAccrualDate: InterestAccrualDate option
    }

// group
type NoStrikesGrp = {
    Instrument: Instrument // component
    }

// group
type NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties: NestedParties option // component
    AllocQty: AllocQty option
    }

// group
type NoTradingSessionsGrp = {
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    }

// group
type NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

// component
type OrderQtyData = {
    OrderQty: OrderQty option
    CashOrderQty: CashOrderQty option
    OrderPercent: OrderPercent option
    RoundingDirection: RoundingDirection option
    RoundingModulus: RoundingModulus option
    }

// component
type SpreadOrBenchmarkCurveData = {
    Spread: Spread option
    BenchmarkCurveCurrency: BenchmarkCurveCurrency option
    BenchmarkCurveName: BenchmarkCurveName option
    BenchmarkCurvePoint: BenchmarkCurvePoint option
    BenchmarkPrice: BenchmarkPrice option
    BenchmarkPriceType: BenchmarkPriceType option
    BenchmarkSecurityID: BenchmarkSecurityID option
    BenchmarkSecurityIDSource: BenchmarkSecurityIDSource option
    }

// component
type YieldData = {
    YieldType: YieldType option
    Yield: Yield option
    YieldCalcDate: YieldCalcDate option
    YieldRedemptionDate: YieldRedemptionDate option
    YieldRedemptionPrice: YieldRedemptionPrice option
    YieldRedemptionPriceType: YieldRedemptionPriceType option
    }

// component
type PegInstructions = {
    PegOffsetValue: PegOffsetValue option
    PegMoveType: PegMoveType option
    PegOffsetType: PegOffsetType option
    PegLimitType: PegLimitType option
    PegRoundDirection: PegRoundDirection option
    PegScope: PegScope option
    }

// component
type DiscretionInstructions = {
    DiscretionInst: DiscretionInst option
    DiscretionOffsetValue: DiscretionOffsetValue option
    DiscretionMoveType: DiscretionMoveType option
    DiscretionOffsetType: DiscretionOffsetType option
    DiscretionLimitType: DiscretionLimitType option
    DiscretionRoundDirection: DiscretionRoundDirection option
    DiscretionScope: DiscretionScope option
    }

// group
type NewOrderList_NoOrdersGrp = {
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
    ProcessCode: ProcessCode option
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
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

// group
type BidResponse_NoBidComponentsGrp = {
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

// group
type NoLegAllocsGrp = {
    LegAllocAccount: LegAllocAccount option
    LegIndividualAllocID: LegIndividualAllocID option
    NestedParties2: NestedParties2 option // component
    LegAllocQty: LegAllocQty option
    LegAllocAcctIDSource: LegAllocAcctIDSource option
    LegSettlCurrency: LegSettlCurrency option
    }

// group
type MultilegOrderCancelReplaceRequest_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegStipulations: LegStipulations option // component
    NoLegAllocsGrp: NoLegAllocsGrp option // group
    LegPositionEffect: LegPositionEffect option
    LegCoveredOrUncovered: LegCoveredOrUncovered option
    NestedParties: NestedParties option // component
    LegRefID: LegRefID option
    LegPrice: LegPrice option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    }

// group
type NoNested3PartySubIDsGrp = {
    Nested3PartySubID: Nested3PartySubID option
    Nested3PartySubIDType: Nested3PartySubIDType option
    }

// group
type NoNested3PartyIDsGrp = {
    Nested3PartyID: Nested3PartyID option
    Nested3PartyIDSource: Nested3PartyIDSource option
    Nested3PartyRole: Nested3PartyRole option
    NoNested3PartySubIDsGrp: NoNested3PartySubIDsGrp option // group
    }

// component
type NestedParties3 = {
    NoNested3PartyIDsGrp: NoNested3PartyIDsGrp option // group
    }

// group
type MultilegOrderCancelReplaceRequest_NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties3: NestedParties3 option // component
    AllocQty: AllocQty option
    }

// group
type NewOrderMultileg_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegStipulations: LegStipulations option // component
    NoLegAllocsGrp: NoLegAllocsGrp option // group
    LegPositionEffect: LegPositionEffect option
    LegCoveredOrUncovered: LegCoveredOrUncovered option
    NestedParties: NestedParties option // component
    LegRefID: LegRefID option
    LegPrice: LegPrice option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    }

// group
type NewOrderMultileg_NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties3: NestedParties3 option // component
    AllocQty: AllocQty option
    }

// group
type CrossOrderCancelRequest_NoSidesGrp = {
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
    }

// group
type CrossOrderCancelReplaceRequest_NoSidesGrp = {
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
    }

// group
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
    NoAllocsGrp: NoAllocsGrp option // group
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
    }

// group
type ExecutionReport_NoLegsGrp = {
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

// group
type NoInstrAttribGrp = {
    InstrAttribType: InstrAttribType option
    InstrAttribValue: InstrAttribValue option
    }

// component
type InstrumentExtension = {
    DeliveryForm: DeliveryForm option
    PctAtRisk: PctAtRisk option
    NoInstrAttribGrp: NoInstrAttribGrp option // group
    }

// group
type NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    }

// group
type DerivativeSecurityList_NoRelatedSymGrp = {
    Instrument: Instrument option // component
    Currency: Currency option
    ExpirationCycle: ExpirationCycle option
    InstrumentExtension: InstrumentExtension option // component
    NoLegsGrp: NoLegsGrp option // group
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    Text: Text option
    EncodedText: EncodedText option
    }

// component
type FinancingDetails = {
    AgreementDesc: AgreementDesc option
    AgreementID: AgreementID option
    AgreementDate: AgreementDate option
    AgreementCurrency: AgreementCurrency option
    TerminationType: TerminationType option
    StartDate: StartDate option
    EndDate: EndDate option
    DeliveryType: DeliveryType option
    MarginRatio: MarginRatio option
    }

// component
type LegBenchmarkCurveData = {
    LegBenchmarkCurveCurrency: LegBenchmarkCurveCurrency option
    LegBenchmarkCurveName: LegBenchmarkCurveName option
    LegBenchmarkCurvePoint: LegBenchmarkCurvePoint option
    LegBenchmarkPrice: LegBenchmarkPrice option
    LegBenchmarkPriceType: LegBenchmarkPriceType option
    }

// group
type SecurityList_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegStipulations: LegStipulations option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    }

// group
type SecurityList_NoRelatedSymGrp = {
    Instrument: Instrument option // component
    InstrumentExtension: InstrumentExtension option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    Currency: Currency option
    Stipulations: Stipulations option // component
    SecurityList_NoLegsGrp: SecurityList_NoLegsGrp option // group
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

// group
type MarketDataIncrementalRefresh_NoMDEntriesGrp = {
    MDUpdateAction: MDUpdateAction
    DeleteReason: DeleteReason option
    MDEntryType: MDEntryType option
    MDEntryID: MDEntryID option
    MDEntryRefID: MDEntryRefID option
    Instrument: Instrument option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    NoLegsGrp: NoLegsGrp option // group
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
    }

// group
type MarketDataRequest_NoRelatedSymGrp = {
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    NoLegsGrp: NoLegsGrp option // group
    }

// group
type MassQuoteAcknowledgement_NoQuoteEntriesGrp = {
    QuoteEntryID: QuoteEntryID option
    Instrument: Instrument option // component
    NoLegsGrp: NoLegsGrp option // group
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

// group
type MassQuoteAcknowledgement_NoQuoteSetsGrp = {
    QuoteSetID: QuoteSetID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    TotNoQuoteEntries: TotNoQuoteEntries option
    LastFragment: LastFragment option
    MassQuoteAcknowledgement_NoQuoteEntriesGrp: MassQuoteAcknowledgement_NoQuoteEntriesGrp option // group
    }

// group
type MassQuote_NoQuoteEntriesGrp = {
    QuoteEntryID: QuoteEntryID
    Instrument: Instrument option // component
    NoLegsGrp: NoLegsGrp option // group
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

// group
type NoQuoteSetsGrp = {
    QuoteSetID: QuoteSetID
    UnderlyingInstrument: UnderlyingInstrument option // component
    QuoteSetValidUntilTime: QuoteSetValidUntilTime option
    TotNoQuoteEntries: TotNoQuoteEntries
    LastFragment: LastFragment option
    MassQuote_NoQuoteEntriesGrp: MassQuote_NoQuoteEntriesGrp // group
    }

// group
type QuoteStatusReport_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegStipulations: LegStipulations option // component
    NestedParties: NestedParties option // component
    }

// group
type NoQuoteEntriesGrp = {
    Instrument: Instrument option // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    NoLegsGrp: NoLegsGrp option // group
    }

// group
type Quote_NoLegsGrp = {
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

// group
type RFQRequest_NoRelatedSymGrp = {
    Instrument: Instrument // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
    NoLegsGrp: NoLegsGrp option // group
    PrevClosePx: PrevClosePx option
    QuoteRequestType: QuoteRequestType option
    QuoteType: QuoteType option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    }

// group
type QuoteRequestReject_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegStipulations: LegStipulations option // component
    NestedParties: NestedParties option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    }

// group
type QuoteRequestReject_NoRelatedSymGrp = {
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
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
    QuoteRequestReject_NoLegsGrp: QuoteRequestReject_NoLegsGrp option // group
    }

// group
type QuoteResponse_NoLegsGrp = {
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

// group
type QuoteRequest_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegQty: LegQty option
    LegSwapType: LegSwapType option
    LegSettlType: LegSettlType option
    LegSettlDate: LegSettlDate option
    LegStipulations: LegStipulations option // component
    NestedParties: NestedParties option // component
    LegBenchmarkCurveData: LegBenchmarkCurveData option // component
    }

// group
type NoQuoteQualifiersGrp = {
    QuoteQualifier: QuoteQualifier option
    }

// group
type QuoteRequest_NoRelatedSymGrp = {
    Instrument: Instrument // component
    FinancingDetails: FinancingDetails option // component
    NoUnderlyingsGrp: NoUnderlyingsGrp option // group
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
    QuoteRequest_NoLegsGrp: QuoteRequest_NoLegsGrp option // group
    NoQuoteQualifiersGrp: NoQuoteQualifiersGrp option // group
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

// group
type NoRelatedSymGrp = {
    Instrument: Instrument option // component
    }

// group
type IndicationOfInterest_NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    LegIOIQty: LegIOIQty option
    LegStipulations: LegStipulations option // component
    }

// group
type Advertisement_NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument // component
    }

// group
type NoMsgTypesGrp = {
    RefMsgType: RefMsgType option
    MsgDirection: MsgDirection option
    }

// group
type NoIOIQualifiersGrp = {
    IOIQualifier: IOIQualifier option
    }

// group
type NoRoutingIDsGrp = {
    RoutingType: RoutingType option
    RoutingID: RoutingID option
    }

// group
type LinesOfTextGrp = {
    Text: Text
    EncodedText: EncodedText option
    }

// group
type NoMDEntryTypesGrp = {
    MDEntryType: MDEntryType
    }

// group
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
    EncodedText: EncodedText option
    }

// group
type NoAltMDSourceGrp = {
    AltMDSourceID: AltMDSourceID option
    }

// group
type NoSecurityTypesGrp = {
    SecurityType: SecurityType option
    SecuritySubType: SecuritySubType option
    Product: Product option
    CFICode: CFICode option
    }

// group
type NoContraBrokersGrp = {
    ContraBroker: ContraBroker option
    ContraTrader: ContraTrader option
    ContraTradeQty: ContraTradeQty option
    ContraTradeTime: ContraTradeTime option
    ContraLegRefID: ContraLegRefID option
    }

// group
type NoAffectedOrdersGrp = {
    OrigClOrdID: OrigClOrdID option
    AffectedOrderID: AffectedOrderID option
    AffectedSecondaryOrderID: AffectedSecondaryOrderID option
    }

// group
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

// group
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

// group
type ListStatus_NoOrdersGrp = {
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

// group
type AllocationInstruction_NoExecsGrp = {
    LastQty: LastQty option
    ExecID: ExecID option
    SecondaryExecID: SecondaryExecID option
    LastPx: LastPx option
    LastParPx: LastParPx option
    LastCapacity: LastCapacity option
    }

// group
type AllocationInstructionAck_NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocPrice: AllocPrice option
    IndividualAllocID: IndividualAllocID option
    IndividualAllocRejCode: IndividualAllocRejCode option
    AllocText: AllocText option
    EncodedAllocText: EncodedAllocText option
    }

// group
type AllocationReport_NoExecsGrp = {
    LastQty: LastQty option
    ExecID: ExecID option
    SecondaryExecID: SecondaryExecID option
    LastPx: LastPx option
    LastParPx: LastParPx option
    LastCapacity: LastCapacity option
    }

// group
type AllocationReportAck_NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocPrice: AllocPrice option
    IndividualAllocID: IndividualAllocID option
    IndividualAllocRejCode: IndividualAllocRejCode option
    AllocText: AllocText option
    EncodedAllocText: EncodedAllocText option
    }

// group
type NoCapacitiesGrp = {
    OrderCapacity: OrderCapacity
    OrderRestrictions: OrderRestrictions option
    OrderCapacityQty: OrderCapacityQty
    }

// group
type NoDatesGrp = {
    TradeDate: TradeDate option
    TransactTime: TransactTime option
    }

// group
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

// group
type NoExecsGrp = {
    ExecID: ExecID option
    }

// group
type NoTradesGrp = {
    TradeReportID: TradeReportID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    }

// group
type NoCollInquiryQualifierGrp = {
    CollInquiryQualifier: CollInquiryQualifier option
    }

// group
type NoCompIDsGrp = {
    RefCompID: RefCompID option
    RefSubID: RefSubID option
    LocationID: LocationID option
    DeskID: DeskID option
    }

// group
type NetworkStatusResponse_NoCompIDsGrp = {
    RefCompID: RefCompID option
    RefSubID: RefSubID option
    LocationID: LocationID option
    DeskID: DeskID option
    StatusValue: StatusValue option
    StatusText: StatusText option
    }
