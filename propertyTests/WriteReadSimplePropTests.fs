module WriteReadSimplePropTests

open FsCheck.Xunit
open Swensen.Unquote




open Generators



let bufSize = 1024 * 4


    

type FsFixPropertyTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 10000, // simple, i.e. a single field or date+time value a faster for fscheck to create so MaxTest and EndSize can be higher
        EndSize = 1000,
        Verbose = false,
        QuietOnSuccess = true
        )



let WriteReadTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:byte[]->int->int->'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let tOut = readFunc bs 0 posW
    tIn =! tOut


[<FsFixPropertyTest>]
let monthYear (tm:MonthYear.MonthYear) =  WriteReadTest tm MonthYear.write MonthYear.read


[<FsFixPropertyTest>]
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



[<FsFixPropertyTest>]
let PosMaintRptID (fldIn:Fix44.Fields.PosMaintRptID) = WriteReadFieldTest fldIn Fix44.FieldWriters.WritePosMaintRptID Fix44.FieldReaders.ReadPosMaintRptIDIdx

// MDEntryTime wraps UTCTimeOnly
[<FsFixPropertyTest>]
let MDEntryTime (fldIn:Fix44.Fields.MDEntryTime) = WriteReadFieldTest fldIn Fix44.FieldWriters.WriteMDEntryTime Fix44.FieldReaders.ReadMDEntryTimeIdx


// RawData is a compound len+data field, the data portion of which may contain field or tag-value seperators
[<FsFixPropertyTest>]
let RawData (fldIn:Fix44.Fields.RawData) = WriteReadFieldTest fldIn Fix44.FieldWriters.WriteRawData Fix44.FieldReaders.ReadRawDataIdx



type FsFixSlowPropertyTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 10,
        EndSize = 2,
        Verbose = false,
        QuietOnSuccess = true
        )


// a very slow test due to the large number of Field DU instances
// will disable/enable this test as required
[<FsFixSlowPropertyTest>]
let AllFields (tIn:Fix44.FieldDU.FIXField) = 
    let bs = Array.zeroCreate<byte> bufSize
    let posW = Fix44.FieldDU.WriteField bs 0 tIn
    let posSep = FIXBuf.findNextTagValSep bs 0
    let tOut = Fix44.FieldDU.ReadField bs (posSep+1) // +1 to move past the tag-value seperator
    tIn =! tOut





