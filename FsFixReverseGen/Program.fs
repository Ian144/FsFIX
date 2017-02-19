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



let printMsg (msg:MessageXmlData) : unit = 
    printfn "    <message name=\"%s\" msgtype=\"%s\" msgcat=\"%s\">" msg.MsgName msg.MsgType msg.Cat
    msg.Members |> List.iter printMember
    printfn "    </message>"





[<EntryPoint>]
let main argv = 
    // todo, get base path as an arg, possibly accept a default if not present
    let fsCmpItmsPath:string = """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\Fix44.CompoundItems.fs"""
    let compoundItemData = ParseFsTypes fsCmpItmsPath |> List.filter isInteresting  |> ChunkBy isSameGrpCmp
    let groups, components = compoundItemData |> List.partition componentGroupPartitionPred


    let componentsSorted = components |> List.map convCmpGrpChunk |> List.sortBy (fun cmp -> componentOrderMap.[cmp.CGName])
    printfn "<components>"
    componentsSorted |> List.iter printComponent
    printfn "</components>"

    // groups are declared inline in FIX44.xml, so they need to be applied to 



//    let fsMsgPath:string = """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\Fix44.Messages.fs"""
//    let msgData = ParseFsTypes fsMsgPath
//    let msgDataChunkedByMsg = msgData |> List.filter isInteresting |> ChunkBy isSameMsg |> List.map convMsgChunk
//    printfn "<messages>"
//    msgDataChunkedByMsg |> List.iter printMsg
//    printfn "</messages>"

    0 // return an integer exit code




