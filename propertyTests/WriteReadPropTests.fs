module WriteReadRoundtrip

open System.Reflection

open Xunit
open FsCheck
open FsCheck.Xunit
open Swensen.Unquote


open Fix44.Fields
open Fix44.FieldWriters
open Fix44.FieldReaders

open Fix44.FieldDU

open Fix44.CompoundItems
open Fix44.CompoundItemWriters
open Fix44.CompoundItemDU
open Fix44.MessageDU

open Generators



let bufSize = 1024 * 82 // so as not to go into the LOH



    

type FsFixPropertyTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 10,
        EndSize = 4,
        Verbose = false
//        QuietOnSuccess = true
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
    //todo: check that all field index entries have been read





let WriteReadIndexTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:byte[]->FIXBufIndexer.FixBufIndex->'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs bs.Length
    let index = FIXBufIndexer.FixBufIndex(indexEnd, fieldPosArr)
    let tOut = readFunc bs index
    tIn =! tOut


let WriteReadTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:byte[]->int->int->'t) =
    let bs = Array.zeroCreate<byte> bufSize
    writeFunc bs 0 tIn |> ignore
    let tOut = readFunc bs 0 bs.Length
    tIn =! tOut


// write-read test for fields, where the tag written by the write function should be ignored, as field read functions only read the body. 
// The tag is read elsewhere and used to find the field read func
let WriteReadFieldTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:byte[]->int->int->'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let posSep = FIXBuf.findNextTagValSep bs 0
    let len = bs.Length - (posSep+1)
    let tOut = readFunc bs (posSep+1) len
    tIn =! tOut



let WriteReadTestAppendFieldTerm (tIn:'t) (writeFunc:byte[]->int->'t->int) readFunc =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    bs.[posW] <- 1uy
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs bs.Length
    let fpData = fieldPosArr.[0]
    let tOut = readFunc bs fpData.Pos fpData.Len
    tIn =! tOut


[<FsFixPropertyTest>]
let monthYear (tm:MonthYear.MonthYear) = 
    WriteReadTestAppendFieldTerm tm MonthYear.write MonthYear.read


[<FsFixPropertyTest>]
let dtTZTimeOnly (tm:TZDateTime.TZTimeOnly) =  WriteReadTest tm TZDateTime.writeTZTimeOnly TZDateTime.readTZTimeOnly


[<FsFixPropertyTest>]
let msgUserRequest (msg:Fix44.Messages.UserRequest) = WriteReadIndexTest msg Fix44.MsgWriters.WriteUserRequest Fix44.MsgReaders.ReadUserRequest


// msg containing a 'NoSides' group
[<FsFixPropertyTest>]
let msgNewOrderCross (msg:Fix44.Messages.NewOrderCross) = WriteReadIndexTest msg Fix44.MsgWriters.WriteNewOrderCross Fix44.MsgReaders.ReadNewOrderCross


[<FsFixPropertyTest>]
let PosMaintRptID (fldIn:Fix44.Fields.PosMaintRptID) = WriteReadFieldTest fldIn Fix44.FieldWriters.WritePosMaintRptID Fix44.FieldReaders.ReadPosMaintRptIDIdx



// MDEntryTime wraps UTCTimeOnly
[<FsFixPropertyTest>]
let MDEntryTime (fldIn:Fix44.Fields.MDEntryTime) = WriteReadFieldTest fldIn Fix44.FieldWriters.WriteMDEntryTime Fix44.FieldReaders.ReadMDEntryTimeIdx


// RawData is a compound len+data field, the data portion of which may contain field or tag-value seperators
[<FsFixPropertyTest>]
let RawData (fldIn:Fix44.Fields.RawData) = WriteReadFieldTest fldIn Fix44.FieldWriters.WriteRawData Fix44.FieldReaders.ReadRawDataIdx



// a very slow test due to the large number of Field DU instances
// will disable/enable this test as required
//[<FsFixPropertyTest>]
//let AllFields (tIn:FIXField) = 
//    let bs = Array.zeroCreate<byte> bufSize
//    let posW = WriteField bs 0 tIn
//    let posSep = FIXBuf.findNextTagValSep bs 0
//    let tOut = ReadField bs (posSep+1) 
//    tIn =! tOut




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
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)
    let tOut = readFunc tIn bs index
    tIn =! tOut


[<FsFixPropertyTest>]
let CompoundItem (ciIn:FIXGroup) = WriteReadSelectorTest ciIn WriteCITest ReadCITest 


[<FsFixPropertyTest>]
let Message (msg:FIXMessage) = WriteReadSelectorTest msg WriteMessage ReadMessage 



