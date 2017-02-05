open FsCheck


open System

open Fix44.Fields
open Fix44.MessageDU

open Swensen.Unquote


Arb.register<Generators.ArbOverrides>() |> ignore

//let propReadWriteFIXFieldRoundtrip (fieldIn:FIXField) =
//    let bs = Array.zeroCreate<byte> 2048
//    WriteField bs 0 fieldIn |> ignore
//    let _, fieldOut = ReadField bs 0
//    fieldIn = fieldOut


let bufSize = 1024 * 64


//let mutable ctr:int = 0
//
//let propReadWriteCompoundItem (ciIn:FIXGroup) =
//    ctr <- ctr + 1
//    if ctr % 10 = 0 then
//        printfn "test count: %d" ctr
//
//    let bs = Array.zeroCreate<byte> bufSize
//    let posW = WriteCITest  bs 0 ciIn
//    let posR, ciOut =  ReadCITest ciIn bs 0
//    posW = posR && ciIn = ciOut


let fixBuf = Array.zeroCreate<byte> bufSize
let tmpBuf = Array.zeroCreate<byte> bufSize

let propReconstructFIXMessageBufFromIndex
        (beginString:BeginString) 
        (senderCompID:SenderCompID) 
        (targetCompID:TargetCompID) 
        (msgSeqNum:MsgSeqNum) 
        (sendingTime:SendingTime) 
        (msg:FIXMessage) =
    Array.Clear(fixBuf, 0, fixBuf.Length)
    let posW = MsgReadWrite.WriteMessageDU 
                                tmpBuf 
                                fixBuf 
                                0 
                                beginString 
                                senderCompID
                                targetCompID
                                msgSeqNum
                                sendingTime
                                msg
    let index = Array.zeroCreate<FIXBufIndexer.FieldPos> bufSize
    let indexEnd = FIXBufIndexer.BuildIndex index fixBuf posW
    let reconstructedFIXBuf = FIXBufIndexer.reconstructFromIndex fixBuf index indexEnd
    // trim fixBuf
    let fixBuf2 = Array.zeroCreate<byte> posW
    Array.Copy(fixBuf, fixBuf2, posW)
    fixBuf2 =! reconstructedFIXBuf


let buf = Array.zeroCreate<byte> bufSize
let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 8)



let isAllocationInstruction (msgIn:FIXMessage) = 
    match msgIn with
    | FIXMessage.AllocationInstruction xx   -> true
    | _                                     -> false

let mutable ctr = 0


let propMessageWriteRead (msgIn:FIXMessage) =
//    if msgIn |> isAllocationInstruction |> not then
        ctr <- ctr + 1
        if (ctr % 100) = 0 then
            printfn "%d" ctr
        Array.Clear(buf, 0, fixBuf.Length)
        Array.Clear(fieldPosArr, 0, fieldPosArr.Length)
        let posW = Fix44.MessageDU.WriteMessage buf 0 msgIn
        let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr buf posW
        let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)
        let msgOut = Fix44.MessageDU.ReadMessage msgIn buf index

        if msgIn <> msgOut then
            use swA = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\msgIn.fs""")
            use swB = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\msgOut.fs""")
            fprintfn swA "%A" msgIn
            fprintfn swB "%A" msgOut

        let ok = msgIn = msgOut
        ok
//    else
//        true

let propAllocationInstructionWriteRead (allocInstr:Fix44.Messages.AllocationInstruction) =
        let msgIn = allocInstr |> FIXMessage.AllocationInstruction
        ctr <- ctr + 1
        if (ctr % 10) = 0 then
            printfn "%d" ctr

        Array.Clear(buf, 0, fixBuf.Length)
        Array.Clear(fieldPosArr, 0, fieldPosArr.Length)
        let posW = Fix44.MessageDU.WriteMessage buf 0 msgIn
        let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr buf posW
        let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)
        let msgOut = Fix44.MessageDU.ReadMessage msgIn buf index

        if msgIn <> msgOut then
            use swA = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\msgIn.fs""")
            use swB = new System.IO.StreamWriter("""C:\Users\Ian\Desktop\msgOut.fs""")
            fprintfn swA "%A" msgIn
            fprintfn swB "%A" msgOut


//        printfn "beg ok"
        let ok = msgIn = msgOut
//        printfn "end ok: %A" (msgIn.GetType())
        ok



let config = {  Config.Quick with 
//                    EveryShrink = (sprintf "%A" )
//                    Replay = Some (Random.StdGen (310046944,296129814))
//                    StartSize = 64
                    EndSize = 1

//                    MaxFail = 10000
                    MaxTest = 10000000 }



#nowarn "52"
let WaitForExitCmd () = 
    while stdin.Read() <> 88 do // 88 is 'X'
        ()

//Check.One (config, propReconstructFIXMessageBufFromIndex)
Check.One (config, propAllocationInstructionWriteRead)
//Check.One (Config.Quick, propReadWriteFIXFieldRoundtrip)


WaitForExitCmd ()