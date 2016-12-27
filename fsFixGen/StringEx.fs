[<RequireQualifiedAccess>]
module StringEx



open System


let join (sep:string) (ss:string seq) =
    String.Join( sep, ss)



let lCaseFirstChar (str:string) = 
    let chrs = str.ToCharArray ()
    chrs.[0] <- System.Char.ToLower chrs.[0]
    new string (chrs)
