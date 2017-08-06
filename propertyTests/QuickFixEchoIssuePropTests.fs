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
 
module QuickFixEchoIssuePropTests


open FsCheck.Xunit
open Swensen.Unquote

open Fix44.Fields
open Fix44.CompoundItems
open Fix44.CompoundItemWriters
open Fix44.MessageDU

open Generators


let bufSize = 1024 * 128
let bs = Array.zeroCreate<byte> bufSize    
let tmpBs = Array.zeroCreate<byte> bufSize
let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 32)

type PropTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 10000,
        StartSize = 0,
        EndSize = 64,
        Verbose = false,
        QuietOnSuccess = true
    )

//
//[<PropTest>]
//let ``all fields have values of non-zero length`` (msg:FIXMessage) = 
//    System.Array.Clear (bs, 0, bs.Length)
//    System.Array.Clear (fieldPosArr, 0, fieldPosArr.Length)
//    let posW = Fix44.MessageDU.WriteMessage bs 0 msg
//    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs posW
//    let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)
//
//    let lenDataIndex = fieldPosArr |>  Array.filter (fun xx -> FIXBufIndexer.IsLenDataCompoundTag xx.Tag)
//    
//    let lenDataFieldValues = lenDataIndex |> Array.map (fun fpData ->
//        let lengthFieldTermPos = FIXBuf.findNextFieldTermOrEnd bs fpData.Pos
//        let dataFieldLength = Conversions.bytesToInt32 bs fpData.Pos (lengthFieldTermPos - fpData.Pos)
//        dataFieldLength, fpData)
//
//    let zeroLenDataFields = lenDataFieldValues |> Array.filter (fun (len, _) -> len = 0) 
//
//    let zeroLenFields = fieldPosArr |> Array.truncate indexEnd |> Array.filter (fun xx -> xx.Len = 0)
//    [||] =! zeroLenDataFields
//    [||] =! zeroLenFields
    
    

// quickfix echo says fsFix messages have an incorrect body length, this test seems to indicate fsFix is correct (different interpretation of fix spec?)
[<PropTest>]
let ``the body length field contains the correct value`` (msg:FIXMessage) =
    System.Array.Clear (bs, 0, bs.Length)
    System.Array.Clear (tmpBs, 0, tmpBs.Length)
    System.Array.Clear (fieldPosArr, 0, fieldPosArr.Length)

    let beginString:BeginString = BeginString.BeginString "FIX.4.4"
    let senderCompID:SenderCompID = SenderCompID.SenderCompID "senderCompID"
    let targetCompID:TargetCompID = TargetCompID.TargetCompID "targetCompID"
    let msgSeqNum:MsgSeqNum = MsgSeqNum.MsgSeqNum 99u
    let sendingTime:SendingTime = SendingTime.SendingTime (UTCDateTime.readUTCTimestamp "20170123-05:30:00.000"B 0 21)
    let posW = MsgReadWrite.WriteMessageDU tmpBs bs 0 beginString senderCompID targetCompID msgSeqNum  sendingTime msg
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs posW
    let bodyLenFieldPos = fieldPosArr.[1] // bodylen is always the 2nd field
    let checkSumFieldPos = fieldPosArr.[indexEnd - 1] // checksum is always the last field
    let firstByteAfterBodyLen = bodyLenFieldPos.Pos + bodyLenFieldPos.Len + 1
    let lastFieldTermBeforeChecksumPos = checkSumFieldPos.Pos - 4 // checkSumFieldPos.Pos contains the position of the checksum value, need to move back 4 to get to the prev field terminator
    let calcedBodyLen = lastFieldTermBeforeChecksumPos - (firstByteAfterBodyLen-1)
    let receivedBodyLen = Conversions.bytesToInt32 bs bodyLenFieldPos.Pos bodyLenFieldPos.Len
//    let endBodyLen2 = fieldPosArr.[1].Pos + fieldPosArr.[1].Len + 1
//    let endBodyLen = fieldPosArr.[2].Pos - 4 // 2 is the index of the msgTag, the tag + tag-value seperator length is 3
//    let endTargetCompId = fieldPosArr.[6].Pos + fieldPosArr.[6].Len
//    let hdrLen = endTargetCompId - endBodyLen
//    let nonHdrLen = lastFieldTermBeforeChecksumPos - endTargetCompId
    calcedBodyLen =! receivedBodyLen





