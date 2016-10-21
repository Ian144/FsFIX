module Fix44.MsgWriteFuncs

open OneOrTwo
open Fix44.Fields
open Fix44.FieldReadWriteFuncs
open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs
open Fix44.Messages


// tag: A
let WriteLogon (xx:Logon) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (strm:ResizeArray<byte>) = 
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
    xx.NoUnderlyingsGrp |> Option.iter (fun gs ->     // group
        let numGrps = gs.Length
        WriteNoUnderlyings strm (Fix44.Fields.NoUnderlyings numGrps) // write the 'num group repeats' field
        gs |> List.iter (fun gg -> WriteNoUnderlyingsGrp strm gg)    ) // end Option.iter
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


