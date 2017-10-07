
open System
open System.Net.Sockets
open System.Net

open Fix44
open Fix44.Fields




//#nowarn "52"
let WaitForExitCmd () = 
    while Console.ReadKey().KeyChar <> 'X' do // 88 is 'X'
        ()


let Executor (msgType:MsgType) (index:FIXBufIndexer.IndexData) (buf:byte array) (resendMsgs:ResizeArray<Fix44.MessageDU.FIXMessage>) : (MessageDU.FIXMessage list) =
    // in qf.net see Session.Next / Session.NextMessage
    
    match msgType with
    | MsgType.OrderCancelRequest        -> []
    | MsgType.OrderCancelReplaceRequest -> []  
    | MsgType.News                      -> []
    | MsgType.NewOrderSingle            -> 

        //todo: what is an elegant way to deal with Option price and Option quantity
        //todo: is there an awkard mix of imperative with functional here ??
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
    
    | mt    -> failwithf "unsuppored msg type: %A" mt




[<EntryPoint>]
let main argv =

    // TODO, read targetCompID and senderCompID from config
    let trgCompId = TargetCompID "acceptor"
    let sndCompId = SenderCompID "initiator"

    let acceptedCompIDPairs = Set.empty |> Set.add (trgCompId, sndCompId)
    let maxMsgAge = TimeSpan(0,0,30)
    let tl = TcpListener (IPAddress.Loopback, 5001)
    tl.Start()

    let bufSize = 1024 * 64
    do FsFix.Session.Acceptor.ListenerLoop Executor maxMsgAge acceptedCompIDPairs bufSize tl
            
    Console.WriteLine("running, press 'X' to exit")        
    WaitForExitCmd ()    

    0 // return an integer exit code
