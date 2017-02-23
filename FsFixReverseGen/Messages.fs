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
 
module Messages


open ParseData






let convMsgChunk (pds:ParseData list) =
    match pds with
    |   catPd::msgNamePd::memberPds   -> 
        let cat = getCategory catPd
        let name = getTypeName msgNamePd
        let members = memberPds |> List.map (fun msgPd ->
            let _, mbr = getMember msgPd
            let isRequired = mbr.Contains("option") |> not
            let subStrs = (mbr.Split ' ')
            let typeName = subStrs.[0].Trim()
            if mbr.Contains("// group") then
                Member.Group (typeName, isRequired)
            else if mbr.Contains "// component" then
                Member.Component (typeName, isRequired)
            else
                Member.Field (typeName, isRequired)
        )
        { MName=name; MType="99"; Cat=cat; Members=members }
    |   _   -> failwith "failed to parse msg"
  

let isSameMsg = function | Category _   -> false | _-> true