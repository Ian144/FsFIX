open System
open System.Net.Sockets
open FsCheck

open Fix44.Fields
open Fix44.Messages
open Fix44.MessageDU



Arb.register<Generators.ArbOverrides>() |> ignore


//let pt = Fix44.Fields.PosType.AdjustmentQty


let host = "localhost"
//let port = 5001 // for quickFixN echo
let port = 9880 // for quickFixJ echo
let client = new TcpClient()
client.Connect (host, port)
let strm = client.GetStream()


let logon =  {
        EncryptMethod = EncryptMethod.NoneOther
        HeartBtInt = HeartBtInt 240
        RawData = None
        ResetSeqNumFlag = None
        NextExpectedMsgSeqNum = None
        MaxMessageSize = None
        NoMsgTypesGrp = None
        TestMessageIndicator = None
        Username = None
        Password = None
    }


let logonMsg = Fix44.MessageDU.FIXMessage.Logon logon
let beginString = BeginString "FIX.4.4"
//let senderCompID = SenderCompID "CLIENT1" // for quickFixN
//let targetCompID = TargetCompID "EXECUTOR" // for quickFixN
let senderCompID = SenderCompID "BANZAI"//for quickFixJ
let targetCompID = TargetCompID "EXEC" // for quickFixJ



let mutable seqNum = 1u
let msgSeqNum = MsgSeqNum seqNum
let utcNow = System.DateTime.UtcNow
let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Millisecond)
let sendingTime = SendingTime ts

let index = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 16)

let bufSize = 1024 * 128

let tmpBuf = Array.zeroCreate<byte> bufSize
let bufIn = Array.zeroCreate<byte> bufSize
let bufOut = Array.zeroCreate<byte> bufSize
let posW = MsgReadWrite.WriteMessageDU tmpBuf bufIn 0 beginString senderCompID targetCompID msgSeqNum sendingTime logonMsg
do strm.Write (bufIn, 0, posW)
printfn "logon sent"

let numBytesReceived = strm.Read (bufIn, 0, bufSize)
printfn "logon reply: %d bytes received" numBytesReceived
let logonMsgReply = MsgReadWrite.ReadMessage bufIn numBytesReceived



let msgExclusions (msgIn:FIXMessage) =
    match msgIn with
    | FIXMessage.Logon  _                    -> false // admin
    | FIXMessage.Logout _                    -> false // admin
    | FIXMessage.TestRequest _               -> false // admin
    | FIXMessage.ResendRequest _             -> false // admin
    | FIXMessage.Reject _                    -> false // admin
    | FIXMessage.SequenceReset _             -> false // admin
    | FIXMessage.Heartbeat _                 -> false // admin
    | FIXMessage.BusinessMessageReject _     -> false // causes quickfixj echo to stall, suspect this is an 'admin like' msg
    | _                                      -> true


let isHeartbeat (msg:FIXMessage) =
    match msg with
    |  FIXMessage.Heartbeat  _  -> true
    |   _                       -> false



// #### quickfixN diagnosis funcs
let GetFieldBegin (index:FIXBufIndexer.IndexData) (indexEnd:int) (tag:int) : int =
    let idx = FIXBufIndexer.FindFieldIdx index indexEnd tag
    match idx with
    | 0 ->  0
    | n ->  let prevIdx = n - 1 // find the end of the previous field
            let prevField = index.FieldPosArr.[prevIdx]
            prevField.Pos + prevField.Len + 1

let IsLenField (tag:int) = 
    match tag with
    | 8 | 9 | 10    -> false
    | _             -> true
    
let IsHdrField (tag:int) = 
    match tag with
    | 35 | 34 | 49 | 52 | 56    -> true
    | _                         -> false


let DisplayLengths (index:FIXBufIndexer.FieldPos array) (indexEnd:int) (bs:byte array) = 
    let indexData = FIXBufIndexer.IndexData (indexEnd, index)
  
    let usedFields = index |> Array.toList  |> List.take indexEnd |> List.skip 2 |> List.rev |> List.skip 1 |> List.rev
    let hdrFields, bodyFields = usedFields |> List.partition (fun fp -> IsHdrField fp.Tag )
    
    let getFieldBeg = GetFieldBegin indexData indexEnd

    let hdrLens = hdrFields |> List.map (fun xx -> 
        let fldB = getFieldBeg xx.Tag
        let fldE = xx.Pos + xx.Len
        let len = (fldE - fldB) + 1
        xx.Tag, len
        )

    let bodyLens = bodyFields |> List.map (fun xx -> 
        let fldB = getFieldBeg xx.Tag
        let fldE = xx.Pos + xx.Len
        let len = (fldE - fldB) + 1
        xx.Tag, len
        )

    let hdrLen = hdrLens    |> List.sumBy (fun (_, len) -> len)
    let bodyLen = bodyLens  |> List.sumBy (fun (_, len) -> len)
    
    printfn "calced len: %d" (hdrLen+bodyLen)
    printfn "hdr fields: %d" hdrLen
    hdrLens |> List.iter (printfn "%A")

    printfn "body fields: %d" bodyLen
    bodyLens |> List.iter (printfn "%A")

    ()


let propSendMsgToQuickfixEchoConfirmReplyIsTheSame (msgInDNS:FIXMessage DoNotShrink) =
    let (DoNotShrink msgIn) = msgInDNS
    if msgExclusions msgIn then // not using ==> lazy as that results in multiple property tests running concurrently
        seqNum <- seqNum + 1u
        let msgSeqNum = MsgSeqNum seqNum
        let utcNow = System.DateTime.UtcNow
        let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Millisecond)
        let sendingTime = SendingTime ts

        System.Array.Clear (bufIn, 0, bufIn.Length)
        System.Array.Clear (tmpBuf, 0, tmpBuf.Length)
        System.Array.Clear (bufOut, 0, bufIn.Length)
        System.Array.Clear (index, 0, index.Length)

        // send msg to quickfix echo
        let numBytesToSend = MsgReadWrite.WriteMessageDU tmpBuf bufIn 0 beginString  senderCompID targetCompID msgSeqNum sendingTime msgIn
        let indexEnd = FIXBufIndexer.BuildIndex index bufIn numBytesToSend
        let tag = GetTag msgIn
        let sTag = FIXBuf.toS tag tag.Length
        printfn "35=%s" sTag
        //DisplayLengths index indexEnd bufIn
            
        strm.Write (bufIn, 0, numBytesToSend)

        let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 8)
        // receive the reply, assuming all bytes are read
        let numBytesReceived = strm.Read (bufOut, 0, bufSize)
        let msgOut = MsgReadWrite.ReadMessage bufOut numBytesReceived fieldPosArr

        let msgOut2 =
            if isHeartbeat msgOut then
                System.Array.Clear (bufIn, 0, bufIn.Length)
                let numBytesReceived = strm.Read (bufIn, 0, bufSize)
                Array.Clear (fieldPosArr, 0, fieldPosArr.Length)
                MsgReadWrite.ReadMessage bufIn numBytesReceived fieldPosArr
            else
                msgOut

//             uncomment and correct the path for your to use beyondCompare or similar to diff the sometimes large messages
        let ok = msgIn = msgOut2
        if ok then
            true
        else
            use swA = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\msgIn.fs""")
            use swB = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\msgOut.fs""")
            use swBytesA = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\msgInBytes.fs""")
            use swBytesB = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\msgOutBytes.fs""")
            fprintfn swA "%A" msgIn
            fprintfn swB "%A" msgOut2
            fprintfn swBytesA "%s" (FIXBuf.toS bufIn numBytesToSend)
            fprintfn swBytesB "%s" (FIXBuf.toS bufOut numBytesReceived)
            printfn "diffs persisted"
            false
    else // msg is an admin msg
        true



let config = { Config.Quick with StartSize = 1; EndSize = 8; MaxTest = 100000000 }



#nowarn "52"
let WaitForExitCmd () =
    while stdin.Read() = 88 do // 88 is 'X'
        ()

Check.One (config, propSendMsgToQuickfixEchoConfirmReplyIsTheSame)


WaitForExitCmd ()


//todo:  log off


