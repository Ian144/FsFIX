module DateTimeGenerators

open FsCheck





let genUTCDate = 
        gen {
            let! yy = Gen.choose(0, 9999)
            let! mm = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 31)
            return FIXDateTime.MakeUTCDate(yy, mm, dd)
        }





let private genUTCTimeOnlyNoMs =
        gen {
            let! hh = Gen.choose(0, 23)
            let! mm = Gen.choose(0, 59)
            let! ss = Gen.choose(0, 59)
            return FIXDateTime.MakeUTCTimeOnly.Make(hh, mm, ss)
        }

let private genUTCTimeOnlyMs =
        gen {
            let! hh = Gen.choose(0, 23)
            let! mm = Gen.choose(0, 59)
            let! ss = Gen.choose(0, 59)
            let! ms = Gen.choose(0, 999)
            return FIXDateTime.MakeUTCTimeOnly.Make(hh, mm, ss, ms)
        }

let private genUTCTimeOnlyLeapSecondNoMs =
        gen {
            return FIXDateTime.MakeUTCTimeOnly.Make(23, 59, 60 )
        }

let private genUTCTimeOnlyLeapSecondMs =
        gen {
            let! ms = Gen.choose(0, 999)
            return FIXDateTime.MakeUTCTimeOnly.Make(23, 59, 60, ms )
        }

let genUTCTimeOnly = Gen.frequency( [   19, genUTCTimeOnlyNoMs; 
                                        19, genUTCTimeOnlyMs; 
                                        1,  genUTCTimeOnlyLeapSecondNoMs; 
                                        1,  genUTCTimeOnlyLeapSecondMs   ])

let private genUTCTimestampNoMs =
        gen {
            let! yy = Gen.choose(0, 9999)
            let! mth = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 31)            
            let! hh = Gen.choose(0, 23)
            let! mm = Gen.choose(0, 59)
            let! ss = Gen.choose(0, 59)
            return FIXDateTime.MakeUTCTimestamp.Make(yy, mth, dd, hh, mm, ss)
        }

let private genUTCTimestampMs =
        gen {
            let! yy = Gen.choose(0, 9999)
            let! mth = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 31)            
            let! hh = Gen.choose(0, 23)
            let! mm = Gen.choose(0, 59)
            let! ss = Gen.choose(0, 59)
            let! ms = Gen.choose(0, 999)
            return FIXDateTime.MakeUTCTimestamp.Make(yy, mth, dd, hh, mm, ss, ms)
        }

let private genUTCTimestampLeapSecondNoMs =
        gen {
            let! yy = Gen.choose(0, 9999)
            let! mth = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 31)                        
            return FIXDateTime.MakeUTCTimestamp.Make(yy, mth, dd, 23, 59, 60 )
        }

let private genUTCTimestampLeapSecondMs =
        gen {
            let! yy = Gen.choose(0, 9999)
            let! mth = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 31)                        
            let! ms = Gen.choose(0, 999)
            return FIXDateTime.MakeUTCTimestamp.Make(yy, mth, dd, 23, 59, 60, ms )
        }

let genUTCTimestamp = Gen.frequency( [   19, genUTCTimestampNoMs; 
                                        19, genUTCTimestampMs; 
                                        1,  genUTCTimestampLeapSecondNoMs; 
                                        1,  genUTCTimestampLeapSecondMs   ])