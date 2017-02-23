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
 
open System


open System.Xml.Linq
open System.Xml.XPath
open System.IO

open FIXGenTypes
open CmdLine





let GenerateFsFIX (fixSpecXmlFile, outDir) =
    let makeOutpath flName = sprintf """%s\%s""" outDir flName

    let fixXml = IO.File.ReadAllText(fixSpecXmlFile)
    let doc = XDocument.Parse fixXml

    let xpthFields = doc.XPathSelectElement "fix/fields"
    use swFixFields = new StreamWriter (makeOutpath "Fix44.Fields.fs")
    use swFieldReadFuncs = new StreamWriter (makeOutpath "Fix44.FieldReaders.fs")
    use swFieldWriteFuncs = new StreamWriter (makeOutpath "Fix44.FieldWriters.fs")
    
    printfn "reading and generating FIX field source"
    let fields = FieldGenerator.ParseFieldData xpthFields 
    let lenFieldNames, mergedFields = FieldGenerator.MergeLenFields fields
    FieldGenerator.Gen mergedFields swFixFields swFieldReadFuncs swFieldWriteFuncs


    let getFieldName = function
        | SimpleField sf    -> sf.Name
        | CompoundField cf  -> cf.Name

    // Make a map of field name to field definition, used to connect a field reference with the field definition.
    let fieldNameMap = mergedFields |> List.map (fun fld -> (getFieldName fld), fld ) |> Map.ofList
    
    printfn "read header"
    let xpthHrd = doc.XPathSelectElement "fix/header"
    let hdr = HeaderTrailerGenerator.ReadHeader lenFieldNames xpthHrd
    
    printfn "read trailer"
    let xpthTrl = doc.XPathSelectElement "fix/trailer"
    let trl = HeaderTrailerGenerator.ReadTrailer lenFieldNames xpthTrl

    printfn "reading components"
    let xpthMsgs = doc.XPathSelectElement "fix/components"
    let components = ComponentReader.Read xpthMsgs

    printfn "reading messages"
    let xpthMsgs = doc.XPathSelectElement "fix/messages"
    let msgs = MessageGenerator.Read xpthMsgs

       
    let hdrTrlPath = makeOutpath "Fix44.HeaderTrailer.fs"
    let hdrItemsAfterGroupMerge, constrainedCompoundItemsInDepOrder, msgsAfterGroupMerge, componentNameMap = CompoundItemProcessor.Process hdr trl hdrTrlPath components msgs lenFieldNames

    printfn "generating group and component writing functions"
    use swCompoundItems = new StreamWriter (makeOutpath "Fix44.CompoundItems.fs")
    CompoundItemGenerator.Gen componentNameMap constrainedCompoundItemsInDepOrder swCompoundItems
    use swGroupWriteFuncs = new StreamWriter (makeOutpath "Fix44.CompoundItemWriters.fs")
    do CompoundItemGenerator.GenWriteFuncs constrainedCompoundItemsInDepOrder swGroupWriteFuncs

    printfn "generating group and component reading functions"
    use swGroupReadFuncs = new StreamWriter (makeOutpath "Fix44.CompoundItemReaders.fs")
    do CompoundItemGenerator.GenReadFuncs fieldNameMap componentNameMap constrainedCompoundItemsInDepOrder swGroupReadFuncs

    printfn "generating group and component factory functions"
    use swGroupCompFactoryFuncs = new StreamWriter (makeOutpath "Fix44.CompoundItemFactoryFuncs.fs")
    do CompoundItemGenerator.GenFactoryFuncs constrainedCompoundItemsInDepOrder swGroupCompFactoryFuncs

    // If this was not done then FsFIX can represent the same state in two different ways (optional component is present (Option.Some) but all optional component members are not OR component is not present (Option.None))
    // To avoid this ambiguity optional components containing only optional members are 'promoted' to being required, the members are left as optional
    let msgsFinal =
        [   for msg in msgsAfterGroupMerge do
            let items2 = msg.Items |> List.collect (CompoundItemRules.makeOptionalComponentsRequiredIfTheyContainOnlyOptionalSubItemsInner componentNameMap)
            yield {msg with Items = items2} ]

    printfn "generating F# message definitions"
    use swMsgs = new StreamWriter (makeOutpath "Fix44.Messages.fs")
    MessageGenerator.Gen msgsFinal swMsgs

    printfn "generating message writer funcs"
    use swMsgWriteFuncs = new StreamWriter (makeOutpath "Fix44.MsgWriters.fs")
    MessageGenerator.GenWriteFuncs hdrItemsAfterGroupMerge msgsFinal swMsgWriteFuncs

    printfn "generating message reader funcs"
    use swMsgWriteFuncs = new StreamWriter (makeOutpath "Fix44.MsgReaders.fs")
    MessageGenerator.GenReadFuncs fieldNameMap componentNameMap hdrItemsAfterGroupMerge msgsFinal swMsgWriteFuncs

    printfn "generating message DU"
    use swMsgWriteFuncs = new StreamWriter (makeOutpath "Fix44.MessageDU.fs")
    MessageGenerator.GenMessageDU msgsFinal swMsgWriteFuncs

    printfn "generating message factory functions"
    use swMsgFactoryFuncs = new StreamWriter (makeOutpath "Fix44.MessageFactoryFunctions.fs")
    MessageGenerator.GenFactoryFuncs msgsFinal swMsgFactoryFuncs



[<EntryPoint>]
let main args = 

    let cmdLineParams = ParseCmdLine args

    match cmdLineParams with
    | Choice1Of2 (fixSpecXmlFile, outDir) -> GenerateFsFIX (fixSpecXmlFile, outDir)
    | Choice2Of2 errMsg -> 
        printfn "invalid command-line params, %s" errMsg
        printfn "should be - fsFixCodeGen.exe <fixXmlSpecPath> <outputDirPath>"
    0 // exit code
