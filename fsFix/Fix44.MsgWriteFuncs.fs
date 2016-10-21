module Fix44.MsgWriteFuncs

open OneOrTwo
open Fix44.Fields
open Fix44.FieldReadWriteFuncs
open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs
open Fix44.Messages


// tag: 0
let WriteHeartbeat (xx:Heartbeat) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.TestReqID |> Option.iter (WriteTestReqID strm)


// tag: A
let WriteLogon (xx:Logon) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteEncryptMethod strm xx.EncryptMethod
    WriteHeartBtInt strm xx.HeartBtInt
    xx.RawDataLength |> Option.iter (WriteRawDataLength strm)
    xx.RawData |> Option.iter (WriteRawData strm)
    xx.ResetSeqNumFlag |> Option.iter (WriteResetSeqNumFlag strm)
    xx.NextExpectedMsgSeqNum |> Option.iter (WriteNextExpectedMsgSeqNum strm)
    xx.MaxMessageSize |> Option.iter (WriteMaxMessageSize strm)
    xx.NoMsgTypesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMsgTypes strm (Fix44.Fields.NoMsgTypes numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMsgTypesGrp strm gg)    ) // end Option.iter
    xx.TestMessageIndicator |> Option.iter (WriteTestMessageIndicator strm)
    xx.Username |> Option.iter (WriteUsername strm)
    xx.Password |> Option.iter (WritePassword strm)


// tag: 1
let WriteTestRequest (xx:TestRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteTestReqID strm xx.TestReqID


// tag: 2
let WriteResendRequest (xx:ResendRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteBeginSeqNo strm xx.BeginSeqNo
    WriteEndSeqNo strm xx.EndSeqNo


// tag: 3
let WriteReject (xx:Reject) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteRefSeqNum strm xx.RefSeqNum
    xx.RefTagID |> Option.iter (WriteRefTagID strm)
    xx.RefMsgType |> Option.iter (WriteRefMsgType strm)
    xx.SessionRejectReason |> Option.iter (WriteSessionRejectReason strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: 4
let WriteSequenceReset (xx:SequenceReset) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.GapFillFlag |> Option.iter (WriteGapFillFlag strm)
    WriteNewSeqNo strm xx.NewSeqNo


// tag: 5
let WriteLogout (xx:Logout) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: j
let WriteBusinessMessageReject (xx:BusinessMessageReject) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.RefSeqNum |> Option.iter (WriteRefSeqNum strm)
    WriteRefMsgType strm xx.RefMsgType
    xx.BusinessRejectRefID |> Option.iter (WriteBusinessRejectRefID strm)
    WriteBusinessRejectReason strm xx.BusinessRejectReason
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: BE
let WriteUserRequest (xx:UserRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteUserRequestID strm xx.UserRequestID
    WriteUserRequestType strm xx.UserRequestType
    WriteUsername strm xx.Username
    xx.Password |> Option.iter (WritePassword strm)
    xx.NewPassword |> Option.iter (WriteNewPassword strm)
    xx.RawDataLength |> Option.iter (WriteRawDataLength strm)
    xx.RawData |> Option.iter (WriteRawData strm)


// tag: BF
let WriteUserResponse (xx:UserResponse) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteUserRequestID strm xx.UserRequestID
    WriteUsername strm xx.Username
    xx.UserStatus |> Option.iter (WriteUserStatus strm)
    xx.UserStatusText |> Option.iter (WriteUserStatusText strm)


// tag: 7
let WriteAdvertisement (xx:Advertisement) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteAdvId strm xx.AdvId
    WriteAdvTransType strm xx.AdvTransType
    xx.AdvRefID |> Option.iter (WriteAdvRefID strm)
    WriteInstrument strm xx.Instrument    // component
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.Advertisement_NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteAdvertisement_NoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteAdvSide strm xx.AdvSide
    WriteQuantity strm xx.Quantity
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.TradeDate |> Option.iter (WriteTradeDate strm)
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.URLLink |> Option.iter (WriteURLLink strm)
    xx.LastMkt |> Option.iter (WriteLastMkt strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)


// tag: 6
let WriteIndicationOfInterest (xx:IndicationOfInterest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteIOIid strm xx.IOIid
    WriteIOITransType strm xx.IOITransType
    xx.IOIRefID |> Option.iter (WriteIOIRefID strm)
    WriteInstrument strm xx.Instrument    // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteSide strm xx.Side
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.OrderQtyData |> Option.iter (WriteOrderQtyData strm) // component
    WriteIOIQty strm xx.IOIQty
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.IndicationOfInterest_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteIndicationOfInterest_NoLegsGrp strm gg)    ) // end Option.iter
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.ValidUntilTime |> Option.iter (WriteValidUntilTime strm)
    xx.IOIQltyInd |> Option.iter (WriteIOIQltyInd strm)
    xx.IOINaturalFlag |> Option.iter (WriteIOINaturalFlag strm)
    xx.NoIOIQualifiersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoIOIQualifiers strm (Fix44.Fields.NoIOIQualifiers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoIOIQualifiersGrp strm gg)    ) // end Option.iter
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    xx.URLLink |> Option.iter (WriteURLLink strm)
    xx.NoRoutingIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRoutingIDs strm (Fix44.Fields.NoRoutingIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoRoutingIDsGrp strm gg)    ) // end Option.iter
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.YieldData |> Option.iter (WriteYieldData strm) // component


// tag: B
let WriteNews (xx:News) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.OrigTime |> Option.iter (WriteOrigTime strm)
    xx.Urgency |> Option.iter (WriteUrgency strm)
    WriteHeadline strm xx.Headline
    xx.EncodedHeadline |> Option.iter (WriteEncodedHeadline strm)
    xx.NoRoutingIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRoutingIDs strm (Fix44.Fields.NoRoutingIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoRoutingIDsGrp strm gg)    ) // end Option.iter
    xx.NoRelatedSymGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoRelatedSymGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    let numGrps = xx.LinesOfTextGrp.Length
    WriteLinesOfText strm (Fix44.Fields.LinesOfText numGrps) // write the 'num group repeats' field
    xx.LinesOfTextGrp |> List.iter (fun gg -> WriteLinesOfTextGrp strm gg)
    xx.URLLink |> Option.iter (WriteURLLink strm)
    xx.RawDataLength |> Option.iter (WriteRawDataLength strm)
    xx.RawData |> Option.iter (WriteRawData strm)


// tag: C
let WriteEmail (xx:Email) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteEmailThreadID strm xx.EmailThreadID
    WriteEmailType strm xx.EmailType
    xx.OrigTime |> Option.iter (WriteOrigTime strm)
    WriteSubject strm xx.Subject
    xx.EncodedSubject |> Option.iter (WriteEncodedSubject strm)
    xx.NoRoutingIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRoutingIDs strm (Fix44.Fields.NoRoutingIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoRoutingIDsGrp strm gg)    ) // end Option.iter
    xx.NoRelatedSymGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoRelatedSymGrp strm gg)    ) // end Option.iter
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.OrderID |> Option.iter (WriteOrderID strm)
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    let numGrps = xx.LinesOfTextGrp.Length
    WriteLinesOfText strm (Fix44.Fields.LinesOfText numGrps) // write the 'num group repeats' field
    xx.LinesOfTextGrp |> List.iter (fun gg -> WriteLinesOfTextGrp strm gg)
    xx.RawDataLength |> Option.iter (WriteRawDataLength strm)
    xx.RawData |> Option.iter (WriteRawData strm)


// tag: R
let WriteQuoteRequest (xx:QuoteRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteQuoteReqID strm xx.QuoteReqID
    xx.RFQReqID |> Option.iter (WriteRFQReqID strm)
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    let numGrps = xx.QuoteRequest_NoRelatedSymGrp.Length
    WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
    xx.QuoteRequest_NoRelatedSymGrp |> List.iter (fun gg -> WriteQuoteRequest_NoRelatedSymGrp strm gg)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: AJ
let WriteQuoteResponse (xx:QuoteResponse) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteQuoteRespID strm xx.QuoteRespID
    xx.QuoteID |> Option.iter (WriteQuoteID strm)
    WriteQuoteRespType strm xx.QuoteRespType
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    xx.IOIid |> Option.iter (WriteIOIid strm)
    xx.QuoteType |> Option.iter (WriteQuoteType strm)
    xx.NoQuoteQualifiersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteQualifiers strm (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoQuoteQualifiersGrp strm gg)    ) // end Option.iter
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    WriteInstrument strm xx.Instrument    // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.Side |> Option.iter (WriteSide strm)
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
    xx.QuoteResponse_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteQuoteResponse_NoLegsGrp strm gg)    ) // end Option.iter
    xx.BidPx |> Option.iter (WriteBidPx strm)
    xx.OfferPx |> Option.iter (WriteOfferPx strm)
    xx.MktBidPx |> Option.iter (WriteMktBidPx strm)
    xx.MktOfferPx |> Option.iter (WriteMktOfferPx strm)
    xx.MinBidSize |> Option.iter (WriteMinBidSize strm)
    xx.BidSize |> Option.iter (WriteBidSize strm)
    xx.MinOfferSize |> Option.iter (WriteMinOfferSize strm)
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
    xx.OrdType |> Option.iter (WriteOrdType strm)
    xx.BidForwardPoints2 |> Option.iter (WriteBidForwardPoints2 strm)
    xx.OfferForwardPoints2 |> Option.iter (WriteOfferForwardPoints2 strm)
    xx.SettlCurrBidFxRate |> Option.iter (WriteSettlCurrBidFxRate strm)
    xx.SettlCurrOfferFxRate |> Option.iter (WriteSettlCurrOfferFxRate strm)
    xx.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    xx.Commission |> Option.iter (WriteCommission strm)
    xx.CommType |> Option.iter (WriteCommType strm)
    xx.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    xx.ExDestination |> Option.iter (WriteExDestination strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.YieldData |> Option.iter (WriteYieldData strm) // component


// tag: AG
let WriteQuoteRequestReject (xx:QuoteRequestReject) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteQuoteReqID strm xx.QuoteReqID
    xx.RFQReqID |> Option.iter (WriteRFQReqID strm)
    WriteQuoteRequestRejectReason strm xx.QuoteRequestRejectReason
    let numGrps = xx.QuoteRequestReject_NoRelatedSymGrp.Length
    WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
    xx.QuoteRequestReject_NoRelatedSymGrp |> List.iter (fun gg -> WriteQuoteRequestReject_NoRelatedSymGrp strm gg)
    xx.NoQuoteQualifiersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteQualifiers strm (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoQuoteQualifiersGrp strm gg)    ) // end Option.iter
    xx.QuotePriceType |> Option.iter (WriteQuotePriceType strm)
    xx.OrdType |> Option.iter (WriteOrdType strm)
    xx.ExpireTime |> Option.iter (WriteExpireTime strm)
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.Price2 |> Option.iter (WritePrice2 strm)
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: AH
let WriteRFQRequest (xx:RFQRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteRFQReqID strm xx.RFQReqID
    let numGrps = xx.RFQRequest_NoRelatedSymGrp.Length
    WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
    xx.RFQRequest_NoRelatedSymGrp |> List.iter (fun gg -> WriteRFQRequest_NoRelatedSymGrp strm gg)
    xx.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)


// tag: S
let WriteQuote (xx:Quote) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.QuoteReqID |> Option.iter (WriteQuoteReqID strm)
    WriteQuoteID strm xx.QuoteID
    xx.QuoteRespID |> Option.iter (WriteQuoteRespID strm)
    xx.QuoteType |> Option.iter (WriteQuoteType strm)
    xx.NoQuoteQualifiersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteQualifiers strm (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoQuoteQualifiersGrp strm gg)    ) // end Option.iter
    xx.QuoteResponseLevel |> Option.iter (WriteQuoteResponseLevel strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    WriteInstrument strm xx.Instrument    // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.Side |> Option.iter (WriteSide strm)
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
    xx.Quote_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteQuote_NoLegsGrp strm gg)    ) // end Option.iter
    xx.BidPx |> Option.iter (WriteBidPx strm)
    xx.OfferPx |> Option.iter (WriteOfferPx strm)
    xx.MktBidPx |> Option.iter (WriteMktBidPx strm)
    xx.MktOfferPx |> Option.iter (WriteMktOfferPx strm)
    xx.MinBidSize |> Option.iter (WriteMinBidSize strm)
    xx.BidSize |> Option.iter (WriteBidSize strm)
    xx.MinOfferSize |> Option.iter (WriteMinOfferSize strm)
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
    xx.OrdType |> Option.iter (WriteOrdType strm)
    xx.BidForwardPoints2 |> Option.iter (WriteBidForwardPoints2 strm)
    xx.OfferForwardPoints2 |> Option.iter (WriteOfferForwardPoints2 strm)
    xx.SettlCurrBidFxRate |> Option.iter (WriteSettlCurrBidFxRate strm)
    xx.SettlCurrOfferFxRate |> Option.iter (WriteSettlCurrOfferFxRate strm)
    xx.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    xx.CommType |> Option.iter (WriteCommType strm)
    xx.Commission |> Option.iter (WriteCommission strm)
    xx.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    xx.ExDestination |> Option.iter (WriteExDestination strm)
    xx.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: Z
let WriteQuoteCancel (xx:QuoteCancel) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.QuoteReqID |> Option.iter (WriteQuoteReqID strm)
    WriteQuoteID strm xx.QuoteID
    WriteQuoteCancelType strm xx.QuoteCancelType
    xx.QuoteResponseLevel |> Option.iter (WriteQuoteResponseLevel strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.NoQuoteEntriesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteEntries strm (Fix44.Fields.NoQuoteEntries numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoQuoteEntriesGrp strm gg)    ) // end Option.iter


// tag: a
let WriteQuoteStatusRequest (xx:QuoteStatusRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.QuoteStatusReqID |> Option.iter (WriteQuoteStatusReqID strm)
    xx.QuoteID |> Option.iter (WriteQuoteID strm)
    WriteInstrument strm xx.Instrument    // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)


// tag: AI
let WriteQuoteStatusReport (xx:QuoteStatusReport) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.QuoteStatusReqID |> Option.iter (WriteQuoteStatusReqID strm)
    xx.QuoteReqID |> Option.iter (WriteQuoteReqID strm)
    WriteQuoteID strm xx.QuoteID
    xx.QuoteRespID |> Option.iter (WriteQuoteRespID strm)
    xx.QuoteType |> Option.iter (WriteQuoteType strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    WriteInstrument strm xx.Instrument    // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.Side |> Option.iter (WriteSide strm)
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
    xx.QuoteStatusReport_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteQuoteStatusReport_NoLegsGrp strm gg)    ) // end Option.iter
    xx.NoQuoteQualifiersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteQualifiers strm (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoQuoteQualifiersGrp strm gg)    ) // end Option.iter
    xx.ExpireTime |> Option.iter (WriteExpireTime strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    xx.BidPx |> Option.iter (WriteBidPx strm)
    xx.OfferPx |> Option.iter (WriteOfferPx strm)
    xx.MktBidPx |> Option.iter (WriteMktBidPx strm)
    xx.MktOfferPx |> Option.iter (WriteMktOfferPx strm)
    xx.MinBidSize |> Option.iter (WriteMinBidSize strm)
    xx.BidSize |> Option.iter (WriteBidSize strm)
    xx.MinOfferSize |> Option.iter (WriteMinOfferSize strm)
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
    xx.OrdType |> Option.iter (WriteOrdType strm)
    xx.BidForwardPoints2 |> Option.iter (WriteBidForwardPoints2 strm)
    xx.OfferForwardPoints2 |> Option.iter (WriteOfferForwardPoints2 strm)
    xx.SettlCurrBidFxRate |> Option.iter (WriteSettlCurrBidFxRate strm)
    xx.SettlCurrOfferFxRate |> Option.iter (WriteSettlCurrOfferFxRate strm)
    xx.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    xx.CommType |> Option.iter (WriteCommType strm)
    xx.Commission |> Option.iter (WriteCommission strm)
    xx.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    xx.ExDestination |> Option.iter (WriteExDestination strm)
    xx.QuoteStatus |> Option.iter (WriteQuoteStatus strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: i
let WriteMassQuote (xx:MassQuote) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.QuoteReqID |> Option.iter (WriteQuoteReqID strm)
    WriteQuoteID strm xx.QuoteID
    xx.QuoteType |> Option.iter (WriteQuoteType strm)
    xx.QuoteResponseLevel |> Option.iter (WriteQuoteResponseLevel strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.DefBidSize |> Option.iter (WriteDefBidSize strm)
    xx.DefOfferSize |> Option.iter (WriteDefOfferSize strm)
    let numGrps = xx.NoQuoteSetsGrp.Length
    WriteNoQuoteSets strm (Fix44.Fields.NoQuoteSets numGrps) // write the 'num group repeats' field
    xx.NoQuoteSetsGrp |> List.iter (fun gg -> WriteNoQuoteSetsGrp strm gg)


// tag: b
let WriteMassQuoteAcknowledgement (xx:MassQuoteAcknowledgement) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.QuoteReqID |> Option.iter (WriteQuoteReqID strm)
    xx.QuoteID |> Option.iter (WriteQuoteID strm)
    WriteQuoteStatus strm xx.QuoteStatus
    xx.QuoteRejectReason |> Option.iter (WriteQuoteRejectReason strm)
    xx.QuoteResponseLevel |> Option.iter (WriteQuoteResponseLevel strm)
    xx.QuoteType |> Option.iter (WriteQuoteType strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.MassQuoteAcknowledgement_NoQuoteSetsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteSets strm (Fix44.Fields.NoQuoteSets numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteMassQuoteAcknowledgement_NoQuoteSetsGrp strm gg)    ) // end Option.iter


// tag: V
let WriteMarketDataRequest (xx:MarketDataRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteMDReqID strm xx.MDReqID
    WriteSubscriptionRequestType strm xx.SubscriptionRequestType
    WriteMarketDepth strm xx.MarketDepth
    xx.MDUpdateType |> Option.iter (WriteMDUpdateType strm)
    xx.AggregatedBook |> Option.iter (WriteAggregatedBook strm)
    xx.OpenCloseSettlFlag |> Option.iter (WriteOpenCloseSettlFlag strm)
    xx.Scope |> Option.iter (WriteScope strm)
    xx.MDImplicitDelete |> Option.iter (WriteMDImplicitDelete strm)
    let numGrps = xx.NoMDEntryTypesGrp.Length
    WriteNoMDEntryTypes strm (Fix44.Fields.NoMDEntryTypes numGrps) // write the 'num group repeats' field
    xx.NoMDEntryTypesGrp |> List.iter (fun gg -> WriteNoMDEntryTypesGrp strm gg)
    let numGrps = xx.MarketDataRequest_NoRelatedSymGrp.Length
    WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
    xx.MarketDataRequest_NoRelatedSymGrp |> List.iter (fun gg -> WriteMarketDataRequest_NoRelatedSymGrp strm gg)
    xx.NoTradingSessionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTradingSessions strm (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradingSessionsGrp strm gg)    ) // end Option.iter
    xx.ApplQueueAction |> Option.iter (WriteApplQueueAction strm)
    xx.ApplQueueMax |> Option.iter (WriteApplQueueMax strm)


// tag: W
let WriteMarketDataSnapshotFullRefresh (xx:MarketDataSnapshotFullRefresh) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.MDReqID |> Option.iter (WriteMDReqID strm)
    WriteInstrument strm xx.Instrument    // component
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
    xx.NetChgPrevDay |> Option.iter (WriteNetChgPrevDay strm)
    let numGrps = xx.NoMDEntriesGrp.Length
    WriteNoMDEntries strm (Fix44.Fields.NoMDEntries numGrps) // write the 'num group repeats' field
    xx.NoMDEntriesGrp |> List.iter (fun gg -> WriteNoMDEntriesGrp strm gg)
    xx.ApplQueueDepth |> Option.iter (WriteApplQueueDepth strm)
    xx.ApplQueueResolution |> Option.iter (WriteApplQueueResolution strm)


// tag: X
let WriteMarketDataIncrementalRefresh (xx:MarketDataIncrementalRefresh) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.MDReqID |> Option.iter (WriteMDReqID strm)
    let numGrps = xx.MarketDataIncrementalRefresh_NoMDEntriesGrp.Length
    WriteNoMDEntries strm (Fix44.Fields.NoMDEntries numGrps) // write the 'num group repeats' field
    xx.MarketDataIncrementalRefresh_NoMDEntriesGrp |> List.iter (fun gg -> WriteMarketDataIncrementalRefresh_NoMDEntriesGrp strm gg)
    xx.ApplQueueDepth |> Option.iter (WriteApplQueueDepth strm)
    xx.ApplQueueResolution |> Option.iter (WriteApplQueueResolution strm)


// tag: Y
let WriteMarketDataRequestReject (xx:MarketDataRequestReject) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteMDReqID strm xx.MDReqID
    xx.MDReqRejReason |> Option.iter (WriteMDReqRejReason strm)
    xx.NoAltMDSourceGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAltMDSource strm (Fix44.Fields.NoAltMDSource numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoAltMDSourceGrp strm gg)    ) // end Option.iter
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: c
let WriteSecurityDefinitionRequest (xx:SecurityDefinitionRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteSecurityReqID strm xx.SecurityReqID
    WriteSecurityRequestType strm xx.SecurityRequestType
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.ExpirationCycle |> Option.iter (WriteExpirationCycle strm)
    xx.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)


// tag: d
let WriteSecurityDefinition (xx:SecurityDefinition) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteSecurityReqID strm xx.SecurityReqID
    WriteSecurityResponseID strm xx.SecurityResponseID
    WriteSecurityResponseType strm xx.SecurityResponseType
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.ExpirationCycle |> Option.iter (WriteExpirationCycle strm)
    xx.RoundLot |> Option.iter (WriteRoundLot strm)
    xx.MinTradeVol |> Option.iter (WriteMinTradeVol strm)


// tag: v
let WriteSecurityTypeRequest (xx:SecurityTypeRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteSecurityReqID strm xx.SecurityReqID
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.Product |> Option.iter (WriteProduct strm)
    xx.SecurityType |> Option.iter (WriteSecurityType strm)
    xx.SecuritySubType |> Option.iter (WriteSecuritySubType strm)


// tag: w
let WriteSecurityTypes (xx:SecurityTypes) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteSecurityReqID strm xx.SecurityReqID
    WriteSecurityResponseID strm xx.SecurityResponseID
    WriteSecurityResponseType strm xx.SecurityResponseType
    xx.TotNoSecurityTypes |> Option.iter (WriteTotNoSecurityTypes strm)
    xx.LastFragment |> Option.iter (WriteLastFragment strm)
    xx.NoSecurityTypesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoSecurityTypes strm (Fix44.Fields.NoSecurityTypes numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoSecurityTypesGrp strm gg)    ) // end Option.iter
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)


// tag: x
let WriteSecurityListRequest (xx:SecurityListRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteSecurityReqID strm xx.SecurityReqID
    WriteSecurityListRequestType strm xx.SecurityListRequestType
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)


// tag: y
let WriteSecurityList (xx:SecurityList) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteSecurityReqID strm xx.SecurityReqID
    WriteSecurityResponseID strm xx.SecurityResponseID
    WriteSecurityRequestResult strm xx.SecurityRequestResult
    xx.TotNoRelatedSym |> Option.iter (WriteTotNoRelatedSym strm)
    xx.LastFragment |> Option.iter (WriteLastFragment strm)
    xx.SecurityList_NoRelatedSymGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteSecurityList_NoRelatedSymGrp strm gg)    ) // end Option.iter


// tag: z
let WriteDerivativeSecurityListRequest (xx:DerivativeSecurityListRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteSecurityReqID strm xx.SecurityReqID
    WriteSecurityListRequestType strm xx.SecurityListRequestType
    xx.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    xx.SecuritySubType |> Option.iter (WriteSecuritySubType strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)


// tag: AA
let WriteDerivativeSecurityList (xx:DerivativeSecurityList) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteSecurityReqID strm xx.SecurityReqID
    WriteSecurityResponseID strm xx.SecurityResponseID
    WriteSecurityRequestResult strm xx.SecurityRequestResult
    xx.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    xx.TotNoRelatedSym |> Option.iter (WriteTotNoRelatedSym strm)
    xx.LastFragment |> Option.iter (WriteLastFragment strm)
    xx.DerivativeSecurityList_NoRelatedSymGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteDerivativeSecurityList_NoRelatedSymGrp strm gg)    ) // end Option.iter


// tag: e
let WriteSecurityStatusRequest (xx:SecurityStatusRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteSecurityStatusReqID strm xx.SecurityStatusReqID
    WriteInstrument strm xx.Instrument    // component
    xx.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.Currency |> Option.iter (WriteCurrency strm)
    WriteSubscriptionRequestType strm xx.SubscriptionRequestType
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)


// tag: f
let WriteSecurityStatus (xx:SecurityStatus) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.SecurityStatusReqID |> Option.iter (WriteSecurityStatusReqID strm)
    WriteInstrument strm xx.Instrument    // component
    xx.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.UnsolicitedIndicator |> Option.iter (WriteUnsolicitedIndicator strm)
    xx.SecurityTradingStatus |> Option.iter (WriteSecurityTradingStatus strm)
    xx.FinancialStatus |> Option.iter (WriteFinancialStatus strm)
    xx.CorporateAction |> Option.iter (WriteCorporateAction strm)
    xx.HaltReason |> Option.iter (WriteHaltReason strm)
    xx.InViewOfCommon |> Option.iter (WriteInViewOfCommon strm)
    xx.DueToRelated |> Option.iter (WriteDueToRelated strm)
    xx.BuyVolume |> Option.iter (WriteBuyVolume strm)
    xx.SellVolume |> Option.iter (WriteSellVolume strm)
    xx.HighPx |> Option.iter (WriteHighPx strm)
    xx.LowPx |> Option.iter (WriteLowPx strm)
    xx.LastPx |> Option.iter (WriteLastPx strm)
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    xx.Adjustment |> Option.iter (WriteAdjustment strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: g
let WriteTradingSessionStatusRequest (xx:TradingSessionStatusRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteTradSesReqID strm xx.TradSesReqID
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.TradSesMethod |> Option.iter (WriteTradSesMethod strm)
    xx.TradSesMode |> Option.iter (WriteTradSesMode strm)
    WriteSubscriptionRequestType strm xx.SubscriptionRequestType


// tag: h
let WriteTradingSessionStatus (xx:TradingSessionStatus) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.TradSesReqID |> Option.iter (WriteTradSesReqID strm)
    WriteTradingSessionID strm xx.TradingSessionID
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.TradSesMethod |> Option.iter (WriteTradSesMethod strm)
    xx.TradSesMode |> Option.iter (WriteTradSesMode strm)
    xx.UnsolicitedIndicator |> Option.iter (WriteUnsolicitedIndicator strm)
    WriteTradSesStatus strm xx.TradSesStatus
    xx.TradSesStatusRejReason |> Option.iter (WriteTradSesStatusRejReason strm)
    xx.TradSesStartTime |> Option.iter (WriteTradSesStartTime strm)
    xx.TradSesOpenTime |> Option.iter (WriteTradSesOpenTime strm)
    xx.TradSesPreCloseTime |> Option.iter (WriteTradSesPreCloseTime strm)
    xx.TradSesCloseTime |> Option.iter (WriteTradSesCloseTime strm)
    xx.TradSesEndTime |> Option.iter (WriteTradSesEndTime strm)
    xx.TotalVolumeTraded |> Option.iter (WriteTotalVolumeTraded strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: D
let WriteNewOrderSingle (xx:NewOrderSingle) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
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
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    WriteSide strm xx.Side
    xx.LocateReqd |> Option.iter (WriteLocateReqd strm)
    WriteTransactTime strm xx.TransactTime
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm xx.OrderQtyData    // component
    WriteOrdType strm xx.OrdType
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
    xx.CancellationRights |> Option.iter (WriteCancellationRights strm)
    xx.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    xx.RegistID |> Option.iter (WriteRegistID strm)
    xx.Designation |> Option.iter (WriteDesignation strm)


// tag: 8
let WriteExecutionReport (xx:ExecutionReport) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteOrderID strm xx.OrderID
    xx.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.SecondaryExecID |> Option.iter (WriteSecondaryExecID strm)
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.OrigClOrdID |> Option.iter (WriteOrigClOrdID strm)
    xx.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    xx.QuoteRespID |> Option.iter (WriteQuoteRespID strm)
    xx.OrdStatusReqID |> Option.iter (WriteOrdStatusReqID strm)
    xx.MassStatusReqID |> Option.iter (WriteMassStatusReqID strm)
    xx.TotNumReports |> Option.iter (WriteTotNumReports strm)
    xx.LastRptRequested |> Option.iter (WriteLastRptRequested strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    xx.NoContraBrokersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoContraBrokers strm (Fix44.Fields.NoContraBrokers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoContraBrokersGrp strm gg)    ) // end Option.iter
    xx.ListID |> Option.iter (WriteListID strm)
    xx.CrossID |> Option.iter (WriteCrossID strm)
    xx.OrigCrossID |> Option.iter (WriteOrigCrossID strm)
    xx.CrossType |> Option.iter (WriteCrossType strm)
    WriteExecID strm xx.ExecID
    xx.ExecRefID |> Option.iter (WriteExecRefID strm)
    WriteExecType strm xx.ExecType
    WriteOrdStatus strm xx.OrdStatus
    xx.WorkingIndicator |> Option.iter (WriteWorkingIndicator strm)
    xx.OrdRejReason |> Option.iter (WriteOrdRejReason strm)
    xx.ExecRestatementReason |> Option.iter (WriteExecRestatementReason strm)
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.DayBookingInst |> Option.iter (WriteDayBookingInst strm)
    xx.BookingUnit |> Option.iter (WriteBookingUnit strm)
    xx.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    xx.SettlType |> Option.iter (WriteSettlType strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.CashMargin |> Option.iter (WriteCashMargin strm)
    xx.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    WriteInstrument strm xx.Instrument    // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteSide strm xx.Side
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.OrderQtyData |> Option.iter (WriteOrderQtyData strm) // component
    xx.OrdType |> Option.iter (WriteOrdType strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.StopPx |> Option.iter (WriteStopPx strm)
    xx.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    xx.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    xx.PeggedPrice |> Option.iter (WritePeggedPrice strm)
    xx.DiscretionPrice |> Option.iter (WriteDiscretionPrice strm)
    xx.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    xx.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    xx.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    xx.TargetStrategyPerformance |> Option.iter (WriteTargetStrategyPerformance strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.ComplianceID |> Option.iter (WriteComplianceID strm)
    xx.SolicitedFlag |> Option.iter (WriteSolicitedFlag strm)
    xx.TimeInForce |> Option.iter (WriteTimeInForce strm)
    xx.EffectiveTime |> Option.iter (WriteEffectiveTime strm)
    xx.ExpireDate |> Option.iter (WriteExpireDate strm)
    xx.ExpireTime |> Option.iter (WriteExpireTime strm)
    xx.ExecInst |> Option.iter (WriteExecInst strm)
    xx.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    xx.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    xx.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    xx.LastQty |> Option.iter (WriteLastQty strm)
    xx.UnderlyingLastQty |> Option.iter (WriteUnderlyingLastQty strm)
    xx.LastPx |> Option.iter (WriteLastPx strm)
    xx.UnderlyingLastPx |> Option.iter (WriteUnderlyingLastPx strm)
    xx.LastParPx |> Option.iter (WriteLastParPx strm)
    xx.LastSpotRate |> Option.iter (WriteLastSpotRate strm)
    xx.LastForwardPoints |> Option.iter (WriteLastForwardPoints strm)
    xx.LastMkt |> Option.iter (WriteLastMkt strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.TimeBracket |> Option.iter (WriteTimeBracket strm)
    xx.LastCapacity |> Option.iter (WriteLastCapacity strm)
    WriteLeavesQty strm xx.LeavesQty
    WriteCumQty strm xx.CumQty
    WriteAvgPx strm xx.AvgPx
    xx.DayOrderQty |> Option.iter (WriteDayOrderQty strm)
    xx.DayCumQty |> Option.iter (WriteDayCumQty strm)
    xx.DayAvgPx |> Option.iter (WriteDayAvgPx strm)
    xx.GTBookingInst |> Option.iter (WriteGTBookingInst strm)
    xx.TradeDate |> Option.iter (WriteTradeDate strm)
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    xx.ReportToExch |> Option.iter (WriteReportToExch strm)
    xx.CommissionData |> Option.iter (WriteCommissionData strm) // component
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    xx.GrossTradeAmt |> Option.iter (WriteGrossTradeAmt strm)
    xx.NumDaysInterest |> Option.iter (WriteNumDaysInterest strm)
    xx.ExDate |> Option.iter (WriteExDate strm)
    xx.AccruedInterestRate |> Option.iter (WriteAccruedInterestRate strm)
    xx.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    xx.InterestAtMaturity |> Option.iter (WriteInterestAtMaturity strm)
    xx.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    xx.StartCash |> Option.iter (WriteStartCash strm)
    xx.EndCash |> Option.iter (WriteEndCash strm)
    xx.TradedFlatSwitch |> Option.iter (WriteTradedFlatSwitch strm)
    xx.BasisFeatureDate |> Option.iter (WriteBasisFeatureDate strm)
    xx.BasisFeaturePrice |> Option.iter (WriteBasisFeaturePrice strm)
    xx.Concession |> Option.iter (WriteConcession strm)
    xx.TotalTakedown |> Option.iter (WriteTotalTakedown strm)
    xx.NetMoney |> Option.iter (WriteNetMoney strm)
    xx.SettlCurrAmt |> Option.iter (WriteSettlCurrAmt strm)
    xx.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    xx.SettlCurrFxRate |> Option.iter (WriteSettlCurrFxRate strm)
    xx.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    xx.HandlInst |> Option.iter (WriteHandlInst strm)
    xx.MinQty |> Option.iter (WriteMinQty strm)
    xx.MaxFloor |> Option.iter (WriteMaxFloor strm)
    xx.PositionEffect |> Option.iter (WritePositionEffect strm)
    xx.MaxShow |> Option.iter (WriteMaxShow strm)
    xx.BookingType |> Option.iter (WriteBookingType strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    xx.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    xx.LastForwardPoints2 |> Option.iter (WriteLastForwardPoints2 strm)
    xx.MultiLegReportingType |> Option.iter (WriteMultiLegReportingType strm)
    xx.CancellationRights |> Option.iter (WriteCancellationRights strm)
    xx.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    xx.RegistID |> Option.iter (WriteRegistID strm)
    xx.Designation |> Option.iter (WriteDesignation strm)
    xx.TransBkdTime |> Option.iter (WriteTransBkdTime strm)
    xx.ExecValuationPoint |> Option.iter (WriteExecValuationPoint strm)
    xx.ExecPriceType |> Option.iter (WriteExecPriceType strm)
    xx.ExecPriceAdjustment |> Option.iter (WriteExecPriceAdjustment strm)
    xx.PriorityIndicator |> Option.iter (WritePriorityIndicator strm)
    xx.PriceImprovement |> Option.iter (WritePriceImprovement strm)
    xx.LastLiquidityInd |> Option.iter (WriteLastLiquidityInd strm)
    xx.NoContAmtsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoContAmts strm (Fix44.Fields.NoContAmts numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoContAmtsGrp strm gg)    ) // end Option.iter
    xx.ExecutionReport_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteExecutionReport_NoLegsGrp strm gg)    ) // end Option.iter
    xx.CopyMsgIndicator |> Option.iter (WriteCopyMsgIndicator strm)
    xx.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter


// tag: Q
let WriteDontKnowTrade (xx:DontKnowTrade) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteOrderID strm xx.OrderID
    xx.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    WriteExecID strm xx.ExecID
    WriteDKReason strm xx.DKReason
    WriteInstrument strm xx.Instrument    // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    WriteSide strm xx.Side
    WriteOrderQtyData strm xx.OrderQtyData    // component
    xx.LastQty |> Option.iter (WriteLastQty strm)
    xx.LastPx |> Option.iter (WriteLastPx strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: G
let WriteOrderCancelReplaceRequest (xx:OrderCancelReplaceRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.OrderID |> Option.iter (WriteOrderID strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    xx.TradeDate |> Option.iter (WriteTradeDate strm)
    WriteOrigClOrdID strm xx.OrigClOrdID
    WriteClOrdID strm xx.ClOrdID
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    xx.ListID |> Option.iter (WriteListID strm)
    xx.OrigOrdModTime |> Option.iter (WriteOrigOrdModTime strm)
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
    WriteInstrument strm xx.Instrument    // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteSide strm xx.Side
    WriteTransactTime strm xx.TransactTime
    xx.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm xx.OrderQtyData    // component
    WriteOrdType strm xx.OrdType
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.StopPx |> Option.iter (WriteStopPx strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    xx.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    xx.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    xx.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    xx.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    xx.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    xx.ComplianceID |> Option.iter (WriteComplianceID strm)
    xx.SolicitedFlag |> Option.iter (WriteSolicitedFlag strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
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
    xx.LocateReqd |> Option.iter (WriteLocateReqd strm)
    xx.CancellationRights |> Option.iter (WriteCancellationRights strm)
    xx.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    xx.RegistID |> Option.iter (WriteRegistID strm)
    xx.Designation |> Option.iter (WriteDesignation strm)


// tag: F
let WriteOrderCancelRequest (xx:OrderCancelRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteOrigClOrdID strm xx.OrigClOrdID
    xx.OrderID |> Option.iter (WriteOrderID strm)
    WriteClOrdID strm xx.ClOrdID
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    xx.ListID |> Option.iter (WriteListID strm)
    xx.OrigOrdModTime |> Option.iter (WriteOrigOrdModTime strm)
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    WriteInstrument strm xx.Instrument    // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteSide strm xx.Side
    WriteTransactTime strm xx.TransactTime
    WriteOrderQtyData strm xx.OrderQtyData    // component
    xx.ComplianceID |> Option.iter (WriteComplianceID strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: 9
let WriteOrderCancelReject (xx:OrderCancelReject) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteOrderID strm xx.OrderID
    xx.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    WriteClOrdID strm xx.ClOrdID
    xx.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    WriteOrigClOrdID strm xx.OrigClOrdID
    WriteOrdStatus strm xx.OrdStatus
    xx.WorkingIndicator |> Option.iter (WriteWorkingIndicator strm)
    xx.OrigOrdModTime |> Option.iter (WriteOrigOrdModTime strm)
    xx.ListID |> Option.iter (WriteListID strm)
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    xx.TradeDate |> Option.iter (WriteTradeDate strm)
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    WriteCxlRejResponseTo strm xx.CxlRejResponseTo
    xx.CxlRejReason |> Option.iter (WriteCxlRejReason strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: H
let WriteOrderStatusRequest (xx:OrderStatusRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.OrderID |> Option.iter (WriteOrderID strm)
    WriteClOrdID strm xx.ClOrdID
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.OrdStatusReqID |> Option.iter (WriteOrdStatusReqID strm)
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteInstrument strm xx.Instrument    // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteSide strm xx.Side


// tag: q
let WriteOrderMassCancelRequest (xx:OrderMassCancelRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteClOrdID strm xx.ClOrdID
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    WriteMassCancelRequestType strm xx.MassCancelRequestType
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    xx.Side |> Option.iter (WriteSide strm)
    WriteTransactTime strm xx.TransactTime
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: r
let WriteOrderMassCancelReport (xx:OrderMassCancelReport) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    WriteOrderID strm xx.OrderID
    xx.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    WriteMassCancelRequestType strm xx.MassCancelRequestType
    WriteMassCancelResponse strm xx.MassCancelResponse
    xx.MassCancelRejectReason |> Option.iter (WriteMassCancelRejectReason strm)
    xx.TotalAffectedOrders |> Option.iter (WriteTotalAffectedOrders strm)
    xx.NoAffectedOrdersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAffectedOrders strm (Fix44.Fields.NoAffectedOrders numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoAffectedOrdersGrp strm gg)    ) // end Option.iter
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    xx.Side |> Option.iter (WriteSide strm)
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: AF
let WriteOrderMassStatusRequest (xx:OrderMassStatusRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteMassStatusReqID strm xx.MassStatusReqID
    WriteMassStatusReqType strm xx.MassStatusReqType
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    xx.Side |> Option.iter (WriteSide strm)


// tag: s
let WriteNewOrderCross (xx:NewOrderCross) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteCrossID strm xx.CrossID
    WriteCrossType strm xx.CrossType
    WriteCrossPrioritization strm xx.CrossPrioritization
    let noSidesField =  // ####
        match xx.NoSidesGrp with
        | OneOrTwo.One _ -> NoSides.OneSide
        | OneOrTwo.Two _ -> NoSides.BothSides
    WriteNoSides strm noSidesField
    xx.NoSidesGrp |> OneOrTwo.iter (WriteNoSidesGrp strm)   // group
    WriteInstrument strm xx.Instrument    // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.SettlType |> Option.iter (WriteSettlType strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
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
    xx.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    xx.LocateReqd |> Option.iter (WriteLocateReqd strm)
    WriteTransactTime strm xx.TransactTime
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    WriteOrdType strm xx.OrdType
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.StopPx |> Option.iter (WriteStopPx strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.ComplianceID |> Option.iter (WriteComplianceID strm)
    xx.IOIid |> Option.iter (WriteIOIid strm)
    xx.QuoteID |> Option.iter (WriteQuoteID strm)
    xx.TimeInForce |> Option.iter (WriteTimeInForce strm)
    xx.EffectiveTime |> Option.iter (WriteEffectiveTime strm)
    xx.ExpireDate |> Option.iter (WriteExpireDate strm)
    xx.ExpireTime |> Option.iter (WriteExpireTime strm)
    xx.GTBookingInst |> Option.iter (WriteGTBookingInst strm)
    xx.MaxShow |> Option.iter (WriteMaxShow strm)
    xx.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    xx.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    xx.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    xx.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    xx.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    xx.CancellationRights |> Option.iter (WriteCancellationRights strm)
    xx.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    xx.RegistID |> Option.iter (WriteRegistID strm)
    xx.Designation |> Option.iter (WriteDesignation strm)


// tag: t
let WriteCrossOrderCancelReplaceRequest (xx:CrossOrderCancelReplaceRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.OrderID |> Option.iter (WriteOrderID strm)
    WriteCrossID strm xx.CrossID
    WriteOrigCrossID strm xx.OrigCrossID
    WriteCrossType strm xx.CrossType
    WriteCrossPrioritization strm xx.CrossPrioritization
    let noSidesField =  // ####
        match xx.CrossOrderCancelReplaceRequest_NoSidesGrp with
        | OneOrTwo.One _ -> NoSides.OneSide
        | OneOrTwo.Two _ -> NoSides.BothSides
    WriteNoSides strm noSidesField
    xx.CrossOrderCancelReplaceRequest_NoSidesGrp |> OneOrTwo.iter (WriteCrossOrderCancelReplaceRequest_NoSidesGrp strm)   // group
    WriteInstrument strm xx.Instrument    // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.SettlType |> Option.iter (WriteSettlType strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
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
    xx.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    xx.LocateReqd |> Option.iter (WriteLocateReqd strm)
    WriteTransactTime strm xx.TransactTime
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    WriteOrdType strm xx.OrdType
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.StopPx |> Option.iter (WriteStopPx strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.ComplianceID |> Option.iter (WriteComplianceID strm)
    xx.IOIid |> Option.iter (WriteIOIid strm)
    xx.QuoteID |> Option.iter (WriteQuoteID strm)
    xx.TimeInForce |> Option.iter (WriteTimeInForce strm)
    xx.EffectiveTime |> Option.iter (WriteEffectiveTime strm)
    xx.ExpireDate |> Option.iter (WriteExpireDate strm)
    xx.ExpireTime |> Option.iter (WriteExpireTime strm)
    xx.GTBookingInst |> Option.iter (WriteGTBookingInst strm)
    xx.MaxShow |> Option.iter (WriteMaxShow strm)
    xx.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    xx.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    xx.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    xx.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    xx.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    xx.CancellationRights |> Option.iter (WriteCancellationRights strm)
    xx.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    xx.RegistID |> Option.iter (WriteRegistID strm)
    xx.Designation |> Option.iter (WriteDesignation strm)


// tag: u
let WriteCrossOrderCancelRequest (xx:CrossOrderCancelRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.OrderID |> Option.iter (WriteOrderID strm)
    WriteCrossID strm xx.CrossID
    WriteOrigCrossID strm xx.OrigCrossID
    WriteCrossType strm xx.CrossType
    WriteCrossPrioritization strm xx.CrossPrioritization
    let noSidesField =  // ####
        match xx.CrossOrderCancelRequest_NoSidesGrp with
        | OneOrTwo.One _ -> NoSides.OneSide
        | OneOrTwo.Two _ -> NoSides.BothSides
    WriteNoSides strm noSidesField
    xx.CrossOrderCancelRequest_NoSidesGrp |> OneOrTwo.iter (WriteCrossOrderCancelRequest_NoSidesGrp strm)   // group
    WriteInstrument strm xx.Instrument    // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    WriteTransactTime strm xx.TransactTime


// tag: AB
let WriteNewOrderMultileg (xx:NewOrderMultileg) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
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
    xx.NewOrderMultileg_NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNewOrderMultileg_NoAllocsGrp strm gg)    ) // end Option.iter
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
    WriteSide strm xx.Side
    WriteInstrument strm xx.Instrument    // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    let numGrps = xx.NewOrderMultileg_NoLegsGrp.Length
    WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
    xx.NewOrderMultileg_NoLegsGrp |> List.iter (fun gg -> WriteNewOrderMultileg_NoLegsGrp strm gg)
    xx.LocateReqd |> Option.iter (WriteLocateReqd strm)
    WriteTransactTime strm xx.TransactTime
    xx.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm xx.OrderQtyData    // component
    WriteOrdType strm xx.OrdType
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.StopPx |> Option.iter (WriteStopPx strm)
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
    xx.PositionEffect |> Option.iter (WritePositionEffect strm)
    xx.CoveredOrUncovered |> Option.iter (WriteCoveredOrUncovered strm)
    xx.MaxShow |> Option.iter (WriteMaxShow strm)
    xx.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    xx.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    xx.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    xx.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    xx.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    xx.CancellationRights |> Option.iter (WriteCancellationRights strm)
    xx.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    xx.RegistID |> Option.iter (WriteRegistID strm)
    xx.Designation |> Option.iter (WriteDesignation strm)
    xx.MultiLegRptTypeReq |> Option.iter (WriteMultiLegRptTypeReq strm)


// tag: AC
let WriteMultilegOrderCancelReplaceRequest (xx:MultilegOrderCancelReplaceRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.OrderID |> Option.iter (WriteOrderID strm)
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
    xx.MultilegOrderCancelReplaceRequest_NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteMultilegOrderCancelReplaceRequest_NoAllocsGrp strm gg)    ) // end Option.iter
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
    WriteSide strm xx.Side
    WriteInstrument strm xx.Instrument    // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    let numGrps = xx.MultilegOrderCancelReplaceRequest_NoLegsGrp.Length
    WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
    xx.MultilegOrderCancelReplaceRequest_NoLegsGrp |> List.iter (fun gg -> WriteMultilegOrderCancelReplaceRequest_NoLegsGrp strm gg)
    xx.LocateReqd |> Option.iter (WriteLocateReqd strm)
    WriteTransactTime strm xx.TransactTime
    xx.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm xx.OrderQtyData    // component
    WriteOrdType strm xx.OrdType
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.StopPx |> Option.iter (WriteStopPx strm)
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
    xx.PositionEffect |> Option.iter (WritePositionEffect strm)
    xx.CoveredOrUncovered |> Option.iter (WriteCoveredOrUncovered strm)
    xx.MaxShow |> Option.iter (WriteMaxShow strm)
    xx.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    xx.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    xx.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    xx.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    xx.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    xx.CancellationRights |> Option.iter (WriteCancellationRights strm)
    xx.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    xx.RegistID |> Option.iter (WriteRegistID strm)
    xx.Designation |> Option.iter (WriteDesignation strm)
    xx.MultiLegRptTypeReq |> Option.iter (WriteMultiLegRptTypeReq strm)


// tag: k
let WriteBidRequest (xx:BidRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.BidID |> Option.iter (WriteBidID strm)
    WriteClientBidID strm xx.ClientBidID
    WriteBidRequestTransType strm xx.BidRequestTransType
    xx.ListName |> Option.iter (WriteListName strm)
    WriteTotNoRelatedSym strm xx.TotNoRelatedSym
    WriteBidType strm xx.BidType
    xx.NumTickets |> Option.iter (WriteNumTickets strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.SideValue1 |> Option.iter (WriteSideValue1 strm)
    xx.SideValue2 |> Option.iter (WriteSideValue2 strm)
    xx.NoBidDescriptorsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoBidDescriptors strm (Fix44.Fields.NoBidDescriptors numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoBidDescriptorsGrp strm gg)    ) // end Option.iter
    xx.NoBidComponentsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoBidComponents strm (Fix44.Fields.NoBidComponents numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoBidComponentsGrp strm gg)    ) // end Option.iter
    xx.LiquidityIndType |> Option.iter (WriteLiquidityIndType strm)
    xx.WtAverageLiquidity |> Option.iter (WriteWtAverageLiquidity strm)
    xx.ExchangeForPhysical |> Option.iter (WriteExchangeForPhysical strm)
    xx.OutMainCntryUIndex |> Option.iter (WriteOutMainCntryUIndex strm)
    xx.CrossPercent |> Option.iter (WriteCrossPercent strm)
    xx.ProgRptReqs |> Option.iter (WriteProgRptReqs strm)
    xx.ProgPeriodInterval |> Option.iter (WriteProgPeriodInterval strm)
    xx.IncTaxInd |> Option.iter (WriteIncTaxInd strm)
    xx.ForexReq |> Option.iter (WriteForexReq strm)
    xx.NumBidders |> Option.iter (WriteNumBidders strm)
    xx.TradeDate |> Option.iter (WriteTradeDate strm)
    WriteBidTradeType strm xx.BidTradeType
    WriteBasisPxType strm xx.BasisPxType
    xx.StrikeTime |> Option.iter (WriteStrikeTime strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: l
let WriteBidResponse (xx:BidResponse) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.BidID |> Option.iter (WriteBidID strm)
    xx.ClientBidID |> Option.iter (WriteClientBidID strm)
    let numGrps = xx.BidResponse_NoBidComponentsGrp.Length
    WriteNoBidComponents strm (Fix44.Fields.NoBidComponents numGrps) // write the 'num group repeats' field
    xx.BidResponse_NoBidComponentsGrp |> List.iter (fun gg -> WriteBidResponse_NoBidComponentsGrp strm gg)


// tag: E
let WriteNewOrderList (xx:NewOrderList) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteListID strm xx.ListID
    xx.BidID |> Option.iter (WriteBidID strm)
    xx.ClientBidID |> Option.iter (WriteClientBidID strm)
    xx.ProgRptReqs |> Option.iter (WriteProgRptReqs strm)
    WriteBidType strm xx.BidType
    xx.ProgPeriodInterval |> Option.iter (WriteProgPeriodInterval strm)
    xx.CancellationRights |> Option.iter (WriteCancellationRights strm)
    xx.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    xx.RegistID |> Option.iter (WriteRegistID strm)
    xx.ListExecInstType |> Option.iter (WriteListExecInstType strm)
    xx.ListExecInst |> Option.iter (WriteListExecInst strm)
    xx.EncodedListExecInst |> Option.iter (WriteEncodedListExecInst strm)
    xx.AllowableOneSidednessPct |> Option.iter (WriteAllowableOneSidednessPct strm)
    xx.AllowableOneSidednessValue |> Option.iter (WriteAllowableOneSidednessValue strm)
    xx.AllowableOneSidednessCurr |> Option.iter (WriteAllowableOneSidednessCurr strm)
    WriteTotNoOrders strm xx.TotNoOrders
    xx.LastFragment |> Option.iter (WriteLastFragment strm)
    let numGrps = xx.NewOrderList_NoOrdersGrp.Length
    WriteNoOrders strm (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
    xx.NewOrderList_NoOrdersGrp |> List.iter (fun gg -> WriteNewOrderList_NoOrdersGrp strm gg)


// tag: m
let WriteListStrikePrice (xx:ListStrikePrice) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteListID strm xx.ListID
    WriteTotNoStrikes strm xx.TotNoStrikes
    xx.LastFragment |> Option.iter (WriteLastFragment strm)
    let numGrps = xx.NoStrikesGrp.Length
    WriteNoStrikes strm (Fix44.Fields.NoStrikes numGrps) // write the 'num group repeats' field
    xx.NoStrikesGrp |> List.iter (fun gg -> WriteNoStrikesGrp strm gg)
    xx.ListStrikePrice_NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteListStrikePrice_NoUnderlyingsGrp strm gg)    ) // end Option.iter


// tag: N
let WriteListStatus (xx:ListStatus) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteListID strm xx.ListID
    WriteListStatusType strm xx.ListStatusType
    WriteNoRpts strm xx.NoRpts
    WriteListOrderStatus strm xx.ListOrderStatus
    WriteRptSeq strm xx.RptSeq
    xx.ListStatusText |> Option.iter (WriteListStatusText strm)
    xx.EncodedListStatusText |> Option.iter (WriteEncodedListStatusText strm)
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    WriteTotNoOrders strm xx.TotNoOrders
    xx.LastFragment |> Option.iter (WriteLastFragment strm)
    let numGrps = xx.ListStatus_NoOrdersGrp.Length
    WriteNoOrders strm (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
    xx.ListStatus_NoOrdersGrp |> List.iter (fun gg -> WriteListStatus_NoOrdersGrp strm gg)


// tag: L
let WriteListExecute (xx:ListExecute) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteListID strm xx.ListID
    xx.ClientBidID |> Option.iter (WriteClientBidID strm)
    xx.BidID |> Option.iter (WriteBidID strm)
    WriteTransactTime strm xx.TransactTime
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: K
let WriteListCancelRequest (xx:ListCancelRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteListID strm xx.ListID
    WriteTransactTime strm xx.TransactTime
    xx.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    xx.TradeDate |> Option.iter (WriteTradeDate strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: M
let WriteListStatusRequest (xx:ListStatusRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteListID strm xx.ListID
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: J
let WriteAllocationInstruction (xx:AllocationInstruction) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteAllocID strm xx.AllocID
    WriteAllocTransType strm xx.AllocTransType
    WriteAllocType strm xx.AllocType
    xx.SecondaryAllocID |> Option.iter (WriteSecondaryAllocID strm)
    xx.RefAllocID |> Option.iter (WriteRefAllocID strm)
    xx.AllocCancReplaceReason |> Option.iter (WriteAllocCancReplaceReason strm)
    xx.AllocIntermedReqType |> Option.iter (WriteAllocIntermedReqType strm)
    xx.AllocLinkID |> Option.iter (WriteAllocLinkID strm)
    xx.AllocLinkType |> Option.iter (WriteAllocLinkType strm)
    xx.BookingRefID |> Option.iter (WriteBookingRefID strm)
    WriteAllocNoOrdersType strm xx.AllocNoOrdersType
    xx.NoOrdersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoOrders strm (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoOrdersGrp strm gg)    ) // end Option.iter
    xx.AllocationInstruction_NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteAllocationInstruction_NoExecsGrp strm gg)    ) // end Option.iter
    xx.PreviouslyReported |> Option.iter (WritePreviouslyReported strm)
    xx.ReversalIndicator |> Option.iter (WriteReversalIndicator strm)
    xx.MatchType |> Option.iter (WriteMatchType strm)
    WriteSide strm xx.Side
    WriteInstrument strm xx.Instrument    // component
    xx.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    WriteQuantity strm xx.Quantity
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.LastMkt |> Option.iter (WriteLastMkt strm)
    xx.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    WriteAvgPx strm xx.AvgPx
    xx.AvgParPx |> Option.iter (WriteAvgParPx strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.AvgPxPrecision |> Option.iter (WriteAvgPxPrecision strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    WriteTradeDate strm xx.TradeDate
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    xx.SettlType |> Option.iter (WriteSettlType strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.BookingType |> Option.iter (WriteBookingType strm)
    xx.GrossTradeAmt |> Option.iter (WriteGrossTradeAmt strm)
    xx.Concession |> Option.iter (WriteConcession strm)
    xx.TotalTakedown |> Option.iter (WriteTotalTakedown strm)
    xx.NetMoney |> Option.iter (WriteNetMoney strm)
    xx.PositionEffect |> Option.iter (WritePositionEffect strm)
    xx.AutoAcceptIndicator |> Option.iter (WriteAutoAcceptIndicator strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.NumDaysInterest |> Option.iter (WriteNumDaysInterest strm)
    xx.AccruedInterestRate |> Option.iter (WriteAccruedInterestRate strm)
    xx.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    xx.TotalAccruedInterestAmt |> Option.iter (WriteTotalAccruedInterestAmt strm)
    xx.InterestAtMaturity |> Option.iter (WriteInterestAtMaturity strm)
    xx.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    xx.StartCash |> Option.iter (WriteStartCash strm)
    xx.EndCash |> Option.iter (WriteEndCash strm)
    xx.LegalConfirm |> Option.iter (WriteLegalConfirm strm)
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    xx.TotNoAllocs |> Option.iter (WriteTotNoAllocs strm)
    xx.LastFragment |> Option.iter (WriteLastFragment strm)
    xx.AllocationInstruction_NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteAllocationInstruction_NoAllocsGrp strm gg)    ) // end Option.iter


// tag: P
let WriteAllocationInstructionAck (xx:AllocationInstructionAck) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteAllocID strm xx.AllocID
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.SecondaryAllocID |> Option.iter (WriteSecondaryAllocID strm)
    xx.TradeDate |> Option.iter (WriteTradeDate strm)
    WriteTransactTime strm xx.TransactTime
    WriteAllocStatus strm xx.AllocStatus
    xx.AllocRejCode |> Option.iter (WriteAllocRejCode strm)
    xx.AllocType |> Option.iter (WriteAllocType strm)
    xx.AllocIntermedReqType |> Option.iter (WriteAllocIntermedReqType strm)
    xx.MatchStatus |> Option.iter (WriteMatchStatus strm)
    xx.Product |> Option.iter (WriteProduct strm)
    xx.SecurityType |> Option.iter (WriteSecurityType strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.AllocationInstructionAck_NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteAllocationInstructionAck_NoAllocsGrp strm gg)    ) // end Option.iter


// tag: AS
let WriteAllocationReport (xx:AllocationReport) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteAllocReportID strm xx.AllocReportID
    xx.AllocID |> Option.iter (WriteAllocID strm)
    WriteAllocTransType strm xx.AllocTransType
    xx.AllocReportRefID |> Option.iter (WriteAllocReportRefID strm)
    xx.AllocCancReplaceReason |> Option.iter (WriteAllocCancReplaceReason strm)
    xx.SecondaryAllocID |> Option.iter (WriteSecondaryAllocID strm)
    WriteAllocReportType strm xx.AllocReportType
    WriteAllocStatus strm xx.AllocStatus
    xx.AllocRejCode |> Option.iter (WriteAllocRejCode strm)
    xx.RefAllocID |> Option.iter (WriteRefAllocID strm)
    xx.AllocIntermedReqType |> Option.iter (WriteAllocIntermedReqType strm)
    xx.AllocLinkID |> Option.iter (WriteAllocLinkID strm)
    xx.AllocLinkType |> Option.iter (WriteAllocLinkType strm)
    xx.BookingRefID |> Option.iter (WriteBookingRefID strm)
    WriteAllocNoOrdersType strm xx.AllocNoOrdersType
    xx.NoOrdersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoOrders strm (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoOrdersGrp strm gg)    ) // end Option.iter
    xx.AllocationReport_NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteAllocationReport_NoExecsGrp strm gg)    ) // end Option.iter
    xx.PreviouslyReported |> Option.iter (WritePreviouslyReported strm)
    xx.ReversalIndicator |> Option.iter (WriteReversalIndicator strm)
    xx.MatchType |> Option.iter (WriteMatchType strm)
    WriteSide strm xx.Side
    WriteInstrument strm xx.Instrument    // component
    xx.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    WriteQuantity strm xx.Quantity
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.LastMkt |> Option.iter (WriteLastMkt strm)
    xx.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    WriteAvgPx strm xx.AvgPx
    xx.AvgParPx |> Option.iter (WriteAvgParPx strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.AvgPxPrecision |> Option.iter (WriteAvgPxPrecision strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    WriteTradeDate strm xx.TradeDate
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    xx.SettlType |> Option.iter (WriteSettlType strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.BookingType |> Option.iter (WriteBookingType strm)
    xx.GrossTradeAmt |> Option.iter (WriteGrossTradeAmt strm)
    xx.Concession |> Option.iter (WriteConcession strm)
    xx.TotalTakedown |> Option.iter (WriteTotalTakedown strm)
    xx.NetMoney |> Option.iter (WriteNetMoney strm)
    xx.PositionEffect |> Option.iter (WritePositionEffect strm)
    xx.AutoAcceptIndicator |> Option.iter (WriteAutoAcceptIndicator strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.NumDaysInterest |> Option.iter (WriteNumDaysInterest strm)
    xx.AccruedInterestRate |> Option.iter (WriteAccruedInterestRate strm)
    xx.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    xx.TotalAccruedInterestAmt |> Option.iter (WriteTotalAccruedInterestAmt strm)
    xx.InterestAtMaturity |> Option.iter (WriteInterestAtMaturity strm)
    xx.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    xx.StartCash |> Option.iter (WriteStartCash strm)
    xx.EndCash |> Option.iter (WriteEndCash strm)
    xx.LegalConfirm |> Option.iter (WriteLegalConfirm strm)
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    xx.TotNoAllocs |> Option.iter (WriteTotNoAllocs strm)
    xx.LastFragment |> Option.iter (WriteLastFragment strm)
    let numGrps = xx.AllocationReport_NoAllocsGrp.Length
    WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
    xx.AllocationReport_NoAllocsGrp |> List.iter (fun gg -> WriteAllocationReport_NoAllocsGrp strm gg)


// tag: AT
let WriteAllocationReportAck (xx:AllocationReportAck) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteAllocReportID strm xx.AllocReportID
    WriteAllocID strm xx.AllocID
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.SecondaryAllocID |> Option.iter (WriteSecondaryAllocID strm)
    xx.TradeDate |> Option.iter (WriteTradeDate strm)
    WriteTransactTime strm xx.TransactTime
    WriteAllocStatus strm xx.AllocStatus
    xx.AllocRejCode |> Option.iter (WriteAllocRejCode strm)
    xx.AllocReportType |> Option.iter (WriteAllocReportType strm)
    xx.AllocIntermedReqType |> Option.iter (WriteAllocIntermedReqType strm)
    xx.MatchStatus |> Option.iter (WriteMatchStatus strm)
    xx.Product |> Option.iter (WriteProduct strm)
    xx.SecurityType |> Option.iter (WriteSecurityType strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.AllocationReportAck_NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteAllocationReportAck_NoAllocsGrp strm gg)    ) // end Option.iter


// tag: AK
let WriteConfirmation (xx:Confirmation) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteConfirmID strm xx.ConfirmID
    xx.ConfirmRefID |> Option.iter (WriteConfirmRefID strm)
    xx.ConfirmReqID |> Option.iter (WriteConfirmReqID strm)
    WriteConfirmTransType strm xx.ConfirmTransType
    WriteConfirmType strm xx.ConfirmType
    xx.CopyMsgIndicator |> Option.iter (WriteCopyMsgIndicator strm)
    xx.LegalConfirm |> Option.iter (WriteLegalConfirm strm)
    WriteConfirmStatus strm xx.ConfirmStatus
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.NoOrdersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoOrders strm (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoOrdersGrp strm gg)    ) // end Option.iter
    xx.AllocID |> Option.iter (WriteAllocID strm)
    xx.SecondaryAllocID |> Option.iter (WriteSecondaryAllocID strm)
    xx.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    WriteTransactTime strm xx.TransactTime
    WriteTradeDate strm xx.TradeDate
    xx.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    WriteInstrument strm xx.Instrument    // component
    xx.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    let numGrps = xx.NoUnderlyingsGrp.Length
    WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
    xx.NoUnderlyingsGrp |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)
    let numGrps = xx.NoLegsGrp.Length
    WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
    xx.NoLegsGrp |> List.iter (fun gg -> WriteNoLegsGrp strm gg)
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    WriteAllocQty strm xx.AllocQty
    xx.QtyType |> Option.iter (WriteQtyType strm)
    WriteSide strm xx.Side
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.LastMkt |> Option.iter (WriteLastMkt strm)
    let numGrps = xx.NoCapacitiesGrp.Length
    WriteNoCapacities strm (Fix44.Fields.NoCapacities numGrps) // write the 'num group repeats' field
    xx.NoCapacitiesGrp |> List.iter (fun gg -> WriteNoCapacitiesGrp strm gg)
    WriteAllocAccount strm xx.AllocAccount
    xx.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    xx.AllocAccountType |> Option.iter (WriteAllocAccountType strm)
    WriteAvgPx strm xx.AvgPx
    xx.AvgPxPrecision |> Option.iter (WriteAvgPxPrecision strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.AvgParPx |> Option.iter (WriteAvgParPx strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.ReportedPx |> Option.iter (WriteReportedPx strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.ProcessCode |> Option.iter (WriteProcessCode strm)
    WriteGrossTradeAmt strm xx.GrossTradeAmt
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
    WriteNetMoney strm xx.NetMoney
    xx.MaturityNetMoney |> Option.iter (WriteMaturityNetMoney strm)
    xx.SettlCurrAmt |> Option.iter (WriteSettlCurrAmt strm)
    xx.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    xx.SettlCurrFxRate |> Option.iter (WriteSettlCurrFxRate strm)
    xx.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    xx.SettlType |> Option.iter (WriteSettlType strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component
    xx.CommissionData |> Option.iter (WriteCommissionData strm) // component
    xx.SharedCommission |> Option.iter (WriteSharedCommission strm)
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter


// tag: AU
let WriteConfirmationAck (xx:ConfirmationAck) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteConfirmID strm xx.ConfirmID
    WriteTradeDate strm xx.TradeDate
    WriteTransactTime strm xx.TransactTime
    WriteAffirmStatus strm xx.AffirmStatus
    xx.ConfirmRejReason |> Option.iter (WriteConfirmRejReason strm)
    xx.MatchStatus |> Option.iter (WriteMatchStatus strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: BH
let WriteConfirmationRequest (xx:ConfirmationRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteConfirmReqID strm xx.ConfirmReqID
    WriteConfirmType strm xx.ConfirmType
    xx.NoOrdersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoOrders strm (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoOrdersGrp strm gg)    ) // end Option.iter
    xx.AllocID |> Option.iter (WriteAllocID strm)
    xx.SecondaryAllocID |> Option.iter (WriteSecondaryAllocID strm)
    xx.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    WriteTransactTime strm xx.TransactTime
    xx.AllocAccount |> Option.iter (WriteAllocAccount strm)
    xx.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    xx.AllocAccountType |> Option.iter (WriteAllocAccountType strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: T
let WriteSettlementInstructions (xx:SettlementInstructions) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteSettlInstMsgID strm xx.SettlInstMsgID
    xx.SettlInstReqID |> Option.iter (WriteSettlInstReqID strm)
    WriteSettlInstMode strm xx.SettlInstMode
    xx.SettlInstReqRejCode |> Option.iter (WriteSettlInstReqRejCode strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.SettlInstSource |> Option.iter (WriteSettlInstSource strm)
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    WriteTransactTime strm xx.TransactTime
    xx.NoSettlInstGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoSettlInst strm (Fix44.Fields.NoSettlInst numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoSettlInstGrp strm gg)    ) // end Option.iter


// tag: AV
let WriteSettlementInstructionRequest (xx:SettlementInstructionRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteSettlInstReqID strm xx.SettlInstReqID
    WriteTransactTime strm xx.TransactTime
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.AllocAccount |> Option.iter (WriteAllocAccount strm)
    xx.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    xx.Side |> Option.iter (WriteSide strm)
    xx.Product |> Option.iter (WriteProduct strm)
    xx.SecurityType |> Option.iter (WriteSecurityType strm)
    xx.CFICode |> Option.iter (WriteCFICode strm)
    xx.EffectiveTime |> Option.iter (WriteEffectiveTime strm)
    xx.ExpireTime |> Option.iter (WriteExpireTime strm)
    xx.LastUpdateTime |> Option.iter (WriteLastUpdateTime strm)
    xx.StandInstDbType |> Option.iter (WriteStandInstDbType strm)
    xx.StandInstDbName |> Option.iter (WriteStandInstDbName strm)
    xx.StandInstDbID |> Option.iter (WriteStandInstDbID strm)


// tag: AD
let WriteTradeCaptureReportRequest (xx:TradeCaptureReportRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteTradeRequestID strm xx.TradeRequestID
    WriteTradeRequestType strm xx.TradeRequestType
    xx.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    xx.TradeReportID |> Option.iter (WriteTradeReportID strm)
    xx.SecondaryTradeReportID |> Option.iter (WriteSecondaryTradeReportID strm)
    xx.ExecID |> Option.iter (WriteExecID strm)
    xx.ExecType |> Option.iter (WriteExecType strm)
    xx.OrderID |> Option.iter (WriteOrderID strm)
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.MatchStatus |> Option.iter (WriteMatchStatus strm)
    xx.TrdType |> Option.iter (WriteTrdType strm)
    xx.TrdSubType |> Option.iter (WriteTrdSubType strm)
    xx.TransferReason |> Option.iter (WriteTransferReason strm)
    xx.SecondaryTrdType |> Option.iter (WriteSecondaryTrdType strm)
    xx.TradeLinkID |> Option.iter (WriteTradeLinkID strm)
    xx.TrdMatchID |> Option.iter (WriteTrdMatchID strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.NoDatesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoDates strm (Fix44.Fields.NoDates numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoDatesGrp strm gg)    ) // end Option.iter
    xx.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.TimeBracket |> Option.iter (WriteTimeBracket strm)
    xx.Side |> Option.iter (WriteSide strm)
    xx.MultiLegReportingType |> Option.iter (WriteMultiLegReportingType strm)
    xx.TradeInputSource |> Option.iter (WriteTradeInputSource strm)
    xx.TradeInputDevice |> Option.iter (WriteTradeInputDevice strm)
    xx.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    xx.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: AQ
let WriteTradeCaptureReportRequestAck (xx:TradeCaptureReportRequestAck) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteTradeRequestID strm xx.TradeRequestID
    WriteTradeRequestType strm xx.TradeRequestType
    xx.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    xx.TotNumTradeReports |> Option.iter (WriteTotNumTradeReports strm)
    WriteTradeRequestResult strm xx.TradeRequestResult
    WriteTradeRequestStatus strm xx.TradeRequestStatus
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.MultiLegReportingType |> Option.iter (WriteMultiLegReportingType strm)
    xx.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    xx.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: AE
let WriteTradeCaptureReport (xx:TradeCaptureReport) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteTradeReportID strm xx.TradeReportID
    xx.TradeReportTransType |> Option.iter (WriteTradeReportTransType strm)
    xx.TradeReportType |> Option.iter (WriteTradeReportType strm)
    xx.TradeRequestID |> Option.iter (WriteTradeRequestID strm)
    xx.TrdType |> Option.iter (WriteTrdType strm)
    xx.TrdSubType |> Option.iter (WriteTrdSubType strm)
    xx.SecondaryTrdType |> Option.iter (WriteSecondaryTrdType strm)
    xx.TransferReason |> Option.iter (WriteTransferReason strm)
    xx.ExecType |> Option.iter (WriteExecType strm)
    xx.TotNumTradeReports |> Option.iter (WriteTotNumTradeReports strm)
    xx.LastRptRequested |> Option.iter (WriteLastRptRequested strm)
    xx.UnsolicitedIndicator |> Option.iter (WriteUnsolicitedIndicator strm)
    xx.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    xx.TradeReportRefID |> Option.iter (WriteTradeReportRefID strm)
    xx.SecondaryTradeReportRefID |> Option.iter (WriteSecondaryTradeReportRefID strm)
    xx.SecondaryTradeReportID |> Option.iter (WriteSecondaryTradeReportID strm)
    xx.TradeLinkID |> Option.iter (WriteTradeLinkID strm)
    xx.TrdMatchID |> Option.iter (WriteTrdMatchID strm)
    xx.ExecID |> Option.iter (WriteExecID strm)
    xx.OrdStatus |> Option.iter (WriteOrdStatus strm)
    xx.SecondaryExecID |> Option.iter (WriteSecondaryExecID strm)
    xx.ExecRestatementReason |> Option.iter (WriteExecRestatementReason strm)
    WritePreviouslyReported strm xx.PreviouslyReported
    xx.PriceType |> Option.iter (WritePriceType strm)
    WriteInstrument strm xx.Instrument    // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.OrderQtyData |> Option.iter (WriteOrderQtyData strm) // component
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.YieldData |> Option.iter (WriteYieldData strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.UnderlyingTradingSessionID |> Option.iter (WriteUnderlyingTradingSessionID strm)
    xx.UnderlyingTradingSessionSubID |> Option.iter (WriteUnderlyingTradingSessionSubID strm)
    WriteLastQty strm xx.LastQty
    WriteLastPx strm xx.LastPx
    xx.LastParPx |> Option.iter (WriteLastParPx strm)
    xx.LastSpotRate |> Option.iter (WriteLastSpotRate strm)
    xx.LastForwardPoints |> Option.iter (WriteLastForwardPoints strm)
    xx.LastMkt |> Option.iter (WriteLastMkt strm)
    WriteTradeDate strm xx.TradeDate
    xx.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    xx.AvgPx |> Option.iter (WriteAvgPx strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.AvgPxIndicator |> Option.iter (WriteAvgPxIndicator strm)
    xx.PositionAmountData |> Option.iter (WritePositionAmountData strm) // component
    xx.MultiLegReportingType |> Option.iter (WriteMultiLegReportingType strm)
    xx.TradeLegRefID |> Option.iter (WriteTradeLegRefID strm)
    xx.TradeCaptureReport_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteTradeCaptureReport_NoLegsGrp strm gg)    ) // end Option.iter
    WriteTransactTime strm xx.TransactTime
    xx.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    xx.SettlType |> Option.iter (WriteSettlType strm)
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.MatchStatus |> Option.iter (WriteMatchStatus strm)
    xx.MatchType |> Option.iter (WriteMatchType strm)
    let noSidesField =  // ####
        match xx.TradeCaptureReport_NoSidesGrp with
        | OneOrTwo.One _ -> NoSides.OneSide
        | OneOrTwo.Two _ -> NoSides.BothSides
    WriteNoSides strm noSidesField
    xx.TradeCaptureReport_NoSidesGrp |> OneOrTwo.iter (WriteTradeCaptureReport_NoSidesGrp strm)   // group
    xx.CopyMsgIndicator |> Option.iter (WriteCopyMsgIndicator strm)
    xx.PublishTrdIndicator |> Option.iter (WritePublishTrdIndicator strm)
    xx.ShortSaleReason |> Option.iter (WriteShortSaleReason strm)


// tag: AR
let WriteTradeCaptureReportAck (xx:TradeCaptureReportAck) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteTradeReportID strm xx.TradeReportID
    xx.TradeReportTransType |> Option.iter (WriteTradeReportTransType strm)
    xx.TradeReportType |> Option.iter (WriteTradeReportType strm)
    xx.TrdType |> Option.iter (WriteTrdType strm)
    xx.TrdSubType |> Option.iter (WriteTrdSubType strm)
    xx.SecondaryTrdType |> Option.iter (WriteSecondaryTrdType strm)
    xx.TransferReason |> Option.iter (WriteTransferReason strm)
    WriteExecType strm xx.ExecType
    xx.TradeReportRefID |> Option.iter (WriteTradeReportRefID strm)
    xx.SecondaryTradeReportRefID |> Option.iter (WriteSecondaryTradeReportRefID strm)
    xx.TrdRptStatus |> Option.iter (WriteTrdRptStatus strm)
    xx.TradeReportRejectReason |> Option.iter (WriteTradeReportRejectReason strm)
    xx.SecondaryTradeReportID |> Option.iter (WriteSecondaryTradeReportID strm)
    xx.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    xx.TradeLinkID |> Option.iter (WriteTradeLinkID strm)
    xx.TrdMatchID |> Option.iter (WriteTrdMatchID strm)
    xx.ExecID |> Option.iter (WriteExecID strm)
    xx.SecondaryExecID |> Option.iter (WriteSecondaryExecID strm)
    WriteInstrument strm xx.Instrument    // component
    xx.TransactTime |> Option.iter (WriteTransactTime strm)
    xx.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    xx.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    xx.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)
    xx.TradeCaptureReportAck_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteTradeCaptureReportAck_NoLegsGrp strm gg)    ) // end Option.iter
    xx.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    xx.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    xx.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    xx.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.PositionEffect |> Option.iter (WritePositionEffect strm)
    xx.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    xx.TradeCaptureReportAck_NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteTradeCaptureReportAck_NoAllocsGrp strm gg)    ) // end Option.iter


// tag: o
let WriteRegistrationInstructions (xx:RegistrationInstructions) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteRegistID strm xx.RegistID
    WriteRegistTransType strm xx.RegistTransType
    WriteRegistRefID strm xx.RegistRefID
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    xx.RegistAcctType |> Option.iter (WriteRegistAcctType strm)
    xx.TaxAdvantageType |> Option.iter (WriteTaxAdvantageType strm)
    xx.OwnershipType |> Option.iter (WriteOwnershipType strm)
    xx.NoRegistDtlsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRegistDtls strm (Fix44.Fields.NoRegistDtls numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoRegistDtlsGrp strm gg)    ) // end Option.iter
    xx.NoDistribInstsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoDistribInsts strm (Fix44.Fields.NoDistribInsts numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoDistribInstsGrp strm gg)    ) // end Option.iter


// tag: p
let WriteRegistrationInstructionsResponse (xx:RegistrationInstructionsResponse) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteRegistID strm xx.RegistID
    WriteRegistTransType strm xx.RegistTransType
    WriteRegistRefID strm xx.RegistRefID
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteRegistStatus strm xx.RegistStatus
    xx.RegistRejReasonCode |> Option.iter (WriteRegistRejReasonCode strm)
    xx.RegistRejReasonText |> Option.iter (WriteRegistRejReasonText strm)


// tag: AL
let WritePositionMaintenanceRequest (xx:PositionMaintenanceRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WritePosReqID strm xx.PosReqID
    WritePosTransType strm xx.PosTransType
    WritePosMaintAction strm xx.PosMaintAction
    xx.OrigPosReqRefID |> Option.iter (WriteOrigPosReqRefID strm)
    xx.PosMaintRptRefID |> Option.iter (WritePosMaintRptRefID strm)
    WriteClearingBusinessDate strm xx.ClearingBusinessDate
    xx.SettlSessID |> Option.iter (WriteSettlSessID strm)
    xx.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    WriteParties strm xx.Parties    // component
    WriteAccount strm xx.Account
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteAccountType strm xx.AccountType
    WriteInstrument strm xx.Instrument    // component
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoTradingSessionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTradingSessions strm (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradingSessionsGrp strm gg)    ) // end Option.iter
    WriteTransactTime strm xx.TransactTime
    WritePositionQty strm xx.PositionQty    // component
    xx.AdjustmentType |> Option.iter (WriteAdjustmentType strm)
    xx.ContraryInstructionIndicator |> Option.iter (WriteContraryInstructionIndicator strm)
    xx.PriorSpreadIndicator |> Option.iter (WritePriorSpreadIndicator strm)
    xx.ThresholdAmount |> Option.iter (WriteThresholdAmount strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: AM
let WritePositionMaintenanceReport (xx:PositionMaintenanceReport) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WritePosMaintRptID strm xx.PosMaintRptID
    WritePosTransType strm xx.PosTransType
    xx.PosReqID |> Option.iter (WritePosReqID strm)
    WritePosMaintAction strm xx.PosMaintAction
    WriteOrigPosReqRefID strm xx.OrigPosReqRefID
    WritePosMaintStatus strm xx.PosMaintStatus
    xx.PosMaintResult |> Option.iter (WritePosMaintResult strm)
    WriteClearingBusinessDate strm xx.ClearingBusinessDate
    xx.SettlSessID |> Option.iter (WriteSettlSessID strm)
    xx.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    WriteAccount strm xx.Account
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteAccountType strm xx.AccountType
    WriteInstrument strm xx.Instrument    // component
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.NoTradingSessionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTradingSessions strm (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradingSessionsGrp strm gg)    ) // end Option.iter
    WriteTransactTime strm xx.TransactTime
    WritePositionQty strm xx.PositionQty    // component
    WritePositionAmountData strm xx.PositionAmountData    // component
    xx.AdjustmentType |> Option.iter (WriteAdjustmentType strm)
    xx.ThresholdAmount |> Option.iter (WriteThresholdAmount strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: AN
let WriteRequestForPositions (xx:RequestForPositions) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WritePosReqID strm xx.PosReqID
    WritePosReqType strm xx.PosReqType
    xx.MatchStatus |> Option.iter (WriteMatchStatus strm)
    xx.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    WriteParties strm xx.Parties    // component
    WriteAccount strm xx.Account
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteAccountType strm xx.AccountType
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteClearingBusinessDate strm xx.ClearingBusinessDate
    xx.SettlSessID |> Option.iter (WriteSettlSessID strm)
    xx.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    xx.NoTradingSessionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTradingSessions strm (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradingSessionsGrp strm gg)    ) // end Option.iter
    WriteTransactTime strm xx.TransactTime
    xx.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    xx.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: AO
let WriteRequestForPositionsAck (xx:RequestForPositionsAck) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WritePosMaintRptID strm xx.PosMaintRptID
    xx.PosReqID |> Option.iter (WritePosReqID strm)
    xx.TotalNumPosReports |> Option.iter (WriteTotalNumPosReports strm)
    xx.UnsolicitedIndicator |> Option.iter (WriteUnsolicitedIndicator strm)
    WritePosReqResult strm xx.PosReqResult
    WritePosReqStatus strm xx.PosReqStatus
    WriteParties strm xx.Parties    // component
    WriteAccount strm xx.Account
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteAccountType strm xx.AccountType
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    xx.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: AP
let WritePositionReport (xx:PositionReport) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WritePosMaintRptID strm xx.PosMaintRptID
    xx.PosReqID |> Option.iter (WritePosReqID strm)
    xx.PosReqType |> Option.iter (WritePosReqType strm)
    xx.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    xx.TotalNumPosReports |> Option.iter (WriteTotalNumPosReports strm)
    xx.UnsolicitedIndicator |> Option.iter (WriteUnsolicitedIndicator strm)
    WritePosReqResult strm xx.PosReqResult
    WriteClearingBusinessDate strm xx.ClearingBusinessDate
    xx.SettlSessID |> Option.iter (WriteSettlSessID strm)
    xx.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    WriteParties strm xx.Parties    // component
    WriteAccount strm xx.Account
    xx.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteAccountType strm xx.AccountType
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.Currency |> Option.iter (WriteCurrency strm)
    WriteSettlPrice strm xx.SettlPrice
    WriteSettlPriceType strm xx.SettlPriceType
    WritePriorSettlPrice strm xx.PriorSettlPrice
    xx.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    xx.PositionReport_NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WritePositionReport_NoUnderlyingsGrp strm gg)    ) // end Option.iter
    WritePositionQty strm xx.PositionQty    // component
    WritePositionAmountData strm xx.PositionAmountData    // component
    xx.RegistStatus |> Option.iter (WriteRegistStatus strm)
    xx.DeliveryDate |> Option.iter (WriteDeliveryDate strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: AW
let WriteAssignmentReport (xx:AssignmentReport) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteAsgnRptID strm xx.AsgnRptID
    xx.TotNumAssignmentReports |> Option.iter (WriteTotNumAssignmentReports strm)
    xx.LastRptRequested |> Option.iter (WriteLastRptRequested strm)
    WriteParties strm xx.Parties    // component
    xx.Account |> Option.iter (WriteAccount strm)
    WriteAccountType strm xx.AccountType
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.NoLegs |> Option.iter (WriteNoLegs strm)
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WritePositionQty strm xx.PositionQty    // component
    WritePositionAmountData strm xx.PositionAmountData    // component
    xx.ThresholdAmount |> Option.iter (WriteThresholdAmount strm)
    WriteSettlPrice strm xx.SettlPrice
    WriteSettlPriceType strm xx.SettlPriceType
    WriteUnderlyingSettlPrice strm xx.UnderlyingSettlPrice
    xx.ExpireDate |> Option.iter (WriteExpireDate strm)
    WriteAssignmentMethod strm xx.AssignmentMethod
    xx.AssignmentUnit |> Option.iter (WriteAssignmentUnit strm)
    WriteOpenInterest strm xx.OpenInterest
    WriteExerciseMethod strm xx.ExerciseMethod
    WriteSettlSessID strm xx.SettlSessID
    WriteSettlSessSubID strm xx.SettlSessSubID
    WriteClearingBusinessDate strm xx.ClearingBusinessDate
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: AX
let WriteCollateralRequest (xx:CollateralRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteCollReqID strm xx.CollReqID
    WriteCollAsgnReason strm xx.CollAsgnReason
    WriteTransactTime strm xx.TransactTime
    xx.ExpireTime |> Option.iter (WriteExpireTime strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.OrderID |> Option.iter (WriteOrderID strm)
    xx.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoExecsGrp strm gg)    ) // end Option.iter
    xx.NoTradesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTrades strm (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradesGrp strm gg)    ) // end Option.iter
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.Quantity |> Option.iter (WriteQuantity strm)
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.NoLegs |> Option.iter (WriteNoLegs strm)
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.CollateralRequest_NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteCollateralRequest_NoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.MarginExcess |> Option.iter (WriteMarginExcess strm)
    xx.TotalNetValue |> Option.iter (WriteTotalNetValue strm)
    xx.CashOutstanding |> Option.iter (WriteCashOutstanding strm)
    xx.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    xx.Side |> Option.iter (WriteSide strm)
    xx.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    xx.Price |> Option.iter (WritePrice strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    xx.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    xx.StartCash |> Option.iter (WriteStartCash strm)
    xx.EndCash |> Option.iter (WriteEndCash strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.SettlSessID |> Option.iter (WriteSettlSessID strm)
    xx.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    xx.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: AY
let WriteCollateralAssignment (xx:CollateralAssignment) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteCollAsgnID strm xx.CollAsgnID
    xx.CollReqID |> Option.iter (WriteCollReqID strm)
    WriteCollAsgnReason strm xx.CollAsgnReason
    WriteCollAsgnTransType strm xx.CollAsgnTransType
    xx.CollAsgnRefID |> Option.iter (WriteCollAsgnRefID strm)
    WriteTransactTime strm xx.TransactTime
    xx.ExpireTime |> Option.iter (WriteExpireTime strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.OrderID |> Option.iter (WriteOrderID strm)
    xx.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoExecsGrp strm gg)    ) // end Option.iter
    xx.NoTradesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTrades strm (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradesGrp strm gg)    ) // end Option.iter
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.Quantity |> Option.iter (WriteQuantity strm)
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.NoLegs |> Option.iter (WriteNoLegs strm)
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.CollateralAssignment_NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteCollateralAssignment_NoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.MarginExcess |> Option.iter (WriteMarginExcess strm)
    xx.TotalNetValue |> Option.iter (WriteTotalNetValue strm)
    xx.CashOutstanding |> Option.iter (WriteCashOutstanding strm)
    xx.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    xx.Side |> Option.iter (WriteSide strm)
    xx.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    xx.Price |> Option.iter (WritePrice strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    xx.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    xx.StartCash |> Option.iter (WriteStartCash strm)
    xx.EndCash |> Option.iter (WriteEndCash strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.SettlSessID |> Option.iter (WriteSettlSessID strm)
    xx.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    xx.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: AZ
let WriteCollateralResponse (xx:CollateralResponse) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteCollRespID strm xx.CollRespID
    WriteCollAsgnID strm xx.CollAsgnID
    xx.CollReqID |> Option.iter (WriteCollReqID strm)
    WriteCollAsgnReason strm xx.CollAsgnReason
    xx.CollAsgnTransType |> Option.iter (WriteCollAsgnTransType strm)
    WriteCollAsgnRespType strm xx.CollAsgnRespType
    xx.CollAsgnRejectReason |> Option.iter (WriteCollAsgnRejectReason strm)
    WriteTransactTime strm xx.TransactTime
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.OrderID |> Option.iter (WriteOrderID strm)
    xx.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoExecsGrp strm gg)    ) // end Option.iter
    xx.NoTradesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTrades strm (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradesGrp strm gg)    ) // end Option.iter
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.Quantity |> Option.iter (WriteQuantity strm)
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.NoLegs |> Option.iter (WriteNoLegs strm)
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.CollateralResponse_NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteCollateralResponse_NoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.MarginExcess |> Option.iter (WriteMarginExcess strm)
    xx.TotalNetValue |> Option.iter (WriteTotalNetValue strm)
    xx.CashOutstanding |> Option.iter (WriteCashOutstanding strm)
    xx.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    xx.Side |> Option.iter (WriteSide strm)
    xx.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    xx.Price |> Option.iter (WritePrice strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    xx.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    xx.StartCash |> Option.iter (WriteStartCash strm)
    xx.EndCash |> Option.iter (WriteEndCash strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: BA
let WriteCollateralReport (xx:CollateralReport) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteCollRptID strm xx.CollRptID
    xx.CollInquiryID |> Option.iter (WriteCollInquiryID strm)
    WriteCollStatus strm xx.CollStatus
    xx.TotNumReports |> Option.iter (WriteTotNumReports strm)
    xx.LastRptRequested |> Option.iter (WriteLastRptRequested strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.OrderID |> Option.iter (WriteOrderID strm)
    xx.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoExecsGrp strm gg)    ) // end Option.iter
    xx.NoTradesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTrades strm (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradesGrp strm gg)    ) // end Option.iter
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.Quantity |> Option.iter (WriteQuantity strm)
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.NoLegs |> Option.iter (WriteNoLegs strm)
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.MarginExcess |> Option.iter (WriteMarginExcess strm)
    xx.TotalNetValue |> Option.iter (WriteTotalNetValue strm)
    xx.CashOutstanding |> Option.iter (WriteCashOutstanding strm)
    xx.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    xx.Side |> Option.iter (WriteSide strm)
    xx.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    xx.Price |> Option.iter (WritePrice strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    xx.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    xx.StartCash |> Option.iter (WriteStartCash strm)
    xx.EndCash |> Option.iter (WriteEndCash strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.SettlSessID |> Option.iter (WriteSettlSessID strm)
    xx.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    xx.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: BB
let WriteCollateralInquiry (xx:CollateralInquiry) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    xx.CollInquiryID |> Option.iter (WriteCollInquiryID strm)
    xx.NoCollInquiryQualifierGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoCollInquiryQualifier strm (Fix44.Fields.NoCollInquiryQualifier numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoCollInquiryQualifierGrp strm gg)    ) // end Option.iter
    xx.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    xx.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    xx.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.OrderID |> Option.iter (WriteOrderID strm)
    xx.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoExecsGrp strm gg)    ) // end Option.iter
    xx.NoTradesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTrades strm (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradesGrp strm gg)    ) // end Option.iter
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.Quantity |> Option.iter (WriteQuantity strm)
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.NoLegs |> Option.iter (WriteNoLegs strm)
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.MarginExcess |> Option.iter (WriteMarginExcess strm)
    xx.TotalNetValue |> Option.iter (WriteTotalNetValue strm)
    xx.CashOutstanding |> Option.iter (WriteCashOutstanding strm)
    xx.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    xx.Side |> Option.iter (WriteSide strm)
    xx.Price |> Option.iter (WritePrice strm)
    xx.PriceType |> Option.iter (WritePriceType strm)
    xx.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    xx.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    xx.StartCash |> Option.iter (WriteStartCash strm)
    xx.EndCash |> Option.iter (WriteEndCash strm)
    xx.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    xx.Stipulations |> Option.iter (WriteStipulations strm) // component
    xx.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.SettlSessID |> Option.iter (WriteSettlSessID strm)
    xx.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    xx.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


// tag: BC
let WriteNetworkStatusRequest (xx:NetworkStatusRequest) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteNetworkRequestType strm xx.NetworkRequestType
    WriteNetworkRequestID strm xx.NetworkRequestID
    xx.NoCompIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoCompIDs strm (Fix44.Fields.NoCompIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoCompIDsGrp strm gg)    ) // end Option.iter


// tag: BD
let WriteNetworkStatusResponse (xx:NetworkStatusResponse) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteNetworkStatusResponseType strm xx.NetworkStatusResponseType
    xx.NetworkRequestID |> Option.iter (WriteNetworkRequestID strm)
    xx.NetworkResponseID |> Option.iter (WriteNetworkResponseID strm)
    xx.LastNetworkResponseID |> Option.iter (WriteLastNetworkResponseID strm)
    let numGrps = xx.NetworkStatusResponse_NoCompIDsGrp.Length
    WriteNoCompIDs strm (Fix44.Fields.NoCompIDs numGrps) // write the 'num group repeats' field
    xx.NetworkStatusResponse_NoCompIDsGrp |> List.iter (fun gg -> WriteNetworkStatusResponse_NoCompIDsGrp strm gg)


// tag: BG
let WriteCollateralInquiryAck (xx:CollateralInquiryAck) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:System.IO.Stream) = 
    WriteCollInquiryID strm xx.CollInquiryID
    WriteCollInquiryStatus strm xx.CollInquiryStatus
    xx.CollInquiryResult |> Option.iter (WriteCollInquiryResult strm)
    xx.NoCollInquiryQualifierGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoCollInquiryQualifier strm (Fix44.Fields.NoCollInquiryQualifier numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoCollInquiryQualifierGrp strm gg)    ) // end Option.iter
    xx.TotNumReports |> Option.iter (WriteTotNumReports strm)
    xx.Parties |> Option.iter (WriteParties strm) // component
    xx.Account |> Option.iter (WriteAccount strm)
    xx.AccountType |> Option.iter (WriteAccountType strm)
    xx.ClOrdID |> Option.iter (WriteClOrdID strm)
    xx.OrderID |> Option.iter (WriteOrderID strm)
    xx.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    xx.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    xx.NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoExecsGrp strm gg)    ) // end Option.iter
    xx.NoTradesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTrades strm (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradesGrp strm gg)    ) // end Option.iter
    xx.Instrument |> Option.iter (WriteInstrument strm) // component
    xx.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    xx.SettlDate |> Option.iter (WriteSettlDate strm)
    xx.Quantity |> Option.iter (WriteQuantity strm)
    xx.QtyType |> Option.iter (WriteQtyType strm)
    xx.Currency |> Option.iter (WriteCurrency strm)
    xx.NoLegs |> Option.iter (WriteNoLegs strm)
    xx.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    xx.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    xx.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    xx.SettlSessID |> Option.iter (WriteSettlSessID strm)
    xx.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    xx.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    xx.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    xx.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    xx.Text |> Option.iter (WriteText strm)
    xx.EncodedText |> Option.iter (WriteEncodedText strm)


