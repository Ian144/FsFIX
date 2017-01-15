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
