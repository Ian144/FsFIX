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

open BenchmarkDotNet.Attributes.Columns


let Dst:byte array =  Array.zeroCreate<byte> 2048
let bufSize = 1024 * 16
let buf:byte array = Array.zeroCreate<byte> bufSize
let tmpBuf:byte array =  Array.zeroCreate<byte> bufSize
let beginString:BeginString = BeginString.BeginString "FIX.4.4"
let senderCompID:SenderCompID = SenderCompID.SenderCompID "senderCompID"
let targetCompID:TargetCompID = TargetCompID.TargetCompID "targetCompID"
let msgSeqNum:MsgSeqNum = MsgSeqNum.MsgSeqNum 99u
let sendingTime:SendingTime = SendingTime.SendingTime (UTCDateTime.readUTCTimestamp "20071123-05:30:00.000"B 0 21)

let quoteRequestMsg = BenchMsgs.quoteStatusRequestIncGroup
let quoteRequestNestedGroupsMsg = BenchMsgs.quoteStatusRequestIncNestedGroup
let newOrderMultiLegMsg = BenchMsgs.newOrderMultileg
let marketDataRequest = BenchMsgs.marketDataRequest



let index = Array.zeroCreate<FIXBufIndexer.FieldPos> 2048


let ReadField bs (index:FIXBufIndexer.IndexData) tag readFunc = 
    let fieldPosArr = index.FieldPosArr
    let tagIdx = FIXBufIndexer.FindFieldIdx index index.EndPos tag
    if tagIdx <> -1 then 
        let fpData = fieldPosArr.[tagIdx] // this is the expected case, and so comes first
        index.LastReadIdx <- tagIdx
        let fld = readFunc bs fpData.Pos fpData.Len
//        fieldPosArr.[tagIdx] <- FIXBufIndexer.emptyFieldPos
        fld
    else
        failwithf "field not found, tag: %d" tag



let ReadOptionalField (bs:byte[]) (index:FIXBufIndexer.IndexData) (tag:int) readFunc = 
    let fieldPosArr = index.FieldPosArr
    let tagIdx = FIXBufIndexer.FindFieldIdx index index.EndPos tag
    if tagIdx = -1 then // no preference as to wether the common case is Option.None or not
        Option.None
    else
        index.LastReadIdx <- tagIdx
        let fpData = fieldPosArr.[tagIdx]
        let fld = readFunc bs fpData.Pos fpData.Len
        //fieldPosArr.[tagIdx] <- FIXBufIndexer.emptyFieldPos
        Option.Some fld


let inline ReadFieldInline bs (index:FIXBufIndexer.IndexData) tag readFunc = 
    let fieldPosArr = index.FieldPosArr
    let tagIdx = FIXBufIndexer.FindFieldIdx index index.EndPos tag
    if tagIdx <> -1 then 
        let fpData = fieldPosArr.[tagIdx] // this is the expected case, and so comes first
        index.LastReadIdx <- tagIdx
        let fld = readFunc bs fpData.Pos fpData.Len
//        fieldPosArr.[tagIdx] <- FIXBufIndexer.emptyFieldPos
        fld
    else
        failwithf "field not found, tag: %d" tag



let inline ReadOptionalFieldInline (bs:byte[]) (index:FIXBufIndexer.IndexData) (tag:int) readFunc = 
    let fieldPosArr = index.FieldPosArr
    let tagIdx = FIXBufIndexer.FindFieldIdx index index.EndPos tag
    if tagIdx = -1 then // no preference as to wether the common case is Option.None or not
        Option.None
    else
        index.LastReadIdx <- tagIdx
        let fpData = fieldPosArr.[tagIdx]
        let fld = readFunc bs fpData.Pos fpData.Len
        //fieldPosArr.[tagIdx] <- FIXBufIndexer.emptyFieldPos
        Option.Some fld



[<MedianColumn; MemoryDiagnoser>]
type BenchmarkIndexedFieldReads () = 

    let mutable indexEnd = 0
    let mutable (bs:byte array) = [||]

    // for the purpose of these benchmarks it does not matter if the field is defined as required or optional in the FIX message

    [<Setup>]
    member this.Setup () =
        bs <- FIXMsgBuffers.newOrderMultilegBytes
        System.Array.Clear (index, 0, index.Length)
        indexEnd <- FIXBufIndexer.BuildIndex index bs bs.Length


    [<Benchmark>]
    member this.IndexComplexNewOrderMultilegMsg () =
        let bs = FIXMsgBuffers.newOrderMultilegBytes
        FIXBufIndexer.BuildIndex index bs bs.Length

   
    [<Benchmark>]
    member this.IndexMarketDataRequest () =
        let bs = FIXMsgBuffers.marketDataRequest
        FIXBufIndexer.BuildIndex index bs bs.Length


//    [<Benchmark>]
//    member this.FindIndexBeginingBuf () =
//        let indexData = FIXBufIndexer.IndexData (indexEnd, index)
//        FIXBufIndexer.FindFieldIdx indexData indexEnd 49
//
//
//    [<Benchmark>]
//    member this.FindIndexEndBuf () =
//        let indexData = FIXBufIndexer.IndexData (indexEnd, index)
//        FIXBufIndexer.FindFieldIdx indexData indexEnd 10
//
//
//    [<Benchmark>]
//    member this.ReadOptionalFieldPresentBeginingBuf () =
//        let indexData = FIXBufIndexer.IndexData (indexEnd, index)
//        ReadOptionalField bs indexData 49 Fix44.FieldReaders.ReadSenderCompID
//
//    [<Benchmark>]
//    member this.ReadOptionalFieldPresentBeginingBufInline () =
//        let indexData = FIXBufIndexer.IndexData (indexEnd, index)
//        ReadOptionalFieldInline bs indexData 49 Fix44.FieldReaders.ReadSenderCompID
//
//
//
//    [<Benchmark>]
//    member this.ReadOptionalFieldPresentEndBuf () =
//        let indexData = FIXBufIndexer.IndexData (indexEnd, index)
//        ReadOptionalField bs indexData 10 Fix44.FieldReaders.ReadCheckSum
//
//
//    [<Benchmark>]
//    member this.ReadOptionalFieldPresentEndBufInline () =
//        let indexData = FIXBufIndexer.IndexData (indexEnd, index)
//        ReadOptionalFieldInline bs indexData 10 Fix44.FieldReaders.ReadCheckSum
//
//
//    [<Benchmark>]
//    member this.ReadOptionalFieldNotPresent () =
//        let indexData = FIXBufIndexer.IndexData (indexEnd, index)
//        ReadOptionalField bs indexData 498 Fix44.FieldReaders.ReadDesignation
//
//
//    [<Benchmark>]
//    member this.ReadOptionalFieldNotPresentInline () =
//        let indexData = FIXBufIndexer.IndexData (indexEnd, index)
//        ReadOptionalFieldInline bs indexData 498 Fix44.FieldReaders.ReadDesignation
//
//
//    [<Benchmark>]
//    member this.ReadRequiredFieldAtBeginingBuf () =
//        let indexData = FIXBufIndexer.IndexData (indexEnd, index)
//        ReadField bs indexData 49 Fix44.FieldReaders.ReadSenderCompID
//
//
//    [<Benchmark>]
//    member this.ReadRequiredFieldAtBeginingBufInline () =
//        let indexData = FIXBufIndexer.IndexData (indexEnd, index)
//        ReadFieldInline bs indexData 49 Fix44.FieldReaders.ReadSenderCompID
//
//
//    [<Benchmark>]
//    member this.ReadRequiredFieldAtEndBuf () =
//        let indexData = FIXBufIndexer.IndexData (indexEnd, index)
//        ReadField bs indexData 10 Fix44.FieldReaders.ReadCheckSum
//
//
//    [<Benchmark>]
//    member this.ReadRequiredFieldAtEndBufInline () =
//        let indexData = FIXBufIndexer.IndexData (indexEnd, index)
//        ReadFieldInline bs indexData 10 Fix44.FieldReaders.ReadCheckSum




//http://benchmarkdotnet.org/Configs/Configs.htm
//[<Config("columns=Mean,StdDev,Gen0,Gen1,Gen2,Allocated")>]
[<MedianColumn; MemoryDiagnoser>]
type BenchmarkMsgReadWrite () =

    [<Benchmark>]
    member this.WriteMarketDataRequest() =
        let msg = marketDataRequest |> Fix44.MessageDU.MarketDataRequest
        MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString senderCompID targetCompID msgSeqNum sendingTime msg


    [<Benchmark>]
    member this.WriteQuoteStatusRequestMsgWithGroup () =
        let msg = quoteRequestMsg |> Fix44.MessageDU.QuoteStatusRequest
        MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString senderCompID targetCompID msgSeqNum sendingTime msg


    [<Benchmark>]
    member this.WriteQuoteStatusRequestWithNestedGroup () =
        let msg = quoteRequestNestedGroupsMsg |> Fix44.MessageDU.QuoteStatusRequest
        MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString senderCompID targetCompID msgSeqNum sendingTime msg


    [<Benchmark>]
    member this.WriteComplexNewOrderMultiLegMsg () =
        let msg = newOrderMultiLegMsg |> Fix44.MessageDU.NewOrderMultileg
        MsgReadWrite.WriteMessageDU tmpBuf buf 0 beginString senderCompID targetCompID msgSeqNum sendingTime msg


    [<Benchmark>]
    member this.ReadMarketDataRequest () =
        MsgReadWrite.ReadMessage FIXMsgBuffers.marketDataRequest FIXMsgBuffers.marketDataRequest.Length index



    [<Benchmark>]
    member this.ReadQuoteStatusRequestWithGroup () =
        MsgReadWrite.ReadMessage FIXMsgBuffers.quoteStatusRequestWithGrpBytes FIXMsgBuffers.quoteStatusRequestWithGrpBytes.Length index


    [<Benchmark>]
    member this.ReadQuoteStatusRequestWithNestedGroups () =
        MsgReadWrite.ReadMessage FIXMsgBuffers.quoteStatusRequestWithNestedGrpsBytes FIXMsgBuffers.quoteStatusRequestWithNestedGrpsBytes.Length index


    [<Benchmark>]
    member this.ReadComplexNewOrderMultilegMsg () =
        MsgReadWrite.ReadMessage FIXMsgBuffers.newOrderMultilegBytes FIXMsgBuffers.newOrderMultilegBytes.Length index 



[<EntryPoint>]
let main argv =

//    BenchmarkRunner.Run<BenchmarkIndexedFieldReads>( DefaultConfig.Instance.With(Job.RyuJitX64) ) |> ignore
    BenchmarkRunner.Run<BenchmarkMsgReadWrite>( DefaultConfig.Instance.With(Job.RyuJitX64) ) |> ignore
    0










