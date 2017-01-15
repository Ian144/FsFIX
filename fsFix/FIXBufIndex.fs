module FIXBufIndexer

open System


//// when using F# 4.1 consider
////[<Struct>]
////type FieldPos = { Tag:int; Pos:int; Len:int }
//ToString for FieldPos??
//    deconstruct the tag??



let convIntToTagBytes (tagInt:int) = 
    let bs = System.BitConverter.GetBytes tagInt
    bs |> Array.filter (fun bb -> bb <> 0uy)


// the msg index should not be an array of value types, do not the reference chasing and cache misses, hence FieldPos is a struct
type FieldPos =
   struct
      val Tag: int // storing tag as an int32 (ok so long as tags are 4 bytes or less long), an array is a refernce type, this avoids chasing down references
      val Pos: int
      val Len: int
      new(tag:int, pos:int, len:int) = { Tag = tag; Pos = pos; Len = len}
   end
    // this member func is for developer convenience, it should not be called in performance critical code
    override this.ToString() =
        let bs2 = convIntToTagBytes this.Tag
        let tagStr = System.Text.Encoding.UTF8.GetString bs2
        sprintf "%s-%d-%d" tagStr this.Pos this.Len


[< NoComparison; NoEquality>]
type FixBufIndex (endPos: int, fieldPosArr: FieldPos[]) =
    member this.EndPos = endPos
    member this.FieldPosArr = fieldPosArr
    member val LastReadIdx = -1 with get,set


let FindFieldIdx (index:FixBufIndex) (tagInt:int) =
    let mutable ctr = 0
    let mutable foundPos = -1
    let fieldPosArr = index.FieldPosArr
    while (foundPos = -1) do
        if tagInt = fieldPosArr.[ctr].Tag then
            foundPos <- ctr
        ctr <- ctr + 1
    foundPos



let inline convTagToInt (bs:byte[]) (tagBeg:int) (tagEnd:int) =
    let tagLen = tagEnd - tagBeg
    match tagLen with
    | 1     ->   int( bs.[tagBeg] )
    | 2     ->  (int( bs.[tagBeg+1] ) <<< 8 ) +  int( bs.[tagBeg] ) // msb is at the higher indice
    | 3     ->  (int( bs.[tagBeg+2] ) <<< 16) + (int( bs.[tagBeg+1] ) <<< 8 ) +  int( bs.[tagBeg] ) 
    | 4     ->  (int( bs.[tagBeg+3] ) <<< 24) + (int( bs.[tagBeg+2] ) <<< 16) + (int( bs.[tagBeg] ) <<< 8) + int( bs.[tagBeg] ) 
    | n     ->  let msg = sprintf "convTagToInt, invalid tag indices - begin %d, end: %d. Len (end - beg) should be 1, 2, 3 or 4" tagBeg tagEnd
                failwith msg



// i.e. is the tag that of the first field of a len+data field pair
// these ints match the tags of FIX4.4 len+data fields only
// todo: this should be generated for each fix version
let inline IsLenDataCompoundTag (tagInt:int) = 
    match tagInt with
    | 13113 -> true     // signature
    | 12345 -> true     // secureData
    | 13625 -> true     // rawData
    | 3289394 -> true   // xmlData
    | 3683379 -> true   // encodedIssuer
    | 3159347 -> true   // encodedSecurityDesc
    | 3290419 -> true   // encodedListExecInst
    | 3421491 -> true   // encodedText
    | 3552563 -> true   // encodedSubject
    | 3683635 -> true   // encodedHeadline
    | 3159603 -> true   // encodedAllocText
    | 3290675 -> true   // encodedUnderlyingIssuer
    | 3421747 -> true   // encodedUnderlyingSecurityDesc
    | 3486772 -> true   // encodedListStatusText
    | 3682614 -> true   // encodedLegIssuer
    | 3224118 -> true   // encodedLegSecurityDesc
    | _       -> false

// todo: consider inlining, this returns a reference type (would i have to manually inline to avoid the ref type??)
let makeIndexField (bs:byte[]) (pos:int) : (int*FieldPos) = 
    let tagValSepPos = FIXBuf.findNextTagValSep bs pos
    let fldBeg = tagValSepPos + 1
    let tagInt = convTagToInt bs pos tagValSepPos
    if IsLenDataCompoundTag tagInt then
        // eat the next field, including the tag value
        // assuming that it is the correct data field, this will be checked when the msg is read    
        let nextFieldBeg, lenBytes = FIXBuf.readValAfterTagValSep bs (tagValSepPos+1)
        let dataFieldLen = Conversions.bytesToInt32 lenBytes
        let dataFieldTagValSepPos = FIXBuf.findNextTagValSep bs nextFieldBeg
        let endDataFieldPos = dataFieldTagValSepPos + dataFieldLen + 1 // +1 to move one past the end
        let compoundFieldLen = endDataFieldPos - fldBeg
        let fp = new FieldPos(tagInt, fldBeg, compoundFieldLen)        
        endDataFieldPos + 1, fp
    else
        let nextFldOrEnd = FIXBuf.findNextFieldTermOrEnd bs fldBeg
        let fldLen = nextFldOrEnd - fldBeg
        let fp = new FieldPos(tagInt, fldBeg, fldLen)
        nextFldOrEnd + 1, fp


// returns the index one after the last populated
let Index (fieldIndex:FieldPos[]) (bs:byte[]) (posEnd:int) =
    Array.Clear (fieldIndex, 0 ,fieldIndex.Length)
    let mutable pos = 0
    let mutable ctr = 0
    while pos < posEnd do
        let pos2, fp = makeIndexField bs pos
        pos <- pos2
        fieldIndex.[ctr] <- fp
        ctr <- ctr + 1
    ctr


// used for roundtrip property testing, if the index cant be used to reconstruct the original FIX buf then something is broken
let reconstructFromIndex (origBuf:byte[]) (index:FieldPos[]) (indexEnd:int) : byte [] =
    let index = index |> Array.take indexEnd
    let lastEl = index.[indexEnd-1]
    let reconLen = lastEl.Pos + lastEl.Len + 1 // +1 to leave room for the final field seperator
    let reconBuf = Array.zeroCreate<byte> reconLen

    for fp in index do
        // tag
        let tagBs = convIntToTagBytes fp.Tag
        let tagPos = fp.Pos - (tagBs.Length + 1) // +1 to leave room for the tag-value seperator
        Array.Copy( tagBs, 0, reconBuf, tagPos, tagBs.Length )
        
        // tagValue sep
        let tagValSepPos = fp.Pos - 1
        reconBuf.[tagValSepPos] <- 61uy
        
        // field value
        Array.Copy( origBuf, fp.Pos, reconBuf, fp.Pos, fp.Len )

        // field seperator
        let fldSepPos = fp.Pos + fp.Len
        reconBuf.[fldSepPos] <- 1uy
    reconBuf




