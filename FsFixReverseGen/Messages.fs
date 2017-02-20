module Messages


open ParseData






let convMsgChunk (pds:ParseData list) =
    match pds with
    |   catPd::msgNamePd::memberPds   -> 
        let cat = getCategory catPd
        let name = getTypeName msgNamePd
        let members = memberPds |> List.map (fun msgPd ->
            let _, mbr = getMember msgPd
            let isRequired = mbr.Contains("option") |> not
            let subStrs = (mbr.Split ' ')
            let typeName = subStrs.[0].Trim()
            if mbr.Contains("// group") then
                Member.Group (typeName, isRequired)
            else if mbr.Contains "// component" then
                Member.Component (typeName, isRequired)
            else
                Member.Field (typeName, isRequired)
        )
        { MName=name; MType="99"; Cat=cat; Members=members }
    |   _   -> failwith "failed to parse msg"
  

let isSameMsg = function | Category _   -> false | _-> true