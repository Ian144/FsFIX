module Fix44.GroupWriteFuncs

open Fix44.Fields
open Fix44.CompoundItems
open Fix44.FieldReadWriteFuncs


let WriteNoUnderlyingSecurityAltIDGrp (strm:System.IO.Stream) (grp:NoUnderlyingSecurityAltIDGrp) =
    grp.UnderlyingSecurityAltID |> Option.iter (WriteUnderlyingSecurityAltID strm)
    grp.UnderlyingSecurityAltIDSource |> Option.iter (WriteUnderlyingSecurityAltIDSource strm)


