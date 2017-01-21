module Fix44.CompoundItemDU

open Fix44.CompoundItems
open Fix44.CompoundItemWriters
open Fix44.CompoundItemReaders


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
    | TradeCaptureReportNoAllocsGrp of TradeCaptureReportNoAllocsGrp
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
    | TradeCaptureReportNoAllocsGrp grp -> WriteTradeCaptureReportNoAllocsGrp dest nextFreeIdx grp
    | TradeCaptureReportNoLegsGrp grp -> WriteTradeCaptureReportNoLegsGrp dest nextFreeIdx grp
    | TradeCaptureReportNoSidesGrp grp -> WriteTradeCaptureReportNoSidesGrp dest nextFreeIdx grp



let ReadCITest (selector:FIXGroup) bs (index:FIXBufIndexer.FixBufIndex) =
    match selector with
    | AdvertisementNoUnderlyingsGrp _ ->
        let grp = ReadAdvertisementNoUnderlyingsGrp bs index
        grp |> FIXGroup.AdvertisementNoUnderlyingsGrp
    | AllocationInstructionAckNoAllocsGrp _ ->
        let grp = ReadAllocationInstructionAckNoAllocsGrp bs index
        grp |> FIXGroup.AllocationInstructionAckNoAllocsGrp
    | AllocationInstructionNoAllocsGrp _ ->
        let grp = ReadAllocationInstructionNoAllocsGrp bs index
        grp |> FIXGroup.AllocationInstructionNoAllocsGrp
    | AllocationInstructionNoExecsGrp _ ->
        let grp = ReadAllocationInstructionNoExecsGrp bs index
        grp |> FIXGroup.AllocationInstructionNoExecsGrp
    | AllocationReportAckNoAllocsGrp _ ->
        let grp = ReadAllocationReportAckNoAllocsGrp bs index
        grp |> FIXGroup.AllocationReportAckNoAllocsGrp
    | AllocationReportNoAllocsGrp _ ->
        let grp = ReadAllocationReportNoAllocsGrp bs index
        grp |> FIXGroup.AllocationReportNoAllocsGrp
    | AllocationReportNoExecsGrp _ ->
        let grp = ReadAllocationReportNoExecsGrp bs index
        grp |> FIXGroup.AllocationReportNoExecsGrp
    | BidResponseNoBidComponentsGrp _ ->
        let grp = ReadBidResponseNoBidComponentsGrp bs index
        grp |> FIXGroup.BidResponseNoBidComponentsGrp
    | CollateralAssignmentNoUnderlyingsGrp _ ->
        let grp = ReadCollateralAssignmentNoUnderlyingsGrp bs index
        grp |> FIXGroup.CollateralAssignmentNoUnderlyingsGrp
    | CollateralRequestNoUnderlyingsGrp _ ->
        let grp = ReadCollateralRequestNoUnderlyingsGrp bs index
        grp |> FIXGroup.CollateralRequestNoUnderlyingsGrp
    | CollateralResponseNoUnderlyingsGrp _ ->
        let grp = ReadCollateralResponseNoUnderlyingsGrp bs index
        grp |> FIXGroup.CollateralResponseNoUnderlyingsGrp
    | CrossOrderCancelReplaceRequestNoSidesGrp _ ->
        let grp = ReadCrossOrderCancelReplaceRequestNoSidesGrp bs index
        grp |> FIXGroup.CrossOrderCancelReplaceRequestNoSidesGrp
    | CrossOrderCancelRequestNoSidesGrp _ ->
        let grp = ReadCrossOrderCancelRequestNoSidesGrp bs index
        grp |> FIXGroup.CrossOrderCancelRequestNoSidesGrp
    | DerivativeSecurityListNoRelatedSymGrp _ ->
        let grp = ReadDerivativeSecurityListNoRelatedSymGrp bs index
        grp |> FIXGroup.DerivativeSecurityListNoRelatedSymGrp
    | ExecutionReportNoLegsGrp _ ->
        let grp = ReadExecutionReportNoLegsGrp bs index
        grp |> FIXGroup.ExecutionReportNoLegsGrp
    | IndicationOfInterestNoLegsGrp _ ->
        let grp = ReadIndicationOfInterestNoLegsGrp bs index
        grp |> FIXGroup.IndicationOfInterestNoLegsGrp
    | LinesOfTextGrp _ ->
        let grp = ReadLinesOfTextGrp bs index
        grp |> FIXGroup.LinesOfTextGrp
    | ListStatusNoOrdersGrp _ ->
        let grp = ReadListStatusNoOrdersGrp bs index
        grp |> FIXGroup.ListStatusNoOrdersGrp
    | ListStrikePriceNoUnderlyingsGrp _ ->
        let grp = ReadListStrikePriceNoUnderlyingsGrp bs index
        grp |> FIXGroup.ListStrikePriceNoUnderlyingsGrp
    | MarketDataIncrementalRefreshNoMDEntriesGrp _ ->
        let grp = ReadMarketDataIncrementalRefreshNoMDEntriesGrp bs index
        grp |> FIXGroup.MarketDataIncrementalRefreshNoMDEntriesGrp
    | MarketDataRequestNoRelatedSymGrp _ ->
        let grp = ReadMarketDataRequestNoRelatedSymGrp bs index
        grp |> FIXGroup.MarketDataRequestNoRelatedSymGrp
    | MassQuoteAcknowledgementNoQuoteEntriesGrp _ ->
        let grp = ReadMassQuoteAcknowledgementNoQuoteEntriesGrp bs index
        grp |> FIXGroup.MassQuoteAcknowledgementNoQuoteEntriesGrp
    | MassQuoteAcknowledgementNoQuoteSetsGrp _ ->
        let grp = ReadMassQuoteAcknowledgementNoQuoteSetsGrp bs index
        grp |> FIXGroup.MassQuoteAcknowledgementNoQuoteSetsGrp
    | MassQuoteNoQuoteEntriesGrp _ ->
        let grp = ReadMassQuoteNoQuoteEntriesGrp bs index
        grp |> FIXGroup.MassQuoteNoQuoteEntriesGrp
    | MultilegOrderCancelReplaceRequestNoAllocsGrp _ ->
        let grp = ReadMultilegOrderCancelReplaceRequestNoAllocsGrp bs index
        grp |> FIXGroup.MultilegOrderCancelReplaceRequestNoAllocsGrp
    | MultilegOrderCancelReplaceRequestNoLegsGrp _ ->
        let grp = ReadMultilegOrderCancelReplaceRequestNoLegsGrp bs index
        grp |> FIXGroup.MultilegOrderCancelReplaceRequestNoLegsGrp
    | NetworkStatusResponseNoCompIDsGrp _ ->
        let grp = ReadNetworkStatusResponseNoCompIDsGrp bs index
        grp |> FIXGroup.NetworkStatusResponseNoCompIDsGrp
    | NewOrderListNoOrdersGrp _ ->
        let grp = ReadNewOrderListNoOrdersGrp bs index
        grp |> FIXGroup.NewOrderListNoOrdersGrp
    | NewOrderMultilegNoAllocsGrp _ ->
        let grp = ReadNewOrderMultilegNoAllocsGrp bs index
        grp |> FIXGroup.NewOrderMultilegNoAllocsGrp
    | NewOrderMultilegNoLegsGrp _ ->
        let grp = ReadNewOrderMultilegNoLegsGrp bs index
        grp |> FIXGroup.NewOrderMultilegNoLegsGrp
    | NoAffectedOrdersGrp _ ->
        let grp = ReadNoAffectedOrdersGrp bs index
        grp |> FIXGroup.NoAffectedOrdersGrp
    | NoAllocsGrp _ ->
        let grp = ReadNoAllocsGrp bs index
        grp |> FIXGroup.NoAllocsGrp
    | NoAltMDSourceGrp _ ->
        let grp = ReadNoAltMDSourceGrp bs index
        grp |> FIXGroup.NoAltMDSourceGrp
    | NoBidComponentsGrp _ ->
        let grp = ReadNoBidComponentsGrp bs index
        grp |> FIXGroup.NoBidComponentsGrp
    | NoBidDescriptorsGrp _ ->
        let grp = ReadNoBidDescriptorsGrp bs index
        grp |> FIXGroup.NoBidDescriptorsGrp
    | NoCapacitiesGrp _ ->
        let grp = ReadNoCapacitiesGrp bs index
        grp |> FIXGroup.NoCapacitiesGrp
    | NoClearingInstructionsGrp _ ->
        let grp = ReadNoClearingInstructionsGrp bs index
        grp |> FIXGroup.NoClearingInstructionsGrp
    | NoCollInquiryQualifierGrp _ ->
        let grp = ReadNoCollInquiryQualifierGrp bs index
        grp |> FIXGroup.NoCollInquiryQualifierGrp
    | NoCompIDsGrp _ ->
        let grp = ReadNoCompIDsGrp bs index
        grp |> FIXGroup.NoCompIDsGrp
    | NoContAmtsGrp _ ->
        let grp = ReadNoContAmtsGrp bs index
        grp |> FIXGroup.NoContAmtsGrp
    | NoContraBrokersGrp _ ->
        let grp = ReadNoContraBrokersGrp bs index
        grp |> FIXGroup.NoContraBrokersGrp
    | NoDatesGrp _ ->
        let grp = ReadNoDatesGrp bs index
        grp |> FIXGroup.NoDatesGrp
    | NoDistribInstsGrp _ ->
        let grp = ReadNoDistribInstsGrp bs index
        grp |> FIXGroup.NoDistribInstsGrp
    | NoDlvyInstGrp _ ->
        let grp = ReadNoDlvyInstGrp bs index
        grp |> FIXGroup.NoDlvyInstGrp
    | NoEventsGrp _ ->
        let grp = ReadNoEventsGrp bs index
        grp |> FIXGroup.NoEventsGrp
    | NoExecsGrp _ ->
        let grp = ReadNoExecsGrp bs index
        grp |> FIXGroup.NoExecsGrp
    | NoHopsGrp _ ->
        let grp = ReadNoHopsGrp bs index
        grp |> FIXGroup.NoHopsGrp
    | NoIOIQualifiersGrp _ ->
        let grp = ReadNoIOIQualifiersGrp bs index
        grp |> FIXGroup.NoIOIQualifiersGrp
    | NoInstrAttribGrp _ ->
        let grp = ReadNoInstrAttribGrp bs index
        grp |> FIXGroup.NoInstrAttribGrp
    | NoLegAllocsGrp _ ->
        let grp = ReadNoLegAllocsGrp bs index
        grp |> FIXGroup.NoLegAllocsGrp
    | NoLegSecurityAltIDGrp _ ->
        let grp = ReadNoLegSecurityAltIDGrp bs index
        grp |> FIXGroup.NoLegSecurityAltIDGrp
    | NoLegStipulationsGrp _ ->
        let grp = ReadNoLegStipulationsGrp bs index
        grp |> FIXGroup.NoLegStipulationsGrp
    | NoLegsGrp _ ->
        let grp = ReadNoLegsGrp bs index
        grp |> FIXGroup.NoLegsGrp
    | NoMDEntriesGrp _ ->
        let grp = ReadNoMDEntriesGrp bs index
        grp |> FIXGroup.NoMDEntriesGrp
    | NoMDEntryTypesGrp _ ->
        let grp = ReadNoMDEntryTypesGrp bs index
        grp |> FIXGroup.NoMDEntryTypesGrp
    | NoMiscFeesGrp _ ->
        let grp = ReadNoMiscFeesGrp bs index
        grp |> FIXGroup.NoMiscFeesGrp
    | NoMsgTypesGrp _ ->
        let grp = ReadNoMsgTypesGrp bs index
        grp |> FIXGroup.NoMsgTypesGrp
    | NoNested2PartyIDsGrp _ ->
        let grp = ReadNoNested2PartyIDsGrp bs index
        grp |> FIXGroup.NoNested2PartyIDsGrp
    | NoNested2PartySubIDsGrp _ ->
        let grp = ReadNoNested2PartySubIDsGrp bs index
        grp |> FIXGroup.NoNested2PartySubIDsGrp
    | NoNested3PartyIDsGrp _ ->
        let grp = ReadNoNested3PartyIDsGrp bs index
        grp |> FIXGroup.NoNested3PartyIDsGrp
    | NoNested3PartySubIDsGrp _ ->
        let grp = ReadNoNested3PartySubIDsGrp bs index
        grp |> FIXGroup.NoNested3PartySubIDsGrp
    | NoNestedPartyIDsGrp _ ->
        let grp = ReadNoNestedPartyIDsGrp bs index
        grp |> FIXGroup.NoNestedPartyIDsGrp
    | NoNestedPartySubIDsGrp _ ->
        let grp = ReadNoNestedPartySubIDsGrp bs index
        grp |> FIXGroup.NoNestedPartySubIDsGrp
    | NoOrdersGrp _ ->
        let grp = ReadNoOrdersGrp bs index
        grp |> FIXGroup.NoOrdersGrp
    | NoPartyIDsGrp _ ->
        let grp = ReadNoPartyIDsGrp bs index
        grp |> FIXGroup.NoPartyIDsGrp
    | NoPartySubIDsGrp _ ->
        let grp = ReadNoPartySubIDsGrp bs index
        grp |> FIXGroup.NoPartySubIDsGrp
    | NoPosAmtGrp _ ->
        let grp = ReadNoPosAmtGrp bs index
        grp |> FIXGroup.NoPosAmtGrp
    | NoPositionsGrp _ ->
        let grp = ReadNoPositionsGrp bs index
        grp |> FIXGroup.NoPositionsGrp
    | NoQuoteEntriesGrp _ ->
        let grp = ReadNoQuoteEntriesGrp bs index
        grp |> FIXGroup.NoQuoteEntriesGrp
    | NoQuoteQualifiersGrp _ ->
        let grp = ReadNoQuoteQualifiersGrp bs index
        grp |> FIXGroup.NoQuoteQualifiersGrp
    | NoQuoteSetsGrp _ ->
        let grp = ReadNoQuoteSetsGrp bs index
        grp |> FIXGroup.NoQuoteSetsGrp
    | NoRegistDtlsGrp _ ->
        let grp = ReadNoRegistDtlsGrp bs index
        grp |> FIXGroup.NoRegistDtlsGrp
    | NoRelatedSymGrp _ ->
        let grp = ReadNoRelatedSymGrp bs index
        grp |> FIXGroup.NoRelatedSymGrp
    | NoRoutingIDsGrp _ ->
        let grp = ReadNoRoutingIDsGrp bs index
        grp |> FIXGroup.NoRoutingIDsGrp
    | NoSecurityAltIDGrp _ ->
        let grp = ReadNoSecurityAltIDGrp bs index
        grp |> FIXGroup.NoSecurityAltIDGrp
    | NoSecurityTypesGrp _ ->
        let grp = ReadNoSecurityTypesGrp bs index
        grp |> FIXGroup.NoSecurityTypesGrp
    | NoSettlInstGrp _ ->
        let grp = ReadNoSettlInstGrp bs index
        grp |> FIXGroup.NoSettlInstGrp
    | NoSettlPartyIDsGrp _ ->
        let grp = ReadNoSettlPartyIDsGrp bs index
        grp |> FIXGroup.NoSettlPartyIDsGrp
    | NoSettlPartySubIDsGrp _ ->
        let grp = ReadNoSettlPartySubIDsGrp bs index
        grp |> FIXGroup.NoSettlPartySubIDsGrp
    | NoSidesGrp _ ->
        let grp = ReadNoSidesGrp bs index
        grp |> FIXGroup.NoSidesGrp
    | NoStipulationsGrp _ ->
        let grp = ReadNoStipulationsGrp bs index
        grp |> FIXGroup.NoStipulationsGrp
    | NoStrikesGrp _ ->
        let grp = ReadNoStrikesGrp bs index
        grp |> FIXGroup.NoStrikesGrp
    | NoTradesGrp _ ->
        let grp = ReadNoTradesGrp bs index
        grp |> FIXGroup.NoTradesGrp
    | NoTradingSessionsGrp _ ->
        let grp = ReadNoTradingSessionsGrp bs index
        grp |> FIXGroup.NoTradingSessionsGrp
    | NoTrdRegTimestampsGrp _ ->
        let grp = ReadNoTrdRegTimestampsGrp bs index
        grp |> FIXGroup.NoTrdRegTimestampsGrp
    | NoUnderlyingSecurityAltIDGrp _ ->
        let grp = ReadNoUnderlyingSecurityAltIDGrp bs index
        grp |> FIXGroup.NoUnderlyingSecurityAltIDGrp
    | NoUnderlyingStipsGrp _ ->
        let grp = ReadNoUnderlyingStipsGrp bs index
        grp |> FIXGroup.NoUnderlyingStipsGrp
    | NoUnderlyingsGrp _ ->
        let grp = ReadNoUnderlyingsGrp bs index
        grp |> FIXGroup.NoUnderlyingsGrp
    | PositionReportNoUnderlyingsGrp _ ->
        let grp = ReadPositionReportNoUnderlyingsGrp bs index
        grp |> FIXGroup.PositionReportNoUnderlyingsGrp
    | QuoteNoLegsGrp _ ->
        let grp = ReadQuoteNoLegsGrp bs index
        grp |> FIXGroup.QuoteNoLegsGrp
    | QuoteRequestNoLegsGrp _ ->
        let grp = ReadQuoteRequestNoLegsGrp bs index
        grp |> FIXGroup.QuoteRequestNoLegsGrp
    | QuoteRequestNoRelatedSymGrp _ ->
        let grp = ReadQuoteRequestNoRelatedSymGrp bs index
        grp |> FIXGroup.QuoteRequestNoRelatedSymGrp
    | QuoteRequestRejectNoLegsGrp _ ->
        let grp = ReadQuoteRequestRejectNoLegsGrp bs index
        grp |> FIXGroup.QuoteRequestRejectNoLegsGrp
    | QuoteRequestRejectNoRelatedSymGrp _ ->
        let grp = ReadQuoteRequestRejectNoRelatedSymGrp bs index
        grp |> FIXGroup.QuoteRequestRejectNoRelatedSymGrp
    | QuoteResponseNoLegsGrp _ ->
        let grp = ReadQuoteResponseNoLegsGrp bs index
        grp |> FIXGroup.QuoteResponseNoLegsGrp
    | QuoteStatusReportNoLegsGrp _ ->
        let grp = ReadQuoteStatusReportNoLegsGrp bs index
        grp |> FIXGroup.QuoteStatusReportNoLegsGrp
    | RFQRequestNoRelatedSymGrp _ ->
        let grp = ReadRFQRequestNoRelatedSymGrp bs index
        grp |> FIXGroup.RFQRequestNoRelatedSymGrp
    | SecurityListNoLegsGrp _ ->
        let grp = ReadSecurityListNoLegsGrp bs index
        grp |> FIXGroup.SecurityListNoLegsGrp
    | SecurityListNoRelatedSymGrp _ ->
        let grp = ReadSecurityListNoRelatedSymGrp bs index
        grp |> FIXGroup.SecurityListNoRelatedSymGrp
    | TradeCaptureReportAckNoAllocsGrp _ ->
        let grp = ReadTradeCaptureReportAckNoAllocsGrp bs index
        grp |> FIXGroup.TradeCaptureReportAckNoAllocsGrp
    | TradeCaptureReportAckNoLegsGrp _ ->
        let grp = ReadTradeCaptureReportAckNoLegsGrp bs index
        grp |> FIXGroup.TradeCaptureReportAckNoLegsGrp
    | TradeCaptureReportNoAllocsGrp _ ->
        let grp = ReadTradeCaptureReportNoAllocsGrp bs index
        grp |> FIXGroup.TradeCaptureReportNoAllocsGrp
    | TradeCaptureReportNoLegsGrp _ ->
        let grp = ReadTradeCaptureReportNoLegsGrp bs index
        grp |> FIXGroup.TradeCaptureReportNoLegsGrp
    | TradeCaptureReportNoSidesGrp _ ->
        let grp = ReadTradeCaptureReportNoSidesGrp bs index
        grp |> FIXGroup.TradeCaptureReportNoSidesGrp
