module FIXGenTypes



type ComponentName = ComponentName of string


                                
type GroupLongName = GroupLongName of string



type Required = Required | NotRequired



type Field = { FName:string; Required:Required }



// msgs refer to components, but the component is defined elsewhere, unlike groups which are defined inline.
// ComponentRefs can be required or not required, whereas Components do not know whether they will  be required 
// or not when being defined in FIX xml, that is specified at the point of use
type ComponentRef = { CRName:ComponentName; Required:Required }



// A FIXItem can contain groups containing FIXItems, SO FIXITEMS ARE TREES
// ComponentRefs refer to a component by name, but do not contain Items directly, 
// Components are not defined inline in FIX XML, whereas groups are.
type FIXItem = Field of Field | Component of ComponentRef | Group of Group
and Group = { GName:string; Parents:string list; Required:Required; Items: FIXItem list }



type Msg = {MName:string; Type:string; Cat:string; Items: FIXItem list}



type Component = {CName:ComponentName; Items: FIXItem list}



// Groups can refer to Components, and Components can refer to Group, need a type 
// that can hold either when generating groups and components in dependency order.
// FIXItem cannot do this as it holds a component ref
type CompoundItem = Component of Component | Group of Group


