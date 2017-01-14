module Fix44.CompoundItemReaders

open ReaderUtils
open Fix44.Fields
open Fix44.FieldReaders
open Fix44.CompoundItems


// group
let ReadNoUnderlyingSecurityAltIDGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoUnderlyingSecurityAltIDGrp =
    let underlyingSecurityAltID = ReadFieldIdx bs index 458 ReadUnderlyingSecurityAltIDIdx
    let underlyingSecurityAltIDSource = ReadOptionalFieldIdx bs index 459 ReadUnderlyingSecurityAltIDSourceIdx
    let ci:NoUnderlyingSecurityAltIDGrp = {
        UnderlyingSecurityAltID = underlyingSecurityAltID
        UnderlyingSecurityAltIDSource = underlyingSecurityAltIDSource
    }
    ci


// group
let ReadNoUnderlyingStipsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoUnderlyingStipsGrp =
    let underlyingStipType = ReadFieldIdx bs index 888 ReadUnderlyingStipTypeIdx
    let underlyingStipValue = ReadOptionalFieldIdx bs index 889 ReadUnderlyingStipValueIdx
    let ci:NoUnderlyingStipsGrp = {
        UnderlyingStipType = underlyingStipType
        UnderlyingStipValue = underlyingStipValue
    }
    ci


// component
let ReadUnderlyingInstrumentIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : UnderlyingInstrument =
    let underlyingSymbol = ReadFieldIdx bs index 311 ReadUnderlyingSymbolIdx
    let underlyingSymbolSfx = ReadOptionalFieldIdx bs index 312 ReadUnderlyingSymbolSfxIdx
    let underlyingSecurityID = ReadOptionalFieldIdx bs index 309 ReadUnderlyingSecurityIDIdx
    let underlyingSecurityIDSource = ReadOptionalFieldIdx bs index 305 ReadUnderlyingSecurityIDSourceIdx
    let noUnderlyingSecurityAltIDGrpIdx = ReadOptionalGroupIdx bs index 457 ReadNoUnderlyingSecurityAltIDGrpIdx
    let underlyingProduct = ReadOptionalFieldIdx bs index 462 ReadUnderlyingProductIdx
    let underlyingCFICode = ReadOptionalFieldIdx bs index 463 ReadUnderlyingCFICodeIdx
    let underlyingSecurityType = ReadOptionalFieldIdx bs index 310 ReadUnderlyingSecurityTypeIdx
    let underlyingSecuritySubType = ReadOptionalFieldIdx bs index 763 ReadUnderlyingSecuritySubTypeIdx
    let underlyingMaturityMonthYear = ReadOptionalFieldIdx bs index 313 ReadUnderlyingMaturityMonthYearIdx
    let underlyingMaturityDate = ReadOptionalFieldIdx bs index 542 ReadUnderlyingMaturityDateIdx
    let underlyingPutOrCall = ReadOptionalFieldIdx bs index 315 ReadUnderlyingPutOrCallIdx
    let underlyingCouponPaymentDate = ReadOptionalFieldIdx bs index 241 ReadUnderlyingCouponPaymentDateIdx
    let underlyingIssueDate = ReadOptionalFieldIdx bs index 242 ReadUnderlyingIssueDateIdx
    let underlyingRepoCollateralSecurityType = ReadOptionalFieldIdx bs index 243 ReadUnderlyingRepoCollateralSecurityTypeIdx
    let underlyingRepurchaseTerm = ReadOptionalFieldIdx bs index 244 ReadUnderlyingRepurchaseTermIdx
    let underlyingRepurchaseRate = ReadOptionalFieldIdx bs index 245 ReadUnderlyingRepurchaseRateIdx
    let underlyingFactor = ReadOptionalFieldIdx bs index 246 ReadUnderlyingFactorIdx
    let underlyingCreditRating = ReadOptionalFieldIdx bs index 256 ReadUnderlyingCreditRatingIdx
    let underlyingInstrRegistry = ReadOptionalFieldIdx bs index 595 ReadUnderlyingInstrRegistryIdx
    let underlyingCountryOfIssue = ReadOptionalFieldIdx bs index 592 ReadUnderlyingCountryOfIssueIdx
    let underlyingStateOrProvinceOfIssue = ReadOptionalFieldIdx bs index 593 ReadUnderlyingStateOrProvinceOfIssueIdx
    let underlyingLocaleOfIssue = ReadOptionalFieldIdx bs index 594 ReadUnderlyingLocaleOfIssueIdx
    let underlyingRedemptionDate = ReadOptionalFieldIdx bs index 247 ReadUnderlyingRedemptionDateIdx
    let underlyingStrikePrice = ReadOptionalFieldIdx bs index 316 ReadUnderlyingStrikePriceIdx
    let underlyingStrikeCurrency = ReadOptionalFieldIdx bs index 941 ReadUnderlyingStrikeCurrencyIdx
    let underlyingOptAttribute = ReadOptionalFieldIdx bs index 317 ReadUnderlyingOptAttributeIdx
    let underlyingContractMultiplier = ReadOptionalFieldIdx bs index 436 ReadUnderlyingContractMultiplierIdx
    let underlyingCouponRate = ReadOptionalFieldIdx bs index 435 ReadUnderlyingCouponRateIdx
    let underlyingSecurityExchange = ReadOptionalFieldIdx bs index 308 ReadUnderlyingSecurityExchangeIdx
    let underlyingIssuer = ReadOptionalFieldIdx bs index 306 ReadUnderlyingIssuerIdx
    let encodedUnderlyingIssuer = ReadOptionalFieldIdx bs index 362 ReadEncodedUnderlyingIssuerIdx
    let underlyingSecurityDesc = ReadOptionalFieldIdx bs index 307 ReadUnderlyingSecurityDescIdx
    let encodedUnderlyingSecurityDesc = ReadOptionalFieldIdx bs index 364 ReadEncodedUnderlyingSecurityDescIdx
    let underlyingCPProgram = ReadOptionalFieldIdx bs index 877 ReadUnderlyingCPProgramIdx
    let underlyingCPRegType = ReadOptionalFieldIdx bs index 878 ReadUnderlyingCPRegTypeIdx
    let underlyingCurrency = ReadOptionalFieldIdx bs index 318 ReadUnderlyingCurrencyIdx
    let underlyingQty = ReadOptionalFieldIdx bs index 879 ReadUnderlyingQtyIdx
    let underlyingPx = ReadOptionalFieldIdx bs index 810 ReadUnderlyingPxIdx
    let underlyingDirtyPrice = ReadOptionalFieldIdx bs index 882 ReadUnderlyingDirtyPriceIdx
    let underlyingEndPrice = ReadOptionalFieldIdx bs index 883 ReadUnderlyingEndPriceIdx
    let underlyingStartValue = ReadOptionalFieldIdx bs index 884 ReadUnderlyingStartValueIdx
    let underlyingCurrentValue = ReadOptionalFieldIdx bs index 885 ReadUnderlyingCurrentValueIdx
    let underlyingEndValue = ReadOptionalFieldIdx bs index 886 ReadUnderlyingEndValueIdx
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
    let underlyingInstrument = ReadComponentIdx bs index ReadUnderlyingInstrumentIdx
    let collAction = ReadOptionalFieldIdx bs index 944 ReadCollActionIdx
    let ci:CollateralResponseNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    ci


// group
let ReadCollateralAssignmentNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CollateralAssignmentNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentIdx bs index ReadUnderlyingInstrumentIdx
    let collAction = ReadOptionalFieldIdx bs index 944 ReadCollActionIdx
    let ci:CollateralAssignmentNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    ci


// group
let ReadCollateralRequestNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CollateralRequestNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentIdx bs index ReadUnderlyingInstrumentIdx
    let collAction = ReadOptionalFieldIdx bs index 944 ReadCollActionIdx
    let ci:CollateralRequestNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    ci


// group
let ReadPositionReportNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionReportNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentIdx bs index ReadUnderlyingInstrumentIdx
    let underlyingSettlPrice = ReadFieldIdx bs index 732 ReadUnderlyingSettlPriceIdx
    let underlyingSettlPriceType = ReadFieldIdx bs index 733 ReadUnderlyingSettlPriceTypeIdx
    let ci:PositionReportNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        UnderlyingSettlPrice = underlyingSettlPrice
        UnderlyingSettlPriceType = underlyingSettlPriceType
    }
    ci


// group
let ReadNoNestedPartySubIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNestedPartySubIDsGrp =
    let nestedPartySubID = ReadFieldIdx bs index 545 ReadNestedPartySubIDIdx
    let nestedPartySubIDType = ReadOptionalFieldIdx bs index 805 ReadNestedPartySubIDTypeIdx
    let ci:NoNestedPartySubIDsGrp = {
        NestedPartySubID = nestedPartySubID
        NestedPartySubIDType = nestedPartySubIDType
    }
    ci


// group
let ReadNoNestedPartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNestedPartyIDsGrp =
    let nestedPartyID = ReadFieldIdx bs index 524 ReadNestedPartyIDIdx
    let nestedPartyIDSource = ReadOptionalFieldIdx bs index 525 ReadNestedPartyIDSourceIdx
    let nestedPartyRole = ReadOptionalFieldIdx bs index 538 ReadNestedPartyRoleIdx
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
    let posType = ReadFieldIdx bs index 703 ReadPosTypeIdx
    let longQty = ReadOptionalFieldIdx bs index 704 ReadLongQtyIdx
    let shortQty = ReadOptionalFieldIdx bs index 705 ReadShortQtyIdx
    let posQtyStatus = ReadOptionalFieldIdx bs index 706 ReadPosQtyStatusIdx
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
    let registDtls = ReadFieldIdx bs index 509 ReadRegistDtlsIdx
    let registEmail = ReadOptionalFieldIdx bs index 511 ReadRegistEmailIdx
    let mailingDtls = ReadOptionalFieldIdx bs index 474 ReadMailingDtlsIdx
    let mailingInst = ReadOptionalFieldIdx bs index 482 ReadMailingInstIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let ownerType = ReadOptionalFieldIdx bs index 522 ReadOwnerTypeIdx
    let dateOfBirth = ReadOptionalFieldIdx bs index 486 ReadDateOfBirthIdx
    let investorCountryOfResidence = ReadOptionalFieldIdx bs index 475 ReadInvestorCountryOfResidenceIdx
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
    let nested2PartySubID = ReadFieldIdx bs index 760 ReadNested2PartySubIDIdx
    let nested2PartySubIDType = ReadOptionalFieldIdx bs index 807 ReadNested2PartySubIDTypeIdx
    let ci:NoNested2PartySubIDsGrp = {
        Nested2PartySubID = nested2PartySubID
        Nested2PartySubIDType = nested2PartySubIDType
    }
    ci


// group
let ReadNoNested2PartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNested2PartyIDsGrp =
    let nested2PartyID = ReadFieldIdx bs index 757 ReadNested2PartyIDIdx
    let nested2PartyIDSource = ReadOptionalFieldIdx bs index 758 ReadNested2PartyIDSourceIdx
    let nested2PartyRole = ReadOptionalFieldIdx bs index 759 ReadNested2PartyRoleIdx
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
    let allocAccount = ReadFieldIdx bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdx bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldIdx bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldIdx bs index 467 ReadIndividualAllocIDIdx
    let noNested2PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 756 ReadNoNested2PartyIDsGrpIdx
    let allocQty = ReadOptionalFieldIdx bs index 80 ReadAllocQtyIdx
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
    let legSecurityAltID = ReadFieldIdx bs index 605 ReadLegSecurityAltIDIdx
    let legSecurityAltIDSource = ReadOptionalFieldIdx bs index 606 ReadLegSecurityAltIDSourceIdx
    let ci:NoLegSecurityAltIDGrp = {
        LegSecurityAltID = legSecurityAltID
        LegSecurityAltIDSource = legSecurityAltIDSource
    }
    ci


// component
let ReadInstrumentLegFGIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentLegFG =
    let legSymbol = ReadFieldIdx bs index 600 ReadLegSymbolIdx
    let legSymbolSfx = ReadOptionalFieldIdx bs index 601 ReadLegSymbolSfxIdx
    let legSecurityID = ReadOptionalFieldIdx bs index 602 ReadLegSecurityIDIdx
    let legSecurityIDSource = ReadOptionalFieldIdx bs index 603 ReadLegSecurityIDSourceIdx
    let noLegSecurityAltIDGrpIdx = ReadOptionalGroupIdx bs index 604 ReadNoLegSecurityAltIDGrpIdx
    let legProduct = ReadOptionalFieldIdx bs index 607 ReadLegProductIdx
    let legCFICode = ReadOptionalFieldIdx bs index 608 ReadLegCFICodeIdx
    let legSecurityType = ReadOptionalFieldIdx bs index 609 ReadLegSecurityTypeIdx
    let legSecuritySubType = ReadOptionalFieldIdx bs index 764 ReadLegSecuritySubTypeIdx
    let legMaturityMonthYear = ReadOptionalFieldIdx bs index 610 ReadLegMaturityMonthYearIdx
    let legMaturityDate = ReadOptionalFieldIdx bs index 611 ReadLegMaturityDateIdx
    let legCouponPaymentDate = ReadOptionalFieldIdx bs index 248 ReadLegCouponPaymentDateIdx
    let legIssueDate = ReadOptionalFieldIdx bs index 249 ReadLegIssueDateIdx
    let legRepoCollateralSecurityType = ReadOptionalFieldIdx bs index 250 ReadLegRepoCollateralSecurityTypeIdx
    let legRepurchaseTerm = ReadOptionalFieldIdx bs index 251 ReadLegRepurchaseTermIdx
    let legRepurchaseRate = ReadOptionalFieldIdx bs index 252 ReadLegRepurchaseRateIdx
    let legFactor = ReadOptionalFieldIdx bs index 253 ReadLegFactorIdx
    let legCreditRating = ReadOptionalFieldIdx bs index 257 ReadLegCreditRatingIdx
    let legInstrRegistry = ReadOptionalFieldIdx bs index 599 ReadLegInstrRegistryIdx
    let legCountryOfIssue = ReadOptionalFieldIdx bs index 596 ReadLegCountryOfIssueIdx
    let legStateOrProvinceOfIssue = ReadOptionalFieldIdx bs index 597 ReadLegStateOrProvinceOfIssueIdx
    let legLocaleOfIssue = ReadOptionalFieldIdx bs index 598 ReadLegLocaleOfIssueIdx
    let legRedemptionDate = ReadOptionalFieldIdx bs index 254 ReadLegRedemptionDateIdx
    let legStrikePrice = ReadOptionalFieldIdx bs index 612 ReadLegStrikePriceIdx
    let legStrikeCurrency = ReadOptionalFieldIdx bs index 942 ReadLegStrikeCurrencyIdx
    let legOptAttribute = ReadOptionalFieldIdx bs index 613 ReadLegOptAttributeIdx
    let legContractMultiplier = ReadOptionalFieldIdx bs index 614 ReadLegContractMultiplierIdx
    let legCouponRate = ReadOptionalFieldIdx bs index 615 ReadLegCouponRateIdx
    let legSecurityExchange = ReadOptionalFieldIdx bs index 616 ReadLegSecurityExchangeIdx
    let legIssuer = ReadOptionalFieldIdx bs index 617 ReadLegIssuerIdx
    let encodedLegIssuer = ReadOptionalFieldIdx bs index 618 ReadEncodedLegIssuerIdx
    let legSecurityDesc = ReadOptionalFieldIdx bs index 620 ReadLegSecurityDescIdx
    let encodedLegSecurityDesc = ReadOptionalFieldIdx bs index 621 ReadEncodedLegSecurityDescIdx
    let legRatioQty = ReadOptionalFieldIdx bs index 623 ReadLegRatioQtyIdx
    let legSide = ReadOptionalFieldIdx bs index 624 ReadLegSideIdx
    let legCurrency = ReadOptionalFieldIdx bs index 556 ReadLegCurrencyIdx
    let legPool = ReadOptionalFieldIdx bs index 740 ReadLegPoolIdx
    let legDatedDate = ReadOptionalFieldIdx bs index 739 ReadLegDatedDateIdx
    let legContractSettlMonth = ReadOptionalFieldIdx bs index 955 ReadLegContractSettlMonthIdx
    let legInterestAccrualDate = ReadOptionalFieldIdx bs index 956 ReadLegInterestAccrualDateIdx
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
    let legStipulationType = ReadFieldIdx bs index 688 ReadLegStipulationTypeIdx
    let legStipulationValue = ReadOptionalFieldIdx bs index 689 ReadLegStipulationValueIdx
    let ci:NoLegStipulationsGrp = {
        LegStipulationType = legStipulationType
        LegStipulationValue = legStipulationValue
    }
    ci


// group
let ReadTradeCaptureReportAckNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportAckNoLegsGrp =
    let instrumentLegFG = ReadComponentIdx bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdx bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdx bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let legPositionEffect = ReadOptionalFieldIdx bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldIdx bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldIdx bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldIdx bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldIdx bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdx bs index 588 ReadLegSettlDateIdx
    let legLastPx = ReadOptionalFieldIdx bs index 637 ReadLegLastPxIdx
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
    let partySubID = ReadFieldIdx bs index 523 ReadPartySubIDIdx
    let partySubIDType = ReadOptionalFieldIdx bs index 803 ReadPartySubIDTypeIdx
    let ci:NoPartySubIDsGrp = {
        PartySubID = partySubID
        PartySubIDType = partySubIDType
    }
    ci


// group
let ReadNoPartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoPartyIDsGrp =
    let partyID = ReadFieldIdx bs index 448 ReadPartyIDIdx
    let partyIDSource = ReadOptionalFieldIdx bs index 447 ReadPartyIDSourceIdx
    let partyRole = ReadOptionalFieldIdx bs index 452 ReadPartyRoleIdx
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
    let clearingInstruction = ReadFieldIdx bs index 577 ReadClearingInstructionIdx
    let ci:NoClearingInstructionsGrp = {
        ClearingInstruction = clearingInstruction
    }
    ci


// component
let ReadCommissionDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CommissionData =
    let commission = ReadOptionalFieldIdx bs index 12 ReadCommissionIdx
    let commType = ReadOptionalFieldIdx bs index 13 ReadCommTypeIdx
    let commCurrency = ReadOptionalFieldIdx bs index 479 ReadCommCurrencyIdx
    let fundRenewWaiv = ReadOptionalFieldIdx bs index 497 ReadFundRenewWaivIdx
    let ci:CommissionData = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    ci


// group
let ReadNoContAmtsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoContAmtsGrp =
    let contAmtType = ReadFieldIdx bs index 519 ReadContAmtTypeIdx
    let contAmtValue = ReadOptionalFieldIdx bs index 520 ReadContAmtValueIdx
    let contAmtCurr = ReadOptionalFieldIdx bs index 521 ReadContAmtCurrIdx
    let ci:NoContAmtsGrp = {
        ContAmtType = contAmtType
        ContAmtValue = contAmtValue
        ContAmtCurr = contAmtCurr
    }
    ci


// group
let ReadNoStipulationsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoStipulationsGrp =
    let stipulationType = ReadFieldIdx bs index 233 ReadStipulationTypeIdx
    let stipulationValue = ReadOptionalFieldIdx bs index 234 ReadStipulationValueIdx
    let ci:NoStipulationsGrp = {
        StipulationType = stipulationType
        StipulationValue = stipulationValue
    }
    ci


// group
let ReadNoMiscFeesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMiscFeesGrp =
    let miscFeeAmt = ReadFieldIdx bs index 137 ReadMiscFeeAmtIdx
    let miscFeeCurr = ReadOptionalFieldIdx bs index 138 ReadMiscFeeCurrIdx
    let miscFeeType = ReadOptionalFieldIdx bs index 139 ReadMiscFeeTypeIdx
    let miscFeeBasis = ReadOptionalFieldIdx bs index 891 ReadMiscFeeBasisIdx
    let ci:NoMiscFeesGrp = {
        MiscFeeAmt = miscFeeAmt
        MiscFeeCurr = miscFeeCurr
        MiscFeeType = miscFeeType
        MiscFeeBasis = miscFeeBasis
    }
    ci


// group
let ReadTradeCaptureReportNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportNoAllocsGrp =
    let allocAccount = ReadFieldIdx bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdx bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldIdx bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldIdx bs index 467 ReadIndividualAllocIDIdx
    let noNested2PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 756 ReadNoNested2PartyIDsGrpIdx
    let allocQty = ReadOptionalFieldIdx bs index 80 ReadAllocQtyIdx
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
    let side = ReadFieldIdx bs index 54 ReadSideIdx
    let orderID = ReadFieldIdx bs index 37 ReadOrderIDIdx
    let secondaryOrderID = ReadOptionalFieldIdx bs index 198 ReadSecondaryOrderIDIdx
    let clOrdID = ReadOptionalFieldIdx bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdx bs index 526 ReadSecondaryClOrdIDIdx
    let listID = ReadOptionalFieldIdx bs index 66 ReadListIDIdx
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let account = ReadOptionalFieldIdx bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdx bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldIdx bs index 581 ReadAccountTypeIdx
    let processCode = ReadOptionalFieldIdx bs index 81 ReadProcessCodeIdx
    let oddLot = ReadOptionalFieldIdx bs index 575 ReadOddLotIdx
    let noClearingInstructionsGrpIdx = ReadOptionalGroupIdx bs index 576 ReadNoClearingInstructionsGrpIdx
    let clearingFeeIndicator = ReadOptionalFieldIdx bs index 635 ReadClearingFeeIndicatorIdx
    let tradeInputSource = ReadOptionalFieldIdx bs index 578 ReadTradeInputSourceIdx
    let tradeInputDevice = ReadOptionalFieldIdx bs index 579 ReadTradeInputDeviceIdx
    let orderInputDevice = ReadOptionalFieldIdx bs index 821 ReadOrderInputDeviceIdx
    let currency = ReadOptionalFieldIdx bs index 15 ReadCurrencyIdx
    let complianceID = ReadOptionalFieldIdx bs index 376 ReadComplianceIDIdx
    let solicitedFlag = ReadOptionalFieldIdx bs index 377 ReadSolicitedFlagIdx
    let orderCapacity = ReadOptionalFieldIdx bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldIdx bs index 529 ReadOrderRestrictionsIdx
    let custOrderCapacity = ReadOptionalFieldIdx bs index 582 ReadCustOrderCapacityIdx
    let ordType = ReadOptionalFieldIdx bs index 40 ReadOrdTypeIdx
    let execInst = ReadOptionalFieldIdx bs index 18 ReadExecInstIdx
    let transBkdTime = ReadOptionalFieldIdx bs index 483 ReadTransBkdTimeIdx
    let tradingSessionID = ReadOptionalFieldIdx bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdx bs index 625 ReadTradingSessionSubIDIdx
    let timeBracket = ReadOptionalFieldIdx bs index 943 ReadTimeBracketIdx
    let commissionData = ReadComponentIdx bs index ReadCommissionDataIdx
    let grossTradeAmt = ReadOptionalFieldIdx bs index 381 ReadGrossTradeAmtIdx
    let numDaysInterest = ReadOptionalFieldIdx bs index 157 ReadNumDaysInterestIdx
    let exDate = ReadOptionalFieldIdx bs index 230 ReadExDateIdx
    let accruedInterestRate = ReadOptionalFieldIdx bs index 158 ReadAccruedInterestRateIdx
    let accruedInterestAmt = ReadOptionalFieldIdx bs index 159 ReadAccruedInterestAmtIdx
    let interestAtMaturity = ReadOptionalFieldIdx bs index 738 ReadInterestAtMaturityIdx
    let endAccruedInterestAmt = ReadOptionalFieldIdx bs index 920 ReadEndAccruedInterestAmtIdx
    let startCash = ReadOptionalFieldIdx bs index 921 ReadStartCashIdx
    let endCash = ReadOptionalFieldIdx bs index 922 ReadEndCashIdx
    let concession = ReadOptionalFieldIdx bs index 238 ReadConcessionIdx
    let totalTakedown = ReadOptionalFieldIdx bs index 237 ReadTotalTakedownIdx
    let netMoney = ReadOptionalFieldIdx bs index 118 ReadNetMoneyIdx
    let settlCurrAmt = ReadOptionalFieldIdx bs index 119 ReadSettlCurrAmtIdx
    let settlCurrency = ReadOptionalFieldIdx bs index 120 ReadSettlCurrencyIdx
    let settlCurrFxRate = ReadOptionalFieldIdx bs index 155 ReadSettlCurrFxRateIdx
    let settlCurrFxRateCalc = ReadOptionalFieldIdx bs index 156 ReadSettlCurrFxRateCalcIdx
    let positionEffect = ReadOptionalFieldIdx bs index 77 ReadPositionEffectIdx
    let text = ReadOptionalFieldIdx bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdx bs index 354 ReadEncodedTextIdx
    let sideMultiLegReportingType = ReadOptionalFieldIdx bs index 752 ReadSideMultiLegReportingTypeIdx
    let noContAmtsGrpIdx = ReadOptionalGroupIdx bs index 518 ReadNoContAmtsGrpIdx
    let noStipulationsGrpIdx = ReadOptionalGroupIdx bs index 232 ReadNoStipulationsGrpIdx
    let noMiscFeesGrpIdx = ReadOptionalGroupIdx bs index 136 ReadNoMiscFeesGrpIdx
    let exchangeRule = ReadOptionalFieldIdx bs index 825 ReadExchangeRuleIdx
    let tradeAllocIndicator = ReadOptionalFieldIdx bs index 826 ReadTradeAllocIndicatorIdx
    let preallocMethod = ReadOptionalFieldIdx bs index 591 ReadPreallocMethodIdx
    let allocID = ReadOptionalFieldIdx bs index 70 ReadAllocIDIdx
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
    let instrumentLegFG = ReadComponentIdx bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdx bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdx bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let legPositionEffect = ReadOptionalFieldIdx bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldIdx bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldIdx bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldIdx bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldIdx bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdx bs index 588 ReadLegSettlDateIdx
    let legLastPx = ReadOptionalFieldIdx bs index 637 ReadLegLastPxIdx
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
    let posAmtType = ReadFieldIdx bs index 707 ReadPosAmtTypeIdx
    let posAmt = ReadFieldIdx bs index 708 ReadPosAmtIdx
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
    let settlPartySubID = ReadFieldIdx bs index 785 ReadSettlPartySubIDIdx
    let settlPartySubIDType = ReadOptionalFieldIdx bs index 786 ReadSettlPartySubIDTypeIdx
    let ci:NoSettlPartySubIDsGrp = {
        SettlPartySubID = settlPartySubID
        SettlPartySubIDType = settlPartySubIDType
    }
    ci


// group
let ReadNoSettlPartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSettlPartyIDsGrp =
    let settlPartyID = ReadFieldIdx bs index 782 ReadSettlPartyIDIdx
    let settlPartyIDSource = ReadOptionalFieldIdx bs index 783 ReadSettlPartyIDSourceIdx
    let settlPartyRole = ReadOptionalFieldIdx bs index 784 ReadSettlPartyRoleIdx
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
    let settlInstSource = ReadFieldIdx bs index 165 ReadSettlInstSourceIdx
    let dlvyInstType = ReadOptionalFieldIdx bs index 787 ReadDlvyInstTypeIdx
    let noSettlPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 781 ReadNoSettlPartyIDsGrpIdx
    let ci:NoDlvyInstGrp = {
        SettlInstSource = settlInstSource
        DlvyInstType = dlvyInstType
        NoSettlPartyIDsGrp = noSettlPartyIDsGrp
    }
    ci


// component
let ReadSettlInstructionsDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SettlInstructionsData =
    let settlDeliveryType = ReadOptionalFieldIdx bs index 172 ReadSettlDeliveryTypeIdx
    let standInstDbType = ReadOptionalFieldIdx bs index 169 ReadStandInstDbTypeIdx
    let standInstDbName = ReadOptionalFieldIdx bs index 170 ReadStandInstDbNameIdx
    let standInstDbID = ReadOptionalFieldIdx bs index 171 ReadStandInstDbIDIdx
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
    let settlInstID = ReadFieldIdx bs index 162 ReadSettlInstIDIdx
    let settlInstTransType = ReadOptionalFieldIdx bs index 163 ReadSettlInstTransTypeIdx
    let settlInstRefID = ReadOptionalFieldIdx bs index 214 ReadSettlInstRefIDIdx
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let side = ReadOptionalFieldIdx bs index 54 ReadSideIdx
    let product = ReadOptionalFieldIdx bs index 460 ReadProductIdx
    let securityType = ReadOptionalFieldIdx bs index 167 ReadSecurityTypeIdx
    let cFICode = ReadOptionalFieldIdx bs index 461 ReadCFICodeIdx
    let effectiveTime = ReadOptionalFieldIdx bs index 168 ReadEffectiveTimeIdx
    let expireTime = ReadOptionalFieldIdx bs index 126 ReadExpireTimeIdx
    let lastUpdateTime = ReadOptionalFieldIdx bs index 779 ReadLastUpdateTimeIdx
    let settlInstructionsData = ReadComponentIdx bs index ReadSettlInstructionsDataIdx
    let paymentMethod = ReadOptionalFieldIdx bs index 492 ReadPaymentMethodIdx
    let paymentRef = ReadOptionalFieldIdx bs index 476 ReadPaymentRefIdx
    let cardHolderName = ReadOptionalFieldIdx bs index 488 ReadCardHolderNameIdx
    let cardNumber = ReadOptionalFieldIdx bs index 489 ReadCardNumberIdx
    let cardStartDate = ReadOptionalFieldIdx bs index 503 ReadCardStartDateIdx
    let cardExpDate = ReadOptionalFieldIdx bs index 490 ReadCardExpDateIdx
    let cardIssNum = ReadOptionalFieldIdx bs index 491 ReadCardIssNumIdx
    let paymentDate = ReadOptionalFieldIdx bs index 504 ReadPaymentDateIdx
    let paymentRemitterID = ReadOptionalFieldIdx bs index 505 ReadPaymentRemitterIDIdx
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
    let trdRegTimestamp = ReadFieldIdx bs index 769 ReadTrdRegTimestampIdx
    let trdRegTimestampType = ReadOptionalFieldIdx bs index 770 ReadTrdRegTimestampTypeIdx
    let trdRegTimestampOrigin = ReadOptionalFieldIdx bs index 771 ReadTrdRegTimestampOriginIdx
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
    let allocAccount = ReadFieldIdx bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdx bs index 661 ReadAllocAcctIDSourceIdx
    let matchStatus = ReadOptionalFieldIdx bs index 573 ReadMatchStatusIdx
    let allocPrice = ReadOptionalFieldIdx bs index 366 ReadAllocPriceIdx
    let allocQty = ReadFieldIdx bs index 80 ReadAllocQtyIdx
    let individualAllocID = ReadOptionalFieldIdx bs index 467 ReadIndividualAllocIDIdx
    let processCode = ReadOptionalFieldIdx bs index 81 ReadProcessCodeIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let notifyBrokerOfCredit = ReadOptionalFieldIdx bs index 208 ReadNotifyBrokerOfCreditIdx
    let allocHandlInst = ReadOptionalFieldIdx bs index 209 ReadAllocHandlInstIdx
    let allocText = ReadOptionalFieldIdx bs index 161 ReadAllocTextIdx
    let encodedAllocText = ReadOptionalFieldIdx bs index 360 ReadEncodedAllocTextIdx
    let commissionData = ReadComponentIdx bs index ReadCommissionDataIdx
    let allocAvgPx = ReadOptionalFieldIdx bs index 153 ReadAllocAvgPxIdx
    let allocNetMoney = ReadOptionalFieldIdx bs index 154 ReadAllocNetMoneyIdx
    let settlCurrAmt = ReadOptionalFieldIdx bs index 119 ReadSettlCurrAmtIdx
    let allocSettlCurrAmt = ReadOptionalFieldIdx bs index 737 ReadAllocSettlCurrAmtIdx
    let settlCurrency = ReadOptionalFieldIdx bs index 120 ReadSettlCurrencyIdx
    let allocSettlCurrency = ReadOptionalFieldIdx bs index 736 ReadAllocSettlCurrencyIdx
    let settlCurrFxRate = ReadOptionalFieldIdx bs index 155 ReadSettlCurrFxRateIdx
    let settlCurrFxRateCalc = ReadOptionalFieldIdx bs index 156 ReadSettlCurrFxRateCalcIdx
    let allocAccruedInterestAmt = ReadOptionalFieldIdx bs index 742 ReadAllocAccruedInterestAmtIdx
    let allocInterestAtMaturity = ReadOptionalFieldIdx bs index 741 ReadAllocInterestAtMaturityIdx
    let noMiscFeesGrpIdx = ReadOptionalGroupIdx bs index 136 ReadNoMiscFeesGrpIdx
    let noClearingInstructionsGrpIdx = ReadOptionalGroupIdx bs index 576 ReadNoClearingInstructionsGrpIdx
    let clearingFeeIndicator = ReadOptionalFieldIdx bs index 635 ReadClearingFeeIndicatorIdx
    let allocSettlInstType = ReadOptionalFieldIdx bs index 780 ReadAllocSettlInstTypeIdx
    let settlInstructionsData = ReadComponentIdx bs index ReadSettlInstructionsDataIdx
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
    let allocAccount = ReadFieldIdx bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdx bs index 661 ReadAllocAcctIDSourceIdx
    let matchStatus = ReadOptionalFieldIdx bs index 573 ReadMatchStatusIdx
    let allocPrice = ReadOptionalFieldIdx bs index 366 ReadAllocPriceIdx
    let allocQty = ReadOptionalFieldIdx bs index 80 ReadAllocQtyIdx
    let individualAllocID = ReadOptionalFieldIdx bs index 467 ReadIndividualAllocIDIdx
    let processCode = ReadOptionalFieldIdx bs index 81 ReadProcessCodeIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let notifyBrokerOfCredit = ReadOptionalFieldIdx bs index 208 ReadNotifyBrokerOfCreditIdx
    let allocHandlInst = ReadOptionalFieldIdx bs index 209 ReadAllocHandlInstIdx
    let allocText = ReadOptionalFieldIdx bs index 161 ReadAllocTextIdx
    let encodedAllocText = ReadOptionalFieldIdx bs index 360 ReadEncodedAllocTextIdx
    let commissionData = ReadComponentIdx bs index ReadCommissionDataIdx
    let allocAvgPx = ReadOptionalFieldIdx bs index 153 ReadAllocAvgPxIdx
    let allocNetMoney = ReadOptionalFieldIdx bs index 154 ReadAllocNetMoneyIdx
    let settlCurrAmt = ReadOptionalFieldIdx bs index 119 ReadSettlCurrAmtIdx
    let allocSettlCurrAmt = ReadOptionalFieldIdx bs index 737 ReadAllocSettlCurrAmtIdx
    let settlCurrency = ReadOptionalFieldIdx bs index 120 ReadSettlCurrencyIdx
    let allocSettlCurrency = ReadOptionalFieldIdx bs index 736 ReadAllocSettlCurrencyIdx
    let settlCurrFxRate = ReadOptionalFieldIdx bs index 155 ReadSettlCurrFxRateIdx
    let settlCurrFxRateCalc = ReadOptionalFieldIdx bs index 156 ReadSettlCurrFxRateCalcIdx
    let accruedInterestAmt = ReadOptionalFieldIdx bs index 159 ReadAccruedInterestAmtIdx
    let allocAccruedInterestAmt = ReadOptionalFieldIdx bs index 742 ReadAllocAccruedInterestAmtIdx
    let allocInterestAtMaturity = ReadOptionalFieldIdx bs index 741 ReadAllocInterestAtMaturityIdx
    let settlInstMode = ReadOptionalFieldIdx bs index 160 ReadSettlInstModeIdx
    let noMiscFeesGrpIdx = ReadOptionalGroupIdx bs index 136 ReadNoMiscFeesGrpIdx
    let noClearingInstructions = ReadOptionalFieldIdx bs index 576 ReadNoClearingInstructionsIdx
    let clearingInstruction = ReadOptionalFieldIdx bs index 577 ReadClearingInstructionIdx
    let clearingFeeIndicator = ReadOptionalFieldIdx bs index 635 ReadClearingFeeIndicatorIdx
    let allocSettlInstType = ReadOptionalFieldIdx bs index 780 ReadAllocSettlInstTypeIdx
    let settlInstructionsData = ReadComponentIdx bs index ReadSettlInstructionsDataIdx
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
    let clOrdID = ReadFieldIdx bs index 11 ReadClOrdIDIdx
    let orderID = ReadOptionalFieldIdx bs index 37 ReadOrderIDIdx
    let secondaryOrderID = ReadOptionalFieldIdx bs index 198 ReadSecondaryOrderIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdx bs index 526 ReadSecondaryClOrdIDIdx
    let listID = ReadOptionalFieldIdx bs index 66 ReadListIDIdx
    let noNested2PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 756 ReadNoNested2PartyIDsGrpIdx
    let orderQty = ReadOptionalFieldIdx bs index 38 ReadOrderQtyIdx
    let orderAvgPx = ReadOptionalFieldIdx bs index 799 ReadOrderAvgPxIdx
    let orderBookingQty = ReadOptionalFieldIdx bs index 800 ReadOrderBookingQtyIdx
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
    let underlyingInstrument = ReadComponentIdx bs index ReadUnderlyingInstrumentIdx
    let prevClosePx = ReadOptionalFieldIdx bs index 140 ReadPrevClosePxIdx
    let clOrdID = ReadOptionalFieldIdx bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdx bs index 526 ReadSecondaryClOrdIDIdx
    let side = ReadOptionalFieldIdx bs index 54 ReadSideIdx
    let price = ReadFieldIdx bs index 44 ReadPriceIdx
    let currency = ReadOptionalFieldIdx bs index 15 ReadCurrencyIdx
    let text = ReadOptionalFieldIdx bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdx bs index 354 ReadEncodedTextIdx
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
    let securityAltID = ReadFieldIdx bs index 455 ReadSecurityAltIDIdx
    let securityAltIDSource = ReadOptionalFieldIdx bs index 456 ReadSecurityAltIDSourceIdx
    let ci:NoSecurityAltIDGrp = {
        SecurityAltID = securityAltID
        SecurityAltIDSource = securityAltIDSource
    }
    ci


// group
let ReadNoEventsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoEventsGrp =
    let eventType = ReadFieldIdx bs index 865 ReadEventTypeIdx
    let eventDate = ReadOptionalFieldIdx bs index 866 ReadEventDateIdx
    let eventPx = ReadOptionalFieldIdx bs index 867 ReadEventPxIdx
    let eventText = ReadOptionalFieldIdx bs index 868 ReadEventTextIdx
    let ci:NoEventsGrp = {
        EventType = eventType
        EventDate = eventDate
        EventPx = eventPx
        EventText = eventText
    }
    ci


// component
let ReadInstrumentIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Instrument =
    let symbol = ReadFieldIdx bs index 55 ReadSymbolIdx
    let symbolSfx = ReadOptionalFieldIdx bs index 65 ReadSymbolSfxIdx
    let securityID = ReadOptionalFieldIdx bs index 48 ReadSecurityIDIdx
    let securityIDSource = ReadOptionalFieldIdx bs index 22 ReadSecurityIDSourceIdx
    let noSecurityAltIDGrpIdx = ReadOptionalGroupIdx bs index 454 ReadNoSecurityAltIDGrpIdx
    let product = ReadOptionalFieldIdx bs index 460 ReadProductIdx
    let cFICode = ReadOptionalFieldIdx bs index 461 ReadCFICodeIdx
    let securityType = ReadOptionalFieldIdx bs index 167 ReadSecurityTypeIdx
    let securitySubType = ReadOptionalFieldIdx bs index 762 ReadSecuritySubTypeIdx
    let maturityMonthYear = ReadOptionalFieldIdx bs index 200 ReadMaturityMonthYearIdx
    let maturityDate = ReadOptionalFieldIdx bs index 541 ReadMaturityDateIdx
    let putOrCall = ReadOptionalFieldIdx bs index 201 ReadPutOrCallIdx
    let couponPaymentDate = ReadOptionalFieldIdx bs index 224 ReadCouponPaymentDateIdx
    let issueDate = ReadOptionalFieldIdx bs index 225 ReadIssueDateIdx
    let repoCollateralSecurityType = ReadOptionalFieldIdx bs index 239 ReadRepoCollateralSecurityTypeIdx
    let repurchaseTerm = ReadOptionalFieldIdx bs index 226 ReadRepurchaseTermIdx
    let repurchaseRate = ReadOptionalFieldIdx bs index 227 ReadRepurchaseRateIdx
    let factor = ReadOptionalFieldIdx bs index 228 ReadFactorIdx
    let creditRating = ReadOptionalFieldIdx bs index 255 ReadCreditRatingIdx
    let instrRegistry = ReadOptionalFieldIdx bs index 543 ReadInstrRegistryIdx
    let countryOfIssue = ReadOptionalFieldIdx bs index 470 ReadCountryOfIssueIdx
    let stateOrProvinceOfIssue = ReadOptionalFieldIdx bs index 471 ReadStateOrProvinceOfIssueIdx
    let localeOfIssue = ReadOptionalFieldIdx bs index 472 ReadLocaleOfIssueIdx
    let redemptionDate = ReadOptionalFieldIdx bs index 240 ReadRedemptionDateIdx
    let strikePrice = ReadOptionalFieldIdx bs index 202 ReadStrikePriceIdx
    let strikeCurrency = ReadOptionalFieldIdx bs index 947 ReadStrikeCurrencyIdx
    let optAttribute = ReadOptionalFieldIdx bs index 206 ReadOptAttributeIdx
    let contractMultiplier = ReadOptionalFieldIdx bs index 231 ReadContractMultiplierIdx
    let couponRate = ReadOptionalFieldIdx bs index 223 ReadCouponRateIdx
    let securityExchange = ReadOptionalFieldIdx bs index 207 ReadSecurityExchangeIdx
    let issuer = ReadOptionalFieldIdx bs index 106 ReadIssuerIdx
    let encodedIssuer = ReadOptionalFieldIdx bs index 348 ReadEncodedIssuerIdx
    let securityDesc = ReadOptionalFieldIdx bs index 107 ReadSecurityDescIdx
    let encodedSecurityDesc = ReadOptionalFieldIdx bs index 350 ReadEncodedSecurityDescIdx
    let pool = ReadOptionalFieldIdx bs index 691 ReadPoolIdx
    let contractSettlMonth = ReadOptionalFieldIdx bs index 667 ReadContractSettlMonthIdx
    let cPProgram = ReadOptionalFieldIdx bs index 875 ReadCPProgramIdx
    let cPRegType = ReadOptionalFieldIdx bs index 876 ReadCPRegTypeIdx
    let noEventsGrpIdx = ReadOptionalGroupIdx bs index 864 ReadNoEventsGrpIdx
    let datedDate = ReadOptionalFieldIdx bs index 873 ReadDatedDateIdx
    let interestAccrualDate = ReadOptionalFieldIdx bs index 874 ReadInterestAccrualDateIdx
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
    let instrument = ReadComponentIdx bs index ReadInstrumentIdx
    let ci:NoStrikesGrp = {
        Instrument = instrument
    }
    ci


// group
let ReadNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoAllocsGrp =
    let allocAccount = ReadFieldIdx bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdx bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldIdx bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldIdx bs index 467 ReadIndividualAllocIDIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let allocQty = ReadOptionalFieldIdx bs index 80 ReadAllocQtyIdx
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
    let tradingSessionID = ReadFieldIdx bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdx bs index 625 ReadTradingSessionSubIDIdx
    let ci:NoTradingSessionsGrp = {
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
    }
    ci


// group
let ReadNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentIdx bs index ReadUnderlyingInstrumentIdx
    let ci:NoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
    }
    ci


// component
let ReadOrderQtyDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : OrderQtyData =
    let orderQty = ReadOptionalFieldIdx bs index 38 ReadOrderQtyIdx
    let cashOrderQty = ReadOptionalFieldIdx bs index 152 ReadCashOrderQtyIdx
    let orderPercent = ReadOptionalFieldIdx bs index 516 ReadOrderPercentIdx
    let roundingDirection = ReadOptionalFieldIdx bs index 468 ReadRoundingDirectionIdx
    let roundingModulus = ReadOptionalFieldIdx bs index 469 ReadRoundingModulusIdx
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
    let spread = ReadOptionalFieldIdx bs index 218 ReadSpreadIdx
    let benchmarkCurveCurrency = ReadOptionalFieldIdx bs index 220 ReadBenchmarkCurveCurrencyIdx
    let benchmarkCurveName = ReadOptionalFieldIdx bs index 221 ReadBenchmarkCurveNameIdx
    let benchmarkCurvePoint = ReadOptionalFieldIdx bs index 222 ReadBenchmarkCurvePointIdx
    let benchmarkPrice = ReadOptionalFieldIdx bs index 662 ReadBenchmarkPriceIdx
    let benchmarkPriceType = ReadOptionalFieldIdx bs index 663 ReadBenchmarkPriceTypeIdx
    let benchmarkSecurityID = ReadOptionalFieldIdx bs index 699 ReadBenchmarkSecurityIDIdx
    let benchmarkSecurityIDSource = ReadOptionalFieldIdx bs index 761 ReadBenchmarkSecurityIDSourceIdx
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
    let yieldType = ReadOptionalFieldIdx bs index 235 ReadYieldTypeIdx
    let yyield = ReadOptionalFieldIdx bs index 236 ReadYieldIdx
    let yieldCalcDate = ReadOptionalFieldIdx bs index 701 ReadYieldCalcDateIdx
    let yieldRedemptionDate = ReadOptionalFieldIdx bs index 696 ReadYieldRedemptionDateIdx
    let yieldRedemptionPrice = ReadOptionalFieldIdx bs index 697 ReadYieldRedemptionPriceIdx
    let yieldRedemptionPriceType = ReadOptionalFieldIdx bs index 698 ReadYieldRedemptionPriceTypeIdx
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
    let pegOffsetValue = ReadOptionalFieldIdx bs index 211 ReadPegOffsetValueIdx
    let pegMoveType = ReadOptionalFieldIdx bs index 835 ReadPegMoveTypeIdx
    let pegOffsetType = ReadOptionalFieldIdx bs index 836 ReadPegOffsetTypeIdx
    let pegLimitType = ReadOptionalFieldIdx bs index 837 ReadPegLimitTypeIdx
    let pegRoundDirection = ReadOptionalFieldIdx bs index 838 ReadPegRoundDirectionIdx
    let pegScope = ReadOptionalFieldIdx bs index 840 ReadPegScopeIdx
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
    let discretionInst = ReadOptionalFieldIdx bs index 388 ReadDiscretionInstIdx
    let discretionOffsetValue = ReadOptionalFieldIdx bs index 389 ReadDiscretionOffsetValueIdx
    let discretionMoveType = ReadOptionalFieldIdx bs index 841 ReadDiscretionMoveTypeIdx
    let discretionOffsetType = ReadOptionalFieldIdx bs index 842 ReadDiscretionOffsetTypeIdx
    let discretionLimitType = ReadOptionalFieldIdx bs index 843 ReadDiscretionLimitTypeIdx
    let discretionRoundDirection = ReadOptionalFieldIdx bs index 844 ReadDiscretionRoundDirectionIdx
    let discretionScope = ReadOptionalFieldIdx bs index 846 ReadDiscretionScopeIdx
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
    let clOrdID = ReadFieldIdx bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdx bs index 526 ReadSecondaryClOrdIDIdx
    let listSeqNo = ReadFieldIdx bs index 67 ReadListSeqNoIdx
    let clOrdLinkID = ReadOptionalFieldIdx bs index 583 ReadClOrdLinkIDIdx
    let settlInstMode = ReadOptionalFieldIdx bs index 160 ReadSettlInstModeIdx
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let tradeOriginationDate = ReadOptionalFieldIdx bs index 229 ReadTradeOriginationDateIdx
    let tradeDate = ReadOptionalFieldIdx bs index 75 ReadTradeDateIdx
    let account = ReadOptionalFieldIdx bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdx bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldIdx bs index 581 ReadAccountTypeIdx
    let dayBookingInst = ReadOptionalFieldIdx bs index 589 ReadDayBookingInstIdx
    let bookingUnit = ReadOptionalFieldIdx bs index 590 ReadBookingUnitIdx
    let allocID = ReadOptionalFieldIdx bs index 70 ReadAllocIDIdx
    let preallocMethod = ReadOptionalFieldIdx bs index 591 ReadPreallocMethodIdx
    let noAllocsGrpIdx = ReadOptionalGroupIdx bs index 78 ReadNoAllocsGrpIdx
    let settlType = ReadOptionalFieldIdx bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldIdx bs index 64 ReadSettlDateIdx
    let cashMargin = ReadOptionalFieldIdx bs index 544 ReadCashMarginIdx
    let clearingFeeIndicator = ReadOptionalFieldIdx bs index 635 ReadClearingFeeIndicatorIdx
    let handlInst = ReadOptionalFieldIdx bs index 21 ReadHandlInstIdx
    let execInst = ReadOptionalFieldIdx bs index 18 ReadExecInstIdx
    let minQty = ReadOptionalFieldIdx bs index 110 ReadMinQtyIdx
    let maxFloor = ReadOptionalFieldIdx bs index 111 ReadMaxFloorIdx
    let exDestination = ReadOptionalFieldIdx bs index 100 ReadExDestinationIdx
    let noTradingSessionsGrpIdx = ReadOptionalGroupIdx bs index 386 ReadNoTradingSessionsGrpIdx
    let processCode = ReadOptionalFieldIdx bs index 81 ReadProcessCodeIdx
    let instrument = ReadComponentIdx bs index ReadInstrumentIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let prevClosePx = ReadOptionalFieldIdx bs index 140 ReadPrevClosePxIdx
    let side = ReadFieldIdx bs index 54 ReadSideIdx
    let sideValueInd = ReadOptionalFieldIdx bs index 401 ReadSideValueIndIdx
    let locateReqd = ReadOptionalFieldIdx bs index 114 ReadLocateReqdIdx
    let transactTime = ReadOptionalFieldIdx bs index 60 ReadTransactTimeIdx
    let noStipulationsGrpIdx = ReadOptionalGroupIdx bs index 232 ReadNoStipulationsGrpIdx
    let qtyType = ReadOptionalFieldIdx bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentIdx bs index ReadOrderQtyDataIdx
    let ordType = ReadOptionalFieldIdx bs index 40 ReadOrdTypeIdx
    let priceType = ReadOptionalFieldIdx bs index 423 ReadPriceTypeIdx
    let price = ReadOptionalFieldIdx bs index 44 ReadPriceIdx
    let stopPx = ReadOptionalFieldIdx bs index 99 ReadStopPxIdx
    let spreadOrBenchmarkCurveData = ReadComponentIdx bs index ReadSpreadOrBenchmarkCurveDataIdx
    let yieldData = ReadComponentIdx bs index ReadYieldDataIdx
    let currency = ReadOptionalFieldIdx bs index 15 ReadCurrencyIdx
    let complianceID = ReadOptionalFieldIdx bs index 376 ReadComplianceIDIdx
    let solicitedFlag = ReadOptionalFieldIdx bs index 377 ReadSolicitedFlagIdx
    let iOIid = ReadOptionalFieldIdx bs index 23 ReadIOIidIdx
    let quoteID = ReadOptionalFieldIdx bs index 117 ReadQuoteIDIdx
    let timeInForce = ReadOptionalFieldIdx bs index 59 ReadTimeInForceIdx
    let effectiveTime = ReadOptionalFieldIdx bs index 168 ReadEffectiveTimeIdx
    let expireDate = ReadOptionalFieldIdx bs index 432 ReadExpireDateIdx
    let expireTime = ReadOptionalFieldIdx bs index 126 ReadExpireTimeIdx
    let gTBookingInst = ReadOptionalFieldIdx bs index 427 ReadGTBookingInstIdx
    let commissionData = ReadComponentIdx bs index ReadCommissionDataIdx
    let orderCapacity = ReadOptionalFieldIdx bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldIdx bs index 529 ReadOrderRestrictionsIdx
    let custOrderCapacity = ReadOptionalFieldIdx bs index 582 ReadCustOrderCapacityIdx
    let forexReq = ReadOptionalFieldIdx bs index 121 ReadForexReqIdx
    let settlCurrency = ReadOptionalFieldIdx bs index 120 ReadSettlCurrencyIdx
    let bookingType = ReadOptionalFieldIdx bs index 775 ReadBookingTypeIdx
    let text = ReadOptionalFieldIdx bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdx bs index 354 ReadEncodedTextIdx
    let settlDate2 = ReadOptionalFieldIdx bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldIdx bs index 192 ReadOrderQty2Idx
    let price2 = ReadOptionalFieldIdx bs index 640 ReadPrice2Idx
    let positionEffect = ReadOptionalFieldIdx bs index 77 ReadPositionEffectIdx
    let coveredOrUncovered = ReadOptionalFieldIdx bs index 203 ReadCoveredOrUncoveredIdx
    let maxShow = ReadOptionalFieldIdx bs index 210 ReadMaxShowIdx
    let pegInstructions = ReadComponentIdx bs index ReadPegInstructionsIdx
    let discretionInstructions = ReadComponentIdx bs index ReadDiscretionInstructionsIdx
    let targetStrategy = ReadOptionalFieldIdx bs index 847 ReadTargetStrategyIdx
    let targetStrategyParameters = ReadOptionalFieldIdx bs index 848 ReadTargetStrategyParametersIdx
    let participationRate = ReadOptionalFieldIdx bs index 849 ReadParticipationRateIdx
    let designation = ReadOptionalFieldIdx bs index 494 ReadDesignationIdx
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
    let commission = ReadFieldIdx bs index 12 ReadCommissionIdx
    let commType = ReadOptionalFieldIdx bs index 13 ReadCommTypeIdx
    let commCurrency = ReadOptionalFieldIdx bs index 479 ReadCommCurrencyIdx
    let fundRenewWaiv = ReadOptionalFieldIdx bs index 497 ReadFundRenewWaivIdx
    let ci:CommissionDataFG = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    ci


// group
let ReadBidResponseNoBidComponentsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : BidResponseNoBidComponentsGrp =
    let commissionDataFG = ReadComponentIdx bs index ReadCommissionDataFGIdx
    let listID = ReadOptionalFieldIdx bs index 66 ReadListIDIdx
    let country = ReadOptionalFieldIdx bs index 421 ReadCountryIdx
    let side = ReadOptionalFieldIdx bs index 54 ReadSideIdx
    let price = ReadOptionalFieldIdx bs index 44 ReadPriceIdx
    let priceType = ReadOptionalFieldIdx bs index 423 ReadPriceTypeIdx
    let fairValue = ReadOptionalFieldIdx bs index 406 ReadFairValueIdx
    let netGrossInd = ReadOptionalFieldIdx bs index 430 ReadNetGrossIndIdx
    let settlType = ReadOptionalFieldIdx bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldIdx bs index 64 ReadSettlDateIdx
    let tradingSessionID = ReadOptionalFieldIdx bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdx bs index 625 ReadTradingSessionSubIDIdx
    let text = ReadOptionalFieldIdx bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdx bs index 354 ReadEncodedTextIdx
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
    let legAllocAccount = ReadFieldIdx bs index 671 ReadLegAllocAccountIdx
    let legIndividualAllocID = ReadOptionalFieldIdx bs index 672 ReadLegIndividualAllocIDIdx
    let noNested2PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 756 ReadNoNested2PartyIDsGrpIdx
    let legAllocQty = ReadOptionalFieldIdx bs index 673 ReadLegAllocQtyIdx
    let legAllocAcctIDSource = ReadOptionalFieldIdx bs index 674 ReadLegAllocAcctIDSourceIdx
    let legSettlCurrency = ReadOptionalFieldIdx bs index 675 ReadLegSettlCurrencyIdx
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
    let instrumentLegFG = ReadComponentIdx bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdx bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdx bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let noLegAllocsGrpIdx = ReadOptionalGroupIdx bs index 670 ReadNoLegAllocsGrpIdx
    let legPositionEffect = ReadOptionalFieldIdx bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldIdx bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldIdx bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldIdx bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldIdx bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdx bs index 588 ReadLegSettlDateIdx
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
    let nested3PartySubID = ReadFieldIdx bs index 953 ReadNested3PartySubIDIdx
    let nested3PartySubIDType = ReadOptionalFieldIdx bs index 954 ReadNested3PartySubIDTypeIdx
    let ci:NoNested3PartySubIDsGrp = {
        Nested3PartySubID = nested3PartySubID
        Nested3PartySubIDType = nested3PartySubIDType
    }
    ci


// group
let ReadNoNested3PartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNested3PartyIDsGrp =
    let nested3PartyID = ReadFieldIdx bs index 949 ReadNested3PartyIDIdx
    let nested3PartyIDSource = ReadOptionalFieldIdx bs index 950 ReadNested3PartyIDSourceIdx
    let nested3PartyRole = ReadOptionalFieldIdx bs index 951 ReadNested3PartyRoleIdx
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
    let allocAccount = ReadFieldIdx bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdx bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldIdx bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldIdx bs index 467 ReadIndividualAllocIDIdx
    let noNested3PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 948 ReadNoNested3PartyIDsGrpIdx
    let allocQty = ReadOptionalFieldIdx bs index 80 ReadAllocQtyIdx
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
    let instrumentLegFG = ReadComponentIdx bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdx bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdx bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let noLegAllocsGrpIdx = ReadOptionalGroupIdx bs index 670 ReadNoLegAllocsGrpIdx
    let legPositionEffect = ReadOptionalFieldIdx bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldIdx bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldIdx bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldIdx bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldIdx bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdx bs index 588 ReadLegSettlDateIdx
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
    let allocAccount = ReadFieldIdx bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdx bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldIdx bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldIdx bs index 467 ReadIndividualAllocIDIdx
    let noNested3PartyIDsGrpIdx = ReadOptionalGroupIdx bs index 948 ReadNoNested3PartyIDsGrpIdx
    let allocQty = ReadOptionalFieldIdx bs index 80 ReadAllocQtyIdx
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
    let side = ReadFieldIdx bs index 54 ReadSideIdx
    let origClOrdID = ReadFieldIdx bs index 41 ReadOrigClOrdIDIdx
    let clOrdID = ReadFieldIdx bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdx bs index 526 ReadSecondaryClOrdIDIdx
    let clOrdLinkID = ReadOptionalFieldIdx bs index 583 ReadClOrdLinkIDIdx
    let origOrdModTime = ReadOptionalFieldIdx bs index 586 ReadOrigOrdModTimeIdx
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let tradeOriginationDate = ReadOptionalFieldIdx bs index 229 ReadTradeOriginationDateIdx
    let tradeDate = ReadOptionalFieldIdx bs index 75 ReadTradeDateIdx
    let orderQtyData = ReadComponentIdx bs index ReadOrderQtyDataIdx
    let complianceID = ReadOptionalFieldIdx bs index 376 ReadComplianceIDIdx
    let text = ReadOptionalFieldIdx bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdx bs index 354 ReadEncodedTextIdx
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
    let side = ReadFieldIdx bs index 54 ReadSideIdx
    let origClOrdID = ReadFieldIdx bs index 41 ReadOrigClOrdIDIdx
    let clOrdID = ReadFieldIdx bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdx bs index 526 ReadSecondaryClOrdIDIdx
    let clOrdLinkID = ReadOptionalFieldIdx bs index 583 ReadClOrdLinkIDIdx
    let origOrdModTime = ReadOptionalFieldIdx bs index 586 ReadOrigOrdModTimeIdx
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let tradeOriginationDate = ReadOptionalFieldIdx bs index 229 ReadTradeOriginationDateIdx
    let tradeDate = ReadOptionalFieldIdx bs index 75 ReadTradeDateIdx
    let account = ReadOptionalFieldIdx bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdx bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldIdx bs index 581 ReadAccountTypeIdx
    let dayBookingInst = ReadOptionalFieldIdx bs index 589 ReadDayBookingInstIdx
    let bookingUnit = ReadOptionalFieldIdx bs index 590 ReadBookingUnitIdx
    let preallocMethod = ReadOptionalFieldIdx bs index 591 ReadPreallocMethodIdx
    let allocID = ReadOptionalFieldIdx bs index 70 ReadAllocIDIdx
    let noAllocsGrpIdx = ReadOptionalGroupIdx bs index 78 ReadNoAllocsGrpIdx
    let qtyType = ReadOptionalFieldIdx bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentIdx bs index ReadOrderQtyDataIdx
    let commissionData = ReadComponentIdx bs index ReadCommissionDataIdx
    let orderCapacity = ReadOptionalFieldIdx bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldIdx bs index 529 ReadOrderRestrictionsIdx
    let custOrderCapacity = ReadOptionalFieldIdx bs index 582 ReadCustOrderCapacityIdx
    let forexReq = ReadOptionalFieldIdx bs index 121 ReadForexReqIdx
    let settlCurrency = ReadOptionalFieldIdx bs index 120 ReadSettlCurrencyIdx
    let bookingType = ReadOptionalFieldIdx bs index 775 ReadBookingTypeIdx
    let text = ReadOptionalFieldIdx bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdx bs index 354 ReadEncodedTextIdx
    let positionEffect = ReadOptionalFieldIdx bs index 77 ReadPositionEffectIdx
    let coveredOrUncovered = ReadOptionalFieldIdx bs index 203 ReadCoveredOrUncoveredIdx
    let cashMargin = ReadOptionalFieldIdx bs index 544 ReadCashMarginIdx
    let clearingFeeIndicator = ReadOptionalFieldIdx bs index 635 ReadClearingFeeIndicatorIdx
    let solicitedFlag = ReadOptionalFieldIdx bs index 377 ReadSolicitedFlagIdx
    let sideComplianceID = ReadOptionalFieldIdx bs index 659 ReadSideComplianceIDIdx
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
    let side = ReadFieldIdx bs index 54 ReadSideIdx
    let clOrdID = ReadFieldIdx bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdx bs index 526 ReadSecondaryClOrdIDIdx
    let clOrdLinkID = ReadOptionalFieldIdx bs index 583 ReadClOrdLinkIDIdx
    let noPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 453 ReadNoPartyIDsGrpIdx
    let tradeOriginationDate = ReadOptionalFieldIdx bs index 229 ReadTradeOriginationDateIdx
    let tradeDate = ReadOptionalFieldIdx bs index 75 ReadTradeDateIdx
    let account = ReadOptionalFieldIdx bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdx bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldIdx bs index 581 ReadAccountTypeIdx
    let dayBookingInst = ReadOptionalFieldIdx bs index 589 ReadDayBookingInstIdx
    let bookingUnit = ReadOptionalFieldIdx bs index 590 ReadBookingUnitIdx
    let preallocMethod = ReadOptionalFieldIdx bs index 591 ReadPreallocMethodIdx
    let allocID = ReadOptionalFieldIdx bs index 70 ReadAllocIDIdx
    let noAllocsGrpIdx = ReadOptionalGroupIdx bs index 78 ReadNoAllocsGrpIdx
    let qtyType = ReadOptionalFieldIdx bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentIdx bs index ReadOrderQtyDataIdx
    let commissionData = ReadComponentIdx bs index ReadCommissionDataIdx
    let orderCapacity = ReadOptionalFieldIdx bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldIdx bs index 529 ReadOrderRestrictionsIdx
    let custOrderCapacity = ReadOptionalFieldIdx bs index 582 ReadCustOrderCapacityIdx
    let forexReq = ReadOptionalFieldIdx bs index 121 ReadForexReqIdx
    let settlCurrency = ReadOptionalFieldIdx bs index 120 ReadSettlCurrencyIdx
    let bookingType = ReadOptionalFieldIdx bs index 775 ReadBookingTypeIdx
    let text = ReadOptionalFieldIdx bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdx bs index 354 ReadEncodedTextIdx
    let positionEffect = ReadOptionalFieldIdx bs index 77 ReadPositionEffectIdx
    let coveredOrUncovered = ReadOptionalFieldIdx bs index 203 ReadCoveredOrUncoveredIdx
    let cashMargin = ReadOptionalFieldIdx bs index 544 ReadCashMarginIdx
    let clearingFeeIndicator = ReadOptionalFieldIdx bs index 635 ReadClearingFeeIndicatorIdx
    let solicitedFlag = ReadOptionalFieldIdx bs index 377 ReadSolicitedFlagIdx
    let sideComplianceID = ReadOptionalFieldIdx bs index 659 ReadSideComplianceIDIdx
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
    let instrumentLegFG = ReadComponentIdx bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdx bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdx bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let legPositionEffect = ReadOptionalFieldIdx bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldIdx bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldIdx bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldIdx bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldIdx bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdx bs index 588 ReadLegSettlDateIdx
    let legLastPx = ReadOptionalFieldIdx bs index 637 ReadLegLastPxIdx
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
    let instrAttribType = ReadFieldIdx bs index 871 ReadInstrAttribTypeIdx
    let instrAttribValue = ReadOptionalFieldIdx bs index 872 ReadInstrAttribValueIdx
    let ci:NoInstrAttribGrp = {
        InstrAttribType = instrAttribType
        InstrAttribValue = instrAttribValue
    }
    ci


// component
let ReadInstrumentExtensionIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentExtension =
    let deliveryForm = ReadOptionalFieldIdx bs index 668 ReadDeliveryFormIdx
    let pctAtRisk = ReadOptionalFieldIdx bs index 869 ReadPctAtRiskIdx
    let noInstrAttribGrpIdx = ReadOptionalGroupIdx bs index 870 ReadNoInstrAttribGrpIdx
    let ci:InstrumentExtension = {
        DeliveryForm = deliveryForm
        PctAtRisk = pctAtRisk
        NoInstrAttribGrp = noInstrAttribGrp
    }
    ci


// group
let ReadNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoLegsGrp =
    let instrumentLegFG = ReadComponentIdx bs index ReadInstrumentLegFGIdx
    let ci:NoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
    }
    ci


// group
let ReadDerivativeSecurityListNoRelatedSymGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : DerivativeSecurityListNoRelatedSymGrp =
    let instrument = ReadComponentIdx bs index ReadInstrumentIdx
    let currency = ReadOptionalFieldIdx bs index 15 ReadCurrencyIdx
    let expirationCycle = ReadOptionalFieldIdx bs index 827 ReadExpirationCycleIdx
    let instrumentExtension = ReadComponentIdx bs index ReadInstrumentExtensionIdx
    let noLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadNoLegsGrpIdx
    let tradingSessionID = ReadOptionalFieldIdx bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdx bs index 625 ReadTradingSessionSubIDIdx
    let text = ReadOptionalFieldIdx bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdx bs index 354 ReadEncodedTextIdx
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
    let agreementDesc = ReadOptionalFieldIdx bs index 913 ReadAgreementDescIdx
    let agreementID = ReadOptionalFieldIdx bs index 914 ReadAgreementIDIdx
    let agreementDate = ReadOptionalFieldIdx bs index 915 ReadAgreementDateIdx
    let agreementCurrency = ReadOptionalFieldIdx bs index 918 ReadAgreementCurrencyIdx
    let terminationType = ReadOptionalFieldIdx bs index 788 ReadTerminationTypeIdx
    let startDate = ReadOptionalFieldIdx bs index 916 ReadStartDateIdx
    let endDate = ReadOptionalFieldIdx bs index 917 ReadEndDateIdx
    let deliveryType = ReadOptionalFieldIdx bs index 919 ReadDeliveryTypeIdx
    let marginRatio = ReadOptionalFieldIdx bs index 898 ReadMarginRatioIdx
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
    let legBenchmarkCurveCurrency = ReadOptionalFieldIdx bs index 676 ReadLegBenchmarkCurveCurrencyIdx
    let legBenchmarkCurveName = ReadOptionalFieldIdx bs index 677 ReadLegBenchmarkCurveNameIdx
    let legBenchmarkCurvePoint = ReadOptionalFieldIdx bs index 678 ReadLegBenchmarkCurvePointIdx
    let legBenchmarkPrice = ReadOptionalFieldIdx bs index 679 ReadLegBenchmarkPriceIdx
    let legBenchmarkPriceType = ReadOptionalFieldIdx bs index 680 ReadLegBenchmarkPriceTypeIdx
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
    let instrumentLegFG = ReadComponentIdx bs index ReadInstrumentLegFGIdx
    let legSwapType = ReadOptionalFieldIdx bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldIdx bs index 587 ReadLegSettlTypeIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let legBenchmarkCurveData = ReadComponentIdx bs index ReadLegBenchmarkCurveDataIdx
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
    let instrument = ReadComponentIdx bs index ReadInstrumentIdx
    let instrumentExtension = ReadComponentIdx bs index ReadInstrumentExtensionIdx
    let financingDetails = ReadComponentIdx bs index ReadFinancingDetailsIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let currency = ReadOptionalFieldIdx bs index 15 ReadCurrencyIdx
    let noStipulationsGrpIdx = ReadOptionalGroupIdx bs index 232 ReadNoStipulationsGrpIdx
    let securityListNoLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadSecurityListNoLegsGrpIdx
    let spreadOrBenchmarkCurveData = ReadComponentIdx bs index ReadSpreadOrBenchmarkCurveDataIdx
    let yieldData = ReadComponentIdx bs index ReadYieldDataIdx
    let roundLot = ReadOptionalFieldIdx bs index 561 ReadRoundLotIdx
    let minTradeVol = ReadOptionalFieldIdx bs index 562 ReadMinTradeVolIdx
    let tradingSessionID = ReadOptionalFieldIdx bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdx bs index 625 ReadTradingSessionSubIDIdx
    let expirationCycle = ReadOptionalFieldIdx bs index 827 ReadExpirationCycleIdx
    let text = ReadOptionalFieldIdx bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdx bs index 354 ReadEncodedTextIdx
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
    let mDUpdateAction = ReadFieldIdx bs index 279 ReadMDUpdateActionIdx
    let deleteReason = ReadOptionalFieldIdx bs index 285 ReadDeleteReasonIdx
    let mDEntryType = ReadOptionalFieldIdx bs index 269 ReadMDEntryTypeIdx
    let mDEntryID = ReadOptionalFieldIdx bs index 278 ReadMDEntryIDIdx
    let mDEntryRefID = ReadOptionalFieldIdx bs index 280 ReadMDEntryRefIDIdx
    let instrument = ReadOptionalComponentIdx bs index 55 ReadInstrumentIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let noLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadNoLegsGrpIdx
    let financialStatus = ReadOptionalFieldIdx bs index 291 ReadFinancialStatusIdx
    let corporateAction = ReadOptionalFieldIdx bs index 292 ReadCorporateActionIdx
    let mDEntryPx = ReadOptionalFieldIdx bs index 270 ReadMDEntryPxIdx
    let currency = ReadOptionalFieldIdx bs index 15 ReadCurrencyIdx
    let mDEntrySize = ReadOptionalFieldIdx bs index 271 ReadMDEntrySizeIdx
    let mDEntryDate = ReadOptionalFieldIdx bs index 272 ReadMDEntryDateIdx
    let mDEntryTime = ReadOptionalFieldIdx bs index 273 ReadMDEntryTimeIdx
    let tickDirection = ReadOptionalFieldIdx bs index 274 ReadTickDirectionIdx
    let mDMkt = ReadOptionalFieldIdx bs index 275 ReadMDMktIdx
    let tradingSessionID = ReadOptionalFieldIdx bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdx bs index 625 ReadTradingSessionSubIDIdx
    let quoteCondition = ReadOptionalFieldIdx bs index 276 ReadQuoteConditionIdx
    let tradeCondition = ReadOptionalFieldIdx bs index 277 ReadTradeConditionIdx
    let mDEntryOriginator = ReadOptionalFieldIdx bs index 282 ReadMDEntryOriginatorIdx
    let locationID = ReadOptionalFieldIdx bs index 283 ReadLocationIDIdx
    let deskID = ReadOptionalFieldIdx bs index 284 ReadDeskIDIdx
    let openCloseSettlFlag = ReadOptionalFieldIdx bs index 286 ReadOpenCloseSettlFlagIdx
    let timeInForce = ReadOptionalFieldIdx bs index 59 ReadTimeInForceIdx
    let expireDate = ReadOptionalFieldIdx bs index 432 ReadExpireDateIdx
    let expireTime = ReadOptionalFieldIdx bs index 126 ReadExpireTimeIdx
    let minQty = ReadOptionalFieldIdx bs index 110 ReadMinQtyIdx
    let execInst = ReadOptionalFieldIdx bs index 18 ReadExecInstIdx
    let sellerDays = ReadOptionalFieldIdx bs index 287 ReadSellerDaysIdx
    let orderID = ReadOptionalFieldIdx bs index 37 ReadOrderIDIdx
    let quoteEntryID = ReadOptionalFieldIdx bs index 299 ReadQuoteEntryIDIdx
    let mDEntryBuyer = ReadOptionalFieldIdx bs index 288 ReadMDEntryBuyerIdx
    let mDEntrySeller = ReadOptionalFieldIdx bs index 289 ReadMDEntrySellerIdx
    let numberOfOrders = ReadOptionalFieldIdx bs index 346 ReadNumberOfOrdersIdx
    let mDEntryPositionNo = ReadOptionalFieldIdx bs index 290 ReadMDEntryPositionNoIdx
    let scope = ReadOptionalFieldIdx bs index 546 ReadScopeIdx
    let priceDelta = ReadOptionalFieldIdx bs index 811 ReadPriceDeltaIdx
    let netChgPrevDay = ReadOptionalFieldIdx bs index 451 ReadNetChgPrevDayIdx
    let text = ReadOptionalFieldIdx bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdx bs index 354 ReadEncodedTextIdx
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
    let instrument = ReadComponentIdx bs index ReadInstrumentIdx
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
    let quoteEntryID = ReadFieldIdx bs index 299 ReadQuoteEntryIDIdx
    let instrument = ReadOptionalComponentIdx bs index 55 ReadInstrumentIdx
    let noLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadNoLegsGrpIdx
    let bidPx = ReadOptionalFieldIdx bs index 132 ReadBidPxIdx
    let offerPx = ReadOptionalFieldIdx bs index 133 ReadOfferPxIdx
    let bidSize = ReadOptionalFieldIdx bs index 134 ReadBidSizeIdx
    let offerSize = ReadOptionalFieldIdx bs index 135 ReadOfferSizeIdx
    let validUntilTime = ReadOptionalFieldIdx bs index 62 ReadValidUntilTimeIdx
    let bidSpotRate = ReadOptionalFieldIdx bs index 188 ReadBidSpotRateIdx
    let offerSpotRate = ReadOptionalFieldIdx bs index 190 ReadOfferSpotRateIdx
    let bidForwardPoints = ReadOptionalFieldIdx bs index 189 ReadBidForwardPointsIdx
    let offerForwardPoints = ReadOptionalFieldIdx bs index 191 ReadOfferForwardPointsIdx
    let midPx = ReadOptionalFieldIdx bs index 631 ReadMidPxIdx
    let bidYield = ReadOptionalFieldIdx bs index 632 ReadBidYieldIdx
    let midYield = ReadOptionalFieldIdx bs index 633 ReadMidYieldIdx
    let offerYield = ReadOptionalFieldIdx bs index 634 ReadOfferYieldIdx
    let transactTime = ReadOptionalFieldIdx bs index 60 ReadTransactTimeIdx
    let tradingSessionID = ReadOptionalFieldIdx bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdx bs index 625 ReadTradingSessionSubIDIdx
    let settlDate = ReadOptionalFieldIdx bs index 64 ReadSettlDateIdx
    let ordType = ReadOptionalFieldIdx bs index 40 ReadOrdTypeIdx
    let settlDate2 = ReadOptionalFieldIdx bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldIdx bs index 192 ReadOrderQty2Idx
    let bidForwardPoints2 = ReadOptionalFieldIdx bs index 642 ReadBidForwardPoints2Idx
    let offerForwardPoints2 = ReadOptionalFieldIdx bs index 643 ReadOfferForwardPoints2Idx
    let currency = ReadOptionalFieldIdx bs index 15 ReadCurrencyIdx
    let quoteEntryRejectReason = ReadOptionalFieldIdx bs index 368 ReadQuoteEntryRejectReasonIdx
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
    let quoteSetID = ReadFieldIdx bs index 302 ReadQuoteSetIDIdx
    let underlyingInstrument = ReadOptionalComponentIdx bs index 311 ReadUnderlyingInstrumentIdx
    let totNoQuoteEntries = ReadOptionalFieldIdx bs index 304 ReadTotNoQuoteEntriesIdx
    let lastFragment = ReadOptionalFieldIdx bs index 893 ReadLastFragmentIdx
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
    let quoteEntryID = ReadFieldIdx bs index 299 ReadQuoteEntryIDIdx
    let instrument = ReadOptionalComponentIdx bs index 55 ReadInstrumentIdx
    let noLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadNoLegsGrpIdx
    let bidPx = ReadOptionalFieldIdx bs index 132 ReadBidPxIdx
    let offerPx = ReadOptionalFieldIdx bs index 133 ReadOfferPxIdx
    let bidSize = ReadOptionalFieldIdx bs index 134 ReadBidSizeIdx
    let offerSize = ReadOptionalFieldIdx bs index 135 ReadOfferSizeIdx
    let validUntilTime = ReadOptionalFieldIdx bs index 62 ReadValidUntilTimeIdx
    let bidSpotRate = ReadOptionalFieldIdx bs index 188 ReadBidSpotRateIdx
    let offerSpotRate = ReadOptionalFieldIdx bs index 190 ReadOfferSpotRateIdx
    let bidForwardPoints = ReadOptionalFieldIdx bs index 189 ReadBidForwardPointsIdx
    let offerForwardPoints = ReadOptionalFieldIdx bs index 191 ReadOfferForwardPointsIdx
    let midPx = ReadOptionalFieldIdx bs index 631 ReadMidPxIdx
    let bidYield = ReadOptionalFieldIdx bs index 632 ReadBidYieldIdx
    let midYield = ReadOptionalFieldIdx bs index 633 ReadMidYieldIdx
    let offerYield = ReadOptionalFieldIdx bs index 634 ReadOfferYieldIdx
    let transactTime = ReadOptionalFieldIdx bs index 60 ReadTransactTimeIdx
    let tradingSessionID = ReadOptionalFieldIdx bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdx bs index 625 ReadTradingSessionSubIDIdx
    let settlDate = ReadOptionalFieldIdx bs index 64 ReadSettlDateIdx
    let ordType = ReadOptionalFieldIdx bs index 40 ReadOrdTypeIdx
    let settlDate2 = ReadOptionalFieldIdx bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldIdx bs index 192 ReadOrderQty2Idx
    let bidForwardPoints2 = ReadOptionalFieldIdx bs index 642 ReadBidForwardPoints2Idx
    let offerForwardPoints2 = ReadOptionalFieldIdx bs index 643 ReadOfferForwardPoints2Idx
    let currency = ReadOptionalFieldIdx bs index 15 ReadCurrencyIdx
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
    let quoteSetID = ReadFieldIdx bs index 302 ReadQuoteSetIDIdx
    let underlyingInstrument = ReadOptionalComponentIdx bs index 311 ReadUnderlyingInstrumentIdx
    let quoteSetValidUntilTime = ReadOptionalFieldIdx bs index 367 ReadQuoteSetValidUntilTimeIdx
    let totNoQuoteEntries = ReadFieldIdx bs index 304 ReadTotNoQuoteEntriesIdx
    let lastFragment = ReadOptionalFieldIdx bs index 893 ReadLastFragmentIdx
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
    let instrumentLegFG = ReadComponentIdx bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdx bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdx bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldIdx bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdx bs index 588 ReadLegSettlDateIdx
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
    let instrument = ReadComponentIdx bs index ReadInstrumentIdx
    let financingDetails = ReadComponentIdx bs index ReadFinancingDetailsIdx
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
    let instrumentLegFG = ReadComponentIdx bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdx bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdx bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldIdx bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdx bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legPriceType = ReadOptionalFieldIdx bs index 686 ReadLegPriceTypeIdx
    let legBidPx = ReadOptionalFieldIdx bs index 681 ReadLegBidPxIdx
    let legOfferPx = ReadOptionalFieldIdx bs index 684 ReadLegOfferPxIdx
    let legBenchmarkCurveData = ReadComponentIdx bs index ReadLegBenchmarkCurveDataIdx
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
    let instrument = ReadComponentIdx bs index ReadInstrumentIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let noLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadNoLegsGrpIdx
    let prevClosePx = ReadOptionalFieldIdx bs index 140 ReadPrevClosePxIdx
    let quoteRequestType = ReadOptionalFieldIdx bs index 303 ReadQuoteRequestTypeIdx
    let quoteType = ReadOptionalFieldIdx bs index 537 ReadQuoteTypeIdx
    let tradingSessionID = ReadOptionalFieldIdx bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdx bs index 625 ReadTradingSessionSubIDIdx
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
    let instrumentLegFG = ReadComponentIdx bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdx bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdx bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldIdx bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdx bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legBenchmarkCurveData = ReadComponentIdx bs index ReadLegBenchmarkCurveDataIdx
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
    let instrument = ReadComponentIdx bs index ReadInstrumentIdx
    let financingDetails = ReadComponentIdx bs index ReadFinancingDetailsIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let prevClosePx = ReadOptionalFieldIdx bs index 140 ReadPrevClosePxIdx
    let quoteRequestType = ReadOptionalFieldIdx bs index 303 ReadQuoteRequestTypeIdx
    let quoteType = ReadOptionalFieldIdx bs index 537 ReadQuoteTypeIdx
    let tradingSessionID = ReadOptionalFieldIdx bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdx bs index 625 ReadTradingSessionSubIDIdx
    let tradeOriginationDate = ReadOptionalFieldIdx bs index 229 ReadTradeOriginationDateIdx
    let side = ReadOptionalFieldIdx bs index 54 ReadSideIdx
    let qtyType = ReadOptionalFieldIdx bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentIdx bs index ReadOrderQtyDataIdx
    let settlType = ReadOptionalFieldIdx bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldIdx bs index 64 ReadSettlDateIdx
    let settlDate2 = ReadOptionalFieldIdx bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldIdx bs index 192 ReadOrderQty2Idx
    let currency = ReadOptionalFieldIdx bs index 15 ReadCurrencyIdx
    let noStipulationsGrpIdx = ReadOptionalGroupIdx bs index 232 ReadNoStipulationsGrpIdx
    let account = ReadOptionalFieldIdx bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdx bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldIdx bs index 581 ReadAccountTypeIdx
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
    let instrumentLegFG = ReadComponentIdx bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdx bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdx bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldIdx bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdx bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legPriceType = ReadOptionalFieldIdx bs index 686 ReadLegPriceTypeIdx
    let legBidPx = ReadOptionalFieldIdx bs index 681 ReadLegBidPxIdx
    let legOfferPx = ReadOptionalFieldIdx bs index 684 ReadLegOfferPxIdx
    let legBenchmarkCurveData = ReadComponentIdx bs index ReadLegBenchmarkCurveDataIdx
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
    let instrumentLegFG = ReadComponentIdx bs index ReadInstrumentLegFGIdx
    let legQty = ReadOptionalFieldIdx bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldIdx bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldIdx bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldIdx bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrpIdx = ReadOptionalGroupIdx bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrpIdx = ReadOptionalGroupIdx bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legBenchmarkCurveData = ReadComponentIdx bs index ReadLegBenchmarkCurveDataIdx
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
    let quoteQualifier = ReadFieldIdx bs index 695 ReadQuoteQualifierIdx
    let ci:NoQuoteQualifiersGrp = {
        QuoteQualifier = quoteQualifier
    }
    ci


// group
let ReadQuoteRequestNoRelatedSymGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteRequestNoRelatedSymGrp =
    let instrument = ReadComponentIdx bs index ReadInstrumentIdx
    let financingDetails = ReadComponentIdx bs index ReadFinancingDetailsIdx
    let noUnderlyingsGrpIdx = ReadOptionalGroupIdx bs index 711 ReadNoUnderlyingsGrpIdx
    let prevClosePx = ReadOptionalFieldIdx bs index 140 ReadPrevClosePxIdx
    let quoteRequestType = ReadOptionalFieldIdx bs index 303 ReadQuoteRequestTypeIdx
    let quoteType = ReadOptionalFieldIdx bs index 537 ReadQuoteTypeIdx
    let tradingSessionID = ReadOptionalFieldIdx bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdx bs index 625 ReadTradingSessionSubIDIdx
    let tradeOriginationDate = ReadOptionalFieldIdx bs index 229 ReadTradeOriginationDateIdx
    let side = ReadOptionalFieldIdx bs index 54 ReadSideIdx
    let qtyType = ReadOptionalFieldIdx bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentIdx bs index ReadOrderQtyDataIdx
    let settlType = ReadOptionalFieldIdx bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldIdx bs index 64 ReadSettlDateIdx
    let settlDate2 = ReadOptionalFieldIdx bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldIdx bs index 192 ReadOrderQty2Idx
    let currency = ReadOptionalFieldIdx bs index 15 ReadCurrencyIdx
    let noStipulationsGrpIdx = ReadOptionalGroupIdx bs index 232 ReadNoStipulationsGrpIdx
    let account = ReadOptionalFieldIdx bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdx bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldIdx bs index 581 ReadAccountTypeIdx
    let quoteRequestNoLegsGrpIdx = ReadOptionalGroupIdx bs index 555 ReadQuoteRequestNoLegsGrpIdx
    let noQuoteQualifiersGrpIdx = ReadOptionalGroupIdx bs index 735 ReadNoQuoteQualifiersGrpIdx
    let quotePriceType = ReadOptionalFieldIdx bs index 692 ReadQuotePriceTypeIdx
    let ordType = ReadOptionalFieldIdx bs index 40 ReadOrdTypeIdx
    let validUntilTime = ReadOptionalFieldIdx bs index 62 ReadValidUntilTimeIdx
    let expireTime = ReadOptionalFieldIdx bs index 126 ReadExpireTimeIdx
    let transactTime = ReadOptionalFieldIdx bs index 60 ReadTransactTimeIdx
    let spreadOrBenchmarkCurveData = ReadComponentIdx bs index ReadSpreadOrBenchmarkCurveDataIdx
    let priceType = ReadOptionalFieldIdx bs index 423 ReadPriceTypeIdx
    let price = ReadOptionalFieldIdx bs index 44 ReadPriceIdx
    let price2 = ReadOptionalFieldIdx bs index 640 ReadPrice2Idx
    let yieldData = ReadComponentIdx bs index ReadYieldDataIdx
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
    let instrument = ReadComponentIdx bs index ReadInstrumentIdx
    let ci:NoRelatedSymGrp = {
        Instrument = instrument
    }
    ci


// group
let ReadIndicationOfInterestNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : IndicationOfInterestNoLegsGrp =
    let instrumentLegFG = ReadComponentIdx bs index ReadInstrumentLegFGIdx
    let legIOIQty = ReadOptionalFieldIdx bs index 682 ReadLegIOIQtyIdx
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
    let underlyingInstrument = ReadComponentIdx bs index ReadUnderlyingInstrumentIdx
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
    let legSymbol = ReadOptionalFieldIdx bs index 600 ReadLegSymbolIdx
    let legSymbolSfx = ReadOptionalFieldIdx bs index 601 ReadLegSymbolSfxIdx
    let legSecurityID = ReadOptionalFieldIdx bs index 602 ReadLegSecurityIDIdx
    let legSecurityIDSource = ReadOptionalFieldIdx bs index 603 ReadLegSecurityIDSourceIdx
    let noLegSecurityAltIDGrpIdx = ReadOptionalGroupIdx bs index 604 ReadNoLegSecurityAltIDGrpIdx
    let legProduct = ReadOptionalFieldIdx bs index 607 ReadLegProductIdx
    let legCFICode = ReadOptionalFieldIdx bs index 608 ReadLegCFICodeIdx
    let legSecurityType = ReadOptionalFieldIdx bs index 609 ReadLegSecurityTypeIdx
    let legSecuritySubType = ReadOptionalFieldIdx bs index 764 ReadLegSecuritySubTypeIdx
    let legMaturityMonthYear = ReadOptionalFieldIdx bs index 610 ReadLegMaturityMonthYearIdx
    let legMaturityDate = ReadOptionalFieldIdx bs index 611 ReadLegMaturityDateIdx
    let legCouponPaymentDate = ReadOptionalFieldIdx bs index 248 ReadLegCouponPaymentDateIdx
    let legIssueDate = ReadOptionalFieldIdx bs index 249 ReadLegIssueDateIdx
    let legRepoCollateralSecurityType = ReadOptionalFieldIdx bs index 250 ReadLegRepoCollateralSecurityTypeIdx
    let legRepurchaseTerm = ReadOptionalFieldIdx bs index 251 ReadLegRepurchaseTermIdx
    let legRepurchaseRate = ReadOptionalFieldIdx bs index 252 ReadLegRepurchaseRateIdx
    let legFactor = ReadOptionalFieldIdx bs index 253 ReadLegFactorIdx
    let legCreditRating = ReadOptionalFieldIdx bs index 257 ReadLegCreditRatingIdx
    let legInstrRegistry = ReadOptionalFieldIdx bs index 599 ReadLegInstrRegistryIdx
    let legCountryOfIssue = ReadOptionalFieldIdx bs index 596 ReadLegCountryOfIssueIdx
    let legStateOrProvinceOfIssue = ReadOptionalFieldIdx bs index 597 ReadLegStateOrProvinceOfIssueIdx
    let legLocaleOfIssue = ReadOptionalFieldIdx bs index 598 ReadLegLocaleOfIssueIdx
    let legRedemptionDate = ReadOptionalFieldIdx bs index 254 ReadLegRedemptionDateIdx
    let legStrikePrice = ReadOptionalFieldIdx bs index 612 ReadLegStrikePriceIdx
    let legStrikeCurrency = ReadOptionalFieldIdx bs index 942 ReadLegStrikeCurrencyIdx
    let legOptAttribute = ReadOptionalFieldIdx bs index 613 ReadLegOptAttributeIdx
    let legContractMultiplier = ReadOptionalFieldIdx bs index 614 ReadLegContractMultiplierIdx
    let legCouponRate = ReadOptionalFieldIdx bs index 615 ReadLegCouponRateIdx
    let legSecurityExchange = ReadOptionalFieldIdx bs index 616 ReadLegSecurityExchangeIdx
    let legIssuer = ReadOptionalFieldIdx bs index 617 ReadLegIssuerIdx
    let encodedLegIssuer = ReadOptionalFieldIdx bs index 618 ReadEncodedLegIssuerIdx
    let legSecurityDesc = ReadOptionalFieldIdx bs index 620 ReadLegSecurityDescIdx
    let encodedLegSecurityDesc = ReadOptionalFieldIdx bs index 621 ReadEncodedLegSecurityDescIdx
    let legRatioQty = ReadOptionalFieldIdx bs index 623 ReadLegRatioQtyIdx
    let legSide = ReadOptionalFieldIdx bs index 624 ReadLegSideIdx
    let legCurrency = ReadOptionalFieldIdx bs index 556 ReadLegCurrencyIdx
    let legPool = ReadOptionalFieldIdx bs index 740 ReadLegPoolIdx
    let legDatedDate = ReadOptionalFieldIdx bs index 739 ReadLegDatedDateIdx
    let legContractSettlMonth = ReadOptionalFieldIdx bs index 955 ReadLegContractSettlMonthIdx
    let legInterestAccrualDate = ReadOptionalFieldIdx bs index 956 ReadLegInterestAccrualDateIdx
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
    let refMsgType = ReadFieldIdx bs index 372 ReadRefMsgTypeIdx
    let msgDirection = ReadOptionalFieldIdx bs index 385 ReadMsgDirectionIdx
    let ci:NoMsgTypesGrp = {
        RefMsgType = refMsgType
        MsgDirection = msgDirection
    }
    ci


// group
let ReadNoIOIQualifiersGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoIOIQualifiersGrp =
    let iOIQualifier = ReadFieldIdx bs index 104 ReadIOIQualifierIdx
    let ci:NoIOIQualifiersGrp = {
        IOIQualifier = iOIQualifier
    }
    ci


// group
let ReadNoRoutingIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoRoutingIDsGrp =
    let routingType = ReadFieldIdx bs index 216 ReadRoutingTypeIdx
    let routingID = ReadOptionalFieldIdx bs index 217 ReadRoutingIDIdx
    let ci:NoRoutingIDsGrp = {
        RoutingType = routingType
        RoutingID = routingID
    }
    ci


// group
let ReadLinesOfTextGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LinesOfTextGrp =
    let text = ReadFieldIdx bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdx bs index 354 ReadEncodedTextIdx
    let ci:LinesOfTextGrp = {
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadNoMDEntryTypesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMDEntryTypesGrp =
    let mDEntryType = ReadFieldIdx bs index 269 ReadMDEntryTypeIdx
    let ci:NoMDEntryTypesGrp = {
        MDEntryType = mDEntryType
    }
    ci


// group
let ReadNoMDEntriesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMDEntriesGrp =
    let mDEntryType = ReadFieldIdx bs index 269 ReadMDEntryTypeIdx
    let mDEntryPx = ReadOptionalFieldIdx bs index 270 ReadMDEntryPxIdx
    let currency = ReadOptionalFieldIdx bs index 15 ReadCurrencyIdx
    let mDEntrySize = ReadOptionalFieldIdx bs index 271 ReadMDEntrySizeIdx
    let mDEntryDate = ReadOptionalFieldIdx bs index 272 ReadMDEntryDateIdx
    let mDEntryTime = ReadOptionalFieldIdx bs index 273 ReadMDEntryTimeIdx
    let tickDirection = ReadOptionalFieldIdx bs index 274 ReadTickDirectionIdx
    let mDMkt = ReadOptionalFieldIdx bs index 275 ReadMDMktIdx
    let tradingSessionID = ReadOptionalFieldIdx bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdx bs index 625 ReadTradingSessionSubIDIdx
    let quoteCondition = ReadOptionalFieldIdx bs index 276 ReadQuoteConditionIdx
    let tradeCondition = ReadOptionalFieldIdx bs index 277 ReadTradeConditionIdx
    let mDEntryOriginator = ReadOptionalFieldIdx bs index 282 ReadMDEntryOriginatorIdx
    let locationID = ReadOptionalFieldIdx bs index 283 ReadLocationIDIdx
    let deskID = ReadOptionalFieldIdx bs index 284 ReadDeskIDIdx
    let openCloseSettlFlag = ReadOptionalFieldIdx bs index 286 ReadOpenCloseSettlFlagIdx
    let timeInForce = ReadOptionalFieldIdx bs index 59 ReadTimeInForceIdx
    let expireDate = ReadOptionalFieldIdx bs index 432 ReadExpireDateIdx
    let expireTime = ReadOptionalFieldIdx bs index 126 ReadExpireTimeIdx
    let minQty = ReadOptionalFieldIdx bs index 110 ReadMinQtyIdx
    let execInst = ReadOptionalFieldIdx bs index 18 ReadExecInstIdx
    let sellerDays = ReadOptionalFieldIdx bs index 287 ReadSellerDaysIdx
    let orderID = ReadOptionalFieldIdx bs index 37 ReadOrderIDIdx
    let quoteEntryID = ReadOptionalFieldIdx bs index 299 ReadQuoteEntryIDIdx
    let mDEntryBuyer = ReadOptionalFieldIdx bs index 288 ReadMDEntryBuyerIdx
    let mDEntrySeller = ReadOptionalFieldIdx bs index 289 ReadMDEntrySellerIdx
    let numberOfOrders = ReadOptionalFieldIdx bs index 346 ReadNumberOfOrdersIdx
    let mDEntryPositionNo = ReadOptionalFieldIdx bs index 290 ReadMDEntryPositionNoIdx
    let scope = ReadOptionalFieldIdx bs index 546 ReadScopeIdx
    let priceDelta = ReadOptionalFieldIdx bs index 811 ReadPriceDeltaIdx
    let text = ReadOptionalFieldIdx bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdx bs index 354 ReadEncodedTextIdx
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
    let altMDSourceID = ReadFieldIdx bs index 817 ReadAltMDSourceIDIdx
    let ci:NoAltMDSourceGrp = {
        AltMDSourceID = altMDSourceID
    }
    ci


// group
let ReadNoSecurityTypesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSecurityTypesGrp =
    let securityType = ReadFieldIdx bs index 167 ReadSecurityTypeIdx
    let securitySubType = ReadOptionalFieldIdx bs index 762 ReadSecuritySubTypeIdx
    let product = ReadOptionalFieldIdx bs index 460 ReadProductIdx
    let cFICode = ReadOptionalFieldIdx bs index 461 ReadCFICodeIdx
    let ci:NoSecurityTypesGrp = {
        SecurityType = securityType
        SecuritySubType = securitySubType
        Product = product
        CFICode = cFICode
    }
    ci


// group
let ReadNoContraBrokersGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoContraBrokersGrp =
    let contraBroker = ReadFieldIdx bs index 375 ReadContraBrokerIdx
    let contraTrader = ReadOptionalFieldIdx bs index 337 ReadContraTraderIdx
    let contraTradeQty = ReadOptionalFieldIdx bs index 437 ReadContraTradeQtyIdx
    let contraTradeTime = ReadOptionalFieldIdx bs index 438 ReadContraTradeTimeIdx
    let contraLegRefID = ReadOptionalFieldIdx bs index 655 ReadContraLegRefIDIdx
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
    let origClOrdID = ReadFieldIdx bs index 41 ReadOrigClOrdIDIdx
    let affectedOrderID = ReadOptionalFieldIdx bs index 535 ReadAffectedOrderIDIdx
    let affectedSecondaryOrderID = ReadOptionalFieldIdx bs index 536 ReadAffectedSecondaryOrderIDIdx
    let ci:NoAffectedOrdersGrp = {
        OrigClOrdID = origClOrdID
        AffectedOrderID = affectedOrderID
        AffectedSecondaryOrderID = affectedSecondaryOrderID
    }
    ci


// group
let ReadNoBidDescriptorsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoBidDescriptorsGrp =
    let bidDescriptorType = ReadFieldIdx bs index 399 ReadBidDescriptorTypeIdx
    let bidDescriptor = ReadOptionalFieldIdx bs index 400 ReadBidDescriptorIdx
    let sideValueInd = ReadOptionalFieldIdx bs index 401 ReadSideValueIndIdx
    let liquidityValue = ReadOptionalFieldIdx bs index 404 ReadLiquidityValueIdx
    let liquidityNumSecurities = ReadOptionalFieldIdx bs index 441 ReadLiquidityNumSecuritiesIdx
    let liquidityPctLow = ReadOptionalFieldIdx bs index 402 ReadLiquidityPctLowIdx
    let liquidityPctHigh = ReadOptionalFieldIdx bs index 403 ReadLiquidityPctHighIdx
    let eFPTrackingError = ReadOptionalFieldIdx bs index 405 ReadEFPTrackingErrorIdx
    let fairValue = ReadOptionalFieldIdx bs index 406 ReadFairValueIdx
    let outsideIndexPct = ReadOptionalFieldIdx bs index 407 ReadOutsideIndexPctIdx
    let valueOfFutures = ReadOptionalFieldIdx bs index 408 ReadValueOfFuturesIdx
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
    let listID = ReadFieldIdx bs index 66 ReadListIDIdx
    let side = ReadOptionalFieldIdx bs index 54 ReadSideIdx
    let tradingSessionID = ReadOptionalFieldIdx bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldIdx bs index 625 ReadTradingSessionSubIDIdx
    let netGrossInd = ReadOptionalFieldIdx bs index 430 ReadNetGrossIndIdx
    let settlType = ReadOptionalFieldIdx bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldIdx bs index 64 ReadSettlDateIdx
    let account = ReadOptionalFieldIdx bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldIdx bs index 660 ReadAcctIDSourceIdx
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
    let clOrdID = ReadFieldIdx bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldIdx bs index 526 ReadSecondaryClOrdIDIdx
    let cumQty = ReadFieldIdx bs index 14 ReadCumQtyIdx
    let ordStatus = ReadFieldIdx bs index 39 ReadOrdStatusIdx
    let workingIndicator = ReadOptionalFieldIdx bs index 636 ReadWorkingIndicatorIdx
    let leavesQty = ReadFieldIdx bs index 151 ReadLeavesQtyIdx
    let cxlQty = ReadFieldIdx bs index 84 ReadCxlQtyIdx
    let avgPx = ReadFieldIdx bs index 6 ReadAvgPxIdx
    let ordRejReason = ReadOptionalFieldIdx bs index 103 ReadOrdRejReasonIdx
    let text = ReadOptionalFieldIdx bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldIdx bs index 354 ReadEncodedTextIdx
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
    let lastQty = ReadFieldIdx bs index 32 ReadLastQtyIdx
    let execID = ReadOptionalFieldIdx bs index 17 ReadExecIDIdx
    let secondaryExecID = ReadOptionalFieldIdx bs index 527 ReadSecondaryExecIDIdx
    let lastPx = ReadOptionalFieldIdx bs index 31 ReadLastPxIdx
    let lastParPx = ReadOptionalFieldIdx bs index 669 ReadLastParPxIdx
    let lastCapacity = ReadOptionalFieldIdx bs index 29 ReadLastCapacityIdx
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
    let allocAccount = ReadFieldIdx bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdx bs index 661 ReadAllocAcctIDSourceIdx
    let allocPrice = ReadOptionalFieldIdx bs index 366 ReadAllocPriceIdx
    let individualAllocID = ReadOptionalFieldIdx bs index 467 ReadIndividualAllocIDIdx
    let individualAllocRejCode = ReadOptionalFieldIdx bs index 776 ReadIndividualAllocRejCodeIdx
    let allocText = ReadOptionalFieldIdx bs index 161 ReadAllocTextIdx
    let encodedAllocText = ReadOptionalFieldIdx bs index 360 ReadEncodedAllocTextIdx
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
    let lastQty = ReadFieldIdx bs index 32 ReadLastQtyIdx
    let execID = ReadOptionalFieldIdx bs index 17 ReadExecIDIdx
    let secondaryExecID = ReadOptionalFieldIdx bs index 527 ReadSecondaryExecIDIdx
    let lastPx = ReadOptionalFieldIdx bs index 31 ReadLastPxIdx
    let lastParPx = ReadOptionalFieldIdx bs index 669 ReadLastParPxIdx
    let lastCapacity = ReadOptionalFieldIdx bs index 29 ReadLastCapacityIdx
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
    let allocAccount = ReadFieldIdx bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldIdx bs index 661 ReadAllocAcctIDSourceIdx
    let allocPrice = ReadOptionalFieldIdx bs index 366 ReadAllocPriceIdx
    let individualAllocID = ReadOptionalFieldIdx bs index 467 ReadIndividualAllocIDIdx
    let individualAllocRejCode = ReadOptionalFieldIdx bs index 776 ReadIndividualAllocRejCodeIdx
    let allocText = ReadOptionalFieldIdx bs index 161 ReadAllocTextIdx
    let encodedAllocText = ReadOptionalFieldIdx bs index 360 ReadEncodedAllocTextIdx
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
    let orderCapacity = ReadFieldIdx bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldIdx bs index 529 ReadOrderRestrictionsIdx
    let orderCapacityQty = ReadFieldIdx bs index 863 ReadOrderCapacityQtyIdx
    let ci:NoCapacitiesGrp = {
        OrderCapacity = orderCapacity
        OrderRestrictions = orderRestrictions
        OrderCapacityQty = orderCapacityQty
    }
    ci


// group
let ReadNoDatesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoDatesGrp =
    let tradeDate = ReadFieldIdx bs index 75 ReadTradeDateIdx
    let transactTime = ReadOptionalFieldIdx bs index 60 ReadTransactTimeIdx
    let ci:NoDatesGrp = {
        TradeDate = tradeDate
        TransactTime = transactTime
    }
    ci


// group
let ReadNoDistribInstsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoDistribInstsGrp =
    let distribPaymentMethod = ReadFieldIdx bs index 477 ReadDistribPaymentMethodIdx
    let distribPercentage = ReadOptionalFieldIdx bs index 512 ReadDistribPercentageIdx
    let cashDistribCurr = ReadOptionalFieldIdx bs index 478 ReadCashDistribCurrIdx
    let cashDistribAgentName = ReadOptionalFieldIdx bs index 498 ReadCashDistribAgentNameIdx
    let cashDistribAgentCode = ReadOptionalFieldIdx bs index 499 ReadCashDistribAgentCodeIdx
    let cashDistribAgentAcctNumber = ReadOptionalFieldIdx bs index 500 ReadCashDistribAgentAcctNumberIdx
    let cashDistribPayRef = ReadOptionalFieldIdx bs index 501 ReadCashDistribPayRefIdx
    let cashDistribAgentAcctName = ReadOptionalFieldIdx bs index 502 ReadCashDistribAgentAcctNameIdx
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
    let execID = ReadFieldIdx bs index 17 ReadExecIDIdx
    let ci:NoExecsGrp = {
        ExecID = execID
    }
    ci


// group
let ReadNoTradesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoTradesGrp =
    let tradeReportID = ReadFieldIdx bs index 571 ReadTradeReportIDIdx
    let secondaryTradeReportID = ReadOptionalFieldIdx bs index 818 ReadSecondaryTradeReportIDIdx
    let ci:NoTradesGrp = {
        TradeReportID = tradeReportID
        SecondaryTradeReportID = secondaryTradeReportID
    }
    ci


// group
let ReadNoCollInquiryQualifierGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoCollInquiryQualifierGrp =
    let collInquiryQualifier = ReadFieldIdx bs index 896 ReadCollInquiryQualifierIdx
    let ci:NoCollInquiryQualifierGrp = {
        CollInquiryQualifier = collInquiryQualifier
    }
    ci


// group
let ReadNoCompIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoCompIDsGrp =
    let refCompID = ReadFieldIdx bs index 930 ReadRefCompIDIdx
    let refSubID = ReadOptionalFieldIdx bs index 931 ReadRefSubIDIdx
    let locationID = ReadOptionalFieldIdx bs index 283 ReadLocationIDIdx
    let deskID = ReadOptionalFieldIdx bs index 284 ReadDeskIDIdx
    let ci:NoCompIDsGrp = {
        RefCompID = refCompID
        RefSubID = refSubID
        LocationID = locationID
        DeskID = deskID
    }
    ci


// group
let ReadNetworkStatusResponseNoCompIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NetworkStatusResponseNoCompIDsGrp =
    let refCompID = ReadFieldIdx bs index 930 ReadRefCompIDIdx
    let refSubID = ReadOptionalFieldIdx bs index 931 ReadRefSubIDIdx
    let locationID = ReadOptionalFieldIdx bs index 283 ReadLocationIDIdx
    let deskID = ReadOptionalFieldIdx bs index 284 ReadDeskIDIdx
    let statusValue = ReadOptionalFieldIdx bs index 928 ReadStatusValueIdx
    let statusText = ReadOptionalFieldIdx bs index 929 ReadStatusTextIdx
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
    let hopCompID = ReadFieldIdx bs index 628 ReadHopCompIDIdx
    let hopSendingTime = ReadOptionalFieldIdx bs index 629 ReadHopSendingTimeIdx
    let hopRefID = ReadOptionalFieldIdx bs index 630 ReadHopRefIDIdx
    let ci:NoHopsGrp = {
        HopCompID = hopCompID
        HopSendingTime = hopSendingTime
        HopRefID = hopRefID
    }
    ci


