module FIXDateTime





//type DayOfMonth =  D1 | D2 | D3 | D4 | D5 | D6 | D7 | D8 | D9 | D10 | D11 | D12 | D13 | D14 | D15 | D16 | D17 | D18 | D19 | D20 | D21 | D22 | D23 | D24 | D25 | D26 | D27 | D28 | D29 | D30 | D31
//
//type MonthYear = MonthYear of string
//
//type LocalMktDate = { Year:int; Month:int; Day:int }


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
//                    override x.ToString() =
//                        match x with
//                        | UTCTimeOnly( hh, mm, ss)          ->  sprintf "%02d:%02d:%02d" hh mm ss
//                        | UTCTimeOnlyMs( hh, mm, ss, ms)    ->  sprintf "%02d:%02d:%02d.%03d" hh mm ss ms




type UTCTimestamp =  private 
                        UTCTimestamp    of Year:int * Month:int * Day:int * Hours:int * Minutes:int * Seconds:int | 
                        UTCTimestampMs  of Year:int * Month:int * Day:int * Hours:int * Minutes:int * Seconds:int * Milliseconds:int



let inline private validate_HHmmss   (hh, mm, ss)       = hh >= 0 && hh <= 23 && mm >= 0 && mm <= 59 && ss >= 0 && ss <= 59
let inline private validate_HHmmss_fff (hh, mm, ss, ms) = validate_HHmmss (hh, mm, ss) && ms >= 0 && ms <= 999
let inline private validate_yyyyMMdd (yy, mm, dd)       = yy >= 0 && yy <= 9999 && 1 >= 0 && mm <= 12 && dd >= 01 && dd <= 31 

let inline private validate_yyyyMMdd_HHmmss_fff (yy, mth, dd, hh, mm, ss, ms)   = validate_yyyyMMdd (yy, mth, dd) && validate_HHmmss_fff(hh, mm, ss, ms)
let inline private validate_yyyyMMdd_HHmmss   (yy, mth, dd, hh, mm, ss)         = validate_yyyyMMdd (yy, mth, dd) && validate_HHmmss(hh, mm, ss)


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
                    | yy, mth, dd, hh, mm, ss, ms when validate_yyyyMMdd_HHmmss_fff (yy, mth, dd, hh, mm, ss, ms)   ->  UTCTimestampMs(Year = yy, Month = mth, Day = dd, Hours = hh, Minutes = mm, Seconds = ss, Milliseconds = ms)
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
                    | hh, mm, ss, ms when validate_HHmmss_fff (hh, mm, ss, ms)  -> UTCTimeOnlyMs(Hours = hh, Minutes = mm, Seconds = ss, Milliseconds = ms)
                    | _                                                         -> failwith "invalid UTCTimeOnly"





let inline private write2ByteInt (bs:byte[]) (pos:int) (n:int) : unit =
    let d1 = (n / 10) 
    let d2 = n - (d1 * 10)
    let b1 = (d1 + 48) |> byte
    let b2 = (d2 + 48) |> byte
    bs.[pos  ] <- b1
    bs.[pos+1] <- b2


let inline private write3ByteInt (bs:byte[]) (pos:int) (n:int) : unit =
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



let inline private write4ByteInt (bs:byte[]) (pos:int) (n:int) : unit =
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





let inline private bytes2ToInt (bs:byte[]) (pos:int) : int =
    let d1 = bs.[pos] - 48uy |> int
    let d2 = bs.[pos+1] - 48uy |> int
    d1 * 10 + d2



let inline private bytes3ToInt (bs:byte[]) (pos:int) : int =
    let d1 = bs.[pos]   - 48uy |> int
    let d2 = bs.[pos+1] - 48uy |> int
    let d3 = bs.[pos+2] - 48uy |> int
    d1 * 100 + d2 * 10 + d3

let inline private bytes4ToInt (bs:byte[]) (pos:int) : int =
    let d1 = bs.[pos]   - 48uy |> int
    let d2 = bs.[pos+1] - 48uy |> int
    let d3 = bs.[pos+2] - 48uy |> int
    let d4 = bs.[pos+3] - 48uy |> int
    d1 * 1000 + d2 * 100 + d3 * 10 + d4


let inline private readHHMMSSints (bs:byte[]) (begPos:int) = 
    let hh = bytes2ToInt bs begPos
    let mm = bytes2ToInt bs (begPos + 3)
    let ss = bytes2ToInt bs (begPos + 6)
    hh, mm, ss


let inline private readHHMMSSMS (bs:byte[]) (begPos:int) =
    let hh = bytes2ToInt bs begPos
    let mm = bytes2ToInt bs (begPos + 3)
    let ss = bytes2ToInt bs (begPos + 6)
    let ms = bytes3ToInt bs (begPos + 9)
    hh, mm, ss, ms



let inline private readTimestampInts (bs:byte[]) (begPos:int) = 
    let yy  = bytes4ToInt bs begPos
    let mth = bytes2ToInt bs (begPos + 4)
    let dd  = bytes2ToInt bs (begPos + 6)
    let hh  = bytes2ToInt bs (begPos + 9)
    let mm  = bytes2ToInt bs (begPos + 12)
    let ss  = bytes2ToInt bs (begPos + 15)
    yy, mth, dd, hh, mm, ss


let inline private readTimestampMsInts (bs:byte[]) (begPos:int) =
    let yy  = bytes4ToInt bs begPos
    let mth = bytes2ToInt bs (begPos + 4)
    let dd  = bytes2ToInt bs (begPos + 6)
    let hh  = bytes2ToInt bs (begPos + 9)
    let mm  = bytes2ToInt bs (begPos + 12)
    let ss  = bytes2ToInt bs (begPos + 15)
    let ms  = bytes3ToInt bs (begPos + 18)
    yy, mth, dd, hh, mm, ss, ms


let inline private readYYYYmmDDints (bs:byte[]) (begPos:int) =
    let yy = bytes4ToInt bs begPos
    let mm = bytes2ToInt bs (begPos + 4)
    let dd = bytes2ToInt bs (begPos + 6)
    yy, mm, dd



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

