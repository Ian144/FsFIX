module Fix44.HeaderTrailer


open OneOrTwo
open Fix44.Fields
open Fix44.CompoundItems

type Header = {
    BeginString: BeginString
    BodyLength: BodyLength
    MsgType: MsgType
    SenderCompID: SenderCompID
    TargetCompID: TargetCompID
    OnBehalfOfCompID: OnBehalfOfCompID option
    DeliverToCompID: DeliverToCompID option
    SecureData: SecureData option
    MsgSeqNum: MsgSeqNum
    SenderSubID: SenderSubID option
    SenderLocationID: SenderLocationID option
    TargetSubID: TargetSubID option
    TargetLocationID: TargetLocationID option
    OnBehalfOfSubID: OnBehalfOfSubID option
    OnBehalfOfLocationID: OnBehalfOfLocationID option
    DeliverToSubID: DeliverToSubID option
    DeliverToLocationID: DeliverToLocationID option
    PossDupFlag: PossDupFlag option
    PossResend: PossResend option
    SendingTime: SendingTime
    OrigSendingTime: OrigSendingTime option
    XmlData: XmlData option
    MessageEncoding: MessageEncoding option
    LastMsgSeqNumProcessed: LastMsgSeqNumProcessed option
    NoHopsGrp: NoHopsGrp list option // group
    }

type Trailer = {
    SignatureLength: SignatureLength option
    Signature: Signature option
    CheckSum: CheckSum
    }
