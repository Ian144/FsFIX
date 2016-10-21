module Fix44.CompoundItemWriteFuncs

open Fix44.Fields
open Fix44.FieldReadWriteFuncs
open Fix44.CompoundItems


// group
let WriteNoUnderlyingSecurityAltIDGrp (strm:System.IO.Stream) (xx:NoUnderlyingSecurityAltIDGrp) =
    xx.UnderlyingSecurityAltID |> Option.iter (WriteUnderlyingSecurityAltID strm)
    xx.UnderlyingSecurityAltIDSource |> Option.iter (WriteUnderlyingSecurityAltIDSource strm)


// group
let WriteNoUnderlyingStipsGrp (strm:System.IO.Stream) (xx:NoUnderlyingStipsGrp) =
    xx.UnderlyingStipType |> Option.iter (WriteUnderlyingStipType strm)
    xx.UnderlyingStipValue |> Option.iter (WriteUnderlyingStipValue strm)


// component
let WriteUnderlyingStipulations (strm:System.IO.Stream) (xx:UnderlyingStipulations) =
    xx.NoUnderlyingStipsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyingStips strm (Fix44.Fields.NoUnderlyingStips numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingStipsGrp strm gg)    ) // end Option.iter


// component
let WriteUnderlyingInstrument (strm:System.IO.Stream) (xx:UnderlyingInstrument) =
    WriteUnderlyingSymbol strm xx.UnderlyingSymbol
    xx.UnderlyingSymbolSfx |> Option.iter (WriteUnderlyingSymbolSfx strm)
    xx.UnderlyingSecurityID |> Option.iter (WriteUnderlyingSecurityID strm)
    xx.UnderlyingSecurityIDSource |> Option.iter (WriteUnderlyingSecurityIDSource strm)
    xx.NoUnderlyingSecurityAltIDGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyingSecurityAltID strm (Fix44.Fields.NoUnderlyingSecurityAltID numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingSecurityAltIDGrp strm gg)    ) // end Option.iter
    xx.UnderlyingProduct |> Option.iter (WriteUnderlyingProduct strm)
    xx.UnderlyingCFICode |> Option.iter (WriteUnderlyingCFICode strm)
    xx.UnderlyingSecurityType |> Option.iter (WriteUnderlyingSecurityType strm)
    xx.UnderlyingSecuritySubType |> Option.iter (WriteUnderlyingSecuritySubType strm)
    xx.UnderlyingMaturityMonthYear |> Option.iter (WriteUnderlyingMaturityMonthYear strm)
    xx.UnderlyingMaturityDate |> Option.iter (WriteUnderlyingMaturityDate strm)
    xx.UnderlyingPutOrCall |> Option.iter (WriteUnderlyingPutOrCall strm)
    xx.UnderlyingCouponPaymentDate |> Option.iter (WriteUnderlyingCouponPaymentDate strm)
    xx.UnderlyingIssueDate |> Option.iter (WriteUnderlyingIssueDate strm)
    xx.UnderlyingRepoCollateralSecurityType |> Option.iter (WriteUnderlyingRepoCollateralSecurityType strm)
    xx.UnderlyingRepurchaseTerm |> Option.iter (WriteUnderlyingRepurchaseTerm strm)
    xx.UnderlyingRepurchaseRate |> Option.iter (WriteUnderlyingRepurchaseRate strm)
    xx.UnderlyingFactor |> Option.iter (WriteUnderlyingFactor strm)
    xx.UnderlyingCreditRating |> Option.iter (WriteUnderlyingCreditRating strm)
    xx.UnderlyingInstrRegistry |> Option.iter (WriteUnderlyingInstrRegistry strm)
    xx.UnderlyingCountryOfIssue |> Option.iter (WriteUnderlyingCountryOfIssue strm)
    xx.UnderlyingStateOrProvinceOfIssue |> Option.iter (WriteUnderlyingStateOrProvinceOfIssue strm)
    xx.UnderlyingLocaleOfIssue |> Option.iter (WriteUnderlyingLocaleOfIssue strm)
    xx.UnderlyingRedemptionDate |> Option.iter (WriteUnderlyingRedemptionDate strm)
    xx.UnderlyingStrikePrice |> Option.iter (WriteUnderlyingStrikePrice strm)
    xx.UnderlyingStrikeCurrency |> Option.iter (WriteUnderlyingStrikeCurrency strm)
    xx.UnderlyingOptAttribute |> Option.iter (WriteUnderlyingOptAttribute strm)
    xx.UnderlyingContractMultiplier |> Option.iter (WriteUnderlyingContractMultiplier strm)
    xx.UnderlyingCouponRate |> Option.iter (WriteUnderlyingCouponRate strm)
    xx.UnderlyingSecurityExchange |> Option.iter (WriteUnderlyingSecurityExchange strm)
    xx.UnderlyingIssuer |> Option.iter (WriteUnderlyingIssuer strm)
    xx.EncodedUnderlyingIssuer |> Option.iter (WriteEncodedUnderlyingIssuer strm)
    xx.UnderlyingSecurityDesc |> Option.iter (WriteUnderlyingSecurityDesc strm)
    xx.EncodedUnderlyingSecurityDesc |> Option.iter (WriteEncodedUnderlyingSecurityDesc strm)
    xx.UnderlyingCPProgram |> Option.iter (WriteUnderlyingCPProgram strm)
    xx.UnderlyingCPRegType |> Option.iter (WriteUnderlyingCPRegType strm)
    xx.UnderlyingCurrency |> Option.iter (WriteUnderlyingCurrency strm)
    xx.UnderlyingQty |> Option.iter (WriteUnderlyingQty strm)
    xx.UnderlyingPx |> Option.iter (WriteUnderlyingPx strm)
    xx.UnderlyingDirtyPrice |> Option.iter (WriteUnderlyingDirtyPrice strm)
    xx.UnderlyingEndPrice |> Option.iter (WriteUnderlyingEndPrice strm)
    xx.UnderlyingStartValue |> Option.iter (WriteUnderlyingStartValue strm)
    xx.UnderlyingCurrentValue |> Option.iter (WriteUnderlyingCurrentValue strm)
    xx.UnderlyingEndValue |> Option.iter (WriteUnderlyingEndValue strm)
    xx.UnderlyingStipulations |> Option.iter (WriteUnderlyingStipulations strm) // component


// group
let WriteCollateralResponse_NoUnderlyingsGrp (strm:System.IO.Stream) (xx:CollateralResponse_NoUnderlyingsGrp) =
    xx.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    xx.CollAction |> Option.iter (WriteCollAction strm)


// group
let WriteCollateralAssignment_NoUnderlyingsGrp (strm:System.IO.Stream) (xx:CollateralAssignment_NoUnderlyingsGrp) =
    xx.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    xx.CollAction |> Option.iter (WriteCollAction strm)


// group
let WriteCollateralRequest_NoUnderlyingsGrp (strm:System.IO.Stream) (xx:CollateralRequest_NoUnderlyingsGrp) =
    xx.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    xx.CollAction |> Option.iter (WriteCollAction strm)


// group
let WritePositionReport_NoUnderlyingsGrp (strm:System.IO.Stream) (xx:PositionReport_NoUnderlyingsGrp) =
    xx.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    WriteUnderlyingSettlPrice strm xx.UnderlyingSettlPrice
    WriteUnderlyingSettlPriceType strm xx.UnderlyingSettlPriceType


// group
let WriteNoNestedPartySubIDsGrp (strm:System.IO.Stream) (xx:NoNestedPartySubIDsGrp) =
    xx.NestedPartySubID |> Option.iter (WriteNestedPartySubID strm)
    xx.NestedPartySubIDType |> Option.iter (WriteNestedPartySubIDType strm)


// group
let WriteNoNestedPartyIDsGrp (strm:System.IO.Stream) (xx:NoNestedPartyIDsGrp) =
    xx.NestedPartyID |> Option.iter (WriteNestedPartyID strm)
    xx.NestedPartyIDSource |> Option.iter (WriteNestedPartyIDSource strm)
    xx.NestedPartyRole |> Option.iter (WriteNestedPartyRole strm)
    xx.NoNestedPartySubIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoNestedPartySubIDs strm (Fix44.Fields.NoNestedPartySubIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoNestedPartySubIDsGrp strm gg)    ) // end Option.iter


// component
let WriteNestedParties (strm:System.IO.Stream) (xx:NestedParties) =
    xx.NoNestedPartyIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoNestedPartyIDs strm (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoNestedPartyIDsGrp strm gg)    ) // end Option.iter


// group
let WriteNoPositionsGrp (strm:System.IO.Stream) (xx:NoPositionsGrp) =
    xx.PosType |> Option.iter (WritePosType strm)
    xx.LongQty |> Option.iter (WriteLongQty strm)
    xx.ShortQty |> Option.iter (WriteShortQty strm)
    xx.PosQtyStatus |> Option.iter (WritePosQtyStatus strm)
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component


// component
let WritePositionQty (strm:System.IO.Stream) (xx:PositionQty) =
    let numGrps = xx.NoPositionsGrp.Length
    WriteNoPositions strm (Fix44.Fields.NoPositions numGrps) // write the 'num group repeats' field
    xx.NoPositionsGrp |> List.iter (fun gg -> WriteNoPositionsGrp strm gg)


// group
let WriteNoRegistDtlsGrp (strm:System.IO.Stream) (xx:NoRegistDtlsGrp) =
    xx.RegistDtls |> Option.iter (WriteRegistDtls strm)
    xx.RegistEmail |> Option.iter (WriteRegistEmail strm)
    xx.MailingDtls |> Option.iter (WriteMailingDtls strm)
    xx.MailingInst |> Option.iter (WriteMailingInst strm)
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component
    xx.OwnerType |> Option.iter (WriteOwnerType strm)
    xx.DateOfBirth |> Option.iter (WriteDateOfBirth strm)
    xx.InvestorCountryOfResidence |> Option.iter (WriteInvestorCountryOfResidence strm)


// group
let WriteNoNested2PartySubIDsGrp (strm:System.IO.Stream) (xx:NoNested2PartySubIDsGrp) =
    xx.Nested2PartySubID |> Option.iter (WriteNested2PartySubID strm)
    xx.Nested2PartySubIDType |> Option.iter (WriteNested2PartySubIDType strm)


// group
let WriteNoNested2PartyIDsGrp (strm:System.IO.Stream) (xx:NoNested2PartyIDsGrp) =
    xx.Nested2PartyID |> Option.iter (WriteNested2PartyID strm)
    xx.Nested2PartyIDSource |> Option.iter (WriteNested2PartyIDSource strm)
    xx.Nested2PartyRole |> Option.iter (WriteNested2PartyRole strm)
    xx.NoNested2PartySubIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoNested2PartySubIDs strm (Fix44.Fields.NoNested2PartySubIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoNested2PartySubIDsGrp strm gg)    ) // end Option.iter


// component
let WriteNestedParties2 (strm:System.IO.Stream) (xx:NestedParties2) =
    xx.NoNested2PartyIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoNested2PartyIDs strm (Fix44.Fields.NoNested2PartyIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoNested2PartyIDsGrp strm gg)    ) // end Option.iter


// group
let WriteTradeCaptureReportAck_NoAllocsGrp (strm:System.IO.Stream) (xx:TradeCaptureReportAck_NoAllocsGrp) =
    xx.AllocAccount |> Option.iter (WriteAllocAccount strm)
    xx.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    xx.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    xx.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    xx.NestedParties2 |> Option.iter (WriteNestedParties2 strm) // component
    xx.AllocQty |> Option.iter (WriteAllocQty strm)


// group
let WriteNoLegSecurityAltIDGrp (strm:System.IO.Stream) (xx:NoLegSecurityAltIDGrp) =
    xx.LegSecurityAltID |> Option.iter (WriteLegSecurityAltID strm)
    xx.LegSecurityAltIDSource |> Option.iter (WriteLegSecurityAltIDSource strm)


// component
let WriteInstrumentLeg (strm:System.IO.Stream) (xx:InstrumentLeg) =
    xx.LegSymbol |> Option.iter (WriteLegSymbol strm)
    xx.LegSymbolSfx |> Option.iter (WriteLegSymbolSfx strm)
    xx.LegSecurityID |> Option.iter (WriteLegSecurityID strm)
    xx.LegSecurityIDSource |> Option.iter (WriteLegSecurityIDSource strm)
    xx.NoLegSecurityAltIDGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegSecurityAltID strm (Fix44.Fields.NoLegSecurityAltID numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegSecurityAltIDGrp strm gg)    ) // end Option.iter
    xx.LegProduct |> Option.iter (WriteLegProduct strm)
    xx.LegCFICode |> Option.iter (WriteLegCFICode strm)
    xx.LegSecurityType |> Option.iter (WriteLegSecurityType strm)
    xx.LegSecuritySubType |> Option.iter (WriteLegSecuritySubType strm)
    xx.LegMaturityMonthYear |> Option.iter (WriteLegMaturityMonthYear strm)
    xx.LegMaturityDate |> Option.iter (WriteLegMaturityDate strm)
    xx.LegCouponPaymentDate |> Option.iter (WriteLegCouponPaymentDate strm)
    xx.LegIssueDate |> Option.iter (WriteLegIssueDate strm)
    xx.LegRepoCollateralSecurityType |> Option.iter (WriteLegRepoCollateralSecurityType strm)
    xx.LegRepurchaseTerm |> Option.iter (WriteLegRepurchaseTerm strm)
    xx.LegRepurchaseRate |> Option.iter (WriteLegRepurchaseRate strm)
    xx.LegFactor |> Option.iter (WriteLegFactor strm)
    xx.LegCreditRating |> Option.iter (WriteLegCreditRating strm)
    xx.LegInstrRegistry |> Option.iter (WriteLegInstrRegistry strm)
    xx.LegCountryOfIssue |> Option.iter (WriteLegCountryOfIssue strm)
    xx.LegStateOrProvinceOfIssue |> Option.iter (WriteLegStateOrProvinceOfIssue strm)
    xx.LegLocaleOfIssue |> Option.iter (WriteLegLocaleOfIssue strm)
    xx.LegRedemptionDate |> Option.iter (WriteLegRedemptionDate strm)
    xx.LegStrikePrice |> Option.iter (WriteLegStrikePrice strm)
    xx.LegStrikeCurrency |> Option.iter (WriteLegStrikeCurrency strm)
    xx.LegOptAttribute |> Option.iter (WriteLegOptAttribute strm)
    xx.LegContractMultiplier |> Option.iter (WriteLegContractMultiplier strm)
    xx.LegCouponRate |> Option.iter (WriteLegCouponRate strm)
    xx.LegSecurityExchange |> Option.iter (WriteLegSecurityExchange strm)
    xx.LegIssuer |> Option.iter (WriteLegIssuer strm)
    xx.EncodedLegIssuer |> Option.iter (WriteEncodedLegIssuer strm)
    xx.LegSecurityDesc |> Option.iter (WriteLegSecurityDesc strm)
    xx.EncodedLegSecurityDesc |> Option.iter (WriteEncodedLegSecurityDesc strm)
    xx.LegRatioQty |> Option.iter (WriteLegRatioQty strm)
    xx.LegSide |> Option.iter (WriteLegSide strm)
    xx.LegCurrency |> Option.iter (WriteLegCurrency strm)
    xx.LegPool |> Option.iter (WriteLegPool strm)
    xx.LegDatedDate |> Option.iter (WriteLegDatedDate strm)
    xx.LegContractSettlMonth |> Option.iter (WriteLegContractSettlMonth strm)
    xx.LegInterestAccrualDate |> Option.iter (WriteLegInterestAccrualDate strm)


// group
let WriteNoLegStipulationsGrp (strm:System.IO.Stream) (xx:NoLegStipulationsGrp) =
    xx.LegStipulationType |> Option.iter (WriteLegStipulationType strm)
    xx.LegStipulationValue |> Option.iter (WriteLegStipulationValue strm)


// component
let WriteLegStipulations (strm:System.IO.Stream) (xx:LegStipulations) =
    xx.NoLegStipulationsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegStipulations strm (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegStipulationsGrp strm gg)    ) // end Option.iter


// group
let WriteTradeCaptureReportAck_NoLegsGrp (strm:System.IO.Stream) (xx:TradeCaptureReportAck_NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.LegQty |> Option.iter (WriteLegQty strm)
    xx.LegSwapType |> Option.iter (WriteLegSwapType strm)
    xx.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    xx.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    xx.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component
    xx.LegRefID |> Option.iter (WriteLegRefID strm)
    xx.LegPrice |> Option.iter (WriteLegPrice strm)
    xx.LegSettlType |> Option.iter (WriteLegSettlType strm)
    xx.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    xx.LegLastPx |> Option.iter (WriteLegLastPx strm)


// group
let WriteNoPartySubIDsGrp (strm:System.IO.Stream) (xx:NoPartySubIDsGrp) =
    xx.PartySubID |> Option.iter (WritePartySubID strm)
    xx.PartySubIDType |> Option.iter (WritePartySubIDType strm)


// group
let WriteNoPartyIDsGrp (strm:System.IO.Stream) (xx:NoPartyIDsGrp) =
    xx.PartyID |> Option.iter (WritePartyID strm)
    xx.PartyIDSource |> Option.iter (WritePartyIDSource strm)
    xx.PartyRole |> Option.iter (WritePartyRole strm)
    xx.NoPartySubIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoPartySubIDs strm (Fix44.Fields.NoPartySubIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoPartySubIDsGrp strm gg)    ) // end Option.iter


// component
let WriteParties (strm:System.IO.Stream) (xx:Parties) =
    xx.NoPartyIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoPartyIDs strm (Fix44.Fields.NoPartyIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoPartyIDsGrp strm gg)    ) // end Option.iter


// group
let WriteNoClearingInstructionsGrp (strm:System.IO.Stream) (xx:NoClearingInstructionsGrp) =
    xx.ClearingInstruction |> Option.iter (WriteClearingInstruction strm)


// component
let WriteCommissionData (strm:System.IO.Stream) (xx:CommissionData) =
    xx.Commission |> Option.iter (WriteCommission strm)
    xx.CommType |> Option.iter (WriteCommType strm)
    xx.CommCurrency |> Option.iter (WriteCommCurrency strm)
    xx.FundRenewWaiv |> Option.iter (WriteFundRenewWaiv strm)


// group
let WriteNoContAmtsGrp (strm:System.IO.Stream) (xx:NoContAmtsGrp) =
    xx.ContAmtType |> Option.iter (WriteContAmtType strm)
    xx.ContAmtValue |> Option.iter (WriteContAmtValue strm)
    xx.ContAmtCurr |> Option.iter (WriteContAmtCurr strm)


// group
let WriteNoStipulationsGrp (strm:System.IO.Stream) (xx:NoStipulationsGrp) =
    xx.StipulationType |> Option.iter (WriteStipulationType strm)
    xx.StipulationValue |> Option.iter (WriteStipulationValue strm)


// component
let WriteStipulations (strm:System.IO.Stream) (xx:Stipulations) =
    xx.NoStipulationsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoStipulations strm (Fix44.Fields.NoStipulations numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoStipulationsGrp strm gg)    ) // end Option.iter


// group
let WriteNoMiscFeesGrp (strm:System.IO.Stream) (xx:NoMiscFeesGrp) =
    xx.MiscFeeAmt |> Option.iter (WriteMiscFeeAmt strm)
    xx.MiscFeeCurr |> Option.iter (WriteMiscFeeCurr strm)
    xx.MiscFeeType |> Option.iter (WriteMiscFeeType strm)
    xx.MiscFeeBasis |> Option.iter (WriteMiscFeeBasis strm)


// group
let WriteTradeCaptureReport_NoSidesGrp (strm:System.IO.Stream) (xx:TradeCaptureReport_NoSidesGrp) =
    WriteSide strm xx.Side
    WriteOrderID strm xx.OrderID
    xx.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.ListID |> Option.iter (WriteListID strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.ProcessCode |> Option.iter (WriteProcessCode strm)
    xx.OddLot |> Option.iter (WriteOddLot strm)
    xx.NoClearingInstructionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoClearingInstructions strm (Fix44.Fields.NoClearingInstructions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoClearingInstructionsGrp strm gg)    ) // end Option.iter
    xx.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    xx.TradeInputSource |> Option.iter (WriteTradeInputSource strm)
    xx.TradeInputDevice |> Option.iter (WriteTradeInputDevice strm)
    xx.OrderInputDevice |> Option.iter (WriteOrderInputDevice strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.ComplianceID |> Option.iter (WriteComplianceID strm)
    xx.SolicitedFlag |> Option.iter (WriteSolicitedFlag strm)
    xx.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    xx.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    xx.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    xx.OrdType |> Option.iter (WriteOrdType strm)
    xx.ExecInst |> Option.iter (WriteExecInst strm)
    xx.TransBkdTime |> Option.iter (WriteTransBkdTime strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.TimeBracket |> Option.iter (WriteTimeBracket strm)
    xx.CommissionData |> Option.iter (WriteCommissionData strm) // component
    xx.GrossTradeAmt |> Option.iter (WriteGrossTradeAmt strm)
    xx.NumDaysInterest |> Option.iter (WriteNumDaysInterest strm)
    xx.ExDate |> Option.iter (WriteExDate strm)
    xx.AccruedInterestRate |> Option.iter (WriteAccruedInterestRate strm)
    xx.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    xx.InterestAtMaturity |> Option.iter (WriteInterestAtMaturity strm)
    xx.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    xx.StartCash |> Option.iter (WriteStartCash strm)
    xx.EndCash |> Option.iter (WriteEndCash strm)
    xx.Concession |> Option.iter (WriteConcession strm)
    xx.TotalTakedown |> Option.iter (WriteTotalTakedown strm)
    xx.NetMoney |> Option.iter (WriteNetMoney strm)
    xx.SettlCurrAmt |> Option.iter (WriteSettlCurrAmt strm)
    xx.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    xx.SettlCurrFxRate |> Option.iter (WriteSettlCurrFxRate strm)
    xx.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    xx.PositionEffect |> Option.iter (WritePositionEffect strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.SideMultiLegReportingType |> Option.iter (WriteSideMultiLegReportingType strm)
    xx.NoContAmtsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoContAmts strm (Fix44.Fields.NoContAmts numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoContAmtsGrp strm gg)    ) // end Option.iter
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    xx.ExchangeRule |> Option.iter (WriteExchangeRule strm)
    xx.TradeAllocIndicator |> Option.iter (WriteTradeAllocIndicator strm)
    xx.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    xx.AllocID |> Option.iter (WriteAllocID strm)


// group
let WriteTradeCaptureReport_NoLegsGrp (strm:System.IO.Stream) (xx:TradeCaptureReport_NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.LegQty |> Option.iter (WriteLegQty strm)
    xx.LegSwapType |> Option.iter (WriteLegSwapType strm)
    xx.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    xx.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    xx.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component
    xx.LegRefID |> Option.iter (WriteLegRefID strm)
    xx.LegPrice |> Option.iter (WriteLegPrice strm)
    xx.LegSettlType |> Option.iter (WriteLegSettlType strm)
    xx.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    xx.LegLastPx |> Option.iter (WriteLegLastPx strm)


// group
let WriteNoPosAmtGrp (strm:System.IO.Stream) (xx:NoPosAmtGrp) =
    WritePosAmtType strm xx.PosAmtType
    WritePosAmt strm xx.PosAmt


// component
let WritePositionAmountData (strm:System.IO.Stream) (xx:PositionAmountData) =
    let numGrps = xx.NoPosAmtGrp.Length
    WriteNoPosAmt strm (Fix44.Fields.NoPosAmt numGrps) // write the 'num group repeats' field
    xx.NoPosAmtGrp |> List.iter (fun gg -> WriteNoPosAmtGrp strm gg)


// group
let WriteNoSettlPartySubIDsGrp (strm:System.IO.Stream) (xx:NoSettlPartySubIDsGrp) =
    xx.SettlPartySubID |> Option.iter (WriteSettlPartySubID strm)
    xx.SettlPartySubIDType |> Option.iter (WriteSettlPartySubIDType strm)


// group
let WriteNoSettlPartyIDsGrp (strm:System.IO.Stream) (xx:NoSettlPartyIDsGrp) =
    xx.SettlPartyID |> Option.iter (WriteSettlPartyID strm)
    xx.SettlPartyIDSource |> Option.iter (WriteSettlPartyIDSource strm)
    xx.SettlPartyRole |> Option.iter (WriteSettlPartyRole strm)
    xx.NoSettlPartySubIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoSettlPartySubIDs strm (Fix44.Fields.NoSettlPartySubIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoSettlPartySubIDsGrp strm gg)    ) // end Option.iter


// component
let WriteSettlParties (strm:System.IO.Stream) (xx:SettlParties) =
    xx.NoSettlPartyIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoSettlPartyIDs strm (Fix44.Fields.NoSettlPartyIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoSettlPartyIDsGrp strm gg)    ) // end Option.iter


// group
let WriteNoDlvyInstGrp (strm:System.IO.Stream) (xx:NoDlvyInstGrp) =
    xx.SettlInstSource |> Option.iter (WriteSettlInstSource strm)
    xx.DlvyInstType |> Option.iter (WriteDlvyInstType strm)
    xx.SettlParties |> Option.iter (WriteSettlParties strm) // component


// component
let WriteSettlInstructionsData (strm:System.IO.Stream) (xx:SettlInstructionsData) =
    xx.SettlDeliveryType |> Option.iter (WriteSettlDeliveryType strm)
    xx.StandInstDbType |> Option.iter (WriteStandInstDbType strm)
    xx.StandInstDbName |> Option.iter (WriteStandInstDbName strm)
    xx.StandInstDbID |> Option.iter (WriteStandInstDbID strm)
    xx.NoDlvyInstGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoDlvyInst strm (Fix44.Fields.NoDlvyInst numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoDlvyInstGrp strm gg)    ) // end Option.iter


// group
let WriteNoSettlInstGrp (strm:System.IO.Stream) (xx:NoSettlInstGrp) =
    xx.SettlInstID |> Option.iter (WriteSettlInstID strm)
    xx.SettlInstTransType |> Option.iter (WriteSettlInstTransType strm)
    xx.SettlInstRefID |> Option.iter (WriteSettlInstRefID strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Side |> Option.iter (WriteSide strm)
    xx.Product |> Option.iter (WriteProduct strm)
    xx.SecurityType |> Option.iter (WriteSecurityType strm)
    xx.CFICode |> Option.iter (WriteCFICode strm)
    xx.EffectiveTime |> Option.iter (WriteEffectiveTime strm)
    xx.ExpireTime |> Option.iter (WriteExpireTime strm)
    xx.LastUpdateTime |> Option.iter (WriteLastUpdateTime strm)
    xx.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component
    xx.PaymentMethod |> Option.iter (WritePaymentMethod strm)
    xx.PaymentRef |> Option.iter (WritePaymentRef strm)
    xx.CardHolderName |> Option.iter (WriteCardHolderName strm)
    xx.CardNumber |> Option.iter (WriteCardNumber strm)
    xx.CardStartDate |> Option.iter (WriteCardStartDate strm)
    xx.CardExpDate |> Option.iter (WriteCardExpDate strm)
    xx.CardIssNum |> Option.iter (WriteCardIssNum strm)
    xx.PaymentDate |> Option.iter (WritePaymentDate strm)
    xx.PaymentRemitterID |> Option.iter (WritePaymentRemitterID strm)


// group
let WriteNoTrdRegTimestampsGrp (strm:System.IO.Stream) (xx:NoTrdRegTimestampsGrp) =
    xx.TrdRegTimestamp |> Option.iter (WriteTrdRegTimestamp strm)
    xx.TrdRegTimestampType |> Option.iter (WriteTrdRegTimestampType strm)
    xx.TrdRegTimestampOrigin |> Option.iter (WriteTrdRegTimestampOrigin strm)


// component
let WriteTrdRegTimestamps (strm:System.IO.Stream) (xx:TrdRegTimestamps) =
    let numGrps = xx.NoTrdRegTimestampsGrp.Length
    WriteNoTrdRegTimestamps strm (Fix44.Fields.NoTrdRegTimestamps numGrps) // write the 'num group repeats' field
    xx.NoTrdRegTimestampsGrp |> List.iter (fun gg -> WriteNoTrdRegTimestampsGrp strm gg)


// group
let WriteAllocationReport_NoAllocsGrp (strm:System.IO.Stream) (xx:AllocationReport_NoAllocsGrp) =
    WriteAllocAccount strm xx.AllocAccount
    xx.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    xx.MatchStatus |> Option.iter (WriteMatchStatus strm)
    xx.AllocPrice |> Option.iter (WriteAllocPrice strm)
    WriteAllocQty strm xx.AllocQty
    xx.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    xx.ProcessCode |> Option.iter (WriteProcessCode strm)
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component
    xx.NotifyBrokerOfCredit |> Option.iter (WriteNotifyBrokerOfCredit strm)
    xx.AllocHandlInst |> Option.iter (WriteAllocHandlInst strm)
    xx.AllocText |> Option.iter (WriteAllocText strm)
    xx.EncodedAllocText |> Option.iter (WriteEncodedAllocText strm)
    xx.CommissionData |> Option.iter (WriteCommissionData strm) // component
    xx.AllocAvgPx |> Option.iter (WriteAllocAvgPx strm)
    xx.AllocNetMoney |> Option.iter (WriteAllocNetMoney strm)
    xx.SettlCurrAmt |> Option.iter (WriteSettlCurrAmt strm)
    xx.AllocSettlCurrAmt |> Option.iter (WriteAllocSettlCurrAmt strm)
    xx.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    xx.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    xx.SettlCurrFxRate |> Option.iter (WriteSettlCurrFxRate strm)
    xx.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    xx.AllocAccruedInterestAmt |> Option.iter (WriteAllocAccruedInterestAmt strm)
    xx.AllocInterestAtMaturity |> Option.iter (WriteAllocInterestAtMaturity strm)
    xx.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    xx.NoClearingInstructionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoClearingInstructions strm (Fix44.Fields.NoClearingInstructions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoClearingInstructionsGrp strm gg)    ) // end Option.iter
    xx.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    xx.AllocSettlInstType |> Option.iter (WriteAllocSettlInstType strm)
    xx.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component


// group
let WriteAllocationInstruction_NoAllocsGrp (strm:System.IO.Stream) (xx:AllocationInstruction_NoAllocsGrp) =
    WriteAllocAccount strm xx.AllocAccount
    xx.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    xx.MatchStatus |> Option.iter (WriteMatchStatus strm)
    xx.AllocPrice |> Option.iter (WriteAllocPrice strm)
    xx.AllocQty |> Option.iter (WriteAllocQty strm)
    xx.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    xx.ProcessCode |> Option.iter (WriteProcessCode strm)
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component
    xx.NotifyBrokerOfCredit |> Option.iter (WriteNotifyBrokerOfCredit strm)
    xx.AllocHandlInst |> Option.iter (WriteAllocHandlInst strm)
    xx.AllocText |> Option.iter (WriteAllocText strm)
    xx.EncodedAllocText |> Option.iter (WriteEncodedAllocText strm)
    xx.CommissionData |> Option.iter (WriteCommissionData strm) // component
    xx.AllocAvgPx |> Option.iter (WriteAllocAvgPx strm)
    xx.AllocNetMoney |> Option.iter (WriteAllocNetMoney strm)
    xx.SettlCurrAmt |> Option.iter (WriteSettlCurrAmt strm)
    xx.AllocSettlCurrAmt |> Option.iter (WriteAllocSettlCurrAmt strm)
    xx.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    xx.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    xx.SettlCurrFxRate |> Option.iter (WriteSettlCurrFxRate strm)
    xx.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    xx.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    xx.AllocAccruedInterestAmt |> Option.iter (WriteAllocAccruedInterestAmt strm)
    xx.AllocInterestAtMaturity |> Option.iter (WriteAllocInterestAtMaturity strm)
    xx.SettlInstMode |> Option.iter (WriteSettlInstMode strm)
    xx.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    xx.NoClearingInstructions |> Option.iter (WriteNoClearingInstructions strm)
    xx.ClearingInstruction |> Option.iter (WriteClearingInstruction strm)
    xx.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    xx.AllocSettlInstType |> Option.iter (WriteAllocSettlInstType strm)
    xx.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component


// group
let WriteNoOrdersGrp (strm:System.IO.Stream) (xx:NoOrdersGrp) =
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.OrderID |> Option.iter (WriteOrderID strm)
    xx.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.ListID |> Option.iter (WriteListID strm)
    xx.NestedParties2 |> Option.iter (WriteNestedParties2 strm) // component
    xx.OrderQty |> Option.iter (WriteOrderQty strm)
    xx.OrderAvgPx |> Option.iter (WriteOrderAvgPx strm)
    xx.OrderBookingQty |> Option.iter (WriteOrderBookingQty strm)


// group
let WriteListStrikePrice_NoUnderlyingsGrp (strm:System.IO.Stream) (xx:ListStrikePrice_NoUnderlyingsGrp) =
    xx.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    xx.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.Side |> Option.iter (WriteSide strm)
    WritePrice strm xx.Price
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteNoSecurityAltIDGrp (strm:System.IO.Stream) (xx:NoSecurityAltIDGrp) =
    xx.SecurityAltID |> Option.iter (WriteSecurityAltID strm)
    xx.SecurityAltIDSource |> Option.iter (WriteSecurityAltIDSource strm)


// group
let WriteNoEventsGrp (strm:System.IO.Stream) (xx:NoEventsGrp) =
    xx.EventType |> Option.iter (WriteEventType strm)
    xx.EventDate |> Option.iter (WriteEventDate strm)
    xx.EventPx |> Option.iter (WriteEventPx strm)
    xx.EventText |> Option.iter (WriteEventText strm)


// component
let WriteInstrument (strm:System.IO.Stream) (xx:Instrument) =
    WriteSymbol strm xx.Symbol
    xx.SymbolSfx |> Option.iter (WriteSymbolSfx strm)
    xx.SecurityID |> Option.iter (WriteSecurityID strm)
    xx.SecurityIDSource |> Option.iter (WriteSecurityIDSource strm)
    xx.NoSecurityAltIDGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoSecurityAltID strm (Fix44.Fields.NoSecurityAltID numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoSecurityAltIDGrp strm gg)    ) // end Option.iter
    xx.Product |> Option.iter (WriteProduct strm)
    xx.CFICode |> Option.iter (WriteCFICode strm)
    xx.SecurityType |> Option.iter (WriteSecurityType strm)
    xx.SecuritySubType |> Option.iter (WriteSecuritySubType strm)
    xx.MaturityMonthYear |> Option.iter (WriteMaturityMonthYear strm)
    xx.MaturityDate |> Option.iter (WriteMaturityDate strm)
    xx.PutOrCall |> Option.iter (WritePutOrCall strm)
    xx.CouponPaymentDate |> Option.iter (WriteCouponPaymentDate strm)
    xx.IssueDate |> Option.iter (WriteIssueDate strm)
    xx.RepoCollateralSecurityType |> Option.iter (WriteRepoCollateralSecurityType strm)
    xx.RepurchaseTerm |> Option.iter (WriteRepurchaseTerm strm)
    xx.RepurchaseRate |> Option.iter (WriteRepurchaseRate strm)
    xx.Factor |> Option.iter (WriteFactor strm)
    xx.CreditRating |> Option.iter (WriteCreditRating strm)
    xx.InstrRegistry |> Option.iter (WriteInstrRegistry strm)
    xx.CountryOfIssue |> Option.iter (WriteCountryOfIssue strm)
    xx.StateOrProvinceOfIssue |> Option.iter (WriteStateOrProvinceOfIssue strm)
    xx.LocaleOfIssue |> Option.iter (WriteLocaleOfIssue strm)
    xx.RedemptionDate |> Option.iter (WriteRedemptionDate strm)
    xx.StrikePrice |> Option.iter (WriteStrikePrice strm)
    xx.StrikeCurrency |> Option.iter (WriteStrikeCurrency strm)
    xx.OptAttribute |> Option.iter (WriteOptAttribute strm)
    xx.ContractMultiplier |> Option.iter (WriteContractMultiplier strm)
    xx.CouponRate |> Option.iter (WriteCouponRate strm)
    xx.SecurityExchange |> Option.iter (WriteSecurityExchange strm)
    xx.Issuer |> Option.iter (WriteIssuer strm)
    xx.EncodedIssuer |> Option.iter (WriteEncodedIssuer strm)
    xx.SecurityDesc |> Option.iter (WriteSecurityDesc strm)
    xx.EncodedSecurityDesc |> Option.iter (WriteEncodedSecurityDesc strm)
    xx.Pool |> Option.iter (WritePool strm)
    xx.ContractSettlMonth |> Option.iter (WriteContractSettlMonth strm)
    xx.CPProgram |> Option.iter (WriteCPProgram strm)
    xx.CPRegType |> Option.iter (WriteCPRegType strm)
    xx.NoEventsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoEvents strm (Fix44.Fields.NoEvents numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoEventsGrp strm gg)    ) // end Option.iter
    xx.DatedDate |> Option.iter (WriteDatedDate strm)
    xx.InterestAccrualDate |> Option.iter (WriteInterestAccrualDate strm)


// group
let WriteNoStrikesGrp (strm:System.IO.Stream) (xx:NoStrikesGrp) =
    WriteInstrument strm xx.Instrument    // component


// group
let WriteNoAllocsGrp (strm:System.IO.Stream) (xx:NoAllocsGrp) =
    xx.AllocAccount |> Option.iter (WriteAllocAccount strm)
    xx.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    xx.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    xx.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component
    xx.AllocQty |> Option.iter (WriteAllocQty strm)


// group
let WriteNoTradingSessionsGrp (strm:System.IO.Stream) (xx:NoTradingSessionsGrp) =
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)


// group
let WriteNoUnderlyingsGrp (strm:System.IO.Stream) (xx:NoUnderlyingsGrp) =
    xx.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component


// component
let WriteOrderQtyData (strm:System.IO.Stream) (xx:OrderQtyData) =
    xx.OrderQty |> Option.iter (WriteOrderQty strm)
    xx.CashOrderQty |> Option.iter (WriteCashOrderQty strm)
    xx.OrderPercent |> Option.iter (WriteOrderPercent strm)
    xx.RoundingDirection |> Option.iter (WriteRoundingDirection strm)
    xx.RoundingModulus |> Option.iter (WriteRoundingModulus strm)


// component
let WriteSpreadOrBenchmarkCurveData (strm:System.IO.Stream) (xx:SpreadOrBenchmarkCurveData) =
    xx.Spread |> Option.iter (WriteSpread strm)
    xx.BenchmarkCurveCurrency |> Option.iter (WriteBenchmarkCurveCurrency strm)
    xx.BenchmarkCurveName |> Option.iter (WriteBenchmarkCurveName strm)
    xx.BenchmarkCurvePoint |> Option.iter (WriteBenchmarkCurvePoint strm)
    xx.BenchmarkPrice |> Option.iter (WriteBenchmarkPrice strm)
    xx.BenchmarkPriceType |> Option.iter (WriteBenchmarkPriceType strm)
    xx.BenchmarkSecurityID |> Option.iter (WriteBenchmarkSecurityID strm)
    xx.BenchmarkSecurityIDSource |> Option.iter (WriteBenchmarkSecurityIDSource strm)


// component
let WriteYieldData (strm:System.IO.Stream) (xx:YieldData) =
    xx.YieldType |> Option.iter (WriteYieldType strm)
    xx.Yield |> Option.iter (WriteYield strm)
    xx.YieldCalcDate |> Option.iter (WriteYieldCalcDate strm)
    xx.YieldRedemptionDate |> Option.iter (WriteYieldRedemptionDate strm)
    xx.YieldRedemptionPrice |> Option.iter (WriteYieldRedemptionPrice strm)
    xx.YieldRedemptionPriceType |> Option.iter (WriteYieldRedemptionPriceType strm)


// component
let WritePegInstructions (strm:System.IO.Stream) (xx:PegInstructions) =
    xx.PegOffsetValue |> Option.iter (WritePegOffsetValue strm)
    xx.PegMoveType |> Option.iter (WritePegMoveType strm)
    xx.PegOffsetType |> Option.iter (WritePegOffsetType strm)
    xx.PegLimitType |> Option.iter (WritePegLimitType strm)
    xx.PegRoundDirection |> Option.iter (WritePegRoundDirection strm)
    xx.PegScope |> Option.iter (WritePegScope strm)


// component
let WriteDiscretionInstructions (strm:System.IO.Stream) (xx:DiscretionInstructions) =
    xx.DiscretionInst |> Option.iter (WriteDiscretionInst strm)
    xx.DiscretionOffsetValue |> Option.iter (WriteDiscretionOffsetValue strm)
    xx.DiscretionMoveType |> Option.iter (WriteDiscretionMoveType strm)
    xx.DiscretionOffsetType |> Option.iter (WriteDiscretionOffsetType strm)
    xx.DiscretionLimitType |> Option.iter (WriteDiscretionLimitType strm)
    xx.DiscretionRoundDirection |> Option.iter (WriteDiscretionRoundDirection strm)
    xx.DiscretionScope |> Option.iter (WriteDiscretionScope strm)


// group
let WriteNewOrderList_NoOrdersGrp (strm:System.IO.Stream) (xx:NewOrderList_NoOrdersGrp) =
    WriteClOrdID strm xx.ClOrdID
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    WriteListSeqNo strm xx.ListSeqNo
    xx.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    xx.SettlInstMode |> Option.iter (WriteSettlInstMode strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    xx.TradeDate |> Option.iter (WriteTradeDate strm)
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.DayBookingInst |> Option.iter (WriteDayBookingInst strm)
    xx.BookingUnit |> Option.iter (WriteBookingUnit strm)
    xx.AllocID |> Option.iter (WriteAllocID strm)
    xx.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    xx.NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoAllocsGrp strm gg)    ) // end Option.iter
    xx.SettlType |> Option.iter (WriteSettlType strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.CashMargin |> Option.iter (WriteCashMargin strm)
    xx.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    xx.HandlInst |> Option.iter (WriteHandlInst strm)
    xx.ExecInst |> Option.iter (WriteExecInst strm)
    xx.MinQty |> Option.iter (WriteMinQty strm)
    xx.MaxFloor |> Option.iter (WriteMaxFloor strm)
    xx.ExDestination |> Option.iter (WriteExDestination strm)
    xx.NoTradingSessionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTradingSessions strm (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradingSessionsGrp strm gg)    ) // end Option.iter
    xx.ProcessCode |> Option.iter (WriteProcessCode strm)
    WriteInstrument strm xx.Instrument    // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    WriteSide strm xx.Side
    xx.SideValueInd |> Option.iter (WriteSideValueInd strm)
    xx.LocateReqd |> Option.iter (WriteLocateReqd strm)
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm xx.OrderQtyData    // component
    xx.OrdType |> Option.iter (WriteOrdType strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.StopPx |> Option.iter (WriteStopPx strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.ComplianceID |> Option.iter (WriteComplianceID strm)
    xx.SolicitedFlag |> Option.iter (WriteSolicitedFlag strm)
    xx.IOIid |> Option.iter (WriteIOIid strm)
    xx.QuoteID |> Option.iter (WriteQuoteID strm)
    xx.TimeInForce |> Option.iter (WriteTimeInForce strm)
    xx.EffectiveTime |> Option.iter (WriteEffectiveTime strm)
    xx.ExpireDate |> Option.iter (WriteExpireDate strm)
    xx.ExpireTime |> Option.iter (WriteExpireTime strm)
    xx.GTBookingInst |> Option.iter (WriteGTBookingInst strm)
    xx.CommissionData |> Option.iter (WriteCommissionData strm) // component
    xx.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    xx.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    xx.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    xx.ForexReq |> Option.iter (WriteForexReq strm)
    xx.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    xx.BookingType |> Option.iter (WriteBookingType strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    xx.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    xx.Price2 |> Option.iter (WritePrice2 strm)
    xx.PositionEffect |> Option.iter (WritePositionEffect strm)
    xx.CoveredOrUncovered |> Option.iter (WriteCoveredOrUncovered strm)
    xx.MaxShow |> Option.iter (WriteMaxShow strm)
    xx.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    xx.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    xx.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    xx.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    xx.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    xx.Designation |> Option.iter (WriteDesignation strm)


// group
let WriteBidResponse_NoBidComponentsGrp (strm:System.IO.Stream) (xx:BidResponse_NoBidComponentsGrp) =
    WriteCommissionData strm xx.CommissionData    // component
    xx.ListID |> Option.iter (WriteListID strm)
    xx.Country |> Option.iter (WriteCountry strm)
    xx.Side |> Option.iter (WriteSide strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.FairValue |> Option.iter (WriteFairValue strm)
    xx.NetGrossInd |> Option.iter (WriteNetGrossInd strm)
    xx.SettlType |> Option.iter (WriteSettlType strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteNoLegAllocsGrp (strm:System.IO.Stream) (xx:NoLegAllocsGrp) =
    xx.LegAllocAccount |> Option.iter (WriteLegAllocAccount strm)
    xx.LegIndividualAllocID |> Option.iter (WriteLegIndividualAllocID strm)
    xx.NestedParties2 |> Option.iter (WriteNestedParties2 strm) // component
    xx.LegAllocQty |> Option.iter (WriteLegAllocQty strm)
    xx.LegAllocAcctIDSource |> Option.iter (WriteLegAllocAcctIDSource strm)
    xx.LegSettlCurrency |> Option.iter (WriteLegSettlCurrency strm)


// group
let WriteMultilegOrderCancelReplaceRequest_NoLegsGrp (strm:System.IO.Stream) (xx:MultilegOrderCancelReplaceRequest_NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.LegQty |> Option.iter (WriteLegQty strm)
    xx.LegSwapType |> Option.iter (WriteLegSwapType strm)
    xx.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    xx.NoLegAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegAllocs strm (Fix44.Fields.NoLegAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegAllocsGrp strm gg)    ) // end Option.iter
    xx.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    xx.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component
    xx.LegRefID |> Option.iter (WriteLegRefID strm)
    xx.LegPrice |> Option.iter (WriteLegPrice strm)
    xx.LegSettlType |> Option.iter (WriteLegSettlType strm)
    xx.LegSettlDate |> Option.iter (WriteLegSettlDate strm)


// group
let WriteNoNested3PartySubIDsGrp (strm:System.IO.Stream) (xx:NoNested3PartySubIDsGrp) =
    xx.Nested3PartySubID |> Option.iter (WriteNested3PartySubID strm)
    xx.Nested3PartySubIDType |> Option.iter (WriteNested3PartySubIDType strm)


// group
let WriteNoNested3PartyIDsGrp (strm:System.IO.Stream) (xx:NoNested3PartyIDsGrp) =
    xx.Nested3PartyID |> Option.iter (WriteNested3PartyID strm)
    xx.Nested3PartyIDSource |> Option.iter (WriteNested3PartyIDSource strm)
    xx.Nested3PartyRole |> Option.iter (WriteNested3PartyRole strm)
    xx.NoNested3PartySubIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoNested3PartySubIDs strm (Fix44.Fields.NoNested3PartySubIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoNested3PartySubIDsGrp strm gg)    ) // end Option.iter


// component
let WriteNestedParties3 (strm:System.IO.Stream) (xx:NestedParties3) =
    xx.NoNested3PartyIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoNested3PartyIDs strm (Fix44.Fields.NoNested3PartyIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoNested3PartyIDsGrp strm gg)    ) // end Option.iter


// group
let WriteMultilegOrderCancelReplaceRequest_NoAllocsGrp (strm:System.IO.Stream) (xx:MultilegOrderCancelReplaceRequest_NoAllocsGrp) =
    xx.AllocAccount |> Option.iter (WriteAllocAccount strm)
    xx.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    xx.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    xx.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    xx.NestedParties3 |> Option.iter (WriteNestedParties3 strm) // component
    xx.AllocQty |> Option.iter (WriteAllocQty strm)


// group
let WriteNewOrderMultileg_NoLegsGrp (strm:System.IO.Stream) (xx:NewOrderMultileg_NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.LegQty |> Option.iter (WriteLegQty strm)
    xx.LegSwapType |> Option.iter (WriteLegSwapType strm)
    xx.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    xx.NoLegAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegAllocs strm (Fix44.Fields.NoLegAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegAllocsGrp strm gg)    ) // end Option.iter
    xx.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    xx.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component
    xx.LegRefID |> Option.iter (WriteLegRefID strm)
    xx.LegPrice |> Option.iter (WriteLegPrice strm)
    xx.LegSettlType |> Option.iter (WriteLegSettlType strm)
    xx.LegSettlDate |> Option.iter (WriteLegSettlDate strm)


// group
let WriteNewOrderMultileg_NoAllocsGrp (strm:System.IO.Stream) (xx:NewOrderMultileg_NoAllocsGrp) =
    xx.AllocAccount |> Option.iter (WriteAllocAccount strm)
    xx.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    xx.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    xx.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    xx.NestedParties3 |> Option.iter (WriteNestedParties3 strm) // component
    xx.AllocQty |> Option.iter (WriteAllocQty strm)


// group
let WriteCrossOrderCancelRequest_NoSidesGrp (strm:System.IO.Stream) (xx:CrossOrderCancelRequest_NoSidesGrp) =
    WriteSide strm xx.Side
    WriteOrigClOrdID strm xx.OrigClOrdID
    WriteClOrdID strm xx.ClOrdID
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    xx.OrigOrdModTime |> Option.iter (WriteOrigOrdModTime strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    xx.TradeDate |> Option.iter (WriteTradeDate strm)
    WriteOrderQtyData strm xx.OrderQtyData    // component
    xx.ComplianceID |> Option.iter (WriteComplianceID strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteCrossOrderCancelReplaceRequest_NoSidesGrp (strm:System.IO.Stream) (xx:CrossOrderCancelReplaceRequest_NoSidesGrp) =
    WriteSide strm xx.Side
    WriteOrigClOrdID strm xx.OrigClOrdID
    WriteClOrdID strm xx.ClOrdID
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    xx.OrigOrdModTime |> Option.iter (WriteOrigOrdModTime strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    xx.TradeDate |> Option.iter (WriteTradeDate strm)
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.DayBookingInst |> Option.iter (WriteDayBookingInst strm)
    xx.BookingUnit |> Option.iter (WriteBookingUnit strm)
    xx.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    xx.AllocID |> Option.iter (WriteAllocID strm)
    xx.NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoAllocsGrp strm gg)    ) // end Option.iter
    xx.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm xx.OrderQtyData    // component
    xx.CommissionData |> Option.iter (WriteCommissionData strm) // component
    xx.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    xx.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    xx.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    xx.ForexReq |> Option.iter (WriteForexReq strm)
    xx.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    xx.BookingType |> Option.iter (WriteBookingType strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.PositionEffect |> Option.iter (WritePositionEffect strm)
    xx.CoveredOrUncovered |> Option.iter (WriteCoveredOrUncovered strm)
    xx.CashMargin |> Option.iter (WriteCashMargin strm)
    xx.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    xx.SolicitedFlag |> Option.iter (WriteSolicitedFlag strm)
    xx.SideComplianceID |> Option.iter (WriteSideComplianceID strm)


// group
let WriteNoSidesGrp (strm:System.IO.Stream) (xx:NoSidesGrp) =
    WriteSide strm xx.Side
    WriteClOrdID strm xx.ClOrdID
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    xx.TradeDate |> Option.iter (WriteTradeDate strm)
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.DayBookingInst |> Option.iter (WriteDayBookingInst strm)
    xx.BookingUnit |> Option.iter (WriteBookingUnit strm)
    xx.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    xx.AllocID |> Option.iter (WriteAllocID strm)
    xx.NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoAllocsGrp strm gg)    ) // end Option.iter
    xx.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm xx.OrderQtyData    // component
    xx.CommissionData |> Option.iter (WriteCommissionData strm) // component
    xx.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    xx.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    xx.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    xx.ForexReq |> Option.iter (WriteForexReq strm)
    xx.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    xx.BookingType |> Option.iter (WriteBookingType strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.PositionEffect |> Option.iter (WritePositionEffect strm)
    xx.CoveredOrUncovered |> Option.iter (WriteCoveredOrUncovered strm)
    xx.CashMargin |> Option.iter (WriteCashMargin strm)
    xx.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    xx.SolicitedFlag |> Option.iter (WriteSolicitedFlag strm)
    xx.SideComplianceID |> Option.iter (WriteSideComplianceID strm)


// group
let WriteExecutionReport_NoLegsGrp (strm:System.IO.Stream) (xx:ExecutionReport_NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.LegQty |> Option.iter (WriteLegQty strm)
    xx.LegSwapType |> Option.iter (WriteLegSwapType strm)
    xx.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    xx.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    xx.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component
    xx.LegRefID |> Option.iter (WriteLegRefID strm)
    xx.LegPrice |> Option.iter (WriteLegPrice strm)
    xx.LegSettlType |> Option.iter (WriteLegSettlType strm)
    xx.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    xx.LegLastPx |> Option.iter (WriteLegLastPx strm)


// group
let WriteNoInstrAttribGrp (strm:System.IO.Stream) (xx:NoInstrAttribGrp) =
    xx.InstrAttribType |> Option.iter (WriteInstrAttribType strm)
    xx.InstrAttribValue |> Option.iter (WriteInstrAttribValue strm)


// component
let WriteInstrumentExtension (strm:System.IO.Stream) (xx:InstrumentExtension) =
    xx.DeliveryForm |> Option.iter (WriteDeliveryForm strm)
    xx.PctAtRisk |> Option.iter (WritePctAtRisk strm)
    xx.NoInstrAttribGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoInstrAttrib strm (Fix44.Fields.NoInstrAttrib numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoInstrAttribGrp strm gg)    ) // end Option.iter


// group
let WriteNoLegsGrp (strm:System.IO.Stream) (xx:NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component


// group
let WriteDerivativeSecurityList_NoRelatedSymGrp (strm:System.IO.Stream) (xx:DerivativeSecurityList_NoRelatedSymGrp) =
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.ExpirationCycle |> Option.iter (WriteExpirationCycle strm)
    xx.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// component
let WriteFinancingDetails (strm:System.IO.Stream) (xx:FinancingDetails) =
    xx.AgreementDesc |> Option.iter (WriteAgreementDesc strm)
    xx.AgreementID |> Option.iter (WriteAgreementID strm)
    xx.AgreementDate |> Option.iter (WriteAgreementDate strm)
    xx.AgreementCurrency |> Option.iter (WriteAgreementCurrency strm)
    xx.TerminationType |> Option.iter (WriteTerminationType strm)
    xx.StartDate |> Option.iter (WriteStartDate strm)
    xx.EndDate |> Option.iter (WriteEndDate strm)
    xx.DeliveryType |> Option.iter (WriteDeliveryType strm)
    xx.MarginRatio |> Option.iter (WriteMarginRatio strm)


// component
let WriteLegBenchmarkCurveData (strm:System.IO.Stream) (xx:LegBenchmarkCurveData) =
    xx.LegBenchmarkCurveCurrency |> Option.iter (WriteLegBenchmarkCurveCurrency strm)
    xx.LegBenchmarkCurveName |> Option.iter (WriteLegBenchmarkCurveName strm)
    xx.LegBenchmarkCurvePoint |> Option.iter (WriteLegBenchmarkCurvePoint strm)
    xx.LegBenchmarkPrice |> Option.iter (WriteLegBenchmarkPrice strm)
    xx.LegBenchmarkPriceType |> Option.iter (WriteLegBenchmarkPriceType strm)


// group
let WriteSecurityList_NoLegsGrp (strm:System.IO.Stream) (xx:SecurityList_NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.LegSwapType |> Option.iter (WriteLegSwapType strm)
    xx.LegSettlType |> Option.iter (WriteLegSettlType strm)
    xx.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    xx.LegBenchmarkCurveData |> Option.iter (WriteLegBenchmarkCurveData strm) // component


// group
let WriteSecurityList_NoRelatedSymGrp (strm:System.IO.Stream) (xx:SecurityList_NoRelatedSymGrp) =
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.SecurityList_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteSecurityList_NoLegsGrp strm gg)    ) // end Option.iter
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    xx.RoundLot |> Option.iter (WriteRoundLot strm)
    xx.MinTradeVol |> Option.iter (WriteMinTradeVol strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.ExpirationCycle |> Option.iter (WriteExpirationCycle strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteMarketDataIncrementalRefresh_NoMDEntriesGrp (strm:System.IO.Stream) (xx:MarketDataIncrementalRefresh_NoMDEntriesGrp) =
    WriteMDUpdateAction strm xx.MDUpdateAction
    xx.DeleteReason |> Option.iter (WriteDeleteReason strm)
    xx.MDEntryType |> Option.iter (WriteMDEntryType strm)
    xx.MDEntryID |> Option.iter (WriteMDEntryID strm)
    xx.MDEntryRefID |> Option.iter (WriteMDEntryRefID strm)
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.FinancialStatus |> Option.iter (WriteFinancialStatus strm)
    xx.CorporateAction |> Option.iter (WriteCorporateAction strm)
    xx.MDEntryPx |> Option.iter (WriteMDEntryPx strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.MDEntrySize |> Option.iter (WriteMDEntrySize strm)
    xx.MDEntryDate |> Option.iter (WriteMDEntryDate strm)
    xx.MDEntryTime |> Option.iter (WriteMDEntryTime strm)
    xx.TickDirection |> Option.iter (WriteTickDirection strm)
    xx.MDMkt |> Option.iter (WriteMDMkt strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.QuoteCondition |> Option.iter (WriteQuoteCondition strm)
    xx.TradeCondition |> Option.iter (WriteTradeCondition strm)
    xx.MDEntryOriginator |> Option.iter (WriteMDEntryOriginator strm)
    xx.LocationID |> Option.iter (WriteLocationID strm)
    xx.DeskID |> Option.iter (WriteDeskID strm)
    xx.OpenCloseSettlFlag |> Option.iter (WriteOpenCloseSettlFlag strm)
    xx.TimeInForce |> Option.iter (WriteTimeInForce strm)
    xx.ExpireDate |> Option.iter (WriteExpireDate strm)
    xx.ExpireTime |> Option.iter (WriteExpireTime strm)
    xx.MinQty |> Option.iter (WriteMinQty strm)
    xx.ExecInst |> Option.iter (WriteExecInst strm)
    xx.SellerDays |> Option.iter (WriteSellerDays strm)
    xx.OrderID |> Option.iter (WriteOrderID strm)
    xx.QuoteEntryID |> Option.iter (WriteQuoteEntryID strm)
    xx.MDEntryBuyer |> Option.iter (WriteMDEntryBuyer strm)
    xx.MDEntrySeller |> Option.iter (WriteMDEntrySeller strm)
    xx.NumberOfOrders |> Option.iter (WriteNumberOfOrders strm)
    xx.MDEntryPositionNo |> Option.iter (WriteMDEntryPositionNo strm)
    xx.Scope |> Option.iter (WriteScope strm)
    xx.PriceDelta |> Option.iter (WritePriceDelta strm)
    xx.NetChgPrevDay |> Option.iter (WriteNetChgPrevDay strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteMarketDataRequest_NoRelatedSymGrp (strm:System.IO.Stream) (xx:MarketDataRequest_NoRelatedSymGrp) =
    WriteInstrument strm xx.Instrument    // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter


// group
let WriteMassQuoteAcknowledgement_NoQuoteEntriesGrp (strm:System.IO.Stream) (xx:MassQuoteAcknowledgement_NoQuoteEntriesGrp) =
    xx.QuoteEntryID |> Option.iter (WriteQuoteEntryID strm)
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.BidPx |> Option.iter (WriteBidPx strm)
    xx.OfferPx |> Option.iter (WriteOfferPx strm)
    xx.BidSize |> Option.iter (WriteBidSize strm)
    xx.OfferSize |> Option.iter (WriteOfferSize strm)
    xx.ValidUntilTime |> Option.iter (WriteValidUntilTime strm)
    xx.BidSpotRate |> Option.iter (WriteBidSpotRate strm)
    xx.OfferSpotRate |> Option.iter (WriteOfferSpotRate strm)
    xx.BidForwardPoints |> Option.iter (WriteBidForwardPoints strm)
    xx.OfferForwardPoints |> Option.iter (WriteOfferForwardPoints strm)
    xx.MidPx |> Option.iter (WriteMidPx strm)
    xx.BidYield |> Option.iter (WriteBidYield strm)
    xx.MidYield |> Option.iter (WriteMidYield strm)
    xx.OfferYield |> Option.iter (WriteOfferYield strm)
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.OrdType |> Option.iter (WriteOrdType strm)
    xx.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    xx.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    xx.BidForwardPoints2 |> Option.iter (WriteBidForwardPoints2 strm)
    xx.OfferForwardPoints2 |> Option.iter (WriteOfferForwardPoints2 strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.QuoteEntryRejectReason |> Option.iter (WriteQuoteEntryRejectReason strm)


// group
let WriteMassQuoteAcknowledgement_NoQuoteSetsGrp (strm:System.IO.Stream) (xx:MassQuoteAcknowledgement_NoQuoteSetsGrp) =
    xx.QuoteSetID |> Option.iter (WriteQuoteSetID strm)
    xx.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    xx.TotNoQuoteEntries |> Option.iter (WriteTotNoQuoteEntries strm)
    xx.LastFragment |> Option.iter (WriteLastFragment strm)
    xx.MassQuoteAcknowledgement_NoQuoteEntriesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteEntries strm (Fix44.Fields.NoQuoteEntries numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteMassQuoteAcknowledgement_NoQuoteEntriesGrp strm gg)    ) // end Option.iter


// group
let WriteMassQuote_NoQuoteEntriesGrp (strm:System.IO.Stream) (xx:MassQuote_NoQuoteEntriesGrp) =
    WriteQuoteEntryID strm xx.QuoteEntryID
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.BidPx |> Option.iter (WriteBidPx strm)
    xx.OfferPx |> Option.iter (WriteOfferPx strm)
    xx.BidSize |> Option.iter (WriteBidSize strm)
    xx.OfferSize |> Option.iter (WriteOfferSize strm)
    xx.ValidUntilTime |> Option.iter (WriteValidUntilTime strm)
    xx.BidSpotRate |> Option.iter (WriteBidSpotRate strm)
    xx.OfferSpotRate |> Option.iter (WriteOfferSpotRate strm)
    xx.BidForwardPoints |> Option.iter (WriteBidForwardPoints strm)
    xx.OfferForwardPoints |> Option.iter (WriteOfferForwardPoints strm)
    xx.MidPx |> Option.iter (WriteMidPx strm)
    xx.BidYield |> Option.iter (WriteBidYield strm)
    xx.MidYield |> Option.iter (WriteMidYield strm)
    xx.OfferYield |> Option.iter (WriteOfferYield strm)
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.OrdType |> Option.iter (WriteOrdType strm)
    xx.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    xx.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    xx.BidForwardPoints2 |> Option.iter (WriteBidForwardPoints2 strm)
    xx.OfferForwardPoints2 |> Option.iter (WriteOfferForwardPoints2 strm)
    xx.Currency |> Option.iter (WriteCurrency strm)


// group
let WriteNoQuoteSetsGrp (strm:System.IO.Stream) (xx:NoQuoteSetsGrp) =
    WriteQuoteSetID strm xx.QuoteSetID
    xx.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    xx.QuoteSetValidUntilTime |> Option.iter (WriteQuoteSetValidUntilTime strm)
    WriteTotNoQuoteEntries strm xx.TotNoQuoteEntries
    xx.LastFragment |> Option.iter (WriteLastFragment strm)
    let numGrps = xx.MassQuote_NoQuoteEntriesGrp.Length
    WriteNoQuoteEntries strm (Fix44.Fields.NoQuoteEntries numGrps) // write the 'num group repeats' field
    xx.MassQuote_NoQuoteEntriesGrp |> List.iter (fun gg -> WriteMassQuote_NoQuoteEntriesGrp strm gg)


// group
let WriteQuoteStatusReport_NoLegsGrp (strm:System.IO.Stream) (xx:QuoteStatusReport_NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.LegQty |> Option.iter (WriteLegQty strm)
    xx.LegSwapType |> Option.iter (WriteLegSwapType strm)
    xx.LegSettlType |> Option.iter (WriteLegSettlType strm)
    xx.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    xx.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component


// group
let WriteNoQuoteEntriesGrp (strm:System.IO.Stream) (xx:NoQuoteEntriesGrp) =
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter


// group
let WriteQuote_NoLegsGrp (strm:System.IO.Stream) (xx:Quote_NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.LegQty |> Option.iter (WriteLegQty strm)
    xx.LegSwapType |> Option.iter (WriteLegSwapType strm)
    xx.LegSettlType |> Option.iter (WriteLegSettlType strm)
    xx.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    xx.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component
    xx.LegPriceType |> Option.iter (WriteLegPriceType strm)
    xx.LegBidPx |> Option.iter (WriteLegBidPx strm)
    xx.LegOfferPx |> Option.iter (WriteLegOfferPx strm)
    xx.LegBenchmarkCurveData |> Option.iter (WriteLegBenchmarkCurveData strm) // component


// group
let WriteRFQRequest_NoRelatedSymGrp (strm:System.IO.Stream) (xx:RFQRequest_NoRelatedSymGrp) =
    WriteInstrument strm xx.Instrument    // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    xx.QuoteRequestType |> Option.iter (WriteQuoteRequestType strm)
    xx.QuoteType |> Option.iter (WriteQuoteType strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)


// group
let WriteQuoteRequestReject_NoLegsGrp (strm:System.IO.Stream) (xx:QuoteRequestReject_NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.LegQty |> Option.iter (WriteLegQty strm)
    xx.LegSwapType |> Option.iter (WriteLegSwapType strm)
    xx.LegSettlType |> Option.iter (WriteLegSettlType strm)
    xx.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    xx.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component
    xx.LegBenchmarkCurveData |> Option.iter (WriteLegBenchmarkCurveData strm) // component


// group
let WriteQuoteRequestReject_NoRelatedSymGrp (strm:System.IO.Stream) (xx:QuoteRequestReject_NoRelatedSymGrp) =
    WriteInstrument strm xx.Instrument    // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    xx.QuoteRequestType |> Option.iter (WriteQuoteRequestType strm)
    xx.QuoteType |> Option.iter (WriteQuoteType strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    xx.Side |> Option.iter (WriteSide strm)
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.OrderQtyData |> Option.iter (WriteOrderQtyData strm) // component
    xx.SettlType |> Option.iter (WriteSettlType strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    xx.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.QuoteRequestReject_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteQuoteRequestReject_NoLegsGrp strm gg)    ) // end Option.iter


// group
let WriteQuoteResponse_NoLegsGrp (strm:System.IO.Stream) (xx:QuoteResponse_NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.LegQty |> Option.iter (WriteLegQty strm)
    xx.LegSwapType |> Option.iter (WriteLegSwapType strm)
    xx.LegSettlType |> Option.iter (WriteLegSettlType strm)
    xx.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    xx.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component
    xx.LegPriceType |> Option.iter (WriteLegPriceType strm)
    xx.LegBidPx |> Option.iter (WriteLegBidPx strm)
    xx.LegOfferPx |> Option.iter (WriteLegOfferPx strm)
    xx.LegBenchmarkCurveData |> Option.iter (WriteLegBenchmarkCurveData strm) // component


// group
let WriteQuoteRequest_NoLegsGrp (strm:System.IO.Stream) (xx:QuoteRequest_NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.LegQty |> Option.iter (WriteLegQty strm)
    xx.LegSwapType |> Option.iter (WriteLegSwapType strm)
    xx.LegSettlType |> Option.iter (WriteLegSettlType strm)
    xx.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    xx.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    xx.NestedParties |> Option.iter (WriteNestedParties strm) // component
    xx.LegBenchmarkCurveData |> Option.iter (WriteLegBenchmarkCurveData strm) // component


// group
let WriteNoQuoteQualifiersGrp (strm:System.IO.Stream) (xx:NoQuoteQualifiersGrp) =
    xx.QuoteQualifier |> Option.iter (WriteQuoteQualifier strm)


// group
let WriteQuoteRequest_NoRelatedSymGrp (strm:System.IO.Stream) (xx:QuoteRequest_NoRelatedSymGrp) =
    WriteInstrument strm xx.Instrument    // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    xx.QuoteRequestType |> Option.iter (WriteQuoteRequestType strm)
    xx.QuoteType |> Option.iter (WriteQuoteType strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    xx.Side |> Option.iter (WriteSide strm)
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.OrderQtyData |> Option.iter (WriteOrderQtyData strm) // component
    xx.SettlType |> Option.iter (WriteSettlType strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    xx.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.QuoteRequest_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteQuoteRequest_NoLegsGrp strm gg)    ) // end Option.iter
    xx.NoQuoteQualifiersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteQualifiers strm (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoQuoteQualifiersGrp strm gg)    ) // end Option.iter
    xx.QuotePriceType |> Option.iter (WriteQuotePriceType strm)
    xx.OrdType |> Option.iter (WriteOrdType strm)
    xx.ValidUntilTime |> Option.iter (WriteValidUntilTime strm)
    xx.ExpireTime |> Option.iter (WriteExpireTime strm)
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.Price2 |> Option.iter (WritePrice2 strm)
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    xx.Parties |> Option.iter (WriteParties strm) // component


// group
let WriteNoRelatedSymGrp (strm:System.IO.Stream) (xx:NoRelatedSymGrp) =
    xx.Instrument |> Option.iter (WriteInstrument strm) // component


// group
let WriteIndicationOfInterest_NoLegsGrp (strm:System.IO.Stream) (xx:IndicationOfInterest_NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.LegIOIQty |> Option.iter (WriteLegIOIQty strm)
    xx.LegStipulations |> Option.iter (WriteLegStipulations strm) // component


// group
let WriteAdvertisement_NoUnderlyingsGrp (strm:System.IO.Stream) (xx:Advertisement_NoUnderlyingsGrp) =
    WriteUnderlyingInstrument strm xx.UnderlyingInstrument    // component


// group
let WriteNoMsgTypesGrp (strm:System.IO.Stream) (xx:NoMsgTypesGrp) =
    xx.RefMsgType |> Option.iter (WriteRefMsgType strm)
    xx.MsgDirection |> Option.iter (WriteMsgDirection strm)


// group
let WriteNoIOIQualifiersGrp (strm:System.IO.Stream) (xx:NoIOIQualifiersGrp) =
    xx.IOIQualifier |> Option.iter (WriteIOIQualifier strm)


// group
let WriteNoRoutingIDsGrp (strm:System.IO.Stream) (xx:NoRoutingIDsGrp) =
    xx.RoutingType |> Option.iter (WriteRoutingType strm)
    xx.RoutingID |> Option.iter (WriteRoutingID strm)


// group
let WriteLinesOfTextGrp (strm:System.IO.Stream) (xx:LinesOfTextGrp) =
    WriteText strm xx.Text
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteNoMDEntryTypesGrp (strm:System.IO.Stream) (xx:NoMDEntryTypesGrp) =
    WriteMDEntryType strm xx.MDEntryType


// group
let WriteNoMDEntriesGrp (strm:System.IO.Stream) (xx:NoMDEntriesGrp) =
    WriteMDEntryType strm xx.MDEntryType
    xx.MDEntryPx |> Option.iter (WriteMDEntryPx strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.MDEntrySize |> Option.iter (WriteMDEntrySize strm)
    xx.MDEntryDate |> Option.iter (WriteMDEntryDate strm)
    xx.MDEntryTime |> Option.iter (WriteMDEntryTime strm)
    xx.TickDirection |> Option.iter (WriteTickDirection strm)
    xx.MDMkt |> Option.iter (WriteMDMkt strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.QuoteCondition |> Option.iter (WriteQuoteCondition strm)
    xx.TradeCondition |> Option.iter (WriteTradeCondition strm)
    xx.MDEntryOriginator |> Option.iter (WriteMDEntryOriginator strm)
    xx.LocationID |> Option.iter (WriteLocationID strm)
    xx.DeskID |> Option.iter (WriteDeskID strm)
    xx.OpenCloseSettlFlag |> Option.iter (WriteOpenCloseSettlFlag strm)
    xx.TimeInForce |> Option.iter (WriteTimeInForce strm)
    xx.ExpireDate |> Option.iter (WriteExpireDate strm)
    xx.ExpireTime |> Option.iter (WriteExpireTime strm)
    xx.MinQty |> Option.iter (WriteMinQty strm)
    xx.ExecInst |> Option.iter (WriteExecInst strm)
    xx.SellerDays |> Option.iter (WriteSellerDays strm)
    xx.OrderID |> Option.iter (WriteOrderID strm)
    xx.QuoteEntryID |> Option.iter (WriteQuoteEntryID strm)
    xx.MDEntryBuyer |> Option.iter (WriteMDEntryBuyer strm)
    xx.MDEntrySeller |> Option.iter (WriteMDEntrySeller strm)
    xx.NumberOfOrders |> Option.iter (WriteNumberOfOrders strm)
    xx.MDEntryPositionNo |> Option.iter (WriteMDEntryPositionNo strm)
    xx.Scope |> Option.iter (WriteScope strm)
    xx.PriceDelta |> Option.iter (WritePriceDelta strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteNoAltMDSourceGrp (strm:System.IO.Stream) (xx:NoAltMDSourceGrp) =
    xx.AltMDSourceID |> Option.iter (WriteAltMDSourceID strm)


// group
let WriteNoSecurityTypesGrp (strm:System.IO.Stream) (xx:NoSecurityTypesGrp) =
    xx.SecurityType |> Option.iter (WriteSecurityType strm)
    xx.SecuritySubType |> Option.iter (WriteSecuritySubType strm)
    xx.Product |> Option.iter (WriteProduct strm)
    xx.CFICode |> Option.iter (WriteCFICode strm)


// group
let WriteNoContraBrokersGrp (strm:System.IO.Stream) (xx:NoContraBrokersGrp) =
    xx.ContraBroker |> Option.iter (WriteContraBroker strm)
    xx.ContraTrader |> Option.iter (WriteContraTrader strm)
    xx.ContraTradeQty |> Option.iter (WriteContraTradeQty strm)
    xx.ContraTradeTime |> Option.iter (WriteContraTradeTime strm)
    xx.ContraLegRefID |> Option.iter (WriteContraLegRefID strm)


// group
let WriteNoAffectedOrdersGrp (strm:System.IO.Stream) (xx:NoAffectedOrdersGrp) =
    xx.OrigClOrdID |> Option.iter (WriteOrigClOrdID strm)
    xx.AffectedOrderID |> Option.iter (WriteAffectedOrderID strm)
    xx.AffectedSecondaryOrderID |> Option.iter (WriteAffectedSecondaryOrderID strm)


// group
let WriteNoBidDescriptorsGrp (strm:System.IO.Stream) (xx:NoBidDescriptorsGrp) =
    xx.BidDescriptorType |> Option.iter (WriteBidDescriptorType strm)
    xx.BidDescriptor |> Option.iter (WriteBidDescriptor strm)
    xx.SideValueInd |> Option.iter (WriteSideValueInd strm)
    xx.LiquidityValue |> Option.iter (WriteLiquidityValue strm)
    xx.LiquidityNumSecurities |> Option.iter (WriteLiquidityNumSecurities strm)
    xx.LiquidityPctLow |> Option.iter (WriteLiquidityPctLow strm)
    xx.LiquidityPctHigh |> Option.iter (WriteLiquidityPctHigh strm)
    xx.EFPTrackingError |> Option.iter (WriteEFPTrackingError strm)
    xx.FairValue |> Option.iter (WriteFairValue strm)
    xx.OutsideIndexPct |> Option.iter (WriteOutsideIndexPct strm)
    xx.ValueOfFutures |> Option.iter (WriteValueOfFutures strm)


// group
let WriteNoBidComponentsGrp (strm:System.IO.Stream) (xx:NoBidComponentsGrp) =
    xx.ListID |> Option.iter (WriteListID strm)
    xx.Side |> Option.iter (WriteSide strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.NetGrossInd |> Option.iter (WriteNetGrossInd strm)
    xx.SettlType |> Option.iter (WriteSettlType strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)


// group
let WriteListStatus_NoOrdersGrp (strm:System.IO.Stream) (xx:ListStatus_NoOrdersGrp) =
    WriteClOrdID strm xx.ClOrdID
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    WriteCumQty strm xx.CumQty
    WriteOrdStatus strm xx.OrdStatus
    xx.WorkingIndicator |> Option.iter (WriteWorkingIndicator strm)
    WriteLeavesQty strm xx.LeavesQty
    WriteCxlQty strm xx.CxlQty
    WriteAvgPx strm xx.AvgPx
    xx.OrdRejReason |> Option.iter (WriteOrdRejReason strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteAllocationInstruction_NoExecsGrp (strm:System.IO.Stream) (xx:AllocationInstruction_NoExecsGrp) =
    xx.LastQty |> Option.iter (WriteLastQty strm)
    xx.ExecID |> Option.iter (WriteExecID strm)
    xx.SecondaryExecID |> Option.iter (WriteSecondaryExecID strm)
    xx.LastPx |> Option.iter (WriteLastPx strm)
    xx.LastParPx |> Option.iter (WriteLastParPx strm)
    xx.LastCapacity |> Option.iter (WriteLastCapacity strm)


// group
let WriteAllocationInstructionAck_NoAllocsGrp (strm:System.IO.Stream) (xx:AllocationInstructionAck_NoAllocsGrp) =
    xx.AllocAccount |> Option.iter (WriteAllocAccount strm)
    xx.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    xx.AllocPrice |> Option.iter (WriteAllocPrice strm)
    xx.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    xx.IndividualAllocRejCode |> Option.iter (WriteIndividualAllocRejCode strm)
    xx.AllocText |> Option.iter (WriteAllocText strm)
    xx.EncodedAllocText |> Option.iter (WriteEncodedAllocText strm)


// group
let WriteAllocationReport_NoExecsGrp (strm:System.IO.Stream) (xx:AllocationReport_NoExecsGrp) =
    xx.LastQty |> Option.iter (WriteLastQty strm)
    xx.ExecID |> Option.iter (WriteExecID strm)
    xx.SecondaryExecID |> Option.iter (WriteSecondaryExecID strm)
    xx.LastPx |> Option.iter (WriteLastPx strm)
    xx.LastParPx |> Option.iter (WriteLastParPx strm)
    xx.LastCapacity |> Option.iter (WriteLastCapacity strm)


// group
let WriteAllocationReportAck_NoAllocsGrp (strm:System.IO.Stream) (xx:AllocationReportAck_NoAllocsGrp) =
    xx.AllocAccount |> Option.iter (WriteAllocAccount strm)
    xx.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    xx.AllocPrice |> Option.iter (WriteAllocPrice strm)
    xx.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    xx.IndividualAllocRejCode |> Option.iter (WriteIndividualAllocRejCode strm)
    xx.AllocText |> Option.iter (WriteAllocText strm)
    xx.EncodedAllocText |> Option.iter (WriteEncodedAllocText strm)


// group
let WriteNoCapacitiesGrp (strm:System.IO.Stream) (xx:NoCapacitiesGrp) =
    WriteOrderCapacity strm xx.OrderCapacity
    xx.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    WriteOrderCapacityQty strm xx.OrderCapacityQty


// group
let WriteNoDatesGrp (strm:System.IO.Stream) (xx:NoDatesGrp) =
    xx.TradeDate |> Option.iter (WriteTradeDate strm)
    xx.TransactTime |> Option.iter (WriteTransactTime strm)


// group
let WriteNoDistribInstsGrp (strm:System.IO.Stream) (xx:NoDistribInstsGrp) =
    xx.DistribPaymentMethod |> Option.iter (WriteDistribPaymentMethod strm)
    xx.DistribPercentage |> Option.iter (WriteDistribPercentage strm)
    xx.CashDistribCurr |> Option.iter (WriteCashDistribCurr strm)
    xx.CashDistribAgentName |> Option.iter (WriteCashDistribAgentName strm)
    xx.CashDistribAgentCode |> Option.iter (WriteCashDistribAgentCode strm)
    xx.CashDistribAgentAcctNumber |> Option.iter (WriteCashDistribAgentAcctNumber strm)
    xx.CashDistribPayRef |> Option.iter (WriteCashDistribPayRef strm)
    xx.CashDistribAgentAcctName |> Option.iter (WriteCashDistribAgentAcctName strm)


// group
let WriteNoExecsGrp (strm:System.IO.Stream) (xx:NoExecsGrp) =
    xx.ExecID |> Option.iter (WriteExecID strm)


// group
let WriteNoTradesGrp (strm:System.IO.Stream) (xx:NoTradesGrp) =
    xx.TradeReportID |> Option.iter (WriteTradeReportID strm)
    xx.SecondaryTradeReportID |> Option.iter (WriteSecondaryTradeReportID strm)


// group
let WriteNoCollInquiryQualifierGrp (strm:System.IO.Stream) (xx:NoCollInquiryQualifierGrp) =
    xx.CollInquiryQualifier |> Option.iter (WriteCollInquiryQualifier strm)


// group
let WriteNoCompIDsGrp (strm:System.IO.Stream) (xx:NoCompIDsGrp) =
    xx.RefCompID |> Option.iter (WriteRefCompID strm)
    xx.RefSubID |> Option.iter (WriteRefSubID strm)
    xx.LocationID |> Option.iter (WriteLocationID strm)
    xx.DeskID |> Option.iter (WriteDeskID strm)


// group
let WriteNetworkStatusResponse_NoCompIDsGrp (strm:System.IO.Stream) (xx:NetworkStatusResponse_NoCompIDsGrp) =
    xx.RefCompID |> Option.iter (WriteRefCompID strm)
    xx.RefSubID |> Option.iter (WriteRefSubID strm)
    xx.LocationID |> Option.iter (WriteLocationID strm)
    xx.DeskID |> Option.iter (WriteDeskID strm)
    xx.StatusValue |> Option.iter (WriteStatusValue strm)
    xx.StatusText |> Option.iter (WriteStatusText strm)


// group
let WriteNoHopsGrp (strm:System.IO.Stream) (xx:NoHopsGrp) =
    xx.HopCompID |> Option.iter (WriteHopCompID strm)
    xx.HopSendingTime |> Option.iter (WriteHopSendingTime strm)
    xx.HopRefID |> Option.iter (WriteHopRefID strm)


