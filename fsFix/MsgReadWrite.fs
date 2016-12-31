module MsgReadWrite


open System
open Fix44.Fields
open Fix44.FieldWriters
open Fix44.FieldReaders
open Fix44.MessageDU







let CalcCheckSum (buf:byte[]) (len:int) =
    let mutable (sum:byte) = 0uy
    for ctr = 0 to (len - 1) do // len is the 'next free index', so it is not included in the checksum calc
        sum <- sum + buf.[ctr]
    //todo: consider a more direct conversion than sprintf
    // checksum is defined as a string in fix44.xml hence the CheckSum field type expects a string
    (sprintf "%03d" sum) |> CheckSum 


let CalcCheckSum2 (buf:byte[]) (pos:int)  (len:int) =
    let mutable (sum:byte) = 0uy
    for ctr = pos to (pos + len - 2) do // -2 so as to not include the field divider before the checksum field
        sum <- sum + buf.[ctr]
    //todo: consider a more direct conversion than sprintf
    // checksum is defined as a string in fix44.xml hence the CheckSum field type expects a string
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

    let nextFreeIdxInner = WriteTag tmpBuf 0 tag
    let nextFreeIdxInner = WriteSenderCompID tmpBuf nextFreeIdxInner senderCompID
    let nextFreeIdxInner = WriteTargetCompID tmpBuf nextFreeIdxInner targetCompID
    let nextFreeIdxInner = WriteMsgSeqNum tmpBuf nextFreeIdxInner msgSeqNum
    let nextFreeIdxInner = WriteSendingTime tmpBuf nextFreeIdxInner sendingTime
    let innerLen = Fix44.MessageDU.WriteMessage tmpBuf nextFreeIdxInner msg

    let nextFreeIdx = WriteBeginString dest nextFreeIdx beginString
    let nextFreeIdx = WriteBodyLength dest nextFreeIdx (innerLen |> uint32 |> BodyLength)

    System.Buffer.BlockCopy(tmpBuf, 0, dest, nextFreeIdx, innerLen)
    let nextFreeIdx = nextFreeIdx + innerLen

    //  <trailer>
    //    <field name="SignatureLength" required="N" />
    //    <field name="Signature" required="N" />
    //    <field name="CheckSum" required="Y" />    
    //  </trailer>
    // CheckSum is defined in fix44.xml as a string field, but will always be a three digit number
    let checksum = CalcCheckSum dest nextFreeIdx
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

let ReadMessage (bs:byte []) : int * FIXMessage =
    
    let ss = System.Text.Encoding.UTF8.GetString bs
    
    let pos = 0
    let pos, beginString    = ReaderUtils.ReadField bs pos "ReadBeginString" "8"B  ReadBeginString
    let pos, bodyLen        = ReaderUtils.ReadField bs pos "ReadBodyLength" "9"B  ReadBodyLength

    let (BodyLength ulen) = bodyLen
    let len = ulen |> int
    let calcedCheckSum = CalcCheckSum2 bs pos len

//    let pos, msgType        = ReadMsgType pos src
    let tagValSepPos        = 1 + FIXBuf.findNextTagValSep bs pos
    let pos, tag            = FIXBuf.readValAfterTagValSep bs tagValSepPos

    let pos, seqNum         = ReaderUtils.ReadField bs pos "ReadMsgSeqNum"    "34"B  ReadMsgSeqNum    
    let pos, senderCompID   = ReaderUtils.ReadField bs pos "ReadSenderCompID" "49"B  ReadSenderCompID
    let pos, sendTime       = ReaderUtils.ReadField bs pos "ReadSendingTime"  "52"B  ReadSendingTime
    let pos, targetCompID   = ReaderUtils.ReadField bs pos "ReadTargetCompID" "56"B  ReadTargetCompID

    let pos, msg = ReadMessageDU tag bs pos // reading from the inner buffer, so its pos is not the one to be returned

    let pos, receivedCheckSum   = ReaderUtils.ReadField bs pos "ReadCheckSum" "10"B  ReadCheckSum

    if calcedCheckSum <> receivedCheckSum then
        let msg = sprintf "invalid checksum, received %A, calculated: %A" receivedCheckSum calcedCheckSum
        failwith msg
   
    pos, msg




    
