﻿module AcceptorTests


open System
open System.Net.Sockets
open System.IO


open Xunit
open Swensen.Unquote

open Fix44
open Fix44.Fields
open Fix44.MessageDU

open Session.Types



let isLogon (msg:FIXMessage) =
    match msg with
    |  FIXMessage.Logon  _  -> true
    |   _                   -> false


// used when testing FIX admin msg processing
let DoNothingAppMsgProc (msgType:MsgType) (index:FIXBufIndexer.IndexData) (buf:byte array) (resendMsgs:ResizeArray<Fix44.MessageDU.FIXMessage>) : (MessageDU.FIXMessage list) =
    []


//// todo: impl IDispose
//type FakeDuplexStream() =
//    inherit System.IO.Stream()

//    let creatingThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
//    let stream1 = new MemoryStream()
//    let stream2 = new MemoryStream()

//    override this.CanRead = raise (new NotImplementedException())
//    override this.CanSeek = stream1.CanSeek
//    override this.CanWrite = raise (new NotImplementedException())
//    override this.Length = raise (new NotImplementedException())
//    override this.Position = raise (new NotImplementedException())
//    override this.set_Position(_) = raise (new NotImplementedException())

//    override this.Flush () = ()
    
//    override this.SetLength(_) = raise (new NotImplementedException())

//    override this.Seek(offset,origin) = 0L

//    override this.Read(buffer, offset, count) =
//        let callingThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
//        let streamToUse = if creatingThreadId = callingThreadId then stream2 else stream1
//        lock this (fun () ->
//            //let xx = streamToUse.Seek(0L,SeekOrigin.Begin)
            
//            //while (not streamToUse.
            
//            let ret = streamToUse.Read(buffer,offset,count)
//            streamToUse.Position <- 0L
//            streamToUse.SetLength( 0L )
//            ret)

//    override this.Write(buffer, offset, count) =
//        let callingThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
//        let streamToUse = if creatingThreadId = callingThreadId then stream1 else stream2 // must be opposite to this.Read
//        lock this (fun () -> 
//            let xx = streamToUse.Seek(0L,SeekOrigin.Begin)
//            streamToUse.Write(buffer, offset, count) )



let startAsyncAcceptor () = 
    let trgCompID = TargetCompID "acceptor"
    let sndCompID = SenderCompID "inititor"
    let sessionConfig:SessionConfig = {
        TargetCompID = trgCompID
        SenderCompID = sndCompID
        MaxMsgSize = 1024u * 64u
        MaxMsgAge  = TimeSpan(0,0,30)
        HeartbeatInterval = 60
        AcceptedCompIDPairs = Set.empty |> Set.add (trgCompID, sndCompID)
    }

    let tcpListener = TcpListener (System.Net.IPAddress.Loopback, 5001)
    tcpListener.Start()

    let bufSize = 1024 * 64
    do FsFix.Session.Acceptor.MsgLoop Executor.Executor sessionConfig bufSize tcpListener
    


[<Fact>]
let testValidLogonToAcceptor () =

    let fixVer          = BeginString  "FIX.4.4"
    let senderCompID    = SenderCompID "initiator"
    let targetCompID    = TargetCompID "acceptor"
    let msgSeqNum       = MsgSeqNum 1u
    let maxMsgSize      = 1024u * 64u    
    let bufSize         = 1024*64
    let tmpBuf          = Array.zeroCreate<byte> (bufSize)
    let buf             = Array.zeroCreate<byte> (bufSize)

    let encryptMethod   = Fix44.Fields.EncryptMethod.NoneOther
    let hrtbeatInterval = Fix44.Fields.HeartBtInt 60
    let logonMsg        = {Fix44.MessageFactoryFuncs.MkLogon (encryptMethod, hrtbeatInterval) with 
                            MaxMessageSize = (MaxMessageSize maxMsgSize) |> Option.Some
                            } |> Fix44.MessageDU.FIXMessage.Logon

    let dtoUtcNow       = DateTimeOffset.UtcNow
    let utcNow          = UTCDateTime.MakeUTCTimestamp.Make dtoUtcNow
    let sendingTime     = SendingTime utcNow

    let msgLen          = MsgReadWrite.WriteMessageDU tmpBuf buf 0 fixVer senderCompID targetCompID msgSeqNum sendingTime logonMsg
    use strm            = new MemoryStream() 
    strm.Write( buf, 0, msgLen )


    let trgCompID = TargetCompID "acceptor"
    let sndCompID = SenderCompID "initiator"
    let sessionConfig = {
        TargetCompID = trgCompID
        SenderCompID = sndCompID
        MaxMsgSize = maxMsgSize
        MaxMsgAge  = TimeSpan(0,0,30)
        HeartbeatInterval = 60
        AcceptedCompIDPairs = Set.empty |> Set.add (trgCompID, sndCompID)
    }

    // 'send' the msg to the acceptor
    FsFix.Session.Acceptor.ProcessMsg DoNothingAppMsgProc sessionConfig bufSize strm

    System.Threading.Thread.Sleep(2000)

    let readBuf = Array.zeroCreate<byte> bufSize
    strm.Seek(0L, SeekOrigin.Begin) |> ignore
    let numBytesRead = strm.Read(readBuf, 0, bufSize)

    //let ss = Conversions.bytesToStr readBuf 0 numBytesRead 
    //let ss2 = ss.Replace( char(1uy), '|')
    //printf "%s" ss

    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 8)
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr readBuf numBytesRead
    let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)

    let msgOut = MsgReadWrite.ReadMessage readBuf numBytesRead fieldPosArr


    match msgOut with
    |  FIXMessage.Logon  logonMsgOut  
                    ->  logonMsgOut.HeartBtInt.Value =! sessionConfig.HeartbeatInterval

                        let initiatorCompID = GenericReaders.ReadField buf index 56 FieldReaders.ReadTargetCompID
                        initiatorCompID.Value =! "initiator"


                        let acceptorCompID = GenericReaders.ReadField buf index 49 FieldReaders.ReadSenderCompID
                        acceptorCompID.Value =! "acceptor"

                        logonMsgOut.MaxMessageSize=! (maxMsgSize |> MaxMessageSize |> Option.Some)

    |   _           -> true =! false


    true =! isLogon msgOut
    

    numBytesRead =! (msgLen + 12345)


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