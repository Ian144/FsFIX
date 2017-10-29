module AcceptorTests


open System

open Xunit
open Swensen.Unquote

open Fix44
open Fix44.Fields


open System.IO
open Session.Types




// used when testing FIX admin msg processing
let DoNothingAppMsgProc (msgType:MsgType) (index:FIXBufIndexer.IndexData) (buf:byte array) (resendMsgs:ResizeArray<Fix44.MessageDU.FIXMessage>) : (MessageDU.FIXMessage list) =
    []

[<Fact>]
let testValidLogonToAcceptor () =

    let fixVer          = BeginString  "FIX.4.4"
    let senderCompID    = SenderCompID "initiator"
    let targetCompID    = TargetCompID "acceptor"
    let msgSeqNum       = MsgSeqNum 1u
    
    let bufSize         = 1024*64
    let tmpBuf          = Array.zeroCreate<byte> (bufSize)
    let buf             = Array.zeroCreate<byte> (bufSize)

    let encryptMethod   = Fix44.Fields.EncryptMethod.NoneOther
    let hrtbeatInterval = Fix44.Fields.HeartBtInt 60
    let logonMsg        = Fix44.MessageFactoryFuncs.MkLogon (encryptMethod, hrtbeatInterval) |> Fix44.MessageDU.FIXMessage.Logon

    let dtoUtcNow       = DateTimeOffset.UtcNow
    let utcNow          = UTCDateTime.MakeUTCTimestamp.Make dtoUtcNow
    let sendingTime     = SendingTime utcNow

    let msgLen          = MsgReadWrite.WriteMessageDU tmpBuf buf 0 fixVer senderCompID targetCompID msgSeqNum sendingTime logonMsg
    use strm            = new MemoryStream ()
    strm.Write( buf, 0, msgLen )

    let trgCompID = TargetCompID "acceptor"
    let sndCompID = SenderCompID "inititor"
    let sessionConfig = {
        TargetCompID = trgCompID
        SenderCompID = sndCompID
        MaxMsgSize = 1024u * 64u
        MaxMsgAge  = TimeSpan(0,0,30)
        HeartbeatInterval = 60
        AcceptedCompIDPairs = Set.empty |> Set.add (trgCompID, sndCompID)
    }

    FsFix.Session.Acceptor.ProcessMsg DoNothingAppMsgProc sessionConfig bufSize strm

    System.Threading.Thread.Sleep(500)

    let readBuf = Array.zeroCreate<byte> (bufSize)
    strm.Seek(0L, SeekOrigin.Begin) |> ignore
    let numBytesRead = strm.Read(readBuf, 0, bufSize)

    let msgOut = MsgReadWrite.ReadMessage(readBuf)



    numBytesRead =! msgLen


//RUN THE QUICKFIXN ACCEPTENCE TESTS AGAINST FSFIX - THE QF C# RUNNER SHOULD BE ABLE TO CONNECT TO FSFIX
// or use them as a source of unit test ideas
//C:\Users\Ian\Documents\GitHub\Quickfixn\AcceptanceTest\definitions\server\fix44
// http://www.quickfixengine.org/quickfix/doc/html/acceptance_tests.html
//      implement the above a unit tests??
// reconnection 'today' starts at seqnum of last + 1
// reconnection 'tomorrow' starts at seqnum of 1
// no logout msg sent when invalid compIDs received in logon msg
// TestRequest msg forces a heartbeat from the other side
// test accetpr session dies|completesWithError or somesuch without msgs from initiator
// test heartbeats sent - use 1 second hb interval
// testLogonMsgSeqnumIs1
// testFirstMsgMustBeLogon
// testUnrecievedMsgsRequested i.e. if seq numbers of msgs recevied show msgs were missed, then the session (initiator or acceptor) sends resend request
// test resend request for N to 0 treats 0 as infinity
// test invalid checksums are recognised