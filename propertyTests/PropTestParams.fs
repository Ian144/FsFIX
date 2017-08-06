module PropTestParams

open FsCheck.Xunit

open Generators


type PropTest() =
    inherit PropertyAttribute(
        Arbitrary = [| typeof<ArbOverrides> |],
        MaxTest = 100000,
        StartSize = 0,
        EndSize = 64,
        Verbose = false,
        QuietOnSuccess = true
    )



type PropTestByteArrayConversions() =
    inherit PropertyAttribute(
        MaxTest = 100000,
        StartSize = 0,
        EndSize = System.Int32.MaxValue,
        Verbose = false,
        QuietOnSuccess = true
        )