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
type MakeMonthYear private () =
    static member Make (year,month) =
        match year, month with
        | yy, mm when validate_yyyyMM (yy,mm)       ->  YYYYMM (yy, mm)
        | _                                         ->  let msg = sprintf "invalid MonthYear: %d-%d" year month
                                                        failwith msg
    static member Make (yy,mm,dd) =
        match (yy,mm,dd) with
        | yy, mm, dd when validate_yyyyMMdd (yy,mm,dd)  ->  YYYYMMDD (yy,mm,dd)
        | _                                             ->  let msg = sprintf "invalid MonthYear: %d-%d-%d" yy mm dd
                                                            failwith msg
    static member Make (yy,mm,ww) =
        match (yy, mm, ww) with
        | yy, mm, ww when validate_yyyyMM (yy, mm)  ->  YYYYMMWW (yy,mm,ww)
        | _                                         ->  let msg = sprintf "invalid MonthYear: %d-%d-%A" yy mm ww
                                                        failwith msg



let private readWeek (bs:byte[]) (pos:int) =
    let wByte = bs.[pos]
    let nByte = bs.[pos+1]
    let ww =
        match wByte, nByte with
        | 119uy, 49uy   ->  W1
        | 119uy, 50uy   ->  W2
        | 119uy, 51uy   ->  W3
        | 119uy, 52uy   ->  W4
        | 119uy, 53uy   ->  W5
        | _             ->  let msg = sprintf "invalid week %c-%c" (System.Convert.ToChar wByte) (System.Convert.ToChar nByte)
                            failwith msg
    ww


let private writeWeek (bs:byte[]) (pos:int) (ww:Week) =
    let wByte = bs.[pos]
    let nByte = bs.[pos+1]
    match ww with
    | W1    ->  bs.[pos] <- 119uy; bs.[pos+1] <- 49uy
    | W2    ->  bs.[pos] <- 119uy; bs.[pos+1] <- 50uy
    | W3    ->  bs.[pos] <- 119uy; bs.[pos+1] <- 51uy
    | W4    ->  bs.[pos] <- 119uy; bs.[pos+1] <- 52uy
    | W5    ->  bs.[pos] <- 119uy; bs.[pos+1] <- 53uy



let readYYYYMM (bs:byte[]) (pos:int) : int*MonthYear =
    let endPos = FIXBufUtils.findNextFieldTermOrEnd bs pos
    match endPos - pos with
    | 6 -> // YYYYMM
        let yy = DateTimeUtils.bytes4ToInt bs pos
        let mm = DateTimeUtils.bytes2ToInt bs (pos+4)
        pos+6, MakeMonthYear.Make (yy,mm)
    | 8 -> // YYYYMMDD OR // YYYYMMDD 
        match bs.[pos+6] with
        | 119uy -> // YYYYMMDD 
            let yy = DateTimeUtils.bytes4ToInt bs pos
            let mm = DateTimeUtils.bytes2ToInt bs (pos+4)
            let ww = readWeek bs (pos+6)
            pos+8, MakeMonthYear.Make (yy,mm,ww)
        | n     -> // // YYYYMMDD 
            let yy = DateTimeUtils.bytes4ToInt bs pos
            let mm = DateTimeUtils.bytes2ToInt bs (pos+4)
            let dd = DateTimeUtils.bytes2ToInt bs (pos+6)
            pos+8, MakeMonthYear.Make (yy,mm,dd)
    | n -> let msg = sprintf "invalid field length for MonthYear: %d" n
           failwith msg 



let writeYYYYMM (bs:byte[]) (pos:int) (ym:MonthYear) : int =
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





