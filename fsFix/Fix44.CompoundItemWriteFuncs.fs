module Fix44.CompoundItemWriteFuncs

open Fix44.Fields
open Fix44.FieldReadWriteFuncs
open Fix44.CompoundItems


// group
let WriteNoUnderlyingSecurityAltIDGrp (strm:System.IO.Stream) (grp:NoUnderlyingSecurityAltIDGrp) =
    grp.UnderlyingSecurityAltID |> Option.iter (WriteUnderlyingSecurityAltID strm)
    grp.UnderlyingSecurityAltIDSource |> Option.iter (WriteUnderlyingSecurityAltIDSource strm)


// group
let WriteNoUnderlyingStipsGrp (strm:System.IO.Stream) (grp:NoUnderlyingStipsGrp) =
    grp.UnderlyingStipType |> Option.iter (WriteUnderlyingStipType strm)
    grp.UnderlyingStipValue |> Option.iter (WriteUnderlyingStipValue strm)


// component
let WriteUnderlyingStipulations (strm:System.IO.Stream) (grp:UnderlyingStipulations) =
    grp.NoUnderlyingStipsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyingStips strm (Fix44.Fields.NoUnderlyingStips numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingStipsGrp strm gg)    ) // end Option.iter


// component
let WriteUnderlyingInstrument (strm:System.IO.Stream) (grp:UnderlyingInstrument) =
    WriteUnderlyingSymbol strm grp.UnderlyingSymbol
    grp.UnderlyingSymbolSfx |> Option.iter (WriteUnderlyingSymbolSfx strm)
    grp.UnderlyingSecurityID |> Option.iter (WriteUnderlyingSecurityID strm)
    grp.UnderlyingSecurityIDSource |> Option.iter (WriteUnderlyingSecurityIDSource strm)
    grp.NoUnderlyingSecurityAltIDGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyingSecurityAltID strm (Fix44.Fields.NoUnderlyingSecurityAltID numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingSecurityAltIDGrp strm gg)    ) // end Option.iter
    grp.UnderlyingProduct |> Option.iter (WriteUnderlyingProduct strm)
    grp.UnderlyingCFICode |> Option.iter (WriteUnderlyingCFICode strm)
    grp.UnderlyingSecurityType |> Option.iter (WriteUnderlyingSecurityType strm)
    grp.UnderlyingSecuritySubType |> Option.iter (WriteUnderlyingSecuritySubType strm)
    grp.UnderlyingMaturityMonthYear |> Option.iter (WriteUnderlyingMaturityMonthYear strm)
    grp.UnderlyingMaturityDate |> Option.iter (WriteUnderlyingMaturityDate strm)
    grp.UnderlyingPutOrCall |> Option.iter (WriteUnderlyingPutOrCall strm)
    grp.UnderlyingCouponPaymentDate |> Option.iter (WriteUnderlyingCouponPaymentDate strm)
    grp.UnderlyingIssueDate |> Option.iter (WriteUnderlyingIssueDate strm)
    grp.UnderlyingRepoCollateralSecurityType |> Option.iter (WriteUnderlyingRepoCollateralSecurityType strm)
    grp.UnderlyingRepurchaseTerm |> Option.iter (WriteUnderlyingRepurchaseTerm strm)
    grp.UnderlyingRepurchaseRate |> Option.iter (WriteUnderlyingRepurchaseRate strm)
    grp.UnderlyingFactor |> Option.iter (WriteUnderlyingFactor strm)
    grp.UnderlyingCreditRating |> Option.iter (WriteUnderlyingCreditRating strm)
    grp.UnderlyingInstrRegistry |> Option.iter (WriteUnderlyingInstrRegistry strm)
    grp.UnderlyingCountryOfIssue |> Option.iter (WriteUnderlyingCountryOfIssue strm)
    grp.UnderlyingStateOrProvinceOfIssue |> Option.iter (WriteUnderlyingStateOrProvinceOfIssue strm)
    grp.UnderlyingLocaleOfIssue |> Option.iter (WriteUnderlyingLocaleOfIssue strm)
    grp.UnderlyingRedemptionDate |> Option.iter (WriteUnderlyingRedemptionDate strm)
    grp.UnderlyingStrikePrice |> Option.iter (WriteUnderlyingStrikePrice strm)
    grp.UnderlyingStrikeCurrency |> Option.iter (WriteUnderlyingStrikeCurrency strm)
    grp.UnderlyingOptAttribute |> Option.iter (WriteUnderlyingOptAttribute strm)
    grp.UnderlyingContractMultiplier |> Option.iter (WriteUnderlyingContractMultiplier strm)
    grp.UnderlyingCouponRate |> Option.iter (WriteUnderlyingCouponRate strm)
    grp.UnderlyingSecurityExchange |> Option.iter (WriteUnderlyingSecurityExchange strm)
    grp.UnderlyingIssuer |> Option.iter (WriteUnderlyingIssuer strm)
    grp.EncodedUnderlyingIssuer |> Option.iter (WriteEncodedUnderlyingIssuer strm)
    grp.UnderlyingSecurityDesc |> Option.iter (WriteUnderlyingSecurityDesc strm)
    grp.EncodedUnderlyingSecurityDesc |> Option.iter (WriteEncodedUnderlyingSecurityDesc strm)
    grp.UnderlyingCPProgram |> Option.iter (WriteUnderlyingCPProgram strm)
    grp.UnderlyingCPRegType |> Option.iter (WriteUnderlyingCPRegType strm)
    grp.UnderlyingCurrency |> Option.iter (WriteUnderlyingCurrency strm)
    grp.UnderlyingQty |> Option.iter (WriteUnderlyingQty strm)
    grp.UnderlyingPx |> Option.iter (WriteUnderlyingPx strm)
    grp.UnderlyingDirtyPrice |> Option.iter (WriteUnderlyingDirtyPrice strm)
    grp.UnderlyingEndPrice |> Option.iter (WriteUnderlyingEndPrice strm)
    grp.UnderlyingStartValue |> Option.iter (WriteUnderlyingStartValue strm)
    grp.UnderlyingCurrentValue |> Option.iter (WriteUnderlyingCurrentValue strm)
    grp.UnderlyingEndValue |> Option.iter (WriteUnderlyingEndValue strm)
    grp.UnderlyingStipulations |> Option.iter (WriteUnderlyingStipulations strm) // component


// group
let WriteCollateralResponse_NoUnderlyingsGrp (strm:System.IO.Stream) (grp:CollateralResponse_NoUnderlyingsGrp) =
    grp.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    grp.CollAction |> Option.iter (WriteCollAction strm)


// group
let WriteCollateralAssignment_NoUnderlyingsGrp (strm:System.IO.Stream) (grp:CollateralAssignment_NoUnderlyingsGrp) =
    grp.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    grp.CollAction |> Option.iter (WriteCollAction strm)


// group
let WriteCollateralRequest_NoUnderlyingsGrp (strm:System.IO.Stream) (grp:CollateralRequest_NoUnderlyingsGrp) =
    grp.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    grp.CollAction |> Option.iter (WriteCollAction strm)


// group
let WritePositionReport_NoUnderlyingsGrp (strm:System.IO.Stream) (grp:PositionReport_NoUnderlyingsGrp) =
    grp.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    WriteUnderlyingSettlPrice strm grp.UnderlyingSettlPrice
    WriteUnderlyingSettlPriceType strm grp.UnderlyingSettlPriceType


// group
let WriteNoNestedPartySubIDsGrp (strm:System.IO.Stream) (grp:NoNestedPartySubIDsGrp) =
    grp.NestedPartySubID |> Option.iter (WriteNestedPartySubID strm)
    grp.NestedPartySubIDType |> Option.iter (WriteNestedPartySubIDType strm)


// group
let WriteNoNestedPartyIDsGrp (strm:System.IO.Stream) (grp:NoNestedPartyIDsGrp) =
    grp.NestedPartyID |> Option.iter (WriteNestedPartyID strm)
    grp.NestedPartyIDSource |> Option.iter (WriteNestedPartyIDSource strm)
    grp.NestedPartyRole |> Option.iter (WriteNestedPartyRole strm)
    grp.NoNestedPartySubIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoNestedPartySubIDs strm (Fix44.Fields.NoNestedPartySubIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoNestedPartySubIDsGrp strm gg)    ) // end Option.iter


// component
let WriteNestedParties (strm:System.IO.Stream) (grp:NestedParties) =
    grp.NoNestedPartyIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoNestedPartyIDs strm (Fix44.Fields.NoNestedPartyIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoNestedPartyIDsGrp strm gg)    ) // end Option.iter


// group
let WriteNoPositionsGrp (strm:System.IO.Stream) (grp:NoPositionsGrp) =
    grp.PosType |> Option.iter (WritePosType strm)
    grp.LongQty |> Option.iter (WriteLongQty strm)
    grp.ShortQty |> Option.iter (WriteShortQty strm)
    grp.PosQtyStatus |> Option.iter (WritePosQtyStatus strm)
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component


// component
let WritePositionQty (strm:System.IO.Stream) (grp:PositionQty) =
    let numGrps = grp.NoPositionsGrp.Length
    WriteNoPositions strm (Fix44.Fields.NoPositions numGrps) // write the 'num group repeats' field
    grp.NoPositionsGrp |> List.iter (fun gg -> WriteNoPositionsGrp strm gg)


// group
let WriteNoRegistDtlsGrp (strm:System.IO.Stream) (grp:NoRegistDtlsGrp) =
    grp.RegistDtls |> Option.iter (WriteRegistDtls strm)
    grp.RegistEmail |> Option.iter (WriteRegistEmail strm)
    grp.MailingDtls |> Option.iter (WriteMailingDtls strm)
    grp.MailingInst |> Option.iter (WriteMailingInst strm)
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component
    grp.OwnerType |> Option.iter (WriteOwnerType strm)
    grp.DateOfBirth |> Option.iter (WriteDateOfBirth strm)
    grp.InvestorCountryOfResidence |> Option.iter (WriteInvestorCountryOfResidence strm)


// group
let WriteNoNested2PartySubIDsGrp (strm:System.IO.Stream) (grp:NoNested2PartySubIDsGrp) =
    grp.Nested2PartySubID |> Option.iter (WriteNested2PartySubID strm)
    grp.Nested2PartySubIDType |> Option.iter (WriteNested2PartySubIDType strm)


// group
let WriteNoNested2PartyIDsGrp (strm:System.IO.Stream) (grp:NoNested2PartyIDsGrp) =
    grp.Nested2PartyID |> Option.iter (WriteNested2PartyID strm)
    grp.Nested2PartyIDSource |> Option.iter (WriteNested2PartyIDSource strm)
    grp.Nested2PartyRole |> Option.iter (WriteNested2PartyRole strm)
    grp.NoNested2PartySubIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoNested2PartySubIDs strm (Fix44.Fields.NoNested2PartySubIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoNested2PartySubIDsGrp strm gg)    ) // end Option.iter


// component
let WriteNestedParties2 (strm:System.IO.Stream) (grp:NestedParties2) =
    grp.NoNested2PartyIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoNested2PartyIDs strm (Fix44.Fields.NoNested2PartyIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoNested2PartyIDsGrp strm gg)    ) // end Option.iter


// group
let WriteTradeCaptureReportAck_NoAllocsGrp (strm:System.IO.Stream) (grp:TradeCaptureReportAck_NoAllocsGrp) =
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    grp.NestedParties2 |> Option.iter (WriteNestedParties2 strm) // component
    grp.AllocQty |> Option.iter (WriteAllocQty strm)


// group
let WriteNoLegSecurityAltIDGrp (strm:System.IO.Stream) (grp:NoLegSecurityAltIDGrp) =
    grp.LegSecurityAltID |> Option.iter (WriteLegSecurityAltID strm)
    grp.LegSecurityAltIDSource |> Option.iter (WriteLegSecurityAltIDSource strm)


// component
let WriteInstrumentLeg (strm:System.IO.Stream) (grp:InstrumentLeg) =
    grp.LegSymbol |> Option.iter (WriteLegSymbol strm)
    grp.LegSymbolSfx |> Option.iter (WriteLegSymbolSfx strm)
    grp.LegSecurityID |> Option.iter (WriteLegSecurityID strm)
    grp.LegSecurityIDSource |> Option.iter (WriteLegSecurityIDSource strm)
    grp.NoLegSecurityAltIDGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegSecurityAltID strm (Fix44.Fields.NoLegSecurityAltID numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegSecurityAltIDGrp strm gg)    ) // end Option.iter
    grp.LegProduct |> Option.iter (WriteLegProduct strm)
    grp.LegCFICode |> Option.iter (WriteLegCFICode strm)
    grp.LegSecurityType |> Option.iter (WriteLegSecurityType strm)
    grp.LegSecuritySubType |> Option.iter (WriteLegSecuritySubType strm)
    grp.LegMaturityMonthYear |> Option.iter (WriteLegMaturityMonthYear strm)
    grp.LegMaturityDate |> Option.iter (WriteLegMaturityDate strm)
    grp.LegCouponPaymentDate |> Option.iter (WriteLegCouponPaymentDate strm)
    grp.LegIssueDate |> Option.iter (WriteLegIssueDate strm)
    grp.LegRepoCollateralSecurityType |> Option.iter (WriteLegRepoCollateralSecurityType strm)
    grp.LegRepurchaseTerm |> Option.iter (WriteLegRepurchaseTerm strm)
    grp.LegRepurchaseRate |> Option.iter (WriteLegRepurchaseRate strm)
    grp.LegFactor |> Option.iter (WriteLegFactor strm)
    grp.LegCreditRating |> Option.iter (WriteLegCreditRating strm)
    grp.LegInstrRegistry |> Option.iter (WriteLegInstrRegistry strm)
    grp.LegCountryOfIssue |> Option.iter (WriteLegCountryOfIssue strm)
    grp.LegStateOrProvinceOfIssue |> Option.iter (WriteLegStateOrProvinceOfIssue strm)
    grp.LegLocaleOfIssue |> Option.iter (WriteLegLocaleOfIssue strm)
    grp.LegRedemptionDate |> Option.iter (WriteLegRedemptionDate strm)
    grp.LegStrikePrice |> Option.iter (WriteLegStrikePrice strm)
    grp.LegStrikeCurrency |> Option.iter (WriteLegStrikeCurrency strm)
    grp.LegOptAttribute |> Option.iter (WriteLegOptAttribute strm)
    grp.LegContractMultiplier |> Option.iter (WriteLegContractMultiplier strm)
    grp.LegCouponRate |> Option.iter (WriteLegCouponRate strm)
    grp.LegSecurityExchange |> Option.iter (WriteLegSecurityExchange strm)
    grp.LegIssuer |> Option.iter (WriteLegIssuer strm)
    grp.EncodedLegIssuer |> Option.iter (WriteEncodedLegIssuer strm)
    grp.LegSecurityDesc |> Option.iter (WriteLegSecurityDesc strm)
    grp.EncodedLegSecurityDesc |> Option.iter (WriteEncodedLegSecurityDesc strm)
    grp.LegRatioQty |> Option.iter (WriteLegRatioQty strm)
    grp.LegSide |> Option.iter (WriteLegSide strm)
    grp.LegCurrency |> Option.iter (WriteLegCurrency strm)
    grp.LegPool |> Option.iter (WriteLegPool strm)
    grp.LegDatedDate |> Option.iter (WriteLegDatedDate strm)
    grp.LegContractSettlMonth |> Option.iter (WriteLegContractSettlMonth strm)
    grp.LegInterestAccrualDate |> Option.iter (WriteLegInterestAccrualDate strm)


// group
let WriteNoLegStipulationsGrp (strm:System.IO.Stream) (grp:NoLegStipulationsGrp) =
    grp.LegStipulationType |> Option.iter (WriteLegStipulationType strm)
    grp.LegStipulationValue |> Option.iter (WriteLegStipulationValue strm)


// component
let WriteLegStipulations (strm:System.IO.Stream) (grp:LegStipulations) =
    grp.NoLegStipulationsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegStipulations strm (Fix44.Fields.NoLegStipulations numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegStipulationsGrp strm gg)    ) // end Option.iter


// group
let WriteTradeCaptureReportAck_NoLegsGrp (strm:System.IO.Stream) (grp:TradeCaptureReportAck_NoLegsGrp) =
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    grp.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    grp.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component
    grp.LegRefID |> Option.iter (WriteLegRefID strm)
    grp.LegPrice |> Option.iter (WriteLegPrice strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    grp.LegLastPx |> Option.iter (WriteLegLastPx strm)


// group
let WriteNoPartySubIDsGrp (strm:System.IO.Stream) (grp:NoPartySubIDsGrp) =
    grp.PartySubID |> Option.iter (WritePartySubID strm)
    grp.PartySubIDType |> Option.iter (WritePartySubIDType strm)


// group
let WriteNoPartyIDsGrp (strm:System.IO.Stream) (grp:NoPartyIDsGrp) =
    grp.PartyID |> Option.iter (WritePartyID strm)
    grp.PartyIDSource |> Option.iter (WritePartyIDSource strm)
    grp.PartyRole |> Option.iter (WritePartyRole strm)
    grp.NoPartySubIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoPartySubIDs strm (Fix44.Fields.NoPartySubIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoPartySubIDsGrp strm gg)    ) // end Option.iter


// component
let WriteParties (strm:System.IO.Stream) (grp:Parties) =
    grp.NoPartyIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoPartyIDs strm (Fix44.Fields.NoPartyIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoPartyIDsGrp strm gg)    ) // end Option.iter


// group
let WriteNoClearingInstructionsGrp (strm:System.IO.Stream) (grp:NoClearingInstructionsGrp) =
    grp.ClearingInstruction |> Option.iter (WriteClearingInstruction strm)


// component
let WriteCommissionData (strm:System.IO.Stream) (grp:CommissionData) =
    grp.Commission |> Option.iter (WriteCommission strm)
    grp.CommType |> Option.iter (WriteCommType strm)
    grp.CommCurrency |> Option.iter (WriteCommCurrency strm)
    grp.FundRenewWaiv |> Option.iter (WriteFundRenewWaiv strm)


// group
let WriteNoContAmtsGrp (strm:System.IO.Stream) (grp:NoContAmtsGrp) =
    grp.ContAmtType |> Option.iter (WriteContAmtType strm)
    grp.ContAmtValue |> Option.iter (WriteContAmtValue strm)
    grp.ContAmtCurr |> Option.iter (WriteContAmtCurr strm)


// group
let WriteNoStipulationsGrp (strm:System.IO.Stream) (grp:NoStipulationsGrp) =
    grp.StipulationType |> Option.iter (WriteStipulationType strm)
    grp.StipulationValue |> Option.iter (WriteStipulationValue strm)


// component
let WriteStipulations (strm:System.IO.Stream) (grp:Stipulations) =
    grp.NoStipulationsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoStipulations strm (Fix44.Fields.NoStipulations numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoStipulationsGrp strm gg)    ) // end Option.iter


// group
let WriteNoMiscFeesGrp (strm:System.IO.Stream) (grp:NoMiscFeesGrp) =
    grp.MiscFeeAmt |> Option.iter (WriteMiscFeeAmt strm)
    grp.MiscFeeCurr |> Option.iter (WriteMiscFeeCurr strm)
    grp.MiscFeeType |> Option.iter (WriteMiscFeeType strm)
    grp.MiscFeeBasis |> Option.iter (WriteMiscFeeBasis strm)


// group
let WriteTradeCaptureReport_NoSidesGrp (strm:System.IO.Stream) (grp:TradeCaptureReport_NoSidesGrp) =
    WriteSide strm grp.Side
    WriteOrderID strm grp.OrderID
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.ListID |> Option.iter (WriteListID strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.ProcessCode |> Option.iter (WriteProcessCode strm)
    grp.OddLot |> Option.iter (WriteOddLot strm)
    grp.NoClearingInstructionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoClearingInstructions strm (Fix44.Fields.NoClearingInstructions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoClearingInstructionsGrp strm gg)    ) // end Option.iter
    grp.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    grp.TradeInputSource |> Option.iter (WriteTradeInputSource strm)
    grp.TradeInputDevice |> Option.iter (WriteTradeInputDevice strm)
    grp.OrderInputDevice |> Option.iter (WriteOrderInputDevice strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.ComplianceID |> Option.iter (WriteComplianceID strm)
    grp.SolicitedFlag |> Option.iter (WriteSolicitedFlag strm)
    grp.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    grp.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    grp.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    grp.OrdType |> Option.iter (WriteOrdType strm)
    grp.ExecInst |> Option.iter (WriteExecInst strm)
    grp.TransBkdTime |> Option.iter (WriteTransBkdTime strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.TimeBracket |> Option.iter (WriteTimeBracket strm)
    grp.CommissionData |> Option.iter (WriteCommissionData strm) // component
    grp.GrossTradeAmt |> Option.iter (WriteGrossTradeAmt strm)
    grp.NumDaysInterest |> Option.iter (WriteNumDaysInterest strm)
    grp.ExDate |> Option.iter (WriteExDate strm)
    grp.AccruedInterestRate |> Option.iter (WriteAccruedInterestRate strm)
    grp.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    grp.InterestAtMaturity |> Option.iter (WriteInterestAtMaturity strm)
    grp.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    grp.StartCash |> Option.iter (WriteStartCash strm)
    grp.EndCash |> Option.iter (WriteEndCash strm)
    grp.Concession |> Option.iter (WriteConcession strm)
    grp.TotalTakedown |> Option.iter (WriteTotalTakedown strm)
    grp.NetMoney |> Option.iter (WriteNetMoney strm)
    grp.SettlCurrAmt |> Option.iter (WriteSettlCurrAmt strm)
    grp.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    grp.SettlCurrFxRate |> Option.iter (WriteSettlCurrFxRate strm)
    grp.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    grp.PositionEffect |> Option.iter (WritePositionEffect strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.SideMultiLegReportingType |> Option.iter (WriteSideMultiLegReportingType strm)
    grp.NoContAmtsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoContAmts strm (Fix44.Fields.NoContAmts numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoContAmtsGrp strm gg)    ) // end Option.iter
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    grp.ExchangeRule |> Option.iter (WriteExchangeRule strm)
    grp.TradeAllocIndicator |> Option.iter (WriteTradeAllocIndicator strm)
    grp.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    grp.AllocID |> Option.iter (WriteAllocID strm)


// group
let WriteTradeCaptureReport_NoLegsGrp (strm:System.IO.Stream) (grp:TradeCaptureReport_NoLegsGrp) =
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    grp.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    grp.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component
    grp.LegRefID |> Option.iter (WriteLegRefID strm)
    grp.LegPrice |> Option.iter (WriteLegPrice strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    grp.LegLastPx |> Option.iter (WriteLegLastPx strm)


// group
let WriteNoPosAmtGrp (strm:System.IO.Stream) (grp:NoPosAmtGrp) =
    WritePosAmtType strm grp.PosAmtType
    WritePosAmt strm grp.PosAmt


// component
let WritePositionAmountData (strm:System.IO.Stream) (grp:PositionAmountData) =
    let numGrps = grp.NoPosAmtGrp.Length
    WriteNoPosAmt strm (Fix44.Fields.NoPosAmt numGrps) // write the 'num group repeats' field
    grp.NoPosAmtGrp |> List.iter (fun gg -> WriteNoPosAmtGrp strm gg)


// group
let WriteNoSettlPartySubIDsGrp (strm:System.IO.Stream) (grp:NoSettlPartySubIDsGrp) =
    grp.SettlPartySubID |> Option.iter (WriteSettlPartySubID strm)
    grp.SettlPartySubIDType |> Option.iter (WriteSettlPartySubIDType strm)


// group
let WriteNoSettlPartyIDsGrp (strm:System.IO.Stream) (grp:NoSettlPartyIDsGrp) =
    grp.SettlPartyID |> Option.iter (WriteSettlPartyID strm)
    grp.SettlPartyIDSource |> Option.iter (WriteSettlPartyIDSource strm)
    grp.SettlPartyRole |> Option.iter (WriteSettlPartyRole strm)
    grp.NoSettlPartySubIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoSettlPartySubIDs strm (Fix44.Fields.NoSettlPartySubIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoSettlPartySubIDsGrp strm gg)    ) // end Option.iter


// component
let WriteSettlParties (strm:System.IO.Stream) (grp:SettlParties) =
    grp.NoSettlPartyIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoSettlPartyIDs strm (Fix44.Fields.NoSettlPartyIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoSettlPartyIDsGrp strm gg)    ) // end Option.iter


// group
let WriteNoDlvyInstGrp (strm:System.IO.Stream) (grp:NoDlvyInstGrp) =
    grp.SettlInstSource |> Option.iter (WriteSettlInstSource strm)
    grp.DlvyInstType |> Option.iter (WriteDlvyInstType strm)
    grp.SettlParties |> Option.iter (WriteSettlParties strm) // component


// component
let WriteSettlInstructionsData (strm:System.IO.Stream) (grp:SettlInstructionsData) =
    grp.SettlDeliveryType |> Option.iter (WriteSettlDeliveryType strm)
    grp.StandInstDbType |> Option.iter (WriteStandInstDbType strm)
    grp.StandInstDbName |> Option.iter (WriteStandInstDbName strm)
    grp.StandInstDbID |> Option.iter (WriteStandInstDbID strm)
    grp.NoDlvyInstGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoDlvyInst strm (Fix44.Fields.NoDlvyInst numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoDlvyInstGrp strm gg)    ) // end Option.iter


// group
let WriteNoSettlInstGrp (strm:System.IO.Stream) (grp:NoSettlInstGrp) =
    grp.SettlInstID |> Option.iter (WriteSettlInstID strm)
    grp.SettlInstTransType |> Option.iter (WriteSettlInstTransType strm)
    grp.SettlInstRefID |> Option.iter (WriteSettlInstRefID strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Side |> Option.iter (WriteSide strm)
    grp.Product |> Option.iter (WriteProduct strm)
    grp.SecurityType |> Option.iter (WriteSecurityType strm)
    grp.CFICode |> Option.iter (WriteCFICode strm)
    grp.EffectiveTime |> Option.iter (WriteEffectiveTime strm)
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.LastUpdateTime |> Option.iter (WriteLastUpdateTime strm)
    grp.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component
    grp.PaymentMethod |> Option.iter (WritePaymentMethod strm)
    grp.PaymentRef |> Option.iter (WritePaymentRef strm)
    grp.CardHolderName |> Option.iter (WriteCardHolderName strm)
    grp.CardNumber |> Option.iter (WriteCardNumber strm)
    grp.CardStartDate |> Option.iter (WriteCardStartDate strm)
    grp.CardExpDate |> Option.iter (WriteCardExpDate strm)
    grp.CardIssNum |> Option.iter (WriteCardIssNum strm)
    grp.PaymentDate |> Option.iter (WritePaymentDate strm)
    grp.PaymentRemitterID |> Option.iter (WritePaymentRemitterID strm)


// group
let WriteNoTrdRegTimestampsGrp (strm:System.IO.Stream) (grp:NoTrdRegTimestampsGrp) =
    grp.TrdRegTimestamp |> Option.iter (WriteTrdRegTimestamp strm)
    grp.TrdRegTimestampType |> Option.iter (WriteTrdRegTimestampType strm)
    grp.TrdRegTimestampOrigin |> Option.iter (WriteTrdRegTimestampOrigin strm)


// component
let WriteTrdRegTimestamps (strm:System.IO.Stream) (grp:TrdRegTimestamps) =
    let numGrps = grp.NoTrdRegTimestampsGrp.Length
    WriteNoTrdRegTimestamps strm (Fix44.Fields.NoTrdRegTimestamps numGrps) // write the 'num group repeats' field
    grp.NoTrdRegTimestampsGrp |> List.iter (fun gg -> WriteNoTrdRegTimestampsGrp strm gg)


// group
let WriteAllocationReport_NoAllocsGrp (strm:System.IO.Stream) (grp:AllocationReport_NoAllocsGrp) =
    WriteAllocAccount strm grp.AllocAccount
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.MatchStatus |> Option.iter (WriteMatchStatus strm)
    grp.AllocPrice |> Option.iter (WriteAllocPrice strm)
    WriteAllocQty strm grp.AllocQty
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    grp.ProcessCode |> Option.iter (WriteProcessCode strm)
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component
    grp.NotifyBrokerOfCredit |> Option.iter (WriteNotifyBrokerOfCredit strm)
    grp.AllocHandlInst |> Option.iter (WriteAllocHandlInst strm)
    grp.AllocText |> Option.iter (WriteAllocText strm)
    grp.EncodedAllocText |> Option.iter (WriteEncodedAllocText strm)
    grp.CommissionData |> Option.iter (WriteCommissionData strm) // component
    grp.AllocAvgPx |> Option.iter (WriteAllocAvgPx strm)
    grp.AllocNetMoney |> Option.iter (WriteAllocNetMoney strm)
    grp.SettlCurrAmt |> Option.iter (WriteSettlCurrAmt strm)
    grp.AllocSettlCurrAmt |> Option.iter (WriteAllocSettlCurrAmt strm)
    grp.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    grp.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    grp.SettlCurrFxRate |> Option.iter (WriteSettlCurrFxRate strm)
    grp.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    grp.AllocAccruedInterestAmt |> Option.iter (WriteAllocAccruedInterestAmt strm)
    grp.AllocInterestAtMaturity |> Option.iter (WriteAllocInterestAtMaturity strm)
    grp.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    grp.NoClearingInstructionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoClearingInstructions strm (Fix44.Fields.NoClearingInstructions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoClearingInstructionsGrp strm gg)    ) // end Option.iter
    grp.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    grp.AllocSettlInstType |> Option.iter (WriteAllocSettlInstType strm)
    grp.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component


// group
let WriteAllocationInstruction_NoAllocsGrp (strm:System.IO.Stream) (grp:AllocationInstruction_NoAllocsGrp) =
    WriteAllocAccount strm grp.AllocAccount
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.MatchStatus |> Option.iter (WriteMatchStatus strm)
    grp.AllocPrice |> Option.iter (WriteAllocPrice strm)
    grp.AllocQty |> Option.iter (WriteAllocQty strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    grp.ProcessCode |> Option.iter (WriteProcessCode strm)
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component
    grp.NotifyBrokerOfCredit |> Option.iter (WriteNotifyBrokerOfCredit strm)
    grp.AllocHandlInst |> Option.iter (WriteAllocHandlInst strm)
    grp.AllocText |> Option.iter (WriteAllocText strm)
    grp.EncodedAllocText |> Option.iter (WriteEncodedAllocText strm)
    grp.CommissionData |> Option.iter (WriteCommissionData strm) // component
    grp.AllocAvgPx |> Option.iter (WriteAllocAvgPx strm)
    grp.AllocNetMoney |> Option.iter (WriteAllocNetMoney strm)
    grp.SettlCurrAmt |> Option.iter (WriteSettlCurrAmt strm)
    grp.AllocSettlCurrAmt |> Option.iter (WriteAllocSettlCurrAmt strm)
    grp.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    grp.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    grp.SettlCurrFxRate |> Option.iter (WriteSettlCurrFxRate strm)
    grp.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    grp.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    grp.AllocAccruedInterestAmt |> Option.iter (WriteAllocAccruedInterestAmt strm)
    grp.AllocInterestAtMaturity |> Option.iter (WriteAllocInterestAtMaturity strm)
    grp.SettlInstMode |> Option.iter (WriteSettlInstMode strm)
    grp.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    grp.NoClearingInstructions |> Option.iter (WriteNoClearingInstructions strm)
    grp.ClearingInstruction |> Option.iter (WriteClearingInstruction strm)
    grp.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    grp.AllocSettlInstType |> Option.iter (WriteAllocSettlInstType strm)
    grp.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component


// group
let WriteNoOrdersGrp (strm:System.IO.Stream) (grp:NoOrdersGrp) =
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.OrderID |> Option.iter (WriteOrderID strm)
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.ListID |> Option.iter (WriteListID strm)
    grp.NestedParties2 |> Option.iter (WriteNestedParties2 strm) // component
    grp.OrderQty |> Option.iter (WriteOrderQty strm)
    grp.OrderAvgPx |> Option.iter (WriteOrderAvgPx strm)
    grp.OrderBookingQty |> Option.iter (WriteOrderBookingQty strm)


// group
let WriteListStrikePrice_NoUnderlyingsGrp (strm:System.IO.Stream) (grp:ListStrikePrice_NoUnderlyingsGrp) =
    grp.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.Side |> Option.iter (WriteSide strm)
    WritePrice strm grp.Price
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteNoSecurityAltIDGrp (strm:System.IO.Stream) (grp:NoSecurityAltIDGrp) =
    grp.SecurityAltID |> Option.iter (WriteSecurityAltID strm)
    grp.SecurityAltIDSource |> Option.iter (WriteSecurityAltIDSource strm)


// group
let WriteNoEventsGrp (strm:System.IO.Stream) (grp:NoEventsGrp) =
    grp.EventType |> Option.iter (WriteEventType strm)
    grp.EventDate |> Option.iter (WriteEventDate strm)
    grp.EventPx |> Option.iter (WriteEventPx strm)
    grp.EventText |> Option.iter (WriteEventText strm)


// component
let WriteInstrument (strm:System.IO.Stream) (grp:Instrument) =
    WriteSymbol strm grp.Symbol
    grp.SymbolSfx |> Option.iter (WriteSymbolSfx strm)
    grp.SecurityID |> Option.iter (WriteSecurityID strm)
    grp.SecurityIDSource |> Option.iter (WriteSecurityIDSource strm)
    grp.NoSecurityAltIDGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoSecurityAltID strm (Fix44.Fields.NoSecurityAltID numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoSecurityAltIDGrp strm gg)    ) // end Option.iter
    grp.Product |> Option.iter (WriteProduct strm)
    grp.CFICode |> Option.iter (WriteCFICode strm)
    grp.SecurityType |> Option.iter (WriteSecurityType strm)
    grp.SecuritySubType |> Option.iter (WriteSecuritySubType strm)
    grp.MaturityMonthYear |> Option.iter (WriteMaturityMonthYear strm)
    grp.MaturityDate |> Option.iter (WriteMaturityDate strm)
    grp.PutOrCall |> Option.iter (WritePutOrCall strm)
    grp.CouponPaymentDate |> Option.iter (WriteCouponPaymentDate strm)
    grp.IssueDate |> Option.iter (WriteIssueDate strm)
    grp.RepoCollateralSecurityType |> Option.iter (WriteRepoCollateralSecurityType strm)
    grp.RepurchaseTerm |> Option.iter (WriteRepurchaseTerm strm)
    grp.RepurchaseRate |> Option.iter (WriteRepurchaseRate strm)
    grp.Factor |> Option.iter (WriteFactor strm)
    grp.CreditRating |> Option.iter (WriteCreditRating strm)
    grp.InstrRegistry |> Option.iter (WriteInstrRegistry strm)
    grp.CountryOfIssue |> Option.iter (WriteCountryOfIssue strm)
    grp.StateOrProvinceOfIssue |> Option.iter (WriteStateOrProvinceOfIssue strm)
    grp.LocaleOfIssue |> Option.iter (WriteLocaleOfIssue strm)
    grp.RedemptionDate |> Option.iter (WriteRedemptionDate strm)
    grp.StrikePrice |> Option.iter (WriteStrikePrice strm)
    grp.StrikeCurrency |> Option.iter (WriteStrikeCurrency strm)
    grp.OptAttribute |> Option.iter (WriteOptAttribute strm)
    grp.ContractMultiplier |> Option.iter (WriteContractMultiplier strm)
    grp.CouponRate |> Option.iter (WriteCouponRate strm)
    grp.SecurityExchange |> Option.iter (WriteSecurityExchange strm)
    grp.Issuer |> Option.iter (WriteIssuer strm)
    grp.EncodedIssuer |> Option.iter (WriteEncodedIssuer strm)
    grp.SecurityDesc |> Option.iter (WriteSecurityDesc strm)
    grp.EncodedSecurityDesc |> Option.iter (WriteEncodedSecurityDesc strm)
    grp.Pool |> Option.iter (WritePool strm)
    grp.ContractSettlMonth |> Option.iter (WriteContractSettlMonth strm)
    grp.CPProgram |> Option.iter (WriteCPProgram strm)
    grp.CPRegType |> Option.iter (WriteCPRegType strm)
    grp.NoEventsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoEvents strm (Fix44.Fields.NoEvents numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoEventsGrp strm gg)    ) // end Option.iter
    grp.DatedDate |> Option.iter (WriteDatedDate strm)
    grp.InterestAccrualDate |> Option.iter (WriteInterestAccrualDate strm)


// group
let WriteNoStrikesGrp (strm:System.IO.Stream) (grp:NoStrikesGrp) =
    WriteInstrument strm grp.Instrument    // component


// group
let WriteNoAllocsGrp (strm:System.IO.Stream) (grp:NoAllocsGrp) =
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component
    grp.AllocQty |> Option.iter (WriteAllocQty strm)


// group
let WriteNoTradingSessionsGrp (strm:System.IO.Stream) (grp:NoTradingSessionsGrp) =
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)


// group
let WriteNoUnderlyingsGrp (strm:System.IO.Stream) (grp:NoUnderlyingsGrp) =
    grp.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component


// component
let WriteOrderQtyData (strm:System.IO.Stream) (grp:OrderQtyData) =
    grp.OrderQty |> Option.iter (WriteOrderQty strm)
    grp.CashOrderQty |> Option.iter (WriteCashOrderQty strm)
    grp.OrderPercent |> Option.iter (WriteOrderPercent strm)
    grp.RoundingDirection |> Option.iter (WriteRoundingDirection strm)
    grp.RoundingModulus |> Option.iter (WriteRoundingModulus strm)


// component
let WriteSpreadOrBenchmarkCurveData (strm:System.IO.Stream) (grp:SpreadOrBenchmarkCurveData) =
    grp.Spread |> Option.iter (WriteSpread strm)
    grp.BenchmarkCurveCurrency |> Option.iter (WriteBenchmarkCurveCurrency strm)
    grp.BenchmarkCurveName |> Option.iter (WriteBenchmarkCurveName strm)
    grp.BenchmarkCurvePoint |> Option.iter (WriteBenchmarkCurvePoint strm)
    grp.BenchmarkPrice |> Option.iter (WriteBenchmarkPrice strm)
    grp.BenchmarkPriceType |> Option.iter (WriteBenchmarkPriceType strm)
    grp.BenchmarkSecurityID |> Option.iter (WriteBenchmarkSecurityID strm)
    grp.BenchmarkSecurityIDSource |> Option.iter (WriteBenchmarkSecurityIDSource strm)


// component
let WriteYieldData (strm:System.IO.Stream) (grp:YieldData) =
    grp.YieldType |> Option.iter (WriteYieldType strm)
    grp.Yield |> Option.iter (WriteYield strm)
    grp.YieldCalcDate |> Option.iter (WriteYieldCalcDate strm)
    grp.YieldRedemptionDate |> Option.iter (WriteYieldRedemptionDate strm)
    grp.YieldRedemptionPrice |> Option.iter (WriteYieldRedemptionPrice strm)
    grp.YieldRedemptionPriceType |> Option.iter (WriteYieldRedemptionPriceType strm)


// component
let WritePegInstructions (strm:System.IO.Stream) (grp:PegInstructions) =
    grp.PegOffsetValue |> Option.iter (WritePegOffsetValue strm)
    grp.PegMoveType |> Option.iter (WritePegMoveType strm)
    grp.PegOffsetType |> Option.iter (WritePegOffsetType strm)
    grp.PegLimitType |> Option.iter (WritePegLimitType strm)
    grp.PegRoundDirection |> Option.iter (WritePegRoundDirection strm)
    grp.PegScope |> Option.iter (WritePegScope strm)


// component
let WriteDiscretionInstructions (strm:System.IO.Stream) (grp:DiscretionInstructions) =
    grp.DiscretionInst |> Option.iter (WriteDiscretionInst strm)
    grp.DiscretionOffsetValue |> Option.iter (WriteDiscretionOffsetValue strm)
    grp.DiscretionMoveType |> Option.iter (WriteDiscretionMoveType strm)
    grp.DiscretionOffsetType |> Option.iter (WriteDiscretionOffsetType strm)
    grp.DiscretionLimitType |> Option.iter (WriteDiscretionLimitType strm)
    grp.DiscretionRoundDirection |> Option.iter (WriteDiscretionRoundDirection strm)
    grp.DiscretionScope |> Option.iter (WriteDiscretionScope strm)


// group
let WriteNewOrderList_NoOrdersGrp (strm:System.IO.Stream) (grp:NewOrderList_NoOrdersGrp) =
    WriteClOrdID strm grp.ClOrdID
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    WriteListSeqNo strm grp.ListSeqNo
    grp.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    grp.SettlInstMode |> Option.iter (WriteSettlInstMode strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.DayBookingInst |> Option.iter (WriteDayBookingInst strm)
    grp.BookingUnit |> Option.iter (WriteBookingUnit strm)
    grp.AllocID |> Option.iter (WriteAllocID strm)
    grp.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    grp.NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoAllocsGrp strm gg)    ) // end Option.iter
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.CashMargin |> Option.iter (WriteCashMargin strm)
    grp.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    grp.HandlInst |> Option.iter (WriteHandlInst strm)
    grp.ExecInst |> Option.iter (WriteExecInst strm)
    grp.MinQty |> Option.iter (WriteMinQty strm)
    grp.MaxFloor |> Option.iter (WriteMaxFloor strm)
    grp.ExDestination |> Option.iter (WriteExDestination strm)
    grp.NoTradingSessionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTradingSessions strm (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradingSessionsGrp strm gg)    ) // end Option.iter
    grp.ProcessCode |> Option.iter (WriteProcessCode strm)
    WriteInstrument strm grp.Instrument    // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    WriteSide strm grp.Side
    grp.SideValueInd |> Option.iter (WriteSideValueInd strm)
    grp.LocateReqd |> Option.iter (WriteLocateReqd strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm grp.OrderQtyData    // component
    grp.OrdType |> Option.iter (WriteOrdType strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.StopPx |> Option.iter (WriteStopPx strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.ComplianceID |> Option.iter (WriteComplianceID strm)
    grp.SolicitedFlag |> Option.iter (WriteSolicitedFlag strm)
    grp.IOIid |> Option.iter (WriteIOIid strm)
    grp.QuoteID |> Option.iter (WriteQuoteID strm)
    grp.TimeInForce |> Option.iter (WriteTimeInForce strm)
    grp.EffectiveTime |> Option.iter (WriteEffectiveTime strm)
    grp.ExpireDate |> Option.iter (WriteExpireDate strm)
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.GTBookingInst |> Option.iter (WriteGTBookingInst strm)
    grp.CommissionData |> Option.iter (WriteCommissionData strm) // component
    grp.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    grp.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    grp.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    grp.ForexReq |> Option.iter (WriteForexReq strm)
    grp.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    grp.BookingType |> Option.iter (WriteBookingType strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    grp.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    grp.Price2 |> Option.iter (WritePrice2 strm)
    grp.PositionEffect |> Option.iter (WritePositionEffect strm)
    grp.CoveredOrUncovered |> Option.iter (WriteCoveredOrUncovered strm)
    grp.MaxShow |> Option.iter (WriteMaxShow strm)
    grp.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    grp.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    grp.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    grp.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    grp.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    grp.Designation |> Option.iter (WriteDesignation strm)


// group
let WriteBidResponse_NoBidComponentsGrp (strm:System.IO.Stream) (grp:BidResponse_NoBidComponentsGrp) =
    WriteCommissionData strm grp.CommissionData    // component
    grp.ListID |> Option.iter (WriteListID strm)
    grp.Country |> Option.iter (WriteCountry strm)
    grp.Side |> Option.iter (WriteSide strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.FairValue |> Option.iter (WriteFairValue strm)
    grp.NetGrossInd |> Option.iter (WriteNetGrossInd strm)
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteNoLegAllocsGrp (strm:System.IO.Stream) (grp:NoLegAllocsGrp) =
    grp.LegAllocAccount |> Option.iter (WriteLegAllocAccount strm)
    grp.LegIndividualAllocID |> Option.iter (WriteLegIndividualAllocID strm)
    grp.NestedParties2 |> Option.iter (WriteNestedParties2 strm) // component
    grp.LegAllocQty |> Option.iter (WriteLegAllocQty strm)
    grp.LegAllocAcctIDSource |> Option.iter (WriteLegAllocAcctIDSource strm)
    grp.LegSettlCurrency |> Option.iter (WriteLegSettlCurrency strm)


// group
let WriteMultilegOrderCancelReplaceRequest_NoLegsGrp (strm:System.IO.Stream) (grp:MultilegOrderCancelReplaceRequest_NoLegsGrp) =
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    grp.NoLegAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegAllocs strm (Fix44.Fields.NoLegAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegAllocsGrp strm gg)    ) // end Option.iter
    grp.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    grp.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component
    grp.LegRefID |> Option.iter (WriteLegRefID strm)
    grp.LegPrice |> Option.iter (WriteLegPrice strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)


// group
let WriteNoNested3PartySubIDsGrp (strm:System.IO.Stream) (grp:NoNested3PartySubIDsGrp) =
    grp.Nested3PartySubID |> Option.iter (WriteNested3PartySubID strm)
    grp.Nested3PartySubIDType |> Option.iter (WriteNested3PartySubIDType strm)


// group
let WriteNoNested3PartyIDsGrp (strm:System.IO.Stream) (grp:NoNested3PartyIDsGrp) =
    grp.Nested3PartyID |> Option.iter (WriteNested3PartyID strm)
    grp.Nested3PartyIDSource |> Option.iter (WriteNested3PartyIDSource strm)
    grp.Nested3PartyRole |> Option.iter (WriteNested3PartyRole strm)
    grp.NoNested3PartySubIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoNested3PartySubIDs strm (Fix44.Fields.NoNested3PartySubIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoNested3PartySubIDsGrp strm gg)    ) // end Option.iter


// component
let WriteNestedParties3 (strm:System.IO.Stream) (grp:NestedParties3) =
    grp.NoNested3PartyIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoNested3PartyIDs strm (Fix44.Fields.NoNested3PartyIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoNested3PartyIDsGrp strm gg)    ) // end Option.iter


// group
let WriteMultilegOrderCancelReplaceRequest_NoAllocsGrp (strm:System.IO.Stream) (grp:MultilegOrderCancelReplaceRequest_NoAllocsGrp) =
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    grp.NestedParties3 |> Option.iter (WriteNestedParties3 strm) // component
    grp.AllocQty |> Option.iter (WriteAllocQty strm)


// group
let WriteNewOrderMultileg_NoLegsGrp (strm:System.IO.Stream) (grp:NewOrderMultileg_NoLegsGrp) =
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    grp.NoLegAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegAllocs strm (Fix44.Fields.NoLegAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegAllocsGrp strm gg)    ) // end Option.iter
    grp.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    grp.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component
    grp.LegRefID |> Option.iter (WriteLegRefID strm)
    grp.LegPrice |> Option.iter (WriteLegPrice strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)


// group
let WriteNewOrderMultileg_NoAllocsGrp (strm:System.IO.Stream) (grp:NewOrderMultileg_NoAllocsGrp) =
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    grp.NestedParties3 |> Option.iter (WriteNestedParties3 strm) // component
    grp.AllocQty |> Option.iter (WriteAllocQty strm)


// group
let WriteCrossOrderCancelRequest_NoSidesGrp (strm:System.IO.Stream) (grp:CrossOrderCancelRequest_NoSidesGrp) =
    WriteSide strm grp.Side
    WriteOrigClOrdID strm grp.OrigClOrdID
    WriteClOrdID strm grp.ClOrdID
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    grp.OrigOrdModTime |> Option.iter (WriteOrigOrdModTime strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    WriteOrderQtyData strm grp.OrderQtyData    // component
    grp.ComplianceID |> Option.iter (WriteComplianceID strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteCrossOrderCancelReplaceRequest_NoSidesGrp (strm:System.IO.Stream) (grp:CrossOrderCancelReplaceRequest_NoSidesGrp) =
    WriteSide strm grp.Side
    WriteOrigClOrdID strm grp.OrigClOrdID
    WriteClOrdID strm grp.ClOrdID
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    grp.OrigOrdModTime |> Option.iter (WriteOrigOrdModTime strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.DayBookingInst |> Option.iter (WriteDayBookingInst strm)
    grp.BookingUnit |> Option.iter (WriteBookingUnit strm)
    grp.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    grp.AllocID |> Option.iter (WriteAllocID strm)
    grp.NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoAllocsGrp strm gg)    ) // end Option.iter
    grp.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm grp.OrderQtyData    // component
    grp.CommissionData |> Option.iter (WriteCommissionData strm) // component
    grp.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    grp.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    grp.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    grp.ForexReq |> Option.iter (WriteForexReq strm)
    grp.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    grp.BookingType |> Option.iter (WriteBookingType strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.PositionEffect |> Option.iter (WritePositionEffect strm)
    grp.CoveredOrUncovered |> Option.iter (WriteCoveredOrUncovered strm)
    grp.CashMargin |> Option.iter (WriteCashMargin strm)
    grp.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    grp.SolicitedFlag |> Option.iter (WriteSolicitedFlag strm)
    grp.SideComplianceID |> Option.iter (WriteSideComplianceID strm)


// group
let WriteNoSidesGrp (strm:System.IO.Stream) (grp:NoSidesGrp) =
    WriteSide strm grp.Side
    WriteClOrdID strm grp.ClOrdID
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.DayBookingInst |> Option.iter (WriteDayBookingInst strm)
    grp.BookingUnit |> Option.iter (WriteBookingUnit strm)
    grp.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    grp.AllocID |> Option.iter (WriteAllocID strm)
    grp.NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoAllocsGrp strm gg)    ) // end Option.iter
    grp.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm grp.OrderQtyData    // component
    grp.CommissionData |> Option.iter (WriteCommissionData strm) // component
    grp.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    grp.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    grp.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    grp.ForexReq |> Option.iter (WriteForexReq strm)
    grp.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    grp.BookingType |> Option.iter (WriteBookingType strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.PositionEffect |> Option.iter (WritePositionEffect strm)
    grp.CoveredOrUncovered |> Option.iter (WriteCoveredOrUncovered strm)
    grp.CashMargin |> Option.iter (WriteCashMargin strm)
    grp.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    grp.SolicitedFlag |> Option.iter (WriteSolicitedFlag strm)
    grp.SideComplianceID |> Option.iter (WriteSideComplianceID strm)


// group
let WriteExecutionReport_NoLegsGrp (strm:System.IO.Stream) (grp:ExecutionReport_NoLegsGrp) =
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    grp.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    grp.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component
    grp.LegRefID |> Option.iter (WriteLegRefID strm)
    grp.LegPrice |> Option.iter (WriteLegPrice strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    grp.LegLastPx |> Option.iter (WriteLegLastPx strm)


// group
let WriteNoInstrAttribGrp (strm:System.IO.Stream) (grp:NoInstrAttribGrp) =
    grp.InstrAttribType |> Option.iter (WriteInstrAttribType strm)
    grp.InstrAttribValue |> Option.iter (WriteInstrAttribValue strm)


// component
let WriteInstrumentExtension (strm:System.IO.Stream) (grp:InstrumentExtension) =
    grp.DeliveryForm |> Option.iter (WriteDeliveryForm strm)
    grp.PctAtRisk |> Option.iter (WritePctAtRisk strm)
    grp.NoInstrAttribGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoInstrAttrib strm (Fix44.Fields.NoInstrAttrib numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoInstrAttribGrp strm gg)    ) // end Option.iter


// group
let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component


// group
let WriteDerivativeSecurityList_NoRelatedSymGrp (strm:System.IO.Stream) (grp:DerivativeSecurityList_NoRelatedSymGrp) =
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.ExpirationCycle |> Option.iter (WriteExpirationCycle strm)
    grp.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


// component
let WriteFinancingDetails (strm:System.IO.Stream) (grp:FinancingDetails) =
    grp.AgreementDesc |> Option.iter (WriteAgreementDesc strm)
    grp.AgreementID |> Option.iter (WriteAgreementID strm)
    grp.AgreementDate |> Option.iter (WriteAgreementDate strm)
    grp.AgreementCurrency |> Option.iter (WriteAgreementCurrency strm)
    grp.TerminationType |> Option.iter (WriteTerminationType strm)
    grp.StartDate |> Option.iter (WriteStartDate strm)
    grp.EndDate |> Option.iter (WriteEndDate strm)
    grp.DeliveryType |> Option.iter (WriteDeliveryType strm)
    grp.MarginRatio |> Option.iter (WriteMarginRatio strm)


// component
let WriteLegBenchmarkCurveData (strm:System.IO.Stream) (grp:LegBenchmarkCurveData) =
    grp.LegBenchmarkCurveCurrency |> Option.iter (WriteLegBenchmarkCurveCurrency strm)
    grp.LegBenchmarkCurveName |> Option.iter (WriteLegBenchmarkCurveName strm)
    grp.LegBenchmarkCurvePoint |> Option.iter (WriteLegBenchmarkCurvePoint strm)
    grp.LegBenchmarkPrice |> Option.iter (WriteLegBenchmarkPrice strm)
    grp.LegBenchmarkPriceType |> Option.iter (WriteLegBenchmarkPriceType strm)


// group
let WriteSecurityList_NoLegsGrp (strm:System.IO.Stream) (grp:SecurityList_NoLegsGrp) =
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    grp.LegBenchmarkCurveData |> Option.iter (WriteLegBenchmarkCurveData strm) // component


// group
let WriteSecurityList_NoRelatedSymGrp (strm:System.IO.Stream) (grp:SecurityList_NoRelatedSymGrp) =
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.SecurityList_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteSecurityList_NoLegsGrp strm gg)    ) // end Option.iter
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    grp.RoundLot |> Option.iter (WriteRoundLot strm)
    grp.MinTradeVol |> Option.iter (WriteMinTradeVol strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.ExpirationCycle |> Option.iter (WriteExpirationCycle strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteMarketDataIncrementalRefresh_NoMDEntriesGrp (strm:System.IO.Stream) (grp:MarketDataIncrementalRefresh_NoMDEntriesGrp) =
    WriteMDUpdateAction strm grp.MDUpdateAction
    grp.DeleteReason |> Option.iter (WriteDeleteReason strm)
    grp.MDEntryType |> Option.iter (WriteMDEntryType strm)
    grp.MDEntryID |> Option.iter (WriteMDEntryID strm)
    grp.MDEntryRefID |> Option.iter (WriteMDEntryRefID strm)
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.FinancialStatus |> Option.iter (WriteFinancialStatus strm)
    grp.CorporateAction |> Option.iter (WriteCorporateAction strm)
    grp.MDEntryPx |> Option.iter (WriteMDEntryPx strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.MDEntrySize |> Option.iter (WriteMDEntrySize strm)
    grp.MDEntryDate |> Option.iter (WriteMDEntryDate strm)
    grp.MDEntryTime |> Option.iter (WriteMDEntryTime strm)
    grp.TickDirection |> Option.iter (WriteTickDirection strm)
    grp.MDMkt |> Option.iter (WriteMDMkt strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.QuoteCondition |> Option.iter (WriteQuoteCondition strm)
    grp.TradeCondition |> Option.iter (WriteTradeCondition strm)
    grp.MDEntryOriginator |> Option.iter (WriteMDEntryOriginator strm)
    grp.LocationID |> Option.iter (WriteLocationID strm)
    grp.DeskID |> Option.iter (WriteDeskID strm)
    grp.OpenCloseSettlFlag |> Option.iter (WriteOpenCloseSettlFlag strm)
    grp.TimeInForce |> Option.iter (WriteTimeInForce strm)
    grp.ExpireDate |> Option.iter (WriteExpireDate strm)
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.MinQty |> Option.iter (WriteMinQty strm)
    grp.ExecInst |> Option.iter (WriteExecInst strm)
    grp.SellerDays |> Option.iter (WriteSellerDays strm)
    grp.OrderID |> Option.iter (WriteOrderID strm)
    grp.QuoteEntryID |> Option.iter (WriteQuoteEntryID strm)
    grp.MDEntryBuyer |> Option.iter (WriteMDEntryBuyer strm)
    grp.MDEntrySeller |> Option.iter (WriteMDEntrySeller strm)
    grp.NumberOfOrders |> Option.iter (WriteNumberOfOrders strm)
    grp.MDEntryPositionNo |> Option.iter (WriteMDEntryPositionNo strm)
    grp.Scope |> Option.iter (WriteScope strm)
    grp.PriceDelta |> Option.iter (WritePriceDelta strm)
    grp.NetChgPrevDay |> Option.iter (WriteNetChgPrevDay strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteMarketDataRequest_NoRelatedSymGrp (strm:System.IO.Stream) (grp:MarketDataRequest_NoRelatedSymGrp) =
    WriteInstrument strm grp.Instrument    // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter


// group
let WriteMassQuoteAcknowledgement_NoQuoteEntriesGrp (strm:System.IO.Stream) (grp:MassQuoteAcknowledgement_NoQuoteEntriesGrp) =
    grp.QuoteEntryID |> Option.iter (WriteQuoteEntryID strm)
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.BidPx |> Option.iter (WriteBidPx strm)
    grp.OfferPx |> Option.iter (WriteOfferPx strm)
    grp.BidSize |> Option.iter (WriteBidSize strm)
    grp.OfferSize |> Option.iter (WriteOfferSize strm)
    grp.ValidUntilTime |> Option.iter (WriteValidUntilTime strm)
    grp.BidSpotRate |> Option.iter (WriteBidSpotRate strm)
    grp.OfferSpotRate |> Option.iter (WriteOfferSpotRate strm)
    grp.BidForwardPoints |> Option.iter (WriteBidForwardPoints strm)
    grp.OfferForwardPoints |> Option.iter (WriteOfferForwardPoints strm)
    grp.MidPx |> Option.iter (WriteMidPx strm)
    grp.BidYield |> Option.iter (WriteBidYield strm)
    grp.MidYield |> Option.iter (WriteMidYield strm)
    grp.OfferYield |> Option.iter (WriteOfferYield strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.OrdType |> Option.iter (WriteOrdType strm)
    grp.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    grp.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    grp.BidForwardPoints2 |> Option.iter (WriteBidForwardPoints2 strm)
    grp.OfferForwardPoints2 |> Option.iter (WriteOfferForwardPoints2 strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.QuoteEntryRejectReason |> Option.iter (WriteQuoteEntryRejectReason strm)


// group
let WriteMassQuoteAcknowledgement_NoQuoteSetsGrp (strm:System.IO.Stream) (grp:MassQuoteAcknowledgement_NoQuoteSetsGrp) =
    grp.QuoteSetID |> Option.iter (WriteQuoteSetID strm)
    grp.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    grp.TotNoQuoteEntries |> Option.iter (WriteTotNoQuoteEntries strm)
    grp.LastFragment |> Option.iter (WriteLastFragment strm)
    grp.MassQuoteAcknowledgement_NoQuoteEntriesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteEntries strm (Fix44.Fields.NoQuoteEntries numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteMassQuoteAcknowledgement_NoQuoteEntriesGrp strm gg)    ) // end Option.iter


// group
let WriteMassQuote_NoQuoteEntriesGrp (strm:System.IO.Stream) (grp:MassQuote_NoQuoteEntriesGrp) =
    WriteQuoteEntryID strm grp.QuoteEntryID
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.BidPx |> Option.iter (WriteBidPx strm)
    grp.OfferPx |> Option.iter (WriteOfferPx strm)
    grp.BidSize |> Option.iter (WriteBidSize strm)
    grp.OfferSize |> Option.iter (WriteOfferSize strm)
    grp.ValidUntilTime |> Option.iter (WriteValidUntilTime strm)
    grp.BidSpotRate |> Option.iter (WriteBidSpotRate strm)
    grp.OfferSpotRate |> Option.iter (WriteOfferSpotRate strm)
    grp.BidForwardPoints |> Option.iter (WriteBidForwardPoints strm)
    grp.OfferForwardPoints |> Option.iter (WriteOfferForwardPoints strm)
    grp.MidPx |> Option.iter (WriteMidPx strm)
    grp.BidYield |> Option.iter (WriteBidYield strm)
    grp.MidYield |> Option.iter (WriteMidYield strm)
    grp.OfferYield |> Option.iter (WriteOfferYield strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.OrdType |> Option.iter (WriteOrdType strm)
    grp.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    grp.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    grp.BidForwardPoints2 |> Option.iter (WriteBidForwardPoints2 strm)
    grp.OfferForwardPoints2 |> Option.iter (WriteOfferForwardPoints2 strm)
    grp.Currency |> Option.iter (WriteCurrency strm)


// group
let WriteNoQuoteSetsGrp (strm:System.IO.Stream) (grp:NoQuoteSetsGrp) =
    WriteQuoteSetID strm grp.QuoteSetID
    grp.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    grp.QuoteSetValidUntilTime |> Option.iter (WriteQuoteSetValidUntilTime strm)
    WriteTotNoQuoteEntries strm grp.TotNoQuoteEntries
    grp.LastFragment |> Option.iter (WriteLastFragment strm)
    let numGrps = grp.MassQuote_NoQuoteEntriesGrp.Length
    WriteNoQuoteEntries strm (Fix44.Fields.NoQuoteEntries numGrps) // write the 'num group repeats' field
    grp.MassQuote_NoQuoteEntriesGrp |> List.iter (fun gg -> WriteMassQuote_NoQuoteEntriesGrp strm gg)


// group
let WriteQuoteStatusReport_NoLegsGrp (strm:System.IO.Stream) (grp:QuoteStatusReport_NoLegsGrp) =
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    grp.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component


// group
let WriteNoQuoteEntriesGrp (strm:System.IO.Stream) (grp:NoQuoteEntriesGrp) =
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter


// group
let WriteQuote_NoLegsGrp (strm:System.IO.Stream) (grp:Quote_NoLegsGrp) =
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    grp.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component
    grp.LegPriceType |> Option.iter (WriteLegPriceType strm)
    grp.LegBidPx |> Option.iter (WriteLegBidPx strm)
    grp.LegOfferPx |> Option.iter (WriteLegOfferPx strm)
    grp.LegBenchmarkCurveData |> Option.iter (WriteLegBenchmarkCurveData strm) // component


// group
let WriteRFQRequest_NoRelatedSymGrp (strm:System.IO.Stream) (grp:RFQRequest_NoRelatedSymGrp) =
    WriteInstrument strm grp.Instrument    // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    grp.QuoteRequestType |> Option.iter (WriteQuoteRequestType strm)
    grp.QuoteType |> Option.iter (WriteQuoteType strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)


// group
let WriteQuoteRequestReject_NoLegsGrp (strm:System.IO.Stream) (grp:QuoteRequestReject_NoLegsGrp) =
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    grp.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component
    grp.LegBenchmarkCurveData |> Option.iter (WriteLegBenchmarkCurveData strm) // component


// group
let WriteQuoteRequestReject_NoRelatedSymGrp (strm:System.IO.Stream) (grp:QuoteRequestReject_NoRelatedSymGrp) =
    WriteInstrument strm grp.Instrument    // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    grp.QuoteRequestType |> Option.iter (WriteQuoteRequestType strm)
    grp.QuoteType |> Option.iter (WriteQuoteType strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.Side |> Option.iter (WriteSide strm)
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.OrderQtyData |> Option.iter (WriteOrderQtyData strm) // component
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    grp.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.QuoteRequestReject_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteQuoteRequestReject_NoLegsGrp strm gg)    ) // end Option.iter


// group
let WriteQuoteResponse_NoLegsGrp (strm:System.IO.Stream) (grp:QuoteResponse_NoLegsGrp) =
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    grp.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component
    grp.LegPriceType |> Option.iter (WriteLegPriceType strm)
    grp.LegBidPx |> Option.iter (WriteLegBidPx strm)
    grp.LegOfferPx |> Option.iter (WriteLegOfferPx strm)
    grp.LegBenchmarkCurveData |> Option.iter (WriteLegBenchmarkCurveData strm) // component


// group
let WriteQuoteRequest_NoLegsGrp (strm:System.IO.Stream) (grp:QuoteRequest_NoLegsGrp) =
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    grp.LegStipulations |> Option.iter (WriteLegStipulations strm) // component
    grp.NestedParties |> Option.iter (WriteNestedParties strm) // component
    grp.LegBenchmarkCurveData |> Option.iter (WriteLegBenchmarkCurveData strm) // component


// group
let WriteNoQuoteQualifiersGrp (strm:System.IO.Stream) (grp:NoQuoteQualifiersGrp) =
    grp.QuoteQualifier |> Option.iter (WriteQuoteQualifier strm)


// group
let WriteQuoteRequest_NoRelatedSymGrp (strm:System.IO.Stream) (grp:QuoteRequest_NoRelatedSymGrp) =
    WriteInstrument strm grp.Instrument    // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    grp.QuoteRequestType |> Option.iter (WriteQuoteRequestType strm)
    grp.QuoteType |> Option.iter (WriteQuoteType strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.Side |> Option.iter (WriteSide strm)
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.OrderQtyData |> Option.iter (WriteOrderQtyData strm) // component
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    grp.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.QuoteRequest_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteQuoteRequest_NoLegsGrp strm gg)    ) // end Option.iter
    grp.NoQuoteQualifiersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteQualifiers strm (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoQuoteQualifiersGrp strm gg)    ) // end Option.iter
    grp.QuotePriceType |> Option.iter (WriteQuotePriceType strm)
    grp.OrdType |> Option.iter (WriteOrdType strm)
    grp.ValidUntilTime |> Option.iter (WriteValidUntilTime strm)
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.Price2 |> Option.iter (WritePrice2 strm)
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    grp.Parties |> Option.iter (WriteParties strm) // component


// group
let WriteNoRelatedSymGrp (strm:System.IO.Stream) (grp:NoRelatedSymGrp) =
    grp.Instrument |> Option.iter (WriteInstrument strm) // component


// group
let WriteIndicationOfInterest_NoLegsGrp (strm:System.IO.Stream) (grp:IndicationOfInterest_NoLegsGrp) =
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.LegIOIQty |> Option.iter (WriteLegIOIQty strm)
    grp.LegStipulations |> Option.iter (WriteLegStipulations strm) // component


// group
let WriteAdvertisement_NoUnderlyingsGrp (strm:System.IO.Stream) (grp:Advertisement_NoUnderlyingsGrp) =
    WriteUnderlyingInstrument strm grp.UnderlyingInstrument    // component


// group
let WriteNoMsgTypesGrp (strm:System.IO.Stream) (grp:NoMsgTypesGrp) =
    grp.RefMsgType |> Option.iter (WriteRefMsgType strm)
    grp.MsgDirection |> Option.iter (WriteMsgDirection strm)


// group
let WriteNoIOIQualifiersGrp (strm:System.IO.Stream) (grp:NoIOIQualifiersGrp) =
    grp.IOIQualifier |> Option.iter (WriteIOIQualifier strm)


// group
let WriteNoRoutingIDsGrp (strm:System.IO.Stream) (grp:NoRoutingIDsGrp) =
    grp.RoutingType |> Option.iter (WriteRoutingType strm)
    grp.RoutingID |> Option.iter (WriteRoutingID strm)


// group
let WriteLinesOfTextGrp (strm:System.IO.Stream) (grp:LinesOfTextGrp) =
    WriteText strm grp.Text
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteNoMDEntryTypesGrp (strm:System.IO.Stream) (grp:NoMDEntryTypesGrp) =
    WriteMDEntryType strm grp.MDEntryType


// group
let WriteNoMDEntriesGrp (strm:System.IO.Stream) (grp:NoMDEntriesGrp) =
    WriteMDEntryType strm grp.MDEntryType
    grp.MDEntryPx |> Option.iter (WriteMDEntryPx strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.MDEntrySize |> Option.iter (WriteMDEntrySize strm)
    grp.MDEntryDate |> Option.iter (WriteMDEntryDate strm)
    grp.MDEntryTime |> Option.iter (WriteMDEntryTime strm)
    grp.TickDirection |> Option.iter (WriteTickDirection strm)
    grp.MDMkt |> Option.iter (WriteMDMkt strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.QuoteCondition |> Option.iter (WriteQuoteCondition strm)
    grp.TradeCondition |> Option.iter (WriteTradeCondition strm)
    grp.MDEntryOriginator |> Option.iter (WriteMDEntryOriginator strm)
    grp.LocationID |> Option.iter (WriteLocationID strm)
    grp.DeskID |> Option.iter (WriteDeskID strm)
    grp.OpenCloseSettlFlag |> Option.iter (WriteOpenCloseSettlFlag strm)
    grp.TimeInForce |> Option.iter (WriteTimeInForce strm)
    grp.ExpireDate |> Option.iter (WriteExpireDate strm)
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.MinQty |> Option.iter (WriteMinQty strm)
    grp.ExecInst |> Option.iter (WriteExecInst strm)
    grp.SellerDays |> Option.iter (WriteSellerDays strm)
    grp.OrderID |> Option.iter (WriteOrderID strm)
    grp.QuoteEntryID |> Option.iter (WriteQuoteEntryID strm)
    grp.MDEntryBuyer |> Option.iter (WriteMDEntryBuyer strm)
    grp.MDEntrySeller |> Option.iter (WriteMDEntrySeller strm)
    grp.NumberOfOrders |> Option.iter (WriteNumberOfOrders strm)
    grp.MDEntryPositionNo |> Option.iter (WriteMDEntryPositionNo strm)
    grp.Scope |> Option.iter (WriteScope strm)
    grp.PriceDelta |> Option.iter (WritePriceDelta strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteNoAltMDSourceGrp (strm:System.IO.Stream) (grp:NoAltMDSourceGrp) =
    grp.AltMDSourceID |> Option.iter (WriteAltMDSourceID strm)


// group
let WriteNoSecurityTypesGrp (strm:System.IO.Stream) (grp:NoSecurityTypesGrp) =
    grp.SecurityType |> Option.iter (WriteSecurityType strm)
    grp.SecuritySubType |> Option.iter (WriteSecuritySubType strm)
    grp.Product |> Option.iter (WriteProduct strm)
    grp.CFICode |> Option.iter (WriteCFICode strm)


// group
let WriteNoContraBrokersGrp (strm:System.IO.Stream) (grp:NoContraBrokersGrp) =
    grp.ContraBroker |> Option.iter (WriteContraBroker strm)
    grp.ContraTrader |> Option.iter (WriteContraTrader strm)
    grp.ContraTradeQty |> Option.iter (WriteContraTradeQty strm)
    grp.ContraTradeTime |> Option.iter (WriteContraTradeTime strm)
    grp.ContraLegRefID |> Option.iter (WriteContraLegRefID strm)


// group
let WriteNoAffectedOrdersGrp (strm:System.IO.Stream) (grp:NoAffectedOrdersGrp) =
    grp.OrigClOrdID |> Option.iter (WriteOrigClOrdID strm)
    grp.AffectedOrderID |> Option.iter (WriteAffectedOrderID strm)
    grp.AffectedSecondaryOrderID |> Option.iter (WriteAffectedSecondaryOrderID strm)


// group
let WriteNoBidDescriptorsGrp (strm:System.IO.Stream) (grp:NoBidDescriptorsGrp) =
    grp.BidDescriptorType |> Option.iter (WriteBidDescriptorType strm)
    grp.BidDescriptor |> Option.iter (WriteBidDescriptor strm)
    grp.SideValueInd |> Option.iter (WriteSideValueInd strm)
    grp.LiquidityValue |> Option.iter (WriteLiquidityValue strm)
    grp.LiquidityNumSecurities |> Option.iter (WriteLiquidityNumSecurities strm)
    grp.LiquidityPctLow |> Option.iter (WriteLiquidityPctLow strm)
    grp.LiquidityPctHigh |> Option.iter (WriteLiquidityPctHigh strm)
    grp.EFPTrackingError |> Option.iter (WriteEFPTrackingError strm)
    grp.FairValue |> Option.iter (WriteFairValue strm)
    grp.OutsideIndexPct |> Option.iter (WriteOutsideIndexPct strm)
    grp.ValueOfFutures |> Option.iter (WriteValueOfFutures strm)


// group
let WriteNoBidComponentsGrp (strm:System.IO.Stream) (grp:NoBidComponentsGrp) =
    grp.ListID |> Option.iter (WriteListID strm)
    grp.Side |> Option.iter (WriteSide strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.NetGrossInd |> Option.iter (WriteNetGrossInd strm)
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)


// group
let WriteListStatus_NoOrdersGrp (strm:System.IO.Stream) (grp:ListStatus_NoOrdersGrp) =
    WriteClOrdID strm grp.ClOrdID
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    WriteCumQty strm grp.CumQty
    WriteOrdStatus strm grp.OrdStatus
    grp.WorkingIndicator |> Option.iter (WriteWorkingIndicator strm)
    WriteLeavesQty strm grp.LeavesQty
    WriteCxlQty strm grp.CxlQty
    WriteAvgPx strm grp.AvgPx
    grp.OrdRejReason |> Option.iter (WriteOrdRejReason strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


// group
let WriteAllocationInstruction_NoExecsGrp (strm:System.IO.Stream) (grp:AllocationInstruction_NoExecsGrp) =
    grp.LastQty |> Option.iter (WriteLastQty strm)
    grp.ExecID |> Option.iter (WriteExecID strm)
    grp.SecondaryExecID |> Option.iter (WriteSecondaryExecID strm)
    grp.LastPx |> Option.iter (WriteLastPx strm)
    grp.LastParPx |> Option.iter (WriteLastParPx strm)
    grp.LastCapacity |> Option.iter (WriteLastCapacity strm)


// group
let WriteAllocationInstructionAck_NoAllocsGrp (strm:System.IO.Stream) (grp:AllocationInstructionAck_NoAllocsGrp) =
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocPrice |> Option.iter (WriteAllocPrice strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    grp.IndividualAllocRejCode |> Option.iter (WriteIndividualAllocRejCode strm)
    grp.AllocText |> Option.iter (WriteAllocText strm)
    grp.EncodedAllocText |> Option.iter (WriteEncodedAllocText strm)


// group
let WriteAllocationReport_NoExecsGrp (strm:System.IO.Stream) (grp:AllocationReport_NoExecsGrp) =
    grp.LastQty |> Option.iter (WriteLastQty strm)
    grp.ExecID |> Option.iter (WriteExecID strm)
    grp.SecondaryExecID |> Option.iter (WriteSecondaryExecID strm)
    grp.LastPx |> Option.iter (WriteLastPx strm)
    grp.LastParPx |> Option.iter (WriteLastParPx strm)
    grp.LastCapacity |> Option.iter (WriteLastCapacity strm)


// group
let WriteAllocationReportAck_NoAllocsGrp (strm:System.IO.Stream) (grp:AllocationReportAck_NoAllocsGrp) =
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocPrice |> Option.iter (WriteAllocPrice strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    grp.IndividualAllocRejCode |> Option.iter (WriteIndividualAllocRejCode strm)
    grp.AllocText |> Option.iter (WriteAllocText strm)
    grp.EncodedAllocText |> Option.iter (WriteEncodedAllocText strm)


// group
let WriteNoCapacitiesGrp (strm:System.IO.Stream) (grp:NoCapacitiesGrp) =
    WriteOrderCapacity strm grp.OrderCapacity
    grp.OrderRestrictions |> Option.iter (WriteOrderRest