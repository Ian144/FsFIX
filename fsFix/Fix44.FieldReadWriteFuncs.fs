module Fix44.FieldReadWriteFuncs


open System.IO
open Fix44.Fields
open ReadWriteFuncs


let ReadAccount valIn =
    let tmp =  valIn
    Account.Account tmp


let WriteAccount (strm:Stream) (valIn:Account) = 
    let tag = "1="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAdvId valIn =
    let tmp =  valIn
    AdvId.AdvId tmp


let WriteAdvId (strm:Stream) (valIn:AdvId) = 
    let tag = "2="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAdvRefID valIn =
    let tmp =  valIn
    AdvRefID.AdvRefID tmp


let WriteAdvRefID (strm:Stream) (valIn:AdvRefID) = 
    let tag = "3="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAdvSide (fldValIn:string) : AdvSide = 
    match fldValIn with
    |"B" -> AdvSide.Buy
    |"S" -> AdvSide.Sell
    |"X" -> AdvSide.Cross
    |"T" -> AdvSide.Trade
    | x -> failwith (sprintf "ReadAdvSide unknown fix tag: %A"  x) 


let WriteAdvSide (strm:Stream) (xxIn:AdvSide) =
    match xxIn with
    | AdvSide.Buy -> strm.Write "4=B"B; strm.Write (delim, 0, 1)
    | AdvSide.Sell -> strm.Write "4=S"B; strm.Write (delim, 0, 1)
    | AdvSide.Cross -> strm.Write "4=X"B; strm.Write (delim, 0, 1)
    | AdvSide.Trade -> strm.Write "4=T"B; strm.Write (delim, 0, 1)


let ReadAdvTransType (fldValIn:string) : AdvTransType = 
    match fldValIn with
    |"N" -> AdvTransType.New
    |"C" -> AdvTransType.Cancel
    |"R" -> AdvTransType.Replace
    | x -> failwith (sprintf "ReadAdvTransType unknown fix tag: %A"  x) 


let WriteAdvTransType (strm:Stream) (xxIn:AdvTransType) =
    match xxIn with
    | AdvTransType.New -> strm.Write "5=N"B; strm.Write (delim, 0, 1)
    | AdvTransType.Cancel -> strm.Write "5=C"B; strm.Write (delim, 0, 1)
    | AdvTransType.Replace -> strm.Write "5=R"B; strm.Write (delim, 0, 1)


let ReadAvgPx valIn =
    let tmp = System.Decimal.Parse valIn
    AvgPx.AvgPx tmp


let WriteAvgPx (strm:Stream) (valIn:AvgPx) = 
    let tag = "6="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBeginSeqNo valIn =
    let tmp = System.Int32.Parse valIn
    BeginSeqNo.BeginSeqNo tmp


let WriteBeginSeqNo (strm:Stream) (valIn:BeginSeqNo) = 
    let tag = "7="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBeginString valIn =
    let tmp =  valIn
    BeginString.BeginString tmp


let WriteBeginString (strm:Stream) (valIn:BeginString) = 
    let tag = "8="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBodyLength valIn =
    let tmp = System.Int32.Parse valIn
    BodyLength.BodyLength tmp


let WriteBodyLength (strm:Stream) (valIn:BodyLength) = 
    let tag = "9="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCheckSum valIn =
    let tmp =  valIn
    CheckSum.CheckSum tmp


let WriteCheckSum (strm:Stream) (valIn:CheckSum) = 
    let tag = "10="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadClOrdID valIn =
    let tmp =  valIn
    ClOrdID.ClOrdID tmp


let WriteClOrdID (strm:Stream) (valIn:ClOrdID) = 
    let tag = "11="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCommission valIn =
    let tmp = System.Int32.Parse valIn
    Commission.Commission tmp


let WriteCommission (strm:Stream) (valIn:Commission) = 
    let tag = "12="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCommType (fldValIn:string) : CommType = 
    match fldValIn with
    |"1" -> CommType.PerUnit
    |"2" -> CommType.Percentage
    |"3" -> CommType.Absolute
    |"4" -> CommType.PercentageWaivedCashDiscount
    |"5" -> CommType.PercentageWaivedEnhancedUnits
    |"6" -> CommType.PointsPerBondOrOrContract
    | x -> failwith (sprintf "ReadCommType unknown fix tag: %A"  x) 


let WriteCommType (strm:Stream) (xxIn:CommType) =
    match xxIn with
    | CommType.PerUnit -> strm.Write "13=1"B; strm.Write (delim, 0, 1)
    | CommType.Percentage -> strm.Write "13=2"B; strm.Write (delim, 0, 1)
    | CommType.Absolute -> strm.Write "13=3"B; strm.Write (delim, 0, 1)
    | CommType.PercentageWaivedCashDiscount -> strm.Write "13=4"B; strm.Write (delim, 0, 1)
    | CommType.PercentageWaivedEnhancedUnits -> strm.Write "13=5"B; strm.Write (delim, 0, 1)
    | CommType.PointsPerBondOrOrContract -> strm.Write "13=6"B; strm.Write (delim, 0, 1)


let ReadCumQty valIn =
    let tmp = System.Decimal.Parse valIn
    CumQty.CumQty tmp


let WriteCumQty (strm:Stream) (valIn:CumQty) = 
    let tag = "14="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCurrency valIn =
    let tmp =  valIn
    Currency.Currency tmp


let WriteCurrency (strm:Stream) (valIn:Currency) = 
    let tag = "15="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadEndSeqNo valIn =
    let tmp = System.Int32.Parse valIn
    EndSeqNo.EndSeqNo tmp


let WriteEndSeqNo (strm:Stream) (valIn:EndSeqNo) = 
    let tag = "16="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadExecID valIn =
    let tmp =  valIn
    ExecID.ExecID tmp


let WriteExecID (strm:Stream) (valIn:ExecID) = 
    let tag = "17="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadExecInst (fldValIn:string) : ExecInst = 
    match fldValIn with
    |"1" -> ExecInst.NotHeld
    |"2" -> ExecInst.Work
    |"3" -> ExecInst.GoAlong
    |"4" -> ExecInst.OverTheDay
    |"5" -> ExecInst.Held
    |"6" -> ExecInst.ParticipateDontInitiate
    |"7" -> ExecInst.StrictScale
    |"8" -> ExecInst.TryToScale
    |"9" -> ExecInst.StayOnBidside
    |"0" -> ExecInst.StayOnOfferside
    |"A" -> ExecInst.NoCross
    |"B" -> ExecInst.OkToCross
    |"C" -> ExecInst.CallFirst
    |"D" -> ExecInst.PercentOfVolume
    |"E" -> ExecInst.DoNotIncrease
    |"F" -> ExecInst.DoNotReduce
    |"G" -> ExecInst.AllOrNone
    |"H" -> ExecInst.ReinstateOnSystemFailure
    |"I" -> ExecInst.InstitutionsOnly
    |"J" -> ExecInst.ReinstateOnTradingHalt
    |"K" -> ExecInst.CancelOnTradingHalt
    |"L" -> ExecInst.LastPeg
    |"M" -> ExecInst.MidPrice
    |"N" -> ExecInst.NonNegotiable
    |"O" -> ExecInst.OpeningPeg
    |"P" -> ExecInst.MarketPeg
    |"Q" -> ExecInst.CancelOnSystemFailure
    |"R" -> ExecInst.PrimaryPeg
    |"S" -> ExecInst.Suspend
    |"T" -> ExecInst.FixedPegToLocalBestBidOrOfferAtTimeOfOrder
    |"U" -> ExecInst.CustomerDisplayInstruction
    |"V" -> ExecInst.Netting
    |"W" -> ExecInst.PegToVwap
    |"X" -> ExecInst.TradeAlong
    |"Y" -> ExecInst.TryToStop
    |"Z" -> ExecInst.CancelIfNotBest
    |"a" -> ExecInst.TrailingStopPeg
    |"b" -> ExecInst.StrictLimit
    |"c" -> ExecInst.IgnorePriceValidityChecks
    |"d" -> ExecInst.PegToLimitPrice
    |"e" -> ExecInst.WorkToTargetStrategy
    | x -> failwith (sprintf "ReadExecInst unknown fix tag: %A"  x) 


let WriteExecInst (strm:Stream) (xxIn:ExecInst) =
    match xxIn with
    | ExecInst.NotHeld -> strm.Write "18=1"B; strm.Write (delim, 0, 1)
    | ExecInst.Work -> strm.Write "18=2"B; strm.Write (delim, 0, 1)
    | ExecInst.GoAlong -> strm.Write "18=3"B; strm.Write (delim, 0, 1)
    | ExecInst.OverTheDay -> strm.Write "18=4"B; strm.Write (delim, 0, 1)
    | ExecInst.Held -> strm.Write "18=5"B; strm.Write (delim, 0, 1)
    | ExecInst.ParticipateDontInitiate -> strm.Write "18=6"B; strm.Write (delim, 0, 1)
    | ExecInst.StrictScale -> strm.Write "18=7"B; strm.Write (delim, 0, 1)
    | ExecInst.TryToScale -> strm.Write "18=8"B; strm.Write (delim, 0, 1)
    | ExecInst.StayOnBidside -> strm.Write "18=9"B; strm.Write (delim, 0, 1)
    | ExecInst.StayOnOfferside -> strm.Write "18=0"B; strm.Write (delim, 0, 1)
    | ExecInst.NoCross -> strm.Write "18=A"B; strm.Write (delim, 0, 1)
    | ExecInst.OkToCross -> strm.Write "18=B"B; strm.Write (delim, 0, 1)
    | ExecInst.CallFirst -> strm.Write "18=C"B; strm.Write (delim, 0, 1)
    | ExecInst.PercentOfVolume -> strm.Write "18=D"B; strm.Write (delim, 0, 1)
    | ExecInst.DoNotIncrease -> strm.Write "18=E"B; strm.Write (delim, 0, 1)
    | ExecInst.DoNotReduce -> strm.Write "18=F"B; strm.Write (delim, 0, 1)
    | ExecInst.AllOrNone -> strm.Write "18=G"B; strm.Write (delim, 0, 1)
    | ExecInst.ReinstateOnSystemFailure -> strm.Write "18=H"B; strm.Write (delim, 0, 1)
    | ExecInst.InstitutionsOnly -> strm.Write "18=I"B; strm.Write (delim, 0, 1)
    | ExecInst.ReinstateOnTradingHalt -> strm.Write "18=J"B; strm.Write (delim, 0, 1)
    | ExecInst.CancelOnTradingHalt -> strm.Write "18=K"B; strm.Write (delim, 0, 1)
    | ExecInst.LastPeg -> strm.Write "18=L"B; strm.Write (delim, 0, 1)
    | ExecInst.MidPrice -> strm.Write "18=M"B; strm.Write (delim, 0, 1)
    | ExecInst.NonNegotiable -> strm.Write "18=N"B; strm.Write (delim, 0, 1)
    | ExecInst.OpeningPeg -> strm.Write "18=O"B; strm.Write (delim, 0, 1)
    | ExecInst.MarketPeg -> strm.Write "18=P"B; strm.Write (delim, 0, 1)
    | ExecInst.CancelOnSystemFailure -> strm.Write "18=Q"B; strm.Write (delim, 0, 1)
    | ExecInst.PrimaryPeg -> strm.Write "18=R"B; strm.Write (delim, 0, 1)
    | ExecInst.Suspend -> strm.Write "18=S"B; strm.Write (delim, 0, 1)
    | ExecInst.FixedPegToLocalBestBidOrOfferAtTimeOfOrder -> strm.Write "18=T"B; strm.Write (delim, 0, 1)
    | ExecInst.CustomerDisplayInstruction -> strm.Write "18=U"B; strm.Write (delim, 0, 1)
    | ExecInst.Netting -> strm.Write "18=V"B; strm.Write (delim, 0, 1)
    | ExecInst.PegToVwap -> strm.Write "18=W"B; strm.Write (delim, 0, 1)
    | ExecInst.TradeAlong -> strm.Write "18=X"B; strm.Write (delim, 0, 1)
    | ExecInst.TryToStop -> strm.Write "18=Y"B; strm.Write (delim, 0, 1)
    | ExecInst.CancelIfNotBest -> strm.Write "18=Z"B; strm.Write (delim, 0, 1)
    | ExecInst.TrailingStopPeg -> strm.Write "18=a"B; strm.Write (delim, 0, 1)
    | ExecInst.StrictLimit -> strm.Write "18=b"B; strm.Write (delim, 0, 1)
    | ExecInst.IgnorePriceValidityChecks -> strm.Write "18=c"B; strm.Write (delim, 0, 1)
    | ExecInst.PegToLimitPrice -> strm.Write "18=d"B; strm.Write (delim, 0, 1)
    | ExecInst.WorkToTargetStrategy -> strm.Write "18=e"B; strm.Write (delim, 0, 1)


let ReadExecRefID valIn =
    let tmp =  valIn
    ExecRefID.ExecRefID tmp


let WriteExecRefID (strm:Stream) (valIn:ExecRefID) = 
    let tag = "19="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadHandlInst (fldValIn:string) : HandlInst = 
    match fldValIn with
    |"1" -> HandlInst.AutomatedExecutionOrderPrivate
    |"2" -> HandlInst.AutomatedExecutionOrderPublic
    |"3" -> HandlInst.ManualOrder
    | x -> failwith (sprintf "ReadHandlInst unknown fix tag: %A"  x) 


let WriteHandlInst (strm:Stream) (xxIn:HandlInst) =
    match xxIn with
    | HandlInst.AutomatedExecutionOrderPrivate -> strm.Write "21=1"B; strm.Write (delim, 0, 1)
    | HandlInst.AutomatedExecutionOrderPublic -> strm.Write "21=2"B; strm.Write (delim, 0, 1)
    | HandlInst.ManualOrder -> strm.Write "21=3"B; strm.Write (delim, 0, 1)


let ReadSecurityIDSource (fldValIn:string) : SecurityIDSource = 
    match fldValIn with
    |"1" -> SecurityIDSource.Cusip
    |"2" -> SecurityIDSource.Sedol
    |"3" -> SecurityIDSource.Quik
    |"4" -> SecurityIDSource.IsinNumber
    |"5" -> SecurityIDSource.RicCode
    |"6" -> SecurityIDSource.IsoCurrencyCode
    |"7" -> SecurityIDSource.IsoCountryCode
    |"8" -> SecurityIDSource.ExchangeSymbol
    |"9" -> SecurityIDSource.ConsolidatedTapeAssociation
    |"A" -> SecurityIDSource.BloombergSymbol
    |"B" -> SecurityIDSource.Wertpapier
    |"C" -> SecurityIDSource.Dutch
    |"D" -> SecurityIDSource.Valoren
    |"E" -> SecurityIDSource.Sicovam
    |"F" -> SecurityIDSource.Belgian
    |"G" -> SecurityIDSource.Common
    |"H" -> SecurityIDSource.ClearingHouseClearingOrganization
    |"I" -> SecurityIDSource.IsdaFpmlProductSpecification
    |"J" -> SecurityIDSource.OptionsPriceReportingAuthority
    | x -> failwith (sprintf "ReadSecurityIDSource unknown fix tag: %A"  x) 


let WriteSecurityIDSource (strm:Stream) (xxIn:SecurityIDSource) =
    match xxIn with
    | SecurityIDSource.Cusip -> strm.Write "22=1"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.Sedol -> strm.Write "22=2"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.Quik -> strm.Write "22=3"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.IsinNumber -> strm.Write "22=4"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.RicCode -> strm.Write "22=5"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.IsoCurrencyCode -> strm.Write "22=6"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.IsoCountryCode -> strm.Write "22=7"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.ExchangeSymbol -> strm.Write "22=8"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.ConsolidatedTapeAssociation -> strm.Write "22=9"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.BloombergSymbol -> strm.Write "22=A"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.Wertpapier -> strm.Write "22=B"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.Dutch -> strm.Write "22=C"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.Valoren -> strm.Write "22=D"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.Sicovam -> strm.Write "22=E"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.Belgian -> strm.Write "22=F"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.Common -> strm.Write "22=G"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.ClearingHouseClearingOrganization -> strm.Write "22=H"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.IsdaFpmlProductSpecification -> strm.Write "22=I"B; strm.Write (delim, 0, 1)
    | SecurityIDSource.OptionsPriceReportingAuthority -> strm.Write "22=J"B; strm.Write (delim, 0, 1)


let ReadIOIid valIn =
    let tmp =  valIn
    IOIid.IOIid tmp


let WriteIOIid (strm:Stream) (valIn:IOIid) = 
    let tag = "23="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadIOIQltyInd (fldValIn:string) : IOIQltyInd = 
    match fldValIn with
    |"L" -> IOIQltyInd.Low
    |"M" -> IOIQltyInd.Medium
    |"H" -> IOIQltyInd.High
    | x -> failwith (sprintf "ReadIOIQltyInd unknown fix tag: %A"  x) 


let WriteIOIQltyInd (strm:Stream) (xxIn:IOIQltyInd) =
    match xxIn with
    | IOIQltyInd.Low -> strm.Write "25=L"B; strm.Write (delim, 0, 1)
    | IOIQltyInd.Medium -> strm.Write "25=M"B; strm.Write (delim, 0, 1)
    | IOIQltyInd.High -> strm.Write "25=H"B; strm.Write (delim, 0, 1)


let ReadIOIRefID valIn =
    let tmp =  valIn
    IOIRefID.IOIRefID tmp


let WriteIOIRefID (strm:Stream) (valIn:IOIRefID) = 
    let tag = "26="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadIOIQty valIn =
    let tmp =  valIn
    IOIQty.IOIQty tmp


let WriteIOIQty (strm:Stream) (valIn:IOIQty) = 
    let tag = "27="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadIOITransType (fldValIn:string) : IOITransType = 
    match fldValIn with
    |"N" -> IOITransType.New
    |"C" -> IOITransType.Cancel
    |"R" -> IOITransType.Replace
    | x -> failwith (sprintf "ReadIOITransType unknown fix tag: %A"  x) 


let WriteIOITransType (strm:Stream) (xxIn:IOITransType) =
    match xxIn with
    | IOITransType.New -> strm.Write "28=N"B; strm.Write (delim, 0, 1)
    | IOITransType.Cancel -> strm.Write "28=C"B; strm.Write (delim, 0, 1)
    | IOITransType.Replace -> strm.Write "28=R"B; strm.Write (delim, 0, 1)


let ReadLastCapacity (fldValIn:string) : LastCapacity = 
    match fldValIn with
    |"1" -> LastCapacity.Agent
    |"2" -> LastCapacity.CrossAsAgent
    |"3" -> LastCapacity.CrossAsPrincipal
    |"4" -> LastCapacity.Principal
    | x -> failwith (sprintf "ReadLastCapacity unknown fix tag: %A"  x) 


let WriteLastCapacity (strm:Stream) (xxIn:LastCapacity) =
    match xxIn with
    | LastCapacity.Agent -> strm.Write "29=1"B; strm.Write (delim, 0, 1)
    | LastCapacity.CrossAsAgent -> strm.Write "29=2"B; strm.Write (delim, 0, 1)
    | LastCapacity.CrossAsPrincipal -> strm.Write "29=3"B; strm.Write (delim, 0, 1)
    | LastCapacity.Principal -> strm.Write "29=4"B; strm.Write (delim, 0, 1)


let ReadLastMkt valIn =
    let tmp =  valIn
    LastMkt.LastMkt tmp


let WriteLastMkt (strm:Stream) (valIn:LastMkt) = 
    let tag = "30="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLastPx valIn =
    let tmp = System.Decimal.Parse valIn
    LastPx.LastPx tmp


let WriteLastPx (strm:Stream) (valIn:LastPx) = 
    let tag = "31="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLastQty valIn =
    let tmp = System.Decimal.Parse valIn
    LastQty.LastQty tmp


let WriteLastQty (strm:Stream) (valIn:LastQty) = 
    let tag = "32="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLinesOfText valIn =
    let tmp = System.Int32.Parse valIn
    LinesOfText.LinesOfText tmp


let WriteLinesOfText (strm:Stream) (valIn:LinesOfText) = 
    let tag = "33="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMsgSeqNum valIn =
    let tmp = System.Int32.Parse valIn
    MsgSeqNum.MsgSeqNum tmp


let WriteMsgSeqNum (strm:Stream) (valIn:MsgSeqNum) = 
    let tag = "34="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMsgType (fldValIn:string) : MsgType = 
    match fldValIn with
    |"0" -> MsgType.Heartbeat
    |"1" -> MsgType.TestRequest
    |"2" -> MsgType.ResendRequest
    |"3" -> MsgType.Reject
    |"4" -> MsgType.SequenceReset
    |"5" -> MsgType.Logout
    |"6" -> MsgType.IndicationOfInterest
    |"7" -> MsgType.Advertisement
    |"8" -> MsgType.ExecutionReport
    |"9" -> MsgType.OrderCancelReject
    |"A" -> MsgType.Logon
    |"B" -> MsgType.News
    |"C" -> MsgType.Email
    |"D" -> MsgType.OrderSingle
    |"E" -> MsgType.OrderList
    |"F" -> MsgType.OrderCancelRequest
    |"G" -> MsgType.OrderCancelReplaceRequest
    |"H" -> MsgType.OrderStatusRequest
    |"J" -> MsgType.AllocationInstruction
    |"K" -> MsgType.ListCancelRequest
    |"L" -> MsgType.ListExecute
    |"M" -> MsgType.ListStatusRequest
    |"N" -> MsgType.ListStatus
    |"P" -> MsgType.AllocationInstructionAck
    |"Q" -> MsgType.DontKnowTrade
    |"R" -> MsgType.QuoteRequest
    |"S" -> MsgType.Quote
    |"T" -> MsgType.SettlementInstructions
    |"V" -> MsgType.MarketDataRequest
    |"W" -> MsgType.MarketDataSnapshotFullRefresh
    |"X" -> MsgType.MarketDataIncrementalRefresh
    |"Y" -> MsgType.MarketDataRequestReject
    |"Z" -> MsgType.QuoteCancel
    |"a" -> MsgType.QuoteStatusRequest
    |"b" -> MsgType.MassQuoteAcknowledgement
    |"c" -> MsgType.SecurityDefinitionRequest
    |"d" -> MsgType.SecurityDefinition
    |"e" -> MsgType.SecurityStatusRequest
    |"f" -> MsgType.SecurityStatus
    |"g" -> MsgType.TradingSessionStatusRequest
    |"h" -> MsgType.TradingSessionStatus
    |"i" -> MsgType.MassQuote
    |"j" -> MsgType.BusinessMessageReject
    |"k" -> MsgType.BidRequest
    |"l" -> MsgType.BidResponse
    |"m" -> MsgType.ListStrikePrice
    |"n" -> MsgType.XmlMessage
    |"o" -> MsgType.RegistrationInstructions
    |"p" -> MsgType.RegistrationInstructionsResponse
    |"q" -> MsgType.OrderMassCancelRequest
    |"r" -> MsgType.OrderMassCancelReport
    |"s" -> MsgType.NewOrderCross
    |"t" -> MsgType.CrossOrderCancelReplaceRequest
    |"u" -> MsgType.CrossOrderCancelRequest
    |"v" -> MsgType.SecurityTypeRequest
    |"w" -> MsgType.SecurityTypes
    |"x" -> MsgType.SecurityListRequest
    |"y" -> MsgType.SecurityList
    |"z" -> MsgType.DerivativeSecurityListRequest
    |"AA" -> MsgType.DerivativeSecurityList
    |"AB" -> MsgType.NewOrderMultileg
    |"AC" -> MsgType.MultilegOrderCancelReplace
    |"AD" -> MsgType.TradeCaptureReportRequest
    |"AE" -> MsgType.TradeCaptureReport
    |"AF" -> MsgType.OrderMassStatusRequest
    |"AG" -> MsgType.QuoteRequestReject
    |"AH" -> MsgType.RfqRequest
    |"AI" -> MsgType.QuoteStatusReport
    |"AJ" -> MsgType.QuoteResponse
    |"AK" -> MsgType.Confirmation
    |"AL" -> MsgType.PositionMaintenanceRequest
    |"AM" -> MsgType.PositionMaintenanceReport
    |"AN" -> MsgType.RequestForPositions
    |"AO" -> MsgType.RequestForPositionsAck
    |"AP" -> MsgType.PositionReport
    |"AQ" -> MsgType.TradeCaptureReportRequestAck
    |"AR" -> MsgType.TradeCaptureReportAck
    |"AS" -> MsgType.AllocationReport
    |"AT" -> MsgType.AllocationReportAck
    |"AU" -> MsgType.ConfirmationAck
    |"AV" -> MsgType.SettlementInstructionRequest
    |"AW" -> MsgType.AssignmentReport
    |"AX" -> MsgType.CollateralRequest
    |"AY" -> MsgType.CollateralAssignment
    |"AZ" -> MsgType.CollateralResponse
    |"BA" -> MsgType.CollateralReport
    |"BB" -> MsgType.CollateralInquiry
    |"BC" -> MsgType.NetworkStatusRequest
    |"BD" -> MsgType.NetworkStatusResponse
    |"BE" -> MsgType.UserRequest
    |"BF" -> MsgType.UserResponse
    |"BG" -> MsgType.CollateralInquiryAck
    |"BH" -> MsgType.ConfirmationRequest
    | x -> failwith (sprintf "ReadMsgType unknown fix tag: %A"  x) 


let WriteMsgType (strm:Stream) (xxIn:MsgType) =
    match xxIn with
    | MsgType.Heartbeat -> strm.Write "35=0"B; strm.Write (delim, 0, 1)
    | MsgType.TestRequest -> strm.Write "35=1"B; strm.Write (delim, 0, 1)
    | MsgType.ResendRequest -> strm.Write "35=2"B; strm.Write (delim, 0, 1)
    | MsgType.Reject -> strm.Write "35=3"B; strm.Write (delim, 0, 1)
    | MsgType.SequenceReset -> strm.Write "35=4"B; strm.Write (delim, 0, 1)
    | MsgType.Logout -> strm.Write "35=5"B; strm.Write (delim, 0, 1)
    | MsgType.IndicationOfInterest -> strm.Write "35=6"B; strm.Write (delim, 0, 1)
    | MsgType.Advertisement -> strm.Write "35=7"B; strm.Write (delim, 0, 1)
    | MsgType.ExecutionReport -> strm.Write "35=8"B; strm.Write (delim, 0, 1)
    | MsgType.OrderCancelReject -> strm.Write "35=9"B; strm.Write (delim, 0, 1)
    | MsgType.Logon -> strm.Write "35=A"B; strm.Write (delim, 0, 1)
    | MsgType.News -> strm.Write "35=B"B; strm.Write (delim, 0, 1)
    | MsgType.Email -> strm.Write "35=C"B; strm.Write (delim, 0, 1)
    | MsgType.OrderSingle -> strm.Write "35=D"B; strm.Write (delim, 0, 1)
    | MsgType.OrderList -> strm.Write "35=E"B; strm.Write (delim, 0, 1)
    | MsgType.OrderCancelRequest -> strm.Write "35=F"B; strm.Write (delim, 0, 1)
    | MsgType.OrderCancelReplaceRequest -> strm.Write "35=G"B; strm.Write (delim, 0, 1)
    | MsgType.OrderStatusRequest -> strm.Write "35=H"B; strm.Write (delim, 0, 1)
    | MsgType.AllocationInstruction -> strm.Write "35=J"B; strm.Write (delim, 0, 1)
    | MsgType.ListCancelRequest -> strm.Write "35=K"B; strm.Write (delim, 0, 1)
    | MsgType.ListExecute -> strm.Write "35=L"B; strm.Write (delim, 0, 1)
    | MsgType.ListStatusRequest -> strm.Write "35=M"B; strm.Write (delim, 0, 1)
    | MsgType.ListStatus -> strm.Write "35=N"B; strm.Write (delim, 0, 1)
    | MsgType.AllocationInstructionAck -> strm.Write "35=P"B; strm.Write (delim, 0, 1)
    | MsgType.DontKnowTrade -> strm.Write "35=Q"B; strm.Write (delim, 0, 1)
    | MsgType.QuoteRequest -> strm.Write "35=R"B; strm.Write (delim, 0, 1)
    | MsgType.Quote -> strm.Write "35=S"B; strm.Write (delim, 0, 1)
    | MsgType.SettlementInstructions -> strm.Write "35=T"B; strm.Write (delim, 0, 1)
    | MsgType.MarketDataRequest -> strm.Write "35=V"B; strm.Write (delim, 0, 1)
    | MsgType.MarketDataSnapshotFullRefresh -> strm.Write "35=W"B; strm.Write (delim, 0, 1)
    | MsgType.MarketDataIncrementalRefresh -> strm.Write "35=X"B; strm.Write (delim, 0, 1)
    | MsgType.MarketDataRequestReject -> strm.Write "35=Y"B; strm.Write (delim, 0, 1)
    | MsgType.QuoteCancel -> strm.Write "35=Z"B; strm.Write (delim, 0, 1)
    | MsgType.QuoteStatusRequest -> strm.Write "35=a"B; strm.Write (delim, 0, 1)
    | MsgType.MassQuoteAcknowledgement -> strm.Write "35=b"B; strm.Write (delim, 0, 1)
    | MsgType.SecurityDefinitionRequest -> strm.Write "35=c"B; strm.Write (delim, 0, 1)
    | MsgType.SecurityDefinition -> strm.Write "35=d"B; strm.Write (delim, 0, 1)
    | MsgType.SecurityStatusRequest -> strm.Write "35=e"B; strm.Write (delim, 0, 1)
    | MsgType.SecurityStatus -> strm.Write "35=f"B; strm.Write (delim, 0, 1)
    | MsgType.TradingSessionStatusRequest -> strm.Write "35=g"B; strm.Write (delim, 0, 1)
    | MsgType.TradingSessionStatus -> strm.Write "35=h"B; strm.Write (delim, 0, 1)
    | MsgType.MassQuote -> strm.Write "35=i"B; strm.Write (delim, 0, 1)
    | MsgType.BusinessMessageReject -> strm.Write "35=j"B; strm.Write (delim, 0, 1)
    | MsgType.BidRequest -> strm.Write "35=k"B; strm.Write (delim, 0, 1)
    | MsgType.BidResponse -> strm.Write "35=l"B; strm.Write (delim, 0, 1)
    | MsgType.ListStrikePrice -> strm.Write "35=m"B; strm.Write (delim, 0, 1)
    | MsgType.XmlMessage -> strm.Write "35=n"B; strm.Write (delim, 0, 1)
    | MsgType.RegistrationInstructions -> strm.Write "35=o"B; strm.Write (delim, 0, 1)
    | MsgType.RegistrationInstructionsResponse -> strm.Write "35=p"B; strm.Write (delim, 0, 1)
    | MsgType.OrderMassCancelRequest -> strm.Write "35=q"B; strm.Write (delim, 0, 1)
    | MsgType.OrderMassCancelReport -> strm.Write "35=r"B; strm.Write (delim, 0, 1)
    | MsgType.NewOrderCross -> strm.Write "35=s"B; strm.Write (delim, 0, 1)
    | MsgType.CrossOrderCancelReplaceRequest -> strm.Write "35=t"B; strm.Write (delim, 0, 1)
    | MsgType.CrossOrderCancelRequest -> strm.Write "35=u"B; strm.Write (delim, 0, 1)
    | MsgType.SecurityTypeRequest -> strm.Write "35=v"B; strm.Write (delim, 0, 1)
    | MsgType.SecurityTypes -> strm.Write "35=w"B; strm.Write (delim, 0, 1)
    | MsgType.SecurityListRequest -> strm.Write "35=x"B; strm.Write (delim, 0, 1)
    | MsgType.SecurityList -> strm.Write "35=y"B; strm.Write (delim, 0, 1)
    | MsgType.DerivativeSecurityListRequest -> strm.Write "35=z"B; strm.Write (delim, 0, 1)
    | MsgType.DerivativeSecurityList -> strm.Write "35=AA"B; strm.Write (delim, 0, 1)
    | MsgType.NewOrderMultileg -> strm.Write "35=AB"B; strm.Write (delim, 0, 1)
    | MsgType.MultilegOrderCancelReplace -> strm.Write "35=AC"B; strm.Write (delim, 0, 1)
    | MsgType.TradeCaptureReportRequest -> strm.Write "35=AD"B; strm.Write (delim, 0, 1)
    | MsgType.TradeCaptureReport -> strm.Write "35=AE"B; strm.Write (delim, 0, 1)
    | MsgType.OrderMassStatusRequest -> strm.Write "35=AF"B; strm.Write (delim, 0, 1)
    | MsgType.QuoteRequestReject -> strm.Write "35=AG"B; strm.Write (delim, 0, 1)
    | MsgType.RfqRequest -> strm.Write "35=AH"B; strm.Write (delim, 0, 1)
    | MsgType.QuoteStatusReport -> strm.Write "35=AI"B; strm.Write (delim, 0, 1)
    | MsgType.QuoteResponse -> strm.Write "35=AJ"B; strm.Write (delim, 0, 1)
    | MsgType.Confirmation -> strm.Write "35=AK"B; strm.Write (delim, 0, 1)
    | MsgType.PositionMaintenanceRequest -> strm.Write "35=AL"B; strm.Write (delim, 0, 1)
    | MsgType.PositionMaintenanceReport -> strm.Write "35=AM"B; strm.Write (delim, 0, 1)
    | MsgType.RequestForPositions -> strm.Write "35=AN"B; strm.Write (delim, 0, 1)
    | MsgType.RequestForPositionsAck -> strm.Write "35=AO"B; strm.Write (delim, 0, 1)
    | MsgType.PositionReport -> strm.Write "35=AP"B; strm.Write (delim, 0, 1)
    | MsgType.TradeCaptureReportRequestAck -> strm.Write "35=AQ"B; strm.Write (delim, 0, 1)
    | MsgType.TradeCaptureReportAck -> strm.Write "35=AR"B; strm.Write (delim, 0, 1)
    | MsgType.AllocationReport -> strm.Write "35=AS"B; strm.Write (delim, 0, 1)
    | MsgType.AllocationReportAck -> strm.Write "35=AT"B; strm.Write (delim, 0, 1)
    | MsgType.ConfirmationAck -> strm.Write "35=AU"B; strm.Write (delim, 0, 1)
    | MsgType.SettlementInstructionRequest -> strm.Write "35=AV"B; strm.Write (delim, 0, 1)
    | MsgType.AssignmentReport -> strm.Write "35=AW"B; strm.Write (delim, 0, 1)
    | MsgType.CollateralRequest -> strm.Write "35=AX"B; strm.Write (delim, 0, 1)
    | MsgType.CollateralAssignment -> strm.Write "35=AY"B; strm.Write (delim, 0, 1)
    | MsgType.CollateralResponse -> strm.Write "35=AZ"B; strm.Write (delim, 0, 1)
    | MsgType.CollateralReport -> strm.Write "35=BA"B; strm.Write (delim, 0, 1)
    | MsgType.CollateralInquiry -> strm.Write "35=BB"B; strm.Write (delim, 0, 1)
    | MsgType.NetworkStatusRequest -> strm.Write "35=BC"B; strm.Write (delim, 0, 1)
    | MsgType.NetworkStatusResponse -> strm.Write "35=BD"B; strm.Write (delim, 0, 1)
    | MsgType.UserRequest -> strm.Write "35=BE"B; strm.Write (delim, 0, 1)
    | MsgType.UserResponse -> strm.Write "35=BF"B; strm.Write (delim, 0, 1)
    | MsgType.CollateralInquiryAck -> strm.Write "35=BG"B; strm.Write (delim, 0, 1)
    | MsgType.ConfirmationRequest -> strm.Write "35=BH"B; strm.Write (delim, 0, 1)


let ReadNewSeqNo valIn =
    let tmp = System.Int32.Parse valIn
    NewSeqNo.NewSeqNo tmp


let WriteNewSeqNo (strm:Stream) (valIn:NewSeqNo) = 
    let tag = "36="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOrderID valIn =
    let tmp =  valIn
    OrderID.OrderID tmp


let WriteOrderID (strm:Stream) (valIn:OrderID) = 
    let tag = "37="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOrderQty valIn =
    let tmp = System.Decimal.Parse valIn
    OrderQty.OrderQty tmp


let WriteOrderQty (strm:Stream) (valIn:OrderQty) = 
    let tag = "38="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOrdStatus (fldValIn:string) : OrdStatus = 
    match fldValIn with
    |"0" -> OrdStatus.New
    |"1" -> OrdStatus.PartiallyFilled
    |"2" -> OrdStatus.Filled
    |"3" -> OrdStatus.DoneForDay
    |"4" -> OrdStatus.Canceled
    |"5" -> OrdStatus.Replaced
    |"6" -> OrdStatus.PendingCancel
    |"7" -> OrdStatus.Stopped
    |"8" -> OrdStatus.Rejected
    |"9" -> OrdStatus.Suspended
    |"A" -> OrdStatus.PendingNew
    |"B" -> OrdStatus.Calculated
    |"C" -> OrdStatus.Expired
    |"D" -> OrdStatus.AcceptedForBidding
    |"E" -> OrdStatus.PendingReplace
    | x -> failwith (sprintf "ReadOrdStatus unknown fix tag: %A"  x) 


let WriteOrdStatus (strm:Stream) (xxIn:OrdStatus) =
    match xxIn with
    | OrdStatus.New -> strm.Write "39=0"B; strm.Write (delim, 0, 1)
    | OrdStatus.PartiallyFilled -> strm.Write "39=1"B; strm.Write (delim, 0, 1)
    | OrdStatus.Filled -> strm.Write "39=2"B; strm.Write (delim, 0, 1)
    | OrdStatus.DoneForDay -> strm.Write "39=3"B; strm.Write (delim, 0, 1)
    | OrdStatus.Canceled -> strm.Write "39=4"B; strm.Write (delim, 0, 1)
    | OrdStatus.Replaced -> strm.Write "39=5"B; strm.Write (delim, 0, 1)
    | OrdStatus.PendingCancel -> strm.Write "39=6"B; strm.Write (delim, 0, 1)
    | OrdStatus.Stopped -> strm.Write "39=7"B; strm.Write (delim, 0, 1)
    | OrdStatus.Rejected -> strm.Write "39=8"B; strm.Write (delim, 0, 1)
    | OrdStatus.Suspended -> strm.Write "39=9"B; strm.Write (delim, 0, 1)
    | OrdStatus.PendingNew -> strm.Write "39=A"B; strm.Write (delim, 0, 1)
    | OrdStatus.Calculated -> strm.Write "39=B"B; strm.Write (delim, 0, 1)
    | OrdStatus.Expired -> strm.Write "39=C"B; strm.Write (delim, 0, 1)
    | OrdStatus.AcceptedForBidding -> strm.Write "39=D"B; strm.Write (delim, 0, 1)
    | OrdStatus.PendingReplace -> strm.Write "39=E"B; strm.Write (delim, 0, 1)


let ReadOrdType (fldValIn:string) : OrdType = 
    match fldValIn with
    |"1" -> OrdType.Market
    |"2" -> OrdType.Limit
    |"3" -> OrdType.Stop
    |"4" -> OrdType.StopLimit
    |"5" -> OrdType.MarketOnClose
    |"6" -> OrdType.WithOrWithout
    |"7" -> OrdType.LimitOrBetter
    |"8" -> OrdType.LimitWithOrWithout
    |"9" -> OrdType.OnBasis
    |"A" -> OrdType.OnClose
    |"B" -> OrdType.LimitOnClose
    |"C" -> OrdType.ForexMarket
    |"D" -> OrdType.PreviouslyQuoted
    |"E" -> OrdType.PreviouslyIndicated
    |"F" -> OrdType.ForexLimit
    |"G" -> OrdType.ForexSwap
    |"H" -> OrdType.ForexPreviouslyQuoted
    |"I" -> OrdType.Funari
    |"J" -> OrdType.MarketIfTouched
    |"K" -> OrdType.MarketWithLeftoverAsLimit
    |"L" -> OrdType.PreviousFundValuationPoint
    |"M" -> OrdType.NextFundValuationPoint
    |"P" -> OrdType.Pegged
    | x -> failwith (sprintf "ReadOrdType unknown fix tag: %A"  x) 


let WriteOrdType (strm:Stream) (xxIn:OrdType) =
    match xxIn with
    | OrdType.Market -> strm.Write "40=1"B; strm.Write (delim, 0, 1)
    | OrdType.Limit -> strm.Write "40=2"B; strm.Write (delim, 0, 1)
    | OrdType.Stop -> strm.Write "40=3"B; strm.Write (delim, 0, 1)
    | OrdType.StopLimit -> strm.Write "40=4"B; strm.Write (delim, 0, 1)
    | OrdType.MarketOnClose -> strm.Write "40=5"B; strm.Write (delim, 0, 1)
    | OrdType.WithOrWithout -> strm.Write "40=6"B; strm.Write (delim, 0, 1)
    | OrdType.LimitOrBetter -> strm.Write "40=7"B; strm.Write (delim, 0, 1)
    | OrdType.LimitWithOrWithout -> strm.Write "40=8"B; strm.Write (delim, 0, 1)
    | OrdType.OnBasis -> strm.Write "40=9"B; strm.Write (delim, 0, 1)
    | OrdType.OnClose -> strm.Write "40=A"B; strm.Write (delim, 0, 1)
    | OrdType.LimitOnClose -> strm.Write "40=B"B; strm.Write (delim, 0, 1)
    | OrdType.ForexMarket -> strm.Write "40=C"B; strm.Write (delim, 0, 1)
    | OrdType.PreviouslyQuoted -> strm.Write "40=D"B; strm.Write (delim, 0, 1)
    | OrdType.PreviouslyIndicated -> strm.Write "40=E"B; strm.Write (delim, 0, 1)
    | OrdType.ForexLimit -> strm.Write "40=F"B; strm.Write (delim, 0, 1)
    | OrdType.ForexSwap -> strm.Write "40=G"B; strm.Write (delim, 0, 1)
    | OrdType.ForexPreviouslyQuoted -> strm.Write "40=H"B; strm.Write (delim, 0, 1)
    | OrdType.Funari -> strm.Write "40=I"B; strm.Write (delim, 0, 1)
    | OrdType.MarketIfTouched -> strm.Write "40=J"B; strm.Write (delim, 0, 1)
    | OrdType.MarketWithLeftoverAsLimit -> strm.Write "40=K"B; strm.Write (delim, 0, 1)
    | OrdType.PreviousFundValuationPoint -> strm.Write "40=L"B; strm.Write (delim, 0, 1)
    | OrdType.NextFundValuationPoint -> strm.Write "40=M"B; strm.Write (delim, 0, 1)
    | OrdType.Pegged -> strm.Write "40=P"B; strm.Write (delim, 0, 1)


let ReadOrigClOrdID valIn =
    let tmp =  valIn
    OrigClOrdID.OrigClOrdID tmp


let WriteOrigClOrdID (strm:Stream) (valIn:OrigClOrdID) = 
    let tag = "41="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOrigTime valIn =
    let tmp =  valIn
    OrigTime.OrigTime tmp


let WriteOrigTime (strm:Stream) (valIn:OrigTime) = 
    let tag = "42="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPossDupFlag valIn =
    let tmp = System.Boolean.Parse valIn
    PossDupFlag.PossDupFlag tmp


let WritePossDupFlag (strm:Stream) (valIn:PossDupFlag) = 
    let tag = "43="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPrice valIn =
    let tmp = System.Decimal.Parse valIn
    Price.Price tmp


let WritePrice (strm:Stream) (valIn:Price) = 
    let tag = "44="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRefSeqNum valIn =
    let tmp = System.Int32.Parse valIn
    RefSeqNum.RefSeqNum tmp


let WriteRefSeqNum (strm:Stream) (valIn:RefSeqNum) = 
    let tag = "45="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecurityID valIn =
    let tmp =  valIn
    SecurityID.SecurityID tmp


let WriteSecurityID (strm:Stream) (valIn:SecurityID) = 
    let tag = "48="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSenderCompID valIn =
    let tmp =  valIn
    SenderCompID.SenderCompID tmp


let WriteSenderCompID (strm:Stream) (valIn:SenderCompID) = 
    let tag = "49="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSenderSubID valIn =
    let tmp =  valIn
    SenderSubID.SenderSubID tmp


let WriteSenderSubID (strm:Stream) (valIn:SenderSubID) = 
    let tag = "50="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSendingTime valIn =
    let tmp =  valIn
    SendingTime.SendingTime tmp


let WriteSendingTime (strm:Stream) (valIn:SendingTime) = 
    let tag = "52="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuantity valIn =
    let tmp = System.Decimal.Parse valIn
    Quantity.Quantity tmp


let WriteQuantity (strm:Stream) (valIn:Quantity) = 
    let tag = "53="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSide (fldValIn:string) : Side = 
    match fldValIn with
    |"1" -> Side.Buy
    |"2" -> Side.Sell
    |"3" -> Side.BuyMinus
    |"4" -> Side.SellPlus
    |"5" -> Side.SellShort
    |"6" -> Side.SellShortExempt
    |"7" -> Side.Undisclosed
    |"8" -> Side.Cross
    |"9" -> Side.CrossShort
    |"A" -> Side.CrossShortExempt
    |"B" -> Side.AsDefined
    |"C" -> Side.Opposite
    |"D" -> Side.Subscribe
    |"E" -> Side.Redeem
    |"F" -> Side.Lend
    |"G" -> Side.Borrow
    | x -> failwith (sprintf "ReadSide unknown fix tag: %A"  x) 


let WriteSide (strm:Stream) (xxIn:Side) =
    match xxIn with
    | Side.Buy -> strm.Write "54=1"B; strm.Write (delim, 0, 1)
    | Side.Sell -> strm.Write "54=2"B; strm.Write (delim, 0, 1)
    | Side.BuyMinus -> strm.Write "54=3"B; strm.Write (delim, 0, 1)
    | Side.SellPlus -> strm.Write "54=4"B; strm.Write (delim, 0, 1)
    | Side.SellShort -> strm.Write "54=5"B; strm.Write (delim, 0, 1)
    | Side.SellShortExempt -> strm.Write "54=6"B; strm.Write (delim, 0, 1)
    | Side.Undisclosed -> strm.Write "54=7"B; strm.Write (delim, 0, 1)
    | Side.Cross -> strm.Write "54=8"B; strm.Write (delim, 0, 1)
    | Side.CrossShort -> strm.Write "54=9"B; strm.Write (delim, 0, 1)
    | Side.CrossShortExempt -> strm.Write "54=A"B; strm.Write (delim, 0, 1)
    | Side.AsDefined -> strm.Write "54=B"B; strm.Write (delim, 0, 1)
    | Side.Opposite -> strm.Write "54=C"B; strm.Write (delim, 0, 1)
    | Side.Subscribe -> strm.Write "54=D"B; strm.Write (delim, 0, 1)
    | Side.Redeem -> strm.Write "54=E"B; strm.Write (delim, 0, 1)
    | Side.Lend -> strm.Write "54=F"B; strm.Write (delim, 0, 1)
    | Side.Borrow -> strm.Write "54=G"B; strm.Write (delim, 0, 1)


let ReadSymbol valIn =
    let tmp =  valIn
    Symbol.Symbol tmp


let WriteSymbol (strm:Stream) (valIn:Symbol) = 
    let tag = "55="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTargetCompID valIn =
    let tmp =  valIn
    TargetCompID.TargetCompID tmp


let WriteTargetCompID (strm:Stream) (valIn:TargetCompID) = 
    let tag = "56="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTargetSubID valIn =
    let tmp =  valIn
    TargetSubID.TargetSubID tmp


let WriteTargetSubID (strm:Stream) (valIn:TargetSubID) = 
    let tag = "57="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadText valIn =
    let tmp =  valIn
    Text.Text tmp


let WriteText (strm:Stream) (valIn:Text) = 
    let tag = "58="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTimeInForce (fldValIn:string) : TimeInForce = 
    match fldValIn with
    |"0" -> TimeInForce.Day
    |"1" -> TimeInForce.GoodTillCancel
    |"2" -> TimeInForce.AtTheOpening
    |"3" -> TimeInForce.ImmediateOrCancel
    |"4" -> TimeInForce.FillOrKill
    |"5" -> TimeInForce.GoodTillCrossing
    |"6" -> TimeInForce.GoodTillDate
    |"7" -> TimeInForce.AtTheClose
    | x -> failwith (sprintf "ReadTimeInForce unknown fix tag: %A"  x) 


let WriteTimeInForce (strm:Stream) (xxIn:TimeInForce) =
    match xxIn with
    | TimeInForce.Day -> strm.Write "59=0"B; strm.Write (delim, 0, 1)
    | TimeInForce.GoodTillCancel -> strm.Write "59=1"B; strm.Write (delim, 0, 1)
    | TimeInForce.AtTheOpening -> strm.Write "59=2"B; strm.Write (delim, 0, 1)
    | TimeInForce.ImmediateOrCancel -> strm.Write "59=3"B; strm.Write (delim, 0, 1)
    | TimeInForce.FillOrKill -> strm.Write "59=4"B; strm.Write (delim, 0, 1)
    | TimeInForce.GoodTillCrossing -> strm.Write "59=5"B; strm.Write (delim, 0, 1)
    | TimeInForce.GoodTillDate -> strm.Write "59=6"B; strm.Write (delim, 0, 1)
    | TimeInForce.AtTheClose -> strm.Write "59=7"B; strm.Write (delim, 0, 1)


let ReadTransactTime valIn =
    let tmp =  valIn
    TransactTime.TransactTime tmp


let WriteTransactTime (strm:Stream) (valIn:TransactTime) = 
    let tag = "60="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUrgency (fldValIn:string) : Urgency = 
    match fldValIn with
    |"0" -> Urgency.Normal
    |"1" -> Urgency.Flash
    |"2" -> Urgency.Background
    | x -> failwith (sprintf "ReadUrgency unknown fix tag: %A"  x) 


let WriteUrgency (strm:Stream) (xxIn:Urgency) =
    match xxIn with
    | Urgency.Normal -> strm.Write "61=0"B; strm.Write (delim, 0, 1)
    | Urgency.Flash -> strm.Write "61=1"B; strm.Write (delim, 0, 1)
    | Urgency.Background -> strm.Write "61=2"B; strm.Write (delim, 0, 1)


let ReadValidUntilTime valIn =
    let tmp =  valIn
    ValidUntilTime.ValidUntilTime tmp


let WriteValidUntilTime (strm:Stream) (valIn:ValidUntilTime) = 
    let tag = "62="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlType (fldValIn:string) : SettlType = 
    match fldValIn with
    |"0" -> SettlType.Regular
    |"1" -> SettlType.Cash
    |"2" -> SettlType.NextDay
    |"3" -> SettlType.TPlus2
    |"4" -> SettlType.TPlus3
    |"5" -> SettlType.TPlus4
    |"6" -> SettlType.Future
    |"7" -> SettlType.WhenAndIfIssued
    |"8" -> SettlType.SellersOption
    |"9" -> SettlType.TPlus5
    | x -> failwith (sprintf "ReadSettlType unknown fix tag: %A"  x) 


let WriteSettlType (strm:Stream) (xxIn:SettlType) =
    match xxIn with
    | SettlType.Regular -> strm.Write "63=0"B; strm.Write (delim, 0, 1)
    | SettlType.Cash -> strm.Write "63=1"B; strm.Write (delim, 0, 1)
    | SettlType.NextDay -> strm.Write "63=2"B; strm.Write (delim, 0, 1)
    | SettlType.TPlus2 -> strm.Write "63=3"B; strm.Write (delim, 0, 1)
    | SettlType.TPlus3 -> strm.Write "63=4"B; strm.Write (delim, 0, 1)
    | SettlType.TPlus4 -> strm.Write "63=5"B; strm.Write (delim, 0, 1)
    | SettlType.Future -> strm.Write "63=6"B; strm.Write (delim, 0, 1)
    | SettlType.WhenAndIfIssued -> strm.Write "63=7"B; strm.Write (delim, 0, 1)
    | SettlType.SellersOption -> strm.Write "63=8"B; strm.Write (delim, 0, 1)
    | SettlType.TPlus5 -> strm.Write "63=9"B; strm.Write (delim, 0, 1)


let ReadSettlDate valIn =
    let tmp =  valIn
    SettlDate.SettlDate tmp


let WriteSettlDate (strm:Stream) (valIn:SettlDate) = 
    let tag = "64="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSymbolSfx (fldValIn:string) : SymbolSfx = 
    match fldValIn with
    |"WI" -> SymbolSfx.WhenIssued
    |"CD" -> SymbolSfx.AEucpWithLumpSumInterest
    | x -> failwith (sprintf "ReadSymbolSfx unknown fix tag: %A"  x) 


let WriteSymbolSfx (strm:Stream) (xxIn:SymbolSfx) =
    match xxIn with
    | SymbolSfx.WhenIssued -> strm.Write "65=WI"B; strm.Write (delim, 0, 1)
    | SymbolSfx.AEucpWithLumpSumInterest -> strm.Write "65=CD"B; strm.Write (delim, 0, 1)


let ReadListID valIn =
    let tmp =  valIn
    ListID.ListID tmp


let WriteListID (strm:Stream) (valIn:ListID) = 
    let tag = "66="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadListSeqNo valIn =
    let tmp = System.Int32.Parse valIn
    ListSeqNo.ListSeqNo tmp


let WriteListSeqNo (strm:Stream) (valIn:ListSeqNo) = 
    let tag = "67="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTotNoOrders valIn =
    let tmp = System.Int32.Parse valIn
    TotNoOrders.TotNoOrders tmp


let WriteTotNoOrders (strm:Stream) (valIn:TotNoOrders) = 
    let tag = "68="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadListExecInst valIn =
    let tmp =  valIn
    ListExecInst.ListExecInst tmp


let WriteListExecInst (strm:Stream) (valIn:ListExecInst) = 
    let tag = "69="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocID valIn =
    let tmp =  valIn
    AllocID.AllocID tmp


let WriteAllocID (strm:Stream) (valIn:AllocID) = 
    let tag = "70="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocTransType (fldValIn:string) : AllocTransType = 
    match fldValIn with
    |"0" -> AllocTransType.New
    |"1" -> AllocTransType.Replace
    |"2" -> AllocTransType.Cancel
    | x -> failwith (sprintf "ReadAllocTransType unknown fix tag: %A"  x) 


let WriteAllocTransType (strm:Stream) (xxIn:AllocTransType) =
    match xxIn with
    | AllocTransType.New -> strm.Write "71=0"B; strm.Write (delim, 0, 1)
    | AllocTransType.Replace -> strm.Write "71=1"B; strm.Write (delim, 0, 1)
    | AllocTransType.Cancel -> strm.Write "71=2"B; strm.Write (delim, 0, 1)


let ReadRefAllocID valIn =
    let tmp =  valIn
    RefAllocID.RefAllocID tmp


let WriteRefAllocID (strm:Stream) (valIn:RefAllocID) = 
    let tag = "72="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoOrders valIn =
    let tmp = System.Int32.Parse valIn
    NoOrders.NoOrders tmp


let WriteNoOrders (strm:Stream) (valIn:NoOrders) = 
    let tag = "73="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAvgPxPrecision valIn =
    let tmp = System.Int32.Parse valIn
    AvgPxPrecision.AvgPxPrecision tmp


let WriteAvgPxPrecision (strm:Stream) (valIn:AvgPxPrecision) = 
    let tag = "74="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradeDate valIn =
    let tmp =  valIn
    TradeDate.TradeDate tmp


let WriteTradeDate (strm:Stream) (valIn:TradeDate) = 
    let tag = "75="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPositionEffect (fldValIn:string) : PositionEffect = 
    match fldValIn with
    |"O" -> PositionEffect.Open
    |"C" -> PositionEffect.Close
    |"R" -> PositionEffect.Rolled
    |"F" -> PositionEffect.Fifo
    | x -> failwith (sprintf "ReadPositionEffect unknown fix tag: %A"  x) 


let WritePositionEffect (strm:Stream) (xxIn:PositionEffect) =
    match xxIn with
    | PositionEffect.Open -> strm.Write "77=O"B; strm.Write (delim, 0, 1)
    | PositionEffect.Close -> strm.Write "77=C"B; strm.Write (delim, 0, 1)
    | PositionEffect.Rolled -> strm.Write "77=R"B; strm.Write (delim, 0, 1)
    | PositionEffect.Fifo -> strm.Write "77=F"B; strm.Write (delim, 0, 1)


let ReadNoAllocs valIn =
    let tmp = System.Int32.Parse valIn
    NoAllocs.NoAllocs tmp


let WriteNoAllocs (strm:Stream) (valIn:NoAllocs) = 
    let tag = "78="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocAccount valIn =
    let tmp =  valIn
    AllocAccount.AllocAccount tmp


let WriteAllocAccount (strm:Stream) (valIn:AllocAccount) = 
    let tag = "79="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocQty valIn =
    let tmp = System.Decimal.Parse valIn
    AllocQty.AllocQty tmp


let WriteAllocQty (strm:Stream) (valIn:AllocQty) = 
    let tag = "80="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadProcessCode (fldValIn:string) : ProcessCode = 
    match fldValIn with
    |"0" -> ProcessCode.Regular
    |"1" -> ProcessCode.SoftDollar
    |"2" -> ProcessCode.StepIn
    |"3" -> ProcessCode.StepOut
    |"4" -> ProcessCode.SoftDollarStepIn
    |"5" -> ProcessCode.SoftDollarStepOut
    |"6" -> ProcessCode.PlanSponsor
    | x -> failwith (sprintf "ReadProcessCode unknown fix tag: %A"  x) 


let WriteProcessCode (strm:Stream) (xxIn:ProcessCode) =
    match xxIn with
    | ProcessCode.Regular -> strm.Write "81=0"B; strm.Write (delim, 0, 1)
    | ProcessCode.SoftDollar -> strm.Write "81=1"B; strm.Write (delim, 0, 1)
    | ProcessCode.StepIn -> strm.Write "81=2"B; strm.Write (delim, 0, 1)
    | ProcessCode.StepOut -> strm.Write "81=3"B; strm.Write (delim, 0, 1)
    | ProcessCode.SoftDollarStepIn -> strm.Write "81=4"B; strm.Write (delim, 0, 1)
    | ProcessCode.SoftDollarStepOut -> strm.Write "81=5"B; strm.Write (delim, 0, 1)
    | ProcessCode.PlanSponsor -> strm.Write "81=6"B; strm.Write (delim, 0, 1)


let ReadNoRpts valIn =
    let tmp = System.Int32.Parse valIn
    NoRpts.NoRpts tmp


let WriteNoRpts (strm:Stream) (valIn:NoRpts) = 
    let tag = "82="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRptSeq valIn =
    let tmp = System.Int32.Parse valIn
    RptSeq.RptSeq tmp


let WriteRptSeq (strm:Stream) (valIn:RptSeq) = 
    let tag = "83="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCxlQty valIn =
    let tmp = System.Decimal.Parse valIn
    CxlQty.CxlQty tmp


let WriteCxlQty (strm:Stream) (valIn:CxlQty) = 
    let tag = "84="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoDlvyInst valIn =
    let tmp = System.Int32.Parse valIn
    NoDlvyInst.NoDlvyInst tmp


let WriteNoDlvyInst (strm:Stream) (valIn:NoDlvyInst) = 
    let tag = "85="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocStatus (fldValIn:string) : AllocStatus = 
    match fldValIn with
    |"0" -> AllocStatus.Accepted
    |"1" -> AllocStatus.BlockLevelReject
    |"2" -> AllocStatus.AccountLevelReject
    |"3" -> AllocStatus.Received
    |"4" -> AllocStatus.Incomplete
    |"5" -> AllocStatus.RejectedByIntermediary
    | x -> failwith (sprintf "ReadAllocStatus unknown fix tag: %A"  x) 


let WriteAllocStatus (strm:Stream) (xxIn:AllocStatus) =
    match xxIn with
    | AllocStatus.Accepted -> strm.Write "87=0"B; strm.Write (delim, 0, 1)
    | AllocStatus.BlockLevelReject -> strm.Write "87=1"B; strm.Write (delim, 0, 1)
    | AllocStatus.AccountLevelReject -> strm.Write "87=2"B; strm.Write (delim, 0, 1)
    | AllocStatus.Received -> strm.Write "87=3"B; strm.Write (delim, 0, 1)
    | AllocStatus.Incomplete -> strm.Write "87=4"B; strm.Write (delim, 0, 1)
    | AllocStatus.RejectedByIntermediary -> strm.Write "87=5"B; strm.Write (delim, 0, 1)


let ReadAllocRejCode (fldValIn:string) : AllocRejCode = 
    match fldValIn with
    |"0" -> AllocRejCode.UnknownAccount
    |"1" -> AllocRejCode.IncorrectQuantity
    |"2" -> AllocRejCode.IncorrectAveragePrice
    |"3" -> AllocRejCode.UnknownExecutingBrokerMnemonic
    |"4" -> AllocRejCode.CommissionDifference
    |"5" -> AllocRejCode.UnknownOrderid
    |"6" -> AllocRejCode.UnknownListid
    |"7" -> AllocRejCode.Other
    |"8" -> AllocRejCode.IncorrectAllocatedQuantity
    |"9" -> AllocRejCode.CalculationDifference
    |"10" -> AllocRejCode.UnknownOrStaleExecId
    |"11" -> AllocRejCode.MismatchedDataValue
    |"12" -> AllocRejCode.UnknownClordid
    |"13" -> AllocRejCode.WarehouseRequestRejected
    | x -> failwith (sprintf "ReadAllocRejCode unknown fix tag: %A"  x) 


let WriteAllocRejCode (strm:Stream) (xxIn:AllocRejCode) =
    match xxIn with
    | AllocRejCode.UnknownAccount -> strm.Write "88=0"B; strm.Write (delim, 0, 1)
    | AllocRejCode.IncorrectQuantity -> strm.Write "88=1"B; strm.Write (delim, 0, 1)
    | AllocRejCode.IncorrectAveragePrice -> strm.Write "88=2"B; strm.Write (delim, 0, 1)
    | AllocRejCode.UnknownExecutingBrokerMnemonic -> strm.Write "88=3"B; strm.Write (delim, 0, 1)
    | AllocRejCode.CommissionDifference -> strm.Write "88=4"B; strm.Write (delim, 0, 1)
    | AllocRejCode.UnknownOrderid -> strm.Write "88=5"B; strm.Write (delim, 0, 1)
    | AllocRejCode.UnknownListid -> strm.Write "88=6"B; strm.Write (delim, 0, 1)
    | AllocRejCode.Other -> strm.Write "88=7"B; strm.Write (delim, 0, 1)
    | AllocRejCode.IncorrectAllocatedQuantity -> strm.Write "88=8"B; strm.Write (delim, 0, 1)
    | AllocRejCode.CalculationDifference -> strm.Write "88=9"B; strm.Write (delim, 0, 1)
    | AllocRejCode.UnknownOrStaleExecId -> strm.Write "88=10"B; strm.Write (delim, 0, 1)
    | AllocRejCode.MismatchedDataValue -> strm.Write "88=11"B; strm.Write (delim, 0, 1)
    | AllocRejCode.UnknownClordid -> strm.Write "88=12"B; strm.Write (delim, 0, 1)
    | AllocRejCode.WarehouseRequestRejected -> strm.Write "88=13"B; strm.Write (delim, 0, 1)


let ReadSignature valIn =
    let tmp =  valIn
    Signature.Signature tmp


let WriteSignature (strm:Stream) (valIn:Signature) = 
    let tag = "89="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


// compound write
let WriteSecureData (strm:System.IO.Stream) (fld:SecureData) =
    let lenTag = "90="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "91="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadSecureData valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "91" then failwith "invalid tag reading SecureData"
    if strLen <> raw.Length then failwith "mismatched string len reading SecureData"
    SecureData.SecureData raw


let ReadSignatureLength valIn =
    let tmp = System.Int32.Parse valIn
    SignatureLength.SignatureLength tmp


let WriteSignatureLength (strm:Stream) (valIn:SignatureLength) = 
    let tag = "93="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadEmailType (fldValIn:string) : EmailType = 
    match fldValIn with
    |"0" -> EmailType.New
    |"1" -> EmailType.Reply
    |"2" -> EmailType.AdminReply
    | x -> failwith (sprintf "ReadEmailType unknown fix tag: %A"  x) 


let WriteEmailType (strm:Stream) (xxIn:EmailType) =
    match xxIn with
    | EmailType.New -> strm.Write "94=0"B; strm.Write (delim, 0, 1)
    | EmailType.Reply -> strm.Write "94=1"B; strm.Write (delim, 0, 1)
    | EmailType.AdminReply -> strm.Write "94=2"B; strm.Write (delim, 0, 1)


let ReadRawDataLength valIn =
    let tmp = System.Int32.Parse valIn
    RawDataLength.RawDataLength tmp


let WriteRawDataLength (strm:Stream) (valIn:RawDataLength) = 
    let tag = "95="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRawData valIn =
    let tmp =  valIn
    RawData.RawData tmp


let WriteRawData (strm:Stream) (valIn:RawData) = 
    let tag = "96="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPossResend valIn =
    let tmp = System.Boolean.Parse valIn
    PossResend.PossResend tmp


let WritePossResend (strm:Stream) (valIn:PossResend) = 
    let tag = "97="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadEncryptMethod (fldValIn:string) : EncryptMethod = 
    match fldValIn with
    |"0" -> EncryptMethod.NoneOther
    |"1" -> EncryptMethod.Pkcs
    |"2" -> EncryptMethod.Des
    |"3" -> EncryptMethod.PkcsDes
    |"4" -> EncryptMethod.PgpDes
    |"5" -> EncryptMethod.PgpDesMd5
    |"6" -> EncryptMethod.PemDesMd5
    | x -> failwith (sprintf "ReadEncryptMethod unknown fix tag: %A"  x) 


let WriteEncryptMethod (strm:Stream) (xxIn:EncryptMethod) =
    match xxIn with
    | EncryptMethod.NoneOther -> strm.Write "98=0"B; strm.Write (delim, 0, 1)
    | EncryptMethod.Pkcs -> strm.Write "98=1"B; strm.Write (delim, 0, 1)
    | EncryptMethod.Des -> strm.Write "98=2"B; strm.Write (delim, 0, 1)
    | EncryptMethod.PkcsDes -> strm.Write "98=3"B; strm.Write (delim, 0, 1)
    | EncryptMethod.PgpDes -> strm.Write "98=4"B; strm.Write (delim, 0, 1)
    | EncryptMethod.PgpDesMd5 -> strm.Write "98=5"B; strm.Write (delim, 0, 1)
    | EncryptMethod.PemDesMd5 -> strm.Write "98=6"B; strm.Write (delim, 0, 1)


let ReadStopPx valIn =
    let tmp = System.Decimal.Parse valIn
    StopPx.StopPx tmp


let WriteStopPx (strm:Stream) (valIn:StopPx) = 
    let tag = "99="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadExDestination valIn =
    let tmp =  valIn
    ExDestination.ExDestination tmp


let WriteExDestination (strm:Stream) (valIn:ExDestination) = 
    let tag = "100="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCxlRejReason (fldValIn:string) : CxlRejReason = 
    match fldValIn with
    |"0" -> CxlRejReason.TooLateToCancel
    |"1" -> CxlRejReason.UnknownOrder
    |"2" -> CxlRejReason.BrokerExchangeOption
    |"3" -> CxlRejReason.OrderAlreadyInPendingCancelOrPendingReplaceStatus
    |"4" -> CxlRejReason.UnableToProcessOrderMassCancelRequest
    |"5" -> CxlRejReason.OrigordmodtimeDidNotMatchLastTransacttimeOfOrder
    |"6" -> CxlRejReason.DuplicateClordidReceived
    |"99" -> CxlRejReason.Other
    | x -> failwith (sprintf "ReadCxlRejReason unknown fix tag: %A"  x) 


let WriteCxlRejReason (strm:Stream) (xxIn:CxlRejReason) =
    match xxIn with
    | CxlRejReason.TooLateToCancel -> strm.Write "102=0"B; strm.Write (delim, 0, 1)
    | CxlRejReason.UnknownOrder -> strm.Write "102=1"B; strm.Write (delim, 0, 1)
    | CxlRejReason.BrokerExchangeOption -> strm.Write "102=2"B; strm.Write (delim, 0, 1)
    | CxlRejReason.OrderAlreadyInPendingCancelOrPendingReplaceStatus -> strm.Write "102=3"B; strm.Write (delim, 0, 1)
    | CxlRejReason.UnableToProcessOrderMassCancelRequest -> strm.Write "102=4"B; strm.Write (delim, 0, 1)
    | CxlRejReason.OrigordmodtimeDidNotMatchLastTransacttimeOfOrder -> strm.Write "102=5"B; strm.Write (delim, 0, 1)
    | CxlRejReason.DuplicateClordidReceived -> strm.Write "102=6"B; strm.Write (delim, 0, 1)
    | CxlRejReason.Other -> strm.Write "102=99"B; strm.Write (delim, 0, 1)


let ReadOrdRejReason (fldValIn:string) : OrdRejReason = 
    match fldValIn with
    |"0" -> OrdRejReason.BrokerExchangeOption
    |"1" -> OrdRejReason.UnknownSymbol
    |"2" -> OrdRejReason.ExchangeClosed
    |"3" -> OrdRejReason.OrderExceedsLimit
    |"4" -> OrdRejReason.TooLateToEnter
    |"5" -> OrdRejReason.UnknownOrder
    |"6" -> OrdRejReason.DuplicateOrder
    |"7" -> OrdRejReason.DuplicateOfAVerballyCommunicatedOrder
    |"8" -> OrdRejReason.StaleOrder
    |"9" -> OrdRejReason.TradeAlongRequired
    |"10" -> OrdRejReason.InvalidInvestorId
    |"11" -> OrdRejReason.UnsupportedOrderCharacteristic
    |"12" -> OrdRejReason.SurveillenceOption
    |"13" -> OrdRejReason.IncorrectQuantity
    |"14" -> OrdRejReason.IncorrectAllocatedQuantity
    |"15" -> OrdRejReason.UnknownAccount
    |"99" -> OrdRejReason.Other
    | x -> failwith (sprintf "ReadOrdRejReason unknown fix tag: %A"  x) 


let WriteOrdRejReason (strm:Stream) (xxIn:OrdRejReason) =
    match xxIn with
    | OrdRejReason.BrokerExchangeOption -> strm.Write "103=0"B; strm.Write (delim, 0, 1)
    | OrdRejReason.UnknownSymbol -> strm.Write "103=1"B; strm.Write (delim, 0, 1)
    | OrdRejReason.ExchangeClosed -> strm.Write "103=2"B; strm.Write (delim, 0, 1)
    | OrdRejReason.OrderExceedsLimit -> strm.Write "103=3"B; strm.Write (delim, 0, 1)
    | OrdRejReason.TooLateToEnter -> strm.Write "103=4"B; strm.Write (delim, 0, 1)
    | OrdRejReason.UnknownOrder -> strm.Write "103=5"B; strm.Write (delim, 0, 1)
    | OrdRejReason.DuplicateOrder -> strm.Write "103=6"B; strm.Write (delim, 0, 1)
    | OrdRejReason.DuplicateOfAVerballyCommunicatedOrder -> strm.Write "103=7"B; strm.Write (delim, 0, 1)
    | OrdRejReason.StaleOrder -> strm.Write "103=8"B; strm.Write (delim, 0, 1)
    | OrdRejReason.TradeAlongRequired -> strm.Write "103=9"B; strm.Write (delim, 0, 1)
    | OrdRejReason.InvalidInvestorId -> strm.Write "103=10"B; strm.Write (delim, 0, 1)
    | OrdRejReason.UnsupportedOrderCharacteristic -> strm.Write "103=11"B; strm.Write (delim, 0, 1)
    | OrdRejReason.SurveillenceOption -> strm.Write "103=12"B; strm.Write (delim, 0, 1)
    | OrdRejReason.IncorrectQuantity -> strm.Write "103=13"B; strm.Write (delim, 0, 1)
    | OrdRejReason.IncorrectAllocatedQuantity -> strm.Write "103=14"B; strm.Write (delim, 0, 1)
    | OrdRejReason.UnknownAccount -> strm.Write "103=15"B; strm.Write (delim, 0, 1)
    | OrdRejReason.Other -> strm.Write "103=99"B; strm.Write (delim, 0, 1)


let ReadIOIQualifier (fldValIn:string) : IOIQualifier = 
    match fldValIn with
    |"A" -> IOIQualifier.AllOrNone
    |"B" -> IOIQualifier.MarketOnClose
    |"C" -> IOIQualifier.AtTheClose
    |"D" -> IOIQualifier.Vwap
    |"I" -> IOIQualifier.InTouchWith
    |"L" -> IOIQualifier.Limit
    |"M" -> IOIQualifier.MoreBehind
    |"O" -> IOIQualifier.AtTheOpen
    |"P" -> IOIQualifier.TakingAPosition
    |"Q" -> IOIQualifier.AtTheMarket
    |"R" -> IOIQualifier.ReadyToTrade
    |"S" -> IOIQualifier.PortfolioShown
    |"T" -> IOIQualifier.ThroughTheDay
    |"V" -> IOIQualifier.Versus
    |"W" -> IOIQualifier.IndicationWorkingAway
    |"X" -> IOIQualifier.CrossingOpportunity
    |"Y" -> IOIQualifier.AtTheMidpoint
    |"Z" -> IOIQualifier.PreOpen
    | x -> failwith (sprintf "ReadIOIQualifier unknown fix tag: %A"  x) 


let WriteIOIQualifier (strm:Stream) (xxIn:IOIQualifier) =
    match xxIn with
    | IOIQualifier.AllOrNone -> strm.Write "104=A"B; strm.Write (delim, 0, 1)
    | IOIQualifier.MarketOnClose -> strm.Write "104=B"B; strm.Write (delim, 0, 1)
    | IOIQualifier.AtTheClose -> strm.Write "104=C"B; strm.Write (delim, 0, 1)
    | IOIQualifier.Vwap -> strm.Write "104=D"B; strm.Write (delim, 0, 1)
    | IOIQualifier.InTouchWith -> strm.Write "104=I"B; strm.Write (delim, 0, 1)
    | IOIQualifier.Limit -> strm.Write "104=L"B; strm.Write (delim, 0, 1)
    | IOIQualifier.MoreBehind -> strm.Write "104=M"B; strm.Write (delim, 0, 1)
    | IOIQualifier.AtTheOpen -> strm.Write "104=O"B; strm.Write (delim, 0, 1)
    | IOIQualifier.TakingAPosition -> strm.Write "104=P"B; strm.Write (delim, 0, 1)
    | IOIQualifier.AtTheMarket -> strm.Write "104=Q"B; strm.Write (delim, 0, 1)
    | IOIQualifier.ReadyToTrade -> strm.Write "104=R"B; strm.Write (delim, 0, 1)
    | IOIQualifier.PortfolioShown -> strm.Write "104=S"B; strm.Write (delim, 0, 1)
    | IOIQualifier.ThroughTheDay -> strm.Write "104=T"B; strm.Write (delim, 0, 1)
    | IOIQualifier.Versus -> strm.Write "104=V"B; strm.Write (delim, 0, 1)
    | IOIQualifier.IndicationWorkingAway -> strm.Write "104=W"B; strm.Write (delim, 0, 1)
    | IOIQualifier.CrossingOpportunity -> strm.Write "104=X"B; strm.Write (delim, 0, 1)
    | IOIQualifier.AtTheMidpoint -> strm.Write "104=Y"B; strm.Write (delim, 0, 1)
    | IOIQualifier.PreOpen -> strm.Write "104=Z"B; strm.Write (delim, 0, 1)


let ReadWaveNo valIn =
    let tmp =  valIn
    WaveNo.WaveNo tmp


let WriteWaveNo (strm:Stream) (valIn:WaveNo) = 
    let tag = "105="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadIssuer valIn =
    let tmp =  valIn
    Issuer.Issuer tmp


let WriteIssuer (strm:Stream) (valIn:Issuer) = 
    let tag = "106="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecurityDesc valIn =
    let tmp =  valIn
    SecurityDesc.SecurityDesc tmp


let WriteSecurityDesc (strm:Stream) (valIn:SecurityDesc) = 
    let tag = "107="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadHeartBtInt valIn =
    let tmp = System.Int32.Parse valIn
    HeartBtInt.HeartBtInt tmp


let WriteHeartBtInt (strm:Stream) (valIn:HeartBtInt) = 
    let tag = "108="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMinQty valIn =
    let tmp = System.Decimal.Parse valIn
    MinQty.MinQty tmp


let WriteMinQty (strm:Stream) (valIn:MinQty) = 
    let tag = "110="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMaxFloor valIn =
    let tmp = System.Decimal.Parse valIn
    MaxFloor.MaxFloor tmp


let WriteMaxFloor (strm:Stream) (valIn:MaxFloor) = 
    let tag = "111="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTestReqID valIn =
    let tmp =  valIn
    TestReqID.TestReqID tmp


let WriteTestReqID (strm:Stream) (valIn:TestReqID) = 
    let tag = "112="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadReportToExch valIn =
    let tmp = System.Boolean.Parse valIn
    ReportToExch.ReportToExch tmp


let WriteReportToExch (strm:Stream) (valIn:ReportToExch) = 
    let tag = "113="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLocateReqd valIn =
    let tmp = System.Boolean.Parse valIn
    LocateReqd.LocateReqd tmp


let WriteLocateReqd (strm:Stream) (valIn:LocateReqd) = 
    let tag = "114="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOnBehalfOfCompID valIn =
    let tmp =  valIn
    OnBehalfOfCompID.OnBehalfOfCompID tmp


let WriteOnBehalfOfCompID (strm:Stream) (valIn:OnBehalfOfCompID) = 
    let tag = "115="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOnBehalfOfSubID valIn =
    let tmp =  valIn
    OnBehalfOfSubID.OnBehalfOfSubID tmp


let WriteOnBehalfOfSubID (strm:Stream) (valIn:OnBehalfOfSubID) = 
    let tag = "116="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuoteID valIn =
    let tmp =  valIn
    QuoteID.QuoteID tmp


let WriteQuoteID (strm:Stream) (valIn:QuoteID) = 
    let tag = "117="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNetMoney valIn =
    let tmp = System.Int32.Parse valIn
    NetMoney.NetMoney tmp


let WriteNetMoney (strm:Stream) (valIn:NetMoney) = 
    let tag = "118="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlCurrAmt valIn =
    let tmp = System.Int32.Parse valIn
    SettlCurrAmt.SettlCurrAmt tmp


let WriteSettlCurrAmt (strm:Stream) (valIn:SettlCurrAmt) = 
    let tag = "119="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlCurrency valIn =
    let tmp =  valIn
    SettlCurrency.SettlCurrency tmp


let WriteSettlCurrency (strm:Stream) (valIn:SettlCurrency) = 
    let tag = "120="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadForexReq valIn =
    let tmp = System.Boolean.Parse valIn
    ForexReq.ForexReq tmp


let WriteForexReq (strm:Stream) (valIn:ForexReq) = 
    let tag = "121="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOrigSendingTime valIn =
    let tmp =  valIn
    OrigSendingTime.OrigSendingTime tmp


let WriteOrigSendingTime (strm:Stream) (valIn:OrigSendingTime) = 
    let tag = "122="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadGapFillFlag valIn =
    let tmp = System.Boolean.Parse valIn
    GapFillFlag.GapFillFlag tmp


let WriteGapFillFlag (strm:Stream) (valIn:GapFillFlag) = 
    let tag = "123="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoExecs valIn =
    let tmp = System.Int32.Parse valIn
    NoExecs.NoExecs tmp


let WriteNoExecs (strm:Stream) (valIn:NoExecs) = 
    let tag = "124="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadExpireTime valIn =
    let tmp =  valIn
    ExpireTime.ExpireTime tmp


let WriteExpireTime (strm:Stream) (valIn:ExpireTime) = 
    let tag = "126="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDKReason (fldValIn:string) : DKReason = 
    match fldValIn with
    |"A" -> DKReason.UnknownSymbol
    |"B" -> DKReason.WrongSide
    |"C" -> DKReason.QuantityExceedsOrder
    |"D" -> DKReason.NoMatchingOrder
    |"E" -> DKReason.PriceExceedsLimit
    |"F" -> DKReason.CalculationDifference
    |"Z" -> DKReason.Other
    | x -> failwith (sprintf "ReadDKReason unknown fix tag: %A"  x) 


let WriteDKReason (strm:Stream) (xxIn:DKReason) =
    match xxIn with
    | DKReason.UnknownSymbol -> strm.Write "127=A"B; strm.Write (delim, 0, 1)
    | DKReason.WrongSide -> strm.Write "127=B"B; strm.Write (delim, 0, 1)
    | DKReason.QuantityExceedsOrder -> strm.Write "127=C"B; strm.Write (delim, 0, 1)
    | DKReason.NoMatchingOrder -> strm.Write "127=D"B; strm.Write (delim, 0, 1)
    | DKReason.PriceExceedsLimit -> strm.Write "127=E"B; strm.Write (delim, 0, 1)
    | DKReason.CalculationDifference -> strm.Write "127=F"B; strm.Write (delim, 0, 1)
    | DKReason.Other -> strm.Write "127=Z"B; strm.Write (delim, 0, 1)


let ReadDeliverToCompID valIn =
    let tmp =  valIn
    DeliverToCompID.DeliverToCompID tmp


let WriteDeliverToCompID (strm:Stream) (valIn:DeliverToCompID) = 
    let tag = "128="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDeliverToSubID valIn =
    let tmp =  valIn
    DeliverToSubID.DeliverToSubID tmp


let WriteDeliverToSubID (strm:Stream) (valIn:DeliverToSubID) = 
    let tag = "129="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadIOINaturalFlag valIn =
    let tmp = System.Boolean.Parse valIn
    IOINaturalFlag.IOINaturalFlag tmp


let WriteIOINaturalFlag (strm:Stream) (valIn:IOINaturalFlag) = 
    let tag = "130="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuoteReqID valIn =
    let tmp =  valIn
    QuoteReqID.QuoteReqID tmp


let WriteQuoteReqID (strm:Stream) (valIn:QuoteReqID) = 
    let tag = "131="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBidPx valIn =
    let tmp = System.Decimal.Parse valIn
    BidPx.BidPx tmp


let WriteBidPx (strm:Stream) (valIn:BidPx) = 
    let tag = "132="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOfferPx valIn =
    let tmp = System.Decimal.Parse valIn
    OfferPx.OfferPx tmp


let WriteOfferPx (strm:Stream) (valIn:OfferPx) = 
    let tag = "133="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBidSize valIn =
    let tmp = System.Decimal.Parse valIn
    BidSize.BidSize tmp


let WriteBidSize (strm:Stream) (valIn:BidSize) = 
    let tag = "134="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOfferSize valIn =
    let tmp = System.Decimal.Parse valIn
    OfferSize.OfferSize tmp


let WriteOfferSize (strm:Stream) (valIn:OfferSize) = 
    let tag = "135="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoMiscFees valIn =
    let tmp = System.Int32.Parse valIn
    NoMiscFees.NoMiscFees tmp


let WriteNoMiscFees (strm:Stream) (valIn:NoMiscFees) = 
    let tag = "136="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMiscFeeAmt valIn =
    let tmp = System.Int32.Parse valIn
    MiscFeeAmt.MiscFeeAmt tmp


let WriteMiscFeeAmt (strm:Stream) (valIn:MiscFeeAmt) = 
    let tag = "137="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMiscFeeCurr valIn =
    let tmp =  valIn
    MiscFeeCurr.MiscFeeCurr tmp


let WriteMiscFeeCurr (strm:Stream) (valIn:MiscFeeCurr) = 
    let tag = "138="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMiscFeeType (fldValIn:string) : MiscFeeType = 
    match fldValIn with
    |"1" -> MiscFeeType.Regulatory
    |"2" -> MiscFeeType.Tax
    |"3" -> MiscFeeType.LocalCommission
    |"4" -> MiscFeeType.ExchangeFees
    |"5" -> MiscFeeType.Stamp
    |"6" -> MiscFeeType.Levy
    |"7" -> MiscFeeType.Other
    |"8" -> MiscFeeType.Markup
    |"9" -> MiscFeeType.ConsumptionTax
    |"10" -> MiscFeeType.PerTransaction
    |"11" -> MiscFeeType.Conversion
    |"12" -> MiscFeeType.Agent
    | x -> failwith (sprintf "ReadMiscFeeType unknown fix tag: %A"  x) 


let WriteMiscFeeType (strm:Stream) (xxIn:MiscFeeType) =
    match xxIn with
    | MiscFeeType.Regulatory -> strm.Write "139=1"B; strm.Write (delim, 0, 1)
    | MiscFeeType.Tax -> strm.Write "139=2"B; strm.Write (delim, 0, 1)
    | MiscFeeType.LocalCommission -> strm.Write "139=3"B; strm.Write (delim, 0, 1)
    | MiscFeeType.ExchangeFees -> strm.Write "139=4"B; strm.Write (delim, 0, 1)
    | MiscFeeType.Stamp -> strm.Write "139=5"B; strm.Write (delim, 0, 1)
    | MiscFeeType.Levy -> strm.Write "139=6"B; strm.Write (delim, 0, 1)
    | MiscFeeType.Other -> strm.Write "139=7"B; strm.Write (delim, 0, 1)
    | MiscFeeType.Markup -> strm.Write "139=8"B; strm.Write (delim, 0, 1)
    | MiscFeeType.ConsumptionTax -> strm.Write "139=9"B; strm.Write (delim, 0, 1)
    | MiscFeeType.PerTransaction -> strm.Write "139=10"B; strm.Write (delim, 0, 1)
    | MiscFeeType.Conversion -> strm.Write "139=11"B; strm.Write (delim, 0, 1)
    | MiscFeeType.Agent -> strm.Write "139=12"B; strm.Write (delim, 0, 1)


let ReadPrevClosePx valIn =
    let tmp = System.Decimal.Parse valIn
    PrevClosePx.PrevClosePx tmp


let WritePrevClosePx (strm:Stream) (valIn:PrevClosePx) = 
    let tag = "140="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadResetSeqNumFlag valIn =
    let tmp = System.Boolean.Parse valIn
    ResetSeqNumFlag.ResetSeqNumFlag tmp


let WriteResetSeqNumFlag (strm:Stream) (valIn:ResetSeqNumFlag) = 
    let tag = "141="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSenderLocationID valIn =
    let tmp =  valIn
    SenderLocationID.SenderLocationID tmp


let WriteSenderLocationID (strm:Stream) (valIn:SenderLocationID) = 
    let tag = "142="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTargetLocationID valIn =
    let tmp =  valIn
    TargetLocationID.TargetLocationID tmp


let WriteTargetLocationID (strm:Stream) (valIn:TargetLocationID) = 
    let tag = "143="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOnBehalfOfLocationID valIn =
    let tmp =  valIn
    OnBehalfOfLocationID.OnBehalfOfLocationID tmp


let WriteOnBehalfOfLocationID (strm:Stream) (valIn:OnBehalfOfLocationID) = 
    let tag = "144="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDeliverToLocationID valIn =
    let tmp =  valIn
    DeliverToLocationID.DeliverToLocationID tmp


let WriteDeliverToLocationID (strm:Stream) (valIn:DeliverToLocationID) = 
    let tag = "145="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoRelatedSym valIn =
    let tmp = System.Int32.Parse valIn
    NoRelatedSym.NoRelatedSym tmp


let WriteNoRelatedSym (strm:Stream) (valIn:NoRelatedSym) = 
    let tag = "146="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSubject valIn =
    let tmp =  valIn
    Subject.Subject tmp


let WriteSubject (strm:Stream) (valIn:Subject) = 
    let tag = "147="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadHeadline valIn =
    let tmp =  valIn
    Headline.Headline tmp


let WriteHeadline (strm:Stream) (valIn:Headline) = 
    let tag = "148="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadURLLink valIn =
    let tmp =  valIn
    URLLink.URLLink tmp


let WriteURLLink (strm:Stream) (valIn:URLLink) = 
    let tag = "149="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadExecType (fldValIn:string) : ExecType = 
    match fldValIn with
    |"0" -> ExecType.New
    |"1" -> ExecType.PartialFill
    |"2" -> ExecType.Fill
    |"3" -> ExecType.DoneForDay
    |"4" -> ExecType.Canceled
    |"5" -> ExecType.Replace
    |"6" -> ExecType.PendingCancel
    |"7" -> ExecType.Stopped
    |"8" -> ExecType.Rejected
    |"9" -> ExecType.Suspended
    |"A" -> ExecType.PendingNew
    |"B" -> ExecType.Calculated
    |"C" -> ExecType.Expired
    |"D" -> ExecType.Restated
    |"E" -> ExecType.PendingReplace
    |"F" -> ExecType.Trade
    |"G" -> ExecType.TradeCorrect
    |"H" -> ExecType.TradeCancel
    |"I" -> ExecType.OrderStatus
    | x -> failwith (sprintf "ReadExecType unknown fix tag: %A"  x) 


let WriteExecType (strm:Stream) (xxIn:ExecType) =
    match xxIn with
    | ExecType.New -> strm.Write "150=0"B; strm.Write (delim, 0, 1)
    | ExecType.PartialFill -> strm.Write "150=1"B; strm.Write (delim, 0, 1)
    | ExecType.Fill -> strm.Write "150=2"B; strm.Write (delim, 0, 1)
    | ExecType.DoneForDay -> strm.Write "150=3"B; strm.Write (delim, 0, 1)
    | ExecType.Canceled -> strm.Write "150=4"B; strm.Write (delim, 0, 1)
    | ExecType.Replace -> strm.Write "150=5"B; strm.Write (delim, 0, 1)
    | ExecType.PendingCancel -> strm.Write "150=6"B; strm.Write (delim, 0, 1)
    | ExecType.Stopped -> strm.Write "150=7"B; strm.Write (delim, 0, 1)
    | ExecType.Rejected -> strm.Write "150=8"B; strm.Write (delim, 0, 1)
    | ExecType.Suspended -> strm.Write "150=9"B; strm.Write (delim, 0, 1)
    | ExecType.PendingNew -> strm.Write "150=A"B; strm.Write (delim, 0, 1)
    | ExecType.Calculated -> strm.Write "150=B"B; strm.Write (delim, 0, 1)
    | ExecType.Expired -> strm.Write "150=C"B; strm.Write (delim, 0, 1)
    | ExecType.Restated -> strm.Write "150=D"B; strm.Write (delim, 0, 1)
    | ExecType.PendingReplace -> strm.Write "150=E"B; strm.Write (delim, 0, 1)
    | ExecType.Trade -> strm.Write "150=F"B; strm.Write (delim, 0, 1)
    | ExecType.TradeCorrect -> strm.Write "150=G"B; strm.Write (delim, 0, 1)
    | ExecType.TradeCancel -> strm.Write "150=H"B; strm.Write (delim, 0, 1)
    | ExecType.OrderStatus -> strm.Write "150=I"B; strm.Write (delim, 0, 1)


let ReadLeavesQty valIn =
    let tmp = System.Decimal.Parse valIn
    LeavesQty.LeavesQty tmp


let WriteLeavesQty (strm:Stream) (valIn:LeavesQty) = 
    let tag = "151="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCashOrderQty valIn =
    let tmp = System.Decimal.Parse valIn
    CashOrderQty.CashOrderQty tmp


let WriteCashOrderQty (strm:Stream) (valIn:CashOrderQty) = 
    let tag = "152="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocAvgPx valIn =
    let tmp = System.Decimal.Parse valIn
    AllocAvgPx.AllocAvgPx tmp


let WriteAllocAvgPx (strm:Stream) (valIn:AllocAvgPx) = 
    let tag = "153="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocNetMoney valIn =
    let tmp = System.Int32.Parse valIn
    AllocNetMoney.AllocNetMoney tmp


let WriteAllocNetMoney (strm:Stream) (valIn:AllocNetMoney) = 
    let tag = "154="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlCurrFxRate valIn =
    let tmp = System.Decimal.Parse valIn
    SettlCurrFxRate.SettlCurrFxRate tmp


let WriteSettlCurrFxRate (strm:Stream) (valIn:SettlCurrFxRate) = 
    let tag = "155="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlCurrFxRateCalc (fldValIn:string) : SettlCurrFxRateCalc = 
    match fldValIn with
    |"M" -> SettlCurrFxRateCalc.Multiply
    |"D" -> SettlCurrFxRateCalc.Divide
    | x -> failwith (sprintf "ReadSettlCurrFxRateCalc unknown fix tag: %A"  x) 


let WriteSettlCurrFxRateCalc (strm:Stream) (xxIn:SettlCurrFxRateCalc) =
    match xxIn with
    | SettlCurrFxRateCalc.Multiply -> strm.Write "156=M"B; strm.Write (delim, 0, 1)
    | SettlCurrFxRateCalc.Divide -> strm.Write "156=D"B; strm.Write (delim, 0, 1)


let ReadNumDaysInterest valIn =
    let tmp = System.Int32.Parse valIn
    NumDaysInterest.NumDaysInterest tmp


let WriteNumDaysInterest (strm:Stream) (valIn:NumDaysInterest) = 
    let tag = "157="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAccruedInterestRate valIn =
    let tmp = System.Decimal.Parse valIn
    AccruedInterestRate.AccruedInterestRate tmp


let WriteAccruedInterestRate (strm:Stream) (valIn:AccruedInterestRate) = 
    let tag = "158="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAccruedInterestAmt valIn =
    let tmp = System.Int32.Parse valIn
    AccruedInterestAmt.AccruedInterestAmt tmp


let WriteAccruedInterestAmt (strm:Stream) (valIn:AccruedInterestAmt) = 
    let tag = "159="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlInstMode (fldValIn:string) : SettlInstMode = 
    match fldValIn with
    |"0" -> SettlInstMode.Default
    |"1" -> SettlInstMode.StandingInstructionsProvided
    |"4" -> SettlInstMode.SpecificOrderForASingleAccount
    |"5" -> SettlInstMode.RequestReject
    | x -> failwith (sprintf "ReadSettlInstMode unknown fix tag: %A"  x) 


let WriteSettlInstMode (strm:Stream) (xxIn:SettlInstMode) =
    match xxIn with
    | SettlInstMode.Default -> strm.Write "160=0"B; strm.Write (delim, 0, 1)
    | SettlInstMode.StandingInstructionsProvided -> strm.Write "160=1"B; strm.Write (delim, 0, 1)
    | SettlInstMode.SpecificOrderForASingleAccount -> strm.Write "160=4"B; strm.Write (delim, 0, 1)
    | SettlInstMode.RequestReject -> strm.Write "160=5"B; strm.Write (delim, 0, 1)


let ReadAllocText valIn =
    let tmp =  valIn
    AllocText.AllocText tmp


let WriteAllocText (strm:Stream) (valIn:AllocText) = 
    let tag = "161="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlInstID valIn =
    let tmp =  valIn
    SettlInstID.SettlInstID tmp


let WriteSettlInstID (strm:Stream) (valIn:SettlInstID) = 
    let tag = "162="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlInstTransType (fldValIn:string) : SettlInstTransType = 
    match fldValIn with
    |"N" -> SettlInstTransType.New
    |"C" -> SettlInstTransType.Cancel
    |"R" -> SettlInstTransType.Replace
    |"T" -> SettlInstTransType.Restate
    | x -> failwith (sprintf "ReadSettlInstTransType unknown fix tag: %A"  x) 


let WriteSettlInstTransType (strm:Stream) (xxIn:SettlInstTransType) =
    match xxIn with
    | SettlInstTransType.New -> strm.Write "163=N"B; strm.Write (delim, 0, 1)
    | SettlInstTransType.Cancel -> strm.Write "163=C"B; strm.Write (delim, 0, 1)
    | SettlInstTransType.Replace -> strm.Write "163=R"B; strm.Write (delim, 0, 1)
    | SettlInstTransType.Restate -> strm.Write "163=T"B; strm.Write (delim, 0, 1)


let ReadEmailThreadID valIn =
    let tmp =  valIn
    EmailThreadID.EmailThreadID tmp


let WriteEmailThreadID (strm:Stream) (valIn:EmailThreadID) = 
    let tag = "164="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlInstSource (fldValIn:string) : SettlInstSource = 
    match fldValIn with
    |"1" -> SettlInstSource.BrokersInstructions
    |"2" -> SettlInstSource.InstitutionsInstructions
    |"3" -> SettlInstSource.Investor
    | x -> failwith (sprintf "ReadSettlInstSource unknown fix tag: %A"  x) 


let WriteSettlInstSource (strm:Stream) (xxIn:SettlInstSource) =
    match xxIn with
    | SettlInstSource.BrokersInstructions -> strm.Write "165=1"B; strm.Write (delim, 0, 1)
    | SettlInstSource.InstitutionsInstructions -> strm.Write "165=2"B; strm.Write (delim, 0, 1)
    | SettlInstSource.Investor -> strm.Write "165=3"B; strm.Write (delim, 0, 1)


let ReadSecurityType (fldValIn:string) : SecurityType = 
    match fldValIn with
    |"EUSUPRA" -> SecurityType.EuroSupranationalCoupons
    |"FAC" -> SecurityType.FederalAgencyCoupon
    |"FADN" -> SecurityType.FederalAgencyDiscountNote
    |"PEF" -> SecurityType.PrivateExportFunding
    |"SUPRA" -> SecurityType.UsdSupranationalCoupons
    |"FUT" -> SecurityType.Future
    |"OPT" -> SecurityType.Option
    |"CORP" -> SecurityType.CorporateBond
    |"CPP" -> SecurityType.CorporatePrivatePlacement
    |"CB" -> SecurityType.ConvertibleBond
    |"DUAL" -> SecurityType.DualCurrency
    |"EUCORP" -> SecurityType.EuroCorporateBond
    |"XLINKD" -> SecurityType.IndexedLinked
    |"STRUCT" -> SecurityType.StructuredNotes
    |"YANK" -> SecurityType.YankeeCorporateBond
    |"FOR" -> SecurityType.ForeignExchangeContract
    |"CS" -> SecurityType.CommonStock
    |"PS" -> SecurityType.PreferredStock
    |"BRADY" -> SecurityType.BradyBond
    |"EUSOV" -> SecurityType.EuroSovereigns
    |"TBOND" -> SecurityType.UsTreasuryBond
    |"TINT" -> SecurityType.InterestStripFromAnyBondOrNote
    |"TIPS" -> SecurityType.TreasuryInflationProtectedSecurities
    |"TCAL" -> SecurityType.PrincipalStripOfACallableBondOrNote
    |"TPRN" -> SecurityType.PrincipalStripFromANonCallableBondOrNote
    |"TNOTE" -> SecurityType.UsTreasuryNote
    |"TBILL" -> SecurityType.UsTreasuryBill
    |"REPO" -> SecurityType.Repurchase
    |"FORWARD" -> SecurityType.Forward
    |"BUYSELL" -> SecurityType.BuySellback
    |"SECLOAN" -> SecurityType.SecuritiesLoan
    |"SECPLEDGE" -> SecurityType.SecuritiesPledge
    |"TERM" -> SecurityType.TermLoan
    |"RVLV" -> SecurityType.RevolverLoan
    |"RVLVTRM" -> SecurityType.RevolverTermLoan
    |"BRIDGE" -> SecurityType.BridgeLoan
    |"LOFC" -> SecurityType.LetterOfCredit
    |"SWING" -> SecurityType.SwingLineFacility
    |"DINP" -> SecurityType.DebtorInPossession
    |"DEFLTED" -> SecurityType.Defaulted
    |"WITHDRN" -> SecurityType.Withdrawn
    |"REPLACD" -> SecurityType.Replaced
    |"MATURED" -> SecurityType.Matured
    |"AMENDED" -> SecurityType.AmendedAndRestated
    |"RETIRED" -> SecurityType.Retired
    |"BA" -> SecurityType.BankersAcceptance
    |"BN" -> SecurityType.BankNotes
    |"BOX" -> SecurityType.BillOfExchanges
    |"CD" -> SecurityType.CertificateOfDeposit
    |"CL" -> SecurityType.CallLoans
    |"CP" -> SecurityType.CommercialPaper
    |"DN" -> SecurityType.DepositNotes
    |"EUCD" -> SecurityType.EuroCertificateOfDeposit
    |"EUCP" -> SecurityType.EuroCommercialPaper
    |"LQN" -> SecurityType.LiquidityNote
    |"MTN" -> SecurityType.MediumTermNotes
    |"ONITE" -> SecurityType.Overnight
    |"PN" -> SecurityType.PromissoryNote
    |"PZFJ" -> SecurityType.PlazosFijos
    |"STN" -> SecurityType.ShortTermLoanNote
    |"TD" -> SecurityType.TimeDeposit
    |"XCN" -> SecurityType.ExtendedCommNote
    |"YCD" -> SecurityType.YankeeCertificateOfDeposit
    |"ABS" -> SecurityType.AssetBackedSecurities
    |"CMBS" -> SecurityType.CorpMortgageBackedSecurities
    |"CMO" -> SecurityType.CollateralizedMortgageObligation
    |"IET" -> SecurityType.IoetteMortgage
    |"MBS" -> SecurityType.MortgageBackedSecurities
    |"MIO" -> SecurityType.MortgageInterestOnly
    |"MPO" -> SecurityType.MortgagePrincipalOnly
    |"MPP" -> SecurityType.MortgagePrivatePlacement
    |"MPT" -> SecurityType.MiscellaneousPassThrough
    |"PFAND" -> SecurityType.Pfandbriefe
    |"TBA" -> SecurityType.ToBeAnnounced
    |"AN" -> SecurityType.OtherAnticipationNotes
    |"COFO" -> SecurityType.CertificateOfObligation
    |"COFP" -> SecurityType.CertificateOfParticipation
    |"GO" -> SecurityType.GeneralObligationBonds
    |"MT" -> SecurityType.MandatoryTender
    |"RAN" -> SecurityType.RevenueAnticipationNote
    |"REV" -> SecurityType.RevenueBonds
    |"SPCLA" -> SecurityType.SpecialAssessment
    |"SPCLO" -> SecurityType.SpecialObligation
    |"SPCLT" -> SecurityType.SpecialTax
    |"TAN" -> SecurityType.TaxAnticipationNote
    |"TAXA" -> SecurityType.TaxAllocation
    |"TECP" -> SecurityType.TaxExemptCommercialPaper
    |"TRAN" -> SecurityType.TaxAndRevenueAnticipationNote
    |"VRDN" -> SecurityType.VariableRateDemandNote
    |"WAR" -> SecurityType.Warrant
    |"MF" -> SecurityType.MutualFund
    |"MLEG" -> SecurityType.MultiLegInstrument
    |"NONE" -> SecurityType.NoSecurityType
    |"?" -> SecurityType.Wildcard
    | x -> failwith (sprintf "ReadSecurityType unknown fix tag: %A"  x) 


let WriteSecurityType (strm:Stream) (xxIn:SecurityType) =
    match xxIn with
    | SecurityType.EuroSupranationalCoupons -> strm.Write "167=EUSUPRA"B; strm.Write (delim, 0, 1)
    | SecurityType.FederalAgencyCoupon -> strm.Write "167=FAC"B; strm.Write (delim, 0, 1)
    | SecurityType.FederalAgencyDiscountNote -> strm.Write "167=FADN"B; strm.Write (delim, 0, 1)
    | SecurityType.PrivateExportFunding -> strm.Write "167=PEF"B; strm.Write (delim, 0, 1)
    | SecurityType.UsdSupranationalCoupons -> strm.Write "167=SUPRA"B; strm.Write (delim, 0, 1)
    | SecurityType.Future -> strm.Write "167=FUT"B; strm.Write (delim, 0, 1)
    | SecurityType.Option -> strm.Write "167=OPT"B; strm.Write (delim, 0, 1)
    | SecurityType.CorporateBond -> strm.Write "167=CORP"B; strm.Write (delim, 0, 1)
    | SecurityType.CorporatePrivatePlacement -> strm.Write "167=CPP"B; strm.Write (delim, 0, 1)
    | SecurityType.ConvertibleBond -> strm.Write "167=CB"B; strm.Write (delim, 0, 1)
    | SecurityType.DualCurrency -> strm.Write "167=DUAL"B; strm.Write (delim, 0, 1)
    | SecurityType.EuroCorporateBond -> strm.Write "167=EUCORP"B; strm.Write (delim, 0, 1)
    | SecurityType.IndexedLinked -> strm.Write "167=XLINKD"B; strm.Write (delim, 0, 1)
    | SecurityType.StructuredNotes -> strm.Write "167=STRUCT"B; strm.Write (delim, 0, 1)
    | SecurityType.YankeeCorporateBond -> strm.Write "167=YANK"B; strm.Write (delim, 0, 1)
    | SecurityType.ForeignExchangeContract -> strm.Write "167=FOR"B; strm.Write (delim, 0, 1)
    | SecurityType.CommonStock -> strm.Write "167=CS"B; strm.Write (delim, 0, 1)
    | SecurityType.PreferredStock -> strm.Write "167=PS"B; strm.Write (delim, 0, 1)
    | SecurityType.BradyBond -> strm.Write "167=BRADY"B; strm.Write (delim, 0, 1)
    | SecurityType.EuroSovereigns -> strm.Write "167=EUSOV"B; strm.Write (delim, 0, 1)
    | SecurityType.UsTreasuryBond -> strm.Write "167=TBOND"B; strm.Write (delim, 0, 1)
    | SecurityType.InterestStripFromAnyBondOrNote -> strm.Write "167=TINT"B; strm.Write (delim, 0, 1)
    | SecurityType.TreasuryInflationProtectedSecurities -> strm.Write "167=TIPS"B; strm.Write (delim, 0, 1)
    | SecurityType.PrincipalStripOfACallableBondOrNote -> strm.Write "167=TCAL"B; strm.Write (delim, 0, 1)
    | SecurityType.PrincipalStripFromANonCallableBondOrNote -> strm.Write "167=TPRN"B; strm.Write (delim, 0, 1)
    | SecurityType.UsTreasuryNote -> strm.Write "167=TNOTE"B; strm.Write (delim, 0, 1)
    | SecurityType.UsTreasuryBill -> strm.Write "167=TBILL"B; strm.Write (delim, 0, 1)
    | SecurityType.Repurchase -> strm.Write "167=REPO"B; strm.Write (delim, 0, 1)
    | SecurityType.Forward -> strm.Write "167=FORWARD"B; strm.Write (delim, 0, 1)
    | SecurityType.BuySellback -> strm.Write "167=BUYSELL"B; strm.Write (delim, 0, 1)
    | SecurityType.SecuritiesLoan -> strm.Write "167=SECLOAN"B; strm.Write (delim, 0, 1)
    | SecurityType.SecuritiesPledge -> strm.Write "167=SECPLEDGE"B; strm.Write (delim, 0, 1)
    | SecurityType.TermLoan -> strm.Write "167=TERM"B; strm.Write (delim, 0, 1)
    | SecurityType.RevolverLoan -> strm.Write "167=RVLV"B; strm.Write (delim, 0, 1)
    | SecurityType.RevolverTermLoan -> strm.Write "167=RVLVTRM"B; strm.Write (delim, 0, 1)
    | SecurityType.BridgeLoan -> strm.Write "167=BRIDGE"B; strm.Write (delim, 0, 1)
    | SecurityType.LetterOfCredit -> strm.Write "167=LOFC"B; strm.Write (delim, 0, 1)
    | SecurityType.SwingLineFacility -> strm.Write "167=SWING"B; strm.Write (delim, 0, 1)
    | SecurityType.DebtorInPossession -> strm.Write "167=DINP"B; strm.Write (delim, 0, 1)
    | SecurityType.Defaulted -> strm.Write "167=DEFLTED"B; strm.Write (delim, 0, 1)
    | SecurityType.Withdrawn -> strm.Write "167=WITHDRN"B; strm.Write (delim, 0, 1)
    | SecurityType.Replaced -> strm.Write "167=REPLACD"B; strm.Write (delim, 0, 1)
    | SecurityType.Matured -> strm.Write "167=MATURED"B; strm.Write (delim, 0, 1)
    | SecurityType.AmendedAndRestated -> strm.Write "167=AMENDED"B; strm.Write (delim, 0, 1)
    | SecurityType.Retired -> strm.Write "167=RETIRED"B; strm.Write (delim, 0, 1)
    | SecurityType.BankersAcceptance -> strm.Write "167=BA"B; strm.Write (delim, 0, 1)
    | SecurityType.BankNotes -> strm.Write "167=BN"B; strm.Write (delim, 0, 1)
    | SecurityType.BillOfExchanges -> strm.Write "167=BOX"B; strm.Write (delim, 0, 1)
    | SecurityType.CertificateOfDeposit -> strm.Write "167=CD"B; strm.Write (delim, 0, 1)
    | SecurityType.CallLoans -> strm.Write "167=CL"B; strm.Write (delim, 0, 1)
    | SecurityType.CommercialPaper -> strm.Write "167=CP"B; strm.Write (delim, 0, 1)
    | SecurityType.DepositNotes -> strm.Write "167=DN"B; strm.Write (delim, 0, 1)
    | SecurityType.EuroCertificateOfDeposit -> strm.Write "167=EUCD"B; strm.Write (delim, 0, 1)
    | SecurityType.EuroCommercialPaper -> strm.Write "167=EUCP"B; strm.Write (delim, 0, 1)
    | SecurityType.LiquidityNote -> strm.Write "167=LQN"B; strm.Write (delim, 0, 1)
    | SecurityType.MediumTermNotes -> strm.Write "167=MTN"B; strm.Write (delim, 0, 1)
    | SecurityType.Overnight -> strm.Write "167=ONITE"B; strm.Write (delim, 0, 1)
    | SecurityType.PromissoryNote -> strm.Write "167=PN"B; strm.Write (delim, 0, 1)
    | SecurityType.PlazosFijos -> strm.Write "167=PZFJ"B; strm.Write (delim, 0, 1)
    | SecurityType.ShortTermLoanNote -> strm.Write "167=STN"B; strm.Write (delim, 0, 1)
    | SecurityType.TimeDeposit -> strm.Write "167=TD"B; strm.Write (delim, 0, 1)
    | SecurityType.ExtendedCommNote -> strm.Write "167=XCN"B; strm.Write (delim, 0, 1)
    | SecurityType.YankeeCertificateOfDeposit -> strm.Write "167=YCD"B; strm.Write (delim, 0, 1)
    | SecurityType.AssetBackedSecurities -> strm.Write "167=ABS"B; strm.Write (delim, 0, 1)
    | SecurityType.CorpMortgageBackedSecurities -> strm.Write "167=CMBS"B; strm.Write (delim, 0, 1)
    | SecurityType.CollateralizedMortgageObligation -> strm.Write "167=CMO"B; strm.Write (delim, 0, 1)
    | SecurityType.IoetteMortgage -> strm.Write "167=IET"B; strm.Write (delim, 0, 1)
    | SecurityType.MortgageBackedSecurities -> strm.Write "167=MBS"B; strm.Write (delim, 0, 1)
    | SecurityType.MortgageInterestOnly -> strm.Write "167=MIO"B; strm.Write (delim, 0, 1)
    | SecurityType.MortgagePrincipalOnly -> strm.Write "167=MPO"B; strm.Write (delim, 0, 1)
    | SecurityType.MortgagePrivatePlacement -> strm.Write "167=MPP"B; strm.Write (delim, 0, 1)
    | SecurityType.MiscellaneousPassThrough -> strm.Write "167=MPT"B; strm.Write (delim, 0, 1)
    | SecurityType.Pfandbriefe -> strm.Write "167=PFAND"B; strm.Write (delim, 0, 1)
    | SecurityType.ToBeAnnounced -> strm.Write "167=TBA"B; strm.Write (delim, 0, 1)
    | SecurityType.OtherAnticipationNotes -> strm.Write "167=AN"B; strm.Write (delim, 0, 1)
    | SecurityType.CertificateOfObligation -> strm.Write "167=COFO"B; strm.Write (delim, 0, 1)
    | SecurityType.CertificateOfParticipation -> strm.Write "167=COFP"B; strm.Write (delim, 0, 1)
    | SecurityType.GeneralObligationBonds -> strm.Write "167=GO"B; strm.Write (delim, 0, 1)
    | SecurityType.MandatoryTender -> strm.Write "167=MT"B; strm.Write (delim, 0, 1)
    | SecurityType.RevenueAnticipationNote -> strm.Write "167=RAN"B; strm.Write (delim, 0, 1)
    | SecurityType.RevenueBonds -> strm.Write "167=REV"B; strm.Write (delim, 0, 1)
    | SecurityType.SpecialAssessment -> strm.Write "167=SPCLA"B; strm.Write (delim, 0, 1)
    | SecurityType.SpecialObligation -> strm.Write "167=SPCLO"B; strm.Write (delim, 0, 1)
    | SecurityType.SpecialTax -> strm.Write "167=SPCLT"B; strm.Write (delim, 0, 1)
    | SecurityType.TaxAnticipationNote -> strm.Write "167=TAN"B; strm.Write (delim, 0, 1)
    | SecurityType.TaxAllocation -> strm.Write "167=TAXA"B; strm.Write (delim, 0, 1)
    | SecurityType.TaxExemptCommercialPaper -> strm.Write "167=TECP"B; strm.Write (delim, 0, 1)
    | SecurityType.TaxAndRevenueAnticipationNote -> strm.Write "167=TRAN"B; strm.Write (delim, 0, 1)
    | SecurityType.VariableRateDemandNote -> strm.Write "167=VRDN"B; strm.Write (delim, 0, 1)
    | SecurityType.Warrant -> strm.Write "167=WAR"B; strm.Write (delim, 0, 1)
    | SecurityType.MutualFund -> strm.Write "167=MF"B; strm.Write (delim, 0, 1)
    | SecurityType.MultiLegInstrument -> strm.Write "167=MLEG"B; strm.Write (delim, 0, 1)
    | SecurityType.NoSecurityType -> strm.Write "167=NONE"B; strm.Write (delim, 0, 1)
    | SecurityType.Wildcard -> strm.Write "167=?"B; strm.Write (delim, 0, 1)


let ReadEffectiveTime valIn =
    let tmp =  valIn
    EffectiveTime.EffectiveTime tmp


let WriteEffectiveTime (strm:Stream) (valIn:EffectiveTime) = 
    let tag = "168="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadStandInstDbType (fldValIn:string) : StandInstDbType = 
    match fldValIn with
    |"0" -> StandInstDbType.Other
    |"1" -> StandInstDbType.DtcSid
    |"2" -> StandInstDbType.ThomsonAlert
    |"3" -> StandInstDbType.AGlobalCustodian
    |"4" -> StandInstDbType.Accountnet
    | x -> failwith (sprintf "ReadStandInstDbType unknown fix tag: %A"  x) 


let WriteStandInstDbType (strm:Stream) (xxIn:StandInstDbType) =
    match xxIn with
    | StandInstDbType.Other -> strm.Write "169=0"B; strm.Write (delim, 0, 1)
    | StandInstDbType.DtcSid -> strm.Write "169=1"B; strm.Write (delim, 0, 1)
    | StandInstDbType.ThomsonAlert -> strm.Write "169=2"B; strm.Write (delim, 0, 1)
    | StandInstDbType.AGlobalCustodian -> strm.Write "169=3"B; strm.Write (delim, 0, 1)
    | StandInstDbType.Accountnet -> strm.Write "169=4"B; strm.Write (delim, 0, 1)


let ReadStandInstDbName valIn =
    let tmp =  valIn
    StandInstDbName.StandInstDbName tmp


let WriteStandInstDbName (strm:Stream) (valIn:StandInstDbName) = 
    let tag = "170="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadStandInstDbID valIn =
    let tmp =  valIn
    StandInstDbID.StandInstDbID tmp


let WriteStandInstDbID (strm:Stream) (valIn:StandInstDbID) = 
    let tag = "171="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlDeliveryType (fldValIn:string) : SettlDeliveryType = 
    match fldValIn with
    |"0" -> SettlDeliveryType.VersusPayment
    |"1" -> SettlDeliveryType.Free
    |"2" -> SettlDeliveryType.TriParty
    |"3" -> SettlDeliveryType.HoldInCustody
    | x -> failwith (sprintf "ReadSettlDeliveryType unknown fix tag: %A"  x) 


let WriteSettlDeliveryType (strm:Stream) (xxIn:SettlDeliveryType) =
    match xxIn with
    | SettlDeliveryType.VersusPayment -> strm.Write "172=0"B; strm.Write (delim, 0, 1)
    | SettlDeliveryType.Free -> strm.Write "172=1"B; strm.Write (delim, 0, 1)
    | SettlDeliveryType.TriParty -> strm.Write "172=2"B; strm.Write (delim, 0, 1)
    | SettlDeliveryType.HoldInCustody -> strm.Write "172=3"B; strm.Write (delim, 0, 1)


let ReadBidSpotRate valIn =
    let tmp = System.Decimal.Parse valIn
    BidSpotRate.BidSpotRate tmp


let WriteBidSpotRate (strm:Stream) (valIn:BidSpotRate) = 
    let tag = "188="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBidForwardPoints valIn =
    let tmp = System.Decimal.Parse valIn
    BidForwardPoints.BidForwardPoints tmp


let WriteBidForwardPoints (strm:Stream) (valIn:BidForwardPoints) = 
    let tag = "189="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOfferSpotRate valIn =
    let tmp = System.Decimal.Parse valIn
    OfferSpotRate.OfferSpotRate tmp


let WriteOfferSpotRate (strm:Stream) (valIn:OfferSpotRate) = 
    let tag = "190="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOfferForwardPoints valIn =
    let tmp = System.Decimal.Parse valIn
    OfferForwardPoints.OfferForwardPoints tmp


let WriteOfferForwardPoints (strm:Stream) (valIn:OfferForwardPoints) = 
    let tag = "191="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOrderQty2 valIn =
    let tmp = System.Decimal.Parse valIn
    OrderQty2.OrderQty2 tmp


let WriteOrderQty2 (strm:Stream) (valIn:OrderQty2) = 
    let tag = "192="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlDate2 valIn =
    let tmp =  valIn
    SettlDate2.SettlDate2 tmp


let WriteSettlDate2 (strm:Stream) (valIn:SettlDate2) = 
    let tag = "193="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLastSpotRate valIn =
    let tmp = System.Decimal.Parse valIn
    LastSpotRate.LastSpotRate tmp


let WriteLastSpotRate (strm:Stream) (valIn:LastSpotRate) = 
    let tag = "194="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLastForwardPoints valIn =
    let tmp = System.Decimal.Parse valIn
    LastForwardPoints.LastForwardPoints tmp


let WriteLastForwardPoints (strm:Stream) (valIn:LastForwardPoints) = 
    let tag = "195="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocLinkID valIn =
    let tmp =  valIn
    AllocLinkID.AllocLinkID tmp


let WriteAllocLinkID (strm:Stream) (valIn:AllocLinkID) = 
    let tag = "196="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocLinkType (fldValIn:string) : AllocLinkType = 
    match fldValIn with
    |"0" -> AllocLinkType.FXNetting
    |"1" -> AllocLinkType.FXSwap
    | x -> failwith (sprintf "ReadAllocLinkType unknown fix tag: %A"  x) 


let WriteAllocLinkType (strm:Stream) (xxIn:AllocLinkType) =
    match xxIn with
    | AllocLinkType.FXNetting -> strm.Write "197=0"B; strm.Write (delim, 0, 1)
    | AllocLinkType.FXSwap -> strm.Write "197=1"B; strm.Write (delim, 0, 1)


let ReadSecondaryOrderID valIn =
    let tmp =  valIn
    SecondaryOrderID.SecondaryOrderID tmp


let WriteSecondaryOrderID (strm:Stream) (valIn:SecondaryOrderID) = 
    let tag = "198="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoIOIQualifiers valIn =
    let tmp = System.Int32.Parse valIn
    NoIOIQualifiers.NoIOIQualifiers tmp


let WriteNoIOIQualifiers (strm:Stream) (valIn:NoIOIQualifiers) = 
    let tag = "199="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMaturityMonthYear valIn =
    let tmp =  valIn
    MaturityMonthYear.MaturityMonthYear tmp


let WriteMaturityMonthYear (strm:Stream) (valIn:MaturityMonthYear) = 
    let tag = "200="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPutOrCall (fldValIn:string) : PutOrCall = 
    match fldValIn with
    |"0" -> PutOrCall.Put
    |"1" -> PutOrCall.Call
    | x -> failwith (sprintf "ReadPutOrCall unknown fix tag: %A"  x) 


let WritePutOrCall (strm:Stream) (xxIn:PutOrCall) =
    match xxIn with
    | PutOrCall.Put -> strm.Write "201=0"B; strm.Write (delim, 0, 1)
    | PutOrCall.Call -> strm.Write "201=1"B; strm.Write (delim, 0, 1)


let ReadStrikePrice valIn =
    let tmp = System.Decimal.Parse valIn
    StrikePrice.StrikePrice tmp


let WriteStrikePrice (strm:Stream) (valIn:StrikePrice) = 
    let tag = "202="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCoveredOrUncovered (fldValIn:string) : CoveredOrUncovered = 
    match fldValIn with
    |"0" -> CoveredOrUncovered.Covered
    |"1" -> CoveredOrUncovered.Uncovered
    | x -> failwith (sprintf "ReadCoveredOrUncovered unknown fix tag: %A"  x) 


let WriteCoveredOrUncovered (strm:Stream) (xxIn:CoveredOrUncovered) =
    match xxIn with
    | CoveredOrUncovered.Covered -> strm.Write "203=0"B; strm.Write (delim, 0, 1)
    | CoveredOrUncovered.Uncovered -> strm.Write "203=1"B; strm.Write (delim, 0, 1)


let ReadOptAttribute valIn =
    let tmp = System.Int32.Parse valIn
    OptAttribute.OptAttribute tmp


let WriteOptAttribute (strm:Stream) (valIn:OptAttribute) = 
    let tag = "206="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecurityExchange valIn =
    let tmp =  valIn
    SecurityExchange.SecurityExchange tmp


let WriteSecurityExchange (strm:Stream) (valIn:SecurityExchange) = 
    let tag = "207="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNotifyBrokerOfCredit valIn =
    let tmp = System.Boolean.Parse valIn
    NotifyBrokerOfCredit.NotifyBrokerOfCredit tmp


let WriteNotifyBrokerOfCredit (strm:Stream) (valIn:NotifyBrokerOfCredit) = 
    let tag = "208="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocHandlInst (fldValIn:string) : AllocHandlInst = 
    match fldValIn with
    |"1" -> AllocHandlInst.Match
    |"2" -> AllocHandlInst.Forward
    |"3" -> AllocHandlInst.ForwardAndMatch
    | x -> failwith (sprintf "ReadAllocHandlInst unknown fix tag: %A"  x) 


let WriteAllocHandlInst (strm:Stream) (xxIn:AllocHandlInst) =
    match xxIn with
    | AllocHandlInst.Match -> strm.Write "209=1"B; strm.Write (delim, 0, 1)
    | AllocHandlInst.Forward -> strm.Write "209=2"B; strm.Write (delim, 0, 1)
    | AllocHandlInst.ForwardAndMatch -> strm.Write "209=3"B; strm.Write (delim, 0, 1)


let ReadMaxShow valIn =
    let tmp = System.Decimal.Parse valIn
    MaxShow.MaxShow tmp


let WriteMaxShow (strm:Stream) (valIn:MaxShow) = 
    let tag = "210="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPegOffsetValue valIn =
    let tmp = System.Decimal.Parse valIn
    PegOffsetValue.PegOffsetValue tmp


let WritePegOffsetValue (strm:Stream) (valIn:PegOffsetValue) = 
    let tag = "211="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


// compound write
let WriteXmlData (strm:System.IO.Stream) (fld:XmlData) =
    let lenTag = "212="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "213="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadXmlData valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "213" then failwith "invalid tag reading XmlData"
    if strLen <> raw.Length then failwith "mismatched string len reading XmlData"
    XmlData.XmlData raw


let ReadSettlInstRefID valIn =
    let tmp =  valIn
    SettlInstRefID.SettlInstRefID tmp


let WriteSettlInstRefID (strm:Stream) (valIn:SettlInstRefID) = 
    let tag = "214="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoRoutingIDs valIn =
    let tmp = System.Int32.Parse valIn
    NoRoutingIDs.NoRoutingIDs tmp


let WriteNoRoutingIDs (strm:Stream) (valIn:NoRoutingIDs) = 
    let tag = "215="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRoutingType (fldValIn:string) : RoutingType = 
    match fldValIn with
    |"1" -> RoutingType.TargetFirm
    |"2" -> RoutingType.TargetList
    |"3" -> RoutingType.BlockFirm
    |"4" -> RoutingType.BlockList
    | x -> failwith (sprintf "ReadRoutingType unknown fix tag: %A"  x) 


let WriteRoutingType (strm:Stream) (xxIn:RoutingType) =
    match xxIn with
    | RoutingType.TargetFirm -> strm.Write "216=1"B; strm.Write (delim, 0, 1)
    | RoutingType.TargetList -> strm.Write "216=2"B; strm.Write (delim, 0, 1)
    | RoutingType.BlockFirm -> strm.Write "216=3"B; strm.Write (delim, 0, 1)
    | RoutingType.BlockList -> strm.Write "216=4"B; strm.Write (delim, 0, 1)


let ReadRoutingID valIn =
    let tmp =  valIn
    RoutingID.RoutingID tmp


let WriteRoutingID (strm:Stream) (valIn:RoutingID) = 
    let tag = "217="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSpread valIn =
    let tmp = System.Decimal.Parse valIn
    Spread.Spread tmp


let WriteSpread (strm:Stream) (valIn:Spread) = 
    let tag = "218="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBenchmarkCurveCurrency valIn =
    let tmp =  valIn
    BenchmarkCurveCurrency.BenchmarkCurveCurrency tmp


let WriteBenchmarkCurveCurrency (strm:Stream) (valIn:BenchmarkCurveCurrency) = 
    let tag = "220="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBenchmarkCurveName (fldValIn:string) : BenchmarkCurveName = 
    match fldValIn with
    |"MuniAAA" -> BenchmarkCurveName.Muniaaa
    |"FutureSWAP" -> BenchmarkCurveName.Futureswap
    |"LIBID" -> BenchmarkCurveName.Libid
    |"LIBOR" -> BenchmarkCurveName.Libor
    |"OTHER" -> BenchmarkCurveName.Other
    |"SWAP" -> BenchmarkCurveName.Swap
    |"Treasury" -> BenchmarkCurveName.Treasury
    |"Euribor" -> BenchmarkCurveName.Euribor
    |"Pfandbriefe" -> BenchmarkCurveName.Pfandbriefe
    |"EONIA" -> BenchmarkCurveName.Eonia
    |"SONIA" -> BenchmarkCurveName.Sonia
    |"EUREPO" -> BenchmarkCurveName.Eurepo
    | x -> failwith (sprintf "ReadBenchmarkCurveName unknown fix tag: %A"  x) 


let WriteBenchmarkCurveName (strm:Stream) (xxIn:BenchmarkCurveName) =
    match xxIn with
    | BenchmarkCurveName.Muniaaa -> strm.Write "221=MuniAAA"B; strm.Write (delim, 0, 1)
    | BenchmarkCurveName.Futureswap -> strm.Write "221=FutureSWAP"B; strm.Write (delim, 0, 1)
    | BenchmarkCurveName.Libid -> strm.Write "221=LIBID"B; strm.Write (delim, 0, 1)
    | BenchmarkCurveName.Libor -> strm.Write "221=LIBOR"B; strm.Write (delim, 0, 1)
    | BenchmarkCurveName.Other -> strm.Write "221=OTHER"B; strm.Write (delim, 0, 1)
    | BenchmarkCurveName.Swap -> strm.Write "221=SWAP"B; strm.Write (delim, 0, 1)
    | BenchmarkCurveName.Treasury -> strm.Write "221=Treasury"B; strm.Write (delim, 0, 1)
    | BenchmarkCurveName.Euribor -> strm.Write "221=Euribor"B; strm.Write (delim, 0, 1)
    | BenchmarkCurveName.Pfandbriefe -> strm.Write "221=Pfandbriefe"B; strm.Write (delim, 0, 1)
    | BenchmarkCurveName.Eonia -> strm.Write "221=EONIA"B; strm.Write (delim, 0, 1)
    | BenchmarkCurveName.Sonia -> strm.Write "221=SONIA"B; strm.Write (delim, 0, 1)
    | BenchmarkCurveName.Eurepo -> strm.Write "221=EUREPO"B; strm.Write (delim, 0, 1)


let ReadBenchmarkCurvePoint valIn =
    let tmp =  valIn
    BenchmarkCurvePoint.BenchmarkCurvePoint tmp


let WriteBenchmarkCurvePoint (strm:Stream) (valIn:BenchmarkCurvePoint) = 
    let tag = "222="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCouponRate valIn =
    let tmp = System.Decimal.Parse valIn
    CouponRate.CouponRate tmp


let WriteCouponRate (strm:Stream) (valIn:CouponRate) = 
    let tag = "223="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCouponPaymentDate valIn =
    let tmp =  valIn
    CouponPaymentDate.CouponPaymentDate tmp


let WriteCouponPaymentDate (strm:Stream) (valIn:CouponPaymentDate) = 
    let tag = "224="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadIssueDate valIn =
    let tmp =  valIn
    IssueDate.IssueDate tmp


let WriteIssueDate (strm:Stream) (valIn:IssueDate) = 
    let tag = "225="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRepurchaseTerm valIn =
    let tmp = System.Int32.Parse valIn
    RepurchaseTerm.RepurchaseTerm tmp


let WriteRepurchaseTerm (strm:Stream) (valIn:RepurchaseTerm) = 
    let tag = "226="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRepurchaseRate valIn =
    let tmp = System.Decimal.Parse valIn
    RepurchaseRate.RepurchaseRate tmp


let WriteRepurchaseRate (strm:Stream) (valIn:RepurchaseRate) = 
    let tag = "227="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadFactor valIn =
    let tmp = System.Decimal.Parse valIn
    Factor.Factor tmp


let WriteFactor (strm:Stream) (valIn:Factor) = 
    let tag = "228="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradeOriginationDate valIn =
    let tmp =  valIn
    TradeOriginationDate.TradeOriginationDate tmp


let WriteTradeOriginationDate (strm:Stream) (valIn:TradeOriginationDate) = 
    let tag = "229="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadExDate valIn =
    let tmp =  valIn
    ExDate.ExDate tmp


let WriteExDate (strm:Stream) (valIn:ExDate) = 
    let tag = "230="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadContractMultiplier valIn =
    let tmp = System.Decimal.Parse valIn
    ContractMultiplier.ContractMultiplier tmp


let WriteContractMultiplier (strm:Stream) (valIn:ContractMultiplier) = 
    let tag = "231="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoStipulations valIn =
    let tmp = System.Int32.Parse valIn
    NoStipulations.NoStipulations tmp


let WriteNoStipulations (strm:Stream) (valIn:NoStipulations) = 
    let tag = "232="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadStipulationType (fldValIn:string) : StipulationType = 
    match fldValIn with
    |"AMT" -> StipulationType.Amt
    |"AUTOREINV" -> StipulationType.AutoReinvestmentAtOrBetter
    |"BANKQUAL" -> StipulationType.BankQualified
    |"BGNCON" -> StipulationType.BargainConditions
    |"COUPON" -> StipulationType.CouponRange
    |"CURRENCY" -> StipulationType.IsoCurrencyCode
    |"CUSTOMDATE" -> StipulationType.CustomStartEndDate
    |"GEOG" -> StipulationType.GeographicsAndPercentRange
    |"HAIRCUT" -> StipulationType.ValuationDiscount
    |"INSURED" -> StipulationType.Insured
    |"ISSUE" -> StipulationType.YearOrYearMonthOfIssue
    |"ISSUER" -> StipulationType.IssuersTicker
    |"ISSUESIZE" -> StipulationType.IssueSizeRange
    |"LOOKBACK" -> StipulationType.LookbackDays
    |"LOT" -> StipulationType.ExplicitLotIdentifier
    |"LOTVAR" -> StipulationType.LotVariance
    |"MAT" -> StipulationType.MaturityYearAndMonth
    |"MATURITY" -> StipulationType.MaturityRange
    |"MAXSUBS" -> StipulationType.MaximumSubstitutions
    |"MINQTY" -> StipulationType.MinimumQuantity
    |"MININCR" -> StipulationType.MinimumIncrement
    |"MINDNOM" -> StipulationType.MinimumDenomination
    |"PAYFREQ" -> StipulationType.PaymentFrequencyCalendar
    |"PIECES" -> StipulationType.NumberOfPieces
    |"PMAX" -> StipulationType.PoolsMaximum
    |"PPM" -> StipulationType.PoolsPerMillion
    |"PPL" -> StipulationType.PoolsPerLot
    |"PPT" -> StipulationType.PoolsPerTrade
    |"PRICE" -> StipulationType.PriceRange
    |"PRICEFREQ" -> StipulationType.PricingFrequency
    |"PROD" -> StipulationType.ProductionYear
    |"PROTECT" -> StipulationType.CallProtection
    |"PURPOSE" -> StipulationType.Purpose
    |"PXSOURCE" -> StipulationType.BenchmarkPriceSource
    |"RATING" -> StipulationType.RatingSourceAndRange
    |"RESTRICTED" -> StipulationType.Restricted
    |"SECTOR" -> StipulationType.MarketSector
    |"SECTYPE" -> StipulationType.SecuritytypeIncludedOrExcluded
    |"STRUCT" -> StipulationType.Structure
    |"SUBSFREQ" -> StipulationType.SubstitutionsFrequency
    |"SUBSLEFT" -> StipulationType.SubstitutionsLeft
    |"TEXT" -> StipulationType.FreeformText
    |"TRDVAR" -> StipulationType.TradeVariance
    |"WAC" -> StipulationType.WeightedAverageCoupon
    |"WAL" -> StipulationType.WeightedAverageLifeCoupon
    |"WALA" -> StipulationType.WeightedAverageLoanAge
    |"WAM" -> StipulationType.WeightedAverageMaturity
    |"WHOLE" -> StipulationType.WholePool
    |"YIELD" -> StipulationType.YieldRange
    |"SMM" -> StipulationType.SingleMonthlyMortality
    |"CPR" -> StipulationType.ConstantPrepaymentRate
    |"CPY" -> StipulationType.ConstantPrepaymentYield
    |"CPP" -> StipulationType.ConstantPrepaymentPenalty
    |"ABS" -> StipulationType.AbsolutePrepaymentSpeed
    |"MPR" -> StipulationType.MonthlyPrepaymentRate
    |"PSA" -> StipulationType.PercentOfBmaPrepaymentCurve
    |"PPC" -> StipulationType.PercentOfProspectusPrepaymentCurve
    |"MHP" -> StipulationType.PercentOfManufacturedHousingPrepaymentCurve
    |"HEP" -> StipulationType.FinalCprOfHomeEquityPrepaymentCurve
    | x -> failwith (sprintf "ReadStipulationType unknown fix tag: %A"  x) 


let WriteStipulationType (strm:Stream) (xxIn:StipulationType) =
    match xxIn with
    | StipulationType.Amt -> strm.Write "233=AMT"B; strm.Write (delim, 0, 1)
    | StipulationType.AutoReinvestmentAtOrBetter -> strm.Write "233=AUTOREINV"B; strm.Write (delim, 0, 1)
    | StipulationType.BankQualified -> strm.Write "233=BANKQUAL"B; strm.Write (delim, 0, 1)
    | StipulationType.BargainConditions -> strm.Write "233=BGNCON"B; strm.Write (delim, 0, 1)
    | StipulationType.CouponRange -> strm.Write "233=COUPON"B; strm.Write (delim, 0, 1)
    | StipulationType.IsoCurrencyCode -> strm.Write "233=CURRENCY"B; strm.Write (delim, 0, 1)
    | StipulationType.CustomStartEndDate -> strm.Write "233=CUSTOMDATE"B; strm.Write (delim, 0, 1)
    | StipulationType.GeographicsAndPercentRange -> strm.Write "233=GEOG"B; strm.Write (delim, 0, 1)
    | StipulationType.ValuationDiscount -> strm.Write "233=HAIRCUT"B; strm.Write (delim, 0, 1)
    | StipulationType.Insured -> strm.Write "233=INSURED"B; strm.Write (delim, 0, 1)
    | StipulationType.YearOrYearMonthOfIssue -> strm.Write "233=ISSUE"B; strm.Write (delim, 0, 1)
    | StipulationType.IssuersTicker -> strm.Write "233=ISSUER"B; strm.Write (delim, 0, 1)
    | StipulationType.IssueSizeRange -> strm.Write "233=ISSUESIZE"B; strm.Write (delim, 0, 1)
    | StipulationType.LookbackDays -> strm.Write "233=LOOKBACK"B; strm.Write (delim, 0, 1)
    | StipulationType.ExplicitLotIdentifier -> strm.Write "233=LOT"B; strm.Write (delim, 0, 1)
    | StipulationType.LotVariance -> strm.Write "233=LOTVAR"B; strm.Write (delim, 0, 1)
    | StipulationType.MaturityYearAndMonth -> strm.Write "233=MAT"B; strm.Write (delim, 0, 1)
    | StipulationType.MaturityRange -> strm.Write "233=MATURITY"B; strm.Write (delim, 0, 1)
    | StipulationType.MaximumSubstitutions -> strm.Write "233=MAXSUBS"B; strm.Write (delim, 0, 1)
    | StipulationType.MinimumQuantity -> strm.Write "233=MINQTY"B; strm.Write (delim, 0, 1)
    | StipulationType.MinimumIncrement -> strm.Write "233=MININCR"B; strm.Write (delim, 0, 1)
    | StipulationType.MinimumDenomination -> strm.Write "233=MINDNOM"B; strm.Write (delim, 0, 1)
    | StipulationType.PaymentFrequencyCalendar -> strm.Write "233=PAYFREQ"B; strm.Write (delim, 0, 1)
    | StipulationType.NumberOfPieces -> strm.Write "233=PIECES"B; strm.Write (delim, 0, 1)
    | StipulationType.PoolsMaximum -> strm.Write "233=PMAX"B; strm.Write (delim, 0, 1)
    | StipulationType.PoolsPerMillion -> strm.Write "233=PPM"B; strm.Write (delim, 0, 1)
    | StipulationType.PoolsPerLot -> strm.Write "233=PPL"B; strm.Write (delim, 0, 1)
    | StipulationType.PoolsPerTrade -> strm.Write "233=PPT"B; strm.Write (delim, 0, 1)
    | StipulationType.PriceRange -> strm.Write "233=PRICE"B; strm.Write (delim, 0, 1)
    | StipulationType.PricingFrequency -> strm.Write "233=PRICEFREQ"B; strm.Write (delim, 0, 1)
    | StipulationType.ProductionYear -> strm.Write "233=PROD"B; strm.Write (delim, 0, 1)
    | StipulationType.CallProtection -> strm.Write "233=PROTECT"B; strm.Write (delim, 0, 1)
    | StipulationType.Purpose -> strm.Write "233=PURPOSE"B; strm.Write (delim, 0, 1)
    | StipulationType.BenchmarkPriceSource -> strm.Write "233=PXSOURCE"B; strm.Write (delim, 0, 1)
    | StipulationType.RatingSourceAndRange -> strm.Write "233=RATING"B; strm.Write (delim, 0, 1)
    | StipulationType.Restricted -> strm.Write "233=RESTRICTED"B; strm.Write (delim, 0, 1)
    | StipulationType.MarketSector -> strm.Write "233=SECTOR"B; strm.Write (delim, 0, 1)
    | StipulationType.SecuritytypeIncludedOrExcluded -> strm.Write "233=SECTYPE"B; strm.Write (delim, 0, 1)
    | StipulationType.Structure -> strm.Write "233=STRUCT"B; strm.Write (delim, 0, 1)
    | StipulationType.SubstitutionsFrequency -> strm.Write "233=SUBSFREQ"B; strm.Write (delim, 0, 1)
    | StipulationType.SubstitutionsLeft -> strm.Write "233=SUBSLEFT"B; strm.Write (delim, 0, 1)
    | StipulationType.FreeformText -> strm.Write "233=TEXT"B; strm.Write (delim, 0, 1)
    | StipulationType.TradeVariance -> strm.Write "233=TRDVAR"B; strm.Write (delim, 0, 1)
    | StipulationType.WeightedAverageCoupon -> strm.Write "233=WAC"B; strm.Write (delim, 0, 1)
    | StipulationType.WeightedAverageLifeCoupon -> strm.Write "233=WAL"B; strm.Write (delim, 0, 1)
    | StipulationType.WeightedAverageLoanAge -> strm.Write "233=WALA"B; strm.Write (delim, 0, 1)
    | StipulationType.WeightedAverageMaturity -> strm.Write "233=WAM"B; strm.Write (delim, 0, 1)
    | StipulationType.WholePool -> strm.Write "233=WHOLE"B; strm.Write (delim, 0, 1)
    | StipulationType.YieldRange -> strm.Write "233=YIELD"B; strm.Write (delim, 0, 1)
    | StipulationType.SingleMonthlyMortality -> strm.Write "233=SMM"B; strm.Write (delim, 0, 1)
    | StipulationType.ConstantPrepaymentRate -> strm.Write "233=CPR"B; strm.Write (delim, 0, 1)
    | StipulationType.ConstantPrepaymentYield -> strm.Write "233=CPY"B; strm.Write (delim, 0, 1)
    | StipulationType.ConstantPrepaymentPenalty -> strm.Write "233=CPP"B; strm.Write (delim, 0, 1)
    | StipulationType.AbsolutePrepaymentSpeed -> strm.Write "233=ABS"B; strm.Write (delim, 0, 1)
    | StipulationType.MonthlyPrepaymentRate -> strm.Write "233=MPR"B; strm.Write (delim, 0, 1)
    | StipulationType.PercentOfBmaPrepaymentCurve -> strm.Write "233=PSA"B; strm.Write (delim, 0, 1)
    | StipulationType.PercentOfProspectusPrepaymentCurve -> strm.Write "233=PPC"B; strm.Write (delim, 0, 1)
    | StipulationType.PercentOfManufacturedHousingPrepaymentCurve -> strm.Write "233=MHP"B; strm.Write (delim, 0, 1)
    | StipulationType.FinalCprOfHomeEquityPrepaymentCurve -> strm.Write "233=HEP"B; strm.Write (delim, 0, 1)


let ReadStipulationValue (fldValIn:string) : StipulationValue = 
    match fldValIn with
    |"CD" -> StipulationValue.SpecialCumDividend
    |"XD" -> StipulationValue.SpecialExDividend
    |"CC" -> StipulationValue.SpecialCumCoupon
    |"XC" -> StipulationValue.SpecialExCoupon
    |"CB" -> StipulationValue.SpecialCumBonus
    |"XB" -> StipulationValue.SpecialExBonus
    |"CR" -> StipulationValue.SpecialCumRights
    |"XR" -> StipulationValue.SpecialExRights
    |"CP" -> StipulationValue.SpecialCumCapitalRepayments
    |"XP" -> StipulationValue.SpecialExCapitalRepayments
    |"CS" -> StipulationValue.CashSettlement
    |"SP" -> StipulationValue.SpecialPrice
    |"TR" -> StipulationValue.ReportForEuropeanEquityMarketSecurities
    |"GD" -> StipulationValue.GuaranteedDelivery
    | x -> failwith (sprintf "ReadStipulationValue unknown fix tag: %A"  x) 


let WriteStipulationValue (strm:Stream) (xxIn:StipulationValue) =
    match xxIn with
    | StipulationValue.SpecialCumDividend -> strm.Write "234=CD"B; strm.Write (delim, 0, 1)
    | StipulationValue.SpecialExDividend -> strm.Write "234=XD"B; strm.Write (delim, 0, 1)
    | StipulationValue.SpecialCumCoupon -> strm.Write "234=CC"B; strm.Write (delim, 0, 1)
    | StipulationValue.SpecialExCoupon -> strm.Write "234=XC"B; strm.Write (delim, 0, 1)
    | StipulationValue.SpecialCumBonus -> strm.Write "234=CB"B; strm.Write (delim, 0, 1)
    | StipulationValue.SpecialExBonus -> strm.Write "234=XB"B; strm.Write (delim, 0, 1)
    | StipulationValue.SpecialCumRights -> strm.Write "234=CR"B; strm.Write (delim, 0, 1)
    | StipulationValue.SpecialExRights -> strm.Write "234=XR"B; strm.Write (delim, 0, 1)
    | StipulationValue.SpecialCumCapitalRepayments -> strm.Write "234=CP"B; strm.Write (delim, 0, 1)
    | StipulationValue.SpecialExCapitalRepayments -> strm.Write "234=XP"B; strm.Write (delim, 0, 1)
    | StipulationValue.CashSettlement -> strm.Write "234=CS"B; strm.Write (delim, 0, 1)
    | StipulationValue.SpecialPrice -> strm.Write "234=SP"B; strm.Write (delim, 0, 1)
    | StipulationValue.ReportForEuropeanEquityMarketSecurities -> strm.Write "234=TR"B; strm.Write (delim, 0, 1)
    | StipulationValue.GuaranteedDelivery -> strm.Write "234=GD"B; strm.Write (delim, 0, 1)


let ReadYieldType (fldValIn:string) : YieldType = 
    match fldValIn with
    |"AFTERTAX" -> YieldType.AfterTaxYield
    |"ANNUAL" -> YieldType.AnnualYield
    |"ATISSUE" -> YieldType.YieldAtIssue
    |"AVGMATURITY" -> YieldType.YieldToAverageMaturity
    |"BOOK" -> YieldType.BookYield
    |"CALL" -> YieldType.YieldToNextCall
    |"CHANGE" -> YieldType.YieldChangeSinceClose
    |"CLOSE" -> YieldType.ClosingYield
    |"COMPOUND" -> YieldType.CompoundYield
    |"CURRENT" -> YieldType.CurrentYield
    |"GROSS" -> YieldType.TrueGrossYield
    |"GOVTEQUIV" -> YieldType.GovernmentEquivalentYield
    |"INFLATION" -> YieldType.YieldWithInflationAssumption
    |"INVERSEFLOATER" -> YieldType.InverseFloaterBondYield
    |"LASTCLOSE" -> YieldType.MostRecentClosingYield
    |"LASTMONTH" -> YieldType.ClosingYieldMostRecentMonth
    |"LASTQUARTER" -> YieldType.ClosingYieldMostRecentQuarter
    |"LASTYEAR" -> YieldType.ClosingYieldMostRecentYear
    |"LONGAVGLIFE" -> YieldType.YieldToLongestAverageLife
    |"MARK" -> YieldType.MarkToMarketYield
    |"MATURITY" -> YieldType.YieldToMaturity
    |"NEXTREFUND" -> YieldType.YieldToNextRefund
    |"OPENAVG" -> YieldType.OpenAverageYield
    |"PUT" -> YieldType.YieldToNextPut
    |"PREVCLOSE" -> YieldType.PreviousCloseYield
    |"PROCEEDS" -> YieldType.ProceedsYield
    |"SEMIANNUAL" -> YieldType.SemiAnnualYield
    |"SHORTAVGLIFE" -> YieldType.YieldToShortestAverageLife
    |"SIMPLE" -> YieldType.SimpleYield
    |"TAXEQUIV" -> YieldType.TaxEquivalentYield
    |"TENDER" -> YieldType.YieldToTenderDate
    |"TRUE" -> YieldType.TrueYield
    |"VALUE1_32" -> YieldType.YieldValueOf132
    |"WORST" -> YieldType.YieldToWorst
    | x -> failwith (sprintf "ReadYieldType unknown fix tag: %A"  x) 


let WriteYieldType (strm:Stream) (xxIn:YieldType) =
    match xxIn with
    | YieldType.AfterTaxYield -> strm.Write "235=AFTERTAX"B; strm.Write (delim, 0, 1)
    | YieldType.AnnualYield -> strm.Write "235=ANNUAL"B; strm.Write (delim, 0, 1)
    | YieldType.YieldAtIssue -> strm.Write "235=ATISSUE"B; strm.Write (delim, 0, 1)
    | YieldType.YieldToAverageMaturity -> strm.Write "235=AVGMATURITY"B; strm.Write (delim, 0, 1)
    | YieldType.BookYield -> strm.Write "235=BOOK"B; strm.Write (delim, 0, 1)
    | YieldType.YieldToNextCall -> strm.Write "235=CALL"B; strm.Write (delim, 0, 1)
    | YieldType.YieldChangeSinceClose -> strm.Write "235=CHANGE"B; strm.Write (delim, 0, 1)
    | YieldType.ClosingYield -> strm.Write "235=CLOSE"B; strm.Write (delim, 0, 1)
    | YieldType.CompoundYield -> strm.Write "235=COMPOUND"B; strm.Write (delim, 0, 1)
    | YieldType.CurrentYield -> strm.Write "235=CURRENT"B; strm.Write (delim, 0, 1)
    | YieldType.TrueGrossYield -> strm.Write "235=GROSS"B; strm.Write (delim, 0, 1)
    | YieldType.GovernmentEquivalentYield -> strm.Write "235=GOVTEQUIV"B; strm.Write (delim, 0, 1)
    | YieldType.YieldWithInflationAssumption -> strm.Write "235=INFLATION"B; strm.Write (delim, 0, 1)
    | YieldType.InverseFloaterBondYield -> strm.Write "235=INVERSEFLOATER"B; strm.Write (delim, 0, 1)
    | YieldType.MostRecentClosingYield -> strm.Write "235=LASTCLOSE"B; strm.Write (delim, 0, 1)
    | YieldType.ClosingYieldMostRecentMonth -> strm.Write "235=LASTMONTH"B; strm.Write (delim, 0, 1)
    | YieldType.ClosingYieldMostRecentQuarter -> strm.Write "235=LASTQUARTER"B; strm.Write (delim, 0, 1)
    | YieldType.ClosingYieldMostRecentYear -> strm.Write "235=LASTYEAR"B; strm.Write (delim, 0, 1)
    | YieldType.YieldToLongestAverageLife -> strm.Write "235=LONGAVGLIFE"B; strm.Write (delim, 0, 1)
    | YieldType.MarkToMarketYield -> strm.Write "235=MARK"B; strm.Write (delim, 0, 1)
    | YieldType.YieldToMaturity -> strm.Write "235=MATURITY"B; strm.Write (delim, 0, 1)
    | YieldType.YieldToNextRefund -> strm.Write "235=NEXTREFUND"B; strm.Write (delim, 0, 1)
    | YieldType.OpenAverageYield -> strm.Write "235=OPENAVG"B; strm.Write (delim, 0, 1)
    | YieldType.YieldToNextPut -> strm.Write "235=PUT"B; strm.Write (delim, 0, 1)
    | YieldType.PreviousCloseYield -> strm.Write "235=PREVCLOSE"B; strm.Write (delim, 0, 1)
    | YieldType.ProceedsYield -> strm.Write "235=PROCEEDS"B; strm.Write (delim, 0, 1)
    | YieldType.SemiAnnualYield -> strm.Write "235=SEMIANNUAL"B; strm.Write (delim, 0, 1)
    | YieldType.YieldToShortestAverageLife -> strm.Write "235=SHORTAVGLIFE"B; strm.Write (delim, 0, 1)
    | YieldType.SimpleYield -> strm.Write "235=SIMPLE"B; strm.Write (delim, 0, 1)
    | YieldType.TaxEquivalentYield -> strm.Write "235=TAXEQUIV"B; strm.Write (delim, 0, 1)
    | YieldType.YieldToTenderDate -> strm.Write "235=TENDER"B; strm.Write (delim, 0, 1)
    | YieldType.TrueYield -> strm.Write "235=TRUE"B; strm.Write (delim, 0, 1)
    | YieldType.YieldValueOf132 -> strm.Write "235=VALUE1_32"B; strm.Write (delim, 0, 1)
    | YieldType.YieldToWorst -> strm.Write "235=WORST"B; strm.Write (delim, 0, 1)


let ReadYield valIn =
    let tmp = System.Decimal.Parse valIn
    Yield.Yield tmp


let WriteYield (strm:Stream) (valIn:Yield) = 
    let tag = "236="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTotalTakedown valIn =
    let tmp = System.Int32.Parse valIn
    TotalTakedown.TotalTakedown tmp


let WriteTotalTakedown (strm:Stream) (valIn:TotalTakedown) = 
    let tag = "237="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadConcession valIn =
    let tmp = System.Int32.Parse valIn
    Concession.Concession tmp


let WriteConcession (strm:Stream) (valIn:Concession) = 
    let tag = "238="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRepoCollateralSecurityType valIn =
    let tmp = System.Int32.Parse valIn
    RepoCollateralSecurityType.RepoCollateralSecurityType tmp


let WriteRepoCollateralSecurityType (strm:Stream) (valIn:RepoCollateralSecurityType) = 
    let tag = "239="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRedemptionDate valIn =
    let tmp =  valIn
    RedemptionDate.RedemptionDate tmp


let WriteRedemptionDate (strm:Stream) (valIn:RedemptionDate) = 
    let tag = "240="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingCouponPaymentDate valIn =
    let tmp =  valIn
    UnderlyingCouponPaymentDate.UnderlyingCouponPaymentDate tmp


let WriteUnderlyingCouponPaymentDate (strm:Stream) (valIn:UnderlyingCouponPaymentDate) = 
    let tag = "241="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingIssueDate valIn =
    let tmp =  valIn
    UnderlyingIssueDate.UnderlyingIssueDate tmp


let WriteUnderlyingIssueDate (strm:Stream) (valIn:UnderlyingIssueDate) = 
    let tag = "242="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingRepoCollateralSecurityType valIn =
    let tmp = System.Int32.Parse valIn
    UnderlyingRepoCollateralSecurityType.UnderlyingRepoCollateralSecurityType tmp


let WriteUnderlyingRepoCollateralSecurityType (strm:Stream) (valIn:UnderlyingRepoCollateralSecurityType) = 
    let tag = "243="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingRepurchaseTerm valIn =
    let tmp = System.Int32.Parse valIn
    UnderlyingRepurchaseTerm.UnderlyingRepurchaseTerm tmp


let WriteUnderlyingRepurchaseTerm (strm:Stream) (valIn:UnderlyingRepurchaseTerm) = 
    let tag = "244="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingRepurchaseRate valIn =
    let tmp = System.Decimal.Parse valIn
    UnderlyingRepurchaseRate.UnderlyingRepurchaseRate tmp


let WriteUnderlyingRepurchaseRate (strm:Stream) (valIn:UnderlyingRepurchaseRate) = 
    let tag = "245="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingFactor valIn =
    let tmp = System.Decimal.Parse valIn
    UnderlyingFactor.UnderlyingFactor tmp


let WriteUnderlyingFactor (strm:Stream) (valIn:UnderlyingFactor) = 
    let tag = "246="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingRedemptionDate valIn =
    let tmp =  valIn
    UnderlyingRedemptionDate.UnderlyingRedemptionDate tmp


let WriteUnderlyingRedemptionDate (strm:Stream) (valIn:UnderlyingRedemptionDate) = 
    let tag = "247="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegCouponPaymentDate valIn =
    let tmp =  valIn
    LegCouponPaymentDate.LegCouponPaymentDate tmp


let WriteLegCouponPaymentDate (strm:Stream) (valIn:LegCouponPaymentDate) = 
    let tag = "248="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegIssueDate valIn =
    let tmp =  valIn
    LegIssueDate.LegIssueDate tmp


let WriteLegIssueDate (strm:Stream) (valIn:LegIssueDate) = 
    let tag = "249="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegRepoCollateralSecurityType valIn =
    let tmp = System.Int32.Parse valIn
    LegRepoCollateralSecurityType.LegRepoCollateralSecurityType tmp


let WriteLegRepoCollateralSecurityType (strm:Stream) (valIn:LegRepoCollateralSecurityType) = 
    let tag = "250="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegRepurchaseTerm valIn =
    let tmp = System.Int32.Parse valIn
    LegRepurchaseTerm.LegRepurchaseTerm tmp


let WriteLegRepurchaseTerm (strm:Stream) (valIn:LegRepurchaseTerm) = 
    let tag = "251="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegRepurchaseRate valIn =
    let tmp = System.Decimal.Parse valIn
    LegRepurchaseRate.LegRepurchaseRate tmp


let WriteLegRepurchaseRate (strm:Stream) (valIn:LegRepurchaseRate) = 
    let tag = "252="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegFactor valIn =
    let tmp = System.Decimal.Parse valIn
    LegFactor.LegFactor tmp


let WriteLegFactor (strm:Stream) (valIn:LegFactor) = 
    let tag = "253="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegRedemptionDate valIn =
    let tmp =  valIn
    LegRedemptionDate.LegRedemptionDate tmp


let WriteLegRedemptionDate (strm:Stream) (valIn:LegRedemptionDate) = 
    let tag = "254="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCreditRating valIn =
    let tmp =  valIn
    CreditRating.CreditRating tmp


let WriteCreditRating (strm:Stream) (valIn:CreditRating) = 
    let tag = "255="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingCreditRating valIn =
    let tmp =  valIn
    UnderlyingCreditRating.UnderlyingCreditRating tmp


let WriteUnderlyingCreditRating (strm:Stream) (valIn:UnderlyingCreditRating) = 
    let tag = "256="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegCreditRating valIn =
    let tmp =  valIn
    LegCreditRating.LegCreditRating tmp


let WriteLegCreditRating (strm:Stream) (valIn:LegCreditRating) = 
    let tag = "257="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradedFlatSwitch valIn =
    let tmp = System.Boolean.Parse valIn
    TradedFlatSwitch.TradedFlatSwitch tmp


let WriteTradedFlatSwitch (strm:Stream) (valIn:TradedFlatSwitch) = 
    let tag = "258="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBasisFeatureDate valIn =
    let tmp =  valIn
    BasisFeatureDate.BasisFeatureDate tmp


let WriteBasisFeatureDate (strm:Stream) (valIn:BasisFeatureDate) = 
    let tag = "259="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBasisFeaturePrice valIn =
    let tmp = System.Decimal.Parse valIn
    BasisFeaturePrice.BasisFeaturePrice tmp


let WriteBasisFeaturePrice (strm:Stream) (valIn:BasisFeaturePrice) = 
    let tag = "260="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMDReqID valIn =
    let tmp =  valIn
    MDReqID.MDReqID tmp


let WriteMDReqID (strm:Stream) (valIn:MDReqID) = 
    let tag = "262="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSubscriptionRequestType (fldValIn:string) : SubscriptionRequestType = 
    match fldValIn with
    |"0" -> SubscriptionRequestType.Snapshot
    |"1" -> SubscriptionRequestType.SnapshotPlusUpdates
    |"2" -> SubscriptionRequestType.DisablePreviousSnapshotPlusUpdateRequest
    | x -> failwith (sprintf "ReadSubscriptionRequestType unknown fix tag: %A"  x) 


let WriteSubscriptionRequestType (strm:Stream) (xxIn:SubscriptionRequestType) =
    match xxIn with
    | SubscriptionRequestType.Snapshot -> strm.Write "263=0"B; strm.Write (delim, 0, 1)
    | SubscriptionRequestType.SnapshotPlusUpdates -> strm.Write "263=1"B; strm.Write (delim, 0, 1)
    | SubscriptionRequestType.DisablePreviousSnapshotPlusUpdateRequest -> strm.Write "263=2"B; strm.Write (delim, 0, 1)


let ReadMarketDepth valIn =
    let tmp = System.Int32.Parse valIn
    MarketDepth.MarketDepth tmp


let WriteMarketDepth (strm:Stream) (valIn:MarketDepth) = 
    let tag = "264="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMDUpdateType (fldValIn:string) : MDUpdateType = 
    match fldValIn with
    |"0" -> MDUpdateType.FullRefresh
    |"1" -> MDUpdateType.IncrementalRefresh
    | x -> failwith (sprintf "ReadMDUpdateType unknown fix tag: %A"  x) 


let WriteMDUpdateType (strm:Stream) (xxIn:MDUpdateType) =
    match xxIn with
    | MDUpdateType.FullRefresh -> strm.Write "265=0"B; strm.Write (delim, 0, 1)
    | MDUpdateType.IncrementalRefresh -> strm.Write "265=1"B; strm.Write (delim, 0, 1)


let ReadAggregatedBook valIn =
    let tmp = System.Boolean.Parse valIn
    AggregatedBook.AggregatedBook tmp


let WriteAggregatedBook (strm:Stream) (valIn:AggregatedBook) = 
    let tag = "266="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoMDEntryTypes valIn =
    let tmp = System.Int32.Parse valIn
    NoMDEntryTypes.NoMDEntryTypes tmp


let WriteNoMDEntryTypes (strm:Stream) (valIn:NoMDEntryTypes) = 
    let tag = "267="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoMDEntries valIn =
    let tmp = System.Int32.Parse valIn
    NoMDEntries.NoMDEntries tmp


let WriteNoMDEntries (strm:Stream) (valIn:NoMDEntries) = 
    let tag = "268="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMDEntryType (fldValIn:string) : MDEntryType = 
    match fldValIn with
    |"0" -> MDEntryType.Bid
    |"1" -> MDEntryType.Offer
    |"2" -> MDEntryType.Trade
    |"3" -> MDEntryType.IndexValue
    |"4" -> MDEntryType.OpeningPrice
    |"5" -> MDEntryType.ClosingPrice
    |"6" -> MDEntryType.SettlementPrice
    |"7" -> MDEntryType.TradingSessionHighPrice
    |"8" -> MDEntryType.TradingSessionLowPrice
    |"9" -> MDEntryType.TradingSessionVwapPrice
    |"A" -> MDEntryType.Imbalance
    |"B" -> MDEntryType.TradeVolume
    |"C" -> MDEntryType.OpenInterest
    | x -> failwith (sprintf "ReadMDEntryType unknown fix tag: %A"  x) 


let WriteMDEntryType (strm:Stream) (xxIn:MDEntryType) =
    match xxIn with
    | MDEntryType.Bid -> strm.Write "269=0"B; strm.Write (delim, 0, 1)
    | MDEntryType.Offer -> strm.Write "269=1"B; strm.Write (delim, 0, 1)
    | MDEntryType.Trade -> strm.Write "269=2"B; strm.Write (delim, 0, 1)
    | MDEntryType.IndexValue -> strm.Write "269=3"B; strm.Write (delim, 0, 1)
    | MDEntryType.OpeningPrice -> strm.Write "269=4"B; strm.Write (delim, 0, 1)
    | MDEntryType.ClosingPrice -> strm.Write "269=5"B; strm.Write (delim, 0, 1)
    | MDEntryType.SettlementPrice -> strm.Write "269=6"B; strm.Write (delim, 0, 1)
    | MDEntryType.TradingSessionHighPrice -> strm.Write "269=7"B; strm.Write (delim, 0, 1)
    | MDEntryType.TradingSessionLowPrice -> strm.Write "269=8"B; strm.Write (delim, 0, 1)
    | MDEntryType.TradingSessionVwapPrice -> strm.Write "269=9"B; strm.Write (delim, 0, 1)
    | MDEntryType.Imbalance -> strm.Write "269=A"B; strm.Write (delim, 0, 1)
    | MDEntryType.TradeVolume -> strm.Write "269=B"B; strm.Write (delim, 0, 1)
    | MDEntryType.OpenInterest -> strm.Write "269=C"B; strm.Write (delim, 0, 1)


let ReadMDEntryPx valIn =
    let tmp = System.Decimal.Parse valIn
    MDEntryPx.MDEntryPx tmp


let WriteMDEntryPx (strm:Stream) (valIn:MDEntryPx) = 
    let tag = "270="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMDEntrySize valIn =
    let tmp = System.Decimal.Parse valIn
    MDEntrySize.MDEntrySize tmp


let WriteMDEntrySize (strm:Stream) (valIn:MDEntrySize) = 
    let tag = "271="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMDEntryDate valIn =
    let tmp =  valIn
    MDEntryDate.MDEntryDate tmp


let WriteMDEntryDate (strm:Stream) (valIn:MDEntryDate) = 
    let tag = "272="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMDEntryTime valIn =
    let tmp =  valIn
    MDEntryTime.MDEntryTime tmp


let WriteMDEntryTime (strm:Stream) (valIn:MDEntryTime) = 
    let tag = "273="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTickDirection (fldValIn:string) : TickDirection = 
    match fldValIn with
    |"0" -> TickDirection.PlusTick
    |"1" -> TickDirection.ZeroPlusTick
    |"2" -> TickDirection.MinusTick
    |"3" -> TickDirection.ZeroMinusTick
    | x -> failwith (sprintf "ReadTickDirection unknown fix tag: %A"  x) 


let WriteTickDirection (strm:Stream) (xxIn:TickDirection) =
    match xxIn with
    | TickDirection.PlusTick -> strm.Write "274=0"B; strm.Write (delim, 0, 1)
    | TickDirection.ZeroPlusTick -> strm.Write "274=1"B; strm.Write (delim, 0, 1)
    | TickDirection.MinusTick -> strm.Write "274=2"B; strm.Write (delim, 0, 1)
    | TickDirection.ZeroMinusTick -> strm.Write "274=3"B; strm.Write (delim, 0, 1)


let ReadMDMkt valIn =
    let tmp =  valIn
    MDMkt.MDMkt tmp


let WriteMDMkt (strm:Stream) (valIn:MDMkt) = 
    let tag = "275="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuoteCondition (fldValIn:string) : QuoteCondition = 
    match fldValIn with
    |"A" -> QuoteCondition.OpenActive
    |"B" -> QuoteCondition.ClosedInactive
    |"C" -> QuoteCondition.ExchangeBest
    |"D" -> QuoteCondition.ConsolidatedBest
    |"E" -> QuoteCondition.Locked
    |"F" -> QuoteCondition.Crossed
    |"G" -> QuoteCondition.Depth
    |"H" -> QuoteCondition.FastTrading
    |"I" -> QuoteCondition.NonFirm
    | x -> failwith (sprintf "ReadQuoteCondition unknown fix tag: %A"  x) 


let WriteQuoteCondition (strm:Stream) (xxIn:QuoteCondition) =
    match xxIn with
    | QuoteCondition.OpenActive -> strm.Write "276=A"B; strm.Write (delim, 0, 1)
    | QuoteCondition.ClosedInactive -> strm.Write "276=B"B; strm.Write (delim, 0, 1)
    | QuoteCondition.ExchangeBest -> strm.Write "276=C"B; strm.Write (delim, 0, 1)
    | QuoteCondition.ConsolidatedBest -> strm.Write "276=D"B; strm.Write (delim, 0, 1)
    | QuoteCondition.Locked -> strm.Write "276=E"B; strm.Write (delim, 0, 1)
    | QuoteCondition.Crossed -> strm.Write "276=F"B; strm.Write (delim, 0, 1)
    | QuoteCondition.Depth -> strm.Write "276=G"B; strm.Write (delim, 0, 1)
    | QuoteCondition.FastTrading -> strm.Write "276=H"B; strm.Write (delim, 0, 1)
    | QuoteCondition.NonFirm -> strm.Write "276=I"B; strm.Write (delim, 0, 1)


let ReadTradeCondition (fldValIn:string) : TradeCondition = 
    match fldValIn with
    |"A" -> TradeCondition.CashMarket
    |"B" -> TradeCondition.AveragePriceTrade
    |"C" -> TradeCondition.CashTrade
    |"D" -> TradeCondition.NextDayMarket
    |"E" -> TradeCondition.OpeningReopeningTradeDetail
    |"F" -> TradeCondition.IntradayTradeDetail
    |"G" -> TradeCondition.Rule127
    |"H" -> TradeCondition.Rule155
    |"I" -> TradeCondition.SoldLast
    |"J" -> TradeCondition.NextDayTrade
    |"K" -> TradeCondition.Opened
    |"L" -> TradeCondition.Seller
    |"M" -> TradeCondition.Sold
    |"N" -> TradeCondition.StoppedStock
    |"P" -> TradeCondition.ImbalanceMoreBuyers
    |"Q" -> TradeCondition.ImbalanceMoreSellers
    |"R" -> TradeCondition.OpeningPrice
    | x -> failwith (sprintf "ReadTradeCondition unknown fix tag: %A"  x) 


let WriteTradeCondition (strm:Stream) (xxIn:TradeCondition) =
    match xxIn with
    | TradeCondition.CashMarket -> strm.Write "277=A"B; strm.Write (delim, 0, 1)
    | TradeCondition.AveragePriceTrade -> strm.Write "277=B"B; strm.Write (delim, 0, 1)
    | TradeCondition.CashTrade -> strm.Write "277=C"B; strm.Write (delim, 0, 1)
    | TradeCondition.NextDayMarket -> strm.Write "277=D"B; strm.Write (delim, 0, 1)
    | TradeCondition.OpeningReopeningTradeDetail -> strm.Write "277=E"B; strm.Write (delim, 0, 1)
    | TradeCondition.IntradayTradeDetail -> strm.Write "277=F"B; strm.Write (delim, 0, 1)
    | TradeCondition.Rule127 -> strm.Write "277=G"B; strm.Write (delim, 0, 1)
    | TradeCondition.Rule155 -> strm.Write "277=H"B; strm.Write (delim, 0, 1)
    | TradeCondition.SoldLast -> strm.Write "277=I"B; strm.Write (delim, 0, 1)
    | TradeCondition.NextDayTrade -> strm.Write "277=J"B; strm.Write (delim, 0, 1)
    | TradeCondition.Opened -> strm.Write "277=K"B; strm.Write (delim, 0, 1)
    | TradeCondition.Seller -> strm.Write "277=L"B; strm.Write (delim, 0, 1)
    | TradeCondition.Sold -> strm.Write "277=M"B; strm.Write (delim, 0, 1)
    | TradeCondition.StoppedStock -> strm.Write "277=N"B; strm.Write (delim, 0, 1)
    | TradeCondition.ImbalanceMoreBuyers -> strm.Write "277=P"B; strm.Write (delim, 0, 1)
    | TradeCondition.ImbalanceMoreSellers -> strm.Write "277=Q"B; strm.Write (delim, 0, 1)
    | TradeCondition.OpeningPrice -> strm.Write "277=R"B; strm.Write (delim, 0, 1)


let ReadMDEntryID valIn =
    let tmp =  valIn
    MDEntryID.MDEntryID tmp


let WriteMDEntryID (strm:Stream) (valIn:MDEntryID) = 
    let tag = "278="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMDUpdateAction (fldValIn:string) : MDUpdateAction = 
    match fldValIn with
    |"0" -> MDUpdateAction.New
    |"1" -> MDUpdateAction.Change
    |"2" -> MDUpdateAction.Delete
    | x -> failwith (sprintf "ReadMDUpdateAction unknown fix tag: %A"  x) 


let WriteMDUpdateAction (strm:Stream) (xxIn:MDUpdateAction) =
    match xxIn with
    | MDUpdateAction.New -> strm.Write "279=0"B; strm.Write (delim, 0, 1)
    | MDUpdateAction.Change -> strm.Write "279=1"B; strm.Write (delim, 0, 1)
    | MDUpdateAction.Delete -> strm.Write "279=2"B; strm.Write (delim, 0, 1)


let ReadMDEntryRefID valIn =
    let tmp =  valIn
    MDEntryRefID.MDEntryRefID tmp


let WriteMDEntryRefID (strm:Stream) (valIn:MDEntryRefID) = 
    let tag = "280="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMDReqRejReason (fldValIn:string) : MDReqRejReason = 
    match fldValIn with
    |"0" -> MDReqRejReason.UnknownSymbol
    |"1" -> MDReqRejReason.DuplicateMdreqid
    |"2" -> MDReqRejReason.InsufficientBandwidth
    |"3" -> MDReqRejReason.InsufficientPermissions
    |"4" -> MDReqRejReason.UnsupportedSubscriptionrequesttype
    |"5" -> MDReqRejReason.UnsupportedMarketdepth
    |"6" -> MDReqRejReason.UnsupportedMdupdatetype
    |"7" -> MDReqRejReason.UnsupportedAggregatedbook
    |"8" -> MDReqRejReason.UnsupportedMdentrytype
    |"9" -> MDReqRejReason.UnsupportedTradingsessionid
    |"A" -> MDReqRejReason.UnsupportedScope
    |"B" -> MDReqRejReason.UnsupportedOpenclosesettleflag
    |"C" -> MDReqRejReason.UnsupportedMdimplicitdelete
    | x -> failwith (sprintf "ReadMDReqRejReason unknown fix tag: %A"  x) 


let WriteMDReqRejReason (strm:Stream) (xxIn:MDReqRejReason) =
    match xxIn with
    | MDReqRejReason.UnknownSymbol -> strm.Write "281=0"B; strm.Write (delim, 0, 1)
    | MDReqRejReason.DuplicateMdreqid -> strm.Write "281=1"B; strm.Write (delim, 0, 1)
    | MDReqRejReason.InsufficientBandwidth -> strm.Write "281=2"B; strm.Write (delim, 0, 1)
    | MDReqRejReason.InsufficientPermissions -> strm.Write "281=3"B; strm.Write (delim, 0, 1)
    | MDReqRejReason.UnsupportedSubscriptionrequesttype -> strm.Write "281=4"B; strm.Write (delim, 0, 1)
    | MDReqRejReason.UnsupportedMarketdepth -> strm.Write "281=5"B; strm.Write (delim, 0, 1)
    | MDReqRejReason.UnsupportedMdupdatetype -> strm.Write "281=6"B; strm.Write (delim, 0, 1)
    | MDReqRejReason.UnsupportedAggregatedbook -> strm.Write "281=7"B; strm.Write (delim, 0, 1)
    | MDReqRejReason.UnsupportedMdentrytype -> strm.Write "281=8"B; strm.Write (delim, 0, 1)
    | MDReqRejReason.UnsupportedTradingsessionid -> strm.Write "281=9"B; strm.Write (delim, 0, 1)
    | MDReqRejReason.UnsupportedScope -> strm.Write "281=A"B; strm.Write (delim, 0, 1)
    | MDReqRejReason.UnsupportedOpenclosesettleflag -> strm.Write "281=B"B; strm.Write (delim, 0, 1)
    | MDReqRejReason.UnsupportedMdimplicitdelete -> strm.Write "281=C"B; strm.Write (delim, 0, 1)


let ReadMDEntryOriginator valIn =
    let tmp =  valIn
    MDEntryOriginator.MDEntryOriginator tmp


let WriteMDEntryOriginator (strm:Stream) (valIn:MDEntryOriginator) = 
    let tag = "282="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLocationID valIn =
    let tmp =  valIn
    LocationID.LocationID tmp


let WriteLocationID (strm:Stream) (valIn:LocationID) = 
    let tag = "283="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDeskID valIn =
    let tmp =  valIn
    DeskID.DeskID tmp


let WriteDeskID (strm:Stream) (valIn:DeskID) = 
    let tag = "284="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDeleteReason (fldValIn:string) : DeleteReason = 
    match fldValIn with
    |"0" -> DeleteReason.CancelationTradeBust
    |"1" -> DeleteReason.Error
    | x -> failwith (sprintf "ReadDeleteReason unknown fix tag: %A"  x) 


let WriteDeleteReason (strm:Stream) (xxIn:DeleteReason) =
    match xxIn with
    | DeleteReason.CancelationTradeBust -> strm.Write "285=0"B; strm.Write (delim, 0, 1)
    | DeleteReason.Error -> strm.Write "285=1"B; strm.Write (delim, 0, 1)


let ReadOpenCloseSettlFlag (fldValIn:string) : OpenCloseSettlFlag = 
    match fldValIn with
    |"0" -> OpenCloseSettlFlag.DailyOpenCloseSettlementEntry
    |"1" -> OpenCloseSettlFlag.SessionOpenCloseSettlementEntry
    |"2" -> OpenCloseSettlFlag.DeliverySettlementEntry
    |"3" -> OpenCloseSettlFlag.ExpectedEntry
    |"4" -> OpenCloseSettlFlag.EntryFromPreviousBusinessDay
    |"5" -> OpenCloseSettlFlag.TheoreticalPriceValue
    | x -> failwith (sprintf "ReadOpenCloseSettlFlag unknown fix tag: %A"  x) 


let WriteOpenCloseSettlFlag (strm:Stream) (xxIn:OpenCloseSettlFlag) =
    match xxIn with
    | OpenCloseSettlFlag.DailyOpenCloseSettlementEntry -> strm.Write "286=0"B; strm.Write (delim, 0, 1)
    | OpenCloseSettlFlag.SessionOpenCloseSettlementEntry -> strm.Write "286=1"B; strm.Write (delim, 0, 1)
    | OpenCloseSettlFlag.DeliverySettlementEntry -> strm.Write "286=2"B; strm.Write (delim, 0, 1)
    | OpenCloseSettlFlag.ExpectedEntry -> strm.Write "286=3"B; strm.Write (delim, 0, 1)
    | OpenCloseSettlFlag.EntryFromPreviousBusinessDay -> strm.Write "286=4"B; strm.Write (delim, 0, 1)
    | OpenCloseSettlFlag.TheoreticalPriceValue -> strm.Write "286=5"B; strm.Write (delim, 0, 1)


let ReadSellerDays valIn =
    let tmp = System.Int32.Parse valIn
    SellerDays.SellerDays tmp


let WriteSellerDays (strm:Stream) (valIn:SellerDays) = 
    let tag = "287="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMDEntryBuyer valIn =
    let tmp =  valIn
    MDEntryBuyer.MDEntryBuyer tmp


let WriteMDEntryBuyer (strm:Stream) (valIn:MDEntryBuyer) = 
    let tag = "288="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMDEntrySeller valIn =
    let tmp =  valIn
    MDEntrySeller.MDEntrySeller tmp


let WriteMDEntrySeller (strm:Stream) (valIn:MDEntrySeller) = 
    let tag = "289="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMDEntryPositionNo valIn =
    let tmp = System.Int32.Parse valIn
    MDEntryPositionNo.MDEntryPositionNo tmp


let WriteMDEntryPositionNo (strm:Stream) (valIn:MDEntryPositionNo) = 
    let tag = "290="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadFinancialStatus (fldValIn:string) : FinancialStatus = 
    match fldValIn with
    |"1" -> FinancialStatus.Bankrupt
    |"2" -> FinancialStatus.PendingDelisting
    | x -> failwith (sprintf "ReadFinancialStatus unknown fix tag: %A"  x) 


let WriteFinancialStatus (strm:Stream) (xxIn:FinancialStatus) =
    match xxIn with
    | FinancialStatus.Bankrupt -> strm.Write "291=1"B; strm.Write (delim, 0, 1)
    | FinancialStatus.PendingDelisting -> strm.Write "291=2"B; strm.Write (delim, 0, 1)


let ReadCorporateAction (fldValIn:string) : CorporateAction = 
    match fldValIn with
    |"A" -> CorporateAction.ExDividend
    |"B" -> CorporateAction.ExDistribution
    |"C" -> CorporateAction.ExRights
    |"D" -> CorporateAction.New
    |"E" -> CorporateAction.ExInterest
    | x -> failwith (sprintf "ReadCorporateAction unknown fix tag: %A"  x) 


let WriteCorporateAction (strm:Stream) (xxIn:CorporateAction) =
    match xxIn with
    | CorporateAction.ExDividend -> strm.Write "292=A"B; strm.Write (delim, 0, 1)
    | CorporateAction.ExDistribution -> strm.Write "292=B"B; strm.Write (delim, 0, 1)
    | CorporateAction.ExRights -> strm.Write "292=C"B; strm.Write (delim, 0, 1)
    | CorporateAction.New -> strm.Write "292=D"B; strm.Write (delim, 0, 1)
    | CorporateAction.ExInterest -> strm.Write "292=E"B; strm.Write (delim, 0, 1)


let ReadDefBidSize valIn =
    let tmp = System.Decimal.Parse valIn
    DefBidSize.DefBidSize tmp


let WriteDefBidSize (strm:Stream) (valIn:DefBidSize) = 
    let tag = "293="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDefOfferSize valIn =
    let tmp = System.Decimal.Parse valIn
    DefOfferSize.DefOfferSize tmp


let WriteDefOfferSize (strm:Stream) (valIn:DefOfferSize) = 
    let tag = "294="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoQuoteEntries valIn =
    let tmp = System.Int32.Parse valIn
    NoQuoteEntries.NoQuoteEntries tmp


let WriteNoQuoteEntries (strm:Stream) (valIn:NoQuoteEntries) = 
    let tag = "295="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoQuoteSets valIn =
    let tmp = System.Int32.Parse valIn
    NoQuoteSets.NoQuoteSets tmp


let WriteNoQuoteSets (strm:Stream) (valIn:NoQuoteSets) = 
    let tag = "296="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuoteStatus (fldValIn:string) : QuoteStatus = 
    match fldValIn with
    |"0" -> QuoteStatus.Accepted
    |"1" -> QuoteStatus.CanceledForSymbol
    |"2" -> QuoteStatus.CanceledForSecurityType
    |"3" -> QuoteStatus.CanceledForUnderlying
    |"4" -> QuoteStatus.CanceledAll
    |"5" -> QuoteStatus.Rejected
    |"6" -> QuoteStatus.RemovedFromMarket
    |"7" -> QuoteStatus.Expired
    |"8" -> QuoteStatus.Query
    |"9" -> QuoteStatus.QuoteNotFound
    |"10" -> QuoteStatus.Pending
    |"11" -> QuoteStatus.Pass
    |"12" -> QuoteStatus.LockedMarketWarning
    |"13" -> QuoteStatus.CrossMarketWarning
    |"14" -> QuoteStatus.CanceledDueToLockMarket
    |"15" -> QuoteStatus.CanceledDueToCrossMarket
    | x -> failwith (sprintf "ReadQuoteStatus unknown fix tag: %A"  x) 


let WriteQuoteStatus (strm:Stream) (xxIn:QuoteStatus) =
    match xxIn with
    | QuoteStatus.Accepted -> strm.Write "297=0"B; strm.Write (delim, 0, 1)
    | QuoteStatus.CanceledForSymbol -> strm.Write "297=1"B; strm.Write (delim, 0, 1)
    | QuoteStatus.CanceledForSecurityType -> strm.Write "297=2"B; strm.Write (delim, 0, 1)
    | QuoteStatus.CanceledForUnderlying -> strm.Write "297=3"B; strm.Write (delim, 0, 1)
    | QuoteStatus.CanceledAll -> strm.Write "297=4"B; strm.Write (delim, 0, 1)
    | QuoteStatus.Rejected -> strm.Write "297=5"B; strm.Write (delim, 0, 1)
    | QuoteStatus.RemovedFromMarket -> strm.Write "297=6"B; strm.Write (delim, 0, 1)
    | QuoteStatus.Expired -> strm.Write "297=7"B; strm.Write (delim, 0, 1)
    | QuoteStatus.Query -> strm.Write "297=8"B; strm.Write (delim, 0, 1)
    | QuoteStatus.QuoteNotFound -> strm.Write "297=9"B; strm.Write (delim, 0, 1)
    | QuoteStatus.Pending -> strm.Write "297=10"B; strm.Write (delim, 0, 1)
    | QuoteStatus.Pass -> strm.Write "297=11"B; strm.Write (delim, 0, 1)
    | QuoteStatus.LockedMarketWarning -> strm.Write "297=12"B; strm.Write (delim, 0, 1)
    | QuoteStatus.CrossMarketWarning -> strm.Write "297=13"B; strm.Write (delim, 0, 1)
    | QuoteStatus.CanceledDueToLockMarket -> strm.Write "297=14"B; strm.Write (delim, 0, 1)
    | QuoteStatus.CanceledDueToCrossMarket -> strm.Write "297=15"B; strm.Write (delim, 0, 1)


let ReadQuoteCancelType (fldValIn:string) : QuoteCancelType = 
    match fldValIn with
    |"1" -> QuoteCancelType.CancelForSymbol
    |"2" -> QuoteCancelType.CancelForSecurityType
    |"3" -> QuoteCancelType.CancelForUnderlyingSymbol
    |"4" -> QuoteCancelType.CancelAllQuotes
    | x -> failwith (sprintf "ReadQuoteCancelType unknown fix tag: %A"  x) 


let WriteQuoteCancelType (strm:Stream) (xxIn:QuoteCancelType) =
    match xxIn with
    | QuoteCancelType.CancelForSymbol -> strm.Write "298=1"B; strm.Write (delim, 0, 1)
    | QuoteCancelType.CancelForSecurityType -> strm.Write "298=2"B; strm.Write (delim, 0, 1)
    | QuoteCancelType.CancelForUnderlyingSymbol -> strm.Write "298=3"B; strm.Write (delim, 0, 1)
    | QuoteCancelType.CancelAllQuotes -> strm.Write "298=4"B; strm.Write (delim, 0, 1)


let ReadQuoteEntryID valIn =
    let tmp =  valIn
    QuoteEntryID.QuoteEntryID tmp


let WriteQuoteEntryID (strm:Stream) (valIn:QuoteEntryID) = 
    let tag = "299="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuoteRejectReason (fldValIn:string) : QuoteRejectReason = 
    match fldValIn with
    |"1" -> QuoteRejectReason.UnknownSymbol
    |"2" -> QuoteRejectReason.ExchangeClosed
    |"3" -> QuoteRejectReason.QuoteRequestExceedsLimit
    |"4" -> QuoteRejectReason.TooLateToEnter
    |"5" -> QuoteRejectReason.UnknownQuote
    |"6" -> QuoteRejectReason.DuplicateQuote
    |"7" -> QuoteRejectReason.InvalidBidAskSpread
    |"8" -> QuoteRejectReason.InvalidPrice
    |"9" -> QuoteRejectReason.NotAuthorizedToQuoteSecurity
    |"99" -> QuoteRejectReason.Other
    | x -> failwith (sprintf "ReadQuoteRejectReason unknown fix tag: %A"  x) 


let WriteQuoteRejectReason (strm:Stream) (xxIn:QuoteRejectReason) =
    match xxIn with
    | QuoteRejectReason.UnknownSymbol -> strm.Write "300=1"B; strm.Write (delim, 0, 1)
    | QuoteRejectReason.ExchangeClosed -> strm.Write "300=2"B; strm.Write (delim, 0, 1)
    | QuoteRejectReason.QuoteRequestExceedsLimit -> strm.Write "300=3"B; strm.Write (delim, 0, 1)
    | QuoteRejectReason.TooLateToEnter -> strm.Write "300=4"B; strm.Write (delim, 0, 1)
    | QuoteRejectReason.UnknownQuote -> strm.Write "300=5"B; strm.Write (delim, 0, 1)
    | QuoteRejectReason.DuplicateQuote -> strm.Write "300=6"B; strm.Write (delim, 0, 1)
    | QuoteRejectReason.InvalidBidAskSpread -> strm.Write "300=7"B; strm.Write (delim, 0, 1)
    | QuoteRejectReason.InvalidPrice -> strm.Write "300=8"B; strm.Write (delim, 0, 1)
    | QuoteRejectReason.NotAuthorizedToQuoteSecurity -> strm.Write "300=9"B; strm.Write (delim, 0, 1)
    | QuoteRejectReason.Other -> strm.Write "300=99"B; strm.Write (delim, 0, 1)


let ReadQuoteResponseLevel (fldValIn:string) : QuoteResponseLevel = 
    match fldValIn with
    |"0" -> QuoteResponseLevel.NoAcknowledgement
    |"1" -> QuoteResponseLevel.AcknowledgeOnlyNegativeOrErroneousQuotes
    |"2" -> QuoteResponseLevel.AcknowledgeEachQuoteMessages
    | x -> failwith (sprintf "ReadQuoteResponseLevel unknown fix tag: %A"  x) 


let WriteQuoteResponseLevel (strm:Stream) (xxIn:QuoteResponseLevel) =
    match xxIn with
    | QuoteResponseLevel.NoAcknowledgement -> strm.Write "301=0"B; strm.Write (delim, 0, 1)
    | QuoteResponseLevel.AcknowledgeOnlyNegativeOrErroneousQuotes -> strm.Write "301=1"B; strm.Write (delim, 0, 1)
    | QuoteResponseLevel.AcknowledgeEachQuoteMessages -> strm.Write "301=2"B; strm.Write (delim, 0, 1)


let ReadQuoteSetID valIn =
    let tmp =  valIn
    QuoteSetID.QuoteSetID tmp


let WriteQuoteSetID (strm:Stream) (valIn:QuoteSetID) = 
    let tag = "302="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuoteRequestType (fldValIn:string) : QuoteRequestType = 
    match fldValIn with
    |"1" -> QuoteRequestType.Manual
    |"2" -> QuoteRequestType.Automatic
    | x -> failwith (sprintf "ReadQuoteRequestType unknown fix tag: %A"  x) 


let WriteQuoteRequestType (strm:Stream) (xxIn:QuoteRequestType) =
    match xxIn with
    | QuoteRequestType.Manual -> strm.Write "303=1"B; strm.Write (delim, 0, 1)
    | QuoteRequestType.Automatic -> strm.Write "303=2"B; strm.Write (delim, 0, 1)


let ReadTotNoQuoteEntries valIn =
    let tmp = System.Int32.Parse valIn
    TotNoQuoteEntries.TotNoQuoteEntries tmp


let WriteTotNoQuoteEntries (strm:Stream) (valIn:TotNoQuoteEntries) = 
    let tag = "304="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingSecurityIDSource valIn =
    let tmp =  valIn
    UnderlyingSecurityIDSource.UnderlyingSecurityIDSource tmp


let WriteUnderlyingSecurityIDSource (strm:Stream) (valIn:UnderlyingSecurityIDSource) = 
    let tag = "305="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingIssuer valIn =
    let tmp =  valIn
    UnderlyingIssuer.UnderlyingIssuer tmp


let WriteUnderlyingIssuer (strm:Stream) (valIn:UnderlyingIssuer) = 
    let tag = "306="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingSecurityDesc valIn =
    let tmp =  valIn
    UnderlyingSecurityDesc.UnderlyingSecurityDesc tmp


let WriteUnderlyingSecurityDesc (strm:Stream) (valIn:UnderlyingSecurityDesc) = 
    let tag = "307="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingSecurityExchange valIn =
    let tmp =  valIn
    UnderlyingSecurityExchange.UnderlyingSecurityExchange tmp


let WriteUnderlyingSecurityExchange (strm:Stream) (valIn:UnderlyingSecurityExchange) = 
    let tag = "308="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingSecurityID valIn =
    let tmp =  valIn
    UnderlyingSecurityID.UnderlyingSecurityID tmp


let WriteUnderlyingSecurityID (strm:Stream) (valIn:UnderlyingSecurityID) = 
    let tag = "309="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingSecurityType valIn =
    let tmp =  valIn
    UnderlyingSecurityType.UnderlyingSecurityType tmp


let WriteUnderlyingSecurityType (strm:Stream) (valIn:UnderlyingSecurityType) = 
    let tag = "310="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingSymbol valIn =
    let tmp =  valIn
    UnderlyingSymbol.UnderlyingSymbol tmp


let WriteUnderlyingSymbol (strm:Stream) (valIn:UnderlyingSymbol) = 
    let tag = "311="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingSymbolSfx valIn =
    let tmp =  valIn
    UnderlyingSymbolSfx.UnderlyingSymbolSfx tmp


let WriteUnderlyingSymbolSfx (strm:Stream) (valIn:UnderlyingSymbolSfx) = 
    let tag = "312="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingMaturityMonthYear valIn =
    let tmp =  valIn
    UnderlyingMaturityMonthYear.UnderlyingMaturityMonthYear tmp


let WriteUnderlyingMaturityMonthYear (strm:Stream) (valIn:UnderlyingMaturityMonthYear) = 
    let tag = "313="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingPutOrCall (fldValIn:string) : UnderlyingPutOrCall = 
    match fldValIn with
    |"0" -> UnderlyingPutOrCall.Put
    |"1" -> UnderlyingPutOrCall.Call
    | x -> failwith (sprintf "ReadUnderlyingPutOrCall unknown fix tag: %A"  x) 


let WriteUnderlyingPutOrCall (strm:Stream) (xxIn:UnderlyingPutOrCall) =
    match xxIn with
    | UnderlyingPutOrCall.Put -> strm.Write "315=0"B; strm.Write (delim, 0, 1)
    | UnderlyingPutOrCall.Call -> strm.Write "315=1"B; strm.Write (delim, 0, 1)


let ReadUnderlyingStrikePrice valIn =
    let tmp = System.Decimal.Parse valIn
    UnderlyingStrikePrice.UnderlyingStrikePrice tmp


let WriteUnderlyingStrikePrice (strm:Stream) (valIn:UnderlyingStrikePrice) = 
    let tag = "316="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingOptAttribute valIn =
    let tmp = System.Int32.Parse valIn
    UnderlyingOptAttribute.UnderlyingOptAttribute tmp


let WriteUnderlyingOptAttribute (strm:Stream) (valIn:UnderlyingOptAttribute) = 
    let tag = "317="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingCurrency valIn =
    let tmp =  valIn
    UnderlyingCurrency.UnderlyingCurrency tmp


let WriteUnderlyingCurrency (strm:Stream) (valIn:UnderlyingCurrency) = 
    let tag = "318="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecurityReqID valIn =
    let tmp =  valIn
    SecurityReqID.SecurityReqID tmp


let WriteSecurityReqID (strm:Stream) (valIn:SecurityReqID) = 
    let tag = "320="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecurityRequestType (fldValIn:string) : SecurityRequestType = 
    match fldValIn with
    |"0" -> SecurityRequestType.RequestSecurityIdentityAndSpecifications
    |"1" -> SecurityRequestType.RequestSecurityIdentityForTheSpecificationsProvided
    |"2" -> SecurityRequestType.RequestListSecurityTypes
    |"3" -> SecurityRequestType.RequestListSecurities
    | x -> failwith (sprintf "ReadSecurityRequestType unknown fix tag: %A"  x) 


let WriteSecurityRequestType (strm:Stream) (xxIn:SecurityRequestType) =
    match xxIn with
    | SecurityRequestType.RequestSecurityIdentityAndSpecifications -> strm.Write "321=0"B; strm.Write (delim, 0, 1)
    | SecurityRequestType.RequestSecurityIdentityForTheSpecificationsProvided -> strm.Write "321=1"B; strm.Write (delim, 0, 1)
    | SecurityRequestType.RequestListSecurityTypes -> strm.Write "321=2"B; strm.Write (delim, 0, 1)
    | SecurityRequestType.RequestListSecurities -> strm.Write "321=3"B; strm.Write (delim, 0, 1)


let ReadSecurityResponseID valIn =
    let tmp =  valIn
    SecurityResponseID.SecurityResponseID tmp


let WriteSecurityResponseID (strm:Stream) (valIn:SecurityResponseID) = 
    let tag = "322="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecurityResponseType (fldValIn:string) : SecurityResponseType = 
    match fldValIn with
    |"1" -> SecurityResponseType.AcceptSecurityProposalAsIs
    |"2" -> SecurityResponseType.AcceptSecurityProposalWithRevisionsAsIndicatedInTheMessage
    |"3" -> SecurityResponseType.ListOfSecurityTypesReturnedPerRequest
    |"4" -> SecurityResponseType.ListOfSecuritiesReturnedPerRequest
    |"5" -> SecurityResponseType.RejectSecurityProposal
    |"6" -> SecurityResponseType.CanNotMatchSelectionCriteria
    | x -> failwith (sprintf "ReadSecurityResponseType unknown fix tag: %A"  x) 


let WriteSecurityResponseType (strm:Stream) (xxIn:SecurityResponseType) =
    match xxIn with
    | SecurityResponseType.AcceptSecurityProposalAsIs -> strm.Write "323=1"B; strm.Write (delim, 0, 1)
    | SecurityResponseType.AcceptSecurityProposalWithRevisionsAsIndicatedInTheMessage -> strm.Write "323=2"B; strm.Write (delim, 0, 1)
    | SecurityResponseType.ListOfSecurityTypesReturnedPerRequest -> strm.Write "323=3"B; strm.Write (delim, 0, 1)
    | SecurityResponseType.ListOfSecuritiesReturnedPerRequest -> strm.Write "323=4"B; strm.Write (delim, 0, 1)
    | SecurityResponseType.RejectSecurityProposal -> strm.Write "323=5"B; strm.Write (delim, 0, 1)
    | SecurityResponseType.CanNotMatchSelectionCriteria -> strm.Write "323=6"B; strm.Write (delim, 0, 1)


let ReadSecurityStatusReqID valIn =
    let tmp =  valIn
    SecurityStatusReqID.SecurityStatusReqID tmp


let WriteSecurityStatusReqID (strm:Stream) (valIn:SecurityStatusReqID) = 
    let tag = "324="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnsolicitedIndicator valIn =
    let tmp = System.Boolean.Parse valIn
    UnsolicitedIndicator.UnsolicitedIndicator tmp


let WriteUnsolicitedIndicator (strm:Stream) (valIn:UnsolicitedIndicator) = 
    let tag = "325="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecurityTradingStatus (fldValIn:string) : SecurityTradingStatus = 
    match fldValIn with
    |"1" -> SecurityTradingStatus.OpeningDelay
    |"2" -> SecurityTradingStatus.TradingHalt
    |"3" -> SecurityTradingStatus.Resume
    |"4" -> SecurityTradingStatus.NoOpenNoResume
    |"5" -> SecurityTradingStatus.PriceIndication
    |"6" -> SecurityTradingStatus.TradingRangeIndication
    |"7" -> SecurityTradingStatus.MarketImbalanceBuy
    |"8" -> SecurityTradingStatus.MarketImbalanceSell
    |"9" -> SecurityTradingStatus.MarketOnCloseImbalanceBuy
    |"10" -> SecurityTradingStatus.MarketOnCloseImbalanceSell
    |"11" -> SecurityTradingStatus.NotAssigned
    |"12" -> SecurityTradingStatus.NoMarketImbalance
    |"13" -> SecurityTradingStatus.NoMarketOnCloseImbalance
    |"14" -> SecurityTradingStatus.ItsPreOpening
    |"15" -> SecurityTradingStatus.NewPriceIndication
    |"16" -> SecurityTradingStatus.TradeDisseminationTime
    |"17" -> SecurityTradingStatus.ReadyToTradeStartOfSession
    |"18" -> SecurityTradingStatus.NotAvailableForTradingEndOfSession
    |"19" -> SecurityTradingStatus.NotTradedOnThisMarket
    |"20" -> SecurityTradingStatus.UnknownOrInvalid
    |"21" -> SecurityTradingStatus.PreOpen
    |"22" -> SecurityTradingStatus.OpeningRotation
    |"23" -> SecurityTradingStatus.FastMarket
    | x -> failwith (sprintf "ReadSecurityTradingStatus unknown fix tag: %A"  x) 


let WriteSecurityTradingStatus (strm:Stream) (xxIn:SecurityTradingStatus) =
    match xxIn with
    | SecurityTradingStatus.OpeningDelay -> strm.Write "326=1"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.TradingHalt -> strm.Write "326=2"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.Resume -> strm.Write "326=3"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.NoOpenNoResume -> strm.Write "326=4"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.PriceIndication -> strm.Write "326=5"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.TradingRangeIndication -> strm.Write "326=6"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.MarketImbalanceBuy -> strm.Write "326=7"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.MarketImbalanceSell -> strm.Write "326=8"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.MarketOnCloseImbalanceBuy -> strm.Write "326=9"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.MarketOnCloseImbalanceSell -> strm.Write "326=10"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.NotAssigned -> strm.Write "326=11"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.NoMarketImbalance -> strm.Write "326=12"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.NoMarketOnCloseImbalance -> strm.Write "326=13"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.ItsPreOpening -> strm.Write "326=14"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.NewPriceIndication -> strm.Write "326=15"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.TradeDisseminationTime -> strm.Write "326=16"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.ReadyToTradeStartOfSession -> strm.Write "326=17"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.NotAvailableForTradingEndOfSession -> strm.Write "326=18"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.NotTradedOnThisMarket -> strm.Write "326=19"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.UnknownOrInvalid -> strm.Write "326=20"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.PreOpen -> strm.Write "326=21"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.OpeningRotation -> strm.Write "326=22"B; strm.Write (delim, 0, 1)
    | SecurityTradingStatus.FastMarket -> strm.Write "326=23"B; strm.Write (delim, 0, 1)


let ReadHaltReason (fldValIn:string) : HaltReason = 
    match fldValIn with
    |"I" -> HaltReason.OrderImbalance
    |"X" -> HaltReason.EquipmentChangeover
    |"P" -> HaltReason.NewsPending
    |"D" -> HaltReason.NewsDissemination
    |"E" -> HaltReason.OrderInflux
    |"M" -> HaltReason.AdditionalInformation
    | x -> failwith (sprintf "ReadHaltReason unknown fix tag: %A"  x) 


let WriteHaltReason (strm:Stream) (xxIn:HaltReason) =
    match xxIn with
    | HaltReason.OrderImbalance -> strm.Write "327=I"B; strm.Write (delim, 0, 1)
    | HaltReason.EquipmentChangeover -> strm.Write "327=X"B; strm.Write (delim, 0, 1)
    | HaltReason.NewsPending -> strm.Write "327=P"B; strm.Write (delim, 0, 1)
    | HaltReason.NewsDissemination -> strm.Write "327=D"B; strm.Write (delim, 0, 1)
    | HaltReason.OrderInflux -> strm.Write "327=E"B; strm.Write (delim, 0, 1)
    | HaltReason.AdditionalInformation -> strm.Write "327=M"B; strm.Write (delim, 0, 1)


let ReadInViewOfCommon valIn =
    let tmp = System.Boolean.Parse valIn
    InViewOfCommon.InViewOfCommon tmp


let WriteInViewOfCommon (strm:Stream) (valIn:InViewOfCommon) = 
    let tag = "328="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDueToRelated valIn =
    let tmp = System.Boolean.Parse valIn
    DueToRelated.DueToRelated tmp


let WriteDueToRelated (strm:Stream) (valIn:DueToRelated) = 
    let tag = "329="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBuyVolume valIn =
    let tmp = System.Decimal.Parse valIn
    BuyVolume.BuyVolume tmp


let WriteBuyVolume (strm:Stream) (valIn:BuyVolume) = 
    let tag = "330="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSellVolume valIn =
    let tmp = System.Decimal.Parse valIn
    SellVolume.SellVolume tmp


let WriteSellVolume (strm:Stream) (valIn:SellVolume) = 
    let tag = "331="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadHighPx valIn =
    let tmp = System.Decimal.Parse valIn
    HighPx.HighPx tmp


let WriteHighPx (strm:Stream) (valIn:HighPx) = 
    let tag = "332="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLowPx valIn =
    let tmp = System.Decimal.Parse valIn
    LowPx.LowPx tmp


let WriteLowPx (strm:Stream) (valIn:LowPx) = 
    let tag = "333="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAdjustment (fldValIn:string) : Adjustment = 
    match fldValIn with
    |"1" -> Adjustment.Cancel
    |"2" -> Adjustment.Error
    |"3" -> Adjustment.Correction
    | x -> failwith (sprintf "ReadAdjustment unknown fix tag: %A"  x) 


let WriteAdjustment (strm:Stream) (xxIn:Adjustment) =
    match xxIn with
    | Adjustment.Cancel -> strm.Write "334=1"B; strm.Write (delim, 0, 1)
    | Adjustment.Error -> strm.Write "334=2"B; strm.Write (delim, 0, 1)
    | Adjustment.Correction -> strm.Write "334=3"B; strm.Write (delim, 0, 1)


let ReadTradSesReqID valIn =
    let tmp =  valIn
    TradSesReqID.TradSesReqID tmp


let WriteTradSesReqID (strm:Stream) (valIn:TradSesReqID) = 
    let tag = "335="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradingSessionID valIn =
    let tmp =  valIn
    TradingSessionID.TradingSessionID tmp


let WriteTradingSessionID (strm:Stream) (valIn:TradingSessionID) = 
    let tag = "336="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadContraTrader valIn =
    let tmp =  valIn
    ContraTrader.ContraTrader tmp


let WriteContraTrader (strm:Stream) (valIn:ContraTrader) = 
    let tag = "337="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradSesMethod (fldValIn:string) : TradSesMethod = 
    match fldValIn with
    |"1" -> TradSesMethod.Electronic
    |"2" -> TradSesMethod.OpenOutcry
    |"3" -> TradSesMethod.TwoParty
    | x -> failwith (sprintf "ReadTradSesMethod unknown fix tag: %A"  x) 


let WriteTradSesMethod (strm:Stream) (xxIn:TradSesMethod) =
    match xxIn with
    | TradSesMethod.Electronic -> strm.Write "338=1"B; strm.Write (delim, 0, 1)
    | TradSesMethod.OpenOutcry -> strm.Write "338=2"B; strm.Write (delim, 0, 1)
    | TradSesMethod.TwoParty -> strm.Write "338=3"B; strm.Write (delim, 0, 1)


let ReadTradSesMode (fldValIn:string) : TradSesMode = 
    match fldValIn with
    |"1" -> TradSesMode.Testing
    |"2" -> TradSesMode.Simulated
    |"3" -> TradSesMode.Production
    | x -> failwith (sprintf "ReadTradSesMode unknown fix tag: %A"  x) 


let WriteTradSesMode (strm:Stream) (xxIn:TradSesMode) =
    match xxIn with
    | TradSesMode.Testing -> strm.Write "339=1"B; strm.Write (delim, 0, 1)
    | TradSesMode.Simulated -> strm.Write "339=2"B; strm.Write (delim, 0, 1)
    | TradSesMode.Production -> strm.Write "339=3"B; strm.Write (delim, 0, 1)


let ReadTradSesStatus (fldValIn:string) : TradSesStatus = 
    match fldValIn with
    |"0" -> TradSesStatus.Unknown
    |"1" -> TradSesStatus.Halted
    |"2" -> TradSesStatus.Open
    |"3" -> TradSesStatus.Closed
    |"4" -> TradSesStatus.PreOpen
    |"5" -> TradSesStatus.PreClose
    |"6" -> TradSesStatus.RequestRejected
    | x -> failwith (sprintf "ReadTradSesStatus unknown fix tag: %A"  x) 


let WriteTradSesStatus (strm:Stream) (xxIn:TradSesStatus) =
    match xxIn with
    | TradSesStatus.Unknown -> strm.Write "340=0"B; strm.Write (delim, 0, 1)
    | TradSesStatus.Halted -> strm.Write "340=1"B; strm.Write (delim, 0, 1)
    | TradSesStatus.Open -> strm.Write "340=2"B; strm.Write (delim, 0, 1)
    | TradSesStatus.Closed -> strm.Write "340=3"B; strm.Write (delim, 0, 1)
    | TradSesStatus.PreOpen -> strm.Write "340=4"B; strm.Write (delim, 0, 1)
    | TradSesStatus.PreClose -> strm.Write "340=5"B; strm.Write (delim, 0, 1)
    | TradSesStatus.RequestRejected -> strm.Write "340=6"B; strm.Write (delim, 0, 1)


let ReadTradSesStartTime valIn =
    let tmp =  valIn
    TradSesStartTime.TradSesStartTime tmp


let WriteTradSesStartTime (strm:Stream) (valIn:TradSesStartTime) = 
    let tag = "341="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradSesOpenTime valIn =
    let tmp =  valIn
    TradSesOpenTime.TradSesOpenTime tmp


let WriteTradSesOpenTime (strm:Stream) (valIn:TradSesOpenTime) = 
    let tag = "342="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradSesPreCloseTime valIn =
    let tmp =  valIn
    TradSesPreCloseTime.TradSesPreCloseTime tmp


let WriteTradSesPreCloseTime (strm:Stream) (valIn:TradSesPreCloseTime) = 
    let tag = "343="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradSesCloseTime valIn =
    let tmp =  valIn
    TradSesCloseTime.TradSesCloseTime tmp


let WriteTradSesCloseTime (strm:Stream) (valIn:TradSesCloseTime) = 
    let tag = "344="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradSesEndTime valIn =
    let tmp =  valIn
    TradSesEndTime.TradSesEndTime tmp


let WriteTradSesEndTime (strm:Stream) (valIn:TradSesEndTime) = 
    let tag = "345="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNumberOfOrders valIn =
    let tmp = System.Int32.Parse valIn
    NumberOfOrders.NumberOfOrders tmp


let WriteNumberOfOrders (strm:Stream) (valIn:NumberOfOrders) = 
    let tag = "346="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMessageEncoding (fldValIn:string) : MessageEncoding = 
    match fldValIn with
    |"ISO-2022-JP" -> MessageEncoding.Iso2022Jp
    |"EUC-JP" -> MessageEncoding.EucJp
    |"SHIFT_JIS" -> MessageEncoding.ShiftJis
    |"UTF-8" -> MessageEncoding.Utf8
    | x -> failwith (sprintf "ReadMessageEncoding unknown fix tag: %A"  x) 


let WriteMessageEncoding (strm:Stream) (xxIn:MessageEncoding) =
    match xxIn with
    | MessageEncoding.Iso2022Jp -> strm.Write "347=ISO-2022-JP"B; strm.Write (delim, 0, 1)
    | MessageEncoding.EucJp -> strm.Write "347=EUC-JP"B; strm.Write (delim, 0, 1)
    | MessageEncoding.ShiftJis -> strm.Write "347=SHIFT_JIS"B; strm.Write (delim, 0, 1)
    | MessageEncoding.Utf8 -> strm.Write "347=UTF-8"B; strm.Write (delim, 0, 1)


// compound write
let WriteEncodedIssuer (strm:System.IO.Stream) (fld:EncodedIssuer) =
    let lenTag = "348="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "349="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadEncodedIssuer valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "349" then failwith "invalid tag reading EncodedIssuer"
    if strLen <> raw.Length then failwith "mismatched string len reading EncodedIssuer"
    EncodedIssuer.EncodedIssuer raw


// compound write
let WriteEncodedSecurityDesc (strm:System.IO.Stream) (fld:EncodedSecurityDesc) =
    let lenTag = "350="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "351="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadEncodedSecurityDesc valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "351" then failwith "invalid tag reading EncodedSecurityDesc"
    if strLen <> raw.Length then failwith "mismatched string len reading EncodedSecurityDesc"
    EncodedSecurityDesc.EncodedSecurityDesc raw


// compound write
let WriteEncodedListExecInst (strm:System.IO.Stream) (fld:EncodedListExecInst) =
    let lenTag = "352="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "353="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadEncodedListExecInst valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "353" then failwith "invalid tag reading EncodedListExecInst"
    if strLen <> raw.Length then failwith "mismatched string len reading EncodedListExecInst"
    EncodedListExecInst.EncodedListExecInst raw


// compound write
let WriteEncodedText (strm:System.IO.Stream) (fld:EncodedText) =
    let lenTag = "354="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "355="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadEncodedText valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "355" then failwith "invalid tag reading EncodedText"
    if strLen <> raw.Length then failwith "mismatched string len reading EncodedText"
    EncodedText.EncodedText raw


// compound write
let WriteEncodedSubject (strm:System.IO.Stream) (fld:EncodedSubject) =
    let lenTag = "356="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "357="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadEncodedSubject valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "357" then failwith "invalid tag reading EncodedSubject"
    if strLen <> raw.Length then failwith "mismatched string len reading EncodedSubject"
    EncodedSubject.EncodedSubject raw


// compound write
let WriteEncodedHeadline (strm:System.IO.Stream) (fld:EncodedHeadline) =
    let lenTag = "358="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "359="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadEncodedHeadline valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "359" then failwith "invalid tag reading EncodedHeadline"
    if strLen <> raw.Length then failwith "mismatched string len reading EncodedHeadline"
    EncodedHeadline.EncodedHeadline raw


// compound write
let WriteEncodedAllocText (strm:System.IO.Stream) (fld:EncodedAllocText) =
    let lenTag = "360="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "361="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadEncodedAllocText valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "361" then failwith "invalid tag reading EncodedAllocText"
    if strLen <> raw.Length then failwith "mismatched string len reading EncodedAllocText"
    EncodedAllocText.EncodedAllocText raw


// compound write
let WriteEncodedUnderlyingIssuer (strm:System.IO.Stream) (fld:EncodedUnderlyingIssuer) =
    let lenTag = "362="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "363="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadEncodedUnderlyingIssuer valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "363" then failwith "invalid tag reading EncodedUnderlyingIssuer"
    if strLen <> raw.Length then failwith "mismatched string len reading EncodedUnderlyingIssuer"
    EncodedUnderlyingIssuer.EncodedUnderlyingIssuer raw


// compound write
let WriteEncodedUnderlyingSecurityDesc (strm:System.IO.Stream) (fld:EncodedUnderlyingSecurityDesc) =
    let lenTag = "364="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "365="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadEncodedUnderlyingSecurityDesc valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "365" then failwith "invalid tag reading EncodedUnderlyingSecurityDesc"
    if strLen <> raw.Length then failwith "mismatched string len reading EncodedUnderlyingSecurityDesc"
    EncodedUnderlyingSecurityDesc.EncodedUnderlyingSecurityDesc raw


let ReadAllocPrice valIn =
    let tmp = System.Decimal.Parse valIn
    AllocPrice.AllocPrice tmp


let WriteAllocPrice (strm:Stream) (valIn:AllocPrice) = 
    let tag = "366="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuoteSetValidUntilTime valIn =
    let tmp =  valIn
    QuoteSetValidUntilTime.QuoteSetValidUntilTime tmp


let WriteQuoteSetValidUntilTime (strm:Stream) (valIn:QuoteSetValidUntilTime) = 
    let tag = "367="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuoteEntryRejectReason (fldValIn:string) : QuoteEntryRejectReason = 
    match fldValIn with
    |"1" -> QuoteEntryRejectReason.UnknownSymbol
    |"2" -> QuoteEntryRejectReason.ExchangeClosed
    |"3" -> QuoteEntryRejectReason.QuoteExceedsLimit
    |"4" -> QuoteEntryRejectReason.TooLateToEnter
    |"5" -> QuoteEntryRejectReason.UnknownQuote
    |"6" -> QuoteEntryRejectReason.DuplicateQuote
    |"7" -> QuoteEntryRejectReason.InvalidBidAskSpread
    |"8" -> QuoteEntryRejectReason.InvalidPrice
    |"9" -> QuoteEntryRejectReason.NotAuthorizedToQuoteSecurity
    | x -> failwith (sprintf "ReadQuoteEntryRejectReason unknown fix tag: %A"  x) 


let WriteQuoteEntryRejectReason (strm:Stream) (xxIn:QuoteEntryRejectReason) =
    match xxIn with
    | QuoteEntryRejectReason.UnknownSymbol -> strm.Write "368=1"B; strm.Write (delim, 0, 1)
    | QuoteEntryRejectReason.ExchangeClosed -> strm.Write "368=2"B; strm.Write (delim, 0, 1)
    | QuoteEntryRejectReason.QuoteExceedsLimit -> strm.Write "368=3"B; strm.Write (delim, 0, 1)
    | QuoteEntryRejectReason.TooLateToEnter -> strm.Write "368=4"B; strm.Write (delim, 0, 1)
    | QuoteEntryRejectReason.UnknownQuote -> strm.Write "368=5"B; strm.Write (delim, 0, 1)
    | QuoteEntryRejectReason.DuplicateQuote -> strm.Write "368=6"B; strm.Write (delim, 0, 1)
    | QuoteEntryRejectReason.InvalidBidAskSpread -> strm.Write "368=7"B; strm.Write (delim, 0, 1)
    | QuoteEntryRejectReason.InvalidPrice -> strm.Write "368=8"B; strm.Write (delim, 0, 1)
    | QuoteEntryRejectReason.NotAuthorizedToQuoteSecurity -> strm.Write "368=9"B; strm.Write (delim, 0, 1)


let ReadLastMsgSeqNumProcessed valIn =
    let tmp = System.Int32.Parse valIn
    LastMsgSeqNumProcessed.LastMsgSeqNumProcessed tmp


let WriteLastMsgSeqNumProcessed (strm:Stream) (valIn:LastMsgSeqNumProcessed) = 
    let tag = "369="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRefTagID valIn =
    let tmp = System.Int32.Parse valIn
    RefTagID.RefTagID tmp


let WriteRefTagID (strm:Stream) (valIn:RefTagID) = 
    let tag = "371="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRefMsgType valIn =
    let tmp =  valIn
    RefMsgType.RefMsgType tmp


let WriteRefMsgType (strm:Stream) (valIn:RefMsgType) = 
    let tag = "372="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSessionRejectReason (fldValIn:string) : SessionRejectReason = 
    match fldValIn with
    |"0" -> SessionRejectReason.InvalidTagNumber
    |"1" -> SessionRejectReason.RequiredTagMissing
    |"2" -> SessionRejectReason.TagNotDefinedForThisMessageType
    |"3" -> SessionRejectReason.UndefinedTag
    |"4" -> SessionRejectReason.TagSpecifiedWithoutAValue
    |"5" -> SessionRejectReason.ValueIsIncorrect
    |"6" -> SessionRejectReason.IncorrectDataFormatForValue
    |"7" -> SessionRejectReason.DecryptionProblem
    |"8" -> SessionRejectReason.SignatureProblem
    |"9" -> SessionRejectReason.CompidProblem
    |"10" -> SessionRejectReason.SendingtimeAccuracyProblem
    |"11" -> SessionRejectReason.InvalidMsgtype
    |"12" -> SessionRejectReason.XmlValidationError
    |"13" -> SessionRejectReason.TagAppearsMoreThanOnce
    |"14" -> SessionRejectReason.TagSpecifiedOutOfRequiredOrder
    |"15" -> SessionRejectReason.RepeatingGroupFieldsOutOfOrder
    |"16" -> SessionRejectReason.IncorrectNumingroupCountForRepeatingGroup
    |"17" -> SessionRejectReason.NonDataValueIncludesFieldDelimiter
    |"99" -> SessionRejectReason.Other
    | x -> failwith (sprintf "ReadSessionRejectReason unknown fix tag: %A"  x) 


let WriteSessionRejectReason (strm:Stream) (xxIn:SessionRejectReason) =
    match xxIn with
    | SessionRejectReason.InvalidTagNumber -> strm.Write "373=0"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.RequiredTagMissing -> strm.Write "373=1"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.TagNotDefinedForThisMessageType -> strm.Write "373=2"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.UndefinedTag -> strm.Write "373=3"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.TagSpecifiedWithoutAValue -> strm.Write "373=4"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.ValueIsIncorrect -> strm.Write "373=5"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.IncorrectDataFormatForValue -> strm.Write "373=6"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.DecryptionProblem -> strm.Write "373=7"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.SignatureProblem -> strm.Write "373=8"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.CompidProblem -> strm.Write "373=9"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.SendingtimeAccuracyProblem -> strm.Write "373=10"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.InvalidMsgtype -> strm.Write "373=11"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.XmlValidationError -> strm.Write "373=12"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.TagAppearsMoreThanOnce -> strm.Write "373=13"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.TagSpecifiedOutOfRequiredOrder -> strm.Write "373=14"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.RepeatingGroupFieldsOutOfOrder -> strm.Write "373=15"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.IncorrectNumingroupCountForRepeatingGroup -> strm.Write "373=16"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.NonDataValueIncludesFieldDelimiter -> strm.Write "373=17"B; strm.Write (delim, 0, 1)
    | SessionRejectReason.Other -> strm.Write "373=99"B; strm.Write (delim, 0, 1)


let ReadBidRequestTransType (fldValIn:string) : BidRequestTransType = 
    match fldValIn with
    |"N" -> BidRequestTransType.New
    |"C" -> BidRequestTransType.Cancel
    | x -> failwith (sprintf "ReadBidRequestTransType unknown fix tag: %A"  x) 


let WriteBidRequestTransType (strm:Stream) (xxIn:BidRequestTransType) =
    match xxIn with
    | BidRequestTransType.New -> strm.Write "374=N"B; strm.Write (delim, 0, 1)
    | BidRequestTransType.Cancel -> strm.Write "374=C"B; strm.Write (delim, 0, 1)


let ReadContraBroker valIn =
    let tmp =  valIn
    ContraBroker.ContraBroker tmp


let WriteContraBroker (strm:Stream) (valIn:ContraBroker) = 
    let tag = "375="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadComplianceID valIn =
    let tmp =  valIn
    ComplianceID.ComplianceID tmp


let WriteComplianceID (strm:Stream) (valIn:ComplianceID) = 
    let tag = "376="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSolicitedFlag valIn =
    let tmp = System.Boolean.Parse valIn
    SolicitedFlag.SolicitedFlag tmp


let WriteSolicitedFlag (strm:Stream) (valIn:SolicitedFlag) = 
    let tag = "377="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadExecRestatementReason (fldValIn:string) : ExecRestatementReason = 
    match fldValIn with
    |"0" -> ExecRestatementReason.GtCorporateAction
    |"1" -> ExecRestatementReason.GtRenewalRestatement
    |"2" -> ExecRestatementReason.VerbalChange
    |"3" -> ExecRestatementReason.RepricingOfOrder
    |"4" -> ExecRestatementReason.BrokerOption
    |"5" -> ExecRestatementReason.PartialDeclineOfOrderqty
    |"6" -> ExecRestatementReason.CancelOnTradingHalt
    |"7" -> ExecRestatementReason.CancelOnSystemFailure
    |"8" -> ExecRestatementReason.MarketOption
    |"9" -> ExecRestatementReason.CanceledNotBest
    | x -> failwith (sprintf "ReadExecRestatementReason unknown fix tag: %A"  x) 


let WriteExecRestatementReason (strm:Stream) (xxIn:ExecRestatementReason) =
    match xxIn with
    | ExecRestatementReason.GtCorporateAction -> strm.Write "378=0"B; strm.Write (delim, 0, 1)
    | ExecRestatementReason.GtRenewalRestatement -> strm.Write "378=1"B; strm.Write (delim, 0, 1)
    | ExecRestatementReason.VerbalChange -> strm.Write "378=2"B; strm.Write (delim, 0, 1)
    | ExecRestatementReason.RepricingOfOrder -> strm.Write "378=3"B; strm.Write (delim, 0, 1)
    | ExecRestatementReason.BrokerOption -> strm.Write "378=4"B; strm.Write (delim, 0, 1)
    | ExecRestatementReason.PartialDeclineOfOrderqty -> strm.Write "378=5"B; strm.Write (delim, 0, 1)
    | ExecRestatementReason.CancelOnTradingHalt -> strm.Write "378=6"B; strm.Write (delim, 0, 1)
    | ExecRestatementReason.CancelOnSystemFailure -> strm.Write "378=7"B; strm.Write (delim, 0, 1)
    | ExecRestatementReason.MarketOption -> strm.Write "378=8"B; strm.Write (delim, 0, 1)
    | ExecRestatementReason.CanceledNotBest -> strm.Write "378=9"B; strm.Write (delim, 0, 1)


let ReadBusinessRejectRefID valIn =
    let tmp =  valIn
    BusinessRejectRefID.BusinessRejectRefID tmp


let WriteBusinessRejectRefID (strm:Stream) (valIn:BusinessRejectRefID) = 
    let tag = "379="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBusinessRejectReason (fldValIn:string) : BusinessRejectReason = 
    match fldValIn with
    |"0" -> BusinessRejectReason.Other
    |"1" -> BusinessRejectReason.UnkownId
    |"2" -> BusinessRejectReason.UnknownSecurity
    |"3" -> BusinessRejectReason.UnsupportedMessageType
    |"4" -> BusinessRejectReason.ApplicationNotAvailable
    |"5" -> BusinessRejectReason.ConditionallyRequiredFieldMissing
    |"6" -> BusinessRejectReason.NotAuthorized
    |"7" -> BusinessRejectReason.DelivertoFirmNotAvailableAtThisTime
    | x -> failwith (sprintf "ReadBusinessRejectReason unknown fix tag: %A"  x) 


let WriteBusinessRejectReason (strm:Stream) (xxIn:BusinessRejectReason) =
    match xxIn with
    | BusinessRejectReason.Other -> strm.Write "380=0"B; strm.Write (delim, 0, 1)
    | BusinessRejectReason.UnkownId -> strm.Write "380=1"B; strm.Write (delim, 0, 1)
    | BusinessRejectReason.UnknownSecurity -> strm.Write "380=2"B; strm.Write (delim, 0, 1)
    | BusinessRejectReason.UnsupportedMessageType -> strm.Write "380=3"B; strm.Write (delim, 0, 1)
    | BusinessRejectReason.ApplicationNotAvailable -> strm.Write "380=4"B; strm.Write (delim, 0, 1)
    | BusinessRejectReason.ConditionallyRequiredFieldMissing -> strm.Write "380=5"B; strm.Write (delim, 0, 1)
    | BusinessRejectReason.NotAuthorized -> strm.Write "380=6"B; strm.Write (delim, 0, 1)
    | BusinessRejectReason.DelivertoFirmNotAvailableAtThisTime -> strm.Write "380=7"B; strm.Write (delim, 0, 1)


let ReadGrossTradeAmt valIn =
    let tmp = System.Int32.Parse valIn
    GrossTradeAmt.GrossTradeAmt tmp


let WriteGrossTradeAmt (strm:Stream) (valIn:GrossTradeAmt) = 
    let tag = "381="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoContraBrokers valIn =
    let tmp = System.Int32.Parse valIn
    NoContraBrokers.NoContraBrokers tmp


let WriteNoContraBrokers (strm:Stream) (valIn:NoContraBrokers) = 
    let tag = "382="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMaxMessageSize valIn =
    let tmp = System.Int32.Parse valIn
    MaxMessageSize.MaxMessageSize tmp


let WriteMaxMessageSize (strm:Stream) (valIn:MaxMessageSize) = 
    let tag = "383="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoMsgTypes valIn =
    let tmp = System.Int32.Parse valIn
    NoMsgTypes.NoMsgTypes tmp


let WriteNoMsgTypes (strm:Stream) (valIn:NoMsgTypes) = 
    let tag = "384="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMsgDirection (fldValIn:string) : MsgDirection = 
    match fldValIn with
    |"S" -> MsgDirection.Send
    |"R" -> MsgDirection.Receive
    | x -> failwith (sprintf "ReadMsgDirection unknown fix tag: %A"  x) 


let WriteMsgDirection (strm:Stream) (xxIn:MsgDirection) =
    match xxIn with
    | MsgDirection.Send -> strm.Write "385=S"B; strm.Write (delim, 0, 1)
    | MsgDirection.Receive -> strm.Write "385=R"B; strm.Write (delim, 0, 1)


let ReadNoTradingSessions valIn =
    let tmp = System.Int32.Parse valIn
    NoTradingSessions.NoTradingSessions tmp


let WriteNoTradingSessions (strm:Stream) (valIn:NoTradingSessions) = 
    let tag = "386="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTotalVolumeTraded valIn =
    let tmp = System.Decimal.Parse valIn
    TotalVolumeTraded.TotalVolumeTraded tmp


let WriteTotalVolumeTraded (strm:Stream) (valIn:TotalVolumeTraded) = 
    let tag = "387="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDiscretionInst (fldValIn:string) : DiscretionInst = 
    match fldValIn with
    |"0" -> DiscretionInst.RelatedToDisplayedPrice
    |"1" -> DiscretionInst.RelatedToMarketPrice
    |"2" -> DiscretionInst.RelatedToPrimaryPrice
    |"3" -> DiscretionInst.RelatedToLocalPrimaryPrice
    |"4" -> DiscretionInst.RelatedToMidpointPrice
    |"5" -> DiscretionInst.RelatedToLastTradePrice
    |"6" -> DiscretionInst.RelatedToVwap
    | x -> failwith (sprintf "ReadDiscretionInst unknown fix tag: %A"  x) 


let WriteDiscretionInst (strm:Stream) (xxIn:DiscretionInst) =
    match xxIn with
    | DiscretionInst.RelatedToDisplayedPrice -> strm.Write "388=0"B; strm.Write (delim, 0, 1)
    | DiscretionInst.RelatedToMarketPrice -> strm.Write "388=1"B; strm.Write (delim, 0, 1)
    | DiscretionInst.RelatedToPrimaryPrice -> strm.Write "388=2"B; strm.Write (delim, 0, 1)
    | DiscretionInst.RelatedToLocalPrimaryPrice -> strm.Write "388=3"B; strm.Write (delim, 0, 1)
    | DiscretionInst.RelatedToMidpointPrice -> strm.Write "388=4"B; strm.Write (delim, 0, 1)
    | DiscretionInst.RelatedToLastTradePrice -> strm.Write "388=5"B; strm.Write (delim, 0, 1)
    | DiscretionInst.RelatedToVwap -> strm.Write "388=6"B; strm.Write (delim, 0, 1)


let ReadDiscretionOffsetValue valIn =
    let tmp = System.Decimal.Parse valIn
    DiscretionOffsetValue.DiscretionOffsetValue tmp


let WriteDiscretionOffsetValue (strm:Stream) (valIn:DiscretionOffsetValue) = 
    let tag = "389="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBidID valIn =
    let tmp =  valIn
    BidID.BidID tmp


let WriteBidID (strm:Stream) (valIn:BidID) = 
    let tag = "390="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadClientBidID valIn =
    let tmp =  valIn
    ClientBidID.ClientBidID tmp


let WriteClientBidID (strm:Stream) (valIn:ClientBidID) = 
    let tag = "391="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadListName valIn =
    let tmp =  valIn
    ListName.ListName tmp


let WriteListName (strm:Stream) (valIn:ListName) = 
    let tag = "392="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTotNoRelatedSym valIn =
    let tmp = System.Int32.Parse valIn
    TotNoRelatedSym.TotNoRelatedSym tmp


let WriteTotNoRelatedSym (strm:Stream) (valIn:TotNoRelatedSym) = 
    let tag = "393="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBidType (fldValIn:string) : BidType = 
    match fldValIn with
    |"1" -> BidType.NonDisclosed
    |"2" -> BidType.DisclosedStyle
    |"3" -> BidType.NoBiddingProcess
    | x -> failwith (sprintf "ReadBidType unknown fix tag: %A"  x) 


let WriteBidType (strm:Stream) (xxIn:BidType) =
    match xxIn with
    | BidType.NonDisclosed -> strm.Write "394=1"B; strm.Write (delim, 0, 1)
    | BidType.DisclosedStyle -> strm.Write "394=2"B; strm.Write (delim, 0, 1)
    | BidType.NoBiddingProcess -> strm.Write "394=3"B; strm.Write (delim, 0, 1)


let ReadNumTickets valIn =
    let tmp = System.Int32.Parse valIn
    NumTickets.NumTickets tmp


let WriteNumTickets (strm:Stream) (valIn:NumTickets) = 
    let tag = "395="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSideValue1 valIn =
    let tmp = System.Int32.Parse valIn
    SideValue1.SideValue1 tmp


let WriteSideValue1 (strm:Stream) (valIn:SideValue1) = 
    let tag = "396="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSideValue2 valIn =
    let tmp = System.Int32.Parse valIn
    SideValue2.SideValue2 tmp


let WriteSideValue2 (strm:Stream) (valIn:SideValue2) = 
    let tag = "397="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoBidDescriptors valIn =
    let tmp = System.Int32.Parse valIn
    NoBidDescriptors.NoBidDescriptors tmp


let WriteNoBidDescriptors (strm:Stream) (valIn:NoBidDescriptors) = 
    let tag = "398="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBidDescriptorType (fldValIn:string) : BidDescriptorType = 
    match fldValIn with
    |"1" -> BidDescriptorType.Sector
    |"2" -> BidDescriptorType.Country
    |"3" -> BidDescriptorType.Index
    | x -> failwith (sprintf "ReadBidDescriptorType unknown fix tag: %A"  x) 


let WriteBidDescriptorType (strm:Stream) (xxIn:BidDescriptorType) =
    match xxIn with
    | BidDescriptorType.Sector -> strm.Write "399=1"B; strm.Write (delim, 0, 1)
    | BidDescriptorType.Country -> strm.Write "399=2"B; strm.Write (delim, 0, 1)
    | BidDescriptorType.Index -> strm.Write "399=3"B; strm.Write (delim, 0, 1)


let ReadBidDescriptor valIn =
    let tmp =  valIn
    BidDescriptor.BidDescriptor tmp


let WriteBidDescriptor (strm:Stream) (valIn:BidDescriptor) = 
    let tag = "400="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSideValueInd (fldValIn:string) : SideValueInd = 
    match fldValIn with
    |"1" -> SideValueInd.Sidevalue1
    |"2" -> SideValueInd.Sidevalue2
    | x -> failwith (sprintf "ReadSideValueInd unknown fix tag: %A"  x) 


let WriteSideValueInd (strm:Stream) (xxIn:SideValueInd) =
    match xxIn with
    | SideValueInd.Sidevalue1 -> strm.Write "401=1"B; strm.Write (delim, 0, 1)
    | SideValueInd.Sidevalue2 -> strm.Write "401=2"B; strm.Write (delim, 0, 1)


let ReadLiquidityPctLow valIn =
    let tmp = System.Decimal.Parse valIn
    LiquidityPctLow.LiquidityPctLow tmp


let WriteLiquidityPctLow (strm:Stream) (valIn:LiquidityPctLow) = 
    let tag = "402="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLiquidityPctHigh valIn =
    let tmp = System.Decimal.Parse valIn
    LiquidityPctHigh.LiquidityPctHigh tmp


let WriteLiquidityPctHigh (strm:Stream) (valIn:LiquidityPctHigh) = 
    let tag = "403="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLiquidityValue valIn =
    let tmp = System.Int32.Parse valIn
    LiquidityValue.LiquidityValue tmp


let WriteLiquidityValue (strm:Stream) (valIn:LiquidityValue) = 
    let tag = "404="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadEFPTrackingError valIn =
    let tmp = System.Decimal.Parse valIn
    EFPTrackingError.EFPTrackingError tmp


let WriteEFPTrackingError (strm:Stream) (valIn:EFPTrackingError) = 
    let tag = "405="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadFairValue valIn =
    let tmp = System.Int32.Parse valIn
    FairValue.FairValue tmp


let WriteFairValue (strm:Stream) (valIn:FairValue) = 
    let tag = "406="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOutsideIndexPct valIn =
    let tmp = System.Decimal.Parse valIn
    OutsideIndexPct.OutsideIndexPct tmp


let WriteOutsideIndexPct (strm:Stream) (valIn:OutsideIndexPct) = 
    let tag = "407="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadValueOfFutures valIn =
    let tmp = System.Int32.Parse valIn
    ValueOfFutures.ValueOfFutures tmp


let WriteValueOfFutures (strm:Stream) (valIn:ValueOfFutures) = 
    let tag = "408="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLiquidityIndType (fldValIn:string) : LiquidityIndType = 
    match fldValIn with
    |"1" -> LiquidityIndType.FivedayMovingAverage
    |"2" -> LiquidityIndType.TwentydayMovingAverage
    |"3" -> LiquidityIndType.NormalMarketSize
    |"4" -> LiquidityIndType.Other
    | x -> failwith (sprintf "ReadLiquidityIndType unknown fix tag: %A"  x) 


let WriteLiquidityIndType (strm:Stream) (xxIn:LiquidityIndType) =
    match xxIn with
    | LiquidityIndType.FivedayMovingAverage -> strm.Write "409=1"B; strm.Write (delim, 0, 1)
    | LiquidityIndType.TwentydayMovingAverage -> strm.Write "409=2"B; strm.Write (delim, 0, 1)
    | LiquidityIndType.NormalMarketSize -> strm.Write "409=3"B; strm.Write (delim, 0, 1)
    | LiquidityIndType.Other -> strm.Write "409=4"B; strm.Write (delim, 0, 1)


let ReadWtAverageLiquidity valIn =
    let tmp = System.Decimal.Parse valIn
    WtAverageLiquidity.WtAverageLiquidity tmp


let WriteWtAverageLiquidity (strm:Stream) (valIn:WtAverageLiquidity) = 
    let tag = "410="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadExchangeForPhysical valIn =
    let tmp = System.Boolean.Parse valIn
    ExchangeForPhysical.ExchangeForPhysical tmp


let WriteExchangeForPhysical (strm:Stream) (valIn:ExchangeForPhysical) = 
    let tag = "411="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOutMainCntryUIndex valIn =
    let tmp = System.Int32.Parse valIn
    OutMainCntryUIndex.OutMainCntryUIndex tmp


let WriteOutMainCntryUIndex (strm:Stream) (valIn:OutMainCntryUIndex) = 
    let tag = "412="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCrossPercent valIn =
    let tmp = System.Decimal.Parse valIn
    CrossPercent.CrossPercent tmp


let WriteCrossPercent (strm:Stream) (valIn:CrossPercent) = 
    let tag = "413="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadProgRptReqs (fldValIn:string) : ProgRptReqs = 
    match fldValIn with
    |"1" -> ProgRptReqs.BuysideExplicitlyRequestsStatusUsingStatusrequest
    |"2" -> ProgRptReqs.SellsidePeriodicallySendsStatusUsingListstatus
    |"3" -> ProgRptReqs.RealTimeExecutionReports
    | x -> failwith (sprintf "ReadProgRptReqs unknown fix tag: %A"  x) 


let WriteProgRptReqs (strm:Stream) (xxIn:ProgRptReqs) =
    match xxIn with
    | ProgRptReqs.BuysideExplicitlyRequestsStatusUsingStatusrequest -> strm.Write "414=1"B; strm.Write (delim, 0, 1)
    | ProgRptReqs.SellsidePeriodicallySendsStatusUsingListstatus -> strm.Write "414=2"B; strm.Write (delim, 0, 1)
    | ProgRptReqs.RealTimeExecutionReports -> strm.Write "414=3"B; strm.Write (delim, 0, 1)


let ReadProgPeriodInterval valIn =
    let tmp = System.Int32.Parse valIn
    ProgPeriodInterval.ProgPeriodInterval tmp


let WriteProgPeriodInterval (strm:Stream) (valIn:ProgPeriodInterval) = 
    let tag = "415="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadIncTaxInd (fldValIn:string) : IncTaxInd = 
    match fldValIn with
    |"1" -> IncTaxInd.Net
    |"2" -> IncTaxInd.Gross
    | x -> failwith (sprintf "ReadIncTaxInd unknown fix tag: %A"  x) 


let WriteIncTaxInd (strm:Stream) (xxIn:IncTaxInd) =
    match xxIn with
    | IncTaxInd.Net -> strm.Write "416=1"B; strm.Write (delim, 0, 1)
    | IncTaxInd.Gross -> strm.Write "416=2"B; strm.Write (delim, 0, 1)


let ReadNumBidders valIn =
    let tmp = System.Int32.Parse valIn
    NumBidders.NumBidders tmp


let WriteNumBidders (strm:Stream) (valIn:NumBidders) = 
    let tag = "417="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBidTradeType (fldValIn:string) : BidTradeType = 
    match fldValIn with
    |"R" -> BidTradeType.RiskTrade
    |"G" -> BidTradeType.VwapGuarantee
    |"A" -> BidTradeType.Agency
    |"J" -> BidTradeType.GuaranteedClose
    | x -> failwith (sprintf "ReadBidTradeType unknown fix tag: %A"  x) 


let WriteBidTradeType (strm:Stream) (xxIn:BidTradeType) =
    match xxIn with
    | BidTradeType.RiskTrade -> strm.Write "418=R"B; strm.Write (delim, 0, 1)
    | BidTradeType.VwapGuarantee -> strm.Write "418=G"B; strm.Write (delim, 0, 1)
    | BidTradeType.Agency -> strm.Write "418=A"B; strm.Write (delim, 0, 1)
    | BidTradeType.GuaranteedClose -> strm.Write "418=J"B; strm.Write (delim, 0, 1)


let ReadBasisPxType (fldValIn:string) : BasisPxType = 
    match fldValIn with
    |"2" -> BasisPxType.ClosingPriceAtMorningSession
    |"3" -> BasisPxType.ClosingPrice
    |"4" -> BasisPxType.CurrentPrice
    |"5" -> BasisPxType.Sq
    |"6" -> BasisPxType.VwapThroughADay
    |"7" -> BasisPxType.VwapThroughAMorningSession
    |"8" -> BasisPxType.VwapThroughAnAfternoonSession
    |"9" -> BasisPxType.VwapThroughADayExceptYori
    |"A" -> BasisPxType.VwapThroughAMorningSessionExceptYori
    |"B" -> BasisPxType.VwapThroughAnAfternoonSessionExceptYori
    |"C" -> BasisPxType.Strike
    |"D" -> BasisPxType.Open
    |"Z" -> BasisPxType.Others
    | x -> failwith (sprintf "ReadBasisPxType unknown fix tag: %A"  x) 


let WriteBasisPxType (strm:Stream) (xxIn:BasisPxType) =
    match xxIn with
    | BasisPxType.ClosingPriceAtMorningSession -> strm.Write "419=2"B; strm.Write (delim, 0, 1)
    | BasisPxType.ClosingPrice -> strm.Write "419=3"B; strm.Write (delim, 0, 1)
    | BasisPxType.CurrentPrice -> strm.Write "419=4"B; strm.Write (delim, 0, 1)
    | BasisPxType.Sq -> strm.Write "419=5"B; strm.Write (delim, 0, 1)
    | BasisPxType.VwapThroughADay -> strm.Write "419=6"B; strm.Write (delim, 0, 1)
    | BasisPxType.VwapThroughAMorningSession -> strm.Write "419=7"B; strm.Write (delim, 0, 1)
    | BasisPxType.VwapThroughAnAfternoonSession -> strm.Write "419=8"B; strm.Write (delim, 0, 1)
    | BasisPxType.VwapThroughADayExceptYori -> strm.Write "419=9"B; strm.Write (delim, 0, 1)
    | BasisPxType.VwapThroughAMorningSessionExceptYori -> strm.Write "419=A"B; strm.Write (delim, 0, 1)
    | BasisPxType.VwapThroughAnAfternoonSessionExceptYori -> strm.Write "419=B"B; strm.Write (delim, 0, 1)
    | BasisPxType.Strike -> strm.Write "419=C"B; strm.Write (delim, 0, 1)
    | BasisPxType.Open -> strm.Write "419=D"B; strm.Write (delim, 0, 1)
    | BasisPxType.Others -> strm.Write "419=Z"B; strm.Write (delim, 0, 1)


let ReadNoBidComponents valIn =
    let tmp = System.Int32.Parse valIn
    NoBidComponents.NoBidComponents tmp


let WriteNoBidComponents (strm:Stream) (valIn:NoBidComponents) = 
    let tag = "420="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCountry valIn =
    let tmp =  valIn
    Country.Country tmp


let WriteCountry (strm:Stream) (valIn:Country) = 
    let tag = "421="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTotNoStrikes valIn =
    let tmp = System.Int32.Parse valIn
    TotNoStrikes.TotNoStrikes tmp


let WriteTotNoStrikes (strm:Stream) (valIn:TotNoStrikes) = 
    let tag = "422="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPriceType (fldValIn:string) : PriceType = 
    match fldValIn with
    |"1" -> PriceType.Percentage
    |"2" -> PriceType.PerUnit
    |"3" -> PriceType.FixedAmount
    |"4" -> PriceType.Discount
    |"5" -> PriceType.Premium
    |"6" -> PriceType.Spread
    |"7" -> PriceType.TedPrice
    |"8" -> PriceType.TedYield
    |"9" -> PriceType.Yield
    |"10" -> PriceType.FixedCabinetTradePrice
    |"11" -> PriceType.VariableCabinetTradePrice
    | x -> failwith (sprintf "ReadPriceType unknown fix tag: %A"  x) 


let WritePriceType (strm:Stream) (xxIn:PriceType) =
    match xxIn with
    | PriceType.Percentage -> strm.Write "423=1"B; strm.Write (delim, 0, 1)
    | PriceType.PerUnit -> strm.Write "423=2"B; strm.Write (delim, 0, 1)
    | PriceType.FixedAmount -> strm.Write "423=3"B; strm.Write (delim, 0, 1)
    | PriceType.Discount -> strm.Write "423=4"B; strm.Write (delim, 0, 1)
    | PriceType.Premium -> strm.Write "423=5"B; strm.Write (delim, 0, 1)
    | PriceType.Spread -> strm.Write "423=6"B; strm.Write (delim, 0, 1)
    | PriceType.TedPrice -> strm.Write "423=7"B; strm.Write (delim, 0, 1)
    | PriceType.TedYield -> strm.Write "423=8"B; strm.Write (delim, 0, 1)
    | PriceType.Yield -> strm.Write "423=9"B; strm.Write (delim, 0, 1)
    | PriceType.FixedCabinetTradePrice -> strm.Write "423=10"B; strm.Write (delim, 0, 1)
    | PriceType.VariableCabinetTradePrice -> strm.Write "423=11"B; strm.Write (delim, 0, 1)


let ReadDayOrderQty valIn =
    let tmp = System.Decimal.Parse valIn
    DayOrderQty.DayOrderQty tmp


let WriteDayOrderQty (strm:Stream) (valIn:DayOrderQty) = 
    let tag = "424="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDayCumQty valIn =
    let tmp = System.Decimal.Parse valIn
    DayCumQty.DayCumQty tmp


let WriteDayCumQty (strm:Stream) (valIn:DayCumQty) = 
    let tag = "425="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDayAvgPx valIn =
    let tmp = System.Decimal.Parse valIn
    DayAvgPx.DayAvgPx tmp


let WriteDayAvgPx (strm:Stream) (valIn:DayAvgPx) = 
    let tag = "426="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadGTBookingInst (fldValIn:string) : GTBookingInst = 
    match fldValIn with
    |"0" -> GTBookingInst.BookOutAllTradesOnDayOfExecution
    |"1" -> GTBookingInst.AccumulateExecutionsUntilOrderIsFilledOrExpires
    |"2" -> GTBookingInst.AccumulateUntilVerballyNotifiedOtherwise
    | x -> failwith (sprintf "ReadGTBookingInst unknown fix tag: %A"  x) 


let WriteGTBookingInst (strm:Stream) (xxIn:GTBookingInst) =
    match xxIn with
    | GTBookingInst.BookOutAllTradesOnDayOfExecution -> strm.Write "427=0"B; strm.Write (delim, 0, 1)
    | GTBookingInst.AccumulateExecutionsUntilOrderIsFilledOrExpires -> strm.Write "427=1"B; strm.Write (delim, 0, 1)
    | GTBookingInst.AccumulateUntilVerballyNotifiedOtherwise -> strm.Write "427=2"B; strm.Write (delim, 0, 1)


let ReadNoStrikes valIn =
    let tmp = System.Int32.Parse valIn
    NoStrikes.NoStrikes tmp


let WriteNoStrikes (strm:Stream) (valIn:NoStrikes) = 
    let tag = "428="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadListStatusType (fldValIn:string) : ListStatusType = 
    match fldValIn with
    |"1" -> ListStatusType.Ack
    |"2" -> ListStatusType.Response
    |"3" -> ListStatusType.Timed
    |"4" -> ListStatusType.Execstarted
    |"5" -> ListStatusType.Alldone
    |"6" -> ListStatusType.Alert
    | x -> failwith (sprintf "ReadListStatusType unknown fix tag: %A"  x) 


let WriteListStatusType (strm:Stream) (xxIn:ListStatusType) =
    match xxIn with
    | ListStatusType.Ack -> strm.Write "429=1"B; strm.Write (delim, 0, 1)
    | ListStatusType.Response -> strm.Write "429=2"B; strm.Write (delim, 0, 1)
    | ListStatusType.Timed -> strm.Write "429=3"B; strm.Write (delim, 0, 1)
    | ListStatusType.Execstarted -> strm.Write "429=4"B; strm.Write (delim, 0, 1)
    | ListStatusType.Alldone -> strm.Write "429=5"B; strm.Write (delim, 0, 1)
    | ListStatusType.Alert -> strm.Write "429=6"B; strm.Write (delim, 0, 1)


let ReadNetGrossInd (fldValIn:string) : NetGrossInd = 
    match fldValIn with
    |"1" -> NetGrossInd.Net
    |"2" -> NetGrossInd.Gross
    | x -> failwith (sprintf "ReadNetGrossInd unknown fix tag: %A"  x) 


let WriteNetGrossInd (strm:Stream) (xxIn:NetGrossInd) =
    match xxIn with
    | NetGrossInd.Net -> strm.Write "430=1"B; strm.Write (delim, 0, 1)
    | NetGrossInd.Gross -> strm.Write "430=2"B; strm.Write (delim, 0, 1)


let ReadListOrderStatus (fldValIn:string) : ListOrderStatus = 
    match fldValIn with
    |"1" -> ListOrderStatus.Inbiddingprocess
    |"2" -> ListOrderStatus.Receivedforexecution
    |"3" -> ListOrderStatus.Executing
    |"4" -> ListOrderStatus.Canceling
    |"5" -> ListOrderStatus.Alert
    |"6" -> ListOrderStatus.AllDone
    |"7" -> ListOrderStatus.Reject
    | x -> failwith (sprintf "ReadListOrderStatus unknown fix tag: %A"  x) 


let WriteListOrderStatus (strm:Stream) (xxIn:ListOrderStatus) =
    match xxIn with
    | ListOrderStatus.Inbiddingprocess -> strm.Write "431=1"B; strm.Write (delim, 0, 1)
    | ListOrderStatus.Receivedforexecution -> strm.Write "431=2"B; strm.Write (delim, 0, 1)
    | ListOrderStatus.Executing -> strm.Write "431=3"B; strm.Write (delim, 0, 1)
    | ListOrderStatus.Canceling -> strm.Write "431=4"B; strm.Write (delim, 0, 1)
    | ListOrderStatus.Alert -> strm.Write "431=5"B; strm.Write (delim, 0, 1)
    | ListOrderStatus.AllDone -> strm.Write "431=6"B; strm.Write (delim, 0, 1)
    | ListOrderStatus.Reject -> strm.Write "431=7"B; strm.Write (delim, 0, 1)


let ReadExpireDate valIn =
    let tmp =  valIn
    ExpireDate.ExpireDate tmp


let WriteExpireDate (strm:Stream) (valIn:ExpireDate) = 
    let tag = "432="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadListExecInstType (fldValIn:string) : ListExecInstType = 
    match fldValIn with
    |"1" -> ListExecInstType.Immediate
    |"2" -> ListExecInstType.WaitForExecuteInstruction
    |"3" -> ListExecInstType.ExchangeSwitchCivOrderSellDriven
    |"4" -> ListExecInstType.ExchangeSwitchCivOrderBuyDrivenCashTopUp
    |"5" -> ListExecInstType.ExchangeSwitchCivOrderBuyDrivenCashWithdraw
    | x -> failwith (sprintf "ReadListExecInstType unknown fix tag: %A"  x) 


let WriteListExecInstType (strm:Stream) (xxIn:ListExecInstType) =
    match xxIn with
    | ListExecInstType.Immediate -> strm.Write "433=1"B; strm.Write (delim, 0, 1)
    | ListExecInstType.WaitForExecuteInstruction -> strm.Write "433=2"B; strm.Write (delim, 0, 1)
    | ListExecInstType.ExchangeSwitchCivOrderSellDriven -> strm.Write "433=3"B; strm.Write (delim, 0, 1)
    | ListExecInstType.ExchangeSwitchCivOrderBuyDrivenCashTopUp -> strm.Write "433=4"B; strm.Write (delim, 0, 1)
    | ListExecInstType.ExchangeSwitchCivOrderBuyDrivenCashWithdraw -> strm.Write "433=5"B; strm.Write (delim, 0, 1)


let ReadCxlRejResponseTo (fldValIn:string) : CxlRejResponseTo = 
    match fldValIn with
    |"1" -> CxlRejResponseTo.OrderCancelRequest
    |"2" -> CxlRejResponseTo.OrderCancelReplaceRequest
    | x -> failwith (sprintf "ReadCxlRejResponseTo unknown fix tag: %A"  x) 


let WriteCxlRejResponseTo (strm:Stream) (xxIn:CxlRejResponseTo) =
    match xxIn with
    | CxlRejResponseTo.OrderCancelRequest -> strm.Write "434=1"B; strm.Write (delim, 0, 1)
    | CxlRejResponseTo.OrderCancelReplaceRequest -> strm.Write "434=2"B; strm.Write (delim, 0, 1)


let ReadUnderlyingCouponRate valIn =
    let tmp = System.Decimal.Parse valIn
    UnderlyingCouponRate.UnderlyingCouponRate tmp


let WriteUnderlyingCouponRate (strm:Stream) (valIn:UnderlyingCouponRate) = 
    let tag = "435="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingContractMultiplier valIn =
    let tmp = System.Decimal.Parse valIn
    UnderlyingContractMultiplier.UnderlyingContractMultiplier tmp


let WriteUnderlyingContractMultiplier (strm:Stream) (valIn:UnderlyingContractMultiplier) = 
    let tag = "436="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadContraTradeQty valIn =
    let tmp = System.Decimal.Parse valIn
    ContraTradeQty.ContraTradeQty tmp


let WriteContraTradeQty (strm:Stream) (valIn:ContraTradeQty) = 
    let tag = "437="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadContraTradeTime valIn =
    let tmp =  valIn
    ContraTradeTime.ContraTradeTime tmp


let WriteContraTradeTime (strm:Stream) (valIn:ContraTradeTime) = 
    let tag = "438="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLiquidityNumSecurities valIn =
    let tmp = System.Int32.Parse valIn
    LiquidityNumSecurities.LiquidityNumSecurities tmp


let WriteLiquidityNumSecurities (strm:Stream) (valIn:LiquidityNumSecurities) = 
    let tag = "441="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMultiLegReportingType (fldValIn:string) : MultiLegReportingType = 
    match fldValIn with
    |"1" -> MultiLegReportingType.SingleSecurity
    |"2" -> MultiLegReportingType.IndividualLegOfAMultiLegSecurity
    |"3" -> MultiLegReportingType.MultiLegSecurity
    | x -> failwith (sprintf "ReadMultiLegReportingType unknown fix tag: %A"  x) 


let WriteMultiLegReportingType (strm:Stream) (xxIn:MultiLegReportingType) =
    match xxIn with
    | MultiLegReportingType.SingleSecurity -> strm.Write "442=1"B; strm.Write (delim, 0, 1)
    | MultiLegReportingType.IndividualLegOfAMultiLegSecurity -> strm.Write "442=2"B; strm.Write (delim, 0, 1)
    | MultiLegReportingType.MultiLegSecurity -> strm.Write "442=3"B; strm.Write (delim, 0, 1)


let ReadStrikeTime valIn =
    let tmp =  valIn
    StrikeTime.StrikeTime tmp


let WriteStrikeTime (strm:Stream) (valIn:StrikeTime) = 
    let tag = "443="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadListStatusText valIn =
    let tmp =  valIn
    ListStatusText.ListStatusText tmp


let WriteListStatusText (strm:Stream) (valIn:ListStatusText) = 
    let tag = "444="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


// compound write
let WriteEncodedListStatusText (strm:System.IO.Stream) (fld:EncodedListStatusText) =
    let lenTag = "445="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "446="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadEncodedListStatusText valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "446" then failwith "invalid tag reading EncodedListStatusText"
    if strLen <> raw.Length then failwith "mismatched string len reading EncodedListStatusText"
    EncodedListStatusText.EncodedListStatusText raw


let ReadPartyIDSource (fldValIn:string) : PartyIDSource = 
    match fldValIn with
    |"B" -> PartyIDSource.Bic
    |"C" -> PartyIDSource.GenerallyAcceptedMarketParticipantIdentifier
    |"D" -> PartyIDSource.ProprietaryCustomCode
    |"E" -> PartyIDSource.IsoCountryCode
    |"F" -> PartyIDSource.SettlementEntityLocation
    |"G" -> PartyIDSource.Mic
    |"H" -> PartyIDSource.CsdParticipantMemberCode
    |"1" -> PartyIDSource.KoreanInvestorId
    |"2" -> PartyIDSource.TaiwaneseQualifiedForeignInvestorIdQfiiFid
    |"3" -> PartyIDSource.TaiwaneseTradingAccount
    |"4" -> PartyIDSource.MalaysianCentralDepositoryNumber
    |"5" -> PartyIDSource.ChineseBShare
    |"6" -> PartyIDSource.UkNationalInsuranceOrPensionNumber
    |"7" -> PartyIDSource.UsSocialSecurityNumber
    |"8" -> PartyIDSource.UsEmployerIdentificationNumber
    |"9" -> PartyIDSource.AustralianBusinessNumber
    |"A" -> PartyIDSource.AustralianTaxFileNumber
    |"I" -> PartyIDSource.DirectedBroker
    | x -> failwith (sprintf "ReadPartyIDSource unknown fix tag: %A"  x) 


let WritePartyIDSource (strm:Stream) (xxIn:PartyIDSource) =
    match xxIn with
    | PartyIDSource.Bic -> strm.Write "447=B"B; strm.Write (delim, 0, 1)
    | PartyIDSource.GenerallyAcceptedMarketParticipantIdentifier -> strm.Write "447=C"B; strm.Write (delim, 0, 1)
    | PartyIDSource.ProprietaryCustomCode -> strm.Write "447=D"B; strm.Write (delim, 0, 1)
    | PartyIDSource.IsoCountryCode -> strm.Write "447=E"B; strm.Write (delim, 0, 1)
    | PartyIDSource.SettlementEntityLocation -> strm.Write "447=F"B; strm.Write (delim, 0, 1)
    | PartyIDSource.Mic -> strm.Write "447=G"B; strm.Write (delim, 0, 1)
    | PartyIDSource.CsdParticipantMemberCode -> strm.Write "447=H"B; strm.Write (delim, 0, 1)
    | PartyIDSource.KoreanInvestorId -> strm.Write "447=1"B; strm.Write (delim, 0, 1)
    | PartyIDSource.TaiwaneseQualifiedForeignInvestorIdQfiiFid -> strm.Write "447=2"B; strm.Write (delim, 0, 1)
    | PartyIDSource.TaiwaneseTradingAccount -> strm.Write "447=3"B; strm.Write (delim, 0, 1)
    | PartyIDSource.MalaysianCentralDepositoryNumber -> strm.Write "447=4"B; strm.Write (delim, 0, 1)
    | PartyIDSource.ChineseBShare -> strm.Write "447=5"B; strm.Write (delim, 0, 1)
    | PartyIDSource.UkNationalInsuranceOrPensionNumber -> strm.Write "447=6"B; strm.Write (delim, 0, 1)
    | PartyIDSource.UsSocialSecurityNumber -> strm.Write "447=7"B; strm.Write (delim, 0, 1)
    | PartyIDSource.UsEmployerIdentificationNumber -> strm.Write "447=8"B; strm.Write (delim, 0, 1)
    | PartyIDSource.AustralianBusinessNumber -> strm.Write "447=9"B; strm.Write (delim, 0, 1)
    | PartyIDSource.AustralianTaxFileNumber -> strm.Write "447=A"B; strm.Write (delim, 0, 1)
    | PartyIDSource.DirectedBroker -> strm.Write "447=I"B; strm.Write (delim, 0, 1)


let ReadPartyID valIn =
    let tmp =  valIn
    PartyID.PartyID tmp


let WritePartyID (strm:Stream) (valIn:PartyID) = 
    let tag = "448="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNetChgPrevDay valIn =
    let tmp = System.Decimal.Parse valIn
    NetChgPrevDay.NetChgPrevDay tmp


let WriteNetChgPrevDay (strm:Stream) (valIn:NetChgPrevDay) = 
    let tag = "451="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPartyRole (fldValIn:string) : PartyRole = 
    match fldValIn with
    |"1" -> PartyRole.ExecutingFirm
    |"2" -> PartyRole.BrokerOfCredit
    |"3" -> PartyRole.ClientId
    |"4" -> PartyRole.ClearingFirm
    |"5" -> PartyRole.InvestorId
    |"6" -> PartyRole.IntroducingFirm
    |"7" -> PartyRole.EnteringFirm
    |"8" -> PartyRole.LocateLendingFirm
    |"9" -> PartyRole.FundManagerClientId
    |"10" -> PartyRole.SettlementLocation
    |"11" -> PartyRole.OrderOriginationTrader
    |"12" -> PartyRole.ExecutingTrader
    |"13" -> PartyRole.OrderOriginationFirm
    |"14" -> PartyRole.GiveupClearingFirm
    |"15" -> PartyRole.CorrespondantClearingFirm
    |"16" -> PartyRole.ExecutingSystem
    |"17" -> PartyRole.ContraFirm
    |"18" -> PartyRole.ContraClearingFirm
    |"19" -> PartyRole.SponsoringFirm
    |"20" -> PartyRole.UnderlyingContraFirm
    |"21" -> PartyRole.ClearingOrganization
    |"22" -> PartyRole.Exchange
    |"24" -> PartyRole.CustomerAccount
    |"25" -> PartyRole.CorrespondentClearingOrganization
    |"26" -> PartyRole.CorrespondentBroker
    |"27" -> PartyRole.BuyerSeller
    |"28" -> PartyRole.Custodian
    |"29" -> PartyRole.Intermediary
    |"30" -> PartyRole.Agent
    |"31" -> PartyRole.SubCustodian
    |"32" -> PartyRole.Beneficiary
    |"33" -> PartyRole.InterestedParty
    |"34" -> PartyRole.RegulatoryBody
    |"35" -> PartyRole.LiquidityProvider
    |"36" -> PartyRole.EnteringTrader
    |"37" -> PartyRole.ContraTrader
    |"38" -> PartyRole.PositionAccount
    | x -> failwith (sprintf "ReadPartyRole unknown fix tag: %A"  x) 


let WritePartyRole (strm:Stream) (xxIn:PartyRole) =
    match xxIn with
    | PartyRole.ExecutingFirm -> strm.Write "452=1"B; strm.Write (delim, 0, 1)
    | PartyRole.BrokerOfCredit -> strm.Write "452=2"B; strm.Write (delim, 0, 1)
    | PartyRole.ClientId -> strm.Write "452=3"B; strm.Write (delim, 0, 1)
    | PartyRole.ClearingFirm -> strm.Write "452=4"B; strm.Write (delim, 0, 1)
    | PartyRole.InvestorId -> strm.Write "452=5"B; strm.Write (delim, 0, 1)
    | PartyRole.IntroducingFirm -> strm.Write "452=6"B; strm.Write (delim, 0, 1)
    | PartyRole.EnteringFirm -> strm.Write "452=7"B; strm.Write (delim, 0, 1)
    | PartyRole.LocateLendingFirm -> strm.Write "452=8"B; strm.Write (delim, 0, 1)
    | PartyRole.FundManagerClientId -> strm.Write "452=9"B; strm.Write (delim, 0, 1)
    | PartyRole.SettlementLocation -> strm.Write "452=10"B; strm.Write (delim, 0, 1)
    | PartyRole.OrderOriginationTrader -> strm.Write "452=11"B; strm.Write (delim, 0, 1)
    | PartyRole.ExecutingTrader -> strm.Write "452=12"B; strm.Write (delim, 0, 1)
    | PartyRole.OrderOriginationFirm -> strm.Write "452=13"B; strm.Write (delim, 0, 1)
    | PartyRole.GiveupClearingFirm -> strm.Write "452=14"B; strm.Write (delim, 0, 1)
    | PartyRole.CorrespondantClearingFirm -> strm.Write "452=15"B; strm.Write (delim, 0, 1)
    | PartyRole.ExecutingSystem -> strm.Write "452=16"B; strm.Write (delim, 0, 1)
    | PartyRole.ContraFirm -> strm.Write "452=17"B; strm.Write (delim, 0, 1)
    | PartyRole.ContraClearingFirm -> strm.Write "452=18"B; strm.Write (delim, 0, 1)
    | PartyRole.SponsoringFirm -> strm.Write "452=19"B; strm.Write (delim, 0, 1)
    | PartyRole.UnderlyingContraFirm -> strm.Write "452=20"B; strm.Write (delim, 0, 1)
    | PartyRole.ClearingOrganization -> strm.Write "452=21"B; strm.Write (delim, 0, 1)
    | PartyRole.Exchange -> strm.Write "452=22"B; strm.Write (delim, 0, 1)
    | PartyRole.CustomerAccount -> strm.Write "452=24"B; strm.Write (delim, 0, 1)
    | PartyRole.CorrespondentClearingOrganization -> strm.Write "452=25"B; strm.Write (delim, 0, 1)
    | PartyRole.CorrespondentBroker -> strm.Write "452=26"B; strm.Write (delim, 0, 1)
    | PartyRole.BuyerSeller -> strm.Write "452=27"B; strm.Write (delim, 0, 1)
    | PartyRole.Custodian -> strm.Write "452=28"B; strm.Write (delim, 0, 1)
    | PartyRole.Intermediary -> strm.Write "452=29"B; strm.Write (delim, 0, 1)
    | PartyRole.Agent -> strm.Write "452=30"B; strm.Write (delim, 0, 1)
    | PartyRole.SubCustodian -> strm.Write "452=31"B; strm.Write (delim, 0, 1)
    | PartyRole.Beneficiary -> strm.Write "452=32"B; strm.Write (delim, 0, 1)
    | PartyRole.InterestedParty -> strm.Write "452=33"B; strm.Write (delim, 0, 1)
    | PartyRole.RegulatoryBody -> strm.Write "452=34"B; strm.Write (delim, 0, 1)
    | PartyRole.LiquidityProvider -> strm.Write "452=35"B; strm.Write (delim, 0, 1)
    | PartyRole.EnteringTrader -> strm.Write "452=36"B; strm.Write (delim, 0, 1)
    | PartyRole.ContraTrader -> strm.Write "452=37"B; strm.Write (delim, 0, 1)
    | PartyRole.PositionAccount -> strm.Write "452=38"B; strm.Write (delim, 0, 1)


let ReadNoPartyIDs valIn =
    let tmp = System.Int32.Parse valIn
    NoPartyIDs.NoPartyIDs tmp


let WriteNoPartyIDs (strm:Stream) (valIn:NoPartyIDs) = 
    let tag = "453="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoSecurityAltID valIn =
    let tmp = System.Int32.Parse valIn
    NoSecurityAltID.NoSecurityAltID tmp


let WriteNoSecurityAltID (strm:Stream) (valIn:NoSecurityAltID) = 
    let tag = "454="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecurityAltID valIn =
    let tmp =  valIn
    SecurityAltID.SecurityAltID tmp


let WriteSecurityAltID (strm:Stream) (valIn:SecurityAltID) = 
    let tag = "455="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecurityAltIDSource valIn =
    let tmp =  valIn
    SecurityAltIDSource.SecurityAltIDSource tmp


let WriteSecurityAltIDSource (strm:Stream) (valIn:SecurityAltIDSource) = 
    let tag = "456="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoUnderlyingSecurityAltID valIn =
    let tmp = System.Int32.Parse valIn
    NoUnderlyingSecurityAltID.NoUnderlyingSecurityAltID tmp


let WriteNoUnderlyingSecurityAltID (strm:Stream) (valIn:NoUnderlyingSecurityAltID) = 
    let tag = "457="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingSecurityAltID valIn =
    let tmp =  valIn
    UnderlyingSecurityAltID.UnderlyingSecurityAltID tmp


let WriteUnderlyingSecurityAltID (strm:Stream) (valIn:UnderlyingSecurityAltID) = 
    let tag = "458="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingSecurityAltIDSource valIn =
    let tmp =  valIn
    UnderlyingSecurityAltIDSource.UnderlyingSecurityAltIDSource tmp


let WriteUnderlyingSecurityAltIDSource (strm:Stream) (valIn:UnderlyingSecurityAltIDSource) = 
    let tag = "459="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadProduct (fldValIn:string) : Product = 
    match fldValIn with
    |"1" -> Product.Agency
    |"2" -> Product.Commodity
    |"3" -> Product.Corporate
    |"4" -> Product.Currency
    |"5" -> Product.Equity
    |"6" -> Product.Government
    |"7" -> Product.Index
    |"8" -> Product.Loan
    |"9" -> Product.Moneymarket
    |"10" -> Product.Mortgage
    |"11" -> Product.Municipal
    |"12" -> Product.Other
    |"13" -> Product.Financing
    | x -> failwith (sprintf "ReadProduct unknown fix tag: %A"  x) 


let WriteProduct (strm:Stream) (xxIn:Product) =
    match xxIn with
    | Product.Agency -> strm.Write "460=1"B; strm.Write (delim, 0, 1)
    | Product.Commodity -> strm.Write "460=2"B; strm.Write (delim, 0, 1)
    | Product.Corporate -> strm.Write "460=3"B; strm.Write (delim, 0, 1)
    | Product.Currency -> strm.Write "460=4"B; strm.Write (delim, 0, 1)
    | Product.Equity -> strm.Write "460=5"B; strm.Write (delim, 0, 1)
    | Product.Government -> strm.Write "460=6"B; strm.Write (delim, 0, 1)
    | Product.Index -> strm.Write "460=7"B; strm.Write (delim, 0, 1)
    | Product.Loan -> strm.Write "460=8"B; strm.Write (delim, 0, 1)
    | Product.Moneymarket -> strm.Write "460=9"B; strm.Write (delim, 0, 1)
    | Product.Mortgage -> strm.Write "460=10"B; strm.Write (delim, 0, 1)
    | Product.Municipal -> strm.Write "460=11"B; strm.Write (delim, 0, 1)
    | Product.Other -> strm.Write "460=12"B; strm.Write (delim, 0, 1)
    | Product.Financing -> strm.Write "460=13"B; strm.Write (delim, 0, 1)


let ReadCFICode valIn =
    let tmp =  valIn
    CFICode.CFICode tmp


let WriteCFICode (strm:Stream) (valIn:CFICode) = 
    let tag = "461="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingProduct valIn =
    let tmp = System.Int32.Parse valIn
    UnderlyingProduct.UnderlyingProduct tmp


let WriteUnderlyingProduct (strm:Stream) (valIn:UnderlyingProduct) = 
    let tag = "462="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingCFICode valIn =
    let tmp =  valIn
    UnderlyingCFICode.UnderlyingCFICode tmp


let WriteUnderlyingCFICode (strm:Stream) (valIn:UnderlyingCFICode) = 
    let tag = "463="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTestMessageIndicator valIn =
    let tmp = System.Boolean.Parse valIn
    TestMessageIndicator.TestMessageIndicator tmp


let WriteTestMessageIndicator (strm:Stream) (valIn:TestMessageIndicator) = 
    let tag = "464="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuantityType (fldValIn:string) : QuantityType = 
    match fldValIn with
    |"1" -> QuantityType.Shares
    |"2" -> QuantityType.Bonds
    |"3" -> QuantityType.Currentface
    |"4" -> QuantityType.Originalface
    |"5" -> QuantityType.Currency
    |"6" -> QuantityType.Contracts
    |"7" -> QuantityType.Other
    |"8" -> QuantityType.Par
    | x -> failwith (sprintf "ReadQuantityType unknown fix tag: %A"  x) 


let WriteQuantityType (strm:Stream) (xxIn:QuantityType) =
    match xxIn with
    | QuantityType.Shares -> strm.Write "465=1"B; strm.Write (delim, 0, 1)
    | QuantityType.Bonds -> strm.Write "465=2"B; strm.Write (delim, 0, 1)
    | QuantityType.Currentface -> strm.Write "465=3"B; strm.Write (delim, 0, 1)
    | QuantityType.Originalface -> strm.Write "465=4"B; strm.Write (delim, 0, 1)
    | QuantityType.Currency -> strm.Write "465=5"B; strm.Write (delim, 0, 1)
    | QuantityType.Contracts -> strm.Write "465=6"B; strm.Write (delim, 0, 1)
    | QuantityType.Other -> strm.Write "465=7"B; strm.Write (delim, 0, 1)
    | QuantityType.Par -> strm.Write "465=8"B; strm.Write (delim, 0, 1)


let ReadBookingRefID valIn =
    let tmp =  valIn
    BookingRefID.BookingRefID tmp


let WriteBookingRefID (strm:Stream) (valIn:BookingRefID) = 
    let tag = "466="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadIndividualAllocID valIn =
    let tmp =  valIn
    IndividualAllocID.IndividualAllocID tmp


let WriteIndividualAllocID (strm:Stream) (valIn:IndividualAllocID) = 
    let tag = "467="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRoundingDirection (fldValIn:string) : RoundingDirection = 
    match fldValIn with
    |"0" -> RoundingDirection.RoundToNearest
    |"1" -> RoundingDirection.RoundDown
    |"2" -> RoundingDirection.RoundUp
    | x -> failwith (sprintf "ReadRoundingDirection unknown fix tag: %A"  x) 


let WriteRoundingDirection (strm:Stream) (xxIn:RoundingDirection) =
    match xxIn with
    | RoundingDirection.RoundToNearest -> strm.Write "468=0"B; strm.Write (delim, 0, 1)
    | RoundingDirection.RoundDown -> strm.Write "468=1"B; strm.Write (delim, 0, 1)
    | RoundingDirection.RoundUp -> strm.Write "468=2"B; strm.Write (delim, 0, 1)


let ReadRoundingModulus valIn =
    let tmp = System.Decimal.Parse valIn
    RoundingModulus.RoundingModulus tmp


let WriteRoundingModulus (strm:Stream) (valIn:RoundingModulus) = 
    let tag = "469="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCountryOfIssue valIn =
    let tmp =  valIn
    CountryOfIssue.CountryOfIssue tmp


let WriteCountryOfIssue (strm:Stream) (valIn:CountryOfIssue) = 
    let tag = "470="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadStateOrProvinceOfIssue valIn =
    let tmp =  valIn
    StateOrProvinceOfIssue.StateOrProvinceOfIssue tmp


let WriteStateOrProvinceOfIssue (strm:Stream) (valIn:StateOrProvinceOfIssue) = 
    let tag = "471="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLocaleOfIssue valIn =
    let tmp =  valIn
    LocaleOfIssue.LocaleOfIssue tmp


let WriteLocaleOfIssue (strm:Stream) (valIn:LocaleOfIssue) = 
    let tag = "472="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoRegistDtls valIn =
    let tmp = System.Int32.Parse valIn
    NoRegistDtls.NoRegistDtls tmp


let WriteNoRegistDtls (strm:Stream) (valIn:NoRegistDtls) = 
    let tag = "473="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMailingDtls valIn =
    let tmp =  valIn
    MailingDtls.MailingDtls tmp


let WriteMailingDtls (strm:Stream) (valIn:MailingDtls) = 
    let tag = "474="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadInvestorCountryOfResidence valIn =
    let tmp =  valIn
    InvestorCountryOfResidence.InvestorCountryOfResidence tmp


let WriteInvestorCountryOfResidence (strm:Stream) (valIn:InvestorCountryOfResidence) = 
    let tag = "475="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPaymentRef valIn =
    let tmp =  valIn
    PaymentRef.PaymentRef tmp


let WritePaymentRef (strm:Stream) (valIn:PaymentRef) = 
    let tag = "476="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDistribPaymentMethod (fldValIn:string) : DistribPaymentMethod = 
    match fldValIn with
    |"1" -> DistribPaymentMethod.Crest
    |"2" -> DistribPaymentMethod.Nscc
    |"3" -> DistribPaymentMethod.Euroclear
    |"4" -> DistribPaymentMethod.Clearstream
    |"5" -> DistribPaymentMethod.Cheque
    |"6" -> DistribPaymentMethod.TelegraphicTransfer
    |"7" -> DistribPaymentMethod.Fedwire
    |"8" -> DistribPaymentMethod.DirectCredit
    |"9" -> DistribPaymentMethod.AchCredit
    |"10" -> DistribPaymentMethod.Bpay
    |"11" -> DistribPaymentMethod.HighValueClearingSystem
    |"12" -> DistribPaymentMethod.ReinvestInFund
    | x -> failwith (sprintf "ReadDistribPaymentMethod unknown fix tag: %A"  x) 


let WriteDistribPaymentMethod (strm:Stream) (xxIn:DistribPaymentMethod) =
    match xxIn with
    | DistribPaymentMethod.Crest -> strm.Write "477=1"B; strm.Write (delim, 0, 1)
    | DistribPaymentMethod.Nscc -> strm.Write "477=2"B; strm.Write (delim, 0, 1)
    | DistribPaymentMethod.Euroclear -> strm.Write "477=3"B; strm.Write (delim, 0, 1)
    | DistribPaymentMethod.Clearstream -> strm.Write "477=4"B; strm.Write (delim, 0, 1)
    | DistribPaymentMethod.Cheque -> strm.Write "477=5"B; strm.Write (delim, 0, 1)
    | DistribPaymentMethod.TelegraphicTransfer -> strm.Write "477=6"B; strm.Write (delim, 0, 1)
    | DistribPaymentMethod.Fedwire -> strm.Write "477=7"B; strm.Write (delim, 0, 1)
    | DistribPaymentMethod.DirectCredit -> strm.Write "477=8"B; strm.Write (delim, 0, 1)
    | DistribPaymentMethod.AchCredit -> strm.Write "477=9"B; strm.Write (delim, 0, 1)
    | DistribPaymentMethod.Bpay -> strm.Write "477=10"B; strm.Write (delim, 0, 1)
    | DistribPaymentMethod.HighValueClearingSystem -> strm.Write "477=11"B; strm.Write (delim, 0, 1)
    | DistribPaymentMethod.ReinvestInFund -> strm.Write "477=12"B; strm.Write (delim, 0, 1)


let ReadCashDistribCurr valIn =
    let tmp =  valIn
    CashDistribCurr.CashDistribCurr tmp


let WriteCashDistribCurr (strm:Stream) (valIn:CashDistribCurr) = 
    let tag = "478="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCommCurrency valIn =
    let tmp =  valIn
    CommCurrency.CommCurrency tmp


let WriteCommCurrency (strm:Stream) (valIn:CommCurrency) = 
    let tag = "479="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCancellationRights (fldValIn:string) : CancellationRights = 
    match fldValIn with
    |"Y" -> CancellationRights.Yes
    |"N" -> CancellationRights.NoExecutionOnly
    |"M" -> CancellationRights.NoWaiverAgreement
    |"O" -> CancellationRights.NoInstitutional
    | x -> failwith (sprintf "ReadCancellationRights unknown fix tag: %A"  x) 


let WriteCancellationRights (strm:Stream) (xxIn:CancellationRights) =
    match xxIn with
    | CancellationRights.Yes -> strm.Write "480=Y"B; strm.Write (delim, 0, 1)
    | CancellationRights.NoExecutionOnly -> strm.Write "480=N"B; strm.Write (delim, 0, 1)
    | CancellationRights.NoWaiverAgreement -> strm.Write "480=M"B; strm.Write (delim, 0, 1)
    | CancellationRights.NoInstitutional -> strm.Write "480=O"B; strm.Write (delim, 0, 1)


let ReadMoneyLaunderingStatus (fldValIn:string) : MoneyLaunderingStatus = 
    match fldValIn with
    |"Y" -> MoneyLaunderingStatus.Passed
    |"N" -> MoneyLaunderingStatus.NotChecked
    |"1" -> MoneyLaunderingStatus.ExemptBelowTheLimit
    |"2" -> MoneyLaunderingStatus.ExemptClientMoneyTypeExemption
    |"3" -> MoneyLaunderingStatus.ExemptAuthorisedCreditOrFinancialInstitution
    | x -> failwith (sprintf "ReadMoneyLaunderingStatus unknown fix tag: %A"  x) 


let WriteMoneyLaunderingStatus (strm:Stream) (xxIn:MoneyLaunderingStatus) =
    match xxIn with
    | MoneyLaunderingStatus.Passed -> strm.Write "481=Y"B; strm.Write (delim, 0, 1)
    | MoneyLaunderingStatus.NotChecked -> strm.Write "481=N"B; strm.Write (delim, 0, 1)
    | MoneyLaunderingStatus.ExemptBelowTheLimit -> strm.Write "481=1"B; strm.Write (delim, 0, 1)
    | MoneyLaunderingStatus.ExemptClientMoneyTypeExemption -> strm.Write "481=2"B; strm.Write (delim, 0, 1)
    | MoneyLaunderingStatus.ExemptAuthorisedCreditOrFinancialInstitution -> strm.Write "481=3"B; strm.Write (delim, 0, 1)


let ReadMailingInst valIn =
    let tmp =  valIn
    MailingInst.MailingInst tmp


let WriteMailingInst (strm:Stream) (valIn:MailingInst) = 
    let tag = "482="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTransBkdTime valIn =
    let tmp =  valIn
    TransBkdTime.TransBkdTime tmp


let WriteTransBkdTime (strm:Stream) (valIn:TransBkdTime) = 
    let tag = "483="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadExecPriceType (fldValIn:string) : ExecPriceType = 
    match fldValIn with
    |"B" -> ExecPriceType.BidPrice
    |"C" -> ExecPriceType.CreationPrice
    |"D" -> ExecPriceType.CreationPricePlusAdjustmentPercent
    |"E" -> ExecPriceType.CreationPricePlusAdjustmentAmount
    |"O" -> ExecPriceType.OfferPrice
    |"P" -> ExecPriceType.OfferPriceMinusAdjustmentPercent
    |"Q" -> ExecPriceType.OfferPriceMinusAdjustmentAmount
    |"S" -> ExecPriceType.SinglePrice
    | x -> failwith (sprintf "ReadExecPriceType unknown fix tag: %A"  x) 


let WriteExecPriceType (strm:Stream) (xxIn:ExecPriceType) =
    match xxIn with
    | ExecPriceType.BidPrice -> strm.Write "484=B"B; strm.Write (delim, 0, 1)
    | ExecPriceType.CreationPrice -> strm.Write "484=C"B; strm.Write (delim, 0, 1)
    | ExecPriceType.CreationPricePlusAdjustmentPercent -> strm.Write "484=D"B; strm.Write (delim, 0, 1)
    | ExecPriceType.CreationPricePlusAdjustmentAmount -> strm.Write "484=E"B; strm.Write (delim, 0, 1)
    | ExecPriceType.OfferPrice -> strm.Write "484=O"B; strm.Write (delim, 0, 1)
    | ExecPriceType.OfferPriceMinusAdjustmentPercent -> strm.Write "484=P"B; strm.Write (delim, 0, 1)
    | ExecPriceType.OfferPriceMinusAdjustmentAmount -> strm.Write "484=Q"B; strm.Write (delim, 0, 1)
    | ExecPriceType.SinglePrice -> strm.Write "484=S"B; strm.Write (delim, 0, 1)


let ReadExecPriceAdjustment valIn =
    let tmp = System.Decimal.Parse valIn
    ExecPriceAdjustment.ExecPriceAdjustment tmp


let WriteExecPriceAdjustment (strm:Stream) (valIn:ExecPriceAdjustment) = 
    let tag = "485="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDateOfBirth valIn =
    let tmp =  valIn
    DateOfBirth.DateOfBirth tmp


let WriteDateOfBirth (strm:Stream) (valIn:DateOfBirth) = 
    let tag = "486="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradeReportTransType (fldValIn:string) : TradeReportTransType = 
    match fldValIn with
    |"0" -> TradeReportTransType.New
    |"1" -> TradeReportTransType.Cancel
    |"2" -> TradeReportTransType.Replace
    |"3" -> TradeReportTransType.Release
    |"4" -> TradeReportTransType.Reverse
    | x -> failwith (sprintf "ReadTradeReportTransType unknown fix tag: %A"  x) 


let WriteTradeReportTransType (strm:Stream) (xxIn:TradeReportTransType) =
    match xxIn with
    | TradeReportTransType.New -> strm.Write "487=0"B; strm.Write (delim, 0, 1)
    | TradeReportTransType.Cancel -> strm.Write "487=1"B; strm.Write (delim, 0, 1)
    | TradeReportTransType.Replace -> strm.Write "487=2"B; strm.Write (delim, 0, 1)
    | TradeReportTransType.Release -> strm.Write "487=3"B; strm.Write (delim, 0, 1)
    | TradeReportTransType.Reverse -> strm.Write "487=4"B; strm.Write (delim, 0, 1)


let ReadCardHolderName valIn =
    let tmp =  valIn
    CardHolderName.CardHolderName tmp


let WriteCardHolderName (strm:Stream) (valIn:CardHolderName) = 
    let tag = "488="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCardNumber valIn =
    let tmp =  valIn
    CardNumber.CardNumber tmp


let WriteCardNumber (strm:Stream) (valIn:CardNumber) = 
    let tag = "489="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCardExpDate valIn =
    let tmp =  valIn
    CardExpDate.CardExpDate tmp


let WriteCardExpDate (strm:Stream) (valIn:CardExpDate) = 
    let tag = "490="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCardIssNum valIn =
    let tmp =  valIn
    CardIssNum.CardIssNum tmp


let WriteCardIssNum (strm:Stream) (valIn:CardIssNum) = 
    let tag = "491="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPaymentMethod (fldValIn:string) : PaymentMethod = 
    match fldValIn with
    |"1" -> PaymentMethod.Crest
    |"2" -> PaymentMethod.Nscc
    |"3" -> PaymentMethod.Euroclear
    |"4" -> PaymentMethod.Clearstream
    |"5" -> PaymentMethod.Cheque
    |"6" -> PaymentMethod.TelegraphicTransfer
    |"7" -> PaymentMethod.Fedwire
    |"8" -> PaymentMethod.DebitCard
    |"9" -> PaymentMethod.DirectDebit
    |"10" -> PaymentMethod.DirectCredit
    |"11" -> PaymentMethod.CreditCard
    |"12" -> PaymentMethod.AchDebit
    |"13" -> PaymentMethod.AchCredit
    |"14" -> PaymentMethod.Bpay
    |"15" -> PaymentMethod.HighValueClearingSystem
    | x -> failwith (sprintf "ReadPaymentMethod unknown fix tag: %A"  x) 


let WritePaymentMethod (strm:Stream) (xxIn:PaymentMethod) =
    match xxIn with
    | PaymentMethod.Crest -> strm.Write "492=1"B; strm.Write (delim, 0, 1)
    | PaymentMethod.Nscc -> strm.Write "492=2"B; strm.Write (delim, 0, 1)
    | PaymentMethod.Euroclear -> strm.Write "492=3"B; strm.Write (delim, 0, 1)
    | PaymentMethod.Clearstream -> strm.Write "492=4"B; strm.Write (delim, 0, 1)
    | PaymentMethod.Cheque -> strm.Write "492=5"B; strm.Write (delim, 0, 1)
    | PaymentMethod.TelegraphicTransfer -> strm.Write "492=6"B; strm.Write (delim, 0, 1)
    | PaymentMethod.Fedwire -> strm.Write "492=7"B; strm.Write (delim, 0, 1)
    | PaymentMethod.DebitCard -> strm.Write "492=8"B; strm.Write (delim, 0, 1)
    | PaymentMethod.DirectDebit -> strm.Write "492=9"B; strm.Write (delim, 0, 1)
    | PaymentMethod.DirectCredit -> strm.Write "492=10"B; strm.Write (delim, 0, 1)
    | PaymentMethod.CreditCard -> strm.Write "492=11"B; strm.Write (delim, 0, 1)
    | PaymentMethod.AchDebit -> strm.Write "492=12"B; strm.Write (delim, 0, 1)
    | PaymentMethod.AchCredit -> strm.Write "492=13"B; strm.Write (delim, 0, 1)
    | PaymentMethod.Bpay -> strm.Write "492=14"B; strm.Write (delim, 0, 1)
    | PaymentMethod.HighValueClearingSystem -> strm.Write "492=15"B; strm.Write (delim, 0, 1)


let ReadRegistAcctType valIn =
    let tmp =  valIn
    RegistAcctType.RegistAcctType tmp


let WriteRegistAcctType (strm:Stream) (valIn:RegistAcctType) = 
    let tag = "493="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDesignation valIn =
    let tmp =  valIn
    Designation.Designation tmp


let WriteDesignation (strm:Stream) (valIn:Designation) = 
    let tag = "494="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTaxAdvantageType (fldValIn:string) : TaxAdvantageType = 
    match fldValIn with
    |"0" -> TaxAdvantageType.NNone
    |"1" -> TaxAdvantageType.MaxiIsa
    |"2" -> TaxAdvantageType.Tessa
    |"3" -> TaxAdvantageType.MiniCashIsa
    |"4" -> TaxAdvantageType.MiniStocksAndSharesIsa
    |"5" -> TaxAdvantageType.MiniInsuranceIsa
    |"6" -> TaxAdvantageType.CurrentYearPayment
    |"7" -> TaxAdvantageType.PriorYearPayment
    |"8" -> TaxAdvantageType.AssetTransfer
    |"9" -> TaxAdvantageType.EmployeePriorYear
    |"999" -> TaxAdvantageType.Other
    | x -> failwith (sprintf "ReadTaxAdvantageType unknown fix tag: %A"  x) 


let WriteTaxAdvantageType (strm:Stream) (xxIn:TaxAdvantageType) =
    match xxIn with
    | TaxAdvantageType.NNone -> strm.Write "495=0"B; strm.Write (delim, 0, 1)
    | TaxAdvantageType.MaxiIsa -> strm.Write "495=1"B; strm.Write (delim, 0, 1)
    | TaxAdvantageType.Tessa -> strm.Write "495=2"B; strm.Write (delim, 0, 1)
    | TaxAdvantageType.MiniCashIsa -> strm.Write "495=3"B; strm.Write (delim, 0, 1)
    | TaxAdvantageType.MiniStocksAndSharesIsa -> strm.Write "495=4"B; strm.Write (delim, 0, 1)
    | TaxAdvantageType.MiniInsuranceIsa -> strm.Write "495=5"B; strm.Write (delim, 0, 1)
    | TaxAdvantageType.CurrentYearPayment -> strm.Write "495=6"B; strm.Write (delim, 0, 1)
    | TaxAdvantageType.PriorYearPayment -> strm.Write "495=7"B; strm.Write (delim, 0, 1)
    | TaxAdvantageType.AssetTransfer -> strm.Write "495=8"B; strm.Write (delim, 0, 1)
    | TaxAdvantageType.EmployeePriorYear -> strm.Write "495=9"B; strm.Write (delim, 0, 1)
    | TaxAdvantageType.Other -> strm.Write "495=999"B; strm.Write (delim, 0, 1)


let ReadRegistRejReasonText valIn =
    let tmp =  valIn
    RegistRejReasonText.RegistRejReasonText tmp


let WriteRegistRejReasonText (strm:Stream) (valIn:RegistRejReasonText) = 
    let tag = "496="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadFundRenewWaiv (fldValIn:string) : FundRenewWaiv = 
    match fldValIn with
    |"Y" -> FundRenewWaiv.Yes
    |"N" -> FundRenewWaiv.No
    | x -> failwith (sprintf "ReadFundRenewWaiv unknown fix tag: %A"  x) 


let WriteFundRenewWaiv (strm:Stream) (xxIn:FundRenewWaiv) =
    match xxIn with
    | FundRenewWaiv.Yes -> strm.Write "497=Y"B; strm.Write (delim, 0, 1)
    | FundRenewWaiv.No -> strm.Write "497=N"B; strm.Write (delim, 0, 1)


let ReadCashDistribAgentName valIn =
    let tmp =  valIn
    CashDistribAgentName.CashDistribAgentName tmp


let WriteCashDistribAgentName (strm:Stream) (valIn:CashDistribAgentName) = 
    let tag = "498="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCashDistribAgentCode valIn =
    let tmp =  valIn
    CashDistribAgentCode.CashDistribAgentCode tmp


let WriteCashDistribAgentCode (strm:Stream) (valIn:CashDistribAgentCode) = 
    let tag = "499="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCashDistribAgentAcctNumber valIn =
    let tmp =  valIn
    CashDistribAgentAcctNumber.CashDistribAgentAcctNumber tmp


let WriteCashDistribAgentAcctNumber (strm:Stream) (valIn:CashDistribAgentAcctNumber) = 
    let tag = "500="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCashDistribPayRef valIn =
    let tmp =  valIn
    CashDistribPayRef.CashDistribPayRef tmp


let WriteCashDistribPayRef (strm:Stream) (valIn:CashDistribPayRef) = 
    let tag = "501="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCashDistribAgentAcctName valIn =
    let tmp =  valIn
    CashDistribAgentAcctName.CashDistribAgentAcctName tmp


let WriteCashDistribAgentAcctName (strm:Stream) (valIn:CashDistribAgentAcctName) = 
    let tag = "502="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCardStartDate valIn =
    let tmp =  valIn
    CardStartDate.CardStartDate tmp


let WriteCardStartDate (strm:Stream) (valIn:CardStartDate) = 
    let tag = "503="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPaymentDate valIn =
    let tmp =  valIn
    PaymentDate.PaymentDate tmp


let WritePaymentDate (strm:Stream) (valIn:PaymentDate) = 
    let tag = "504="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPaymentRemitterID valIn =
    let tmp =  valIn
    PaymentRemitterID.PaymentRemitterID tmp


let WritePaymentRemitterID (strm:Stream) (valIn:PaymentRemitterID) = 
    let tag = "505="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRegistStatus (fldValIn:string) : RegistStatus = 
    match fldValIn with
    |"A" -> RegistStatus.Accepted
    |"R" -> RegistStatus.Rejected
    |"H" -> RegistStatus.Held
    |"N" -> RegistStatus.Reminder
    | x -> failwith (sprintf "ReadRegistStatus unknown fix tag: %A"  x) 


let WriteRegistStatus (strm:Stream) (xxIn:RegistStatus) =
    match xxIn with
    | RegistStatus.Accepted -> strm.Write "506=A"B; strm.Write (delim, 0, 1)
    | RegistStatus.Rejected -> strm.Write "506=R"B; strm.Write (delim, 0, 1)
    | RegistStatus.Held -> strm.Write "506=H"B; strm.Write (delim, 0, 1)
    | RegistStatus.Reminder -> strm.Write "506=N"B; strm.Write (delim, 0, 1)


let ReadRegistRejReasonCode (fldValIn:string) : RegistRejReasonCode = 
    match fldValIn with
    |"1" -> RegistRejReasonCode.InvalidUnacceptableAccountType
    |"2" -> RegistRejReasonCode.InvalidUnacceptableTaxExemptType
    |"3" -> RegistRejReasonCode.InvalidUnacceptableOwnershipType
    |"4" -> RegistRejReasonCode.InvalidUnacceptableNoRegDetls
    |"5" -> RegistRejReasonCode.InvalidUnacceptableRegSeqNo
    |"6" -> RegistRejReasonCode.InvalidUnacceptableRegDtls
    |"7" -> RegistRejReasonCode.InvalidUnacceptableMailingDtls
    |"8" -> RegistRejReasonCode.InvalidUnacceptableMailingInst
    |"9" -> RegistRejReasonCode.InvalidUnacceptableInvestorId
    |"10" -> RegistRejReasonCode.InvalidUnacceptableInvestorIdSource
    |"11" -> RegistRejReasonCode.InvalidUnacceptableDateOfBirth
    |"12" -> RegistRejReasonCode.InvalidUnacceptableInvestorCountryOfResidence
    |"13" -> RegistRejReasonCode.InvalidUnacceptableNodistribinstns
    |"14" -> RegistRejReasonCode.InvalidUnacceptableDistribPercentage
    |"15" -> RegistRejReasonCode.InvalidUnacceptableDistribPaymentMethod
    |"16" -> RegistRejReasonCode.InvalidUnacceptableCashDistribAgentAcctName
    |"17" -> RegistRejReasonCode.InvalidUnacceptableCashDistribAgentCode
    |"18" -> RegistRejReasonCode.InvalidUnacceptableCashDistribAgentAcctNum
    |"99" -> RegistRejReasonCode.Other
    | x -> failwith (sprintf "ReadRegistRejReasonCode unknown fix tag: %A"  x) 


let WriteRegistRejReasonCode (strm:Stream) (xxIn:RegistRejReasonCode) =
    match xxIn with
    | RegistRejReasonCode.InvalidUnacceptableAccountType -> strm.Write "507=1"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableTaxExemptType -> strm.Write "507=2"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableOwnershipType -> strm.Write "507=3"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableNoRegDetls -> strm.Write "507=4"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableRegSeqNo -> strm.Write "507=5"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableRegDtls -> strm.Write "507=6"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableMailingDtls -> strm.Write "507=7"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableMailingInst -> strm.Write "507=8"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableInvestorId -> strm.Write "507=9"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableInvestorIdSource -> strm.Write "507=10"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableDateOfBirth -> strm.Write "507=11"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableInvestorCountryOfResidence -> strm.Write "507=12"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableNodistribinstns -> strm.Write "507=13"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableDistribPercentage -> strm.Write "507=14"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableDistribPaymentMethod -> strm.Write "507=15"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableCashDistribAgentAcctName -> strm.Write "507=16"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableCashDistribAgentCode -> strm.Write "507=17"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.InvalidUnacceptableCashDistribAgentAcctNum -> strm.Write "507=18"B; strm.Write (delim, 0, 1)
    | RegistRejReasonCode.Other -> strm.Write "507=99"B; strm.Write (delim, 0, 1)


let ReadRegistRefID valIn =
    let tmp =  valIn
    RegistRefID.RegistRefID tmp


let WriteRegistRefID (strm:Stream) (valIn:RegistRefID) = 
    let tag = "508="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRegistDtls valIn =
    let tmp =  valIn
    RegistDtls.RegistDtls tmp


let WriteRegistDtls (strm:Stream) (valIn:RegistDtls) = 
    let tag = "509="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoDistribInsts valIn =
    let tmp = System.Int32.Parse valIn
    NoDistribInsts.NoDistribInsts tmp


let WriteNoDistribInsts (strm:Stream) (valIn:NoDistribInsts) = 
    let tag = "510="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRegistEmail valIn =
    let tmp =  valIn
    RegistEmail.RegistEmail tmp


let WriteRegistEmail (strm:Stream) (valIn:RegistEmail) = 
    let tag = "511="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDistribPercentage valIn =
    let tmp = System.Decimal.Parse valIn
    DistribPercentage.DistribPercentage tmp


let WriteDistribPercentage (strm:Stream) (valIn:DistribPercentage) = 
    let tag = "512="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRegistID valIn =
    let tmp =  valIn
    RegistID.RegistID tmp


let WriteRegistID (strm:Stream) (valIn:RegistID) = 
    let tag = "513="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRegistTransType (fldValIn:string) : RegistTransType = 
    match fldValIn with
    |"0" -> RegistTransType.New
    |"1" -> RegistTransType.Replace
    |"2" -> RegistTransType.Cancel
    | x -> failwith (sprintf "ReadRegistTransType unknown fix tag: %A"  x) 


let WriteRegistTransType (strm:Stream) (xxIn:RegistTransType) =
    match xxIn with
    | RegistTransType.New -> strm.Write "514=0"B; strm.Write (delim, 0, 1)
    | RegistTransType.Replace -> strm.Write "514=1"B; strm.Write (delim, 0, 1)
    | RegistTransType.Cancel -> strm.Write "514=2"B; strm.Write (delim, 0, 1)


let ReadExecValuationPoint valIn =
    let tmp =  valIn
    ExecValuationPoint.ExecValuationPoint tmp


let WriteExecValuationPoint (strm:Stream) (valIn:ExecValuationPoint) = 
    let tag = "515="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOrderPercent valIn =
    let tmp = System.Decimal.Parse valIn
    OrderPercent.OrderPercent tmp


let WriteOrderPercent (strm:Stream) (valIn:OrderPercent) = 
    let tag = "516="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOwnershipType (fldValIn:string) : OwnershipType = 
    match fldValIn with
    |"J" -> OwnershipType.JointInvestors
    |"T" -> OwnershipType.TenantsInCommon
    |"2" -> OwnershipType.JointTrustees
    | x -> failwith (sprintf "ReadOwnershipType unknown fix tag: %A"  x) 


let WriteOwnershipType (strm:Stream) (xxIn:OwnershipType) =
    match xxIn with
    | OwnershipType.JointInvestors -> strm.Write "517=J"B; strm.Write (delim, 0, 1)
    | OwnershipType.TenantsInCommon -> strm.Write "517=T"B; strm.Write (delim, 0, 1)
    | OwnershipType.JointTrustees -> strm.Write "517=2"B; strm.Write (delim, 0, 1)


let ReadNoContAmts valIn =
    let tmp = System.Int32.Parse valIn
    NoContAmts.NoContAmts tmp


let WriteNoContAmts (strm:Stream) (valIn:NoContAmts) = 
    let tag = "518="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadContAmtType (fldValIn:string) : ContAmtType = 
    match fldValIn with
    |"1" -> ContAmtType.CommissionAmount
    |"2" -> ContAmtType.CommissionPercent
    |"3" -> ContAmtType.InitialChargeAmount
    |"4" -> ContAmtType.InitialChargePercent
    |"5" -> ContAmtType.DiscountAmount
    |"6" -> ContAmtType.DiscountPercent
    |"7" -> ContAmtType.DilutionLevyAmount
    |"8" -> ContAmtType.DilutionLevyPercent
    |"9" -> ContAmtType.ExitChargeAmount
    | x -> failwith (sprintf "ReadContAmtType unknown fix tag: %A"  x) 


let WriteContAmtType (strm:Stream) (xxIn:ContAmtType) =
    match xxIn with
    | ContAmtType.CommissionAmount -> strm.Write "519=1"B; strm.Write (delim, 0, 1)
    | ContAmtType.CommissionPercent -> strm.Write "519=2"B; strm.Write (delim, 0, 1)
    | ContAmtType.InitialChargeAmount -> strm.Write "519=3"B; strm.Write (delim, 0, 1)
    | ContAmtType.InitialChargePercent -> strm.Write "519=4"B; strm.Write (delim, 0, 1)
    | ContAmtType.DiscountAmount -> strm.Write "519=5"B; strm.Write (delim, 0, 1)
    | ContAmtType.DiscountPercent -> strm.Write "519=6"B; strm.Write (delim, 0, 1)
    | ContAmtType.DilutionLevyAmount -> strm.Write "519=7"B; strm.Write (delim, 0, 1)
    | ContAmtType.DilutionLevyPercent -> strm.Write "519=8"B; strm.Write (delim, 0, 1)
    | ContAmtType.ExitChargeAmount -> strm.Write "519=9"B; strm.Write (delim, 0, 1)


let ReadContAmtValue valIn =
    let tmp = System.Decimal.Parse valIn
    ContAmtValue.ContAmtValue tmp


let WriteContAmtValue (strm:Stream) (valIn:ContAmtValue) = 
    let tag = "520="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadContAmtCurr valIn =
    let tmp =  valIn
    ContAmtCurr.ContAmtCurr tmp


let WriteContAmtCurr (strm:Stream) (valIn:ContAmtCurr) = 
    let tag = "521="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOwnerType (fldValIn:string) : OwnerType = 
    match fldValIn with
    |"1" -> OwnerType.IndividualInvestor
    |"2" -> OwnerType.PublicCompany
    |"3" -> OwnerType.PrivateCompany
    |"4" -> OwnerType.IndividualTrustee
    |"5" -> OwnerType.CompanyTrustee
    |"6" -> OwnerType.PensionPlan
    |"7" -> OwnerType.CustodianUnderGiftsToMinorsAct
    |"8" -> OwnerType.Trusts
    |"9" -> OwnerType.Fiduciaries
    |"10" -> OwnerType.NetworkingSubAccount
    |"11" -> OwnerType.NonProfitOrganization
    |"12" -> OwnerType.CorporateBody
    |"13" -> OwnerType.Nominee
    | x -> failwith (sprintf "ReadOwnerType unknown fix tag: %A"  x) 


let WriteOwnerType (strm:Stream) (xxIn:OwnerType) =
    match xxIn with
    | OwnerType.IndividualInvestor -> strm.Write "522=1"B; strm.Write (delim, 0, 1)
    | OwnerType.PublicCompany -> strm.Write "522=2"B; strm.Write (delim, 0, 1)
    | OwnerType.PrivateCompany -> strm.Write "522=3"B; strm.Write (delim, 0, 1)
    | OwnerType.IndividualTrustee -> strm.Write "522=4"B; strm.Write (delim, 0, 1)
    | OwnerType.CompanyTrustee -> strm.Write "522=5"B; strm.Write (delim, 0, 1)
    | OwnerType.PensionPlan -> strm.Write "522=6"B; strm.Write (delim, 0, 1)
    | OwnerType.CustodianUnderGiftsToMinorsAct -> strm.Write "522=7"B; strm.Write (delim, 0, 1)
    | OwnerType.Trusts -> strm.Write "522=8"B; strm.Write (delim, 0, 1)
    | OwnerType.Fiduciaries -> strm.Write "522=9"B; strm.Write (delim, 0, 1)
    | OwnerType.NetworkingSubAccount -> strm.Write "522=10"B; strm.Write (delim, 0, 1)
    | OwnerType.NonProfitOrganization -> strm.Write "522=11"B; strm.Write (delim, 0, 1)
    | OwnerType.CorporateBody -> strm.Write "522=12"B; strm.Write (delim, 0, 1)
    | OwnerType.Nominee -> strm.Write "522=13"B; strm.Write (delim, 0, 1)


let ReadPartySubID valIn =
    let tmp =  valIn
    PartySubID.PartySubID tmp


let WritePartySubID (strm:Stream) (valIn:PartySubID) = 
    let tag = "523="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNestedPartyID valIn =
    let tmp =  valIn
    NestedPartyID.NestedPartyID tmp


let WriteNestedPartyID (strm:Stream) (valIn:NestedPartyID) = 
    let tag = "524="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNestedPartyIDSource valIn =
    let tmp = System.Int32.Parse valIn
    NestedPartyIDSource.NestedPartyIDSource tmp


let WriteNestedPartyIDSource (strm:Stream) (valIn:NestedPartyIDSource) = 
    let tag = "525="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecondaryClOrdID valIn =
    let tmp =  valIn
    SecondaryClOrdID.SecondaryClOrdID tmp


let WriteSecondaryClOrdID (strm:Stream) (valIn:SecondaryClOrdID) = 
    let tag = "526="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecondaryExecID valIn =
    let tmp =  valIn
    SecondaryExecID.SecondaryExecID tmp


let WriteSecondaryExecID (strm:Stream) (valIn:SecondaryExecID) = 
    let tag = "527="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOrderCapacity (fldValIn:string) : OrderCapacity = 
    match fldValIn with
    |"A" -> OrderCapacity.Agency
    |"G" -> OrderCapacity.Proprietary
    |"I" -> OrderCapacity.Individual
    |"P" -> OrderCapacity.Principal
    |"R" -> OrderCapacity.RisklessPrincipal
    |"W" -> OrderCapacity.AgentForOtherMember
    | x -> failwith (sprintf "ReadOrderCapacity unknown fix tag: %A"  x) 


let WriteOrderCapacity (strm:Stream) (xxIn:OrderCapacity) =
    match xxIn with
    | OrderCapacity.Agency -> strm.Write "528=A"B; strm.Write (delim, 0, 1)
    | OrderCapacity.Proprietary -> strm.Write "528=G"B; strm.Write (delim, 0, 1)
    | OrderCapacity.Individual -> strm.Write "528=I"B; strm.Write (delim, 0, 1)
    | OrderCapacity.Principal -> strm.Write "528=P"B; strm.Write (delim, 0, 1)
    | OrderCapacity.RisklessPrincipal -> strm.Write "528=R"B; strm.Write (delim, 0, 1)
    | OrderCapacity.AgentForOtherMember -> strm.Write "528=W"B; strm.Write (delim, 0, 1)


let ReadOrderRestrictions (fldValIn:string) : OrderRestrictions = 
    match fldValIn with
    |"1" -> OrderRestrictions.ProgramTrade
    |"2" -> OrderRestrictions.IndexArbitrage
    |"3" -> OrderRestrictions.NonIndexArbitrage
    |"4" -> OrderRestrictions.CompetingMarketMaker
    |"5" -> OrderRestrictions.ActingAsMarketMakerOrSpecialistInTheSecurity
    |"6" -> OrderRestrictions.ActingAsMarketMakerOrSpecialistInTheUnderlyingSecurityOfADerivativeSecurity
    |"7" -> OrderRestrictions.ForeignEntity
    |"8" -> OrderRestrictions.ExternalMarketParticipant
    |"9" -> OrderRestrictions.ExternalInterConnectedMarketLinkage
    |"A" -> OrderRestrictions.RisklessArbitrage
    | x -> failwith (sprintf "ReadOrderRestrictions unknown fix tag: %A"  x) 


let WriteOrderRestrictions (strm:Stream) (xxIn:OrderRestrictions) =
    match xxIn with
    | OrderRestrictions.ProgramTrade -> strm.Write "529=1"B; strm.Write (delim, 0, 1)
    | OrderRestrictions.IndexArbitrage -> strm.Write "529=2"B; strm.Write (delim, 0, 1)
    | OrderRestrictions.NonIndexArbitrage -> strm.Write "529=3"B; strm.Write (delim, 0, 1)
    | OrderRestrictions.CompetingMarketMaker -> strm.Write "529=4"B; strm.Write (delim, 0, 1)
    | OrderRestrictions.ActingAsMarketMakerOrSpecialistInTheSecurity -> strm.Write "529=5"B; strm.Write (delim, 0, 1)
    | OrderRestrictions.ActingAsMarketMakerOrSpecialistInTheUnderlyingSecurityOfADerivativeSecurity -> strm.Write "529=6"B; strm.Write (delim, 0, 1)
    | OrderRestrictions.ForeignEntity -> strm.Write "529=7"B; strm.Write (delim, 0, 1)
    | OrderRestrictions.ExternalMarketParticipant -> strm.Write "529=8"B; strm.Write (delim, 0, 1)
    | OrderRestrictions.ExternalInterConnectedMarketLinkage -> strm.Write "529=9"B; strm.Write (delim, 0, 1)
    | OrderRestrictions.RisklessArbitrage -> strm.Write "529=A"B; strm.Write (delim, 0, 1)


let ReadMassCancelRequestType (fldValIn:string) : MassCancelRequestType = 
    match fldValIn with
    |"1" -> MassCancelRequestType.CancelOrdersForASecurity
    |"2" -> MassCancelRequestType.CancelOrdersForAnUnderlyingSecurity
    |"3" -> MassCancelRequestType.CancelOrdersForAProduct
    |"4" -> MassCancelRequestType.CancelOrdersForACficode
    |"5" -> MassCancelRequestType.CancelOrdersForASecuritytype
    |"6" -> MassCancelRequestType.CancelOrdersForATradingSession
    |"7" -> MassCancelRequestType.CancelAllOrders
    | x -> failwith (sprintf "ReadMassCancelRequestType unknown fix tag: %A"  x) 


let WriteMassCancelRequestType (strm:Stream) (xxIn:MassCancelRequestType) =
    match xxIn with
    | MassCancelRequestType.CancelOrdersForASecurity -> strm.Write "530=1"B; strm.Write (delim, 0, 1)
    | MassCancelRequestType.CancelOrdersForAnUnderlyingSecurity -> strm.Write "530=2"B; strm.Write (delim, 0, 1)
    | MassCancelRequestType.CancelOrdersForAProduct -> strm.Write "530=3"B; strm.Write (delim, 0, 1)
    | MassCancelRequestType.CancelOrdersForACficode -> strm.Write "530=4"B; strm.Write (delim, 0, 1)
    | MassCancelRequestType.CancelOrdersForASecuritytype -> strm.Write "530=5"B; strm.Write (delim, 0, 1)
    | MassCancelRequestType.CancelOrdersForATradingSession -> strm.Write "530=6"B; strm.Write (delim, 0, 1)
    | MassCancelRequestType.CancelAllOrders -> strm.Write "530=7"B; strm.Write (delim, 0, 1)


let ReadMassCancelResponse (fldValIn:string) : MassCancelResponse = 
    match fldValIn with
    |"0" -> MassCancelResponse.CancelRequestRejected
    |"1" -> MassCancelResponse.CancelOrdersForASecurity
    |"2" -> MassCancelResponse.CancelOrdersForAnUnderlyingSecurity
    |"3" -> MassCancelResponse.CancelOrdersForAProduct
    |"4" -> MassCancelResponse.CancelOrdersForACficode
    |"5" -> MassCancelResponse.CancelOrdersForASecuritytype
    |"6" -> MassCancelResponse.CancelOrdersForATradingSession
    |"7" -> MassCancelResponse.CancelAllOrders
    | x -> failwith (sprintf "ReadMassCancelResponse unknown fix tag: %A"  x) 


let WriteMassCancelResponse (strm:Stream) (xxIn:MassCancelResponse) =
    match xxIn with
    | MassCancelResponse.CancelRequestRejected -> strm.Write "531=0"B; strm.Write (delim, 0, 1)
    | MassCancelResponse.CancelOrdersForASecurity -> strm.Write "531=1"B; strm.Write (delim, 0, 1)
    | MassCancelResponse.CancelOrdersForAnUnderlyingSecurity -> strm.Write "531=2"B; strm.Write (delim, 0, 1)
    | MassCancelResponse.CancelOrdersForAProduct -> strm.Write "531=3"B; strm.Write (delim, 0, 1)
    | MassCancelResponse.CancelOrdersForACficode -> strm.Write "531=4"B; strm.Write (delim, 0, 1)
    | MassCancelResponse.CancelOrdersForASecuritytype -> strm.Write "531=5"B; strm.Write (delim, 0, 1)
    | MassCancelResponse.CancelOrdersForATradingSession -> strm.Write "531=6"B; strm.Write (delim, 0, 1)
    | MassCancelResponse.CancelAllOrders -> strm.Write "531=7"B; strm.Write (delim, 0, 1)


let ReadMassCancelRejectReason (fldValIn:string) : MassCancelRejectReason = 
    match fldValIn with
    |"0" -> MassCancelRejectReason.MassCancelNotSupported
    |"1" -> MassCancelRejectReason.InvalidOrUnknownSecurity
    |"2" -> MassCancelRejectReason.InvalidOrUnknownUnderlying
    |"3" -> MassCancelRejectReason.InvalidOrUnknownProduct
    |"4" -> MassCancelRejectReason.InvalidOrUnknownCficode
    |"5" -> MassCancelRejectReason.InvalidOrUnknownSecurityType
    |"6" -> MassCancelRejectReason.InvalidOrUnknownTradingSession
    |"99" -> MassCancelRejectReason.Other
    | x -> failwith (sprintf "ReadMassCancelRejectReason unknown fix tag: %A"  x) 


let WriteMassCancelRejectReason (strm:Stream) (xxIn:MassCancelRejectReason) =
    match xxIn with
    | MassCancelRejectReason.MassCancelNotSupported -> strm.Write "532=0"B; strm.Write (delim, 0, 1)
    | MassCancelRejectReason.InvalidOrUnknownSecurity -> strm.Write "532=1"B; strm.Write (delim, 0, 1)
    | MassCancelRejectReason.InvalidOrUnknownUnderlying -> strm.Write "532=2"B; strm.Write (delim, 0, 1)
    | MassCancelRejectReason.InvalidOrUnknownProduct -> strm.Write "532=3"B; strm.Write (delim, 0, 1)
    | MassCancelRejectReason.InvalidOrUnknownCficode -> strm.Write "532=4"B; strm.Write (delim, 0, 1)
    | MassCancelRejectReason.InvalidOrUnknownSecurityType -> strm.Write "532=5"B; strm.Write (delim, 0, 1)
    | MassCancelRejectReason.InvalidOrUnknownTradingSession -> strm.Write "532=6"B; strm.Write (delim, 0, 1)
    | MassCancelRejectReason.Other -> strm.Write "532=99"B; strm.Write (delim, 0, 1)


let ReadTotalAffectedOrders valIn =
    let tmp = System.Int32.Parse valIn
    TotalAffectedOrders.TotalAffectedOrders tmp


let WriteTotalAffectedOrders (strm:Stream) (valIn:TotalAffectedOrders) = 
    let tag = "533="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoAffectedOrders valIn =
    let tmp = System.Int32.Parse valIn
    NoAffectedOrders.NoAffectedOrders tmp


let WriteNoAffectedOrders (strm:Stream) (valIn:NoAffectedOrders) = 
    let tag = "534="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAffectedOrderID valIn =
    let tmp =  valIn
    AffectedOrderID.AffectedOrderID tmp


let WriteAffectedOrderID (strm:Stream) (valIn:AffectedOrderID) = 
    let tag = "535="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAffectedSecondaryOrderID valIn =
    let tmp =  valIn
    AffectedSecondaryOrderID.AffectedSecondaryOrderID tmp


let WriteAffectedSecondaryOrderID (strm:Stream) (valIn:AffectedSecondaryOrderID) = 
    let tag = "536="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuoteType (fldValIn:string) : QuoteType = 
    match fldValIn with
    |"0" -> QuoteType.Indicative
    |"1" -> QuoteType.Tradeable
    |"2" -> QuoteType.RestrictedTradeable
    |"3" -> QuoteType.Counter
    | x -> failwith (sprintf "ReadQuoteType unknown fix tag: %A"  x) 


let WriteQuoteType (strm:Stream) (xxIn:QuoteType) =
    match xxIn with
    | QuoteType.Indicative -> strm.Write "537=0"B; strm.Write (delim, 0, 1)
    | QuoteType.Tradeable -> strm.Write "537=1"B; strm.Write (delim, 0, 1)
    | QuoteType.RestrictedTradeable -> strm.Write "537=2"B; strm.Write (delim, 0, 1)
    | QuoteType.Counter -> strm.Write "537=3"B; strm.Write (delim, 0, 1)


let ReadNestedPartyRole valIn =
    let tmp = System.Int32.Parse valIn
    NestedPartyRole.NestedPartyRole tmp


let WriteNestedPartyRole (strm:Stream) (valIn:NestedPartyRole) = 
    let tag = "538="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoNestedPartyIDs valIn =
    let tmp = System.Int32.Parse valIn
    NoNestedPartyIDs.NoNestedPartyIDs tmp


let WriteNoNestedPartyIDs (strm:Stream) (valIn:NoNestedPartyIDs) = 
    let tag = "539="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTotalAccruedInterestAmt valIn =
    let tmp = System.Int32.Parse valIn
    TotalAccruedInterestAmt.TotalAccruedInterestAmt tmp


let WriteTotalAccruedInterestAmt (strm:Stream) (valIn:TotalAccruedInterestAmt) = 
    let tag = "540="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMaturityDate valIn =
    let tmp =  valIn
    MaturityDate.MaturityDate tmp


let WriteMaturityDate (strm:Stream) (valIn:MaturityDate) = 
    let tag = "541="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingMaturityDate valIn =
    let tmp =  valIn
    UnderlyingMaturityDate.UnderlyingMaturityDate tmp


let WriteUnderlyingMaturityDate (strm:Stream) (valIn:UnderlyingMaturityDate) = 
    let tag = "542="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadInstrRegistry valIn =
    let tmp =  valIn
    InstrRegistry.InstrRegistry tmp


let WriteInstrRegistry (strm:Stream) (valIn:InstrRegistry) = 
    let tag = "543="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCashMargin (fldValIn:string) : CashMargin = 
    match fldValIn with
    |"1" -> CashMargin.Cash
    |"2" -> CashMargin.MarginOpen
    |"3" -> CashMargin.MarginClose
    | x -> failwith (sprintf "ReadCashMargin unknown fix tag: %A"  x) 


let WriteCashMargin (strm:Stream) (xxIn:CashMargin) =
    match xxIn with
    | CashMargin.Cash -> strm.Write "544=1"B; strm.Write (delim, 0, 1)
    | CashMargin.MarginOpen -> strm.Write "544=2"B; strm.Write (delim, 0, 1)
    | CashMargin.MarginClose -> strm.Write "544=3"B; strm.Write (delim, 0, 1)


let ReadNestedPartySubID valIn =
    let tmp =  valIn
    NestedPartySubID.NestedPartySubID tmp


let WriteNestedPartySubID (strm:Stream) (valIn:NestedPartySubID) = 
    let tag = "545="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadScope (fldValIn:string) : Scope = 
    match fldValIn with
    |"1" -> Scope.Local
    |"2" -> Scope.National
    |"3" -> Scope.Global
    | x -> failwith (sprintf "ReadScope unknown fix tag: %A"  x) 


let WriteScope (strm:Stream) (xxIn:Scope) =
    match xxIn with
    | Scope.Local -> strm.Write "546=1"B; strm.Write (delim, 0, 1)
    | Scope.National -> strm.Write "546=2"B; strm.Write (delim, 0, 1)
    | Scope.Global -> strm.Write "546=3"B; strm.Write (delim, 0, 1)


let ReadMDImplicitDelete valIn =
    let tmp = System.Boolean.Parse valIn
    MDImplicitDelete.MDImplicitDelete tmp


let WriteMDImplicitDelete (strm:Stream) (valIn:MDImplicitDelete) = 
    let tag = "547="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCrossID valIn =
    let tmp =  valIn
    CrossID.CrossID tmp


let WriteCrossID (strm:Stream) (valIn:CrossID) = 
    let tag = "548="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCrossType (fldValIn:string) : CrossType = 
    match fldValIn with
    |"1" -> CrossType.CrossTradeWhichIsExecutedCompletelyOrNot
    |"2" -> CrossType.CrossTradeWhichIsExecutedPartiallyAndTheRestIsCancelled
    |"3" -> CrossType.CrossTradeWhichIsPartiallyExecutedWithTheUnfilledPortionsRemainingActive
    |"4" -> CrossType.CrossTradeIsExecutedWithExistingOrdersWithTheSamePrice
    | x -> failwith (sprintf "ReadCrossType unknown fix tag: %A"  x) 


let WriteCrossType (strm:Stream) (xxIn:CrossType) =
    match xxIn with
    | CrossType.CrossTradeWhichIsExecutedCompletelyOrNot -> strm.Write "549=1"B; strm.Write (delim, 0, 1)
    | CrossType.CrossTradeWhichIsExecutedPartiallyAndTheRestIsCancelled -> strm.Write "549=2"B; strm.Write (delim, 0, 1)
    | CrossType.CrossTradeWhichIsPartiallyExecutedWithTheUnfilledPortionsRemainingActive -> strm.Write "549=3"B; strm.Write (delim, 0, 1)
    | CrossType.CrossTradeIsExecutedWithExistingOrdersWithTheSamePrice -> strm.Write "549=4"B; strm.Write (delim, 0, 1)


let ReadCrossPrioritization (fldValIn:string) : CrossPrioritization = 
    match fldValIn with
    |"0" -> CrossPrioritization.NNone
    |"1" -> CrossPrioritization.BuySideIsPrioritized
    |"2" -> CrossPrioritization.SellSideIsPrioritized
    | x -> failwith (sprintf "ReadCrossPrioritization unknown fix tag: %A"  x) 


let WriteCrossPrioritization (strm:Stream) (xxIn:CrossPrioritization) =
    match xxIn with
    | CrossPrioritization.NNone -> strm.Write "550=0"B; strm.Write (delim, 0, 1)
    | CrossPrioritization.BuySideIsPrioritized -> strm.Write "550=1"B; strm.Write (delim, 0, 1)
    | CrossPrioritization.SellSideIsPrioritized -> strm.Write "550=2"B; strm.Write (delim, 0, 1)


let ReadOrigCrossID valIn =
    let tmp =  valIn
    OrigCrossID.OrigCrossID tmp


let WriteOrigCrossID (strm:Stream) (valIn:OrigCrossID) = 
    let tag = "551="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoSides (fldValIn:string) : NoSides = 
    match fldValIn with
    |"1" -> NoSides.OneSide
    |"2" -> NoSides.BothSides
    | x -> failwith (sprintf "ReadNoSides unknown fix tag: %A"  x) 


let WriteNoSides (strm:Stream) (xxIn:NoSides) =
    match xxIn with
    | NoSides.OneSide -> strm.Write "552=1"B; strm.Write (delim, 0, 1)
    | NoSides.BothSides -> strm.Write "552=2"B; strm.Write (delim, 0, 1)


let ReadUsername valIn =
    let tmp =  valIn
    Username.Username tmp


let WriteUsername (strm:Stream) (valIn:Username) = 
    let tag = "553="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPassword valIn =
    let tmp =  valIn
    Password.Password tmp


let WritePassword (strm:Stream) (valIn:Password) = 
    let tag = "554="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoLegs valIn =
    let tmp = System.Int32.Parse valIn
    NoLegs.NoLegs tmp


let WriteNoLegs (strm:Stream) (valIn:NoLegs) = 
    let tag = "555="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegCurrency valIn =
    let tmp =  valIn
    LegCurrency.LegCurrency tmp


let WriteLegCurrency (strm:Stream) (valIn:LegCurrency) = 
    let tag = "556="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTotNoSecurityTypes valIn =
    let tmp = System.Int32.Parse valIn
    TotNoSecurityTypes.TotNoSecurityTypes tmp


let WriteTotNoSecurityTypes (strm:Stream) (valIn:TotNoSecurityTypes) = 
    let tag = "557="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoSecurityTypes valIn =
    let tmp = System.Int32.Parse valIn
    NoSecurityTypes.NoSecurityTypes tmp


let WriteNoSecurityTypes (strm:Stream) (valIn:NoSecurityTypes) = 
    let tag = "558="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecurityListRequestType (fldValIn:string) : SecurityListRequestType = 
    match fldValIn with
    |"0" -> SecurityListRequestType.Symbol
    |"1" -> SecurityListRequestType.SecuritytypeAndOrCficode
    |"2" -> SecurityListRequestType.Product
    |"3" -> SecurityListRequestType.Tradingsessionid
    |"4" -> SecurityListRequestType.AllSecurities
    | x -> failwith (sprintf "ReadSecurityListRequestType unknown fix tag: %A"  x) 


let WriteSecurityListRequestType (strm:Stream) (xxIn:SecurityListRequestType) =
    match xxIn with
    | SecurityListRequestType.Symbol -> strm.Write "559=0"B; strm.Write (delim, 0, 1)
    | SecurityListRequestType.SecuritytypeAndOrCficode -> strm.Write "559=1"B; strm.Write (delim, 0, 1)
    | SecurityListRequestType.Product -> strm.Write "559=2"B; strm.Write (delim, 0, 1)
    | SecurityListRequestType.Tradingsessionid -> strm.Write "559=3"B; strm.Write (delim, 0, 1)
    | SecurityListRequestType.AllSecurities -> strm.Write "559=4"B; strm.Write (delim, 0, 1)


let ReadSecurityRequestResult (fldValIn:string) : SecurityRequestResult = 
    match fldValIn with
    |"0" -> SecurityRequestResult.ValidRequest
    |"1" -> SecurityRequestResult.InvalidOrUnsupportedRequest
    |"2" -> SecurityRequestResult.NoInstrumentsFoundThatMatchSelectionCriteria
    |"3" -> SecurityRequestResult.NotAuthorizedToRetrieveInstrumentData
    |"4" -> SecurityRequestResult.InstrumentDataTemporarilyUnavailable
    |"5" -> SecurityRequestResult.RequestForInstrumentDataNotSupported
    | x -> failwith (sprintf "ReadSecurityRequestResult unknown fix tag: %A"  x) 


let WriteSecurityRequestResult (strm:Stream) (xxIn:SecurityRequestResult) =
    match xxIn with
    | SecurityRequestResult.ValidRequest -> strm.Write "560=0"B; strm.Write (delim, 0, 1)
    | SecurityRequestResult.InvalidOrUnsupportedRequest -> strm.Write "560=1"B; strm.Write (delim, 0, 1)
    | SecurityRequestResult.NoInstrumentsFoundThatMatchSelectionCriteria -> strm.Write "560=2"B; strm.Write (delim, 0, 1)
    | SecurityRequestResult.NotAuthorizedToRetrieveInstrumentData -> strm.Write "560=3"B; strm.Write (delim, 0, 1)
    | SecurityRequestResult.InstrumentDataTemporarilyUnavailable -> strm.Write "560=4"B; strm.Write (delim, 0, 1)
    | SecurityRequestResult.RequestForInstrumentDataNotSupported -> strm.Write "560=5"B; strm.Write (delim, 0, 1)


let ReadRoundLot valIn =
    let tmp = System.Decimal.Parse valIn
    RoundLot.RoundLot tmp


let WriteRoundLot (strm:Stream) (valIn:RoundLot) = 
    let tag = "561="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMinTradeVol valIn =
    let tmp = System.Decimal.Parse valIn
    MinTradeVol.MinTradeVol tmp


let WriteMinTradeVol (strm:Stream) (valIn:MinTradeVol) = 
    let tag = "562="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMultiLegRptTypeReq (fldValIn:string) : MultiLegRptTypeReq = 
    match fldValIn with
    |"0" -> MultiLegRptTypeReq.ReportByMulitlegSecurityOnly
    |"1" -> MultiLegRptTypeReq.ReportByMultilegSecurityAndByInstrumentLegsBelongingToTheMultilegSecurity
    |"2" -> MultiLegRptTypeReq.ReportByInstrumentLegsBelongingToTheMultilegSecurityOnly
    | x -> failwith (sprintf "ReadMultiLegRptTypeReq unknown fix tag: %A"  x) 


let WriteMultiLegRptTypeReq (strm:Stream) (xxIn:MultiLegRptTypeReq) =
    match xxIn with
    | MultiLegRptTypeReq.ReportByMulitlegSecurityOnly -> strm.Write "563=0"B; strm.Write (delim, 0, 1)
    | MultiLegRptTypeReq.ReportByMultilegSecurityAndByInstrumentLegsBelongingToTheMultilegSecurity -> strm.Write "563=1"B; strm.Write (delim, 0, 1)
    | MultiLegRptTypeReq.ReportByInstrumentLegsBelongingToTheMultilegSecurityOnly -> strm.Write "563=2"B; strm.Write (delim, 0, 1)


let ReadLegPositionEffect valIn =
    let tmp = System.Int32.Parse valIn
    LegPositionEffect.LegPositionEffect tmp


let WriteLegPositionEffect (strm:Stream) (valIn:LegPositionEffect) = 
    let tag = "564="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegCoveredOrUncovered valIn =
    let tmp = System.Int32.Parse valIn
    LegCoveredOrUncovered.LegCoveredOrUncovered tmp


let WriteLegCoveredOrUncovered (strm:Stream) (valIn:LegCoveredOrUncovered) = 
    let tag = "565="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegPrice valIn =
    let tmp = System.Decimal.Parse valIn
    LegPrice.LegPrice tmp


let WriteLegPrice (strm:Stream) (valIn:LegPrice) = 
    let tag = "566="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradSesStatusRejReason (fldValIn:string) : TradSesStatusRejReason = 
    match fldValIn with
    |"1" -> TradSesStatusRejReason.UnknownOrInvalidTradingsessionid
    | x -> failwith (sprintf "ReadTradSesStatusRejReason unknown fix tag: %A"  x) 


let WriteTradSesStatusRejReason (strm:Stream) (xxIn:TradSesStatusRejReason) =
    match xxIn with
    | TradSesStatusRejReason.UnknownOrInvalidTradingsessionid -> strm.Write "567=1"B; strm.Write (delim, 0, 1)


let ReadTradeRequestID valIn =
    let tmp =  valIn
    TradeRequestID.TradeRequestID tmp


let WriteTradeRequestID (strm:Stream) (valIn:TradeRequestID) = 
    let tag = "568="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradeRequestType (fldValIn:string) : TradeRequestType = 
    match fldValIn with
    |"0" -> TradeRequestType.AllTrades
    |"1" -> TradeRequestType.MatchedTradesMatchingCriteriaProvidedOnRequest
    |"2" -> TradeRequestType.UnmatchedTradesThatMatchCriteria
    |"3" -> TradeRequestType.UnreportedTradesThatMatchCriteria
    |"4" -> TradeRequestType.AdvisoriesThatMatchCriteria
    | x -> failwith (sprintf "ReadTradeRequestType unknown fix tag: %A"  x) 


let WriteTradeRequestType (strm:Stream) (xxIn:TradeRequestType) =
    match xxIn with
    | TradeRequestType.AllTrades -> strm.Write "569=0"B; strm.Write (delim, 0, 1)
    | TradeRequestType.MatchedTradesMatchingCriteriaProvidedOnRequest -> strm.Write "569=1"B; strm.Write (delim, 0, 1)
    | TradeRequestType.UnmatchedTradesThatMatchCriteria -> strm.Write "569=2"B; strm.Write (delim, 0, 1)
    | TradeRequestType.UnreportedTradesThatMatchCriteria -> strm.Write "569=3"B; strm.Write (delim, 0, 1)
    | TradeRequestType.AdvisoriesThatMatchCriteria -> strm.Write "569=4"B; strm.Write (delim, 0, 1)


let ReadPreviouslyReported valIn =
    let tmp = System.Boolean.Parse valIn
    PreviouslyReported.PreviouslyReported tmp


let WritePreviouslyReported (strm:Stream) (valIn:PreviouslyReported) = 
    let tag = "570="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradeReportID valIn =
    let tmp =  valIn
    TradeReportID.TradeReportID tmp


let WriteTradeReportID (strm:Stream) (valIn:TradeReportID) = 
    let tag = "571="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradeReportRefID valIn =
    let tmp =  valIn
    TradeReportRefID.TradeReportRefID tmp


let WriteTradeReportRefID (strm:Stream) (valIn:TradeReportRefID) = 
    let tag = "572="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMatchStatus (fldValIn:string) : MatchStatus = 
    match fldValIn with
    |"0" -> MatchStatus.ComparedMatchedOrAffirmed
    |"1" -> MatchStatus.UncomparedUnmatchedOrUnaffirmed
    |"2" -> MatchStatus.AdvisoryOrAlert
    | x -> failwith (sprintf "ReadMatchStatus unknown fix tag: %A"  x) 


let WriteMatchStatus (strm:Stream) (xxIn:MatchStatus) =
    match xxIn with
    | MatchStatus.ComparedMatchedOrAffirmed -> strm.Write "573=0"B; strm.Write (delim, 0, 1)
    | MatchStatus.UncomparedUnmatchedOrUnaffirmed -> strm.Write "573=1"B; strm.Write (delim, 0, 1)
    | MatchStatus.AdvisoryOrAlert -> strm.Write "573=2"B; strm.Write (delim, 0, 1)


let ReadMatchType valIn =
    let tmp =  valIn
    MatchType.MatchType tmp


let WriteMatchType (strm:Stream) (valIn:MatchType) = 
    let tag = "574="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOddLot valIn =
    let tmp = System.Boolean.Parse valIn
    OddLot.OddLot tmp


let WriteOddLot (strm:Stream) (valIn:OddLot) = 
    let tag = "575="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoClearingInstructions valIn =
    let tmp = System.Int32.Parse valIn
    NoClearingInstructions.NoClearingInstructions tmp


let WriteNoClearingInstructions (strm:Stream) (valIn:NoClearingInstructions) = 
    let tag = "576="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadClearingInstruction (fldValIn:string) : ClearingInstruction = 
    match fldValIn with
    |"0" -> ClearingInstruction.ProcessNormally
    |"1" -> ClearingInstruction.ExcludeFromAllNetting
    |"2" -> ClearingInstruction.BilateralNettingOnly
    |"3" -> ClearingInstruction.ExClearing
    |"4" -> ClearingInstruction.SpecialTrade
    |"5" -> ClearingInstruction.MultilateralNetting
    |"6" -> ClearingInstruction.ClearAgainstCentralCounterparty
    |"7" -> ClearingInstruction.ExcludeFromCentralCounterparty
    |"8" -> ClearingInstruction.ManualMode
    |"9" -> ClearingInstruction.AutomaticPostingMode
    |"10" -> ClearingInstruction.AutomaticGiveUpMode
    |"11" -> ClearingInstruction.QualifiedServiceRepresentative
    |"12" -> ClearingInstruction.CustomerTrade
    |"13" -> ClearingInstruction.SelfClearing
    | x -> failwith (sprintf "ReadClearingInstruction unknown fix tag: %A"  x) 


let WriteClearingInstruction (strm:Stream) (xxIn:ClearingInstruction) =
    match xxIn with
    | ClearingInstruction.ProcessNormally -> strm.Write "577=0"B; strm.Write (delim, 0, 1)
    | ClearingInstruction.ExcludeFromAllNetting -> strm.Write "577=1"B; strm.Write (delim, 0, 1)
    | ClearingInstruction.BilateralNettingOnly -> strm.Write "577=2"B; strm.Write (delim, 0, 1)
    | ClearingInstruction.ExClearing -> strm.Write "577=3"B; strm.Write (delim, 0, 1)
    | ClearingInstruction.SpecialTrade -> strm.Write "577=4"B; strm.Write (delim, 0, 1)
    | ClearingInstruction.MultilateralNetting -> strm.Write "577=5"B; strm.Write (delim, 0, 1)
    | ClearingInstruction.ClearAgainstCentralCounterparty -> strm.Write "577=6"B; strm.Write (delim, 0, 1)
    | ClearingInstruction.ExcludeFromCentralCounterparty -> strm.Write "577=7"B; strm.Write (delim, 0, 1)
    | ClearingInstruction.ManualMode -> strm.Write "577=8"B; strm.Write (delim, 0, 1)
    | ClearingInstruction.AutomaticPostingMode -> strm.Write "577=9"B; strm.Write (delim, 0, 1)
    | ClearingInstruction.AutomaticGiveUpMode -> strm.Write "577=10"B; strm.Write (delim, 0, 1)
    | ClearingInstruction.QualifiedServiceRepresentative -> strm.Write "577=11"B; strm.Write (delim, 0, 1)
    | ClearingInstruction.CustomerTrade -> strm.Write "577=12"B; strm.Write (delim, 0, 1)
    | ClearingInstruction.SelfClearing -> strm.Write "577=13"B; strm.Write (delim, 0, 1)


let ReadTradeInputSource valIn =
    let tmp =  valIn
    TradeInputSource.TradeInputSource tmp


let WriteTradeInputSource (strm:Stream) (valIn:TradeInputSource) = 
    let tag = "578="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradeInputDevice valIn =
    let tmp =  valIn
    TradeInputDevice.TradeInputDevice tmp


let WriteTradeInputDevice (strm:Stream) (valIn:TradeInputDevice) = 
    let tag = "579="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoDates valIn =
    let tmp = System.Int32.Parse valIn
    NoDates.NoDates tmp


let WriteNoDates (strm:Stream) (valIn:NoDates) = 
    let tag = "580="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAccountType (fldValIn:string) : AccountType = 
    match fldValIn with
    |"1" -> AccountType.AccountIsCarriedOnCustomerSideOfBooks
    |"2" -> AccountType.AccountIsCarriedOnNonCustomerSideOfBooks
    |"3" -> AccountType.HouseTrader
    |"4" -> AccountType.FloorTrader
    |"6" -> AccountType.AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined
    |"7" -> AccountType.AccountIsHouseTraderAndIsCrossMargined
    |"8" -> AccountType.JointBackofficeAccount
    | x -> failwith (sprintf "ReadAccountType unknown fix tag: %A"  x) 


let WriteAccountType (strm:Stream) (xxIn:AccountType) =
    match xxIn with
    | AccountType.AccountIsCarriedOnCustomerSideOfBooks -> strm.Write "581=1"B; strm.Write (delim, 0, 1)
    | AccountType.AccountIsCarriedOnNonCustomerSideOfBooks -> strm.Write "581=2"B; strm.Write (delim, 0, 1)
    | AccountType.HouseTrader -> strm.Write "581=3"B; strm.Write (delim, 0, 1)
    | AccountType.FloorTrader -> strm.Write "581=4"B; strm.Write (delim, 0, 1)
    | AccountType.AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined -> strm.Write "581=6"B; strm.Write (delim, 0, 1)
    | AccountType.AccountIsHouseTraderAndIsCrossMargined -> strm.Write "581=7"B; strm.Write (delim, 0, 1)
    | AccountType.JointBackofficeAccount -> strm.Write "581=8"B; strm.Write (delim, 0, 1)


let ReadCustOrderCapacity (fldValIn:string) : CustOrderCapacity = 
    match fldValIn with
    |"1" -> CustOrderCapacity.MemberTradingForTheirOwnAccount
    |"2" -> CustOrderCapacity.ClearingFirmTradingForItsProprietaryAccount
    |"3" -> CustOrderCapacity.MemberTradingForAnotherMember
    |"4" -> CustOrderCapacity.AllOther
    | x -> failwith (sprintf "ReadCustOrderCapacity unknown fix tag: %A"  x) 


let WriteCustOrderCapacity (strm:Stream) (xxIn:CustOrderCapacity) =
    match xxIn with
    | CustOrderCapacity.MemberTradingForTheirOwnAccount -> strm.Write "582=1"B; strm.Write (delim, 0, 1)
    | CustOrderCapacity.ClearingFirmTradingForItsProprietaryAccount -> strm.Write "582=2"B; strm.Write (delim, 0, 1)
    | CustOrderCapacity.MemberTradingForAnotherMember -> strm.Write "582=3"B; strm.Write (delim, 0, 1)
    | CustOrderCapacity.AllOther -> strm.Write "582=4"B; strm.Write (delim, 0, 1)


let ReadClOrdLinkID valIn =
    let tmp =  valIn
    ClOrdLinkID.ClOrdLinkID tmp


let WriteClOrdLinkID (strm:Stream) (valIn:ClOrdLinkID) = 
    let tag = "583="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMassStatusReqID valIn =
    let tmp =  valIn
    MassStatusReqID.MassStatusReqID tmp


let WriteMassStatusReqID (strm:Stream) (valIn:MassStatusReqID) = 
    let tag = "584="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMassStatusReqType (fldValIn:string) : MassStatusReqType = 
    match fldValIn with
    |"1" -> MassStatusReqType.StatusForOrdersForASecurity
    |"2" -> MassStatusReqType.StatusForOrdersForAnUnderlyingSecurity
    |"3" -> MassStatusReqType.StatusForOrdersForAProduct
    |"4" -> MassStatusReqType.StatusForOrdersForACficode
    |"5" -> MassStatusReqType.StatusForOrdersForASecuritytype
    |"6" -> MassStatusReqType.StatusForOrdersForATradingSession
    |"7" -> MassStatusReqType.StatusForAllOrders
    |"8" -> MassStatusReqType.StatusForOrdersForAPartyid
    | x -> failwith (sprintf "ReadMassStatusReqType unknown fix tag: %A"  x) 


let WriteMassStatusReqType (strm:Stream) (xxIn:MassStatusReqType) =
    match xxIn with
    | MassStatusReqType.StatusForOrdersForASecurity -> strm.Write "585=1"B; strm.Write (delim, 0, 1)
    | MassStatusReqType.StatusForOrdersForAnUnderlyingSecurity -> strm.Write "585=2"B; strm.Write (delim, 0, 1)
    | MassStatusReqType.StatusForOrdersForAProduct -> strm.Write "585=3"B; strm.Write (delim, 0, 1)
    | MassStatusReqType.StatusForOrdersForACficode -> strm.Write "585=4"B; strm.Write (delim, 0, 1)
    | MassStatusReqType.StatusForOrdersForASecuritytype -> strm.Write "585=5"B; strm.Write (delim, 0, 1)
    | MassStatusReqType.StatusForOrdersForATradingSession -> strm.Write "585=6"B; strm.Write (delim, 0, 1)
    | MassStatusReqType.StatusForAllOrders -> strm.Write "585=7"B; strm.Write (delim, 0, 1)
    | MassStatusReqType.StatusForOrdersForAPartyid -> strm.Write "585=8"B; strm.Write (delim, 0, 1)


let ReadOrigOrdModTime valIn =
    let tmp =  valIn
    OrigOrdModTime.OrigOrdModTime tmp


let WriteOrigOrdModTime (strm:Stream) (valIn:OrigOrdModTime) = 
    let tag = "586="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSettlType valIn =
    let tmp = System.Int32.Parse valIn
    LegSettlType.LegSettlType tmp


let WriteLegSettlType (strm:Stream) (valIn:LegSettlType) = 
    let tag = "587="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSettlDate valIn =
    let tmp =  valIn
    LegSettlDate.LegSettlDate tmp


let WriteLegSettlDate (strm:Stream) (valIn:LegSettlDate) = 
    let tag = "588="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDayBookingInst (fldValIn:string) : DayBookingInst = 
    match fldValIn with
    |"0" -> DayBookingInst.CanTriggerBookingWithoutReferenceToTheOrderInitiator
    |"1" -> DayBookingInst.SpeakWithOrderInitiatorBeforeBooking
    |"2" -> DayBookingInst.Accumulate
    | x -> failwith (sprintf "ReadDayBookingInst unknown fix tag: %A"  x) 


let WriteDayBookingInst (strm:Stream) (xxIn:DayBookingInst) =
    match xxIn with
    | DayBookingInst.CanTriggerBookingWithoutReferenceToTheOrderInitiator -> strm.Write "589=0"B; strm.Write (delim, 0, 1)
    | DayBookingInst.SpeakWithOrderInitiatorBeforeBooking -> strm.Write "589=1"B; strm.Write (delim, 0, 1)
    | DayBookingInst.Accumulate -> strm.Write "589=2"B; strm.Write (delim, 0, 1)


let ReadBookingUnit (fldValIn:string) : BookingUnit = 
    match fldValIn with
    |"0" -> BookingUnit.EachPartialExecutionIsABookableUnit
    |"1" -> BookingUnit.AggregatePartialExecutionsOnThisOrderAndBookOneTradePerOrder
    |"2" -> BookingUnit.AggregateExecutionsForThisSymbolSideAndSettlementDate
    | x -> failwith (sprintf "ReadBookingUnit unknown fix tag: %A"  x) 


let WriteBookingUnit (strm:Stream) (xxIn:BookingUnit) =
    match xxIn with
    | BookingUnit.EachPartialExecutionIsABookableUnit -> strm.Write "590=0"B; strm.Write (delim, 0, 1)
    | BookingUnit.AggregatePartialExecutionsOnThisOrderAndBookOneTradePerOrder -> strm.Write "590=1"B; strm.Write (delim, 0, 1)
    | BookingUnit.AggregateExecutionsForThisSymbolSideAndSettlementDate -> strm.Write "590=2"B; strm.Write (delim, 0, 1)


let ReadPreallocMethod (fldValIn:string) : PreallocMethod = 
    match fldValIn with
    |"0" -> PreallocMethod.ProRata
    |"1" -> PreallocMethod.DoNotProRata
    | x -> failwith (sprintf "ReadPreallocMethod unknown fix tag: %A"  x) 


let WritePreallocMethod (strm:Stream) (xxIn:PreallocMethod) =
    match xxIn with
    | PreallocMethod.ProRata -> strm.Write "591=0"B; strm.Write (delim, 0, 1)
    | PreallocMethod.DoNotProRata -> strm.Write "591=1"B; strm.Write (delim, 0, 1)


let ReadUnderlyingCountryOfIssue valIn =
    let tmp =  valIn
    UnderlyingCountryOfIssue.UnderlyingCountryOfIssue tmp


let WriteUnderlyingCountryOfIssue (strm:Stream) (valIn:UnderlyingCountryOfIssue) = 
    let tag = "592="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingStateOrProvinceOfIssue valIn =
    let tmp =  valIn
    UnderlyingStateOrProvinceOfIssue.UnderlyingStateOrProvinceOfIssue tmp


let WriteUnderlyingStateOrProvinceOfIssue (strm:Stream) (valIn:UnderlyingStateOrProvinceOfIssue) = 
    let tag = "593="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingLocaleOfIssue valIn =
    let tmp =  valIn
    UnderlyingLocaleOfIssue.UnderlyingLocaleOfIssue tmp


let WriteUnderlyingLocaleOfIssue (strm:Stream) (valIn:UnderlyingLocaleOfIssue) = 
    let tag = "594="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingInstrRegistry valIn =
    let tmp =  valIn
    UnderlyingInstrRegistry.UnderlyingInstrRegistry tmp


let WriteUnderlyingInstrRegistry (strm:Stream) (valIn:UnderlyingInstrRegistry) = 
    let tag = "595="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegCountryOfIssue valIn =
    let tmp =  valIn
    LegCountryOfIssue.LegCountryOfIssue tmp


let WriteLegCountryOfIssue (strm:Stream) (valIn:LegCountryOfIssue) = 
    let tag = "596="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegStateOrProvinceOfIssue valIn =
    let tmp =  valIn
    LegStateOrProvinceOfIssue.LegStateOrProvinceOfIssue tmp


let WriteLegStateOrProvinceOfIssue (strm:Stream) (valIn:LegStateOrProvinceOfIssue) = 
    let tag = "597="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegLocaleOfIssue valIn =
    let tmp =  valIn
    LegLocaleOfIssue.LegLocaleOfIssue tmp


let WriteLegLocaleOfIssue (strm:Stream) (valIn:LegLocaleOfIssue) = 
    let tag = "598="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegInstrRegistry valIn =
    let tmp =  valIn
    LegInstrRegistry.LegInstrRegistry tmp


let WriteLegInstrRegistry (strm:Stream) (valIn:LegInstrRegistry) = 
    let tag = "599="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSymbol valIn =
    let tmp =  valIn
    LegSymbol.LegSymbol tmp


let WriteLegSymbol (strm:Stream) (valIn:LegSymbol) = 
    let tag = "600="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSymbolSfx valIn =
    let tmp =  valIn
    LegSymbolSfx.LegSymbolSfx tmp


let WriteLegSymbolSfx (strm:Stream) (valIn:LegSymbolSfx) = 
    let tag = "601="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSecurityID valIn =
    let tmp =  valIn
    LegSecurityID.LegSecurityID tmp


let WriteLegSecurityID (strm:Stream) (valIn:LegSecurityID) = 
    let tag = "602="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSecurityIDSource valIn =
    let tmp =  valIn
    LegSecurityIDSource.LegSecurityIDSource tmp


let WriteLegSecurityIDSource (strm:Stream) (valIn:LegSecurityIDSource) = 
    let tag = "603="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoLegSecurityAltID valIn =
    let tmp = System.Int32.Parse valIn
    NoLegSecurityAltID.NoLegSecurityAltID tmp


let WriteNoLegSecurityAltID (strm:Stream) (valIn:NoLegSecurityAltID) = 
    let tag = "604="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSecurityAltID valIn =
    let tmp =  valIn
    LegSecurityAltID.LegSecurityAltID tmp


let WriteLegSecurityAltID (strm:Stream) (valIn:LegSecurityAltID) = 
    let tag = "605="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSecurityAltIDSource valIn =
    let tmp =  valIn
    LegSecurityAltIDSource.LegSecurityAltIDSource tmp


let WriteLegSecurityAltIDSource (strm:Stream) (valIn:LegSecurityAltIDSource) = 
    let tag = "606="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegProduct valIn =
    let tmp = System.Int32.Parse valIn
    LegProduct.LegProduct tmp


let WriteLegProduct (strm:Stream) (valIn:LegProduct) = 
    let tag = "607="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegCFICode valIn =
    let tmp =  valIn
    LegCFICode.LegCFICode tmp


let WriteLegCFICode (strm:Stream) (valIn:LegCFICode) = 
    let tag = "608="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSecurityType valIn =
    let tmp =  valIn
    LegSecurityType.LegSecurityType tmp


let WriteLegSecurityType (strm:Stream) (valIn:LegSecurityType) = 
    let tag = "609="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegMaturityMonthYear valIn =
    let tmp =  valIn
    LegMaturityMonthYear.LegMaturityMonthYear tmp


let WriteLegMaturityMonthYear (strm:Stream) (valIn:LegMaturityMonthYear) = 
    let tag = "610="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegMaturityDate valIn =
    let tmp =  valIn
    LegMaturityDate.LegMaturityDate tmp


let WriteLegMaturityDate (strm:Stream) (valIn:LegMaturityDate) = 
    let tag = "611="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegStrikePrice valIn =
    let tmp = System.Decimal.Parse valIn
    LegStrikePrice.LegStrikePrice tmp


let WriteLegStrikePrice (strm:Stream) (valIn:LegStrikePrice) = 
    let tag = "612="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegOptAttribute valIn =
    let tmp = System.Int32.Parse valIn
    LegOptAttribute.LegOptAttribute tmp


let WriteLegOptAttribute (strm:Stream) (valIn:LegOptAttribute) = 
    let tag = "613="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegContractMultiplier valIn =
    let tmp = System.Decimal.Parse valIn
    LegContractMultiplier.LegContractMultiplier tmp


let WriteLegContractMultiplier (strm:Stream) (valIn:LegContractMultiplier) = 
    let tag = "614="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegCouponRate valIn =
    let tmp = System.Decimal.Parse valIn
    LegCouponRate.LegCouponRate tmp


let WriteLegCouponRate (strm:Stream) (valIn:LegCouponRate) = 
    let tag = "615="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSecurityExchange valIn =
    let tmp =  valIn
    LegSecurityExchange.LegSecurityExchange tmp


let WriteLegSecurityExchange (strm:Stream) (valIn:LegSecurityExchange) = 
    let tag = "616="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegIssuer valIn =
    let tmp =  valIn
    LegIssuer.LegIssuer tmp


let WriteLegIssuer (strm:Stream) (valIn:LegIssuer) = 
    let tag = "617="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


// compound write
let WriteEncodedLegIssuer (strm:System.IO.Stream) (fld:EncodedLegIssuer) =
    let lenTag = "618="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "619="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadEncodedLegIssuer valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "619" then failwith "invalid tag reading EncodedLegIssuer"
    if strLen <> raw.Length then failwith "mismatched string len reading EncodedLegIssuer"
    EncodedLegIssuer.EncodedLegIssuer raw


let ReadLegSecurityDesc valIn =
    let tmp =  valIn
    LegSecurityDesc.LegSecurityDesc tmp


let WriteLegSecurityDesc (strm:Stream) (valIn:LegSecurityDesc) = 
    let tag = "620="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


// compound write
let WriteEncodedLegSecurityDesc (strm:System.IO.Stream) (fld:EncodedLegSecurityDesc) =
    let lenTag = "621="B
    strm.Write lenTag
    strm.Write (ToBytes.Convert fld.Value.Length)
    strm.Write (delim, 0, 1)
    let strTag = "622="B
    strm.Write strTag
    strm.Write (ToBytes.Convert fld.Value)
    strm.Write (delim, 0, 1)


// compound read
let ReadEncodedLegSecurityDesc valIn (strm:System.IO.Stream) =
    let strLen = System.Int32.Parse valIn
    // the len has been read, next read the string
    // the tag read-in must match the expected tag
    // todo: read in strLen bytes
    let ss = CrapReadUntilDelim strm
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    if tag <> "622" then failwith "invalid tag reading EncodedLegSecurityDesc"
    if strLen <> raw.Length then failwith "mismatched string len reading EncodedLegSecurityDesc"
    EncodedLegSecurityDesc.EncodedLegSecurityDesc raw


let ReadLegRatioQty valIn =
    let tmp = System.Decimal.Parse valIn
    LegRatioQty.LegRatioQty tmp


let WriteLegRatioQty (strm:Stream) (valIn:LegRatioQty) = 
    let tag = "623="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSide valIn =
    let tmp = System.Int32.Parse valIn
    LegSide.LegSide tmp


let WriteLegSide (strm:Stream) (valIn:LegSide) = 
    let tag = "624="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradingSessionSubID valIn =
    let tmp =  valIn
    TradingSessionSubID.TradingSessionSubID tmp


let WriteTradingSessionSubID (strm:Stream) (valIn:TradingSessionSubID) = 
    let tag = "625="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocType (fldValIn:string) : AllocType = 
    match fldValIn with
    |"1" -> AllocType.Calculated
    |"2" -> AllocType.Preliminary
    |"5" -> AllocType.ReadyToBookSingleOrder
    |"7" -> AllocType.WarehouseInstruction
    |"8" -> AllocType.RequestToIntermediary
    | x -> failwith (sprintf "ReadAllocType unknown fix tag: %A"  x) 


let WriteAllocType (strm:Stream) (xxIn:AllocType) =
    match xxIn with
    | AllocType.Calculated -> strm.Write "626=1"B; strm.Write (delim, 0, 1)
    | AllocType.Preliminary -> strm.Write "626=2"B; strm.Write (delim, 0, 1)
    | AllocType.ReadyToBookSingleOrder -> strm.Write "626=5"B; strm.Write (delim, 0, 1)
    | AllocType.WarehouseInstruction -> strm.Write "626=7"B; strm.Write (delim, 0, 1)
    | AllocType.RequestToIntermediary -> strm.Write "626=8"B; strm.Write (delim, 0, 1)


let ReadNoHops valIn =
    let tmp = System.Int32.Parse valIn
    NoHops.NoHops tmp


let WriteNoHops (strm:Stream) (valIn:NoHops) = 
    let tag = "627="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadHopCompID valIn =
    let tmp =  valIn
    HopCompID.HopCompID tmp


let WriteHopCompID (strm:Stream) (valIn:HopCompID) = 
    let tag = "628="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadHopSendingTime valIn =
    let tmp =  valIn
    HopSendingTime.HopSendingTime tmp


let WriteHopSendingTime (strm:Stream) (valIn:HopSendingTime) = 
    let tag = "629="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadHopRefID valIn =
    let tmp = System.Int32.Parse valIn
    HopRefID.HopRefID tmp


let WriteHopRefID (strm:Stream) (valIn:HopRefID) = 
    let tag = "630="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMidPx valIn =
    let tmp = System.Decimal.Parse valIn
    MidPx.MidPx tmp


let WriteMidPx (strm:Stream) (valIn:MidPx) = 
    let tag = "631="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBidYield valIn =
    let tmp = System.Decimal.Parse valIn
    BidYield.BidYield tmp


let WriteBidYield (strm:Stream) (valIn:BidYield) = 
    let tag = "632="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMidYield valIn =
    let tmp = System.Decimal.Parse valIn
    MidYield.MidYield tmp


let WriteMidYield (strm:Stream) (valIn:MidYield) = 
    let tag = "633="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOfferYield valIn =
    let tmp = System.Decimal.Parse valIn
    OfferYield.OfferYield tmp


let WriteOfferYield (strm:Stream) (valIn:OfferYield) = 
    let tag = "634="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadClearingFeeIndicator (fldValIn:string) : ClearingFeeIndicator = 
    match fldValIn with
    |"B" -> ClearingFeeIndicator.CboeMember
    |"C" -> ClearingFeeIndicator.NonMemberAndCustomer
    |"E" -> ClearingFeeIndicator.EquityMemberAndClearingMember
    |"F" -> ClearingFeeIndicator.FullAndAssociateMemberTradingForOwnAccountAndAsFloorBrokers
    |"H" -> ClearingFeeIndicator.Firms106hAnd106j
    |"I" -> ClearingFeeIndicator.GimIdemAndComMembershipInterestHolders
    |"L" -> ClearingFeeIndicator.LesseeAnd106fEmployees
    |"M" -> ClearingFeeIndicator.AllOtherOwnershipTypes
    | x -> failwith (sprintf "ReadClearingFeeIndicator unknown fix tag: %A"  x) 


let WriteClearingFeeIndicator (strm:Stream) (xxIn:ClearingFeeIndicator) =
    match xxIn with
    | ClearingFeeIndicator.CboeMember -> strm.Write "635=B"B; strm.Write (delim, 0, 1)
    | ClearingFeeIndicator.NonMemberAndCustomer -> strm.Write "635=C"B; strm.Write (delim, 0, 1)
    | ClearingFeeIndicator.EquityMemberAndClearingMember -> strm.Write "635=E"B; strm.Write (delim, 0, 1)
    | ClearingFeeIndicator.FullAndAssociateMemberTradingForOwnAccountAndAsFloorBrokers -> strm.Write "635=F"B; strm.Write (delim, 0, 1)
    | ClearingFeeIndicator.Firms106hAnd106j -> strm.Write "635=H"B; strm.Write (delim, 0, 1)
    | ClearingFeeIndicator.GimIdemAndComMembershipInterestHolders -> strm.Write "635=I"B; strm.Write (delim, 0, 1)
    | ClearingFeeIndicator.LesseeAnd106fEmployees -> strm.Write "635=L"B; strm.Write (delim, 0, 1)
    | ClearingFeeIndicator.AllOtherOwnershipTypes -> strm.Write "635=M"B; strm.Write (delim, 0, 1)


let ReadWorkingIndicator valIn =
    let tmp = System.Boolean.Parse valIn
    WorkingIndicator.WorkingIndicator tmp


let WriteWorkingIndicator (strm:Stream) (valIn:WorkingIndicator) = 
    let tag = "636="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegLastPx valIn =
    let tmp = System.Decimal.Parse valIn
    LegLastPx.LegLastPx tmp


let WriteLegLastPx (strm:Stream) (valIn:LegLastPx) = 
    let tag = "637="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPriorityIndicator (fldValIn:string) : PriorityIndicator = 
    match fldValIn with
    |"0" -> PriorityIndicator.PriorityUnchanged
    |"1" -> PriorityIndicator.LostPriorityAsResultOfOrderChange
    | x -> failwith (sprintf "ReadPriorityIndicator unknown fix tag: %A"  x) 


let WritePriorityIndicator (strm:Stream) (xxIn:PriorityIndicator) =
    match xxIn with
    | PriorityIndicator.PriorityUnchanged -> strm.Write "638=0"B; strm.Write (delim, 0, 1)
    | PriorityIndicator.LostPriorityAsResultOfOrderChange -> strm.Write "638=1"B; strm.Write (delim, 0, 1)


let ReadPriceImprovement valIn =
    let tmp = System.Decimal.Parse valIn
    PriceImprovement.PriceImprovement tmp


let WritePriceImprovement (strm:Stream) (valIn:PriceImprovement) = 
    let tag = "639="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPrice2 valIn =
    let tmp = System.Decimal.Parse valIn
    Price2.Price2 tmp


let WritePrice2 (strm:Stream) (valIn:Price2) = 
    let tag = "640="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLastForwardPoints2 valIn =
    let tmp = System.Decimal.Parse valIn
    LastForwardPoints2.LastForwardPoints2 tmp


let WriteLastForwardPoints2 (strm:Stream) (valIn:LastForwardPoints2) = 
    let tag = "641="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBidForwardPoints2 valIn =
    let tmp = System.Decimal.Parse valIn
    BidForwardPoints2.BidForwardPoints2 tmp


let WriteBidForwardPoints2 (strm:Stream) (valIn:BidForwardPoints2) = 
    let tag = "642="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOfferForwardPoints2 valIn =
    let tmp = System.Decimal.Parse valIn
    OfferForwardPoints2.OfferForwardPoints2 tmp


let WriteOfferForwardPoints2 (strm:Stream) (valIn:OfferForwardPoints2) = 
    let tag = "643="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRFQReqID valIn =
    let tmp =  valIn
    RFQReqID.RFQReqID tmp


let WriteRFQReqID (strm:Stream) (valIn:RFQReqID) = 
    let tag = "644="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMktBidPx valIn =
    let tmp = System.Decimal.Parse valIn
    MktBidPx.MktBidPx tmp


let WriteMktBidPx (strm:Stream) (valIn:MktBidPx) = 
    let tag = "645="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMktOfferPx valIn =
    let tmp = System.Decimal.Parse valIn
    MktOfferPx.MktOfferPx tmp


let WriteMktOfferPx (strm:Stream) (valIn:MktOfferPx) = 
    let tag = "646="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMinBidSize valIn =
    let tmp = System.Decimal.Parse valIn
    MinBidSize.MinBidSize tmp


let WriteMinBidSize (strm:Stream) (valIn:MinBidSize) = 
    let tag = "647="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMinOfferSize valIn =
    let tmp = System.Decimal.Parse valIn
    MinOfferSize.MinOfferSize tmp


let WriteMinOfferSize (strm:Stream) (valIn:MinOfferSize) = 
    let tag = "648="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuoteStatusReqID valIn =
    let tmp =  valIn
    QuoteStatusReqID.QuoteStatusReqID tmp


let WriteQuoteStatusReqID (strm:Stream) (valIn:QuoteStatusReqID) = 
    let tag = "649="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegalConfirm valIn =
    let tmp = System.Boolean.Parse valIn
    LegalConfirm.LegalConfirm tmp


let WriteLegalConfirm (strm:Stream) (valIn:LegalConfirm) = 
    let tag = "650="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingLastPx valIn =
    let tmp = System.Decimal.Parse valIn
    UnderlyingLastPx.UnderlyingLastPx tmp


let WriteUnderlyingLastPx (strm:Stream) (valIn:UnderlyingLastPx) = 
    let tag = "651="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingLastQty valIn =
    let tmp = System.Decimal.Parse valIn
    UnderlyingLastQty.UnderlyingLastQty tmp


let WriteUnderlyingLastQty (strm:Stream) (valIn:UnderlyingLastQty) = 
    let tag = "652="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegRefID valIn =
    let tmp =  valIn
    LegRefID.LegRefID tmp


let WriteLegRefID (strm:Stream) (valIn:LegRefID) = 
    let tag = "654="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadContraLegRefID valIn =
    let tmp =  valIn
    ContraLegRefID.ContraLegRefID tmp


let WriteContraLegRefID (strm:Stream) (valIn:ContraLegRefID) = 
    let tag = "655="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlCurrBidFxRate valIn =
    let tmp = System.Decimal.Parse valIn
    SettlCurrBidFxRate.SettlCurrBidFxRate tmp


let WriteSettlCurrBidFxRate (strm:Stream) (valIn:SettlCurrBidFxRate) = 
    let tag = "656="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlCurrOfferFxRate valIn =
    let tmp = System.Decimal.Parse valIn
    SettlCurrOfferFxRate.SettlCurrOfferFxRate tmp


let WriteSettlCurrOfferFxRate (strm:Stream) (valIn:SettlCurrOfferFxRate) = 
    let tag = "657="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuoteRequestRejectReason (fldValIn:string) : QuoteRequestRejectReason = 
    match fldValIn with
    |"1" -> QuoteRequestRejectReason.UnknownSymbol
    |"2" -> QuoteRequestRejectReason.ExchangeClosed
    |"3" -> QuoteRequestRejectReason.QuoteRequestExceedsLimit
    |"4" -> QuoteRequestRejectReason.TooLateToEnter
    |"5" -> QuoteRequestRejectReason.InvalidPrice
    |"6" -> QuoteRequestRejectReason.NotAuthorizedToRequestQuote
    |"7" -> QuoteRequestRejectReason.NoMatchForInquiry
    |"8" -> QuoteRequestRejectReason.NoMarketForInstrument
    |"9" -> QuoteRequestRejectReason.NoInventory
    |"10" -> QuoteRequestRejectReason.Pass
    |"99" -> QuoteRequestRejectReason.Other
    | x -> failwith (sprintf "ReadQuoteRequestRejectReason unknown fix tag: %A"  x) 


let WriteQuoteRequestRejectReason (strm:Stream) (xxIn:QuoteRequestRejectReason) =
    match xxIn with
    | QuoteRequestRejectReason.UnknownSymbol -> strm.Write "658=1"B; strm.Write (delim, 0, 1)
    | QuoteRequestRejectReason.ExchangeClosed -> strm.Write "658=2"B; strm.Write (delim, 0, 1)
    | QuoteRequestRejectReason.QuoteRequestExceedsLimit -> strm.Write "658=3"B; strm.Write (delim, 0, 1)
    | QuoteRequestRejectReason.TooLateToEnter -> strm.Write "658=4"B; strm.Write (delim, 0, 1)
    | QuoteRequestRejectReason.InvalidPrice -> strm.Write "658=5"B; strm.Write (delim, 0, 1)
    | QuoteRequestRejectReason.NotAuthorizedToRequestQuote -> strm.Write "658=6"B; strm.Write (delim, 0, 1)
    | QuoteRequestRejectReason.NoMatchForInquiry -> strm.Write "658=7"B; strm.Write (delim, 0, 1)
    | QuoteRequestRejectReason.NoMarketForInstrument -> strm.Write "658=8"B; strm.Write (delim, 0, 1)
    | QuoteRequestRejectReason.NoInventory -> strm.Write "658=9"B; strm.Write (delim, 0, 1)
    | QuoteRequestRejectReason.Pass -> strm.Write "658=10"B; strm.Write (delim, 0, 1)
    | QuoteRequestRejectReason.Other -> strm.Write "658=99"B; strm.Write (delim, 0, 1)


let ReadSideComplianceID valIn =
    let tmp =  valIn
    SideComplianceID.SideComplianceID tmp


let WriteSideComplianceID (strm:Stream) (valIn:SideComplianceID) = 
    let tag = "659="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAcctIDSource (fldValIn:string) : AcctIDSource = 
    match fldValIn with
    |"1" -> AcctIDSource.Bic
    |"2" -> AcctIDSource.SidCode
    |"3" -> AcctIDSource.Tfm
    |"4" -> AcctIDSource.Omgeo
    |"5" -> AcctIDSource.DtccCode
    |"99" -> AcctIDSource.Other
    | x -> failwith (sprintf "ReadAcctIDSource unknown fix tag: %A"  x) 


let WriteAcctIDSource (strm:Stream) (xxIn:AcctIDSource) =
    match xxIn with
    | AcctIDSource.Bic -> strm.Write "660=1"B; strm.Write (delim, 0, 1)
    | AcctIDSource.SidCode -> strm.Write "660=2"B; strm.Write (delim, 0, 1)
    | AcctIDSource.Tfm -> strm.Write "660=3"B; strm.Write (delim, 0, 1)
    | AcctIDSource.Omgeo -> strm.Write "660=4"B; strm.Write (delim, 0, 1)
    | AcctIDSource.DtccCode -> strm.Write "660=5"B; strm.Write (delim, 0, 1)
    | AcctIDSource.Other -> strm.Write "660=99"B; strm.Write (delim, 0, 1)


let ReadAllocAcctIDSource valIn =
    let tmp = System.Int32.Parse valIn
    AllocAcctIDSource.AllocAcctIDSource tmp


let WriteAllocAcctIDSource (strm:Stream) (valIn:AllocAcctIDSource) = 
    let tag = "661="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBenchmarkPrice valIn =
    let tmp = System.Decimal.Parse valIn
    BenchmarkPrice.BenchmarkPrice tmp


let WriteBenchmarkPrice (strm:Stream) (valIn:BenchmarkPrice) = 
    let tag = "662="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBenchmarkPriceType valIn =
    let tmp = System.Int32.Parse valIn
    BenchmarkPriceType.BenchmarkPriceType tmp


let WriteBenchmarkPriceType (strm:Stream) (valIn:BenchmarkPriceType) = 
    let tag = "663="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadConfirmID valIn =
    let tmp =  valIn
    ConfirmID.ConfirmID tmp


let WriteConfirmID (strm:Stream) (valIn:ConfirmID) = 
    let tag = "664="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadConfirmStatus (fldValIn:string) : ConfirmStatus = 
    match fldValIn with
    |"1" -> ConfirmStatus.Received
    |"2" -> ConfirmStatus.MismatchedAccount
    |"3" -> ConfirmStatus.MissingSettlementInstructions
    |"4" -> ConfirmStatus.Confirmed
    |"5" -> ConfirmStatus.RequestRejected
    | x -> failwith (sprintf "ReadConfirmStatus unknown fix tag: %A"  x) 


let WriteConfirmStatus (strm:Stream) (xxIn:ConfirmStatus) =
    match xxIn with
    | ConfirmStatus.Received -> strm.Write "665=1"B; strm.Write (delim, 0, 1)
    | ConfirmStatus.MismatchedAccount -> strm.Write "665=2"B; strm.Write (delim, 0, 1)
    | ConfirmStatus.MissingSettlementInstructions -> strm.Write "665=3"B; strm.Write (delim, 0, 1)
    | ConfirmStatus.Confirmed -> strm.Write "665=4"B; strm.Write (delim, 0, 1)
    | ConfirmStatus.RequestRejected -> strm.Write "665=5"B; strm.Write (delim, 0, 1)


let ReadConfirmTransType (fldValIn:string) : ConfirmTransType = 
    match fldValIn with
    |"0" -> ConfirmTransType.New
    |"1" -> ConfirmTransType.Replace
    |"2" -> ConfirmTransType.Cancel
    | x -> failwith (sprintf "ReadConfirmTransType unknown fix tag: %A"  x) 


let WriteConfirmTransType (strm:Stream) (xxIn:ConfirmTransType) =
    match xxIn with
    | ConfirmTransType.New -> strm.Write "666=0"B; strm.Write (delim, 0, 1)
    | ConfirmTransType.Replace -> strm.Write "666=1"B; strm.Write (delim, 0, 1)
    | ConfirmTransType.Cancel -> strm.Write "666=2"B; strm.Write (delim, 0, 1)


let ReadContractSettlMonth valIn =
    let tmp =  valIn
    ContractSettlMonth.ContractSettlMonth tmp


let WriteContractSettlMonth (strm:Stream) (valIn:ContractSettlMonth) = 
    let tag = "667="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDeliveryForm (fldValIn:string) : DeliveryForm = 
    match fldValIn with
    |"1" -> DeliveryForm.Bookentry
    |"2" -> DeliveryForm.Bearer
    | x -> failwith (sprintf "ReadDeliveryForm unknown fix tag: %A"  x) 


let WriteDeliveryForm (strm:Stream) (xxIn:DeliveryForm) =
    match xxIn with
    | DeliveryForm.Bookentry -> strm.Write "668=1"B; strm.Write (delim, 0, 1)
    | DeliveryForm.Bearer -> strm.Write "668=2"B; strm.Write (delim, 0, 1)


let ReadLastParPx valIn =
    let tmp = System.Decimal.Parse valIn
    LastParPx.LastParPx tmp


let WriteLastParPx (strm:Stream) (valIn:LastParPx) = 
    let tag = "669="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoLegAllocs valIn =
    let tmp = System.Int32.Parse valIn
    NoLegAllocs.NoLegAllocs tmp


let WriteNoLegAllocs (strm:Stream) (valIn:NoLegAllocs) = 
    let tag = "670="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegAllocAccount valIn =
    let tmp =  valIn
    LegAllocAccount.LegAllocAccount tmp


let WriteLegAllocAccount (strm:Stream) (valIn:LegAllocAccount) = 
    let tag = "671="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegIndividualAllocID valIn =
    let tmp =  valIn
    LegIndividualAllocID.LegIndividualAllocID tmp


let WriteLegIndividualAllocID (strm:Stream) (valIn:LegIndividualAllocID) = 
    let tag = "672="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegAllocQty valIn =
    let tmp = System.Decimal.Parse valIn
    LegAllocQty.LegAllocQty tmp


let WriteLegAllocQty (strm:Stream) (valIn:LegAllocQty) = 
    let tag = "673="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegAllocAcctIDSource valIn =
    let tmp =  valIn
    LegAllocAcctIDSource.LegAllocAcctIDSource tmp


let WriteLegAllocAcctIDSource (strm:Stream) (valIn:LegAllocAcctIDSource) = 
    let tag = "674="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSettlCurrency valIn =
    let tmp =  valIn
    LegSettlCurrency.LegSettlCurrency tmp


let WriteLegSettlCurrency (strm:Stream) (valIn:LegSettlCurrency) = 
    let tag = "675="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegBenchmarkCurveCurrency valIn =
    let tmp =  valIn
    LegBenchmarkCurveCurrency.LegBenchmarkCurveCurrency tmp


let WriteLegBenchmarkCurveCurrency (strm:Stream) (valIn:LegBenchmarkCurveCurrency) = 
    let tag = "676="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegBenchmarkCurveName valIn =
    let tmp =  valIn
    LegBenchmarkCurveName.LegBenchmarkCurveName tmp


let WriteLegBenchmarkCurveName (strm:Stream) (valIn:LegBenchmarkCurveName) = 
    let tag = "677="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegBenchmarkCurvePoint valIn =
    let tmp =  valIn
    LegBenchmarkCurvePoint.LegBenchmarkCurvePoint tmp


let WriteLegBenchmarkCurvePoint (strm:Stream) (valIn:LegBenchmarkCurvePoint) = 
    let tag = "678="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegBenchmarkPrice valIn =
    let tmp = System.Decimal.Parse valIn
    LegBenchmarkPrice.LegBenchmarkPrice tmp


let WriteLegBenchmarkPrice (strm:Stream) (valIn:LegBenchmarkPrice) = 
    let tag = "679="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegBenchmarkPriceType valIn =
    let tmp = System.Int32.Parse valIn
    LegBenchmarkPriceType.LegBenchmarkPriceType tmp


let WriteLegBenchmarkPriceType (strm:Stream) (valIn:LegBenchmarkPriceType) = 
    let tag = "680="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegBidPx valIn =
    let tmp = System.Decimal.Parse valIn
    LegBidPx.LegBidPx tmp


let WriteLegBidPx (strm:Stream) (valIn:LegBidPx) = 
    let tag = "681="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegIOIQty valIn =
    let tmp =  valIn
    LegIOIQty.LegIOIQty tmp


let WriteLegIOIQty (strm:Stream) (valIn:LegIOIQty) = 
    let tag = "682="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoLegStipulations valIn =
    let tmp = System.Int32.Parse valIn
    NoLegStipulations.NoLegStipulations tmp


let WriteNoLegStipulations (strm:Stream) (valIn:NoLegStipulations) = 
    let tag = "683="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegOfferPx valIn =
    let tmp = System.Decimal.Parse valIn
    LegOfferPx.LegOfferPx tmp


let WriteLegOfferPx (strm:Stream) (valIn:LegOfferPx) = 
    let tag = "684="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegOrderQty valIn =
    let tmp = System.Decimal.Parse valIn
    LegOrderQty.LegOrderQty tmp


let WriteLegOrderQty (strm:Stream) (valIn:LegOrderQty) = 
    let tag = "685="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegPriceType valIn =
    let tmp = System.Int32.Parse valIn
    LegPriceType.LegPriceType tmp


let WriteLegPriceType (strm:Stream) (valIn:LegPriceType) = 
    let tag = "686="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegQty valIn =
    let tmp = System.Decimal.Parse valIn
    LegQty.LegQty tmp


let WriteLegQty (strm:Stream) (valIn:LegQty) = 
    let tag = "687="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegStipulationType valIn =
    let tmp =  valIn
    LegStipulationType.LegStipulationType tmp


let WriteLegStipulationType (strm:Stream) (valIn:LegStipulationType) = 
    let tag = "688="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegStipulationValue valIn =
    let tmp =  valIn
    LegStipulationValue.LegStipulationValue tmp


let WriteLegStipulationValue (strm:Stream) (valIn:LegStipulationValue) = 
    let tag = "689="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSwapType (fldValIn:string) : LegSwapType = 
    match fldValIn with
    |"1" -> LegSwapType.ParForPar
    |"2" -> LegSwapType.ModifiedDuration
    |"4" -> LegSwapType.Risk
    |"5" -> LegSwapType.Proceeds
    | x -> failwith (sprintf "ReadLegSwapType unknown fix tag: %A"  x) 


let WriteLegSwapType (strm:Stream) (xxIn:LegSwapType) =
    match xxIn with
    | LegSwapType.ParForPar -> strm.Write "690=1"B; strm.Write (delim, 0, 1)
    | LegSwapType.ModifiedDuration -> strm.Write "690=2"B; strm.Write (delim, 0, 1)
    | LegSwapType.Risk -> strm.Write "690=4"B; strm.Write (delim, 0, 1)
    | LegSwapType.Proceeds -> strm.Write "690=5"B; strm.Write (delim, 0, 1)


let ReadPool valIn =
    let tmp =  valIn
    Pool.Pool tmp


let WritePool (strm:Stream) (valIn:Pool) = 
    let tag = "691="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuotePriceType (fldValIn:string) : QuotePriceType = 
    match fldValIn with
    |"1" -> QuotePriceType.Percent
    |"2" -> QuotePriceType.PerShare
    |"3" -> QuotePriceType.FixedAmount
    |"4" -> QuotePriceType.Discount
    |"5" -> QuotePriceType.Premium
    |"6" -> QuotePriceType.BasisPointsRelativeToBenchmark
    |"7" -> QuotePriceType.TedPrice
    |"8" -> QuotePriceType.TedYield
    |"9" -> QuotePriceType.YieldSpread
    |"10" -> QuotePriceType.Yield
    | x -> failwith (sprintf "ReadQuotePriceType unknown fix tag: %A"  x) 


let WriteQuotePriceType (strm:Stream) (xxIn:QuotePriceType) =
    match xxIn with
    | QuotePriceType.Percent -> strm.Write "692=1"B; strm.Write (delim, 0, 1)
    | QuotePriceType.PerShare -> strm.Write "692=2"B; strm.Write (delim, 0, 1)
    | QuotePriceType.FixedAmount -> strm.Write "692=3"B; strm.Write (delim, 0, 1)
    | QuotePriceType.Discount -> strm.Write "692=4"B; strm.Write (delim, 0, 1)
    | QuotePriceType.Premium -> strm.Write "692=5"B; strm.Write (delim, 0, 1)
    | QuotePriceType.BasisPointsRelativeToBenchmark -> strm.Write "692=6"B; strm.Write (delim, 0, 1)
    | QuotePriceType.TedPrice -> strm.Write "692=7"B; strm.Write (delim, 0, 1)
    | QuotePriceType.TedYield -> strm.Write "692=8"B; strm.Write (delim, 0, 1)
    | QuotePriceType.YieldSpread -> strm.Write "692=9"B; strm.Write (delim, 0, 1)
    | QuotePriceType.Yield -> strm.Write "692=10"B; strm.Write (delim, 0, 1)


let ReadQuoteRespID valIn =
    let tmp =  valIn
    QuoteRespID.QuoteRespID tmp


let WriteQuoteRespID (strm:Stream) (valIn:QuoteRespID) = 
    let tag = "693="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadQuoteRespType (fldValIn:string) : QuoteRespType = 
    match fldValIn with
    |"1" -> QuoteRespType.HitLift
    |"2" -> QuoteRespType.Counter
    |"3" -> QuoteRespType.Expired
    |"4" -> QuoteRespType.Cover
    |"5" -> QuoteRespType.DoneAway
    |"6" -> QuoteRespType.Pass
    | x -> failwith (sprintf "ReadQuoteRespType unknown fix tag: %A"  x) 


let WriteQuoteRespType (strm:Stream) (xxIn:QuoteRespType) =
    match xxIn with
    | QuoteRespType.HitLift -> strm.Write "694=1"B; strm.Write (delim, 0, 1)
    | QuoteRespType.Counter -> strm.Write "694=2"B; strm.Write (delim, 0, 1)
    | QuoteRespType.Expired -> strm.Write "694=3"B; strm.Write (delim, 0, 1)
    | QuoteRespType.Cover -> strm.Write "694=4"B; strm.Write (delim, 0, 1)
    | QuoteRespType.DoneAway -> strm.Write "694=5"B; strm.Write (delim, 0, 1)
    | QuoteRespType.Pass -> strm.Write "694=6"B; strm.Write (delim, 0, 1)


let ReadQuoteQualifier valIn =
    let tmp = System.Int32.Parse valIn
    QuoteQualifier.QuoteQualifier tmp


let WriteQuoteQualifier (strm:Stream) (valIn:QuoteQualifier) = 
    let tag = "695="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadYieldRedemptionDate valIn =
    let tmp =  valIn
    YieldRedemptionDate.YieldRedemptionDate tmp


let WriteYieldRedemptionDate (strm:Stream) (valIn:YieldRedemptionDate) = 
    let tag = "696="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadYieldRedemptionPrice valIn =
    let tmp = System.Decimal.Parse valIn
    YieldRedemptionPrice.YieldRedemptionPrice tmp


let WriteYieldRedemptionPrice (strm:Stream) (valIn:YieldRedemptionPrice) = 
    let tag = "697="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadYieldRedemptionPriceType valIn =
    let tmp = System.Int32.Parse valIn
    YieldRedemptionPriceType.YieldRedemptionPriceType tmp


let WriteYieldRedemptionPriceType (strm:Stream) (valIn:YieldRedemptionPriceType) = 
    let tag = "698="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBenchmarkSecurityID valIn =
    let tmp =  valIn
    BenchmarkSecurityID.BenchmarkSecurityID tmp


let WriteBenchmarkSecurityID (strm:Stream) (valIn:BenchmarkSecurityID) = 
    let tag = "699="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadReversalIndicator valIn =
    let tmp = System.Boolean.Parse valIn
    ReversalIndicator.ReversalIndicator tmp


let WriteReversalIndicator (strm:Stream) (valIn:ReversalIndicator) = 
    let tag = "700="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadYieldCalcDate valIn =
    let tmp =  valIn
    YieldCalcDate.YieldCalcDate tmp


let WriteYieldCalcDate (strm:Stream) (valIn:YieldCalcDate) = 
    let tag = "701="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoPositions valIn =
    let tmp = System.Int32.Parse valIn
    NoPositions.NoPositions tmp


let WriteNoPositions (strm:Stream) (valIn:NoPositions) = 
    let tag = "702="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPosType (fldValIn:string) : PosType = 
    match fldValIn with
    |"TQ" -> PosType.TransactionQuantity
    |"IAS" -> PosType.IntraSpreadQty
    |"IES" -> PosType.InterSpreadQty
    |"FIN" -> PosType.EndOfDayQty
    |"SOD" -> PosType.StartOfDayQty
    |"EX" -> PosType.OptionExerciseQty
    |"AS" -> PosType.OptionAssignment
    |"TX" -> PosType.TransactionFromExercise
    |"TA" -> PosType.TransactionFromAssignment
    |"PIT" -> PosType.PitTradeQty
    |"TRF" -> PosType.TransferTradeQty
    |"ETR" -> PosType.ElectronicTradeQty
    |"ALC" -> PosType.AllocationTradeQty
    |"PA" -> PosType.AdjustmentQty
    |"ASF" -> PosType.AsOfTradeQty
    |"DLV" -> PosType.DeliveryQty
    |"TOT" -> PosType.TotalTransactionQty
    |"XM" -> PosType.CrossMarginQty
    |"SPL" -> PosType.IntegralSplit
    | x -> failwith (sprintf "ReadPosType unknown fix tag: %A"  x) 


let WritePosType (strm:Stream) (xxIn:PosType) =
    match xxIn with
    | PosType.TransactionQuantity -> strm.Write "703=TQ"B; strm.Write (delim, 0, 1)
    | PosType.IntraSpreadQty -> strm.Write "703=IAS"B; strm.Write (delim, 0, 1)
    | PosType.InterSpreadQty -> strm.Write "703=IES"B; strm.Write (delim, 0, 1)
    | PosType.EndOfDayQty -> strm.Write "703=FIN"B; strm.Write (delim, 0, 1)
    | PosType.StartOfDayQty -> strm.Write "703=SOD"B; strm.Write (delim, 0, 1)
    | PosType.OptionExerciseQty -> strm.Write "703=EX"B; strm.Write (delim, 0, 1)
    | PosType.OptionAssignment -> strm.Write "703=AS"B; strm.Write (delim, 0, 1)
    | PosType.TransactionFromExercise -> strm.Write "703=TX"B; strm.Write (delim, 0, 1)
    | PosType.TransactionFromAssignment -> strm.Write "703=TA"B; strm.Write (delim, 0, 1)
    | PosType.PitTradeQty -> strm.Write "703=PIT"B; strm.Write (delim, 0, 1)
    | PosType.TransferTradeQty -> strm.Write "703=TRF"B; strm.Write (delim, 0, 1)
    | PosType.ElectronicTradeQty -> strm.Write "703=ETR"B; strm.Write (delim, 0, 1)
    | PosType.AllocationTradeQty -> strm.Write "703=ALC"B; strm.Write (delim, 0, 1)
    | PosType.AdjustmentQty -> strm.Write "703=PA"B; strm.Write (delim, 0, 1)
    | PosType.AsOfTradeQty -> strm.Write "703=ASF"B; strm.Write (delim, 0, 1)
    | PosType.DeliveryQty -> strm.Write "703=DLV"B; strm.Write (delim, 0, 1)
    | PosType.TotalTransactionQty -> strm.Write "703=TOT"B; strm.Write (delim, 0, 1)
    | PosType.CrossMarginQty -> strm.Write "703=XM"B; strm.Write (delim, 0, 1)
    | PosType.IntegralSplit -> strm.Write "703=SPL"B; strm.Write (delim, 0, 1)


let ReadLongQty valIn =
    let tmp = System.Decimal.Parse valIn
    LongQty.LongQty tmp


let WriteLongQty (strm:Stream) (valIn:LongQty) = 
    let tag = "704="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadShortQty valIn =
    let tmp = System.Decimal.Parse valIn
    ShortQty.ShortQty tmp


let WriteShortQty (strm:Stream) (valIn:ShortQty) = 
    let tag = "705="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPosQtyStatus (fldValIn:string) : PosQtyStatus = 
    match fldValIn with
    |"0" -> PosQtyStatus.Submitted
    |"1" -> PosQtyStatus.Accepted
    |"2" -> PosQtyStatus.Rejected
    | x -> failwith (sprintf "ReadPosQtyStatus unknown fix tag: %A"  x) 


let WritePosQtyStatus (strm:Stream) (xxIn:PosQtyStatus) =
    match xxIn with
    | PosQtyStatus.Submitted -> strm.Write "706=0"B; strm.Write (delim, 0, 1)
    | PosQtyStatus.Accepted -> strm.Write "706=1"B; strm.Write (delim, 0, 1)
    | PosQtyStatus.Rejected -> strm.Write "706=2"B; strm.Write (delim, 0, 1)


let ReadPosAmtType (fldValIn:string) : PosAmtType = 
    match fldValIn with
    |"FMTM" -> PosAmtType.FinalMarkToMarketAmount
    |"IMTM" -> PosAmtType.IncrementalMarkToMarketAmount
    |"TVAR" -> PosAmtType.TradeVariationAmount
    |"SMTM" -> PosAmtType.StartOfDayMarkToMarketAmount
    |"PREM" -> PosAmtType.PremiumAmount
    |"CRES" -> PosAmtType.CashResidualAmount
    |"CASH" -> PosAmtType.CashAmount
    |"VADJ" -> PosAmtType.ValueAdjustedAmount
    | x -> failwith (sprintf "ReadPosAmtType unknown fix tag: %A"  x) 


let WritePosAmtType (strm:Stream) (xxIn:PosAmtType) =
    match xxIn with
    | PosAmtType.FinalMarkToMarketAmount -> strm.Write "707=FMTM"B; strm.Write (delim, 0, 1)
    | PosAmtType.IncrementalMarkToMarketAmount -> strm.Write "707=IMTM"B; strm.Write (delim, 0, 1)
    | PosAmtType.TradeVariationAmount -> strm.Write "707=TVAR"B; strm.Write (delim, 0, 1)
    | PosAmtType.StartOfDayMarkToMarketAmount -> strm.Write "707=SMTM"B; strm.Write (delim, 0, 1)
    | PosAmtType.PremiumAmount -> strm.Write "707=PREM"B; strm.Write (delim, 0, 1)
    | PosAmtType.CashResidualAmount -> strm.Write "707=CRES"B; strm.Write (delim, 0, 1)
    | PosAmtType.CashAmount -> strm.Write "707=CASH"B; strm.Write (delim, 0, 1)
    | PosAmtType.ValueAdjustedAmount -> strm.Write "707=VADJ"B; strm.Write (delim, 0, 1)


let ReadPosAmt valIn =
    let tmp = System.Int32.Parse valIn
    PosAmt.PosAmt tmp


let WritePosAmt (strm:Stream) (valIn:PosAmt) = 
    let tag = "708="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPosTransType (fldValIn:string) : PosTransType = 
    match fldValIn with
    |"1" -> PosTransType.Exercise
    |"2" -> PosTransType.DoNotExercise
    |"3" -> PosTransType.PositionAdjustment
    |"4" -> PosTransType.PositionChangeSubmissionMarginDisposition
    |"5" -> PosTransType.Pledge
    | x -> failwith (sprintf "ReadPosTransType unknown fix tag: %A"  x) 


let WritePosTransType (strm:Stream) (xxIn:PosTransType) =
    match xxIn with
    | PosTransType.Exercise -> strm.Write "709=1"B; strm.Write (delim, 0, 1)
    | PosTransType.DoNotExercise -> strm.Write "709=2"B; strm.Write (delim, 0, 1)
    | PosTransType.PositionAdjustment -> strm.Write "709=3"B; strm.Write (delim, 0, 1)
    | PosTransType.PositionChangeSubmissionMarginDisposition -> strm.Write "709=4"B; strm.Write (delim, 0, 1)
    | PosTransType.Pledge -> strm.Write "709=5"B; strm.Write (delim, 0, 1)


let ReadPosReqID valIn =
    let tmp =  valIn
    PosReqID.PosReqID tmp


let WritePosReqID (strm:Stream) (valIn:PosReqID) = 
    let tag = "710="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoUnderlyings valIn =
    let tmp = System.Int32.Parse valIn
    NoUnderlyings.NoUnderlyings tmp


let WriteNoUnderlyings (strm:Stream) (valIn:NoUnderlyings) = 
    let tag = "711="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPosMaintAction (fldValIn:string) : PosMaintAction = 
    match fldValIn with
    |"1" -> PosMaintAction.New
    |"2" -> PosMaintAction.Replace
    |"3" -> PosMaintAction.Cancel
    | x -> failwith (sprintf "ReadPosMaintAction unknown fix tag: %A"  x) 


let WritePosMaintAction (strm:Stream) (xxIn:PosMaintAction) =
    match xxIn with
    | PosMaintAction.New -> strm.Write "712=1"B; strm.Write (delim, 0, 1)
    | PosMaintAction.Replace -> strm.Write "712=2"B; strm.Write (delim, 0, 1)
    | PosMaintAction.Cancel -> strm.Write "712=3"B; strm.Write (delim, 0, 1)


let ReadOrigPosReqRefID valIn =
    let tmp =  valIn
    OrigPosReqRefID.OrigPosReqRefID tmp


let WriteOrigPosReqRefID (strm:Stream) (valIn:OrigPosReqRefID) = 
    let tag = "713="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPosMaintRptRefID valIn =
    let tmp =  valIn
    PosMaintRptRefID.PosMaintRptRefID tmp


let WritePosMaintRptRefID (strm:Stream) (valIn:PosMaintRptRefID) = 
    let tag = "714="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadClearingBusinessDate valIn =
    let tmp =  valIn
    ClearingBusinessDate.ClearingBusinessDate tmp


let WriteClearingBusinessDate (strm:Stream) (valIn:ClearingBusinessDate) = 
    let tag = "715="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlSessID valIn =
    let tmp =  valIn
    SettlSessID.SettlSessID tmp


let WriteSettlSessID (strm:Stream) (valIn:SettlSessID) = 
    let tag = "716="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlSessSubID valIn =
    let tmp =  valIn
    SettlSessSubID.SettlSessSubID tmp


let WriteSettlSessSubID (strm:Stream) (valIn:SettlSessSubID) = 
    let tag = "717="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAdjustmentType (fldValIn:string) : AdjustmentType = 
    match fldValIn with
    |"0" -> AdjustmentType.ProcessRequestAsMarginDisposition
    |"1" -> AdjustmentType.DeltaPlus
    |"2" -> AdjustmentType.DeltaMinus
    |"3" -> AdjustmentType.Final
    | x -> failwith (sprintf "ReadAdjustmentType unknown fix tag: %A"  x) 


let WriteAdjustmentType (strm:Stream) (xxIn:AdjustmentType) =
    match xxIn with
    | AdjustmentType.ProcessRequestAsMarginDisposition -> strm.Write "718=0"B; strm.Write (delim, 0, 1)
    | AdjustmentType.DeltaPlus -> strm.Write "718=1"B; strm.Write (delim, 0, 1)
    | AdjustmentType.DeltaMinus -> strm.Write "718=2"B; strm.Write (delim, 0, 1)
    | AdjustmentType.Final -> strm.Write "718=3"B; strm.Write (delim, 0, 1)


let ReadContraryInstructionIndicator valIn =
    let tmp = System.Boolean.Parse valIn
    ContraryInstructionIndicator.ContraryInstructionIndicator tmp


let WriteContraryInstructionIndicator (strm:Stream) (valIn:ContraryInstructionIndicator) = 
    let tag = "719="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPriorSpreadIndicator valIn =
    let tmp = System.Boolean.Parse valIn
    PriorSpreadIndicator.PriorSpreadIndicator tmp


let WritePriorSpreadIndicator (strm:Stream) (valIn:PriorSpreadIndicator) = 
    let tag = "720="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPosMaintRptID valIn =
    let tmp =  valIn
    PosMaintRptID.PosMaintRptID tmp


let WritePosMaintRptID (strm:Stream) (valIn:PosMaintRptID) = 
    let tag = "721="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPosMaintStatus (fldValIn:string) : PosMaintStatus = 
    match fldValIn with
    |"0" -> PosMaintStatus.Accepted
    |"1" -> PosMaintStatus.AcceptedWithWarnings
    |"2" -> PosMaintStatus.Rejected
    |"3" -> PosMaintStatus.Completed
    |"4" -> PosMaintStatus.CompletedWithWarnings
    | x -> failwith (sprintf "ReadPosMaintStatus unknown fix tag: %A"  x) 


let WritePosMaintStatus (strm:Stream) (xxIn:PosMaintStatus) =
    match xxIn with
    | PosMaintStatus.Accepted -> strm.Write "722=0"B; strm.Write (delim, 0, 1)
    | PosMaintStatus.AcceptedWithWarnings -> strm.Write "722=1"B; strm.Write (delim, 0, 1)
    | PosMaintStatus.Rejected -> strm.Write "722=2"B; strm.Write (delim, 0, 1)
    | PosMaintStatus.Completed -> strm.Write "722=3"B; strm.Write (delim, 0, 1)
    | PosMaintStatus.CompletedWithWarnings -> strm.Write "722=4"B; strm.Write (delim, 0, 1)


let ReadPosMaintResult (fldValIn:string) : PosMaintResult = 
    match fldValIn with
    |"0" -> PosMaintResult.SuccessfulCompletionNoWarningsOrErrors
    |"1" -> PosMaintResult.Rejected
    |"99" -> PosMaintResult.Other
    | x -> failwith (sprintf "ReadPosMaintResult unknown fix tag: %A"  x) 


let WritePosMaintResult (strm:Stream) (xxIn:PosMaintResult) =
    match xxIn with
    | PosMaintResult.SuccessfulCompletionNoWarningsOrErrors -> strm.Write "723=0"B; strm.Write (delim, 0, 1)
    | PosMaintResult.Rejected -> strm.Write "723=1"B; strm.Write (delim, 0, 1)
    | PosMaintResult.Other -> strm.Write "723=99"B; strm.Write (delim, 0, 1)


let ReadPosReqType (fldValIn:string) : PosReqType = 
    match fldValIn with
    |"0" -> PosReqType.Positions
    |"1" -> PosReqType.Trades
    |"2" -> PosReqType.Exercises
    |"3" -> PosReqType.Assignments
    | x -> failwith (sprintf "ReadPosReqType unknown fix tag: %A"  x) 


let WritePosReqType (strm:Stream) (xxIn:PosReqType) =
    match xxIn with
    | PosReqType.Positions -> strm.Write "724=0"B; strm.Write (delim, 0, 1)
    | PosReqType.Trades -> strm.Write "724=1"B; strm.Write (delim, 0, 1)
    | PosReqType.Exercises -> strm.Write "724=2"B; strm.Write (delim, 0, 1)
    | PosReqType.Assignments -> strm.Write "724=3"B; strm.Write (delim, 0, 1)


let ReadResponseTransportType (fldValIn:string) : ResponseTransportType = 
    match fldValIn with
    |"0" -> ResponseTransportType.Inband
    |"1" -> ResponseTransportType.OutOfBand
    | x -> failwith (sprintf "ReadResponseTransportType unknown fix tag: %A"  x) 


let WriteResponseTransportType (strm:Stream) (xxIn:ResponseTransportType) =
    match xxIn with
    | ResponseTransportType.Inband -> strm.Write "725=0"B; strm.Write (delim, 0, 1)
    | ResponseTransportType.OutOfBand -> strm.Write "725=1"B; strm.Write (delim, 0, 1)


let ReadResponseDestination valIn =
    let tmp =  valIn
    ResponseDestination.ResponseDestination tmp


let WriteResponseDestination (strm:Stream) (valIn:ResponseDestination) = 
    let tag = "726="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTotalNumPosReports valIn =
    let tmp = System.Int32.Parse valIn
    TotalNumPosReports.TotalNumPosReports tmp


let WriteTotalNumPosReports (strm:Stream) (valIn:TotalNumPosReports) = 
    let tag = "727="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPosReqResult (fldValIn:string) : PosReqResult = 
    match fldValIn with
    |"0" -> PosReqResult.ValidRequest
    |"1" -> PosReqResult.InvalidOrUnsupportedRequest
    |"2" -> PosReqResult.NoPositionsFoundThatMatchCriteria
    |"3" -> PosReqResult.NotAuthorizedToRequestPositions
    |"4" -> PosReqResult.RequestForPositionNotSupported
    |"99" -> PosReqResult.Other
    | x -> failwith (sprintf "ReadPosReqResult unknown fix tag: %A"  x) 


let WritePosReqResult (strm:Stream) (xxIn:PosReqResult) =
    match xxIn with
    | PosReqResult.ValidRequest -> strm.Write "728=0"B; strm.Write (delim, 0, 1)
    | PosReqResult.InvalidOrUnsupportedRequest -> strm.Write "728=1"B; strm.Write (delim, 0, 1)
    | PosReqResult.NoPositionsFoundThatMatchCriteria -> strm.Write "728=2"B; strm.Write (delim, 0, 1)
    | PosReqResult.NotAuthorizedToRequestPositions -> strm.Write "728=3"B; strm.Write (delim, 0, 1)
    | PosReqResult.RequestForPositionNotSupported -> strm.Write "728=4"B; strm.Write (delim, 0, 1)
    | PosReqResult.Other -> strm.Write "728=99"B; strm.Write (delim, 0, 1)


let ReadPosReqStatus (fldValIn:string) : PosReqStatus = 
    match fldValIn with
    |"0" -> PosReqStatus.Completed
    |"1" -> PosReqStatus.CompletedWithWarnings
    |"2" -> PosReqStatus.Rejected
    | x -> failwith (sprintf "ReadPosReqStatus unknown fix tag: %A"  x) 


let WritePosReqStatus (strm:Stream) (xxIn:PosReqStatus) =
    match xxIn with
    | PosReqStatus.Completed -> strm.Write "729=0"B; strm.Write (delim, 0, 1)
    | PosReqStatus.CompletedWithWarnings -> strm.Write "729=1"B; strm.Write (delim, 0, 1)
    | PosReqStatus.Rejected -> strm.Write "729=2"B; strm.Write (delim, 0, 1)


let ReadSettlPrice valIn =
    let tmp = System.Decimal.Parse valIn
    SettlPrice.SettlPrice tmp


let WriteSettlPrice (strm:Stream) (valIn:SettlPrice) = 
    let tag = "730="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlPriceType (fldValIn:string) : SettlPriceType = 
    match fldValIn with
    |"1" -> SettlPriceType.Final
    |"2" -> SettlPriceType.Theoretical
    | x -> failwith (sprintf "ReadSettlPriceType unknown fix tag: %A"  x) 


let WriteSettlPriceType (strm:Stream) (xxIn:SettlPriceType) =
    match xxIn with
    | SettlPriceType.Final -> strm.Write "731=1"B; strm.Write (delim, 0, 1)
    | SettlPriceType.Theoretical -> strm.Write "731=2"B; strm.Write (delim, 0, 1)


let ReadUnderlyingSettlPrice valIn =
    let tmp = System.Decimal.Parse valIn
    UnderlyingSettlPrice.UnderlyingSettlPrice tmp


let WriteUnderlyingSettlPrice (strm:Stream) (valIn:UnderlyingSettlPrice) = 
    let tag = "732="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingSettlPriceType valIn =
    let tmp = System.Int32.Parse valIn
    UnderlyingSettlPriceType.UnderlyingSettlPriceType tmp


let WriteUnderlyingSettlPriceType (strm:Stream) (valIn:UnderlyingSettlPriceType) = 
    let tag = "733="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPriorSettlPrice valIn =
    let tmp = System.Decimal.Parse valIn
    PriorSettlPrice.PriorSettlPrice tmp


let WritePriorSettlPrice (strm:Stream) (valIn:PriorSettlPrice) = 
    let tag = "734="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoQuoteQualifiers valIn =
    let tmp = System.Int32.Parse valIn
    NoQuoteQualifiers.NoQuoteQualifiers tmp


let WriteNoQuoteQualifiers (strm:Stream) (valIn:NoQuoteQualifiers) = 
    let tag = "735="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocSettlCurrency valIn =
    let tmp =  valIn
    AllocSettlCurrency.AllocSettlCurrency tmp


let WriteAllocSettlCurrency (strm:Stream) (valIn:AllocSettlCurrency) = 
    let tag = "736="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocSettlCurrAmt valIn =
    let tmp = System.Int32.Parse valIn
    AllocSettlCurrAmt.AllocSettlCurrAmt tmp


let WriteAllocSettlCurrAmt (strm:Stream) (valIn:AllocSettlCurrAmt) = 
    let tag = "737="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadInterestAtMaturity valIn =
    let tmp = System.Int32.Parse valIn
    InterestAtMaturity.InterestAtMaturity tmp


let WriteInterestAtMaturity (strm:Stream) (valIn:InterestAtMaturity) = 
    let tag = "738="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegDatedDate valIn =
    let tmp =  valIn
    LegDatedDate.LegDatedDate tmp


let WriteLegDatedDate (strm:Stream) (valIn:LegDatedDate) = 
    let tag = "739="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegPool valIn =
    let tmp =  valIn
    LegPool.LegPool tmp


let WriteLegPool (strm:Stream) (valIn:LegPool) = 
    let tag = "740="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocInterestAtMaturity valIn =
    let tmp = System.Int32.Parse valIn
    AllocInterestAtMaturity.AllocInterestAtMaturity tmp


let WriteAllocInterestAtMaturity (strm:Stream) (valIn:AllocInterestAtMaturity) = 
    let tag = "741="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocAccruedInterestAmt valIn =
    let tmp = System.Int32.Parse valIn
    AllocAccruedInterestAmt.AllocAccruedInterestAmt tmp


let WriteAllocAccruedInterestAmt (strm:Stream) (valIn:AllocAccruedInterestAmt) = 
    let tag = "742="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDeliveryDate valIn =
    let tmp =  valIn
    DeliveryDate.DeliveryDate tmp


let WriteDeliveryDate (strm:Stream) (valIn:DeliveryDate) = 
    let tag = "743="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAssignmentMethod (fldValIn:string) : AssignmentMethod = 
    match fldValIn with
    |"R" -> AssignmentMethod.Random
    |"P" -> AssignmentMethod.Prorata
    | x -> failwith (sprintf "ReadAssignmentMethod unknown fix tag: %A"  x) 


let WriteAssignmentMethod (strm:Stream) (xxIn:AssignmentMethod) =
    match xxIn with
    | AssignmentMethod.Random -> strm.Write "744=R"B; strm.Write (delim, 0, 1)
    | AssignmentMethod.Prorata -> strm.Write "744=P"B; strm.Write (delim, 0, 1)


let ReadAssignmentUnit valIn =
    let tmp = System.Decimal.Parse valIn
    AssignmentUnit.AssignmentUnit tmp


let WriteAssignmentUnit (strm:Stream) (valIn:AssignmentUnit) = 
    let tag = "745="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOpenInterest valIn =
    let tmp = System.Int32.Parse valIn
    OpenInterest.OpenInterest tmp


let WriteOpenInterest (strm:Stream) (valIn:OpenInterest) = 
    let tag = "746="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadExerciseMethod (fldValIn:string) : ExerciseMethod = 
    match fldValIn with
    |"A" -> ExerciseMethod.Automatic
    |"M" -> ExerciseMethod.Manual
    | x -> failwith (sprintf "ReadExerciseMethod unknown fix tag: %A"  x) 


let WriteExerciseMethod (strm:Stream) (xxIn:ExerciseMethod) =
    match xxIn with
    | ExerciseMethod.Automatic -> strm.Write "747=A"B; strm.Write (delim, 0, 1)
    | ExerciseMethod.Manual -> strm.Write "747=M"B; strm.Write (delim, 0, 1)


let ReadTotNumTradeReports valIn =
    let tmp = System.Int32.Parse valIn
    TotNumTradeReports.TotNumTradeReports tmp


let WriteTotNumTradeReports (strm:Stream) (valIn:TotNumTradeReports) = 
    let tag = "748="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradeRequestResult (fldValIn:string) : TradeRequestResult = 
    match fldValIn with
    |"0" -> TradeRequestResult.Successful
    |"1" -> TradeRequestResult.InvalidOrUnknownInstrument
    |"2" -> TradeRequestResult.InvalidTypeOfTradeRequested
    |"3" -> TradeRequestResult.InvalidParties
    |"4" -> TradeRequestResult.InvalidTransportTypeRequested
    |"5" -> TradeRequestResult.InvalidDestinationRequested
    |"8" -> TradeRequestResult.TraderequesttypeNotSupported
    |"9" -> TradeRequestResult.UnauthorizedForTradeCaptureReportRequest
    |"10" -> TradeRequestResult.Yield
    | x -> failwith (sprintf "ReadTradeRequestResult unknown fix tag: %A"  x) 


let WriteTradeRequestResult (strm:Stream) (xxIn:TradeRequestResult) =
    match xxIn with
    | TradeRequestResult.Successful -> strm.Write "749=0"B; strm.Write (delim, 0, 1)
    | TradeRequestResult.InvalidOrUnknownInstrument -> strm.Write "749=1"B; strm.Write (delim, 0, 1)
    | TradeRequestResult.InvalidTypeOfTradeRequested -> strm.Write "749=2"B; strm.Write (delim, 0, 1)
    | TradeRequestResult.InvalidParties -> strm.Write "749=3"B; strm.Write (delim, 0, 1)
    | TradeRequestResult.InvalidTransportTypeRequested -> strm.Write "749=4"B; strm.Write (delim, 0, 1)
    | TradeRequestResult.InvalidDestinationRequested -> strm.Write "749=5"B; strm.Write (delim, 0, 1)
    | TradeRequestResult.TraderequesttypeNotSupported -> strm.Write "749=8"B; strm.Write (delim, 0, 1)
    | TradeRequestResult.UnauthorizedForTradeCaptureReportRequest -> strm.Write "749=9"B; strm.Write (delim, 0, 1)
    | TradeRequestResult.Yield -> strm.Write "749=10"B; strm.Write (delim, 0, 1)


let ReadTradeRequestStatus (fldValIn:string) : TradeRequestStatus = 
    match fldValIn with
    |"0" -> TradeRequestStatus.Accepted
    |"1" -> TradeRequestStatus.Completed
    |"2" -> TradeRequestStatus.Rejected
    | x -> failwith (sprintf "ReadTradeRequestStatus unknown fix tag: %A"  x) 


let WriteTradeRequestStatus (strm:Stream) (xxIn:TradeRequestStatus) =
    match xxIn with
    | TradeRequestStatus.Accepted -> strm.Write "750=0"B; strm.Write (delim, 0, 1)
    | TradeRequestStatus.Completed -> strm.Write "750=1"B; strm.Write (delim, 0, 1)
    | TradeRequestStatus.Rejected -> strm.Write "750=2"B; strm.Write (delim, 0, 1)


let ReadTradeReportRejectReason (fldValIn:string) : TradeReportRejectReason = 
    match fldValIn with
    |"0" -> TradeReportRejectReason.Successful
    |"1" -> TradeReportRejectReason.InvalidPartyInformation
    |"2" -> TradeReportRejectReason.UnknownInstrument
    |"3" -> TradeReportRejectReason.UnauthorizedToReportTrades
    |"4" -> TradeReportRejectReason.InvalidTradeType
    |"10" -> TradeReportRejectReason.Yield
    | x -> failwith (sprintf "ReadTradeReportRejectReason unknown fix tag: %A"  x) 


let WriteTradeReportRejectReason (strm:Stream) (xxIn:TradeReportRejectReason) =
    match xxIn with
    | TradeReportRejectReason.Successful -> strm.Write "751=0"B; strm.Write (delim, 0, 1)
    | TradeReportRejectReason.InvalidPartyInformation -> strm.Write "751=1"B; strm.Write (delim, 0, 1)
    | TradeReportRejectReason.UnknownInstrument -> strm.Write "751=2"B; strm.Write (delim, 0, 1)
    | TradeReportRejectReason.UnauthorizedToReportTrades -> strm.Write "751=3"B; strm.Write (delim, 0, 1)
    | TradeReportRejectReason.InvalidTradeType -> strm.Write "751=4"B; strm.Write (delim, 0, 1)
    | TradeReportRejectReason.Yield -> strm.Write "751=10"B; strm.Write (delim, 0, 1)


let ReadSideMultiLegReportingType (fldValIn:string) : SideMultiLegReportingType = 
    match fldValIn with
    |"1" -> SideMultiLegReportingType.SingleSecurity
    |"2" -> SideMultiLegReportingType.IndividualLegOfAMultiLegSecurity
    |"3" -> SideMultiLegReportingType.MultiLegSecurity
    | x -> failwith (sprintf "ReadSideMultiLegReportingType unknown fix tag: %A"  x) 


let WriteSideMultiLegReportingType (strm:Stream) (xxIn:SideMultiLegReportingType) =
    match xxIn with
    | SideMultiLegReportingType.SingleSecurity -> strm.Write "752=1"B; strm.Write (delim, 0, 1)
    | SideMultiLegReportingType.IndividualLegOfAMultiLegSecurity -> strm.Write "752=2"B; strm.Write (delim, 0, 1)
    | SideMultiLegReportingType.MultiLegSecurity -> strm.Write "752=3"B; strm.Write (delim, 0, 1)


let ReadNoPosAmt valIn =
    let tmp = System.Int32.Parse valIn
    NoPosAmt.NoPosAmt tmp


let WriteNoPosAmt (strm:Stream) (valIn:NoPosAmt) = 
    let tag = "753="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAutoAcceptIndicator valIn =
    let tmp = System.Boolean.Parse valIn
    AutoAcceptIndicator.AutoAcceptIndicator tmp


let WriteAutoAcceptIndicator (strm:Stream) (valIn:AutoAcceptIndicator) = 
    let tag = "754="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocReportID valIn =
    let tmp =  valIn
    AllocReportID.AllocReportID tmp


let WriteAllocReportID (strm:Stream) (valIn:AllocReportID) = 
    let tag = "755="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoNested2PartyIDs valIn =
    let tmp = System.Int32.Parse valIn
    NoNested2PartyIDs.NoNested2PartyIDs tmp


let WriteNoNested2PartyIDs (strm:Stream) (valIn:NoNested2PartyIDs) = 
    let tag = "756="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNested2PartyID valIn =
    let tmp =  valIn
    Nested2PartyID.Nested2PartyID tmp


let WriteNested2PartyID (strm:Stream) (valIn:Nested2PartyID) = 
    let tag = "757="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNested2PartyIDSource valIn =
    let tmp = System.Int32.Parse valIn
    Nested2PartyIDSource.Nested2PartyIDSource tmp


let WriteNested2PartyIDSource (strm:Stream) (valIn:Nested2PartyIDSource) = 
    let tag = "758="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNested2PartyRole valIn =
    let tmp = System.Int32.Parse valIn
    Nested2PartyRole.Nested2PartyRole tmp


let WriteNested2PartyRole (strm:Stream) (valIn:Nested2PartyRole) = 
    let tag = "759="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNested2PartySubID valIn =
    let tmp =  valIn
    Nested2PartySubID.Nested2PartySubID tmp


let WriteNested2PartySubID (strm:Stream) (valIn:Nested2PartySubID) = 
    let tag = "760="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadBenchmarkSecurityIDSource valIn =
    let tmp =  valIn
    BenchmarkSecurityIDSource.BenchmarkSecurityIDSource tmp


let WriteBenchmarkSecurityIDSource (strm:Stream) (valIn:BenchmarkSecurityIDSource) = 
    let tag = "761="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecuritySubType valIn =
    let tmp =  valIn
    SecuritySubType.SecuritySubType tmp


let WriteSecuritySubType (strm:Stream) (valIn:SecuritySubType) = 
    let tag = "762="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingSecuritySubType valIn =
    let tmp =  valIn
    UnderlyingSecuritySubType.UnderlyingSecuritySubType tmp


let WriteUnderlyingSecuritySubType (strm:Stream) (valIn:UnderlyingSecuritySubType) = 
    let tag = "763="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegSecuritySubType valIn =
    let tmp =  valIn
    LegSecuritySubType.LegSecuritySubType tmp


let WriteLegSecuritySubType (strm:Stream) (valIn:LegSecuritySubType) = 
    let tag = "764="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllowableOneSidednessPct valIn =
    let tmp = System.Decimal.Parse valIn
    AllowableOneSidednessPct.AllowableOneSidednessPct tmp


let WriteAllowableOneSidednessPct (strm:Stream) (valIn:AllowableOneSidednessPct) = 
    let tag = "765="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllowableOneSidednessValue valIn =
    let tmp = System.Int32.Parse valIn
    AllowableOneSidednessValue.AllowableOneSidednessValue tmp


let WriteAllowableOneSidednessValue (strm:Stream) (valIn:AllowableOneSidednessValue) = 
    let tag = "766="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllowableOneSidednessCurr valIn =
    let tmp =  valIn
    AllowableOneSidednessCurr.AllowableOneSidednessCurr tmp


let WriteAllowableOneSidednessCurr (strm:Stream) (valIn:AllowableOneSidednessCurr) = 
    let tag = "767="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoTrdRegTimestamps valIn =
    let tmp = System.Int32.Parse valIn
    NoTrdRegTimestamps.NoTrdRegTimestamps tmp


let WriteNoTrdRegTimestamps (strm:Stream) (valIn:NoTrdRegTimestamps) = 
    let tag = "768="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTrdRegTimestamp valIn =
    let tmp =  valIn
    TrdRegTimestamp.TrdRegTimestamp tmp


let WriteTrdRegTimestamp (strm:Stream) (valIn:TrdRegTimestamp) = 
    let tag = "769="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTrdRegTimestampType (fldValIn:string) : TrdRegTimestampType = 
    match fldValIn with
    |"1" -> TrdRegTimestampType.ExecutionTime
    |"2" -> TrdRegTimestampType.TimeIn
    |"3" -> TrdRegTimestampType.TimeOut
    |"4" -> TrdRegTimestampType.BrokerReceipt
    |"5" -> TrdRegTimestampType.BrokerExecution
    | x -> failwith (sprintf "ReadTrdRegTimestampType unknown fix tag: %A"  x) 


let WriteTrdRegTimestampType (strm:Stream) (xxIn:TrdRegTimestampType) =
    match xxIn with
    | TrdRegTimestampType.ExecutionTime -> strm.Write "770=1"B; strm.Write (delim, 0, 1)
    | TrdRegTimestampType.TimeIn -> strm.Write "770=2"B; strm.Write (delim, 0, 1)
    | TrdRegTimestampType.TimeOut -> strm.Write "770=3"B; strm.Write (delim, 0, 1)
    | TrdRegTimestampType.BrokerReceipt -> strm.Write "770=4"B; strm.Write (delim, 0, 1)
    | TrdRegTimestampType.BrokerExecution -> strm.Write "770=5"B; strm.Write (delim, 0, 1)


let ReadTrdRegTimestampOrigin valIn =
    let tmp =  valIn
    TrdRegTimestampOrigin.TrdRegTimestampOrigin tmp


let WriteTrdRegTimestampOrigin (strm:Stream) (valIn:TrdRegTimestampOrigin) = 
    let tag = "771="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadConfirmRefID valIn =
    let tmp =  valIn
    ConfirmRefID.ConfirmRefID tmp


let WriteConfirmRefID (strm:Stream) (valIn:ConfirmRefID) = 
    let tag = "772="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadConfirmType (fldValIn:string) : ConfirmType = 
    match fldValIn with
    |"1" -> ConfirmType.Status
    |"2" -> ConfirmType.Confirmation
    |"3" -> ConfirmType.ConfirmationRequestRejected
    | x -> failwith (sprintf "ReadConfirmType unknown fix tag: %A"  x) 


let WriteConfirmType (strm:Stream) (xxIn:ConfirmType) =
    match xxIn with
    | ConfirmType.Status -> strm.Write "773=1"B; strm.Write (delim, 0, 1)
    | ConfirmType.Confirmation -> strm.Write "773=2"B; strm.Write (delim, 0, 1)
    | ConfirmType.ConfirmationRequestRejected -> strm.Write "773=3"B; strm.Write (delim, 0, 1)


let ReadConfirmRejReason (fldValIn:string) : ConfirmRejReason = 
    match fldValIn with
    |"1" -> ConfirmRejReason.MismatchedAccount
    |"2" -> ConfirmRejReason.MissingSettlementInstructions
    |"99" -> ConfirmRejReason.Other
    | x -> failwith (sprintf "ReadConfirmRejReason unknown fix tag: %A"  x) 


let WriteConfirmRejReason (strm:Stream) (xxIn:ConfirmRejReason) =
    match xxIn with
    | ConfirmRejReason.MismatchedAccount -> strm.Write "774=1"B; strm.Write (delim, 0, 1)
    | ConfirmRejReason.MissingSettlementInstructions -> strm.Write "774=2"B; strm.Write (delim, 0, 1)
    | ConfirmRejReason.Other -> strm.Write "774=99"B; strm.Write (delim, 0, 1)


let ReadBookingType (fldValIn:string) : BookingType = 
    match fldValIn with
    |"0" -> BookingType.RegularBooking
    |"1" -> BookingType.Cfd
    |"2" -> BookingType.TotalReturnSwap
    | x -> failwith (sprintf "ReadBookingType unknown fix tag: %A"  x) 


let WriteBookingType (strm:Stream) (xxIn:BookingType) =
    match xxIn with
    | BookingType.RegularBooking -> strm.Write "775=0"B; strm.Write (delim, 0, 1)
    | BookingType.Cfd -> strm.Write "775=1"B; strm.Write (delim, 0, 1)
    | BookingType.TotalReturnSwap -> strm.Write "775=2"B; strm.Write (delim, 0, 1)


let ReadIndividualAllocRejCode valIn =
    let tmp = System.Int32.Parse valIn
    IndividualAllocRejCode.IndividualAllocRejCode tmp


let WriteIndividualAllocRejCode (strm:Stream) (valIn:IndividualAllocRejCode) = 
    let tag = "776="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlInstMsgID valIn =
    let tmp =  valIn
    SettlInstMsgID.SettlInstMsgID tmp


let WriteSettlInstMsgID (strm:Stream) (valIn:SettlInstMsgID) = 
    let tag = "777="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoSettlInst valIn =
    let tmp = System.Int32.Parse valIn
    NoSettlInst.NoSettlInst tmp


let WriteNoSettlInst (strm:Stream) (valIn:NoSettlInst) = 
    let tag = "778="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLastUpdateTime valIn =
    let tmp =  valIn
    LastUpdateTime.LastUpdateTime tmp


let WriteLastUpdateTime (strm:Stream) (valIn:LastUpdateTime) = 
    let tag = "779="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocSettlInstType (fldValIn:string) : AllocSettlInstType = 
    match fldValIn with
    |"0" -> AllocSettlInstType.UseDefaultInstructions
    |"1" -> AllocSettlInstType.DeriveFromParametersProvided
    |"2" -> AllocSettlInstType.FullDetailsProvided
    |"3" -> AllocSettlInstType.SsiDbIdsProvided
    |"4" -> AllocSettlInstType.PhoneForInstructions
    | x -> failwith (sprintf "ReadAllocSettlInstType unknown fix tag: %A"  x) 


let WriteAllocSettlInstType (strm:Stream) (xxIn:AllocSettlInstType) =
    match xxIn with
    | AllocSettlInstType.UseDefaultInstructions -> strm.Write "780=0"B; strm.Write (delim, 0, 1)
    | AllocSettlInstType.DeriveFromParametersProvided -> strm.Write "780=1"B; strm.Write (delim, 0, 1)
    | AllocSettlInstType.FullDetailsProvided -> strm.Write "780=2"B; strm.Write (delim, 0, 1)
    | AllocSettlInstType.SsiDbIdsProvided -> strm.Write "780=3"B; strm.Write (delim, 0, 1)
    | AllocSettlInstType.PhoneForInstructions -> strm.Write "780=4"B; strm.Write (delim, 0, 1)


let ReadNoSettlPartyIDs valIn =
    let tmp = System.Int32.Parse valIn
    NoSettlPartyIDs.NoSettlPartyIDs tmp


let WriteNoSettlPartyIDs (strm:Stream) (valIn:NoSettlPartyIDs) = 
    let tag = "781="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlPartyID valIn =
    let tmp =  valIn
    SettlPartyID.SettlPartyID tmp


let WriteSettlPartyID (strm:Stream) (valIn:SettlPartyID) = 
    let tag = "782="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlPartyIDSource valIn =
    let tmp = System.Int32.Parse valIn
    SettlPartyIDSource.SettlPartyIDSource tmp


let WriteSettlPartyIDSource (strm:Stream) (valIn:SettlPartyIDSource) = 
    let tag = "783="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlPartyRole valIn =
    let tmp = System.Int32.Parse valIn
    SettlPartyRole.SettlPartyRole tmp


let WriteSettlPartyRole (strm:Stream) (valIn:SettlPartyRole) = 
    let tag = "784="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlPartySubID valIn =
    let tmp =  valIn
    SettlPartySubID.SettlPartySubID tmp


let WriteSettlPartySubID (strm:Stream) (valIn:SettlPartySubID) = 
    let tag = "785="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlPartySubIDType valIn =
    let tmp = System.Int32.Parse valIn
    SettlPartySubIDType.SettlPartySubIDType tmp


let WriteSettlPartySubIDType (strm:Stream) (valIn:SettlPartySubIDType) = 
    let tag = "786="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDlvyInstType (fldValIn:string) : DlvyInstType = 
    match fldValIn with
    |"S" -> DlvyInstType.Securities
    |"C" -> DlvyInstType.Cash
    | x -> failwith (sprintf "ReadDlvyInstType unknown fix tag: %A"  x) 


let WriteDlvyInstType (strm:Stream) (xxIn:DlvyInstType) =
    match xxIn with
    | DlvyInstType.Securities -> strm.Write "787=S"B; strm.Write (delim, 0, 1)
    | DlvyInstType.Cash -> strm.Write "787=C"B; strm.Write (delim, 0, 1)


let ReadTerminationType (fldValIn:string) : TerminationType = 
    match fldValIn with
    |"1" -> TerminationType.Overnight
    |"2" -> TerminationType.Term
    |"3" -> TerminationType.Flexible
    |"4" -> TerminationType.Open
    | x -> failwith (sprintf "ReadTerminationType unknown fix tag: %A"  x) 


let WriteTerminationType (strm:Stream) (xxIn:TerminationType) =
    match xxIn with
    | TerminationType.Overnight -> strm.Write "788=1"B; strm.Write (delim, 0, 1)
    | TerminationType.Term -> strm.Write "788=2"B; strm.Write (delim, 0, 1)
    | TerminationType.Flexible -> strm.Write "788=3"B; strm.Write (delim, 0, 1)
    | TerminationType.Open -> strm.Write "788=4"B; strm.Write (delim, 0, 1)


let ReadNextExpectedMsgSeqNum valIn =
    let tmp = System.Int32.Parse valIn
    NextExpectedMsgSeqNum.NextExpectedMsgSeqNum tmp


let WriteNextExpectedMsgSeqNum (strm:Stream) (valIn:NextExpectedMsgSeqNum) = 
    let tag = "789="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOrdStatusReqID valIn =
    let tmp =  valIn
    OrdStatusReqID.OrdStatusReqID tmp


let WriteOrdStatusReqID (strm:Stream) (valIn:OrdStatusReqID) = 
    let tag = "790="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlInstReqID valIn =
    let tmp =  valIn
    SettlInstReqID.SettlInstReqID tmp


let WriteSettlInstReqID (strm:Stream) (valIn:SettlInstReqID) = 
    let tag = "791="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSettlInstReqRejCode (fldValIn:string) : SettlInstReqRejCode = 
    match fldValIn with
    |"0" -> SettlInstReqRejCode.UnableToProcessRequest
    |"1" -> SettlInstReqRejCode.UnknownAccount
    |"2" -> SettlInstReqRejCode.NoMatchingSettlementInstructionsFound
    |"99" -> SettlInstReqRejCode.Other
    | x -> failwith (sprintf "ReadSettlInstReqRejCode unknown fix tag: %A"  x) 


let WriteSettlInstReqRejCode (strm:Stream) (xxIn:SettlInstReqRejCode) =
    match xxIn with
    | SettlInstReqRejCode.UnableToProcessRequest -> strm.Write "792=0"B; strm.Write (delim, 0, 1)
    | SettlInstReqRejCode.UnknownAccount -> strm.Write "792=1"B; strm.Write (delim, 0, 1)
    | SettlInstReqRejCode.NoMatchingSettlementInstructionsFound -> strm.Write "792=2"B; strm.Write (delim, 0, 1)
    | SettlInstReqRejCode.Other -> strm.Write "792=99"B; strm.Write (delim, 0, 1)


let ReadSecondaryAllocID valIn =
    let tmp =  valIn
    SecondaryAllocID.SecondaryAllocID tmp


let WriteSecondaryAllocID (strm:Stream) (valIn:SecondaryAllocID) = 
    let tag = "793="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocReportType (fldValIn:string) : AllocReportType = 
    match fldValIn with
    |"3" -> AllocReportType.SellsideCalculatedUsingPreliminary
    |"4" -> AllocReportType.SellsideCalculatedWithoutPreliminary
    |"5" -> AllocReportType.WarehouseRecap
    |"8" -> AllocReportType.RequestToIntermediary
    | x -> failwith (sprintf "ReadAllocReportType unknown fix tag: %A"  x) 


let WriteAllocReportType (strm:Stream) (xxIn:AllocReportType) =
    match xxIn with
    | AllocReportType.SellsideCalculatedUsingPreliminary -> strm.Write "794=3"B; strm.Write (delim, 0, 1)
    | AllocReportType.SellsideCalculatedWithoutPreliminary -> strm.Write "794=4"B; strm.Write (delim, 0, 1)
    | AllocReportType.WarehouseRecap -> strm.Write "794=5"B; strm.Write (delim, 0, 1)
    | AllocReportType.RequestToIntermediary -> strm.Write "794=8"B; strm.Write (delim, 0, 1)


let ReadAllocReportRefID valIn =
    let tmp =  valIn
    AllocReportRefID.AllocReportRefID tmp


let WriteAllocReportRefID (strm:Stream) (valIn:AllocReportRefID) = 
    let tag = "795="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocCancReplaceReason (fldValIn:string) : AllocCancReplaceReason = 
    match fldValIn with
    |"1" -> AllocCancReplaceReason.OriginalDetailsIncompleteIncorrect
    |"2" -> AllocCancReplaceReason.ChangeInUnderlyingOrderDetails
    | x -> failwith (sprintf "ReadAllocCancReplaceReason unknown fix tag: %A"  x) 


let WriteAllocCancReplaceReason (strm:Stream) (xxIn:AllocCancReplaceReason) =
    match xxIn with
    | AllocCancReplaceReason.OriginalDetailsIncompleteIncorrect -> strm.Write "796=1"B; strm.Write (delim, 0, 1)
    | AllocCancReplaceReason.ChangeInUnderlyingOrderDetails -> strm.Write "796=2"B; strm.Write (delim, 0, 1)


let ReadCopyMsgIndicator valIn =
    let tmp = System.Boolean.Parse valIn
    CopyMsgIndicator.CopyMsgIndicator tmp


let WriteCopyMsgIndicator (strm:Stream) (valIn:CopyMsgIndicator) = 
    let tag = "797="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocAccountType (fldValIn:string) : AllocAccountType = 
    match fldValIn with
    |"1" -> AllocAccountType.AccountIsCarriedOnCustomerSideOfBooks
    |"2" -> AllocAccountType.AccountIsCarriedOnNonCustomerSideOfBooks
    |"3" -> AllocAccountType.HouseTrader
    |"4" -> AllocAccountType.FloorTrader
    |"6" -> AllocAccountType.AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined
    |"7" -> AllocAccountType.AccountIsHouseTraderAndIsCrossMargined
    |"8" -> AllocAccountType.JointBackofficeAccount
    | x -> failwith (sprintf "ReadAllocAccountType unknown fix tag: %A"  x) 


let WriteAllocAccountType (strm:Stream) (xxIn:AllocAccountType) =
    match xxIn with
    | AllocAccountType.AccountIsCarriedOnCustomerSideOfBooks -> strm.Write "798=1"B; strm.Write (delim, 0, 1)
    | AllocAccountType.AccountIsCarriedOnNonCustomerSideOfBooks -> strm.Write "798=2"B; strm.Write (delim, 0, 1)
    | AllocAccountType.HouseTrader -> strm.Write "798=3"B; strm.Write (delim, 0, 1)
    | AllocAccountType.FloorTrader -> strm.Write "798=4"B; strm.Write (delim, 0, 1)
    | AllocAccountType.AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined -> strm.Write "798=6"B; strm.Write (delim, 0, 1)
    | AllocAccountType.AccountIsHouseTraderAndIsCrossMargined -> strm.Write "798=7"B; strm.Write (delim, 0, 1)
    | AllocAccountType.JointBackofficeAccount -> strm.Write "798=8"B; strm.Write (delim, 0, 1)


let ReadOrderAvgPx valIn =
    let tmp = System.Decimal.Parse valIn
    OrderAvgPx.OrderAvgPx tmp


let WriteOrderAvgPx (strm:Stream) (valIn:OrderAvgPx) = 
    let tag = "799="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOrderBookingQty valIn =
    let tmp = System.Decimal.Parse valIn
    OrderBookingQty.OrderBookingQty tmp


let WriteOrderBookingQty (strm:Stream) (valIn:OrderBookingQty) = 
    let tag = "800="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoSettlPartySubIDs valIn =
    let tmp = System.Int32.Parse valIn
    NoSettlPartySubIDs.NoSettlPartySubIDs tmp


let WriteNoSettlPartySubIDs (strm:Stream) (valIn:NoSettlPartySubIDs) = 
    let tag = "801="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoPartySubIDs valIn =
    let tmp = System.Int32.Parse valIn
    NoPartySubIDs.NoPartySubIDs tmp


let WriteNoPartySubIDs (strm:Stream) (valIn:NoPartySubIDs) = 
    let tag = "802="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPartySubIDType valIn =
    let tmp = System.Int32.Parse valIn
    PartySubIDType.PartySubIDType tmp


let WritePartySubIDType (strm:Stream) (valIn:PartySubIDType) = 
    let tag = "803="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoNestedPartySubIDs valIn =
    let tmp = System.Int32.Parse valIn
    NoNestedPartySubIDs.NoNestedPartySubIDs tmp


let WriteNoNestedPartySubIDs (strm:Stream) (valIn:NoNestedPartySubIDs) = 
    let tag = "804="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNestedPartySubIDType valIn =
    let tmp = System.Int32.Parse valIn
    NestedPartySubIDType.NestedPartySubIDType tmp


let WriteNestedPartySubIDType (strm:Stream) (valIn:NestedPartySubIDType) = 
    let tag = "805="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoNested2PartySubIDs valIn =
    let tmp = System.Int32.Parse valIn
    NoNested2PartySubIDs.NoNested2PartySubIDs tmp


let WriteNoNested2PartySubIDs (strm:Stream) (valIn:NoNested2PartySubIDs) = 
    let tag = "806="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNested2PartySubIDType valIn =
    let tmp = System.Int32.Parse valIn
    Nested2PartySubIDType.Nested2PartySubIDType tmp


let WriteNested2PartySubIDType (strm:Stream) (valIn:Nested2PartySubIDType) = 
    let tag = "807="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAllocIntermedReqType (fldValIn:string) : AllocIntermedReqType = 
    match fldValIn with
    |"1" -> AllocIntermedReqType.PendingAccept
    |"2" -> AllocIntermedReqType.PendingRelease
    |"3" -> AllocIntermedReqType.PendingReversal
    |"4" -> AllocIntermedReqType.Accept
    |"5" -> AllocIntermedReqType.BlockLevelReject
    |"6" -> AllocIntermedReqType.AccountLevelReject
    | x -> failwith (sprintf "ReadAllocIntermedReqType unknown fix tag: %A"  x) 


let WriteAllocIntermedReqType (strm:Stream) (xxIn:AllocIntermedReqType) =
    match xxIn with
    | AllocIntermedReqType.PendingAccept -> strm.Write "808=1"B; strm.Write (delim, 0, 1)
    | AllocIntermedReqType.PendingRelease -> strm.Write "808=2"B; strm.Write (delim, 0, 1)
    | AllocIntermedReqType.PendingReversal -> strm.Write "808=3"B; strm.Write (delim, 0, 1)
    | AllocIntermedReqType.Accept -> strm.Write "808=4"B; strm.Write (delim, 0, 1)
    | AllocIntermedReqType.BlockLevelReject -> strm.Write "808=5"B; strm.Write (delim, 0, 1)
    | AllocIntermedReqType.AccountLevelReject -> strm.Write "808=6"B; strm.Write (delim, 0, 1)


let ReadUnderlyingPx valIn =
    let tmp = System.Decimal.Parse valIn
    UnderlyingPx.UnderlyingPx tmp


let WriteUnderlyingPx (strm:Stream) (valIn:UnderlyingPx) = 
    let tag = "810="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPriceDelta valIn =
    let tmp = System.Decimal.Parse valIn
    PriceDelta.PriceDelta tmp


let WritePriceDelta (strm:Stream) (valIn:PriceDelta) = 
    let tag = "811="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadApplQueueMax valIn =
    let tmp = System.Int32.Parse valIn
    ApplQueueMax.ApplQueueMax tmp


let WriteApplQueueMax (strm:Stream) (valIn:ApplQueueMax) = 
    let tag = "812="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadApplQueueDepth valIn =
    let tmp = System.Int32.Parse valIn
    ApplQueueDepth.ApplQueueDepth tmp


let WriteApplQueueDepth (strm:Stream) (valIn:ApplQueueDepth) = 
    let tag = "813="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadApplQueueResolution (fldValIn:string) : ApplQueueResolution = 
    match fldValIn with
    |"0" -> ApplQueueResolution.NoActionTaken
    |"1" -> ApplQueueResolution.QueueFlushed
    |"2" -> ApplQueueResolution.OverlayLast
    |"3" -> ApplQueueResolution.EndSession
    | x -> failwith (sprintf "ReadApplQueueResolution unknown fix tag: %A"  x) 


let WriteApplQueueResolution (strm:Stream) (xxIn:ApplQueueResolution) =
    match xxIn with
    | ApplQueueResolution.NoActionTaken -> strm.Write "814=0"B; strm.Write (delim, 0, 1)
    | ApplQueueResolution.QueueFlushed -> strm.Write "814=1"B; strm.Write (delim, 0, 1)
    | ApplQueueResolution.OverlayLast -> strm.Write "814=2"B; strm.Write (delim, 0, 1)
    | ApplQueueResolution.EndSession -> strm.Write "814=3"B; strm.Write (delim, 0, 1)


let ReadApplQueueAction (fldValIn:string) : ApplQueueAction = 
    match fldValIn with
    |"0" -> ApplQueueAction.NoActionTaken
    |"1" -> ApplQueueAction.QueueFlushed
    |"2" -> ApplQueueAction.OverlayLast
    |"3" -> ApplQueueAction.EndSession
    | x -> failwith (sprintf "ReadApplQueueAction unknown fix tag: %A"  x) 


let WriteApplQueueAction (strm:Stream) (xxIn:ApplQueueAction) =
    match xxIn with
    | ApplQueueAction.NoActionTaken -> strm.Write "815=0"B; strm.Write (delim, 0, 1)
    | ApplQueueAction.QueueFlushed -> strm.Write "815=1"B; strm.Write (delim, 0, 1)
    | ApplQueueAction.OverlayLast -> strm.Write "815=2"B; strm.Write (delim, 0, 1)
    | ApplQueueAction.EndSession -> strm.Write "815=3"B; strm.Write (delim, 0, 1)


let ReadNoAltMDSource valIn =
    let tmp = System.Int32.Parse valIn
    NoAltMDSource.NoAltMDSource tmp


let WriteNoAltMDSource (strm:Stream) (valIn:NoAltMDSource) = 
    let tag = "816="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAltMDSourceID valIn =
    let tmp =  valIn
    AltMDSourceID.AltMDSourceID tmp


let WriteAltMDSourceID (strm:Stream) (valIn:AltMDSourceID) = 
    let tag = "817="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecondaryTradeReportID valIn =
    let tmp =  valIn
    SecondaryTradeReportID.SecondaryTradeReportID tmp


let WriteSecondaryTradeReportID (strm:Stream) (valIn:SecondaryTradeReportID) = 
    let tag = "818="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAvgPxIndicator (fldValIn:string) : AvgPxIndicator = 
    match fldValIn with
    |"0" -> AvgPxIndicator.NoAveragePricing
    |"1" -> AvgPxIndicator.TradeIsPartOfAnAveragePriceGroupIdentifiedByTheTradelinkid
    |"2" -> AvgPxIndicator.LastTradeInTheAveragePriceGroupIdentifiedByTheTradelinkid
    | x -> failwith (sprintf "ReadAvgPxIndicator unknown fix tag: %A"  x) 


let WriteAvgPxIndicator (strm:Stream) (xxIn:AvgPxIndicator) =
    match xxIn with
    | AvgPxIndicator.NoAveragePricing -> strm.Write "819=0"B; strm.Write (delim, 0, 1)
    | AvgPxIndicator.TradeIsPartOfAnAveragePriceGroupIdentifiedByTheTradelinkid -> strm.Write "819=1"B; strm.Write (delim, 0, 1)
    | AvgPxIndicator.LastTradeInTheAveragePriceGroupIdentifiedByTheTradelinkid -> strm.Write "819=2"B; strm.Write (delim, 0, 1)


let ReadTradeLinkID valIn =
    let tmp =  valIn
    TradeLinkID.TradeLinkID tmp


let WriteTradeLinkID (strm:Stream) (valIn:TradeLinkID) = 
    let tag = "820="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOrderInputDevice valIn =
    let tmp =  valIn
    OrderInputDevice.OrderInputDevice tmp


let WriteOrderInputDevice (strm:Stream) (valIn:OrderInputDevice) = 
    let tag = "821="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingTradingSessionID valIn =
    let tmp =  valIn
    UnderlyingTradingSessionID.UnderlyingTradingSessionID tmp


let WriteUnderlyingTradingSessionID (strm:Stream) (valIn:UnderlyingTradingSessionID) = 
    let tag = "822="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingTradingSessionSubID valIn =
    let tmp =  valIn
    UnderlyingTradingSessionSubID.UnderlyingTradingSessionSubID tmp


let WriteUnderlyingTradingSessionSubID (strm:Stream) (valIn:UnderlyingTradingSessionSubID) = 
    let tag = "823="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradeLegRefID valIn =
    let tmp =  valIn
    TradeLegRefID.TradeLegRefID tmp


let WriteTradeLegRefID (strm:Stream) (valIn:TradeLegRefID) = 
    let tag = "824="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadExchangeRule valIn =
    let tmp =  valIn
    ExchangeRule.ExchangeRule tmp


let WriteExchangeRule (strm:Stream) (valIn:ExchangeRule) = 
    let tag = "825="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradeAllocIndicator (fldValIn:string) : TradeAllocIndicator = 
    match fldValIn with
    |"0" -> TradeAllocIndicator.AllocationNotRequired
    |"1" -> TradeAllocIndicator.AllocationRequired
    |"2" -> TradeAllocIndicator.UseAllocationProvidedWithTheTrade
    | x -> failwith (sprintf "ReadTradeAllocIndicator unknown fix tag: %A"  x) 


let WriteTradeAllocIndicator (strm:Stream) (xxIn:TradeAllocIndicator) =
    match xxIn with
    | TradeAllocIndicator.AllocationNotRequired -> strm.Write "826=0"B; strm.Write (delim, 0, 1)
    | TradeAllocIndicator.AllocationRequired -> strm.Write "826=1"B; strm.Write (delim, 0, 1)
    | TradeAllocIndicator.UseAllocationProvidedWithTheTrade -> strm.Write "826=2"B; strm.Write (delim, 0, 1)


let ReadExpirationCycle (fldValIn:string) : ExpirationCycle = 
    match fldValIn with
    |"0" -> ExpirationCycle.ExpireOnTradingSessionClose
    |"1" -> ExpirationCycle.ExpireOnTradingSessionOpen
    | x -> failwith (sprintf "ReadExpirationCycle unknown fix tag: %A"  x) 


let WriteExpirationCycle (strm:Stream) (xxIn:ExpirationCycle) =
    match xxIn with
    | ExpirationCycle.ExpireOnTradingSessionClose -> strm.Write "827=0"B; strm.Write (delim, 0, 1)
    | ExpirationCycle.ExpireOnTradingSessionOpen -> strm.Write "827=1"B; strm.Write (delim, 0, 1)


let ReadTrdType (fldValIn:string) : TrdType = 
    match fldValIn with
    |"0" -> TrdType.RegularTrade
    |"1" -> TrdType.BlockTrade
    |"2" -> TrdType.Efp
    |"3" -> TrdType.Transfer
    |"4" -> TrdType.LateTrade
    |"5" -> TrdType.TTrade
    |"6" -> TrdType.WeightedAveragePriceTrade
    |"7" -> TrdType.BunchedTrade
    |"8" -> TrdType.LateBunchedTrade
    |"9" -> TrdType.PriorReferencePriceTrade
    |"10" -> TrdType.AfterHoursTrade
    | x -> failwith (sprintf "ReadTrdType unknown fix tag: %A"  x) 


let WriteTrdType (strm:Stream) (xxIn:TrdType) =
    match xxIn with
    | TrdType.RegularTrade -> strm.Write "828=0"B; strm.Write (delim, 0, 1)
    | TrdType.BlockTrade -> strm.Write "828=1"B; strm.Write (delim, 0, 1)
    | TrdType.Efp -> strm.Write "828=2"B; strm.Write (delim, 0, 1)
    | TrdType.Transfer -> strm.Write "828=3"B; strm.Write (delim, 0, 1)
    | TrdType.LateTrade -> strm.Write "828=4"B; strm.Write (delim, 0, 1)
    | TrdType.TTrade -> strm.Write "828=5"B; strm.Write (delim, 0, 1)
    | TrdType.WeightedAveragePriceTrade -> strm.Write "828=6"B; strm.Write (delim, 0, 1)
    | TrdType.BunchedTrade -> strm.Write "828=7"B; strm.Write (delim, 0, 1)
    | TrdType.LateBunchedTrade -> strm.Write "828=8"B; strm.Write (delim, 0, 1)
    | TrdType.PriorReferencePriceTrade -> strm.Write "828=9"B; strm.Write (delim, 0, 1)
    | TrdType.AfterHoursTrade -> strm.Write "828=10"B; strm.Write (delim, 0, 1)


let ReadTrdSubType valIn =
    let tmp = System.Int32.Parse valIn
    TrdSubType.TrdSubType tmp


let WriteTrdSubType (strm:Stream) (valIn:TrdSubType) = 
    let tag = "829="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTransferReason valIn =
    let tmp =  valIn
    TransferReason.TransferReason tmp


let WriteTransferReason (strm:Stream) (valIn:TransferReason) = 
    let tag = "830="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAsgnReqID valIn =
    let tmp =  valIn
    AsgnReqID.AsgnReqID tmp


let WriteAsgnReqID (strm:Stream) (valIn:AsgnReqID) = 
    let tag = "831="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTotNumAssignmentReports valIn =
    let tmp = System.Int32.Parse valIn
    TotNumAssignmentReports.TotNumAssignmentReports tmp


let WriteTotNumAssignmentReports (strm:Stream) (valIn:TotNumAssignmentReports) = 
    let tag = "832="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAsgnRptID valIn =
    let tmp =  valIn
    AsgnRptID.AsgnRptID tmp


let WriteAsgnRptID (strm:Stream) (valIn:AsgnRptID) = 
    let tag = "833="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadThresholdAmount valIn =
    let tmp = System.Decimal.Parse valIn
    ThresholdAmount.ThresholdAmount tmp


let WriteThresholdAmount (strm:Stream) (valIn:ThresholdAmount) = 
    let tag = "834="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPegMoveType (fldValIn:string) : PegMoveType = 
    match fldValIn with
    |"0" -> PegMoveType.Floating
    |"1" -> PegMoveType.Fixed
    | x -> failwith (sprintf "ReadPegMoveType unknown fix tag: %A"  x) 


let WritePegMoveType (strm:Stream) (xxIn:PegMoveType) =
    match xxIn with
    | PegMoveType.Floating -> strm.Write "835=0"B; strm.Write (delim, 0, 1)
    | PegMoveType.Fixed -> strm.Write "835=1"B; strm.Write (delim, 0, 1)


let ReadPegOffsetType (fldValIn:string) : PegOffsetType = 
    match fldValIn with
    |"0" -> PegOffsetType.Price
    |"1" -> PegOffsetType.BasisPoints
    |"2" -> PegOffsetType.Ticks
    |"3" -> PegOffsetType.PriceTierLevel
    | x -> failwith (sprintf "ReadPegOffsetType unknown fix tag: %A"  x) 


let WritePegOffsetType (strm:Stream) (xxIn:PegOffsetType) =
    match xxIn with
    | PegOffsetType.Price -> strm.Write "836=0"B; strm.Write (delim, 0, 1)
    | PegOffsetType.BasisPoints -> strm.Write "836=1"B; strm.Write (delim, 0, 1)
    | PegOffsetType.Ticks -> strm.Write "836=2"B; strm.Write (delim, 0, 1)
    | PegOffsetType.PriceTierLevel -> strm.Write "836=3"B; strm.Write (delim, 0, 1)


let ReadPegLimitType (fldValIn:string) : PegLimitType = 
    match fldValIn with
    |"0" -> PegLimitType.OrBetter
    |"1" -> PegLimitType.Strict
    |"2" -> PegLimitType.OrWorse
    | x -> failwith (sprintf "ReadPegLimitType unknown fix tag: %A"  x) 


let WritePegLimitType (strm:Stream) (xxIn:PegLimitType) =
    match xxIn with
    | PegLimitType.OrBetter -> strm.Write "837=0"B; strm.Write (delim, 0, 1)
    | PegLimitType.Strict -> strm.Write "837=1"B; strm.Write (delim, 0, 1)
    | PegLimitType.OrWorse -> strm.Write "837=2"B; strm.Write (delim, 0, 1)


let ReadPegRoundDirection (fldValIn:string) : PegRoundDirection = 
    match fldValIn with
    |"1" -> PegRoundDirection.MoreAggressive
    |"2" -> PegRoundDirection.MorePassive
    | x -> failwith (sprintf "ReadPegRoundDirection unknown fix tag: %A"  x) 


let WritePegRoundDirection (strm:Stream) (xxIn:PegRoundDirection) =
    match xxIn with
    | PegRoundDirection.MoreAggressive -> strm.Write "838=1"B; strm.Write (delim, 0, 1)
    | PegRoundDirection.MorePassive -> strm.Write "838=2"B; strm.Write (delim, 0, 1)


let ReadPeggedPrice valIn =
    let tmp = System.Decimal.Parse valIn
    PeggedPrice.PeggedPrice tmp


let WritePeggedPrice (strm:Stream) (valIn:PeggedPrice) = 
    let tag = "839="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPegScope (fldValIn:string) : PegScope = 
    match fldValIn with
    |"1" -> PegScope.Local
    |"2" -> PegScope.National
    |"3" -> PegScope.Global
    |"4" -> PegScope.NationalExcludingLocal
    | x -> failwith (sprintf "ReadPegScope unknown fix tag: %A"  x) 


let WritePegScope (strm:Stream) (xxIn:PegScope) =
    match xxIn with
    | PegScope.Local -> strm.Write "840=1"B; strm.Write (delim, 0, 1)
    | PegScope.National -> strm.Write "840=2"B; strm.Write (delim, 0, 1)
    | PegScope.Global -> strm.Write "840=3"B; strm.Write (delim, 0, 1)
    | PegScope.NationalExcludingLocal -> strm.Write "840=4"B; strm.Write (delim, 0, 1)


let ReadDiscretionMoveType (fldValIn:string) : DiscretionMoveType = 
    match fldValIn with
    |"0" -> DiscretionMoveType.Floating
    |"1" -> DiscretionMoveType.Fixed
    | x -> failwith (sprintf "ReadDiscretionMoveType unknown fix tag: %A"  x) 


let WriteDiscretionMoveType (strm:Stream) (xxIn:DiscretionMoveType) =
    match xxIn with
    | DiscretionMoveType.Floating -> strm.Write "841=0"B; strm.Write (delim, 0, 1)
    | DiscretionMoveType.Fixed -> strm.Write "841=1"B; strm.Write (delim, 0, 1)


let ReadDiscretionOffsetType (fldValIn:string) : DiscretionOffsetType = 
    match fldValIn with
    |"0" -> DiscretionOffsetType.Price
    |"1" -> DiscretionOffsetType.BasisPoints
    |"2" -> DiscretionOffsetType.Ticks
    |"3" -> DiscretionOffsetType.PriceTierLevel
    | x -> failwith (sprintf "ReadDiscretionOffsetType unknown fix tag: %A"  x) 


let WriteDiscretionOffsetType (strm:Stream) (xxIn:DiscretionOffsetType) =
    match xxIn with
    | DiscretionOffsetType.Price -> strm.Write "842=0"B; strm.Write (delim, 0, 1)
    | DiscretionOffsetType.BasisPoints -> strm.Write "842=1"B; strm.Write (delim, 0, 1)
    | DiscretionOffsetType.Ticks -> strm.Write "842=2"B; strm.Write (delim, 0, 1)
    | DiscretionOffsetType.PriceTierLevel -> strm.Write "842=3"B; strm.Write (delim, 0, 1)


let ReadDiscretionLimitType (fldValIn:string) : DiscretionLimitType = 
    match fldValIn with
    |"0" -> DiscretionLimitType.OrBetter
    |"1" -> DiscretionLimitType.Strict
    |"2" -> DiscretionLimitType.OrWorse
    | x -> failwith (sprintf "ReadDiscretionLimitType unknown fix tag: %A"  x) 


let WriteDiscretionLimitType (strm:Stream) (xxIn:DiscretionLimitType) =
    match xxIn with
    | DiscretionLimitType.OrBetter -> strm.Write "843=0"B; strm.Write (delim, 0, 1)
    | DiscretionLimitType.Strict -> strm.Write "843=1"B; strm.Write (delim, 0, 1)
    | DiscretionLimitType.OrWorse -> strm.Write "843=2"B; strm.Write (delim, 0, 1)


let ReadDiscretionRoundDirection (fldValIn:string) : DiscretionRoundDirection = 
    match fldValIn with
    |"1" -> DiscretionRoundDirection.MoreAggressive
    |"2" -> DiscretionRoundDirection.MorePassive
    | x -> failwith (sprintf "ReadDiscretionRoundDirection unknown fix tag: %A"  x) 


let WriteDiscretionRoundDirection (strm:Stream) (xxIn:DiscretionRoundDirection) =
    match xxIn with
    | DiscretionRoundDirection.MoreAggressive -> strm.Write "844=1"B; strm.Write (delim, 0, 1)
    | DiscretionRoundDirection.MorePassive -> strm.Write "844=2"B; strm.Write (delim, 0, 1)


let ReadDiscretionPrice valIn =
    let tmp = System.Decimal.Parse valIn
    DiscretionPrice.DiscretionPrice tmp


let WriteDiscretionPrice (strm:Stream) (valIn:DiscretionPrice) = 
    let tag = "845="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDiscretionScope (fldValIn:string) : DiscretionScope = 
    match fldValIn with
    |"1" -> DiscretionScope.Local
    |"2" -> DiscretionScope.National
    |"3" -> DiscretionScope.Global
    |"4" -> DiscretionScope.NationalExcludingLocal
    | x -> failwith (sprintf "ReadDiscretionScope unknown fix tag: %A"  x) 


let WriteDiscretionScope (strm:Stream) (xxIn:DiscretionScope) =
    match xxIn with
    | DiscretionScope.Local -> strm.Write "846=1"B; strm.Write (delim, 0, 1)
    | DiscretionScope.National -> strm.Write "846=2"B; strm.Write (delim, 0, 1)
    | DiscretionScope.Global -> strm.Write "846=3"B; strm.Write (delim, 0, 1)
    | DiscretionScope.NationalExcludingLocal -> strm.Write "846=4"B; strm.Write (delim, 0, 1)


let ReadTargetStrategy valIn =
    let tmp = System.Int32.Parse valIn
    TargetStrategy.TargetStrategy tmp


let WriteTargetStrategy (strm:Stream) (valIn:TargetStrategy) = 
    let tag = "847="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTargetStrategyParameters valIn =
    let tmp =  valIn
    TargetStrategyParameters.TargetStrategyParameters tmp


let WriteTargetStrategyParameters (strm:Stream) (valIn:TargetStrategyParameters) = 
    let tag = "848="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadParticipationRate valIn =
    let tmp = System.Decimal.Parse valIn
    ParticipationRate.ParticipationRate tmp


let WriteParticipationRate (strm:Stream) (valIn:ParticipationRate) = 
    let tag = "849="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTargetStrategyPerformance valIn =
    let tmp = System.Decimal.Parse valIn
    TargetStrategyPerformance.TargetStrategyPerformance tmp


let WriteTargetStrategyPerformance (strm:Stream) (valIn:TargetStrategyPerformance) = 
    let tag = "850="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLastLiquidityInd (fldValIn:string) : LastLiquidityInd = 
    match fldValIn with
    |"1" -> LastLiquidityInd.AddedLiquidity
    |"2" -> LastLiquidityInd.RemovedLiquidity
    |"3" -> LastLiquidityInd.LiquidityRoutedOut
    | x -> failwith (sprintf "ReadLastLiquidityInd unknown fix tag: %A"  x) 


let WriteLastLiquidityInd (strm:Stream) (xxIn:LastLiquidityInd) =
    match xxIn with
    | LastLiquidityInd.AddedLiquidity -> strm.Write "851=1"B; strm.Write (delim, 0, 1)
    | LastLiquidityInd.RemovedLiquidity -> strm.Write "851=2"B; strm.Write (delim, 0, 1)
    | LastLiquidityInd.LiquidityRoutedOut -> strm.Write "851=3"B; strm.Write (delim, 0, 1)


let ReadPublishTrdIndicator valIn =
    let tmp = System.Boolean.Parse valIn
    PublishTrdIndicator.PublishTrdIndicator tmp


let WritePublishTrdIndicator (strm:Stream) (valIn:PublishTrdIndicator) = 
    let tag = "852="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadShortSaleReason (fldValIn:string) : ShortSaleReason = 
    match fldValIn with
    |"0" -> ShortSaleReason.DealerSoldShort
    |"1" -> ShortSaleReason.DealerSoldShortExempt
    |"2" -> ShortSaleReason.SellingCustomerSoldShort
    |"3" -> ShortSaleReason.SellingCustomerSoldShortExempt
    |"4" -> ShortSaleReason.QualifedServiceRepresentativeOrAutomaticGiveupContraSideSoldShort
    |"5" -> ShortSaleReason.QsrOrAguContraSideSoldShortExempt
    | x -> failwith (sprintf "ReadShortSaleReason unknown fix tag: %A"  x) 


let WriteShortSaleReason (strm:Stream) (xxIn:ShortSaleReason) =
    match xxIn with
    | ShortSaleReason.DealerSoldShort -> strm.Write "853=0"B; strm.Write (delim, 0, 1)
    | ShortSaleReason.DealerSoldShortExempt -> strm.Write "853=1"B; strm.Write (delim, 0, 1)
    | ShortSaleReason.SellingCustomerSoldShort -> strm.Write "853=2"B; strm.Write (delim, 0, 1)
    | ShortSaleReason.SellingCustomerSoldShortExempt -> strm.Write "853=3"B; strm.Write (delim, 0, 1)
    | ShortSaleReason.QualifedServiceRepresentativeOrAutomaticGiveupContraSideSoldShort -> strm.Write "853=4"B; strm.Write (delim, 0, 1)
    | ShortSaleReason.QsrOrAguContraSideSoldShortExempt -> strm.Write "853=5"B; strm.Write (delim, 0, 1)


let ReadQtyType (fldValIn:string) : QtyType = 
    match fldValIn with
    |"0" -> QtyType.Units
    |"1" -> QtyType.Contracts
    | x -> failwith (sprintf "ReadQtyType unknown fix tag: %A"  x) 


let WriteQtyType (strm:Stream) (xxIn:QtyType) =
    match xxIn with
    | QtyType.Units -> strm.Write "854=0"B; strm.Write (delim, 0, 1)
    | QtyType.Contracts -> strm.Write "854=1"B; strm.Write (delim, 0, 1)


let ReadSecondaryTrdType valIn =
    let tmp = System.Int32.Parse valIn
    SecondaryTrdType.SecondaryTrdType tmp


let WriteSecondaryTrdType (strm:Stream) (valIn:SecondaryTrdType) = 
    let tag = "855="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTradeReportType (fldValIn:string) : TradeReportType = 
    match fldValIn with
    |"0" -> TradeReportType.Submit
    |"1" -> TradeReportType.Alleged
    |"2" -> TradeReportType.Accept
    |"3" -> TradeReportType.Decline
    |"4" -> TradeReportType.Addendum
    |"5" -> TradeReportType.NoWas
    |"6" -> TradeReportType.TradeReportCancel
    |"7" -> TradeReportType.LockedInTradeBreak
    | x -> failwith (sprintf "ReadTradeReportType unknown fix tag: %A"  x) 


let WriteTradeReportType (strm:Stream) (xxIn:TradeReportType) =
    match xxIn with
    | TradeReportType.Submit -> strm.Write "856=0"B; strm.Write (delim, 0, 1)
    | TradeReportType.Alleged -> strm.Write "856=1"B; strm.Write (delim, 0, 1)
    | TradeReportType.Accept -> strm.Write "856=2"B; strm.Write (delim, 0, 1)
    | TradeReportType.Decline -> strm.Write "856=3"B; strm.Write (delim, 0, 1)
    | TradeReportType.Addendum -> strm.Write "856=4"B; strm.Write (delim, 0, 1)
    | TradeReportType.NoWas -> strm.Write "856=5"B; strm.Write (delim, 0, 1)
    | TradeReportType.TradeReportCancel -> strm.Write "856=6"B; strm.Write (delim, 0, 1)
    | TradeReportType.LockedInTradeBreak -> strm.Write "856=7"B; strm.Write (delim, 0, 1)


let ReadAllocNoOrdersType (fldValIn:string) : AllocNoOrdersType = 
    match fldValIn with
    |"0" -> AllocNoOrdersType.NotSpecified
    |"1" -> AllocNoOrdersType.ExplicitListProvided
    | x -> failwith (sprintf "ReadAllocNoOrdersType unknown fix tag: %A"  x) 


let WriteAllocNoOrdersType (strm:Stream) (xxIn:AllocNoOrdersType) =
    match xxIn with
    | AllocNoOrdersType.NotSpecified -> strm.Write "857=0"B; strm.Write (delim, 0, 1)
    | AllocNoOrdersType.ExplicitListProvided -> strm.Write "857=1"B; strm.Write (delim, 0, 1)


let ReadSharedCommission valIn =
    let tmp = System.Int32.Parse valIn
    SharedCommission.SharedCommission tmp


let WriteSharedCommission (strm:Stream) (valIn:SharedCommission) = 
    let tag = "858="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadConfirmReqID valIn =
    let tmp =  valIn
    ConfirmReqID.ConfirmReqID tmp


let WriteConfirmReqID (strm:Stream) (valIn:ConfirmReqID) = 
    let tag = "859="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAvgParPx valIn =
    let tmp = System.Decimal.Parse valIn
    AvgParPx.AvgParPx tmp


let WriteAvgParPx (strm:Stream) (valIn:AvgParPx) = 
    let tag = "860="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadReportedPx valIn =
    let tmp = System.Decimal.Parse valIn
    ReportedPx.ReportedPx tmp


let WriteReportedPx (strm:Stream) (valIn:ReportedPx) = 
    let tag = "861="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoCapacities valIn =
    let tmp = System.Int32.Parse valIn
    NoCapacities.NoCapacities tmp


let WriteNoCapacities (strm:Stream) (valIn:NoCapacities) = 
    let tag = "862="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadOrderCapacityQty valIn =
    let tmp = System.Decimal.Parse valIn
    OrderCapacityQty.OrderCapacityQty tmp


let WriteOrderCapacityQty (strm:Stream) (valIn:OrderCapacityQty) = 
    let tag = "863="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoEvents valIn =
    let tmp = System.Int32.Parse valIn
    NoEvents.NoEvents tmp


let WriteNoEvents (strm:Stream) (valIn:NoEvents) = 
    let tag = "864="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadEventType (fldValIn:string) : EventType = 
    match fldValIn with
    |"1" -> EventType.Put
    |"2" -> EventType.Call
    |"3" -> EventType.Tender
    |"4" -> EventType.SinkingFundCall
    |"99" -> EventType.Other
    | x -> failwith (sprintf "ReadEventType unknown fix tag: %A"  x) 


let WriteEventType (strm:Stream) (xxIn:EventType) =
    match xxIn with
    | EventType.Put -> strm.Write "865=1"B; strm.Write (delim, 0, 1)
    | EventType.Call -> strm.Write "865=2"B; strm.Write (delim, 0, 1)
    | EventType.Tender -> strm.Write "865=3"B; strm.Write (delim, 0, 1)
    | EventType.SinkingFundCall -> strm.Write "865=4"B; strm.Write (delim, 0, 1)
    | EventType.Other -> strm.Write "865=99"B; strm.Write (delim, 0, 1)


let ReadEventDate valIn =
    let tmp =  valIn
    EventDate.EventDate tmp


let WriteEventDate (strm:Stream) (valIn:EventDate) = 
    let tag = "866="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadEventPx valIn =
    let tmp = System.Decimal.Parse valIn
    EventPx.EventPx tmp


let WriteEventPx (strm:Stream) (valIn:EventPx) = 
    let tag = "867="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadEventText valIn =
    let tmp =  valIn
    EventText.EventText tmp


let WriteEventText (strm:Stream) (valIn:EventText) = 
    let tag = "868="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadPctAtRisk valIn =
    let tmp = System.Decimal.Parse valIn
    PctAtRisk.PctAtRisk tmp


let WritePctAtRisk (strm:Stream) (valIn:PctAtRisk) = 
    let tag = "869="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoInstrAttrib valIn =
    let tmp = System.Int32.Parse valIn
    NoInstrAttrib.NoInstrAttrib tmp


let WriteNoInstrAttrib (strm:Stream) (valIn:NoInstrAttrib) = 
    let tag = "870="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadInstrAttribType (fldValIn:string) : InstrAttribType = 
    match fldValIn with
    |"1" -> InstrAttribType.Flat
    |"2" -> InstrAttribType.ZeroCoupon
    |"3" -> InstrAttribType.InterestBearing
    |"4" -> InstrAttribType.NoPeriodicPayments
    |"5" -> InstrAttribType.VariableRate
    |"6" -> InstrAttribType.LessFeeForPut
    |"7" -> InstrAttribType.SteppedCoupon
    |"8" -> InstrAttribType.CouponPeriod
    |"9" -> InstrAttribType.WhenAndIfIssued
    |"10" -> InstrAttribType.OriginalIssueDiscount
    |"11" -> InstrAttribType.CallablePuttable
    |"12" -> InstrAttribType.EscrowedToMaturity
    |"13" -> InstrAttribType.EscrowedToRedemptionDate
    |"14" -> InstrAttribType.PreRefunded
    |"15" -> InstrAttribType.InDefault
    |"16" -> InstrAttribType.Unrated
    |"17" -> InstrAttribType.Taxable
    |"18" -> InstrAttribType.Indexed
    |"19" -> InstrAttribType.SubjectToAlternativeMinimumTax
    |"20" -> InstrAttribType.OriginalIssueDiscountPrice
    |"21" -> InstrAttribType.CallableBelowMaturityValue
    |"22" -> InstrAttribType.CallableWithoutNoticeByMailToHolderUnlessRegistered
    |"99" -> InstrAttribType.Text
    | x -> failwith (sprintf "ReadInstrAttribType unknown fix tag: %A"  x) 


let WriteInstrAttribType (strm:Stream) (xxIn:InstrAttribType) =
    match xxIn with
    | InstrAttribType.Flat -> strm.Write "871=1"B; strm.Write (delim, 0, 1)
    | InstrAttribType.ZeroCoupon -> strm.Write "871=2"B; strm.Write (delim, 0, 1)
    | InstrAttribType.InterestBearing -> strm.Write "871=3"B; strm.Write (delim, 0, 1)
    | InstrAttribType.NoPeriodicPayments -> strm.Write "871=4"B; strm.Write (delim, 0, 1)
    | InstrAttribType.VariableRate -> strm.Write "871=5"B; strm.Write (delim, 0, 1)
    | InstrAttribType.LessFeeForPut -> strm.Write "871=6"B; strm.Write (delim, 0, 1)
    | InstrAttribType.SteppedCoupon -> strm.Write "871=7"B; strm.Write (delim, 0, 1)
    | InstrAttribType.CouponPeriod -> strm.Write "871=8"B; strm.Write (delim, 0, 1)
    | InstrAttribType.WhenAndIfIssued -> strm.Write "871=9"B; strm.Write (delim, 0, 1)
    | InstrAttribType.OriginalIssueDiscount -> strm.Write "871=10"B; strm.Write (delim, 0, 1)
    | InstrAttribType.CallablePuttable -> strm.Write "871=11"B; strm.Write (delim, 0, 1)
    | InstrAttribType.EscrowedToMaturity -> strm.Write "871=12"B; strm.Write (delim, 0, 1)
    | InstrAttribType.EscrowedToRedemptionDate -> strm.Write "871=13"B; strm.Write (delim, 0, 1)
    | InstrAttribType.PreRefunded -> strm.Write "871=14"B; strm.Write (delim, 0, 1)
    | InstrAttribType.InDefault -> strm.Write "871=15"B; strm.Write (delim, 0, 1)
    | InstrAttribType.Unrated -> strm.Write "871=16"B; strm.Write (delim, 0, 1)
    | InstrAttribType.Taxable -> strm.Write "871=17"B; strm.Write (delim, 0, 1)
    | InstrAttribType.Indexed -> strm.Write "871=18"B; strm.Write (delim, 0, 1)
    | InstrAttribType.SubjectToAlternativeMinimumTax -> strm.Write "871=19"B; strm.Write (delim, 0, 1)
    | InstrAttribType.OriginalIssueDiscountPrice -> strm.Write "871=20"B; strm.Write (delim, 0, 1)
    | InstrAttribType.CallableBelowMaturityValue -> strm.Write "871=21"B; strm.Write (delim, 0, 1)
    | InstrAttribType.CallableWithoutNoticeByMailToHolderUnlessRegistered -> strm.Write "871=22"B; strm.Write (delim, 0, 1)
    | InstrAttribType.Text -> strm.Write "871=99"B; strm.Write (delim, 0, 1)


let ReadInstrAttribValue valIn =
    let tmp =  valIn
    InstrAttribValue.InstrAttribValue tmp


let WriteInstrAttribValue (strm:Stream) (valIn:InstrAttribValue) = 
    let tag = "872="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDatedDate valIn =
    let tmp =  valIn
    DatedDate.DatedDate tmp


let WriteDatedDate (strm:Stream) (valIn:DatedDate) = 
    let tag = "873="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadInterestAccrualDate valIn =
    let tmp =  valIn
    InterestAccrualDate.InterestAccrualDate tmp


let WriteInterestAccrualDate (strm:Stream) (valIn:InterestAccrualDate) = 
    let tag = "874="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCPProgram valIn =
    let tmp = System.Int32.Parse valIn
    CPProgram.CPProgram tmp


let WriteCPProgram (strm:Stream) (valIn:CPProgram) = 
    let tag = "875="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCPRegType valIn =
    let tmp =  valIn
    CPRegType.CPRegType tmp


let WriteCPRegType (strm:Stream) (valIn:CPRegType) = 
    let tag = "876="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingCPProgram valIn =
    let tmp =  valIn
    UnderlyingCPProgram.UnderlyingCPProgram tmp


let WriteUnderlyingCPProgram (strm:Stream) (valIn:UnderlyingCPProgram) = 
    let tag = "877="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingCPRegType valIn =
    let tmp =  valIn
    UnderlyingCPRegType.UnderlyingCPRegType tmp


let WriteUnderlyingCPRegType (strm:Stream) (valIn:UnderlyingCPRegType) = 
    let tag = "878="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingQty valIn =
    let tmp = System.Decimal.Parse valIn
    UnderlyingQty.UnderlyingQty tmp


let WriteUnderlyingQty (strm:Stream) (valIn:UnderlyingQty) = 
    let tag = "879="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTrdMatchID valIn =
    let tmp =  valIn
    TrdMatchID.TrdMatchID tmp


let WriteTrdMatchID (strm:Stream) (valIn:TrdMatchID) = 
    let tag = "880="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadSecondaryTradeReportRefID valIn =
    let tmp =  valIn
    SecondaryTradeReportRefID.SecondaryTradeReportRefID tmp


let WriteSecondaryTradeReportRefID (strm:Stream) (valIn:SecondaryTradeReportRefID) = 
    let tag = "881="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingDirtyPrice valIn =
    let tmp = System.Decimal.Parse valIn
    UnderlyingDirtyPrice.UnderlyingDirtyPrice tmp


let WriteUnderlyingDirtyPrice (strm:Stream) (valIn:UnderlyingDirtyPrice) = 
    let tag = "882="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingEndPrice valIn =
    let tmp = System.Decimal.Parse valIn
    UnderlyingEndPrice.UnderlyingEndPrice tmp


let WriteUnderlyingEndPrice (strm:Stream) (valIn:UnderlyingEndPrice) = 
    let tag = "883="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingStartValue valIn =
    let tmp = System.Int32.Parse valIn
    UnderlyingStartValue.UnderlyingStartValue tmp


let WriteUnderlyingStartValue (strm:Stream) (valIn:UnderlyingStartValue) = 
    let tag = "884="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingCurrentValue valIn =
    let tmp = System.Int32.Parse valIn
    UnderlyingCurrentValue.UnderlyingCurrentValue tmp


let WriteUnderlyingCurrentValue (strm:Stream) (valIn:UnderlyingCurrentValue) = 
    let tag = "885="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingEndValue valIn =
    let tmp = System.Int32.Parse valIn
    UnderlyingEndValue.UnderlyingEndValue tmp


let WriteUnderlyingEndValue (strm:Stream) (valIn:UnderlyingEndValue) = 
    let tag = "886="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoUnderlyingStips valIn =
    let tmp = System.Int32.Parse valIn
    NoUnderlyingStips.NoUnderlyingStips tmp


let WriteNoUnderlyingStips (strm:Stream) (valIn:NoUnderlyingStips) = 
    let tag = "887="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingStipType valIn =
    let tmp =  valIn
    UnderlyingStipType.UnderlyingStipType tmp


let WriteUnderlyingStipType (strm:Stream) (valIn:UnderlyingStipType) = 
    let tag = "888="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUnderlyingStipValue valIn =
    let tmp =  valIn
    UnderlyingStipValue.UnderlyingStipValue tmp


let WriteUnderlyingStipValue (strm:Stream) (valIn:UnderlyingStipValue) = 
    let tag = "889="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMaturityNetMoney valIn =
    let tmp = System.Int32.Parse valIn
    MaturityNetMoney.MaturityNetMoney tmp


let WriteMaturityNetMoney (strm:Stream) (valIn:MaturityNetMoney) = 
    let tag = "890="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMiscFeeBasis (fldValIn:string) : MiscFeeBasis = 
    match fldValIn with
    |"0" -> MiscFeeBasis.Absolute
    |"1" -> MiscFeeBasis.PerUnit
    |"2" -> MiscFeeBasis.Percentage
    | x -> failwith (sprintf "ReadMiscFeeBasis unknown fix tag: %A"  x) 


let WriteMiscFeeBasis (strm:Stream) (xxIn:MiscFeeBasis) =
    match xxIn with
    | MiscFeeBasis.Absolute -> strm.Write "891=0"B; strm.Write (delim, 0, 1)
    | MiscFeeBasis.PerUnit -> strm.Write "891=1"B; strm.Write (delim, 0, 1)
    | MiscFeeBasis.Percentage -> strm.Write "891=2"B; strm.Write (delim, 0, 1)


let ReadTotNoAllocs valIn =
    let tmp = System.Int32.Parse valIn
    TotNoAllocs.TotNoAllocs tmp


let WriteTotNoAllocs (strm:Stream) (valIn:TotNoAllocs) = 
    let tag = "892="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLastFragment valIn =
    let tmp = System.Boolean.Parse valIn
    LastFragment.LastFragment tmp


let WriteLastFragment (strm:Stream) (valIn:LastFragment) = 
    let tag = "893="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCollReqID valIn =
    let tmp =  valIn
    CollReqID.CollReqID tmp


let WriteCollReqID (strm:Stream) (valIn:CollReqID) = 
    let tag = "894="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCollAsgnReason (fldValIn:string) : CollAsgnReason = 
    match fldValIn with
    |"0" -> CollAsgnReason.Initial
    |"1" -> CollAsgnReason.Scheduled
    |"2" -> CollAsgnReason.TimeWarning
    |"3" -> CollAsgnReason.MarginDeficiency
    |"4" -> CollAsgnReason.MarginExcess
    |"5" -> CollAsgnReason.ForwardCollateralDemand
    |"6" -> CollAsgnReason.EventOfDefault
    |"7" -> CollAsgnReason.AdverseTaxEvent
    | x -> failwith (sprintf "ReadCollAsgnReason unknown fix tag: %A"  x) 


let WriteCollAsgnReason (strm:Stream) (xxIn:CollAsgnReason) =
    match xxIn with
    | CollAsgnReason.Initial -> strm.Write "895=0"B; strm.Write (delim, 0, 1)
    | CollAsgnReason.Scheduled -> strm.Write "895=1"B; strm.Write (delim, 0, 1)
    | CollAsgnReason.TimeWarning -> strm.Write "895=2"B; strm.Write (delim, 0, 1)
    | CollAsgnReason.MarginDeficiency -> strm.Write "895=3"B; strm.Write (delim, 0, 1)
    | CollAsgnReason.MarginExcess -> strm.Write "895=4"B; strm.Write (delim, 0, 1)
    | CollAsgnReason.ForwardCollateralDemand -> strm.Write "895=5"B; strm.Write (delim, 0, 1)
    | CollAsgnReason.EventOfDefault -> strm.Write "895=6"B; strm.Write (delim, 0, 1)
    | CollAsgnReason.AdverseTaxEvent -> strm.Write "895=7"B; strm.Write (delim, 0, 1)


let ReadCollInquiryQualifier (fldValIn:string) : CollInquiryQualifier = 
    match fldValIn with
    |"0" -> CollInquiryQualifier.Tradedate
    |"1" -> CollInquiryQualifier.GcInstrument
    |"2" -> CollInquiryQualifier.Collateralinstrument
    |"3" -> CollInquiryQualifier.SubstitutionEligible
    |"4" -> CollInquiryQualifier.NotAssigned
    |"5" -> CollInquiryQualifier.PartiallyAssigned
    |"6" -> CollInquiryQualifier.FullyAssigned
    |"7" -> CollInquiryQualifier.OutstandingTrades
    | x -> failwith (sprintf "ReadCollInquiryQualifier unknown fix tag: %A"  x) 


let WriteCollInquiryQualifier (strm:Stream) (xxIn:CollInquiryQualifier) =
    match xxIn with
    | CollInquiryQualifier.Tradedate -> strm.Write "896=0"B; strm.Write (delim, 0, 1)
    | CollInquiryQualifier.GcInstrument -> strm.Write "896=1"B; strm.Write (delim, 0, 1)
    | CollInquiryQualifier.Collateralinstrument -> strm.Write "896=2"B; strm.Write (delim, 0, 1)
    | CollInquiryQualifier.SubstitutionEligible -> strm.Write "896=3"B; strm.Write (delim, 0, 1)
    | CollInquiryQualifier.NotAssigned -> strm.Write "896=4"B; strm.Write (delim, 0, 1)
    | CollInquiryQualifier.PartiallyAssigned -> strm.Write "896=5"B; strm.Write (delim, 0, 1)
    | CollInquiryQualifier.FullyAssigned -> strm.Write "896=6"B; strm.Write (delim, 0, 1)
    | CollInquiryQualifier.OutstandingTrades -> strm.Write "896=7"B; strm.Write (delim, 0, 1)


let ReadNoTrades valIn =
    let tmp = System.Int32.Parse valIn
    NoTrades.NoTrades tmp


let WriteNoTrades (strm:Stream) (valIn:NoTrades) = 
    let tag = "897="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMarginRatio valIn =
    let tmp = System.Decimal.Parse valIn
    MarginRatio.MarginRatio tmp


let WriteMarginRatio (strm:Stream) (valIn:MarginRatio) = 
    let tag = "898="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadMarginExcess valIn =
    let tmp = System.Int32.Parse valIn
    MarginExcess.MarginExcess tmp


let WriteMarginExcess (strm:Stream) (valIn:MarginExcess) = 
    let tag = "899="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTotalNetValue valIn =
    let tmp = System.Int32.Parse valIn
    TotalNetValue.TotalNetValue tmp


let WriteTotalNetValue (strm:Stream) (valIn:TotalNetValue) = 
    let tag = "900="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCashOutstanding valIn =
    let tmp = System.Int32.Parse valIn
    CashOutstanding.CashOutstanding tmp


let WriteCashOutstanding (strm:Stream) (valIn:CashOutstanding) = 
    let tag = "901="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCollAsgnID valIn =
    let tmp =  valIn
    CollAsgnID.CollAsgnID tmp


let WriteCollAsgnID (strm:Stream) (valIn:CollAsgnID) = 
    let tag = "902="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCollAsgnTransType (fldValIn:string) : CollAsgnTransType = 
    match fldValIn with
    |"0" -> CollAsgnTransType.New
    |"1" -> CollAsgnTransType.Replace
    |"2" -> CollAsgnTransType.Cancel
    |"3" -> CollAsgnTransType.Release
    |"4" -> CollAsgnTransType.Reverse
    | x -> failwith (sprintf "ReadCollAsgnTransType unknown fix tag: %A"  x) 


let WriteCollAsgnTransType (strm:Stream) (xxIn:CollAsgnTransType) =
    match xxIn with
    | CollAsgnTransType.New -> strm.Write "903=0"B; strm.Write (delim, 0, 1)
    | CollAsgnTransType.Replace -> strm.Write "903=1"B; strm.Write (delim, 0, 1)
    | CollAsgnTransType.Cancel -> strm.Write "903=2"B; strm.Write (delim, 0, 1)
    | CollAsgnTransType.Release -> strm.Write "903=3"B; strm.Write (delim, 0, 1)
    | CollAsgnTransType.Reverse -> strm.Write "903=4"B; strm.Write (delim, 0, 1)


let ReadCollRespID valIn =
    let tmp =  valIn
    CollRespID.CollRespID tmp


let WriteCollRespID (strm:Stream) (valIn:CollRespID) = 
    let tag = "904="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCollAsgnRespType (fldValIn:string) : CollAsgnRespType = 
    match fldValIn with
    |"0" -> CollAsgnRespType.Received
    |"1" -> CollAsgnRespType.Accepted
    |"2" -> CollAsgnRespType.Declined
    |"3" -> CollAsgnRespType.Rejected
    | x -> failwith (sprintf "ReadCollAsgnRespType unknown fix tag: %A"  x) 


let WriteCollAsgnRespType (strm:Stream) (xxIn:CollAsgnRespType) =
    match xxIn with
    | CollAsgnRespType.Received -> strm.Write "905=0"B; strm.Write (delim, 0, 1)
    | CollAsgnRespType.Accepted -> strm.Write "905=1"B; strm.Write (delim, 0, 1)
    | CollAsgnRespType.Declined -> strm.Write "905=2"B; strm.Write (delim, 0, 1)
    | CollAsgnRespType.Rejected -> strm.Write "905=3"B; strm.Write (delim, 0, 1)


let ReadCollAsgnRejectReason (fldValIn:string) : CollAsgnRejectReason = 
    match fldValIn with
    |"0" -> CollAsgnRejectReason.UnknownDeal
    |"1" -> CollAsgnRejectReason.UnknownOrInvalidInstrument
    |"2" -> CollAsgnRejectReason.UnauthorizedTransaction
    |"3" -> CollAsgnRejectReason.InsufficientCollateral
    |"4" -> CollAsgnRejectReason.InvalidTypeOfCollateral
    |"5" -> CollAsgnRejectReason.ExcessiveSubstitution
    |"99" -> CollAsgnRejectReason.Other
    | x -> failwith (sprintf "ReadCollAsgnRejectReason unknown fix tag: %A"  x) 


let WriteCollAsgnRejectReason (strm:Stream) (xxIn:CollAsgnRejectReason) =
    match xxIn with
    | CollAsgnRejectReason.UnknownDeal -> strm.Write "906=0"B; strm.Write (delim, 0, 1)
    | CollAsgnRejectReason.UnknownOrInvalidInstrument -> strm.Write "906=1"B; strm.Write (delim, 0, 1)
    | CollAsgnRejectReason.UnauthorizedTransaction -> strm.Write "906=2"B; strm.Write (delim, 0, 1)
    | CollAsgnRejectReason.InsufficientCollateral -> strm.Write "906=3"B; strm.Write (delim, 0, 1)
    | CollAsgnRejectReason.InvalidTypeOfCollateral -> strm.Write "906=4"B; strm.Write (delim, 0, 1)
    | CollAsgnRejectReason.ExcessiveSubstitution -> strm.Write "906=5"B; strm.Write (delim, 0, 1)
    | CollAsgnRejectReason.Other -> strm.Write "906=99"B; strm.Write (delim, 0, 1)


let ReadCollAsgnRefID valIn =
    let tmp =  valIn
    CollAsgnRefID.CollAsgnRefID tmp


let WriteCollAsgnRefID (strm:Stream) (valIn:CollAsgnRefID) = 
    let tag = "907="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCollRptID valIn =
    let tmp =  valIn
    CollRptID.CollRptID tmp


let WriteCollRptID (strm:Stream) (valIn:CollRptID) = 
    let tag = "908="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCollInquiryID valIn =
    let tmp =  valIn
    CollInquiryID.CollInquiryID tmp


let WriteCollInquiryID (strm:Stream) (valIn:CollInquiryID) = 
    let tag = "909="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCollStatus (fldValIn:string) : CollStatus = 
    match fldValIn with
    |"0" -> CollStatus.Unassigned
    |"1" -> CollStatus.PartiallyAssigned
    |"2" -> CollStatus.AssignmentProposed
    |"3" -> CollStatus.Assigned
    |"4" -> CollStatus.Challenged
    | x -> failwith (sprintf "ReadCollStatus unknown fix tag: %A"  x) 


let WriteCollStatus (strm:Stream) (xxIn:CollStatus) =
    match xxIn with
    | CollStatus.Unassigned -> strm.Write "910=0"B; strm.Write (delim, 0, 1)
    | CollStatus.PartiallyAssigned -> strm.Write "910=1"B; strm.Write (delim, 0, 1)
    | CollStatus.AssignmentProposed -> strm.Write "910=2"B; strm.Write (delim, 0, 1)
    | CollStatus.Assigned -> strm.Write "910=3"B; strm.Write (delim, 0, 1)
    | CollStatus.Challenged -> strm.Write "910=4"B; strm.Write (delim, 0, 1)


let ReadTotNumReports valIn =
    let tmp = System.Int32.Parse valIn
    TotNumReports.TotNumReports tmp


let WriteTotNumReports (strm:Stream) (valIn:TotNumReports) = 
    let tag = "911="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLastRptRequested valIn =
    let tmp = System.Boolean.Parse valIn
    LastRptRequested.LastRptRequested tmp


let WriteLastRptRequested (strm:Stream) (valIn:LastRptRequested) = 
    let tag = "912="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAgreementDesc valIn =
    let tmp =  valIn
    AgreementDesc.AgreementDesc tmp


let WriteAgreementDesc (strm:Stream) (valIn:AgreementDesc) = 
    let tag = "913="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAgreementID valIn =
    let tmp =  valIn
    AgreementID.AgreementID tmp


let WriteAgreementID (strm:Stream) (valIn:AgreementID) = 
    let tag = "914="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAgreementDate valIn =
    let tmp =  valIn
    AgreementDate.AgreementDate tmp


let WriteAgreementDate (strm:Stream) (valIn:AgreementDate) = 
    let tag = "915="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadStartDate valIn =
    let tmp =  valIn
    StartDate.StartDate tmp


let WriteStartDate (strm:Stream) (valIn:StartDate) = 
    let tag = "916="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadEndDate valIn =
    let tmp =  valIn
    EndDate.EndDate tmp


let WriteEndDate (strm:Stream) (valIn:EndDate) = 
    let tag = "917="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadAgreementCurrency valIn =
    let tmp =  valIn
    AgreementCurrency.AgreementCurrency tmp


let WriteAgreementCurrency (strm:Stream) (valIn:AgreementCurrency) = 
    let tag = "918="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadDeliveryType (fldValIn:string) : DeliveryType = 
    match fldValIn with
    |"0" -> DeliveryType.VersusPayment
    |"1" -> DeliveryType.Free
    |"2" -> DeliveryType.TriParty
    |"3" -> DeliveryType.HoldInCustody
    | x -> failwith (sprintf "ReadDeliveryType unknown fix tag: %A"  x) 


let WriteDeliveryType (strm:Stream) (xxIn:DeliveryType) =
    match xxIn with
    | DeliveryType.VersusPayment -> strm.Write "919=0"B; strm.Write (delim, 0, 1)
    | DeliveryType.Free -> strm.Write "919=1"B; strm.Write (delim, 0, 1)
    | DeliveryType.TriParty -> strm.Write "919=2"B; strm.Write (delim, 0, 1)
    | DeliveryType.HoldInCustody -> strm.Write "919=3"B; strm.Write (delim, 0, 1)


let ReadEndAccruedInterestAmt valIn =
    let tmp = System.Int32.Parse valIn
    EndAccruedInterestAmt.EndAccruedInterestAmt tmp


let WriteEndAccruedInterestAmt (strm:Stream) (valIn:EndAccruedInterestAmt) = 
    let tag = "920="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadStartCash valIn =
    let tmp = System.Int32.Parse valIn
    StartCash.StartCash tmp


let WriteStartCash (strm:Stream) (valIn:StartCash) = 
    let tag = "921="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadEndCash valIn =
    let tmp = System.Int32.Parse valIn
    EndCash.EndCash tmp


let WriteEndCash (strm:Stream) (valIn:EndCash) = 
    let tag = "922="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUserRequestID valIn =
    let tmp =  valIn
    UserRequestID.UserRequestID tmp


let WriteUserRequestID (strm:Stream) (valIn:UserRequestID) = 
    let tag = "923="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUserRequestType (fldValIn:string) : UserRequestType = 
    match fldValIn with
    |"1" -> UserRequestType.Logonuser
    |"2" -> UserRequestType.Logoffuser
    |"3" -> UserRequestType.Changepasswordforuser
    |"4" -> UserRequestType.RequestIndividualUserStatus
    | x -> failwith (sprintf "ReadUserRequestType unknown fix tag: %A"  x) 


let WriteUserRequestType (strm:Stream) (xxIn:UserRequestType) =
    match xxIn with
    | UserRequestType.Logonuser -> strm.Write "924=1"B; strm.Write (delim, 0, 1)
    | UserRequestType.Logoffuser -> strm.Write "924=2"B; strm.Write (delim, 0, 1)
    | UserRequestType.Changepasswordforuser -> strm.Write "924=3"B; strm.Write (delim, 0, 1)
    | UserRequestType.RequestIndividualUserStatus -> strm.Write "924=4"B; strm.Write (delim, 0, 1)


let ReadNewPassword valIn =
    let tmp =  valIn
    NewPassword.NewPassword tmp


let WriteNewPassword (strm:Stream) (valIn:NewPassword) = 
    let tag = "925="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadUserStatus (fldValIn:string) : UserStatus = 
    match fldValIn with
    |"1" -> UserStatus.LoggedIn
    |"2" -> UserStatus.NotLoggedIn
    |"3" -> UserStatus.UserNotRecognised
    |"4" -> UserStatus.PasswordIncorrect
    |"5" -> UserStatus.PasswordChanged
    |"6" -> UserStatus.Other
    | x -> failwith (sprintf "ReadUserStatus unknown fix tag: %A"  x) 


let WriteUserStatus (strm:Stream) (xxIn:UserStatus) =
    match xxIn with
    | UserStatus.LoggedIn -> strm.Write "926=1"B; strm.Write (delim, 0, 1)
    | UserStatus.NotLoggedIn -> strm.Write "926=2"B; strm.Write (delim, 0, 1)
    | UserStatus.UserNotRecognised -> strm.Write "926=3"B; strm.Write (delim, 0, 1)
    | UserStatus.PasswordIncorrect -> strm.Write "926=4"B; strm.Write (delim, 0, 1)
    | UserStatus.PasswordChanged -> strm.Write "926=5"B; strm.Write (delim, 0, 1)
    | UserStatus.Other -> strm.Write "926=6"B; strm.Write (delim, 0, 1)


let ReadUserStatusText valIn =
    let tmp =  valIn
    UserStatusText.UserStatusText tmp


let WriteUserStatusText (strm:Stream) (valIn:UserStatusText) = 
    let tag = "927="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadStatusValue (fldValIn:string) : StatusValue = 
    match fldValIn with
    |"1" -> StatusValue.Connected
    |"2" -> StatusValue.NotConnectedDownExpectedUp
    |"3" -> StatusValue.NotConnectedDownExpectedDown
    |"4" -> StatusValue.InProcess
    | x -> failwith (sprintf "ReadStatusValue unknown fix tag: %A"  x) 


let WriteStatusValue (strm:Stream) (xxIn:StatusValue) =
    match xxIn with
    | StatusValue.Connected -> strm.Write "928=1"B; strm.Write (delim, 0, 1)
    | StatusValue.NotConnectedDownExpectedUp -> strm.Write "928=2"B; strm.Write (delim, 0, 1)
    | StatusValue.NotConnectedDownExpectedDown -> strm.Write "928=3"B; strm.Write (delim, 0, 1)
    | StatusValue.InProcess -> strm.Write "928=4"B; strm.Write (delim, 0, 1)


let ReadStatusText valIn =
    let tmp =  valIn
    StatusText.StatusText tmp


let WriteStatusText (strm:Stream) (valIn:StatusText) = 
    let tag = "929="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRefCompID valIn =
    let tmp =  valIn
    RefCompID.RefCompID tmp


let WriteRefCompID (strm:Stream) (valIn:RefCompID) = 
    let tag = "930="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadRefSubID valIn =
    let tmp =  valIn
    RefSubID.RefSubID tmp


let WriteRefSubID (strm:Stream) (valIn:RefSubID) = 
    let tag = "931="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNetworkResponseID valIn =
    let tmp =  valIn
    NetworkResponseID.NetworkResponseID tmp


let WriteNetworkResponseID (strm:Stream) (valIn:NetworkResponseID) = 
    let tag = "932="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNetworkRequestID valIn =
    let tmp =  valIn
    NetworkRequestID.NetworkRequestID tmp


let WriteNetworkRequestID (strm:Stream) (valIn:NetworkRequestID) = 
    let tag = "933="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLastNetworkResponseID valIn =
    let tmp =  valIn
    LastNetworkResponseID.LastNetworkResponseID tmp


let WriteLastNetworkResponseID (strm:Stream) (valIn:LastNetworkResponseID) = 
    let tag = "934="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNetworkRequestType (fldValIn:string) : NetworkRequestType = 
    match fldValIn with
    |"1" -> NetworkRequestType.Snapshot
    |"2" -> NetworkRequestType.Subscribe
    |"4" -> NetworkRequestType.StopSubscribing
    |"8" -> NetworkRequestType.LevelOfDetail
    | x -> failwith (sprintf "ReadNetworkRequestType unknown fix tag: %A"  x) 


let WriteNetworkRequestType (strm:Stream) (xxIn:NetworkRequestType) =
    match xxIn with
    | NetworkRequestType.Snapshot -> strm.Write "935=1"B; strm.Write (delim, 0, 1)
    | NetworkRequestType.Subscribe -> strm.Write "935=2"B; strm.Write (delim, 0, 1)
    | NetworkRequestType.StopSubscribing -> strm.Write "935=4"B; strm.Write (delim, 0, 1)
    | NetworkRequestType.LevelOfDetail -> strm.Write "935=8"B; strm.Write (delim, 0, 1)


let ReadNoCompIDs valIn =
    let tmp = System.Int32.Parse valIn
    NoCompIDs.NoCompIDs tmp


let WriteNoCompIDs (strm:Stream) (valIn:NoCompIDs) = 
    let tag = "936="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNetworkStatusResponseType (fldValIn:string) : NetworkStatusResponseType = 
    match fldValIn with
    |"1" -> NetworkStatusResponseType.Full
    |"2" -> NetworkStatusResponseType.IncrementalUpdate
    | x -> failwith (sprintf "ReadNetworkStatusResponseType unknown fix tag: %A"  x) 


let WriteNetworkStatusResponseType (strm:Stream) (xxIn:NetworkStatusResponseType) =
    match xxIn with
    | NetworkStatusResponseType.Full -> strm.Write "937=1"B; strm.Write (delim, 0, 1)
    | NetworkStatusResponseType.IncrementalUpdate -> strm.Write "937=2"B; strm.Write (delim, 0, 1)


let ReadNoCollInquiryQualifier valIn =
    let tmp = System.Int32.Parse valIn
    NoCollInquiryQualifier.NoCollInquiryQualifier tmp


let WriteNoCollInquiryQualifier (strm:Stream) (valIn:NoCollInquiryQualifier) = 
    let tag = "938="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTrdRptStatus (fldValIn:string) : TrdRptStatus = 
    match fldValIn with
    |"0" -> TrdRptStatus.Accepted
    |"1" -> TrdRptStatus.Rejected
    | x -> failwith (sprintf "ReadTrdRptStatus unknown fix tag: %A"  x) 


let WriteTrdRptStatus (strm:Stream) (xxIn:TrdRptStatus) =
    match xxIn with
    | TrdRptStatus.Accepted -> strm.Write "939=0"B; strm.Write (delim, 0, 1)
    | TrdRptStatus.Rejected -> strm.Write "939=1"B; strm.Write (delim, 0, 1)


let ReadAffirmStatus (fldValIn:string) : AffirmStatus = 
    match fldValIn with
    |"1" -> AffirmStatus.Received
    |"2" -> AffirmStatus.ConfirmRejected
    |"3" -> AffirmStatus.Affirmed
    | x -> failwith (sprintf "ReadAffirmStatus unknown fix tag: %A"  x) 


let WriteAffirmStatus (strm:Stream) (xxIn:AffirmStatus) =
    match xxIn with
    | AffirmStatus.Received -> strm.Write "940=1"B; strm.Write (delim, 0, 1)
    | AffirmStatus.ConfirmRejected -> strm.Write "940=2"B; strm.Write (delim, 0, 1)
    | AffirmStatus.Affirmed -> strm.Write "940=3"B; strm.Write (delim, 0, 1)


let ReadUnderlyingStrikeCurrency valIn =
    let tmp =  valIn
    UnderlyingStrikeCurrency.UnderlyingStrikeCurrency tmp


let WriteUnderlyingStrikeCurrency (strm:Stream) (valIn:UnderlyingStrikeCurrency) = 
    let tag = "941="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegStrikeCurrency valIn =
    let tmp =  valIn
    LegStrikeCurrency.LegStrikeCurrency tmp


let WriteLegStrikeCurrency (strm:Stream) (valIn:LegStrikeCurrency) = 
    let tag = "942="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadTimeBracket valIn =
    let tmp =  valIn
    TimeBracket.TimeBracket tmp


let WriteTimeBracket (strm:Stream) (valIn:TimeBracket) = 
    let tag = "943="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadCollAction (fldValIn:string) : CollAction = 
    match fldValIn with
    |"0" -> CollAction.Retain
    |"1" -> CollAction.Add
    |"2" -> CollAction.Remove
    | x -> failwith (sprintf "ReadCollAction unknown fix tag: %A"  x) 


let WriteCollAction (strm:Stream) (xxIn:CollAction) =
    match xxIn with
    | CollAction.Retain -> strm.Write "944=0"B; strm.Write (delim, 0, 1)
    | CollAction.Add -> strm.Write "944=1"B; strm.Write (delim, 0, 1)
    | CollAction.Remove -> strm.Write "944=2"B; strm.Write (delim, 0, 1)


let ReadCollInquiryStatus (fldValIn:string) : CollInquiryStatus = 
    match fldValIn with
    |"0" -> CollInquiryStatus.Accepted
    |"1" -> CollInquiryStatus.AcceptedWithWarnings
    |"2" -> CollInquiryStatus.Completed
    |"3" -> CollInquiryStatus.CompletedWithWarnings
    |"4" -> CollInquiryStatus.Rejected
    | x -> failwith (sprintf "ReadCollInquiryStatus unknown fix tag: %A"  x) 


let WriteCollInquiryStatus (strm:Stream) (xxIn:CollInquiryStatus) =
    match xxIn with
    | CollInquiryStatus.Accepted -> strm.Write "945=0"B; strm.Write (delim, 0, 1)
    | CollInquiryStatus.AcceptedWithWarnings -> strm.Write "945=1"B; strm.Write (delim, 0, 1)
    | CollInquiryStatus.Completed -> strm.Write "945=2"B; strm.Write (delim, 0, 1)
    | CollInquiryStatus.CompletedWithWarnings -> strm.Write "945=3"B; strm.Write (delim, 0, 1)
    | CollInquiryStatus.Rejected -> strm.Write "945=4"B; strm.Write (delim, 0, 1)


let ReadCollInquiryResult (fldValIn:string) : CollInquiryResult = 
    match fldValIn with
    |"0" -> CollInquiryResult.Successful
    |"1" -> CollInquiryResult.InvalidOrUnknownInstrument
    |"2" -> CollInquiryResult.InvalidOrUnknownCollateralType
    |"3" -> CollInquiryResult.InvalidParties
    |"4" -> CollInquiryResult.InvalidTransportTypeRequested
    |"5" -> CollInquiryResult.InvalidDestinationRequested
    |"6" -> CollInquiryResult.NoCollateralFoundForTheTradeSpecified
    |"7" -> CollInquiryResult.NoCollateralFoundForTheOrderSpecified
    |"8" -> CollInquiryResult.CollateralInquiryTypeNotSupported
    |"9" -> CollInquiryResult.UnauthorizedForCollateralInquiry
    |"99" -> CollInquiryResult.Other
    | x -> failwith (sprintf "ReadCollInquiryResult unknown fix tag: %A"  x) 


let WriteCollInquiryResult (strm:Stream) (xxIn:CollInquiryResult) =
    match xxIn with
    | CollInquiryResult.Successful -> strm.Write "946=0"B; strm.Write (delim, 0, 1)
    | CollInquiryResult.InvalidOrUnknownInstrument -> strm.Write "946=1"B; strm.Write (delim, 0, 1)
    | CollInquiryResult.InvalidOrUnknownCollateralType -> strm.Write "946=2"B; strm.Write (delim, 0, 1)
    | CollInquiryResult.InvalidParties -> strm.Write "946=3"B; strm.Write (delim, 0, 1)
    | CollInquiryResult.InvalidTransportTypeRequested -> strm.Write "946=4"B; strm.Write (delim, 0, 1)
    | CollInquiryResult.InvalidDestinationRequested -> strm.Write "946=5"B; strm.Write (delim, 0, 1)
    | CollInquiryResult.NoCollateralFoundForTheTradeSpecified -> strm.Write "946=6"B; strm.Write (delim, 0, 1)
    | CollInquiryResult.NoCollateralFoundForTheOrderSpecified -> strm.Write "946=7"B; strm.Write (delim, 0, 1)
    | CollInquiryResult.CollateralInquiryTypeNotSupported -> strm.Write "946=8"B; strm.Write (delim, 0, 1)
    | CollInquiryResult.UnauthorizedForCollateralInquiry -> strm.Write "946=9"B; strm.Write (delim, 0, 1)
    | CollInquiryResult.Other -> strm.Write "946=99"B; strm.Write (delim, 0, 1)


let ReadStrikeCurrency valIn =
    let tmp =  valIn
    StrikeCurrency.StrikeCurrency tmp


let WriteStrikeCurrency (strm:Stream) (valIn:StrikeCurrency) = 
    let tag = "947="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoNested3PartyIDs valIn =
    let tmp = System.Int32.Parse valIn
    NoNested3PartyIDs.NoNested3PartyIDs tmp


let WriteNoNested3PartyIDs (strm:Stream) (valIn:NoNested3PartyIDs) = 
    let tag = "948="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNested3PartyID valIn =
    let tmp =  valIn
    Nested3PartyID.Nested3PartyID tmp


let WriteNested3PartyID (strm:Stream) (valIn:Nested3PartyID) = 
    let tag = "949="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNested3PartyIDSource valIn =
    let tmp = System.Int32.Parse valIn
    Nested3PartyIDSource.Nested3PartyIDSource tmp


let WriteNested3PartyIDSource (strm:Stream) (valIn:Nested3PartyIDSource) = 
    let tag = "950="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNested3PartyRole valIn =
    let tmp = System.Int32.Parse valIn
    Nested3PartyRole.Nested3PartyRole tmp


let WriteNested3PartyRole (strm:Stream) (valIn:Nested3PartyRole) = 
    let tag = "951="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNoNested3PartySubIDs valIn =
    let tmp = System.Int32.Parse valIn
    NoNested3PartySubIDs.NoNested3PartySubIDs tmp


let WriteNoNested3PartySubIDs (strm:Stream) (valIn:NoNested3PartySubIDs) = 
    let tag = "952="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNested3PartySubID valIn =
    let tmp =  valIn
    Nested3PartySubID.Nested3PartySubID tmp


let WriteNested3PartySubID (strm:Stream) (valIn:Nested3PartySubID) = 
    let tag = "953="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadNested3PartySubIDType valIn =
    let tmp = System.Int32.Parse valIn
    Nested3PartySubIDType.Nested3PartySubIDType tmp


let WriteNested3PartySubIDType (strm:Stream) (valIn:Nested3PartySubIDType) = 
    let tag = "954="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegContractSettlMonth valIn =
    let tmp =  valIn
    LegContractSettlMonth.LegContractSettlMonth tmp


let WriteLegContractSettlMonth (strm:Stream) (valIn:LegContractSettlMonth) = 
    let tag = "955="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)


let ReadLegInterestAccrualDate valIn =
    let tmp =  valIn
    LegInterestAccrualDate.LegInterestAccrualDate tmp


let WriteLegInterestAccrualDate (strm:Stream) (valIn:LegInterestAccrualDate) = 
    let tag = "956="B
    strm.Write tag
    let bs = ToBytes.Convert(valIn.Value)
    strm.Write bs
    strm.Write (delim, 0, 1)




let WriteField strm fixField =
    match fixField with
    | Account fixField -> WriteAccount strm fixField
    | AdvId fixField -> WriteAdvId strm fixField
    | AdvRefID fixField -> WriteAdvRefID strm fixField
    | AdvSide fixField -> WriteAdvSide strm fixField
    | AdvTransType fixField -> WriteAdvTransType strm fixField
    | AvgPx fixField -> WriteAvgPx strm fixField
    | BeginSeqNo fixField -> WriteBeginSeqNo strm fixField
    | BeginString fixField -> WriteBeginString strm fixField
    | BodyLength fixField -> WriteBodyLength strm fixField
    | CheckSum fixField -> WriteCheckSum strm fixField
    | ClOrdID fixField -> WriteClOrdID strm fixField
    | Commission fixField -> WriteCommission strm fixField
    | CommType fixField -> WriteCommType strm fixField
    | CumQty fixField -> WriteCumQty strm fixField
    | Currency fixField -> WriteCurrency strm fixField
    | EndSeqNo fixField -> WriteEndSeqNo strm fixField
    | ExecID fixField -> WriteExecID strm fixField
    | ExecInst fixField -> WriteExecInst strm fixField
    | ExecRefID fixField -> WriteExecRefID strm fixField
    | HandlInst fixField -> WriteHandlInst strm fixField
    | SecurityIDSource fixField -> WriteSecurityIDSource strm fixField
    | IOIid fixField -> WriteIOIid strm fixField
    | IOIQltyInd fixField -> WriteIOIQltyInd strm fixField
    | IOIRefID fixField -> WriteIOIRefID strm fixField
    | IOIQty fixField -> WriteIOIQty strm fixField
    | IOITransType fixField -> WriteIOITransType strm fixField
    | LastCapacity fixField -> WriteLastCapacity strm fixField
    | LastMkt fixField -> WriteLastMkt strm fixField
    | LastPx fixField -> WriteLastPx strm fixField
    | LastQty fixField -> WriteLastQty strm fixField
    | LinesOfText fixField -> WriteLinesOfText strm fixField
    | MsgSeqNum fixField -> WriteMsgSeqNum strm fixField
    | MsgType fixField -> WriteMsgType strm fixField
    | NewSeqNo fixField -> WriteNewSeqNo strm fixField
    | OrderID fixField -> WriteOrderID strm fixField
    | OrderQty fixField -> WriteOrderQty strm fixField
    | OrdStatus fixField -> WriteOrdStatus strm fixField
    | OrdType fixField -> WriteOrdType strm fixField
    | OrigClOrdID fixField -> WriteOrigClOrdID strm fixField
    | OrigTime fixField -> WriteOrigTime strm fixField
    | PossDupFlag fixField -> WritePossDupFlag strm fixField
    | Price fixField -> WritePrice strm fixField
    | RefSeqNum fixField -> WriteRefSeqNum strm fixField
    | SecurityID fixField -> WriteSecurityID strm fixField
    | SenderCompID fixField -> WriteSenderCompID strm fixField
    | SenderSubID fixField -> WriteSenderSubID strm fixField
    | SendingTime fixField -> WriteSendingTime strm fixField
    | Quantity fixField -> WriteQuantity strm fixField
    | Side fixField -> WriteSide strm fixField
    | Symbol fixField -> WriteSymbol strm fixField
    | TargetCompID fixField -> WriteTargetCompID strm fixField
    | TargetSubID fixField -> WriteTargetSubID strm fixField
    | Text fixField -> WriteText strm fixField
    | TimeInForce fixField -> WriteTimeInForce strm fixField
    | TransactTime fixField -> WriteTransactTime strm fixField
    | Urgency fixField -> WriteUrgency strm fixField
    | ValidUntilTime fixField -> WriteValidUntilTime strm fixField
    | SettlType fixField -> WriteSettlType strm fixField
    | SettlDate fixField -> WriteSettlDate strm fixField
    | SymbolSfx fixField -> WriteSymbolSfx strm fixField
    | ListID fixField -> WriteListID strm fixField
    | ListSeqNo fixField -> WriteListSeqNo strm fixField
    | TotNoOrders fixField -> WriteTotNoOrders strm fixField
    | ListExecInst fixField -> WriteListExecInst strm fixField
    | AllocID fixField -> WriteAllocID strm fixField
    | AllocTransType fixField -> WriteAllocTransType strm fixField
    | RefAllocID fixField -> WriteRefAllocID strm fixField
    | NoOrders fixField -> WriteNoOrders strm fixField
    | AvgPxPrecision fixField -> WriteAvgPxPrecision strm fixField
    | TradeDate fixField -> WriteTradeDate strm fixField
    | PositionEffect fixField -> WritePositionEffect strm fixField
    | NoAllocs fixField -> WriteNoAllocs strm fixField
    | AllocAccount fixField -> WriteAllocAccount strm fixField
    | AllocQty fixField -> WriteAllocQty strm fixField
    | ProcessCode fixField -> WriteProcessCode strm fixField
    | NoRpts fixField -> WriteNoRpts strm fixField
    | RptSeq fixField -> WriteRptSeq strm fixField
    | CxlQty fixField -> WriteCxlQty strm fixField
    | NoDlvyInst fixField -> WriteNoDlvyInst strm fixField
    | AllocStatus fixField -> WriteAllocStatus strm fixField
    | AllocRejCode fixField -> WriteAllocRejCode strm fixField
    | Signature fixField -> WriteSignature strm fixField
    | SecureData fixField -> WriteSecureData strm fixField // compound field
    | SignatureLength fixField -> WriteSignatureLength strm fixField
    | EmailType fixField -> WriteEmailType strm fixField
    | RawDataLength fixField -> WriteRawDataLength strm fixField
    | RawData fixField -> WriteRawData strm fixField
    | PossResend fixField -> WritePossResend strm fixField
    | EncryptMethod fixField -> WriteEncryptMethod strm fixField
    | StopPx fixField -> WriteStopPx strm fixField
    | ExDestination fixField -> WriteExDestination strm fixField
    | CxlRejReason fixField -> WriteCxlRejReason strm fixField
    | OrdRejReason fixField -> WriteOrdRejReason strm fixField
    | IOIQualifier fixField -> WriteIOIQualifier strm fixField
    | WaveNo fixField -> WriteWaveNo strm fixField
    | Issuer fixField -> WriteIssuer strm fixField
    | SecurityDesc fixField -> WriteSecurityDesc strm fixField
    | HeartBtInt fixField -> WriteHeartBtInt strm fixField
    | MinQty fixField -> WriteMinQty strm fixField
    | MaxFloor fixField -> WriteMaxFloor strm fixField
    | TestReqID fixField -> WriteTestReqID strm fixField
    | ReportToExch fixField -> WriteReportToExch strm fixField
    | LocateReqd fixField -> WriteLocateReqd strm fixField
    | OnBehalfOfCompID fixField -> WriteOnBehalfOfCompID strm fixField
    | OnBehalfOfSubID fixField -> WriteOnBehalfOfSubID strm fixField
    | QuoteID fixField -> WriteQuoteID strm fixField
    | NetMoney fixField -> WriteNetMoney strm fixField
    | SettlCurrAmt fixField -> WriteSettlCurrAmt strm fixField
    | SettlCurrency fixField -> WriteSettlCurrency strm fixField
    | ForexReq fixField -> WriteForexReq strm fixField
    | OrigSendingTime fixField -> WriteOrigSendingTime strm fixField
    | GapFillFlag fixField -> WriteGapFillFlag strm fixField
    | NoExecs fixField -> WriteNoExecs strm fixField
    | ExpireTime fixField -> WriteExpireTime strm fixField
    | DKReason fixField -> WriteDKReason strm fixField
    | DeliverToCompID fixField -> WriteDeliverToCompID strm fixField
    | DeliverToSubID fixField -> WriteDeliverToSubID strm fixField
    | IOINaturalFlag fixField -> WriteIOINaturalFlag strm fixField
    | QuoteReqID fixField -> WriteQuoteReqID strm fixField
    | BidPx fixField -> WriteBidPx strm fixField
    | OfferPx fixField -> WriteOfferPx strm fixField
    | BidSize fixField -> WriteBidSize strm fixField
    | OfferSize fixField -> WriteOfferSize strm fixField
    | NoMiscFees fixField -> WriteNoMiscFees strm fixField
    | MiscFeeAmt fixField -> WriteMiscFeeAmt strm fixField
    | MiscFeeCurr fixField -> WriteMiscFeeCurr strm fixField
    | MiscFeeType fixField -> WriteMiscFeeType strm fixField
    | PrevClosePx fixField -> WritePrevClosePx strm fixField
    | ResetSeqNumFlag fixField -> WriteResetSeqNumFlag strm fixField
    | SenderLocationID fixField -> WriteSenderLocationID strm fixField
    | TargetLocationID fixField -> WriteTargetLocationID strm fixField
    | OnBehalfOfLocationID fixField -> WriteOnBehalfOfLocationID strm fixField
    | DeliverToLocationID fixField -> WriteDeliverToLocationID strm fixField
    | NoRelatedSym fixField -> WriteNoRelatedSym strm fixField
    | Subject fixField -> WriteSubject strm fixField
    | Headline fixField -> WriteHeadline strm fixField
    | URLLink fixField -> WriteURLLink strm fixField
    | ExecType fixField -> WriteExecType strm fixField
    | LeavesQty fixField -> WriteLeavesQty strm fixField
    | CashOrderQty fixField -> WriteCashOrderQty strm fixField
    | AllocAvgPx fixField -> WriteAllocAvgPx strm fixField
    | AllocNetMoney fixField -> WriteAllocNetMoney strm fixField
    | SettlCurrFxRate fixField -> WriteSettlCurrFxRate strm fixField
    | SettlCurrFxRateCalc fixField -> WriteSettlCurrFxRateCalc strm fixField
    | NumDaysInterest fixField -> WriteNumDaysInterest strm fixField
    | AccruedInterestRate fixField -> WriteAccruedInterestRate strm fixField
    | AccruedInterestAmt fixField -> WriteAccruedInterestAmt strm fixField
    | SettlInstMode fixField -> WriteSettlInstMode strm fixField
    | AllocText fixField -> WriteAllocText strm fixField
    | SettlInstID fixField -> WriteSettlInstID strm fixField
    | SettlInstTransType fixField -> WriteSettlInstTransType strm fixField
    | EmailThreadID fixField -> WriteEmailThreadID strm fixField
    | SettlInstSource fixField -> WriteSettlInstSource strm fixField
    | SecurityType fixField -> WriteSecurityType strm fixField
    | EffectiveTime fixField -> WriteEffectiveTime strm fixField
    | StandInstDbType fixField -> WriteStandInstDbType strm fixField
    | StandInstDbName fixField -> WriteStandInstDbName strm fixField
    | StandInstDbID fixField -> WriteStandInstDbID strm fixField
    | SettlDeliveryType fixField -> WriteSettlDeliveryType strm fixField
    | BidSpotRate fixField -> WriteBidSpotRate strm fixField
    | BidForwardPoints fixField -> WriteBidForwardPoints strm fixField
    | OfferSpotRate fixField -> WriteOfferSpotRate strm fixField
    | OfferForwardPoints fixField -> WriteOfferForwardPoints strm fixField
    | OrderQty2 fixField -> WriteOrderQty2 strm fixField
    | SettlDate2 fixField -> WriteSettlDate2 strm fixField
    | LastSpotRate fixField -> WriteLastSpotRate strm fixField
    | LastForwardPoints fixField -> WriteLastForwardPoints strm fixField
    | AllocLinkID fixField -> WriteAllocLinkID strm fixField
    | AllocLinkType fixField -> WriteAllocLinkType strm fixField
    | SecondaryOrderID fixField -> WriteSecondaryOrderID strm fixField
    | NoIOIQualifiers fixField -> WriteNoIOIQualifiers strm fixField
    | MaturityMonthYear fixField -> WriteMaturityMonthYear strm fixField
    | PutOrCall fixField -> WritePutOrCall strm fixField
    | StrikePrice fixField -> WriteStrikePrice strm fixField
    | CoveredOrUncovered fixField -> WriteCoveredOrUncovered strm fixField
    | OptAttribute fixField -> WriteOptAttribute strm fixField
    | SecurityExchange fixField -> WriteSecurityExchange strm fixField
    | NotifyBrokerOfCredit fixField -> WriteNotifyBrokerOfCredit strm fixField
    | AllocHandlInst fixField -> WriteAllocHandlInst strm fixField
    | MaxShow fixField -> WriteMaxShow strm fixField
    | PegOffsetValue fixField -> WritePegOffsetValue strm fixField
    | XmlData fixField -> WriteXmlData strm fixField // compound field
    | SettlInstRefID fixField -> WriteSettlInstRefID strm fixField
    | NoRoutingIDs fixField -> WriteNoRoutingIDs strm fixField
    | RoutingType fixField -> WriteRoutingType strm fixField
    | RoutingID fixField -> WriteRoutingID strm fixField
    | Spread fixField -> WriteSpread strm fixField
    | BenchmarkCurveCurrency fixField -> WriteBenchmarkCurveCurrency strm fixField
    | BenchmarkCurveName fixField -> WriteBenchmarkCurveName strm fixField
    | BenchmarkCurvePoint fixField -> WriteBenchmarkCurvePoint strm fixField
    | CouponRate fixField -> WriteCouponRate strm fixField
    | CouponPaymentDate fixField -> WriteCouponPaymentDate strm fixField
    | IssueDate fixField -> WriteIssueDate strm fixField
    | RepurchaseTerm fixField -> WriteRepurchaseTerm strm fixField
    | RepurchaseRate fixField -> WriteRepurchaseRate strm fixField
    | Factor fixField -> WriteFactor strm fixField
    | TradeOriginationDate fixField -> WriteTradeOriginationDate strm fixField
    | ExDate fixField -> WriteExDate strm fixField
    | ContractMultiplier fixField -> WriteContractMultiplier strm fixField
    | NoStipulations fixField -> WriteNoStipulations strm fixField
    | StipulationType fixField -> WriteStipulationType strm fixField
    | StipulationValue fixField -> WriteStipulationValue strm fixField
    | YieldType fixField -> WriteYieldType strm fixField
    | Yield fixField -> WriteYield strm fixField
    | TotalTakedown fixField -> WriteTotalTakedown strm fixField
    | Concession fixField -> WriteConcession strm fixField
    | RepoCollateralSecurityType fixField -> WriteRepoCollateralSecurityType strm fixField
    | RedemptionDate fixField -> WriteRedemptionDate strm fixField
    | UnderlyingCouponPaymentDate fixField -> WriteUnderlyingCouponPaymentDate strm fixField
    | UnderlyingIssueDate fixField -> WriteUnderlyingIssueDate strm fixField
    | UnderlyingRepoCollateralSecurityType fixField -> WriteUnderlyingRepoCollateralSecurityType strm fixField
    | UnderlyingRepurchaseTerm fixField -> WriteUnderlyingRepurchaseTerm strm fixField
    | UnderlyingRepurchaseRate fixField -> WriteUnderlyingRepurchaseRate strm fixField
    | UnderlyingFactor fixField -> WriteUnderlyingFactor strm fixField
    | UnderlyingRedemptionDate fixField -> WriteUnderlyingRedemptionDate strm fixField
    | LegCouponPaymentDate fixField -> WriteLegCouponPaymentDate strm fixField
    | LegIssueDate fixField -> WriteLegIssueDate strm fixField
    | LegRepoCollateralSecurityType fixField -> WriteLegRepoCollateralSecurityType strm fixField
    | LegRepurchaseTerm fixField -> WriteLegRepurchaseTerm strm fixField
    | LegRepurchaseRate fixField -> WriteLegRepurchaseRate strm fixField
    | LegFactor fixField -> WriteLegFactor strm fixField
    | LegRedemptionDate fixField -> WriteLegRedemptionDate strm fixField
    | CreditRating fixField -> WriteCreditRating strm fixField
    | UnderlyingCreditRating fixField -> WriteUnderlyingCreditRating strm fixField
    | LegCreditRating fixField -> WriteLegCreditRating strm fixField
    | TradedFlatSwitch fixField -> WriteTradedFlatSwitch strm fixField
    | BasisFeatureDate fixField -> WriteBasisFeatureDate strm fixField
    | BasisFeaturePrice fixField -> WriteBasisFeaturePrice strm fixField
    | MDReqID fixField -> WriteMDReqID strm fixField
    | SubscriptionRequestType fixField -> WriteSubscriptionRequestType strm fixField
    | MarketDepth fixField -> WriteMarketDepth strm fixField
    | MDUpdateType fixField -> WriteMDUpdateType strm fixField
    | AggregatedBook fixField -> WriteAggregatedBook strm fixField
    | NoMDEntryTypes fixField -> WriteNoMDEntryTypes strm fixField
    | NoMDEntries fixField -> WriteNoMDEntries strm fixField
    | MDEntryType fixField -> WriteMDEntryType strm fixField
    | MDEntryPx fixField -> WriteMDEntryPx strm fixField
    | MDEntrySize fixField -> WriteMDEntrySize strm fixField
    | MDEntryDate fixField -> WriteMDEntryDate strm fixField
    | MDEntryTime fixField -> WriteMDEntryTime strm fixField
    | TickDirection fixField -> WriteTickDirection strm fixField
    | MDMkt fixField -> WriteMDMkt strm fixField
    | QuoteCondition fixField -> WriteQuoteCondition strm fixField
    | TradeCondition fixField -> WriteTradeCondition strm fixField
    | MDEntryID fixField -> WriteMDEntryID strm fixField
    | MDUpdateAction fixField -> WriteMDUpdateAction strm fixField
    | MDEntryRefID fixField -> WriteMDEntryRefID strm fixField
    | MDReqRejReason fixField -> WriteMDReqRejReason strm fixField
    | MDEntryOriginator fixField -> WriteMDEntryOriginator strm fixField
    | LocationID fixField -> WriteLocationID strm fixField
    | DeskID fixField -> WriteDeskID strm fixField
    | DeleteReason fixField -> WriteDeleteReason strm fixField
    | OpenCloseSettlFlag fixField -> WriteOpenCloseSettlFlag strm fixField
    | SellerDays fixField -> WriteSellerDays strm fixField
    | MDEntryBuyer fixField -> WriteMDEntryBuyer strm fixField
    | MDEntrySeller fixField -> WriteMDEntrySeller strm fixField
    | MDEntryPositionNo fixField -> WriteMDEntryPositionNo strm fixField
    | FinancialStatus fixField -> WriteFinancialStatus strm fixField
    | CorporateAction fixField -> WriteCorporateAction strm fixField
    | DefBidSize fixField -> WriteDefBidSize strm fixField
    | DefOfferSize fixField -> WriteDefOfferSize strm fixField
    | NoQuoteEntries fixField -> WriteNoQuoteEntries strm fixField
    | NoQuoteSets fixField -> WriteNoQuoteSets strm fixField
    | QuoteStatus fixField -> WriteQuoteStatus strm fixField
    | QuoteCancelType fixField -> WriteQuoteCancelType strm fixField
    | QuoteEntryID fixField -> WriteQuoteEntryID strm fixField
    | QuoteRejectReason fixField -> WriteQuoteRejectReason strm fixField
    | QuoteResponseLevel fixField -> WriteQuoteResponseLevel strm fixField
    | QuoteSetID fixField -> WriteQuoteSetID strm fixField
    | QuoteRequestType fixField -> WriteQuoteRequestType strm fixField
    | TotNoQuoteEntries fixField -> WriteTotNoQuoteEntries strm fixField
    | UnderlyingSecurityIDSource fixField -> WriteUnderlyingSecurityIDSource strm fixField
    | UnderlyingIssuer fixField -> WriteUnderlyingIssuer strm fixField
    | UnderlyingSecurityDesc fixField -> WriteUnderlyingSecurityDesc strm fixField
    | UnderlyingSecurityExchange fixField -> WriteUnderlyingSecurityExchange strm fixField
    | UnderlyingSecurityID fixField -> WriteUnderlyingSecurityID strm fixField
    | UnderlyingSecurityType fixField -> WriteUnderlyingSecurityType strm fixField
    | UnderlyingSymbol fixField -> WriteUnderlyingSymbol strm fixField
    | UnderlyingSymbolSfx fixField -> WriteUnderlyingSymbolSfx strm fixField
    | UnderlyingMaturityMonthYear fixField -> WriteUnderlyingMaturityMonthYear strm fixField
    | UnderlyingPutOrCall fixField -> WriteUnderlyingPutOrCall strm fixField
    | UnderlyingStrikePrice fixField -> WriteUnderlyingStrikePrice strm fixField
    | UnderlyingOptAttribute fixField -> WriteUnderlyingOptAttribute strm fixField
    | UnderlyingCurrency fixField -> WriteUnderlyingCurrency strm fixField
    | SecurityReqID fixField -> WriteSecurityReqID strm fixField
    | SecurityRequestType fixField -> WriteSecurityRequestType strm fixField
    | SecurityResponseID fixField -> WriteSecurityResponseID strm fixField
    | SecurityResponseType fixField -> WriteSecurityResponseType strm fixField
    | SecurityStatusReqID fixField -> WriteSecurityStatusReqID strm fixField
    | UnsolicitedIndicator fixField -> WriteUnsolicitedIndicator strm fixField
    | SecurityTradingStatus fixField -> WriteSecurityTradingStatus strm fixField
    | HaltReason fixField -> WriteHaltReason strm fixField
    | InViewOfCommon fixField -> WriteInViewOfCommon strm fixField
    | DueToRelated fixField -> WriteDueToRelated strm fixField
    | BuyVolume fixField -> WriteBuyVolume strm fixField
    | SellVolume fixField -> WriteSellVolume strm fixField
    | HighPx fixField -> WriteHighPx strm fixField
    | LowPx fixField -> WriteLowPx strm fixField
    | Adjustment fixField -> WriteAdjustment strm fixField
    | TradSesReqID fixField -> WriteTradSesReqID strm fixField
    | TradingSessionID fixField -> WriteTradingSessionID strm fixField
    | ContraTrader fixField -> WriteContraTrader strm fixField
    | TradSesMethod fixField -> WriteTradSesMethod strm fixField
    | TradSesMode fixField -> WriteTradSesMode strm fixField
    | TradSesStatus fixField -> WriteTradSesStatus strm fixField
    | TradSesStartTime fixField -> WriteTradSesStartTime strm fixField
    | TradSesOpenTime fixField -> WriteTradSesOpenTime strm fixField
    | TradSesPreCloseTime fixField -> WriteTradSesPreCloseTime strm fixField
    | TradSesCloseTime fixField -> WriteTradSesCloseTime strm fixField
    | TradSesEndTime fixField -> WriteTradSesEndTime strm fixField
    | NumberOfOrders fixField -> WriteNumberOfOrders strm fixField
    | MessageEncoding fixField -> WriteMessageEncoding strm fixField
    | EncodedIssuer fixField -> WriteEncodedIssuer strm fixField // compound field
    | EncodedSecurityDesc fixField -> WriteEncodedSecurityDesc strm fixField // compound field
    | EncodedListExecInst fixField -> WriteEncodedListExecInst strm fixField // compound field
    | EncodedText fixField -> WriteEncodedText strm fixField // compound field
    | EncodedSubject fixField -> WriteEncodedSubject strm fixField // compound field
    | EncodedHeadline fixField -> WriteEncodedHeadline strm fixField // compound field
    | EncodedAllocText fixField -> WriteEncodedAllocText strm fixField // compound field
    | EncodedUnderlyingIssuer fixField -> WriteEncodedUnderlyingIssuer strm fixField // compound field
    | EncodedUnderlyingSecurityDesc fixField -> WriteEncodedUnderlyingSecurityDesc strm fixField // compound field
    | AllocPrice fixField -> WriteAllocPrice strm fixField
    | QuoteSetValidUntilTime fixField -> WriteQuoteSetValidUntilTime strm fixField
    | QuoteEntryRejectReason fixField -> WriteQuoteEntryRejectReason strm fixField
    | LastMsgSeqNumProcessed fixField -> WriteLastMsgSeqNumProcessed strm fixField
    | RefTagID fixField -> WriteRefTagID strm fixField
    | RefMsgType fixField -> WriteRefMsgType strm fixField
    | SessionRejectReason fixField -> WriteSessionRejectReason strm fixField
    | BidRequestTransType fixField -> WriteBidRequestTransType strm fixField
    | ContraBroker fixField -> WriteContraBroker strm fixField
    | ComplianceID fixField -> WriteComplianceID strm fixField
    | SolicitedFlag fixField -> WriteSolicitedFlag strm fixField
    | ExecRestatementReason fixField -> WriteExecRestatementReason strm fixField
    | BusinessRejectRefID fixField -> WriteBusinessRejectRefID strm fixField
    | BusinessRejectReason fixField -> WriteBusinessRejectReason strm fixField
    | GrossTradeAmt fixField -> WriteGrossTradeAmt strm fixField
    | NoContraBrokers fixField -> WriteNoContraBrokers strm fixField
    | MaxMessageSize fixField -> WriteMaxMessageSize strm fixField
    | NoMsgTypes fixField -> WriteNoMsgTypes strm fixField
    | MsgDirection fixField -> WriteMsgDirection strm fixField
    | NoTradingSessions fixField -> WriteNoTradingSessions strm fixField
    | TotalVolumeTraded fixField -> WriteTotalVolumeTraded strm fixField
    | DiscretionInst fixField -> WriteDiscretionInst strm fixField
    | DiscretionOffsetValue fixField -> WriteDiscretionOffsetValue strm fixField
    | BidID fixField -> WriteBidID strm fixField
    | ClientBidID fixField -> WriteClientBidID strm fixField
    | ListName fixField -> WriteListName strm fixField
    | TotNoRelatedSym fixField -> WriteTotNoRelatedSym strm fixField
    | BidType fixField -> WriteBidType strm fixField
    | NumTickets fixField -> WriteNumTickets strm fixField
    | SideValue1 fixField -> WriteSideValue1 strm fixField
    | SideValue2 fixField -> WriteSideValue2 strm fixField
    | NoBidDescriptors fixField -> WriteNoBidDescriptors strm fixField
    | BidDescriptorType fixField -> WriteBidDescriptorType strm fixField
    | BidDescriptor fixField -> WriteBidDescriptor strm fixField
    | SideValueInd fixField -> WriteSideValueInd strm fixField
    | LiquidityPctLow fixField -> WriteLiquidityPctLow strm fixField
    | LiquidityPctHigh fixField -> WriteLiquidityPctHigh strm fixField
    | LiquidityValue fixField -> WriteLiquidityValue strm fixField
    | EFPTrackingError fixField -> WriteEFPTrackingError strm fixField
    | FairValue fixField -> WriteFairValue strm fixField
    | OutsideIndexPct fixField -> WriteOutsideIndexPct strm fixField
    | ValueOfFutures fixField -> WriteValueOfFutures strm fixField
    | LiquidityIndType fixField -> WriteLiquidityIndType strm fixField
    | WtAverageLiquidity fixField -> WriteWtAverageLiquidity strm fixField
    | ExchangeForPhysical fixField -> WriteExchangeForPhysical strm fixField
    | OutMainCntryUIndex fixField -> WriteOutMainCntryUIndex strm fixField
    | CrossPercent fixField -> WriteCrossPercent strm fixField
    | ProgRptReqs fixField -> WriteProgRptReqs strm fixField
    | ProgPeriodInterval fixField -> WriteProgPeriodInterval strm fixField
    | IncTaxInd fixField -> WriteIncTaxInd strm fixField
    | NumBidders fixField -> WriteNumBidders strm fixField
    | BidTradeType fixField -> WriteBidTradeType strm fixField
    | BasisPxType fixField -> WriteBasisPxType strm fixField
    | NoBidComponents fixField -> WriteNoBidComponents strm fixField
    | Country fixField -> WriteCountry strm fixField
    | TotNoStrikes fixField -> WriteTotNoStrikes strm fixField
    | PriceType fixField -> WritePriceType strm fixField
    | DayOrderQty fixField -> WriteDayOrderQty strm fixField
    | DayCumQty fixField -> WriteDayCumQty strm fixField
    | DayAvgPx fixField -> WriteDayAvgPx strm fixField
    | GTBookingInst fixField -> WriteGTBookingInst strm fixField
    | NoStrikes fixField -> WriteNoStrikes strm fixField
    | ListStatusType fixField -> WriteListStatusType strm fixField
    | NetGrossInd fixField -> WriteNetGrossInd strm fixField
    | ListOrderStatus fixField -> WriteListOrderStatus strm fixField
    | ExpireDate fixField -> WriteExpireDate strm fixField
    | ListExecInstType fixField -> WriteListExecInstType strm fixField
    | CxlRejResponseTo fixField -> WriteCxlRejResponseTo strm fixField
    | UnderlyingCouponRate fixField -> WriteUnderlyingCouponRate strm fixField
    | UnderlyingContractMultiplier fixField -> WriteUnderlyingContractMultiplier strm fixField
    | ContraTradeQty fixField -> WriteContraTradeQty strm fixField
    | ContraTradeTime fixField -> WriteContraTradeTime strm fixField
    | LiquidityNumSecurities fixField -> WriteLiquidityNumSecurities strm fixField
    | MultiLegReportingType fixField -> WriteMultiLegReportingType strm fixField
    | StrikeTime fixField -> WriteStrikeTime strm fixField
    | ListStatusText fixField -> WriteListStatusText strm fixField
    | EncodedListStatusText fixField -> WriteEncodedListStatusText strm fixField // compound field
    | PartyIDSource fixField -> WritePartyIDSource strm fixField
    | PartyID fixField -> WritePartyID strm fixField
    | NetChgPrevDay fixField -> WriteNetChgPrevDay strm fixField
    | PartyRole fixField -> WritePartyRole strm fixField
    | NoPartyIDs fixField -> WriteNoPartyIDs strm fixField
    | NoSecurityAltID fixField -> WriteNoSecurityAltID strm fixField
    | SecurityAltID fixField -> WriteSecurityAltID strm fixField
    | SecurityAltIDSource fixField -> WriteSecurityAltIDSource strm fixField
    | NoUnderlyingSecurityAltID fixField -> WriteNoUnderlyingSecurityAltID strm fixField
    | UnderlyingSecurityAltID fixField -> WriteUnderlyingSecurityAltID strm fixField
    | UnderlyingSecurityAltIDSource fixField -> WriteUnderlyingSecurityAltIDSource strm fixField
    | Product fixField -> WriteProduct strm fixField
    | CFICode fixField -> WriteCFICode strm fixField
    | UnderlyingProduct fixField -> WriteUnderlyingProduct strm fixField
    | UnderlyingCFICode fixField -> WriteUnderlyingCFICode strm fixField
    | TestMessageIndicator fixField -> WriteTestMessageIndicator strm fixField
    | QuantityType fixField -> WriteQuantityType strm fixField
    | BookingRefID fixField -> WriteBookingRefID strm fixField
    | IndividualAllocID fixField -> WriteIndividualAllocID strm fixField
    | RoundingDirection fixField -> WriteRoundingDirection strm fixField
    | RoundingModulus fixField -> WriteRoundingModulus strm fixField
    | CountryOfIssue fixField -> WriteCountryOfIssue strm fixField
    | StateOrProvinceOfIssue fixField -> WriteStateOrProvinceOfIssue strm fixField
    | LocaleOfIssue fixField -> WriteLocaleOfIssue strm fixField
    | NoRegistDtls fixField -> WriteNoRegistDtls strm fixField
    | MailingDtls fixField -> WriteMailingDtls strm fixField
    | InvestorCountryOfResidence fixField -> WriteInvestorCountryOfResidence strm fixField
    | PaymentRef fixField -> WritePaymentRef strm fixField
    | DistribPaymentMethod fixField -> WriteDistribPaymentMethod strm fixField
    | CashDistribCurr fixField -> WriteCashDistribCurr strm fixField
    | CommCurrency fixField -> WriteCommCurrency strm fixField
    | CancellationRights fixField -> WriteCancellationRights strm fixField
    | MoneyLaunderingStatus fixField -> WriteMoneyLaunderingStatus strm fixField
    | MailingInst fixField -> WriteMailingInst strm fixField
    | TransBkdTime fixField -> WriteTransBkdTime strm fixField
    | ExecPriceType fixField -> WriteExecPriceType strm fixField
    | ExecPriceAdjustment fixField -> WriteExecPriceAdjustment strm fixField
    | DateOfBirth fixField -> WriteDateOfBirth strm fixField
    | TradeReportTransType fixField -> WriteTradeReportTransType strm fixField
    | CardHolderName fixField -> WriteCardHolderName strm fixField
    | CardNumber fixField -> WriteCardNumber strm fixField
    | CardExpDate fixField -> WriteCardExpDate strm fixField
    | CardIssNum fixField -> WriteCardIssNum strm fixField
    | PaymentMethod fixField -> WritePaymentMethod strm fixField
    | RegistAcctType fixField -> WriteRegistAcctType strm fixField
    | Designation fixField -> WriteDesignation strm fixField
    | TaxAdvantageType fixField -> WriteTaxAdvantageType strm fixField
    | RegistRejReasonText fixField -> WriteRegistRejReasonText strm fixField
    | FundRenewWaiv fixField -> WriteFundRenewWaiv strm fixField
    | CashDistribAgentName fixField -> WriteCashDistribAgentName strm fixField
    | CashDistribAgentCode fixField -> WriteCashDistribAgentCode strm fixField
    | CashDistribAgentAcctNumber fixField -> WriteCashDistribAgentAcctNumber strm fixField
    | CashDistribPayRef fixField -> WriteCashDistribPayRef strm fixField
    | CashDistribAgentAcctName fixField -> WriteCashDistribAgentAcctName strm fixField
    | CardStartDate fixField -> WriteCardStartDate strm fixField
    | PaymentDate fixField -> WritePaymentDate strm fixField
    | PaymentRemitterID fixField -> WritePaymentRemitterID strm fixField
    | RegistStatus fixField -> WriteRegistStatus strm fixField
    | RegistRejReasonCode fixField -> WriteRegistRejReasonCode strm fixField
    | RegistRefID fixField -> WriteRegistRefID strm fixField
    | RegistDtls fixField -> WriteRegistDtls strm fixField
    | NoDistribInsts fixField -> WriteNoDistribInsts strm fixField
    | RegistEmail fixField -> WriteRegistEmail strm fixField
    | DistribPercentage fixField -> WriteDistribPercentage strm fixField
    | RegistID fixField -> WriteRegistID strm fixField
    | RegistTransType fixField -> WriteRegistTransType strm fixField
    | ExecValuationPoint fixField -> WriteExecValuationPoint strm fixField
    | OrderPercent fixField -> WriteOrderPercent strm fixField
    | OwnershipType fixField -> WriteOwnershipType strm fixField
    | NoContAmts fixField -> WriteNoContAmts strm fixField
    | ContAmtType fixField -> WriteContAmtType strm fixField
    | ContAmtValue fixField -> WriteContAmtValue strm fixField
    | ContAmtCurr fixField -> WriteContAmtCurr strm fixField
    | OwnerType fixField -> WriteOwnerType strm fixField
    | PartySubID fixField -> WritePartySubID strm fixField
    | NestedPartyID fixField -> WriteNestedPartyID strm fixField
    | NestedPartyIDSource fixField -> WriteNestedPartyIDSource strm fixField
    | SecondaryClOrdID fixField -> WriteSecondaryClOrdID strm fixField
    | SecondaryExecID fixField -> WriteSecondaryExecID strm fixField
    | OrderCapacity fixField -> WriteOrderCapacity strm fixField
    | OrderRestrictions fixField -> WriteOrderRestrictions strm fixField
    | MassCancelRequestType fixField -> WriteMassCancelRequestType strm fixField
    | MassCancelResponse fixField -> WriteMassCancelResponse strm fixField
    | MassCancelRejectReason fixField -> WriteMassCancelRejectReason strm fixField
    | TotalAffectedOrders fixField -> WriteTotalAffectedOrders strm fixField
    | NoAffectedOrders fixField -> WriteNoAffectedOrders strm fixField
    | AffectedOrderID fixField -> WriteAffectedOrderID strm fixField
    | AffectedSecondaryOrderID fixField -> WriteAffectedSecondaryOrderID strm fixField
    | QuoteType fixField -> WriteQuoteType strm fixField
    | NestedPartyRole fixField -> WriteNestedPartyRole strm fixField
    | NoNestedPartyIDs fixField -> WriteNoNestedPartyIDs strm fixField
    | TotalAccruedInterestAmt fixField -> WriteTotalAccruedInterestAmt strm fixField
    | MaturityDate fixField -> WriteMaturityDate strm fixField
    | UnderlyingMaturityDate fixField -> WriteUnderlyingMaturityDate strm fixField
    | InstrRegistry fixField -> WriteInstrRegistry strm fixField
    | CashMargin fixField -> WriteCashMargin strm fixField
    | NestedPartySubID fixField -> WriteNestedPartySubID strm fixField
    | Scope fixField -> WriteScope strm fixField
    | MDImplicitDelete fixField -> WriteMDImplicitDelete strm fixField
    | CrossID fixField -> WriteCrossID strm fixField
    | CrossType fixField -> WriteCrossType strm fixField
    | CrossPrioritization fixField -> WriteCrossPrioritization strm fixField
    | OrigCrossID fixField -> WriteOrigCrossID strm fixField
    | NoSides fixField -> WriteNoSides strm fixField
    | Username fixField -> WriteUsername strm fixField
    | Password fixField -> WritePassword strm fixField
    | NoLegs fixField -> WriteNoLegs strm fixField
    | LegCurrency fixField -> WriteLegCurrency strm fixField
    | TotNoSecurityTypes fixField -> WriteTotNoSecurityTypes strm fixField
    | NoSecurityTypes fixField -> WriteNoSecurityTypes strm fixField
    | SecurityListRequestType fixField -> WriteSecurityListRequestType strm fixField
    | SecurityRequestResult fixField -> WriteSecurityRequestResult strm fixField
    | RoundLot fixField -> WriteRoundLot strm fixField
    | MinTradeVol fixField -> WriteMinTradeVol strm fixField
    | MultiLegRptTypeReq fixField -> WriteMultiLegRptTypeReq strm fixField
    | LegPositionEffect fixField -> WriteLegPositionEffect strm fixField
    | LegCoveredOrUncovered fixField -> WriteLegCoveredOrUncovered strm fixField
    | LegPrice fixField -> WriteLegPrice strm fixField
    | TradSesStatusRejReason fixField -> WriteTradSesStatusRejReason strm fixField
    | TradeRequestID fixField -> WriteTradeRequestID strm fixField
    | TradeRequestType fixField -> WriteTradeRequestType strm fixField
    | PreviouslyReported fixField -> WritePreviouslyReported strm fixField
    | TradeReportID fixField -> WriteTradeReportID strm fixField
    | TradeReportRefID fixField -> WriteTradeReportRefID strm fixField
    | MatchStatus fixField -> WriteMatchStatus strm fixField
    | MatchType fixField -> WriteMatchType strm fixField
    | OddLot fixField -> WriteOddLot strm fixField
    | NoClearingInstructions fixField -> WriteNoClearingInstructions strm fixField
    | ClearingInstruction fixField -> WriteClearingInstruction strm fixField
    | TradeInputSource fixField -> WriteTradeInputSource strm fixField
    | TradeInputDevice fixField -> WriteTradeInputDevice strm fixField
    | NoDates fixField -> WriteNoDates strm fixField
    | AccountType fixField -> WriteAccountType strm fixField
    | CustOrderCapacity fixField -> WriteCustOrderCapacity strm fixField
    | ClOrdLinkID fixField -> WriteClOrdLinkID strm fixField
    | MassStatusReqID fixField -> WriteMassStatusReqID strm fixField
    | MassStatusReqType fixField -> WriteMassStatusReqType strm fixField
    | OrigOrdModTime fixField -> WriteOrigOrdModTime strm fixField
    | LegSettlType fixField -> WriteLegSettlType strm fixField
    | LegSettlDate fixField -> WriteLegSettlDate strm fixField
    | DayBookingInst fixField -> WriteDayBookingInst strm fixField
    | BookingUnit fixField -> WriteBookingUnit strm fixField
    | PreallocMethod fixField -> WritePreallocMethod strm fixField
    | UnderlyingCountryOfIssue fixField -> WriteUnderlyingCountryOfIssue strm fixField
    | UnderlyingStateOrProvinceOfIssue fixField -> WriteUnderlyingStateOrProvinceOfIssue strm fixField
    | UnderlyingLocaleOfIssue fixField -> WriteUnderlyingLocaleOfIssue strm fixField
    | UnderlyingInstrRegistry fixField -> WriteUnderlyingInstrRegistry strm fixField
    | LegCountryOfIssue fixField -> WriteLegCountryOfIssue strm fixField
    | LegStateOrProvinceOfIssue fixField -> WriteLegStateOrProvinceOfIssue strm fixField
    | LegLocaleOfIssue fixField -> WriteLegLocaleOfIssue strm fixField
    | LegInstrRegistry fixField -> WriteLegInstrRegistry strm fixField
    | LegSymbol fixField -> WriteLegSymbol strm fixField
    | LegSymbolSfx fixField -> WriteLegSymbolSfx strm fixField
    | LegSecurityID fixField -> WriteLegSecurityID strm fixField
    | LegSecurityIDSource fixField -> WriteLegSecurityIDSource strm fixField
    | NoLegSecurityAltID fixField -> WriteNoLegSecurityAltID strm fixField
    | LegSecurityAltID fixField -> WriteLegSecurityAltID strm fixField
    | LegSecurityAltIDSource fixField -> WriteLegSecurityAltIDSource strm fixField
    | LegProduct fixField -> WriteLegProduct strm fixField
    | LegCFICode fixField -> WriteLegCFICode strm fixField
    | LegSecurityType fixField -> WriteLegSecurityType strm fixField
    | LegMaturityMonthYear fixField -> WriteLegMaturityMonthYear strm fixField
    | LegMaturityDate fixField -> WriteLegMaturityDate strm fixField
    | LegStrikePrice fixField -> WriteLegStrikePrice strm fixField
    | LegOptAttribute fixField -> WriteLegOptAttribute strm fixField
    | LegContractMultiplier fixField -> WriteLegContractMultiplier strm fixField
    | LegCouponRate fixField -> WriteLegCouponRate strm fixField
    | LegSecurityExchange fixField -> WriteLegSecurityExchange strm fixField
    | LegIssuer fixField -> WriteLegIssuer strm fixField
    | EncodedLegIssuer fixField -> WriteEncodedLegIssuer strm fixField // compound field
    | LegSecurityDesc fixField -> WriteLegSecurityDesc strm fixField
    | EncodedLegSecurityDesc fixField -> WriteEncodedLegSecurityDesc strm fixField // compound field
    | LegRatioQty fixField -> WriteLegRatioQty strm fixField
    | LegSide fixField -> WriteLegSide strm fixField
    | TradingSessionSubID fixField -> WriteTradingSessionSubID strm fixField
    | AllocType fixField -> WriteAllocType strm fixField
    | NoHops fixField -> WriteNoHops strm fixField
    | HopCompID fixField -> WriteHopCompID strm fixField
    | HopSendingTime fixField -> WriteHopSendingTime strm fixField
    | HopRefID fixField -> WriteHopRefID strm fixField
    | MidPx fixField -> WriteMidPx strm fixField
    | BidYield fixField -> WriteBidYield strm fixField
    | MidYield fixField -> WriteMidYield strm fixField
    | OfferYield fixField -> WriteOfferYield strm fixField
    | ClearingFeeIndicator fixField -> WriteClearingFeeIndicator strm fixField
    | WorkingIndicator fixField -> WriteWorkingIndicator strm fixField
    | LegLastPx fixField -> WriteLegLastPx strm fixField
    | PriorityIndicator fixField -> WritePriorityIndicator strm fixField
    | PriceImprovement fixField -> WritePriceImprovement strm fixField
    | Price2 fixField -> WritePrice2 strm fixField
    | LastForwardPoints2 fixField -> WriteLastForwardPoints2 strm fixField
    | BidForwardPoints2 fixField -> WriteBidForwardPoints2 strm fixField
    | OfferForwardPoints2 fixField -> WriteOfferForwardPoints2 strm fixField
    | RFQReqID fixField -> WriteRFQReqID strm fixField
    | MktBidPx fixField -> WriteMktBidPx strm fixField
    | MktOfferPx fixField -> WriteMktOfferPx strm fixField
    | MinBidSize fixField -> WriteMinBidSize strm fixField
    | MinOfferSize fixField -> WriteMinOfferSize strm fixField
    | QuoteStatusReqID fixField -> WriteQuoteStatusReqID strm fixField
    | LegalConfirm fixField -> WriteLegalConfirm strm fixField
    | UnderlyingLastPx fixField -> WriteUnderlyingLastPx strm fixField
    | UnderlyingLastQty fixField -> WriteUnderlyingLastQty strm fixField
    | LegRefID fixField -> WriteLegRefID strm fixField
    | ContraLegRefID fixField -> WriteContraLegRefID strm fixField
    | SettlCurrBidFxRate fixField -> WriteSettlCurrBidFxRate strm fixField
    | SettlCurrOfferFxRate fixField -> WriteSettlCurrOfferFxRate strm fixField
    | QuoteRequestRejectReason fixField -> WriteQuoteRequestRejectReason strm fixField
    | SideComplianceID fixField -> WriteSideComplianceID strm fixField
    | AcctIDSource fixField -> WriteAcctIDSource strm fixField
    | AllocAcctIDSource fixField -> WriteAllocAcctIDSource strm fixField
    | BenchmarkPrice fixField -> WriteBenchmarkPrice strm fixField
    | BenchmarkPriceType fixField -> WriteBenchmarkPriceType strm fixField
    | ConfirmID fixField -> WriteConfirmID strm fixField
    | ConfirmStatus fixField -> WriteConfirmStatus strm fixField
    | ConfirmTransType fixField -> WriteConfirmTransType strm fixField
    | ContractSettlMonth fixField -> WriteContractSettlMonth strm fixField
    | DeliveryForm fixField -> WriteDeliveryForm strm fixField
    | LastParPx fixField -> WriteLastParPx strm fixField
    | NoLegAllocs fixField -> WriteNoLegAllocs strm fixField
    | LegAllocAccount fixField -> WriteLegAllocAccount strm fixField
    | LegIndividualAllocID fixField -> WriteLegIndividualAllocID strm fixField
    | LegAllocQty fixField -> WriteLegAllocQty strm fixField
    | LegAllocAcctIDSource fixField -> WriteLegAllocAcctIDSource strm fixField
    | LegSettlCurrency fixField -> WriteLegSettlCurrency strm fixField
    | LegBenchmarkCurveCurrency fixField -> WriteLegBenchmarkCurveCurrency strm fixField
    | LegBenchmarkCurveName fixField -> WriteLegBenchmarkCurveName strm fixField
    | LegBenchmarkCurvePoint fixField -> WriteLegBenchmarkCurvePoint strm fixField
    | LegBenchmarkPrice fixField -> WriteLegBenchmarkPrice strm fixField
    | LegBenchmarkPriceType fixField -> WriteLegBenchmarkPriceType strm fixField
    | LegBidPx fixField -> WriteLegBidPx strm fixField
    | LegIOIQty fixField -> WriteLegIOIQty strm fixField
    | NoLegStipulations fixField -> WriteNoLegStipulations strm fixField
    | LegOfferPx fixField -> WriteLegOfferPx strm fixField
    | LegOrderQty fixField -> WriteLegOrderQty strm fixField
    | LegPriceType fixField -> WriteLegPriceType strm fixField
    | LegQty fixField -> WriteLegQty strm fixField
    | LegStipulationType fixField -> WriteLegStipulationType strm fixField
    | LegStipulationValue fixField -> WriteLegStipulationValue strm fixField
    | LegSwapType fixField -> WriteLegSwapType strm fixField
    | Pool fixField -> WritePool strm fixField
    | QuotePriceType fixField -> WriteQuotePriceType strm fixField
    | QuoteRespID fixField -> WriteQuoteRespID strm fixField
    | QuoteRespType fixField -> WriteQuoteRespType strm fixField
    | QuoteQualifier fixField -> WriteQuoteQualifier strm fixField
    | YieldRedemptionDate fixField -> WriteYieldRedemptionDate strm fixField
    | YieldRedemptionPrice fixField -> WriteYieldRedemptionPrice strm fixField
    | YieldRedemptionPriceType fixField -> WriteYieldRedemptionPriceType strm fixField
    | BenchmarkSecurityID fixField -> WriteBenchmarkSecurityID strm fixField
    | ReversalIndicator fixField -> WriteReversalIndicator strm fixField
    | YieldCalcDate fixField -> WriteYieldCalcDate strm fixField
    | NoPositions fixField -> WriteNoPositions strm fixField
    | PosType fixField -> WritePosType strm fixField
    | LongQty fixField -> WriteLongQty strm fixField
    | ShortQty fixField -> WriteShortQty strm fixField
    | PosQtyStatus fixField -> WritePosQtyStatus strm fixField
    | PosAmtType fixField -> WritePosAmtType strm fixField
    | PosAmt fixField -> WritePosAmt strm fixField
    | PosTransType fixField -> WritePosTransType strm fixField
    | PosReqID fixField -> WritePosReqID strm fixField
    | NoUnderlyings fixField -> WriteNoUnderlyings strm fixField
    | PosMaintAction fixField -> WritePosMaintAction strm fixField
    | OrigPosReqRefID fixField -> WriteOrigPosReqRefID strm fixField
    | PosMaintRptRefID fixField -> WritePosMaintRptRefID strm fixField
    | ClearingBusinessDate fixField -> WriteClearingBusinessDate strm fixField
    | SettlSessID fixField -> WriteSettlSessID strm fixField
    | SettlSessSubID fixField -> WriteSettlSessSubID strm fixField
    | AdjustmentType fixField -> WriteAdjustmentType strm fixField
    | ContraryInstructionIndicator fixField -> WriteContraryInstructionIndicator strm fixField
    | PriorSpreadIndicator fixField -> WritePriorSpreadIndicator strm fixField
    | PosMaintRptID fixField -> WritePosMaintRptID strm fixField
    | PosMaintStatus fixField -> WritePosMaintStatus strm fixField
    | PosMaintResult fixField -> WritePosMaintResult strm fixField
    | PosReqType fixField -> WritePosReqType strm fixField
    | ResponseTransportType fixField -> WriteResponseTransportType strm fixField
    | ResponseDestination fixField -> WriteResponseDestination strm fixField
    | TotalNumPosReports fixField -> WriteTotalNumPosReports strm fixField
    | PosReqResult fixField -> WritePosReqResult strm fixField
    | PosReqStatus fixField -> WritePosReqStatus strm fixField
    | SettlPrice fixField -> WriteSettlPrice strm fixField
    | SettlPriceType fixField -> WriteSettlPriceType strm fixField
    | UnderlyingSettlPrice fixField -> WriteUnderlyingSettlPrice strm fixField
    | UnderlyingSettlPriceType fixField -> WriteUnderlyingSettlPriceType strm fixField
    | PriorSettlPrice fixField -> WritePriorSettlPrice strm fixField
    | NoQuoteQualifiers fixField -> WriteNoQuoteQualifiers strm fixField
    | AllocSettlCurrency fixField -> WriteAllocSettlCurrency strm fixField
    | AllocSettlCurrAmt fixField -> WriteAllocSettlCurrAmt strm fixField
    | InterestAtMaturity fixField -> WriteInterestAtMaturity strm fixField
    | LegDatedDate fixField -> WriteLegDatedDate strm fixField
    | LegPool fixField -> WriteLegPool strm fixField
    | AllocInterestAtMaturity fixField -> WriteAllocInterestAtMaturity strm fixField
    | AllocAccruedInterestAmt fixField -> WriteAllocAccruedInterestAmt strm fixField
    | DeliveryDate fixField -> WriteDeliveryDate strm fixField
    | AssignmentMethod fixField -> WriteAssignmentMethod strm fixField
    | AssignmentUnit fixField -> WriteAssignmentUnit strm fixField
    | OpenInterest fixField -> WriteOpenInterest strm fixField
    | ExerciseMethod fixField -> WriteExerciseMethod strm fixField
    | TotNumTradeReports fixField -> WriteTotNumTradeReports strm fixField
    | TradeRequestResult fixField -> WriteTradeRequestResult strm fixField
    | TradeRequestStatus fixField -> WriteTradeRequestStatus strm fixField
    | TradeReportRejectReason fixField -> WriteTradeReportRejectReason strm fixField
    | SideMultiLegReportingType fixField -> WriteSideMultiLegReportingType strm fixField
    | NoPosAmt fixField -> WriteNoPosAmt strm fixField
    | AutoAcceptIndicator fixField -> WriteAutoAcceptIndicator strm fixField
    | AllocReportID fixField -> WriteAllocReportID strm fixField
    | NoNested2PartyIDs fixField -> WriteNoNested2PartyIDs strm fixField
    | Nested2PartyID fixField -> WriteNested2PartyID strm fixField
    | Nested2PartyIDSource fixField -> WriteNested2PartyIDSource strm fixField
    | Nested2PartyRole fixField -> WriteNested2PartyRole strm fixField
    | Nested2PartySubID fixField -> WriteNested2PartySubID strm fixField
    | BenchmarkSecurityIDSource fixField -> WriteBenchmarkSecurityIDSource strm fixField
    | SecuritySubType fixField -> WriteSecuritySubType strm fixField
    | UnderlyingSecuritySubType fixField -> WriteUnderlyingSecuritySubType strm fixField
    | LegSecuritySubType fixField -> WriteLegSecuritySubType strm fixField
    | AllowableOneSidednessPct fixField -> WriteAllowableOneSidednessPct strm fixField
    | AllowableOneSidednessValue fixField -> WriteAllowableOneSidednessValue strm fixField
    | AllowableOneSidednessCurr fixField -> WriteAllowableOneSidednessCurr strm fixField
    | NoTrdRegTimestamps fixField -> WriteNoTrdRegTimestamps strm fixField
    | TrdRegTimestamp fixField -> WriteTrdRegTimestamp strm fixField
    | TrdRegTimestampType fixField -> WriteTrdRegTimestampType strm fixField
    | TrdRegTimestampOrigin fixField -> WriteTrdRegTimestampOrigin strm fixField
    | ConfirmRefID fixField -> WriteConfirmRefID strm fixField
    | ConfirmType fixField -> WriteConfirmType strm fixField
    | ConfirmRejReason fixField -> WriteConfirmRejReason strm fixField
    | BookingType fixField -> WriteBookingType strm fixField
    | IndividualAllocRejCode fixField -> WriteIndividualAllocRejCode strm fixField
    | SettlInstMsgID fixField -> WriteSettlInstMsgID strm fixField
    | NoSettlInst fixField -> WriteNoSettlInst strm fixField
    | LastUpdateTime fixField -> WriteLastUpdateTime strm fixField
    | AllocSettlInstType fixField -> WriteAllocSettlInstType strm fixField
    | NoSettlPartyIDs fixField -> WriteNoSettlPartyIDs strm fixField
    | SettlPartyID fixField -> WriteSettlPartyID strm fixField
    | SettlPartyIDSource fixField -> WriteSettlPartyIDSource strm fixField
    | SettlPartyRole fixField -> WriteSettlPartyRole strm fixField
    | SettlPartySubID fixField -> WriteSettlPartySubID strm fixField
    | SettlPartySubIDType fixField -> WriteSettlPartySubIDType strm fixField
    | DlvyInstType fixField -> WriteDlvyInstType strm fixField
    | TerminationType fixField -> WriteTerminationType strm fixField
    | NextExpectedMsgSeqNum fixField -> WriteNextExpectedMsgSeqNum strm fixField
    | OrdStatusReqID fixField -> WriteOrdStatusReqID strm fixField
    | SettlInstReqID fixField -> WriteSettlInstReqID strm fixField
    | SettlInstReqRejCode fixField -> WriteSettlInstReqRejCode strm fixField
    | SecondaryAllocID fixField -> WriteSecondaryAllocID strm fixField
    | AllocReportType fixField -> WriteAllocReportType strm fixField
    | AllocReportRefID fixField -> WriteAllocReportRefID strm fixField
    | AllocCancReplaceReason fixField -> WriteAllocCancReplaceReason strm fixField
    | CopyMsgIndicator fixField -> WriteCopyMsgIndicator strm fixField
    | AllocAccountType fixField -> WriteAllocAccountType strm fixField
    | OrderAvgPx fixField -> WriteOrderAvgPx strm fixField
    | OrderBookingQty fixField -> WriteOrderBookingQty strm fixField
    | NoSettlPartySubIDs fixField -> WriteNoSettlPartySubIDs strm fixField
    | NoPartySubIDs fixField -> WriteNoPartySubIDs strm fixField
    | PartySubIDType fixField -> WritePartySubIDType strm fixField
    | NoNestedPartySubIDs fixField -> WriteNoNestedPartySubIDs strm fixField
    | NestedPartySubIDType fixField -> WriteNestedPartySubIDType strm fixField
    | NoNested2PartySubIDs fixField -> WriteNoNested2PartySubIDs strm fixField
    | Nested2PartySubIDType fixField -> WriteNested2PartySubIDType strm fixField
    | AllocIntermedReqType fixField -> WriteAllocIntermedReqType strm fixField
    | UnderlyingPx fixField -> WriteUnderlyingPx strm fixField
    | PriceDelta fixField -> WritePriceDelta strm fixField
    | ApplQueueMax fixField -> WriteApplQueueMax strm fixField
    | ApplQueueDepth fixField -> WriteApplQueueDepth strm fixField
    | ApplQueueResolution fixField -> WriteApplQueueResolution strm fixField
    | ApplQueueAction fixField -> WriteApplQueueAction strm fixField
    | NoAltMDSource fixField -> WriteNoAltMDSource strm fixField
    | AltMDSourceID fixField -> WriteAltMDSourceID strm fixField
    | SecondaryTradeReportID fixField -> WriteSecondaryTradeReportID strm fixField
    | AvgPxIndicator fixField -> WriteAvgPxIndicator strm fixField
    | TradeLinkID fixField -> WriteTradeLinkID strm fixField
    | OrderInputDevice fixField -> WriteOrderInputDevice strm fixField
    | UnderlyingTradingSessionID fixField -> WriteUnderlyingTradingSessionID strm fixField
    | UnderlyingTradingSessionSubID fixField -> WriteUnderlyingTradingSessionSubID strm fixField
    | TradeLegRefID fixField -> WriteTradeLegRefID strm fixField
    | ExchangeRule fixField -> WriteExchangeRule strm fixField
    | TradeAllocIndicator fixField -> WriteTradeAllocIndicator strm fixField
    | ExpirationCycle fixField -> WriteExpirationCycle strm fixField
    | TrdType fixField -> WriteTrdType strm fixField
    | TrdSubType fixField -> WriteTrdSubType strm fixField
    | TransferReason fixField -> WriteTransferReason strm fixField
    | AsgnReqID fixField -> WriteAsgnReqID strm fixField
    | TotNumAssignmentReports fixField -> WriteTotNumAssignmentReports strm fixField
    | AsgnRptID fixField -> WriteAsgnRptID strm fixField
    | ThresholdAmount fixField -> WriteThresholdAmount strm fixField
    | PegMoveType fixField -> WritePegMoveType strm fixField
    | PegOffsetType fixField -> WritePegOffsetType strm fixField
    | PegLimitType fixField -> WritePegLimitType strm fixField
    | PegRoundDirection fixField -> WritePegRoundDirection strm fixField
    | PeggedPrice fixField -> WritePeggedPrice strm fixField
    | PegScope fixField -> WritePegScope strm fixField
    | DiscretionMoveType fixField -> WriteDiscretionMoveType strm fixField
    | DiscretionOffsetType fixField -> WriteDiscretionOffsetType strm fixField
    | DiscretionLimitType fixField -> WriteDiscretionLimitType strm fixField
    | DiscretionRoundDirection fixField -> WriteDiscretionRoundDirection strm fixField
    | DiscretionPrice fixField -> WriteDiscretionPrice strm fixField
    | DiscretionScope fixField -> WriteDiscretionScope strm fixField
    | TargetStrategy fixField -> WriteTargetStrategy strm fixField
    | TargetStrategyParameters fixField -> WriteTargetStrategyParameters strm fixField
    | ParticipationRate fixField -> WriteParticipationRate strm fixField
    | TargetStrategyPerformance fixField -> WriteTargetStrategyPerformance strm fixField
    | LastLiquidityInd fixField -> WriteLastLiquidityInd strm fixField
    | PublishTrdIndicator fixField -> WritePublishTrdIndicator strm fixField
    | ShortSaleReason fixField -> WriteShortSaleReason strm fixField
    | QtyType fixField -> WriteQtyType strm fixField
    | SecondaryTrdType fixField -> WriteSecondaryTrdType strm fixField
    | TradeReportType fixField -> WriteTradeReportType strm fixField
    | AllocNoOrdersType fixField -> WriteAllocNoOrdersType strm fixField
    | SharedCommission fixField -> WriteSharedCommission strm fixField
    | ConfirmReqID fixField -> WriteConfirmReqID strm fixField
    | AvgParPx fixField -> WriteAvgParPx strm fixField
    | ReportedPx fixField -> WriteReportedPx strm fixField
    | NoCapacities fixField -> WriteNoCapacities strm fixField
    | OrderCapacityQty fixField -> WriteOrderCapacityQty strm fixField
    | NoEvents fixField -> WriteNoEvents strm fixField
    | EventType fixField -> WriteEventType strm fixField
    | EventDate fixField -> WriteEventDate strm fixField
    | EventPx fixField -> WriteEventPx strm fixField
    | EventText fixField -> WriteEventText strm fixField
    | PctAtRisk fixField -> WritePctAtRisk strm fixField
    | NoInstrAttrib fixField -> WriteNoInstrAttrib strm fixField
    | InstrAttribType fixField -> WriteInstrAttribType strm fixField
    | InstrAttribValue fixField -> WriteInstrAttribValue strm fixField
    | DatedDate fixField -> WriteDatedDate strm fixField
    | InterestAccrualDate fixField -> WriteInterestAccrualDate strm fixField
    | CPProgram fixField -> WriteCPProgram strm fixField
    | CPRegType fixField -> WriteCPRegType strm fixField
    | UnderlyingCPProgram fixField -> WriteUnderlyingCPProgram strm fixField
    | UnderlyingCPRegType fixField -> WriteUnderlyingCPRegType strm fixField
    | UnderlyingQty fixField -> WriteUnderlyingQty strm fixField
    | TrdMatchID fixField -> WriteTrdMatchID strm fixField
    | SecondaryTradeReportRefID fixField -> WriteSecondaryTradeReportRefID strm fixField
    | UnderlyingDirtyPrice fixField -> WriteUnderlyingDirtyPrice strm fixField
    | UnderlyingEndPrice fixField -> WriteUnderlyingEndPrice strm fixField
    | UnderlyingStartValue fixField -> WriteUnderlyingStartValue strm fixField
    | UnderlyingCurrentValue fixField -> WriteUnderlyingCurrentValue strm fixField
    | UnderlyingEndValue fixField -> WriteUnderlyingEndValue strm fixField
    | NoUnderlyingStips fixField -> WriteNoUnderlyingStips strm fixField
    | UnderlyingStipType fixField -> WriteUnderlyingStipType strm fixField
    | UnderlyingStipValue fixField -> WriteUnderlyingStipValue strm fixField
    | MaturityNetMoney fixField -> WriteMaturityNetMoney strm fixField
    | MiscFeeBasis fixField -> WriteMiscFeeBasis strm fixField
    | TotNoAllocs fixField -> WriteTotNoAllocs strm fixField
    | LastFragment fixField -> WriteLastFragment strm fixField
    | CollReqID fixField -> WriteCollReqID strm fixField
    | CollAsgnReason fixField -> WriteCollAsgnReason strm fixField
    | CollInquiryQualifier fixField -> WriteCollInquiryQualifier strm fixField
    | NoTrades fixField -> WriteNoTrades strm fixField
    | MarginRatio fixField -> WriteMarginRatio strm fixField
    | MarginExcess fixField -> WriteMarginExcess strm fixField
    | TotalNetValue fixField -> WriteTotalNetValue strm fixField
    | CashOutstanding fixField -> WriteCashOutstanding strm fixField
    | CollAsgnID fixField -> WriteCollAsgnID strm fixField
    | CollAsgnTransType fixField -> WriteCollAsgnTransType strm fixField
    | CollRespID fixField -> WriteCollRespID strm fixField
    | CollAsgnRespType fixField -> WriteCollAsgnRespType strm fixField
    | CollAsgnRejectReason fixField -> WriteCollAsgnRejectReason strm fixField
    | CollAsgnRefID fixField -> WriteCollAsgnRefID strm fixField
    | CollRptID fixField -> WriteCollRptID strm fixField
    | CollInquiryID fixField -> WriteCollInquiryID strm fixField
    | CollStatus fixField -> WriteCollStatus strm fixField
    | TotNumReports fixField -> WriteTotNumReports strm fixField
    | LastRptRequested fixField -> WriteLastRptRequested strm fixField
    | AgreementDesc fixField -> WriteAgreementDesc strm fixField
    | AgreementID fixField -> WriteAgreementID strm fixField
    | AgreementDate fixField -> WriteAgreementDate strm fixField
    | StartDate fixField -> WriteStartDate strm fixField
    | EndDate fixField -> WriteEndDate strm fixField
    | AgreementCurrency fixField -> WriteAgreementCurrency strm fixField
    | DeliveryType fixField -> WriteDeliveryType strm fixField
    | EndAccruedInterestAmt fixField -> WriteEndAccruedInterestAmt strm fixField
    | StartCash fixField -> WriteStartCash strm fixField
    | EndCash fixField -> WriteEndCash strm fixField
    | UserRequestID fixField -> WriteUserRequestID strm fixField
    | UserRequestType fixField -> WriteUserRequestType strm fixField
    | NewPassword fixField -> WriteNewPassword strm fixField
    | UserStatus fixField -> WriteUserStatus strm fixField
    | UserStatusText fixField -> WriteUserStatusText strm fixField
    | StatusValue fixField -> WriteStatusValue strm fixField
    | StatusText fixField -> WriteStatusText strm fixField
    | RefCompID fixField -> WriteRefCompID strm fixField
    | RefSubID fixField -> WriteRefSubID strm fixField
    | NetworkResponseID fixField -> WriteNetworkResponseID strm fixField
    | NetworkRequestID fixField -> WriteNetworkRequestID strm fixField
    | LastNetworkResponseID fixField -> WriteLastNetworkResponseID strm fixField
    | NetworkRequestType fixField -> WriteNetworkRequestType strm fixField
    | NoCompIDs fixField -> WriteNoCompIDs strm fixField
    | NetworkStatusResponseType fixField -> WriteNetworkStatusResponseType strm fixField
    | NoCollInquiryQualifier fixField -> WriteNoCollInquiryQualifier strm fixField
    | TrdRptStatus fixField -> WriteTrdRptStatus strm fixField
    | AffirmStatus fixField -> WriteAffirmStatus strm fixField
    | UnderlyingStrikeCurrency fixField -> WriteUnderlyingStrikeCurrency strm fixField
    | LegStrikeCurrency fixField -> WriteLegStrikeCurrency strm fixField
    | TimeBracket fixField -> WriteTimeBracket strm fixField
    | CollAction fixField -> WriteCollAction strm fixField
    | CollInquiryStatus fixField -> WriteCollInquiryStatus strm fixField
    | CollInquiryResult fixField -> WriteCollInquiryResult strm fixField
    | StrikeCurrency fixField -> WriteStrikeCurrency strm fixField
    | NoNested3PartyIDs fixField -> WriteNoNested3PartyIDs strm fixField
    | Nested3PartyID fixField -> WriteNested3PartyID strm fixField
    | Nested3PartyIDSource fixField -> WriteNested3PartyIDSource strm fixField
    | Nested3PartyRole fixField -> WriteNested3PartyRole strm fixField
    | NoNested3PartySubIDs fixField -> WriteNoNested3PartySubIDs strm fixField
    | Nested3PartySubID fixField -> WriteNested3PartySubID strm fixField
    | Nested3PartySubIDType fixField -> WriteNested3PartySubIDType strm fixField
    | LegContractSettlMonth fixField -> WriteLegContractSettlMonth strm fixField
    | LegInterestAccrualDate fixField -> WriteLegInterestAccrualDate strm fixField


// todo consider replacing ReadFields match statement with lookup in a map
let ReadField (strm:Stream) =
    let ss = CrapReadUntilDelim strm // todo: replace with something efficient
    let subStrs = ss.Split([|'='|])
    let tag = subStrs.[0]
    let raw = subStrs.[1]
    let fld =    
        match tag with
        | "1" -> ReadAccount raw |> FIXField.Account
        | "2" -> ReadAdvId raw |> FIXField.AdvId
        | "3" -> ReadAdvRefID raw |> FIXField.AdvRefID
        | "4" -> ReadAdvSide raw |> FIXField.AdvSide
        | "5" -> ReadAdvTransType raw |> FIXField.AdvTransType
        | "6" -> ReadAvgPx raw |> FIXField.AvgPx
        | "7" -> ReadBeginSeqNo raw |> FIXField.BeginSeqNo
        | "8" -> ReadBeginString raw |> FIXField.BeginString
        | "9" -> ReadBodyLength raw |> FIXField.BodyLength
        | "10" -> ReadCheckSum raw |> FIXField.CheckSum
        | "11" -> ReadClOrdID raw |> FIXField.ClOrdID
        | "12" -> ReadCommission raw |> FIXField.Commission
        | "13" -> ReadCommType raw |> FIXField.CommType
        | "14" -> ReadCumQty raw |> FIXField.CumQty
        | "15" -> ReadCurrency raw |> FIXField.Currency
        | "16" -> ReadEndSeqNo raw |> FIXField.EndSeqNo
        | "17" -> ReadExecID raw |> FIXField.ExecID
        | "18" -> ReadExecInst raw |> FIXField.ExecInst
        | "19" -> ReadExecRefID raw |> FIXField.ExecRefID
        | "21" -> ReadHandlInst raw |> FIXField.HandlInst
        | "22" -> ReadSecurityIDSource raw |> FIXField.SecurityIDSource
        | "23" -> ReadIOIid raw |> FIXField.IOIid
        | "25" -> ReadIOIQltyInd raw |> FIXField.IOIQltyInd
        | "26" -> ReadIOIRefID raw |> FIXField.IOIRefID
        | "27" -> ReadIOIQty raw |> FIXField.IOIQty
        | "28" -> ReadIOITransType raw |> FIXField.IOITransType
        | "29" -> ReadLastCapacity raw |> FIXField.LastCapacity
        | "30" -> ReadLastMkt raw |> FIXField.LastMkt
        | "31" -> ReadLastPx raw |> FIXField.LastPx
        | "32" -> ReadLastQty raw |> FIXField.LastQty
        | "33" -> ReadLinesOfText raw |> FIXField.LinesOfText
        | "34" -> ReadMsgSeqNum raw |> FIXField.MsgSeqNum
        | "35" -> ReadMsgType raw |> FIXField.MsgType
        | "36" -> ReadNewSeqNo raw |> FIXField.NewSeqNo
        | "37" -> ReadOrderID raw |> FIXField.OrderID
        | "38" -> ReadOrderQty raw |> FIXField.OrderQty
        | "39" -> ReadOrdStatus raw |> FIXField.OrdStatus
        | "40" -> ReadOrdType raw |> FIXField.OrdType
        | "41" -> ReadOrigClOrdID raw |> FIXField.OrigClOrdID
        | "42" -> ReadOrigTime raw |> FIXField.OrigTime
        | "43" -> ReadPossDupFlag raw |> FIXField.PossDupFlag
        | "44" -> ReadPrice raw |> FIXField.Price
        | "45" -> ReadRefSeqNum raw |> FIXField.RefSeqNum
        | "48" -> ReadSecurityID raw |> FIXField.SecurityID
        | "49" -> ReadSenderCompID raw |> FIXField.SenderCompID
        | "50" -> ReadSenderSubID raw |> FIXField.SenderSubID
        | "52" -> ReadSendingTime raw |> FIXField.SendingTime
        | "53" -> ReadQuantity raw |> FIXField.Quantity
        | "54" -> ReadSide raw |> FIXField.Side
        | "55" -> ReadSymbol raw |> FIXField.Symbol
        | "56" -> ReadTargetCompID raw |> FIXField.TargetCompID
        | "57" -> ReadTargetSubID raw |> FIXField.TargetSubID
        | "58" -> ReadText raw |> FIXField.Text
        | "59" -> ReadTimeInForce raw |> FIXField.TimeInForce
        | "60" -> ReadTransactTime raw |> FIXField.TransactTime
        | "61" -> ReadUrgency raw |> FIXField.Urgency
        | "62" -> ReadValidUntilTime raw |> FIXField.ValidUntilTime
        | "63" -> ReadSettlType raw |> FIXField.SettlType
        | "64" -> ReadSettlDate raw |> FIXField.SettlDate
        | "65" -> ReadSymbolSfx raw |> FIXField.SymbolSfx
        | "66" -> ReadListID raw |> FIXField.ListID
        | "67" -> ReadListSeqNo raw |> FIXField.ListSeqNo
        | "68" -> ReadTotNoOrders raw |> FIXField.TotNoOrders
        | "69" -> ReadListExecInst raw |> FIXField.ListExecInst
        | "70" -> ReadAllocID raw |> FIXField.AllocID
        | "71" -> ReadAllocTransType raw |> FIXField.AllocTransType
        | "72" -> ReadRefAllocID raw |> FIXField.RefAllocID
        | "73" -> ReadNoOrders raw |> FIXField.NoOrders
        | "74" -> ReadAvgPxPrecision raw |> FIXField.AvgPxPrecision
        | "75" -> ReadTradeDate raw |> FIXField.TradeDate
        | "77" -> ReadPositionEffect raw |> FIXField.PositionEffect
        | "78" -> ReadNoAllocs raw |> FIXField.NoAllocs
        | "79" -> ReadAllocAccount raw |> FIXField.AllocAccount
        | "80" -> ReadAllocQty raw |> FIXField.AllocQty
        | "81" -> ReadProcessCode raw |> FIXField.ProcessCode
        | "82" -> ReadNoRpts raw |> FIXField.NoRpts
        | "83" -> ReadRptSeq raw |> FIXField.RptSeq
        | "84" -> ReadCxlQty raw |> FIXField.CxlQty
        | "85" -> ReadNoDlvyInst raw |> FIXField.NoDlvyInst
        | "87" -> ReadAllocStatus raw |> FIXField.AllocStatus
        | "88" -> ReadAllocRejCode raw |> FIXField.AllocRejCode
        | "89" -> ReadSignature raw |> FIXField.Signature
        | "90" -> ReadSecureData raw strm|> FIXField.SecureData // len->string compound field
        | "93" -> ReadSignatureLength raw |> FIXField.SignatureLength
        | "94" -> ReadEmailType raw |> FIXField.EmailType
        | "95" -> ReadRawDataLength raw |> FIXField.RawDataLength
        | "96" -> ReadRawData raw |> FIXField.RawData
        | "97" -> ReadPossResend raw |> FIXField.PossResend
        | "98" -> ReadEncryptMethod raw |> FIXField.EncryptMethod
        | "99" -> ReadStopPx raw |> FIXField.StopPx
        | "100" -> ReadExDestination raw |> FIXField.ExDestination
        | "102" -> ReadCxlRejReason raw |> FIXField.CxlRejReason
        | "103" -> ReadOrdRejReason raw |> FIXField.OrdRejReason
        | "104" -> ReadIOIQualifier raw |> FIXField.IOIQualifier
        | "105" -> ReadWaveNo raw |> FIXField.WaveNo
        | "106" -> ReadIssuer raw |> FIXField.Issuer
        | "107" -> ReadSecurityDesc raw |> FIXField.SecurityDesc
        | "108" -> ReadHeartBtInt raw |> FIXField.HeartBtInt
        | "110" -> ReadMinQty raw |> FIXField.MinQty
        | "111" -> ReadMaxFloor raw |> FIXField.MaxFloor
        | "112" -> ReadTestReqID raw |> FIXField.TestReqID
        | "113" -> ReadReportToExch raw |> FIXField.ReportToExch
        | "114" -> ReadLocateReqd raw |> FIXField.LocateReqd
        | "115" -> ReadOnBehalfOfCompID raw |> FIXField.OnBehalfOfCompID
        | "116" -> ReadOnBehalfOfSubID raw |> FIXField.OnBehalfOfSubID
        | "117" -> ReadQuoteID raw |> FIXField.QuoteID
        | "118" -> ReadNetMoney raw |> FIXField.NetMoney
        | "119" -> ReadSettlCurrAmt raw |> FIXField.SettlCurrAmt
        | "120" -> ReadSettlCurrency raw |> FIXField.SettlCurrency
        | "121" -> ReadForexReq raw |> FIXField.ForexReq
        | "122" -> ReadOrigSendingTime raw |> FIXField.OrigSendingTime
        | "123" -> ReadGapFillFlag raw |> FIXField.GapFillFlag
        | "124" -> ReadNoExecs raw |> FIXField.NoExecs
        | "126" -> ReadExpireTime raw |> FIXField.ExpireTime
        | "127" -> ReadDKReason raw |> FIXField.DKReason
        | "128" -> ReadDeliverToCompID raw |> FIXField.DeliverToCompID
        | "129" -> ReadDeliverToSubID raw |> FIXField.DeliverToSubID
        | "130" -> ReadIOINaturalFlag raw |> FIXField.IOINaturalFlag
        | "131" -> ReadQuoteReqID raw |> FIXField.QuoteReqID
        | "132" -> ReadBidPx raw |> FIXField.BidPx
        | "133" -> ReadOfferPx raw |> FIXField.OfferPx
        | "134" -> ReadBidSize raw |> FIXField.BidSize
        | "135" -> ReadOfferSize raw |> FIXField.OfferSize
        | "136" -> ReadNoMiscFees raw |> FIXField.NoMiscFees
        | "137" -> ReadMiscFeeAmt raw |> FIXField.MiscFeeAmt
        | "138" -> ReadMiscFeeCurr raw |> FIXField.MiscFeeCurr
        | "139" -> ReadMiscFeeType raw |> FIXField.MiscFeeType
        | "140" -> ReadPrevClosePx raw |> FIXField.PrevClosePx
        | "141" -> ReadResetSeqNumFlag raw |> FIXField.ResetSeqNumFlag
        | "142" -> ReadSenderLocationID raw |> FIXField.SenderLocationID
        | "143" -> ReadTargetLocationID raw |> FIXField.TargetLocationID
        | "144" -> ReadOnBehalfOfLocationID raw |> FIXField.OnBehalfOfLocationID
        | "145" -> ReadDeliverToLocationID raw |> FIXField.DeliverToLocationID
        | "146" -> ReadNoRelatedSym raw |> FIXField.NoRelatedSym
        | "147" -> ReadSubject raw |> FIXField.Subject
        | "148" -> ReadHeadline raw |> FIXField.Headline
        | "149" -> ReadURLLink raw |> FIXField.URLLink
        | "150" -> ReadExecType raw |> FIXField.ExecType
        | "151" -> ReadLeavesQty raw |> FIXField.LeavesQty
        | "152" -> ReadCashOrderQty raw |> FIXField.CashOrderQty
        | "153" -> ReadAllocAvgPx raw |> FIXField.AllocAvgPx
        | "154" -> ReadAllocNetMoney raw |> FIXField.AllocNetMoney
        | "155" -> ReadSettlCurrFxRate raw |> FIXField.SettlCurrFxRate
        | "156" -> ReadSettlCurrFxRateCalc raw |> FIXField.SettlCurrFxRateCalc
        | "157" -> ReadNumDaysInterest raw |> FIXField.NumDaysInterest
        | "158" -> ReadAccruedInterestRate raw |> FIXField.AccruedInterestRate
        | "159" -> ReadAccruedInterestAmt raw |> FIXField.AccruedInterestAmt
        | "160" -> ReadSettlInstMode raw |> FIXField.SettlInstMode
        | "161" -> ReadAllocText raw |> FIXField.AllocText
        | "162" -> ReadSettlInstID raw |> FIXField.SettlInstID
        | "163" -> ReadSettlInstTransType raw |> FIXField.SettlInstTransType
        | "164" -> ReadEmailThreadID raw |> FIXField.EmailThreadID
        | "165" -> ReadSettlInstSource raw |> FIXField.SettlInstSource
        | "167" -> ReadSecurityType raw |> FIXField.SecurityType
        | "168" -> ReadEffectiveTime raw |> FIXField.EffectiveTime
        | "169" -> ReadStandInstDbType raw |> FIXField.StandInstDbType
        | "170" -> ReadStandInstDbName raw |> FIXField.StandInstDbName
        | "171" -> ReadStandInstDbID raw |> FIXField.StandInstDbID
        | "172" -> ReadSettlDeliveryType raw |> FIXField.SettlDeliveryType
        | "188" -> ReadBidSpotRate raw |> FIXField.BidSpotRate
        | "189" -> ReadBidForwardPoints raw |> FIXField.BidForwardPoints
        | "190" -> ReadOfferSpotRate raw |> FIXField.OfferSpotRate
        | "191" -> ReadOfferForwardPoints raw |> FIXField.OfferForwardPoints
        | "192" -> ReadOrderQty2 raw |> FIXField.OrderQty2
        | "193" -> ReadSettlDate2 raw |> FIXField.SettlDate2
        | "194" -> ReadLastSpotRate raw |> FIXField.LastSpotRate
        | "195" -> ReadLastForwardPoints raw |> FIXField.LastForwardPoints
        | "196" -> ReadAllocLinkID raw |> FIXField.AllocLinkID
        | "197" -> ReadAllocLinkType raw |> FIXField.AllocLinkType
        | "198" -> ReadSecondaryOrderID raw |> FIXField.SecondaryOrderID
        | "199" -> ReadNoIOIQualifiers raw |> FIXField.NoIOIQualifiers
        | "200" -> ReadMaturityMonthYear raw |> FIXField.MaturityMonthYear
        | "201" -> ReadPutOrCall raw |> FIXField.PutOrCall
        | "202" -> ReadStrikePrice raw |> FIXField.StrikePrice
        | "203" -> ReadCoveredOrUncovered raw |> FIXField.CoveredOrUncovered
        | "206" -> ReadOptAttribute raw |> FIXField.OptAttribute
        | "207" -> ReadSecurityExchange raw |> FIXField.SecurityExchange
        | "208" -> ReadNotifyBrokerOfCredit raw |> FIXField.NotifyBrokerOfCredit
        | "209" -> ReadAllocHandlInst raw |> FIXField.AllocHandlInst
        | "210" -> ReadMaxShow raw |> FIXField.MaxShow
        | "211" -> ReadPegOffsetValue raw |> FIXField.PegOffsetValue
        | "212" -> ReadXmlData raw strm|> FIXField.XmlData // len->string compound field
        | "214" -> ReadSettlInstRefID raw |> FIXField.SettlInstRefID
        | "215" -> ReadNoRoutingIDs raw |> FIXField.NoRoutingIDs
        | "216" -> ReadRoutingType raw |> FIXField.RoutingType
        | "217" -> ReadRoutingID raw |> FIXField.RoutingID
        | "218" -> ReadSpread raw |> FIXField.Spread
        | "220" -> ReadBenchmarkCurveCurrency raw |> FIXField.BenchmarkCurveCurrency
        | "221" -> ReadBenchmarkCurveName raw |> FIXField.BenchmarkCurveName
        | "222" -> ReadBenchmarkCurvePoint raw |> FIXField.BenchmarkCurvePoint
        | "223" -> ReadCouponRate raw |> FIXField.CouponRate
        | "224" -> ReadCouponPaymentDate raw |> FIXField.CouponPaymentDate
        | "225" -> ReadIssueDate raw |> FIXField.IssueDate
        | "226" -> ReadRepurchaseTerm raw |> FIXField.RepurchaseTerm
        | "227" -> ReadRepurchaseRate raw |> FIXField.RepurchaseRate
        | "228" -> ReadFactor raw |> FIXField.Factor
        | "229" -> ReadTradeOriginationDate raw |> FIXField.TradeOriginationDate
        | "230" -> ReadExDate raw |> FIXField.ExDate
        | "231" -> ReadContractMultiplier raw |> FIXField.ContractMultiplier
        | "232" -> ReadNoStipulations raw |> FIXField.NoStipulations
        | "233" -> ReadStipulationType raw |> FIXField.StipulationType
        | "234" -> ReadStipulationValue raw |> FIXField.StipulationValue
        | "235" -> ReadYieldType raw |> FIXField.YieldType
        | "236" -> ReadYield raw |> FIXField.Yield
        | "237" -> ReadTotalTakedown raw |> FIXField.TotalTakedown
        | "238" -> ReadConcession raw |> FIXField.Concession
        | "239" -> ReadRepoCollateralSecurityType raw |> FIXField.RepoCollateralSecurityType
        | "240" -> ReadRedemptionDate raw |> FIXField.RedemptionDate
        | "241" -> ReadUnderlyingCouponPaymentDate raw |> FIXField.UnderlyingCouponPaymentDate
        | "242" -> ReadUnderlyingIssueDate raw |> FIXField.UnderlyingIssueDate
        | "243" -> ReadUnderlyingRepoCollateralSecurityType raw |> FIXField.UnderlyingRepoCollateralSecurityType
        | "244" -> ReadUnderlyingRepurchaseTerm raw |> FIXField.UnderlyingRepurchaseTerm
        | "245" -> ReadUnderlyingRepurchaseRate raw |> FIXField.UnderlyingRepurchaseRate
        | "246" -> ReadUnderlyingFactor raw |> FIXField.UnderlyingFactor
        | "247" -> ReadUnderlyingRedemptionDate raw |> FIXField.UnderlyingRedemptionDate
        | "248" -> ReadLegCouponPaymentDate raw |> FIXField.LegCouponPaymentDate
        | "249" -> ReadLegIssueDate raw |> FIXField.LegIssueDate
        | "250" -> ReadLegRepoCollateralSecurityType raw |> FIXField.LegRepoCollateralSecurityType
        | "251" -> ReadLegRepurchaseTerm raw |> FIXField.LegRepurchaseTerm
        | "252" -> ReadLegRepurchaseRate raw |> FIXField.LegRepurchaseRate
        | "253" -> ReadLegFactor raw |> FIXField.LegFactor
        | "254" -> ReadLegRedemptionDate raw |> FIXField.LegRedemptionDate
        | "255" -> ReadCreditRating raw |> FIXField.CreditRating
        | "256" -> ReadUnderlyingCreditRating raw |> FIXField.UnderlyingCreditRating
        | "257" -> ReadLegCreditRating raw |> FIXField.LegCreditRating
        | "258" -> ReadTradedFlatSwitch raw |> FIXField.TradedFlatSwitch
        | "259" -> ReadBasisFeatureDate raw |> FIXField.BasisFeatureDate
        | "260" -> ReadBasisFeaturePrice raw |> FIXField.BasisFeaturePrice
        | "262" -> ReadMDReqID raw |> FIXField.MDReqID
        | "263" -> ReadSubscriptionRequestType raw |> FIXField.SubscriptionRequestType
        | "264" -> ReadMarketDepth raw |> FIXField.MarketDepth
        | "265" -> ReadMDUpdateType raw |> FIXField.MDUpdateType
        | "266" -> ReadAggregatedBook raw |> FIXField.AggregatedBook
        | "267" -> ReadNoMDEntryTypes raw |> FIXField.NoMDEntryTypes
        | "268" -> ReadNoMDEntries raw |> FIXField.NoMDEntries
        | "269" -> ReadMDEntryType raw |> FIXField.MDEntryType
        | "270" -> ReadMDEntryPx raw |> FIXField.MDEntryPx
        | "271" -> ReadMDEntrySize raw |> FIXField.MDEntrySize
        | "272" -> ReadMDEntryDate raw |> FIXField.MDEntryDate
        | "273" -> ReadMDEntryTime raw |> FIXField.MDEntryTime
        | "274" -> ReadTickDirection raw |> FIXField.TickDirection
        | "275" -> ReadMDMkt raw |> FIXField.MDMkt
        | "276" -> ReadQuoteCondition raw |> FIXField.QuoteCondition
        | "277" -> ReadTradeCondition raw |> FIXField.TradeCondition
        | "278" -> ReadMDEntryID raw |> FIXField.MDEntryID
        | "279" -> ReadMDUpdateAction raw |> FIXField.MDUpdateAction
        | "280" -> ReadMDEntryRefID raw |> FIXField.MDEntryRefID
        | "281" -> ReadMDReqRejReason raw |> FIXField.MDReqRejReason
        | "282" -> ReadMDEntryOriginator raw |> FIXField.MDEntryOriginator
        | "283" -> ReadLocationID raw |> FIXField.LocationID
        | "284" -> ReadDeskID raw |> FIXField.DeskID
        | "285" -> ReadDeleteReason raw |> FIXField.DeleteReason
        | "286" -> ReadOpenCloseSettlFlag raw |> FIXField.OpenCloseSettlFlag
        | "287" -> ReadSellerDays raw |> FIXField.SellerDays
        | "288" -> ReadMDEntryBuyer raw |> FIXField.MDEntryBuyer
        | "289" -> ReadMDEntrySeller raw |> FIXField.MDEntrySeller
        | "290" -> ReadMDEntryPositionNo raw |> FIXField.MDEntryPositionNo
        | "291" -> ReadFinancialStatus raw |> FIXField.FinancialStatus
        | "292" -> ReadCorporateAction raw |> FIXField.CorporateAction
        | "293" -> ReadDefBidSize raw |> FIXField.DefBidSize
        | "294" -> ReadDefOfferSize raw |> FIXField.DefOfferSize
        | "295" -> ReadNoQuoteEntries raw |> FIXField.NoQuoteEntries
        | "296" -> ReadNoQuoteSets raw |> FIXField.NoQuoteSets
        | "297" -> ReadQuoteStatus raw |> FIXField.QuoteStatus
        | "298" -> ReadQuoteCancelType raw |> FIXField.QuoteCancelType
        | "299" -> ReadQuoteEntryID raw |> FIXField.QuoteEntryID
        | "300" -> ReadQuoteRejectReason raw |> FIXField.QuoteRejectReason
        | "301" -> ReadQuoteResponseLevel raw |> FIXField.QuoteResponseLevel
        | "302" -> ReadQuoteSetID raw |> FIXField.QuoteSetID
        | "303" -> ReadQuoteRequestType raw |> FIXField.QuoteRequestType
        | "304" -> ReadTotNoQuoteEntries raw |> FIXField.TotNoQuoteEntries
        | "305" -> ReadUnderlyingSecurityIDSource raw |> FIXField.UnderlyingSecurityIDSource
        | "306" -> ReadUnderlyingIssuer raw |> FIXField.UnderlyingIssuer
        | "307" -> ReadUnderlyingSecurityDesc raw |> FIXField.UnderlyingSecurityDesc
        | "308" -> ReadUnderlyingSecurityExchange raw |> FIXField.UnderlyingSecurityExchange
        | "309" -> ReadUnderlyingSecurityID raw |> FIXField.UnderlyingSecurityID
        | "310" -> ReadUnderlyingSecurityType raw |> FIXField.UnderlyingSecurityType
        | "311" -> ReadUnderlyingSymbol raw |> FIXField.UnderlyingSymbol
        | "312" -> ReadUnderlyingSymbolSfx raw |> FIXField.UnderlyingSymbolSfx
        | "313" -> ReadUnderlyingMaturityMonthYear raw |> FIXField.UnderlyingMaturityMonthYear
        | "315" -> ReadUnderlyingPutOrCall raw |> FIXField.UnderlyingPutOrCall
        | "316" -> ReadUnderlyingStrikePrice raw |> FIXField.UnderlyingStrikePrice
        | "317" -> ReadUnderlyingOptAttribute raw |> FIXField.UnderlyingOptAttribute
        | "318" -> ReadUnderlyingCurrency raw |> FIXField.UnderlyingCurrency
        | "320" -> ReadSecurityReqID raw |> FIXField.SecurityReqID
        | "321" -> ReadSecurityRequestType raw |> FIXField.SecurityRequestType
        | "322" -> ReadSecurityResponseID raw |> FIXField.SecurityResponseID
        | "323" -> ReadSecurityResponseType raw |> FIXField.SecurityResponseType
        | "324" -> ReadSecurityStatusReqID raw |> FIXField.SecurityStatusReqID
        | "325" -> ReadUnsolicitedIndicator raw |> FIXField.UnsolicitedIndicator
        | "326" -> ReadSecurityTradingStatus raw |> FIXField.SecurityTradingStatus
        | "327" -> ReadHaltReason raw |> FIXField.HaltReason
        | "328" -> ReadInViewOfCommon raw |> FIXField.InViewOfCommon
        | "329" -> ReadDueToRelated raw |> FIXField.DueToRelated
        | "330" -> ReadBuyVolume raw |> FIXField.BuyVolume
        | "331" -> ReadSellVolume raw |> FIXField.SellVolume
        | "332" -> ReadHighPx raw |> FIXField.HighPx
        | "333" -> ReadLowPx raw |> FIXField.LowPx
        | "334" -> ReadAdjustment raw |> FIXField.Adjustment
        | "335" -> ReadTradSesReqID raw |> FIXField.TradSesReqID
        | "336" -> ReadTradingSessionID raw |> FIXField.TradingSessionID
        | "337" -> ReadContraTrader raw |> FIXField.ContraTrader
        | "338" -> ReadTradSesMethod raw |> FIXField.TradSesMethod
        | "339" -> ReadTradSesMode raw |> FIXField.TradSesMode
        | "340" -> ReadTradSesStatus raw |> FIXField.TradSesStatus
        | "341" -> ReadTradSesStartTime raw |> FIXField.TradSesStartTime
        | "342" -> ReadTradSesOpenTime raw |> FIXField.TradSesOpenTime
        | "343" -> ReadTradSesPreCloseTime raw |> FIXField.TradSesPreCloseTime
        | "344" -> ReadTradSesCloseTime raw |> FIXField.TradSesCloseTime
        | "345" -> ReadTradSesEndTime raw |> FIXField.TradSesEndTime
        | "346" -> ReadNumberOfOrders raw |> FIXField.NumberOfOrders
        | "347" -> ReadMessageEncoding raw |> FIXField.MessageEncoding
        | "348" -> ReadEncodedIssuer raw strm|> FIXField.EncodedIssuer // len->string compound field
        | "350" -> ReadEncodedSecurityDesc raw strm|> FIXField.EncodedSecurityDesc // len->string compound field
        | "352" -> ReadEncodedListExecInst raw strm|> FIXField.EncodedListExecInst // len->string compound field
        | "354" -> ReadEncodedText raw strm|> FIXField.EncodedText // len->string compound field
        | "356" -> ReadEncodedSubject raw strm|> FIXField.EncodedSubject // len->string compound field
        | "358" -> ReadEncodedHeadline raw strm|> FIXField.EncodedHeadline // len->string compound field
        | "360" -> ReadEncodedAllocText raw strm|> FIXField.EncodedAllocText // len->string compound field
        | "362" -> ReadEncodedUnderlyingIssuer raw strm|> FIXField.EncodedUnderlyingIssuer // len->string compound field
        | "364" -> ReadEncodedUnderlyingSecurityDesc raw strm|> FIXField.EncodedUnderlyingSecurityDesc // len->string compound field
        | "366" -> ReadAllocPrice raw |> FIXField.AllocPrice
        | "367" -> ReadQuoteSetValidUntilTime raw |> FIXField.QuoteSetValidUntilTime
        | "368" -> ReadQuoteEntryRejectReason raw |> FIXField.QuoteEntryRejectReason
        | "369" -> ReadLastMsgSeqNumProcessed raw |> FIXField.LastMsgSeqNumProcessed
        | "371" -> ReadRefTagID raw |> FIXField.RefTagID
        | "372" -> ReadRefMsgType raw |> FIXField.RefMsgType
        | "373" -> ReadSessionRejectReason raw |> FIXField.SessionRejectReason
        | "374" -> ReadBidRequestTransType raw |> FIXField.BidRequestTransType
        | "375" -> ReadContraBroker raw |> FIXField.ContraBroker
        | "376" -> ReadComplianceID raw |> FIXField.ComplianceID
        | "377" -> ReadSolicitedFlag raw |> FIXField.SolicitedFlag
        | "378" -> ReadExecRestatementReason raw |> FIXField.ExecRestatementReason
        | "379" -> ReadBusinessRejectRefID raw |> FIXField.BusinessRejectRefID
        | "380" -> ReadBusinessRejectReason raw |> FIXField.BusinessRejectReason
        | "381" -> ReadGrossTradeAmt raw |> FIXField.GrossTradeAmt
        | "382" -> ReadNoContraBrokers raw |> FIXField.NoContraBrokers
        | "383" -> ReadMaxMessageSize raw |> FIXField.MaxMessageSize
        | "384" -> ReadNoMsgTypes raw |> FIXField.NoMsgTypes
        | "385" -> ReadMsgDirection raw |> FIXField.MsgDirection
        | "386" -> ReadNoTradingSessions raw |> FIXField.NoTradingSessions
        | "387" -> ReadTotalVolumeTraded raw |> FIXField.TotalVolumeTraded
        | "388" -> ReadDiscretionInst raw |> FIXField.DiscretionInst
        | "389" -> ReadDiscretionOffsetValue raw |> FIXField.DiscretionOffsetValue
        | "390" -> ReadBidID raw |> FIXField.BidID
        | "391" -> ReadClientBidID raw |> FIXField.ClientBidID
        | "392" -> ReadListName raw |> FIXField.ListName
        | "393" -> ReadTotNoRelatedSym raw |> FIXField.TotNoRelatedSym
        | "394" -> ReadBidType raw |> FIXField.BidType
        | "395" -> ReadNumTickets raw |> FIXField.NumTickets
        | "396" -> ReadSideValue1 raw |> FIXField.SideValue1
        | "397" -> ReadSideValue2 raw |> FIXField.SideValue2
        | "398" -> ReadNoBidDescriptors raw |> FIXField.NoBidDescriptors
        | "399" -> ReadBidDescriptorType raw |> FIXField.BidDescriptorType
        | "400" -> ReadBidDescriptor raw |> FIXField.BidDescriptor
        | "401" -> ReadSideValueInd raw |> FIXField.SideValueInd
        | "402" -> ReadLiquidityPctLow raw |> FIXField.LiquidityPctLow
        | "403" -> ReadLiquidityPctHigh raw |> FIXField.LiquidityPctHigh
        | "404" -> ReadLiquidityValue raw |> FIXField.LiquidityValue
        | "405" -> ReadEFPTrackingError raw |> FIXField.EFPTrackingError
        | "406" -> ReadFairValue raw |> FIXField.FairValue
        | "407" -> ReadOutsideIndexPct raw |> FIXField.OutsideIndexPct
        | "408" -> ReadValueOfFutures raw |> FIXField.ValueOfFutures
        | "409" -> ReadLiquidityIndType raw |> FIXField.LiquidityIndType
        | "410" -> ReadWtAverageLiquidity raw |> FIXField.WtAverageLiquidity
        | "411" -> ReadExchangeForPhysical raw |> FIXField.ExchangeForPhysical
        | "412" -> ReadOutMainCntryUIndex raw |> FIXField.OutMainCntryUIndex
        | "413" -> ReadCrossPercent raw |> FIXField.CrossPercent
        | "414" -> ReadProgRptReqs raw |> FIXField.ProgRptReqs
        | "415" -> ReadProgPeriodInterval raw |> FIXField.ProgPeriodInterval
        | "416" -> ReadIncTaxInd raw |> FIXField.IncTaxInd
        | "417" -> ReadNumBidders raw |> FIXField.NumBidders
        | "418" -> ReadBidTradeType raw |> FIXField.BidTradeType
        | "419" -> ReadBasisPxType raw |> FIXField.BasisPxType
        | "420" -> ReadNoBidComponents raw |> FIXField.NoBidComponents
        | "421" -> ReadCountry raw |> FIXField.Country
        | "422" -> ReadTotNoStrikes raw |> FIXField.TotNoStrikes
        | "423" -> ReadPriceType raw |> FIXField.PriceType
        | "424" -> ReadDayOrderQty raw |> FIXField.DayOrderQty
        | "425" -> ReadDayCumQty raw |> FIXField.DayCumQty
        | "426" -> ReadDayAvgPx raw |> FIXField.DayAvgPx
        | "427" -> ReadGTBookingInst raw |> FIXField.GTBookingInst
        | "428" -> ReadNoStrikes raw |> FIXField.NoStrikes
        | "429" -> ReadListStatusType raw |> FIXField.ListStatusType
        | "430" -> ReadNetGrossInd raw |> FIXField.NetGrossInd
        | "431" -> ReadListOrderStatus raw |> FIXField.ListOrderStatus
        | "432" -> ReadExpireDate raw |> FIXField.ExpireDate
        | "433" -> ReadListExecInstType raw |> FIXField.ListExecInstType
        | "434" -> ReadCxlRejResponseTo raw |> FIXField.CxlRejResponseTo
        | "435" -> ReadUnderlyingCouponRate raw |> FIXField.UnderlyingCouponRate
        | "436" -> ReadUnderlyingContractMultiplier raw |> FIXField.UnderlyingContractMultiplier
        | "437" -> ReadContraTradeQty raw |> FIXField.ContraTradeQty
        | "438" -> ReadContraTradeTime raw |> FIXField.ContraTradeTime
        | "441" -> ReadLiquidityNumSecurities raw |> FIXField.LiquidityNumSecurities
        | "442" -> ReadMultiLegReportingType raw |> FIXField.MultiLegReportingType
        | "443" -> ReadStrikeTime raw |> FIXField.StrikeTime
        | "444" -> ReadListStatusText raw |> FIXField.ListStatusText
        | "445" -> ReadEncodedListStatusText raw strm|> FIXField.EncodedListStatusText // len->string compound field
        | "447" -> ReadPartyIDSource raw |> FIXField.PartyIDSource
        | "448" -> ReadPartyID raw |> FIXField.PartyID
        | "451" -> ReadNetChgPrevDay raw |> FIXField.NetChgPrevDay
        | "452" -> ReadPartyRole raw |> FIXField.PartyRole
        | "453" -> ReadNoPartyIDs raw |> FIXField.NoPartyIDs
        | "454" -> ReadNoSecurityAltID raw |> FIXField.NoSecurityAltID
        | "455" -> ReadSecurityAltID raw |> FIXField.SecurityAltID
        | "456" -> ReadSecurityAltIDSource raw |> FIXField.SecurityAltIDSource
        | "457" -> ReadNoUnderlyingSecurityAltID raw |> FIXField.NoUnderlyingSecurityAltID
        | "458" -> ReadUnderlyingSecurityAltID raw |> FIXField.UnderlyingSecurityAltID
        | "459" -> ReadUnderlyingSecurityAltIDSource raw |> FIXField.UnderlyingSecurityAltIDSource
        | "460" -> ReadProduct raw |> FIXField.Product
        | "461" -> ReadCFICode raw |> FIXField.CFICode
        | "462" -> ReadUnderlyingProduct raw |> FIXField.UnderlyingProduct
        | "463" -> ReadUnderlyingCFICode raw |> FIXField.UnderlyingCFICode
        | "464" -> ReadTestMessageIndicator raw |> FIXField.TestMessageIndicator
        | "465" -> ReadQuantityType raw |> FIXField.QuantityType
        | "466" -> ReadBookingRefID raw |> FIXField.BookingRefID
        | "467" -> ReadIndividualAllocID raw |> FIXField.IndividualAllocID
        | "468" -> ReadRoundingDirection raw |> FIXField.RoundingDirection
        | "469" -> ReadRoundingModulus raw |> FIXField.RoundingModulus
        | "470" -> ReadCountryOfIssue raw |> FIXField.CountryOfIssue
        | "471" -> ReadStateOrProvinceOfIssue raw |> FIXField.StateOrProvinceOfIssue
        | "472" -> ReadLocaleOfIssue raw |> FIXField.LocaleOfIssue
        | "473" -> ReadNoRegistDtls raw |> FIXField.NoRegistDtls
        | "474" -> ReadMailingDtls raw |> FIXField.MailingDtls
        | "475" -> ReadInvestorCountryOfResidence raw |> FIXField.InvestorCountryOfResidence
        | "476" -> ReadPaymentRef raw |> FIXField.PaymentRef
        | "477" -> ReadDistribPaymentMethod raw |> FIXField.DistribPaymentMethod
        | "478" -> ReadCashDistribCurr raw |> FIXField.CashDistribCurr
        | "479" -> ReadCommCurrency raw |> FIXField.CommCurrency
        | "480" -> ReadCancellationRights raw |> FIXField.CancellationRights
        | "481" -> ReadMoneyLaunderingStatus raw |> FIXField.MoneyLaunderingStatus
        | "482" -> ReadMailingInst raw |> FIXField.MailingInst
        | "483" -> ReadTransBkdTime raw |> FIXField.TransBkdTime
        | "484" -> ReadExecPriceType raw |> FIXField.ExecPriceType
        | "485" -> ReadExecPriceAdjustment raw |> FIXField.ExecPriceAdjustment
        | "486" -> ReadDateOfBirth raw |> FIXField.DateOfBirth
        | "487" -> ReadTradeReportTransType raw |> FIXField.TradeReportTransType
        | "488" -> ReadCardHolderName raw |> FIXField.CardHolderName
        | "489" -> ReadCardNumber raw |> FIXField.CardNumber
        | "490" -> ReadCardExpDate raw |> FIXField.CardExpDate
        | "491" -> ReadCardIssNum raw |> FIXField.CardIssNum
        | "492" -> ReadPaymentMethod raw |> FIXField.PaymentMethod
        | "493" -> ReadRegistAcctType raw |> FIXField.RegistAcctType
        | "494" -> ReadDesignation raw |> FIXField.Designation
        | "495" -> ReadTaxAdvantageType raw |> FIXField.TaxAdvantageType
        | "496" -> ReadRegistRejReasonText raw |> FIXField.RegistRejReasonText
        | "497" -> ReadFundRenewWaiv raw |> FIXField.FundRenewWaiv
        | "498" -> ReadCashDistribAgentName raw |> FIXField.CashDistribAgentName
        | "499" -> ReadCashDistribAgentCode raw |> FIXField.CashDistribAgentCode
        | "500" -> ReadCashDistribAgentAcctNumber raw |> FIXField.CashDistribAgentAcctNumber
        | "501" -> ReadCashDistribPayRef raw |> FIXField.CashDistribPayRef
        | "502" -> ReadCashDistribAgentAcctName raw |> FIXField.CashDistribAgentAcctName
        | "503" -> ReadCardStartDate raw |> FIXField.CardStartDate
        | "504" -> ReadPaymentDate raw |> FIXField.PaymentDate
        | "505" -> ReadPaymentRemitterID raw |> FIXField.PaymentRemitterID
        | "506" -> ReadRegistStatus raw |> FIXField.RegistStatus
        | "507" -> ReadRegistRejReasonCode raw |> FIXField.RegistRejReasonCode
        | "508" -> ReadRegistRefID raw |> FIXField.RegistRefID
        | "509" -> ReadRegistDtls raw |> FIXField.RegistDtls
        | "510" -> ReadNoDistribInsts raw |> FIXField.NoDistribInsts
        | "511" -> ReadRegistEmail raw |> FIXField.RegistEmail
        | "512" -> ReadDistribPercentage raw |> FIXField.DistribPercentage
        | "513" -> ReadRegistID raw |> FIXField.RegistID
        | "514" -> ReadRegistTransType raw |> FIXField.RegistTransType
        | "515" -> ReadExecValuationPoint raw |> FIXField.ExecValuationPoint
        | "516" -> ReadOrderPercent raw |> FIXField.OrderPercent
        | "517" -> ReadOwnershipType raw |> FIXField.OwnershipType
        | "518" -> ReadNoContAmts raw |> FIXField.NoContAmts
        | "519" -> ReadContAmtType raw |> FIXField.ContAmtType
        | "520" -> ReadContAmtValue raw |> FIXField.ContAmtValue
        | "521" -> ReadContAmtCurr raw |> FIXField.ContAmtCurr
        | "522" -> ReadOwnerType raw |> FIXField.OwnerType
        | "523" -> ReadPartySubID raw |> FIXField.PartySubID
        | "524" -> ReadNestedPartyID raw |> FIXField.NestedPartyID
        | "525" -> ReadNestedPartyIDSource raw |> FIXField.NestedPartyIDSource
        | "526" -> ReadSecondaryClOrdID raw |> FIXField.SecondaryClOrdID
        | "527" -> ReadSecondaryExecID raw |> FIXField.SecondaryExecID
        | "528" -> ReadOrderCapacity raw |> FIXField.OrderCapacity
        | "529" -> ReadOrderRestrictions raw |> FIXField.OrderRestrictions
        | "530" -> ReadMassCancelRequestType raw |> FIXField.MassCancelRequestType
        | "531" -> ReadMassCancelResponse raw |> FIXField.MassCancelResponse
        | "532" -> ReadMassCancelRejectReason raw |> FIXField.MassCancelRejectReason
        | "533" -> ReadTotalAffectedOrders raw |> FIXField.TotalAffectedOrders
        | "534" -> ReadNoAffectedOrders raw |> FIXField.NoAffectedOrders
        | "535" -> ReadAffectedOrderID raw |> FIXField.AffectedOrderID
        | "536" -> ReadAffectedSecondaryOrderID raw |> FIXField.AffectedSecondaryOrderID
        | "537" -> ReadQuoteType raw |> FIXField.QuoteType
        | "538" -> ReadNestedPartyRole raw |> FIXField.NestedPartyRole
        | "539" -> ReadNoNestedPartyIDs raw |> FIXField.NoNestedPartyIDs
        | "540" -> ReadTotalAccruedInterestAmt raw |> FIXField.TotalAccruedInterestAmt
        | "541" -> ReadMaturityDate raw |> FIXField.MaturityDate
        | "542" -> ReadUnderlyingMaturityDate raw |> FIXField.UnderlyingMaturityDate
        | "543" -> ReadInstrRegistry raw |> FIXField.InstrRegistry
        | "544" -> ReadCashMargin raw |> FIXField.CashMargin
        | "545" -> ReadNestedPartySubID raw |> FIXField.NestedPartySubID
        | "546" -> ReadScope raw |> FIXField.Scope
        | "547" -> ReadMDImplicitDelete raw |> FIXField.MDImplicitDelete
        | "548" -> ReadCrossID raw |> FIXField.CrossID
        | "549" -> ReadCrossType raw |> FIXField.CrossType
        | "550" -> ReadCrossPrioritization raw |> FIXField.CrossPrioritization
        | "551" -> ReadOrigCrossID raw |> FIXField.OrigCrossID
        | "552" -> ReadNoSides raw |> FIXField.NoSides
        | "553" -> ReadUsername raw |> FIXField.Username
        | "554" -> ReadPassword raw |> FIXField.Password
        | "555" -> ReadNoLegs raw |> FIXField.NoLegs
        | "556" -> ReadLegCurrency raw |> FIXField.LegCurrency
        | "557" -> ReadTotNoSecurityTypes raw |> FIXField.TotNoSecurityTypes
        | "558" -> ReadNoSecurityTypes raw |> FIXField.NoSecurityTypes
        | "559" -> ReadSecurityListRequestType raw |> FIXField.SecurityListRequestType
        | "560" -> ReadSecurityRequestResult raw |> FIXField.SecurityRequestResult
        | "561" -> ReadRoundLot raw |> FIXField.RoundLot
        | "562" -> ReadMinTradeVol raw |> FIXField.MinTradeVol
        | "563" -> ReadMultiLegRptTypeReq raw |> FIXField.MultiLegRptTypeReq
        | "564" -> ReadLegPositionEffect raw |> FIXField.LegPositionEffect
        | "565" -> ReadLegCoveredOrUncovered raw |> FIXField.LegCoveredOrUncovered
        | "566" -> ReadLegPrice raw |> FIXField.LegPrice
        | "567" -> ReadTradSesStatusRejReason raw |> FIXField.TradSesStatusRejReason
        | "568" -> ReadTradeRequestID raw |> FIXField.TradeRequestID
        | "569" -> ReadTradeRequestType raw |> FIXField.TradeRequestType
        | "570" -> ReadPreviouslyReported raw |> FIXField.PreviouslyReported
        | "571" -> ReadTradeReportID raw |> FIXField.TradeReportID
        | "572" -> ReadTradeReportRefID raw |> FIXField.TradeReportRefID
        | "573" -> ReadMatchStatus raw |> FIXField.MatchStatus
        | "574" -> ReadMatchType raw |> FIXField.MatchType
        | "575" -> ReadOddLot raw |> FIXField.OddLot
        | "576" -> ReadNoClearingInstructions raw |> FIXField.NoClearingInstructions
        | "577" -> ReadClearingInstruction raw |> FIXField.ClearingInstruction
        | "578" -> ReadTradeInputSource raw |> FIXField.TradeInputSource
        | "579" -> ReadTradeInputDevice raw |> FIXField.TradeInputDevice
        | "580" -> ReadNoDates raw |> FIXField.NoDates
        | "581" -> ReadAccountType raw |> FIXField.AccountType
        | "582" -> ReadCustOrderCapacity raw |> FIXField.CustOrderCapacity
        | "583" -> ReadClOrdLinkID raw |> FIXField.ClOrdLinkID
        | "584" -> ReadMassStatusReqID raw |> FIXField.MassStatusReqID
        | "585" -> ReadMassStatusReqType raw |> FIXField.MassStatusReqType
        | "586" -> ReadOrigOrdModTime raw |> FIXField.OrigOrdModTime
        | "587" -> ReadLegSettlType raw |> FIXField.LegSettlType
        | "588" -> ReadLegSettlDate raw |> FIXField.LegSettlDate
        | "589" -> ReadDayBookingInst raw |> FIXField.DayBookingInst
        | "590" -> ReadBookingUnit raw |> FIXField.BookingUnit
        | "591" -> ReadPreallocMethod raw |> FIXField.PreallocMethod
        | "592" -> ReadUnderlyingCountryOfIssue raw |> FIXField.UnderlyingCountryOfIssue
        | "593" -> ReadUnderlyingStateOrProvinceOfIssue raw |> FIXField.UnderlyingStateOrProvinceOfIssue
        | "594" -> ReadUnderlyingLocaleOfIssue raw |> FIXField.UnderlyingLocaleOfIssue
        | "595" -> ReadUnderlyingInstrRegistry raw |> FIXField.UnderlyingInstrRegistry
        | "596" -> ReadLegCountryOfIssue raw |> FIXField.LegCountryOfIssue
        | "597" -> ReadLegStateOrProvinceOfIssue raw |> FIXField.LegStateOrProvinceOfIssue
        | "598" -> ReadLegLocaleOfIssue raw |> FIXField.LegLocaleOfIssue
        | "599" -> ReadLegInstrRegistry raw |> FIXField.LegInstrRegistry
        | "600" -> ReadLegSymbol raw |> FIXField.LegSymbol
        | "601" -> ReadLegSymbolSfx raw |> FIXField.LegSymbolSfx
        | "602" -> ReadLegSecurityID raw |> FIXField.LegSecurityID
        | "603" -> ReadLegSecurityIDSource raw |> FIXField.LegSecurityIDSource
        | "604" -> ReadNoLegSecurityAltID raw |> FIXField.NoLegSecurityAltID
        | "605" -> ReadLegSecurityAltID raw |> FIXField.LegSecurityAltID
        | "606" -> ReadLegSecurityAltIDSource raw |> FIXField.LegSecurityAltIDSource
        | "607" -> ReadLegProduct raw |> FIXField.LegProduct
        | "608" -> ReadLegCFICode raw |> FIXField.LegCFICode
        | "609" -> ReadLegSecurityType raw |> FIXField.LegSecurityType
        | "610" -> ReadLegMaturityMonthYear raw |> FIXField.LegMaturityMonthYear
        | "611" -> ReadLegMaturityDate raw |> FIXField.LegMaturityDate
        | "612" -> ReadLegStrikePrice raw |> FIXField.LegStrikePrice
        | "613" -> ReadLegOptAttribute raw |> FIXField.LegOptAttribute
        | "614" -> ReadLegContractMultiplier raw |> FIXField.LegContractMultiplier
        | "615" -> ReadLegCouponRate raw |> FIXField.LegCouponRate
        | "616" -> ReadLegSecurityExchange raw |> FIXField.LegSecurityExchange
        | "617" -> ReadLegIssuer raw |> FIXField.LegIssuer
        | "618" -> ReadEncodedLegIssuer raw strm|> FIXField.EncodedLegIssuer // len->string compound field
        | "620" -> ReadLegSecurityDesc raw |> FIXField.LegSecurityDesc
        | "621" -> ReadEncodedLegSecurityDesc raw strm|> FIXField.EncodedLegSecurityDesc // len->string compound field
        | "623" -> ReadLegRatioQty raw |> FIXField.LegRatioQty
        | "624" -> ReadLegSide raw |> FIXField.LegSide
        | "625" -> ReadTradingSessionSubID raw |> FIXField.TradingSessionSubID
        | "626" -> ReadAllocType raw |> FIXField.AllocType
        | "627" -> ReadNoHops raw |> FIXField.NoHops
        | "628" -> ReadHopCompID raw |> FIXField.HopCompID
        | "629" -> ReadHopSendingTime raw |> FIXField.HopSendingTime
        | "630" -> ReadHopRefID raw |> FIXField.HopRefID
        | "631" -> ReadMidPx raw |> FIXField.MidPx
        | "632" -> ReadBidYield raw |> FIXField.BidYield
        | "633" -> ReadMidYield raw |> FIXField.MidYield
        | "634" -> ReadOfferYield raw |> FIXField.OfferYield
        | "635" -> ReadClearingFeeIndicator raw |> FIXField.ClearingFeeIndicator
        | "636" -> ReadWorkingIndicator raw |> FIXField.WorkingIndicator
        | "637" -> ReadLegLastPx raw |> FIXField.LegLastPx
        | "638" -> ReadPriorityIndicator raw |> FIXField.PriorityIndicator
        | "639" -> ReadPriceImprovement raw |> FIXField.PriceImprovement
        | "640" -> ReadPrice2 raw |> FIXField.Price2
        | "641" -> ReadLastForwardPoints2 raw |> FIXField.LastForwardPoints2
        | "642" -> ReadBidForwardPoints2 raw |> FIXField.BidForwardPoints2
        | "643" -> ReadOfferForwardPoints2 raw |> FIXField.OfferForwardPoints2
        | "644" -> ReadRFQReqID raw |> FIXField.RFQReqID
        | "645" -> ReadMktBidPx raw |> FIXField.MktBidPx
        | "646" -> ReadMktOfferPx raw |> FIXField.MktOfferPx
        | "647" -> ReadMinBidSize raw |> FIXField.MinBidSize
        | "648" -> ReadMinOfferSize raw |> FIXField.MinOfferSize
        | "649" -> ReadQuoteStatusReqID raw |> FIXField.QuoteStatusReqID
        | "650" -> ReadLegalConfirm raw |> FIXField.LegalConfirm
        | "651" -> ReadUnderlyingLastPx raw |> FIXField.UnderlyingLastPx
        | "652" -> ReadUnderlyingLastQty raw |> FIXField.UnderlyingLastQty
        | "654" -> ReadLegRefID raw |> FIXField.LegRefID
        | "655" -> ReadContraLegRefID raw |> FIXField.ContraLegRefID
        | "656" -> ReadSettlCurrBidFxRate raw |> FIXField.SettlCurrBidFxRate
        | "657" -> ReadSettlCurrOfferFxRate raw |> FIXField.SettlCurrOfferFxRate
        | "658" -> ReadQuoteRequestRejectReason raw |> FIXField.QuoteRequestRejectReason
        | "659" -> ReadSideComplianceID raw |> FIXField.SideComplianceID
        | "660" -> ReadAcctIDSource raw |> FIXField.AcctIDSource
        | "661" -> ReadAllocAcctIDSource raw |> FIXField.AllocAcctIDSource
        | "662" -> ReadBenchmarkPrice raw |> FIXField.BenchmarkPrice
        | "663" -> ReadBenchmarkPriceType raw |> FIXField.BenchmarkPriceType
        | "664" -> ReadConfirmID raw |> FIXField.ConfirmID
        | "665" -> ReadConfirmStatus raw |> FIXField.ConfirmStatus
        | "666" -> ReadConfirmTransType raw |> FIXField.ConfirmTransType
        | "667" -> ReadContractSettlMonth raw |> FIXField.ContractSettlMonth
        | "668" -> ReadDeliveryForm raw |> FIXField.DeliveryForm
        | "669" -> ReadLastParPx raw |> FIXField.LastParPx
        | "670" -> ReadNoLegAllocs raw |> FIXField.NoLegAllocs
        | "671" -> ReadLegAllocAccount raw |> FIXField.LegAllocAccount
        | "672" -> ReadLegIndividualAllocID raw |> FIXField.LegIndividualAllocID
        | "673" -> ReadLegAllocQty raw |> FIXField.LegAllocQty
        | "674" -> ReadLegAllocAcctIDSource raw |> FIXField.LegAllocAcctIDSource
        | "675" -> ReadLegSettlCurrency raw |> FIXField.LegSettlCurrency
        | "676" -> ReadLegBenchmarkCurveCurrency raw |> FIXField.LegBenchmarkCurveCurrency
        | "677" -> ReadLegBenchmarkCurveName raw |> FIXField.LegBenchmarkCurveName
        | "678" -> ReadLegBenchmarkCurvePoint raw |> FIXField.LegBenchmarkCurvePoint
        | "679" -> ReadLegBenchmarkPrice raw |> FIXField.LegBenchmarkPrice
        | "680" -> ReadLegBenchmarkPriceType raw |> FIXField.LegBenchmarkPriceType
        | "681" -> ReadLegBidPx raw |> FIXField.LegBidPx
        | "682" -> ReadLegIOIQty raw |> FIXField.LegIOIQty
        | "683" -> ReadNoLegStipulations raw |> FIXField.NoLegStipulations
        | "684" -> ReadLegOfferPx raw |> FIXField.LegOfferPx
        | "685" -> ReadLegOrderQty raw |> FIXField.LegOrderQty
        | "686" -> ReadLegPriceType raw |> FIXField.LegPriceType
        | "687" -> ReadLegQty raw |> FIXField.LegQty
        | "688" -> ReadLegStipulationType raw |> FIXField.LegStipulationType
        | "689" -> ReadLegStipulationValue raw |> FIXField.LegStipulationValue
        | "690" -> ReadLegSwapType raw |> FIXField.LegSwapType
        | "691" -> ReadPool raw |> FIXField.Pool
        | "692" -> ReadQuotePriceType raw |> FIXField.QuotePriceType
        | "693" -> ReadQuoteRespID raw |> FIXField.QuoteRespID
        | "694" -> ReadQuoteRespType raw |> FIXField.QuoteRespType
        | "695" -> ReadQuoteQualifier raw |> FIXField.QuoteQualifier
        | "696" -> ReadYieldRedemptionDate raw |> FIXField.YieldRedemptionDate
        | "697" -> ReadYieldRedemptionPrice raw |> FIXField.YieldRedemptionPrice
        | "698" -> ReadYieldRedemptionPriceType raw |> FIXField.YieldRedemptionPriceType
        | "699" -> ReadBenchmarkSecurityID raw |> FIXField.BenchmarkSecurityID
        | "700" -> ReadReversalIndicator raw |> FIXField.ReversalIndicator
        | "701" -> ReadYieldCalcDate raw |> FIXField.YieldCalcDate
        | "702" -> ReadNoPositions raw |> FIXField.NoPositions
        | "703" -> ReadPosType raw |> FIXField.PosType
        | "704" -> ReadLongQty raw |> FIXField.LongQty
        | "705" -> ReadShortQty raw |> FIXField.ShortQty
        | "706" -> ReadPosQtyStatus raw |> FIXField.PosQtyStatus
        | "707" -> ReadPosAmtType raw |> FIXField.PosAmtType
        | "708" -> ReadPosAmt raw |> FIXField.PosAmt
        | "709" -> ReadPosTransType raw |> FIXField.PosTransType
        | "710" -> ReadPosReqID raw |> FIXField.PosReqID
        | "711" -> ReadNoUnderlyings raw |> FIXField.NoUnderlyings
        | "712" -> ReadPosMaintAction raw |> FIXField.PosMaintAction
        | "713" -> ReadOrigPosReqRefID raw |> FIXField.OrigPosReqRefID
        | "714" -> ReadPosMaintRptRefID raw |> FIXField.PosMaintRptRefID
        | "715" -> ReadClearingBusinessDate raw |> FIXField.ClearingBusinessDate
        | "716" -> ReadSettlSessID raw |> FIXField.SettlSessID
        | "717" -> ReadSettlSessSubID raw |> FIXField.SettlSessSubID
        | "718" -> ReadAdjustmentType raw |> FIXField.AdjustmentType
        | "719" -> ReadContraryInstructionIndicator raw |> FIXField.ContraryInstructionIndicator
        | "720" -> ReadPriorSpreadIndicator raw |> FIXField.PriorSpreadIndicator
        | "721" -> ReadPosMaintRptID raw |> FIXField.PosMaintRptID
        | "722" -> ReadPosMaintStatus raw |> FIXField.PosMaintStatus
        | "723" -> ReadPosMaintResult raw |> FIXField.PosMaintResult
        | "724" -> ReadPosReqType raw |> FIXField.PosReqType
        | "725" -> ReadResponseTransportType raw |> FIXField.ResponseTransportType
        | "726" -> ReadResponseDestination raw |> FIXField.ResponseDestination
        | "727" -> ReadTotalNumPosReports raw |> FIXField.TotalNumPosReports
        | "728" -> ReadPosReqResult raw |> FIXField.PosReqResult
        | "729" -> ReadPosReqStatus raw |> FIXField.PosReqStatus
        | "730" -> ReadSettlPrice raw |> FIXField.SettlPrice
        | "731" -> ReadSettlPriceType raw |> FIXField.SettlPriceType
        | "732" -> ReadUnderlyingSettlPrice raw |> FIXField.UnderlyingSettlPrice
        | "733" -> ReadUnderlyingSettlPriceType raw |> FIXField.UnderlyingSettlPriceType
        | "734" -> ReadPriorSettlPrice raw |> FIXField.PriorSettlPrice
        | "735" -> ReadNoQuoteQualifiers raw |> FIXField.NoQuoteQualifiers
        | "736" -> ReadAllocSettlCurrency raw |> FIXField.AllocSettlCurrency
        | "737" -> ReadAllocSettlCurrAmt raw |> FIXField.AllocSettlCurrAmt
        | "738" -> ReadInterestAtMaturity raw |> FIXField.InterestAtMaturity
        | "739" -> ReadLegDatedDate raw |> FIXField.LegDatedDate
        | "740" -> ReadLegPool raw |> FIXField.LegPool
        | "741" -> ReadAllocInterestAtMaturity raw |> FIXField.AllocInterestAtMaturity
        | "742" -> ReadAllocAccruedInterestAmt raw |> FIXField.AllocAccruedInterestAmt
        | "743" -> ReadDeliveryDate raw |> FIXField.DeliveryDate
        | "744" -> ReadAssignmentMethod raw |> FIXField.AssignmentMethod
        | "745" -> ReadAssignmentUnit raw |> FIXField.AssignmentUnit
        | "746" -> ReadOpenInterest raw |> FIXField.OpenInterest
        | "747" -> ReadExerciseMethod raw |> FIXField.ExerciseMethod
        | "748" -> ReadTotNumTradeReports raw |> FIXField.TotNumTradeReports
        | "749" -> ReadTradeRequestResult raw |> FIXField.TradeRequestResult
        | "750" -> ReadTradeRequestStatus raw |> FIXField.TradeRequestStatus
        | "751" -> ReadTradeReportRejectReason raw |> FIXField.TradeReportRejectReason
        | "752" -> ReadSideMultiLegReportingType raw |> FIXField.SideMultiLegReportingType
        | "753" -> ReadNoPosAmt raw |> FIXField.NoPosAmt
        | "754" -> ReadAutoAcceptIndicator raw |> FIXField.AutoAcceptIndicator
        | "755" -> ReadAllocReportID raw |> FIXField.AllocReportID
        | "756" -> ReadNoNested2PartyIDs raw |> FIXField.NoNested2PartyIDs
        | "757" -> ReadNested2PartyID raw |> FIXField.Nested2PartyID
        | "758" -> ReadNested2PartyIDSource raw |> FIXField.Nested2PartyIDSource
        | "759" -> ReadNested2PartyRole raw |> FIXField.Nested2PartyRole
        | "760" -> ReadNested2PartySubID raw |> FIXField.Nested2PartySubID
        | "761" -> ReadBenchmarkSecurityIDSource raw |> FIXField.BenchmarkSecurityIDSource
        | "762" -> ReadSecuritySubType raw |> FIXField.SecuritySubType
        | "763" -> ReadUnderlyingSecuritySubType raw |> FIXField.UnderlyingSecuritySubType
        | "764" -> ReadLegSecuritySubType raw |> FIXField.LegSecuritySubType
        | "765" -> ReadAllowableOneSidednessPct raw |> FIXField.AllowableOneSidednessPct
        | "766" -> ReadAllowableOneSidednessValue raw |> FIXField.AllowableOneSidednessValue
        | "767" -> ReadAllowableOneSidednessCurr raw |> FIXField.AllowableOneSidednessCurr
        | "768" -> ReadNoTrdRegTimestamps raw |> FIXField.NoTrdRegTimestamps
        | "769" -> ReadTrdRegTimestamp raw |> FIXField.TrdRegTimestamp
        | "770" -> ReadTrdRegTimestampType raw |> FIXField.TrdRegTimestampType
        | "771" -> ReadTrdRegTimestampOrigin raw |> FIXField.TrdRegTimestampOrigin
        | "772" -> ReadConfirmRefID raw |> FIXField.ConfirmRefID
        | "773" -> ReadConfirmType raw |> FIXField.ConfirmType
        | "774" -> ReadConfirmRejReason raw |> FIXField.ConfirmRejReason
        | "775" -> ReadBookingType raw |> FIXField.BookingType
        | "776" -> ReadIndividualAllocRejCode raw |> FIXField.IndividualAllocRejCode
        | "777" -> ReadSettlInstMsgID raw |> FIXField.SettlInstMsgID
        | "778" -> ReadNoSettlInst raw |> FIXField.NoSettlInst
        | "779" -> ReadLastUpdateTime raw |> FIXField.LastUpdateTime
        | "780" -> ReadAllocSettlInstType raw |> FIXField.AllocSettlInstType
        | "781" -> ReadNoSettlPartyIDs raw |> FIXField.NoSettlPartyIDs
        | "782" -> ReadSettlPartyID raw |> FIXField.SettlPartyID
        | "783" -> ReadSettlPartyIDSource raw |> FIXField.SettlPartyIDSource
        | "784" -> ReadSettlPartyRole raw |> FIXField.SettlPartyRole
        | "785" -> ReadSettlPartySubID raw |> FIXField.SettlPartySubID
        | "786" -> ReadSettlPartySubIDType raw |> FIXField.SettlPartySubIDType
        | "787" -> ReadDlvyInstType raw |> FIXField.DlvyInstType
        | "788" -> ReadTerminationType raw |> FIXField.TerminationType
        | "789" -> ReadNextExpectedMsgSeqNum raw |> FIXField.NextExpectedMsgSeqNum
        | "790" -> ReadOrdStatusReqID raw |> FIXField.OrdStatusReqID
        | "791" -> ReadSettlInstReqID raw |> FIXField.SettlInstReqID
        | "792" -> ReadSettlInstReqRejCode raw |> FIXField.SettlInstReqRejCode
        | "793" -> ReadSecondaryAllocID raw |> FIXField.SecondaryAllocID
        | "794" -> ReadAllocReportType raw |> FIXField.AllocReportType
        | "795" -> ReadAllocReportRefID raw |> FIXField.AllocReportRefID
        | "796" -> ReadAllocCancReplaceReason raw |> FIXField.AllocCancReplaceReason
        | "797" -> ReadCopyMsgIndicator raw |> FIXField.CopyMsgIndicator
        | "798" -> ReadAllocAccountType raw |> FIXField.AllocAccountType
        | "799" -> ReadOrderAvgPx raw |> FIXField.OrderAvgPx
        | "800" -> ReadOrderBookingQty raw |> FIXField.OrderBookingQty
        | "801" -> ReadNoSettlPartySubIDs raw |> FIXField.NoSettlPartySubIDs
        | "802" -> ReadNoPartySubIDs raw |> FIXField.NoPartySubIDs
        | "803" -> ReadPartySubIDType raw |> FIXField.PartySubIDType
        | "804" -> ReadNoNestedPartySubIDs raw |> FIXField.NoNestedPartySubIDs
        | "805" -> ReadNestedPartySubIDType raw |> FIXField.NestedPartySubIDType
        | "806" -> ReadNoNested2PartySubIDs raw |> FIXField.NoNested2PartySubIDs
        | "807" -> ReadNested2PartySubIDType raw |> FIXField.Nested2PartySubIDType
        | "808" -> ReadAllocIntermedReqType raw |> FIXField.AllocIntermedReqType
        | "810" -> ReadUnderlyingPx raw |> FIXField.UnderlyingPx
        | "811" -> ReadPriceDelta raw |> FIXField.PriceDelta
        | "812" -> ReadApplQueueMax raw |> FIXField.ApplQueueMax
        | "813" -> ReadApplQueueDepth raw |> FIXField.ApplQueueDepth
        | "814" -> ReadApplQueueResolution raw |> FIXField.ApplQueueResolution
        | "815" -> ReadApplQueueAction raw |> FIXField.ApplQueueAction
        | "816" -> ReadNoAltMDSource raw |> FIXField.NoAltMDSource
        | "817" -> ReadAltMDSourceID raw |> FIXField.AltMDSourceID
        | "818" -> ReadSecondaryTradeReportID raw |> FIXField.SecondaryTradeReportID
        | "819" -> ReadAvgPxIndicator raw |> FIXField.AvgPxIndicator
        | "820" -> ReadTradeLinkID raw |> FIXField.TradeLinkID
        | "821" -> ReadOrderInputDevice raw |> FIXField.OrderInputDevice
        | "822" -> ReadUnderlyingTradingSessionID raw |> FIXField.UnderlyingTradingSessionID
        | "823" -> ReadUnderlyingTradingSessionSubID raw |> FIXField.UnderlyingTradingSessionSubID
        | "824" -> ReadTradeLegRefID raw |> FIXField.TradeLegRefID
        | "825" -> ReadExchangeRule raw |> FIXField.ExchangeRule
        | "826" -> ReadTradeAllocIndicator raw |> FIXField.TradeAllocIndicator
        | "827" -> ReadExpirationCycle raw |> FIXField.ExpirationCycle
        | "828" -> ReadTrdType raw |> FIXField.TrdType
        | "829" -> ReadTrdSubType raw |> FIXField.TrdSubType
        | "830" -> ReadTransferReason raw |> FIXField.TransferReason
        | "831" -> ReadAsgnReqID raw |> FIXField.AsgnReqID
        | "832" -> ReadTotNumAssignmentReports raw |> FIXField.TotNumAssignmentReports
        | "833" -> ReadAsgnRptID raw |> FIXField.AsgnRptID
        | "834" -> ReadThresholdAmount raw |> FIXField.ThresholdAmount
        | "835" -> ReadPegMoveType raw |> FIXField.PegMoveType
        | "836" -> ReadPegOffsetType raw |> FIXField.PegOffsetType
        | "837" -> ReadPegLimitType raw |> FIXField.PegLimitType
        | "838" -> ReadPegRoundDirection raw |> FIXField.PegRoundDirection
        | "839" -> ReadPeggedPrice raw |> FIXField.PeggedPrice
        | "840" -> ReadPegScope raw |> FIXField.PegScope
        | "841" -> ReadDiscretionMoveType raw |> FIXField.DiscretionMoveType
        | "842" -> ReadDiscretionOffsetType raw |> FIXField.DiscretionOffsetType
        | "843" -> ReadDiscretionLimitType raw |> FIXField.DiscretionLimitType
        | "844" -> ReadDiscretionRoundDirection raw |> FIXField.DiscretionRoundDirection
        | "845" -> ReadDiscretionPrice raw |> FIXField.DiscretionPrice
        | "846" -> ReadDiscretionScope raw |> FIXField.DiscretionScope
        | "847" -> ReadTargetStrategy raw |> FIXField.TargetStrategy
        | "848" -> ReadTargetStrategyParameters raw |> FIXField.TargetStrategyParameters
        | "849" -> ReadParticipationRate raw |> FIXField.ParticipationRate
        | "850" -> ReadTargetStrategyPerformance raw |> FIXField.TargetStrategyPerformance
        | "851" -> ReadLastLiquidityInd raw |> FIXField.LastLiquidityInd
        | "852" -> ReadPublishTrdIndicator raw |> FIXField.PublishTrdIndicator
        | "853" -> ReadShortSaleReason raw |> FIXField.ShortSaleReason
        | "854" -> ReadQtyType raw |> FIXField.QtyType
        | "855" -> ReadSecondaryTrdType raw |> FIXField.SecondaryTrdType
        | "856" -> ReadTradeReportType raw |> FIXField.TradeReportType
        | "857" -> ReadAllocNoOrdersType raw |> FIXField.AllocNoOrdersType
        | "858" -> ReadSharedCommission raw |> FIXField.SharedCommission
        | "859" -> ReadConfirmReqID raw |> FIXField.ConfirmReqID
        | "860" -> ReadAvgParPx raw |> FIXField.AvgParPx
        | "861" -> ReadReportedPx raw |> FIXField.ReportedPx
        | "862" -> ReadNoCapacities raw |> FIXField.NoCapacities
        | "863" -> ReadOrderCapacityQty raw |> FIXField.OrderCapacityQty
        | "864" -> ReadNoEvents raw |> FIXField.NoEvents
        | "865" -> ReadEventType raw |> FIXField.EventType
        | "866" -> ReadEventDate raw |> FIXField.EventDate
        | "867" -> ReadEventPx raw |> FIXField.EventPx
        | "868" -> ReadEventText raw |> FIXField.EventText
        | "869" -> ReadPctAtRisk raw |> FIXField.PctAtRisk
        | "870" -> ReadNoInstrAttrib raw |> FIXField.NoInstrAttrib
        | "871" -> ReadInstrAttribType raw |> FIXField.InstrAttribType
        | "872" -> ReadInstrAttribValue raw |> FIXField.InstrAttribValue
        | "873" -> ReadDatedDate raw |> FIXField.DatedDate
        | "874" -> ReadInterestAccrualDate raw |> FIXField.InterestAccrualDate
        | "875" -> ReadCPProgram raw |> FIXField.CPProgram
        | "876" -> ReadCPRegType raw |> FIXField.CPRegType
        | "877" -> ReadUnderlyingCPProgram raw |> FIXField.UnderlyingCPProgram
        | "878" -> ReadUnderlyingCPRegType raw |> FIXField.UnderlyingCPRegType
        | "879" -> ReadUnderlyingQty raw |> FIXField.UnderlyingQty
        | "880" -> ReadTrdMatchID raw |> FIXField.TrdMatchID
        | "881" -> ReadSecondaryTradeReportRefID raw |> FIXField.SecondaryTradeReportRefID
        | "882" -> ReadUnderlyingDirtyPrice raw |> FIXField.UnderlyingDirtyPrice
        | "883" -> ReadUnderlyingEndPrice raw |> FIXField.UnderlyingEndPrice
        | "884" -> ReadUnderlyingStartValue raw |> FIXField.UnderlyingStartValue
        | "885" -> ReadUnderlyingCurrentValue raw |> FIXField.UnderlyingCurrentValue
        | "886" -> ReadUnderlyingEndValue raw |> FIXField.UnderlyingEndValue
        | "887" -> ReadNoUnderlyingStips raw |> FIXField.NoUnderlyingStips
        | "888" -> ReadUnderlyingStipType raw |> FIXField.UnderlyingStipType
        | "889" -> ReadUnderlyingStipValue raw |> FIXField.UnderlyingStipValue
        | "890" -> ReadMaturityNetMoney raw |> FIXField.MaturityNetMoney
        | "891" -> ReadMiscFeeBasis raw |> FIXField.MiscFeeBasis
        | "892" -> ReadTotNoAllocs raw |> FIXField.TotNoAllocs
        | "893" -> ReadLastFragment raw |> FIXField.LastFragment
        | "894" -> ReadCollReqID raw |> FIXField.CollReqID
        | "895" -> ReadCollAsgnReason raw |> FIXField.CollAsgnReason
        | "896" -> ReadCollInquiryQualifier raw |> FIXField.CollInquiryQualifier
        | "897" -> ReadNoTrades raw |> FIXField.NoTrades
        | "898" -> ReadMarginRatio raw |> FIXField.MarginRatio
        | "899" -> ReadMarginExcess raw |> FIXField.MarginExcess
        | "900" -> ReadTotalNetValue raw |> FIXField.TotalNetValue
        | "901" -> ReadCashOutstanding raw |> FIXField.CashOutstanding
        | "902" -> ReadCollAsgnID raw |> FIXField.CollAsgnID
        | "903" -> ReadCollAsgnTransType raw |> FIXField.CollAsgnTransType
        | "904" -> ReadCollRespID raw |> FIXField.CollRespID
        | "905" -> ReadCollAsgnRespType raw |> FIXField.CollAsgnRespType
        | "906" -> ReadCollAsgnRejectReason raw |> FIXField.CollAsgnRejectReason
        | "907" -> ReadCollAsgnRefID raw |> FIXField.CollAsgnRefID
        | "908" -> ReadCollRptID raw |> FIXField.CollRptID
        | "909" -> ReadCollInquiryID raw |> FIXField.CollInquiryID
        | "910" -> ReadCollStatus raw |> FIXField.CollStatus
        | "911" -> ReadTotNumReports raw |> FIXField.TotNumReports
        | "912" -> ReadLastRptRequested raw |> FIXField.LastRptRequested
        | "913" -> ReadAgreementDesc raw |> FIXField.AgreementDesc
        | "914" -> ReadAgreementID raw |> FIXField.AgreementID
        | "915" -> ReadAgreementDate raw |> FIXField.AgreementDate
        | "916" -> ReadStartDate raw |> FIXField.StartDate
        | "917" -> ReadEndDate raw |> FIXField.EndDate
        | "918" -> ReadAgreementCurrency raw |> FIXField.AgreementCurrency
        | "919" -> ReadDeliveryType raw |> FIXField.DeliveryType
        | "920" -> ReadEndAccruedInterestAmt raw |> FIXField.EndAccruedInterestAmt
        | "921" -> ReadStartCash raw |> FIXField.StartCash
        | "922" -> ReadEndCash raw |> FIXField.EndCash
        | "923" -> ReadUserRequestID raw |> FIXField.UserRequestID
        | "924" -> ReadUserRequestType raw |> FIXField.UserRequestType
        | "925" -> ReadNewPassword raw |> FIXField.NewPassword
        | "926" -> ReadUserStatus raw |> FIXField.UserStatus
        | "927" -> ReadUserStatusText raw |> FIXField.UserStatusText
        | "928" -> ReadStatusValue raw |> FIXField.StatusValue
        | "929" -> ReadStatusText raw |> FIXField.StatusText
        | "930" -> ReadRefCompID raw |> FIXField.RefCompID
        | "931" -> ReadRefSubID raw |> FIXField.RefSubID
        | "932" -> ReadNetworkResponseID raw |> FIXField.NetworkResponseID
        | "933" -> ReadNetworkRequestID raw |> FIXField.NetworkRequestID
        | "934" -> ReadLastNetworkResponseID raw |> FIXField.LastNetworkResponseID
        | "935" -> ReadNetworkRequestType raw |> FIXField.NetworkRequestType
        | "936" -> ReadNoCompIDs raw |> FIXField.NoCompIDs
        | "937" -> ReadNetworkStatusResponseType raw |> FIXField.NetworkStatusResponseType
        | "938" -> ReadNoCollInquiryQualifier raw |> FIXField.NoCollInquiryQualifier
        | "939" -> ReadTrdRptStatus raw |> FIXField.TrdRptStatus
        | "940" -> ReadAffirmStatus raw |> FIXField.AffirmStatus
        | "941" -> ReadUnderlyingStrikeCurrency raw |> FIXField.UnderlyingStrikeCurrency
        | "942" -> ReadLegStrikeCurrency raw |> FIXField.LegStrikeCurrency
        | "943" -> ReadTimeBracket raw |> FIXField.TimeBracket
        | "944" -> ReadCollAction raw |> FIXField.CollAction
        | "945" -> ReadCollInquiryStatus raw |> FIXField.CollInquiryStatus
        | "946" -> ReadCollInquiryResult raw |> FIXField.CollInquiryResult
        | "947" -> ReadStrikeCurrency raw |> FIXField.StrikeCurrency
        | "948" -> ReadNoNested3PartyIDs raw |> FIXField.NoNested3PartyIDs
        | "949" -> ReadNested3PartyID raw |> FIXField.Nested3PartyID
        | "950" -> ReadNested3PartyIDSource raw |> FIXField.Nested3PartyIDSource
        | "951" -> ReadNested3PartyRole raw |> FIXField.Nested3PartyRole
        | "952" -> ReadNoNested3PartySubIDs raw |> FIXField.NoNested3PartySubIDs
        | "953" -> ReadNested3PartySubID raw |> FIXField.Nested3PartySubID
        | "954" -> ReadNested3PartySubIDType raw |> FIXField.Nested3PartySubIDType
        | "955" -> ReadLegContractSettlMonth raw |> FIXField.LegContractSettlMonth
        | "956" -> ReadLegInterestAccrualDate raw |> FIXField.LegInterestAccrualDate
        |  _  -> failwith "FIXField invalid tag" 
    fld
