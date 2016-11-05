module Fix44.CompoundItemReadFuncs

open Fix44.Fields
open Fix44.FieldReadFuncs
open Fix44.CompoundItems


let ReadField (ss:string) (pos:int) (expectedTag:byte[]) (bs:byte[]) readFunc = 
    let pos2, tag = FIXBufUtils.readTag pos bs
    if tag <> expectedTag then 
        let msg = sprintf "when reading %s: expected tag: %A, actual: %A" ss expectedTag tag
        failwith msg
    let pos3, fld = readFunc pos2 bs
    pos3, fld


let inline ReadOptionalField (pos:int) (expectedTag:byte[]) (bs:byte[]) readFunc = 
    let pos2, tag = FIXBufUtils.readTag pos bs
    if tag = expectedTag then 
        let pos3, fld = readFunc pos2 bs
        pos3, Some fld
    else
        pos, None   // return the original pos, the next readoptional will re-read it
// group
let ReadNoUnderlyingSecurityAltIDGrp (pos:int) (bs:byte []) : int * NoUnderlyingSecurityAltIDGrp  =
    let pos, underlyingSecurityAltID = ReadOptionalField pos "458"B bs ReadUnderlyingSecurityAltID
    let pos, underlyingSecurityAltIDSource = ReadOptionalField pos "459"B bs ReadUnderlyingSecurityAltIDSource
    //let ci = {
            //UnderlyingSecurityAltID = underlyingSecurityAltID
            //UnderlyingSecurityAltIDSource = underlyingSecurityAltIDSource
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoUnderlyingStipsGrp (pos:int) (bs:byte []) : int * NoUnderlyingStipsGrp  =
    let pos, underlyingStipType = ReadOptionalField pos "888"B bs ReadUnderlyingStipType
    let pos, underlyingStipValue = ReadOptionalField pos "889"B bs ReadUnderlyingStipValue
    //let ci = {
            //UnderlyingStipType = underlyingStipType
            //UnderlyingStipValue = underlyingStipValue
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadUnderlyingStipulations (pos:int) (bs:byte []) : int * UnderlyingStipulations  =
    //let ci = {
            //NoUnderlyingStips = noUnderlyingStips
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadUnderlyingInstrument (pos:int) (bs:byte []) : int * UnderlyingInstrument  =
    let pos, underlyingSymbol = ReadField "ReadUnderlyingInstrument" pos "311"B bs ReadUnderlyingSymbol
    let pos, underlyingSymbolSfx = ReadOptionalField pos "312"B bs ReadUnderlyingSymbolSfx
    let pos, underlyingSecurityID = ReadOptionalField pos "309"B bs ReadUnderlyingSecurityID
    let pos, underlyingSecurityIDSource = ReadOptionalField pos "305"B bs ReadUnderlyingSecurityIDSource
    let pos, underlyingProduct = ReadOptionalField pos "462"B bs ReadUnderlyingProduct
    let pos, underlyingCFICode = ReadOptionalField pos "463"B bs ReadUnderlyingCFICode
    let pos, underlyingSecurityType = ReadOptionalField pos "310"B bs ReadUnderlyingSecurityType
    let pos, underlyingSecuritySubType = ReadOptionalField pos "763"B bs ReadUnderlyingSecuritySubType
    let pos, underlyingMaturityMonthYear = ReadOptionalField pos "313"B bs ReadUnderlyingMaturityMonthYear
    let pos, underlyingMaturityDate = ReadOptionalField pos "542"B bs ReadUnderlyingMaturityDate
    let pos, underlyingPutOrCall = ReadOptionalField pos "315"B bs ReadUnderlyingPutOrCall
    let pos, underlyingCouponPaymentDate = ReadOptionalField pos "241"B bs ReadUnderlyingCouponPaymentDate
    let pos, underlyingIssueDate = ReadOptionalField pos "242"B bs ReadUnderlyingIssueDate
    let pos, underlyingRepoCollateralSecurityType = ReadOptionalField pos "243"B bs ReadUnderlyingRepoCollateralSecurityType
    let pos, underlyingRepurchaseTerm = ReadOptionalField pos "244"B bs ReadUnderlyingRepurchaseTerm
    let pos, underlyingRepurchaseRate = ReadOptionalField pos "245"B bs ReadUnderlyingRepurchaseRate
    let pos, underlyingFactor = ReadOptionalField pos "246"B bs ReadUnderlyingFactor
    let pos, underlyingCreditRating = ReadOptionalField pos "256"B bs ReadUnderlyingCreditRating
    let pos, underlyingInstrRegistry = ReadOptionalField pos "595"B bs ReadUnderlyingInstrRegistry
    let pos, underlyingCountryOfIssue = ReadOptionalField pos "592"B bs ReadUnderlyingCountryOfIssue
    let pos, underlyingStateOrProvinceOfIssue = ReadOptionalField pos "593"B bs ReadUnderlyingStateOrProvinceOfIssue
    let pos, underlyingLocaleOfIssue = ReadOptionalField pos "594"B bs ReadUnderlyingLocaleOfIssue
    let pos, underlyingRedemptionDate = ReadOptionalField pos "247"B bs ReadUnderlyingRedemptionDate
    let pos, underlyingStrikePrice = ReadOptionalField pos "316"B bs ReadUnderlyingStrikePrice
    let pos, underlyingStrikeCurrency = ReadOptionalField pos "941"B bs ReadUnderlyingStrikeCurrency
    let pos, underlyingOptAttribute = ReadOptionalField pos "317"B bs ReadUnderlyingOptAttribute
    let pos, underlyingContractMultiplier = ReadOptionalField pos "436"B bs ReadUnderlyingContractMultiplier
    let pos, underlyingCouponRate = ReadOptionalField pos "435"B bs ReadUnderlyingCouponRate
    let pos, underlyingSecurityExchange = ReadOptionalField pos "308"B bs ReadUnderlyingSecurityExchange
    let pos, underlyingIssuer = ReadOptionalField pos "306"B bs ReadUnderlyingIssuer
    let pos, encodedUnderlyingIssuer = ReadOptionalField pos "363"B bs ReadEncodedUnderlyingIssuer
    let pos, underlyingSecurityDesc = ReadOptionalField pos "307"B bs ReadUnderlyingSecurityDesc
    let pos, encodedUnderlyingSecurityDesc = ReadOptionalField pos "365"B bs ReadEncodedUnderlyingSecurityDesc
    let pos, underlyingCPProgram = ReadOptionalField pos "877"B bs ReadUnderlyingCPProgram
    let pos, underlyingCPRegType = ReadOptionalField pos "878"B bs ReadUnderlyingCPRegType
    let pos, underlyingCurrency = ReadOptionalField pos "318"B bs ReadUnderlyingCurrency
    let pos, underlyingQty = ReadOptionalField pos "879"B bs ReadUnderlyingQty
    let pos, underlyingPx = ReadOptionalField pos "810"B bs ReadUnderlyingPx
    let pos, underlyingDirtyPrice = ReadOptionalField pos "882"B bs ReadUnderlyingDirtyPrice
    let pos, underlyingEndPrice = ReadOptionalField pos "883"B bs ReadUnderlyingEndPrice
    let pos, underlyingStartValue = ReadOptionalField pos "884"B bs ReadUnderlyingStartValue
    let pos, underlyingCurrentValue = ReadOptionalField pos "885"B bs ReadUnderlyingCurrentValue
    let pos, underlyingEndValue = ReadOptionalField pos "886"B bs ReadUnderlyingEndValue
    //let ci = {
            //UnderlyingSymbol = underlyingSymbol
            //UnderlyingSymbolSfx = underlyingSymbolSfx
            //UnderlyingSecurityID = underlyingSecurityID
            //UnderlyingSecurityIDSource = underlyingSecurityIDSource
            //NoUnderlyingSecurityAltID = noUnderlyingSecurityAltID
            //UnderlyingProduct = underlyingProduct
            //UnderlyingCFICode = underlyingCFICode
            //UnderlyingSecurityType = underlyingSecurityType
            //UnderlyingSecuritySubType = underlyingSecuritySubType
            //UnderlyingMaturityMonthYear = underlyingMaturityMonthYear
            //UnderlyingMaturityDate = underlyingMaturityDate
            //UnderlyingPutOrCall = underlyingPutOrCall
            //UnderlyingCouponPaymentDate = underlyingCouponPaymentDate
            //UnderlyingIssueDate = underlyingIssueDate
            //UnderlyingRepoCollateralSecurityType = underlyingRepoCollateralSecurityType
            //UnderlyingRepurchaseTerm = underlyingRepurchaseTerm
            //UnderlyingRepurchaseRate = underlyingRepurchaseRate
            //UnderlyingFactor = underlyingFactor
            //UnderlyingCreditRating = underlyingCreditRating
            //UnderlyingInstrRegistry = underlyingInstrRegistry
            //UnderlyingCountryOfIssue = underlyingCountryOfIssue
            //UnderlyingStateOrProvinceOfIssue = underlyingStateOrProvinceOfIssue
            //UnderlyingLocaleOfIssue = underlyingLocaleOfIssue
            //UnderlyingRedemptionDate = underlyingRedemptionDate
            //UnderlyingStrikePrice = underlyingStrikePrice
            //UnderlyingStrikeCurrency = underlyingStrikeCurrency
            //UnderlyingOptAttribute = underlyingOptAttribute
            //UnderlyingContractMultiplier = underlyingContractMultiplier
            //UnderlyingCouponRate = underlyingCouponRate
            //UnderlyingSecurityExchange = underlyingSecurityExchange
            //UnderlyingIssuer = underlyingIssuer
            //EncodedUnderlyingIssuer = encodedUnderlyingIssuer
            //UnderlyingSecurityDesc = underlyingSecurityDesc
            //EncodedUnderlyingSecurityDesc = encodedUnderlyingSecurityDesc
            //UnderlyingCPProgram = underlyingCPProgram
            //UnderlyingCPRegType = underlyingCPRegType
            //UnderlyingCurrency = underlyingCurrency
            //UnderlyingQty = underlyingQty
            //UnderlyingPx = underlyingPx
            //UnderlyingDirtyPrice = underlyingDirtyPrice
            //UnderlyingEndPrice = underlyingEndPrice
            //UnderlyingStartValue = underlyingStartValue
            //UnderlyingCurrentValue = underlyingCurrentValue
            //UnderlyingEndValue = underlyingEndValue
            //UnderlyingStipulations = underlyingStipulations
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadCollateralResponseNoUnderlyingsGrp (pos:int) (bs:byte []) : int * CollateralResponseNoUnderlyingsGrp  =
    let pos, collAction = ReadOptionalField pos "944"B bs ReadCollAction
    //let ci = {
            //UnderlyingInstrument = underlyingInstrument
            //CollAction = collAction
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadCollateralAssignmentNoUnderlyingsGrp (pos:int) (bs:byte []) : int * CollateralAssignmentNoUnderlyingsGrp  =
    let pos, collAction = ReadOptionalField pos "944"B bs ReadCollAction
    //let ci = {
            //UnderlyingInstrument = underlyingInstrument
            //CollAction = collAction
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadCollateralRequestNoUnderlyingsGrp (pos:int) (bs:byte []) : int * CollateralRequestNoUnderlyingsGrp  =
    let pos, collAction = ReadOptionalField pos "944"B bs ReadCollAction
    //let ci = {
            //UnderlyingInstrument = underlyingInstrument
            //CollAction = collAction
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadPositionReportNoUnderlyingsGrp (pos:int) (bs:byte []) : int * PositionReportNoUnderlyingsGrp  =
    let pos, underlyingSettlPrice = ReadField "ReadPositionReportNoUnderlyings" pos "732"B bs ReadUnderlyingSettlPrice
    let pos, underlyingSettlPriceType = ReadField "ReadPositionReportNoUnderlyings" pos "733"B bs ReadUnderlyingSettlPriceType
    //let ci = {
            //UnderlyingInstrument = underlyingInstrument
            //UnderlyingSettlPrice = underlyingSettlPrice
            //UnderlyingSettlPriceType = underlyingSettlPriceType
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoNestedPartySubIDsGrp (pos:int) (bs:byte []) : int * NoNestedPartySubIDsGrp  =
    let pos, nestedPartySubID = ReadOptionalField pos "545"B bs ReadNestedPartySubID
    let pos, nestedPartySubIDType = ReadOptionalField pos "805"B bs ReadNestedPartySubIDType
    //let ci = {
            //NestedPartySubID = nestedPartySubID
            //NestedPartySubIDType = nestedPartySubIDType
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoNestedPartyIDsGrp (pos:int) (bs:byte []) : int * NoNestedPartyIDsGrp  =
    let pos, nestedPartyID = ReadOptionalField pos "524"B bs ReadNestedPartyID
    let pos, nestedPartyIDSource = ReadOptionalField pos "525"B bs ReadNestedPartyIDSource
    let pos, nestedPartyRole = ReadOptionalField pos "538"B bs ReadNestedPartyRole
    //let ci = {
            //NestedPartyID = nestedPartyID
            //NestedPartyIDSource = nestedPartyIDSource
            //NestedPartyRole = nestedPartyRole
            //NoNestedPartySubIDs = noNestedPartySubIDs
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadNestedParties (pos:int) (bs:byte []) : int * NestedParties  =
    //let ci = {
            //NoNestedPartyIDs = noNestedPartyIDs
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoPositionsGrp (pos:int) (bs:byte []) : int * NoPositionsGrp  =
    let pos, posType = ReadOptionalField pos "703"B bs ReadPosType
    let pos, longQty = ReadOptionalField pos "704"B bs ReadLongQty
    let pos, shortQty = ReadOptionalField pos "705"B bs ReadShortQty
    let pos, posQtyStatus = ReadOptionalField pos "706"B bs ReadPosQtyStatus
    //let ci = {
            //PosType = posType
            //LongQty = longQty
            //ShortQty = shortQty
            //PosQtyStatus = posQtyStatus
            //NestedParties = nestedParties
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadPositionQty (pos:int) (bs:byte []) : int * PositionQty  =
    //let ci = {
            //NoPositions = noPositions
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoRegistDtlsGrp (pos:int) (bs:byte []) : int * NoRegistDtlsGrp  =
    let pos, registDtls = ReadOptionalField pos "509"B bs ReadRegistDtls
    let pos, registEmail = ReadOptionalField pos "511"B bs ReadRegistEmail
    let pos, mailingDtls = ReadOptionalField pos "474"B bs ReadMailingDtls
    let pos, mailingInst = ReadOptionalField pos "482"B bs ReadMailingInst
    let pos, ownerType = ReadOptionalField pos "522"B bs ReadOwnerType
    let pos, dateOfBirth = ReadOptionalField pos "486"B bs ReadDateOfBirth
    let pos, investorCountryOfResidence = ReadOptionalField pos "475"B bs ReadInvestorCountryOfResidence
    //let ci = {
            //RegistDtls = registDtls
            //RegistEmail = registEmail
            //MailingDtls = mailingDtls
            //MailingInst = mailingInst
            //NestedParties = nestedParties
            //OwnerType = ownerType
            //DateOfBirth = dateOfBirth
            //InvestorCountryOfResidence = investorCountryOfResidence
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoNested2PartySubIDsGrp (pos:int) (bs:byte []) : int * NoNested2PartySubIDsGrp  =
    let pos, nested2PartySubID = ReadOptionalField pos "760"B bs ReadNested2PartySubID
    let pos, nested2PartySubIDType = ReadOptionalField pos "807"B bs ReadNested2PartySubIDType
    //let ci = {
            //Nested2PartySubID = nested2PartySubID
            //Nested2PartySubIDType = nested2PartySubIDType
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoNested2PartyIDsGrp (pos:int) (bs:byte []) : int * NoNested2PartyIDsGrp  =
    let pos, nested2PartyID = ReadOptionalField pos "757"B bs ReadNested2PartyID
    let pos, nested2PartyIDSource = ReadOptionalField pos "758"B bs ReadNested2PartyIDSource
    let pos, nested2PartyRole = ReadOptionalField pos "759"B bs ReadNested2PartyRole
    //let ci = {
            //Nested2PartyID = nested2PartyID
            //Nested2PartyIDSource = nested2PartyIDSource
            //Nested2PartyRole = nested2PartyRole
            //NoNested2PartySubIDs = noNested2PartySubIDs
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadNestedParties2 (pos:int) (bs:byte []) : int * NestedParties2  =
    //let ci = {
            //NoNested2PartyIDs = noNested2PartyIDs
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadTradeCaptureReportAckNoAllocsGrp (pos:int) (bs:byte []) : int * TradeCaptureReportAckNoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "79"B bs ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "661"B bs ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField pos "736"B bs ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField pos "467"B bs ReadIndividualAllocID
    let pos, allocQty = ReadOptionalField pos "80"B bs ReadAllocQty
    //let ci = {
            //AllocAccount = allocAccount
            //AllocAcctIDSource = allocAcctIDSource
            //AllocSettlCurrency = allocSettlCurrency
            //IndividualAllocID = individualAllocID
            //NestedParties2 = nestedParties2
            //AllocQty = allocQty
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoLegSecurityAltIDGrp (pos:int) (bs:byte []) : int * NoLegSecurityAltIDGrp  =
    let pos, legSecurityAltID = ReadOptionalField pos "605"B bs ReadLegSecurityAltID
    let pos, legSecurityAltIDSource = ReadOptionalField pos "606"B bs ReadLegSecurityAltIDSource
    //let ci = {
            //LegSecurityAltID = legSecurityAltID
            //LegSecurityAltIDSource = legSecurityAltIDSource
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadInstrumentLeg (pos:int) (bs:byte []) : int * InstrumentLeg  =
    let pos, legSymbol = ReadOptionalField pos "600"B bs ReadLegSymbol
    let pos, legSymbolSfx = ReadOptionalField pos "601"B bs ReadLegSymbolSfx
    let pos, legSecurityID = ReadOptionalField pos "602"B bs ReadLegSecurityID
    let pos, legSecurityIDSource = ReadOptionalField pos "603"B bs ReadLegSecurityIDSource
    let pos, legProduct = ReadOptionalField pos "607"B bs ReadLegProduct
    let pos, legCFICode = ReadOptionalField pos "608"B bs ReadLegCFICode
    let pos, legSecurityType = ReadOptionalField pos "609"B bs ReadLegSecurityType
    let pos, legSecuritySubType = ReadOptionalField pos "764"B bs ReadLegSecuritySubType
    let pos, legMaturityMonthYear = ReadOptionalField pos "610"B bs ReadLegMaturityMonthYear
    let pos, legMaturityDate = ReadOptionalField pos "611"B bs ReadLegMaturityDate
    let pos, legCouponPaymentDate = ReadOptionalField pos "248"B bs ReadLegCouponPaymentDate
    let pos, legIssueDate = ReadOptionalField pos "249"B bs ReadLegIssueDate
    let pos, legRepoCollateralSecurityType = ReadOptionalField pos "250"B bs ReadLegRepoCollateralSecurityType
    let pos, legRepurchaseTerm = ReadOptionalField pos "251"B bs ReadLegRepurchaseTerm
    let pos, legRepurchaseRate = ReadOptionalField pos "252"B bs ReadLegRepurchaseRate
    let pos, legFactor = ReadOptionalField pos "253"B bs ReadLegFactor
    let pos, legCreditRating = ReadOptionalField pos "257"B bs ReadLegCreditRating
    let pos, legInstrRegistry = ReadOptionalField pos "599"B bs ReadLegInstrRegistry
    let pos, legCountryOfIssue = ReadOptionalField pos "596"B bs ReadLegCountryOfIssue
    let pos, legStateOrProvinceOfIssue = ReadOptionalField pos "597"B bs ReadLegStateOrProvinceOfIssue
    let pos, legLocaleOfIssue = ReadOptionalField pos "598"B bs ReadLegLocaleOfIssue
    let pos, legRedemptionDate = ReadOptionalField pos "254"B bs ReadLegRedemptionDate
    let pos, legStrikePrice = ReadOptionalField pos "612"B bs ReadLegStrikePrice
    let pos, legStrikeCurrency = ReadOptionalField pos "942"B bs ReadLegStrikeCurrency
    let pos, legOptAttribute = ReadOptionalField pos "613"B bs ReadLegOptAttribute
    let pos, legContractMultiplier = ReadOptionalField pos "614"B bs ReadLegContractMultiplier
    let pos, legCouponRate = ReadOptionalField pos "615"B bs ReadLegCouponRate
    let pos, legSecurityExchange = ReadOptionalField pos "616"B bs ReadLegSecurityExchange
    let pos, legIssuer = ReadOptionalField pos "617"B bs ReadLegIssuer
    let pos, encodedLegIssuer = ReadOptionalField pos "619"B bs ReadEncodedLegIssuer
    let pos, legSecurityDesc = ReadOptionalField pos "620"B bs ReadLegSecurityDesc
    let pos, encodedLegSecurityDesc = ReadOptionalField pos "622"B bs ReadEncodedLegSecurityDesc
    let pos, legRatioQty = ReadOptionalField pos "623"B bs ReadLegRatioQty
    let pos, legSide = ReadOptionalField pos "624"B bs ReadLegSide
    let pos, legCurrency = ReadOptionalField pos "556"B bs ReadLegCurrency
    let pos, legPool = ReadOptionalField pos "740"B bs ReadLegPool
    let pos, legDatedDate = ReadOptionalField pos "739"B bs ReadLegDatedDate
    let pos, legContractSettlMonth = ReadOptionalField pos "955"B bs ReadLegContractSettlMonth
    let pos, legInterestAccrualDate = ReadOptionalField pos "956"B bs ReadLegInterestAccrualDate
    //let ci = {
            //LegSymbol = legSymbol
            //LegSymbolSfx = legSymbolSfx
            //LegSecurityID = legSecurityID
            //LegSecurityIDSource = legSecurityIDSource
            //NoLegSecurityAltID = noLegSecurityAltID
            //LegProduct = legProduct
            //LegCFICode = legCFICode
            //LegSecurityType = legSecurityType
            //LegSecuritySubType = legSecuritySubType
            //LegMaturityMonthYear = legMaturityMonthYear
            //LegMaturityDate = legMaturityDate
            //LegCouponPaymentDate = legCouponPaymentDate
            //LegIssueDate = legIssueDate
            //LegRepoCollateralSecurityType = legRepoCollateralSecurityType
            //LegRepurchaseTerm = legRepurchaseTerm
            //LegRepurchaseRate = legRepurchaseRate
            //LegFactor = legFactor
            //LegCreditRating = legCreditRating
            //LegInstrRegistry = legInstrRegistry
            //LegCountryOfIssue = legCountryOfIssue
            //LegStateOrProvinceOfIssue = legStateOrProvinceOfIssue
            //LegLocaleOfIssue = legLocaleOfIssue
            //LegRedemptionDate = legRedemptionDate
            //LegStrikePrice = legStrikePrice
            //LegStrikeCurrency = legStrikeCurrency
            //LegOptAttribute = legOptAttribute
            //LegContractMultiplier = legContractMultiplier
            //LegCouponRate = legCouponRate
            //LegSecurityExchange = legSecurityExchange
            //LegIssuer = legIssuer
            //EncodedLegIssuer = encodedLegIssuer
            //LegSecurityDesc = legSecurityDesc
            //EncodedLegSecurityDesc = encodedLegSecurityDesc
            //LegRatioQty = legRatioQty
            //LegSide = legSide
            //LegCurrency = legCurrency
            //LegPool = legPool
            //LegDatedDate = legDatedDate
            //LegContractSettlMonth = legContractSettlMonth
            //LegInterestAccrualDate = legInterestAccrualDate
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoLegStipulationsGrp (pos:int) (bs:byte []) : int * NoLegStipulationsGrp  =
    let pos, legStipulationType = ReadOptionalField pos "688"B bs ReadLegStipulationType
    let pos, legStipulationValue = ReadOptionalField pos "689"B bs ReadLegStipulationValue
    //let ci = {
            //LegStipulationType = legStipulationType
            //LegStipulationValue = legStipulationValue
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadLegStipulations (pos:int) (bs:byte []) : int * LegStipulations  =
    //let ci = {
            //NoLegStipulations = noLegStipulations
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadTradeCaptureReportAckNoLegsGrp (pos:int) (bs:byte []) : int * TradeCaptureReportAckNoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "687"B bs ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legPositionEffect = ReadOptionalField pos "564"B bs ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField pos "565"B bs ReadLegCoveredOrUncovered
    let pos, legRefID = ReadOptionalField pos "654"B bs ReadLegRefID
    let pos, legPrice = ReadOptionalField pos "566"B bs ReadLegPrice
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "588"B bs ReadLegSettlDate
    let pos, legLastPx = ReadOptionalField pos "637"B bs ReadLegLastPx
    //let ci = {
            //InstrumentLeg = instrumentLeg
            //LegQty = legQty
            //LegSwapType = legSwapType
            //LegStipulations = legStipulations
            //LegPositionEffect = legPositionEffect
            //LegCoveredOrUncovered = legCoveredOrUncovered
            //NestedParties = nestedParties
            //LegRefID = legRefID
            //LegPrice = legPrice
            //LegSettlType = legSettlType
            //LegSettlDate = legSettlDate
            //LegLastPx = legLastPx
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoPartySubIDsGrp (pos:int) (bs:byte []) : int * NoPartySubIDsGrp  =
    let pos, partySubID = ReadOptionalField pos "523"B bs ReadPartySubID
    let pos, partySubIDType = ReadOptionalField pos "803"B bs ReadPartySubIDType
    //let ci = {
            //PartySubID = partySubID
            //PartySubIDType = partySubIDType
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoPartyIDsGrp (pos:int) (bs:byte []) : int * NoPartyIDsGrp  =
    let pos, partyID = ReadOptionalField pos "448"B bs ReadPartyID
    let pos, partyIDSource = ReadOptionalField pos "447"B bs ReadPartyIDSource
    let pos, partyRole = ReadOptionalField pos "452"B bs ReadPartyRole
    //let ci = {
            //PartyID = partyID
            //PartyIDSource = partyIDSource
            //PartyRole = partyRole
            //NoPartySubIDs = noPartySubIDs
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadParties (pos:int) (bs:byte []) : int * Parties  =
    //let ci = {
            //NoPartyIDs = noPartyIDs
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoClearingInstructionsGrp (pos:int) (bs:byte []) : int * NoClearingInstructionsGrp  =
    let pos, clearingInstruction = ReadOptionalField pos "577"B bs ReadClearingInstruction
    //let ci = {
            //ClearingInstruction = clearingInstruction
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadCommissionData (pos:int) (bs:byte []) : int * CommissionData  =
    let pos, commission = ReadOptionalField pos "12"B bs ReadCommission
    let pos, commType = ReadOptionalField pos "13"B bs ReadCommType
    let pos, commCurrency = ReadOptionalField pos "479"B bs ReadCommCurrency
    let pos, fundRenewWaiv = ReadOptionalField pos "497"B bs ReadFundRenewWaiv
    //let ci = {
            //Commission = commission
            //CommType = commType
            //CommCurrency = commCurrency
            //FundRenewWaiv = fundRenewWaiv
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoContAmtsGrp (pos:int) (bs:byte []) : int * NoContAmtsGrp  =
    let pos, contAmtType = ReadOptionalField pos "519"B bs ReadContAmtType
    let pos, contAmtValue = ReadOptionalField pos "520"B bs ReadContAmtValue
    let pos, contAmtCurr = ReadOptionalField pos "521"B bs ReadContAmtCurr
    //let ci = {
            //ContAmtType = contAmtType
            //ContAmtValue = contAmtValue
            //ContAmtCurr = contAmtCurr
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoStipulationsGrp (pos:int) (bs:byte []) : int * NoStipulationsGrp  =
    let pos, stipulationType = ReadOptionalField pos "233"B bs ReadStipulationType
    let pos, stipulationValue = ReadOptionalField pos "234"B bs ReadStipulationValue
    //let ci = {
            //StipulationType = stipulationType
            //StipulationValue = stipulationValue
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadStipulations (pos:int) (bs:byte []) : int * Stipulations  =
    //let ci = {
            //NoStipulations = noStipulations
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoMiscFeesGrp (pos:int) (bs:byte []) : int * NoMiscFeesGrp  =
    let pos, miscFeeAmt = ReadOptionalField pos "137"B bs ReadMiscFeeAmt
    let pos, miscFeeCurr = ReadOptionalField pos "138"B bs ReadMiscFeeCurr
    let pos, miscFeeType = ReadOptionalField pos "139"B bs ReadMiscFeeType
    let pos, miscFeeBasis = ReadOptionalField pos "891"B bs ReadMiscFeeBasis
    //let ci = {
            //MiscFeeAmt = miscFeeAmt
            //MiscFeeCurr = miscFeeCurr
            //MiscFeeType = miscFeeType
            //MiscFeeBasis = miscFeeBasis
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadTradeCaptureReportNoSidesGrp (pos:int) (bs:byte []) : int * TradeCaptureReportNoSidesGrp  =
    let pos, side = ReadField "ReadTradeCaptureReportNoSides" pos "54"B bs ReadSide
    let pos, orderID = ReadField "ReadTradeCaptureReportNoSides" pos "37"B bs ReadOrderID
    let pos, secondaryOrderID = ReadOptionalField pos "198"B bs ReadSecondaryOrderID
    let pos, clOrdID = ReadOptionalField pos "11"B bs ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "526"B bs ReadSecondaryClOrdID
    let pos, listID = ReadOptionalField pos "66"B bs ReadListID
    let pos, account = ReadOptionalField pos "1"B bs ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "660"B bs ReadAcctIDSource
    let pos, accountType = ReadOptionalField pos "581"B bs ReadAccountType
    let pos, processCode = ReadOptionalField pos "81"B bs ReadProcessCode
    let pos, oddLot = ReadOptionalField pos "575"B bs ReadOddLot
    let pos, clearingFeeIndicator = ReadOptionalField pos "635"B bs ReadClearingFeeIndicator
    let pos, tradeInputSource = ReadOptionalField pos "578"B bs ReadTradeInputSource
    let pos, tradeInputDevice = ReadOptionalField pos "579"B bs ReadTradeInputDevice
    let pos, orderInputDevice = ReadOptionalField pos "821"B bs ReadOrderInputDevice
    let pos, currency = ReadOptionalField pos "15"B bs ReadCurrency
    let pos, complianceID = ReadOptionalField pos "376"B bs ReadComplianceID
    let pos, solicitedFlag = ReadOptionalField pos "377"B bs ReadSolicitedFlag
    let pos, orderCapacity = ReadOptionalField pos "528"B bs ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField pos "529"B bs ReadOrderRestrictions
    let pos, custOrderCapacity = ReadOptionalField pos "582"B bs ReadCustOrderCapacity
    let pos, ordType = ReadOptionalField pos "40"B bs ReadOrdType
    let pos, execInst = ReadOptionalField pos "18"B bs ReadExecInst
    let pos, transBkdTime = ReadOptionalField pos "483"B bs ReadTransBkdTime
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    let pos, timeBracket = ReadOptionalField pos "943"B bs ReadTimeBracket
    let pos, grossTradeAmt = ReadOptionalField pos "381"B bs ReadGrossTradeAmt
    let pos, numDaysInterest = ReadOptionalField pos "157"B bs ReadNumDaysInterest
    let pos, exDate = ReadOptionalField pos "230"B bs ReadExDate
    let pos, accruedInterestRate = ReadOptionalField pos "158"B bs ReadAccruedInterestRate
    let pos, accruedInterestAmt = ReadOptionalField pos "159"B bs ReadAccruedInterestAmt
    let pos, interestAtMaturity = ReadOptionalField pos "738"B bs ReadInterestAtMaturity
    let pos, endAccruedInterestAmt = ReadOptionalField pos "920"B bs ReadEndAccruedInterestAmt
    let pos, startCash = ReadOptionalField pos "921"B bs ReadStartCash
    let pos, endCash = ReadOptionalField pos "922"B bs ReadEndCash
    let pos, concession = ReadOptionalField pos "238"B bs ReadConcession
    let pos, totalTakedown = ReadOptionalField pos "237"B bs ReadTotalTakedown
    let pos, netMoney = ReadOptionalField pos "118"B bs ReadNetMoney
    let pos, settlCurrAmt = ReadOptionalField pos "119"B bs ReadSettlCurrAmt
    let pos, settlCurrency = ReadOptionalField pos "120"B bs ReadSettlCurrency
    let pos, settlCurrFxRate = ReadOptionalField pos "155"B bs ReadSettlCurrFxRate
    let pos, settlCurrFxRateCalc = ReadOptionalField pos "156"B bs ReadSettlCurrFxRateCalc
    let pos, positionEffect = ReadOptionalField pos "77"B bs ReadPositionEffect
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    let pos, sideMultiLegReportingType = ReadOptionalField pos "752"B bs ReadSideMultiLegReportingType
    let pos, exchangeRule = ReadOptionalField pos "825"B bs ReadExchangeRule
    let pos, tradeAllocIndicator = ReadOptionalField pos "826"B bs ReadTradeAllocIndicator
    let pos, preallocMethod = ReadOptionalField pos "591"B bs ReadPreallocMethod
    let pos, allocID = ReadOptionalField pos "70"B bs ReadAllocID
    //let ci = {
            //Side = side
            //OrderID = orderID
            //SecondaryOrderID = secondaryOrderID
            //ClOrdID = clOrdID
            //SecondaryClOrdID = secondaryClOrdID
            //ListID = listID
            //Parties = parties
            //Account = account
            //AcctIDSource = acctIDSource
            //AccountType = accountType
            //ProcessCode = processCode
            //OddLot = oddLot
            //NoClearingInstructions = noClearingInstructions
            //ClearingFeeIndicator = clearingFeeIndicator
            //TradeInputSource = tradeInputSource
            //TradeInputDevice = tradeInputDevice
            //OrderInputDevice = orderInputDevice
            //Currency = currency
            //ComplianceID = complianceID
            //SolicitedFlag = solicitedFlag
            //OrderCapacity = orderCapacity
            //OrderRestrictions = orderRestrictions
            //CustOrderCapacity = custOrderCapacity
            //OrdType = ordType
            //ExecInst = execInst
            //TransBkdTime = transBkdTime
            //TradingSessionID = tradingSessionID
            //TradingSessionSubID = tradingSessionSubID
            //TimeBracket = timeBracket
            //CommissionData = commissionData
            //GrossTradeAmt = grossTradeAmt
            //NumDaysInterest = numDaysInterest
            //ExDate = exDate
            //AccruedInterestRate = accruedInterestRate
            //AccruedInterestAmt = accruedInterestAmt
            //InterestAtMaturity = interestAtMaturity
            //EndAccruedInterestAmt = endAccruedInterestAmt
            //StartCash = startCash
            //EndCash = endCash
            //Concession = concession
            //TotalTakedown = totalTakedown
            //NetMoney = netMoney
            //SettlCurrAmt = settlCurrAmt
            //SettlCurrency = settlCurrency
            //SettlCurrFxRate = settlCurrFxRate
            //SettlCurrFxRateCalc = settlCurrFxRateCalc
            //PositionEffect = positionEffect
            //Text = text
            //EncodedText = encodedText
            //SideMultiLegReportingType = sideMultiLegReportingType
            //NoContAmts = noContAmts
            //Stipulations = stipulations
            //NoMiscFees = noMiscFees
            //ExchangeRule = exchangeRule
            //TradeAllocIndicator = tradeAllocIndicator
            //PreallocMethod = preallocMethod
            //AllocID = allocID
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadTradeCaptureReportNoLegsGrp (pos:int) (bs:byte []) : int * TradeCaptureReportNoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "687"B bs ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legPositionEffect = ReadOptionalField pos "564"B bs ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField pos "565"B bs ReadLegCoveredOrUncovered
    let pos, legRefID = ReadOptionalField pos "654"B bs ReadLegRefID
    let pos, legPrice = ReadOptionalField pos "566"B bs ReadLegPrice
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "588"B bs ReadLegSettlDate
    let pos, legLastPx = ReadOptionalField pos "637"B bs ReadLegLastPx
    //let ci = {
            //InstrumentLeg = instrumentLeg
            //LegQty = legQty
            //LegSwapType = legSwapType
            //LegStipulations = legStipulations
            //LegPositionEffect = legPositionEffect
            //LegCoveredOrUncovered = legCoveredOrUncovered
            //NestedParties = nestedParties
            //LegRefID = legRefID
            //LegPrice = legPrice
            //LegSettlType = legSettlType
            //LegSettlDate = legSettlDate
            //LegLastPx = legLastPx
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoPosAmtGrp (pos:int) (bs:byte []) : int * NoPosAmtGrp  =
    let pos, posAmtType = ReadField "ReadNoPosAmt" pos "707"B bs ReadPosAmtType
    let pos, posAmt = ReadField "ReadNoPosAmt" pos "708"B bs ReadPosAmt
    //let ci = {
            //PosAmtType = posAmtType
            //PosAmt = posAmt
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadPositionAmountData (pos:int) (bs:byte []) : int * PositionAmountData  =
    //let ci = {
            //NoPosAmt = noPosAmt
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoSettlPartySubIDsGrp (pos:int) (bs:byte []) : int * NoSettlPartySubIDsGrp  =
    let pos, settlPartySubID = ReadOptionalField pos "785"B bs ReadSettlPartySubID
    let pos, settlPartySubIDType = ReadOptionalField pos "786"B bs ReadSettlPartySubIDType
    //let ci = {
            //SettlPartySubID = settlPartySubID
            //SettlPartySubIDType = settlPartySubIDType
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoSettlPartyIDsGrp (pos:int) (bs:byte []) : int * NoSettlPartyIDsGrp  =
    let pos, settlPartyID = ReadOptionalField pos "782"B bs ReadSettlPartyID
    let pos, settlPartyIDSource = ReadOptionalField pos "783"B bs ReadSettlPartyIDSource
    let pos, settlPartyRole = ReadOptionalField pos "784"B bs ReadSettlPartyRole
    //let ci = {
            //SettlPartyID = settlPartyID
            //SettlPartyIDSource = settlPartyIDSource
            //SettlPartyRole = settlPartyRole
            //NoSettlPartySubIDs = noSettlPartySubIDs
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadSettlParties (pos:int) (bs:byte []) : int * SettlParties  =
    //let ci = {
            //NoSettlPartyIDs = noSettlPartyIDs
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoDlvyInstGrp (pos:int) (bs:byte []) : int * NoDlvyInstGrp  =
    let pos, settlInstSource = ReadOptionalField pos "165"B bs ReadSettlInstSource
    let pos, dlvyInstType = ReadOptionalField pos "787"B bs ReadDlvyInstType
    //let ci = {
            //SettlInstSource = settlInstSource
            //DlvyInstType = dlvyInstType
            //SettlParties = settlParties
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadSettlInstructionsData (pos:int) (bs:byte []) : int * SettlInstructionsData  =
    let pos, settlDeliveryType = ReadOptionalField pos "172"B bs ReadSettlDeliveryType
    let pos, standInstDbType = ReadOptionalField pos "169"B bs ReadStandInstDbType
    let pos, standInstDbName = ReadOptionalField pos "170"B bs ReadStandInstDbName
    let pos, standInstDbID = ReadOptionalField pos "171"B bs ReadStandInstDbID
    //let ci = {
            //SettlDeliveryType = settlDeliveryType
            //StandInstDbType = standInstDbType
            //StandInstDbName = standInstDbName
            //StandInstDbID = standInstDbID
            //NoDlvyInst = noDlvyInst
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoSettlInstGrp (pos:int) (bs:byte []) : int * NoSettlInstGrp  =
    let pos, settlInstID = ReadOptionalField pos "162"B bs ReadSettlInstID
    let pos, settlInstTransType = ReadOptionalField pos "163"B bs ReadSettlInstTransType
    let pos, settlInstRefID = ReadOptionalField pos "214"B bs ReadSettlInstRefID
    let pos, side = ReadOptionalField pos "54"B bs ReadSide
    let pos, product = ReadOptionalField pos "460"B bs ReadProduct
    let pos, securityType = ReadOptionalField pos "167"B bs ReadSecurityType
    let pos, cFICode = ReadOptionalField pos "461"B bs ReadCFICode
    let pos, effectiveTime = ReadOptionalField pos "168"B bs ReadEffectiveTime
    let pos, expireTime = ReadOptionalField pos "126"B bs ReadExpireTime
    let pos, lastUpdateTime = ReadOptionalField pos "779"B bs ReadLastUpdateTime
    let pos, paymentMethod = ReadOptionalField pos "492"B bs ReadPaymentMethod
    let pos, paymentRef = ReadOptionalField pos "476"B bs ReadPaymentRef
    let pos, cardHolderName = ReadOptionalField pos "488"B bs ReadCardHolderName
    let pos, cardNumber = ReadOptionalField pos "489"B bs ReadCardNumber
    let pos, cardStartDate = ReadOptionalField pos "503"B bs ReadCardStartDate
    let pos, cardExpDate = ReadOptionalField pos "490"B bs ReadCardExpDate
    let pos, cardIssNum = ReadOptionalField pos "491"B bs ReadCardIssNum
    let pos, paymentDate = ReadOptionalField pos "504"B bs ReadPaymentDate
    let pos, paymentRemitterID = ReadOptionalField pos "505"B bs ReadPaymentRemitterID
    //let ci = {
            //SettlInstID = settlInstID
            //SettlInstTransType = settlInstTransType
            //SettlInstRefID = settlInstRefID
            //Parties = parties
            //Side = side
            //Product = product
            //SecurityType = securityType
            //CFICode = cFICode
            //EffectiveTime = effectiveTime
            //ExpireTime = expireTime
            //LastUpdateTime = lastUpdateTime
            //SettlInstructionsData = settlInstructionsData
            //PaymentMethod = paymentMethod
            //PaymentRef = paymentRef
            //CardHolderName = cardHolderName
            //CardNumber = cardNumber
            //CardStartDate = cardStartDate
            //CardExpDate = cardExpDate
            //CardIssNum = cardIssNum
            //PaymentDate = paymentDate
            //PaymentRemitterID = paymentRemitterID
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoTrdRegTimestampsGrp (pos:int) (bs:byte []) : int * NoTrdRegTimestampsGrp  =
    let pos, trdRegTimestamp = ReadOptionalField pos "769"B bs ReadTrdRegTimestamp
    let pos, trdRegTimestampType = ReadOptionalField pos "770"B bs ReadTrdRegTimestampType
    let pos, trdRegTimestampOrigin = ReadOptionalField pos "771"B bs ReadTrdRegTimestampOrigin
    //let ci = {
            //TrdRegTimestamp = trdRegTimestamp
            //TrdRegTimestampType = trdRegTimestampType
            //TrdRegTimestampOrigin = trdRegTimestampOrigin
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadTrdRegTimestamps (pos:int) (bs:byte []) : int * TrdRegTimestamps  =
    //let ci = {
            //NoTrdRegTimestamps = noTrdRegTimestamps
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadAllocationReportNoAllocsGrp (pos:int) (bs:byte []) : int * AllocationReportNoAllocsGrp  =
    let pos, allocAccount = ReadField "ReadAllocationReportNoAllocs" pos "79"B bs ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "661"B bs ReadAllocAcctIDSource
    let pos, matchStatus = ReadOptionalField pos "573"B bs ReadMatchStatus
    let pos, allocPrice = ReadOptionalField pos "366"B bs ReadAllocPrice
    let pos, allocQty = ReadField "ReadAllocationReportNoAllocs" pos "80"B bs ReadAllocQty
    let pos, individualAllocID = ReadOptionalField pos "467"B bs ReadIndividualAllocID
    let pos, processCode = ReadOptionalField pos "81"B bs ReadProcessCode
    let pos, notifyBrokerOfCredit = ReadOptionalField pos "208"B bs ReadNotifyBrokerOfCredit
    let pos, allocHandlInst = ReadOptionalField pos "209"B bs ReadAllocHandlInst
    let pos, allocText = ReadOptionalField pos "161"B bs ReadAllocText
    let pos, encodedAllocText = ReadOptionalField pos "361"B bs ReadEncodedAllocText
    let pos, allocAvgPx = ReadOptionalField pos "153"B bs ReadAllocAvgPx
    let pos, allocNetMoney = ReadOptionalField pos "154"B bs ReadAllocNetMoney
    let pos, settlCurrAmt = ReadOptionalField pos "119"B bs ReadSettlCurrAmt
    let pos, allocSettlCurrAmt = ReadOptionalField pos "737"B bs ReadAllocSettlCurrAmt
    let pos, settlCurrency = ReadOptionalField pos "120"B bs ReadSettlCurrency
    let pos, allocSettlCurrency = ReadOptionalField pos "736"B bs ReadAllocSettlCurrency
    let pos, settlCurrFxRate = ReadOptionalField pos "155"B bs ReadSettlCurrFxRate
    let pos, settlCurrFxRateCalc = ReadOptionalField pos "156"B bs ReadSettlCurrFxRateCalc
    let pos, allocAccruedInterestAmt = ReadOptionalField pos "742"B bs ReadAllocAccruedInterestAmt
    let pos, allocInterestAtMaturity = ReadOptionalField pos "741"B bs ReadAllocInterestAtMaturity
    let pos, clearingFeeIndicator = ReadOptionalField pos "635"B bs ReadClearingFeeIndicator
    let pos, allocSettlInstType = ReadOptionalField pos "780"B bs ReadAllocSettlInstType
    //let ci = {
            //AllocAccount = allocAccount
            //AllocAcctIDSource = allocAcctIDSource
            //MatchStatus = matchStatus
            //AllocPrice = allocPrice
            //AllocQty = allocQty
            //IndividualAllocID = individualAllocID
            //ProcessCode = processCode
            //NestedParties = nestedParties
            //NotifyBrokerOfCredit = notifyBrokerOfCredit
            //AllocHandlInst = allocHandlInst
            //AllocText = allocText
            //EncodedAllocText = encodedAllocText
            //CommissionData = commissionData
            //AllocAvgPx = allocAvgPx
            //AllocNetMoney = allocNetMoney
            //SettlCurrAmt = settlCurrAmt
            //AllocSettlCurrAmt = allocSettlCurrAmt
            //SettlCurrency = settlCurrency
            //AllocSettlCurrency = allocSettlCurrency
            //SettlCurrFxRate = settlCurrFxRate
            //SettlCurrFxRateCalc = settlCurrFxRateCalc
            //AllocAccruedInterestAmt = allocAccruedInterestAmt
            //AllocInterestAtMaturity = allocInterestAtMaturity
            //NoMiscFees = noMiscFees
            //NoClearingInstructions = noClearingInstructions
            //ClearingFeeIndicator = clearingFeeIndicator
            //AllocSettlInstType = allocSettlInstType
            //SettlInstructionsData = settlInstructionsData
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadAllocationInstructionNoAllocsGrp (pos:int) (bs:byte []) : int * AllocationInstructionNoAllocsGrp  =
    let pos, allocAccount = ReadField "ReadAllocationInstructionNoAllocs" pos "79"B bs ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "661"B bs ReadAllocAcctIDSource
    let pos, matchStatus = ReadOptionalField pos "573"B bs ReadMatchStatus
    let pos, allocPrice = ReadOptionalField pos "366"B bs ReadAllocPrice
    let pos, allocQty = ReadOptionalField pos "80"B bs ReadAllocQty
    let pos, individualAllocID = ReadOptionalField pos "467"B bs ReadIndividualAllocID
    let pos, processCode = ReadOptionalField pos "81"B bs ReadProcessCode
    let pos, notifyBrokerOfCredit = ReadOptionalField pos "208"B bs ReadNotifyBrokerOfCredit
    let pos, allocHandlInst = ReadOptionalField pos "209"B bs ReadAllocHandlInst
    let pos, allocText = ReadOptionalField pos "161"B bs ReadAllocText
    let pos, encodedAllocText = ReadOptionalField pos "361"B bs ReadEncodedAllocText
    let pos, allocAvgPx = ReadOptionalField pos "153"B bs ReadAllocAvgPx
    let pos, allocNetMoney = ReadOptionalField pos "154"B bs ReadAllocNetMoney
    let pos, settlCurrAmt = ReadOptionalField pos "119"B bs ReadSettlCurrAmt
    let pos, allocSettlCurrAmt = ReadOptionalField pos "737"B bs ReadAllocSettlCurrAmt
    let pos, settlCurrency = ReadOptionalField pos "120"B bs ReadSettlCurrency
    let pos, allocSettlCurrency = ReadOptionalField pos "736"B bs ReadAllocSettlCurrency
    let pos, settlCurrFxRate = ReadOptionalField pos "155"B bs ReadSettlCurrFxRate
    let pos, settlCurrFxRateCalc = ReadOptionalField pos "156"B bs ReadSettlCurrFxRateCalc
    let pos, accruedInterestAmt = ReadOptionalField pos "159"B bs ReadAccruedInterestAmt
    let pos, allocAccruedInterestAmt = ReadOptionalField pos "742"B bs ReadAllocAccruedInterestAmt
    let pos, allocInterestAtMaturity = ReadOptionalField pos "741"B bs ReadAllocInterestAtMaturity
    let pos, settlInstMode = ReadOptionalField pos "160"B bs ReadSettlInstMode
    let pos, noClearingInstructions = ReadOptionalField pos "576"B bs ReadNoClearingInstructions
    let pos, clearingInstruction = ReadOptionalField pos "577"B bs ReadClearingInstruction
    let pos, clearingFeeIndicator = ReadOptionalField pos "635"B bs ReadClearingFeeIndicator
    let pos, allocSettlInstType = ReadOptionalField pos "780"B bs ReadAllocSettlInstType
    //let ci = {
            //AllocAccount = allocAccount
            //AllocAcctIDSource = allocAcctIDSource
            //MatchStatus = matchStatus
            //AllocPrice = allocPrice
            //AllocQty = allocQty
            //IndividualAllocID = individualAllocID
            //ProcessCode = processCode
            //NestedParties = nestedParties
            //NotifyBrokerOfCredit = notifyBrokerOfCredit
            //AllocHandlInst = allocHandlInst
            //AllocText = allocText
            //EncodedAllocText = encodedAllocText
            //CommissionData = commissionData
            //AllocAvgPx = allocAvgPx
            //AllocNetMoney = allocNetMoney
            //SettlCurrAmt = settlCurrAmt
            //AllocSettlCurrAmt = allocSettlCurrAmt
            //SettlCurrency = settlCurrency
            //AllocSettlCurrency = allocSettlCurrency
            //SettlCurrFxRate = settlCurrFxRate
            //SettlCurrFxRateCalc = settlCurrFxRateCalc
            //AccruedInterestAmt = accruedInterestAmt
            //AllocAccruedInterestAmt = allocAccruedInterestAmt
            //AllocInterestAtMaturity = allocInterestAtMaturity
            //SettlInstMode = settlInstMode
            //NoMiscFees = noMiscFees
            //NoClearingInstructions = noClearingInstructions
            //ClearingInstruction = clearingInstruction
            //ClearingFeeIndicator = clearingFeeIndicator
            //AllocSettlInstType = allocSettlInstType
            //SettlInstructionsData = settlInstructionsData
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoOrdersGrp (pos:int) (bs:byte []) : int * NoOrdersGrp  =
    let pos, clOrdID = ReadOptionalField pos "11"B bs ReadClOrdID
    let pos, orderID = ReadOptionalField pos "37"B bs ReadOrderID
    let pos, secondaryOrderID = ReadOptionalField pos "198"B bs ReadSecondaryOrderID
    let pos, secondaryClOrdID = ReadOptionalField pos "526"B bs ReadSecondaryClOrdID
    let pos, listID = ReadOptionalField pos "66"B bs ReadListID
    let pos, orderQty = ReadOptionalField pos "38"B bs ReadOrderQty
    let pos, orderAvgPx = ReadOptionalField pos "799"B bs ReadOrderAvgPx
    let pos, orderBookingQty = ReadOptionalField pos "800"B bs ReadOrderBookingQty
    //let ci = {
            //ClOrdID = clOrdID
            //OrderID = orderID
            //SecondaryOrderID = secondaryOrderID
            //SecondaryClOrdID = secondaryClOrdID
            //ListID = listID
            //NestedParties2 = nestedParties2
            //OrderQty = orderQty
            //OrderAvgPx = orderAvgPx
            //OrderBookingQty = orderBookingQty
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadListStrikePriceNoUnderlyingsGrp (pos:int) (bs:byte []) : int * ListStrikePriceNoUnderlyingsGrp  =
    let pos, prevClosePx = ReadOptionalField pos "140"B bs ReadPrevClosePx
    let pos, clOrdID = ReadOptionalField pos "11"B bs ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "526"B bs ReadSecondaryClOrdID
    let pos, side = ReadOptionalField pos "54"B bs ReadSide
    let pos, price = ReadField "ReadListStrikePriceNoUnderlyings" pos "44"B bs ReadPrice
    let pos, currency = ReadOptionalField pos "15"B bs ReadCurrency
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    //let ci = {
            //UnderlyingInstrument = underlyingInstrument
            //PrevClosePx = prevClosePx
            //ClOrdID = clOrdID
            //SecondaryClOrdID = secondaryClOrdID
            //Side = side
            //Price = price
            //Currency = currency
            //Text = text
            //EncodedText = encodedText
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoSecurityAltIDGrp (pos:int) (bs:byte []) : int * NoSecurityAltIDGrp  =
    let pos, securityAltID = ReadOptionalField pos "455"B bs ReadSecurityAltID
    let pos, securityAltIDSource = ReadOptionalField pos "456"B bs ReadSecurityAltIDSource
    //let ci = {
            //SecurityAltID = securityAltID
            //SecurityAltIDSource = securityAltIDSource
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoEventsGrp (pos:int) (bs:byte []) : int * NoEventsGrp  =
    let pos, eventType = ReadOptionalField pos "865"B bs ReadEventType
    let pos, eventDate = ReadOptionalField pos "866"B bs ReadEventDate
    let pos, eventPx = ReadOptionalField pos "867"B bs ReadEventPx
    let pos, eventText = ReadOptionalField pos "868"B bs ReadEventText
    //let ci = {
            //EventType = eventType
            //EventDate = eventDate
            //EventPx = eventPx
            //EventText = eventText
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadInstrument (pos:int) (bs:byte []) : int * Instrument  =
    let pos, symbol = ReadField "ReadInstrument" pos "55"B bs ReadSymbol
    let pos, symbolSfx = ReadOptionalField pos "65"B bs ReadSymbolSfx
    let pos, securityID = ReadOptionalField pos "48"B bs ReadSecurityID
    let pos, securityIDSource = ReadOptionalField pos "22"B bs ReadSecurityIDSource
    let pos, product = ReadOptionalField pos "460"B bs ReadProduct
    let pos, cFICode = ReadOptionalField pos "461"B bs ReadCFICode
    let pos, securityType = ReadOptionalField pos "167"B bs ReadSecurityType
    let pos, securitySubType = ReadOptionalField pos "762"B bs ReadSecuritySubType
    let pos, maturityMonthYear = ReadOptionalField pos "200"B bs ReadMaturityMonthYear
    let pos, maturityDate = ReadOptionalField pos "541"B bs ReadMaturityDate
    let pos, putOrCall = ReadOptionalField pos "201"B bs ReadPutOrCall
    let pos, couponPaymentDate = ReadOptionalField pos "224"B bs ReadCouponPaymentDate
    let pos, issueDate = ReadOptionalField pos "225"B bs ReadIssueDate
    let pos, repoCollateralSecurityType = ReadOptionalField pos "239"B bs ReadRepoCollateralSecurityType
    let pos, repurchaseTerm = ReadOptionalField pos "226"B bs ReadRepurchaseTerm
    let pos, repurchaseRate = ReadOptionalField pos "227"B bs ReadRepurchaseRate
    let pos, factor = ReadOptionalField pos "228"B bs ReadFactor
    let pos, creditRating = ReadOptionalField pos "255"B bs ReadCreditRating
    let pos, instrRegistry = ReadOptionalField pos "543"B bs ReadInstrRegistry
    let pos, countryOfIssue = ReadOptionalField pos "470"B bs ReadCountryOfIssue
    let pos, stateOrProvinceOfIssue = ReadOptionalField pos "471"B bs ReadStateOrProvinceOfIssue
    let pos, localeOfIssue = ReadOptionalField pos "472"B bs ReadLocaleOfIssue
    let pos, redemptionDate = ReadOptionalField pos "240"B bs ReadRedemptionDate
    let pos, strikePrice = ReadOptionalField pos "202"B bs ReadStrikePrice
    let pos, strikeCurrency = ReadOptionalField pos "947"B bs ReadStrikeCurrency
    let pos, optAttribute = ReadOptionalField pos "206"B bs ReadOptAttribute
    let pos, contractMultiplier = ReadOptionalField pos "231"B bs ReadContractMultiplier
    let pos, couponRate = ReadOptionalField pos "223"B bs ReadCouponRate
    let pos, securityExchange = ReadOptionalField pos "207"B bs ReadSecurityExchange
    let pos, issuer = ReadOptionalField pos "106"B bs ReadIssuer
    let pos, encodedIssuer = ReadOptionalField pos "349"B bs ReadEncodedIssuer
    let pos, securityDesc = ReadOptionalField pos "107"B bs ReadSecurityDesc
    let pos, encodedSecurityDesc = ReadOptionalField pos "351"B bs ReadEncodedSecurityDesc
    let pos, pool = ReadOptionalField pos "691"B bs ReadPool
    let pos, contractSettlMonth = ReadOptionalField pos "667"B bs ReadContractSettlMonth
    let pos, cPProgram = ReadOptionalField pos "875"B bs ReadCPProgram
    let pos, cPRegType = ReadOptionalField pos "876"B bs ReadCPRegType
    let pos, datedDate = ReadOptionalField pos "873"B bs ReadDatedDate
    let pos, interestAccrualDate = ReadOptionalField pos "874"B bs ReadInterestAccrualDate
    //let ci = {
            //Symbol = symbol
            //SymbolSfx = symbolSfx
            //SecurityID = securityID
            //SecurityIDSource = securityIDSource
            //NoSecurityAltID = noSecurityAltID
            //Product = product
            //CFICode = cFICode
            //SecurityType = securityType
            //SecuritySubType = securitySubType
            //MaturityMonthYear = maturityMonthYear
            //MaturityDate = maturityDate
            //PutOrCall = putOrCall
            //CouponPaymentDate = couponPaymentDate
            //IssueDate = issueDate
            //RepoCollateralSecurityType = repoCollateralSecurityType
            //RepurchaseTerm = repurchaseTerm
            //RepurchaseRate = repurchaseRate
            //Factor = factor
            //CreditRating = creditRating
            //InstrRegistry = instrRegistry
            //CountryOfIssue = countryOfIssue
            //StateOrProvinceOfIssue = stateOrProvinceOfIssue
            //LocaleOfIssue = localeOfIssue
            //RedemptionDate = redemptionDate
            //StrikePrice = strikePrice
            //StrikeCurrency = strikeCurrency
            //OptAttribute = optAttribute
            //ContractMultiplier = contractMultiplier
            //CouponRate = couponRate
            //SecurityExchange = securityExchange
            //Issuer = issuer
            //EncodedIssuer = encodedIssuer
            //SecurityDesc = securityDesc
            //EncodedSecurityDesc = encodedSecurityDesc
            //Pool = pool
            //ContractSettlMonth = contractSettlMonth
            //CPProgram = cPProgram
            //CPRegType = cPRegType
            //NoEvents = noEvents
            //DatedDate = datedDate
            //InterestAccrualDate = interestAccrualDate
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoStrikesGrp (pos:int) (bs:byte []) : int * NoStrikesGrp  =
    let pos, instrument = ReadInstrument pos bs    // component
    //let ci = {
            //Instrument = instrument
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoAllocsGrp (pos:int) (bs:byte []) : int * NoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "79"B bs ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "661"B bs ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField pos "736"B bs ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField pos "467"B bs ReadIndividualAllocID
    let pos, allocQty = ReadOptionalField pos "80"B bs ReadAllocQty
    //let ci = {
            //AllocAccount = allocAccount
            //AllocAcctIDSource = allocAcctIDSource
            //AllocSettlCurrency = allocSettlCurrency
            //IndividualAllocID = individualAllocID
            //NestedParties = nestedParties
            //AllocQty = allocQty
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoTradingSessionsGrp (pos:int) (bs:byte []) : int * NoTradingSessionsGrp  =
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    //let ci = {
            //TradingSessionID = tradingSessionID
            //TradingSessionSubID = tradingSessionSubID
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoUnderlyingsGrp (pos:int) (bs:byte []) : int * NoUnderlyingsGrp  =
    //let ci = {
            //UnderlyingInstrument = underlyingInstrument
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadOrderQtyData (pos:int) (bs:byte []) : int * OrderQtyData  =
    let pos, orderQty = ReadOptionalField pos "38"B bs ReadOrderQty
    let pos, cashOrderQty = ReadOptionalField pos "152"B bs ReadCashOrderQty
    let pos, orderPercent = ReadOptionalField pos "516"B bs ReadOrderPercent
    let pos, roundingDirection = ReadOptionalField pos "468"B bs ReadRoundingDirection
    let pos, roundingModulus = ReadOptionalField pos "469"B bs ReadRoundingModulus
    //let ci = {
            //OrderQty = orderQty
            //CashOrderQty = cashOrderQty
            //OrderPercent = orderPercent
            //RoundingDirection = roundingDirection
            //RoundingModulus = roundingModulus
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadSpreadOrBenchmarkCurveData (pos:int) (bs:byte []) : int * SpreadOrBenchmarkCurveData  =
    let pos, spread = ReadOptionalField pos "218"B bs ReadSpread
    let pos, benchmarkCurveCurrency = ReadOptionalField pos "220"B bs ReadBenchmarkCurveCurrency
    let pos, benchmarkCurveName = ReadOptionalField pos "221"B bs ReadBenchmarkCurveName
    let pos, benchmarkCurvePoint = ReadOptionalField pos "222"B bs ReadBenchmarkCurvePoint
    let pos, benchmarkPrice = ReadOptionalField pos "662"B bs ReadBenchmarkPrice
    let pos, benchmarkPriceType = ReadOptionalField pos "663"B bs ReadBenchmarkPriceType
    let pos, benchmarkSecurityID = ReadOptionalField pos "699"B bs ReadBenchmarkSecurityID
    let pos, benchmarkSecurityIDSource = ReadOptionalField pos "761"B bs ReadBenchmarkSecurityIDSource
    //let ci = {
            //Spread = spread
            //BenchmarkCurveCurrency = benchmarkCurveCurrency
            //BenchmarkCurveName = benchmarkCurveName
            //BenchmarkCurvePoint = benchmarkCurvePoint
            //BenchmarkPrice = benchmarkPrice
            //BenchmarkPriceType = benchmarkPriceType
            //BenchmarkSecurityID = benchmarkSecurityID
            //BenchmarkSecurityIDSource = benchmarkSecurityIDSource
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadYieldData (pos:int) (bs:byte []) : int * YieldData  =
    let pos, yieldType = ReadOptionalField pos "235"B bs ReadYieldType
    let pos, yyield = ReadOptionalField pos "236"B bs ReadYield
    let pos, yieldCalcDate = ReadOptionalField pos "701"B bs ReadYieldCalcDate
    let pos, yieldRedemptionDate = ReadOptionalField pos "696"B bs ReadYieldRedemptionDate
    let pos, yieldRedemptionPrice = ReadOptionalField pos "697"B bs ReadYieldRedemptionPrice
    let pos, yieldRedemptionPriceType = ReadOptionalField pos "698"B bs ReadYieldRedemptionPriceType
    //let ci = {
            //YieldType = yieldType
            //Yield = yyield
            //YieldCalcDate = yieldCalcDate
            //YieldRedemptionDate = yieldRedemptionDate
            //YieldRedemptionPrice = yieldRedemptionPrice
            //YieldRedemptionPriceType = yieldRedemptionPriceType
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadPegInstructions (pos:int) (bs:byte []) : int * PegInstructions  =
    let pos, pegOffsetValue = ReadOptionalField pos "211"B bs ReadPegOffsetValue
    let pos, pegMoveType = ReadOptionalField pos "835"B bs ReadPegMoveType
    let pos, pegOffsetType = ReadOptionalField pos "836"B bs ReadPegOffsetType
    let pos, pegLimitType = ReadOptionalField pos "837"B bs ReadPegLimitType
    let pos, pegRoundDirection = ReadOptionalField pos "838"B bs ReadPegRoundDirection
    let pos, pegScope = ReadOptionalField pos "840"B bs ReadPegScope
    //let ci = {
            //PegOffsetValue = pegOffsetValue
            //PegMoveType = pegMoveType
            //PegOffsetType = pegOffsetType
            //PegLimitType = pegLimitType
            //PegRoundDirection = pegRoundDirection
            //PegScope = pegScope
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadDiscretionInstructions (pos:int) (bs:byte []) : int * DiscretionInstructions  =
    let pos, discretionInst = ReadOptionalField pos "388"B bs ReadDiscretionInst
    let pos, discretionOffsetValue = ReadOptionalField pos "389"B bs ReadDiscretionOffsetValue
    let pos, discretionMoveType = ReadOptionalField pos "841"B bs ReadDiscretionMoveType
    let pos, discretionOffsetType = ReadOptionalField pos "842"B bs ReadDiscretionOffsetType
    let pos, discretionLimitType = ReadOptionalField pos "843"B bs ReadDiscretionLimitType
    let pos, discretionRoundDirection = ReadOptionalField pos "844"B bs ReadDiscretionRoundDirection
    let pos, discretionScope = ReadOptionalField pos "846"B bs ReadDiscretionScope
    //let ci = {
            //DiscretionInst = discretionInst
            //DiscretionOffsetValue = discretionOffsetValue
            //DiscretionMoveType = discretionMoveType
            //DiscretionOffsetType = discretionOffsetType
            //DiscretionLimitType = discretionLimitType
            //DiscretionRoundDirection = discretionRoundDirection
            //DiscretionScope = discretionScope
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNewOrderListNoOrdersGrp (pos:int) (bs:byte []) : int * NewOrderListNoOrdersGrp  =
    let pos, clOrdID = ReadField "ReadNewOrderListNoOrders" pos "11"B bs ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "526"B bs ReadSecondaryClOrdID
    let pos, listSeqNo = ReadField "ReadNewOrderListNoOrders" pos "67"B bs ReadListSeqNo
    let pos, clOrdLinkID = ReadOptionalField pos "583"B bs ReadClOrdLinkID
    let pos, settlInstMode = ReadOptionalField pos "160"B bs ReadSettlInstMode
    let pos, tradeOriginationDate = ReadOptionalField pos "229"B bs ReadTradeOriginationDate
    let pos, tradeDate = ReadOptionalField pos "75"B bs ReadTradeDate
    let pos, account = ReadOptionalField pos "1"B bs ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "660"B bs ReadAcctIDSource
    let pos, accountType = ReadOptionalField pos "581"B bs ReadAccountType
    let pos, dayBookingInst = ReadOptionalField pos "589"B bs ReadDayBookingInst
    let pos, bookingUnit = ReadOptionalField pos "590"B bs ReadBookingUnit
    let pos, allocID = ReadOptionalField pos "70"B bs ReadAllocID
    let pos, preallocMethod = ReadOptionalField pos "591"B bs ReadPreallocMethod
    let pos, settlType = ReadOptionalField pos "63"B bs ReadSettlType
    let pos, settlDate = ReadOptionalField pos "64"B bs ReadSettlDate
    let pos, cashMargin = ReadOptionalField pos "544"B bs ReadCashMargin
    let pos, clearingFeeIndicator = ReadOptionalField pos "635"B bs ReadClearingFeeIndicator
    let pos, handlInst = ReadOptionalField pos "21"B bs ReadHandlInst
    let pos, execInst = ReadOptionalField pos "18"B bs ReadExecInst
    let pos, minQty = ReadOptionalField pos "110"B bs ReadMinQty
    let pos, maxFloor = ReadOptionalField pos "111"B bs ReadMaxFloor
    let pos, exDestination = ReadOptionalField pos "100"B bs ReadExDestination
    let pos, processCode = ReadOptionalField pos "81"B bs ReadProcessCode
    let pos, instrument = ReadInstrument pos bs    // component
    let pos, prevClosePx = ReadOptionalField pos "140"B bs ReadPrevClosePx
    let pos, side = ReadField "ReadNewOrderListNoOrders" pos "54"B bs ReadSide
    let pos, sideValueInd = ReadOptionalField pos "401"B bs ReadSideValueInd
    let pos, locateReqd = ReadOptionalField pos "114"B bs ReadLocateReqd
    let pos, transactTime = ReadOptionalField pos "60"B bs ReadTransactTime
    let pos, qtyType = ReadOptionalField pos "854"B bs ReadQtyType
    let pos, orderQtyData = ReadOrderQtyData pos bs    // component
    let pos, ordType = ReadOptionalField pos "40"B bs ReadOrdType
    let pos, priceType = ReadOptionalField pos "423"B bs ReadPriceType
    let pos, price = ReadOptionalField pos "44"B bs ReadPrice
    let pos, stopPx = ReadOptionalField pos "99"B bs ReadStopPx
    let pos, currency = ReadOptionalField pos "15"B bs ReadCurrency
    let pos, complianceID = ReadOptionalField pos "376"B bs ReadComplianceID
    let pos, solicitedFlag = ReadOptionalField pos "377"B bs ReadSolicitedFlag
    let pos, iOIid = ReadOptionalField pos "23"B bs ReadIOIid
    let pos, quoteID = ReadOptionalField pos "117"B bs ReadQuoteID
    let pos, timeInForce = ReadOptionalField pos "59"B bs ReadTimeInForce
    let pos, effectiveTime = ReadOptionalField pos "168"B bs ReadEffectiveTime
    let pos, expireDate = ReadOptionalField pos "432"B bs ReadExpireDate
    let pos, expireTime = ReadOptionalField pos "126"B bs ReadExpireTime
    let pos, gTBookingInst = ReadOptionalField pos "427"B bs ReadGTBookingInst
    let pos, orderCapacity = ReadOptionalField pos "528"B bs ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField pos "529"B bs ReadOrderRestrictions
    let pos, custOrderCapacity = ReadOptionalField pos "582"B bs ReadCustOrderCapacity
    let pos, forexReq = ReadOptionalField pos "121"B bs ReadForexReq
    let pos, settlCurrency = ReadOptionalField pos "120"B bs ReadSettlCurrency
    let pos, bookingType = ReadOptionalField pos "775"B bs ReadBookingType
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    let pos, settlDate2 = ReadOptionalField pos "193"B bs ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField pos "192"B bs ReadOrderQty2
    let pos, price2 = ReadOptionalField pos "640"B bs ReadPrice2
    let pos, positionEffect = ReadOptionalField pos "77"B bs ReadPositionEffect
    let pos, coveredOrUncovered = ReadOptionalField pos "203"B bs ReadCoveredOrUncovered
    let pos, maxShow = ReadOptionalField pos "210"B bs ReadMaxShow
    let pos, targetStrategy = ReadOptionalField pos "847"B bs ReadTargetStrategy
    let pos, targetStrategyParameters = ReadOptionalField pos "848"B bs ReadTargetStrategyParameters
    let pos, participationRate = ReadOptionalField pos "849"B bs ReadParticipationRate
    let pos, designation = ReadOptionalField pos "494"B bs ReadDesignation
    //let ci = {
            //ClOrdID = clOrdID
            //SecondaryClOrdID = secondaryClOrdID
            //ListSeqNo = listSeqNo
            //ClOrdLinkID = clOrdLinkID
            //SettlInstMode = settlInstMode
            //Parties = parties
            //TradeOriginationDate = tradeOriginationDate
            //TradeDate = tradeDate
            //Account = account
            //AcctIDSource = acctIDSource
            //AccountType = accountType
            //DayBookingInst = dayBookingInst
            //BookingUnit = bookingUnit
            //AllocID = allocID
            //PreallocMethod = preallocMethod
            //NoAllocs = noAllocs
            //SettlType = settlType
            //SettlDate = settlDate
            //CashMargin = cashMargin
            //ClearingFeeIndicator = clearingFeeIndicator
            //HandlInst = handlInst
            //ExecInst = execInst
            //MinQty = minQty
            //MaxFloor = maxFloor
            //ExDestination = exDestination
            //NoTradingSessions = noTradingSessions
            //ProcessCode = processCode
            //Instrument = instrument
            //NoUnderlyings = noUnderlyings
            //PrevClosePx = prevClosePx
            //Side = side
            //SideValueInd = sideValueInd
            //LocateReqd = locateReqd
            //TransactTime = transactTime
            //Stipulations = stipulations
            //QtyType = qtyType
            //OrderQtyData = orderQtyData
            //OrdType = ordType
            //PriceType = priceType
            //Price = price
            //StopPx = stopPx
            //SpreadOrBenchmarkCurveData = spreadOrBenchmarkCurveData
            //YieldData = yieldData
            //Currency = currency
            //ComplianceID = complianceID
            //SolicitedFlag = solicitedFlag
            //IOIid = iOIid
            //QuoteID = quoteID
            //TimeInForce = timeInForce
            //EffectiveTime = effectiveTime
            //ExpireDate = expireDate
            //ExpireTime = expireTime
            //GTBookingInst = gTBookingInst
            //CommissionData = commissionData
            //OrderCapacity = orderCapacity
            //OrderRestrictions = orderRestrictions
            //CustOrderCapacity = custOrderCapacity
            //ForexReq = forexReq
            //SettlCurrency = settlCurrency
            //BookingType = bookingType
            //Text = text
            //EncodedText = encodedText
            //SettlDate2 = settlDate2
            //OrderQty2 = orderQty2
            //Price2 = price2
            //PositionEffect = positionEffect
            //CoveredOrUncovered = coveredOrUncovered
            //MaxShow = maxShow
            //PegInstructions = pegInstructions
            //DiscretionInstructions = discretionInstructions
            //TargetStrategy = targetStrategy
            //TargetStrategyParameters = targetStrategyParameters
            //ParticipationRate = participationRate
            //Designation = designation
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadBidResponseNoBidComponentsGrp (pos:int) (bs:byte []) : int * BidResponseNoBidComponentsGrp  =
    let pos, commissionData = ReadCommissionData pos bs    // component
    let pos, listID = ReadOptionalField pos "66"B bs ReadListID
    let pos, country = ReadOptionalField pos "421"B bs ReadCountry
    let pos, side = ReadOptionalField pos "54"B bs ReadSide
    let pos, price = ReadOptionalField pos "44"B bs ReadPrice
    let pos, priceType = ReadOptionalField pos "423"B bs ReadPriceType
    let pos, fairValue = ReadOptionalField pos "406"B bs ReadFairValue
    let pos, netGrossInd = ReadOptionalField pos "430"B bs ReadNetGrossInd
    let pos, settlType = ReadOptionalField pos "63"B bs ReadSettlType
    let pos, settlDate = ReadOptionalField pos "64"B bs ReadSettlDate
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    //let ci = {
            //CommissionData = commissionData
            //ListID = listID
            //Country = country
            //Side = side
            //Price = price
            //PriceType = priceType
            //FairValue = fairValue
            //NetGrossInd = netGrossInd
            //SettlType = settlType
            //SettlDate = settlDate
            //TradingSessionID = tradingSessionID
            //TradingSessionSubID = tradingSessionSubID
            //Text = text
            //EncodedText = encodedText
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoLegAllocsGrp (pos:int) (bs:byte []) : int * NoLegAllocsGrp  =
    let pos, legAllocAccount = ReadOptionalField pos "671"B bs ReadLegAllocAccount
    let pos, legIndividualAllocID = ReadOptionalField pos "672"B bs ReadLegIndividualAllocID
    let pos, legAllocQty = ReadOptionalField pos "673"B bs ReadLegAllocQty
    let pos, legAllocAcctIDSource = ReadOptionalField pos "674"B bs ReadLegAllocAcctIDSource
    let pos, legSettlCurrency = ReadOptionalField pos "675"B bs ReadLegSettlCurrency
    //let ci = {
            //LegAllocAccount = legAllocAccount
            //LegIndividualAllocID = legIndividualAllocID
            //NestedParties2 = nestedParties2
            //LegAllocQty = legAllocQty
            //LegAllocAcctIDSource = legAllocAcctIDSource
            //LegSettlCurrency = legSettlCurrency
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadMultilegOrderCancelReplaceRequestNoLegsGrp (pos:int) (bs:byte []) : int * MultilegOrderCancelReplaceRequestNoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "687"B bs ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legPositionEffect = ReadOptionalField pos "564"B bs ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField pos "565"B bs ReadLegCoveredOrUncovered
    let pos, legRefID = ReadOptionalField pos "654"B bs ReadLegRefID
    let pos, legPrice = ReadOptionalField pos "566"B bs ReadLegPrice
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "588"B bs ReadLegSettlDate
    //let ci = {
            //InstrumentLeg = instrumentLeg
            //LegQty = legQty
            //LegSwapType = legSwapType
            //LegStipulations = legStipulations
            //NoLegAllocs = noLegAllocs
            //LegPositionEffect = legPositionEffect
            //LegCoveredOrUncovered = legCoveredOrUncovered
            //NestedParties = nestedParties
            //LegRefID = legRefID
            //LegPrice = legPrice
            //LegSettlType = legSettlType
            //LegSettlDate = legSettlDate
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoNested3PartySubIDsGrp (pos:int) (bs:byte []) : int * NoNested3PartySubIDsGrp  =
    let pos, nested3PartySubID = ReadOptionalField pos "953"B bs ReadNested3PartySubID
    let pos, nested3PartySubIDType = ReadOptionalField pos "954"B bs ReadNested3PartySubIDType
    //let ci = {
            //Nested3PartySubID = nested3PartySubID
            //Nested3PartySubIDType = nested3PartySubIDType
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoNested3PartyIDsGrp (pos:int) (bs:byte []) : int * NoNested3PartyIDsGrp  =
    let pos, nested3PartyID = ReadOptionalField pos "949"B bs ReadNested3PartyID
    let pos, nested3PartyIDSource = ReadOptionalField pos "950"B bs ReadNested3PartyIDSource
    let pos, nested3PartyRole = ReadOptionalField pos "951"B bs ReadNested3PartyRole
    //let ci = {
            //Nested3PartyID = nested3PartyID
            //Nested3PartyIDSource = nested3PartyIDSource
            //Nested3PartyRole = nested3PartyRole
            //NoNested3PartySubIDs = noNested3PartySubIDs
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadNestedParties3 (pos:int) (bs:byte []) : int * NestedParties3  =
    //let ci = {
            //NoNested3PartyIDs = noNested3PartyIDs
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadMultilegOrderCancelReplaceRequestNoAllocsGrp (pos:int) (bs:byte []) : int * MultilegOrderCancelReplaceRequestNoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "79"B bs ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "661"B bs ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField pos "736"B bs ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField pos "467"B bs ReadIndividualAllocID
    let pos, allocQty = ReadOptionalField pos "80"B bs ReadAllocQty
    //let ci = {
            //AllocAccount = allocAccount
            //AllocAcctIDSource = allocAcctIDSource
            //AllocSettlCurrency = allocSettlCurrency
            //IndividualAllocID = individualAllocID
            //NestedParties3 = nestedParties3
            //AllocQty = allocQty
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNewOrderMultilegNoLegsGrp (pos:int) (bs:byte []) : int * NewOrderMultilegNoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "687"B bs ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legPositionEffect = ReadOptionalField pos "564"B bs ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField pos "565"B bs ReadLegCoveredOrUncovered
    let pos, legRefID = ReadOptionalField pos "654"B bs ReadLegRefID
    let pos, legPrice = ReadOptionalField pos "566"B bs ReadLegPrice
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "588"B bs ReadLegSettlDate
    //let ci = {
            //InstrumentLeg = instrumentLeg
            //LegQty = legQty
            //LegSwapType = legSwapType
            //LegStipulations = legStipulations
            //NoLegAllocs = noLegAllocs
            //LegPositionEffect = legPositionEffect
            //LegCoveredOrUncovered = legCoveredOrUncovered
            //NestedParties = nestedParties
            //LegRefID = legRefID
            //LegPrice = legPrice
            //LegSettlType = legSettlType
            //LegSettlDate = legSettlDate
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNewOrderMultilegNoAllocsGrp (pos:int) (bs:byte []) : int * NewOrderMultilegNoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "79"B bs ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "661"B bs ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField pos "736"B bs ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField pos "467"B bs ReadIndividualAllocID
    let pos, allocQty = ReadOptionalField pos "80"B bs ReadAllocQty
    //let ci = {
            //AllocAccount = allocAccount
            //AllocAcctIDSource = allocAcctIDSource
            //AllocSettlCurrency = allocSettlCurrency
            //IndividualAllocID = individualAllocID
            //NestedParties3 = nestedParties3
            //AllocQty = allocQty
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadCrossOrderCancelRequestNoSidesGrp (pos:int) (bs:byte []) : int * CrossOrderCancelRequestNoSidesGrp  =
    let pos, side = ReadField "ReadCrossOrderCancelRequestNoSides" pos "54"B bs ReadSide
    let pos, origClOrdID = ReadField "ReadCrossOrderCancelRequestNoSides" pos "41"B bs ReadOrigClOrdID
    let pos, clOrdID = ReadField "ReadCrossOrderCancelRequestNoSides" pos "11"B bs ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "526"B bs ReadSecondaryClOrdID
    let pos, clOrdLinkID = ReadOptionalField pos "583"B bs ReadClOrdLinkID
    let pos, origOrdModTime = ReadOptionalField pos "586"B bs ReadOrigOrdModTime
    let pos, tradeOriginationDate = ReadOptionalField pos "229"B bs ReadTradeOriginationDate
    let pos, tradeDate = ReadOptionalField pos "75"B bs ReadTradeDate
    let pos, orderQtyData = ReadOrderQtyData pos bs    // component
    let pos, complianceID = ReadOptionalField pos "376"B bs ReadComplianceID
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    //let ci = {
            //Side = side
            //OrigClOrdID = origClOrdID
            //ClOrdID = clOrdID
            //SecondaryClOrdID = secondaryClOrdID
            //ClOrdLinkID = clOrdLinkID
            //OrigOrdModTime = origOrdModTime
            //Parties = parties
            //TradeOriginationDate = tradeOriginationDate
            //TradeDate = tradeDate
            //OrderQtyData = orderQtyData
            //ComplianceID = complianceID
            //Text = text
            //EncodedText = encodedText
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadCrossOrderCancelReplaceRequestNoSidesGrp (pos:int) (bs:byte []) : int * CrossOrderCancelReplaceRequestNoSidesGrp  =
    let pos, side = ReadField "ReadCrossOrderCancelReplaceRequestNoSides" pos "54"B bs ReadSide
    let pos, origClOrdID = ReadField "ReadCrossOrderCancelReplaceRequestNoSides" pos "41"B bs ReadOrigClOrdID
    let pos, clOrdID = ReadField "ReadCrossOrderCancelReplaceRequestNoSides" pos "11"B bs ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "526"B bs ReadSecondaryClOrdID
    let pos, clOrdLinkID = ReadOptionalField pos "583"B bs ReadClOrdLinkID
    let pos, origOrdModTime = ReadOptionalField pos "586"B bs ReadOrigOrdModTime
    let pos, tradeOriginationDate = ReadOptionalField pos "229"B bs ReadTradeOriginationDate
    let pos, tradeDate = ReadOptionalField pos "75"B bs ReadTradeDate
    let pos, account = ReadOptionalField pos "1"B bs ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "660"B bs ReadAcctIDSource
    let pos, accountType = ReadOptionalField pos "581"B bs ReadAccountType
    let pos, dayBookingInst = ReadOptionalField pos "589"B bs ReadDayBookingInst
    let pos, bookingUnit = ReadOptionalField pos "590"B bs ReadBookingUnit
    let pos, preallocMethod = ReadOptionalField pos "591"B bs ReadPreallocMethod
    let pos, allocID = ReadOptionalField pos "70"B bs ReadAllocID
    let pos, qtyType = ReadOptionalField pos "854"B bs ReadQtyType
    let pos, orderQtyData = ReadOrderQtyData pos bs    // component
    let pos, orderCapacity = ReadOptionalField pos "528"B bs ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField pos "529"B bs ReadOrderRestrictions
    let pos, custOrderCapacity = ReadOptionalField pos "582"B bs ReadCustOrderCapacity
    let pos, forexReq = ReadOptionalField pos "121"B bs ReadForexReq
    let pos, settlCurrency = ReadOptionalField pos "120"B bs ReadSettlCurrency
    let pos, bookingType = ReadOptionalField pos "775"B bs ReadBookingType
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    let pos, positionEffect = ReadOptionalField pos "77"B bs ReadPositionEffect
    let pos, coveredOrUncovered = ReadOptionalField pos "203"B bs ReadCoveredOrUncovered
    let pos, cashMargin = ReadOptionalField pos "544"B bs ReadCashMargin
    let pos, clearingFeeIndicator = ReadOptionalField pos "635"B bs ReadClearingFeeIndicator
    let pos, solicitedFlag = ReadOptionalField pos "377"B bs ReadSolicitedFlag
    let pos, sideComplianceID = ReadOptionalField pos "659"B bs ReadSideComplianceID
    //let ci = {
            //Side = side
            //OrigClOrdID = origClOrdID
            //ClOrdID = clOrdID
            //SecondaryClOrdID = secondaryClOrdID
            //ClOrdLinkID = clOrdLinkID
            //OrigOrdModTime = origOrdModTime
            //Parties = parties
            //TradeOriginationDate = tradeOriginationDate
            //TradeDate = tradeDate
            //Account = account
            //AcctIDSource = acctIDSource
            //AccountType = accountType
            //DayBookingInst = dayBookingInst
            //BookingUnit = bookingUnit
            //PreallocMethod = preallocMethod
            //AllocID = allocID
            //NoAllocs = noAllocs
            //QtyType = qtyType
            //OrderQtyData = orderQtyData
            //CommissionData = commissionData
            //OrderCapacity = orderCapacity
            //OrderRestrictions = orderRestrictions
            //CustOrderCapacity = custOrderCapacity
            //ForexReq = forexReq
            //SettlCurrency = settlCurrency
            //BookingType = bookingType
            //Text = text
            //EncodedText = encodedText
            //PositionEffect = positionEffect
            //CoveredOrUncovered = coveredOrUncovered
            //CashMargin = cashMargin
            //ClearingFeeIndicator = clearingFeeIndicator
            //SolicitedFlag = solicitedFlag
            //SideComplianceID = sideComplianceID
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoSidesGrp (pos:int) (bs:byte []) : int * NoSidesGrp  =
    let pos, side = ReadField "ReadNoSides" pos "54"B bs ReadSide
    let pos, clOrdID = ReadField "ReadNoSides" pos "11"B bs ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "526"B bs ReadSecondaryClOrdID
    let pos, clOrdLinkID = ReadOptionalField pos "583"B bs ReadClOrdLinkID
    let pos, tradeOriginationDate = ReadOptionalField pos "229"B bs ReadTradeOriginationDate
    let pos, tradeDate = ReadOptionalField pos "75"B bs ReadTradeDate
    let pos, account = ReadOptionalField pos "1"B bs ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "660"B bs ReadAcctIDSource
    let pos, accountType = ReadOptionalField pos "581"B bs ReadAccountType
    let pos, dayBookingInst = ReadOptionalField pos "589"B bs ReadDayBookingInst
    let pos, bookingUnit = ReadOptionalField pos "590"B bs ReadBookingUnit
    let pos, preallocMethod = ReadOptionalField pos "591"B bs ReadPreallocMethod
    let pos, allocID = ReadOptionalField pos "70"B bs ReadAllocID
    let pos, qtyType = ReadOptionalField pos "854"B bs ReadQtyType
    let pos, orderQtyData = ReadOrderQtyData pos bs    // component
    let pos, orderCapacity = ReadOptionalField pos "528"B bs ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField pos "529"B bs ReadOrderRestrictions
    let pos, custOrderCapacity = ReadOptionalField pos "582"B bs ReadCustOrderCapacity
    let pos, forexReq = ReadOptionalField pos "121"B bs ReadForexReq
    let pos, settlCurrency = ReadOptionalField pos "120"B bs ReadSettlCurrency
    let pos, bookingType = ReadOptionalField pos "775"B bs ReadBookingType
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    let pos, positionEffect = ReadOptionalField pos "77"B bs ReadPositionEffect
    let pos, coveredOrUncovered = ReadOptionalField pos "203"B bs ReadCoveredOrUncovered
    let pos, cashMargin = ReadOptionalField pos "544"B bs ReadCashMargin
    let pos, clearingFeeIndicator = ReadOptionalField pos "635"B bs ReadClearingFeeIndicator
    let pos, solicitedFlag = ReadOptionalField pos "377"B bs ReadSolicitedFlag
    let pos, sideComplianceID = ReadOptionalField pos "659"B bs ReadSideComplianceID
    //let ci = {
            //Side = side
            //ClOrdID = clOrdID
            //SecondaryClOrdID = secondaryClOrdID
            //ClOrdLinkID = clOrdLinkID
            //Parties = parties
            //TradeOriginationDate = tradeOriginationDate
            //TradeDate = tradeDate
            //Account = account
            //AcctIDSource = acctIDSource
            //AccountType = accountType
            //DayBookingInst = dayBookingInst
            //BookingUnit = bookingUnit
            //PreallocMethod = preallocMethod
            //AllocID = allocID
            //NoAllocs = noAllocs
            //QtyType = qtyType
            //OrderQtyData = orderQtyData
            //CommissionData = commissionData
            //OrderCapacity = orderCapacity
            //OrderRestrictions = orderRestrictions
            //CustOrderCapacity = custOrderCapacity
            //ForexReq = forexReq
            //SettlCurrency = settlCurrency
            //BookingType = bookingType
            //Text = text
            //EncodedText = encodedText
            //PositionEffect = positionEffect
            //CoveredOrUncovered = coveredOrUncovered
            //CashMargin = cashMargin
            //ClearingFeeIndicator = clearingFeeIndicator
            //SolicitedFlag = solicitedFlag
            //SideComplianceID = sideComplianceID
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadExecutionReportNoLegsGrp (pos:int) (bs:byte []) : int * ExecutionReportNoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "687"B bs ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legPositionEffect = ReadOptionalField pos "564"B bs ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField pos "565"B bs ReadLegCoveredOrUncovered
    let pos, legRefID = ReadOptionalField pos "654"B bs ReadLegRefID
    let pos, legPrice = ReadOptionalField pos "566"B bs ReadLegPrice
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "588"B bs ReadLegSettlDate
    let pos, legLastPx = ReadOptionalField pos "637"B bs ReadLegLastPx
    //let ci = {
            //InstrumentLeg = instrumentLeg
            //LegQty = legQty
            //LegSwapType = legSwapType
            //LegStipulations = legStipulations
            //LegPositionEffect = legPositionEffect
            //LegCoveredOrUncovered = legCoveredOrUncovered
            //NestedParties = nestedParties
            //LegRefID = legRefID
            //LegPrice = legPrice
            //LegSettlType = legSettlType
            //LegSettlDate = legSettlDate
            //LegLastPx = legLastPx
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoInstrAttribGrp (pos:int) (bs:byte []) : int * NoInstrAttribGrp  =
    let pos, instrAttribType = ReadOptionalField pos "871"B bs ReadInstrAttribType
    let pos, instrAttribValue = ReadOptionalField pos "872"B bs ReadInstrAttribValue
    //let ci = {
            //InstrAttribType = instrAttribType
            //InstrAttribValue = instrAttribValue
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadInstrumentExtension (pos:int) (bs:byte []) : int * InstrumentExtension  =
    let pos, deliveryForm = ReadOptionalField pos "668"B bs ReadDeliveryForm
    let pos, pctAtRisk = ReadOptionalField pos "869"B bs ReadPctAtRisk
    //let ci = {
            //DeliveryForm = deliveryForm
            //PctAtRisk = pctAtRisk
            //NoInstrAttrib = noInstrAttrib
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoLegsGrp (pos:int) (bs:byte []) : int * NoLegsGrp  =
    //let ci = {
            //InstrumentLeg = instrumentLeg
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadDerivativeSecurityListNoRelatedSymGrp (pos:int) (bs:byte []) : int * DerivativeSecurityListNoRelatedSymGrp  =
    let pos, currency = ReadOptionalField pos "15"B bs ReadCurrency
    let pos, expirationCycle = ReadOptionalField pos "827"B bs ReadExpirationCycle
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    //let ci = {
            //Instrument = instrument
            //Currency = currency
            //ExpirationCycle = expirationCycle
            //InstrumentExtension = instrumentExtension
            //NoLegs = noLegs
            //TradingSessionID = tradingSessionID
            //TradingSessionSubID = tradingSessionSubID
            //Text = text
            //EncodedText = encodedText
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadFinancingDetails (pos:int) (bs:byte []) : int * FinancingDetails  =
    let pos, agreementDesc = ReadOptionalField pos "913"B bs ReadAgreementDesc
    let pos, agreementID = ReadOptionalField pos "914"B bs ReadAgreementID
    let pos, agreementDate = ReadOptionalField pos "915"B bs ReadAgreementDate
    let pos, agreementCurrency = ReadOptionalField pos "918"B bs ReadAgreementCurrency
    let pos, terminationType = ReadOptionalField pos "788"B bs ReadTerminationType
    let pos, startDate = ReadOptionalField pos "916"B bs ReadStartDate
    let pos, endDate = ReadOptionalField pos "917"B bs ReadEndDate
    let pos, deliveryType = ReadOptionalField pos "919"B bs ReadDeliveryType
    let pos, marginRatio = ReadOptionalField pos "898"B bs ReadMarginRatio
    //let ci = {
            //AgreementDesc = agreementDesc
            //AgreementID = agreementID
            //AgreementDate = agreementDate
            //AgreementCurrency = agreementCurrency
            //TerminationType = terminationType
            //StartDate = startDate
            //EndDate = endDate
            //DeliveryType = deliveryType
            //MarginRatio = marginRatio
    //}
    //pos, ci
    failwith "not implemented"


// component
let ReadLegBenchmarkCurveData (pos:int) (bs:byte []) : int * LegBenchmarkCurveData  =
    let pos, legBenchmarkCurveCurrency = ReadOptionalField pos "676"B bs ReadLegBenchmarkCurveCurrency
    let pos, legBenchmarkCurveName = ReadOptionalField pos "677"B bs ReadLegBenchmarkCurveName
    let pos, legBenchmarkCurvePoint = ReadOptionalField pos "678"B bs ReadLegBenchmarkCurvePoint
    let pos, legBenchmarkPrice = ReadOptionalField pos "679"B bs ReadLegBenchmarkPrice
    let pos, legBenchmarkPriceType = ReadOptionalField pos "680"B bs ReadLegBenchmarkPriceType
    //let ci = {
            //LegBenchmarkCurveCurrency = legBenchmarkCurveCurrency
            //LegBenchmarkCurveName = legBenchmarkCurveName
            //LegBenchmarkCurvePoint = legBenchmarkCurvePoint
            //LegBenchmarkPrice = legBenchmarkPrice
            //LegBenchmarkPriceType = legBenchmarkPriceType
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadSecurityListNoLegsGrp (pos:int) (bs:byte []) : int * SecurityListNoLegsGrp  =
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    //let ci = {
            //InstrumentLeg = instrumentLeg
            //LegSwapType = legSwapType
            //LegSettlType = legSettlType
            //LegStipulations = legStipulations
            //LegBenchmarkCurveData = legBenchmarkCurveData
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadSecurityListNoRelatedSymGrp (pos:int) (bs:byte []) : int * SecurityListNoRelatedSymGrp  =
    let pos, currency = ReadOptionalField pos "15"B bs ReadCurrency
    let pos, roundLot = ReadOptionalField pos "561"B bs ReadRoundLot
    let pos, minTradeVol = ReadOptionalField pos "562"B bs ReadMinTradeVol
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    let pos, expirationCycle = ReadOptionalField pos "827"B bs ReadExpirationCycle
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    //let ci = {
            //Instrument = instrument
            //InstrumentExtension = instrumentExtension
            //FinancingDetails = financingDetails
            //NoUnderlyings = noUnderlyings
            //Currency = currency
            //Stipulations = stipulations
            //SecurityListNoLegs = securityListNoLegs
            //SpreadOrBenchmarkCurveData = spreadOrBenchmarkCurveData
            //YieldData = yieldData
            //RoundLot = roundLot
            //MinTradeVol = minTradeVol
            //TradingSessionID = tradingSessionID
            //TradingSessionSubID = tradingSessionSubID
            //ExpirationCycle = expirationCycle
            //Text = text
            //EncodedText = encodedText
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadMarketDataIncrementalRefreshNoMDEntriesGrp (pos:int) (bs:byte []) : int * MarketDataIncrementalRefreshNoMDEntriesGrp  =
    let pos, mDUpdateAction = ReadField "ReadMarketDataIncrementalRefreshNoMDEntries" pos "279"B bs ReadMDUpdateAction
    let pos, deleteReason = ReadOptionalField pos "285"B bs ReadDeleteReason
    let pos, mDEntryType = ReadOptionalField pos "269"B bs ReadMDEntryType
    let pos, mDEntryID = ReadOptionalField pos "278"B bs ReadMDEntryID
    let pos, mDEntryRefID = ReadOptionalField pos "280"B bs ReadMDEntryRefID
    let pos, financialStatus = ReadOptionalField pos "291"B bs ReadFinancialStatus
    let pos, corporateAction = ReadOptionalField pos "292"B bs ReadCorporateAction
    let pos, mDEntryPx = ReadOptionalField pos "270"B bs ReadMDEntryPx
    let pos, currency = ReadOptionalField pos "15"B bs ReadCurrency
    let pos, mDEntrySize = ReadOptionalField pos "271"B bs ReadMDEntrySize
    let pos, mDEntryDate = ReadOptionalField pos "272"B bs ReadMDEntryDate
    let pos, mDEntryTime = ReadOptionalField pos "273"B bs ReadMDEntryTime
    let pos, tickDirection = ReadOptionalField pos "274"B bs ReadTickDirection
    let pos, mDMkt = ReadOptionalField pos "275"B bs ReadMDMkt
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    let pos, quoteCondition = ReadOptionalField pos "276"B bs ReadQuoteCondition
    let pos, tradeCondition = ReadOptionalField pos "277"B bs ReadTradeCondition
    let pos, mDEntryOriginator = ReadOptionalField pos "282"B bs ReadMDEntryOriginator
    let pos, locationID = ReadOptionalField pos "283"B bs ReadLocationID
    let pos, deskID = ReadOptionalField pos "284"B bs ReadDeskID
    let pos, openCloseSettlFlag = ReadOptionalField pos "286"B bs ReadOpenCloseSettlFlag
    let pos, timeInForce = ReadOptionalField pos "59"B bs ReadTimeInForce
    let pos, expireDate = ReadOptionalField pos "432"B bs ReadExpireDate
    let pos, expireTime = ReadOptionalField pos "126"B bs ReadExpireTime
    let pos, minQty = ReadOptionalField pos "110"B bs ReadMinQty
    let pos, execInst = ReadOptionalField pos "18"B bs ReadExecInst
    let pos, sellerDays = ReadOptionalField pos "287"B bs ReadSellerDays
    let pos, orderID = ReadOptionalField pos "37"B bs ReadOrderID
    let pos, quoteEntryID = ReadOptionalField pos "299"B bs ReadQuoteEntryID
    let pos, mDEntryBuyer = ReadOptionalField pos "288"B bs ReadMDEntryBuyer
    let pos, mDEntrySeller = ReadOptionalField pos "289"B bs ReadMDEntrySeller
    let pos, numberOfOrders = ReadOptionalField pos "346"B bs ReadNumberOfOrders
    let pos, mDEntryPositionNo = ReadOptionalField pos "290"B bs ReadMDEntryPositionNo
    let pos, scope = ReadOptionalField pos "546"B bs ReadScope
    let pos, priceDelta = ReadOptionalField pos "811"B bs ReadPriceDelta
    let pos, netChgPrevDay = ReadOptionalField pos "451"B bs ReadNetChgPrevDay
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    //let ci = {
            //MDUpdateAction = mDUpdateAction
            //DeleteReason = deleteReason
            //MDEntryType = mDEntryType
            //MDEntryID = mDEntryID
            //MDEntryRefID = mDEntryRefID
            //Instrument = instrument
            //NoUnderlyings = noUnderlyings
            //NoLegs = noLegs
            //FinancialStatus = financialStatus
            //CorporateAction = corporateAction
            //MDEntryPx = mDEntryPx
            //Currency = currency
            //MDEntrySize = mDEntrySize
            //MDEntryDate = mDEntryDate
            //MDEntryTime = mDEntryTime
            //TickDirection = tickDirection
            //MDMkt = mDMkt
            //TradingSessionID = tradingSessionID
            //TradingSessionSubID = tradingSessionSubID
            //QuoteCondition = quoteCondition
            //TradeCondition = tradeCondition
            //MDEntryOriginator = mDEntryOriginator
            //LocationID = locationID
            //DeskID = deskID
            //OpenCloseSettlFlag = openCloseSettlFlag
            //TimeInForce = timeInForce
            //ExpireDate = expireDate
            //ExpireTime = expireTime
            //MinQty = minQty
            //ExecInst = execInst
            //SellerDays = sellerDays
            //OrderID = orderID
            //QuoteEntryID = quoteEntryID
            //MDEntryBuyer = mDEntryBuyer
            //MDEntrySeller = mDEntrySeller
            //NumberOfOrders = numberOfOrders
            //MDEntryPositionNo = mDEntryPositionNo
            //Scope = scope
            //PriceDelta = priceDelta
            //NetChgPrevDay = netChgPrevDay
            //Text = text
            //EncodedText = encodedText
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadMarketDataRequestNoRelatedSymGrp (pos:int) (bs:byte []) : int * MarketDataRequestNoRelatedSymGrp  =
    let pos, instrument = ReadInstrument pos bs    // component
    //let ci = {
            //Instrument = instrument
            //NoUnderlyings = noUnderlyings
            //NoLegs = noLegs
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadMassQuoteAcknowledgementNoQuoteEntriesGrp (pos:int) (bs:byte []) : int * MassQuoteAcknowledgementNoQuoteEntriesGrp  =
    let pos, quoteEntryID = ReadOptionalField pos "299"B bs ReadQuoteEntryID
    let pos, bidPx = ReadOptionalField pos "132"B bs ReadBidPx
    let pos, offerPx = ReadOptionalField pos "133"B bs ReadOfferPx
    let pos, bidSize = ReadOptionalField pos "134"B bs ReadBidSize
    let pos, offerSize = ReadOptionalField pos "135"B bs ReadOfferSize
    let pos, validUntilTime = ReadOptionalField pos "62"B bs ReadValidUntilTime
    let pos, bidSpotRate = ReadOptionalField pos "188"B bs ReadBidSpotRate
    let pos, offerSpotRate = ReadOptionalField pos "190"B bs ReadOfferSpotRate
    let pos, bidForwardPoints = ReadOptionalField pos "189"B bs ReadBidForwardPoints
    let pos, offerForwardPoints = ReadOptionalField pos "191"B bs ReadOfferForwardPoints
    let pos, midPx = ReadOptionalField pos "631"B bs ReadMidPx
    let pos, bidYield = ReadOptionalField pos "632"B bs ReadBidYield
    let pos, midYield = ReadOptionalField pos "633"B bs ReadMidYield
    let pos, offerYield = ReadOptionalField pos "634"B bs ReadOfferYield
    let pos, transactTime = ReadOptionalField pos "60"B bs ReadTransactTime
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    let pos, settlDate = ReadOptionalField pos "64"B bs ReadSettlDate
    let pos, ordType = ReadOptionalField pos "40"B bs ReadOrdType
    let pos, settlDate2 = ReadOptionalField pos "193"B bs ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField pos "192"B bs ReadOrderQty2
    let pos, bidForwardPoints2 = ReadOptionalField pos "642"B bs ReadBidForwardPoints2
    let pos, offerForwardPoints2 = ReadOptionalField pos "643"B bs ReadOfferForwardPoints2
    let pos, currency = ReadOptionalField pos "15"B bs ReadCurrency
    let pos, quoteEntryRejectReason = ReadOptionalField pos "368"B bs ReadQuoteEntryRejectReason
    //let ci = {
            //QuoteEntryID = quoteEntryID
            //Instrument = instrument
            //NoLegs = noLegs
            //BidPx = bidPx
            //OfferPx = offerPx
            //BidSize = bidSize
            //OfferSize = offerSize
            //ValidUntilTime = validUntilTime
            //BidSpotRate = bidSpotRate
            //OfferSpotRate = offerSpotRate
            //BidForwardPoints = bidForwardPoints
            //OfferForwardPoints = offerForwardPoints
            //MidPx = midPx
            //BidYield = bidYield
            //MidYield = midYield
            //OfferYield = offerYield
            //TransactTime = transactTime
            //TradingSessionID = tradingSessionID
            //TradingSessionSubID = tradingSessionSubID
            //SettlDate = settlDate
            //OrdType = ordType
            //SettlDate2 = settlDate2
            //OrderQty2 = orderQty2
            //BidForwardPoints2 = bidForwardPoints2
            //OfferForwardPoints2 = offerForwardPoints2
            //Currency = currency
            //QuoteEntryRejectReason = quoteEntryRejectReason
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadMassQuoteAcknowledgementNoQuoteSetsGrp (pos:int) (bs:byte []) : int * MassQuoteAcknowledgementNoQuoteSetsGrp  =
    let pos, quoteSetID = ReadOptionalField pos "302"B bs ReadQuoteSetID
    let pos, totNoQuoteEntries = ReadOptionalField pos "304"B bs ReadTotNoQuoteEntries
    let pos, lastFragment = ReadOptionalField pos "893"B bs ReadLastFragment
    //let ci = {
            //QuoteSetID = quoteSetID
            //UnderlyingInstrument = underlyingInstrument
            //TotNoQuoteEntries = totNoQuoteEntries
            //LastFragment = lastFragment
            //MassQuoteAcknowledgementNoQuoteEntries = massQuoteAcknowledgementNoQuoteEntries
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadMassQuoteNoQuoteEntriesGrp (pos:int) (bs:byte []) : int * MassQuoteNoQuoteEntriesGrp  =
    let pos, quoteEntryID = ReadField "ReadMassQuoteNoQuoteEntries" pos "299"B bs ReadQuoteEntryID
    let pos, bidPx = ReadOptionalField pos "132"B bs ReadBidPx
    let pos, offerPx = ReadOptionalField pos "133"B bs ReadOfferPx
    let pos, bidSize = ReadOptionalField pos "134"B bs ReadBidSize
    let pos, offerSize = ReadOptionalField pos "135"B bs ReadOfferSize
    let pos, validUntilTime = ReadOptionalField pos "62"B bs ReadValidUntilTime
    let pos, bidSpotRate = ReadOptionalField pos "188"B bs ReadBidSpotRate
    let pos, offerSpotRate = ReadOptionalField pos "190"B bs ReadOfferSpotRate
    let pos, bidForwardPoints = ReadOptionalField pos "189"B bs ReadBidForwardPoints
    let pos, offerForwardPoints = ReadOptionalField pos "191"B bs ReadOfferForwardPoints
    let pos, midPx = ReadOptionalField pos "631"B bs ReadMidPx
    let pos, bidYield = ReadOptionalField pos "632"B bs ReadBidYield
    let pos, midYield = ReadOptionalField pos "633"B bs ReadMidYield
    let pos, offerYield = ReadOptionalField pos "634"B bs ReadOfferYield
    let pos, transactTime = ReadOptionalField pos "60"B bs ReadTransactTime
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    let pos, settlDate = ReadOptionalField pos "64"B bs ReadSettlDate
    let pos, ordType = ReadOptionalField pos "40"B bs ReadOrdType
    let pos, settlDate2 = ReadOptionalField pos "193"B bs ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField pos "192"B bs ReadOrderQty2
    let pos, bidForwardPoints2 = ReadOptionalField pos "642"B bs ReadBidForwardPoints2
    let pos, offerForwardPoints2 = ReadOptionalField pos "643"B bs ReadOfferForwardPoints2
    let pos, currency = ReadOptionalField pos "15"B bs ReadCurrency
    //let ci = {
            //QuoteEntryID = quoteEntryID
            //Instrument = instrument
            //NoLegs = noLegs
            //BidPx = bidPx
            //OfferPx = offerPx
            //BidSize = bidSize
            //OfferSize = offerSize
            //ValidUntilTime = validUntilTime
            //BidSpotRate = bidSpotRate
            //OfferSpotRate = offerSpotRate
            //BidForwardPoints = bidForwardPoints
            //OfferForwardPoints = offerForwardPoints
            //MidPx = midPx
            //BidYield = bidYield
            //MidYield = midYield
            //OfferYield = offerYield
            //TransactTime = transactTime
            //TradingSessionID = tradingSessionID
            //TradingSessionSubID = tradingSessionSubID
            //SettlDate = settlDate
            //OrdType = ordType
            //SettlDate2 = settlDate2
            //OrderQty2 = orderQty2
            //BidForwardPoints2 = bidForwardPoints2
            //OfferForwardPoints2 = offerForwardPoints2
            //Currency = currency
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoQuoteSetsGrp (pos:int) (bs:byte []) : int * NoQuoteSetsGrp  =
    let pos, quoteSetID = ReadField "ReadNoQuoteSets" pos "302"B bs ReadQuoteSetID
    let pos, quoteSetValidUntilTime = ReadOptionalField pos "367"B bs ReadQuoteSetValidUntilTime
    let pos, totNoQuoteEntries = ReadField "ReadNoQuoteSets" pos "304"B bs ReadTotNoQuoteEntries
    let pos, lastFragment = ReadOptionalField pos "893"B bs ReadLastFragment
    //let ci = {
            //QuoteSetID = quoteSetID
            //UnderlyingInstrument = underlyingInstrument
            //QuoteSetValidUntilTime = quoteSetValidUntilTime
            //TotNoQuoteEntries = totNoQuoteEntries
            //LastFragment = lastFragment
            //MassQuoteNoQuoteEntries = massQuoteNoQuoteEntries
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadQuoteStatusReportNoLegsGrp (pos:int) (bs:byte []) : int * QuoteStatusReportNoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "687"B bs ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "588"B bs ReadLegSettlDate
    //let ci = {
            //InstrumentLeg = instrumentLeg
            //LegQty = legQty
            //LegSwapType = legSwapType
            //LegSettlType = legSettlType
            //LegSettlDate = legSettlDate
            //LegStipulations = legStipulations
            //NestedParties = nestedParties
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoQuoteEntriesGrp (pos:int) (bs:byte []) : int * NoQuoteEntriesGrp  =
    //let ci = {
            //Instrument = instrument
            //FinancingDetails = financingDetails
            //NoUnderlyings = noUnderlyings
            //NoLegs = noLegs
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadQuoteNoLegsGrp (pos:int) (bs:byte []) : int * QuoteNoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "687"B bs ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "588"B bs ReadLegSettlDate
    let pos, legPriceType = ReadOptionalField pos "686"B bs ReadLegPriceType
    let pos, legBidPx = ReadOptionalField pos "681"B bs ReadLegBidPx
    let pos, legOfferPx = ReadOptionalField pos "684"B bs ReadLegOfferPx
    //let ci = {
            //InstrumentLeg = instrumentLeg
            //LegQty = legQty
            //LegSwapType = legSwapType
            //LegSettlType = legSettlType
            //LegSettlDate = legSettlDate
            //LegStipulations = legStipulations
            //NestedParties = nestedParties
            //LegPriceType = legPriceType
            //LegBidPx = legBidPx
            //LegOfferPx = legOfferPx
            //LegBenchmarkCurveData = legBenchmarkCurveData
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadRFQRequestNoRelatedSymGrp (pos:int) (bs:byte []) : int * RFQRequestNoRelatedSymGrp  =
    let pos, instrument = ReadInstrument pos bs    // component
    let pos, prevClosePx = ReadOptionalField pos "140"B bs ReadPrevClosePx
    let pos, quoteRequestType = ReadOptionalField pos "303"B bs ReadQuoteRequestType
    let pos, quoteType = ReadOptionalField pos "537"B bs ReadQuoteType
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    //let ci = {
            //Instrument = instrument
            //NoUnderlyings = noUnderlyings
            //NoLegs = noLegs
            //PrevClosePx = prevClosePx
            //QuoteRequestType = quoteRequestType
            //QuoteType = quoteType
            //TradingSessionID = tradingSessionID
            //TradingSessionSubID = tradingSessionSubID
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadQuoteRequestRejectNoLegsGrp (pos:int) (bs:byte []) : int * QuoteRequestRejectNoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "687"B bs ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "588"B bs ReadLegSettlDate
    //let ci = {
            //InstrumentLeg = instrumentLeg
            //LegQty = legQty
            //LegSwapType = legSwapType
            //LegSettlType = legSettlType
            //LegSettlDate = legSettlDate
            //LegStipulations = legStipulations
            //NestedParties = nestedParties
            //LegBenchmarkCurveData = legBenchmarkCurveData
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadQuoteRequestRejectNoRelatedSymGrp (pos:int) (bs:byte []) : int * QuoteRequestRejectNoRelatedSymGrp  =
    let pos, instrument = ReadInstrument pos bs    // component
    let pos, prevClosePx = ReadOptionalField pos "140"B bs ReadPrevClosePx
    let pos, quoteRequestType = ReadOptionalField pos "303"B bs ReadQuoteRequestType
    let pos, quoteType = ReadOptionalField pos "537"B bs ReadQuoteType
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    let pos, tradeOriginationDate = ReadOptionalField pos "229"B bs ReadTradeOriginationDate
    let pos, side = ReadOptionalField pos "54"B bs ReadSide
    let pos, qtyType = ReadOptionalField pos "854"B bs ReadQtyType
    let pos, settlType = ReadOptionalField pos "63"B bs ReadSettlType
    let pos, settlDate = ReadOptionalField pos "64"B bs ReadSettlDate
    let pos, settlDate2 = ReadOptionalField pos "193"B bs ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField pos "192"B bs ReadOrderQty2
    let pos, currency = ReadOptionalField pos "15"B bs ReadCurrency
    let pos, account = ReadOptionalField pos "1"B bs ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "660"B bs ReadAcctIDSource
    let pos, accountType = ReadOptionalField pos "581"B bs ReadAccountType
    //let ci = {
            //Instrument = instrument
            //FinancingDetails = financingDetails
            //NoUnderlyings = noUnderlyings
            //PrevClosePx = prevClosePx
            //QuoteRequestType = quoteRequestType
            //QuoteType = quoteType
            //TradingSessionID = tradingSessionID
            //TradingSessionSubID = tradingSessionSubID
            //TradeOriginationDate = tradeOriginationDate
            //Side = side
            //QtyType = qtyType
            //OrderQtyData = orderQtyData
            //SettlType = settlType
            //SettlDate = settlDate
            //SettlDate2 = settlDate2
            //OrderQty2 = orderQty2
            //Currency = currency
            //Stipulations = stipulations
            //Account = account
            //AcctIDSource = acctIDSource
            //AccountType = accountType
            //QuoteRequestRejectNoLegs = quoteRequestRejectNoLegs
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadQuoteResponseNoLegsGrp (pos:int) (bs:byte []) : int * QuoteResponseNoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "687"B bs ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "588"B bs ReadLegSettlDate
    let pos, legPriceType = ReadOptionalField pos "686"B bs ReadLegPriceType
    let pos, legBidPx = ReadOptionalField pos "681"B bs ReadLegBidPx
    let pos, legOfferPx = ReadOptionalField pos "684"B bs ReadLegOfferPx
    //let ci = {
            //InstrumentLeg = instrumentLeg
            //LegQty = legQty
            //LegSwapType = legSwapType
            //LegSettlType = legSettlType
            //LegSettlDate = legSettlDate
            //LegStipulations = legStipulations
            //NestedParties = nestedParties
            //LegPriceType = legPriceType
            //LegBidPx = legBidPx
            //LegOfferPx = legOfferPx
            //LegBenchmarkCurveData = legBenchmarkCurveData
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadQuoteRequestNoLegsGrp (pos:int) (bs:byte []) : int * QuoteRequestNoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "687"B bs ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "588"B bs ReadLegSettlDate
    //let ci = {
            //InstrumentLeg = instrumentLeg
            //LegQty = legQty
            //LegSwapType = legSwapType
            //LegSettlType = legSettlType
            //LegSettlDate = legSettlDate
            //LegStipulations = legStipulations
            //NestedParties = nestedParties
            //LegBenchmarkCurveData = legBenchmarkCurveData
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoQuoteQualifiersGrp (pos:int) (bs:byte []) : int * NoQuoteQualifiersGrp  =
    let pos, quoteQualifier = ReadOptionalField pos "695"B bs ReadQuoteQualifier
    //let ci = {
            //QuoteQualifier = quoteQualifier
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadQuoteRequestNoRelatedSymGrp (pos:int) (bs:byte []) : int * QuoteRequestNoRelatedSymGrp  =
    let pos, instrument = ReadInstrument pos bs    // component
    let pos, prevClosePx = ReadOptionalField pos "140"B bs ReadPrevClosePx
    let pos, quoteRequestType = ReadOptionalField pos "303"B bs ReadQuoteRequestType
    let pos, quoteType = ReadOptionalField pos "537"B bs ReadQuoteType
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    let pos, tradeOriginationDate = ReadOptionalField pos "229"B bs ReadTradeOriginationDate
    let pos, side = ReadOptionalField pos "54"B bs ReadSide
    let pos, qtyType = ReadOptionalField pos "854"B bs ReadQtyType
    let pos, settlType = ReadOptionalField pos "63"B bs ReadSettlType
    let pos, settlDate = ReadOptionalField pos "64"B bs ReadSettlDate
    let pos, settlDate2 = ReadOptionalField pos "193"B bs ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField pos "192"B bs ReadOrderQty2
    let pos, currency = ReadOptionalField pos "15"B bs ReadCurrency
    let pos, account = ReadOptionalField pos "1"B bs ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "660"B bs ReadAcctIDSource
    let pos, accountType = ReadOptionalField pos "581"B bs ReadAccountType
    let pos, quotePriceType = ReadOptionalField pos "692"B bs ReadQuotePriceType
    let pos, ordType = ReadOptionalField pos "40"B bs ReadOrdType
    let pos, validUntilTime = ReadOptionalField pos "62"B bs ReadValidUntilTime
    let pos, expireTime = ReadOptionalField pos "126"B bs ReadExpireTime
    let pos, transactTime = ReadOptionalField pos "60"B bs ReadTransactTime
    let pos, priceType = ReadOptionalField pos "423"B bs ReadPriceType
    let pos, price = ReadOptionalField pos "44"B bs ReadPrice
    let pos, price2 = ReadOptionalField pos "640"B bs ReadPrice2
    //let ci = {
            //Instrument = instrument
            //FinancingDetails = financingDetails
            //NoUnderlyings = noUnderlyings
            //PrevClosePx = prevClosePx
            //QuoteRequestType = quoteRequestType
            //QuoteType = quoteType
            //TradingSessionID = tradingSessionID
            //TradingSessionSubID = tradingSessionSubID
            //TradeOriginationDate = tradeOriginationDate
            //Side = side
            //QtyType = qtyType
            //OrderQtyData = orderQtyData
            //SettlType = settlType
            //SettlDate = settlDate
            //SettlDate2 = settlDate2
            //OrderQty2 = orderQty2
            //Currency = currency
            //Stipulations = stipulations
            //Account = account
            //AcctIDSource = acctIDSource
            //AccountType = accountType
            //QuoteRequestNoLegs = quoteRequestNoLegs
            //NoQuoteQualifiers = noQuoteQualifiers
            //QuotePriceType = quotePriceType
            //OrdType = ordType
            //ValidUntilTime = validUntilTime
            //ExpireTime = expireTime
            //TransactTime = transactTime
            //SpreadOrBenchmarkCurveData = spreadOrBenchmarkCurveData
            //PriceType = priceType
            //Price = price
            //Price2 = price2
            //YieldData = yieldData
            //Parties = parties
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoRelatedSymGrp (pos:int) (bs:byte []) : int * NoRelatedSymGrp  =
    //let ci = {
            //Instrument = instrument
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadIndicationOfInterestNoLegsGrp (pos:int) (bs:byte []) : int * IndicationOfInterestNoLegsGrp  =
    let pos, legIOIQty = ReadOptionalField pos "682"B bs ReadLegIOIQty
    //let ci = {
            //InstrumentLeg = instrumentLeg
            //LegIOIQty = legIOIQty
            //LegStipulations = legStipulations
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadAdvertisementNoUnderlyingsGrp (pos:int) (bs:byte []) : int * AdvertisementNoUnderlyingsGrp  =
    let pos, underlyingInstrument = ReadUnderlyingInstrument pos bs    // component
    //let ci = {
            //UnderlyingInstrument = underlyingInstrument
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoMsgTypesGrp (pos:int) (bs:byte []) : int * NoMsgTypesGrp  =
    let pos, refMsgType = ReadOptionalField pos "372"B bs ReadRefMsgType
    let pos, msgDirection = ReadOptionalField pos "385"B bs ReadMsgDirection
    //let ci = {
            //RefMsgType = refMsgType
            //MsgDirection = msgDirection
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoIOIQualifiersGrp (pos:int) (bs:byte []) : int * NoIOIQualifiersGrp  =
    let pos, iOIQualifier = ReadOptionalField pos "104"B bs ReadIOIQualifier
    //let ci = {
            //IOIQualifier = iOIQualifier
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoRoutingIDsGrp (pos:int) (bs:byte []) : int * NoRoutingIDsGrp  =
    let pos, routingType = ReadOptionalField pos "216"B bs ReadRoutingType
    let pos, routingID = ReadOptionalField pos "217"B bs ReadRoutingID
    //let ci = {
            //RoutingType = routingType
            //RoutingID = routingID
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadLinesOfTextGrp (pos:int) (bs:byte []) : int * LinesOfTextGrp  =
    let pos, text = ReadField "ReadLinesOfText" pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    //let ci = {
            //Text = text
            //EncodedText = encodedText
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoMDEntryTypesGrp (pos:int) (bs:byte []) : int * NoMDEntryTypesGrp  =
    let pos, mDEntryType = ReadField "ReadNoMDEntryTypes" pos "269"B bs ReadMDEntryType
    //let ci = {
            //MDEntryType = mDEntryType
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoMDEntriesGrp (pos:int) (bs:byte []) : int * NoMDEntriesGrp  =
    let pos, mDEntryType = ReadField "ReadNoMDEntries" pos "269"B bs ReadMDEntryType
    let pos, mDEntryPx = ReadOptionalField pos "270"B bs ReadMDEntryPx
    let pos, currency = ReadOptionalField pos "15"B bs ReadCurrency
    let pos, mDEntrySize = ReadOptionalField pos "271"B bs ReadMDEntrySize
    let pos, mDEntryDate = ReadOptionalField pos "272"B bs ReadMDEntryDate
    let pos, mDEntryTime = ReadOptionalField pos "273"B bs ReadMDEntryTime
    let pos, tickDirection = ReadOptionalField pos "274"B bs ReadTickDirection
    let pos, mDMkt = ReadOptionalField pos "275"B bs ReadMDMkt
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    let pos, quoteCondition = ReadOptionalField pos "276"B bs ReadQuoteCondition
    let pos, tradeCondition = ReadOptionalField pos "277"B bs ReadTradeCondition
    let pos, mDEntryOriginator = ReadOptionalField pos "282"B bs ReadMDEntryOriginator
    let pos, locationID = ReadOptionalField pos "283"B bs ReadLocationID
    let pos, deskID = ReadOptionalField pos "284"B bs ReadDeskID
    let pos, openCloseSettlFlag = ReadOptionalField pos "286"B bs ReadOpenCloseSettlFlag
    let pos, timeInForce = ReadOptionalField pos "59"B bs ReadTimeInForce
    let pos, expireDate = ReadOptionalField pos "432"B bs ReadExpireDate
    let pos, expireTime = ReadOptionalField pos "126"B bs ReadExpireTime
    let pos, minQty = ReadOptionalField pos "110"B bs ReadMinQty
    let pos, execInst = ReadOptionalField pos "18"B bs ReadExecInst
    let pos, sellerDays = ReadOptionalField pos "287"B bs ReadSellerDays
    let pos, orderID = ReadOptionalField pos "37"B bs ReadOrderID
    let pos, quoteEntryID = ReadOptionalField pos "299"B bs ReadQuoteEntryID
    let pos, mDEntryBuyer = ReadOptionalField pos "288"B bs ReadMDEntryBuyer
    let pos, mDEntrySeller = ReadOptionalField pos "289"B bs ReadMDEntrySeller
    let pos, numberOfOrders = ReadOptionalField pos "346"B bs ReadNumberOfOrders
    let pos, mDEntryPositionNo = ReadOptionalField pos "290"B bs ReadMDEntryPositionNo
    let pos, scope = ReadOptionalField pos "546"B bs ReadScope
    let pos, priceDelta = ReadOptionalField pos "811"B bs ReadPriceDelta
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    //let ci = {
            //MDEntryType = mDEntryType
            //MDEntryPx = mDEntryPx
            //Currency = currency
            //MDEntrySize = mDEntrySize
            //MDEntryDate = mDEntryDate
            //MDEntryTime = mDEntryTime
            //TickDirection = tickDirection
            //MDMkt = mDMkt
            //TradingSessionID = tradingSessionID
            //TradingSessionSubID = tradingSessionSubID
            //QuoteCondition = quoteCondition
            //TradeCondition = tradeCondition
            //MDEntryOriginator = mDEntryOriginator
            //LocationID = locationID
            //DeskID = deskID
            //OpenCloseSettlFlag = openCloseSettlFlag
            //TimeInForce = timeInForce
            //ExpireDate = expireDate
            //ExpireTime = expireTime
            //MinQty = minQty
            //ExecInst = execInst
            //SellerDays = sellerDays
            //OrderID = orderID
            //QuoteEntryID = quoteEntryID
            //MDEntryBuyer = mDEntryBuyer
            //MDEntrySeller = mDEntrySeller
            //NumberOfOrders = numberOfOrders
            //MDEntryPositionNo = mDEntryPositionNo
            //Scope = scope
            //PriceDelta = priceDelta
            //Text = text
            //EncodedText = encodedText
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoAltMDSourceGrp (pos:int) (bs:byte []) : int * NoAltMDSourceGrp  =
    let pos, altMDSourceID = ReadOptionalField pos "817"B bs ReadAltMDSourceID
    //let ci = {
            //AltMDSourceID = altMDSourceID
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoSecurityTypesGrp (pos:int) (bs:byte []) : int * NoSecurityTypesGrp  =
    let pos, securityType = ReadOptionalField pos "167"B bs ReadSecurityType
    let pos, securitySubType = ReadOptionalField pos "762"B bs ReadSecuritySubType
    let pos, product = ReadOptionalField pos "460"B bs ReadProduct
    let pos, cFICode = ReadOptionalField pos "461"B bs ReadCFICode
    //let ci = {
            //SecurityType = securityType
            //SecuritySubType = securitySubType
            //Product = product
            //CFICode = cFICode
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoContraBrokersGrp (pos:int) (bs:byte []) : int * NoContraBrokersGrp  =
    let pos, contraBroker = ReadOptionalField pos "375"B bs ReadContraBroker
    let pos, contraTrader = ReadOptionalField pos "337"B bs ReadContraTrader
    let pos, contraTradeQty = ReadOptionalField pos "437"B bs ReadContraTradeQty
    let pos, contraTradeTime = ReadOptionalField pos "438"B bs ReadContraTradeTime
    let pos, contraLegRefID = ReadOptionalField pos "655"B bs ReadContraLegRefID
    //let ci = {
            //ContraBroker = contraBroker
            //ContraTrader = contraTrader
            //ContraTradeQty = contraTradeQty
            //ContraTradeTime = contraTradeTime
            //ContraLegRefID = contraLegRefID
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoAffectedOrdersGrp (pos:int) (bs:byte []) : int * NoAffectedOrdersGrp  =
    let pos, origClOrdID = ReadOptionalField pos "41"B bs ReadOrigClOrdID
    let pos, affectedOrderID = ReadOptionalField pos "535"B bs ReadAffectedOrderID
    let pos, affectedSecondaryOrderID = ReadOptionalField pos "536"B bs ReadAffectedSecondaryOrderID
    //let ci = {
            //OrigClOrdID = origClOrdID
            //AffectedOrderID = affectedOrderID
            //AffectedSecondaryOrderID = affectedSecondaryOrderID
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoBidDescriptorsGrp (pos:int) (bs:byte []) : int * NoBidDescriptorsGrp  =
    let pos, bidDescriptorType = ReadOptionalField pos "399"B bs ReadBidDescriptorType
    let pos, bidDescriptor = ReadOptionalField pos "400"B bs ReadBidDescriptor
    let pos, sideValueInd = ReadOptionalField pos "401"B bs ReadSideValueInd
    let pos, liquidityValue = ReadOptionalField pos "404"B bs ReadLiquidityValue
    let pos, liquidityNumSecurities = ReadOptionalField pos "441"B bs ReadLiquidityNumSecurities
    let pos, liquidityPctLow = ReadOptionalField pos "402"B bs ReadLiquidityPctLow
    let pos, liquidityPctHigh = ReadOptionalField pos "403"B bs ReadLiquidityPctHigh
    let pos, eFPTrackingError = ReadOptionalField pos "405"B bs ReadEFPTrackingError
    let pos, fairValue = ReadOptionalField pos "406"B bs ReadFairValue
    let pos, outsideIndexPct = ReadOptionalField pos "407"B bs ReadOutsideIndexPct
    let pos, valueOfFutures = ReadOptionalField pos "408"B bs ReadValueOfFutures
    //let ci = {
            //BidDescriptorType = bidDescriptorType
            //BidDescriptor = bidDescriptor
            //SideValueInd = sideValueInd
            //LiquidityValue = liquidityValue
            //LiquidityNumSecurities = liquidityNumSecurities
            //LiquidityPctLow = liquidityPctLow
            //LiquidityPctHigh = liquidityPctHigh
            //EFPTrackingError = eFPTrackingError
            //FairValue = fairValue
            //OutsideIndexPct = outsideIndexPct
            //ValueOfFutures = valueOfFutures
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoBidComponentsGrp (pos:int) (bs:byte []) : int * NoBidComponentsGrp  =
    let pos, listID = ReadOptionalField pos "66"B bs ReadListID
    let pos, side = ReadOptionalField pos "54"B bs ReadSide
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    let pos, netGrossInd = ReadOptionalField pos "430"B bs ReadNetGrossInd
    let pos, settlType = ReadOptionalField pos "63"B bs ReadSettlType
    let pos, settlDate = ReadOptionalField pos "64"B bs ReadSettlDate
    let pos, account = ReadOptionalField pos "1"B bs ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "660"B bs ReadAcctIDSource
    //let ci = {
            //ListID = listID
            //Side = side
            //TradingSessionID = tradingSessionID
            //TradingSessionSubID = tradingSessionSubID
            //NetGrossInd = netGrossInd
            //SettlType = settlType
            //SettlDate = settlDate
            //Account = account
            //AcctIDSource = acctIDSource
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadListStatusNoOrdersGrp (pos:int) (bs:byte []) : int * ListStatusNoOrdersGrp  =
    let pos, clOrdID = ReadField "ReadListStatusNoOrders" pos "11"B bs ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "526"B bs ReadSecondaryClOrdID
    let pos, cumQty = ReadField "ReadListStatusNoOrders" pos "14"B bs ReadCumQty
    let pos, ordStatus = ReadField "ReadListStatusNoOrders" pos "39"B bs ReadOrdStatus
    let pos, workingIndicator = ReadOptionalField pos "636"B bs ReadWorkingIndicator
    let pos, leavesQty = ReadField "ReadListStatusNoOrders" pos "151"B bs ReadLeavesQty
    let pos, cxlQty = ReadField "ReadListStatusNoOrders" pos "84"B bs ReadCxlQty
    let pos, avgPx = ReadField "ReadListStatusNoOrders" pos "6"B bs ReadAvgPx
    let pos, ordRejReason = ReadOptionalField pos "103"B bs ReadOrdRejReason
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    //let ci = {
            //ClOrdID = clOrdID
            //SecondaryClOrdID = secondaryClOrdID
            //CumQty = cumQty
            //OrdStatus = ordStatus
            //WorkingIndicator = workingIndicator
            //LeavesQty = leavesQty
            //CxlQty = cxlQty
            //AvgPx = avgPx
            //OrdRejReason = ordRejReason
            //Text = text
            //EncodedText = encodedText
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadAllocationInstructionNoExecsGrp (pos:int) (bs:byte []) : int * AllocationInstructionNoExecsGrp  =
    let pos, lastQty = ReadOptionalField pos "32"B bs ReadLastQty
    let pos, execID = ReadOptionalField pos "17"B bs ReadExecID
    let pos, secondaryExecID = ReadOptionalField pos "527"B bs ReadSecondaryExecID
    let pos, lastPx = ReadOptionalField pos "31"B bs ReadLastPx
    let pos, lastParPx = ReadOptionalField pos "669"B bs ReadLastParPx
    let pos, lastCapacity = ReadOptionalField pos "29"B bs ReadLastCapacity
    //let ci = {
            //LastQty = lastQty
            //ExecID = execID
            //SecondaryExecID = secondaryExecID
            //LastPx = lastPx
            //LastParPx = lastParPx
            //LastCapacity = lastCapacity
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadAllocationInstructionAckNoAllocsGrp (pos:int) (bs:byte []) : int * AllocationInstructionAckNoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "79"B bs ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "661"B bs ReadAllocAcctIDSource
    let pos, allocPrice = ReadOptionalField pos "366"B bs ReadAllocPrice
    let pos, individualAllocID = ReadOptionalField pos "467"B bs ReadIndividualAllocID
    let pos, individualAllocRejCode = ReadOptionalField pos "776"B bs ReadIndividualAllocRejCode
    let pos, allocText = ReadOptionalField pos "161"B bs ReadAllocText
    let pos, encodedAllocText = ReadOptionalField pos "361"B bs ReadEncodedAllocText
    //let ci = {
            //AllocAccount = allocAccount
            //AllocAcctIDSource = allocAcctIDSource
            //AllocPrice = allocPrice
            //IndividualAllocID = individualAllocID
            //IndividualAllocRejCode = individualAllocRejCode
            //AllocText = allocText
            //EncodedAllocText = encodedAllocText
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadAllocationReportNoExecsGrp (pos:int) (bs:byte []) : int * AllocationReportNoExecsGrp  =
    let pos, lastQty = ReadOptionalField pos "32"B bs ReadLastQty
    let pos, execID = ReadOptionalField pos "17"B bs ReadExecID
    let pos, secondaryExecID = ReadOptionalField pos "527"B bs ReadSecondaryExecID
    let pos, lastPx = ReadOptionalField pos "31"B bs ReadLastPx
    let pos, lastParPx = ReadOptionalField pos "669"B bs ReadLastParPx
    let pos, lastCapacity = ReadOptionalField pos "29"B bs ReadLastCapacity
    //let ci = {
            //LastQty = lastQty
            //ExecID = execID
            //SecondaryExecID = secondaryExecID
            //LastPx = lastPx
            //LastParPx = lastParPx
            //LastCapacity = lastCapacity
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadAllocationReportAckNoAllocsGrp (pos:int) (bs:byte []) : int * AllocationReportAckNoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "79"B bs ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "661"B bs ReadAllocAcctIDSource
    let pos, allocPrice = ReadOptionalField pos "366"B bs ReadAllocPrice
    let pos, individualAllocID = ReadOptionalField pos "467"B bs ReadIndividualAllocID
    let pos, individualAllocRejCode = ReadOptionalField pos "776"B bs ReadIndividualAllocRejCode
    let pos, allocText = ReadOptionalField pos "161"B bs ReadAllocText
    let pos, encodedAllocText = ReadOptionalField pos "361"B bs ReadEncodedAllocText
    //let ci = {
            //AllocAccount = allocAccount
            //AllocAcctIDSource = allocAcctIDSource
            //AllocPrice = allocPrice
            //IndividualAllocID = individualAllocID
            //IndividualAllocRejCode = individualAllocRejCode
            //AllocText = allocText
            //EncodedAllocText = encodedAllocText
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoCapacitiesGrp (pos:int) (bs:byte []) : int * NoCapacitiesGrp  =
    let pos, orderCapacity = ReadField "ReadNoCapacities" pos "528"B bs ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField pos "529"B bs ReadOrderRestrictions
    let pos, orderCapacityQty = ReadField "ReadNoCapacities" pos "863"B bs ReadOrderCapacityQty
    //let ci = {
            //OrderCapacity = orderCapacity
            //OrderRestrictions = orderRestrictions
            //OrderCapacityQty = orderCapacityQty
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoDatesGrp (pos:int) (bs:byte []) : int * NoDatesGrp  =
    let pos, tradeDate = ReadOptionalField pos "75"B bs ReadTradeDate
    let pos, transactTime = ReadOptionalField pos "60"B bs ReadTransactTime
    //let ci = {
            //TradeDate = tradeDate
            //TransactTime = transactTime
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoDistribInstsGrp (pos:int) (bs:byte []) : int * NoDistribInstsGrp  =
    let pos, distribPaymentMethod = ReadOptionalField pos "477"B bs ReadDistribPaymentMethod
    let pos, distribPercentage = ReadOptionalField pos "512"B bs ReadDistribPercentage
    let pos, cashDistribCurr = ReadOptionalField pos "478"B bs ReadCashDistribCurr
    let pos, cashDistribAgentName = ReadOptionalField pos "498"B bs ReadCashDistribAgentName
    let pos, cashDistribAgentCode = ReadOptionalField pos "499"B bs ReadCashDistribAgentCode
    let pos, cashDistribAgentAcctNumber = ReadOptionalField pos "500"B bs ReadCashDistribAgentAcctNumber
    let pos, cashDistribPayRef = ReadOptionalField pos "501"B bs ReadCashDistribPayRef
    let pos, cashDistribAgentAcctName = ReadOptionalField pos "502"B bs ReadCashDistribAgentAcctName
    //let ci = {
            //DistribPaymentMethod = distribPaymentMethod
            //DistribPercentage = distribPercentage
            //CashDistribCurr = cashDistribCurr
            //CashDistribAgentName = cashDistribAgentName
            //CashDistribAgentCode = cashDistribAgentCode
            //CashDistribAgentAcctNumber = cashDistribAgentAcctNumber
            //CashDistribPayRef = cashDistribPayRef
            //CashDistribAgentAcctName = cashDistribAgentAcctName
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoExecsGrp (pos:int) (bs:byte []) : int * NoExecsGrp  =
    let pos, execID = ReadOptionalField pos "17"B bs ReadExecID
    //let ci = {
            //ExecID = execID
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoTradesGrp (pos:int) (bs:byte []) : int * NoTradesGrp  =
    let pos, tradeReportID = ReadOptionalField pos "571"B bs ReadTradeReportID
    let pos, secondaryTradeReportID = ReadOptionalField pos "818"B bs ReadSecondaryTradeReportID
    //let ci = {
            //TradeReportID = tradeReportID
            //SecondaryTradeReportID = secondaryTradeReportID
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoCollInquiryQualifierGrp (pos:int) (bs:byte []) : int * NoCollInquiryQualifierGrp  =
    let pos, collInquiryQualifier = ReadOptionalField pos "896"B bs ReadCollInquiryQualifier
    //let ci = {
            //CollInquiryQualifier = collInquiryQualifier
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoCompIDsGrp (pos:int) (bs:byte []) : int * NoCompIDsGrp  =
    let pos, refCompID = ReadOptionalField pos "930"B bs ReadRefCompID
    let pos, refSubID = ReadOptionalField pos "931"B bs ReadRefSubID
    let pos, locationID = ReadOptionalField pos "283"B bs ReadLocationID
    let pos, deskID = ReadOptionalField pos "284"B bs ReadDeskID
    //let ci = {
            //RefCompID = refCompID
            //RefSubID = refSubID
            //LocationID = locationID
            //DeskID = deskID
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNetworkStatusResponseNoCompIDsGrp (pos:int) (bs:byte []) : int * NetworkStatusResponseNoCompIDsGrp  =
    let pos, refCompID = ReadOptionalField pos "930"B bs ReadRefCompID
    let pos, refSubID = ReadOptionalField pos "931"B bs ReadRefSubID
    let pos, locationID = ReadOptionalField pos "283"B bs ReadLocationID
    let pos, deskID = ReadOptionalField pos "284"B bs ReadDeskID
    let pos, statusValue = ReadOptionalField pos "928"B bs ReadStatusValue
    let pos, statusText = ReadOptionalField pos "929"B bs ReadStatusText
    //let ci = {
            //RefCompID = refCompID
            //RefSubID = refSubID
            //LocationID = locationID
            //DeskID = deskID
            //StatusValue = statusValue
            //StatusText = statusText
    //}
    //pos, ci
    failwith "not implemented"


// group
let ReadNoHopsGrp (pos:int) (bs:byte []) : int * NoHopsGrp  =
    let pos, hopCompID = ReadOptionalField pos "628"B bs ReadHopCompID
    let pos, hopSendingTime = ReadOptionalField pos "629"B bs ReadHopSendingTime
    let pos, hopRefID = ReadOptionalField pos "630"B bs ReadHopRefID
    //let ci = {
            //HopCompID = hopCompID
            //HopSendingTime = hopSendingTime
            //HopRefID = hopRefID
    //}
    //pos, ci
    failwith "not implemented"


