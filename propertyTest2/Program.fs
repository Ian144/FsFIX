open FsCheck


open System

open Fix44.Fields
open Fix44.MessageDU

open Swensen.Unquote


Arb.register<Generators.ArbOverrides>() |> ignore

//let propReadWriteFIXFieldRoundtrip (fieldIn:FIXField) =
//    let bs = Array.zeroCreate<byte> 2048
//    WriteField bs 0 fieldIn |> ignore
//    let _, fieldOut = ReadField bs 0
//    fieldIn = fieldOut


let bufSize = 1024 * 64


//let mutable ctr:int = 0
//
//let propReadWriteCompoundItem (ciIn:FIXGroup) =
//    ctr <- ctr + 1
//    if ctr % 10 = 0 then
//        printfn "test count: %d" ctr
//
//    let bs = Array.zeroCreate<byte> bufSize
//    let posW = WriteCITest  bs 0 ciIn
//    let posR, ciOut =  ReadCITest ciIn bs 0
//    posW = posR && ciIn = ciOut




let propReconstructFIXMessageBufFromIndex
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
    let indexEnd = FIXBufIndexer.BuildIndex index fixBuf posW
    let reconstructedFIXBuf = FIXBufIndexer.reconstructFromIndex fixBuf index indexEnd
    // trim fixBuf
    let fixBuf2 = Array.zeroCreate<byte> posW
    Array.Copy(fixBuf, fixBuf2, posW)
    fixBuf2 =! reconstructedFIXBuf




let config = {  Config.Quick with 
//                    EveryShrink = (sprintf "%A" )
//                    Replay = Some (Random.StdGen (310046944,296129814))
//                    StartSize = 64
                    EndSize = 64

//                    MaxFail = 10000
                    MaxTest = 10000000 }



#nowarn "52"
let WaitForExitCmd () = 
    while stdin.Read() <> 88 do // 88 is 'X'
        ()

Check.One (config, propReconstructFIXMessageBufFromIndex)
//Check.One (Config.Quick, propReadWriteFIXFieldRoundtrip)


//WaitForExitCmd ()