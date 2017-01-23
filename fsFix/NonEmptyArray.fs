module NonEmptyByteArray





// why have a private ctor and still allow access to the wrapped data via the value member? 
// if the ctor was not private it would allow the creation of empty NonEmptyArrays

type NonEmptyByteArray = private NonEmptyByteArray of byte array
                                    member x.Value = let (NonEmptyByteArray v) = x in v

let Make (bs:byte array) =
    if bs.Length > 0 then
        NonEmptyByteArray bs
    else
        failwith "NonEmptyArray.Make given empty array"

