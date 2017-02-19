open System


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



let printMsg (grpMap:Map<string,Member list>) (msg:Message) : unit = 
    printfn "         <message name=\"%s\" msgtype=\"%s\" msgcat=\"%s\">" msg.MName msg.MType msg.Cat
    msg.Members |> List.iter (printMember "    " grpMap)
    printfn "        </message>"





[<EntryPoint>]
let main argv = 
    // todo, get F# source base path as an arg, possibly accept a default if not present
    let fsCmpItmsPath:string = """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\Fix44.CompoundItems.fs"""
    let compoundItemData = ParseFsTypes fsCmpItmsPath |> List.filter isInteresting  |> ChunkBy isSameGrpCmp
    let groups, components = compoundItemData |> List.partition componentGroupPartitionPred
    let groupMap = groups |> List.map convCmpGrpChunk |> List.map (fun grp -> grp.CGName, grp.Members) |> Map.ofList

    printfn "<fix major=\"4\" minor=\"4\">"

    let fsMsgPath:string = """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\Fix44.Messages.fs"""
    let msgData = ParseFsTypes fsMsgPath
    let msgDataChunkedByMsg = msgData |> List.filter isInteresting |> ChunkBy isSameMsg |> List.map convMsgChunk
    printfn "    <messages>"
    msgDataChunkedByMsg |> List.iter (printMsg groupMap)
    printfn "    </messages>"

    let componentsSorted = components |> List.map convCmpGrpChunk |> List.sortBy (fun cmp -> componentOrderMap.[cmp.CGName])
    printfn "    <components>"
    componentsSorted |> List.iter (printComponent groupMap)
    printfn "    </components>"

    // groups are declared inline in FIX44.xml, so they need to be inline when Messages and Components are printed






    printfn "</fix>"

    0 // return an integer exit code




