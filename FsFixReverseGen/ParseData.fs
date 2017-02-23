(*
 * Copyright (C) 2016-2017 Ian Spratt <ian144@hotmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301, USA.
 *
 *)
 
 
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


type Member = 
    | Field     of string*bool
    | Group     of string*bool
    | Component of string*bool


let expandLenDataField (name, required) =
    let mapLenFieldSuffixes = Map.empty.
                                Add("EncodedIssuer", "Len").
                                Add("EncodedLegIssuer", "Len").
                                Add("EncodedLegSecurityDesc", "Len").
                                Add("EncodedSecurityDesc", "Len").
                                Add("EncodedText", "Len").
                                Add("EncodedSubject", "Len").
                                Add("RawData", "Length").
                                Add("EncodedUnderlyingIssuer", "Len").
                                Add("EncodedUnderlyingSecurityDesc", "Len").
                                Add("EncodedHeadline", "Len").
                                Add("EncodedAllocText", "Len" ).
                                Add("EncodedListStatusText", "Len" ).
                                Add("EncodedListExecInst", "Len" )

    if mapLenFieldSuffixes.ContainsKey name then
        let lenFieldName  =  name + mapLenFieldSuffixes.[name]
        [(lenFieldName, required); (name, required)]
    else
        [(name, required)]



type Message = {MName:string; MType:string; Cat:string; Members: Member list }

type CmpGrp = {CGName:string; Members: Member list }


let printRaw indent fieldGrpCmpStr typName required = printfn "      %s<%s name=\"%s\" required=\"%s\" />"  indent fieldGrpCmpStr typName (getRequiredString required)

let rec printGroup (indent:string) (grpMap:Map<string,Member list>) groupName required = 
    let yOrN = (getRequiredString required)
    let groupMembers = grpMap.[groupName]
    let groupName2 = groupName.Replace("Grp", "")
    let indent2 = indent + "    "
    printfn "      %s<group name=\"%s\" required=\"%s\" >" indent groupName2 yOrN
    groupMembers |> List.iter (printMember indent2 grpMap )
    printfn "      %s</group>" indent
and printMember (indent:string) (grpMap:Map<string,Member list>) mbr = 
    match mbr with
    | Field     ( name, required) -> let fields = expandLenDataField (name, required)
                                     fields |> List.iter (fun (typName, required) -> printRaw indent "field" typName required)
    | Group     ( name, required) -> printGroup indent grpMap name required
    | Component ( name, required) -> printRaw   indent "component" name required


