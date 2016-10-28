module ByteArrayUtils

open System

let findNext (bb:byte) (pos:int) (bs:byte[]) =
    let mutable found = false
    let mutable ctr = pos
    while (ctr < bs.Length && (not found)) do
        if bs.[ctr] = bb then
            found <- true
        else
            ctr <- ctr + 1
    if found then ctr else -1

let findNextFieldTerm (pos:int) (bs:byte[]) = findNext 1uy pos bs

let findNextTagValSep (pos:int) (bs:byte[]) = findNext 61uy pos bs

/// assumes and checks that the prev byte pointed to by pos is a tag=value separator (i.e. an '=)
/// returns the index of first char after the field value and the value itself
let readValAfterTagValSep (pos:int) (bs:byte[]) =
    // byte value of '=' is 61
    if bs.[pos-1] <> 61uy then failwith "readValAfterFieldSep, prev byte is not a tag value separator"
    let fldTermPos = findNextFieldTerm pos bs
    if fldTermPos = -1 then failwith "could not find next field separator"
    let valLen = fldTermPos - pos
    let bsVal = Array.zeroCreate<byte> valLen
    Buffer.BlockCopy (bs, pos, bsVal, 0, valLen)
    fldTermPos, bsVal

/// assumes and checks that the prev byte pointed to by pos is a tag=value separator (i.e. an '=)
/// returns the index of first char after the field value and the value itself
let readNBytesVal (pos:int) (count:int) (bs:byte[]) =
    // byte value of '=' is 61, of field delim is 1
    if bs.[pos-1] <> 61uy then failwith "readNBytesVal, prev byte is not a tag value separator"
    if bs.[pos+count] <> 1uy then failwith "readNBytesVal, next byte is not a field delimator"
    let bsVal = Array.zeroCreate<byte> count
    Buffer.BlockCopy (bs, pos, bsVal, 0, count)
    pos+count, bsVal


// assumes and checks that the prevByte points to a field delimitor
let readTagAfterFieldDelim (pos:int) (bs:byte[]) =
    if bs.[pos-1] <> 1uy then failwith "readTagAfterFieldDelim, prev byte is not a field delimitor"
    let tagValSepPos = findNextTagValSep pos bs
    if tagValSepPos = -1 then failwith "could not find next tag-valus separator"
    let tagLen = tagValSepPos - pos
    let bsVal = Array.zeroCreate<byte> tagLen
    Buffer.BlockCopy (bs, pos, bsVal, 0, tagLen)
    tagValSepPos, bsVal


// may be the first thing to be read from a byte array, so there will be no initial or prev field deliminator
let readTag (pos:int) (bs:byte[]) =
    let tagValSepPos = findNextTagValSep pos bs
    if tagValSepPos = -1 then failwith "readTag, could not find next tag-valus separator"
    let tagLen = tagValSepPos - pos
    let bsVal = Array.zeroCreate<byte> tagLen
    Buffer.BlockCopy (bs, pos, bsVal, 0, tagLen)
    tagValSepPos, bsVal