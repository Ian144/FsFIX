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
 
module FIXMsgIndexingPropTests

open System
open System.Reflection

open Xunit
open FsCheck
open FsCheck.Xunit
open Swensen.Unquote

open Generators
open Fix44.Messages
open Fix44.Fields
open Fix44.MessageDU


type FsFixPropertyTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 10000,
        StartSize = 0,
        EndSize = 512,
        Verbose = false
        )

let bufSize = 82 * 1024




[<FsFixPropertyTest>]
let ``reconstruct FIX message buf with header and trailer``
        (beginString:BeginString) 
        (senderCompID:SenderCompID) 
        (targetCompID:TargetCompID) 
        (msgSeqNum:MsgSeqNum) 
        (sendingTime:SendingTime) 
        (msg:FIXMessage) =
    let fixBuf = Array.zeroCreate<byte> bufSize
    let tmpBuf = Array.zeroCreate<byte> bufSize
    let posW = MsgReadWrite.WriteMessageDU tmpBuf fixBuf 0 beginString senderCompID targetCompID msgSeqNum sendingTime msg
    let index = Array.zeroCreate<FIXBufIndexer.FieldPos> bufSize
    let indexEnd = FIXBufIndexer.BuildIndex index fixBuf posW
    let reconstructedFIXBuf = FIXBufIndexer.reconstructFromIndex fixBuf index indexEnd
    let fixBuf2 = fixBuf.[..(posW-1)] // trim fixBuf
    fixBuf2 =! reconstructedFIXBuf
