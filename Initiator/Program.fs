﻿// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

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


open Fix44.MessageFactoryFuncs
open Fix44.Fields

let convFieldSep (bb:byte) = 
    match bb with 
    | 124uy -> 1uy
    | n     -> n


//let quoteStatusRequestWithGrpBytes          = "8=FIX.4.4|9=140|35=a|34=99|49=senderCompID|52=20071123-05:30:00.000|56=targetCompID|55=ABCDE|555=3|600=BCDEF|601=PQRS|600=CDEFG|601=QRST|600=DEFGH|601=RSTU|10=134|"B |> Array.map convFieldSep
//let quoteStatusRequestWithNestedGrpsBytes   = "8=FIX.4.4|9=246|35=a|34=99|49=senderCompID|52=20071123-05:30:00.000|56=targetCompID|55=ABCDE|555=3|600=BCDEF|601=PQRS|604=2|605=12345|606=QWERTYU|605=23456|606=ASDFGHJ|600=CDEFG|601=QRST|604=1|605=34567|606=ZXCVBNM|600=DEFGH|601=RSTU|604=1|605=45678|606=POIUYTR|10=043|"B  |> Array.map convFieldSep
//let newOrderMultilegBytes                   = "8=FIX.4.4|9=1491|35=AB|34=99|49=senderCompID|52=20071123-05:30:00.000|56=targetCompID|11=PZXWQ|526=EFZDRSMQ|453=0|229=20170122|75=20170122|1=PKNOIWA|660=3|581=2|589=0|590=1|70=ZNOSMQBF|78=0|63=9|64=20170122|544=2|635=H|21=3|110=792281624589241053767102627.850000000000000|111=3.689348814312414|100=UYJN|386=0|81=0|54=F|55=RSWQE|65=WI|48=FJXY|22=D|454=0|461=WAUIJ|167=TIPS|762=JXYCWAL|200=201701w1|541=20170122|201=0|224=20170122|239=0|226=1|227=-5534023222112865484.700000000000000|228=79228162477.370849433239945|255=ESTXRVJK|543=YSWHLF|470=IMGKYZT|472=VZNO|240=20170122|202=79228162458924105376.710262785000000|947=CWKL|206=4|231=-3689348814312413.593900000000000|223=-792281.625142643375807|106=GHBFTU|348=2|349=AA|107=QUOJDHBP|350=2|351=BB|691=DRSWQEF|875=-2|876=UVZTX|864=0|873=20170122|874=20170122|140=-7922816249581759353.271930061100000|555=0|114=N|60=20170122-06:54:00|854=1|152=-0.000000003689349|516=-5534.023223401355674|468=1|469=792281.624958175935327|40=M|44=36.893488143124136|99=79228162477370849459009.748992000000000|15=USD|376=NHVWAUY|377=Y|23=ALPJNB|117=KOCDXBP|168=20170122-06:54:00|432=20170122|126=20170122-06:54:00|427=2|12=-79228.162495817593533|13=4|479=VZTHIMGU|497=N|529=7|582=4|121=Y|120=ZTXLMG|775=0|58=MGBVZT|354=2|355=CC|77=C|203=0|210=-792281.624773708494590|211=-79228162477370849.454714781696000|836=1|837=2|838=2|840=1|388=6|389=-79228162514264337580659048.449000000000000|841=1|842=0|843=0|844=1|846=1|847=-3|848=UOSMHBFZ|849=-55.340232221128655|480=N|481=1|513=EFJDHS|563=1|10=000|"B |> Array.map convFieldSep
//let marketDataRequest                       = "8=FIX.4.4|9=138|35=V|34=99|49=senderCompID|52=20071123-05:30:00.000|56=targetCompID|262=MDRQ-1487838687427|263=1|264=1|267=2|269=0|269=1|146=1|55=EUR/USD|10=133|"B  |> Array.map convFieldSep


[<EntryPoint>]
let main argv = 
    
    let em        = Fix44.Fields.EncryptMethod.NoneOther
    let hb        = Fix44.Fields.HeartBtInt 60
    let un        = Username "fred" |> Option.Some
    let pw        = Password "pw" |> Option.Some
    let logonMsg  = Fix44.MessageFactoryFuncs.MkLogon (em, hb)
    let logonMsg2 = {logonMsg with Username = un; Password = pw} |> Fix44.MessageDU.FIXMessage.Logon
    
    
    let fixVer          = BeginString   "FIX.4.4"
    let senderCompID    = SenderCompID  "initiator"
    let targetCompID    = TargetCompID  "acceptor"
    
    let dtoUtcNow   = DateTimeOffset.UtcNow
    let utcNow      = UTCDateTime.MakeUTCTimestamp.Make dtoUtcNow
    let sendingTime = SendingTime utcNow

    let msgSeqNum = MsgSeqNum 0u

    let tmpBuf = Array.zeroCreate<byte> (1024 * 16)
    let buf = Array.zeroCreate<byte> (1024 * 16)

    use tcpClient = new TcpClient("127.0.0.1", 5001)
    use strm = tcpClient.GetStream()
    let bytesWritten = MsgReadWrite.WriteMessageDU tmpBuf buf 0 fixVer senderCompID targetCompID msgSeqNum sendingTime logonMsg2
    strm.Write( buf, 0, bytesWritten )





    Console.WriteLine("press any key to exit")
    Console.ReadKey() |> ignore

    0 // exit code
