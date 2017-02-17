open System



//let (|TypeName|Member|Uninteresting|) (ss:string) =
//    if ss.Contains("Type") then
//        TypeName
//    else if ss.Contains(":") then
//        Member
//    else
//        Uninteresting


let getTypeName2 (ss:string) = ss.Replace("type ", "").Replace(" = {", "")
    
type ParseData = 
        | TypeName of string
        | Member of string * string
        | Category of string
        | Uninteresting

let getCategory pd = 
    match pd with
    | Category catStr   -> catStr
    | _                 -> failwith "non cat pd"

let getTypeName pd = 
    match pd with
    | TypeName tn   -> tn
    | _             -> failwith "non typename pd"

let getMember pd = 
    match pd with
    | Member (s1, s2)   -> s1, s2
    | _                 -> failwith "non typename pd"




let isInteresting (pd:ParseData) = 
    match pd with
    | TypeName _        -> true
    | Member _          -> true
    | Category _        -> true 
    | Uninteresting _   -> false



let isNewMsg (pd:ParseData) =
    match pd with
    | TypeName _        -> false
    | Member _          -> false
    | Category _        -> true
    | Uninteresting _   -> false




let isSameMsg = isNewMsg >> not


let ParseFsTypes (sourcePath:string) = 
    let fsTypeData = System.IO.File.ReadLines sourcePath |> Seq.toList
    let pds = fsTypeData |> List.map (fun ss -> 
            if ss.Contains("type ") then
                let tn = getTypeName2 ss
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
    match pds with
    | []        ->  []
    | hd::tl    ->  let curMsgPds = tl |> List.takeWhile isSameMsg
                    let remainingPds = pds |> List.skip (curMsgPds.Length + 1)
                    (hd::curMsgPds) :: (ChunkByMsg remainingPds)


type MessageElement = 
    | Field     of string*string*bool
    | Group     of string*string*bool
    | Component of string*string*bool


type MessageXmlData = {MsgName:string; MsgType:string; Cat:string; MessageElements: MessageElement list }


let getRequiredString (required:bool) =
    match required with
    | true  -> "Y"
    | false -> "N"


let printMsgElement (mEl:MessageElement) =
    let printRaw fieldGrpCmpStr mbrName typName required =
        printfn "      <%s name=\"%s\" required=\"%s\" />" fieldGrpCmpStr typName (getRequiredString required)

    match mEl with
    | Field     (mbrName, typName, required) -> printRaw "field" mbrName typName required
    | Group     (mbrName, typName, required) -> printRaw "group" mbrName typName required
    | Component (mbrName, typName, required) -> printRaw "component" mbrName typName required


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
        {MsgName=msgName; MsgType="99"; Cat=cat; MessageElements=msgElements }
    |   _                       -> failwith "failed to parse msg"



//let printMsgXml (pds:ParseData seq) =
//    


[<EntryPoint>]
let main argv = 

    let fsMsgPath:string = """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\Fix44.Messages.fs"""
    let fsCmpItmsPath:string = """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\Fix44.CompoundItems.fs"""
    let msgData = ParseFsTypes fsMsgPath
    let compoundItemData = ParseFsTypes fsCmpItmsPath |> List.filter isInteresting

    let msgDataChunkedByMsg = msgData |> List.filter isInteresting |> ChunkByMsg |> List.map convMsgChunk
    
    msgDataChunkedByMsg |> List.take 10 |> List.iter printMsg

    0 // return an integer exit code
