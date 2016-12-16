module DateTimeUtils





let inline write2ByteInt (bs:byte[]) (pos:int) (n:int) : unit =
    let d1 = (n / 10) 
    let d2 = n - (d1 * 10)
    let b1 = (d1 + 48) |> byte
    let b2 = (d2 + 48) |> byte
    bs.[pos  ] <- b1
    bs.[pos+1] <- b2


let inline write3ByteInt (bs:byte[]) (pos:int) (n:int) : unit =
    let d1 = (n / 100) 
    let n2 = n - (d1 * 100) 
    let d2 = n2 / 10
    let d3 = n2 - (d2 * 10)
    let b1 = (d1 + 48) |> byte
    let b2 = (d2 + 48) |> byte
    let b3 = (d3 + 48) |> byte
    bs.[pos  ] <- b1
    bs.[pos+1] <- b2
    bs.[pos+2] <- b3



let inline write4ByteInt (bs:byte[]) (pos:int) (n:int) : unit =
    let d1 = (n / 1000) 
    let n2 = n - (d1 * 1000) 
    let d2 = n2 / 100
    let n3 = n2 - (d2 * 100)
    let d3 = n3 / 10
    let d4 = n3 - (d3 * 10)
    let b1 = (d1 + 48) |> byte
    let b2 = (d2 + 48) |> byte
    let b3 = (d3 + 48) |> byte
    let b4 = (d4 + 48) |> byte
    bs.[pos  ] <- b1
    bs.[pos+1] <- b2
    bs.[pos+2] <- b3
    bs.[pos+3] <- b4





let inline bytes2ToInt (bs:byte[]) (pos:int) : int =
    let d1 = bs.[pos] - 48uy |> int
    let d2 = bs.[pos+1] - 48uy |> int
    d1 * 10 + d2



let inline bytes3ToInt (bs:byte[]) (pos:int) : int =
    let d1 = bs.[pos]   - 48uy |> int
    let d2 = bs.[pos+1] - 48uy |> int
    let d3 = bs.[pos+2] - 48uy |> int
    d1 * 100 + d2 * 10 + d3

let inline bytes4ToInt (bs:byte[]) (pos:int) : int =
    let d1 = bs.[pos]   - 48uy |> int
    let d2 = bs.[pos+1] - 48uy |> int
    let d3 = bs.[pos+2] - 48uy |> int
    let d4 = bs.[pos+3] - 48uy |> int
    d1 * 1000 + d2 * 100 + d3 * 10 + d4


let inline readHHMMSSints (bs:byte[]) (begPos:int) = 
    let hh = bytes2ToInt bs begPos
    let mm = bytes2ToInt bs (begPos + 3)
    let ss = bytes2ToInt bs (begPos + 6)
    hh, mm, ss


let inline readHHMMSSMS (bs:byte[]) (begPos:int) =
    let hh = bytes2ToInt bs begPos
    let mm = bytes2ToInt bs (begPos + 3)
    let ss = bytes2ToInt bs (begPos + 6)
    let ms = bytes3ToInt bs (begPos + 9)
    hh, mm, ss, ms



let inline readTimestampInts (bs:byte[]) (begPos:int) = 
    let yy  = bytes4ToInt bs begPos
    let mth = bytes2ToInt bs (begPos + 4)
    let dd  = bytes2ToInt bs (begPos + 6)
    let hh  = bytes2ToInt bs (begPos + 9)
    let mm  = bytes2ToInt bs (begPos + 12)
    let ss  = bytes2ToInt bs (begPos + 15)
    yy, mth, dd, hh, mm, ss


let inline readTimestampMsInts (bs:byte[]) (begPos:int) =
    let yy  = bytes4ToInt bs begPos
    let mth = bytes2ToInt bs (begPos + 4)
    let dd  = bytes2ToInt bs (begPos + 6)
    let hh  = bytes2ToInt bs (begPos + 9)
    let mm  = bytes2ToInt bs (begPos + 12)
    let ss  = bytes2ToInt bs (begPos + 15)
    let ms  = bytes3ToInt bs (begPos + 18)
    yy, mth, dd, hh, mm, ss, ms


let inline readYYYYmmDDints (bs:byte[]) (begPos:int) =
    let yy = bytes4ToInt bs begPos
    let mm = bytes2ToInt bs (begPos + 4)
    let dd = bytes2ToInt bs (begPos + 6)
    yy, mm, dd