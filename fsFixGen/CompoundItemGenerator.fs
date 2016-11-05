module CompoundItemGenerator

open System.IO
open FIXGenTypes



let private writeComponent (cmp:Component) (sw:StreamWriter) = 
    sw.WriteLine ""
    sw.WriteLine "// component"
    let (ComponentName name) = cmp.CName
    let ss = sprintf "type %s = {"  name// different from write group
    sw.Write ss
    sw.WriteLine ""
    cmp.Items |> (CommonGenerator.writeFIXItemList sw)
    sw.Write  "    }"
    sw.WriteLine ""


// todo: consider a static class + overloading, dictionary of operations or ^t + member constraints to write a single type generator function for components, groups and messages
let private writeGroup (grp:Group) (sw:StreamWriter) = 
    sw.WriteLine ""
    sw.WriteLine "// group"
    let (GroupLongName grpName) = GroupUtils.makeLongName grp // merged groups have an empty parent list, so the long name is correct
    let ss = sprintf "type %sGrp = {" grpName
    sw.Write ss
    sw.WriteLine ""
    grp.Items |> (CommonGenerator.writeFIXItemList sw)
    sw.Write  "    }"
    sw.WriteLine ""


let Gen (cmpItems:CompoundItem list) (swCompItms:StreamWriter) (swCompItemDU:StreamWriter) =
    swCompItms.WriteLine "module Fix44.CompoundItems"
    swCompItms.WriteLine ""
    swCompItms.WriteLine "open Fix44.Fields"
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""
    cmpItems |> List.iter (fun ci ->
                    match ci with
                    | CompoundItem.Group    grp     -> writeGroup grp swCompItms
                    | CompoundItem.Component comp   -> writeComponent comp swCompItms    )
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""

    // write the 'group' DU
    swCompItemDU.WriteLine "module Fix44.CompoundItemDU"
    swCompItemDU.WriteLine ""
    swCompItemDU.WriteLine "open Fix44.CompoundItems"
    swCompItemDU.WriteLine ""
    swCompItemDU.WriteLine ""
    swCompItemDU.WriteLine ""

    let groups = cmpItems |> CompoundItemFuncs.extractGroups
    swCompItemDU.WriteLine  "type FIXGroup ="
    groups 
    |> List.map GroupUtils.makeLongName
    |> List.sort 
    |> List.iter (fun grpLngName ->
            let (GroupLongName strName) = grpLngName
            let ss  = sprintf "    | %sGrp of %sGrp" strName strName
            swCompItemDU.WriteLine ss  )
    swCompItemDU.WriteLine ""
    swCompItemDU.WriteLine ""
    swCompItemDU.WriteLine ""



let private genGroupWriter (sw:StreamWriter) (grp:Group) =
    sw.WriteLine "// group"
    let (GroupLongName grpName) = GroupUtils.makeLongName grp
    let funcSig = sprintf "let Write%sGrp (dest:byte []) (nextFreeIdx:int) (xx:%sGrp) =" grpName grpName
    sw.WriteLine funcSig
    let writeGroupFuncStrs = CommonGenerator.genItemListWriterStrs grp.Items
    writeGroupFuncStrs |> List.iter sw.WriteLine
    sw.WriteLine "    nextFreeIdx"
    sw.WriteLine ""
    sw.WriteLine ""



let private genComponentWriter (sw:StreamWriter) (cmp:Component) =
    sw.WriteLine "// component"
    let (ComponentName name) = cmp.CName
    let funcSig = sprintf "let Write%s (dest:byte []) (nextFreeIdx:int) (xx:%s) =" name name
    sw.WriteLine funcSig
    let writeGroupFuncStrs = CommonGenerator.genItemListWriterStrs cmp.Items
    writeGroupFuncStrs |> List.iter sw.WriteLine
    sw.WriteLine "    nextFreeIdx"
    sw.WriteLine ""
    sw.WriteLine ""


let private genCompoundItemWriter (sw:StreamWriter) (ci:CompoundItem) =
    match ci with
    | CompoundItem.Group grp        -> genGroupWriter sw grp
    | CompoundItem.Component cmp    -> genComponentWriter sw cmp
    


let GenWriteFuncs (groups:CompoundItem list) (sw:StreamWriter) =
    sw.WriteLine "module Fix44.CompoundItemWriteFuncs"
    sw.WriteLine ""
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.FieldWriteFuncs"
    sw.WriteLine "open Fix44.CompoundItems"
    sw.WriteLine ""
    sw.WriteLine ""
    groups |> List.iter (genCompoundItemWriter sw)  



let private genCompoundItemReader (fieldNameMap:Map<string,SimpleField>) (sw:StreamWriter) (ci:CompoundItem) = 
    let name = CompoundItemFuncs.getName ci
    let suffix = CompoundItemFuncs.getNameSuffix ci
    let compOrGroup = CompoundItemFuncs.getCompOrGroupStr ci
    let items = CompoundItemFuncs.getItems ci
    sw.WriteLine (sprintf "// %s" compOrGroup)
    let funcSig = sprintf "let Read%s%s (pos:int) (bs:byte []) : int * %s%s  =" name suffix name suffix
    sw.WriteLine funcSig
    let writeGroupFuncStrs = CommonGenerator.genItemListReaderStrs fieldNameMap name items
    writeGroupFuncStrs |> List.iter sw.WriteLine
    //todo: apply the fields, subgroups and subcomponents that have been read to create the instance
    sw.WriteLine "    failwith \"not implemented\""
    sw.WriteLine ""


let GenReadFuncs (fieldNameMap:Map<string,SimpleField>) (groups:CompoundItem list) (sw:StreamWriter) =
    sw.WriteLine "module Fix44.CompoundItemReadFuncs"
    sw.WriteLine ""
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.FieldReadFuncs"
    sw.WriteLine "open Fix44.CompoundItems"
    sw.WriteLine ""
    sw.WriteLine ""
    groups |> List.iter (genCompoundItemReader fieldNameMap sw)  

