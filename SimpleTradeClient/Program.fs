open System.Net.Sockets

open Fix44.Messages
open Fix44.Fields






[<EntryPoint>]
let main argv_ = 

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
    
    let news = {
        OrigTime = None
        Urgency = None
        Headline = Headline "a news headline"
        EncodedHeadline = None
        NoRoutingIDsGrp = None
        NoRelatedSymGrp = None
        NoLegsGrp = None
        NoUnderlyingsGrp = None
        LinesOfTextGrp = []
        URLLink = None
        RawData = None
        }



    let host = "localhost"
    let port = 5001
    use client = new TcpClient() 
    client.Connect (host, port)
    let strm = client.GetStream()

    let mutable seqNum = 0u

    let logonMsg = Fix44.MessageDU.FIXMessage.Logon logon
    let newsMsg =  Fix44.MessageDU.FIXMessage.News news
    let utcNow = System.DateTime.UtcNow
    let beginString = BeginString "FIX.4.4"
    let senderCompID = SenderCompID "CLIENT1"
    let targetCompID = TargetCompID "EXECUTOR" // also for quickFixEcho
//    let targetCompID = TargetCompID "SIMPLE"
    seqNum <- seqNum + 1u
    let msgSeqNumLogon = MsgSeqNum seqNum
    let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Millisecond)
    let sendingTime = SendingTime ts
    
    let tmpBuf = Array.zeroCreate<byte> 2048
    let buf = Array.zeroCreate<byte> 2048
    let posW = MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString senderCompID targetCompID msgSeqNumLogon sendingTime logonMsg

    do strm.Write (buf, 0, posW)
    printfn "logon sent"


    let bufOut = Array.zeroCreate<byte> 2048
    let ii = strm.Read (bufOut, 0, 2048)
    let strReceived = FIXBuf.toS bufOut ii
    printfn "logon reply: %s" strReceived
    
    let logonMsgReply = MsgReadWrite.ReadMessage bufOut

    while true do
        printfn "press any key to send news msg"
        let ss = System.Console.ReadKey()
        let tmpBuf2 = Array.zeroCreate<byte> 2048
        let buf2 = Array.zeroCreate<byte> 2048
        seqNum <- seqNum + 1u
        let msgSeqNumNews = MsgSeqNum seqNum
        let posWnews = MsgReadWrite.WriteMessageDU tmpBuf2 buf2 0 beginString senderCompID targetCompID msgSeqNumNews sendingTime newsMsg
        let strSendNews = FIXBuf.toS buf2 posWnews
        do strm.Write (buf2, 0, posWnews)
        printfn "   send: %s" strSendNews
        
        let buf3 = Array.zeroCreate<byte> 2048
        let ii3 = strm.Read (buf3, 0, 2048)
        let strReceivedNews = FIXBuf.toS buf2 ii3
        printfn "received: %s" strReceivedNews
        //let posR, newsMsgOut = MsgReadWrite.ReadMessage buf3


//        let asyncRequestResponse = 
//            async{
//                do! client.ConnectAsync (host, port) |> Async.AwaitTask
//                let strm = client.GetStream()
//                do! strm.AsyncWrite (buf, 0, posW)
//                let! numRead = strm.AsyncRead (bufOut, 0, 2048)
//                let posR, msgOut = MsgReadWrite.ReadMessage bufOut
//                return msgOut    
//            }
//        let replyMsg = asyncRequestResponse |> Async.RunSynchronously
        ()



    0 // return an integer exit code










