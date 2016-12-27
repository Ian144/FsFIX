module Fix44.CompoundItemWriters

open Fix44.Fields
open Fix44.FieldWriters
open Fix44.CompoundItems



// group
let WriteNoUnderlyingSecurityAltIDGrp (dest:byte []) (nextFreeIdx:int) (xx:NoUnderlyingSecurityAltIDGrp) =
    let nextFreeIdx = WriteUnderlyingSecurityAltID dest nextFreeIdx xx.UnderlyingSecurityAltID
    let nextFreeIdx = Option.fold (WriteUnderlyingSecurityAltIDSource dest) nextFreeIdx xx.UnderlyingSecurityAltIDSource
    nextFreeIdx


// group
let WriteNoUnderlyingStipsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoUnderlyingStipsGrp) =
    let nextFreeIdx = WriteUnderlyingStipType dest nextFreeIdx xx.UnderlyingStipType
    let nextFreeIdx = Option.fold (WriteUnderlyingStipValue dest) nextFreeIdx xx.UnderlyingStipValue
    nextFreeIdx


// component
let WriteUnderlyingInstrument (dest:byte []) (nextFreeIdx:int) (xx:UnderlyingInstrument) =
    let nextFreeIdx = WriteUnderlyingSymbol dest nextFreeIdx xx.UnderlyingSymbol
    let nextFreeIdx = Option.fold (WriteUnderlyingSymbolSfx dest) nextFreeIdx xx.UnderlyingSymbolSfx
    let nextFreeIdx = Option.fold (WriteUnderlyingSecurityID dest) nextFreeIdx xx.UnderlyingSecurityID
    let nextFreeIdx = Option.fold (WriteUnderlyingSecurityIDSource dest) nextFreeIdx xx.UnderlyingSecurityIDSource
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingSecurityAltIDGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyingSecurityAltID dest innerNextFreeIdx (Fix44.Fields.NoUnderlyingSecurityAltID numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingSecurityAltIDGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingSecurityAltIDGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteUnderlyingProduct dest) nextFreeIdx xx.UnderlyingProduct
    let nextFreeIdx = Option.fold (WriteUnderlyingCFICode dest) nextFreeIdx xx.UnderlyingCFICode
    let nextFreeIdx = Option.fold (WriteUnderlyingSecurityType dest) nextFreeIdx xx.UnderlyingSecurityType
    let nextFreeIdx = Option.fold (WriteUnderlyingSecuritySubType dest) nextFreeIdx xx.UnderlyingSecuritySubType
    let nextFreeIdx = Option.fold (WriteUnderlyingMaturityMonthYear dest) nextFreeIdx xx.UnderlyingMaturityMonthYear
    let nextFreeIdx = Option.fold (WriteUnderlyingMaturityDate dest) nextFreeIdx xx.UnderlyingMaturityDate
    let nextFreeIdx = Option.fold (WriteUnderlyingPutOrCall dest) nextFreeIdx xx.UnderlyingPutOrCall
    let nextFreeIdx = Option.fold (WriteUnderlyingCouponPaymentDate dest) nextFreeIdx xx.UnderlyingCouponPaymentDate
    let nextFreeIdx = Option.fold (WriteUnderlyingIssueDate dest) nextFreeIdx xx.UnderlyingIssueDate
    let nextFreeIdx = Option.fold (WriteUnderlyingRepoCollateralSecurityType dest) nextFreeIdx xx.UnderlyingRepoCollateralSecurityType
    let nextFreeIdx = Option.fold (WriteUnderlyingRepurchaseTerm dest) nextFreeIdx xx.UnderlyingRepurchaseTerm
    let nextFreeIdx = Option.fold (WriteUnderlyingRepurchaseRate dest) nextFreeIdx xx.UnderlyingRepurchaseRate
    let nextFreeIdx = Option.fold (WriteUnderlyingFactor dest) nextFreeIdx xx.UnderlyingFactor
    let nextFreeIdx = Option.fold (WriteUnderlyingCreditRating dest) nextFreeIdx xx.UnderlyingCreditRating
    let nextFreeIdx = Option.fold (WriteUnderlyingInstrRegistry dest) nextFreeIdx xx.UnderlyingInstrRegistry
    let nextFreeIdx = Option.fold (WriteUnderlyingCountryOfIssue dest) nextFreeIdx xx.UnderlyingCountryOfIssue
    let nextFreeIdx = Option.fold (WriteUnderlyingStateOrProvinceOfIssue dest) nextFreeIdx xx.UnderlyingStateOrProvinceOfIssue
    let nextFreeIdx = Option.fold (WriteUnderlyingLocaleOfIssue dest) nextFreeIdx xx.UnderlyingLocaleOfIssue
    let nextFreeIdx = Option.fold (WriteUnderlyingRedemptionDate dest) nextFreeIdx xx.UnderlyingRedemptionDate
    let nextFreeIdx = Option.fold (WriteUnderlyingStrikePrice dest) nextFreeIdx xx.UnderlyingStrikePrice
    let nextFreeIdx = Option.fold (WriteUnderlyingStrikeCurrency dest) nextFreeIdx xx.UnderlyingStrikeCurrency
    let nextFreeIdx = Option.fold (WriteUnderlyingOptAttribute dest) nextFreeIdx xx.UnderlyingOptAttribute
    let nextFreeIdx = Option.fold (WriteUnderlyingContractMultiplier dest) nextFreeIdx xx.UnderlyingContractMultiplier
    let nextFreeIdx = Option.fold (WriteUnderlyingCouponRate dest) nextFreeIdx xx.UnderlyingCouponRate
    let nextFreeIdx = Option.fold (WriteUnderlyingSecurityExchange dest) nextFreeIdx xx.UnderlyingSecurityExchange
    let nextFreeIdx = Option.fold (WriteUnderlyingIssuer dest) nextFreeIdx xx.UnderlyingIssuer
    let nextFreeIdx = Option.fold (WriteEncodedUnderlyingIssuer dest) nextFreeIdx xx.EncodedUnderlyingIssuer
    let nextFreeIdx = Option.fold (WriteUnderlyingSecurityDesc dest) nextFreeIdx xx.UnderlyingSecurityDesc
    let nextFreeIdx = Option.fold (WriteEncodedUnderlyingSecurityDesc dest) nextFreeIdx xx.EncodedUnderlyingSecurityDesc
    let nextFreeIdx = Option.fold (WriteUnderlyingCPProgram dest) nextFreeIdx xx.UnderlyingCPProgram
    let nextFreeIdx = Option.fold (WriteUnderlyingCPRegType dest) nextFreeIdx xx.UnderlyingCPRegType
    let nextFreeIdx = Option.fold (WriteUnderlyingCurrency dest) nextFreeIdx xx.UnderlyingCurrency
    let nextFreeIdx = Option.fold (WriteUnderlyingQty dest) nextFreeIdx xx.UnderlyingQty
    let nextFreeIdx = Option.fold (WriteUnderlyingPx dest) nextFreeIdx xx.UnderlyingPx
    let nextFreeIdx = Option.fold (WriteUnderlyingDirtyPrice dest) nextFreeIdx xx.UnderlyingDirtyPrice
    let nextFreeIdx = Option.fold (WriteUnderlyingEndPrice dest) nextFreeIdx xx.UnderlyingEndPrice
    let nextFreeIdx = Option.fold (WriteUnderlyingStartValue dest) nextFreeIdx xx.UnderlyingStartValue
    let nextFreeIdx = Option.fold (WriteUnderlyingCurrentValue dest) nextFreeIdx xx.UnderlyingCurrentValue
    let nextFreeIdx = Option.fold (WriteUnderlyingEndValue dest) nextFreeIdx xx.UnderlyingEndValue
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingStipsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyingStips dest innerNextFreeIdx (Fix44.Fields.NoUnderlyingStips numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingStipsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingStipsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteCollateralResponseNoUnderlyingsGrp (dest:byte []) (nextFreeIdx:int) (xx:CollateralResponseNoUnderlyingsGrp) =
    let nextFreeIdx = WriteUnderlyingInstrument dest nextFreeIdx xx.UnderlyingInstrument   // component
    let nextFreeIdx = Option.fold (WriteCollAction dest) nextFreeIdx xx.CollAction
    nextFreeIdx


// group
let WriteCollateralAssignmentNoUnderlyingsGrp (dest:byte []) (nextFreeIdx:int) (xx:CollateralAssignmentNoUnderlyingsGrp) =
    let nextFreeIdx = WriteUnderlyingInstrument dest nextFreeIdx xx.UnderlyingInstrument   // component
    let nextFreeIdx = Option.fold (WriteCollAction dest) nextFreeIdx xx.CollAction
    nextFreeIdx


// group
let WriteCollateralRequestNoUnderlyingsGrp (dest:byte []) (nextFreeIdx:int) (xx:CollateralRequestNoUnderlyingsGrp) =
    let nextFreeIdx = WriteUnderlyingInstrument dest nextFreeIdx xx.UnderlyingInstrument   // component
    let nextFreeIdx = Option.fold (WriteCollAction dest) nextFreeIdx xx.CollAction
    nextFreeIdx


// group
let WritePositionReportNoUnderlyingsGrp (dest:byte []) (nextFreeIdx:int) (xx:PositionReportNoUnderlyingsGrp) =
    let nextFreeIdx = WriteUnderlyingInstrument dest nextFreeIdx xx.UnderlyingInstrument   // component
    let nextFreeIdx = WriteUnderlyingSettlPrice dest nextFreeIdx xx.UnderlyingSettlPrice
    let nextFreeIdx = WriteUnderlyingSettlPriceType dest nextFreeIdx xx.UnderlyingSettlPriceType
    nextFreeIdx


// group
let WriteNoNestedPartySubIDsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoNestedPartySubIDsGrp) =
    let nextFreeIdx = WriteNestedPartySubID dest nextFreeIdx xx.NestedPartySubID
    let nextFreeIdx = Option.fold (WriteNestedPartySubIDType dest) nextFreeIdx xx.NestedPartySubIDType
    nextFreeIdx


// group
let WriteNoNestedPartyIDsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoNestedPartyIDsGrp) =
    let nextFreeIdx = WriteNestedPartyID dest nextFreeIdx xx.NestedPartyID
    let nextFreeIdx = Option.fold (WriteNestedPartyIDSource dest) nextFreeIdx xx.NestedPartyIDSource
    let nextFreeIdx = Option.fold (WriteNestedPartyRole dest) nextFreeIdx xx.NestedPartyRole
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartySubIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartySubIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartySubIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartySubIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartySubIDsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteNoPositionsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoPositionsGrp) =
    let nextFreeIdx = WritePosType dest nextFreeIdx xx.PosType
    let nextFreeIdx = Option.fold (WriteLongQty dest) nextFreeIdx xx.LongQty
    let nextFreeIdx = Option.fold (WriteShortQty dest) nextFreeIdx xx.ShortQty
    let nextFreeIdx = Option.fold (WritePosQtyStatus dest) nextFreeIdx xx.PosQtyStatus
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    nextFreeIdx


// component
let WritePositionQty (dest:byte []) (nextFreeIdx:int) (xx:PositionQty) =
    let numGrps = xx.NoPositionsGrp.Length
    let nextFreeIdx = WriteNoPositions dest nextFreeIdx (Fix44.Fields.NoPositions numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.NoPositionsGrp |> List.fold (fun accFreeIdx gg -> WriteNoPositionsGrp dest accFreeIdx gg) nextFreeIdx
    nextFreeIdx


// group
let WriteNoRegistDtlsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoRegistDtlsGrp) =
    let nextFreeIdx = WriteRegistDtls dest nextFreeIdx xx.RegistDtls
    let nextFreeIdx = Option.fold (WriteRegistEmail dest) nextFreeIdx xx.RegistEmail
    let nextFreeIdx = Option.fold (WriteMailingDtls dest) nextFreeIdx xx.MailingDtls
    let nextFreeIdx = Option.fold (WriteMailingInst dest) nextFreeIdx xx.MailingInst
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteOwnerType dest) nextFreeIdx xx.OwnerType
    let nextFreeIdx = Option.fold (WriteDateOfBirth dest) nextFreeIdx xx.DateOfBirth
    let nextFreeIdx = Option.fold (WriteInvestorCountryOfResidence dest) nextFreeIdx xx.InvestorCountryOfResidence
    nextFreeIdx


// group
let WriteNoNested2PartySubIDsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoNested2PartySubIDsGrp) =
    let nextFreeIdx = WriteNested2PartySubID dest nextFreeIdx xx.Nested2PartySubID
    let nextFreeIdx = Option.fold (WriteNested2PartySubIDType dest) nextFreeIdx xx.Nested2PartySubIDType
    nextFreeIdx


// group
let WriteNoNested2PartyIDsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoNested2PartyIDsGrp) =
    let nextFreeIdx = WriteNested2PartyID dest nextFreeIdx xx.Nested2PartyID
    let nextFreeIdx = Option.fold (WriteNested2PartyIDSource dest) nextFreeIdx xx.Nested2PartyIDSource
    let nextFreeIdx = Option.fold (WriteNested2PartyRole dest) nextFreeIdx xx.Nested2PartyRole
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNested2PartySubIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNested2PartySubIDs dest innerNextFreeIdx (Fix44.Fields.NoNested2PartySubIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNested2PartySubIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNested2PartySubIDsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteTradeCaptureReportAckNoAllocsGrp (dest:byte []) (nextFreeIdx:int) (xx:TradeCaptureReportAckNoAllocsGrp) =
    let nextFreeIdx = WriteAllocAccount dest nextFreeIdx xx.AllocAccount
    let nextFreeIdx = Option.fold (WriteAllocAcctIDSource dest) nextFreeIdx xx.AllocAcctIDSource
    let nextFreeIdx = Option.fold (WriteAllocSettlCurrency dest) nextFreeIdx xx.AllocSettlCurrency
    let nextFreeIdx = Option.fold (WriteIndividualAllocID dest) nextFreeIdx xx.IndividualAllocID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNested2PartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNested2PartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNested2PartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNested2PartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNested2PartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteAllocQty dest) nextFreeIdx xx.AllocQty
    nextFreeIdx


// group
let WriteNoLegSecurityAltIDGrp (dest:byte []) (nextFreeIdx:int) (xx:NoLegSecurityAltIDGrp) =
    let nextFreeIdx = WriteLegSecurityAltID dest nextFreeIdx xx.LegSecurityAltID
    let nextFreeIdx = Option.fold (WriteLegSecurityAltIDSource dest) nextFreeIdx xx.LegSecurityAltIDSource
    nextFreeIdx


// component
let WriteInstrumentLegFG (dest:byte []) (nextFreeIdx:int) (xx:InstrumentLegFG) =
    let nextFreeIdx = WriteLegSymbol dest nextFreeIdx xx.LegSymbol
    let nextFreeIdx = Option.fold (WriteLegSymbolSfx dest) nextFreeIdx xx.LegSymbolSfx
    let nextFreeIdx = Option.fold (WriteLegSecurityID dest) nextFreeIdx xx.LegSecurityID
    let nextFreeIdx = Option.fold (WriteLegSecurityIDSource dest) nextFreeIdx xx.LegSecurityIDSource
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegSecurityAltIDGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegSecurityAltID dest innerNextFreeIdx (Fix44.Fields.NoLegSecurityAltID numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegSecurityAltIDGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegSecurityAltIDGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegProduct dest) nextFreeIdx xx.LegProduct
    let nextFreeIdx = Option.fold (WriteLegCFICode dest) nextFreeIdx xx.LegCFICode
    let nextFreeIdx = Option.fold (WriteLegSecurityType dest) nextFreeIdx xx.LegSecurityType
    let nextFreeIdx = Option.fold (WriteLegSecuritySubType dest) nextFreeIdx xx.LegSecuritySubType
    let nextFreeIdx = Option.fold (WriteLegMaturityMonthYear dest) nextFreeIdx xx.LegMaturityMonthYear
    let nextFreeIdx = Option.fold (WriteLegMaturityDate dest) nextFreeIdx xx.LegMaturityDate
    let nextFreeIdx = Option.fold (WriteLegCouponPaymentDate dest) nextFreeIdx xx.LegCouponPaymentDate
    let nextFreeIdx = Option.fold (WriteLegIssueDate dest) nextFreeIdx xx.LegIssueDate
    let nextFreeIdx = Option.fold (WriteLegRepoCollateralSecurityType dest) nextFreeIdx xx.LegRepoCollateralSecurityType
    let nextFreeIdx = Option.fold (WriteLegRepurchaseTerm dest) nextFreeIdx xx.LegRepurchaseTerm
    let nextFreeIdx = Option.fold (WriteLegRepurchaseRate dest) nextFreeIdx xx.LegRepurchaseRate
    let nextFreeIdx = Option.fold (WriteLegFactor dest) nextFreeIdx xx.LegFactor
    let nextFreeIdx = Option.fold (WriteLegCreditRating dest) nextFreeIdx xx.LegCreditRating
    let nextFreeIdx = Option.fold (WriteLegInstrRegistry dest) nextFreeIdx xx.LegInstrRegistry
    let nextFreeIdx = Option.fold (WriteLegCountryOfIssue dest) nextFreeIdx xx.LegCountryOfIssue
    let nextFreeIdx = Option.fold (WriteLegStateOrProvinceOfIssue dest) nextFreeIdx xx.LegStateOrProvinceOfIssue
    let nextFreeIdx = Option.fold (WriteLegLocaleOfIssue dest) nextFreeIdx xx.LegLocaleOfIssue
    let nextFreeIdx = Option.fold (WriteLegRedemptionDate dest) nextFreeIdx xx.LegRedemptionDate
    let nextFreeIdx = Option.fold (WriteLegStrikePrice dest) nextFreeIdx xx.LegStrikePrice
    let nextFreeIdx = Option.fold (WriteLegStrikeCurrency dest) nextFreeIdx xx.LegStrikeCurrency
    let nextFreeIdx = Option.fold (WriteLegOptAttribute dest) nextFreeIdx xx.LegOptAttribute
    let nextFreeIdx = Option.fold (WriteLegContractMultiplier dest) nextFreeIdx xx.LegContractMultiplier
    let nextFreeIdx = Option.fold (WriteLegCouponRate dest) nextFreeIdx xx.LegCouponRate
    let nextFreeIdx = Option.fold (WriteLegSecurityExchange dest) nextFreeIdx xx.LegSecurityExchange
    let nextFreeIdx = Option.fold (WriteLegIssuer dest) nextFreeIdx xx.LegIssuer
    let nextFreeIdx = Option.fold (WriteEncodedLegIssuer dest) nextFreeIdx xx.EncodedLegIssuer
    let nextFreeIdx = Option.fold (WriteLegSecurityDesc dest) nextFreeIdx xx.LegSecurityDesc
    let nextFreeIdx = Option.fold (WriteEncodedLegSecurityDesc dest) nextFreeIdx xx.EncodedLegSecurityDesc
    let nextFreeIdx = Option.fold (WriteLegRatioQty dest) nextFreeIdx xx.LegRatioQty
    let nextFreeIdx = Option.fold (WriteLegSide dest) nextFreeIdx xx.LegSide
    let nextFreeIdx = Option.fold (WriteLegCurrency dest) nextFreeIdx xx.LegCurrency
    let nextFreeIdx = Option.fold (WriteLegPool dest) nextFreeIdx xx.LegPool
    let nextFreeIdx = Option.fold (WriteLegDatedDate dest) nextFreeIdx xx.LegDatedDate
    let nextFreeIdx = Option.fold (WriteLegContractSettlMonth dest) nextFreeIdx xx.LegContractSettlMonth
    let nextFreeIdx = Option.fold (WriteLegInterestAccrualDate dest) nextFreeIdx xx.LegInterestAccrualDate
    nextFreeIdx


// group
let WriteNoLegStipulationsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoLegStipulationsGrp) =
    let nextFreeIdx = WriteLegStipulationType dest nextFreeIdx xx.LegStipulationType
    let nextFreeIdx = Option.fold (WriteLegStipulationValue dest) nextFreeIdx xx.LegStipulationValue
    nextFreeIdx


// group
let WriteTradeCaptureReportAckNoLegsGrp (dest:byte []) (nextFreeIdx:int) (xx:TradeCaptureReportAckNoLegsGrp) =
    let nextFreeIdx = WriteInstrumentLegFG dest nextFreeIdx xx.InstrumentLegFG   // component
    let nextFreeIdx = Option.fold (WriteLegQty dest) nextFreeIdx xx.LegQty
    let nextFreeIdx = Option.fold (WriteLegSwapType dest) nextFreeIdx xx.LegSwapType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegStipulations dest innerNextFreeIdx (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegStipulationsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegPositionEffect dest) nextFreeIdx xx.LegPositionEffect
    let nextFreeIdx = Option.fold (WriteLegCoveredOrUncovered dest) nextFreeIdx xx.LegCoveredOrUncovered
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegRefID dest) nextFreeIdx xx.LegRefID
    let nextFreeIdx = Option.fold (WriteLegPrice dest) nextFreeIdx xx.LegPrice
    let nextFreeIdx = Option.fold (WriteLegSettlType dest) nextFreeIdx xx.LegSettlType
    let nextFreeIdx = Option.fold (WriteLegSettlDate dest) nextFreeIdx xx.LegSettlDate
    let nextFreeIdx = Option.fold (WriteLegLastPx dest) nextFreeIdx xx.LegLastPx
    nextFreeIdx


// group
let WriteNoPartySubIDsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoPartySubIDsGrp) =
    let nextFreeIdx = WritePartySubID dest nextFreeIdx xx.PartySubID
    let nextFreeIdx = Option.fold (WritePartySubIDType dest) nextFreeIdx xx.PartySubIDType
    nextFreeIdx


// group
let WriteNoPartyIDsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoPartyIDsGrp) =
    let nextFreeIdx = WritePartyID dest nextFreeIdx xx.PartyID
    let nextFreeIdx = Option.fold (WritePartyIDSource dest) nextFreeIdx xx.PartyIDSource
    let nextFreeIdx = Option.fold (WritePartyRole dest) nextFreeIdx xx.PartyRole
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoPartySubIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoPartySubIDs dest innerNextFreeIdx (Fix44.Fields.NoPartySubIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoPartySubIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoPartySubIDsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteNoClearingInstructionsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoClearingInstructionsGrp) =
    let nextFreeIdx = WriteClearingInstruction dest nextFreeIdx xx.ClearingInstruction
    nextFreeIdx


// component
let WriteCommissionData (dest:byte []) (nextFreeIdx:int) (xx:CommissionData) =
    let nextFreeIdx = Option.fold (WriteCommission dest) nextFreeIdx xx.Commission
    let nextFreeIdx = Option.fold (WriteCommType dest) nextFreeIdx xx.CommType
    let nextFreeIdx = Option.fold (WriteCommCurrency dest) nextFreeIdx xx.CommCurrency
    let nextFreeIdx = Option.fold (WriteFundRenewWaiv dest) nextFreeIdx xx.FundRenewWaiv
    nextFreeIdx


// group
let WriteNoContAmtsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoContAmtsGrp) =
    let nextFreeIdx = WriteContAmtType dest nextFreeIdx xx.ContAmtType
    let nextFreeIdx = Option.fold (WriteContAmtValue dest) nextFreeIdx xx.ContAmtValue
    let nextFreeIdx = Option.fold (WriteContAmtCurr dest) nextFreeIdx xx.ContAmtCurr
    nextFreeIdx


// group
let WriteNoStipulationsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoStipulationsGrp) =
    let nextFreeIdx = WriteStipulationType dest nextFreeIdx xx.StipulationType
    let nextFreeIdx = Option.fold (WriteStipulationValue dest) nextFreeIdx xx.StipulationValue
    nextFreeIdx


// group
let WriteNoMiscFeesGrp (dest:byte []) (nextFreeIdx:int) (xx:NoMiscFeesGrp) =
    let nextFreeIdx = WriteMiscFeeAmt dest nextFreeIdx xx.MiscFeeAmt
    let nextFreeIdx = Option.fold (WriteMiscFeeCurr dest) nextFreeIdx xx.MiscFeeCurr
    let nextFreeIdx = Option.fold (WriteMiscFeeType dest) nextFreeIdx xx.MiscFeeType
    let nextFreeIdx = Option.fold (WriteMiscFeeBasis dest) nextFreeIdx xx.MiscFeeBasis
    nextFreeIdx


// group
let WriteTradeCaptureReportNoAllocsGrp (dest:byte []) (nextFreeIdx:int) (xx:TradeCaptureReportNoAllocsGrp) =
    let nextFreeIdx = WriteAllocAccount dest nextFreeIdx xx.AllocAccount
    let nextFreeIdx = Option.fold (WriteAllocAcctIDSource dest) nextFreeIdx xx.AllocAcctIDSource
    let nextFreeIdx = Option.fold (WriteAllocSettlCurrency dest) nextFreeIdx xx.AllocSettlCurrency
    let nextFreeIdx = Option.fold (WriteIndividualAllocID dest) nextFreeIdx xx.IndividualAllocID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNested2PartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNested2PartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNested2PartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNested2PartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNested2PartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteAllocQty dest) nextFreeIdx xx.AllocQty
    nextFreeIdx


// group
let WriteTradeCaptureReportNoSidesGrp (dest:byte []) (nextFreeIdx:int) (xx:TradeCaptureReportNoSidesGrp) =
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = WriteOrderID dest nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteSecondaryOrderID dest) nextFreeIdx xx.SecondaryOrderID
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = Option.fold (WriteListID dest) nextFreeIdx xx.ListID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteProcessCode dest) nextFreeIdx xx.ProcessCode
    let nextFreeIdx = Option.fold (WriteOddLot dest) nextFreeIdx xx.OddLot
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoClearingInstructionsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoClearingInstructions dest innerNextFreeIdx (Fix44.Fields.NoClearingInstructions numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoClearingInstructionsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoClearingInstructionsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteClearingFeeIndicator dest) nextFreeIdx xx.ClearingFeeIndicator
    let nextFreeIdx = Option.fold (WriteTradeInputSource dest) nextFreeIdx xx.TradeInputSource
    let nextFreeIdx = Option.fold (WriteTradeInputDevice dest) nextFreeIdx xx.TradeInputDevice
    let nextFreeIdx = Option.fold (WriteOrderInputDevice dest) nextFreeIdx xx.OrderInputDevice
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteComplianceID dest) nextFreeIdx xx.ComplianceID
    let nextFreeIdx = Option.fold (WriteSolicitedFlag dest) nextFreeIdx xx.SolicitedFlag
    let nextFreeIdx = Option.fold (WriteOrderCapacity dest) nextFreeIdx xx.OrderCapacity
    let nextFreeIdx = Option.fold (WriteOrderRestrictions dest) nextFreeIdx xx.OrderRestrictions
    let nextFreeIdx = Option.fold (WriteCustOrderCapacity dest) nextFreeIdx xx.CustOrderCapacity
    let nextFreeIdx = Option.fold (WriteOrdType dest) nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WriteExecInst dest) nextFreeIdx xx.ExecInst
    let nextFreeIdx = Option.fold (WriteTransBkdTime dest) nextFreeIdx xx.TransBkdTime
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteTimeBracket dest) nextFreeIdx xx.TimeBracket
    let nextFreeIdx = WriteCommissionData dest nextFreeIdx xx.CommissionData   // component
    let nextFreeIdx = Option.fold (WriteGrossTradeAmt dest) nextFreeIdx xx.GrossTradeAmt
    let nextFreeIdx = Option.fold (WriteNumDaysInterest dest) nextFreeIdx xx.NumDaysInterest
    let nextFreeIdx = Option.fold (WriteExDate dest) nextFreeIdx xx.ExDate
    let nextFreeIdx = Option.fold (WriteAccruedInterestRate dest) nextFreeIdx xx.AccruedInterestRate
    let nextFreeIdx = Option.fold (WriteAccruedInterestAmt dest) nextFreeIdx xx.AccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteInterestAtMaturity dest) nextFreeIdx xx.InterestAtMaturity
    let nextFreeIdx = Option.fold (WriteEndAccruedInterestAmt dest) nextFreeIdx xx.EndAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteStartCash dest) nextFreeIdx xx.StartCash
    let nextFreeIdx = Option.fold (WriteEndCash dest) nextFreeIdx xx.EndCash
    let nextFreeIdx = Option.fold (WriteConcession dest) nextFreeIdx xx.Concession
    let nextFreeIdx = Option.fold (WriteTotalTakedown dest) nextFreeIdx xx.TotalTakedown
    let nextFreeIdx = Option.fold (WriteNetMoney dest) nextFreeIdx xx.NetMoney
    let nextFreeIdx = Option.fold (WriteSettlCurrAmt dest) nextFreeIdx xx.SettlCurrAmt
    let nextFreeIdx = Option.fold (WriteSettlCurrency dest) nextFreeIdx xx.SettlCurrency
    let nextFreeIdx = Option.fold (WriteSettlCurrFxRate dest) nextFreeIdx xx.SettlCurrFxRate
    let nextFreeIdx = Option.fold (WriteSettlCurrFxRateCalc dest) nextFreeIdx xx.SettlCurrFxRateCalc
    let nextFreeIdx = Option.fold (WritePositionEffect dest) nextFreeIdx xx.PositionEffect
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteSideMultiLegReportingType dest) nextFreeIdx xx.SideMultiLegReportingType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoContAmtsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoContAmts dest innerNextFreeIdx (Fix44.Fields.NoContAmts numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoContAmtsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoContAmtsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoStipulations dest innerNextFreeIdx (Fix44.Fields.NoStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoStipulationsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoMiscFeesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoMiscFees dest innerNextFreeIdx (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoMiscFeesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoMiscFeesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteExchangeRule dest) nextFreeIdx xx.ExchangeRule
    let nextFreeIdx = Option.fold (WriteTradeAllocIndicator dest) nextFreeIdx xx.TradeAllocIndicator
    let nextFreeIdx = Option.fold (WritePreallocMethod dest) nextFreeIdx xx.PreallocMethod
    let nextFreeIdx = Option.fold (WriteAllocID dest) nextFreeIdx xx.AllocID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:TradeCaptureReportNoAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAllocs dest innerNextFreeIdx (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteTradeCaptureReportNoAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.TradeCaptureReportNoAllocsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteTradeCaptureReportNoLegsGrp (dest:byte []) (nextFreeIdx:int) (xx:TradeCaptureReportNoLegsGrp) =
    let nextFreeIdx = WriteInstrumentLegFG dest nextFreeIdx xx.InstrumentLegFG   // component
    let nextFreeIdx = Option.fold (WriteLegQty dest) nextFreeIdx xx.LegQty
    let nextFreeIdx = Option.fold (WriteLegSwapType dest) nextFreeIdx xx.LegSwapType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegStipulations dest innerNextFreeIdx (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegStipulationsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegPositionEffect dest) nextFreeIdx xx.LegPositionEffect
    let nextFreeIdx = Option.fold (WriteLegCoveredOrUncovered dest) nextFreeIdx xx.LegCoveredOrUncovered
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegRefID dest) nextFreeIdx xx.LegRefID
    let nextFreeIdx = Option.fold (WriteLegPrice dest) nextFreeIdx xx.LegPrice
    let nextFreeIdx = Option.fold (WriteLegSettlType dest) nextFreeIdx xx.LegSettlType
    let nextFreeIdx = Option.fold (WriteLegSettlDate dest) nextFreeIdx xx.LegSettlDate
    let nextFreeIdx = Option.fold (WriteLegLastPx dest) nextFreeIdx xx.LegLastPx
    nextFreeIdx


// group
let WriteNoPosAmtGrp (dest:byte []) (nextFreeIdx:int) (xx:NoPosAmtGrp) =
    let nextFreeIdx = WritePosAmtType dest nextFreeIdx xx.PosAmtType
    let nextFreeIdx = WritePosAmt dest nextFreeIdx xx.PosAmt
    nextFreeIdx


// component
let WritePositionAmountData (dest:byte []) (nextFreeIdx:int) (xx:PositionAmountData) =
    let numGrps = xx.NoPosAmtGrp.Length
    let nextFreeIdx = WriteNoPosAmt dest nextFreeIdx (Fix44.Fields.NoPosAmt numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.NoPosAmtGrp |> List.fold (fun accFreeIdx gg -> WriteNoPosAmtGrp dest accFreeIdx gg) nextFreeIdx
    nextFreeIdx


// group
let WriteNoSettlPartySubIDsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoSettlPartySubIDsGrp) =
    let nextFreeIdx = WriteSettlPartySubID dest nextFreeIdx xx.SettlPartySubID
    let nextFreeIdx = Option.fold (WriteSettlPartySubIDType dest) nextFreeIdx xx.SettlPartySubIDType
    nextFreeIdx


// group
let WriteNoSettlPartyIDsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoSettlPartyIDsGrp) =
    let nextFreeIdx = WriteSettlPartyID dest nextFreeIdx xx.SettlPartyID
    let nextFreeIdx = Option.fold (WriteSettlPartyIDSource dest) nextFreeIdx xx.SettlPartyIDSource
    let nextFreeIdx = Option.fold (WriteSettlPartyRole dest) nextFreeIdx xx.SettlPartyRole
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoSettlPartySubIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoSettlPartySubIDs dest innerNextFreeIdx (Fix44.Fields.NoSettlPartySubIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoSettlPartySubIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoSettlPartySubIDsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteNoDlvyInstGrp (dest:byte []) (nextFreeIdx:int) (xx:NoDlvyInstGrp) =
    let nextFreeIdx = WriteSettlInstSource dest nextFreeIdx xx.SettlInstSource
    let nextFreeIdx = Option.fold (WriteDlvyInstType dest) nextFreeIdx xx.DlvyInstType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoSettlPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoSettlPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoSettlPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoSettlPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoSettlPartyIDsGrp  // end Option.fold
    nextFreeIdx


// component
let WriteSettlInstructionsData (dest:byte []) (nextFreeIdx:int) (xx:SettlInstructionsData) =
    let nextFreeIdx = Option.fold (WriteSettlDeliveryType dest) nextFreeIdx xx.SettlDeliveryType
    let nextFreeIdx = Option.fold (WriteStandInstDbType dest) nextFreeIdx xx.StandInstDbType
    let nextFreeIdx = Option.fold (WriteStandInstDbName dest) nextFreeIdx xx.StandInstDbName
    let nextFreeIdx = Option.fold (WriteStandInstDbID dest) nextFreeIdx xx.StandInstDbID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoDlvyInstGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoDlvyInst dest innerNextFreeIdx (Fix44.Fields.NoDlvyInst numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoDlvyInstGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoDlvyInstGrp  // end Option.fold
    nextFreeIdx


// group
let WriteNoSettlInstGrp (dest:byte []) (nextFreeIdx:int) (xx:NoSettlInstGrp) =
    let nextFreeIdx = WriteSettlInstID dest nextFreeIdx xx.SettlInstID
    let nextFreeIdx = Option.fold (WriteSettlInstTransType dest) nextFreeIdx xx.SettlInstTransType
    let nextFreeIdx = Option.fold (WriteSettlInstRefID dest) nextFreeIdx xx.SettlInstRefID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteProduct dest) nextFreeIdx xx.Product
    let nextFreeIdx = Option.fold (WriteSecurityType dest) nextFreeIdx xx.SecurityType
    let nextFreeIdx = Option.fold (WriteCFICode dest) nextFreeIdx xx.CFICode
    let nextFreeIdx = Option.fold (WriteEffectiveTime dest) nextFreeIdx xx.EffectiveTime
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteLastUpdateTime dest) nextFreeIdx xx.LastUpdateTime
    let nextFreeIdx = WriteSettlInstructionsData dest nextFreeIdx xx.SettlInstructionsData   // component
    let nextFreeIdx = Option.fold (WritePaymentMethod dest) nextFreeIdx xx.PaymentMethod
    let nextFreeIdx = Option.fold (WritePaymentRef dest) nextFreeIdx xx.PaymentRef
    let nextFreeIdx = Option.fold (WriteCardHolderName dest) nextFreeIdx xx.CardHolderName
    let nextFreeIdx = Option.fold (WriteCardNumber dest) nextFreeIdx xx.CardNumber
    let nextFreeIdx = Option.fold (WriteCardStartDate dest) nextFreeIdx xx.CardStartDate
    let nextFreeIdx = Option.fold (WriteCardExpDate dest) nextFreeIdx xx.CardExpDate
    let nextFreeIdx = Option.fold (WriteCardIssNum dest) nextFreeIdx xx.CardIssNum
    let nextFreeIdx = Option.fold (WritePaymentDate dest) nextFreeIdx xx.PaymentDate
    let nextFreeIdx = Option.fold (WritePaymentRemitterID dest) nextFreeIdx xx.PaymentRemitterID
    nextFreeIdx


// group
let WriteNoTrdRegTimestampsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoTrdRegTimestampsGrp) =
    let nextFreeIdx = WriteTrdRegTimestamp dest nextFreeIdx xx.TrdRegTimestamp
    let nextFreeIdx = Option.fold (WriteTrdRegTimestampType dest) nextFreeIdx xx.TrdRegTimestampType
    let nextFreeIdx = Option.fold (WriteTrdRegTimestampOrigin dest) nextFreeIdx xx.TrdRegTimestampOrigin
    nextFreeIdx


// component
let WriteTrdRegTimestamps (dest:byte []) (nextFreeIdx:int) (xx:TrdRegTimestamps) =
    let numGrps = xx.NoTrdRegTimestampsGrp.Length
    let nextFreeIdx = WriteNoTrdRegTimestamps dest nextFreeIdx (Fix44.Fields.NoTrdRegTimestamps numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.NoTrdRegTimestampsGrp |> List.fold (fun accFreeIdx gg -> WriteNoTrdRegTimestampsGrp dest accFreeIdx gg) nextFreeIdx
    nextFreeIdx


// group
let WriteAllocationReportNoAllocsGrp (dest:byte []) (nextFreeIdx:int) (xx:AllocationReportNoAllocsGrp) =
    let nextFreeIdx = WriteAllocAccount dest nextFreeIdx xx.AllocAccount
    let nextFreeIdx = Option.fold (WriteAllocAcctIDSource dest) nextFreeIdx xx.AllocAcctIDSource
    let nextFreeIdx = Option.fold (WriteMatchStatus dest) nextFreeIdx xx.MatchStatus
    let nextFreeIdx = Option.fold (WriteAllocPrice dest) nextFreeIdx xx.AllocPrice
    let nextFreeIdx = WriteAllocQty dest nextFreeIdx xx.AllocQty
    let nextFreeIdx = Option.fold (WriteIndividualAllocID dest) nextFreeIdx xx.IndividualAllocID
    let nextFreeIdx = Option.fold (WriteProcessCode dest) nextFreeIdx xx.ProcessCode
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteNotifyBrokerOfCredit dest) nextFreeIdx xx.NotifyBrokerOfCredit
    let nextFreeIdx = Option.fold (WriteAllocHandlInst dest) nextFreeIdx xx.AllocHandlInst
    let nextFreeIdx = Option.fold (WriteAllocText dest) nextFreeIdx xx.AllocText
    let nextFreeIdx = Option.fold (WriteEncodedAllocText dest) nextFreeIdx xx.EncodedAllocText
    let nextFreeIdx = WriteCommissionData dest nextFreeIdx xx.CommissionData   // component
    let nextFreeIdx = Option.fold (WriteAllocAvgPx dest) nextFreeIdx xx.AllocAvgPx
    let nextFreeIdx = Option.fold (WriteAllocNetMoney dest) nextFreeIdx xx.AllocNetMoney
    let nextFreeIdx = Option.fold (WriteSettlCurrAmt dest) nextFreeIdx xx.SettlCurrAmt
    let nextFreeIdx = Option.fold (WriteAllocSettlCurrAmt dest) nextFreeIdx xx.AllocSettlCurrAmt
    let nextFreeIdx = Option.fold (WriteSettlCurrency dest) nextFreeIdx xx.SettlCurrency
    let nextFreeIdx = Option.fold (WriteAllocSettlCurrency dest) nextFreeIdx xx.AllocSettlCurrency
    let nextFreeIdx = Option.fold (WriteSettlCurrFxRate dest) nextFreeIdx xx.SettlCurrFxRate
    let nextFreeIdx = Option.fold (WriteSettlCurrFxRateCalc dest) nextFreeIdx xx.SettlCurrFxRateCalc
    let nextFreeIdx = Option.fold (WriteAllocAccruedInterestAmt dest) nextFreeIdx xx.AllocAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteAllocInterestAtMaturity dest) nextFreeIdx xx.AllocInterestAtMaturity
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoMiscFeesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoMiscFees dest innerNextFreeIdx (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoMiscFeesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoMiscFeesGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoClearingInstructionsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoClearingInstructions dest innerNextFreeIdx (Fix44.Fields.NoClearingInstructions numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoClearingInstructionsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoClearingInstructionsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteClearingFeeIndicator dest) nextFreeIdx xx.ClearingFeeIndicator
    let nextFreeIdx = Option.fold (WriteAllocSettlInstType dest) nextFreeIdx xx.AllocSettlInstType
    let nextFreeIdx = WriteSettlInstructionsData dest nextFreeIdx xx.SettlInstructionsData   // component
    nextFreeIdx


// group
let WriteAllocationInstructionNoAllocsGrp (dest:byte []) (nextFreeIdx:int) (xx:AllocationInstructionNoAllocsGrp) =
    let nextFreeIdx = WriteAllocAccount dest nextFreeIdx xx.AllocAccount
    let nextFreeIdx = Option.fold (WriteAllocAcctIDSource dest) nextFreeIdx xx.AllocAcctIDSource
    let nextFreeIdx = Option.fold (WriteMatchStatus dest) nextFreeIdx xx.MatchStatus
    let nextFreeIdx = Option.fold (WriteAllocPrice dest) nextFreeIdx xx.AllocPrice
    let nextFreeIdx = Option.fold (WriteAllocQty dest) nextFreeIdx xx.AllocQty
    let nextFreeIdx = Option.fold (WriteIndividualAllocID dest) nextFreeIdx xx.IndividualAllocID
    let nextFreeIdx = Option.fold (WriteProcessCode dest) nextFreeIdx xx.ProcessCode
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteNotifyBrokerOfCredit dest) nextFreeIdx xx.NotifyBrokerOfCredit
    let nextFreeIdx = Option.fold (WriteAllocHandlInst dest) nextFreeIdx xx.AllocHandlInst
    let nextFreeIdx = Option.fold (WriteAllocText dest) nextFreeIdx xx.AllocText
    let nextFreeIdx = Option.fold (WriteEncodedAllocText dest) nextFreeIdx xx.EncodedAllocText
    let nextFreeIdx = WriteCommissionData dest nextFreeIdx xx.CommissionData   // component
    let nextFreeIdx = Option.fold (WriteAllocAvgPx dest) nextFreeIdx xx.AllocAvgPx
    let nextFreeIdx = Option.fold (WriteAllocNetMoney dest) nextFreeIdx xx.AllocNetMoney
    let nextFreeIdx = Option.fold (WriteSettlCurrAmt dest) nextFreeIdx xx.SettlCurrAmt
    let nextFreeIdx = Option.fold (WriteAllocSettlCurrAmt dest) nextFreeIdx xx.AllocSettlCurrAmt
    let nextFreeIdx = Option.fold (WriteSettlCurrency dest) nextFreeIdx xx.SettlCurrency
    let nextFreeIdx = Option.fold (WriteAllocSettlCurrency dest) nextFreeIdx xx.AllocSettlCurrency
    let nextFreeIdx = Option.fold (WriteSettlCurrFxRate dest) nextFreeIdx xx.SettlCurrFxRate
    let nextFreeIdx = Option.fold (WriteSettlCurrFxRateCalc dest) nextFreeIdx xx.SettlCurrFxRateCalc
    let nextFreeIdx = Option.fold (WriteAccruedInterestAmt dest) nextFreeIdx xx.AccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteAllocAccruedInterestAmt dest) nextFreeIdx xx.AllocAccruedInterestAmt
    let nextFreeIdx = Option.fold (WriteAllocInterestAtMaturity dest) nextFreeIdx xx.AllocInterestAtMaturity
    let nextFreeIdx = Option.fold (WriteSettlInstMode dest) nextFreeIdx xx.SettlInstMode
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoMiscFeesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoMiscFees dest innerNextFreeIdx (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoMiscFeesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoMiscFeesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteNoClearingInstructions dest) nextFreeIdx xx.NoClearingInstructions
    let nextFreeIdx = Option.fold (WriteClearingInstruction dest) nextFreeIdx xx.ClearingInstruction
    let nextFreeIdx = Option.fold (WriteClearingFeeIndicator dest) nextFreeIdx xx.ClearingFeeIndicator
    let nextFreeIdx = Option.fold (WriteAllocSettlInstType dest) nextFreeIdx xx.AllocSettlInstType
    let nextFreeIdx = WriteSettlInstructionsData dest nextFreeIdx xx.SettlInstructionsData   // component
    nextFreeIdx


// component
let WriteSettlParties (dest:byte []) (nextFreeIdx:int) (xx:SettlParties) =
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoSettlPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoSettlPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoSettlPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoSettlPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoSettlPartyIDsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteNoOrdersGrp (dest:byte []) (nextFreeIdx:int) (xx:NoOrdersGrp) =
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteSecondaryOrderID dest) nextFreeIdx xx.SecondaryOrderID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = Option.fold (WriteListID dest) nextFreeIdx xx.ListID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNested2PartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNested2PartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNested2PartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNested2PartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNested2PartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteOrderQty dest) nextFreeIdx xx.OrderQty
    let nextFreeIdx = Option.fold (WriteOrderAvgPx dest) nextFreeIdx xx.OrderAvgPx
    let nextFreeIdx = Option.fold (WriteOrderBookingQty dest) nextFreeIdx xx.OrderBookingQty
    nextFreeIdx


// group
let WriteListStrikePriceNoUnderlyingsGrp (dest:byte []) (nextFreeIdx:int) (xx:ListStrikePriceNoUnderlyingsGrp) =
    let nextFreeIdx = WriteUnderlyingInstrument dest nextFreeIdx xx.UnderlyingInstrument   // component
    let nextFreeIdx = Option.fold (WritePrevClosePx dest) nextFreeIdx xx.PrevClosePx
    let nextFreeIdx = Option.fold (WriteClOrdID dest) nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = WritePrice dest nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// group
let WriteNoSecurityAltIDGrp (dest:byte []) (nextFreeIdx:int) (xx:NoSecurityAltIDGrp) =
    let nextFreeIdx = WriteSecurityAltID dest nextFreeIdx xx.SecurityAltID
    let nextFreeIdx = Option.fold (WriteSecurityAltIDSource dest) nextFreeIdx xx.SecurityAltIDSource
    nextFreeIdx


// group
let WriteNoEventsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoEventsGrp) =
    let nextFreeIdx = WriteEventType dest nextFreeIdx xx.EventType
    let nextFreeIdx = Option.fold (WriteEventDate dest) nextFreeIdx xx.EventDate
    let nextFreeIdx = Option.fold (WriteEventPx dest) nextFreeIdx xx.EventPx
    let nextFreeIdx = Option.fold (WriteEventText dest) nextFreeIdx xx.EventText
    nextFreeIdx


// component
let WriteInstrument (dest:byte []) (nextFreeIdx:int) (xx:Instrument) =
    let nextFreeIdx = WriteSymbol dest nextFreeIdx xx.Symbol
    let nextFreeIdx = Option.fold (WriteSymbolSfx dest) nextFreeIdx xx.SymbolSfx
    let nextFreeIdx = Option.fold (WriteSecurityID dest) nextFreeIdx xx.SecurityID
    let nextFreeIdx = Option.fold (WriteSecurityIDSource dest) nextFreeIdx xx.SecurityIDSource
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoSecurityAltIDGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoSecurityAltID dest innerNextFreeIdx (Fix44.Fields.NoSecurityAltID numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoSecurityAltIDGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoSecurityAltIDGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteProduct dest) nextFreeIdx xx.Product
    let nextFreeIdx = Option.fold (WriteCFICode dest) nextFreeIdx xx.CFICode
    let nextFreeIdx = Option.fold (WriteSecurityType dest) nextFreeIdx xx.SecurityType
    let nextFreeIdx = Option.fold (WriteSecuritySubType dest) nextFreeIdx xx.SecuritySubType
    let nextFreeIdx = Option.fold (WriteMaturityMonthYear dest) nextFreeIdx xx.MaturityMonthYear
    let nextFreeIdx = Option.fold (WriteMaturityDate dest) nextFreeIdx xx.MaturityDate
    let nextFreeIdx = Option.fold (WritePutOrCall dest) nextFreeIdx xx.PutOrCall
    let nextFreeIdx = Option.fold (WriteCouponPaymentDate dest) nextFreeIdx xx.CouponPaymentDate
    let nextFreeIdx = Option.fold (WriteIssueDate dest) nextFreeIdx xx.IssueDate
    let nextFreeIdx = Option.fold (WriteRepoCollateralSecurityType dest) nextFreeIdx xx.RepoCollateralSecurityType
    let nextFreeIdx = Option.fold (WriteRepurchaseTerm dest) nextFreeIdx xx.RepurchaseTerm
    let nextFreeIdx = Option.fold (WriteRepurchaseRate dest) nextFreeIdx xx.RepurchaseRate
    let nextFreeIdx = Option.fold (WriteFactor dest) nextFreeIdx xx.Factor
    let nextFreeIdx = Option.fold (WriteCreditRating dest) nextFreeIdx xx.CreditRating
    let nextFreeIdx = Option.fold (WriteInstrRegistry dest) nextFreeIdx xx.InstrRegistry
    let nextFreeIdx = Option.fold (WriteCountryOfIssue dest) nextFreeIdx xx.CountryOfIssue
    let nextFreeIdx = Option.fold (WriteStateOrProvinceOfIssue dest) nextFreeIdx xx.StateOrProvinceOfIssue
    let nextFreeIdx = Option.fold (WriteLocaleOfIssue dest) nextFreeIdx xx.LocaleOfIssue
    let nextFreeIdx = Option.fold (WriteRedemptionDate dest) nextFreeIdx xx.RedemptionDate
    let nextFreeIdx = Option.fold (WriteStrikePrice dest) nextFreeIdx xx.StrikePrice
    let nextFreeIdx = Option.fold (WriteStrikeCurrency dest) nextFreeIdx xx.StrikeCurrency
    let nextFreeIdx = Option.fold (WriteOptAttribute dest) nextFreeIdx xx.OptAttribute
    let nextFreeIdx = Option.fold (WriteContractMultiplier dest) nextFreeIdx xx.ContractMultiplier
    let nextFreeIdx = Option.fold (WriteCouponRate dest) nextFreeIdx xx.CouponRate
    let nextFreeIdx = Option.fold (WriteSecurityExchange dest) nextFreeIdx xx.SecurityExchange
    let nextFreeIdx = Option.fold (WriteIssuer dest) nextFreeIdx xx.Issuer
    let nextFreeIdx = Option.fold (WriteEncodedIssuer dest) nextFreeIdx xx.EncodedIssuer
    let nextFreeIdx = Option.fold (WriteSecurityDesc dest) nextFreeIdx xx.SecurityDesc
    let nextFreeIdx = Option.fold (WriteEncodedSecurityDesc dest) nextFreeIdx xx.EncodedSecurityDesc
    let nextFreeIdx = Option.fold (WritePool dest) nextFreeIdx xx.Pool
    let nextFreeIdx = Option.fold (WriteContractSettlMonth dest) nextFreeIdx xx.ContractSettlMonth
    let nextFreeIdx = Option.fold (WriteCPProgram dest) nextFreeIdx xx.CPProgram
    let nextFreeIdx = Option.fold (WriteCPRegType dest) nextFreeIdx xx.CPRegType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoEventsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoEvents dest innerNextFreeIdx (Fix44.Fields.NoEvents numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoEventsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoEventsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteDatedDate dest) nextFreeIdx xx.DatedDate
    let nextFreeIdx = Option.fold (WriteInterestAccrualDate dest) nextFreeIdx xx.InterestAccrualDate
    nextFreeIdx


// group
let WriteNoStrikesGrp (dest:byte []) (nextFreeIdx:int) (xx:NoStrikesGrp) =
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    nextFreeIdx


// group
let WriteNoAllocsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoAllocsGrp) =
    let nextFreeIdx = WriteAllocAccount dest nextFreeIdx xx.AllocAccount
    let nextFreeIdx = Option.fold (WriteAllocAcctIDSource dest) nextFreeIdx xx.AllocAcctIDSource
    let nextFreeIdx = Option.fold (WriteAllocSettlCurrency dest) nextFreeIdx xx.AllocSettlCurrency
    let nextFreeIdx = Option.fold (WriteIndividualAllocID dest) nextFreeIdx xx.IndividualAllocID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteAllocQty dest) nextFreeIdx xx.AllocQty
    nextFreeIdx


// group
let WriteNoTradingSessionsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoTradingSessionsGrp) =
    let nextFreeIdx = WriteTradingSessionID dest nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    nextFreeIdx


// group
let WriteNoUnderlyingsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoUnderlyingsGrp) =
    let nextFreeIdx = WriteUnderlyingInstrument dest nextFreeIdx xx.UnderlyingInstrument   // component
    nextFreeIdx


// component
let WriteOrderQtyData (dest:byte []) (nextFreeIdx:int) (xx:OrderQtyData) =
    let nextFreeIdx = Option.fold (WriteOrderQty dest) nextFreeIdx xx.OrderQty
    let nextFreeIdx = Option.fold (WriteCashOrderQty dest) nextFreeIdx xx.CashOrderQty
    let nextFreeIdx = Option.fold (WriteOrderPercent dest) nextFreeIdx xx.OrderPercent
    let nextFreeIdx = Option.fold (WriteRoundingDirection dest) nextFreeIdx xx.RoundingDirection
    let nextFreeIdx = Option.fold (WriteRoundingModulus dest) nextFreeIdx xx.RoundingModulus
    nextFreeIdx


// component
let WriteSpreadOrBenchmarkCurveData (dest:byte []) (nextFreeIdx:int) (xx:SpreadOrBenchmarkCurveData) =
    let nextFreeIdx = Option.fold (WriteSpread dest) nextFreeIdx xx.Spread
    let nextFreeIdx = Option.fold (WriteBenchmarkCurveCurrency dest) nextFreeIdx xx.BenchmarkCurveCurrency
    let nextFreeIdx = Option.fold (WriteBenchmarkCurveName dest) nextFreeIdx xx.BenchmarkCurveName
    let nextFreeIdx = Option.fold (WriteBenchmarkCurvePoint dest) nextFreeIdx xx.BenchmarkCurvePoint
    let nextFreeIdx = Option.fold (WriteBenchmarkPrice dest) nextFreeIdx xx.BenchmarkPrice
    let nextFreeIdx = Option.fold (WriteBenchmarkPriceType dest) nextFreeIdx xx.BenchmarkPriceType
    let nextFreeIdx = Option.fold (WriteBenchmarkSecurityID dest) nextFreeIdx xx.BenchmarkSecurityID
    let nextFreeIdx = Option.fold (WriteBenchmarkSecurityIDSource dest) nextFreeIdx xx.BenchmarkSecurityIDSource
    nextFreeIdx


// component
let WriteYieldData (dest:byte []) (nextFreeIdx:int) (xx:YieldData) =
    let nextFreeIdx = Option.fold (WriteYieldType dest) nextFreeIdx xx.YieldType
    let nextFreeIdx = Option.fold (WriteYield dest) nextFreeIdx xx.Yield
    let nextFreeIdx = Option.fold (WriteYieldCalcDate dest) nextFreeIdx xx.YieldCalcDate
    let nextFreeIdx = Option.fold (WriteYieldRedemptionDate dest) nextFreeIdx xx.YieldRedemptionDate
    let nextFreeIdx = Option.fold (WriteYieldRedemptionPrice dest) nextFreeIdx xx.YieldRedemptionPrice
    let nextFreeIdx = Option.fold (WriteYieldRedemptionPriceType dest) nextFreeIdx xx.YieldRedemptionPriceType
    nextFreeIdx


// component
let WritePegInstructions (dest:byte []) (nextFreeIdx:int) (xx:PegInstructions) =
    let nextFreeIdx = Option.fold (WritePegOffsetValue dest) nextFreeIdx xx.PegOffsetValue
    let nextFreeIdx = Option.fold (WritePegMoveType dest) nextFreeIdx xx.PegMoveType
    let nextFreeIdx = Option.fold (WritePegOffsetType dest) nextFreeIdx xx.PegOffsetType
    let nextFreeIdx = Option.fold (WritePegLimitType dest) nextFreeIdx xx.PegLimitType
    let nextFreeIdx = Option.fold (WritePegRoundDirection dest) nextFreeIdx xx.PegRoundDirection
    let nextFreeIdx = Option.fold (WritePegScope dest) nextFreeIdx xx.PegScope
    nextFreeIdx


// component
let WriteDiscretionInstructions (dest:byte []) (nextFreeIdx:int) (xx:DiscretionInstructions) =
    let nextFreeIdx = Option.fold (WriteDiscretionInst dest) nextFreeIdx xx.DiscretionInst
    let nextFreeIdx = Option.fold (WriteDiscretionOffsetValue dest) nextFreeIdx xx.DiscretionOffsetValue
    let nextFreeIdx = Option.fold (WriteDiscretionMoveType dest) nextFreeIdx xx.DiscretionMoveType
    let nextFreeIdx = Option.fold (WriteDiscretionOffsetType dest) nextFreeIdx xx.DiscretionOffsetType
    let nextFreeIdx = Option.fold (WriteDiscretionLimitType dest) nextFreeIdx xx.DiscretionLimitType
    let nextFreeIdx = Option.fold (WriteDiscretionRoundDirection dest) nextFreeIdx xx.DiscretionRoundDirection
    let nextFreeIdx = Option.fold (WriteDiscretionScope dest) nextFreeIdx xx.DiscretionScope
    nextFreeIdx


// group
let WriteNewOrderListNoOrdersGrp (dest:byte []) (nextFreeIdx:int) (xx:NewOrderListNoOrdersGrp) =
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = WriteListSeqNo dest nextFreeIdx xx.ListSeqNo
    let nextFreeIdx = Option.fold (WriteClOrdLinkID dest) nextFreeIdx xx.ClOrdLinkID
    let nextFreeIdx = Option.fold (WriteSettlInstMode dest) nextFreeIdx xx.SettlInstMode
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteDayBookingInst dest) nextFreeIdx xx.DayBookingInst
    let nextFreeIdx = Option.fold (WriteBookingUnit dest) nextFreeIdx xx.BookingUnit
    let nextFreeIdx = Option.fold (WriteAllocID dest) nextFreeIdx xx.AllocID
    let nextFreeIdx = Option.fold (WritePreallocMethod dest) nextFreeIdx xx.PreallocMethod
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAllocs dest innerNextFreeIdx (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoAllocsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteCashMargin dest) nextFreeIdx xx.CashMargin
    let nextFreeIdx = Option.fold (WriteClearingFeeIndicator dest) nextFreeIdx xx.ClearingFeeIndicator
    let nextFreeIdx = Option.fold (WriteHandlInst dest) nextFreeIdx xx.HandlInst
    let nextFreeIdx = Option.fold (WriteExecInst dest) nextFreeIdx xx.ExecInst
    let nextFreeIdx = Option.fold (WriteMinQty dest) nextFreeIdx xx.MinQty
    let nextFreeIdx = Option.fold (WriteMaxFloor dest) nextFreeIdx xx.MaxFloor
    let nextFreeIdx = Option.fold (WriteExDestination dest) nextFreeIdx xx.ExDestination
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoTradingSessionsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoTradingSessions dest innerNextFreeIdx (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoTradingSessionsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoTradingSessionsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteProcessCode dest) nextFreeIdx xx.ProcessCode
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePrevClosePx dest) nextFreeIdx xx.PrevClosePx
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteSideValueInd dest) nextFreeIdx xx.SideValueInd
    let nextFreeIdx = Option.fold (WriteLocateReqd dest) nextFreeIdx xx.LocateReqd
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoStipulations dest innerNextFreeIdx (Fix44.Fields.NoStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoStipulationsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = WriteOrderQtyData dest nextFreeIdx xx.OrderQtyData   // component
    let nextFreeIdx = Option.fold (WriteOrdType dest) nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WriteStopPx dest) nextFreeIdx xx.StopPx
    let nextFreeIdx = WriteSpreadOrBenchmarkCurveData dest nextFreeIdx xx.SpreadOrBenchmarkCurveData   // component
    let nextFreeIdx = WriteYieldData dest nextFreeIdx xx.YieldData   // component
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteComplianceID dest) nextFreeIdx xx.ComplianceID
    let nextFreeIdx = Option.fold (WriteSolicitedFlag dest) nextFreeIdx xx.SolicitedFlag
    let nextFreeIdx = Option.fold (WriteIOIid dest) nextFreeIdx xx.IOIid
    let nextFreeIdx = Option.fold (WriteQuoteID dest) nextFreeIdx xx.QuoteID
    let nextFreeIdx = Option.fold (WriteTimeInForce dest) nextFreeIdx xx.TimeInForce
    let nextFreeIdx = Option.fold (WriteEffectiveTime dest) nextFreeIdx xx.EffectiveTime
    let nextFreeIdx = Option.fold (WriteExpireDate dest) nextFreeIdx xx.ExpireDate
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteGTBookingInst dest) nextFreeIdx xx.GTBookingInst
    let nextFreeIdx = WriteCommissionData dest nextFreeIdx xx.CommissionData   // component
    let nextFreeIdx = Option.fold (WriteOrderCapacity dest) nextFreeIdx xx.OrderCapacity
    let nextFreeIdx = Option.fold (WriteOrderRestrictions dest) nextFreeIdx xx.OrderRestrictions
    let nextFreeIdx = Option.fold (WriteCustOrderCapacity dest) nextFreeIdx xx.CustOrderCapacity
    let nextFreeIdx = Option.fold (WriteForexReq dest) nextFreeIdx xx.ForexReq
    let nextFreeIdx = Option.fold (WriteSettlCurrency dest) nextFreeIdx xx.SettlCurrency
    let nextFreeIdx = Option.fold (WriteBookingType dest) nextFreeIdx xx.BookingType
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WriteSettlDate2 dest) nextFreeIdx xx.SettlDate2
    let nextFreeIdx = Option.fold (WriteOrderQty2 dest) nextFreeIdx xx.OrderQty2
    let nextFreeIdx = Option.fold (WritePrice2 dest) nextFreeIdx xx.Price2
    let nextFreeIdx = Option.fold (WritePositionEffect dest) nextFreeIdx xx.PositionEffect
    let nextFreeIdx = Option.fold (WriteCoveredOrUncovered dest) nextFreeIdx xx.CoveredOrUncovered
    let nextFreeIdx = Option.fold (WriteMaxShow dest) nextFreeIdx xx.MaxShow
    let nextFreeIdx = WritePegInstructions dest nextFreeIdx xx.PegInstructions   // component
    let nextFreeIdx = WriteDiscretionInstructions dest nextFreeIdx xx.DiscretionInstructions   // component
    let nextFreeIdx = Option.fold (WriteTargetStrategy dest) nextFreeIdx xx.TargetStrategy
    let nextFreeIdx = Option.fold (WriteTargetStrategyParameters dest) nextFreeIdx xx.TargetStrategyParameters
    let nextFreeIdx = Option.fold (WriteParticipationRate dest) nextFreeIdx xx.ParticipationRate
    let nextFreeIdx = Option.fold (WriteDesignation dest) nextFreeIdx xx.Designation
    nextFreeIdx


// component
let WriteCommissionDataFG (dest:byte []) (nextFreeIdx:int) (xx:CommissionDataFG) =
    let nextFreeIdx = WriteCommission dest nextFreeIdx xx.Commission
    let nextFreeIdx = Option.fold (WriteCommType dest) nextFreeIdx xx.CommType
    let nextFreeIdx = Option.fold (WriteCommCurrency dest) nextFreeIdx xx.CommCurrency
    let nextFreeIdx = Option.fold (WriteFundRenewWaiv dest) nextFreeIdx xx.FundRenewWaiv
    nextFreeIdx


// group
let WriteBidResponseNoBidComponentsGrp (dest:byte []) (nextFreeIdx:int) (xx:BidResponseNoBidComponentsGrp) =
    let nextFreeIdx = WriteCommissionDataFG dest nextFreeIdx xx.CommissionDataFG   // component
    let nextFreeIdx = Option.fold (WriteListID dest) nextFreeIdx xx.ListID
    let nextFreeIdx = Option.fold (WriteCountry dest) nextFreeIdx xx.Country
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WriteFairValue dest) nextFreeIdx xx.FairValue
    let nextFreeIdx = Option.fold (WriteNetGrossInd dest) nextFreeIdx xx.NetGrossInd
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// group
let WriteNoLegAllocsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoLegAllocsGrp) =
    let nextFreeIdx = WriteLegAllocAccount dest nextFreeIdx xx.LegAllocAccount
    let nextFreeIdx = Option.fold (WriteLegIndividualAllocID dest) nextFreeIdx xx.LegIndividualAllocID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNested2PartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNested2PartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNested2PartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNested2PartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNested2PartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegAllocQty dest) nextFreeIdx xx.LegAllocQty
    let nextFreeIdx = Option.fold (WriteLegAllocAcctIDSource dest) nextFreeIdx xx.LegAllocAcctIDSource
    let nextFreeIdx = Option.fold (WriteLegSettlCurrency dest) nextFreeIdx xx.LegSettlCurrency
    nextFreeIdx


// group
let WriteMultilegOrderCancelReplaceRequestNoLegsGrp (dest:byte []) (nextFreeIdx:int) (xx:MultilegOrderCancelReplaceRequestNoLegsGrp) =
    let nextFreeIdx = WriteInstrumentLegFG dest nextFreeIdx xx.InstrumentLegFG   // component
    let nextFreeIdx = Option.fold (WriteLegQty dest) nextFreeIdx xx.LegQty
    let nextFreeIdx = Option.fold (WriteLegSwapType dest) nextFreeIdx xx.LegSwapType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegStipulations dest innerNextFreeIdx (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegStipulationsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegAllocs dest innerNextFreeIdx (Fix44.Fields.NoLegAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegAllocsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegPositionEffect dest) nextFreeIdx xx.LegPositionEffect
    let nextFreeIdx = Option.fold (WriteLegCoveredOrUncovered dest) nextFreeIdx xx.LegCoveredOrUncovered
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegRefID dest) nextFreeIdx xx.LegRefID
    let nextFreeIdx = Option.fold (WriteLegPrice dest) nextFreeIdx xx.LegPrice
    let nextFreeIdx = Option.fold (WriteLegSettlType dest) nextFreeIdx xx.LegSettlType
    let nextFreeIdx = Option.fold (WriteLegSettlDate dest) nextFreeIdx xx.LegSettlDate
    nextFreeIdx


// group
let WriteNoNested3PartySubIDsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoNested3PartySubIDsGrp) =
    let nextFreeIdx = WriteNested3PartySubID dest nextFreeIdx xx.Nested3PartySubID
    let nextFreeIdx = Option.fold (WriteNested3PartySubIDType dest) nextFreeIdx xx.Nested3PartySubIDType
    nextFreeIdx


// group
let WriteNoNested3PartyIDsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoNested3PartyIDsGrp) =
    let nextFreeIdx = WriteNested3PartyID dest nextFreeIdx xx.Nested3PartyID
    let nextFreeIdx = Option.fold (WriteNested3PartyIDSource dest) nextFreeIdx xx.Nested3PartyIDSource
    let nextFreeIdx = Option.fold (WriteNested3PartyRole dest) nextFreeIdx xx.Nested3PartyRole
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNested3PartySubIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNested3PartySubIDs dest innerNextFreeIdx (Fix44.Fields.NoNested3PartySubIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNested3PartySubIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNested3PartySubIDsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteMultilegOrderCancelReplaceRequestNoAllocsGrp (dest:byte []) (nextFreeIdx:int) (xx:MultilegOrderCancelReplaceRequestNoAllocsGrp) =
    let nextFreeIdx = WriteAllocAccount dest nextFreeIdx xx.AllocAccount
    let nextFreeIdx = Option.fold (WriteAllocAcctIDSource dest) nextFreeIdx xx.AllocAcctIDSource
    let nextFreeIdx = Option.fold (WriteAllocSettlCurrency dest) nextFreeIdx xx.AllocSettlCurrency
    let nextFreeIdx = Option.fold (WriteIndividualAllocID dest) nextFreeIdx xx.IndividualAllocID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNested3PartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNested3PartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNested3PartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNested3PartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNested3PartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteAllocQty dest) nextFreeIdx xx.AllocQty
    nextFreeIdx


// group
let WriteNewOrderMultilegNoLegsGrp (dest:byte []) (nextFreeIdx:int) (xx:NewOrderMultilegNoLegsGrp) =
    let nextFreeIdx = WriteInstrumentLegFG dest nextFreeIdx xx.InstrumentLegFG   // component
    let nextFreeIdx = Option.fold (WriteLegQty dest) nextFreeIdx xx.LegQty
    let nextFreeIdx = Option.fold (WriteLegSwapType dest) nextFreeIdx xx.LegSwapType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegStipulations dest innerNextFreeIdx (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegStipulationsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegAllocs dest innerNextFreeIdx (Fix44.Fields.NoLegAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegAllocsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegPositionEffect dest) nextFreeIdx xx.LegPositionEffect
    let nextFreeIdx = Option.fold (WriteLegCoveredOrUncovered dest) nextFreeIdx xx.LegCoveredOrUncovered
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegRefID dest) nextFreeIdx xx.LegRefID
    let nextFreeIdx = Option.fold (WriteLegPrice dest) nextFreeIdx xx.LegPrice
    let nextFreeIdx = Option.fold (WriteLegSettlType dest) nextFreeIdx xx.LegSettlType
    let nextFreeIdx = Option.fold (WriteLegSettlDate dest) nextFreeIdx xx.LegSettlDate
    nextFreeIdx


// component
let WriteNestedParties2 (dest:byte []) (nextFreeIdx:int) (xx:NestedParties2) =
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNested2PartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNested2PartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNested2PartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNested2PartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNested2PartyIDsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteNewOrderMultilegNoAllocsGrp (dest:byte []) (nextFreeIdx:int) (xx:NewOrderMultilegNoAllocsGrp) =
    let nextFreeIdx = WriteAllocAccount dest nextFreeIdx xx.AllocAccount
    let nextFreeIdx = Option.fold (WriteAllocAcctIDSource dest) nextFreeIdx xx.AllocAcctIDSource
    let nextFreeIdx = Option.fold (WriteAllocSettlCurrency dest) nextFreeIdx xx.AllocSettlCurrency
    let nextFreeIdx = Option.fold (WriteIndividualAllocID dest) nextFreeIdx xx.IndividualAllocID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNested3PartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNested3PartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNested3PartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNested3PartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNested3PartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteAllocQty dest) nextFreeIdx xx.AllocQty
    nextFreeIdx


// component
let WriteNestedParties3 (dest:byte []) (nextFreeIdx:int) (xx:NestedParties3) =
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNested3PartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNested3PartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNested3PartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNested3PartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNested3PartyIDsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteCrossOrderCancelRequestNoSidesGrp (dest:byte []) (nextFreeIdx:int) (xx:CrossOrderCancelRequestNoSidesGrp) =
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = WriteOrigClOrdID dest nextFreeIdx xx.OrigClOrdID
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = Option.fold (WriteClOrdLinkID dest) nextFreeIdx xx.ClOrdLinkID
    let nextFreeIdx = Option.fold (WriteOrigOrdModTime dest) nextFreeIdx xx.OrigOrdModTime
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = WriteOrderQtyData dest nextFreeIdx xx.OrderQtyData   // component
    let nextFreeIdx = Option.fold (WriteComplianceID dest) nextFreeIdx xx.ComplianceID
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// group
let WriteCrossOrderCancelReplaceRequestNoSidesGrp (dest:byte []) (nextFreeIdx:int) (xx:CrossOrderCancelReplaceRequestNoSidesGrp) =
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = WriteOrigClOrdID dest nextFreeIdx xx.OrigClOrdID
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = Option.fold (WriteClOrdLinkID dest) nextFreeIdx xx.ClOrdLinkID
    let nextFreeIdx = Option.fold (WriteOrigOrdModTime dest) nextFreeIdx xx.OrigOrdModTime
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteDayBookingInst dest) nextFreeIdx xx.DayBookingInst
    let nextFreeIdx = Option.fold (WriteBookingUnit dest) nextFreeIdx xx.BookingUnit
    let nextFreeIdx = Option.fold (WritePreallocMethod dest) nextFreeIdx xx.PreallocMethod
    let nextFreeIdx = Option.fold (WriteAllocID dest) nextFreeIdx xx.AllocID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAllocs dest innerNextFreeIdx (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoAllocsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = WriteOrderQtyData dest nextFreeIdx xx.OrderQtyData   // component
    let nextFreeIdx = WriteCommissionData dest nextFreeIdx xx.CommissionData   // component
    let nextFreeIdx = Option.fold (WriteOrderCapacity dest) nextFreeIdx xx.OrderCapacity
    let nextFreeIdx = Option.fold (WriteOrderRestrictions dest) nextFreeIdx xx.OrderRestrictions
    let nextFreeIdx = Option.fold (WriteCustOrderCapacity dest) nextFreeIdx xx.CustOrderCapacity
    let nextFreeIdx = Option.fold (WriteForexReq dest) nextFreeIdx xx.ForexReq
    let nextFreeIdx = Option.fold (WriteSettlCurrency dest) nextFreeIdx xx.SettlCurrency
    let nextFreeIdx = Option.fold (WriteBookingType dest) nextFreeIdx xx.BookingType
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WritePositionEffect dest) nextFreeIdx xx.PositionEffect
    let nextFreeIdx = Option.fold (WriteCoveredOrUncovered dest) nextFreeIdx xx.CoveredOrUncovered
    let nextFreeIdx = Option.fold (WriteCashMargin dest) nextFreeIdx xx.CashMargin
    let nextFreeIdx = Option.fold (WriteClearingFeeIndicator dest) nextFreeIdx xx.ClearingFeeIndicator
    let nextFreeIdx = Option.fold (WriteSolicitedFlag dest) nextFreeIdx xx.SolicitedFlag
    let nextFreeIdx = Option.fold (WriteSideComplianceID dest) nextFreeIdx xx.SideComplianceID
    nextFreeIdx


// group
let WriteNoSidesGrp (dest:byte []) (nextFreeIdx:int) (xx:NoSidesGrp) =
    let nextFreeIdx = WriteSide dest nextFreeIdx xx.Side
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = Option.fold (WriteClOrdLinkID dest) nextFreeIdx xx.ClOrdLinkID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteTradeDate dest) nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    let nextFreeIdx = Option.fold (WriteDayBookingInst dest) nextFreeIdx xx.DayBookingInst
    let nextFreeIdx = Option.fold (WriteBookingUnit dest) nextFreeIdx xx.BookingUnit
    let nextFreeIdx = Option.fold (WritePreallocMethod dest) nextFreeIdx xx.PreallocMethod
    let nextFreeIdx = Option.fold (WriteAllocID dest) nextFreeIdx xx.AllocID
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoAllocsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoAllocs dest innerNextFreeIdx (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoAllocsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoAllocsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = WriteOrderQtyData dest nextFreeIdx xx.OrderQtyData   // component
    let nextFreeIdx = WriteCommissionData dest nextFreeIdx xx.CommissionData   // component
    let nextFreeIdx = Option.fold (WriteOrderCapacity dest) nextFreeIdx xx.OrderCapacity
    let nextFreeIdx = Option.fold (WriteOrderRestrictions dest) nextFreeIdx xx.OrderRestrictions
    let nextFreeIdx = Option.fold (WriteCustOrderCapacity dest) nextFreeIdx xx.CustOrderCapacity
    let nextFreeIdx = Option.fold (WriteForexReq dest) nextFreeIdx xx.ForexReq
    let nextFreeIdx = Option.fold (WriteSettlCurrency dest) nextFreeIdx xx.SettlCurrency
    let nextFreeIdx = Option.fold (WriteBookingType dest) nextFreeIdx xx.BookingType
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    let nextFreeIdx = Option.fold (WritePositionEffect dest) nextFreeIdx xx.PositionEffect
    let nextFreeIdx = Option.fold (WriteCoveredOrUncovered dest) nextFreeIdx xx.CoveredOrUncovered
    let nextFreeIdx = Option.fold (WriteCashMargin dest) nextFreeIdx xx.CashMargin
    let nextFreeIdx = Option.fold (WriteClearingFeeIndicator dest) nextFreeIdx xx.ClearingFeeIndicator
    let nextFreeIdx = Option.fold (WriteSolicitedFlag dest) nextFreeIdx xx.SolicitedFlag
    let nextFreeIdx = Option.fold (WriteSideComplianceID dest) nextFreeIdx xx.SideComplianceID
    nextFreeIdx


// group
let WriteExecutionReportNoLegsGrp (dest:byte []) (nextFreeIdx:int) (xx:ExecutionReportNoLegsGrp) =
    let nextFreeIdx = WriteInstrumentLegFG dest nextFreeIdx xx.InstrumentLegFG   // component
    let nextFreeIdx = Option.fold (WriteLegQty dest) nextFreeIdx xx.LegQty
    let nextFreeIdx = Option.fold (WriteLegSwapType dest) nextFreeIdx xx.LegSwapType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegStipulations dest innerNextFreeIdx (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegStipulationsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegPositionEffect dest) nextFreeIdx xx.LegPositionEffect
    let nextFreeIdx = Option.fold (WriteLegCoveredOrUncovered dest) nextFreeIdx xx.LegCoveredOrUncovered
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegRefID dest) nextFreeIdx xx.LegRefID
    let nextFreeIdx = Option.fold (WriteLegPrice dest) nextFreeIdx xx.LegPrice
    let nextFreeIdx = Option.fold (WriteLegSettlType dest) nextFreeIdx xx.LegSettlType
    let nextFreeIdx = Option.fold (WriteLegSettlDate dest) nextFreeIdx xx.LegSettlDate
    let nextFreeIdx = Option.fold (WriteLegLastPx dest) nextFreeIdx xx.LegLastPx
    nextFreeIdx


// group
let WriteNoInstrAttribGrp (dest:byte []) (nextFreeIdx:int) (xx:NoInstrAttribGrp) =
    let nextFreeIdx = WriteInstrAttribType dest nextFreeIdx xx.InstrAttribType
    let nextFreeIdx = Option.fold (WriteInstrAttribValue dest) nextFreeIdx xx.InstrAttribValue
    nextFreeIdx


// component
let WriteInstrumentExtension (dest:byte []) (nextFreeIdx:int) (xx:InstrumentExtension) =
    let nextFreeIdx = Option.fold (WriteDeliveryForm dest) nextFreeIdx xx.DeliveryForm
    let nextFreeIdx = Option.fold (WritePctAtRisk dest) nextFreeIdx xx.PctAtRisk
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoInstrAttribGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoInstrAttrib dest innerNextFreeIdx (Fix44.Fields.NoInstrAttrib numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoInstrAttribGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoInstrAttribGrp  // end Option.fold
    nextFreeIdx


// group
let WriteNoLegsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoLegsGrp) =
    let nextFreeIdx = WriteInstrumentLegFG dest nextFreeIdx xx.InstrumentLegFG   // component
    nextFreeIdx


// group
let WriteDerivativeSecurityListNoRelatedSymGrp (dest:byte []) (nextFreeIdx:int) (xx:DerivativeSecurityListNoRelatedSymGrp) =
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteExpirationCycle dest) nextFreeIdx xx.ExpirationCycle
    let nextFreeIdx = WriteInstrumentExtension dest nextFreeIdx xx.InstrumentExtension   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// component
let WriteFinancingDetails (dest:byte []) (nextFreeIdx:int) (xx:FinancingDetails) =
    let nextFreeIdx = Option.fold (WriteAgreementDesc dest) nextFreeIdx xx.AgreementDesc
    let nextFreeIdx = Option.fold (WriteAgreementID dest) nextFreeIdx xx.AgreementID
    let nextFreeIdx = Option.fold (WriteAgreementDate dest) nextFreeIdx xx.AgreementDate
    let nextFreeIdx = Option.fold (WriteAgreementCurrency dest) nextFreeIdx xx.AgreementCurrency
    let nextFreeIdx = Option.fold (WriteTerminationType dest) nextFreeIdx xx.TerminationType
    let nextFreeIdx = Option.fold (WriteStartDate dest) nextFreeIdx xx.StartDate
    let nextFreeIdx = Option.fold (WriteEndDate dest) nextFreeIdx xx.EndDate
    let nextFreeIdx = Option.fold (WriteDeliveryType dest) nextFreeIdx xx.DeliveryType
    let nextFreeIdx = Option.fold (WriteMarginRatio dest) nextFreeIdx xx.MarginRatio
    nextFreeIdx


// component
let WriteLegBenchmarkCurveData (dest:byte []) (nextFreeIdx:int) (xx:LegBenchmarkCurveData) =
    let nextFreeIdx = Option.fold (WriteLegBenchmarkCurveCurrency dest) nextFreeIdx xx.LegBenchmarkCurveCurrency
    let nextFreeIdx = Option.fold (WriteLegBenchmarkCurveName dest) nextFreeIdx xx.LegBenchmarkCurveName
    let nextFreeIdx = Option.fold (WriteLegBenchmarkCurvePoint dest) nextFreeIdx xx.LegBenchmarkCurvePoint
    let nextFreeIdx = Option.fold (WriteLegBenchmarkPrice dest) nextFreeIdx xx.LegBenchmarkPrice
    let nextFreeIdx = Option.fold (WriteLegBenchmarkPriceType dest) nextFreeIdx xx.LegBenchmarkPriceType
    nextFreeIdx


// group
let WriteSecurityListNoLegsGrp (dest:byte []) (nextFreeIdx:int) (xx:SecurityListNoLegsGrp) =
    let nextFreeIdx = WriteInstrumentLegFG dest nextFreeIdx xx.InstrumentLegFG   // component
    let nextFreeIdx = Option.fold (WriteLegSwapType dest) nextFreeIdx xx.LegSwapType
    let nextFreeIdx = Option.fold (WriteLegSettlType dest) nextFreeIdx xx.LegSettlType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegStipulations dest innerNextFreeIdx (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegStipulationsGrp  // end Option.fold
    let nextFreeIdx = WriteLegBenchmarkCurveData dest nextFreeIdx xx.LegBenchmarkCurveData   // component
    nextFreeIdx


// group
let WriteSecurityListNoRelatedSymGrp (dest:byte []) (nextFreeIdx:int) (xx:SecurityListNoRelatedSymGrp) =
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = WriteInstrumentExtension dest nextFreeIdx xx.InstrumentExtension   // component
    let nextFreeIdx = WriteFinancingDetails dest nextFreeIdx xx.FinancingDetails   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoStipulations dest innerNextFreeIdx (Fix44.Fields.NoStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoStipulationsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:SecurityListNoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteSecurityListNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.SecurityListNoLegsGrp  // end Option.fold
    let nextFreeIdx = WriteSpreadOrBenchmarkCurveData dest nextFreeIdx xx.SpreadOrBenchmarkCurveData   // component
    let nextFreeIdx = WriteYieldData dest nextFreeIdx xx.YieldData   // component
    let nextFreeIdx = Option.fold (WriteRoundLot dest) nextFreeIdx xx.RoundLot
    let nextFreeIdx = Option.fold (WriteMinTradeVol dest) nextFreeIdx xx.MinTradeVol
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteExpirationCycle dest) nextFreeIdx xx.ExpirationCycle
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// group
let WriteMarketDataIncrementalRefreshNoMDEntriesGrp (dest:byte []) (nextFreeIdx:int) (xx:MarketDataIncrementalRefreshNoMDEntriesGrp) =
    let nextFreeIdx = WriteMDUpdateAction dest nextFreeIdx xx.MDUpdateAction
    let nextFreeIdx = Option.fold (WriteDeleteReason dest) nextFreeIdx xx.DeleteReason
    let nextFreeIdx = Option.fold (WriteMDEntryType dest) nextFreeIdx xx.MDEntryType
    let nextFreeIdx = Option.fold (WriteMDEntryID dest) nextFreeIdx xx.MDEntryID
    let nextFreeIdx = Option.fold (WriteMDEntryRefID dest) nextFreeIdx xx.MDEntryRefID
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteFinancialStatus dest) nextFreeIdx xx.FinancialStatus
    let nextFreeIdx = Option.fold (WriteCorporateAction dest) nextFreeIdx xx.CorporateAction
    let nextFreeIdx = Option.fold (WriteMDEntryPx dest) nextFreeIdx xx.MDEntryPx
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteMDEntrySize dest) nextFreeIdx xx.MDEntrySize
    let nextFreeIdx = Option.fold (WriteMDEntryDate dest) nextFreeIdx xx.MDEntryDate
    let nextFreeIdx = Option.fold (WriteMDEntryTime dest) nextFreeIdx xx.MDEntryTime
    let nextFreeIdx = Option.fold (WriteTickDirection dest) nextFreeIdx xx.TickDirection
    let nextFreeIdx = Option.fold (WriteMDMkt dest) nextFreeIdx xx.MDMkt
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteQuoteCondition dest) nextFreeIdx xx.QuoteCondition
    let nextFreeIdx = Option.fold (WriteTradeCondition dest) nextFreeIdx xx.TradeCondition
    let nextFreeIdx = Option.fold (WriteMDEntryOriginator dest) nextFreeIdx xx.MDEntryOriginator
    let nextFreeIdx = Option.fold (WriteLocationID dest) nextFreeIdx xx.LocationID
    let nextFreeIdx = Option.fold (WriteDeskID dest) nextFreeIdx xx.DeskID
    let nextFreeIdx = Option.fold (WriteOpenCloseSettlFlag dest) nextFreeIdx xx.OpenCloseSettlFlag
    let nextFreeIdx = Option.fold (WriteTimeInForce dest) nextFreeIdx xx.TimeInForce
    let nextFreeIdx = Option.fold (WriteExpireDate dest) nextFreeIdx xx.ExpireDate
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteMinQty dest) nextFreeIdx xx.MinQty
    let nextFreeIdx = Option.fold (WriteExecInst dest) nextFreeIdx xx.ExecInst
    let nextFreeIdx = Option.fold (WriteSellerDays dest) nextFreeIdx xx.SellerDays
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteQuoteEntryID dest) nextFreeIdx xx.QuoteEntryID
    let nextFreeIdx = Option.fold (WriteMDEntryBuyer dest) nextFreeIdx xx.MDEntryBuyer
    let nextFreeIdx = Option.fold (WriteMDEntrySeller dest) nextFreeIdx xx.MDEntrySeller
    let nextFreeIdx = Option.fold (WriteNumberOfOrders dest) nextFreeIdx xx.NumberOfOrders
    let nextFreeIdx = Option.fold (WriteMDEntryPositionNo dest) nextFreeIdx xx.MDEntryPositionNo
    let nextFreeIdx = Option.fold (WriteScope dest) nextFreeIdx xx.Scope
    let nextFreeIdx = Option.fold (WritePriceDelta dest) nextFreeIdx xx.PriceDelta
    let nextFreeIdx = Option.fold (WriteNetChgPrevDay dest) nextFreeIdx xx.NetChgPrevDay
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// group
let WriteMarketDataRequestNoRelatedSymGrp (dest:byte []) (nextFreeIdx:int) (xx:MarketDataRequestNoRelatedSymGrp) =
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteMassQuoteAcknowledgementNoQuoteEntriesGrp (dest:byte []) (nextFreeIdx:int) (xx:MassQuoteAcknowledgementNoQuoteEntriesGrp) =
    let nextFreeIdx = WriteQuoteEntryID dest nextFreeIdx xx.QuoteEntryID
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteBidPx dest) nextFreeIdx xx.BidPx
    let nextFreeIdx = Option.fold (WriteOfferPx dest) nextFreeIdx xx.OfferPx
    let nextFreeIdx = Option.fold (WriteBidSize dest) nextFreeIdx xx.BidSize
    let nextFreeIdx = Option.fold (WriteOfferSize dest) nextFreeIdx xx.OfferSize
    let nextFreeIdx = Option.fold (WriteValidUntilTime dest) nextFreeIdx xx.ValidUntilTime
    let nextFreeIdx = Option.fold (WriteBidSpotRate dest) nextFreeIdx xx.BidSpotRate
    let nextFreeIdx = Option.fold (WriteOfferSpotRate dest) nextFreeIdx xx.OfferSpotRate
    let nextFreeIdx = Option.fold (WriteBidForwardPoints dest) nextFreeIdx xx.BidForwardPoints
    let nextFreeIdx = Option.fold (WriteOfferForwardPoints dest) nextFreeIdx xx.OfferForwardPoints
    let nextFreeIdx = Option.fold (WriteMidPx dest) nextFreeIdx xx.MidPx
    let nextFreeIdx = Option.fold (WriteBidYield dest) nextFreeIdx xx.BidYield
    let nextFreeIdx = Option.fold (WriteMidYield dest) nextFreeIdx xx.MidYield
    let nextFreeIdx = Option.fold (WriteOfferYield dest) nextFreeIdx xx.OfferYield
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteOrdType dest) nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WriteSettlDate2 dest) nextFreeIdx xx.SettlDate2
    let nextFreeIdx = Option.fold (WriteOrderQty2 dest) nextFreeIdx xx.OrderQty2
    let nextFreeIdx = Option.fold (WriteBidForwardPoints2 dest) nextFreeIdx xx.BidForwardPoints2
    let nextFreeIdx = Option.fold (WriteOfferForwardPoints2 dest) nextFreeIdx xx.OfferForwardPoints2
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteQuoteEntryRejectReason dest) nextFreeIdx xx.QuoteEntryRejectReason
    nextFreeIdx


// group
let WriteMassQuoteAcknowledgementNoQuoteSetsGrp (dest:byte []) (nextFreeIdx:int) (xx:MassQuoteAcknowledgementNoQuoteSetsGrp) =
    let nextFreeIdx = WriteQuoteSetID dest nextFreeIdx xx.QuoteSetID
    let nextFreeIdx = Option.fold (WriteUnderlyingInstrument dest) nextFreeIdx xx.UnderlyingInstrument    // component option
    let nextFreeIdx = Option.fold (WriteTotNoQuoteEntries dest) nextFreeIdx xx.TotNoQuoteEntries
    let nextFreeIdx = Option.fold (WriteLastFragment dest) nextFreeIdx xx.LastFragment
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:MassQuoteAcknowledgementNoQuoteEntriesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoQuoteEntries dest innerNextFreeIdx (Fix44.Fields.NoQuoteEntries numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteMassQuoteAcknowledgementNoQuoteEntriesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.MassQuoteAcknowledgementNoQuoteEntriesGrp  // end Option.fold
    nextFreeIdx


// group
let WriteMassQuoteNoQuoteEntriesGrp (dest:byte []) (nextFreeIdx:int) (xx:MassQuoteNoQuoteEntriesGrp) =
    let nextFreeIdx = WriteQuoteEntryID dest nextFreeIdx xx.QuoteEntryID
    let nextFreeIdx = Option.fold (WriteInstrument dest) nextFreeIdx xx.Instrument    // component option
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteBidPx dest) nextFreeIdx xx.BidPx
    let nextFreeIdx = Option.fold (WriteOfferPx dest) nextFreeIdx xx.OfferPx
    let nextFreeIdx = Option.fold (WriteBidSize dest) nextFreeIdx xx.BidSize
    let nextFreeIdx = Option.fold (WriteOfferSize dest) nextFreeIdx xx.OfferSize
    let nextFreeIdx = Option.fold (WriteValidUntilTime dest) nextFreeIdx xx.ValidUntilTime
    let nextFreeIdx = Option.fold (WriteBidSpotRate dest) nextFreeIdx xx.BidSpotRate
    let nextFreeIdx = Option.fold (WriteOfferSpotRate dest) nextFreeIdx xx.OfferSpotRate
    let nextFreeIdx = Option.fold (WriteBidForwardPoints dest) nextFreeIdx xx.BidForwardPoints
    let nextFreeIdx = Option.fold (WriteOfferForwardPoints dest) nextFreeIdx xx.OfferForwardPoints
    let nextFreeIdx = Option.fold (WriteMidPx dest) nextFreeIdx xx.MidPx
    let nextFreeIdx = Option.fold (WriteBidYield dest) nextFreeIdx xx.BidYield
    let nextFreeIdx = Option.fold (WriteMidYield dest) nextFreeIdx xx.MidYield
    let nextFreeIdx = Option.fold (WriteOfferYield dest) nextFreeIdx xx.OfferYield
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteOrdType dest) nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WriteSettlDate2 dest) nextFreeIdx xx.SettlDate2
    let nextFreeIdx = Option.fold (WriteOrderQty2 dest) nextFreeIdx xx.OrderQty2
    let nextFreeIdx = Option.fold (WriteBidForwardPoints2 dest) nextFreeIdx xx.BidForwardPoints2
    let nextFreeIdx = Option.fold (WriteOfferForwardPoints2 dest) nextFreeIdx xx.OfferForwardPoints2
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    nextFreeIdx


// group
let WriteNoQuoteSetsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoQuoteSetsGrp) =
    let nextFreeIdx = WriteQuoteSetID dest nextFreeIdx xx.QuoteSetID
    let nextFreeIdx = Option.fold (WriteUnderlyingInstrument dest) nextFreeIdx xx.UnderlyingInstrument    // component option
    let nextFreeIdx = Option.fold (WriteQuoteSetValidUntilTime dest) nextFreeIdx xx.QuoteSetValidUntilTime
    let nextFreeIdx = WriteTotNoQuoteEntries dest nextFreeIdx xx.TotNoQuoteEntries
    let nextFreeIdx = Option.fold (WriteLastFragment dest) nextFreeIdx xx.LastFragment
    let numGrps = xx.MassQuoteNoQuoteEntriesGrp.Length
    let nextFreeIdx = WriteNoQuoteEntries dest nextFreeIdx (Fix44.Fields.NoQuoteEntries numGrps) // write the 'num group repeats' field
    let nextFreeIdx =  xx.MassQuoteNoQuoteEntriesGrp |> List.fold (fun accFreeIdx gg -> WriteMassQuoteNoQuoteEntriesGrp dest accFreeIdx gg) nextFreeIdx
    nextFreeIdx


// group
let WriteQuoteStatusReportNoLegsGrp (dest:byte []) (nextFreeIdx:int) (xx:QuoteStatusReportNoLegsGrp) =
    let nextFreeIdx = WriteInstrumentLegFG dest nextFreeIdx xx.InstrumentLegFG   // component
    let nextFreeIdx = Option.fold (WriteLegQty dest) nextFreeIdx xx.LegQty
    let nextFreeIdx = Option.fold (WriteLegSwapType dest) nextFreeIdx xx.LegSwapType
    let nextFreeIdx = Option.fold (WriteLegSettlType dest) nextFreeIdx xx.LegSettlType
    let nextFreeIdx = Option.fold (WriteLegSettlDate dest) nextFreeIdx xx.LegSettlDate
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegStipulations dest innerNextFreeIdx (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegStipulationsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteNoQuoteEntriesGrp (dest:byte []) (nextFreeIdx:int) (xx:NoQuoteEntriesGrp) =
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = WriteFinancingDetails dest nextFreeIdx xx.FinancingDetails   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteQuoteNoLegsGrp (dest:byte []) (nextFreeIdx:int) (xx:QuoteNoLegsGrp) =
    let nextFreeIdx = WriteInstrumentLegFG dest nextFreeIdx xx.InstrumentLegFG   // component
    let nextFreeIdx = Option.fold (WriteLegQty dest) nextFreeIdx xx.LegQty
    let nextFreeIdx = Option.fold (WriteLegSwapType dest) nextFreeIdx xx.LegSwapType
    let nextFreeIdx = Option.fold (WriteLegSettlType dest) nextFreeIdx xx.LegSettlType
    let nextFreeIdx = Option.fold (WriteLegSettlDate dest) nextFreeIdx xx.LegSettlDate
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegStipulations dest innerNextFreeIdx (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegStipulationsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegPriceType dest) nextFreeIdx xx.LegPriceType
    let nextFreeIdx = Option.fold (WriteLegBidPx dest) nextFreeIdx xx.LegBidPx
    let nextFreeIdx = Option.fold (WriteLegOfferPx dest) nextFreeIdx xx.LegOfferPx
    let nextFreeIdx = WriteLegBenchmarkCurveData dest nextFreeIdx xx.LegBenchmarkCurveData   // component
    nextFreeIdx


// group
let WriteRFQRequestNoRelatedSymGrp (dest:byte []) (nextFreeIdx:int) (xx:RFQRequestNoRelatedSymGrp) =
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePrevClosePx dest) nextFreeIdx xx.PrevClosePx
    let nextFreeIdx = Option.fold (WriteQuoteRequestType dest) nextFreeIdx xx.QuoteRequestType
    let nextFreeIdx = Option.fold (WriteQuoteType dest) nextFreeIdx xx.QuoteType
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    nextFreeIdx


// group
let WriteQuoteRequestRejectNoLegsGrp (dest:byte []) (nextFreeIdx:int) (xx:QuoteRequestRejectNoLegsGrp) =
    let nextFreeIdx = WriteInstrumentLegFG dest nextFreeIdx xx.InstrumentLegFG   // component
    let nextFreeIdx = Option.fold (WriteLegQty dest) nextFreeIdx xx.LegQty
    let nextFreeIdx = Option.fold (WriteLegSwapType dest) nextFreeIdx xx.LegSwapType
    let nextFreeIdx = Option.fold (WriteLegSettlType dest) nextFreeIdx xx.LegSettlType
    let nextFreeIdx = Option.fold (WriteLegSettlDate dest) nextFreeIdx xx.LegSettlDate
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegStipulations dest innerNextFreeIdx (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegStipulationsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    let nextFreeIdx = WriteLegBenchmarkCurveData dest nextFreeIdx xx.LegBenchmarkCurveData   // component
    nextFreeIdx


// group
let WriteQuoteRequestRejectNoRelatedSymGrp (dest:byte []) (nextFreeIdx:int) (xx:QuoteRequestRejectNoRelatedSymGrp) =
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = WriteFinancingDetails dest nextFreeIdx xx.FinancingDetails   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePrevClosePx dest) nextFreeIdx xx.PrevClosePx
    let nextFreeIdx = Option.fold (WriteQuoteRequestType dest) nextFreeIdx xx.QuoteRequestType
    let nextFreeIdx = Option.fold (WriteQuoteType dest) nextFreeIdx xx.QuoteType
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = WriteOrderQtyData dest nextFreeIdx xx.OrderQtyData   // component
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteSettlDate2 dest) nextFreeIdx xx.SettlDate2
    let nextFreeIdx = Option.fold (WriteOrderQty2 dest) nextFreeIdx xx.OrderQty2
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoStipulations dest innerNextFreeIdx (Fix44.Fields.NoStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoStipulationsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:QuoteRequestRejectNoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteQuoteRequestRejectNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.QuoteRequestRejectNoLegsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteQuoteResponseNoLegsGrp (dest:byte []) (nextFreeIdx:int) (xx:QuoteResponseNoLegsGrp) =
    let nextFreeIdx = WriteInstrumentLegFG dest nextFreeIdx xx.InstrumentLegFG   // component
    let nextFreeIdx = Option.fold (WriteLegQty dest) nextFreeIdx xx.LegQty
    let nextFreeIdx = Option.fold (WriteLegSwapType dest) nextFreeIdx xx.LegSwapType
    let nextFreeIdx = Option.fold (WriteLegSettlType dest) nextFreeIdx xx.LegSettlType
    let nextFreeIdx = Option.fold (WriteLegSettlDate dest) nextFreeIdx xx.LegSettlDate
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegStipulations dest innerNextFreeIdx (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegStipulationsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegPriceType dest) nextFreeIdx xx.LegPriceType
    let nextFreeIdx = Option.fold (WriteLegBidPx dest) nextFreeIdx xx.LegBidPx
    let nextFreeIdx = Option.fold (WriteLegOfferPx dest) nextFreeIdx xx.LegOfferPx
    let nextFreeIdx = WriteLegBenchmarkCurveData dest nextFreeIdx xx.LegBenchmarkCurveData   // component
    nextFreeIdx


// group
let WriteQuoteRequestNoLegsGrp (dest:byte []) (nextFreeIdx:int) (xx:QuoteRequestNoLegsGrp) =
    let nextFreeIdx = WriteInstrumentLegFG dest nextFreeIdx xx.InstrumentLegFG   // component
    let nextFreeIdx = Option.fold (WriteLegQty dest) nextFreeIdx xx.LegQty
    let nextFreeIdx = Option.fold (WriteLegSwapType dest) nextFreeIdx xx.LegSwapType
    let nextFreeIdx = Option.fold (WriteLegSettlType dest) nextFreeIdx xx.LegSettlType
    let nextFreeIdx = Option.fold (WriteLegSettlDate dest) nextFreeIdx xx.LegSettlDate
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegStipulations dest innerNextFreeIdx (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegStipulationsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    let nextFreeIdx = WriteLegBenchmarkCurveData dest nextFreeIdx xx.LegBenchmarkCurveData   // component
    nextFreeIdx


// group
let WriteNoQuoteQualifiersGrp (dest:byte []) (nextFreeIdx:int) (xx:NoQuoteQualifiersGrp) =
    let nextFreeIdx = WriteQuoteQualifier dest nextFreeIdx xx.QuoteQualifier
    nextFreeIdx


// group
let WriteQuoteRequestNoRelatedSymGrp (dest:byte []) (nextFreeIdx:int) (xx:QuoteRequestNoRelatedSymGrp) =
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    let nextFreeIdx = WriteFinancingDetails dest nextFreeIdx xx.FinancingDetails   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyings dest innerNextFreeIdx (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WritePrevClosePx dest) nextFreeIdx xx.PrevClosePx
    let nextFreeIdx = Option.fold (WriteQuoteRequestType dest) nextFreeIdx xx.QuoteRequestType
    let nextFreeIdx = Option.fold (WriteQuoteType dest) nextFreeIdx xx.QuoteType
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteTradeOriginationDate dest) nextFreeIdx xx.TradeOriginationDate
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteQtyType dest) nextFreeIdx xx.QtyType
    let nextFreeIdx = WriteOrderQtyData dest nextFreeIdx xx.OrderQtyData   // component
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteSettlDate2 dest) nextFreeIdx xx.SettlDate2
    let nextFreeIdx = Option.fold (WriteOrderQty2 dest) nextFreeIdx xx.OrderQty2
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoStipulations dest innerNextFreeIdx (Fix44.Fields.NoStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoStipulationsGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    let nextFreeIdx = Option.fold (WriteAccountType dest) nextFreeIdx xx.AccountType
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:QuoteRequestNoLegsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegs dest innerNextFreeIdx (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteQuoteRequestNoLegsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.QuoteRequestNoLegsGrp  // end Option.fold
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoQuoteQualifiersGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoQuoteQualifiers dest innerNextFreeIdx (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoQuoteQualifiersGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoQuoteQualifiersGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteQuotePriceType dest) nextFreeIdx xx.QuotePriceType
    let nextFreeIdx = Option.fold (WriteOrdType dest) nextFreeIdx xx.OrdType
    let nextFreeIdx = Option.fold (WriteValidUntilTime dest) nextFreeIdx xx.ValidUntilTime
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    let nextFreeIdx = WriteSpreadOrBenchmarkCurveData dest nextFreeIdx xx.SpreadOrBenchmarkCurveData   // component
    let nextFreeIdx = Option.fold (WritePriceType dest) nextFreeIdx xx.PriceType
    let nextFreeIdx = Option.fold (WritePrice dest) nextFreeIdx xx.Price
    let nextFreeIdx = Option.fold (WritePrice2 dest) nextFreeIdx xx.Price2
    let nextFreeIdx = WriteYieldData dest nextFreeIdx xx.YieldData   // component
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoPartyIDsGrp  // end Option.fold
    nextFreeIdx


// component
let WriteParties (dest:byte []) (nextFreeIdx:int) (xx:Parties) =
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoPartyIDsGrp  // end Option.fold
    nextFreeIdx


// component
let WriteNestedParties (dest:byte []) (nextFreeIdx:int) (xx:NestedParties) =
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoNestedPartyIDsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoNestedPartyIDs dest innerNextFreeIdx (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoNestedPartyIDsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoNestedPartyIDsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteNoRelatedSymGrp (dest:byte []) (nextFreeIdx:int) (xx:NoRelatedSymGrp) =
    let nextFreeIdx = WriteInstrument dest nextFreeIdx xx.Instrument   // component
    nextFreeIdx


// group
let WriteIndicationOfInterestNoLegsGrp (dest:byte []) (nextFreeIdx:int) (xx:IndicationOfInterestNoLegsGrp) =
    let nextFreeIdx = WriteInstrumentLegFG dest nextFreeIdx xx.InstrumentLegFG   // component
    let nextFreeIdx = Option.fold (WriteLegIOIQty dest) nextFreeIdx xx.LegIOIQty
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegStipulations dest innerNextFreeIdx (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegStipulationsGrp  // end Option.fold
    nextFreeIdx


// component
let WriteLegStipulations (dest:byte []) (nextFreeIdx:int) (xx:LegStipulations) =
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegStipulations dest innerNextFreeIdx (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegStipulationsGrp  // end Option.fold
    nextFreeIdx


// component
let WriteStipulations (dest:byte []) (nextFreeIdx:int) (xx:Stipulations) =
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoStipulationsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoStipulations dest innerNextFreeIdx (Fix44.Fields.NoStipulations numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoStipulationsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoStipulationsGrp  // end Option.fold
    nextFreeIdx


// group
let WriteAdvertisementNoUnderlyingsGrp (dest:byte []) (nextFreeIdx:int) (xx:AdvertisementNoUnderlyingsGrp) =
    let nextFreeIdx = WriteUnderlyingInstrument dest nextFreeIdx xx.UnderlyingInstrument   // component
    nextFreeIdx


// component
let WriteUnderlyingStipulations (dest:byte []) (nextFreeIdx:int) (xx:UnderlyingStipulations) =
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoUnderlyingStipsGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoUnderlyingStips dest innerNextFreeIdx (Fix44.Fields.NoUnderlyingStips numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoUnderlyingStipsGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoUnderlyingStipsGrp  // end Option.fold
    nextFreeIdx


// component
let WriteInstrumentLeg (dest:byte []) (nextFreeIdx:int) (xx:InstrumentLeg) =
    let nextFreeIdx = Option.fold (WriteLegSymbol dest) nextFreeIdx xx.LegSymbol
    let nextFreeIdx = Option.fold (WriteLegSymbolSfx dest) nextFreeIdx xx.LegSymbolSfx
    let nextFreeIdx = Option.fold (WriteLegSecurityID dest) nextFreeIdx xx.LegSecurityID
    let nextFreeIdx = Option.fold (WriteLegSecurityIDSource dest) nextFreeIdx xx.LegSecurityIDSource
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoLegSecurityAltIDGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoLegSecurityAltID dest innerNextFreeIdx (Fix44.Fields.NoLegSecurityAltID numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoLegSecurityAltIDGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoLegSecurityAltIDGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteLegProduct dest) nextFreeIdx xx.LegProduct
    let nextFreeIdx = Option.fold (WriteLegCFICode dest) nextFreeIdx xx.LegCFICode
    let nextFreeIdx = Option.fold (WriteLegSecurityType dest) nextFreeIdx xx.LegSecurityType
    let nextFreeIdx = Option.fold (WriteLegSecuritySubType dest) nextFreeIdx xx.LegSecuritySubType
    let nextFreeIdx = Option.fold (WriteLegMaturityMonthYear dest) nextFreeIdx xx.LegMaturityMonthYear
    let nextFreeIdx = Option.fold (WriteLegMaturityDate dest) nextFreeIdx xx.LegMaturityDate
    let nextFreeIdx = Option.fold (WriteLegCouponPaymentDate dest) nextFreeIdx xx.LegCouponPaymentDate
    let nextFreeIdx = Option.fold (WriteLegIssueDate dest) nextFreeIdx xx.LegIssueDate
    let nextFreeIdx = Option.fold (WriteLegRepoCollateralSecurityType dest) nextFreeIdx xx.LegRepoCollateralSecurityType
    let nextFreeIdx = Option.fold (WriteLegRepurchaseTerm dest) nextFreeIdx xx.LegRepurchaseTerm
    let nextFreeIdx = Option.fold (WriteLegRepurchaseRate dest) nextFreeIdx xx.LegRepurchaseRate
    let nextFreeIdx = Option.fold (WriteLegFactor dest) nextFreeIdx xx.LegFactor
    let nextFreeIdx = Option.fold (WriteLegCreditRating dest) nextFreeIdx xx.LegCreditRating
    let nextFreeIdx = Option.fold (WriteLegInstrRegistry dest) nextFreeIdx xx.LegInstrRegistry
    let nextFreeIdx = Option.fold (WriteLegCountryOfIssue dest) nextFreeIdx xx.LegCountryOfIssue
    let nextFreeIdx = Option.fold (WriteLegStateOrProvinceOfIssue dest) nextFreeIdx xx.LegStateOrProvinceOfIssue
    let nextFreeIdx = Option.fold (WriteLegLocaleOfIssue dest) nextFreeIdx xx.LegLocaleOfIssue
    let nextFreeIdx = Option.fold (WriteLegRedemptionDate dest) nextFreeIdx xx.LegRedemptionDate
    let nextFreeIdx = Option.fold (WriteLegStrikePrice dest) nextFreeIdx xx.LegStrikePrice
    let nextFreeIdx = Option.fold (WriteLegStrikeCurrency dest) nextFreeIdx xx.LegStrikeCurrency
    let nextFreeIdx = Option.fold (WriteLegOptAttribute dest) nextFreeIdx xx.LegOptAttribute
    let nextFreeIdx = Option.fold (WriteLegContractMultiplier dest) nextFreeIdx xx.LegContractMultiplier
    let nextFreeIdx = Option.fold (WriteLegCouponRate dest) nextFreeIdx xx.LegCouponRate
    let nextFreeIdx = Option.fold (WriteLegSecurityExchange dest) nextFreeIdx xx.LegSecurityExchange
    let nextFreeIdx = Option.fold (WriteLegIssuer dest) nextFreeIdx xx.LegIssuer
    let nextFreeIdx = Option.fold (WriteEncodedLegIssuer dest) nextFreeIdx xx.EncodedLegIssuer
    let nextFreeIdx = Option.fold (WriteLegSecurityDesc dest) nextFreeIdx xx.LegSecurityDesc
    let nextFreeIdx = Option.fold (WriteEncodedLegSecurityDesc dest) nextFreeIdx xx.EncodedLegSecurityDesc
    let nextFreeIdx = Option.fold (WriteLegRatioQty dest) nextFreeIdx xx.LegRatioQty
    let nextFreeIdx = Option.fold (WriteLegSide dest) nextFreeIdx xx.LegSide
    let nextFreeIdx = Option.fold (WriteLegCurrency dest) nextFreeIdx xx.LegCurrency
    let nextFreeIdx = Option.fold (WriteLegPool dest) nextFreeIdx xx.LegPool
    let nextFreeIdx = Option.fold (WriteLegDatedDate dest) nextFreeIdx xx.LegDatedDate
    let nextFreeIdx = Option.fold (WriteLegContractSettlMonth dest) nextFreeIdx xx.LegContractSettlMonth
    let nextFreeIdx = Option.fold (WriteLegInterestAccrualDate dest) nextFreeIdx xx.LegInterestAccrualDate
    nextFreeIdx


// group
let WriteNoMsgTypesGrp (dest:byte []) (nextFreeIdx:int) (xx:NoMsgTypesGrp) =
    let nextFreeIdx = WriteRefMsgType dest nextFreeIdx xx.RefMsgType
    let nextFreeIdx = Option.fold (WriteMsgDirection dest) nextFreeIdx xx.MsgDirection
    nextFreeIdx


// group
let WriteNoIOIQualifiersGrp (dest:byte []) (nextFreeIdx:int) (xx:NoIOIQualifiersGrp) =
    let nextFreeIdx = WriteIOIQualifier dest nextFreeIdx xx.IOIQualifier
    nextFreeIdx


// group
let WriteNoRoutingIDsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoRoutingIDsGrp) =
    let nextFreeIdx = WriteRoutingType dest nextFreeIdx xx.RoutingType
    let nextFreeIdx = Option.fold (WriteRoutingID dest) nextFreeIdx xx.RoutingID
    nextFreeIdx


// group
let WriteLinesOfTextGrp (dest:byte []) (nextFreeIdx:int) (xx:LinesOfTextGrp) =
    let nextFreeIdx = WriteText dest nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// group
let WriteNoMDEntryTypesGrp (dest:byte []) (nextFreeIdx:int) (xx:NoMDEntryTypesGrp) =
    let nextFreeIdx = WriteMDEntryType dest nextFreeIdx xx.MDEntryType
    nextFreeIdx


// group
let WriteNoMDEntriesGrp (dest:byte []) (nextFreeIdx:int) (xx:NoMDEntriesGrp) =
    let nextFreeIdx = WriteMDEntryType dest nextFreeIdx xx.MDEntryType
    let nextFreeIdx = Option.fold (WriteMDEntryPx dest) nextFreeIdx xx.MDEntryPx
    let nextFreeIdx = Option.fold (WriteCurrency dest) nextFreeIdx xx.Currency
    let nextFreeIdx = Option.fold (WriteMDEntrySize dest) nextFreeIdx xx.MDEntrySize
    let nextFreeIdx = Option.fold (WriteMDEntryDate dest) nextFreeIdx xx.MDEntryDate
    let nextFreeIdx = Option.fold (WriteMDEntryTime dest) nextFreeIdx xx.MDEntryTime
    let nextFreeIdx = Option.fold (WriteTickDirection dest) nextFreeIdx xx.TickDirection
    let nextFreeIdx = Option.fold (WriteMDMkt dest) nextFreeIdx xx.MDMkt
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteQuoteCondition dest) nextFreeIdx xx.QuoteCondition
    let nextFreeIdx = Option.fold (WriteTradeCondition dest) nextFreeIdx xx.TradeCondition
    let nextFreeIdx = Option.fold (WriteMDEntryOriginator dest) nextFreeIdx xx.MDEntryOriginator
    let nextFreeIdx = Option.fold (WriteLocationID dest) nextFreeIdx xx.LocationID
    let nextFreeIdx = Option.fold (WriteDeskID dest) nextFreeIdx xx.DeskID
    let nextFreeIdx = Option.fold (WriteOpenCloseSettlFlag dest) nextFreeIdx xx.OpenCloseSettlFlag
    let nextFreeIdx = Option.fold (WriteTimeInForce dest) nextFreeIdx xx.TimeInForce
    let nextFreeIdx = Option.fold (WriteExpireDate dest) nextFreeIdx xx.ExpireDate
    let nextFreeIdx = Option.fold (WriteExpireTime dest) nextFreeIdx xx.ExpireTime
    let nextFreeIdx = Option.fold (WriteMinQty dest) nextFreeIdx xx.MinQty
    let nextFreeIdx = Option.fold (WriteExecInst dest) nextFreeIdx xx.ExecInst
    let nextFreeIdx = Option.fold (WriteSellerDays dest) nextFreeIdx xx.SellerDays
    let nextFreeIdx = Option.fold (WriteOrderID dest) nextFreeIdx xx.OrderID
    let nextFreeIdx = Option.fold (WriteQuoteEntryID dest) nextFreeIdx xx.QuoteEntryID
    let nextFreeIdx = Option.fold (WriteMDEntryBuyer dest) nextFreeIdx xx.MDEntryBuyer
    let nextFreeIdx = Option.fold (WriteMDEntrySeller dest) nextFreeIdx xx.MDEntrySeller
    let nextFreeIdx = Option.fold (WriteNumberOfOrders dest) nextFreeIdx xx.NumberOfOrders
    let nextFreeIdx = Option.fold (WriteMDEntryPositionNo dest) nextFreeIdx xx.MDEntryPositionNo
    let nextFreeIdx = Option.fold (WriteScope dest) nextFreeIdx xx.Scope
    let nextFreeIdx = Option.fold (WritePriceDelta dest) nextFreeIdx xx.PriceDelta
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// group
let WriteNoAltMDSourceGrp (dest:byte []) (nextFreeIdx:int) (xx:NoAltMDSourceGrp) =
    let nextFreeIdx = WriteAltMDSourceID dest nextFreeIdx xx.AltMDSourceID
    nextFreeIdx


// group
let WriteNoSecurityTypesGrp (dest:byte []) (nextFreeIdx:int) (xx:NoSecurityTypesGrp) =
    let nextFreeIdx = WriteSecurityType dest nextFreeIdx xx.SecurityType
    let nextFreeIdx = Option.fold (WriteSecuritySubType dest) nextFreeIdx xx.SecuritySubType
    let nextFreeIdx = Option.fold (WriteProduct dest) nextFreeIdx xx.Product
    let nextFreeIdx = Option.fold (WriteCFICode dest) nextFreeIdx xx.CFICode
    nextFreeIdx


// group
let WriteNoContraBrokersGrp (dest:byte []) (nextFreeIdx:int) (xx:NoContraBrokersGrp) =
    let nextFreeIdx = WriteContraBroker dest nextFreeIdx xx.ContraBroker
    let nextFreeIdx = Option.fold (WriteContraTrader dest) nextFreeIdx xx.ContraTrader
    let nextFreeIdx = Option.fold (WriteContraTradeQty dest) nextFreeIdx xx.ContraTradeQty
    let nextFreeIdx = Option.fold (WriteContraTradeTime dest) nextFreeIdx xx.ContraTradeTime
    let nextFreeIdx = Option.fold (WriteContraLegRefID dest) nextFreeIdx xx.ContraLegRefID
    nextFreeIdx


// group
let WriteNoAffectedOrdersGrp (dest:byte []) (nextFreeIdx:int) (xx:NoAffectedOrdersGrp) =
    let nextFreeIdx = WriteOrigClOrdID dest nextFreeIdx xx.OrigClOrdID
    let nextFreeIdx = Option.fold (WriteAffectedOrderID dest) nextFreeIdx xx.AffectedOrderID
    let nextFreeIdx = Option.fold (WriteAffectedSecondaryOrderID dest) nextFreeIdx xx.AffectedSecondaryOrderID
    nextFreeIdx


// group
let WriteNoBidDescriptorsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoBidDescriptorsGrp) =
    let nextFreeIdx = WriteBidDescriptorType dest nextFreeIdx xx.BidDescriptorType
    let nextFreeIdx = Option.fold (WriteBidDescriptor dest) nextFreeIdx xx.BidDescriptor
    let nextFreeIdx = Option.fold (WriteSideValueInd dest) nextFreeIdx xx.SideValueInd
    let nextFreeIdx = Option.fold (WriteLiquidityValue dest) nextFreeIdx xx.LiquidityValue
    let nextFreeIdx = Option.fold (WriteLiquidityNumSecurities dest) nextFreeIdx xx.LiquidityNumSecurities
    let nextFreeIdx = Option.fold (WriteLiquidityPctLow dest) nextFreeIdx xx.LiquidityPctLow
    let nextFreeIdx = Option.fold (WriteLiquidityPctHigh dest) nextFreeIdx xx.LiquidityPctHigh
    let nextFreeIdx = Option.fold (WriteEFPTrackingError dest) nextFreeIdx xx.EFPTrackingError
    let nextFreeIdx = Option.fold (WriteFairValue dest) nextFreeIdx xx.FairValue
    let nextFreeIdx = Option.fold (WriteOutsideIndexPct dest) nextFreeIdx xx.OutsideIndexPct
    let nextFreeIdx = Option.fold (WriteValueOfFutures dest) nextFreeIdx xx.ValueOfFutures
    nextFreeIdx


// group
let WriteNoBidComponentsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoBidComponentsGrp) =
    let nextFreeIdx = WriteListID dest nextFreeIdx xx.ListID
    let nextFreeIdx = Option.fold (WriteSide dest) nextFreeIdx xx.Side
    let nextFreeIdx = Option.fold (WriteTradingSessionID dest) nextFreeIdx xx.TradingSessionID
    let nextFreeIdx = Option.fold (WriteTradingSessionSubID dest) nextFreeIdx xx.TradingSessionSubID
    let nextFreeIdx = Option.fold (WriteNetGrossInd dest) nextFreeIdx xx.NetGrossInd
    let nextFreeIdx = Option.fold (WriteSettlType dest) nextFreeIdx xx.SettlType
    let nextFreeIdx = Option.fold (WriteSettlDate dest) nextFreeIdx xx.SettlDate
    let nextFreeIdx = Option.fold (WriteAccount dest) nextFreeIdx xx.Account
    let nextFreeIdx = Option.fold (WriteAcctIDSource dest) nextFreeIdx xx.AcctIDSource
    nextFreeIdx


// group
let WriteListStatusNoOrdersGrp (dest:byte []) (nextFreeIdx:int) (xx:ListStatusNoOrdersGrp) =
    let nextFreeIdx = WriteClOrdID dest nextFreeIdx xx.ClOrdID
    let nextFreeIdx = Option.fold (WriteSecondaryClOrdID dest) nextFreeIdx xx.SecondaryClOrdID
    let nextFreeIdx = WriteCumQty dest nextFreeIdx xx.CumQty
    let nextFreeIdx = WriteOrdStatus dest nextFreeIdx xx.OrdStatus
    let nextFreeIdx = Option.fold (WriteWorkingIndicator dest) nextFreeIdx xx.WorkingIndicator
    let nextFreeIdx = WriteLeavesQty dest nextFreeIdx xx.LeavesQty
    let nextFreeIdx = WriteCxlQty dest nextFreeIdx xx.CxlQty
    let nextFreeIdx = WriteAvgPx dest nextFreeIdx xx.AvgPx
    let nextFreeIdx = Option.fold (WriteOrdRejReason dest) nextFreeIdx xx.OrdRejReason
    let nextFreeIdx = Option.fold (WriteText dest) nextFreeIdx xx.Text
    let nextFreeIdx = Option.fold (WriteEncodedText dest) nextFreeIdx xx.EncodedText
    nextFreeIdx


// group
let WriteAllocationInstructionNoExecsGrp (dest:byte []) (nextFreeIdx:int) (xx:AllocationInstructionNoExecsGrp) =
    let nextFreeIdx = WriteLastQty dest nextFreeIdx xx.LastQty
    let nextFreeIdx = Option.fold (WriteExecID dest) nextFreeIdx xx.ExecID
    let nextFreeIdx = Option.fold (WriteSecondaryExecID dest) nextFreeIdx xx.SecondaryExecID
    let nextFreeIdx = Option.fold (WriteLastPx dest) nextFreeIdx xx.LastPx
    let nextFreeIdx = Option.fold (WriteLastParPx dest) nextFreeIdx xx.LastParPx
    let nextFreeIdx = Option.fold (WriteLastCapacity dest) nextFreeIdx xx.LastCapacity
    nextFreeIdx


// group
let WriteAllocationInstructionAckNoAllocsGrp (dest:byte []) (nextFreeIdx:int) (xx:AllocationInstructionAckNoAllocsGrp) =
    let nextFreeIdx = WriteAllocAccount dest nextFreeIdx xx.AllocAccount
    let nextFreeIdx = Option.fold (WriteAllocAcctIDSource dest) nextFreeIdx xx.AllocAcctIDSource
    let nextFreeIdx = Option.fold (WriteAllocPrice dest) nextFreeIdx xx.AllocPrice
    let nextFreeIdx = Option.fold (WriteIndividualAllocID dest) nextFreeIdx xx.IndividualAllocID
    let nextFreeIdx = Option.fold (WriteIndividualAllocRejCode dest) nextFreeIdx xx.IndividualAllocRejCode
    let nextFreeIdx = Option.fold (WriteAllocText dest) nextFreeIdx xx.AllocText
    let nextFreeIdx = Option.fold (WriteEncodedAllocText dest) nextFreeIdx xx.EncodedAllocText
    nextFreeIdx


// group
let WriteAllocationReportNoExecsGrp (dest:byte []) (nextFreeIdx:int) (xx:AllocationReportNoExecsGrp) =
    let nextFreeIdx = WriteLastQty dest nextFreeIdx xx.LastQty
    let nextFreeIdx = Option.fold (WriteExecID dest) nextFreeIdx xx.ExecID
    let nextFreeIdx = Option.fold (WriteSecondaryExecID dest) nextFreeIdx xx.SecondaryExecID
    let nextFreeIdx = Option.fold (WriteLastPx dest) nextFreeIdx xx.LastPx
    let nextFreeIdx = Option.fold (WriteLastParPx dest) nextFreeIdx xx.LastParPx
    let nextFreeIdx = Option.fold (WriteLastCapacity dest) nextFreeIdx xx.LastCapacity
    nextFreeIdx


// group
let WriteAllocationReportAckNoAllocsGrp (dest:byte []) (nextFreeIdx:int) (xx:AllocationReportAckNoAllocsGrp) =
    let nextFreeIdx = WriteAllocAccount dest nextFreeIdx xx.AllocAccount
    let nextFreeIdx = Option.fold (WriteAllocAcctIDSource dest) nextFreeIdx xx.AllocAcctIDSource
    let nextFreeIdx = Option.fold (WriteAllocPrice dest) nextFreeIdx xx.AllocPrice
    let nextFreeIdx = Option.fold (WriteIndividualAllocID dest) nextFreeIdx xx.IndividualAllocID
    let nextFreeIdx = Option.fold (WriteIndividualAllocRejCode dest) nextFreeIdx xx.IndividualAllocRejCode
    let nextFreeIdx = Option.fold (WriteAllocText dest) nextFreeIdx xx.AllocText
    let nextFreeIdx = Option.fold (WriteEncodedAllocText dest) nextFreeIdx xx.EncodedAllocText
    nextFreeIdx


// group
let WriteNoCapacitiesGrp (dest:byte []) (nextFreeIdx:int) (xx:NoCapacitiesGrp) =
    let nextFreeIdx = WriteOrderCapacity dest nextFreeIdx xx.OrderCapacity
    let nextFreeIdx = Option.fold (WriteOrderRestrictions dest) nextFreeIdx xx.OrderRestrictions
    let nextFreeIdx = WriteOrderCapacityQty dest nextFreeIdx xx.OrderCapacityQty
    nextFreeIdx


// group
let WriteNoDatesGrp (dest:byte []) (nextFreeIdx:int) (xx:NoDatesGrp) =
    let nextFreeIdx = WriteTradeDate dest nextFreeIdx xx.TradeDate
    let nextFreeIdx = Option.fold (WriteTransactTime dest) nextFreeIdx xx.TransactTime
    nextFreeIdx


// group
let WriteNoDistribInstsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoDistribInstsGrp) =
    let nextFreeIdx = WriteDistribPaymentMethod dest nextFreeIdx xx.DistribPaymentMethod
    let nextFreeIdx = Option.fold (WriteDistribPercentage dest) nextFreeIdx xx.DistribPercentage
    let nextFreeIdx = Option.fold (WriteCashDistribCurr dest) nextFreeIdx xx.CashDistribCurr
    let nextFreeIdx = Option.fold (WriteCashDistribAgentName dest) nextFreeIdx xx.CashDistribAgentName
    let nextFreeIdx = Option.fold (WriteCashDistribAgentCode dest) nextFreeIdx xx.CashDistribAgentCode
    let nextFreeIdx = Option.fold (WriteCashDistribAgentAcctNumber dest) nextFreeIdx xx.CashDistribAgentAcctNumber
    let nextFreeIdx = Option.fold (WriteCashDistribPayRef dest) nextFreeIdx xx.CashDistribPayRef
    let nextFreeIdx = Option.fold (WriteCashDistribAgentAcctName dest) nextFreeIdx xx.CashDistribAgentAcctName
    nextFreeIdx


// group
let WriteNoExecsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoExecsGrp) =
    let nextFreeIdx = WriteExecID dest nextFreeIdx xx.ExecID
    nextFreeIdx


// group
let WriteNoTradesGrp (dest:byte []) (nextFreeIdx:int) (xx:NoTradesGrp) =
    let nextFreeIdx = WriteTradeReportID dest nextFreeIdx xx.TradeReportID
    let nextFreeIdx = Option.fold (WriteSecondaryTradeReportID dest) nextFreeIdx xx.SecondaryTradeReportID
    nextFreeIdx


// group
let WriteNoCollInquiryQualifierGrp (dest:byte []) (nextFreeIdx:int) (xx:NoCollInquiryQualifierGrp) =
    let nextFreeIdx = WriteCollInquiryQualifier dest nextFreeIdx xx.CollInquiryQualifier
    nextFreeIdx


// group
let WriteNoCompIDsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoCompIDsGrp) =
    let nextFreeIdx = WriteRefCompID dest nextFreeIdx xx.RefCompID
    let nextFreeIdx = Option.fold (WriteRefSubID dest) nextFreeIdx xx.RefSubID
    let nextFreeIdx = Option.fold (WriteLocationID dest) nextFreeIdx xx.LocationID
    let nextFreeIdx = Option.fold (WriteDeskID dest) nextFreeIdx xx.DeskID
    nextFreeIdx


// group
let WriteNetworkStatusResponseNoCompIDsGrp (dest:byte []) (nextFreeIdx:int) (xx:NetworkStatusResponseNoCompIDsGrp) =
    let nextFreeIdx = WriteRefCompID dest nextFreeIdx xx.RefCompID
    let nextFreeIdx = Option.fold (WriteRefSubID dest) nextFreeIdx xx.RefSubID
    let nextFreeIdx = Option.fold (WriteLocationID dest) nextFreeIdx xx.LocationID
    let nextFreeIdx = Option.fold (WriteDeskID dest) nextFreeIdx xx.DeskID
    let nextFreeIdx = Option.fold (WriteStatusValue dest) nextFreeIdx xx.StatusValue
    let nextFreeIdx = Option.fold (WriteStatusText dest) nextFreeIdx xx.StatusText
    nextFreeIdx


// group
let WriteNoHopsGrp (dest:byte []) (nextFreeIdx:int) (xx:NoHopsGrp) =
    let nextFreeIdx = WriteHopCompID dest nextFreeIdx xx.HopCompID
    let nextFreeIdx = Option.fold (WriteHopSendingTime dest) nextFreeIdx xx.HopSendingTime
    let nextFreeIdx = Option.fold (WriteHopRefID dest) nextFreeIdx xx.HopRefID
    nextFreeIdx

