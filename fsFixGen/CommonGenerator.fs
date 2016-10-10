module CommonGenerator

open System.IO

open FIXGenTypes



let makeItemStr (item:FIXItem) = 
    match item with
    | FIXItem.Field fld     ->  match fld.Required with
                                | Required.Required     ->  sprintf "    %s: %s" fld.FName fld.FName
                                | Required.NotRequired  ->  sprintf "    %s: %s option" fld.FName fld.FName
    | FIXItem.Component cmp ->  match cmp.Required with
                                | Required.Required     ->  sprintf "    %s: %s // component" cmp.CRName.Value cmp.CRName.Value
                                | Required.NotRequired  ->  sprintf "    %s: %s option // component" cmp.CRName.Value cmp.CRName.Value
    | FIXItem.Group grp     ->  let (GroupLongName grpNameInner) = GroupUtils.makeLongName grp
                                match grp.Required with
                                | Required.Required     ->  sprintf "    %sGrp: %sGrp // group" grpNameInner grpNameInner
                                | Required.NotRequired  ->  sprintf "    %sGrp: %sGrp option // group" grpNameInner grpNameInner
    


let writeFIXItemList (sw:StreamWriter) (items:FIXItem list)  = 
    let itemStrs = items|> List.map makeItemStr
    itemStrs |> List.iter sw.WriteLine





