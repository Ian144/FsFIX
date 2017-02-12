open System


open System.Xml.Linq
open System.Xml.XPath
open System.IO

open FIXGenTypes
open FieldGenerator





//let fixSpecXmlFile = """C:\Users\Ian\Documents\GitHub\fsFixGen\FIX44.modified.xml"""
let fixSpecXmlFile = """C:\Users\Ian\Documents\GitHub\quickfixj\quickfixj-messages\quickfixj-messages-fix44\src\main\resources\FIX44.modified.xml"""
//let fixSpecXmlFile = """C:\Users\Ian\Documents\GitHub\quickfixj\quickfixj-messages\quickfixj-messages-all\target\classes\FIX50.xml"""
//let fixSpecXmlFile = """C:\Users\Ian\Documents\GitHub\quickfixj\quickfixj-core\target\classes\FIX50SP2.xml"""

[<EntryPoint>]
let main args = 

    if args.Length = 0 then
        failwith "must specify output dir for generated F#"
    
    let outDir = args.[0]

    //let MkOutpath flName = sprintf """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\%s""" flName
    let makeOutpath flName = sprintf """%sfsFix\%s""" outDir flName


    let fixXml = IO.File.ReadAllText(fixSpecXmlFile)
    let doc = XDocument.Parse fixXml

    let xpthFields = doc.XPathSelectElement "fix/fields"
    let tmp = (makeOutpath "Fix44.Fields.fs")
    use swFixFields = new StreamWriter (makeOutpath "Fix44.Fields.fs")
    use swFieldReadFuncs = new StreamWriter (makeOutpath "Fix44.FieldReaders.fs")
    use swFieldWriteFuncs = new StreamWriter (makeOutpath "Fix44.FieldWriters.fs")
    
    printfn "reading and generating FIX field source"
    let fields = FieldGenerator.ParseFieldData xpthFields 
    let lenFieldNames, mergedFields = FieldGenerator.MergeLenFields fields
    FieldGenerator.Gen mergedFields swFixFields swFieldReadFuncs swFieldWriteFuncs


    let getFieldName (fld:Field) =
        match fld with
        | SimpleField sf -> sf.Name
        | CompoundField cf -> cf.Name

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


    let msgsx = 
        [   for msg in msgsAfterGroupMerge do
            let items2 = msg.Items |> List.collect (CompoundItemRules.makeOptionalComponentsRequiredIfTheyContainOnlyOptionalSubItemsInner componentNameMap)
            yield {msg with Items = items2} ]

    printfn "generating F# message definitions"
    use swMsgs = new StreamWriter (makeOutpath "Fix44.Messages.fs")
    MessageGenerator.Gen msgsx swMsgs

    printfn "generating message writer funcs"
    use swMsgWriteFuncs = new StreamWriter (makeOutpath "Fix44.MsgWriters.fs")
    MessageGenerator.GenWriteFuncs hdrItemsAfterGroupMerge msgsx swMsgWriteFuncs

    printfn "generating message reader funcs"
    use swMsgWriteFuncs = new StreamWriter (makeOutpath "Fix44.MsgReaders.fs")
    MessageGenerator.GenReadFuncs fieldNameMap componentNameMap hdrItemsAfterGroupMerge msgsx swMsgWriteFuncs

    printfn "generating message DU"
    use swMsgWriteFuncs = new StreamWriter (makeOutpath "Fix44.MessageDU.fs")
    MessageGenerator.GenMessageDU msgsx swMsgWriteFuncs

    0 // exit code
