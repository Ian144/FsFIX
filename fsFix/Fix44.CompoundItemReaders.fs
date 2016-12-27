module Fix44.CompoundItemReaders

open ReaderUtils
open Fix44.Fields
open Fix44.FieldReaders
open Fix44.CompoundItems


// group
let ReadNoUnderlyingSecurityAltIDGrp (bs:byte []) (pos:int) : int * NoUnderlyingSecurityAltIDGrp  =
    let pos, underlyingSecurityAltID = ReadField bs pos "ReadNoUnderlyingSecurityAltID" "458"B ReadUnderlyingSecurityAltID
    let pos, underlyingSecurityAltIDSource = ReadOptionalField bs pos "459"B  ReadUnderlyingSecurityAltIDSource
    let ci:NoUnderlyingSecurityAltIDGrp = {
        UnderlyingSecurityAltID = underlyingSecurityAltID
        UnderlyingSecurityAltIDSource = underlyingSecurityAltIDSource
    }
    pos, ci


// group
let ReadNoUnderlyingStipsGrp (bs:byte []) (pos:int) : int * NoUnderlyingStipsGrp  =
    let pos, underlyingStipType = ReadField bs pos "ReadNoUnderlyingStips" "888"B ReadUnderlyingStipType
    let pos, underlyingStipValue = ReadOptionalField bs pos "889"B  ReadUnderlyingStipValue
    let ci:NoUnderlyingStipsGrp = {
        UnderlyingStipType = underlyingStipType
        UnderlyingStipValue = underlyingStipValue
    }
    pos, ci


// component
let ReadUnderlyingInstrument (bs:byte []) (pos:int) : int * UnderlyingInstrument  =
    let pos, underlyingSymbol = ReadField bs pos "ReadUnderlyingInstrument" "311"B ReadUnderlyingSymbol
    let pos, underlyingSymbolSfx = ReadOptionalField bs pos "312"B  ReadUnderlyingSymbolSfx
    let pos, underlyingSecurityID = ReadOptionalField bs pos "309"B  ReadUnderlyingSecurityID
    let pos, underlyingSecurityIDSource = ReadOptionalField bs pos "305"B  ReadUnderlyingSecurityIDSource
    let pos, noUnderlyingSecurityAltIDGrp = ReadOptionalGroup bs pos "457"B ReadNoUnderlyingSecurityAltIDGrp
    let pos, underlyingProduct = ReadOptionalField bs pos "462"B  ReadUnderlyingProduct
    let pos, underlyingCFICode = ReadOptionalField bs pos "463"B  ReadUnderlyingCFICode
    let pos, underlyingSecurityType = ReadOptionalField bs pos "310"B  ReadUnderlyingSecurityType
    let pos, underlyingSecuritySubType = ReadOptionalField bs pos "763"B  ReadUnderlyingSecuritySubType
    let pos, underlyingMaturityMonthYear = ReadOptionalField bs pos "313"B  ReadUnderlyingMaturityMonthYear
    let pos, underlyingMaturityDate = ReadOptionalField bs pos "542"B  ReadUnderlyingMaturityDate
    let pos, underlyingPutOrCall = ReadOptionalField bs pos "315"B  ReadUnderlyingPutOrCall
    let pos, underlyingCouponPaymentDate = ReadOptionalField bs pos "241"B  ReadUnderlyingCouponPaymentDate
    let pos, underlyingIssueDate = ReadOptionalField bs pos "242"B  ReadUnderlyingIssueDate
    let pos, underlyingRepoCollateralSecurityType = ReadOptionalField bs pos "243"B  ReadUnderlyingRepoCollateralSecurityType
    let pos, underlyingRepurchaseTerm = ReadOptionalField bs pos "244"B  ReadUnderlyingRepurchaseTerm
    let pos, underlyingRepurchaseRate = ReadOptionalField bs pos "245"B  ReadUnderlyingRepurchaseRate
    let pos, underlyingFactor = ReadOptionalField bs pos "246"B  ReadUnderlyingFactor
    let pos, underlyingCreditRating = ReadOptionalField bs pos "256"B  ReadUnderlyingCreditRating
    let pos, underlyingInstrRegistry = ReadOptionalField bs pos "595"B  ReadUnderlyingInstrRegistry
    let pos, underlyingCountryOfIssue = ReadOptionalField bs pos "592"B  ReadUnderlyingCountryOfIssue
    let pos, underlyingStateOrProvinceOfIssue = ReadOptionalField bs pos "593"B  ReadUnderlyingStateOrProvinceOfIssue
    let pos, underlyingLocaleOfIssue = ReadOptionalField bs pos "594"B  ReadUnderlyingLocaleOfIssue
    let pos, underlyingRedemptionDate = ReadOptionalField bs pos "247"B  ReadUnderlyingRedemptionDate
    let pos, underlyingStrikePrice = ReadOptionalField bs pos "316"B  ReadUnderlyingStrikePrice
    let pos, underlyingStrikeCurrency = ReadOptionalField bs pos "941"B  ReadUnderlyingStrikeCurrency
    let pos, underlyingOptAttribute = ReadOptionalField bs pos "317"B  ReadUnderlyingOptAttribute
    let pos, underlyingContractMultiplier = ReadOptionalField bs pos "436"B  ReadUnderlyingContractMultiplier
    let pos, underlyingCouponRate = ReadOptionalField bs pos "435"B  ReadUnderlyingCouponRate
    let pos, underlyingSecurityExchange = ReadOptionalField bs pos "308"B  ReadUnderlyingSecurityExchange
    let pos, underlyingIssuer = ReadOptionalField bs pos "306"B  ReadUnderlyingIssuer
    let pos, encodedUnderlyingIssuer = ReadOptionalField bs pos "362"B  ReadEncodedUnderlyingIssuer
    let pos, underlyingSecurityDesc = ReadOptionalField bs pos "307"B  ReadUnderlyingSecurityDesc
    let pos, encodedUnderlyingSecurityDesc = ReadOptionalField bs pos "364"B  ReadEncodedUnderlyingSecurityDesc
    let pos, underlyingCPProgram = ReadOptionalField bs pos "877"B  ReadUnderlyingCPProgram
    let pos, underlyingCPRegType = ReadOptionalField bs pos "878"B  ReadUnderlyingCPRegType
    let pos, underlyingCurrency = ReadOptionalField bs pos "318"B  ReadUnderlyingCurrency
    let pos, underlyingQty = ReadOptionalField bs pos "879"B  ReadUnderlyingQty
    let pos, underlyingPx = ReadOptionalField bs pos "810"B  ReadUnderlyingPx
    let pos, underlyingDirtyPrice = ReadOptionalField bs pos "882"B  ReadUnderlyingDirtyPrice
    let pos, underlyingEndPrice = ReadOptionalField bs pos "883"B  ReadUnderlyingEndPrice
    let pos, underlyingStartValue = ReadOptionalField bs pos "884"B  ReadUnderlyingStartValue
    let pos, underlyingCurrentValue = ReadOptionalField bs pos "885"B  ReadUnderlyingCurrentValue
    let pos, underlyingEndValue = ReadOptionalField bs pos "886"B  ReadUnderlyingEndValue
    let pos, noUnderlyingStipsGrp = ReadOptionalGroup bs pos "887"B ReadNoUnderlyingStipsGrp
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
    pos, ci


// group
let ReadCollateralResponseNoUnderlyingsGrp (bs:byte []) (pos:int) : int * CollateralResponseNoUnderlyingsGrp  =
    let pos, underlyingInstrument = ReadComponent bs pos "ReadUnderlyingInstrument component" ReadUnderlyingInstrument
    let pos, collAction = ReadOptionalField bs pos "944"B  ReadCollAction
    let ci:CollateralResponseNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    pos, ci


// group
let ReadCollateralAssignmentNoUnderlyingsGrp (bs:byte []) (pos:int) : int * CollateralAssignmentNoUnderlyingsGrp  =
    let pos, underlyingInstrument = ReadComponent bs pos "ReadUnderlyingInstrument component" ReadUnderlyingInstrument
    let pos, collAction = ReadOptionalField bs pos "944"B  ReadCollAction
    let ci:CollateralAssignmentNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    pos, ci


// group
let ReadCollateralRequestNoUnderlyingsGrp (bs:byte []) (pos:int) : int * CollateralRequestNoUnderlyingsGrp  =
    let pos, underlyingInstrument = ReadComponent bs pos "ReadUnderlyingInstrument component" ReadUnderlyingInstrument
    let pos, collAction = ReadOptionalField bs pos "944"B  ReadCollAction
    let ci:CollateralRequestNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    pos, ci


// group
let ReadPositionReportNoUnderlyingsGrp (bs:byte []) (pos:int) : int * PositionReportNoUnderlyingsGrp  =
    let pos, underlyingInstrument = ReadComponent bs pos "ReadUnderlyingInstrument component" ReadUnderlyingInstrument
    let pos, underlyingSettlPrice = ReadField bs pos "ReadPositionReportNoUnderlyings" "732"B ReadUnderlyingSettlPrice
    let pos, underlyingSettlPriceType = ReadField bs pos "ReadPositionReportNoUnderlyings" "733"B ReadUnderlyingSettlPriceType
    let ci:PositionReportNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        UnderlyingSettlPrice = underlyingSettlPrice
        UnderlyingSettlPriceType = underlyingSettlPriceType
    }
    pos, ci


// group
let ReadNoNestedPartySubIDsGrp (bs:byte []) (pos:int) : int * NoNestedPartySubIDsGrp  =
    let pos, nestedPartySubID = ReadField bs pos "ReadNoNestedPartySubIDs" "545"B ReadNestedPartySubID
    let pos, nestedPartySubIDType = ReadOptionalField bs pos "805"B  ReadNestedPartySubIDType
    let ci:NoNestedPartySubIDsGrp = {
        NestedPartySubID = nestedPartySubID
        NestedPartySubIDType = nestedPartySubIDType
    }
    pos, ci


// group
let ReadNoNestedPartyIDsGrp (bs:byte []) (pos:int) : int * NoNestedPartyIDsGrp  =
    let pos, nestedPartyID = ReadField bs pos "ReadNoNestedPartyIDs" "524"B ReadNestedPartyID
    let pos, nestedPartyIDSource = ReadOptionalField bs pos "525"B  ReadNestedPartyIDSource
    let pos, nestedPartyRole = ReadOptionalField bs pos "538"B  ReadNestedPartyRole
    let pos, noNestedPartySubIDsGrp = ReadOptionalGroup bs pos "804"B ReadNoNestedPartySubIDsGrp
    let ci:NoNestedPartyIDsGrp = {
        NestedPartyID = nestedPartyID
        NestedPartyIDSource = nestedPartyIDSource
        NestedPartyRole = nestedPartyRole
        NoNestedPartySubIDsGrp = noNestedPartySubIDsGrp
    }
    pos, ci


// group
let ReadNoPositionsGrp (bs:byte []) (pos:int) : int * NoPositionsGrp  =
    let pos, posType = ReadField bs pos "ReadNoPositions" "703"B ReadPosType
    let pos, longQty = ReadOptionalField bs pos "704"B  ReadLongQty
    let pos, shortQty = ReadOptionalField bs pos "705"B  ReadShortQty
    let pos, posQtyStatus = ReadOptionalField bs pos "706"B  ReadPosQtyStatus
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let ci:NoPositionsGrp = {
        PosType = posType
        LongQty = longQty
        ShortQty = shortQty
        PosQtyStatus = posQtyStatus
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
    }
    pos, ci


// component
let ReadPositionQty (bs:byte []) (pos:int) : int * PositionQty  =
    let pos, noPositionsGrp = ReadGroup bs pos "ReadPositionQty" "702"B ReadNoPositionsGrp
    let ci:PositionQty = {
        NoPositionsGrp = noPositionsGrp
    }
    pos, ci


// group
let ReadNoRegistDtlsGrp (bs:byte []) (pos:int) : int * NoRegistDtlsGrp  =
    let pos, registDtls = ReadField bs pos "ReadNoRegistDtls" "509"B ReadRegistDtls
    let pos, registEmail = ReadOptionalField bs pos "511"B  ReadRegistEmail
    let pos, mailingDtls = ReadOptionalField bs pos "474"B  ReadMailingDtls
    let pos, mailingInst = ReadOptionalField bs pos "482"B  ReadMailingInst
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let pos, ownerType = ReadOptionalField bs pos "522"B  ReadOwnerType
    let pos, dateOfBirth = ReadOptionalField bs pos "486"B  ReadDateOfBirth
    let pos, investorCountryOfResidence = ReadOptionalField bs pos "475"B  ReadInvestorCountryOfResidence
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
    pos, ci


// group
let ReadNoNested2PartySubIDsGrp (bs:byte []) (pos:int) : int * NoNested2PartySubIDsGrp  =
    let pos, nested2PartySubID = ReadField bs pos "ReadNoNested2PartySubIDs" "760"B ReadNested2PartySubID
    let pos, nested2PartySubIDType = ReadOptionalField bs pos "807"B  ReadNested2PartySubIDType
    let ci:NoNested2PartySubIDsGrp = {
        Nested2PartySubID = nested2PartySubID
        Nested2PartySubIDType = nested2PartySubIDType
    }
    pos, ci


// group
let ReadNoNested2PartyIDsGrp (bs:byte []) (pos:int) : int * NoNested2PartyIDsGrp  =
    let pos, nested2PartyID = ReadField bs pos "ReadNoNested2PartyIDs" "757"B ReadNested2PartyID
    let pos, nested2PartyIDSource = ReadOptionalField bs pos "758"B  ReadNested2PartyIDSource
    let pos, nested2PartyRole = ReadOptionalField bs pos "759"B  ReadNested2PartyRole
    let pos, noNested2PartySubIDsGrp = ReadOptionalGroup bs pos "806"B ReadNoNested2PartySubIDsGrp
    let ci:NoNested2PartyIDsGrp = {
        Nested2PartyID = nested2PartyID
        Nested2PartyIDSource = nested2PartyIDSource
        Nested2PartyRole = nested2PartyRole
        NoNested2PartySubIDsGrp = noNested2PartySubIDsGrp
    }
    pos, ci


// group
let ReadTradeCaptureReportAckNoAllocsGrp (bs:byte []) (pos:int) : int * TradeCaptureReportAckNoAllocsGrp  =
    let pos, allocAccount = ReadField bs pos "ReadTradeCaptureReportAckNoAllocs" "79"B ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField bs pos "661"B  ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField bs pos "736"B  ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField bs pos "467"B  ReadIndividualAllocID
    let pos, noNested2PartyIDsGrp = ReadOptionalGroup bs pos "756"B ReadNoNested2PartyIDsGrp
    let pos, allocQty = ReadOptionalField bs pos "80"B  ReadAllocQty
    let ci:TradeCaptureReportAckNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
        AllocQty = allocQty
    }
    pos, ci


// group
let ReadNoLegSecurityAltIDGrp (bs:byte []) (pos:int) : int * NoLegSecurityAltIDGrp  =
    let pos, legSecurityAltID = ReadField bs pos "ReadNoLegSecurityAltID" "605"B ReadLegSecurityAltID
    let pos, legSecurityAltIDSource = ReadOptionalField bs pos "606"B  ReadLegSecurityAltIDSource
    let ci:NoLegSecurityAltIDGrp = {
        LegSecurityAltID = legSecurityAltID
        LegSecurityAltIDSource = legSecurityAltIDSource
    }
    pos, ci


// component
let ReadInstrumentLegFG (bs:byte []) (pos:int) : int * InstrumentLegFG  =
    let pos, legSymbol = ReadField bs pos "ReadInstrumentLegFG" "600"B ReadLegSymbol
    let pos, legSymbolSfx = ReadOptionalField bs pos "601"B  ReadLegSymbolSfx
    let pos, legSecurityID = ReadOptionalField bs pos "602"B  ReadLegSecurityID
    let pos, legSecurityIDSource = ReadOptionalField bs pos "603"B  ReadLegSecurityIDSource
    let pos, noLegSecurityAltIDGrp = ReadOptionalGroup bs pos "604"B ReadNoLegSecurityAltIDGrp
    let pos, legProduct = ReadOptionalField bs pos "607"B  ReadLegProduct
    let pos, legCFICode = ReadOptionalField bs pos "608"B  ReadLegCFICode
    let pos, legSecurityType = ReadOptionalField bs pos "609"B  ReadLegSecurityType
    let pos, legSecuritySubType = ReadOptionalField bs pos "764"B  ReadLegSecuritySubType
    let pos, legMaturityMonthYear = ReadOptionalField bs pos "610"B  ReadLegMaturityMonthYear
    let pos, legMaturityDate = ReadOptionalField bs pos "611"B  ReadLegMaturityDate
    let pos, legCouponPaymentDate = ReadOptionalField bs pos "248"B  ReadLegCouponPaymentDate
    let pos, legIssueDate = ReadOptionalField bs pos "249"B  ReadLegIssueDate
    let pos, legRepoCollateralSecurityType = ReadOptionalField bs pos "250"B  ReadLegRepoCollateralSecurityType
    let pos, legRepurchaseTerm = ReadOptionalField bs pos "251"B  ReadLegRepurchaseTerm
    let pos, legRepurchaseRate = ReadOptionalField bs pos "252"B  ReadLegRepurchaseRate
    let pos, legFactor = ReadOptionalField bs pos "253"B  ReadLegFactor
    let pos, legCreditRating = ReadOptionalField bs pos "257"B  ReadLegCreditRating
    let pos, legInstrRegistry = ReadOptionalField bs pos "599"B  ReadLegInstrRegistry
    let pos, legCountryOfIssue = ReadOptionalField bs pos "596"B  ReadLegCountryOfIssue
    let pos, legStateOrProvinceOfIssue = ReadOptionalField bs pos "597"B  ReadLegStateOrProvinceOfIssue
    let pos, legLocaleOfIssue = ReadOptionalField bs pos "598"B  ReadLegLocaleOfIssue
    let pos, legRedemptionDate = ReadOptionalField bs pos "254"B  ReadLegRedemptionDate
    let pos, legStrikePrice = ReadOptionalField bs pos "612"B  ReadLegStrikePrice
    let pos, legStrikeCurrency = ReadOptionalField bs pos "942"B  ReadLegStrikeCurrency
    let pos, legOptAttribute = ReadOptionalField bs pos "613"B  ReadLegOptAttribute
    let pos, legContractMultiplier = ReadOptionalField bs pos "614"B  ReadLegContractMultiplier
    let pos, legCouponRate = ReadOptionalField bs pos "615"B  ReadLegCouponRate
    let pos, legSecurityExchange = ReadOptionalField bs pos "616"B  ReadLegSecurityExchange
    let pos, legIssuer = ReadOptionalField bs pos "617"B  ReadLegIssuer
    let pos, encodedLegIssuer = ReadOptionalField bs pos "618"B  ReadEncodedLegIssuer
    let pos, legSecurityDesc = ReadOptionalField bs pos "620"B  ReadLegSecurityDesc
    let pos, encodedLegSecurityDesc = ReadOptionalField bs pos "621"B  ReadEncodedLegSecurityDesc
    let pos, legRatioQty = ReadOptionalField bs pos "623"B  ReadLegRatioQty
    let pos, legSide = ReadOptionalField bs pos "624"B  ReadLegSide
    let pos, legCurrency = ReadOptionalField bs pos "556"B  ReadLegCurrency
    let pos, legPool = ReadOptionalField bs pos "740"B  ReadLegPool
    let pos, legDatedDate = ReadOptionalField bs pos "739"B  ReadLegDatedDate
    let pos, legContractSettlMonth = ReadOptionalField bs pos "955"B  ReadLegContractSettlMonth
    let pos, legInterestAccrualDate = ReadOptionalField bs pos "956"B  ReadLegInterestAccrualDate
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
    pos, ci


// group
let ReadNoLegStipulationsGrp (bs:byte []) (pos:int) : int * NoLegStipulationsGrp  =
    let pos, legStipulationType = ReadField bs pos "ReadNoLegStipulations" "688"B ReadLegStipulationType
    let pos, legStipulationValue = ReadOptionalField bs pos "689"B  ReadLegStipulationValue
    let ci:NoLegStipulationsGrp = {
        LegStipulationType = legStipulationType
        LegStipulationValue = legStipulationValue
    }
    pos, ci


// group
let ReadTradeCaptureReportAckNoLegsGrp (bs:byte []) (pos:int) : int * TradeCaptureReportAckNoLegsGrp  =
    let pos, instrumentLegFG = ReadComponent bs pos "ReadInstrumentLegFG component" ReadInstrumentLegFG
    let pos, legQty = ReadOptionalField bs pos "687"B  ReadLegQty
    let pos, legSwapType = ReadOptionalField bs pos "690"B  ReadLegSwapType
    let pos, noLegStipulationsGrp = ReadOptionalGroup bs pos "683"B ReadNoLegStipulationsGrp
    let pos, legPositionEffect = ReadOptionalField bs pos "564"B  ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField bs pos "565"B  ReadLegCoveredOrUncovered
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let pos, legRefID = ReadOptionalField bs pos "654"B  ReadLegRefID
    let pos, legPrice = ReadOptionalField bs pos "566"B  ReadLegPrice
    let pos, legSettlType = ReadOptionalField bs pos "587"B  ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField bs pos "588"B  ReadLegSettlDate
    let pos, legLastPx = ReadOptionalField bs pos "637"B  ReadLegLastPx
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
    pos, ci


// group
let ReadNoPartySubIDsGrp (bs:byte []) (pos:int) : int * NoPartySubIDsGrp  =
    let pos, partySubID = ReadField bs pos "ReadNoPartySubIDs" "523"B ReadPartySubID
    let pos, partySubIDType = ReadOptionalField bs pos "803"B  ReadPartySubIDType
    let ci:NoPartySubIDsGrp = {
        PartySubID = partySubID
        PartySubIDType = partySubIDType
    }
    pos, ci


// group
let ReadNoPartyIDsGrp (bs:byte []) (pos:int) : int * NoPartyIDsGrp  =
    let pos, partyID = ReadField bs pos "ReadNoPartyIDs" "448"B ReadPartyID
    let pos, partyIDSource = ReadOptionalField bs pos "447"B  ReadPartyIDSource
    let pos, partyRole = ReadOptionalField bs pos "452"B  ReadPartyRole
    let pos, noPartySubIDsGrp = ReadOptionalGroup bs pos "802"B ReadNoPartySubIDsGrp
    let ci:NoPartyIDsGrp = {
        PartyID = partyID
        PartyIDSource = partyIDSource
        PartyRole = partyRole
        NoPartySubIDsGrp = noPartySubIDsGrp
    }
    pos, ci


// group
let ReadNoClearingInstructionsGrp (bs:byte []) (pos:int) : int * NoClearingInstructionsGrp  =
    let pos, clearingInstruction = ReadField bs pos "ReadNoClearingInstructions" "577"B ReadClearingInstruction
    let ci:NoClearingInstructionsGrp = {
        ClearingInstruction = clearingInstruction
    }
    pos, ci


// component
let ReadCommissionData (bs:byte []) (pos:int) : int * CommissionData  =
    let pos, commission = ReadOptionalField bs pos "12"B  ReadCommission
    let pos, commType = ReadOptionalField bs pos "13"B  ReadCommType
    let pos, commCurrency = ReadOptionalField bs pos "479"B  ReadCommCurrency
    let pos, fundRenewWaiv = ReadOptionalField bs pos "497"B  ReadFundRenewWaiv
    let ci:CommissionData = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    pos, ci


// group
let ReadNoContAmtsGrp (bs:byte []) (pos:int) : int * NoContAmtsGrp  =
    let pos, contAmtType = ReadField bs pos "ReadNoContAmts" "519"B ReadContAmtType
    let pos, contAmtValue = ReadOptionalField bs pos "520"B  ReadContAmtValue
    let pos, contAmtCurr = ReadOptionalField bs pos "521"B  ReadContAmtCurr
    let ci:NoContAmtsGrp = {
        ContAmtType = contAmtType
        ContAmtValue = contAmtValue
        ContAmtCurr = contAmtCurr
    }
    pos, ci


// group
let ReadNoStipulationsGrp (bs:byte []) (pos:int) : int * NoStipulationsGrp  =
    let pos, stipulationType = ReadField bs pos "ReadNoStipulations" "233"B ReadStipulationType
    let pos, stipulationValue = ReadOptionalField bs pos "234"B  ReadStipulationValue
    let ci:NoStipulationsGrp = {
        StipulationType = stipulationType
        StipulationValue = stipulationValue
    }
    pos, ci


// group
let ReadNoMiscFeesGrp (bs:byte []) (pos:int) : int * NoMiscFeesGrp  =
    let pos, miscFeeAmt = ReadField bs pos "ReadNoMiscFees" "137"B ReadMiscFeeAmt
    let pos, miscFeeCurr = ReadOptionalField bs pos "138"B  ReadMiscFeeCurr
    let pos, miscFeeType = ReadOptionalField bs pos "139"B  ReadMiscFeeType
    let pos, miscFeeBasis = ReadOptionalField bs pos "891"B  ReadMiscFeeBasis
    let ci:NoMiscFeesGrp = {
        MiscFeeAmt = miscFeeAmt
        MiscFeeCurr = miscFeeCurr
        MiscFeeType = miscFeeType
        MiscFeeBasis = miscFeeBasis
    }
    pos, ci


// group
let ReadTradeCaptureReportNoAllocsGrp (bs:byte []) (pos:int) : int * TradeCaptureReportNoAllocsGrp  =
    let pos, allocAccount = ReadField bs pos "ReadTradeCaptureReportNoAllocs" "79"B ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField bs pos "661"B  ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField bs pos "736"B  ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField bs pos "467"B  ReadIndividualAllocID
    let pos, noNested2PartyIDsGrp = ReadOptionalGroup bs pos "756"B ReadNoNested2PartyIDsGrp
    let pos, allocQty = ReadOptionalField bs pos "80"B  ReadAllocQty
    let ci:TradeCaptureReportNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
        AllocQty = allocQty
    }
    pos, ci


// group
let ReadTradeCaptureReportNoSidesGrp (bs:byte []) (pos:int) : int * TradeCaptureReportNoSidesGrp  =
    let pos, side = ReadField bs pos "ReadTradeCaptureReportNoSides" "54"B ReadSide
    let pos, orderID = ReadField bs pos "ReadTradeCaptureReportNoSides" "37"B ReadOrderID
    let pos, secondaryOrderID = ReadOptionalField bs pos "198"B  ReadSecondaryOrderID
    let pos, clOrdID = ReadOptionalField bs pos "11"B  ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField bs pos "526"B  ReadSecondaryClOrdID
    let pos, listID = ReadOptionalField bs pos "66"B  ReadListID
    let pos, noPartyIDsGrp = ReadOptionalGroup bs pos "453"B ReadNoPartyIDsGrp
    let pos, account = ReadOptionalField bs pos "1"B  ReadAccount
    let pos, acctIDSource = ReadOptionalField bs pos "660"B  ReadAcctIDSource
    let pos, accountType = ReadOptionalField bs pos "581"B  ReadAccountType
    let pos, processCode = ReadOptionalField bs pos "81"B  ReadProcessCode
    let pos, oddLot = ReadOptionalField bs pos "575"B  ReadOddLot
    let pos, noClearingInstructionsGrp = ReadOptionalGroup bs pos "576"B ReadNoClearingInstructionsGrp
    let pos, clearingFeeIndicator = ReadOptionalField bs pos "635"B  ReadClearingFeeIndicator
    let pos, tradeInputSource = ReadOptionalField bs pos "578"B  ReadTradeInputSource
    let pos, tradeInputDevice = ReadOptionalField bs pos "579"B  ReadTradeInputDevice
    let pos, orderInputDevice = ReadOptionalField bs pos "821"B  ReadOrderInputDevice
    let pos, currency = ReadOptionalField bs pos "15"B  ReadCurrency
    let pos, complianceID = ReadOptionalField bs pos "376"B  ReadComplianceID
    let pos, solicitedFlag = ReadOptionalField bs pos "377"B  ReadSolicitedFlag
    let pos, orderCapacity = ReadOptionalField bs pos "528"B  ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField bs pos "529"B  ReadOrderRestrictions
    let pos, custOrderCapacity = ReadOptionalField bs pos "582"B  ReadCustOrderCapacity
    let pos, ordType = ReadOptionalField bs pos "40"B  ReadOrdType
    let pos, execInst = ReadOptionalField bs pos "18"B  ReadExecInst
    let pos, transBkdTime = ReadOptionalField bs pos "483"B  ReadTransBkdTime
    let pos, tradingSessionID = ReadOptionalField bs pos "336"B  ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField bs pos "625"B  ReadTradingSessionSubID
    let pos, timeBracket = ReadOptionalField bs pos "943"B  ReadTimeBracket
    let pos, commissionData = ReadComponent bs pos "ReadCommissionData component" ReadCommissionData
    let pos, grossTradeAmt = ReadOptionalField bs pos "381"B  ReadGrossTradeAmt
    let pos, numDaysInterest = ReadOptionalField bs pos "157"B  ReadNumDaysInterest
    let pos, exDate = ReadOptionalField bs pos "230"B  ReadExDate
    let pos, accruedInterestRate = ReadOptionalField bs pos "158"B  ReadAccruedInterestRate
    let pos, accruedInterestAmt = ReadOptionalField bs pos "159"B  ReadAccruedInterestAmt
    let pos, interestAtMaturity = ReadOptionalField bs pos "738"B  ReadInterestAtMaturity
    let pos, endAccruedInterestAmt = ReadOptionalField bs pos "920"B  ReadEndAccruedInterestAmt
    let pos, startCash = ReadOptionalField bs pos "921"B  ReadStartCash
    let pos, endCash = ReadOptionalField bs pos "922"B  ReadEndCash
    let pos, concession = ReadOptionalField bs pos "238"B  ReadConcession
    let pos, totalTakedown = ReadOptionalField bs pos "237"B  ReadTotalTakedown
    let pos, netMoney = ReadOptionalField bs pos "118"B  ReadNetMoney
    let pos, settlCurrAmt = ReadOptionalField bs pos "119"B  ReadSettlCurrAmt
    let pos, settlCurrency = ReadOptionalField bs pos "120"B  ReadSettlCurrency
    let pos, settlCurrFxRate = ReadOptionalField bs pos "155"B  ReadSettlCurrFxRate
    let pos, settlCurrFxRateCalc = ReadOptionalField bs pos "156"B  ReadSettlCurrFxRateCalc
    let pos, positionEffect = ReadOptionalField bs pos "77"B  ReadPositionEffect
    let pos, text = ReadOptionalField bs pos "58"B  ReadText
    let pos, encodedText = ReadOptionalField bs pos "354"B  ReadEncodedText
    let pos, sideMultiLegReportingType = ReadOptionalField bs pos "752"B  ReadSideMultiLegReportingType
    let pos, noContAmtsGrp = ReadOptionalGroup bs pos "518"B ReadNoContAmtsGrp
    let pos, noStipulationsGrp = ReadOptionalGroup bs pos "232"B ReadNoStipulationsGrp
    let pos, noMiscFeesGrp = ReadOptionalGroup bs pos "136"B ReadNoMiscFeesGrp
    let pos, exchangeRule = ReadOptionalField bs pos "825"B  ReadExchangeRule
    let pos, tradeAllocIndicator = ReadOptionalField bs pos "826"B  ReadTradeAllocIndicator
    let pos, preallocMethod = ReadOptionalField bs pos "591"B  ReadPreallocMethod
    let pos, allocID = ReadOptionalField bs pos "70"B  ReadAllocID
    let pos, tradeCaptureReportNoAllocsGrp = ReadOptionalGroup bs pos "78"B ReadTradeCaptureReportNoAllocsGrp
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
    pos, ci


// group
let ReadTradeCaptureReportNoLegsGrp (bs:byte []) (pos:int) : int * TradeCaptureReportNoLegsGrp  =
    let pos, instrumentLegFG = ReadComponent bs pos "ReadInstrumentLegFG component" ReadInstrumentLegFG
    let pos, legQty = ReadOptionalField bs pos "687"B  ReadLegQty
    let pos, legSwapType = ReadOptionalField bs pos "690"B  ReadLegSwapType
    let pos, noLegStipulationsGrp = ReadOptionalGroup bs pos "683"B ReadNoLegStipulationsGrp
    let pos, legPositionEffect = ReadOptionalField bs pos "564"B  ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField bs pos "565"B  ReadLegCoveredOrUncovered
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let pos, legRefID = ReadOptionalField bs pos "654"B  ReadLegRefID
    let pos, legPrice = ReadOptionalField bs pos "566"B  ReadLegPrice
    let pos, legSettlType = ReadOptionalField bs pos "587"B  ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField bs pos "588"B  ReadLegSettlDate
    let pos, legLastPx = ReadOptionalField bs pos "637"B  ReadLegLastPx
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
    pos, ci


// group
let ReadNoPosAmtGrp (bs:byte []) (pos:int) : int * NoPosAmtGrp  =
    let pos, posAmtType = ReadField bs pos "ReadNoPosAmt" "707"B ReadPosAmtType
    let pos, posAmt = ReadField bs pos "ReadNoPosAmt" "708"B ReadPosAmt
    let ci:NoPosAmtGrp = {
        PosAmtType = posAmtType
        PosAmt = posAmt
    }
    pos, ci


// component
let ReadPositionAmountData (bs:byte []) (pos:int) : int * PositionAmountData  =
    let pos, noPosAmtGrp = ReadGroup bs pos "ReadPositionAmountData" "753"B ReadNoPosAmtGrp
    let ci:PositionAmountData = {
        NoPosAmtGrp = noPosAmtGrp
    }
    pos, ci


// group
let ReadNoSettlPartySubIDsGrp (bs:byte []) (pos:int) : int * NoSettlPartySubIDsGrp  =
    let pos, settlPartySubID = ReadField bs pos "ReadNoSettlPartySubIDs" "785"B ReadSettlPartySubID
    let pos, settlPartySubIDType = ReadOptionalField bs pos "786"B  ReadSettlPartySubIDType
    let ci:NoSettlPartySubIDsGrp = {
        SettlPartySubID = settlPartySubID
        SettlPartySubIDType = settlPartySubIDType
    }
    pos, ci


// group
let ReadNoSettlPartyIDsGrp (bs:byte []) (pos:int) : int * NoSettlPartyIDsGrp  =
    let pos, settlPartyID = ReadField bs pos "ReadNoSettlPartyIDs" "782"B ReadSettlPartyID
    let pos, settlPartyIDSource = ReadOptionalField bs pos "783"B  ReadSettlPartyIDSource
    let pos, settlPartyRole = ReadOptionalField bs pos "784"B  ReadSettlPartyRole
    let pos, noSettlPartySubIDsGrp = ReadOptionalGroup bs pos "801"B ReadNoSettlPartySubIDsGrp
    let ci:NoSettlPartyIDsGrp = {
        SettlPartyID = settlPartyID
        SettlPartyIDSource = settlPartyIDSource
        SettlPartyRole = settlPartyRole
        NoSettlPartySubIDsGrp = noSettlPartySubIDsGrp
    }
    pos, ci


// group
let ReadNoDlvyInstGrp (bs:byte []) (pos:int) : int * NoDlvyInstGrp  =
    let pos, settlInstSource = ReadField bs pos "ReadNoDlvyInst" "165"B ReadSettlInstSource
    let pos, dlvyInstType = ReadOptionalField bs pos "787"B  ReadDlvyInstType
    let pos, noSettlPartyIDsGrp = ReadOptionalGroup bs pos "781"B ReadNoSettlPartyIDsGrp
    let ci:NoDlvyInstGrp = {
        SettlInstSource = settlInstSource
        DlvyInstType = dlvyInstType
        NoSettlPartyIDsGrp = noSettlPartyIDsGrp
    }
    pos, ci


// component
let ReadSettlInstructionsData (bs:byte []) (pos:int) : int * SettlInstructionsData  =
    let pos, settlDeliveryType = ReadOptionalField bs pos "172"B  ReadSettlDeliveryType
    let pos, standInstDbType = ReadOptionalField bs pos "169"B  ReadStandInstDbType
    let pos, standInstDbName = ReadOptionalField bs pos "170"B  ReadStandInstDbName
    let pos, standInstDbID = ReadOptionalField bs pos "171"B  ReadStandInstDbID
    let pos, noDlvyInstGrp = ReadOptionalGroup bs pos "85"B ReadNoDlvyInstGrp
    let ci:SettlInstructionsData = {
        SettlDeliveryType = settlDeliveryType
        StandInstDbType = standInstDbType
        StandInstDbName = standInstDbName
        StandInstDbID = standInstDbID
        NoDlvyInstGrp = noDlvyInstGrp
    }
    pos, ci


// group
let ReadNoSettlInstGrp (bs:byte []) (pos:int) : int * NoSettlInstGrp  =
    let pos, settlInstID = ReadField bs pos "ReadNoSettlInst" "162"B ReadSettlInstID
    let pos, settlInstTransType = ReadOptionalField bs pos "163"B  ReadSettlInstTransType
    let pos, settlInstRefID = ReadOptionalField bs pos "214"B  ReadSettlInstRefID
    let pos, noPartyIDsGrp = ReadOptionalGroup bs pos "453"B ReadNoPartyIDsGrp
    let pos, side = ReadOptionalField bs pos "54"B  ReadSide
    let pos, product = ReadOptionalField bs pos "460"B  ReadProduct
    let pos, securityType = ReadOptionalField bs pos "167"B  ReadSecurityType
    let pos, cFICode = ReadOptionalField bs pos "461"B  ReadCFICode
    let pos, effectiveTime = ReadOptionalField bs pos "168"B  ReadEffectiveTime
    let pos, expireTime = ReadOptionalField bs pos "126"B  ReadExpireTime
    let pos, lastUpdateTime = ReadOptionalField bs pos "779"B  ReadLastUpdateTime
    let pos, settlInstructionsData = ReadComponent bs pos "ReadSettlInstructionsData component" ReadSettlInstructionsData
    let pos, paymentMethod = ReadOptionalField bs pos "492"B  ReadPaymentMethod
    let pos, paymentRef = ReadOptionalField bs pos "476"B  ReadPaymentRef
    let pos, cardHolderName = ReadOptionalField bs pos "488"B  ReadCardHolderName
    let pos, cardNumber = ReadOptionalField bs pos "489"B  ReadCardNumber
    let pos, cardStartDate = ReadOptionalField bs pos "503"B  ReadCardStartDate
    let pos, cardExpDate = ReadOptionalField bs pos "490"B  ReadCardExpDate
    let pos, cardIssNum = ReadOptionalField bs pos "491"B  ReadCardIssNum
    let pos, paymentDate = ReadOptionalField bs pos "504"B  ReadPaymentDate
    let pos, paymentRemitterID = ReadOptionalField bs pos "505"B  ReadPaymentRemitterID
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
    pos, ci


// group
let ReadNoTrdRegTimestampsGrp (bs:byte []) (pos:int) : int * NoTrdRegTimestampsGrp  =
    let pos, trdRegTimestamp = ReadField bs pos "ReadNoTrdRegTimestamps" "769"B ReadTrdRegTimestamp
    let pos, trdRegTimestampType = ReadOptionalField bs pos "770"B  ReadTrdRegTimestampType
    let pos, trdRegTimestampOrigin = ReadOptionalField bs pos "771"B  ReadTrdRegTimestampOrigin
    let ci:NoTrdRegTimestampsGrp = {
        TrdRegTimestamp = trdRegTimestamp
        TrdRegTimestampType = trdRegTimestampType
        TrdRegTimestampOrigin = trdRegTimestampOrigin
    }
    pos, ci


// component
let ReadTrdRegTimestamps (bs:byte []) (pos:int) : int * TrdRegTimestamps  =
    let pos, noTrdRegTimestampsGrp = ReadGroup bs pos "ReadTrdRegTimestamps" "768"B ReadNoTrdRegTimestampsGrp
    let ci:TrdRegTimestamps = {
        NoTrdRegTimestampsGrp = noTrdRegTimestampsGrp
    }
    pos, ci


// group
let ReadAllocationReportNoAllocsGrp (bs:byte []) (pos:int) : int * AllocationReportNoAllocsGrp  =
    let pos, allocAccount = ReadField bs pos "ReadAllocationReportNoAllocs" "79"B ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField bs pos "661"B  ReadAllocAcctIDSource
    let pos, matchStatus = ReadOptionalField bs pos "573"B  ReadMatchStatus
    let pos, allocPrice = ReadOptionalField bs pos "366"B  ReadAllocPrice
    let pos, allocQty = ReadField bs pos "ReadAllocationReportNoAllocs" "80"B ReadAllocQty
    let pos, individualAllocID = ReadOptionalField bs pos "467"B  ReadIndividualAllocID
    let pos, processCode = ReadOptionalField bs pos "81"B  ReadProcessCode
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let pos, notifyBrokerOfCredit = ReadOptionalField bs pos "208"B  ReadNotifyBrokerOfCredit
    let pos, allocHandlInst = ReadOptionalField bs pos "209"B  ReadAllocHandlInst
    let pos, allocText = ReadOptionalField bs pos "161"B  ReadAllocText
    let pos, encodedAllocText = ReadOptionalField bs pos "360"B  ReadEncodedAllocText
    let pos, commissionData = ReadComponent bs pos "ReadCommissionData component" ReadCommissionData
    let pos, allocAvgPx = ReadOptionalField bs pos "153"B  ReadAllocAvgPx
    let pos, allocNetMoney = ReadOptionalField bs pos "154"B  ReadAllocNetMoney
    let pos, settlCurrAmt = ReadOptionalField bs pos "119"B  ReadSettlCurrAmt
    let pos, allocSettlCurrAmt = ReadOptionalField bs pos "737"B  ReadAllocSettlCurrAmt
    let pos, settlCurrency = ReadOptionalField bs pos "120"B  ReadSettlCurrency
    let pos, allocSettlCurrency = ReadOptionalField bs pos "736"B  ReadAllocSettlCurrency
    let pos, settlCurrFxRate = ReadOptionalField bs pos "155"B  ReadSettlCurrFxRate
    let pos, settlCurrFxRateCalc = ReadOptionalField bs pos "156"B  ReadSettlCurrFxRateCalc
    let pos, allocAccruedInterestAmt = ReadOptionalField bs pos "742"B  ReadAllocAccruedInterestAmt
    let pos, allocInterestAtMaturity = ReadOptionalField bs pos "741"B  ReadAllocInterestAtMaturity
    let pos, noMiscFeesGrp = ReadOptionalGroup bs pos "136"B ReadNoMiscFeesGrp
    let pos, noClearingInstructionsGrp = ReadOptionalGroup bs pos "576"B ReadNoClearingInstructionsGrp
    let pos, clearingFeeIndicator = ReadOptionalField bs pos "635"B  ReadClearingFeeIndicator
    let pos, allocSettlInstType = ReadOptionalField bs pos "780"B  ReadAllocSettlInstType
    let pos, settlInstructionsData = ReadComponent bs pos "ReadSettlInstructionsData component" ReadSettlInstructionsData
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
    pos, ci


// group
let ReadAllocationInstructionNoAllocsGrp (bs:byte []) (pos:int) : int * AllocationInstructionNoAllocsGrp  =
    let pos, allocAccount = ReadField bs pos "ReadAllocationInstructionNoAllocs" "79"B ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField bs pos "661"B  ReadAllocAcctIDSource
    let pos, matchStatus = ReadOptionalField bs pos "573"B  ReadMatchStatus
    let pos, allocPrice = ReadOptionalField bs pos "366"B  ReadAllocPrice
    let pos, allocQty = ReadOptionalField bs pos "80"B  ReadAllocQty
    let pos, individualAllocID = ReadOptionalField bs pos "467"B  ReadIndividualAllocID
    let pos, processCode = ReadOptionalField bs pos "81"B  ReadProcessCode
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let pos, notifyBrokerOfCredit = ReadOptionalField bs pos "208"B  ReadNotifyBrokerOfCredit
    let pos, allocHandlInst = ReadOptionalField bs pos "209"B  ReadAllocHandlInst
    let pos, allocText = ReadOptionalField bs pos "161"B  ReadAllocText
    let pos, encodedAllocText = ReadOptionalField bs pos "360"B  ReadEncodedAllocText
    let pos, commissionData = ReadComponent bs pos "ReadCommissionData component" ReadCommissionData
    let pos, allocAvgPx = ReadOptionalField bs pos "153"B  ReadAllocAvgPx
    let pos, allocNetMoney = ReadOptionalField bs pos "154"B  ReadAllocNetMoney
    let pos, settlCurrAmt = ReadOptionalField bs pos "119"B  ReadSettlCurrAmt
    let pos, allocSettlCurrAmt = ReadOptionalField bs pos "737"B  ReadAllocSettlCurrAmt
    let pos, settlCurrency = ReadOptionalField bs pos "120"B  ReadSettlCurrency
    let pos, allocSettlCurrency = ReadOptionalField bs pos "736"B  ReadAllocSettlCurrency
    let pos, settlCurrFxRate = ReadOptionalField bs pos "155"B  ReadSettlCurrFxRate
    let pos, settlCurrFxRateCalc = ReadOptionalField bs pos "156"B  ReadSettlCurrFxRateCalc
    let pos, accruedInterestAmt = ReadOptionalField bs pos "159"B  ReadAccruedInterestAmt
    let pos, allocAccruedInterestAmt = ReadOptionalField bs pos "742"B  ReadAllocAccruedInterestAmt
    let pos, allocInterestAtMaturity = ReadOptionalField bs pos "741"B  ReadAllocInterestAtMaturity
    let pos, settlInstMode = ReadOptionalField bs pos "160"B  ReadSettlInstMode
    let pos, noMiscFeesGrp = ReadOptionalGroup bs pos "136"B ReadNoMiscFeesGrp
    let pos, noClearingInstructions = ReadOptionalField bs pos "576"B  ReadNoClearingInstructions
    let pos, clearingInstruction = ReadOptionalField bs pos "577"B  ReadClearingInstruction
    let pos, clearingFeeIndicator = ReadOptionalField bs pos "635"B  ReadClearingFeeIndicator
    let pos, allocSettlInstType = ReadOptionalField bs pos "780"B  ReadAllocSettlInstType
    let pos, settlInstructionsData = ReadComponent bs pos "ReadSettlInstructionsData component" ReadSettlInstructionsData
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
    pos, ci


// component
let ReadSettlParties (bs:byte []) (pos:int) : int * SettlParties  =
    let pos, noSettlPartyIDsGrp = ReadOptionalGroup bs pos "781"B ReadNoSettlPartyIDsGrp
    let ci:SettlParties = {
        NoSettlPartyIDsGrp = noSettlPartyIDsGrp
    }
    pos, ci


// group
let ReadNoOrdersGrp (bs:byte []) (pos:int) : int * NoOrdersGrp  =
    let pos, clOrdID = ReadField bs pos "ReadNoOrders" "11"B ReadClOrdID
    let pos, orderID = ReadOptionalField bs pos "37"B  ReadOrderID
    let pos, secondaryOrderID = ReadOptionalField bs pos "198"B  ReadSecondaryOrderID
    let pos, secondaryClOrdID = ReadOptionalField bs pos "526"B  ReadSecondaryClOrdID
    let pos, listID = ReadOptionalField bs pos "66"B  ReadListID
    let pos, noNested2PartyIDsGrp = ReadOptionalGroup bs pos "756"B ReadNoNested2PartyIDsGrp
    let pos, orderQty = ReadOptionalField bs pos "38"B  ReadOrderQty
    let pos, orderAvgPx = ReadOptionalField bs pos "799"B  ReadOrderAvgPx
    let pos, orderBookingQty = ReadOptionalField bs pos "800"B  ReadOrderBookingQty
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
    pos, ci


// group
let ReadListStrikePriceNoUnderlyingsGrp (bs:byte []) (pos:int) : int * ListStrikePriceNoUnderlyingsGrp  =
    let pos, underlyingInstrument = ReadComponent bs pos "ReadUnderlyingInstrument component" ReadUnderlyingInstrument
    let pos, prevClosePx = ReadOptionalField bs pos "140"B  ReadPrevClosePx
    let pos, clOrdID = ReadOptionalField bs pos "11"B  ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField bs pos "526"B  ReadSecondaryClOrdID
    let pos, side = ReadOptionalField bs pos "54"B  ReadSide
    let pos, price = ReadField bs pos "ReadListStrikePriceNoUnderlyings" "44"B ReadPrice
    let pos, currency = ReadOptionalField bs pos "15"B  ReadCurrency
    let pos, text = ReadOptionalField bs pos "58"B  ReadText
    let pos, encodedText = ReadOptionalField bs pos "354"B  ReadEncodedText
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
    pos, ci


// group
let ReadNoSecurityAltIDGrp (bs:byte []) (pos:int) : int * NoSecurityAltIDGrp  =
    let pos, securityAltID = ReadField bs pos "ReadNoSecurityAltID" "455"B ReadSecurityAltID
    let pos, securityAltIDSource = ReadOptionalField bs pos "456"B  ReadSecurityAltIDSource
    let ci:NoSecurityAltIDGrp = {
        SecurityAltID = securityAltID
        SecurityAltIDSource = securityAltIDSource
    }
    pos, ci


// group
let ReadNoEventsGrp (bs:byte []) (pos:int) : int * NoEventsGrp  =
    let pos, eventType = ReadField bs pos "ReadNoEvents" "865"B ReadEventType
    let pos, eventDate = ReadOptionalField bs pos "866"B  ReadEventDate
    let pos, eventPx = ReadOptionalField bs pos "867"B  ReadEventPx
    let pos, eventText = ReadOptionalField bs pos "868"B  ReadEventText
    let ci:NoEventsGrp = {
        EventType = eventType
        EventDate = eventDate
        EventPx = eventPx
        EventText = eventText
    }
    pos, ci


// component
let ReadInstrument (bs:byte []) (pos:int) : int * Instrument  =
    let pos, symbol = ReadField bs pos "ReadInstrument" "55"B ReadSymbol
    let pos, symbolSfx = ReadOptionalField bs pos "65"B  ReadSymbolSfx
    let pos, securityID = ReadOptionalField bs pos "48"B  ReadSecurityID
    let pos, securityIDSource = ReadOptionalField bs pos "22"B  ReadSecurityIDSource
    let pos, noSecurityAltIDGrp = ReadOptionalGroup bs pos "454"B ReadNoSecurityAltIDGrp
    let pos, product = ReadOptionalField bs pos "460"B  ReadProduct
    let pos, cFICode = ReadOptionalField bs pos "461"B  ReadCFICode
    let pos, securityType = ReadOptionalField bs pos "167"B  ReadSecurityType
    let pos, securitySubType = ReadOptionalField bs pos "762"B  ReadSecuritySubType
    let pos, maturityMonthYear = ReadOptionalField bs pos "200"B  ReadMaturityMonthYear
    let pos, maturityDate = ReadOptionalField bs pos "541"B  ReadMaturityDate
    let pos, putOrCall = ReadOptionalField bs pos "201"B  ReadPutOrCall
    let pos, couponPaymentDate = ReadOptionalField bs pos "224"B  ReadCouponPaymentDate
    let pos, issueDate = ReadOptionalField bs pos "225"B  ReadIssueDate
    let pos, repoCollateralSecurityType = ReadOptionalField bs pos "239"B  ReadRepoCollateralSecurityType
    let pos, repurchaseTerm = ReadOptionalField bs pos "226"B  ReadRepurchaseTerm
    let pos, repurchaseRate = ReadOptionalField bs pos "227"B  ReadRepurchaseRate
    let pos, factor = ReadOptionalField bs pos "228"B  ReadFactor
    let pos, creditRating = ReadOptionalField bs pos "255"B  ReadCreditRating
    let pos, instrRegistry = ReadOptionalField bs pos "543"B  ReadInstrRegistry
    let pos, countryOfIssue = ReadOptionalField bs pos "470"B  ReadCountryOfIssue
    let pos, stateOrProvinceOfIssue = ReadOptionalField bs pos "471"B  ReadStateOrProvinceOfIssue
    let pos, localeOfIssue = ReadOptionalField bs pos "472"B  ReadLocaleOfIssue
    let pos, redemptionDate = ReadOptionalField bs pos "240"B  ReadRedemptionDate
    let pos, strikePrice = ReadOptionalField bs pos "202"B  ReadStrikePrice
    let pos, strikeCurrency = ReadOptionalField bs pos "947"B  ReadStrikeCurrency
    let pos, optAttribute = ReadOptionalField bs pos "206"B  ReadOptAttribute
    let pos, contractMultiplier = ReadOptionalField bs pos "231"B  ReadContractMultiplier
    let pos, couponRate = ReadOptionalField bs pos "223"B  ReadCouponRate
    let pos, securityExchange = ReadOptionalField bs pos "207"B  ReadSecurityExchange
    let pos, issuer = ReadOptionalField bs pos "106"B  ReadIssuer
    let pos, encodedIssuer = ReadOptionalField bs pos "348"B  ReadEncodedIssuer
    let pos, securityDesc = ReadOptionalField bs pos "107"B  ReadSecurityDesc
    let pos, encodedSecurityDesc = ReadOptionalField bs pos "350"B  ReadEncodedSecurityDesc
    let pos, pool = ReadOptionalField bs pos "691"B  ReadPool
    let pos, contractSettlMonth = ReadOptionalField bs pos "667"B  ReadContractSettlMonth
    let pos, cPProgram = ReadOptionalField bs pos "875"B  ReadCPProgram
    let pos, cPRegType = ReadOptionalField bs pos "876"B  ReadCPRegType
    let pos, noEventsGrp = ReadOptionalGroup bs pos "864"B ReadNoEventsGrp
    let pos, datedDate = ReadOptionalField bs pos "873"B  ReadDatedDate
    let pos, interestAccrualDate = ReadOptionalField bs pos "874"B  ReadInterestAccrualDate
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
    pos, ci


// group
let ReadNoStrikesGrp (bs:byte []) (pos:int) : int * NoStrikesGrp  =
    let pos, instrument = ReadComponent bs pos "ReadInstrument component" ReadInstrument
    let ci:NoStrikesGrp = {
        Instrument = instrument
    }
    pos, ci


// group
let ReadNoAllocsGrp (bs:byte []) (pos:int) : int * NoAllocsGrp  =
    let pos, allocAccount = ReadField bs pos "ReadNoAllocs" "79"B ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField bs pos "661"B  ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField bs pos "736"B  ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField bs pos "467"B  ReadIndividualAllocID
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let pos, allocQty = ReadOptionalField bs pos "80"B  ReadAllocQty
    let ci:NoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        AllocQty = allocQty
    }
    pos, ci


// group
let ReadNoTradingSessionsGrp (bs:byte []) (pos:int) : int * NoTradingSessionsGrp  =
    let pos, tradingSessionID = ReadField bs pos "ReadNoTradingSessions" "336"B ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField bs pos "625"B  ReadTradingSessionSubID
    let ci:NoTradingSessionsGrp = {
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
    }
    pos, ci


// group
let ReadNoUnderlyingsGrp (bs:byte []) (pos:int) : int * NoUnderlyingsGrp  =
    let pos, underlyingInstrument = ReadComponent bs pos "ReadUnderlyingInstrument component" ReadUnderlyingInstrument
    let ci:NoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
    }
    pos, ci


// component
let ReadOrderQtyData (bs:byte []) (pos:int) : int * OrderQtyData  =
    let pos, orderQty = ReadOptionalField bs pos "38"B  ReadOrderQty
    let pos, cashOrderQty = ReadOptionalField bs pos "152"B  ReadCashOrderQty
    let pos, orderPercent = ReadOptionalField bs pos "516"B  ReadOrderPercent
    let pos, roundingDirection = ReadOptionalField bs pos "468"B  ReadRoundingDirection
    let pos, roundingModulus = ReadOptionalField bs pos "469"B  ReadRoundingModulus
    let ci:OrderQtyData = {
        OrderQty = orderQty
        CashOrderQty = cashOrderQty
        OrderPercent = orderPercent
        RoundingDirection = roundingDirection
        RoundingModulus = roundingModulus
    }
    pos, ci


// component
let ReadSpreadOrBenchmarkCurveData (bs:byte []) (pos:int) : int * SpreadOrBenchmarkCurveData  =
    let pos, spread = ReadOptionalField bs pos "218"B  ReadSpread
    let pos, benchmarkCurveCurrency = ReadOptionalField bs pos "220"B  ReadBenchmarkCurveCurrency
    let pos, benchmarkCurveName = ReadOptionalField bs pos "221"B  ReadBenchmarkCurveName
    let pos, benchmarkCurvePoint = ReadOptionalField bs pos "222"B  ReadBenchmarkCurvePoint
    let pos, benchmarkPrice = ReadOptionalField bs pos "662"B  ReadBenchmarkPrice
    let pos, benchmarkPriceType = ReadOptionalField bs pos "663"B  ReadBenchmarkPriceType
    let pos, benchmarkSecurityID = ReadOptionalField bs pos "699"B  ReadBenchmarkSecurityID
    let pos, benchmarkSecurityIDSource = ReadOptionalField bs pos "761"B  ReadBenchmarkSecurityIDSource
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
    pos, ci


// component
let ReadYieldData (bs:byte []) (pos:int) : int * YieldData  =
    let pos, yieldType = ReadOptionalField bs pos "235"B  ReadYieldType
    let pos, yyield = ReadOptionalField bs pos "236"B  ReadYield
    let pos, yieldCalcDate = ReadOptionalField bs pos "701"B  ReadYieldCalcDate
    let pos, yieldRedemptionDate = ReadOptionalField bs pos "696"B  ReadYieldRedemptionDate
    let pos, yieldRedemptionPrice = ReadOptionalField bs pos "697"B  ReadYieldRedemptionPrice
    let pos, yieldRedemptionPriceType = ReadOptionalField bs pos "698"B  ReadYieldRedemptionPriceType
    let ci:YieldData = {
        YieldType = yieldType
        Yield = yyield
        YieldCalcDate = yieldCalcDate
        YieldRedemptionDate = yieldRedemptionDate
        YieldRedemptionPrice = yieldRedemptionPrice
        YieldRedemptionPriceType = yieldRedemptionPriceType
    }
    pos, ci


// component
let ReadPegInstructions (bs:byte []) (pos:int) : int * PegInstructions  =
    let pos, pegOffsetValue = ReadOptionalField bs pos "211"B  ReadPegOffsetValue
    let pos, pegMoveType = ReadOptionalField bs pos "835"B  ReadPegMoveType
    let pos, pegOffsetType = ReadOptionalField bs pos "836"B  ReadPegOffsetType
    let pos, pegLimitType = ReadOptionalField bs pos "837"B  ReadPegLimitType
    let pos, pegRoundDirection = ReadOptionalField bs pos "838"B  ReadPegRoundDirection
    let pos, pegScope = ReadOptionalField bs pos "840"B  ReadPegScope
    let ci:PegInstructions = {
        PegOffsetValue = pegOffsetValue
        PegMoveType = pegMoveType
        PegOffsetType = pegOffsetType
        PegLimitType = pegLimitType
        PegRoundDirection = pegRoundDirection
        PegScope = pegScope
    }
    pos, ci


// component
let ReadDiscretionInstructions (bs:byte []) (pos:int) : int * DiscretionInstructions  =
    let pos, discretionInst = ReadOptionalField bs pos "388"B  ReadDiscretionInst
    let pos, discretionOffsetValue = ReadOptionalField bs pos "389"B  ReadDiscretionOffsetValue
    let pos, discretionMoveType = ReadOptionalField bs pos "841"B  ReadDiscretionMoveType
    let pos, discretionOffsetType = ReadOptionalField bs pos "842"B  ReadDiscretionOffsetType
    let pos, discretionLimitType = ReadOptionalField bs pos "843"B  ReadDiscretionLimitType
    let pos, discretionRoundDirection = ReadOptionalField bs pos "844"B  ReadDiscretionRoundDirection
    let pos, discretionScope = ReadOptionalField bs pos "846"B  ReadDiscretionScope
    let ci:DiscretionInstructions = {
        DiscretionInst = discretionInst
        DiscretionOffsetValue = discretionOffsetValue
        DiscretionMoveType = discretionMoveType
        DiscretionOffsetType = discretionOffsetType
        DiscretionLimitType = discretionLimitType
        DiscretionRoundDirection = discretionRoundDirection
        DiscretionScope = discretionScope
    }
    pos, ci


// group
let ReadNewOrderListNoOrdersGrp (bs:byte []) (pos:int) : int * NewOrderListNoOrdersGrp  =
    let pos, clOrdID = ReadField bs pos "ReadNewOrderListNoOrders" "11"B ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField bs pos "526"B  ReadSecondaryClOrdID
    let pos, listSeqNo = ReadField bs pos "ReadNewOrderListNoOrders" "67"B ReadListSeqNo
    let pos, clOrdLinkID = ReadOptionalField bs pos "583"B  ReadClOrdLinkID
    let pos, settlInstMode = ReadOptionalField bs pos "160"B  ReadSettlInstMode
    let pos, noPartyIDsGrp = ReadOptionalGroup bs pos "453"B ReadNoPartyIDsGrp
    let pos, tradeOriginationDate = ReadOptionalField bs pos "229"B  ReadTradeOriginationDate
    let pos, tradeDate = ReadOptionalField bs pos "75"B  ReadTradeDate
    let pos, account = ReadOptionalField bs pos "1"B  ReadAccount
    let pos, acctIDSource = ReadOptionalField bs pos "660"B  ReadAcctIDSource
    let pos, accountType = ReadOptionalField bs pos "581"B  ReadAccountType
    let pos, dayBookingInst = ReadOptionalField bs pos "589"B  ReadDayBookingInst
    let pos, bookingUnit = ReadOptionalField bs pos "590"B  ReadBookingUnit
    let pos, allocID = ReadOptionalField bs pos "70"B  ReadAllocID
    let pos, preallocMethod = ReadOptionalField bs pos "591"B  ReadPreallocMethod
    let pos, noAllocsGrp = ReadOptionalGroup bs pos "78"B ReadNoAllocsGrp
    let pos, settlType = ReadOptionalField bs pos "63"B  ReadSettlType
    let pos, settlDate = ReadOptionalField bs pos "64"B  ReadSettlDate
    let pos, cashMargin = ReadOptionalField bs pos "544"B  ReadCashMargin
    let pos, clearingFeeIndicator = ReadOptionalField bs pos "635"B  ReadClearingFeeIndicator
    let pos, handlInst = ReadOptionalField bs pos "21"B  ReadHandlInst
    let pos, execInst = ReadOptionalField bs pos "18"B  ReadExecInst
    let pos, minQty = ReadOptionalField bs pos "110"B  ReadMinQty
    let pos, maxFloor = ReadOptionalField bs pos "111"B  ReadMaxFloor
    let pos, exDestination = ReadOptionalField bs pos "100"B  ReadExDestination
    let pos, noTradingSessionsGrp = ReadOptionalGroup bs pos "386"B ReadNoTradingSessionsGrp
    let pos, processCode = ReadOptionalField bs pos "81"B  ReadProcessCode
    let pos, instrument = ReadComponent bs pos "ReadInstrument component" ReadInstrument
    let pos, noUnderlyingsGrp = ReadOptionalGroup bs pos "711"B ReadNoUnderlyingsGrp
    let pos, prevClosePx = ReadOptionalField bs pos "140"B  ReadPrevClosePx
    let pos, side = ReadField bs pos "ReadNewOrderListNoOrders" "54"B ReadSide
    let pos, sideValueInd = ReadOptionalField bs pos "401"B  ReadSideValueInd
    let pos, locateReqd = ReadOptionalField bs pos "114"B  ReadLocateReqd
    let pos, transactTime = ReadOptionalField bs pos "60"B  ReadTransactTime
    let pos, noStipulationsGrp = ReadOptionalGroup bs pos "232"B ReadNoStipulationsGrp
    let pos, qtyType = ReadOptionalField bs pos "854"B  ReadQtyType
    let pos, orderQtyData = ReadComponent bs pos "ReadOrderQtyData component" ReadOrderQtyData
    let pos, ordType = ReadOptionalField bs pos "40"B  ReadOrdType
    let pos, priceType = ReadOptionalField bs pos "423"B  ReadPriceType
    let pos, price = ReadOptionalField bs pos "44"B  ReadPrice
    let pos, stopPx = ReadOptionalField bs pos "99"B  ReadStopPx
    let pos, spreadOrBenchmarkCurveData = ReadComponent bs pos "ReadSpreadOrBenchmarkCurveData component" ReadSpreadOrBenchmarkCurveData
    let pos, yieldData = ReadComponent bs pos "ReadYieldData component" ReadYieldData
    let pos, currency = ReadOptionalField bs pos "15"B  ReadCurrency
    let pos, complianceID = ReadOptionalField bs pos "376"B  ReadComplianceID
    let pos, solicitedFlag = ReadOptionalField bs pos "377"B  ReadSolicitedFlag
    let pos, iOIid = ReadOptionalField bs pos "23"B  ReadIOIid
    let pos, quoteID = ReadOptionalField bs pos "117"B  ReadQuoteID
    let pos, timeInForce = ReadOptionalField bs pos "59"B  ReadTimeInForce
    let pos, effectiveTime = ReadOptionalField bs pos "168"B  ReadEffectiveTime
    let pos, expireDate = ReadOptionalField bs pos "432"B  ReadExpireDate
    let pos, expireTime = ReadOptionalField bs pos "126"B  ReadExpireTime
    let pos, gTBookingInst = ReadOptionalField bs pos "427"B  ReadGTBookingInst
    let pos, commissionData = ReadComponent bs pos "ReadCommissionData component" ReadCommissionData
    let pos, orderCapacity = ReadOptionalField bs pos "528"B  ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField bs pos "529"B  ReadOrderRestrictions
    let pos, custOrderCapacity = ReadOptionalField bs pos "582"B  ReadCustOrderCapacity
    let pos, forexReq = ReadOptionalField bs pos "121"B  ReadForexReq
    let pos, settlCurrency = ReadOptionalField bs pos "120"B  ReadSettlCurrency
    let pos, bookingType = ReadOptionalField bs pos "775"B  ReadBookingType
    let pos, text = ReadOptionalField bs pos "58"B  ReadText
    let pos, encodedText = ReadOptionalField bs pos "354"B  ReadEncodedText
    let pos, settlDate2 = ReadOptionalField bs pos "193"B  ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField bs pos "192"B  ReadOrderQty2
    let pos, price2 = ReadOptionalField bs pos "640"B  ReadPrice2
    let pos, positionEffect = ReadOptionalField bs pos "77"B  ReadPositionEffect
    let pos, coveredOrUncovered = ReadOptionalField bs pos "203"B  ReadCoveredOrUncovered
    let pos, maxShow = ReadOptionalField bs pos "210"B  ReadMaxShow
    let pos, pegInstructions = ReadComponent bs pos "ReadPegInstructions component" ReadPegInstructions
    let pos, discretionInstructions = ReadComponent bs pos "ReadDiscretionInstructions component" ReadDiscretionInstructions
    let pos, targetStrategy = ReadOptionalField bs pos "847"B  ReadTargetStrategy
    let pos, targetStrategyParameters = ReadOptionalField bs pos "848"B  ReadTargetStrategyParameters
    let pos, participationRate = ReadOptionalField bs pos "849"B  ReadParticipationRate
    let pos, designation = ReadOptionalField bs pos "494"B  ReadDesignation
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
    pos, ci


// component
let ReadCommissionDataFG (bs:byte []) (pos:int) : int * CommissionDataFG  =
    let pos, commission = ReadField bs pos "ReadCommissionDataFG" "12"B ReadCommission
    let pos, commType = ReadOptionalField bs pos "13"B  ReadCommType
    let pos, commCurrency = ReadOptionalField bs pos "479"B  ReadCommCurrency
    let pos, fundRenewWaiv = ReadOptionalField bs pos "497"B  ReadFundRenewWaiv
    let ci:CommissionDataFG = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    pos, ci


// group
let ReadBidResponseNoBidComponentsGrp (bs:byte []) (pos:int) : int * BidResponseNoBidComponentsGrp  =
    let pos, commissionDataFG = ReadComponent bs pos "ReadCommissionDataFG component" ReadCommissionDataFG
    let pos, listID = ReadOptionalField bs pos "66"B  ReadListID
    let pos, country = ReadOptionalField bs pos "421"B  ReadCountry
    let pos, side = ReadOptionalField bs pos "54"B  ReadSide
    let pos, price = ReadOptionalField bs pos "44"B  ReadPrice
    let pos, priceType = ReadOptionalField bs pos "423"B  ReadPriceType
    let pos, fairValue = ReadOptionalField bs pos "406"B  ReadFairValue
    let pos, netGrossInd = ReadOptionalField bs pos "430"B  ReadNetGrossInd
    let pos, settlType = ReadOptionalField bs pos "63"B  ReadSettlType
    let pos, settlDate = ReadOptionalField bs pos "64"B  ReadSettlDate
    let pos, tradingSessionID = ReadOptionalField bs pos "336"B  ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField bs pos "625"B  ReadTradingSessionSubID
    let pos, text = ReadOptionalField bs pos "58"B  ReadText
    let pos, encodedText = ReadOptionalField bs pos "354"B  ReadEncodedText
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
    pos, ci


// group
let ReadNoLegAllocsGrp (bs:byte []) (pos:int) : int * NoLegAllocsGrp  =
    let pos, legAllocAccount = ReadField bs pos "ReadNoLegAllocs" "671"B ReadLegAllocAccount
    let pos, legIndividualAllocID = ReadOptionalField bs pos "672"B  ReadLegIndividualAllocID
    let pos, noNested2PartyIDsGrp = ReadOptionalGroup bs pos "756"B ReadNoNested2PartyIDsGrp
    let pos, legAllocQty = ReadOptionalField bs pos "673"B  ReadLegAllocQty
    let pos, legAllocAcctIDSource = ReadOptionalField bs pos "674"B  ReadLegAllocAcctIDSource
    let pos, legSettlCurrency = ReadOptionalField bs pos "675"B  ReadLegSettlCurrency
    let ci:NoLegAllocsGrp = {
        LegAllocAccount = legAllocAccount
        LegIndividualAllocID = legIndividualAllocID
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
        LegAllocQty = legAllocQty
        LegAllocAcctIDSource = legAllocAcctIDSource
        LegSettlCurrency = legSettlCurrency
    }
    pos, ci


// group
let ReadMultilegOrderCancelReplaceRequestNoLegsGrp (bs:byte []) (pos:int) : int * MultilegOrderCancelReplaceRequestNoLegsGrp  =
    let pos, instrumentLegFG = ReadComponent bs pos "ReadInstrumentLegFG component" ReadInstrumentLegFG
    let pos, legQty = ReadOptionalField bs pos "687"B  ReadLegQty
    let pos, legSwapType = ReadOptionalField bs pos "690"B  ReadLegSwapType
    let pos, noLegStipulationsGrp = ReadOptionalGroup bs pos "683"B ReadNoLegStipulationsGrp
    let pos, noLegAllocsGrp = ReadOptionalGroup bs pos "670"B ReadNoLegAllocsGrp
    let pos, legPositionEffect = ReadOptionalField bs pos "564"B  ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField bs pos "565"B  ReadLegCoveredOrUncovered
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let pos, legRefID = ReadOptionalField bs pos "654"B  ReadLegRefID
    let pos, legPrice = ReadOptionalField bs pos "566"B  ReadLegPrice
    let pos, legSettlType = ReadOptionalField bs pos "587"B  ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField bs pos "588"B  ReadLegSettlDate
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
    pos, ci


// group
let ReadNoNested3PartySubIDsGrp (bs:byte []) (pos:int) : int * NoNested3PartySubIDsGrp  =
    let pos, nested3PartySubID = ReadField bs pos "ReadNoNested3PartySubIDs" "953"B ReadNested3PartySubID
    let pos, nested3PartySubIDType = ReadOptionalField bs pos "954"B  ReadNested3PartySubIDType
    let ci:NoNested3PartySubIDsGrp = {
        Nested3PartySubID = nested3PartySubID
        Nested3PartySubIDType = nested3PartySubIDType
    }
    pos, ci


// group
let ReadNoNested3PartyIDsGrp (bs:byte []) (pos:int) : int * NoNested3PartyIDsGrp  =
    let pos, nested3PartyID = ReadField bs pos "ReadNoNested3PartyIDs" "949"B ReadNested3PartyID
    let pos, nested3PartyIDSource = ReadOptionalField bs pos "950"B  ReadNested3PartyIDSource
    let pos, nested3PartyRole = ReadOptionalField bs pos "951"B  ReadNested3PartyRole
    let pos, noNested3PartySubIDsGrp = ReadOptionalGroup bs pos "952"B ReadNoNested3PartySubIDsGrp
    let ci:NoNested3PartyIDsGrp = {
        Nested3PartyID = nested3PartyID
        Nested3PartyIDSource = nested3PartyIDSource
        Nested3PartyRole = nested3PartyRole
        NoNested3PartySubIDsGrp = noNested3PartySubIDsGrp
    }
    pos, ci


// group
let ReadMultilegOrderCancelReplaceRequestNoAllocsGrp (bs:byte []) (pos:int) : int * MultilegOrderCancelReplaceRequestNoAllocsGrp  =
    let pos, allocAccount = ReadField bs pos "ReadMultilegOrderCancelReplaceRequestNoAllocs" "79"B ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField bs pos "661"B  ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField bs pos "736"B  ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField bs pos "467"B  ReadIndividualAllocID
    let pos, noNested3PartyIDsGrp = ReadOptionalGroup bs pos "948"B ReadNoNested3PartyIDsGrp
    let pos, allocQty = ReadOptionalField bs pos "80"B  ReadAllocQty
    let ci:MultilegOrderCancelReplaceRequestNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNested3PartyIDsGrp = noNested3PartyIDsGrp
        AllocQty = allocQty
    }
    pos, ci


// group
let ReadNewOrderMultilegNoLegsGrp (bs:byte []) (pos:int) : int * NewOrderMultilegNoLegsGrp  =
    let pos, instrumentLegFG = ReadComponent bs pos "ReadInstrumentLegFG component" ReadInstrumentLegFG
    let pos, legQty = ReadOptionalField bs pos "687"B  ReadLegQty
    let pos, legSwapType = ReadOptionalField bs pos "690"B  ReadLegSwapType
    let pos, noLegStipulationsGrp = ReadOptionalGroup bs pos "683"B ReadNoLegStipulationsGrp
    let pos, noLegAllocsGrp = ReadOptionalGroup bs pos "670"B ReadNoLegAllocsGrp
    let pos, legPositionEffect = ReadOptionalField bs pos "564"B  ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField bs pos "565"B  ReadLegCoveredOrUncovered
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let pos, legRefID = ReadOptionalField bs pos "654"B  ReadLegRefID
    let pos, legPrice = ReadOptionalField bs pos "566"B  ReadLegPrice
    let pos, legSettlType = ReadOptionalField bs pos "587"B  ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField bs pos "588"B  ReadLegSettlDate
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
    pos, ci


// component
let ReadNestedParties2 (bs:byte []) (pos:int) : int * NestedParties2  =
    let pos, noNested2PartyIDsGrp = ReadOptionalGroup bs pos "756"B ReadNoNested2PartyIDsGrp
    let ci:NestedParties2 = {
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
    }
    pos, ci


// group
let ReadNewOrderMultilegNoAllocsGrp (bs:byte []) (pos:int) : int * NewOrderMultilegNoAllocsGrp  =
    let pos, allocAccount = ReadField bs pos "ReadNewOrderMultilegNoAllocs" "79"B ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField bs pos "661"B  ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField bs pos "736"B  ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField bs pos "467"B  ReadIndividualAllocID
    let pos, noNested3PartyIDsGrp = ReadOptionalGroup bs pos "948"B ReadNoNested3PartyIDsGrp
    let pos, allocQty = ReadOptionalField bs pos "80"B  ReadAllocQty
    let ci:NewOrderMultilegNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNested3PartyIDsGrp = noNested3PartyIDsGrp
        AllocQty = allocQty
    }
    pos, ci


// component
let ReadNestedParties3 (bs:byte []) (pos:int) : int * NestedParties3  =
    let pos, noNested3PartyIDsGrp = ReadOptionalGroup bs pos "948"B ReadNoNested3PartyIDsGrp
    let ci:NestedParties3 = {
        NoNested3PartyIDsGrp = noNested3PartyIDsGrp
    }
    pos, ci


// group
let ReadCrossOrderCancelRequestNoSidesGrp (bs:byte []) (pos:int) : int * CrossOrderCancelRequestNoSidesGrp  =
    let pos, side = ReadField bs pos "ReadCrossOrderCancelRequestNoSides" "54"B ReadSide
    let pos, origClOrdID = ReadField bs pos "ReadCrossOrderCancelRequestNoSides" "41"B ReadOrigClOrdID
    let pos, clOrdID = ReadField bs pos "ReadCrossOrderCancelRequestNoSides" "11"B ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField bs pos "526"B  ReadSecondaryClOrdID
    let pos, clOrdLinkID = ReadOptionalField bs pos "583"B  ReadClOrdLinkID
    let pos, origOrdModTime = ReadOptionalField bs pos "586"B  ReadOrigOrdModTime
    let pos, noPartyIDsGrp = ReadOptionalGroup bs pos "453"B ReadNoPartyIDsGrp
    let pos, tradeOriginationDate = ReadOptionalField bs pos "229"B  ReadTradeOriginationDate
    let pos, tradeDate = ReadOptionalField bs pos "75"B  ReadTradeDate
    let pos, orderQtyData = ReadComponent bs pos "ReadOrderQtyData component" ReadOrderQtyData
    let pos, complianceID = ReadOptionalField bs pos "376"B  ReadComplianceID
    let pos, text = ReadOptionalField bs pos "58"B  ReadText
    let pos, encodedText = ReadOptionalField bs pos "354"B  ReadEncodedText
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
    pos, ci


// group
let ReadCrossOrderCancelReplaceRequestNoSidesGrp (bs:byte []) (pos:int) : int * CrossOrderCancelReplaceRequestNoSidesGrp  =
    let pos, side = ReadField bs pos "ReadCrossOrderCancelReplaceRequestNoSides" "54"B ReadSide
    let pos, origClOrdID = ReadField bs pos "ReadCrossOrderCancelReplaceRequestNoSides" "41"B ReadOrigClOrdID
    let pos, clOrdID = ReadField bs pos "ReadCrossOrderCancelReplaceRequestNoSides" "11"B ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField bs pos "526"B  ReadSecondaryClOrdID
    let pos, clOrdLinkID = ReadOptionalField bs pos "583"B  ReadClOrdLinkID
    let pos, origOrdModTime = ReadOptionalField bs pos "586"B  ReadOrigOrdModTime
    let pos, noPartyIDsGrp = ReadOptionalGroup bs pos "453"B ReadNoPartyIDsGrp
    let pos, tradeOriginationDate = ReadOptionalField bs pos "229"B  ReadTradeOriginationDate
    let pos, tradeDate = ReadOptionalField bs pos "75"B  ReadTradeDate
    let pos, account = ReadOptionalField bs pos "1"B  ReadAccount
    let pos, acctIDSource = ReadOptionalField bs pos "660"B  ReadAcctIDSource
    let pos, accountType = ReadOptionalField bs pos "581"B  ReadAccountType
    let pos, dayBookingInst = ReadOptionalField bs pos "589"B  ReadDayBookingInst
    let pos, bookingUnit = ReadOptionalField bs pos "590"B  ReadBookingUnit
    let pos, preallocMethod = ReadOptionalField bs pos "591"B  ReadPreallocMethod
    let pos, allocID = ReadOptionalField bs pos "70"B  ReadAllocID
    let pos, noAllocsGrp = ReadOptionalGroup bs pos "78"B ReadNoAllocsGrp
    let pos, qtyType = ReadOptionalField bs pos "854"B  ReadQtyType
    let pos, orderQtyData = ReadComponent bs pos "ReadOrderQtyData component" ReadOrderQtyData
    let pos, commissionData = ReadComponent bs pos "ReadCommissionData component" ReadCommissionData
    let pos, orderCapacity = ReadOptionalField bs pos "528"B  ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField bs pos "529"B  ReadOrderRestrictions
    let pos, custOrderCapacity = ReadOptionalField bs pos "582"B  ReadCustOrderCapacity
    let pos, forexReq = ReadOptionalField bs pos "121"B  ReadForexReq
    let pos, settlCurrency = ReadOptionalField bs pos "120"B  ReadSettlCurrency
    let pos, bookingType = ReadOptionalField bs pos "775"B  ReadBookingType
    let pos, text = ReadOptionalField bs pos "58"B  ReadText
    let pos, encodedText = ReadOptionalField bs pos "354"B  ReadEncodedText
    let pos, positionEffect = ReadOptionalField bs pos "77"B  ReadPositionEffect
    let pos, coveredOrUncovered = ReadOptionalField bs pos "203"B  ReadCoveredOrUncovered
    let pos, cashMargin = ReadOptionalField bs pos "544"B  ReadCashMargin
    let pos, clearingFeeIndicator = ReadOptionalField bs pos "635"B  ReadClearingFeeIndicator
    let pos, solicitedFlag = ReadOptionalField bs pos "377"B  ReadSolicitedFlag
    let pos, sideComplianceID = ReadOptionalField bs pos "659"B  ReadSideComplianceID
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
    pos, ci


// group
let ReadNoSidesGrp (bs:byte []) (pos:int) : int * NoSidesGrp  =
    let pos, side = ReadField bs pos "ReadNoSides" "54"B ReadSide
    let pos, clOrdID = ReadField bs pos "ReadNoSides" "11"B ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField bs pos "526"B  ReadSecondaryClOrdID
    let pos, clOrdLinkID = ReadOptionalField bs pos "583"B  ReadClOrdLinkID
    let pos, noPartyIDsGrp = ReadOptionalGroup bs pos "453"B ReadNoPartyIDsGrp
    let pos, tradeOriginationDate = ReadOptionalField bs pos "229"B  ReadTradeOriginationDate
    let pos, tradeDate = ReadOptionalField bs pos "75"B  ReadTradeDate
    let pos, account = ReadOptionalField bs pos "1"B  ReadAccount
    let pos, acctIDSource = ReadOptionalField bs pos "660"B  ReadAcctIDSource
    let pos, accountType = ReadOptionalField bs pos "581"B  ReadAccountType
    let pos, dayBookingInst = ReadOptionalField bs pos "589"B  ReadDayBookingInst
    let pos, bookingUnit = ReadOptionalField bs pos "590"B  ReadBookingUnit
    let pos, preallocMethod = ReadOptionalField bs pos "591"B  ReadPreallocMethod
    let pos, allocID = ReadOptionalField bs pos "70"B  ReadAllocID
    let pos, noAllocsGrp = ReadOptionalGroup bs pos "78"B ReadNoAllocsGrp
    let pos, qtyType = ReadOptionalField bs pos "854"B  ReadQtyType
    let pos, orderQtyData = ReadComponent bs pos "ReadOrderQtyData component" ReadOrderQtyData
    let pos, commissionData = ReadComponent bs pos "ReadCommissionData component" ReadCommissionData
    let pos, orderCapacity = ReadOptionalField bs pos "528"B  ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField bs pos "529"B  ReadOrderRestrictions
    let pos, custOrderCapacity = ReadOptionalField bs pos "582"B  ReadCustOrderCapacity
    let pos, forexReq = ReadOptionalField bs pos "121"B  ReadForexReq
    let pos, settlCurrency = ReadOptionalField bs pos "120"B  ReadSettlCurrency
    let pos, bookingType = ReadOptionalField bs pos "775"B  ReadBookingType
    let pos, text = ReadOptionalField bs pos "58"B  ReadText
    let pos, encodedText = ReadOptionalField bs pos "354"B  ReadEncodedText
    let pos, positionEffect = ReadOptionalField bs pos "77"B  ReadPositionEffect
    let pos, coveredOrUncovered = ReadOptionalField bs pos "203"B  ReadCoveredOrUncovered
    let pos, cashMargin = ReadOptionalField bs pos "544"B  ReadCashMargin
    let pos, clearingFeeIndicator = ReadOptionalField bs pos "635"B  ReadClearingFeeIndicator
    let pos, solicitedFlag = ReadOptionalField bs pos "377"B  ReadSolicitedFlag
    let pos, sideComplianceID = ReadOptionalField bs pos "659"B  ReadSideComplianceID
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
    pos, ci


// group
let ReadExecutionReportNoLegsGrp (bs:byte []) (pos:int) : int * ExecutionReportNoLegsGrp  =
    let pos, instrumentLegFG = ReadComponent bs pos "ReadInstrumentLegFG component" ReadInstrumentLegFG
    let pos, legQty = ReadOptionalField bs pos "687"B  ReadLegQty
    let pos, legSwapType = ReadOptionalField bs pos "690"B  ReadLegSwapType
    let pos, noLegStipulationsGrp = ReadOptionalGroup bs pos "683"B ReadNoLegStipulationsGrp
    let pos, legPositionEffect = ReadOptionalField bs pos "564"B  ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField bs pos "565"B  ReadLegCoveredOrUncovered
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let pos, legRefID = ReadOptionalField bs pos "654"B  ReadLegRefID
    let pos, legPrice = ReadOptionalField bs pos "566"B  ReadLegPrice
    let pos, legSettlType = ReadOptionalField bs pos "587"B  ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField bs pos "588"B  ReadLegSettlDate
    let pos, legLastPx = ReadOptionalField bs pos "637"B  ReadLegLastPx
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
    pos, ci


// group
let ReadNoInstrAttribGrp (bs:byte []) (pos:int) : int * NoInstrAttribGrp  =
    let pos, instrAttribType = ReadField bs pos "ReadNoInstrAttrib" "871"B ReadInstrAttribType
    let pos, instrAttribValue = ReadOptionalField bs pos "872"B  ReadInstrAttribValue
    let ci:NoInstrAttribGrp = {
        InstrAttribType = instrAttribType
        InstrAttribValue = instrAttribValue
    }
    pos, ci


// component
let ReadInstrumentExtension (bs:byte []) (pos:int) : int * InstrumentExtension  =
    let pos, deliveryForm = ReadOptionalField bs pos "668"B  ReadDeliveryForm
    let pos, pctAtRisk = ReadOptionalField bs pos "869"B  ReadPctAtRisk
    let pos, noInstrAttribGrp = ReadOptionalGroup bs pos "870"B ReadNoInstrAttribGrp
    let ci:InstrumentExtension = {
        DeliveryForm = deliveryForm
        PctAtRisk = pctAtRisk
        NoInstrAttribGrp = noInstrAttribGrp
    }
    pos, ci


// group
let ReadNoLegsGrp (bs:byte []) (pos:int) : int * NoLegsGrp  =
    let pos, instrumentLegFG = ReadComponent bs pos "ReadInstrumentLegFG component" ReadInstrumentLegFG
    let ci:NoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
    }
    pos, ci


// group
let ReadDerivativeSecurityListNoRelatedSymGrp (bs:byte []) (pos:int) : int * DerivativeSecurityListNoRelatedSymGrp  =
    let pos, instrument = ReadComponent bs pos "ReadInstrument component" ReadInstrument
    let pos, currency = ReadOptionalField bs pos "15"B  ReadCurrency
    let pos, expirationCycle = ReadOptionalField bs pos "827"B  ReadExpirationCycle
    let pos, instrumentExtension = ReadComponent bs pos "ReadInstrumentExtension component" ReadInstrumentExtension
    let pos, noLegsGrp = ReadOptionalGroup bs pos "555"B ReadNoLegsGrp
    let pos, tradingSessionID = ReadOptionalField bs pos "336"B  ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField bs pos "625"B  ReadTradingSessionSubID
    let pos, text = ReadOptionalField bs pos "58"B  ReadText
    let pos, encodedText = ReadOptionalField bs pos "354"B  ReadEncodedText
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
    pos, ci


// component
let ReadFinancingDetails (bs:byte []) (pos:int) : int * FinancingDetails  =
    let pos, agreementDesc = ReadOptionalField bs pos "913"B  ReadAgreementDesc
    let pos, agreementID = ReadOptionalField bs pos "914"B  ReadAgreementID
    let pos, agreementDate = ReadOptionalField bs pos "915"B  ReadAgreementDate
    let pos, agreementCurrency = ReadOptionalField bs pos "918"B  ReadAgreementCurrency
    let pos, terminationType = ReadOptionalField bs pos "788"B  ReadTerminationType
    let pos, startDate = ReadOptionalField bs pos "916"B  ReadStartDate
    let pos, endDate = ReadOptionalField bs pos "917"B  ReadEndDate
    let pos, deliveryType = ReadOptionalField bs pos "919"B  ReadDeliveryType
    let pos, marginRatio = ReadOptionalField bs pos "898"B  ReadMarginRatio
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
    pos, ci


// component
let ReadLegBenchmarkCurveData (bs:byte []) (pos:int) : int * LegBenchmarkCurveData  =
    let pos, legBenchmarkCurveCurrency = ReadOptionalField bs pos "676"B  ReadLegBenchmarkCurveCurrency
    let pos, legBenchmarkCurveName = ReadOptionalField bs pos "677"B  ReadLegBenchmarkCurveName
    let pos, legBenchmarkCurvePoint = ReadOptionalField bs pos "678"B  ReadLegBenchmarkCurvePoint
    let pos, legBenchmarkPrice = ReadOptionalField bs pos "679"B  ReadLegBenchmarkPrice
    let pos, legBenchmarkPriceType = ReadOptionalField bs pos "680"B  ReadLegBenchmarkPriceType
    let ci:LegBenchmarkCurveData = {
        LegBenchmarkCurveCurrency = legBenchmarkCurveCurrency
        LegBenchmarkCurveName = legBenchmarkCurveName
        LegBenchmarkCurvePoint = legBenchmarkCurvePoint
        LegBenchmarkPrice = legBenchmarkPrice
        LegBenchmarkPriceType = legBenchmarkPriceType
    }
    pos, ci


// group
let ReadSecurityListNoLegsGrp (bs:byte []) (pos:int) : int * SecurityListNoLegsGrp  =
    let pos, instrumentLegFG = ReadComponent bs pos "ReadInstrumentLegFG component" ReadInstrumentLegFG
    let pos, legSwapType = ReadOptionalField bs pos "690"B  ReadLegSwapType
    let pos, legSettlType = ReadOptionalField bs pos "587"B  ReadLegSettlType
    let pos, noLegStipulationsGrp = ReadOptionalGroup bs pos "683"B ReadNoLegStipulationsGrp
    let pos, legBenchmarkCurveData = ReadComponent bs pos "ReadLegBenchmarkCurveData component" ReadLegBenchmarkCurveData
    let ci:SecurityListNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        NoLegStipulationsGrp = noLegStipulationsGrp
        LegBenchmarkCurveData = legBenchmarkCurveData
    }
    pos, ci


// group
let ReadSecurityListNoRelatedSymGrp (bs:byte []) (pos:int) : int * SecurityListNoRelatedSymGrp  =
    let pos, instrument = ReadComponent bs pos "ReadInstrument component" ReadInstrument
    let pos, instrumentExtension = ReadComponent bs pos "ReadInstrumentExtension component" ReadInstrumentExtension
    let pos, financingDetails = ReadComponent bs pos "ReadFinancingDetails component" ReadFinancingDetails
    let pos, noUnderlyingsGrp = ReadOptionalGroup bs pos "711"B ReadNoUnderlyingsGrp
    let pos, currency = ReadOptionalField bs pos "15"B  ReadCurrency
    let pos, noStipulationsGrp = ReadOptionalGroup bs pos "232"B ReadNoStipulationsGrp
    let pos, securityListNoLegsGrp = ReadOptionalGroup bs pos "555"B ReadSecurityListNoLegsGrp
    let pos, spreadOrBenchmarkCurveData = ReadComponent bs pos "ReadSpreadOrBenchmarkCurveData component" ReadSpreadOrBenchmarkCurveData
    let pos, yieldData = ReadComponent bs pos "ReadYieldData component" ReadYieldData
    let pos, roundLot = ReadOptionalField bs pos "561"B  ReadRoundLot
    let pos, minTradeVol = ReadOptionalField bs pos "562"B  ReadMinTradeVol
    let pos, tradingSessionID = ReadOptionalField bs pos "336"B  ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField bs pos "625"B  ReadTradingSessionSubID
    let pos, expirationCycle = ReadOptionalField bs pos "827"B  ReadExpirationCycle
    let pos, text = ReadOptionalField bs pos "58"B  ReadText
    let pos, encodedText = ReadOptionalField bs pos "354"B  ReadEncodedText
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
    pos, ci


// group
let ReadMarketDataIncrementalRefreshNoMDEntriesGrp (bs:byte []) (pos:int) : int * MarketDataIncrementalRefreshNoMDEntriesGrp  =
    let pos, mDUpdateAction = ReadField bs pos "ReadMarketDataIncrementalRefreshNoMDEntries" "279"B ReadMDUpdateAction
    let pos, deleteReason = ReadOptionalField bs pos "285"B  ReadDeleteReason
    let pos, mDEntryType = ReadOptionalField bs pos "269"B  ReadMDEntryType
    let pos, mDEntryID = ReadOptionalField bs pos "278"B  ReadMDEntryID
    let pos, mDEntryRefID = ReadOptionalField bs pos "280"B  ReadMDEntryRefID
    let pos, instrument = ReadOptionalComponent bs pos "55"B ReadInstrument
    let pos, noUnderlyingsGrp = ReadOptionalGroup bs pos "711"B ReadNoUnderlyingsGrp
    let pos, noLegsGrp = ReadOptionalGroup bs pos "555"B ReadNoLegsGrp
    let pos, financialStatus = ReadOptionalField bs pos "291"B  ReadFinancialStatus
    let pos, corporateAction = ReadOptionalField bs pos "292"B  ReadCorporateAction
    let pos, mDEntryPx = ReadOptionalField bs pos "270"B  ReadMDEntryPx
    let pos, currency = ReadOptionalField bs pos "15"B  ReadCurrency
    let pos, mDEntrySize = ReadOptionalField bs pos "271"B  ReadMDEntrySize
    let pos, mDEntryDate = ReadOptionalField bs pos "272"B  ReadMDEntryDate
    let pos, mDEntryTime = ReadOptionalField bs pos "273"B  ReadMDEntryTime
    let pos, tickDirection = ReadOptionalField bs pos "274"B  ReadTickDirection
    let pos, mDMkt = ReadOptionalField bs pos "275"B  ReadMDMkt
    let pos, tradingSessionID = ReadOptionalField bs pos "336"B  ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField bs pos "625"B  ReadTradingSessionSubID
    let pos, quoteCondition = ReadOptionalField bs pos "276"B  ReadQuoteCondition
    let pos, tradeCondition = ReadOptionalField bs pos "277"B  ReadTradeCondition
    let pos, mDEntryOriginator = ReadOptionalField bs pos "282"B  ReadMDEntryOriginator
    let pos, locationID = ReadOptionalField bs pos "283"B  ReadLocationID
    let pos, deskID = ReadOptionalField bs pos "284"B  ReadDeskID
    let pos, openCloseSettlFlag = ReadOptionalField bs pos "286"B  ReadOpenCloseSettlFlag
    let pos, timeInForce = ReadOptionalField bs pos "59"B  ReadTimeInForce
    let pos, expireDate = ReadOptionalField bs pos "432"B  ReadExpireDate
    let pos, expireTime = ReadOptionalField bs pos "126"B  ReadExpireTime
    let pos, minQty = ReadOptionalField bs pos "110"B  ReadMinQty
    let pos, execInst = ReadOptionalField bs pos "18"B  ReadExecInst
    let pos, sellerDays = ReadOptionalField bs pos "287"B  ReadSellerDays
    let pos, orderID = ReadOptionalField bs pos "37"B  ReadOrderID
    let pos, quoteEntryID = ReadOptionalField bs pos "299"B  ReadQuoteEntryID
    let pos, mDEntryBuyer = ReadOptionalField bs pos "288"B  ReadMDEntryBuyer
    let pos, mDEntrySeller = ReadOptionalField bs pos "289"B  ReadMDEntrySeller
    let pos, numberOfOrders = ReadOptionalField bs pos "346"B  ReadNumberOfOrders
    let pos, mDEntryPositionNo = ReadOptionalField bs pos "290"B  ReadMDEntryPositionNo
    let pos, scope = ReadOptionalField bs pos "546"B  ReadScope
    let pos, priceDelta = ReadOptionalField bs pos "811"B  ReadPriceDelta
    let pos, netChgPrevDay = ReadOptionalField bs pos "451"B  ReadNetChgPrevDay
    let pos, text = ReadOptionalField bs pos "58"B  ReadText
    let pos, encodedText = ReadOptionalField bs pos "354"B  ReadEncodedText
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
    pos, ci


// group
let ReadMarketDataRequestNoRelatedSymGrp (bs:byte []) (pos:int) : int * MarketDataRequestNoRelatedSymGrp  =
    let pos, instrument = ReadComponent bs pos "ReadInstrument component" ReadInstrument
    let pos, noUnderlyingsGrp = ReadOptionalGroup bs pos "711"B ReadNoUnderlyingsGrp
    let pos, noLegsGrp = ReadOptionalGroup bs pos "555"B ReadNoLegsGrp
    let ci:MarketDataRequestNoRelatedSymGrp = {
        Instrument = instrument
        NoUnderlyingsGrp = noUnderlyingsGrp
        NoLegsGrp = noLegsGrp
    }
    pos, ci


// group
let ReadMassQuoteAcknowledgementNoQuoteEntriesGrp (bs:byte []) (pos:int) : int * MassQuoteAcknowledgementNoQuoteEntriesGrp  =
    let pos, quoteEntryID = ReadField bs pos "ReadMassQuoteAcknowledgementNoQuoteEntries" "299"B ReadQuoteEntryID
    let pos, instrument = ReadOptionalComponent bs pos "55"B ReadInstrument
    let pos, noLegsGrp = ReadOptionalGroup bs pos "555"B ReadNoLegsGrp
    let pos, bidPx = ReadOptionalField bs pos "132"B  ReadBidPx
    let pos, offerPx = ReadOptionalField bs pos "133"B  ReadOfferPx
    let pos, bidSize = ReadOptionalField bs pos "134"B  ReadBidSize
    let pos, offerSize = ReadOptionalField bs pos "135"B  ReadOfferSize
    let pos, validUntilTime = ReadOptionalField bs pos "62"B  ReadValidUntilTime
    let pos, bidSpotRate = ReadOptionalField bs pos "188"B  ReadBidSpotRate
    let pos, offerSpotRate = ReadOptionalField bs pos "190"B  ReadOfferSpotRate
    let pos, bidForwardPoints = ReadOptionalField bs pos "189"B  ReadBidForwardPoints
    let pos, offerForwardPoints = ReadOptionalField bs pos "191"B  ReadOfferForwardPoints
    let pos, midPx = ReadOptionalField bs pos "631"B  ReadMidPx
    let pos, bidYield = ReadOptionalField bs pos "632"B  ReadBidYield
    let pos, midYield = ReadOptionalField bs pos "633"B  ReadMidYield
    let pos, offerYield = ReadOptionalField bs pos "634"B  ReadOfferYield
    let pos, transactTime = ReadOptionalField bs pos "60"B  ReadTransactTime
    let pos, tradingSessionID = ReadOptionalField bs pos "336"B  ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField bs pos "625"B  ReadTradingSessionSubID
    let pos, settlDate = ReadOptionalField bs pos "64"B  ReadSettlDate
    let pos, ordType = ReadOptionalField bs pos "40"B  ReadOrdType
    let pos, settlDate2 = ReadOptionalField bs pos "193"B  ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField bs pos "192"B  ReadOrderQty2
    let pos, bidForwardPoints2 = ReadOptionalField bs pos "642"B  ReadBidForwardPoints2
    let pos, offerForwardPoints2 = ReadOptionalField bs pos "643"B  ReadOfferForwardPoints2
    let pos, currency = ReadOptionalField bs pos "15"B  ReadCurrency
    let pos, quoteEntryRejectReason = ReadOptionalField bs pos "368"B  ReadQuoteEntryRejectReason
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
    pos, ci


// group
let ReadMassQuoteAcknowledgementNoQuoteSetsGrp (bs:byte []) (pos:int) : int * MassQuoteAcknowledgementNoQuoteSetsGrp  =
    let pos, quoteSetID = ReadField bs pos "ReadMassQuoteAcknowledgementNoQuoteSets" "302"B ReadQuoteSetID
    let pos, underlyingInstrument = ReadOptionalComponent bs pos "311"B ReadUnderlyingInstrument
    let pos, totNoQuoteEntries = ReadOptionalField bs pos "304"B  ReadTotNoQuoteEntries
    let pos, lastFragment = ReadOptionalField bs pos "893"B  ReadLastFragment
    let pos, massQuoteAcknowledgementNoQuoteEntriesGrp = ReadOptionalGroup bs pos "295"B ReadMassQuoteAcknowledgementNoQuoteEntriesGrp
    let ci:MassQuoteAcknowledgementNoQuoteSetsGrp = {
        QuoteSetID = quoteSetID
        UnderlyingInstrument = underlyingInstrument
        TotNoQuoteEntries = totNoQuoteEntries
        LastFragment = lastFragment
        MassQuoteAcknowledgementNoQuoteEntriesGrp = massQuoteAcknowledgementNoQuoteEntriesGrp
    }
    pos, ci


// group
let ReadMassQuoteNoQuoteEntriesGrp (bs:byte []) (pos:int) : int * MassQuoteNoQuoteEntriesGrp  =
    let pos, quoteEntryID = ReadField bs pos "ReadMassQuoteNoQuoteEntries" "299"B ReadQuoteEntryID
    let pos, instrument = ReadOptionalComponent bs pos "55"B ReadInstrument
    let pos, noLegsGrp = ReadOptionalGroup bs pos "555"B ReadNoLegsGrp
    let pos, bidPx = ReadOptionalField bs pos "132"B  ReadBidPx
    let pos, offerPx = ReadOptionalField bs pos "133"B  ReadOfferPx
    let pos, bidSize = ReadOptionalField bs pos "134"B  ReadBidSize
    let pos, offerSize = ReadOptionalField bs pos "135"B  ReadOfferSize
    let pos, validUntilTime = ReadOptionalField bs pos "62"B  ReadValidUntilTime
    let pos, bidSpotRate = ReadOptionalField bs pos "188"B  ReadBidSpotRate
    let pos, offerSpotRate = ReadOptionalField bs pos "190"B  ReadOfferSpotRate
    let pos, bidForwardPoints = ReadOptionalField bs pos "189"B  ReadBidForwardPoints
    let pos, offerForwardPoints = ReadOptionalField bs pos "191"B  ReadOfferForwardPoints
    let pos, midPx = ReadOptionalField bs pos "631"B  ReadMidPx
    let pos, bidYield = ReadOptionalField bs pos "632"B  ReadBidYield
    let pos, midYield = ReadOptionalField bs pos "633"B  ReadMidYield
    let pos, offerYield = ReadOptionalField bs pos "634"B  ReadOfferYield
    let pos, transactTime = ReadOptionalField bs pos "60"B  ReadTransactTime
    let pos, tradingSessionID = ReadOptionalField bs pos "336"B  ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField bs pos "625"B  ReadTradingSessionSubID
    let pos, settlDate = ReadOptionalField bs pos "64"B  ReadSettlDate
    let pos, ordType = ReadOptionalField bs pos "40"B  ReadOrdType
    let pos, settlDate2 = ReadOptionalField bs pos "193"B  ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField bs pos "192"B  ReadOrderQty2
    let pos, bidForwardPoints2 = ReadOptionalField bs pos "642"B  ReadBidForwardPoints2
    let pos, offerForwardPoints2 = ReadOptionalField bs pos "643"B  ReadOfferForwardPoints2
    let pos, currency = ReadOptionalField bs pos "15"B  ReadCurrency
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
    pos, ci


// group
let ReadNoQuoteSetsGrp (bs:byte []) (pos:int) : int * NoQuoteSetsGrp  =
    let pos, quoteSetID = ReadField bs pos "ReadNoQuoteSets" "302"B ReadQuoteSetID
    let pos, underlyingInstrument = ReadOptionalComponent bs pos "311"B ReadUnderlyingInstrument
    let pos, quoteSetValidUntilTime = ReadOptionalField bs pos "367"B  ReadQuoteSetValidUntilTime
    let pos, totNoQuoteEntries = ReadField bs pos "ReadNoQuoteSets" "304"B ReadTotNoQuoteEntries
    let pos, lastFragment = ReadOptionalField bs pos "893"B  ReadLastFragment
    let pos, massQuoteNoQuoteEntriesGrp = ReadGroup bs pos "ReadNoQuoteSets" "295"B ReadMassQuoteNoQuoteEntriesGrp
    let ci:NoQuoteSetsGrp = {
        QuoteSetID = quoteSetID
        UnderlyingInstrument = underlyingInstrument
        QuoteSetValidUntilTime = quoteSetValidUntilTime
        TotNoQuoteEntries = totNoQuoteEntries
        LastFragment = lastFragment
        MassQuoteNoQuoteEntriesGrp = massQuoteNoQuoteEntriesGrp
    }
    pos, ci


// group
let ReadQuoteStatusReportNoLegsGrp (bs:byte []) (pos:int) : int * QuoteStatusReportNoLegsGrp  =
    let pos, instrumentLegFG = ReadComponent bs pos "ReadInstrumentLegFG component" ReadInstrumentLegFG
    let pos, legQty = ReadOptionalField bs pos "687"B  ReadLegQty
    let pos, legSwapType = ReadOptionalField bs pos "690"B  ReadLegSwapType
    let pos, legSettlType = ReadOptionalField bs pos "587"B  ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField bs pos "588"B  ReadLegSettlDate
    let pos, noLegStipulationsGrp = ReadOptionalGroup bs pos "683"B ReadNoLegStipulationsGrp
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let ci:QuoteStatusReportNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
    }
    pos, ci


// group
let ReadNoQuoteEntriesGrp (bs:byte []) (pos:int) : int * NoQuoteEntriesGrp  =
    let pos, instrument = ReadComponent bs pos "ReadInstrument component" ReadInstrument
    let pos, financingDetails = ReadComponent bs pos "ReadFinancingDetails component" ReadFinancingDetails
    let pos, noUnderlyingsGrp = ReadOptionalGroup bs pos "711"B ReadNoUnderlyingsGrp
    let pos, noLegsGrp = ReadOptionalGroup bs pos "555"B ReadNoLegsGrp
    let ci:NoQuoteEntriesGrp = {
        Instrument = instrument
        FinancingDetails = financingDetails
        NoUnderlyingsGrp = noUnderlyingsGrp
        NoLegsGrp = noLegsGrp
    }
    pos, ci


// group
let ReadQuoteNoLegsGrp (bs:byte []) (pos:int) : int * QuoteNoLegsGrp  =
    let pos, instrumentLegFG = ReadComponent bs pos "ReadInstrumentLegFG component" ReadInstrumentLegFG
    let pos, legQty = ReadOptionalField bs pos "687"B  ReadLegQty
    let pos, legSwapType = ReadOptionalField bs pos "690"B  ReadLegSwapType
    let pos, legSettlType = ReadOptionalField bs pos "587"B  ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField bs pos "588"B  ReadLegSettlDate
    let pos, noLegStipulationsGrp = ReadOptionalGroup bs pos "683"B ReadNoLegStipulationsGrp
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let pos, legPriceType = ReadOptionalField bs pos "686"B  ReadLegPriceType
    let pos, legBidPx = ReadOptionalField bs pos "681"B  ReadLegBidPx
    let pos, legOfferPx = ReadOptionalField bs pos "684"B  ReadLegOfferPx
    let pos, legBenchmarkCurveData = ReadComponent bs pos "ReadLegBenchmarkCurveData component" ReadLegBenchmarkCurveData
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
    pos, ci


// group
let ReadRFQRequestNoRelatedSymGrp (bs:byte []) (pos:int) : int * RFQRequestNoRelatedSymGrp  =
    let pos, instrument = ReadComponent bs pos "ReadInstrument component" ReadInstrument
    let pos, noUnderlyingsGrp = ReadOptionalGroup bs pos "711"B ReadNoUnderlyingsGrp
    let pos, noLegsGrp = ReadOptionalGroup bs pos "555"B ReadNoLegsGrp
    let pos, prevClosePx = ReadOptionalField bs pos "140"B  ReadPrevClosePx
    let pos, quoteRequestType = ReadOptionalField bs pos "303"B  ReadQuoteRequestType
    let pos, quoteType = ReadOptionalField bs pos "537"B  ReadQuoteType
    let pos, tradingSessionID = ReadOptionalField bs pos "336"B  ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField bs pos "625"B  ReadTradingSessionSubID
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
    pos, ci


// group
let ReadQuoteRequestRejectNoLegsGrp (bs:byte []) (pos:int) : int * QuoteRequestRejectNoLegsGrp  =
    let pos, instrumentLegFG = ReadComponent bs pos "ReadInstrumentLegFG component" ReadInstrumentLegFG
    let pos, legQty = ReadOptionalField bs pos "687"B  ReadLegQty
    let pos, legSwapType = ReadOptionalField bs pos "690"B  ReadLegSwapType
    let pos, legSettlType = ReadOptionalField bs pos "587"B  ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField bs pos "588"B  ReadLegSettlDate
    let pos, noLegStipulationsGrp = ReadOptionalGroup bs pos "683"B ReadNoLegStipulationsGrp
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let pos, legBenchmarkCurveData = ReadComponent bs pos "ReadLegBenchmarkCurveData component" ReadLegBenchmarkCurveData
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
    pos, ci


// group
let ReadQuoteRequestRejectNoRelatedSymGrp (bs:byte []) (pos:int) : int * QuoteRequestRejectNoRelatedSymGrp  =
    let pos, instrument = ReadComponent bs pos "ReadInstrument component" ReadInstrument
    let pos, financingDetails = ReadComponent bs pos "ReadFinancingDetails component" ReadFinancingDetails
    let pos, noUnderlyingsGrp = ReadOptionalGroup bs pos "711"B ReadNoUnderlyingsGrp
    let pos, prevClosePx = ReadOptionalField bs pos "140"B  ReadPrevClosePx
    let pos, quoteRequestType = ReadOptionalField bs pos "303"B  ReadQuoteRequestType
    let pos, quoteType = ReadOptionalField bs pos "537"B  ReadQuoteType
    let pos, tradingSessionID = ReadOptionalField bs pos "336"B  ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField bs pos "625"B  ReadTradingSessionSubID
    let pos, tradeOriginationDate = ReadOptionalField bs pos "229"B  ReadTradeOriginationDate
    let pos, side = ReadOptionalField bs pos "54"B  ReadSide
    let pos, qtyType = ReadOptionalField bs pos "854"B  ReadQtyType
    let pos, orderQtyData = ReadComponent bs pos "ReadOrderQtyData component" ReadOrderQtyData
    let pos, settlType = ReadOptionalField bs pos "63"B  ReadSettlType
    let pos, settlDate = ReadOptionalField bs pos "64"B  ReadSettlDate
    let pos, settlDate2 = ReadOptionalField bs pos "193"B  ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField bs pos "192"B  ReadOrderQty2
    let pos, currency = ReadOptionalField bs pos "15"B  ReadCurrency
    let pos, noStipulationsGrp = ReadOptionalGroup bs pos "232"B ReadNoStipulationsGrp
    let pos, account = ReadOptionalField bs pos "1"B  ReadAccount
    let pos, acctIDSource = ReadOptionalField bs pos "660"B  ReadAcctIDSource
    let pos, accountType = ReadOptionalField bs pos "581"B  ReadAccountType
    let pos, quoteRequestRejectNoLegsGrp = ReadOptionalGroup bs pos "555"B ReadQuoteRequestRejectNoLegsGrp
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
    pos, ci


// group
let ReadQuoteResponseNoLegsGrp (bs:byte []) (pos:int) : int * QuoteResponseNoLegsGrp  =
    let pos, instrumentLegFG = ReadComponent bs pos "ReadInstrumentLegFG component" ReadInstrumentLegFG
    let pos, legQty = ReadOptionalField bs pos "687"B  ReadLegQty
    let pos, legSwapType = ReadOptionalField bs pos "690"B  ReadLegSwapType
    let pos, legSettlType = ReadOptionalField bs pos "587"B  ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField bs pos "588"B  ReadLegSettlDate
    let pos, noLegStipulationsGrp = ReadOptionalGroup bs pos "683"B ReadNoLegStipulationsGrp
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let pos, legPriceType = ReadOptionalField bs pos "686"B  ReadLegPriceType
    let pos, legBidPx = ReadOptionalField bs pos "681"B  ReadLegBidPx
    let pos, legOfferPx = ReadOptionalField bs pos "684"B  ReadLegOfferPx
    let pos, legBenchmarkCurveData = ReadComponent bs pos "ReadLegBenchmarkCurveData component" ReadLegBenchmarkCurveData
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
    pos, ci


// group
let ReadQuoteRequestNoLegsGrp (bs:byte []) (pos:int) : int * QuoteRequestNoLegsGrp  =
    let pos, instrumentLegFG = ReadComponent bs pos "ReadInstrumentLegFG component" ReadInstrumentLegFG
    let pos, legQty = ReadOptionalField bs pos "687"B  ReadLegQty
    let pos, legSwapType = ReadOptionalField bs pos "690"B  ReadLegSwapType
    let pos, legSettlType = ReadOptionalField bs pos "587"B  ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField bs pos "588"B  ReadLegSettlDate
    let pos, noLegStipulationsGrp = ReadOptionalGroup bs pos "683"B ReadNoLegStipulationsGrp
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let pos, legBenchmarkCurveData = ReadComponent bs pos "ReadLegBenchmarkCurveData component" ReadLegBenchmarkCurveData
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
    pos, ci


// group
let ReadNoQuoteQualifiersGrp (bs:byte []) (pos:int) : int * NoQuoteQualifiersGrp  =
    let pos, quoteQualifier = ReadField bs pos "ReadNoQuoteQualifiers" "695"B ReadQuoteQualifier
    let ci:NoQuoteQualifiersGrp = {
        QuoteQualifier = quoteQualifier
    }
    pos, ci


// group
let ReadQuoteRequestNoRelatedSymGrp (bs:byte []) (pos:int) : int * QuoteRequestNoRelatedSymGrp  =
    let pos, instrument = ReadComponent bs pos "ReadInstrument component" ReadInstrument
    let pos, financingDetails = ReadComponent bs pos "ReadFinancingDetails component" ReadFinancingDetails
    let pos, noUnderlyingsGrp = ReadOptionalGroup bs pos "711"B ReadNoUnderlyingsGrp
    let pos, prevClosePx = ReadOptionalField bs pos "140"B  ReadPrevClosePx
    let pos, quoteRequestType = ReadOptionalField bs pos "303"B  ReadQuoteRequestType
    let pos, quoteType = ReadOptionalField bs pos "537"B  ReadQuoteType
    let pos, tradingSessionID = ReadOptionalField bs pos "336"B  ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField bs pos "625"B  ReadTradingSessionSubID
    let pos, tradeOriginationDate = ReadOptionalField bs pos "229"B  ReadTradeOriginationDate
    let pos, side = ReadOptionalField bs pos "54"B  ReadSide
    let pos, qtyType = ReadOptionalField bs pos "854"B  ReadQtyType
    let pos, orderQtyData = ReadComponent bs pos "ReadOrderQtyData component" ReadOrderQtyData
    let pos, settlType = ReadOptionalField bs pos "63"B  ReadSettlType
    let pos, settlDate = ReadOptionalField bs pos "64"B  ReadSettlDate
    let pos, settlDate2 = ReadOptionalField bs pos "193"B  ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField bs pos "192"B  ReadOrderQty2
    let pos, currency = ReadOptionalField bs pos "15"B  ReadCurrency
    let pos, noStipulationsGrp = ReadOptionalGroup bs pos "232"B ReadNoStipulationsGrp
    let pos, account = ReadOptionalField bs pos "1"B  ReadAccount
    let pos, acctIDSource = ReadOptionalField bs pos "660"B  ReadAcctIDSource
    let pos, accountType = ReadOptionalField bs pos "581"B  ReadAccountType
    let pos, quoteRequestNoLegsGrp = ReadOptionalGroup bs pos "555"B ReadQuoteRequestNoLegsGrp
    let pos, noQuoteQualifiersGrp = ReadOptionalGroup bs pos "735"B ReadNoQuoteQualifiersGrp
    let pos, quotePriceType = ReadOptionalField bs pos "692"B  ReadQuotePriceType
    let pos, ordType = ReadOptionalField bs pos "40"B  ReadOrdType
    let pos, validUntilTime = ReadOptionalField bs pos "62"B  ReadValidUntilTime
    let pos, expireTime = ReadOptionalField bs pos "126"B  ReadExpireTime
    let pos, transactTime = ReadOptionalField bs pos "60"B  ReadTransactTime
    let pos, spreadOrBenchmarkCurveData = ReadComponent bs pos "ReadSpreadOrBenchmarkCurveData component" ReadSpreadOrBenchmarkCurveData
    let pos, priceType = ReadOptionalField bs pos "423"B  ReadPriceType
    let pos, price = ReadOptionalField bs pos "44"B  ReadPrice
    let pos, price2 = ReadOptionalField bs pos "640"B  ReadPrice2
    let pos, yieldData = ReadComponent bs pos "ReadYieldData component" ReadYieldData
    let pos, noPartyIDsGrp = ReadOptionalGroup bs pos "453"B ReadNoPartyIDsGrp
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
    pos, ci


// component
let ReadParties (bs:byte []) (pos:int) : int * Parties  =
    let pos, noPartyIDsGrp = ReadOptionalGroup bs pos "453"B ReadNoPartyIDsGrp
    let ci:Parties = {
        NoPartyIDsGrp = noPartyIDsGrp
    }
    pos, ci


// component
let ReadNestedParties (bs:byte []) (pos:int) : int * NestedParties  =
    let pos, noNestedPartyIDsGrp = ReadOptionalGroup bs pos "539"B ReadNoNestedPartyIDsGrp
    let ci:NestedParties = {
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
    }
    pos, ci


// group
let ReadNoRelatedSymGrp (bs:byte []) (pos:int) : int * NoRelatedSymGrp  =
    let pos, instrument = ReadComponent bs pos "ReadInstrument component" ReadInstrument
    let ci:NoRelatedSymGrp = {
        Instrument = instrument
    }
    pos, ci


// group
let ReadIndicationOfInterestNoLegsGrp (bs:byte []) (pos:int) : int * IndicationOfInterestNoLegsGrp  =
    let pos, instrumentLegFG = ReadComponent bs pos "ReadInstrumentLegFG component" ReadInstrumentLegFG
    let pos, legIOIQty = ReadOptionalField bs pos "682"B  ReadLegIOIQty
    let pos, noLegStipulationsGrp = ReadOptionalGroup bs pos "683"B ReadNoLegStipulationsGrp
    let ci:IndicationOfInterestNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegIOIQty = legIOIQty
        NoLegStipulationsGrp = noLegStipulationsGrp
    }
    pos, ci


// component
let ReadLegStipulations (bs:byte []) (pos:int) : int * LegStipulations  =
    let pos, noLegStipulationsGrp = ReadOptionalGroup bs pos "683"B ReadNoLegStipulationsGrp
    let ci:LegStipulations = {
        NoLegStipulationsGrp = noLegStipulationsGrp
    }
    pos, ci


// component
let ReadStipulations (bs:byte []) (pos:int) : int * Stipulations  =
    let pos, noStipulationsGrp = ReadOptionalGroup bs pos "232"B ReadNoStipulationsGrp
    let ci:Stipulations = {
        NoStipulationsGrp = noStipulationsGrp
    }
    pos, ci


// group
let ReadAdvertisementNoUnderlyingsGrp (bs:byte []) (pos:int) : int * AdvertisementNoUnderlyingsGrp  =
    let pos, underlyingInstrument = ReadComponent bs pos "ReadUnderlyingInstrument component" ReadUnderlyingInstrument
    let ci:AdvertisementNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
    }
    pos, ci


// component
let ReadUnderlyingStipulations (bs:byte []) (pos:int) : int * UnderlyingStipulations  =
    let pos, noUnderlyingStipsGrp = ReadOptionalGroup bs pos "887"B ReadNoUnderlyingStipsGrp
    let ci:UnderlyingStipulations = {
        NoUnderlyingStipsGrp = noUnderlyingStipsGrp
    }
    pos, ci


// component
let ReadInstrumentLeg (bs:byte []) (pos:int) : int * InstrumentLeg  =
    let pos, legSymbol = ReadOptionalField bs pos "600"B  ReadLegSymbol
    let pos, legSymbolSfx = ReadOptionalField bs pos "601"B  ReadLegSymbolSfx
    let pos, legSecurityID = ReadOptionalField bs pos "602"B  ReadLegSecurityID
    let pos, legSecurityIDSource = ReadOptionalField bs pos "603"B  ReadLegSecurityIDSource
    let pos, noLegSecurityAltIDGrp = ReadOptionalGroup bs pos "604"B ReadNoLegSecurityAltIDGrp
    let pos, legProduct = ReadOptionalField bs pos "607"B  ReadLegProduct
    let pos, legCFICode = ReadOptionalField bs pos "608"B  ReadLegCFICode
    let pos, legSecurityType = ReadOptionalField bs pos "609"B  ReadLegSecurityType
    let pos, legSecuritySubType = ReadOptionalField bs pos "764"B  ReadLegSecuritySubType
    let pos, legMaturityMonthYear = ReadOptionalField bs pos "610"B  ReadLegMaturityMonthYear
    let pos, legMaturityDate = ReadOptionalField bs pos "611"B  ReadLegMaturityDate
    let pos, legCouponPaymentDate = ReadOptionalField bs pos "248"B  ReadLegCouponPaymentDate
    let pos, legIssueDate = ReadOptionalField bs pos "249"B  ReadLegIssueDate
    let pos, legRepoCollateralSecurityType = ReadOptionalField bs pos "250"B  ReadLegRepoCollateralSecurityType
    let pos, legRepurchaseTerm = ReadOptionalField bs pos "251"B  ReadLegRepurchaseTerm
    let pos, legRepurchaseRate = ReadOptionalField bs pos "252"B  ReadLegRepurchaseRate
    let pos, legFactor = ReadOptionalField bs pos "253"B  ReadLegFactor
    let pos, legCreditRating = ReadOptionalField bs pos "257"B  ReadLegCreditRating
    let pos, legInstrRegistry = ReadOptionalField bs pos "599"B  ReadLegInstrRegistry
    let pos, legCountryOfIssue = ReadOptionalField bs pos "596"B  ReadLegCountryOfIssue
    let pos, legStateOrProvinceOfIssue = ReadOptionalField bs pos "597"B  ReadLegStateOrProvinceOfIssue
    let pos, legLocaleOfIssue = ReadOptionalField bs pos "598"B  ReadLegLocaleOfIssue
    let pos, legRedemptionDate = ReadOptionalField bs pos "254"B  ReadLegRedemptionDate
    let pos, legStrikePrice = ReadOptionalField bs pos "612"B  ReadLegStrikePrice
    let pos, legStrikeCurrency = ReadOptionalField bs pos "942"B  ReadLegStrikeCurrency
    let pos, legOptAttribute = ReadOptionalField bs pos "613"B  ReadLegOptAttribute
    let pos, legContractMultiplier = ReadOptionalField bs pos "614"B  ReadLegContractMultiplier
    let pos, legCouponRate = ReadOptionalField bs pos "615"B  ReadLegCouponRate
    let pos, legSecurityExchange = ReadOptionalField bs pos "616"B  ReadLegSecurityExchange
    let pos, legIssuer = ReadOptionalField bs pos "617"B  ReadLegIssuer
    let pos, encodedLegIssuer = ReadOptionalField bs pos "618"B  ReadEncodedLegIssuer
    let pos, legSecurityDesc = ReadOptionalField bs pos "620"B  ReadLegSecurityDesc
    let pos, encodedLegSecurityDesc = ReadOptionalField bs pos "621"B  ReadEncodedLegSecurityDesc
    let pos, legRatioQty = ReadOptionalField bs pos "623"B  ReadLegRatioQty
    let pos, legSide = ReadOptionalField bs pos "624"B  ReadLegSide
    let pos, legCurrency = ReadOptionalField bs pos "556"B  ReadLegCurrency
    let pos, legPool = ReadOptionalField bs pos "740"B  ReadLegPool
    let pos, legDatedDate = ReadOptionalField bs pos "739"B  ReadLegDatedDate
    let pos, legContractSettlMonth = ReadOptionalField bs pos "955"B  ReadLegContractSettlMonth
    let pos, legInterestAccrualDate = ReadOptionalField bs pos "956"B  ReadLegInterestAccrualDate
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
    pos, ci


// group
let ReadNoMsgTypesGrp (bs:byte []) (pos:int) : int * NoMsgTypesGrp  =
    let pos, refMsgType = ReadField bs pos "ReadNoMsgTypes" "372"B ReadRefMsgType
    let pos, msgDirection = ReadOptionalField bs pos "385"B  ReadMsgDirection
    let ci:NoMsgTypesGrp = {
        RefMsgType = refMsgType
        MsgDirection = msgDirection
    }
    pos, ci


// group
let ReadNoIOIQualifiersGrp (bs:byte []) (pos:int) : int * NoIOIQualifiersGrp  =
    let pos, iOIQualifier = ReadField bs pos "ReadNoIOIQualifiers" "104"B ReadIOIQualifier
    let ci:NoIOIQualifiersGrp = {
        IOIQualifier = iOIQualifier
    }
    pos, ci


// group
let ReadNoRoutingIDsGrp (bs:byte []) (pos:int) : int * NoRoutingIDsGrp  =
    let pos, routingType = ReadField bs pos "ReadNoRoutingIDs" "216"B ReadRoutingType
    let pos, routingID = ReadOptionalField bs pos "217"B  ReadRoutingID
    let ci:NoRoutingIDsGrp = {
        RoutingType = routingType
        RoutingID = routingID
    }
    pos, ci


// group
let ReadLinesOfTextGrp (bs:byte []) (pos:int) : int * LinesOfTextGrp  =
    let pos, text = ReadField bs pos "ReadLinesOfText" "58"B ReadText
    let pos, encodedText = ReadOptionalField bs pos "354"B  ReadEncodedText
    let ci:LinesOfTextGrp = {
        Text = text
        EncodedText = encodedText
    }
    pos, ci


// group
let ReadNoMDEntryTypesGrp (bs:byte []) (pos:int) : int * NoMDEntryTypesGrp  =
    let pos, mDEntryType = ReadField bs pos "ReadNoMDEntryTypes" "269"B ReadMDEntryType
    let ci:NoMDEntryTypesGrp = {
        MDEntryType = mDEntryType
    }
    pos, ci


// group
let ReadNoMDEntriesGrp (bs:byte []) (pos:int) : int * NoMDEntriesGrp  =
    let pos, mDEntryType = ReadField bs pos "ReadNoMDEntries" "269"B ReadMDEntryType
    let pos, mDEntryPx = ReadOptionalField bs pos "270"B  ReadMDEntryPx
    let pos, currency = ReadOptionalField bs pos "15"B  ReadCurrency
    let pos, mDEntrySize = ReadOptionalField bs pos "271"B  ReadMDEntrySize
    let pos, mDEntryDate = ReadOptionalField bs pos "272"B  ReadMDEntryDate
    let pos, mDEntryTime = ReadOptionalField bs pos "273"B  ReadMDEntryTime
    let pos, tickDirection = ReadOptionalField bs pos "274"B  ReadTickDirection
    let pos, mDMkt = ReadOptionalField bs pos "275"B  ReadMDMkt
    let pos, tradingSessionID = ReadOptionalField bs pos "336"B  ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField bs pos "625"B  ReadTradingSessionSubID
    let pos, quoteCondition = ReadOptionalField bs pos "276"B  ReadQuoteCondition
    let pos, tradeCondition = ReadOptionalField bs pos "277"B  ReadTradeCondition
    let pos, mDEntryOriginator = ReadOptionalField bs pos "282"B  ReadMDEntryOriginator
    let pos, locationID = ReadOptionalField bs pos "283"B  ReadLocationID
    let pos, deskID = ReadOptionalField bs pos "284"B  ReadDeskID
    let pos, openCloseSettlFlag = ReadOptionalField bs pos "286"B  ReadOpenCloseSettlFlag
    let pos, timeInForce = ReadOptionalField bs pos "59"B  ReadTimeInForce
    let pos, expireDate = ReadOptionalField bs pos "432"B  ReadExpireDate
    let pos, expireTime = ReadOptionalField bs pos "126"B  ReadExpireTime
    let pos, minQty = ReadOptionalField bs pos "110"B  ReadMinQty
    let pos, execInst = ReadOptionalField bs pos "18"B  ReadExecInst
    let pos, sellerDays = ReadOptionalField bs pos "287"B  ReadSellerDays
    let pos, orderID = ReadOptionalField bs pos "37"B  ReadOrderID
    let pos, quoteEntryID = ReadOptionalField bs pos "299"B  ReadQuoteEntryID
    let pos, mDEntryBuyer = ReadOptionalField bs pos "288"B  ReadMDEntryBuyer
    let pos, mDEntrySeller = ReadOptionalField bs pos "289"B  ReadMDEntrySeller
    let pos, numberOfOrders = ReadOptionalField bs pos "346"B  ReadNumberOfOrders
    let pos, mDEntryPositionNo = ReadOptionalField bs pos "290"B  ReadMDEntryPositionNo
    let pos, scope = ReadOptionalField bs pos "546"B  ReadScope
    let pos, priceDelta = ReadOptionalField bs pos "811"B  ReadPriceDelta
    let pos, text = ReadOptionalField bs pos "58"B  ReadText
    let pos, encodedText = ReadOptionalField bs pos "354"B  ReadEncodedText
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
    pos, ci


// group
let ReadNoAltMDSourceGrp (bs:byte []) (pos:int) : int * NoAltMDSourceGrp  =
    let pos, altMDSourceID = ReadField bs pos "ReadNoAltMDSource" "817"B ReadAltMDSourceID
    let ci:NoAltMDSourceGrp = {
        AltMDSourceID = altMDSourceID
    }
    pos, ci


// group
let ReadNoSecurityTypesGrp (bs:byte []) (pos:int) : int * NoSecurityTypesGrp  =
    let pos, securityType = ReadField bs pos "ReadNoSecurityTypes" "167"B ReadSecurityType
    let pos, securitySubType = ReadOptionalField bs pos "762"B  ReadSecuritySubType
    let pos, product = ReadOptionalField bs pos "460"B  ReadProduct
    let pos, cFICode = ReadOptionalField bs pos "461"B  ReadCFICode
    let ci:NoSecurityTypesGrp = {
        SecurityType = securityType
        SecuritySubType = securitySubType
        Product = product
        CFICode = cFICode
    }
    pos, ci


// group
let ReadNoContraBrokersGrp (bs:byte []) (pos:int) : int * NoContraBrokersGrp  =
    let pos, contraBroker = ReadField bs pos "ReadNoContraBrokers" "375"B ReadContraBroker
    let pos, contraTrader = ReadOptionalField bs pos "337"B  ReadContraTrader
    let pos, contraTradeQty = ReadOptionalField bs pos "437"B  ReadContraTradeQty
    let pos, contraTradeTime = ReadOptionalField bs pos "438"B  ReadContraTradeTime
    let pos, contraLegRefID = ReadOptionalField bs pos "655"B  ReadContraLegRefID
    let ci:NoContraBrokersGrp = {
        ContraBroker = contraBroker
        ContraTrader = contraTrader
        ContraTradeQty = contraTradeQty
        ContraTradeTime = contraTradeTime
        ContraLegRefID = contraLegRefID
    }
    pos, ci


// group
let ReadNoAffectedOrdersGrp (bs:byte []) (pos:int) : int * NoAffectedOrdersGrp  =
    let pos, origClOrdID = ReadField bs pos "ReadNoAffectedOrders" "41"B ReadOrigClOrdID
    let pos, affectedOrderID = ReadOptionalField bs pos "535"B  ReadAffectedOrderID
    let pos, affectedSecondaryOrderID = ReadOptionalField bs pos "536"B  ReadAffectedSecondaryOrderID
    let ci:NoAffectedOrdersGrp = {
        OrigClOrdID = origClOrdID
        AffectedOrderID = affectedOrderID
        AffectedSecondaryOrderID = affectedSecondaryOrderID
    }
    pos, ci


// group
let ReadNoBidDescriptorsGrp (bs:byte []) (pos:int) : int * NoBidDescriptorsGrp  =
    let pos, bidDescriptorType = ReadField bs pos "ReadNoBidDescriptors" "399"B ReadBidDescriptorType
    let pos, bidDescriptor = ReadOptionalField bs pos "400"B  ReadBidDescriptor
    let pos, sideValueInd = ReadOptionalField bs pos "401"B  ReadSideValueInd
    let pos, liquidityValue = ReadOptionalField bs pos "404"B  ReadLiquidityValue
    let pos, liquidityNumSecurities = ReadOptionalField bs pos "441"B  ReadLiquidityNumSecurities
    let pos, liquidityPctLow = ReadOptionalField bs pos "402"B  ReadLiquidityPctLow
    let pos, liquidityPctHigh = ReadOptionalField bs pos "403"B  ReadLiquidityPctHigh
    let pos, eFPTrackingError = ReadOptionalField bs pos "405"B  ReadEFPTrackingError
    let pos, fairValue = ReadOptionalField bs pos "406"B  ReadFairValue
    let pos, outsideIndexPct = ReadOptionalField bs pos "407"B  ReadOutsideIndexPct
    let pos, valueOfFutures = ReadOptionalField bs pos "408"B  ReadValueOfFutures
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
    pos, ci


// group
let ReadNoBidComponentsGrp (bs:byte []) (pos:int) : int * NoBidComponentsGrp  =
    let pos, listID = ReadField bs pos "ReadNoBidComponents" "66"B ReadListID
    let pos, side = ReadOptionalField bs pos "54"B  ReadSide
    let pos, tradingSessionID = ReadOptionalField bs pos "336"B  ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField bs pos "625"B  ReadTradingSessionSubID
    let pos, netGrossInd = ReadOptionalField bs pos "430"B  ReadNetGrossInd
    let pos, settlType = ReadOptionalField bs pos "63"B  ReadSettlType
    let pos, settlDate = ReadOptionalField bs pos "64"B  ReadSettlDate
    let pos, account = ReadOptionalField bs pos "1"B  ReadAccount
    let pos, acctIDSource = ReadOptionalField bs pos "660"B  ReadAcctIDSource
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
    pos, ci


// group
let ReadListStatusNoOrdersGrp (bs:byte []) (pos:int) : int * ListStatusNoOrdersGrp  =
    let pos, clOrdID = ReadField bs pos "ReadListStatusNoOrders" "11"B ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField bs pos "526"B  ReadSecondaryClOrdID
    let pos, cumQty = ReadField bs pos "ReadListStatusNoOrders" "14"B ReadCumQty
    let pos, ordStatus = ReadField bs pos "ReadListStatusNoOrders" "39"B ReadOrdStatus
    let pos, workingIndicator = ReadOptionalField bs pos "636"B  ReadWorkingIndicator
    let pos, leavesQty = ReadField bs pos "ReadListStatusNoOrders" "151"B ReadLeavesQty
    let pos, cxlQty = ReadField bs pos "ReadListStatusNoOrders" "84"B ReadCxlQty
    let pos, avgPx = ReadField bs pos "ReadListStatusNoOrders" "6"B ReadAvgPx
    let pos, ordRejReason = ReadOptionalField bs pos "103"B  ReadOrdRejReason
    let pos, text = ReadOptionalField bs pos "58"B  ReadText
    let pos, encodedText = ReadOptionalField bs pos "354"B  ReadEncodedText
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
    pos, ci


// group
let ReadAllocationInstructionNoExecsGrp (bs:byte []) (pos:int) : int * AllocationInstructionNoExecsGrp  =
    let pos, lastQty = ReadField bs pos "ReadAllocationInstructionNoExecs" "32"B ReadLastQty
    let pos, execID = ReadOptionalField bs pos "17"B  ReadExecID
    let pos, secondaryExecID = ReadOptionalField bs pos "527"B  ReadSecondaryExecID
    let pos, lastPx = ReadOptionalField bs pos "31"B  ReadLastPx
    let pos, lastParPx = ReadOptionalField bs pos "669"B  ReadLastParPx
    let pos, lastCapacity = ReadOptionalField bs pos "29"B  ReadLastCapacity
    let ci:AllocationInstructionNoExecsGrp = {
        LastQty = lastQty
        ExecID = execID
        SecondaryExecID = secondaryExecID
        LastPx = lastPx
        LastParPx = lastParPx
        LastCapacity = lastCapacity
    }
    pos, ci


// group
let ReadAllocationInstructionAckNoAllocsGrp (bs:byte []) (pos:int) : int * AllocationInstructionAckNoAllocsGrp  =
    let pos, allocAccount = ReadField bs pos "ReadAllocationInstructionAckNoAllocs" "79"B ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField bs pos "661"B  ReadAllocAcctIDSource
    let pos, allocPrice = ReadOptionalField bs pos "366"B  ReadAllocPrice
    let pos, individualAllocID = ReadOptionalField bs pos "467"B  ReadIndividualAllocID
    let pos, individualAllocRejCode = ReadOptionalField bs pos "776"B  ReadIndividualAllocRejCode
    let pos, allocText = ReadOptionalField bs pos "161"B  ReadAllocText
    let pos, encodedAllocText = ReadOptionalField bs pos "360"B  ReadEncodedAllocText
    let ci:AllocationInstructionAckNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocPrice = allocPrice
        IndividualAllocID = individualAllocID
        IndividualAllocRejCode = individualAllocRejCode
        AllocText = allocText
        EncodedAllocText = encodedAllocText
    }
    pos, ci


// group
let ReadAllocationReportNoExecsGrp (bs:byte []) (pos:int) : int * AllocationReportNoExecsGrp  =
    let pos, lastQty = ReadField bs pos "ReadAllocationReportNoExecs" "32"B ReadLastQty
    let pos, execID = ReadOptionalField bs pos "17"B  ReadExecID
    let pos, secondaryExecID = ReadOptionalField bs pos "527"B  ReadSecondaryExecID
    let pos, lastPx = ReadOptionalField bs pos "31"B  ReadLastPx
    let pos, lastParPx = ReadOptionalField bs pos "669"B  ReadLastParPx
    let pos, lastCapacity = ReadOptionalField bs pos "29"B  ReadLastCapacity
    let ci:AllocationReportNoExecsGrp = {
        LastQty = lastQty
        ExecID = execID
        SecondaryExecID = secondaryExecID
        LastPx = lastPx
        LastParPx = lastParPx
        LastCapacity = lastCapacity
    }
    pos, ci


// group
let ReadAllocationReportAckNoAllocsGrp (bs:byte []) (pos:int) : int * AllocationReportAckNoAllocsGrp  =
    let pos, allocAccount = ReadField bs pos "ReadAllocationReportAckNoAllocs" "79"B ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField bs pos "661"B  ReadAllocAcctIDSource
    let pos, allocPrice = ReadOptionalField bs pos "366"B  ReadAllocPrice
    let pos, individualAllocID = ReadOptionalField bs pos "467"B  ReadIndividualAllocID
    let pos, individualAllocRejCode = ReadOptionalField bs pos "776"B  ReadIndividualAllocRejCode
    let pos, allocText = ReadOptionalField bs pos "161"B  ReadAllocText
    let pos, encodedAllocText = ReadOptionalField bs pos "360"B  ReadEncodedAllocText
    let ci:AllocationReportAckNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocPrice = allocPrice
        IndividualAllocID = individualAllocID
        IndividualAllocRejCode = individualAllocRejCode
        AllocText = allocText
        EncodedAllocText = encodedAllocText
    }
    pos, ci


// group
let ReadNoCapacitiesGrp (bs:byte []) (pos:int) : int * NoCapacitiesGrp  =
    let pos, orderCapacity = ReadField bs pos "ReadNoCapacities" "528"B ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField bs pos "529"B  ReadOrderRestrictions
    let pos, orderCapacityQty = ReadField bs pos "ReadNoCapacities" "863"B ReadOrderCapacityQty
    let ci:NoCapacitiesGrp = {
        OrderCapacity = orderCapacity
        OrderRestrictions = orderRestrictions
        OrderCapacityQty = orderCapacityQty
    }
    pos, ci


// group
let ReadNoDatesGrp (bs:byte []) (pos:int) : int * NoDatesGrp  =
    let pos, tradeDate = ReadField bs pos "ReadNoDates" "75"B ReadTradeDate
    let pos, transactTime = ReadOptionalField bs pos "60"B  ReadTransactTime
    let ci:NoDatesGrp = {
        TradeDate = tradeDate
        TransactTime = transactTime
    }
    pos, ci


// group
let ReadNoDistribInstsGrp (bs:byte []) (pos:int) : int * NoDistribInstsGrp  =
    let pos, distribPaymentMethod = ReadField bs pos "ReadNoDistribInsts" "477"B ReadDistribPaymentMethod
    let pos, distribPercentage = ReadOptionalField bs pos "512"B  ReadDistribPercentage
    let pos, cashDistribCurr = ReadOptionalField bs pos "478"B  ReadCashDistribCurr
    let pos, cashDistribAgentName = ReadOptionalField bs pos "498"B  ReadCashDistribAgentName
    let pos, cashDistribAgentCode = ReadOptionalField bs pos "499"B  ReadCashDistribAgentCode
    let pos, cashDistribAgentAcctNumber = ReadOptionalField bs pos "500"B  ReadCashDistribAgentAcctNumber
    let pos, cashDistribPayRef = ReadOptionalField bs pos "501"B  ReadCashDistribPayRef
    let pos, cashDistribAgentAcctName = ReadOptionalField bs pos "502"B  ReadCashDistribAgentAcctName
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
    pos, ci


// group
let ReadNoExecsGrp (bs:byte []) (pos:int) : int * NoExecsGrp  =
    let pos, execID = ReadField bs pos "ReadNoExecs" "17"B ReadExecID
    let ci:NoExecsGrp = {
        ExecID = execID
    }
    pos, ci


// group
let ReadNoTradesGrp (bs:byte []) (pos:int) : int * NoTradesGrp  =
    let pos, tradeReportID = ReadField bs pos "ReadNoTrades" "571"B ReadTradeReportID
    let pos, secondaryTradeReportID = ReadOptionalField bs pos "818"B  ReadSecondaryTradeReportID
    let ci:NoTradesGrp = {
        TradeReportID = tradeReportID
        SecondaryTradeReportID = secondaryTradeReportID
    }
    pos, ci


// group
let ReadNoCollInquiryQualifierGrp (bs:byte []) (pos:int) : int * NoCollInquiryQualifierGrp  =
    let pos, collInquiryQualifier = ReadField bs pos "ReadNoCollInquiryQualifier" "896"B ReadCollInquiryQualifier
    let ci:NoCollInquiryQualifierGrp = {
        CollInquiryQualifier = collInquiryQualifier
    }
    pos, ci


// group
let ReadNoCompIDsGrp (bs:byte []) (pos:int) : int * NoCompIDsGrp  =
    let pos, refCompID = ReadField bs pos "ReadNoCompIDs" "930"B ReadRefCompID
    let pos, refSubID = ReadOptionalField bs pos "931"B  ReadRefSubID
    let pos, locationID = ReadOptionalField bs pos "283"B  ReadLocationID
    let pos, deskID = ReadOptionalField bs pos "284"B  ReadDeskID
    let ci:NoCompIDsGrp = {
        RefCompID = refCompID
        RefSubID = refSubID
        LocationID = locationID
        DeskID = deskID
    }
    pos, ci


// group
let ReadNetworkStatusResponseNoCompIDsGrp (bs:byte []) (pos:int) : int * NetworkStatusResponseNoCompIDsGrp  =
    let pos, refCompID = ReadField bs pos "ReadNetworkStatusResponseNoCompIDs" "930"B ReadRefCompID
    let pos, refSubID = ReadOptionalField bs pos "931"B  ReadRefSubID
    let pos, locationID = ReadOptionalField bs pos "283"B  ReadLocationID
    let pos, deskID = ReadOptionalField bs pos "284"B  ReadDeskID
    let pos, statusValue = ReadOptionalField bs pos "928"B  ReadStatusValue
    let pos, statusText = ReadOptionalField bs pos "929"B  ReadStatusText
    let ci:NetworkStatusResponseNoCompIDsGrp = {
        RefCompID = refCompID
        RefSubID = refSubID
        LocationID = locationID
        DeskID = deskID
        StatusValue = statusValue
        StatusText = statusText
    }
    pos, ci


// group
let ReadNoHopsGrp (bs:byte []) (pos:int) : int * NoHopsGrp  =
    let pos, hopCompID = ReadField bs pos "ReadNoHops" "628"B ReadHopCompID
    let pos, hopSendingTime = ReadOptionalField bs pos "629"B  ReadHopSendingTime
    let pos, hopRefID = ReadOptionalField bs pos "630"B  ReadHopRefID
    let ci:NoHopsGrp = {
        HopCompID = hopCompID
        HopSendingTime = hopSendingTime
        HopRefID = hopRefID
    }
    pos, ci


