module FIXGenTypes



type ComponentName = ComponentName of string
    with member this.Value =    let (ComponentName vv) = this
                                vv
                                
type GroupLongName = GroupLongName of string



type Required = Required | NotRequired


type Field = { FName:string; Required:Required }
    with override this.ToString () = sprintf "%s (%O)" this.FName this.Required

// msgs refer to components, but the component is defined elsewhere, unlike groups which are defined inline
type ComponentRef = { CRName:ComponentName; Required:Required }


// A FIXItem can contain groups containing Items.
// ComponentRefs refer to a component by name, but do not contain Items directly, 
// Components are not defined inline in FIX XML, whereas groups are inline.
type FIXItem = Field of Field | Component of ComponentRef | Group of Group


and Group = { GName:string; Parents:string list; Required:Required; Items: FIXItem list }

type Msg = {MName:string; Type:string; Cat:string; Items: FIXItem list}

type Component = {CName:ComponentName; Items: FIXItem list}


// Groups can refer to Components, and Components can refer to Group
// need a type that can hold either when generating them in dependency order
type CompoundItem = Component of Component | Group of Group


