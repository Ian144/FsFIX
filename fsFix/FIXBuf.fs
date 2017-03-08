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


/// used for reading the data component of length+data paired fields, the data component may contain field delimiters
/// checks that the prev byte pointed to by pos is a tag=value separator (i.e. an '=)
/// returns the index of first char after the field value and the value itself
let readNBytesVal (pos:int) (count:int) (bs:byte array) =
    // byte value of '=' is 61, of field delim is 1
    if bs.[pos-1] <> 61uy then failwith "readNBytesVal, prev byte is not a tag value separator"
    if bs.[pos+count] <> 1uy then failwith "readNBytesVal, next byte is not a field delimator"
    let bsVal = bs.[pos..(pos+count-1)]
    pos+count+1, bsVal


// checks that the prevByte points to a field delimiter
let readTagAfterFieldDelim (bs:byte array) (pos:int) =
    if bs.[pos-1] <> 1uy then failwith "readTagAfterFieldDelim, prev byte is not a field delimiter"
    let tagValSepPos = findNextTagValSep bs pos
    if tagValSepPos = -1 then failwith "could not find next tag-value separator"
    let count = tagValSepPos - pos
    let bsVal = bs.[pos..(pos+count-1)]
    tagValSepPos + 1, bsVal
