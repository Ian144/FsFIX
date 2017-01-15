module LocalMktDate

open FIXDateTime



type LocalMktDate = private LocalMktDate of Year:int * Month:int * Day:int 



let MakeLocalMktDate (yy:int, mm:int, dd:int) : LocalMktDate = 
    if validate_yyyyMMdd (yy, mm, dd) |> not then
        let msg = sprintf "failwith invalid LocalMktDate, y:%d, m:%d, d:%d" yy mm dd
        failwith msg
    LocalMktDate ( yy, mm, dd )




let writeLocalMktDate (dt:LocalMktDate) (bs:byte[]) (pos:int) : int =
    match dt with 
    | LocalMktDate (yyyy, mm, dd) ->    write4ByteInt bs pos yyyy
                                        write2ByteInt bs (pos + 4) mm
                                        write2ByteInt bs (pos + 6) dd
                                        pos + 8

let readLocalMktDate (bs:byte[]) (pos:int) (len:int) : LocalMktDate =
    let yyyy, mm, dd = readYYYYmmDDints bs pos
    MakeLocalMktDate (yyyy, mm, dd)                    