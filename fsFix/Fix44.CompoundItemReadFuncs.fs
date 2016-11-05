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
    failwith "not implemented"

// group
let ReadNoUnderlyingStipsGrp (pos:int) (bs:byte []) : int * NoUnderlyingStipsGrp  =
    let pos, underlyingStipType = ReadOptionalField pos "888"B bs ReadUnderlyingStipType
    let pos, underlyingStipValue = ReadOptionalField pos "889"B bs ReadUnderlyingStipValue
    failwith "not implemented"

// group
let ReadCollateralResponseNoUnderlyingsGrp (pos:int) (bs:byte []) : int * CollateralResponseNoUnderlyingsGrp  =
    let pos, collAction = ReadOptionalField pos "944"B bs ReadCollAction
    failwith "not implemented"

// group
let ReadCollateralAssignmentNoUnderlyingsGrp (pos:int) (bs:byte []) : int * CollateralAssignmentNoUnderlyingsGrp  =
    let pos, collAction = ReadOptionalField pos "944"B bs ReadCollAction
    failwith "not implemented"

// group
let ReadCollateralRequestNoUnderlyingsGrp (pos:int) (bs:byte []) : int * CollateralRequestNoUnderlyingsGrp  =
    let pos, collAction = ReadOptionalField pos "944"B bs ReadCollAction
    failwith "not implemented"

// group
let ReadPositionReportNoUnderlyingsGrp (pos:int) (bs:byte []) : int * PositionReportNoUnderlyingsGrp  =
    let pos, underlyingSettlPrice = ReadField "ReadPositionReportNoUnderlyings" pos "732"B bs ReadUnderlyingSettlPrice
    let pos, underlyingSettlPriceType = ReadField "ReadPositionReportNoUnderlyings" pos "733"B bs ReadUnderlyingSettlPriceType
    failwith "not implemented"

// group
let ReadNoNestedPartySubIDsGrp (pos:int) (bs:byte []) : int * NoNestedPartySubIDsGrp  =
    let pos, nestedPartySubID = ReadOptionalField pos "545"B bs ReadNestedPartySubID
    let pos, nestedPartySubIDType = ReadOptionalField pos "805"B bs ReadNestedPartySubIDType
    failwith "not implemented"

// group
let ReadNoNestedPartyIDsGrp (pos:int) (bs:byte []) : int * NoNestedPartyIDsGrp  =
    let pos, nestedPartyID = ReadOptionalField pos "524"B bs ReadNestedPartyID
    let pos, nestedPartyIDSource = ReadOptionalField pos "525"B bs ReadNestedPartyIDSource
    let pos, nestedPartyRole = ReadOptionalField pos "538"B bs ReadNestedPartyRole
    failwith "not implemented"

// group
let ReadNoPositionsGrp (pos:int) (bs:byte []) : int * NoPositionsGrp  =
    let pos, posType = ReadOptionalField pos "703"B bs ReadPosType
    let pos, longQty = ReadOptionalField pos "704"B bs ReadLongQty
    let pos, shortQty = ReadOptionalField pos "705"B bs ReadShortQty
    let pos, posQtyStatus = ReadOptionalField pos "706"B bs ReadPosQtyStatus
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
    failwith "not implemented"

// group
let ReadNoNested2PartySubIDsGrp (pos:int) (bs:byte []) : int * NoNested2PartySubIDsGrp  =
    let pos, nested2PartySubID = ReadOptionalField pos "760"B bs ReadNested2PartySubID
    let pos, nested2PartySubIDType = ReadOptionalField pos "807"B bs ReadNested2PartySubIDType
    failwith "not implemented"

// group
let ReadNoNested2PartyIDsGrp (pos:int) (bs:byte []) : int * NoNested2PartyIDsGrp  =
    let pos, nested2PartyID = ReadOptionalField pos "757"B bs ReadNested2PartyID
    let pos, nested2PartyIDSource = ReadOptionalField pos "758"B bs ReadNested2PartyIDSource
    let pos, nested2PartyRole = ReadOptionalField pos "759"B bs ReadNested2PartyRole
    failwith "not implemented"

// group
let ReadTradeCaptureReportAckNoAllocsGrp (pos:int) (bs:byte []) : int * TradeCaptureReportAckNoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "79"B bs ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "661"B bs ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField pos "736"B bs ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField pos "467"B bs ReadIndividualAllocID
    let pos, allocQty = ReadOptionalField pos "80"B bs ReadAllocQty
    failwith "not implemented"

// group
let ReadNoLegSecurityAltIDGrp (pos:int) (bs:byte []) : int * NoLegSecurityAltIDGrp  =
    let pos, legSecurityAltID = ReadOptionalField pos "605"B bs ReadLegSecurityAltID
    let pos, legSecurityAltIDSource = ReadOptionalField pos "606"B bs ReadLegSecurityAltIDSource
    failwith "not implemented"

// group
let ReadNoLegStipulationsGrp (pos:int) (bs:byte []) : int * NoLegStipulationsGrp  =
    let pos, legStipulationType = ReadOptionalField pos "688"B bs ReadLegStipulationType
    let pos, legStipulationValue = ReadOptionalField pos "689"B bs ReadLegStipulationValue
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
    failwith "not implemented"

// group
let ReadNoPartySubIDsGrp (pos:int) (bs:byte []) : int * NoPartySubIDsGrp  =
    let pos, partySubID = ReadOptionalField pos "523"B bs ReadPartySubID
    let pos, partySubIDType = ReadOptionalField pos "803"B bs ReadPartySubIDType
    failwith "not implemented"

// group
let ReadNoPartyIDsGrp (pos:int) (bs:byte []) : int * NoPartyIDsGrp  =
    let pos, partyID = ReadOptionalField pos "448"B bs ReadPartyID
    let pos, partyIDSource = ReadOptionalField pos "447"B bs ReadPartyIDSource
    let pos, partyRole = ReadOptionalField pos "452"B bs ReadPartyRole
    failwith "not implemented"

// group
let ReadNoClearingInstructionsGrp (pos:int) (bs:byte []) : int * NoClearingInstructionsGrp  =
    let pos, clearingInstruction = ReadOptionalField pos "577"B bs ReadClearingInstruction
    failwith "not implemented"

// group
let ReadNoContAmtsGrp (pos:int) (bs:byte []) : int * NoContAmtsGrp  =
    let pos, contAmtType = ReadOptionalField pos "519"B bs ReadContAmtType
    let pos, contAmtValue = ReadOptionalField pos "520"B bs ReadContAmtValue
    let pos, contAmtCurr = ReadOptionalField pos "521"B bs ReadContAmtCurr
    failwith "not implemented"

// group
let ReadNoStipulationsGrp (pos:int) (bs:byte []) : int * NoStipulationsGrp  =
    let pos, stipulationType = ReadOptionalField pos "233"B bs ReadStipulationType
    let pos, stipulationValue = ReadOptionalField pos "234"B bs ReadStipulationValue
    failwith "not implemented"

// group
let ReadNoMiscFeesGrp (pos:int) (bs:byte []) : int * NoMiscFeesGrp  =
    let pos, miscFeeAmt = ReadOptionalField pos "137"B bs ReadMiscFeeAmt
    let pos, miscFeeCurr = ReadOptionalField pos "138"B bs ReadMiscFeeCurr
    let pos, miscFeeType = ReadOptionalField pos "139"B bs ReadMiscFeeType
    let pos, miscFeeBasis = ReadOptionalField pos "891"B bs ReadMiscFeeBasis
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
    failwith "not implemented"

// group
let ReadNoPosAmtGrp (pos:int) (bs:byte []) : int * NoPosAmtGrp  =
    let pos, posAmtType = ReadField "ReadNoPosAmt" pos "707"B bs ReadPosAmtType
    let pos, posAmt = ReadField "ReadNoPosAmt" pos "708"B bs ReadPosAmt
    failwith "not implemented"

// group
let ReadNoSettlPartySubIDsGrp (pos:int) (bs:byte []) : int * NoSettlPartySubIDsGrp  =
    let pos, settlPartySubID = ReadOptionalField pos "785"B bs ReadSettlPartySubID
    let pos, settlPartySubIDType = ReadOptionalField pos "786"B bs ReadSettlPartySubIDType
    failwith "not implemented"

// group
let ReadNoSettlPartyIDsGrp (pos:int) (bs:byte []) : int * NoSettlPartyIDsGrp  =
    let pos, settlPartyID = ReadOptionalField pos "782"B bs ReadSettlPartyID
    let pos, settlPartyIDSource = ReadOptionalField pos "783"B bs ReadSettlPartyIDSource
    let pos, settlPartyRole = ReadOptionalField pos "784"B bs ReadSettlPartyRole
    failwith "not implemented"

// group
let ReadNoDlvyInstGrp (pos:int) (bs:byte []) : int * NoDlvyInstGrp  =
    let pos, settlInstSource = ReadOptionalField pos "165"B bs ReadSettlInstSource
    let pos, dlvyInstType = ReadOptionalField pos "787"B bs ReadDlvyInstType
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
    failwith "not implemented"

// group
let ReadNoTrdRegTimestampsGrp (pos:int) (bs:byte []) : int * NoTrdRegTimestampsGrp  =
    let pos, trdRegTimestamp = ReadOptionalField pos "769"B bs ReadTrdRegTimestamp
    let pos, trdRegTimestampType = ReadOptionalField pos "770"B bs ReadTrdRegTimestampType
    let pos, trdRegTimestampOrigin = ReadOptionalField pos "771"B bs ReadTrdRegTimestampOrigin
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
    failwith "not implemented"

// group
let ReadNoSecurityAltIDGrp (pos:int) (bs:byte []) : int * NoSecurityAltIDGrp  =
    let pos, securityAltID = ReadOptionalField pos "455"B bs ReadSecurityAltID
    let pos, securityAltIDSource = ReadOptionalField pos "456"B bs ReadSecurityAltIDSource
    failwith "not implemented"

// group
let ReadNoEventsGrp (pos:int) (bs:byte []) : int * NoEventsGrp  =
    let pos, eventType = ReadOptionalField pos "865"B bs ReadEventType
    let pos, eventDate = ReadOptionalField pos "866"B bs ReadEventDate
    let pos, eventPx = ReadOptionalField pos "867"B bs ReadEventPx
    let pos, eventText = ReadOptionalField pos "868"B bs ReadEventText
    failwith "not implemented"

// group
let ReadNoStrikesGrp (pos:int) (bs:byte []) : int * NoStrikesGrp  =
    failwith "not implemented"

// group
let ReadNoAllocsGrp (pos:int) (bs:byte []) : int * NoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "79"B bs ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "661"B bs ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField pos "736"B bs ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField pos "467"B bs ReadIndividualAllocID
    let pos, allocQty = ReadOptionalField pos "80"B bs ReadAllocQty
    failwith "not implemented"

// group
let ReadNoTradingSessionsGrp (pos:int) (bs:byte []) : int * NoTradingSessionsGrp  =
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    failwith "not implemented"

// group
let ReadNoUnderlyingsGrp (pos:int) (bs:byte []) : int * NoUnderlyingsGrp  =
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
    let pos, prevClosePx = ReadOptionalField pos "140"B bs ReadPrevClosePx
    let pos, side = ReadField "ReadNewOrderListNoOrders" pos "54"B bs ReadSide
    let pos, sideValueInd = ReadOptionalField pos "401"B bs ReadSideValueInd
    let pos, locateReqd = ReadOptionalField pos "114"B bs ReadLocateReqd
    let pos, transactTime = ReadOptionalField pos "60"B bs ReadTransactTime
    let pos, qtyType = ReadOptionalField pos "854"B bs ReadQtyType
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
    failwith "not implemented"

// group
let ReadBidResponseNoBidComponentsGrp (pos:int) (bs:byte []) : int * BidResponseNoBidComponentsGrp  =
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
    failwith "not implemented"

// group
let ReadNoLegAllocsGrp (pos:int) (bs:byte []) : int * NoLegAllocsGrp  =
    let pos, legAllocAccount = ReadOptionalField pos "671"B bs ReadLegAllocAccount
    let pos, legIndividualAllocID = ReadOptionalField pos "672"B bs ReadLegIndividualAllocID
    let pos, legAllocQty = ReadOptionalField pos "673"B bs ReadLegAllocQty
    let pos, legAllocAcctIDSource = ReadOptionalField pos "674"B bs ReadLegAllocAcctIDSource
    let pos, legSettlCurrency = ReadOptionalField pos "675"B bs ReadLegSettlCurrency
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
    failwith "not implemented"

// group
let ReadNoNested3PartySubIDsGrp (pos:int) (bs:byte []) : int * NoNested3PartySubIDsGrp  =
    let pos, nested3PartySubID = ReadOptionalField pos "953"B bs ReadNested3PartySubID
    let pos, nested3PartySubIDType = ReadOptionalField pos "954"B bs ReadNested3PartySubIDType
    failwith "not implemented"

// group
let ReadNoNested3PartyIDsGrp (pos:int) (bs:byte []) : int * NoNested3PartyIDsGrp  =
    let pos, nested3PartyID = ReadOptionalField pos "949"B bs ReadNested3PartyID
    let pos, nested3PartyIDSource = ReadOptionalField pos "950"B bs ReadNested3PartyIDSource
    let pos, nested3PartyRole = ReadOptionalField pos "951"B bs ReadNested3PartyRole
    failwith "not implemented"

// group
let ReadMultilegOrderCancelReplaceRequestNoAllocsGrp (pos:int) (bs:byte []) : int * MultilegOrderCancelReplaceRequestNoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "79"B bs ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "661"B bs ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField pos "736"B bs ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField pos "467"B bs ReadIndividualAllocID
    let pos, allocQty = ReadOptionalField pos "80"B bs ReadAllocQty
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
    failwith "not implemented"

// group
let ReadNewOrderMultilegNoAllocsGrp (pos:int) (bs:byte []) : int * NewOrderMultilegNoAllocsGrp  =
    let pos, allocAccount = ReadOptionalField pos "79"B bs ReadAllocAccount
    let pos, allocAcctIDSource = ReadOptionalField pos "661"B bs ReadAllocAcctIDSource
    let pos, allocSettlCurrency = ReadOptionalField pos "736"B bs ReadAllocSettlCurrency
    let pos, individualAllocID = ReadOptionalField pos "467"B bs ReadIndividualAllocID
    let pos, allocQty = ReadOptionalField pos "80"B bs ReadAllocQty
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
    let pos, complianceID = ReadOptionalField pos "376"B bs ReadComplianceID
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
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
    failwith "not implemented"

// group
let ReadNoInstrAttribGrp (pos:int) (bs:byte []) : int * NoInstrAttribGrp  =
    let pos, instrAttribType = ReadOptionalField pos "871"B bs ReadInstrAttribType
    let pos, instrAttribValue = ReadOptionalField pos "872"B bs ReadInstrAttribValue
    failwith "not implemented"

// group
let ReadNoLegsGrp (pos:int) (bs:byte []) : int * NoLegsGrp  =
    failwith "not implemented"

// group
let ReadDerivativeSecurityListNoRelatedSymGrp (pos:int) (bs:byte []) : int * DerivativeSecurityListNoRelatedSymGrp  =
    let pos, currency = ReadOptionalField pos "15"B bs ReadCurrency
    let pos, expirationCycle = ReadOptionalField pos "827"B bs ReadExpirationCycle
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    let pos, text = ReadOptionalField pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    failwith "not implemented"

// group
let ReadSecurityListNoLegsGrp (pos:int) (bs:byte []) : int * SecurityListNoLegsGrp  =
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
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
    failwith "not implemented"

// group
let ReadMarketDataRequestNoRelatedSymGrp (pos:int) (bs:byte []) : int * MarketDataRequestNoRelatedSymGrp  =
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
    failwith "not implemented"

// group
let ReadMassQuoteAcknowledgementNoQuoteSetsGrp (pos:int) (bs:byte []) : int * MassQuoteAcknowledgementNoQuoteSetsGrp  =
    let pos, quoteSetID = ReadOptionalField pos "302"B bs ReadQuoteSetID
    let pos, totNoQuoteEntries = ReadOptionalField pos "304"B bs ReadTotNoQuoteEntries
    let pos, lastFragment = ReadOptionalField pos "893"B bs ReadLastFragment
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
    failwith "not implemented"

// group
let ReadNoQuoteSetsGrp (pos:int) (bs:byte []) : int * NoQuoteSetsGrp  =
    let pos, quoteSetID = ReadField "ReadNoQuoteSets" pos "302"B bs ReadQuoteSetID
    let pos, quoteSetValidUntilTime = ReadOptionalField pos "367"B bs ReadQuoteSetValidUntilTime
    let pos, totNoQuoteEntries = ReadField "ReadNoQuoteSets" pos "304"B bs ReadTotNoQuoteEntries
    let pos, lastFragment = ReadOptionalField pos "893"B bs ReadLastFragment
    failwith "not implemented"

// group
let ReadQuoteStatusReportNoLegsGrp (pos:int) (bs:byte []) : int * QuoteStatusReportNoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "687"B bs ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "588"B bs ReadLegSettlDate
    failwith "not implemented"

// group
let ReadNoQuoteEntriesGrp (pos:int) (bs:byte []) : int * NoQuoteEntriesGrp  =
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
    failwith "not implemented"

// group
let ReadRFQRequestNoRelatedSymGrp (pos:int) (bs:byte []) : int * RFQRequestNoRelatedSymGrp  =
    let pos, prevClosePx = ReadOptionalField pos "140"B bs ReadPrevClosePx
    let pos, quoteRequestType = ReadOptionalField pos "303"B bs ReadQuoteRequestType
    let pos, quoteType = ReadOptionalField pos "537"B bs ReadQuoteType
    let pos, tradingSessionID = ReadOptionalField pos "336"B bs ReadTradingSessionID
    let pos, tradingSessionSubID = ReadOptionalField pos "625"B bs ReadTradingSessionSubID
    failwith "not implemented"

// group
let ReadQuoteRequestRejectNoLegsGrp (pos:int) (bs:byte []) : int * QuoteRequestRejectNoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "687"B bs ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "588"B bs ReadLegSettlDate
    failwith "not implemented"

// group
let ReadQuoteRequestRejectNoRelatedSymGrp (pos:int) (bs:byte []) : int * QuoteRequestRejectNoRelatedSymGrp  =
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
    failwith "not implemented"

// group
let ReadQuoteRequestNoLegsGrp (pos:int) (bs:byte []) : int * QuoteRequestNoLegsGrp  =
    let pos, legQty = ReadOptionalField pos "687"B bs ReadLegQty
    let pos, legSwapType = ReadOptionalField pos "690"B bs ReadLegSwapType
    let pos, legSettlType = ReadOptionalField pos "587"B bs ReadLegSettlType
    let pos, legSettlDate = ReadOptionalField pos "588"B bs ReadLegSettlDate
    failwith "not implemented"

// group
let ReadNoQuoteQualifiersGrp (pos:int) (bs:byte []) : int * NoQuoteQualifiersGrp  =
    let pos, quoteQualifier = ReadOptionalField pos "695"B bs ReadQuoteQualifier
    failwith "not implemented"

// group
let ReadQuoteRequestNoRelatedSymGrp (pos:int) (bs:byte []) : int * QuoteRequestNoRelatedSymGrp  =
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
    failwith "not implemented"

// group
let ReadNoRelatedSymGrp (pos:int) (bs:byte []) : int * NoRelatedSymGrp  =
    failwith "not implemented"

// group
let ReadIndicationOfInterestNoLegsGrp (pos:int) (bs:byte []) : int * IndicationOfInterestNoLegsGrp  =
    let pos, legIOIQty = ReadOptionalField pos "682"B bs ReadLegIOIQty
    failwith "not implemented"

// group
let ReadAdvertisementNoUnderlyingsGrp (pos:int) (bs:byte []) : int * AdvertisementNoUnderlyingsGrp  =
    failwith "not implemented"

// group
let ReadNoMsgTypesGrp (pos:int) (bs:byte []) : int * NoMsgTypesGrp  =
    let pos, refMsgType = ReadOptionalField pos "372"B bs ReadRefMsgType
    let pos, msgDirection = ReadOptionalField pos "385"B bs ReadMsgDirection
    failwith "not implemented"

// group
let ReadNoIOIQualifiersGrp (pos:int) (bs:byte []) : int * NoIOIQualifiersGrp  =
    let pos, iOIQualifier = ReadOptionalField pos "104"B bs ReadIOIQualifier
    failwith "not implemented"

// group
let ReadNoRoutingIDsGrp (pos:int) (bs:byte []) : int * NoRoutingIDsGrp  =
    let pos, routingType = ReadOptionalField pos "216"B bs ReadRoutingType
    let pos, routingID = ReadOptionalField pos "217"B bs ReadRoutingID
    failwith "not implemented"

// group
let ReadLinesOfTextGrp (pos:int) (bs:byte []) : int * LinesOfTextGrp  =
    let pos, text = ReadField "ReadLinesOfText" pos "58"B bs ReadText
    let pos, encodedText = ReadOptionalField pos "355"B bs ReadEncodedText
    failwith "not implemented"

// group
let ReadNoMDEntryTypesGrp (pos:int) (bs:byte []) : int * NoMDEntryTypesGrp  =
    let pos, mDEntryType = ReadField "ReadNoMDEntryTypes" pos "269"B bs ReadMDEntryType
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
    failwith "not implemented"

// group
let ReadNoAltMDSourceGrp (pos:int) (bs:byte []) : int * NoAltMDSourceGrp  =
    let pos, altMDSourceID = ReadOptionalField pos "817"B bs ReadAltMDSourceID
    failwith "not implemented"

// group
let ReadNoSecurityTypesGrp (pos:int) (bs:byte []) : int * NoSecurityTypesGrp  =
    let pos, securityType = ReadOptionalField pos "167"B bs ReadSecurityType
    let pos, securitySubType = ReadOptionalField pos "762"B bs ReadSecuritySubType
    let pos, product = ReadOptionalField pos "460"B bs ReadProduct
    let pos, cFICode = ReadOptionalField pos "461"B bs ReadCFICode
    failwith "not implemented"

// group
let ReadNoContraBrokersGrp (pos:int) (bs:byte []) : int * NoContraBrokersGrp  =
    let pos, contraBroker = ReadOptionalField pos "375"B bs ReadContraBroker
    let pos, contraTrader = ReadOptionalField pos "337"B bs ReadContraTrader
    let pos, contraTradeQty = ReadOptionalField pos "437"B bs ReadContraTradeQty
    let pos, contraTradeTime = ReadOptionalField pos "438"B bs ReadContraTradeTime
    let pos, contraLegRefID = ReadOptionalField pos "655"B bs ReadContraLegRefID
    failwith "not implemented"

// group
let ReadNoAffectedOrdersGrp (pos:int) (bs:byte []) : int * NoAffectedOrdersGrp  =
    let pos, origClOrdID = ReadOptionalField pos "41"B bs ReadOrigClOrdID
    let pos, affectedOrderID = ReadOptionalField pos "535"B bs ReadAffectedOrderID
    let pos, affectedSecondaryOrderID = ReadOptionalField pos "536"B bs ReadAffectedSecondaryOrderID
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
    failwith "not implemented"

// group
let ReadAllocationInstructionNoExecsGrp (pos:int) (bs:byte []) : int * AllocationInstructionNoExecsGrp  =
    let pos, lastQty = ReadOptionalField pos "32"B bs ReadLastQty
    let pos, execID = ReadOptionalField pos "17"B bs ReadExecID
    let pos, secondaryExecID = ReadOptionalField pos "527"B bs ReadSecondaryExecID
    let pos, lastPx = ReadOptionalField pos "31"B bs ReadLastPx
    let pos, lastParPx = ReadOptionalField pos "669"B bs ReadLastParPx
    let pos, lastCapacity = ReadOptionalField pos "29"B bs ReadLastCapacity
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
    failwith "not implemented"

// group
let ReadAllocationReportNoExecsGrp (pos:int) (bs:byte []) : int * AllocationReportNoExecsGrp  =
    let pos, lastQty = ReadOptionalField pos "32"B bs ReadLastQty
    let pos, execID = ReadOptionalField pos "17"B bs ReadExecID
    let pos, secondaryExecID = ReadOptionalField pos "527"B bs ReadSecondaryExecID
    let pos, lastPx = ReadOptionalField pos "31"B bs ReadLastPx
    let pos, lastParPx = ReadOptionalField pos "669"B bs ReadLastParPx
    let pos, lastCapacity = ReadOptionalField pos "29"B bs ReadLastCapacity
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
    failwith "not implemented"

// group
let ReadNoCapacitiesGrp (pos:int) (bs:byte []) : int * NoCapacitiesGrp  =
    let pos, orderCapacity = ReadField "ReadNoCapacities" pos "528"B bs ReadOrderCapacity
    let pos, orderRestrictions = ReadOptionalField pos "529"B bs ReadOrderRestrictions
    let pos, orderCapacityQty = ReadField "ReadNoCapacities" pos "863"B bs ReadOrderCapacityQty
    let grp = 
        {
            OrderCapacity = orderCapacity
            OrderRestrictions = orderRestrictions
            OrderCapacityQty = orderCapacityQty
        }
    pos, grp


// group
let ReadNoDatesGrp (pos:int) (bs:byte []) : int * NoDatesGrp  =
    let pos, tradeDate = ReadOptionalField pos "75"B bs ReadTradeDate
    let pos, transactTime = ReadOptionalField pos "60"B bs ReadTransactTime
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
    failwith "not implemented"

// group
let ReadNoExecsGrp (pos:int) (bs:byte []) : int * NoExecsGrp  =
    let pos, execID = ReadOptionalField pos "17"B bs ReadExecID
    failwith "not implemented"

// group
let ReadNoTradesGrp (pos:int) (bs:byte []) : int * NoTradesGrp  =
    let pos, tradeReportID = ReadOptionalField pos "571"B bs ReadTradeReportID
    let pos, secondaryTradeReportID = ReadOptionalField pos "818"B bs ReadSecondaryTradeReportID
    failwith "not implemented"

// group
let ReadNoCollInquiryQualifierGrp (pos:int) (bs:byte []) : int * NoCollInquiryQualifierGrp  =
    let pos, collInquiryQualifier = ReadOptionalField pos "896"B bs ReadCollInquiryQualifier
    failwith "not implemented"

// group
let ReadNoCompIDsGrp (pos:int) (bs:byte []) : int * NoCompIDsGrp  =
    let pos, refCompID = ReadOptionalField pos "930"B bs ReadRefCompID
    let pos, refSubID = ReadOptionalField pos "931"B bs ReadRefSubID
    let pos, locationID = ReadOptionalField pos "283"B bs ReadLocationID
    let pos, deskID = ReadOptionalField pos "284"B bs ReadDeskID
    failwith "not implemented"

// group
let ReadNetworkStatusResponseNoCompIDsGrp (pos:int) (bs:byte []) : int * NetworkStatusResponseNoCompIDsGrp  =
    let pos, refCompID = ReadOptionalField pos "930"B bs ReadRefCompID
    let pos, refSubID = ReadOptionalField pos "931"B bs ReadRefSubID
    let pos, locationID = ReadOptionalField pos "283"B bs ReadLocationID
    let pos, deskID = ReadOptionalField pos "284"B bs ReadDeskID
    let pos, statusValue = ReadOptionalField pos "928"B bs ReadStatusValue
    let pos, statusText = ReadOptionalField pos "929"B bs ReadStatusText
    failwith "not implemented"

// group
let ReadNoHopsGrp (pos:int) (bs:byte []) : int * NoHopsGrp  =
    let pos, hopCompID = ReadOptionalField pos "628"B bs ReadHopCompID
    let pos, hopSendingTime = ReadOptionalField pos "629"B bs ReadHopSendingTime
    let pos, hopRefID = ReadOptionalField pos "630"B bs ReadHopRefID
    failwith "not implemented"

