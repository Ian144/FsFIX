open System.Net.Sockets

open Fix44.Messages
open Fix44.Fields






[<EntryPoint>]
let main argv_ = 

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
//    let targetCompID = TargetCompID "EXECUTOR"
    let targetCompID = TargetCompID "SIMPLE"
    let msgSeqNum = MsgSeqNum 1u
    let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Millisecond)
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

    // C:\Users\Ian\Documents\Src\dotnet451\Source\ndp\clr\src\BCL\System\ArraySegment.cs                                
//    let arraySeg = System.ArraySegment(buf, 0, posW)
    //let xx = arraySeg.[0]

    let host = "localhost"
    let port = 5001
    let client = new TcpClient() 
    client.Connect (host, port)
    let strm = client.GetStream()
    do strm.Write (buf, 0, posW)
    printfn "write complete"

    let bufOut = Array.zeroCreate<byte> 2048
    let ii = strm.Read (bufOut, 0, 2048)
    let posR, msgOut = MsgReadWrite.ReadMessage bufOut



//    let asyncRequestResponse = 
//        async{
//            do! client.ConnectAsync (host, port) |> Async.AwaitTask
//            let strm = client.GetStream()
//            do! strm.AsyncWrite (buf, 0, posW)
//            let! numRead = strm.AsyncRead (bufOut, 0, 2048)
//            let posR, msgOut = MsgReadWrite.ReadMessage bufOut
//            return msgOut    
//        }
//    let replyMsg = asyncRequestResponse |> Async.RunSynchronously


    let ss = System.Console.ReadLine()



    0 // return an integer exit code




