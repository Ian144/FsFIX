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
 


module LocalMktDate

open FIXDateTime



type LocalMktDate = private LocalMktDate of Year:int * Month:int * Day:int 



let MakeLocalMktDate (yy:int, mm:int, dd:int) : LocalMktDate = 
    if validate_yyyyMMdd (yy, mm, dd) |> not then
        failwithf "invalid LocalMktDate, y:%d, m:%d, d:%d" yy mm dd
    LocalMktDate ( yy, mm, dd )




let writeLocalMktDate (dt:LocalMktDate) (bs:byte[]) (pos:int) : int =
    match dt with 
    | LocalMktDate (yyyy, mm, dd) ->    write4ByteInt bs pos yyyy
                                        write2ByteInt bs (pos + 4) mm
                                        write2ByteInt bs (pos + 6) dd
                                        pos + 8

let readLocalMktDate (bs:byte[]) (pos:int) (len:int) : LocalMktDate =
    let yyyy, mm, dd = readYYYYmmDDints bs pos
    MakeLocalMktDate (yyyy, mm, dd)                    