module WriteReadUnitTests

open Xunit
open Swensen.Unquote

open Fix44.Fields
open Fix44.CompoundItems
open Fix44.CompoundItemReaders
open Fix44.CompoundItemWriters
open Fix44.Messages
open Fix44.MsgReaders
open Fix44.MsgWriters




// todo: put a single def of this function in a common location
let convFieldSep (bb:byte) = 
    match bb with 
    | 124uy -> 1uy
    | n     -> n

// this test fails with quickfixN because the bytes are encoded with quickfixJ's version of MassQuote, which as UnderlyingRepoCollateralSecurityType as a string not an int
[<Fact>]
let MassQuoteDeserialiseIssue2ndGroupReplacedWithCopyOf1st () =
    let bs = "8=FIX.4.4|9=4710|35=i|34=3458953|49=EXEC|52=20170129-15:41:43.109|56=BANZAI|117=GHYYKZQY|293=0.000000000000000|294=0.000000000000000|537=0|581=2|660=99|296=2|302=CGHB|311=NOSGABFT|309=VPTUO|305=VPDHIW|457=2|458=IJNDDJCG|459=WMJIBP|458=KOEE|459=NKJCQRV|462=0|463=SGKTPO|310=FAJY|763=ZIEDZTAI|542=22781202|315=1|241=79120621|242=01930431|243=ZKOIM|244=0|245=0.000000000000000|246=0.000000000000000|256=QKFZDXLM|592=NOSMABFZ|593=NBCG|594=HBFQUOS|247=71140129|316=0.000000000000000|941=EIWXRVP|317=s|435=0.000000000000000|308=VZTHIM|306=IJNH|362=4|363=KFFA|307=CWALPJNB|364=4|365=QLQL|877=PDEYCWR|318=TNRLGAE|879=0.000000000000000|810=0.000000000000000|882=0.000000000000000|883=0.000000000000000|884=0.000000000000000|885=0.000000000000000|887=1|888=CDXB|889=WRLPJXY|367=67800120-19:21:13.367|304=0|893=N|295=1|299=JNOIWBO|55=DHBYONAB|65=CD|48=NDCVJ|22=5|454=1|455=IAZHRE|456=XRVJK|460=4|461=FGKE|167=TBOND|200=520504|541=26171206|201=0|224=66810312|225=86270913|239=VJNOIWA|226=0|228=0.000000000000000|255=MQEYZDRL|470=TNRSGAE|471=THBFGAOS|472=GHBP|240=58831211|202=0.000000000000000|947=KESWQRV|206=³|223=0.000000000000000|207=UVZNH|106=OIMNHV|348=5|349=LQFAG|107=BCWKY|350=7|351=QLRVLWA|691=LZNZWLS|875=0|876=DPSTNBF|864=2|865=2|866=78960903|867=0.000000000000000|868=HATHIMG|865=3|866=61260229|867=0.000000000000000|868=PKOHLSX|874=25150606|555=1|600=PXMFG|601=UZJPBG|602=JPVJA|603=SBWIT|604=2|605=ZDRSMQ|606=NRLZ|605=EYTNR|606=SMABFZDO|608=XIMGKVZ|609=HLWAUYMN|764=BVZNOI|610=557004w1|611=67161228|248=51001007|249=73810403|251=0|252=0.000000000000000|253=0.000000000000000|257=CGUV|599=WQUIJDH|596=JKEICX|597=JDYSWQE|254=43020101|612=0.000000000000000|942=AUYJN|613=½|614=0.000000000000000|615=0.000000000000000|616=RLPJ|618=8|619=V@QVQVKQ|620=OSMA|621=8|622=@FAFAAWA|623=0.000000000000000|624=@|556=FJDHVWQU|740=IWXRVP|739=78980520|955=455001|956=19620925|132=0.000000000000000|133=0.000000000000000|134=0.000000000000000|135=0.000000000000000|188=0.000000000000000|190=0.000000000000000|189=0.000000000000000|631=0.000000000000000|633=0.000000000000000|634=0.000000000000000|60=72250314-14:48:40|625=KDBYYK|64=26950618|40=G|193=83150727|642=0.000000000000000|643=0.000000000000000|15=SGD|302=HICQUVPD|311=KEFJ|312=YSWXRFJ|309=YMGKLZIX|305=LMGUYO|457=1|458=HVBB|459=RHGZUOS|462=0|463=IDMBAD|310=CLHGC|313=97881230|542=38190117|315=0|241=72300918|242=93480314|244=0|245=0.000000000000000|256=DHBW|595=XRVPD|592=QEFJDH|593=KEIT|594=UYSWH|247=62691211|316=0.000000000000000|317=o|436=0.000000000000000|435=0.000000000000000|308=SMQKYZ|306=LZAEYCN|362=7|363=WAWWRWR|307=PTNRCG|877=CGUVPTNI|878=WQUO|318=PKEIC|879=0.000000000000000|810=0.000000000000000|882=0.000000000000000|883=0.000000000000000|885=0.000000000000000|886=0.000000000000000|887=2|888=BVZNOIMA|889=PJNHCW|888=WAOP|889=KOIWX|367=47220928-22:00:09|304=0|893=N|295=1|299=UIMNCV|55=FGWML|65=WI|48=DHBWQU|22=4|454=1|455=OIWABVZ|456=VIBFTUO|460=7|461=GAOS|167=TAXA|762=DHBCQUOP|541=25181109|201=0|224=28480309|225=49660919|239=HLMGUY|226=0|227=0.000000000000000|255=YCWX|543=YCQKLPDX|470=LMQE|471=FZAESMQ|472=FTNRSMAE|240=20500508|202=0.000000000000000|206=|231=0.000000000000000|223=0.000000000000000|207=TXLF|106=GHLZT|348=4|349=ZDZE|107=AOIG|350=4|351=JPTD|691=XLEETQTU|667=431609|876=HBVG|864=2|865=99|866=20271125|867=0.000000000000000|868=JBFBFJYT|865=3|867=0.000000000000000|873=67360107|874=97400518|555=2|600=ZHQY|601=VBRV|602=ENIU|603=WQLF|604=2|605=PJXYC|606=DXBMQKOC|605=KYZDXBM|606=YCQRL|607=0|608=TXIM|764=XBVZNO|610=31470209|611=05591016|248=26770412|249=46230213|250=RLZAE|251=0|253=0.000000000000000|257=ICGU|599=VWQUI|596=VJKEICXR|597=FJDY|254=15440119|612=0.000000000000000|613=«|614=0.000000000000000|615=0.000000000000000|616=QRLPJE|617=QKFZ|618=2|619=WR|620=UOSM|623=0.000000000000000|624=b|556=UFJDHVW|740=EIWXRVPK|739=53120524|955=856508|956=56420430|600=ZEENGL|601=HALXIM|602=ZTOIMG|603=JNHVWAU|604=2|605=HCWAUPJ|606=VJKOI|605=DXBVJK|606=ALPJ|607=0|608=QKOZ|609=AEYCNRLP|764=DOSM|611=97140930|248=16600731|249=37780104|250=EICQRVPT|251=0|252=0.000000000000000|253=0.000000000000000|599=YMNHL|596=IMGBVZ|597=CWAU|598=VQKOI|254=69651102|612=0.000000000000000|942=MNRLPAEY|614=0.000000000000000|615=0.000000000000000|616=THICGA|617=DHBWQUO|618=7|619=HMHMCHC|620=QLFJDRS|621=6|622=SXMSNS|623=0.000000000000000|624=4|740=BVZNOIMG|739=42950321|956=49600727|132=0.000000000000000|133=0.000000000000000|134=0.000000000000000|62=64230315-09:31:50|188=0.000000000000000|190=0.000000000000000|191=0.000000000000000|632=0.000000000000000|633=0.000000000000000|634=0.000000000000000|336=VOMJJVO|625=UONYL|64=04861127|40=7|192=0.000000000000000|642=0.000000000000000|643=0.000000000000000|15=USD|453=1|448=TNRFG|447=9|802=2|523=QEFJD|803=0|523=VJKE|803=0|10=153|"B |> Array.map convFieldSep
    let index = Array.zeroCreate<FIXBufIndexer.FieldPos> (1024 * 8)// todo, make index size a parameter 
    let indexEnd = FIXBufIndexer.BuildIndex index bs bs.Length
    let indexData = FIXBufIndexer.IndexData (indexEnd, index)
    indexData.LastReadIdx <- 9
    let nqeGrps =  GenericReaders.ReadGroup bs indexData 296 Fix44.CompoundItemReaders.ReadNoQuoteSetsGrp

    let outerGrp1 = nqeGrps.Head
    let outerGrp2 = nqeGrps.Tail.Head

    let innerGrp1 = outerGrp1.MassQuoteNoQuoteEntriesGrp.Head
    let innerGrp2 = outerGrp2.MassQuoteNoQuoteEntriesGrp.Head

    test<@ innerGrp1 <> innerGrp2 @>


// outer SettlInstSource is None
// inner SettlInstSource is Some
// write-> read results in a outer SettlInstSource taking the value of the inner
[<Fact>]
let ``SettlementInstructions and contained group both have SettlInstSource fields, is write+read correct`` () =
    let timeStamp = UTCDateTime.MakeUTCTimestamp.Make(2017, 01, 31, 06, 37, 00)
    let si:SettlementInstructions = {
        SettlInstMsgID = SettlInstMsgID "XRVWQEI"
        SettlInstReqID = None
        SettlInstMode = Default
        SettlInstReqRejCode = None
        Text = None
        EncodedText = None
        SettlInstSource = Some BrokersInstructions //outer SettlInstSource
        ClOrdID = None
        TransactTime = TransactTime timeStamp
        NoSettlInstGrp =
         Some
           [{SettlInstID = SettlInstID "OCWXBP"
             SettlInstTransType = None
             SettlInstRefID = None
             NoPartyIDsGrp = None
             Side = None
             Product = None
             SecurityType = None
             CFICode = None
             EffectiveTime = None   
             ExpireTime = None
             LastUpdateTime = None
             SettlInstructionsData = 
                {   SettlDeliveryType = Some SettlDeliveryType.Free
                    StandInstDbType = None
                    StandInstDbName = None
                    StandInstDbID = None
                    NoDlvyInstGrp = 
                        Some 
                            [{  SettlInstSource = Investor // inner SettlInstSource
                                DlvyInstType = None
                                NoSettlPartyIDsGrp = None 
                        }]
                }
             PaymentMethod = None
             PaymentRef = None
             CardHolderName = None
             CardNumber = None
             CardStartDate = None
             CardExpDate = None
             CardIssNum = None
             PaymentDate = None
             PaymentRemitterID = None}]
        }

    let buf = Array.zeroCreate<byte> 2048
    let posW = Fix44.MsgWriters.WriteSettlementInstructions buf 0 si

    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 256
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr buf posW
    let indexData = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)

    let siOut = Fix44.MsgReaders.ReadSettlementInstructions buf indexData

    // expecting this test to fail at the time of writing, as the outer SettlInstSource will have pulled in the value of the inner
    // test if outer SettlInstSource is None
    siOut =! si





[<Fact>]
let MessageWithHeaderTrailerUnit () =
    let bufSize = 4096
    let beginString = BeginString "NMNXPPML"
    let senderCompID = SenderCompID "UPGLIM"
    let targetCompID = TargetCompID "WKOPJXBC"
    let msgSeqNum = MsgSeqNum 0u
    let stn = UTCDateTime.MakeUTCTimestamp.Make(2016, 12, 29, 19, 09, 00)
    let sendingTime = SendingTime stn
    let ttm = UTCDateTime.MakeUTCTimestamp.Make(2016, 12, 29, 19, 09, 00)
    let msg =  {    AllocID = AllocID "XRFGK"
                    Parties = {NoPartyIDsGrp = None}
                    SecondaryAllocID = None
                    TradeDate = None
                    TransactTime = TransactTime ttm
                    AllocStatus = RejectedByIntermediary
                    AllocRejCode = None
                    AllocType = None
                    AllocIntermedReqType = None
                    MatchStatus = None
                    Product = None
                    SecurityType = None
                    Text = None
                    EncodedText = None
                    AllocationInstructionAckNoAllocsGrp = None} |> Fix44.MessageDU.AllocationInstructionAck
    let buf = Array.zeroCreate<byte> bufSize
    let tmpBuf = Array.zeroCreate<byte> bufSize
    let posW = MsgReadWrite.WriteMessageDU 
                                tmpBuf 
                                buf 
                                0 
                                beginString 
                                senderCompID
                                targetCompID
                                msgSeqNum
                                sendingTime
                                msg
    let msgOut = MsgReadWrite.ReadMessage buf posW
    msg =! msgOut




let NoHopsGrp () = 
    let bs = Array.zeroCreate<byte> 1024
    let xIn:NoHopsGrp = {
                HopCompID = HopCompID "RWTM"
                HopSendingTime = None
                HopRefID = Some (HopRefID 0u)
                }
    let posW = WriteNoHopsGrp  bs 0 xIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 1
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs posW
    let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)
    let xOut = ReadNoHopsGrp bs index
    xIn =! xOut



[<Fact>]
let InstrumentLegFG () =
    let bs = Array.zeroCreate<byte> 1024
    let legContractSettlMonth = MonthYear.MakeMonthYear.Make(2016, 12) |> LegContractSettlMonth
    let xIn:InstrumentLegFG = {
                LegSymbol = LegSymbol "DHVC"
                LegSymbolSfx = None
                LegSecurityID = None
                LegSecurityIDSource = None
                NoLegSecurityAltIDGrp = None
                LegProduct = None
                LegCFICode = None
                LegSecurityType = None
                LegSecuritySubType = None
                LegMaturityMonthYear = None
                LegMaturityDate = None
                LegCouponPaymentDate = None
                LegIssueDate = None
                LegRepoCollateralSecurityType = None
                LegRepurchaseTerm = None
                LegRepurchaseRate = None
                LegFactor = None
                LegCreditRating = None
                LegInstrRegistry = None
                LegCountryOfIssue = None
                LegStateOrProvinceOfIssue = None
                LegLocaleOfIssue = None
                LegRedemptionDate = None
                LegStrikePrice = None
                LegStrikeCurrency = None
                LegOptAttribute = None
                LegContractMultiplier = None
                LegCouponRate = None
                LegSecurityExchange = None
                LegIssuer = None
                EncodedLegIssuer = None
                LegSecurityDesc = None
                EncodedLegSecurityDesc = None
                LegRatioQty = None
                LegSide = Some (LegSide 'a')
                LegCurrency = None
                LegPool = None
                LegDatedDate = None
                LegContractSettlMonth = None
                LegInterestAccrualDate = None}
    let posW = WriteInstrumentLegFG  bs 0 xIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 2
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs posW
    let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)
    let xOut = ReadInstrumentLegFG bs index
    xIn =! xOut





[<Fact>]
let InstrumentLegFG2 () =
    let bs = Array.zeroCreate<byte> 1024
    let legContractSettlMonth = MonthYear.MakeMonthYear.Make(2016, 12) |> LegContractSettlMonth
    let xIn:InstrumentLegFG = {
                LegSymbol = LegSymbol "LOPK"
                LegSymbolSfx = None
                LegSecurityID = None
                LegSecurityIDSource = None
                NoLegSecurityAltIDGrp = None
                LegProduct = None
                LegCFICode = None
                LegSecurityType = None
                LegSecuritySubType = None
                LegMaturityMonthYear = None
                LegMaturityDate = None
                LegCouponPaymentDate = None
                LegIssueDate = None
                LegRepoCollateralSecurityType = None
                LegRepurchaseTerm = None
                LegRepurchaseRate = None
                LegFactor = None
                LegCreditRating = None
                LegInstrRegistry = None
                LegCountryOfIssue = None
                LegStateOrProvinceOfIssue = None
                LegLocaleOfIssue = None
                LegRedemptionDate = None
                LegStrikePrice = None
                LegStrikeCurrency = None
                LegOptAttribute = None
                LegContractMultiplier = None
                LegCouponRate = None
                LegSecurityExchange = None
                LegIssuer = None
                EncodedLegIssuer = None
                LegSecurityDesc = None
                EncodedLegSecurityDesc = None
                LegRatioQty = None
                LegSide = None
                LegCurrency = None
                LegPool = None
                LegDatedDate = None
                LegContractSettlMonth = Some (legContractSettlMonth)
                LegInterestAccrualDate = None}
    let posW = WriteInstrumentLegFG  bs 0 xIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 2
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs posW
    let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)
    let xOut = ReadInstrumentLegFG bs index
    xIn =! xOut
    





[<Fact>]
let MassQuoteNoQuoteEntriesGrp () =
    let bs = Array.zeroCreate<byte> 1024
    let xIn:MassQuoteNoQuoteEntriesGrp =
                 {  QuoteEntryID = QuoteEntryID "GKCO"
                    Instrument = None
                    NoLegsGrp = None
                    BidPx = None
                    OfferPx = None
                    BidSize = None
                    OfferSize = None
                    ValidUntilTime = None
                    BidSpotRate = None
                    OfferSpotRate = None
                    BidForwardPoints = None
                    OfferForwardPoints = None
                    MidPx = None
                    BidYield = None
                    MidYield = None
                    OfferYield = None
                    TransactTime = None
                    TradingSessionID = None
                    TradingSessionSubID = None
                    SettlDate = None
                    OrdType = None
                    SettlDate2 = None
                    OrderQty2 = None
                    BidForwardPoints2 = None
                    OfferForwardPoints2 = None
                    Currency = None    } 

    let posW = WriteMassQuoteNoQuoteEntriesGrp  bs 0 xIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 2 //todo: allowing probe for the next optional field to look past endPos/end of the index, is there a better way to do this
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs posW
    let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)
    let xOut = ReadMassQuoteNoQuoteEntriesGrp bs index
    xIn =! xOut



 


[<Fact>]
let MarketDataIncrementalRefreshNoMDEntriesGrp () =
    let bs = Array.zeroCreate<byte> 1024    
    let tm = UTCDateTime.MakeUTCTimeOnly.Make (13, 59, 25, 377)
    let xIn:MarketDataIncrementalRefreshNoMDEntriesGrp = 
          {MDUpdateAction = MDUpdateAction.New;
           DeleteReason = None;
           MDEntryType = None;
           MDEntryID = None;
           MDEntryRefID = None;
           Instrument = None;
           NoUnderlyingsGrp = None;
           NoLegsGrp = None;
           FinancialStatus = None;
           CorporateAction = None;
           MDEntryPx = None;
           Currency = None;
           MDEntrySize = None;
           MDEntryDate = None;
           MDEntryTime = Some (MDEntryTime tm);
           TickDirection = None;
           MDMkt = None;
           TradingSessionID = None;
           TradingSessionSubID = None;
           QuoteCondition = None;
           TradeCondition = None;
           MDEntryOriginator = None;
           LocationID = None;
           DeskID = None;
           OpenCloseSettlFlag = None;
           TimeInForce = None;
           ExpireDate = None;
           ExpireTime = None;
           MinQty = None;
           ExecInst = None;
           SellerDays = None;
           OrderID = None;
           QuoteEntryID = None;
           MDEntryBuyer = None;
           MDEntrySeller = None;
           NumberOfOrders = None;
           MDEntryPositionNo = None;
           Scope = None;
           PriceDelta = None;
           NetChgPrevDay = None;
           Text = None;
           EncodedText = None;}
    let posW = WriteMarketDataIncrementalRefreshNoMDEntriesGrp  bs 0 xIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 4
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs posW
    let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)
    let xOut = ReadMarketDataIncrementalRefreshNoMDEntriesGrp bs index
    xIn =! xOut


[<Fact>]
let NoSidesGrp () =
    let bs = Array.zeroCreate<byte> 1024    

    let ptyId1Grp1:NoPartyIDsGrp = 
                {   PartyID = PartyID "HLFCBGEH"
                    PartyIDSource = None
                    PartyRole = None
                    NoPartySubIDsGrp = Some []} 
    let ptyId1Grp2:NoPartyIDsGrp = 
                         {  PartyID = PartyID "MGDCHFI"
                            PartyIDSource = None
                            PartyRole = None
                            NoPartySubIDsGrp = None}
    
    let noPartyIDsGrp =  [ ptyId1Grp1; ptyId1Grp2 ] |> Option.Some 

    let xIn:NoSidesGrp = 
                {Side = AsDefined
                 ClOrdID = ClOrdID "ICGHV"
                 SecondaryClOrdID = None
                 ClOrdLinkID = None
                 NoPartyIDsGrp = noPartyIDsGrp
                 TradeOriginationDate = None
                 TradeDate = None
                 Account = None
                 AcctIDSource = None
                 AccountType = None
                 DayBookingInst = None
                 BookingUnit = None
                 PreallocMethod = None
                 AllocID = None
                 NoAllocsGrp = None
                 QtyType = None
                 OrderQtyData = {OrderQty = None
                                 CashOrderQty = None
                                 OrderPercent = None
                                 RoundingDirection = None
                                 RoundingModulus = None}
                 CommissionData = {Commission = None
                                   CommType = None
                                   CommCurrency = None
                                   FundRenewWaiv = None}
                 OrderCapacity = None
                 OrderRestrictions = None
                 CustOrderCapacity = None
                 ForexReq = None
                 SettlCurrency = None
                 BookingType = None
                 Text = None
                 EncodedText = None
                 PositionEffect = None
                 CoveredOrUncovered = None
                 CashMargin = None
                 ClearingFeeIndicator = None
                 SolicitedFlag = None
                 SideComplianceID = None}
    let posW = WriteNoSidesGrp  bs 0 xIn
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 128
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs posW
    let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)
    let xOut = ReadNoSidesGrp bs index
    xIn =! xOut



[<Fact>]
let NoPartyIDsGrp () =
    let bs = Array.zeroCreate<byte> 1024
    let ptyId1Grp1:NoPartyIDsGrp = 
                {   PartyID = PartyID "HLFCBGEH"
                    PartyIDSource = None
                    PartyRole = None
                    NoPartySubIDsGrp = Some []} 
    let ptyId1Grp2:NoPartyIDsGrp = 
                         {  PartyID = PartyID "MGDCHFI"
                            PartyIDSource = None
                            PartyRole = None
                            NoPartySubIDsGrp = None}
    let ptyIdGrp = ptyId1Grp1
    let posW = WriteNoPartyIDsGrp  bs 0 ptyIdGrp
    let fieldPosArr = Array.zeroCreate<FIXBufIndexer.FieldPos> 128
    let indexEnd = FIXBufIndexer.BuildIndex fieldPosArr bs posW
    let index = FIXBufIndexer.IndexData (indexEnd, fieldPosArr)
    let xOut = ReadNoPartyIDsGrp bs index
    ptyIdGrp =! xOut



    
