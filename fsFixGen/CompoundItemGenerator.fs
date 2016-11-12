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


let private getGroupComment (cmpNameMap:Map<ComponentName,Component>) (grp:Group) = 
    let itm = grp.Items.Head
    match itm with
    | FIXItem.ComponentRef cr   ->  let cmp = cmpNameMap.[cr.CRName] 
                                    let fstInnerItem = cmp.Items.Head
                                    match cr.Required,  FIXItem.getIsRequired fstInnerItem with
                                    | Required, true        -> "// group"
                                    | Required, false       -> "// group 1st ############# component: required, first: notRequired"
                                    | NotRequired, true     -> "// group"// 1st ############# component: notRequired, first: required"
                                    | NotRequired, false    -> "// group ############# component: notRequired, first: notRequired"
    | FIXItem.FieldRef  fr      ->  match fr.Required with
                                    | Required.Required     -> "// group"
                                    | Required.NotRequired  -> "// group ############# first field not required"
    | FIXItem.Group     gg      ->  let hd = gg.Items.Head
                                    match FIXItem.getIsRequired hd with
                                    | true  -> "// group"
                                    | false -> "// group 1st is group @@@@@@@@@@@ first item is not required"


let private writeGroup (cmpNameMap:Map<ComponentName,Component>) (grp:Group) (sw:StreamWriter) = 
    sw.WriteLine ""
    let comment = getGroupComment cmpNameMap grp
    sw.WriteLine comment
    let (GroupLongName grpName) = GroupUtils.makeLongName grp // merged groups have an empty parent list, so the long name is correct
    let ss = sprintf "type %sGrp = {" grpName
    sw.WriteLine ss
    grp.Items |> (CommonGenerator.writeFIXItemList sw)
    sw.Write  "    }"
    sw.WriteLine ""



let Gen (cmpNameMap:Map<ComponentName,Component>) (cmpItems:CompoundItem list) (swCompItms:StreamWriter) (swCompItemDU:StreamWriter) =
    swCompItms.WriteLine "module Fix44.CompoundItems"
    swCompItms.WriteLine ""
    swCompItms.WriteLine "open Fix44.Fields"
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""
    cmpItems |> List.iter (fun ci ->
                    match ci with
                    | CompoundItem.Group    grp     -> writeGroup cmpNameMap grp swCompItms
                    | CompoundItem.Component comp   -> writeComponent comp swCompItms    )
    swCompItms.WriteLine ""
    swCompItms.WriteLine ""
    
    // write the 'group/component' DU
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





let private genCompoundItemWriter (sw:StreamWriter) (ci:CompoundItem) =
    let name = CompoundItemFuncs.getName ci
    let suffix = CompoundItemFuncs.getNameSuffix ci
    let compOrGroup = CompoundItemFuncs.getCompOrGroupStr ci
    let items = CompoundItemFuncs.getItems ci
    sw.WriteLine (sprintf "// %s" compOrGroup)
    let funcSig = sprintf "let Write%s%s (dest:byte []) (nextFreeIdx:int) (xx:%s%s) =" name suffix name suffix
    sw.WriteLine funcSig
    let writeGroupFuncStrs = CommonGenerator.genItemListWriterStrs items
    writeGroupFuncStrs |> List.iter sw.WriteLine
    sw.WriteLine "    nextFreeIdx"
    sw.WriteLine ""
    sw.WriteLine ""
   


let GenWriteFuncs (groups:CompoundItem list) (sw:StreamWriter) =
    sw.WriteLine "module Fix44.CompoundItemWriteFuncs"
    sw.WriteLine ""
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.FieldWriteFuncs"
    sw.WriteLine "open Fix44.CompoundItems"
    sw.WriteLine ""
    sw.WriteLine ""
    groups |> List.iter (genCompoundItemWriter sw)  


let private genFieldInitStrs (items:FIXItem list) =
    items |> List.map (fun fi -> 
        let fieldName = fi |> FIXItem.getNameLN
        let varName = fieldName |> Utils.lCaseFirstChar |> CommonGenerator.fixYield
        sprintf "        %s = %s" fieldName varName )



let private genCompoundItemReader (fieldNameMap:Map<string,SimpleField>) (sw:StreamWriter) (ci:CompoundItem) = 
    let name = CompoundItemFuncs.getName ci
    let suffix = CompoundItemFuncs.getNameSuffix ci
    let typeName = sprintf "%s%s" name suffix
    let compOrGroup = CompoundItemFuncs.getCompOrGroupStr ci
    let items = CompoundItemFuncs.getItems ci
    sw.WriteLine (sprintf "// %s" compOrGroup)
    let funcSig = sprintf "let Read%s (pos:int) (bs:byte []) : int * %s  =" typeName typeName
    sw.WriteLine funcSig
    let readFIXItemStrs = CommonGenerator.genItemListReaderStrs fieldNameMap name items
    readFIXItemStrs |> List.iter sw.WriteLine
    let fieldInitStrs = genFieldInitStrs items
    sw.WriteLine (sprintf "    let ci:%s = {" typeName)
    fieldInitStrs |> List.iter sw.WriteLine
    sw.WriteLine "    }"
    sw.WriteLine "    pos, ci"
//    sw.WriteLine "    failwith \"not implemented\""
    sw.WriteLine ""
    sw.WriteLine ""


let GenReadFuncs (fieldNameMap:Map<string,SimpleField>) (groups:CompoundItem list) (sw:StreamWriter) =
    sw.WriteLine "module Fix44.CompoundItemReadFuncs"
    sw.WriteLine ""
    sw.WriteLine "open ReaderUtils"
    sw.WriteLine "open Fix44.Fields"
    sw.WriteLine "open Fix44.FieldReadFuncs"
    sw.WriteLine "open Fix44.CompoundItems"
    sw.WriteLine ""
    sw.WriteLine ""
    groups |> List.iter (genCompoundItemReader fieldNameMap sw)  

