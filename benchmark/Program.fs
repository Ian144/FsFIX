open Fix44.Fields
open Fix44.Messages
open Fix44.MsgWriteFuncs










open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running



//// tag: A
//let WriteLogon2 (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:Logon) =
//    let mutable nextFreeIdx = nextFreeIdx
//    nextFreeIdx <- WriteEncryptMethod dest nextFreeIdx xx.EncryptMethod
//    nextFreeIdx <- WriteHeartBtInt dest nextFreeIdx xx.HeartBtInt
//
//    if xx.RawDataLength.IsSome then nextFreeIdx <- WriteRawDataLength dest nextFreeIdx xx.RawDataLength.Value
//    if xx.RawData.IsSome then nextFreeIdx <- WriteRawData dest nextFreeIdx xx.RawData.Value
//
//    if xx.ResetSeqNumFlag.IsSome then nextFreeIdx <- WriteResetSeqNumFlag dest nextFreeIdx xx.ResetSeqNumFlag.Value
//    if xx.NextExpectedMsgSeqNum.IsSome then nextFreeIdx <- WriteNextExpectedMsgSeqNum dest nextFreeIdx xx.NextExpectedMsgSeqNum.Value
//    if xx.MaxMessageSize.IsSome then nextFreeIdx <- WriteMaxMessageSize dest nextFreeIdx xx.MaxMessageSize.Value
//
//    nextFreeIdx <- Option.fold (fun innerNextFreeIdx (gs:NoMsgTypesGrp list) ->
//                                        let numGrps = gs.Length
//                                        let innerNextFreeIdx2 = WriteNoMsgTypes dest innerNextFreeIdx (Fix44.Fields.NoMsgTypes numGrps) // write the 'num group repeats' field
//                                        List.fold (fun accFreeIdx gg -> WriteNoMsgTypesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
//                                  nextFreeIdx
//                                  xx.NoMsgTypesGrp  // end Option.fold
//
//    if xx.TestMessageIndicator.IsSome then nextFreeIdx <- WriteTestMessageIndicator dest nextFreeIdx xx.TestMessageIndicator.Value
//    if xx.Username.IsSome then nextFreeIdx <- WriteUsername dest nextFreeIdx xx.Username.Value
//    if xx.Password.IsSome then nextFreeIdx <- WritePassword dest nextFreeIdx xx.Password.Value
//    nextFreeIdx



type BenchmarkWriteLogon () =

    //member val Dst:byte array =  [||] with get, set
    member val Dst:byte array =  Array.zeroCreate<byte> 2048


    member val BeginString:BeginString = BeginString.BeginString "FIX.4.4"
    member val BodyLength:BodyLength = BodyLength.BodyLength 99u
    member val MsgType:MsgType = MsgType.Logon
    member val SenderCompID:SenderCompID = SenderCompID.SenderCompID "senderCompID"
    member val TargetCompID:TargetCompID = TargetCompID.TargetCompID "targetCompID"
    member val MsgSeqNum:MsgSeqNum = MsgSeqNum.MsgSeqNum 99u
    member val SendingTime:SendingTime = SendingTime.SendingTime (UTCDateTime.readUTCTimestamp "20071123-05:30:00.000"B 0 21)


    member val logonMsg:Fix44.Messages.Logon = {
        EncryptMethod = EncryptMethod.NoneOther
        HeartBtInt = HeartBtInt.HeartBtInt 30
        RawData = RawData.RawData "some data, some more data"B |> Option.Some
        ResetSeqNumFlag = ResetSeqNumFlag.ResetSeqNumFlag false |> Option.Some
        NextExpectedMsgSeqNum = NextExpectedMsgSeqNum.NextExpectedMsgSeqNum 99u |> Option.Some
        MaxMessageSize = MaxMessageSize.MaxMessageSize 256u |> Option.Some
        NoMsgTypesGrp = Option.None
        TestMessageIndicator = TestMessageIndicator.TestMessageIndicator true |> Option.Some
        Username = Option.None
        Password = Option.None
    }


// 8=FIX.4.2|9=178|35=8|49=PHLX|56=PERS|52=20071123-05:30:00.000|11=ATOMNOCCC9990900|20=3|150=E|39=E|55=MSFT|167=CS|54=1|38=15|40=2|44=15|58=PHLX EQUITY TESTING|59=0|47=C|32=0|31=0|151=15|14=0|6=0|10=128|


    [<Benchmark>]
    member this.WriteLogonMsg () =
        let nextFreeIdx =
            Fix44.MsgWriteFuncs.WriteLogon
                this.Dst
                0
//                this.BeginString
//                this.BodyLength
//                this.MsgType
//                this.SenderCompID
//                this.TargetCompID
//                this.MsgSeqNum
//                this.SendingTime
                this.logonMsg
        ()


    [<Benchmark>]
    member this.WriteLogonMsg2 () =
        let nextFreeIdx =
            Fix44.MsgWriteFuncs.WriteLogon
                this.Dst
                0
//                this.BeginString
//                this.BodyLength
//                this.MsgType
//                this.SenderCompID
//                this.TargetCompID
//                this.MsgSeqNum
//                this.SendingTime
                this.logonMsg
        ()


[<EntryPoint>]
let main argv =
    BenchmarkRunner.Run<BenchmarkWriteLogon>() |> ignore
    0
