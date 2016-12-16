module FIXDateTime

open DateTimeUtils


//type MonthYear = MonthYear of string
//
//type LocalMktDate = { Year:int; Month:int; Day:int }







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
                   


// string field representing Date represented in UTC (Universal Time Coordinated, also known as "GMT") in YYYYMMDD format. 
// This special-purpose field is paired with UTCTimeOnly to form a proper UTCTimestamp for bandwidth-sensitive messages.
// Valid values:
// YYYY = 0000-9999, MM = 01-12, DD = 01-31.
type UTCDate = private UTCDate of Year:int * Month:int * Day:int 


// Time-only represented in UTC (Universal Time Coordinated, also known as "GMT") in either HH:MM:SS (whole seconds) or HH:MM:SS.sss (milliseconds) format, colons, and period required. 
//Valid values: 
//    HH = 00-23, MM = 00-59, SS = 00-5960 (60 only if UTC leap second) (without milliseconds). 
//    HH = 00-23, MM = 00-59, SS = 00-5960 (60 only if UTC leap second),. sss=000-999 (indicating milliseconds).
type UTCTimeOnly =  private 
                        UTCTimeOnly  of Hours:int * Minutes:int * Seconds:int | 
                        UTCTimeOnlyMs of Hours:int * Minutes:int * Seconds:int * Milliseconds:int


type UTCTimestamp =  private 
                        UTCTimestamp    of Year:int * Month:int * Day:int * Hours:int * Minutes:int * Seconds:int | 
                        UTCTimestampMs  of Year:int * Month:int * Day:int * Hours:int * Minutes:int * Seconds:int * Milliseconds:int



let inline validate_HHmmss (hh, mm, ss)         = hh >= 0 && hh <= 23 && mm >= 0 && mm <= 59 && ss >= 0 && ss <= 59
let inline validate_HHmmss_sss (hh, mm, ss, ms) = validate_HHmmss (hh, mm, ss) && ms >= 0 && ms <= 999
let inline validate_yyyyMMdd (yy, mm, dd)       = yy >= 0 && yy <= 9999 && 1 >= 0 && mm <= 12 && dd >= 01 && dd <= 31 

let inline validate_yyyyMMdd_HHmmss_sss (yy, mth, dd, hh, mm, ss, ms)   = validate_yyyyMMdd (yy, mth, dd) && validate_HHmmss_sss(hh, mm, ss, ms)
let inline validate_yyyyMMdd_HHmmss   (yy, mth, dd, hh, mm, ss)         = validate_yyyyMMdd (yy, mth, dd) && validate_HHmmss(hh, mm, ss)

let inline validate_HHmm (hh, mm) = hh >= 0 && hh <= 23 && mm >= 0 && mm <= 59




// function overloading in F#
[<AbstractClass;Sealed>]
type MakeUTCTimestamp private () =
    static member Make (yy:int, mth:int, dd:int, hh:int, mm:int, ss:int) : UTCTimestamp = 
                    match yy, mth, dd, hh, mm, ss with
                    | yy, mth, dd, 23, 59, 60 when validate_yyyyMMdd (yy, mth, dd)                      -> UTCTimestamp (Year = yy, Month = mth, Day = dd, Hours = hh, Minutes = mm, Seconds = ss)  // the leap second case
                    | yy, mth, dd, hh, mm, ss when validate_yyyyMMdd_HHmmss (yy, mth, dd, hh, mm, ss)   -> UTCTimestamp (Year = yy, Month = mth, Day = dd, Hours = hh, Minutes = mm, Seconds = ss)
                    | _                                                                                 -> let msg = sprintf "invalid UTCTimestamp, %04d%02d%02d-%02d%02d%02d" yy mth dd hh mm ss
                                                                                                           failwith msg

    static member Make (yy:int, mth:int, dd:int, hh:int, mm:int, ss:int, ms:int): UTCTimestamp = 
                    match yy, mth, dd, hh, mm, ss, ms with
                    | yy, mth, dd, 23, 59, 60, ms when validate_yyyyMMdd (yy, mth, dd) && ms >= 0 && ms <= 999      ->  UTCTimestampMs(Year = yy, Month = mth, Day = dd, Hours = hh, Minutes = mm, Seconds = ss, Milliseconds = ms)  // the leap second case
                    | yy, mth, dd, hh, mm, ss, ms when validate_yyyyMMdd_HHmmss_sss (yy, mth, dd, hh, mm, ss, ms)   ->  UTCTimestampMs(Year = yy, Month = mth, Day = dd, Hours = hh, Minutes = mm, Seconds = ss, Milliseconds = ms)
                    | _                                                                                             ->  let msg = sprintf "invalid UTCTimestamp, %04d%02d%02d-%02d%02d%02d.%03d" yy mth dd hh mm ss ms
                                                                                                                        failwith msg



let MakeUTCDate (yy:int, mm:int, dd:int) : UTCDate = 
                    match yy, mm with
                    | yy, mm when validate_yyyyMMdd (yy, mm, dd)    -> UTCDate( Year = yy, Month = mm, Day = dd )
                    | _                                             -> failwith "invalid UTCDateOnly"


// function overloading in F#
[<AbstractClass;Sealed>]
type MakeUTCTimeOnly private () =
    static member Make (hh:int, mm:int, ss:int) : UTCTimeOnly = 
                    match hh, mm, ss with
                    | 23, 59, 60                                    -> UTCTimeOnly(Hours = hh, Minutes = mm, Seconds = ss)  // the leap second case
                    | hh, mm, ss when validate_HHmmss (hh,mm,ss)    -> UTCTimeOnly(Hours = hh, Minutes = mm, Seconds = ss)
                    | _                                             -> failwith "invalid UTCTimeOnly"

    static member Make (hh:int, mm:int, ss:int, ms:int): UTCTimeOnly = 
                    match hh, mm, ss, ms with
                    | 23, 59, 60, ms                                            -> UTCTimeOnlyMs(Hours = hh, Minutes = mm, Seconds = ss, Milliseconds = ms)  // the leap second case
                    | hh, mm, ss, ms when validate_HHmmss_sss (hh, mm, ss, ms)  -> UTCTimeOnlyMs(Hours = hh, Minutes = mm, Seconds = ss, Milliseconds = ms)
                    | _                                                         -> failwith "invalid UTCTimeOnly"






// time only format with milliseconds = "HH:mm:ss.fff";
// time only format without milliseconds = "HH:mm:ss";
let writeUTCTimeOnly (tm:UTCTimeOnly) (bs:byte[]) (pos:int) : int =
    match tm with
    | UTCTimeOnly (hh, mm, ss)          ->  
            write2ByteInt bs pos hh
            bs.[pos + 2] <- 58uy // write the ':'
            write2ByteInt bs (pos + 3) mm
            bs.[pos + 5] <- 58uy // write the ':'
            write2ByteInt bs (pos + 6) ss
            pos + 8
    | UTCTimeOnlyMs (hh, mm, ss, ms)    ->  
            write2ByteInt bs pos hh
            bs.[pos + 2] <- 58uy // write the ':'
            write2ByteInt bs (pos + 3) mm
            bs.[pos + 5] <- 58uy // write the ':'
            write2ByteInt bs (pos + 6) ss
            bs.[pos + 8] <- 46uy // write the '.'
            write3ByteInt bs (pos + 9) ms
            pos + 12


let readUTCTimeOnly (bs:byte[]) (begPos:int) (endPos:int) : UTCTimeOnly =
    match (endPos - begPos) with
    | 8     ->  let hh, mm, ss = readHHMMSSints bs begPos
                MakeUTCTimeOnly.Make (hh, mm, ss)
    | 12    ->  let hh, mm, ss, ms = readHHMMSSMS bs begPos
                MakeUTCTimeOnly.Make (hh, mm, ss, ms)
    | _     ->  failwith "corrupt serialised UTCTimeOnly"



//let writeBytesUTCDate (tm:UTCDate) (bs:byte[]) (pos:int) : int =
//    let UTCDate (yyyy, mm, dd) = tm
//    write2ByteInt bs pos yyyy
//    write2ByteInt bs (pos + 4) mm
//    write2ByteInt bs (pos + 6) dd
//    pos + 8

//  DATE_ONLY_FORMAT = "yyyyMMdd";
let writeUTCDate (dt:UTCDate) (bs:byte[]) (pos:int) : int =
    match dt with 
    | UTCDate (yyyy, mm, dd) -> 
        write4ByteInt bs pos yyyy
        write2ByteInt bs (pos + 4) mm
        write2ByteInt bs (pos + 6) dd
        pos + 8

let readUTCDate (bs:byte[]) (begPos:int) (endPos:int)  : UTCDate =
    let yyyy, mm, dd = readYYYYmmDDints bs begPos
    MakeUTCDate (yyyy, mm, dd)



//public const string DATE_TIME_FORMAT_WITH_MILLISECONDS = "{0:yyyyMMdd-HH:mm:ss.fff}";
//public const string DATE_TIME_FORMAT_WITHOUT_MILLISECONDS = "{0:yyyyMMdd-HH:mm:ss}";
let writeUTCTimestamp (tm:UTCTimestamp) (bs:byte[]) (pos:int) : int =
    match tm with
    | UTCTimestamp (yy, mth, dd, hh, mm, ss)          ->
            write4ByteInt bs pos yy
            write2ByteInt bs (pos + 4) mth
            write2ByteInt bs (pos + 6) dd      
            bs.[pos + 8] <- 45uy // write the '-'
            write2ByteInt bs (pos + 9) hh
            bs.[pos + 11] <- 58uy // write the ':'
            write2ByteInt bs (pos + 12) mm
            bs.[pos + 14] <- 58uy // write the ':'
            write2ByteInt bs (pos + 15) ss
            pos + 17
    | UTCTimestampMs (yy, mth, dd, hh, mm, ss, ms)    ->  
            write4ByteInt bs pos yy
            write2ByteInt bs (pos + 4) mth
            write2ByteInt bs (pos + 6) dd      
            bs.[pos + 8] <- 45uy // write the '-'
            write2ByteInt bs (pos + 9) hh
            bs.[pos + 11] <- 58uy // write the ':'
            write2ByteInt bs (pos + 12) mm
            bs.[pos + 14] <- 58uy // write the ':'
            write2ByteInt bs (pos + 15) ss
            bs.[pos + 17] <- 46uy // write the '.'
            write3ByteInt bs (pos + 18) ms
            pos + 21


let readUTCTimestamp (bs:byte[]) (begPos:int) (endPos:int) : UTCTimestamp =
    match (endPos - begPos) with
    | 17    ->  let yy, mth, dd, hh, mm, ss = readTimestampInts bs begPos
                MakeUTCTimestamp.Make (yy, mth, dd, hh, mm, ss)
    | 21    ->  let yy, mth, dd, hh, mm, ss, ms = readTimestampMsInts bs begPos
                MakeUTCTimestamp.Make (yy, mth, dd, hh, mm, ss, ms)
    | _     ->  failwith "corrupt serialised UTCTimeOnly"

