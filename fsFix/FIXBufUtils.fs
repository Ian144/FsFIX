module FIXBufUtils

open System


let findNextOrEnd (bs:byte[]) (pos:int) (bb:byte) =
    let mutable found = false
    let mutable ctr = pos
    while (ctr < bs.Length && (not found)) do
        if bs.[ctr] = bb then
            found <- true
        else
            ctr <- ctr + 1
    ctr

let findNextFieldTermOrEnd (bs:byte[]) (pos:int) = findNextOrEnd bs pos 1uy

let findNext (bs:byte[]) (pos:int) (bb:byte) =
    let mutable found = false
    let mutable ctr = pos
    while (ctr < bs.Length && (not found)) do
        if bs.[ctr] = bb then
            found <- true
        else
            ctr <- ctr + 1
    if found then ctr else -1

let findNextFieldTerm (bs:byte[]) (pos:int) = findNext bs pos 1uy 
let findNextTagValSep (bs:byte[]) (pos:int) = findNext bs pos 61uy

/// returns the index of first char after the field value and the value itself
/// checks that the prev byte pointed to by pos is a tag=value separator (i.e. an '=)
let readValAfterTagValSep (bs:byte[]) (pos:int) =
    // byte value of '=' is 61
    if bs.[pos-1] <> 61uy then failwith "readValAfterFieldSep, prev byte is not a tag value separator"
    let fldTermPos = findNextFieldTerm bs pos
    if fldTermPos = -1 then failwith "could not find next field separator"
    let valLen = fldTermPos - pos
    let bsVal = Array.zeroCreate<byte> valLen
    Buffer.BlockCopy (bs, pos, bsVal, 0, valLen)
    fldTermPos + 1, bsVal

/// used for reading the data component of length+data paired fields, the data component may contain field deliminators
/// checks that the prev byte pointed to by pos is a tag=value separator (i.e. an '=)
/// returns the index of first char after the field value and the value itself
let readNBytesVal (pos:int) (count:int) (bs:byte[]) =
    // byte value of '=' is 61, of field delim is 1
    if bs.[pos-1] <> 61uy then failwith "readNBytesVal, prev byte is not a tag value separator"
    if bs.[pos+count] <> 1uy then failwith "readNBytesVal, next byte is not a field delimator"
    let bsVal = Array.zeroCreate<byte> count
    Buffer.BlockCopy (bs, pos, bsVal, 0, count)
    pos+count+1, bsVal


// checks that the prevByte points to a field delimitor
let readTagAfterFieldDelim (bs:byte[]) (pos:int) =
    if bs.[pos-1] <> 1uy then failwith "readTagAfterFieldDelim, prev byte is not a field delimitor"
    let tagValSepPos = findNextTagValSep bs pos
    if tagValSepPos = -1 then failwith "could not find next tag-value separator"
    let tagLen = tagValSepPos - pos
    let bsVal = Array.zeroCreate<byte> tagLen
    Buffer.BlockCopy (bs, pos, bsVal, 0, tagLen)
    tagValSepPos + 1, bsVal


// may be the first thing to be read from a byte array, so there will be no initial or prev field deliminator
let readTag (bs:byte[]) (pos:int) =
    let tagValSepPos = findNextTagValSep bs pos
    if tagValSepPos = -1 then failwith "readTag, could not find next tag-value separator"
    let tagLen = tagValSepPos - pos
    let bsVal = Array.zeroCreate<byte> tagLen
    Buffer.BlockCopy (bs, pos, bsVal, 0, tagLen)
    tagValSepPos + 1, bsVal // +1 to advance past the tag value seperator


let readTagOpt (bs:byte[]) (pos:int) =
    let tagValSepPos = findNextTagValSep bs pos
    if tagValSepPos = -1 then None
    else
        let tagLen = tagValSepPos - pos
        let bsVal = Array.zeroCreate<byte> tagLen
        Buffer.BlockCopy (bs, pos, bsVal, 0, tagLen)
        Some (tagValSepPos + 1, bsVal) // +1 to advance past the tag value seperator