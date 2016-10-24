


open System

open Fix44.Fields
open Fix44.FieldReadWriteFuncs
open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs
open Fix44.Messages
open Fix44.MsgWriteFuncs



let calcCheckSum (arr:byte[]) (endPos:int) =
    let mutable (sum:byte) = 0uy
    for ctr = 0 to (endPos-1) do
        sum <- sum + arr.[ctr]
    int (sum)


let WriteLogonx (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:Logon) =
    let nextFreeIdx = WriteEncryptMethod dest nextFreeIdx xx.EncryptMethod
    let nextFreeIdx = WriteHeartBtInt dest nextFreeIdx xx.HeartBtInt
    let nextFreeIdx = Option.fold (WriteRawDataLength dest) nextFreeIdx xx.RawDataLength
    let nextFreeIdx = Option.fold (WriteRawData dest) nextFreeIdx xx.RawData
    let nextFreeIdx = Option.fold (WriteResetSeqNumFlag dest) nextFreeIdx xx.ResetSeqNumFlag
    let nextFreeIdx = Option.fold (WriteNextExpectedMsgSeqNum dest) nextFreeIdx xx.NextExpectedMsgSeqNum
    let nextFreeIdx = Option.fold (WriteMaxMessageSize dest) nextFreeIdx xx.MaxMessageSize
    // group (apologies for this nested fold code, will refactor when I think of something better)
    let nextFreeIdx = Option.fold (fun innerNextFreeIdx (gs:NoMsgTypesGrp list) ->
                                        let numGrps = gs.Length
                                        let innerNextFreeIdx2 = WriteNoMsgTypes dest innerNextFreeIdx (Fix44.Fields.NoMsgTypes numGrps) // write the 'num group repeats' field
                                        List.fold (fun accFreeIdx gg -> WriteNoMsgTypesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
                                  nextFreeIdx
                                  xx.NoMsgTypesGrp  // end Option.fold
    let nextFreeIdx = Option.fold (WriteTestMessageIndicator dest) nextFreeIdx xx.TestMessageIndicator
    let nextFreeIdx = Option.fold (WriteUsername dest) nextFreeIdx xx.Username
    let nextFreeIdx = Option.fold (WritePassword dest) nextFreeIdx xx.Password
    let bodyLength = nextFreeIdx - 1

    let startHeader = nextFreeIdx
    let checksum = calcCheckSum dest nextFreeIdx
    let nextFreeIdx = WriteBeginString dest nextFreeIdx beginString
    let nextFreeIdx = WriteBodyLength dest nextFreeIdx (BodyLength.BodyLength bodyLength)
    let nextFreeIdx = WriteMsgType dest nextFreeIdx MsgType.Logon
    let nextFreeIdx = WriteSenderCompID dest nextFreeIdx senderCompID
    let nextFreeIdx = WriteTargetCompID dest nextFreeIdx targetCompID
    let nextFreeIdx = WriteMsgSeqNum dest nextFreeIdx msgSeqNum
    let nextFreeIdx = WriteSendingTime dest nextFreeIdx sendingTime

    let startTrailer = nextFreeIdx
    let strCheckSum = CheckSum.CheckSum (checksum.ToString("D3")) // checksum is always a three digit number
    let nextFreeIdx = WriteCheckSum dest nextFreeIdx strCheckSum
    let endTrailer = nextFreeIdx
    startHeader, startTrailer, endTrailer






[<EntryPoint>]
let main argv = 

    let logonMsg:Fix44.Messages.Logon = {
        EncryptMethod = EncryptMethod.NoneOther
        HeartBtInt = HeartBtInt.HeartBtInt 30
        RawDataLength = RawDataLength.RawDataLength 128 |> Option.Some
        RawData = RawData.RawData "some data, some more data" |> Option.Some
        ResetSeqNumFlag = ResetSeqNumFlag.ResetSeqNumFlag false |> Option.Some
        NextExpectedMsgSeqNum = NextExpectedMsgSeqNum.NextExpectedMsgSeqNum 99 |> Option.Some
        MaxMessageSize = MaxMessageSize.MaxMessageSize 256 |> Option.Some
        NoMsgTypesGrp = Option.None
        TestMessageIndicator = TestMessageIndicator.TestMessageIndicator true |> Option.Some
        Username = Option.None
        Password = Option.None
        }



    let beginString:BeginString = BeginString.BeginString "FIX.4.4"
    let bodyLength:BodyLength = BodyLength.BodyLength 99
    let msgType:MsgType = MsgType.Logon
    let senderCompID:SenderCompID = SenderCompID.SenderCompID "senderCompID"
    let targetCompID:TargetCompID = TargetCompID.TargetCompID "targetCompID"
    let msgSeqNum:MsgSeqNum = MsgSeqNum.MsgSeqNum 99
    let sendingTime:SendingTime = SendingTime.SendingTime "20071123-05:30:00.000"

    let dest = Array.zeroCreate<byte> 2048
    let nextFreeIdx = 0;
    let startHeader, startTrailer, endTrailer =  WriteLogonx dest nextFreeIdx beginString bodyLength msgType senderCompID targetCompID msgSeqNum sendingTime logonMsg

    let lenHeader = startTrailer - startHeader
    let lenBody = startHeader
    let lenTrailer = endTrailer - startTrailer

    let socketBuf = Array.zeroCreate<byte> 2048
    Buffer.BlockCopy( dest, startHeader,    socketBuf,  0,                      lenHeader ) // copy header to socket buffer
    Buffer.BlockCopy( dest, 0,              socketBuf,  lenHeader,              lenBody ) // copy body to socket buffer
    Buffer.BlockCopy( dest, startTrailer,   socketBuf,  lenHeader + lenBody,    lenTrailer ) // copy header to socket buffer

    let tmp = socketBuf |> Array.map ( fun bb -> 
                                        match bb with
                                        | 1uy   -> '|'
                                        | _     -> System.Convert.ToChar (bb) )
    let str = new string (tmp)
    printfn "%A" str
    
    0 // return an integer exit code
