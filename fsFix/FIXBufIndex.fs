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


// the msg index should not be an array of value types, to avoid reference chasing and cache misses, hence FieldPos is a struct
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


 

let readInt(bs: byte[]) (tagBeg:int) (tagEnd:int) =
    let mutable num = 0
    let mutable ctr = tagBeg
    let mutable b = 0uy
    while ctr < tagEnd do
        b <- bs.[ctr]
        num <- num * 10 + (int32 b) - 48
        ctr <- ctr + 1
    num



let BuildIndex (fieldIndex:FieldPos[]) (bs:byte[]) (bsLen:int) =
    Array.Clear (fieldIndex, 0, fieldIndex.Length)
    let mutable pos = 0
    let mutable pos2 = 0
    let mutable indexCtr = 0
    while pos < bsLen do
        
        // find the next tag value seperator, read the tag
        pos2 <- pos
        while (bs.[pos2] <> 61uy && pos2 < bsLen) do
            pos2 <- pos2 + 1
        let tag = readInt bs pos pos2
        pos <- pos2 + 1 // advance pos to the start of the fields value

        if tag <> 93 && tag <> 90  && tag <> 95  && tag <> 212 && (tag < 348 || tag > 364) && tag <> 445 && tag <> 618 && tag <> 621 then
            // find the end of the field value
            while (bs.[pos2] <> 1uy && pos2 < bsLen) do // 1uy is the field seperator
                pos2 <- pos2 + 1
        
            let fldLen = pos2 - pos
            fieldIndex.[indexCtr] <- FieldPos(tag, pos, fldLen)
        else

            // advance pos2 to the begining of the next field (which will be the data-field), then read the value of the length field
            while (bs.[pos2] <> 1uy && pos2 < bsLen) do // 1uy is the field seperator
                pos2 <- pos2 + 1

            let dataFieldLen = readInt bs pos pos2
            
            // advance to the next tag-value seperator, which should be the start of the data-fields data
            while (bs.[pos2] <> 61uy && pos2 < bsLen) do // 1uy is the field seperator
                pos2 <- pos2 + 1
            
            // advance to the end of the datafield, this range may encompass any embedded field or tag-value separators
            pos2 <- pos2 + dataFieldLen + 1 // +1 to move past the last data cell

            let fldLen = pos2 - pos
            fieldIndex.[indexCtr] <- FieldPos(tag, pos, fldLen)

        pos <- pos2 + 1 // advance pos to the start of the next field
        indexCtr <- indexCtr + 1
    indexCtr





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




