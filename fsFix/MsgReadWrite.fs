﻿module MsgReadWrite


open System
open Fix44.Fields
open Fix44.FieldWriters
open Fix44.FieldReaders
open Fix44.MessageDU




let CalcCheckSum (bs:byte[]) (pos:int) (len:int) =
    let mutable (sum:byte) = 0uy
    for ctr = pos to (pos + len - 1) do // len is the 'next free index', so it is not included in the checksum calc
        sum <- sum + bs.[ctr]
    //todo: consider a more direct conversion than sprintf
    (sprintf "%03d" sum) |> CheckSum     // checksum is defined as a string in fix44.xml hence the CheckSum field type expects a strings



let WriteTag (dest:byte[]) (nextFreeIdx:int) (msgTag:byte[]) : int = 
    let tag =  [|yield! "35="B; yield! msgTag|]
    System.Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
    let nextFreeIdx2 = nextFreeIdx + tag.Length
    dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
    nextFreeIdx2 + 1 // +1 to go to the index one past the SOH field delimeter


let WriteMessageDU
        (tmpBuf:byte []) 
        (dest:byte []) 
        (nextFreeIdx:int) 
        (beginString:BeginString) 
        (senderCompID:SenderCompID) 
        (targetCompID:TargetCompID) 
        (msgSeqNum:MsgSeqNum) 
        (sendingTime:SendingTime) 
        (msg:FIXMessage) =

    let tag = Fix44.MessageDU.GetTag msg
    let nextFreeIdxInner = WriteTag tmpBuf 0 tag
    let nextFreeIdxInner = WriteMsgSeqNum tmpBuf nextFreeIdxInner msgSeqNum
    let nextFreeIdxInner = WriteSenderCompID tmpBuf nextFreeIdxInner senderCompID
    let nextFreeIdxInner = WriteSendingTime tmpBuf nextFreeIdxInner sendingTime    
    let nextFreeIdxInner = WriteTargetCompID tmpBuf nextFreeIdxInner targetCompID
    
    let innerLen = Fix44.MessageDU.WriteMessage tmpBuf nextFreeIdxInner msg
    let nextFreeIdx = WriteBeginString dest nextFreeIdx beginString
    let nextFreeIdx = WriteBodyLength dest nextFreeIdx (innerLen |> uint32 |> BodyLength)

    System.Buffer.BlockCopy(tmpBuf, 0, dest, nextFreeIdx, innerLen)
    let nextFreeIdx = nextFreeIdx + innerLen

    let checksum = CalcCheckSum dest 0 nextFreeIdx
    let ss = System.Text.Encoding.UTF8.GetString dest


    // not sending optional signature fields in the trailer, this may change
    //  <trailer>
    //    <field name="SignatureLength" required="N" />
    //    <field name="Signature" required="N" />
    //    <field name="CheckSum" required="Y" />    
    //  </trailer>
    // CheckSum is defined in fix44.xml as a string field, but will always be a three digit number
    
    let nextFreeIdx = WriteCheckSum dest nextFreeIdx checksum
    nextFreeIdx




// quickfix executor replies to a logon msg by returning a logon msg with the fields in this order
// 8=FIX.4.4
// 9=70
// 35=A
// 34=1
// 49=EXECUTOR
// 52=20161231-07:17:23.037
// 56=CLIENT1
// 98=0
// 108=30
// 10=090

//let ReadMessage (bs:byte []) : int * FIXMessage =
//
//    let pos = 0
//    let pos, beginString    = ReaderUtils.ReadField bs pos "ReadBeginString" "8"B  ReadBeginString
//    let pos, bodyLen        = ReaderUtils.ReadField bs pos "ReadBodyLength" "9"B  ReadBodyLength
//
//    // the generated readMsgType function returns a MsgType DU case which is not used for dispatching
//    //let _, msgType        = ReaderUtils.ReadField bs pos "ReadMsgType"    "35"B  ReadMsgType
//    let tagValSepPos        = 1 + FIXBuf.findNextTagValSep bs pos
//    let pos, tag            = FIXBuf.readValAfterTagValSep bs tagValSepPos
//
//    let pos, seqNum         = ReaderUtils.ReadField bs pos "ReadMsgSeqNum"    "34"B  ReadMsgSeqNum
//    let pos, senderCompID   = ReaderUtils.ReadField bs pos "ReadSenderCompID" "49"B  ReadSenderCompID
//    let pos, sendTime       = ReaderUtils.ReadField bs pos "ReadSendingTime"  "52"B  ReadSendingTime
//    let pos, targetCompID   = ReaderUtils.ReadField bs pos "ReadTargetCompID" "56"B  ReadTargetCompID
//    let pos, msg = ReadMessageDU tag bs pos
//    let (BodyLength ulen) = bodyLen
//    let len = ulen |> int
//    let calcedCheckSum = CalcCheckSum bs 0 pos
//    let pos, receivedCheckSum   = ReaderUtils.ReadField bs pos "ReadCheckSum" "10"B  ReadCheckSum
//    if calcedCheckSum <> receivedCheckSum then
//        let msg = sprintf "invalid checksum, received %A, calculated: %A" receivedCheckSum calcedCheckSum
//        failwith msg
//    pos, msg



let ReadMessage (bs:byte []) : FIXMessage =

    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 256 // todo, make index size a parameter 
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs bs.Length // todo: this should be the last populated array index, not the array len
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)
    

    // magic numbers are FIX field tags
    let beginString    = ReaderUtils.ReadFieldIdxOrdered true bs index 8 ReadBeginStringIdx
    let bodyLen        = ReaderUtils.ReadFieldIdxOrdered true bs index 9 ReadBodyLengthIdx

    // the generated readMsgType function returns a MsgType DU case which is not used for dispatching
    //let _, msgType        = ReaderUtils.ReadField bs index "ReadMsgType"    "35"B  ReadMsgType
    let tagValSepPos        = 1 + FIXBuf.findNextTagValSep bs 999
    let pos, tag            = FIXBuf.readValAfterTagValSep bs tagValSepPos

    let seqNum         = ReaderUtils.ReadFieldIdxOrdered true bs index 34 ReadMsgSeqNumIdx
    let senderCompID   = ReaderUtils.ReadFieldIdxOrdered true bs index 49 ReadSenderCompIDIdx
    let sendTime       = ReaderUtils.ReadFieldIdxOrdered true bs index 52 ReadSendingTimeIdx
    let targetCompID   = ReaderUtils.ReadFieldIdxOrdered true bs index 56 ReadTargetCompIDIdx

    let msg = ReadMessageDU tag bs index

    let (BodyLength ulen) = bodyLen
    let len = ulen |> int
    let calcedCheckSum = CalcCheckSum bs 0 pos

    let receivedCheckSum   = ReaderUtils.ReadFieldIdx bs index 10 ReadCheckSumIdx

    if calcedCheckSum = receivedCheckSum then
        msg
    else
        let errMsg = sprintf "invalid checksum, received %A, calculated: %A" receivedCheckSum calcedCheckSum
        failwith errMsg
