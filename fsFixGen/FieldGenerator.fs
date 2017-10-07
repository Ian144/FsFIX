(*
 * Copyright (C) 2016-2017 Ian Spratt <ian144@hotmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301, USA.
 *
 *)
 
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
        yield (sprintf "        dest.[nextFreeIdx2] <- 1uy")
        yield (sprintf "        nextFreeIdx2 + 1")
    ]
    lines  |> StringEx.join "\n"



let private makeMultiCaseDUReaderFunc (typeName:string) (values:FieldDUCase list) =
    let readerFuncErrMsg = sprintf "Read%s unknown fix tag:" typeName
    let lines = [
            yield  sprintf "let Read%s (bs:byte[]) (pos:int) (len:int): %s =" typeName typeName 
            yield  sprintf "    let tagBs = bs.[pos..(pos+len-1)]"
            yield  sprintf "    match tagBs with"
            yield! values |> List.map (fun vv -> 
                   sprintf "    |\"%s\"B -> %s.%s" vv.Case typeName vv.Description )
            yield          "    | x -> failwithf \"" + readerFuncErrMsg + " %A\"  x" // the failure case (nested stringformatting makes this difficult to code with a sprintf)
    ]    
    StringEx.join "\n" lines



let private createFieldDUWithValues (typeName:string) (fixTag:uint32) (values:FieldDUCase list) =
    let typeStr = sprintf "type %s =" typeName
    let caseStr = values |> List.map (fun vv -> sprintf "    | %s" vv.Description) |> StringEx.join "\n"
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
    |> StringEx.join ""



// f# cases cannot begin with a number
let private prefixNumericCaseNames (ss:string) =
    match Char.IsDigit(ss.[0]) with
    | true  -> sprintf "C%s" ss
    | false -> ss



let private correctNone (ss:string) =
    match ss with
    | "None"    -> "NNone" // so as not confused with Option.None
    | _         -> ss


let private matchMsgTypeTagToFieldNameFIX44 (ss:string) =
    match ss with
    |"RfqRequest"                        -> "RFQRequest"
    |"OrderSingle"                       -> "NewOrderSingle" 
    |"MultilegOrderCancelReplace"        -> "MultilegOrderCancelReplaceRequest" 
    |"OrderList"                         -> "NewOrderList"
    | ss                                 -> ss


let private correctDUNames = correctDUCaseNames >> prefixNumericCaseNames >> correctNone >> matchMsgTypeTagToFieldNameFIX44



let private getSingleCaseDUReadFuncString (fieldType:string) =
    match fieldType with
    | "uint32"          -> "ReadFieldUInt"
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
    | _                 -> failwithf "unknown type name: %s" fieldType



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
    | _                 -> failwithf "unknown type name: %s" fieldType



let private makeSingleCaseDUWriterFunc (wrappedType:string) (fieldName:string) (fixTag:uint32) =
    let writeFunc = getSingleCaseDUWriteFuncString wrappedType
    let lines = [
            sprintf "let Write%s (dest:byte []) (pos:int) (valIn:%s) : int = " fieldName fieldName
            sprintf "    %s dest pos \"%d=\"B valIn" writeFunc fixTag
    ]
    StringEx.join "\n" lines



let private makeSingleCaseDUReaderFunc (wrappedType:string) (fieldName:string) =
    let readFunc = getSingleCaseDUReadFuncString wrappedType
    let lines = [
            sprintf "let Read%s (bs:byte[]) (pos:int) (len:int): %s =" fieldName fieldName
            sprintf "    %s bs pos len %s.%s" readFunc fieldName fieldName
    ]    
    StringEx.join "\n" lines


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
//    | "TZTIMESTAMP",            true    -> makeSingleCaseDU fieldName tag "TZTimestamp" // not used in FIX4.4, will result in an exception if used in other versions of FIX until TZTIMESTAMP and associated reading and writing functions are implemented
    | "UTCDATEONLY",            true    -> makeSingleCaseDU fieldName tag "UTCDate"
    | "UTCTIMEONLY",            true    -> makeSingleCaseDU fieldName tag "UTCTimeOnly"
    | "UTCTIMESTAMP",           true    -> makeSingleCaseDU fieldName tag "UTCTimestamp"
    | "XMLDATA",                true    -> makeSingleCaseDU fieldName tag "string"
    | "INT",                    false   -> createFieldDUWithValues fieldName tag values
    | "CHAR",                   false   -> createFieldDUWithValues fieldName tag values
    | "BOOLEAN",                false   -> createFieldDUWithValues fieldName tag values
    | "STRING",                 false   -> createFieldDUWithValues fieldName tag values
    | "MULTIPLECHARVALUE",      false   -> createFieldDUWithValues fieldName tag values    // required for 5.0sp2
    | "MULTIPLESTRINGVALUE",    false   -> createFieldDUWithValues fieldName tag values
    | "MULTIPLEVALUESTRING",    false   -> createFieldDUWithValues fieldName tag values    // required for 4.4
    | "NUMINGROUP",             false   -> createFieldDUWithValues fieldName tag values
    | _                                 -> failwithf "NOT IMPLEMENTED %s - %s" fieldName fieldType



// merge a len field and the corresponding string field into a CompoundField
// there are also length fields, RawData(Length) and Signature(Length), requiring similar treatment
let MergeLenFields (fields:SimpleField list) =
    let isLenFieldName (fldName:string) =  System.Text.RegularExpressions.Regex.IsMatch(fldName, ".*Len\z" )
    let isLengthFieldName (fldName:string) =  System.Text.RegularExpressions.Regex.IsMatch(fldName, ".*Length$" )
    let stripLen (fieldName:string) = fieldName.Substring (0, (fieldName.Length - 3) )
    let stripLength (fieldName:string) = fieldName.Substring (0, (fieldName.Length - 6) )
    
    let nameToFieldMap = fields |> List.map (fun fd -> fd.Name, fd) |> Map.ofList

    let lenFields = fields |> List.filter (fun fd -> isLenFieldName fd.Name)
    let lengthFields = fields |> List.filter (fun fd -> isLengthFieldName fd.Name) |> List.filter (fun fd -> fd.Name <> "BodyLength") 
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

    let lengthPairedFields =  lengthFields @ lenFields |> List.map (fun fld -> fld.Name) |> Set.ofList
    lengthPairedFields, mergedFields




let ParseFieldData (parentXL:XElement) : SimpleField list =
    let fieldsXL = parentXL.XPathSelectElements "field"
    [   for fieldXL in fieldsXL do
        let fldNumber = FIXSpecReader.GetAttributeStr fieldXL "number" |> System.Convert.ToUInt32
        let name = FIXSpecReader.GetAttributeStr fieldXL "name"
        let fldType = FIXSpecReader.GetAttributeStr fieldXL "type"
        let valuesXLs = fieldXL.XPathSelectElements "value"
        let values =
            [   for valueXL in valuesXLs do
                let desc = FIXSpecReader.GetAttributeStr valueXL "description"
                let eenum = FIXSpecReader.GetAttributeStr valueXL "enum"
                let duName = correctDUNames desc
                yield {Description = duName; Case = eenum}  ]
        yield {Tag = fldNumber; Name = name; Type = fldType; Values = values}
    ]




let private createLenDataFieldReadFunction (fld:CompoundField) =
    let lines = [   
            sprintf "// compound read"
            sprintf "let Read%s (bs:byte[]) (pos:int) (len:int): %s =" fld.Name fld.Name
            sprintf "    ReadLengthDataCompoundField bs pos len \"%d\"B %s.%s" (fld.DataField.Tag) fld.Name fld.Name 
    ]
    StringEx.join "\n" lines



let private createLenDataFieldDefinition (cfd:CompoundField) =
    sprintf "// compound len+str field\ntype %s =\n    |%s of NonEmptyByteArray.NonEmptyByteArray\n     member x.Value = let (%s v) = x in v" cfd.Name cfd.Name cfd.Name


let private createLenDataFieldWriteFunction (fld:CompoundField) =
    let lines = [   
            sprintf "// compound write, of a length field and the corresponding string field"
            sprintf "let Write%s (dest:byte []) (pos:int) (fld:%s) : int =" fld.Name fld.Name
            sprintf "    WriteFieldLengthData dest pos \"%d=\"B \"%d=\"B fld" fld.LenField.Tag fld.DataField.Tag
        ]
    StringEx.join "\n" lines




let Gen (fieldData:Field list) (sw:StreamWriter) (swReadFuncs:StreamWriter) (swWriteFuncs:StreamWriter) =
    sw.WriteLine "module Fix44.Fields"
    sw.WriteLine ""
    sw.WriteLine "// **** this file is generated by fsFixGen ****"
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
    swReadFuncs.WriteLine "module Fix44.FieldReaders"
    swReadFuncs.WriteLine ""
    swReadFuncs.WriteLine "// **** this file is generated by fsFixGen ****"
    swReadFuncs.WriteLine ""
    swReadFuncs.WriteLine ""
    swReadFuncs.WriteLine "open System"
    swReadFuncs.WriteLine "open System.IO"
    swReadFuncs.WriteLine "open Fix44.Fields"
    swReadFuncs.WriteLine "open Conversions"
    swReadFuncs.WriteLine "open RawField"
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
    swWriteFuncs.WriteLine "module Fix44.FieldWriters"
    swWriteFuncs.WriteLine ""
    swWriteFuncs.WriteLine "// **** this file is generated by fsFixGen ****"
    swWriteFuncs.WriteLine ""
    swWriteFuncs.WriteLine "open System"
    swWriteFuncs.WriteLine "open System.IO"
    swWriteFuncs.WriteLine "open Fix44.Fields"
    swWriteFuncs.WriteLine "open Conversions"
    swWriteFuncs.WriteLine "open RawField"
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
