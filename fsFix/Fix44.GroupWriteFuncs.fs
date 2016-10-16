module Fix44.GroupWriteFuncs

open Fix44.Fields
open Fix44.Groups
open Fix44.FieldReadWriteFuncs


let WriteNoUnderlyingSecurityAltIDGrp (strm:System.IO.Stream) (grp:NoUnderlyingSecurityAltIDGrp) =
    grp.UnderlyingSecurityAltID |> Option.iter (WriteUnderlyingSecurityAltID strm)
    grp.UnderlyingSecurityAltIDSource |> Option.iter (WriteUnderlyingSecurityAltIDSource strm)


let WriteNoUnderlyingStipsGrp (strm:System.IO.Stream) (grp:NoUnderlyingStipsGrp) =
    grp.UnderlyingStipType |> Option.iter (WriteUnderlyingStipType strm)
    grp.UnderlyingStipValue |> Option.iter (WriteUnderlyingStipValue strm)


let WriteNoUnderlyingsGrp (strm:System.IO.Stream) (grp:NoUnderlyingsGrp) =
    // grp component writer func not implemented
    grp.CollAction |> Option.iter (WriteCollAction strm)


let WriteNoUnderlyingsGrp (strm:System.IO.Stream) (grp:NoUnderlyingsGrp) =
    // grp component writer func not implemented
    grp.CollAction |> Option.iter (WriteCollAction strm)


let WriteNoUnderlyingsGrp (strm:System.IO.Stream) (grp:NoUnderlyingsGrp) =
    // grp component writer func not implemented
    grp.CollAction |> Option.iter (WriteCollAction strm)


let WriteNoUnderlyingsGrp (strm:System.IO.Stream) (grp:NoUnderlyingsGrp) =
    // grp component writer func not implemented
    WriteUnderlyingSettlPrice strm grp.UnderlyingSettlPrice
    WriteUnderlyingSettlPriceType strm grp.UnderlyingSettlPriceType


let WriteNoNestedPartySubIDsGrp (strm:System.IO.Stream) (grp:NoNestedPartySubIDsGrp) =
    grp.NestedPartySubID |> Option.iter (WriteNestedPartySubID strm)
    grp.NestedPartySubIDType |> Option.iter (WriteNestedPartySubIDType strm)


let WriteNoNestedPartyIDsGrp (strm:System.IO.Stream) (grp:NoNestedPartyIDsGrp) =
    grp.NestedPartyID |> Option.iter (WriteNestedPartyID strm)
    grp.NestedPartyIDSource |> Option.iter (WriteNestedPartyIDSource strm)
    grp.NestedPartyRole |> Option.iter (WriteNestedPartyRole strm)
    // grp subgroup writer func not implemented


let WriteNoPositionsGrp (strm:System.IO.Stream) (grp:NoPositionsGrp) =
    grp.PosType |> Option.iter (WritePosType strm)
    grp.LongQty |> Option.iter (WriteLongQty strm)
    grp.ShortQty |> Option.iter (WriteShortQty strm)
    grp.PosQtyStatus |> Option.iter (WritePosQtyStatus strm)
    // grp component writer func not implemented


let WriteNoRegistDtlsGrp (strm:System.IO.Stream) (grp:NoRegistDtlsGrp) =
    grp.RegistDtls |> Option.iter (WriteRegistDtls strm)
    grp.RegistEmail |> Option.iter (WriteRegistEmail strm)
    grp.MailingDtls |> Option.iter (WriteMailingDtls strm)
    grp.MailingInst |> Option.iter (WriteMailingInst strm)
    // grp component writer func not implemented
    grp.OwnerType |> Option.iter (WriteOwnerType strm)
    grp.DateOfBirth |> Option.iter (WriteDateOfBirth strm)
    grp.InvestorCountryOfResidence |> Option.iter (WriteInvestorCountryOfResidence strm)


let WriteNoNested2PartySubIDsGrp (strm:System.IO.Stream) (grp:NoNested2PartySubIDsGrp) =
    grp.Nested2PartySubID |> Option.iter (WriteNested2PartySubID strm)
    grp.Nested2PartySubIDType |> Option.iter (WriteNested2PartySubIDType strm)


let WriteNoNested2PartyIDsGrp (strm:System.IO.Stream) (grp:NoNested2PartyIDsGrp) =
    grp.Nested2PartyID |> Option.iter (WriteNested2PartyID strm)
    grp.Nested2PartyIDSource |> Option.iter (WriteNested2PartyIDSource strm)
    grp.Nested2PartyRole |> Option.iter (WriteNested2PartyRole strm)
    // grp subgroup writer func not implemented


let WriteNoAllocsGrp (strm:System.IO.Stream) (grp:NoAllocsGrp) =
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    // grp component writer func not implemented
    grp.AllocQty |> Option.iter (WriteAllocQty strm)


let WriteNoLegSecurityAltIDGrp (strm:System.IO.Stream) (grp:NoLegSecurityAltIDGrp) =
    grp.LegSecurityAltID |> Option.iter (WriteLegSecurityAltID strm)
    grp.LegSecurityAltIDSource |> Option.iter (WriteLegSecurityAltIDSource strm)


let WriteNoLegStipulationsGrp (strm:System.IO.Stream) (grp:NoLegStipulationsGrp) =
    grp.LegStipulationType |> Option.iter (WriteLegStipulationType strm)
    grp.LegStipulationValue |> Option.iter (WriteLegStipulationValue strm)


let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    // grp component writer func not implemented
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    // grp component writer func not implemented
    grp.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    grp.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    // grp component writer func not implemented
    grp.LegRefID |> Option.iter (WriteLegRefID strm)
    grp.LegPrice |> Option.iter (WriteLegPrice strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    grp.LegLastPx |> Option.iter (WriteLegLastPx strm)


let WriteNoPartySubIDsGrp (strm:System.IO.Stream) (grp:NoPartySubIDsGrp) =
    grp.PartySubID |> Option.iter (WritePartySubID strm)
    grp.PartySubIDType |> Option.iter (WritePartySubIDType strm)


let WriteNoPartyIDsGrp (strm:System.IO.Stream) (grp:NoPartyIDsGrp) =
    grp.PartyID |> Option.iter (WritePartyID strm)
    grp.PartyIDSource |> Option.iter (WritePartyIDSource strm)
    grp.PartyRole |> Option.iter (WritePartyRole strm)
    // grp subgroup writer func not implemented


let WriteNoClearingInstructionsGrp (strm:System.IO.Stream) (grp:NoClearingInstructionsGrp) =
    grp.ClearingInstruction |> Option.iter (WriteClearingInstruction strm)


let WriteNoContAmtsGrp (strm:System.IO.Stream) (grp:NoContAmtsGrp) =
    grp.ContAmtType |> Option.iter (WriteContAmtType strm)
    grp.ContAmtValue |> Option.iter (WriteContAmtValue strm)
    grp.ContAmtCurr |> Option.iter (WriteContAmtCurr strm)


let WriteNoStipulationsGrp (strm:System.IO.Stream) (grp:NoStipulationsGrp) =
    grp.StipulationType |> Option.iter (WriteStipulationType strm)
    grp.StipulationValue |> Option.iter (WriteStipulationValue strm)


let WriteNoMiscFeesGrp (strm:System.IO.Stream) (grp:NoMiscFeesGrp) =
    grp.MiscFeeAmt |> Option.iter (WriteMiscFeeAmt strm)
    grp.MiscFeeCurr |> Option.iter (WriteMiscFeeCurr strm)
    grp.MiscFeeType |> Option.iter (WriteMiscFeeType strm)
    grp.MiscFeeBasis |> Option.iter (WriteMiscFeeBasis strm)


let WriteNoSidesGrp (strm:System.IO.Stream) (grp:NoSidesGrp) =
    WriteSide strm grp.Side
    WriteOrderID strm grp.OrderID
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.ListID |> Option.iter (WriteListID strm)
    // grp component writer func not implemented
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.ProcessCode |> Option.iter (WriteProcessCode strm)
    grp.OddLot |> Option.iter (WriteOddLot strm)
    // grp subgroup writer func not implemented
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
    // grp component writer func not implemented
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
    // grp subgroup writer func not implemented
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
    grp.ExchangeRule |> Option.iter (WriteExchangeRule strm)
    grp.TradeAllocIndicator |> Option.iter (WriteTradeAllocIndicator strm)
    grp.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    grp.AllocID |> Option.iter (WriteAllocID strm)


let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    // grp component writer func not implemented
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    // grp component writer func not implemented
    grp.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    grp.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    // grp component writer func not implemented
    grp.LegRefID |> Option.iter (WriteLegRefID strm)
    grp.LegPrice |> Option.iter (WriteLegPrice strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    grp.LegLastPx |> Option.iter (WriteLegLastPx strm)


let WriteNoPosAmtGrp (strm:System.IO.Stream) (grp:NoPosAmtGrp) =
    WritePosAmtType strm grp.PosAmtType
    WritePosAmt strm grp.PosAmt


let WriteNoSettlPartySubIDsGrp (strm:System.IO.Stream) (grp:NoSettlPartySubIDsGrp) =
    grp.SettlPartySubID |> Option.iter (WriteSettlPartySubID strm)
    grp.SettlPartySubIDType |> Option.iter (WriteSettlPartySubIDType strm)


let WriteNoSettlPartyIDsGrp (strm:System.IO.Stream) (grp:NoSettlPartyIDsGrp) =
    grp.SettlPartyID |> Option.iter (WriteSettlPartyID strm)
    grp.SettlPartyIDSource |> Option.iter (WriteSettlPartyIDSource strm)
    grp.SettlPartyRole |> Option.iter (WriteSettlPartyRole strm)
    // grp subgroup writer func not implemented


let WriteNoDlvyInstGrp (strm:System.IO.Stream) (grp:NoDlvyInstGrp) =
    grp.SettlInstSource |> Option.iter (WriteSettlInstSource strm)
    grp.DlvyInstType |> Option.iter (WriteDlvyInstType strm)
    // grp component writer func not implemented


let WriteNoSettlInstGrp (strm:System.IO.Stream) (grp:NoSettlInstGrp) =
    grp.SettlInstID |> Option.iter (WriteSettlInstID strm)
    grp.SettlInstTransType |> Option.iter (WriteSettlInstTransType strm)
    grp.SettlInstRefID |> Option.iter (WriteSettlInstRefID strm)
    // grp component writer func not implemented
    grp.Side |> Option.iter (WriteSide strm)
    grp.Product |> Option.iter (WriteProduct strm)
    grp.SecurityType |> Option.iter (WriteSecurityType strm)
    grp.CFICode |> Option.iter (WriteCFICode strm)
    grp.EffectiveTime |> Option.iter (WriteEffectiveTime strm)
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.LastUpdateTime |> Option.iter (WriteLastUpdateTime strm)
    // grp component writer func not implemented
    grp.PaymentMethod |> Option.iter (WritePaymentMethod strm)
    grp.PaymentRef |> Option.iter (WritePaymentRef strm)
    grp.CardHolderName |> Option.iter (WriteCardHolderName strm)
    grp.CardNumber |> Option.iter (WriteCardNumber strm)
    grp.CardStartDate |> Option.iter (WriteCardStartDate strm)
    grp.CardExpDate |> Option.iter (WriteCardExpDate strm)
    grp.CardIssNum |> Option.iter (WriteCardIssNum strm)
    grp.PaymentDate |> Option.iter (WritePaymentDate strm)
    grp.PaymentRemitterID |> Option.iter (WritePaymentRemitterID strm)


let WriteNoTrdRegTimestampsGrp (strm:System.IO.Stream) (grp:NoTrdRegTimestampsGrp) =
    grp.TrdRegTimestamp |> Option.iter (WriteTrdRegTimestamp strm)
    grp.TrdRegTimestampType |> Option.iter (WriteTrdRegTimestampType strm)
    grp.TrdRegTimestampOrigin |> Option.iter (WriteTrdRegTimestampOrigin strm)


let WriteNoAllocsGrp (strm:System.IO.Stream) (grp:NoAllocsGrp) =
    WriteAllocAccount strm grp.AllocAccount
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.MatchStatus |> Option.iter (WriteMatchStatus strm)
    grp.AllocPrice |> Option.iter (WriteAllocPrice strm)
    WriteAllocQty strm grp.AllocQty
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    grp.ProcessCode |> Option.iter (WriteProcessCode strm)
    // grp component writer func not implemented
    grp.NotifyBrokerOfCredit |> Option.iter (WriteNotifyBrokerOfCredit strm)
    grp.AllocHandlInst |> Option.iter (WriteAllocHandlInst strm)
    grp.AllocText |> Option.iter (WriteAllocText strm)
    grp.EncodedAllocText |> Option.iter (WriteEncodedAllocText strm)
    // grp component writer func not implemented
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
    // grp subgroup writer func not implemented
    // grp subgroup writer func not implemented
    grp.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    grp.AllocSettlInstType |> Option.iter (WriteAllocSettlInstType strm)
    // grp component writer func not implemented


let WriteNoAllocsGrp (strm:System.IO.Stream) (grp:NoAllocsGrp) =
    WriteAllocAccount strm grp.AllocAccount
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.MatchStatus |> Option.iter (WriteMatchStatus strm)
    grp.AllocPrice |> Option.iter (WriteAllocPrice strm)
    grp.AllocQty |> Option.iter (WriteAllocQty strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    grp.ProcessCode |> Option.iter (WriteProcessCode strm)
    // grp component writer func not implemented
    grp.NotifyBrokerOfCredit |> Option.iter (WriteNotifyBrokerOfCredit strm)
    grp.AllocHandlInst |> Option.iter (WriteAllocHandlInst strm)
    grp.AllocText |> Option.iter (WriteAllocText strm)
    grp.EncodedAllocText |> Option.iter (WriteEncodedAllocText strm)
    // grp component writer func not implemented
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
    // grp subgroup writer func not implemented
    grp.NoClearingInstructions |> Option.iter (WriteNoClearingInstructions strm)
    grp.ClearingInstruction |> Option.iter (WriteClearingInstruction strm)
    grp.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    grp.AllocSettlInstType |> Option.iter (WriteAllocSettlInstType strm)
    // grp component writer func not implemented


let WriteNoOrdersGrp (strm:System.IO.Stream) (grp:NoOrdersGrp) =
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.OrderID |> Option.iter (WriteOrderID strm)
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.ListID |> Option.iter (WriteListID strm)
    // grp component writer func not implemented
    grp.OrderQty |> Option.iter (WriteOrderQty strm)
    grp.OrderAvgPx |> Option.iter (WriteOrderAvgPx strm)
    grp.OrderBookingQty |> Option.iter (WriteOrderBookingQty strm)


let WriteNoUnderlyingsGrp (strm:System.IO.Stream) (grp:NoUnderlyingsGrp) =
    // grp component writer func not implemented
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.Side |> Option.iter (WriteSide strm)
    WritePrice strm grp.Price
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteNoSecurityAltIDGrp (strm:System.IO.Stream) (grp:NoSecurityAltIDGrp) =
    grp.SecurityAltID |> Option.iter (WriteSecurityAltID strm)
    grp.SecurityAltIDSource |> Option.iter (WriteSecurityAltIDSource strm)


let WriteNoEventsGrp (strm:System.IO.Stream) (grp:NoEventsGrp) =
    grp.EventType |> Option.iter (WriteEventType strm)
    grp.EventDate |> Option.iter (WriteEventDate strm)
    grp.EventPx |> Option.iter (WriteEventPx strm)
    grp.EventText |> Option.iter (WriteEventText strm)


let WriteNoStrikesGrp (strm:System.IO.Stream) (grp:NoStrikesGrp) =
    // grp component writer func not implemented


let WriteNoAllocsGrp (strm:System.IO.Stream) (grp:NoAllocsGrp) =
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    // grp component writer func not implemented
    grp.AllocQty |> Option.iter (WriteAllocQty strm)


let WriteNoTradingSessionsGrp (strm:System.IO.Stream) (grp:NoTradingSessionsGrp) =
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)


let WriteNoUnderlyingsGrp (strm:System.IO.Stream) (grp:NoUnderlyingsGrp) =
    // grp component writer func not implemented


let WriteNoOrdersGrp (strm:System.IO.Stream) (grp:NoOrdersGrp) =
    WriteClOrdID strm grp.ClOrdID
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    WriteListSeqNo strm grp.ListSeqNo
    grp.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    grp.SettlInstMode |> Option.iter (WriteSettlInstMode strm)
    // grp component writer func not implemented
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.DayBookingInst |> Option.iter (WriteDayBookingInst strm)
    grp.BookingUnit |> Option.iter (WriteBookingUnit strm)
    grp.AllocID |> Option.iter (WriteAllocID strm)
    grp.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    // grp subgroup writer func not implemented
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.CashMargin |> Option.iter (WriteCashMargin strm)
    grp.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    grp.HandlInst |> Option.iter (WriteHandlInst strm)
    grp.ExecInst |> Option.iter (WriteExecInst strm)
    grp.MinQty |> Option.iter (WriteMinQty strm)
    grp.MaxFloor |> Option.iter (WriteMaxFloor strm)
    grp.ExDestination |> Option.iter (WriteExDestination strm)
    // grp subgroup writer func not implemented
    grp.ProcessCode |> Option.iter (WriteProcessCode strm)
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    WriteSide strm grp.Side
    grp.SideValueInd |> Option.iter (WriteSideValueInd strm)
    grp.LocateReqd |> Option.iter (WriteLocateReqd strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    // grp component writer func not implemented
    grp.QtyType |> Option.iter (WriteQtyType strm)
    // grp component writer func not implemented
    grp.OrdType |> Option.iter (WriteOrdType strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.StopPx |> Option.iter (WriteStopPx strm)
    // grp component writer func not implemented
    // grp component writer func not implemented
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
    // grp component writer func not implemented
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
    // grp component writer func not implemented
    // grp component writer func not implemented
    grp.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    grp.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    grp.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    grp.Designation |> Option.iter (WriteDesignation strm)


let WriteNoBidComponentsGrp (strm:System.IO.Stream) (grp:NoBidComponentsGrp) =
    // grp component writer func not implemented
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


let WriteNoLegAllocsGrp (strm:System.IO.Stream) (grp:NoLegAllocsGrp) =
    grp.LegAllocAccount |> Option.iter (WriteLegAllocAccount strm)
    grp.LegIndividualAllocID |> Option.iter (WriteLegIndividualAllocID strm)
    // grp component writer func not implemented
    grp.LegAllocQty |> Option.iter (WriteLegAllocQty strm)
    grp.LegAllocAcctIDSource |> Option.iter (WriteLegAllocAcctIDSource strm)
    grp.LegSettlCurrency |> Option.iter (WriteLegSettlCurrency strm)


let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    // grp component writer func not implemented
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
    grp.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    grp.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    // grp component writer func not implemented
    grp.LegRefID |> Option.iter (WriteLegRefID strm)
    grp.LegPrice |> Option.iter (WriteLegPrice strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)


let WriteNoNested3PartySubIDsGrp (strm:System.IO.Stream) (grp:NoNested3PartySubIDsGrp) =
    grp.Nested3PartySubID |> Option.iter (WriteNested3PartySubID strm)
    grp.Nested3PartySubIDType |> Option.iter (WriteNested3PartySubIDType strm)


let WriteNoNested3PartyIDsGrp (strm:System.IO.Stream) (grp:NoNested3PartyIDsGrp) =
    grp.Nested3PartyID |> Option.iter (WriteNested3PartyID strm)
    grp.Nested3PartyIDSource |> Option.iter (WriteNested3PartyIDSource strm)
    grp.Nested3PartyRole |> Option.iter (WriteNested3PartyRole strm)
    // grp subgroup writer func not implemented


let WriteNoAllocsGrp (strm:System.IO.Stream) (grp:NoAllocsGrp) =
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    // grp component writer func not implemented
    grp.AllocQty |> Option.iter (WriteAllocQty strm)


let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    // grp component writer func not implemented
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
    grp.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    grp.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    // grp component writer func not implemented
    grp.LegRefID |> Option.iter (WriteLegRefID strm)
    grp.LegPrice |> Option.iter (WriteLegPrice strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)


let WriteNoAllocsGrp (strm:System.IO.Stream) (grp:NoAllocsGrp) =
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocSettlCurrency |> Option.iter (WriteAllocSettlCurrency strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    // grp component writer func not implemented
    grp.AllocQty |> Option.iter (WriteAllocQty strm)


let WriteNoSidesGrp (strm:System.IO.Stream) (grp:NoSidesGrp) =
    WriteSide strm grp.Side
    WriteOrigClOrdID strm grp.OrigClOrdID
    WriteClOrdID strm grp.ClOrdID
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    grp.OrigOrdModTime |> Option.iter (WriteOrigOrdModTime strm)
    // grp component writer func not implemented
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    // grp component writer func not implemented
    grp.ComplianceID |> Option.iter (WriteComplianceID strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteNoSidesGrp (strm:System.IO.Stream) (grp:NoSidesGrp) =
    WriteSide strm grp.Side
    WriteOrigClOrdID strm grp.OrigClOrdID
    WriteClOrdID strm grp.ClOrdID
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    grp.OrigOrdModTime |> Option.iter (WriteOrigOrdModTime strm)
    // grp component writer func not implemented
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.DayBookingInst |> Option.iter (WriteDayBookingInst strm)
    grp.BookingUnit |> Option.iter (WriteBookingUnit strm)
    grp.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    grp.AllocID |> Option.iter (WriteAllocID strm)
    // grp subgroup writer func not implemented
    grp.QtyType |> Option.iter (WriteQtyType strm)
    // grp component writer func not implemented
    // grp component writer func not implemented
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


let WriteNoSidesGrp (strm:System.IO.Stream) (grp:NoSidesGrp) =
    WriteSide strm grp.Side
    WriteClOrdID strm grp.ClOrdID
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    // grp component writer func not implemented
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.DayBookingInst |> Option.iter (WriteDayBookingInst strm)
    grp.BookingUnit |> Option.iter (WriteBookingUnit strm)
    grp.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    grp.AllocID |> Option.iter (WriteAllocID strm)
    // grp subgroup writer func not implemented
    grp.QtyType |> Option.iter (WriteQtyType strm)
    // grp component writer func not implemented
    // grp component writer func not implemented
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


let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    // grp component writer func not implemented
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    // grp component writer func not implemented
    grp.LegPositionEffect |> Option.iter (WriteLegPositionEffect strm)
    grp.LegCoveredOrUncovered |> Option.iter (WriteLegCoveredOrUncovered strm)
    // grp component writer func not implemented
    grp.LegRefID |> Option.iter (WriteLegRefID strm)
    grp.LegPrice |> Option.iter (WriteLegPrice strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    grp.LegLastPx |> Option.iter (WriteLegLastPx strm)


let WriteNoInstrAttribGrp (strm:System.IO.Stream) (grp:NoInstrAttribGrp) =
    grp.InstrAttribType |> Option.iter (WriteInstrAttribType strm)
    grp.InstrAttribValue |> Option.iter (WriteInstrAttribValue strm)


let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    // grp component writer func not implemented


let WriteNoRelatedSymGrp (strm:System.IO.Stream) (grp:NoRelatedSymGrp) =
    // grp component writer func not implemented
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.ExpirationCycle |> Option.iter (WriteExpirationCycle strm)
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    // grp component writer func not implemented
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    // grp component writer func not implemented
    // grp component writer func not implemented


let WriteNoRelatedSymGrp (strm:System.IO.Stream) (grp:NoRelatedSymGrp) =
    // grp component writer func not implemented
    // grp component writer func not implemented
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
    grp.Currency |> Option.iter (WriteCurrency strm)
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
    // grp component writer func not implemented
    // grp component writer func not implemented
    grp.RoundLot |> Option.iter (WriteRoundLot strm)
    grp.MinTradeVol |> Option.iter (WriteMinTradeVol strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.ExpirationCycle |> Option.iter (WriteExpirationCycle strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteNoMDEntriesGrp (strm:System.IO.Stream) (grp:NoMDEntriesGrp) =
    WriteMDUpdateAction strm grp.MDUpdateAction
    grp.DeleteReason |> Option.iter (WriteDeleteReason strm)
    grp.MDEntryType |> Option.iter (WriteMDEntryType strm)
    grp.MDEntryID |> Option.iter (WriteMDEntryID strm)
    grp.MDEntryRefID |> Option.iter (WriteMDEntryRefID strm)
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
    // grp subgroup writer func not implemented
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


let WriteNoRelatedSymGrp (strm:System.IO.Stream) (grp:NoRelatedSymGrp) =
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
    // grp subgroup writer func not implemented


let WriteNoQuoteEntriesGrp (strm:System.IO.Stream) (grp:NoQuoteEntriesGrp) =
    grp.QuoteEntryID |> Option.iter (WriteQuoteEntryID strm)
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
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


let WriteNoQuoteSetsGrp (strm:System.IO.Stream) (grp:NoQuoteSetsGrp) =
    grp.QuoteSetID |> Option.iter (WriteQuoteSetID strm)
    // grp component writer func not implemented
    grp.TotNoQuoteEntries |> Option.iter (WriteTotNoQuoteEntries strm)
    grp.LastFragment |> Option.iter (WriteLastFragment strm)
    // grp subgroup writer func not implemented


let WriteNoQuoteEntriesGrp (strm:System.IO.Stream) (grp:NoQuoteEntriesGrp) =
    WriteQuoteEntryID strm grp.QuoteEntryID
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
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


let WriteNoQuoteSetsGrp (strm:System.IO.Stream) (grp:NoQuoteSetsGrp) =
    WriteQuoteSetID strm grp.QuoteSetID
    // grp component writer func not implemented
    grp.QuoteSetValidUntilTime |> Option.iter (WriteQuoteSetValidUntilTime strm)
    WriteTotNoQuoteEntries strm grp.TotNoQuoteEntries
    grp.LastFragment |> Option.iter (WriteLastFragment strm)
    // grp subgroup writer func not implemented


let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    // grp component writer func not implemented
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    // grp component writer func not implemented
    // grp component writer func not implemented


let WriteNoQuoteEntriesGrp (strm:System.IO.Stream) (grp:NoQuoteEntriesGrp) =
    // grp component writer func not implemented
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
    // grp subgroup writer func not implemented


let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    // grp component writer func not implemented
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    // grp component writer func not implemented
    // grp component writer func not implemented
    grp.LegPriceType |> Option.iter (WriteLegPriceType strm)
    grp.LegBidPx |> Option.iter (WriteLegBidPx strm)
    grp.LegOfferPx |> Option.iter (WriteLegOfferPx strm)
    // grp component writer func not implemented


let WriteNoRelatedSymGrp (strm:System.IO.Stream) (grp:NoRelatedSymGrp) =
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
    // grp subgroup writer func not implemented
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    grp.QuoteRequestType |> Option.iter (WriteQuoteRequestType strm)
    grp.QuoteType |> Option.iter (WriteQuoteType strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)


let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    // grp component writer func not implemented
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    // grp component writer func not implemented
    // grp component writer func not implemented
    // grp component writer func not implemented


let WriteNoRelatedSymGrp (strm:System.IO.Stream) (grp:NoRelatedSymGrp) =
    // grp component writer func not implemented
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    grp.QuoteRequestType |> Option.iter (WriteQuoteRequestType strm)
    grp.QuoteType |> Option.iter (WriteQuoteType strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.Side |> Option.iter (WriteSide strm)
    grp.QtyType |> Option.iter (WriteQtyType strm)
    // grp component writer func not implemented
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    grp.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    // grp component writer func not implemented
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    // grp subgroup writer func not implemented


let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    // grp component writer func not implemented
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    // grp component writer func not implemented
    // grp component writer func not implemented
    grp.LegPriceType |> Option.iter (WriteLegPriceType strm)
    grp.LegBidPx |> Option.iter (WriteLegBidPx strm)
    grp.LegOfferPx |> Option.iter (WriteLegOfferPx strm)
    // grp component writer func not implemented


let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    // grp component writer func not implemented
    grp.LegQty |> Option.iter (WriteLegQty strm)
    grp.LegSwapType |> Option.iter (WriteLegSwapType strm)
    grp.LegSettlType |> Option.iter (WriteLegSettlType strm)
    grp.LegSettlDate |> Option.iter (WriteLegSettlDate strm)
    // grp component writer func not implemented
    // grp component writer func not implemented
    // grp component writer func not implemented


let WriteNoQuoteQualifiersGrp (strm:System.IO.Stream) (grp:NoQuoteQualifiersGrp) =
    grp.QuoteQualifier |> Option.iter (WriteQuoteQualifier strm)


let WriteNoRelatedSymGrp (strm:System.IO.Stream) (grp:NoRelatedSymGrp) =
    // grp component writer func not implemented
    // grp component writer func not implemented
    // grp subgroup writer func not implemented
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    grp.QuoteRequestType |> Option.iter (WriteQuoteRequestType strm)
    grp.QuoteType |> Option.iter (WriteQuoteType strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.Side |> Option.iter (WriteSide strm)
    grp.QtyType |> Option.iter (WriteQtyType strm)
    // grp component writer func not implemented
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    grp.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    // grp component writer func not implemented
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    // grp subgroup writer func not implemented
    // grp subgroup writer func not implemented
    grp.QuotePriceType |> Option.iter (WriteQuotePriceType strm)
    grp.OrdType |> Option.iter (WriteOrdType strm)
    grp.ValidUntilTime |> Option.iter (WriteValidUntilTime strm)
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    // grp component writer func not implemented
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.Price2 |> Option.iter (WritePrice2 strm)
    // grp component writer func not implemented
    // grp component writer func not implemented


let WriteNoRelatedSymGrp (strm:System.IO.Stream) (grp:NoRelatedSymGrp) =
    // grp component writer func not implemented


let WriteNoLegsGrp (strm:System.IO.Stream) (grp:NoLegsGrp) =
    // grp component writer func not implemented
    grp.LegIOIQty |> Option.iter (WriteLegIOIQty strm)
    // grp component writer func not implemented


let WriteNoUnderlyingsGrp (strm:System.IO.Stream) (grp:NoUnderlyingsGrp) =
    // grp component writer func not implemented


let WriteNoMsgTypesGrp (strm:System.IO.Stream) (grp:NoMsgTypesGrp) =
    grp.RefMsgType |> Option.iter (WriteRefMsgType strm)
    grp.MsgDirection |> Option.iter (WriteMsgDirection strm)


let WriteNoIOIQualifiersGrp (strm:System.IO.Stream) (grp:NoIOIQualifiersGrp) =
    grp.IOIQualifier |> Option.iter (WriteIOIQualifier strm)


let WriteNoRoutingIDsGrp (strm:System.IO.Stream) (grp:NoRoutingIDsGrp) =
    grp.RoutingType |> Option.iter (WriteRoutingType strm)
    grp.RoutingID |> Option.iter (WriteRoutingID strm)


let WriteLinesOfTextGrp (strm:System.IO.Stream) (grp:LinesOfTextGrp) =
    WriteText strm grp.Text
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteNoMDEntryTypesGrp (strm:System.IO.Stream) (grp:NoMDEntryTypesGrp) =
    WriteMDEntryType strm grp.MDEntryType


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


let WriteNoAltMDSourceGrp (strm:System.IO.Stream) (grp:NoAltMDSourceGrp) =
    grp.AltMDSourceID |> Option.iter (WriteAltMDSourceID strm)


let WriteNoSecurityTypesGrp (strm:System.IO.Stream) (grp:NoSecurityTypesGrp) =
    grp.SecurityType |> Option.iter (WriteSecurityType strm)
    grp.SecuritySubType |> Option.iter (WriteSecuritySubType strm)
    grp.Product |> Option.iter (WriteProduct strm)
    grp.CFICode |> Option.iter (WriteCFICode strm)


let WriteNoContraBrokersGrp (strm:System.IO.Stream) (grp:NoContraBrokersGrp) =
    grp.ContraBroker |> Option.iter (WriteContraBroker strm)
    grp.ContraTrader |> Option.iter (WriteContraTrader strm)
    grp.ContraTradeQty |> Option.iter (WriteContraTradeQty strm)
    grp.ContraTradeTime |> Option.iter (WriteContraTradeTime strm)
    grp.ContraLegRefID |> Option.iter (WriteContraLegRefID strm)


let WriteNoAffectedOrdersGrp (strm:System.IO.Stream) (grp:NoAffectedOrdersGrp) =
    grp.OrigClOrdID |> Option.iter (WriteOrigClOrdID strm)
    grp.AffectedOrderID |> Option.iter (WriteAffectedOrderID strm)
    grp.AffectedSecondaryOrderID |> Option.iter (WriteAffectedSecondaryOrderID strm)


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


let WriteNoOrdersGrp (strm:System.IO.Stream) (grp:NoOrdersGrp) =
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


let WriteNoExecsGrp (strm:System.IO.Stream) (grp:NoExecsGrp) =
    grp.LastQty |> Option.iter (WriteLastQty strm)
    grp.ExecID |> Option.iter (WriteExecID strm)
    grp.SecondaryExecID |> Option.iter (WriteSecondaryExecID strm)
    grp.LastPx |> Option.iter (WriteLastPx strm)
    grp.LastParPx |> Option.iter (WriteLastParPx strm)
    grp.LastCapacity |> Option.iter (WriteLastCapacity strm)


let WriteNoAllocsGrp (strm:System.IO.Stream) (grp:NoAllocsGrp) =
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocPrice |> Option.iter (WriteAllocPrice strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    grp.IndividualAllocRejCode |> Option.iter (WriteIndividualAllocRejCode strm)
    grp.AllocText |> Option.iter (WriteAllocText strm)
    grp.EncodedAllocText |> Option.iter (WriteEncodedAllocText strm)


let WriteNoExecsGrp (strm:System.IO.Stream) (grp:NoExecsGrp) =
    grp.LastQty |> Option.iter (WriteLastQty strm)
    grp.ExecID |> Option.iter (WriteExecID strm)
    grp.SecondaryExecID |> Option.iter (WriteSecondaryExecID strm)
    grp.LastPx |> Option.iter (WriteLastPx strm)
    grp.LastParPx |> Option.iter (WriteLastParPx strm)
    grp.LastCapacity |> Option.iter (WriteLastCapacity strm)


let WriteNoAllocsGrp (strm:System.IO.Stream) (grp:NoAllocsGrp) =
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocPrice |> Option.iter (WriteAllocPrice strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    grp.IndividualAllocRejCode |> Option.iter (WriteIndividualAllocRejCode strm)
    grp.AllocText |> Option.iter (WriteAllocText strm)
    grp.EncodedAllocText |> Option.iter (WriteEncodedAllocText strm)


let WriteNoCapacitiesGrp (strm:System.IO.Stream) (grp:NoCapacitiesGrp) =
    WriteOrderCapacity strm grp.OrderCapacity
    grp.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    WriteOrderCapacityQty strm grp.OrderCapacityQty


let WriteNoDatesGrp (strm:System.IO.Stream) (grp:NoDatesGrp) =
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)


let WriteNoDistribInstsGrp (strm:System.IO.Stream) (grp:NoDistribInstsGrp) =
    grp.DistribPaymentMethod |> Option.iter (WriteDistribPaymentMethod strm)
    grp.DistribPercentage |> Option.iter (WriteDistribPercentage strm)
    grp.CashDistribCurr |> Option.iter (WriteCashDistribCurr strm)
    grp.CashDistribAgentName |> Option.iter (WriteCashDistribAgentName strm)
    grp.CashDistribAgentCode |> Option.iter (WriteCashDistribAgentCode strm)
    grp.CashDistribAgentAcctNumber |> Option.iter (WriteCashDistribAgentAcctNumber strm)
    grp.CashDistribPayRef |> Option.iter (WriteCashDistribPayRef strm)
    grp.CashDistribAgentAcctName |> Option.iter (WriteCashDistribAgentAcctName strm)


let WriteNoExecsGrp (strm:System.IO.Stream) (grp:NoExecsGrp) =
    grp.ExecID |> Option.iter (WriteExecID strm)


let WriteNoTradesGrp (strm:System.IO.Stream) (grp:NoTradesGrp) =
    grp.TradeReportID |> Option.iter (WriteTradeReportID strm)
    grp.SecondaryTradeReportID |> Option.iter (WriteSecondaryTradeReportID strm)


let WriteNoCollInquiryQualifierGrp (strm:System.IO.Stream) (grp:NoCollInquiryQualifierGrp) =
    grp.CollInquiryQualifier |> Option.iter (WriteCollInquiryQualifier strm)


let WriteNoCompIDsGrp (strm:System.IO.Stream) (grp:NoCompIDsGrp) =
    grp.RefCompID |> Option.iter (WriteRefCompID strm)
    grp.RefSubID |> Option.iter (WriteRefSubID strm)
    grp.LocationID |> Option.iter (WriteLocationID strm)
    grp.DeskID |> Option.iter (WriteDeskID strm)


let WriteNoCompIDsGrp (strm:System.IO.Stream) (grp:NoCompIDsGrp) =
    grp.RefCompID |> Option.iter (WriteRefCompID strm)
    grp.RefSubID |> Option.iter (WriteRefSubID strm)
    grp.LocationID |> Option.iter (WriteLocationID strm)
    grp.DeskID |> Option.iter (WriteDeskID strm)
    grp.StatusValue |> Option.iter (WriteStatusValue strm)
    grp.StatusText |> Option.iter (WriteStatusText strm)


