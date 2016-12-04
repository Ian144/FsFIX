module WriterUtils


open Fix44.Fields
open Fix44.FieldWriteFuncs
open Fix44.FieldReadFuncs
open Fix44.MessageDU




let CalcCheckSum (buf:byte[]) (len:int) =
    let mutable (sum:byte) = 0uy
    for ctr = 0 to (len - 1) do // len is the 'next free index', so it is not included in the checksum calc
        sum <- sum + buf.[ctr]
    //todo: there may be a much better way that sprintf and string conversion for writing the checksum, checksum is defined as a string in fix44.xml hence the CheckSum field type expects a string
    (sprintf "%03d" sum) |> CheckSum 


let WriteMessage
        (tmpBuf:byte []) 
        (dest:byte []) 
        (nextFreeIdx:int) 
        (beginString:BeginString) 
        (msgType:MsgType) 
        (senderCompID:SenderCompID) 
        (targetCompID:TargetCompID) 
        (msgSeqNum:MsgSeqNum) 
        (sendingTime:SendingTime) 
        (writerFunc:byte[]->int->'M->int)
        (msg:'M) =

    // write the msg, but not header or trailer, to a tmp buffer then calc the checksum 
    let innerLen = writerFunc tmpBuf 0 msg

    let nextFreeIdx = WriteBeginString dest nextFreeIdx beginString
    let nextFreeIdx = WriteBodyLength dest nextFreeIdx (innerLen |> BodyLength)
    let nextFreeIdx = WriteMsgType dest nextFreeIdx msgType
    let nextFreeIdx = WriteSenderCompID dest nextFreeIdx senderCompID
    let nextFreeIdx = WriteTargetCompID dest nextFreeIdx targetCompID
    let nextFreeIdx = WriteMsgSeqNum dest nextFreeIdx msgSeqNum
    let nextFreeIdx = WriteSendingTime dest nextFreeIdx sendingTime

    System.Buffer.BlockCopy(tmpBuf, 0, dest, nextFreeIdx, innerLen)
    let nextFreeIdx = nextFreeIdx + innerLen

    //  <trailer>
    //    <field name="SignatureLength" required="N" />
    //    <field name="Signature" required="N" />
    //    <field name="CheckSum" required="Y" />    
    //  </trailer>
    // CheckSum is defined in fix44.xml as a string field, but will always be a three digit number
    let checksum = CalcCheckSum tmpBuf innerLen 
    let nextFreeIdx = WriteCheckSum dest nextFreeIdx checksum 
    nextFreeIdx






let WriteTag (dest:byte[]) (nextFreeIdx:int) (msgTag:byte[]) : int = 
    let tag =  [|yield! "35="B; yield! msgTag|]
    System.Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
    let nextFreeIdx2 = nextFreeIdx + tag.Length
    dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
    nextFreeIdx2 + 1 // +1 to go to the index one past the SOH field delimeter





let WriteMessage2
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

    let innerLen = Fix44.MessageDU.WriteMessage tmpBuf 0 msg

    let nextFreeIdx = WriteBeginString dest nextFreeIdx beginString
    let nextFreeIdx = WriteBodyLength dest nextFreeIdx (innerLen |> BodyLength)
    let nextFreeIdx = WriteTag dest nextFreeIdx tag
    let nextFreeIdx = WriteSenderCompID dest nextFreeIdx senderCompID
    let nextFreeIdx = WriteTargetCompID dest nextFreeIdx targetCompID
    let nextFreeIdx = WriteMsgSeqNum dest nextFreeIdx msgSeqNum
    let nextFreeIdx = WriteSendingTime dest nextFreeIdx sendingTime

    System.Buffer.BlockCopy(tmpBuf, 0, dest, nextFreeIdx, innerLen)
    let nextFreeIdx = nextFreeIdx + innerLen

    //  <trailer>
    //    <field name="SignatureLength" required="N" />
    //    <field name="Signature" required="N" />
    //    <field name="CheckSum" required="Y" />    
    //  </trailer>
    // CheckSum is defined in fix44.xml as a string field, but will always be a three digit number
    let checksum = CalcCheckSum tmpBuf innerLen 
    let nextFreeIdx = WriteCheckSum dest nextFreeIdx checksum 
    nextFreeIdx




let ReadMessage (src:byte []) (innerBuf:byte []) : int * FIXMessage =
    let pos = 0
    let pos, beginString    = ReaderUtils.ReadField "ReadBeginString" pos "8"B src ReadBeginString
    let pos, bodyLen        = ReaderUtils.ReadField "ReadBodyLength" pos "9"B src ReadBodyLength
    
//    let pos, msgType        = ReadMsgType pos src
    let tagValSepPos        = 1 + FIXBufUtils.findNextTagValSep pos src
    let pos, tag            = FIXBufUtils.readValAfterTagValSep tagValSepPos src
    
    let pos, senderCompID   = ReaderUtils.ReadField "ReadSenderCompID" pos "49"B src ReadSenderCompID
    let pos, targetCompID   = ReaderUtils.ReadField "ReadTargetCompID" pos "56"B src ReadTargetCompID
    let pos, seqNum         = ReaderUtils.ReadField "ReadMsgSeqNum"    pos "34"B src ReadMsgSeqNum
    let pos, sendTime       = ReaderUtils.ReadField "ReadSendingTime"  pos "52"B src ReadSendingTime

    let (BodyLength len) = bodyLen
    System.Buffer.BlockCopy(src, pos, innerBuf, 0, len)
    
    let calcedCheckSum = CalcCheckSum innerBuf len 

    let pos = pos + len
    let pos, receivedCheckSum   = ReaderUtils.ReadField "ReadCheckSum" pos "10"B src ReadCheckSum

    if calcedCheckSum <> receivedCheckSum then
        let msg = sprintf "invalid checksum, received %A, calculated: %A" receivedCheckSum calcedCheckSum
        failwith msg

    ReadMessage2 tag 0 innerBuf
    


//
//let ReadMessage (src:byte []) (innerBuf:byte []) : int * FIXMessage =
//    let pos = 1 + FIXBufUtils.findNextTagValSep 0 src
//    let pos, beginString    = ReadBeginString pos src
//    let pos, bodyLen        = ReadBodyLength pos src
//    
////    let pos, msgType        = ReadMsgType pos src
//    
//    let tagValSepPos        = FIXBufUtils.findNextTagValSep pos src
//    let pos, tag            = FIXBufUtils.readValAfterTagValSep tagValSepPos src
//    
//    let pos, senderCompID   = ReadSenderCompID pos src
//    let pos, targetCompID   = ReadTargetCompID pos src
//    let pos, seqNum         = ReadMsgSeqNum pos src
//    let pos, sendTime       = ReadSendingTime pos src
//
//    let (BodyLength len) = bodyLen
//    System.Buffer.BlockCopy(src, pos, innerBuf, 0, len)
//    
//    let calcedCheckSum = CalcCheckSum innerBuf len 
//
//    let pos = pos + len
//    let pos, receivedCheckSum   = ReadCheckSum pos src
//
//    if calcedCheckSum <> receivedCheckSum then
//        let msg = sprintf "invalid checksum, received %A, calculated: %A" receivedCheckSum calcedCheckSum
//        failwith msg
//
//    ReadMessage2 tag 0 innerBuf
    
