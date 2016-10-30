//[<RequireQualifiedAccess>]
module FieldGenerator


open System
open System.IO
open System.Xml.Linq
open System.Xml.XPath



type FieldDUCase = { Enum:string; Description:string }
type SimpleField = { FixTag:int; Name:string; Type:string; Values:FieldDUCase list }
type CompoundField = { Name:string; LenField:SimpleField; DataField:SimpleField }
type FieldData = SimpleField of SimpleField | CompoundField of CompoundField


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



let private makeMultiCaseDUReaderFunc (typeName:string) (values:FieldDUCase list) =
    let readerFuncErrMsg = sprintf "Read%s unknown fix tag:" typeName
    let lines = [
            yield  sprintf "let Read%s (pos:int) (bs:byte[]) : (int * %s) =" typeName typeName 
            yield  sprintf "    let pos2, valIn = FIXBufUtils.readValAfterTagValSep pos bs"
            yield  sprintf "    let fld = "
            yield  sprintf "        match valIn with"
            yield! values |> List.map (fun vv -> 
                   sprintf "        |\"%s\"B -> %s.%s" vv.Enum typeName vv.Description )
            yield          "        | x -> failwith (sprintf \"" + readerFuncErrMsg + " %A\"  x) " // the failure case (nested sprintf makes this difficult to code with a sprintf)
            yield  sprintf "    pos2 + 1, fld  // +1 to advance the position to after the field separator" 
    ]    
    Utils.joinStrs "\n" lines


let private createFieldDUWithValues (typeName:string) (fixTag:int) (values:FieldDUCase list) =
    let typeStr = sprintf "type %s =" typeName
    let caseStr = values |> List.map (fun vv -> sprintf "    | %s" vv.Description) |> Utils.joinStrs "\n"
    let typeStr = sprintf "%s\n%s" typeStr caseStr
    let readerFunc = makeMultiCaseDUReaderFunc typeName values
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
    | true  -> sprintf "C%s" ss
    | false -> ss



let private correctNone (ss:string) =
    match ss with
    | "None"    -> "NNone"
    | _         -> ss




let private correctDUNames = correctDUCaseNames >> prefixNumericCaseNames >> correctNone


let private getSingleCaseDUReadFuncString (fieldType:string) =
    match fieldType with
    | "int"     -> "ReadSingleCaseDUIntField"
    | "decimal" -> "ReadSingleCaseDUDecimalField"
    | "bool"    -> "ReadSingleCaseDUBoolField"
    | "string"  -> "ReadSingleCaseDUStrField"
    | "byte []" -> "ReadSingleCaseDUDataField"
    | _         -> failwith "unknown type name"



let private getSingleCaseDUWriteFuncString (fieldType:string) =
    match fieldType with
    | "int"     -> "WriteFieldInt"
    | "decimal" -> "WriteFieldDecimal"
    | "bool"    -> "WriteFieldBool"
    | "string"  -> "WriteFieldStr"
    | "byte []" -> "WriteFieldData"
    | _         -> failwith "unknown type name"



let private makeSingleCaseDUWriterFunc (wrappedType:string) (fieldName:string) (fixTag:int) =
    let writeFunc = getSingleCaseDUWriteFuncString wrappedType
    let lines = [
            sprintf "let Write%s (dest:byte []) (pos:int) (valIn:%s) : int = " fieldName fieldName
            sprintf "    %s dest pos \"%d=\"B valIn" writeFunc fixTag
    ]
    Utils.joinStrs "\n" lines


let private makeSingleCaseDUReaderFunc (wrappedType:string) (fieldName:string) =
    let readFunc = getSingleCaseDUReadFuncString wrappedType
    let lines = [
            sprintf "let Read%s (pos:int) (bs:byte[]) : (int*%s) =" fieldName fieldName
            sprintf "    %s pos bs %s.%s" readFunc fieldName fieldName
    ]    
    Utils.joinStrs "\n" lines


let private makeSingleCaseDU (fieldName:string) (tag:int) (innerType:string) =
    let fieldDefStr = sprintf "type %s =\n    |%s of %s\n     member x.Value = let (%s v) = x in v" fieldName fieldName innerType fieldName
    //let readerFunc = sprintf "let Read%s valIn =\n    let tmp = %s valIn\n    %s.%s tmp" typeName (getParseFuncString fsharpInnerType) typeName typeName
    let readerFunc = makeSingleCaseDUReaderFunc innerType fieldName
    let writerFunc = makeSingleCaseDUWriterFunc  innerType fieldName tag
    fieldDefStr, readerFunc, writerFunc


let private createFieldTypes (field:SimpleField) =
    let fieldType = field.Type
    let fieldName = field.Name
    let tag = field.FixTag
    let values = field.Values
    match fieldType, (Seq.isEmpty values) with
    | "AMT",                    true    -> makeSingleCaseDU fieldName tag "int"
    | "BOOLEAN",                true    -> makeSingleCaseDU fieldName tag "bool"
    | "CHAR",                   true    -> makeSingleCaseDU fieldName tag "int" // todo, store char as a byte|char
    | "COUNTRY",                true    -> makeSingleCaseDU fieldName tag "string"
    | "CURRENCY",               true    -> makeSingleCaseDU fieldName tag "string"
    | "DATA",                   true    -> makeSingleCaseDU fieldName tag "byte []"
    | "DAYOFMONTH",             true    -> makeSingleCaseDU fieldName tag "int"     // todo: store dayofmonth as a uint|ushort
    | "EXCHANGE",               true    -> makeSingleCaseDU fieldName tag "string"
    | "FLOAT",                  true    -> makeSingleCaseDU fieldName tag "decimal"
    | "INT",                    true    -> makeSingleCaseDU fieldName tag "int"
    | "LANGUAGE",               true    -> makeSingleCaseDU fieldName tag "string"
    | "LENGTH",                 true    -> makeSingleCaseDU fieldName tag "int"     //todo: store length as a uint??
    | "LOCALMKTDATE",           true    -> makeSingleCaseDU fieldName tag "string" // todo: storing LOCALMKTDATE as string, use appropriate type (use NODA TIME - what does quickfixJ use?)
    | "MONTHYEAR",              true    -> makeSingleCaseDU fieldName tag "string" // todo: storing MONTHYEAR as string, use appropriate type(use NODA TIME)
    | "MULTIPLECHARVALUE",      true    -> makeSingleCaseDU fieldName tag "string"
    | "NUMINGROUP",             true    -> makeSingleCaseDU fieldName tag "int"     // todo: store numingroup as a uint?
    | "PERCENTAGE",             true    -> makeSingleCaseDU fieldName tag "decimal"
    | "PRICE",                  true    -> makeSingleCaseDU fieldName tag "decimal"
    | "PRICEOFFSET",            true    -> makeSingleCaseDU fieldName tag "decimal"
    | "QTY",                    true    -> makeSingleCaseDU fieldName tag "decimal"
    | "SEQNUM",                 true    -> makeSingleCaseDU fieldName tag "int"     // todo: represent seqnum as a uint?
    | "STRING",                 true    -> makeSingleCaseDU fieldName tag "string"
    | "TZTIMEONLY",             true    -> makeSingleCaseDU fieldName tag "string" // todo: storing TZTIMESTAMP as string, use appropriate type (use NODA TIME)
    | "TZTIMESTAMP",            true    -> makeSingleCaseDU fieldName tag "string" // todo: storing TZTIMESTAMP as string, use appropriate type (use NODA TIME)
    | "UTCDATEONLY",            true    -> makeSingleCaseDU fieldName tag "string" // todo: storing UTCDATEONLY as string, use appropriate type (use NODA TIME)
    | "UTCTIMEONLY",            true    -> makeSingleCaseDU fieldName tag "string" // todo: storing UTCTIMEONLY as string, use appropriate type (use NODA TIME)
    | "UTCTIMESTAMP",           true    -> makeSingleCaseDU fieldName tag "string" // todo: storing UTCTIMESTAMP as string, use appropriate type (use NODA TIME)
    | "XMLDATA",                true    -> makeSingleCaseDU fieldName tag "string"
    | "INT",                    false   -> createFieldDUWithValues fieldName tag values //todo: INT, CHAR, BOOLEAN etc currently sent and recieved as strings for multicase variants with a value, is this correct
    | "CHAR",                   false   -> createFieldDUWithValues fieldName tag values
    | "BOOLEAN",                false   -> createFieldDUWithValues fieldName tag values
    | "STRING",                 false   -> createFieldDUWithValues fieldName tag values
    | "MULTIPLECHARVALUE",      false   -> createFieldDUWithValues fieldName tag values    // required for 5.0sp2
    | "MULTIPLESTRINGVALUE",    false   -> createFieldDUWithValues fieldName tag values
    | "MULTIPLEVALUESTRING",    false   -> createFieldDUWithValues fieldName tag values    // required for 4.4
    | "NUMINGROUP",             false   -> createFieldDUWithValues fieldName tag values
    | _                                 -> let msg = sprintf "NOT IMPLEMENTED %s - %s" fieldName fieldType
                                           failwith msg



// merge len fields and the corresponding string fields into a CompoundField, other fields are in a SimpleField
// there are also length fields, RawData(Length) and Signature(Length), requiring similare
let MergeLenFields (fields:SimpleField list) =
    let isLenFieldName (fldName:string) =  System.Text.RegularExpressions.Regex.IsMatch(fldName, ".*Len\z" )
    let isLengthFieldName (fldName:string) =  System.Text.RegularExpressions.Regex.IsMatch(fldName, ".*Length$" )
    let stripLen (fieldName:string) = fieldName.Substring (0, (fieldName.Length - 3) )
    let stripLength (fieldName:string) = fieldName.Substring (0, (fieldName.Length - 6) )
    
    let nameToFieldMap = fields |> List.map (fun fd -> fd.Name, fd) |> Map.ofList

    let lenFields = fields |> List.filter (fun fd -> isLenFieldName fd.Name)
    let lengthFields = fields |> List.filter (fun fd -> isLengthFieldName fd.Name) |> List.filter (fun fd -> fd.Name <> "BodyLength") // todo: fix hardcoded field name in length-data field pair detection
    let allLengthTypeFields = lengthFields @ lenFields |> Set.ofList

    // find those fields (string or byte[]) paired with a len|length field
    let lengthPairs =
        [   for fld in lengthFields do
            let fn = stripLength fld.Name
            yield nameToFieldMap.[fn], fld ]

    let lenPairs =
        [   for fld in lenFields do
            let fn = stripLen fld.Name
            yield nameToFieldMap.[fn], fld ]

    let allFieldPairsMap = lenPairs @ lengthPairs |> Map.ofList

    let mergedFields =
        [   for fld in fields do
            if allLengthTypeFields |> Set.contains fld |> not then
                if allFieldPairsMap.ContainsKey fld then
                    let lenField = allFieldPairsMap.[fld] // 'len' and 'length' fields
                    yield FieldData.CompoundField {Name=fld.Name; LenField = lenField; DataField = fld}
                else
                    yield FieldData.SimpleField fld ]

    let lengthPairedFields =  lengthFields @ lenFields |> List.map (fun fld -> fld.Name) |> Set.ofList //todo: get client of this function to use a Set<Field>
    lengthPairedFields, mergedFields




let ParseFieldData (parentXL:XElement) : SimpleField list =
    let fieldsXL = parentXL.XPathSelectElements "field"
    [   for fieldXL in fieldsXL do
        let fldNumber = ParsingFuncs.gas fieldXL "number" |> System.Convert.ToInt32
        let name = ParsingFuncs.gas fieldXL "name"
        let fldName = name.Trim()
        let fldType = ParsingFuncs.gas fieldXL "type"
        let valuesXLs = fieldXL.XPathSelectElements "value"
        let values =
            [   for valueXL in valuesXLs do
                let desc = ParsingFuncs.gas valueXL "description"
                let eenum = ParsingFuncs.gas valueXL "enum"
                let duName = correctDUNames desc
                yield {Description = duName; Enum  = eenum}  ]
        yield {FixTag = fldNumber; Name = name; Type = fldType; Values = values}
    ]




let private createLenDataFieldDefinition (cfd:CompoundField) =
    sprintf "// compound len+str field\ntype %s =\n    |%s of byte []\n     member x.Value = let (%s v) = x in v" cfd.Name cfd.Name cfd.Name



let private createLenDataFieldReadFunction (fld:CompoundField) =
    let lines = [   
            sprintf "// compound read"
            sprintf "let Read%s (pos:int) (bs:byte[]) : (int * %s) =" fld.Name fld.Name
            sprintf "    ReadLengthDataCompoundField \"%d\"B (pos:int) (bs:byte[]) %s.%s" (fld.DataField.FixTag) fld.Name fld.Name 
    ]
    Utils.joinStrs "\n" lines


let private createLenDataFieldWriteFunction (fld:CompoundField) =
    let lines = [   
            sprintf "// compound write, of a length field and the corresponding string field"
            sprintf "let Write%s (dest:byte []) (pos:int) (fld:%s) : int =" fld.Name fld.Name
            sprintf "    WriteFieldLengthData \"%d=\"B \"%d=\"B dest pos fld" fld.LenField.FixTag fld.DataField.FixTag
//            sprintf "    // write the string length part of the compound msg"
//            sprintf "    let lenTag = \"%d=\"B" fld.LenField.FixTag
//            sprintf "    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)"
//            sprintf "    let nextFreeIdx2 = nextFreeIdx + lenTag.Length"
//            sprintf "    let lenBs = ToBytes.Convert fld.Value.Length"
//            sprintf "    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)"
//            sprintf "    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length"
//            sprintf "    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter"
//            sprintf "    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter"
//            sprintf "    // write the string part of the compound msg"
//            sprintf "    let dataTag = \"%d=\"B // i.e. tag for the data field of the compound msg" fld.DataField.FixTag
//            sprintf "    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)"
//            sprintf "    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length"
//            sprintf "    let dataBs = fld.Value"
//            sprintf "    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)"
//            sprintf "    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length"
//            sprintf "    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter"
//            sprintf "    nextFreeIdx6 + 1 // +1 to include the delimeter"
        ]
    Utils.joinStrs "\n" lines




let Gen (fieldData:FieldData list) (sw:StreamWriter) (swReadFuncs:StreamWriter) (swWriteFuncs:StreamWriter) (swFieldDU:StreamWriter) =

    sw.WriteLine "module Fix44.Fields"
    sw.WriteLine ""
    sw.WriteLine ""

    // write the individual field instances
    fieldData |> Seq.iter (fun fd ->
            let fldDef =
                match fd with
                | CompoundField cfd ->  createLenDataFieldDefinition cfd
                | SimpleField sfd   ->  let fldDef, _, _ = createFieldTypes sfd
                                        fldDef
            sw.WriteLine fldDef
            sw.WriteLine ""
            sw.WriteLine ""
        )

    
    // write the field read functions
    swReadFuncs.WriteLine "module Fix44.FieldReadFuncs"
    swReadFuncs.WriteLine ""
    swReadFuncs.WriteLine ""
    swReadFuncs.WriteLine "open System"
    swReadFuncs.WriteLine "open System.IO"
    swReadFuncs.WriteLine "open Fix44.Fields"
    swReadFuncs.WriteLine "open Conversions"
    swReadFuncs.WriteLine "open FieldFuncs"
    swReadFuncs.WriteLine ""
    swReadFuncs.WriteLine ""

    // write the field read functions
    fieldData |> Seq.iter (fun fd ->
            let readerFunc =
                match fd with
                | SimpleField sfd   ->  let _, rdrFunc, _= createFieldTypes sfd
                                        rdrFunc
                | CompoundField cfd ->  createLenDataFieldReadFunction cfd
            swReadFuncs.WriteLine readerFunc
            swReadFuncs.WriteLine ""
            swReadFuncs.WriteLine ""
        )


    // write the field write functions
    swWriteFuncs.WriteLine "module Fix44.FieldWriteFuncs"
    swWriteFuncs.WriteLine ""
    swWriteFuncs.WriteLine ""
    swWriteFuncs.WriteLine "open System"
    swWriteFuncs.WriteLine "open System.IO"
    swWriteFuncs.WriteLine "open Fix44.Fields"
    swWriteFuncs.WriteLine "open Conversions"
    swWriteFuncs.WriteLine "open FieldFuncs"
    swWriteFuncs.WriteLine ""
    swWriteFuncs.WriteLine ""

    fieldData |> Seq.iter (fun fd ->
            let writerFunc =
                match fd with
                | SimpleField sfd   ->  let _, _, writerFunc = createFieldTypes sfd          // calling createFieldTypes 3 times, cannot determin len-str pairs until all fields have been parsed
                                        writerFunc
                | CompoundField cfd -> createLenDataFieldWriteFunction cfd
            swWriteFuncs.WriteLine writerFunc
            swWriteFuncs.WriteLine ""
            swWriteFuncs.WriteLine ""
        )



    // write the 'field' DU, and the DU readField and writeField functions in a separate source file to try to reduce source file length
    swFieldDU.WriteLine "module Fix44.FieldDU"
    swFieldDU.WriteLine ""
    swFieldDU.WriteLine ""
    swFieldDU.WriteLine "open Fix44.Fields"
    swFieldDU.WriteLine "open Fix44.FieldReadFuncs"
    swFieldDU.WriteLine "open Fix44.FieldWriteFuncs"
    swFieldDU.WriteLine ""
    swFieldDU.WriteLine ""


    swFieldDU.WriteLine  "type FIXField ="
    fieldData |> Seq.iter (fun fd ->
            let str =
                match fd with
                | SimpleField sfld      ->   sprintf "    | %s of %s" sfld.Name sfld.Name
                | CompoundField cfld    ->   sprintf "    | %s of %s" cfld.Name cfld.Name
            swFieldDU.WriteLine str
        )

    
    swFieldDU.WriteLine ""
    swFieldDU.WriteLine ""
    swFieldDU.WriteLine  "let WriteField dest nextFreeIdx fixField ="
    swFieldDU.WriteLine  "    match fixField with"
    fieldData |> Seq.iter (fun fd ->
            let str =
                match fd with
                | SimpleField fd      ->   sprintf "    | %s fixField -> Write%s dest nextFreeIdx fixField" fd.Name fd.Name
                | CompoundField fd    ->   sprintf "    | %s fixField -> Write%s dest nextFreeIdx fixField // compound field" fd.Name fd.Name
            swFieldDU.WriteLine str
        )



    swFieldDU.WriteLine ""
    swFieldDU.WriteLine ""
    swFieldDU.WriteLine "// todo consider replacing ReadFields match statement with lookup in a map"
    swFieldDU.WriteLine  "let ReadField (pos:int) (bs:byte[]) ="
    swFieldDU.WriteLine  "    let pos2, tag = FIXBufUtils.readTag pos bs"
    swFieldDU.WriteLine  "    let pos2 = pos2 + 1 // move past the tag-value separator"
    swFieldDU.WriteLine  "    match tag with"
    fieldData |> Seq.iter (fun fd ->
            let ss =
                match fd with
                | SimpleField fd      ->   sprintf "    | \"%d\"B ->\n        let pos3, fld = Read%s pos2 bs\n        pos3, fld |> FIXField.%s" fd.FixTag  fd.Name fd.Name
                | CompoundField fd    ->   sprintf "    | \"%d\"B ->\n        let pos3, fld = Read%s pos2 bs\n        pos3, fld |> FIXField.%s // len->string compound field" fd.LenField.FixTag fd.Name fd.Name // the length field is always read first
            swFieldDU.WriteLine ss )
    swFieldDU.WriteLine "    |  _  -> failwith \"FIXField invalid tag\" "
