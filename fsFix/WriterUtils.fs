module WriterUtils


open Fix44.Fields
open Fix44.FieldWriteFuncs





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
