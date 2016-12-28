open System.Net
open System.Net.Sockets

open Fix44.Messages
open Fix44.Fields






//type Logon = {
//    EncryptMethod: EncryptMethod
//    HeartBtInt: HeartBtInt
//    RawData: RawData option
//    ResetSeqNumFlag: ResetSeqNumFlag option
//    NextExpectedMsgSeqNum: NextExpectedMsgSeqNum option
//    MaxMessageSize: MaxMessageSize option
//    NoMsgTypesGrp: NoMsgTypesGrp list option // group
//    TestMessageIndicator: TestMessageIndicator option
//    Username: Username option
//    Password: Password option
//    }





//let MessageWithHeaderTrailer 
//        (beginString:BeginString) 
//        (senderCompID:SenderCompID) 
//        (targetCompID:TargetCompID) 
//        (msgSeqNum:MsgSeqNum) 
//        (sendingTime:SendingTime) 
//        (msg:FIXMessage) =
//    let buf = Array.zeroCreate<byte> bufSize
//    let tmpBuf = Array.zeroCreate<byte> bufSize
//    let posW = MsgReadWrite.WriteMessageDU 
//                                tmpBuf 
//                                buf 
//                                0 
//                                beginString 
//                                senderCompID
//                                targetCompID
//                                msgSeqNum
//                                sendingTime
//                                msg
//    let tmpBuf2 = Array.zeroCreate<byte> bufSize
//    let posR, msgOut = MsgReadWrite.ReadMessage buf tmpBuf2
//    msg =! msgOut
//    posW =! posR
//




[<EntryPoint>]
let main argv = 

    let logon =  {
        EncryptMethod = EncryptMethod.NoneOther
        HeartBtInt = HeartBtInt 30
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



    let utcNow = System.DateTime.UtcNow

    let beginString = BeginString "FIX.4.4"
    let senderCompID = SenderCompID "CLIENT1"
    let targetCompID = TargetCompID "EXECUTOR"
    let msgSeqNum = MsgSeqNum 1u
    let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second)
    let sendingTime = SendingTime ts

    



    let tmpBuf = Array.zeroCreate<byte> 2048
    let buf = Array.zeroCreate<byte> 2048


    let posW = MsgReadWrite.WriteMessageDU 
                                tmpBuf 
                                buf 
                                1 
                                beginString 
                                senderCompID
                                targetCompID
                                msgSeqNum
                                sendingTime
                                logonMsg
                                
    let arraySeg = System.ArraySegment(buf, 0, posW)

    let host = "localhost"
    let port = 5001
    let client = new TcpClient() 
    client.Connect (host, port)
    let strm = client.GetStream()
    let xx = strm.Write (buf, 0, posW)
    printfn "write complete"


    let bufOut = Array.zeroCreate<byte> 2048
    let bufOutInner = Array.zeroCreate<byte> 2048
    let ii = strm.Read (bufOut, 0, 2048)

    let posR, msgOut = MsgReadWrite.ReadMessage bufOut bufOutInner

    let ss = System.Console.ReadLine()


//    let xx = 
//        async{
//            do! client.ConnectAsync (host, port) |> Async.AwaitTask
//            let strm = client.GetStream()
//            do! strm.AsyncWrite (buf, posW)
//            printfn "async write complete"
//            return 0    
//        } |>  Async.RunSynchronously
//


    0 // return an integer exit code




