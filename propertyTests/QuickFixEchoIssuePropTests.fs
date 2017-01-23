module QuickFixEchoIssuePropTests


open FsCheck.Xunit
open Swensen.Unquote

open Fix44.Fields
open Fix44.CompoundItems
open Fix44.CompoundItemWriters
open Fix44.CompoundItemDU
open Fix44.MessageDU

open Generators


let bufSize = 1024 * 16 // so as not to go into the LOH
let bs = Array.zeroCreate<byte> bufSize    
let tmpBs = Array.zeroCreate<byte> bufSize
let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1024

type PropTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 1000,
        EndSize = 1,
        Verbose = true,
        QuietOnSuccess = true
        )


[<PropTest>]
let ``check all fields have values of non-zero length`` (msg:FIXMessage) = 
    System.Array.Clear (bs, 0, bs.Length)
    System.Array.Clear (fieldPosArr, 0, fieldPosArr.Length)
    let posW = Fix44.MessageDU.WriteMessage bs 0 msg
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)

    let lenDataIndex = fieldPosArr |>  Array.filter (fun xx -> FIXBufIndexer.IsLenDataCompoundTag xx.Tag)
    
    let lenDataFieldValues = lenDataIndex |> Array.map (fun fpData ->
        let lengthFieldTermPos = FIXBuf.findNextFieldTermOrEnd bs fpData.Pos
        let dataFieldLength = Conversions.bytesToInt32 bs fpData.Pos (lengthFieldTermPos - fpData.Pos)
        dataFieldLength, fpData)

    let zeroLenDataFields = lenDataFieldValues |> Array.filter (fun (len, _) -> len = 0) 

    let zeroLenFields = fieldPosArr |> Array.truncate indexEnd |> Array.filter (fun xx -> xx.Len = 0)
    [||] =! zeroLenDataFields
    [||] =! zeroLenFields
    
    


[<PropTest>]
let ``check that the body length field contains the correct value`` (msg:FIXMessage) =
    System.Array.Clear (bs, 0, bs.Length)
    System.Array.Clear (tmpBs, 0, tmpBs.Length)
    System.Array.Clear (fieldPosArr, 0, fieldPosArr.Length)
    let beginString:BeginString = BeginString.BeginString "FIX.4.4"
    let msgType:MsgType = MsgType.NewOrderMultileg
    let senderCompID:SenderCompID = SenderCompID.SenderCompID "senderCompID"
    let targetCompID:TargetCompID = TargetCompID.TargetCompID "targetCompID"
    let msgSeqNum:MsgSeqNum = MsgSeqNum.MsgSeqNum 99u
    let sendingTime:SendingTime = SendingTime.SendingTime (UTCDateTime.readUTCTimestamp "20170123-05:30:00.000"B 0 21)
    let posW = MsgReadWrite.WriteMessageDU tmpBs bs 0 beginString senderCompID targetCompID msgSeqNum  sendingTime msg
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)
    let bodyLenTag = 9
    let checkSumTag = 10
    let bodyLenFieldIdx = FIXBufIndexer.FindFieldIdx index indexEnd bodyLenTag
    let bodyLenFieldPos = fieldPosArr.[bodyLenFieldIdx]
    let checkSumFieldIdx = FIXBufIndexer.FindFieldIdx index indexEnd checkSumTag
    let checkSumFieldPos = fieldPosArr.[checkSumFieldIdx]
    let firstByteAfterBodyLen = bodyLenFieldPos.Pos + bodyLenFieldPos.Len + 1
    let lastFieldTermBeforeChecksumPos = checkSumFieldPos.Pos - 4 // checkSumFieldPos.Pos contains the position of the checksum value, need to move back 4 to get to the prev field terminator
    let calcedBodyLen = lastFieldTermBeforeChecksumPos - (firstByteAfterBodyLen-1)
    let receivedBodyLen = Conversions.bytesToInt32 bs bodyLenFieldPos.Pos bodyLenFieldPos.Len
    calcedBodyLen =! receivedBodyLen
