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
 

module FIXBufIndexer

open System


//// when using F# 4.1 consider
////[<Struct>]
////type FieldPos = { Tag:int; Pos:int; Len:int }
//ToString for FieldPos??
//    deconstruct the tag??


//
// type PosLen =
//    struct
//      val Pos:int
//      val len:int
//      new(pos:int;len:int) = {Pos=pos; Len=len}
//    end
// 
//type FieldIndex =
//   struct
//      val Tag: int array// storing tag as an int32 (ok so long as tags are 4 bytes or less long), an array is a refernce type, this avoids chasing down references
//      val PosLen: PosLen array
//      new(tag:int array, pl:PosLen array) = { Tag = tag; PosLen = pl}
//   end


// the msg index should not be an array of value types, do not the reference chasing and cache misses, hence FieldPos is a struct
type FieldPos =
   struct
      val Tag: int // storing tag as an int32 (ok so long as tags are 4 bytes or less long), an array is a refernce type, this avoids chasing down references
      val Pos: int
      val Len: int
      new(tag:int, pos:int, len:int) = {Tag = tag; Pos = pos; Len = len}
   end
    // this member func is for developer convenience, it should not be called in performance critical code
    override this.ToString() =
        sprintf "%d-%d-%d" this.Tag this.Pos this.Len

let emptyFieldPos = FieldPos(0,0,0)



[< NoComparison; NoEquality>]
type IndexData (endPos: int, fieldPosArr: FieldPos[]) =
    member this.EndPos = endPos
    member this.FieldPosArr = fieldPosArr
    member val LastReadIdx = -1 with get,set


//let FindFieldIdx (index:IndexData) (indexEnd:int) (tagRequired:int) =
//    let mutable ctr = 0
//    let mutable foundPos = -1
//    let fieldPosArr = index.FieldPosArr
//    while (foundPos = -1) && (ctr < indexEnd) do
//        if tagRequired <> fieldPosArr.[ctr].Tag then
//            ctr <- ctr + 1
//        else
//            foundPos <- ctr
//    foundPos


// this version optimistically tries the next unread field to see if it is the one being searched for
let FindFieldIdx (index:IndexData) (indexEnd:int) (tagRequired:int) =
    let fieldPosArr = index.FieldPosArr
    let nextIdx = index.LastReadIdx + 1
    if tagRequired = fieldPosArr.[nextIdx].Tag then
        nextIdx
    else
        let mutable ctr = 0
        let mutable foundPos = -1
        while (foundPos = -1) && (ctr < indexEnd) do
            if tagRequired <> fieldPosArr.[ctr].Tag then
                ctr <- ctr + 1
            else
                foundPos <- ctr
        foundPos




// in the case of non-field tags that contain alpha chars
//let inline convTagToInt (bs:byte[]) (tagBeg:int) (tagEnd:int) =
//    let tagLen = tagEnd - tagBeg
//    match tagLen with
//    | 1     ->   int( bs.[tagBeg] )
//    | 2     ->  (int( bs.[tagBeg+1] ) <<< 8 ) +  int( bs.[tagBeg] ) // msb is at the higher indice
//    | 3     ->  (int( bs.[tagBeg+2] ) <<< 16) + (int( bs.[tagBeg+1] ) <<< 8 ) +  int( bs.[tagBeg] ) 
//    | 4     ->  (int( bs.[tagBeg+3] ) <<< 24) + (int( bs.[tagBeg+2] ) <<< 16) + (int( bs.[tagBeg] ) <<< 8) + int( bs.[tagBeg] ) 
//    | n     ->  failwith "convTagToInt, invalid tag indices - begin %d, end: %d. Len (end - beg) should be 1, 2, 3 or 4" tagBeg tagEnd


let convTagToInt(bs: byte[]) (tagBeg:int) (tagEnd:int) =
    let len = tagEnd - tagBeg
    match len with
    | 1 ->  int(bs.[tagBeg+0] - 48uy)
    | 2 ->  int(bs.[tagBeg+0] - 48uy) * 10   + int(bs.[tagBeg+1] - 48uy)
    | 3 ->  int(bs.[tagBeg+0] - 48uy) * 100  + int(bs.[tagBeg+1] - 48uy) * 10  + int(bs.[tagBeg+2] - 48uy)
    | 4 ->  int(bs.[tagBeg+0] - 48uy) * 1000 + int(bs.[tagBeg+1] - 48uy) * 100 + int(bs.[tagBeg+2] - 48uy) * 10 + int(bs.[tagBeg+3] - 48uy)
    | n ->  failwithf "convTagToInt, invalid tag indices - begin %d, end: %d. Len (end - beg) should be 1, 2, 3 or 4" tagBeg tagEnd 


// i.e. is the tag that of the first field of a len+data field pair
// these ints match the tags of FIX4.4 len+data fields only
// todo: this should be generated for each fix version
let inline IsLenDataCompoundTag (tagInt:int) = 
    match tagInt with
    | 93  -> true // Signature
    | 90  -> true // SecureData
    | 95  -> true // RawData
    | 212 -> true // XmlData
    | 348 -> true // EncodedIssuer
    | 350 -> true // EncodedSecurityDesc
    | 352 -> true // EncodedListExecInst
    | 354 -> true // EncodedText
    | 356 -> true // EncodedSubject
    | 358 -> true // EncodedHeadline
    | 360 -> true // EncodedAllocText
    | 362 -> true // EncodedUnderlyingIssuer
    | 364 -> true // EncodedUnderlyingSecurityDesc
    | 445 -> true // EncodedListStatusText
    | 618 -> true // EncodedLegIssuer
    | 621 -> true // EncodedLegSecurityDesc
    | _   -> false



// todo: consider inlining, this returns a reference type (would i have to manually inline to avoid the ref type??)
let makeIndexField (bs:byte[]) (pos:int) : (int*FieldPos) = 
    let tagValSepPos = FIXBuf.findNextTagValSep bs pos
    let fldBeg = tagValSepPos + 1
    let tagInt = convTagToInt bs pos tagValSepPos
    if not (IsLenDataCompoundTag tagInt) then
        let nextFldOrEnd = FIXBuf.findNextFieldTermOrEnd bs fldBeg
        let fldLen = nextFldOrEnd - fldBeg
        let fp = FieldPos(tagInt, fldBeg, fldLen)
        nextFldOrEnd + 1, fp
    else
        // eat the next field, i.e. the data field component of the len+data pair, including the tag
        let fieldTerm = FIXBuf.findNextFieldTermOrEnd bs (tagValSepPos+1)
        let len = fieldTerm - (tagValSepPos+1)
        let dataFieldLen = Conversions.bytesToInt32 bs (tagValSepPos+1) len
        let nextFieldBeg = fieldTerm + 1
        let dataFieldTagValSepPos = FIXBuf.findNextTagValSep bs nextFieldBeg
        let endDataFieldPos = dataFieldTagValSepPos + dataFieldLen + 1 // +1 to move one past the end
        let compoundFieldLen = endDataFieldPos - fldBeg
        let fp = FieldPos(tagInt, fldBeg, compoundFieldLen)        
        endDataFieldPos + 1, fp




// populates the fieldIndex array - this is not functional programming, using imperative techniques for performance
// returns the array cell index one after the last populated
let BuildIndexX (fieldIndex:FieldPos[]) (bs:byte[]) (posEnd:int) =
    Array.Clear (fieldIndex, 0 ,fieldIndex.Length)
    let mutable pos = 0
    let mutable ctr = 0
    while pos < posEnd do
        let pos2, fp = makeIndexField bs pos
        pos <- pos2
        fieldIndex.[ctr] <- fp
        ctr <- ctr + 1
    ctr


let BuildIndex (fieldIndex:FieldPos[]) (bs:byte[]) (posEnd:int) =
    Array.Clear (fieldIndex, 0 ,fieldIndex.Length)
    let mutable pos = 0
    let mutable ctr = 0
    while pos < posEnd do
//        let pos2, fp = makeIndexField bs pos
        let tagValSepPos = FIXBuf.findNextTagValSep bs pos
        let fldBeg = tagValSepPos + 1
        let tagInt = convTagToInt bs pos tagValSepPos
        if not (IsLenDataCompoundTag tagInt) then
            let nextFldOrEnd = FIXBuf.findNextFieldTermOrEnd bs fldBeg
            let fldLen = nextFldOrEnd - fldBeg
            pos <- nextFldOrEnd + 1
            fieldIndex.[ctr] <- FieldPos(tagInt, fldBeg, fldLen)
        else
            // eat the next field, i.e. the data field component of the len+data pair, including the tag
            let fieldTerm = FIXBuf.findNextFieldTermOrEnd bs (tagValSepPos+1)
            let len = fieldTerm - (tagValSepPos+1)
            let dataFieldLen = Conversions.bytesToInt32 bs (tagValSepPos+1) len
            let nextFieldBeg = fieldTerm + 1
            let dataFieldTagValSepPos = FIXBuf.findNextTagValSep bs nextFieldBeg
            let endDataFieldPos = dataFieldTagValSepPos + dataFieldLen + 1 // +1 to move one past the end
            let compoundFieldLen = endDataFieldPos - fldBeg
            pos <- endDataFieldPos + 1
            fieldIndex.[ctr] <- FieldPos(tagInt, fldBeg, compoundFieldLen)        

        ctr <- ctr + 1
    ctr



// used for roundtrip property testing, if the index cant be used to reconstruct the original FIX buf then something is broken
let reconstructFromIndex (origBuf:byte[]) (index:FieldPos[]) (indexEnd:int) : byte [] =
    let index = index |> Array.take indexEnd
    let lastEl = index.[indexEnd-1]
    let reconLen = lastEl.Pos + lastEl.Len + 1 // +1 to leave room for the final field seperator
    let reconBuf = Array.zeroCreate<byte> reconLen
    let convIntToTagBytes (tag:int) = 
        let ss = sprintf "%d" tag
        System.Text.Encoding.ASCII.GetBytes  ss
    for fp in index do
        // tag
        let tagBs = convIntToTagBytes fp.Tag
        let tagPos = fp.Pos - (tagBs.Length + 1) // +1 to leave room for the tag-value seperator
        Array.Copy( tagBs, 0, reconBuf, tagPos, tagBs.Length )
        
        // tagValue sep
        let tagValSepPos = fp.Pos - 1
        reconBuf.[tagValSepPos] <- 61uy
        
        // field value
        Array.Copy( origBuf, fp.Pos, reconBuf, fp.Pos, fp.Len )

        // field seperator
        let fldSepPos = fp.Pos + fp.Len
        reconBuf.[fldSepPos] <- 1uy
    reconBuf




