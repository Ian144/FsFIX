module Messages


open ParseData



let convMsgChunk (pds:ParseData list) =
    match pds with
    |   catPd::msgNamePd::memberPds   -> 
        let cat = getCategory catPd
        let name = getTypeName msgNamePd
        let members = memberPds |> List.map (fun msgPd ->
            let _, xx = getMember msgPd
            let isRequired = xx.Contains("option") |> not
            let subStrs = (xx.Split ' ')
            let typeName = subStrs.[0].Trim()
            if xx.Contains("// group") then
                Member.Group (typeName, isRequired)
            else if xx.Contains "// component" then
                Member.Component (typeName, isRequired)
            else
                Member.Field (typeName, isRequired)
        )
        { MsgName=name; MsgType="99"; Cat=cat; Members=members }
    |   _   -> failwith "failed to parse msg"
  

let isSameMsg = function | Category _   -> false | _-> true