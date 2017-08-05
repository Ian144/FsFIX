
open System
open System.Net.Sockets
open System.Net



[<EntryPoint>]
let main argv = 

    let tl = new TcpListener(IPAddress.Loopback,5001)

    //let xx = FsFix.Session.
            
    Console.WriteLine("running, press any key to exit")
    Console.ReadKey() |> ignore
        
    0 // return an integer exit code
