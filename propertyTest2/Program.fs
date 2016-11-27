open FsCheck


open Fix44.FieldDU

open Fix44.FieldDU
//open Fix44.FieldReadFuncs
open Fix44.CompoundItems
open Fix44.CompoundItemWriteFuncs
open Fix44.CompoundItemDU



let genAlphaChar = Gen.choose(32,255) |> Gen.map char 
//let genAlphaChar = Gen.choose(65,90) |> Gen.map char 
//let genAlphaCharArray = Gen.arrayOfLength 16 genAlphaChar 
let genAlphaString = 
        gen{
            let! len = Gen.choose(4, 64)
            let! chars = Gen.arrayOfLength len genAlphaChar
            return System.String chars
        }


type ArbOverrides() =
    static member String() = Arb.fromGen genAlphaString
//        Arb.Default.String()
//        |> Arb.filter (fun ss -> not (isNull ss) && ss.Length > 0 && StringIsAlpha(ss) )




Arb.register<ArbOverrides>() |> ignore

let propReadWriteFIXFieldRoundtrip (fieldIn:FIXField) =
    let bs = Array.zeroCreate<byte> 2048
    WriteField bs 0 fieldIn |> ignore
    let _, fieldOut = ReadField 0 bs
    fieldIn = fieldOut


let bufSize = 1024 * 64


let mutable ctr:int = 0

let propReadWriteCompoundItem (ciIn:FIXGroup) =
    ctr <- ctr + 1
    if ctr % 10 = 0 then
        printfn "test count: %d" ctr

    let bs = Array.zeroCreate<byte> bufSize
    let posW = WriteCITest  bs 0 ciIn
    let posR, ciOut =  ReadCITest ciIn 0 bs
    posW = posR && ciIn = ciOut





let config = {  Config.Quick with 
//                    EveryShrink = (sprintf "%A" )
//                    Replay = Some (Random.StdGen (310046944,296129814))
//                    StartSize = 64
                    EndSize = 8

//                    MaxFail = 10000
                    MaxTest = 1000 }



#nowarn "52"
let WaitForExitCmd () = 
    while stdin.Read() <> 88 do // 88 is 'X'
        ()

Check.One (config, propReadWriteCompoundItem)
//Check.One (Config.Quick, propReadWriteFIXFieldRoundtrip)


//WaitForExitCmd ()