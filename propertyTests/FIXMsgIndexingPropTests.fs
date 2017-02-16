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
        EndSize = 4,
        Verbose = false
        )

let bufSize = 82 * 1024




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
    let posW = MsgReadWrite.WriteMessageDU tmpBuf fixBuf 0 beginString senderCompID targetCompID msgSeqNum sendingTime msg
    let index = Array.zeroCreate<FIXBufIndexer.FieldPos> bufSize
    let indexEnd = FIXBufIndexer.BuildIndex index fixBuf posW
    let reconstructedFIXBuf = FIXBufIndexer.reconstructFromIndex fixBuf index indexEnd
    let fixBuf2 = fixBuf.[..(posW-1)] // trim fixBuf
    fixBuf2 =! reconstructedFIXBuf
