module Executor

//open System
//open System.Net.Sockets
//open System.Threading
//open System.IO

open Fix44
open Fix44.Fields





// in qf.net see Session.Next / Session.NextMessage
let Executor (msgType:MsgType) (index:FIXBufIndexer.IndexData) (buf:byte array) (resendMsgs:ResizeArray<Fix44.MessageDU.FIXMessage>) : (MessageDU.FIXMessage list) =

    match msgType with
    | MsgType.OrderCancelRequest -> 
        let msgIn = MsgReaders.ReadOrderCancelRequest buf index
        let orderId = 
            match msgIn.OrderID with
            | Some ordId    -> ordId
            | None          -> OrderID "unknown"
        let ocr = MessageFactoryFuncs.MkOrderCancelReject (orderId, msgIn.ClOrdID, msgIn.OrigClOrdID, OrdStatus.Rejected, CxlRejResponseTo.OrderCancelRequest )
        let ocr2 = {ocr with 
                        CxlRejReason = CxlRejReason.Other |> Some
                        Text = "Executor does not support order cancels" |> Fields.Text |> Some}
        let msgDu = ocr2 |> Fix44.MessageDU.FIXMessage.OrderCancelReject
        [msgDu]

    | MsgType.OrderCancelReplaceRequest ->
        let msgIn = MsgReaders.ReadOrderCancelReplaceRequest buf index
        let orderId = 
            match msgIn.OrderID with
            | Some ordId    -> ordId
            | None          -> OrderID "unknown"
        let ocr = MessageFactoryFuncs.MkOrderCancelReject (orderId, msgIn.ClOrdID, msgIn.OrigClOrdID, OrdStatus.Rejected, CxlRejResponseTo.OrderCancelReplaceRequest )
        let ocr2 = {ocr with 
                        CxlRejReason = CxlRejReason.Other |> Some
                        Text = "Executor does not support order cancel/replaces" |> Fields.Text |> Some}
        let msgDu = ocr2 |> Fix44.MessageDU.FIXMessage.OrderCancelReject
        [msgDu]
    
    | MsgType.News                      -> []
    
    | MsgType.NewOrderSingle            -> 

        let nos = MsgReaders.ReadNewOrderSingle buf index

        match nos.Price, nos.OrderQtyData.OrderQty with
        | Some prc, Some qty -> 
                                
            let clOrdId = nos.ClOrdID
            let orderID = OrderID   "ORDERID" // todo: generate orderID
            let execID  = ExecID    "EXECID"  // todo: generate executionID
            let leavesQty = LeavesQty 0.0m
            let cumQty = CumQty qty.Value
            let executionPrice =
                match nos.OrdType with
                | OrdType.Limit     -> prc.Value
                | OrdType.Market    -> 10.0m // this is demo app, consider the market price to be 10.0
                | ot                -> failwithf "unsupported order type: %A" ot // todo: send orderRejected message
            let avgPrc = AvgPx executionPrice

            let execRep = Fix44.MessageFactoryFuncs.MkExecutionReport (
                                                orderID, 
                                                nos.Parties, 
                                                execID, 
                                                ExecType.Fill, 
                                                OrdStatus.Filled, 
                                                nos.Instrument, 
                                                Fix44.CompoundItemFactoryFuncs.MkFinancingDetails(),
                                                nos.Side,
                                                nos.Stipulations,
                                                nos.OrderQtyData,
                                                Fix44.CompoundItemFactoryFuncs.MkPegInstructions(),
                                                Fix44.CompoundItemFactoryFuncs.MkDiscretionInstructions(),
                                                leavesQty,
                                                cumQty, 
                                                avgPrc,
                                                Fix44.CompoundItemFactoryFuncs.MkCommissionData (),
                                                Fix44.CompoundItemFactoryFuncs.MkSpreadOrBenchmarkCurveData(),
                                                Fix44.CompoundItemFactoryFuncs.MkYieldData() )

            let execRep2 = { execRep with 
                                Account = nos.Account
                                ClOrdID = clOrdId |> Some
                                LastQty = qty.Value |> LastQty |> Some
                                LastPx  = executionPrice |> LastPx |> Some }

            let msgToSend = execRep2 |> Fix44.MessageDU.FIXMessage.ExecutionReport
            resendMsgs.Add msgToSend
            [msgToSend]
        | _      -> failwithf "order: %A, zero price or quantity for limit order" nos.ClOrdID             //todo this is incorrect, a market order could have Option.None price
    
    | mt    -> failwithf "unsupported msg type: %A" mt

