open System


open System.Xml.Linq
open System.Xml.XPath
open System.IO

open FIXGenTypes
open FieldGenerator





let fixSpecXmlFile = """C:\Users\Ian\Documents\GitHub\quickfixn\spec\fix\FIX44.xml"""



[<EntryPoint>]
let main _ = 
    let fixXml = IO.File.ReadAllText(fixSpecXmlFile)
    let doc = XDocument.Parse fixXml

    let xpthFields = doc.XPathSelectElement "fix/fields"
    use swFixFields = new StreamWriter (Utils.MkOutpath "Fix44.Fields.fs")
    use swFieldReadFuncs = new StreamWriter (Utils.MkOutpath "Fix44.FieldReadFuncs.fs")
    use swFieldWriteFuncs = new StreamWriter (Utils.MkOutpath "Fix44.FieldWriteFuncs.fs")
    use swFieldDU = new StreamWriter (Utils.MkOutpath "Fix44.FieldDU.fs")
    
    printfn "reading and generating FIX field source"
    let fields = FieldGenerator.ParseFieldData xpthFields 
    let lenFieldNames, mergedFields = FieldGenerator.MergeLenFields fields
    FieldGenerator.Gen mergedFields swFixFields swFieldReadFuncs swFieldWriteFuncs  swFieldDU


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
    let components = ComponentGenerator.Read xpthMsgs

    printfn "reading messages"
    let xpthMsgs = doc.XPathSelectElement "fix/messages"
    let msgs = MessageGenerator.Read xpthMsgs

    let hdrItemsAfterGroupMerge, constrainedCompoundItemsInDepOrder, msgsAfterGroupMerge, componentNameMap = CompoundItemProcessor.Process hdr trl components msgs lenFieldNames

    printfn "generating group and component writing functions"
    use swCompoundItems = new StreamWriter (Utils.MkOutpath "Fix44.CompoundItems.fs")
    use swCompoundItemDU = new StreamWriter (Utils.MkOutpath "Fix44.CompoundItemDU.fs")
    CompoundItemGenerator.Gen componentNameMap constrainedCompoundItemsInDepOrder swCompoundItems swCompoundItemDU
    use swGroupWriteFuncs = new StreamWriter (Utils.MkOutpath "Fix44.CompoundItemWriteFuncs.fs")
    do CompoundItemGenerator.GenWriteFuncs constrainedCompoundItemsInDepOrder swGroupWriteFuncs

    printfn "generating group and component reading functions"
    use swGroupReadFuncs = new StreamWriter (Utils.MkOutpath "Fix44.CompoundItemReadFuncs.fs")
    do CompoundItemGenerator.GenReadFuncs fieldNameMap componentNameMap constrainedCompoundItemsInDepOrder swGroupReadFuncs

    printfn "generating F# message definitions"
    use swMsgs = new StreamWriter (Utils.MkOutpath "Fix44.Messages.fs")
    MessageGenerator.Gen msgsAfterGroupMerge swMsgs

    printfn "generating message writer funcs"
    use swMsgWriteFuncs = new StreamWriter (Utils.MkOutpath "Fix44.MsgWriteFuncs.fs")
    MessageGenerator.GenWriteFuncs hdrItemsAfterGroupMerge msgsAfterGroupMerge swMsgWriteFuncs

    printfn "generating message reader funcs"
    use swMsgWriteFuncs = new StreamWriter (Utils.MkOutpath "Fix44.MsgReadFuncs.fs")
    MessageGenerator.GenReadFuncs fieldNameMap componentNameMap hdrItemsAfterGroupMerge msgsAfterGroupMerge swMsgWriteFuncs


    0 // exit code
