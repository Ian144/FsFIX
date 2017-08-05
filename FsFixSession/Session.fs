module FsFix.Session


open System.Net.Sockets
open System.Threading;




let HandleSocketError (name:string) (ex:System.Exception) = 
    //let rec handleExInner (ex:System.Exception) = 
    //    let msg = ex.Message
    //    let optInnerEx = FSharpx.FSharpOption.ToFSharpOption ex.InnerException

    //    match optInnerEx with
    //    | None  ->          msg
    //    | Some innerEx ->   let innerMsg = handleExInner innerEx
    //                        sprintf "%s | %s" msg innerMsg
    //let msg = handleExInner ex
    //// Microsoft redis-benchmark does not close its socket connections down cleanly
    //if not (msg.Contains("forcibly closed")) then
    //    printfn "%s --> %s" name msg
    ()


let ClientError ex =  HandleSocketError "client error" ex
let ConnectionListenerError ex = HandleSocketError "connection listener error" ex





let bufSize = 1024 * 64
let readTimeout = 1000 // millisecs
let checksumLen = 7

let countFieldSeperators (buf:byte array) endPos = 
    let mutable numSeps:uint32 = 0u
    let mutable pos:int = 0
    while pos < endPos do
        if buf.[pos] = 1uy then
            numSeps <- numSeps + 1u
    numSeps

//let AcceptorLoop msgProcessorFunc (bufSize:int) (client:TcpClient) =
let AcceptorLoop (bufSize:int) (client:TcpClient) =
    //todo: client.LingerState <-
    client.NoDelay              <- true
    client.ReceiveBufferSize    <- bufSize
    client.SendBufferSize       <- bufSize
    let strm = client.GetStream()
    strm.ReadTimeout <- readTimeout
    let buf = Array.zeroCreate<byte> bufSize
    let threadFunc _ = 
        // process logon msg
        while true do
            let numBytes = strm.Read(buf, 0, bufSize ) // times out after readTimeout millisecs
                
            if numBytes = 0 then
                () // read timeout, send heartbeat if neccessary - inner reads, while reading up to the end of a msg do not process session logic
            else
                // is more that length of "8=fIX.4.4" read
                // todo has the length been read in a previous iteration??
                // read the length

                // check fix version, if enough has been read
                let endPos = 0
                let begLenField = 10
                let mutable firstSepPos = 0
                while buf.[firstSepPos] <> 1uy do
                    firstSepPos <- firstSepPos + 1

                assert ((firstSepPos+1) = begLenField)

                let mutable secondSepPos = firstSepPos + 1
                while buf.[secondSepPos] <> 1uy do
                    secondSepPos <- secondSepPos + 1

                let fixVerField = Fix44.FieldReaders.ReadBeginString buf 0 firstSepPos
                let (Fix44.Fields.BodyLength bodyLen) = Fix44.FieldReaders.ReadBodyLength buf (firstSepPos+1) secondSepPos
                
                let totalLen = firstSepPos + (int32 bodyLen) + checksumLen

                while totalLen > numBytes do
                    () // read more


                // check the compIds
                // have enought bytes been read toin clude the length prefix?
                // are there at least two '|'s in the msg, the second should contian the length
                () 


            ()
        ()
    
    let thread = Thread(ThreadStart(threadFunc))
    thread.Start();
    




let ConnectionListenerLoop (bufSize:int) (listener:TcpListener) =
    let asyncConnectionListener =
        async {
            while true do
                let acceptClientTask = listener.AcceptTcpClientAsync ()
                let! client = Async.AwaitTask acceptClientTask
                do AcceptorLoop bufSize client
        }

    Async.StartWithContinuations(
        asyncConnectionListener,
        (fun _  -> printfn "ConnectionListener completed"),
        ConnectionListenerError,
        (fun ct -> printfn "ConnectionListener cancelled: %A" ct)
    )