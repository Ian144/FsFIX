(*
 * Copyright (C) 2016-2017 Ian Spratt <ian144@hotmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301, USA.
 *
 *)
 
module DateTimeGenerators

open FsCheck





let genUTCDate = 
        gen {
            //let! yy = Gen.choose(0, 9999)
            let! yy = Gen.choose(2000, 2050) // attempting to run against quickfixN-echo, which does not like dates in the 0 - 9999 year range
            let! mm = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 28) // quickfix will check dates such as the 30th feb
            return UTCDateTime.MakeUTCDate(yy, mm, dd)
        }


// UTCTimeOnly


let private genUTCTimeOnlyNoMs =
        gen {
            let! hh = Gen.choose(0, 23)
            let! mm = Gen.choose(0, 59)
            let! ss = Gen.choose(0, 59)
            return UTCDateTime.MakeUTCTimeOnly.Make(hh, mm, ss)
        }

let private genUTCTimeOnlyMs =
        gen {
            let! hh = Gen.choose(0, 23)
            let! mm = Gen.choose(0, 59)
            let! ss = Gen.choose(0, 59)
            let! ms = Gen.choose(0, 999)
            return UTCDateTime.MakeUTCTimeOnly.Make(hh, mm, ss, ms)
        }

let private genUTCTimeOnlyLeapSecondNoMs =
        gen {
            return UTCDateTime.MakeUTCTimeOnly.Make(23, 59, 60 )
        }

let private genUTCTimeOnlyLeapSecondMs =
        gen {
            let! ms = Gen.choose(0, 999)
            return UTCDateTime.MakeUTCTimeOnly.Make(23, 59, 60, ms )
        }

let genUTCTimeOnly = Gen.frequency( [   19, genUTCTimeOnlyNoMs; 
                                        19, genUTCTimeOnlyMs; 
//                                        1,  genUTCTimeOnlyLeapSecondNoMs;  // quickfixN date conversions fail if leapseconds are present
//                                        1,  genUTCTimeOnlyLeapSecondMs   
                                        ])


// UTCTimestamp

let private genUTCTimestampNoMs =
        gen {
            //let! yy = Gen.choose(0, 9999)
            let! yy = Gen.choose(2000, 2050) // attempting to run against quickfixN-echo, which does not like dates in the 0 - 9999 year range
            let! mth = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 28)
            let! hh = Gen.choose(0, 23)
            let! mm = Gen.choose(0, 59)
            let! ss = Gen.choose(0, 59)
            return UTCDateTime.MakeUTCTimestamp.Make(yy, mth, dd, hh, mm, ss)
        }

let private genUTCTimestampMs =
        gen {
            //let! yy = Gen.choose(0, 9999)
            let! yy = Gen.choose(2000, 2050) // attempting to run against quickfixN-echo, which does not like dates in the 0 - 9999 year range
            let! mth = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 28)
            let! hh = Gen.choose(0, 23)
            let! mm = Gen.choose(0, 59)
            let! ss = Gen.choose(0, 59)
            let! ms = Gen.choose(0, 999)
            return UTCDateTime.MakeUTCTimestamp.Make(yy, mth, dd, hh, mm, ss, ms)
        }

//https://en.wikipedia.org/wiki/Leap_second
// past leap seconds "December 31, 2016 at 23:59:60 UTC"
// past leap seconds "JUNE 30, 2015 at 23:59:60 UTC"
let private genUTCTimestampLeapSecondNoMs =
        gen {
            return UTCDateTime.MakeUTCTimestamp.Make(2016, 12, 31, 23, 59, 60 )
        }
// an there was leap second at this UTC datetime "December 31, 2016 at 23:59:60"
let private genUTCTimestampLeapSecondMs =
        gen {
            let! ms = Gen.choose(0, 999)
            return UTCDateTime.MakeUTCTimestamp.Make(2016, 12, 31, 23, 59, 60, ms )
        }

let genUTCTimestamp = Gen.frequency [  19, genUTCTimestampNoMs; 
                                       19, genUTCTimestampMs; 
//                                       1,  genUTCTimestampLeapSecondNoMs; 
//                                       1,  genUTCTimestampLeapSecondMs   
                                       ]

// TZOffset

let private genDir = Gen.elements [ 43uy; 45uy ]

let private genTZOffsetUTC = gen{ return TZDateTime.MakeTZOffset.Make 90uy  } // 90uy is Z which meas UTC

let private genTZOffsetHH = gen{
            let! dir = genDir
            let! hh = Gen.choose(1, 12)
            return TZDateTime.MakeTZOffset.Make (dir, hh) // 43uy is +, meaning positive offset
        }

let private genTZOffsetHHmm = gen{
            let! dir = genDir
            let! hh = Gen.choose(1, 12)
            let! mm = Gen.choose(0, 59)
            return TZDateTime.MakeTZOffset.Make (dir, hh, mm) // 43uy is +, meaning positive offset
        }

let genTZOffset = Gen.frequency [   1, genTZOffsetUTC;
                                    10, genTZOffsetHH;
                                    10, genTZOffsetHHmm ]


// TZTimeOnly

let private genHHmmTZTimeOnlyHHmm = gen{
            let! offset = genTZOffset
            let! hh = Gen.choose(1, 23)
            let! mm = Gen.choose(0, 59)
            return TZDateTime.MakeTZTimeOnly.Make (offset, hh, mm)
    }

let private genHHmmTZTimeOnlyHHmmSS = gen{
            let! offset = genTZOffset
            let! hh = Gen.choose(1, 23)
            let! mm = Gen.choose(0, 59)
            let! ss = Gen.choose(0, 59)
            return TZDateTime.MakeTZTimeOnly.Make (offset, hh, mm, ss)
    }


let genTZTimeOnly = Gen.frequency [1, genHHmmTZTimeOnlyHHmm; 1, genHHmmTZTimeOnlyHHmmSS ]





// MonthYear


let private genMonthYearYYYYMM = 
        gen {
            //let! yy = Gen.choose(0, 9999)
            let! yy = Gen.choose(2000, 2050) // attempting to run against quickfixN-echo, which does not like dates in the 0 - 9999 year range
            let! mm = Gen.choose(1, 12)
            return MonthYear.MakeMonthYear.Make (yy, mm)
        }

let private genMonthYearYYYYMMDD = 
        gen {
            //let! yy = Gen.choose(0, 9999)
            let! yy = Gen.choose(2000, 2050) // attempting to run against quickfixN-echo, which does not like dates in the 0 - 9999 year range
            let! mm = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 28)
            return MonthYear.MakeMonthYear.Make(yy, mm, dd)
        }


let private genMonthYearYYYYMMWW = 
        gen {
            //let! yy = Gen.choose(0, 9999)
            let! yy = Gen.choose(2000, 2050) // attempting to run against quickfixN-echo, which does not like dates in the 0 - 9999 year range
            let! mm = Gen.choose(1, 12)
            let! (ww:MonthYear.Week) = Arb.generate
            return MonthYear.MakeMonthYear.Make(yy, mm, ww)
        }

let genMonthYear = Gen.frequency [1, genMonthYearYYYYMM; 1,genMonthYearYYYYMMDD; 1, genMonthYearYYYYMMWW]

let genLocalMktDate = 
        gen {
            //let! yy = Gen.choose(0, 9999)
            let! yy = Gen.choose(2000, 2050) // attempting to run against quickfixN-echo, which does not like dates in the 0 - 9999 year range
            let! mm = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 28)
            return LocalMktDate.MakeLocalMktDate(yy, mm, dd)
        }