module Fix44.CompoundItemDU

open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs
open Fix44.CompoundItemReadFuncs


type FIXGroup =
    | AdvertisementNoUnderlyingsGrp of AdvertisementNoUnderlyingsGrp
    | AllocationInstructionAckNoAllocsGrp of AllocationInstructionAckNoAllocsGrp
    | AllocationInstructionNoAllocsGrp of AllocationInstructionNoAllocsGrp
    | AllocationInstructionNoExecsGrp of AllocationInstructionNoExecsGrp
    | AllocationReportAckNoAllocsGrp of AllocationReportAckNoAllocsGrp
    | AllocationReportNoAllocsGrp of AllocationReportNoAllocsGrp
    | AllocationReportNoExecsGrp of AllocationReportNoExecsGrp
    | BidResponseNoBidComponentsGrp of BidResponseNoBidComponentsGrp
    | CollateralAssignmentNoUnderlyingsGrp of CollateralAssignmentNoUnderlyingsGrp
    | CollateralRequestNoUnderlyingsGrp of CollateralRequestNoUnderlyingsGrp
    | CollateralResponseNoUnderlyingsGrp of CollateralResponseNoUnderlyingsGrp
    | CrossOrderCancelReplaceRequestNoSidesGrp of CrossOrderCancelReplaceRequestNoSidesGrp
    | CrossOrderCancelRequestNoSidesGrp of CrossOrderCancelRequestNoSidesGrp
    | DerivativeSecurityListNoRelatedSymGrp of DerivativeSecurityListNoRelatedSymGrp
    | ExecutionReportNoLegsGrp of ExecutionReportNoLegsGrp
    | IndicationOfInterestNoLegsGrp of IndicationOfInterestNoLegsGrp
    | LinesOfTextGrp of LinesOfTextGrp
    | ListStatusNoOrdersGrp of ListStatusNoOrdersGrp
    | ListStrikePriceNoUnderlyingsGrp of ListStrikePriceNoUnderlyingsGrp
    | MarketDataIncrementalRefreshNoMDEntriesGrp of MarketDataIncrementalRefreshNoMDEntriesGrp
    | MarketDataRequestNoRelatedSymGrp of MarketDataRequestNoRelatedSymGrp
    | MassQuoteAcknowledgementNoQuoteEntriesGrp of MassQuoteAcknowledgementNoQuoteEntriesGrp
    | MassQuoteAcknowledgementNoQuoteSetsGrp of MassQuoteAcknowledgementNoQuoteSetsGrp
    | MassQuoteNoQuoteEntriesGrp of MassQuoteNoQuoteEntriesGrp
    | MultilegOrderCancelReplaceRequestNoAllocsGrp of MultilegOrderCancelReplaceRequestNoAllocsGrp
    | MultilegOrderCancelReplaceRequestNoLegsGrp of MultilegOrderCancelReplaceRequestNoLegsGrp
    | NetworkStatusResponseNoCompIDsGrp of NetworkStatusResponseNoCompIDsGrp
    | NewOrderListNoOrdersGrp of NewOrderListNoOrdersGrp
    | NewOrderMultilegNoAllocsGrp of NewOrderMultilegNoAllocsGrp
    | NewOrderMultilegNoLegsGrp of NewOrderMultilegNoLegsGrp
    | NoAffectedOrdersGrp of NoAffectedOrdersGrp
    | NoAllocsGrp of NoAllocsGrp
    | NoAltMDSourceGrp of NoAltMDSourceGrp
    | NoBidComponentsGrp of NoBidComponentsGrp
    | NoBidDescriptorsGrp of NoBidDescriptorsGrp
    | NoCapacitiesGrp of NoCapacitiesGrp
    | NoClearingInstructionsGrp of NoClearingInstructionsGrp
    | NoCollInquiryQualifierGrp of NoCollInquiryQualifierGrp
    | NoCompIDsGrp of NoCompIDsGrp
    | NoContAmtsGrp of NoContAmtsGrp
    | NoContraBrokersGrp of NoContraBrokersGrp
    | NoDatesGrp of NoDatesGrp
    | NoDistribInstsGrp of NoDistribInstsGrp
    | NoDlvyInstGrp of NoDlvyInstGrp
    | NoEventsGrp of NoEventsGrp
    | NoExecsGrp of NoExecsGrp
    | NoHopsGrp of NoHopsGrp
    | NoIOIQualifiersGrp of NoIOIQualifiersGrp
    | NoInstrAttribGrp of NoInstrAttribGrp
    | NoLegAllocsGrp of NoLegAllocsGrp
    | NoLegSecurityAltIDGrp of NoLegSecurityAltIDGrp
    | NoLegStipulationsGrp of NoLegStipulationsGrp
    | NoLegsGrp of NoLegsGrp
    | NoMDEntriesGrp of NoMDEntriesGrp
    | NoMDEntryTypesGrp of NoMDEntryTypesGrp
    | NoMiscFeesGrp of NoMiscFeesGrp
    | NoMsgTypesGrp of NoMsgTypesGrp
    | NoNested2PartyIDsGrp of NoNested2PartyIDsGrp
    | NoNested2PartySubIDsGrp of NoNested2PartySubIDsGrp
    | NoNested3PartyIDsGrp of NoNested3PartyIDsGrp
    | NoNested3PartySubIDsGrp of NoNested3PartySubIDsGrp
    | NoNestedPartyIDsGrp of NoNestedPartyIDsGrp
    | NoNestedPartySubIDsGrp of NoNestedPartySubIDsGrp
    | NoOrdersGrp of NoOrdersGrp
    | NoPartyIDsGrp of NoPartyIDsGrp
    | NoPartySubIDsGrp of NoPartySubIDsGrp
    | NoPosAmtGrp of NoPosAmtGrp
    | NoPositionsGrp of NoPositionsGrp
    | NoQuoteEntriesGrp of NoQuoteEntriesGrp
    | NoQuoteQualifiersGrp of NoQuoteQualifiersGrp
    | NoQuoteSetsGrp of NoQuoteSetsGrp
    | NoRegistDtlsGrp of NoRegistDtlsGrp
    | NoRelatedSymGrp of NoRelatedSymGrp
    | NoRoutingIDsGrp of NoRoutingIDsGrp
    | NoSecurityAltIDGrp of NoSecurityAltIDGrp
    | NoSecurityTypesGrp of NoSecurityTypesGrp
    | NoSettlInstGrp of NoSettlInstGrp
    | NoSettlPartyIDsGrp of NoSettlPartyIDsGrp
    | NoSettlPartySubIDsGrp of NoSettlPartySubIDsGrp
    | NoSidesGrp of NoSidesGrp
    | NoStipulationsGrp of NoStipulationsGrp
    | NoStrikesGrp of NoStrikesGrp
    | NoTradesGrp of NoTradesGrp
    | NoTradingSessionsGrp of NoTradingSessionsGrp
    | NoTrdRegTimestampsGrp of NoTrdRegTimestampsGrp
    | NoUnderlyingSecurityAltIDGrp of NoUnderlyingSecurityAltIDGrp
    | NoUnderlyingStipsGrp of NoUnderlyingStipsGrp
    | NoUnderlyingsGrp of NoUnderlyingsGrp
    | PositionReportNoUnderlyingsGrp of PositionReportNoUnderlyingsGrp
    | QuoteNoLegsGrp of QuoteNoLegsGrp
    | QuoteRequestNoLegsGrp of QuoteRequestNoLegsGrp
    | QuoteRequestNoRelatedSymGrp of QuoteRequestNoRelatedSymGrp
    | QuoteRequestRejectNoLegsGrp of QuoteRequestRejectNoLegsGrp
    | QuoteRequestRejectNoRelatedSymGrp of QuoteRequestRejectNoRelatedSymGrp
    | QuoteResponseNoLegsGrp of QuoteResponseNoLegsGrp
    | QuoteStatusReportNoLegsGrp of QuoteStatusReportNoLegsGrp
    | RFQRequestNoRelatedSymGrp of RFQRequestNoRelatedSymGrp
    | SecurityListNoLegsGrp of SecurityListNoLegsGrp
    | SecurityListNoRelatedSymGrp of SecurityListNoRelatedSymGrp
    | TradeCaptureReportAckNoAllocsGrp of TradeCaptureReportAckNoAllocsGrp
    | TradeCaptureReportAckNoLegsGrp of TradeCaptureReportAckNoLegsGrp
    | TradeCaptureReportNoLegsGrp of TradeCaptureReportNoLegsGrp
    | TradeCaptureReportNoSidesGrp of TradeCaptureReportNoSidesGrp



let WriteCITest dest nextFreeIdx grp =
    match grp with
    | AdvertisementNoUnderlyingsGrp grp -> WriteAdvertisementNoUnderlyingsGrp dest nextFreeIdx grp
    | AllocationInstructionAckNoAllocsGrp grp -> WriteAllocationInstructionAckNoAllocsGrp dest nextFreeIdx grp
    | AllocationInstructionNoAllocsGrp grp -> WriteAllocationInstructionNoAllocsGrp dest nextFreeIdx grp
    | AllocationInstructionNoExecsGrp grp -> WriteAllocationInstructionNoExecsGrp dest nextFreeIdx grp
    | AllocationReportAckNoAllocsGrp grp -> WriteAllocationReportAckNoAllocsGrp dest nextFreeIdx grp
    | AllocationReportNoAllocsGrp grp -> WriteAllocationReportNoAllocsGrp dest nextFreeIdx grp
    | AllocationReportNoExecsGrp grp -> WriteAllocationReportNoExecsGrp dest nextFreeIdx grp
    | BidResponseNoBidComponentsGrp grp -> WriteBidResponseNoBidComponentsGrp dest nextFreeIdx grp
    | CollateralAssignmentNoUnderlyingsGrp grp -> WriteCollateralAssignmentNoUnderlyingsGrp dest nextFreeIdx grp
    | CollateralRequestNoUnderlyingsGrp grp -> WriteCollateralRequestNoUnderlyingsGrp dest nextFreeIdx grp
    | CollateralResponseNoUnderlyingsGrp grp -> WriteCollateralResponseNoUnderlyingsGrp dest nextFreeIdx grp
    | CrossOrderCancelReplaceRequestNoSidesGrp grp -> WriteCrossOrderCancelReplaceRequestNoSidesGrp dest nextFreeIdx grp
    | CrossOrderCancelRequestNoSidesGrp grp -> WriteCrossOrderCancelRequestNoSidesGrp dest nextFreeIdx grp
    | DerivativeSecurityListNoRelatedSymGrp grp -> WriteDerivativeSecurityListNoRelatedSymGrp dest nextFreeIdx grp
    | ExecutionReportNoLegsGrp grp -> WriteExecutionReportNoLegsGrp dest nextFreeIdx grp
    | IndicationOfInterestNoLegsGrp grp -> WriteIndicationOfInterestNoLegsGrp dest nextFreeIdx grp
    | LinesOfTextGrp grp -> WriteLinesOfTextGrp dest nextFreeIdx grp
    | ListStatusNoOrdersGrp grp -> WriteListStatusNoOrdersGrp dest nextFreeIdx grp
    | ListStrikePriceNoUnderlyingsGrp grp -> WriteListStrikePriceNoUnderlyingsGrp dest nextFreeIdx grp
    | MarketDataIncrementalRefreshNoMDEntriesGrp grp -> WriteMarketDataIncrementalRefreshNoMDEntriesGrp dest nextFreeIdx grp
    | MarketDataRequestNoRelatedSymGrp grp -> WriteMarketDataRequestNoRelatedSymGrp dest nextFreeIdx grp
    | MassQuoteAcknowledgementNoQuoteEntriesGrp grp -> WriteMassQuoteAcknowledgementNoQuoteEntriesGrp dest nextFreeIdx grp
    | MassQuoteAcknowledgementNoQuoteSetsGrp grp -> WriteMassQuoteAcknowledgementNoQuoteSetsGrp dest nextFreeIdx grp
    | MassQuoteNoQuoteEntriesGrp grp -> WriteMassQuoteNoQuoteEntriesGrp dest nextFreeIdx grp
    | MultilegOrderCancelReplaceRequestNoAllocsGrp grp -> WriteMultilegOrderCancelReplaceRequestNoAllocsGrp dest nextFreeIdx grp
    | MultilegOrderCancelReplaceRequestNoLegsGrp grp -> WriteMultilegOrderCancelReplaceRequestNoLegsGrp dest nextFreeIdx grp
    | NetworkStatusResponseNoCompIDsGrp grp -> WriteNetworkStatusResponseNoCompIDsGrp dest nextFreeIdx grp
    | NewOrderListNoOrdersGrp grp -> WriteNewOrderListNoOrdersGrp dest nextFreeIdx grp
    | NewOrderMultilegNoAllocsGrp grp -> WriteNewOrderMultilegNoAllocsGrp dest nextFreeIdx grp
    | NewOrderMultilegNoLegsGrp grp -> WriteNewOrderMultilegNoLegsGrp dest nextFreeIdx grp
    | NoAffectedOrdersGrp grp -> WriteNoAffectedOrdersGrp dest nextFreeIdx grp
    | NoAllocsGrp grp -> WriteNoAllocsGrp dest nextFreeIdx grp
    | NoAltMDSourceGrp grp -> WriteNoAltMDSourceGrp dest nextFreeIdx grp
    | NoBidComponentsGrp grp -> WriteNoBidComponentsGrp dest nextFreeIdx grp
    | NoBidDescriptorsGrp grp -> WriteNoBidDescriptorsGrp dest nextFreeIdx grp
    | NoCapacitiesGrp grp -> WriteNoCapacitiesGrp dest nextFreeIdx grp
    | NoClearingInstructionsGrp grp -> WriteNoClearingInstructionsGrp dest nextFreeIdx grp
    | NoCollInquiryQualifierGrp grp -> WriteNoCollInquiryQualifierGrp dest nextFreeIdx grp
    | NoCompIDsGrp grp -> WriteNoCompIDsGrp dest nextFreeIdx grp
    | NoContAmtsGrp grp -> WriteNoContAmtsGrp dest nextFreeIdx grp
    | NoContraBrokersGrp grp -> WriteNoContraBrokersGrp dest nextFreeIdx grp
    | NoDatesGrp grp -> WriteNoDatesGrp dest nextFreeIdx grp
    | NoDistribInstsGrp grp -> WriteNoDistribInstsGrp dest nextFreeIdx grp
    | NoDlvyInstGrp grp -> WriteNoDlvyInstGrp dest nextFreeIdx grp
    | NoEventsGrp grp -> WriteNoEventsGrp dest nextFreeIdx grp
    | NoExecsGrp grp -> WriteNoExecsGrp dest nextFreeIdx grp
    | NoHopsGrp grp -> WriteNoHopsGrp dest nextFreeIdx grp
    | NoIOIQualifiersGrp grp -> WriteNoIOIQualifiersGrp dest nextFreeIdx grp
    | NoInstrAttribGrp grp -> WriteNoInstrAttribGrp dest nextFreeIdx grp
    | NoLegAllocsGrp grp -> WriteNoLegAllocsGrp dest nextFreeIdx grp
    | NoLegSecurityAltIDGrp grp -> WriteNoLegSecurityAltIDGrp dest nextFreeIdx grp
    | NoLegStipulationsGrp grp -> WriteNoLegStipulationsGrp dest nextFreeIdx grp
    | NoLegsGrp grp -> WriteNoLegsGrp dest nextFreeIdx grp
    | NoMDEntriesGrp grp -> WriteNoMDEntriesGrp dest nextFreeIdx grp
    | NoMDEntryTypesGrp grp -> WriteNoMDEntryTypesGrp dest nextFreeIdx grp
    | NoMiscFeesGrp grp -> WriteNoMiscFeesGrp dest nextFreeIdx grp
    | NoMsgTypesGrp grp -> WriteNoMsgTypesGrp dest nextFreeIdx grp
    | NoNested2PartyIDsGrp grp -> WriteNoNested2PartyIDsGrp dest nextFreeIdx grp
    | NoNested2PartySubIDsGrp grp -> WriteNoNested2PartySubIDsGrp dest nextFreeIdx grp
    | NoNested3PartyIDsGrp grp -> WriteNoNested3PartyIDsGrp dest nextFreeIdx grp
    | NoNested3PartySubIDsGrp grp -> WriteNoNested3PartySubIDsGrp dest nextFreeIdx grp
    | NoNestedPartyIDsGrp grp -> WriteNoNestedPartyIDsGrp dest nextFreeIdx grp
    | NoNestedPartySubIDsGrp grp -> WriteNoNestedPartySubIDsGrp dest nextFreeIdx grp
    | NoOrdersGrp grp -> WriteNoOrdersGrp dest nextFreeIdx grp
    | NoPartyIDsGrp grp -> WriteNoPartyIDsGrp dest nextFreeIdx grp
    | NoPartySubIDsGrp grp -> WriteNoPartySubIDsGrp dest nextFreeIdx grp
    | NoPosAmtGrp grp -> WriteNoPosAmtGrp dest nextFreeIdx grp
    | NoPositionsGrp grp -> WriteNoPositionsGrp dest nextFreeIdx grp
    | NoQuoteEntriesGrp grp -> WriteNoQuoteEntriesGrp dest nextFreeIdx grp
    | NoQuoteQualifiersGrp grp -> WriteNoQuoteQualifiersGrp dest nextFreeIdx grp
    | NoQuoteSetsGrp grp -> WriteNoQuoteSetsGrp dest nextFreeIdx grp
    | NoRegistDtlsGrp grp -> WriteNoRegistDtlsGrp dest nextFreeIdx grp
    | NoRelatedSymGrp grp -> WriteNoRelatedSymGrp dest nextFreeIdx grp
    | NoRoutingIDsGrp grp -> WriteNoRoutingIDsGrp dest nextFreeIdx grp
    | NoSecurityAltIDGrp grp -> WriteNoSecurityAltIDGrp dest nextFreeIdx grp
    | NoSecurityTypesGrp grp -> WriteNoSecurityTypesGrp dest nextFreeIdx grp
    | NoSettlInstGrp grp -> WriteNoSettlInstGrp dest nextFreeIdx grp
    | NoSettlPartyIDsGrp grp -> WriteNoSettlPartyIDsGrp dest nextFreeIdx grp
    | NoSettlPartySubIDsGrp grp -> WriteNoSettlPartySubIDsGrp dest nextFreeIdx grp
    | NoSidesGrp grp -> WriteNoSidesGrp dest nextFreeIdx grp
    | NoStipulationsGrp grp -> WriteNoStipulationsGrp dest nextFreeIdx grp
    | NoStrikesGrp grp -> WriteNoStrikesGrp dest nextFreeIdx grp
    | NoTradesGrp grp -> WriteNoTradesGrp dest nextFreeIdx grp
    | NoTradingSessionsGrp grp -> WriteNoTradingSessionsGrp dest nextFreeIdx grp
    | NoTrdRegTimestampsGrp grp -> WriteNoTrdRegTimestampsGrp dest nextFreeIdx grp
    | NoUnderlyingSecurityAltIDGrp grp -> WriteNoUnderlyingSecurityAltIDGrp dest nextFreeIdx grp
    | NoUnderlyingStipsGrp grp -> WriteNoUnderlyingStipsGrp dest nextFreeIdx grp
    | NoUnderlyingsGrp grp -> WriteNoUnderlyingsGrp dest nextFreeIdx grp
    | PositionReportNoUnderlyingsGrp grp -> WritePositionReportNoUnderlyingsGrp dest nextFreeIdx grp
    | QuoteNoLegsGrp grp -> WriteQuoteNoLegsGrp dest nextFreeIdx grp
    | QuoteRequestNoLegsGrp grp -> WriteQuoteRequestNoLegsGrp dest nextFreeIdx grp
    | QuoteRequestNoRelatedSymGrp grp -> WriteQuoteRequestNoRelatedSymGrp dest nextFreeIdx grp
    | QuoteRequestRejectNoLegsGrp grp -> WriteQuoteRequestRejectNoLegsGrp dest nextFreeIdx grp
    | QuoteRequestRejectNoRelatedSymGrp grp -> WriteQuoteRequestRejectNoRelatedSymGrp dest nextFreeIdx grp
    | QuoteResponseNoLegsGrp grp -> WriteQuoteResponseNoLegsGrp dest nextFreeIdx grp
    | QuoteStatusReportNoLegsGrp grp -> WriteQuoteStatusReportNoLegsGrp dest nextFreeIdx grp
    | RFQRequestNoRelatedSymGrp grp -> WriteRFQRequestNoRelatedSymGrp dest nextFreeIdx grp
    | SecurityListNoLegsGrp grp -> WriteSecurityListNoLegsGrp dest nextFreeIdx grp
    | SecurityListNoRelatedSymGrp grp -> WriteSecurityListNoRelatedSymGrp dest nextFreeIdx grp
    | TradeCaptureReportAckNoAllocsGrp grp -> WriteTradeCaptureReportAckNoAllocsGrp dest nextFreeIdx grp
    | TradeCaptureReportAckNoLegsGrp grp -> WriteTradeCaptureReportAckNoLegsGrp dest nextFreeIdx grp
    | TradeCaptureReportNoLegsGrp grp -> WriteTradeCaptureReportNoLegsGrp dest nextFreeIdx grp
    | TradeCaptureReportNoSidesGrp grp -> WriteTradeCaptureReportNoSidesGrp dest nextFreeIdx grp



let ReadCITest (selector:FIXGroup) pos bs =
    match selector with
    | AdvertisementNoUnderlyingsGrp _ ->
        let pos, grp = ReadAdvertisementNoUnderlyingsGrp  pos bs
        pos, grp |> FIXGroup.AdvertisementNoUnderlyingsGrp
    | AllocationInstructionAckNoAllocsGrp _ ->
        let pos, grp = ReadAllocationInstructionAckNoAllocsGrp  pos bs
        pos, grp |> FIXGroup.AllocationInstructionAckNoAllocsGrp
    | AllocationInstructionNoAllocsGrp _ ->
        let pos, grp = ReadAllocationInstructionNoAllocsGrp  pos bs
        pos, grp |> FIXGroup.AllocationInstructionNoAllocsGrp
    | AllocationInstructionNoExecsGrp _ ->
        let pos, grp = ReadAllocationInstructionNoExecsGrp  pos bs
        pos, grp |> FIXGroup.AllocationInstructionNoExecsGrp
    | AllocationReportAckNoAllocsGrp _ ->
        let pos, grp = ReadAllocationReportAckNoAllocsGrp  pos bs
        pos, grp |> FIXGroup.AllocationReportAckNoAllocsGrp
    | AllocationReportNoAllocsGrp _ ->
        let pos, grp = ReadAllocationReportNoAllocsGrp  pos bs
        pos, grp |> FIXGroup.AllocationReportNoAllocsGrp
    | AllocationReportNoExecsGrp _ ->
        let pos, grp = ReadAllocationReportNoExecsGrp  pos bs
        pos, grp |> FIXGroup.AllocationReportNoExecsGrp
    | BidResponseNoBidComponentsGrp _ ->
        let pos, grp = ReadBidResponseNoBidComponentsGrp  pos bs
        pos, grp |> FIXGroup.BidResponseNoBidComponentsGrp
    | CollateralAssignmentNoUnderlyingsGrp _ ->
        let pos, grp = ReadCollateralAssignmentNoUnderlyingsGrp  pos bs
        pos, grp |> FIXGroup.CollateralAssignmentNoUnderlyingsGrp
    | CollateralRequestNoUnderlyingsGrp _ ->
        let pos, grp = ReadCollateralRequestNoUnderlyingsGrp  pos bs
        pos, grp |> FIXGroup.CollateralRequestNoUnderlyingsGrp
    | CollateralResponseNoUnderlyingsGrp _ ->
        let pos, grp = ReadCollateralResponseNoUnderlyingsGrp  pos bs
        pos, grp |> FIXGroup.CollateralResponseNoUnderlyingsGrp
    | CrossOrderCancelReplaceRequestNoSidesGrp _ ->
        let pos, grp = ReadCrossOrderCancelReplaceRequestNoSidesGrp  pos bs
        pos, grp |> FIXGroup.CrossOrderCancelReplaceRequestNoSidesGrp
    | CrossOrderCancelRequestNoSidesGrp _ ->
        let pos, grp = ReadCrossOrderCancelRequestNoSidesGrp  pos bs
        pos, grp |> FIXGroup.CrossOrderCancelRequestNoSidesGrp
    | DerivativeSecurityListNoRelatedSymGrp _ ->
        let pos, grp = ReadDerivativeSecurityListNoRelatedSymGrp  pos bs
        pos, grp |> FIXGroup.DerivativeSecurityListNoRelatedSymGrp
    | ExecutionReportNoLegsGrp _ ->
        let pos, grp = ReadExecutionReportNoLegsGrp  pos bs
        pos, grp |> FIXGroup.ExecutionReportNoLegsGrp
    | IndicationOfInterestNoLegsGrp _ ->
        let pos, grp = ReadIndicationOfInterestNoLegsGrp  pos bs
        pos, grp |> FIXGroup.IndicationOfInterestNoLegsGrp
    | LinesOfTextGrp _ ->
        let pos, grp = ReadLinesOfTextGrp  pos bs
        pos, grp |> FIXGroup.LinesOfTextGrp
    | ListStatusNoOrdersGrp _ ->
        let pos, grp = ReadListStatusNoOrdersGrp  pos bs
        pos, grp |> FIXGroup.ListStatusNoOrdersGrp
    | ListStrikePriceNoUnderlyingsGrp _ ->
        let pos, grp = ReadListStrikePriceNoUnderlyingsGrp  pos bs
        pos, grp |> FIXGroup.ListStrikePriceNoUnderlyingsGrp
    | MarketDataIncrementalRefreshNoMDEntriesGrp _ ->
        let pos, grp = ReadMarketDataIncrementalRefreshNoMDEntriesGrp  pos bs
        pos, grp |> FIXGroup.MarketDataIncrementalRefreshNoMDEntriesGrp
    | MarketDataRequestNoRelatedSymGrp _ ->
        let pos, grp = ReadMarketDataRequestNoRelatedSymGrp  pos bs
        pos, grp |> FIXGroup.MarketDataRequestNoRelatedSymGrp
    | MassQuoteAcknowledgementNoQuoteEntriesGrp _ ->
        let pos, grp = ReadMassQuoteAcknowledgementNoQuoteEntriesGrp  pos bs
        pos, grp |> FIXGroup.MassQuoteAcknowledgementNoQuoteEntriesGrp
    | MassQuoteAcknowledgementNoQuoteSetsGrp _ ->
        let pos, grp = ReadMassQuoteAcknowledgementNoQuoteSetsGrp  pos bs
        pos, grp |> FIXGroup.MassQuoteAcknowledgementNoQuoteSetsGrp
    | MassQuoteNoQuoteEntriesGrp _ ->
        let pos, grp = ReadMassQuoteNoQuoteEntriesGrp  pos bs
        pos, grp |> FIXGroup.MassQuoteNoQuoteEntriesGrp
    | MultilegOrderCancelReplaceRequestNoAllocsGrp _ ->
        let pos, grp = ReadMultilegOrderCancelReplaceRequestNoAllocsGrp  pos bs
        pos, grp |> FIXGroup.MultilegOrderCancelReplaceRequestNoAllocsGrp
    | MultilegOrderCancelReplaceRequestNoLegsGrp _ ->
        let pos, grp = ReadMultilegOrderCancelReplaceRequestNoLegsGrp  pos bs
        pos, grp |> FIXGroup.MultilegOrderCancelReplaceRequestNoLegsGrp
    | NetworkStatusResponseNoCompIDsGrp _ ->
        let pos, grp = ReadNetworkStatusResponseNoCompIDsGrp  pos bs
        pos, grp |> FIXGroup.NetworkStatusResponseNoCompIDsGrp
    | NewOrderListNoOrdersGrp _ ->
        let pos, grp = ReadNewOrderListNoOrdersGrp  pos bs
        pos, grp |> FIXGroup.NewOrderListNoOrdersGrp
    | NewOrderMultilegNoAllocsGrp _ ->
        let pos, grp = ReadNewOrderMultilegNoAllocsGrp  pos bs
        pos, grp |> FIXGroup.NewOrderMultilegNoAllocsGrp
    | NewOrderMultilegNoLegsGrp _ ->
        let pos, grp = ReadNewOrderMultilegNoLegsGrp  pos bs
        pos, grp |> FIXGroup.NewOrderMultilegNoLegsGrp
    | NoAffectedOrdersGrp _ ->
        let pos, grp = ReadNoAffectedOrdersGrp  pos bs
        pos, grp |> FIXGroup.NoAffectedOrdersGrp
    | NoAllocsGrp _ ->
        let pos, grp = ReadNoAllocsGrp  pos bs
        pos, grp |> FIXGroup.NoAllocsGrp
    | NoAltMDSourceGrp _ ->
        let pos, grp = ReadNoAltMDSourceGrp  pos bs
        pos, grp |> FIXGroup.NoAltMDSourceGrp
    | NoBidComponentsGrp _ ->
        let pos, grp = ReadNoBidComponentsGrp  pos bs
        pos, grp |> FIXGroup.NoBidComponentsGrp
    | NoBidDescriptorsGrp _ ->
        let pos, grp = ReadNoBidDescriptorsGrp  pos bs
        pos, grp |> FIXGroup.NoBidDescriptorsGrp
    | NoCapacitiesGrp _ ->
        let pos, grp = ReadNoCapacitiesGrp  pos bs
        pos, grp |> FIXGroup.NoCapacitiesGrp
    | NoClearingInstructionsGrp _ ->
        let pos, grp = ReadNoClearingInstructionsGrp  pos bs
        pos, grp |> FIXGroup.NoClearingInstructionsGrp
    | NoCollInquiryQualifierGrp _ ->
        let pos, grp = ReadNoCollInquiryQualifierGrp  pos bs
        pos, grp |> FIXGroup.NoCollInquiryQualifierGrp
    | NoCompIDsGrp _ ->
        let pos, grp = ReadNoCompIDsGrp  pos bs
        pos, grp |> FIXGroup.NoCompIDsGrp
    | NoContAmtsGrp _ ->
        let pos, grp = ReadNoContAmtsGrp  pos bs
        pos, grp |> FIXGroup.NoContAmtsGrp
    | NoContraBrokersGrp _ ->
        let pos, grp = ReadNoContraBrokersGrp  pos bs
        pos, grp |> FIXGroup.NoContraBrokersGrp
    | NoDatesGrp _ ->
        let pos, grp = ReadNoDatesGrp  pos bs
        pos, grp |> FIXGroup.NoDatesGrp
    | NoDistribInstsGrp _ ->
        let pos, grp = ReadNoDistribInstsGrp  pos bs
        pos, grp |> FIXGroup.NoDistribInstsGrp
    | NoDlvyInstGrp _ ->
        let pos, grp = ReadNoDlvyInstGrp  pos bs
        pos, grp |> FIXGroup.NoDlvyInstGrp
    | NoEventsGrp _ ->
        let pos, grp = ReadNoEventsGrp  pos bs
        pos, grp |> FIXGroup.NoEventsGrp
    | NoExecsGrp _ ->
        let pos, grp = ReadNoExecsGrp  pos bs
        pos, grp |> FIXGroup.NoExecsGrp
    | NoHopsGrp _ ->
        let pos, grp = ReadNoHopsGrp  pos bs
        pos, grp |> FIXGroup.NoHopsGrp
    | NoIOIQualifiersGrp _ ->
        let pos, grp = ReadNoIOIQualifiersGrp  pos bs
        pos, grp |> FIXGroup.NoIOIQualifiersGrp
    | NoInstrAttribGrp _ ->
        let pos, grp = ReadNoInstrAttribGrp  pos bs
        pos, grp |> FIXGroup.NoInstrAttribGrp
    | NoLegAllocsGrp _ ->
        let pos, grp = ReadNoLegAllocsGrp  pos bs
        pos, grp |> FIXGroup.NoLegAllocsGrp
    | NoLegSecurityAltIDGrp _ ->
        let pos, grp = ReadNoLegSecurityAltIDGrp  pos bs
        pos, grp |> FIXGroup.NoLegSecurityAltIDGrp
    | NoLegStipulationsGrp _ ->
        let pos, grp = ReadNoLegStipulationsGrp  pos bs
        pos, grp |> FIXGroup.NoLegStipulationsGrp
    | NoLegsGrp _ ->
        let pos, grp = ReadNoLegsGrp  pos bs
        pos, grp |> FIXGroup.NoLegsGrp
    | NoMDEntriesGrp _ ->
        let pos, grp = ReadNoMDEntriesGrp  pos bs
        pos, grp |> FIXGroup.NoMDEntriesGrp
    | NoMDEntryTypesGrp _ ->
        let pos, grp = ReadNoMDEntryTypesGrp  pos bs
        pos, grp |> FIXGroup.NoMDEntryTypesGrp
    | NoMiscFeesGrp _ ->
        let pos, grp = ReadNoMiscFeesGrp  pos bs
        pos, grp |> FIXGroup.NoMiscFeesGrp
    | NoMsgTypesGrp _ ->
        let pos, grp = ReadNoMsgTypesGrp  pos bs
        pos, grp |> FIXGroup.NoMsgTypesGrp
    | NoNested2PartyIDsGrp _ ->
        let pos, grp = ReadNoNested2PartyIDsGrp  pos bs
        pos, grp |> FIXGroup.NoNested2PartyIDsGrp
    | NoNested2PartySubIDsGrp _ ->
        let pos, grp = ReadNoNested2PartySubIDsGrp  pos bs
        pos, grp |> FIXGroup.NoNested2PartySubIDsGrp
    | NoNested3PartyIDsGrp _ ->
        let pos, grp = ReadNoNested3PartyIDsGrp  pos bs
        pos, grp |> FIXGroup.NoNested3PartyIDsGrp
    | NoNested3PartySubIDsGrp _ ->
        let pos, grp = ReadNoNested3PartySubIDsGrp  pos bs
        pos, grp |> FIXGroup.NoNested3PartySubIDsGrp
    | NoNestedPartyIDsGrp _ ->
        let pos, grp = ReadNoNestedPartyIDsGrp  pos bs
        pos, grp |> FIXGroup.NoNestedPartyIDsGrp
    | NoNestedPartySubIDsGrp _ ->
        let pos, grp = ReadNoNestedPartySubIDsGrp  pos bs
        pos, grp |> FIXGroup.NoNestedPartySubIDsGrp
    | NoOrdersGrp _ ->
        let pos, grp = ReadNoOrdersGrp  pos bs
        pos, grp |> FIXGroup.NoOrdersGrp
    | NoPartyIDsGrp _ ->
        let pos, grp = ReadNoPartyIDsGrp  pos bs
        pos, grp |> FIXGroup.NoPartyIDsGrp
    | NoPartySubIDsGrp _ ->
        let pos, grp = ReadNoPartySubIDsGrp  pos bs
        pos, grp |> FIXGroup.NoPartySubIDsGrp
    | NoPosAmtGrp _ ->
        let pos, grp = ReadNoPosAmtGrp  pos bs
        pos, grp |> FIXGroup.NoPosAmtGrp
    | NoPositionsGrp _ ->
        let pos, grp = ReadNoPositionsGrp  pos bs
        pos, grp |> FIXGroup.NoPositionsGrp
    | NoQuoteEntriesGrp _ ->
        let pos, grp = ReadNoQuoteEntriesGrp  pos bs
        pos, grp |> FIXGroup.NoQuoteEntriesGrp
    | NoQuoteQualifiersGrp _ ->
        let pos, grp = ReadNoQuoteQualifiersGrp  pos bs
        pos, grp |> FIXGroup.NoQuoteQualifiersGrp
    | NoQuoteSetsGrp _ ->
        let pos, grp = ReadNoQuoteSetsGrp  pos bs
        pos, grp |> FIXGroup.NoQuoteSetsGrp
    | NoRegistDtlsGrp _ ->
        let pos, grp = ReadNoRegistDtlsGrp  pos bs
        pos, grp |> FIXGroup.NoRegistDtlsGrp
    | NoRelatedSymGrp _ ->
        let pos, grp = ReadNoRelatedSymGrp  pos bs
        pos, grp |> FIXGroup.NoRelatedSymGrp
    | NoRoutingIDsGrp _ ->
        let pos, grp = ReadNoRoutingIDsGrp  pos bs
        pos, grp |> FIXGroup.NoRoutingIDsGrp
    | NoSecurityAltIDGrp _ ->
        let pos, grp = ReadNoSecurityAltIDGrp  pos bs
        pos, grp |> FIXGroup.NoSecurityAltIDGrp
    | NoSecurityTypesGrp _ ->
        let pos, grp = ReadNoSecurityTypesGrp  pos bs
        pos, grp |> FIXGroup.NoSecurityTypesGrp
    | NoSettlInstGrp _ ->
        let pos, grp = ReadNoSettlInstGrp  pos bs
        pos, grp |> FIXGroup.NoSettlInstGrp
    | NoSettlPartyIDsGrp _ ->
        let pos, grp = ReadNoSettlPartyIDsGrp  pos bs
        pos, grp |> FIXGroup.NoSettlPartyIDsGrp
    | NoSettlPartySubIDsGrp _ ->
        let pos, grp = ReadNoSettlPartySubIDsGrp  pos bs
        pos, grp |> FIXGroup.NoSettlPartySubIDsGrp
    | NoSidesGrp _ ->
        let pos, grp = ReadNoSidesGrp  pos bs
        pos, grp |> FIXGroup.NoSidesGrp
    | NoStipulationsGrp _ ->
        let pos, grp = ReadNoStipulationsGrp  pos bs
        pos, grp |> FIXGroup.NoStipulationsGrp
    | NoStrikesGrp _ ->
        let pos, grp = ReadNoStrikesGrp  pos bs
        pos, grp |> FIXGroup.NoStrikesGrp
    | NoTradesGrp _ ->
        let pos, grp = ReadNoTradesGrp  pos bs
        pos, grp |> FIXGroup.NoTradesGrp
    | NoTradingSessionsGrp _ ->
        let pos, grp = ReadNoTradingSessionsGrp  pos bs
        pos, grp |> FIXGroup.NoTradingSessionsGrp
    | NoTrdRegTimestampsGrp _ ->
        let pos, grp = ReadNoTrdRegTimestampsGrp  pos bs
        pos, grp |> FIXGroup.NoTrdRegTimestampsGrp
    | NoUnderlyingSecurityAltIDGrp _ ->
        let pos, grp = ReadNoUnderlyingSecurityAltIDGrp  pos bs
        pos, grp |> FIXGroup.NoUnderlyingSecurityAltIDGrp
    | NoUnderlyingStipsGrp _ ->
        let pos, grp = ReadNoUnderlyingStipsGrp  pos bs
        pos, grp |> FIXGroup.NoUnderlyingStipsGrp
    | NoUnderlyingsGrp _ ->
        let pos, grp = ReadNoUnderlyingsGrp  pos bs
        pos, grp |> FIXGroup.NoUnderlyingsGrp
    | PositionReportNoUnderlyingsGrp _ ->
        let pos, grp = ReadPositionReportNoUnderlyingsGrp  pos bs
        pos, grp |> FIXGroup.PositionReportNoUnderlyingsGrp
    | QuoteNoLegsGrp _ ->
        let pos, grp = ReadQuoteNoLegsGrp  pos bs
        pos, grp |> FIXGroup.QuoteNoLegsGrp
    | QuoteRequestNoLegsGrp _ ->
        let pos, grp = ReadQuoteRequestNoLegsGrp  pos bs
        pos, grp |> FIXGroup.QuoteRequestNoLegsGrp
    | QuoteRequestNoRelatedSymGrp _ ->
        let pos, grp = ReadQuoteRequestNoRelatedSymGrp  pos bs
        pos, grp |> FIXGroup.QuoteRequestNoRelatedSymGrp
    | QuoteRequestRejectNoLegsGrp _ ->
        let pos, grp = ReadQuoteRequestRejectNoLegsGrp  pos bs
        pos, grp |> FIXGroup.QuoteRequestRejectNoLegsGrp
    | QuoteRequestRejectNoRelatedSymGrp _ ->
        let pos, grp = ReadQuoteRequestRejectNoRelatedSymGrp  pos bs
        pos, grp |> FIXGroup.QuoteRequestRejectNoRelatedSymGrp
    | QuoteResponseNoLegsGrp _ ->
        let pos, grp = ReadQuoteResponseNoLegsGrp  pos bs
        pos, grp |> FIXGroup.QuoteResponseNoLegsGrp
    | QuoteStatusReportNoLegsGrp _ ->
        let pos, grp = ReadQuoteStatusReportNoLegsGrp  pos bs
        pos, grp |> FIXGroup.QuoteStatusReportNoLegsGrp
    | RFQRequestNoRelatedSymGrp _ ->
        let pos, grp = ReadRFQRequestNoRelatedSymGrp  pos bs
        pos, grp |> FIXGroup.RFQRequestNoRelatedSymGrp
    | SecurityListNoLegsGrp _ ->
        let pos, grp = ReadSecurityListNoLegsGrp  pos bs
        pos, grp |> FIXGroup.SecurityListNoLegsGrp
    | SecurityListNoRelatedSymGrp _ ->
        let pos, grp = ReadSecurityListNoRelatedSymGrp  pos bs
        pos, grp |> FIXGroup.SecurityListNoRelatedSymGrp
    | TradeCaptureReportAckNoAllocsGrp _ ->
        let pos, grp = ReadTradeCaptureReportAckNoAllocsGrp  pos bs
        pos, grp |> FIXGroup.TradeCaptureReportAckNoAllocsGrp
    | TradeCaptureReportAckNoLegsGrp _ ->
        let pos, grp = ReadTradeCaptureReportAckNoLegsGrp  pos bs
        pos, grp |> FIXGroup.TradeCaptureReportAckNoLegsGrp
    | TradeCaptureReportNoLegsGrp _ ->
        let pos, grp = ReadTradeCaptureReportNoLegsGrp  pos bs
        pos, grp |> FIXGroup.TradeCaptureReportNoLegsGrp
    | TradeCaptureReportNoSidesGrp _ ->
        let pos, grp = ReadTradeCaptureReportNoSidesGrp  pos bs
        pos, grp |> FIXGroup.TradeCaptureReportNoSidesGrp
