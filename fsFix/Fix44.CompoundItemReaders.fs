module Fix44.CompoundItemReaders

open ReaderUtils
open Fix44.Fields
open Fix44.FieldReaders
open Fix44.CompoundItems


// group
let ReadNoUnderlyingSecurityAltIDGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoUnderlyingSecurityAltIDGrp =
    let underlyingSecurityAltID = ReadFieldOrdered true bs index 458 ReadUnderlyingSecurityAltIDIdx
    let underlyingSecurityAltIDSource = ReadOptionalFieldOrdered true bs index 459 ReadUnderlyingSecurityAltIDSourceIdx
    let ci:NoUnderlyingSecurityAltIDGrp = {
        UnderlyingSecurityAltID = underlyingSecurityAltID
        UnderlyingSecurityAltIDSource = underlyingSecurityAltIDSource
    }
    ci


// group
let ReadNoUnderlyingStipsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoUnderlyingStipsGrp =
    let underlyingStipType = ReadFieldOrdered true bs index 888 ReadUnderlyingStipTypeIdx
    let underlyingStipValue = ReadOptionalFieldOrdered true bs index 889 ReadUnderlyingStipValueIdx
    let ci:NoUnderlyingStipsGrp = {
        UnderlyingStipType = underlyingStipType
        UnderlyingStipValue = underlyingStipValue
    }
    ci


// component, random access reader
let ReadUnderlyingInstrumentIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : UnderlyingInstrument =
    let underlyingSymbol                     = ReadField bs index 311 ReadUnderlyingSymbolIdx
    let underlyingSymbolSfx                  = ReadOptionalField bs index 312 ReadUnderlyingSymbolSfxIdx
    let underlyingSecurityID                 = ReadOptionalField bs index 309 ReadUnderlyingSecurityIDIdx
    let underlyingSecurityIDSource           = ReadOptionalField bs index 305 ReadUnderlyingSecurityIDSourceIdx
    let noUnderlyingSecurityAltIDGrp         = ReadOptionalGroup bs index 457 ReadNoUnderlyingSecurityAltIDGrpIdx
    let underlyingProduct                    = ReadOptionalField bs index 462 ReadUnderlyingProductIdx
    let underlyingCFICode                    = ReadOptionalField bs index 463 ReadUnderlyingCFICodeIdx
    let underlyingSecurityType               = ReadOptionalField bs index 310 ReadUnderlyingSecurityTypeIdx
    let underlyingSecuritySubType            = ReadOptionalField bs index 763 ReadUnderlyingSecuritySubTypeIdx
    let underlyingMaturityMonthYear          = ReadOptionalField bs index 313 ReadUnderlyingMaturityMonthYearIdx
    let underlyingMaturityDate               = ReadOptionalField bs index 542 ReadUnderlyingMaturityDateIdx
    let underlyingPutOrCall                  = ReadOptionalField bs index 315 ReadUnderlyingPutOrCallIdx
    let underlyingCouponPaymentDate          = ReadOptionalField bs index 241 ReadUnderlyingCouponPaymentDateIdx
    let underlyingIssueDate                  = ReadOptionalField bs index 242 ReadUnderlyingIssueDateIdx
    let underlyingRepoCollateralSecurityType = ReadOptionalField bs index 243 ReadUnderlyingRepoCollateralSecurityTypeIdx
    let underlyingRepurchaseTerm             = ReadOptionalField bs index 244 ReadUnderlyingRepurchaseTermIdx
    let underlyingRepurchaseRate             = ReadOptionalField bs index 245 ReadUnderlyingRepurchaseRateIdx
    let underlyingFactor                     = ReadOptionalField bs index 246 ReadUnderlyingFactorIdx
    let underlyingCreditRating               = ReadOptionalField bs index 256 ReadUnderlyingCreditRatingIdx
    let underlyingInstrRegistry              = ReadOptionalField bs index 595 ReadUnderlyingInstrRegistryIdx
    let underlyingCountryOfIssue             = ReadOptionalField bs index 592 ReadUnderlyingCountryOfIssueIdx
    let underlyingStateOrProvinceOfIssue     = ReadOptionalField bs index 593 ReadUnderlyingStateOrProvinceOfIssueIdx
    let underlyingLocaleOfIssue              = ReadOptionalField bs index 594 ReadUnderlyingLocaleOfIssueIdx
    let underlyingRedemptionDate             = ReadOptionalField bs index 247 ReadUnderlyingRedemptionDateIdx
    let underlyingStrikePrice                = ReadOptionalField bs index 316 ReadUnderlyingStrikePriceIdx
    let underlyingStrikeCurrency             = ReadOptionalField bs index 941 ReadUnderlyingStrikeCurrencyIdx
    let underlyingOptAttribute               = ReadOptionalField bs index 317 ReadUnderlyingOptAttributeIdx
    let underlyingContractMultiplier         = ReadOptionalField bs index 436 ReadUnderlyingContractMultiplierIdx
    let underlyingCouponRate                 = ReadOptionalField bs index 435 ReadUnderlyingCouponRateIdx
    let underlyingSecurityExchange           = ReadOptionalField bs index 308 ReadUnderlyingSecurityExchangeIdx
    let underlyingIssuer                     = ReadOptionalField bs index 306 ReadUnderlyingIssuerIdx
    let encodedUnderlyingIssuer              = ReadOptionalField bs index 362 ReadEncodedUnderlyingIssuerIdx
    let underlyingSecurityDesc               = ReadOptionalField bs index 307 ReadUnderlyingSecurityDescIdx
    let encodedUnderlyingSecurityDesc        = ReadOptionalField bs index 364 ReadEncodedUnderlyingSecurityDescIdx
    let underlyingCPProgram                  = ReadOptionalField bs index 877 ReadUnderlyingCPProgramIdx
    let underlyingCPRegType                  = ReadOptionalField bs index 878 ReadUnderlyingCPRegTypeIdx
    let underlyingCurrency                   = ReadOptionalField bs index 318 ReadUnderlyingCurrencyIdx
    let underlyingQty                        = ReadOptionalField bs index 879 ReadUnderlyingQtyIdx
    let underlyingPx                         = ReadOptionalField bs index 810 ReadUnderlyingPxIdx
    let underlyingDirtyPrice                 = ReadOptionalField bs index 882 ReadUnderlyingDirtyPriceIdx
    let underlyingEndPrice                   = ReadOptionalField bs index 883 ReadUnderlyingEndPriceIdx
    let underlyingStartValue                 = ReadOptionalField bs index 884 ReadUnderlyingStartValueIdx
    let underlyingCurrentValue               = ReadOptionalField bs index 885 ReadUnderlyingCurrentValueIdx
    let underlyingEndValue                   = ReadOptionalField bs index 886 ReadUnderlyingEndValueIdx
    let noUnderlyingStipsGrp                 = ReadOptionalGroup bs index 887 ReadNoUnderlyingStipsGrpIdx
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


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadUnderlyingInstrumentIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : UnderlyingInstrument =
    let underlyingSymbol                     = ReadFieldOrdered         true bs index 311 ReadUnderlyingSymbolIdx
    let underlyingSymbolSfx                  = ReadOptionalFieldOrdered true bs index 312 ReadUnderlyingSymbolSfxIdx
    let underlyingSecurityID                 = ReadOptionalFieldOrdered true bs index 309 ReadUnderlyingSecurityIDIdx
    let underlyingSecurityIDSource           = ReadOptionalFieldOrdered true bs index 305 ReadUnderlyingSecurityIDSourceIdx
    let noUnderlyingSecurityAltIDGrp         = ReadOptionalGroupOrdered true bs index 457 ReadNoUnderlyingSecurityAltIDGrpIdx
    let underlyingProduct                    = ReadOptionalFieldOrdered true bs index 462 ReadUnderlyingProductIdx
    let underlyingCFICode                    = ReadOptionalFieldOrdered true bs index 463 ReadUnderlyingCFICodeIdx
    let underlyingSecurityType               = ReadOptionalFieldOrdered true bs index 310 ReadUnderlyingSecurityTypeIdx
    let underlyingSecuritySubType            = ReadOptionalFieldOrdered true bs index 763 ReadUnderlyingSecuritySubTypeIdx
    let underlyingMaturityMonthYear          = ReadOptionalFieldOrdered true bs index 313 ReadUnderlyingMaturityMonthYearIdx
    let underlyingMaturityDate               = ReadOptionalFieldOrdered true bs index 542 ReadUnderlyingMaturityDateIdx
    let underlyingPutOrCall                  = ReadOptionalFieldOrdered true bs index 315 ReadUnderlyingPutOrCallIdx
    let underlyingCouponPaymentDate          = ReadOptionalFieldOrdered true bs index 241 ReadUnderlyingCouponPaymentDateIdx
    let underlyingIssueDate                  = ReadOptionalFieldOrdered true bs index 242 ReadUnderlyingIssueDateIdx
    let underlyingRepoCollateralSecurityType = ReadOptionalFieldOrdered true bs index 243 ReadUnderlyingRepoCollateralSecurityTypeIdx
    let underlyingRepurchaseTerm             = ReadOptionalFieldOrdered true bs index 244 ReadUnderlyingRepurchaseTermIdx
    let underlyingRepurchaseRate             = ReadOptionalFieldOrdered true bs index 245 ReadUnderlyingRepurchaseRateIdx
    let underlyingFactor                     = ReadOptionalFieldOrdered true bs index 246 ReadUnderlyingFactorIdx
    let underlyingCreditRating               = ReadOptionalFieldOrdered true bs index 256 ReadUnderlyingCreditRatingIdx
    let underlyingInstrRegistry              = ReadOptionalFieldOrdered true bs index 595 ReadUnderlyingInstrRegistryIdx
    let underlyingCountryOfIssue             = ReadOptionalFieldOrdered true bs index 592 ReadUnderlyingCountryOfIssueIdx
    let underlyingStateOrProvinceOfIssue     = ReadOptionalFieldOrdered true bs index 593 ReadUnderlyingStateOrProvinceOfIssueIdx
    let underlyingLocaleOfIssue              = ReadOptionalFieldOrdered true bs index 594 ReadUnderlyingLocaleOfIssueIdx
    let underlyingRedemptionDate             = ReadOptionalFieldOrdered true bs index 247 ReadUnderlyingRedemptionDateIdx
    let underlyingStrikePrice                = ReadOptionalFieldOrdered true bs index 316 ReadUnderlyingStrikePriceIdx
    let underlyingStrikeCurrency             = ReadOptionalFieldOrdered true bs index 941 ReadUnderlyingStrikeCurrencyIdx
    let underlyingOptAttribute               = ReadOptionalFieldOrdered true bs index 317 ReadUnderlyingOptAttributeIdx
    let underlyingContractMultiplier         = ReadOptionalFieldOrdered true bs index 436 ReadUnderlyingContractMultiplierIdx
    let underlyingCouponRate                 = ReadOptionalFieldOrdered true bs index 435 ReadUnderlyingCouponRateIdx
    let underlyingSecurityExchange           = ReadOptionalFieldOrdered true bs index 308 ReadUnderlyingSecurityExchangeIdx
    let underlyingIssuer                     = ReadOptionalFieldOrdered true bs index 306 ReadUnderlyingIssuerIdx
    let encodedUnderlyingIssuer              = ReadOptionalFieldOrdered true bs index 362 ReadEncodedUnderlyingIssuerIdx
    let underlyingSecurityDesc               = ReadOptionalFieldOrdered true bs index 307 ReadUnderlyingSecurityDescIdx
    let encodedUnderlyingSecurityDesc        = ReadOptionalFieldOrdered true bs index 364 ReadEncodedUnderlyingSecurityDescIdx
    let underlyingCPProgram                  = ReadOptionalFieldOrdered true bs index 877 ReadUnderlyingCPProgramIdx
    let underlyingCPRegType                  = ReadOptionalFieldOrdered true bs index 878 ReadUnderlyingCPRegTypeIdx
    let underlyingCurrency                   = ReadOptionalFieldOrdered true bs index 318 ReadUnderlyingCurrencyIdx
    let underlyingQty                        = ReadOptionalFieldOrdered true bs index 879 ReadUnderlyingQtyIdx
    let underlyingPx                         = ReadOptionalFieldOrdered true bs index 810 ReadUnderlyingPxIdx
    let underlyingDirtyPrice                 = ReadOptionalFieldOrdered true bs index 882 ReadUnderlyingDirtyPriceIdx
    let underlyingEndPrice                   = ReadOptionalFieldOrdered true bs index 883 ReadUnderlyingEndPriceIdx
    let underlyingStartValue                 = ReadOptionalFieldOrdered true bs index 884 ReadUnderlyingStartValueIdx
    let underlyingCurrentValue               = ReadOptionalFieldOrdered true bs index 885 ReadUnderlyingCurrentValueIdx
    let underlyingEndValue                   = ReadOptionalFieldOrdered true bs index 886 ReadUnderlyingEndValueIdx
    let noUnderlyingStipsGrp                 = ReadOptionalGroupOrdered true bs index 887 ReadNoUnderlyingStipsGrpIdx
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
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentIdxOrdered
    let collAction = ReadOptionalFieldOrdered true bs index 944 ReadCollActionIdx
    let ci:CollateralResponseNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    ci


// group
let ReadCollateralAssignmentNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CollateralAssignmentNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentIdxOrdered
    let collAction = ReadOptionalFieldOrdered true bs index 944 ReadCollActionIdx
    let ci:CollateralAssignmentNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    ci


// group
let ReadCollateralRequestNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CollateralRequestNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentIdxOrdered
    let collAction = ReadOptionalFieldOrdered true bs index 944 ReadCollActionIdx
    let ci:CollateralRequestNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    ci


// group
let ReadPositionReportNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionReportNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentIdxOrdered
    let underlyingSettlPrice = ReadFieldOrdered true bs index 732 ReadUnderlyingSettlPriceIdx
    let underlyingSettlPriceType = ReadFieldOrdered true bs index 733 ReadUnderlyingSettlPriceTypeIdx
    let ci:PositionReportNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        UnderlyingSettlPrice = underlyingSettlPrice
        UnderlyingSettlPriceType = underlyingSettlPriceType
    }
    ci


// group
let ReadNoNestedPartySubIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNestedPartySubIDsGrp =
    let nestedPartySubID = ReadFieldOrdered true bs index 545 ReadNestedPartySubIDIdx
    let nestedPartySubIDType = ReadOptionalFieldOrdered true bs index 805 ReadNestedPartySubIDTypeIdx
    let ci:NoNestedPartySubIDsGrp = {
        NestedPartySubID = nestedPartySubID
        NestedPartySubIDType = nestedPartySubIDType
    }
    ci


// group
let ReadNoNestedPartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNestedPartyIDsGrp =
    let nestedPartyID          = ReadFieldOrdered true bs index 524 ReadNestedPartyIDIdx
    let nestedPartyIDSource    = ReadOptionalFieldOrdered true bs index 525 ReadNestedPartyIDSourceIdx
    let nestedPartyRole        = ReadOptionalFieldOrdered true bs index 538 ReadNestedPartyRoleIdx
    let noNestedPartySubIDsGrp = ReadOptionalGroupOrdered true bs index 804 ReadNoNestedPartySubIDsGrpIdx
    let ci:NoNestedPartyIDsGrp = {
        NestedPartyID = nestedPartyID
        NestedPartyIDSource = nestedPartyIDSource
        NestedPartyRole = nestedPartyRole
        NoNestedPartySubIDsGrp = noNestedPartySubIDsGrp
    }
    ci


// group
let ReadNoPositionsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoPositionsGrp =
    let posType = ReadFieldOrdered true bs index 703 ReadPosTypeIdx
    let longQty = ReadOptionalFieldOrdered true bs index 704 ReadLongQtyIdx
    let shortQty = ReadOptionalFieldOrdered true bs index 705 ReadShortQtyIdx
    let posQtyStatus = ReadOptionalFieldOrdered true bs index 706 ReadPosQtyStatusIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let ci:NoPositionsGrp = {
        PosType = posType
        LongQty = longQty
        ShortQty = shortQty
        PosQtyStatus = posQtyStatus
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
    }
    ci


// component, random access reader
let ReadPositionQtyIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionQty =
    let noPositionsGrp = ReadGroup bs index 702 ReadNoPositionsGrpIdx
    let ci:PositionQty = {
        NoPositionsGrp = noPositionsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadPositionQtyIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionQty =
    let noPositionsGrp = ReadGroup bs index 702 ReadNoPositionsGrpIdx
    let ci:PositionQty = {
        NoPositionsGrp = noPositionsGrp
    }
    ci


// group
let ReadNoRegistDtlsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoRegistDtlsGrp =
    let registDtls = ReadFieldOrdered true bs index 509 ReadRegistDtlsIdx
    let registEmail = ReadOptionalFieldOrdered true bs index 511 ReadRegistEmailIdx
    let mailingDtls = ReadOptionalFieldOrdered true bs index 474 ReadMailingDtlsIdx
    let mailingInst = ReadOptionalFieldOrdered true bs index 482 ReadMailingInstIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let ownerType = ReadOptionalFieldOrdered true bs index 522 ReadOwnerTypeIdx
    let dateOfBirth = ReadOptionalFieldOrdered true bs index 486 ReadDateOfBirthIdx
    let investorCountryOfResidence = ReadOptionalFieldOrdered true bs index 475 ReadInvestorCountryOfResidenceIdx
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
    let nested2PartySubID = ReadFieldOrdered true bs index 760 ReadNested2PartySubIDIdx
    let nested2PartySubIDType = ReadOptionalFieldOrdered true bs index 807 ReadNested2PartySubIDTypeIdx
    let ci:NoNested2PartySubIDsGrp = {
        Nested2PartySubID = nested2PartySubID
        Nested2PartySubIDType = nested2PartySubIDType
    }
    ci


// group
let ReadNoNested2PartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNested2PartyIDsGrp =
    let nested2PartyID = ReadFieldOrdered true bs index 757 ReadNested2PartyIDIdx
    let nested2PartyIDSource = ReadOptionalFieldOrdered true bs index 758 ReadNested2PartyIDSourceIdx
    let nested2PartyRole = ReadOptionalFieldOrdered true bs index 759 ReadNested2PartyRoleIdx
    let noNested2PartySubIDsGrp = ReadOptionalGroupOrdered true bs index 806 ReadNoNested2PartySubIDsGrpIdx
    let ci:NoNested2PartyIDsGrp = {
        Nested2PartyID = nested2PartyID
        Nested2PartyIDSource = nested2PartyIDSource
        Nested2PartyRole = nested2PartyRole
        NoNested2PartySubIDsGrp = noNested2PartySubIDsGrp
    }
    ci


// group
let ReadTradeCaptureReportAckNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportAckNoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocIDIdx
    let noNested2PartyIDsGrp = ReadOptionalGroupOrdered true bs index 756 ReadNoNested2PartyIDsGrpIdx
    let allocQty = ReadOptionalFieldOrdered true bs index 80 ReadAllocQtyIdx
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
    let legSecurityAltID = ReadFieldOrdered true bs index 605 ReadLegSecurityAltIDIdx
    let legSecurityAltIDSource = ReadOptionalFieldOrdered true bs index 606 ReadLegSecurityAltIDSourceIdx
    let ci:NoLegSecurityAltIDGrp = {
        LegSecurityAltID = legSecurityAltID
        LegSecurityAltIDSource = legSecurityAltIDSource
    }
    ci


// component, random access reader
let ReadInstrumentLegFGIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentLegFG =
    let legSymbol = ReadField bs index 600 ReadLegSymbolIdx
    let legSymbolSfx = ReadOptionalField bs index 601 ReadLegSymbolSfxIdx
    let legSecurityID = ReadOptionalField bs index 602 ReadLegSecurityIDIdx
    let legSecurityIDSource = ReadOptionalField bs index 603 ReadLegSecurityIDSourceIdx
    let noLegSecurityAltIDGrp = ReadOptionalGroup bs index 604 ReadNoLegSecurityAltIDGrpIdx
    let legProduct = ReadOptionalField bs index 607 ReadLegProductIdx
    let legCFICode = ReadOptionalField bs index 608 ReadLegCFICodeIdx
    let legSecurityType = ReadOptionalField bs index 609 ReadLegSecurityTypeIdx
    let legSecuritySubType = ReadOptionalField bs index 764 ReadLegSecuritySubTypeIdx
    let legMaturityMonthYear = ReadOptionalField bs index 610 ReadLegMaturityMonthYearIdx
    let legMaturityDate = ReadOptionalField bs index 611 ReadLegMaturityDateIdx
    let legCouponPaymentDate = ReadOptionalField bs index 248 ReadLegCouponPaymentDateIdx
    let legIssueDate = ReadOptionalField bs index 249 ReadLegIssueDateIdx
    let legRepoCollateralSecurityType = ReadOptionalField bs index 250 ReadLegRepoCollateralSecurityTypeIdx
    let legRepurchaseTerm = ReadOptionalField bs index 251 ReadLegRepurchaseTermIdx
    let legRepurchaseRate = ReadOptionalField bs index 252 ReadLegRepurchaseRateIdx
    let legFactor = ReadOptionalField bs index 253 ReadLegFactorIdx
    let legCreditRating = ReadOptionalField bs index 257 ReadLegCreditRatingIdx
    let legInstrRegistry = ReadOptionalField bs index 599 ReadLegInstrRegistryIdx
    let legCountryOfIssue = ReadOptionalField bs index 596 ReadLegCountryOfIssueIdx
    let legStateOrProvinceOfIssue = ReadOptionalField bs index 597 ReadLegStateOrProvinceOfIssueIdx
    let legLocaleOfIssue = ReadOptionalField bs index 598 ReadLegLocaleOfIssueIdx
    let legRedemptionDate = ReadOptionalField bs index 254 ReadLegRedemptionDateIdx
    let legStrikePrice = ReadOptionalField bs index 612 ReadLegStrikePriceIdx
    let legStrikeCurrency = ReadOptionalField bs index 942 ReadLegStrikeCurrencyIdx
    let legOptAttribute = ReadOptionalField bs index 613 ReadLegOptAttributeIdx
    let legContractMultiplier = ReadOptionalField bs index 614 ReadLegContractMultiplierIdx
    let legCouponRate = ReadOptionalField bs index 615 ReadLegCouponRateIdx
    let legSecurityExchange = ReadOptionalField bs index 616 ReadLegSecurityExchangeIdx
    let legIssuer = ReadOptionalField bs index 617 ReadLegIssuerIdx
    let encodedLegIssuer = ReadOptionalField bs index 618 ReadEncodedLegIssuerIdx
    let legSecurityDesc = ReadOptionalField bs index 620 ReadLegSecurityDescIdx
    let encodedLegSecurityDesc = ReadOptionalField bs index 621 ReadEncodedLegSecurityDescIdx
    let legRatioQty = ReadOptionalField bs index 623 ReadLegRatioQtyIdx
    let legSide = ReadOptionalField bs index 624 ReadLegSideIdx
    let legCurrency = ReadOptionalField bs index 556 ReadLegCurrencyIdx
    let legPool = ReadOptionalField bs index 740 ReadLegPoolIdx
    let legDatedDate = ReadOptionalField bs index 739 ReadLegDatedDateIdx
    let legContractSettlMonth = ReadOptionalField bs index 955 ReadLegContractSettlMonthIdx
    let legInterestAccrualDate = ReadOptionalField bs index 956 ReadLegInterestAccrualDateIdx
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


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadInstrumentLegFGIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentLegFG =
    let legSymbol = ReadFieldOrdered true bs index 600 ReadLegSymbolIdx
    let legSymbolSfx = ReadOptionalFieldOrdered true bs index 601 ReadLegSymbolSfxIdx
    let legSecurityID = ReadOptionalFieldOrdered true bs index 602 ReadLegSecurityIDIdx
    let legSecurityIDSource = ReadOptionalFieldOrdered true bs index 603 ReadLegSecurityIDSourceIdx
    let noLegSecurityAltIDGrp = ReadOptionalGroupOrdered true bs index 604 ReadNoLegSecurityAltIDGrpIdx
    let legProduct = ReadOptionalFieldOrdered true bs index 607 ReadLegProductIdx
    let legCFICode = ReadOptionalFieldOrdered true bs index 608 ReadLegCFICodeIdx
    let legSecurityType = ReadOptionalFieldOrdered true bs index 609 ReadLegSecurityTypeIdx
    let legSecuritySubType = ReadOptionalFieldOrdered true bs index 764 ReadLegSecuritySubTypeIdx
    let legMaturityMonthYear = ReadOptionalFieldOrdered true bs index 610 ReadLegMaturityMonthYearIdx
    let legMaturityDate = ReadOptionalFieldOrdered true bs index 611 ReadLegMaturityDateIdx
    let legCouponPaymentDate = ReadOptionalFieldOrdered true bs index 248 ReadLegCouponPaymentDateIdx
    let legIssueDate = ReadOptionalFieldOrdered true bs index 249 ReadLegIssueDateIdx
    let legRepoCollateralSecurityType = ReadOptionalFieldOrdered true bs index 250 ReadLegRepoCollateralSecurityTypeIdx
    let legRepurchaseTerm = ReadOptionalFieldOrdered true bs index 251 ReadLegRepurchaseTermIdx
    let legRepurchaseRate = ReadOptionalFieldOrdered true bs index 252 ReadLegRepurchaseRateIdx
    let legFactor = ReadOptionalFieldOrdered true bs index 253 ReadLegFactorIdx
    let legCreditRating = ReadOptionalFieldOrdered true bs index 257 ReadLegCreditRatingIdx
    let legInstrRegistry = ReadOptionalFieldOrdered true bs index 599 ReadLegInstrRegistryIdx
    let legCountryOfIssue = ReadOptionalFieldOrdered true bs index 596 ReadLegCountryOfIssueIdx
    let legStateOrProvinceOfIssue = ReadOptionalFieldOrdered true bs index 597 ReadLegStateOrProvinceOfIssueIdx
    let legLocaleOfIssue = ReadOptionalFieldOrdered true bs index 598 ReadLegLocaleOfIssueIdx
    let legRedemptionDate = ReadOptionalFieldOrdered true bs index 254 ReadLegRedemptionDateIdx
    let legStrikePrice = ReadOptionalFieldOrdered true bs index 612 ReadLegStrikePriceIdx
    let legStrikeCurrency = ReadOptionalFieldOrdered true bs index 942 ReadLegStrikeCurrencyIdx
    let legOptAttribute = ReadOptionalFieldOrdered true bs index 613 ReadLegOptAttributeIdx
    let legContractMultiplier = ReadOptionalFieldOrdered true bs index 614 ReadLegContractMultiplierIdx
    let legCouponRate = ReadOptionalFieldOrdered true bs index 615 ReadLegCouponRateIdx
    let legSecurityExchange = ReadOptionalFieldOrdered true bs index 616 ReadLegSecurityExchangeIdx
    let legIssuer = ReadOptionalFieldOrdered true bs index 617 ReadLegIssuerIdx
    let encodedLegIssuer = ReadOptionalFieldOrdered true bs index 618 ReadEncodedLegIssuerIdx
    let legSecurityDesc = ReadOptionalFieldOrdered true bs index 620 ReadLegSecurityDescIdx
    let encodedLegSecurityDesc = ReadOptionalFieldOrdered true bs index 621 ReadEncodedLegSecurityDescIdx
    let legRatioQty = ReadOptionalFieldOrdered true bs index 623 ReadLegRatioQtyIdx
    let legSide = ReadOptionalFieldOrdered true bs index 624 ReadLegSideIdx
    let legCurrency = ReadOptionalFieldOrdered true bs index 556 ReadLegCurrencyIdx
    let legPool = ReadOptionalFieldOrdered true bs index 740 ReadLegPoolIdx
    let legDatedDate = ReadOptionalFieldOrdered true bs index 739 ReadLegDatedDateIdx
    let legContractSettlMonth = ReadOptionalFieldOrdered true bs index 955 ReadLegContractSettlMonthIdx
    let legInterestAccrualDate = ReadOptionalFieldOrdered true bs index 956 ReadLegInterestAccrualDateIdx
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
    let legStipulationType = ReadFieldOrdered true bs index 688 ReadLegStipulationTypeIdx
    let legStipulationValue = ReadOptionalFieldOrdered true bs index 689 ReadLegStipulationValueIdx
    let ci:NoLegStipulationsGrp = {
        LegStipulationType = legStipulationType
        LegStipulationValue = legStipulationValue
    }
    ci


// group
let ReadTradeCaptureReportAckNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportAckNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGIdxOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrpIdx
    let legPositionEffect = ReadOptionalFieldOrdered true bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldOrdered true bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldOrdered true bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldOrdered true bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDateIdx
    let legLastPx = ReadOptionalFieldOrdered true bs index 637 ReadLegLastPxIdx
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
    let partySubID = ReadFieldOrdered true bs index 523 ReadPartySubIDIdx
    let partySubIDType = ReadOptionalFieldOrdered true bs index 803 ReadPartySubIDTypeIdx
    let ci:NoPartySubIDsGrp = {
        PartySubID = partySubID
        PartySubIDType = partySubIDType
    }
    ci


// group
let ReadNoPartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoPartyIDsGrp =
    let partyID = ReadFieldOrdered true bs index 448 ReadPartyIDIdx
    let partyIDSource = ReadOptionalFieldOrdered true bs index 447 ReadPartyIDSourceIdx
    let partyRole = ReadOptionalFieldOrdered true bs index 452 ReadPartyRoleIdx
    let noPartySubIDsGrp = ReadOptionalGroupOrdered true bs index 802 ReadNoPartySubIDsGrpIdx
    let ci:NoPartyIDsGrp = {
        PartyID = partyID
        PartyIDSource = partyIDSource
        PartyRole = partyRole
        NoPartySubIDsGrp = noPartySubIDsGrp
    }
    ci


// group
let ReadNoClearingInstructionsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoClearingInstructionsGrp =
    let clearingInstruction = ReadFieldOrdered true bs index 577 ReadClearingInstructionIdx
    let ci:NoClearingInstructionsGrp = {
        ClearingInstruction = clearingInstruction
    }
    ci


// component, random access reader
let ReadCommissionDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CommissionData =
    let commission = ReadOptionalField bs index 12 ReadCommissionIdx
    let commType = ReadOptionalField bs index 13 ReadCommTypeIdx
    let commCurrency = ReadOptionalField bs index 479 ReadCommCurrencyIdx
    let fundRenewWaiv = ReadOptionalField bs index 497 ReadFundRenewWaivIdx
    let ci:CommissionData = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadCommissionDataIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CommissionData =
    let commission = ReadOptionalFieldOrdered true bs index 12 ReadCommissionIdx
    let commType = ReadOptionalFieldOrdered true bs index 13 ReadCommTypeIdx
    let commCurrency = ReadOptionalFieldOrdered true bs index 479 ReadCommCurrencyIdx
    let fundRenewWaiv = ReadOptionalFieldOrdered true bs index 497 ReadFundRenewWaivIdx
    let ci:CommissionData = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    ci


// group
let ReadNoContAmtsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoContAmtsGrp =
    let contAmtType = ReadFieldOrdered true bs index 519 ReadContAmtTypeIdx
    let contAmtValue = ReadOptionalFieldOrdered true bs index 520 ReadContAmtValueIdx
    let contAmtCurr = ReadOptionalFieldOrdered true bs index 521 ReadContAmtCurrIdx
    let ci:NoContAmtsGrp = {
        ContAmtType = contAmtType
        ContAmtValue = contAmtValue
        ContAmtCurr = contAmtCurr
    }
    ci


// group
let ReadNoStipulationsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoStipulationsGrp =
    let stipulationType = ReadFieldOrdered true bs index 233 ReadStipulationTypeIdx
    let stipulationValue = ReadOptionalFieldOrdered true bs index 234 ReadStipulationValueIdx
    let ci:NoStipulationsGrp = {
        StipulationType = stipulationType
        StipulationValue = stipulationValue
    }
    ci


// group
let ReadNoMiscFeesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMiscFeesGrp =
    let miscFeeAmt = ReadFieldOrdered true bs index 137 ReadMiscFeeAmtIdx
    let miscFeeCurr = ReadOptionalFieldOrdered true bs index 138 ReadMiscFeeCurrIdx
    let miscFeeType = ReadOptionalFieldOrdered true bs index 139 ReadMiscFeeTypeIdx
    let miscFeeBasis = ReadOptionalFieldOrdered true bs index 891 ReadMiscFeeBasisIdx
    let ci:NoMiscFeesGrp = {
        MiscFeeAmt = miscFeeAmt
        MiscFeeCurr = miscFeeCurr
        MiscFeeType = miscFeeType
        MiscFeeBasis = miscFeeBasis
    }
    ci


// group
let ReadTradeCaptureReportNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportNoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocIDIdx
    let noNested2PartyIDsGrp = ReadOptionalGroupOrdered true bs index 756 ReadNoNested2PartyIDsGrpIdx
    let allocQty = ReadOptionalFieldOrdered true bs index 80 ReadAllocQtyIdx
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
    let side = ReadFieldOrdered true bs index 54 ReadSideIdx
    let orderID = ReadFieldOrdered true bs index 37 ReadOrderIDIdx
    let secondaryOrderID = ReadOptionalFieldOrdered true bs index 198 ReadSecondaryOrderIDIdx
    let clOrdID = ReadOptionalFieldOrdered true bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let listID = ReadOptionalFieldOrdered true bs index 66 ReadListIDIdx
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrpIdx
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldOrdered true bs index 581 ReadAccountTypeIdx
    let processCode = ReadOptionalFieldOrdered true bs index 81 ReadProcessCodeIdx
    let oddLot = ReadOptionalFieldOrdered true bs index 575 ReadOddLotIdx
    let noClearingInstructionsGrp = ReadOptionalGroupOrdered true bs index 576 ReadNoClearingInstructionsGrpIdx
    let clearingFeeIndicator = ReadOptionalFieldOrdered true bs index 635 ReadClearingFeeIndicatorIdx
    let tradeInputSource = ReadOptionalFieldOrdered true bs index 578 ReadTradeInputSourceIdx
    let tradeInputDevice = ReadOptionalFieldOrdered true bs index 579 ReadTradeInputDeviceIdx
    let orderInputDevice = ReadOptionalFieldOrdered true bs index 821 ReadOrderInputDeviceIdx
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrencyIdx
    let complianceID = ReadOptionalFieldOrdered true bs index 376 ReadComplianceIDIdx
    let solicitedFlag = ReadOptionalFieldOrdered true bs index 377 ReadSolicitedFlagIdx
    let orderCapacity = ReadOptionalFieldOrdered true bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldOrdered true bs index 529 ReadOrderRestrictionsIdx
    let custOrderCapacity = ReadOptionalFieldOrdered true bs index 582 ReadCustOrderCapacityIdx
    let ordType = ReadOptionalFieldOrdered true bs index 40 ReadOrdTypeIdx
    let execInst = ReadOptionalFieldOrdered true bs index 18 ReadExecInstIdx
    let transBkdTime = ReadOptionalFieldOrdered true bs index 483 ReadTransBkdTimeIdx
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let timeBracket = ReadOptionalFieldOrdered true bs index 943 ReadTimeBracketIdx
    let commissionData = ReadComponentOrdered true bs index ReadCommissionDataIdxOrdered
    let grossTradeAmt = ReadOptionalFieldOrdered true bs index 381 ReadGrossTradeAmtIdx
    let numDaysInterest = ReadOptionalFieldOrdered true bs index 157 ReadNumDaysInterestIdx
    let exDate = ReadOptionalFieldOrdered true bs index 230 ReadExDateIdx
    let accruedInterestRate = ReadOptionalFieldOrdered true bs index 158 ReadAccruedInterestRateIdx
    let accruedInterestAmt = ReadOptionalFieldOrdered true bs index 159 ReadAccruedInterestAmtIdx
    let interestAtMaturity = ReadOptionalFieldOrdered true bs index 738 ReadInterestAtMaturityIdx
    let endAccruedInterestAmt = ReadOptionalFieldOrdered true bs index 920 ReadEndAccruedInterestAmtIdx
    let startCash = ReadOptionalFieldOrdered true bs index 921 ReadStartCashIdx
    let endCash = ReadOptionalFieldOrdered true bs index 922 ReadEndCashIdx
    let concession = ReadOptionalFieldOrdered true bs index 238 ReadConcessionIdx
    let totalTakedown = ReadOptionalFieldOrdered true bs index 237 ReadTotalTakedownIdx
    let netMoney = ReadOptionalFieldOrdered true bs index 118 ReadNetMoneyIdx
    let settlCurrAmt = ReadOptionalFieldOrdered true bs index 119 ReadSettlCurrAmtIdx
    let settlCurrency = ReadOptionalFieldOrdered true bs index 120 ReadSettlCurrencyIdx
    let settlCurrFxRate = ReadOptionalFieldOrdered true bs index 155 ReadSettlCurrFxRateIdx
    let settlCurrFxRateCalc = ReadOptionalFieldOrdered true bs index 156 ReadSettlCurrFxRateCalcIdx
    let positionEffect = ReadOptionalFieldOrdered true bs index 77 ReadPositionEffectIdx
    let text = ReadOptionalFieldOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedTextIdx
    let sideMultiLegReportingType = ReadOptionalFieldOrdered true bs index 752 ReadSideMultiLegReportingTypeIdx
    let noContAmtsGrp = ReadOptionalGroupOrdered true bs index 518 ReadNoContAmtsGrpIdx
    let noStipulationsGrp = ReadOptionalGroupOrdered true bs index 232 ReadNoStipulationsGrpIdx
    let noMiscFeesGrp = ReadOptionalGroupOrdered true bs index 136 ReadNoMiscFeesGrpIdx
    let exchangeRule = ReadOptionalFieldOrdered true bs index 825 ReadExchangeRuleIdx
    let tradeAllocIndicator = ReadOptionalFieldOrdered true bs index 826 ReadTradeAllocIndicatorIdx
    let preallocMethod = ReadOptionalFieldOrdered true bs index 591 ReadPreallocMethodIdx
    let allocID = ReadOptionalFieldOrdered true bs index 70 ReadAllocIDIdx
    let tradeCaptureReportNoAllocsGrp = ReadOptionalGroupOrdered true bs index 78 ReadTradeCaptureReportNoAllocsGrpIdx
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
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGIdxOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrpIdx
    let legPositionEffect = ReadOptionalFieldOrdered true bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldOrdered true bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldOrdered true bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldOrdered true bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDateIdx
    let legLastPx = ReadOptionalFieldOrdered true bs index 637 ReadLegLastPxIdx
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
    let posAmtType = ReadFieldOrdered true bs index 707 ReadPosAmtTypeIdx
    let posAmt = ReadFieldOrdered true bs index 708 ReadPosAmtIdx
    let ci:NoPosAmtGrp = {
        PosAmtType = posAmtType
        PosAmt = posAmt
    }
    ci


// component, random access reader
let ReadPositionAmountDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionAmountData =
    let noPosAmtGrp = ReadGroup bs index 753 ReadNoPosAmtGrpIdx
    let ci:PositionAmountData = {
        NoPosAmtGrp = noPosAmtGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadPositionAmountDataIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionAmountData =
    let noPosAmtGrp = ReadGroup bs index 753 ReadNoPosAmtGrpIdx
    let ci:PositionAmountData = {
        NoPosAmtGrp = noPosAmtGrp
    }
    ci


// group
let ReadNoSettlPartySubIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSettlPartySubIDsGrp =
    let settlPartySubID = ReadFieldOrdered true bs index 785 ReadSettlPartySubIDIdx
    let settlPartySubIDType = ReadOptionalFieldOrdered true bs index 786 ReadSettlPartySubIDTypeIdx
    let ci:NoSettlPartySubIDsGrp = {
        SettlPartySubID = settlPartySubID
        SettlPartySubIDType = settlPartySubIDType
    }
    ci


// group
let ReadNoSettlPartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSettlPartyIDsGrp =
    let settlPartyID = ReadFieldOrdered true bs index 782 ReadSettlPartyIDIdx
    let settlPartyIDSource = ReadOptionalFieldOrdered true bs index 783 ReadSettlPartyIDSourceIdx
    let settlPartyRole = ReadOptionalFieldOrdered true bs index 784 ReadSettlPartyRoleIdx
    let noSettlPartySubIDsGrp = ReadOptionalGroupOrdered true bs index 801 ReadNoSettlPartySubIDsGrpIdx
    let ci:NoSettlPartyIDsGrp = {
        SettlPartyID = settlPartyID
        SettlPartyIDSource = settlPartyIDSource
        SettlPartyRole = settlPartyRole
        NoSettlPartySubIDsGrp = noSettlPartySubIDsGrp
    }
    ci


// group
let ReadNoDlvyInstGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoDlvyInstGrp =
    let settlInstSource = ReadFieldOrdered true bs index 165 ReadSettlInstSourceIdx
    let dlvyInstType = ReadOptionalFieldOrdered true bs index 787 ReadDlvyInstTypeIdx
    let noSettlPartyIDsGrp = ReadOptionalGroupOrdered true bs index 781 ReadNoSettlPartyIDsGrpIdx
    let ci:NoDlvyInstGrp = {
        SettlInstSource = settlInstSource
        DlvyInstType = dlvyInstType
        NoSettlPartyIDsGrp = noSettlPartyIDsGrp
    }
    ci


// component, random access reader
let ReadSettlInstructionsDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SettlInstructionsData =
    let settlDeliveryType = ReadOptionalField bs index 172 ReadSettlDeliveryTypeIdx
    let standInstDbType = ReadOptionalField bs index 169 ReadStandInstDbTypeIdx
    let standInstDbName = ReadOptionalField bs index 170 ReadStandInstDbNameIdx
    let standInstDbID = ReadOptionalField bs index 171 ReadStandInstDbIDIdx
    let noDlvyInstGrp = ReadOptionalGroup bs index 85 ReadNoDlvyInstGrpIdx
    let ci:SettlInstructionsData = {
        SettlDeliveryType = settlDeliveryType
        StandInstDbType = standInstDbType
        StandInstDbName = standInstDbName
        StandInstDbID = standInstDbID
        NoDlvyInstGrp = noDlvyInstGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadSettlInstructionsDataIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SettlInstructionsData =
    let settlDeliveryType = ReadOptionalFieldOrdered true bs index 172 ReadSettlDeliveryTypeIdx
    let standInstDbType = ReadOptionalFieldOrdered true bs index 169 ReadStandInstDbTypeIdx
    let standInstDbName = ReadOptionalFieldOrdered true bs index 170 ReadStandInstDbNameIdx
    let standInstDbID = ReadOptionalFieldOrdered true bs index 171 ReadStandInstDbIDIdx
    let noDlvyInstGrp = ReadOptionalGroupOrdered true bs index 85 ReadNoDlvyInstGrpIdx
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
    let settlInstID = ReadFieldOrdered true bs index 162 ReadSettlInstIDIdx
    let settlInstTransType = ReadOptionalFieldOrdered true bs index 163 ReadSettlInstTransTypeIdx
    let settlInstRefID = ReadOptionalFieldOrdered true bs index 214 ReadSettlInstRefIDIdx
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrpIdx
    let side = ReadOptionalFieldOrdered true bs index 54 ReadSideIdx
    let product = ReadOptionalFieldOrdered true bs index 460 ReadProductIdx
    let securityType = ReadOptionalFieldOrdered true bs index 167 ReadSecurityTypeIdx
    let cFICode = ReadOptionalFieldOrdered true bs index 461 ReadCFICodeIdx
    let effectiveTime = ReadOptionalFieldOrdered true bs index 168 ReadEffectiveTimeIdx
    let expireTime = ReadOptionalFieldOrdered true bs index 126 ReadExpireTimeIdx
    let lastUpdateTime = ReadOptionalFieldOrdered true bs index 779 ReadLastUpdateTimeIdx
    let settlInstructionsData = ReadComponentOrdered true bs index ReadSettlInstructionsDataIdxOrdered
    let paymentMethod = ReadOptionalFieldOrdered true bs index 492 ReadPaymentMethodIdx
    let paymentRef = ReadOptionalFieldOrdered true bs index 476 ReadPaymentRefIdx
    let cardHolderName = ReadOptionalFieldOrdered true bs index 488 ReadCardHolderNameIdx
    let cardNumber = ReadOptionalFieldOrdered true bs index 489 ReadCardNumberIdx
    let cardStartDate = ReadOptionalFieldOrdered true bs index 503 ReadCardStartDateIdx
    let cardExpDate = ReadOptionalFieldOrdered true bs index 490 ReadCardExpDateIdx
    let cardIssNum = ReadOptionalFieldOrdered true bs index 491 ReadCardIssNumIdx
    let paymentDate = ReadOptionalFieldOrdered true bs index 504 ReadPaymentDateIdx
    let paymentRemitterID = ReadOptionalFieldOrdered true bs index 505 ReadPaymentRemitterIDIdx
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
    let trdRegTimestamp = ReadFieldOrdered true bs index 769 ReadTrdRegTimestampIdx
    let trdRegTimestampType = ReadOptionalFieldOrdered true bs index 770 ReadTrdRegTimestampTypeIdx
    let trdRegTimestampOrigin = ReadOptionalFieldOrdered true bs index 771 ReadTrdRegTimestampOriginIdx
    let ci:NoTrdRegTimestampsGrp = {
        TrdRegTimestamp = trdRegTimestamp
        TrdRegTimestampType = trdRegTimestampType
        TrdRegTimestampOrigin = trdRegTimestampOrigin
    }
    ci


// component, random access reader
let ReadTrdRegTimestampsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TrdRegTimestamps =
    let noTrdRegTimestampsGrp = ReadGroup bs index 768 ReadNoTrdRegTimestampsGrpIdx
    let ci:TrdRegTimestamps = {
        NoTrdRegTimestampsGrp = noTrdRegTimestampsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadTrdRegTimestampsIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TrdRegTimestamps =
    let noTrdRegTimestampsGrp = ReadGroup bs index 768 ReadNoTrdRegTimestampsGrpIdx
    let ci:TrdRegTimestamps = {
        NoTrdRegTimestampsGrp = noTrdRegTimestampsGrp
    }
    ci


// group
let ReadAllocationReportNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AllocationReportNoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let matchStatus = ReadOptionalFieldOrdered true bs index 573 ReadMatchStatusIdx
    let allocPrice = ReadOptionalFieldOrdered true bs index 366 ReadAllocPriceIdx
    let allocQty = ReadFieldOrdered true bs index 80 ReadAllocQtyIdx
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocIDIdx
    let processCode = ReadOptionalFieldOrdered true bs index 81 ReadProcessCodeIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let notifyBrokerOfCredit = ReadOptionalFieldOrdered true bs index 208 ReadNotifyBrokerOfCreditIdx
    let allocHandlInst = ReadOptionalFieldOrdered true bs index 209 ReadAllocHandlInstIdx
    let allocText = ReadOptionalFieldOrdered true bs index 161 ReadAllocTextIdx
    let encodedAllocText = ReadOptionalFieldOrdered true bs index 360 ReadEncodedAllocTextIdx
    let commissionData = ReadComponentOrdered true bs index ReadCommissionDataIdxOrdered
    let allocAvgPx = ReadOptionalFieldOrdered true bs index 153 ReadAllocAvgPxIdx
    let allocNetMoney = ReadOptionalFieldOrdered true bs index 154 ReadAllocNetMoneyIdx
    let settlCurrAmt = ReadOptionalFieldOrdered true bs index 119 ReadSettlCurrAmtIdx
    let allocSettlCurrAmt = ReadOptionalFieldOrdered true bs index 737 ReadAllocSettlCurrAmtIdx
    let settlCurrency = ReadOptionalFieldOrdered true bs index 120 ReadSettlCurrencyIdx
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let settlCurrFxRate = ReadOptionalFieldOrdered true bs index 155 ReadSettlCurrFxRateIdx
    let settlCurrFxRateCalc = ReadOptionalFieldOrdered true bs index 156 ReadSettlCurrFxRateCalcIdx
    let allocAccruedInterestAmt = ReadOptionalFieldOrdered true bs index 742 ReadAllocAccruedInterestAmtIdx
    let allocInterestAtMaturity = ReadOptionalFieldOrdered true bs index 741 ReadAllocInterestAtMaturityIdx
    let noMiscFeesGrp = ReadOptionalGroupOrdered true bs index 136 ReadNoMiscFeesGrpIdx
    let noClearingInstructionsGrp = ReadOptionalGroupOrdered true bs index 576 ReadNoClearingInstructionsGrpIdx
    let clearingFeeIndicator = ReadOptionalFieldOrdered true bs index 635 ReadClearingFeeIndicatorIdx
    let allocSettlInstType = ReadOptionalFieldOrdered true bs index 780 ReadAllocSettlInstTypeIdx
    let settlInstructionsData = ReadComponentOrdered true bs index ReadSettlInstructionsDataIdxOrdered
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
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let matchStatus = ReadOptionalFieldOrdered true bs index 573 ReadMatchStatusIdx
    let allocPrice = ReadOptionalFieldOrdered true bs index 366 ReadAllocPriceIdx
    let allocQty = ReadOptionalFieldOrdered true bs index 80 ReadAllocQtyIdx
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocIDIdx
    let processCode = ReadOptionalFieldOrdered true bs index 81 ReadProcessCodeIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let notifyBrokerOfCredit = ReadOptionalFieldOrdered true bs index 208 ReadNotifyBrokerOfCreditIdx
    let allocHandlInst = ReadOptionalFieldOrdered true bs index 209 ReadAllocHandlInstIdx
    let allocText = ReadOptionalFieldOrdered true bs index 161 ReadAllocTextIdx
    let encodedAllocText = ReadOptionalFieldOrdered true bs index 360 ReadEncodedAllocTextIdx
    let commissionData = ReadComponentOrdered true bs index ReadCommissionDataIdxOrdered
    let allocAvgPx = ReadOptionalFieldOrdered true bs index 153 ReadAllocAvgPxIdx
    let allocNetMoney = ReadOptionalFieldOrdered true bs index 154 ReadAllocNetMoneyIdx
    let settlCurrAmt = ReadOptionalFieldOrdered true bs index 119 ReadSettlCurrAmtIdx
    let allocSettlCurrAmt = ReadOptionalFieldOrdered true bs index 737 ReadAllocSettlCurrAmtIdx
    let settlCurrency = ReadOptionalFieldOrdered true bs index 120 ReadSettlCurrencyIdx
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let settlCurrFxRate = ReadOptionalFieldOrdered true bs index 155 ReadSettlCurrFxRateIdx
    let settlCurrFxRateCalc = ReadOptionalFieldOrdered true bs index 156 ReadSettlCurrFxRateCalcIdx
    let accruedInterestAmt = ReadOptionalFieldOrdered true bs index 159 ReadAccruedInterestAmtIdx
    let allocAccruedInterestAmt = ReadOptionalFieldOrdered true bs index 742 ReadAllocAccruedInterestAmtIdx
    let allocInterestAtMaturity = ReadOptionalFieldOrdered true bs index 741 ReadAllocInterestAtMaturityIdx
    let settlInstMode = ReadOptionalFieldOrdered true bs index 160 ReadSettlInstModeIdx
    let noMiscFeesGrp = ReadOptionalGroupOrdered true bs index 136 ReadNoMiscFeesGrpIdx
    let noClearingInstructions = ReadOptionalFieldOrdered true bs index 576 ReadNoClearingInstructionsIdx
    let clearingInstruction = ReadOptionalFieldOrdered true bs index 577 ReadClearingInstructionIdx
    let clearingFeeIndicator = ReadOptionalFieldOrdered true bs index 635 ReadClearingFeeIndicatorIdx
    let allocSettlInstType = ReadOptionalFieldOrdered true bs index 780 ReadAllocSettlInstTypeIdx
    let settlInstructionsData = ReadComponentOrdered true bs index ReadSettlInstructionsDataIdxOrdered
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


// component, random access reader
let ReadSettlPartiesIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SettlParties =
    let noSettlPartyIDsGrp = ReadOptionalGroup bs index 781 ReadNoSettlPartyIDsGrpIdx
    let ci:SettlParties = {
        NoSettlPartyIDsGrp = noSettlPartyIDsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadSettlPartiesIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SettlParties =
    let noSettlPartyIDsGrp = ReadOptionalGroupOrdered true bs index 781 ReadNoSettlPartyIDsGrpIdx
    let ci:SettlParties = {
        NoSettlPartyIDsGrp = noSettlPartyIDsGrp
    }
    ci


// group
let ReadNoOrdersGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoOrdersGrp =
    let clOrdID = ReadFieldOrdered true bs index 11 ReadClOrdIDIdx
    let orderID = ReadOptionalFieldOrdered true bs index 37 ReadOrderIDIdx
    let secondaryOrderID = ReadOptionalFieldOrdered true bs index 198 ReadSecondaryOrderIDIdx
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let listID = ReadOptionalFieldOrdered true bs index 66 ReadListIDIdx
    let noNested2PartyIDsGrp = ReadOptionalGroupOrdered true bs index 756 ReadNoNested2PartyIDsGrpIdx
    let orderQty = ReadOptionalFieldOrdered true bs index 38 ReadOrderQtyIdx
    let orderAvgPx = ReadOptionalFieldOrdered true bs index 799 ReadOrderAvgPxIdx
    let orderBookingQty = ReadOptionalFieldOrdered true bs index 800 ReadOrderBookingQtyIdx
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
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentIdxOrdered
    let prevClosePx = ReadOptionalFieldOrdered true bs index 140 ReadPrevClosePxIdx
    let clOrdID = ReadOptionalFieldOrdered true bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let side = ReadOptionalFieldOrdered true bs index 54 ReadSideIdx
    let price = ReadFieldOrdered true bs index 44 ReadPriceIdx
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrencyIdx
    let text = ReadOptionalFieldOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedTextIdx
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
    let securityAltID = ReadFieldOrdered true bs index 455 ReadSecurityAltIDIdx
    let securityAltIDSource = ReadOptionalFieldOrdered true bs index 456 ReadSecurityAltIDSourceIdx
    let ci:NoSecurityAltIDGrp = {
        SecurityAltID = securityAltID
        SecurityAltIDSource = securityAltIDSource
    }
    ci


// group
let ReadNoEventsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoEventsGrp =
    let eventType = ReadFieldOrdered true bs index 865 ReadEventTypeIdx
    let eventDate = ReadOptionalFieldOrdered true bs index 866 ReadEventDateIdx
    let eventPx = ReadOptionalFieldOrdered true bs index 867 ReadEventPxIdx
    let eventText = ReadOptionalFieldOrdered true bs index 868 ReadEventTextIdx
    let ci:NoEventsGrp = {
        EventType = eventType
        EventDate = eventDate
        EventPx = eventPx
        EventText = eventText
    }
    ci


// component, random access reader
let ReadInstrumentIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Instrument =
    let symbol = ReadField bs index 55 ReadSymbolIdx
    let symbolSfx = ReadOptionalField bs index 65 ReadSymbolSfxIdx
    let securityID = ReadOptionalField bs index 48 ReadSecurityIDIdx
    let securityIDSource = ReadOptionalField bs index 22 ReadSecurityIDSourceIdx
    let noSecurityAltIDGrp = ReadOptionalGroup bs index 454 ReadNoSecurityAltIDGrpIdx
    let product = ReadOptionalField bs index 460 ReadProductIdx
    let cFICode = ReadOptionalField bs index 461 ReadCFICodeIdx
    let securityType = ReadOptionalField bs index 167 ReadSecurityTypeIdx
    let securitySubType = ReadOptionalField bs index 762 ReadSecuritySubTypeIdx
    let maturityMonthYear = ReadOptionalField bs index 200 ReadMaturityMonthYearIdx
    let maturityDate = ReadOptionalField bs index 541 ReadMaturityDateIdx
    let putOrCall = ReadOptionalField bs index 201 ReadPutOrCallIdx
    let couponPaymentDate = ReadOptionalField bs index 224 ReadCouponPaymentDateIdx
    let issueDate = ReadOptionalField bs index 225 ReadIssueDateIdx
    let repoCollateralSecurityType = ReadOptionalField bs index 239 ReadRepoCollateralSecurityTypeIdx
    let repurchaseTerm = ReadOptionalField bs index 226 ReadRepurchaseTermIdx
    let repurchaseRate = ReadOptionalField bs index 227 ReadRepurchaseRateIdx
    let factor = ReadOptionalField bs index 228 ReadFactorIdx
    let creditRating = ReadOptionalField bs index 255 ReadCreditRatingIdx
    let instrRegistry = ReadOptionalField bs index 543 ReadInstrRegistryIdx
    let countryOfIssue = ReadOptionalField bs index 470 ReadCountryOfIssueIdx
    let stateOrProvinceOfIssue = ReadOptionalField bs index 471 ReadStateOrProvinceOfIssueIdx
    let localeOfIssue = ReadOptionalField bs index 472 ReadLocaleOfIssueIdx
    let redemptionDate = ReadOptionalField bs index 240 ReadRedemptionDateIdx
    let strikePrice = ReadOptionalField bs index 202 ReadStrikePriceIdx
    let strikeCurrency = ReadOptionalField bs index 947 ReadStrikeCurrencyIdx
    let optAttribute = ReadOptionalField bs index 206 ReadOptAttributeIdx
    let contractMultiplier = ReadOptionalField bs index 231 ReadContractMultiplierIdx
    let couponRate = ReadOptionalField bs index 223 ReadCouponRateIdx
    let securityExchange = ReadOptionalField bs index 207 ReadSecurityExchangeIdx
    let issuer = ReadOptionalField bs index 106 ReadIssuerIdx
    let encodedIssuer = ReadOptionalField bs index 348 ReadEncodedIssuerIdx
    let securityDesc = ReadOptionalField bs index 107 ReadSecurityDescIdx
    let encodedSecurityDesc = ReadOptionalField bs index 350 ReadEncodedSecurityDescIdx
    let pool = ReadOptionalField bs index 691 ReadPoolIdx
    let contractSettlMonth = ReadOptionalField bs index 667 ReadContractSettlMonthIdx
    let cPProgram = ReadOptionalField bs index 875 ReadCPProgramIdx
    let cPRegType = ReadOptionalField bs index 876 ReadCPRegTypeIdx
    let noEventsGrp = ReadOptionalGroup bs index 864 ReadNoEventsGrpIdx
    let datedDate = ReadOptionalField bs index 873 ReadDatedDateIdx
    let interestAccrualDate = ReadOptionalField bs index 874 ReadInterestAccrualDateIdx
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


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadInstrumentIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Instrument =
    let symbol = ReadFieldOrdered true bs index 55 ReadSymbolIdx
    let symbolSfx = ReadOptionalFieldOrdered true bs index 65 ReadSymbolSfxIdx
    let securityID = ReadOptionalFieldOrdered true bs index 48 ReadSecurityIDIdx
    let securityIDSource = ReadOptionalFieldOrdered true bs index 22 ReadSecurityIDSourceIdx
    let noSecurityAltIDGrp = ReadOptionalGroupOrdered true bs index 454 ReadNoSecurityAltIDGrpIdx
    let product = ReadOptionalFieldOrdered true bs index 460 ReadProductIdx
    let cFICode = ReadOptionalFieldOrdered true bs index 461 ReadCFICodeIdx
    let securityType = ReadOptionalFieldOrdered true bs index 167 ReadSecurityTypeIdx
    let securitySubType = ReadOptionalFieldOrdered true bs index 762 ReadSecuritySubTypeIdx
    let maturityMonthYear = ReadOptionalFieldOrdered true bs index 200 ReadMaturityMonthYearIdx
    let maturityDate = ReadOptionalFieldOrdered true bs index 541 ReadMaturityDateIdx
    let putOrCall = ReadOptionalFieldOrdered true bs index 201 ReadPutOrCallIdx
    let couponPaymentDate = ReadOptionalFieldOrdered true bs index 224 ReadCouponPaymentDateIdx
    let issueDate = ReadOptionalFieldOrdered true bs index 225 ReadIssueDateIdx
    let repoCollateralSecurityType = ReadOptionalFieldOrdered true bs index 239 ReadRepoCollateralSecurityTypeIdx
    let repurchaseTerm = ReadOptionalFieldOrdered true bs index 226 ReadRepurchaseTermIdx
    let repurchaseRate = ReadOptionalFieldOrdered true bs index 227 ReadRepurchaseRateIdx
    let factor = ReadOptionalFieldOrdered true bs index 228 ReadFactorIdx
    let creditRating = ReadOptionalFieldOrdered true bs index 255 ReadCreditRatingIdx
    let instrRegistry = ReadOptionalFieldOrdered true bs index 543 ReadInstrRegistryIdx
    let countryOfIssue = ReadOptionalFieldOrdered true bs index 470 ReadCountryOfIssueIdx
    let stateOrProvinceOfIssue = ReadOptionalFieldOrdered true bs index 471 ReadStateOrProvinceOfIssueIdx
    let localeOfIssue = ReadOptionalFieldOrdered true bs index 472 ReadLocaleOfIssueIdx
    let redemptionDate = ReadOptionalFieldOrdered true bs index 240 ReadRedemptionDateIdx
    let strikePrice = ReadOptionalFieldOrdered true bs index 202 ReadStrikePriceIdx
    let strikeCurrency = ReadOptionalFieldOrdered true bs index 947 ReadStrikeCurrencyIdx
    let optAttribute = ReadOptionalFieldOrdered true bs index 206 ReadOptAttributeIdx
    let contractMultiplier = ReadOptionalFieldOrdered true bs index 231 ReadContractMultiplierIdx
    let couponRate = ReadOptionalFieldOrdered true bs index 223 ReadCouponRateIdx
    let securityExchange = ReadOptionalFieldOrdered true bs index 207 ReadSecurityExchangeIdx
    let issuer = ReadOptionalFieldOrdered true bs index 106 ReadIssuerIdx
    let encodedIssuer = ReadOptionalFieldOrdered true bs index 348 ReadEncodedIssuerIdx
    let securityDesc = ReadOptionalFieldOrdered true bs index 107 ReadSecurityDescIdx
    let encodedSecurityDesc = ReadOptionalFieldOrdered true bs index 350 ReadEncodedSecurityDescIdx
    let pool = ReadOptionalFieldOrdered true bs index 691 ReadPoolIdx
    let contractSettlMonth = ReadOptionalFieldOrdered true bs index 667 ReadContractSettlMonthIdx
    let cPProgram = ReadOptionalFieldOrdered true bs index 875 ReadCPProgramIdx
    let cPRegType = ReadOptionalFieldOrdered true bs index 876 ReadCPRegTypeIdx
    let noEventsGrp = ReadOptionalGroupOrdered true bs index 864 ReadNoEventsGrpIdx
    let datedDate = ReadOptionalFieldOrdered true bs index 873 ReadDatedDateIdx
    let interestAccrualDate = ReadOptionalFieldOrdered true bs index 874 ReadInterestAccrualDateIdx
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
    let instrument = ReadComponentOrdered true bs index ReadInstrumentIdxOrdered
    let ci:NoStrikesGrp = {
        Instrument = instrument
    }
    ci


// group
let ReadNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocIDIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let allocQty = ReadOptionalFieldOrdered true bs index 80 ReadAllocQtyIdx
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
    let tradingSessionID = ReadFieldOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let ci:NoTradingSessionsGrp = {
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
    }
    ci


// group
let ReadNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentIdxOrdered
    let ci:NoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
    }
    ci


// component, random access reader
let ReadOrderQtyDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : OrderQtyData =
    let orderQty = ReadOptionalField bs index 38 ReadOrderQtyIdx
    let cashOrderQty = ReadOptionalField bs index 152 ReadCashOrderQtyIdx
    let orderPercent = ReadOptionalField bs index 516 ReadOrderPercentIdx
    let roundingDirection = ReadOptionalField bs index 468 ReadRoundingDirectionIdx
    let roundingModulus = ReadOptionalField bs index 469 ReadRoundingModulusIdx
    let ci:OrderQtyData = {
        OrderQty = orderQty
        CashOrderQty = cashOrderQty
        OrderPercent = orderPercent
        RoundingDirection = roundingDirection
        RoundingModulus = roundingModulus
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadOrderQtyDataIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : OrderQtyData =
    let orderQty = ReadOptionalFieldOrdered true bs index 38 ReadOrderQtyIdx
    let cashOrderQty = ReadOptionalFieldOrdered true bs index 152 ReadCashOrderQtyIdx
    let orderPercent = ReadOptionalFieldOrdered true bs index 516 ReadOrderPercentIdx
    let roundingDirection = ReadOptionalFieldOrdered true bs index 468 ReadRoundingDirectionIdx
    let roundingModulus = ReadOptionalFieldOrdered true bs index 469 ReadRoundingModulusIdx
    let ci:OrderQtyData = {
        OrderQty = orderQty
        CashOrderQty = cashOrderQty
        OrderPercent = orderPercent
        RoundingDirection = roundingDirection
        RoundingModulus = roundingModulus
    }
    ci


// component, random access reader
let ReadSpreadOrBenchmarkCurveDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SpreadOrBenchmarkCurveData =
    let spread = ReadOptionalField bs index 218 ReadSpreadIdx
    let benchmarkCurveCurrency = ReadOptionalField bs index 220 ReadBenchmarkCurveCurrencyIdx
    let benchmarkCurveName = ReadOptionalField bs index 221 ReadBenchmarkCurveNameIdx
    let benchmarkCurvePoint = ReadOptionalField bs index 222 ReadBenchmarkCurvePointIdx
    let benchmarkPrice = ReadOptionalField bs index 662 ReadBenchmarkPriceIdx
    let benchmarkPriceType = ReadOptionalField bs index 663 ReadBenchmarkPriceTypeIdx
    let benchmarkSecurityID = ReadOptionalField bs index 699 ReadBenchmarkSecurityIDIdx
    let benchmarkSecurityIDSource = ReadOptionalField bs index 761 ReadBenchmarkSecurityIDSourceIdx
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


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadSpreadOrBenchmarkCurveDataIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SpreadOrBenchmarkCurveData =
    let spread = ReadOptionalFieldOrdered true bs index 218 ReadSpreadIdx
    let benchmarkCurveCurrency = ReadOptionalFieldOrdered true bs index 220 ReadBenchmarkCurveCurrencyIdx
    let benchmarkCurveName = ReadOptionalFieldOrdered true bs index 221 ReadBenchmarkCurveNameIdx
    let benchmarkCurvePoint = ReadOptionalFieldOrdered true bs index 222 ReadBenchmarkCurvePointIdx
    let benchmarkPrice = ReadOptionalFieldOrdered true bs index 662 ReadBenchmarkPriceIdx
    let benchmarkPriceType = ReadOptionalFieldOrdered true bs index 663 ReadBenchmarkPriceTypeIdx
    let benchmarkSecurityID = ReadOptionalFieldOrdered true bs index 699 ReadBenchmarkSecurityIDIdx
    let benchmarkSecurityIDSource = ReadOptionalFieldOrdered true bs index 761 ReadBenchmarkSecurityIDSourceIdx
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


// component, random access reader
let ReadYieldDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : YieldData =
    let yieldType = ReadOptionalField bs index 235 ReadYieldTypeIdx
    let yyield = ReadOptionalField bs index 236 ReadYieldIdx
    let yieldCalcDate = ReadOptionalField bs index 701 ReadYieldCalcDateIdx
    let yieldRedemptionDate = ReadOptionalField bs index 696 ReadYieldRedemptionDateIdx
    let yieldRedemptionPrice = ReadOptionalField bs index 697 ReadYieldRedemptionPriceIdx
    let yieldRedemptionPriceType = ReadOptionalField bs index 698 ReadYieldRedemptionPriceTypeIdx
    let ci:YieldData = {
        YieldType = yieldType
        Yield = yyield
        YieldCalcDate = yieldCalcDate
        YieldRedemptionDate = yieldRedemptionDate
        YieldRedemptionPrice = yieldRedemptionPrice
        YieldRedemptionPriceType = yieldRedemptionPriceType
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadYieldDataIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : YieldData =
    let yieldType = ReadOptionalFieldOrdered true bs index 235 ReadYieldTypeIdx
    let yyield = ReadOptionalFieldOrdered true bs index 236 ReadYieldIdx
    let yieldCalcDate = ReadOptionalFieldOrdered true bs index 701 ReadYieldCalcDateIdx
    let yieldRedemptionDate = ReadOptionalFieldOrdered true bs index 696 ReadYieldRedemptionDateIdx
    let yieldRedemptionPrice = ReadOptionalFieldOrdered true bs index 697 ReadYieldRedemptionPriceIdx
    let yieldRedemptionPriceType = ReadOptionalFieldOrdered true bs index 698 ReadYieldRedemptionPriceTypeIdx
    let ci:YieldData = {
        YieldType = yieldType
        Yield = yyield
        YieldCalcDate = yieldCalcDate
        YieldRedemptionDate = yieldRedemptionDate
        YieldRedemptionPrice = yieldRedemptionPrice
        YieldRedemptionPriceType = yieldRedemptionPriceType
    }
    ci


// component, random access reader
let ReadPegInstructionsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PegInstructions =
    let pegOffsetValue = ReadOptionalField bs index 211 ReadPegOffsetValueIdx
    let pegMoveType = ReadOptionalField bs index 835 ReadPegMoveTypeIdx
    let pegOffsetType = ReadOptionalField bs index 836 ReadPegOffsetTypeIdx
    let pegLimitType = ReadOptionalField bs index 837 ReadPegLimitTypeIdx
    let pegRoundDirection = ReadOptionalField bs index 838 ReadPegRoundDirectionIdx
    let pegScope = ReadOptionalField bs index 840 ReadPegScopeIdx
    let ci:PegInstructions = {
        PegOffsetValue = pegOffsetValue
        PegMoveType = pegMoveType
        PegOffsetType = pegOffsetType
        PegLimitType = pegLimitType
        PegRoundDirection = pegRoundDirection
        PegScope = pegScope
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadPegInstructionsIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PegInstructions =
    let pegOffsetValue = ReadOptionalFieldOrdered true bs index 211 ReadPegOffsetValueIdx
    let pegMoveType = ReadOptionalFieldOrdered true bs index 835 ReadPegMoveTypeIdx
    let pegOffsetType = ReadOptionalFieldOrdered true bs index 836 ReadPegOffsetTypeIdx
    let pegLimitType = ReadOptionalFieldOrdered true bs index 837 ReadPegLimitTypeIdx
    let pegRoundDirection = ReadOptionalFieldOrdered true bs index 838 ReadPegRoundDirectionIdx
    let pegScope = ReadOptionalFieldOrdered true bs index 840 ReadPegScopeIdx
    let ci:PegInstructions = {
        PegOffsetValue = pegOffsetValue
        PegMoveType = pegMoveType
        PegOffsetType = pegOffsetType
        PegLimitType = pegLimitType
        PegRoundDirection = pegRoundDirection
        PegScope = pegScope
    }
    ci


// component, random access reader
let ReadDiscretionInstructionsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : DiscretionInstructions =
    let discretionInst = ReadOptionalField bs index 388 ReadDiscretionInstIdx
    let discretionOffsetValue = ReadOptionalField bs index 389 ReadDiscretionOffsetValueIdx
    let discretionMoveType = ReadOptionalField bs index 841 ReadDiscretionMoveTypeIdx
    let discretionOffsetType = ReadOptionalField bs index 842 ReadDiscretionOffsetTypeIdx
    let discretionLimitType = ReadOptionalField bs index 843 ReadDiscretionLimitTypeIdx
    let discretionRoundDirection = ReadOptionalField bs index 844 ReadDiscretionRoundDirectionIdx
    let discretionScope = ReadOptionalField bs index 846 ReadDiscretionScopeIdx
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


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadDiscretionInstructionsIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : DiscretionInstructions =
    let discretionInst = ReadOptionalFieldOrdered true bs index 388 ReadDiscretionInstIdx
    let discretionOffsetValue = ReadOptionalFieldOrdered true bs index 389 ReadDiscretionOffsetValueIdx
    let discretionMoveType = ReadOptionalFieldOrdered true bs index 841 ReadDiscretionMoveTypeIdx
    let discretionOffsetType = ReadOptionalFieldOrdered true bs index 842 ReadDiscretionOffsetTypeIdx
    let discretionLimitType = ReadOptionalFieldOrdered true bs index 843 ReadDiscretionLimitTypeIdx
    let discretionRoundDirection = ReadOptionalFieldOrdered true bs index 844 ReadDiscretionRoundDirectionIdx
    let discretionScope = ReadOptionalFieldOrdered true bs index 846 ReadDiscretionScopeIdx
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
    let clOrdID = ReadFieldOrdered true bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let listSeqNo = ReadFieldOrdered true bs index 67 ReadListSeqNoIdx
    let clOrdLinkID = ReadOptionalFieldOrdered true bs index 583 ReadClOrdLinkIDIdx
    let settlInstMode = ReadOptionalFieldOrdered true bs index 160 ReadSettlInstModeIdx
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrpIdx
    let tradeOriginationDate = ReadOptionalFieldOrdered true bs index 229 ReadTradeOriginationDateIdx
    let tradeDate = ReadOptionalFieldOrdered true bs index 75 ReadTradeDateIdx
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldOrdered true bs index 581 ReadAccountTypeIdx
    let dayBookingInst = ReadOptionalFieldOrdered true bs index 589 ReadDayBookingInstIdx
    let bookingUnit = ReadOptionalFieldOrdered true bs index 590 ReadBookingUnitIdx
    let allocID = ReadOptionalFieldOrdered true bs index 70 ReadAllocIDIdx
    let preallocMethod = ReadOptionalFieldOrdered true bs index 591 ReadPreallocMethodIdx
    let noAllocsGrp = ReadOptionalGroupOrdered true bs index 78 ReadNoAllocsGrpIdx
    let settlType = ReadOptionalFieldOrdered true bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDateIdx
    let cashMargin = ReadOptionalFieldOrdered true bs index 544 ReadCashMarginIdx
    let clearingFeeIndicator = ReadOptionalFieldOrdered true bs index 635 ReadClearingFeeIndicatorIdx
    let handlInst = ReadOptionalFieldOrdered true bs index 21 ReadHandlInstIdx
    let execInst = ReadOptionalFieldOrdered true bs index 18 ReadExecInstIdx
    let minQty = ReadOptionalFieldOrdered true bs index 110 ReadMinQtyIdx
    let maxFloor = ReadOptionalFieldOrdered true bs index 111 ReadMaxFloorIdx
    let exDestination = ReadOptionalFieldOrdered true bs index 100 ReadExDestinationIdx
    let noTradingSessionsGrp = ReadOptionalGroupOrdered true bs index 386 ReadNoTradingSessionsGrpIdx
    let processCode = ReadOptionalFieldOrdered true bs index 81 ReadProcessCodeIdx
    let instrument = ReadComponentOrdered true bs index ReadInstrumentIdxOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrpIdx
    let prevClosePx = ReadOptionalFieldOrdered true bs index 140 ReadPrevClosePxIdx
    let side = ReadFieldOrdered true bs index 54 ReadSideIdx
    let sideValueInd = ReadOptionalFieldOrdered true bs index 401 ReadSideValueIndIdx
    let locateReqd = ReadOptionalFieldOrdered true bs index 114 ReadLocateReqdIdx
    let transactTime = ReadOptionalFieldOrdered true bs index 60 ReadTransactTimeIdx
    let noStipulationsGrp = ReadOptionalGroupOrdered true bs index 232 ReadNoStipulationsGrpIdx
    let qtyType = ReadOptionalFieldOrdered true bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentOrdered true bs index ReadOrderQtyDataIdxOrdered
    let ordType = ReadOptionalFieldOrdered true bs index 40 ReadOrdTypeIdx
    let priceType = ReadOptionalFieldOrdered true bs index 423 ReadPriceTypeIdx
    let price = ReadOptionalFieldOrdered true bs index 44 ReadPriceIdx
    let stopPx = ReadOptionalFieldOrdered true bs index 99 ReadStopPxIdx
    let spreadOrBenchmarkCurveData = ReadComponentOrdered true bs index ReadSpreadOrBenchmarkCurveDataIdxOrdered
    let yieldData = ReadComponentOrdered true bs index ReadYieldDataIdxOrdered
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrencyIdx
    let complianceID = ReadOptionalFieldOrdered true bs index 376 ReadComplianceIDIdx
    let solicitedFlag = ReadOptionalFieldOrdered true bs index 377 ReadSolicitedFlagIdx
    let iOIid = ReadOptionalFieldOrdered true bs index 23 ReadIOIidIdx
    let quoteID = ReadOptionalFieldOrdered true bs index 117 ReadQuoteIDIdx
    let timeInForce = ReadOptionalFieldOrdered true bs index 59 ReadTimeInForceIdx
    let effectiveTime = ReadOptionalFieldOrdered true bs index 168 ReadEffectiveTimeIdx
    let expireDate = ReadOptionalFieldOrdered true bs index 432 ReadExpireDateIdx
    let expireTime = ReadOptionalFieldOrdered true bs index 126 ReadExpireTimeIdx
    let gTBookingInst = ReadOptionalFieldOrdered true bs index 427 ReadGTBookingInstIdx
    let commissionData = ReadComponentOrdered true bs index ReadCommissionDataIdxOrdered
    let orderCapacity = ReadOptionalFieldOrdered true bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldOrdered true bs index 529 ReadOrderRestrictionsIdx
    let custOrderCapacity = ReadOptionalFieldOrdered true bs index 582 ReadCustOrderCapacityIdx
    let forexReq = ReadOptionalFieldOrdered true bs index 121 ReadForexReqIdx
    let settlCurrency = ReadOptionalFieldOrdered true bs index 120 ReadSettlCurrencyIdx
    let bookingType = ReadOptionalFieldOrdered true bs index 775 ReadBookingTypeIdx
    let text = ReadOptionalFieldOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedTextIdx
    let settlDate2 = ReadOptionalFieldOrdered true bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldOrdered true bs index 192 ReadOrderQty2Idx
    let price2 = ReadOptionalFieldOrdered true bs index 640 ReadPrice2Idx
    let positionEffect = ReadOptionalFieldOrdered true bs index 77 ReadPositionEffectIdx
    let coveredOrUncovered = ReadOptionalFieldOrdered true bs index 203 ReadCoveredOrUncoveredIdx
    let maxShow = ReadOptionalFieldOrdered true bs index 210 ReadMaxShowIdx
    let pegInstructions = ReadComponentOrdered true bs index ReadPegInstructionsIdxOrdered
    let discretionInstructions = ReadComponentOrdered true bs index ReadDiscretionInstructionsIdxOrdered
    let targetStrategy = ReadOptionalFieldOrdered true bs index 847 ReadTargetStrategyIdx
    let targetStrategyParameters = ReadOptionalFieldOrdered true bs index 848 ReadTargetStrategyParametersIdx
    let participationRate = ReadOptionalFieldOrdered true bs index 849 ReadParticipationRateIdx
    let designation = ReadOptionalFieldOrdered true bs index 494 ReadDesignationIdx
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


// component, random access reader
let ReadCommissionDataFGIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CommissionDataFG =
    let commission = ReadField bs index 12 ReadCommissionIdx
    let commType = ReadOptionalField bs index 13 ReadCommTypeIdx
    let commCurrency = ReadOptionalField bs index 479 ReadCommCurrencyIdx
    let fundRenewWaiv = ReadOptionalField bs index 497 ReadFundRenewWaivIdx
    let ci:CommissionDataFG = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadCommissionDataFGIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CommissionDataFG =
    let commission = ReadFieldOrdered true bs index 12 ReadCommissionIdx
    let commType = ReadOptionalFieldOrdered true bs index 13 ReadCommTypeIdx
    let commCurrency = ReadOptionalFieldOrdered true bs index 479 ReadCommCurrencyIdx
    let fundRenewWaiv = ReadOptionalFieldOrdered true bs index 497 ReadFundRenewWaivIdx
    let ci:CommissionDataFG = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    ci


// group
let ReadBidResponseNoBidComponentsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : BidResponseNoBidComponentsGrp =
    let commissionDataFG = ReadComponentOrdered true bs index ReadCommissionDataFGIdxOrdered
    let listID = ReadOptionalFieldOrdered true bs index 66 ReadListIDIdx
    let country = ReadOptionalFieldOrdered true bs index 421 ReadCountryIdx
    let side = ReadOptionalFieldOrdered true bs index 54 ReadSideIdx
    let price = ReadOptionalFieldOrdered true bs index 44 ReadPriceIdx
    let priceType = ReadOptionalFieldOrdered true bs index 423 ReadPriceTypeIdx
    let fairValue = ReadOptionalFieldOrdered true bs index 406 ReadFairValueIdx
    let netGrossInd = ReadOptionalFieldOrdered true bs index 430 ReadNetGrossIndIdx
    let settlType = ReadOptionalFieldOrdered true bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDateIdx
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let text = ReadOptionalFieldOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedTextIdx
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
    let legAllocAccount = ReadFieldOrdered true bs index 671 ReadLegAllocAccountIdx
    let legIndividualAllocID = ReadOptionalFieldOrdered true bs index 672 ReadLegIndividualAllocIDIdx
    let noNested2PartyIDsGrp = ReadOptionalGroupOrdered true bs index 756 ReadNoNested2PartyIDsGrpIdx
    let legAllocQty = ReadOptionalFieldOrdered true bs index 673 ReadLegAllocQtyIdx
    let legAllocAcctIDSource = ReadOptionalFieldOrdered true bs index 674 ReadLegAllocAcctIDSourceIdx
    let legSettlCurrency = ReadOptionalFieldOrdered true bs index 675 ReadLegSettlCurrencyIdx
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
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGIdxOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrpIdx
    let noLegAllocsGrp = ReadOptionalGroupOrdered true bs index 670 ReadNoLegAllocsGrpIdx
    let legPositionEffect = ReadOptionalFieldOrdered true bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldOrdered true bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldOrdered true bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldOrdered true bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDateIdx
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
    let nested3PartySubID = ReadFieldOrdered true bs index 953 ReadNested3PartySubIDIdx
    let nested3PartySubIDType = ReadOptionalFieldOrdered true bs index 954 ReadNested3PartySubIDTypeIdx
    let ci:NoNested3PartySubIDsGrp = {
        Nested3PartySubID = nested3PartySubID
        Nested3PartySubIDType = nested3PartySubIDType
    }
    ci


// group
let ReadNoNested3PartyIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNested3PartyIDsGrp =
    let nested3PartyID = ReadFieldOrdered true bs index 949 ReadNested3PartyIDIdx
    let nested3PartyIDSource = ReadOptionalFieldOrdered true bs index 950 ReadNested3PartyIDSourceIdx
    let nested3PartyRole = ReadOptionalFieldOrdered true bs index 951 ReadNested3PartyRoleIdx
    let noNested3PartySubIDsGrp = ReadOptionalGroupOrdered true bs index 952 ReadNoNested3PartySubIDsGrpIdx
    let ci:NoNested3PartyIDsGrp = {
        Nested3PartyID = nested3PartyID
        Nested3PartyIDSource = nested3PartyIDSource
        Nested3PartyRole = nested3PartyRole
        NoNested3PartySubIDsGrp = noNested3PartySubIDsGrp
    }
    ci


// group
let ReadMultilegOrderCancelReplaceRequestNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MultilegOrderCancelReplaceRequestNoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocIDIdx
    let noNested3PartyIDsGrp = ReadOptionalGroupOrdered true bs index 948 ReadNoNested3PartyIDsGrpIdx
    let allocQty = ReadOptionalFieldOrdered true bs index 80 ReadAllocQtyIdx
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
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGIdxOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrpIdx
    let noLegAllocsGrp = ReadOptionalGroupOrdered true bs index 670 ReadNoLegAllocsGrpIdx
    let legPositionEffect = ReadOptionalFieldOrdered true bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldOrdered true bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldOrdered true bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldOrdered true bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDateIdx
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


// component, random access reader
let ReadNestedParties2Idx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties2 =
    let noNested2PartyIDsGrp = ReadOptionalGroup bs index 756 ReadNoNested2PartyIDsGrpIdx
    let ci:NestedParties2 = {
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadNestedParties2IdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties2 =
    let noNested2PartyIDsGrp = ReadOptionalGroupOrdered true bs index 756 ReadNoNested2PartyIDsGrpIdx
    let ci:NestedParties2 = {
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
    }
    ci


// group
let ReadNewOrderMultilegNoAllocsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NewOrderMultilegNoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrencyIdx
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocIDIdx
    let noNested3PartyIDsGrp = ReadOptionalGroupOrdered true bs index 948 ReadNoNested3PartyIDsGrpIdx
    let allocQty = ReadOptionalFieldOrdered true bs index 80 ReadAllocQtyIdx
    let ci:NewOrderMultilegNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNested3PartyIDsGrp = noNested3PartyIDsGrp
        AllocQty = allocQty
    }
    ci


// component, random access reader
let ReadNestedParties3Idx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties3 =
    let noNested3PartyIDsGrp = ReadOptionalGroup bs index 948 ReadNoNested3PartyIDsGrpIdx
    let ci:NestedParties3 = {
        NoNested3PartyIDsGrp = noNested3PartyIDsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadNestedParties3IdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties3 =
    let noNested3PartyIDsGrp = ReadOptionalGroupOrdered true bs index 948 ReadNoNested3PartyIDsGrpIdx
    let ci:NestedParties3 = {
        NoNested3PartyIDsGrp = noNested3PartyIDsGrp
    }
    ci


// group
let ReadCrossOrderCancelRequestNoSidesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CrossOrderCancelRequestNoSidesGrp =
    let side = ReadFieldOrdered true bs index 54 ReadSideIdx
    let origClOrdID = ReadFieldOrdered true bs index 41 ReadOrigClOrdIDIdx
    let clOrdID = ReadFieldOrdered true bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let clOrdLinkID = ReadOptionalFieldOrdered true bs index 583 ReadClOrdLinkIDIdx
    let origOrdModTime = ReadOptionalFieldOrdered true bs index 586 ReadOrigOrdModTimeIdx
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrpIdx
    let tradeOriginationDate = ReadOptionalFieldOrdered true bs index 229 ReadTradeOriginationDateIdx
    let tradeDate = ReadOptionalFieldOrdered true bs index 75 ReadTradeDateIdx
    let orderQtyData = ReadComponentOrdered true bs index ReadOrderQtyDataIdxOrdered
    let complianceID = ReadOptionalFieldOrdered true bs index 376 ReadComplianceIDIdx
    let text = ReadOptionalFieldOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedTextIdx
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
    let side = ReadFieldOrdered true bs index 54 ReadSideIdx
    let origClOrdID = ReadFieldOrdered true bs index 41 ReadOrigClOrdIDIdx
    let clOrdID = ReadFieldOrdered true bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let clOrdLinkID = ReadOptionalFieldOrdered true bs index 583 ReadClOrdLinkIDIdx
    let origOrdModTime = ReadOptionalFieldOrdered true bs index 586 ReadOrigOrdModTimeIdx
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrpIdx
    let tradeOriginationDate = ReadOptionalFieldOrdered true bs index 229 ReadTradeOriginationDateIdx
    let tradeDate = ReadOptionalFieldOrdered true bs index 75 ReadTradeDateIdx
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldOrdered true bs index 581 ReadAccountTypeIdx
    let dayBookingInst = ReadOptionalFieldOrdered true bs index 589 ReadDayBookingInstIdx
    let bookingUnit = ReadOptionalFieldOrdered true bs index 590 ReadBookingUnitIdx
    let preallocMethod = ReadOptionalFieldOrdered true bs index 591 ReadPreallocMethodIdx
    let allocID = ReadOptionalFieldOrdered true bs index 70 ReadAllocIDIdx
    let noAllocsGrp = ReadOptionalGroupOrdered true bs index 78 ReadNoAllocsGrpIdx
    let qtyType = ReadOptionalFieldOrdered true bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentOrdered true bs index ReadOrderQtyDataIdxOrdered
    let commissionData = ReadComponentOrdered true bs index ReadCommissionDataIdxOrdered
    let orderCapacity = ReadOptionalFieldOrdered true bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldOrdered true bs index 529 ReadOrderRestrictionsIdx
    let custOrderCapacity = ReadOptionalFieldOrdered true bs index 582 ReadCustOrderCapacityIdx
    let forexReq = ReadOptionalFieldOrdered true bs index 121 ReadForexReqIdx
    let settlCurrency = ReadOptionalFieldOrdered true bs index 120 ReadSettlCurrencyIdx
    let bookingType = ReadOptionalFieldOrdered true bs index 775 ReadBookingTypeIdx
    let text = ReadOptionalFieldOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedTextIdx
    let positionEffect = ReadOptionalFieldOrdered true bs index 77 ReadPositionEffectIdx
    let coveredOrUncovered = ReadOptionalFieldOrdered true bs index 203 ReadCoveredOrUncoveredIdx
    let cashMargin = ReadOptionalFieldOrdered true bs index 544 ReadCashMarginIdx
    let clearingFeeIndicator = ReadOptionalFieldOrdered true bs index 635 ReadClearingFeeIndicatorIdx
    let solicitedFlag = ReadOptionalFieldOrdered true bs index 377 ReadSolicitedFlagIdx
    let sideComplianceID = ReadOptionalFieldOrdered true bs index 659 ReadSideComplianceIDIdx
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
    let side = ReadFieldOrdered true bs index 54 ReadSideIdx
    let clOrdID = ReadFieldOrdered true bs index 11 ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let clOrdLinkID = ReadOptionalFieldOrdered true bs index 583 ReadClOrdLinkIDIdx
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrpIdx
    let tradeOriginationDate = ReadOptionalFieldOrdered true bs index 229 ReadTradeOriginationDateIdx
    let tradeDate = ReadOptionalFieldOrdered true bs index 75 ReadTradeDateIdx
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldOrdered true bs index 581 ReadAccountTypeIdx
    let dayBookingInst = ReadOptionalFieldOrdered true bs index 589 ReadDayBookingInstIdx
    let bookingUnit = ReadOptionalFieldOrdered true bs index 590 ReadBookingUnitIdx
    let preallocMethod = ReadOptionalFieldOrdered true bs index 591 ReadPreallocMethodIdx
    let allocID = ReadOptionalFieldOrdered true bs index 70 ReadAllocIDIdx
    let noAllocsGrp = ReadOptionalGroupOrdered true bs index 78 ReadNoAllocsGrpIdx
    let qtyType = ReadOptionalFieldOrdered true bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentOrdered true bs index ReadOrderQtyDataIdxOrdered
    let commissionData = ReadComponentOrdered true bs index ReadCommissionDataIdxOrdered
    let orderCapacity = ReadOptionalFieldOrdered true bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldOrdered true bs index 529 ReadOrderRestrictionsIdx
    let custOrderCapacity = ReadOptionalFieldOrdered true bs index 582 ReadCustOrderCapacityIdx
    let forexReq = ReadOptionalFieldOrdered true bs index 121 ReadForexReqIdx
    let settlCurrency = ReadOptionalFieldOrdered true bs index 120 ReadSettlCurrencyIdx
    let bookingType = ReadOptionalFieldOrdered true bs index 775 ReadBookingTypeIdx
    let text = ReadOptionalFieldOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedTextIdx
    let positionEffect = ReadOptionalFieldOrdered true bs index 77 ReadPositionEffectIdx
    let coveredOrUncovered = ReadOptionalFieldOrdered true bs index 203 ReadCoveredOrUncoveredIdx
    let cashMargin = ReadOptionalFieldOrdered true bs index 544 ReadCashMarginIdx
    let clearingFeeIndicator = ReadOptionalFieldOrdered true bs index 635 ReadClearingFeeIndicatorIdx
    let solicitedFlag = ReadOptionalFieldOrdered true bs index 377 ReadSolicitedFlagIdx
    let sideComplianceID = ReadOptionalFieldOrdered true bs index 659 ReadSideComplianceIDIdx
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
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGIdxOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapTypeIdx
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrpIdx
    let legPositionEffect = ReadOptionalFieldOrdered true bs index 564 ReadLegPositionEffectIdx
    let legCoveredOrUncovered = ReadOptionalFieldOrdered true bs index 565 ReadLegCoveredOrUncoveredIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legRefID = ReadOptionalFieldOrdered true bs index 654 ReadLegRefIDIdx
    let legPrice = ReadOptionalFieldOrdered true bs index 566 ReadLegPriceIdx
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDateIdx
    let legLastPx = ReadOptionalFieldOrdered true bs index 637 ReadLegLastPxIdx
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
    let instrAttribType = ReadFieldOrdered true bs index 871 ReadInstrAttribTypeIdx
    let instrAttribValue = ReadOptionalFieldOrdered true bs index 872 ReadInstrAttribValueIdx
    let ci:NoInstrAttribGrp = {
        InstrAttribType = instrAttribType
        InstrAttribValue = instrAttribValue
    }
    ci


// component, random access reader
let ReadInstrumentExtensionIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentExtension =
    let deliveryForm = ReadOptionalField bs index 668 ReadDeliveryFormIdx
    let pctAtRisk = ReadOptionalField bs index 869 ReadPctAtRiskIdx
    let noInstrAttribGrp = ReadOptionalGroup bs index 870 ReadNoInstrAttribGrpIdx
    let ci:InstrumentExtension = {
        DeliveryForm = deliveryForm
        PctAtRisk = pctAtRisk
        NoInstrAttribGrp = noInstrAttribGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadInstrumentExtensionIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentExtension =
    let deliveryForm = ReadOptionalFieldOrdered true bs index 668 ReadDeliveryFormIdx
    let pctAtRisk = ReadOptionalFieldOrdered true bs index 869 ReadPctAtRiskIdx
    let noInstrAttribGrp = ReadOptionalGroupOrdered true bs index 870 ReadNoInstrAttribGrpIdx
    let ci:InstrumentExtension = {
        DeliveryForm = deliveryForm
        PctAtRisk = pctAtRisk
        NoInstrAttribGrp = noInstrAttribGrp
    }
    ci


// group
let ReadNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGIdxOrdered
    let ci:NoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
    }
    ci


// group
let ReadDerivativeSecurityListNoRelatedSymGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : DerivativeSecurityListNoRelatedSymGrp =
    let instrument = ReadComponentOrdered true bs index ReadInstrumentIdxOrdered
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrencyIdx
    let expirationCycle = ReadOptionalFieldOrdered true bs index 827 ReadExpirationCycleIdx
    let instrumentExtension = ReadComponentOrdered true bs index ReadInstrumentExtensionIdxOrdered
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrpIdx
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let text = ReadOptionalFieldOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedTextIdx
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


// component, random access reader
let ReadFinancingDetailsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : FinancingDetails =
    let agreementDesc = ReadOptionalField bs index 913 ReadAgreementDescIdx
    let agreementID = ReadOptionalField bs index 914 ReadAgreementIDIdx
    let agreementDate = ReadOptionalField bs index 915 ReadAgreementDateIdx
    let agreementCurrency = ReadOptionalField bs index 918 ReadAgreementCurrencyIdx
    let terminationType = ReadOptionalField bs index 788 ReadTerminationTypeIdx
    let startDate = ReadOptionalField bs index 916 ReadStartDateIdx
    let endDate = ReadOptionalField bs index 917 ReadEndDateIdx
    let deliveryType = ReadOptionalField bs index 919 ReadDeliveryTypeIdx
    let marginRatio = ReadOptionalField bs index 898 ReadMarginRatioIdx
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


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadFinancingDetailsIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : FinancingDetails =
    let agreementDesc = ReadOptionalFieldOrdered true bs index 913 ReadAgreementDescIdx
    let agreementID = ReadOptionalFieldOrdered true bs index 914 ReadAgreementIDIdx
    let agreementDate = ReadOptionalFieldOrdered true bs index 915 ReadAgreementDateIdx
    let agreementCurrency = ReadOptionalFieldOrdered true bs index 918 ReadAgreementCurrencyIdx
    let terminationType = ReadOptionalFieldOrdered true bs index 788 ReadTerminationTypeIdx
    let startDate = ReadOptionalFieldOrdered true bs index 916 ReadStartDateIdx
    let endDate = ReadOptionalFieldOrdered true bs index 917 ReadEndDateIdx
    let deliveryType = ReadOptionalFieldOrdered true bs index 919 ReadDeliveryTypeIdx
    let marginRatio = ReadOptionalFieldOrdered true bs index 898 ReadMarginRatioIdx
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


// component, random access reader
let ReadLegBenchmarkCurveDataIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LegBenchmarkCurveData =
    let legBenchmarkCurveCurrency = ReadOptionalField bs index 676 ReadLegBenchmarkCurveCurrencyIdx
    let legBenchmarkCurveName = ReadOptionalField bs index 677 ReadLegBenchmarkCurveNameIdx
    let legBenchmarkCurvePoint = ReadOptionalField bs index 678 ReadLegBenchmarkCurvePointIdx
    let legBenchmarkPrice = ReadOptionalField bs index 679 ReadLegBenchmarkPriceIdx
    let legBenchmarkPriceType = ReadOptionalField bs index 680 ReadLegBenchmarkPriceTypeIdx
    let ci:LegBenchmarkCurveData = {
        LegBenchmarkCurveCurrency = legBenchmarkCurveCurrency
        LegBenchmarkCurveName = legBenchmarkCurveName
        LegBenchmarkCurvePoint = legBenchmarkCurvePoint
        LegBenchmarkPrice = legBenchmarkPrice
        LegBenchmarkPriceType = legBenchmarkPriceType
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadLegBenchmarkCurveDataIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LegBenchmarkCurveData =
    let legBenchmarkCurveCurrency = ReadOptionalFieldOrdered true bs index 676 ReadLegBenchmarkCurveCurrencyIdx
    let legBenchmarkCurveName = ReadOptionalFieldOrdered true bs index 677 ReadLegBenchmarkCurveNameIdx
    let legBenchmarkCurvePoint = ReadOptionalFieldOrdered true bs index 678 ReadLegBenchmarkCurvePointIdx
    let legBenchmarkPrice = ReadOptionalFieldOrdered true bs index 679 ReadLegBenchmarkPriceIdx
    let legBenchmarkPriceType = ReadOptionalFieldOrdered true bs index 680 ReadLegBenchmarkPriceTypeIdx
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
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGIdxOrdered
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlTypeIdx
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrpIdx
    let legBenchmarkCurveData = ReadComponentOrdered true bs index ReadLegBenchmarkCurveDataIdxOrdered
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
    let instrument = ReadComponentOrdered true bs index ReadInstrumentIdxOrdered
    let instrumentExtension = ReadComponentOrdered true bs index ReadInstrumentExtensionIdxOrdered
    let financingDetails = ReadComponentOrdered true bs index ReadFinancingDetailsIdxOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrpIdx
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrencyIdx
    let noStipulationsGrp = ReadOptionalGroupOrdered true bs index 232 ReadNoStipulationsGrpIdx
    let securityListNoLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadSecurityListNoLegsGrpIdx
    let spreadOrBenchmarkCurveData = ReadComponentOrdered true bs index ReadSpreadOrBenchmarkCurveDataIdxOrdered
    let yieldData = ReadComponentOrdered true bs index ReadYieldDataIdxOrdered
    let roundLot = ReadOptionalFieldOrdered true bs index 561 ReadRoundLotIdx
    let minTradeVol = ReadOptionalFieldOrdered true bs index 562 ReadMinTradeVolIdx
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let expirationCycle = ReadOptionalFieldOrdered true bs index 827 ReadExpirationCycleIdx
    let text = ReadOptionalFieldOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedTextIdx
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
    let mDUpdateAction = ReadFieldOrdered true bs index 279 ReadMDUpdateActionIdx
    let deleteReason = ReadOptionalFieldOrdered true bs index 285 ReadDeleteReasonIdx
    let mDEntryType = ReadOptionalFieldOrdered true bs index 269 ReadMDEntryTypeIdx
    let mDEntryID = ReadOptionalFieldOrdered true bs index 278 ReadMDEntryIDIdx
    let mDEntryRefID = ReadOptionalFieldOrdered true bs index 280 ReadMDEntryRefIDIdx
    let instrument = ReadOptionalComponentOrdered true bs index 55 ReadInstrumentIdxOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrpIdx
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrpIdx
    let financialStatus = ReadOptionalFieldOrdered true bs index 291 ReadFinancialStatusIdx
    let corporateAction = ReadOptionalFieldOrdered true bs index 292 ReadCorporateActionIdx
    let mDEntryPx = ReadOptionalFieldOrdered true bs index 270 ReadMDEntryPxIdx
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrencyIdx
    let mDEntrySize = ReadOptionalFieldOrdered true bs index 271 ReadMDEntrySizeIdx
    let mDEntryDate = ReadOptionalFieldOrdered true bs index 272 ReadMDEntryDateIdx
    let mDEntryTime = ReadOptionalFieldOrdered true bs index 273 ReadMDEntryTimeIdx
    let tickDirection = ReadOptionalFieldOrdered true bs index 274 ReadTickDirectionIdx
    let mDMkt = ReadOptionalFieldOrdered true bs index 275 ReadMDMktIdx
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let quoteCondition = ReadOptionalFieldOrdered true bs index 276 ReadQuoteConditionIdx
    let tradeCondition = ReadOptionalFieldOrdered true bs index 277 ReadTradeConditionIdx
    let mDEntryOriginator = ReadOptionalFieldOrdered true bs index 282 ReadMDEntryOriginatorIdx
    let locationID = ReadOptionalFieldOrdered true bs index 283 ReadLocationIDIdx
    let deskID = ReadOptionalFieldOrdered true bs index 284 ReadDeskIDIdx
    let openCloseSettlFlag = ReadOptionalFieldOrdered true bs index 286 ReadOpenCloseSettlFlagIdx
    let timeInForce = ReadOptionalFieldOrdered true bs index 59 ReadTimeInForceIdx
    let expireDate = ReadOptionalFieldOrdered true bs index 432 ReadExpireDateIdx
    let expireTime = ReadOptionalFieldOrdered true bs index 126 ReadExpireTimeIdx
    let minQty = ReadOptionalFieldOrdered true bs index 110 ReadMinQtyIdx
    let execInst = ReadOptionalFieldOrdered true bs index 18 ReadExecInstIdx
    let sellerDays = ReadOptionalFieldOrdered true bs index 287 ReadSellerDaysIdx
    let orderID = ReadOptionalFieldOrdered true bs index 37 ReadOrderIDIdx
    let quoteEntryID = ReadOptionalFieldOrdered true bs index 299 ReadQuoteEntryIDIdx
    let mDEntryBuyer = ReadOptionalFieldOrdered true bs index 288 ReadMDEntryBuyerIdx
    let mDEntrySeller = ReadOptionalFieldOrdered true bs index 289 ReadMDEntrySellerIdx
    let numberOfOrders = ReadOptionalFieldOrdered true bs index 346 ReadNumberOfOrdersIdx
    let mDEntryPositionNo = ReadOptionalFieldOrdered true bs index 290 ReadMDEntryPositionNoIdx
    let scope = ReadOptionalFieldOrdered true bs index 546 ReadScopeIdx
    let priceDelta = ReadOptionalFieldOrdered true bs index 811 ReadPriceDeltaIdx
    let netChgPrevDay = ReadOptionalFieldOrdered true bs index 451 ReadNetChgPrevDayIdx
    let text = ReadOptionalFieldOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedTextIdx
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
    let instrument = ReadComponentOrdered true bs index ReadInstrumentIdxOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrpIdx
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrpIdx
    let ci:MarketDataRequestNoRelatedSymGrp = {
        Instrument = instrument
        NoUnderlyingsGrp = noUnderlyingsGrp
        NoLegsGrp = noLegsGrp
    }
    ci


// group
let ReadMassQuoteAcknowledgementNoQuoteEntriesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MassQuoteAcknowledgementNoQuoteEntriesGrp =
    let quoteEntryID = ReadFieldOrdered true bs index 299 ReadQuoteEntryIDIdx
    let instrument = ReadOptionalComponentOrdered true bs index 55 ReadInstrumentIdxOrdered
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrpIdx
    let bidPx = ReadOptionalFieldOrdered true bs index 132 ReadBidPxIdx
    let offerPx = ReadOptionalFieldOrdered true bs index 133 ReadOfferPxIdx
    let bidSize = ReadOptionalFieldOrdered true bs index 134 ReadBidSizeIdx
    let offerSize = ReadOptionalFieldOrdered true bs index 135 ReadOfferSizeIdx
    let validUntilTime = ReadOptionalFieldOrdered true bs index 62 ReadValidUntilTimeIdx
    let bidSpotRate = ReadOptionalFieldOrdered true bs index 188 ReadBidSpotRateIdx
    let offerSpotRate = ReadOptionalFieldOrdered true bs index 190 ReadOfferSpotRateIdx
    let bidForwardPoints = ReadOptionalFieldOrdered true bs index 189 ReadBidForwardPointsIdx
    let offerForwardPoints = ReadOptionalFieldOrdered true bs index 191 ReadOfferForwardPointsIdx
    let midPx = ReadOptionalFieldOrdered true bs index 631 ReadMidPxIdx
    let bidYield = ReadOptionalFieldOrdered true bs index 632 ReadBidYieldIdx
    let midYield = ReadOptionalFieldOrdered true bs index 633 ReadMidYieldIdx
    let offerYield = ReadOptionalFieldOrdered true bs index 634 ReadOfferYieldIdx
    let transactTime = ReadOptionalFieldOrdered true bs index 60 ReadTransactTimeIdx
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDateIdx
    let ordType = ReadOptionalFieldOrdered true bs index 40 ReadOrdTypeIdx
    let settlDate2 = ReadOptionalFieldOrdered true bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldOrdered true bs index 192 ReadOrderQty2Idx
    let bidForwardPoints2 = ReadOptionalFieldOrdered true bs index 642 ReadBidForwardPoints2Idx
    let offerForwardPoints2 = ReadOptionalFieldOrdered true bs index 643 ReadOfferForwardPoints2Idx
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrencyIdx
    let quoteEntryRejectReason = ReadOptionalFieldOrdered true bs index 368 ReadQuoteEntryRejectReasonIdx
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
    let quoteSetID = ReadFieldOrdered true bs index 302 ReadQuoteSetIDIdx
    let underlyingInstrument = ReadOptionalComponentOrdered true bs index 311 ReadUnderlyingInstrumentIdxOrdered
    let totNoQuoteEntries = ReadOptionalFieldOrdered true bs index 304 ReadTotNoQuoteEntriesIdx
    let lastFragment = ReadOptionalFieldOrdered true bs index 893 ReadLastFragmentIdx
    let massQuoteAcknowledgementNoQuoteEntriesGrp = ReadOptionalGroupOrdered true bs index 295 ReadMassQuoteAcknowledgementNoQuoteEntriesGrpIdx
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
    let quoteEntryID = ReadFieldOrdered true bs index 299 ReadQuoteEntryIDIdx
    let instrument = ReadOptionalComponentOrdered true bs index 55 ReadInstrumentIdxOrdered
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrpIdx
    let bidPx = ReadOptionalFieldOrdered true bs index 132 ReadBidPxIdx
    let offerPx = ReadOptionalFieldOrdered true bs index 133 ReadOfferPxIdx
    let bidSize = ReadOptionalFieldOrdered true bs index 134 ReadBidSizeIdx
    let offerSize = ReadOptionalFieldOrdered true bs index 135 ReadOfferSizeIdx
    let validUntilTime = ReadOptionalFieldOrdered true bs index 62 ReadValidUntilTimeIdx
    let bidSpotRate = ReadOptionalFieldOrdered true bs index 188 ReadBidSpotRateIdx
    let offerSpotRate = ReadOptionalFieldOrdered true bs index 190 ReadOfferSpotRateIdx
    let bidForwardPoints = ReadOptionalFieldOrdered true bs index 189 ReadBidForwardPointsIdx
    let offerForwardPoints = ReadOptionalFieldOrdered true bs index 191 ReadOfferForwardPointsIdx
    let midPx = ReadOptionalFieldOrdered true bs index 631 ReadMidPxIdx
    let bidYield = ReadOptionalFieldOrdered true bs index 632 ReadBidYieldIdx
    let midYield = ReadOptionalFieldOrdered true bs index 633 ReadMidYieldIdx
    let offerYield = ReadOptionalFieldOrdered true bs index 634 ReadOfferYieldIdx
    let transactTime = ReadOptionalFieldOrdered true bs index 60 ReadTransactTimeIdx
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDateIdx
    let ordType = ReadOptionalFieldOrdered true bs index 40 ReadOrdTypeIdx
    let settlDate2 = ReadOptionalFieldOrdered true bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldOrdered true bs index 192 ReadOrderQty2Idx
    let bidForwardPoints2 = ReadOptionalFieldOrdered true bs index 642 ReadBidForwardPoints2Idx
    let offerForwardPoints2 = ReadOptionalFieldOrdered true bs index 643 ReadOfferForwardPoints2Idx
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrencyIdx
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
    let quoteSetID = ReadFieldOrdered true bs index 302 ReadQuoteSetIDIdx
    let underlyingInstrument = ReadOptionalComponentOrdered true bs index 311 ReadUnderlyingInstrumentIdxOrdered
    let quoteSetValidUntilTime = ReadOptionalFieldOrdered true bs index 367 ReadQuoteSetValidUntilTimeIdx
    let totNoQuoteEntries = ReadFieldOrdered true bs index 304 ReadTotNoQuoteEntriesIdx
    let lastFragment = ReadOptionalFieldOrdered true bs index 893 ReadLastFragmentIdx
    let massQuoteNoQuoteEntriesGrp = ReadGroup bs index 295 ReadMassQuoteNoQuoteEntriesGrpIdx
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
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGIdxOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
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
    let instrument = ReadComponentOrdered true bs index ReadInstrumentIdxOrdered
    let financingDetails = ReadComponentOrdered true bs index ReadFinancingDetailsIdxOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrpIdx
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrpIdx
    let ci:NoQuoteEntriesGrp = {
        Instrument = instrument
        FinancingDetails = financingDetails
        NoUnderlyingsGrp = noUnderlyingsGrp
        NoLegsGrp = noLegsGrp
    }
    ci


// group
let ReadQuoteNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGIdxOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legPriceType = ReadOptionalFieldOrdered true bs index 686 ReadLegPriceTypeIdx
    let legBidPx = ReadOptionalFieldOrdered true bs index 681 ReadLegBidPxIdx
    let legOfferPx = ReadOptionalFieldOrdered true bs index 684 ReadLegOfferPxIdx
    let legBenchmarkCurveData = ReadComponentOrdered true bs index ReadLegBenchmarkCurveDataIdxOrdered
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
    let instrument = ReadComponentOrdered true bs index ReadInstrumentIdxOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrpIdx
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrpIdx
    let prevClosePx = ReadOptionalFieldOrdered true bs index 140 ReadPrevClosePxIdx
    let quoteRequestType = ReadOptionalFieldOrdered true bs index 303 ReadQuoteRequestTypeIdx
    let quoteType = ReadOptionalFieldOrdered true bs index 537 ReadQuoteTypeIdx
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubIDIdx
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
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGIdxOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legBenchmarkCurveData = ReadComponentOrdered true bs index ReadLegBenchmarkCurveDataIdxOrdered
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
    let instrument = ReadComponentOrdered true bs index ReadInstrumentIdxOrdered
    let financingDetails = ReadComponentOrdered true bs index ReadFinancingDetailsIdxOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrpIdx
    let prevClosePx = ReadOptionalFieldOrdered true bs index 140 ReadPrevClosePxIdx
    let quoteRequestType = ReadOptionalFieldOrdered true bs index 303 ReadQuoteRequestTypeIdx
    let quoteType = ReadOptionalFieldOrdered true bs index 537 ReadQuoteTypeIdx
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let tradeOriginationDate = ReadOptionalFieldOrdered true bs index 229 ReadTradeOriginationDateIdx
    let side = ReadOptionalFieldOrdered true bs index 54 ReadSideIdx
    let qtyType = ReadOptionalFieldOrdered true bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentOrdered true bs index ReadOrderQtyDataIdxOrdered
    let settlType = ReadOptionalFieldOrdered true bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDateIdx
    let settlDate2 = ReadOptionalFieldOrdered true bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldOrdered true bs index 192 ReadOrderQty2Idx
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrencyIdx
    let noStipulationsGrp = ReadOptionalGroupOrdered true bs index 232 ReadNoStipulationsGrpIdx
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldOrdered true bs index 581 ReadAccountTypeIdx
    let quoteRequestRejectNoLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadQuoteRequestRejectNoLegsGrpIdx
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
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGIdxOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legPriceType = ReadOptionalFieldOrdered true bs index 686 ReadLegPriceTypeIdx
    let legBidPx = ReadOptionalFieldOrdered true bs index 681 ReadLegBidPxIdx
    let legOfferPx = ReadOptionalFieldOrdered true bs index 684 ReadLegOfferPxIdx
    let legBenchmarkCurveData = ReadComponentOrdered true bs index ReadLegBenchmarkCurveDataIdxOrdered
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
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGIdxOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQtyIdx
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapTypeIdx
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlTypeIdx
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDateIdx
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrpIdx
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let legBenchmarkCurveData = ReadComponentOrdered true bs index ReadLegBenchmarkCurveDataIdxOrdered
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
    let quoteQualifier = ReadFieldOrdered true bs index 695 ReadQuoteQualifierIdx
    let ci:NoQuoteQualifiersGrp = {
        QuoteQualifier = quoteQualifier
    }
    ci


// group
let ReadQuoteRequestNoRelatedSymGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteRequestNoRelatedSymGrp =
    let instrument = ReadComponentOrdered true bs index ReadInstrumentIdxOrdered
    let financingDetails = ReadComponentOrdered true bs index ReadFinancingDetailsIdxOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrpIdx
    let prevClosePx = ReadOptionalFieldOrdered true bs index 140 ReadPrevClosePxIdx
    let quoteRequestType = ReadOptionalFieldOrdered true bs index 303 ReadQuoteRequestTypeIdx
    let quoteType = ReadOptionalFieldOrdered true bs index 537 ReadQuoteTypeIdx
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let tradeOriginationDate = ReadOptionalFieldOrdered true bs index 229 ReadTradeOriginationDateIdx
    let side = ReadOptionalFieldOrdered true bs index 54 ReadSideIdx
    let qtyType = ReadOptionalFieldOrdered true bs index 854 ReadQtyTypeIdx
    let orderQtyData = ReadComponentOrdered true bs index ReadOrderQtyDataIdxOrdered
    let settlType = ReadOptionalFieldOrdered true bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDateIdx
    let settlDate2 = ReadOptionalFieldOrdered true bs index 193 ReadSettlDate2Idx
    let orderQty2 = ReadOptionalFieldOrdered true bs index 192 ReadOrderQty2Idx
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrencyIdx
    let noStipulationsGrp = ReadOptionalGroupOrdered true bs index 232 ReadNoStipulationsGrpIdx
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSourceIdx
    let accountType = ReadOptionalFieldOrdered true bs index 581 ReadAccountTypeIdx
    let quoteRequestNoLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadQuoteRequestNoLegsGrpIdx
    let noQuoteQualifiersGrp = ReadOptionalGroupOrdered true bs index 735 ReadNoQuoteQualifiersGrpIdx
    let quotePriceType = ReadOptionalFieldOrdered true bs index 692 ReadQuotePriceTypeIdx
    let ordType = ReadOptionalFieldOrdered true bs index 40 ReadOrdTypeIdx
    let validUntilTime = ReadOptionalFieldOrdered true bs index 62 ReadValidUntilTimeIdx
    let expireTime = ReadOptionalFieldOrdered true bs index 126 ReadExpireTimeIdx
    let transactTime = ReadOptionalFieldOrdered true bs index 60 ReadTransactTimeIdx
    let spreadOrBenchmarkCurveData = ReadComponentOrdered true bs index ReadSpreadOrBenchmarkCurveDataIdxOrdered
    let priceType = ReadOptionalFieldOrdered true bs index 423 ReadPriceTypeIdx
    let price = ReadOptionalFieldOrdered true bs index 44 ReadPriceIdx
    let price2 = ReadOptionalFieldOrdered true bs index 640 ReadPrice2Idx
    let yieldData = ReadComponentOrdered true bs index ReadYieldDataIdxOrdered
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrpIdx
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


// component, random access reader
let ReadPartiesIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Parties =
    let noPartyIDsGrp = ReadOptionalGroup bs index 453 ReadNoPartyIDsGrpIdx
    let ci:Parties = {
        NoPartyIDsGrp = noPartyIDsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadPartiesIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Parties =
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrpIdx
    let ci:Parties = {
        NoPartyIDsGrp = noPartyIDsGrp
    }
    ci


// component, random access reader
let ReadNestedPartiesIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties =
    let noNestedPartyIDsGrp = ReadOptionalGroup bs index 539 ReadNoNestedPartyIDsGrpIdx
    let ci:NestedParties = {
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadNestedPartiesIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties =
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrpIdx
    let ci:NestedParties = {
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
    }
    ci


// group
let ReadNoRelatedSymGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoRelatedSymGrp =
    let instrument = ReadComponentOrdered true bs index ReadInstrumentIdxOrdered
    let ci:NoRelatedSymGrp = {
        Instrument = instrument
    }
    ci


// group
let ReadIndicationOfInterestNoLegsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : IndicationOfInterestNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGIdxOrdered
    let legIOIQty = ReadOptionalFieldOrdered true bs index 682 ReadLegIOIQtyIdx
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrpIdx
    let ci:IndicationOfInterestNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegIOIQty = legIOIQty
        NoLegStipulationsGrp = noLegStipulationsGrp
    }
    ci


// component, random access reader
let ReadLegStipulationsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LegStipulations =
    let noLegStipulationsGrp = ReadOptionalGroup bs index 683 ReadNoLegStipulationsGrpIdx
    let ci:LegStipulations = {
        NoLegStipulationsGrp = noLegStipulationsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadLegStipulationsIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LegStipulations =
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrpIdx
    let ci:LegStipulations = {
        NoLegStipulationsGrp = noLegStipulationsGrp
    }
    ci


// component, random access reader
let ReadStipulationsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Stipulations =
    let noStipulationsGrp = ReadOptionalGroup bs index 232 ReadNoStipulationsGrpIdx
    let ci:Stipulations = {
        NoStipulationsGrp = noStipulationsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadStipulationsIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Stipulations =
    let noStipulationsGrp = ReadOptionalGroupOrdered true bs index 232 ReadNoStipulationsGrpIdx
    let ci:Stipulations = {
        NoStipulationsGrp = noStipulationsGrp
    }
    ci


// group
let ReadAdvertisementNoUnderlyingsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AdvertisementNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentIdxOrdered
    let ci:AdvertisementNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
    }
    ci


// component, random access reader
let ReadUnderlyingStipulationsIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : UnderlyingStipulations =
    let noUnderlyingStipsGrp = ReadOptionalGroup bs index 887 ReadNoUnderlyingStipsGrpIdx
    let ci:UnderlyingStipulations = {
        NoUnderlyingStipsGrp = noUnderlyingStipsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadUnderlyingStipulationsIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : UnderlyingStipulations =
    let noUnderlyingStipsGrp = ReadOptionalGroupOrdered true bs index 887 ReadNoUnderlyingStipsGrpIdx
    let ci:UnderlyingStipulations = {
        NoUnderlyingStipsGrp = noUnderlyingStipsGrp
    }
    ci


// component, random access reader
let ReadInstrumentLegIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentLeg =
    let legSymbol = ReadOptionalField bs index 600 ReadLegSymbolIdx
    let legSymbolSfx = ReadOptionalField bs index 601 ReadLegSymbolSfxIdx
    let legSecurityID = ReadOptionalField bs index 602 ReadLegSecurityIDIdx
    let legSecurityIDSource = ReadOptionalField bs index 603 ReadLegSecurityIDSourceIdx
    let noLegSecurityAltIDGrp = ReadOptionalGroup bs index 604 ReadNoLegSecurityAltIDGrpIdx
    let legProduct = ReadOptionalField bs index 607 ReadLegProductIdx
    let legCFICode = ReadOptionalField bs index 608 ReadLegCFICodeIdx
    let legSecurityType = ReadOptionalField bs index 609 ReadLegSecurityTypeIdx
    let legSecuritySubType = ReadOptionalField bs index 764 ReadLegSecuritySubTypeIdx
    let legMaturityMonthYear = ReadOptionalField bs index 610 ReadLegMaturityMonthYearIdx
    let legMaturityDate = ReadOptionalField bs index 611 ReadLegMaturityDateIdx
    let legCouponPaymentDate = ReadOptionalField bs index 248 ReadLegCouponPaymentDateIdx
    let legIssueDate = ReadOptionalField bs index 249 ReadLegIssueDateIdx
    let legRepoCollateralSecurityType = ReadOptionalField bs index 250 ReadLegRepoCollateralSecurityTypeIdx
    let legRepurchaseTerm = ReadOptionalField bs index 251 ReadLegRepurchaseTermIdx
    let legRepurchaseRate = ReadOptionalField bs index 252 ReadLegRepurchaseRateIdx
    let legFactor = ReadOptionalField bs index 253 ReadLegFactorIdx
    let legCreditRating = ReadOptionalField bs index 257 ReadLegCreditRatingIdx
    let legInstrRegistry = ReadOptionalField bs index 599 ReadLegInstrRegistryIdx
    let legCountryOfIssue = ReadOptionalField bs index 596 ReadLegCountryOfIssueIdx
    let legStateOrProvinceOfIssue = ReadOptionalField bs index 597 ReadLegStateOrProvinceOfIssueIdx
    let legLocaleOfIssue = ReadOptionalField bs index 598 ReadLegLocaleOfIssueIdx
    let legRedemptionDate = ReadOptionalField bs index 254 ReadLegRedemptionDateIdx
    let legStrikePrice = ReadOptionalField bs index 612 ReadLegStrikePriceIdx
    let legStrikeCurrency = ReadOptionalField bs index 942 ReadLegStrikeCurrencyIdx
    let legOptAttribute = ReadOptionalField bs index 613 ReadLegOptAttributeIdx
    let legContractMultiplier = ReadOptionalField bs index 614 ReadLegContractMultiplierIdx
    let legCouponRate = ReadOptionalField bs index 615 ReadLegCouponRateIdx
    let legSecurityExchange = ReadOptionalField bs index 616 ReadLegSecurityExchangeIdx
    let legIssuer = ReadOptionalField bs index 617 ReadLegIssuerIdx
    let encodedLegIssuer = ReadOptionalField bs index 618 ReadEncodedLegIssuerIdx
    let legSecurityDesc = ReadOptionalField bs index 620 ReadLegSecurityDescIdx
    let encodedLegSecurityDesc = ReadOptionalField bs index 621 ReadEncodedLegSecurityDescIdx
    let legRatioQty = ReadOptionalField bs index 623 ReadLegRatioQtyIdx
    let legSide = ReadOptionalField bs index 624 ReadLegSideIdx
    let legCurrency = ReadOptionalField bs index 556 ReadLegCurrencyIdx
    let legPool = ReadOptionalField bs index 740 ReadLegPoolIdx
    let legDatedDate = ReadOptionalField bs index 739 ReadLegDatedDateIdx
    let legContractSettlMonth = ReadOptionalField bs index 955 ReadLegContractSettlMonthIdx
    let legInterestAccrualDate = ReadOptionalField bs index 956 ReadLegInterestAccrualDateIdx
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


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadInstrumentLegIdxOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentLeg =
    let legSymbol = ReadOptionalFieldOrdered true bs index 600 ReadLegSymbolIdx
    let legSymbolSfx = ReadOptionalFieldOrdered true bs index 601 ReadLegSymbolSfxIdx
    let legSecurityID = ReadOptionalFieldOrdered true bs index 602 ReadLegSecurityIDIdx
    let legSecurityIDSource = ReadOptionalFieldOrdered true bs index 603 ReadLegSecurityIDSourceIdx
    let noLegSecurityAltIDGrp = ReadOptionalGroupOrdered true bs index 604 ReadNoLegSecurityAltIDGrpIdx
    let legProduct = ReadOptionalFieldOrdered true bs index 607 ReadLegProductIdx
    let legCFICode = ReadOptionalFieldOrdered true bs index 608 ReadLegCFICodeIdx
    let legSecurityType = ReadOptionalFieldOrdered true bs index 609 ReadLegSecurityTypeIdx
    let legSecuritySubType = ReadOptionalFieldOrdered true bs index 764 ReadLegSecuritySubTypeIdx
    let legMaturityMonthYear = ReadOptionalFieldOrdered true bs index 610 ReadLegMaturityMonthYearIdx
    let legMaturityDate = ReadOptionalFieldOrdered true bs index 611 ReadLegMaturityDateIdx
    let legCouponPaymentDate = ReadOptionalFieldOrdered true bs index 248 ReadLegCouponPaymentDateIdx
    let legIssueDate = ReadOptionalFieldOrdered true bs index 249 ReadLegIssueDateIdx
    let legRepoCollateralSecurityType = ReadOptionalFieldOrdered true bs index 250 ReadLegRepoCollateralSecurityTypeIdx
    let legRepurchaseTerm = ReadOptionalFieldOrdered true bs index 251 ReadLegRepurchaseTermIdx
    let legRepurchaseRate = ReadOptionalFieldOrdered true bs index 252 ReadLegRepurchaseRateIdx
    let legFactor = ReadOptionalFieldOrdered true bs index 253 ReadLegFactorIdx
    let legCreditRating = ReadOptionalFieldOrdered true bs index 257 ReadLegCreditRatingIdx
    let legInstrRegistry = ReadOptionalFieldOrdered true bs index 599 ReadLegInstrRegistryIdx
    let legCountryOfIssue = ReadOptionalFieldOrdered true bs index 596 ReadLegCountryOfIssueIdx
    let legStateOrProvinceOfIssue = ReadOptionalFieldOrdered true bs index 597 ReadLegStateOrProvinceOfIssueIdx
    let legLocaleOfIssue = ReadOptionalFieldOrdered true bs index 598 ReadLegLocaleOfIssueIdx
    let legRedemptionDate = ReadOptionalFieldOrdered true bs index 254 ReadLegRedemptionDateIdx
    let legStrikePrice = ReadOptionalFieldOrdered true bs index 612 ReadLegStrikePriceIdx
    let legStrikeCurrency = ReadOptionalFieldOrdered true bs index 942 ReadLegStrikeCurrencyIdx
    let legOptAttribute = ReadOptionalFieldOrdered true bs index 613 ReadLegOptAttributeIdx
    let legContractMultiplier = ReadOptionalFieldOrdered true bs index 614 ReadLegContractMultiplierIdx
    let legCouponRate = ReadOptionalFieldOrdered true bs index 615 ReadLegCouponRateIdx
    let legSecurityExchange = ReadOptionalFieldOrdered true bs index 616 ReadLegSecurityExchangeIdx
    let legIssuer = ReadOptionalFieldOrdered true bs index 617 ReadLegIssuerIdx
    let encodedLegIssuer = ReadOptionalFieldOrdered true bs index 618 ReadEncodedLegIssuerIdx
    let legSecurityDesc = ReadOptionalFieldOrdered true bs index 620 ReadLegSecurityDescIdx
    let encodedLegSecurityDesc = ReadOptionalFieldOrdered true bs index 621 ReadEncodedLegSecurityDescIdx
    let legRatioQty = ReadOptionalFieldOrdered true bs index 623 ReadLegRatioQtyIdx
    let legSide = ReadOptionalFieldOrdered true bs index 624 ReadLegSideIdx
    let legCurrency = ReadOptionalFieldOrdered true bs index 556 ReadLegCurrencyIdx
    let legPool = ReadOptionalFieldOrdered true bs index 740 ReadLegPoolIdx
    let legDatedDate = ReadOptionalFieldOrdered true bs index 739 ReadLegDatedDateIdx
    let legContractSettlMonth = ReadOptionalFieldOrdered true bs index 955 ReadLegContractSettlMonthIdx
    let legInterestAccrualDate = ReadOptionalFieldOrdered true bs index 956 ReadLegInterestAccrualDateIdx
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
    let refMsgType = ReadFieldOrdered true bs index 372 ReadRefMsgTypeIdx
    let msgDirection = ReadOptionalFieldOrdered true bs index 385 ReadMsgDirectionIdx
    let ci:NoMsgTypesGrp = {
        RefMsgType = refMsgType
        MsgDirection = msgDirection
    }
    ci


// group
let ReadNoIOIQualifiersGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoIOIQualifiersGrp =
    let iOIQualifier = ReadFieldOrdered true bs index 104 ReadIOIQualifierIdx
    let ci:NoIOIQualifiersGrp = {
        IOIQualifier = iOIQualifier
    }
    ci


// group
let ReadNoRoutingIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoRoutingIDsGrp =
    let routingType = ReadFieldOrdered true bs index 216 ReadRoutingTypeIdx
    let routingID = ReadOptionalFieldOrdered true bs index 217 ReadRoutingIDIdx
    let ci:NoRoutingIDsGrp = {
        RoutingType = routingType
        RoutingID = routingID
    }
    ci


// group
let ReadLinesOfTextGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LinesOfTextGrp =
    let text = ReadFieldOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedTextIdx
    let ci:LinesOfTextGrp = {
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadNoMDEntryTypesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMDEntryTypesGrp =
    let mDEntryType = ReadFieldOrdered true bs index 269 ReadMDEntryTypeIdx
    let ci:NoMDEntryTypesGrp = {
        MDEntryType = mDEntryType
    }
    ci


// group
let ReadNoMDEntriesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMDEntriesGrp =
    let mDEntryType = ReadFieldOrdered true bs index 269 ReadMDEntryTypeIdx
    let mDEntryPx = ReadOptionalFieldOrdered true bs index 270 ReadMDEntryPxIdx
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrencyIdx
    let mDEntrySize = ReadOptionalFieldOrdered true bs index 271 ReadMDEntrySizeIdx
    let mDEntryDate = ReadOptionalFieldOrdered true bs index 272 ReadMDEntryDateIdx
    let mDEntryTime = ReadOptionalFieldOrdered true bs index 273 ReadMDEntryTimeIdx
    let tickDirection = ReadOptionalFieldOrdered true bs index 274 ReadTickDirectionIdx
    let mDMkt = ReadOptionalFieldOrdered true bs index 275 ReadMDMktIdx
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let quoteCondition = ReadOptionalFieldOrdered true bs index 276 ReadQuoteConditionIdx
    let tradeCondition = ReadOptionalFieldOrdered true bs index 277 ReadTradeConditionIdx
    let mDEntryOriginator = ReadOptionalFieldOrdered true bs index 282 ReadMDEntryOriginatorIdx
    let locationID = ReadOptionalFieldOrdered true bs index 283 ReadLocationIDIdx
    let deskID = ReadOptionalFieldOrdered true bs index 284 ReadDeskIDIdx
    let openCloseSettlFlag = ReadOptionalFieldOrdered true bs index 286 ReadOpenCloseSettlFlagIdx
    let timeInForce = ReadOptionalFieldOrdered true bs index 59 ReadTimeInForceIdx
    let expireDate = ReadOptionalFieldOrdered true bs index 432 ReadExpireDateIdx
    let expireTime = ReadOptionalFieldOrdered true bs index 126 ReadExpireTimeIdx
    let minQty = ReadOptionalFieldOrdered true bs index 110 ReadMinQtyIdx
    let execInst = ReadOptionalFieldOrdered true bs index 18 ReadExecInstIdx
    let sellerDays = ReadOptionalFieldOrdered true bs index 287 ReadSellerDaysIdx
    let orderID = ReadOptionalFieldOrdered true bs index 37 ReadOrderIDIdx
    let quoteEntryID = ReadOptionalFieldOrdered true bs index 299 ReadQuoteEntryIDIdx
    let mDEntryBuyer = ReadOptionalFieldOrdered true bs index 288 ReadMDEntryBuyerIdx
    let mDEntrySeller = ReadOptionalFieldOrdered true bs index 289 ReadMDEntrySellerIdx
    let numberOfOrders = ReadOptionalFieldOrdered true bs index 346 ReadNumberOfOrdersIdx
    let mDEntryPositionNo = ReadOptionalFieldOrdered true bs index 290 ReadMDEntryPositionNoIdx
    let scope = ReadOptionalFieldOrdered true bs index 546 ReadScopeIdx
    let priceDelta = ReadOptionalFieldOrdered true bs index 811 ReadPriceDeltaIdx
    let text = ReadOptionalFieldOrdered true bs index 58 ReadTextIdx
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedTextIdx
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
    let altMDSourceID = ReadFieldOrdered true bs index 817 ReadAltMDSourceIDIdx
    let ci:NoAltMDSourceGrp = {
        AltMDSourceID = altMDSourceID
    }
    ci


// group
let ReadNoSecurityTypesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSecurityTypesGrp =
    let securityType = ReadFieldOrdered true bs index 167 ReadSecurityTypeIdx
    let securitySubType = ReadOptionalFieldOrdered true bs index 762 ReadSecuritySubTypeIdx
    let product = ReadOptionalFieldOrdered true bs index 460 ReadProductIdx
    let cFICode = ReadOptionalFieldOrdered true bs index 461 ReadCFICodeIdx
    let ci:NoSecurityTypesGrp = {
        SecurityType = securityType
        SecuritySubType = securitySubType
        Product = product
        CFICode = cFICode
    }
    ci


// group
let ReadNoContraBrokersGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoContraBrokersGrp =
    let contraBroker = ReadFieldOrdered true bs index 375 ReadContraBrokerIdx
    let contraTrader = ReadOptionalFieldOrdered true bs index 337 ReadContraTraderIdx
    let contraTradeQty = ReadOptionalFieldOrdered true bs index 437 ReadContraTradeQtyIdx
    let contraTradeTime = ReadOptionalFieldOrdered true bs index 438 ReadContraTradeTimeIdx
    let contraLegRefID = ReadOptionalFieldOrdered true bs index 655 ReadContraLegRefIDIdx
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
    let origClOrdID = ReadFieldOrdered true bs index 41 ReadOrigClOrdIDIdx
    let affectedOrderID = ReadOptionalFieldOrdered true bs index 535 ReadAffectedOrderIDIdx
    let affectedSecondaryOrderID = ReadOptionalFieldOrdered true bs index 536 ReadAffectedSecondaryOrderIDIdx
    let ci:NoAffectedOrdersGrp = {
        OrigClOrdID = origClOrdID
        AffectedOrderID = affectedOrderID
        AffectedSecondaryOrderID = affectedSecondaryOrderID
    }
    ci


// group
let ReadNoBidDescriptorsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoBidDescriptorsGrp =
    let bidDescriptorType = ReadFieldOrdered true bs index 399 ReadBidDescriptorTypeIdx
    let bidDescriptor = ReadOptionalFieldOrdered true bs index 400 ReadBidDescriptorIdx
    let sideValueInd = ReadOptionalFieldOrdered true bs index 401 ReadSideValueIndIdx
    let liquidityValue = ReadOptionalFieldOrdered true bs index 404 ReadLiquidityValueIdx
    let liquidityNumSecurities = ReadOptionalFieldOrdered true bs index 441 ReadLiquidityNumSecuritiesIdx
    let liquidityPctLow = ReadOptionalFieldOrdered true bs index 402 ReadLiquidityPctLowIdx
    let liquidityPctHigh = ReadOptionalFieldOrdered true bs index 403 ReadLiquidityPctHighIdx
    let eFPTrackingError = ReadOptionalFieldOrdered true bs index 405 ReadEFPTrackingErrorIdx
    let fairValue = ReadOptionalFieldOrdered true bs index 406 ReadFairValueIdx
    let outsideIndexPct = ReadOptionalFieldOrdered true bs index 407 ReadOutsideIndexPctIdx
    let valueOfFutures = ReadOptionalFieldOrdered true bs index 408 ReadValueOfFuturesIdx
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
    let listID = ReadFieldOrdered true bs index 66 ReadListIDIdx
    let side = ReadOptionalFieldOrdered true bs index 54 ReadSideIdx
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionIDIdx
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubIDIdx
    let netGrossInd = ReadOptionalFieldOrdered true bs index 430 ReadNetGrossIndIdx
    let settlType = ReadOptionalFieldOrdered true bs index 63 ReadSettlTypeIdx
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDateIdx
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccountIdx
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSourceIdx
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
    let clOrdID          = ReadFieldOrdered         true bs index 11  ReadClOrdIDIdx
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdIDIdx
    let cumQty           = ReadFieldOrdered         true bs index 14  ReadCumQtyIdx
    let ordStatus        = ReadFieldOrdered         true bs index 39  ReadOrdStatusIdx
    let workingIndicator = ReadOptionalFieldOrdered true bs index 636 ReadWorkingIndicatorIdx
    let leavesQty        = ReadFieldOrdered         true bs index 151 ReadLeavesQtyIdx
    let cxlQty           = ReadFieldOrdered         true bs index 84  ReadCxlQtyIdx
    let avgPx            = ReadFieldOrdered         true bs index 6   ReadAvgPxIdx
    let ordRejReason     = ReadOptionalFieldOrdered true bs index 103 ReadOrdRejReasonIdx
    let text             = ReadOptionalFieldOrdered true bs index 58  ReadTextIdx
    let encodedText      = ReadOptionalFieldOrdered true bs index 354 ReadEncodedTextIdx
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
    let lastQty = ReadFieldOrdered true bs index 32 ReadLastQtyIdx
    let execID = ReadOptionalFieldOrdered true bs index 17 ReadExecIDIdx
    let secondaryExecID = ReadOptionalFieldOrdered true bs index 527 ReadSecondaryExecIDIdx
    let lastPx = ReadOptionalFieldOrdered true bs index 31 ReadLastPxIdx
    let lastParPx = ReadOptionalFieldOrdered true bs index 669 ReadLastParPxIdx
    let lastCapacity = ReadOptionalFieldOrdered true bs index 29 ReadLastCapacityIdx
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
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocPrice = ReadOptionalFieldOrdered true bs index 366 ReadAllocPriceIdx
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocIDIdx
    let individualAllocRejCode = ReadOptionalFieldOrdered true bs index 776 ReadIndividualAllocRejCodeIdx
    let allocText = ReadOptionalFieldOrdered true bs index 161 ReadAllocTextIdx
    let encodedAllocText = ReadOptionalFieldOrdered true bs index 360 ReadEncodedAllocTextIdx
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
    let lastQty = ReadFieldOrdered true bs index 32 ReadLastQtyIdx
    let execID = ReadOptionalFieldOrdered true bs index 17 ReadExecIDIdx
    let secondaryExecID = ReadOptionalFieldOrdered true bs index 527 ReadSecondaryExecIDIdx
    let lastPx = ReadOptionalFieldOrdered true bs index 31 ReadLastPxIdx
    let lastParPx = ReadOptionalFieldOrdered true bs index 669 ReadLastParPxIdx
    let lastCapacity = ReadOptionalFieldOrdered true bs index 29 ReadLastCapacityIdx
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
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccountIdx
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSourceIdx
    let allocPrice = ReadOptionalFieldOrdered true bs index 366 ReadAllocPriceIdx
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocIDIdx
    let individualAllocRejCode = ReadOptionalFieldOrdered true bs index 776 ReadIndividualAllocRejCodeIdx
    let allocText = ReadOptionalFieldOrdered true bs index 161 ReadAllocTextIdx
    let encodedAllocText = ReadOptionalFieldOrdered true bs index 360 ReadEncodedAllocTextIdx
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
    let orderCapacity = ReadFieldOrdered true bs index 528 ReadOrderCapacityIdx
    let orderRestrictions = ReadOptionalFieldOrdered true bs index 529 ReadOrderRestrictionsIdx
    let orderCapacityQty = ReadFieldOrdered true bs index 863 ReadOrderCapacityQtyIdx
    let ci:NoCapacitiesGrp = {
        OrderCapacity = orderCapacity
        OrderRestrictions = orderRestrictions
        OrderCapacityQty = orderCapacityQty
    }
    ci


// group
let ReadNoDatesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoDatesGrp =
    let tradeDate = ReadFieldOrdered true bs index 75 ReadTradeDateIdx
    let transactTime = ReadOptionalFieldOrdered true bs index 60 ReadTransactTimeIdx
    let ci:NoDatesGrp = {
        TradeDate = tradeDate
        TransactTime = transactTime
    }
    ci


// group
let ReadNoDistribInstsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoDistribInstsGrp =
    let distribPaymentMethod = ReadFieldOrdered true bs index 477 ReadDistribPaymentMethodIdx
    let distribPercentage = ReadOptionalFieldOrdered true bs index 512 ReadDistribPercentageIdx
    let cashDistribCurr = ReadOptionalFieldOrdered true bs index 478 ReadCashDistribCurrIdx
    let cashDistribAgentName = ReadOptionalFieldOrdered true bs index 498 ReadCashDistribAgentNameIdx
    let cashDistribAgentCode = ReadOptionalFieldOrdered true bs index 499 ReadCashDistribAgentCodeIdx
    let cashDistribAgentAcctNumber = ReadOptionalFieldOrdered true bs index 500 ReadCashDistribAgentAcctNumberIdx
    let cashDistribPayRef = ReadOptionalFieldOrdered true bs index 501 ReadCashDistribPayRefIdx
    let cashDistribAgentAcctName = ReadOptionalFieldOrdered true bs index 502 ReadCashDistribAgentAcctNameIdx
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
    let execID = ReadFieldOrdered true bs index 17 ReadExecIDIdx
    let ci:NoExecsGrp = {
        ExecID = execID
    }
    ci


// group
let ReadNoTradesGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoTradesGrp =
    let tradeReportID = ReadFieldOrdered true bs index 571 ReadTradeReportIDIdx
    let secondaryTradeReportID = ReadOptionalFieldOrdered true bs index 818 ReadSecondaryTradeReportIDIdx
    let ci:NoTradesGrp = {
        TradeReportID = tradeReportID
        SecondaryTradeReportID = secondaryTradeReportID
    }
    ci


// group
let ReadNoCollInquiryQualifierGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoCollInquiryQualifierGrp =
    let collInquiryQualifier = ReadFieldOrdered true bs index 896 ReadCollInquiryQualifierIdx
    let ci:NoCollInquiryQualifierGrp = {
        CollInquiryQualifier = collInquiryQualifier
    }
    ci


// group
let ReadNoCompIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoCompIDsGrp =
    let refCompID = ReadFieldOrdered true bs index 930 ReadRefCompIDIdx
    let refSubID = ReadOptionalFieldOrdered true bs index 931 ReadRefSubIDIdx
    let locationID = ReadOptionalFieldOrdered true bs index 283 ReadLocationIDIdx
    let deskID = ReadOptionalFieldOrdered true bs index 284 ReadDeskIDIdx
    let ci:NoCompIDsGrp = {
        RefCompID = refCompID
        RefSubID = refSubID
        LocationID = locationID
        DeskID = deskID
    }
    ci


// group
let ReadNetworkStatusResponseNoCompIDsGrpIdx (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NetworkStatusResponseNoCompIDsGrp =
    let refCompID = ReadFieldOrdered true bs index 930 ReadRefCompIDIdx
    let refSubID = ReadOptionalFieldOrdered true bs index 931 ReadRefSubIDIdx
    let locationID = ReadOptionalFieldOrdered true bs index 283 ReadLocationIDIdx
    let deskID = ReadOptionalFieldOrdered true bs index 284 ReadDeskIDIdx
    let statusValue = ReadOptionalFieldOrdered true bs index 928 ReadStatusValueIdx
    let statusText = ReadOptionalFieldOrdered true bs index 929 ReadStatusTextIdx
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
    let hopCompID = ReadFieldOrdered true bs index 628 ReadHopCompIDIdx
    let hopSendingTime = ReadOptionalFieldOrdered true bs index 629 ReadHopSendingTimeIdx
    let hopRefID = ReadOptionalFieldOrdered true bs index 630 ReadHopRefIDIdx
    let ci:NoHopsGrp = {
        HopCompID = hopCompID
        HopSendingTime = hopSendingTime
        HopRefID = hopRefID
    }
    ci


