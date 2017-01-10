module FIXMsgIndexingPropTests

open System
open System.Reflection

open Xunit
open FsCheck
open FsCheck.Xunit
open Swensen.Unquote

open Generators
open Fix44.Messages
open Fix44.Fields
open Fix44.MessageDU


type FsFixPropertyTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 100,
        EndSize = 8,
        Verbose = false
//        QuietOnSuccess = true
        )

let bufSize = 82 * 1024



//[<FsFixPropertyTest>]
//let ReconstructMessageBuf (msg:FIXMessage) =
//    let fixBuf = Array.zeroCreate<byte> bufSize
//    let posW = Fix44.MessageDU.WriteMessage fixBuf 0 msg
//
//    // ignore msgs with len zero bodies (Heartbeats)
//    posW > 0 ==> lazy 
//        let index = Array.zeroCreate<FIXBufIndexer.FieldPos> bufSize
//        let indexEnd = FIXBufIndexer.Index index fixBuf posW
//        let reconstructedFIXBuf = FIXBufIndexer.reconstructFromIndex fixBuf index indexEnd
//        // trim fixBuf
//        let fixBuf2 = Array.zeroCreate<byte> posW
//        Array.Copy(fixBuf, fixBuf2, posW)
//        fixBuf2 =! reconstructedFIXBuf





[<FsFixPropertyTest>]
let ``reconstruct FIX message buf with header and trailer``
        (beginString:BeginString) 
        (senderCompID:SenderCompID) 
        (targetCompID:TargetCompID) 
        (msgSeqNum:MsgSeqNum) 
        (sendingTime:SendingTime) 
        (msg:FIXMessage) =
    let fixBuf = Array.zeroCreate<byte> bufSize
    let tmpBuf = Array.zeroCreate<byte> bufSize
    let posW = MsgReadWrite.WriteMessageDU 
                                tmpBuf 
                                fixBuf 
                                0 
                                beginString 
                                senderCompID
                                targetCompID
                                msgSeqNum
                                sendingTime
                                msg
    let index = Array.zeroCreate<FIXBufIndexer.FieldPos> bufSize
    let indexEnd = FIXBufIndexer.Index index fixBuf posW
    let reconstructedFIXBuf = FIXBufIndexer.reconstructFromIndex fixBuf index indexEnd
    // trim fixBuf
    let fixBuf2 = Array.zeroCreate<byte> posW
    Array.Copy(fixBuf, fixBuf2, posW)
    fixBuf2 =! reconstructedFIXBuf


    
    
//[<Fact>]
//let ``reconstruct message buf, xunit`` () =
//    let msg: NetworkStatusResponse = {  NetworkStatusResponseType = NetworkStatusResponseType.Full
//                                        NetworkRequestID = None
//                                        NetworkResponseID = None
//                                        LastNetworkResponseID = None
//                                        NetworkStatusResponseNoCompIDsGrp = []}
//    let msg = msg |> FIXMessage.NetworkStatusResponse        
//
//    let fixBuf = Array.zeroCreate<byte> bufSize
//    let posW = Fix44.MessageDU.WriteMessage fixBuf 0 msg
//    
//    let index = Array.zeroCreate<FIXBufIndexer.FieldPos> bufSize
//    let indexEnd = FIXBufIndexer.Index index fixBuf posW
//    let reconstructedFIXBuf = FIXBufIndexer.reconstructFromIndex fixBuf index indexEnd
//
//    let fixBuf2 = Array.zeroCreate<byte> posW
//    Array.Copy(fixBuf, fixBuf2, posW)
//    fixBuf2 =! reconstructedFIXBuf
