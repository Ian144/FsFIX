open Fix44.Fields
open Fix44.Messages
open Fix44.MsgWriteFuncs










open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running



type BenchmarkWriteLogon () =

    //member val Dst:byte array =  [||] with get, set
    member val Dst:byte array =  Array.zeroCreate<byte> 2048


    member val BeginString:BeginString = BeginString.BeginString ""
    member val BodyLength:BodyLength = BodyLength.BodyLength 99
    member val MsgType:MsgType = MsgType.Logon
    member val SenderCompID:SenderCompID = SenderCompID.SenderCompID ""
    member val TargetCompID:TargetCompID = TargetCompID.TargetCompID ""
    member val MsgSeqNum:MsgSeqNum = MsgSeqNum.MsgSeqNum 99
    member val SendingTime:SendingTime = SendingTime.SendingTime ""

    
    member val logonMsg:Fix44.Messages.Logon = {
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

//    [<Setup>]
//    member this.SetupArrays () =
//        this.Dst |> Array


// 8=FIX.4.2|9=178|35=8|49=PHLX|56=PERS|52=20071123-05:30:00.000|11=ATOMNOCCC9990900|20=3|150=E|39=E|55=MSFT|167=CS|54=1|38=15|40=2|44=15|58=PHLX EQUITY TESTING|59=0|47=C|32=0|31=0|151=15|14=0|6=0|10=128|


    [<Benchmark>]
    member this.WriteLogonMsg () = 
        let nextFreeIdx = 
            Fix44.MsgWriteFuncs.WriteLogon 
                this.Dst 
                0 
                this.BeginString 
                this.BodyLength 
                this.MsgType 
                this.SenderCompID 
                this.TargetCompID 
                this.MsgSeqNum 
                this.SendingTime 
                this.logonMsg
        ()


[<EntryPoint>]
let main argv = 
    BenchmarkRunner.Run<BenchmarkWriteLogon>() |> ignore
    0
