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

open DateTimeGenerators



let bufSize = 1024 * 82 // so as not to go into the LOH


// strings stored in FIX do not contain field terminators, 
// let genAlphaChar = Gen.choose(32,255) |> Gen.map char 
let genAlphaChar = Gen.choose(65,90) |> Gen.map char 
//let genAlphaCharArray = Gen.arrayOfLength 16 genAlphaChar 
let genAlphaString = 
        gen{
            let! len = Gen.choose(4, 8)
            let! chars = Gen.arrayOfLength len genAlphaChar
            return System.String chars
        }

let genChar = Gen.choose(32,255) |> Gen.map char 


// FIX specifies decimals contain a max of 15 decimal places, allowing fscheck to generate decimals with more DP than this will create errors.
// Adapted from fscheck code.
let genDecimal15dp =
    gen {
        let! lo = Arb.generate
        let! mid = Arb.generate
        let! hi = Arb.generate
        let! isNegative = Arb.generate
        let! scale = Gen.choose(0, 28) |> Gen.map byte
        let d1 = System.Decimal(lo, mid, hi, isNegative, scale)
        return System.Math.Round(d1, 15)
    }


let genCurrency = 
    gen {
        let! ss = Gen.elements [ "GBP"; "USD"; "EUR"; "SGD" ]
        return Fix44.Fields.Currency ss
    }
    

let genCountry = 
    gen {
       let! ss = Gen.elements [ "AD"; "AE"; "AF"; "AG"; "AI"; "AL"; "AM"; "AO"; "AQ"; "AR"; "AS"; "AT"; "AU"; "AW"; "AX"; "AZ"; "BA"; "BB"; "BD"; "BE"; "BF"; "BG"; "BH"; "BI"; "BJ"; "BL"; "BM"; "BN"; "BO"; "BQ"; "BR"; "BS"; "BT"; "BV"; "BW"; "BY"; "BZ"; "CA"; "CC"; "CD"; "CF"; "CG"; "CH"; "CI"; "CK"; "CL"; "CM"; "CN"; "CO"; "CR"; "CU"; "CV"; "CW"; "CX"; "CY"; "CZ"; "DE"; "DJ"; "DK"; "DM"; "DO"; "DZ"; "EC"; "EE"; "EG"; "EH"; "ER"; "ES"; "ET"; "FI"; "FJ"; "FK"; "FM"; "FO"; "FR"; "GA"; "GB"; "GD"; "GE"; "GF"; "GG"; "GH"; "GI"; "GL"; "GM"; "GN"; "GP"; "GQ"; "GR"; "GS"; "GT"; "GU"; "GW"; "GY"; "HK"; "HM"; "HN"; "HR"; "HT"; "HU"; "ID"; "IE"; "IL"; "IM"; "IN"; "IO"; "IQ"; "IR"; "IS"; "IT"; "JE"; "JM"; "JO"; "JP"; "KE"; "KG"; "KH"; "KI"; "KM"; "KN"; "KP"; "KR"; "KW"; "KY"; "KZ"; "LA"; "LB"; "LC"; "LI"; "LK"; "LR"; "LS"; "LT"; "LU"; "LV"; "LY"; "MA"; "MC"; "MD"; "ME"; "MF"; "MG"; "MH"; "MK"; "ML"; "MM"; "MN"; "MO"; "MP"; "MQ"; "MR"; "MS"; "MT"; "MU"; "MV"; "MW"; "MX"; "MY"; "MZ"; "NA"; "NC"; "NE"; "NF"; "NG"; "NI"; "NL"; "NO"; "NP"; "NR"; "NU"; "NZ"; "OM"; "PA"; "PE"; "PF"; "PG"; "PH"; "PK"; "PL"; "PM"; "PN"; "PR"; "PS"; "PT"; "PW"; "PY"; "QA"; "RE"; "RO"; "RS"; "RU"; "RW"; "SA"; "SB"; "SC"; "SD"; "SE"; "SG"; "SH"; "SI"; "SJ"; "SK"; "SL"; "SM"; "SN"; "SO"; "SR"; "SS"; "ST"; "SV"; "SX"; "SY"; "SZ"; "TC"; "TD"; "TF"; "TG"; "TH"; "TJ"; "TK"; "TL"; "TM"; "TN"; "TO"; "TR"; "TT"; "TV"; "TW"; "TZ"; "UA"; "UG"; "UM"; "US"; "UY"; "UZ"; "VA"; "VC"; "VE"; "VG"; "VI"; "VN"; "VU"; "WF"; "WS"; "YE"; "YT"; "ZA"; "ZM"; "ZW" ]
       return Fix44.Fields.Country ss
    }


type ArbOverrides() =
    static member Char()            = Arb.fromGen genChar
    static member String()          = Arb.fromGen genAlphaString
    static member UTCTimeOnly()     = Arb.fromGen genUTCTimeOnly
    static member UTCDate()         = Arb.fromGen genUTCDate
    static member UTCTimestamp()    = Arb.fromGen genUTCTimestamp
    static member TZTimeonly()      = Arb.fromGen genTZTimeOnly
    static member MonthYear()       = Arb.fromGen genMonthYear
    static member Decimal15dp       = Arb.fromGenShrink (genDecimal15dp, Arb.shrink)
    static member LocalMktDate()    = Arb.fromGen genLocalMktDate
    static member Currency()        = Arb.fromGen genCurrency
    static member Country()         = Arb.fromGen genCountry
    

type FsFixPropertyTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 10,
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
    let tmpBuf = Array.zeroCreate<byte> bufSize // todo: think of better names
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
    let tmpBuf2 = Array.zeroCreate<byte> bufSize
    let posR, msgOut = MsgReadWrite.ReadMessage buf tmpBuf2
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
    let posSep = FIXBufUtils.findNextTagValSep bs 0
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



