module MonthYear

open DateTimeUtils



// http://www.fixtradingcommunity.org/FIXimate/FIXimate3.0/en/FIX.4.4/fix_datatypes.html
//string field representing month of a year. An optional day of the month can be appended or an optional week code.
//Valid formats:
//  YYYYMM
//  YYYYMMDD
//  YYYYMMWW
//Valid values:
//  YYYY = 0000-9999
//  MM = 01-12; 
//  DD = 01-31; 
//  WW = w1, w2, w3, w4, w5.


type Week = W1 | W2 | W3 | W4 | W5


type MonthYear = private
                    | YYYYMM of yy:int * mth:int
                    | YYYYMMDD of yy:int * mth:int * dd:int
                    | YYYYMMWW of yy:int * mth:int * ww:Week




let inline private validate_yyyyMM (yy, mm)  = yy >= 0 && yy <= 9999 && 1 >= 0 && mm <= 12


[<AbstractClass;Sealed>]
type MakeTZTimeOnly private () =
    static member Make (year:int, month:int ) =
        match year, month with
        | yy, mm when validate_yyyyMM (year,month)  ->  YYYYMM (year, month)
        | _                                         ->  let msg = sprintf "invalid MonthYear: %d-%d" year month
                                                        failwith msg
    static member Make (year:int, month:int, day:int ) =
        match year, month, day with
        | yy, mm, dd when validate_yyyyMMdd (year, month, day)  ->  YYYYMMDD (year, month, day)
        | _                                                     ->  let msg = sprintf "invalid MonthYear: %d-%d-%d" year month day
                                                                    failwith msg
    static member Make (year:int, month:int, week:Week ) =
        match year, month, week with
        | yy, mm, dd when validate_yyyyMM (year, month)         ->  YYYYMMWW (year, month, week)
        | _                                                     ->  let msg = sprintf "invalid MonthYear: %d-%d-%A" year month week
                                                                    failwith msg