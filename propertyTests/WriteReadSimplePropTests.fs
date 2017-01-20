module WriteReadSimplePropTests

open FsCheck.Xunit
open Swensen.Unquote




open Generators



let bufSize = 1024 * 4


    

type PropTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 10000, // simple, i.e. a single specific field or date+time value is faster for fscheck to create so MaxTest and EndSize can be higher
        EndSize = 1000,
        Verbose = true,
        QuietOnSuccess = true
        )



let WriteReadTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:byte[]->int->int->'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let tOut = readFunc bs 0 posW
    tIn =! tOut


[<PropTest>]
let monthYear (tm:MonthYear.MonthYear) =  WriteReadTest tm MonthYear.write MonthYear.read


[<PropTest>]
let dtTZTimeOnly (tm:TZDateTime.TZTimeOnly) =  WriteReadTest tm TZDateTime.writeTZTimeOnly TZDateTime.readTZTimeOnly


let WriteReadFieldTest (tIn:'t) (writeFunc:byte[]->int->'t->int) readFunc =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    bs.[posW] <- 1uy // append a field terminator
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let fpData = fieldPosArr.[0]
    let tOut = readFunc bs fpData.Pos fpData.Len
    tIn =! tOut



[<PropTest>]
let PosMaintRptID (fldIn:Fix44.Fields. PosMaintRptID) = 
    WriteReadFieldTest fldIn Fix44.FieldWriters.WritePosMaintRptID Fix44.FieldReaders.ReadPosMaintRptIDIdx

// MDEntryTime wraps UTCTimeOnly
[<PropTest>]
let MDEntryTime (fldIn:Fix44.Fields.MDEntryTime) = WriteReadFieldTest fldIn Fix44.FieldWriters.WriteMDEntryTime Fix44.FieldReaders.ReadMDEntryTimeIdx


// RawData is a compound len+data field, the data portion of which may contain field or tag-value seperators
[<PropTest>]
let RawData (fldIn:Fix44.Fields.RawData) = WriteReadFieldTest fldIn Fix44.FieldWriters.WriteRawData Fix44.FieldReaders.ReadRawDataIdx



[<PropTest>]
let SecurityRequestType (fldIn:Fix44.Fields.SecurityRequestType) = WriteReadFieldTest fldIn Fix44.FieldWriters.WriteSecurityRequestType Fix44.FieldReaders.ReadSecurityRequestTypeIdx



type PropTest2() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 10000,
        EndSize = 16,
        Verbose = false,
        QuietOnSuccess = true
        )



// will disable/enable this test as required
[<PropTest2>]
let AllFields (tIn:Fix44.FieldDU.FIXField) = 
    let bs = Array.zeroCreate<byte> bufSize
    let posW = Fix44.FieldDU.WriteField bs 0 tIn
    let tOut = Fix44.FieldDU.ReadField bs 0
    tIn =! tOut





