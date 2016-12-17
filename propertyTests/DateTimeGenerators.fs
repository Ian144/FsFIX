module DateTimeGenerators

open FsCheck





let genUTCDate = 
        gen {
            let! yy = Gen.choose(0, 9999)
            let! mm = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 31)
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
                                        1,  genUTCTimeOnlyLeapSecondNoMs; 
                                        1,  genUTCTimeOnlyLeapSecondMs   ])


// UTCTimestamp

let private genUTCTimestampNoMs =
        gen {
            let! yy = Gen.choose(0, 9999)
            let! mth = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 31)            
            let! hh = Gen.choose(0, 23)
            let! mm = Gen.choose(0, 59)
            let! ss = Gen.choose(0, 59)
            return UTCDateTime.MakeUTCTimestamp.Make(yy, mth, dd, hh, mm, ss)
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
            return UTCDateTime.MakeUTCTimestamp.Make(yy, mth, dd, hh, mm, ss, ms)
        }

let private genUTCTimestampLeapSecondNoMs =
        gen {
            let! yy = Gen.choose(0, 9999)
            let! mth = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 31)                        
            return UTCDateTime.MakeUTCTimestamp.Make(yy, mth, dd, 23, 59, 60 )
        }

let private genUTCTimestampLeapSecondMs =
        gen {
            let! yy = Gen.choose(0, 9999)
            let! mth = Gen.choose(1, 12)
            let! dd = Gen.choose(1, 31)                        
            let! ms = Gen.choose(0, 999)
            return UTCDateTime.MakeUTCTimestamp.Make(yy, mth, dd, 23, 59, 60, ms )
        }

let genUTCTimestamp = Gen.frequency [  19, genUTCTimestampNoMs; 
                                       19, genUTCTimestampMs; 
                                       1,  genUTCTimestampLeapSecondNoMs; 
                                       1,  genUTCTimestampLeapSecondMs   ]

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
