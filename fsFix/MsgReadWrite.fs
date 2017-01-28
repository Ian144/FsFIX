module MsgReadWrite


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

    // not sending optional signature fields in the trailer, this may change
    //  <trailer>
    //    <field name="SignatureLength" required="N" />
    //    <field name="Signature" required="N" />
    //    <field name="CheckSum" required="Y" />    
    //  </trailer>

    let checksum = CalcCheckSum dest 0 nextFreeIdx
    let nextFreeIdx = WriteCheckSum dest nextFreeIdx checksum
    nextFreeIdx




let ReadMessage (bs:byte []) (posEnd:int) : FIXMessage =
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 8)// todo, make index size a parameter 
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posEnd
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)

    // magic numbers are FIX field tags, true is a dummy parameter to differentiate the type signature of the 'ordered' reading functions from the random access equivalents
    let beginString    = ReaderUtils.ReadFieldOrdered true bs index 8 ReadBeginString
    let bodyLen        = ReaderUtils.ReadFieldOrdered true bs index 9 ReadBodyLength
    let msgTag         = ReaderUtils.ReadFieldOrdered true bs index 35 ReadMsgType
    let seqNum         = ReaderUtils.ReadFieldOrdered true bs index 34 ReadMsgSeqNum
    let senderCompID   = ReaderUtils.ReadFieldOrdered true bs index 49 ReadSenderCompID
    let sendTime       = ReaderUtils.ReadFieldOrdered true bs index 52 ReadSendingTime
    let targetCompID   = ReaderUtils.ReadFieldOrdered true bs index 56 ReadTargetCompID

    let msg = ReadMessageDU msgTag bs index

    let checksumFieldposDataIndex = FIXBufIndexer.FindFieldIdx index indexEnd 10
    let checksumFieldPosData = fieldPosArr.[checksumFieldposDataIndex]
    let checksumTagPlusDelimLen = 3
    let calcedCheckSum = CalcCheckSum bs 0 (checksumFieldPosData.Pos-checksumTagPlusDelimLen)
    let receivedCheckSum   = ReaderUtils.ReadField bs index 10 ReadCheckSum
    if calcedCheckSum = receivedCheckSum then
        msg
    else
        failwithf "invalid checksum, received %A, calculated: %A" receivedCheckSum calcedCheckSum




let ReadMessage2 (bs:byte []) (posEnd:int) fieldPosArr : FIXMessage =
    //let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1024 // todo, make index size a parameter 
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posEnd
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)

    // magic numbers are FIX field tags, true is a dummy parameter to differentiate the type signature of the 'ordered' reading functions from the random access equivalents
    let beginString    = ReaderUtils.ReadFieldOrdered true bs index 8 ReadBeginString
    let bodyLen        = ReaderUtils.ReadFieldOrdered true bs index 9 ReadBodyLength
    let msgTag         = ReaderUtils.ReadFieldOrdered true bs index 35 ReadMsgType
    let seqNum         = ReaderUtils.ReadFieldOrdered true bs index 34 ReadMsgSeqNum
    let senderCompID   = ReaderUtils.ReadFieldOrdered true bs index 49 ReadSenderCompID
    let sendTime       = ReaderUtils.ReadFieldOrdered true bs index 52 ReadSendingTime
    let targetCompID   = ReaderUtils.ReadFieldOrdered true bs index 56 ReadTargetCompID

    let msg = ReadMessageDU msgTag bs index

    let checksumFieldposDataIndex = FIXBufIndexer.FindFieldIdx index indexEnd 10
    let checksumFieldPosData = fieldPosArr.[checksumFieldposDataIndex]
    let checksumTagPlusDelimLen = 3
    let calcedCheckSum = CalcCheckSum bs 0 (checksumFieldPosData.Pos-checksumTagPlusDelimLen)
    let receivedCheckSum   = ReaderUtils.ReadField bs index 10 ReadCheckSum
    if calcedCheckSum = receivedCheckSum then
        msg
    else
        failwithf "invalid checksum, received %A, calculated: %A" receivedCheckSum calcedCheckSum


let ReadMessage3 (bs, posEnd)  : FIXMessage =
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1024 // todo, make index size a parameter 
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posEnd
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)

    // magic numbers are FIX field tags, true is a dummy parameter to differentiate the type signature of the 'ordered' reading functions from the random access equivalents
    let beginString    = ReaderUtils.ReadFieldOrdered true bs index 8 ReadBeginString
    let bodyLen        = ReaderUtils.ReadFieldOrdered true bs index 9 ReadBodyLength
    let msgTag         = ReaderUtils.ReadFieldOrdered true bs index 35 ReadMsgType
    let seqNum         = ReaderUtils.ReadFieldOrdered true bs index 34 ReadMsgSeqNum
    let senderCompID   = ReaderUtils.ReadFieldOrdered true bs index 49 ReadSenderCompID
    let sendTime       = ReaderUtils.ReadFieldOrdered true bs index 52 ReadSendingTime
    let targetCompID   = ReaderUtils.ReadFieldOrdered true bs index 56 ReadTargetCompID

    let msg = ReadMessageDU msgTag bs index

    let checksumFieldposDataIndex = FIXBufIndexer.FindFieldIdx index indexEnd 10
    let checksumFieldPosData = fieldPosArr.[checksumFieldposDataIndex]
    let checksumTagPlusDelimLen = 3
    let calcedCheckSum = CalcCheckSum bs 0 (checksumFieldPosData.Pos-checksumTagPlusDelimLen)
    let receivedCheckSum   = ReaderUtils.ReadField bs index 10 ReadCheckSum
    if calcedCheckSum = receivedCheckSum then
        msg
    else
        failwithf "invalid checksum, received %A, calculated: %A" receivedCheckSum calcedCheckSum



let ReadMessage4 (bs, posEnd, fieldPosArr)  : FIXMessage =
    //let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1024 // todo, make index size a parameter 
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posEnd
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)

    // magic numbers are FIX field tags, true is a dummy parameter to differentiate the type signature of the 'ordered' reading functions from the random access equivalents
    let beginString    = ReaderUtils.ReadFieldOrdered true bs index 8 ReadBeginString
    let bodyLen        = ReaderUtils.ReadFieldOrdered true bs index 9 ReadBodyLength
    let msgTag         = ReaderUtils.ReadFieldOrdered true bs index 35 ReadMsgType
    let seqNum         = ReaderUtils.ReadFieldOrdered true bs index 34 ReadMsgSeqNum
    let senderCompID   = ReaderUtils.ReadFieldOrdered true bs index 49 ReadSenderCompID
    let sendTime       = ReaderUtils.ReadFieldOrdered true bs index 52 ReadSendingTime
    let targetCompID   = ReaderUtils.ReadFieldOrdered true bs index 56 ReadTargetCompID

    let msg = ReadMessageDU msgTag bs index

    let checksumFieldposDataIndex = FIXBufIndexer.FindFieldIdx index indexEnd 10
    let checksumFieldPosData = fieldPosArr.[checksumFieldposDataIndex]
    let checksumTagPlusDelimLen = 3
    let calcedCheckSum = CalcCheckSum bs 0 (checksumFieldPosData.Pos-checksumTagPlusDelimLen)
    let receivedCheckSum   = ReaderUtils.ReadField bs index 10 ReadCheckSum
    if calcedCheckSum = receivedCheckSum then
        msg
    else
        failwithf "invalid checksum, received %A, calculated: %A" receivedCheckSum calcedCheckSum