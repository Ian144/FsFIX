
open System.Net.Sockets
open System
open FsCheck
open Swensen.Unquote

open Fix44.Fields
open Fix44.Messages
open Fix44.MessageDU



Arb.register<Generators.ArbOverrides>() |> ignore


let host = "localhost"
let port = 5001
let client = new TcpClient() 
client.Connect (host, port)
let strm = client.GetStream()


let logon =  {
        EncryptMethod = EncryptMethod.NoneOther
        HeartBtInt = HeartBtInt 60
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
let senderCompID = SenderCompID "CLIENT1"
let targetCompID = TargetCompID "EXECUTOR" // also for quickFixEcho
let mutable seqNum = 1u
let msgSeqNum = MsgSeqNum seqNum
let utcNow = System.DateTime.UtcNow
let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Millisecond)
let sendingTime = SendingTime ts

let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1024

let bufSize = 1024 * 64

let tmpBuf = Array.zeroCreate<byte> bufSize
let buf = Array.zeroCreate<byte> bufSize
let posW = MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString senderCompID targetCompID msgSeqNum sendingTime logonMsg
do strm.Write (buf, 0, posW)
printfn "logon sent"

let ii = strm.Read (buf, 0, bufSize)
printfn "logon reply: %d bytes received" ii
let logonMsgReply = MsgReadWrite.ReadMessage buf



let isNotLogonLogoff (msgIn:FIXMessage) = 
    match msgIn with
    | FIXMessage.Logon  _ -> false
    | FIXMessage.Logout _ -> false
    | _                   -> true


let propSendMsgToQuickfixEchoConfirmReplyIsTheSame  (msgIn:FIXMessage) =
    isNotLogonLogoff msgIn ==> lazy 
        printfn "%A" msgIn
        seqNum <- seqNum + 1u
        let msgSeqNum = MsgSeqNum seqNum
        let utcNow = System.DateTime.UtcNow
        let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Millisecond)
        let sendingTime = SendingTime ts

        // send msg to quickfix echo
        let numBytesToSend = MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString  senderCompID targetCompID msgSeqNum sendingTime msgIn
        strm.Write (buf, 0, numBytesToSend)

        let indexEnd = FIXBufIndexer.Index fieldPosArr buf posW
        let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)

        // receive the reply, assuming all bytes are read
        let numBytesReceived = strm.Read (buf, 0, bufSize)
        let msgOut = MsgReadWrite.ReadMessage buf numBytesReceived
    
        if msgIn <> msgOut then
            printfn "%A" msgIn
            printfn "\n-----------------------------------------------\n"
            printfn "%A" msgOut
        else
            printfn "\nok\n"

        // should be the same msg
//        msgIn =! msgOut
        true





let config = { Config.Quick with EndSize = 4; MaxTest = 10 }


#nowarn "52"
let WaitForExitCmd () = 
    while stdin.Read() <> 88 do // 88 is 'X'
        ()

Check.One (config, propSendMsgToQuickfixEchoConfirmReplyIsTheSame)


WaitForExitCmd ()


//todo:  log off


