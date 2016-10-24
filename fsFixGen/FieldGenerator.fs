//[<RequireQualifiedAccess>]
module FieldGenerator


open System
open System.IO
open System.Xml.Linq
open System.Xml.XPath

open ParsingFuncs





type FieldDUCase = { Enum:string; Description:string }
type SimpleField = { FixTag:int; Name:string; Type:string; Values:FieldDUCase list }
type CompoundField = { Name:string; LenField:SimpleField; StrField:SimpleField }
type FieldData = SimpleField of SimpleField | CompoundField of CompoundField



//let WriteAdvSide (nextFreeIdx:int) (dest:byte []) (xxIn:AdvSide) : int =
//    match xxIn with
//    | AdvSide.Buy ->
//        let tag = "4=B"B
//        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
//        let nextFreeIdx2 = nextFreeIdx + tag.Length
//        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
//        nextFreeIdx2 + 1 // +1 to include the delimeter
//    | AdvSide.Sell ->
//        let tag = "4=S"B
//        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
//        let nextFreeIdx2 = nextFreeIdx + tag.Length
//        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
//        nextFreeIdx2 + 1 // +1 to include the delimeter
//    | AdvSide.Cross ->
//        let tag = "4=X"B
//        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
//        let nextFreeIdx2 = nextFreeIdx + tag.Length
//        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
//        nextFreeIdx2 + 1 // +1 to include the delimeter
//    | AdvSide.Trade ->
//        let tag = "4=T"B
//        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
//        let nextFreeIdx2 = nextFreeIdx + tag.Length
//        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
//        nextFreeIdx2 + 1 // +1 to include the delimeter

let private createFieldDUWriterFunc (fldName:string) (fixTag:int) (values:FieldDUCase list) = 
    let lines = [
        yield (sprintf "let Write%s (dest:byte array) (nextFreeIdx:int) (xxIn:%s) : int =" fldName fldName)
        yield (sprintf "    match xxIn with")
        for vv in values do
        yield (sprintf "    | %s.%s ->"  fldName vv.Description)
        yield (sprintf "        let tag = \"%d=%s\"B"  fixTag  vv.Enum)
        yield (sprintf "        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)")
        yield (sprintf "        let nextFreeIdx2 = nextFreeIdx + tag.Length")
        yield (sprintf "        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter")
        yield (sprintf "        nextFreeIdx2 + 1 // +1 to include the delimeter")
    ]
    lines  |> Utils.joinStrs "\n"



let private createFieldDUWithValues (typeName:string) (fixTag:int) (values:FieldDUCase list) =
    let typeStr = sprintf "type %s =" typeName
    let caseStr = values |> List.map (fun vv -> sprintf "    | %s" vv.Description) |> Utils.joinStrs "\n"
    let typeStr = sprintf "%s\n%s" typeStr caseStr

    let readerFuncBeg = sprintf "let Read%s (fldValIn:string) : %s = \n    match fldValIn with" typeName typeName
    let readerFuncMatchLines = values |> List.map (fun vv -> sprintf "    |\"%s\" -> %s.%s" vv.Enum typeName vv.Description )
    let readerFuncErrMsg = sprintf "Read%s unknown fix tag:" typeName
    let readerFuncFailureCase =
            "    | x -> failwith (sprintf \"" +
            readerFuncErrMsg +
            """ %A"  x) """
    let readerFunc = seq{ yield readerFuncBeg; yield! readerFuncMatchLines; yield readerFuncFailureCase } |> Utils.joinStrs "\n"
    let writerFunc = createFieldDUWriterFunc typeName fixTag values
    typeStr, readerFunc, writerFunc




let private correctDUCaseNames (strIn:string) =
    let upperCaseFirst (s:string) =
        let ff = Char.ToUpper(s.[0])
        sprintf "%c%s" ff (s.Substring(1))
    strIn.Split('_')
    |> Array.map (fun ss -> ss.ToLower() |> upperCaseFirst)
    |> Utils.joinStrs ""



// f# cases cannot begin with a number
let private prefixNumericCaseNames (ss:string) =
    match Char.IsDigit(ss.[0]) with
    //| true  -> sprintf "``%s``" ss
    | true  -> sprintf "C%s" ss
    | false -> ss




let private correctNone (ss:string) =
    match ss with
    | "None"    -> "NNone"
    | _         -> ss




let private correctDUNames = correctDUCaseNames >> prefixNumericCaseNames >> correctNone




let private getParseFuncString (typeName:string) =
    match typeName with
    | "int"     -> "System.Int32.Parse"
    | "decimal" -> "System.Decimal.Parse"
    | "bool"    -> "System.Boolean.Parse"
    | "string"  -> ""
    | _         -> failwith "unknown type name"


//let WriteAccount (nextFreeIdx:int) (dest:byte []) (valIn:Account) : int =
//   let tag = "1="B
//   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
//   let nextFreeIdx2 = nextFreeIdx + tag.Length
//   let bs = ToBytes.Convert(valIn.Value)
//   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
//   dest.[nextFreeIdx2] <- 1uy // write the SOH delimeter
//   nextFreeIdx2 + bs.Length + 1 // +1 to include the delimeter

let private makeSingleCaseDUWriterFunc (typeName:string) (fixTag:int) =
    let lines = 
            [
                sprintf "let Write%s (dest:byte []) (nextFreeIdx:int) (valIn:%s) : int = " typeName typeName
                sprintf "   let tag = \"%d=\"B" fixTag
                sprintf "   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)"
                sprintf "   let nextFreeIdx2 = nextFreeIdx + tag.Length"
                sprintf "   let bs = ToBytes.Convert(valIn.Value)"
                sprintf "   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)"
                sprintf "   let nextFreeIdx3 = nextFreeIdx2 + bs.Length"
                sprintf "   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter"
                sprintf "   nextFreeIdx3 + 1 // +1 to include the delimeter"
            ]
    Utils.joinStrs "\n" lines


let private makeSingleCaseDU (typeName:string) (fixTag:int) (fsharpInnerType:string) =
    let typeStr = sprintf "type %s =\n    |%s of %s\n     member x.Value = let (%s v) = x in v" typeName typeName fsharpInnerType typeName
    let readerFunc = sprintf "let Read%s valIn =\n    let tmp = %s valIn\n    %s.%s tmp" typeName (getParseFuncString fsharpInnerType) typeName typeName
    let writerFunc = makeSingleCaseDUWriterFunc typeName fixTag
    typeStr, readerFunc, writerFunc




let private createFieldTypes (fd2:SimpleField) =
    let fieldType = fd2.Type
    let typeName = fd2.Name
    let fixNumber = fd2.FixTag
    let values = fd2.Values
    match fieldType, (Seq.isEmpty values) with
    | "AMT",                    true    -> makeSingleCaseDU typeName fixNumber "int"
    | "BOOLEAN",                true    -> makeSingleCaseDU typeName fixNumber "bool"
    | "CHAR",                   true    -> makeSingleCaseDU typeName fixNumber "int"
    | "COUNTRY",                true    -> makeSingleCaseDU typeName fixNumber "string"
    | "CURRENCY",               true    -> makeSingleCaseDU typeName fixNumber "string"
    | "DATA",                   true    -> makeSingleCaseDU typeName fixNumber "string"
    | "DAYOFMONTH",             true    -> makeSingleCaseDU typeName fixNumber "int"
    | "EXCHANGE",               true    -> makeSingleCaseDU typeName fixNumber "string"
    | "FLOAT",                  true    -> makeSingleCaseDU typeName fixNumber "decimal"
    | "INT",                    true    -> makeSingleCaseDU typeName fixNumber "int"
    | "LANGUAGE",               true    -> makeSingleCaseDU typeName fixNumber "string"
    | "LENGTH",                 true    -> makeSingleCaseDU typeName fixNumber "int"
    | "LOCALMKTDATE",           true    -> makeSingleCaseDU typeName fixNumber "string" // todo: storing LOCALMKTDATE as string, use appropriate type
    | "MONTHYEAR",              true    -> makeSingleCaseDU typeName fixNumber "string" // todo: storing MONTHYEAR as string, use appropriate type
    | "MULTIPLECHARVALUE",      true    -> makeSingleCaseDU typeName fixNumber "string"
    | "NUMINGROUP",             true    -> makeSingleCaseDU typeName fixNumber "int"
    | "PERCENTAGE",             true    -> makeSingleCaseDU typeName fixNumber "decimal"
    | "PRICE",                  true    -> makeSingleCaseDU typeName fixNumber "decimal"
    | "PRICEOFFSET",            true    -> makeSingleCaseDU typeName fixNumber "decimal"
    | "QTY",                    true    -> makeSingleCaseDU typeName fixNumber "decimal"
    | "SEQNUM",                 true    -> makeSingleCaseDU typeName fixNumber "int"
    | "STRING",                 true    -> makeSingleCaseDU typeName fixNumber "string"
    | "TZTIMEONLY",             true    -> makeSingleCaseDU typeName fixNumber "string" // todo: storing TZTIMESTAMP as string, use appropriate type
    | "TZTIMESTAMP",            true    -> makeSingleCaseDU typeName fixNumber "string" // todo: storing TZTIMESTAMP as string, use appropriate type
    | "UTCDATEONLY",            true    -> makeSingleCaseDU typeName fixNumber "string" // todo: storing UTCDATEONLY as string, use appropriate type
    | "UTCTIMEONLY",            true    -> makeSingleCaseDU typeName fixNumber "string" // todo: storing UTCTIMEONLY as string, use appropriate type
    | "UTCTIMESTAMP",           true    -> makeSingleCaseDU typeName fixNumber "string" // todo: storing UTCTIMESTAMP as string, use appropriate type
    | "XMLDATA",                true    -> makeSingleCaseDU typeName fixNumber "string"
    | "INT",                    false   -> createFieldDUWithValues typeName fixNumber values //todo: INT, CHAR, BOOLEAN etc currently sent and recieved as strings for multicase variants with a value, is this correct
    | "CHAR",                   false   -> createFieldDUWithValues typeName fixNumber values
    | "BOOLEAN",                false   -> createFieldDUWithValues typeName fixNumber values
    | "STRING",                 false   -> createFieldDUWithValues typeName fixNumber values
    | "MULTIPLECHARVALUE",      false   -> createFieldDUWithValues typeName fixNumber values    // required for 5.0sp2
    | "MULTIPLESTRINGVALUE",    false   -> createFieldDUWithValues typeName fixNumber values
    | "MULTIPLEVALUESTRING",    false   -> createFieldDUWithValues typeName fixNumber values    // required for 4.4
    | "NUMINGROUP",             false   -> createFieldDUWithValues typeName fixNumber values
    | _                                 -> let msg = sprintf "NOT IMPLEMENTED %s - %s" typeName fieldType
                                           failwith msg



// merge len fields and the corresponding string fields into a CmpdField, other fields are in a SngleField
let MergeLenFields (fds:SimpleField list) =
    let isLenFieldName (fn:string) =  System.Text.RegularExpressions.Regex.IsMatch(fn, ".*Len\z" )
    let stripLen (fn:string) = fn.Substring (0, (fn.Length - 3) )
    let nameToFieldMap = fds |> List.map (fun fd -> fd.Name, fd) |> Map.ofList

    let lenFields = fds |> List.filter (fun fd -> isLenFieldName fd.Name)

    // find those string fields which have a corresponding len field
    let stringFieldsWithLen =
        [   for fld in lenFields do
            let fn = stripLen fld.Name
            yield nameToFieldMap.[fn]   ]


    let lenFieldSet = lenFields |> List.map (fun fld -> fld.Name) |> Set.ofList               // used in group and msg generation to filter out 'Len' fields
    let stringFieldSet = stringFieldsWithLen |> Set.ofList

    let mergedFields =
        [   for fld in fds do
            let fldName = fld.Name
            let isNotLenFld = lenFieldSet |> Set.contains fldName |> not
            if isNotLenFld then
                let isStrFld = stringFieldSet |> Set.contains fld
                if isStrFld then
                    let lenFldName = sprintf "%sLen" fld.Name
                    let lenFld = nameToFieldMap.[lenFldName]
                    yield FieldData.CompoundField {Name=fld.Name; LenField = lenFld; StrField = fld}
                else
                    yield FieldData.SimpleField fld
            ]

    lenFieldSet, mergedFields




let ParseFieldData2 (parentXL:XElement) : SimpleField list =
    let fieldsXL = parentXL.XPathSelectElements "field"
    [   for fieldXL in fieldsXL do
        let fldNumber = gas fieldXL "number" |> System.Convert.ToInt32
        let name = gas fieldXL "name"
        let fldName = name.Trim()
        let fldType = gas fieldXL "type"
        let valuesXLs = fieldXL.XPathSelectElements "value"
        let values =
            [   for valueXL in valuesXLs do
                let desc = gas valueXL "description"
                let eenum = gas valueXL "enum"
                let duName = correctDUNames desc
                yield {Description = duName; Enum  = eenum}  ]
        yield {FixTag = fldNumber; Name = name; Type = fldType; Values = values}
    ]




let private createLenStrFieldDefinition (cfd:CompoundField) =
    sprintf "// compound len+str field\ntype %s =\n    |%s of string\n     member x.Value = let (%s v) = x in v" cfd.Name cfd.Name cfd.Name




let private createLenStrFieldReadFunction (fld:CompoundField) =
    let lines = 
        [   sprintf "// compound read"
            sprintf "let Read%s valIn (strm:System.IO.Stream) =" fld.Name
            sprintf "    let strLen = System.Int32.Parse valIn"
            sprintf "    // the len has been read, next read the string"
            sprintf "    // the tag read-in must match the expected tag"
            sprintf "    // todo: read in strLen bytes" // todo: read in strLen bytes + delim
            sprintf "    let ss = CrapReadUntilDelim strm"
            sprintf "    let subStrs = ss.Split([|'='|])"
            sprintf "    let tag = subStrs.[0]"
            sprintf "    let raw = subStrs.[1]"
            sprintf "    if tag <> \"%d\" then failwith \"invalid tag reading %s\"" fld.StrField.FixTag fld.Name //todo comparing string tags, not byte arrays, i.e. not - if tag <> "91"B
            sprintf "    if strLen <> raw.Length then failwith \"mismatched string len reading %s\"" fld.Name
            sprintf "    %s.%s raw" fld.Name fld.Name   ]
    Utils.joinStrs "\n" lines



let private createLenStrFieldWriteFunction (fld:CompoundField) =
    let lines = [   
            sprintf "// compound write, of a length field and the corresponding string field"
            sprintf "let Write%s (dest:byte []) (nextFreeIdx:int) (fld:%s) : int =" fld.Name fld.Name
            sprintf "    // write the string length part of the compound msg"
            sprintf "    let lenTag = \"%d=\"B" fld.LenField.FixTag
            sprintf "    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)"
            sprintf "    let nextFreeIdx2 = nextFreeIdx + lenTag.Length"
            sprintf "    let lenBs = ToBytes.Convert fld.Value.Length"
            sprintf "    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)"
            sprintf "    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length"
            sprintf "    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter"
            sprintf "    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter"
            sprintf "    // write the string part of the compound msg"
            sprintf "    let strTag = \"91=\"B // i.e. a tag for the string field of the compound msg"
            sprintf "    Buffer.BlockCopy (strTag, 0, dest, nextFreeIdx4, strTag.Length)"
            sprintf "    let nextFreeIdx5 = nextFreeIdx4 + strTag.Length"
            sprintf "    let strBs = ToBytes.Convert fld.Value"
            sprintf "    Buffer.BlockCopy (strBs, 0, dest, nextFreeIdx5, strBs.Length)"
            sprintf "    let nextFreeIdx6 = nextFreeIdx5 + strTag.Length"
            sprintf "    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter"
            sprintf "    nextFreeIdx6 + lenBs.Length + 1 // +1 to include the delimeter"
        ]
    Utils.joinStrs "\n" lines




let Gen (fieldData:FieldData list) (sw:StreamWriter) (swRWFuncs:StreamWriter) =
    sw.WriteLine "module Fix44.Fields"
    sw.WriteLine ""
    sw.WriteLine ""

    // write the individual field instances
    fieldData |> Seq.iter (fun fd ->
            let fldDef =
                match fd with
                | CompoundField cfd ->  createLenStrFieldDefinition cfd
                | SimpleField sfd   ->  let fldDef, _, _ = createFieldTypes sfd
                                        fldDef
            sw.WriteLine fldDef
            sw.WriteLine ""
            sw.WriteLine ""
        )


    // write the 'field' DU
    sw.WriteLine  "type FIXField ="
    fieldData |> Seq.iter (fun fd ->
            let str =
                match fd with
                | SimpleField sfld      ->   sprintf "    | %s of %s" sfld.Name sfld.Name
                | CompoundField cfld    ->   sprintf "    | %s of %s" cfld.Name cfld.Name
            sw.WriteLine str
        )


    swRWFuncs.WriteLine "module Fix44.FieldReadWriteFuncs"
    swRWFuncs.WriteLine ""
    swRWFuncs.WriteLine ""
    swRWFuncs.WriteLine "open System"
    swRWFuncs.WriteLine "open System.IO"
    swRWFuncs.WriteLine "open Fix44.Fields"
    swRWFuncs.WriteLine "open ReadWriteFuncs"
    swRWFuncs.WriteLine ""
    swRWFuncs.WriteLine ""


    fieldData |> Seq.iter (fun fd ->
            let writerFunc =
                match fd with
                | SimpleField sfd   ->  let _, rdrFunc, _ = createFieldTypes sfd          // calling createFieldTypes 3 times, cant determin len-str pairs until all fields have been parsed
                                        rdrFunc

                | CompoundField cfd -> createLenStrFieldWriteFunction cfd
            swRWFuncs.WriteLine writerFunc
            swRWFuncs.WriteLine ""
            swRWFuncs.WriteLine ""
            let readerFunc =
                match fd with
                | SimpleField sfd   ->  let _, _, writerFunc = createFieldTypes sfd
                                        writerFunc
                | CompoundField cfd ->  createLenStrFieldReadFunction cfd
            swRWFuncs.WriteLine readerFunc
            swRWFuncs.WriteLine ""
            swRWFuncs.WriteLine ""
        )


    
    swRWFuncs.WriteLine ""
    swRWFuncs.WriteLine ""
    swRWFuncs.WriteLine  "let WriteField nextFreeIdx dest fixField ="
    swRWFuncs.WriteLine  "    match fixField with"
    fieldData |> Seq.iter (fun fd ->
            let str =
                match fd with
                | SimpleField fd      ->   sprintf "    | %s fixField -> Write%s nextFreeIdx dest fixField" fd.Name fd.Name
                | CompoundField fd    ->   sprintf "    | %s fixField -> Write%s nextFreeIdx dest fixField // compound field" fd.Name fd.Name
            swRWFuncs.WriteLine str
        )



    swRWFuncs.WriteLine ""
    swRWFuncs.WriteLine ""
    swRWFuncs.WriteLine "// todo consider replacing ReadFields match statement with lookup in a map"
    swRWFuncs.WriteLine  "let ReadField (strm:Stream) ="
    swRWFuncs.WriteLine  "    let ss = CrapReadUntilDelim strm // todo: replace with something efficient"
    swRWFuncs.WriteLine  "    let subStrs = ss.Split([|'='|])"
    swRWFuncs.WriteLine  "    let tag = subStrs.[0]"
    swRWFuncs.WriteLine  "    let raw = subStrs.[1]"
    swRWFuncs.WriteLine  "    let fld =    "
    swRWFuncs.WriteLine  "        match tag with"
    fieldData |> Seq.iter (fun fd ->
            let ss =
                match fd with
                | SimpleField fd      ->   sprintf "        | \"%d\" -> Read%s raw |> FIXField.%s" fd.FixTag  fd.Name fd.Name
                | CompoundField fd    ->   sprintf "        | \"%d\" -> Read%s raw strm|> FIXField.%s // len->string compound field" fd.LenField.FixTag fd.Name fd.Name // the length field is always read first
            swRWFuncs.WriteLine ss )
    swRWFuncs.WriteLine "        |  _  -> failwith \"FIXField invalid tag\" "
    swRWFuncs.WriteLine "    fld"
