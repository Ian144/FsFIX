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
 
module NonEmptyByteArray





// why have a private ctor and still allow access to the wrapped data via the value member? 
// if the ctor was not private it would allow the creation of empty NonEmptyArrays, arrays may be mutable but these will definately not be empty

type NonEmptyByteArray = private NonEmptyByteArray of byte array
                                    member x.Value = let (NonEmptyByteArray v) = x in v

let Make (bs:byte array) =
    if bs.Length > 0 then
        NonEmptyByteArray bs
    else
        failwith "NonEmptyArray.Make given empty array"

