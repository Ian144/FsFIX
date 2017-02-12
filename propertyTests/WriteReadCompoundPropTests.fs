module WriteReadMsgPropTests

open FsCheck.Xunit
open Swensen.Unquote

open Fix44.Fields
open Fix44.MessageDU

open Generators



let bufSize = 1024 * 1024
let indexBufSize = 1024 * 32


type PropTest() =
    inherit PropertyAttribute(
        Arbitrary = [|typeof<ArbOverrides>|],
        MaxTest = 1000,
        EndSize = 8,
        Verbose = false,
        QuietOnSuccess = true
        )


[<PropTest>]
let MessageWithHeaderTrailer 
        (beginString:BeginString) 
        (senderCompID:SenderCompID) 
        (targetCompID:TargetCompID) 
        (msgSeqNum:MsgSeqNum) 
        (sendingTime:SendingTime) 
        (msg:FIXMessage) =
    let buf = Array.zeroCreate<byte> bufSize
    let tmpBuf = Array.zeroCreate<byte> bufSize
    let posW = MsgReadWrite.WriteMessageDU tmpBuf  buf 0 beginString senderCompID targetCompID msgSeqNum sendingTime msg
    let msgOut = MsgReadWrite.ReadMessage buf posW
    msg =! msgOut



let WriteReadIndexTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:byte[]->FIXBufIndexer.IndexData->'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let ss = FIXBuf.toS bs posW
    printfn "%s" ss
    let index = Array.zeroCreate<FIXBufIndexer.FieldPos> indexBufSize
    let indexEnd = FIXBufIndexer.BuildIndex index bs posW
    let indexData = FIXBufIndexer.IndexData(indexEnd, index)
    let tOut = readFunc bs indexData
    for ctr = 0 to indexEnd do
        if index.[ctr] = FIXBufIndexer.emptyFieldPos then
            ()
        else
            failwithf "there is an unread FIX field in the fix buffer index, tag: %d" index.[ctr].Tag
    tIn =! tOut




[<PropTest>]
let Advertisement (msgIn:Fix44.Messages.Advertisement) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteAdvertisement Fix44.MsgReaders.ReadAdvertisement

[<PropTest>]
let AllocationInstruction (msgIn:Fix44.Messages.AllocationInstruction) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteAllocationInstruction Fix44.MsgReaders.ReadAllocationInstruction

[<PropTest>]
let AllocationInstructionAck (msgIn:Fix44.Messages.AllocationInstructionAck) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteAllocationInstructionAck Fix44.MsgReaders.ReadAllocationInstructionAck

[<PropTest>]
let AllocationReport (msgIn:Fix44.Messages.AllocationReport) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteAllocationReport Fix44.MsgReaders.ReadAllocationReport

[<PropTest>]
let AllocationReportAck (msgIn:Fix44.Messages.AllocationReportAck) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteAllocationReportAck Fix44.MsgReaders.ReadAllocationReportAck

[<PropTest>]
let AssignmentReport (msgIn:Fix44.Messages.AssignmentReport) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteAssignmentReport Fix44.MsgReaders.ReadAssignmentReport

[<PropTest>]
let BidRequest (msgIn:Fix44.Messages.BidRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteBidRequest Fix44.MsgReaders.ReadBidRequest

[<PropTest>]
let BidResponse (msgIn:Fix44.Messages.BidResponse) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteBidResponse Fix44.MsgReaders.ReadBidResponse

[<PropTest>]
let BusinessMessageReject (msgIn:Fix44.Messages.BusinessMessageReject) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteBusinessMessageReject Fix44.MsgReaders.ReadBusinessMessageReject

[<PropTest>]
let CollateralAssignment (msgIn:Fix44.Messages.CollateralAssignment) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteCollateralAssignment Fix44.MsgReaders.ReadCollateralAssignment

[<PropTest>]
let CollateralInquiry (msgIn:Fix44.Messages.CollateralInquiry) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteCollateralInquiry Fix44.MsgReaders.ReadCollateralInquiry

[<PropTest>]
let CollateralInquiryAck (msgIn:Fix44.Messages.CollateralInquiryAck) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteCollateralInquiryAck Fix44.MsgReaders.ReadCollateralInquiryAck

[<PropTest>]
let CollateralReport (msgIn:Fix44.Messages.CollateralReport) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteCollateralReport Fix44.MsgReaders.ReadCollateralReport

[<PropTest>]
let CollateralRequest (msgIn:Fix44.Messages.CollateralRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteCollateralRequest Fix44.MsgReaders.ReadCollateralRequest

[<PropTest>]
let CollateralResponse (msgIn:Fix44.Messages.CollateralResponse) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteCollateralResponse Fix44.MsgReaders.ReadCollateralResponse

[<PropTest>]
let Confirmation (msgIn:Fix44.Messages.Confirmation) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteConfirmation Fix44.MsgReaders.ReadConfirmation

[<PropTest>]
let ConfirmationAck (msgIn:Fix44.Messages.ConfirmationAck) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteConfirmationAck Fix44.MsgReaders.ReadConfirmationAck

[<PropTest>]
let ConfirmationRequest (msgIn:Fix44.Messages.ConfirmationRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteConfirmationRequest Fix44.MsgReaders.ReadConfirmationRequest

[<PropTest>]
let CrossOrderCancelReplaceRequest (msgIn:Fix44.Messages.CrossOrderCancelReplaceRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteCrossOrderCancelReplaceRequest Fix44.MsgReaders.ReadCrossOrderCancelReplaceRequest

[<PropTest>]
let CrossOrderCancelRequest (msgIn:Fix44.Messages.CrossOrderCancelRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteCrossOrderCancelRequest Fix44.MsgReaders.ReadCrossOrderCancelRequest

[<PropTest>]
let DerivativeSecurityList (msgIn:Fix44.Messages.DerivativeSecurityList) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteDerivativeSecurityList Fix44.MsgReaders.ReadDerivativeSecurityList

[<PropTest>]
let DerivativeSecurityListRequest (msgIn:Fix44.Messages.DerivativeSecurityListRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteDerivativeSecurityListRequest Fix44.MsgReaders.ReadDerivativeSecurityListRequest

[<PropTest>]
let DontKnowTrade (msgIn:Fix44.Messages.DontKnowTrade) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteDontKnowTrade Fix44.MsgReaders.ReadDontKnowTrade

[<PropTest>]
let Email (msgIn:Fix44.Messages.Email) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteEmail Fix44.MsgReaders.ReadEmail

[<PropTest>]
let ExecutionReport (msgIn:Fix44.Messages.ExecutionReport) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteExecutionReport Fix44.MsgReaders.ReadExecutionReport

[<PropTest>]
let Heartbeat (msgIn:Fix44.Messages.Heartbeat) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteHeartbeat Fix44.MsgReaders.ReadHeartbeat

[<PropTest>]
let IndicationOfInterest (msgIn:Fix44.Messages.IndicationOfInterest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteIndicationOfInterest Fix44.MsgReaders.ReadIndicationOfInterest

[<PropTest>]
let ListCancelRequest (msgIn:Fix44.Messages.ListCancelRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteListCancelRequest Fix44.MsgReaders.ReadListCancelRequest

[<PropTest>]
let ListExecute (msgIn:Fix44.Messages.ListExecute) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteListExecute Fix44.MsgReaders.ReadListExecute

[<PropTest>]
let ListStatus (msgIn:Fix44.Messages.ListStatus) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteListStatus Fix44.MsgReaders.ReadListStatus

[<PropTest>]
let ListStatusRequest (msgIn:Fix44.Messages.ListStatusRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteListStatusRequest Fix44.MsgReaders.ReadListStatusRequest

[<PropTest>]
let ListStrikePrice (msgIn:Fix44.Messages.ListStrikePrice) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteListStrikePrice Fix44.MsgReaders.ReadListStrikePrice

[<PropTest>]
let Logon (msgIn:Fix44.Messages.Logon) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteLogon Fix44.MsgReaders.ReadLogon

[<PropTest>]
let Logout (msgIn:Fix44.Messages.Logout) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteLogout Fix44.MsgReaders.ReadLogout

[<PropTest>]
let MarketDataIncrementalRefresh (msgIn:Fix44.Messages.MarketDataIncrementalRefresh) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteMarketDataIncrementalRefresh Fix44.MsgReaders.ReadMarketDataIncrementalRefresh

[<PropTest>]
let MarketDataRequest (msgIn:Fix44.Messages.MarketDataRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteMarketDataRequest Fix44.MsgReaders.ReadMarketDataRequest

[<PropTest>]
let MarketDataRequestReject (msgIn:Fix44.Messages.MarketDataRequestReject) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteMarketDataRequestReject Fix44.MsgReaders.ReadMarketDataRequestReject

[<PropTest>]
let MarketDataSnapshotFullRefresh (msgIn:Fix44.Messages.MarketDataSnapshotFullRefresh) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteMarketDataSnapshotFullRefresh Fix44.MsgReaders.ReadMarketDataSnapshotFullRefresh

[<PropTest>]
let MassQuote (msgIn:Fix44.Messages.MassQuote) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteMassQuote Fix44.MsgReaders.ReadMassQuote

[<PropTest>]
let MassQuoteAcknowledgement (msgIn:Fix44.Messages.MassQuoteAcknowledgement) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteMassQuoteAcknowledgement Fix44.MsgReaders.ReadMassQuoteAcknowledgement

[<PropTest>]
let MultilegOrderCancelReplaceRequest (msgIn:Fix44.Messages.MultilegOrderCancelReplaceRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteMultilegOrderCancelReplaceRequest Fix44.MsgReaders.ReadMultilegOrderCancelReplaceRequest

[<PropTest>]
let NetworkStatusRequest (msgIn:Fix44.Messages.NetworkStatusRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteNetworkStatusRequest Fix44.MsgReaders.ReadNetworkStatusRequest

[<PropTest>]
let NetworkStatusResponse (msgIn:Fix44.Messages.NetworkStatusResponse) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteNetworkStatusResponse Fix44.MsgReaders.ReadNetworkStatusResponse

[<PropTest>]
let NewOrderCross (msgIn:Fix44.Messages.NewOrderCross) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteNewOrderCross Fix44.MsgReaders.ReadNewOrderCross

[<PropTest>]
let NewOrderList (msgIn:Fix44.Messages.NewOrderList) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteNewOrderList Fix44.MsgReaders.ReadNewOrderList

[<PropTest>]
let NewOrderMultileg (msgIn:Fix44.Messages.NewOrderMultileg) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteNewOrderMultileg Fix44.MsgReaders.ReadNewOrderMultileg

[<PropTest>]
let NewOrderSingle (msgIn:Fix44.Messages.NewOrderSingle) = 
    WriteReadIndexTest msgIn Fix44.MsgWriters.WriteNewOrderSingle Fix44.MsgReaders.ReadNewOrderSingle

[<PropTest>]
let News (msgIn:Fix44.Messages.News) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteNews Fix44.MsgReaders.ReadNews

[<PropTest>]
let OrderCancelReject (msgIn:Fix44.Messages.OrderCancelReject) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteOrderCancelReject Fix44.MsgReaders.ReadOrderCancelReject

[<PropTest>]
let OrderCancelReplaceRequest (msgIn:Fix44.Messages.OrderCancelReplaceRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteOrderCancelReplaceRequest Fix44.MsgReaders.ReadOrderCancelReplaceRequest

[<PropTest>]
let OrderCancelRequest (msgIn:Fix44.Messages.OrderCancelRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteOrderCancelRequest Fix44.MsgReaders.ReadOrderCancelRequest

[<PropTest>]
let OrderMassCancelReport (msgIn:Fix44.Messages.OrderMassCancelReport) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteOrderMassCancelReport Fix44.MsgReaders.ReadOrderMassCancelReport

[<PropTest>]
let OrderMassCancelRequest (msgIn:Fix44.Messages.OrderMassCancelRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteOrderMassCancelRequest Fix44.MsgReaders.ReadOrderMassCancelRequest

[<PropTest>]
let OrderMassStatusRequest (msgIn:Fix44.Messages.OrderMassStatusRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteOrderMassStatusRequest Fix44.MsgReaders.ReadOrderMassStatusRequest

[<PropTest>]
let OrderStatusRequest (msgIn:Fix44.Messages.OrderStatusRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteOrderStatusRequest Fix44.MsgReaders.ReadOrderStatusRequest

[<PropTest>]
let PositionMaintenanceReport (msgIn:Fix44.Messages.PositionMaintenanceReport) = WriteReadIndexTest msgIn Fix44.MsgWriters.WritePositionMaintenanceReport Fix44.MsgReaders.ReadPositionMaintenanceReport

[<PropTest>]
let PositionMaintenanceRequest (msgIn:Fix44.Messages.PositionMaintenanceRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WritePositionMaintenanceRequest Fix44.MsgReaders.ReadPositionMaintenanceRequest

[<PropTest>]
let PositionReport (msgIn:Fix44.Messages.PositionReport) = WriteReadIndexTest msgIn Fix44.MsgWriters.WritePositionReport Fix44.MsgReaders.ReadPositionReport

[<PropTest>]
let Quote (msgIn:Fix44.Messages.Quote) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteQuote Fix44.MsgReaders.ReadQuote

[<PropTest>]
let QuoteCancel (msgIn:Fix44.Messages.QuoteCancel) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteQuoteCancel Fix44.MsgReaders.ReadQuoteCancel

[<PropTest>]
let QuoteRequest (msgIn:Fix44.Messages.QuoteRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteQuoteRequest Fix44.MsgReaders.ReadQuoteRequest

[<PropTest>]
let QuoteRequestReject (msgIn:Fix44.Messages.QuoteRequestReject) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteQuoteRequestReject Fix44.MsgReaders.ReadQuoteRequestReject

[<PropTest>]
let QuoteResponse (msgIn:Fix44.Messages.QuoteResponse) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteQuoteResponse Fix44.MsgReaders.ReadQuoteResponse

[<PropTest>]
let QuoteStatusReport (msgIn:Fix44.Messages.QuoteStatusReport) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteQuoteStatusReport Fix44.MsgReaders.ReadQuoteStatusReport

[<PropTest>]
let QuoteStatusRequest (msgIn:Fix44.Messages.QuoteStatusRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteQuoteStatusRequest Fix44.MsgReaders.ReadQuoteStatusRequest

[<PropTest>]
let RFQRequest (msgIn:Fix44.Messages.RFQRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteRFQRequest Fix44.MsgReaders.ReadRFQRequest

[<PropTest>]
let RegistrationInstructions (msgIn:Fix44.Messages.RegistrationInstructions) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteRegistrationInstructions Fix44.MsgReaders.ReadRegistrationInstructions

[<PropTest>]
let RegistrationInstructionsResponse (msgIn:Fix44.Messages.RegistrationInstructionsResponse) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteRegistrationInstructionsResponse Fix44.MsgReaders.ReadRegistrationInstructionsResponse

[<PropTest>]
let Reject (msgIn:Fix44.Messages.Reject) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteReject Fix44.MsgReaders.ReadReject

[<PropTest>]
let RequestForPositions (msgIn:Fix44.Messages.RequestForPositions) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteRequestForPositions Fix44.MsgReaders.ReadRequestForPositions

[<PropTest>]
let RequestForPositionsAck (msgIn:Fix44.Messages.RequestForPositionsAck) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteRequestForPositionsAck Fix44.MsgReaders.ReadRequestForPositionsAck

[<PropTest>]
let ResendRequest (msgIn:Fix44.Messages.ResendRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteResendRequest Fix44.MsgReaders.ReadResendRequest

[<PropTest>]
let SecurityDefinition (msgIn:Fix44.Messages.SecurityDefinition) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteSecurityDefinition Fix44.MsgReaders.ReadSecurityDefinition

[<PropTest>]
let SecurityDefinitionRequest (msgIn:Fix44.Messages.SecurityDefinitionRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteSecurityDefinitionRequest Fix44.MsgReaders.ReadSecurityDefinitionRequest

[<PropTest>]
let SecurityList (msgIn:Fix44.Messages.SecurityList) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteSecurityList Fix44.MsgReaders.ReadSecurityList

[<PropTest>]
let SecurityListRequest (msgIn:Fix44.Messages.SecurityListRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteSecurityListRequest Fix44.MsgReaders.ReadSecurityListRequest

[<PropTest>]
let SecurityStatus (msgIn:Fix44.Messages.SecurityStatus) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteSecurityStatus Fix44.MsgReaders.ReadSecurityStatus

[<PropTest>]
let SecurityStatusRequest (msgIn:Fix44.Messages.SecurityStatusRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteSecurityStatusRequest Fix44.MsgReaders.ReadSecurityStatusRequest

[<PropTest>]
let SecurityTypeRequest (msgIn:Fix44.Messages.SecurityTypeRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteSecurityTypeRequest Fix44.MsgReaders.ReadSecurityTypeRequest

[<PropTest>]
let SecurityTypes (msgIn:Fix44.Messages.SecurityTypes) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteSecurityTypes Fix44.MsgReaders.ReadSecurityTypes

[<PropTest>]
let SequenceReset (msgIn:Fix44.Messages.SequenceReset) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteSequenceReset Fix44.MsgReaders.ReadSequenceReset

[<PropTest>]
let SettlementInstructionRequest (msgIn:Fix44.Messages.SettlementInstructionRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteSettlementInstructionRequest Fix44.MsgReaders.ReadSettlementInstructionRequest

[<PropTest>]
let SettlementInstructions (msgIn:Fix44.Messages.SettlementInstructions) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteSettlementInstructions Fix44.MsgReaders.ReadSettlementInstructions

[<PropTest>]
let TestRequest (msgIn:Fix44.Messages.TestRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteTestRequest Fix44.MsgReaders.ReadTestRequest

[<PropTest>]
let TradeCaptureReport (msgIn:Fix44.Messages.TradeCaptureReport) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteTradeCaptureReport Fix44.MsgReaders.ReadTradeCaptureReport

[<PropTest>]
let TradeCaptureReportAck (msgIn:Fix44.Messages.TradeCaptureReportAck) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteTradeCaptureReportAck Fix44.MsgReaders.ReadTradeCaptureReportAck

[<PropTest>]
let TradeCaptureReportRequest (msgIn:Fix44.Messages.TradeCaptureReportRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteTradeCaptureReportRequest Fix44.MsgReaders.ReadTradeCaptureReportRequest

[<PropTest>]
let TradeCaptureReportRequestAck (msgIn:Fix44.Messages.TradeCaptureReportRequestAck) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteTradeCaptureReportRequestAck Fix44.MsgReaders.ReadTradeCaptureReportRequestAck

[<PropTest>]
let TradingSessionStatus (msgIn:Fix44.Messages.TradingSessionStatus) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteTradingSessionStatus Fix44.MsgReaders.ReadTradingSessionStatus

[<PropTest>]
let TradingSessionStatusRequest (msgIn:Fix44.Messages.TradingSessionStatusRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteTradingSessionStatusRequest Fix44.MsgReaders.ReadTradingSessionStatusRequest

[<PropTest>]
let UserRequest (msgIn:Fix44.Messages.UserRequest) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteUserRequest Fix44.MsgReaders.ReadUserRequest

[<PropTest>]
let UserResponse (msgIn:Fix44.Messages.UserResponse) = WriteReadIndexTest msgIn Fix44.MsgWriters.WriteUserResponse Fix44.MsgReaders.ReadUserResponse

