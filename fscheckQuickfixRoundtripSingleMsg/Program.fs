
open System.Net.Sockets
open System

open Fix44.Fields
open Fix44.Messages
open Fix44.MessageDU





let host = "localhost"
//let port = 5001 // for quickFixN echo
let port = 9880
let client = new TcpClient()
client.Connect (host, port)
let strm = client.GetStream()


let logon = {
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



let timeStamp = UTCDateTime.MakeUTCTimestamp.Make(2017, 01, 31, 06, 37, 00)
let settlInst:SettlementInstructions = {
        SettlInstMsgID = SettlInstMsgID "XRVWQEI"
        SettlInstReqID = None
        SettlInstMode = Default
        SettlInstReqRejCode = None
        Text = None
        EncodedText = None
//        SettlInstSource = None  // outer SettlInstSource is None
        ClOrdID = None
        TransactTime = TransactTime timeStamp
        NoSettlInstGrp =
         Some
           [{SettlInstID = SettlInstID "OCWXBP"
             SettlInstTransType = None
             SettlInstRefID = None
             NoPartyIDsGrp = None
             Side = None
             Product = None
             SecurityType = None
             CFICode = None
             EffectiveTime = None   
             ExpireTime = None
             LastUpdateTime = None
             SettlInstructionsData = 
                {   SettlDeliveryType = Some SettlDeliveryType.Free
                    StandInstDbType = None
                    StandInstDbName = None
                    StandInstDbID = None
                    NoDlvyInstGrp = 
                        Some 
                            [{  SettlInstSource = Investor // inner SettlInstSource
                                DlvyInstType = None
                                NoSettlPartyIDsGrp = None 
                        }]
                }
             PaymentMethod = None
             PaymentRef = None
             CardHolderName = None
             CardNumber = None
             CardStartDate = None
             CardExpDate = None
             CardIssNum = None
             PaymentDate = None
             PaymentRemitterID = None}]
        } 

let siIn = Fix44.MessageDU.SettlementInstructions settlInst 

seqNum <- seqNum + 1u
let msgSeqNum2 = MsgSeqNum seqNum
//let seqNumxx = seqNum
//let utcNow = System.DateTime.UtcNow
//let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Millisecond)
//let sendingTime = SendingTime ts

System.Array.Clear (bufIn, 0, bufIn.Length)
System.Array.Clear (tmpBuf, 0, tmpBuf.Length)
System.Array.Clear (bufOut, 0, bufIn.Length)

// send msg to quickfix echo
let numBytesToSendSettleInst = MsgReadWrite.WriteMessageDU tmpBuf bufIn 0 beginString  senderCompID targetCompID msgSeqNum2 sendingTime siIn
do strm.Write (bufIn, 0, numBytesToSendSettleInst)


// receive the reply, assuming all bytes are read
let numBytesReceivedSettleInst = strm.Read (bufOut, 0, bufSize)
let siOut = MsgReadWrite.ReadMessage bufOut numBytesReceivedSettleInst


let index = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 8)// todo, make index size a parameter 
let indexEnd = FIXBufIndexer.BuildIndex index bufOut numBytesReceivedSettleInst
let indexdata = FIXBufIndexer.IndexData (indexEnd, index)
let SettlInstSourceFieldData = index |> Array.filter (fun fd -> fd.Tag = 165)

// uncomment and correct the path to your desktop to use beyondCompare to diff the sometimes large messages
if siIn <> siOut then
    use swA = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\settleInstructionsIn.fs""")
    use swB = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\settleInstructionsOut.fs""")
    use swBytesA = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\msgInBytes.fs""")
    use swBytesB = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\msgOutBytes.fs""")
    fprintfn swA "%A" siIn
    fprintfn swB "%A" siOut
    fprintfn swBytesA "%s" (FIXBuf.toS bufIn numBytesToSendSettleInst)
    fprintfn swBytesB "%s" (FIXBuf.toS bufOut numBytesReceivedSettleInst)
    printfn "diffs persisted"
else
    printfn "in and out messages are identical"



#nowarn "52"
let WaitForExitCmd () =
    while stdin.Read() > -9999 do
        ()

WaitForExitCmd ()


// logout

let logout:Logout = {
    Text = None
    EncodedText = None
    }

let logoutDU = Fix44.MessageDU.Logout logout
let numBytesToSendLogout = MsgReadWrite.WriteMessageDU tmpBuf bufIn 0 beginString  senderCompID targetCompID msgSeqNum2 sendingTime logoutDU
do strm.Write (bufIn, 0, numBytesToSendLogout)

printfn "logout sent"

WaitForExitCmd ()