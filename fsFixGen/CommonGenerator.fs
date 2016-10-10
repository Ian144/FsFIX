module CommonGenerator

open System.IO

open FIXGenTypes



// used for building the FIXItem definition string for messages, groups and components
let makeItemStr (item:FIXItem) = 
    match item with
    | FIXItem.Field fld     ->  match fld.Required with
                                | Required.Required     ->  sprintf "    %s: %s" fld.FName fld.FName
                                | Required.NotRequired  ->  sprintf "    %s: %s option" fld.FName fld.FName
    | FIXItem.Component cmp ->  let (ComponentName nm) = cmp.CRName
                                match cmp.Required with
                                | Required.Required     ->  sprintf "    %s: %s // component" nm nm 
                                | Required.NotRequired  ->  sprintf "    %s: %s option // component" nm nm
    | FIXItem.Group grp     ->  let (GroupLongName grpNameInner) = GroupUtils.makeLongName grp
                                match grp.Required with
                                | Required.Required     ->  sprintf "    %sGrp: %sGrp // group" grpNameInner grpNameInner
                                | Required.NotRequired  ->  sprintf "    %sGrp: %sGrp option // group" grpNameInner grpNameInner
    


let writeFIXItemList (sw : StreamWriter) (items : FIXItem list) = 
    items
    |> List.map makeItemStr
    |> List.iter sw.WriteLine






