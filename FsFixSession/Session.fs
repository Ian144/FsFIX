module FsFix.Session

open System
open System.Net.Sockets
open System.Threading

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


let countFieldSeperators (buf:byte array) endPos = 
    let mutable numSeps:uint32 = 0u
    let mutable pos:int = 0
    while pos < endPos do
        if buf.[pos] = 1uy then
            numSeps <- numSeps + 1u
    numSeps

let ProcessLogon (maxMsgAge:TimeSpan) (utcNow:DateTimeOffset) (acceptableCompIDPairSet: (TargetCompID*SenderCompID) Set) (strm:System.IO.Stream) (fieldIndex:FIXBufIndexer.FieldPos []) (buf:byte[]) : Unit =
    
    let mutable numBytes = strm.Read(buf, 0, bufSize ) // times out after readTimeout millisecs
                
    // ensure that the first two fields are present by reading beyond the max plausible end of the second
    // the first field contains the fix version
    // the second field contains the length of the msg body, allowing the rest of the bytes to be read before msg parsing
    // TODO: make min bytes to read configurable
    let minBytesToRead = 32
    while minBytesToRead > numBytes do
        let numBytesInner = strm.Read(buf, numBytes, bufSize-numBytes )
        numBytes <- numBytes + numBytesInner


    //8=FIX.4.2|9=65|35=A|49=SERVER|56=CLIENT|34=177|52=20090107-18:15:16|98=0|108=30|10=062|
    let mutable firstSepPos = 0
    while buf.[firstSepPos] <> 1uy && firstSepPos < numBytes do
        firstSepPos <- firstSepPos + 1

    let mutable secondSepPos = firstSepPos + 1
    while buf.[secondSepPos] <> 1uy && firstSepPos < numBytes do
        secondSepPos <- secondSepPos + 1

    if firstSepPos <> numBytes && secondSepPos <> numBytes then
        let firstMsgIsBeginString = buf.[0] = 56uy && buf.[1] = 61uy
        let secondMsgIsBodyLen = buf.[firstSepPos+1] = 57uy && buf.[firstSepPos+2] = 61uy

        if firstMsgIsBeginString && secondMsgIsBodyLen then
            let (Fix44.Fields.BeginString fixVer) = Fix44.FieldReaders.ReadBeginString buf 2 (firstSepPos - 2)

            if fixVer = "FIX.4.4" then

                let beginingOfLen = firstSepPos + 3
                let (Fix44.Fields.BodyLength bodyLen) = Fix44.FieldReaders.ReadBodyLength buf beginingOfLen (secondSepPos - beginingOfLen)
                
                let totalLen = secondSepPos + (int32 bodyLen) + checksumLen + 1 //+1 as the buffer is zero based

                // read the rest of the msg bytes from the buffer
                while totalLen > numBytes do
                    let numBytesInner = strm.Read( buf, numBytes, bufSize-numBytes )
                    numBytes <- numBytes + numBytesInner

                // TODO: don't use hard coded fix tags
                let indexEnd                = FIXBufIndexer.BuildIndex fieldIndex buf numBytes
                let index                   = FIXBufIndexer.IndexData (indexEnd, fieldIndex)
                let (MsgSeqNum seqNum)      = GenericReaders.ReadField buf index 34 Fix44.FieldReaders.ReadMsgSeqNum
                let senderCompID            = GenericReaders.ReadField buf index 49 Fix44.FieldReaders.ReadSenderCompID
                let (SendingTime sendTime)  = GenericReaders.ReadField buf index 52 Fix44.FieldReaders.ReadSendingTime
                let targetCompID            = GenericReaders.ReadField buf index 56 Fix44.FieldReaders.ReadTargetCompID
                
                let dtoSendTime = UTCDateTime.MakeUTCTimestamp.MakeDTO sendTime
                let msgAge = (dtoSendTime - utcNow)
                let sendTimeOk = maxMsgAge >= msgAge
                if not sendTimeOk then
                    failwithf "logon failure: max acceptable msg age: %A, actual msg age: %A" maxMsgAge  msgAge

                let seqNumOk = (0u = seqNum)
                if not seqNumOk then
                    failwithf "logon failure: expected '0' sequence number, actual: %d" seqNum


                let compIDsOk = acceptableCompIDPairSet.Contains (targetCompID, senderCompID)
                if not compIDsOk then
                    failwithf "logon failure: invalid target and sender compIDs: %A" (targetCompID, senderCompID)

                // does imperative logic make returning a Choice2 difficult

                let logonMsg = Fix44.MsgReaders.ReadLogon buf index
                printfn "%A" logonMsg

                ()
                //match msg with
                //|  Fix44.MessageDU.FIXMessage.Logon logonMsg    -> 
                //        // TODO: check username and password in logon msg??
                //        ()
                //|   _                                           -> 
                //        let tag = Fix44.MessageDU.GetTag msg
                //        let tagStr = Conversions.bytesToStr tag 0 tag.Length
                //        failwithf "expected Logon msg, recieved msg type: %s" tagStr
            else
                failwithf "logon failure: unexpected FIX version in BeginString field: %s, currently only FIX.4.4 supported" fixVer
        else
            failwith "logon failure: first two msg fields are not BeginString and BodyLen"
    else
        failwith "logon failure: first two field seperators not found in msg bytes read"
    ()


//todo: consider let AcceptorLoop msgProcessorFunc (bufSize:int) (client:TcpClient) =
let AcceptorLoop (bufSize:int) (client:TcpClient) =
    //todo: client.LingerState <-
    client.NoDelay              <- true
    client.ReceiveBufferSize    <- bufSize
    client.SendBufferSize       <- bufSize
    let strm = client.GetStream()
    strm.ReadTimeout <- readTimeout
    let buf = Array.zeroCreate<byte> bufSize
    let fieldIndex = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 8) // one element for each field
    let trgCompId = TargetCompID "acceptor"
    let sndCompId = SenderCompID "initiator"
    
    
    // TODO, read these from config
    let acceptedCompIDPairs = Set.empty |> Set.add (trgCompId, sndCompId)
    let maxMsgAge = new TimeSpan(0,0,30)

    let threadFunc _ = 

        let utcNow = DateTimeOffset.UtcNow
        
        // process a received logon msg
        // TODO return Choice2of2 if not successfull
        ProcessLogon maxMsgAge utcNow acceptedCompIDPairs strm fieldIndex buf 


        //TODO set thread affinity
        //https://stackoverflow.com/questions/2510593/how-can-i-set-processor-affinity-in-net

        // am (prematurly?) optimising this code, prefering inline while loops to functions when advancing through the byte buffer
        // F# allows imperative style code

       
        while true do
            let mutable numBytes = strm.Read(buf, 0, bufSize ) // times out after readTimeout millisecs
                
            if numBytes = 0 then
                () // read timeout, send heartbeat if neccessary - inner reads, while reading up to the end of a msg do not process session logic
            else

                // ensure that the first two fields are present by reading beyond the max plausible end of the second
                // make min bytes to read configurable
                let minBytesToRead = 32
                while minBytesToRead > numBytes do
                    let numBytesInner = strm.Read(buf, numBytes, bufSize-numBytes )
                    numBytes <- numBytes + numBytesInner

                let mutable firstSepPos = 0
                while buf.[firstSepPos] <> 1uy && firstSepPos < numBytes do
                    firstSepPos <- firstSepPos + 1

                let mutable secondSepPos = firstSepPos + 1
                while buf.[secondSepPos] <> 1uy && firstSepPos < numBytes do
                    secondSepPos <- secondSepPos + 1

                if firstSepPos <> numBytes && secondSepPos <> numBytes then
                    let firstMsgIsBeginString = buf.[0] = 56uy && buf.[1] = 61uy
                    let secondMsgIsBodyLen = buf.[firstSepPos+1] = 57uy && buf.[firstSepPos+2] = 61uy

                    let beginString = Fix44.FieldReaders.ReadBeginString buf 2 (firstSepPos - 2)
                    let beginingOfLen = firstSepPos + 3
                    let (Fix44.Fields.BodyLength bodyLen) = Fix44.FieldReaders.ReadBodyLength buf beginingOfLen (secondSepPos - beginingOfLen)
                
                    let totalLen = secondSepPos + (int32 bodyLen) + checksumLen + 1 //+1 as the buffer is zero based

                    while totalLen > numBytes do
                        let numBytesInner = strm.Read(buf, numBytes, bufSize-numBytes )
                        numBytes <- numBytes + numBytesInner
                else
                    failwith "first two field seperators not found in msg bytes read"



                //let msgIn = MsgReadWrite.ReadMessage buf totalLen fieldPosArr
                //printfn "xxxxxxxxxxxx"
                // is msg a logon msg - ensure with 
                // compIds valid
                // send
                // have enought bytes been read toin clude the length prefix?
                // are there at least two '|'s in the msg, the second should contian the length
                () 


            ()
        ()
    
    let thread = Thread(ThreadStart(threadFunc))
    thread.Start();
    




let ConnectionListenerLoop (bufSize:int) (listener:TcpListener) =
    let asyncConnectionListener =
        async {
            while true do
                let acceptClientTask = listener.AcceptTcpClientAsync ()
                let! client = Async.AwaitTask acceptClientTask
                do AcceptorLoop bufSize client
        }

    Async.StartWithContinuations(
        asyncConnectionListener,
        (fun _  -> printfn "ConnectionListener completed"),
        ConnectionListenerError,
        (fun ct -> printfn "ConnectionListener cancelled: %A" ct)
    )