[<RequireQualifiedAccess>]
module GroupUtils

open FIXGenTypes




let extractGroups (itms:FIXItem list) : Group list =
    let extractGroup (itm:FIXItem) =
        match itm with 
        | FIXItem.Group grp -> Some grp
        | _                 -> None
    itms |> List.choose extractGroup



let extractLevel1GroupsFromComponents (cmps:Component list) = 
    [   for cmp in cmps do
        yield! cmp.Items |> extractGroups ]

    

let extractLevel1GroupsFromMsgs (msg:Msg list) = 
    [   for cmp in msg do
        yield! cmp.Items |> extractGroups ]



let rec flattenGroups (groups:Group list) = 
    [   for group in groups do
        let subGroups = group.Items |> extractGroups
        yield! flattenGroups subGroups 
        yield group ]


