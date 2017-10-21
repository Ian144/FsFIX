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
 

open System
open System.Net.Sockets
open FsCheck

open Fix44.Fields
open Fix44.Messages
open Fix44.MessageDU
open Fix44.MessageFactoryFuncs
open CmdLine

Arb.register<Generators.ArbOverrides>() |> ignore






let msgExclusions (msgIn:FIXMessage) =
    match msgIn with
    | FIXMessage.Logon  _                    -> false // admin
    | FIXMessage.Logout _                    -> false // admin
    | FIXMessage.TestRequest _               -> false // admin
    | FIXMessage.ResendRequest _             -> false // admin
    | FIXMessage.Reject _                    -> false // admin
    | FIXMessage.SequenceReset _             -> false // admin
    | FIXMessage.Heartbeat _                 -> false // admin
    | FIXMessage.BusinessMessageReject _     -> false // causes quickfixj echo to stall, maybe this is an 'admin like' msg
    | _                                      -> true


let isHeartbeat (msg:FIXMessage) =
    match msg with
    |  FIXMessage.Heartbeat  _  -> true
    |   _                       -> false




let config = { Config.Quick with StartSize = 1; EndSize = 8; MaxTest = 100000000 }



#nowarn "52"
let WaitForExitCmd () =
    printfn "press 'X' to exit"
    while stdin.Read() = 88 do // 88 is 'X'
        ()


let runFIXEcho (host:string) (port:int) senderCompID targetCompID msgDiffOutPath = 
    let client = new TcpClient()
    client.Connect (host, port)
    let strm = client.GetStream()

    let beginString = BeginString "FIX.4.4"
    let mutable seqNum = 1u
    let msgSeqNum = MsgSeqNum seqNum
    let utcNow = System.DateTime.UtcNow
    let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Millisecond)
    let sendingTime = SendingTime ts

    let index = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 16)
    let bufSize = 1024 * 84

    let tmpBuf = Array.zeroCreate<byte> bufSize
    let bufIn = Array.zeroCreate<byte> bufSize
    let bufOut = Array.zeroCreate<byte> bufSize
    let logonMsg =  MkLogon (EncryptMethod.NoneOther, HeartBtInt 240 ) |> Fix44.MessageDU.FIXMessage.Logon
    let posW = MsgReadWrite.WriteMessageDU tmpBuf bufIn 0 beginString senderCompID targetCompID msgSeqNum sendingTime logonMsg
    do strm.Write (bufIn, 0, posW)
    printfn "logon sent"

    let numBytesReceived = strm.Read (bufIn, 0, bufSize)
    printfn "logon reply: %d bytes received" numBytesReceived
    let logonMsgReply = MsgReadWrite.ReadMessage bufIn numBytesReceived


    let propSendMsgToQuickfixEchoConfirmReplyIsTheSame (msgInDNS:FIXMessage DoNotShrink) =
        let (DoNotShrink msgIn) = msgInDNS
        if msgExclusions msgIn then // not using ==> lazy as that results in multiple property tests running concurrently, quickfixEcho expects responses to follow msgs before the next msg can be sent
            seqNum <- seqNum + 1u
            let msgSeqNum = MsgSeqNum seqNum
            let utcNow = System.DateTime.UtcNow
            let ts = UTCDateTime.MakeUTCTimestamp.Make (utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, utcNow.Millisecond)
            let sendingTime = SendingTime ts

            System.Array.Clear (bufIn, 0, bufIn.Length)
            System.Array.Clear (tmpBuf, 0, tmpBuf.Length)
            System.Array.Clear (bufOut, 0, bufIn.Length)
            System.Array.Clear (index, 0, index.Length)

            // send msg to quickfix echo
            let numBytesToSend = MsgReadWrite.WriteMessageDU tmpBuf bufIn 0 beginString  senderCompID targetCompID msgSeqNum sendingTime msgIn
            let indexEnd = FIXBufIndexer.BuildIndex index bufIn numBytesToSend
            let tag = GetTag msgIn
            let sTag = FIXBuf.toS tag tag.Length
            printfn "sending: 35=%s" sTag
            //DisplayLengths index indexEnd bufIn
            
            strm.Write (bufIn, 0, numBytesToSend)

            let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 8)
            // receive the reply, assuming all bytes are read
            let numBytesReceived = strm.Read (bufOut, 0, bufSize)
            let msgOut = MsgReadWrite.ReadMessage bufOut numBytesReceived fieldPosArr

            let msgOut2 =
                if isHeartbeat msgOut then
                    System.Array.Clear (bufIn, 0, bufIn.Length)
                    let numBytesReceived = strm.Read (bufIn, 0, bufSize)
                    Array.Clear (fieldPosArr, 0, fieldPosArr.Length)
                    MsgReadWrite.ReadMessage bufIn numBytesReceived fieldPosArr
                else
                    msgOut

            let ok = msgIn = msgOut2
            if not ok then
                use swA      = new System.IO.StreamWriter( msgDiffOutPath + """\msgIn.fs"""       )
                use swB      = new System.IO.StreamWriter( msgDiffOutPath + """\msgOut.fs"""      )
                use swBytesA = new System.IO.StreamWriter( msgDiffOutPath + """\msgInBytes.fs"""  )
                use swBytesB = new System.IO.StreamWriter( msgDiffOutPath + """\msgOutBytes.fs""" )
                fprintfn swA "%A" msgIn
                fprintfn swB "%A" msgOut2
                fprintfn swBytesA "%s" (FIXBuf.toS bufIn numBytesToSend)
                fprintfn swBytesB "%s" (FIXBuf.toS bufOut numBytesReceived)
                printfn "msg diffs saved"
            ok
        else // msg is an admin msg, these are ignored as they would affect the FIX echo session
            true
    
    Check.One (config, propSendMsgToQuickfixEchoConfirmReplyIsTheSame)



[<EntryPoint>]
let main args = 

//  let port = 5001 // for quickFixN echo
//  let senderCompID = SenderCompID "CLIENT1" // for quickFixN
//  let targetCompID = TargetCompID "EXECUTOR" // for quickFixN

//  let port = 9880 // for quickFixJ echo
//  let senderCompID = SenderCompID "BANZAI"//for quickFixJ
//  let targetCompID = TargetCompID "EXEC" // for quickFixJ

    let cmdLine = ParseCmdLine args

    match cmdLine with
    | Choice1Of2 (host, port, senderCompID, targetCompID, msgDiffOutPath) -> runFIXEcho host port senderCompID targetCompID msgDiffOutPath
    | Choice2Of2 errMsg -> 
        printfn "invalid command-line params, %s" errMsg
        printfn "should be - FsFIXEcho.exe <targetHost> <targetPort> <SenderCompID> <TargetCompID> <badMsgOutDir>"
    
    //todo:  log off
        
    WaitForExitCmd ()

    0 // exit code



