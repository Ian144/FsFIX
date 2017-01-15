module UTCDateTime

open FIXDateTime





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

