module Fix44.MessageDU

open Fix44.Messages
open Fix44.MsgWriters
open Fix44.MsgReaders


type FIXMessage =
    | Advertisement of Advertisement
    | AllocationInstruction of AllocationInstruction
    | AllocationInstructionAck of AllocationInstructionAck
    | AllocationReport of AllocationReport
    | AllocationReportAck of AllocationReportAck
    | AssignmentReport of AssignmentReport
    | BidRequest of BidRequest
    | BidResponse of BidResponse
    | BusinessMessageReject of BusinessMessageReject
    | CollateralAssignment of CollateralAssignment
    | CollateralInquiry of CollateralInquiry
    | CollateralInquiryAck of CollateralInquiryAck
    | CollateralReport of CollateralReport
    | CollateralRequest of CollateralRequest
    | CollateralResponse of CollateralResponse
    | Confirmation of Confirmation
    | ConfirmationAck of ConfirmationAck
    | ConfirmationRequest of ConfirmationRequest
    | CrossOrderCancelReplaceRequest of CrossOrderCancelReplaceRequest
    | CrossOrderCancelRequest of CrossOrderCancelRequest
    | DerivativeSecurityList of DerivativeSecurityList
    | DerivativeSecurityListRequest of DerivativeSecurityListRequest
    | DontKnowTrade of DontKnowTrade
    | Email of Email
    | ExecutionReport of ExecutionReport
    | Heartbeat of Heartbeat
    | IndicationOfInterest of IndicationOfInterest
    | ListCancelRequest of ListCancelRequest
    | ListExecute of ListExecute
    | ListStatus of ListStatus
    | ListStatusRequest of ListStatusRequest
    | ListStrikePrice of ListStrikePrice
    | Logon of Logon
    | Logout of Logout
    | MarketDataIncrementalRefresh of MarketDataIncrementalRefresh
    | MarketDataRequest of MarketDataRequest
    | MarketDataRequestReject of MarketDataRequestReject
    | MarketDataSnapshotFullRefresh of MarketDataSnapshotFullRefresh
    | MassQuote of MassQuote
    | MassQuoteAcknowledgement of MassQuoteAcknowledgement
    | MultilegOrderCancelReplaceRequest of MultilegOrderCancelReplaceRequest
    | NetworkStatusRequest of NetworkStatusRequest
    | NetworkStatusResponse of NetworkStatusResponse
    | NewOrderCross of NewOrderCross
    | NewOrderList of NewOrderList
    | NewOrderMultileg of NewOrderMultileg
    | NewOrderSingle of NewOrderSingle
    | News of News
    | OrderCancelReject of OrderCancelReject
    | OrderCancelReplaceRequest of OrderCancelReplaceRequest
    | OrderCancelRequest of OrderCancelRequest
    | OrderMassCancelReport of OrderMassCancelReport
    | OrderMassCancelRequest of OrderMassCancelRequest
    | OrderMassStatusRequest of OrderMassStatusRequest
    | OrderStatusRequest of OrderStatusRequest
    | PositionMaintenanceReport of PositionMaintenanceReport
    | PositionMaintenanceRequest of PositionMaintenanceRequest
    | PositionReport of PositionReport
    | Quote of Quote
    | QuoteCancel of QuoteCancel
    | QuoteRequest of QuoteRequest
    | QuoteRequestReject of QuoteRequestReject
    | QuoteResponse of QuoteResponse
    | QuoteStatusReport of QuoteStatusReport
    | QuoteStatusRequest of QuoteStatusRequest
    | RFQRequest of RFQRequest
    | RegistrationInstructions of RegistrationInstructions
    | RegistrationInstructionsResponse of RegistrationInstructionsResponse
    | Reject of Reject
    | RequestForPositions of RequestForPositions
    | RequestForPositionsAck of RequestForPositionsAck
    | ResendRequest of ResendRequest
    | SecurityDefinition of SecurityDefinition
    | SecurityDefinitionRequest of SecurityDefinitionRequest
    | SecurityList of SecurityList
    | SecurityListRequest of SecurityListRequest
    | SecurityStatus of SecurityStatus
    | SecurityStatusRequest of SecurityStatusRequest
    | SecurityTypeRequest of SecurityTypeRequest
    | SecurityTypes of SecurityTypes
    | SequenceReset of SequenceReset
    | SettlementInstructionRequest of SettlementInstructionRequest
    | SettlementInstructions of SettlementInstructions
    | TestRequest of TestRequest
    | TradeCaptureReport of TradeCaptureReport
    | TradeCaptureReportAck of TradeCaptureReportAck
    | TradeCaptureReportRequest of TradeCaptureReportRequest
    | TradeCaptureReportRequestAck of TradeCaptureReportRequestAck
    | TradingSessionStatus of TradingSessionStatus
    | TradingSessionStatusRequest of TradingSessionStatusRequest
    | UserRequest of UserRequest
    | UserResponse of UserResponse



let WriteMessage dest nextFreeIdx msg =
    match msg with
    | Advertisement msg -> WriteAdvertisement dest nextFreeIdx msg
    | AllocationInstruction msg -> WriteAllocationInstruction dest nextFreeIdx msg
    | AllocationInstructionAck msg -> WriteAllocationInstructionAck dest nextFreeIdx msg
    | AllocationReport msg -> WriteAllocationReport dest nextFreeIdx msg
    | AllocationReportAck msg -> WriteAllocationReportAck dest nextFreeIdx msg
    | AssignmentReport msg -> WriteAssignmentReport dest nextFreeIdx msg
    | BidRequest msg -> WriteBidRequest dest nextFreeIdx msg
    | BidResponse msg -> WriteBidResponse dest nextFreeIdx msg
    | BusinessMessageReject msg -> WriteBusinessMessageReject dest nextFreeIdx msg
    | CollateralAssignment msg -> WriteCollateralAssignment dest nextFreeIdx msg
    | CollateralInquiry msg -> WriteCollateralInquiry dest nextFreeIdx msg
    | CollateralInquiryAck msg -> WriteCollateralInquiryAck dest nextFreeIdx msg
    | CollateralReport msg -> WriteCollateralReport dest nextFreeIdx msg
    | CollateralRequest msg -> WriteCollateralRequest dest nextFreeIdx msg
    | CollateralResponse msg -> WriteCollateralResponse dest nextFreeIdx msg
    | Confirmation msg -> WriteConfirmation dest nextFreeIdx msg
    | ConfirmationAck msg -> WriteConfirmationAck dest nextFreeIdx msg
    | ConfirmationRequest msg -> WriteConfirmationRequest dest nextFreeIdx msg
    | CrossOrderCancelReplaceRequest msg -> WriteCrossOrderCancelReplaceRequest dest nextFreeIdx msg
    | CrossOrderCancelRequest msg -> WriteCrossOrderCancelRequest dest nextFreeIdx msg
    | DerivativeSecurityList msg -> WriteDerivativeSecurityList dest nextFreeIdx msg
    | DerivativeSecurityListRequest msg -> WriteDerivativeSecurityListRequest dest nextFreeIdx msg
    | DontKnowTrade msg -> WriteDontKnowTrade dest nextFreeIdx msg
    | Email msg -> WriteEmail dest nextFreeIdx msg
    | ExecutionReport msg -> WriteExecutionReport dest nextFreeIdx msg
    | Heartbeat msg -> WriteHeartbeat dest nextFreeIdx msg
    | IndicationOfInterest msg -> WriteIndicationOfInterest dest nextFreeIdx msg
    | ListCancelRequest msg -> WriteListCancelRequest dest nextFreeIdx msg
    | ListExecute msg -> WriteListExecute dest nextFreeIdx msg
    | ListStatus msg -> WriteListStatus dest nextFreeIdx msg
    | ListStatusRequest msg -> WriteListStatusRequest dest nextFreeIdx msg
    | ListStrikePrice msg -> WriteListStrikePrice dest nextFreeIdx msg
    | Logon msg -> WriteLogon dest nextFreeIdx msg
    | Logout msg -> WriteLogout dest nextFreeIdx msg
    | MarketDataIncrementalRefresh msg -> WriteMarketDataIncrementalRefresh dest nextFreeIdx msg
    | MarketDataRequest msg -> WriteMarketDataRequest dest nextFreeIdx msg
    | MarketDataRequestReject msg -> WriteMarketDataRequestReject dest nextFreeIdx msg
    | MarketDataSnapshotFullRefresh msg -> WriteMarketDataSnapshotFullRefresh dest nextFreeIdx msg
    | MassQuote msg -> WriteMassQuote dest nextFreeIdx msg
    | MassQuoteAcknowledgement msg -> WriteMassQuoteAcknowledgement dest nextFreeIdx msg
    | MultilegOrderCancelReplaceRequest msg -> WriteMultilegOrderCancelReplaceRequest dest nextFreeIdx msg
    | NetworkStatusRequest msg -> WriteNetworkStatusRequest dest nextFreeIdx msg
    | NetworkStatusResponse msg -> WriteNetworkStatusResponse dest nextFreeIdx msg
    | NewOrderCross msg -> WriteNewOrderCross dest nextFreeIdx msg
    | NewOrderList msg -> WriteNewOrderList dest nextFreeIdx msg
    | NewOrderMultileg msg -> WriteNewOrderMultileg dest nextFreeIdx msg
    | NewOrderSingle msg -> WriteNewOrderSingle dest nextFreeIdx msg
    | News msg -> WriteNews dest nextFreeIdx msg
    | OrderCancelReject msg -> WriteOrderCancelReject dest nextFreeIdx msg
    | OrderCancelReplaceRequest msg -> WriteOrderCancelReplaceRequest dest nextFreeIdx msg
    | OrderCancelRequest msg -> WriteOrderCancelRequest dest nextFreeIdx msg
    | OrderMassCancelReport msg -> WriteOrderMassCancelReport dest nextFreeIdx msg
    | OrderMassCancelRequest msg -> WriteOrderMassCancelRequest dest nextFreeIdx msg
    | OrderMassStatusRequest msg -> WriteOrderMassStatusRequest dest nextFreeIdx msg
    | OrderStatusRequest msg -> WriteOrderStatusRequest dest nextFreeIdx msg
    | PositionMaintenanceReport msg -> WritePositionMaintenanceReport dest nextFreeIdx msg
    | PositionMaintenanceRequest msg -> WritePositionMaintenanceRequest dest nextFreeIdx msg
    | PositionReport msg -> WritePositionReport dest nextFreeIdx msg
    | Quote msg -> WriteQuote dest nextFreeIdx msg
    | QuoteCancel msg -> WriteQuoteCancel dest nextFreeIdx msg
    | QuoteRequest msg -> WriteQuoteRequest dest nextFreeIdx msg
    | QuoteRequestReject msg -> WriteQuoteRequestReject dest nextFreeIdx msg
    | QuoteResponse msg -> WriteQuoteResponse dest nextFreeIdx msg
    | QuoteStatusReport msg -> WriteQuoteStatusReport dest nextFreeIdx msg
    | QuoteStatusRequest msg -> WriteQuoteStatusRequest dest nextFreeIdx msg
    | RFQRequest msg -> WriteRFQRequest dest nextFreeIdx msg
    | RegistrationInstructions msg -> WriteRegistrationInstructions dest nextFreeIdx msg
    | RegistrationInstructionsResponse msg -> WriteRegistrationInstructionsResponse dest nextFreeIdx msg
    | Reject msg -> WriteReject dest nextFreeIdx msg
    | RequestForPositions msg -> WriteRequestForPositions dest nextFreeIdx msg
    | RequestForPositionsAck msg -> WriteRequestForPositionsAck dest nextFreeIdx msg
    | ResendRequest msg -> WriteResendRequest dest nextFreeIdx msg
    | SecurityDefinition msg -> WriteSecurityDefinition dest nextFreeIdx msg
    | SecurityDefinitionRequest msg -> WriteSecurityDefinitionRequest dest nextFreeIdx msg
    | SecurityList msg -> WriteSecurityList dest nextFreeIdx msg
    | SecurityListRequest msg -> WriteSecurityListRequest dest nextFreeIdx msg
    | SecurityStatus msg -> WriteSecurityStatus dest nextFreeIdx msg
    | SecurityStatusRequest msg -> WriteSecurityStatusRequest dest nextFreeIdx msg
    | SecurityTypeRequest msg -> WriteSecurityTypeRequest dest nextFreeIdx msg
    | SecurityTypes msg -> WriteSecurityTypes dest nextFreeIdx msg
    | SequenceReset msg -> WriteSequenceReset dest nextFreeIdx msg
    | SettlementInstructionRequest msg -> WriteSettlementInstructionRequest dest nextFreeIdx msg
    | SettlementInstructions msg -> WriteSettlementInstructions dest nextFreeIdx msg
    | TestRequest msg -> WriteTestRequest dest nextFreeIdx msg
    | TradeCaptureReport msg -> WriteTradeCaptureReport dest nextFreeIdx msg
    | TradeCaptureReportAck msg -> WriteTradeCaptureReportAck dest nextFreeIdx msg
    | TradeCaptureReportRequest msg -> WriteTradeCaptureReportRequest dest nextFreeIdx msg
    | TradeCaptureReportRequestAck msg -> WriteTradeCaptureReportRequestAck dest nextFreeIdx msg
    | TradingSessionStatus msg -> WriteTradingSessionStatus dest nextFreeIdx msg
    | TradingSessionStatusRequest msg -> WriteTradingSessionStatusRequest dest nextFreeIdx msg
    | UserRequest msg -> WriteUserRequest dest nextFreeIdx msg
    | UserResponse msg -> WriteUserResponse dest nextFreeIdx msg



let ReadMessage selector bs (index:FIXBufIndexer.FixBufIndex) =
    match selector with
    | Advertisement _ ->
        let msg = ReadAdvertisement bs index
        msg |> FIXMessage.Advertisement
    | AllocationInstruction _ ->
        let msg = ReadAllocationInstruction bs index
        msg |> FIXMessage.AllocationInstruction
    | AllocationInstructionAck _ ->
        let msg = ReadAllocationInstructionAck bs index
        msg |> FIXMessage.AllocationInstructionAck
    | AllocationReport _ ->
        let msg = ReadAllocationReport bs index
        msg |> FIXMessage.AllocationReport
    | AllocationReportAck _ ->
        let msg = ReadAllocationReportAck bs index
        msg |> FIXMessage.AllocationReportAck
    | AssignmentReport _ ->
        let msg = ReadAssignmentReport bs index
        msg |> FIXMessage.AssignmentReport
    | BidRequest _ ->
        let msg = ReadBidRequest bs index
        msg |> FIXMessage.BidRequest
    | BidResponse _ ->
        let msg = ReadBidResponse bs index
        msg |> FIXMessage.BidResponse
    | BusinessMessageReject _ ->
        let msg = ReadBusinessMessageReject bs index
        msg |> FIXMessage.BusinessMessageReject
    | CollateralAssignment _ ->
        let msg = ReadCollateralAssignment bs index
        msg |> FIXMessage.CollateralAssignment
    | CollateralInquiry _ ->
        let msg = ReadCollateralInquiry bs index
        msg |> FIXMessage.CollateralInquiry
    | CollateralInquiryAck _ ->
        let msg = ReadCollateralInquiryAck bs index
        msg |> FIXMessage.CollateralInquiryAck
    | CollateralReport _ ->
        let msg = ReadCollateralReport bs index
        msg |> FIXMessage.CollateralReport
    | CollateralRequest _ ->
        let msg = ReadCollateralRequest bs index
        msg |> FIXMessage.CollateralRequest
    | CollateralResponse _ ->
        let msg = ReadCollateralResponse bs index
        msg |> FIXMessage.CollateralResponse
    | Confirmation _ ->
        let msg = ReadConfirmation bs index
        msg |> FIXMessage.Confirmation
    | ConfirmationAck _ ->
        let msg = ReadConfirmationAck bs index
        msg |> FIXMessage.ConfirmationAck
    | ConfirmationRequest _ ->
        let msg = ReadConfirmationRequest bs index
        msg |> FIXMessage.ConfirmationRequest
    | CrossOrderCancelReplaceRequest _ ->
        let msg = ReadCrossOrderCancelReplaceRequest bs index
        msg |> FIXMessage.CrossOrderCancelReplaceRequest
    | CrossOrderCancelRequest _ ->
        let msg = ReadCrossOrderCancelRequest bs index
        msg |> FIXMessage.CrossOrderCancelRequest
    | DerivativeSecurityList _ ->
        let msg = ReadDerivativeSecurityList bs index
        msg |> FIXMessage.DerivativeSecurityList
    | DerivativeSecurityListRequest _ ->
        let msg = ReadDerivativeSecurityListRequest bs index
        msg |> FIXMessage.DerivativeSecurityListRequest
    | DontKnowTrade _ ->
        let msg = ReadDontKnowTrade bs index
        msg |> FIXMessage.DontKnowTrade
    | Email _ ->
        let msg = ReadEmail bs index
        msg |> FIXMessage.Email
    | ExecutionReport _ ->
        let msg = ReadExecutionReport bs index
        msg |> FIXMessage.ExecutionReport
    | Heartbeat _ ->
        let msg = ReadHeartbeat bs index
        msg |> FIXMessage.Heartbeat
    | IndicationOfInterest _ ->
        let msg = ReadIndicationOfInterest bs index
        msg |> FIXMessage.IndicationOfInterest
    | ListCancelRequest _ ->
        let msg = ReadListCancelRequest bs index
        msg |> FIXMessage.ListCancelRequest
    | ListExecute _ ->
        let msg = ReadListExecute bs index
        msg |> FIXMessage.ListExecute
    | ListStatus _ ->
        let msg = ReadListStatus bs index
        msg |> FIXMessage.ListStatus
    | ListStatusRequest _ ->
        let msg = ReadListStatusRequest bs index
        msg |> FIXMessage.ListStatusRequest
    | ListStrikePrice _ ->
        let msg = ReadListStrikePrice bs index
        msg |> FIXMessage.ListStrikePrice
    | Logon _ ->
        let msg = ReadLogon bs index
        msg |> FIXMessage.Logon
    | Logout _ ->
        let msg = ReadLogout bs index
        msg |> FIXMessage.Logout
    | MarketDataIncrementalRefresh _ ->
        let msg = ReadMarketDataIncrementalRefresh bs index
        msg |> FIXMessage.MarketDataIncrementalRefresh
    | MarketDataRequest _ ->
        let msg = ReadMarketDataRequest bs index
        msg |> FIXMessage.MarketDataRequest
    | MarketDataRequestReject _ ->
        let msg = ReadMarketDataRequestReject bs index
        msg |> FIXMessage.MarketDataRequestReject
    | MarketDataSnapshotFullRefresh _ ->
        let msg = ReadMarketDataSnapshotFullRefresh bs index
        msg |> FIXMessage.MarketDataSnapshotFullRefresh
    | MassQuote _ ->
        let msg = ReadMassQuote bs index
        msg |> FIXMessage.MassQuote
    | MassQuoteAcknowledgement _ ->
        let msg = ReadMassQuoteAcknowledgement bs index
        msg |> FIXMessage.MassQuoteAcknowledgement
    | MultilegOrderCancelReplaceRequest _ ->
        let msg = ReadMultilegOrderCancelReplaceRequest bs index
        msg |> FIXMessage.MultilegOrderCancelReplaceRequest
    | NetworkStatusRequest _ ->
        let msg = ReadNetworkStatusRequest bs index
        msg |> FIXMessage.NetworkStatusRequest
    | NetworkStatusResponse _ ->
        let msg = ReadNetworkStatusResponse bs index
        msg |> FIXMessage.NetworkStatusResponse
    | NewOrderCross _ ->
        let msg = ReadNewOrderCross bs index
        msg |> FIXMessage.NewOrderCross
    | NewOrderList _ ->
        let msg = ReadNewOrderList bs index
        msg |> FIXMessage.NewOrderList
    | NewOrderMultileg _ ->
        let msg = ReadNewOrderMultileg bs index
        msg |> FIXMessage.NewOrderMultileg
    | NewOrderSingle _ ->
        let msg = ReadNewOrderSingle bs index
        msg |> FIXMessage.NewOrderSingle
    | News _ ->
        let msg = ReadNews bs index
        msg |> FIXMessage.News
    | OrderCancelReject _ ->
        let msg = ReadOrderCancelReject bs index
        msg |> FIXMessage.OrderCancelReject
    | OrderCancelReplaceRequest _ ->
        let msg = ReadOrderCancelReplaceRequest bs index
        msg |> FIXMessage.OrderCancelReplaceRequest
    | OrderCancelRequest _ ->
        let msg = ReadOrderCancelRequest bs index
        msg |> FIXMessage.OrderCancelRequest
    | OrderMassCancelReport _ ->
        let msg = ReadOrderMassCancelReport bs index
        msg |> FIXMessage.OrderMassCancelReport
    | OrderMassCancelRequest _ ->
        let msg = ReadOrderMassCancelRequest bs index
        msg |> FIXMessage.OrderMassCancelRequest
    | OrderMassStatusRequest _ ->
        let msg = ReadOrderMassStatusRequest bs index
        msg |> FIXMessage.OrderMassStatusRequest
    | OrderStatusRequest _ ->
        let msg = ReadOrderStatusRequest bs index
        msg |> FIXMessage.OrderStatusRequest
    | PositionMaintenanceReport _ ->
        let msg = ReadPositionMaintenanceReport bs index
        msg |> FIXMessage.PositionMaintenanceReport
    | PositionMaintenanceRequest _ ->
        let msg = ReadPositionMaintenanceRequest bs index
        msg |> FIXMessage.PositionMaintenanceRequest
    | PositionReport _ ->
        let msg = ReadPositionReport bs index
        msg |> FIXMessage.PositionReport
    | Quote _ ->
        let msg = ReadQuote bs index
        msg |> FIXMessage.Quote
    | QuoteCancel _ ->
        let msg = ReadQuoteCancel bs index
        msg |> FIXMessage.QuoteCancel
    | QuoteRequest _ ->
        let msg = ReadQuoteRequest bs index
        msg |> FIXMessage.QuoteRequest
    | QuoteRequestReject _ ->
        let msg = ReadQuoteRequestReject bs index
        msg |> FIXMessage.QuoteRequestReject
    | QuoteResponse _ ->
        let msg = ReadQuoteResponse bs index
        msg |> FIXMessage.QuoteResponse
    | QuoteStatusReport _ ->
        let msg = ReadQuoteStatusReport bs index
        msg |> FIXMessage.QuoteStatusReport
    | QuoteStatusRequest _ ->
        let msg = ReadQuoteStatusRequest bs index
        msg |> FIXMessage.QuoteStatusRequest
    | RFQRequest _ ->
        let msg = ReadRFQRequest bs index
        msg |> FIXMessage.RFQRequest
    | RegistrationInstructions _ ->
        let msg = ReadRegistrationInstructions bs index
        msg |> FIXMessage.RegistrationInstructions
    | RegistrationInstructionsResponse _ ->
        let msg = ReadRegistrationInstructionsResponse bs index
        msg |> FIXMessage.RegistrationInstructionsResponse
    | Reject _ ->
        let msg = ReadReject bs index
        msg |> FIXMessage.Reject
    | RequestForPositions _ ->
        let msg = ReadRequestForPositions bs index
        msg |> FIXMessage.RequestForPositions
    | RequestForPositionsAck _ ->
        let msg = ReadRequestForPositionsAck bs index
        msg |> FIXMessage.RequestForPositionsAck
    | ResendRequest _ ->
        let msg = ReadResendRequest bs index
        msg |> FIXMessage.ResendRequest
    | SecurityDefinition _ ->
        let msg = ReadSecurityDefinition bs index
        msg |> FIXMessage.SecurityDefinition
    | SecurityDefinitionRequest _ ->
        let msg = ReadSecurityDefinitionRequest bs index
        msg |> FIXMessage.SecurityDefinitionRequest
    | SecurityList _ ->
        let msg = ReadSecurityList bs index
        msg |> FIXMessage.SecurityList
    | SecurityListRequest _ ->
        let msg = ReadSecurityListRequest bs index
        msg |> FIXMessage.SecurityListRequest
    | SecurityStatus _ ->
        let msg = ReadSecurityStatus bs index
        msg |> FIXMessage.SecurityStatus
    | SecurityStatusRequest _ ->
        let msg = ReadSecurityStatusRequest bs index
        msg |> FIXMessage.SecurityStatusRequest
    | SecurityTypeRequest _ ->
        let msg = ReadSecurityTypeRequest bs index
        msg |> FIXMessage.SecurityTypeRequest
    | SecurityTypes _ ->
        let msg = ReadSecurityTypes bs index
        msg |> FIXMessage.SecurityTypes
    | SequenceReset _ ->
        let msg = ReadSequenceReset bs index
        msg |> FIXMessage.SequenceReset
    | SettlementInstructionRequest _ ->
        let msg = ReadSettlementInstructionRequest bs index
        msg |> FIXMessage.SettlementInstructionRequest
    | SettlementInstructions _ ->
        let msg = ReadSettlementInstructions bs index
        msg |> FIXMessage.SettlementInstructions
    | TestRequest _ ->
        let msg = ReadTestRequest bs index
        msg |> FIXMessage.TestRequest
    | TradeCaptureReport _ ->
        let msg = ReadTradeCaptureReport bs index
        msg |> FIXMessage.TradeCaptureReport
    | TradeCaptureReportAck _ ->
        let msg = ReadTradeCaptureReportAck bs index
        msg |> FIXMessage.TradeCaptureReportAck
    | TradeCaptureReportRequest _ ->
        let msg = ReadTradeCaptureReportRequest bs index
        msg |> FIXMessage.TradeCaptureReportRequest
    | TradeCaptureReportRequestAck _ ->
        let msg = ReadTradeCaptureReportRequestAck bs index
        msg |> FIXMessage.TradeCaptureReportRequestAck
    | TradingSessionStatus _ ->
        let msg = ReadTradingSessionStatus bs index
        msg |> FIXMessage.TradingSessionStatus
    | TradingSessionStatusRequest _ ->
        let msg = ReadTradingSessionStatusRequest bs index
        msg |> FIXMessage.TradingSessionStatusRequest
    | UserRequest _ ->
        let msg = ReadUserRequest bs index
        msg |> FIXMessage.UserRequest
    | UserResponse _ ->
        let msg = ReadUserResponse bs index
        msg |> FIXMessage.UserResponse



let ReadMessageDU tag bs (index:FIXBufIndexer.FixBufIndex) =
    match tag with
    | "0"B   ->  ReadHeartbeat bs index |> FIXMessage.Heartbeat
    | "A"B   ->  ReadLogon bs index |> FIXMessage.Logon
    | "1"B   ->  ReadTestRequest bs index |> FIXMessage.TestRequest
    | "2"B   ->  ReadResendRequest bs index |> FIXMessage.ResendRequest
    | "3"B   ->  ReadReject bs index |> FIXMessage.Reject
    | "4"B   ->  ReadSequenceReset bs index |> FIXMessage.SequenceReset
    | "5"B   ->  ReadLogout bs index |> FIXMessage.Logout
    | "j"B   ->  ReadBusinessMessageReject bs index |> FIXMessage.BusinessMessageReject
    | "BE"B   ->  ReadUserRequest bs index |> FIXMessage.UserRequest
    | "BF"B   ->  ReadUserResponse bs index |> FIXMessage.UserResponse
    | "7"B   ->  ReadAdvertisement bs index |> FIXMessage.Advertisement
    | "6"B   ->  ReadIndicationOfInterest bs index |> FIXMessage.IndicationOfInterest
    | "B"B   ->  ReadNews bs index |> FIXMessage.News
    | "C"B   ->  ReadEmail bs index |> FIXMessage.Email
    | "R"B   ->  ReadQuoteRequest bs index |> FIXMessage.QuoteRequest
    | "AJ"B   ->  ReadQuoteResponse bs index |> FIXMessage.QuoteResponse
    | "AG"B   ->  ReadQuoteRequestReject bs index |> FIXMessage.QuoteRequestReject
    | "AH"B   ->  ReadRFQRequest bs index |> FIXMessage.RFQRequest
    | "S"B   ->  ReadQuote bs index |> FIXMessage.Quote
    | "Z"B   ->  ReadQuoteCancel bs index |> FIXMessage.QuoteCancel
    | "a"B   ->  ReadQuoteStatusRequest bs index |> FIXMessage.QuoteStatusRequest
    | "AI"B   ->  ReadQuoteStatusReport bs index |> FIXMessage.QuoteStatusReport
    | "i"B   ->  ReadMassQuote bs index |> FIXMessage.MassQuote
    | "b"B   ->  ReadMassQuoteAcknowledgement bs index |> FIXMessage.MassQuoteAcknowledgement
    | "V"B   ->  ReadMarketDataRequest bs index |> FIXMessage.MarketDataRequest
    | "W"B   ->  ReadMarketDataSnapshotFullRefresh bs index |> FIXMessage.MarketDataSnapshotFullRefresh
    | "X"B   ->  ReadMarketDataIncrementalRefresh bs index |> FIXMessage.MarketDataIncrementalRefresh
    | "Y"B   ->  ReadMarketDataRequestReject bs index |> FIXMessage.MarketDataRequestReject
    | "c"B   ->  ReadSecurityDefinitionRequest bs index |> FIXMessage.SecurityDefinitionRequest
    | "d"B   ->  ReadSecurityDefinition bs index |> FIXMessage.SecurityDefinition
    | "v"B   ->  ReadSecurityTypeRequest bs index |> FIXMessage.SecurityTypeRequest
    | "w"B   ->  ReadSecurityTypes bs index |> FIXMessage.SecurityTypes
    | "x"B   ->  ReadSecurityListRequest bs index |> FIXMessage.SecurityListRequest
    | "y"B   ->  ReadSecurityList bs index |> FIXMessage.SecurityList
    | "z"B   ->  ReadDerivativeSecurityListRequest bs index |> FIXMessage.DerivativeSecurityListRequest
    | "AA"B   ->  ReadDerivativeSecurityList bs index |> FIXMessage.DerivativeSecurityList
    | "e"B   ->  ReadSecurityStatusRequest bs index |> FIXMessage.SecurityStatusRequest
    | "f"B   ->  ReadSecurityStatus bs index |> FIXMessage.SecurityStatus
    | "g"B   ->  ReadTradingSessionStatusRequest bs index |> FIXMessage.TradingSessionStatusRequest
    | "h"B   ->  ReadTradingSessionStatus bs index |> FIXMessage.TradingSessionStatus
    | "D"B   ->  ReadNewOrderSingle bs index |> FIXMessage.NewOrderSingle
    | "8"B   ->  ReadExecutionReport bs index |> FIXMessage.ExecutionReport
    | "Q"B   ->  ReadDontKnowTrade bs index |> FIXMessage.DontKnowTrade
    | "G"B   ->  ReadOrderCancelReplaceRequest bs index |> FIXMessage.OrderCancelReplaceRequest
    | "F"B   ->  ReadOrderCancelRequest bs index |> FIXMessage.OrderCancelRequest
    | "9"B   ->  ReadOrderCancelReject bs index |> FIXMessage.OrderCancelReject
    | "H"B   ->  ReadOrderStatusRequest bs index |> FIXMessage.OrderStatusRequest
    | "q"B   ->  ReadOrderMassCancelRequest bs index |> FIXMessage.OrderMassCancelRequest
    | "r"B   ->  ReadOrderMassCancelReport bs index |> FIXMessage.OrderMassCancelReport
    | "AF"B   ->  ReadOrderMassStatusRequest bs index |> FIXMessage.OrderMassStatusRequest
    | "s"B   ->  ReadNewOrderCross bs index |> FIXMessage.NewOrderCross
    | "t"B   ->  ReadCrossOrderCancelReplaceRequest bs index |> FIXMessage.CrossOrderCancelReplaceRequest
    | "u"B   ->  ReadCrossOrderCancelRequest bs index |> FIXMessage.CrossOrderCancelRequest
    | "AB"B   ->  ReadNewOrderMultileg bs index |> FIXMessage.NewOrderMultileg
    | "AC"B   ->  ReadMultilegOrderCancelReplaceRequest bs index |> FIXMessage.MultilegOrderCancelReplaceRequest
    | "k"B   ->  ReadBidRequest bs index |> FIXMessage.BidRequest
    | "l"B   ->  ReadBidResponse bs index |> FIXMessage.BidResponse
    | "E"B   ->  ReadNewOrderList bs index |> FIXMessage.NewOrderList
    | "m"B   ->  ReadListStrikePrice bs index |> FIXMessage.ListStrikePrice
    | "N"B   ->  ReadListStatus bs index |> FIXMessage.ListStatus
    | "L"B   ->  ReadListExecute bs index |> FIXMessage.ListExecute
    | "K"B   ->  ReadListCancelRequest bs index |> FIXMessage.ListCancelRequest
    | "M"B   ->  ReadListStatusRequest bs index |> FIXMessage.ListStatusRequest
    | "J"B   ->  ReadAllocationInstruction bs index |> FIXMessage.AllocationInstruction
    | "P"B   ->  ReadAllocationInstructionAck bs index |> FIXMessage.AllocationInstructionAck
    | "AS"B   ->  ReadAllocationReport bs index |> FIXMessage.AllocationReport
    | "AT"B   ->  ReadAllocationReportAck bs index |> FIXMessage.AllocationReportAck
    | "AK"B   ->  ReadConfirmation bs index |> FIXMessage.Confirmation
    | "AU"B   ->  ReadConfirmationAck bs index |> FIXMessage.ConfirmationAck
    | "BH"B   ->  ReadConfirmationRequest bs index |> FIXMessage.ConfirmationRequest
    | "T"B   ->  ReadSettlementInstructions bs index |> FIXMessage.SettlementInstructions
    | "AV"B   ->  ReadSettlementInstructionRequest bs index |> FIXMessage.SettlementInstructionRequest
    | "AD"B   ->  ReadTradeCaptureReportRequest bs index |> FIXMessage.TradeCaptureReportRequest
    | "AQ"B   ->  ReadTradeCaptureReportRequestAck bs index |> FIXMessage.TradeCaptureReportRequestAck
    | "AE"B   ->  ReadTradeCaptureReport bs index |> FIXMessage.TradeCaptureReport
    | "AR"B   ->  ReadTradeCaptureReportAck bs index |> FIXMessage.TradeCaptureReportAck
    | "o"B   ->  ReadRegistrationInstructions bs index |> FIXMessage.RegistrationInstructions
    | "p"B   ->  ReadRegistrationInstructionsResponse bs index |> FIXMessage.RegistrationInstructionsResponse
    | "AL"B   ->  ReadPositionMaintenanceRequest bs index |> FIXMessage.PositionMaintenanceRequest
    | "AM"B   ->  ReadPositionMaintenanceReport bs index |> FIXMessage.PositionMaintenanceReport
    | "AN"B   ->  ReadRequestForPositions bs index |> FIXMessage.RequestForPositions
    | "AO"B   ->  ReadRequestForPositionsAck bs index |> FIXMessage.RequestForPositionsAck
    | "AP"B   ->  ReadPositionReport bs index |> FIXMessage.PositionReport
    | "AW"B   ->  ReadAssignmentReport bs index |> FIXMessage.AssignmentReport
    | "AX"B   ->  ReadCollateralRequest bs index |> FIXMessage.CollateralRequest
    | "AY"B   ->  ReadCollateralAssignment bs index |> FIXMessage.CollateralAssignment
    | "AZ"B   ->  ReadCollateralResponse bs index |> FIXMessage.CollateralResponse
    | "BA"B   ->  ReadCollateralReport bs index |> FIXMessage.CollateralReport
    | "BB"B   ->  ReadCollateralInquiry bs index |> FIXMessage.CollateralInquiry
    | "BC"B   ->  ReadNetworkStatusRequest bs index |> FIXMessage.NetworkStatusRequest
    | "BD"B   ->  ReadNetworkStatusResponse bs index |> FIXMessage.NetworkStatusResponse
    | "BG"B   ->  ReadCollateralInquiryAck bs index |> FIXMessage.CollateralInquiryAck
    | invalidTag   ->
        let ss = sprintf "received unknown message type tag: %A" invalidTag
        failwith ss



let GetTag (msg:FIXMessage) =
    match msg with
    | Heartbeat _   -> "0"B
    | Logon _   -> "A"B
    | TestRequest _   -> "1"B
    | ResendRequest _   -> "2"B
    | Reject _   -> "3"B
    | SequenceReset _   -> "4"B
    | Logout _   -> "5"B
    | BusinessMessageReject _   -> "j"B
    | UserRequest _   -> "BE"B
    | UserResponse _   -> "BF"B
    | Advertisement _   -> "7"B
    | IndicationOfInterest _   -> "6"B
    | News _   -> "B"B
    | Email _   -> "C"B
    | QuoteRequest _   -> "R"B
    | QuoteResponse _   -> "AJ"B
    | QuoteRequestReject _   -> "AG"B
    | RFQRequest _   -> "AH"B
    | Quote _   -> "S"B
    | QuoteCancel _   -> "Z"B
    | QuoteStatusRequest _   -> "a"B
    | QuoteStatusReport _   -> "AI"B
    | MassQuote _   -> "i"B
    | MassQuoteAcknowledgement _   -> "b"B
    | MarketDataRequest _   -> "V"B
    | MarketDataSnapshotFullRefresh _   -> "W"B
    | MarketDataIncrementalRefresh _   -> "X"B
    | MarketDataRequestReject _   -> "Y"B
    | SecurityDefinitionRequest _   -> "c"B
    | SecurityDefinition _   -> "d"B
    | SecurityTypeRequest _   -> "v"B
    | SecurityTypes _   -> "w"B
    | SecurityListRequest _   -> "x"B
    | SecurityList _   -> "y"B
    | DerivativeSecurityListRequest _   -> "z"B
    | DerivativeSecurityList _   -> "AA"B
    | SecurityStatusRequest _   -> "e"B
    | SecurityStatus _   -> "f"B
    | TradingSessionStatusRequest _   -> "g"B
    | TradingSessionStatus _   -> "h"B
    | NewOrderSingle _   -> "D"B
    | ExecutionReport _   -> "8"B
    | DontKnowTrade _   -> "Q"B
    | OrderCancelReplaceRequest _   -> "G"B
    | OrderCancelRequest _   -> "F"B
    | OrderCancelReject _   -> "9"B
    | OrderStatusRequest _   -> "H"B
    | OrderMassCancelRequest _   -> "q"B
    | OrderMassCancelReport _   -> "r"B
    | OrderMassStatusRequest _   -> "AF"B
    | NewOrderCross _   -> "s"B
    | CrossOrderCancelReplaceRequest _   -> "t"B
    | CrossOrderCancelRequest _   -> "u"B
    | NewOrderMultileg _   -> "AB"B
    | MultilegOrderCancelReplaceRequest _   -> "AC"B
    | BidRequest _   -> "k"B
    | BidResponse _   -> "l"B
    | NewOrderList _   -> "E"B
    | ListStrikePrice _   -> "m"B
    | ListStatus _   -> "N"B
    | ListExecute _   -> "L"B
    | ListCancelRequest _   -> "K"B
    | ListStatusRequest _   -> "M"B
    | AllocationInstruction _   -> "J"B
    | AllocationInstructionAck _   -> "P"B
    | AllocationReport _   -> "AS"B
    | AllocationReportAck _   -> "AT"B
    | Confirmation _   -> "AK"B
    | ConfirmationAck _   -> "AU"B
    | ConfirmationRequest _   -> "BH"B
    | SettlementInstructions _   -> "T"B
    | SettlementInstructionRequest _   -> "AV"B
    | TradeCaptureReportRequest _   -> "AD"B
    | TradeCaptureReportRequestAck _   -> "AQ"B
    | TradeCaptureReport _   -> "AE"B
    | TradeCaptureReportAck _   -> "AR"B
    | RegistrationInstructions _   -> "o"B
    | RegistrationInstructionsResponse _   -> "p"B
    | PositionMaintenanceRequest _   -> "AL"B
    | PositionMaintenanceReport _   -> "AM"B
    | RequestForPositions _   -> "AN"B
    | RequestForPositionsAck _   -> "AO"B
    | PositionReport _   -> "AP"B
    | AssignmentReport _   -> "AW"B
    | CollateralRequest _   -> "AX"B
    | CollateralAssignment _   -> "AY"B
    | CollateralResponse _   -> "AZ"B
    | CollateralReport _   -> "BA"B
    | CollateralInquiry _   -> "BB"B
    | NetworkStatusRequest _   -> "BC"B
    | NetworkStatusResponse _   -> "BD"B
    | CollateralInquiryAck _   -> "BG"B
