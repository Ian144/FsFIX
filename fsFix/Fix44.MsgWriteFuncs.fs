module Fix44.MsgWriteFuncs

open OneOrTwo
open Fix44.Fields
open Fix44.FieldReadWriteFuncs
open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs
open Fix44.Messages


let WriteHeartbeat (strm:System.IO.Stream) (grp:Heartbeat) =
    grp.TestReqID |> Option.iter (WriteTestReqID strm)


let WriteLogon (strm:System.IO.Stream) (grp:Logon) =
    WriteEncryptMethod strm grp.EncryptMethod
    WriteHeartBtInt strm grp.HeartBtInt
    grp.RawDataLength |> Option.iter (WriteRawDataLength strm)
    grp.RawData |> Option.iter (WriteRawData strm)
    grp.ResetSeqNumFlag |> Option.iter (WriteResetSeqNumFlag strm)
    grp.NextExpectedMsgSeqNum |> Option.iter (WriteNextExpectedMsgSeqNum strm)
    grp.MaxMessageSize |> Option.iter (WriteMaxMessageSize strm)
    grp.NoMsgTypesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMsgTypes strm (Fix44.Fields.NoMsgTypes numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMsgTypesGrp strm gg)    ) // end Option.iter
    grp.TestMessageIndicator |> Option.iter (WriteTestMessageIndicator strm)
    grp.Username |> Option.iter (WriteUsername strm)
    grp.Password |> Option.iter (WritePassword strm)


let WriteTestRequest (strm:System.IO.Stream) (grp:TestRequest) =
    WriteTestReqID strm grp.TestReqID


let WriteResendRequest (strm:System.IO.Stream) (grp:ResendRequest) =
    WriteBeginSeqNo strm grp.BeginSeqNo
    WriteEndSeqNo strm grp.EndSeqNo


let WriteReject (strm:System.IO.Stream) (grp:Reject) =
    WriteRefSeqNum strm grp.RefSeqNum
    grp.RefTagID |> Option.iter (WriteRefTagID strm)
    grp.RefMsgType |> Option.iter (WriteRefMsgType strm)
    grp.SessionRejectReason |> Option.iter (WriteSessionRejectReason strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteSequenceReset (strm:System.IO.Stream) (grp:SequenceReset) =
    grp.GapFillFlag |> Option.iter (WriteGapFillFlag strm)
    WriteNewSeqNo strm grp.NewSeqNo


let WriteLogout (strm:System.IO.Stream) (grp:Logout) =
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteBusinessMessageReject (strm:System.IO.Stream) (grp:BusinessMessageReject) =
    grp.RefSeqNum |> Option.iter (WriteRefSeqNum strm)
    WriteRefMsgType strm grp.RefMsgType
    grp.BusinessRejectRefID |> Option.iter (WriteBusinessRejectRefID strm)
    WriteBusinessRejectReason strm grp.BusinessRejectReason
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteUserRequest (strm:System.IO.Stream) (grp:UserRequest) =
    WriteUserRequestID strm grp.UserRequestID
    WriteUserRequestType strm grp.UserRequestType
    WriteUsername strm grp.Username
    grp.Password |> Option.iter (WritePassword strm)
    grp.NewPassword |> Option.iter (WriteNewPassword strm)
    grp.RawDataLength |> Option.iter (WriteRawDataLength strm)
    grp.RawData |> Option.iter (WriteRawData strm)


let WriteUserResponse (strm:System.IO.Stream) (grp:UserResponse) =
    WriteUserRequestID strm grp.UserRequestID
    WriteUsername strm grp.Username
    grp.UserStatus |> Option.iter (WriteUserStatus strm)
    grp.UserStatusText |> Option.iter (WriteUserStatusText strm)


let WriteAdvertisement (strm:System.IO.Stream) (grp:Advertisement) =
    WriteAdvId strm grp.AdvId
    WriteAdvTransType strm grp.AdvTransType
    grp.AdvRefID |> Option.iter (WriteAdvRefID strm)
    WriteInstrument strm grp.Instrument    // component
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.Advertisement_NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteAdvertisement_NoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteAdvSide strm grp.AdvSide
    WriteQuantity strm grp.Quantity
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.URLLink |> Option.iter (WriteURLLink strm)
    grp.LastMkt |> Option.iter (WriteLastMkt strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)


let WriteIndicationOfInterest (strm:System.IO.Stream) (grp:IndicationOfInterest) =
    WriteIOIid strm grp.IOIid
    WriteIOITransType strm grp.IOITransType
    grp.IOIRefID |> Option.iter (WriteIOIRefID strm)
    WriteInstrument strm grp.Instrument    // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteSide strm grp.Side
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.OrderQtyData |> Option.iter (WriteOrderQtyData strm) // component
    WriteIOIQty strm grp.IOIQty
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.IndicationOfInterest_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteIndicationOfInterest_NoLegsGrp strm gg)    ) // end Option.iter
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.ValidUntilTime |> Option.iter (WriteValidUntilTime strm)
    grp.IOIQltyInd |> Option.iter (WriteIOIQltyInd strm)
    grp.IOINaturalFlag |> Option.iter (WriteIOINaturalFlag strm)
    grp.NoIOIQualifiersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoIOIQualifiers strm (Fix44.Fields.NoIOIQualifiers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoIOIQualifiersGrp strm gg)    ) // end Option.iter
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    grp.URLLink |> Option.iter (WriteURLLink strm)
    grp.NoRoutingIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRoutingIDs strm (Fix44.Fields.NoRoutingIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoRoutingIDsGrp strm gg)    ) // end Option.iter
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.YieldData |> Option.iter (WriteYieldData strm) // component


let WriteNews (strm:System.IO.Stream) (grp:News) =
    grp.OrigTime |> Option.iter (WriteOrigTime strm)
    grp.Urgency |> Option.iter (WriteUrgency strm)
    WriteHeadline strm grp.Headline
    grp.EncodedHeadline |> Option.iter (WriteEncodedHeadline strm)
    grp.NoRoutingIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRoutingIDs strm (Fix44.Fields.NoRoutingIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoRoutingIDsGrp strm gg)    ) // end Option.iter
    grp.NoRelatedSymGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoRelatedSymGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    let numGrps = grp.LinesOfTextGrp.Length
    WriteLinesOfText strm (Fix44.Fields.LinesOfText numGrps) // write the 'num group repeats' field
    grp.LinesOfTextGrp |> List.iter (fun gg -> WriteLinesOfTextGrp strm gg)
    grp.URLLink |> Option.iter (WriteURLLink strm)
    grp.RawDataLength |> Option.iter (WriteRawDataLength strm)
    grp.RawData |> Option.iter (WriteRawData strm)


let WriteEmail (strm:System.IO.Stream) (grp:Email) =
    WriteEmailThreadID strm grp.EmailThreadID
    WriteEmailType strm grp.EmailType
    grp.OrigTime |> Option.iter (WriteOrigTime strm)
    WriteSubject strm grp.Subject
    grp.EncodedSubject |> Option.iter (WriteEncodedSubject strm)
    grp.NoRoutingIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRoutingIDs strm (Fix44.Fields.NoRoutingIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoRoutingIDsGrp strm gg)    ) // end Option.iter
    grp.NoRelatedSymGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoRelatedSymGrp strm gg)    ) // end Option.iter
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.OrderID |> Option.iter (WriteOrderID strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    let numGrps = grp.LinesOfTextGrp.Length
    WriteLinesOfText strm (Fix44.Fields.LinesOfText numGrps) // write the 'num group repeats' field
    grp.LinesOfTextGrp |> List.iter (fun gg -> WriteLinesOfTextGrp strm gg)
    grp.RawDataLength |> Option.iter (WriteRawDataLength strm)
    grp.RawData |> Option.iter (WriteRawData strm)


let WriteQuoteRequest (strm:System.IO.Stream) (grp:QuoteRequest) =
    WriteQuoteReqID strm grp.QuoteReqID
    grp.RFQReqID |> Option.iter (WriteRFQReqID strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    let numGrps = grp.QuoteRequest_NoRelatedSymGrp.Length
    WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
    grp.QuoteRequest_NoRelatedSymGrp |> List.iter (fun gg -> WriteQuoteRequest_NoRelatedSymGrp strm gg)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteQuoteResponse (strm:System.IO.Stream) (grp:QuoteResponse) =
    WriteQuoteRespID strm grp.QuoteRespID
    grp.QuoteID |> Option.iter (WriteQuoteID strm)
    WriteQuoteRespType strm grp.QuoteRespType
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    grp.IOIid |> Option.iter (WriteIOIid strm)
    grp.QuoteType |> Option.iter (WriteQuoteType strm)
    grp.NoQuoteQualifiersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteQualifiers strm (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoQuoteQualifiersGrp strm gg)    ) // end Option.iter
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    WriteInstrument strm grp.Instrument    // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.Side |> Option.iter (WriteSide strm)
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
    grp.QuoteResponse_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteQuoteResponse_NoLegsGrp strm gg)    ) // end Option.iter
    grp.BidPx |> Option.iter (WriteBidPx strm)
    grp.OfferPx |> Option.iter (WriteOfferPx strm)
    grp.MktBidPx |> Option.iter (WriteMktBidPx strm)
    grp.MktOfferPx |> Option.iter (WriteMktOfferPx strm)
    grp.MinBidSize |> Option.iter (WriteMinBidSize strm)
    grp.BidSize |> Option.iter (WriteBidSize strm)
    grp.MinOfferSize |> Option.iter (WriteMinOfferSize strm)
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
    grp.OrdType |> Option.iter (WriteOrdType strm)
    grp.BidForwardPoints2 |> Option.iter (WriteBidForwardPoints2 strm)
    grp.OfferForwardPoints2 |> Option.iter (WriteOfferForwardPoints2 strm)
    grp.SettlCurrBidFxRate |> Option.iter (WriteSettlCurrBidFxRate strm)
    grp.SettlCurrOfferFxRate |> Option.iter (WriteSettlCurrOfferFxRate strm)
    grp.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    grp.Commission |> Option.iter (WriteCommission strm)
    grp.CommType |> Option.iter (WriteCommType strm)
    grp.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    grp.ExDestination |> Option.iter (WriteExDestination strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.YieldData |> Option.iter (WriteYieldData strm) // component


let WriteQuoteRequestReject (strm:System.IO.Stream) (grp:QuoteRequestReject) =
    WriteQuoteReqID strm grp.QuoteReqID
    grp.RFQReqID |> Option.iter (WriteRFQReqID strm)
    WriteQuoteRequestRejectReason strm grp.QuoteRequestRejectReason
    let numGrps = grp.QuoteRequestReject_NoRelatedSymGrp.Length
    WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
    grp.QuoteRequestReject_NoRelatedSymGrp |> List.iter (fun gg -> WriteQuoteRequestReject_NoRelatedSymGrp strm gg)
    grp.NoQuoteQualifiersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteQualifiers strm (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoQuoteQualifiersGrp strm gg)    ) // end Option.iter
    grp.QuotePriceType |> Option.iter (WriteQuotePriceType strm)
    grp.OrdType |> Option.iter (WriteOrdType strm)
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.Price2 |> Option.iter (WritePrice2 strm)
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteRFQRequest (strm:System.IO.Stream) (grp:RFQRequest) =
    WriteRFQReqID strm grp.RFQReqID
    let numGrps = grp.RFQRequest_NoRelatedSymGrp.Length
    WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
    grp.RFQRequest_NoRelatedSymGrp |> List.iter (fun gg -> WriteRFQRequest_NoRelatedSymGrp strm gg)
    grp.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)


let WriteQuote (strm:System.IO.Stream) (grp:Quote) =
    grp.QuoteReqID |> Option.iter (WriteQuoteReqID strm)
    WriteQuoteID strm grp.QuoteID
    grp.QuoteRespID |> Option.iter (WriteQuoteRespID strm)
    grp.QuoteType |> Option.iter (WriteQuoteType strm)
    grp.NoQuoteQualifiersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteQualifiers strm (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoQuoteQualifiersGrp strm gg)    ) // end Option.iter
    grp.QuoteResponseLevel |> Option.iter (WriteQuoteResponseLevel strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    WriteInstrument strm grp.Instrument    // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.Side |> Option.iter (WriteSide strm)
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
    grp.Quote_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteQuote_NoLegsGrp strm gg)    ) // end Option.iter
    grp.BidPx |> Option.iter (WriteBidPx strm)
    grp.OfferPx |> Option.iter (WriteOfferPx strm)
    grp.MktBidPx |> Option.iter (WriteMktBidPx strm)
    grp.MktOfferPx |> Option.iter (WriteMktOfferPx strm)
    grp.MinBidSize |> Option.iter (WriteMinBidSize strm)
    grp.BidSize |> Option.iter (WriteBidSize strm)
    grp.MinOfferSize |> Option.iter (WriteMinOfferSize strm)
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
    grp.OrdType |> Option.iter (WriteOrdType strm)
    grp.BidForwardPoints2 |> Option.iter (WriteBidForwardPoints2 strm)
    grp.OfferForwardPoints2 |> Option.iter (WriteOfferForwardPoints2 strm)
    grp.SettlCurrBidFxRate |> Option.iter (WriteSettlCurrBidFxRate strm)
    grp.SettlCurrOfferFxRate |> Option.iter (WriteSettlCurrOfferFxRate strm)
    grp.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    grp.CommType |> Option.iter (WriteCommType strm)
    grp.Commission |> Option.iter (WriteCommission strm)
    grp.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    grp.ExDestination |> Option.iter (WriteExDestination strm)
    grp.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteQuoteCancel (strm:System.IO.Stream) (grp:QuoteCancel) =
    grp.QuoteReqID |> Option.iter (WriteQuoteReqID strm)
    WriteQuoteID strm grp.QuoteID
    WriteQuoteCancelType strm grp.QuoteCancelType
    grp.QuoteResponseLevel |> Option.iter (WriteQuoteResponseLevel strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.NoQuoteEntriesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteEntries strm (Fix44.Fields.NoQuoteEntries numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoQuoteEntriesGrp strm gg)    ) // end Option.iter


let WriteQuoteStatusRequest (strm:System.IO.Stream) (grp:QuoteStatusRequest) =
    grp.QuoteStatusReqID |> Option.iter (WriteQuoteStatusReqID strm)
    grp.QuoteID |> Option.iter (WriteQuoteID strm)
    WriteInstrument strm grp.Instrument    // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)


let WriteQuoteStatusReport (strm:System.IO.Stream) (grp:QuoteStatusReport) =
    grp.QuoteStatusReqID |> Option.iter (WriteQuoteStatusReqID strm)
    grp.QuoteReqID |> Option.iter (WriteQuoteReqID strm)
    WriteQuoteID strm grp.QuoteID
    grp.QuoteRespID |> Option.iter (WriteQuoteRespID strm)
    grp.QuoteType |> Option.iter (WriteQuoteType strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    WriteInstrument strm grp.Instrument    // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.Side |> Option.iter (WriteSide strm)
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
    grp.QuoteStatusReport_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteQuoteStatusReport_NoLegsGrp strm gg)    ) // end Option.iter
    grp.NoQuoteQualifiersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteQualifiers strm (Fix44.Fields.NoQuoteQualifiers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoQuoteQualifiersGrp strm gg)    ) // end Option.iter
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    grp.BidPx |> Option.iter (WriteBidPx strm)
    grp.OfferPx |> Option.iter (WriteOfferPx strm)
    grp.MktBidPx |> Option.iter (WriteMktBidPx strm)
    grp.MktOfferPx |> Option.iter (WriteMktOfferPx strm)
    grp.MinBidSize |> Option.iter (WriteMinBidSize strm)
    grp.BidSize |> Option.iter (WriteBidSize strm)
    grp.MinOfferSize |> Option.iter (WriteMinOfferSize strm)
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
    grp.OrdType |> Option.iter (WriteOrdType strm)
    grp.BidForwardPoints2 |> Option.iter (WriteBidForwardPoints2 strm)
    grp.OfferForwardPoints2 |> Option.iter (WriteOfferForwardPoints2 strm)
    grp.SettlCurrBidFxRate |> Option.iter (WriteSettlCurrBidFxRate strm)
    grp.SettlCurrOfferFxRate |> Option.iter (WriteSettlCurrOfferFxRate strm)
    grp.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    grp.CommType |> Option.iter (WriteCommType strm)
    grp.Commission |> Option.iter (WriteCommission strm)
    grp.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    grp.ExDestination |> Option.iter (WriteExDestination strm)
    grp.QuoteStatus |> Option.iter (WriteQuoteStatus strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteMassQuote (strm:System.IO.Stream) (grp:MassQuote) =
    grp.QuoteReqID |> Option.iter (WriteQuoteReqID strm)
    WriteQuoteID strm grp.QuoteID
    grp.QuoteType |> Option.iter (WriteQuoteType strm)
    grp.QuoteResponseLevel |> Option.iter (WriteQuoteResponseLevel strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.DefBidSize |> Option.iter (WriteDefBidSize strm)
    grp.DefOfferSize |> Option.iter (WriteDefOfferSize strm)
    let numGrps = grp.NoQuoteSetsGrp.Length
    WriteNoQuoteSets strm (Fix44.Fields.NoQuoteSets numGrps) // write the 'num group repeats' field
    grp.NoQuoteSetsGrp |> List.iter (fun gg -> WriteNoQuoteSetsGrp strm gg)


let WriteMassQuoteAcknowledgement (strm:System.IO.Stream) (grp:MassQuoteAcknowledgement) =
    grp.QuoteReqID |> Option.iter (WriteQuoteReqID strm)
    grp.QuoteID |> Option.iter (WriteQuoteID strm)
    WriteQuoteStatus strm grp.QuoteStatus
    grp.QuoteRejectReason |> Option.iter (WriteQuoteRejectReason strm)
    grp.QuoteResponseLevel |> Option.iter (WriteQuoteResponseLevel strm)
    grp.QuoteType |> Option.iter (WriteQuoteType strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.MassQuoteAcknowledgement_NoQuoteSetsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoQuoteSets strm (Fix44.Fields.NoQuoteSets numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteMassQuoteAcknowledgement_NoQuoteSetsGrp strm gg)    ) // end Option.iter


let WriteMarketDataRequest (strm:System.IO.Stream) (grp:MarketDataRequest) =
    WriteMDReqID strm grp.MDReqID
    WriteSubscriptionRequestType strm grp.SubscriptionRequestType
    WriteMarketDepth strm grp.MarketDepth
    grp.MDUpdateType |> Option.iter (WriteMDUpdateType strm)
    grp.AggregatedBook |> Option.iter (WriteAggregatedBook strm)
    grp.OpenCloseSettlFlag |> Option.iter (WriteOpenCloseSettlFlag strm)
    grp.Scope |> Option.iter (WriteScope strm)
    grp.MDImplicitDelete |> Option.iter (WriteMDImplicitDelete strm)
    let numGrps = grp.NoMDEntryTypesGrp.Length
    WriteNoMDEntryTypes strm (Fix44.Fields.NoMDEntryTypes numGrps) // write the 'num group repeats' field
    grp.NoMDEntryTypesGrp |> List.iter (fun gg -> WriteNoMDEntryTypesGrp strm gg)
    let numGrps = grp.MarketDataRequest_NoRelatedSymGrp.Length
    WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
    grp.MarketDataRequest_NoRelatedSymGrp |> List.iter (fun gg -> WriteMarketDataRequest_NoRelatedSymGrp strm gg)
    grp.NoTradingSessionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTradingSessions strm (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradingSessionsGrp strm gg)    ) // end Option.iter
    grp.ApplQueueAction |> Option.iter (WriteApplQueueAction strm)
    grp.ApplQueueMax |> Option.iter (WriteApplQueueMax strm)


let WriteMarketDataSnapshotFullRefresh (strm:System.IO.Stream) (grp:MarketDataSnapshotFullRefresh) =
    grp.MDReqID |> Option.iter (WriteMDReqID strm)
    WriteInstrument strm grp.Instrument    // component
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
    grp.NetChgPrevDay |> Option.iter (WriteNetChgPrevDay strm)
    let numGrps = grp.NoMDEntriesGrp.Length
    WriteNoMDEntries strm (Fix44.Fields.NoMDEntries numGrps) // write the 'num group repeats' field
    grp.NoMDEntriesGrp |> List.iter (fun gg -> WriteNoMDEntriesGrp strm gg)
    grp.ApplQueueDepth |> Option.iter (WriteApplQueueDepth strm)
    grp.ApplQueueResolution |> Option.iter (WriteApplQueueResolution strm)


let WriteMarketDataIncrementalRefresh (strm:System.IO.Stream) (grp:MarketDataIncrementalRefresh) =
    grp.MDReqID |> Option.iter (WriteMDReqID strm)
    let numGrps = grp.MarketDataIncrementalRefresh_NoMDEntriesGrp.Length
    WriteNoMDEntries strm (Fix44.Fields.NoMDEntries numGrps) // write the 'num group repeats' field
    grp.MarketDataIncrementalRefresh_NoMDEntriesGrp |> List.iter (fun gg -> WriteMarketDataIncrementalRefresh_NoMDEntriesGrp strm gg)
    grp.ApplQueueDepth |> Option.iter (WriteApplQueueDepth strm)
    grp.ApplQueueResolution |> Option.iter (WriteApplQueueResolution strm)


let WriteMarketDataRequestReject (strm:System.IO.Stream) (grp:MarketDataRequestReject) =
    WriteMDReqID strm grp.MDReqID
    grp.MDReqRejReason |> Option.iter (WriteMDReqRejReason strm)
    grp.NoAltMDSourceGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAltMDSource strm (Fix44.Fields.NoAltMDSource numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoAltMDSourceGrp strm gg)    ) // end Option.iter
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteSecurityDefinitionRequest (strm:System.IO.Stream) (grp:SecurityDefinitionRequest) =
    WriteSecurityReqID strm grp.SecurityReqID
    WriteSecurityRequestType strm grp.SecurityRequestType
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.ExpirationCycle |> Option.iter (WriteExpirationCycle strm)
    grp.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)


let WriteSecurityDefinition (strm:System.IO.Stream) (grp:SecurityDefinition) =
    WriteSecurityReqID strm grp.SecurityReqID
    WriteSecurityResponseID strm grp.SecurityResponseID
    WriteSecurityResponseType strm grp.SecurityResponseType
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.ExpirationCycle |> Option.iter (WriteExpirationCycle strm)
    grp.RoundLot |> Option.iter (WriteRoundLot strm)
    grp.MinTradeVol |> Option.iter (WriteMinTradeVol strm)


let WriteSecurityTypeRequest (strm:System.IO.Stream) (grp:SecurityTypeRequest) =
    WriteSecurityReqID strm grp.SecurityReqID
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.Product |> Option.iter (WriteProduct strm)
    grp.SecurityType |> Option.iter (WriteSecurityType strm)
    grp.SecuritySubType |> Option.iter (WriteSecuritySubType strm)


let WriteSecurityTypes (strm:System.IO.Stream) (grp:SecurityTypes) =
    WriteSecurityReqID strm grp.SecurityReqID
    WriteSecurityResponseID strm grp.SecurityResponseID
    WriteSecurityResponseType strm grp.SecurityResponseType
    grp.TotNoSecurityTypes |> Option.iter (WriteTotNoSecurityTypes strm)
    grp.LastFragment |> Option.iter (WriteLastFragment strm)
    grp.NoSecurityTypesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoSecurityTypes strm (Fix44.Fields.NoSecurityTypes numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoSecurityTypesGrp strm gg)    ) // end Option.iter
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)


let WriteSecurityListRequest (strm:System.IO.Stream) (grp:SecurityListRequest) =
    WriteSecurityReqID strm grp.SecurityReqID
    WriteSecurityListRequestType strm grp.SecurityListRequestType
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)


let WriteSecurityList (strm:System.IO.Stream) (grp:SecurityList) =
    WriteSecurityReqID strm grp.SecurityReqID
    WriteSecurityResponseID strm grp.SecurityResponseID
    WriteSecurityRequestResult strm grp.SecurityRequestResult
    grp.TotNoRelatedSym |> Option.iter (WriteTotNoRelatedSym strm)
    grp.LastFragment |> Option.iter (WriteLastFragment strm)
    grp.SecurityList_NoRelatedSymGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteSecurityList_NoRelatedSymGrp strm gg)    ) // end Option.iter


let WriteDerivativeSecurityListRequest (strm:System.IO.Stream) (grp:DerivativeSecurityListRequest) =
    WriteSecurityReqID strm grp.SecurityReqID
    WriteSecurityListRequestType strm grp.SecurityListRequestType
    grp.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    grp.SecuritySubType |> Option.iter (WriteSecuritySubType strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)


let WriteDerivativeSecurityList (strm:System.IO.Stream) (grp:DerivativeSecurityList) =
    WriteSecurityReqID strm grp.SecurityReqID
    WriteSecurityResponseID strm grp.SecurityResponseID
    WriteSecurityRequestResult strm grp.SecurityRequestResult
    grp.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    grp.TotNoRelatedSym |> Option.iter (WriteTotNoRelatedSym strm)
    grp.LastFragment |> Option.iter (WriteLastFragment strm)
    grp.DerivativeSecurityList_NoRelatedSymGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRelatedSym strm (Fix44.Fields.NoRelatedSym numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteDerivativeSecurityList_NoRelatedSymGrp strm gg)    ) // end Option.iter


let WriteSecurityStatusRequest (strm:System.IO.Stream) (grp:SecurityStatusRequest) =
    WriteSecurityStatusReqID strm grp.SecurityStatusReqID
    WriteInstrument strm grp.Instrument    // component
    grp.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.Currency |> Option.iter (WriteCurrency strm)
    WriteSubscriptionRequestType strm grp.SubscriptionRequestType
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)


let WriteSecurityStatus (strm:System.IO.Stream) (grp:SecurityStatus) =
    grp.SecurityStatusReqID |> Option.iter (WriteSecurityStatusReqID strm)
    WriteInstrument strm grp.Instrument    // component
    grp.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.UnsolicitedIndicator |> Option.iter (WriteUnsolicitedIndicator strm)
    grp.SecurityTradingStatus |> Option.iter (WriteSecurityTradingStatus strm)
    grp.FinancialStatus |> Option.iter (WriteFinancialStatus strm)
    grp.CorporateAction |> Option.iter (WriteCorporateAction strm)
    grp.HaltReason |> Option.iter (WriteHaltReason strm)
    grp.InViewOfCommon |> Option.iter (WriteInViewOfCommon strm)
    grp.DueToRelated |> Option.iter (WriteDueToRelated strm)
    grp.BuyVolume |> Option.iter (WriteBuyVolume strm)
    grp.SellVolume |> Option.iter (WriteSellVolume strm)
    grp.HighPx |> Option.iter (WriteHighPx strm)
    grp.LowPx |> Option.iter (WriteLowPx strm)
    grp.LastPx |> Option.iter (WriteLastPx strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    grp.Adjustment |> Option.iter (WriteAdjustment strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteTradingSessionStatusRequest (strm:System.IO.Stream) (grp:TradingSessionStatusRequest) =
    WriteTradSesReqID strm grp.TradSesReqID
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.TradSesMethod |> Option.iter (WriteTradSesMethod strm)
    grp.TradSesMode |> Option.iter (WriteTradSesMode strm)
    WriteSubscriptionRequestType strm grp.SubscriptionRequestType


let WriteTradingSessionStatus (strm:System.IO.Stream) (grp:TradingSessionStatus) =
    grp.TradSesReqID |> Option.iter (WriteTradSesReqID strm)
    WriteTradingSessionID strm grp.TradingSessionID
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.TradSesMethod |> Option.iter (WriteTradSesMethod strm)
    grp.TradSesMode |> Option.iter (WriteTradSesMode strm)
    grp.UnsolicitedIndicator |> Option.iter (WriteUnsolicitedIndicator strm)
    WriteTradSesStatus strm grp.TradSesStatus
    grp.TradSesStatusRejReason |> Option.iter (WriteTradSesStatusRejReason strm)
    grp.TradSesStartTime |> Option.iter (WriteTradSesStartTime strm)
    grp.TradSesOpenTime |> Option.iter (WriteTradSesOpenTime strm)
    grp.TradSesPreCloseTime |> Option.iter (WriteTradSesPreCloseTime strm)
    grp.TradSesCloseTime |> Option.iter (WriteTradSesCloseTime strm)
    grp.TradSesEndTime |> Option.iter (WriteTradSesEndTime strm)
    grp.TotalVolumeTraded |> Option.iter (WriteTotalVolumeTraded strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteNewOrderSingle (strm:System.IO.Stream) (grp:NewOrderSingle) =
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
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    WriteSide strm grp.Side
    grp.LocateReqd |> Option.iter (WriteLocateReqd strm)
    WriteTransactTime strm grp.TransactTime
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm grp.OrderQtyData    // component
    WriteOrdType strm grp.OrdType
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
    grp.CancellationRights |> Option.iter (WriteCancellationRights strm)
    grp.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    grp.RegistID |> Option.iter (WriteRegistID strm)
    grp.Designation |> Option.iter (WriteDesignation strm)


let WriteExecutionReport (strm:System.IO.Stream) (grp:ExecutionReport) =
    WriteOrderID strm grp.OrderID
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.SecondaryExecID |> Option.iter (WriteSecondaryExecID strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.OrigClOrdID |> Option.iter (WriteOrigClOrdID strm)
    grp.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    grp.QuoteRespID |> Option.iter (WriteQuoteRespID strm)
    grp.OrdStatusReqID |> Option.iter (WriteOrdStatusReqID strm)
    grp.MassStatusReqID |> Option.iter (WriteMassStatusReqID strm)
    grp.TotNumReports |> Option.iter (WriteTotNumReports strm)
    grp.LastRptRequested |> Option.iter (WriteLastRptRequested strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.NoContraBrokersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoContraBrokers strm (Fix44.Fields.NoContraBrokers numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoContraBrokersGrp strm gg)    ) // end Option.iter
    grp.ListID |> Option.iter (WriteListID strm)
    grp.CrossID |> Option.iter (WriteCrossID strm)
    grp.OrigCrossID |> Option.iter (WriteOrigCrossID strm)
    grp.CrossType |> Option.iter (WriteCrossType strm)
    WriteExecID strm grp.ExecID
    grp.ExecRefID |> Option.iter (WriteExecRefID strm)
    WriteExecType strm grp.ExecType
    WriteOrdStatus strm grp.OrdStatus
    grp.WorkingIndicator |> Option.iter (WriteWorkingIndicator strm)
    grp.OrdRejReason |> Option.iter (WriteOrdRejReason strm)
    grp.ExecRestatementReason |> Option.iter (WriteExecRestatementReason strm)
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.DayBookingInst |> Option.iter (WriteDayBookingInst strm)
    grp.BookingUnit |> Option.iter (WriteBookingUnit strm)
    grp.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.CashMargin |> Option.iter (WriteCashMargin strm)
    grp.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    WriteInstrument strm grp.Instrument    // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteSide strm grp.Side
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.OrderQtyData |> Option.iter (WriteOrderQtyData strm) // component
    grp.OrdType |> Option.iter (WriteOrdType strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.StopPx |> Option.iter (WriteStopPx strm)
    grp.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    grp.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    grp.PeggedPrice |> Option.iter (WritePeggedPrice strm)
    grp.DiscretionPrice |> Option.iter (WriteDiscretionPrice strm)
    grp.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    grp.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    grp.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    grp.TargetStrategyPerformance |> Option.iter (WriteTargetStrategyPerformance strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.ComplianceID |> Option.iter (WriteComplianceID strm)
    grp.SolicitedFlag |> Option.iter (WriteSolicitedFlag strm)
    grp.TimeInForce |> Option.iter (WriteTimeInForce strm)
    grp.EffectiveTime |> Option.iter (WriteEffectiveTime strm)
    grp.ExpireDate |> Option.iter (WriteExpireDate strm)
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.ExecInst |> Option.iter (WriteExecInst strm)
    grp.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    grp.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    grp.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    grp.LastQty |> Option.iter (WriteLastQty strm)
    grp.UnderlyingLastQty |> Option.iter (WriteUnderlyingLastQty strm)
    grp.LastPx |> Option.iter (WriteLastPx strm)
    grp.UnderlyingLastPx |> Option.iter (WriteUnderlyingLastPx strm)
    grp.LastParPx |> Option.iter (WriteLastParPx strm)
    grp.LastSpotRate |> Option.iter (WriteLastSpotRate strm)
    grp.LastForwardPoints |> Option.iter (WriteLastForwardPoints strm)
    grp.LastMkt |> Option.iter (WriteLastMkt strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.TimeBracket |> Option.iter (WriteTimeBracket strm)
    grp.LastCapacity |> Option.iter (WriteLastCapacity strm)
    WriteLeavesQty strm grp.LeavesQty
    WriteCumQty strm grp.CumQty
    WriteAvgPx strm grp.AvgPx
    grp.DayOrderQty |> Option.iter (WriteDayOrderQty strm)
    grp.DayCumQty |> Option.iter (WriteDayCumQty strm)
    grp.DayAvgPx |> Option.iter (WriteDayAvgPx strm)
    grp.GTBookingInst |> Option.iter (WriteGTBookingInst strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    grp.ReportToExch |> Option.iter (WriteReportToExch strm)
    grp.CommissionData |> Option.iter (WriteCommissionData strm) // component
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    grp.GrossTradeAmt |> Option.iter (WriteGrossTradeAmt strm)
    grp.NumDaysInterest |> Option.iter (WriteNumDaysInterest strm)
    grp.ExDate |> Option.iter (WriteExDate strm)
    grp.AccruedInterestRate |> Option.iter (WriteAccruedInterestRate strm)
    grp.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    grp.InterestAtMaturity |> Option.iter (WriteInterestAtMaturity strm)
    grp.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    grp.StartCash |> Option.iter (WriteStartCash strm)
    grp.EndCash |> Option.iter (WriteEndCash strm)
    grp.TradedFlatSwitch |> Option.iter (WriteTradedFlatSwitch strm)
    grp.BasisFeatureDate |> Option.iter (WriteBasisFeatureDate strm)
    grp.BasisFeaturePrice |> Option.iter (WriteBasisFeaturePrice strm)
    grp.Concession |> Option.iter (WriteConcession strm)
    grp.TotalTakedown |> Option.iter (WriteTotalTakedown strm)
    grp.NetMoney |> Option.iter (WriteNetMoney strm)
    grp.SettlCurrAmt |> Option.iter (WriteSettlCurrAmt strm)
    grp.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    grp.SettlCurrFxRate |> Option.iter (WriteSettlCurrFxRate strm)
    grp.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    grp.HandlInst |> Option.iter (WriteHandlInst strm)
    grp.MinQty |> Option.iter (WriteMinQty strm)
    grp.MaxFloor |> Option.iter (WriteMaxFloor strm)
    grp.PositionEffect |> Option.iter (WritePositionEffect strm)
    grp.MaxShow |> Option.iter (WriteMaxShow strm)
    grp.BookingType |> Option.iter (WriteBookingType strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.SettlDate2 |> Option.iter (WriteSettlDate2 strm)
    grp.OrderQty2 |> Option.iter (WriteOrderQty2 strm)
    grp.LastForwardPoints2 |> Option.iter (WriteLastForwardPoints2 strm)
    grp.MultiLegReportingType |> Option.iter (WriteMultiLegReportingType strm)
    grp.CancellationRights |> Option.iter (WriteCancellationRights strm)
    grp.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    grp.RegistID |> Option.iter (WriteRegistID strm)
    grp.Designation |> Option.iter (WriteDesignation strm)
    grp.TransBkdTime |> Option.iter (WriteTransBkdTime strm)
    grp.ExecValuationPoint |> Option.iter (WriteExecValuationPoint strm)
    grp.ExecPriceType |> Option.iter (WriteExecPriceType strm)
    grp.ExecPriceAdjustment |> Option.iter (WriteExecPriceAdjustment strm)
    grp.PriorityIndicator |> Option.iter (WritePriorityIndicator strm)
    grp.PriceImprovement |> Option.iter (WritePriceImprovement strm)
    grp.LastLiquidityInd |> Option.iter (WriteLastLiquidityInd strm)
    grp.NoContAmtsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoContAmts strm (Fix44.Fields.NoContAmts numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoContAmtsGrp strm gg)    ) // end Option.iter
    grp.ExecutionReport_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteExecutionReport_NoLegsGrp strm gg)    ) // end Option.iter
    grp.CopyMsgIndicator |> Option.iter (WriteCopyMsgIndicator strm)
    grp.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter


let WriteDontKnowTrade (strm:System.IO.Stream) (grp:DontKnowTrade) =
    WriteOrderID strm grp.OrderID
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    WriteExecID strm grp.ExecID
    WriteDKReason strm grp.DKReason
    WriteInstrument strm grp.Instrument    // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    WriteSide strm grp.Side
    WriteOrderQtyData strm grp.OrderQtyData    // component
    grp.LastQty |> Option.iter (WriteLastQty strm)
    grp.LastPx |> Option.iter (WriteLastPx strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteOrderCancelReplaceRequest (strm:System.IO.Stream) (grp:OrderCancelReplaceRequest) =
    grp.OrderID |> Option.iter (WriteOrderID strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    WriteOrigClOrdID strm grp.OrigClOrdID
    WriteClOrdID strm grp.ClOrdID
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    grp.ListID |> Option.iter (WriteListID strm)
    grp.OrigOrdModTime |> Option.iter (WriteOrigOrdModTime strm)
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
    WriteInstrument strm grp.Instrument    // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteSide strm grp.Side
    WriteTransactTime strm grp.TransactTime
    grp.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm grp.OrderQtyData    // component
    WriteOrdType strm grp.OrdType
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.StopPx |> Option.iter (WriteStopPx strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    grp.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    grp.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    grp.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    grp.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    grp.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    grp.ComplianceID |> Option.iter (WriteComplianceID strm)
    grp.SolicitedFlag |> Option.iter (WriteSolicitedFlag strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
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
    grp.LocateReqd |> Option.iter (WriteLocateReqd strm)
    grp.CancellationRights |> Option.iter (WriteCancellationRights strm)
    grp.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    grp.RegistID |> Option.iter (WriteRegistID strm)
    grp.Designation |> Option.iter (WriteDesignation strm)


let WriteOrderCancelRequest (strm:System.IO.Stream) (grp:OrderCancelRequest) =
    WriteOrigClOrdID strm grp.OrigClOrdID
    grp.OrderID |> Option.iter (WriteOrderID strm)
    WriteClOrdID strm grp.ClOrdID
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    grp.ListID |> Option.iter (WriteListID strm)
    grp.OrigOrdModTime |> Option.iter (WriteOrigOrdModTime strm)
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    WriteInstrument strm grp.Instrument    // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteSide strm grp.Side
    WriteTransactTime strm grp.TransactTime
    WriteOrderQtyData strm grp.OrderQtyData    // component
    grp.ComplianceID |> Option.iter (WriteComplianceID strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteOrderCancelReject (strm:System.IO.Stream) (grp:OrderCancelReject) =
    WriteOrderID strm grp.OrderID
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    WriteClOrdID strm grp.ClOrdID
    grp.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    WriteOrigClOrdID strm grp.OrigClOrdID
    WriteOrdStatus strm grp.OrdStatus
    grp.WorkingIndicator |> Option.iter (WriteWorkingIndicator strm)
    grp.OrigOrdModTime |> Option.iter (WriteOrigOrdModTime strm)
    grp.ListID |> Option.iter (WriteListID strm)
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    WriteCxlRejResponseTo strm grp.CxlRejResponseTo
    grp.CxlRejReason |> Option.iter (WriteCxlRejReason strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteOrderStatusRequest (strm:System.IO.Stream) (grp:OrderStatusRequest) =
    grp.OrderID |> Option.iter (WriteOrderID strm)
    WriteClOrdID strm grp.ClOrdID
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.ClOrdLinkID |> Option.iter (WriteClOrdLinkID strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.OrdStatusReqID |> Option.iter (WriteOrdStatusReqID strm)
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteInstrument strm grp.Instrument    // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteSide strm grp.Side


let WriteOrderMassCancelRequest (strm:System.IO.Stream) (grp:OrderMassCancelRequest) =
    WriteClOrdID strm grp.ClOrdID
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    WriteMassCancelRequestType strm grp.MassCancelRequestType
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    grp.Side |> Option.iter (WriteSide strm)
    WriteTransactTime strm grp.TransactTime
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteOrderMassCancelReport (strm:System.IO.Stream) (grp:OrderMassCancelReport) =
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    WriteOrderID strm grp.OrderID
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    WriteMassCancelRequestType strm grp.MassCancelRequestType
    WriteMassCancelResponse strm grp.MassCancelResponse
    grp.MassCancelRejectReason |> Option.iter (WriteMassCancelRejectReason strm)
    grp.TotalAffectedOrders |> Option.iter (WriteTotalAffectedOrders strm)
    grp.NoAffectedOrdersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAffectedOrders strm (Fix44.Fields.NoAffectedOrders numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoAffectedOrdersGrp strm gg)    ) // end Option.iter
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    grp.Side |> Option.iter (WriteSide strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteOrderMassStatusRequest (strm:System.IO.Stream) (grp:OrderMassStatusRequest) =
    WriteMassStatusReqID strm grp.MassStatusReqID
    WriteMassStatusReqType strm grp.MassStatusReqType
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.UnderlyingInstrument |> Option.iter (WriteUnderlyingInstrument strm) // component
    grp.Side |> Option.iter (WriteSide strm)


let WriteNewOrderCross (strm:System.IO.Stream) (grp:NewOrderCross) =
    WriteCrossID strm grp.CrossID
    WriteCrossType strm grp.CrossType
    WriteCrossPrioritization strm grp.CrossPrioritization
    let noSidesField =  // ####
        match grp.NoSidesGrp with
        | OneOrTwo.One _ -> NoSides.OneSide
        | OneOrTwo.Two _ -> NoSides.BothSides
    WriteNoSides strm noSidesField
    grp.NoSidesGrp |> OneOrTwo.iter (WriteNoSidesGrp strm)   // group
    WriteInstrument strm grp.Instrument    // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
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
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    grp.LocateReqd |> Option.iter (WriteLocateReqd strm)
    WriteTransactTime strm grp.TransactTime
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    WriteOrdType strm grp.OrdType
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.StopPx |> Option.iter (WriteStopPx strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.ComplianceID |> Option.iter (WriteComplianceID strm)
    grp.IOIid |> Option.iter (WriteIOIid strm)
    grp.QuoteID |> Option.iter (WriteQuoteID strm)
    grp.TimeInForce |> Option.iter (WriteTimeInForce strm)
    grp.EffectiveTime |> Option.iter (WriteEffectiveTime strm)
    grp.ExpireDate |> Option.iter (WriteExpireDate strm)
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.GTBookingInst |> Option.iter (WriteGTBookingInst strm)
    grp.MaxShow |> Option.iter (WriteMaxShow strm)
    grp.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    grp.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    grp.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    grp.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    grp.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    grp.CancellationRights |> Option.iter (WriteCancellationRights strm)
    grp.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    grp.RegistID |> Option.iter (WriteRegistID strm)
    grp.Designation |> Option.iter (WriteDesignation strm)


let WriteCrossOrderCancelReplaceRequest (strm:System.IO.Stream) (grp:CrossOrderCancelReplaceRequest) =
    grp.OrderID |> Option.iter (WriteOrderID strm)
    WriteCrossID strm grp.CrossID
    WriteOrigCrossID strm grp.OrigCrossID
    WriteCrossType strm grp.CrossType
    WriteCrossPrioritization strm grp.CrossPrioritization
    let noSidesField =  // ####
        match grp.CrossOrderCancelReplaceRequest_NoSidesGrp with
        | OneOrTwo.One _ -> NoSides.OneSide
        | OneOrTwo.Two _ -> NoSides.BothSides
    WriteNoSides strm noSidesField
    grp.CrossOrderCancelReplaceRequest_NoSidesGrp |> OneOrTwo.iter (WriteCrossOrderCancelReplaceRequest_NoSidesGrp strm)   // group
    WriteInstrument strm grp.Instrument    // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
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
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    grp.LocateReqd |> Option.iter (WriteLocateReqd strm)
    WriteTransactTime strm grp.TransactTime
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    WriteOrdType strm grp.OrdType
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.StopPx |> Option.iter (WriteStopPx strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.ComplianceID |> Option.iter (WriteComplianceID strm)
    grp.IOIid |> Option.iter (WriteIOIid strm)
    grp.QuoteID |> Option.iter (WriteQuoteID strm)
    grp.TimeInForce |> Option.iter (WriteTimeInForce strm)
    grp.EffectiveTime |> Option.iter (WriteEffectiveTime strm)
    grp.ExpireDate |> Option.iter (WriteExpireDate strm)
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.GTBookingInst |> Option.iter (WriteGTBookingInst strm)
    grp.MaxShow |> Option.iter (WriteMaxShow strm)
    grp.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    grp.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    grp.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    grp.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    grp.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    grp.CancellationRights |> Option.iter (WriteCancellationRights strm)
    grp.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    grp.RegistID |> Option.iter (WriteRegistID strm)
    grp.Designation |> Option.iter (WriteDesignation strm)


let WriteCrossOrderCancelRequest (strm:System.IO.Stream) (grp:CrossOrderCancelRequest) =
    grp.OrderID |> Option.iter (WriteOrderID strm)
    WriteCrossID strm grp.CrossID
    WriteOrigCrossID strm grp.OrigCrossID
    WriteCrossType strm grp.CrossType
    WriteCrossPrioritization strm grp.CrossPrioritization
    let noSidesField =  // ####
        match grp.CrossOrderCancelRequest_NoSidesGrp with
        | OneOrTwo.One _ -> NoSides.OneSide
        | OneOrTwo.Two _ -> NoSides.BothSides
    WriteNoSides strm noSidesField
    grp.CrossOrderCancelRequest_NoSidesGrp |> OneOrTwo.iter (WriteCrossOrderCancelRequest_NoSidesGrp strm)   // group
    WriteInstrument strm grp.Instrument    // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    WriteTransactTime strm grp.TransactTime


let WriteNewOrderMultileg (strm:System.IO.Stream) (grp:NewOrderMultileg) =
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
    grp.NewOrderMultileg_NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNewOrderMultileg_NoAllocsGrp strm gg)    ) // end Option.iter
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
    WriteSide strm grp.Side
    WriteInstrument strm grp.Instrument    // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    let numGrps = grp.NewOrderMultileg_NoLegsGrp.Length
    WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
    grp.NewOrderMultileg_NoLegsGrp |> List.iter (fun gg -> WriteNewOrderMultileg_NoLegsGrp strm gg)
    grp.LocateReqd |> Option.iter (WriteLocateReqd strm)
    WriteTransactTime strm grp.TransactTime
    grp.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm grp.OrderQtyData    // component
    WriteOrdType strm grp.OrdType
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.StopPx |> Option.iter (WriteStopPx strm)
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
    grp.PositionEffect |> Option.iter (WritePositionEffect strm)
    grp.CoveredOrUncovered |> Option.iter (WriteCoveredOrUncovered strm)
    grp.MaxShow |> Option.iter (WriteMaxShow strm)
    grp.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    grp.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    grp.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    grp.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    grp.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    grp.CancellationRights |> Option.iter (WriteCancellationRights strm)
    grp.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    grp.RegistID |> Option.iter (WriteRegistID strm)
    grp.Designation |> Option.iter (WriteDesignation strm)
    grp.MultiLegRptTypeReq |> Option.iter (WriteMultiLegRptTypeReq strm)


let WriteMultilegOrderCancelReplaceRequest (strm:System.IO.Stream) (grp:MultilegOrderCancelReplaceRequest) =
    grp.OrderID |> Option.iter (WriteOrderID strm)
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
    grp.MultilegOrderCancelReplaceRequest_NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteMultilegOrderCancelReplaceRequest_NoAllocsGrp strm gg)    ) // end Option.iter
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
    WriteSide strm grp.Side
    WriteInstrument strm grp.Instrument    // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.PrevClosePx |> Option.iter (WritePrevClosePx strm)
    let numGrps = grp.MultilegOrderCancelReplaceRequest_NoLegsGrp.Length
    WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
    grp.MultilegOrderCancelReplaceRequest_NoLegsGrp |> List.iter (fun gg -> WriteMultilegOrderCancelReplaceRequest_NoLegsGrp strm gg)
    grp.LocateReqd |> Option.iter (WriteLocateReqd strm)
    WriteTransactTime strm grp.TransactTime
    grp.QtyType |> Option.iter (WriteQtyType strm)
    WriteOrderQtyData strm grp.OrderQtyData    // component
    WriteOrdType strm grp.OrdType
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.StopPx |> Option.iter (WriteStopPx strm)
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
    grp.PositionEffect |> Option.iter (WritePositionEffect strm)
    grp.CoveredOrUncovered |> Option.iter (WriteCoveredOrUncovered strm)
    grp.MaxShow |> Option.iter (WriteMaxShow strm)
    grp.PegInstructions |> Option.iter (WritePegInstructions strm) // component
    grp.DiscretionInstructions |> Option.iter (WriteDiscretionInstructions strm) // component
    grp.TargetStrategy |> Option.iter (WriteTargetStrategy strm)
    grp.TargetStrategyParameters |> Option.iter (WriteTargetStrategyParameters strm)
    grp.ParticipationRate |> Option.iter (WriteParticipationRate strm)
    grp.CancellationRights |> Option.iter (WriteCancellationRights strm)
    grp.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    grp.RegistID |> Option.iter (WriteRegistID strm)
    grp.Designation |> Option.iter (WriteDesignation strm)
    grp.MultiLegRptTypeReq |> Option.iter (WriteMultiLegRptTypeReq strm)


let WriteBidRequest (strm:System.IO.Stream) (grp:BidRequest) =
    grp.BidID |> Option.iter (WriteBidID strm)
    WriteClientBidID strm grp.ClientBidID
    WriteBidRequestTransType strm grp.BidRequestTransType
    grp.ListName |> Option.iter (WriteListName strm)
    WriteTotNoRelatedSym strm grp.TotNoRelatedSym
    WriteBidType strm grp.BidType
    grp.NumTickets |> Option.iter (WriteNumTickets strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.SideValue1 |> Option.iter (WriteSideValue1 strm)
    grp.SideValue2 |> Option.iter (WriteSideValue2 strm)
    grp.NoBidDescriptorsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoBidDescriptors strm (Fix44.Fields.NoBidDescriptors numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoBidDescriptorsGrp strm gg)    ) // end Option.iter
    grp.NoBidComponentsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoBidComponents strm (Fix44.Fields.NoBidComponents numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoBidComponentsGrp strm gg)    ) // end Option.iter
    grp.LiquidityIndType |> Option.iter (WriteLiquidityIndType strm)
    grp.WtAverageLiquidity |> Option.iter (WriteWtAverageLiquidity strm)
    grp.ExchangeForPhysical |> Option.iter (WriteExchangeForPhysical strm)
    grp.OutMainCntryUIndex |> Option.iter (WriteOutMainCntryUIndex strm)
    grp.CrossPercent |> Option.iter (WriteCrossPercent strm)
    grp.ProgRptReqs |> Option.iter (WriteProgRptReqs strm)
    grp.ProgPeriodInterval |> Option.iter (WriteProgPeriodInterval strm)
    grp.IncTaxInd |> Option.iter (WriteIncTaxInd strm)
    grp.ForexReq |> Option.iter (WriteForexReq strm)
    grp.NumBidders |> Option.iter (WriteNumBidders strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    WriteBidTradeType strm grp.BidTradeType
    WriteBasisPxType strm grp.BasisPxType
    grp.StrikeTime |> Option.iter (WriteStrikeTime strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteBidResponse (strm:System.IO.Stream) (grp:BidResponse) =
    grp.BidID |> Option.iter (WriteBidID strm)
    grp.ClientBidID |> Option.iter (WriteClientBidID strm)
    let numGrps = grp.BidResponse_NoBidComponentsGrp.Length
    WriteNoBidComponents strm (Fix44.Fields.NoBidComponents numGrps) // write the 'num group repeats' field
    grp.BidResponse_NoBidComponentsGrp |> List.iter (fun gg -> WriteBidResponse_NoBidComponentsGrp strm gg)


let WriteNewOrderList (strm:System.IO.Stream) (grp:NewOrderList) =
    WriteListID strm grp.ListID
    grp.BidID |> Option.iter (WriteBidID strm)
    grp.ClientBidID |> Option.iter (WriteClientBidID strm)
    grp.ProgRptReqs |> Option.iter (WriteProgRptReqs strm)
    WriteBidType strm grp.BidType
    grp.ProgPeriodInterval |> Option.iter (WriteProgPeriodInterval strm)
    grp.CancellationRights |> Option.iter (WriteCancellationRights strm)
    grp.MoneyLaunderingStatus |> Option.iter (WriteMoneyLaunderingStatus strm)
    grp.RegistID |> Option.iter (WriteRegistID strm)
    grp.ListExecInstType |> Option.iter (WriteListExecInstType strm)
    grp.ListExecInst |> Option.iter (WriteListExecInst strm)
    grp.EncodedListExecInst |> Option.iter (WriteEncodedListExecInst strm)
    grp.AllowableOneSidednessPct |> Option.iter (WriteAllowableOneSidednessPct strm)
    grp.AllowableOneSidednessValue |> Option.iter (WriteAllowableOneSidednessValue strm)
    grp.AllowableOneSidednessCurr |> Option.iter (WriteAllowableOneSidednessCurr strm)
    WriteTotNoOrders strm grp.TotNoOrders
    grp.LastFragment |> Option.iter (WriteLastFragment strm)
    let numGrps = grp.NewOrderList_NoOrdersGrp.Length
    WriteNoOrders strm (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
    grp.NewOrderList_NoOrdersGrp |> List.iter (fun gg -> WriteNewOrderList_NoOrdersGrp strm gg)


let WriteListStrikePrice (strm:System.IO.Stream) (grp:ListStrikePrice) =
    WriteListID strm grp.ListID
    WriteTotNoStrikes strm grp.TotNoStrikes
    grp.LastFragment |> Option.iter (WriteLastFragment strm)
    let numGrps = grp.NoStrikesGrp.Length
    WriteNoStrikes strm (Fix44.Fields.NoStrikes numGrps) // write the 'num group repeats' field
    grp.NoStrikesGrp |> List.iter (fun gg -> WriteNoStrikesGrp strm gg)
    grp.ListStrikePrice_NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteListStrikePrice_NoUnderlyingsGrp strm gg)    ) // end Option.iter


let WriteListStatus (strm:System.IO.Stream) (grp:ListStatus) =
    WriteListID strm grp.ListID
    WriteListStatusType strm grp.ListStatusType
    WriteNoRpts strm grp.NoRpts
    WriteListOrderStatus strm grp.ListOrderStatus
    WriteRptSeq strm grp.RptSeq
    grp.ListStatusText |> Option.iter (WriteListStatusText strm)
    grp.EncodedListStatusText |> Option.iter (WriteEncodedListStatusText strm)
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    WriteTotNoOrders strm grp.TotNoOrders
    grp.LastFragment |> Option.iter (WriteLastFragment strm)
    let numGrps = grp.ListStatus_NoOrdersGrp.Length
    WriteNoOrders strm (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
    grp.ListStatus_NoOrdersGrp |> List.iter (fun gg -> WriteListStatus_NoOrdersGrp strm gg)


let WriteListExecute (strm:System.IO.Stream) (grp:ListExecute) =
    WriteListID strm grp.ListID
    grp.ClientBidID |> Option.iter (WriteClientBidID strm)
    grp.BidID |> Option.iter (WriteBidID strm)
    WriteTransactTime strm grp.TransactTime
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteListCancelRequest (strm:System.IO.Stream) (grp:ListCancelRequest) =
    WriteListID strm grp.ListID
    WriteTransactTime strm grp.TransactTime
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteListStatusRequest (strm:System.IO.Stream) (grp:ListStatusRequest) =
    WriteListID strm grp.ListID
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteAllocationInstruction (strm:System.IO.Stream) (grp:AllocationInstruction) =
    WriteAllocID strm grp.AllocID
    WriteAllocTransType strm grp.AllocTransType
    WriteAllocType strm grp.AllocType
    grp.SecondaryAllocID |> Option.iter (WriteSecondaryAllocID strm)
    grp.RefAllocID |> Option.iter (WriteRefAllocID strm)
    grp.AllocCancReplaceReason |> Option.iter (WriteAllocCancReplaceReason strm)
    grp.AllocIntermedReqType |> Option.iter (WriteAllocIntermedReqType strm)
    grp.AllocLinkID |> Option.iter (WriteAllocLinkID strm)
    grp.AllocLinkType |> Option.iter (WriteAllocLinkType strm)
    grp.BookingRefID |> Option.iter (WriteBookingRefID strm)
    WriteAllocNoOrdersType strm grp.AllocNoOrdersType
    grp.NoOrdersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoOrders strm (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoOrdersGrp strm gg)    ) // end Option.iter
    grp.AllocationInstruction_NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteAllocationInstruction_NoExecsGrp strm gg)    ) // end Option.iter
    grp.PreviouslyReported |> Option.iter (WritePreviouslyReported strm)
    grp.ReversalIndicator |> Option.iter (WriteReversalIndicator strm)
    grp.MatchType |> Option.iter (WriteMatchType strm)
    WriteSide strm grp.Side
    WriteInstrument strm grp.Instrument    // component
    grp.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    WriteQuantity strm grp.Quantity
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.LastMkt |> Option.iter (WriteLastMkt strm)
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    WriteAvgPx strm grp.AvgPx
    grp.AvgParPx |> Option.iter (WriteAvgParPx strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.AvgPxPrecision |> Option.iter (WriteAvgPxPrecision strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    WriteTradeDate strm grp.TradeDate
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.BookingType |> Option.iter (WriteBookingType strm)
    grp.GrossTradeAmt |> Option.iter (WriteGrossTradeAmt strm)
    grp.Concession |> Option.iter (WriteConcession strm)
    grp.TotalTakedown |> Option.iter (WriteTotalTakedown strm)
    grp.NetMoney |> Option.iter (WriteNetMoney strm)
    grp.PositionEffect |> Option.iter (WritePositionEffect strm)
    grp.AutoAcceptIndicator |> Option.iter (WriteAutoAcceptIndicator strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.NumDaysInterest |> Option.iter (WriteNumDaysInterest strm)
    grp.AccruedInterestRate |> Option.iter (WriteAccruedInterestRate strm)
    grp.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    grp.TotalAccruedInterestAmt |> Option.iter (WriteTotalAccruedInterestAmt strm)
    grp.InterestAtMaturity |> Option.iter (WriteInterestAtMaturity strm)
    grp.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    grp.StartCash |> Option.iter (WriteStartCash strm)
    grp.EndCash |> Option.iter (WriteEndCash strm)
    grp.LegalConfirm |> Option.iter (WriteLegalConfirm strm)
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    grp.TotNoAllocs |> Option.iter (WriteTotNoAllocs strm)
    grp.LastFragment |> Option.iter (WriteLastFragment strm)
    grp.AllocationInstruction_NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteAllocationInstruction_NoAllocsGrp strm gg)    ) // end Option.iter


let WriteAllocationInstructionAck (strm:System.IO.Stream) (grp:AllocationInstructionAck) =
    WriteAllocID strm grp.AllocID
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.SecondaryAllocID |> Option.iter (WriteSecondaryAllocID strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    WriteTransactTime strm grp.TransactTime
    WriteAllocStatus strm grp.AllocStatus
    grp.AllocRejCode |> Option.iter (WriteAllocRejCode strm)
    grp.AllocType |> Option.iter (WriteAllocType strm)
    grp.AllocIntermedReqType |> Option.iter (WriteAllocIntermedReqType strm)
    grp.MatchStatus |> Option.iter (WriteMatchStatus strm)
    grp.Product |> Option.iter (WriteProduct strm)
    grp.SecurityType |> Option.iter (WriteSecurityType strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.AllocationInstructionAck_NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteAllocationInstructionAck_NoAllocsGrp strm gg)    ) // end Option.iter


let WriteAllocationReport (strm:System.IO.Stream) (grp:AllocationReport) =
    WriteAllocReportID strm grp.AllocReportID
    grp.AllocID |> Option.iter (WriteAllocID strm)
    WriteAllocTransType strm grp.AllocTransType
    grp.AllocReportRefID |> Option.iter (WriteAllocReportRefID strm)
    grp.AllocCancReplaceReason |> Option.iter (WriteAllocCancReplaceReason strm)
    grp.SecondaryAllocID |> Option.iter (WriteSecondaryAllocID strm)
    WriteAllocReportType strm grp.AllocReportType
    WriteAllocStatus strm grp.AllocStatus
    grp.AllocRejCode |> Option.iter (WriteAllocRejCode strm)
    grp.RefAllocID |> Option.iter (WriteRefAllocID strm)
    grp.AllocIntermedReqType |> Option.iter (WriteAllocIntermedReqType strm)
    grp.AllocLinkID |> Option.iter (WriteAllocLinkID strm)
    grp.AllocLinkType |> Option.iter (WriteAllocLinkType strm)
    grp.BookingRefID |> Option.iter (WriteBookingRefID strm)
    WriteAllocNoOrdersType strm grp.AllocNoOrdersType
    grp.NoOrdersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoOrders strm (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoOrdersGrp strm gg)    ) // end Option.iter
    grp.AllocationReport_NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteAllocationReport_NoExecsGrp strm gg)    ) // end Option.iter
    grp.PreviouslyReported |> Option.iter (WritePreviouslyReported strm)
    grp.ReversalIndicator |> Option.iter (WriteReversalIndicator strm)
    grp.MatchType |> Option.iter (WriteMatchType strm)
    WriteSide strm grp.Side
    WriteInstrument strm grp.Instrument    // component
    grp.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    WriteQuantity strm grp.Quantity
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.LastMkt |> Option.iter (WriteLastMkt strm)
    grp.TradeOriginationDate |> Option.iter (WriteTradeOriginationDate strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    WriteAvgPx strm grp.AvgPx
    grp.AvgParPx |> Option.iter (WriteAvgParPx strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.AvgPxPrecision |> Option.iter (WriteAvgPxPrecision strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    WriteTradeDate strm grp.TradeDate
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.BookingType |> Option.iter (WriteBookingType strm)
    grp.GrossTradeAmt |> Option.iter (WriteGrossTradeAmt strm)
    grp.Concession |> Option.iter (WriteConcession strm)
    grp.TotalTakedown |> Option.iter (WriteTotalTakedown strm)
    grp.NetMoney |> Option.iter (WriteNetMoney strm)
    grp.PositionEffect |> Option.iter (WritePositionEffect strm)
    grp.AutoAcceptIndicator |> Option.iter (WriteAutoAcceptIndicator strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.NumDaysInterest |> Option.iter (WriteNumDaysInterest strm)
    grp.AccruedInterestRate |> Option.iter (WriteAccruedInterestRate strm)
    grp.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    grp.TotalAccruedInterestAmt |> Option.iter (WriteTotalAccruedInterestAmt strm)
    grp.InterestAtMaturity |> Option.iter (WriteInterestAtMaturity strm)
    grp.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    grp.StartCash |> Option.iter (WriteStartCash strm)
    grp.EndCash |> Option.iter (WriteEndCash strm)
    grp.LegalConfirm |> Option.iter (WriteLegalConfirm strm)
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    grp.TotNoAllocs |> Option.iter (WriteTotNoAllocs strm)
    grp.LastFragment |> Option.iter (WriteLastFragment strm)
    let numGrps = grp.AllocationReport_NoAllocsGrp.Length
    WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
    grp.AllocationReport_NoAllocsGrp |> List.iter (fun gg -> WriteAllocationReport_NoAllocsGrp strm gg)


let WriteAllocationReportAck (strm:System.IO.Stream) (grp:AllocationReportAck) =
    WriteAllocReportID strm grp.AllocReportID
    WriteAllocID strm grp.AllocID
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.SecondaryAllocID |> Option.iter (WriteSecondaryAllocID strm)
    grp.TradeDate |> Option.iter (WriteTradeDate strm)
    WriteTransactTime strm grp.TransactTime
    WriteAllocStatus strm grp.AllocStatus
    grp.AllocRejCode |> Option.iter (WriteAllocRejCode strm)
    grp.AllocReportType |> Option.iter (WriteAllocReportType strm)
    grp.AllocIntermedReqType |> Option.iter (WriteAllocIntermedReqType strm)
    grp.MatchStatus |> Option.iter (WriteMatchStatus strm)
    grp.Product |> Option.iter (WriteProduct strm)
    grp.SecurityType |> Option.iter (WriteSecurityType strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.AllocationReportAck_NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteAllocationReportAck_NoAllocsGrp strm gg)    ) // end Option.iter


let WriteConfirmation (strm:System.IO.Stream) (grp:Confirmation) =
    WriteConfirmID strm grp.ConfirmID
    grp.ConfirmRefID |> Option.iter (WriteConfirmRefID strm)
    grp.ConfirmReqID |> Option.iter (WriteConfirmReqID strm)
    WriteConfirmTransType strm grp.ConfirmTransType
    WriteConfirmType strm grp.ConfirmType
    grp.CopyMsgIndicator |> Option.iter (WriteCopyMsgIndicator strm)
    grp.LegalConfirm |> Option.iter (WriteLegalConfirm strm)
    WriteConfirmStatus strm grp.ConfirmStatus
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.NoOrdersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoOrders strm (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoOrdersGrp strm gg)    ) // end Option.iter
    grp.AllocID |> Option.iter (WriteAllocID strm)
    grp.SecondaryAllocID |> Option.iter (WriteSecondaryAllocID strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    WriteTransactTime strm grp.TransactTime
    WriteTradeDate strm grp.TradeDate
    grp.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    WriteInstrument strm grp.Instrument    // component
    grp.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    let numGrps = grp.NoUnderlyingsGrp.Length
    WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
    grp.NoUnderlyingsGrp |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)
    let numGrps = grp.NoLegsGrp.Length
    WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
    grp.NoLegsGrp |> List.iter (fun gg -> WriteNoLegsGrp strm gg)
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    WriteAllocQty strm grp.AllocQty
    grp.QtyType |> Option.iter (WriteQtyType strm)
    WriteSide strm grp.Side
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.LastMkt |> Option.iter (WriteLastMkt strm)
    let numGrps = grp.NoCapacitiesGrp.Length
    WriteNoCapacities strm (Fix44.Fields.NoCapacities numGrps) // write the 'num group repeats' field
    grp.NoCapacitiesGrp |> List.iter (fun gg -> WriteNoCapacitiesGrp strm gg)
    WriteAllocAccount strm grp.AllocAccount
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocAccountType |> Option.iter (WriteAllocAccountType strm)
    WriteAvgPx strm grp.AvgPx
    grp.AvgPxPrecision |> Option.iter (WriteAvgPxPrecision strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.AvgParPx |> Option.iter (WriteAvgParPx strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.ReportedPx |> Option.iter (WriteReportedPx strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.ProcessCode |> Option.iter (WriteProcessCode strm)
    WriteGrossTradeAmt strm grp.GrossTradeAmt
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
    WriteNetMoney strm grp.NetMoney
    grp.MaturityNetMoney |> Option.iter (WriteMaturityNetMoney strm)
    grp.SettlCurrAmt |> Option.iter (WriteSettlCurrAmt strm)
    grp.SettlCurrency |> Option.iter (WriteSettlCurrency strm)
    grp.SettlCurrFxRate |> Option.iter (WriteSettlCurrFxRate strm)
    grp.SettlCurrFxRateCalc |> Option.iter (WriteSettlCurrFxRateCalc strm)
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component
    grp.CommissionData |> Option.iter (WriteCommissionData strm) // component
    grp.SharedCommission |> Option.iter (WriteSharedCommission strm)
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter


let WriteConfirmationAck (strm:System.IO.Stream) (grp:ConfirmationAck) =
    WriteConfirmID strm grp.ConfirmID
    WriteTradeDate strm grp.TradeDate
    WriteTransactTime strm grp.TransactTime
    WriteAffirmStatus strm grp.AffirmStatus
    grp.ConfirmRejReason |> Option.iter (WriteConfirmRejReason strm)
    grp.MatchStatus |> Option.iter (WriteMatchStatus strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteConfirmationRequest (strm:System.IO.Stream) (grp:ConfirmationRequest) =
    WriteConfirmReqID strm grp.ConfirmReqID
    WriteConfirmType strm grp.ConfirmType
    grp.NoOrdersGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoOrders strm (Fix44.Fields.NoOrders numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoOrdersGrp strm gg)    ) // end Option.iter
    grp.AllocID |> Option.iter (WriteAllocID strm)
    grp.SecondaryAllocID |> Option.iter (WriteSecondaryAllocID strm)
    grp.IndividualAllocID |> Option.iter (WriteIndividualAllocID strm)
    WriteTransactTime strm grp.TransactTime
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.AllocAccountType |> Option.iter (WriteAllocAccountType strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteSettlementInstructions (strm:System.IO.Stream) (grp:SettlementInstructions) =
    WriteSettlInstMsgID strm grp.SettlInstMsgID
    grp.SettlInstReqID |> Option.iter (WriteSettlInstReqID strm)
    WriteSettlInstMode strm grp.SettlInstMode
    grp.SettlInstReqRejCode |> Option.iter (WriteSettlInstReqRejCode strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.SettlInstSource |> Option.iter (WriteSettlInstSource strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    WriteTransactTime strm grp.TransactTime
    grp.NoSettlInstGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoSettlInst strm (Fix44.Fields.NoSettlInst numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoSettlInstGrp strm gg)    ) // end Option.iter


let WriteSettlementInstructionRequest (strm:System.IO.Stream) (grp:SettlementInstructionRequest) =
    WriteSettlInstReqID strm grp.SettlInstReqID
    WriteTransactTime strm grp.TransactTime
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.AllocAccount |> Option.iter (WriteAllocAccount strm)
    grp.AllocAcctIDSource |> Option.iter (WriteAllocAcctIDSource strm)
    grp.Side |> Option.iter (WriteSide strm)
    grp.Product |> Option.iter (WriteProduct strm)
    grp.SecurityType |> Option.iter (WriteSecurityType strm)
    grp.CFICode |> Option.iter (WriteCFICode strm)
    grp.EffectiveTime |> Option.iter (WriteEffectiveTime strm)
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.LastUpdateTime |> Option.iter (WriteLastUpdateTime strm)
    grp.StandInstDbType |> Option.iter (WriteStandInstDbType strm)
    grp.StandInstDbName |> Option.iter (WriteStandInstDbName strm)
    grp.StandInstDbID |> Option.iter (WriteStandInstDbID strm)


let WriteTradeCaptureReportRequest (strm:System.IO.Stream) (grp:TradeCaptureReportRequest) =
    WriteTradeRequestID strm grp.TradeRequestID
    WriteTradeRequestType strm grp.TradeRequestType
    grp.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    grp.TradeReportID |> Option.iter (WriteTradeReportID strm)
    grp.SecondaryTradeReportID |> Option.iter (WriteSecondaryTradeReportID strm)
    grp.ExecID |> Option.iter (WriteExecID strm)
    grp.ExecType |> Option.iter (WriteExecType strm)
    grp.OrderID |> Option.iter (WriteOrderID strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.MatchStatus |> Option.iter (WriteMatchStatus strm)
    grp.TrdType |> Option.iter (WriteTrdType strm)
    grp.TrdSubType |> Option.iter (WriteTrdSubType strm)
    grp.TransferReason |> Option.iter (WriteTransferReason strm)
    grp.SecondaryTrdType |> Option.iter (WriteSecondaryTrdType strm)
    grp.TradeLinkID |> Option.iter (WriteTradeLinkID strm)
    grp.TrdMatchID |> Option.iter (WriteTrdMatchID strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.InstrumentExtension |> Option.iter (WriteInstrumentExtension strm) // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.NoDatesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoDates strm (Fix44.Fields.NoDates numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoDatesGrp strm gg)    ) // end Option.iter
    grp.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.TimeBracket |> Option.iter (WriteTimeBracket strm)
    grp.Side |> Option.iter (WriteSide strm)
    grp.MultiLegReportingType |> Option.iter (WriteMultiLegReportingType strm)
    grp.TradeInputSource |> Option.iter (WriteTradeInputSource strm)
    grp.TradeInputDevice |> Option.iter (WriteTradeInputDevice strm)
    grp.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    grp.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteTradeCaptureReportRequestAck (strm:System.IO.Stream) (grp:TradeCaptureReportRequestAck) =
    WriteTradeRequestID strm grp.TradeRequestID
    WriteTradeRequestType strm grp.TradeRequestType
    grp.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    grp.TotNumTradeReports |> Option.iter (WriteTotNumTradeReports strm)
    WriteTradeRequestResult strm grp.TradeRequestResult
    WriteTradeRequestStatus strm grp.TradeRequestStatus
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.MultiLegReportingType |> Option.iter (WriteMultiLegReportingType strm)
    grp.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    grp.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteTradeCaptureReport (strm:System.IO.Stream) (grp:TradeCaptureReport) =
    WriteTradeReportID strm grp.TradeReportID
    grp.TradeReportTransType |> Option.iter (WriteTradeReportTransType strm)
    grp.TradeReportType |> Option.iter (WriteTradeReportType strm)
    grp.TradeRequestID |> Option.iter (WriteTradeRequestID strm)
    grp.TrdType |> Option.iter (WriteTrdType strm)
    grp.TrdSubType |> Option.iter (WriteTrdSubType strm)
    grp.SecondaryTrdType |> Option.iter (WriteSecondaryTrdType strm)
    grp.TransferReason |> Option.iter (WriteTransferReason strm)
    grp.ExecType |> Option.iter (WriteExecType strm)
    grp.TotNumTradeReports |> Option.iter (WriteTotNumTradeReports strm)
    grp.LastRptRequested |> Option.iter (WriteLastRptRequested strm)
    grp.UnsolicitedIndicator |> Option.iter (WriteUnsolicitedIndicator strm)
    grp.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    grp.TradeReportRefID |> Option.iter (WriteTradeReportRefID strm)
    grp.SecondaryTradeReportRefID |> Option.iter (WriteSecondaryTradeReportRefID strm)
    grp.SecondaryTradeReportID |> Option.iter (WriteSecondaryTradeReportID strm)
    grp.TradeLinkID |> Option.iter (WriteTradeLinkID strm)
    grp.TrdMatchID |> Option.iter (WriteTrdMatchID strm)
    grp.ExecID |> Option.iter (WriteExecID strm)
    grp.OrdStatus |> Option.iter (WriteOrdStatus strm)
    grp.SecondaryExecID |> Option.iter (WriteSecondaryExecID strm)
    grp.ExecRestatementReason |> Option.iter (WriteExecRestatementReason strm)
    WritePreviouslyReported strm grp.PreviouslyReported
    grp.PriceType |> Option.iter (WritePriceType strm)
    WriteInstrument strm grp.Instrument    // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.OrderQtyData |> Option.iter (WriteOrderQtyData strm) // component
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.YieldData |> Option.iter (WriteYieldData strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.UnderlyingTradingSessionID |> Option.iter (WriteUnderlyingTradingSessionID strm)
    grp.UnderlyingTradingSessionSubID |> Option.iter (WriteUnderlyingTradingSessionSubID strm)
    WriteLastQty strm grp.LastQty
    WriteLastPx strm grp.LastPx
    grp.LastParPx |> Option.iter (WriteLastParPx strm)
    grp.LastSpotRate |> Option.iter (WriteLastSpotRate strm)
    grp.LastForwardPoints |> Option.iter (WriteLastForwardPoints strm)
    grp.LastMkt |> Option.iter (WriteLastMkt strm)
    WriteTradeDate strm grp.TradeDate
    grp.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    grp.AvgPx |> Option.iter (WriteAvgPx strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.AvgPxIndicator |> Option.iter (WriteAvgPxIndicator strm)
    grp.PositionAmountData |> Option.iter (WritePositionAmountData strm) // component
    grp.MultiLegReportingType |> Option.iter (WriteMultiLegReportingType strm)
    grp.TradeLegRefID |> Option.iter (WriteTradeLegRefID strm)
    grp.TradeCaptureReport_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteTradeCaptureReport_NoLegsGrp strm gg)    ) // end Option.iter
    WriteTransactTime strm grp.TransactTime
    grp.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    grp.SettlType |> Option.iter (WriteSettlType strm)
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.MatchStatus |> Option.iter (WriteMatchStatus strm)
    grp.MatchType |> Option.iter (WriteMatchType strm)
    let noSidesField =  // ####
        match grp.TradeCaptureReport_NoSidesGrp with
        | OneOrTwo.One _ -> NoSides.OneSide
        | OneOrTwo.Two _ -> NoSides.BothSides
    WriteNoSides strm noSidesField
    grp.TradeCaptureReport_NoSidesGrp |> OneOrTwo.iter (WriteTradeCaptureReport_NoSidesGrp strm)   // group
    grp.CopyMsgIndicator |> Option.iter (WriteCopyMsgIndicator strm)
    grp.PublishTrdIndicator |> Option.iter (WritePublishTrdIndicator strm)
    grp.ShortSaleReason |> Option.iter (WriteShortSaleReason strm)


let WriteTradeCaptureReportAck (strm:System.IO.Stream) (grp:TradeCaptureReportAck) =
    WriteTradeReportID strm grp.TradeReportID
    grp.TradeReportTransType |> Option.iter (WriteTradeReportTransType strm)
    grp.TradeReportType |> Option.iter (WriteTradeReportType strm)
    grp.TrdType |> Option.iter (WriteTrdType strm)
    grp.TrdSubType |> Option.iter (WriteTrdSubType strm)
    grp.SecondaryTrdType |> Option.iter (WriteSecondaryTrdType strm)
    grp.TransferReason |> Option.iter (WriteTransferReason strm)
    WriteExecType strm grp.ExecType
    grp.TradeReportRefID |> Option.iter (WriteTradeReportRefID strm)
    grp.SecondaryTradeReportRefID |> Option.iter (WriteSecondaryTradeReportRefID strm)
    grp.TrdRptStatus |> Option.iter (WriteTrdRptStatus strm)
    grp.TradeReportRejectReason |> Option.iter (WriteTradeReportRejectReason strm)
    grp.SecondaryTradeReportID |> Option.iter (WriteSecondaryTradeReportID strm)
    grp.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    grp.TradeLinkID |> Option.iter (WriteTradeLinkID strm)
    grp.TrdMatchID |> Option.iter (WriteTrdMatchID strm)
    grp.ExecID |> Option.iter (WriteExecID strm)
    grp.SecondaryExecID |> Option.iter (WriteSecondaryExecID strm)
    WriteInstrument strm grp.Instrument    // component
    grp.TransactTime |> Option.iter (WriteTransactTime strm)
    grp.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    grp.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    grp.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)
    grp.TradeCaptureReportAck_NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteTradeCaptureReportAck_NoLegsGrp strm gg)    ) // end Option.iter
    grp.ClearingFeeIndicator |> Option.iter (WriteClearingFeeIndicator strm)
    grp.OrderCapacity |> Option.iter (WriteOrderCapacity strm)
    grp.OrderRestrictions |> Option.iter (WriteOrderRestrictions strm)
    grp.CustOrderCapacity |> Option.iter (WriteCustOrderCapacity strm)
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.PositionEffect |> Option.iter (WritePositionEffect strm)
    grp.PreallocMethod |> Option.iter (WritePreallocMethod strm)
    grp.TradeCaptureReportAck_NoAllocsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoAllocs strm (Fix44.Fields.NoAllocs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteTradeCaptureReportAck_NoAllocsGrp strm gg)    ) // end Option.iter


let WriteRegistrationInstructions (strm:System.IO.Stream) (grp:RegistrationInstructions) =
    WriteRegistID strm grp.RegistID
    WriteRegistTransType strm grp.RegistTransType
    WriteRegistRefID strm grp.RegistRefID
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    grp.RegistAcctType |> Option.iter (WriteRegistAcctType strm)
    grp.TaxAdvantageType |> Option.iter (WriteTaxAdvantageType strm)
    grp.OwnershipType |> Option.iter (WriteOwnershipType strm)
    grp.NoRegistDtlsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoRegistDtls strm (Fix44.Fields.NoRegistDtls numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoRegistDtlsGrp strm gg)    ) // end Option.iter
    grp.NoDistribInstsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoDistribInsts strm (Fix44.Fields.NoDistribInsts numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoDistribInstsGrp strm gg)    ) // end Option.iter


let WriteRegistrationInstructionsResponse (strm:System.IO.Stream) (grp:RegistrationInstructionsResponse) =
    WriteRegistID strm grp.RegistID
    WriteRegistTransType strm grp.RegistTransType
    WriteRegistRefID strm grp.RegistRefID
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteRegistStatus strm grp.RegistStatus
    grp.RegistRejReasonCode |> Option.iter (WriteRegistRejReasonCode strm)
    grp.RegistRejReasonText |> Option.iter (WriteRegistRejReasonText strm)


let WritePositionMaintenanceRequest (strm:System.IO.Stream) (grp:PositionMaintenanceRequest) =
    WritePosReqID strm grp.PosReqID
    WritePosTransType strm grp.PosTransType
    WritePosMaintAction strm grp.PosMaintAction
    grp.OrigPosReqRefID |> Option.iter (WriteOrigPosReqRefID strm)
    grp.PosMaintRptRefID |> Option.iter (WritePosMaintRptRefID strm)
    WriteClearingBusinessDate strm grp.ClearingBusinessDate
    grp.SettlSessID |> Option.iter (WriteSettlSessID strm)
    grp.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    WriteParties strm grp.Parties    // component
    WriteAccount strm grp.Account
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteAccountType strm grp.AccountType
    WriteInstrument strm grp.Instrument    // component
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoTradingSessionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTradingSessions strm (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradingSessionsGrp strm gg)    ) // end Option.iter
    WriteTransactTime strm grp.TransactTime
    WritePositionQty strm grp.PositionQty    // component
    grp.AdjustmentType |> Option.iter (WriteAdjustmentType strm)
    grp.ContraryInstructionIndicator |> Option.iter (WriteContraryInstructionIndicator strm)
    grp.PriorSpreadIndicator |> Option.iter (WritePriorSpreadIndicator strm)
    grp.ThresholdAmount |> Option.iter (WriteThresholdAmount strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WritePositionMaintenanceReport (strm:System.IO.Stream) (grp:PositionMaintenanceReport) =
    WritePosMaintRptID strm grp.PosMaintRptID
    WritePosTransType strm grp.PosTransType
    grp.PosReqID |> Option.iter (WritePosReqID strm)
    WritePosMaintAction strm grp.PosMaintAction
    WriteOrigPosReqRefID strm grp.OrigPosReqRefID
    WritePosMaintStatus strm grp.PosMaintStatus
    grp.PosMaintResult |> Option.iter (WritePosMaintResult strm)
    WriteClearingBusinessDate strm grp.ClearingBusinessDate
    grp.SettlSessID |> Option.iter (WriteSettlSessID strm)
    grp.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    WriteAccount strm grp.Account
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteAccountType strm grp.AccountType
    WriteInstrument strm grp.Instrument    // component
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.NoTradingSessionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTradingSessions strm (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradingSessionsGrp strm gg)    ) // end Option.iter
    WriteTransactTime strm grp.TransactTime
    WritePositionQty strm grp.PositionQty    // component
    WritePositionAmountData strm grp.PositionAmountData    // component
    grp.AdjustmentType |> Option.iter (WriteAdjustmentType strm)
    grp.ThresholdAmount |> Option.iter (WriteThresholdAmount strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteRequestForPositions (strm:System.IO.Stream) (grp:RequestForPositions) =
    WritePosReqID strm grp.PosReqID
    WritePosReqType strm grp.PosReqType
    grp.MatchStatus |> Option.iter (WriteMatchStatus strm)
    grp.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    WriteParties strm grp.Parties    // component
    WriteAccount strm grp.Account
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteAccountType strm grp.AccountType
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WriteClearingBusinessDate strm grp.ClearingBusinessDate
    grp.SettlSessID |> Option.iter (WriteSettlSessID strm)
    grp.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    grp.NoTradingSessionsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTradingSessions strm (Fix44.Fields.NoTradingSessions numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradingSessionsGrp strm gg)    ) // end Option.iter
    WriteTransactTime strm grp.TransactTime
    grp.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    grp.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteRequestForPositionsAck (strm:System.IO.Stream) (grp:RequestForPositionsAck) =
    WritePosMaintRptID strm grp.PosMaintRptID
    grp.PosReqID |> Option.iter (WritePosReqID strm)
    grp.TotalNumPosReports |> Option.iter (WriteTotalNumPosReports strm)
    grp.UnsolicitedIndicator |> Option.iter (WriteUnsolicitedIndicator strm)
    WritePosReqResult strm grp.PosReqResult
    WritePosReqStatus strm grp.PosReqStatus
    WriteParties strm grp.Parties    // component
    WriteAccount strm grp.Account
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteAccountType strm grp.AccountType
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    grp.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WritePositionReport (strm:System.IO.Stream) (grp:PositionReport) =
    WritePosMaintRptID strm grp.PosMaintRptID
    grp.PosReqID |> Option.iter (WritePosReqID strm)
    grp.PosReqType |> Option.iter (WritePosReqType strm)
    grp.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    grp.TotalNumPosReports |> Option.iter (WriteTotalNumPosReports strm)
    grp.UnsolicitedIndicator |> Option.iter (WriteUnsolicitedIndicator strm)
    WritePosReqResult strm grp.PosReqResult
    WriteClearingBusinessDate strm grp.ClearingBusinessDate
    grp.SettlSessID |> Option.iter (WriteSettlSessID strm)
    grp.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    WriteParties strm grp.Parties    // component
    WriteAccount strm grp.Account
    grp.AcctIDSource |> Option.iter (WriteAcctIDSource strm)
    WriteAccountType strm grp.AccountType
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.Currency |> Option.iter (WriteCurrency strm)
    WriteSettlPrice strm grp.SettlPrice
    WriteSettlPriceType strm grp.SettlPriceType
    WritePriorSettlPrice strm grp.PriorSettlPrice
    grp.NoLegsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoLegs strm (Fix44.Fields.NoLegs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoLegsGrp strm gg)    ) // end Option.iter
    grp.PositionReport_NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WritePositionReport_NoUnderlyingsGrp strm gg)    ) // end Option.iter
    WritePositionQty strm grp.PositionQty    // component
    WritePositionAmountData strm grp.PositionAmountData    // component
    grp.RegistStatus |> Option.iter (WriteRegistStatus strm)
    grp.DeliveryDate |> Option.iter (WriteDeliveryDate strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteAssignmentReport (strm:System.IO.Stream) (grp:AssignmentReport) =
    WriteAsgnRptID strm grp.AsgnRptID
    grp.TotNumAssignmentReports |> Option.iter (WriteTotNumAssignmentReports strm)
    grp.LastRptRequested |> Option.iter (WriteLastRptRequested strm)
    WriteParties strm grp.Parties    // component
    grp.Account |> Option.iter (WriteAccount strm)
    WriteAccountType strm grp.AccountType
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.NoLegs |> Option.iter (WriteNoLegs strm)
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    WritePositionQty strm grp.PositionQty    // component
    WritePositionAmountData strm grp.PositionAmountData    // component
    grp.ThresholdAmount |> Option.iter (WriteThresholdAmount strm)
    WriteSettlPrice strm grp.SettlPrice
    WriteSettlPriceType strm grp.SettlPriceType
    WriteUnderlyingSettlPrice strm grp.UnderlyingSettlPrice
    grp.ExpireDate |> Option.iter (WriteExpireDate strm)
    WriteAssignmentMethod strm grp.AssignmentMethod
    grp.AssignmentUnit |> Option.iter (WriteAssignmentUnit strm)
    WriteOpenInterest strm grp.OpenInterest
    WriteExerciseMethod strm grp.ExerciseMethod
    WriteSettlSessID strm grp.SettlSessID
    WriteSettlSessSubID strm grp.SettlSessSubID
    WriteClearingBusinessDate strm grp.ClearingBusinessDate
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteCollateralRequest (strm:System.IO.Stream) (grp:CollateralRequest) =
    WriteCollReqID strm grp.CollReqID
    WriteCollAsgnReason strm grp.CollAsgnReason
    WriteTransactTime strm grp.TransactTime
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.OrderID |> Option.iter (WriteOrderID strm)
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoExecsGrp strm gg)    ) // end Option.iter
    grp.NoTradesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTrades strm (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradesGrp strm gg)    ) // end Option.iter
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.Quantity |> Option.iter (WriteQuantity strm)
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.NoLegs |> Option.iter (WriteNoLegs strm)
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.CollateralRequest_NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteCollateralRequest_NoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.MarginExcess |> Option.iter (WriteMarginExcess strm)
    grp.TotalNetValue |> Option.iter (WriteTotalNetValue strm)
    grp.CashOutstanding |> Option.iter (WriteCashOutstanding strm)
    grp.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    grp.Side |> Option.iter (WriteSide strm)
    grp.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    grp.Price |> Option.iter (WritePrice strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    grp.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    grp.StartCash |> Option.iter (WriteStartCash strm)
    grp.EndCash |> Option.iter (WriteEndCash strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.SettlSessID |> Option.iter (WriteSettlSessID strm)
    grp.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    grp.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteCollateralAssignment (strm:System.IO.Stream) (grp:CollateralAssignment) =
    WriteCollAsgnID strm grp.CollAsgnID
    grp.CollReqID |> Option.iter (WriteCollReqID strm)
    WriteCollAsgnReason strm grp.CollAsgnReason
    WriteCollAsgnTransType strm grp.CollAsgnTransType
    grp.CollAsgnRefID |> Option.iter (WriteCollAsgnRefID strm)
    WriteTransactTime strm grp.TransactTime
    grp.ExpireTime |> Option.iter (WriteExpireTime strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.OrderID |> Option.iter (WriteOrderID strm)
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoExecsGrp strm gg)    ) // end Option.iter
    grp.NoTradesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTrades strm (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradesGrp strm gg)    ) // end Option.iter
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.Quantity |> Option.iter (WriteQuantity strm)
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.NoLegs |> Option.iter (WriteNoLegs strm)
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.CollateralAssignment_NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteCollateralAssignment_NoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.MarginExcess |> Option.iter (WriteMarginExcess strm)
    grp.TotalNetValue |> Option.iter (WriteTotalNetValue strm)
    grp.CashOutstanding |> Option.iter (WriteCashOutstanding strm)
    grp.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    grp.Side |> Option.iter (WriteSide strm)
    grp.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    grp.Price |> Option.iter (WritePrice strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    grp.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    grp.StartCash |> Option.iter (WriteStartCash strm)
    grp.EndCash |> Option.iter (WriteEndCash strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.SettlSessID |> Option.iter (WriteSettlSessID strm)
    grp.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    grp.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteCollateralResponse (strm:System.IO.Stream) (grp:CollateralResponse) =
    WriteCollRespID strm grp.CollRespID
    WriteCollAsgnID strm grp.CollAsgnID
    grp.CollReqID |> Option.iter (WriteCollReqID strm)
    WriteCollAsgnReason strm grp.CollAsgnReason
    grp.CollAsgnTransType |> Option.iter (WriteCollAsgnTransType strm)
    WriteCollAsgnRespType strm grp.CollAsgnRespType
    grp.CollAsgnRejectReason |> Option.iter (WriteCollAsgnRejectReason strm)
    WriteTransactTime strm grp.TransactTime
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.OrderID |> Option.iter (WriteOrderID strm)
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoExecsGrp strm gg)    ) // end Option.iter
    grp.NoTradesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTrades strm (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradesGrp strm gg)    ) // end Option.iter
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.Quantity |> Option.iter (WriteQuantity strm)
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.NoLegs |> Option.iter (WriteNoLegs strm)
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.CollateralResponse_NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteCollateralResponse_NoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.MarginExcess |> Option.iter (WriteMarginExcess strm)
    grp.TotalNetValue |> Option.iter (WriteTotalNetValue strm)
    grp.CashOutstanding |> Option.iter (WriteCashOutstanding strm)
    grp.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    grp.Side |> Option.iter (WriteSide strm)
    grp.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    grp.Price |> Option.iter (WritePrice strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    grp.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    grp.StartCash |> Option.iter (WriteStartCash strm)
    grp.EndCash |> Option.iter (WriteEndCash strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteCollateralReport (strm:System.IO.Stream) (grp:CollateralReport) =
    WriteCollRptID strm grp.CollRptID
    grp.CollInquiryID |> Option.iter (WriteCollInquiryID strm)
    WriteCollStatus strm grp.CollStatus
    grp.TotNumReports |> Option.iter (WriteTotNumReports strm)
    grp.LastRptRequested |> Option.iter (WriteLastRptRequested strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.OrderID |> Option.iter (WriteOrderID strm)
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoExecsGrp strm gg)    ) // end Option.iter
    grp.NoTradesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTrades strm (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradesGrp strm gg)    ) // end Option.iter
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.Quantity |> Option.iter (WriteQuantity strm)
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.NoLegs |> Option.iter (WriteNoLegs strm)
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.MarginExcess |> Option.iter (WriteMarginExcess strm)
    grp.TotalNetValue |> Option.iter (WriteTotalNetValue strm)
    grp.CashOutstanding |> Option.iter (WriteCashOutstanding strm)
    grp.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    grp.Side |> Option.iter (WriteSide strm)
    grp.NoMiscFeesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoMiscFees strm (Fix44.Fields.NoMiscFees numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoMiscFeesGrp strm gg)    ) // end Option.iter
    grp.Price |> Option.iter (WritePrice strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    grp.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    grp.StartCash |> Option.iter (WriteStartCash strm)
    grp.EndCash |> Option.iter (WriteEndCash strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.SettlSessID |> Option.iter (WriteSettlSessID strm)
    grp.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    grp.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteCollateralInquiry (strm:System.IO.Stream) (grp:CollateralInquiry) =
    grp.CollInquiryID |> Option.iter (WriteCollInquiryID strm)
    grp.NoCollInquiryQualifierGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoCollInquiryQualifier strm (Fix44.Fields.NoCollInquiryQualifier numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoCollInquiryQualifierGrp strm gg)    ) // end Option.iter
    grp.SubscriptionRequestType |> Option.iter (WriteSubscriptionRequestType strm)
    grp.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    grp.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.OrderID |> Option.iter (WriteOrderID strm)
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoExecsGrp strm gg)    ) // end Option.iter
    grp.NoTradesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTrades strm (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradesGrp strm gg)    ) // end Option.iter
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.Quantity |> Option.iter (WriteQuantity strm)
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.NoLegs |> Option.iter (WriteNoLegs strm)
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.MarginExcess |> Option.iter (WriteMarginExcess strm)
    grp.TotalNetValue |> Option.iter (WriteTotalNetValue strm)
    grp.CashOutstanding |> Option.iter (WriteCashOutstanding strm)
    grp.TrdRegTimestamps |> Option.iter (WriteTrdRegTimestamps strm) // component
    grp.Side |> Option.iter (WriteSide strm)
    grp.Price |> Option.iter (WritePrice strm)
    grp.PriceType |> Option.iter (WritePriceType strm)
    grp.AccruedInterestAmt |> Option.iter (WriteAccruedInterestAmt strm)
    grp.EndAccruedInterestAmt |> Option.iter (WriteEndAccruedInterestAmt strm)
    grp.StartCash |> Option.iter (WriteStartCash strm)
    grp.EndCash |> Option.iter (WriteEndCash strm)
    grp.SpreadOrBenchmarkCurveData |> Option.iter (WriteSpreadOrBenchmarkCurveData strm) // component
    grp.Stipulations |> Option.iter (WriteStipulations strm) // component
    grp.SettlInstructionsData |> Option.iter (WriteSettlInstructionsData strm) // component
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.SettlSessID |> Option.iter (WriteSettlSessID strm)
    grp.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    grp.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


let WriteNetworkStatusRequest (strm:System.IO.Stream) (grp:NetworkStatusRequest) =
    WriteNetworkRequestType strm grp.NetworkRequestType
    WriteNetworkRequestID strm grp.NetworkRequestID
    grp.NoCompIDsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoCompIDs strm (Fix44.Fields.NoCompIDs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoCompIDsGrp strm gg)    ) // end Option.iter


let WriteNetworkStatusResponse (strm:System.IO.Stream) (grp:NetworkStatusResponse) =
    WriteNetworkStatusResponseType strm grp.NetworkStatusResponseType
    grp.NetworkRequestID |> Option.iter (WriteNetworkRequestID strm)
    grp.NetworkResponseID |> Option.iter (WriteNetworkResponseID strm)
    grp.LastNetworkResponseID |> Option.iter (WriteLastNetworkResponseID strm)
    let numGrps = grp.NetworkStatusResponse_NoCompIDsGrp.Length
    WriteNoCompIDs strm (Fix44.Fields.NoCompIDs numGrps) // write the 'num group repeats' field
    grp.NetworkStatusResponse_NoCompIDsGrp |> List.iter (fun gg -> WriteNetworkStatusResponse_NoCompIDsGrp strm gg)


let WriteCollateralInquiryAck (strm:System.IO.Stream) (grp:CollateralInquiryAck) =
    WriteCollInquiryID strm grp.CollInquiryID
    WriteCollInquiryStatus strm grp.CollInquiryStatus
    grp.CollInquiryResult |> Option.iter (WriteCollInquiryResult strm)
    grp.NoCollInquiryQualifierGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoCollInquiryQualifier strm (Fix44.Fields.NoCollInquiryQualifier numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoCollInquiryQualifierGrp strm gg)    ) // end Option.iter
    grp.TotNumReports |> Option.iter (WriteTotNumReports strm)
    grp.Parties |> Option.iter (WriteParties strm) // component
    grp.Account |> Option.iter (WriteAccount strm)
    grp.AccountType |> Option.iter (WriteAccountType strm)
    grp.ClOrdID |> Option.iter (WriteClOrdID strm)
    grp.OrderID |> Option.iter (WriteOrderID strm)
    grp.SecondaryOrderID |> Option.iter (WriteSecondaryOrderID strm)
    grp.SecondaryClOrdID |> Option.iter (WriteSecondaryClOrdID strm)
    grp.NoExecsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoExecs strm (Fix44.Fields.NoExecs numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoExecsGrp strm gg)    ) // end Option.iter
    grp.NoTradesGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoTrades strm (Fix44.Fields.NoTrades numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoTradesGrp strm gg)    ) // end Option.iter
    grp.Instrument |> Option.iter (WriteInstrument strm) // component
    grp.FinancingDetails |> Option.iter (WriteFinancingDetails strm) // component
    grp.SettlDate |> Option.iter (WriteSettlDate strm)
    grp.Quantity |> Option.iter (WriteQuantity strm)
    grp.QtyType |> Option.iter (WriteQtyType strm)
    grp.Currency |> Option.iter (WriteCurrency strm)
    grp.NoLegs |> Option.iter (WriteNoLegs strm)
    grp.InstrumentLeg |> Option.iter (WriteInstrumentLeg strm) // component
    grp.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
    grp.TradingSessionID |> Option.iter (WriteTradingSessionID strm)
    grp.TradingSessionSubID |> Option.iter (WriteTradingSessionSubID strm)
    grp.SettlSessID |> Option.iter (WriteSettlSessID strm)
    grp.SettlSessSubID |> Option.iter (WriteSettlSessSubID strm)
    grp.ClearingBusinessDate |> Option.iter (WriteClearingBusinessDate strm)
    grp.ResponseTransportType |> Option.iter (WriteResponseTransportType strm)
    grp.ResponseDestination |> Option.iter (WriteResponseDestination strm)
    grp.Text |> Option.iter (WriteText strm)
    grp.EncodedText |> Option.iter (WriteEncodedText strm)


