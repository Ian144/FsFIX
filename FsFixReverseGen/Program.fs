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
 
open System

open System.Text.RegularExpressions

open ParseData
open Messages    
open GroupsAndComponents







// passing an accumulator param for tco
let rec ChunkByInner acc chunkPred xs =
    match xs with
    | []        ->  acc |> List.rev
    | hd::tl    ->  let chunked = tl |> List.takeWhile chunkPred
                    let remaining = xs |> List.skip (chunked.Length + 1) // +1 because hd is included in the chunked items
                    let acc2 = (hd::chunked) :: acc
                    (ChunkByInner acc2 chunkPred remaining)
let ChunkBy = ChunkByInner []



let printMsg (msgNameTagMap:Map<string,string>) (grpMap:Map<string,Member list>) (msg:Message) : unit = 
    let tag = msgNameTagMap.[msg.MName]
    printfn "         <message name=\"%s\" msgtype=\"%s\" msgcat=\"%s\">" msg.MName tag msg.Cat
    msg.Members |> List.iter (printMember "    " grpMap)
    printfn "        </message>"



let extractMsgNameAndTag (xs:string array) =
    match xs with
    | [|rawTag; rawMsgName|] ->
        let tag = rawTag.Replace("// tag: ", "")
        let mtch = Regex.Match(rawMsgName, "xx:[A-z]+", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        if mtch.Success then
            let msgName = mtch.Value.Replace("xx:","")
            msgName, tag
        else
            failwithf "could not extract msg name from: %s" rawMsgName
    | _ -> failwithf "extractMsgNameAndTag input list should be of length 2"






[<EntryPoint>]
let main argv = 
    
    //let baseDir = """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix"""

    let cmdLine = CmdLine.ParseCmdLine argv
    match cmdLine with
    | Choice1Of2 baseDir -> 

        let fsCmpItmsPath =  baseDir +  """\Fix44.CompoundItems.fs"""
    
        let compoundItemData = ParseFsTypes fsCmpItmsPath |> List.filter isInteresting  |> ChunkBy isSameGrpCmp
        let groups, components = compoundItemData |> List.partition componentGroupPartitionPred
        let groupMap = groups |> List.map convCmpGrpChunk |> List.map (fun grp -> grp.CGName, grp.Members) |> Map.ofList

        printfn "<fix major=\"4\" minor=\"4\">"

        let fsMsgWritersPath = baseDir + """\Fix44.MsgWriters.fs""" // used to get msg tags
        let fsTags = IO.File.ReadLines fsMsgWritersPath |> Seq.filter (fun ss -> ss.Contains("tag:") || ss.Contains("xx:")) |> Seq.chunkBySize 2 |> Seq.map extractMsgNameAndTag
        let msgNameTagMap = fsTags |> Map.ofSeq

        let fsMsgPath = baseDir + """\Fix44.Messages.fs"""
        let msgData = ParseFsTypes fsMsgPath
        let msgs = msgData |> List.filter isInteresting |> ChunkBy isSameMsg |> List.map convMsgChunk
        printfn "    <messages>"
        msgs |> List.iter (printMsg msgNameTagMap groupMap)
        printfn "    </messages>"

        let componentsSorted = components |> List.map convCmpGrpChunk |> List.sortBy (fun cmp -> componentOrderMap.[cmp.CGName])
        printfn "    <components>"
        componentsSorted |> List.iter (printComponent groupMap)
        printfn "    </components>"

        printfn "</fix>"

    | Choice2Of2 errMsg -> // error in cmdline
        printf "%s" errMsg
        printfn "FsFixReverseGen.exe <pathToFsFIXSource>"
    0 // return an integer exit code




