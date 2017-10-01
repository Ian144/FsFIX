
open System
open System.Net.Sockets
open System.Net

open Fix44
open Fix44.Fields




//#nowarn "52"
let WaitForExitCmd () = 
    while Console.ReadKey().KeyChar <> 'X' do // 88 is 'X'
        ()



[<EntryPoint>]
let main argv = 

    // TODO, read targetCompID and senderCompID from config
    let trgCompId = TargetCompID "acceptor"
    let sndCompId = SenderCompID "initiator"

    let acceptedCompIDPairs = Set.empty |> Set.add (trgCompId, sndCompId)
    let maxMsgAge = TimeSpan(0,0,30)
    let tl = TcpListener(IPAddress.Loopback,5001)
    tl.Start()

    let bufSize = 1024 * 64
    do FsFix.Session.ConnectionListenerLoop maxMsgAge acceptedCompIDPairs bufSize tl
            
    Console.WriteLine("running, press 'X' to exit")        
    WaitForExitCmd ()    

    0 // return an integer exit code
