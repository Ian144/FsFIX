module FsFixSession

open Fix44.Fields

let beginString44 = BeginString "FIX.4.4"



type SessionState = NotLoggedOn | LogonFailed | LoggedOn | LoggedOffWithError  | LoggedOff



// LOGGING !!!!

let runInitiator (host:string) (port:int) senderCompID targetCompID = 
    
    // connect
    // start msg resender (impl later)
    // kickoff heartbeater (impl 2nd)
    // run msg loop (impl first)
        // when to exit?? - task completion source??
        // async?? 



   ()








let runAcceptor (host:string) (port:int) senderCompID targetCompID = 




   ()