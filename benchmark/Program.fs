open Fix44.Fields
open Fix44.Messages
open Fix44.MsgWriters
open Fix44.CompoundItems

open Fix44.CompoundItemFactoryFuncs
open Fix44.MessageFactoryFuncs



open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running

open BenchmarkDotNet.Configs
open BenchmarkDotNet.Diagnosers
open BenchmarkDotNet.Jobs

//private class Config : ManualConfig
//{
//    public Config()
//    {
//        Add(MemoryDiagnoser.Default);
//        Add(new InliningDiagnoser());
//    }
//}


//type MyConfig () as this =
//    inherit ManualConfig()
//    do
////        let md:IDiagnoser = BenchmarkDotNet.Diagnosers.MemoryDiagnoser() :> IDiagnoser
//        let cd:IDiagnoser = BenchmarkDotNet.Diagnosers.CompositeDiagnoser() :> IDiagnoser
//        this.Add cd





let Dst:byte array =  Array.zeroCreate<byte> 2048
let bufSize = 1024 * 16
let buf:byte array = Array.zeroCreate<byte> bufSize
let tmpBuf:byte array =  Array.zeroCreate<byte> bufSize
let beginString:BeginString = BeginString.BeginString "FIX.4.4"
let senderCompID:SenderCompID = SenderCompID.SenderCompID "senderCompID"
let targetCompID:TargetCompID = TargetCompID.TargetCompID "targetCompID"
let msgSeqNum:MsgSeqNum = MsgSeqNum.MsgSeqNum 99u
let sendingTime:SendingTime = SendingTime.SendingTime (UTCDateTime.readUTCTimestamp "20071123-05:30:00.000"B 0 21)

let index = Array.zeroCreate<FIXBufIndexer.FieldPos> 2048

let quoteRequestMsg = BenchMsgs.quoteStatusRequestIncGroup
let quoteRequestNestedGroupsMsg = BenchMsgs.quoteStatusRequestIncNestedGroup
let newOrderMultiLegMsg = BenchMsgs.newOrderMultileg
let marketDataRequest = BenchMsgs.marketDataRequest

//http://benchmarkdotnet.org/Configs/Configs.htm
//[<Config("columns=Mean,StdDev,Gen0,Gen1,Gen2,Allocated")>]
type BenchmarkMsgReadWrite () =

    [<Benchmark>]
    member this.WriteMarketDataRequest() =
        let msg = marketDataRequest |> Fix44.MessageDU.MarketDataRequest
        let posW = MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString senderCompID targetCompID msgSeqNum sendingTime msg
        ()

    [<Benchmark>]
    member this.WriteQuoteStatusRequestMsgWithGroup () =
        let msg = quoteRequestMsg |> Fix44.MessageDU.QuoteStatusRequest
        let posW = MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString senderCompID targetCompID msgSeqNum sendingTime msg
        ()

    [<Benchmark>]
    member this.WriteQuoteStatusRequestWithNestedGroup () =
        let msg = quoteRequestMsg |> Fix44.MessageDU.QuoteStatusRequest
        let posW = MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString senderCompID targetCompID msgSeqNum sendingTime msg
        ()

    [<Benchmark>]
    member this.WriteComplexNewOrderMultiLegMsg () =
        let msg = newOrderMultiLegMsg |> Fix44.MessageDU.NewOrderMultileg
        let posW = MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString senderCompID targetCompID msgSeqNum sendingTime msg
        ()

    [<Benchmark>]
    member this.ReadMarketDataRequest () =
        let msg = MsgReadWrite.ReadMessage FIXMsgBuffers.marketDataRequest FIXMsgBuffers.marketDataRequest.Length index
        ()


    [<Benchmark>]
    member this.ReadQuoteStatusRequestWithGroup () =
        let msg = MsgReadWrite.ReadMessage FIXMsgBuffers.quoteStatusRequestWithGrpBytes FIXMsgBuffers.quoteStatusRequestWithGrpBytes.Length index
        ()

    [<Benchmark>]
    member this.ReadQuoteStatusRequestWithNestedGroups () =
        let msg = MsgReadWrite.ReadMessage FIXMsgBuffers.quoteStatusRequestWithNestedGrpsBytes FIXMsgBuffers.quoteStatusRequestWithNestedGrpsBytes.Length index
        ()

    [<Benchmark>]
    member this.ReadNewOrderMultilegMsg () =
        let msg = MsgReadWrite.ReadMessage FIXMsgBuffers.newOrderMultilegBytes FIXMsgBuffers.newOrderMultilegBytes.Length index 
        ()


[<EntryPoint>]
let main argv =
    BenchmarkRunner.Run<BenchmarkMsgReadWrite>( DefaultConfig.Instance.With(Job.RyuJitX64) ) |> ignore
    0










