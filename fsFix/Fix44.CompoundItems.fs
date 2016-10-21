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
    NoUnderlyingStipsGrp: NoUnderlyingStipsGrp list option // group
    }

// component
type UnderlyingInstrument = {
    UnderlyingSymbol: UnderlyingSymbol
    UnderlyingSymbolSfx: UnderlyingSymbolSfx option
    UnderlyingSecurityID: UnderlyingSecurityID option
    UnderlyingSecurityIDSource: UnderlyingSecurityIDSource option
    NoUnderlyingSecurityAltIDGrp: NoUnderlyingSecurityAltIDGrp list option // group
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
    UnderlyingInstrument: UnderlyingInstrument // component
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
    NoLegSecurityAltIDGrp: NoLegSecurityAltIDGrp list option // group
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
type NoLegsGrp = {
    InstrumentLeg: InstrumentLeg option // component
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
    NoSecurityAltIDGrp: NoSecurityAltIDGrp list option // group
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
    NoEventsGrp: NoEventsGrp list option // group
    DatedDate: DatedDate option
    InterestAccrualDate: InterestAccrualDate option
    }

// group
type NoMsgTypesGrp = {
    RefMsgType: RefMsgType option
    MsgDirection: MsgDirection option
    }

// group
type NoHopsGrp = {
    HopCompID: HopCompID option
    HopSendingTime: HopSendingTime option
    HopRefID: HopRefID option
    }


type FIXGroup =
    | NoEventsGrp of NoEventsGrp
    | NoHopsGrp of NoHopsGrp
    | NoLegSecurityAltIDGrp of NoLegSecurityAltIDGrp
    | NoLegsGrp of NoLegsGrp
    | NoMsgTypesGrp of NoMsgTypesGrp
    | NoSecurityAltIDGrp of NoSecurityAltIDGrp
    | NoUnderlyingSecurityAltIDGrp of NoUnderlyingSecurityAltIDGrp
    | NoUnderlyingStipsGrp of NoUnderlyingStipsGrp
    | NoUnderlyingsGrp of NoUnderlyingsGrp
