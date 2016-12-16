module TZDateTime

open DateTimeUtils




// TZTimeOnly 
// string field representing the time represented based on ISO 8601. This is the time with a UTC offset to allow identification of local time and timezone of that time.
// Format is HH:MM[:SS][Z [ + - hh[:mm]]] where HH = 00-23 hours, MM = 00-59 minutes, SS = 00-59 seconds, hh = 01-12 offset hours, mm = 00-59 offset minutes.
// Example: 07:39Z is 07:39 UTC
// Example: 02:39-05 is five hours behind UTC, thus Eastern Time
// Example: 15:39+08 is eight hours ahead of UTC, Hong Kong/Singapore time
// Example: 13:09+05:30 is 5.5 hours ahead of UTC, India time
//
// oddly documentation does not mention leap seconds
type TZOffset = private
                    | UTC
                    | PosOffsetHH of Hours:int 
                    | NegOffsetHH of Hours:int
                    | PosOffsetHHmm of Hours:int * Minutes:int 
                    | NegOffsetHHmm of Hours:int * Minutes:int 
                    override this.ToString() = 
                        match this with
                        | UTC                   -> "UTC"
                        | PosOffsetHH hh        -> sprintf "PosOffsetHH %d" hh
                        | NegOffsetHH hh        -> sprintf "NegOffsetHH %d" hh
                        | PosOffsetHHmm (hh,mm) -> sprintf "PosOffsetHHmm %d:%d" hh mm
                        | NegOffsetHHmm (hh,mm) -> sprintf "NegOffsetHHmm %d:%d" hh mm

type TZTimeOnly =  private 
                    | TZTimeOnly    of Offset:TZOffset * Hours:int * Minutes:int
                    | TZTimeOnlySS  of Offset:TZOffset * Hours:int * Minutes:int * Seconds:int



[<AbstractClass;Sealed>]
type MakeTZOffset private () =
    static member Make (dir:byte) = 
        match dir with 
        | 90uy  ->  TZOffset.UTC    // match 'Z'
        | _     ->  let msg = sprintf "invalid TZOffset %c" (System.Convert.ToChar dir)
                    failwith msg

    static member Make (dir:byte, hh:int) = 
                    let valid = hh > 0 && hh <= 12 
                    match dir, valid with
                    | 43uy, true    ->  PosOffsetHH hh // +
                    | 45uy, true    ->  NegOffsetHH hh // -
                    | _,    _       ->  let msg = sprintf "invalid TZOffset, %c-%d" (System.Convert.ToChar dir) hh
                                        failwith msg
    static member Make (dir:byte, hh:int, mm:int) = 
                    let valid = hh > 0 && hh <= 12 && mm >= 0 && mm < 60
                    match dir, valid with
                    | 43uy,  true   ->  PosOffsetHHmm ( hh, mm) // +
                    | 45uy,  true   ->  NegOffsetHHmm ( hh, mm) // -
                    | _,    _       ->  let msg = sprintf "invalid TZOffset, %c-%d:%d" (System.Convert.ToChar dir) hh mm
                                        failwith msg





let readTZOffset (bs:byte[]) (pos:int) =
    let inline readZ (bs:byte[]) (pos:int) = // assume Z|+|- is at pos
        let zone = bs.[pos]
        zone
    let inline readZHH (bs:byte[]) (pos:int) = // assume Z|+|- is at pos, HH
        let zone = bs.[pos]
        let hhD1 = bs.[pos+1] - 48uy |> int
        let hhD2 = bs.[pos+2] - 48uy |> int
        let hh = hhD1 * 10 + hhD2
        zone, hh
    let inline readZHHmm (bs:byte[]) (pos:int) = // assume Z|+|- is at pos, HH MM
        let zone = bs.[pos]
        let hhD1 = bs.[pos+1] - 48uy |> int
        let hhD2 = bs.[pos+2] - 48uy |> int
        let mmD1 = bs.[pos+4] - 48uy |> int
        let mmD2 = bs.[pos+5] - 48uy |> int
        let hh = hhD1 * 10 + hhD2
        let mm = mmD1 * 10 + mmD2
        zone, hh, mm
    let nextFieldSepOrEnd = FIXBufUtils.findNextFieldTermOrEnd pos bs
    let offsetLen = nextFieldSepOrEnd - pos
    match offsetLen with
    | 1 ->  let zone = readZ bs pos
            let offset = MakeTZOffset.Make zone
            nextFieldSepOrEnd, offset
    | 3 ->  let zone, hh = readZHH bs pos
            let offset = MakeTZOffset.Make (zone, hh)
            nextFieldSepOrEnd, offset
    | 6 ->  let zone, hh, mm = readZHHmm bs pos
            let offset = MakeTZOffset.Make (zone, hh, mm)
            nextFieldSepOrEnd, offset
    | _ ->  let msg = sprintf "invalid TZOffset length: %d" offsetLen
            failwith msg 


let writeTZOffset (bs:byte[]) (pos:int) (offSet:TZOffset) : int =
    match offSet with 
    | UTC                       ->  bs.[pos] <- 90uy; (pos + 1)
    | PosOffsetHH hh            ->  bs.[pos] <- 43uy
                                    DateTimeUtils.write2ByteInt bs (pos+1) hh
                                    (pos + 3)
    | NegOffsetHH hh            ->  bs.[pos] <- 45uy
                                    DateTimeUtils.write2ByteInt bs (pos+1) hh
                                    (pos + 3)
    | NegOffsetHHmm (hh, mm)    ->  bs.[pos] <- 45uy
                                    DateTimeUtils.write2ByteInt bs (pos+1) hh
                                    bs.[pos+3] <- 58uy
                                    DateTimeUtils.write2ByteInt bs (pos+4) mm
                                    (pos + 6)
    | PosOffsetHHmm (hh, mm)    ->  bs.[pos] <- 43uy
                                    DateTimeUtils.write2ByteInt bs (pos+1) hh
                                    bs.[pos+3] <- 58uy
                                    DateTimeUtils.write2ByteInt bs (pos+4) mm
                                    (pos + 6)




[<AbstractClass;Sealed>]
type MakeTZTimeOnly private () =
    static member Make (offset:TZOffset, hh:int, mm:int) =
        let valid = hh >= 0 && hh <= 23 && mm >= 0 && mm <= 59
        match valid with
        | true  -> TZTimeOnly (offset, hh, mm)
        | false -> let msg = sprintf "invalid TZTimeOnly, %d:%d" hh mm
                   failwith msg
                   
    static member Make (offset:TZOffset, hh:int, mm:int, ss:int) =
        let valid = hh >= 0 && hh <= 23 && mm >= 0 && mm <= 59 && ss >= 0 && ss <= 59
        match valid with
        | true  -> TZTimeOnlySS (offset, hh, mm, ss)
        | false -> let msg = sprintf "invalid TZTimeOnly, %d:%d:%d" hh mm ss
                   failwith msg
                   

