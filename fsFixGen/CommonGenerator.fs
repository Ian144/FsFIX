module CommonGenerator

open System.IO

open FIXGenTypes



// used for building the FIXItem definition string for messages, groups and components
let makeItemStr (item:FIXItem) = 
    match item with
    | FIXItem.Field fld     ->      match fld.Required with
                                    | Required.Required     ->  sprintf "    %s: %s" fld.FName fld.FName
                                    | Required.NotRequired  ->  sprintf "    %s: %s option" fld.FName fld.FName
    | FIXItem.ComponentRef cmp ->   let (ComponentName nm) = cmp.CRName
                                    match cmp.Required with
                                    | Required.Required     ->  sprintf "    %s: %s // component" nm nm 
                                    | Required.NotRequired  ->  sprintf "    %s: %s option // component" nm nm
    | FIXItem.Group grp     ->      let (GroupLongName grpNameInner) = GroupUtils.makeLongName grp
                                    let isLegsGroup = grpNameInner.Contains "NoLegs"
                                    match isLegsGroup, grp.Required with
                                    | false, Required.Required     ->  sprintf "    %sGrp: %sGrp list // group" grpNameInner grpNameInner
                                    | false, Required.NotRequired  ->  sprintf "    %sGrp: %sGrp list option // group" grpNameInner grpNameInner
                                    | true,  Required.Required     ->  sprintf "    %sGrp: %sGrp NonGenTypes.OneOrTwo // group" grpNameInner grpNameInner
                                    | true,  Required.NotRequired  ->  sprintf "    %sGrp: %sGrp NonGenTypes.OneOrTwo option // group" grpNameInner grpNameInner
    


let writeFIXItemList (sw : StreamWriter) (items : FIXItem list) = 
    items
    |> List.map makeItemStr
    |> List.iter sw.WriteLine






