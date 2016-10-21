module Fix44.Messages

open OneOrTwo
open Fix44.Fields
open Fix44.CompoundItems



type Logon = {
    EncryptMethod: EncryptMethod
    HeartBtInt: HeartBtInt
    RawDataLength: RawDataLength option
    RawData: RawData option
    ResetSeqNumFlag: ResetSeqNumFlag option
    NextExpectedMsgSeqNum: NextExpectedMsgSeqNum option
    MaxMessageSize: MaxMessageSize option
    NoMsgTypesGrp: NoMsgTypesGrp list option // group
    TestMessageIndicator: TestMessageIndicator option
    Username: Username option
    Password: Password option
    }

type Advertisement = {
    AdvId: AdvId
    AdvTransType: AdvTransType
    AdvRefID: AdvRefID option
    Instrument: Instrument // component
    NoLegsGrp: NoLegsGrp list option // group
    NoUnderlyingsGrp: NoUnderlyingsGrp list option // group
    AdvSide: AdvSide
    Quantity: Quantity
    QtyType: QtyType option
    Price: Price option
    Currency: Currency option
    TradeDate: TradeDate option
    TransactTime: TransactTime option
    Text: Text option
    EncodedText: EncodedText option
    URLLink: URLLink option
    LastMkt: LastMkt option
    TradingSessionID: TradingSessionID option
    TradingSessionSubID: TradingSessionSubID option
    }
