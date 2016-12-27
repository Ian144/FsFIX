module MsgReadWrite



open Fix44.Fields
open Fix44.FieldWriters
open Fix44.FieldReaders
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
    let nextFreeIdx = WriteBodyLength dest nextFreeIdx (innerLen |> uint32 |> BodyLength)
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

    let innerLen = Fix44.MessageDU.WriteMessage tmpBuf 0 msg

    let nextFreeIdx = WriteBeginString dest nextFreeIdx beginString
    let nextFreeIdx = WriteBodyLength dest nextFreeIdx (innerLen |> uint32 |> BodyLength)
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
    let pos, beginString    = ReaderUtils.ReadField src pos "ReadBeginString" "8"B  ReadBeginString
    let pos, bodyLen        = ReaderUtils.ReadField src pos "ReadBodyLength" "9"B  ReadBodyLength
    
//    let pos, msgType        = ReadMsgType pos src
    let tagValSepPos        = 1 + FIXBufUtils.findNextTagValSep src pos
    let pos, tag            = FIXBufUtils.readValAfterTagValSep src tagValSepPos
    
    let pos, senderCompID   = ReaderUtils.ReadField src pos "ReadSenderCompID" "49"B  ReadSenderCompID
    let pos, targetCompID   = ReaderUtils.ReadField src pos "ReadTargetCompID" "56"B  ReadTargetCompID
    let pos, seqNum         = ReaderUtils.ReadField src pos "ReadMsgSeqNum"    "34"B  ReadMsgSeqNum
    let pos, sendTime       = ReaderUtils.ReadField src pos "ReadSendingTime"  "52"B  ReadSendingTime

    let (BodyLength len) = bodyLen
    let iLen = len |> int
    System.Buffer.BlockCopy(src, pos, innerBuf, 0, iLen)
    
    let calcedCheckSum = CalcCheckSum innerBuf iLen

    let pos = pos + iLen
    let pos, receivedCheckSum   = ReaderUtils.ReadField src pos "ReadCheckSum" "10"B  ReadCheckSum

    if calcedCheckSum <> receivedCheckSum then
        let msg = sprintf "invalid checksum, received %A, calculated: %A" receivedCheckSum calcedCheckSum
        failwith msg

    let _, msg = ReadMessageDU tag innerBuf 0 // reading from the inner buffer, so its pos is not the one to be returned
    pos, msg
    



let ReadMessageGeneric (src:byte []) (innerBuf:byte [])  (readFunc:int->byte[]->int*'t) : int * 't =
    let pos = 0
    let pos, beginString    = ReaderUtils.ReadField src pos "ReadBeginString" "8"B  ReadBeginString
    let pos, bodyLen        = ReaderUtils.ReadField src pos "ReadBodyLength" "9"B  ReadBodyLength
    
//    let pos, msgType        = ReadMsgType pos src
    let tagValSepPos        = 1 + FIXBufUtils.findNextTagValSep src pos 
    let pos, tag            = FIXBufUtils.readValAfterTagValSep src tagValSepPos// need to bounce from a runtime value to a compile time generic instance, is using a DU unavoidable??
    let pos, senderCompID   = ReaderUtils.ReadField src pos "ReadSenderCompID" "49"B  ReadSenderCompID
    let pos, targetCompID   = ReaderUtils.ReadField src pos "ReadTargetCompID" "56"B  ReadTargetCompID
    let pos, seqNum         = ReaderUtils.ReadField src pos "ReadMsgSeqNum"    "34"B  ReadMsgSeqNum
    let pos, sendTime       = ReaderUtils.ReadField src pos "ReadSendingTime"  "52"B  ReadSendingTime

    let (BodyLength len) = bodyLen
    let iLen = len |> int

    System.Buffer.BlockCopy(src, pos, innerBuf, 0, iLen)
    
    let calcedCheckSum = CalcCheckSum innerBuf iLen
    let pos = pos + iLen

    let pos, receivedCheckSum   = ReaderUtils.ReadField src pos "ReadCheckSum" "10"B  ReadCheckSum

    if calcedCheckSum <> receivedCheckSum then
        let msg = sprintf "invalid checksum, received %A, calculated: %A" receivedCheckSum calcedCheckSum
        failwith msg

    let _, msg = readFunc 0 innerBuf // reading from the inner buffer, so its pos is not the one to be returned
    pos, msg



    
