module PropTestParams

open FsCheck.Xunit

open Generators



#if DEBUG
let private maxTest = 10
let private endSize = 4
#else
let private maxTest = 10000
let private endSize = 64
#endif



type PropTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = maxTest,
        StartSize = 0,
        EndSize = endSize,
        Verbose = false,
        QuietOnSuccess = true
    )


type PropTestByteArrayConversions() =
    inherit PropertyAttribute(
        MaxTest = maxTest,
        StartSize = 0,
        EndSize = System.Int32.MaxValue,
        Verbose = false,
        QuietOnSuccess = true
        )