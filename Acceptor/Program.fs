
open System
open System.Net.Sockets
open System.Net


//#nowarn "52"
let WaitForExitCmd () = 
    while Console.ReadKey().KeyChar <> 'X' do // 88 is 'X'
        ()



[<EntryPoint>]
let main argv = 

    let tl = new TcpListener(IPAddress.Loopback,5001)
    tl.Start()

    let bufSize = 1024 * 64
    let xx = FsFix.Session.ConnectionListenerLoop  bufSize tl
            
    Console.WriteLine("running, press 'X' to exit")        
    WaitForExitCmd ()    

    0 // return an integer exit code
