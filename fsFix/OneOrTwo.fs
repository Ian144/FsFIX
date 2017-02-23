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
 
module OneOrTwo


// the NoLegs group has either 1 or 2 elements, 
// enforce at compile time with this container

type OneOrTwo<'a> =
    | One of 'a 
    | Two of 'a * 'a



let iter func oneTwo  : Unit = 
    match oneTwo with
    | One t1        -> func t1
    | Two (t1,t2)   -> func t1; func t2



let fold (func:'state -> 't -> 'state) (stateIn:'state) oneTwo  : 'state = 
    match oneTwo with
    | One t1        -> func stateIn t1
    | Two (t1,t2)   -> let stateTmp = func stateIn t1
                       func stateTmp t2


