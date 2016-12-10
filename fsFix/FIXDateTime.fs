module FIXDateTime





//type DayOfMonth =  D1 | D2 | D3 | D4 | D5 | D6 | D7 | D8 | D9 | D10 | D11 | D12 | D13 | D14 | D15 | D16 | D17 | D18 | D19 | D20 | D21 | D22 | D23 | D24 | D25 | D26 | D27 | D28 | D29 | D30 | D31
//
//type MonthYear = MonthYear of string
//
//type LocalMktDate = { Year:int; Month:int; Day:int }
//
//
//type UTCDate = { Year:int; Month:int; Day:int }




// TIME_ONLY_FORMAT_WITH_MILLISECONDS = "{0:HH:mm:ss.fff}";
// TIME_ONLY_FORMAT_WITHOUT_MILLISECONDS = "{0:HH:mm:ss}";

// Time-only represented in UTC (Universal Time Coordinated, also known as "GMT") in either HH:MM:SS (whole seconds) or HH:MM:SS.sss (milliseconds) format, colons, and period required. 
//Valid values: 
//    HH = 00-23, MM = 00-59, SS = 00-5960 (60 only if UTC leap second) (without milliseconds). 
//    HH = 00-23, MM = 00-59, SS = 00-5960 (60 only if UTC leap second),. sss=000-999 (indicating milliseconds).

type UTCTimeOnly =  private 
                        UTCTimeOnly  of Hours:int * Minutes:int * Seconds:int | 
                        UTCTimeOnlyMs of Hours:int * Minutes:int * Seconds:int * Milliseconds:int

// see https://fsharpforfunandprofit.com/posts/designing-with-types-single-case-dus/

// how function overloading is done in F#
[<AbstractClass;Sealed>]
type MakeUTCTimeOnly private () =
    static member Make (hh:int, mm:int, ss:int) : UTCTimeOnly = 
                    match hh, mm, ss with
                    | 23, 59, 60                                                                            -> UTCTimeOnly(Hours = hh, Minutes = mm, Seconds = ss)  // the leap second case
                    | hh, mm, ss when hh >= 0 && hh <= 23 && mm >= 0 && mm <= 59 && ss >= 00 && ss <= 59    -> UTCTimeOnly(Hours = hh, Minutes = mm, Seconds = ss)
                    | _                                                                                     -> failwith "invalid utc time only"

    static member Make (hh:int, mm:int, ss:int, ms:int): UTCTimeOnly = 
                    match hh, mm, ss, ms with
                    | 23, 59, 60, ms                                                                                                    -> UTCTimeOnlyMs(Hours = hh, Minutes = mm, Seconds = ss, Milliseconds = ms)  // the leap second case
                    | hh, mm, ss, ms when hh >= 0 && hh <= 23 && mm >= 0 && mm <= 59 && ss >= 00 && ss <= 59 && ms >= 00 && ms <= 999   -> UTCTimeOnlyMs(Hours = hh, Minutes = mm, Seconds = ss, Milliseconds = ms)
                    | _                                                                                                                 -> failwith "invalid utc time only"


let ToFIXString tm = 
    match tm with
    | UTCTimeOnly( hh, mm, ss)          ->  sprintf "%02d:%02d:%02d" hh mm ss
    | UTCTimeOnlyMs( hh, mm, ss, ms)    ->  sprintf "%02d:%02d:%02d.%03d" hh mm ss ms



let inline private byte2ToInt (bs:byte[]) (pos:int) : int =
    let d1 = bs.[pos] - 48uy |> int
    let d2 = bs.[pos+1] - 48uy |> int
    d1 * 10 + d2


let inline private byte3ToInt (bs:byte[]) (pos:int) : int =
    let d1 = bs.[pos]   - 48uy |> int
    let d2 = bs.[pos+1] - 48uy |> int
    let d3 = bs.[pos+1] - 48uy |> int
    d1 * 100 * d2 * 10 + d3


let inline private read3ints (bs:byte[]) (begPos:int) = 
    let hh = byte2ToInt bs begPos
    let mm = byte2ToInt bs begPos + 3
    let ss = byte2ToInt bs begPos + 6
    hh, mm, ss


let inline private read4ints (bs:byte[]) (begPos:int) =
    let hh = byte2ToInt bs begPos
    let mm = byte2ToInt bs begPos + 3
    let ss = byte2ToInt bs begPos + 6
    let ms = byte3ToInt bs begPos + 9
    hh, mm, ss, ms


// consider using ArraySegement
let fromBytes (bs:byte[]) (begPos:int) (endPos:int)  : UTCTimeOnly =
    match (endPos - begPos) with
    | 9     ->  let hh, mm, ss = read3ints bs begPos
                MakeUTCTimeOnly.Make (hh, mm, ss)
    | 13    ->  let hh, mm, ss, ms = read4ints bs begPos
                MakeUTCTimeOnly.Make (hh, mm, ss, ms)
    | _     ->  failwith "corrupt serialised UTCTimeOnly"