module WriteReadRoundtrip

open System.Reflection

open Xunit
open FsCheck
open FsCheck.Xunit
open Swensen.Unquote


open Fix44.Fields
open Fix44.FieldWriteFuncs
open Fix44.FieldReadFuncs

open Fix44.FieldDU

open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs
open Fix44.CompoundItemDU
open Fix44.MessageDU

open DateTimeGenerators



let bufSize = 1024 * 82 // so as not to go into the LOH


// strings stored in FIX do not contain field terminators, 
//let genAlphaChar = Gen.choose(32,255) |> Gen.map char 
let genAlphaChar = Gen.choose(65,90) |> Gen.map char 
//let genAlphaCharArray = Gen.arrayOfLength 16 genAlphaChar 
let genAlphaString = 
        gen{
            let! len = Gen.choose(4, 4)
            let! chars = Gen.arrayOfLength len genAlphaChar
            return System.String chars
        }



type ArbOverrides() =
    static member String()          = Arb.fromGen genAlphaString
    static member UTCTimeOnly()     = Arb.fromGen genUTCTimeOnly
    static member UTCDate()         = Arb.fromGen genUTCDate
    static member UTCTimestamp()    = Arb.fromGen genUTCTimestamp
    static member TZTimeonly()      = Arb.fromGen genTZTimeOnly


type FsFixPropertyTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 1000,
        EndSize = 8,
        Verbose = false
//        QuietOnSuccess = true
        )



let genWriteReadTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:byte[]->int->int*'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let posR, tOut = readFunc bs 0
    posW =! posR
    tIn =! tOut

[<FsFixPropertyTest>]
let dtTZTimeOnly (tm:TZDateTime.TZTimeOnly) =  genWriteReadTest tm TZDateTime.writeTZTimeOnly TZDateTime.readTZTimeOnly



// a simple msg
[<FsFixPropertyTest>]
let msgUserRequest (msg:Fix44.Messages.UserRequest) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = Fix44.MsgWriteFuncs.WriteUserRequest bs 0 msg
    let posR, msgOut = Fix44.MsgReadFuncs.ReadUserRequest 0 bs
    posW =! posR
    msg =! msgOut



// msg containing a 'NoSides' group
[<FsFixPropertyTest>]
let msgNewOrderCross (msg:Fix44.Messages.NewOrderCross) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = Fix44.MsgWriteFuncs.WriteNewOrderCross bs 0 msg
    let posR, msgOut = Fix44.MsgReadFuncs.ReadNewOrderCross 0 bs
    posW =! posR
    msg =! msgOut


[<FsFixPropertyTest>]
let PosMaintRptID (fldIn:Fix44.Fields.PosMaintRptID) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = Fix44.FieldWriteFuncs.WritePosMaintRptID bs 0 fldIn
    let posSep = FIXBufUtils.findNextTagValSep 0 bs
    let posR, fldOut = Fix44.FieldReadFuncs.ReadPosMaintRptID (posSep+1) bs
    posW =! posR
    fldIn =! fldOut  


// MDEntryTime wraps UTCTimeOnly
[<FsFixPropertyTest>]
let MDEntryTime (fldIn:Fix44.Fields.MDEntryTime) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = Fix44.FieldWriteFuncs.WriteMDEntryTime bs 0 fldIn
    let posSep = FIXBufUtils.findNextTagValSep 0 bs
    let posR, fldOut = Fix44.FieldReadFuncs.ReadMDEntryTime (posSep+1) bs
    posW =! posR
    fldIn =! fldOut 



// a very slow test due to the large number of Field DU instances
// will re-enable this test occasionally
//[<FsFixPropertyTest>]
//let AllFields (fieldIn:FIXField) =
//    let bs = Array.zeroCreate<byte> bufSize
//    let posW = WriteField bs 0 fieldIn
//    let posR, fieldOut = ReadField 0 bs
//    posW =! posR
//    fieldIn =! fieldOut  



[<FsFixPropertyTest>]
let NoCapacitiesGrp (grpIn:NoCapacitiesGrp ) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteNoCapacitiesGrp  bs 0 grpIn
    let posR, grpOut = Fix44.CompoundItemReadFuncs.ReadNoCapacitiesGrp 0 bs
    posW =! posR
    grpIn =! grpOut  




[<FsFixPropertyTest>]
let UnderlyingStipulationsGrp (usIn:NoUnderlyingStipsGrp ) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteNoUnderlyingStipsGrp bs 0 usIn
    let posR, usOut = Fix44.CompoundItemReadFuncs.ReadNoUnderlyingStipsGrp 0 bs
    posW =! posR
    usIn =! usOut



[<FsFixPropertyTest>]
let UnderlyingStipulations (usIn:UnderlyingStipulations) =
//    (usIn.NoUnderlyingStipsGrp.IsSome) ==> lazy
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteUnderlyingStipulations  bs 0 usIn
    let posR, usOut = Fix44.CompoundItemReadFuncs.ReadUnderlyingStipulations 0 bs
    usIn =! usOut
    posW =! posR
        


//let rec compareInner (indent:string) (objA:System.Object) (objB:System.Object) =
//    let bindingFlags = 
//        BindingFlags.Public     ||| 
//        BindingFlags.NonPublic  |||
//        BindingFlags.Instance   ||| 
//        BindingFlags.Static     |||
//        BindingFlags.DeclaredOnly
//
//    let ty = objA.GetType()
//    let fields = ty.GetFields(bindingFlags)
//
//    let compStrs = 
//        fields |> Array.map (fun fi ->
//            let vA = fi.GetValue objA
//            let vB = fi.GetValue objB
//            if vA <> vB then
//                let ft = fi.FieldType
//                let fieldsInner = ft.GetFields(bindingFlags)
//                if fieldsInner.Length > 1 then
//                    let indent2 = sprintf "    %s" indent
//                    compareInner indent2 vA vB
//                else
//                    sprintf "%s >>>>>>>> %s: %O <> %O" indent fi.Name vA vB
//            else
//               sprintf "%s: %O <> %O" fi.Name vA vB
//            )
// 
//    System.String.Join("\n", compStrs)
//
//
//let compare (objA:System.Object) (objB:System.Object) = 
//    let ss = compareInner "" objA objB
//    printf "%s" ss




[<FsFixPropertyTest>]
let UnderlyingInstument (usIn:UnderlyingInstrument) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteUnderlyingInstrument  bs 0 usIn
    let posR, usOut = Fix44.CompoundItemReadFuncs.ReadUnderlyingInstrument 0 bs
    posW =! posR
    usIn =! usOut         



[<FsFixPropertyTest>]
let NoSidesGrp (gIn:NoSidesGrp ) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteNoSidesGrp bs 0 gIn
    let posR, gOut = Fix44.CompoundItemReadFuncs.ReadNoSidesGrp 0 bs
    posW =! posR
    gIn =! gOut



[<FsFixPropertyTest>]
let CompoundItem (ciIn:FIXGroup) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteCITest  bs 0 ciIn
    let posR, ciOut =  ReadCITest ciIn 0 bs
    posW =! posR
    ciIn =! ciOut



[<FsFixPropertyTest>]
let Message (msg:FIXMessage) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteMessage bs 0 msg
    let posR, msgOut = ReadMessage msg 0 bs
    posW =! posR
    msg =! msgOut



[<FsFixPropertyTest>]
let InstrumentLegFG (usIn:InstrumentLegFG) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteInstrumentLegFG  bs 0 usIn
    let posR, usOut = Fix44.CompoundItemReadFuncs.ReadInstrumentLegFG 0 bs
    posW =! posR
    usIn =! usOut



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
    let posW = WriterUtils.WriteMessageDU 
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
    let posR, msgOut = WriterUtils.ReadMessage buf tmpBuf2
    msg =! msgOut