module FIXBufSplitter

open System


// when using F# 4.1 consider
//[<Struct>]
//type FieldPos = { Tag:int; Pos:int; Len:int }

type FieldPos =
   struct
      val Tag: int
      val Pos: int
      val Len: int
      new(tag:int, pos:int, len:int) = { Tag = tag; Pos = pos; Len = len}
   end



// store tag as the tag bytes converted to 

let Split (bs:byte[]) : FieldPos[] =
    [||]



