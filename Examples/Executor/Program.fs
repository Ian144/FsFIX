
open System
open System.Net.Sockets
open System.Net

open Fix44
open Fix44.Fields

open Session.Types






//#nowarn "52"
let WaitForExitCmd () = 
    while Console.ReadKey().KeyChar <> 'X' do // 88 is 'X'
        ()




[<EntryPoint>]
let main argv =

    // TODO, fix hardcoding
    let trgCompID = TargetCompID "acceptor"
    let sndCompID = SenderCompID "inititor"
    let sessionConfig:SessionConfig = {
        TargetCompID = trgCompID
        SenderCompID = sndCompID
        MaxMsgSize = 1024u * 64u
        MaxMsgAge  = TimeSpan(0,0,30)
        HeartbeatInterval = 60
        AcceptedCompIDPairs = Set.empty |> Set.add (trgCompID, sndCompID)
    }

    let tcpListener = TcpListener (IPAddress.Loopback, 5001)
    tcpListener.Start()

    let bufSize = 1024 * 64
    do FsFix.Session.Acceptor.MsgLoop Executor.Executor sessionConfig bufSize tcpListener
            
    Console.WriteLine("running, press 'X' to exit")        
    WaitForExitCmd ()    

    0 // return an integer exit code
