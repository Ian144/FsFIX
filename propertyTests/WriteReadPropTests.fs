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
        MaxTest = 100,
        EndSize = 8,
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
    let posR, msgOut = MsgReadWrite.ReadMessage buf
    msg =! msgOut
    posW =! posR


// most write-read tests follow this form
let WriteReadTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:byte[]->int->int*'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let posR, tOut = readFunc bs 0
    tIn =! tOut
    posW =! posR



// write-read test for fields, where the tag written by the write function should be ignored. as field read functions only read the body. The tag is read elsewhere and used to find the field read func
let WriteReadFieldTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:byte[]->int->int*'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let posSep = FIXBuf.findNextTagValSep bs 0
    let posR, tOut = readFunc bs (posSep+1)
    tIn =! tOut
    posW =! posR


let WriteReadTestAppendFieldTerm (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:byte[]->int->int*'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    bs.[posW] <- 1uy
    let posR, tOut = readFunc bs 0
    tIn =! tOut
    posW =! posR


[<FsFixPropertyTest>]
let monthYear (tm:MonthYear.MonthYear) = WriteReadTestAppendFieldTerm tm MonthYear.write MonthYear.read


[<FsFixPropertyTest>]
let dtTZTimeOnly (tm:TZDateTime.TZTimeOnly) =  WriteReadTest tm TZDateTime.writeTZTimeOnly TZDateTime.readTZTimeOnly


[<FsFixPropertyTest>]
let msgUserRequest (msg:Fix44.Messages.UserRequest) = WriteReadTest msg Fix44.MsgWriters.WriteUserRequest Fix44.MsgReaders.ReadUserRequest


// msg containing a 'NoSides' group
[<FsFixPropertyTest>]
let msgNewOrderCross (msg:Fix44.Messages.NewOrderCross) = WriteReadTest msg Fix44.MsgWriters.WriteNewOrderCross Fix44.MsgReaders.ReadNewOrderCross


[<FsFixPropertyTest>]
let PosMaintRptID (fldIn:Fix44.Fields.PosMaintRptID) = WriteReadFieldTest fldIn Fix44.FieldWriters.WritePosMaintRptID Fix44.FieldReaders.ReadPosMaintRptID



// MDEntryTime wraps UTCTimeOnly
[<FsFixPropertyTest>]
let MDEntryTime (fldIn:Fix44.Fields.MDEntryTime) = WriteReadFieldTest fldIn Fix44.FieldWriters.WriteMDEntryTime Fix44.FieldReaders.ReadMDEntryTime


// RawData is a compound len+data field, the data portion of which may contain field or tag-value seperators
[<FsFixPropertyTest>]
let RawData (fldIn:Fix44.Fields.RawData) = WriteReadFieldTest fldIn Fix44.FieldWriters.WriteRawData Fix44.FieldReaders.ReadRawData



// a very slow test due to the large number of Field DU instances
// will re-enable this test occasionally
[<FsFixPropertyTest>]
let AllFields (fieldIn:FIXField) = WriteReadTest fieldIn WriteField ReadField



[<FsFixPropertyTest>]
let NoCapacitiesGrp (grpIn:NoCapacitiesGrp ) = WriteReadTest grpIn WriteNoCapacitiesGrp Fix44.CompoundItemReaders.ReadNoCapacitiesGrp



[<FsFixPropertyTest>]
let UnderlyingStipulationsGrp (usIn:NoUnderlyingStipsGrp ) = WriteReadTest usIn WriteNoUnderlyingStipsGrp Fix44.CompoundItemReaders.ReadNoUnderlyingStipsGrp



[<FsFixPropertyTest>]
let UnderlyingStipulations (usIn:UnderlyingStipulations) = WriteReadTest usIn WriteUnderlyingStipulations Fix44.CompoundItemReaders.ReadUnderlyingStipulations
        


[<FsFixPropertyTest>]
let UnderlyingInstument (usIn:UnderlyingInstrument) = WriteReadTest usIn WriteUnderlyingInstrument Fix44.CompoundItemReaders.ReadUnderlyingInstrument



[<FsFixPropertyTest>]
let NoSidesGrp (gIn:NoSidesGrp) = WriteReadTest gIn WriteNoSidesGrp Fix44.CompoundItemReaders.ReadNoSidesGrp


[<FsFixPropertyTest>]
let InstrumentLegFG (usIn:InstrumentLegFG) = WriteReadTest usIn WriteInstrumentLegFG Fix44.CompoundItemReaders.ReadInstrumentLegFG



let WriteReadSelectorTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:'t -> byte[]->int->int*'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let posR, tOut = readFunc tIn bs 0
    posW =! posR
    tIn =! tOut

[<FsFixPropertyTest>]
let CompoundItem (ciIn:FIXGroup) = WriteReadSelectorTest ciIn WriteCITest ReadCITest


[<FsFixPropertyTest>]
let Message (msg:FIXMessage) = WriteReadSelectorTest msg WriteMessage ReadMessage



