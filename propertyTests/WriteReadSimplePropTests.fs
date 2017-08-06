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
 
module WriteReadSimplePropTests

open FsCheck.Xunit
open Swensen.Unquote


open PropTestParams



let bufSize = 1024 * 4

    



let WriteReadTest (tIn:'t) (writeFunc:byte[]->int->'t->int) (readFunc:byte[]->int->int->'t) =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    let tOut = readFunc bs 0 posW
    tIn =! tOut


[<PropTest>]
let monthYear (tm:MonthYear.MonthYear) =  WriteReadTest tm MonthYear.write MonthYear.read


[<PropTest>]
let dtTZTimeOnly (tm:TZDateTime.TZTimeOnly) =  WriteReadTest tm TZDateTime.writeTZTimeOnly TZDateTime.readTZTimeOnly


let WriteReadFieldTest (tIn:'t) (writeFunc:byte[]->int->'t->int) readFunc =
    let bs = Array.zeroCreate<byte> bufSize
    let posW = writeFunc bs 0 tIn
    bs.[posW] <- 1uy // append a field terminator
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs posW
    let fpData = fieldPosArr.[0]
    let tOut = readFunc bs fpData.Pos fpData.Len
    tIn =! tOut



[<PropTest>]
let PosMaintRptID (fldIn:Fix44.Fields. PosMaintRptID) = 
    WriteReadFieldTest fldIn Fix44.FieldWriters.WritePosMaintRptID Fix44.FieldReaders.ReadPosMaintRptID

// MDEntryTime wraps UTCTimeOnly
[<PropTest>]
let MDEntryTime (fldIn:Fix44.Fields.MDEntryTime) = WriteReadFieldTest fldIn Fix44.FieldWriters.WriteMDEntryTime Fix44.FieldReaders.ReadMDEntryTime


// RawData is a compound len+data field, the data portion of which may contain field or tag-value seperators
[<PropTest>]
let RawData (fldIn:Fix44.Fields.RawData) = 
    WriteReadFieldTest fldIn Fix44.FieldWriters.WriteRawData Fix44.FieldReaders.ReadRawData



[<PropTest>]
let SecurityRequestType (fldIn:Fix44.Fields.SecurityRequestType) = WriteReadFieldTest fldIn Fix44.FieldWriters.WriteSecurityRequestType Fix44.FieldReaders.ReadSecurityRequestType





