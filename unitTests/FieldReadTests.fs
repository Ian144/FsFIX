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
 
module FieldReadUnitTests


open Xunit

open Fix44.Fields
open Fix44.FieldReaders
open Swensen.Unquote


let private indexSingleField bs = 
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs bs.Length
    let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)
    let fpData = fieldPosArr.[0]
    fpData.Pos, fpData.Len



[<Fact>]
let ``read single case DU`` () =
    let bs = [| yield! "1=AccountStr"B; yield 1uy |]
    let pos, len = indexSingleField bs
    let fld = ReadAccount bs pos len
    (Account.Account "AccountStr") =! fld


[<Fact>]
let ``read multicase DU case Buy`` () =
    let bs = [| yield! "3=B"B; yield 1uy |]
    let pos, len = indexSingleField bs
    let fld = ReadAdvSide bs pos len
    AdvSide.Buy =! fld


[<Fact>]
let ``read multicase DU case 1`` () =
    let bs = [| yield! "3=S"B; yield 1uy |]
    let pos, len = indexSingleField bs
    let fld = ReadAdvSide bs pos len
    AdvSide.Sell =! fld


[<Fact>]
let ``read multicase DU case Cross`` () =
    let bs = [| yield! "3=X"B; yield 1uy |]
    let pos, len = indexSingleField bs
    let fld = ReadAdvSide bs pos len
    AdvSide.Cross =! fld


[<Fact>]
let ``read multicase DU case Trade`` () =
    let bs = [| yield! "3=T"B; yield 1uy |]
    let pos, len = indexSingleField bs
    let fld = ReadAdvSide bs pos len
    AdvSide.Trade =! fld


[<Fact>]
let ``read multicase DU case invalid`` () =
    let bs = [| yield! "3=TT"B; yield 1uy |]
    let pos, len = indexSingleField bs
    try
        ReadAdvSide bs pos len |> ignore
        true =! false
    with
        | ex -> "ReadAdvSide unknown fix tag: [|84uy; 84uy|]" =! ex.Message



[<Fact>]
let ``read compound len+str pair`` () =
    let bs = [|  yield! "90=8"B; yield 1uy           // SecureDataLen, containing the length of the data in SecureData
                 yield! "91=ABCDEFGH"B; yield 1uy|]  // SecureData
    let pos, len = indexSingleField bs
    let fld = ReadSecureData bs pos len
    SecureData.SecureData (NonEmptyByteArray.Make"ABCDEFGH"B) =! fld


[<Fact>]
let ``read compound len+str pair, containing a field seperator in the string`` () =
    let valToRead = [|yield! "ABCD"B; yield 1uy; yield! "EFGH"B; |] // contains a field seperator
    
    let bs = [| yield! "90=9"B; yield 1uy                       // SecureDataLen, containing the length of the data in SecureData
                yield! "91="B;  yield! valToRead; yield 1uy |]  // SecureData
    let pos,len = indexSingleField bs
    let fld = ReadSecureData bs pos len
    SecureData.SecureData (NonEmptyByteArray.Make valToRead) =! fld


[<Fact>]
let ``read compound len+str pair, containing a tag-value seperator in the string`` () =
    let bs = [|  yield! "90=9"B; yield 1uy           // SecureDataLen, containing the length of the data in SecureData
                 yield! "91=ABCD=EFGH"B; yield 1uy|]  // SecureData
    let pos,len = indexSingleField bs
    let fld = ReadSecureData bs pos len
    SecureData.SecureData (NonEmptyByteArray.Make "ABCD=EFGH"B) =! fld



[<Fact>]
let ``read RawDataLength`` () = 
    let bs = [| yield! "95=6"B; yield 1uy            // raw data length
                yield! "96=aaaaaa"B; yield 1uy |]    // raw data 
    let pos, len = indexSingleField bs
    let fld = ReadRawData bs pos len
    RawData.RawData (NonEmptyByteArray.Make"aaaaaa"B) =! fld


[<Fact>]
let ``read RawDataLength + RawData pair, containing a field seperator in the string`` () = 
    let bs = [| yield! "95=7"B; yield 1uy            // raw data length
                yield! "96=aaa=aaa"B; yield 1uy |]    // raw data 
    let pos, len = indexSingleField bs
    let fld = ReadRawData bs pos len
    RawData.RawData (NonEmptyByteArray.Make "aaa=aaa"B) =! fld


[<Fact>]
let ``read RawDataLength + RawData pair, containing a tag-value seperator in the string`` () =
    let valToRead = [|yield! "ABCD"B; yield 1uy; yield! "EFGH"B; |] // contains a field seperator
    let bs = [|  yield! "95=9"B; yield 1uy                          // SecureDataLen, containing the length of the data in SecureData
                 yield! "96="B; yield! valToRead; yield 1uy |]      // SecureData
    let pos, len = indexSingleField bs
    let fld = ReadRawData bs pos len
    RawData.RawData (NonEmptyByteArray.Make valToRead) =! fld


// todo: put a single def of this function in a common location
let convFieldSep (bb:byte) = 
    match bb with
    | 124uy -> 1uy
    | n     -> n


[<Fact>]
let ``read newOrderMultileg bytes`` () =
    let buf = "8=FIX.4.4|9=1503|35=AB|34=99|49=senderCompID|52=20071123-05:30:00.000|56=targetCompID|11=PZXWQ|526=EFZDRSMQ|453=0|229=20170122|75=20170122|1=PKNOIWA|660=3|581=2|589=0|590=1|70=ZNOSMQBF|78=0|63=9|64=20170122|544=2|635=H|21=3|110=792281624589241053767102627.850000000000000|111=3.689348814312414|100=UYJN|386=0|81=0|54=F|55=RSWQE|65=WI|48=FJXY|22=D|454=0|461=WAUIJ|167=TIPS|762=JXYCWAL|200=201701w1|541=20170122|201=0|224=20170122|239=0|226=1|227=-5534023222112865484.700000000000000|228=79228162477.370849433239945|255=ESTXRVJK|543=YSWHLF|470=IMGKYZT|472=VZNO|240=20170122|202=79228162458924105376.710262785000000|947=CWKL|206=4|231=-3689348814312413.593900000000000|223=-792281.625142643375807|106=GHBFTU|348=4|349=xxxx|107=QUOJDHBP|350=4|351=yyyy|691=DRSWQEF|875=-2|876=UVZTX|864=0|873=20170122|874=20170122|140=-7922816249581759353.271930061100000|555=0|114=N|60=20170122-06:54:00|854=1|152=-0.000000003689349|516=-5534.023223401355674|468=1|469=792281.624958175935327|40=M|44=36.893488143124136|99=79228162477370849459009.748992000000000|15=USD|376=NHVWAUY|377=Y|23=ALPJNB|117=KOCDXBP|168=20170122-06:54:00|432=20170122|126=20170122-06:54:00|427=2|12=-79228.162495817593533|13=4|479=VZTHIMGU|497=N|529=7|582=4|121=Y|120=ZTXLMG|775=0|58=MGBVZT|354=4|355=zzzz|77=C|203=0|210=-792281.624773708494590|211=-79228162477370849.454714781696000|836=1|837=2|838=2|840=1|388=6|389=-79228162514264337580659048.449000000000000|841=1|842=0|843=0|844=1|846=1|847=-3|848=UOSMHBFZ|849=-55.340232221128655|480=N|481=1|513=EFJDHS|563=1|10=110|"B |> Array.map convFieldSep
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 2048
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr buf buf.Length
    let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)
    let _ = Fix44.MsgReaders.ReadNewOrderMultileg buf index 
    () // test passes so long as no exception is thrown
    





