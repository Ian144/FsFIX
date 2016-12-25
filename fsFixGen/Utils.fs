[<RequireQualifiedAccess>]
module Utils



open System


let joinStrs (sep:string) (ss:string seq) =
    String.Join( sep, ss)



let lCaseFirstChar (str:string) = 
    let chrs = str.ToCharArray ()
    chrs.[0] <- System.Char.ToLower chrs.[0]
    new string (chrs)
