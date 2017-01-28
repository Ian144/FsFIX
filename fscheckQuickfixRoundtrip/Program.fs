
open System.Net.Sockets
open System
open FsCheck
open Swensen.Unquote

open Fix44.Fields
open Fix44.Messages
open Fix44.MessageDU



Arb.register<Generators.ArbOverrides>() |> ignore


let host = "localhost"
//let port = 5001
let port = 9880
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
//let senderCompID = SenderCompID "CLIENT1"
//let targetCompID = TargetCompID "EXECUTOR" // also for quickFixEcho
let senderCompID = SenderCompID "BANZAI"
let targetCompID = TargetCompID "EXEC" // also for quickFixEcho
// from banzai.cfg
//SenderCompID=BANZAI
//TargetCompID=EXEC


let mutable seqNum = 51u
let msgSeqNum = MsgSeqNum seqNum
let utcNow = System.DateTime.UtcNow
let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Millisecond)
let sendingTime = SendingTime ts

let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 16)

let bufSize = 1024 * 64

let tmpBuf = Array.zeroCreate<byte> bufSize
let buf = Array.zeroCreate<byte> bufSize
let posW = MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString senderCompID targetCompID msgSeqNum sendingTime logonMsg
do strm.Write (buf, 0, posW)
printfn "logon sent"

let ii = strm.Read (buf, 0, bufSize)
printfn "logon reply: %d bytes received" ii
let logonMsgReply = MsgReadWrite.ReadMessage buf




let GetFieldBegin (index:FIXBufIndexer.FixBufIndex) (indexEnd:int) (tag:int) : int =
    let idx = FIXBufIndexer.FindFieldIdx index indexEnd tag
    match idx with
    | 0 ->  0
    | n ->  let prevIdx = n - 1 // find the end of the previous field
            let prevField = index.FieldPosArr.[prevIdx]
            prevField.Pos + prevField.Len

let IsLenField (tag:int) = 
    match tag with
    | 8 | 9 | 10    -> false
    | _             -> true
    
let IsHdrField (tag:int) = 
    match tag with
    | 35 | 34 | 49 | 52 | 56    -> true
    | _                         -> false


let IsQuickfixNLenDisagreementField (fp:FIXBufIndexer.FieldPos) =
    match fp.Tag with
    | 206   -> true // OptAttribute
    | 93    -> true // Signature
    | 90    -> true // SecureData
    | 95    -> true // RawData
    | 212   -> true // XmlData
    | 348   -> true // EncodedIssuer
    | 350   -> true // EncodedSecurityDesc
    | 352   -> true // EncodedListExecInst
    | 354   -> true // EncodedText
    | 356   -> true // EncodedSubject
    | 358   -> true // EncodedHeadline
    | 360   -> true // EncodedAllocText
    | 362   -> true // EncodedUnderlyingIssuer
    | 364   -> true // EncodedUnderlyingSecurityDesc
    | 445   -> true // EncodedListStatusText
    | 618   -> true // EncodedLegIssuer
    | 621   -> true // EncodedLegSecurityDesc
    | _       -> false


let isNotAdminMsg (msgIn:FIXMessage) = 
    match msgIn with
    | FIXMessage.Logon  _        -> false
    | FIXMessage.Logout _        -> false
    | FIXMessage.TestRequest _   -> false
    | FIXMessage.ResendRequest _ -> false
    | FIXMessage.Reject _        -> false
    | FIXMessage.SequenceReset _ -> false
    | FIXMessage.Heartbeat _     -> false
    | _                          -> true

let isHeartbeat (msg:FIXMessage) = 
    match msg with
    |  FIXMessage.Heartbeat  _  -> true
    |   _                       -> false



let tmpBuf2 = Array.zeroCreate<byte> bufSize

let mutable ctr = 0

let propSendMsgToQuickfixEchoConfirmReplyIsTheSame  (msgInXX:FIXMessage DoNotShrink) =
    let (DoNotShrink msgIn) = msgInXX
    if isNotAdminMsg msgIn then
        seqNum <- seqNum + 1u
        let msgSeqNum = MsgSeqNum seqNum
        let seqNumxx = seqNum
        printfn "entering seqNum: %d" seqNumxx
        let utcNow = System.DateTime.UtcNow
        let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Millisecond)
        let sendingTime = SendingTime ts

        System.Array.Clear (buf, 0, buf.Length)
        System.Array.Clear (tmpBuf, 0, tmpBuf.Length)
        System.Array.Clear (fieldPosArr, 0, fieldPosArr.Length)

        // send msg to quickfix echo
        let numBytesToSend = MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString  senderCompID targetCompID msgSeqNum sendingTime msgIn
        strm.Write (buf, 0, numBytesToSend)

        let indexEnd = FIXBufIndexer.Index fieldPosArr buf numBytesToSend
        let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)

        let bodyLenFieldIdx = 1 // bodyLen is always the 2nd field
        let bodyLenFieldPos = fieldPosArr.[bodyLenFieldIdx]
        let checkSumFieldPos = fieldPosArr.[indexEnd - 1] // checksum is always the last
        let firstByteAfterBodyLen = bodyLenFieldPos.Pos + bodyLenFieldPos.Len + 1
        let lastFieldTermBeforeChecksumPos = checkSumFieldPos.Pos - 4 // checkSumFieldPos.Pos contains the position of the checksum value, need to move back 4 to get to the prev field terminator
        let calcedBodyLen = lastFieldTermBeforeChecksumPos - (firstByteAfterBodyLen-1)

        
//            let endBodyLen2 = fieldPosArr.[1].Pos + fieldPosArr.[1].Len + 1
//            let endBodyLen = fieldPosArr.[2].Pos - 4 // 2 is the index of the msgTag, the tag + tag-value seperator length is 3
//            let endTargetCompId = fieldPosArr.[6].Pos + fieldPosArr.[6].Len
//            let hdrLen = endTargetCompId - endBodyLen
//            let nonHdrLen = lastFieldTermBeforeChecksumPos - endTargetCompId


//            let usedFields = fieldPosArr |> Array.take indexEnd
//            let lenFields = usedFields |> Array.filter (fun fp -> IsLenField fp.Tag)
//            let hdrFields, bodyFields = lenFields |> Array.partition (fun fp -> IsHdrField fp.Tag )
//
//            let getFieldBeg = GetFieldBegin index indexEnd

//            printfn "hdr fields\n--------"
//
//            hdrFields |> Array.iter (fun fp ->
//                let posB = getFieldBeg fp.Tag
//                let posE = fp.Pos + fp.Len
//                let len = posE - posB
//                printfn "%d - %d" fp.Tag len
//            )
//
//            printfn "body fields\n--------"
//
//            bodyFields |> Array.iter (fun fp ->
//                let posB = getFieldBeg fp.Tag
//                let posE = fp.Pos + fp.Len
//                let len = posE - posB
//                printfn "%d - %d" fp.Tag len
//            )

            // receive the reply, assuming all bytes are read
        let numBytesReceived = strm.Read (buf, 0, bufSize)



        let msgOut = MsgReadWrite.ReadMessage buf numBytesReceived
            
        let msgOut2 = 
            if isHeartbeat msgOut then
                let numBytesReceived = strm.Read (buf, 0, bufSize)
                MsgReadWrite.ReadMessage buf numBytesReceived
            else
                msgOut


        // uncomment and correct the path to your desktop to use beyondCompare to diff the sometimes large messages
        if msgIn <> msgOut then
            use swA = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\msgIn.fs""")
            use swB = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\msgOut.fs""")
            fprintfn swA "%A" msgIn
            fprintfn swB "%A" msgOut
            printfn "diffs persisted"

        printfn " leaving seqNum: %d" seqNumxx
        msgIn = msgOut2
    else
            true




let config = { Config.Quick with StartSize = 1; EndSize = 2; MaxTest = 1000 }


#nowarn "52"
let WaitForExitCmd () = 
    while stdin.Read() = 88 do // 88 is 'X'
        ()

Check.One (config, propSendMsgToQuickfixEchoConfirmReplyIsTheSame)


WaitForExitCmd ()


//todo:  log off


