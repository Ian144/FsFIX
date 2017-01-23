module QuickFixEchoIssuePropTests


open FsCheck.Xunit
open Swensen.Unquote

open Fix44.Fields
open Fix44.CompoundItems
open Fix44.CompoundItemWriters
open Fix44.CompoundItemDU
open Fix44.MessageDU

open Generators


let bufSize = 1024 * 16 // so as not to go into the LOH
let bs = Array.zeroCreate<byte> bufSize    
let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1024

type PropTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 10000,
        EndSize = 1,
        Verbose = true,
        QuietOnSuccess = true
        )


[<PropTest>]
let ``check all fields have values of non-zero length`` (msg:FIXMessage) = 
    System.Array.Clear (bs, 0, bs.Length)
    System.Array.Clear (fieldPosArr, 0, fieldPosArr.Length)
    let posW = Fix44.MessageDU.WriteMessage bs 0 msg
    let indexEnd = FIXBufIndexer.Index fieldPosArr bs posW
    let index = FIXBufIndexer.FixBufIndex (indexEnd, fieldPosArr)

    let lenDataIndex = fieldPosArr |>  Array.filter (fun xx -> FIXBufIndexer.IsLenDataCompoundTag xx.Tag)
    
    let lenDataFieldValues = lenDataIndex |> Array.map (fun fpData ->
        let lengthFieldTermPos = FIXBuf.findNextFieldTermOrEnd bs fpData.Pos
        let dataFieldLength = Conversions.bytesToInt32 bs fpData.Pos (lengthFieldTermPos - fpData.Pos)
        dataFieldLength, fpData)

    let zeroLenDataFields = lenDataFieldValues |> Array.filter (fun (len, _) -> len = 0) 

    let zeroLenFields = fieldPosArr |> Array.truncate indexEnd |> Array.filter (fun xx -> xx.Len = 0)
    [||] =! zeroLenDataFields
    [||] =! zeroLenFields
    

