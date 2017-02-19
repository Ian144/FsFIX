module ParseData


type ParseData = 
        | TypeName of string
        | Member   of string*string
        | Category of string
        | Uninteresting


let getCategory = function
    | Category catStr   -> catStr
    | _                 -> failwith "non cat pd"

let getTypeName = function
    | TypeName tn   -> tn
    | _             -> failwith "non typename pd"

let getMember = function
    | Member (s1, s2)   -> s1, s2
    | _                 -> failwith "non member pd"

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


let printRaw fieldGrpCmpStr typName required = printfn "      <%s name=\"%s\" required=\"%s\" />" fieldGrpCmpStr typName (getRequiredString required)


type Member = 
    | Field     of string*bool
    | Group     of string*bool
    | Component of string*bool

type MessageXmlData = {MsgName:string; MsgType:string; Cat:string; Members: Member list }


type CmpGrpXmlData = {CGName:string; Members: Member list }



let printMember = function
    | Field     ( typName, required) -> printRaw "field"        typName required
    | Group     ( typName, required) -> printRaw "group"        typName required
    | Component ( typName, required) -> printRaw "component"    typName required