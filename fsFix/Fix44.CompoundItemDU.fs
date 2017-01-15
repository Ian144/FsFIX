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



