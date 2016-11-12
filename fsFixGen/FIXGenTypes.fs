module FIXGenTypes



type ComponentName = ComponentName of string
                                
type GroupLongName = GroupLongName of string

type Required = Required | NotRequired

type FieldDUCase = { Case:string; Description:string }

type SimpleField = { Tag:uint32; Name:string; Type:string; Values:FieldDUCase list }

type CompoundField = { Name:string; LenField:SimpleField; DataField:SimpleField }

type FieldData = SimpleField of SimpleField | CompoundField of CompoundField

// groups and components refer to fields in the fix xml spec, but the fields are defined elsewhere
type FieldRef = { FName:string; Required:Required }

// msgs refer to components in the fix xml spec, components is defined elsewhere, however groups are defined inline.
// ComponentRefs can be required or not required, whereas Components do not know if they are required or
// not when being defined in FIX xml, that is specified at the point of use
type ComponentRef = { CRName:ComponentName; Required:Required }


// A FIXItem can contain groups containing FIXItems, SO FIXITEMS ARE TREES
// ComponentRefs refer to a component by name, but do not contain Items directly, 
// Components are not defined inline, whereas groups are.
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