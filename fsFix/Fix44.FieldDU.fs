module Fix44.FieldDU


open Fix44.Fields
open Fix44.FieldReaders
open Fix44.FieldWriters


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

// only used for property based testing
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


// only used for property based testing, can generate random but valid fields of any type, and have them dispatched to the correct reading function
let ReadField (bs:byte[]) (pos:int) =
    let posSep = FIXBuf.findNextTagValSep bs pos
    let pos2 = posSep + 1
    let tag = FIXBufIndexer.convTagToInt bs pos (posSep - pos)
    let posEnd = FIXBuf.findNextFieldTermOrEnd bs pos2
    let len = posEnd - pos2
    match tag with
    | 1 ->
        let fld = ReadAccountIdx bs pos2 len
        fld |> FIXField.Account
    | 2 ->
        let fld = ReadAdvIdIdx bs pos2 len
        fld |> FIXField.AdvId
    | 3 ->
        let fld = ReadAdvRefIDIdx bs pos2 len
        fld |> FIXField.AdvRefID
    | 4 ->
        let fld = ReadAdvSideIdx bs pos2 len
        fld |> FIXField.AdvSide
    | 5 ->
        let fld = ReadAdvTransTypeIdx bs pos2 len
        fld |> FIXField.AdvTransType
    | 6 ->
        let fld = ReadAvgPxIdx bs pos2 len
        fld |> FIXField.AvgPx
    | 7 ->
        let fld = ReadBeginSeqNoIdx bs pos2 len
        fld |> FIXField.BeginSeqNo
    | 8 ->
        let fld = ReadBeginStringIdx bs pos2 len
        fld |> FIXField.BeginString
    | 9 ->
        let fld = ReadBodyLengthIdx bs pos2 len
        fld |> FIXField.BodyLength
    | 10 ->
        let fld = ReadCheckSumIdx bs pos2 len
        fld |> FIXField.CheckSum
    | 11 ->
        let fld = ReadClOrdIDIdx bs pos2 len
        fld |> FIXField.ClOrdID
    | 12 ->
        let fld = ReadCommissionIdx bs pos2 len
        fld |> FIXField.Commission
    | 13 ->
        let fld = ReadCommTypeIdx bs pos2 len
        fld |> FIXField.CommType
    | 14 ->
        let fld = ReadCumQtyIdx bs pos2 len
        fld |> FIXField.CumQty
    | 15 ->
        let fld = ReadCurrencyIdx bs pos2 len
        fld |> FIXField.Currency
    | 16 ->
        let fld = ReadEndSeqNoIdx bs pos2 len
        fld |> FIXField.EndSeqNo
    | 17 ->
        let fld = ReadExecIDIdx bs pos2 len
        fld |> FIXField.ExecID
    | 18 ->
        let fld = ReadExecInstIdx bs pos2 len
        fld |> FIXField.ExecInst
    | 19 ->
        let fld = ReadExecRefIDIdx bs pos2 len
        fld |> FIXField.ExecRefID
    | 21 ->
        let fld = ReadHandlInstIdx bs pos2 len
        fld |> FIXField.HandlInst
    | 22 ->
        let fld = ReadSecurityIDSourceIdx bs pos2 len
        fld |> FIXField.SecurityIDSource
    | 23 ->
        let fld = ReadIOIidIdx bs pos2 len
        fld |> FIXField.IOIid
    | 25 ->
        let fld = ReadIOIQltyIndIdx bs pos2 len
        fld |> FIXField.IOIQltyInd
    | 26 ->
        let fld = ReadIOIRefIDIdx bs pos2 len
        fld |> FIXField.IOIRefID
    | 27 ->
        let fld = ReadIOIQtyIdx bs pos2 len
        fld |> FIXField.IOIQty
    | 28 ->
        let fld = ReadIOITransTypeIdx bs pos2 len
        fld |> FIXField.IOITransType
    | 29 ->
        let fld = ReadLastCapacityIdx bs pos2 len
        fld |> FIXField.LastCapacity
    | 30 ->
        let fld = ReadLastMktIdx bs pos2 len
        fld |> FIXField.LastMkt
    | 31 ->
        let fld = ReadLastPxIdx bs pos2 len
        fld |> FIXField.LastPx
    | 32 ->
        let fld = ReadLastQtyIdx bs pos2 len
        fld |> FIXField.LastQty
    | 33 ->
        let fld = ReadLinesOfTextIdx bs pos2 len
        fld |> FIXField.LinesOfText
    | 34 ->
        let fld = ReadMsgSeqNumIdx bs pos2 len
        fld |> FIXField.MsgSeqNum
    | 35 ->
        let fld = ReadMsgTypeIdx bs pos2 len
        fld |> FIXField.MsgType
    | 36 ->
        let fld = ReadNewSeqNoIdx bs pos2 len
        fld |> FIXField.NewSeqNo
    | 37 ->
        let fld = ReadOrderIDIdx bs pos2 len
        fld |> FIXField.OrderID
    | 38 ->
        let fld = ReadOrderQtyIdx bs pos2 len
        fld |> FIXField.OrderQty
    | 39 ->
        let fld = ReadOrdStatusIdx bs pos2 len
        fld |> FIXField.OrdStatus
    | 40 ->
        let fld = ReadOrdTypeIdx bs pos2 len
        fld |> FIXField.OrdType
    | 41 ->
        let fld = ReadOrigClOrdIDIdx bs pos2 len
        fld |> FIXField.OrigClOrdID
    | 42 ->
        let fld = ReadOrigTimeIdx bs pos2 len
        fld |> FIXField.OrigTime
    | 43 ->
        let fld = ReadPossDupFlagIdx bs pos2 len
        fld |> FIXField.PossDupFlag
    | 44 ->
        let fld = ReadPriceIdx bs pos2 len
        fld |> FIXField.Price
    | 45 ->
        let fld = ReadRefSeqNumIdx bs pos2 len
        fld |> FIXField.RefSeqNum
    | 48 ->
        let fld = ReadSecurityIDIdx bs pos2 len
        fld |> FIXField.SecurityID
    | 49 ->
        let fld = ReadSenderCompIDIdx bs pos2 len
        fld |> FIXField.SenderCompID
    | 50 ->
        let fld = ReadSenderSubIDIdx bs pos2 len
        fld |> FIXField.SenderSubID
    | 52 ->
        let fld = ReadSendingTimeIdx bs pos2 len
        fld |> FIXField.SendingTime
    | 53 ->
        let fld = ReadQuantityIdx bs pos2 len
        fld |> FIXField.Quantity
    | 54 ->
        let fld = ReadSideIdx bs pos2 len
        fld |> FIXField.Side
    | 55 ->
        let fld = ReadSymbolIdx bs pos2 len
        fld |> FIXField.Symbol
    | 56 ->
        let fld = ReadTargetCompIDIdx bs pos2 len
        fld |> FIXField.TargetCompID
    | 57 ->
        let fld = ReadTargetSubIDIdx bs pos2 len
        fld |> FIXField.TargetSubID
    | 58 ->
        let fld = ReadTextIdx bs pos2 len
        fld |> FIXField.Text
    | 59 ->
        let fld = ReadTimeInForceIdx bs pos2 len
        fld |> FIXField.TimeInForce
    | 60 ->
        let fld = ReadTransactTimeIdx bs pos2 len
        fld |> FIXField.TransactTime
    | 61 ->
        let fld = ReadUrgencyIdx bs pos2 len
        fld |> FIXField.Urgency
    | 62 ->
        let fld = ReadValidUntilTimeIdx bs pos2 len
        fld |> FIXField.ValidUntilTime
    | 63 ->
        let fld = ReadSettlTypeIdx bs pos2 len
        fld |> FIXField.SettlType
    | 64 ->
        let fld = ReadSettlDateIdx bs pos2 len
        fld |> FIXField.SettlDate
    | 65 ->
        let fld = ReadSymbolSfxIdx bs pos2 len
        fld |> FIXField.SymbolSfx
    | 66 ->
        let fld = ReadListIDIdx bs pos2 len
        fld |> FIXField.ListID
    | 67 ->
        let fld = ReadListSeqNoIdx bs pos2 len
        fld |> FIXField.ListSeqNo
    | 68 ->
        let fld = ReadTotNoOrdersIdx bs pos2 len
        fld |> FIXField.TotNoOrders
    | 69 ->
        let fld = ReadListExecInstIdx bs pos2 len
        fld |> FIXField.ListExecInst
    | 70 ->
        let fld = ReadAllocIDIdx bs pos2 len
        fld |> FIXField.AllocID
    | 71 ->
        let fld = ReadAllocTransTypeIdx bs pos2 len
        fld |> FIXField.AllocTransType
    | 72 ->
        let fld = ReadRefAllocIDIdx bs pos2 len
        fld |> FIXField.RefAllocID
    | 73 ->
        let fld = ReadNoOrdersIdx bs pos2 len
        fld |> FIXField.NoOrders
    | 74 ->
        let fld = ReadAvgPxPrecisionIdx bs pos2 len
        fld |> FIXField.AvgPxPrecision
    | 75 ->
        let fld = ReadTradeDateIdx bs pos2 len
        fld |> FIXField.TradeDate
    | 77 ->
        let fld = ReadPositionEffectIdx bs pos2 len
        fld |> FIXField.PositionEffect
    | 78 ->
        let fld = ReadNoAllocsIdx bs pos2 len
        fld |> FIXField.NoAllocs
    | 79 ->
        let fld = ReadAllocAccountIdx bs pos2 len
        fld |> FIXField.AllocAccount
    | 80 ->
        let fld = ReadAllocQtyIdx bs pos2 len
        fld |> FIXField.AllocQty
    | 81 ->
        let fld = ReadProcessCodeIdx bs pos2 len
        fld |> FIXField.ProcessCode
    | 82 ->
        let fld = ReadNoRptsIdx bs pos2 len
        fld |> FIXField.NoRpts
    | 83 ->
        let fld = ReadRptSeqIdx bs pos2 len
        fld |> FIXField.RptSeq
    | 84 ->
        let fld = ReadCxlQtyIdx bs pos2 len
        fld |> FIXField.CxlQty
    | 85 ->
        let fld = ReadNoDlvyInstIdx bs pos2 len
        fld |> FIXField.NoDlvyInst
    | 87 ->
        let fld = ReadAllocStatusIdx bs pos2 len
        fld |> FIXField.AllocStatus
    | 88 ->
        let fld = ReadAllocRejCodeIdx bs pos2 len
        fld |> FIXField.AllocRejCode
    | 93 ->
        let fld = ReadSignatureIdx bs pos2 len
        fld |> FIXField.Signature // len->string compound field
    | 90 ->
        let fld = ReadSecureDataIdx bs pos2 len
        fld |> FIXField.SecureData // len->string compound field
    | 94 ->
        let fld = ReadEmailTypeIdx bs pos2 len
        fld |> FIXField.EmailType
    | 95 ->
        let fld = ReadRawDataIdx bs pos2 len
        fld |> FIXField.RawData // len->string compound field
    | 97 ->
        let fld = ReadPossResendIdx bs pos2 len
        fld |> FIXField.PossResend
    | 98 ->
        let fld = ReadEncryptMethodIdx bs pos2 len
        fld |> FIXField.EncryptMethod
    | 99 ->
        let fld = ReadStopPxIdx bs pos2 len
        fld |> FIXField.StopPx
    | 100 ->
        let fld = ReadExDestinationIdx bs pos2 len
        fld |> FIXField.ExDestination
    | 102 ->
        let fld = ReadCxlRejReasonIdx bs pos2 len
        fld |> FIXField.CxlRejReason
    | 103 ->
        let fld = ReadOrdRejReasonIdx bs pos2 len
        fld |> FIXField.OrdRejReason
    | 104 ->
        let fld = ReadIOIQualifierIdx bs pos2 len
        fld |> FIXField.IOIQualifier
    | 105 ->
        let fld = ReadWaveNoIdx bs pos2 len
        fld |> FIXField.WaveNo
    | 106 ->
        let fld = ReadIssuerIdx bs pos2 len
        fld |> FIXField.Issuer
    | 107 ->
        let fld = ReadSecurityDescIdx bs pos2 len
        fld |> FIXField.SecurityDesc
    | 108 ->
        let fld = ReadHeartBtIntIdx bs pos2 len
        fld |> FIXField.HeartBtInt
    | 110 ->
        let fld = ReadMinQtyIdx bs pos2 len
        fld |> FIXField.MinQty
    | 111 ->
        let fld = ReadMaxFloorIdx bs pos2 len
        fld |> FIXField.MaxFloor
    | 112 ->
        let fld = ReadTestReqIDIdx bs pos2 len
        fld |> FIXField.TestReqID
    | 113 ->
        let fld = ReadReportToExchIdx bs pos2 len
        fld |> FIXField.ReportToExch
    | 114 ->
        let fld = ReadLocateReqdIdx bs pos2 len
        fld |> FIXField.LocateReqd
    | 115 ->
        let fld = ReadOnBehalfOfCompIDIdx bs pos2 len
        fld |> FIXField.OnBehalfOfCompID
    | 116 ->
        let fld = ReadOnBehalfOfSubIDIdx bs pos2 len
        fld |> FIXField.OnBehalfOfSubID
    | 117 ->
        let fld = ReadQuoteIDIdx bs pos2 len
        fld |> FIXField.QuoteID
    | 118 ->
        let fld = ReadNetMoneyIdx bs pos2 len
        fld |> FIXField.NetMoney
    | 119 ->
        let fld = ReadSettlCurrAmtIdx bs pos2 len
        fld |> FIXField.SettlCurrAmt
    | 120 ->
        let fld = ReadSettlCurrencyIdx bs pos2 len
        fld |> FIXField.SettlCurrency
    | 121 ->
        let fld = ReadForexReqIdx bs pos2 len
        fld |> FIXField.ForexReq
    | 122 ->
        let fld = ReadOrigSendingTimeIdx bs pos2 len
        fld |> FIXField.OrigSendingTime
    | 123 ->
        let fld = ReadGapFillFlagIdx bs pos2 len
        fld |> FIXField.GapFillFlag
    | 124 ->
        let fld = ReadNoExecsIdx bs pos2 len
        fld |> FIXField.NoExecs
    | 126 ->
        let fld = ReadExpireTimeIdx bs pos2 len
        fld |> FIXField.ExpireTime
    | 127 ->
        let fld = ReadDKReasonIdx bs pos2 len
        fld |> FIXField.DKReason
    | 128 ->
        let fld = ReadDeliverToCompIDIdx bs pos2 len
        fld |> FIXField.DeliverToCompID
    | 129 ->
        let fld = ReadDeliverToSubIDIdx bs pos2 len
        fld |> FIXField.DeliverToSubID
    | 130 ->
        let fld = ReadIOINaturalFlagIdx bs pos2 len
        fld |> FIXField.IOINaturalFlag
    | 131 ->
        let fld = ReadQuoteReqIDIdx bs pos2 len
        fld |> FIXField.QuoteReqID
    | 132 ->
        let fld = ReadBidPxIdx bs pos2 len
        fld |> FIXField.BidPx
    | 133 ->
        let fld = ReadOfferPxIdx bs pos2 len
        fld |> FIXField.OfferPx
    | 134 ->
        let fld = ReadBidSizeIdx bs pos2 len
        fld |> FIXField.BidSize
    | 135 ->
        let fld = ReadOfferSizeIdx bs pos2 len
        fld |> FIXField.OfferSize
    | 136 ->
        let fld = ReadNoMiscFeesIdx bs pos2 len
        fld |> FIXField.NoMiscFees
    | 137 ->
        let fld = ReadMiscFeeAmtIdx bs pos2 len
        fld |> FIXField.MiscFeeAmt
    | 138 ->
        let fld = ReadMiscFeeCurrIdx bs pos2 len
        fld |> FIXField.MiscFeeCurr
    | 139 ->
        let fld = ReadMiscFeeTypeIdx bs pos2 len
        fld |> FIXField.MiscFeeType
    | 140 ->
        let fld = ReadPrevClosePxIdx bs pos2 len
        fld |> FIXField.PrevClosePx
    | 141 ->
        let fld = ReadResetSeqNumFlagIdx bs pos2 len
        fld |> FIXField.ResetSeqNumFlag
    | 142 ->
        let fld = ReadSenderLocationIDIdx bs pos2 len
        fld |> FIXField.SenderLocationID
    | 143 ->
        let fld = ReadTargetLocationIDIdx bs pos2 len
        fld |> FIXField.TargetLocationID
    | 144 ->
        let fld = ReadOnBehalfOfLocationIDIdx bs pos2 len
        fld |> FIXField.OnBehalfOfLocationID
    | 145 ->
        let fld = ReadDeliverToLocationIDIdx bs pos2 len
        fld |> FIXField.DeliverToLocationID
    | 146 ->
        let fld = ReadNoRelatedSymIdx bs pos2 len
        fld |> FIXField.NoRelatedSym
    | 147 ->
        let fld = ReadSubjectIdx bs pos2 len
        fld |> FIXField.Subject
    | 148 ->
        let fld = ReadHeadlineIdx bs pos2 len
        fld |> FIXField.Headline
    | 149 ->
        let fld = ReadURLLinkIdx bs pos2 len
        fld |> FIXField.URLLink
    | 150 ->
        let fld = ReadExecTypeIdx bs pos2 len
        fld |> FIXField.ExecType
    | 151 ->
        let fld = ReadLeavesQtyIdx bs pos2 len
        fld |> FIXField.LeavesQty
    | 152 ->
        let fld = ReadCashOrderQtyIdx bs pos2 len
        fld |> FIXField.CashOrderQty
    | 153 ->
        let fld = ReadAllocAvgPxIdx bs pos2 len
        fld |> FIXField.AllocAvgPx
    | 154 ->
        let fld = ReadAllocNetMoneyIdx bs pos2 len
        fld |> FIXField.AllocNetMoney
    | 155 ->
        let fld = ReadSettlCurrFxRateIdx bs pos2 len
        fld |> FIXField.SettlCurrFxRate
    | 156 ->
        let fld = ReadSettlCurrFxRateCalcIdx bs pos2 len
        fld |> FIXField.SettlCurrFxRateCalc
    | 157 ->
        let fld = ReadNumDaysInterestIdx bs pos2 len
        fld |> FIXField.NumDaysInterest
    | 158 ->
        let fld = ReadAccruedInterestRateIdx bs pos2 len
        fld |> FIXField.AccruedInterestRate
    | 159 ->
        let fld = ReadAccruedInterestAmtIdx bs pos2 len
        fld |> FIXField.AccruedInterestAmt
    | 160 ->
        let fld = ReadSettlInstModeIdx bs pos2 len
        fld |> FIXField.SettlInstMode
    | 161 ->
        let fld = ReadAllocTextIdx bs pos2 len
        fld |> FIXField.AllocText
    | 162 ->
        let fld = ReadSettlInstIDIdx bs pos2 len
        fld |> FIXField.SettlInstID
    | 163 ->
        let fld = ReadSettlInstTransTypeIdx bs pos2 len
        fld |> FIXField.SettlInstTransType
    | 164 ->
        let fld = ReadEmailThreadIDIdx bs pos2 len
        fld |> FIXField.EmailThreadID
    | 165 ->
        let fld = ReadSettlInstSourceIdx bs pos2 len
        fld |> FIXField.SettlInstSource
    | 167 ->
        let fld = ReadSecurityTypeIdx bs pos2 len
        fld |> FIXField.SecurityType
    | 168 ->
        let fld = ReadEffectiveTimeIdx bs pos2 len
        fld |> FIXField.EffectiveTime
    | 169 ->
        let fld = ReadStandInstDbTypeIdx bs pos2 len
        fld |> FIXField.StandInstDbType
    | 170 ->
        let fld = ReadStandInstDbNameIdx bs pos2 len
        fld |> FIXField.StandInstDbName
    | 171 ->
        let fld = ReadStandInstDbIDIdx bs pos2 len
        fld |> FIXField.StandInstDbID
    | 172 ->
        let fld = ReadSettlDeliveryTypeIdx bs pos2 len
        fld |> FIXField.SettlDeliveryType
    | 188 ->
        let fld = ReadBidSpotRateIdx bs pos2 len
        fld |> FIXField.BidSpotRate
    | 189 ->
        let fld = ReadBidForwardPointsIdx bs pos2 len
        fld |> FIXField.BidForwardPoints
    | 190 ->
        let fld = ReadOfferSpotRateIdx bs pos2 len
        fld |> FIXField.OfferSpotRate
    | 191 ->
        let fld = ReadOfferForwardPointsIdx bs pos2 len
        fld |> FIXField.OfferForwardPoints
    | 192 ->
        let fld = ReadOrderQty2Idx bs pos2 len
        fld |> FIXField.OrderQty2
    | 193 ->
        let fld = ReadSettlDate2Idx bs pos2 len
        fld |> FIXField.SettlDate2
    | 194 ->
        let fld = ReadLastSpotRateIdx bs pos2 len
        fld |> FIXField.LastSpotRate
    | 195 ->
        let fld = ReadLastForwardPointsIdx bs pos2 len
        fld |> FIXField.LastForwardPoints
    | 196 ->
        let fld = ReadAllocLinkIDIdx bs pos2 len
        fld |> FIXField.AllocLinkID
    | 197 ->
        let fld = ReadAllocLinkTypeIdx bs pos2 len
        fld |> FIXField.AllocLinkType
    | 198 ->
        let fld = ReadSecondaryOrderIDIdx bs pos2 len
        fld |> FIXField.SecondaryOrderID
    | 199 ->
        let fld = ReadNoIOIQualifiersIdx bs pos2 len
        fld |> FIXField.NoIOIQualifiers
    | 200 ->
        let fld = ReadMaturityMonthYearIdx bs pos2 len
        fld |> FIXField.MaturityMonthYear
    | 201 ->
        let fld = ReadPutOrCallIdx bs pos2 len
        fld |> FIXField.PutOrCall
    | 202 ->
        let fld = ReadStrikePriceIdx bs pos2 len
        fld |> FIXField.StrikePrice
    | 203 ->
        let fld = ReadCoveredOrUncoveredIdx bs pos2 len
        fld |> FIXField.CoveredOrUncovered
    | 206 ->
        let fld = ReadOptAttributeIdx bs pos2 len
        fld |> FIXField.OptAttribute
    | 207 ->
        let fld = ReadSecurityExchangeIdx bs pos2 len
        fld |> FIXField.SecurityExchange
    | 208 ->
        let fld = ReadNotifyBrokerOfCreditIdx bs pos2 len
        fld |> FIXField.NotifyBrokerOfCredit
    | 209 ->
        let fld = ReadAllocHandlInstIdx bs pos2 len
        fld |> FIXField.AllocHandlInst
    | 210 ->
        let fld = ReadMaxShowIdx bs pos2 len
        fld |> FIXField.MaxShow
    | 211 ->
        let fld = ReadPegOffsetValueIdx bs pos2 len
        fld |> FIXField.PegOffsetValue
    | 212 ->
        let fld = ReadXmlDataIdx bs pos2 len
        fld |> FIXField.XmlData // len->string compound field
    | 214 ->
        let fld = ReadSettlInstRefIDIdx bs pos2 len
        fld |> FIXField.SettlInstRefID
    | 215 ->
        let fld = ReadNoRoutingIDsIdx bs pos2 len
        fld |> FIXField.NoRoutingIDs
    | 216 ->
        let fld = ReadRoutingTypeIdx bs pos2 len
        fld |> FIXField.RoutingType
    | 217 ->
        let fld = ReadRoutingIDIdx bs pos2 len
        fld |> FIXField.RoutingID
    | 218 ->
        let fld = ReadSpreadIdx bs pos2 len
        fld |> FIXField.Spread
    | 220 ->
        let fld = ReadBenchmarkCurveCurrencyIdx bs pos2 len
        fld |> FIXField.BenchmarkCurveCurrency
    | 221 ->
        let fld = ReadBenchmarkCurveNameIdx bs pos2 len
        fld |> FIXField.BenchmarkCurveName
    | 222 ->
        let fld = ReadBenchmarkCurvePointIdx bs pos2 len
        fld |> FIXField.BenchmarkCurvePoint
    | 223 ->
        let fld = ReadCouponRateIdx bs pos2 len
        fld |> FIXField.CouponRate
    | 224 ->
        let fld = ReadCouponPaymentDateIdx bs pos2 len
        fld |> FIXField.CouponPaymentDate
    | 225 ->
        let fld = ReadIssueDateIdx bs pos2 len
        fld |> FIXField.IssueDate
    | 226 ->
        let fld = ReadRepurchaseTermIdx bs pos2 len
        fld |> FIXField.RepurchaseTerm
    | 227 ->
        let fld = ReadRepurchaseRateIdx bs pos2 len
        fld |> FIXField.RepurchaseRate
    | 228 ->
        let fld = ReadFactorIdx bs pos2 len
        fld |> FIXField.Factor
    | 229 ->
        let fld = ReadTradeOriginationDateIdx bs pos2 len
        fld |> FIXField.TradeOriginationDate
    | 230 ->
        let fld = ReadExDateIdx bs pos2 len
        fld |> FIXField.ExDate
    | 231 ->
        let fld = ReadContractMultiplierIdx bs pos2 len
        fld |> FIXField.ContractMultiplier
    | 232 ->
        let fld = ReadNoStipulationsIdx bs pos2 len
        fld |> FIXField.NoStipulations
    | 233 ->
        let fld = ReadStipulationTypeIdx bs pos2 len
        fld |> FIXField.StipulationType
    | 234 ->
        let fld = ReadStipulationValueIdx bs pos2 len
        fld |> FIXField.StipulationValue
    | 235 ->
        let fld = ReadYieldTypeIdx bs pos2 len
        fld |> FIXField.YieldType
    | 236 ->
        let fld = ReadYieldIdx bs pos2 len
        fld |> FIXField.Yield
    | 237 ->
        let fld = ReadTotalTakedownIdx bs pos2 len
        fld |> FIXField.TotalTakedown
    | 238 ->
        let fld = ReadConcessionIdx bs pos2 len
        fld |> FIXField.Concession
    | 239 ->
        let fld = ReadRepoCollateralSecurityTypeIdx bs pos2 len
        fld |> FIXField.RepoCollateralSecurityType
    | 240 ->
        let fld = ReadRedemptionDateIdx bs pos2 len
        fld |> FIXField.RedemptionDate
    | 241 ->
        let fld = ReadUnderlyingCouponPaymentDateIdx bs pos2 len
        fld |> FIXField.UnderlyingCouponPaymentDate
    | 242 ->
        let fld = ReadUnderlyingIssueDateIdx bs pos2 len
        fld |> FIXField.UnderlyingIssueDate
    | 243 ->
        let fld = ReadUnderlyingRepoCollateralSecurityTypeIdx bs pos2 len
        fld |> FIXField.UnderlyingRepoCollateralSecurityType
    | 244 ->
        let fld = ReadUnderlyingRepurchaseTermIdx bs pos2 len
        fld |> FIXField.UnderlyingRepurchaseTerm
    | 245 ->
        let fld = ReadUnderlyingRepurchaseRateIdx bs pos2 len
        fld |> FIXField.UnderlyingRepurchaseRate
    | 246 ->
        let fld = ReadUnderlyingFactorIdx bs pos2 len
        fld |> FIXField.UnderlyingFactor
    | 247 ->
        let fld = ReadUnderlyingRedemptionDateIdx bs pos2 len
        fld |> FIXField.UnderlyingRedemptionDate
    | 248 ->
        let fld = ReadLegCouponPaymentDateIdx bs pos2 len
        fld |> FIXField.LegCouponPaymentDate
    | 249 ->
        let fld = ReadLegIssueDateIdx bs pos2 len
        fld |> FIXField.LegIssueDate
    | 250 ->
        let fld = ReadLegRepoCollateralSecurityTypeIdx bs pos2 len
        fld |> FIXField.LegRepoCollateralSecurityType
    | 251 ->
        let fld = ReadLegRepurchaseTermIdx bs pos2 len
        fld |> FIXField.LegRepurchaseTerm
    | 252 ->
        let fld = ReadLegRepurchaseRateIdx bs pos2 len
        fld |> FIXField.LegRepurchaseRate
    | 253 ->
        let fld = ReadLegFactorIdx bs pos2 len
        fld |> FIXField.LegFactor
    | 254 ->
        let fld = ReadLegRedemptionDateIdx bs pos2 len
        fld |> FIXField.LegRedemptionDate
    | 255 ->
        let fld = ReadCreditRatingIdx bs pos2 len
        fld |> FIXField.CreditRating
    | 256 ->
        let fld = ReadUnderlyingCreditRatingIdx bs pos2 len
        fld |> FIXField.UnderlyingCreditRating
    | 257 ->
        let fld = ReadLegCreditRatingIdx bs pos2 len
        fld |> FIXField.LegCreditRating
    | 258 ->
        let fld = ReadTradedFlatSwitchIdx bs pos2 len
        fld |> FIXField.TradedFlatSwitch
    | 259 ->
        let fld = ReadBasisFeatureDateIdx bs pos2 len
        fld |> FIXField.BasisFeatureDate
    | 260 ->
        let fld = ReadBasisFeaturePriceIdx bs pos2 len
        fld |> FIXField.BasisFeaturePrice
    | 262 ->
        let fld = ReadMDReqIDIdx bs pos2 len
        fld |> FIXField.MDReqID
    | 263 ->
        let fld = ReadSubscriptionRequestTypeIdx bs pos2 len
        fld |> FIXField.SubscriptionRequestType
    | 264 ->
        let fld = ReadMarketDepthIdx bs pos2 len
        fld |> FIXField.MarketDepth
    | 265 ->
        let fld = ReadMDUpdateTypeIdx bs pos2 len
        fld |> FIXField.MDUpdateType
    | 266 ->
        let fld = ReadAggregatedBookIdx bs pos2 len
        fld |> FIXField.AggregatedBook
    | 267 ->
        let fld = ReadNoMDEntryTypesIdx bs pos2 len
        fld |> FIXField.NoMDEntryTypes
    | 268 ->
        let fld = ReadNoMDEntriesIdx bs pos2 len
        fld |> FIXField.NoMDEntries
    | 269 ->
        let fld = ReadMDEntryTypeIdx bs pos2 len
        fld |> FIXField.MDEntryType
    | 270 ->
        let fld = ReadMDEntryPxIdx bs pos2 len
        fld |> FIXField.MDEntryPx
    | 271 ->
        let fld = ReadMDEntrySizeIdx bs pos2 len
        fld |> FIXField.MDEntrySize
    | 272 ->
        let fld = ReadMDEntryDateIdx bs pos2 len
        fld |> FIXField.MDEntryDate
    | 273 ->
        let fld = ReadMDEntryTimeIdx bs pos2 len
        fld |> FIXField.MDEntryTime
    | 274 ->
        let fld = ReadTickDirectionIdx bs pos2 len
        fld |> FIXField.TickDirection
    | 275 ->
        let fld = ReadMDMktIdx bs pos2 len
        fld |> FIXField.MDMkt
    | 276 ->
        let fld = ReadQuoteConditionIdx bs pos2 len
        fld |> FIXField.QuoteCondition
    | 277 ->
        let fld = ReadTradeConditionIdx bs pos2 len
        fld |> FIXField.TradeCondition
    | 278 ->
        let fld = ReadMDEntryIDIdx bs pos2 len
        fld |> FIXField.MDEntryID
    | 279 ->
        let fld = ReadMDUpdateActionIdx bs pos2 len
        fld |> FIXField.MDUpdateAction
    | 280 ->
        let fld = ReadMDEntryRefIDIdx bs pos2 len
        fld |> FIXField.MDEntryRefID
    | 281 ->
        let fld = ReadMDReqRejReasonIdx bs pos2 len
        fld |> FIXField.MDReqRejReason
    | 282 ->
        let fld = ReadMDEntryOriginatorIdx bs pos2 len
        fld |> FIXField.MDEntryOriginator
    | 283 ->
        let fld = ReadLocationIDIdx bs pos2 len
        fld |> FIXField.LocationID
    | 284 ->
        let fld = ReadDeskIDIdx bs pos2 len
        fld |> FIXField.DeskID
    | 285 ->
        let fld = ReadDeleteReasonIdx bs pos2 len
        fld |> FIXField.DeleteReason
    | 286 ->
        let fld = ReadOpenCloseSettlFlagIdx bs pos2 len
        fld |> FIXField.OpenCloseSettlFlag
    | 287 ->
        let fld = ReadSellerDaysIdx bs pos2 len
        fld |> FIXField.SellerDays
    | 288 ->
        let fld = ReadMDEntryBuyerIdx bs pos2 len
        fld |> FIXField.MDEntryBuyer
    | 289 ->
        let fld = ReadMDEntrySellerIdx bs pos2 len
        fld |> FIXField.MDEntrySeller
    | 290 ->
        let fld = ReadMDEntryPositionNoIdx bs pos2 len
        fld |> FIXField.MDEntryPositionNo
    | 291 ->
        let fld = ReadFinancialStatusIdx bs pos2 len
        fld |> FIXField.FinancialStatus
    | 292 ->
        let fld = ReadCorporateActionIdx bs pos2 len
        fld |> FIXField.CorporateAction
    | 293 ->
        let fld = ReadDefBidSizeIdx bs pos2 len
        fld |> FIXField.DefBidSize
    | 294 ->
        let fld = ReadDefOfferSizeIdx bs pos2 len
        fld |> FIXField.DefOfferSize
    | 295 ->
        let fld = ReadNoQuoteEntriesIdx bs pos2 len
        fld |> FIXField.NoQuoteEntries
    | 296 ->
        let fld = ReadNoQuoteSetsIdx bs pos2 len
        fld |> FIXField.NoQuoteSets
    | 297 ->
        let fld = ReadQuoteStatusIdx bs pos2 len
        fld |> FIXField.QuoteStatus
    | 298 ->
        let fld = ReadQuoteCancelTypeIdx bs pos2 len
        fld |> FIXField.QuoteCancelType
    | 299 ->
        let fld = ReadQuoteEntryIDIdx bs pos2 len
        fld |> FIXField.QuoteEntryID
    | 300 ->
        let fld = ReadQuoteRejectReasonIdx bs pos2 len
        fld |> FIXField.QuoteRejectReason
    | 301 ->
        let fld = ReadQuoteResponseLevelIdx bs pos2 len
        fld |> FIXField.QuoteResponseLevel
    | 302 ->
        let fld = ReadQuoteSetIDIdx bs pos2 len
        fld |> FIXField.QuoteSetID
    | 303 ->
        let fld = ReadQuoteRequestTypeIdx bs pos2 len
        fld |> FIXField.QuoteRequestType
    | 304 ->
        let fld = ReadTotNoQuoteEntriesIdx bs pos2 len
        fld |> FIXField.TotNoQuoteEntries
    | 305 ->
        let fld = ReadUnderlyingSecurityIDSourceIdx bs pos2 len
        fld |> FIXField.UnderlyingSecurityIDSource
    | 306 ->
        let fld = ReadUnderlyingIssuerIdx bs pos2 len
        fld |> FIXField.UnderlyingIssuer
    | 307 ->
        let fld = ReadUnderlyingSecurityDescIdx bs pos2 len
        fld |> FIXField.UnderlyingSecurityDesc
    | 308 ->
        let fld = ReadUnderlyingSecurityExchangeIdx bs pos2 len
        fld |> FIXField.UnderlyingSecurityExchange
    | 309 ->
        let fld = ReadUnderlyingSecurityIDIdx bs pos2 len
        fld |> FIXField.UnderlyingSecurityID
    | 310 ->
        let fld = ReadUnderlyingSecurityTypeIdx bs pos2 len
        fld |> FIXField.UnderlyingSecurityType
    | 311 ->
        let fld = ReadUnderlyingSymbolIdx bs pos2 len
        fld |> FIXField.UnderlyingSymbol
    | 312 ->
        let fld = ReadUnderlyingSymbolSfxIdx bs pos2 len
        fld |> FIXField.UnderlyingSymbolSfx
    | 313 ->
        let fld = ReadUnderlyingMaturityMonthYearIdx bs pos2 len
        fld |> FIXField.UnderlyingMaturityMonthYear
    | 315 ->
        let fld = ReadUnderlyingPutOrCallIdx bs pos2 len
        fld |> FIXField.UnderlyingPutOrCall
    | 316 ->
        let fld = ReadUnderlyingStrikePriceIdx bs pos2 len
        fld |> FIXField.UnderlyingStrikePrice
    | 317 ->
        let fld = ReadUnderlyingOptAttributeIdx bs pos2 len
        fld |> FIXField.UnderlyingOptAttribute
    | 318 ->
        let fld = ReadUnderlyingCurrencyIdx bs pos2 len
        fld |> FIXField.UnderlyingCurrency
    | 320 ->
        let fld = ReadSecurityReqIDIdx bs pos2 len
        fld |> FIXField.SecurityReqID
    | 321 ->
        let fld = ReadSecurityRequestTypeIdx bs pos2 len
        fld |> FIXField.SecurityRequestType
    | 322 ->
        let fld = ReadSecurityResponseIDIdx bs pos2 len
        fld |> FIXField.SecurityResponseID
    | 323 ->
        let fld = ReadSecurityResponseTypeIdx bs pos2 len
        fld |> FIXField.SecurityResponseType
    | 324 ->
        let fld = ReadSecurityStatusReqIDIdx bs pos2 len
        fld |> FIXField.SecurityStatusReqID
    | 325 ->
        let fld = ReadUnsolicitedIndicatorIdx bs pos2 len
        fld |> FIXField.UnsolicitedIndicator
    | 326 ->
        let fld = ReadSecurityTradingStatusIdx bs pos2 len
        fld |> FIXField.SecurityTradingStatus
    | 327 ->
        let fld = ReadHaltReasonIdx bs pos2 len
        fld |> FIXField.HaltReason
    | 328 ->
        let fld = ReadInViewOfCommonIdx bs pos2 len
        fld |> FIXField.InViewOfCommon
    | 329 ->
        let fld = ReadDueToRelatedIdx bs pos2 len
        fld |> FIXField.DueToRelated
    | 330 ->
        let fld = ReadBuyVolumeIdx bs pos2 len
        fld |> FIXField.BuyVolume
    | 331 ->
        let fld = ReadSellVolumeIdx bs pos2 len
        fld |> FIXField.SellVolume
    | 332 ->
        let fld = ReadHighPxIdx bs pos2 len
        fld |> FIXField.HighPx
    | 333 ->
        let fld = ReadLowPxIdx bs pos2 len
        fld |> FIXField.LowPx
    | 334 ->
        let fld = ReadAdjustmentIdx bs pos2 len
        fld |> FIXField.Adjustment
    | 335 ->
        let fld = ReadTradSesReqIDIdx bs pos2 len
        fld |> FIXField.TradSesReqID
    | 336 ->
        let fld = ReadTradingSessionIDIdx bs pos2 len
        fld |> FIXField.TradingSessionID
    | 337 ->
        let fld = ReadContraTraderIdx bs pos2 len
        fld |> FIXField.ContraTrader
    | 338 ->
        let fld = ReadTradSesMethodIdx bs pos2 len
        fld |> FIXField.TradSesMethod
    | 339 ->
        let fld = ReadTradSesModeIdx bs pos2 len
        fld |> FIXField.TradSesMode
    | 340 ->
        let fld = ReadTradSesStatusIdx bs pos2 len
        fld |> FIXField.TradSesStatus
    | 341 ->
        let fld = ReadTradSesStartTimeIdx bs pos2 len
        fld |> FIXField.TradSesStartTime
    | 342 ->
        let fld = ReadTradSesOpenTimeIdx bs pos2 len
        fld |> FIXField.TradSesOpenTime
    | 343 ->
        let fld = ReadTradSesPreCloseTimeIdx bs pos2 len
        fld |> FIXField.TradSesPreCloseTime
    | 344 ->
        let fld = ReadTradSesCloseTimeIdx bs pos2 len
        fld |> FIXField.TradSesCloseTime
    | 345 ->
        let fld = ReadTradSesEndTimeIdx bs pos2 len
        fld |> FIXField.TradSesEndTime
    | 346 ->
        let fld = ReadNumberOfOrdersIdx bs pos2 len
        fld |> FIXField.NumberOfOrders
    | 347 ->
        let fld = ReadMessageEncodingIdx bs pos2 len
        fld |> FIXField.MessageEncoding
    | 348 ->
        let fld = ReadEncodedIssuerIdx bs pos2 len
        fld |> FIXField.EncodedIssuer // len->string compound field
    | 350 ->
        let fld = ReadEncodedSecurityDescIdx bs pos2 len
        fld |> FIXField.EncodedSecurityDesc // len->string compound field
    | 352 ->
        let fld = ReadEncodedListExecInstIdx bs pos2 len
        fld |> FIXField.EncodedListExecInst // len->string compound field
    | 354 ->
        let fld = ReadEncodedTextIdx bs pos2 len
        fld |> FIXField.EncodedText // len->string compound field
    | 356 ->
        let fld = ReadEncodedSubjectIdx bs pos2 len
        fld |> FIXField.EncodedSubject // len->string compound field
    | 358 ->
        let fld = ReadEncodedHeadlineIdx bs pos2 len
        fld |> FIXField.EncodedHeadline // len->string compound field
    | 360 ->
        let fld = ReadEncodedAllocTextIdx bs pos2 len
        fld |> FIXField.EncodedAllocText // len->string compound field
    | 362 ->
        let fld = ReadEncodedUnderlyingIssuerIdx bs pos2 len
        fld |> FIXField.EncodedUnderlyingIssuer // len->string compound field
    | 364 ->
        let fld = ReadEncodedUnderlyingSecurityDescIdx bs pos2 len
        fld |> FIXField.EncodedUnderlyingSecurityDesc // len->string compound field
    | 366 ->
        let fld = ReadAllocPriceIdx bs pos2 len
        fld |> FIXField.AllocPrice
    | 367 ->
        let fld = ReadQuoteSetValidUntilTimeIdx bs pos2 len
        fld |> FIXField.QuoteSetValidUntilTime
    | 368 ->
        let fld = ReadQuoteEntryRejectReasonIdx bs pos2 len
        fld |> FIXField.QuoteEntryRejectReason
    | 369 ->
        let fld = ReadLastMsgSeqNumProcessedIdx bs pos2 len
        fld |> FIXField.LastMsgSeqNumProcessed
    | 371 ->
        let fld = ReadRefTagIDIdx bs pos2 len
        fld |> FIXField.RefTagID
    | 372 ->
        let fld = ReadRefMsgTypeIdx bs pos2 len
        fld |> FIXField.RefMsgType
    | 373 ->
        let fld = ReadSessionRejectReasonIdx bs pos2 len
        fld |> FIXField.SessionRejectReason
    | 374 ->
        let fld = ReadBidRequestTransTypeIdx bs pos2 len
        fld |> FIXField.BidRequestTransType
    | 375 ->
        let fld = ReadContraBrokerIdx bs pos2 len
        fld |> FIXField.ContraBroker
    | 376 ->
        let fld = ReadComplianceIDIdx bs pos2 len
        fld |> FIXField.ComplianceID
    | 377 ->
        let fld = ReadSolicitedFlagIdx bs pos2 len
        fld |> FIXField.SolicitedFlag
    | 378 ->
        let fld = ReadExecRestatementReasonIdx bs pos2 len
        fld |> FIXField.ExecRestatementReason
    | 379 ->
        let fld = ReadBusinessRejectRefIDIdx bs pos2 len
        fld |> FIXField.BusinessRejectRefID
    | 380 ->
        let fld = ReadBusinessRejectReasonIdx bs pos2 len
        fld |> FIXField.BusinessRejectReason
    | 381 ->
        let fld = ReadGrossTradeAmtIdx bs pos2 len
        fld |> FIXField.GrossTradeAmt
    | 382 ->
        let fld = ReadNoContraBrokersIdx bs pos2 len
        fld |> FIXField.NoContraBrokers
    | 383 ->
        let fld = ReadMaxMessageSizeIdx bs pos2 len
        fld |> FIXField.MaxMessageSize
    | 384 ->
        let fld = ReadNoMsgTypesIdx bs pos2 len
        fld |> FIXField.NoMsgTypes
    | 385 ->
        let fld = ReadMsgDirectionIdx bs pos2 len
        fld |> FIXField.MsgDirection
    | 386 ->
        let fld = ReadNoTradingSessionsIdx bs pos2 len
        fld |> FIXField.NoTradingSessions
    | 387 ->
        let fld = ReadTotalVolumeTradedIdx bs pos2 len
        fld |> FIXField.TotalVolumeTraded
    | 388 ->
        let fld = ReadDiscretionInstIdx bs pos2 len
        fld |> FIXField.DiscretionInst
    | 389 ->
        let fld = ReadDiscretionOffsetValueIdx bs pos2 len
        fld |> FIXField.DiscretionOffsetValue
    | 390 ->
        let fld = ReadBidIDIdx bs pos2 len
        fld |> FIXField.BidID
    | 391 ->
        let fld = ReadClientBidIDIdx bs pos2 len
        fld |> FIXField.ClientBidID
    | 392 ->
        let fld = ReadListNameIdx bs pos2 len
        fld |> FIXField.ListName
    | 393 ->
        let fld = ReadTotNoRelatedSymIdx bs pos2 len
        fld |> FIXField.TotNoRelatedSym
    | 394 ->
        let fld = ReadBidTypeIdx bs pos2 len
        fld |> FIXField.BidType
    | 395 ->
        let fld = ReadNumTicketsIdx bs pos2 len
        fld |> FIXField.NumTickets
    | 396 ->
        let fld = ReadSideValue1Idx bs pos2 len
        fld |> FIXField.SideValue1
    | 397 ->
        let fld = ReadSideValue2Idx bs pos2 len
        fld |> FIXField.SideValue2
    | 398 ->
        let fld = ReadNoBidDescriptorsIdx bs pos2 len
        fld |> FIXField.NoBidDescriptors
    | 399 ->
        let fld = ReadBidDescriptorTypeIdx bs pos2 len
        fld |> FIXField.BidDescriptorType
    | 400 ->
        let fld = ReadBidDescriptorIdx bs pos2 len
        fld |> FIXField.BidDescriptor
    | 401 ->
        let fld = ReadSideValueIndIdx bs pos2 len
        fld |> FIXField.SideValueInd
    | 402 ->
        let fld = ReadLiquidityPctLowIdx bs pos2 len
        fld |> FIXField.LiquidityPctLow
    | 403 ->
        let fld = ReadLiquidityPctHighIdx bs pos2 len
        fld |> FIXField.LiquidityPctHigh
    | 404 ->
        let fld = ReadLiquidityValueIdx bs pos2 len
        fld |> FIXField.LiquidityValue
    | 405 ->
        let fld = ReadEFPTrackingErrorIdx bs pos2 len
        fld |> FIXField.EFPTrackingError
    | 406 ->
        let fld = ReadFairValueIdx bs pos2 len
        fld |> FIXField.FairValue
    | 407 ->
        let fld = ReadOutsideIndexPctIdx bs pos2 len
        fld |> FIXField.OutsideIndexPct
    | 408 ->
        let fld = ReadValueOfFuturesIdx bs pos2 len
        fld |> FIXField.ValueOfFutures
    | 409 ->
        let fld = ReadLiquidityIndTypeIdx bs pos2 len
        fld |> FIXField.LiquidityIndType
    | 410 ->
        let fld = ReadWtAverageLiquidityIdx bs pos2 len
        fld |> FIXField.WtAverageLiquidity
    | 411 ->
        let fld = ReadExchangeForPhysicalIdx bs pos2 len
        fld |> FIXField.ExchangeForPhysical
    | 412 ->
        let fld = ReadOutMainCntryUIndexIdx bs pos2 len
        fld |> FIXField.OutMainCntryUIndex
    | 413 ->
        let fld = ReadCrossPercentIdx bs pos2 len
        fld |> FIXField.CrossPercent
    | 414 ->
        let fld = ReadProgRptReqsIdx bs pos2 len
        fld |> FIXField.ProgRptReqs
    | 415 ->
        let fld = ReadProgPeriodIntervalIdx bs pos2 len
        fld |> FIXField.ProgPeriodInterval
    | 416 ->
        let fld = ReadIncTaxIndIdx bs pos2 len
        fld |> FIXField.IncTaxInd
    | 417 ->
        let fld = ReadNumBiddersIdx bs pos2 len
        fld |> FIXField.NumBidders
    | 418 ->
        let fld = ReadBidTradeTypeIdx bs pos2 len
        fld |> FIXField.BidTradeType
    | 419 ->
        let fld = ReadBasisPxTypeIdx bs pos2 len
        fld |> FIXField.BasisPxType
    | 420 ->
        let fld = ReadNoBidComponentsIdx bs pos2 len
        fld |> FIXField.NoBidComponents
    | 421 ->
        let fld = ReadCountryIdx bs pos2 len
        fld |> FIXField.Country
    | 422 ->
        let fld = ReadTotNoStrikesIdx bs pos2 len
        fld |> FIXField.TotNoStrikes
    | 423 ->
        let fld = ReadPriceTypeIdx bs pos2 len
        fld |> FIXField.PriceType
    | 424 ->
        let fld = ReadDayOrderQtyIdx bs pos2 len
        fld |> FIXField.DayOrderQty
    | 425 ->
        let fld = ReadDayCumQtyIdx bs pos2 len
        fld |> FIXField.DayCumQty
    | 426 ->
        let fld = ReadDayAvgPxIdx bs pos2 len
        fld |> FIXField.DayAvgPx
    | 427 ->
        let fld = ReadGTBookingInstIdx bs pos2 len
        fld |> FIXField.GTBookingInst
    | 428 ->
        let fld = ReadNoStrikesIdx bs pos2 len
        fld |> FIXField.NoStrikes
    | 429 ->
        let fld = ReadListStatusTypeIdx bs pos2 len
        fld |> FIXField.ListStatusType
    | 430 ->
        let fld = ReadNetGrossIndIdx bs pos2 len
        fld |> FIXField.NetGrossInd
    | 431 ->
        let fld = ReadListOrderStatusIdx bs pos2 len
        fld |> FIXField.ListOrderStatus
    | 432 ->
        let fld = ReadExpireDateIdx bs pos2 len
        fld |> FIXField.ExpireDate
    | 433 ->
        let fld = ReadListExecInstTypeIdx bs pos2 len
        fld |> FIXField.ListExecInstType
    | 434 ->
        let fld = ReadCxlRejResponseToIdx bs pos2 len
        fld |> FIXField.CxlRejResponseTo
    | 435 ->
        let fld = ReadUnderlyingCouponRateIdx bs pos2 len
        fld |> FIXField.UnderlyingCouponRate
    | 436 ->
        let fld = ReadUnderlyingContractMultiplierIdx bs pos2 len
        fld |> FIXField.UnderlyingContractMultiplier
    | 437 ->
        let fld = ReadContraTradeQtyIdx bs pos2 len
        fld |> FIXField.ContraTradeQty
    | 438 ->
        let fld = ReadContraTradeTimeIdx bs pos2 len
        fld |> FIXField.ContraTradeTime
    | 441 ->
        let fld = ReadLiquidityNumSecuritiesIdx bs pos2 len
        fld |> FIXField.LiquidityNumSecurities
    | 442 ->
        let fld = ReadMultiLegReportingTypeIdx bs pos2 len
        fld |> FIXField.MultiLegReportingType
    | 443 ->
        let fld = ReadStrikeTimeIdx bs pos2 len
        fld |> FIXField.StrikeTime
    | 444 ->
        let fld = ReadListStatusTextIdx bs pos2 len
        fld |> FIXField.ListStatusText
    | 445 ->
        let fld = ReadEncodedListStatusTextIdx bs pos2 len
        fld |> FIXField.EncodedListStatusText // len->string compound field
    | 447 ->
        let fld = ReadPartyIDSourceIdx bs pos2 len
        fld |> FIXField.PartyIDSource
    | 448 ->
        let fld = ReadPartyIDIdx bs pos2 len
        fld |> FIXField.PartyID
    | 451 ->
        let fld = ReadNetChgPrevDayIdx bs pos2 len
        fld |> FIXField.NetChgPrevDay
    | 452 ->
        let fld = ReadPartyRoleIdx bs pos2 len
        fld |> FIXField.PartyRole
    | 453 ->
        let fld = ReadNoPartyIDsIdx bs pos2 len
        fld |> FIXField.NoPartyIDs
    | 454 ->
        let fld = ReadNoSecurityAltIDIdx bs pos2 len
        fld |> FIXField.NoSecurityAltID
    | 455 ->
        let fld = ReadSecurityAltIDIdx bs pos2 len
        fld |> FIXField.SecurityAltID
    | 456 ->
        let fld = ReadSecurityAltIDSourceIdx bs pos2 len
        fld |> FIXField.SecurityAltIDSource
    | 457 ->
        let fld = ReadNoUnderlyingSecurityAltIDIdx bs pos2 len
        fld |> FIXField.NoUnderlyingSecurityAltID
    | 458 ->
        let fld = ReadUnderlyingSecurityAltIDIdx bs pos2 len
        fld |> FIXField.UnderlyingSecurityAltID
    | 459 ->
        let fld = ReadUnderlyingSecurityAltIDSourceIdx bs pos2 len
        fld |> FIXField.UnderlyingSecurityAltIDSource
    | 460 ->
        let fld = ReadProductIdx bs pos2 len
        fld |> FIXField.Product
    | 461 ->
        let fld = ReadCFICodeIdx bs pos2 len
        fld |> FIXField.CFICode
    | 462 ->
        let fld = ReadUnderlyingProductIdx bs pos2 len
        fld |> FIXField.UnderlyingProduct
    | 463 ->
        let fld = ReadUnderlyingCFICodeIdx bs pos2 len
        fld |> FIXField.UnderlyingCFICode
    | 464 ->
        let fld = ReadTestMessageIndicatorIdx bs pos2 len
        fld |> FIXField.TestMessageIndicator
    | 465 ->
        let fld = ReadQuantityTypeIdx bs pos2 len
        fld |> FIXField.QuantityType
    | 466 ->
        let fld = ReadBookingRefIDIdx bs pos2 len
        fld |> FIXField.BookingRefID
    | 467 ->
        let fld = ReadIndividualAllocIDIdx bs pos2 len
        fld |> FIXField.IndividualAllocID
    | 468 ->
        let fld = ReadRoundingDirectionIdx bs pos2 len
        fld |> FIXField.RoundingDirection
    | 469 ->
        let fld = ReadRoundingModulusIdx bs pos2 len
        fld |> FIXField.RoundingModulus
    | 470 ->
        let fld = ReadCountryOfIssueIdx bs pos2 len
        fld |> FIXField.CountryOfIssue
    | 471 ->
        let fld = ReadStateOrProvinceOfIssueIdx bs pos2 len
        fld |> FIXField.StateOrProvinceOfIssue
    | 472 ->
        let fld = ReadLocaleOfIssueIdx bs pos2 len
        fld |> FIXField.LocaleOfIssue
    | 473 ->
        let fld = ReadNoRegistDtlsIdx bs pos2 len
        fld |> FIXField.NoRegistDtls
    | 474 ->
        let fld = ReadMailingDtlsIdx bs pos2 len
        fld |> FIXField.MailingDtls
    | 475 ->
        let fld = ReadInvestorCountryOfResidenceIdx bs pos2 len
        fld |> FIXField.InvestorCountryOfResidence
    | 476 ->
        let fld = ReadPaymentRefIdx bs pos2 len
        fld |> FIXField.PaymentRef
    | 477 ->
        let fld = ReadDistribPaymentMethodIdx bs pos2 len
        fld |> FIXField.DistribPaymentMethod
    | 478 ->
        let fld = ReadCashDistribCurrIdx bs pos2 len
        fld |> FIXField.CashDistribCurr
    | 479 ->
        let fld = ReadCommCurrencyIdx bs pos2 len
        fld |> FIXField.CommCurrency
    | 480 ->
        let fld = ReadCancellationRightsIdx bs pos2 len
        fld |> FIXField.CancellationRights
    | 481 ->
        let fld = ReadMoneyLaunderingStatusIdx bs pos2 len
        fld |> FIXField.MoneyLaunderingStatus
    | 482 ->
        let fld = ReadMailingInstIdx bs pos2 len
        fld |> FIXField.MailingInst
    | 483 ->
        let fld = ReadTransBkdTimeIdx bs pos2 len
        fld |> FIXField.TransBkdTime
    | 484 ->
        let fld = ReadExecPriceTypeIdx bs pos2 len
        fld |> FIXField.ExecPriceType
    | 485 ->
        let fld = ReadExecPriceAdjustmentIdx bs pos2 len
        fld |> FIXField.ExecPriceAdjustment
    | 486 ->
        let fld = ReadDateOfBirthIdx bs pos2 len
        fld |> FIXField.DateOfBirth
    | 487 ->
        let fld = ReadTradeReportTransTypeIdx bs pos2 len
        fld |> FIXField.TradeReportTransType
    | 488 ->
        let fld = ReadCardHolderNameIdx bs pos2 len
        fld |> FIXField.CardHolderName
    | 489 ->
        let fld = ReadCardNumberIdx bs pos2 len
        fld |> FIXField.CardNumber
    | 490 ->
        let fld = ReadCardExpDateIdx bs pos2 len
        fld |> FIXField.CardExpDate
    | 491 ->
        let fld = ReadCardIssNumIdx bs pos2 len
        fld |> FIXField.CardIssNum
    | 492 ->
        let fld = ReadPaymentMethodIdx bs pos2 len
        fld |> FIXField.PaymentMethod
    | 493 ->
        let fld = ReadRegistAcctTypeIdx bs pos2 len
        fld |> FIXField.RegistAcctType
    | 494 ->
        let fld = ReadDesignationIdx bs pos2 len
        fld |> FIXField.Designation
    | 495 ->
        let fld = ReadTaxAdvantageTypeIdx bs pos2 len
        fld |> FIXField.TaxAdvantageType
    | 496 ->
        let fld = ReadRegistRejReasonTextIdx bs pos2 len
        fld |> FIXField.RegistRejReasonText
    | 497 ->
        let fld = ReadFundRenewWaivIdx bs pos2 len
        fld |> FIXField.FundRenewWaiv
    | 498 ->
        let fld = ReadCashDistribAgentNameIdx bs pos2 len
        fld |> FIXField.CashDistribAgentName
    | 499 ->
        let fld = ReadCashDistribAgentCodeIdx bs pos2 len
        fld |> FIXField.CashDistribAgentCode
    | 500 ->
        let fld = ReadCashDistribAgentAcctNumberIdx bs pos2 len
        fld |> FIXField.CashDistribAgentAcctNumber
    | 501 ->
        let fld = ReadCashDistribPayRefIdx bs pos2 len
        fld |> FIXField.CashDistribPayRef
    | 502 ->
        let fld = ReadCashDistribAgentAcctNameIdx bs pos2 len
        fld |> FIXField.CashDistribAgentAcctName
    | 503 ->
        let fld = ReadCardStartDateIdx bs pos2 len
        fld |> FIXField.CardStartDate
    | 504 ->
        let fld = ReadPaymentDateIdx bs pos2 len
        fld |> FIXField.PaymentDate
    | 505 ->
        let fld = ReadPaymentRemitterIDIdx bs pos2 len
        fld |> FIXField.PaymentRemitterID
    | 506 ->
        let fld = ReadRegistStatusIdx bs pos2 len
        fld |> FIXField.RegistStatus
    | 507 ->
        let fld = ReadRegistRejReasonCodeIdx bs pos2 len
        fld |> FIXField.RegistRejReasonCode
    | 508 ->
        let fld = ReadRegistRefIDIdx bs pos2 len
        fld |> FIXField.RegistRefID
    | 509 ->
        let fld = ReadRegistDtlsIdx bs pos2 len
        fld |> FIXField.RegistDtls
    | 510 ->
        let fld = ReadNoDistribInstsIdx bs pos2 len
        fld |> FIXField.NoDistribInsts
    | 511 ->
        let fld = ReadRegistEmailIdx bs pos2 len
        fld |> FIXField.RegistEmail
    | 512 ->
        let fld = ReadDistribPercentageIdx bs pos2 len
        fld |> FIXField.DistribPercentage
    | 513 ->
        let fld = ReadRegistIDIdx bs pos2 len
        fld |> FIXField.RegistID
    | 514 ->
        let fld = ReadRegistTransTypeIdx bs pos2 len
        fld |> FIXField.RegistTransType
    | 515 ->
        let fld = ReadExecValuationPointIdx bs pos2 len
        fld |> FIXField.ExecValuationPoint
    | 516 ->
        let fld = ReadOrderPercentIdx bs pos2 len
        fld |> FIXField.OrderPercent
    | 517 ->
        let fld = ReadOwnershipTypeIdx bs pos2 len
        fld |> FIXField.OwnershipType
    | 518 ->
        let fld = ReadNoContAmtsIdx bs pos2 len
        fld |> FIXField.NoContAmts
    | 519 ->
        let fld = ReadContAmtTypeIdx bs pos2 len
        fld |> FIXField.ContAmtType
    | 520 ->
        let fld = ReadContAmtValueIdx bs pos2 len
        fld |> FIXField.ContAmtValue
    | 521 ->
        let fld = ReadContAmtCurrIdx bs pos2 len
        fld |> FIXField.ContAmtCurr
    | 522 ->
        let fld = ReadOwnerTypeIdx bs pos2 len
        fld |> FIXField.OwnerType
    | 523 ->
        let fld = ReadPartySubIDIdx bs pos2 len
        fld |> FIXField.PartySubID
    | 524 ->
        let fld = ReadNestedPartyIDIdx bs pos2 len
        fld |> FIXField.NestedPartyID
    | 525 ->
        let fld = ReadNestedPartyIDSourceIdx bs pos2 len
        fld |> FIXField.NestedPartyIDSource
    | 526 ->
        let fld = ReadSecondaryClOrdIDIdx bs pos2 len
        fld |> FIXField.SecondaryClOrdID
    | 527 ->
        let fld = ReadSecondaryExecIDIdx bs pos2 len
        fld |> FIXField.SecondaryExecID
    | 528 ->
        let fld = ReadOrderCapacityIdx bs pos2 len
        fld |> FIXField.OrderCapacity
    | 529 ->
        let fld = ReadOrderRestrictionsIdx bs pos2 len
        fld |> FIXField.OrderRestrictions
    | 530 ->
        let fld = ReadMassCancelRequestTypeIdx bs pos2 len
        fld |> FIXField.MassCancelRequestType
    | 531 ->
        let fld = ReadMassCancelResponseIdx bs pos2 len
        fld |> FIXField.MassCancelResponse
    | 532 ->
        let fld = ReadMassCancelRejectReasonIdx bs pos2 len
        fld |> FIXField.MassCancelRejectReason
    | 533 ->
        let fld = ReadTotalAffectedOrdersIdx bs pos2 len
        fld |> FIXField.TotalAffectedOrders
    | 534 ->
        let fld = ReadNoAffectedOrdersIdx bs pos2 len
        fld |> FIXField.NoAffectedOrders
    | 535 ->
        let fld = ReadAffectedOrderIDIdx bs pos2 len
        fld |> FIXField.AffectedOrderID
    | 536 ->
        let fld = ReadAffectedSecondaryOrderIDIdx bs pos2 len
        fld |> FIXField.AffectedSecondaryOrderID
    | 537 ->
        let fld = ReadQuoteTypeIdx bs pos2 len
        fld |> FIXField.QuoteType
    | 538 ->
        let fld = ReadNestedPartyRoleIdx bs pos2 len
        fld |> FIXField.NestedPartyRole
    | 539 ->
        let fld = ReadNoNestedPartyIDsIdx bs pos2 len
        fld |> FIXField.NoNestedPartyIDs
    | 540 ->
        let fld = ReadTotalAccruedInterestAmtIdx bs pos2 len
        fld |> FIXField.TotalAccruedInterestAmt
    | 541 ->
        let fld = ReadMaturityDateIdx bs pos2 len
        fld |> FIXField.MaturityDate
    | 542 ->
        let fld = ReadUnderlyingMaturityDateIdx bs pos2 len
        fld |> FIXField.UnderlyingMaturityDate
    | 543 ->
        let fld = ReadInstrRegistryIdx bs pos2 len
        fld |> FIXField.InstrRegistry
    | 544 ->
        let fld = ReadCashMarginIdx bs pos2 len
        fld |> FIXField.CashMargin
    | 545 ->
        let fld = ReadNestedPartySubIDIdx bs pos2 len
        fld |> FIXField.NestedPartySubID
    | 546 ->
        let fld = ReadScopeIdx bs pos2 len
        fld |> FIXField.Scope
    | 547 ->
        let fld = ReadMDImplicitDeleteIdx bs pos2 len
        fld |> FIXField.MDImplicitDelete
    | 548 ->
        let fld = ReadCrossIDIdx bs pos2 len
        fld |> FIXField.CrossID
    | 549 ->
        let fld = ReadCrossTypeIdx bs pos2 len
        fld |> FIXField.CrossType
    | 550 ->
        let fld = ReadCrossPrioritizationIdx bs pos2 len
        fld |> FIXField.CrossPrioritization
    | 551 ->
        let fld = ReadOrigCrossIDIdx bs pos2 len
        fld |> FIXField.OrigCrossID
    | 552 ->
        let fld = ReadNoSidesIdx bs pos2 len
        fld |> FIXField.NoSides
    | 553 ->
        let fld = ReadUsernameIdx bs pos2 len
        fld |> FIXField.Username
    | 554 ->
        let fld = ReadPasswordIdx bs pos2 len
        fld |> FIXField.Password
    | 555 ->
        let fld = ReadNoLegsIdx bs pos2 len
        fld |> FIXField.NoLegs
    | 556 ->
        let fld = ReadLegCurrencyIdx bs pos2 len
        fld |> FIXField.LegCurrency
    | 557 ->
        let fld = ReadTotNoSecurityTypesIdx bs pos2 len
        fld |> FIXField.TotNoSecurityTypes
    | 558 ->
        let fld = ReadNoSecurityTypesIdx bs pos2 len
        fld |> FIXField.NoSecurityTypes
    | 559 ->
        let fld = ReadSecurityListRequestTypeIdx bs pos2 len
        fld |> FIXField.SecurityListRequestType
    | 560 ->
        let fld = ReadSecurityRequestResultIdx bs pos2 len
        fld |> FIXField.SecurityRequestResult
    | 561 ->
        let fld = ReadRoundLotIdx bs pos2 len
        fld |> FIXField.RoundLot
    | 562 ->
        let fld = ReadMinTradeVolIdx bs pos2 len
        fld |> FIXField.MinTradeVol
    | 563 ->
        let fld = ReadMultiLegRptTypeReqIdx bs pos2 len
        fld |> FIXField.MultiLegRptTypeReq
    | 564 ->
        let fld = ReadLegPositionEffectIdx bs pos2 len
        fld |> FIXField.LegPositionEffect
    | 565 ->
        let fld = ReadLegCoveredOrUncoveredIdx bs pos2 len
        fld |> FIXField.LegCoveredOrUncovered
    | 566 ->
        let fld = ReadLegPriceIdx bs pos2 len
        fld |> FIXField.LegPrice
    | 567 ->
        let fld = ReadTradSesStatusRejReasonIdx bs pos2 len
        fld |> FIXField.TradSesStatusRejReason
    | 568 ->
        let fld = ReadTradeRequestIDIdx bs pos2 len
        fld |> FIXField.TradeRequestID
    | 569 ->
        let fld = ReadTradeRequestTypeIdx bs pos2 len
        fld |> FIXField.TradeRequestType
    | 570 ->
        let fld = ReadPreviouslyReportedIdx bs pos2 len
        fld |> FIXField.PreviouslyReported
    | 571 ->
        let fld = ReadTradeReportIDIdx bs pos2 len
        fld |> FIXField.TradeReportID
    | 572 ->
        let fld = ReadTradeReportRefIDIdx bs pos2 len
        fld |> FIXField.TradeReportRefID
    | 573 ->
        let fld = ReadMatchStatusIdx bs pos2 len
        fld |> FIXField.MatchStatus
    | 574 ->
        let fld = ReadMatchTypeIdx bs pos2 len
        fld |> FIXField.MatchType
    | 575 ->
        let fld = ReadOddLotIdx bs pos2 len
        fld |> FIXField.OddLot
    | 576 ->
        let fld = ReadNoClearingInstructionsIdx bs pos2 len
        fld |> FIXField.NoClearingInstructions
    | 577 ->
        let fld = ReadClearingInstructionIdx bs pos2 len
        fld |> FIXField.ClearingInstruction
    | 578 ->
        let fld = ReadTradeInputSourceIdx bs pos2 len
        fld |> FIXField.TradeInputSource
    | 579 ->
        let fld = ReadTradeInputDeviceIdx bs pos2 len
        fld |> FIXField.TradeInputDevice
    | 580 ->
        let fld = ReadNoDatesIdx bs pos2 len
        fld |> FIXField.NoDates
    | 581 ->
        let fld = ReadAccountTypeIdx bs pos2 len
        fld |> FIXField.AccountType
    | 582 ->
        let fld = ReadCustOrderCapacityIdx bs pos2 len
        fld |> FIXField.CustOrderCapacity
    | 583 ->
        let fld = ReadClOrdLinkIDIdx bs pos2 len
        fld |> FIXField.ClOrdLinkID
    | 584 ->
        let fld = ReadMassStatusReqIDIdx bs pos2 len
        fld |> FIXField.MassStatusReqID
    | 585 ->
        let fld = ReadMassStatusReqTypeIdx bs pos2 len
        fld |> FIXField.MassStatusReqType
    | 586 ->
        let fld = ReadOrigOrdModTimeIdx bs pos2 len
        fld |> FIXField.OrigOrdModTime
    | 587 ->
        let fld = ReadLegSettlTypeIdx bs pos2 len
        fld |> FIXField.LegSettlType
    | 588 ->
        let fld = ReadLegSettlDateIdx bs pos2 len
        fld |> FIXField.LegSettlDate
    | 589 ->
        let fld = ReadDayBookingInstIdx bs pos2 len
        fld |> FIXField.DayBookingInst
    | 590 ->
        let fld = ReadBookingUnitIdx bs pos2 len
        fld |> FIXField.BookingUnit
    | 591 ->
        let fld = ReadPreallocMethodIdx bs pos2 len
        fld |> FIXField.PreallocMethod
    | 592 ->
        let fld = ReadUnderlyingCountryOfIssueIdx bs pos2 len
        fld |> FIXField.UnderlyingCountryOfIssue
    | 593 ->
        let fld = ReadUnderlyingStateOrProvinceOfIssueIdx bs pos2 len
        fld |> FIXField.UnderlyingStateOrProvinceOfIssue
    | 594 ->
        let fld = ReadUnderlyingLocaleOfIssueIdx bs pos2 len
        fld |> FIXField.UnderlyingLocaleOfIssue
    | 595 ->
        let fld = ReadUnderlyingInstrRegistryIdx bs pos2 len
        fld |> FIXField.UnderlyingInstrRegistry
    | 596 ->
        let fld = ReadLegCountryOfIssueIdx bs pos2 len
        fld |> FIXField.LegCountryOfIssue
    | 597 ->
        let fld = ReadLegStateOrProvinceOfIssueIdx bs pos2 len
        fld |> FIXField.LegStateOrProvinceOfIssue
    | 598 ->
        let fld = ReadLegLocaleOfIssueIdx bs pos2 len
        fld |> FIXField.LegLocaleOfIssue
    | 599 ->
        let fld = ReadLegInstrRegistryIdx bs pos2 len
        fld |> FIXField.LegInstrRegistry
    | 600 ->
        let fld = ReadLegSymbolIdx bs pos2 len
        fld |> FIXField.LegSymbol
    | 601 ->
        let fld = ReadLegSymbolSfxIdx bs pos2 len
        fld |> FIXField.LegSymbolSfx
    | 602 ->
        let fld = ReadLegSecurityIDIdx bs pos2 len
        fld |> FIXField.LegSecurityID
    | 603 ->
        let fld = ReadLegSecurityIDSourceIdx bs pos2 len
        fld |> FIXField.LegSecurityIDSource
    | 604 ->
        let fld = ReadNoLegSecurityAltIDIdx bs pos2 len
        fld |> FIXField.NoLegSecurityAltID
    | 605 ->
        let fld = ReadLegSecurityAltIDIdx bs pos2 len
        fld |> FIXField.LegSecurityAltID
    | 606 ->
        let fld = ReadLegSecurityAltIDSourceIdx bs pos2 len
        fld |> FIXField.LegSecurityAltIDSource
    | 607 ->
        let fld = ReadLegProductIdx bs pos2 len
        fld |> FIXField.LegProduct
    | 608 ->
        let fld = ReadLegCFICodeIdx bs pos2 len
        fld |> FIXField.LegCFICode
    | 609 ->
        let fld = ReadLegSecurityTypeIdx bs pos2 len
        fld |> FIXField.LegSecurityType
    | 610 ->
        let fld = ReadLegMaturityMonthYearIdx bs pos2 len
        fld |> FIXField.LegMaturityMonthYear
    | 611 ->
        let fld = ReadLegMaturityDateIdx bs pos2 len
        fld |> FIXField.LegMaturityDate
    | 612 ->
        let fld = ReadLegStrikePriceIdx bs pos2 len
        fld |> FIXField.LegStrikePrice
    | 613 ->
        let fld = ReadLegOptAttributeIdx bs pos2 len
        fld |> FIXField.LegOptAttribute
    | 614 ->
        let fld = ReadLegContractMultiplierIdx bs pos2 len
        fld |> FIXField.LegContractMultiplier
    | 615 ->
        let fld = ReadLegCouponRateIdx bs pos2 len
        fld |> FIXField.LegCouponRate
    | 616 ->
        let fld = ReadLegSecurityExchangeIdx bs pos2 len
        fld |> FIXField.LegSecurityExchange
    | 617 ->
        let fld = ReadLegIssuerIdx bs pos2 len
        fld |> FIXField.LegIssuer
    | 618 ->
        let fld = ReadEncodedLegIssuerIdx bs pos2 len
        fld |> FIXField.EncodedLegIssuer // len->string compound field
    | 620 ->
        let fld = ReadLegSecurityDescIdx bs pos2 len
        fld |> FIXField.LegSecurityDesc
    | 621 ->
        let fld = ReadEncodedLegSecurityDescIdx bs pos2 len
        fld |> FIXField.EncodedLegSecurityDesc // len->string compound field
    | 623 ->
        let fld = ReadLegRatioQtyIdx bs pos2 len
        fld |> FIXField.LegRatioQty
    | 624 ->
        let fld = ReadLegSideIdx bs pos2 len
        fld |> FIXField.LegSide
    | 625 ->
        let fld = ReadTradingSessionSubIDIdx bs pos2 len
        fld |> FIXField.TradingSessionSubID
    | 626 ->
        let fld = ReadAllocTypeIdx bs pos2 len
        fld |> FIXField.AllocType
    | 627 ->
        let fld = ReadNoHopsIdx bs pos2 len
        fld |> FIXField.NoHops
    | 628 ->
        let fld = ReadHopCompIDIdx bs pos2 len
        fld |> FIXField.HopCompID
    | 629 ->
        let fld = ReadHopSendingTimeIdx bs pos2 len
        fld |> FIXField.HopSendingTime
    | 630 ->
        let fld = ReadHopRefIDIdx bs pos2 len
        fld |> FIXField.HopRefID
    | 631 ->
        let fld = ReadMidPxIdx bs pos2 len
        fld |> FIXField.MidPx
    | 632 ->
        let fld = ReadBidYieldIdx bs pos2 len
        fld |> FIXField.BidYield
    | 633 ->
        let fld = ReadMidYieldIdx bs pos2 len
        fld |> FIXField.MidYield
    | 634 ->
        let fld = ReadOfferYieldIdx bs pos2 len
        fld |> FIXField.OfferYield
    | 635 ->
        let fld = ReadClearingFeeIndicatorIdx bs pos2 len
        fld |> FIXField.ClearingFeeIndicator
    | 636 ->
        let fld = ReadWorkingIndicatorIdx bs pos2 len
        fld |> FIXField.WorkingIndicator
    | 637 ->
        let fld = ReadLegLastPxIdx bs pos2 len
        fld |> FIXField.LegLastPx
    | 638 ->
        let fld = ReadPriorityIndicatorIdx bs pos2 len
        fld |> FIXField.PriorityIndicator
    | 639 ->
        let fld = ReadPriceImprovementIdx bs pos2 len
        fld |> FIXField.PriceImprovement
    | 640 ->
        let fld = ReadPrice2Idx bs pos2 len
        fld |> FIXField.Price2
    | 641 ->
        let fld = ReadLastForwardPoints2Idx bs pos2 len
        fld |> FIXField.LastForwardPoints2
    | 642 ->
        let fld = ReadBidForwardPoints2Idx bs pos2 len
        fld |> FIXField.BidForwardPoints2
    | 643 ->
        let fld = ReadOfferForwardPoints2Idx bs pos2 len
        fld |> FIXField.OfferForwardPoints2
    | 644 ->
        let fld = ReadRFQReqIDIdx bs pos2 len
        fld |> FIXField.RFQReqID
    | 645 ->
        let fld = ReadMktBidPxIdx bs pos2 len
        fld |> FIXField.MktBidPx
    | 646 ->
        let fld = ReadMktOfferPxIdx bs pos2 len
        fld |> FIXField.MktOfferPx
    | 647 ->
        let fld = ReadMinBidSizeIdx bs pos2 len
        fld |> FIXField.MinBidSize
    | 648 ->
        let fld = ReadMinOfferSizeIdx bs pos2 len
        fld |> FIXField.MinOfferSize
    | 649 ->
        let fld = ReadQuoteStatusReqIDIdx bs pos2 len
        fld |> FIXField.QuoteStatusReqID
    | 650 ->
        let fld = ReadLegalConfirmIdx bs pos2 len
        fld |> FIXField.LegalConfirm
    | 651 ->
        let fld = ReadUnderlyingLastPxIdx bs pos2 len
        fld |> FIXField.UnderlyingLastPx
    | 652 ->
        let fld = ReadUnderlyingLastQtyIdx bs pos2 len
        fld |> FIXField.UnderlyingLastQty
    | 654 ->
        let fld = ReadLegRefIDIdx bs pos2 len
        fld |> FIXField.LegRefID
    | 655 ->
        let fld = ReadContraLegRefIDIdx bs pos2 len
        fld |> FIXField.ContraLegRefID
    | 656 ->
        let fld = ReadSettlCurrBidFxRateIdx bs pos2 len
        fld |> FIXField.SettlCurrBidFxRate
    | 657 ->
        let fld = ReadSettlCurrOfferFxRateIdx bs pos2 len
        fld |> FIXField.SettlCurrOfferFxRate
    | 658 ->
        let fld = ReadQuoteRequestRejectReasonIdx bs pos2 len
        fld |> FIXField.QuoteRequestRejectReason
    | 659 ->
        let fld = ReadSideComplianceIDIdx bs pos2 len
        fld |> FIXField.SideComplianceID
    | 660 ->
        let fld = ReadAcctIDSourceIdx bs pos2 len
        fld |> FIXField.AcctIDSource
    | 661 ->
        let fld = ReadAllocAcctIDSourceIdx bs pos2 len
        fld |> FIXField.AllocAcctIDSource
    | 662 ->
        let fld = ReadBenchmarkPriceIdx bs pos2 len
        fld |> FIXField.BenchmarkPrice
    | 663 ->
        let fld = ReadBenchmarkPriceTypeIdx bs pos2 len
        fld |> FIXField.BenchmarkPriceType
    | 664 ->
        let fld = ReadConfirmIDIdx bs pos2 len
        fld |> FIXField.ConfirmID
    | 665 ->
        let fld = ReadConfirmStatusIdx bs pos2 len
        fld |> FIXField.ConfirmStatus
    | 666 ->
        let fld = ReadConfirmTransTypeIdx bs pos2 len
        fld |> FIXField.ConfirmTransType
    | 667 ->
        let fld = ReadContractSettlMonthIdx bs pos2 len
        fld |> FIXField.ContractSettlMonth
    | 668 ->
        let fld = ReadDeliveryFormIdx bs pos2 len
        fld |> FIXField.DeliveryForm
    | 669 ->
        let fld = ReadLastParPxIdx bs pos2 len
        fld |> FIXField.LastParPx
    | 670 ->
        let fld = ReadNoLegAllocsIdx bs pos2 len
        fld |> FIXField.NoLegAllocs
    | 671 ->
        let fld = ReadLegAllocAccountIdx bs pos2 len
        fld |> FIXField.LegAllocAccount
    | 672 ->
        let fld = ReadLegIndividualAllocIDIdx bs pos2 len
        fld |> FIXField.LegIndividualAllocID
    | 673 ->
        let fld = ReadLegAllocQtyIdx bs pos2 len
        fld |> FIXField.LegAllocQty
    | 674 ->
        let fld = ReadLegAllocAcctIDSourceIdx bs pos2 len
        fld |> FIXField.LegAllocAcctIDSource
    | 675 ->
        let fld = ReadLegSettlCurrencyIdx bs pos2 len
        fld |> FIXField.LegSettlCurrency
    | 676 ->
        let fld = ReadLegBenchmarkCurveCurrencyIdx bs pos2 len
        fld |> FIXField.LegBenchmarkCurveCurrency
    | 677 ->
        let fld = ReadLegBenchmarkCurveNameIdx bs pos2 len
        fld |> FIXField.LegBenchmarkCurveName
    | 678 ->
        let fld = ReadLegBenchmarkCurvePointIdx bs pos2 len
        fld |> FIXField.LegBenchmarkCurvePoint
    | 679 ->
        let fld = ReadLegBenchmarkPriceIdx bs pos2 len
        fld |> FIXField.LegBenchmarkPrice
    | 680 ->
        let fld = ReadLegBenchmarkPriceTypeIdx bs pos2 len
        fld |> FIXField.LegBenchmarkPriceType
    | 681 ->
        let fld = ReadLegBidPxIdx bs pos2 len
        fld |> FIXField.LegBidPx
    | 682 ->
        let fld = ReadLegIOIQtyIdx bs pos2 len
        fld |> FIXField.LegIOIQty
    | 683 ->
        let fld = ReadNoLegStipulationsIdx bs pos2 len
        fld |> FIXField.NoLegStipulations
    | 684 ->
        let fld = ReadLegOfferPxIdx bs pos2 len
        fld |> FIXField.LegOfferPx
    | 685 ->
        let fld = ReadLegOrderQtyIdx bs pos2 len
        fld |> FIXField.LegOrderQty
    | 686 ->
        let fld = ReadLegPriceTypeIdx bs pos2 len
        fld |> FIXField.LegPriceType
    | 687 ->
        let fld = ReadLegQtyIdx bs pos2 len
        fld |> FIXField.LegQty
    | 688 ->
        let fld = ReadLegStipulationTypeIdx bs pos2 len
        fld |> FIXField.LegStipulationType
    | 689 ->
        let fld = ReadLegStipulationValueIdx bs pos2 len
        fld |> FIXField.LegStipulationValue
    | 690 ->
        let fld = ReadLegSwapTypeIdx bs pos2 len
        fld |> FIXField.LegSwapType
    | 691 ->
        let fld = ReadPoolIdx bs pos2 len
        fld |> FIXField.Pool
    | 692 ->
        let fld = ReadQuotePriceTypeIdx bs pos2 len
        fld |> FIXField.QuotePriceType
    | 693 ->
        let fld = ReadQuoteRespIDIdx bs pos2 len
        fld |> FIXField.QuoteRespID
    | 694 ->
        let fld = ReadQuoteRespTypeIdx bs pos2 len
        fld |> FIXField.QuoteRespType
    | 695 ->
        let fld = ReadQuoteQualifierIdx bs pos2 len
        fld |> FIXField.QuoteQualifier
    | 696 ->
        let fld = ReadYieldRedemptionDateIdx bs pos2 len
        fld |> FIXField.YieldRedemptionDate
    | 697 ->
        let fld = ReadYieldRedemptionPriceIdx bs pos2 len
        fld |> FIXField.YieldRedemptionPrice
    | 698 ->
        let fld = ReadYieldRedemptionPriceTypeIdx bs pos2 len
        fld |> FIXField.YieldRedemptionPriceType
    | 699 ->
        let fld = ReadBenchmarkSecurityIDIdx bs pos2 len
        fld |> FIXField.BenchmarkSecurityID
    | 700 ->
        let fld = ReadReversalIndicatorIdx bs pos2 len
        fld |> FIXField.ReversalIndicator
    | 701 ->
        let fld = ReadYieldCalcDateIdx bs pos2 len
        fld |> FIXField.YieldCalcDate
    | 702 ->
        let fld = ReadNoPositionsIdx bs pos2 len
        fld |> FIXField.NoPositions
    | 703 ->
        let fld = ReadPosTypeIdx bs pos2 len
        fld |> FIXField.PosType
    | 704 ->
        let fld = ReadLongQtyIdx bs pos2 len
        fld |> FIXField.LongQty
    | 705 ->
        let fld = ReadShortQtyIdx bs pos2 len
        fld |> FIXField.ShortQty
    | 706 ->
        let fld = ReadPosQtyStatusIdx bs pos2 len
        fld |> FIXField.PosQtyStatus
    | 707 ->
        let fld = ReadPosAmtTypeIdx bs pos2 len
        fld |> FIXField.PosAmtType
    | 708 ->
        let fld = ReadPosAmtIdx bs pos2 len
        fld |> FIXField.PosAmt
    | 709 ->
        let fld = ReadPosTransTypeIdx bs pos2 len
        fld |> FIXField.PosTransType
    | 710 ->
        let fld = ReadPosReqIDIdx bs pos2 len
        fld |> FIXField.PosReqID
    | 711 ->
        let fld = ReadNoUnderlyingsIdx bs pos2 len
        fld |> FIXField.NoUnderlyings
    | 712 ->
        let fld = ReadPosMaintActionIdx bs pos2 len
        fld |> FIXField.PosMaintAction
    | 713 ->
        let fld = ReadOrigPosReqRefIDIdx bs pos2 len
        fld |> FIXField.OrigPosReqRefID
    | 714 ->
        let fld = ReadPosMaintRptRefIDIdx bs pos2 len
        fld |> FIXField.PosMaintRptRefID
    | 715 ->
        let fld = ReadClearingBusinessDateIdx bs pos2 len
        fld |> FIXField.ClearingBusinessDate
    | 716 ->
        let fld = ReadSettlSessIDIdx bs pos2 len
        fld |> FIXField.SettlSessID
    | 717 ->
        let fld = ReadSettlSessSubIDIdx bs pos2 len
        fld |> FIXField.SettlSessSubID
    | 718 ->
        let fld = ReadAdjustmentTypeIdx bs pos2 len
        fld |> FIXField.AdjustmentType
    | 719 ->
        let fld = ReadContraryInstructionIndicatorIdx bs pos2 len
        fld |> FIXField.ContraryInstructionIndicator
    | 720 ->
        let fld = ReadPriorSpreadIndicatorIdx bs pos2 len
        fld |> FIXField.PriorSpreadIndicator
    | 721 ->
        let fld = ReadPosMaintRptIDIdx bs pos2 len
        fld |> FIXField.PosMaintRptID
    | 722 ->
        let fld = ReadPosMaintStatusIdx bs pos2 len
        fld |> FIXField.PosMaintStatus
    | 723 ->
        let fld = ReadPosMaintResultIdx bs pos2 len
        fld |> FIXField.PosMaintResult
    | 724 ->
        let fld = ReadPosReqTypeIdx bs pos2 len
        fld |> FIXField.PosReqType
    | 725 ->
        let fld = ReadResponseTransportTypeIdx bs pos2 len
        fld |> FIXField.ResponseTransportType
    | 726 ->
        let fld = ReadResponseDestinationIdx bs pos2 len
        fld |> FIXField.ResponseDestination
    | 727 ->
        let fld = ReadTotalNumPosReportsIdx bs pos2 len
        fld |> FIXField.TotalNumPosReports
    | 728 ->
        let fld = ReadPosReqResultIdx bs pos2 len
        fld |> FIXField.PosReqResult
    | 729 ->
        let fld = ReadPosReqStatusIdx bs pos2 len
        fld |> FIXField.PosReqStatus
    | 730 ->
        let fld = ReadSettlPriceIdx bs pos2 len
        fld |> FIXField.SettlPrice
    | 731 ->
        let fld = ReadSettlPriceTypeIdx bs pos2 len
        fld |> FIXField.SettlPriceType
    | 732 ->
        let fld = ReadUnderlyingSettlPriceIdx bs pos2 len
        fld |> FIXField.UnderlyingSettlPrice
    | 733 ->
        let fld = ReadUnderlyingSettlPriceTypeIdx bs pos2 len
        fld |> FIXField.UnderlyingSettlPriceType
    | 734 ->
        let fld = ReadPriorSettlPriceIdx bs pos2 len
        fld |> FIXField.PriorSettlPrice
    | 735 ->
        let fld = ReadNoQuoteQualifiersIdx bs pos2 len
        fld |> FIXField.NoQuoteQualifiers
    | 736 ->
        let fld = ReadAllocSettlCurrencyIdx bs pos2 len
        fld |> FIXField.AllocSettlCurrency
    | 737 ->
        let fld = ReadAllocSettlCurrAmtIdx bs pos2 len
        fld |> FIXField.AllocSettlCurrAmt
    | 738 ->
        let fld = ReadInterestAtMaturityIdx bs pos2 len
        fld |> FIXField.InterestAtMaturity
    | 739 ->
        let fld = ReadLegDatedDateIdx bs pos2 len
        fld |> FIXField.LegDatedDate
    | 740 ->
        let fld = ReadLegPoolIdx bs pos2 len
        fld |> FIXField.LegPool
    | 741 ->
        let fld = ReadAllocInterestAtMaturityIdx bs pos2 len
        fld |> FIXField.AllocInterestAtMaturity
    | 742 ->
        let fld = ReadAllocAccruedInterestAmtIdx bs pos2 len
        fld |> FIXField.AllocAccruedInterestAmt
    | 743 ->
        let fld = ReadDeliveryDateIdx bs pos2 len
        fld |> FIXField.DeliveryDate
    | 744 ->
        let fld = ReadAssignmentMethodIdx bs pos2 len
        fld |> FIXField.AssignmentMethod
    | 745 ->
        let fld = ReadAssignmentUnitIdx bs pos2 len
        fld |> FIXField.AssignmentUnit
    | 746 ->
        let fld = ReadOpenInterestIdx bs pos2 len
        fld |> FIXField.OpenInterest
    | 747 ->
        let fld = ReadExerciseMethodIdx bs pos2 len
        fld |> FIXField.ExerciseMethod
    | 748 ->
        let fld = ReadTotNumTradeReportsIdx bs pos2 len
        fld |> FIXField.TotNumTradeReports
    | 749 ->
        let fld = ReadTradeRequestResultIdx bs pos2 len
        fld |> FIXField.TradeRequestResult
    | 750 ->
        let fld = ReadTradeRequestStatusIdx bs pos2 len
        fld |> FIXField.TradeRequestStatus
    | 751 ->
        let fld = ReadTradeReportRejectReasonIdx bs pos2 len
        fld |> FIXField.TradeReportRejectReason
    | 752 ->
        let fld = ReadSideMultiLegReportingTypeIdx bs pos2 len
        fld |> FIXField.SideMultiLegReportingType
    | 753 ->
        let fld = ReadNoPosAmtIdx bs pos2 len
        fld |> FIXField.NoPosAmt
    | 754 ->
        let fld = ReadAutoAcceptIndicatorIdx bs pos2 len
        fld |> FIXField.AutoAcceptIndicator
    | 755 ->
        let fld = ReadAllocReportIDIdx bs pos2 len
        fld |> FIXField.AllocReportID
    | 756 ->
        let fld = ReadNoNested2PartyIDsIdx bs pos2 len
        fld |> FIXField.NoNested2PartyIDs
    | 757 ->
        let fld = ReadNested2PartyIDIdx bs pos2 len
        fld |> FIXField.Nested2PartyID
    | 758 ->
        let fld = ReadNested2PartyIDSourceIdx bs pos2 len
        fld |> FIXField.Nested2PartyIDSource
    | 759 ->
        let fld = ReadNested2PartyRoleIdx bs pos2 len
        fld |> FIXField.Nested2PartyRole
    | 760 ->
        let fld = ReadNested2PartySubIDIdx bs pos2 len
        fld |> FIXField.Nested2PartySubID
    | 761 ->
        let fld = ReadBenchmarkSecurityIDSourceIdx bs pos2 len
        fld |> FIXField.BenchmarkSecurityIDSource
    | 762 ->
        let fld = ReadSecuritySubTypeIdx bs pos2 len
        fld |> FIXField.SecuritySubType
    | 763 ->
        let fld = ReadUnderlyingSecuritySubTypeIdx bs pos2 len
        fld |> FIXField.UnderlyingSecuritySubType
    | 764 ->
        let fld = ReadLegSecuritySubTypeIdx bs pos2 len
        fld |> FIXField.LegSecuritySubType
    | 765 ->
        let fld = ReadAllowableOneSidednessPctIdx bs pos2 len
        fld |> FIXField.AllowableOneSidednessPct
    | 766 ->
        let fld = ReadAllowableOneSidednessValueIdx bs pos2 len
        fld |> FIXField.AllowableOneSidednessValue
    | 767 ->
        let fld = ReadAllowableOneSidednessCurrIdx bs pos2 len
        fld |> FIXField.AllowableOneSidednessCurr
    | 768 ->
        let fld = ReadNoTrdRegTimestampsIdx bs pos2 len
        fld |> FIXField.NoTrdRegTimestamps
    | 769 ->
        let fld = ReadTrdRegTimestampIdx bs pos2 len
        fld |> FIXField.TrdRegTimestamp
    | 770 ->
        let fld = ReadTrdRegTimestampTypeIdx bs pos2 len
        fld |> FIXField.TrdRegTimestampType
    | 771 ->
        let fld = ReadTrdRegTimestampOriginIdx bs pos2 len
        fld |> FIXField.TrdRegTimestampOrigin
    | 772 ->
        let fld = ReadConfirmRefIDIdx bs pos2 len
        fld |> FIXField.ConfirmRefID
    | 773 ->
        let fld = ReadConfirmTypeIdx bs pos2 len
        fld |> FIXField.ConfirmType
    | 774 ->
        let fld = ReadConfirmRejReasonIdx bs pos2 len
        fld |> FIXField.ConfirmRejReason
    | 775 ->
        let fld = ReadBookingTypeIdx bs pos2 len
        fld |> FIXField.BookingType
    | 776 ->
        let fld = ReadIndividualAllocRejCodeIdx bs pos2 len
        fld |> FIXField.IndividualAllocRejCode
    | 777 ->
        let fld = ReadSettlInstMsgIDIdx bs pos2 len
        fld |> FIXField.SettlInstMsgID
    | 778 ->
        let fld = ReadNoSettlInstIdx bs pos2 len
        fld |> FIXField.NoSettlInst
    | 779 ->
        let fld = ReadLastUpdateTimeIdx bs pos2 len
        fld |> FIXField.LastUpdateTime
    | 780 ->
        let fld = ReadAllocSettlInstTypeIdx bs pos2 len
        fld |> FIXField.AllocSettlInstType
    | 781 ->
        let fld = ReadNoSettlPartyIDsIdx bs pos2 len
        fld |> FIXField.NoSettlPartyIDs
    | 782 ->
        let fld = ReadSettlPartyIDIdx bs pos2 len
        fld |> FIXField.SettlPartyID
    | 783 ->
        let fld = ReadSettlPartyIDSourceIdx bs pos2 len
        fld |> FIXField.SettlPartyIDSource
    | 784 ->
        let fld = ReadSettlPartyRoleIdx bs pos2 len
        fld |> FIXField.SettlPartyRole
    | 785 ->
        let fld = ReadSettlPartySubIDIdx bs pos2 len
        fld |> FIXField.SettlPartySubID
    | 786 ->
        let fld = ReadSettlPartySubIDTypeIdx bs pos2 len
        fld |> FIXField.SettlPartySubIDType
    | 787 ->
        let fld = ReadDlvyInstTypeIdx bs pos2 len
        fld |> FIXField.DlvyInstType
    | 788 ->
        let fld = ReadTerminationTypeIdx bs pos2 len
        fld |> FIXField.TerminationType
    | 789 ->
        let fld = ReadNextExpectedMsgSeqNumIdx bs pos2 len
        fld |> FIXField.NextExpectedMsgSeqNum
    | 790 ->
        let fld = ReadOrdStatusReqIDIdx bs pos2 len
        fld |> FIXField.OrdStatusReqID
    | 791 ->
        let fld = ReadSettlInstReqIDIdx bs pos2 len
        fld |> FIXField.SettlInstReqID
    | 792 ->
        let fld = ReadSettlInstReqRejCodeIdx bs pos2 len
        fld |> FIXField.SettlInstReqRejCode
    | 793 ->
        let fld = ReadSecondaryAllocIDIdx bs pos2 len
        fld |> FIXField.SecondaryAllocID
    | 794 ->
        let fld = ReadAllocReportTypeIdx bs pos2 len
        fld |> FIXField.AllocReportType
    | 795 ->
        let fld = ReadAllocReportRefIDIdx bs pos2 len
        fld |> FIXField.AllocReportRefID
    | 796 ->
        let fld = ReadAllocCancReplaceReasonIdx bs pos2 len
        fld |> FIXField.AllocCancReplaceReason
    | 797 ->
        let fld = ReadCopyMsgIndicatorIdx bs pos2 len
        fld |> FIXField.CopyMsgIndicator
    | 798 ->
        let fld = ReadAllocAccountTypeIdx bs pos2 len
        fld |> FIXField.AllocAccountType
    | 799 ->
        let fld = ReadOrderAvgPxIdx bs pos2 len
        fld |> FIXField.OrderAvgPx
    | 800 ->
        let fld = ReadOrderBookingQtyIdx bs pos2 len
        fld |> FIXField.OrderBookingQty
    | 801 ->
        let fld = ReadNoSettlPartySubIDsIdx bs pos2 len
        fld |> FIXField.NoSettlPartySubIDs
    | 802 ->
        let fld = ReadNoPartySubIDsIdx bs pos2 len
        fld |> FIXField.NoPartySubIDs
    | 803 ->
        let fld = ReadPartySubIDTypeIdx bs pos2 len
        fld |> FIXField.PartySubIDType
    | 804 ->
        let fld = ReadNoNestedPartySubIDsIdx bs pos2 len
        fld |> FIXField.NoNestedPartySubIDs
    | 805 ->
        let fld = ReadNestedPartySubIDTypeIdx bs pos2 len
        fld |> FIXField.NestedPartySubIDType
    | 806 ->
        let fld = ReadNoNested2PartySubIDsIdx bs pos2 len
        fld |> FIXField.NoNested2PartySubIDs
    | 807 ->
        let fld = ReadNested2PartySubIDTypeIdx bs pos2 len
        fld |> FIXField.Nested2PartySubIDType
    | 808 ->
        let fld = ReadAllocIntermedReqTypeIdx bs pos2 len
        fld |> FIXField.AllocIntermedReqType
    | 810 ->
        let fld = ReadUnderlyingPxIdx bs pos2 len
        fld |> FIXField.UnderlyingPx
    | 811 ->
        let fld = ReadPriceDeltaIdx bs pos2 len
        fld |> FIXField.PriceDelta
    | 812 ->
        let fld = ReadApplQueueMaxIdx bs pos2 len
        fld |> FIXField.ApplQueueMax
    | 813 ->
        let fld = ReadApplQueueDepthIdx bs pos2 len
        fld |> FIXField.ApplQueueDepth
    | 814 ->
        let fld = ReadApplQueueResolutionIdx bs pos2 len
        fld |> FIXField.ApplQueueResolution
    | 815 ->
        let fld = ReadApplQueueActionIdx bs pos2 len
        fld |> FIXField.ApplQueueAction
    | 816 ->
        let fld = ReadNoAltMDSourceIdx bs pos2 len
        fld |> FIXField.NoAltMDSource
    | 817 ->
        let fld = ReadAltMDSourceIDIdx bs pos2 len
        fld |> FIXField.AltMDSourceID
    | 818 ->
        let fld = ReadSecondaryTradeReportIDIdx bs pos2 len
        fld |> FIXField.SecondaryTradeReportID
    | 819 ->
        let fld = ReadAvgPxIndicatorIdx bs pos2 len
        fld |> FIXField.AvgPxIndicator
    | 820 ->
        let fld = ReadTradeLinkIDIdx bs pos2 len
        fld |> FIXField.TradeLinkID
    | 821 ->
        let fld = ReadOrderInputDeviceIdx bs pos2 len
        fld |> FIXField.OrderInputDevice
    | 822 ->
        let fld = ReadUnderlyingTradingSessionIDIdx bs pos2 len
        fld |> FIXField.UnderlyingTradingSessionID
    | 823 ->
        let fld = ReadUnderlyingTradingSessionSubIDIdx bs pos2 len
        fld |> FIXField.UnderlyingTradingSessionSubID
    | 824 ->
        let fld = ReadTradeLegRefIDIdx bs pos2 len
        fld |> FIXField.TradeLegRefID
    | 825 ->
        let fld = ReadExchangeRuleIdx bs pos2 len
        fld |> FIXField.ExchangeRule
    | 826 ->
        let fld = ReadTradeAllocIndicatorIdx bs pos2 len
        fld |> FIXField.TradeAllocIndicator
    | 827 ->
        let fld = ReadExpirationCycleIdx bs pos2 len
        fld |> FIXField.ExpirationCycle
    | 828 ->
        let fld = ReadTrdTypeIdx bs pos2 len
        fld |> FIXField.TrdType
    | 829 ->
        let fld = ReadTrdSubTypeIdx bs pos2 len
        fld |> FIXField.TrdSubType
    | 830 ->
        let fld = ReadTransferReasonIdx bs pos2 len
        fld |> FIXField.TransferReason
    | 831 ->
        let fld = ReadAsgnReqIDIdx bs pos2 len
        fld |> FIXField.AsgnReqID
    | 832 ->
        let fld = ReadTotNumAssignmentReportsIdx bs pos2 len
        fld |> FIXField.TotNumAssignmentReports
    | 833 ->
        let fld = ReadAsgnRptIDIdx bs pos2 len
        fld |> FIXField.AsgnRptID
    | 834 ->
        let fld = ReadThresholdAmountIdx bs pos2 len
        fld |> FIXField.ThresholdAmount
    | 835 ->
        let fld = ReadPegMoveTypeIdx bs pos2 len
        fld |> FIXField.PegMoveType
    | 836 ->
        let fld = ReadPegOffsetTypeIdx bs pos2 len
        fld |> FIXField.PegOffsetType
    | 837 ->
        let fld = ReadPegLimitTypeIdx bs pos2 len
        fld |> FIXField.PegLimitType
    | 838 ->
        let fld = ReadPegRoundDirectionIdx bs pos2 len
        fld |> FIXField.PegRoundDirection
    | 839 ->
        let fld = ReadPeggedPriceIdx bs pos2 len
        fld |> FIXField.PeggedPrice
    | 840 ->
        let fld = ReadPegScopeIdx bs pos2 len
        fld |> FIXField.PegScope
    | 841 ->
        let fld = ReadDiscretionMoveTypeIdx bs pos2 len
        fld |> FIXField.DiscretionMoveType
    | 842 ->
        let fld = ReadDiscretionOffsetTypeIdx bs pos2 len
        fld |> FIXField.DiscretionOffsetType
    | 843 ->
        let fld = ReadDiscretionLimitTypeIdx bs pos2 len
        fld |> FIXField.DiscretionLimitType
    | 844 ->
        let fld = ReadDiscretionRoundDirectionIdx bs pos2 len
        fld |> FIXField.DiscretionRoundDirection
    | 845 ->
        let fld = ReadDiscretionPriceIdx bs pos2 len
        fld |> FIXField.DiscretionPrice
    | 846 ->
        let fld = ReadDiscretionScopeIdx bs pos2 len
        fld |> FIXField.DiscretionScope
    | 847 ->
        let fld = ReadTargetStrategyIdx bs pos2 len
        fld |> FIXField.TargetStrategy
    | 848 ->
        let fld = ReadTargetStrategyParametersIdx bs pos2 len
        fld |> FIXField.TargetStrategyParameters
    | 849 ->
        let fld = ReadParticipationRateIdx bs pos2 len
        fld |> FIXField.ParticipationRate
    | 850 ->
        let fld = ReadTargetStrategyPerformanceIdx bs pos2 len
        fld |> FIXField.TargetStrategyPerformance
    | 851 ->
        let fld = ReadLastLiquidityIndIdx bs pos2 len
        fld |> FIXField.LastLiquidityInd
    | 852 ->
        let fld = ReadPublishTrdIndicatorIdx bs pos2 len
        fld |> FIXField.PublishTrdIndicator
    | 853 ->
        let fld = ReadShortSaleReasonIdx bs pos2 len
        fld |> FIXField.ShortSaleReason
    | 854 ->
        let fld = ReadQtyTypeIdx bs pos2 len
        fld |> FIXField.QtyType
    | 855 ->
        let fld = ReadSecondaryTrdTypeIdx bs pos2 len
        fld |> FIXField.SecondaryTrdType
    | 856 ->
        let fld = ReadTradeReportTypeIdx bs pos2 len
        fld |> FIXField.TradeReportType
    | 857 ->
        let fld = ReadAllocNoOrdersTypeIdx bs pos2 len
        fld |> FIXField.AllocNoOrdersType
    | 858 ->
        let fld = ReadSharedCommissionIdx bs pos2 len
        fld |> FIXField.SharedCommission
    | 859 ->
        let fld = ReadConfirmReqIDIdx bs pos2 len
        fld |> FIXField.ConfirmReqID
    | 860 ->
        let fld = ReadAvgParPxIdx bs pos2 len
        fld |> FIXField.AvgParPx
    | 861 ->
        let fld = ReadReportedPxIdx bs pos2 len
        fld |> FIXField.ReportedPx
    | 862 ->
        let fld = ReadNoCapacitiesIdx bs pos2 len
        fld |> FIXField.NoCapacities
    | 863 ->
        let fld = ReadOrderCapacityQtyIdx bs pos2 len
        fld |> FIXField.OrderCapacityQty
    | 864 ->
        let fld = ReadNoEventsIdx bs pos2 len
        fld |> FIXField.NoEvents
    | 865 ->
        let fld = ReadEventTypeIdx bs pos2 len
        fld |> FIXField.EventType
    | 866 ->
        let fld = ReadEventDateIdx bs pos2 len
        fld |> FIXField.EventDate
    | 867 ->
        let fld = ReadEventPxIdx bs pos2 len
        fld |> FIXField.EventPx
    | 868 ->
        let fld = ReadEventTextIdx bs pos2 len
        fld |> FIXField.EventText
    | 869 ->
        let fld = ReadPctAtRiskIdx bs pos2 len
        fld |> FIXField.PctAtRisk
    | 870 ->
        let fld = ReadNoInstrAttribIdx bs pos2 len
        fld |> FIXField.NoInstrAttrib
    | 871 ->
        let fld = ReadInstrAttribTypeIdx bs pos2 len
        fld |> FIXField.InstrAttribType
    | 872 ->
        let fld = ReadInstrAttribValueIdx bs pos2 len
        fld |> FIXField.InstrAttribValue
    | 873 ->
        let fld = ReadDatedDateIdx bs pos2 len
        fld |> FIXField.DatedDate
    | 874 ->
        let fld = ReadInterestAccrualDateIdx bs pos2 len
        fld |> FIXField.InterestAccrualDate
    | 875 ->
        let fld = ReadCPProgramIdx bs pos2 len
        fld |> FIXField.CPProgram
    | 876 ->
        let fld = ReadCPRegTypeIdx bs pos2 len
        fld |> FIXField.CPRegType
    | 877 ->
        let fld = ReadUnderlyingCPProgramIdx bs pos2 len
        fld |> FIXField.UnderlyingCPProgram
    | 878 ->
        let fld = ReadUnderlyingCPRegTypeIdx bs pos2 len
        fld |> FIXField.UnderlyingCPRegType
    | 879 ->
        let fld = ReadUnderlyingQtyIdx bs pos2 len
        fld |> FIXField.UnderlyingQty
    | 880 ->
        let fld = ReadTrdMatchIDIdx bs pos2 len
        fld |> FIXField.TrdMatchID
    | 881 ->
        let fld = ReadSecondaryTradeReportRefIDIdx bs pos2 len
        fld |> FIXField.SecondaryTradeReportRefID
    | 882 ->
        let fld = ReadUnderlyingDirtyPriceIdx bs pos2 len
        fld |> FIXField.UnderlyingDirtyPrice
    | 883 ->
        let fld = ReadUnderlyingEndPriceIdx bs pos2 len
        fld |> FIXField.UnderlyingEndPrice
    | 884 ->
        let fld = ReadUnderlyingStartValueIdx bs pos2 len
        fld |> FIXField.UnderlyingStartValue
    | 885 ->
        let fld = ReadUnderlyingCurrentValueIdx bs pos2 len
        fld |> FIXField.UnderlyingCurrentValue
    | 886 ->
        let fld = ReadUnderlyingEndValueIdx bs pos2 len
        fld |> FIXField.UnderlyingEndValue
    | 887 ->
        let fld = ReadNoUnderlyingStipsIdx bs pos2 len
        fld |> FIXField.NoUnderlyingStips
    | 888 ->
        let fld = ReadUnderlyingStipTypeIdx bs pos2 len
        fld |> FIXField.UnderlyingStipType
    | 889 ->
        let fld = ReadUnderlyingStipValueIdx bs pos2 len
        fld |> FIXField.UnderlyingStipValue
    | 890 ->
        let fld = ReadMaturityNetMoneyIdx bs pos2 len
        fld |> FIXField.MaturityNetMoney
    | 891 ->
        let fld = ReadMiscFeeBasisIdx bs pos2 len
        fld |> FIXField.MiscFeeBasis
    | 892 ->
        let fld = ReadTotNoAllocsIdx bs pos2 len
        fld |> FIXField.TotNoAllocs
    | 893 ->
        let fld = ReadLastFragmentIdx bs pos2 len
        fld |> FIXField.LastFragment
    | 894 ->
        let fld = ReadCollReqIDIdx bs pos2 len
        fld |> FIXField.CollReqID
    | 895 ->
        let fld = ReadCollAsgnReasonIdx bs pos2 len
        fld |> FIXField.CollAsgnReason
    | 896 ->
        let fld = ReadCollInquiryQualifierIdx bs pos2 len
        fld |> FIXField.CollInquiryQualifier
    | 897 ->
        let fld = ReadNoTradesIdx bs pos2 len
        fld |> FIXField.NoTrades
    | 898 ->
        let fld = ReadMarginRatioIdx bs pos2 len
        fld |> FIXField.MarginRatio
    | 899 ->
        let fld = ReadMarginExcessIdx bs pos2 len
        fld |> FIXField.MarginExcess
    | 900 ->
        let fld = ReadTotalNetValueIdx bs pos2 len
        fld |> FIXField.TotalNetValue
    | 901 ->
        let fld = ReadCashOutstandingIdx bs pos2 len
        fld |> FIXField.CashOutstanding
    | 902 ->
        let fld = ReadCollAsgnIDIdx bs pos2 len
        fld |> FIXField.CollAsgnID
    | 903 ->
        let fld = ReadCollAsgnTransTypeIdx bs pos2 len
        fld |> FIXField.CollAsgnTransType
    | 904 ->
        let fld = ReadCollRespIDIdx bs pos2 len
        fld |> FIXField.CollRespID
    | 905 ->
        let fld = ReadCollAsgnRespTypeIdx bs pos2 len
        fld |> FIXField.CollAsgnRespType
    | 906 ->
        let fld = ReadCollAsgnRejectReasonIdx bs pos2 len
        fld |> FIXField.CollAsgnRejectReason
    | 907 ->
        let fld = ReadCollAsgnRefIDIdx bs pos2 len
        fld |> FIXField.CollAsgnRefID
    | 908 ->
        let fld = ReadCollRptIDIdx bs pos2 len
        fld |> FIXField.CollRptID
    | 909 ->
        let fld = ReadCollInquiryIDIdx bs pos2 len
        fld |> FIXField.CollInquiryID
    | 910 ->
        let fld = ReadCollStatusIdx bs pos2 len
        fld |> FIXField.CollStatus
    | 911 ->
        let fld = ReadTotNumReportsIdx bs pos2 len
        fld |> FIXField.TotNumReports
    | 912 ->
        let fld = ReadLastRptRequestedIdx bs pos2 len
        fld |> FIXField.LastRptRequested
    | 913 ->
        let fld = ReadAgreementDescIdx bs pos2 len
        fld |> FIXField.AgreementDesc
    | 914 ->
        let fld = ReadAgreementIDIdx bs pos2 len
        fld |> FIXField.AgreementID
    | 915 ->
        let fld = ReadAgreementDateIdx bs pos2 len
        fld |> FIXField.AgreementDate
    | 916 ->
        let fld = ReadStartDateIdx bs pos2 len
        fld |> FIXField.StartDate
    | 917 ->
        let fld = ReadEndDateIdx bs pos2 len
        fld |> FIXField.EndDate
    | 918 ->
        let fld = ReadAgreementCurrencyIdx bs pos2 len
        fld |> FIXField.AgreementCurrency
    | 919 ->
        let fld = ReadDeliveryTypeIdx bs pos2 len
        fld |> FIXField.DeliveryType
    | 920 ->
        let fld = ReadEndAccruedInterestAmtIdx bs pos2 len
        fld |> FIXField.EndAccruedInterestAmt
    | 921 ->
        let fld = ReadStartCashIdx bs pos2 len
        fld |> FIXField.StartCash
    | 922 ->
        let fld = ReadEndCashIdx bs pos2 len
        fld |> FIXField.EndCash
    | 923 ->
        let fld = ReadUserRequestIDIdx bs pos2 len
        fld |> FIXField.UserRequestID
    | 924 ->
        let fld = ReadUserRequestTypeIdx bs pos2 len
        fld |> FIXField.UserRequestType
    | 925 ->
        let fld = ReadNewPasswordIdx bs pos2 len
        fld |> FIXField.NewPassword
    | 926 ->
        let fld = ReadUserStatusIdx bs pos2 len
        fld |> FIXField.UserStatus
    | 927 ->
        let fld = ReadUserStatusTextIdx bs pos2 len
        fld |> FIXField.UserStatusText
    | 928 ->
        let fld = ReadStatusValueIdx bs pos2 len
        fld |> FIXField.StatusValue
    | 929 ->
        let fld = ReadStatusTextIdx bs pos2 len
        fld |> FIXField.StatusText
    | 930 ->
        let fld = ReadRefCompIDIdx bs pos2 len
        fld |> FIXField.RefCompID
    | 931 ->
        let fld = ReadRefSubIDIdx bs pos2 len
        fld |> FIXField.RefSubID
    | 932 ->
        let fld = ReadNetworkResponseIDIdx bs pos2 len
        fld |> FIXField.NetworkResponseID
    | 933 ->
        let fld = ReadNetworkRequestIDIdx bs pos2 len
        fld |> FIXField.NetworkRequestID
    | 934 ->
        let fld = ReadLastNetworkResponseIDIdx bs pos2 len
        fld |> FIXField.LastNetworkResponseID
    | 935 ->
        let fld = ReadNetworkRequestTypeIdx bs pos2 len
        fld |> FIXField.NetworkRequestType
    | 936 ->
        let fld = ReadNoCompIDsIdx bs pos2 len
        fld |> FIXField.NoCompIDs
    | 937 ->
        let fld = ReadNetworkStatusResponseTypeIdx bs pos2 len
        fld |> FIXField.NetworkStatusResponseType
    | 938 ->
        let fld = ReadNoCollInquiryQualifierIdx bs pos2 len
        fld |> FIXField.NoCollInquiryQualifier
    | 939 ->
        let fld = ReadTrdRptStatusIdx bs pos2 len
        fld |> FIXField.TrdRptStatus
    | 940 ->
        let fld = ReadAffirmStatusIdx bs pos2 len
        fld |> FIXField.AffirmStatus
    | 941 ->
        let fld = ReadUnderlyingStrikeCurrencyIdx bs pos2 len
        fld |> FIXField.UnderlyingStrikeCurrency
    | 942 ->
        let fld = ReadLegStrikeCurrencyIdx bs pos2 len
        fld |> FIXField.LegStrikeCurrency
    | 943 ->
        let fld = ReadTimeBracketIdx bs pos2 len
        fld |> FIXField.TimeBracket
    | 944 ->
        let fld = ReadCollActionIdx bs pos2 len
        fld |> FIXField.CollAction
    | 945 ->
        let fld = ReadCollInquiryStatusIdx bs pos2 len
        fld |> FIXField.CollInquiryStatus
    | 946 ->
        let fld = ReadCollInquiryResultIdx bs pos2 len
        fld |> FIXField.CollInquiryResult
    | 947 ->
        let fld = ReadStrikeCurrencyIdx bs pos2 len
        fld |> FIXField.StrikeCurrency
    | 948 ->
        let fld = ReadNoNested3PartyIDsIdx bs pos2 len
        fld |> FIXField.NoNested3PartyIDs
    | 949 ->
        let fld = ReadNested3PartyIDIdx bs pos2 len
        fld |> FIXField.Nested3PartyID
    | 950 ->
        let fld = ReadNested3PartyIDSourceIdx bs pos2 len
        fld |> FIXField.Nested3PartyIDSource
    | 951 ->
        let fld = ReadNested3PartyRoleIdx bs pos2 len
        fld |> FIXField.Nested3PartyRole
    | 952 ->
        let fld = ReadNoNested3PartySubIDsIdx bs pos2 len
        fld |> FIXField.NoNested3PartySubIDs
    | 953 ->
        let fld = ReadNested3PartySubIDIdx bs pos2 len
        fld |> FIXField.Nested3PartySubID
    | 954 ->
        let fld = ReadNested3PartySubIDTypeIdx bs pos2 len
        fld |> FIXField.Nested3PartySubIDType
    | 955 ->
        let fld = ReadLegContractSettlMonthIdx bs pos2 len
        fld |> FIXField.LegContractSettlMonth
    | 956 ->
        let fld = ReadLegInterestAccrualDateIdx bs pos2 len
        fld |> FIXField.LegInterestAccrualDate
    |  _  -> failwith "FIXField invalid tag" 
