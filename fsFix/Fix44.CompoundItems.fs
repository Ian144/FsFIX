module Fix44.CompoundItems

open Fix44.Fields





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
    NestedPartySubID: NestedPartySubID option
    NestedPartySubIDType: NestedPartySubIDType option
    }

    // component
type NestedParties = {
    NoNestedPartyIDsGrp: NoNestedPartyIDsGrp option // group
    NestedPartyID: NestedPartyID option
    NestedPartyIDSource: NestedPartyIDSource option
    NestedPartyRole: NestedPartyRole option
    NoNestedPartySubIDsGrp: NoNestedPartySubIDsGrp option // group
    NestedPartySubID: NestedPartySubID option
    NestedPartySubIDType: NestedPartySubIDType option
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
    PosType: PosType option
    LongQty: LongQty option
    ShortQty: ShortQty option
    PosQtyStatus: PosQtyStatus option
    NestedParties: NestedParties option // component
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
type NoPosAmtGrp = {
    PosAmtType: PosAmtType
    PosAmt: PosAmt
    }

    // component
type PositionAmountData = {
    NoPosAmtGrp: NoPosAmtGrp // group
    PosAmtType: PosAmtType
    PosAmt: PosAmt
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
    PartySubID: PartySubID option
    PartySubIDType: PartySubIDType option
    }

    // component
type Parties = {
    NoPartyIDsGrp: NoPartyIDsGrp option // group
    PartyID: PartyID option
    PartyIDSource: PartyIDSource option
    PartyRole: PartyRole option
    NoPartySubIDsGrp: NoPartySubIDsGrp option // group
    PartySubID: PartySubID option
    PartySubIDType: PartySubIDType option
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
    SettlPartySubID: SettlPartySubID option
    SettlPartySubIDType: SettlPartySubIDType option
    }

    // component
type SettlParties = {
    NoSettlPartyIDsGrp: NoSettlPartyIDsGrp option // group
    SettlPartyID: SettlPartyID option
    SettlPartyIDSource: SettlPartyIDSource option
    SettlPartyRole: SettlPartyRole option
    NoSettlPartySubIDsGrp: NoSettlPartySubIDsGrp option // group
    SettlPartySubID: SettlPartySubID option
    SettlPartySubIDType: SettlPartySubIDType option
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
    SettlInstSource: SettlInstSource option
    DlvyInstType: DlvyInstType option
    SettlParties: SettlParties option // component
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
    TrdRegTimestamp: TrdRegTimestamp option
    TrdRegTimestampType: TrdRegTimestampType option
    TrdRegTimestampOrigin: TrdRegTimestampOrigin option
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
    SecurityAltID: SecurityAltID option
    SecurityAltIDSource: SecurityAltIDSource option
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
    EventType: EventType option
    EventDate: EventDate option
    EventPx: EventPx option
    EventText: EventText option
    DatedDate: DatedDate option
    InterestAccrualDate: InterestAccrualDate option
    }

    // group
type NoStrikesGrp = {
    Instrument: Instrument // component
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
    Nested3PartySubID: Nested3PartySubID option
    Nested3PartySubIDType: Nested3PartySubIDType option
    }

    // component
type NestedParties3 = {
    NoNested3PartyIDsGrp: NoNested3PartyIDsGrp option // group
    Nested3PartyID: Nested3PartyID option
    Nested3PartyIDSource: Nested3PartyIDSource option
    Nested3PartyRole: Nested3PartyRole option
    NoNested3PartySubIDsGrp: NoNested3PartySubIDsGrp option // group
    Nested3PartySubID: Nested3PartySubID option
    Nested3PartySubIDType: Nested3PartySubIDType option
    }

    // component
type CommissionData = {
    Commission: Commission option
    CommType: CommType option
    CommCurrency: CommCurrency option
    FundRenewWaiv: FundRenewWaiv option
    }

    // group
type NoMiscFeesGrp = {
    MiscFeeAmt: MiscFeeAmt option
    MiscFeeCurr: MiscFeeCurr option
    MiscFeeType: MiscFeeType option
    MiscFeeBasis: MiscFeeBasis option
    }

    // group
type NoClearingInstructionsGrp = {
    ClearingInstruction: ClearingInstruction option
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
    Nested2PartySubID: Nested2PartySubID option
    Nested2PartySubIDType: Nested2PartySubIDType option
    }

    // component
type NestedParties2 = {
    NoNested2PartyIDsGrp: NoNested2PartyIDsGrp option // group
    Nested2PartyID: Nested2PartyID option
    Nested2PartyIDSource: Nested2PartyIDSource option
    Nested2PartyRole: Nested2PartyRole option
    NoNested2PartySubIDsGrp: NoNested2PartySubIDsGrp option // group
    Nested2PartySubID: Nested2PartySubID option
    Nested2PartySubIDType: Nested2PartySubIDType option
    }

    // group
type NoAllocsGrp = {
    AllocAccount: AllocAccount option
    AllocAcctIDSource: AllocAcctIDSource option
    AllocSettlCurrency: AllocSettlCurrency option
    IndividualAllocID: IndividualAllocID option
    NestedParties2: NestedParties2 option // component
    AllocQty: AllocQty option
    }

    // group
type NoTradingSessionsGrp = {
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    }

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
    UnderlyingStipType: UnderlyingStipType option
    UnderlyingStipValue: UnderlyingStipValue option
    }

    // component
type UnderlyingInstrument = {
    UnderlyingSymbol: UnderlyingSymbol
    UnderlyingSymbolSfx: UnderlyingSymbolSfx option
    UnderlyingSecurityID: UnderlyingSecurityID option
    UnderlyingSecurityIDSource: UnderlyingSecurityIDSource option
    NoUnderlyingSecurityAltIDGrp: NoUnderlyingSecurityAltIDGrp option // group
    UnderlyingSecurityAltID: UnderlyingSecurityAltID option
    UnderlyingSecurityAltIDSource: UnderlyingSecurityAltIDSource option
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
type NoUnderlyingsGrp = {
    UnderlyingInstrument: UnderlyingInstrument option // component
    }

    // group
type NoStipulationsGrp = {
    StipulationType: StipulationType option
    StipulationValue: StipulationValue option
    }

    // component
type Stipulations = {
    NoStipulationsGrp: NoStipulationsGrp option // group
    StipulationType: StipulationType option
    StipulationValue: StipulationValue option
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
type NoBidComponentsGrp = {
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
type NoContAmtsGrp = {
    ContAmtType: ContAmtType option
    ContAmtValue: ContAmtValue option
    ContAmtCurr: ContAmtCurr option
    }

    // group
type NoSidesGrp = {
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
    NoAllocsGrp: NoAllocsGrp option // group
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
    LegSecurityAltID: LegSecurityAltID option
    LegSecurityAltIDSource: LegSecurityAltIDSource option
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
    LegStipulationType: LegStipulationType option
    LegStipulationValue: LegStipulationValue option
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
type NoLegAllocsGrp = {
    LegAllocAccount: LegAllocAccount option
    LegIndividualAllocID: LegIndividualAllocID option
    NestedParties2: NestedParties2 option // component
    LegAllocQty: LegAllocQty option
    LegAllocAcctIDSource: LegAllocAcctIDSource option
    LegSettlCurrency: LegSettlCurrency option
    }

    // group
type NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
    }

    // group
type NoMDEntriesGrp = {
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

    // group
type NoQuoteEntriesGrp = {
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

    // group
type NoQuoteSetsGrp = {
    QuoteSetID: QuoteSetID option
    UnderlyingInstrument: UnderlyingInstrument option // component
    TotNoQuoteEntries: TotNoQuoteEntries option
    LastFragment: LastFragment option
    NoQuoteEntriesGrp: NoQuoteEntriesGrp option // group
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

    // group
type NoQuoteQualifiersGrp = {
    QuoteQualifier: QuoteQualifier option
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
    InstrAttribType: InstrAttribType option
    InstrAttribValue: InstrAttribValue option
    }

    // group
type NoRelatedSymGrp = {
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
type NoExecsGrp = {
    LastQty: LastQty option
    ExecID: ExecID option
    SecondaryExecID: SecondaryExecID option
    LastPx: LastPx option
    LastParPx: LastParPx option
    LastCapacity: LastCapacity option
    }

    // group
type NoExecsGrp = {
    LastQty: LastQty option
    ExecID: ExecID option
    SecondaryExecID: SecondaryExecID option
    LastPx: LastPx option
    LastParPx: LastParPx option
    LastCapacity: LastCapacity option
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
type NoExecsGrp = {
    ExecID: ExecID option
    }

    // group
type NoTradesGrp = {
    TradeReportID: TradeReportID option
    SecondaryTradeReportID: SecondaryTradeReportID option
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
type NoExecsGrp = {
    ExecID: ExecID option
    }

    // group
type NoTradesGrp = {
    TradeReportID: TradeReportID option
    SecondaryTradeReportID: SecondaryTradeReportID option
    }

    // group
type NoCompIDsGrp = {
    RefCompID: RefCompID option
    RefSubID: RefSubID option
    LocationID: LocationID option
    DeskID: DeskID option
    }

    // group
type NoCompIDsGrp = {
    RefCompID: RefCompID option
    RefSubID: RefSubID option
    LocationID: LocationID option
    DeskID: DeskID option
    StatusValue: StatusValue option
    StatusText: StatusText option
    }

    // group
type NoCollInquiryQualifierGrp = {
    CollInquiryQualifier: CollInquiryQualifier option
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
