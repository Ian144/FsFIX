
open System.Net.Sockets
open System
open FsCheck
open Swensen.Unquote

open Fix44.Fields
open Fix44.Messages
open Fix44.MessageDU



Arb.register<Generators.ArbOverrides>() |> ignore


let host = "localhost"
//let port = 5001 // for quickFixN echo
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
//let targetCompID = TargetCompID "EXECUTOR" // also for quickFixN
let senderCompID = SenderCompID "BANZAI"
let targetCompID = TargetCompID "EXEC" // also for quickFixJ



let mutable seqNum = 1u
let msgSeqNum = MsgSeqNum seqNum
let utcNow = System.DateTime.UtcNow
let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Millisecond)
let sendingTime = SendingTime ts

let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 16)

let bufSize = 1024 * 128

let tmpBuf = Array.zeroCreate<byte> bufSize
let buf = Array.zeroCreate<byte> bufSize
let posW = MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString senderCompID targetCompID msgSeqNum sendingTime logonMsg
do strm.Write (buf, 0, posW)
printfn "logon sent"

let ii = strm.Read (buf, 0, bufSize)
printfn "logon reply: %d bytes received" ii
let logonMsgReply = MsgReadWrite.ReadMessage buf



// used to exclude msgs containing particular fields, by searching for the field in the msg index
let fieldExclusions (fp:FIXBufIndexer.FieldPos) =
    match fp.Tag with
//    | 206   -> true // OptAttribute   quickfixN had issues with this field
    | 212   -> true // XmlData, fscheck generators currently not creating valid but random xml for this field
    | _     -> false


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
    | FIXMessage.SettlementInstructions _    -> false // quickfixj echo'd msg missing optional SettlInstSource, excluding to help find other issues
    | FIXMessage.AllocationInstruction _     -> false // quickfixj echo returns these msgs with a populated AccruedInterestAmt which was None going in
    | _                                      -> true


let isHeartbeat (msg:FIXMessage) =
    match msg with
    |  FIXMessage.Heartbeat  _  -> true
    |   _                       -> false



let propSendMsgToQuickfixEchoConfirmReplyIsTheSame (msgInDNS:FIXMessage DoNotShrink) =
    let (DoNotShrink msgIn) = msgInDNS
    if msgExclusions msgIn then // not using ==> lazy as that means that multiple property tests will be running concurrently
        seqNum <- seqNum + 1u
        let msgSeqNum = MsgSeqNum seqNum
        let seqNumxx = seqNum
        let utcNow = System.DateTime.UtcNow
        let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Millisecond)
        let sendingTime = SendingTime ts

        System.Array.Clear (buf, 0, buf.Length)
        System.Array.Clear (tmpBuf, 0, tmpBuf.Length)
        System.Array.Clear (fieldPosArr, 0, fieldPosArr.Length)

        // send msg to quickfix echo
        let numBytesToSend = MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString  senderCompID targetCompID msgSeqNum sendingTime msgIn
        let _ = FIXBufIndexer.BuildIndex fieldPosArr buf numBytesToSend
        let excludedFields = fieldPosArr |> Array.filter fieldExclusions |> Array.length
        if excludedFields = 0 then
            printfn "sending seqNum: %d" seqNumxx
            strm.Write (buf, 0, numBytesToSend)


            // receive the reply, assuming all bytes are read
            let numBytesReceived = strm.Read (buf, 0, bufSize)
            let msgOut = MsgReadWrite.ReadMessage buf numBytesReceived
            printfn " reading reply seqNum: %d" seqNumxx
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
            msgIn = msgOut2
        else // numLenDataFields <> 0
            true
    else // msg is an admin msg
        true



let config = { Config.Quick with StartSize = 1; EndSize = 8; MaxTest = 10000000 }



#nowarn "52"
let WaitForExitCmd () =
    while stdin.Read() = 88 do // 88 is 'X'
        ()

Check.One (config, propSendMsgToQuickfixEchoConfirmReplyIsTheSame)


WaitForExitCmd ()


//todo:  log off


