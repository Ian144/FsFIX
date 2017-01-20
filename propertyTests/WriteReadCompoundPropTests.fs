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

    

type FsFixPropertyTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 100,
        EndSize = 2,
        Verbose = true,
        QuietOnSuccess = true
        )




[<FsFixPropertyTest>]
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
    let msgOut = MsgReadWrite.ReadMessage buf posW
    msg =! msgOut



//------------------------------------



let WriteReadIndexTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:byte[]->FIXBufIndexer.FixBufIndex->'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 256
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let index = FIXBufIndexer.FixBufIndex(indexEnd, fieldPosArr)
    let tOut = readFunc bs index
    tIn =! tOut

[<FsFixPropertyTest>]
let msgUserRequest (msg:Fix44.Messages.UserRequest) = WriteReadIndexTest msg Fix44.MsgWriters.WriteUserRequest Fix44.MsgReaders.ReadUserRequest

// SLOW
//// msg containing a 'NoSides' group
//[<FsFixPropertyTest>]
//let msgNewOrderCross (msg:Fix44.Messages.NewOrderCross) = 
//    WriteReadIndexTest msg Fix44.MsgWriters.WriteNewOrderCross Fix44.MsgReaders.ReadNewOrderCross

[<FsFixPropertyTest>]
let NoCapacitiesGrp (grpIn:NoCapacitiesGrp ) = WriteReadIndexTest grpIn WriteNoCapacitiesGrp Fix44.CompoundItemReaders.ReadNoCapacitiesGrpIdx

[<FsFixPropertyTest>]
let UnderlyingStipulationsGrp (usIn:NoUnderlyingStipsGrp ) = WriteReadIndexTest usIn WriteNoUnderlyingStipsGrp Fix44.CompoundItemReaders.ReadNoUnderlyingStipsGrpIdx

[<FsFixPropertyTest>]
let UnderlyingStipulations (usIn:UnderlyingStipulations) = WriteReadIndexTest usIn WriteUnderlyingStipulations Fix44.CompoundItemReaders.ReadUnderlyingStipulationsIdx

[<FsFixPropertyTest>]
let UnderlyingInstument (usIn:UnderlyingInstrument) = WriteReadIndexTest usIn WriteUnderlyingInstrument Fix44.CompoundItemReaders.ReadUnderlyingInstrumentIdx

[<FsFixPropertyTest>]
let NoSidesGrp (gIn:NoSidesGrp) = WriteReadIndexTest gIn WriteNoSidesGrp Fix44.CompoundItemReaders.ReadNoSidesGrpIdx

[<FsFixPropertyTest>]
let InstrumentLegFG (usIn:InstrumentLegFG) = WriteReadIndexTest usIn WriteInstrumentLegFG Fix44.CompoundItemReaders.ReadInstrumentLegFGIdx




let WriteReadSelectorTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:'t -> byte[]->FIXBufIndexer.FixBufIndex->'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1024
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)
    let tOut = readFunc tIn bs index
    tIn =! tOut


[<FsFixPropertyTest>]
let CompoundItem (ciIn:FIXGroup) = WriteReadSelectorTest ciIn WriteCITest ReadCITest 


[<FsFixPropertyTest>]
let Message (msg:FIXMessage) = WriteReadSelectorTest msg WriteMessage ReadMessage 



