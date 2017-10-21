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
 
module FIXGenTypes



type ComponentName = ComponentName of string
                                
type GroupLongName = GroupLongName of string

type Required = Required | NotRequired

type FieldDUCase = { Case:string; Description:string }

type SimpleField = { Tag:uint32; Name:string; Type:string; Values:FieldDUCase list }

// compound fields are length+data pairs
type CompoundField = { Name:string; LenField:SimpleField; DataField:SimpleField }

type Field = SimpleField of SimpleField | CompoundField of CompoundField

// groups and components refer to fields in the fix xml spec, but the fields are defined elsewhere
type FieldRef = { FName:string; Required:Required }

// msgs refer to components in the fix xml spec, components are defined elsewhere, however groups are defined inline.
// ComponentRefs can be required or not required, whereas Components do not know if they are required or not.
type ComponentRef = { CRName:ComponentName; Required:Required }


// A FIXItem can contain groups containing FIXItems, so FIXItems are trees.
// ComponentRefs refer to a component by name, but do not contain Items directly, 
// Components are not defined inline, groups are inline with their parent type.
type FIXItem = FieldRef of FieldRef | ComponentRef of ComponentRef | Group of Group
and Group = { GName:string; Parents:string list; Required:Required; Items: FIXItem list }


type Msg = {MName:string; Tag:string; Cat:string; Items: FIXItem list}


type Component = {CName:ComponentName; Items: FIXItem list}


// Groups can refer to Components, and Components can refer to Groups, need a type 
// that can hold either when generating groups and components in dependency order.
// FIXItem cannot do this as it holds a ComponentRef (which contains no dependency information, its just a name) not a Component
type CompoundItem = Component of Component | Group of Group


type Header = {HItems: FIXItem list}


type Trailer = {TItems: FIXItem list}