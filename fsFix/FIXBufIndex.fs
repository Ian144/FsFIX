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
        let ss = sprintf "%s, %d-%d" tagStr this.Pos this.Len
//        let ss = sprintf "FIXBufIndexer.FieldPos(%d, %d, %d)" this.Tag this.Pos this.Len
        ss





let convTagToInt (bs:byte[]) (tagBeg:int) (tagEnd:int) =
    let tmp = Array.zeroCreate<byte> 4 // todo: consider passing tmp array in as a param, can then reuse
    let tagLen = tagEnd - tagBeg
    match tagLen with
    | 1     ->  tmp.[0] <- bs.[tagBeg]
    | 2     ->  tmp.[0] <- bs.[tagBeg]
                tmp.[1] <- bs.[tagBeg+1]
    | 3     ->  tmp.[0] <- bs.[tagBeg]
                tmp.[1] <- bs.[tagBeg+1]
                tmp.[2] <- bs.[tagBeg+2]
    | 4     ->  tmp.[0] <- bs.[tagBeg]
                tmp.[1] <- bs.[tagBeg+1]
                tmp.[2] <- bs.[tagBeg+2]
                tmp.[3] <- bs.[tagBeg+3]
    | n     ->  let msg = sprintf "convTagToInt, invalid tag indices - begin %d, end: %d. Len (end - beg) should be 2 or 3" tagBeg tagEnd
                failwith msg
    System.BitConverter.ToInt32 (tmp, 0)



let makeIndexField (bs:byte[]) (pos:int) : (int*FieldPos) = 
    let tagValSep = FIXBuf.findNextTagValSep bs pos
    let tagInt = convTagToInt bs pos tagValSep
    let fldBeg = tagValSep + 1
    let nextFldOrEnd = FIXBuf.findNextFieldTermOrEnd bs fldBeg
    let fldLen = nextFldOrEnd - fldBeg
    let fp = new FieldPos(tagInt, fldBeg, fldLen)
    nextFldOrEnd + 1, fp

// create large array of empty FieldPos's
let Index (bs:byte[]) : FieldPos[] =
    let mutable countFieldSep = 0
    
    for ctr i= 0 to (bs.Length - 1) do
        // if next tag is a len+data then read len and jump to end of data

        if bs.[ctr] = 1uy then
            countFieldSep <- countFieldSep + 1
    let numFields = countFieldSep + 1

    // todo: is this creating objects? 
    let fieldIndex = Array.zeroCreate<FieldPos> numFields 

    let mutable pos = 0
    let mutable ctr = 0
    while pos < bs.Length do
        let pos2, fp = makeIndexField bs pos
        pos <- pos2
        fieldIndex.[ctr] <- fp
        ctr <- ctr + 1
    fieldIndex



// used for roundtrip property testing, if the index cant be used to reconstruct the original array then something is broken
let reconstructFromIndex (origBuf:byte[]) (index:FieldPos[]) : byte [] =
    let lastIndexElementIdx = index.Length - 1
    let lastEl = index.[lastIndexElementIdx]
    let reconLen = lastEl.Pos + lastEl.Len
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
        if fldSepPos < reconLen then
            reconBuf.[fldSepPos] <- 1uy
    reconBuf




