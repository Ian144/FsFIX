open Fix44.Fields
open Fix44.Messages
open Fix44.MsgWriters
open Fix44.CompoundItems

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running



//// tag: A
//let WriteLogon2 (dest:byte []) (nextFreeIdx:int) (beginString:BeginString) (bodyLength:BodyLength) (msgType:MsgType) (senderCompID:SenderCompID) (targetCompID:TargetCompID) (msgSeqNum:MsgSeqNum) (sendingTime:SendingTime) (xx:Logon) =
//    let mutable nextFreeIdx = nextFreeIdx
//    nextFreeIdx <- WriteEncryptMethod dest nextFreeIdx xx.EncryptMethod
//    nextFreeIdx <- WriteHeartBtInt dest nextFreeIdx xx.HeartBtInt
//
//    if xx.RawDataLength.IsSome then nextFreeIdx <- WriteRawDataLength dest nextFreeIdx xx.RawDataLength.Value
//    if xx.RawData.IsSome then nextFreeIdx <- WriteRawData dest nextFreeIdx xx.RawData.Value
//
//    if xx.ResetSeqNumFlag.IsSome then nextFreeIdx <- WriteResetSeqNumFlag dest nextFreeIdx xx.ResetSeqNumFlag.Value
//    if xx.NextExpectedMsgSeqNum.IsSome then nextFreeIdx <- WriteNextExpectedMsgSeqNum dest nextFreeIdx xx.NextExpectedMsgSeqNum.Value
//    if xx.MaxMessageSize.IsSome then nextFreeIdx <- WriteMaxMessageSize dest nextFreeIdx xx.MaxMessageSize.Value
//
//    nextFreeIdx <- Option.fold (fun innerNextFreeIdx (gs:NoMsgTypesGrp list) ->
//                                        let numGrps = gs.Length
//                                        let innerNextFreeIdx2 = WriteNoMsgTypes dest innerNextFreeIdx (Fix44.Fields.NoMsgTypes numGrps) // write the 'num group repeats' field
//                                        List.fold (fun accFreeIdx gg -> WriteNoMsgTypesGrp dest accFreeIdx gg) innerNextFreeIdx2 gs  ) // returns the accumulated nextFreeIdx
//                                  nextFreeIdx
//                                  xx.NoMsgTypesGrp  // end Option.fold
//
//    if xx.TestMessageIndicator.IsSome then nextFreeIdx <- WriteTestMessageIndicator dest nextFreeIdx xx.TestMessageIndicator.Value
//    if xx.Username.IsSome then nextFreeIdx <- WriteUsername dest nextFreeIdx xx.Username.Value
//    if xx.Password.IsSome then nextFreeIdx <- WritePassword dest nextFreeIdx xx.Password.Value
//    nextFreeIdx



let localMktDate = LocalMktDate.MakeLocalMktDate(2017,01,22)
let monthYear = MonthYear.MakeMonthYear.Make(2017,01,MonthYear.W1)
let utcTimeStamp = UTCDateTime.MakeUTCTimestamp.Make(2017, 01, 22, 06, 54, 00)

let instrument: Instrument =
     {Symbol = (Fix44.Fields.Symbol "RSWQE")
      SymbolSfx = Some WhenIssued
      SecurityID = Some (SecurityID "FJXY")
      SecurityIDSource = Some Valoren
      NoSecurityAltIDGrp = Some []
      Product = None
      CFICode = Some (CFICode "WAUIJ")
      SecurityType = Some TreasuryInflationProtectedSecurities
      SecuritySubType = Some (SecuritySubType "JXYCWAL")
      MaturityMonthYear = Some (MaturityMonthYear monthYear)
      MaturityDate = Some (MaturityDate localMktDate)
      PutOrCall = Some PutOrCall.Put
      CouponPaymentDate = Some (CouponPaymentDate localMktDate)
      IssueDate = None
      RepoCollateralSecurityType = Some (RepoCollateralSecurityType 0)
      RepurchaseTerm = Some (RepurchaseTerm 1)
      RepurchaseRate = Some (RepurchaseRate -5534023222112865484.7M)
      Factor = Some (Factor 79228162477.370849433239945M)
      CreditRating = Some (CreditRating "ESTXRVJK")
      InstrRegistry = Some (InstrRegistry "YSWHLF")
      CountryOfIssue = Some (CountryOfIssue "IMGKYZT")
      StateOrProvinceOfIssue = None
      LocaleOfIssue = Some (LocaleOfIssue "VZNO")
      RedemptionDate = Some (RedemptionDate localMktDate)
      StrikePrice = Some (StrikePrice 79228162458924105376.710262785M)
      StrikeCurrency = Some (StrikeCurrency "CWKL")
      OptAttribute = Some (OptAttribute '4')
      ContractMultiplier = Some (ContractMultiplier -3689348814312413.5939M)
      CouponRate = Some (CouponRate -792281.625142643375807M)
      SecurityExchange = None
      Issuer = Some (Issuer "GHBFTU")
      EncodedIssuer = Some (EncodedIssuer [||])
      SecurityDesc = Some (SecurityDesc "QUOJDHBP")
      EncodedSecurityDesc = Some (EncodedSecurityDesc [||])
      Pool = Some (Pool "DRSWQEF")
      ContractSettlMonth = None
      CPProgram = Some (CPProgram -2)
      CPRegType = Some (CPRegType "UVZTX")
      NoEventsGrp = Some []
      DatedDate = Some (DatedDate localMktDate)
      InterestAccrualDate = Some (InterestAccrualDate localMktDate )
      }


let newOrderMultileg:NewOrderMultileg =
   {ClOrdID = ClOrdID "PZXWQ"
    SecondaryClOrdID = Some (SecondaryClOrdID "EFZDRSMQ")
    ClOrdLinkID = None
    Parties = {NoPartyIDsGrp = Some []}
    TradeOriginationDate = Some (TradeOriginationDate localMktDate)
    TradeDate = Some (TradeDate localMktDate)
    Account = Some (Account "PKNOIWA")
    AcctIDSource = Some Tfm
    AccountType = Some AccountType.AccountIsCarriedOnNonCustomerSideOfBooks
    DayBookingInst = Some CanTriggerBookingWithoutReferenceToTheOrderInitiator
    BookingUnit = Some AggregatePartialExecutionsOnThisOrderAndBookOneTradePerOrder
    PreallocMethod = None
    AllocID = Some (AllocID "ZNOSMQBF")
    NewOrderMultilegNoAllocsGrp = Some []
    SettlType = Some TPlus5
    SettlDate = Some (SettlDate localMktDate)
    CashMargin = Some MarginOpen
    ClearingFeeIndicator = Some Firms106hAnd106j
    HandlInst = Some ManualOrder
    ExecInst = None
    MinQty = Some (MinQty 792281624589241053767102627.85M)
    MaxFloor = Some (MaxFloor 3.689348814312414M)
    ExDestination = Some (ExDestination "UYJN")
    NoTradingSessionsGrp = Some []
    ProcessCode = Some Regular
    Side = Lend
    Instrument = instrument
    NoUnderlyingsGrp = None
    PrevClosePx = Some (PrevClosePx -7922816249581759353.2719300611M)
    NewOrderMultilegNoLegsGrp = []
    LocateReqd = Some (LocateReqd false)
    TransactTime = TransactTime utcTimeStamp
    QtyType = Some Contracts
    OrderQtyData =
     {OrderQty = None
      CashOrderQty = Some (CashOrderQty -0.000000003689349M)
      OrderPercent = Some (OrderPercent -5534.023223401355674M)
      RoundingDirection = Some RoundDown
      RoundingModulus = Some (RoundingModulus 792281.624958175935327M)}
    OrdType = NextFundValuationPoint
    PriceType = None
    Price = Some (Fix44.Fields.Price 36.893488143124136M)
    StopPx = Some (StopPx 79228162477370849459009.748992M)
    Currency = Some (Fix44.Fields.Currency "USD")
    ComplianceID = Some (ComplianceID "NHVWAUY")
    SolicitedFlag = Some (SolicitedFlag true)
    IOIid = Some (IOIid "ALPJNB")
    QuoteID = Some (QuoteID "KOCDXBP")
    TimeInForce = None
    EffectiveTime =
     Some (EffectiveTime utcTimeStamp)
    ExpireDate = Some (ExpireDate localMktDate)
    ExpireTime = Some (ExpireTime utcTimeStamp)
    GTBookingInst = Some AccumulateUntilVerballyNotifiedOtherwise
    CommissionData = {Commission = Some (Commission -79228.162495817593533M)
                      CommType = Some PercentageWaivedCashDiscount
                      CommCurrency = Some (CommCurrency "VZTHIMGU")
                      FundRenewWaiv = Some No}
    OrderCapacity = None
    OrderRestrictions = Some ForeignEntity
    CustOrderCapacity = Some AllOther
    ForexReq = Some (ForexReq true)
    SettlCurrency = Some (SettlCurrency "ZTXLMG")
    BookingType = Some RegularBooking
    Text = Some (Fix44.Fields.Text "MGBVZT")
    EncodedText = Some (EncodedText [||])
    PositionEffect = Some Close
    CoveredOrUncovered = Some Covered
    MaxShow = Some (MaxShow -792281.624773708494590M)
    PegInstructions =
     {PegOffsetValue = Some (PegOffsetValue -79228162477370849.454714781696M)
      PegMoveType = None
      PegOffsetType = Some PegOffsetType.BasisPoints
      PegLimitType = Some PegLimitType.OrWorse
      PegRoundDirection = Some PegRoundDirection.MorePassive
      PegScope = Some PegScope.Local}
    DiscretionInstructions =
     {DiscretionInst = Some RelatedToVwap
      DiscretionOffsetValue =
       Some (DiscretionOffsetValue -79228162514264337580659048.449M)
      DiscretionMoveType = Some Fixed
      DiscretionOffsetType = Some Price
      DiscretionLimitType = Some OrBetter
      DiscretionRoundDirection = Some MoreAggressive
      DiscretionScope = Some Local}
    TargetStrategy = Some (TargetStrategy -3)
    TargetStrategyParameters = Some (TargetStrategyParameters "UOSMHBFZ")
    ParticipationRate = Some (ParticipationRate -55.340232221128655M)
    CancellationRights = Some NoExecutionOnly
    MoneyLaunderingStatus = Some ExemptBelowTheLimit
    RegistID = Some (RegistID "EFJDHS")
    Designation = None
    MultiLegRptTypeReq = Some ReportByMultilegSecurityAndByInstrumentLegsBelongingToTheMultilegSecurity}


let msg = newOrderMultileg |> Fix44.MessageDU.NewOrderMultileg


let bufSize = 1024 * 16

type BenchmarkNewOrderMultileg () =
    
    member val buf:byte array =  Array.zeroCreate<byte> bufSize
    member val tmpBuf:byte array =  Array.zeroCreate<byte> bufSize
    member val BeginString:BeginString = BeginString.BeginString "FIX.4.4"
    //member val BodyLength:BodyLength = BodyLength.BodyLength 99u
    member val MsgType:MsgType = MsgType.Logon
    member val SenderCompID:SenderCompID = SenderCompID.SenderCompID "senderCompID"
    member val TargetCompID:TargetCompID = TargetCompID.TargetCompID "targetCompID"
    member val MsgSeqNum:MsgSeqNum = MsgSeqNum.MsgSeqNum 99u
    member val SendingTime:SendingTime = SendingTime.SendingTime (UTCDateTime.readUTCTimestamp "20071123-05:30:00.000"B 0 21)


    [<Benchmark>]
    member this.Write () =
        let posW = MsgReadWrite.WriteMessageDU 
                                    this.tmpBuf 
                                    this.buf 
                                    0 
                                    this.BeginString 
                                    this.SenderCompID
                                    this.TargetCompID
                                    this.MsgSeqNum
                                    this.SendingTime
                                    msg


        ()


    


type BenchmarkWriteLogon () =


    member val Dst:byte array =  Array.zeroCreate<byte> 2048
    member val BeginString:BeginString = BeginString.BeginString "FIX.4.4"
    member val BodyLength:BodyLength = BodyLength.BodyLength 99u
    member val MsgType:MsgType = MsgType.Logon
    member val SenderCompID:SenderCompID = SenderCompID.SenderCompID "senderCompID"
    member val TargetCompID:TargetCompID = TargetCompID.TargetCompID "targetCompID"
    member val MsgSeqNum:MsgSeqNum = MsgSeqNum.MsgSeqNum 99u
    member val SendingTime:SendingTime = SendingTime.SendingTime (UTCDateTime.readUTCTimestamp "20071123-05:30:00.000"B 0 21)


    member val logonMsg:Fix44.Messages.Logon = {
        EncryptMethod = EncryptMethod.NoneOther
        HeartBtInt = HeartBtInt.HeartBtInt 30
        RawData = RawData.RawData "some data, some more data"B |> Option.Some
        ResetSeqNumFlag = ResetSeqNumFlag.ResetSeqNumFlag false |> Option.Some
        NextExpectedMsgSeqNum = NextExpectedMsgSeqNum.NextExpectedMsgSeqNum 99u |> Option.Some
        MaxMessageSize = MaxMessageSize.MaxMessageSize 256u |> Option.Some
        NoMsgTypesGrp = Option.None
        TestMessageIndicator = TestMessageIndicator.TestMessageIndicator true |> Option.Some
        Username = Option.None
        Password = Option.None
    }


// 8=FIX.4.2|9=178|35=8|49=PHLX|56=PERS|52=20071123-05:30:00.000|11=ATOMNOCCC9990900|20=3|150=E|39=E|55=MSFT|167=CS|54=1|38=15|40=2|44=15|58=PHLX EQUITY TESTING|59=0|47=C|32=0|31=0|151=15|14=0|6=0|10=128|


    [<Benchmark>]
    member this.WriteLogonMsg () =
        let nextFreeIdx =
            Fix44.MsgWriters.WriteLogon
                this.Dst
                0
//                this.BeginString
//                this.BodyLength
//                this.MsgType
//                this.SenderCompID
//                this.TargetCompID
//                this.MsgSeqNum
//                this.SendingTime
                this.logonMsg
        ()


    [<Benchmark>]
    member this.WriteLogonMsg2 () =
        let nextFreeIdx =
            Fix44.MsgWriters.WriteLogon
                this.Dst
                0
//                this.BeginString
//                this.BodyLength
//                this.MsgType
//                this.SenderCompID
//                this.TargetCompID
//                this.MsgSeqNum
//                this.SendingTime
                this.logonMsg
        ()


[<EntryPoint>]
let main argv =
    BenchmarkRunner.Run<BenchmarkWriteLogon>() |> ignore
    0
