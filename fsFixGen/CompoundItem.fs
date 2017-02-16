[<RequireQualifiedAccess>]
module CompoundItem

open FIXGenTypes




let private extractCompoundItems (componentNameMap:Map<ComponentName,Component>) (itms:FIXItem list) : CompoundItem list =
    let extract (itm:FIXItem) : CompoundItem option =
        match itm with 
        | FIXItem.Group     group       ->  Some (CompoundItem.Group group)
        | FIXItem.ComponentRef cmpRef  ->   let componentName = cmpRef.CRName 
                                            let comp = componentNameMap.[componentName] 
                                            Some (CompoundItem.Component comp)
        | FIXItem.FieldRef _               ->  None
    itms |> List.choose extract 



let getSubCompoundItems (componentNameMap:Map<ComponentName,Component>) (ci:CompoundItem) : CompoundItem list = 
    match ci with
    | CompoundItem.Component cmp    -> cmp.Items |> (extractCompoundItems componentNameMap)
    | CompoundItem.Group grp        -> grp.Items |> (extractCompoundItems componentNameMap)



let rec private flattenCompoundItems (componentNameMap:Map<ComponentName,Component>) (compoundItems:CompoundItem list) : CompoundItem list  = 
    [   for ci in compoundItems do
        let subItems = getSubCompoundItems componentNameMap ci
        let subSubItems = flattenCompoundItems componentNameMap subItems
        yield! subSubItems
        yield! subItems
        yield ci ]



// compound items are either groups or components, both of which may contain nested components and groups (nested to an arbitrary degree) 
let recursivelyGetAllCompoundItems (componentNameMap:Map<ComponentName,Component>) (itms:FIXItem list) : CompoundItem list =
    let level0CompoundItems = extractCompoundItems componentNameMap itms
    flattenCompoundItems componentNameMap level0CompoundItems



let getName (ci:CompoundItem) =
    match ci with
    | CompoundItem.Component cmp    ->  let (ComponentName nm) = cmp.CName
                                        nm
    | CompoundItem.Group grp        ->  let (GroupLongName ln) = Group.makeLongName grp
                                        ln

// a string suffixed onto names in generated code
let getNameSuffix (ci:CompoundItem) =
    match ci with
    | CompoundItem.Component cmp    ->  ""
    | CompoundItem.Group grp        ->  "Grp"


// a string suffixed onto names in generated code
let getItems (ci:CompoundItem) =
    match ci with
    | CompoundItem.Component cmp    ->  cmp.Items
    | CompoundItem.Group grp        ->  grp.Items


let getNameAndTypeStr (ci:CompoundItem) =
    match ci with
    | CompoundItem.Component cmp    ->  let (ComponentName nm) = cmp.CName
                                        sprintf "component: %s" nm
    | CompoundItem.Group grp        ->  let (GroupLongName ln) = Group.makeLongName grp
                                        sprintf "    group: %s" ln    

let getCompOrGroupStr (ci:CompoundItem) =
    match ci with
    | CompoundItem.Component _  ->  "component"
    | CompoundItem.Group _      ->  "group"


let extractGroups (cis:CompoundItem list) : Group list =
    let extractGroup ci =
        match ci with
        | CompoundItem.Group grp    -> Some grp
        | CompoundItem.Component _  -> None
    cis |> List.choose extractGroup



let extractComponents (cis:CompoundItem list) : Component list =
    let extract ci =
        match ci with
        | CompoundItem.Group _          -> None
        | CompoundItem.Component cmp    -> Some cmp
    cis |> List.choose extract




let GenFactoryFuncs (typeName:string) (typeMembers:FIXItem list) (sw:System.IO.StreamWriter) =

    let getParamType (fi:FIXItem) =
        match fi with
        | FIXItem.FieldRef fld      ->  fld.FName
        | FIXItem.ComponentRef cmp  ->  let (ComponentName nm) = cmp.CRName
                                        nm
        | FIXItem.Group grp         ->  let (GroupLongName nm) = Group.makeLongName grp
                                        match nm.Contains("NoSides") with
                                        | true  -> sprintf "%sGrp OneOrTwo" nm
                                        | false -> sprintf "%sGrp list" nm

    sw.WriteLine ""
    sw.WriteLine ""

    // required items are factory func parameters
    let requiredItems = typeMembers |> List.filter FIXItem.getIsRequired
    let parameterStrs = requiredItems |> List.map (fun prm -> 
            let prmName = FIXItem.getNameLN prm |> StringEx.lCaseFirstChar
            let prmType = getParamType prm 
            sprintf "%s:%s" prmName prmType )
    let parameterStr = parameterStrs |> StringEx.join ", "
    
    let funcSigElements =  [ 
                yield   (sprintf "let Mk%s (" typeName)
                yield   parameterStr
                yield   (sprintf ") : %s = {" typeName)  
            ]

    let funcSig = funcSigElements |> StringEx.join ""
    sw.WriteLine funcSig

    let memberInitStrs = typeMembers |> List.map (fun mbr ->
            let mbrName = FIXItem.getNameLN mbr
            let isRequired = FIXItem.getIsRequired mbr
            match isRequired with
            | true  ->  sprintf "    %s = %s"   mbrName (mbrName |> StringEx.lCaseFirstChar)
            | false ->  sprintf "    %s = None" mbrName
        )

    memberInitStrs |> List.iter sw.WriteLine

    sw.WriteLine "  }"

    ()
    
    
