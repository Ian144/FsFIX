[<RequireQualifiedAccess>]
module FIXBuf

open System



// converts a byte array containing a FIX msg to a reasonably readable string
let toS (bs:byte array) (posEnd:int) = (System.Text.Encoding.ASCII.GetString bs).Substring(0, posEnd)



let findNextOrEnd (bs:byte array) (pos:int) (bytesToFind:byte) =
    let mutable found = false
    let mutable ctr = pos
    while (ctr < bs.Length && (not found)) do
        if bs.[ctr] = bytesToFind then
            found <- true
        else
            ctr <- ctr + 1
    ctr

let findNextFieldTermOrEnd (bs:byte array) (pos:int) = findNextOrEnd bs pos 1uy

let findNext (bs:byte array) (pos:int) (bytesToFind:byte) =
    let mutable found = false
    let mutable ctr = pos
    while (ctr < bs.Length && (not found)) do
        if bs.[ctr] = bytesToFind then
            found <- true
        else
            ctr <- ctr + 1
    if found then ctr else -1


let findNextFieldTerm (bs:byte array) (pos:int) = findNext bs pos 1uy 
let findNextTagValSep (bs:byte array) (pos:int) = findNext bs pos 61uy


/// used for reading the data component of length+data paired fields, the data component may contain field deliminators
/// checks that the prev byte pointed to by pos is a tag=value separator (i.e. an '=)
/// returns the index of first char after the field value and the value itself
let readNBytesVal (pos:int) (count:int) (bs:byte array) =
    // byte value of '=' is 61, of field delim is 1
    if bs.[pos-1] <> 61uy then failwith "readNBytesVal, prev byte is not a tag value separator"
    if bs.[pos+count] <> 1uy then failwith "readNBytesVal, next byte is not a field delimator"
    let bsVal = Array.zeroCreate<byte> count
    Buffer.BlockCopy (bs, pos, bsVal, 0, count)
    pos+count+1, bsVal


// checks that the prevByte points to a field delimitor
let readTagAfterFieldDelim (bs:byte array) (pos:int) =
    if bs.[pos-1] <> 1uy then failwith "readTagAfterFieldDelim, prev byte is not a field delimitor"
    let tagValSepPos = findNextTagValSep bs pos
    if tagValSepPos = -1 then failwith "could not find next tag-value separator"
    let tagLen = tagValSepPos - pos
    let bsVal = Array.zeroCreate<byte> tagLen
    Buffer.BlockCopy (bs, pos, bsVal, 0, tagLen)
    tagValSepPos + 1, bsVal
