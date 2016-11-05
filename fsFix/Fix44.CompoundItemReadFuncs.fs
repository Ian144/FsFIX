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

// ####
// how do i get the tag? do readfuncs need to be tupled with thier tags?
// ReadOptionalField re-reads the tag each time it is called and returns None
let inline ReadOptionalField (pos:int) (expectedTag:byte[]) (bs:byte[]) readFunc = 
    let pos2, tag = FIXBufUtils.readTag pos bs
    if tag = expectedTag then 
        let pos3, fld = readFunc pos2 bs
        pos3, Some fld
    else
        pos, None   // return the original pos, the next readoptional will re-read it



// group
let ReadNoUnderlyingSecurityAltIDGrp (pos:int) (bs:byte []) : NoUnderlyingSecurityAltIDGrp  =
    let pos, underlyingSecurityAltID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadUnderlyingSecurityAltID
    let pos, underlyingSecurityAltIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadUnderlyingSecurityAltIDSource
    failwith "not implemented"

// group
let ReadNoUnderlyingStipsGrp (pos:int) (bs:byte []) : NoUnderlyingStipsGrp  =
    let pos, underlyingStipType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadUnderlyingStipType
    let pos, underlyingStipValue = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadUnderlyingStipValue
    failwith "not implemented"

// group
let ReadCollateralResponse_NoUnderlyingsGrp (pos:int) (bs:byte []) : CollateralResponse_NoUnderlyingsGrp  =
    let pos, collAction = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCollAction
    failwith "not implemented"

// group
let ReadCollateralAssignment_NoUnderlyingsGrp (pos:int) (bs:byte []) : CollateralAssignment_NoUnderlyingsGrp  =
    let pos, collAction = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCollAction
    failwith "not implemented"

// group
let ReadCollateralRequest_NoUnderlyingsGrp (pos:int) (bs:byte []) : CollateralRequest_NoUnderlyingsGrp  =
    let pos, collAction = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCollAction
    failwith "not implemented"

// group
let ReadPositionReport_NoUnderlyingsGrp (pos:int) (bs:byte []) : PositionReport_NoUnderlyingsGrp  =
    let pos, underlyingSettlPrice = ReadField "ReadPositionReport_NoUnderlyings" pos "tag"B bs Fix44.FieldReadFuncs.ReadUnderlyingSettlPrice
    let pos, underlyingSettlPriceType = ReadField "ReadPositionReport_NoUnderlyings" pos "tag"B bs Fix44.FieldReadFuncs.ReadUnderlyingSettlPriceType
    failwith "not implemented"

// group
let ReadNoNestedPartySubIDsGrp (pos:int) (bs:byte []) : NoNestedPartySubIDsGrp  =
    let pos, nestedPartySubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNestedPartySubID
    let pos, nestedPartySubIDType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNestedPartySubIDType
    failwith "not implemented"

// group
let ReadNoNestedPartyIDsGrp (pos:int) (bs:byte []) : NoNestedPartyIDsGrp  =
    let pos, nestedPartyID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNestedPartyID
    let pos, nestedPartyIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNestedPartyIDSource
    let pos, nestedPartyRole = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNestedPartyRole
    failwith "not implemented"

// group
let ReadNoPositionsGrp (pos:int) (bs:byte []) : NoPositionsGrp  =
    let pos, posType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPosType
    let pos, longQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLongQty
    let pos, shortQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadShortQty
    let pos, posQtyStatus = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPosQtyStatus
    failwith "not implemented"

// group
let ReadNoRegistDtlsGrp (pos:int) (bs:byte []) : NoRegistDtlsGrp  =
    let pos, registDtls = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadRegistDtls
    let pos, registEmail = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadRegistEmail
    let pos, mailingDtls = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMailingDtls
    let pos, mailingInst = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMailingInst
    let pos, ownerType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOwnerType
    let pos, dateOfBirth = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadDateOfBirth
    let pos, investorCountryOfResidence = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadInvestorCountryOfResidence
    failwith "not implemented"

// group
let ReadNoNested2PartySubIDsGrp (pos:int) (bs:byte []) : NoNested2PartySubIDsGrp  =
    let pos, nested2PartySubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNested2PartySubID
    let pos, nested2PartySubIDType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNested2PartySubIDType
    failwith "not implemented"

// group
let ReadNoNested2PartyIDsGrp (pos:int) (bs:byte []) : NoNested2PartyIDsGrp  =
    let pos, nested2PartyID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNested2PartyID
    let pos, nested2PartyIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNested2PartyIDSource
    let pos, nested2PartyRole = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNested2PartyRole
    failwith "not implemented"

// group
let ReadTradeCaptureReportAck_NoAllocsGrp (pos:int) (bs:byte []) : TradeCaptureReportAck_NoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadIndividualAllocID
    let pos, allocQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocQty
    failwith "not implemented"

// group
let ReadNoLegSecurityAltIDGrp (pos:int) (bs:byte []) : NoLegSecurityAltIDGrp  =
    let pos, legSecurityAltID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSecurityAltID
    let pos, legSecurityAltIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSecurityAltIDSource
    failwith "not implemented"

// group
let ReadNoLegStipulationsGrp (pos:int) (bs:byte []) : NoLegStipulationsGrp  =
    let pos, legStipulationType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegStipulationType
    let pos, legStipulationValue = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegStipulationValue
    failwith "not implemented"

// group
let ReadTradeCaptureReportAck_NoLegsGrp (pos:int) (bs:byte []) : TradeCaptureReportAck_NoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSwapType
    let pos, legPositionEffect = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegCoveredOrUncovered
    let pos, legRefID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegRefID
    let pos, legPrice = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegPrice
    let pos, legSettlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlDate
    let pos, legLastPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegLastPx
    failwith "not implemented"

// group
let ReadNoPartySubIDsGrp (pos:int) (bs:byte []) : NoPartySubIDsGrp  =
    let pos, partySubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPartySubID
    let pos, partySubIDType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPartySubIDType
    failwith "not implemented"

// group
let ReadNoPartyIDsGrp (pos:int) (bs:byte []) : NoPartyIDsGrp  =
    let pos, partyID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPartyID
    let pos, partyIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPartyIDSource
    let pos, partyRole = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPartyRole
    failwith "not implemented"

// group
let ReadNoClearingInstructionsGrp (pos:int) (bs:byte []) : NoClearingInstructionsGrp  =
    let pos, clearingInstruction = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClearingInstruction
    failwith "not implemented"

// group
let ReadNoContAmtsGrp (pos:int) (bs:byte []) : NoContAmtsGrp  =
    let pos, contAmtType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadContAmtType
    let pos, contAmtValue = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadContAmtValue
    let pos, contAmtCurr = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadContAmtCurr
    failwith "not implemented"

// group
let ReadNoStipulationsGrp (pos:int) (bs:byte []) : NoStipulationsGrp  =
    let pos, stipulationType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadStipulationType
    let pos, stipulationValue = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadStipulationValue
    failwith "not implemented"

// group
let ReadNoMiscFeesGrp (pos:int) (bs:byte []) : NoMiscFeesGrp  =
    let pos, miscFeeAmt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMiscFeeAmt
    let pos, miscFeeCurr = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMiscFeeCurr
    let pos, miscFeeType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMiscFeeType
    let pos, miscFeeBasis = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMiscFeeBasis
    failwith "not implemented"

// group
let ReadTradeCaptureReport_NoSidesGrp (pos:int) (bs:byte []) : TradeCaptureReport_NoSidesGrp  =
    let pos, side = ReadField "ReadTradeCaptureReport_NoSides" pos "tag"B bs Fix44.FieldReadFuncs.ReadSide
    let pos, orderID = ReadField "ReadTradeCaptureReport_NoSides" pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderID
    let pos, secondaryOrderID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecondaryOrderID
    let pos, clOrdID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecondaryClOrdID
    
    let pos, listID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadListID
    let pos, account = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAcctIDSource
    let pos, accountType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccountType
    let pos, processCode = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadProcessCode
    let pos, oddLot = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOddLot
    
    let pos, clearingFeeIndicator = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClearingFeeIndicator
    let pos, tradeInputSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeInputSource
    let pos, tradeInputDevice = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeInputDevice
    let pos, orderInputDevice = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderInputDevice
    let pos, currency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCurrency
    let pos, complianceID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadComplianceID
    let pos, solicitedFlag = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSolicitedFlag
    let pos, orderCapacity = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderRestrictions
    let pos, custOrderCapacity = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCustOrderCapacity
    let pos, ordType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrdType
    let pos, execInst = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExecInst
    let pos, transBkdTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTransBkdTime
    let pos, tradingSessionID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    let pos, timeBracket = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTimeBracket
    
    let pos, grossTradeAmt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadGrossTradeAmt
    let pos, numDaysInterest = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNumDaysInterest
    let pos, exDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExDate
    let pos, accruedInterestRate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccruedInterestRate
    let pos, accruedInterestAmt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccruedInterestAmt
    let pos, interestAtMaturity = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadInterestAtMaturity
    let pos, endAccruedInterestAmt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEndAccruedInterestAmt
    let pos, startCash = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadStartCash
    let pos, endCash = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEndCash
    let pos, concession = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadConcession
    let pos, totalTakedown = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTotalTakedown
    let pos, netMoney = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNetMoney
    let pos, settlCurrAmt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrAmt
    let pos, settlCurrency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrency
    let pos, settlCurrFxRate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrFxRate
    let pos, settlCurrFxRateCalc = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrFxRateCalc
    let pos, positionEffect = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPositionEffect
    let pos, text = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedText
    let pos, sideMultiLegReportingType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSideMultiLegReportingType
    
    
    
    let pos, exchangeRule = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExchangeRule
    let pos, tradeAllocIndicator = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeAllocIndicator
    let pos, preallocMethod = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPreallocMethod
    let pos, allocID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocID
    failwith "not implemented"

// group
let ReadTradeCaptureReport_NoLegsGrp (pos:int) (bs:byte []) : TradeCaptureReport_NoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSwapType
    let pos, legPositionEffect = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegCoveredOrUncovered
    let pos, legRefID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegRefID
    let pos, legPrice = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegPrice
    let pos, legSettlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlDate
    let pos, legLastPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegLastPx
    failwith "not implemented"

// group
let ReadNoPosAmtGrp (pos:int) (bs:byte []) : NoPosAmtGrp  =
    let pos, posAmtType = ReadField "ReadNoPosAmt" pos "tag"B bs Fix44.FieldReadFuncs.ReadPosAmtType
    let pos, posAmt = ReadField "ReadNoPosAmt" pos "tag"B bs Fix44.FieldReadFuncs.ReadPosAmt
    failwith "not implemented"

// group
let ReadNoSettlPartySubIDsGrp (pos:int) (bs:byte []) : NoSettlPartySubIDsGrp  =
    let pos, settlPartySubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlPartySubID
    let pos, settlPartySubIDType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlPartySubIDType
    failwith "not implemented"

// group
let ReadNoSettlPartyIDsGrp (pos:int) (bs:byte []) : NoSettlPartyIDsGrp  =
    let pos, settlPartyID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlPartyID
    let pos, settlPartyIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlPartyIDSource
    let pos, settlPartyRole = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlPartyRole
    failwith "not implemented"

// group
let ReadNoDlvyInstGrp (pos:int) (bs:byte []) : NoDlvyInstGrp  =
    let pos, settlInstSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlInstSource
    let pos, dlvyInstType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadDlvyInstType
    failwith "not implemented"

// group
let ReadNoSettlInstGrp (pos:int) (bs:byte []) : NoSettlInstGrp  =
    let pos, settlInstID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlInstID
    let pos, settlInstTransType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlInstTransType
    let pos, settlInstRefID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlInstRefID
    let pos, side = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSide
    let pos, product = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadProduct
    let pos, securityType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecurityType
    let pos, cFICode = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCFICode
    let pos, effectiveTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEffectiveTime
    let pos, expireTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExpireTime
    let pos, lastUpdateTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLastUpdateTime
    let pos, paymentMethod = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPaymentMethod
    let pos, paymentRef = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPaymentRef
    let pos, cardHolderName = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCardHolderName
    let pos, cardNumber = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCardNumber
    let pos, cardStartDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCardStartDate
    let pos, cardExpDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCardExpDate
    let pos, cardIssNum = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCardIssNum
    let pos, paymentDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPaymentDate
    let pos, paymentRemitterID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPaymentRemitterID
    failwith "not implemented"

// group
let ReadNoTrdRegTimestampsGrp (pos:int) (bs:byte []) : NoTrdRegTimestampsGrp  =
    let pos, trdRegTimestamp = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTrdRegTimestamp
    let pos, trdRegTimestampType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTrdRegTimestampType
    let pos, trdRegTimestampOrigin = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTrdRegTimestampOrigin
    failwith "not implemented"

// group
let ReadAllocationReport_NoAllocsGrp (pos:int) (bs:byte []) : AllocationReport_NoAllocsGrp  =
    let pos, allocAccount = ReadField "ReadAllocationReport_NoAllocs" pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAcctIDSource
    let pos, matchStatus = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMatchStatus
    let pos, allocPrice = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocPrice
    let pos, allocQty = ReadField "ReadAllocationReport_NoAllocs" pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocQty
    let pos, individualAllocID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadIndividualAllocID
    let pos, processCode = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadProcessCode
    let pos, notifyBrokerOfCredit = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNotifyBrokerOfCredit
    let pos, allocHandlInst = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocHandlInst
    let pos, allocText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocText
    let pos, encodedAllocText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedAllocText
    let pos, allocAvgPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAvgPx
    let pos, allocNetMoney = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocNetMoney
    let pos, settlCurrAmt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrAmt
    let pos, allocSettlCurrAmt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocSettlCurrAmt
    let pos, settlCurrency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrency
    let pos, allocSettlCurrency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocSettlCurrency
    let pos, settlCurrFxRate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrFxRate
    let pos, settlCurrFxRateCalc = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrFxRateCalc
    let pos, allocAccruedInterestAmt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAccruedInterestAmt
    let pos, allocInterestAtMaturity = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocInterestAtMaturity
    let pos, clearingFeeIndicator = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClearingFeeIndicator
    let pos, allocSettlInstType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocSettlInstType
    failwith "not implemented"

// group
let ReadAllocationInstruction_NoAllocsGrp (pos:int) (bs:byte []) : AllocationInstruction_NoAllocsGrp  =
    let pos, allocAccount = ReadField "ReadAllocationInstruction_NoAllocs" pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAcctIDSource
    let pos, matchStatus = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMatchStatus
    let pos, allocPrice = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocPrice
    let pos, allocQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocQty
    let pos, individualAllocID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadIndividualAllocID
    let pos, processCode = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadProcessCode
    let pos, notifyBrokerOfCredit = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNotifyBrokerOfCredit
    let pos, allocHandlInst = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocHandlInst
    let pos, allocText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocText
    let pos, encodedAllocText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedAllocText
    let pos, allocAvgPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAvgPx
    let pos, allocNetMoney = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocNetMoney
    let pos, settlCurrAmt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrAmt
    let pos, allocSettlCurrAmt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocSettlCurrAmt
    let pos, settlCurrency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrency
    let pos, allocSettlCurrency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocSettlCurrency
    let pos, settlCurrFxRate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrFxRate
    let pos, settlCurrFxRateCalc = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrFxRateCalc
    let pos, accruedInterestAmt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccruedInterestAmt
    let pos, allocAccruedInterestAmt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAccruedInterestAmt
    let pos, allocInterestAtMaturity = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocInterestAtMaturity
    let pos, settlInstMode = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlInstMode
    let pos, noClearingInstructions = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNoClearingInstructions
    let pos, clearingInstruction = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClearingInstruction
    let pos, clearingFeeIndicator = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClearingFeeIndicator
    let pos, allocSettlInstType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocSettlInstType
    failwith "not implemented"

// group
let ReadNoOrdersGrp (pos:int) (bs:byte []) : NoOrdersGrp  =
    let pos, clOrdID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClOrdID
    let pos, orderID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderID
    let pos, secondaryOrderID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecondaryOrderID
    let pos, secondaryClOrdID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecondaryClOrdID
    let pos, listID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadListID
    let pos, orderQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderQty
    let pos, orderAvgPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderAvgPx
    let pos, orderBookingQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderBookingQty
    failwith "not implemented"

// group
let ReadListStrikePrice_NoUnderlyingsGrp (pos:int) (bs:byte []) : ListStrikePrice_NoUnderlyingsGrp  =
    let pos, prevClosePx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPrevClosePx
    let pos, clOrdID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecondaryClOrdID
    let pos, side = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSide
    let pos, price = ReadField "ReadListStrikePrice_NoUnderlyings" pos "tag"B bs Fix44.FieldReadFuncs.ReadPrice
    let pos, currency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCurrency
    let pos, text = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedText
    failwith "not implemented"

// group
let ReadNoSecurityAltIDGrp (pos:int) (bs:byte []) : NoSecurityAltIDGrp  =
    let pos, securityAltID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecurityAltID
    let pos, securityAltIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecurityAltIDSource
    failwith "not implemented"

// group
let ReadNoEventsGrp (pos:int) (bs:byte []) : NoEventsGrp  =
    let pos, eventType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEventType
    let pos, eventDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEventDate
    let pos, eventPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEventPx
    let pos, eventText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEventText
    failwith "not implemented"

// group
let ReadNoStrikesGrp (pos:int) (bs:byte []) : NoStrikesGrp  =
    failwith "not implemented"

// group
let ReadNoAllocsGrp (pos:int) (bs:byte []) : NoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadIndividualAllocID
    let pos, allocQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocQty
    failwith "not implemented"

// group
let ReadNoTradingSessionsGrp (pos:int) (bs:byte []) : NoTradingSessionsGrp  =
    let pos, tradingSessionID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    failwith "not implemented"

// group
let ReadNoUnderlyingsGrp (pos:int) (bs:byte []) : NoUnderlyingsGrp  =
    failwith "not implemented"

// group
let ReadNewOrderList_NoOrdersGrp (pos:int) (bs:byte []) : NewOrderList_NoOrdersGrp  =
    let pos, clOrdID = ReadField "ReadNewOrderList_NoOrders" pos "tag"B bs Fix44.FieldReadFuncs.ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecondaryClOrdID
    let pos, listSeqNo = ReadField "ReadNewOrderList_NoOrders" pos "tag"B bs Fix44.FieldReadFuncs.ReadListSeqNo
    let pos, clOrdLinkID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClOrdLinkID
    let pos, settlInstMode = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlInstMode
    let pos, tradeOriginationDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeOriginationDate
    let pos, tradeDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeDate
    let pos, account = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAcctIDSource
    let pos, accountType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccountType
    let pos, dayBookingInst = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadDayBookingInst
    let pos, bookingUnit = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBookingUnit
    let pos, allocID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocID
    let pos, preallocMethod = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPreallocMethod
    let pos, settlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlType
    let pos, settlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlDate
    let pos, cashMargin = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCashMargin
    let pos, clearingFeeIndicator = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClearingFeeIndicator
    let pos, handlInst = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadHandlInst
    let pos, execInst = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExecInst
    let pos, minQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMinQty
    let pos, maxFloor = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMaxFloor
    let pos, exDestination = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExDestination
    let pos, processCode = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadProcessCode
    let pos, prevClosePx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPrevClosePx
    let pos, side = ReadField "ReadNewOrderList_NoOrders" pos "tag"B bs Fix44.FieldReadFuncs.ReadSide
    let pos, sideValueInd = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSideValueInd
    let pos, locateReqd = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLocateReqd
    let pos, transactTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTransactTime
    let pos, qtyType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQtyType
    let pos, ordType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrdType
    let pos, priceType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPriceType
    let pos, price = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPrice
    let pos, stopPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadStopPx
    let pos, currency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCurrency
    let pos, complianceID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadComplianceID
    let pos, solicitedFlag = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSolicitedFlag
    let pos, iOIid = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadIOIid
    let pos, quoteID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteID
    let pos, timeInForce = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTimeInForce
    let pos, effectiveTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEffectiveTime
    let pos, expireDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExpireDate
    let pos, expireTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExpireTime
    let pos, gTBookingInst = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadGTBookingInst
    let pos, orderCapacity = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderRestrictions
    let pos, custOrderCapacity = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCustOrderCapacity
    let pos, forexReq = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadForexReq
    let pos, settlCurrency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrency
    let pos, bookingType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBookingType
    let pos, text = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedText
    let pos, settlDate2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderQty2
    let pos, price2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPrice2
    let pos, positionEffect = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPositionEffect
    let pos, coveredOrUncovered = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCoveredOrUncovered
    let pos, maxShow = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMaxShow
    let pos, targetStrategy = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTargetStrategy
    let pos, targetStrategyParameters = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTargetStrategyParameters
    let pos, participationRate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadParticipationRate
    let pos, designation = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadDesignation
    failwith "not implemented"

// group
let ReadBidResponse_NoBidComponentsGrp (pos:int) (bs:byte []) : BidResponse_NoBidComponentsGrp  =
    let pos, listID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadListID
    let pos, country = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCountry
    let pos, side = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSide
    let pos, price = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPrice
    let pos, priceType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPriceType
    let pos, fairValue = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadFairValue
    let pos, netGrossInd = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNetGrossInd
    let pos, settlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlType
    let pos, settlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlDate
    let pos, tradingSessionID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    let pos, text = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedText
    failwith "not implemented"

// group
let ReadNoLegAllocsGrp (pos:int) (bs:byte []) : NoLegAllocsGrp  =
    let pos, legAllocAccount = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegAllocAccount
    let pos, legIndividualAllocID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegIndividualAllocID
    let pos, legAllocQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegAllocQty
    let pos, legAllocAcctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegAllocAcctIDSource
    let pos, legSettlCurrency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlCurrency
    failwith "not implemented"

// group
let ReadMultilegOrderCancelReplaceRequest_NoLegsGrp (pos:int) (bs:byte []) : MultilegOrderCancelReplaceRequest_NoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSwapType
    let pos, legPositionEffect = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegCoveredOrUncovered
    let pos, legRefID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegRefID
    let pos, legPrice = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegPrice
    let pos, legSettlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlDate
    failwith "not implemented"

// group
let ReadNoNested3PartySubIDsGrp (pos:int) (bs:byte []) : NoNested3PartySubIDsGrp  =
    let pos, nested3PartySubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNested3PartySubID
    let pos, nested3PartySubIDType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNested3PartySubIDType
    failwith "not implemented"

// group
let ReadNoNested3PartyIDsGrp (pos:int) (bs:byte []) : NoNested3PartyIDsGrp  =
    let pos, nested3PartyID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNested3PartyID
    let pos, nested3PartyIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNested3PartyIDSource
    let pos, nested3PartyRole = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNested3PartyRole
    failwith "not implemented"

// group
let ReadMultilegOrderCancelReplaceRequest_NoAllocsGrp (pos:int) (bs:byte []) : MultilegOrderCancelReplaceRequest_NoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadIndividualAllocID
    let pos, allocQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocQty
    failwith "not implemented"

// group
let ReadNewOrderMultileg_NoLegsGrp (pos:int) (bs:byte []) : NewOrderMultileg_NoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSwapType
    let pos, legPositionEffect = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegCoveredOrUncovered
    let pos, legRefID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegRefID
    let pos, legPrice = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegPrice
    let pos, legSettlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlDate
    failwith "not implemented"

// group
let ReadNewOrderMultileg_NoAllocsGrp (pos:int) (bs:byte []) : NewOrderMultileg_NoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadIndividualAllocID
    let pos, allocQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocQty
    failwith "not implemented"

// group
let ReadCrossOrderCancelRequest_NoSidesGrp (pos:int) (bs:byte []) : CrossOrderCancelRequest_NoSidesGrp  =
    let pos, side = ReadField "ReadCrossOrderCancelRequest_NoSides" pos "tag"B bs Fix44.FieldReadFuncs.ReadSide
    let pos, origClOrdID = ReadField "ReadCrossOrderCancelRequest_NoSides" pos "tag"B bs Fix44.FieldReadFuncs.ReadOrigClOrdID
    let pos, clOrdID = ReadField "ReadCrossOrderCancelRequest_NoSides" pos "tag"B bs Fix44.FieldReadFuncs.ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecondaryClOrdID
    let pos, clOrdLinkID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClOrdLinkID
    let pos, origOrdModTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrigOrdModTime
    let pos, tradeOriginationDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeOriginationDate
    let pos, tradeDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeDate
    let pos, complianceID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadComplianceID
    let pos, text = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedText
    failwith "not implemented"

// group
let ReadCrossOrderCancelReplaceRequest_NoSidesGrp (pos:int) (bs:byte []) : CrossOrderCancelReplaceRequest_NoSidesGrp  =
    let pos, side = ReadField "ReadCrossOrderCancelReplaceRequest_NoSides" pos "tag"B bs Fix44.FieldReadFuncs.ReadSide
    let pos, origClOrdID = ReadField "ReadCrossOrderCancelReplaceRequest_NoSides" pos "tag"B bs Fix44.FieldReadFuncs.ReadOrigClOrdID
    let pos, clOrdID = ReadField "ReadCrossOrderCancelReplaceRequest_NoSides" pos "tag"B bs Fix44.FieldReadFuncs.ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecondaryClOrdID
    let pos, clOrdLinkID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClOrdLinkID
    let pos, origOrdModTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrigOrdModTime
    let pos, tradeOriginationDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeOriginationDate
    let pos, tradeDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeDate
    let pos, account = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAcctIDSource
    let pos, accountType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccountType
    let pos, dayBookingInst = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadDayBookingInst
    let pos, bookingUnit = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBookingUnit
    let pos, preallocMethod = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPreallocMethod
    let pos, allocID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocID
    let pos, qtyType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQtyType
    let pos, orderCapacity = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderRestrictions
    let pos, custOrderCapacity = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCustOrderCapacity
    let pos, forexReq = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadForexReq
    let pos, settlCurrency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrency
    let pos, bookingType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBookingType
    let pos, text = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedText
    let pos, positionEffect = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPositionEffect
    let pos, coveredOrUncovered = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCoveredOrUncovered
    let pos, cashMargin = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCashMargin
    let pos, clearingFeeIndicator = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClearingFeeIndicator
    let pos, solicitedFlag = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSolicitedFlag
    let pos, sideComplianceID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSideComplianceID
    failwith "not implemented"

// group
let ReadNoSidesGrp (pos:int) (bs:byte []) : NoSidesGrp  =
    let pos, side = ReadField "ReadNoSides" pos "tag"B bs Fix44.FieldReadFuncs.ReadSide
    let pos, clOrdID = ReadField "ReadNoSides" pos "tag"B bs Fix44.FieldReadFuncs.ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecondaryClOrdID
    let pos, clOrdLinkID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClOrdLinkID
    let pos, tradeOriginationDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeOriginationDate
    let pos, tradeDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeDate
    let pos, account = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAcctIDSource
    let pos, accountType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccountType
    let pos, dayBookingInst = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadDayBookingInst
    let pos, bookingUnit = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBookingUnit
    let pos, preallocMethod = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPreallocMethod
    let pos, allocID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocID
    let pos, qtyType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQtyType
    let pos, orderCapacity = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderRestrictions
    let pos, custOrderCapacity = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCustOrderCapacity
    let pos, forexReq = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadForexReq
    let pos, settlCurrency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlCurrency
    let pos, bookingType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBookingType
    let pos, text = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedText
    let pos, positionEffect = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPositionEffect
    let pos, coveredOrUncovered = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCoveredOrUncovered
    let pos, cashMargin = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCashMargin
    let pos, clearingFeeIndicator = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadClearingFeeIndicator
    let pos, solicitedFlag = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSolicitedFlag
    let pos, sideComplianceID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSideComplianceID
    failwith "not implemented"

// group
let ReadExecutionReport_NoLegsGrp (pos:int) (bs:byte []) : ExecutionReport_NoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSwapType
    let pos, legPositionEffect = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegPositionEffect
    let pos, legCoveredOrUncovered = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegCoveredOrUncovered
    let pos, legRefID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegRefID
    let pos, legPrice = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegPrice
    let pos, legSettlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlDate
    let pos, legLastPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegLastPx
    failwith "not implemented"

// group
let ReadNoInstrAttribGrp (pos:int) (bs:byte []) : NoInstrAttribGrp  =
    let pos, instrAttribType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadInstrAttribType
    let pos, instrAttribValue = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadInstrAttribValue
    failwith "not implemented"

// group
let ReadNoLegsGrp (pos:int) (bs:byte []) : NoLegsGrp  =
    failwith "not implemented"

// group
let ReadDerivativeSecurityList_NoRelatedSymGrp (pos:int) (bs:byte []) : DerivativeSecurityList_NoRelatedSymGrp  =
    let pos, currency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCurrency
    let pos, expirationCycle = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExpirationCycle
    let pos, tradingSessionID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    let pos, text = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedText
    failwith "not implemented"

// group
let ReadSecurityList_NoLegsGrp (pos:int) (bs:byte []) : SecurityList_NoLegsGrp  =
    let pos, legSwapType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlType
    failwith "not implemented"

// group
let ReadSecurityList_NoRelatedSymGrp (pos:int) (bs:byte []) : SecurityList_NoRelatedSymGrp  =
    let pos, currency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCurrency
    let pos, roundLot = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadRoundLot
    let pos, minTradeVol = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMinTradeVol
    let pos, tradingSessionID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    let pos, expirationCycle = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExpirationCycle
    let pos, text = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedText
    failwith "not implemented"

// group
let ReadMarketDataIncrementalRefresh_NoMDEntriesGrp (pos:int) (bs:byte []) : MarketDataIncrementalRefresh_NoMDEntriesGrp  =
    let pos, mDUpdateAction = ReadField "ReadMarketDataIncrementalRefresh_NoMDEntries" pos "tag"B bs Fix44.FieldReadFuncs.ReadMDUpdateAction
    let pos, deleteReason = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadDeleteReason
    let pos, mDEntryType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryType
    let pos, mDEntryID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryID
    let pos, mDEntryRefID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryRefID
    let pos, financialStatus = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadFinancialStatus
    let pos, corporateAction = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCorporateAction
    let pos, mDEntryPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryPx
    let pos, currency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCurrency
    let pos, mDEntrySize = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntrySize
    let pos, mDEntryDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryDate
    let pos, mDEntryTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryTime
    let pos, tickDirection = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTickDirection
    let pos, mDMkt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDMkt
    let pos, tradingSessionID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    let pos, quoteCondition = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteCondition
    let pos, tradeCondition = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeCondition
    let pos, mDEntryOriginator = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryOriginator
    let pos, locationID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLocationID
    let pos, deskID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadDeskID
    let pos, openCloseSettlFlag = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOpenCloseSettlFlag
    let pos, timeInForce = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTimeInForce
    let pos, expireDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExpireDate
    let pos, expireTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExpireTime
    let pos, minQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMinQty
    let pos, execInst = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExecInst
    let pos, sellerDays = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSellerDays
    let pos, orderID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderID
    let pos, quoteEntryID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteEntryID
    let pos, mDEntryBuyer = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryBuyer
    let pos, mDEntrySeller = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntrySeller
    let pos, numberOfOrders = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNumberOfOrders
    let pos, mDEntryPositionNo = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryPositionNo
    let pos, scope = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadScope
    let pos, priceDelta = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPriceDelta
    let pos, netChgPrevDay = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNetChgPrevDay
    let pos, text = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedText
    failwith "not implemented"

// group
let ReadMarketDataRequest_NoRelatedSymGrp (pos:int) (bs:byte []) : MarketDataRequest_NoRelatedSymGrp  =
    failwith "not implemented"

// group
let ReadMassQuoteAcknowledgement_NoQuoteEntriesGrp (pos:int) (bs:byte []) : MassQuoteAcknowledgement_NoQuoteEntriesGrp  =
    let pos, quoteEntryID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteEntryID
    let pos, bidPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidPx
    let pos, offerPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOfferPx
    let pos, bidSize = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidSize
    let pos, offerSize = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOfferSize
    let pos, validUntilTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadValidUntilTime
    let pos, bidSpotRate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidSpotRate
    let pos, offerSpotRate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOfferSpotRate
    let pos, bidForwardPoints = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidForwardPoints
    let pos, offerForwardPoints = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOfferForwardPoints
    let pos, midPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMidPx
    let pos, bidYield = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidYield
    let pos, midYield = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMidYield
    let pos, offerYield = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOfferYield
    let pos, transactTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTransactTime
    let pos, tradingSessionID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    let pos, settlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlDate
    let pos, ordType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrdType
    let pos, settlDate2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderQty2
    let pos, bidForwardPoints2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidForwardPoints2
    let pos, offerForwardPoints2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOfferForwardPoints2
    let pos, currency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCurrency
    let pos, quoteEntryRejectReason = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteEntryRejectReason
    failwith "not implemented"

// group
let ReadMassQuoteAcknowledgement_NoQuoteSetsGrp (pos:int) (bs:byte []) : MassQuoteAcknowledgement_NoQuoteSetsGrp  =
    let pos, quoteSetID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteSetID
    let pos, totNoQuoteEntries = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTotNoQuoteEntries
    let pos, lastFragment = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLastFragment
    failwith "not implemented"

// group
let ReadMassQuote_NoQuoteEntriesGrp (pos:int) (bs:byte []) : MassQuote_NoQuoteEntriesGrp  =
    let pos, quoteEntryID = ReadField "ReadMassQuote_NoQuoteEntries" pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteEntryID
    let pos, bidPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidPx
    let pos, offerPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOfferPx
    let pos, bidSize = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidSize
    let pos, offerSize = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOfferSize
    let pos, validUntilTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadValidUntilTime
    let pos, bidSpotRate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidSpotRate
    let pos, offerSpotRate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOfferSpotRate
    let pos, bidForwardPoints = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidForwardPoints
    let pos, offerForwardPoints = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOfferForwardPoints
    let pos, midPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMidPx
    let pos, bidYield = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidYield
    let pos, midYield = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMidYield
    let pos, offerYield = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOfferYield
    let pos, transactTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTransactTime
    let pos, tradingSessionID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    let pos, settlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlDate
    let pos, ordType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrdType
    let pos, settlDate2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderQty2
    let pos, bidForwardPoints2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidForwardPoints2
    let pos, offerForwardPoints2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOfferForwardPoints2
    let pos, currency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCurrency
    failwith "not implemented"

// group
let ReadNoQuoteSetsGrp (pos:int) (bs:byte []) : NoQuoteSetsGrp  =
    let pos, quoteSetID = ReadField "ReadNoQuoteSets" pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteSetID
    let pos, quoteSetValidUntilTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteSetValidUntilTime
    let pos, totNoQuoteEntries = ReadField "ReadNoQuoteSets" pos "tag"B bs Fix44.FieldReadFuncs.ReadTotNoQuoteEntries
    let pos, lastFragment = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLastFragment
    failwith "not implemented"

// group
let ReadQuoteStatusReport_NoLegsGrp (pos:int) (bs:byte []) : QuoteStatusReport_NoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlDate
    failwith "not implemented"

// group
let ReadNoQuoteEntriesGrp (pos:int) (bs:byte []) : NoQuoteEntriesGrp  =
    failwith "not implemented"

// group
let ReadQuote_NoLegsGrp (pos:int) (bs:byte []) : Quote_NoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlDate
    let pos, legPriceType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegPriceType
    let pos, legBidPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegBidPx
    let pos, legOfferPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegOfferPx
    failwith "not implemented"

// group
let ReadRFQRequest_NoRelatedSymGrp (pos:int) (bs:byte []) : RFQRequest_NoRelatedSymGrp  =
    let pos, prevClosePx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPrevClosePx
    let pos, quoteRequestType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteRequestType
    let pos, quoteType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteType
    let pos, tradingSessionID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    failwith "not implemented"

// group
let ReadQuoteRequestReject_NoLegsGrp (pos:int) (bs:byte []) : QuoteRequestReject_NoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlDate
    failwith "not implemented"

// group
let ReadQuoteRequestReject_NoRelatedSymGrp (pos:int) (bs:byte []) : QuoteRequestReject_NoRelatedSymGrp  =
    let pos, prevClosePx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPrevClosePx
    let pos, quoteRequestType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteRequestType
    let pos, quoteType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteType
    let pos, tradingSessionID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    let pos, tradeOriginationDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeOriginationDate
    let pos, side = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSide
    let pos, qtyType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQtyType
    let pos, settlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlType
    let pos, settlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlDate
    let pos, settlDate2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderQty2
    let pos, currency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCurrency
    let pos, account = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAcctIDSource
    let pos, accountType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccountType
    failwith "not implemented"

// group
let ReadQuoteResponse_NoLegsGrp (pos:int) (bs:byte []) : QuoteResponse_NoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlDate
    let pos, legPriceType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegPriceType
    let pos, legBidPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegBidPx
    let pos, legOfferPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegOfferPx
    failwith "not implemented"

// group
let ReadQuoteRequest_NoLegsGrp (pos:int) (bs:byte []) : QuoteRequest_NoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegSettlDate
    failwith "not implemented"

// group
let ReadNoQuoteQualifiersGrp (pos:int) (bs:byte []) : NoQuoteQualifiersGrp  =
    let pos, quoteQualifier = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteQualifier
    failwith "not implemented"

// group
let ReadQuoteRequest_NoRelatedSymGrp (pos:int) (bs:byte []) : QuoteRequest_NoRelatedSymGrp  =
    let pos, prevClosePx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPrevClosePx
    let pos, quoteRequestType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteRequestType
    let pos, quoteType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteType
    let pos, tradingSessionID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    let pos, tradeOriginationDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeOriginationDate
    let pos, side = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSide
    let pos, qtyType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQtyType
    let pos, settlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlType
    let pos, settlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlDate
    let pos, settlDate2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlDate2
    let pos, orderQty2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderQty2
    let pos, currency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCurrency
    let pos, account = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAcctIDSource
    let pos, accountType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccountType
    let pos, quotePriceType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuotePriceType
    let pos, ordType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrdType
    let pos, validUntilTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadValidUntilTime
    let pos, expireTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExpireTime
    let pos, transactTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTransactTime
    let pos, priceType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPriceType
    let pos, price = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPrice
    let pos, price2 = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPrice2
    failwith "not implemented"

// group
let ReadNoRelatedSymGrp (pos:int) (bs:byte []) : NoRelatedSymGrp  =
    failwith "not implemented"

// group
let ReadIndicationOfInterest_NoLegsGrp (pos:int) (bs:byte []) : IndicationOfInterest_NoLegsGrp  =
    let pos, legIOIQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLegIOIQty
    failwith "not implemented"

// group
let ReadAdvertisement_NoUnderlyingsGrp (pos:int) (bs:byte []) : Advertisement_NoUnderlyingsGrp  =
    failwith "not implemented"

// group
let ReadNoMsgTypesGrp (pos:int) (bs:byte []) : NoMsgTypesGrp  =
    let pos, refMsgType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadRefMsgType
    let pos, msgDirection = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMsgDirection
    failwith "not implemented"

// group
let ReadNoIOIQualifiersGrp (pos:int) (bs:byte []) : NoIOIQualifiersGrp  =
    let pos, iOIQualifier = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadIOIQualifier
    failwith "not implemented"

// group
let ReadNoRoutingIDsGrp (pos:int) (bs:byte []) : NoRoutingIDsGrp  =
    let pos, routingType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadRoutingType
    let pos, routingID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadRoutingID
    failwith "not implemented"

// group
let ReadLinesOfTextGrp (pos:int) (bs:byte []) : LinesOfTextGrp  =
    let pos, text = ReadField "ReadLinesOfText" pos "tag"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedText
    failwith "not implemented"

// group
let ReadNoMDEntryTypesGrp (pos:int) (bs:byte []) : NoMDEntryTypesGrp  =
    let pos, mDEntryType = ReadField "ReadNoMDEntryTypes" pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryType
    failwith "not implemented"

// group
let ReadNoMDEntriesGrp (pos:int) (bs:byte []) : NoMDEntriesGrp  =
    let pos, mDEntryType = ReadField "ReadNoMDEntries" pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryType
    let pos, mDEntryPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryPx
    let pos, currency = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCurrency
    let pos, mDEntrySize = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntrySize
    let pos, mDEntryDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryDate
    let pos, mDEntryTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryTime
    let pos, tickDirection = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTickDirection
    let pos, mDMkt = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDMkt
    let pos, tradingSessionID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    let pos, quoteCondition = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteCondition
    let pos, tradeCondition = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeCondition
    let pos, mDEntryOriginator = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryOriginator
    let pos, locationID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLocationID
    let pos, deskID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadDeskID
    let pos, openCloseSettlFlag = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOpenCloseSettlFlag
    let pos, timeInForce = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTimeInForce
    let pos, expireDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExpireDate
    let pos, expireTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExpireTime
    let pos, minQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMinQty
    let pos, execInst = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExecInst
    let pos, sellerDays = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSellerDays
    let pos, orderID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderID
    let pos, quoteEntryID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadQuoteEntryID
    let pos, mDEntryBuyer = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryBuyer
    let pos, mDEntrySeller = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntrySeller
    let pos, numberOfOrders = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNumberOfOrders
    let pos, mDEntryPositionNo = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadMDEntryPositionNo
    let pos, scope = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadScope
    let pos, priceDelta = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadPriceDelta
    let pos, text = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedText
    failwith "not implemented"

// group
let ReadNoAltMDSourceGrp (pos:int) (bs:byte []) : NoAltMDSourceGrp  =
    let pos, altMDSourceID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAltMDSourceID
    failwith "not implemented"

// group
let ReadNoSecurityTypesGrp (pos:int) (bs:byte []) : NoSecurityTypesGrp  =
    let pos, securityType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecurityType
    let pos, securitySubType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecuritySubType
    let pos, product = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadProduct
    let pos, cFICode = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCFICode
    failwith "not implemented"

// group
let ReadNoContraBrokersGrp (pos:int) (bs:byte []) : NoContraBrokersGrp  =
    let pos, contraBroker = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadContraBroker
    let pos, contraTrader = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadContraTrader
    let pos, contraTradeQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadContraTradeQty
    let pos, contraTradeTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadContraTradeTime
    let pos, contraLegRefID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadContraLegRefID
    failwith "not implemented"

// group
let ReadNoAffectedOrdersGrp (pos:int) (bs:byte []) : NoAffectedOrdersGrp  =
    let pos, origClOrdID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrigClOrdID
    let pos, affectedOrderID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAffectedOrderID
    let pos, affectedSecondaryOrderID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAffectedSecondaryOrderID
    failwith "not implemented"

// group
let ReadNoBidDescriptorsGrp (pos:int) (bs:byte []) : NoBidDescriptorsGrp  =
    let pos, bidDescriptorType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidDescriptorType
    let pos, bidDescriptor = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadBidDescriptor
    let pos, sideValueInd = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSideValueInd
    let pos, liquidityValue = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLiquidityValue
    let pos, liquidityNumSecurities = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLiquidityNumSecurities
    let pos, liquidityPctLow = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLiquidityPctLow
    let pos, liquidityPctHigh = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLiquidityPctHigh
    let pos, eFPTrackingError = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEFPTrackingError
    let pos, fairValue = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadFairValue
    let pos, outsideIndexPct = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOutsideIndexPct
    let pos, valueOfFutures = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadValueOfFutures
    failwith "not implemented"

// group
let ReadNoBidComponentsGrp (pos:int) (bs:byte []) : NoBidComponentsGrp  =
    let pos, listID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadListID
    let pos, side = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSide
    let pos, tradingSessionID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradingSessionSubID
    let pos, netGrossInd = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadNetGrossInd
    let pos, settlType = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlType
    let pos, settlDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSettlDate
    let pos, account = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAccount
    let pos, acctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAcctIDSource
    failwith "not implemented"

// group
let ReadListStatus_NoOrdersGrp (pos:int) (bs:byte []) : ListStatus_NoOrdersGrp  =
    let pos, clOrdID = ReadField "ReadListStatus_NoOrders" pos "tag"B bs Fix44.FieldReadFuncs.ReadClOrdID
    let pos, secondaryClOrdID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecondaryClOrdID
    let pos, cumQty = ReadField "ReadListStatus_NoOrders" pos "tag"B bs Fix44.FieldReadFuncs.ReadCumQty
    let pos, ordStatus = ReadField "ReadListStatus_NoOrders" pos "tag"B bs Fix44.FieldReadFuncs.ReadOrdStatus
    let pos, workingIndicator = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadWorkingIndicator
    let pos, leavesQty = ReadField "ReadListStatus_NoOrders" pos "tag"B bs Fix44.FieldReadFuncs.ReadLeavesQty
    let pos, cxlQty = ReadField "ReadListStatus_NoOrders" pos "tag"B bs Fix44.FieldReadFuncs.ReadCxlQty
    let pos, avgPx = ReadField "ReadListStatus_NoOrders" pos "tag"B bs Fix44.FieldReadFuncs.ReadAvgPx
    let pos, ordRejReason = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrdRejReason
    let pos, text = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadText
    let pos, encodedText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedText
    failwith "not implemented"

// group
let ReadAllocationInstruction_NoExecsGrp (pos:int) (bs:byte []) : AllocationInstruction_NoExecsGrp  =
    let pos, lastQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLastQty
    let pos, execID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExecID
    let pos, secondaryExecID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecondaryExecID
    let pos, lastPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLastPx
    let pos, lastParPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLastParPx
    let pos, lastCapacity = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLastCapacity
    failwith "not implemented"

// group
let ReadAllocationInstructionAck_NoAllocsGrp (pos:int) (bs:byte []) : AllocationInstructionAck_NoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAcctIDSource
    let pos, allocPrice = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocPrice
    let pos, individualAllocID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadIndividualAllocID
    let pos, individualAllocRejCode = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadIndividualAllocRejCode
    let pos, allocText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocText
    let pos, encodedAllocText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedAllocText
    failwith "not implemented"

// group
let ReadAllocationReport_NoExecsGrp (pos:int) (bs:byte []) : AllocationReport_NoExecsGrp  =
    let pos, lastQty = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLastQty
    let pos, execID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExecID
    let pos, secondaryExecID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecondaryExecID
    let pos, lastPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLastPx
    let pos, lastParPx = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLastParPx
    let pos, lastCapacity = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLastCapacity
    failwith "not implemented"

// group
let ReadAllocationReportAck_NoAllocsGrp (pos:int) (bs:byte []) : AllocationReportAck_NoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocAcctIDSource
    let pos, allocPrice = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocPrice
    let pos, individualAllocID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadIndividualAllocID
    let pos, individualAllocRejCode = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadIndividualAllocRejCode
    let pos, allocText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadAllocText
    let pos, encodedAllocText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadEncodedAllocText
    failwith "not implemented"

// group
let ReadNoCapacitiesGrp (pos:int) (bs:byte [])  =
    let pos, orderCapacity = ReadField "ReadNoCapacities" pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderRestrictions
    let pos, orderCapacityQty = ReadField "ReadNoCapacities" pos "tag"B bs Fix44.FieldReadFuncs.ReadOrderCapacityQty
    let grp = 
        {
            OrderCapacity = orderCapacity
            OrderRestrictions = orderRestrictions
            OrderCapacityQty = orderCapacityQty
        }
    pos, grp

// group
let ReadNoDatesGrp (pos:int) (bs:byte []) : NoDatesGrp  =
    let pos, tradeDate = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeDate
    let pos, transactTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTransactTime
    failwith "not implemented"

// group
let ReadNoDistribInstsGrp (pos:int) (bs:byte []) : NoDistribInstsGrp  =
    let pos, distribPaymentMethod = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadDistribPaymentMethod
    let pos, distribPercentage = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadDistribPercentage
    let pos, cashDistribCurr = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCashDistribCurr
    let pos, cashDistribAgentName = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCashDistribAgentName
    let pos, cashDistribAgentCode = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCashDistribAgentCode
    let pos, cashDistribAgentAcctNumber = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCashDistribAgentAcctNumber
    let pos, cashDistribPayRef = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCashDistribPayRef
    let pos, cashDistribAgentAcctName = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCashDistribAgentAcctName
    failwith "not implemented"

// group
let ReadNoExecsGrp (pos:int) (bs:byte []) : NoExecsGrp  =
    let pos, execID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadExecID
    failwith "not implemented"

// group
let ReadNoTradesGrp (pos:int) (bs:byte []) : NoTradesGrp  =
    let pos, tradeReportID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadTradeReportID
    let pos, secondaryTradeReportID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadSecondaryTradeReportID
    failwith "not implemented"

// group
let ReadNoCollInquiryQualifierGrp (pos:int) (bs:byte []) : NoCollInquiryQualifierGrp  =
    let pos, collInquiryQualifier = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadCollInquiryQualifier
    failwith "not implemented"

// group
let ReadNoCompIDsGrp (pos:int) (bs:byte []) : NoCompIDsGrp  =
    let pos, refCompID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadRefCompID
    let pos, refSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadRefSubID
    let pos, locationID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLocationID
    let pos, deskID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadDeskID
    failwith "not implemented"

// group
let ReadNetworkStatusResponse_NoCompIDsGrp (pos:int) (bs:byte []) : NetworkStatusResponse_NoCompIDsGrp  =
    let pos, refCompID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadRefCompID
    let pos, refSubID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadRefSubID
    let pos, locationID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadLocationID
    let pos, deskID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadDeskID
    let pos, statusValue = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadStatusValue
    let pos, statusText = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadStatusText
    failwith "not implemented"

// group
let ReadNoHopsGrp (pos:int) (bs:byte []) : NoHopsGrp  =
    let pos, hopCompID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadHopCompID
    let pos, hopSendingTime = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadHopSendingTime
    let pos, hopRefID = ReadOptionalField pos "tag"B bs Fix44.FieldReadFuncs.ReadHopRefID
    failwith "not implemented"

