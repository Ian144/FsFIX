module Session.Types

open System
open Fix44.Fields




type SessionConfig = {
        TargetCompID:TargetCompID
        SenderCompID:SenderCompID
        MaxMsgSize:uint32
        MaxMsgAge:TimeSpan
        HeartbeatInterval:int
        AcceptedCompIDPairs:Set<TargetCompID*SenderCompID>
    }


