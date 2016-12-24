//[<RequireQualifiedAccess>]
module FieldGenerator


open System
open System.IO
open System.Xml.Linq
open System.Xml.XPath

open FIXGenTypes



let private createFieldDUWriterFunc (fldName:string) (fixTag:uint32) (values:FieldDUCase list) = 
    let lines = [
        yield (sprintf "let Write%s (dest:byte array) (nextFreeIdx:int) (xxIn:%s) : int =" fldName fldName)
        yield (sprintf "    match xxIn with")
        for vv in values do
        yield (sprintf "    | %s.%s ->"  fldName vv.Description)
        yield (sprintf "        let tag = \"%d=%s\"B"  fixTag  vv.Case)
        yield (sprintf "        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)")
        yield (sprintf "        let nextFreeIdx2 = nextFreeIdx + tag.Length")
        yield (sprintf "        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter")
        yield (sprintf "        nextFreeIdx2 + 1 // +1 to include the delimeter")
    ]
    lines  |> Utils.joinStrs "\n"



let private makeMultiCaseDUReaderFunc (typeName:string) (values:FieldDUCase list) =
    let readerFuncErrMsg = sprintf "Read%s unknown fix tag:" typeName
    let lines = [
            yield  sprintf "let Read%s (bs:byte[]) (pos:int) : (int * %s) =" typeName typeName 
            yield  sprintf "    let pos2, valIn = FIXBufUtils.readValAfterTagValSep bs pos"
            yield  sprintf "    let fld = "
            yield  sprintf "        match valIn with"
            yield! values |> List.map (fun vv -> 
                   sprintf "        |\"%s\"B -> %s.%s" vv.Case typeName vv.Description )
            yield          "        | x -> failwith (sprintf \"" + readerFuncErrMsg + " %A\"  x) " // the failure case (nested sprintf makes this difficult to code with a sprintf)
            yield  sprintf "    pos2, fld"
    ]    
    Utils.joinStrs "\n" lines


let private createFieldDUWithValues (typeName:string) (fixTag:uint32) (values:FieldDUCase list) =
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
    | "uint32"          -> "ReadFieldUint32"
    | "int"             -> "ReadFieldInt"
    | "decimal"         -> "ReadFieldDecimal"
    | "bool"            -> "ReadFieldBool"
    | "char"            -> "ReadFieldChar"
    | "string"          -> "ReadFieldStr"
    | "byte []"         -> "ReadFieldData"
    | "UTCTimeOnly"     -> "ReadFieldUTCTimeOnly"
    | "UTCDate"         -> "ReadFieldUTCDate"
    | "UTCTimestamp"    -> "ReadFieldUTCTimestamp" 
    | "TZTimeOnly"      -> "ReadFieldTZTimeOnly"
    | "MonthYear"       -> "ReadFieldMonthYear"
    | "LocalMktDate"    -> "ReadFieldLocalMktDate"
    | _                 -> failwith "unknown type name"



let private getSingleCaseDUWriteFuncString (fieldType:string) =
    match fieldType with
    | "int"             -> "WriteFieldInt"
    | "uint32"          -> "WriteFieldUint32"
    | "decimal"         -> "WriteFieldDecimal"
    | "bool"            -> "WriteFieldBool"
    | "char"            -> "WriteFieldChar"
    | "string"          -> "WriteFieldStr"
    | "byte []"         -> "WriteFieldData"
    | "UTCTimeOnly"     -> "WriteFieldUTCTimeOnly"
    | "UTCDate"         -> "WriteFieldUTCDate"
    | "UTCTimestamp"    -> "WriteFieldUTCTimestamp"
    | "TZTimeOnly"      -> "WriteFieldTZTimeOnly"
    | "MonthYear"       -> "WriteFieldMonthYear"
    | "LocalMktDate"    -> "WriteFieldLocalMktDate"
    | _                 -> failwith "unknown type name"



let private makeSingleCaseDUWriterFunc (wrappedType:string) (fieldName:string) (fixTag:uint32) =
    let writeFunc = getSingleCaseDUWriteFuncString wrappedType
    let lines = [
            sprintf "let Write%s (dest:byte []) (pos:int) (valIn:%s) : int = " fieldName fieldName
            sprintf "    %s dest pos \"%d=\"B valIn" writeFunc fixTag
    ]
    Utils.joinStrs "\n" lines


let private makeSingleCaseDUReaderFunc (wrappedType:string) (fieldName:string) =
    let readFunc = getSingleCaseDUReadFuncString wrappedType
    let lines = [
            sprintf "let Read%s (bs:byte[]) (pos:int): (int*%s) =" fieldName fieldName
            sprintf "    %s bs pos %s.%s" readFunc fieldName fieldName
    ]    
    Utils.joinStrs "\n" lines


let private makeSingleCaseDU (fieldName:string) (tag:uint32) (innerType:string) =
    let fieldDefStr = sprintf "type %s =\n    |%s of %s\n     member x.Value = let (%s v) = x in v" fieldName fieldName innerType fieldName
    //let readerFunc = sprintf "let Read%s valIn =\n    let tmp = %s valIn\n    %s.%s tmp" typeName (getParseFuncString fsharpInnerType) typeName typeName
    let readerFunc = makeSingleCaseDUReaderFunc innerType fieldName
    let writerFunc = makeSingleCaseDUWriterFunc  innerType fieldName tag
    fieldDefStr, readerFunc, writerFunc


let private createFieldTypes (field:SimpleField) =
    let fieldType = field.Type
    let fieldName = field.Name
    let tag = field.Tag
    let values = field.Values
    match fieldType, (Seq.isEmpty values) with
    | "AMT",                    true    -> makeSingleCaseDU fieldName tag "decimal"
    | "BOOLEAN",                true    -> makeSingleCaseDU fieldName tag "bool"
    | "CHAR",                   true    -> makeSingleCaseDU fieldName tag "char"
    | "COUNTRY",                true    -> makeSingleCaseDU fieldName tag "string" 
    | "CURRENCY",               true    -> makeSingleCaseDU fieldName tag "string"
    | "DATA",                   true    -> makeSingleCaseDU fieldName tag "byte []"
//    | "DAYOFMONTH",             true    -> makeSingleCaseDU fieldName tag "DayOfMonth"     // not in FIX4.4
    | "EXCHANGE",               true    -> makeSingleCaseDU fieldName tag "string"
    | "FLOAT",                  true    -> makeSingleCaseDU fieldName tag "decimal"
    | "INT",                    true    -> makeSingleCaseDU fieldName tag "int"
    | "LANGUAGE",               true    -> makeSingleCaseDU fieldName tag "string"
    | "LENGTH",                 true    -> makeSingleCaseDU fieldName tag "uint32"
    | "LOCALMKTDATE",           true    -> makeSingleCaseDU fieldName tag "LocalMktDate"
    | "MONTHYEAR",              true    -> makeSingleCaseDU fieldName tag "MonthYear"
    | "MULTIPLECHARVALUE",      true    -> makeSingleCaseDU fieldName tag "string"
    | "NUMINGROUP",             true    -> makeSingleCaseDU fieldName tag "int"     // leaving this as an 'int' as array and list (used to hold group instances) indexing funcs take ints not uints, may review this decision
    | "PERCENTAGE",             true    -> makeSingleCaseDU fieldName tag "decimal"
    | "PRICE",                  true    -> makeSingleCaseDU fieldName tag "decimal"
    | "PRICEOFFSET",            true    -> makeSingleCaseDU fieldName tag "decimal"
    | "QTY",                    true    -> makeSingleCaseDU fieldName tag "decimal"
    | "SEQNUM",                 true    -> makeSingleCaseDU fieldName tag "uint32"
    | "STRING",                 true    -> makeSingleCaseDU fieldName tag "string"
//    | "TZTIMEONLY",             true    -> makeSingleCaseDU fieldName tag "TZTimeOnly"
//    | "TZTIMESTAMP",            true    -> makeSingleCaseDU fieldName tag "TZTimestamp" // todo: not used in FIX4.4, will result in an exception if used in other versions of FIX until TZTIMESTAMP and associated reading and writing functions are implemented
    | "UTCDATEONLY",            true    -> makeSingleCaseDU fieldName tag "UTCDate"
    | "UTCTIMEONLY",            true    -> makeSingleCaseDU fieldName tag "UTCTimeOnly"
    | "UTCTIMESTAMP",           true    -> makeSingleCaseDU fieldName tag "UTCTimestamp"
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
    let lengthFields = fields |> List.filter (fun fd -> isLengthFieldName fd.Name) |> List.filter (fun fd -> fd.Name <> "BodyLength") // todo: fix hardcoded field name filter in length-data field pair detection
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
                    yield Field.CompoundField {Name=fld.Name; LenField = lenField; DataField = fld}
                else
                    yield Field.SimpleField fld ]

    let lengthPairedFields =  lengthFields @ lenFields |> List.map (fun fld -> fld.Name) |> Set.ofList //todo: get client of this function to use a Set<Field>
    lengthPairedFields, mergedFields




let ParseFieldData (parentXL:XElement) : SimpleField list =
    let fieldsXL = parentXL.XPathSelectElements "field"
    [   for fieldXL in fieldsXL do
        let fldNumber = ParsingFuncs.gas fieldXL "number" |> System.Convert.ToUInt32
        let name = ParsingFuncs.gas fieldXL "name"
        let fldType = ParsingFuncs.gas fieldXL "type"
        let valuesXLs = fieldXL.XPathSelectElements "value"
        let values =
            [   for valueXL in valuesXLs do
                let desc = ParsingFuncs.gas valueXL "description"
                let eenum = ParsingFuncs.gas valueXL "enum"
                let duName = correctDUNames desc
                yield {Description = duName; Case = eenum}  ]
        yield {Tag = fldNumber; Name = name; Type = fldType; Values = values}
    ]




let private createLenDataFieldDefinition (cfd:CompoundField) =
    sprintf "// compound len+str field\ntype %s =\n    |%s of byte []\n     member x.Value = let (%s v) = x in v" cfd.Name cfd.Name cfd.Name



let private createLenDataFieldReadFunction (fld:CompoundField) =
    let lines = [   
            sprintf "// compound read"
            sprintf "let Read%s (bs:byte[]) (pos:int) : (int * %s) =" fld.Name fld.Name
            sprintf "    ReadLengthDataCompoundField (bs:byte[]) (pos:int) \"%d\"B %s.%s" (fld.DataField.Tag) fld.Name fld.Name 
    ]
    Utils.joinStrs "\n" lines


let private createLenDataFieldWriteFunction (fld:CompoundField) =
    let lines = [   
            sprintf "// compound write, of a length field and the corresponding string field"
            sprintf "let Write%s (dest:byte []) (pos:int) (fld:%s) : int =" fld.Name fld.Name
            sprintf "    WriteFieldLengthData dest pos \"%d=\"B \"%d=\"B fld" fld.LenField.Tag fld.DataField.Tag
        ]
    Utils.joinStrs "\n" lines




let Gen (fieldData:Field list) (sw:StreamWriter) (swReadFuncs:StreamWriter) (swWriteFuncs:StreamWriter) (swFieldDU:StreamWriter) =
    sw.WriteLine "module Fix44.Fields"
    sw.WriteLine ""
    sw.WriteLine "open LocalMktDate"
    sw.WriteLine "open UTCDateTime"
    sw.WriteLine "open MonthYear"
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
    swFieldDU.WriteLine  "let ReadField (bs:byte[]) (pos:int) ="
    swFieldDU.WriteLine  "    let pos2, tag = FIXBufUtils.readTag bs pos"
    swFieldDU.WriteLine  "    match tag with"
    fieldData |> Seq.iter (fun fd ->
            let ss =
                match fd with
                | SimpleField fd      ->   sprintf "    | \"%d\"B ->\n        let pos3, fld = Read%s bs pos2 \n        pos3, fld |> FIXField.%s" fd.Tag  fd.Name fd.Name
                | CompoundField fd    ->   sprintf "    | \"%d\"B ->\n        let pos3, fld = Read%s bs pos2 \n        pos3, fld |> FIXField.%s // len->string compound field" fd.LenField.Tag fd.Name fd.Name // the length field is always read first
            swFieldDU.WriteLine ss )
    swFieldDU.WriteLine "    |  _  -> failwith \"FIXField invalid tag\" "
