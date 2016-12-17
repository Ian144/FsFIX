module Fix44.FieldDU


open Fix44.Fields
open Fix44.FieldReadFuncs
open Fix44.FieldWriteFuncs


type FIXField =
    | Account of Account
    | AdvId of AdvId
    | AdvRefID of AdvRefID
    | AdvSide of AdvSide
    | AdvTransType of AdvTransType
    | AvgPx of AvgPx
    | BeginSeqNo of BeginSeqNo
    | BeginString of BeginString
    | BodyLength of BodyLength
    | CheckSum of CheckSum
    | ClOrdID of ClOrdID
    | Commission of Commission
    | CommType of CommType
    | CumQty of CumQty
    | Currency of Currency
    | EndSeqNo of EndSeqNo
    | ExecID of ExecID
    | ExecInst of ExecInst
    | ExecRefID of ExecRefID
    | HandlInst of HandlInst
    | SecurityIDSource of SecurityIDSource
    | IOIid of IOIid
    | IOIQltyInd of IOIQltyInd
    | IOIRefID of IOIRefID
    | IOIQty of IOIQty
    | IOITransType of IOITransType
    | LastCapacity of LastCapacity
    | LastMkt of LastMkt
    | LastPx of LastPx
    | LastQty of LastQty
    | LinesOfText of LinesOfText
    | MsgSeqNum of MsgSeqNum
    | MsgType of MsgType
    | NewSeqNo of NewSeqNo
    | OrderID of OrderID
    | OrderQty of OrderQty
    | OrdStatus of OrdStatus
    | OrdType of OrdType
    | OrigClOrdID of OrigClOrdID
    | OrigTime of OrigTime
    | PossDupFlag of PossDupFlag
    | Price of Price
    | RefSeqNum of RefSeqNum
    | SecurityID of SecurityID
    | SenderCompID of SenderCompID
    | SenderSubID of SenderSubID
    | SendingTime of SendingTime
    | Quantity of Quantity
    | Side of Side
    | Symbol of Symbol
    | TargetCompID of TargetCompID
    | TargetSubID of TargetSubID
    | Text of Text
    | TimeInForce of TimeInForce
    | TransactTime of TransactTime
    | Urgency of Urgency
    | ValidUntilTime of ValidUntilTime
    | SettlType of SettlType
    | SettlDate of SettlDate
    | SymbolSfx of SymbolSfx
    | ListID of ListID
    | ListSeqNo of ListSeqNo
    | TotNoOrders of TotNoOrders
    | ListExecInst of ListExecInst
    | AllocID of AllocID
    | AllocTransType of AllocTransType
    | RefAllocID of RefAllocID
    | NoOrders of NoOrders
    | AvgPxPrecision of AvgPxPrecision
    | TradeDate of TradeDate
    | PositionEffect of PositionEffect
    | NoAllocs of NoAllocs
    | AllocAccount of AllocAccount
    | AllocQty of AllocQty
    | ProcessCode of ProcessCode
    | NoRpts of NoRpts
    | RptSeq of RptSeq
    | CxlQty of CxlQty
    | NoDlvyInst of NoDlvyInst
    | AllocStatus of AllocStatus
    | AllocRejCode of AllocRejCode
    | Signature of Signature
    | SecureData of SecureData
    | EmailType of EmailType
    | RawData of RawData
    | PossResend of PossResend
    | EncryptMethod of EncryptMethod
    | StopPx of StopPx
    | ExDestination of ExDestination
    | CxlRejReason of CxlRejReason
    | OrdRejReason of OrdRejReason
    | IOIQualifier of IOIQualifier
    | WaveNo of WaveNo
    | Issuer of Issuer
    | SecurityDesc of SecurityDesc
    | HeartBtInt of HeartBtInt
    | MinQty of MinQty
    | MaxFloor of MaxFloor
    | TestReqID of TestReqID
    | ReportToExch of ReportToExch
    | LocateReqd of LocateReqd
    | OnBehalfOfCompID of OnBehalfOfCompID
    | OnBehalfOfSubID of OnBehalfOfSubID
    | QuoteID of QuoteID
    | NetMoney of NetMoney
    | SettlCurrAmt of SettlCurrAmt
    | SettlCurrency of SettlCurrency
    | ForexReq of ForexReq
    | OrigSendingTime of OrigSendingTime
    | GapFillFlag of GapFillFlag
    | NoExecs of NoExecs
    | ExpireTime of ExpireTime
    | DKReason of DKReason
    | DeliverToCompID of DeliverToCompID
    | DeliverToSubID of DeliverToSubID
    | IOINaturalFlag of IOINaturalFlag
    | QuoteReqID of QuoteReqID
    | BidPx of BidPx
    | OfferPx of OfferPx
    | BidSize of BidSize
    | OfferSize of OfferSize
    | NoMiscFees of NoMiscFees
    | MiscFeeAmt of MiscFeeAmt
    | MiscFeeCurr of MiscFeeCurr
    | MiscFeeType of MiscFeeType
    | PrevClosePx of PrevClosePx
    | ResetSeqNumFlag of ResetSeqNumFlag
    | SenderLocationID of SenderLocationID
    | TargetLocationID of TargetLocationID
    | OnBehalfOfLocationID of OnBehalfOfLocationID
    | DeliverToLocationID of DeliverToLocationID
    | NoRelatedSym of NoRelatedSym
    | Subject of Subject
    | Headline of Headline
    | URLLink of URLLink
    | ExecType of ExecType
    | LeavesQty of LeavesQty
    | CashOrderQty of CashOrderQty
    | AllocAvgPx of AllocAvgPx
    | AllocNetMoney of AllocNetMoney
    | SettlCurrFxRate of SettlCurrFxRate
    | SettlCurrFxRateCalc of SettlCurrFxRateCalc
    | NumDaysInterest of NumDaysInterest
    | AccruedInterestRate of AccruedInterestRate
    | AccruedInterestAmt of AccruedInterestAmt
    | SettlInstMode of SettlInstMode
    | AllocText of AllocText
    | SettlInstID of SettlInstID
    | SettlInstTransType of SettlInstTransType
    | EmailThreadID of EmailThreadID
    | SettlInstSource of SettlInstSource
    | SecurityType of SecurityType
    | EffectiveTime of EffectiveTime
    | StandInstDbType of StandInstDbType
    | StandInstDbName of StandInstDbName
    | StandInstDbID of StandInstDbID
    | SettlDeliveryType of SettlDeliveryType
    | BidSpotRate of BidSpotRate
    | BidForwardPoints of BidForwardPoints
    | OfferSpotRate of OfferSpotRate
    | OfferForwardPoints of OfferForwardPoints
    | OrderQty2 of OrderQty2
    | SettlDate2 of SettlDate2
    | LastSpotRate of LastSpotRate
    | LastForwardPoints of LastForwardPoints
    | AllocLinkID of AllocLinkID
    | AllocLinkType of AllocLinkType
    | SecondaryOrderID of SecondaryOrderID
    | NoIOIQualifiers of NoIOIQualifiers
    | MaturityMonthYear of MaturityMonthYear
    | PutOrCall of PutOrCall
    | StrikePrice of StrikePrice
    | CoveredOrUncovered of CoveredOrUncovered
    | OptAttribute of OptAttribute
    | SecurityExchange of SecurityExchange
    | NotifyBrokerOfCredit of NotifyBrokerOfCredit
    | AllocHandlInst of AllocHandlInst
    | MaxShow of MaxShow
    | PegOffsetValue of PegOffsetValue
    | XmlData of XmlData
    | SettlInstRefID of SettlInstRefID
    | NoRoutingIDs of NoRoutingIDs
    | RoutingType of RoutingType
    | RoutingID of RoutingID
    | Spread of Spread
    | BenchmarkCurveCurrency of BenchmarkCurveCurrency
    | BenchmarkCurveName of BenchmarkCurveName
    | BenchmarkCurvePoint of BenchmarkCurvePoint
    | CouponRate of CouponRate
    | CouponPaymentDate of CouponPaymentDate
    | IssueDate of IssueDate
    | RepurchaseTerm of RepurchaseTerm
    | RepurchaseRate of RepurchaseRate
    | Factor of Factor
    | TradeOriginationDate of TradeOriginationDate
    | ExDate of ExDate
    | ContractMultiplier of ContractMultiplier
    | NoStipulations of NoStipulations
    | StipulationType of StipulationType
    | StipulationValue of StipulationValue
    | YieldType of YieldType
    | Yield of Yield
    | TotalTakedown of TotalTakedown
    | Concession of Concession
    | RepoCollateralSecurityType of RepoCollateralSecurityType
    | RedemptionDate of RedemptionDate
    | UnderlyingCouponPaymentDate of UnderlyingCouponPaymentDate
    | UnderlyingIssueDate of UnderlyingIssueDate
    | UnderlyingRepoCollateralSecurityType of UnderlyingRepoCollateralSecurityType
    | UnderlyingRepurchaseTerm of UnderlyingRepurchaseTerm
    | UnderlyingRepurchaseRate of UnderlyingRepurchaseRate
    | UnderlyingFactor of UnderlyingFactor
    | UnderlyingRedemptionDate of UnderlyingRedemptionDate
    | LegCouponPaymentDate of LegCouponPaymentDate
    | LegIssueDate of LegIssueDate
    | LegRepoCollateralSecurityType of LegRepoCollateralSecurityType
    | LegRepurchaseTerm of LegRepurchaseTerm
    | LegRepurchaseRate of LegRepurchaseRate
    | LegFactor of LegFactor
    | LegRedemptionDate of LegRedemptionDate
    | CreditRating of CreditRating
    | UnderlyingCreditRating of UnderlyingCreditRating
    | LegCreditRating of LegCreditRating
    | TradedFlatSwitch of TradedFlatSwitch
    | BasisFeatureDate of BasisFeatureDate
    | BasisFeaturePrice of BasisFeaturePrice
    | MDReqID of MDReqID
    | SubscriptionRequestType of SubscriptionRequestType
    | MarketDepth of MarketDepth
    | MDUpdateType of MDUpdateType
    | AggregatedBook of AggregatedBook
    | NoMDEntryTypes of NoMDEntryTypes
    | NoMDEntries of NoMDEntries
    | MDEntryType of MDEntryType
    | MDEntryPx of MDEntryPx
    | MDEntrySize of MDEntrySize
    | MDEntryDate of MDEntryDate
    | MDEntryTime of MDEntryTime
    | TickDirection of TickDirection
    | MDMkt of MDMkt
    | QuoteCondition of QuoteCondition
    | TradeCondition of TradeCondition
    | MDEntryID of MDEntryID
    | MDUpdateAction of MDUpdateAction
    | MDEntryRefID of MDEntryRefID
    | MDReqRejReason of MDReqRejReason
    | MDEntryOriginator of MDEntryOriginator
    | LocationID of LocationID
    | DeskID of DeskID
    | DeleteReason of DeleteReason
    | OpenCloseSettlFlag of OpenCloseSettlFlag
    | SellerDays of SellerDays
    | MDEntryBuyer of MDEntryBuyer
    | MDEntrySeller of MDEntrySeller
    | MDEntryPositionNo of MDEntryPositionNo
    | FinancialStatus of FinancialStatus
    | CorporateAction of CorporateAction
    | DefBidSize of DefBidSize
    | DefOfferSize of DefOfferSize
    | NoQuoteEntries of NoQuoteEntries
    | NoQuoteSets of NoQuoteSets
    | QuoteStatus of QuoteStatus
    | QuoteCancelType of QuoteCancelType
    | QuoteEntryID of QuoteEntryID
    | QuoteRejectReason of QuoteRejectReason
    | QuoteResponseLevel of QuoteResponseLevel
    | QuoteSetID of QuoteSetID
    | QuoteRequestType of QuoteRequestType
    | TotNoQuoteEntries of TotNoQuoteEntries
    | UnderlyingSecurityIDSource of UnderlyingSecurityIDSource
    | UnderlyingIssuer of UnderlyingIssuer
    | UnderlyingSecurityDesc of UnderlyingSecurityDesc
    | UnderlyingSecurityExchange of UnderlyingSecurityExchange
    | UnderlyingSecurityID of UnderlyingSecurityID
    | UnderlyingSecurityType of UnderlyingSecurityType
    | UnderlyingSymbol of UnderlyingSymbol
    | UnderlyingSymbolSfx of UnderlyingSymbolSfx
    | UnderlyingMaturityMonthYear of UnderlyingMaturityMonthYear
    | UnderlyingPutOrCall of UnderlyingPutOrCall
    | UnderlyingStrikePrice of UnderlyingStrikePrice
    | UnderlyingOptAttribute of UnderlyingOptAttribute
    | UnderlyingCurrency of UnderlyingCurrency
    | SecurityReqID of SecurityReqID
    | SecurityRequestType of SecurityRequestType
    | SecurityResponseID of SecurityResponseID
    | SecurityResponseType of SecurityResponseType
    | SecurityStatusReqID of SecurityStatusReqID
    | UnsolicitedIndicator of UnsolicitedIndicator
    | SecurityTradingStatus of SecurityTradingStatus
    | HaltReason of HaltReason
    | InViewOfCommon of InViewOfCommon
    | DueToRelated of DueToRelated
    | BuyVolume of BuyVolume
    | SellVolume of SellVolume
    | HighPx of HighPx
    | LowPx of LowPx
    | Adjustment of Adjustment
    | TradSesReqID of TradSesReqID
    | TradingSessionID of TradingSessionID
    | ContraTrader of ContraTrader
    | TradSesMethod of TradSesMethod
    | TradSesMode of TradSesMode
    | TradSesStatus of TradSesStatus
    | TradSesStartTime of TradSesStartTime
    | TradSesOpenTime of TradSesOpenTime
    | TradSesPreCloseTime of TradSesPreCloseTime
    | TradSesCloseTime of TradSesCloseTime
    | TradSesEndTime of TradSesEndTime
    | NumberOfOrders of NumberOfOrders
    | MessageEncoding of MessageEncoding
    | EncodedIssuer of EncodedIssuer
    | EncodedSecurityDesc of EncodedSecurityDesc
    | EncodedListExecInst of EncodedListExecInst
    | EncodedText of EncodedText
    | EncodedSubject of EncodedSubject
    | EncodedHeadline of EncodedHeadline
    | EncodedAllocText of EncodedAllocText
    | EncodedUnderlyingIssuer of EncodedUnderlyingIssuer
    | EncodedUnderlyingSecurityDesc of EncodedUnderlyingSecurityDesc
    | AllocPrice of AllocPrice
    | QuoteSetValidUntilTime of QuoteSetValidUntilTime
    | QuoteEntryRejectReason of QuoteEntryRejectReason
    | LastMsgSeqNumProcessed of LastMsgSeqNumProcessed
    | RefTagID of RefTagID
    | RefMsgType of RefMsgType
    | SessionRejectReason of SessionRejectReason
    | BidRequestTransType of BidRequestTransType
    | ContraBroker of ContraBroker
    | ComplianceID of ComplianceID
    | SolicitedFlag of SolicitedFlag
    | ExecRestatementReason of ExecRestatementReason
    | BusinessRejectRefID of BusinessRejectRefID
    | BusinessRejectReason of BusinessRejectReason
    | GrossTradeAmt of GrossTradeAmt
    | NoContraBrokers of NoContraBrokers
    | MaxMessageSize of MaxMessageSize
    | NoMsgTypes of NoMsgTypes
    | MsgDirection of MsgDirection
    | NoTradingSessions of NoTradingSessions
    | TotalVolumeTraded of TotalVolumeTraded
    | DiscretionInst of DiscretionInst
    | DiscretionOffsetValue of DiscretionOffsetValue
    | BidID of BidID
    | ClientBidID of ClientBidID
    | ListName of ListName
    | TotNoRelatedSym of TotNoRelatedSym
    | BidType of BidType
    | NumTickets of NumTickets
    | SideValue1 of SideValue1
    | SideValue2 of SideValue2
    | NoBidDescriptors of NoBidDescriptors
    | BidDescriptorType of BidDescriptorType
    | BidDescriptor of BidDescriptor
    | SideValueInd of SideValueInd
    | LiquidityPctLow of LiquidityPctLow
    | LiquidityPctHigh of LiquidityPctHigh
    | LiquidityValue of LiquidityValue
    | EFPTrackingError of EFPTrackingError
    | FairValue of FairValue
    | OutsideIndexPct of OutsideIndexPct
    | ValueOfFutures of ValueOfFutures
    | LiquidityIndType of LiquidityIndType
    | WtAverageLiquidity of WtAverageLiquidity
    | ExchangeForPhysical of ExchangeForPhysical
    | OutMainCntryUIndex of OutMainCntryUIndex
    | CrossPercent of CrossPercent
    | ProgRptReqs of ProgRptReqs
    | ProgPeriodInterval of ProgPeriodInterval
    | IncTaxInd of IncTaxInd
    | NumBidders of NumBidders
    | BidTradeType of BidTradeType
    | BasisPxType of BasisPxType
    | NoBidComponents of NoBidComponents
    | Country of Country
    | TotNoStrikes of TotNoStrikes
    | PriceType of PriceType
    | DayOrderQty of DayOrderQty
    | DayCumQty of DayCumQty
    | DayAvgPx of DayAvgPx
    | GTBookingInst of GTBookingInst
    | NoStrikes of NoStrikes
    | ListStatusType of ListStatusType
    | NetGrossInd of NetGrossInd
    | ListOrderStatus of ListOrderStatus
    | ExpireDate of ExpireDate
    | ListExecInstType of ListExecInstType
    | CxlRejResponseTo of CxlRejResponseTo
    | UnderlyingCouponRate of UnderlyingCouponRate
    | UnderlyingContractMultiplier of UnderlyingContractMultiplier
    | ContraTradeQty of ContraTradeQty
    | ContraTradeTime of ContraTradeTime
    | LiquidityNumSecurities of LiquidityNumSecurities
    | MultiLegReportingType of MultiLegReportingType
    | StrikeTime of StrikeTime
    | ListStatusText of ListStatusText
    | EncodedListStatusText of EncodedListStatusText
    | PartyIDSource of PartyIDSource
    | PartyID of PartyID
    | NetChgPrevDay of NetChgPrevDay
    | PartyRole of PartyRole
    | NoPartyIDs of NoPartyIDs
    | NoSecurityAltID of NoSecurityAltID
    | SecurityAltID of SecurityAltID
    | SecurityAltIDSource of SecurityAltIDSource
    | NoUnderlyingSecurityAltID of NoUnderlyingSecurityAltID
    | UnderlyingSecurityAltID of UnderlyingSecurityAltID
    | UnderlyingSecurityAltIDSource of UnderlyingSecurityAltIDSource
    | Product of Product
    | CFICode of CFICode
    | UnderlyingProduct of UnderlyingProduct
    | UnderlyingCFICode of UnderlyingCFICode
    | TestMessageIndicator of TestMessageIndicator
    | QuantityType of QuantityType
    | BookingRefID of BookingRefID
    | IndividualAllocID of IndividualAllocID
    | RoundingDirection of RoundingDirection
    | RoundingModulus of RoundingModulus
    | CountryOfIssue of CountryOfIssue
    | StateOrProvinceOfIssue of StateOrProvinceOfIssue
    | LocaleOfIssue of LocaleOfIssue
    | NoRegistDtls of NoRegistDtls
    | MailingDtls of MailingDtls
    | InvestorCountryOfResidence of InvestorCountryOfResidence
    | PaymentRef of PaymentRef
    | DistribPaymentMethod of DistribPaymentMethod
    | CashDistribCurr of CashDistribCurr
    | CommCurrency of CommCurrency
    | CancellationRights of CancellationRights
    | MoneyLaunderingStatus of MoneyLaunderingStatus
    | MailingInst of MailingInst
    | TransBkdTime of TransBkdTime
    | ExecPriceType of ExecPriceType
    | ExecPriceAdjustment of ExecPriceAdjustment
    | DateOfBirth of DateOfBirth
    | TradeReportTransType of TradeReportTransType
    | CardHolderName of CardHolderName
    | CardNumber of CardNumber
    | CardExpDate of CardExpDate
    | CardIssNum of CardIssNum
    | PaymentMethod of PaymentMethod
    | RegistAcctType of RegistAcctType
    | Designation of Designation
    | TaxAdvantageType of TaxAdvantageType
    | RegistRejReasonText of RegistRejReasonText
    | FundRenewWaiv of FundRenewWaiv
    | CashDistribAgentName of CashDistribAgentName
    | CashDistribAgentCode of CashDistribAgentCode
    | CashDistribAgentAcctNumber of CashDistribAgentAcctNumber
    | CashDistribPayRef of CashDistribPayRef
    | CashDistribAgentAcctName of CashDistribAgentAcctName
    | CardStartDate of CardStartDate
    | PaymentDate of PaymentDate
    | PaymentRemitterID of PaymentRemitterID
    | RegistStatus of RegistStatus
    | RegistRejReasonCode of RegistRejReasonCode
    | RegistRefID of RegistRefID
    | RegistDtls of RegistDtls
    | NoDistribInsts of NoDistribInsts
    | RegistEmail of RegistEmail
    | DistribPercentage of DistribPercentage
    | RegistID of RegistID
    | RegistTransType of RegistTransType
    | ExecValuationPoint of ExecValuationPoint
    | OrderPercent of OrderPercent
    | OwnershipType of OwnershipType
    | NoContAmts of NoContAmts
    | ContAmtType of ContAmtType
    | ContAmtValue of ContAmtValue
    | ContAmtCurr of ContAmtCurr
    | OwnerType of OwnerType
    | PartySubID of PartySubID
    | NestedPartyID of NestedPartyID
    | NestedPartyIDSource of NestedPartyIDSource
    | SecondaryClOrdID of SecondaryClOrdID
    | SecondaryExecID of SecondaryExecID
    | OrderCapacity of OrderCapacity
    | OrderRestrictions of OrderRestrictions
    | MassCancelRequestType of MassCancelRequestType
    | MassCancelResponse of MassCancelResponse
    | MassCancelRejectReason of MassCancelRejectReason
    | TotalAffectedOrders of TotalAffectedOrders
    | NoAffectedOrders of NoAffectedOrders
    | AffectedOrderID of AffectedOrderID
    | AffectedSecondaryOrderID of AffectedSecondaryOrderID
    | QuoteType of QuoteType
    | NestedPartyRole of NestedPartyRole
    | NoNestedPartyIDs of NoNestedPartyIDs
    | TotalAccruedInterestAmt of TotalAccruedInterestAmt
    | MaturityDate of MaturityDate
    | UnderlyingMaturityDate of UnderlyingMaturityDate
    | InstrRegistry of InstrRegistry
    | CashMargin of CashMargin
    | NestedPartySubID of NestedPartySubID
    | Scope of Scope
    | MDImplicitDelete of MDImplicitDelete
    | CrossID of CrossID
    | CrossType of CrossType
    | CrossPrioritization of CrossPrioritization
    | OrigCrossID of OrigCrossID
    | NoSides of NoSides
    | Username of Username
    | Password of Password
    | NoLegs of NoLegs
    | LegCurrency of LegCurrency
    | TotNoSecurityTypes of TotNoSecurityTypes
    | NoSecurityTypes of NoSecurityTypes
    | SecurityListRequestType of SecurityListRequestType
    | SecurityRequestResult of SecurityRequestResult
    | RoundLot of RoundLot
    | MinTradeVol of MinTradeVol
    | MultiLegRptTypeReq of MultiLegRptTypeReq
    | LegPositionEffect of LegPositionEffect
    | LegCoveredOrUncovered of LegCoveredOrUncovered
    | LegPrice of LegPrice
    | TradSesStatusRejReason of TradSesStatusRejReason
    | TradeRequestID of TradeRequestID
    | TradeRequestType of TradeRequestType
    | PreviouslyReported of PreviouslyReported
    | TradeReportID of TradeReportID
    | TradeReportRefID of TradeReportRefID
    | MatchStatus of MatchStatus
    | MatchType of MatchType
    | OddLot of OddLot
    | NoClearingInstructions of NoClearingInstructions
    | ClearingInstruction of ClearingInstruction
    | TradeInputSource of TradeInputSource
    | TradeInputDevice of TradeInputDevice
    | NoDates of NoDates
    | AccountType of AccountType
    | CustOrderCapacity of CustOrderCapacity
    | ClOrdLinkID of ClOrdLinkID
    | MassStatusReqID of MassStatusReqID
    | MassStatusReqType of MassStatusReqType
    | OrigOrdModTime of OrigOrdModTime
    | LegSettlType of LegSettlType
    | LegSettlDate of LegSettlDate
    | DayBookingInst of DayBookingInst
    | BookingUnit of BookingUnit
    | PreallocMethod of PreallocMethod
    | UnderlyingCountryOfIssue of UnderlyingCountryOfIssue
    | UnderlyingStateOrProvinceOfIssue of UnderlyingStateOrProvinceOfIssue
    | UnderlyingLocaleOfIssue of UnderlyingLocaleOfIssue
    | UnderlyingInstrRegistry of UnderlyingInstrRegistry
    | LegCountryOfIssue of LegCountryOfIssue
    | LegStateOrProvinceOfIssue of LegStateOrProvinceOfIssue
    | LegLocaleOfIssue of LegLocaleOfIssue
    | LegInstrRegistry of LegInstrRegistry
    | LegSymbol of LegSymbol
    | LegSymbolSfx of LegSymbolSfx
    | LegSecurityID of LegSecurityID
    | LegSecurityIDSource of LegSecurityIDSource
    | NoLegSecurityAltID of NoLegSecurityAltID
    | LegSecurityAltID of LegSecurityAltID
    | LegSecurityAltIDSource of LegSecurityAltIDSource
    | LegProduct of LegProduct
    | LegCFICode of LegCFICode
    | LegSecurityType of LegSecurityType
    | LegMaturityMonthYear of LegMaturityMonthYear
    | LegMaturityDate of LegMaturityDate
    | LegStrikePrice of LegStrikePrice
    | LegOptAttribute of LegOptAttribute
    | LegContractMultiplier of LegContractMultiplier
    | LegCouponRate of LegCouponRate
    | LegSecurityExchange of LegSecurityExchange
    | LegIssuer of LegIssuer
    | EncodedLegIssuer of EncodedLegIssuer
    | LegSecurityDesc of LegSecurityDesc
    | EncodedLegSecurityDesc of EncodedLegSecurityDesc
    | LegRatioQty of LegRatioQty
    | LegSide of LegSide
    | TradingSessionSubID of TradingSessionSubID
    | AllocType of AllocType
    | NoHops of NoHops
    | HopCompID of HopCompID
    | HopSendingTime of HopSendingTime
    | HopRefID of HopRefID
    | MidPx of MidPx
    | BidYield of BidYield
    | MidYield of MidYield
    | OfferYield of OfferYield
    | ClearingFeeIndicator of ClearingFeeIndicator
    | WorkingIndicator of WorkingIndicator
    | LegLastPx of LegLastPx
    | PriorityIndicator of PriorityIndicator
    | PriceImprovement of PriceImprovement
    | Price2 of Price2
    | LastForwardPoints2 of LastForwardPoints2
    | BidForwardPoints2 of BidForwardPoints2
    | OfferForwardPoints2 of OfferForwardPoints2
    | RFQReqID of RFQReqID
    | MktBidPx of MktBidPx
    | MktOfferPx of MktOfferPx
    | MinBidSize of MinBidSize
    | MinOfferSize of MinOfferSize
    | QuoteStatusReqID of QuoteStatusReqID
    | LegalConfirm of LegalConfirm
    | UnderlyingLastPx of UnderlyingLastPx
    | UnderlyingLastQty of UnderlyingLastQty
    | LegRefID of LegRefID
    | ContraLegRefID of ContraLegRefID
    | SettlCurrBidFxRate of SettlCurrBidFxRate
    | SettlCurrOfferFxRate of SettlCurrOfferFxRate
    | QuoteRequestRejectReason of QuoteRequestRejectReason
    | SideComplianceID of SideComplianceID
    | AcctIDSource of AcctIDSource
    | AllocAcctIDSource of AllocAcctIDSource
    | BenchmarkPrice of BenchmarkPrice
    | BenchmarkPriceType of BenchmarkPriceType
    | ConfirmID of ConfirmID
    | ConfirmStatus of ConfirmStatus
    | ConfirmTransType of ConfirmTransType
    | ContractSettlMonth of ContractSettlMonth
    | DeliveryForm of DeliveryForm
    | LastParPx of LastParPx
    | NoLegAllocs of NoLegAllocs
    | LegAllocAccount of LegAllocAccount
    | LegIndividualAllocID of LegIndividualAllocID
    | LegAllocQty of LegAllocQty
    | LegAllocAcctIDSource of LegAllocAcctIDSource
    | LegSettlCurrency of LegSettlCurrency
    | LegBenchmarkCurveCurrency of LegBenchmarkCurveCurrency
    | LegBenchmarkCurveName of LegBenchmarkCurveName
    | LegBenchmarkCurvePoint of LegBenchmarkCurvePoint
    | LegBenchmarkPrice of LegBenchmarkPrice
    | LegBenchmarkPriceType of LegBenchmarkPriceType
    | LegBidPx of LegBidPx
    | LegIOIQty of LegIOIQty
    | NoLegStipulations of NoLegStipulations
    | LegOfferPx of LegOfferPx
    | LegOrderQty of LegOrderQty
    | LegPriceType of LegPriceType
    | LegQty of LegQty
    | LegStipulationType of LegStipulationType
    | LegStipulationValue of LegStipulationValue
    | LegSwapType of LegSwapType
    | Pool of Pool
    | QuotePriceType of QuotePriceType
    | QuoteRespID of QuoteRespID
    | QuoteRespType of QuoteRespType
    | QuoteQualifier of QuoteQualifier
    | YieldRedemptionDate of YieldRedemptionDate
    | YieldRedemptionPrice of YieldRedemptionPrice
    | YieldRedemptionPriceType of YieldRedemptionPriceType
    | BenchmarkSecurityID of BenchmarkSecurityID
    | ReversalIndicator of ReversalIndicator
    | YieldCalcDate of YieldCalcDate
    | NoPositions of NoPositions
    | PosType of PosType
    | LongQty of LongQty
    | ShortQty of ShortQty
    | PosQtyStatus of PosQtyStatus
    | PosAmtType of PosAmtType
    | PosAmt of PosAmt
    | PosTransType of PosTransType
    | PosReqID of PosReqID
    | NoUnderlyings of NoUnderlyings
    | PosMaintAction of PosMaintAction
    | OrigPosReqRefID of OrigPosReqRefID
    | PosMaintRptRefID of PosMaintRptRefID
    | ClearingBusinessDate of ClearingBusinessDate
    | SettlSessID of SettlSessID
    | SettlSessSubID of SettlSessSubID
    | AdjustmentType of AdjustmentType
    | ContraryInstructionIndicator of ContraryInstructionIndicator
    | PriorSpreadIndicator of PriorSpreadIndicator
    | PosMaintRptID of PosMaintRptID
    | PosMaintStatus of PosMaintStatus
    | PosMaintResult of PosMaintResult
    | PosReqType of PosReqType
    | ResponseTransportType of ResponseTransportType
    | ResponseDestination of ResponseDestination
    | TotalNumPosReports of TotalNumPosReports
    | PosReqResult of PosReqResult
    | PosReqStatus of PosReqStatus
    | SettlPrice of SettlPrice
    | SettlPriceType of SettlPriceType
    | UnderlyingSettlPrice of UnderlyingSettlPrice
    | UnderlyingSettlPriceType of UnderlyingSettlPriceType
    | PriorSettlPrice of PriorSettlPrice
    | NoQuoteQualifiers of NoQuoteQualifiers
    | AllocSettlCurrency of AllocSettlCurrency
    | AllocSettlCurrAmt of AllocSettlCurrAmt
    | InterestAtMaturity of InterestAtMaturity
    | LegDatedDate of LegDatedDate
    | LegPool of LegPool
    | AllocInterestAtMaturity of AllocInterestAtMaturity
    | AllocAccruedInterestAmt of AllocAccruedInterestAmt
    | DeliveryDate of DeliveryDate
    | AssignmentMethod of AssignmentMethod
    | AssignmentUnit of AssignmentUnit
    | OpenInterest of OpenInterest
    | ExerciseMethod of ExerciseMethod
    | TotNumTradeReports of TotNumTradeReports
    | TradeRequestResult of TradeRequestResult
    | TradeRequestStatus of TradeRequestStatus
    | TradeReportRejectReason of TradeReportRejectReason
    | SideMultiLegReportingType of SideMultiLegReportingType
    | NoPosAmt of NoPosAmt
    | AutoAcceptIndicator of AutoAcceptIndicator
    | AllocReportID of AllocReportID
    | NoNested2PartyIDs of NoNested2PartyIDs
    | Nested2PartyID of Nested2PartyID
    | Nested2PartyIDSource of Nested2PartyIDSource
    | Nested2PartyRole of Nested2PartyRole
    | Nested2PartySubID of Nested2PartySubID
    | BenchmarkSecurityIDSource of BenchmarkSecurityIDSource
    | SecuritySubType of SecuritySubType
    | UnderlyingSecuritySubType of UnderlyingSecuritySubType
    | LegSecuritySubType of LegSecuritySubType
    | AllowableOneSidednessPct of AllowableOneSidednessPct
    | AllowableOneSidednessValue of AllowableOneSidednessValue
    | AllowableOneSidednessCurr of AllowableOneSidednessCurr
    | NoTrdRegTimestamps of NoTrdRegTimestamps
    | TrdRegTimestamp of TrdRegTimestamp
    | TrdRegTimestampType of TrdRegTimestampType
    | TrdRegTimestampOrigin of TrdRegTimestampOrigin
    | ConfirmRefID of ConfirmRefID
    | ConfirmType of ConfirmType
    | ConfirmRejReason of ConfirmRejReason
    | BookingType of BookingType
    | IndividualAllocRejCode of IndividualAllocRejCode
    | SettlInstMsgID of SettlInstMsgID
    | NoSettlInst of NoSettlInst
    | LastUpdateTime of LastUpdateTime
    | AllocSettlInstType of AllocSettlInstType
    | NoSettlPartyIDs of NoSettlPartyIDs
    | SettlPartyID of SettlPartyID
    | SettlPartyIDSource of SettlPartyIDSource
    | SettlPartyRole of SettlPartyRole
    | SettlPartySubID of SettlPartySubID
    | SettlPartySubIDType of SettlPartySubIDType
    | DlvyInstType of DlvyInstType
    | TerminationType of TerminationType
    | NextExpectedMsgSeqNum of NextExpectedMsgSeqNum
    | OrdStatusReqID of OrdStatusReqID
    | SettlInstReqID of SettlInstReqID
    | SettlInstReqRejCode of SettlInstReqRejCode
    | SecondaryAllocID of SecondaryAllocID
    | AllocReportType of AllocReportType
    | AllocReportRefID of AllocReportRefID
    | AllocCancReplaceReason of AllocCancReplaceReason
    | CopyMsgIndicator of CopyMsgIndicator
    | AllocAccountType of AllocAccountType
    | OrderAvgPx of OrderAvgPx
    | OrderBookingQty of OrderBookingQty
    | NoSettlPartySubIDs of NoSettlPartySubIDs
    | NoPartySubIDs of NoPartySubIDs
    | PartySubIDType of PartySubIDType
    | NoNestedPartySubIDs of NoNestedPartySubIDs
    | NestedPartySubIDType of NestedPartySubIDType
    | NoNested2PartySubIDs of NoNested2PartySubIDs
    | Nested2PartySubIDType of Nested2PartySubIDType
    | AllocIntermedReqType of AllocIntermedReqType
    | UnderlyingPx of UnderlyingPx
    | PriceDelta of PriceDelta
    | ApplQueueMax of ApplQueueMax
    | ApplQueueDepth of ApplQueueDepth
    | ApplQueueResolution of ApplQueueResolution
    | ApplQueueAction of ApplQueueAction
    | NoAltMDSource of NoAltMDSource
    | AltMDSourceID of AltMDSourceID
    | SecondaryTradeReportID of SecondaryTradeReportID
    | AvgPxIndicator of AvgPxIndicator
    | TradeLinkID of TradeLinkID
    | OrderInputDevice of OrderInputDevice
    | UnderlyingTradingSessionID of UnderlyingTradingSessionID
    | UnderlyingTradingSessionSubID of UnderlyingTradingSessionSubID
    | TradeLegRefID of TradeLegRefID
    | ExchangeRule of ExchangeRule
    | TradeAllocIndicator of TradeAllocIndicator
    | ExpirationCycle of ExpirationCycle
    | TrdType of TrdType
    | TrdSubType of TrdSubType
    | TransferReason of TransferReason
    | AsgnReqID of AsgnReqID
    | TotNumAssignmentReports of TotNumAssignmentReports
    | AsgnRptID of AsgnRptID
    | ThresholdAmount of ThresholdAmount
    | PegMoveType of PegMoveType
    | PegOffsetType of PegOffsetType
    | PegLimitType of PegLimitType
    | PegRoundDirection of PegRoundDirection
    | PeggedPrice of PeggedPrice
    | PegScope of PegScope
    | DiscretionMoveType of DiscretionMoveType
    | DiscretionOffsetType of DiscretionOffsetType
    | DiscretionLimitType of DiscretionLimitType
    | DiscretionRoundDirection of DiscretionRoundDirection
    | DiscretionPrice of DiscretionPrice
    | DiscretionScope of DiscretionScope
    | TargetStrategy of TargetStrategy
    | TargetStrategyParameters of TargetStrategyParameters
    | ParticipationRate of ParticipationRate
    | TargetStrategyPerformance of TargetStrategyPerformance
    | LastLiquidityInd of LastLiquidityInd
    | PublishTrdIndicator of PublishTrdIndicator
    | ShortSaleReason of ShortSaleReason
    | QtyType of QtyType
    | SecondaryTrdType of SecondaryTrdType
    | TradeReportType of TradeReportType
    | AllocNoOrdersType of AllocNoOrdersType
    | SharedCommission of SharedCommission
    | ConfirmReqID of ConfirmReqID
    | AvgParPx of AvgParPx
    | ReportedPx of ReportedPx
    | NoCapacities of NoCapacities
    | OrderCapacityQty of OrderCapacityQty
    | NoEvents of NoEvents
    | EventType of EventType
    | EventDate of EventDate
    | EventPx of EventPx
    | EventText of EventText
    | PctAtRisk of PctAtRisk
    | NoInstrAttrib of NoInstrAttrib
    | InstrAttribType of InstrAttribType
    | InstrAttribValue of InstrAttribValue
    | DatedDate of DatedDate
    | InterestAccrualDate of InterestAccrualDate
    | CPProgram of CPProgram
    | CPRegType of CPRegType
    | UnderlyingCPProgram of UnderlyingCPProgram
    | UnderlyingCPRegType of UnderlyingCPRegType
    | UnderlyingQty of UnderlyingQty
    | TrdMatchID of TrdMatchID
    | SecondaryTradeReportRefID of SecondaryTradeReportRefID
    | UnderlyingDirtyPrice of UnderlyingDirtyPrice
    | UnderlyingEndPrice of UnderlyingEndPrice
    | UnderlyingStartValue of UnderlyingStartValue
    | UnderlyingCurrentValue of UnderlyingCurrentValue
    | UnderlyingEndValue of UnderlyingEndValue
    | NoUnderlyingStips of NoUnderlyingStips
    | UnderlyingStipType of UnderlyingStipType
    | UnderlyingStipValue of UnderlyingStipValue
    | MaturityNetMoney of MaturityNetMoney
    | MiscFeeBasis of MiscFeeBasis
    | TotNoAllocs of TotNoAllocs
    | LastFragment of LastFragment
    | CollReqID of CollReqID
    | CollAsgnReason of CollAsgnReason
    | CollInquiryQualifier of CollInquiryQualifier
    | NoTrades of NoTrades
    | MarginRatio of MarginRatio
    | MarginExcess of MarginExcess
    | TotalNetValue of TotalNetValue
    | CashOutstanding of CashOutstanding
    | CollAsgnID of CollAsgnID
    | CollAsgnTransType of CollAsgnTransType
    | CollRespID of CollRespID
    | CollAsgnRespType of CollAsgnRespType
    | CollAsgnRejectReason of CollAsgnRejectReason
    | CollAsgnRefID of CollAsgnRefID
    | CollRptID of CollRptID
    | CollInquiryID of CollInquiryID
    | CollStatus of CollStatus
    | TotNumReports of TotNumReports
    | LastRptRequested of LastRptRequested
    | AgreementDesc of AgreementDesc
    | AgreementID of AgreementID
    | AgreementDate of AgreementDate
    | StartDate of StartDate
    | EndDate of EndDate
    | AgreementCurrency of AgreementCurrency
    | DeliveryType of DeliveryType
    | EndAccruedInterestAmt of EndAccruedInterestAmt
    | StartCash of StartCash
    | EndCash of EndCash
    | UserRequestID of UserRequestID
    | UserRequestType of UserRequestType
    | NewPassword of NewPassword
    | UserStatus of UserStatus
    | UserStatusText of UserStatusText
    | StatusValue of StatusValue
    | StatusText of StatusText
    | RefCompID of RefCompID
    | RefSubID of RefSubID
    | NetworkResponseID of NetworkResponseID
    | NetworkRequestID of NetworkRequestID
    | LastNetworkResponseID of LastNetworkResponseID
    | NetworkRequestType of NetworkRequestType
    | NoCompIDs of NoCompIDs
    | NetworkStatusResponseType of NetworkStatusResponseType
    | NoCollInquiryQualifier of NoCollInquiryQualifier
    | TrdRptStatus of TrdRptStatus
    | AffirmStatus of AffirmStatus
    | UnderlyingStrikeCurrency of UnderlyingStrikeCurrency
    | LegStrikeCurrency of LegStrikeCurrency
    | TimeBracket of TimeBracket
    | CollAction of CollAction
    | CollInquiryStatus of CollInquiryStatus
    | CollInquiryResult of CollInquiryResult
    | StrikeCurrency of StrikeCurrency
    | NoNested3PartyIDs of NoNested3PartyIDs
    | Nested3PartyID of Nested3PartyID
    | Nested3PartyIDSource of Nested3PartyIDSource
    | Nested3PartyRole of Nested3PartyRole
    | NoNested3PartySubIDs of NoNested3PartySubIDs
    | Nested3PartySubID of Nested3PartySubID
    | Nested3PartySubIDType of Nested3PartySubIDType
    | LegContractSettlMonth of LegContractSettlMonth
    | LegInterestAccrualDate of LegInterestAccrualDate


let WriteField dest nextFreeIdx fixField =
    match fixField with
    | Account fixField -> WriteAccount dest nextFreeIdx fixField
    | AdvId fixField -> WriteAdvId dest nextFreeIdx fixField
    | AdvRefID fixField -> WriteAdvRefID dest nextFreeIdx fixField
    | AdvSide fixField -> WriteAdvSide dest nextFreeIdx fixField
    | AdvTransType fixField -> WriteAdvTransType dest nextFreeIdx fixField
    | AvgPx fixField -> WriteAvgPx dest nextFreeIdx fixField
    | BeginSeqNo fixField -> WriteBeginSeqNo dest nextFreeIdx fixField
    | BeginString fixField -> WriteBeginString dest nextFreeIdx fixField
    | BodyLength fixField -> WriteBodyLength dest nextFreeIdx fixField
    | CheckSum fixField -> WriteCheckSum dest nextFreeIdx fixField
    | ClOrdID fixField -> WriteClOrdID dest nextFreeIdx fixField
    | Commission fixField -> WriteCommission dest nextFreeIdx fixField
    | CommType fixField -> WriteCommType dest nextFreeIdx fixField
    | CumQty fixField -> WriteCumQty dest nextFreeIdx fixField
    | Currency fixField -> WriteCurrency dest nextFreeIdx fixField
    | EndSeqNo fixField -> WriteEndSeqNo dest nextFreeIdx fixField
    | ExecID fixField -> WriteExecID dest nextFreeIdx fixField
    | ExecInst fixField -> WriteExecInst dest nextFreeIdx fixField
    | ExecRefID fixField -> WriteExecRefID dest nextFreeIdx fixField
    | HandlInst fixField -> WriteHandlInst dest nextFreeIdx fixField
    | SecurityIDSource fixField -> WriteSecurityIDSource dest nextFreeIdx fixField
    | IOIid fixField -> WriteIOIid dest nextFreeIdx fixField
    | IOIQltyInd fixField -> WriteIOIQltyInd dest nextFreeIdx fixField
    | IOIRefID fixField -> WriteIOIRefID dest nextFreeIdx fixField
    | IOIQty fixField -> WriteIOIQty dest nextFreeIdx fixField
    | IOITransType fixField -> WriteIOITransType dest nextFreeIdx fixField
    | LastCapacity fixField -> WriteLastCapacity dest nextFreeIdx fixField
    | LastMkt fixField -> WriteLastMkt dest nextFreeIdx fixField
    | LastPx fixField -> WriteLastPx dest nextFreeIdx fixField
    | LastQty fixField -> WriteLastQty dest nextFreeIdx fixField
    | LinesOfText fixField -> WriteLinesOfText dest nextFreeIdx fixField
    | MsgSeqNum fixField -> WriteMsgSeqNum dest nextFreeIdx fixField
    | MsgType fixField -> WriteMsgType dest nextFreeIdx fixField
    | NewSeqNo fixField -> WriteNewSeqNo dest nextFreeIdx fixField
    | OrderID fixField -> WriteOrderID dest nextFreeIdx fixField
    | OrderQty fixField -> WriteOrderQty dest nextFreeIdx fixField
    | OrdStatus fixField -> WriteOrdStatus dest nextFreeIdx fixField
    | OrdType fixField -> WriteOrdType dest nextFreeIdx fixField
    | OrigClOrdID fixField -> WriteOrigClOrdID dest nextFreeIdx fixField
    | OrigTime fixField -> WriteOrigTime dest nextFreeIdx fixField
    | PossDupFlag fixField -> WritePossDupFlag dest nextFreeIdx fixField
    | Price fixField -> WritePrice dest nextFreeIdx fixField
    | RefSeqNum fixField -> WriteRefSeqNum dest nextFreeIdx fixField
    | SecurityID fixField -> WriteSecurityID dest nextFreeIdx fixField
    | SenderCompID fixField -> WriteSenderCompID dest nextFreeIdx fixField
    | SenderSubID fixField -> WriteSenderSubID dest nextFreeIdx fixField
    | SendingTime fixField -> WriteSendingTime dest nextFreeIdx fixField
    | Quantity fixField -> WriteQuantity dest nextFreeIdx fixField
    | Side fixField -> WriteSide dest nextFreeIdx fixField
    | Symbol fixField -> WriteSymbol dest nextFreeIdx fixField
    | TargetCompID fixField -> WriteTargetCompID dest nextFreeIdx fixField
    | TargetSubID fixField -> WriteTargetSubID dest nextFreeIdx fixField
    | Text fixField -> WriteText dest nextFreeIdx fixField
    | TimeInForce fixField -> WriteTimeInForce dest nextFreeIdx fixField
    | TransactTime fixField -> WriteTransactTime dest nextFreeIdx fixField
    | Urgency fixField -> WriteUrgency dest nextFreeIdx fixField
    | ValidUntilTime fixField -> WriteValidUntilTime dest nextFreeIdx fixField
    | SettlType fixField -> WriteSettlType dest nextFreeIdx fixField
    | SettlDate fixField -> WriteSettlDate dest nextFreeIdx fixField
    | SymbolSfx fixField -> WriteSymbolSfx dest nextFreeIdx fixField
    | ListID fixField -> WriteListID dest nextFreeIdx fixField
    | ListSeqNo fixField -> WriteListSeqNo dest nextFreeIdx fixField
    | TotNoOrders fixField -> WriteTotNoOrders dest nextFreeIdx fixField
    | ListExecInst fixField -> WriteListExecInst dest nextFreeIdx fixField
    | AllocID fixField -> WriteAllocID dest nextFreeIdx fixField
    | AllocTransType fixField -> WriteAllocTransType dest nextFreeIdx fixField
    | RefAllocID fixField -> WriteRefAllocID dest nextFreeIdx fixField
    | NoOrders fixField -> WriteNoOrders dest nextFreeIdx fixField
    | AvgPxPrecision fixField -> WriteAvgPxPrecision dest nextFreeIdx fixField
    | TradeDate fixField -> WriteTradeDate dest nextFreeIdx fixField
    | PositionEffect fixField -> WritePositionEffect dest nextFreeIdx fixField
    | NoAllocs fixField -> WriteNoAllocs dest nextFreeIdx fixField
    | AllocAccount fixField -> WriteAllocAccount dest nextFreeIdx fixField
    | AllocQty fixField -> WriteAllocQty dest nextFreeIdx fixField
    | ProcessCode fixField -> WriteProcessCode dest nextFreeIdx fixField
    | NoRpts fixField -> WriteNoRpts dest nextFreeIdx fixField
    | RptSeq fixField -> WriteRptSeq dest nextFreeIdx fixField
    | CxlQty fixField -> WriteCxlQty dest nextFreeIdx fixField
    | NoDlvyInst fixField -> WriteNoDlvyInst dest nextFreeIdx fixField
    | AllocStatus fixField -> WriteAllocStatus dest nextFreeIdx fixField
    | AllocRejCode fixField -> WriteAllocRejCode dest nextFreeIdx fixField
    | Signature fixField -> WriteSignature dest nextFreeIdx fixField // compound field
    | SecureData fixField -> WriteSecureData dest nextFreeIdx fixField // compound field
    | EmailType fixField -> WriteEmailType dest nextFreeIdx fixField
    | RawData fixField -> WriteRawData dest nextFreeIdx fixField // compound field
    | PossResend fixField -> WritePossResend dest nextFreeIdx fixField
    | EncryptMethod fixField -> WriteEncryptMethod dest nextFreeIdx fixField
    | StopPx fixField -> WriteStopPx dest nextFreeIdx fixField
    | ExDestination fixField -> WriteExDestination dest nextFreeIdx fixField
    | CxlRejReason fixField -> WriteCxlRejReason dest nextFreeIdx fixField
    | OrdRejReason fixField -> WriteOrdRejReason dest nextFreeIdx fixField
    | IOIQualifier fixField -> WriteIOIQualifier dest nextFreeIdx fixField
    | WaveNo fixField -> WriteWaveNo dest nextFreeIdx fixField
    | Issuer fixField -> WriteIssuer dest nextFreeIdx fixField
    | SecurityDesc fixField -> WriteSecurityDesc dest nextFreeIdx fixField
    | HeartBtInt fixField -> WriteHeartBtInt dest nextFreeIdx fixField
    | MinQty fixField -> WriteMinQty dest nextFreeIdx fixField
    | MaxFloor fixField -> WriteMaxFloor dest nextFreeIdx fixField
    | TestReqID fixField -> WriteTestReqID dest nextFreeIdx fixField
    | ReportToExch fixField -> WriteReportToExch dest nextFreeIdx fixField
    | LocateReqd fixField -> WriteLocateReqd dest nextFreeIdx fixField
    | OnBehalfOfCompID fixField -> WriteOnBehalfOfCompID dest nextFreeIdx fixField
    | OnBehalfOfSubID fixField -> WriteOnBehalfOfSubID dest nextFreeIdx fixField
    | QuoteID fixField -> WriteQuoteID dest nextFreeIdx fixField
    | NetMoney fixField -> WriteNetMoney dest nextFreeIdx fixField
    | SettlCurrAmt fixField -> WriteSettlCurrAmt dest nextFreeIdx fixField
    | SettlCurrency fixField -> WriteSettlCurrency dest nextFreeIdx fixField
    | ForexReq fixField -> WriteForexReq dest nextFreeIdx fixField
    | OrigSendingTime fixField -> WriteOrigSendingTime dest nextFreeIdx fixField
    | GapFillFlag fixField -> WriteGapFillFlag dest nextFreeIdx fixField
    | NoExecs fixField -> WriteNoExecs dest nextFreeIdx fixField
    | ExpireTime fixField -> WriteExpireTime dest nextFreeIdx fixField
    | DKReason fixField -> WriteDKReason dest nextFreeIdx fixField
    | DeliverToCompID fixField -> WriteDeliverToCompID dest nextFreeIdx fixField
    | DeliverToSubID fixField -> WriteDeliverToSubID dest nextFreeIdx fixField
    | IOINaturalFlag fixField -> WriteIOINaturalFlag dest nextFreeIdx fixField
    | QuoteReqID fixField -> WriteQuoteReqID dest nextFreeIdx fixField
    | BidPx fixField -> WriteBidPx dest nextFreeIdx fixField
    | OfferPx fixField -> WriteOfferPx dest nextFreeIdx fixField
    | BidSize fixField -> WriteBidSize dest nextFreeIdx fixField
    | OfferSize fixField -> WriteOfferSize dest nextFreeIdx fixField
    | NoMiscFees fixField -> WriteNoMiscFees dest nextFreeIdx fixField
    | MiscFeeAmt fixField -> WriteMiscFeeAmt dest nextFreeIdx fixField
    | MiscFeeCurr fixField -> WriteMiscFeeCurr dest nextFreeIdx fixField
    | MiscFeeType fixField -> WriteMiscFeeType dest nextFreeIdx fixField
    | PrevClosePx fixField -> WritePrevClosePx dest nextFreeIdx fixField
    | ResetSeqNumFlag fixField -> WriteResetSeqNumFlag dest nextFreeIdx fixField
    | SenderLocationID fixField -> WriteSenderLocationID dest nextFreeIdx fixField
    | TargetLocationID fixField -> WriteTargetLocationID dest nextFreeIdx fixField
    | OnBehalfOfLocationID fixField -> WriteOnBehalfOfLocationID dest nextFreeIdx fixField
    | DeliverToLocationID fixField -> WriteDeliverToLocationID dest nextFreeIdx fixField
    | NoRelatedSym fixField -> WriteNoRelatedSym dest nextFreeIdx fixField
    | Subject fixField -> WriteSubject dest nextFreeIdx fixField
    | Headline fixField -> WriteHeadline dest nextFreeIdx fixField
    | URLLink fixField -> WriteURLLink dest nextFreeIdx fixField
    | ExecType fixField -> WriteExecType dest nextFreeIdx fixField
    | LeavesQty fixField -> WriteLeavesQty dest nextFreeIdx fixField
    | CashOrderQty fixField -> WriteCashOrderQty dest nextFreeIdx fixField
    | AllocAvgPx fixField -> WriteAllocAvgPx dest nextFreeIdx fixField
    | AllocNetMoney fixField -> WriteAllocNetMoney dest nextFreeIdx fixField
    | SettlCurrFxRate fixField -> WriteSettlCurrFxRate dest nextFreeIdx fixField
    | SettlCurrFxRateCalc fixField -> WriteSettlCurrFxRateCalc dest nextFreeIdx fixField
    | NumDaysInterest fixField -> WriteNumDaysInterest dest nextFreeIdx fixField
    | AccruedInterestRate fixField -> WriteAccruedInterestRate dest nextFreeIdx fixField
    | AccruedInterestAmt fixField -> WriteAccruedInterestAmt dest nextFreeIdx fixField
    | SettlInstMode fixField -> WriteSettlInstMode dest nextFreeIdx fixField
    | AllocText fixField -> WriteAllocText dest nextFreeIdx fixField
    | SettlInstID fixField -> WriteSettlInstID dest nextFreeIdx fixField
    | SettlInstTransType fixField -> WriteSettlInstTransType dest nextFreeIdx fixField
    | EmailThreadID fixField -> WriteEmailThreadID dest nextFreeIdx fixField
    | SettlInstSource fixField -> WriteSettlInstSource dest nextFreeIdx fixField
    | SecurityType fixField -> WriteSecurityType dest nextFreeIdx fixField
    | EffectiveTime fixField -> WriteEffectiveTime dest nextFreeIdx fixField
    | StandInstDbType fixField -> WriteStandInstDbType dest nextFreeIdx fixField
    | StandInstDbName fixField -> WriteStandInstDbName dest nextFreeIdx fixField
    | StandInstDbID fixField -> WriteStandInstDbID dest nextFreeIdx fixField
    | SettlDeliveryType fixField -> WriteSettlDeliveryType dest nextFreeIdx fixField
    | BidSpotRate fixField -> WriteBidSpotRate dest nextFreeIdx fixField
    | BidForwardPoints fixField -> WriteBidForwardPoints dest nextFreeIdx fixField
    | OfferSpotRate fixField -> WriteOfferSpotRate dest nextFreeIdx fixField
    | OfferForwardPoints fixField -> WriteOfferForwardPoints dest nextFreeIdx fixField
    | OrderQty2 fixField -> WriteOrderQty2 dest nextFreeIdx fixField
    | SettlDate2 fixField -> WriteSettlDate2 dest nextFreeIdx fixField
    | LastSpotRate fixField -> WriteLastSpotRate dest nextFreeIdx fixField
    | LastForwardPoints fixField -> WriteLastForwardPoints dest nextFreeIdx fixField
    | AllocLinkID fixField -> WriteAllocLinkID dest nextFreeIdx fixField
    | AllocLinkType fixField -> WriteAllocLinkType dest nextFreeIdx fixField
    | SecondaryOrderID fixField -> WriteSecondaryOrderID dest nextFreeIdx fixField
    | NoIOIQualifiers fixField -> WriteNoIOIQualifiers dest nextFreeIdx fixField
    | MaturityMonthYear fixField -> WriteMaturityMonthYear dest nextFreeIdx fixField
    | PutOrCall fixField -> WritePutOrCall dest nextFreeIdx fixField
    | StrikePrice fixField -> WriteStrikePrice dest nextFreeIdx fixField
    | CoveredOrUncovered fixField -> WriteCoveredOrUncovered dest nextFreeIdx fixField
    | OptAttribute fixField -> WriteOptAttribute dest nextFreeIdx fixField
    | SecurityExchange fixField -> WriteSecurityExchange dest nextFreeIdx fixField
    | NotifyBrokerOfCredit fixField -> WriteNotifyBrokerOfCredit dest nextFreeIdx fixField
    | AllocHandlInst fixField -> WriteAllocHandlInst dest nextFreeIdx fixField
    | MaxShow fixField -> WriteMaxShow dest nextFreeIdx fixField
    | PegOffsetValue fixField -> WritePegOffsetValue dest nextFreeIdx fixField
    | XmlData fixField -> WriteXmlData dest nextFreeIdx fixField // compound field
    | SettlInstRefID fixField -> WriteSettlInstRefID dest nextFreeIdx fixField
    | NoRoutingIDs fixField -> WriteNoRoutingIDs dest nextFreeIdx fixField
    | RoutingType fixField -> WriteRoutingType dest nextFreeIdx fixField
    | RoutingID fixField -> WriteRoutingID dest nextFreeIdx fixField
    | Spread fixField -> WriteSpread dest nextFreeIdx fixField
    | BenchmarkCurveCurrency fixField -> WriteBenchmarkCurveCurrency dest nextFreeIdx fixField
    | BenchmarkCurveName fixField -> WriteBenchmarkCurveName dest nextFreeIdx fixField
    | BenchmarkCurvePoint fixField -> WriteBenchmarkCurvePoint dest nextFreeIdx fixField
    | CouponRate fixField -> WriteCouponRate dest nextFreeIdx fixField
    | CouponPaymentDate fixField -> WriteCouponPaymentDate dest nextFreeIdx fixField
    | IssueDate fixField -> WriteIssueDate dest nextFreeIdx fixField
    | RepurchaseTerm fixField -> WriteRepurchaseTerm dest nextFreeIdx fixField
    | RepurchaseRate fixField -> WriteRepurchaseRate dest nextFreeIdx fixField
    | Factor fixField -> WriteFactor dest nextFreeIdx fixField
    | TradeOriginationDate fixField -> WriteTradeOriginationDate dest nextFreeIdx fixField
    | ExDate fixField -> WriteExDate dest nextFreeIdx fixField
    | ContractMultiplier fixField -> WriteContractMultiplier dest nextFreeIdx fixField
    | NoStipulations fixField -> WriteNoStipulations dest nextFreeIdx fixField
    | StipulationType fixField -> WriteStipulationType dest nextFreeIdx fixField
    | StipulationValue fixField -> WriteStipulationValue dest nextFreeIdx fixField
    | YieldType fixField -> WriteYieldType dest nextFreeIdx fixField
    | Yield fixField -> WriteYield dest nextFreeIdx fixField
    | TotalTakedown fixField -> WriteTotalTakedown dest nextFreeIdx fixField
    | Concession fixField -> WriteConcession dest nextFreeIdx fixField
    | RepoCollateralSecurityType fixField -> WriteRepoCollateralSecurityType dest nextFreeIdx fixField
    | RedemptionDate fixField -> WriteRedemptionDate dest nextFreeIdx fixField
    | UnderlyingCouponPaymentDate fixField -> WriteUnderlyingCouponPaymentDate dest nextFreeIdx fixField
    | UnderlyingIssueDate fixField -> WriteUnderlyingIssueDate dest nextFreeIdx fixField
    | UnderlyingRepoCollateralSecurityType fixField -> WriteUnderlyingRepoCollateralSecurityType dest nextFreeIdx fixField
    | UnderlyingRepurchaseTerm fixField -> WriteUnderlyingRepurchaseTerm dest nextFreeIdx fixField
    | UnderlyingRepurchaseRate fixField -> WriteUnderlyingRepurchaseRate dest nextFreeIdx fixField
    | UnderlyingFactor fixField -> WriteUnderlyingFactor dest nextFreeIdx fixField
    | UnderlyingRedemptionDate fixField -> WriteUnderlyingRedemptionDate dest nextFreeIdx fixField
    | LegCouponPaymentDate fixField -> WriteLegCouponPaymentDate dest nextFreeIdx fixField
    | LegIssueDate fixField -> WriteLegIssueDate dest nextFreeIdx fixField
    | LegRepoCollateralSecurityType fixField -> WriteLegRepoCollateralSecurityType dest nextFreeIdx fixField
    | LegRepurchaseTerm fixField -> WriteLegRepurchaseTerm dest nextFreeIdx fixField
    | LegRepurchaseRate fixField -> WriteLegRepurchaseRate dest nextFreeIdx fixField
    | LegFactor fixField -> WriteLegFactor dest nextFreeIdx fixField
    | LegRedemptionDate fixField -> WriteLegRedemptionDate dest nextFreeIdx fixField
    | CreditRating fixField -> WriteCreditRating dest nextFreeIdx fixField
    | UnderlyingCreditRating fixField -> WriteUnderlyingCreditRating dest nextFreeIdx fixField
    | LegCreditRating fixField -> WriteLegCreditRating dest nextFreeIdx fixField
    | TradedFlatSwitch fixField -> WriteTradedFlatSwitch dest nextFreeIdx fixField
    | BasisFeatureDate fixField -> WriteBasisFeatureDate dest nextFreeIdx fixField
    | BasisFeaturePrice fixField -> WriteBasisFeaturePrice dest nextFreeIdx fixField
    | MDReqID fixField -> WriteMDReqID dest nextFreeIdx fixField
    | SubscriptionRequestType fixField -> WriteSubscriptionRequestType dest nextFreeIdx fixField
    | MarketDepth fixField -> WriteMarketDepth dest nextFreeIdx fixField
    | MDUpdateType fixField -> WriteMDUpdateType dest nextFreeIdx fixField
    | AggregatedBook fixField -> WriteAggregatedBook dest nextFreeIdx fixField
    | NoMDEntryTypes fixField -> WriteNoMDEntryTypes dest nextFreeIdx fixField
    | NoMDEntries fixField -> WriteNoMDEntries dest nextFreeIdx fixField
    | MDEntryType fixField -> WriteMDEntryType dest nextFreeIdx fixField
    | MDEntryPx fixField -> WriteMDEntryPx dest nextFreeIdx fixField
    | MDEntrySize fixField -> WriteMDEntrySize dest nextFreeIdx fixField
    | MDEntryDate fixField -> WriteMDEntryDate dest nextFreeIdx fixField
    | MDEntryTime fixField -> WriteMDEntryTime dest nextFreeIdx fixField
    | TickDirection fixField -> WriteTickDirection dest nextFreeIdx fixField
    | MDMkt fixField -> WriteMDMkt dest nextFreeIdx fixField
    | QuoteCondition fixField -> WriteQuoteCondition dest nextFreeIdx fixField
    | TradeCondition fixField -> WriteTradeCondition dest nextFreeIdx fixField
    | MDEntryID fixField -> WriteMDEntryID dest nextFreeIdx fixField
    | MDUpdateAction fixField -> WriteMDUpdateAction dest nextFreeIdx fixField
    | MDEntryRefID fixField -> WriteMDEntryRefID dest nextFreeIdx fixField
    | MDReqRejReason fixField -> WriteMDReqRejReason dest nextFreeIdx fixField
    | MDEntryOriginator fixField -> WriteMDEntryOriginator dest nextFreeIdx fixField
    | LocationID fixField -> WriteLocationID dest nextFreeIdx fixField
    | DeskID fixField -> WriteDeskID dest nextFreeIdx fixField
    | DeleteReason fixField -> WriteDeleteReason dest nextFreeIdx fixField
    | OpenCloseSettlFlag fixField -> WriteOpenCloseSettlFlag dest nextFreeIdx fixField
    | SellerDays fixField -> WriteSellerDays dest nextFreeIdx fixField
    | MDEntryBuyer fixField -> WriteMDEntryBuyer dest nextFreeIdx fixField
    | MDEntrySeller fixField -> WriteMDEntrySeller dest nextFreeIdx fixField
    | MDEntryPositionNo fixField -> WriteMDEntryPositionNo dest nextFreeIdx fixField
    | FinancialStatus fixField -> WriteFinancialStatus dest nextFreeIdx fixField
    | CorporateAction fixField -> WriteCorporateAction dest nextFreeIdx fixField
    | DefBidSize fixField -> WriteDefBidSize dest nextFreeIdx fixField
    | DefOfferSize fixField -> WriteDefOfferSize dest nextFreeIdx fixField
    | NoQuoteEntries fixField -> WriteNoQuoteEntries dest nextFreeIdx fixField
    | NoQuoteSets fixField -> WriteNoQuoteSets dest nextFreeIdx fixField
    | QuoteStatus fixField -> WriteQuoteStatus dest nextFreeIdx fixField
    | QuoteCancelType fixField -> WriteQuoteCancelType dest nextFreeIdx fixField
    | QuoteEntryID fixField -> WriteQuoteEntryID dest nextFreeIdx fixField
    | QuoteRejectReason fixField -> WriteQuoteRejectReason dest nextFreeIdx fixField
    | QuoteResponseLevel fixField -> WriteQuoteResponseLevel dest nextFreeIdx fixField
    | QuoteSetID fixField -> WriteQuoteSetID dest nextFreeIdx fixField
    | QuoteRequestType fixField -> WriteQuoteRequestType dest nextFreeIdx fixField
    | TotNoQuoteEntries fixField -> WriteTotNoQuoteEntries dest nextFreeIdx fixField
    | UnderlyingSecurityIDSource fixField -> WriteUnderlyingSecurityIDSource dest nextFreeIdx fixField
    | UnderlyingIssuer fixField -> WriteUnderlyingIssuer dest nextFreeIdx fixField
    | UnderlyingSecurityDesc fixField -> WriteUnderlyingSecurityDesc dest nextFreeIdx fixField
    | UnderlyingSecurityExchange fixField -> WriteUnderlyingSecurityExchange dest nextFreeIdx fixField
    | UnderlyingSecurityID fixField -> WriteUnderlyingSecurityID dest nextFreeIdx fixField
    | UnderlyingSecurityType fixField -> WriteUnderlyingSecurityType dest nextFreeIdx fixField
    | UnderlyingSymbol fixField -> WriteUnderlyingSymbol dest nextFreeIdx fixField
    | UnderlyingSymbolSfx fixField -> WriteUnderlyingSymbolSfx dest nextFreeIdx fixField
    | UnderlyingMaturityMonthYear fixField -> WriteUnderlyingMaturityMonthYear dest nextFreeIdx fixField
    | UnderlyingPutOrCall fixField -> WriteUnderlyingPutOrCall dest nextFreeIdx fixField
    | UnderlyingStrikePrice fixField -> WriteUnderlyingStrikePrice dest nextFreeIdx fixField
    | UnderlyingOptAttribute fixField -> WriteUnderlyingOptAttribute dest nextFreeIdx fixField
    | UnderlyingCurrency fixField -> WriteUnderlyingCurrency dest nextFreeIdx fixField
    | SecurityReqID fixField -> WriteSecurityReqID dest nextFreeIdx fixField
    | SecurityRequestType fixField -> WriteSecurityRequestType dest nextFreeIdx fixField
    | SecurityResponseID fixField -> WriteSecurityResponseID dest nextFreeIdx fixField
    | SecurityResponseType fixField -> WriteSecurityResponseType dest nextFreeIdx fixField
    | SecurityStatusReqID fixField -> WriteSecurityStatusReqID dest nextFreeIdx fixField
    | UnsolicitedIndicator fixField -> WriteUnsolicitedIndicator dest nextFreeIdx fixField
    | SecurityTradingStatus fixField -> WriteSecurityTradingStatus dest nextFreeIdx fixField
    | HaltReason fixField -> WriteHaltReason dest nextFreeIdx fixField
    | InViewOfCommon fixField -> WriteInViewOfCommon dest nextFreeIdx fixField
    | DueToRelated fixField -> WriteDueToRelated dest nextFreeIdx fixField
    | BuyVolume fixField -> WriteBuyVolume dest nextFreeIdx fixField
    | SellVolume fixField -> WriteSellVolume dest nextFreeIdx fixField
    | HighPx fixField -> WriteHighPx dest nextFreeIdx fixField
    | LowPx fixField -> WriteLowPx dest nextFreeIdx fixField
    | Adjustment fixField -> WriteAdjustment dest nextFreeIdx fixField
    | TradSesReqID fixField -> WriteTradSesReqID dest nextFreeIdx fixField
    | TradingSessionID fixField -> WriteTradingSessionID dest nextFreeIdx fixField
    | ContraTrader fixField -> WriteContraTrader dest nextFreeIdx fixField
    | TradSesMethod fixField -> WriteTradSesMethod dest nextFreeIdx fixField
    | TradSesMode fixField -> WriteTradSesMode dest nextFreeIdx fixField
    | TradSesStatus fixField -> WriteTradSesStatus dest nextFreeIdx fixField
    | TradSesStartTime fixField -> WriteTradSesStartTime dest nextFreeIdx fixField
    | TradSesOpenTime fixField -> WriteTradSesOpenTime dest nextFreeIdx fixField
    | TradSesPreCloseTime fixField -> WriteTradSesPreCloseTime dest nextFreeIdx fixField
    | TradSesCloseTime fixField -> WriteTradSesCloseTime dest nextFreeIdx fixField
    | TradSesEndTime fixField -> WriteTradSesEndTime dest nextFreeIdx fixField
    | NumberOfOrders fixField -> WriteNumberOfOrders dest nextFreeIdx fixField
    | MessageEncoding fixField -> WriteMessageEncoding dest nextFreeIdx fixField
    | EncodedIssuer fixField -> WriteEncodedIssuer dest nextFreeIdx fixField // compound field
    | EncodedSecurityDesc fixField -> WriteEncodedSecurityDesc dest nextFreeIdx fixField // compound field
    | EncodedListExecInst fixField -> WriteEncodedListExecInst dest nextFreeIdx fixField // compound field
    | EncodedText fixField -> WriteEncodedText dest nextFreeIdx fixField // compound field
    | EncodedSubject fixField -> WriteEncodedSubject dest nextFreeIdx fixField // compound field
    | EncodedHeadline fixField -> WriteEncodedHeadline dest nextFreeIdx fixField // compound field
    | EncodedAllocText fixField -> WriteEncodedAllocText dest nextFreeIdx fixField // compound field
    | EncodedUnderlyingIssuer fixField -> WriteEncodedUnderlyingIssuer dest nextFreeIdx fixField // compound field
    | EncodedUnderlyingSecurityDesc fixField -> WriteEncodedUnderlyingSecurityDesc dest nextFreeIdx fixField // compound field
    | AllocPrice fixField -> WriteAllocPrice dest nextFreeIdx fixField
    | QuoteSetValidUntilTime fixField -> WriteQuoteSetValidUntilTime dest nextFreeIdx fixField
    | QuoteEntryRejectReason fixField -> WriteQuoteEntryRejectReason dest nextFreeIdx fixField
    | LastMsgSeqNumProcessed fixField -> WriteLastMsgSeqNumProcessed dest nextFreeIdx fixField
    | RefTagID fixField -> WriteRefTagID dest nextFreeIdx fixField
    | RefMsgType fixField -> WriteRefMsgType dest nextFreeIdx fixField
    | SessionRejectReason fixField -> WriteSessionRejectReason dest nextFreeIdx fixField
    | BidRequestTransType fixField -> WriteBidRequestTransType dest nextFreeIdx fixField
    | ContraBroker fixField -> WriteContraBroker dest nextFreeIdx fixField
    | ComplianceID fixField -> WriteComplianceID dest nextFreeIdx fixField
    | SolicitedFlag fixField -> WriteSolicitedFlag dest nextFreeIdx fixField
    | ExecRestatementReason fixField -> WriteExecRestatementReason dest nextFreeIdx fixField
    | BusinessRejectRefID fixField -> WriteBusinessRejectRefID dest nextFreeIdx fixField
    | BusinessRejectReason fixField -> WriteBusinessRejectReason dest nextFreeIdx fixField
    | GrossTradeAmt fixField -> WriteGrossTradeAmt dest nextFreeIdx fixField
    | NoContraBrokers fixField -> WriteNoContraBrokers dest nextFreeIdx fixField
    | MaxMessageSize fixField -> WriteMaxMessageSize dest nextFreeIdx fixField
    | NoMsgTypes fixField -> WriteNoMsgTypes dest nextFreeIdx fixField
    | MsgDirection fixField -> WriteMsgDirection dest nextFreeIdx fixField
    | NoTradingSessions fixField -> WriteNoTradingSessions dest nextFreeIdx fixField
    | TotalVolumeTraded fixField -> WriteTotalVolumeTraded dest nextFreeIdx fixField
    | DiscretionInst fixField -> WriteDiscretionInst dest nextFreeIdx fixField
    | DiscretionOffsetValue fixField -> WriteDiscretionOffsetValue dest nextFreeIdx fixField
    | BidID fixField -> WriteBidID dest nextFreeIdx fixField
    | ClientBidID fixField -> WriteClientBidID dest nextFreeIdx fixField
    | ListName fixField -> WriteListName dest nextFreeIdx fixField
    | TotNoRelatedSym fixField -> WriteTotNoRelatedSym dest nextFreeIdx fixField
    | BidType fixField -> WriteBidType dest nextFreeIdx fixField
    | NumTickets fixField -> WriteNumTickets dest nextFreeIdx fixField
    | SideValue1 fixField -> WriteSideValue1 dest nextFreeIdx fixField
    | SideValue2 fixField -> WriteSideValue2 dest nextFreeIdx fixField
    | NoBidDescriptors fixField -> WriteNoBidDescriptors dest nextFreeIdx fixField
    | BidDescriptorType fixField -> WriteBidDescriptorType dest nextFreeIdx fixField
    | BidDescriptor fixField -> WriteBidDescriptor dest nextFreeIdx fixField
    | SideValueInd fixField -> WriteSideValueInd dest nextFreeIdx fixField
    | LiquidityPctLow fixField -> WriteLiquidityPctLow dest nextFreeIdx fixField
    | LiquidityPctHigh fixField -> WriteLiquidityPctHigh dest nextFreeIdx fixField
    | LiquidityValue fixField -> WriteLiquidityValue dest nextFreeIdx fixField
    | EFPTrackingError fixField -> WriteEFPTrackingError dest nextFreeIdx fixField
    | FairValue fixField -> WriteFairValue dest nextFreeIdx fixField
    | OutsideIndexPct fixField -> WriteOutsideIndexPct dest nextFreeIdx fixField
    | ValueOfFutures fixField -> WriteValueOfFutures dest nextFreeIdx fixField
    | LiquidityIndType fixField -> WriteLiquidityIndType dest nextFreeIdx fixField
    | WtAverageLiquidity fixField -> WriteWtAverageLiquidity dest nextFreeIdx fixField
    | ExchangeForPhysical fixField -> WriteExchangeForPhysical dest nextFreeIdx fixField
    | OutMainCntryUIndex fixField -> WriteOutMainCntryUIndex dest nextFreeIdx fixField
    | CrossPercent fixField -> WriteCrossPercent dest nextFreeIdx fixField
    | ProgRptReqs fixField -> WriteProgRptReqs dest nextFreeIdx fixField
    | ProgPeriodInterval fixField -> WriteProgPeriodInterval dest nextFreeIdx fixField
    | IncTaxInd fixField -> WriteIncTaxInd dest nextFreeIdx fixField
    | NumBidders fixField -> WriteNumBidders dest nextFreeIdx fixField
    | BidTradeType fixField -> WriteBidTradeType dest nextFreeIdx fixField
    | BasisPxType fixField -> WriteBasisPxType dest nextFreeIdx fixField
    | NoBidComponents fixField -> WriteNoBidComponents dest nextFreeIdx fixField
    | Country fixField -> WriteCountry dest nextFreeIdx fixField
    | TotNoStrikes fixField -> WriteTotNoStrikes dest nextFreeIdx fixField
    | PriceType fixField -> WritePriceType dest nextFreeIdx fixField
    | DayOrderQty fixField -> WriteDayOrderQty dest nextFreeIdx fixField
    | DayCumQty fixField -> WriteDayCumQty dest nextFreeIdx fixField
    | DayAvgPx fixField -> WriteDayAvgPx dest nextFreeIdx fixField
    | GTBookingInst fixField -> WriteGTBookingInst dest nextFreeIdx fixField
    | NoStrikes fixField -> WriteNoStrikes dest nextFreeIdx fixField
    | ListStatusType fixField -> WriteListStatusType dest nextFreeIdx fixField
    | NetGrossInd fixField -> WriteNetGrossInd dest nextFreeIdx fixField
    | ListOrderStatus fixField -> WriteListOrderStatus dest nextFreeIdx fixField
    | ExpireDate fixField -> WriteExpireDate dest nextFreeIdx fixField
    | ListExecInstType fixField -> WriteListExecInstType dest nextFreeIdx fixField
    | CxlRejResponseTo fixField -> WriteCxlRejResponseTo dest nextFreeIdx fixField
    | UnderlyingCouponRate fixField -> WriteUnderlyingCouponRate dest nextFreeIdx fixField
    | UnderlyingContractMultiplier fixField -> WriteUnderlyingContractMultiplier dest nextFreeIdx fixField
    | ContraTradeQty fixField -> WriteContraTradeQty dest nextFreeIdx fixField
    | ContraTradeTime fixField -> WriteContraTradeTime dest nextFreeIdx fixField
    | LiquidityNumSecurities fixField -> WriteLiquidityNumSecurities dest nextFreeIdx fixField
    | MultiLegReportingType fixField -> WriteMultiLegReportingType dest nextFreeIdx fixField
    | StrikeTime fixField -> WriteStrikeTime dest nextFreeIdx fixField
    | ListStatusText fixField -> WriteListStatusText dest nextFreeIdx fixField
    | EncodedListStatusText fixField -> WriteEncodedListStatusText dest nextFreeIdx fixField // compound field
    | PartyIDSource fixField -> WritePartyIDSource dest nextFreeIdx fixField
    | PartyID fixField -> WritePartyID dest nextFreeIdx fixField
    | NetChgPrevDay fixField -> WriteNetChgPrevDay dest nextFreeIdx fixField
    | PartyRole fixField -> WritePartyRole dest nextFreeIdx fixField
    | NoPartyIDs fixField -> WriteNoPartyIDs dest nextFreeIdx fixField
    | NoSecurityAltID fixField -> WriteNoSecurityAltID dest nextFreeIdx fixField
    | SecurityAltID fixField -> WriteSecurityAltID dest nextFreeIdx fixField
    | SecurityAltIDSource fixField -> WriteSecurityAltIDSource dest nextFreeIdx fixField
    | NoUnderlyingSecurityAltID fixField -> WriteNoUnderlyingSecurityAltID dest nextFreeIdx fixField
    | UnderlyingSecurityAltID fixField -> WriteUnderlyingSecurityAltID dest nextFreeIdx fixField
    | UnderlyingSecurityAltIDSource fixField -> WriteUnderlyingSecurityAltIDSource dest nextFreeIdx fixField
    | Product fixField -> WriteProduct dest nextFreeIdx fixField
    | CFICode fixField -> WriteCFICode dest nextFreeIdx fixField
    | UnderlyingProduct fixField -> WriteUnderlyingProduct dest nextFreeIdx fixField
    | UnderlyingCFICode fixField -> WriteUnderlyingCFICode dest nextFreeIdx fixField
    | TestMessageIndicator fixField -> WriteTestMessageIndicator dest nextFreeIdx fixField
    | QuantityType fixField -> WriteQuantityType dest nextFreeIdx fixField
    | BookingRefID fixField -> WriteBookingRefID dest nextFreeIdx fixField
    | IndividualAllocID fixField -> WriteIndividualAllocID dest nextFreeIdx fixField
    | RoundingDirection fixField -> WriteRoundingDirection dest nextFreeIdx fixField
    | RoundingModulus fixField -> WriteRoundingModulus dest nextFreeIdx fixField
    | CountryOfIssue fixField -> WriteCountryOfIssue dest nextFreeIdx fixField
    | StateOrProvinceOfIssue fixField -> WriteStateOrProvinceOfIssue dest nextFreeIdx fixField
    | LocaleOfIssue fixField -> WriteLocaleOfIssue dest nextFreeIdx fixField
    | NoRegistDtls fixField -> WriteNoRegistDtls dest nextFreeIdx fixField
    | MailingDtls fixField -> WriteMailingDtls dest nextFreeIdx fixField
    | InvestorCountryOfResidence fixField -> WriteInvestorCountryOfResidence dest nextFreeIdx fixField
    | PaymentRef fixField -> WritePaymentRef dest nextFreeIdx fixField
    | DistribPaymentMethod fixField -> WriteDistribPaymentMethod dest nextFreeIdx fixField
    | CashDistribCurr fixField -> WriteCashDistribCurr dest nextFreeIdx fixField
    | CommCurrency fixField -> WriteCommCurrency dest nextFreeIdx fixField
    | CancellationRights fixField -> WriteCancellationRights dest nextFreeIdx fixField
    | MoneyLaunderingStatus fixField -> WriteMoneyLaunderingStatus dest nextFreeIdx fixField
    | MailingInst fixField -> WriteMailingInst dest nextFreeIdx fixField
    | TransBkdTime fixField -> WriteTransBkdTime dest nextFreeIdx fixField
    | ExecPriceType fixField -> WriteExecPriceType dest nextFreeIdx fixField
    | ExecPriceAdjustment fixField -> WriteExecPriceAdjustment dest nextFreeIdx fixField
    | DateOfBirth fixField -> WriteDateOfBirth dest nextFreeIdx fixField
    | TradeReportTransType fixField -> WriteTradeReportTransType dest nextFreeIdx fixField
    | CardHolderName fixField -> WriteCardHolderName dest nextFreeIdx fixField
    | CardNumber fixField -> WriteCardNumber dest nextFreeIdx fixField
    | CardExpDate fixField -> WriteCardExpDate dest nextFreeIdx fixField
    | CardIssNum fixField -> WriteCardIssNum dest nextFreeIdx fixField
    | PaymentMethod fixField -> WritePaymentMethod dest nextFreeIdx fixField
    | RegistAcctType fixField -> WriteRegistAcctType dest nextFreeIdx fixField
    | Designation fixField -> WriteDesignation dest nextFreeIdx fixField
    | TaxAdvantageType fixField -> WriteTaxAdvantageType dest nextFreeIdx fixField
    | RegistRejReasonText fixField -> WriteRegistRejReasonText dest nextFreeIdx fixField
    | FundRenewWaiv fixField -> WriteFundRenewWaiv dest nextFreeIdx fixField
    | CashDistribAgentName fixField -> WriteCashDistribAgentName dest nextFreeIdx fixField
    | CashDistribAgentCode fixField -> WriteCashDistribAgentCode dest nextFreeIdx fixField
    | CashDistribAgentAcctNumber fixField -> WriteCashDistribAgentAcctNumber dest nextFreeIdx fixField
    | CashDistribPayRef fixField -> WriteCashDistribPayRef dest nextFreeIdx fixField
    | CashDistribAgentAcctName fixField -> WriteCashDistribAgentAcctName dest nextFreeIdx fixField
    | CardStartDate fixField -> WriteCardStartDate dest nextFreeIdx fixField
    | PaymentDate fixField -> WritePaymentDate dest nextFreeIdx fixField
    | PaymentRemitterID fixField -> WritePaymentRemitterID dest nextFreeIdx fixField
    | RegistStatus fixField -> WriteRegistStatus dest nextFreeIdx fixField
    | RegistRejReasonCode fixField -> WriteRegistRejReasonCode dest nextFreeIdx fixField
    | RegistRefID fixField -> WriteRegistRefID dest nextFreeIdx fixField
    | RegistDtls fixField -> WriteRegistDtls dest nextFreeIdx fixField
    | NoDistribInsts fixField -> WriteNoDistribInsts dest nextFreeIdx fixField
    | RegistEmail fixField -> WriteRegistEmail dest nextFreeIdx fixField
    | DistribPercentage fixField -> WriteDistribPercentage dest nextFreeIdx fixField
    | RegistID fixField -> WriteRegistID dest nextFreeIdx fixField
    | RegistTransType fixField -> WriteRegistTransType dest nextFreeIdx fixField
    | ExecValuationPoint fixField -> WriteExecValuationPoint dest nextFreeIdx fixField
    | OrderPercent fixField -> WriteOrderPercent dest nextFreeIdx fixField
    | OwnershipType fixField -> WriteOwnershipType dest nextFreeIdx fixField
    | NoContAmts fixField -> WriteNoContAmts dest nextFreeIdx fixField
    | ContAmtType fixField -> WriteContAmtType dest nextFreeIdx fixField
    | ContAmtValue fixField -> WriteContAmtValue dest nextFreeIdx fixField
    | ContAmtCurr fixField -> WriteContAmtCurr dest nextFreeIdx fixField
    | OwnerType fixField -> WriteOwnerType dest nextFreeIdx fixField
    | PartySubID fixField -> WritePartySubID dest nextFreeIdx fixField
    | NestedPartyID fixField -> WriteNestedPartyID dest nextFreeIdx fixField
    | NestedPartyIDSource fixField -> WriteNestedPartyIDSource dest nextFreeIdx fixField
    | SecondaryClOrdID fixField -> WriteSecondaryClOrdID dest nextFreeIdx fixField
    | SecondaryExecID fixField -> WriteSecondaryExecID dest nextFreeIdx fixField
    | OrderCapacity fixField -> WriteOrderCapacity dest nextFreeIdx fixField
    | OrderRestrictions fixField -> WriteOrderRestrictions dest nextFreeIdx fixField
    | MassCancelRequestType fixField -> WriteMassCancelRequestType dest nextFreeIdx fixField
    | MassCancelResponse fixField -> WriteMassCancelResponse dest nextFreeIdx fixField
    | MassCancelRejectReason fixField -> WriteMassCancelRejectReason dest nextFreeIdx fixField
    | TotalAffectedOrders fixField -> WriteTotalAffectedOrders dest nextFreeIdx fixField
    | NoAffectedOrders fixField -> WriteNoAffectedOrders dest nextFreeIdx fixField
    | AffectedOrderID fixField -> WriteAffectedOrderID dest nextFreeIdx fixField
    | AffectedSecondaryOrderID fixField -> WriteAffectedSecondaryOrderID dest nextFreeIdx fixField
    | QuoteType fixField -> WriteQuoteType dest nextFreeIdx fixField
    | NestedPartyRole fixField -> WriteNestedPartyRole dest nextFreeIdx fixField
    | NoNestedPartyIDs fixField -> WriteNoNestedPartyIDs dest nextFreeIdx fixField
    | TotalAccruedInterestAmt fixField -> WriteTotalAccruedInterestAmt dest nextFreeIdx fixField
    | MaturityDate fixField -> WriteMaturityDate dest nextFreeIdx fixField
    | UnderlyingMaturityDate fixField -> WriteUnderlyingMaturityDate dest nextFreeIdx fixField
    | InstrRegistry fixField -> WriteInstrRegistry dest nextFreeIdx fixField
    | CashMargin fixField -> WriteCashMargin dest nextFreeIdx fixField
    | NestedPartySubID fixField -> WriteNestedPartySubID dest nextFreeIdx fixField
    | Scope fixField -> WriteScope dest nextFreeIdx fixField
    | MDImplicitDelete fixField -> WriteMDImplicitDelete dest nextFreeIdx fixField
    | CrossID fixField -> WriteCrossID dest nextFreeIdx fixField
    | CrossType fixField -> WriteCrossType dest nextFreeIdx fixField
    | CrossPrioritization fixField -> WriteCrossPrioritization dest nextFreeIdx fixField
    | OrigCrossID fixField -> WriteOrigCrossID dest nextFreeIdx fixField
    | NoSides fixField -> WriteNoSides dest nextFreeIdx fixField
    | Username fixField -> WriteUsername dest nextFreeIdx fixField
    | Password fixField -> WritePassword dest nextFreeIdx fixField
    | NoLegs fixField -> WriteNoLegs dest nextFreeIdx fixField
    | LegCurrency fixField -> WriteLegCurrency dest nextFreeIdx fixField
    | TotNoSecurityTypes fixField -> WriteTotNoSecurityTypes dest nextFreeIdx fixField
    | NoSecurityTypes fixField -> WriteNoSecurityTypes dest nextFreeIdx fixField
    | SecurityListRequestType fixField -> WriteSecurityListRequestType dest nextFreeIdx fixField
    | SecurityRequestResult fixField -> WriteSecurityRequestResult dest nextFreeIdx fixField
    | RoundLot fixField -> WriteRoundLot dest nextFreeIdx fixField
    | MinTradeVol fixField -> WriteMinTradeVol dest nextFreeIdx fixField
    | MultiLegRptTypeReq fixField -> WriteMultiLegRptTypeReq dest nextFreeIdx fixField
    | LegPositionEffect fixField -> WriteLegPositionEffect dest nextFreeIdx fixField
    | LegCoveredOrUncovered fixField -> WriteLegCoveredOrUncovered dest nextFreeIdx fixField
    | LegPrice fixField -> WriteLegPrice dest nextFreeIdx fixField
    | TradSesStatusRejReason fixField -> WriteTradSesStatusRejReason dest nextFreeIdx fixField
    | TradeRequestID fixField -> WriteTradeRequestID dest nextFreeIdx fixField
    | TradeRequestType fixField -> WriteTradeRequestType dest nextFreeIdx fixField
    | PreviouslyReported fixField -> WritePreviouslyReported dest nextFreeIdx fixField
    | TradeReportID fixField -> WriteTradeReportID dest nextFreeIdx fixField
    | TradeReportRefID fixField -> WriteTradeReportRefID dest nextFreeIdx fixField
    | MatchStatus fixField -> WriteMatchStatus dest nextFreeIdx fixField
    | MatchType fixField -> WriteMatchType dest nextFreeIdx fixField
    | OddLot fixField -> WriteOddLot dest nextFreeIdx fixField
    | NoClearingInstructions fixField -> WriteNoClearingInstructions dest nextFreeIdx fixField
    | ClearingInstruction fixField -> WriteClearingInstruction dest nextFreeIdx fixField
    | TradeInputSource fixField -> WriteTradeInputSource dest nextFreeIdx fixField
    | TradeInputDevice fixField -> WriteTradeInputDevice dest nextFreeIdx fixField
    | NoDates fixField -> WriteNoDates dest nextFreeIdx fixField
    | AccountType fixField -> WriteAccountType dest nextFreeIdx fixField
    | CustOrderCapacity fixField -> WriteCustOrderCapacity dest nextFreeIdx fixField
    | ClOrdLinkID fixField -> WriteClOrdLinkID dest nextFreeIdx fixField
    | MassStatusReqID fixField -> WriteMassStatusReqID dest nextFreeIdx fixField
    | MassStatusReqType fixField -> WriteMassStatusReqType dest nextFreeIdx fixField
    | OrigOrdModTime fixField -> WriteOrigOrdModTime dest nextFreeIdx fixField
    | LegSettlType fixField -> WriteLegSettlType dest nextFreeIdx fixField
    | LegSettlDate fixField -> WriteLegSettlDate dest nextFreeIdx fixField
    | DayBookingInst fixField -> WriteDayBookingInst dest nextFreeIdx fixField
    | BookingUnit fixField -> WriteBookingUnit dest nextFreeIdx fixField
    | PreallocMethod fixField -> WritePreallocMethod dest nextFreeIdx fixField
    | UnderlyingCountryOfIssue fixField -> WriteUnderlyingCountryOfIssue dest nextFreeIdx fixField
    | UnderlyingStateOrProvinceOfIssue fixField -> WriteUnderlyingStateOrProvinceOfIssue dest nextFreeIdx fixField
    | UnderlyingLocaleOfIssue fixField -> WriteUnderlyingLocaleOfIssue dest nextFreeIdx fixField
    | UnderlyingInstrRegistry fixField -> WriteUnderlyingInstrRegistry dest nextFreeIdx fixField
    | LegCountryOfIssue fixField -> WriteLegCountryOfIssue dest nextFreeIdx fixField
    | LegStateOrProvinceOfIssue fixField -> WriteLegStateOrProvinceOfIssue dest nextFreeIdx fixField
    | LegLocaleOfIssue fixField -> WriteLegLocaleOfIssue dest nextFreeIdx fixField
    | LegInstrRegistry fixField -> WriteLegInstrRegistry dest nextFreeIdx fixField
    | LegSymbol fixField -> WriteLegSymbol dest nextFreeIdx fixField
    | LegSymbolSfx fixField -> WriteLegSymbolSfx dest nextFreeIdx fixField
    | LegSecurityID fixField -> WriteLegSecurityID dest nextFreeIdx fixField
    | LegSecurityIDSource fixField -> WriteLegSecurityIDSource dest nextFreeIdx fixField
    | NoLegSecurityAltID fixField -> WriteNoLegSecurityAltID dest nextFreeIdx fixField
    | LegSecurityAltID fixField -> WriteLegSecurityAltID dest nextFreeIdx fixField
    | LegSecurityAltIDSource fixField -> WriteLegSecurityAltIDSource dest nextFreeIdx fixField
    | LegProduct fixField -> WriteLegProduct dest nextFreeIdx fixField
    | LegCFICode fixField -> WriteLegCFICode dest nextFreeIdx fixField
    | LegSecurityType fixField -> WriteLegSecurityType dest nextFreeIdx fixField
    | LegMaturityMonthYear fixField -> WriteLegMaturityMonthYear dest nextFreeIdx fixField
    | LegMaturityDate fixField -> WriteLegMaturityDate dest nextFreeIdx fixField
    | LegStrikePrice fixField -> WriteLegStrikePrice dest nextFreeIdx fixField
    | LegOptAttribute fixField -> WriteLegOptAttribute dest nextFreeIdx fixField
    | LegContractMultiplier fixField -> WriteLegContractMultiplier dest nextFreeIdx fixField
    | LegCouponRate fixField -> WriteLegCouponRate dest nextFreeIdx fixField
    | LegSecurityExchange fixField -> WriteLegSecurityExchange dest nextFreeIdx fixField
    | LegIssuer fixField -> WriteLegIssuer dest nextFreeIdx fixField
    | EncodedLegIssuer fixField -> WriteEncodedLegIssuer dest nextFreeIdx fixField // compound field
    | LegSecurityDesc fixField -> WriteLegSecurityDesc dest nextFreeIdx fixField
    | EncodedLegSecurityDesc fixField -> WriteEncodedLegSecurityDesc dest nextFreeIdx fixField // compound field
    | LegRatioQty fixField -> WriteLegRatioQty dest nextFreeIdx fixField
    | LegSide fixField -> WriteLegSide dest nextFreeIdx fixField
    | TradingSessionSubID fixField -> WriteTradingSessionSubID dest nextFreeIdx fixField
    | AllocType fixField -> WriteAllocType dest nextFreeIdx fixField
    | NoHops fixField -> WriteNoHops dest nextFreeIdx fixField
    | HopCompID fixField -> WriteHopCompID dest nextFreeIdx fixField
    | HopSendingTime fixField -> WriteHopSendingTime dest nextFreeIdx fixField
    | HopRefID fixField -> WriteHopRefID dest nextFreeIdx fixField
    | MidPx fixField -> WriteMidPx dest nextFreeIdx fixField
    | BidYield fixField -> WriteBidYield dest nextFreeIdx fixField
    | MidYield fixField -> WriteMidYield dest nextFreeIdx fixField
    | OfferYield fixField -> WriteOfferYield dest nextFreeIdx fixField
    | ClearingFeeIndicator fixField -> WriteClearingFeeIndicator dest nextFreeIdx fixField
    | WorkingIndicator fixField -> WriteWorkingIndicator dest nextFreeIdx fixField
    | LegLastPx fixField -> WriteLegLastPx dest nextFreeIdx fixField
    | PriorityIndicator fixField -> WritePriorityIndicator dest nextFreeIdx fixField
    | PriceImprovement fixField -> WritePriceImprovement dest nextFreeIdx fixField
    | Price2 fixField -> WritePrice2 dest nextFreeIdx fixField
    | LastForwardPoints2 fixField -> WriteLastForwardPoints2 dest nextFreeIdx fixField
    | BidForwardPoints2 fixField -> WriteBidForwardPoints2 dest nextFreeIdx fixField
    | OfferForwardPoints2 fixField -> WriteOfferForwardPoints2 dest nextFreeIdx fixField
    | RFQReqID fixField -> WriteRFQReqID dest nextFreeIdx fixField
    | MktBidPx fixField -> WriteMktBidPx dest nextFreeIdx fixField
    | MktOfferPx fixField -> WriteMktOfferPx dest nextFreeIdx fixField
    | MinBidSize fixField -> WriteMinBidSize dest nextFreeIdx fixField
    | MinOfferSize fixField -> WriteMinOfferSize dest nextFreeIdx fixField
    | QuoteStatusReqID fixField -> WriteQuoteStatusReqID dest nextFreeIdx fixField
    | LegalConfirm fixField -> WriteLegalConfirm dest nextFreeIdx fixField
    | UnderlyingLastPx fixField -> WriteUnderlyingLastPx dest nextFreeIdx fixField
    | UnderlyingLastQty fixField -> WriteUnderlyingLastQty dest nextFreeIdx fixField
    | LegRefID fixField -> WriteLegRefID dest nextFreeIdx fixField
    | ContraLegRefID fixField -> WriteContraLegRefID dest nextFreeIdx fixField
    | SettlCurrBidFxRate fixField -> WriteSettlCurrBidFxRate dest nextFreeIdx fixField
    | SettlCurrOfferFxRate fixField -> WriteSettlCurrOfferFxRate dest nextFreeIdx fixField
    | QuoteRequestRejectReason fixField -> WriteQuoteRequestRejectReason dest nextFreeIdx fixField
    | SideComplianceID fixField -> WriteSideComplianceID dest nextFreeIdx fixField
    | AcctIDSource fixField -> WriteAcctIDSource dest nextFreeIdx fixField
    | AllocAcctIDSource fixField -> WriteAllocAcctIDSource dest nextFreeIdx fixField
    | BenchmarkPrice fixField -> WriteBenchmarkPrice dest nextFreeIdx fixField
    | BenchmarkPriceType fixField -> WriteBenchmarkPriceType dest nextFreeIdx fixField
    | ConfirmID fixField -> WriteConfirmID dest nextFreeIdx fixField
    | ConfirmStatus fixField -> WriteConfirmStatus dest nextFreeIdx fixField
    | ConfirmTransType fixField -> WriteConfirmTransType dest nextFreeIdx fixField
    | ContractSettlMonth fixField -> WriteContractSettlMonth dest nextFreeIdx fixField
    | DeliveryForm fixField -> WriteDeliveryForm dest nextFreeIdx fixField
    | LastParPx fixField -> WriteLastParPx dest nextFreeIdx fixField
    | NoLegAllocs fixField -> WriteNoLegAllocs dest nextFreeIdx fixField
    | LegAllocAccount fixField -> WriteLegAllocAccount dest nextFreeIdx fixField
    | LegIndividualAllocID fixField -> WriteLegIndividualAllocID dest nextFreeIdx fixField
    | LegAllocQty fixField -> WriteLegAllocQty dest nextFreeIdx fixField
    | LegAllocAcctIDSource fixField -> WriteLegAllocAcctIDSource dest nextFreeIdx fixField
    | LegSettlCurrency fixField -> WriteLegSettlCurrency dest nextFreeIdx fixField
    | LegBenchmarkCurveCurrency fixField -> WriteLegBenchmarkCurveCurrency dest nextFreeIdx fixField
    | LegBenchmarkCurveName fixField -> WriteLegBenchmarkCurveName dest nextFreeIdx fixField
    | LegBenchmarkCurvePoint fixField -> WriteLegBenchmarkCurvePoint dest nextFreeIdx fixField
    | LegBenchmarkPrice fixField -> WriteLegBenchmarkPrice dest nextFreeIdx fixField
    | LegBenchmarkPriceType fixField -> WriteLegBenchmarkPriceType dest nextFreeIdx fixField
    | LegBidPx fixField -> WriteLegBidPx dest nextFreeIdx fixField
    | LegIOIQty fixField -> WriteLegIOIQty dest nextFreeIdx fixField
    | NoLegStipulations fixField -> WriteNoLegStipulations dest nextFreeIdx fixField
    | LegOfferPx fixField -> WriteLegOfferPx dest nextFreeIdx fixField
    | LegOrderQty fixField -> WriteLegOrderQty dest nextFreeIdx fixField
    | LegPriceType fixField -> WriteLegPriceType dest nextFreeIdx fixField
    | LegQty fixField -> WriteLegQty dest nextFreeIdx fixField
    | LegStipulationType fixField -> WriteLegStipulationType dest nextFreeIdx fixField
    | LegStipulationValue fixField -> WriteLegStipulationValue dest nextFreeIdx fixField
    | LegSwapType fixField -> WriteLegSwapType dest nextFreeIdx fixField
    | Pool fixField -> WritePool dest nextFreeIdx fixField
    | QuotePriceType fixField -> WriteQuotePriceType dest nextFreeIdx fixField
    | QuoteRespID fixField -> WriteQuoteRespID dest nextFreeIdx fixField
    | QuoteRespType fixField -> WriteQuoteRespType dest nextFreeIdx fixField
    | QuoteQualifier fixField -> WriteQuoteQualifier dest nextFreeIdx fixField
    | YieldRedemptionDate fixField -> WriteYieldRedemptionDate dest nextFreeIdx fixField
    | YieldRedemptionPrice fixField -> WriteYieldRedemptionPrice dest nextFreeIdx fixField
    | YieldRedemptionPriceType fixField -> WriteYieldRedemptionPriceType dest nextFreeIdx fixField
    | BenchmarkSecurityID fixField -> WriteBenchmarkSecurityID dest nextFreeIdx fixField
    | ReversalIndicator fixField -> WriteReversalIndicator dest nextFreeIdx fixField
    | YieldCalcDate fixField -> WriteYieldCalcDate dest nextFreeIdx fixField
    | NoPositions fixField -> WriteNoPositions dest nextFreeIdx fixField
    | PosType fixField -> WritePosType dest nextFreeIdx fixField
    | LongQty fixField -> WriteLongQty dest nextFreeIdx fixField
    | ShortQty fixField -> WriteShortQty dest nextFreeIdx fixField
    | PosQtyStatus fixField -> WritePosQtyStatus dest nextFreeIdx fixField
    | PosAmtType fixField -> WritePosAmtType dest nextFreeIdx fixField
    | PosAmt fixField -> WritePosAmt dest nextFreeIdx fixField
    | PosTransType fixField -> WritePosTransType dest nextFreeIdx fixField
    | PosReqID fixField -> WritePosReqID dest nextFreeIdx fixField
    | NoUnderlyings fixField -> WriteNoUnderlyings dest nextFreeIdx fixField
    | PosMaintAction fixField -> WritePosMaintAction dest nextFreeIdx fixField
    | OrigPosReqRefID fixField -> WriteOrigPosReqRefID dest nextFreeIdx fixField
    | PosMaintRptRefID fixField -> WritePosMaintRptRefID dest nextFreeIdx fixField
    | ClearingBusinessDate fixField -> WriteClearingBusinessDate dest nextFreeIdx fixField
    | SettlSessID fixField -> WriteSettlSessID dest nextFreeIdx fixField
    | SettlSessSubID fixField -> WriteSettlSessSubID dest nextFreeIdx fixField
    | AdjustmentType fixField -> WriteAdjustmentType dest nextFreeIdx fixField
    | ContraryInstructionIndicator fixField -> WriteContraryInstructionIndicator dest nextFreeIdx fixField
    | PriorSpreadIndicator fixField -> WritePriorSpreadIndicator dest nextFreeIdx fixField
    | PosMaintRptID fixField -> WritePosMaintRptID dest nextFreeIdx fixField
    | PosMaintStatus fixField -> WritePosMaintStatus dest nextFreeIdx fixField
    | PosMaintResult fixField -> WritePosMaintResult dest nextFreeIdx fixField
    | PosReqType fixField -> WritePosReqType dest nextFreeIdx fixField
    | ResponseTransportType fixField -> WriteResponseTransportType dest nextFreeIdx fixField
    | ResponseDestination fixField -> WriteResponseDestination dest nextFreeIdx fixField
    | TotalNumPosReports fixField -> WriteTotalNumPosReports dest nextFreeIdx fixField
    | PosReqResult fixField -> WritePosReqResult dest nextFreeIdx fixField
    | PosReqStatus fixField -> WritePosReqStatus dest nextFreeIdx fixField
    | SettlPrice fixField -> WriteSettlPrice dest nextFreeIdx fixField
    | SettlPriceType fixField -> WriteSettlPriceType dest nextFreeIdx fixField
    | UnderlyingSettlPrice fixField -> WriteUnderlyingSettlPrice dest nextFreeIdx fixField
    | UnderlyingSettlPriceType fixField -> WriteUnderlyingSettlPriceType dest nextFreeIdx fixField
    | PriorSettlPrice fixField -> WritePriorSettlPrice dest nextFreeIdx fixField
    | NoQuoteQualifiers fixField -> WriteNoQuoteQualifiers dest nextFreeIdx fixField
    | AllocSettlCurrency fixField -> WriteAllocSettlCurrency dest nextFreeIdx fixField
    | AllocSettlCurrAmt fixField -> WriteAllocSettlCurrAmt dest nextFreeIdx fixField
    | InterestAtMaturity fixField -> WriteInterestAtMaturity dest nextFreeIdx fixField
    | LegDatedDate fixField -> WriteLegDatedDate dest nextFreeIdx fixField
    | LegPool fixField -> WriteLegPool dest nextFreeIdx fixField
    | AllocInterestAtMaturity fixField -> WriteAllocInterestAtMaturity dest nextFreeIdx fixField
    | AllocAccruedInterestAmt fixField -> WriteAllocAccruedInterestAmt dest nextFreeIdx fixField
    | DeliveryDate fixField -> WriteDeliveryDate dest nextFreeIdx fixField
    | AssignmentMethod fixField -> WriteAssignmentMethod dest nextFreeIdx fixField
    | AssignmentUnit fixField -> WriteAssignmentUnit dest nextFreeIdx fixField
    | OpenInterest fixField -> WriteOpenInterest dest nextFreeIdx fixField
    | ExerciseMethod fixField -> WriteExerciseMethod dest nextFreeIdx fixField
    | TotNumTradeReports fixField -> WriteTotNumTradeReports dest nextFreeIdx fixField
    | TradeRequestResult fixField -> WriteTradeRequestResult dest nextFreeIdx fixField
    | TradeRequestStatus fixField -> WriteTradeRequestStatus dest nextFreeIdx fixField
    | TradeReportRejectReason fixField -> WriteTradeReportRejectReason dest nextFreeIdx fixField
    | SideMultiLegReportingType fixField -> WriteSideMultiLegReportingType dest nextFreeIdx fixField
    | NoPosAmt fixField -> WriteNoPosAmt dest nextFreeIdx fixField
    | AutoAcceptIndicator fixField -> WriteAutoAcceptIndicator dest nextFreeIdx fixField
    | AllocReportID fixField -> WriteAllocReportID dest nextFreeIdx fixField
    | NoNested2PartyIDs fixField -> WriteNoNested2PartyIDs dest nextFreeIdx fixField
    | Nested2PartyID fixField -> WriteNested2PartyID dest nextFreeIdx fixField
    | Nested2PartyIDSource fixField -> WriteNested2PartyIDSource dest nextFreeIdx fixField
    | Nested2PartyRole fixField -> WriteNested2PartyRole dest nextFreeIdx fixField
    | Nested2PartySubID fixField -> WriteNested2PartySubID dest nextFreeIdx fixField
    | BenchmarkSecurityIDSource fixField -> WriteBenchmarkSecurityIDSource dest nextFreeIdx fixField
    | SecuritySubType fixField -> WriteSecuritySubType dest nextFreeIdx fixField
    | UnderlyingSecuritySubType fixField -> WriteUnderlyingSecuritySubType dest nextFreeIdx fixField
    | LegSecuritySubType fixField -> WriteLegSecuritySubType dest nextFreeIdx fixField
    | AllowableOneSidednessPct fixField -> WriteAllowableOneSidednessPct dest nextFreeIdx fixField
    | AllowableOneSidednessValue fixField -> WriteAllowableOneSidednessValue dest nextFreeIdx fixField
    | AllowableOneSidednessCurr fixField -> WriteAllowableOneSidednessCurr dest nextFreeIdx fixField
    | NoTrdRegTimestamps fixField -> WriteNoTrdRegTimestamps dest nextFreeIdx fixField
    | TrdRegTimestamp fixField -> WriteTrdRegTimestamp dest nextFreeIdx fixField
    | TrdRegTimestampType fixField -> WriteTrdRegTimestampType dest nextFreeIdx fixField
    | TrdRegTimestampOrigin fixField -> WriteTrdRegTimestampOrigin dest nextFreeIdx fixField
    | ConfirmRefID fixField -> WriteConfirmRefID dest nextFreeIdx fixField
    | ConfirmType fixField -> WriteConfirmType dest nextFreeIdx fixField
    | ConfirmRejReason fixField -> WriteConfirmRejReason dest nextFreeIdx fixField
    | BookingType fixField -> WriteBookingType dest nextFreeIdx fixField
    | IndividualAllocRejCode fixField -> WriteIndividualAllocRejCode dest nextFreeIdx fixField
    | SettlInstMsgID fixField -> WriteSettlInstMsgID dest nextFreeIdx fixField
    | NoSettlInst fixField -> WriteNoSettlInst dest nextFreeIdx fixField
    | LastUpdateTime fixField -> WriteLastUpdateTime dest nextFreeIdx fixField
    | AllocSettlInstType fixField -> WriteAllocSettlInstType dest nextFreeIdx fixField
    | NoSettlPartyIDs fixField -> WriteNoSettlPartyIDs dest nextFreeIdx fixField
    | SettlPartyID fixField -> WriteSettlPartyID dest nextFreeIdx fixField
    | SettlPartyIDSource fixField -> WriteSettlPartyIDSource dest nextFreeIdx fixField
    | SettlPartyRole fixField -> WriteSettlPartyRole dest nextFreeIdx fixField
    | SettlPartySubID fixField -> WriteSettlPartySubID dest nextFreeIdx fixField
    | SettlPartySubIDType fixField -> WriteSettlPartySubIDType dest nextFreeIdx fixField
    | DlvyInstType fixField -> WriteDlvyInstType dest nextFreeIdx fixField
    | TerminationType fixField -> WriteTerminationType dest nextFreeIdx fixField
    | NextExpectedMsgSeqNum fixField -> WriteNextExpectedMsgSeqNum dest nextFreeIdx fixField
    | OrdStatusReqID fixField -> WriteOrdStatusReqID dest nextFreeIdx fixField
    | SettlInstReqID fixField -> WriteSettlInstReqID dest nextFreeIdx fixField
    | SettlInstReqRejCode fixField -> WriteSettlInstReqRejCode dest nextFreeIdx fixField
    | SecondaryAllocID fixField -> WriteSecondaryAllocID dest nextFreeIdx fixField
    | AllocReportType fixField -> WriteAllocReportType dest nextFreeIdx fixField
    | AllocReportRefID fixField -> WriteAllocReportRefID dest nextFreeIdx fixField
    | AllocCancReplaceReason fixField -> WriteAllocCancReplaceReason dest nextFreeIdx fixField
    | CopyMsgIndicator fixField -> WriteCopyMsgIndicator dest nextFreeIdx fixField
    | AllocAccountType fixField -> WriteAllocAccountType dest nextFreeIdx fixField
    | OrderAvgPx fixField -> WriteOrderAvgPx dest nextFreeIdx fixField
    | OrderBookingQty fixField -> WriteOrderBookingQty dest nextFreeIdx fixField
    | NoSettlPartySubIDs fixField -> WriteNoSettlPartySubIDs dest nextFreeIdx fixField
    | NoPartySubIDs fixField -> WriteNoPartySubIDs dest nextFreeIdx fixField
    | PartySubIDType fixField -> WritePartySubIDType dest nextFreeIdx fixField
    | NoNestedPartySubIDs fixField -> WriteNoNestedPartySubIDs dest nextFreeIdx fixField
    | NestedPartySubIDType fixField -> WriteNestedPartySubIDType dest nextFreeIdx fixField
    | NoNested2PartySubIDs fixField -> WriteNoNested2PartySubIDs dest nextFreeIdx fixField
    | Nested2PartySubIDType fixField -> WriteNested2PartySubIDType dest nextFreeIdx fixField
    | AllocIntermedReqType fixField -> WriteAllocIntermedReqType dest nextFreeIdx fixField
    | UnderlyingPx fixField -> WriteUnderlyingPx dest nextFreeIdx fixField
    | PriceDelta fixField -> WritePriceDelta dest nextFreeIdx fixField
    | ApplQueueMax fixField -> WriteApplQueueMax dest nextFreeIdx fixField
    | ApplQueueDepth fixField -> WriteApplQueueDepth dest nextFreeIdx fixField
    | ApplQueueResolution fixField -> WriteApplQueueResolution dest nextFreeIdx fixField
    | ApplQueueAction fixField -> WriteApplQueueAction dest nextFreeIdx fixField
    | NoAltMDSource fixField -> WriteNoAltMDSource dest nextFreeIdx fixField
    | AltMDSourceID fixField -> WriteAltMDSourceID dest nextFreeIdx fixField
    | SecondaryTradeReportID fixField -> WriteSecondaryTradeReportID dest nextFreeIdx fixField
    | AvgPxIndicator fixField -> WriteAvgPxIndicator dest nextFreeIdx fixField
    | TradeLinkID fixField -> WriteTradeLinkID dest nextFreeIdx fixField
    | OrderInputDevice fixField -> WriteOrderInputDevice dest nextFreeIdx fixField
    | UnderlyingTradingSessionID fixField -> WriteUnderlyingTradingSessionID dest nextFreeIdx fixField
    | UnderlyingTradingSessionSubID fixField -> WriteUnderlyingTradingSessionSubID dest nextFreeIdx fixField
    | TradeLegRefID fixField -> WriteTradeLegRefID dest nextFreeIdx fixField
    | ExchangeRule fixField -> WriteExchangeRule dest nextFreeIdx fixField
    | TradeAllocIndicator fixField -> WriteTradeAllocIndicator dest nextFreeIdx fixField
    | ExpirationCycle fixField -> WriteExpirationCycle dest nextFreeIdx fixField
    | TrdType fixField -> WriteTrdType dest nextFreeIdx fixField
    | TrdSubType fixField -> WriteTrdSubType dest nextFreeIdx fixField
    | TransferReason fixField -> WriteTransferReason dest nextFreeIdx fixField
    | AsgnReqID fixField -> WriteAsgnReqID dest nextFreeIdx fixField
    | TotNumAssignmentReports fixField -> WriteTotNumAssignmentReports dest nextFreeIdx fixField
    | AsgnRptID fixField -> WriteAsgnRptID dest nextFreeIdx fixField
    | ThresholdAmount fixField -> WriteThresholdAmount dest nextFreeIdx fixField
    | PegMoveType fixField -> WritePegMoveType dest nextFreeIdx fixField
    | PegOffsetType fixField -> WritePegOffsetType dest nextFreeIdx fixField
    | PegLimitType fixField -> WritePegLimitType dest nextFreeIdx fixField
    | PegRoundDirection fixField -> WritePegRoundDirection dest nextFreeIdx fixField
    | PeggedPrice fixField -> WritePeggedPrice dest nextFreeIdx fixField
    | PegScope fixField -> WritePegScope dest nextFreeIdx fixField
    | DiscretionMoveType fixField -> WriteDiscretionMoveType dest nextFreeIdx fixField
    | DiscretionOffsetType fixField -> WriteDiscretionOffsetType dest nextFreeIdx fixField
    | DiscretionLimitType fixField -> WriteDiscretionLimitType dest nextFreeIdx fixField
    | DiscretionRoundDirection fixField -> WriteDiscretionRoundDirection dest nextFreeIdx fixField
    | DiscretionPrice fixField -> WriteDiscretionPrice dest nextFreeIdx fixField
    | DiscretionScope fixField -> WriteDiscretionScope dest nextFreeIdx fixField
    | TargetStrategy fixField -> WriteTargetStrategy dest nextFreeIdx fixField
    | TargetStrategyParameters fixField -> WriteTargetStrategyParameters dest nextFreeIdx fixField
    | ParticipationRate fixField -> WriteParticipationRate dest nextFreeIdx fixField
    | TargetStrategyPerformance fixField -> WriteTargetStrategyPerformance dest nextFreeIdx fixField
    | LastLiquidityInd fixField -> WriteLastLiquidityInd dest nextFreeIdx fixField
    | PublishTrdIndicator fixField -> WritePublishTrdIndicator dest nextFreeIdx fixField
    | ShortSaleReason fixField -> WriteShortSaleReason dest nextFreeIdx fixField
    | QtyType fixField -> WriteQtyType dest nextFreeIdx fixField
    | SecondaryTrdType fixField -> WriteSecondaryTrdType dest nextFreeIdx fixField
    | TradeReportType fixField -> WriteTradeReportType dest nextFreeIdx fixField
    | AllocNoOrdersType fixField -> WriteAllocNoOrdersType dest nextFreeIdx fixField
    | SharedCommission fixField -> WriteSharedCommission dest nextFreeIdx fixField
    | ConfirmReqID fixField -> WriteConfirmReqID dest nextFreeIdx fixField
    | AvgParPx fixField -> WriteAvgParPx dest nextFreeIdx fixField
    | ReportedPx fixField -> WriteReportedPx dest nextFreeIdx fixField
    | NoCapacities fixField -> WriteNoCapacities dest nextFreeIdx fixField
    | OrderCapacityQty fixField -> WriteOrderCapacityQty dest nextFreeIdx fixField
    | NoEvents fixField -> WriteNoEvents dest nextFreeIdx fixField
    | EventType fixField -> WriteEventType dest nextFreeIdx fixField
    | EventDate fixField -> WriteEventDate dest nextFreeIdx fixField
    | EventPx fixField -> WriteEventPx dest nextFreeIdx fixField
    | EventText fixField -> WriteEventText dest nextFreeIdx fixField
    | PctAtRisk fixField -> WritePctAtRisk dest nextFreeIdx fixField
    | NoInstrAttrib fixField -> WriteNoInstrAttrib dest nextFreeIdx fixField
    | InstrAttribType fixField -> WriteInstrAttribType dest nextFreeIdx fixField
    | InstrAttribValue fixField -> WriteInstrAttribValue dest nextFreeIdx fixField
    | DatedDate fixField -> WriteDatedDate dest nextFreeIdx fixField
    | InterestAccrualDate fixField -> WriteInterestAccrualDate dest nextFreeIdx fixField
    | CPProgram fixField -> WriteCPProgram dest nextFreeIdx fixField
    | CPRegType fixField -> WriteCPRegType dest nextFreeIdx fixField
    | UnderlyingCPProgram fixField -> WriteUnderlyingCPProgram dest nextFreeIdx fixField
    | UnderlyingCPRegType fixField -> WriteUnderlyingCPRegType dest nextFreeIdx fixField
    | UnderlyingQty fixField -> WriteUnderlyingQty dest nextFreeIdx fixField
    | TrdMatchID fixField -> WriteTrdMatchID dest nextFreeIdx fixField
    | SecondaryTradeReportRefID fixField -> WriteSecondaryTradeReportRefID dest nextFreeIdx fixField
    | UnderlyingDirtyPrice fixField -> WriteUnderlyingDirtyPrice dest nextFreeIdx fixField
    | UnderlyingEndPrice fixField -> WriteUnderlyingEndPrice dest nextFreeIdx fixField
    | UnderlyingStartValue fixField -> WriteUnderlyingStartValue dest nextFreeIdx fixField
    | UnderlyingCurrentValue fixField -> WriteUnderlyingCurrentValue dest nextFreeIdx fixField
    | UnderlyingEndValue fixField -> WriteUnderlyingEndValue dest nextFreeIdx fixField
    | NoUnderlyingStips fixField -> WriteNoUnderlyingStips dest nextFreeIdx fixField
    | UnderlyingStipType fixField -> WriteUnderlyingStipType dest nextFreeIdx fixField
    | UnderlyingStipValue fixField -> WriteUnderlyingStipValue dest nextFreeIdx fixField
    | MaturityNetMoney fixField -> WriteMaturityNetMoney dest nextFreeIdx fixField
    | MiscFeeBasis fixField -> WriteMiscFeeBasis dest nextFreeIdx fixField
    | TotNoAllocs fixField -> WriteTotNoAllocs dest nextFreeIdx fixField
    | LastFragment fixField -> WriteLastFragment dest nextFreeIdx fixField
    | CollReqID fixField -> WriteCollReqID dest nextFreeIdx fixField
    | CollAsgnReason fixField -> WriteCollAsgnReason dest nextFreeIdx fixField
    | CollInquiryQualifier fixField -> WriteCollInquiryQualifier dest nextFreeIdx fixField
    | NoTrades fixField -> WriteNoTrades dest nextFreeIdx fixField
    | MarginRatio fixField -> WriteMarginRatio dest nextFreeIdx fixField
    | MarginExcess fixField -> WriteMarginExcess dest nextFreeIdx fixField
    | TotalNetValue fixField -> WriteTotalNetValue dest nextFreeIdx fixField
    | CashOutstanding fixField -> WriteCashOutstanding dest nextFreeIdx fixField
    | CollAsgnID fixField -> WriteCollAsgnID dest nextFreeIdx fixField
    | CollAsgnTransType fixField -> WriteCollAsgnTransType dest nextFreeIdx fixField
    | CollRespID fixField -> WriteCollRespID dest nextFreeIdx fixField
    | CollAsgnRespType fixField -> WriteCollAsgnRespType dest nextFreeIdx fixField
    | CollAsgnRejectReason fixField -> WriteCollAsgnRejectReason dest nextFreeIdx fixField
    | CollAsgnRefID fixField -> WriteCollAsgnRefID dest nextFreeIdx fixField
    | CollRptID fixField -> WriteCollRptID dest nextFreeIdx fixField
    | CollInquiryID fixField -> WriteCollInquiryID dest nextFreeIdx fixField
    | CollStatus fixField -> WriteCollStatus dest nextFreeIdx fixField
    | TotNumReports fixField -> WriteTotNumReports dest nextFreeIdx fixField
    | LastRptRequested fixField -> WriteLastRptRequested dest nextFreeIdx fixField
    | AgreementDesc fixField -> WriteAgreementDesc dest nextFreeIdx fixField
    | AgreementID fixField -> WriteAgreementID dest nextFreeIdx fixField
    | AgreementDate fixField -> WriteAgreementDate dest nextFreeIdx fixField
    | StartDate fixField -> WriteStartDate dest nextFreeIdx fixField
    | EndDate fixField -> WriteEndDate dest nextFreeIdx fixField
    | AgreementCurrency fixField -> WriteAgreementCurrency dest nextFreeIdx fixField
    | DeliveryType fixField -> WriteDeliveryType dest nextFreeIdx fixField
    | EndAccruedInterestAmt fixField -> WriteEndAccruedInterestAmt dest nextFreeIdx fixField
    | StartCash fixField -> WriteStartCash dest nextFreeIdx fixField
    | EndCash fixField -> WriteEndCash dest nextFreeIdx fixField
    | UserRequestID fixField -> WriteUserRequestID dest nextFreeIdx fixField
    | UserRequestType fixField -> WriteUserRequestType dest nextFreeIdx fixField
    | NewPassword fixField -> WriteNewPassword dest nextFreeIdx fixField
    | UserStatus fixField -> WriteUserStatus dest nextFreeIdx fixField
    | UserStatusText fixField -> WriteUserStatusText dest nextFreeIdx fixField
    | StatusValue fixField -> WriteStatusValue dest nextFreeIdx fixField
    | StatusText fixField -> WriteStatusText dest nextFreeIdx fixField
    | RefCompID fixField -> WriteRefCompID dest nextFreeIdx fixField
    | RefSubID fixField -> WriteRefSubID dest nextFreeIdx fixField
    | NetworkResponseID fixField -> WriteNetworkResponseID dest nextFreeIdx fixField
    | NetworkRequestID fixField -> WriteNetworkRequestID dest nextFreeIdx fixField
    | LastNetworkResponseID fixField -> WriteLastNetworkResponseID dest nextFreeIdx fixField
    | NetworkRequestType fixField -> WriteNetworkRequestType dest nextFreeIdx fixField
    | NoCompIDs fixField -> WriteNoCompIDs dest nextFreeIdx fixField
    | NetworkStatusResponseType fixField -> WriteNetworkStatusResponseType dest nextFreeIdx fixField
    | NoCollInquiryQualifier fixField -> WriteNoCollInquiryQualifier dest nextFreeIdx fixField
    | TrdRptStatus fixField -> WriteTrdRptStatus dest nextFreeIdx fixField
    | AffirmStatus fixField -> WriteAffirmStatus dest nextFreeIdx fixField
    | UnderlyingStrikeCurrency fixField -> WriteUnderlyingStrikeCurrency dest nextFreeIdx fixField
    | LegStrikeCurrency fixField -> WriteLegStrikeCurrency dest nextFreeIdx fixField
    | TimeBracket fixField -> WriteTimeBracket dest nextFreeIdx fixField
    | CollAction fixField -> WriteCollAction dest nextFreeIdx fixField
    | CollInquiryStatus fixField -> WriteCollInquiryStatus dest nextFreeIdx fixField
    | CollInquiryResult fixField -> WriteCollInquiryResult dest nextFreeIdx fixField
    | StrikeCurrency fixField -> WriteStrikeCurrency dest nextFreeIdx fixField
    | NoNested3PartyIDs fixField -> WriteNoNested3PartyIDs dest nextFreeIdx fixField
    | Nested3PartyID fixField -> WriteNested3PartyID dest nextFreeIdx fixField
    | Nested3PartyIDSource fixField -> WriteNested3PartyIDSource dest nextFreeIdx fixField
    | Nested3PartyRole fixField -> WriteNested3PartyRole dest nextFreeIdx fixField
    | NoNested3PartySubIDs fixField -> WriteNoNested3PartySubIDs dest nextFreeIdx fixField
    | Nested3PartySubID fixField -> WriteNested3PartySubID dest nextFreeIdx fixField
    | Nested3PartySubIDType fixField -> WriteNested3PartySubIDType dest nextFreeIdx fixField
    | LegContractSettlMonth fixField -> WriteLegContractSettlMonth dest nextFreeIdx fixField
    | LegInterestAccrualDate fixField -> WriteLegInterestAccrualDate dest nextFreeIdx fixField


// todo consider replacing ReadFields match statement with lookup in a map
let ReadField (pos:int) (bs:byte[]) =
    let pos2, tag = FIXBufUtils.readTag pos bs
    match tag with
    | "1"B ->
        let pos3, fld = ReadAccount bs pos2 
        pos3, fld |> FIXField.Account
    | "2"B ->
        let pos3, fld = ReadAdvId bs pos2 
        pos3, fld |> FIXField.AdvId
    | "3"B ->
        let pos3, fld = ReadAdvRefID bs pos2 
        pos3, fld |> FIXField.AdvRefID
    | "4"B ->
        let pos3, fld = ReadAdvSide bs pos2 
        pos3, fld |> FIXField.AdvSide
    | "5"B ->
        let pos3, fld = ReadAdvTransType bs pos2 
        pos3, fld |> FIXField.AdvTransType
    | "6"B ->
        let pos3, fld = ReadAvgPx bs pos2 
        pos3, fld |> FIXField.AvgPx
    | "7"B ->
        let pos3, fld = ReadBeginSeqNo bs pos2 
        pos3, fld |> FIXField.BeginSeqNo
    | "8"B ->
        let pos3, fld = ReadBeginString bs pos2 
        pos3, fld |> FIXField.BeginString
    | "9"B ->
        let pos3, fld = ReadBodyLength bs pos2 
        pos3, fld |> FIXField.BodyLength
    | "10"B ->
        let pos3, fld = ReadCheckSum bs pos2 
        pos3, fld |> FIXField.CheckSum
    | "11"B ->
        let pos3, fld = ReadClOrdID bs pos2 
        pos3, fld |> FIXField.ClOrdID
    | "12"B ->
        let pos3, fld = ReadCommission bs pos2 
        pos3, fld |> FIXField.Commission
    | "13"B ->
        let pos3, fld = ReadCommType bs pos2 
        pos3, fld |> FIXField.CommType
    | "14"B ->
        let pos3, fld = ReadCumQty bs pos2 
        pos3, fld |> FIXField.CumQty
    | "15"B ->
        let pos3, fld = ReadCurrency bs pos2 
        pos3, fld |> FIXField.Currency
    | "16"B ->
        let pos3, fld = ReadEndSeqNo bs pos2 
        pos3, fld |> FIXField.EndSeqNo
    | "17"B ->
        let pos3, fld = ReadExecID bs pos2 
        pos3, fld |> FIXField.ExecID
    | "18"B ->
        let pos3, fld = ReadExecInst bs pos2 
        pos3, fld |> FIXField.ExecInst
    | "19"B ->
        let pos3, fld = ReadExecRefID bs pos2 
        pos3, fld |> FIXField.ExecRefID
    | "21"B ->
        let pos3, fld = ReadHandlInst bs pos2 
        pos3, fld |> FIXField.HandlInst
    | "22"B ->
        let pos3, fld = ReadSecurityIDSource bs pos2 
        pos3, fld |> FIXField.SecurityIDSource
    | "23"B ->
        let pos3, fld = ReadIOIid bs pos2 
        pos3, fld |> FIXField.IOIid
    | "25"B ->
        let pos3, fld = ReadIOIQltyInd bs pos2 
        pos3, fld |> FIXField.IOIQltyInd
    | "26"B ->
        let pos3, fld = ReadIOIRefID bs pos2 
        pos3, fld |> FIXField.IOIRefID
    | "27"B ->
        let pos3, fld = ReadIOIQty bs pos2 
        pos3, fld |> FIXField.IOIQty
    | "28"B ->
        let pos3, fld = ReadIOITransType bs pos2 
        pos3, fld |> FIXField.IOITransType
    | "29"B ->
        let pos3, fld = ReadLastCapacity bs pos2 
        pos3, fld |> FIXField.LastCapacity
    | "30"B ->
        let pos3, fld = ReadLastMkt bs pos2 
        pos3, fld |> FIXField.LastMkt
    | "31"B ->
        let pos3, fld = ReadLastPx bs pos2 
        pos3, fld |> FIXField.LastPx
    | "32"B ->
        let pos3, fld = ReadLastQty bs pos2 
        pos3, fld |> FIXField.LastQty
    | "33"B ->
        let pos3, fld = ReadLinesOfText bs pos2 
        pos3, fld |> FIXField.LinesOfText
    | "34"B ->
        let pos3, fld = ReadMsgSeqNum bs pos2 
        pos3, fld |> FIXField.MsgSeqNum
    | "35"B ->
        let pos3, fld = ReadMsgType bs pos2 
        pos3, fld |> FIXField.MsgType
    | "36"B ->
        let pos3, fld = ReadNewSeqNo bs pos2 
        pos3, fld |> FIXField.NewSeqNo
    | "37"B ->
        let pos3, fld = ReadOrderID bs pos2 
        pos3, fld |> FIXField.OrderID
    | "38"B ->
        let pos3, fld = ReadOrderQty bs pos2 
        pos3, fld |> FIXField.OrderQty
    | "39"B ->
        let pos3, fld = ReadOrdStatus bs pos2 
        pos3, fld |> FIXField.OrdStatus
    | "40"B ->
        let pos3, fld = ReadOrdType bs pos2 
        pos3, fld |> FIXField.OrdType
    | "41"B ->
        let pos3, fld = ReadOrigClOrdID bs pos2 
        pos3, fld |> FIXField.OrigClOrdID
    | "42"B ->
        let pos3, fld = ReadOrigTime bs pos2 
        pos3, fld |> FIXField.OrigTime
    | "43"B ->
        let pos3, fld = ReadPossDupFlag bs pos2 
        pos3, fld |> FIXField.PossDupFlag
    | "44"B ->
        let pos3, fld = ReadPrice bs pos2 
        pos3, fld |> FIXField.Price
    | "45"B ->
        let pos3, fld = ReadRefSeqNum bs pos2 
        pos3, fld |> FIXField.RefSeqNum
    | "48"B ->
        let pos3, fld = ReadSecurityID bs pos2 
        pos3, fld |> FIXField.SecurityID
    | "49"B ->
        let pos3, fld = ReadSenderCompID bs pos2 
        pos3, fld |> FIXField.SenderCompID
    | "50"B ->
        let pos3, fld = ReadSenderSubID bs pos2 
        pos3, fld |> FIXField.SenderSubID
    | "52"B ->
        let pos3, fld = ReadSendingTime bs pos2 
        pos3, fld |> FIXField.SendingTime
    | "53"B ->
        let pos3, fld = ReadQuantity bs pos2 
        pos3, fld |> FIXField.Quantity
    | "54"B ->
        let pos3, fld = ReadSide bs pos2 
        pos3, fld |> FIXField.Side
    | "55"B ->
        let pos3, fld = ReadSymbol bs pos2 
        pos3, fld |> FIXField.Symbol
    | "56"B ->
        let pos3, fld = ReadTargetCompID bs pos2 
        pos3, fld |> FIXField.TargetCompID
    | "57"B ->
        let pos3, fld = ReadTargetSubID bs pos2 
        pos3, fld |> FIXField.TargetSubID
    | "58"B ->
        let pos3, fld = ReadText bs pos2 
        pos3, fld |> FIXField.Text
    | "59"B ->
        let pos3, fld = ReadTimeInForce bs pos2 
        pos3, fld |> FIXField.TimeInForce
    | "60"B ->
        let pos3, fld = ReadTransactTime bs pos2 
        pos3, fld |> FIXField.TransactTime
    | "61"B ->
        let pos3, fld = ReadUrgency bs pos2 
        pos3, fld |> FIXField.Urgency
    | "62"B ->
        let pos3, fld = ReadValidUntilTime bs pos2 
        pos3, fld |> FIXField.ValidUntilTime
    | "63"B ->
        let pos3, fld = ReadSettlType bs pos2 
        pos3, fld |> FIXField.SettlType
    | "64"B ->
        let pos3, fld = ReadSettlDate bs pos2 
        pos3, fld |> FIXField.SettlDate
    | "65"B ->
        let pos3, fld = ReadSymbolSfx bs pos2 
        pos3, fld |> FIXField.SymbolSfx
    | "66"B ->
        let pos3, fld = ReadListID bs pos2 
        pos3, fld |> FIXField.ListID
    | "67"B ->
        let pos3, fld = ReadListSeqNo bs pos2 
        pos3, fld |> FIXField.ListSeqNo
    | "68"B ->
        let pos3, fld = ReadTotNoOrders bs pos2 
        pos3, fld |> FIXField.TotNoOrders
    | "69"B ->
        let pos3, fld = ReadListExecInst bs pos2 
        pos3, fld |> FIXField.ListExecInst
    | "70"B ->
        let pos3, fld = ReadAllocID bs pos2 
        pos3, fld |> FIXField.AllocID
    | "71"B ->
        let pos3, fld = ReadAllocTransType bs pos2 
        pos3, fld |> FIXField.AllocTransType
    | "72"B ->
        let pos3, fld = ReadRefAllocID bs pos2 
        pos3, fld |> FIXField.RefAllocID
    | "73"B ->
        let pos3, fld = ReadNoOrders bs pos2 
        pos3, fld |> FIXField.NoOrders
    | "74"B ->
        let pos3, fld = ReadAvgPxPrecision bs pos2 
        pos3, fld |> FIXField.AvgPxPrecision
    | "75"B ->
        let pos3, fld = ReadTradeDate bs pos2 
        pos3, fld |> FIXField.TradeDate
    | "77"B ->
        let pos3, fld = ReadPositionEffect bs pos2 
        pos3, fld |> FIXField.PositionEffect
    | "78"B ->
        let pos3, fld = ReadNoAllocs bs pos2 
        pos3, fld |> FIXField.NoAllocs
    | "79"B ->
        let pos3, fld = ReadAllocAccount bs pos2 
        pos3, fld |> FIXField.AllocAccount
    | "80"B ->
        let pos3, fld = ReadAllocQty bs pos2 
        pos3, fld |> FIXField.AllocQty
    | "81"B ->
        let pos3, fld = ReadProcessCode bs pos2 
        pos3, fld |> FIXField.ProcessCode
    | "82"B ->
        let pos3, fld = ReadNoRpts bs pos2 
        pos3, fld |> FIXField.NoRpts
    | "83"B ->
        let pos3, fld = ReadRptSeq bs pos2 
        pos3, fld |> FIXField.RptSeq
    | "84"B ->
        let pos3, fld = ReadCxlQty bs pos2 
        pos3, fld |> FIXField.CxlQty
    | "85"B ->
        let pos3, fld = ReadNoDlvyInst bs pos2 
        pos3, fld |> FIXField.NoDlvyInst
    | "87"B ->
        let pos3, fld = ReadAllocStatus bs pos2 
        pos3, fld |> FIXField.AllocStatus
    | "88"B ->
        let pos3, fld = ReadAllocRejCode bs pos2 
        pos3, fld |> FIXField.AllocRejCode
    | "93"B ->
        let pos3, fld = ReadSignature bs pos2 
        pos3, fld |> FIXField.Signature // len->string compound field
    | "90"B ->
        let pos3, fld = ReadSecureData bs pos2 
        pos3, fld |> FIXField.SecureData // len->string compound field
    | "94"B ->
        let pos3, fld = ReadEmailType bs pos2 
        pos3, fld |> FIXField.EmailType
    | "95"B ->
        let pos3, fld = ReadRawData bs pos2 
        pos3, fld |> FIXField.RawData // len->string compound field
    | "97"B ->
        let pos3, fld = ReadPossResend bs pos2 
        pos3, fld |> FIXField.PossResend
    | "98"B ->
        let pos3, fld = ReadEncryptMethod bs pos2 
        pos3, fld |> FIXField.EncryptMethod
    | "99"B ->
        let pos3, fld = ReadStopPx bs pos2 
        pos3, fld |> FIXField.StopPx
    | "100"B ->
        let pos3, fld = ReadExDestination bs pos2 
        pos3, fld |> FIXField.ExDestination
    | "102"B ->
        let pos3, fld = ReadCxlRejReason bs pos2 
        pos3, fld |> FIXField.CxlRejReason
    | "103"B ->
        let pos3, fld = ReadOrdRejReason bs pos2 
        pos3, fld |> FIXField.OrdRejReason
    | "104"B ->
        let pos3, fld = ReadIOIQualifier bs pos2 
        pos3, fld |> FIXField.IOIQualifier
    | "105"B ->
        let pos3, fld = ReadWaveNo bs pos2 
        pos3, fld |> FIXField.WaveNo
    | "106"B ->
        let pos3, fld = ReadIssuer bs pos2 
        pos3, fld |> FIXField.Issuer
    | "107"B ->
        let pos3, fld = ReadSecurityDesc bs pos2 
        pos3, fld |> FIXField.SecurityDesc
    | "108"B ->
        let pos3, fld = ReadHeartBtInt bs pos2 
        pos3, fld |> FIXField.HeartBtInt
    | "110"B ->
        let pos3, fld = ReadMinQty bs pos2 
        pos3, fld |> FIXField.MinQty
    | "111"B ->
        let pos3, fld = ReadMaxFloor bs pos2 
        pos3, fld |> FIXField.MaxFloor
    | "112"B ->
        let pos3, fld = ReadTestReqID bs pos2 
        pos3, fld |> FIXField.TestReqID
    | "113"B ->
        let pos3, fld = ReadReportToExch bs pos2 
        pos3, fld |> FIXField.ReportToExch
    | "114"B ->
        let pos3, fld = ReadLocateReqd bs pos2 
        pos3, fld |> FIXField.LocateReqd
    | "115"B ->
        let pos3, fld = ReadOnBehalfOfCompID bs pos2 
        pos3, fld |> FIXField.OnBehalfOfCompID
    | "116"B ->
        let pos3, fld = ReadOnBehalfOfSubID bs pos2 
        pos3, fld |> FIXField.OnBehalfOfSubID
    | "117"B ->
        let pos3, fld = ReadQuoteID bs pos2 
        pos3, fld |> FIXField.QuoteID
    | "118"B ->
        let pos3, fld = ReadNetMoney bs pos2 
        pos3, fld |> FIXField.NetMoney
    | "119"B ->
        let pos3, fld = ReadSettlCurrAmt bs pos2 
        pos3, fld |> FIXField.SettlCurrAmt
    | "120"B ->
        let pos3, fld = ReadSettlCurrency bs pos2 
        pos3, fld |> FIXField.SettlCurrency
    | "121"B ->
        let pos3, fld = ReadForexReq bs pos2 
        pos3, fld |> FIXField.ForexReq
    | "122"B ->
        let pos3, fld = ReadOrigSendingTime bs pos2 
        pos3, fld |> FIXField.OrigSendingTime
    | "123"B ->
        let pos3, fld = ReadGapFillFlag bs pos2 
        pos3, fld |> FIXField.GapFillFlag
    | "124"B ->
        let pos3, fld = ReadNoExecs bs pos2 
        pos3, fld |> FIXField.NoExecs
    | "126"B ->
        let pos3, fld = ReadExpireTime bs pos2 
        pos3, fld |> FIXField.ExpireTime
    | "127"B ->
        let pos3, fld = ReadDKReason bs pos2 
        pos3, fld |> FIXField.DKReason
    | "128"B ->
        let pos3, fld = ReadDeliverToCompID bs pos2 
        pos3, fld |> FIXField.DeliverToCompID
    | "129"B ->
        let pos3, fld = ReadDeliverToSubID bs pos2 
        pos3, fld |> FIXField.DeliverToSubID
    | "130"B ->
        let pos3, fld = ReadIOINaturalFlag bs pos2 
        pos3, fld |> FIXField.IOINaturalFlag
    | "131"B ->
        let pos3, fld = ReadQuoteReqID bs pos2 
        pos3, fld |> FIXField.QuoteReqID
    | "132"B ->
        let pos3, fld = ReadBidPx bs pos2 
        pos3, fld |> FIXField.BidPx
    | "133"B ->
        let pos3, fld = ReadOfferPx bs pos2 
        pos3, fld |> FIXField.OfferPx
    | "134"B ->
        let pos3, fld = ReadBidSize bs pos2 
        pos3, fld |> FIXField.BidSize
    | "135"B ->
        let pos3, fld = ReadOfferSize bs pos2 
        pos3, fld |> FIXField.OfferSize
    | "136"B ->
        let pos3, fld = ReadNoMiscFees bs pos2 
        pos3, fld |> FIXField.NoMiscFees
    | "137"B ->
        let pos3, fld = ReadMiscFeeAmt bs pos2 
        pos3, fld |> FIXField.MiscFeeAmt
    | "138"B ->
        let pos3, fld = ReadMiscFeeCurr bs pos2 
        pos3, fld |> FIXField.MiscFeeCurr
    | "139"B ->
        let pos3, fld = ReadMiscFeeType bs pos2 
        pos3, fld |> FIXField.MiscFeeType
    | "140"B ->
        let pos3, fld = ReadPrevClosePx bs pos2 
        pos3, fld |> FIXField.PrevClosePx
    | "141"B ->
        let pos3, fld = ReadResetSeqNumFlag bs pos2 
        pos3, fld |> FIXField.ResetSeqNumFlag
    | "142"B ->
        let pos3, fld = ReadSenderLocationID bs pos2 
        pos3, fld |> FIXField.SenderLocationID
    | "143"B ->
        let pos3, fld = ReadTargetLocationID bs pos2 
        pos3, fld |> FIXField.TargetLocationID
    | "144"B ->
        let pos3, fld = ReadOnBehalfOfLocationID bs pos2 
        pos3, fld |> FIXField.OnBehalfOfLocationID
    | "145"B ->
        let pos3, fld = ReadDeliverToLocationID bs pos2 
        pos3, fld |> FIXField.DeliverToLocationID
    | "146"B ->
        let pos3, fld = ReadNoRelatedSym bs pos2 
        pos3, fld |> FIXField.NoRelatedSym
    | "147"B ->
        let pos3, fld = ReadSubject bs pos2 
        pos3, fld |> FIXField.Subject
    | "148"B ->
        let pos3, fld = ReadHeadline bs pos2 
        pos3, fld |> FIXField.Headline
    | "149"B ->
        let pos3, fld = ReadURLLink bs pos2 
        pos3, fld |> FIXField.URLLink
    | "150"B ->
        let pos3, fld = ReadExecType bs pos2 
        pos3, fld |> FIXField.ExecType
    | "151"B ->
        let pos3, fld = ReadLeavesQty bs pos2 
        pos3, fld |> FIXField.LeavesQty
    | "152"B ->
        let pos3, fld = ReadCashOrderQty bs pos2 
        pos3, fld |> FIXField.CashOrderQty
    | "153"B ->
        let pos3, fld = ReadAllocAvgPx bs pos2 
        pos3, fld |> FIXField.AllocAvgPx
    | "154"B ->
        let pos3, fld = ReadAllocNetMoney bs pos2 
        pos3, fld |> FIXField.AllocNetMoney
    | "155"B ->
        let pos3, fld = ReadSettlCurrFxRate bs pos2 
        pos3, fld |> FIXField.SettlCurrFxRate
    | "156"B ->
        let pos3, fld = ReadSettlCurrFxRateCalc bs pos2 
        pos3, fld |> FIXField.SettlCurrFxRateCalc
    | "157"B ->
        let pos3, fld = ReadNumDaysInterest bs pos2 
        pos3, fld |> FIXField.NumDaysInterest
    | "158"B ->
        let pos3, fld = ReadAccruedInterestRate bs pos2 
        pos3, fld |> FIXField.AccruedInterestRate
    | "159"B ->
        let pos3, fld = ReadAccruedInterestAmt bs pos2 
        pos3, fld |> FIXField.AccruedInterestAmt
    | "160"B ->
        let pos3, fld = ReadSettlInstMode bs pos2 
        pos3, fld |> FIXField.SettlInstMode
    | "161"B ->
        let pos3, fld = ReadAllocText bs pos2 
        pos3, fld |> FIXField.AllocText
    | "162"B ->
        let pos3, fld = ReadSettlInstID bs pos2 
        pos3, fld |> FIXField.SettlInstID
    | "163"B ->
        let pos3, fld = ReadSettlInstTransType bs pos2 
        pos3, fld |> FIXField.SettlInstTransType
    | "164"B ->
        let pos3, fld = ReadEmailThreadID bs pos2 
        pos3, fld |> FIXField.EmailThreadID
    | "165"B ->
        let pos3, fld = ReadSettlInstSource bs pos2 
        pos3, fld |> FIXField.SettlInstSource
    | "167"B ->
        let pos3, fld = ReadSecurityType bs pos2 
        pos3, fld |> FIXField.SecurityType
    | "168"B ->
        let pos3, fld = ReadEffectiveTime bs pos2 
        pos3, fld |> FIXField.EffectiveTime
    | "169"B ->
        let pos3, fld = ReadStandInstDbType bs pos2 
        pos3, fld |> FIXField.StandInstDbType
    | "170"B ->
        let pos3, fld = ReadStandInstDbName bs pos2 
        pos3, fld |> FIXField.StandInstDbName
    | "171"B ->
        let pos3, fld = ReadStandInstDbID bs pos2 
        pos3, fld |> FIXField.StandInstDbID
    | "172"B ->
        let pos3, fld = ReadSettlDeliveryType bs pos2 
        pos3, fld |> FIXField.SettlDeliveryType
    | "188"B ->
        let pos3, fld = ReadBidSpotRate bs pos2 
        pos3, fld |> FIXField.BidSpotRate
    | "189"B ->
        let pos3, fld = ReadBidForwardPoints bs pos2 
        pos3, fld |> FIXField.BidForwardPoints
    | "190"B ->
        let pos3, fld = ReadOfferSpotRate bs pos2 
        pos3, fld |> FIXField.OfferSpotRate
    | "191"B ->
        let pos3, fld = ReadOfferForwardPoints bs pos2 
        pos3, fld |> FIXField.OfferForwardPoints
    | "192"B ->
        let pos3, fld = ReadOrderQty2 bs pos2 
        pos3, fld |> FIXField.OrderQty2
    | "193"B ->
        let pos3, fld = ReadSettlDate2 bs pos2 
        pos3, fld |> FIXField.SettlDate2
    | "194"B ->
        let pos3, fld = ReadLastSpotRate bs pos2 
        pos3, fld |> FIXField.LastSpotRate
    | "195"B ->
        let pos3, fld = ReadLastForwardPoints bs pos2 
        pos3, fld |> FIXField.LastForwardPoints
    | "196"B ->
        let pos3, fld = ReadAllocLinkID bs pos2 
        pos3, fld |> FIXField.AllocLinkID
    | "197"B ->
        let pos3, fld = ReadAllocLinkType bs pos2 
        pos3, fld |> FIXField.AllocLinkType
    | "198"B ->
        let pos3, fld = ReadSecondaryOrderID bs pos2 
        pos3, fld |> FIXField.SecondaryOrderID
    | "199"B ->
        let pos3, fld = ReadNoIOIQualifiers bs pos2 
        pos3, fld |> FIXField.NoIOIQualifiers
    | "200"B ->
        let pos3, fld = ReadMaturityMonthYear bs pos2 
        pos3, fld |> FIXField.MaturityMonthYear
    | "201"B ->
        let pos3, fld = ReadPutOrCall bs pos2 
        pos3, fld |> FIXField.PutOrCall
    | "202"B ->
        let pos3, fld = ReadStrikePrice bs pos2 
        pos3, fld |> FIXField.StrikePrice
    | "203"B ->
        let pos3, fld = ReadCoveredOrUncovered bs pos2 
        pos3, fld |> FIXField.CoveredOrUncovered
    | "206"B ->
        let pos3, fld = ReadOptAttribute bs pos2 
        pos3, fld |> FIXField.OptAttribute
    | "207"B ->
        let pos3, fld = ReadSecurityExchange bs pos2 
        pos3, fld |> FIXField.SecurityExchange
    | "208"B ->
        let pos3, fld = ReadNotifyBrokerOfCredit bs pos2 
        pos3, fld |> FIXField.NotifyBrokerOfCredit
    | "209"B ->
        let pos3, fld = ReadAllocHandlInst bs pos2 
        pos3, fld |> FIXField.AllocHandlInst
    | "210"B ->
        let pos3, fld = ReadMaxShow bs pos2 
        pos3, fld |> FIXField.MaxShow
    | "211"B ->
        let pos3, fld = ReadPegOffsetValue bs pos2 
        pos3, fld |> FIXField.PegOffsetValue
    | "212"B ->
        let pos3, fld = ReadXmlData bs pos2 
        pos3, fld |> FIXField.XmlData // len->string compound field
    | "214"B ->
        let pos3, fld = ReadSettlInstRefID bs pos2 
        pos3, fld |> FIXField.SettlInstRefID
    | "215"B ->
        let pos3, fld = ReadNoRoutingIDs bs pos2 
        pos3, fld |> FIXField.NoRoutingIDs
    | "216"B ->
        let pos3, fld = ReadRoutingType bs pos2 
        pos3, fld |> FIXField.RoutingType
    | "217"B ->
        let pos3, fld = ReadRoutingID bs pos2 
        pos3, fld |> FIXField.RoutingID
    | "218"B ->
        let pos3, fld = ReadSpread bs pos2 
        pos3, fld |> FIXField.Spread
    | "220"B ->
        let pos3, fld = ReadBenchmarkCurveCurrency bs pos2 
        pos3, fld |> FIXField.BenchmarkCurveCurrency
    | "221"B ->
        let pos3, fld = ReadBenchmarkCurveName bs pos2 
        pos3, fld |> FIXField.BenchmarkCurveName
    | "222"B ->
        let pos3, fld = ReadBenchmarkCurvePoint bs pos2 
        pos3, fld |> FIXField.BenchmarkCurvePoint
    | "223"B ->
        let pos3, fld = ReadCouponRate bs pos2 
        pos3, fld |> FIXField.CouponRate
    | "224"B ->
        let pos3, fld = ReadCouponPaymentDate bs pos2 
        pos3, fld |> FIXField.CouponPaymentDate
    | "225"B ->
        let pos3, fld = ReadIssueDate bs pos2 
        pos3, fld |> FIXField.IssueDate
    | "226"B ->
        let pos3, fld = ReadRepurchaseTerm bs pos2 
        pos3, fld |> FIXField.RepurchaseTerm
    | "227"B ->
        let pos3, fld = ReadRepurchaseRate bs pos2 
        pos3, fld |> FIXField.RepurchaseRate
    | "228"B ->
        let pos3, fld = ReadFactor bs pos2 
        pos3, fld |> FIXField.Factor
    | "229"B ->
        let pos3, fld = ReadTradeOriginationDate bs pos2 
        pos3, fld |> FIXField.TradeOriginationDate
    | "230"B ->
        let pos3, fld = ReadExDate bs pos2 
        pos3, fld |> FIXField.ExDate
    | "231"B ->
        let pos3, fld = ReadContractMultiplier bs pos2 
        pos3, fld |> FIXField.ContractMultiplier
    | "232"B ->
        let pos3, fld = ReadNoStipulations bs pos2 
        pos3, fld |> FIXField.NoStipulations
    | "233"B ->
        let pos3, fld = ReadStipulationType bs pos2 
        pos3, fld |> FIXField.StipulationType
    | "234"B ->
        let pos3, fld = ReadStipulationValue bs pos2 
        pos3, fld |> FIXField.StipulationValue
    | "235"B ->
        let pos3, fld = ReadYieldType bs pos2 
        pos3, fld |> FIXField.YieldType
    | "236"B ->
        let pos3, fld = ReadYield bs pos2 
        pos3, fld |> FIXField.Yield
    | "237"B ->
        let pos3, fld = ReadTotalTakedown bs pos2 
        pos3, fld |> FIXField.TotalTakedown
    | "238"B ->
        let pos3, fld = ReadConcession bs pos2 
        pos3, fld |> FIXField.Concession
    | "239"B ->
        let pos3, fld = ReadRepoCollateralSecurityType bs pos2 
        pos3, fld |> FIXField.RepoCollateralSecurityType
    | "240"B ->
        let pos3, fld = ReadRedemptionDate bs pos2 
        pos3, fld |> FIXField.RedemptionDate
    | "241"B ->
        let pos3, fld = ReadUnderlyingCouponPaymentDate bs pos2 
        pos3, fld |> FIXField.UnderlyingCouponPaymentDate
    | "242"B ->
        let pos3, fld = ReadUnderlyingIssueDate bs pos2 
        pos3, fld |> FIXField.UnderlyingIssueDate
    | "243"B ->
        let pos3, fld = ReadUnderlyingRepoCollateralSecurityType bs pos2 
        pos3, fld |> FIXField.UnderlyingRepoCollateralSecurityType
    | "244"B ->
        let pos3, fld = ReadUnderlyingRepurchaseTerm bs pos2 
        pos3, fld |> FIXField.UnderlyingRepurchaseTerm
    | "245"B ->
        let pos3, fld = ReadUnderlyingRepurchaseRate bs pos2 
        pos3, fld |> FIXField.UnderlyingRepurchaseRate
    | "246"B ->
        let pos3, fld = ReadUnderlyingFactor bs pos2 
        pos3, fld |> FIXField.UnderlyingFactor
    | "247"B ->
        let pos3, fld = ReadUnderlyingRedemptionDate bs pos2 
        pos3, fld |> FIXField.UnderlyingRedemptionDate
    | "248"B ->
        let pos3, fld = ReadLegCouponPaymentDate bs pos2 
        pos3, fld |> FIXField.LegCouponPaymentDate
    | "249"B ->
        let pos3, fld = ReadLegIssueDate bs pos2 
        pos3, fld |> FIXField.LegIssueDate
    | "250"B ->
        let pos3, fld = ReadLegRepoCollateralSecurityType bs pos2 
        pos3, fld |> FIXField.LegRepoCollateralSecurityType
    | "251"B ->
        let pos3, fld = ReadLegRepurchaseTerm bs pos2 
        pos3, fld |> FIXField.LegRepurchaseTerm
    | "252"B ->
        let pos3, fld = ReadLegRepurchaseRate bs pos2 
        pos3, fld |> FIXField.LegRepurchaseRate
    | "253"B ->
        let pos3, fld = ReadLegFactor bs pos2 
        pos3, fld |> FIXField.LegFactor
    | "254"B ->
        let pos3, fld = ReadLegRedemptionDate bs pos2 
        pos3, fld |> FIXField.LegRedemptionDate
    | "255"B ->
        let pos3, fld = ReadCreditRating bs pos2 
        pos3, fld |> FIXField.CreditRating
    | "256"B ->
        let pos3, fld = ReadUnderlyingCreditRating bs pos2 
        pos3, fld |> FIXField.UnderlyingCreditRating
    | "257"B ->
        let pos3, fld = ReadLegCreditRating bs pos2 
        pos3, fld |> FIXField.LegCreditRating
    | "258"B ->
        let pos3, fld = ReadTradedFlatSwitch bs pos2 
        pos3, fld |> FIXField.TradedFlatSwitch
    | "259"B ->
        let pos3, fld = ReadBasisFeatureDate bs pos2 
        pos3, fld |> FIXField.BasisFeatureDate
    | "260"B ->
        let pos3, fld = ReadBasisFeaturePrice bs pos2 
        pos3, fld |> FIXField.BasisFeaturePrice
    | "262"B ->
        let pos3, fld = ReadMDReqID bs pos2 
        pos3, fld |> FIXField.MDReqID
    | "263"B ->
        let pos3, fld = ReadSubscriptionRequestType bs pos2 
        pos3, fld |> FIXField.SubscriptionRequestType
    | "264"B ->
        let pos3, fld = ReadMarketDepth bs pos2 
        pos3, fld |> FIXField.MarketDepth
    | "265"B ->
        let pos3, fld = ReadMDUpdateType bs pos2 
        pos3, fld |> FIXField.MDUpdateType
    | "266"B ->
        let pos3, fld = ReadAggregatedBook bs pos2 
        pos3, fld |> FIXField.AggregatedBook
    | "267"B ->
        let pos3, fld = ReadNoMDEntryTypes bs pos2 
        pos3, fld |> FIXField.NoMDEntryTypes
    | "268"B ->
        let pos3, fld = ReadNoMDEntries bs pos2 
        pos3, fld |> FIXField.NoMDEntries
    | "269"B ->
        let pos3, fld = ReadMDEntryType bs pos2 
        pos3, fld |> FIXField.MDEntryType
    | "270"B ->
        let pos3, fld = ReadMDEntryPx bs pos2 
        pos3, fld |> FIXField.MDEntryPx
    | "271"B ->
        let pos3, fld = ReadMDEntrySize bs pos2 
        pos3, fld |> FIXField.MDEntrySize
    | "272"B ->
        let pos3, fld = ReadMDEntryDate bs pos2 
        pos3, fld |> FIXField.MDEntryDate
    | "273"B ->
        let pos3, fld = ReadMDEntryTime bs pos2 
        pos3, fld |> FIXField.MDEntryTime
    | "274"B ->
        let pos3, fld = ReadTickDirection bs pos2 
        pos3, fld |> FIXField.TickDirection
    | "275"B ->
        let pos3, fld = ReadMDMkt bs pos2 
        pos3, fld |> FIXField.MDMkt
    | "276"B ->
        let pos3, fld = ReadQuoteCondition bs pos2 
        pos3, fld |> FIXField.QuoteCondition
    | "277"B ->
        let pos3, fld = ReadTradeCondition bs pos2 
        pos3, fld |> FIXField.TradeCondition
    | "278"B ->
        let pos3, fld = ReadMDEntryID bs pos2 
        pos3, fld |> FIXField.MDEntryID
    | "279"B ->
        let pos3, fld = ReadMDUpdateAction bs pos2 
        pos3, fld |> FIXField.MDUpdateAction
    | "280"B ->
        let pos3, fld = ReadMDEntryRefID bs pos2 
        pos3, fld |> FIXField.MDEntryRefID
    | "281"B ->
        let pos3, fld = ReadMDReqRejReason bs pos2 
        pos3, fld |> FIXField.MDReqRejReason
    | "282"B ->
        let pos3, fld = ReadMDEntryOriginator bs pos2 
        pos3, fld |> FIXField.MDEntryOriginator
    | "283"B ->
        let pos3, fld = ReadLocationID bs pos2 
        pos3, fld |> FIXField.LocationID
    | "284"B ->
        let pos3, fld = ReadDeskID bs pos2 
        pos3, fld |> FIXField.DeskID
    | "285"B ->
        let pos3, fld = ReadDeleteReason bs pos2 
        pos3, fld |> FIXField.DeleteReason
    | "286"B ->
        let pos3, fld = ReadOpenCloseSettlFlag bs pos2 
        pos3, fld |> FIXField.OpenCloseSettlFlag
    | "287"B ->
        let pos3, fld = ReadSellerDays bs pos2 
        pos3, fld |> FIXField.SellerDays
    | "288"B ->
        let pos3, fld = ReadMDEntryBuyer bs pos2 
        pos3, fld |> FIXField.MDEntryBuyer
    | "289"B ->
        let pos3, fld = ReadMDEntrySeller bs pos2 
        pos3, fld |> FIXField.MDEntrySeller
    | "290"B ->
        let pos3, fld = ReadMDEntryPositionNo bs pos2 
        pos3, fld |> FIXField.MDEntryPositionNo
    | "291"B ->
        let pos3, fld = ReadFinancialStatus bs pos2 
        pos3, fld |> FIXField.FinancialStatus
    | "292"B ->
        let pos3, fld = ReadCorporateAction bs pos2 
        pos3, fld |> FIXField.CorporateAction
    | "293"B ->
        let pos3, fld = ReadDefBidSize bs pos2 
        pos3, fld |> FIXField.DefBidSize
    | "294"B ->
        let pos3, fld = ReadDefOfferSize bs pos2 
        pos3, fld |> FIXField.DefOfferSize
    | "295"B ->
        let pos3, fld = ReadNoQuoteEntries bs pos2 
        pos3, fld |> FIXField.NoQuoteEntries
    | "296"B ->
        let pos3, fld = ReadNoQuoteSets bs pos2 
        pos3, fld |> FIXField.NoQuoteSets
    | "297"B ->
        let pos3, fld = ReadQuoteStatus bs pos2 
        pos3, fld |> FIXField.QuoteStatus
    | "298"B ->
        let pos3, fld = ReadQuoteCancelType bs pos2 
        pos3, fld |> FIXField.QuoteCancelType
    | "299"B ->
        let pos3, fld = ReadQuoteEntryID bs pos2 
        pos3, fld |> FIXField.QuoteEntryID
    | "300"B ->
        let pos3, fld = ReadQuoteRejectReason bs pos2 
        pos3, fld |> FIXField.QuoteRejectReason
    | "301"B ->
        let pos3, fld = ReadQuoteResponseLevel bs pos2 
        pos3, fld |> FIXField.QuoteResponseLevel
    | "302"B ->
        let pos3, fld = ReadQuoteSetID bs pos2 
        pos3, fld |> FIXField.QuoteSetID
    | "303"B ->
        let pos3, fld = ReadQuoteRequestType bs pos2 
        pos3, fld |> FIXField.QuoteRequestType
    | "304"B ->
        let pos3, fld = ReadTotNoQuoteEntries bs pos2 
        pos3, fld |> FIXField.TotNoQuoteEntries
    | "305"B ->
        let pos3, fld = ReadUnderlyingSecurityIDSource bs pos2 
        pos3, fld |> FIXField.UnderlyingSecurityIDSource
    | "306"B ->
        let pos3, fld = ReadUnderlyingIssuer bs pos2 
        pos3, fld |> FIXField.UnderlyingIssuer
    | "307"B ->
        let pos3, fld = ReadUnderlyingSecurityDesc bs pos2 
        pos3, fld |> FIXField.UnderlyingSecurityDesc
    | "308"B ->
        let pos3, fld = ReadUnderlyingSecurityExchange bs pos2 
        pos3, fld |> FIXField.UnderlyingSecurityExchange
    | "309"B ->
        let pos3, fld = ReadUnderlyingSecurityID bs pos2 
        pos3, fld |> FIXField.UnderlyingSecurityID
    | "310"B ->
        let pos3, fld = ReadUnderlyingSecurityType bs pos2 
        pos3, fld |> FIXField.UnderlyingSecurityType
    | "311"B ->
        let pos3, fld = ReadUnderlyingSymbol bs pos2 
        pos3, fld |> FIXField.UnderlyingSymbol
    | "312"B ->
        let pos3, fld = ReadUnderlyingSymbolSfx bs pos2 
        pos3, fld |> FIXField.UnderlyingSymbolSfx
    | "313"B ->
        let pos3, fld = ReadUnderlyingMaturityMonthYear bs pos2 
        pos3, fld |> FIXField.UnderlyingMaturityMonthYear
    | "315"B ->
        let pos3, fld = ReadUnderlyingPutOrCall bs pos2 
        pos3, fld |> FIXField.UnderlyingPutOrCall
    | "316"B ->
        let pos3, fld = ReadUnderlyingStrikePrice bs pos2 
        pos3, fld |> FIXField.UnderlyingStrikePrice
    | "317"B ->
        let pos3, fld = ReadUnderlyingOptAttribute bs pos2 
        pos3, fld |> FIXField.UnderlyingOptAttribute
    | "318"B ->
        let pos3, fld = ReadUnderlyingCurrency bs pos2 
        pos3, fld |> FIXField.UnderlyingCurrency
    | "320"B ->
        let pos3, fld = ReadSecurityReqID bs pos2 
        pos3, fld |> FIXField.SecurityReqID
    | "321"B ->
        let pos3, fld = ReadSecurityRequestType bs pos2 
        pos3, fld |> FIXField.SecurityRequestType
    | "322"B ->
        let pos3, fld = ReadSecurityResponseID bs pos2 
        pos3, fld |> FIXField.SecurityResponseID
    | "323"B ->
        let pos3, fld = ReadSecurityResponseType bs pos2 
        pos3, fld |> FIXField.SecurityResponseType
    | "324"B ->
        let pos3, fld = ReadSecurityStatusReqID bs pos2 
        pos3, fld |> FIXField.SecurityStatusReqID
    | "325"B ->
        let pos3, fld = ReadUnsolicitedIndicator bs pos2 
        pos3, fld |> FIXField.UnsolicitedIndicator
    | "326"B ->
        let pos3, fld = ReadSecurityTradingStatus bs pos2 
        pos3, fld |> FIXField.SecurityTradingStatus
    | "327"B ->
        let pos3, fld = ReadHaltReason bs pos2 
        pos3, fld |> FIXField.HaltReason
    | "328"B ->
        let pos3, fld = ReadInViewOfCommon bs pos2 
        pos3, fld |> FIXField.InViewOfCommon
    | "329"B ->
        let pos3, fld = ReadDueToRelated bs pos2 
        pos3, fld |> FIXField.DueToRelated
    | "330"B ->
        let pos3, fld = ReadBuyVolume bs pos2 
        pos3, fld |> FIXField.BuyVolume
    | "331"B ->
        let pos3, fld = ReadSellVolume bs pos2 
        pos3, fld |> FIXField.SellVolume
    | "332"B ->
        let pos3, fld = ReadHighPx bs pos2 
        pos3, fld |> FIXField.HighPx
    | "333"B ->
        let pos3, fld = ReadLowPx bs pos2 
        pos3, fld |> FIXField.LowPx
    | "334"B ->
        let pos3, fld = ReadAdjustment bs pos2 
        pos3, fld |> FIXField.Adjustment
    | "335"B ->
        let pos3, fld = ReadTradSesReqID bs pos2 
        pos3, fld |> FIXField.TradSesReqID
    | "336"B ->
        let pos3, fld = ReadTradingSessionID bs pos2 
        pos3, fld |> FIXField.TradingSessionID
    | "337"B ->
        let pos3, fld = ReadContraTrader bs pos2 
        pos3, fld |> FIXField.ContraTrader
    | "338"B ->
        let pos3, fld = ReadTradSesMethod bs pos2 
        pos3, fld |> FIXField.TradSesMethod
    | "339"B ->
        let pos3, fld = ReadTradSesMode bs pos2 
        pos3, fld |> FIXField.TradSesMode
    | "340"B ->
        let pos3, fld = ReadTradSesStatus bs pos2 
        pos3, fld |> FIXField.TradSesStatus
    | "341"B ->
        let pos3, fld = ReadTradSesStartTime bs pos2 
        pos3, fld |> FIXField.TradSesStartTime
    | "342"B ->
        let pos3, fld = ReadTradSesOpenTime bs pos2 
        pos3, fld |> FIXField.TradSesOpenTime
    | "343"B ->
        let pos3, fld = ReadTradSesPreCloseTime bs pos2 
        pos3, fld |> FIXField.TradSesPreCloseTime
    | "344"B ->
        let pos3, fld = ReadTradSesCloseTime bs pos2 
        pos3, fld |> FIXField.TradSesCloseTime
    | "345"B ->
        let pos3, fld = ReadTradSesEndTime bs pos2 
        pos3, fld |> FIXField.TradSesEndTime
    | "346"B ->
        let pos3, fld = ReadNumberOfOrders bs pos2 
        pos3, fld |> FIXField.NumberOfOrders
    | "347"B ->
        let pos3, fld = ReadMessageEncoding bs pos2 
        pos3, fld |> FIXField.MessageEncoding
    | "348"B ->
        let pos3, fld = ReadEncodedIssuer bs pos2 
        pos3, fld |> FIXField.EncodedIssuer // len->string compound field
    | "350"B ->
        let pos3, fld = ReadEncodedSecurityDesc bs pos2 
        pos3, fld |> FIXField.EncodedSecurityDesc // len->string compound field
    | "352"B ->
        let pos3, fld = ReadEncodedListExecInst bs pos2 
        pos3, fld |> FIXField.EncodedListExecInst // len->string compound field
    | "354"B ->
        let pos3, fld = ReadEncodedText bs pos2 
        pos3, fld |> FIXField.EncodedText // len->string compound field
    | "356"B ->
        let pos3, fld = ReadEncodedSubject bs pos2 
        pos3, fld |> FIXField.EncodedSubject // len->string compound field
    | "358"B ->
        let pos3, fld = ReadEncodedHeadline bs pos2 
        pos3, fld |> FIXField.EncodedHeadline // len->string compound field
    | "360"B ->
        let pos3, fld = ReadEncodedAllocText bs pos2 
        pos3, fld |> FIXField.EncodedAllocText // len->string compound field
    | "362"B ->
        let pos3, fld = ReadEncodedUnderlyingIssuer bs pos2 
        pos3, fld |> FIXField.EncodedUnderlyingIssuer // len->string compound field
    | "364"B ->
        let pos3, fld = ReadEncodedUnderlyingSecurityDesc bs pos2 
        pos3, fld |> FIXField.EncodedUnderlyingSecurityDesc // len->string compound field
    | "366"B ->
        let pos3, fld = ReadAllocPrice bs pos2 
        pos3, fld |> FIXField.AllocPrice
    | "367"B ->
        let pos3, fld = ReadQuoteSetValidUntilTime bs pos2 
        pos3, fld |> FIXField.QuoteSetValidUntilTime
    | "368"B ->
        let pos3, fld = ReadQuoteEntryRejectReason bs pos2 
        pos3, fld |> FIXField.QuoteEntryRejectReason
    | "369"B ->
        let pos3, fld = ReadLastMsgSeqNumProcessed bs pos2 
        pos3, fld |> FIXField.LastMsgSeqNumProcessed
    | "371"B ->
        let pos3, fld = ReadRefTagID bs pos2 
        pos3, fld |> FIXField.RefTagID
    | "372"B ->
        let pos3, fld = ReadRefMsgType bs pos2 
        pos3, fld |> FIXField.RefMsgType
    | "373"B ->
        let pos3, fld = ReadSessionRejectReason bs pos2 
        pos3, fld |> FIXField.SessionRejectReason
    | "374"B ->
        let pos3, fld = ReadBidRequestTransType bs pos2 
        pos3, fld |> FIXField.BidRequestTransType
    | "375"B ->
        let pos3, fld = ReadContraBroker bs pos2 
        pos3, fld |> FIXField.ContraBroker
    | "376"B ->
        let pos3, fld = ReadComplianceID bs pos2 
        pos3, fld |> FIXField.ComplianceID
    | "377"B ->
        let pos3, fld = ReadSolicitedFlag bs pos2 
        pos3, fld |> FIXField.SolicitedFlag
    | "378"B ->
        let pos3, fld = ReadExecRestatementReason bs pos2 
        pos3, fld |> FIXField.ExecRestatementReason
    | "379"B ->
        let pos3, fld = ReadBusinessRejectRefID bs pos2 
        pos3, fld |> FIXField.BusinessRejectRefID
    | "380"B ->
        let pos3, fld = ReadBusinessRejectReason bs pos2 
        pos3, fld |> FIXField.BusinessRejectReason
    | "381"B ->
        let pos3, fld = ReadGrossTradeAmt bs pos2 
        pos3, fld |> FIXField.GrossTradeAmt
    | "382"B ->
        let pos3, fld = ReadNoContraBrokers bs pos2 
        pos3, fld |> FIXField.NoContraBrokers
    | "383"B ->
        let pos3, fld = ReadMaxMessageSize bs pos2 
        pos3, fld |> FIXField.MaxMessageSize
    | "384"B ->
        let pos3, fld = ReadNoMsgTypes bs pos2 
        pos3, fld |> FIXField.NoMsgTypes
    | "385"B ->
        let pos3, fld = ReadMsgDirection bs pos2 
        pos3, fld |> FIXField.MsgDirection
    | "386"B ->
        let pos3, fld = ReadNoTradingSessions bs pos2 
        pos3, fld |> FIXField.NoTradingSessions
    | "387"B ->
        let pos3, fld = ReadTotalVolumeTraded bs pos2 
        pos3, fld |> FIXField.TotalVolumeTraded
    | "388"B ->
        let pos3, fld = ReadDiscretionInst bs pos2 
        pos3, fld |> FIXField.DiscretionInst
    | "389"B ->
        let pos3, fld = ReadDiscretionOffsetValue bs pos2 
        pos3, fld |> FIXField.DiscretionOffsetValue
    | "390"B ->
        let pos3, fld = ReadBidID bs pos2 
        pos3, fld |> FIXField.BidID
    | "391"B ->
        let pos3, fld = ReadClientBidID bs pos2 
        pos3, fld |> FIXField.ClientBidID
    | "392"B ->
        let pos3, fld = ReadListName bs pos2 
        pos3, fld |> FIXField.ListName
    | "393"B ->
        let pos3, fld = ReadTotNoRelatedSym bs pos2 
        pos3, fld |> FIXField.TotNoRelatedSym
    | "394"B ->
        let pos3, fld = ReadBidType bs pos2 
        pos3, fld |> FIXField.BidType
    | "395"B ->
        let pos3, fld = ReadNumTickets bs pos2 
        pos3, fld |> FIXField.NumTickets
    | "396"B ->
        let pos3, fld = ReadSideValue1 bs pos2 
        pos3, fld |> FIXField.SideValue1
    | "397"B ->
        let pos3, fld = ReadSideValue2 bs pos2 
        pos3, fld |> FIXField.SideValue2
    | "398"B ->
        let pos3, fld = ReadNoBidDescriptors bs pos2 
        pos3, fld |> FIXField.NoBidDescriptors
    | "399"B ->
        let pos3, fld = ReadBidDescriptorType bs pos2 
        pos3, fld |> FIXField.BidDescriptorType
    | "400"B ->
        let pos3, fld = ReadBidDescriptor bs pos2 
        pos3, fld |> FIXField.BidDescriptor
    | "401"B ->
        let pos3, fld = ReadSideValueInd bs pos2 
        pos3, fld |> FIXField.SideValueInd
    | "402"B ->
        let pos3, fld = ReadLiquidityPctLow bs pos2 
        pos3, fld |> FIXField.LiquidityPctLow
    | "403"B ->
        let pos3, fld = ReadLiquidityPctHigh bs pos2 
        pos3, fld |> FIXField.LiquidityPctHigh
    | "404"B ->
        let pos3, fld = ReadLiquidityValue bs pos2 
        pos3, fld |> FIXField.LiquidityValue
    | "405"B ->
        let pos3, fld = ReadEFPTrackingError bs pos2 
        pos3, fld |> FIXField.EFPTrackingError
    | "406"B ->
        let pos3, fld = ReadFairValue bs pos2 
        pos3, fld |> FIXField.FairValue
    | "407"B ->
        let pos3, fld = ReadOutsideIndexPct bs pos2 
        pos3, fld |> FIXField.OutsideIndexPct
    | "408"B ->
        let pos3, fld = ReadValueOfFutures bs pos2 
        pos3, fld |> FIXField.ValueOfFutures
    | "409"B ->
        let pos3, fld = ReadLiquidityIndType bs pos2 
        pos3, fld |> FIXField.LiquidityIndType
    | "410"B ->
        let pos3, fld = ReadWtAverageLiquidity bs pos2 
        pos3, fld |> FIXField.WtAverageLiquidity
    | "411"B ->
        let pos3, fld = ReadExchangeForPhysical bs pos2 
        pos3, fld |> FIXField.ExchangeForPhysical
    | "412"B ->
        let pos3, fld = ReadOutMainCntryUIndex bs pos2 
        pos3, fld |> FIXField.OutMainCntryUIndex
    | "413"B ->
        let pos3, fld = ReadCrossPercent bs pos2 
        pos3, fld |> FIXField.CrossPercent
    | "414"B ->
        let pos3, fld = ReadProgRptReqs bs pos2 
        pos3, fld |> FIXField.ProgRptReqs
    | "415"B ->
        let pos3, fld = ReadProgPeriodInterval bs pos2 
        pos3, fld |> FIXField.ProgPeriodInterval
    | "416"B ->
        let pos3, fld = ReadIncTaxInd bs pos2 
        pos3, fld |> FIXField.IncTaxInd
    | "417"B ->
        let pos3, fld = ReadNumBidders bs pos2 
        pos3, fld |> FIXField.NumBidders
    | "418"B ->
        let pos3, fld = ReadBidTradeType bs pos2 
        pos3, fld |> FIXField.BidTradeType
    | "419"B ->
        let pos3, fld = ReadBasisPxType bs pos2 
        pos3, fld |> FIXField.BasisPxType
    | "420"B ->
        let pos3, fld = ReadNoBidComponents bs pos2 
        pos3, fld |> FIXField.NoBidComponents
    | "421"B ->
        let pos3, fld = ReadCountry bs pos2 
        pos3, fld |> FIXField.Country
    | "422"B ->
        let pos3, fld = ReadTotNoStrikes bs pos2 
        pos3, fld |> FIXField.TotNoStrikes
    | "423"B ->
        let pos3, fld = ReadPriceType bs pos2 
        pos3, fld |> FIXField.PriceType
    | "424"B ->
        let pos3, fld = ReadDayOrderQty bs pos2 
        pos3, fld |> FIXField.DayOrderQty
    | "425"B ->
        let pos3, fld = ReadDayCumQty bs pos2 
        pos3, fld |> FIXField.DayCumQty
    | "426"B ->
        let pos3, fld = ReadDayAvgPx bs pos2 
        pos3, fld |> FIXField.DayAvgPx
    | "427"B ->
        let pos3, fld = ReadGTBookingInst bs pos2 
        pos3, fld |> FIXField.GTBookingInst
    | "428"B ->
        let pos3, fld = ReadNoStrikes bs pos2 
        pos3, fld |> FIXField.NoStrikes
    | "429"B ->
        let pos3, fld = ReadListStatusType bs pos2 
        pos3, fld |> FIXField.ListStatusType
    | "430"B ->
        let pos3, fld = ReadNetGrossInd bs pos2 
        pos3, fld |> FIXField.NetGrossInd
    | "431"B ->
        let pos3, fld = ReadListOrderStatus bs pos2 
        pos3, fld |> FIXField.ListOrderStatus
    | "432"B ->
        let pos3, fld = ReadExpireDate bs pos2 
        pos3, fld |> FIXField.ExpireDate
    | "433"B ->
        let pos3, fld = ReadListExecInstType bs pos2 
        pos3, fld |> FIXField.ListExecInstType
    | "434"B ->
        let pos3, fld = ReadCxlRejResponseTo bs pos2 
        pos3, fld |> FIXField.CxlRejResponseTo
    | "435"B ->
        let pos3, fld = ReadUnderlyingCouponRate bs pos2 
        pos3, fld |> FIXField.UnderlyingCouponRate
    | "436"B ->
        let pos3, fld = ReadUnderlyingContractMultiplier bs pos2 
        pos3, fld |> FIXField.UnderlyingContractMultiplier
    | "437"B ->
        let pos3, fld = ReadContraTradeQty bs pos2 
        pos3, fld |> FIXField.ContraTradeQty
    | "438"B ->
        let pos3, fld = ReadContraTradeTime bs pos2 
        pos3, fld |> FIXField.ContraTradeTime
    | "441"B ->
        let pos3, fld = ReadLiquidityNumSecurities bs pos2 
        pos3, fld |> FIXField.LiquidityNumSecurities
    | "442"B ->
        let pos3, fld = ReadMultiLegReportingType bs pos2 
        pos3, fld |> FIXField.MultiLegReportingType
    | "443"B ->
        let pos3, fld = ReadStrikeTime bs pos2 
        pos3, fld |> FIXField.StrikeTime
    | "444"B ->
        let pos3, fld = ReadListStatusText bs pos2 
        pos3, fld |> FIXField.ListStatusText
    | "445"B ->
        let pos3, fld = ReadEncodedListStatusText bs pos2 
        pos3, fld |> FIXField.EncodedListStatusText // len->string compound field
    | "447"B ->
        let pos3, fld = ReadPartyIDSource bs pos2 
        pos3, fld |> FIXField.PartyIDSource
    | "448"B ->
        let pos3, fld = ReadPartyID bs pos2 
        pos3, fld |> FIXField.PartyID
    | "451"B ->
        let pos3, fld = ReadNetChgPrevDay bs pos2 
        pos3, fld |> FIXField.NetChgPrevDay
    | "452"B ->
        let pos3, fld = ReadPartyRole bs pos2 
        pos3, fld |> FIXField.PartyRole
    | "453"B ->
        let pos3, fld = ReadNoPartyIDs bs pos2 
        pos3, fld |> FIXField.NoPartyIDs
    | "454"B ->
        let pos3, fld = ReadNoSecurityAltID bs pos2 
        pos3, fld |> FIXField.NoSecurityAltID
    | "455"B ->
        let pos3, fld = ReadSecurityAltID bs pos2 
        pos3, fld |> FIXField.SecurityAltID
    | "456"B ->
        let pos3, fld = ReadSecurityAltIDSource bs pos2 
        pos3, fld |> FIXField.SecurityAltIDSource
    | "457"B ->
        let pos3, fld = ReadNoUnderlyingSecurityAltID bs pos2 
        pos3, fld |> FIXField.NoUnderlyingSecurityAltID
    | "458"B ->
        let pos3, fld = ReadUnderlyingSecurityAltID bs pos2 
        pos3, fld |> FIXField.UnderlyingSecurityAltID
    | "459"B ->
        let pos3, fld = ReadUnderlyingSecurityAltIDSource bs pos2 
        pos3, fld |> FIXField.UnderlyingSecurityAltIDSource
    | "460"B ->
        let pos3, fld = ReadProduct bs pos2 
        pos3, fld |> FIXField.Product
    | "461"B ->
        let pos3, fld = ReadCFICode bs pos2 
        pos3, fld |> FIXField.CFICode
    | "462"B ->
        let pos3, fld = ReadUnderlyingProduct bs pos2 
        pos3, fld |> FIXField.UnderlyingProduct
    | "463"B ->
        let pos3, fld = ReadUnderlyingCFICode bs pos2 
        pos3, fld |> FIXField.UnderlyingCFICode
    | "464"B ->
        let pos3, fld = ReadTestMessageIndicator bs pos2 
        pos3, fld |> FIXField.TestMessageIndicator
    | "465"B ->
        let pos3, fld = ReadQuantityType bs pos2 
        pos3, fld |> FIXField.QuantityType
    | "466"B ->
        let pos3, fld = ReadBookingRefID bs pos2 
        pos3, fld |> FIXField.BookingRefID
    | "467"B ->
        let pos3, fld = ReadIndividualAllocID bs pos2 
        pos3, fld |> FIXField.IndividualAllocID
    | "468"B ->
        let pos3, fld = ReadRoundingDirection bs pos2 
        pos3, fld |> FIXField.RoundingDirection
    | "469"B ->
        let pos3, fld = ReadRoundingModulus bs pos2 
        pos3, fld |> FIXField.RoundingModulus
    | "470"B ->
        let pos3, fld = ReadCountryOfIssue bs pos2 
        pos3, fld |> FIXField.CountryOfIssue
    | "471"B ->
        let pos3, fld = ReadStateOrProvinceOfIssue bs pos2 
        pos3, fld |> FIXField.StateOrProvinceOfIssue
    | "472"B ->
        let pos3, fld = ReadLocaleOfIssue bs pos2 
        pos3, fld |> FIXField.LocaleOfIssue
    | "473"B ->
        let pos3, fld = ReadNoRegistDtls bs pos2 
        pos3, fld |> FIXField.NoRegistDtls
    | "474"B ->
        let pos3, fld = ReadMailingDtls bs pos2 
        pos3, fld |> FIXField.MailingDtls
    | "475"B ->
        let pos3, fld = ReadInvestorCountryOfResidence bs pos2 
        pos3, fld |> FIXField.InvestorCountryOfResidence
    | "476"B ->
        let pos3, fld = ReadPaymentRef bs pos2 
        pos3, fld |> FIXField.PaymentRef
    | "477"B ->
        let pos3, fld = ReadDistribPaymentMethod bs pos2 
        pos3, fld |> FIXField.DistribPaymentMethod
    | "478"B ->
        let pos3, fld = ReadCashDistribCurr bs pos2 
        pos3, fld |> FIXField.CashDistribCurr
    | "479"B ->
        let pos3, fld = ReadCommCurrency bs pos2 
        pos3, fld |> FIXField.CommCurrency
    | "480"B ->
        let pos3, fld = ReadCancellationRights bs pos2 
        pos3, fld |> FIXField.CancellationRights
    | "481"B ->
        let pos3, fld = ReadMoneyLaunderingStatus bs pos2 
        pos3, fld |> FIXField.MoneyLaunderingStatus
    | "482"B ->
        let pos3, fld = ReadMailingInst bs pos2 
        pos3, fld |> FIXField.MailingInst
    | "483"B ->
        let pos3, fld = ReadTransBkdTime bs pos2 
        pos3, fld |> FIXField.TransBkdTime
    | "484"B ->
        let pos3, fld = ReadExecPriceType bs pos2 
        pos3, fld |> FIXField.ExecPriceType
    | "485"B ->
        let pos3, fld = ReadExecPriceAdjustment bs pos2 
        pos3, fld |> FIXField.ExecPriceAdjustment
    | "486"B ->
        let pos3, fld = ReadDateOfBirth bs pos2 
        pos3, fld |> FIXField.DateOfBirth
    | "487"B ->
        let pos3, fld = ReadTradeReportTransType bs pos2 
        pos3, fld |> FIXField.TradeReportTransType
    | "488"B ->
        let pos3, fld = ReadCardHolderName bs pos2 
        pos3, fld |> FIXField.CardHolderName
    | "489"B ->
        let pos3, fld = ReadCardNumber bs pos2 
        pos3, fld |> FIXField.CardNumber
    | "490"B ->
        let pos3, fld = ReadCardExpDate bs pos2 
        pos3, fld |> FIXField.CardExpDate
    | "491"B ->
        let pos3, fld = ReadCardIssNum bs pos2 
        pos3, fld |> FIXField.CardIssNum
    | "492"B ->
        let pos3, fld = ReadPaymentMethod bs pos2 
        pos3, fld |> FIXField.PaymentMethod
    | "493"B ->
        let pos3, fld = ReadRegistAcctType bs pos2 
        pos3, fld |> FIXField.RegistAcctType
    | "494"B ->
        let pos3, fld = ReadDesignation bs pos2 
        pos3, fld |> FIXField.Designation
    | "495"B ->
        let pos3, fld = ReadTaxAdvantageType bs pos2 
        pos3, fld |> FIXField.TaxAdvantageType
    | "496"B ->
        let pos3, fld = ReadRegistRejReasonText bs pos2 
        pos3, fld |> FIXField.RegistRejReasonText
    | "497"B ->
        let pos3, fld = ReadFundRenewWaiv bs pos2 
        pos3, fld |> FIXField.FundRenewWaiv
    | "498"B ->
        let pos3, fld = ReadCashDistribAgentName bs pos2 
        pos3, fld |> FIXField.CashDistribAgentName
    | "499"B ->
        let pos3, fld = ReadCashDistribAgentCode bs pos2 
        pos3, fld |> FIXField.CashDistribAgentCode
    | "500"B ->
        let pos3, fld = ReadCashDistribAgentAcctNumber bs pos2 
        pos3, fld |> FIXField.CashDistribAgentAcctNumber
    | "501"B ->
        let pos3, fld = ReadCashDistribPayRef bs pos2 
        pos3, fld |> FIXField.CashDistribPayRef
    | "502"B ->
        let pos3, fld = ReadCashDistribAgentAcctName bs pos2 
        pos3, fld |> FIXField.CashDistribAgentAcctName
    | "503"B ->
        let pos3, fld = ReadCardStartDate bs pos2 
        pos3, fld |> FIXField.CardStartDate
    | "504"B ->
        let pos3, fld = ReadPaymentDate bs pos2 
        pos3, fld |> FIXField.PaymentDate
    | "505"B ->
        let pos3, fld = ReadPaymentRemitterID bs pos2 
        pos3, fld |> FIXField.PaymentRemitterID
    | "506"B ->
        let pos3, fld = ReadRegistStatus bs pos2 
        pos3, fld |> FIXField.RegistStatus
    | "507"B ->
        let pos3, fld = ReadRegistRejReasonCode bs pos2 
        pos3, fld |> FIXField.RegistRejReasonCode
    | "508"B ->
        let pos3, fld = ReadRegistRefID bs pos2 
        pos3, fld |> FIXField.RegistRefID
    | "509"B ->
        let pos3, fld = ReadRegistDtls bs pos2 
        pos3, fld |> FIXField.RegistDtls
    | "510"B ->
        let pos3, fld = ReadNoDistribInsts bs pos2 
        pos3, fld |> FIXField.NoDistribInsts
    | "511"B ->
        let pos3, fld = ReadRegistEmail bs pos2 
        pos3, fld |> FIXField.RegistEmail
    | "512"B ->
        let pos3, fld = ReadDistribPercentage bs pos2 
        pos3, fld |> FIXField.DistribPercentage
    | "513"B ->
        let pos3, fld = ReadRegistID bs pos2 
        pos3, fld |> FIXField.RegistID
    | "514"B ->
        let pos3, fld = ReadRegistTransType bs pos2 
        pos3, fld |> FIXField.RegistTransType
    | "515"B ->
        let pos3, fld = ReadExecValuationPoint bs pos2 
        pos3, fld |> FIXField.ExecValuationPoint
    | "516"B ->
        let pos3, fld = ReadOrderPercent bs pos2 
        pos3, fld |> FIXField.OrderPercent
    | "517"B ->
        let pos3, fld = ReadOwnershipType bs pos2 
        pos3, fld |> FIXField.OwnershipType
    | "518"B ->
        let pos3, fld = ReadNoContAmts bs pos2 
        pos3, fld |> FIXField.NoContAmts
    | "519"B ->
        let pos3, fld = ReadContAmtType bs pos2 
        pos3, fld |> FIXField.ContAmtType
    | "520"B ->
        let pos3, fld = ReadContAmtValue bs pos2 
        pos3, fld |> FIXField.ContAmtValue
    | "521"B ->
        let pos3, fld = ReadContAmtCurr bs pos2 
        pos3, fld |> FIXField.ContAmtCurr
    | "522"B ->
        let pos3, fld = ReadOwnerType bs pos2 
        pos3, fld |> FIXField.OwnerType
    | "523"B ->
        let pos3, fld = ReadPartySubID bs pos2 
        pos3, fld |> FIXField.PartySubID
    | "524"B ->
        let pos3, fld = ReadNestedPartyID bs pos2 
        pos3, fld |> FIXField.NestedPartyID
    | "525"B ->
        let pos3, fld = ReadNestedPartyIDSource bs pos2 
        pos3, fld |> FIXField.NestedPartyIDSource
    | "526"B ->
        let pos3, fld = ReadSecondaryClOrdID bs pos2 
        pos3, fld |> FIXField.SecondaryClOrdID
    | "527"B ->
        let pos3, fld = ReadSecondaryExecID bs pos2 
        pos3, fld |> FIXField.SecondaryExecID
    | "528"B ->
        let pos3, fld = ReadOrderCapacity bs pos2 
        pos3, fld |> FIXField.OrderCapacity
    | "529"B ->
        let pos3, fld = ReadOrderRestrictions bs pos2 
        pos3, fld |> FIXField.OrderRestrictions
    | "530"B ->
        let pos3, fld = ReadMassCancelRequestType bs pos2 
        pos3, fld |> FIXField.MassCancelRequestType
    | "531"B ->
        let pos3, fld = ReadMassCancelResponse bs pos2 
        pos3, fld |> FIXField.MassCancelResponse
    | "532"B ->
        let pos3, fld = ReadMassCancelRejectReason bs pos2 
        pos3, fld |> FIXField.MassCancelRejectReason
    | "533"B ->
        let pos3, fld = ReadTotalAffectedOrders bs pos2 
        pos3, fld |> FIXField.TotalAffectedOrders
    | "534"B ->
        let pos3, fld = ReadNoAffectedOrders bs pos2 
        pos3, fld |> FIXField.NoAffectedOrders
    | "535"B ->
        let pos3, fld = ReadAffectedOrderID bs pos2 
        pos3, fld |> FIXField.AffectedOrderID
    | "536"B ->
        let pos3, fld = ReadAffectedSecondaryOrderID bs pos2 
        pos3, fld |> FIXField.AffectedSecondaryOrderID
    | "537"B ->
        let pos3, fld = ReadQuoteType bs pos2 
        pos3, fld |> FIXField.QuoteType
    | "538"B ->
        let pos3, fld = ReadNestedPartyRole bs pos2 
        pos3, fld |> FIXField.NestedPartyRole
    | "539"B ->
        let pos3, fld = ReadNoNestedPartyIDs bs pos2 
        pos3, fld |> FIXField.NoNestedPartyIDs
    | "540"B ->
        let pos3, fld = ReadTotalAccruedInterestAmt bs pos2 
        pos3, fld |> FIXField.TotalAccruedInterestAmt
    | "541"B ->
        let pos3, fld = ReadMaturityDate bs pos2 
        pos3, fld |> FIXField.MaturityDate
    | "542"B ->
        let pos3, fld = ReadUnderlyingMaturityDate bs pos2 
        pos3, fld |> FIXField.UnderlyingMaturityDate
    | "543"B ->
        let pos3, fld = ReadInstrRegistry bs pos2 
        pos3, fld |> FIXField.InstrRegistry
    | "544"B ->
        let pos3, fld = ReadCashMargin bs pos2 
        pos3, fld |> FIXField.CashMargin
    | "545"B ->
        let pos3, fld = ReadNestedPartySubID bs pos2 
        pos3, fld |> FIXField.NestedPartySubID
    | "546"B ->
        let pos3, fld = ReadScope bs pos2 
        pos3, fld |> FIXField.Scope
    | "547"B ->
        let pos3, fld = ReadMDImplicitDelete bs pos2 
        pos3, fld |> FIXField.MDImplicitDelete
    | "548"B ->
        let pos3, fld = ReadCrossID bs pos2 
        pos3, fld |> FIXField.CrossID
    | "549"B ->
        let pos3, fld = ReadCrossType bs pos2 
        pos3, fld |> FIXField.CrossType
    | "550"B ->
        let pos3, fld = ReadCrossPrioritization bs pos2 
        pos3, fld |> FIXField.CrossPrioritization
    | "551"B ->
        let pos3, fld = ReadOrigCrossID bs pos2 
        pos3, fld |> FIXField.OrigCrossID
    | "552"B ->
        let pos3, fld = ReadNoSides bs pos2 
        pos3, fld |> FIXField.NoSides
    | "553"B ->
        let pos3, fld = ReadUsername bs pos2 
        pos3, fld |> FIXField.Username
    | "554"B ->
        let pos3, fld = ReadPassword bs pos2 
        pos3, fld |> FIXField.Password
    | "555"B ->
        let pos3, fld = ReadNoLegs bs pos2 
        pos3, fld |> FIXField.NoLegs
    | "556"B ->
        let pos3, fld = ReadLegCurrency bs pos2 
        pos3, fld |> FIXField.LegCurrency
    | "557"B ->
        let pos3, fld = ReadTotNoSecurityTypes bs pos2 
        pos3, fld |> FIXField.TotNoSecurityTypes
    | "558"B ->
        let pos3, fld = ReadNoSecurityTypes bs pos2 
        pos3, fld |> FIXField.NoSecurityTypes
    | "559"B ->
        let pos3, fld = ReadSecurityListRequestType bs pos2 
        pos3, fld |> FIXField.SecurityListRequestType
    | "560"B ->
        let pos3, fld = ReadSecurityRequestResult bs pos2 
        pos3, fld |> FIXField.SecurityRequestResult
    | "561"B ->
        let pos3, fld = ReadRoundLot bs pos2 
        pos3, fld |> FIXField.RoundLot
    | "562"B ->
        let pos3, fld = ReadMinTradeVol bs pos2 
        pos3, fld |> FIXField.MinTradeVol
    | "563"B ->
        let pos3, fld = ReadMultiLegRptTypeReq bs pos2 
        pos3, fld |> FIXField.MultiLegRptTypeReq
    | "564"B ->
        let pos3, fld = ReadLegPositionEffect bs pos2 
        pos3, fld |> FIXField.LegPositionEffect
    | "565"B ->
        let pos3, fld = ReadLegCoveredOrUncovered bs pos2 
        pos3, fld |> FIXField.LegCoveredOrUncovered
    | "566"B ->
        let pos3, fld = ReadLegPrice bs pos2 
        pos3, fld |> FIXField.LegPrice
    | "567"B ->
        let pos3, fld = ReadTradSesStatusRejReason bs pos2 
        pos3, fld |> FIXField.TradSesStatusRejReason
    | "568"B ->
        let pos3, fld = ReadTradeRequestID bs pos2 
        pos3, fld |> FIXField.TradeRequestID
    | "569"B ->
        let pos3, fld = ReadTradeRequestType bs pos2 
        pos3, fld |> FIXField.TradeRequestType
    | "570"B ->
        let pos3, fld = ReadPreviouslyReported bs pos2 
        pos3, fld |> FIXField.PreviouslyReported
    | "571"B ->
        let pos3, fld = ReadTradeReportID bs pos2 
        pos3, fld |> FIXField.TradeReportID
    | "572"B ->
        let pos3, fld = ReadTradeReportRefID bs pos2 
        pos3, fld |> FIXField.TradeReportRefID
    | "573"B ->
        let pos3, fld = ReadMatchStatus bs pos2 
        pos3, fld |> FIXField.MatchStatus
    | "574"B ->
        let pos3, fld = ReadMatchType bs pos2 
        pos3, fld |> FIXField.MatchType
    | "575"B ->
        let pos3, fld = ReadOddLot bs pos2 
        pos3, fld |> FIXField.OddLot
    | "576"B ->
        let pos3, fld = ReadNoClearingInstructions bs pos2 
        pos3, fld |> FIXField.NoClearingInstructions
    | "577"B ->
        let pos3, fld = ReadClearingInstruction bs pos2 
        pos3, fld |> FIXField.ClearingInstruction
    | "578"B ->
        let pos3, fld = ReadTradeInputSource bs pos2 
        pos3, fld |> FIXField.TradeInputSource
    | "579"B ->
        let pos3, fld = ReadTradeInputDevice bs pos2 
        pos3, fld |> FIXField.TradeInputDevice
    | "580"B ->
        let pos3, fld = ReadNoDates bs pos2 
        pos3, fld |> FIXField.NoDates
    | "581"B ->
        let pos3, fld = ReadAccountType bs pos2 
        pos3, fld |> FIXField.AccountType
    | "582"B ->
        let pos3, fld = ReadCustOrderCapacity bs pos2 
        pos3, fld |> FIXField.CustOrderCapacity
    | "583"B ->
        let pos3, fld = ReadClOrdLinkID bs pos2 
        pos3, fld |> FIXField.ClOrdLinkID
    | "584"B ->
        let pos3, fld = ReadMassStatusReqID bs pos2 
        pos3, fld |> FIXField.MassStatusReqID
    | "585"B ->
        let pos3, fld = ReadMassStatusReqType bs pos2 
        pos3, fld |> FIXField.MassStatusReqType
    | "586"B ->
        let pos3, fld = ReadOrigOrdModTime bs pos2 
        pos3, fld |> FIXField.OrigOrdModTime
    | "587"B ->
        let pos3, fld = ReadLegSettlType bs pos2 
        pos3, fld |> FIXField.LegSettlType
    | "588"B ->
        let pos3, fld = ReadLegSettlDate bs pos2 
        pos3, fld |> FIXField.LegSettlDate
    | "589"B ->
        let pos3, fld = ReadDayBookingInst bs pos2 
        pos3, fld |> FIXField.DayBookingInst
    | "590"B ->
        let pos3, fld = ReadBookingUnit bs pos2 
        pos3, fld |> FIXField.BookingUnit
    | "591"B ->
        let pos3, fld = ReadPreallocMethod bs pos2 
        pos3, fld |> FIXField.PreallocMethod
    | "592"B ->
        let pos3, fld = ReadUnderlyingCountryOfIssue bs pos2 
        pos3, fld |> FIXField.UnderlyingCountryOfIssue
    | "593"B ->
        let pos3, fld = ReadUnderlyingStateOrProvinceOfIssue bs pos2 
        pos3, fld |> FIXField.UnderlyingStateOrProvinceOfIssue
    | "594"B ->
        let pos3, fld = ReadUnderlyingLocaleOfIssue bs pos2 
        pos3, fld |> FIXField.UnderlyingLocaleOfIssue
    | "595"B ->
        let pos3, fld = ReadUnderlyingInstrRegistry bs pos2 
        pos3, fld |> FIXField.UnderlyingInstrRegistry
    | "596"B ->
        let pos3, fld = ReadLegCountryOfIssue bs pos2 
        pos3, fld |> FIXField.LegCountryOfIssue
    | "597"B ->
        let pos3, fld = ReadLegStateOrProvinceOfIssue bs pos2 
        pos3, fld |> FIXField.LegStateOrProvinceOfIssue
    | "598"B ->
        let pos3, fld = ReadLegLocaleOfIssue bs pos2 
        pos3, fld |> FIXField.LegLocaleOfIssue
    | "599"B ->
        let pos3, fld = ReadLegInstrRegistry bs pos2 
        pos3, fld |> FIXField.LegInstrRegistry
    | "600"B ->
        let pos3, fld = ReadLegSymbol bs pos2 
        pos3, fld |> FIXField.LegSymbol
    | "601"B ->
        let pos3, fld = ReadLegSymbolSfx bs pos2 
        pos3, fld |> FIXField.LegSymbolSfx
    | "602"B ->
        let pos3, fld = ReadLegSecurityID bs pos2 
        pos3, fld |> FIXField.LegSecurityID
    | "603"B ->
        let pos3, fld = ReadLegSecurityIDSource bs pos2 
        pos3, fld |> FIXField.LegSecurityIDSource
    | "604"B ->
        let pos3, fld = ReadNoLegSecurityAltID bs pos2 
        pos3, fld |> FIXField.NoLegSecurityAltID
    | "605"B ->
        let pos3, fld = ReadLegSecurityAltID bs pos2 
        pos3, fld |> FIXField.LegSecurityAltID
    | "606"B ->
        let pos3, fld = ReadLegSecurityAltIDSource bs pos2 
        pos3, fld |> FIXField.LegSecurityAltIDSource
    | "607"B ->
        let pos3, fld = ReadLegProduct bs pos2 
        pos3, fld |> FIXField.LegProduct
    | "608"B ->
        let pos3, fld = ReadLegCFICode bs pos2 
        pos3, fld |> FIXField.LegCFICode
    | "609"B ->
        let pos3, fld = ReadLegSecurityType bs pos2 
        pos3, fld |> FIXField.LegSecurityType
    | "610"B ->
        let pos3, fld = ReadLegMaturityMonthYear bs pos2 
        pos3, fld |> FIXField.LegMaturityMonthYear
    | "611"B ->
        let pos3, fld = ReadLegMaturityDate bs pos2 
        pos3, fld |> FIXField.LegMaturityDate
    | "612"B ->
        let pos3, fld = ReadLegStrikePrice bs pos2 
        pos3, fld |> FIXField.LegStrikePrice
    | "613"B ->
        let pos3, fld = ReadLegOptAttribute bs pos2 
        pos3, fld |> FIXField.LegOptAttribute
    | "614"B ->
        let pos3, fld = ReadLegContractMultiplier bs pos2 
        pos3, fld |> FIXField.LegContractMultiplier
    | "615"B ->
        let pos3, fld = ReadLegCouponRate bs pos2 
        pos3, fld |> FIXField.LegCouponRate
    | "616"B ->
        let pos3, fld = ReadLegSecurityExchange bs pos2 
        pos3, fld |> FIXField.LegSecurityExchange
    | "617"B ->
        let pos3, fld = ReadLegIssuer bs pos2 
        pos3, fld |> FIXField.LegIssuer
    | "618"B ->
        let pos3, fld = ReadEncodedLegIssuer bs pos2 
        pos3, fld |> FIXField.EncodedLegIssuer // len->string compound field
    | "620"B ->
        let pos3, fld = ReadLegSecurityDesc bs pos2 
        pos3, fld |> FIXField.LegSecurityDesc
    | "621"B ->
        let pos3, fld = ReadEncodedLegSecurityDesc bs pos2 
        pos3, fld |> FIXField.EncodedLegSecurityDesc // len->string compound field
    | "623"B ->
        let pos3, fld = ReadLegRatioQty bs pos2 
        pos3, fld |> FIXField.LegRatioQty
    | "624"B ->
        let pos3, fld = ReadLegSide bs pos2 
        pos3, fld |> FIXField.LegSide
    | "625"B ->
        let pos3, fld = ReadTradingSessionSubID bs pos2 
        pos3, fld |> FIXField.TradingSessionSubID
    | "626"B ->
        let pos3, fld = ReadAllocType bs pos2 
        pos3, fld |> FIXField.AllocType
    | "627"B ->
        let pos3, fld = ReadNoHops bs pos2 
        pos3, fld |> FIXField.NoHops
    | "628"B ->
        let pos3, fld = ReadHopCompID bs pos2 
        pos3, fld |> FIXField.HopCompID
    | "629"B ->
        let pos3, fld = ReadHopSendingTime bs pos2 
        pos3, fld |> FIXField.HopSendingTime
    | "630"B ->
        let pos3, fld = ReadHopRefID bs pos2 
        pos3, fld |> FIXField.HopRefID
    | "631"B ->
        let pos3, fld = ReadMidPx bs pos2 
        pos3, fld |> FIXField.MidPx
    | "632"B ->
        let pos3, fld = ReadBidYield bs pos2 
        pos3, fld |> FIXField.BidYield
    | "633"B ->
        let pos3, fld = ReadMidYield bs pos2 
        pos3, fld |> FIXField.MidYield
    | "634"B ->
        let pos3, fld = ReadOfferYield bs pos2 
        pos3, fld |> FIXField.OfferYield
    | "635"B ->
        let pos3, fld = ReadClearingFeeIndicator bs pos2 
        pos3, fld |> FIXField.ClearingFeeIndicator
    | "636"B ->
        let pos3, fld = ReadWorkingIndicator bs pos2 
        pos3, fld |> FIXField.WorkingIndicator
    | "637"B ->
        let pos3, fld = ReadLegLastPx bs pos2 
        pos3, fld |> FIXField.LegLastPx
    | "638"B ->
        let pos3, fld = ReadPriorityIndicator bs pos2 
        pos3, fld |> FIXField.PriorityIndicator
    | "639"B ->
        let pos3, fld = ReadPriceImprovement bs pos2 
        pos3, fld |> FIXField.PriceImprovement
    | "640"B ->
        let pos3, fld = ReadPrice2 bs pos2 
        pos3, fld |> FIXField.Price2
    | "641"B ->
        let pos3, fld = ReadLastForwardPoints2 bs pos2 
        pos3, fld |> FIXField.LastForwardPoints2
    | "642"B ->
        let pos3, fld = ReadBidForwardPoints2 bs pos2 
        pos3, fld |> FIXField.BidForwardPoints2
    | "643"B ->
        let pos3, fld = ReadOfferForwardPoints2 bs pos2 
        pos3, fld |> FIXField.OfferForwardPoints2
    | "644"B ->
        let pos3, fld = ReadRFQReqID bs pos2 
        pos3, fld |> FIXField.RFQReqID
    | "645"B ->
        let pos3, fld = ReadMktBidPx bs pos2 
        pos3, fld |> FIXField.MktBidPx
    | "646"B ->
        let pos3, fld = ReadMktOfferPx bs pos2 
        pos3, fld |> FIXField.MktOfferPx
    | "647"B ->
        let pos3, fld = ReadMinBidSize bs pos2 
        pos3, fld |> FIXField.MinBidSize
    | "648"B ->
        let pos3, fld = ReadMinOfferSize bs pos2 
        pos3, fld |> FIXField.MinOfferSize
    | "649"B ->
        let pos3, fld = ReadQuoteStatusReqID bs pos2 
        pos3, fld |> FIXField.QuoteStatusReqID
    | "650"B ->
        let pos3, fld = ReadLegalConfirm bs pos2 
        pos3, fld |> FIXField.LegalConfirm
    | "651"B ->
        let pos3, fld = ReadUnderlyingLastPx bs pos2 
        pos3, fld |> FIXField.UnderlyingLastPx
    | "652"B ->
        let pos3, fld = ReadUnderlyingLastQty bs pos2 
        pos3, fld |> FIXField.UnderlyingLastQty
    | "654"B ->
        let pos3, fld = ReadLegRefID bs pos2 
        pos3, fld |> FIXField.LegRefID
    | "655"B ->
        let pos3, fld = ReadContraLegRefID bs pos2 
        pos3, fld |> FIXField.ContraLegRefID
    | "656"B ->
        let pos3, fld = ReadSettlCurrBidFxRate bs pos2 
        pos3, fld |> FIXField.SettlCurrBidFxRate
    | "657"B ->
        let pos3, fld = ReadSettlCurrOfferFxRate bs pos2 
        pos3, fld |> FIXField.SettlCurrOfferFxRate
    | "658"B ->
        let pos3, fld = ReadQuoteRequestRejectReason bs pos2 
        pos3, fld |> FIXField.QuoteRequestRejectReason
    | "659"B ->
        let pos3, fld = ReadSideComplianceID bs pos2 
        pos3, fld |> FIXField.SideComplianceID
    | "660"B ->
        let pos3, fld = ReadAcctIDSource bs pos2 
        pos3, fld |> FIXField.AcctIDSource
    | "661"B ->
        let pos3, fld = ReadAllocAcctIDSource bs pos2 
        pos3, fld |> FIXField.AllocAcctIDSource
    | "662"B ->
        let pos3, fld = ReadBenchmarkPrice bs pos2 
        pos3, fld |> FIXField.BenchmarkPrice
    | "663"B ->
        let pos3, fld = ReadBenchmarkPriceType bs pos2 
        pos3, fld |> FIXField.BenchmarkPriceType
    | "664"B ->
        let pos3, fld = ReadConfirmID bs pos2 
        pos3, fld |> FIXField.ConfirmID
    | "665"B ->
        let pos3, fld = ReadConfirmStatus bs pos2 
        pos3, fld |> FIXField.ConfirmStatus
    | "666"B ->
        let pos3, fld = ReadConfirmTransType bs pos2 
        pos3, fld |> FIXField.ConfirmTransType
    | "667"B ->
        let pos3, fld = ReadContractSettlMonth bs pos2 
        pos3, fld |> FIXField.ContractSettlMonth
    | "668"B ->
        let pos3, fld = ReadDeliveryForm bs pos2 
        pos3, fld |> FIXField.DeliveryForm
    | "669"B ->
        let pos3, fld = ReadLastParPx bs pos2 
        pos3, fld |> FIXField.LastParPx
    | "670"B ->
        let pos3, fld = ReadNoLegAllocs bs pos2 
        pos3, fld |> FIXField.NoLegAllocs
    | "671"B ->
        let pos3, fld = ReadLegAllocAccount bs pos2 
        pos3, fld |> FIXField.LegAllocAccount
    | "672"B ->
        let pos3, fld = ReadLegIndividualAllocID bs pos2 
        pos3, fld |> FIXField.LegIndividualAllocID
    | "673"B ->
        let pos3, fld = ReadLegAllocQty bs pos2 
        pos3, fld |> FIXField.LegAllocQty
    | "674"B ->
        let pos3, fld = ReadLegAllocAcctIDSource bs pos2 
        pos3, fld |> FIXField.LegAllocAcctIDSource
    | "675"B ->
        let pos3, fld = ReadLegSettlCurrency bs pos2 
        pos3, fld |> FIXField.LegSettlCurrency
    | "676"B ->
        let pos3, fld = ReadLegBenchmarkCurveCurrency bs pos2 
        pos3, fld |> FIXField.LegBenchmarkCurveCurrency
    | "677"B ->
        let pos3, fld = ReadLegBenchmarkCurveName bs pos2 
        pos3, fld |> FIXField.LegBenchmarkCurveName
    | "678"B ->
        let pos3, fld = ReadLegBenchmarkCurvePoint bs pos2 
        pos3, fld |> FIXField.LegBenchmarkCurvePoint
    | "679"B ->
        let pos3, fld = ReadLegBenchmarkPrice bs pos2 
        pos3, fld |> FIXField.LegBenchmarkPrice
    | "680"B ->
        let pos3, fld = ReadLegBenchmarkPriceType bs pos2 
        pos3, fld |> FIXField.LegBenchmarkPriceType
    | "681"B ->
        let pos3, fld = ReadLegBidPx bs pos2 
        pos3, fld |> FIXField.LegBidPx
    | "682"B ->
        let pos3, fld = ReadLegIOIQty bs pos2 
        pos3, fld |> FIXField.LegIOIQty
    | "683"B ->
        let pos3, fld = ReadNoLegStipulations bs pos2 
        pos3, fld |> FIXField.NoLegStipulations
    | "684"B ->
        let pos3, fld = ReadLegOfferPx bs pos2 
        pos3, fld |> FIXField.LegOfferPx
    | "685"B ->
        let pos3, fld = ReadLegOrderQty bs pos2 
        pos3, fld |> FIXField.LegOrderQty
    | "686"B ->
        let pos3, fld = ReadLegPriceType bs pos2 
        pos3, fld |> FIXField.LegPriceType
    | "687"B ->
        let pos3, fld = ReadLegQty bs pos2 
        pos3, fld |> FIXField.LegQty
    | "688"B ->
        let pos3, fld = ReadLegStipulationType bs pos2 
        pos3, fld |> FIXField.LegStipulationType
    | "689"B ->
        let pos3, fld = ReadLegStipulationValue bs pos2 
        pos3, fld |> FIXField.LegStipulationValue
    | "690"B ->
        let pos3, fld = ReadLegSwapType bs pos2 
        pos3, fld |> FIXField.LegSwapType
    | "691"B ->
        let pos3, fld = ReadPool bs pos2 
        pos3, fld |> FIXField.Pool
    | "692"B ->
        let pos3, fld = ReadQuotePriceType bs pos2 
        pos3, fld |> FIXField.QuotePriceType
    | "693"B ->
        let pos3, fld = ReadQuoteRespID bs pos2 
        pos3, fld |> FIXField.QuoteRespID
    | "694"B ->
        let pos3, fld = ReadQuoteRespType bs pos2 
        pos3, fld |> FIXField.QuoteRespType
    | "695"B ->
        let pos3, fld = ReadQuoteQualifier bs pos2 
        pos3, fld |> FIXField.QuoteQualifier
    | "696"B ->
        let pos3, fld = ReadYieldRedemptionDate bs pos2 
        pos3, fld |> FIXField.YieldRedemptionDate
    | "697"B ->
        let pos3, fld = ReadYieldRedemptionPrice bs pos2 
        pos3, fld |> FIXField.YieldRedemptionPrice
    | "698"B ->
        let pos3, fld = ReadYieldRedemptionPriceType bs pos2 
        pos3, fld |> FIXField.YieldRedemptionPriceType
    | "699"B ->
        let pos3, fld = ReadBenchmarkSecurityID bs pos2 
        pos3, fld |> FIXField.BenchmarkSecurityID
    | "700"B ->
        let pos3, fld = ReadReversalIndicator bs pos2 
        pos3, fld |> FIXField.ReversalIndicator
    | "701"B ->
        let pos3, fld = ReadYieldCalcDate bs pos2 
        pos3, fld |> FIXField.YieldCalcDate
    | "702"B ->
        let pos3, fld = ReadNoPositions bs pos2 
        pos3, fld |> FIXField.NoPositions
    | "703"B ->
        let pos3, fld = ReadPosType bs pos2 
        pos3, fld |> FIXField.PosType
    | "704"B ->
        let pos3, fld = ReadLongQty bs pos2 
        pos3, fld |> FIXField.LongQty
    | "705"B ->
        let pos3, fld = ReadShortQty bs pos2 
        pos3, fld |> FIXField.ShortQty
    | "706"B ->
        let pos3, fld = ReadPosQtyStatus bs pos2 
        pos3, fld |> FIXField.PosQtyStatus
    | "707"B ->
        let pos3, fld = ReadPosAmtType bs pos2 
        pos3, fld |> FIXField.PosAmtType
    | "708"B ->
        let pos3, fld = ReadPosAmt bs pos2 
        pos3, fld |> FIXField.PosAmt
    | "709"B ->
        let pos3, fld = ReadPosTransType bs pos2 
        pos3, fld |> FIXField.PosTransType
    | "710"B ->
        let pos3, fld = ReadPosReqID bs pos2 
        pos3, fld |> FIXField.PosReqID
    | "711"B ->
        let pos3, fld = ReadNoUnderlyings bs pos2 
        pos3, fld |> FIXField.NoUnderlyings
    | "712"B ->
        let pos3, fld = ReadPosMaintAction bs pos2 
        pos3, fld |> FIXField.PosMaintAction
    | "713"B ->
        let pos3, fld = ReadOrigPosReqRefID bs pos2 
        pos3, fld |> FIXField.OrigPosReqRefID
    | "714"B ->
        let pos3, fld = ReadPosMaintRptRefID bs pos2 
        pos3, fld |> FIXField.PosMaintRptRefID
    | "715"B ->
        let pos3, fld = ReadClearingBusinessDate bs pos2 
        pos3, fld |> FIXField.ClearingBusinessDate
    | "716"B ->
        let pos3, fld = ReadSettlSessID bs pos2 
        pos3, fld |> FIXField.SettlSessID
    | "717"B ->
        let pos3, fld = ReadSettlSessSubID bs pos2 
        pos3, fld |> FIXField.SettlSessSubID
    | "718"B ->
        let pos3, fld = ReadAdjustmentType bs pos2 
        pos3, fld |> FIXField.AdjustmentType
    | "719"B ->
        let pos3, fld = ReadContraryInstructionIndicator bs pos2 
        pos3, fld |> FIXField.ContraryInstructionIndicator
    | "720"B ->
        let pos3, fld = ReadPriorSpreadIndicator bs pos2 
        pos3, fld |> FIXField.PriorSpreadIndicator
    | "721"B ->
        let pos3, fld = ReadPosMaintRptID bs pos2 
        pos3, fld |> FIXField.PosMaintRptID
    | "722"B ->
        let pos3, fld = ReadPosMaintStatus bs pos2 
        pos3, fld |> FIXField.PosMaintStatus
    | "723"B ->
        let pos3, fld = ReadPosMaintResult bs pos2 
        pos3, fld |> FIXField.PosMaintResult
    | "724"B ->
        let pos3, fld = ReadPosReqType bs pos2 
        pos3, fld |> FIXField.PosReqType
    | "725"B ->
        let pos3, fld = ReadResponseTransportType bs pos2 
        pos3, fld |> FIXField.ResponseTransportType
    | "726"B ->
        let pos3, fld = ReadResponseDestination bs pos2 
        pos3, fld |> FIXField.ResponseDestination
    | "727"B ->
        let pos3, fld = ReadTotalNumPosReports bs pos2 
        pos3, fld |> FIXField.TotalNumPosReports
    | "728"B ->
        let pos3, fld = ReadPosReqResult bs pos2 
        pos3, fld |> FIXField.PosReqResult
    | "729"B ->
        let pos3, fld = ReadPosReqStatus bs pos2 
        pos3, fld |> FIXField.PosReqStatus
    | "730"B ->
        let pos3, fld = ReadSettlPrice bs pos2 
        pos3, fld |> FIXField.SettlPrice
    | "731"B ->
        let pos3, fld = ReadSettlPriceType bs pos2 
        pos3, fld |> FIXField.SettlPriceType
    | "732"B ->
        let pos3, fld = ReadUnderlyingSettlPrice bs pos2 
        pos3, fld |> FIXField.UnderlyingSettlPrice
    | "733"B ->
        let pos3, fld = ReadUnderlyingSettlPriceType bs pos2 
        pos3, fld |> FIXField.UnderlyingSettlPriceType
    | "734"B ->
        let pos3, fld = ReadPriorSettlPrice bs pos2 
        pos3, fld |> FIXField.PriorSettlPrice
    | "735"B ->
        let pos3, fld = ReadNoQuoteQualifiers bs pos2 
        pos3, fld |> FIXField.NoQuoteQualifiers
    | "736"B ->
        let pos3, fld = ReadAllocSettlCurrency bs pos2 
        pos3, fld |> FIXField.AllocSettlCurrency
    | "737"B ->
        let pos3, fld = ReadAllocSettlCurrAmt bs pos2 
        pos3, fld |> FIXField.AllocSettlCurrAmt
    | "738"B ->
        let pos3, fld = ReadInterestAtMaturity bs pos2 
        pos3, fld |> FIXField.InterestAtMaturity
    | "739"B ->
        let pos3, fld = ReadLegDatedDate bs pos2 
        pos3, fld |> FIXField.LegDatedDate
    | "740"B ->
        let pos3, fld = ReadLegPool bs pos2 
        pos3, fld |> FIXField.LegPool
    | "741"B ->
        let pos3, fld = ReadAllocInterestAtMaturity bs pos2 
        pos3, fld |> FIXField.AllocInterestAtMaturity
    | "742"B ->
        let pos3, fld = ReadAllocAccruedInterestAmt bs pos2 
        pos3, fld |> FIXField.AllocAccruedInterestAmt
    | "743"B ->
        let pos3, fld = ReadDeliveryDate bs pos2 
        pos3, fld |> FIXField.DeliveryDate
    | "744"B ->
        let pos3, fld = ReadAssignmentMethod bs pos2 
        pos3, fld |> FIXField.AssignmentMethod
    | "745"B ->
        let pos3, fld = ReadAssignmentUnit bs pos2 
        pos3, fld |> FIXField.AssignmentUnit
    | "746"B ->
        let pos3, fld = ReadOpenInterest bs pos2 
        pos3, fld |> FIXField.OpenInterest
    | "747"B ->
        let pos3, fld = ReadExerciseMethod bs pos2 
        pos3, fld |> FIXField.ExerciseMethod
    | "748"B ->
        let pos3, fld = ReadTotNumTradeReports bs pos2 
        pos3, fld |> FIXField.TotNumTradeReports
    | "749"B ->
        let pos3, fld = ReadTradeRequestResult bs pos2 
        pos3, fld |> FIXField.TradeRequestResult
    | "750"B ->
        let pos3, fld = ReadTradeRequestStatus bs pos2 
        pos3, fld |> FIXField.TradeRequestStatus
    | "751"B ->
        let pos3, fld = ReadTradeReportRejectReason bs pos2 
        pos3, fld |> FIXField.TradeReportRejectReason
    | "752"B ->
        let pos3, fld = ReadSideMultiLegReportingType bs pos2 
        pos3, fld |> FIXField.SideMultiLegReportingType
    | "753"B ->
        let pos3, fld = ReadNoPosAmt bs pos2 
        pos3, fld |> FIXField.NoPosAmt
    | "754"B ->
        let pos3, fld = ReadAutoAcceptIndicator bs pos2 
        pos3, fld |> FIXField.AutoAcceptIndicator
    | "755"B ->
        let pos3, fld = ReadAllocReportID bs pos2 
        pos3, fld |> FIXField.AllocReportID
    | "756"B ->
        let pos3, fld = ReadNoNested2PartyIDs bs pos2 
        pos3, fld |> FIXField.NoNested2PartyIDs
    | "757"B ->
        let pos3, fld = ReadNested2PartyID bs pos2 
        pos3, fld |> FIXField.Nested2PartyID
    | "758"B ->
        let pos3, fld = ReadNested2PartyIDSource bs pos2 
        pos3, fld |> FIXField.Nested2PartyIDSource
    | "759"B ->
        let pos3, fld = ReadNested2PartyRole bs pos2 
        pos3, fld |> FIXField.Nested2PartyRole
    | "760"B ->
        let pos3, fld = ReadNested2PartySubID bs pos2 
        pos3, fld |> FIXField.Nested2PartySubID
    | "761"B ->
        let pos3, fld = ReadBenchmarkSecurityIDSource bs pos2 
        pos3, fld |> FIXField.BenchmarkSecurityIDSource
    | "762"B ->
        let pos3, fld = ReadSecuritySubType bs pos2 
        pos3, fld |> FIXField.SecuritySubType
    | "763"B ->
        let pos3, fld = ReadUnderlyingSecuritySubType bs pos2 
        pos3, fld |> FIXField.UnderlyingSecuritySubType
    | "764"B ->
        let pos3, fld = ReadLegSecuritySubType bs pos2 
        pos3, fld |> FIXField.LegSecuritySubType
    | "765"B ->
        let pos3, fld = ReadAllowableOneSidednessPct bs pos2 
        pos3, fld |> FIXField.AllowableOneSidednessPct
    | "766"B ->
        let pos3, fld = ReadAllowableOneSidednessValue bs pos2 
        pos3, fld |> FIXField.AllowableOneSidednessValue
    | "767"B ->
        let pos3, fld = ReadAllowableOneSidednessCurr bs pos2 
        pos3, fld |> FIXField.AllowableOneSidednessCurr
    | "768"B ->
        let pos3, fld = ReadNoTrdRegTimestamps bs pos2 
        pos3, fld |> FIXField.NoTrdRegTimestamps
    | "769"B ->
        let pos3, fld = ReadTrdRegTimestamp bs pos2 
        pos3, fld |> FIXField.TrdRegTimestamp
    | "770"B ->
        let pos3, fld = ReadTrdRegTimestampType bs pos2 
        pos3, fld |> FIXField.TrdRegTimestampType
    | "771"B ->
        let pos3, fld = ReadTrdRegTimestampOrigin bs pos2 
        pos3, fld |> FIXField.TrdRegTimestampOrigin
    | "772"B ->
        let pos3, fld = ReadConfirmRefID bs pos2 
        pos3, fld |> FIXField.ConfirmRefID
    | "773"B ->
        let pos3, fld = ReadConfirmType bs pos2 
        pos3, fld |> FIXField.ConfirmType
    | "774"B ->
        let pos3, fld = ReadConfirmRejReason bs pos2 
        pos3, fld |> FIXField.ConfirmRejReason
    | "775"B ->
        let pos3, fld = ReadBookingType bs pos2 
        pos3, fld |> FIXField.BookingType
    | "776"B ->
        let pos3, fld = ReadIndividualAllocRejCode bs pos2 
        pos3, fld |> FIXField.IndividualAllocRejCode
    | "777"B ->
        let pos3, fld = ReadSettlInstMsgID bs pos2 
        pos3, fld |> FIXField.SettlInstMsgID
    | "778"B ->
        let pos3, fld = ReadNoSettlInst bs pos2 
        pos3, fld |> FIXField.NoSettlInst
    | "779"B ->
        let pos3, fld = ReadLastUpdateTime bs pos2 
        pos3, fld |> FIXField.LastUpdateTime
    | "780"B ->
        let pos3, fld = ReadAllocSettlInstType bs pos2 
        pos3, fld |> FIXField.AllocSettlInstType
    | "781"B ->
        let pos3, fld = ReadNoSettlPartyIDs bs pos2 
        pos3, fld |> FIXField.NoSettlPartyIDs
    | "782"B ->
        let pos3, fld = ReadSettlPartyID bs pos2 
        pos3, fld |> FIXField.SettlPartyID
    | "783"B ->
        let pos3, fld = ReadSettlPartyIDSource bs pos2 
        pos3, fld |> FIXField.SettlPartyIDSource
    | "784"B ->
        let pos3, fld = ReadSettlPartyRole bs pos2 
        pos3, fld |> FIXField.SettlPartyRole
    | "785"B ->
        let pos3, fld = ReadSettlPartySubID bs pos2 
        pos3, fld |> FIXField.SettlPartySubID
    | "786"B ->
        let pos3, fld = ReadSettlPartySubIDType bs pos2 
        pos3, fld |> FIXField.SettlPartySubIDType
    | "787"B ->
        let pos3, fld = ReadDlvyInstType bs pos2 
        pos3, fld |> FIXField.DlvyInstType
    | "788"B ->
        let pos3, fld = ReadTerminationType bs pos2 
        pos3, fld |> FIXField.TerminationType
    | "789"B ->
        let pos3, fld = ReadNextExpectedMsgSeqNum bs pos2 
        pos3, fld |> FIXField.NextExpectedMsgSeqNum
    | "790"B ->
        let pos3, fld = ReadOrdStatusReqID bs pos2 
        pos3, fld |> FIXField.OrdStatusReqID
    | "791"B ->
        let pos3, fld = ReadSettlInstReqID bs pos2 
        pos3, fld |> FIXField.SettlInstReqID
    | "792"B ->
        let pos3, fld = ReadSettlInstReqRejCode bs pos2 
        pos3, fld |> FIXField.SettlInstReqRejCode
    | "793"B ->
        let pos3, fld = ReadSecondaryAllocID bs pos2 
        pos3, fld |> FIXField.SecondaryAllocID
    | "794"B ->
        let pos3, fld = ReadAllocReportType bs pos2 
        pos3, fld |> FIXField.AllocReportType
    | "795"B ->
        let pos3, fld = ReadAllocReportRefID bs pos2 
        pos3, fld |> FIXField.AllocReportRefID
    | "796"B ->
        let pos3, fld = ReadAllocCancReplaceReason bs pos2 
        pos3, fld |> FIXField.AllocCancReplaceReason
    | "797"B ->
        let pos3, fld = ReadCopyMsgIndicator bs pos2 
        pos3, fld |> FIXField.CopyMsgIndicator
    | "798"B ->
        let pos3, fld = ReadAllocAccountType bs pos2 
        pos3, fld |> FIXField.AllocAccountType
    | "799"B ->
        let pos3, fld = ReadOrderAvgPx bs pos2 
        pos3, fld |> FIXField.OrderAvgPx
    | "800"B ->
        let pos3, fld = ReadOrderBookingQty bs pos2 
        pos3, fld |> FIXField.OrderBookingQty
    | "801"B ->
        let pos3, fld = ReadNoSettlPartySubIDs bs pos2 
        pos3, fld |> FIXField.NoSettlPartySubIDs
    | "802"B ->
        let pos3, fld = ReadNoPartySubIDs bs pos2 
        pos3, fld |> FIXField.NoPartySubIDs
    | "803"B ->
        let pos3, fld = ReadPartySubIDType bs pos2 
        pos3, fld |> FIXField.PartySubIDType
    | "804"B ->
        let pos3, fld = ReadNoNestedPartySubIDs bs pos2 
        pos3, fld |> FIXField.NoNestedPartySubIDs
    | "805"B ->
        let pos3, fld = ReadNestedPartySubIDType bs pos2 
        pos3, fld |> FIXField.NestedPartySubIDType
    | "806"B ->
        let pos3, fld = ReadNoNested2PartySubIDs bs pos2 
        pos3, fld |> FIXField.NoNested2PartySubIDs
    | "807"B ->
        let pos3, fld = ReadNested2PartySubIDType bs pos2 
        pos3, fld |> FIXField.Nested2PartySubIDType
    | "808"B ->
        let pos3, fld = ReadAllocIntermedReqType bs pos2 
        pos3, fld |> FIXField.AllocIntermedReqType
    | "810"B ->
        let pos3, fld = ReadUnderlyingPx bs pos2 
        pos3, fld |> FIXField.UnderlyingPx
    | "811"B ->
        let pos3, fld = ReadPriceDelta bs pos2 
        pos3, fld |> FIXField.PriceDelta
    | "812"B ->
        let pos3, fld = ReadApplQueueMax bs pos2 
        pos3, fld |> FIXField.ApplQueueMax
    | "813"B ->
        let pos3, fld = ReadApplQueueDepth bs pos2 
        pos3, fld |> FIXField.ApplQueueDepth
    | "814"B ->
        let pos3, fld = ReadApplQueueResolution bs pos2 
        pos3, fld |> FIXField.ApplQueueResolution
    | "815"B ->
        let pos3, fld = ReadApplQueueAction bs pos2 
        pos3, fld |> FIXField.ApplQueueAction
    | "816"B ->
        let pos3, fld = ReadNoAltMDSource bs pos2 
        pos3, fld |> FIXField.NoAltMDSource
    | "817"B ->
        let pos3, fld = ReadAltMDSourceID bs pos2 
        pos3, fld |> FIXField.AltMDSourceID
    | "818"B ->
        let pos3, fld = ReadSecondaryTradeReportID bs pos2 
        pos3, fld |> FIXField.SecondaryTradeReportID
    | "819"B ->
        let pos3, fld = ReadAvgPxIndicator bs pos2 
        pos3, fld |> FIXField.AvgPxIndicator
    | "820"B ->
        let pos3, fld = ReadTradeLinkID bs pos2 
        pos3, fld |> FIXField.TradeLinkID
    | "821"B ->
        let pos3, fld = ReadOrderInputDevice bs pos2 
        pos3, fld |> FIXField.OrderInputDevice
    | "822"B ->
        let pos3, fld = ReadUnderlyingTradingSessionID bs pos2 
        pos3, fld |> FIXField.UnderlyingTradingSessionID
    | "823"B ->
        let pos3, fld = ReadUnderlyingTradingSessionSubID bs pos2 
        pos3, fld |> FIXField.UnderlyingTradingSessionSubID
    | "824"B ->
        let pos3, fld = ReadTradeLegRefID bs pos2 
        pos3, fld |> FIXField.TradeLegRefID
    | "825"B ->
        let pos3, fld = ReadExchangeRule bs pos2 
        pos3, fld |> FIXField.ExchangeRule
    | "826"B ->
        let pos3, fld = ReadTradeAllocIndicator bs pos2 
        pos3, fld |> FIXField.TradeAllocIndicator
    | "827"B ->
        let pos3, fld = ReadExpirationCycle bs pos2 
        pos3, fld |> FIXField.ExpirationCycle
    | "828"B ->
        let pos3, fld = ReadTrdType bs pos2 
        pos3, fld |> FIXField.TrdType
    | "829"B ->
        let pos3, fld = ReadTrdSubType bs pos2 
        pos3, fld |> FIXField.TrdSubType
    | "830"B ->
        let pos3, fld = ReadTransferReason bs pos2 
        pos3, fld |> FIXField.TransferReason
    | "831"B ->
        let pos3, fld = ReadAsgnReqID bs pos2 
        pos3, fld |> FIXField.AsgnReqID
    | "832"B ->
        let pos3, fld = ReadTotNumAssignmentReports bs pos2 
        pos3, fld |> FIXField.TotNumAssignmentReports
    | "833"B ->
        let pos3, fld = ReadAsgnRptID bs pos2 
        pos3, fld |> FIXField.AsgnRptID
    | "834"B ->
        let pos3, fld = ReadThresholdAmount bs pos2 
        pos3, fld |> FIXField.ThresholdAmount
    | "835"B ->
        let pos3, fld = ReadPegMoveType bs pos2 
        pos3, fld |> FIXField.PegMoveType
    | "836"B ->
        let pos3, fld = ReadPegOffsetType bs pos2 
        pos3, fld |> FIXField.PegOffsetType
    | "837"B ->
        let pos3, fld = ReadPegLimitType bs pos2 
        pos3, fld |> FIXField.PegLimitType
    | "838"B ->
        let pos3, fld = ReadPegRoundDirection bs pos2 
        pos3, fld |> FIXField.PegRoundDirection
    | "839"B ->
        let pos3, fld = ReadPeggedPrice bs pos2 
        pos3, fld |> FIXField.PeggedPrice
    | "840"B ->
        let pos3, fld = ReadPegScope bs pos2 
        pos3, fld |> FIXField.PegScope
    | "841"B ->
        let pos3, fld = ReadDiscretionMoveType bs pos2 
        pos3, fld |> FIXField.DiscretionMoveType
    | "842"B ->
        let pos3, fld = ReadDiscretionOffsetType bs pos2 
        pos3, fld |> FIXField.DiscretionOffsetType
    | "843"B ->
        let pos3, fld = ReadDiscretionLimitType bs pos2 
        pos3, fld |> FIXField.DiscretionLimitType
    | "844"B ->
        let pos3, fld = ReadDiscretionRoundDirection bs pos2 
        pos3, fld |> FIXField.DiscretionRoundDirection
    | "845"B ->
        let pos3, fld = ReadDiscretionPrice bs pos2 
        pos3, fld |> FIXField.DiscretionPrice
    | "846"B ->
        let pos3, fld = ReadDiscretionScope bs pos2 
        pos3, fld |> FIXField.DiscretionScope
    | "847"B ->
        let pos3, fld = ReadTargetStrategy bs pos2 
        pos3, fld |> FIXField.TargetStrategy
    | "848"B ->
        let pos3, fld = ReadTargetStrategyParameters bs pos2 
        pos3, fld |> FIXField.TargetStrategyParameters
    | "849"B ->
        let pos3, fld = ReadParticipationRate bs pos2 
        pos3, fld |> FIXField.ParticipationRate
    | "850"B ->
        let pos3, fld = ReadTargetStrategyPerformance bs pos2 
        pos3, fld |> FIXField.TargetStrategyPerformance
    | "851"B ->
        let pos3, fld = ReadLastLiquidityInd bs pos2 
        pos3, fld |> FIXField.LastLiquidityInd
    | "852"B ->
        let pos3, fld = ReadPublishTrdIndicator bs pos2 
        pos3, fld |> FIXField.PublishTrdIndicator
    | "853"B ->
        let pos3, fld = ReadShortSaleReason bs pos2 
        pos3, fld |> FIXField.ShortSaleReason
    | "854"B ->
        let pos3, fld = ReadQtyType bs pos2 
        pos3, fld |> FIXField.QtyType
    | "855"B ->
        let pos3, fld = ReadSecondaryTrdType bs pos2 
        pos3, fld |> FIXField.SecondaryTrdType
    | "856"B ->
        let pos3, fld = ReadTradeReportType bs pos2 
        pos3, fld |> FIXField.TradeReportType
    | "857"B ->
        let pos3, fld = ReadAllocNoOrdersType bs pos2 
        pos3, fld |> FIXField.AllocNoOrdersType
    | "858"B ->
        let pos3, fld = ReadSharedCommission bs pos2 
        pos3, fld |> FIXField.SharedCommission
    | "859"B ->
        let pos3, fld = ReadConfirmReqID bs pos2 
        pos3, fld |> FIXField.ConfirmReqID
    | "860"B ->
        let pos3, fld = ReadAvgParPx bs pos2 
        pos3, fld |> FIXField.AvgParPx
    | "861"B ->
        let pos3, fld = ReadReportedPx bs pos2 
        pos3, fld |> FIXField.ReportedPx
    | "862"B ->
        let pos3, fld = ReadNoCapacities bs pos2 
        pos3, fld |> FIXField.NoCapacities
    | "863"B ->
        let pos3, fld = ReadOrderCapacityQty bs pos2 
        pos3, fld |> FIXField.OrderCapacityQty
    | "864"B ->
        let pos3, fld = ReadNoEvents bs pos2 
        pos3, fld |> FIXField.NoEvents
    | "865"B ->
        let pos3, fld = ReadEventType bs pos2 
        pos3, fld |> FIXField.EventType
    | "866"B ->
        let pos3, fld = ReadEventDate bs pos2 
        pos3, fld |> FIXField.EventDate
    | "867"B ->
        let pos3, fld = ReadEventPx bs pos2 
        pos3, fld |> FIXField.EventPx
    | "868"B ->
        let pos3, fld = ReadEventText bs pos2 
        pos3, fld |> FIXField.EventText
    | "869"B ->
        let pos3, fld = ReadPctAtRisk bs pos2 
        pos3, fld |> FIXField.PctAtRisk
    | "870"B ->
        let pos3, fld = ReadNoInstrAttrib bs pos2 
        pos3, fld |> FIXField.NoInstrAttrib
    | "871"B ->
        let pos3, fld = ReadInstrAttribType bs pos2 
        pos3, fld |> FIXField.InstrAttribType
    | "872"B ->
        let pos3, fld = ReadInstrAttribValue bs pos2 
        pos3, fld |> FIXField.InstrAttribValue
    | "873"B ->
        let pos3, fld = ReadDatedDate bs pos2 
        pos3, fld |> FIXField.DatedDate
    | "874"B ->
        let pos3, fld = ReadInterestAccrualDate bs pos2 
        pos3, fld |> FIXField.InterestAccrualDate
    | "875"B ->
        let pos3, fld = ReadCPProgram bs pos2 
        pos3, fld |> FIXField.CPProgram
    | "876"B ->
        let pos3, fld = ReadCPRegType bs pos2 
        pos3, fld |> FIXField.CPRegType
    | "877"B ->
        let pos3, fld = ReadUnderlyingCPProgram bs pos2 
        pos3, fld |> FIXField.UnderlyingCPProgram
    | "878"B ->
        let pos3, fld = ReadUnderlyingCPRegType bs pos2 
        pos3, fld |> FIXField.UnderlyingCPRegType
    | "879"B ->
        let pos3, fld = ReadUnderlyingQty bs pos2 
        pos3, fld |> FIXField.UnderlyingQty
    | "880"B ->
        let pos3, fld = ReadTrdMatchID bs pos2 
        pos3, fld |> FIXField.TrdMatchID
    | "881"B ->
        let pos3, fld = ReadSecondaryTradeReportRefID bs pos2 
        pos3, fld |> FIXField.SecondaryTradeReportRefID
    | "882"B ->
        let pos3, fld = ReadUnderlyingDirtyPrice bs pos2 
        pos3, fld |> FIXField.UnderlyingDirtyPrice
    | "883"B ->
        let pos3, fld = ReadUnderlyingEndPrice bs pos2 
        pos3, fld |> FIXField.UnderlyingEndPrice
    | "884"B ->
        let pos3, fld = ReadUnderlyingStartValue bs pos2 
        pos3, fld |> FIXField.UnderlyingStartValue
    | "885"B ->
        let pos3, fld = ReadUnderlyingCurrentValue bs pos2 
        pos3, fld |> FIXField.UnderlyingCurrentValue
    | "886"B ->
        let pos3, fld = ReadUnderlyingEndValue bs pos2 
        pos3, fld |> FIXField.UnderlyingEndValue
    | "887"B ->
        let pos3, fld = ReadNoUnderlyingStips bs pos2 
        pos3, fld |> FIXField.NoUnderlyingStips
    | "888"B ->
        let pos3, fld = ReadUnderlyingStipType bs pos2 
        pos3, fld |> FIXField.UnderlyingStipType
    | "889"B ->
        let pos3, fld = ReadUnderlyingStipValue bs pos2 
        pos3, fld |> FIXField.UnderlyingStipValue
    | "890"B ->
        let pos3, fld = ReadMaturityNetMoney bs pos2 
        pos3, fld |> FIXField.MaturityNetMoney
    | "891"B ->
        let pos3, fld = ReadMiscFeeBasis bs pos2 
        pos3, fld |> FIXField.MiscFeeBasis
    | "892"B ->
        let pos3, fld = ReadTotNoAllocs bs pos2 
        pos3, fld |> FIXField.TotNoAllocs
    | "893"B ->
        let pos3, fld = ReadLastFragment bs pos2 
        pos3, fld |> FIXField.LastFragment
    | "894"B ->
        let pos3, fld = ReadCollReqID bs pos2 
        pos3, fld |> FIXField.CollReqID
    | "895"B ->
        let pos3, fld = ReadCollAsgnReason bs pos2 
        pos3, fld |> FIXField.CollAsgnReason
    | "896"B ->
        let pos3, fld = ReadCollInquiryQualifier bs pos2 
        pos3, fld |> FIXField.CollInquiryQualifier
    | "897"B ->
        let pos3, fld = ReadNoTrades bs pos2 
        pos3, fld |> FIXField.NoTrades
    | "898"B ->
        let pos3, fld = ReadMarginRatio bs pos2 
        pos3, fld |> FIXField.MarginRatio
    | "899"B ->
        let pos3, fld = ReadMarginExcess bs pos2 
        pos3, fld |> FIXField.MarginExcess
    | "900"B ->
        let pos3, fld = ReadTotalNetValue bs pos2 
        pos3, fld |> FIXField.TotalNetValue
    | "901"B ->
        let pos3, fld = ReadCashOutstanding bs pos2 
        pos3, fld |> FIXField.CashOutstanding
    | "902"B ->
        let pos3, fld = ReadCollAsgnID bs pos2 
        pos3, fld |> FIXField.CollAsgnID
    | "903"B ->
        let pos3, fld = ReadCollAsgnTransType bs pos2 
        pos3, fld |> FIXField.CollAsgnTransType
    | "904"B ->
        let pos3, fld = ReadCollRespID bs pos2 
        pos3, fld |> FIXField.CollRespID
    | "905"B ->
        let pos3, fld = ReadCollAsgnRespType bs pos2 
        pos3, fld |> FIXField.CollAsgnRespType
    | "906"B ->
        let pos3, fld = ReadCollAsgnRejectReason bs pos2 
        pos3, fld |> FIXField.CollAsgnRejectReason
    | "907"B ->
        let pos3, fld = ReadCollAsgnRefID bs pos2 
        pos3, fld |> FIXField.CollAsgnRefID
    | "908"B ->
        let pos3, fld = ReadCollRptID bs pos2 
        pos3, fld |> FIXField.CollRptID
    | "909"B ->
        let pos3, fld = ReadCollInquiryID bs pos2 
        pos3, fld |> FIXField.CollInquiryID
    | "910"B ->
        let pos3, fld = ReadCollStatus bs pos2 
        pos3, fld |> FIXField.CollStatus
    | "911"B ->
        let pos3, fld = ReadTotNumReports bs pos2 
        pos3, fld |> FIXField.TotNumReports
    | "912"B ->
        let pos3, fld = ReadLastRptRequested bs pos2 
        pos3, fld |> FIXField.LastRptRequested
    | "913"B ->
        let pos3, fld = ReadAgreementDesc bs pos2 
        pos3, fld |> FIXField.AgreementDesc
    | "914"B ->
        let pos3, fld = ReadAgreementID bs pos2 
        pos3, fld |> FIXField.AgreementID
    | "915"B ->
        let pos3, fld = ReadAgreementDate bs pos2 
        pos3, fld |> FIXField.AgreementDate
    | "916"B ->
        let pos3, fld = ReadStartDate bs pos2 
        pos3, fld |> FIXField.StartDate
    | "917"B ->
        let pos3, fld = ReadEndDate bs pos2 
        pos3, fld |> FIXField.EndDate
    | "918"B ->
        let pos3, fld = ReadAgreementCurrency bs pos2 
        pos3, fld |> FIXField.AgreementCurrency
    | "919"B ->
        let pos3, fld = ReadDeliveryType bs pos2 
        pos3, fld |> FIXField.DeliveryType
    | "920"B ->
        let pos3, fld = ReadEndAccruedInterestAmt bs pos2 
        pos3, fld |> FIXField.EndAccruedInterestAmt
    | "921"B ->
        let pos3, fld = ReadStartCash bs pos2 
        pos3, fld |> FIXField.StartCash
    | "922"B ->
        let pos3, fld = ReadEndCash bs pos2 
        pos3, fld |> FIXField.EndCash
    | "923"B ->
        let pos3, fld = ReadUserRequestID bs pos2 
        pos3, fld |> FIXField.UserRequestID
    | "924"B ->
        let pos3, fld = ReadUserRequestType bs pos2 
        pos3, fld |> FIXField.UserRequestType
    | "925"B ->
        let pos3, fld = ReadNewPassword bs pos2 
        pos3, fld |> FIXField.NewPassword
    | "926"B ->
        let pos3, fld = ReadUserStatus bs pos2 
        pos3, fld |> FIXField.UserStatus
    | "927"B ->
        let pos3, fld = ReadUserStatusText bs pos2 
        pos3, fld |> FIXField.UserStatusText
    | "928"B ->
        let pos3, fld = ReadStatusValue bs pos2 
        pos3, fld |> FIXField.StatusValue
    | "929"B ->
        let pos3, fld = ReadStatusText bs pos2 
        pos3, fld |> FIXField.StatusText
    | "930"B ->
        let pos3, fld = ReadRefCompID bs pos2 
        pos3, fld |> FIXField.RefCompID
    | "931"B ->
        let pos3, fld = ReadRefSubID bs pos2 
        pos3, fld |> FIXField.RefSubID
    | "932"B ->
        let pos3, fld = ReadNetworkResponseID bs pos2 
        pos3, fld |> FIXField.NetworkResponseID
    | "933"B ->
        let pos3, fld = ReadNetworkRequestID bs pos2 
        pos3, fld |> FIXField.NetworkRequestID
    | "934"B ->
        let pos3, fld = ReadLastNetworkResponseID bs pos2 
        pos3, fld |> FIXField.LastNetworkResponseID
    | "935"B ->
        let pos3, fld = ReadNetworkRequestType bs pos2 
        pos3, fld |> FIXField.NetworkRequestType
    | "936"B ->
        let pos3, fld = ReadNoCompIDs bs pos2 
        pos3, fld |> FIXField.NoCompIDs
    | "937"B ->
        let pos3, fld = ReadNetworkStatusResponseType bs pos2 
        pos3, fld |> FIXField.NetworkStatusResponseType
    | "938"B ->
        let pos3, fld = ReadNoCollInquiryQualifier bs pos2 
        pos3, fld |> FIXField.NoCollInquiryQualifier
    | "939"B ->
        let pos3, fld = ReadTrdRptStatus bs pos2 
        pos3, fld |> FIXField.TrdRptStatus
    | "940"B ->
        let pos3, fld = ReadAffirmStatus bs pos2 
        pos3, fld |> FIXField.AffirmStatus
    | "941"B ->
        let pos3, fld = ReadUnderlyingStrikeCurrency bs pos2 
        pos3, fld |> FIXField.UnderlyingStrikeCurrency
    | "942"B ->
        let pos3, fld = ReadLegStrikeCurrency bs pos2 
        pos3, fld |> FIXField.LegStrikeCurrency
    | "943"B ->
        let pos3, fld = ReadTimeBracket bs pos2 
        pos3, fld |> FIXField.TimeBracket
    | "944"B ->
        let pos3, fld = ReadCollAction bs pos2 
        pos3, fld |> FIXField.CollAction
    | "945"B ->
        let pos3, fld = ReadCollInquiryStatus bs pos2 
        pos3, fld |> FIXField.CollInquiryStatus
    | "946"B ->
        let pos3, fld = ReadCollInquiryResult bs pos2 
        pos3, fld |> FIXField.CollInquiryResult
    | "947"B ->
        let pos3, fld = ReadStrikeCurrency bs pos2 
        pos3, fld |> FIXField.StrikeCurrency
    | "948"B ->
        let pos3, fld = ReadNoNested3PartyIDs bs pos2 
        pos3, fld |> FIXField.NoNested3PartyIDs
    | "949"B ->
        let pos3, fld = ReadNested3PartyID bs pos2 
        pos3, fld |> FIXField.Nested3PartyID
    | "950"B ->
        let pos3, fld = ReadNested3PartyIDSource bs pos2 
        pos3, fld |> FIXField.Nested3PartyIDSource
    | "951"B ->
        let pos3, fld = ReadNested3PartyRole bs pos2 
        pos3, fld |> FIXField.Nested3PartyRole
    | "952"B ->
        let pos3, fld = ReadNoNested3PartySubIDs bs pos2 
        pos3, fld |> FIXField.NoNested3PartySubIDs
    | "953"B ->
        let pos3, fld = ReadNested3PartySubID bs pos2 
        pos3, fld |> FIXField.Nested3PartySubID
    | "954"B ->
        let pos3, fld = ReadNested3PartySubIDType bs pos2 
        pos3, fld |> FIXField.Nested3PartySubIDType
    | "955"B ->
        let pos3, fld = ReadLegContractSettlMonth bs pos2 
        pos3, fld |> FIXField.LegContractSettlMonth
    | "956"B ->
        let pos3, fld = ReadLegInterestAccrualDate bs pos2 
        pos3, fld |> FIXField.LegInterestAccrualDate
    |  _  -> failwith "FIXField invalid tag" 
