module WriteReadCompoundPropTests

open FsCheck.Xunit
open Swensen.Unquote

open Fix44.Fields
open Fix44.CompoundItems
open Fix44.CompoundItemWriters
open Fix44.CompoundItemDU
open Fix44.MessageDU

open Generators



let bufSize = 1024 * 82 // so as not to go into the LOH

    

type PropTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 100,
        EndSize = 4,
        Verbose = true,
        QuietOnSuccess = true
        )



type PropTestSlow() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 10,
        EndSize = 1,
        Verbose = true,
        QuietOnSuccess = true
        )




[<PropTest>]
let MessageWithHeaderTrailer 
        (beginString:BeginString) 
        (senderCompID:SenderCompID) 
        (targetCompID:TargetCompID) 
        (msgSeqNum:MsgSeqNum) 
        (sendingTime:SendingTime) 
        (msg:FIXMessage) =
    let buf = Array.zeroCreate<byte> bufSize
    let tmpBuf = Array.zeroCreate<byte> bufSize
    let posW = MsgReadWrite.WriteMessageDU 
                                tmpBuf 
                                buf 
                                0 
                                beginString 
                                senderCompID
                                targetCompID
                                msgSeqNum
                                sendingTime
                                msg

//    let ss = FIXBuf.toS buf posW
//    printf "%s" ss

    let msgOut = MsgReadWrite.ReadMessage buf posW
    msg =! msgOut





let WriteReadIndexTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:byte[]->FIXBufIndexer.IndexData->'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let ss = FIXBuf.toS bs posW
    printfn "%s" ss
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1024
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs posW
    let index = FIXBufIndexer.IndexData(indexEnd, fieldPosArr)
    let tOut = readFunc bs index
    tIn =! tOut


[<PropTest>]
let msgUserRequest (msg:Fix44.Messages.UserRequest) = WriteReadIndexTest msg Fix44.MsgWriters.WriteUserRequest Fix44.MsgReaders.ReadUserRequest

//// msg containing a 'NoSides' group
[<PropTestSlow>]
let msgNewOrderCross (msg:Fix44.Messages.NewOrderCross) = 
    WriteReadIndexTest msg Fix44.MsgWriters.WriteNewOrderCross Fix44.MsgReaders.ReadNewOrderCross

[<PropTest>]
let NoCapacitiesGrp (grpIn:NoCapacitiesGrp ) = WriteReadIndexTest grpIn WriteNoCapacitiesGrp Fix44.CompoundItemReaders.ReadNoCapacitiesGrp

[<PropTest>]
let UnderlyingStipulationsGrp (usIn:NoUnderlyingStipsGrp ) = WriteReadIndexTest usIn WriteNoUnderlyingStipsGrp Fix44.CompoundItemReaders.ReadNoUnderlyingStipsGrp


let WriteReadIndexOrderedTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:bool->byte[]->FIXBufIndexer.IndexData->'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1024
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs posW
    let index = FIXBufIndexer.IndexData(indexEnd, fieldPosArr)
    let tOut = readFunc true bs index
    tIn =! tOut



[<PropTest>]
let UnderlyingInstrument (usIn:UnderlyingInstrument ) = WriteReadIndexOrderedTest usIn WriteUnderlyingInstrument Fix44.CompoundItemReaders.ReadUnderlyingInstrumentOrdered


[<PropTest>]
let UnderlyingStipulations (usIn:UnderlyingStipulations) = WriteReadIndexTest usIn WriteUnderlyingStipulations Fix44.CompoundItemReaders.ReadUnderlyingStipulations

[<PropTest>]
let UnderlyingInstument (usIn:UnderlyingInstrument) = WriteReadIndexTest usIn WriteUnderlyingInstrument Fix44.CompoundItemReaders.ReadUnderlyingInstrument

[<PropTest>]
let NoSidesGrp (gIn:NoSidesGrp) = WriteReadIndexTest gIn WriteNoSidesGrp Fix44.CompoundItemReaders.ReadNoSidesGrp

[<PropTest>]
let InstrumentLegFG (usIn:InstrumentLegFG) = WriteReadIndexTest usIn WriteInstrumentLegFG Fix44.CompoundItemReaders.ReadInstrumentLegFG


[<PropTest>]
let MarketDataSnapshotFullRefresh (usIn:Fix44.Messages.MarketDataSnapshotFullRefresh) = WriteReadIndexTest usIn Fix44.MsgWriters.WriteMarketDataSnapshotFullRefresh Fix44.MsgReaders.ReadMarketDataSnapshotFullRefresh


[<PropTest>]
let CollateralInquiry (usIn:Fix44.Messages.CollateralInquiry) = WriteReadIndexTest usIn Fix44.MsgWriters.WriteCollateralInquiry Fix44.MsgReaders.ReadCollateralInquiry


let WriteReadSelectorTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:'t -> byte[]->FIXBufIndexer.IndexData->'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1024
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs posW
    let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)
    let tOut = readFunc tIn bs index
    tIn =! tOut


[<PropTest>]
let CompoundItem (ciIn:FIXGroup) = WriteReadSelectorTest ciIn WriteCITest ReadCITest 


[<PropTest>]
let Message (msg:FIXMessage) = WriteReadSelectorTest msg WriteMessage ReadMessage 



