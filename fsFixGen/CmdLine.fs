module CmdLine



// FSharpx.extras does not work with .net 4.6.1 at the time of writing, hence
type ChoiceBuilder() =
    member this.Return a = Choice1Of2 a
    member this.Bind (cx, f) =  match cx with
                                | Choice1Of2 x -> f x
                                | Choice2Of2 x -> Choice2Of2 x
let choose = ChoiceBuilder()        

let Exists pth ff msg = 
    if ff pth then
        Choice1Of2 ""
    else
        Choice2Of2 (sprintf msg pth)

let inputFileExists pth = Exists pth System.IO.File.Exists "FIX xml input file does not exist: %s" 
let outputDirExists pth = Exists pth System.IO.Directory.Exists "output directory path does not exist or is not a directory: %s"


let SafeAccess (arr:'t array) index errMsg = 
    if index < arr.Length then
        Choice1Of2 arr.[index] 
    else
        Choice2Of2 errMsg

let ParseCmdLine (args:string array) = 
        choose {    let! fixXml     = SafeAccess args 0 "both parameters missing"
                    let! outputDir  = SafeAccess args 1 "2nd parameter missing: \"generated code output directory path\""
                    let! _          = inputFileExists fixXml
                    let! _          = outputDirExists outputDir
                    return fixXml, outputDir }