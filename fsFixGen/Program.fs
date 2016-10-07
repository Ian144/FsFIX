open System


open System.Xml.Linq
open System.Xml.XPath
open System.IO

open FIXGenTypes
open FieldGenerator






let fixSpecXmlFile = """C:\Users\Ian\Documents\GitHub\quickfixn\spec\fix\FIX44.xml"""


let MkOutpath flName = 
    sprintf """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\%s""" flName





[<EntryPoint>]
let main _ = 

    let fixXml = IO.File.ReadAllText(fixSpecXmlFile)
    let doc = XDocument.Parse fixXml

    let xpthFields = doc.XPathSelectElement "fix/fields"
    use swFixFields = new StreamWriter (MkOutpath "Fix44.Fields.fs")
    use swFieldReadWriteFuncs = new StreamWriter (MkOutpath "Fix44.FieldReadWriteFuncs.fs")
    
    printfn "reading and generating FIX field source"
    let fieldData = FieldGenerator.ParseFieldData2 xpthFields 
    let lenFieldNames, mergedFields = FieldGenerator.MergeLenFields fieldData
    FieldGenerator.Gen mergedFields swFixFields swFieldReadWriteFuncs

    printfn "reading components"
    let xpthMsgs = doc.XPathSelectElement "fix/components"
    let cmps = ComponentGenerator.Read xpthMsgs

    printfn "reading messages"
    let xpthMsgs = doc.XPathSelectElement "fix/messages"
    let msgs = MessageGenerator.Read xpthMsgs

    // groups are defined in component and message elements.
    // groups can contain sub-groups.
    // groups with the same name in different messages or components may or may not contain the same fields.
    // groups with the same name containing the same fields and subgroups should be merged into a single group.
    // groups which are a dependency of other groups should appear before the other groups in the f# souce file, or there will be a compile error.
    printfn "processing groups"
    let cmpGrps = GroupUtils.extractLevel1GroupsFromComponents cmps
    let msgGrps = GroupUtils.extractLevel1GroupsFromMsgs msgs
    let allGrps = cmpGrps @ msgGrps
    let depOrderGroups = GroupGenerator.GetGroupsInDependencyOrder allGrps

    printfn "generating group source"
    use swGroups = new StreamWriter (MkOutpath "Fix44.Groups.fs")
    use swGroupWriteFuncs = new StreamWriter (MkOutpath "Fix44.GroupWriteFuncs.fs")
    use swGroupFactoryFuncs = new StreamWriter (MkOutpath "Fix44.GroupFactoryFuncs.fs")
    GroupGenerator.Gen depOrderGroups swGroups swGroupWriteFuncs

//    GroupGenerator.GenFactoryFuncs depOrderGroups swGroupFactoryFuncs


    0 // return an integer exit code
