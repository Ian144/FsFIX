open FsCheck


open Fix44.FieldDU




let genAlphaChar = Gen.choose(0,256) |> Gen.map char 
let genAlphaCharArray = Gen.arrayOfLength 8 genAlphaChar 
let genAlphaString = 
        gen{
            let! chars = genAlphaCharArray
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


let config = {  Config.Quick with 
                    EveryShrink = (sprintf "%A" )
//                    Replay = Some (Random.StdGen (310046944,296129814))
//                    StartSize = 512
//                    MaxFail = 10000
                    MaxTest = 10000 }



#nowarn "52"
let WaitForExitCmd () = 
    while stdin.Read() <> 88 do // 88 is 'X'
        ()


Check.One (config, propReadWriteFIXFieldRoundtrip)


