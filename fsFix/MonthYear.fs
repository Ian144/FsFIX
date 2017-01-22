module MonthYear

open FIXDateTime



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
type MakeMonthYear () =
    static member Make (year,month) =
        match year, month with
        | yy, mm when validate_yyyyMM (yy,mm)       ->  YYYYMM (yy, mm)
        | _                                         ->  failwithf "invalid MonthYear: %d-%d" year month
    static member Make (yy,mm,dd) =
        match (yy,mm,dd) with
        | yy, mm, dd when validate_yyyyMMdd (yy,mm,dd)  ->  YYYYMMDD (yy,mm,dd)
        | _                                             ->  failwithf "invalid MonthYear: %d-%d-%d" yy mm dd
    static member Make (yy,mm,ww) =
        match (yy, mm, ww) with
        | yy, mm, ww when validate_yyyyMM (yy, mm)  ->  YYYYMMWW (yy,mm,ww)
        | _                                         ->  failwithf "invalid MonthYear: %d-%d-%A" yy mm ww



let private readWeek (bs:byte[]) (pos:int) =
    let wByte = bs.[pos]
    let nByte = bs.[pos+1]
    match wByte, nByte with
    | 119uy, 49uy   ->  W1
    | 119uy, 50uy   ->  W2
    | 119uy, 51uy   ->  W3
    | 119uy, 52uy   ->  W4
    | 119uy, 53uy   ->  W5
    | _             ->  failwithf "invalid week %c-%c" (System.Convert.ToChar wByte) (System.Convert.ToChar nByte)


let private writeWeek (bs:byte[]) (pos:int) (ww:Week) =
    match ww with
    | W1    ->  bs.[pos] <- 119uy; bs.[pos+1] <- 49uy
    | W2    ->  bs.[pos] <- 119uy; bs.[pos+1] <- 50uy
    | W3    ->  bs.[pos] <- 119uy; bs.[pos+1] <- 51uy
    | W4    ->  bs.[pos] <- 119uy; bs.[pos+1] <- 52uy
    | W5    ->  bs.[pos] <- 119uy; bs.[pos+1] <- 53uy



let read (bs:byte[]) (pos:int) (len:int): MonthYear =
    match len with
    | 6 -> // YYYYMM
        let yy = FIXDateTime.bytes4ToInt bs pos
        let mm = FIXDateTime.bytes2ToInt bs (pos+4)
        MakeMonthYear.Make (yy,mm)
    | 8 -> // YYYYMMDD OR // YYYYMMDD 
        match bs.[pos+6] with
        | 119uy -> // YYYYMMDD 
            let yy = FIXDateTime.bytes4ToInt bs pos
            let mm = FIXDateTime.bytes2ToInt bs (pos+4)
            let ww = readWeek bs (pos+6)
            MakeMonthYear.Make (yy,mm,ww)
        | n     -> // // YYYYMMDD 
            let yy = FIXDateTime.bytes4ToInt bs pos
            let mm = FIXDateTime.bytes2ToInt bs (pos+4)
            let dd = FIXDateTime.bytes2ToInt bs (pos+6)
            MakeMonthYear.Make (yy,mm,dd)
    | n -> failwithf "invalid field length for MonthYear: %d" n



let write (bs:byte[]) (pos:int) (ym:MonthYear) : int =
    match ym with
    | YYYYMM (yy, mth)          -> 
        write4ByteInt bs pos yy
        write2ByteInt bs (pos+4) mth
        pos+6
    | YYYYMMDD (yy, mth, dd)    ->
        write4ByteInt bs pos yy
        write2ByteInt bs (pos+4) mth
        write2ByteInt bs (pos+6) dd
        pos+8
    | YYYYMMWW (yy, mth, ww)    -> 
        write4ByteInt bs pos yy
        write2ByteInt bs (pos+4) mth
        writeWeek bs (pos+6) ww
        pos+8





