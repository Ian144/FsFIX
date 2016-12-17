module ReaderUtils




let ReadField (bs:byte[]) (pos:int) (ss:string) (expectedTag:byte[]) readFunc = 
    let pos2, tag = FIXBufUtils.readTag bs pos
    if tag <> expectedTag then 
        let msg = sprintf "when reading %s: expected tag: %A, actual: %A" ss expectedTag tag
        failwith msg
    let pos3, fld = readFunc bs pos2
    pos3, fld


let ReadOptionalField (bs:byte[]) (pos:int) (expectedTag:byte[]) readFunc : int * 'b option = 
    match FIXBufUtils.readTagOpt bs pos with
    | Some (pos2, tag)  ->     
        if tag = expectedTag then 
            let pos3, fld = readFunc bs pos2
            pos3, Some fld
        else
            pos, None   // return the original pos, the next read op will re-read it
    | None -> pos, None   // return the original pos, the next read op will re-read it



let rec readGrpInner (acc: 'grp list) (pos:int) (recursionCount:uint32) (bs:byte[]) (readFunc: byte [] -> int -> int * 'grp) =
    match recursionCount with
    | 0u    ->  pos, (acc |> List.rev)
    | _     ->  let pos2, grpInstance = readFunc bs pos 
                readGrpInner (grpInstance::acc) pos2 (recursionCount-1u) bs readFunc


let ReadGroup (ss:string) (pos:int) (numTag:byte[]) (bs:byte[]) readFunc =
    let pos2, tag = FIXBufUtils.readTag bs pos
    if tag <> numTag then
        let msg = sprintf "when reading %s: expected tag: %A, actual: %A" ss numTag tag
        failwith msg
    let pos3, numRepeatBs = FIXBufUtils.readValAfterTagValSep bs pos2
    let numRepeats = Conversions.bytesToUInt32 numRepeatBs
    let pos4, gs = readGrpInner [] pos3 numRepeats bs readFunc
    let gsRev = gs
    pos4, gsRev


let ReadNoSidesGroup (ss:string) (pos:int) (numTag:byte[]) (bs:byte[]) readFunc =
    let pos2, tag = FIXBufUtils.readTag bs pos
    if tag <> numTag then
        let msg = sprintf "ReadNoSidesGroup, when reading %s: expected tag: %A, actual: %A" ss numTag tag
        failwith msg
    let pos3, numRepeatBs = FIXBufUtils.readValAfterTagValSep bs pos2
    match numRepeatBs with
    | "1"B  ->  let pos4, grp = readFunc bs pos3
                pos4, OneOrTwo.One grp
    | "2"B  ->  let pos4, grp1 = readFunc bs pos3
                let pos5, grp2 = readFunc bs pos4 
                pos5, OneOrTwo.Two (grp1, grp2)
    | x     ->  failwith (sprintf "ReadNoSidesGroup invalid num repeats, must be 1 or 2, was: %A"  x)



let ReadOptionalGroup (bs:byte[]) (pos:int) (numFieldTag:byte[]) (readFunc:byte[] -> int -> int * 'grp) : int * 'grp list option =
    match FIXBufUtils.readTagOpt bs pos with
    | Some (pos2, tag)  ->
        if tag = numFieldTag then 
            let pos3, numRepeatBs = FIXBufUtils.readValAfterTagValSep bs pos2
            let numRepeats = Conversions.bytesToUInt32 numRepeatBs
            let pos4, gs = readGrpInner [] pos3 numRepeats bs readFunc
            let gsRev = gs
            pos4, Some gsRev
        else
            pos, None   // return the original pos, the next read op will re-read it
    | None  -> pos, None




let ReadComponent (bs:byte[]) (pos:int) (ss:string) readFunc = 
    let pos3, fld = readFunc bs pos
    pos3, fld


// the first field of an optional component is required, so the component is present if the first field is present
let ReadOptionalComponent (bs:byte[]) (pos:int) (expectedTag:byte[]) readFunc = 
    match FIXBufUtils.readTagOpt bs pos with
    | Some (_, tag)  ->
        if tag = expectedTag then 
            let pos2, cmp = readFunc bs pos // this will read the tag again, will live with this inefficiency until it proves costly, if ever
            pos2, Some cmp
        else
            pos, None   // return the original pos, the next read op will re-read it
    | None -> pos, None

