open System



    
type ParseData = 
        | TypeName of string
        | Member of string * string
        | Category of string
        | Uninteresting


type MessageElement = 
    | Field     of string*string*bool
    | Group     of string*string*bool
    | Component of string*string*bool

type MessageXmlData = {MsgName:string; MsgType:string; Cat:string; MessageElements: MessageElement list }


let getCategory = function
    | Category catStr   -> catStr
    | _                 -> failwith "non cat pd"

let getTypeName = function
    | TypeName tn   -> tn
    | _             -> failwith "non typename pd"

let getMember = function
    | Member (s1, s2)   -> s1, s2
    | _                 -> failwith "non typename pd"

let isInteresting = function
    | Uninteresting _   -> false
    | _                 -> true

let getRequiredString = function
    | true  -> "Y"
    | false -> "N"


let typeNameFromFsStr (ss:string) = ss.Replace("type ", "").Replace(" = {", "")


let ParseFsTypes (sourcePath:string) = 
    let fsTypeData = System.IO.File.ReadLines sourcePath |> Seq.toList
    let pds = fsTypeData |> List.map (fun ss -> 
            if ss.Contains("type ") then
                let tn = typeNameFromFsStr ss
                ParseData.TypeName tn
            else if ss.Contains(":") then
                let xx = ss.Split(':')
                let memName = xx.[0].Trim()
                let memType = xx.[1].Trim()
                ParseData.Member (memName, memType)
            else if ss.Contains("admin") || ss.Contains("app") then
                let cat = ss.Substring(2)
                Category cat
            else
                Uninteresting )
    pds


let rec ChunkByMsg (pds:ParseData list) : ParseData list list =
    let isSameMsg = function | Category _  -> false | _-> true
    match pds with
    | []        ->  []
    | hd::tl    ->  let curMsgPds = tl |> List.takeWhile isSameMsg
                    let remainingPds = pds |> List.skip (curMsgPds.Length + 1)
                    (hd::curMsgPds) :: (ChunkByMsg remainingPds)

let rec ChunkByGroupOrComponent (pds:ParseData list) : ParseData list list =
    let isSameType = function | TypeName _  -> false | _-> true
    match pds with
    | []        ->  []
    | hd::tl    ->  let curMsgPds = tl |> List.takeWhile isSameType
                    let remainingPds = pds |> List.skip (curMsgPds.Length + 1)
                    (hd::curMsgPds) :: (ChunkByGroupOrComponent remainingPds)


let printRaw fieldGrpCmpStr typName required = printfn "      <%s name=\"%s\" required=\"%s\" />" fieldGrpCmpStr typName (getRequiredString required)


let printMsgElement = function
    | Field     (_, typName, required) -> printRaw "field"        typName required
    | Group     (_, typName, required) -> printRaw "group"        typName required
    | Component (_, typName, required) -> printRaw "component"    typName required


let printMsg (msg:MessageXmlData) : unit = 
    printfn "    <message name=\"%s\" msgtype=\"%s\" msgcat=\"%s\">" msg.MsgName msg.MsgType msg.Cat
    msg.MessageElements |> List.iter printMsgElement
    printfn "    </message>"


let convMsgChunk (msgPds:ParseData list) =
    match msgPds with
    |   catPd::msgNamePd::memberPds   -> 
        let cat = getCategory catPd
        let msgName = getTypeName msgNamePd
        let msgElements = memberPds |> List.map (fun msgPd ->
            let name, xx = getMember msgPd
            let isRequired = xx.Contains("option") |> not
            let subStrs = (xx.Split ' ')
            let typeName = subStrs.[0].Trim()
            if xx.Contains("// group") then
                MessageElement.Group (name, typeName, isRequired)
            else if xx.Contains "// component" then
                MessageElement.Component (name, typeName, isRequired)
            else
                MessageElement.Field (name, typeName, isRequired)
        )
        { MsgName=msgName; MsgType="99"; Cat=cat; MessageElements=msgElements }
    |   _   -> failwith "failed to parse msg"
  


[<EntryPoint>]
let main argv = 
    // todo, get base path as an arg, possibly accept a default if not present
    let fsMsgPath:string = """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\Fix44.Messages.fs"""
    let fsCmpItmsPath:string = """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\Fix44.CompoundItems.fs"""
    let msgData = ParseFsTypes fsMsgPath
    let compoundItemData = ParseFsTypes fsCmpItmsPath |> List.filter isInteresting |> List.take 100 |> ChunkByGroupOrComponent

    // chunk by compound item
    // separate components from groups
    // sort components into order in FIX44.xml
    // 


//    let msgDataChunkedByMsg = msgData |> List.filter isInteresting |> ChunkByMsg |> List.map convMsgChunk
//    printfn "<messages>"
//    msgDataChunkedByMsg |> List.iter printMsg
//    printfn "</messages>"

    0 // return an integer exit code








