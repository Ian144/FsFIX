module FIXGenTypes



type Required = Required | NotRequired
//    with override this.ToString () =
//                        match this with
//                        | Required -> "required"
//                        | NotRequired -> "not required"

type Field = { FName:string; Required:Required }
    with override this.ToString () = sprintf "%s (%O)" this.FName this.Required

type ComponentRef = { CRName:string; Required:Required }


// Items can contain groups containing Items
type FIXItem = Field of Field | Component of ComponentRef | Group of Group
//    with member this.ToString () = 
//                        match this with 
//                        | FIXItem.Field fld -> fld.ToString()
//                        | obj               -> obj.ToString()

and Group = { GName:string; Parents:string list; Required:Required; Items: FIXItem list}

type Msg = {MName:string; Type:string; Cat:string; Items: FIXItem list}

type Component = {CName:string; Items: FIXItem list}



// SubGroup and GroupGen are used when generating F# group code
type SubGroup = {CountFieldName:string; SubGroupName:string}
type Level1Group = {LGName:string; CountFieldName:string; Items: FIXItem list}