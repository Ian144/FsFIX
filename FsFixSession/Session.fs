module FsFix.Session


open System
open System.Net.Sockets
open System.Threading
open System.IO


open Fix44
open Fix44.Fields


let HandleSocketError (name:string) (ex:System.Exception) = 
    //let rec handleExInner (ex:System.Exception) = 
    //    let msg = ex.Message
    //    let optInnerEx = FSharpx.FSharpOption.ToFSharpOption ex.InnerException

    //    match optInnerEx with
    //    | None  ->          msg
    //    | Some innerEx ->   let innerMsg = handleExInner innerEx
    //                        sprintf "%s | %s" msg innerMsg
    //let msg = handleExInner ex
    //// Microsoft redis-benchmark does not close its socket connections down cleanly
    //if not (msg.Contains("forcibly closed")) then
    //    printfn "%s --> %s" name msg
    ()


let ClientError ex =  HandleSocketError "client error" ex
let ConnectionListenerError ex = HandleSocketError "connection listener error" ex


let bufSize = 1024 * 64
let readTimeout = 1000000 // millisecs
let checksumLen = 7

let fix44 = Fields.BeginString "FIX.4.4"


let countFieldSeperators (buf:byte array) endPos = 
    let mutable numSeps:uint32 = 0u
    let mutable pos:int = 0
    while pos < endPos do
        if buf.[pos] = 1uy then
            numSeps <- numSeps + 1u
    numSeps


// populates buf with all message bytes, unless a read timeout occurred
// returns num bytes read
let ReadAllMsgBytes (strm:Stream) (buf:byte[]): int =
    
    // todo: ensure read-timeout is set
    let mutable numBytesRead = strm.Read(buf, 0, bufSize ) // times out after readTimeout millisecs

    if numBytesRead <> 0 then

        // ensure that the first two fields are present by reading beyond the max plausible end of the second
        // the first field contains the fix version
        // the second field contains the length of the msg body, allowing the rest of the bytes to be read before msg parsing
        // TODO: make min bytes to read configurable
        let minBytesToRead = 32
        while minBytesToRead > numBytesRead do
            let numBytesInner = strm.Read( buf, numBytesRead, bufSize-numBytesRead )
            numBytesRead <- numBytesRead + numBytesInner

        //8=FIX.4.2|9=65|35=A|49=SERVER|56=CLIENT|34=177|52=20090107-18:15:16|98=0|108=30|10=062|

        let mutable firstSepPos = 0
        while buf.[firstSepPos] <> 1uy && firstSepPos < numBytesRead do
            firstSepPos <- firstSepPos + 1

        let mutable secondSepPos = firstSepPos + 1
        while buf.[secondSepPos] <> 1uy && firstSepPos < numBytesRead do
            secondSepPos <- secondSepPos + 1

        if firstSepPos < numBytesRead && secondSepPos < numBytesRead then
            let firstMsgIsBeginString = buf.[0] = 56uy && buf.[1] = 61uy
            let secondMsgIsBodyLen = buf.[firstSepPos+1] = 57uy && buf.[firstSepPos+2] = 61uy

            // todo, exception if first two fields are not BeginString and BodyLen

            let beginingOfLen = firstSepPos + 3
            let (Fields.BodyLength bodyLen) = FieldReaders.ReadBodyLength buf beginingOfLen (secondSepPos - beginingOfLen)
                
            let msgLen = secondSepPos + (int32 bodyLen) + checksumLen + 1 //+1 as the buffer is zero based
            while msgLen > numBytesRead do
                let numBytesInner = strm.Read( buf, numBytesRead, bufSize-numBytesRead )
                // todo: if zero bytes return here then error, a timeout has expired
                numBytesRead <- numBytesRead + numBytesInner

            numBytesRead

        else
            let ss = Conversions.bytesToStr buf 0 numBytesRead 
            let ss2 = ss.Replace( char(1uy), '|')
            failwithf "Reading new message error. Failed to find first BegingString and BodyLen field seperators: %s" ss2
    else
        0   // read timeout in first strm.Read - client code may want to send a heartbeat




let ProcessLogon (maxMsgAge:TimeSpan) (acceptableCompIDPairSet: (TargetCompID*SenderCompID) Set) (strm:Stream) (fieldIndex:FIXBufIndexer.FieldPos []) (buf:byte[]) : Unit =
    
        let numBytesRead = ReadAllMsgBytes strm buf
        // todo: deal with zero bytes read, or use infinite read timeout

        let indexEnd                = FIXBufIndexer.BuildIndex fieldIndex buf numBytesRead
        let index                   = FIXBufIndexer.IndexData (indexEnd, fieldIndex)
                
        // TODO: don't use hard coded fix tags
        let (MsgSeqNum seqNum)      = GenericReaders.ReadField buf index 34 FieldReaders.ReadMsgSeqNum
        let senderCompID            = GenericReaders.ReadField buf index 49 FieldReaders.ReadSenderCompID
        let (SendingTime sendTime)  = GenericReaders.ReadField buf index 52 FieldReaders.ReadSendingTime
        let targetCompID            = GenericReaders.ReadField buf index 56 FieldReaders.ReadTargetCompID
        let msgType                 = GenericReaders.ReadField buf index 35 FieldReaders.ReadMsgType

        // todo read and check fix version

        let msgTypeOK = msgType = MsgType.Logon
        if not msgTypeOK then
            failwithf "logon failure: invalid msg type received: %A" msgType

        let dtoSendTime = UTCDateTime.MakeUTCTimestamp.MakeDTO sendTime
        let utcNow = DateTimeOffset.UtcNow
        let msgAge = (dtoSendTime - utcNow)
        let sendTimeOk = maxMsgAge >= msgAge
        if not sendTimeOk then
            failwithf "max acceptable msg age: %A, actual msg age: %A" maxMsgAge  msgAge

        let seqNumOk = (1u = seqNum)
        if not seqNumOk then
            failwithf "logon failure: expected '0' sequence number, actual: %d" seqNum

        let compIDsOk = acceptableCompIDPairSet.Contains (targetCompID, senderCompID)
        if not compIDsOk then
            failwithf "logon failure: invalid target and sender compIDs: %A" (targetCompID, senderCompID)

        let logonMsg = MsgReaders.ReadLogon buf index
        printfn "%A" logonMsg
        printfn "logon successfull"
        //todo: log successfull logon




//todo: consider let AcceptorLoop msgProcessorFunc (bufSize:int) (client:TcpClient) =
let AcceptorLoop (maxMsgAge:TimeSpan) (acceptableCompIDPairSet: (TargetCompID*SenderCompID) Set) (bufSize:int) (client:TcpClient) =
    //todo: client.LingerState <-
    client.NoDelay              <- true
    client.ReceiveBufferSize    <- bufSize
    client.SendBufferSize       <- bufSize
    use strm                    = client.GetStream()
    strm.ReadTimeout            <- readTimeout
    let buf                     = Array.zeroCreate<byte> bufSize
    let tmpBuf                  = Array.zeroCreate<byte> bufSize
    let fieldIndex              = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 8) // one element for each field

    let mutable currentSeqNum   = 1u

    // todo: add logging

    let threadFunc () = 

        // TODO add logging to ProcessLogon
        ProcessLogon maxMsgAge acceptableCompIDPairSet strm fieldIndex buf 
       
        while true do
    
            let numBytesRead = ReadAllMsgBytes strm buf

            let indexEnd                = FIXBufIndexer.BuildIndex fieldIndex buf numBytesRead
            let index                   = FIXBufIndexer.IndexData (indexEnd, fieldIndex)            
            
            
            let mutable numBytes = strm.Read(buf, 0, bufSize ) // times out after readTimeout millisecs
                
            if numBytes = 0 then
                () // read timeout, send heartbeat if neccessary - inner reads, while reading up to the end of a msg do not process session logic
            else
                let indexEnd                = FIXBufIndexer.BuildIndex fieldIndex buf numBytes
                let index                   = FIXBufIndexer.IndexData (indexEnd, fieldIndex)
                
                // TODO: don't use hard coded fix tags
                let (MsgSeqNum seqNum)      = GenericReaders.ReadField buf index 34 FieldReaders.ReadMsgSeqNum
                let senderCompID            = GenericReaders.ReadField buf index 49 FieldReaders.ReadSenderCompID
                let (SendingTime sendTime)  = GenericReaders.ReadField buf index 52 FieldReaders.ReadSendingTime
                let targetCompID            = GenericReaders.ReadField buf index 56 FieldReaders.ReadTargetCompID
                let msgType                 = GenericReaders.ReadField buf index 35 FieldReaders.ReadMsgType
                
                //what is an elegant way to deal with Option price and Option quantity


                // todo: check seq num and compIDs
                // in qf.net see Session.Next / Session.NextMessage

                let msgDu = 
                    match msgType with
                    //| MsgType.Heartbeat     -> ()
                    //| MsgType.Logon         -> ()
                    //| MsgType.TestRequest   -> ()
                    //| MsgType.ResendRequest -> ()
                    //| MsgType.Reject        -> ()
                    //| MsgType.SequenceReset -> ()
                    //| MsgType.Logout        -> ()
                    | MsgType.NewOrderSingle            -> 

                        let nos = MsgReaders.ReadNewOrderSingle buf index
                        match nos.Price, nos.OrderQtyData.OrderQty with
                        | Some prc, Some qty -> //todo: is there an awkard mix of imperative with functional here ??
                                
                            let clOrdId = nos.ClOrdID
                            let orderID = OrderID   "ORDERID" // todo: generate orderID
                            let execID  = ExecID    "EXECID"  // todo: generate executionID
                            let leavesQty = LeavesQty 0.0m
                            let cumQty = CumQty qty.Value
                            let executionPrice =
                                match nos.OrdType with
                                | OrdType.Limit     -> prc.Value
                                | OrdType.Market    -> 10.0m // this is demo app, consider the market price to be 10.0
                                | ot                -> failwithf "unsupported order type: %A" ot
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

                            execRep2 |> Fix44.MessageDU.FIXMessage.ExecutionReport
                        | _      -> failwithf "order: %A, zero price for limit order" nos.ClOrdID
                //| MsgType.OrderCancelRequest        -> ()
                //| MsgType.OrderCancelReplaceRequest -> ()
                //| MsgType.News                      -> ()
                    | _                                 -> failwith "unexpected msg received "
                            
                let sendingTime = DateTimeOffset.UtcNow |> UTCDateTime.MakeUTCTimestamp.Make |> SendingTime
                currentSeqNum <- currentSeqNum + 1u
                let senderCompIdOut = "acceptor" |> SenderCompID
                let targetCompIdOut = "initiator" |> TargetCompID
                let msgSeqNum = currentSeqNum |> MsgSeqNum
                Array.Clear(buf, 0, buf.Length)
                let bytesWritten = MsgReadWrite.WriteMessageDU tmpBuf buf 0 fix44 senderCompIdOut targetCompIdOut msgSeqNum sendingTime msgDu
                strm.Write( buf, 0, bytesWritten )
            ()
        ()
    
    let thread = Thread threadFunc
    thread.Start();
    




let ConnectionListenerLoop (maxMsgAge:TimeSpan) (acceptableCompIDPairSet: (TargetCompID*SenderCompID) Set) (bufSize:int) (listener:TcpListener) =
    let asyncConnectionListener =
        async {
            while true do
                use! client = listener.AcceptTcpClientAsync () |> Async.AwaitTask
                do AcceptorLoop maxMsgAge acceptableCompIDPairSet bufSize client
        }

    Async.StartWithContinuations(
        asyncConnectionListener,
        (fun _  -> printfn "ConnectionListener completed"),
        ConnectionListenerError,
        (fun ct -> printfn "ConnectionListener cancelled: %A" ct)
    )