module Fix44.CompoundItemReaders

open ReaderUtils
open Fix44.Fields
open Fix44.FieldReaders
open Fix44.CompoundItems


// group
let ReadNoUnderlyingSecurityAltIDGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoUnderlyingSecurityAltIDGrp =
    let underlyingSecurityAltID = ReadFieldIdxOrdered true bs index 458 ReadUnderlyingSecurityAltIDIdx
    let underlyingSecurityAltIDSource = ReadOptionalFieldIdxOrdered true bs index 459 ReadUnderlyingSecurityAltIDSourceIdx
    let ci:NoUnderlyingSecurityAltIDGrp = {
        UnderlyingSecurityAltID = underlyingSecurityAltID
        UnderlyingSecurityAltIDSource = underlyingSecurityAltIDSource
    }
    ci


// group
let ReadNoUnderlyingStipsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoUnderlyingStipsGrp =
    let underlyingStipType = ReadFieldIdxOrdered true bs index 888 ReadUnderlyingStipTypeIdx
    let underlyingStipValue = ReadOptionalFieldIdxOrdered true bs index 889 ReadUnderlyingStipValueIdx
    let ci:NoUnderlyingStipsGrp = {
        UnderlyingStipType = underlyingStipType
        UnderlyingStipValue = underlyingStipValue
    }
    ci


// component
let ReadUnderlyingInstrumentIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : UnderlyingInstrument =
    let underlyingSymbol = ReadFieldIdxOrdered true bs index 311 ReadUnderlyingSymbolIdx
    let underlyingSymbolSfx = ReadOptionalFieldIdxOrdered true bs index 312 ReadUnderlyingSymbolSfxIdx
    let underlyingSecurityID = ReadOptionalFieldIdxOrdered true bs index 309 ReadUnderlyingSecurityIDIdx
    let underlyingSecurityIDSource = ReadOptionalFieldIdxOrdered true bs index 305 ReadUnderlyingSecurityIDSourceIdx
    let noUnderlyingSecurityAltIDGrpIdx = ReadOptionalGroupIdx bs index 457 ReadNoUnderlyingSecurityAltIDGrpIdx
    let underlyingProduct = ReadOptionalFieldIdxOrdered true bs index 462 ReadUnderlyingProductIdx
    let underlyingCFICode = ReadOptionalFieldIdxOrdered true bs index 463 ReadUnderlyingCFICodeIdx
    let underlyingSecurityType = ReadOptionalFieldIdxOrdered true bs index 310 ReadUnderlyingSecurityTypeIdx
    let underlyingSecuritySubType = ReadOptionalFieldIdxOrdered true bs index 763 ReadUnderlyingSecuritySubTypeIdx
    let underlyingMaturityMonthYear = ReadOptionalFieldIdxOrdered true bs index 313 ReadUnderlyingMaturityMonthYearIdx
    let underlyingMaturityDate = ReadOptionalFieldIdxOrdered true bs index 542 ReadUnderlyingMaturityDateIdx
    let underlyingPutOrCall = ReadOptionalFieldIdxOrdered true bs index 315 ReadUnderlyingPutOrCallIdx
    let underlyingCouponPaymentDate = ReadOptionalFieldIdxOrdered true bs index 241 ReadUnderlyingCouponPaymentDateIdx
    let underlyingIssueDate = ReadOptionalFieldIdxOrdered true bs index 242 ReadUnderlyingIssueDateIdx
    let underlyingRepoCollateralSecurityType = ReadOptionalFieldIdxOrdered true bs index 243 ReadUnderlyingRepoCollateralSecurityTypeIdx
    let underlyingRepurchaseTerm = ReadOptionalFieldIdxOrdered true bs index 244 ReadUnderlyingRepurchaseTermIdx
    let underlyingRepurchaseRate = ReadOptionalFieldIdxOrdered true bs index 245 ReadUnderlyingRepurchaseRateIdx
    let underlyingFactor = ReadOptionalFieldIdxOrdered true bs index 246 ReadUnderlyingFactorIdx
    let underlyingCreditRating = ReadOptionalFieldIdxOrdered true bs index 256 ReadUnderlyingCreditRatingIdx
    let underlyingInstrRegistry = ReadOptionalFieldIdxOrdered true bs index 595 ReadUnderlyingInstrRegistryIdx
    let underlyingCountryOfIssue = ReadOptionalFieldIdxOrdered true bs index 592 ReadUnderlyingCountryOfIssueIdx
    let underlyingStateOrProvinceOfIssue = ReadOptionalFieldIdxOrdered true bs index 593 ReadUnderlyingStateOrProvinceOfIssueIdx
    let underlyingLocaleOfIssue = ReadOptionalFieldIdxOrdered true bs index 594 ReadUnderlyingLocaleOfIssueIdx
    let underlyingRedemptionDate = ReadOptionalFieldIdxOrdered true bs index 247 ReadUnderlyingRedemptionDateIdx
    let underlyingStrikePrice = ReadOptionalFieldIdxOrdered true bs index 316 ReadUnderlyingStrikePriceIdx
    let underlyingStrikeCurrency = ReadOptionalFieldIdxOrdered true bs index 941 ReadUnderlyingStrikeCurrencyIdx
    let underlyingOptAttribute = ReadOptionalFieldIdxOrdered true bs index 317 ReadUnderlyingOptAttributeIdx
    let underlyingContractMultiplier = ReadOptionalFieldIdxOrdered true bs index 436 ReadUnderlyingContractMultiplierIdx
    let underlyingCouponRate = ReadOptionalFieldIdxOrdered true bs index 435 ReadUnderlyingCouponRateIdx
    let underlyingSecurityExchange = ReadOptionalFieldIdxOrdered true bs index 308 ReadUnderlyingSecurityExchangeIdx
    let underlyingIssuer = ReadOptionalFieldIdxOrdered true bs index 306 ReadUnderlyingIssuerIdx
    let encodedUnderlyingIssuer = ReadOptionalFieldIdxOrdered true bs index 362 ReadEncodedUnderlyingIssuerIdx
    let underlyingSecurityDesc = ReadOptionalFieldIdxOrdered true bs index 307 ReadUnderlyingSecurityDescIdx
    let encodedUnderlyingSecurityDesc = ReadOptionalFieldIdxOrdered true bs index 364 ReadEncodedUnderlyingSecurityDescIdx
    let underlyingCPProgram = ReadOptionalFieldIdxOrdered true bs index 877 ReadUnderlyingCPProgramIdx
    let underlyingCPRegType = ReadOptionalFieldIdxOrdered true bs index 878 ReadUnderlyingCPRegTypeIdx
    let underlyingCurrency = ReadOptionalFieldIdxOrdered true bs index 318 ReadUnderlyingCurrencyIdx
    let underlyingQty = ReadOptionalFieldIdxOrdered true bs index 879 ReadUnderlyingQtyIdx
    let underlyingPx = ReadOptionalFieldIdxOrdered true bs index 810 ReadUnderlyingPxIdx
    let underlyingDirtyPrice = ReadOptionalFieldIdxOrdered true bs index 882 ReadUnderlyingDirtyPriceIdx
    let underlyingEndPrice = ReadOptionalFieldIdxOrdered true bs index 883 ReadUnderlyingEndPriceIdx
    let underlyingStartValue = ReadOptionalFieldIdxOrdered true bs index 884 ReadUnderlyingStartValueIdx
    let underlyingCurrentValue = ReadOptionalFieldIdxOrdered true bs index 885 ReadUnderlyingCurrentValueIdx
    let underlyingEndValue = ReadOptionalFieldIdxOrdered true bs index 886 ReadUnderlyingEndValueIdx
    let noUnderlyingStipsGrpIdx = ReadOptionalGroupIdx bs index 887 ReadNoUnderlyingStipsGrpIdx
    let ci:UnderlyingInstrument = {
        UnderlyingSymbol = underlyingSymbol
        UnderlyingSymbolSfx = underlyingSymbolSfx
        UnderlyingSecurityID = underlyingSecurityID
        UnderlyingSecurityIDSource = underlyingSecurityIDSource
        NoUnderlyingSecurityAltIDGrp = noUnderlyingSecurityAltIDGrp
        UnderlyingProduct = underlyingProduct
        UnderlyingCFICode = underlyingCFICode
        UnderlyingSecurityType = underlyingSecurityType
        UnderlyingSecuritySubType = underlyingSecuritySubType
        UnderlyingMaturityMonthYear = underlyingMaturityMonthYear
        UnderlyingMaturityDate = underlyingMaturityDate
        UnderlyingPutOrCall = underlyingPutOrCall
        UnderlyingCouponPaymentDate = underlyingCouponPaymentDate
        UnderlyingIssueDate = underlyingIssueDate
        UnderlyingRepoCollateralSecurityType = underlyingRepoCollateralSecurityType
        UnderlyingRepurchaseTerm = underlyingRepurchaseTerm
        UnderlyingRepurchaseRate = underlyingRepurchaseRate
        UnderlyingFactor = underlyingFactor
        UnderlyingCreditRating = underlyingCreditRating
        UnderlyingInstrRegistry = underlyingInstrRegistry
        UnderlyingCountryOfIssue = underlyingCountryOfIssue
        UnderlyingStateOrProvinceOfIssue = underlyingStateOrProvinceOfIssue
        UnderlyingLocaleOfIssue = underlyingLocaleOfIssue
        UnderlyingRedemptionDate = underlyingRedemptionDate
        UnderlyingStrikePrice = underlyingStrikePrice
        UnderlyingStrikeCurrency = underlyingStrikeCurrency
        UnderlyingOptAttribute = underlyingOptAttribute
        UnderlyingContractMultiplier = underlyingContractMultiplier
        UnderlyingCouponRate = underlyingCouponRate
        UnderlyingSecurityExchange = underlyingSecurityExchange
        UnderlyingIssuer = underlyingIssuer
        EncodedUnderlyingIssuer = encodedUnderlyingIssuer
        UnderlyingSecurityDesc = underlyingSecurityDesc
        EncodedUnderlyingSecurityDesc = encodedUnderlyingSecurityDesc
        UnderlyingCPProgram = underlyingCPProgram
        UnderlyingCPRegType = underlyingCPRegType
        UnderlyingCurrency = underlyingCurrency
        UnderlyingQty = underlyingQty
        UnderlyingPx = underlyingPx
        UnderlyingDirtyPrice = underlyingDirtyPrice
        UnderlyingEndPrice = underlyingEndPrice
        UnderlyingStartValue = underlyingStartValue
        UnderlyingCurrentValue = underlyingCurrentValue
        UnderlyingEndValue = underlyingEndValue
        NoUnderlyingStipsGrp = noUnderlyingStipsGrp
    }
    ci


// group
let ReadCollateralResponseNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CollateralResponseNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentIdxOrdered true bs index ReadUnderlyingInstrumentIdx
    let collAction = ReadOptionalFieldIdxOrdered true bs index 944 ReadCollActionIdx
    let ci:CollateralResponseNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    ci


// group
let ReadCollateralAssignmentNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CollateralAssignmentNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentIdxOrdered true bs index ReadUnderlyingInstrumentIdx
    let collAction = ReadOptionalFieldIdxOrdered true bs index 944 ReadCollActionIdx
    let ci:CollateralAssignmentNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    ci


// group
let ReadCollateralRequestNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CollateralRequestNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentIdxOrdered true bs index ReadUnderlyingInstrumentIdx
    let collAction = ReadOptionalFieldIdxOrdered true bs index 944 ReadCollActionIdx
    let ci:CollateralRequestNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    ci


// group
let ReadPositionReportNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionReportNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentIdxOrdered true bs index ReadUnderlyingInstrumentIdx
    let underlyingSettlPrice = ReadFieldIdxOrdered true bs index 732 ReadUnderlyingSettlPriceIdx
    let underlyingSettlPriceType = ReadFieldIdxOrdered true bs index 733 ReadUnderlyingSettlPriceTypeIdx
    let ci:PositionReportNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        UnderlyingSettlPrice = underlyingSettlPrice
        UnderlyingSettlPriceType = underlyingSettlPriceType
    }
    ci


// group
let ReadNoNestedPartySubIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNestedPartySubIDsGrp =
    let nestedPartySubID = ReadFieldIdxOrdered true bs index 545 ReadNestedPartySubIDIdx
    let nestedPartySubIDType = ReadOptionalFieldIdxOrdered true bs index 805 ReadNestedPartySubIDTypeIdx
    let ci:NoNestedPartySubIDsGrp = {
        NestedPartySubID = nestedPartySubID
        NestedPartySubIDType = nestedPartySubIDType
    }
    ci


// group
let ReadNoNestedPartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNestedPartyIDsGrp =
    let nestedPartyID = ReadFieldIdxOrdered true bs index 524 ReadNestedPartyIDIdx
    let nestedPartyIDSource = ReadOptionalFieldIdxOrdered true bs index 525 ReadNestedPartyIDSourceIdx
    let nestedPartyRole = ReadOptionalFieldIdxOrdered true bs index 538 ReadNestedPartyRoleIdx
    let noNestedPartySubIDsGrpIdx = ReadOptionalGroupIdx bs index 804 ReadNoNestedPartySubIDsGrpIdx
    let ci:NoNestedPartyIDsGrp = {
        NestedPartyID = nestedPartyID
        NestedPartyIDSource = nestedPartyIDSource
        NestedPartyRole = nestedPartyRole
        NoNestedPartySubIDsGrp = noNestedPartySubIDsGrp
    }
    ci


// group
let ReadNoPositionsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoPositionsGrp =
    let posType = ReadFieldIdxOrdered true bs index 703 ReadPosTypeIdx
    let longQty = ReadOptionalFieldIdxOrdered true bs index 704 ReadLongQtyIdx
    let shortQty = ReadOptionalFieldIdxOrdered true bs index 705 ReadShortQtyIdx
    let posQtyStatus = ReadOptionalFieldIdxOrdered true bs index 706 ReadPosQtyStatusIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let ci:NoPositionsGrp = {
        PosType = posType
        LongQty = longQty
        ShortQty = shortQty
        PosQtyStatus = posQtyStatus
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
    }
    ci


// component
let ReadPositionQtyIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionQty =
    let noPositionsGrp = ReadGroupIdx bs index tag702 "ReadPositionQty"  ReadNoPositionsGrpIdx
    let ci:PositionQty = {
        NoPositionsGrp = noPositionsGrp
    }
    ci


// group
let ReadNoRegistDtlsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoRegistDtlsGrp =
    let registDtls = ReadFieldIdxOrdered true bs index 509 ReadRegistDtlsIdx
    let registEmail = ReadOptionalFieldIdxOrdered true bs index 511 ReadRegistEmailIdx
    let mailingDtls = ReadOptionalFieldIdxOrdered true bs index 474 ReadMailingDtlsIdx
    let mailingInst = ReadOptionalFieldIdxOrdered true bs index 482 ReadMailingInstIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let ownerType = ReadOptionalFieldIdxOrdered true bs index 522 ReadOwnerTypeIdx
    let dateOfBirth = ReadOptionalFieldIdxOrdered true bs index 486 ReadDateOfBirthIdx
    let investorCountryOfResidence = ReadOptionalFieldIdxOrdered true bs index 475 ReadInvestorCountryOfResidenceIdx
    let ci:NoRegistDtlsGrp = {
        RegistDtls = registDtls
        RegistEmail = registEmail
        MailingDtls = mailingDtls
        MailingInst = mailingInst
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        OwnerType = ownerType
        DateOfBirth = dateOfBirth
        InvestorCountryOfResidence = investorCountryOfResidence
    }
    ci


// group
let ReadNoNested2PartySubIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNested2PartySubIDsGrp =
    let nested2PartySubID = ReadFieldIdxOrdered true bs index 760 ReadNested2PartySubIDIdx
    let nested2PartySubIDType = ReadOptionalFieldIdxOrdered true bs index 807 ReadNested2PartySubIDTypeIdx
    let ci:NoNested2PartySubIDsGrp = {
        Nested2PartySubID = nested2PartySubID
        Nested2PartySubIDType = nested2PartySubIDType
    }
    ci


// group
let ReadNoNested2PartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNested2PartyIDsGrp =
    let nested2PartyID = ReadFieldIdxOrdered true bs index 757 ReadNested2PartyIDIdx
    let nested2PartyIDSource = ReadOptionalFieldIdxOrdered true bs index 758 ReadNested2PartyIDSourceIdx
    let nested2PartyRole = ReadOptionalFieldIdxOrdered true bs index 759 ReadNested2PartyRoleIdx
    let noNested2PartySubIDsGrpIdx = ReadOptionalGroupIdx bs index 806 ReadNoNested2PartySubIDsGrpIdx
    let ci:NoNested2PartyIDsGrp = {
        Nested2PartyID = nested2PartyID
        Nested2PartyIDSource = nested2PartyIDSource
        Nested2PartyRole = nested2PartyRole
        NoNested2PartySubIDsGrp = noNested2PartySubIDsGrp
    }
    ci


// group
let ReadTradeCaptureReportAckNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportAckNoAllocsGrp =
    let allocAccount = ReadFieldIdxOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdxOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldIdxOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldIdxOrdered true bs index 467 ReadIndividualAllocIDIdx
    let noNested2PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 756 ReadNoNested2PartyIDsGrpIdx
    let allocQty = ReadOptionalFieldIdxOrdered true bs index 80 ReadAllocQtyIdx
    let ci:TradeCaptureReportAckNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
        AllocQty = allocQty
    }
    ci


// group
let ReadNoLegSecurityAltIDGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoLegSecurityAltIDGrp =
    let legSecurityAltID = ReadFieldIdxOrdered true bs index 605 ReadLegSecurityAltIDIdx
    let legSecurityAltIDSource = ReadOptionalFieldIdxOrdered true bs index 606 ReadLegSecurityAltIDSourceIdx
    let ci:NoLegSecurityAltIDGrp = {
        LegSecurityAltID = legSecurityAltID
        LegSecurityAltIDSource = legSecurityAltIDSource
    }
    ci


// component
let ReadInstrumentLegFGIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentLegFG =
    let legSymbol = ReadFieldIdxOrdered true bs index 600 ReadLegSymbolIdx
    let legSymbolSfx = ReadOptionalFieldIdxOrdered true bs index 601 ReadLegSymbolSfxIdx
    let legSecurityID = ReadOptionalFieldIdxOrdered true bs index 602 ReadLegSecurityIDIdx
    let legSecurityIDSource = ReadOptionalFieldIdxOrdered true bs index 603 ReadLegSecurityIDSourceIdx
    let noLegSecurityAltIDGrpIdx = ReadOptionalGroupIdx bs index 604 ReadNoLegSecurityAltIDGrpIdx
    let legProduct = ReadOptionalFieldIdxOrdered true bs index 607 ReadLegProductIdx
    let legCFICode = ReadOptionalFieldIdxOrdered true bs index 608 ReadLegCFICodeIdx
    let legSecurityType = ReadOptionalFieldIdxOrdered true bs index 609 ReadLegSecurityTypeIdx
    let legSecuritySubType = ReadOptionalFieldIdxOrdered true bs index 764 ReadLegSecuritySubTypeIdx
    let legMaturityMonthYear = ReadOptionalFieldIdxOrdered true bs index 610 ReadLegMaturityMonthYearIdx
    let legMaturityDate = ReadOptionalFieldIdxOrdered true bs index 611 ReadLegMaturityDateIdx
    let legCouponPaymentDate = ReadOptionalFieldIdxOrdered true bs index 248 ReadLegCouponPaymentDateIdx
    let legIssueDate = ReadOptionalFieldIdxOrdered true bs index 249 ReadLegIssueDateIdx
    let legRepoCollateralSecurityType = ReadOptionalFieldIdxOrdered true bs index 250 ReadLegRepoCollateralSecurityTypeIdx
    let legRepurchaseTerm = ReadOptionalFieldIdxOrdered true bs index 251 ReadLegRepurchaseTermIdx
    let legRepurchaseRate = ReadOptionalFieldIdxOrdered true bs index 252 ReadLegRepurchaseRateIdx
    let legFactor = ReadOptionalFieldIdxOrdered true bs index 253 ReadLegFactorIdx
    let legCreditRating = ReadOptionalFieldIdxOrdered true bs index 257 ReadLegCreditRatingIdx
    let legInstrRegistry = ReadOptionalFieldIdxOrdered true bs index 599 ReadLegInstrRegistryIdx
    let legCountryOfIssue = ReadOptionalFieldIdxOrdered true bs index 596 ReadLegCountryOfIssueIdx
    let legStateOrProvinceOfIssue = ReadOptionalFieldIdxOrdered true bs index 597 ReadLegStateOrProvinceOfIssueIdx
    let legLocaleOfIssue = ReadOptionalFieldIdxOrdered true bs index 598 ReadLegLocaleOfIssueIdx
    let legRedemptionDate = ReadOptionalFieldIdxOrdered true bs index 254 ReadLegRedemptionDateIdx
    let legStrikePrice = ReadOptionalFieldIdxOrdered true bs index 612 ReadLegStrikePriceIdx
    let legStrikeCurrency = ReadOptionalFieldIdxOrdered true bs index 942 ReadLegStrikeCurrencyIdx
    let legOptAttribute = ReadOptionalFieldIdxOrdered true bs index 613 ReadLegOptAttributeIdx
    let legContractMultiplier = ReadOptionalFieldIdxOrdered true bs index 614 ReadLegContractMultiplierIdx
    let legCouponRate = ReadOptionalFieldIdxOrdered true bs index 615 ReadLegCouponRateIdx
    let legSecurityExchange = ReadOptionalFieldIdxOrdered true bs index 616 ReadLegSecurityExchangeIdx
    let legIssuer = ReadOptionalFieldIdxOrdered true bs index 617 ReadLegIssuerIdx
    let encodedLegIssuer = ReadOptionalFieldIdxOrdered true bs index 618 ReadEncodedLegIssuerIdx
    let legSecurityDesc = ReadOptionalFieldIdxOrdered true bs index 620 ReadLegSecurityDescIdx
    let encodedLegSecurityDesc = ReadOptionalFieldIdxOrdered true bs index 621 ReadEncodedLegSecurityDescIdx
    let legRatioQty = ReadOptionalFieldIdxOrdered true bs index 623 ReadLegRatioQtyIdx
    let legSide = ReadOptionalFieldIdxOrdered true bs index 624 ReadLegSideIdx
    let legCurrency = ReadOptionalFieldIdxOrdered true bs index 556 ReadLegCurrencyIdx
    let legPool = ReadOptionalFieldIdxOrdered true bs index 740 ReadLegPoolIdx
    let legDatedDate = ReadOptionalFieldIdxOrdered true bs index 739 ReadLegDatedDateIdx
    let legContractSettlMonth = ReadOptionalFieldIdxOrdered true bs index 955 ReadLegContractSettlMonthIdx
    let legInterestAccrualDate = ReadOptionalFieldIdxOrdered true bs index 956 ReadLegInterestAccrualDateIdx
    let ci:InstrumentLegFG = {
        LegSymbol = legSymbol
        LegSymbolSfx = legSymbolSfx
        LegSecurityID = legSecurityID
        LegSecurityIDSource = legSecurityIDSource
        NoLegSecurityAltIDGrp = noLegSecurityAltIDGrp
        LegProduct = legProduct
        LegCFICode = legCFICode
        LegSecurityType = legSecurityType
        LegSecuritySubType = legSecuritySubType
        LegMaturityMonthYear = legMaturityMonthYear
        LegMaturityDate = legMaturityDate
        LegCouponPaymentDate = legCouponPaymentDate
        LegIssueDate = legIssueDate
        LegRepoCollateralSecurityType = legRepoCollateralSecurityType
        LegRepurchaseTerm = legRepurchaseTerm
        LegRepurchaseRate = legRepurchaseRate
        LegFactor = legFactor
        LegCreditRating = legCreditRating
        LegInstrRegistry = legInstrRegistry
        LegCountryOfIssue = legCountryOfIssue
        LegStateOrProvinceOfIssue = legStateOrProvinceOfIssue
        LegLocaleOfIssue = legLocaleOfIssue
        LegRedemptionDate = legRedemptionDate
        LegStrikePrice = legStrikePrice
        LegStrikeCurrency = legStrikeCurrency
        LegOptAttribute = legOptAttribute
        LegContractMultiplier = legContractMultiplier
        LegCouponRate = legCouponRate
        LegSecurityExchange = legSecurityExchange
        LegIssuer = legIssuer
        EncodedLegIssuer = encodedLegIssuer
        LegSecurityDesc = legSecurityDesc
        EncodedLegSecurityDesc = encodedLegSecurityDesc
        LegRatioQty = legRatioQty
        LegSide = legSide
        LegCurrency = legCurrency
        LegPool = legPool
        LegDatedDate = legDatedDate
        LegContractSettlMonth = legContractSettlMonth
        LegInterestAccrualDate = legInterestAccrualDate
    }
    ci


// group
let ReadNoLegStipulationsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoLegStipulationsGrp =
    let legStipulationType = ReadFieldIdxOrdered true bs index 688 ReadLegStipulationTypeIdx
    let legStipulationValue = ReadOptionalFieldIdxOrdered true bs index 689 ReadLegStipulationValueIdx
    let ci:NoLegStipulationsGrp = {
        LegStipulationType = legStipulationType
        LegStipulationValue = legStipulationValue
    }
    ci


// group
let ReadTradeCaptureReportAckNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportAckNoLegsGrp =
    let instrumentLegFG = ReadComponentIdxOrdered true bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdxOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdxOrdered true bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let legPositionEffect = ReadOptionalFieldIdxOrdered true bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldIdxOrdered true bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldIdxOrdered true bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldIdxOrdered true bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldIdxOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdxOrdered true bs index 588 ReadLegSettlDateIdx
    let legLastPx = ReadOptionalFieldIdxOrdered true bs index 637 ReadLegLastPxIdx
    let ci:TradeCaptureReportAckNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        NoLegStipulationsGrp = noLegStipulationsGrp
        LegPositionEffect = legPositionEffect
        LegCoveredOrUncovered = legCoveredOrUncovered
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegRefID = legRefID
        LegPrice = legPrice
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        LegLastPx = legLastPx
    }
    ci


// group
let ReadNoPartySubIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoPartySubIDsGrp =
    let partySubID = ReadFieldIdxOrdered true bs index 523 ReadPartySubIDIdx
    let partySubIDType = ReadOptionalFieldIdxOrdered true bs index 803 ReadPartySubIDTypeIdx
    let ci:NoPartySubIDsGrp = {
        PartySubID = partySubID
        PartySubIDType = partySubIDType
    }
    ci


// group
let ReadNoPartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoPartyIDsGrp =
    let partyID = ReadFieldIdxOrdered true bs index 448 ReadPartyIDIdx
    let partyIDSource = ReadOptionalFieldIdxOrdered true bs index 447 ReadPartyIDSourceIdx
    let partyRole = ReadOptionalFieldIdxOrdered true bs index 452 ReadPartyRoleIdx
    let noPartySubIDsGrpIdx = ReadOptionalGroupIdx bs index 802 ReadNoPartySubIDsGrpIdx
    let ci:NoPartyIDsGrp = {
        PartyID = partyID
        PartyIDSource = partyIDSource
        PartyRole = partyRole
        NoPartySubIDsGrp = noPartySubIDsGrp
    }
    ci


// group
let ReadNoClearingInstructionsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoClearingInstructionsGrp =
    let clearingInstruction = ReadFieldIdxOrdered true bs index 577 ReadClearingInstructionIdx
    let ci:NoClearingInstructionsGrp = {
        ClearingInstruction = clearingInstruction
    }
    ci


// component
let ReadCommissionDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CommissionData =
    let commission = ReadOptionalFieldIdxOrdered true bs index 12 ReadCommissionIdx
    let commType = ReadOptionalFieldIdxOrdered true bs index 13 ReadCommTypeIdx
    let commCurrency = ReadOptionalFieldIdxOrdered true bs index 479 ReadCommCurrencyIdx
    let fundRenewWaiv = ReadOptionalFieldIdxOrdered true bs index 497 ReadFundRenewWaivIdx
    let ci:CommissionData = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    ci


// group
let ReadNoContAmtsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoContAmtsGrp =
    let contAmtType = ReadFieldIdxOrdered true bs index 519 ReadContAmtTypeIdx
    let contAmtValue = ReadOptionalFieldIdxOrdered true bs index 520 ReadContAmtValueIdx
    let contAmtCurr = ReadOptionalFieldIdxOrdered true bs index 521 ReadContAmtCurrIdx
    let ci:NoContAmtsGrp = {
        ContAmtType = contAmtType
        ContAmtValue = contAmtValue
        ContAmtCurr = contAmtCurr
    }
    ci


// group
let ReadNoStipulationsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoStipulationsGrp =
    let stipulationType = ReadFieldIdxOrdered true bs index 233 ReadStipulationTypeIdx
    let stipulationValue = ReadOptionalFieldIdxOrdered true bs index 234 ReadStipulationValueIdx
    let ci:NoStipulationsGrp = {
        StipulationType = stipulationType
        StipulationValue = stipulationValue
    }
    ci


// group
let ReadNoMiscFeesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMiscFeesGrp =
    let miscFeeAmt = ReadFieldIdxOrdered true bs index 137 ReadMiscFeeAmtIdx
    let miscFeeCurr = ReadOptionalFieldIdxOrdered true bs index 138 ReadMiscFeeCurrIdx
    let miscFeeType = ReadOptionalFieldIdxOrdered true bs index 139 ReadMiscFeeTypeIdx
    let miscFeeBasis = ReadOptionalFieldIdxOrdered true bs index 891 ReadMiscFeeBasisIdx
    let ci:NoMiscFeesGrp = {
        MiscFeeAmt = miscFeeAmt
        MiscFeeCurr = miscFeeCurr
        MiscFeeType = miscFeeType
        MiscFeeBasis = miscFeeBasis
    }
    ci


// group
let ReadTradeCaptureReportNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportNoAllocsGrp =
    let allocAccount = ReadFieldIdxOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdxOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldIdxOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldIdxOrdered true bs index 467 ReadIndividualAllocIDIdx
    let noNested2PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 756 ReadNoNested2PartyIDsGrpIdx
    let allocQty = ReadOptionalFieldIdxOrdered true bs index 80 ReadAllocQtyIdx
    let ci:TradeCaptureReportNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
        AllocQty = allocQty
    }
    ci


// group
let ReadTradeCaptureReportNoSidesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportNoSidesGrp =
    let side = ReadFieldIdxOrdered true bs index 54 ReadSideIdx
    let orderID = ReadFieldIdxOrdered true bs index 37 ReadOrderIDIdx
    let secondaryOrderID = ReadOptionalFieldIdxOrdered true bs index 198 ReadSecondaryOrderIDIdx
    let clOrdID = ReadOptionalFieldIdxOrdered true bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdxOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let listID = ReadOptionalFieldIdxOrdered true bs index 66 ReadListIDIdx
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let account = ReadOptionalFieldIdxOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdxOrdered true bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldIdxOrdered true bs index 581 ReadAccountTypeIdx
    let processCode = ReadOptionalFieldIdxOrdered true bs index 81 ReadProcessCodeIdx
    let oddLot = ReadOptionalFieldIdxOrdered true bs index 575 ReadOddLotIdx
    let noClearingInstructionsGrpIdx = ReadOptionalGroupIdx bs index 576 ReadNoClearingInstructionsGrpIdx
    let clearingFeeIndicator = ReadOptionalFieldIdxOrdered true bs index 635 ReadClearingFeeIndicatorIdx
    let tradeInputSource = ReadOptionalFieldIdxOrdered true bs index 578 ReadTradeInputSourceIdx
    let tradeInputDevice = ReadOptionalFieldIdxOrdered true bs index 579 ReadTradeInputDeviceIdx
    let orderInputDevice = ReadOptionalFieldIdxOrdered true bs index 821 ReadOrderInputDeviceIdx
    let currency = ReadOptionalFieldIdxOrdered true bs index 15 ReadCurrencyIdx
    let complianceID = ReadOptionalFieldIdxOrdered true bs index 376 ReadComplianceIDIdx
    let solicitedFlag = ReadOptionalFieldIdxOrdered true bs index 377 ReadSolicitedFlagIdx
    let orderCapacity = ReadOptionalFieldIdxOrdered true bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldIdxOrdered true bs index 529 ReadOrderRestrictionsIdx
    let custOrderCapacity = ReadOptionalFieldIdxOrdered true bs index 582 ReadCustOrderCapacityIdx
    let ordType = ReadOptionalFieldIdxOrdered true bs index 40 ReadOrdTypeIdx
    let execInst = ReadOptionalFieldIdxOrdered true bs index 18 ReadExecInstIdx
    let transBkdTime = ReadOptionalFieldIdxOrdered true bs index 483 ReadTransBkdTimeIdx
    let tradingSessionID = ReadOptionalFieldIdxOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdxOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let timeBracket = ReadOptionalFieldIdxOrdered true bs index 943 ReadTimeBracketIdx
    let commissionData = ReadComponentIdxOrdered true bs index ReadCommissionDataIdx
    let grossTradeAmt = ReadOptionalFieldIdxOrdered true bs index 381 ReadGrossTradeAmtIdx
    let numDaysInterest = ReadOptionalFieldIdxOrdered true bs index 157 ReadNumDaysInterestIdx
    let exDate = ReadOptionalFieldIdxOrdered true bs index 230 ReadExDateIdx
    let accruedInterestRate = ReadOptionalFieldIdxOrdered true bs index 158 ReadAccruedInterestRateIdx
    let accruedInterestAmt = ReadOptionalFieldIdxOrdered true bs index 159 ReadAccruedInterestAmtIdx
    let interestAtMaturity = ReadOptionalFieldIdxOrdered true bs index 738 ReadInterestAtMaturityIdx
    let endAccruedInterestAmt = ReadOptionalFieldIdxOrdered true bs index 920 ReadEndAccruedInterestAmtIdx
    let startCash = ReadOptionalFieldIdxOrdered true bs index 921 ReadStartCashIdx
    let endCash = ReadOptionalFieldIdxOrdered true bs index 922 ReadEndCashIdx
    let concession = ReadOptionalFieldIdxOrdered true bs index 238 ReadConcessionIdx
    let totalTakedown = ReadOptionalFieldIdxOrdered true bs index 237 ReadTotalTakedownIdx
    let netMoney = ReadOptionalFieldIdxOrdered true bs index 118 ReadNetMoneyIdx
    let settlCurrAmt = ReadOptionalFieldIdxOrdered true bs index 119 ReadSettlCurrAmtIdx
    let settlCurrency = ReadOptionalFieldIdxOrdered true bs index 120 ReadSettlCurrencyIdx
    let settlCurrFxRate = ReadOptionalFieldIdxOrdered true bs index 155 ReadSettlCurrFxRateIdx
    let settlCurrFxRateCalc = ReadOptionalFieldIdxOrdered true bs index 156 ReadSettlCurrFxRateCalcIdx
    let positionEffect = ReadOptionalFieldIdxOrdered true bs index 77 ReadPositionEffectIdx
    let text = ReadOptionalFieldIdxOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdxOrdered true bs index 354 ReadEncodedTextIdx
    let sideMultiLegReportingType = ReadOptionalFieldIdxOrdered true bs index 752 ReadSideMultiLegReportingTypeIdx
    let noContAmtsGrpIdx = ReadOptionalGroupIdx bs index 518 ReadNoContAmtsGrpIdx
    let noStipulationsGrpIdx = ReadOptionalGroupIdx bs index 232 ReadNoStipulationsGrpIdx
    let noMiscFeesGrpIdx = ReadOptionalGroupIdx bs index 136 ReadNoMiscFeesGrpIdx
    let exchangeRule = ReadOptionalFieldIdxOrdered true bs index 825 ReadExchangeRuleIdx
    let tradeAllocIndicator = ReadOptionalFieldIdxOrdered true bs index 826 ReadTradeAllocIndicatorIdx
    let preallocMethod = ReadOptionalFieldIdxOrdered true bs index 591 ReadPreallocMethodIdx
    let allocID = ReadOptionalFieldIdxOrdered true bs index 70 ReadAllocIDIdx
    let tradeCaptureReportNoAllocsGrpIdx = ReadOptionalGroupIdx bs index 78 ReadTradeCaptureReportNoAllocsGrpIdx
    let ci:TradeCaptureReportNoSidesGrp = {
        Side = side
        OrderID = orderID
        SecondaryOrderID = secondaryOrderID
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        ListID = listID
        NoPartyIDsGrp = noPartyIDsGrp
        Account = account
        AcctIDSource = acctIDSource
        AccountType = accountType
        ProcessCode = processCode
        OddLot = oddLot
        NoClearingInstructionsGrp = noClearingInstructionsGrp
        ClearingFeeIndicator = clearingFeeIndicator
        TradeInputSource = tradeInputSource
        TradeInputDevice = tradeInputDevice
        OrderInputDevice = orderInputDevice
        Currency = currency
        ComplianceID = complianceID
        SolicitedFlag = solicitedFlag
        OrderCapacity = orderCapacity
        OrderRestrictions = orderRestrictions
        CustOrderCapacity = custOrderCapacity
        OrdType = ordType
        ExecInst = execInst
        TransBkdTime = transBkdTime
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        TimeBracket = timeBracket
        CommissionData = commissionData
        GrossTradeAmt = grossTradeAmt
        NumDaysInterest = numDaysInterest
        ExDate = exDate
        AccruedInterestRate = accruedInterestRate
        AccruedInterestAmt = accruedInterestAmt
        InterestAtMaturity = interestAtMaturity
        EndAccruedInterestAmt = endAccruedInterestAmt
        StartCash = startCash
        EndCash = endCash
        Concession = concession
        TotalTakedown = totalTakedown
        NetMoney = netMoney
        SettlCurrAmt = settlCurrAmt
        SettlCurrency = settlCurrency
        SettlCurrFxRate = settlCurrFxRate
        SettlCurrFxRateCalc = settlCurrFxRateCalc
        PositionEffect = positionEffect
        Text = text
        EncodedText = encodedText
        SideMultiLegReportingType = sideMultiLegReportingType
        NoContAmtsGrp = noContAmtsGrp
        NoStipulationsGrp = noStipulationsGrp
        NoMiscFeesGrp = noMiscFeesGrp
        ExchangeRule = exchangeRule
        TradeAllocIndicator = tradeAllocIndicator
        PreallocMethod = preallocMethod
        AllocID = allocID
        TradeCaptureReportNoAllocsGrp = tradeCaptureReportNoAllocsGrp
    }
    ci


// group
let ReadTradeCaptureReportNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportNoLegsGrp =
    let instrumentLegFG = ReadComponentIdxOrdered true bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdxOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdxOrdered true bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let legPositionEffect = ReadOptionalFieldIdxOrdered true bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldIdxOrdered true bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldIdxOrdered true bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldIdxOrdered true bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldIdxOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdxOrdered true bs index 588 ReadLegSettlDateIdx
    let legLastPx = ReadOptionalFieldIdxOrdered true bs index 637 ReadLegLastPxIdx
    let ci:TradeCaptureReportNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        NoLegStipulationsGrp = noLegStipulationsGrp
        LegPositionEffect = legPositionEffect
        LegCoveredOrUncovered = legCoveredOrUncovered
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegRefID = legRefID
        LegPrice = legPrice
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        LegLastPx = legLastPx
    }
    ci


// group
let ReadNoPosAmtGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoPosAmtGrp =
    let posAmtType = ReadFieldIdxOrdered true bs index 707 ReadPosAmtTypeIdx
    let posAmt = ReadFieldIdxOrdered true bs index 708 ReadPosAmtIdx
    let ci:NoPosAmtGrp = {
        PosAmtType = posAmtType
        PosAmt = posAmt
    }
    ci


// component
let ReadPositionAmountDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionAmountData =
    let noPosAmtGrp = ReadGroupIdx bs index tag753 "ReadPositionAmountData"  ReadNoPosAmtGrpIdx
    let ci:PositionAmountData = {
        NoPosAmtGrp = noPosAmtGrp
    }
    ci


// group
let ReadNoSettlPartySubIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSettlPartySubIDsGrp =
    let settlPartySubID = ReadFieldIdxOrdered true bs index 785 ReadSettlPartySubIDIdx
    let settlPartySubIDType = ReadOptionalFieldIdxOrdered true bs index 786 ReadSettlPartySubIDTypeIdx
    let ci:NoSettlPartySubIDsGrp = {
        SettlPartySubID = settlPartySubID
        SettlPartySubIDType = settlPartySubIDType
    }
    ci


// group
let ReadNoSettlPartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSettlPartyIDsGrp =
    let settlPartyID = ReadFieldIdxOrdered true bs index 782 ReadSettlPartyIDIdx
    let settlPartyIDSource = ReadOptionalFieldIdxOrdered true bs index 783 ReadSettlPartyIDSourceIdx
    let settlPartyRole = ReadOptionalFieldIdxOrdered true bs index 784 ReadSettlPartyRoleIdx
    let noSettlPartySubIDsGrpIdx = ReadOptionalGroupIdx bs index 801 ReadNoSettlPartySubIDsGrpIdx
    let ci:NoSettlPartyIDsGrp = {
        SettlPartyID = settlPartyID
        SettlPartyIDSource = settlPartyIDSource
        SettlPartyRole = settlPartyRole
        NoSettlPartySubIDsGrp = noSettlPartySubIDsGrp
    }
    ci


// group
let ReadNoDlvyInstGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoDlvyInstGrp =
    let settlInstSource = ReadFieldIdxOrdered true bs index 165 ReadSettlInstSourceIdx
    let dlvyInstType = ReadOptionalFieldIdxOrdered true bs index 787 ReadDlvyInstTypeIdx
    let noSettlPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 781 ReadNoSettlPartyIDsGrpIdx
    let ci:NoDlvyInstGrp = {
        SettlInstSource = settlInstSource
        DlvyInstType = dlvyInstType
        NoSettlPartyIDsGrp = noSettlPartyIDsGrp
    }
    ci


// component
let ReadSettlInstructionsDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SettlInstructionsData =
    let settlDeliveryType = ReadOptionalFieldIdxOrdered true bs index 172 ReadSettlDeliveryTypeIdx
    let standInstDbType = ReadOptionalFieldIdxOrdered true bs index 169 ReadStandInstDbTypeIdx
    let standInstDbName = ReadOptionalFieldIdxOrdered true bs index 170 ReadStandInstDbNameIdx
    let standInstDbID = ReadOptionalFieldIdxOrdered true bs index 171 ReadStandInstDbIDIdx
    let noDlvyInstGrpIdx = ReadOptionalGroupIdx bs index 85 ReadNoDlvyInstGrpIdx
    let ci:SettlInstructionsData = {
        SettlDeliveryType = settlDeliveryType
        StandInstDbType = standInstDbType
        StandInstDbName = standInstDbName
        StandInstDbID = standInstDbID
        NoDlvyInstGrp = noDlvyInstGrp
    }
    ci


// group
let ReadNoSettlInstGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSettlInstGrp =
    let settlInstID = ReadFieldIdxOrdered true bs index 162 ReadSettlInstIDIdx
    let settlInstTransType = ReadOptionalFieldIdxOrdered true bs index 163 ReadSettlInstTransTypeIdx
    let settlInstRefID = ReadOptionalFieldIdxOrdered true bs index 214 ReadSettlInstRefIDIdx
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let side = ReadOptionalFieldIdxOrdered true bs index 54 ReadSideIdx
    let product = ReadOptionalFieldIdxOrdered true bs index 460 ReadProductIdx
    let securityType = ReadOptionalFieldIdxOrdered true bs index 167 ReadSecurityTypeIdx
    let cFICode = ReadOptionalFieldIdxOrdered true bs index 461 ReadCFICodeIdx
    let effectiveTime = ReadOptionalFieldIdxOrdered true bs index 168 ReadEffectiveTimeIdx
    let expireTime = ReadOptionalFieldIdxOrdered true bs index 126 ReadExpireTimeIdx
    let lastUpdateTime = ReadOptionalFieldIdxOrdered true bs index 779 ReadLastUpdateTimeIdx
    let settlInstructionsData = ReadComponentIdxOrdered true bs index ReadSettlInstructionsDataIdx
    let paymentMethod = ReadOptionalFieldIdxOrdered true bs index 492 ReadPaymentMethodIdx
    let paymentRef = ReadOptionalFieldIdxOrdered true bs index 476 ReadPaymentRefIdx
    let cardHolderName = ReadOptionalFieldIdxOrdered true bs index 488 ReadCardHolderNameIdx
    let cardNumber = ReadOptionalFieldIdxOrdered true bs index 489 ReadCardNumberIdx
    let cardStartDate = ReadOptionalFieldIdxOrdered true bs index 503 ReadCardStartDateIdx
    let cardExpDate = ReadOptionalFieldIdxOrdered true bs index 490 ReadCardExpDateIdx
    let cardIssNum = ReadOptionalFieldIdxOrdered true bs index 491 ReadCardIssNumIdx
    let paymentDate = ReadOptionalFieldIdxOrdered true bs index 504 ReadPaymentDateIdx
    let paymentRemitterID = ReadOptionalFieldIdxOrdered true bs index 505 ReadPaymentRemitterIDIdx
    let ci:NoSettlInstGrp = {
        SettlInstID = settlInstID
        SettlInstTransType = settlInstTransType
        SettlInstRefID = settlInstRefID
        NoPartyIDsGrp = noPartyIDsGrp
        Side = side
        Product = product
        SecurityType = securityType
        CFICode = cFICode
        EffectiveTime = effectiveTime
        ExpireTime = expireTime
        LastUpdateTime = lastUpdateTime
        SettlInstructionsData = settlInstructionsData
        PaymentMethod = paymentMethod
        PaymentRef = paymentRef
        CardHolderName = cardHolderName
        CardNumber = cardNumber
        CardStartDate = cardStartDate
        CardExpDate = cardExpDate
        CardIssNum = cardIssNum
        PaymentDate = paymentDate
        PaymentRemitterID = paymentRemitterID
    }
    ci


// group
let ReadNoTrdRegTimestampsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoTrdRegTimestampsGrp =
    let trdRegTimestamp = ReadFieldIdxOrdered true bs index 769 ReadTrdRegTimestampIdx
    let trdRegTimestampType = ReadOptionalFieldIdxOrdered true bs index 770 ReadTrdRegTimestampTypeIdx
    let trdRegTimestampOrigin = ReadOptionalFieldIdxOrdered true bs index 771 ReadTrdRegTimestampOriginIdx
    let ci:NoTrdRegTimestampsGrp = {
        TrdRegTimestamp = trdRegTimestamp
        TrdRegTimestampType = trdRegTimestampType
        TrdRegTimestampOrigin = trdRegTimestampOrigin
    }
    ci


// component
let ReadTrdRegTimestampsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TrdRegTimestamps =
    let noTrdRegTimestampsGrp = ReadGroupIdx bs index tag768 "ReadTrdRegTimestamps"  ReadNoTrdRegTimestampsGrpIdx
    let ci:TrdRegTimestamps = {
        NoTrdRegTimestampsGrp = noTrdRegTimestampsGrp
    }
    ci


// group
let ReadAllocationReportNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AllocationReportNoAllocsGrp =
    let allocAccount = ReadFieldIdxOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdxOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let matchStatus = ReadOptionalFieldIdxOrdered true bs index 573 ReadMatchStatusIdx
    let allocPrice = ReadOptionalFieldIdxOrdered true bs index 366 ReadAllocPriceIdx
    let allocQty = ReadFieldIdxOrdered true bs index 80 ReadAllocQtyIdx
    let individualAllocID = ReadOptionalFieldIdxOrdered true bs index 467 ReadIndividualAllocIDIdx
    let processCode = ReadOptionalFieldIdxOrdered true bs index 81 ReadProcessCodeIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let notifyBrokerOfCredit = ReadOptionalFieldIdxOrdered true bs index 208 ReadNotifyBrokerOfCreditIdx
    let allocHandlInst = ReadOptionalFieldIdxOrdered true bs index 209 ReadAllocHandlInstIdx
    let allocText = ReadOptionalFieldIdxOrdered true bs index 161 ReadAllocTextIdx
    let encodedAllocText = ReadOptionalFieldIdxOrdered true bs index 360 ReadEncodedAllocTextIdx
    let commissionData = ReadComponentIdxOrdered true bs index ReadCommissionDataIdx
    let allocAvgPx = ReadOptionalFieldIdxOrdered true bs index 153 ReadAllocAvgPxIdx
    let allocNetMoney = ReadOptionalFieldIdxOrdered true bs index 154 ReadAllocNetMoneyIdx
    let settlCurrAmt = ReadOptionalFieldIdxOrdered true bs index 119 ReadSettlCurrAmtIdx
    let allocSettlCurrAmt = ReadOptionalFieldIdxOrdered true bs index 737 ReadAllocSettlCurrAmtIdx
    let settlCurrency = ReadOptionalFieldIdxOrdered true bs index 120 ReadSettlCurrencyIdx
    let allocSettlCurrency = ReadOptionalFieldIdxOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let settlCurrFxRate = ReadOptionalFieldIdxOrdered true bs index 155 ReadSettlCurrFxRateIdx
    let settlCurrFxRateCalc = ReadOptionalFieldIdxOrdered true bs index 156 ReadSettlCurrFxRateCalcIdx
    let allocAccruedInterestAmt = ReadOptionalFieldIdxOrdered true bs index 742 ReadAllocAccruedInterestAmtIdx
    let allocInterestAtMaturity = ReadOptionalFieldIdxOrdered true bs index 741 ReadAllocInterestAtMaturityIdx
    let noMiscFeesGrpIdx = ReadOptionalGroupIdx bs index 136 ReadNoMiscFeesGrpIdx
    let noClearingInstructionsGrpIdx = ReadOptionalGroupIdx bs index 576 ReadNoClearingInstructionsGrpIdx
    let clearingFeeIndicator = ReadOptionalFieldIdxOrdered true bs index 635 ReadClearingFeeIndicatorIdx
    let allocSettlInstType = ReadOptionalFieldIdxOrdered true bs index 780 ReadAllocSettlInstTypeIdx
    let settlInstructionsData = ReadComponentIdxOrdered true bs index ReadSettlInstructionsDataIdx
    let ci:AllocationReportNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        MatchStatus = matchStatus
        AllocPrice = allocPrice
        AllocQty = allocQty
        IndividualAllocID = individualAllocID
        ProcessCode = processCode
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        NotifyBrokerOfCredit = notifyBrokerOfCredit
        AllocHandlInst = allocHandlInst
        AllocText = allocText
        EncodedAllocText = encodedAllocText
        CommissionData = commissionData
        AllocAvgPx = allocAvgPx
        AllocNetMoney = allocNetMoney
        SettlCurrAmt = settlCurrAmt
        AllocSettlCurrAmt = allocSettlCurrAmt
        SettlCurrency = settlCurrency
        AllocSettlCurrency = allocSettlCurrency
        SettlCurrFxRate = settlCurrFxRate
        SettlCurrFxRateCalc = settlCurrFxRateCalc
        AllocAccruedInterestAmt = allocAccruedInterestAmt
        AllocInterestAtMaturity = allocInterestAtMaturity
        NoMiscFeesGrp = noMiscFeesGrp
        NoClearingInstructionsGrp = noClearingInstructionsGrp
        ClearingFeeIndicator = clearingFeeIndicator
        AllocSettlInstType = allocSettlInstType
        SettlInstructionsData = settlInstructionsData
    }
    ci


// group
let ReadAllocationInstructionNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AllocationInstructionNoAllocsGrp =
    let allocAccount = ReadFieldIdxOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdxOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let matchStatus = ReadOptionalFieldIdxOrdered true bs index 573 ReadMatchStatusIdx
    let allocPrice = ReadOptionalFieldIdxOrdered true bs index 366 ReadAllocPriceIdx
    let allocQty = ReadOptionalFieldIdxOrdered true bs index 80 ReadAllocQtyIdx
    let individualAllocID = ReadOptionalFieldIdxOrdered true bs index 467 ReadIndividualAllocIDIdx
    let processCode = ReadOptionalFieldIdxOrdered true bs index 81 ReadProcessCodeIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let notifyBrokerOfCredit = ReadOptionalFieldIdxOrdered true bs index 208 ReadNotifyBrokerOfCreditIdx
    let allocHandlInst = ReadOptionalFieldIdxOrdered true bs index 209 ReadAllocHandlInstIdx
    let allocText = ReadOptionalFieldIdxOrdered true bs index 161 ReadAllocTextIdx
    let encodedAllocText = ReadOptionalFieldIdxOrdered true bs index 360 ReadEncodedAllocTextIdx
    let commissionData = ReadComponentIdxOrdered true bs index ReadCommissionDataIdx
    let allocAvgPx = ReadOptionalFieldIdxOrdered true bs index 153 ReadAllocAvgPxIdx
    let allocNetMoney = ReadOptionalFieldIdxOrdered true bs index 154 ReadAllocNetMoneyIdx
    let settlCurrAmt = ReadOptionalFieldIdxOrdered true bs index 119 ReadSettlCurrAmtIdx
    let allocSettlCurrAmt = ReadOptionalFieldIdxOrdered true bs index 737 ReadAllocSettlCurrAmtIdx
    let settlCurrency = ReadOptionalFieldIdxOrdered true bs index 120 ReadSettlCurrencyIdx
    let allocSettlCurrency = ReadOptionalFieldIdxOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let settlCurrFxRate = ReadOptionalFieldIdxOrdered true bs index 155 ReadSettlCurrFxRateIdx
    let settlCurrFxRateCalc = ReadOptionalFieldIdxOrdered true bs index 156 ReadSettlCurrFxRateCalcIdx
    let accruedInterestAmt = ReadOptionalFieldIdxOrdered true bs index 159 ReadAccruedInterestAmtIdx
    let allocAccruedInterestAmt = ReadOptionalFieldIdxOrdered true bs index 742 ReadAllocAccruedInterestAmtIdx
    let allocInterestAtMaturity = ReadOptionalFieldIdxOrdered true bs index 741 ReadAllocInterestAtMaturityIdx
    let settlInstMode = ReadOptionalFieldIdxOrdered true bs index 160 ReadSettlInstModeIdx
    let noMiscFeesGrpIdx = ReadOptionalGroupIdx bs index 136 ReadNoMiscFeesGrpIdx
    let noClearingInstructions = ReadOptionalFieldIdxOrdered true bs index 576 ReadNoClearingInstructionsIdx
    let clearingInstruction = ReadOptionalFieldIdxOrdered true bs index 577 ReadClearingInstructionIdx
    let clearingFeeIndicator = ReadOptionalFieldIdxOrdered true bs index 635 ReadClearingFeeIndicatorIdx
    let allocSettlInstType = ReadOptionalFieldIdxOrdered true bs index 780 ReadAllocSettlInstTypeIdx
    let settlInstructionsData = ReadComponentIdxOrdered true bs index ReadSettlInstructionsDataIdx
    let ci:AllocationInstructionNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        MatchStatus = matchStatus
        AllocPrice = allocPrice
        AllocQty = allocQty
        IndividualAllocID = individualAllocID
        ProcessCode = processCode
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        NotifyBrokerOfCredit = notifyBrokerOfCredit
        AllocHandlInst = allocHandlInst
        AllocText = allocText
        EncodedAllocText = encodedAllocText
        CommissionData = commissionData
        AllocAvgPx = allocAvgPx
        AllocNetMoney = allocNetMoney
        SettlCurrAmt = settlCurrAmt
        AllocSettlCurrAmt = allocSettlCurrAmt
        SettlCurrency = settlCurrency
        AllocSettlCurrency = allocSettlCurrency
        SettlCurrFxRate = settlCurrFxRate
        SettlCurrFxRateCalc = settlCurrFxRateCalc
        AccruedInterestAmt = accruedInterestAmt
        AllocAccruedInterestAmt = allocAccruedInterestAmt
        AllocInterestAtMaturity = allocInterestAtMaturity
        SettlInstMode = settlInstMode
        NoMiscFeesGrp = noMiscFeesGrp
        NoClearingInstructions = noClearingInstructions
        ClearingInstruction = clearingInstruction
        ClearingFeeIndicator = clearingFeeIndicator
        AllocSettlInstType = allocSettlInstType
        SettlInstructionsData = settlInstructionsData
    }
    ci


// component
let ReadSettlPartiesIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SettlParties =
    let noSettlPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 781 ReadNoSettlPartyIDsGrpIdx
    let ci:SettlParties = {
        NoSettlPartyIDsGrp = noSettlPartyIDsGrp
    }
    ci


// group
let ReadNoOrdersGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoOrdersGrp =
    let clOrdID = ReadFieldIdxOrdered true bs index 11 ReadClOrdIDIdx
    let orderID = ReadOptionalFieldIdxOrdered true bs index 37 ReadOrderIDIdx
    let secondaryOrderID = ReadOptionalFieldIdxOrdered true bs index 198 ReadSecondaryOrderIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdxOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let listID = ReadOptionalFieldIdxOrdered true bs index 66 ReadListIDIdx
    let noNested2PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 756 ReadNoNested2PartyIDsGrpIdx
    let orderQty = ReadOptionalFieldIdxOrdered true bs index 38 ReadOrderQtyIdx
    let orderAvgPx = ReadOptionalFieldIdxOrdered true bs index 799 ReadOrderAvgPxIdx
    let orderBookingQty = ReadOptionalFieldIdxOrdered true bs index 800 ReadOrderBookingQtyIdx
    let ci:NoOrdersGrp = {
        ClOrdID = clOrdID
        OrderID = orderID
        SecondaryOrderID = secondaryOrderID
        SecondaryClOrdID = secondaryClOrdID
        ListID = listID
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
        OrderQty = orderQty
        OrderAvgPx = orderAvgPx
        OrderBookingQty = orderBookingQty
    }
    ci


// group
let ReadListStrikePriceNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : ListStrikePriceNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentIdxOrdered true bs index ReadUnderlyingInstrumentIdx
    let prevClosePx = ReadOptionalFieldIdxOrdered true bs index 140 ReadPrevClosePxIdx
    let clOrdID = ReadOptionalFieldIdxOrdered true bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdxOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let side = ReadOptionalFieldIdxOrdered true bs index 54 ReadSideIdx
    let price = ReadFieldIdxOrdered true bs index 44 ReadPriceIdx
    let currency = ReadOptionalFieldIdxOrdered true bs index 15 ReadCurrencyIdx
    let text = ReadOptionalFieldIdxOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdxOrdered true bs index 354 ReadEncodedTextIdx
    let ci:ListStrikePriceNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        PrevClosePx = prevClosePx
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        Side = side
        Price = price
        Currency = currency
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadNoSecurityAltIDGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSecurityAltIDGrp =
    let securityAltID = ReadFieldIdxOrdered true bs index 455 ReadSecurityAltIDIdx
    let securityAltIDSource = ReadOptionalFieldIdxOrdered true bs index 456 ReadSecurityAltIDSourceIdx
    let ci:NoSecurityAltIDGrp = {
        SecurityAltID = securityAltID
        SecurityAltIDSource = securityAltIDSource
    }
    ci


// group
let ReadNoEventsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoEventsGrp =
    let eventType = ReadFieldIdxOrdered true bs index 865 ReadEventTypeIdx
    let eventDate = ReadOptionalFieldIdxOrdered true bs index 866 ReadEventDateIdx
    let eventPx = ReadOptionalFieldIdxOrdered true bs index 867 ReadEventPxIdx
    let eventText = ReadOptionalFieldIdxOrdered true bs index 868 ReadEventTextIdx
    let ci:NoEventsGrp = {
        EventType = eventType
        EventDate = eventDate
        EventPx = eventPx
        EventText = eventText
    }
    ci


// component
let ReadInstrumentIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Instrument =
    let symbol = ReadFieldIdxOrdered true bs index 55 ReadSymbolIdx
    let symbolSfx = ReadOptionalFieldIdxOrdered true bs index 65 ReadSymbolSfxIdx
    let securityID = ReadOptionalFieldIdxOrdered true bs index 48 ReadSecurityIDIdx
    let securityIDSource = ReadOptionalFieldIdxOrdered true bs index 22 ReadSecurityIDSourceIdx
    let noSecurityAltIDGrpIdx = ReadOptionalGroupIdx bs index 454 ReadNoSecurityAltIDGrpIdx
    let product = ReadOptionalFieldIdxOrdered true bs index 460 ReadProductIdx
    let cFICode = ReadOptionalFieldIdxOrdered true bs index 461 ReadCFICodeIdx
    let securityType = ReadOptionalFieldIdxOrdered true bs index 167 ReadSecurityTypeIdx
    let securitySubType = ReadOptionalFieldIdxOrdered true bs index 762 ReadSecuritySubTypeIdx
    let maturityMonthYear = ReadOptionalFieldIdxOrdered true bs index 200 ReadMaturityMonthYearIdx
    let maturityDate = ReadOptionalFieldIdxOrdered true bs index 541 ReadMaturityDateIdx
    let putOrCall = ReadOptionalFieldIdxOrdered true bs index 201 ReadPutOrCallIdx
    let couponPaymentDate = ReadOptionalFieldIdxOrdered true bs index 224 ReadCouponPaymentDateIdx
    let issueDate = ReadOptionalFieldIdxOrdered true bs index 225 ReadIssueDateIdx
    let repoCollateralSecurityType = ReadOptionalFieldIdxOrdered true bs index 239 ReadRepoCollateralSecurityTypeIdx
    let repurchaseTerm = ReadOptionalFieldIdxOrdered true bs index 226 ReadRepurchaseTermIdx
    let repurchaseRate = ReadOptionalFieldIdxOrdered true bs index 227 ReadRepurchaseRateIdx
    let factor = ReadOptionalFieldIdxOrdered true bs index 228 ReadFactorIdx
    let creditRating = ReadOptionalFieldIdxOrdered true bs index 255 ReadCreditRatingIdx
    let instrRegistry = ReadOptionalFieldIdxOrdered true bs index 543 ReadInstrRegistryIdx
    let countryOfIssue = ReadOptionalFieldIdxOrdered true bs index 470 ReadCountryOfIssueIdx
    let stateOrProvinceOfIssue = ReadOptionalFieldIdxOrdered true bs index 471 ReadStateOrProvinceOfIssueIdx
    let localeOfIssue = ReadOptionalFieldIdxOrdered true bs index 472 ReadLocaleOfIssueIdx
    let redemptionDate = ReadOptionalFieldIdxOrdered true bs index 240 ReadRedemptionDateIdx
    let strikePrice = ReadOptionalFieldIdxOrdered true bs index 202 ReadStrikePriceIdx
    let strikeCurrency = ReadOptionalFieldIdxOrdered true bs index 947 ReadStrikeCurrencyIdx
    let optAttribute = ReadOptionalFieldIdxOrdered true bs index 206 ReadOptAttributeIdx
    let contractMultiplier = ReadOptionalFieldIdxOrdered true bs index 231 ReadContractMultiplierIdx
    let couponRate = ReadOptionalFieldIdxOrdered true bs index 223 ReadCouponRateIdx
    let securityExchange = ReadOptionalFieldIdxOrdered true bs index 207 ReadSecurityExchangeIdx
    let issuer = ReadOptionalFieldIdxOrdered true bs index 106 ReadIssuerIdx
    let encodedIssuer = ReadOptionalFieldIdxOrdered true bs index 348 ReadEncodedIssuerIdx
    let securityDesc = ReadOptionalFieldIdxOrdered true bs index 107 ReadSecurityDescIdx
    let encodedSecurityDesc = ReadOptionalFieldIdxOrdered true bs index 350 ReadEncodedSecurityDescIdx
    let pool = ReadOptionalFieldIdxOrdered true bs index 691 ReadPoolIdx
    let contractSettlMonth = ReadOptionalFieldIdxOrdered true bs index 667 ReadContractSettlMonthIdx
    let cPProgram = ReadOptionalFieldIdxOrdered true bs index 875 ReadCPProgramIdx
    let cPRegType = ReadOptionalFieldIdxOrdered true bs index 876 ReadCPRegTypeIdx
    let noEventsGrpIdx = ReadOptionalGroupIdx bs index 864 ReadNoEventsGrpIdx
    let datedDate = ReadOptionalFieldIdxOrdered true bs index 873 ReadDatedDateIdx
    let interestAccrualDate = ReadOptionalFieldIdxOrdered true bs index 874 ReadInterestAccrualDateIdx
    let ci:Instrument = {
        Symbol = symbol
        SymbolSfx = symbolSfx
        SecurityID = securityID
        SecurityIDSource = securityIDSource
        NoSecurityAltIDGrp = noSecurityAltIDGrp
        Product = product
        CFICode = cFICode
        SecurityType = securityType
        SecuritySubType = securitySubType
        MaturityMonthYear = maturityMonthYear
        MaturityDate = maturityDate
        PutOrCall = putOrCall
        CouponPaymentDate = couponPaymentDate
        IssueDate = issueDate
        RepoCollateralSecurityType = repoCollateralSecurityType
        RepurchaseTerm = repurchaseTerm
        RepurchaseRate = repurchaseRate
        Factor = factor
        CreditRating = creditRating
        InstrRegistry = instrRegistry
        CountryOfIssue = countryOfIssue
        StateOrProvinceOfIssue = stateOrProvinceOfIssue
        LocaleOfIssue = localeOfIssue
        RedemptionDate = redemptionDate
        StrikePrice = strikePrice
        StrikeCurrency = strikeCurrency
        OptAttribute = optAttribute
        ContractMultiplier = contractMultiplier
        CouponRate = couponRate
        SecurityExchange = securityExchange
        Issuer = issuer
        EncodedIssuer = encodedIssuer
        SecurityDesc = securityDesc
        EncodedSecurityDesc = encodedSecurityDesc
        Pool = pool
        ContractSettlMonth = contractSettlMonth
        CPProgram = cPProgram
        CPRegType = cPRegType
        NoEventsGrp = noEventsGrp
        DatedDate = datedDate
        InterestAccrualDate = interestAccrualDate
    }
    ci


// group
let ReadNoStrikesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoStrikesGrp =
    let instrument = ReadComponentIdxOrdered true bs index ReadInstrumentIdx
    let ci:NoStrikesGrp = {
        Instrument = instrument
    }
    ci


// group
let ReadNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoAllocsGrp =
    let allocAccount = ReadFieldIdxOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdxOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldIdxOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldIdxOrdered true bs index 467 ReadIndividualAllocIDIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let allocQty = ReadOptionalFieldIdxOrdered true bs index 80 ReadAllocQtyIdx
    let ci:NoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        AllocQty = allocQty
    }
    ci


// group
let ReadNoTradingSessionsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoTradingSessionsGrp =
    let tradingSessionID = ReadFieldIdxOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdxOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let ci:NoTradingSessionsGrp = {
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
    }
    ci


// group
let ReadNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentIdxOrdered true bs index ReadUnderlyingInstrumentIdx
    let ci:NoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
    }
    ci


// component
let ReadOrderQtyDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : OrderQtyData =
    let orderQty = ReadOptionalFieldIdxOrdered true bs index 38 ReadOrderQtyIdx
    let cashOrderQty = ReadOptionalFieldIdxOrdered true bs index 152 ReadCashOrderQtyIdx
    let orderPercent = ReadOptionalFieldIdxOrdered true bs index 516 ReadOrderPercentIdx
    let roundingDirection = ReadOptionalFieldIdxOrdered true bs index 468 ReadRoundingDirectionIdx
    let roundingModulus = ReadOptionalFieldIdxOrdered true bs index 469 ReadRoundingModulusIdx
    let ci:OrderQtyData = {
        OrderQty = orderQty
        CashOrderQty = cashOrderQty
        OrderPercent = orderPercent
        RoundingDirection = roundingDirection
        RoundingModulus = roundingModulus
    }
    ci


// component
let ReadSpreadOrBenchmarkCurveDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SpreadOrBenchmarkCurveData =
    let spread = ReadOptionalFieldIdxOrdered true bs index 218 ReadSpreadIdx
    let benchmarkCurveCurrency = ReadOptionalFieldIdxOrdered true bs index 220 ReadBenchmarkCurveCurrencyIdx
    let benchmarkCurveName = ReadOptionalFieldIdxOrdered true bs index 221 ReadBenchmarkCurveNameIdx
    let benchmarkCurvePoint = ReadOptionalFieldIdxOrdered true bs index 222 ReadBenchmarkCurvePointIdx
    let benchmarkPrice = ReadOptionalFieldIdxOrdered true bs index 662 ReadBenchmarkPriceIdx
    let benchmarkPriceType = ReadOptionalFieldIdxOrdered true bs index 663 ReadBenchmarkPriceTypeIdx
    let benchmarkSecurityID = ReadOptionalFieldIdxOrdered true bs index 699 ReadBenchmarkSecurityIDIdx
    let benchmarkSecurityIDSource = ReadOptionalFieldIdxOrdered true bs index 761 ReadBenchmarkSecurityIDSourceIdx
    let ci:SpreadOrBenchmarkCurveData = {
        Spread = spread
        BenchmarkCurveCurrency = benchmarkCurveCurrency
        BenchmarkCurveName = benchmarkCurveName
        BenchmarkCurvePoint = benchmarkCurvePoint
        BenchmarkPrice = benchmarkPrice
        BenchmarkPriceType = benchmarkPriceType
        BenchmarkSecurityID = benchmarkSecurityID
        BenchmarkSecurityIDSource = benchmarkSecurityIDSource
    }
    ci


// component
let ReadYieldDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : YieldData =
    let yieldType = ReadOptionalFieldIdxOrdered true bs index 235 ReadYieldTypeIdx
    let yyield = ReadOptionalFieldIdxOrdered true bs index 236 ReadYieldIdx
    let yieldCalcDate = ReadOptionalFieldIdxOrdered true bs index 701 ReadYieldCalcDateIdx
    let yieldRedemptionDate = ReadOptionalFieldIdxOrdered true bs index 696 ReadYieldRedemptionDateIdx
    let yieldRedemptionPrice = ReadOptionalFieldIdxOrdered true bs index 697 ReadYieldRedemptionPriceIdx
    let yieldRedemptionPriceType = ReadOptionalFieldIdxOrdered true bs index 698 ReadYieldRedemptionPriceTypeIdx
    let ci:YieldData = {
        YieldType = yieldType
        Yield = yyield
        YieldCalcDate = yieldCalcDate
        YieldRedemptionDate = yieldRedemptionDate
        YieldRedemptionPrice = yieldRedemptionPrice
        YieldRedemptionPriceType = yieldRedemptionPriceType
    }
    ci


// component
let ReadPegInstructionsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PegInstructions =
    let pegOffsetValue = ReadOptionalFieldIdxOrdered true bs index 211 ReadPegOffsetValueIdx
    let pegMoveType = ReadOptionalFieldIdxOrdered true bs index 835 ReadPegMoveTypeIdx
    let pegOffsetType = ReadOptionalFieldIdxOrdered true bs index 836 ReadPegOffsetTypeIdx
    let pegLimitType = ReadOptionalFieldIdxOrdered true bs index 837 ReadPegLimitTypeIdx
    let pegRoundDirection = ReadOptionalFieldIdxOrdered true bs index 838 ReadPegRoundDirectionIdx
    let pegScope = ReadOptionalFieldIdxOrdered true bs index 840 ReadPegScopeIdx
    let ci:PegInstructions = {
        PegOffsetValue = pegOffsetValue
        PegMoveType = pegMoveType
        PegOffsetType = pegOffsetType
        PegLimitType = pegLimitType
        PegRoundDirection = pegRoundDirection
        PegScope = pegScope
    }
    ci


// component
let ReadDiscretionInstructionsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : DiscretionInstructions =
    let discretionInst = ReadOptionalFieldIdxOrdered true bs index 388 ReadDiscretionInstIdx
    let discretionOffsetValue = ReadOptionalFieldIdxOrdered true bs index 389 ReadDiscretionOffsetValueIdx
    let discretionMoveType = ReadOptionalFieldIdxOrdered true bs index 841 ReadDiscretionMoveTypeIdx
    let discretionOffsetType = ReadOptionalFieldIdxOrdered true bs index 842 ReadDiscretionOffsetTypeIdx
    let discretionLimitType = ReadOptionalFieldIdxOrdered true bs index 843 ReadDiscretionLimitTypeIdx
    let discretionRoundDirection = ReadOptionalFieldIdxOrdered true bs index 844 ReadDiscretionRoundDirectionIdx
    let discretionScope = ReadOptionalFieldIdxOrdered true bs index 846 ReadDiscretionScopeIdx
    let ci:DiscretionInstructions = {
        DiscretionInst = discretionInst
        DiscretionOffsetValue = discretionOffsetValue
        DiscretionMoveType = discretionMoveType
        DiscretionOffsetType = discretionOffsetType
        DiscretionLimitType = discretionLimitType
        DiscretionRoundDirection = discretionRoundDirection
        DiscretionScope = discretionScope
    }
    ci


// group
let ReadNewOrderListNoOrdersGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NewOrderListNoOrdersGrp =
    let clOrdID = ReadFieldIdxOrdered true bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdxOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let listSeqNo = ReadFieldIdxOrdered true bs index 67 ReadListSeqNoIdx
    let clOrdLinkID = ReadOptionalFieldIdxOrdered true bs index 583 ReadClOrdLinkIDIdx
    let settlInstMode = ReadOptionalFieldIdxOrdered true bs index 160 ReadSettlInstModeIdx
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let tradeOriginationDate = ReadOptionalFieldIdxOrdered true bs index 229 ReadTradeOriginationDateIdx
    let tradeDate = ReadOptionalFieldIdxOrdered true bs index 75 ReadTradeDateIdx
    let account = ReadOptionalFieldIdxOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdxOrdered true bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldIdxOrdered true bs index 581 ReadAccountTypeIdx
    let dayBookingInst = ReadOptionalFieldIdxOrdered true bs index 589 ReadDayBookingInstIdx
    let bookingUnit = ReadOptionalFieldIdxOrdered true bs index 590 ReadBookingUnitIdx
    let allocID = ReadOptionalFieldIdxOrdered true bs index 70 ReadAllocIDIdx
    let preallocMethod = ReadOptionalFieldIdxOrdered true bs index 591 ReadPreallocMethodIdx
    let noAllocsGrpIdx = ReadOptionalGroupIdx bs index 78 ReadNoAllocsGrpIdx
    let settlType = ReadOptionalFieldIdxOrdered true bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldIdxOrdered true bs index 64 ReadSettlDateIdx
    let cashMargin = ReadOptionalFieldIdxOrdered true bs index 544 ReadCashMarginIdx
    let clearingFeeIndicator = ReadOptionalFieldIdxOrdered true bs index 635 ReadClearingFeeIndicatorIdx
    let handlInst = ReadOptionalFieldIdxOrdered true bs index 21 ReadHandlInstIdx
    let execInst = ReadOptionalFieldIdxOrdered true bs index 18 ReadExecInstIdx
    let minQty = ReadOptionalFieldIdxOrdered true bs index 110 ReadMinQtyIdx
    let maxFloor = ReadOptionalFieldIdxOrdered true bs index 111 ReadMaxFloorIdx
    let exDestination = ReadOptionalFieldIdxOrdered true bs index 100 ReadExDestinationIdx
    let noTradingSessionsGrpIdx = ReadOptionalGroupIdx bs index 386 ReadNoTradingSessionsGrpIdx
    let processCode = ReadOptionalFieldIdxOrdered true bs index 81 ReadProcessCodeIdx
    let instrument = ReadComponentIdxOrdered true bs index ReadInstrumentIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let prevClosePx = ReadOptionalFieldIdxOrdered true bs index 140 ReadPrevClosePxIdx
    let side = ReadFieldIdxOrdered true bs index 54 ReadSideIdx
    let sideValueInd = ReadOptionalFieldIdxOrdered true bs index 401 ReadSideValueIndIdx
    let locateReqd = ReadOptionalFieldIdxOrdered true bs index 114 ReadLocateReqdIdx
    let transactTime = ReadOptionalFieldIdxOrdered true bs index 60 ReadTransactTimeIdx
    let noStipulationsGrpIdx = ReadOptionalGroupIdx bs index 232 ReadNoStipulationsGrpIdx
    let qtyType = ReadOptionalFieldIdxOrdered true bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentIdxOrdered true bs index ReadOrderQtyDataIdx
    let ordType = ReadOptionalFieldIdxOrdered true bs index 40 ReadOrdTypeIdx
    let priceType = ReadOptionalFieldIdxOrdered true bs index 423 ReadPriceTypeIdx
    let price = ReadOptionalFieldIdxOrdered true bs index 44 ReadPriceIdx
    let stopPx = ReadOptionalFieldIdxOrdered true bs index 99 ReadStopPxIdx
    let spreadOrBenchmarkCurveData = ReadComponentIdxOrdered true bs index ReadSpreadOrBenchmarkCurveDataIdx
    let yieldData = ReadComponentIdxOrdered true bs index ReadYieldDataIdx
    let currency = ReadOptionalFieldIdxOrdered true bs index 15 ReadCurrencyIdx
    let complianceID = ReadOptionalFieldIdxOrdered true bs index 376 ReadComplianceIDIdx
    let solicitedFlag = ReadOptionalFieldIdxOrdered true bs index 377 ReadSolicitedFlagIdx
    let iOIid = ReadOptionalFieldIdxOrdered true bs index 23 ReadIOIidIdx
    let quoteID = ReadOptionalFieldIdxOrdered true bs index 117 ReadQuoteIDIdx
    let timeInForce = ReadOptionalFieldIdxOrdered true bs index 59 ReadTimeInForceIdx
    let effectiveTime = ReadOptionalFieldIdxOrdered true bs index 168 ReadEffectiveTimeIdx
    let expireDate = ReadOptionalFieldIdxOrdered true bs index 432 ReadExpireDateIdx
    let expireTime = ReadOptionalFieldIdxOrdered true bs index 126 ReadExpireTimeIdx
    let gTBookingInst = ReadOptionalFieldIdxOrdered true bs index 427 ReadGTBookingInstIdx
    let commissionData = ReadComponentIdxOrdered true bs index ReadCommissionDataIdx
    let orderCapacity = ReadOptionalFieldIdxOrdered true bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldIdxOrdered true bs index 529 ReadOrderRestrictionsIdx
    let custOrderCapacity = ReadOptionalFieldIdxOrdered true bs index 582 ReadCustOrderCapacityIdx
    let forexReq = ReadOptionalFieldIdxOrdered true bs index 121 ReadForexReqIdx
    let settlCurrency = ReadOptionalFieldIdxOrdered true bs index 120 ReadSettlCurrencyIdx
    let bookingType = ReadOptionalFieldIdxOrdered true bs index 775 ReadBookingTypeIdx
    let text = ReadOptionalFieldIdxOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdxOrdered true bs index 354 ReadEncodedTextIdx
    let settlDate2 = ReadOptionalFieldIdxOrdered true bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldIdxOrdered true bs index 192 ReadOrderQty2Idx
    let price2 = ReadOptionalFieldIdxOrdered true bs index 640 ReadPrice2Idx
    let positionEffect = ReadOptionalFieldIdxOrdered true bs index 77 ReadPositionEffectIdx
    let coveredOrUncovered = ReadOptionalFieldIdxOrdered true bs index 203 ReadCoveredOrUncoveredIdx
    let maxShow = ReadOptionalFieldIdxOrdered true bs index 210 ReadMaxShowIdx
    let pegInstructions = ReadComponentIdxOrdered true bs index ReadPegInstructionsIdx
    let discretionInstructions = ReadComponentIdxOrdered true bs index ReadDiscretionInstructionsIdx
    let targetStrategy = ReadOptionalFieldIdxOrdered true bs index 847 ReadTargetStrategyIdx
    let targetStrategyParameters = ReadOptionalFieldIdxOrdered true bs index 848 ReadTargetStrategyParametersIdx
    let participationRate = ReadOptionalFieldIdxOrdered true bs index 849 ReadParticipationRateIdx
    let designation = ReadOptionalFieldIdxOrdered true bs index 494 ReadDesignationIdx
    let ci:NewOrderListNoOrdersGrp = {
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        ListSeqNo = listSeqNo
        ClOrdLinkID = clOrdLinkID
        SettlInstMode = settlInstMode
        NoPartyIDsGrp = noPartyIDsGrp
        TradeOriginationDate = tradeOriginationDate
        TradeDate = tradeDate
        Account = account
        AcctIDSource = acctIDSource
        AccountType = accountType
        DayBookingInst = dayBookingInst
        BookingUnit = bookingUnit
        AllocID = allocID
        PreallocMethod = preallocMethod
        NoAllocsGrp = noAllocsGrp
        SettlType = settlType
        SettlDate = settlDate
        CashMargin = cashMargin
        ClearingFeeIndicator = clearingFeeIndicator
        HandlInst = handlInst
        ExecInst = execInst
        MinQty = minQty
        MaxFloor = maxFloor
        ExDestination = exDestination
        NoTradingSessionsGrp = noTradingSessionsGrp
        ProcessCode = processCode
        Instrument = instrument
        NoUnderlyingsGrp = noUnderlyingsGrp
        PrevClosePx = prevClosePx
        Side = side
        SideValueInd = sideValueInd
        LocateReqd = locateReqd
        TransactTime = transactTime
        NoStipulationsGrp = noStipulationsGrp
        QtyType = qtyType
        OrderQtyData = orderQtyData
        OrdType = ordType
        PriceType = priceType
        Price = price
        StopPx = stopPx
        SpreadOrBenchmarkCurveData = spreadOrBenchmarkCurveData
        YieldData = yieldData
        Currency = currency
        ComplianceID = complianceID
        SolicitedFlag = solicitedFlag
        IOIid = iOIid
        QuoteID = quoteID
        TimeInForce = timeInForce
        EffectiveTime = effectiveTime
        ExpireDate = expireDate
        ExpireTime = expireTime
        GTBookingInst = gTBookingInst
        CommissionData = commissionData
        OrderCapacity = orderCapacity
        OrderRestrictions = orderRestrictions
        CustOrderCapacity = custOrderCapacity
        ForexReq = forexReq
        SettlCurrency = settlCurrency
        BookingType = bookingType
        Text = text
        EncodedText = encodedText
        SettlDate2 = settlDate2
        OrderQty2 = orderQty2
        Price2 = price2
        PositionEffect = positionEffect
        CoveredOrUncovered = coveredOrUncovered
        MaxShow = maxShow
        PegInstructions = pegInstructions
        DiscretionInstructions = discretionInstructions
        TargetStrategy = targetStrategy
        TargetStrategyParameters = targetStrategyParameters
        ParticipationRate = participationRate
        Designation = designation
    }
    ci


// component
let ReadCommissionDataFGIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CommissionDataFG =
    let commission = ReadFieldIdxOrdered true bs index 12 ReadCommissionIdx
    let commType = ReadOptionalFieldIdxOrdered true bs index 13 ReadCommTypeIdx
    let commCurrency = ReadOptionalFieldIdxOrdered true bs index 479 ReadCommCurrencyIdx
    let fundRenewWaiv = ReadOptionalFieldIdxOrdered true bs index 497 ReadFundRenewWaivIdx
    let ci:CommissionDataFG = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    ci


// group
let ReadBidResponseNoBidComponentsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : BidResponseNoBidComponentsGrp =
    let commissionDataFG = ReadComponentIdxOrdered true bs index ReadCommissionDataFGIdx
    let listID = ReadOptionalFieldIdxOrdered true bs index 66 ReadListIDIdx
    let country = ReadOptionalFieldIdxOrdered true bs index 421 ReadCountryIdx
    let side = ReadOptionalFieldIdxOrdered true bs index 54 ReadSideIdx
    let price = ReadOptionalFieldIdxOrdered true bs index 44 ReadPriceIdx
    let priceType = ReadOptionalFieldIdxOrdered true bs index 423 ReadPriceTypeIdx
    let fairValue = ReadOptionalFieldIdxOrdered true bs index 406 ReadFairValueIdx
    let netGrossInd = ReadOptionalFieldIdxOrdered true bs index 430 ReadNetGrossIndIdx
    let settlType = ReadOptionalFieldIdxOrdered true bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldIdxOrdered true bs index 64 ReadSettlDateIdx
    let tradingSessionID = ReadOptionalFieldIdxOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdxOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let text = ReadOptionalFieldIdxOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdxOrdered true bs index 354 ReadEncodedTextIdx
    let ci:BidResponseNoBidComponentsGrp = {
        CommissionDataFG = commissionDataFG
        ListID = listID
        Country = country
        Side = side
        Price = price
        PriceType = priceType
        FairValue = fairValue
        NetGrossInd = netGrossInd
        SettlType = settlType
        SettlDate = settlDate
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadNoLegAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoLegAllocsGrp =
    let legAllocAccount = ReadFieldIdxOrdered true bs index 671 ReadLegAllocAccountIdx
    let legIndividualAllocID = ReadOptionalFieldIdxOrdered true bs index 672 ReadLegIndividualAllocIDIdx
    let noNested2PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 756 ReadNoNested2PartyIDsGrpIdx
    let legAllocQty = ReadOptionalFieldIdxOrdered true bs index 673 ReadLegAllocQtyIdx
    let legAllocAcctIDSource = ReadOptionalFieldIdxOrdered true bs index 674 ReadLegAllocAcctIDSourceIdx
    let legSettlCurrency = ReadOptionalFieldIdxOrdered true bs index 675 ReadLegSettlCurrencyIdx
    let ci:NoLegAllocsGrp = {
        LegAllocAccount = legAllocAccount
        LegIndividualAllocID = legIndividualAllocID
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
        LegAllocQty = legAllocQty
        LegAllocAcctIDSource = legAllocAcctIDSource
        LegSettlCurrency = legSettlCurrency
    }
    ci


// group
let ReadMultilegOrderCancelReplaceRequestNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MultilegOrderCancelReplaceRequestNoLegsGrp =
    let instrumentLegFG = ReadComponentIdxOrdered true bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdxOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdxOrdered true bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let noLegAllocsGrpIdx = ReadOptionalGroupIdx bs index 670 ReadNoLegAllocsGrpIdx
    let legPositionEffect = ReadOptionalFieldIdxOrdered true bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldIdxOrdered true bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldIdxOrdered true bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldIdxOrdered true bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldIdxOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdxOrdered true bs index 588 ReadLegSettlDateIdx
    let ci:MultilegOrderCancelReplaceRequestNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoLegAllocsGrp = noLegAllocsGrp
        LegPositionEffect = legPositionEffect
        LegCoveredOrUncovered = legCoveredOrUncovered
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegRefID = legRefID
        LegPrice = legPrice
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
    }
    ci


// group
let ReadNoNested3PartySubIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNested3PartySubIDsGrp =
    let nested3PartySubID = ReadFieldIdxOrdered true bs index 953 ReadNested3PartySubIDIdx
    let nested3PartySubIDType = ReadOptionalFieldIdxOrdered true bs index 954 ReadNested3PartySubIDTypeIdx
    let ci:NoNested3PartySubIDsGrp = {
        Nested3PartySubID = nested3PartySubID
        Nested3PartySubIDType = nested3PartySubIDType
    }
    ci


// group
let ReadNoNested3PartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNested3PartyIDsGrp =
    let nested3PartyID = ReadFieldIdxOrdered true bs index 949 ReadNested3PartyIDIdx
    let nested3PartyIDSource = ReadOptionalFieldIdxOrdered true bs index 950 ReadNested3PartyIDSourceIdx
    let nested3PartyRole = ReadOptionalFieldIdxOrdered true bs index 951 ReadNested3PartyRoleIdx
    let noNested3PartySubIDsGrpIdx = ReadOptionalGroupIdx bs index 952 ReadNoNested3PartySubIDsGrpIdx
    let ci:NoNested3PartyIDsGrp = {
        Nested3PartyID = nested3PartyID
        Nested3PartyIDSource = nested3PartyIDSource
        Nested3PartyRole = nested3PartyRole
        NoNested3PartySubIDsGrp = noNested3PartySubIDsGrp
    }
    ci


// group
let ReadMultilegOrderCancelReplaceRequestNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MultilegOrderCancelReplaceRequestNoAllocsGrp =
    let allocAccount = ReadFieldIdxOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdxOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldIdxOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldIdxOrdered true bs index 467 ReadIndividualAllocIDIdx
    let noNested3PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 948 ReadNoNested3PartyIDsGrpIdx
    let allocQty = ReadOptionalFieldIdxOrdered true bs index 80 ReadAllocQtyIdx
    let ci:MultilegOrderCancelReplaceRequestNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNested3PartyIDsGrp = noNested3PartyIDsGrp
        AllocQty = allocQty
    }
    ci


// group
let ReadNewOrderMultilegNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NewOrderMultilegNoLegsGrp =
    let instrumentLegFG = ReadComponentIdxOrdered true bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdxOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdxOrdered true bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let noLegAllocsGrpIdx = ReadOptionalGroupIdx bs index 670 ReadNoLegAllocsGrpIdx
    let legPositionEffect = ReadOptionalFieldIdxOrdered true bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldIdxOrdered true bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldIdxOrdered true bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldIdxOrdered true bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldIdxOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdxOrdered true bs index 588 ReadLegSettlDateIdx
    let ci:NewOrderMultilegNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoLegAllocsGrp = noLegAllocsGrp
        LegPositionEffect = legPositionEffect
        LegCoveredOrUncovered = legCoveredOrUncovered
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegRefID = legRefID
        LegPrice = legPrice
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
    }
    ci


// component
let ReadNestedParties2Idx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties2 =
    let noNested2PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 756 ReadNoNested2PartyIDsGrpIdx
    let ci:NestedParties2 = {
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
    }
    ci


// group
let ReadNewOrderMultilegNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NewOrderMultilegNoAllocsGrp =
    let allocAccount = ReadFieldIdxOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdxOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldIdxOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldIdxOrdered true bs index 467 ReadIndividualAllocIDIdx
    let noNested3PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 948 ReadNoNested3PartyIDsGrpIdx
    let allocQty = ReadOptionalFieldIdxOrdered true bs index 80 ReadAllocQtyIdx
    let ci:NewOrderMultilegNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNested3PartyIDsGrp = noNested3PartyIDsGrp
        AllocQty = allocQty
    }
    ci


// component
let ReadNestedParties3Idx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties3 =
    let noNested3PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 948 ReadNoNested3PartyIDsGrpIdx
    let ci:NestedParties3 = {
        NoNested3PartyIDsGrp = noNested3PartyIDsGrp
    }
    ci


// group
let ReadCrossOrderCancelRequestNoSidesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CrossOrderCancelRequestNoSidesGrp =
    let side = ReadFieldIdxOrdered true bs index 54 ReadSideIdx
    let origClOrdID = ReadFieldIdxOrdered true bs index 41 ReadOrigClOrdIDIdx
    let clOrdID = ReadFieldIdxOrdered true bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdxOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let clOrdLinkID = ReadOptionalFieldIdxOrdered true bs index 583 ReadClOrdLinkIDIdx
    let origOrdModTime = ReadOptionalFieldIdxOrdered true bs index 586 ReadOrigOrdModTimeIdx
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let tradeOriginationDate = ReadOptionalFieldIdxOrdered true bs index 229 ReadTradeOriginationDateIdx
    let tradeDate = ReadOptionalFieldIdxOrdered true bs index 75 ReadTradeDateIdx
    let orderQtyData = ReadComponentIdxOrdered true bs index ReadOrderQtyDataIdx
    let complianceID = ReadOptionalFieldIdxOrdered true bs index 376 ReadComplianceIDIdx
    let text = ReadOptionalFieldIdxOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdxOrdered true bs index 354 ReadEncodedTextIdx
    let ci:CrossOrderCancelRequestNoSidesGrp = {
        Side = side
        OrigClOrdID = origClOrdID
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        ClOrdLinkID = clOrdLinkID
        OrigOrdModTime = origOrdModTime
        NoPartyIDsGrp = noPartyIDsGrp
        TradeOriginationDate = tradeOriginationDate
        TradeDate = tradeDate
        OrderQtyData = orderQtyData
        ComplianceID = complianceID
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadCrossOrderCancelReplaceRequestNoSidesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CrossOrderCancelReplaceRequestNoSidesGrp =
    let side = ReadFieldIdxOrdered true bs index 54 ReadSideIdx
    let origClOrdID = ReadFieldIdxOrdered true bs index 41 ReadOrigClOrdIDIdx
    let clOrdID = ReadFieldIdxOrdered true bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdxOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let clOrdLinkID = ReadOptionalFieldIdxOrdered true bs index 583 ReadClOrdLinkIDIdx
    let origOrdModTime = ReadOptionalFieldIdxOrdered true bs index 586 ReadOrigOrdModTimeIdx
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let tradeOriginationDate = ReadOptionalFieldIdxOrdered true bs index 229 ReadTradeOriginationDateIdx
    let tradeDate = ReadOptionalFieldIdxOrdered true bs index 75 ReadTradeDateIdx
    let account = ReadOptionalFieldIdxOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdxOrdered true bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldIdxOrdered true bs index 581 ReadAccountTypeIdx
    let dayBookingInst = ReadOptionalFieldIdxOrdered true bs index 589 ReadDayBookingInstIdx
    let bookingUnit = ReadOptionalFieldIdxOrdered true bs index 590 ReadBookingUnitIdx
    let preallocMethod = ReadOptionalFieldIdxOrdered true bs index 591 ReadPreallocMethodIdx
    let allocID = ReadOptionalFieldIdxOrdered true bs index 70 ReadAllocIDIdx
    let noAllocsGrpIdx = ReadOptionalGroupIdx bs index 78 ReadNoAllocsGrpIdx
    let qtyType = ReadOptionalFieldIdxOrdered true bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentIdxOrdered true bs index ReadOrderQtyDataIdx
    let commissionData = ReadComponentIdxOrdered true bs index ReadCommissionDataIdx
    let orderCapacity = ReadOptionalFieldIdxOrdered true bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldIdxOrdered true bs index 529 ReadOrderRestrictionsIdx
    let custOrderCapacity = ReadOptionalFieldIdxOrdered true bs index 582 ReadCustOrderCapacityIdx
    let forexReq = ReadOptionalFieldIdxOrdered true bs index 121 ReadForexReqIdx
    let settlCurrency = ReadOptionalFieldIdxOrdered true bs index 120 ReadSettlCurrencyIdx
    let bookingType = ReadOptionalFieldIdxOrdered true bs index 775 ReadBookingTypeIdx
    let text = ReadOptionalFieldIdxOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdxOrdered true bs index 354 ReadEncodedTextIdx
    let positionEffect = ReadOptionalFieldIdxOrdered true bs index 77 ReadPositionEffectIdx
    let coveredOrUncovered = ReadOptionalFieldIdxOrdered true bs index 203 ReadCoveredOrUncoveredIdx
    let cashMargin = ReadOptionalFieldIdxOrdered true bs index 544 ReadCashMarginIdx
    let clearingFeeIndicator = ReadOptionalFieldIdxOrdered true bs index 635 ReadClearingFeeIndicatorIdx
    let solicitedFlag = ReadOptionalFieldIdxOrdered true bs index 377 ReadSolicitedFlagIdx
    let sideComplianceID = ReadOptionalFieldIdxOrdered true bs index 659 ReadSideComplianceIDIdx
    let ci:CrossOrderCancelReplaceRequestNoSidesGrp = {
        Side = side
        OrigClOrdID = origClOrdID
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        ClOrdLinkID = clOrdLinkID
        OrigOrdModTime = origOrdModTime
        NoPartyIDsGrp = noPartyIDsGrp
        TradeOriginationDate = tradeOriginationDate
        TradeDate = tradeDate
        Account = account
        AcctIDSource = acctIDSource
        AccountType = accountType
        DayBookingInst = dayBookingInst
        BookingUnit = bookingUnit
        PreallocMethod = preallocMethod
        AllocID = allocID
        NoAllocsGrp = noAllocsGrp
        QtyType = qtyType
        OrderQtyData = orderQtyData
        CommissionData = commissionData
        OrderCapacity = orderCapacity
        OrderRestrictions = orderRestrictions
        CustOrderCapacity = custOrderCapacity
        ForexReq = forexReq
        SettlCurrency = settlCurrency
        BookingType = bookingType
        Text = text
        EncodedText = encodedText
        PositionEffect = positionEffect
        CoveredOrUncovered = coveredOrUncovered
        CashMargin = cashMargin
        ClearingFeeIndicator = clearingFeeIndicator
        SolicitedFlag = solicitedFlag
        SideComplianceID = sideComplianceID
    }
    ci


// group
let ReadNoSidesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSidesGrp =
    let side = ReadFieldIdxOrdered true bs index 54 ReadSideIdx
    let clOrdID = ReadFieldIdxOrdered true bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdxOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let clOrdLinkID = ReadOptionalFieldIdxOrdered true bs index 583 ReadClOrdLinkIDIdx
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let tradeOriginationDate = ReadOptionalFieldIdxOrdered true bs index 229 ReadTradeOriginationDateIdx
    let tradeDate = ReadOptionalFieldIdxOrdered true bs index 75 ReadTradeDateIdx
    let account = ReadOptionalFieldIdxOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdxOrdered true bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldIdxOrdered true bs index 581 ReadAccountTypeIdx
    let dayBookingInst = ReadOptionalFieldIdxOrdered true bs index 589 ReadDayBookingInstIdx
    let bookingUnit = ReadOptionalFieldIdxOrdered true bs index 590 ReadBookingUnitIdx
    let preallocMethod = ReadOptionalFieldIdxOrdered true bs index 591 ReadPreallocMethodIdx
    let allocID = ReadOptionalFieldIdxOrdered true bs index 70 ReadAllocIDIdx
    let noAllocsGrpIdx = ReadOptionalGroupIdx bs index 78 ReadNoAllocsGrpIdx
    let qtyType = ReadOptionalFieldIdxOrdered true bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentIdxOrdered true bs index ReadOrderQtyDataIdx
    let commissionData = ReadComponentIdxOrdered true bs index ReadCommissionDataIdx
    let orderCapacity = ReadOptionalFieldIdxOrdered true bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldIdxOrdered true bs index 529 ReadOrderRestrictionsIdx
    let custOrderCapacity = ReadOptionalFieldIdxOrdered true bs index 582 ReadCustOrderCapacityIdx
    let forexReq = ReadOptionalFieldIdxOrdered true bs index 121 ReadForexReqIdx
    let settlCurrency = ReadOptionalFieldIdxOrdered true bs index 120 ReadSettlCurrencyIdx
    let bookingType = ReadOptionalFieldIdxOrdered true bs index 775 ReadBookingTypeIdx
    let text = ReadOptionalFieldIdxOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdxOrdered true bs index 354 ReadEncodedTextIdx
    let positionEffect = ReadOptionalFieldIdxOrdered true bs index 77 ReadPositionEffectIdx
    let coveredOrUncovered = ReadOptionalFieldIdxOrdered true bs index 203 ReadCoveredOrUncoveredIdx
    let cashMargin = ReadOptionalFieldIdxOrdered true bs index 544 ReadCashMarginIdx
    let clearingFeeIndicator = ReadOptionalFieldIdxOrdered true bs index 635 ReadClearingFeeIndicatorIdx
    let solicitedFlag = ReadOptionalFieldIdxOrdered true bs index 377 ReadSolicitedFlagIdx
    let sideComplianceID = ReadOptionalFieldIdxOrdered true bs index 659 ReadSideComplianceIDIdx
    let ci:NoSidesGrp = {
        Side = side
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        ClOrdLinkID = clOrdLinkID
        NoPartyIDsGrp = noPartyIDsGrp
        TradeOriginationDate = tradeOriginationDate
        TradeDate = tradeDate
        Account = account
        AcctIDSource = acctIDSource
        AccountType = accountType
        DayBookingInst = dayBookingInst
        BookingUnit = bookingUnit
        PreallocMethod = preallocMethod
        AllocID = allocID
        NoAllocsGrp = noAllocsGrp
        QtyType = qtyType
        OrderQtyData = orderQtyData
        CommissionData = commissionData
        OrderCapacity = orderCapacity
        OrderRestrictions = orderRestrictions
        CustOrderCapacity = custOrderCapacity
        ForexReq = forexReq
        SettlCurrency = settlCurrency
        BookingType = bookingType
        Text = text
        EncodedText = encodedText
        PositionEffect = positionEffect
        CoveredOrUncovered = coveredOrUncovered
        CashMargin = cashMargin
        ClearingFeeIndicator = clearingFeeIndicator
        SolicitedFlag = solicitedFlag
        SideComplianceID = sideComplianceID
    }
    ci


// group
let ReadExecutionReportNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : ExecutionReportNoLegsGrp =
    let instrumentLegFG = ReadComponentIdxOrdered true bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdxOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdxOrdered true bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let legPositionEffect = ReadOptionalFieldIdxOrdered true bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldIdxOrdered true bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldIdxOrdered true bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldIdxOrdered true bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldIdxOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdxOrdered true bs index 588 ReadLegSettlDateIdx
    let legLastPx = ReadOptionalFieldIdxOrdered true bs index 637 ReadLegLastPxIdx
    let ci:ExecutionReportNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        NoLegStipulationsGrp = noLegStipulationsGrp
        LegPositionEffect = legPositionEffect
        LegCoveredOrUncovered = legCoveredOrUncovered
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegRefID = legRefID
        LegPrice = legPrice
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        LegLastPx = legLastPx
    }
    ci


// group
let ReadNoInstrAttribGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoInstrAttribGrp =
    let instrAttribType = ReadFieldIdxOrdered true bs index 871 ReadInstrAttribTypeIdx
    let instrAttribValue = ReadOptionalFieldIdxOrdered true bs index 872 ReadInstrAttribValueIdx
    let ci:NoInstrAttribGrp = {
        InstrAttribType = instrAttribType
        InstrAttribValue = instrAttribValue
    }
    ci


// component
let ReadInstrumentExtensionIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentExtension =
    let deliveryForm = ReadOptionalFieldIdxOrdered true bs index 668 ReadDeliveryFormIdx
    let pctAtRisk = ReadOptionalFieldIdxOrdered true bs index 869 ReadPctAtRiskIdx
    let noInstrAttribGrpIdx = ReadOptionalGroupIdx bs index 870 ReadNoInstrAttribGrpIdx
    let ci:InstrumentExtension = {
        DeliveryForm = deliveryForm
        PctAtRisk = pctAtRisk
        NoInstrAttribGrp = noInstrAttribGrp
    }
    ci


// group
let ReadNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoLegsGrp =
    let instrumentLegFG = ReadComponentIdxOrdered true bs index ReadInstrumentLegFGIdx
    let ci:NoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
    }
    ci


// group
let ReadDerivativeSecurityListNoRelatedSymGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : DerivativeSecurityListNoRelatedSymGrp =
    let instrument = ReadComponentIdxOrdered true bs index ReadInstrumentIdx
    let currency = ReadOptionalFieldIdxOrdered true bs index 15 ReadCurrencyIdx
    let expirationCycle = ReadOptionalFieldIdxOrdered true bs index 827 ReadExpirationCycleIdx
    let instrumentExtension = ReadComponentIdxOrdered true bs index ReadInstrumentExtensionIdx
    let noLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadNoLegsGrpIdx
    let tradingSessionID = ReadOptionalFieldIdxOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdxOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let text = ReadOptionalFieldIdxOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdxOrdered true bs index 354 ReadEncodedTextIdx
    let ci:DerivativeSecurityListNoRelatedSymGrp = {
        Instrument = instrument
        Currency = currency
        ExpirationCycle = expirationCycle
        InstrumentExtension = instrumentExtension
        NoLegsGrp = noLegsGrp
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        Text = text
        EncodedText = encodedText
    }
    ci


// component
let ReadFinancingDetailsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : FinancingDetails =
    let agreementDesc = ReadOptionalFieldIdxOrdered true bs index 913 ReadAgreementDescIdx
    let agreementID = ReadOptionalFieldIdxOrdered true bs index 914 ReadAgreementIDIdx
    let agreementDate = ReadOptionalFieldIdxOrdered true bs index 915 ReadAgreementDateIdx
    let agreementCurrency = ReadOptionalFieldIdxOrdered true bs index 918 ReadAgreementCurrencyIdx
    let terminationType = ReadOptionalFieldIdxOrdered true bs index 788 ReadTerminationTypeIdx
    let startDate = ReadOptionalFieldIdxOrdered true bs index 916 ReadStartDateIdx
    let endDate = ReadOptionalFieldIdxOrdered true bs index 917 ReadEndDateIdx
    let deliveryType = ReadOptionalFieldIdxOrdered true bs index 919 ReadDeliveryTypeIdx
    let marginRatio = ReadOptionalFieldIdxOrdered true bs index 898 ReadMarginRatioIdx
    let ci:FinancingDetails = {
        AgreementDesc = agreementDesc
        AgreementID = agreementID
        AgreementDate = agreementDate
        AgreementCurrency = agreementCurrency
        TerminationType = terminationType
        StartDate = startDate
        EndDate = endDate
        DeliveryType = deliveryType
        MarginRatio = marginRatio
    }
    ci


// component
let ReadLegBenchmarkCurveDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LegBenchmarkCurveData =
    let legBenchmarkCurveCurrency = ReadOptionalFieldIdxOrdered true bs index 676 ReadLegBenchmarkCurveCurrencyIdx
    let legBenchmarkCurveName = ReadOptionalFieldIdxOrdered true bs index 677 ReadLegBenchmarkCurveNameIdx
    let legBenchmarkCurvePoint = ReadOptionalFieldIdxOrdered true bs index 678 ReadLegBenchmarkCurvePointIdx
    let legBenchmarkPrice = ReadOptionalFieldIdxOrdered true bs index 679 ReadLegBenchmarkPriceIdx
    let legBenchmarkPriceType = ReadOptionalFieldIdxOrdered true bs index 680 ReadLegBenchmarkPriceTypeIdx
    let ci:LegBenchmarkCurveData = {
        LegBenchmarkCurveCurrency = legBenchmarkCurveCurrency
        LegBenchmarkCurveName = legBenchmarkCurveName
        LegBenchmarkCurvePoint = legBenchmarkCurvePoint
        LegBenchmarkPrice = legBenchmarkPrice
        LegBenchmarkPriceType = legBenchmarkPriceType
    }
    ci


// group
let ReadSecurityListNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SecurityListNoLegsGrp =
    let instrumentLegFG = ReadComponentIdxOrdered true bs index ReadInstrumentLegFGIdx
    let legSwapType = ReadOptionalFieldIdxOrdered true bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldIdxOrdered true bs index 587 ReadLegSettlTypeIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let legBenchmarkCurveData = ReadComponentIdxOrdered true bs index ReadLegBenchmarkCurveDataIdx
    let ci:SecurityListNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        NoLegStipulationsGrp = noLegStipulationsGrp
        LegBenchmarkCurveData = legBenchmarkCurveData
    }
    ci


// group
let ReadSecurityListNoRelatedSymGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SecurityListNoRelatedSymGrp =
    let instrument = ReadComponentIdxOrdered true bs index ReadInstrumentIdx
    let instrumentExtension = ReadComponentIdxOrdered true bs index ReadInstrumentExtensionIdx
    let financingDetails = ReadComponentIdxOrdered true bs index ReadFinancingDetailsIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let currency = ReadOptionalFieldIdxOrdered true bs index 15 ReadCurrencyIdx
    let noStipulationsGrpIdx = ReadOptionalGroupIdx bs index 232 ReadNoStipulationsGrpIdx
    let securityListNoLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadSecurityListNoLegsGrpIdx
    let spreadOrBenchmarkCurveData = ReadComponentIdxOrdered true bs index ReadSpreadOrBenchmarkCurveDataIdx
    let yieldData = ReadComponentIdxOrdered true bs index ReadYieldDataIdx
    let roundLot = ReadOptionalFieldIdxOrdered true bs index 561 ReadRoundLotIdx
    let minTradeVol = ReadOptionalFieldIdxOrdered true bs index 562 ReadMinTradeVolIdx
    let tradingSessionID = ReadOptionalFieldIdxOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdxOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let expirationCycle = ReadOptionalFieldIdxOrdered true bs index 827 ReadExpirationCycleIdx
    let text = ReadOptionalFieldIdxOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdxOrdered true bs index 354 ReadEncodedTextIdx
    let ci:SecurityListNoRelatedSymGrp = {
        Instrument = instrument
        InstrumentExtension = instrumentExtension
        FinancingDetails = financingDetails
        NoUnderlyingsGrp = noUnderlyingsGrp
        Currency = currency
        NoStipulationsGrp = noStipulationsGrp
        SecurityListNoLegsGrp = securityListNoLegsGrp
        SpreadOrBenchmarkCurveData = spreadOrBenchmarkCurveData
        YieldData = yieldData
        RoundLot = roundLot
        MinTradeVol = minTradeVol
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        ExpirationCycle = expirationCycle
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadMarketDataIncrementalRefreshNoMDEntriesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MarketDataIncrementalRefreshNoMDEntriesGrp =
    let mDUpdateAction = ReadFieldIdxOrdered true bs index 279 ReadMDUpdateActionIdx
    let deleteReason = ReadOptionalFieldIdxOrdered true bs index 285 ReadDeleteReasonIdx
    let mDEntryType = ReadOptionalFieldIdxOrdered true bs index 269 ReadMDEntryTypeIdx
    let mDEntryID = ReadOptionalFieldIdxOrdered true bs index 278 ReadMDEntryIDIdx
    let mDEntryRefID = ReadOptionalFieldIdxOrdered true bs index 280 ReadMDEntryRefIDIdx
    let instrument = ReadOptionalComponentIdxOrdered true bs index 55 ReadInstrumentIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let noLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadNoLegsGrpIdx
    let financialStatus = ReadOptionalFieldIdxOrdered true bs index 291 ReadFinancialStatusIdx
    let corporateAction = ReadOptionalFieldIdxOrdered true bs index 292 ReadCorporateActionIdx
    let mDEntryPx = ReadOptionalFieldIdxOrdered true bs index 270 ReadMDEntryPxIdx
    let currency = ReadOptionalFieldIdxOrdered true bs index 15 ReadCurrencyIdx
    let mDEntrySize = ReadOptionalFieldIdxOrdered true bs index 271 ReadMDEntrySizeIdx
    let mDEntryDate = ReadOptionalFieldIdxOrdered true bs index 272 ReadMDEntryDateIdx
    let mDEntryTime = ReadOptionalFieldIdxOrdered true bs index 273 ReadMDEntryTimeIdx
    let tickDirection = ReadOptionalFieldIdxOrdered true bs index 274 ReadTickDirectionIdx
    let mDMkt = ReadOptionalFieldIdxOrdered true bs index 275 ReadMDMktIdx
    let tradingSessionID = ReadOptionalFieldIdxOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdxOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let quoteCondition = ReadOptionalFieldIdxOrdered true bs index 276 ReadQuoteConditionIdx
    let tradeCondition = ReadOptionalFieldIdxOrdered true bs index 277 ReadTradeConditionIdx
    let mDEntryOriginator = ReadOptionalFieldIdxOrdered true bs index 282 ReadMDEntryOriginatorIdx
    let locationID = ReadOptionalFieldIdxOrdered true bs index 283 ReadLocationIDIdx
    let deskID = ReadOptionalFieldIdxOrdered true bs index 284 ReadDeskIDIdx
    let openCloseSettlFlag = ReadOptionalFieldIdxOrdered true bs index 286 ReadOpenCloseSettlFlagIdx
    let timeInForce = ReadOptionalFieldIdxOrdered true bs index 59 ReadTimeInForceIdx
    let expireDate = ReadOptionalFieldIdxOrdered true bs index 432 ReadExpireDateIdx
    let expireTime = ReadOptionalFieldIdxOrdered true bs index 126 ReadExpireTimeIdx
    let minQty = ReadOptionalFieldIdxOrdered true bs index 110 ReadMinQtyIdx
    let execInst = ReadOptionalFieldIdxOrdered true bs index 18 ReadExecInstIdx
    let sellerDays = ReadOptionalFieldIdxOrdered true bs index 287 ReadSellerDaysIdx
    let orderID = ReadOptionalFieldIdxOrdered true bs index 37 ReadOrderIDIdx
    let quoteEntryID = ReadOptionalFieldIdxOrdered true bs index 299 ReadQuoteEntryIDIdx
    let mDEntryBuyer = ReadOptionalFieldIdxOrdered true bs index 288 ReadMDEntryBuyerIdx
    let mDEntrySeller = ReadOptionalFieldIdxOrdered true bs index 289 ReadMDEntrySellerIdx
    let numberOfOrders = ReadOptionalFieldIdxOrdered true bs index 346 ReadNumberOfOrdersIdx
    let mDEntryPositionNo = ReadOptionalFieldIdxOrdered true bs index 290 ReadMDEntryPositionNoIdx
    let scope = ReadOptionalFieldIdxOrdered true bs index 546 ReadScopeIdx
    let priceDelta = ReadOptionalFieldIdxOrdered true bs index 811 ReadPriceDeltaIdx
    let netChgPrevDay = ReadOptionalFieldIdxOrdered true bs index 451 ReadNetChgPrevDayIdx
    let text = ReadOptionalFieldIdxOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdxOrdered true bs index 354 ReadEncodedTextIdx
    let ci:MarketDataIncrementalRefreshNoMDEntriesGrp = {
        MDUpdateAction = mDUpdateAction
        DeleteReason = deleteReason
        MDEntryType = mDEntryType
        MDEntryID = mDEntryID
        MDEntryRefID = mDEntryRefID
        Instrument = instrument
        NoUnderlyingsGrp = noUnderlyingsGrp
        NoLegsGrp = noLegsGrp
        FinancialStatus = financialStatus
        CorporateAction = corporateAction
        MDEntryPx = mDEntryPx
        Currency = currency
        MDEntrySize = mDEntrySize
        MDEntryDate = mDEntryDate
        MDEntryTime = mDEntryTime
        TickDirection = tickDirection
        MDMkt = mDMkt
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        QuoteCondition = quoteCondition
        TradeCondition = tradeCondition
        MDEntryOriginator = mDEntryOriginator
        LocationID = locationID
        DeskID = deskID
        OpenCloseSettlFlag = openCloseSettlFlag
        TimeInForce = timeInForce
        ExpireDate = expireDate
        ExpireTime = expireTime
        MinQty = minQty
        ExecInst = execInst
        SellerDays = sellerDays
        OrderID = orderID
        QuoteEntryID = quoteEntryID
        MDEntryBuyer = mDEntryBuyer
        MDEntrySeller = mDEntrySeller
        NumberOfOrders = numberOfOrders
        MDEntryPositionNo = mDEntryPositionNo
        Scope = scope
        PriceDelta = priceDelta
        NetChgPrevDay = netChgPrevDay
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadMarketDataRequestNoRelatedSymGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MarketDataRequestNoRelatedSymGrp =
    let instrument = ReadComponentIdxOrdered true bs index ReadInstrumentIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let noLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadNoLegsGrpIdx
    let ci:MarketDataRequestNoRelatedSymGrp = {
        Instrument = instrument
        NoUnderlyingsGrp = noUnderlyingsGrp
        NoLegsGrp = noLegsGrp
    }
    ci


// group
let ReadMassQuoteAcknowledgementNoQuoteEntriesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MassQuoteAcknowledgementNoQuoteEntriesGrp =
    let quoteEntryID = ReadFieldIdxOrdered true bs index 299 ReadQuoteEntryIDIdx
    let instrument = ReadOptionalComponentIdxOrdered true bs index 55 ReadInstrumentIdx
    let noLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadNoLegsGrpIdx
    let bidPx = ReadOptionalFieldIdxOrdered true bs index 132 ReadBidPxIdx
    let offerPx = ReadOptionalFieldIdxOrdered true bs index 133 ReadOfferPxIdx
    let bidSize = ReadOptionalFieldIdxOrdered true bs index 134 ReadBidSizeIdx
    let offerSize = ReadOptionalFieldIdxOrdered true bs index 135 ReadOfferSizeIdx
    let validUntilTime = ReadOptionalFieldIdxOrdered true bs index 62 ReadValidUntilTimeIdx
    let bidSpotRate = ReadOptionalFieldIdxOrdered true bs index 188 ReadBidSpotRateIdx
    let offerSpotRate = ReadOptionalFieldIdxOrdered true bs index 190 ReadOfferSpotRateIdx
    let bidForwardPoints = ReadOptionalFieldIdxOrdered true bs index 189 ReadBidForwardPointsIdx
    let offerForwardPoints = ReadOptionalFieldIdxOrdered true bs index 191 ReadOfferForwardPointsIdx
    let midPx = ReadOptionalFieldIdxOrdered true bs index 631 ReadMidPxIdx
    let bidYield = ReadOptionalFieldIdxOrdered true bs index 632 ReadBidYieldIdx
    let midYield = ReadOptionalFieldIdxOrdered true bs index 633 ReadMidYieldIdx
    let offerYield = ReadOptionalFieldIdxOrdered true bs index 634 ReadOfferYieldIdx
    let transactTime = ReadOptionalFieldIdxOrdered true bs index 60 ReadTransactTimeIdx
    let tradingSessionID = ReadOptionalFieldIdxOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdxOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let settlDate = ReadOptionalFieldIdxOrdered true bs index 64 ReadSettlDateIdx
    let ordType = ReadOptionalFieldIdxOrdered true bs index 40 ReadOrdTypeIdx
    let settlDate2 = ReadOptionalFieldIdxOrdered true bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldIdxOrdered true bs index 192 ReadOrderQty2Idx
    let bidForwardPoints2 = ReadOptionalFieldIdxOrdered true bs index 642 ReadBidForwardPoints2Idx
    let offerForwardPoints2 = ReadOptionalFieldIdxOrdered true bs index 643 ReadOfferForwardPoints2Idx
    let currency = ReadOptionalFieldIdxOrdered true bs index 15 ReadCurrencyIdx
    let quoteEntryRejectReason = ReadOptionalFieldIdxOrdered true bs index 368 ReadQuoteEntryRejectReasonIdx
    let ci:MassQuoteAcknowledgementNoQuoteEntriesGrp = {
        QuoteEntryID = quoteEntryID
        Instrument = instrument
        NoLegsGrp = noLegsGrp
        BidPx = bidPx
        OfferPx = offerPx
        BidSize = bidSize
        OfferSize = offerSize
        ValidUntilTime = validUntilTime
        BidSpotRate = bidSpotRate
        OfferSpotRate = offerSpotRate
        BidForwardPoints = bidForwardPoints
        OfferForwardPoints = offerForwardPoints
        MidPx = midPx
        BidYield = bidYield
        MidYield = midYield
        OfferYield = offerYield
        TransactTime = transactTime
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        SettlDate = settlDate
        OrdType = ordType
        SettlDate2 = settlDate2
        OrderQty2 = orderQty2
        BidForwardPoints2 = bidForwardPoints2
        OfferForwardPoints2 = offerForwardPoints2
        Currency = currency
        QuoteEntryRejectReason = quoteEntryRejectReason
    }
    ci


// group
let ReadMassQuoteAcknowledgementNoQuoteSetsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MassQuoteAcknowledgementNoQuoteSetsGrp =
    let quoteSetID = ReadFieldIdxOrdered true bs index 302 ReadQuoteSetIDIdx
    let underlyingInstrument = ReadOptionalComponentIdxOrdered true bs index 311 ReadUnderlyingInstrumentIdx
    let totNoQuoteEntries = ReadOptionalFieldIdxOrdered true bs index 304 ReadTotNoQuoteEntriesIdx
    let lastFragment = ReadOptionalFieldIdxOrdered true bs index 893 ReadLastFragmentIdx
    let massQuoteAcknowledgementNoQuoteEntriesGrpIdx = ReadOptionalGroupIdx bs index 295 ReadMassQuoteAcknowledgementNoQuoteEntriesGrpIdx
    let ci:MassQuoteAcknowledgementNoQuoteSetsGrp = {
        QuoteSetID = quoteSetID
        UnderlyingInstrument = underlyingInstrument
        TotNoQuoteEntries = totNoQuoteEntries
        LastFragment = lastFragment
        MassQuoteAcknowledgementNoQuoteEntriesGrp = massQuoteAcknowledgementNoQuoteEntriesGrp
    }
    ci


// group
let ReadMassQuoteNoQuoteEntriesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MassQuoteNoQuoteEntriesGrp =
    let quoteEntryID = ReadFieldIdxOrdered true bs index 299 ReadQuoteEntryIDIdx
    let instrument = ReadOptionalComponentIdxOrdered true bs index 55 ReadInstrumentIdx
    let noLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadNoLegsGrpIdx
    let bidPx = ReadOptionalFieldIdxOrdered true bs index 132 ReadBidPxIdx
    let offerPx = ReadOptionalFieldIdxOrdered true bs index 133 ReadOfferPxIdx
    let bidSize = ReadOptionalFieldIdxOrdered true bs index 134 ReadBidSizeIdx
    let offerSize = ReadOptionalFieldIdxOrdered true bs index 135 ReadOfferSizeIdx
    let validUntilTime = ReadOptionalFieldIdxOrdered true bs index 62 ReadValidUntilTimeIdx
    let bidSpotRate = ReadOptionalFieldIdxOrdered true bs index 188 ReadBidSpotRateIdx
    let offerSpotRate = ReadOptionalFieldIdxOrdered true bs index 190 ReadOfferSpotRateIdx
    let bidForwardPoints = ReadOptionalFieldIdxOrdered true bs index 189 ReadBidForwardPointsIdx
    let offerForwardPoints = ReadOptionalFieldIdxOrdered true bs index 191 ReadOfferForwardPointsIdx
    let midPx = ReadOptionalFieldIdxOrdered true bs index 631 ReadMidPxIdx
    let bidYield = ReadOptionalFieldIdxOrdered true bs index 632 ReadBidYieldIdx
    let midYield = ReadOptionalFieldIdxOrdered true bs index 633 ReadMidYieldIdx
    let offerYield = ReadOptionalFieldIdxOrdered true bs index 634 ReadOfferYieldIdx
    let transactTime = ReadOptionalFieldIdxOrdered true bs index 60 ReadTransactTimeIdx
    let tradingSessionID = ReadOptionalFieldIdxOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdxOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let settlDate = ReadOptionalFieldIdxOrdered true bs index 64 ReadSettlDateIdx
    let ordType = ReadOptionalFieldIdxOrdered true bs index 40 ReadOrdTypeIdx
    let settlDate2 = ReadOptionalFieldIdxOrdered true bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldIdxOrdered true bs index 192 ReadOrderQty2Idx
    let bidForwardPoints2 = ReadOptionalFieldIdxOrdered true bs index 642 ReadBidForwardPoints2Idx
    let offerForwardPoints2 = ReadOptionalFieldIdxOrdered true bs index 643 ReadOfferForwardPoints2Idx
    let currency = ReadOptionalFieldIdxOrdered true bs index 15 ReadCurrencyIdx
    let ci:MassQuoteNoQuoteEntriesGrp = {
        QuoteEntryID = quoteEntryID
        Instrument = instrument
        NoLegsGrp = noLegsGrp
        BidPx = bidPx
        OfferPx = offerPx
        BidSize = bidSize
        OfferSize = offerSize
        ValidUntilTime = validUntilTime
        BidSpotRate = bidSpotRate
        OfferSpotRate = offerSpotRate
        BidForwardPoints = bidForwardPoints
        OfferForwardPoints = offerForwardPoints
        MidPx = midPx
        BidYield = bidYield
        MidYield = midYield
        OfferYield = offerYield
        TransactTime = transactTime
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        SettlDate = settlDate
        OrdType = ordType
        SettlDate2 = settlDate2
        OrderQty2 = orderQty2
        BidForwardPoints2 = bidForwardPoints2
        OfferForwardPoints2 = offerForwardPoints2
        Currency = currency
    }
    ci


// group
let ReadNoQuoteSetsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoQuoteSetsGrp =
    let quoteSetID = ReadFieldIdxOrdered true bs index 302 ReadQuoteSetIDIdx
    let underlyingInstrument = ReadOptionalComponentIdxOrdered true bs index 311 ReadUnderlyingInstrumentIdx
    let quoteSetValidUntilTime = ReadOptionalFieldIdxOrdered true bs index 367 ReadQuoteSetValidUntilTimeIdx
    let totNoQuoteEntries = ReadFieldIdxOrdered true bs index 304 ReadTotNoQuoteEntriesIdx
    let lastFragment = ReadOptionalFieldIdxOrdered true bs index 893 ReadLastFragmentIdx
    let massQuoteNoQuoteEntriesGrp = ReadGroupIdx bs index tag295 "ReadNoQuoteSets"  ReadMassQuoteNoQuoteEntriesGrpIdx
    let ci:NoQuoteSetsGrp = {
        QuoteSetID = quoteSetID
        UnderlyingInstrument = underlyingInstrument
        QuoteSetValidUntilTime = quoteSetValidUntilTime
        TotNoQuoteEntries = totNoQuoteEntries
        LastFragment = lastFragment
        MassQuoteNoQuoteEntriesGrp = massQuoteNoQuoteEntriesGrp
    }
    ci


// group
let ReadQuoteStatusReportNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteStatusReportNoLegsGrp =
    let instrumentLegFG = ReadComponentIdxOrdered true bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdxOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdxOrdered true bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldIdxOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdxOrdered true bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let ci:QuoteStatusReportNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
    }
    ci


// group
let ReadNoQuoteEntriesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoQuoteEntriesGrp =
    let instrument = ReadComponentIdxOrdered true bs index ReadInstrumentIdx
    let financingDetails = ReadComponentIdxOrdered true bs index ReadFinancingDetailsIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let noLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadNoLegsGrpIdx
    let ci:NoQuoteEntriesGrp = {
        Instrument = instrument
        FinancingDetails = financingDetails
        NoUnderlyingsGrp = noUnderlyingsGrp
        NoLegsGrp = noLegsGrp
    }
    ci


// group
let ReadQuoteNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteNoLegsGrp =
    let instrumentLegFG = ReadComponentIdxOrdered true bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdxOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdxOrdered true bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldIdxOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdxOrdered true bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legPriceType = ReadOptionalFieldIdxOrdered true bs index 686 ReadLegPriceTypeIdx
    let legBidPx = ReadOptionalFieldIdxOrdered true bs index 681 ReadLegBidPxIdx
    let legOfferPx = ReadOptionalFieldIdxOrdered true bs index 684 ReadLegOfferPxIdx
    let legBenchmarkCurveData = ReadComponentIdxOrdered true bs index ReadLegBenchmarkCurveDataIdx
    let ci:QuoteNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegPriceType = legPriceType
        LegBidPx = legBidPx
        LegOfferPx = legOfferPx
        LegBenchmarkCurveData = legBenchmarkCurveData
    }
    ci


// group
let ReadRFQRequestNoRelatedSymGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : RFQRequestNoRelatedSymGrp =
    let instrument = ReadComponentIdxOrdered true bs index ReadInstrumentIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let noLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadNoLegsGrpIdx
    let prevClosePx = ReadOptionalFieldIdxOrdered true bs index 140 ReadPrevClosePxIdx
    let quoteRequestType = ReadOptionalFieldIdxOrdered true bs index 303 ReadQuoteRequestTypeIdx
    let quoteType = ReadOptionalFieldIdxOrdered true bs index 537 ReadQuoteTypeIdx
    let tradingSessionID = ReadOptionalFieldIdxOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdxOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let ci:RFQRequestNoRelatedSymGrp = {
        Instrument = instrument
        NoUnderlyingsGrp = noUnderlyingsGrp
        NoLegsGrp = noLegsGrp
        PrevClosePx = prevClosePx
        QuoteRequestType = quoteRequestType
        QuoteType = quoteType
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
    }
    ci


// group
let ReadQuoteRequestRejectNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteRequestRejectNoLegsGrp =
    let instrumentLegFG = ReadComponentIdxOrdered true bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdxOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdxOrdered true bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldIdxOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdxOrdered true bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legBenchmarkCurveData = ReadComponentIdxOrdered true bs index ReadLegBenchmarkCurveDataIdx
    let ci:QuoteRequestRejectNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegBenchmarkCurveData = legBenchmarkCurveData
    }
    ci


// group
let ReadQuoteRequestRejectNoRelatedSymGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteRequestRejectNoRelatedSymGrp =
    let instrument = ReadComponentIdxOrdered true bs index ReadInstrumentIdx
    let financingDetails = ReadComponentIdxOrdered true bs index ReadFinancingDetailsIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let prevClosePx = ReadOptionalFieldIdxOrdered true bs index 140 ReadPrevClosePxIdx
    let quoteRequestType = ReadOptionalFieldIdxOrdered true bs index 303 ReadQuoteRequestTypeIdx
    let quoteType = ReadOptionalFieldIdxOrdered true bs index 537 ReadQuoteTypeIdx
    let tradingSessionID = ReadOptionalFieldIdxOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdxOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let tradeOriginationDate = ReadOptionalFieldIdxOrdered true bs index 229 ReadTradeOriginationDateIdx
    let side = ReadOptionalFieldIdxOrdered true bs index 54 ReadSideIdx
    let qtyType = ReadOptionalFieldIdxOrdered true bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentIdxOrdered true bs index ReadOrderQtyDataIdx
    let settlType = ReadOptionalFieldIdxOrdered true bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldIdxOrdered true bs index 64 ReadSettlDateIdx
    let settlDate2 = ReadOptionalFieldIdxOrdered true bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldIdxOrdered true bs index 192 ReadOrderQty2Idx
    let currency = ReadOptionalFieldIdxOrdered true bs index 15 ReadCurrencyIdx
    let noStipulationsGrpIdx = ReadOptionalGroupIdx bs index 232 ReadNoStipulationsGrpIdx
    let account = ReadOptionalFieldIdxOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdxOrdered true bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldIdxOrdered true bs index 581 ReadAccountTypeIdx
    let quoteRequestRejectNoLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadQuoteRequestRejectNoLegsGrpIdx
    let ci:QuoteRequestRejectNoRelatedSymGrp = {
        Instrument = instrument
        FinancingDetails = financingDetails
        NoUnderlyingsGrp = noUnderlyingsGrp
        PrevClosePx = prevClosePx
        QuoteRequestType = quoteRequestType
        QuoteType = quoteType
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        TradeOriginationDate = tradeOriginationDate
        Side = side
        QtyType = qtyType
        OrderQtyData = orderQtyData
        SettlType = settlType
        SettlDate = settlDate
        SettlDate2 = settlDate2
        OrderQty2 = orderQty2
        Currency = currency
        NoStipulationsGrp = noStipulationsGrp
        Account = account
        AcctIDSource = acctIDSource
        AccountType = accountType
        QuoteRequestRejectNoLegsGrp = quoteRequestRejectNoLegsGrp
    }
    ci


// group
let ReadQuoteResponseNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteResponseNoLegsGrp =
    let instrumentLegFG = ReadComponentIdxOrdered true bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdxOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdxOrdered true bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldIdxOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdxOrdered true bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legPriceType = ReadOptionalFieldIdxOrdered true bs index 686 ReadLegPriceTypeIdx
    let legBidPx = ReadOptionalFieldIdxOrdered true bs index 681 ReadLegBidPxIdx
    let legOfferPx = ReadOptionalFieldIdxOrdered true bs index 684 ReadLegOfferPxIdx
    let legBenchmarkCurveData = ReadComponentIdxOrdered true bs index ReadLegBenchmarkCurveDataIdx
    let ci:QuoteResponseNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegPriceType = legPriceType
        LegBidPx = legBidPx
        LegOfferPx = legOfferPx
        LegBenchmarkCurveData = legBenchmarkCurveData
    }
    ci


// group
let ReadQuoteRequestNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteRequestNoLegsGrp =
    let instrumentLegFG = ReadComponentIdxOrdered true bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdxOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdxOrdered true bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldIdxOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdxOrdered true bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legBenchmarkCurveData = ReadComponentIdxOrdered true bs index ReadLegBenchmarkCurveDataIdx
    let ci:QuoteRequestNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegBenchmarkCurveData = legBenchmarkCurveData
    }
    ci


// group
let ReadNoQuoteQualifiersGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoQuoteQualifiersGrp =
    let quoteQualifier = ReadFieldIdxOrdered true bs index 695 ReadQuoteQualifierIdx
    let ci:NoQuoteQualifiersGrp = {
        QuoteQualifier = quoteQualifier
    }
    ci


// group
let ReadQuoteRequestNoRelatedSymGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteRequestNoRelatedSymGrp =
    let instrument = ReadComponentIdxOrdered true bs index ReadInstrumentIdx
    let financingDetails = ReadComponentIdxOrdered true bs index ReadFinancingDetailsIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let prevClosePx = ReadOptionalFieldIdxOrdered true bs index 140 ReadPrevClosePxIdx
    let quoteRequestType = ReadOptionalFieldIdxOrdered true bs index 303 ReadQuoteRequestTypeIdx
    let quoteType = ReadOptionalFieldIdxOrdered true bs index 537 ReadQuoteTypeIdx
    let tradingSessionID = ReadOptionalFieldIdxOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdxOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let tradeOriginationDate = ReadOptionalFieldIdxOrdered true bs index 229 ReadTradeOriginationDateIdx
    let side = ReadOptionalFieldIdxOrdered true bs index 54 ReadSideIdx
    let qtyType = ReadOptionalFieldIdxOrdered true bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentIdxOrdered true bs index ReadOrderQtyDataIdx
    let settlType = ReadOptionalFieldIdxOrdered true bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldIdxOrdered true bs index 64 ReadSettlDateIdx
    let settlDate2 = ReadOptionalFieldIdxOrdered true bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldIdxOrdered true bs index 192 ReadOrderQty2Idx
    let currency = ReadOptionalFieldIdxOrdered true bs index 15 ReadCurrencyIdx
    let noStipulationsGrpIdx = ReadOptionalGroupIdx bs index 232 ReadNoStipulationsGrpIdx
    let account = ReadOptionalFieldIdxOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdxOrdered true bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldIdxOrdered true bs index 581 ReadAccountTypeIdx
    let quoteRequestNoLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadQuoteRequestNoLegsGrpIdx
    let noQuoteQualifiersGrpIdx = ReadOptionalGroupIdx bs index 735 ReadNoQuoteQualifiersGrpIdx
    let quotePriceType = ReadOptionalFieldIdxOrdered true bs index 692 ReadQuotePriceTypeIdx
    let ordType = ReadOptionalFieldIdxOrdered true bs index 40 ReadOrdTypeIdx
    let validUntilTime = ReadOptionalFieldIdxOrdered true bs index 62 ReadValidUntilTimeIdx
    let expireTime = ReadOptionalFieldIdxOrdered true bs index 126 ReadExpireTimeIdx
    let transactTime = ReadOptionalFieldIdxOrdered true bs index 60 ReadTransactTimeIdx
    let spreadOrBenchmarkCurveData = ReadComponentIdxOrdered true bs index ReadSpreadOrBenchmarkCurveDataIdx
    let priceType = ReadOptionalFieldIdxOrdered true bs index 423 ReadPriceTypeIdx
    let price = ReadOptionalFieldIdxOrdered true bs index 44 ReadPriceIdx
    let price2 = ReadOptionalFieldIdxOrdered true bs index 640 ReadPrice2Idx
    let yieldData = ReadComponentIdxOrdered true bs index ReadYieldDataIdx
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let ci:QuoteRequestNoRelatedSymGrp = {
        Instrument = instrument
        FinancingDetails = financingDetails
        NoUnderlyingsGrp = noUnderlyingsGrp
        PrevClosePx = prevClosePx
        QuoteRequestType = quoteRequestType
        QuoteType = quoteType
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        TradeOriginationDate = tradeOriginationDate
        Side = side
        QtyType = qtyType
        OrderQtyData = orderQtyData
        SettlType = settlType
        SettlDate = settlDate
        SettlDate2 = settlDate2
        OrderQty2 = orderQty2
        Currency = currency
        NoStipulationsGrp = noStipulationsGrp
        Account = account
        AcctIDSource = acctIDSource
        AccountType = accountType
        QuoteRequestNoLegsGrp = quoteRequestNoLegsGrp
        NoQuoteQualifiersGrp = noQuoteQualifiersGrp
        QuotePriceType = quotePriceType
        OrdType = ordType
        ValidUntilTime = validUntilTime
        ExpireTime = expireTime
        TransactTime = transactTime
        SpreadOrBenchmarkCurveData = spreadOrBenchmarkCurveData
        PriceType = priceType
        Price = price
        Price2 = price2
        YieldData = yieldData
        NoPartyIDsGrp = noPartyIDsGrp
    }
    ci


// component
let ReadPartiesIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Parties =
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let ci:Parties = {
        NoPartyIDsGrp = noPartyIDsGrp
    }
    ci


// component
let ReadNestedPartiesIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties =
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let ci:NestedParties = {
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
    }
    ci


// group
let ReadNoRelatedSymGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoRelatedSymGrp =
    let instrument = ReadComponentIdxOrdered true bs index ReadInstrumentIdx
    let ci:NoRelatedSymGrp = {
        Instrument = instrument
    }
    ci


// group
let ReadIndicationOfInterestNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : IndicationOfInterestNoLegsGrp =
    let instrumentLegFG = ReadComponentIdxOrdered true bs index ReadInstrumentLegFGIdx
    let legIOIQty = ReadOptionalFieldIdxOrdered true bs index 682 ReadLegIOIQtyIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let ci:IndicationOfInterestNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegIOIQty = legIOIQty
        NoLegStipulationsGrp = noLegStipulationsGrp
    }
    ci


// component
let ReadLegStipulationsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LegStipulations =
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let ci:LegStipulations = {
        NoLegStipulationsGrp = noLegStipulationsGrp
    }
    ci


// component
let ReadStipulationsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Stipulations =
    let noStipulationsGrpIdx = ReadOptionalGroupIdx bs index 232 ReadNoStipulationsGrpIdx
    let ci:Stipulations = {
        NoStipulationsGrp = noStipulationsGrp
    }
    ci


// group
let ReadAdvertisementNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AdvertisementNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentIdxOrdered true bs index ReadUnderlyingInstrumentIdx
    let ci:AdvertisementNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
    }
    ci


// component
let ReadUnderlyingStipulationsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : UnderlyingStipulations =
    let noUnderlyingStipsGrpIdx = ReadOptionalGroupIdx bs index 887 ReadNoUnderlyingStipsGrpIdx
    let ci:UnderlyingStipulations = {
        NoUnderlyingStipsGrp = noUnderlyingStipsGrp
    }
    ci


// component
let ReadInstrumentLegIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentLeg =
    let legSymbol = ReadOptionalFieldIdxOrdered true bs index 600 ReadLegSymbolIdx
    let legSymbolSfx = ReadOptionalFieldIdxOrdered true bs index 601 ReadLegSymbolSfxIdx
    let legSecurityID = ReadOptionalFieldIdxOrdered true bs index 602 ReadLegSecurityIDIdx
    let legSecurityIDSource = ReadOptionalFieldIdxOrdered true bs index 603 ReadLegSecurityIDSourceIdx
    let noLegSecurityAltIDGrpIdx = ReadOptionalGroupIdx bs index 604 ReadNoLegSecurityAltIDGrpIdx
    let legProduct = ReadOptionalFieldIdxOrdered true bs index 607 ReadLegProductIdx
    let legCFICode = ReadOptionalFieldIdxOrdered true bs index 608 ReadLegCFICodeIdx
    let legSecurityType = ReadOptionalFieldIdxOrdered true bs index 609 ReadLegSecurityTypeIdx
    let legSecuritySubType = ReadOptionalFieldIdxOrdered true bs index 764 ReadLegSecuritySubTypeIdx
    let legMaturityMonthYear = ReadOptionalFieldIdxOrdered true bs index 610 ReadLegMaturityMonthYearIdx
    let legMaturityDate = ReadOptionalFieldIdxOrdered true bs index 611 ReadLegMaturityDateIdx
    let legCouponPaymentDate = ReadOptionalFieldIdxOrdered true bs index 248 ReadLegCouponPaymentDateIdx
    let legIssueDate = ReadOptionalFieldIdxOrdered true bs index 249 ReadLegIssueDateIdx
    let legRepoCollateralSecurityType = ReadOptionalFieldIdxOrdered true bs index 250 ReadLegRepoCollateralSecurityTypeIdx
    let legRepurchaseTerm = ReadOptionalFieldIdxOrdered true bs index 251 ReadLegRepurchaseTermIdx
    let legRepurchaseRate = ReadOptionalFieldIdxOrdered true bs index 252 ReadLegRepurchaseRateIdx
    let legFactor = ReadOptionalFieldIdxOrdered true bs index 253 ReadLegFactorIdx
    let legCreditRating = ReadOptionalFieldIdxOrdered true bs index 257 ReadLegCreditRatingIdx
    let legInstrRegistry = ReadOptionalFieldIdxOrdered true bs index 599 ReadLegInstrRegistryIdx
    let legCountryOfIssue = ReadOptionalFieldIdxOrdered true bs index 596 ReadLegCountryOfIssueIdx
    let legStateOrProvinceOfIssue = ReadOptionalFieldIdxOrdered true bs index 597 ReadLegStateOrProvinceOfIssueIdx
    let legLocaleOfIssue = ReadOptionalFieldIdxOrdered true bs index 598 ReadLegLocaleOfIssueIdx
    let legRedemptionDate = ReadOptionalFieldIdxOrdered true bs index 254 ReadLegRedemptionDateIdx
    let legStrikePrice = ReadOptionalFieldIdxOrdered true bs index 612 ReadLegStrikePriceIdx
    let legStrikeCurrency = ReadOptionalFieldIdxOrdered true bs index 942 ReadLegStrikeCurrencyIdx
    let legOptAttribute = ReadOptionalFieldIdxOrdered true bs index 613 ReadLegOptAttributeIdx
    let legContractMultiplier = ReadOptionalFieldIdxOrdered true bs index 614 ReadLegContractMultiplierIdx
    let legCouponRate = ReadOptionalFieldIdxOrdered true bs index 615 ReadLegCouponRateIdx
    let legSecurityExchange = ReadOptionalFieldIdxOrdered true bs index 616 ReadLegSecurityExchangeIdx
    let legIssuer = ReadOptionalFieldIdxOrdered true bs index 617 ReadLegIssuerIdx
    let encodedLegIssuer = ReadOptionalFieldIdxOrdered true bs index 618 ReadEncodedLegIssuerIdx
    let legSecurityDesc = ReadOptionalFieldIdxOrdered true bs index 620 ReadLegSecurityDescIdx
    let encodedLegSecurityDesc = ReadOptionalFieldIdxOrdered true bs index 621 ReadEncodedLegSecurityDescIdx
    let legRatioQty = ReadOptionalFieldIdxOrdered true bs index 623 ReadLegRatioQtyIdx
    let legSide = ReadOptionalFieldIdxOrdered true bs index 624 ReadLegSideIdx
    let legCurrency = ReadOptionalFieldIdxOrdered true bs index 556 ReadLegCurrencyIdx
    let legPool = ReadOptionalFieldIdxOrdered true bs index 740 ReadLegPoolIdx
    let legDatedDate = ReadOptionalFieldIdxOrdered true bs index 739 ReadLegDatedDateIdx
    let legContractSettlMonth = ReadOptionalFieldIdxOrdered true bs index 955 ReadLegContractSettlMonthIdx
    let legInterestAccrualDate = ReadOptionalFieldIdxOrdered true bs index 956 ReadLegInterestAccrualDateIdx
    let ci:InstrumentLeg = {
        LegSymbol = legSymbol
        LegSymbolSfx = legSymbolSfx
        LegSecurityID = legSecurityID
        LegSecurityIDSource = legSecurityIDSource
        NoLegSecurityAltIDGrp = noLegSecurityAltIDGrp
        LegProduct = legProduct
        LegCFICode = legCFICode
        LegSecurityType = legSecurityType
        LegSecuritySubType = legSecuritySubType
        LegMaturityMonthYear = legMaturityMonthYear
        LegMaturityDate = legMaturityDate
        LegCouponPaymentDate = legCouponPaymentDate
        LegIssueDate = legIssueDate
        LegRepoCollateralSecurityType = legRepoCollateralSecurityType
        LegRepurchaseTerm = legRepurchaseTerm
        LegRepurchaseRate = legRepurchaseRate
        LegFactor = legFactor
        LegCreditRating = legCreditRating
        LegInstrRegistry = legInstrRegistry
        LegCountryOfIssue = legCountryOfIssue
        LegStateOrProvinceOfIssue = legStateOrProvinceOfIssue
        LegLocaleOfIssue = legLocaleOfIssue
        LegRedemptionDate = legRedemptionDate
        LegStrikePrice = legStrikePrice
        LegStrikeCurrency = legStrikeCurrency
        LegOptAttribute = legOptAttribute
        LegContractMultiplier = legContractMultiplier
        LegCouponRate = legCouponRate
        LegSecurityExchange = legSecurityExchange
        LegIssuer = legIssuer
        EncodedLegIssuer = encodedLegIssuer
        LegSecurityDesc = legSecurityDesc
        EncodedLegSecurityDesc = encodedLegSecurityDesc
        LegRatioQty = legRatioQty
        LegSide = legSide
        LegCurrency = legCurrency
        LegPool = legPool
        LegDatedDate = legDatedDate
        LegContractSettlMonth = legContractSettlMonth
        LegInterestAccrualDate = legInterestAccrualDate
    }
    ci


// group
let ReadNoMsgTypesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMsgTypesGrp =
    let refMsgType = ReadFieldIdxOrdered true bs index 372 ReadRefMsgTypeIdx
    let msgDirection = ReadOptionalFieldIdxOrdered true bs index 385 ReadMsgDirectionIdx
    let ci:NoMsgTypesGrp = {
        RefMsgType = refMsgType
        MsgDirection = msgDirection
    }
    ci


// group
let ReadNoIOIQualifiersGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoIOIQualifiersGrp =
    let iOIQualifier = ReadFieldIdxOrdered true bs index 104 ReadIOIQualifierIdx
    let ci:NoIOIQualifiersGrp = {
        IOIQualifier = iOIQualifier
    }
    ci


// group
let ReadNoRoutingIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoRoutingIDsGrp =
    let routingType = ReadFieldIdxOrdered true bs index 216 ReadRoutingTypeIdx
    let routingID = ReadOptionalFieldIdxOrdered true bs index 217 ReadRoutingIDIdx
    let ci:NoRoutingIDsGrp = {
        RoutingType = routingType
        RoutingID = routingID
    }
    ci


// group
let ReadLinesOfTextGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LinesOfTextGrp =
    let text = ReadFieldIdxOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdxOrdered true bs index 354 ReadEncodedTextIdx
    let ci:LinesOfTextGrp = {
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadNoMDEntryTypesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMDEntryTypesGrp =
    let mDEntryType = ReadFieldIdxOrdered true bs index 269 ReadMDEntryTypeIdx
    let ci:NoMDEntryTypesGrp = {
        MDEntryType = mDEntryType
    }
    ci


// group
let ReadNoMDEntriesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMDEntriesGrp =
    let mDEntryType = ReadFieldIdxOrdered true bs index 269 ReadMDEntryTypeIdx
    let mDEntryPx = ReadOptionalFieldIdxOrdered true bs index 270 ReadMDEntryPxIdx
    let currency = ReadOptionalFieldIdxOrdered true bs index 15 ReadCurrencyIdx
    let mDEntrySize = ReadOptionalFieldIdxOrdered true bs index 271 ReadMDEntrySizeIdx
    let mDEntryDate = ReadOptionalFieldIdxOrdered true bs index 272 ReadMDEntryDateIdx
    let mDEntryTime = ReadOptionalFieldIdxOrdered true bs index 273 ReadMDEntryTimeIdx
    let tickDirection = ReadOptionalFieldIdxOrdered true bs index 274 ReadTickDirectionIdx
    let mDMkt = ReadOptionalFieldIdxOrdered true bs index 275 ReadMDMktIdx
    let tradingSessionID = ReadOptionalFieldIdxOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdxOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let quoteCondition = ReadOptionalFieldIdxOrdered true bs index 276 ReadQuoteConditionIdx
    let tradeCondition = ReadOptionalFieldIdxOrdered true bs index 277 ReadTradeConditionIdx
    let mDEntryOriginator = ReadOptionalFieldIdxOrdered true bs index 282 ReadMDEntryOriginatorIdx
    let locationID = ReadOptionalFieldIdxOrdered true bs index 283 ReadLocationIDIdx
    let deskID = ReadOptionalFieldIdxOrdered true bs index 284 ReadDeskIDIdx
    let openCloseSettlFlag = ReadOptionalFieldIdxOrdered true bs index 286 ReadOpenCloseSettlFlagIdx
    let timeInForce = ReadOptionalFieldIdxOrdered true bs index 59 ReadTimeInForceIdx
    let expireDate = ReadOptionalFieldIdxOrdered true bs index 432 ReadExpireDateIdx
    let expireTime = ReadOptionalFieldIdxOrdered true bs index 126 ReadExpireTimeIdx
    let minQty = ReadOptionalFieldIdxOrdered true bs index 110 ReadMinQtyIdx
    let execInst = ReadOptionalFieldIdxOrdered true bs index 18 ReadExecInstIdx
    let sellerDays = ReadOptionalFieldIdxOrdered true bs index 287 ReadSellerDaysIdx
    let orderID = ReadOptionalFieldIdxOrdered true bs index 37 ReadOrderIDIdx
    let quoteEntryID = ReadOptionalFieldIdxOrdered true bs index 299 ReadQuoteEntryIDIdx
    let mDEntryBuyer = ReadOptionalFieldIdxOrdered true bs index 288 ReadMDEntryBuyerIdx
    let mDEntrySeller = ReadOptionalFieldIdxOrdered true bs index 289 ReadMDEntrySellerIdx
    let numberOfOrders = ReadOptionalFieldIdxOrdered true bs index 346 ReadNumberOfOrdersIdx
    let mDEntryPositionNo = ReadOptionalFieldIdxOrdered true bs index 290 ReadMDEntryPositionNoIdx
    let scope = ReadOptionalFieldIdxOrdered true bs index 546 ReadScopeIdx
    let priceDelta = ReadOptionalFieldIdxOrdered true bs index 811 ReadPriceDeltaIdx
    let text = ReadOptionalFieldIdxOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdxOrdered true bs index 354 ReadEncodedTextIdx
    let ci:NoMDEntriesGrp = {
        MDEntryType = mDEntryType
        MDEntryPx = mDEntryPx
        Currency = currency
        MDEntrySize = mDEntrySize
        MDEntryDate = mDEntryDate
        MDEntryTime = mDEntryTime
        TickDirection = tickDirection
        MDMkt = mDMkt
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        QuoteCondition = quoteCondition
        TradeCondition = tradeCondition
        MDEntryOriginator = mDEntryOriginator
        LocationID = locationID
        DeskID = deskID
        OpenCloseSettlFlag = openCloseSettlFlag
        TimeInForce = timeInForce
        ExpireDate = expireDate
        ExpireTime = expireTime
        MinQty = minQty
        ExecInst = execInst
        SellerDays = sellerDays
        OrderID = orderID
        QuoteEntryID = quoteEntryID
        MDEntryBuyer = mDEntryBuyer
        MDEntrySeller = mDEntrySeller
        NumberOfOrders = numberOfOrders
        MDEntryPositionNo = mDEntryPositionNo
        Scope = scope
        PriceDelta = priceDelta
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadNoAltMDSourceGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoAltMDSourceGrp =
    let altMDSourceID = ReadFieldIdxOrdered true bs index 817 ReadAltMDSourceIDIdx
    let ci:NoAltMDSourceGrp = {
        AltMDSourceID = altMDSourceID
    }
    ci


// group
let ReadNoSecurityTypesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSecurityTypesGrp =
    let securityType = ReadFieldIdxOrdered true bs index 167 ReadSecurityTypeIdx
    let securitySubType = ReadOptionalFieldIdxOrdered true bs index 762 ReadSecuritySubTypeIdx
    let product = ReadOptionalFieldIdxOrdered true bs index 460 ReadProductIdx
    let cFICode = ReadOptionalFieldIdxOrdered true bs index 461 ReadCFICodeIdx
    let ci:NoSecurityTypesGrp = {
        SecurityType = securityType
        SecuritySubType = securitySubType
        Product = product
        CFICode = cFICode
    }
    ci


// group
let ReadNoContraBrokersGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoContraBrokersGrp =
    let contraBroker = ReadFieldIdxOrdered true bs index 375 ReadContraBrokerIdx
    let contraTrader = ReadOptionalFieldIdxOrdered true bs index 337 ReadContraTraderIdx
    let contraTradeQty = ReadOptionalFieldIdxOrdered true bs index 437 ReadContraTradeQtyIdx
    let contraTradeTime = ReadOptionalFieldIdxOrdered true bs index 438 ReadContraTradeTimeIdx
    let contraLegRefID = ReadOptionalFieldIdxOrdered true bs index 655 ReadContraLegRefIDIdx
    let ci:NoContraBrokersGrp = {
        ContraBroker = contraBroker
        ContraTrader = contraTrader
        ContraTradeQty = contraTradeQty
        ContraTradeTime = contraTradeTime
        ContraLegRefID = contraLegRefID
    }
    ci


// group
let ReadNoAffectedOrdersGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoAffectedOrdersGrp =
    let origClOrdID = ReadFieldIdxOrdered true bs index 41 ReadOrigClOrdIDIdx
    let affectedOrderID = ReadOptionalFieldIdxOrdered true bs index 535 ReadAffectedOrderIDIdx
    let affectedSecondaryOrderID = ReadOptionalFieldIdxOrdered true bs index 536 ReadAffectedSecondaryOrderIDIdx
    let ci:NoAffectedOrdersGrp = {
        OrigClOrdID = origClOrdID
        AffectedOrderID = affectedOrderID
        AffectedSecondaryOrderID = affectedSecondaryOrderID
    }
    ci


// group
let ReadNoBidDescriptorsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoBidDescriptorsGrp =
    let bidDescriptorType = ReadFieldIdxOrdered true bs index 399 ReadBidDescriptorTypeIdx
    let bidDescriptor = ReadOptionalFieldIdxOrdered true bs index 400 ReadBidDescriptorIdx
    let sideValueInd = ReadOptionalFieldIdxOrdered true bs index 401 ReadSideValueIndIdx
    let liquidityValue = ReadOptionalFieldIdxOrdered true bs index 404 ReadLiquidityValueIdx
    let liquidityNumSecurities = ReadOptionalFieldIdxOrdered true bs index 441 ReadLiquidityNumSecuritiesIdx
    let liquidityPctLow = ReadOptionalFieldIdxOrdered true bs index 402 ReadLiquidityPctLowIdx
    let liquidityPctHigh = ReadOptionalFieldIdxOrdered true bs index 403 ReadLiquidityPctHighIdx
    let eFPTrackingError = ReadOptionalFieldIdxOrdered true bs index 405 ReadEFPTrackingErrorIdx
    let fairValue = ReadOptionalFieldIdxOrdered true bs index 406 ReadFairValueIdx
    let outsideIndexPct = ReadOptionalFieldIdxOrdered true bs index 407 ReadOutsideIndexPctIdx
    let valueOfFutures = ReadOptionalFieldIdxOrdered true bs index 408 ReadValueOfFuturesIdx
    let ci:NoBidDescriptorsGrp = {
        BidDescriptorType = bidDescriptorType
        BidDescriptor = bidDescriptor
        SideValueInd = sideValueInd
        LiquidityValue = liquidityValue
        LiquidityNumSecurities = liquidityNumSecurities
        LiquidityPctLow = liquidityPctLow
        LiquidityPctHigh = liquidityPctHigh
        EFPTrackingError = eFPTrackingError
        FairValue = fairValue
        OutsideIndexPct = outsideIndexPct
        ValueOfFutures = valueOfFutures
    }
    ci


// group
let ReadNoBidComponentsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoBidComponentsGrp =
    let listID = ReadFieldIdxOrdered true bs index 66 ReadListIDIdx
    let side = ReadOptionalFieldIdxOrdered true bs index 54 ReadSideIdx
    let tradingSessionID = ReadOptionalFieldIdxOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdxOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let netGrossInd = ReadOptionalFieldIdxOrdered true bs index 430 ReadNetGrossIndIdx
    let settlType = ReadOptionalFieldIdxOrdered true bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldIdxOrdered true bs index 64 ReadSettlDateIdx
    let account = ReadOptionalFieldIdxOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdxOrdered true bs index 660 ReadAcctIDSourceIdx
    let ci:NoBidComponentsGrp = {
        ListID = listID
        Side = side
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        NetGrossInd = netGrossInd
        SettlType = settlType
        SettlDate = settlDate
        Account = account
        AcctIDSource = acctIDSource
    }
    ci


// group
let ReadListStatusNoOrdersGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : ListStatusNoOrdersGrp =
    let clOrdID = ReadFieldIdxOrdered true bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdxOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let cumQty = ReadFieldIdxOrdered true bs index 14 ReadCumQtyIdx
    let ordStatus = ReadFieldIdxOrdered true bs index 39 ReadOrdStatusIdx
    let workingIndicator = ReadOptionalFieldIdxOrdered true bs index 636 ReadWorkingIndicatorIdx
    let leavesQty = ReadFieldIdxOrdered true bs index 151 ReadLeavesQtyIdx
    let cxlQty = ReadFieldIdxOrdered true bs index 84 ReadCxlQtyIdx
    let avgPx = ReadFieldIdxOrdered true bs index 6 ReadAvgPxIdx
    let ordRejReason = ReadOptionalFieldIdxOrdered true bs index 103 ReadOrdRejReasonIdx
    let text = ReadOptionalFieldIdxOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdxOrdered true bs index 354 ReadEncodedTextIdx
    let ci:ListStatusNoOrdersGrp = {
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        CumQty = cumQty
        OrdStatus = ordStatus
        WorkingIndicator = workingIndicator
        LeavesQty = leavesQty
        CxlQty = cxlQty
        AvgPx = avgPx
        OrdRejReason = ordRejReason
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadAllocationInstructionNoExecsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AllocationInstructionNoExecsGrp =
    let lastQty = ReadFieldIdxOrdered true bs index 32 ReadLastQtyIdx
    let execID = ReadOptionalFieldIdxOrdered true bs index 17 ReadExecIDIdx
    let secondaryExecID = ReadOptionalFieldIdxOrdered true bs index 527 ReadSecondaryExecIDIdx
    let lastPx = ReadOptionalFieldIdxOrdered true bs index 31 ReadLastPxIdx
    let lastParPx = ReadOptionalFieldIdxOrdered true bs index 669 ReadLastParPxIdx
    let lastCapacity = ReadOptionalFieldIdxOrdered true bs index 29 ReadLastCapacityIdx
    let ci:AllocationInstructionNoExecsGrp = {
        LastQty = lastQty
        ExecID = execID
        SecondaryExecID = secondaryExecID
        LastPx = lastPx
        LastParPx = lastParPx
        LastCapacity = lastCapacity
    }
    ci


// group
let ReadAllocationInstructionAckNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AllocationInstructionAckNoAllocsGrp =
    let allocAccount = ReadFieldIdxOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdxOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocPrice = ReadOptionalFieldIdxOrdered true bs index 366 ReadAllocPriceIdx
    let individualAllocID = ReadOptionalFieldIdxOrdered true bs index 467 ReadIndividualAllocIDIdx
    let individualAllocRejCode = ReadOptionalFieldIdxOrdered true bs index 776 ReadIndividualAllocRejCodeIdx
    let allocText = ReadOptionalFieldIdxOrdered true bs index 161 ReadAllocTextIdx
    let encodedAllocText = ReadOptionalFieldIdxOrdered true bs index 360 ReadEncodedAllocTextIdx
    let ci:AllocationInstructionAckNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocPrice = allocPrice
        IndividualAllocID = individualAllocID
        IndividualAllocRejCode = individualAllocRejCode
        AllocText = allocText
        EncodedAllocText = encodedAllocText
    }
    ci


// group
let ReadAllocationReportNoExecsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AllocationReportNoExecsGrp =
    let lastQty = ReadFieldIdxOrdered true bs index 32 ReadLastQtyIdx
    let execID = ReadOptionalFieldIdxOrdered true bs index 17 ReadExecIDIdx
    let secondaryExecID = ReadOptionalFieldIdxOrdered true bs index 527 ReadSecondaryExecIDIdx
    let lastPx = ReadOptionalFieldIdxOrdered true bs index 31 ReadLastPxIdx
    let lastParPx = ReadOptionalFieldIdxOrdered true bs index 669 ReadLastParPxIdx
    let lastCapacity = ReadOptionalFieldIdxOrdered true bs index 29 ReadLastCapacityIdx
    let ci:AllocationReportNoExecsGrp = {
        LastQty = lastQty
        ExecID = execID
        SecondaryExecID = secondaryExecID
        LastPx = lastPx
        LastParPx = lastParPx
        LastCapacity = lastCapacity
    }
    ci


// group
let ReadAllocationReportAckNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AllocationReportAckNoAllocsGrp =
    let allocAccount = ReadFieldIdxOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdxOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocPrice = ReadOptionalFieldIdxOrdered true bs index 366 ReadAllocPriceIdx
    let individualAllocID = ReadOptionalFieldIdxOrdered true bs index 467 ReadIndividualAllocIDIdx
    let individualAllocRejCode = ReadOptionalFieldIdxOrdered true bs index 776 ReadIndividualAllocRejCodeIdx
    let allocText = ReadOptionalFieldIdxOrdered true bs index 161 ReadAllocTextIdx
    let encodedAllocText = ReadOptionalFieldIdxOrdered true bs index 360 ReadEncodedAllocTextIdx
    let ci:AllocationReportAckNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocPrice = allocPrice
        IndividualAllocID = individualAllocID
        IndividualAllocRejCode = individualAllocRejCode
        AllocText = allocText
        EncodedAllocText = encodedAllocText
    }
    ci


// group
let ReadNoCapacitiesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoCapacitiesGrp =
    let orderCapacity = ReadFieldIdxOrdered true bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldIdxOrdered true bs index 529 ReadOrderRestrictionsIdx
    let orderCapacityQty = ReadFieldIdxOrdered true bs index 863 ReadOrderCapacityQtyIdx
    let ci:NoCapacitiesGrp = {
        OrderCapacity = orderCapacity
        OrderRestrictions = orderRestrictions
        OrderCapacityQty = orderCapacityQty
    }
    ci


// group
let ReadNoDatesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoDatesGrp =
    let tradeDate = ReadFieldIdxOrdered true bs index 75 ReadTradeDateIdx
    let transactTime = ReadOptionalFieldIdxOrdered true bs index 60 ReadTransactTimeIdx
    let ci:NoDatesGrp = {
        TradeDate = tradeDate
        TransactTime = transactTime
    }
    ci


// group
let ReadNoDistribInstsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoDistribInstsGrp =
    let distribPaymentMethod = ReadFieldIdxOrdered true bs index 477 ReadDistribPaymentMethodIdx
    let distribPercentage = ReadOptionalFieldIdxOrdered true bs index 512 ReadDistribPercentageIdx
    let cashDistribCurr = ReadOptionalFieldIdxOrdered true bs index 478 ReadCashDistribCurrIdx
    let cashDistribAgentName = ReadOptionalFieldIdxOrdered true bs index 498 ReadCashDistribAgentNameIdx
    let cashDistribAgentCode = ReadOptionalFieldIdxOrdered true bs index 499 ReadCashDistribAgentCodeIdx
    let cashDistribAgentAcctNumber = ReadOptionalFieldIdxOrdered true bs index 500 ReadCashDistribAgentAcctNumberIdx
    let cashDistribPayRef = ReadOptionalFieldIdxOrdered true bs index 501 ReadCashDistribPayRefIdx
    let cashDistribAgentAcctName = ReadOptionalFieldIdxOrdered true bs index 502 ReadCashDistribAgentAcctNameIdx
    let ci:NoDistribInstsGrp = {
        DistribPaymentMethod = distribPaymentMethod
        DistribPercentage = distribPercentage
        CashDistribCurr = cashDistribCurr
        CashDistribAgentName = cashDistribAgentName
        CashDistribAgentCode = cashDistribAgentCode
        CashDistribAgentAcctNumber = cashDistribAgentAcctNumber
        CashDistribPayRef = cashDistribPayRef
        CashDistribAgentAcctName = cashDistribAgentAcctName
    }
    ci


// group
let ReadNoExecsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoExecsGrp =
    let execID = ReadFieldIdxOrdered true bs index 17 ReadExecIDIdx
    let ci:NoExecsGrp = {
        ExecID = execID
    }
    ci


// group
let ReadNoTradesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoTradesGrp =
    let tradeReportID = ReadFieldIdxOrdered true bs index 571 ReadTradeReportIDIdx
    let secondaryTradeReportID = ReadOptionalFieldIdxOrdered true bs index 818 ReadSecondaryTradeReportIDIdx
    let ci:NoTradesGrp = {
        TradeReportID = tradeReportID
        SecondaryTradeReportID = secondaryTradeReportID
    }
    ci


// group
let ReadNoCollInquiryQualifierGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoCollInquiryQualifierGrp =
    let collInquiryQualifier = ReadFieldIdxOrdered true bs index 896 ReadCollInquiryQualifierIdx
    let ci:NoCollInquiryQualifierGrp = {
        CollInquiryQualifier = collInquiryQualifier
    }
    ci


// group
let ReadNoCompIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoCompIDsGrp =
    let refCompID = ReadFieldIdxOrdered true bs index 930 ReadRefCompIDIdx
    let refSubID = ReadOptionalFieldIdxOrdered true bs index 931 ReadRefSubIDIdx
    let locationID = ReadOptionalFieldIdxOrdered true bs index 283 ReadLocationIDIdx
    let deskID = ReadOptionalFieldIdxOrdered true bs index 284 ReadDeskIDIdx
    let ci:NoCompIDsGrp = {
        RefCompID = refCompID
        RefSubID = refSubID
        LocationID = locationID
        DeskID = deskID
    }
    ci


// group
let ReadNetworkStatusResponseNoCompIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NetworkStatusResponseNoCompIDsGrp =
    let refCompID = ReadFieldIdxOrdered true bs index 930 ReadRefCompIDIdx
    let refSubID = ReadOptionalFieldIdxOrdered true bs index 931 ReadRefSubIDIdx
    let locationID = ReadOptionalFieldIdxOrdered true bs index 283 ReadLocationIDIdx
    let deskID = ReadOptionalFieldIdxOrdered true bs index 284 ReadDeskIDIdx
    let statusValue = ReadOptionalFieldIdxOrdered true bs index 928 ReadStatusValueIdx
    let statusText = ReadOptionalFieldIdxOrdered true bs index 929 ReadStatusTextIdx
    let ci:NetworkStatusResponseNoCompIDsGrp = {
        RefCompID = refCompID
        RefSubID = refSubID
        LocationID = locationID
        DeskID = deskID
        StatusValue = statusValue
        StatusText = statusText
    }
    ci


// group
let ReadNoHopsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoHopsGrp =
    let hopCompID = ReadFieldIdxOrdered true bs index 628 ReadHopCompIDIdx
    let hopSendingTime = ReadOptionalFieldIdxOrdered true bs index 629 ReadHopSendingTimeIdx
    let hopRefID = ReadOptionalFieldIdxOrdered true bs index 630 ReadHopRefIDIdx
    let ci:NoHopsGrp = {
        HopCompID = hopCompID
        HopSendingTime = hopSendingTime
        HopRefID = hopRefID
    }
    ci


