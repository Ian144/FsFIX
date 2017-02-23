(*
 * Copyright (C) 2016-2017 Ian Spratt <ian144@hotmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301, USA.
 *
 *)
 
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
    member this.ReadComplexNewOrderMultilegMsg () =
        let msg = MsgReadWrite.ReadMessage FIXMsgBuffers.newOrderMultilegBytes FIXMsgBuffers.newOrderMultilegBytes.Length index 
        ()


[<EntryPoint>]
let main argv =
    BenchmarkRunner.Run<BenchmarkMsgReadWrite>( DefaultConfig.Instance.With(Job.RyuJitX64) ) |> ignore
    0










