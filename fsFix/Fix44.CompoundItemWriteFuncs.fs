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
let WriteNoUnderlyingsGrp (strm:System.IO.Stream) (xx:NoUnderlyingsGrp) =
    WriteUnderlyingInstrument strm xx.UnderlyingInstrument    // component


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
let WriteNoLegsGrp (strm:System.IO.Stream) (xx:NoLegsGrp) =
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component


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
let WriteNoMsgTypesGrp (strm:System.IO.Stream) (xx:NoMsgTypesGrp) =
    xx.RefMsgType |> Option.iter (WriteRefMsgType strm)
    xx.MsgDirection |> Option.iter (WriteMsgDirection strm)


// group
let WriteNoHopsGrp (strm:System.IO.Stream) (xx:NoHopsGrp) =
    xx.HopCompID |> Option.iter (WriteHopCompID strm)
    xx.HopSendingTime |> Option.iter (WriteHopSendingTime strm)
    xx.HopRefID |> Option.iter (WriteHopRefID strm)


