module FsFix.Session.Acceptor


open System
open System.Net.Sockets
open System.Threading
open System.IO


open Fix44
open Fix44.Fields

open Session.Types

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

    // todo: ensure read-timeout is set sensibly
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



let ValidateMsg (maxMsgAge:TimeSpan) (acceptableCompIDPairSet: (TargetCompID*SenderCompID) Set) (buf:byte[]) (index:FIXBufIndexer.IndexData) : unit = 
    let fixVersion              = GenericReaders.ReadField buf index 8  FieldReaders.ReadBeginString
    let (MsgSeqNum seqNum)      = GenericReaders.ReadField buf index 34 FieldReaders.ReadMsgSeqNum
    let senderCompID            = GenericReaders.ReadField buf index 49 FieldReaders.ReadSenderCompID
    let (SendingTime sendTime)  = GenericReaders.ReadField buf index 52 FieldReaders.ReadSendingTime
    let targetCompID            = GenericReaders.ReadField buf index 56 FieldReaders.ReadTargetCompID

    // todo: make the success case expected, for branch prediction
    // todo read and check fix version
    if fix44 <> fixVersion then
        failwithf "message contains unsupported fix version: %A" fixVersion

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
    ()





let ProcessLogon (sessionConfig:SessionConfig) (strm:Stream) (fieldIndex:FIXBufIndexer.FieldPos []) (buf:byte[]) =
    
    //http://javarevisited.blogspot.co.uk/2011/02/fix-protocol-session-or-admin-messages.html


    let numBytesRead = ReadAllMsgBytes strm buf
    // todo: deal with zero bytes read, or use infinite read timeout

    let indexEnd                = FIXBufIndexer.BuildIndex fieldIndex buf numBytesRead
    let index                   = FIXBufIndexer.IndexData (indexEnd, fieldIndex)
    
    ValidateMsg sessionConfig.MaxMsgAge sessionConfig.AcceptedCompIDPairs buf index

    let msgType                 = GenericReaders.ReadField buf index 35 FieldReaders.ReadMsgType

    let msgTypeOK = msgType = MsgType.Logon
    if not msgTypeOK then
        failwithf "logon failure: invalid msg type received: %A" msgType

    let logonMsg = MsgReaders.ReadLogon buf index

    let initiatorMaxMsgSize = logonMsg.MaxMessageSize
    let (HeartBtInt initiatorHeartbeatInterval) = logonMsg.HeartBtInt

    let heartbeatIntervalAsAgreed = initiatorHeartbeatInterval = sessionConfig.HeartbeatInterval
    if not heartbeatIntervalAsAgreed then
        failwithf "logon fail: unacceptable heartbeat interval in logon msg, expected %d, received: %d" sessionConfig.HeartbeatInterval initiatorHeartbeatInterval

    let maxMsgSizeOk = 
        match initiatorMaxMsgSize with
        | Some (MaxMessageSize initMaxMsgSizeRaw)   -> sessionConfig.MaxMsgSize = initMaxMsgSizeRaw
        | None                                      -> false

    if not maxMsgSizeOk then
        failwithf "logon fail: unacceptable max message size in logon msg, expected %d, received: %A" sessionConfig.MaxMsgSize  initiatorMaxMsgSize

    printfn "%A" logonMsg
    printfn "logon successfull"
    logonMsg    // the correct sender and target compIds will be set in MsgReadWrite.WriteMessageDU
    //let replyLogonMsg = logonMsg    // the correct sender and target compIds will be set in MsgReadWrite.WriteMessageDU
    //replyLogonMsg, sessionConfig.MaxMsgSize , sessionConfig.HeartbeatInterval




let ProcessMsg applicationMsgProcessor cfg bufSize (strmIn:Stream) =

    let buf                         = Array.zeroCreate<byte> bufSize
    let tmpBuf                      = Array.zeroCreate<byte> bufSize
    let fieldIndex                  = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 8) // one element for each field, assuming max 8k fields in a FIX msg
    let senderCompIdOut             = "acceptor"    |> SenderCompID // todo: take this from config
    let targetCompIdOut             = "initiator"   |> TargetCompID // todo: take this from config
    let mutable currentSeqNum       = 1u
    
    // todo: add logging, are windows event generation or some such, so long as its fast

    let threadFunc () = 

        let strm = strmIn
        strm.ReadTimeout <- 10000 // todo: ensure read-timeout is set sensibly

        let replyLogonMsg = ProcessLogon cfg strm fieldIndex buf |> Fix44.MessageDU.FIXMessage.Logon

        let sendingTime = DateTimeOffset.UtcNow |> UTCDateTime.MakeUTCTimestamp.Make |> SendingTime
        let msgSeqNum = currentSeqNum |> MsgSeqNum
        let bytesWritten = MsgReadWrite.WriteMessageDU tmpBuf buf 0 fix44 senderCompIdOut targetCompIdOut msgSeqNum sendingTime replyLogonMsg
        strm.Write( buf, 0, bytesWritten )

        while true do
    
            let numBytesRead = ReadAllMsgBytes strm buf

            if numBytesRead = 0 then
                // read timeout, send heartbeat if neccessary - inner reads, while reading up to the end of a msg do not process session logic
                // is there are heartbeat timeout? logout if required
                ()
            else
                let indexEnd = FIXBufIndexer.BuildIndex fieldIndex buf numBytesRead
                let index = FIXBufIndexer.IndexData (indexEnd, fieldIndex)
                
                ValidateMsg cfg.MaxMsgAge cfg.AcceptedCompIDPairs buf index // throws if validation fails
                
                let msgType = GenericReaders.ReadField buf index 35 FieldReaders.ReadMsgType

                let initialSizeResendMsgs   = 1024 * 16
                let (resendMsgs:ResizeArray<Fix44.MessageDU.FIXMessage>) = ResizeArray(initialSizeResendMsgs) // todo: consider using a circular buffer if the number of resendable msgs that need to be stored is limited to some fixed value

                let msgs = 
                    match msgType with
                    | MsgType.Heartbeat     -> []
                    | MsgType.Logon         ->  let msg = MsgReaders.ReadLogon buf index
                                                failwithf "recevied logon msg, when already logged on: %A" msg
                                                // todo - does a reject msg need to be sent
                                                []
                    | MsgType.TestRequest   ->  []
                    | MsgType.ResendRequest ->  //https://www.onixs.biz/fix-dictionary/4.4/msgType_2_2.html
                                                let msg = MsgReaders.ReadResendRequest buf index
                                                let (BeginSeqNo bb)  = msg.BeginSeqNo
                                                let (EndSeqNo ee) = msg.EndSeqNo
                                                let iBb = (int bb) - 1 // arrays are zero based, the first seq num is always 1

                                                // arrays are zero based, the first seq num is always 1
                                                // an EndSeqNo of '0' means infinity, i.e. resend all msgs from begin seqNo until the end
                                                // todo: filter out ordersbeing resent if they are older than a threshold
                                                let iEe = if ee = 0u then (resendMsgs.Count - 1) else (int ee) - 1 

                                                if iBb < 0 || iEe >= resendMsgs.Count then
                                                    let maxSeqNumStored = 1 + resendMsgs.Count
                                                    failwithf "invalid ResendRequest range, beg: %d, end: %d, curMax: %d" bb ee maxSeqNumStored

                                                resendMsgs.GetRange(iBb, (iEe - iBb)) |> Seq.toList // return an empty list if no reply required
                    | MsgType.Reject        ->  []        
                    | MsgType.SequenceReset ->  [] 
                    | MsgType.Logout        ->  []              
                    | mt                    ->  applicationMsgProcessor mt index buf resendMsgs

                let sendingTime = DateTimeOffset.UtcNow |> UTCDateTime.MakeUTCTimestamp.Make |> SendingTime
                currentSeqNum <- currentSeqNum + 1u
                let msgSeqNum = currentSeqNum |> MsgSeqNum
                Array.Clear(buf, 0, buf.Length)
                // todo: ######################## send all msgs, including resends?
                // todo: 
                let bytesWritten = MsgReadWrite.WriteMessageDU tmpBuf buf 0 fix44 senderCompIdOut targetCompIdOut msgSeqNum sendingTime (msgs.Head)
                strm.Write( buf, 0, bytesWritten )
                ()
        ()
    
    let thread = Thread threadFunc
    thread.Start();


let MsgLoop appMsgProcessor sessionConfig (bufSize:int) (listener:TcpListener) =

    let asyncConnectionListener =
        async {
            while true do
                let! client = listener.AcceptTcpClientAsync () |> Async.AwaitTask
                client.NoDelay                  <- true
                client.ReceiveBufferSize        <- bufSize
                client.SendBufferSize           <- bufSize
                let strm                        = client.GetStream() // 'use strm' is inside the thread created by ProcessMsg
                strm.ReadTimeout                <- readTimeout
                //todo: client.LingerState <-
                do ProcessMsg appMsgProcessor sessionConfig bufSize strm // ProcessMsg creates a thread to handle incoming msgs, then returns immediately
        }

    Async.StartWithContinuations(
        asyncConnectionListener,
        (fun _  -> printfn "ConnectionListener completed"),
        ConnectionListenerError,
        (fun ct -> printfn "ConnectionListener cancelled: %A" ct)
    )