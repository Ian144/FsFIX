﻿(*
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
 

module GenericReaders




// https://software.intel.com/en-us/articles/branch-and-loop-reorganization-to-prevent-mispredicts
// Static branch prediction is used when there is no data collected by the microprocessor when it encounters a branch, which is typically the first time a branch is encountered. 
// The rules are simple:
//  A forward branch defaults to not taken
//  A backward branch defaults to taken
// In order to effectively write your code to take advantage of these rules, when writing if-else or switch statements, check the most common cases first and work progressively 
// down to the least common.


let ReadField bs (index:FIXBufIndexer.IndexData) tag readFunc = 
    let fieldPosArr = index.FieldPosArr
    let tagIdx = FIXBufIndexer.FindFieldIdx index index.EndPos tag
    if tagIdx <> -1 then 
        let fpData = fieldPosArr.[tagIdx] // this is the expected case, and so comes first
        index.LastReadIdx <- tagIdx
        let fld = readFunc bs fpData.Pos fpData.Len
        fieldPosArr.[tagIdx] <- FIXBufIndexer.emptyFieldPos
        fld
    else
        failwithf "field not found, tag: %d" tag



// giving the ordered read functions a different signature to the unordered by adding an unused bool param, to find errors in code generation where the wrong one is called at compile time
let ReadFieldOrdered (_:bool) bs (index:FIXBufIndexer.IndexData) tag readFunc =
    let fieldPosArr = index.FieldPosArr
    let nextFieldIdx = index.LastReadIdx + 1
    let fpData = fieldPosArr.[nextFieldIdx]
    if fpData.Tag = tag then
        index.LastReadIdx <- nextFieldIdx // this is the expected case, and so comes first
        let fld = readFunc bs fpData.Pos fpData.Len 
        fieldPosArr.[nextFieldIdx] <- FIXBufIndexer.emptyFieldPos
        fld
    else
        failwithf "field not found, tag: %d at field pos: %d" tag nextFieldIdx



let ReadOptionalField (bs:byte[]) (index:FIXBufIndexer.IndexData) (tag:int) readFunc = 
    let fieldPosArr = index.FieldPosArr
    let tagIdx = FIXBufIndexer.FindFieldIdx index index.EndPos tag
    if tagIdx = -1 then // no preference as to wether the common case is Option.None or not
        Option.None
    else
        index.LastReadIdx <- tagIdx
        let fpData = fieldPosArr.[tagIdx]
        let fld = readFunc bs fpData.Pos fpData.Len
        fieldPosArr.[tagIdx] <- FIXBufIndexer.emptyFieldPos
        Option.Some fld

// giving the ordered read functions a different signature to the unordered by adding an unused bool param, to find errors in code generation where the wrong one is called at compile time
let ReadOptionalFieldOrdered (_:bool) (bs:byte[]) (index:FIXBufIndexer.IndexData) (tag:int) readFunc = 
    let fieldPosArr = index.FieldPosArr
    let nextFieldIdx = index.LastReadIdx + 1
    let fpData = fieldPosArr.[nextFieldIdx]
    if fpData.Tag = tag then // no preference as to wether the common case is Option.None or not
        index.LastReadIdx <- nextFieldIdx
        let fld = readFunc bs fpData.Pos fpData.Len
        fieldPosArr.[nextFieldIdx] <- FIXBufIndexer.emptyFieldPos
        Option.Some fld
    else
        Option.None


// the int that readFunc returns is the consecutively next index pos in the FIX buffer field index array 
let rec private readGrpInner (bs:byte[]) (index:FIXBufIndexer.IndexData) (acc:'grp list) (recursionCount:uint32) (readFunc: byte[]->FIXBufIndexer.IndexData->'grp) =
    match recursionCount with
    | 0u    ->  acc |> List.rev // without this the last group in the fix buffer would be first in the list, todo: fix this possible perf issue
    | _     ->  let grpInstance = readFunc bs index
                readGrpInner bs index (grpInstance::acc) (recursionCount-1u) readFunc


// the tag is the tag of the "number group repeats" field, which can be anywhere in the buffer/index
// the rest of the group fields must come consecutively after this point
let ReadGroup (bs:byte[]) (index:FIXBufIndexer.IndexData) (numFieldTag:int) readFunc =
    let fieldPosArr = index.FieldPosArr
    let numFieldIndex = FIXBufIndexer.FindFieldIdx index index.EndPos numFieldTag
    if numFieldIndex <> -1 then 
        let numFieldData = fieldPosArr.[numFieldIndex]
        index.LastReadIdx <- numFieldIndex
        let numRepeats = Conversions.bytesToUInt32 bs numFieldData.Pos numFieldData.Len
        fieldPosArr.[numFieldIndex] <- FIXBufIndexer.emptyFieldPos
        readGrpInner bs index [] numRepeats readFunc
    else
        failwithf "group num field not found, tag: %d" numFieldTag


// the tag is the tag of the "number group repeats" field, which must be the next field relative to the last field read-in
// the rest of the group fields must come consecutively after this point
let ReadGroupOrdered (_:bool) (bs:byte[]) (index:FIXBufIndexer.IndexData) (numFieldTag:int) readFunc =
    let fieldPosArr = index.FieldPosArr
    let nextFieldIndex = index.LastReadIdx + 1 // if the group exists the num field must be here
    let fpData = fieldPosArr.[nextFieldIndex]
    if fpData.Tag = numFieldTag then 
        let numFieldData = index.FieldPosArr.[nextFieldIndex]
        index.LastReadIdx <- nextFieldIndex
        let numRepeats = Conversions.bytesToUInt32 bs numFieldData.Pos numFieldData.Len
        fieldPosArr.[nextFieldIndex] <- FIXBufIndexer.emptyFieldPos
        readGrpInner bs index [] numRepeats readFunc 
    else
        failwithf "group num field not found, tag: %d" numFieldTag


let ReadNoSidesGroup (bs:byte[]) (index:FIXBufIndexer.IndexData) (numFieldTag:int) readFunc =
    let fieldPosArr = index.FieldPosArr
    let numFieldIndex = FIXBufIndexer.FindFieldIdx index index.EndPos numFieldTag
    if numFieldIndex <> -1 then 
        let numFieldData = fieldPosArr.[numFieldIndex]
        index.LastReadIdx <- numFieldIndex
        let numRepeats = Conversions.bytesToUInt32 bs numFieldData.Pos numFieldData.Len
        fieldPosArr.[numFieldIndex] <- FIXBufIndexer.emptyFieldPos
        match numRepeats with
        | 1u  -> let grp = readFunc bs index // the group must start after the num field
                 OneOrTwo.One grp
        | 2u  -> let grp1 = readFunc bs index
                 let grp2 = readFunc bs index
                 OneOrTwo.Two (grp1, grp2)
        | x   -> failwithf "ReadNoSidesGroup invalid num repeats, must be 1 or 2, was: %d" x
    else
       failwithf "group num field not found, tag: %d" numFieldTag


let ReadNoSidesGroupOrdered (bs:byte[]) (index:FIXBufIndexer.IndexData) (numFieldTag:int) readFunc =
    let fieldPosArr = index.FieldPosArr
    let nextFieldIdx = index.LastReadIdx + 1 // if the group exists the num field must be here
    let numFieldData = fieldPosArr.[nextFieldIdx]
    if numFieldData.Tag = numFieldTag then 
        index.LastReadIdx <- nextFieldIdx
        let numRepeats = Conversions.bytesToUInt32 bs numFieldData.Pos numFieldData.Len
        fieldPosArr.[nextFieldIdx] <- FIXBufIndexer.emptyFieldPos
        match numRepeats with
        | 1u  -> let grp = readFunc bs index // the group must start after the num field
                 OneOrTwo.One grp
        | 2u  -> let grp1 = readFunc bs index
                 let grp2 = readFunc bs index
                 OneOrTwo.Two (grp1, grp2)
        | x   -> failwithf "ReadNoSidesGroup invalid num repeats, must be 1 or 2, was: %d" x
    else
        failwithf "group num field not found, tag: %d" numFieldTag


let ReadOptionalGroup (bs:byte[]) (index:FIXBufIndexer.IndexData) (numFieldTag:int) readFunc: 'grp list option =
    // the optional group is allowed to start anywhere, so search for the num field, after that field others must appear in order
    let fieldPosArr = index.FieldPosArr
    let numFieldIdx = FIXBufIndexer.FindFieldIdx index index.EndPos numFieldTag
    if numFieldIdx = -1 then 
        Option.None // the optional group is not present
    else
        // the optional group is present, so read the number of repeats, then read each instance of the repeating group
        let fpData = fieldPosArr.[numFieldIdx]
        index.LastReadIdx <- numFieldIdx
        let numRepeats = Conversions.bytesToUInt32 bs fpData.Pos fpData.Len
        fieldPosArr.[numFieldIdx] <- FIXBufIndexer.emptyFieldPos
        let gs = readGrpInner bs index [] numRepeats readFunc
        Option.Some gs


let ReadOptionalGroupOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.IndexData) (numFieldTag:int) readFunc: 'grp list option =
    let fieldPosArr = index.FieldPosArr
    let nextFieldIdx = index.LastReadIdx + 1 // if the group exists the num field must be here
    let fpData = fieldPosArr.[nextFieldIdx]
    if fpData.Tag = numFieldTag then
        index.LastReadIdx <- nextFieldIdx
        let numRepeats = Conversions.bytesToUInt32 bs fpData.Pos fpData.Len        
        fieldPosArr.[nextFieldIdx] <- FIXBufIndexer.emptyFieldPos
        readGrpInner bs index [] numRepeats readFunc |> Option.Some
    else
        Option.None // the optional group is not present



let ReadComponent (bs:byte[]) (index:FIXBufIndexer.IndexData) readFunc = 
    readFunc bs index


// the first field of an optional component is required, so the component is present if the first field is present
let ReadOptionalComponent (bs:byte[]) (index:FIXBufIndexer.IndexData) (firstFieldTag:int) readFunc =
    let numFieldIdx = FIXBufIndexer.FindFieldIdx index index.EndPos firstFieldTag
    if numFieldIdx = -1 then 
        Option.None // the optional component is not present
    else
        let comp = readFunc bs index
        Option.Some comp


// giving the ordered read functions a different signature to the unordered by adding an unused bool param, to find errors in code generation where the wrong one is called at compile time
let ReadComponentOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.IndexData) readFunc = 
    readFunc bb bs index

// giving the ordered read functions a different signature to the unordered by adding an unused bool param, to find errors in code generation
// the first field of an optional component is required (code generation always sets this to be the case, ignoring FIX spec xml), so the component is present if the first field is present
let ReadOptionalComponentOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.IndexData) (firstFieldTag:int) readFunc =
    let nextFieldIdx = index.LastReadIdx + 1
    let fpData = index.FieldPosArr.[nextFieldIdx]
    if fpData.Tag = firstFieldTag then 
        // the component is present, but the first fields value has not been read yet, so not setting that index entry to empty (meaning already read)
        let comp = readFunc bb bs index
        Option.Some comp
    else
        Option.None // the optional component is not present

