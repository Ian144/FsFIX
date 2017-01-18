module Fix44.FieldWriters


open System
open System.IO
open Fix44.Fields
open Conversions
open RawField


let WriteAccount (dest:byte []) (pos:int) (valIn:Account) : int = 
    WriteFieldStr dest pos "1="B valIn


let WriteAdvId (dest:byte []) (pos:int) (valIn:AdvId) : int = 
    WriteFieldStr dest pos "2="B valIn


let WriteAdvRefID (dest:byte []) (pos:int) (valIn:AdvRefID) : int = 
    WriteFieldStr dest pos "3="B valIn


let WriteAdvSide (dest:byte array) (nextFreeIdx:int) (xxIn:AdvSide) : int =
    match xxIn with
    | AdvSide.Buy ->
        let tag = "4=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AdvSide.Sell ->
        let tag = "4=S"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AdvSide.Cross ->
        let tag = "4=X"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AdvSide.Trade ->
        let tag = "4=T"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteAdvTransType (dest:byte array) (nextFreeIdx:int) (xxIn:AdvTransType) : int =
    match xxIn with
    | AdvTransType.New ->
        let tag = "5=N"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AdvTransType.Cancel ->
        let tag = "5=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AdvTransType.Replace ->
        let tag = "5=R"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteAvgPx (dest:byte []) (pos:int) (valIn:AvgPx) : int = 
    WriteFieldDecimal dest pos "6="B valIn


let WriteBeginSeqNo (dest:byte []) (pos:int) (valIn:BeginSeqNo) : int = 
    WriteFieldUint32 dest pos "7="B valIn


let WriteBeginString (dest:byte []) (pos:int) (valIn:BeginString) : int = 
    WriteFieldStr dest pos "8="B valIn


let WriteBodyLength (dest:byte []) (pos:int) (valIn:BodyLength) : int = 
    WriteFieldUint32 dest pos "9="B valIn


let WriteCheckSum (dest:byte []) (pos:int) (valIn:CheckSum) : int = 
    WriteFieldStr dest pos "10="B valIn


let WriteClOrdID (dest:byte []) (pos:int) (valIn:ClOrdID) : int = 
    WriteFieldStr dest pos "11="B valIn


let WriteCommission (dest:byte []) (pos:int) (valIn:Commission) : int = 
    WriteFieldDecimal dest pos "12="B valIn


let WriteCommType (dest:byte array) (nextFreeIdx:int) (xxIn:CommType) : int =
    match xxIn with
    | CommType.PerUnit ->
        let tag = "13=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CommType.Percentage ->
        let tag = "13=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CommType.Absolute ->
        let tag = "13=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CommType.PercentageWaivedCashDiscount ->
        let tag = "13=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CommType.PercentageWaivedEnhancedUnits ->
        let tag = "13=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CommType.PointsPerBondOrOrContract ->
        let tag = "13=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCumQty (dest:byte []) (pos:int) (valIn:CumQty) : int = 
    WriteFieldDecimal dest pos "14="B valIn


let WriteCurrency (dest:byte []) (pos:int) (valIn:Currency) : int = 
    WriteFieldStr dest pos "15="B valIn


let WriteEndSeqNo (dest:byte []) (pos:int) (valIn:EndSeqNo) : int = 
    WriteFieldUint32 dest pos "16="B valIn


let WriteExecID (dest:byte []) (pos:int) (valIn:ExecID) : int = 
    WriteFieldStr dest pos "17="B valIn


let WriteExecInst (dest:byte array) (nextFreeIdx:int) (xxIn:ExecInst) : int =
    match xxIn with
    | ExecInst.NotHeld ->
        let tag = "18=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.Work ->
        let tag = "18=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.GoAlong ->
        let tag = "18=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.OverTheDay ->
        let tag = "18=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.Held ->
        let tag = "18=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.ParticipateDontInitiate ->
        let tag = "18=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.StrictScale ->
        let tag = "18=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.TryToScale ->
        let tag = "18=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.StayOnBidside ->
        let tag = "18=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.StayOnOfferside ->
        let tag = "18=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.NoCross ->
        let tag = "18=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.OkToCross ->
        let tag = "18=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.CallFirst ->
        let tag = "18=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.PercentOfVolume ->
        let tag = "18=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.DoNotIncrease ->
        let tag = "18=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.DoNotReduce ->
        let tag = "18=F"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.AllOrNone ->
        let tag = "18=G"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.ReinstateOnSystemFailure ->
        let tag = "18=H"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.InstitutionsOnly ->
        let tag = "18=I"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.ReinstateOnTradingHalt ->
        let tag = "18=J"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.CancelOnTradingHalt ->
        let tag = "18=K"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.LastPeg ->
        let tag = "18=L"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.MidPrice ->
        let tag = "18=M"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.NonNegotiable ->
        let tag = "18=N"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.OpeningPeg ->
        let tag = "18=O"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.MarketPeg ->
        let tag = "18=P"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.CancelOnSystemFailure ->
        let tag = "18=Q"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.PrimaryPeg ->
        let tag = "18=R"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.Suspend ->
        let tag = "18=S"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.FixedPegToLocalBestBidOrOfferAtTimeOfOrder ->
        let tag = "18=T"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.CustomerDisplayInstruction ->
        let tag = "18=U"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.Netting ->
        let tag = "18=V"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.PegToVwap ->
        let tag = "18=W"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.TradeAlong ->
        let tag = "18=X"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.TryToStop ->
        let tag = "18=Y"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.CancelIfNotBest ->
        let tag = "18=Z"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.TrailingStopPeg ->
        let tag = "18=a"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.StrictLimit ->
        let tag = "18=b"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.IgnorePriceValidityChecks ->
        let tag = "18=c"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.PegToLimitPrice ->
        let tag = "18=d"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecInst.WorkToTargetStrategy ->
        let tag = "18=e"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteExecRefID (dest:byte []) (pos:int) (valIn:ExecRefID) : int = 
    WriteFieldStr dest pos "19="B valIn


let WriteHandlInst (dest:byte array) (nextFreeIdx:int) (xxIn:HandlInst) : int =
    match xxIn with
    | HandlInst.AutomatedExecutionOrderPrivate ->
        let tag = "21=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | HandlInst.AutomatedExecutionOrderPublic ->
        let tag = "21=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | HandlInst.ManualOrder ->
        let tag = "21=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSecurityIDSource (dest:byte array) (nextFreeIdx:int) (xxIn:SecurityIDSource) : int =
    match xxIn with
    | SecurityIDSource.Cusip ->
        let tag = "22=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.Sedol ->
        let tag = "22=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.Quik ->
        let tag = "22=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.IsinNumber ->
        let tag = "22=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.RicCode ->
        let tag = "22=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.IsoCurrencyCode ->
        let tag = "22=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.IsoCountryCode ->
        let tag = "22=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.ExchangeSymbol ->
        let tag = "22=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.ConsolidatedTapeAssociation ->
        let tag = "22=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.BloombergSymbol ->
        let tag = "22=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.Wertpapier ->
        let tag = "22=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.Dutch ->
        let tag = "22=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.Valoren ->
        let tag = "22=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.Sicovam ->
        let tag = "22=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.Belgian ->
        let tag = "22=F"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.Common ->
        let tag = "22=G"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.ClearingHouseClearingOrganization ->
        let tag = "22=H"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.IsdaFpmlProductSpecification ->
        let tag = "22=I"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityIDSource.OptionsPriceReportingAuthority ->
        let tag = "22=J"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteIOIid (dest:byte []) (pos:int) (valIn:IOIid) : int = 
    WriteFieldStr dest pos "23="B valIn


let WriteIOIQltyInd (dest:byte array) (nextFreeIdx:int) (xxIn:IOIQltyInd) : int =
    match xxIn with
    | IOIQltyInd.Low ->
        let tag = "25=L"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQltyInd.Medium ->
        let tag = "25=M"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQltyInd.High ->
        let tag = "25=H"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteIOIRefID (dest:byte []) (pos:int) (valIn:IOIRefID) : int = 
    WriteFieldStr dest pos "26="B valIn


let WriteIOIQty (dest:byte []) (pos:int) (valIn:IOIQty) : int = 
    WriteFieldStr dest pos "27="B valIn


let WriteIOITransType (dest:byte array) (nextFreeIdx:int) (xxIn:IOITransType) : int =
    match xxIn with
    | IOITransType.New ->
        let tag = "28=N"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOITransType.Cancel ->
        let tag = "28=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOITransType.Replace ->
        let tag = "28=R"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteLastCapacity (dest:byte array) (nextFreeIdx:int) (xxIn:LastCapacity) : int =
    match xxIn with
    | LastCapacity.Agent ->
        let tag = "29=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | LastCapacity.CrossAsAgent ->
        let tag = "29=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | LastCapacity.CrossAsPrincipal ->
        let tag = "29=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | LastCapacity.Principal ->
        let tag = "29=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteLastMkt (dest:byte []) (pos:int) (valIn:LastMkt) : int = 
    WriteFieldStr dest pos "30="B valIn


let WriteLastPx (dest:byte []) (pos:int) (valIn:LastPx) : int = 
    WriteFieldDecimal dest pos "31="B valIn


let WriteLastQty (dest:byte []) (pos:int) (valIn:LastQty) : int = 
    WriteFieldDecimal dest pos "32="B valIn


let WriteLinesOfText (dest:byte []) (pos:int) (valIn:LinesOfText) : int = 
    WriteFieldInt dest pos "33="B valIn


let WriteMsgSeqNum (dest:byte []) (pos:int) (valIn:MsgSeqNum) : int = 
    WriteFieldUint32 dest pos "34="B valIn


let WriteMsgType (dest:byte array) (nextFreeIdx:int) (xxIn:MsgType) : int =
    match xxIn with
    | MsgType.Heartbeat ->
        let tag = "35=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.TestRequest ->
        let tag = "35=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.ResendRequest ->
        let tag = "35=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.Reject ->
        let tag = "35=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.SequenceReset ->
        let tag = "35=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.Logout ->
        let tag = "35=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.IndicationOfInterest ->
        let tag = "35=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.Advertisement ->
        let tag = "35=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.ExecutionReport ->
        let tag = "35=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.OrderCancelReject ->
        let tag = "35=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.Logon ->
        let tag = "35=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.News ->
        let tag = "35=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.Email ->
        let tag = "35=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.NewOrderSingle ->
        let tag = "35=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.NewOrderList ->
        let tag = "35=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.OrderCancelRequest ->
        let tag = "35=F"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.OrderCancelReplaceRequest ->
        let tag = "35=G"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.OrderStatusRequest ->
        let tag = "35=H"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.AllocationInstruction ->
        let tag = "35=J"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.ListCancelRequest ->
        let tag = "35=K"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.ListExecute ->
        let tag = "35=L"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.ListStatusRequest ->
        let tag = "35=M"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.ListStatus ->
        let tag = "35=N"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.AllocationInstructionAck ->
        let tag = "35=P"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.DontKnowTrade ->
        let tag = "35=Q"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.QuoteRequest ->
        let tag = "35=R"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.Quote ->
        let tag = "35=S"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.SettlementInstructions ->
        let tag = "35=T"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.MarketDataRequest ->
        let tag = "35=V"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.MarketDataSnapshotFullRefresh ->
        let tag = "35=W"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.MarketDataIncrementalRefresh ->
        let tag = "35=X"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.MarketDataRequestReject ->
        let tag = "35=Y"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.QuoteCancel ->
        let tag = "35=Z"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.QuoteStatusRequest ->
        let tag = "35=a"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.MassQuoteAcknowledgement ->
        let tag = "35=b"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.SecurityDefinitionRequest ->
        let tag = "35=c"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.SecurityDefinition ->
        let tag = "35=d"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.SecurityStatusRequest ->
        let tag = "35=e"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.SecurityStatus ->
        let tag = "35=f"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.TradingSessionStatusRequest ->
        let tag = "35=g"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.TradingSessionStatus ->
        let tag = "35=h"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.MassQuote ->
        let tag = "35=i"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.BusinessMessageReject ->
        let tag = "35=j"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.BidRequest ->
        let tag = "35=k"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.BidResponse ->
        let tag = "35=l"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.ListStrikePrice ->
        let tag = "35=m"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.XmlMessage ->
        let tag = "35=n"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.RegistrationInstructions ->
        let tag = "35=o"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.RegistrationInstructionsResponse ->
        let tag = "35=p"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.OrderMassCancelRequest ->
        let tag = "35=q"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.OrderMassCancelReport ->
        let tag = "35=r"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.NewOrderCross ->
        let tag = "35=s"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.CrossOrderCancelReplaceRequest ->
        let tag = "35=t"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.CrossOrderCancelRequest ->
        let tag = "35=u"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.SecurityTypeRequest ->
        let tag = "35=v"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.SecurityTypes ->
        let tag = "35=w"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.SecurityListRequest ->
        let tag = "35=x"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.SecurityList ->
        let tag = "35=y"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.DerivativeSecurityListRequest ->
        let tag = "35=z"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.DerivativeSecurityList ->
        let tag = "35=AA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.NewOrderMultileg ->
        let tag = "35=AB"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.MultilegOrderCancelReplaceRequest ->
        let tag = "35=AC"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.TradeCaptureReportRequest ->
        let tag = "35=AD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.TradeCaptureReport ->
        let tag = "35=AE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.OrderMassStatusRequest ->
        let tag = "35=AF"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.QuoteRequestReject ->
        let tag = "35=AG"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.RFQRequest ->
        let tag = "35=AH"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.QuoteStatusReport ->
        let tag = "35=AI"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.QuoteResponse ->
        let tag = "35=AJ"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.Confirmation ->
        let tag = "35=AK"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.PositionMaintenanceRequest ->
        let tag = "35=AL"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.PositionMaintenanceReport ->
        let tag = "35=AM"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.RequestForPositions ->
        let tag = "35=AN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.RequestForPositionsAck ->
        let tag = "35=AO"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.PositionReport ->
        let tag = "35=AP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.TradeCaptureReportRequestAck ->
        let tag = "35=AQ"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.TradeCaptureReportAck ->
        let tag = "35=AR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.AllocationReport ->
        let tag = "35=AS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.AllocationReportAck ->
        let tag = "35=AT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.ConfirmationAck ->
        let tag = "35=AU"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.SettlementInstructionRequest ->
        let tag = "35=AV"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.AssignmentReport ->
        let tag = "35=AW"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.CollateralRequest ->
        let tag = "35=AX"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.CollateralAssignment ->
        let tag = "35=AY"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.CollateralResponse ->
        let tag = "35=AZ"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.CollateralReport ->
        let tag = "35=BA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.CollateralInquiry ->
        let tag = "35=BB"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.NetworkStatusRequest ->
        let tag = "35=BC"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.NetworkStatusResponse ->
        let tag = "35=BD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.UserRequest ->
        let tag = "35=BE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.UserResponse ->
        let tag = "35=BF"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.CollateralInquiryAck ->
        let tag = "35=BG"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.ConfirmationRequest ->
        let tag = "35=BH"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNewSeqNo (dest:byte []) (pos:int) (valIn:NewSeqNo) : int = 
    WriteFieldUint32 dest pos "36="B valIn


let WriteOrderID (dest:byte []) (pos:int) (valIn:OrderID) : int = 
    WriteFieldStr dest pos "37="B valIn


let WriteOrderQty (dest:byte []) (pos:int) (valIn:OrderQty) : int = 
    WriteFieldDecimal dest pos "38="B valIn


let WriteOrdStatus (dest:byte array) (nextFreeIdx:int) (xxIn:OrdStatus) : int =
    match xxIn with
    | OrdStatus.New ->
        let tag = "39=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.PartiallyFilled ->
        let tag = "39=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.Filled ->
        let tag = "39=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.DoneForDay ->
        let tag = "39=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.Canceled ->
        let tag = "39=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.Replaced ->
        let tag = "39=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.PendingCancel ->
        let tag = "39=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.Stopped ->
        let tag = "39=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.Rejected ->
        let tag = "39=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.Suspended ->
        let tag = "39=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.PendingNew ->
        let tag = "39=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.Calculated ->
        let tag = "39=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.Expired ->
        let tag = "39=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.AcceptedForBidding ->
        let tag = "39=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdStatus.PendingReplace ->
        let tag = "39=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteOrdType (dest:byte array) (nextFreeIdx:int) (xxIn:OrdType) : int =
    match xxIn with
    | OrdType.Market ->
        let tag = "40=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.Limit ->
        let tag = "40=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.Stop ->
        let tag = "40=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.StopLimit ->
        let tag = "40=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.MarketOnClose ->
        let tag = "40=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.WithOrWithout ->
        let tag = "40=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.LimitOrBetter ->
        let tag = "40=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.LimitWithOrWithout ->
        let tag = "40=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.OnBasis ->
        let tag = "40=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.OnClose ->
        let tag = "40=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.LimitOnClose ->
        let tag = "40=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.ForexMarket ->
        let tag = "40=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.PreviouslyQuoted ->
        let tag = "40=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.PreviouslyIndicated ->
        let tag = "40=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.ForexLimit ->
        let tag = "40=F"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.ForexSwap ->
        let tag = "40=G"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.ForexPreviouslyQuoted ->
        let tag = "40=H"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.Funari ->
        let tag = "40=I"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.MarketIfTouched ->
        let tag = "40=J"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.MarketWithLeftoverAsLimit ->
        let tag = "40=K"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.PreviousFundValuationPoint ->
        let tag = "40=L"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.NextFundValuationPoint ->
        let tag = "40=M"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdType.Pegged ->
        let tag = "40=P"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteOrigClOrdID (dest:byte []) (pos:int) (valIn:OrigClOrdID) : int = 
    WriteFieldStr dest pos "41="B valIn


let WriteOrigTime (dest:byte []) (pos:int) (valIn:OrigTime) : int = 
    WriteFieldUTCTimestamp dest pos "42="B valIn


let WritePossDupFlag (dest:byte []) (pos:int) (valIn:PossDupFlag) : int = 
    WriteFieldBool dest pos "43="B valIn


let WritePrice (dest:byte []) (pos:int) (valIn:Price) : int = 
    WriteFieldDecimal dest pos "44="B valIn


let WriteRefSeqNum (dest:byte []) (pos:int) (valIn:RefSeqNum) : int = 
    WriteFieldUint32 dest pos "45="B valIn


let WriteSecurityID (dest:byte []) (pos:int) (valIn:SecurityID) : int = 
    WriteFieldStr dest pos "48="B valIn


let WriteSenderCompID (dest:byte []) (pos:int) (valIn:SenderCompID) : int = 
    WriteFieldStr dest pos "49="B valIn


let WriteSenderSubID (dest:byte []) (pos:int) (valIn:SenderSubID) : int = 
    WriteFieldStr dest pos "50="B valIn


let WriteSendingTime (dest:byte []) (pos:int) (valIn:SendingTime) : int = 
    WriteFieldUTCTimestamp dest pos "52="B valIn


let WriteQuantity (dest:byte []) (pos:int) (valIn:Quantity) : int = 
    WriteFieldDecimal dest pos "53="B valIn


let WriteSide (dest:byte array) (nextFreeIdx:int) (xxIn:Side) : int =
    match xxIn with
    | Side.Buy ->
        let tag = "54=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.Sell ->
        let tag = "54=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.BuyMinus ->
        let tag = "54=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.SellPlus ->
        let tag = "54=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.SellShort ->
        let tag = "54=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.SellShortExempt ->
        let tag = "54=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.Undisclosed ->
        let tag = "54=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.Cross ->
        let tag = "54=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.CrossShort ->
        let tag = "54=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.CrossShortExempt ->
        let tag = "54=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.AsDefined ->
        let tag = "54=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.Opposite ->
        let tag = "54=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.Subscribe ->
        let tag = "54=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.Redeem ->
        let tag = "54=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.Lend ->
        let tag = "54=F"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Side.Borrow ->
        let tag = "54=G"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSymbol (dest:byte []) (pos:int) (valIn:Symbol) : int = 
    WriteFieldStr dest pos "55="B valIn


let WriteTargetCompID (dest:byte []) (pos:int) (valIn:TargetCompID) : int = 
    WriteFieldStr dest pos "56="B valIn


let WriteTargetSubID (dest:byte []) (pos:int) (valIn:TargetSubID) : int = 
    WriteFieldStr dest pos "57="B valIn


let WriteText (dest:byte []) (pos:int) (valIn:Text) : int = 
    WriteFieldStr dest pos "58="B valIn


let WriteTimeInForce (dest:byte array) (nextFreeIdx:int) (xxIn:TimeInForce) : int =
    match xxIn with
    | TimeInForce.Day ->
        let tag = "59=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TimeInForce.GoodTillCancel ->
        let tag = "59=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TimeInForce.AtTheOpening ->
        let tag = "59=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TimeInForce.ImmediateOrCancel ->
        let tag = "59=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TimeInForce.FillOrKill ->
        let tag = "59=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TimeInForce.GoodTillCrossing ->
        let tag = "59=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TimeInForce.GoodTillDate ->
        let tag = "59=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TimeInForce.AtTheClose ->
        let tag = "59=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTransactTime (dest:byte []) (pos:int) (valIn:TransactTime) : int = 
    WriteFieldUTCTimestamp dest pos "60="B valIn


let WriteUrgency (dest:byte array) (nextFreeIdx:int) (xxIn:Urgency) : int =
    match xxIn with
    | Urgency.Normal ->
        let tag = "61=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Urgency.Flash ->
        let tag = "61=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Urgency.Background ->
        let tag = "61=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteValidUntilTime (dest:byte []) (pos:int) (valIn:ValidUntilTime) : int = 
    WriteFieldUTCTimestamp dest pos "62="B valIn


let WriteSettlType (dest:byte array) (nextFreeIdx:int) (xxIn:SettlType) : int =
    match xxIn with
    | SettlType.Regular ->
        let tag = "63=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlType.Cash ->
        let tag = "63=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlType.NextDay ->
        let tag = "63=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlType.TPlus2 ->
        let tag = "63=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlType.TPlus3 ->
        let tag = "63=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlType.TPlus4 ->
        let tag = "63=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlType.Future ->
        let tag = "63=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlType.WhenAndIfIssued ->
        let tag = "63=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlType.SellersOption ->
        let tag = "63=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlType.TPlus5 ->
        let tag = "63=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSettlDate (dest:byte []) (pos:int) (valIn:SettlDate) : int = 
    WriteFieldLocalMktDate dest pos "64="B valIn


let WriteSymbolSfx (dest:byte array) (nextFreeIdx:int) (xxIn:SymbolSfx) : int =
    match xxIn with
    | SymbolSfx.WhenIssued ->
        let tag = "65=WI"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SymbolSfx.AEucpWithLumpSumInterest ->
        let tag = "65=CD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteListID (dest:byte []) (pos:int) (valIn:ListID) : int = 
    WriteFieldStr dest pos "66="B valIn


let WriteListSeqNo (dest:byte []) (pos:int) (valIn:ListSeqNo) : int = 
    WriteFieldInt dest pos "67="B valIn


let WriteTotNoOrders (dest:byte []) (pos:int) (valIn:TotNoOrders) : int = 
    WriteFieldInt dest pos "68="B valIn


let WriteListExecInst (dest:byte []) (pos:int) (valIn:ListExecInst) : int = 
    WriteFieldStr dest pos "69="B valIn


let WriteAllocID (dest:byte []) (pos:int) (valIn:AllocID) : int = 
    WriteFieldStr dest pos "70="B valIn


let WriteAllocTransType (dest:byte array) (nextFreeIdx:int) (xxIn:AllocTransType) : int =
    match xxIn with
    | AllocTransType.New ->
        let tag = "71=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocTransType.Replace ->
        let tag = "71=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocTransType.Cancel ->
        let tag = "71=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteRefAllocID (dest:byte []) (pos:int) (valIn:RefAllocID) : int = 
    WriteFieldStr dest pos "72="B valIn


let WriteNoOrders (dest:byte []) (pos:int) (valIn:NoOrders) : int = 
    WriteFieldInt dest pos "73="B valIn


let WriteAvgPxPrecision (dest:byte []) (pos:int) (valIn:AvgPxPrecision) : int = 
    WriteFieldInt dest pos "74="B valIn


let WriteTradeDate (dest:byte []) (pos:int) (valIn:TradeDate) : int = 
    WriteFieldLocalMktDate dest pos "75="B valIn


let WritePositionEffect (dest:byte array) (nextFreeIdx:int) (xxIn:PositionEffect) : int =
    match xxIn with
    | PositionEffect.Open ->
        let tag = "77=O"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PositionEffect.Close ->
        let tag = "77=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PositionEffect.Rolled ->
        let tag = "77=R"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PositionEffect.Fifo ->
        let tag = "77=F"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoAllocs (dest:byte []) (pos:int) (valIn:NoAllocs) : int = 
    WriteFieldInt dest pos "78="B valIn


let WriteAllocAccount (dest:byte []) (pos:int) (valIn:AllocAccount) : int = 
    WriteFieldStr dest pos "79="B valIn


let WriteAllocQty (dest:byte []) (pos:int) (valIn:AllocQty) : int = 
    WriteFieldDecimal dest pos "80="B valIn


let WriteProcessCode (dest:byte array) (nextFreeIdx:int) (xxIn:ProcessCode) : int =
    match xxIn with
    | ProcessCode.Regular ->
        let tag = "81=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ProcessCode.SoftDollar ->
        let tag = "81=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ProcessCode.StepIn ->
        let tag = "81=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ProcessCode.StepOut ->
        let tag = "81=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ProcessCode.SoftDollarStepIn ->
        let tag = "81=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ProcessCode.SoftDollarStepOut ->
        let tag = "81=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ProcessCode.PlanSponsor ->
        let tag = "81=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoRpts (dest:byte []) (pos:int) (valIn:NoRpts) : int = 
    WriteFieldInt dest pos "82="B valIn


let WriteRptSeq (dest:byte []) (pos:int) (valIn:RptSeq) : int = 
    WriteFieldInt dest pos "83="B valIn


let WriteCxlQty (dest:byte []) (pos:int) (valIn:CxlQty) : int = 
    WriteFieldDecimal dest pos "84="B valIn


let WriteNoDlvyInst (dest:byte []) (pos:int) (valIn:NoDlvyInst) : int = 
    WriteFieldInt dest pos "85="B valIn


let WriteAllocStatus (dest:byte array) (nextFreeIdx:int) (xxIn:AllocStatus) : int =
    match xxIn with
    | AllocStatus.Accepted ->
        let tag = "87=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocStatus.BlockLevelReject ->
        let tag = "87=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocStatus.AccountLevelReject ->
        let tag = "87=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocStatus.Received ->
        let tag = "87=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocStatus.Incomplete ->
        let tag = "87=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocStatus.RejectedByIntermediary ->
        let tag = "87=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteAllocRejCode (dest:byte array) (nextFreeIdx:int) (xxIn:AllocRejCode) : int =
    match xxIn with
    | AllocRejCode.UnknownAccount ->
        let tag = "88=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocRejCode.IncorrectQuantity ->
        let tag = "88=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocRejCode.IncorrectAveragePrice ->
        let tag = "88=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocRejCode.UnknownExecutingBrokerMnemonic ->
        let tag = "88=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocRejCode.CommissionDifference ->
        let tag = "88=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocRejCode.UnknownOrderid ->
        let tag = "88=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocRejCode.UnknownListid ->
        let tag = "88=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocRejCode.Other ->
        let tag = "88=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocRejCode.IncorrectAllocatedQuantity ->
        let tag = "88=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocRejCode.CalculationDifference ->
        let tag = "88=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocRejCode.UnknownOrStaleExecId ->
        let tag = "88=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocRejCode.MismatchedDataValue ->
        let tag = "88=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocRejCode.UnknownClordid ->
        let tag = "88=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocRejCode.WarehouseRequestRejected ->
        let tag = "88=13"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteSignature (dest:byte []) (pos:int) (fld:Signature) : int =
    WriteFieldLengthData dest pos "93="B "89="B fld


// compound write, of a length field and the corresponding string field
let WriteSecureData (dest:byte []) (pos:int) (fld:SecureData) : int =
    WriteFieldLengthData dest pos "90="B "91="B fld


let WriteEmailType (dest:byte array) (nextFreeIdx:int) (xxIn:EmailType) : int =
    match xxIn with
    | EmailType.New ->
        let tag = "94=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | EmailType.Reply ->
        let tag = "94=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | EmailType.AdminReply ->
        let tag = "94=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteRawData (dest:byte []) (pos:int) (fld:RawData) : int =
    WriteFieldLengthData dest pos "95="B "96="B fld


let WritePossResend (dest:byte []) (pos:int) (valIn:PossResend) : int = 
    WriteFieldBool dest pos "97="B valIn


let WriteEncryptMethod (dest:byte array) (nextFreeIdx:int) (xxIn:EncryptMethod) : int =
    match xxIn with
    | EncryptMethod.NoneOther ->
        let tag = "98=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | EncryptMethod.Pkcs ->
        let tag = "98=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | EncryptMethod.Des ->
        let tag = "98=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | EncryptMethod.PkcsDes ->
        let tag = "98=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | EncryptMethod.PgpDes ->
        let tag = "98=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | EncryptMethod.PgpDesMd5 ->
        let tag = "98=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | EncryptMethod.PemDesMd5 ->
        let tag = "98=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteStopPx (dest:byte []) (pos:int) (valIn:StopPx) : int = 
    WriteFieldDecimal dest pos "99="B valIn


let WriteExDestination (dest:byte []) (pos:int) (valIn:ExDestination) : int = 
    WriteFieldStr dest pos "100="B valIn


let WriteCxlRejReason (dest:byte array) (nextFreeIdx:int) (xxIn:CxlRejReason) : int =
    match xxIn with
    | CxlRejReason.TooLateToCancel ->
        let tag = "102=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CxlRejReason.UnknownOrder ->
        let tag = "102=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CxlRejReason.BrokerExchangeOption ->
        let tag = "102=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CxlRejReason.OrderAlreadyInPendingCancelOrPendingReplaceStatus ->
        let tag = "102=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CxlRejReason.UnableToProcessOrderMassCancelRequest ->
        let tag = "102=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CxlRejReason.OrigordmodtimeDidNotMatchLastTransacttimeOfOrder ->
        let tag = "102=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CxlRejReason.DuplicateClordidReceived ->
        let tag = "102=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CxlRejReason.Other ->
        let tag = "102=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteOrdRejReason (dest:byte array) (nextFreeIdx:int) (xxIn:OrdRejReason) : int =
    match xxIn with
    | OrdRejReason.BrokerExchangeOption ->
        let tag = "103=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.UnknownSymbol ->
        let tag = "103=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.ExchangeClosed ->
        let tag = "103=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.OrderExceedsLimit ->
        let tag = "103=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.TooLateToEnter ->
        let tag = "103=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.UnknownOrder ->
        let tag = "103=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.DuplicateOrder ->
        let tag = "103=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.DuplicateOfAVerballyCommunicatedOrder ->
        let tag = "103=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.StaleOrder ->
        let tag = "103=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.TradeAlongRequired ->
        let tag = "103=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.InvalidInvestorId ->
        let tag = "103=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.UnsupportedOrderCharacteristic ->
        let tag = "103=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.SurveillenceOption ->
        let tag = "103=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.IncorrectQuantity ->
        let tag = "103=13"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.IncorrectAllocatedQuantity ->
        let tag = "103=14"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.UnknownAccount ->
        let tag = "103=15"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrdRejReason.Other ->
        let tag = "103=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteIOIQualifier (dest:byte array) (nextFreeIdx:int) (xxIn:IOIQualifier) : int =
    match xxIn with
    | IOIQualifier.AllOrNone ->
        let tag = "104=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.MarketOnClose ->
        let tag = "104=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.AtTheClose ->
        let tag = "104=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.Vwap ->
        let tag = "104=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.InTouchWith ->
        let tag = "104=I"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.Limit ->
        let tag = "104=L"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.MoreBehind ->
        let tag = "104=M"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.AtTheOpen ->
        let tag = "104=O"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.TakingAPosition ->
        let tag = "104=P"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.AtTheMarket ->
        let tag = "104=Q"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.ReadyToTrade ->
        let tag = "104=R"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.PortfolioShown ->
        let tag = "104=S"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.ThroughTheDay ->
        let tag = "104=T"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.Versus ->
        let tag = "104=V"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.IndicationWorkingAway ->
        let tag = "104=W"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.CrossingOpportunity ->
        let tag = "104=X"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.AtTheMidpoint ->
        let tag = "104=Y"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IOIQualifier.PreOpen ->
        let tag = "104=Z"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteWaveNo (dest:byte []) (pos:int) (valIn:WaveNo) : int = 
    WriteFieldStr dest pos "105="B valIn


let WriteIssuer (dest:byte []) (pos:int) (valIn:Issuer) : int = 
    WriteFieldStr dest pos "106="B valIn


let WriteSecurityDesc (dest:byte []) (pos:int) (valIn:SecurityDesc) : int = 
    WriteFieldStr dest pos "107="B valIn


let WriteHeartBtInt (dest:byte []) (pos:int) (valIn:HeartBtInt) : int = 
    WriteFieldInt dest pos "108="B valIn


let WriteMinQty (dest:byte []) (pos:int) (valIn:MinQty) : int = 
    WriteFieldDecimal dest pos "110="B valIn


let WriteMaxFloor (dest:byte []) (pos:int) (valIn:MaxFloor) : int = 
    WriteFieldDecimal dest pos "111="B valIn


let WriteTestReqID (dest:byte []) (pos:int) (valIn:TestReqID) : int = 
    WriteFieldStr dest pos "112="B valIn


let WriteReportToExch (dest:byte []) (pos:int) (valIn:ReportToExch) : int = 
    WriteFieldBool dest pos "113="B valIn


let WriteLocateReqd (dest:byte []) (pos:int) (valIn:LocateReqd) : int = 
    WriteFieldBool dest pos "114="B valIn


let WriteOnBehalfOfCompID (dest:byte []) (pos:int) (valIn:OnBehalfOfCompID) : int = 
    WriteFieldStr dest pos "115="B valIn


let WriteOnBehalfOfSubID (dest:byte []) (pos:int) (valIn:OnBehalfOfSubID) : int = 
    WriteFieldStr dest pos "116="B valIn


let WriteQuoteID (dest:byte []) (pos:int) (valIn:QuoteID) : int = 
    WriteFieldStr dest pos "117="B valIn


let WriteNetMoney (dest:byte []) (pos:int) (valIn:NetMoney) : int = 
    WriteFieldDecimal dest pos "118="B valIn


let WriteSettlCurrAmt (dest:byte []) (pos:int) (valIn:SettlCurrAmt) : int = 
    WriteFieldDecimal dest pos "119="B valIn


let WriteSettlCurrency (dest:byte []) (pos:int) (valIn:SettlCurrency) : int = 
    WriteFieldStr dest pos "120="B valIn


let WriteForexReq (dest:byte []) (pos:int) (valIn:ForexReq) : int = 
    WriteFieldBool dest pos "121="B valIn


let WriteOrigSendingTime (dest:byte []) (pos:int) (valIn:OrigSendingTime) : int = 
    WriteFieldUTCTimestamp dest pos "122="B valIn


let WriteGapFillFlag (dest:byte []) (pos:int) (valIn:GapFillFlag) : int = 
    WriteFieldBool dest pos "123="B valIn


let WriteNoExecs (dest:byte []) (pos:int) (valIn:NoExecs) : int = 
    WriteFieldInt dest pos "124="B valIn


let WriteExpireTime (dest:byte []) (pos:int) (valIn:ExpireTime) : int = 
    WriteFieldUTCTimestamp dest pos "126="B valIn


let WriteDKReason (dest:byte array) (nextFreeIdx:int) (xxIn:DKReason) : int =
    match xxIn with
    | DKReason.UnknownSymbol ->
        let tag = "127=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DKReason.WrongSide ->
        let tag = "127=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DKReason.QuantityExceedsOrder ->
        let tag = "127=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DKReason.NoMatchingOrder ->
        let tag = "127=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DKReason.PriceExceedsLimit ->
        let tag = "127=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DKReason.CalculationDifference ->
        let tag = "127=F"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DKReason.Other ->
        let tag = "127=Z"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteDeliverToCompID (dest:byte []) (pos:int) (valIn:DeliverToCompID) : int = 
    WriteFieldStr dest pos "128="B valIn


let WriteDeliverToSubID (dest:byte []) (pos:int) (valIn:DeliverToSubID) : int = 
    WriteFieldStr dest pos "129="B valIn


let WriteIOINaturalFlag (dest:byte []) (pos:int) (valIn:IOINaturalFlag) : int = 
    WriteFieldBool dest pos "130="B valIn


let WriteQuoteReqID (dest:byte []) (pos:int) (valIn:QuoteReqID) : int = 
    WriteFieldStr dest pos "131="B valIn


let WriteBidPx (dest:byte []) (pos:int) (valIn:BidPx) : int = 
    WriteFieldDecimal dest pos "132="B valIn


let WriteOfferPx (dest:byte []) (pos:int) (valIn:OfferPx) : int = 
    WriteFieldDecimal dest pos "133="B valIn


let WriteBidSize (dest:byte []) (pos:int) (valIn:BidSize) : int = 
    WriteFieldDecimal dest pos "134="B valIn


let WriteOfferSize (dest:byte []) (pos:int) (valIn:OfferSize) : int = 
    WriteFieldDecimal dest pos "135="B valIn


let WriteNoMiscFees (dest:byte []) (pos:int) (valIn:NoMiscFees) : int = 
    WriteFieldInt dest pos "136="B valIn


let WriteMiscFeeAmt (dest:byte []) (pos:int) (valIn:MiscFeeAmt) : int = 
    WriteFieldDecimal dest pos "137="B valIn


let WriteMiscFeeCurr (dest:byte []) (pos:int) (valIn:MiscFeeCurr) : int = 
    WriteFieldStr dest pos "138="B valIn


let WriteMiscFeeType (dest:byte array) (nextFreeIdx:int) (xxIn:MiscFeeType) : int =
    match xxIn with
    | MiscFeeType.Regulatory ->
        let tag = "139=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MiscFeeType.Tax ->
        let tag = "139=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MiscFeeType.LocalCommission ->
        let tag = "139=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MiscFeeType.ExchangeFees ->
        let tag = "139=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MiscFeeType.Stamp ->
        let tag = "139=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MiscFeeType.Levy ->
        let tag = "139=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MiscFeeType.Other ->
        let tag = "139=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MiscFeeType.Markup ->
        let tag = "139=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MiscFeeType.ConsumptionTax ->
        let tag = "139=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MiscFeeType.PerTransaction ->
        let tag = "139=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MiscFeeType.Conversion ->
        let tag = "139=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MiscFeeType.Agent ->
        let tag = "139=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePrevClosePx (dest:byte []) (pos:int) (valIn:PrevClosePx) : int = 
    WriteFieldDecimal dest pos "140="B valIn


let WriteResetSeqNumFlag (dest:byte []) (pos:int) (valIn:ResetSeqNumFlag) : int = 
    WriteFieldBool dest pos "141="B valIn


let WriteSenderLocationID (dest:byte []) (pos:int) (valIn:SenderLocationID) : int = 
    WriteFieldStr dest pos "142="B valIn


let WriteTargetLocationID (dest:byte []) (pos:int) (valIn:TargetLocationID) : int = 
    WriteFieldStr dest pos "143="B valIn


let WriteOnBehalfOfLocationID (dest:byte []) (pos:int) (valIn:OnBehalfOfLocationID) : int = 
    WriteFieldStr dest pos "144="B valIn


let WriteDeliverToLocationID (dest:byte []) (pos:int) (valIn:DeliverToLocationID) : int = 
    WriteFieldStr dest pos "145="B valIn


let WriteNoRelatedSym (dest:byte []) (pos:int) (valIn:NoRelatedSym) : int = 
    WriteFieldInt dest pos "146="B valIn


let WriteSubject (dest:byte []) (pos:int) (valIn:Subject) : int = 
    WriteFieldStr dest pos "147="B valIn


let WriteHeadline (dest:byte []) (pos:int) (valIn:Headline) : int = 
    WriteFieldStr dest pos "148="B valIn


let WriteURLLink (dest:byte []) (pos:int) (valIn:URLLink) : int = 
    WriteFieldStr dest pos "149="B valIn


let WriteExecType (dest:byte array) (nextFreeIdx:int) (xxIn:ExecType) : int =
    match xxIn with
    | ExecType.New ->
        let tag = "150=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.PartialFill ->
        let tag = "150=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.Fill ->
        let tag = "150=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.DoneForDay ->
        let tag = "150=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.Canceled ->
        let tag = "150=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.Replace ->
        let tag = "150=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.PendingCancel ->
        let tag = "150=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.Stopped ->
        let tag = "150=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.Rejected ->
        let tag = "150=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.Suspended ->
        let tag = "150=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.PendingNew ->
        let tag = "150=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.Calculated ->
        let tag = "150=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.Expired ->
        let tag = "150=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.Restated ->
        let tag = "150=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.PendingReplace ->
        let tag = "150=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.Trade ->
        let tag = "150=F"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.TradeCorrect ->
        let tag = "150=G"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.TradeCancel ->
        let tag = "150=H"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecType.OrderStatus ->
        let tag = "150=I"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteLeavesQty (dest:byte []) (pos:int) (valIn:LeavesQty) : int = 
    WriteFieldDecimal dest pos "151="B valIn


let WriteCashOrderQty (dest:byte []) (pos:int) (valIn:CashOrderQty) : int = 
    WriteFieldDecimal dest pos "152="B valIn


let WriteAllocAvgPx (dest:byte []) (pos:int) (valIn:AllocAvgPx) : int = 
    WriteFieldDecimal dest pos "153="B valIn


let WriteAllocNetMoney (dest:byte []) (pos:int) (valIn:AllocNetMoney) : int = 
    WriteFieldDecimal dest pos "154="B valIn


let WriteSettlCurrFxRate (dest:byte []) (pos:int) (valIn:SettlCurrFxRate) : int = 
    WriteFieldDecimal dest pos "155="B valIn


let WriteSettlCurrFxRateCalc (dest:byte array) (nextFreeIdx:int) (xxIn:SettlCurrFxRateCalc) : int =
    match xxIn with
    | SettlCurrFxRateCalc.Multiply ->
        let tag = "156=M"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlCurrFxRateCalc.Divide ->
        let tag = "156=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNumDaysInterest (dest:byte []) (pos:int) (valIn:NumDaysInterest) : int = 
    WriteFieldInt dest pos "157="B valIn


let WriteAccruedInterestRate (dest:byte []) (pos:int) (valIn:AccruedInterestRate) : int = 
    WriteFieldDecimal dest pos "158="B valIn


let WriteAccruedInterestAmt (dest:byte []) (pos:int) (valIn:AccruedInterestAmt) : int = 
    WriteFieldDecimal dest pos "159="B valIn


let WriteSettlInstMode (dest:byte array) (nextFreeIdx:int) (xxIn:SettlInstMode) : int =
    match xxIn with
    | SettlInstMode.Default ->
        let tag = "160=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlInstMode.StandingInstructionsProvided ->
        let tag = "160=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlInstMode.SpecificOrderForASingleAccount ->
        let tag = "160=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlInstMode.RequestReject ->
        let tag = "160=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteAllocText (dest:byte []) (pos:int) (valIn:AllocText) : int = 
    WriteFieldStr dest pos "161="B valIn


let WriteSettlInstID (dest:byte []) (pos:int) (valIn:SettlInstID) : int = 
    WriteFieldStr dest pos "162="B valIn


let WriteSettlInstTransType (dest:byte array) (nextFreeIdx:int) (xxIn:SettlInstTransType) : int =
    match xxIn with
    | SettlInstTransType.New ->
        let tag = "163=N"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlInstTransType.Cancel ->
        let tag = "163=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlInstTransType.Replace ->
        let tag = "163=R"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlInstTransType.Restate ->
        let tag = "163=T"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteEmailThreadID (dest:byte []) (pos:int) (valIn:EmailThreadID) : int = 
    WriteFieldStr dest pos "164="B valIn


let WriteSettlInstSource (dest:byte array) (nextFreeIdx:int) (xxIn:SettlInstSource) : int =
    match xxIn with
    | SettlInstSource.BrokersInstructions ->
        let tag = "165=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlInstSource.InstitutionsInstructions ->
        let tag = "165=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlInstSource.Investor ->
        let tag = "165=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSecurityType (dest:byte array) (nextFreeIdx:int) (xxIn:SecurityType) : int =
    match xxIn with
    | SecurityType.EuroSupranationalCoupons ->
        let tag = "167=EUSUPRA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.FederalAgencyCoupon ->
        let tag = "167=FAC"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.FederalAgencyDiscountNote ->
        let tag = "167=FADN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.PrivateExportFunding ->
        let tag = "167=PEF"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.UsdSupranationalCoupons ->
        let tag = "167=SUPRA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.Future ->
        let tag = "167=FUT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.Option ->
        let tag = "167=OPT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.CorporateBond ->
        let tag = "167=CORP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.CorporatePrivatePlacement ->
        let tag = "167=CPP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.ConvertibleBond ->
        let tag = "167=CB"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.DualCurrency ->
        let tag = "167=DUAL"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.EuroCorporateBond ->
        let tag = "167=EUCORP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.IndexedLinked ->
        let tag = "167=XLINKD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.StructuredNotes ->
        let tag = "167=STRUCT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.YankeeCorporateBond ->
        let tag = "167=YANK"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.ForeignExchangeContract ->
        let tag = "167=FOR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.CommonStock ->
        let tag = "167=CS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.PreferredStock ->
        let tag = "167=PS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.BradyBond ->
        let tag = "167=BRADY"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.EuroSovereigns ->
        let tag = "167=EUSOV"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.UsTreasuryBond ->
        let tag = "167=TBOND"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.InterestStripFromAnyBondOrNote ->
        let tag = "167=TINT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.TreasuryInflationProtectedSecurities ->
        let tag = "167=TIPS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.PrincipalStripOfACallableBondOrNote ->
        let tag = "167=TCAL"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.PrincipalStripFromANonCallableBondOrNote ->
        let tag = "167=TPRN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.UsTreasuryNote ->
        let tag = "167=TNOTE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.UsTreasuryBill ->
        let tag = "167=TBILL"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.Repurchase ->
        let tag = "167=REPO"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.Forward ->
        let tag = "167=FORWARD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.BuySellback ->
        let tag = "167=BUYSELL"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.SecuritiesLoan ->
        let tag = "167=SECLOAN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.SecuritiesPledge ->
        let tag = "167=SECPLEDGE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.TermLoan ->
        let tag = "167=TERM"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.RevolverLoan ->
        let tag = "167=RVLV"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.RevolverTermLoan ->
        let tag = "167=RVLVTRM"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.BridgeLoan ->
        let tag = "167=BRIDGE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.LetterOfCredit ->
        let tag = "167=LOFC"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.SwingLineFacility ->
        let tag = "167=SWING"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.DebtorInPossession ->
        let tag = "167=DINP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.Defaulted ->
        let tag = "167=DEFLTED"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.Withdrawn ->
        let tag = "167=WITHDRN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.Replaced ->
        let tag = "167=REPLACD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.Matured ->
        let tag = "167=MATURED"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.AmendedAndRestated ->
        let tag = "167=AMENDED"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.Retired ->
        let tag = "167=RETIRED"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.BankersAcceptance ->
        let tag = "167=BA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.BankNotes ->
        let tag = "167=BN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.BillOfExchanges ->
        let tag = "167=BOX"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.CertificateOfDeposit ->
        let tag = "167=CD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.CallLoans ->
        let tag = "167=CL"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.CommercialPaper ->
        let tag = "167=CP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.DepositNotes ->
        let tag = "167=DN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.EuroCertificateOfDeposit ->
        let tag = "167=EUCD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.EuroCommercialPaper ->
        let tag = "167=EUCP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.LiquidityNote ->
        let tag = "167=LQN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.MediumTermNotes ->
        let tag = "167=MTN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.Overnight ->
        let tag = "167=ONITE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.PromissoryNote ->
        let tag = "167=PN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.PlazosFijos ->
        let tag = "167=PZFJ"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.ShortTermLoanNote ->
        let tag = "167=STN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.TimeDeposit ->
        let tag = "167=TD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.ExtendedCommNote ->
        let tag = "167=XCN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.YankeeCertificateOfDeposit ->
        let tag = "167=YCD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.AssetBackedSecurities ->
        let tag = "167=ABS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.CorpMortgageBackedSecurities ->
        let tag = "167=CMBS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.CollateralizedMortgageObligation ->
        let tag = "167=CMO"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.IoetteMortgage ->
        let tag = "167=IET"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.MortgageBackedSecurities ->
        let tag = "167=MBS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.MortgageInterestOnly ->
        let tag = "167=MIO"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.MortgagePrincipalOnly ->
        let tag = "167=MPO"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.MortgagePrivatePlacement ->
        let tag = "167=MPP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.MiscellaneousPassThrough ->
        let tag = "167=MPT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.Pfandbriefe ->
        let tag = "167=PFAND"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.ToBeAnnounced ->
        let tag = "167=TBA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.OtherAnticipationNotes ->
        let tag = "167=AN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.CertificateOfObligation ->
        let tag = "167=COFO"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.CertificateOfParticipation ->
        let tag = "167=COFP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.GeneralObligationBonds ->
        let tag = "167=GO"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.MandatoryTender ->
        let tag = "167=MT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.RevenueAnticipationNote ->
        let tag = "167=RAN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.RevenueBonds ->
        let tag = "167=REV"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.SpecialAssessment ->
        let tag = "167=SPCLA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.SpecialObligation ->
        let tag = "167=SPCLO"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.SpecialTax ->
        let tag = "167=SPCLT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.TaxAnticipationNote ->
        let tag = "167=TAN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.TaxAllocation ->
        let tag = "167=TAXA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.TaxExemptCommercialPaper ->
        let tag = "167=TECP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.TaxAndRevenueAnticipationNote ->
        let tag = "167=TRAN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.VariableRateDemandNote ->
        let tag = "167=VRDN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.Warrant ->
        let tag = "167=WAR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.MutualFund ->
        let tag = "167=MF"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.MultiLegInstrument ->
        let tag = "167=MLEG"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.NoSecurityType ->
        let tag = "167=NONE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityType.Wildcard ->
        let tag = "167=?"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteEffectiveTime (dest:byte []) (pos:int) (valIn:EffectiveTime) : int = 
    WriteFieldUTCTimestamp dest pos "168="B valIn


let WriteStandInstDbType (dest:byte array) (nextFreeIdx:int) (xxIn:StandInstDbType) : int =
    match xxIn with
    | StandInstDbType.Other ->
        let tag = "169=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StandInstDbType.DtcSid ->
        let tag = "169=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StandInstDbType.ThomsonAlert ->
        let tag = "169=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StandInstDbType.AGlobalCustodian ->
        let tag = "169=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StandInstDbType.Accountnet ->
        let tag = "169=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteStandInstDbName (dest:byte []) (pos:int) (valIn:StandInstDbName) : int = 
    WriteFieldStr dest pos "170="B valIn


let WriteStandInstDbID (dest:byte []) (pos:int) (valIn:StandInstDbID) : int = 
    WriteFieldStr dest pos "171="B valIn


let WriteSettlDeliveryType (dest:byte array) (nextFreeIdx:int) (xxIn:SettlDeliveryType) : int =
    match xxIn with
    | SettlDeliveryType.VersusPayment ->
        let tag = "172=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlDeliveryType.Free ->
        let tag = "172=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlDeliveryType.TriParty ->
        let tag = "172=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlDeliveryType.HoldInCustody ->
        let tag = "172=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteBidSpotRate (dest:byte []) (pos:int) (valIn:BidSpotRate) : int = 
    WriteFieldDecimal dest pos "188="B valIn


let WriteBidForwardPoints (dest:byte []) (pos:int) (valIn:BidForwardPoints) : int = 
    WriteFieldDecimal dest pos "189="B valIn


let WriteOfferSpotRate (dest:byte []) (pos:int) (valIn:OfferSpotRate) : int = 
    WriteFieldDecimal dest pos "190="B valIn


let WriteOfferForwardPoints (dest:byte []) (pos:int) (valIn:OfferForwardPoints) : int = 
    WriteFieldDecimal dest pos "191="B valIn


let WriteOrderQty2 (dest:byte []) (pos:int) (valIn:OrderQty2) : int = 
    WriteFieldDecimal dest pos "192="B valIn


let WriteSettlDate2 (dest:byte []) (pos:int) (valIn:SettlDate2) : int = 
    WriteFieldLocalMktDate dest pos "193="B valIn


let WriteLastSpotRate (dest:byte []) (pos:int) (valIn:LastSpotRate) : int = 
    WriteFieldDecimal dest pos "194="B valIn


let WriteLastForwardPoints (dest:byte []) (pos:int) (valIn:LastForwardPoints) : int = 
    WriteFieldDecimal dest pos "195="B valIn


let WriteAllocLinkID (dest:byte []) (pos:int) (valIn:AllocLinkID) : int = 
    WriteFieldStr dest pos "196="B valIn


let WriteAllocLinkType (dest:byte array) (nextFreeIdx:int) (xxIn:AllocLinkType) : int =
    match xxIn with
    | AllocLinkType.FXNetting ->
        let tag = "197=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocLinkType.FXSwap ->
        let tag = "197=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSecondaryOrderID (dest:byte []) (pos:int) (valIn:SecondaryOrderID) : int = 
    WriteFieldStr dest pos "198="B valIn


let WriteNoIOIQualifiers (dest:byte []) (pos:int) (valIn:NoIOIQualifiers) : int = 
    WriteFieldInt dest pos "199="B valIn


let WriteMaturityMonthYear (dest:byte []) (pos:int) (valIn:MaturityMonthYear) : int = 
    WriteFieldMonthYear dest pos "200="B valIn


let WritePutOrCall (dest:byte array) (nextFreeIdx:int) (xxIn:PutOrCall) : int =
    match xxIn with
    | PutOrCall.Put ->
        let tag = "201=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PutOrCall.Call ->
        let tag = "201=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteStrikePrice (dest:byte []) (pos:int) (valIn:StrikePrice) : int = 
    WriteFieldDecimal dest pos "202="B valIn


let WriteCoveredOrUncovered (dest:byte array) (nextFreeIdx:int) (xxIn:CoveredOrUncovered) : int =
    match xxIn with
    | CoveredOrUncovered.Covered ->
        let tag = "203=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CoveredOrUncovered.Uncovered ->
        let tag = "203=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteOptAttribute (dest:byte []) (pos:int) (valIn:OptAttribute) : int = 
    WriteFieldChar dest pos "206="B valIn


let WriteSecurityExchange (dest:byte []) (pos:int) (valIn:SecurityExchange) : int = 
    WriteFieldStr dest pos "207="B valIn


let WriteNotifyBrokerOfCredit (dest:byte []) (pos:int) (valIn:NotifyBrokerOfCredit) : int = 
    WriteFieldBool dest pos "208="B valIn


let WriteAllocHandlInst (dest:byte array) (nextFreeIdx:int) (xxIn:AllocHandlInst) : int =
    match xxIn with
    | AllocHandlInst.Match ->
        let tag = "209=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocHandlInst.Forward ->
        let tag = "209=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocHandlInst.ForwardAndMatch ->
        let tag = "209=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMaxShow (dest:byte []) (pos:int) (valIn:MaxShow) : int = 
    WriteFieldDecimal dest pos "210="B valIn


let WritePegOffsetValue (dest:byte []) (pos:int) (valIn:PegOffsetValue) : int = 
    WriteFieldDecimal dest pos "211="B valIn


// compound write, of a length field and the corresponding string field
let WriteXmlData (dest:byte []) (pos:int) (fld:XmlData) : int =
    WriteFieldLengthData dest pos "212="B "213="B fld


let WriteSettlInstRefID (dest:byte []) (pos:int) (valIn:SettlInstRefID) : int = 
    WriteFieldStr dest pos "214="B valIn


let WriteNoRoutingIDs (dest:byte []) (pos:int) (valIn:NoRoutingIDs) : int = 
    WriteFieldInt dest pos "215="B valIn


let WriteRoutingType (dest:byte array) (nextFreeIdx:int) (xxIn:RoutingType) : int =
    match xxIn with
    | RoutingType.TargetFirm ->
        let tag = "216=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RoutingType.TargetList ->
        let tag = "216=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RoutingType.BlockFirm ->
        let tag = "216=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RoutingType.BlockList ->
        let tag = "216=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteRoutingID (dest:byte []) (pos:int) (valIn:RoutingID) : int = 
    WriteFieldStr dest pos "217="B valIn


let WriteSpread (dest:byte []) (pos:int) (valIn:Spread) : int = 
    WriteFieldDecimal dest pos "218="B valIn


let WriteBenchmarkCurveCurrency (dest:byte []) (pos:int) (valIn:BenchmarkCurveCurrency) : int = 
    WriteFieldStr dest pos "220="B valIn


let WriteBenchmarkCurveName (dest:byte array) (nextFreeIdx:int) (xxIn:BenchmarkCurveName) : int =
    match xxIn with
    | BenchmarkCurveName.Muniaaa ->
        let tag = "221=MuniAAA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BenchmarkCurveName.Futureswap ->
        let tag = "221=FutureSWAP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BenchmarkCurveName.Libid ->
        let tag = "221=LIBID"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BenchmarkCurveName.Libor ->
        let tag = "221=LIBOR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BenchmarkCurveName.Other ->
        let tag = "221=OTHER"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BenchmarkCurveName.Swap ->
        let tag = "221=SWAP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BenchmarkCurveName.Treasury ->
        let tag = "221=Treasury"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BenchmarkCurveName.Euribor ->
        let tag = "221=Euribor"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BenchmarkCurveName.Pfandbriefe ->
        let tag = "221=Pfandbriefe"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BenchmarkCurveName.Eonia ->
        let tag = "221=EONIA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BenchmarkCurveName.Sonia ->
        let tag = "221=SONIA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BenchmarkCurveName.Eurepo ->
        let tag = "221=EUREPO"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteBenchmarkCurvePoint (dest:byte []) (pos:int) (valIn:BenchmarkCurvePoint) : int = 
    WriteFieldStr dest pos "222="B valIn


let WriteCouponRate (dest:byte []) (pos:int) (valIn:CouponRate) : int = 
    WriteFieldDecimal dest pos "223="B valIn


let WriteCouponPaymentDate (dest:byte []) (pos:int) (valIn:CouponPaymentDate) : int = 
    WriteFieldLocalMktDate dest pos "224="B valIn


let WriteIssueDate (dest:byte []) (pos:int) (valIn:IssueDate) : int = 
    WriteFieldLocalMktDate dest pos "225="B valIn


let WriteRepurchaseTerm (dest:byte []) (pos:int) (valIn:RepurchaseTerm) : int = 
    WriteFieldInt dest pos "226="B valIn


let WriteRepurchaseRate (dest:byte []) (pos:int) (valIn:RepurchaseRate) : int = 
    WriteFieldDecimal dest pos "227="B valIn


let WriteFactor (dest:byte []) (pos:int) (valIn:Factor) : int = 
    WriteFieldDecimal dest pos "228="B valIn


let WriteTradeOriginationDate (dest:byte []) (pos:int) (valIn:TradeOriginationDate) : int = 
    WriteFieldLocalMktDate dest pos "229="B valIn


let WriteExDate (dest:byte []) (pos:int) (valIn:ExDate) : int = 
    WriteFieldLocalMktDate dest pos "230="B valIn


let WriteContractMultiplier (dest:byte []) (pos:int) (valIn:ContractMultiplier) : int = 
    WriteFieldDecimal dest pos "231="B valIn


let WriteNoStipulations (dest:byte []) (pos:int) (valIn:NoStipulations) : int = 
    WriteFieldInt dest pos "232="B valIn


let WriteStipulationType (dest:byte array) (nextFreeIdx:int) (xxIn:StipulationType) : int =
    match xxIn with
    | StipulationType.Amt ->
        let tag = "233=AMT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.AutoReinvestmentAtOrBetter ->
        let tag = "233=AUTOREINV"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.BankQualified ->
        let tag = "233=BANKQUAL"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.BargainConditions ->
        let tag = "233=BGNCON"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.CouponRange ->
        let tag = "233=COUPON"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.IsoCurrencyCode ->
        let tag = "233=CURRENCY"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.CustomStartEndDate ->
        let tag = "233=CUSTOMDATE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.GeographicsAndPercentRange ->
        let tag = "233=GEOG"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.ValuationDiscount ->
        let tag = "233=HAIRCUT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.Insured ->
        let tag = "233=INSURED"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.YearOrYearMonthOfIssue ->
        let tag = "233=ISSUE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.IssuersTicker ->
        let tag = "233=ISSUER"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.IssueSizeRange ->
        let tag = "233=ISSUESIZE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.LookbackDays ->
        let tag = "233=LOOKBACK"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.ExplicitLotIdentifier ->
        let tag = "233=LOT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.LotVariance ->
        let tag = "233=LOTVAR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.MaturityYearAndMonth ->
        let tag = "233=MAT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.MaturityRange ->
        let tag = "233=MATURITY"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.MaximumSubstitutions ->
        let tag = "233=MAXSUBS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.MinimumQuantity ->
        let tag = "233=MINQTY"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.MinimumIncrement ->
        let tag = "233=MININCR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.MinimumDenomination ->
        let tag = "233=MINDNOM"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.PaymentFrequencyCalendar ->
        let tag = "233=PAYFREQ"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.NumberOfPieces ->
        let tag = "233=PIECES"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.PoolsMaximum ->
        let tag = "233=PMAX"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.PoolsPerMillion ->
        let tag = "233=PPM"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.PoolsPerLot ->
        let tag = "233=PPL"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.PoolsPerTrade ->
        let tag = "233=PPT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.PriceRange ->
        let tag = "233=PRICE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.PricingFrequency ->
        let tag = "233=PRICEFREQ"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.ProductionYear ->
        let tag = "233=PROD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.CallProtection ->
        let tag = "233=PROTECT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.Purpose ->
        let tag = "233=PURPOSE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.BenchmarkPriceSource ->
        let tag = "233=PXSOURCE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.RatingSourceAndRange ->
        let tag = "233=RATING"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.Restricted ->
        let tag = "233=RESTRICTED"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.MarketSector ->
        let tag = "233=SECTOR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.SecuritytypeIncludedOrExcluded ->
        let tag = "233=SECTYPE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.Structure ->
        let tag = "233=STRUCT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.SubstitutionsFrequency ->
        let tag = "233=SUBSFREQ"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.SubstitutionsLeft ->
        let tag = "233=SUBSLEFT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.FreeformText ->
        let tag = "233=TEXT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.TradeVariance ->
        let tag = "233=TRDVAR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.WeightedAverageCoupon ->
        let tag = "233=WAC"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.WeightedAverageLifeCoupon ->
        let tag = "233=WAL"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.WeightedAverageLoanAge ->
        let tag = "233=WALA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.WeightedAverageMaturity ->
        let tag = "233=WAM"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.WholePool ->
        let tag = "233=WHOLE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.YieldRange ->
        let tag = "233=YIELD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.SingleMonthlyMortality ->
        let tag = "233=SMM"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.ConstantPrepaymentRate ->
        let tag = "233=CPR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.ConstantPrepaymentYield ->
        let tag = "233=CPY"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.ConstantPrepaymentPenalty ->
        let tag = "233=CPP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.AbsolutePrepaymentSpeed ->
        let tag = "233=ABS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.MonthlyPrepaymentRate ->
        let tag = "233=MPR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.PercentOfBmaPrepaymentCurve ->
        let tag = "233=PSA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.PercentOfProspectusPrepaymentCurve ->
        let tag = "233=PPC"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.PercentOfManufacturedHousingPrepaymentCurve ->
        let tag = "233=MHP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationType.FinalCprOfHomeEquityPrepaymentCurve ->
        let tag = "233=HEP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteStipulationValue (dest:byte array) (nextFreeIdx:int) (xxIn:StipulationValue) : int =
    match xxIn with
    | StipulationValue.SpecialCumDividend ->
        let tag = "234=CD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationValue.SpecialExDividend ->
        let tag = "234=XD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationValue.SpecialCumCoupon ->
        let tag = "234=CC"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationValue.SpecialExCoupon ->
        let tag = "234=XC"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationValue.SpecialCumBonus ->
        let tag = "234=CB"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationValue.SpecialExBonus ->
        let tag = "234=XB"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationValue.SpecialCumRights ->
        let tag = "234=CR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationValue.SpecialExRights ->
        let tag = "234=XR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationValue.SpecialCumCapitalRepayments ->
        let tag = "234=CP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationValue.SpecialExCapitalRepayments ->
        let tag = "234=XP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationValue.CashSettlement ->
        let tag = "234=CS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationValue.SpecialPrice ->
        let tag = "234=SP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationValue.ReportForEuropeanEquityMarketSecurities ->
        let tag = "234=TR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StipulationValue.GuaranteedDelivery ->
        let tag = "234=GD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteYieldType (dest:byte array) (nextFreeIdx:int) (xxIn:YieldType) : int =
    match xxIn with
    | YieldType.AfterTaxYield ->
        let tag = "235=AFTERTAX"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.AnnualYield ->
        let tag = "235=ANNUAL"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.YieldAtIssue ->
        let tag = "235=ATISSUE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.YieldToAverageMaturity ->
        let tag = "235=AVGMATURITY"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.BookYield ->
        let tag = "235=BOOK"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.YieldToNextCall ->
        let tag = "235=CALL"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.YieldChangeSinceClose ->
        let tag = "235=CHANGE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.ClosingYield ->
        let tag = "235=CLOSE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.CompoundYield ->
        let tag = "235=COMPOUND"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.CurrentYield ->
        let tag = "235=CURRENT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.TrueGrossYield ->
        let tag = "235=GROSS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.GovernmentEquivalentYield ->
        let tag = "235=GOVTEQUIV"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.YieldWithInflationAssumption ->
        let tag = "235=INFLATION"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.InverseFloaterBondYield ->
        let tag = "235=INVERSEFLOATER"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.MostRecentClosingYield ->
        let tag = "235=LASTCLOSE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.ClosingYieldMostRecentMonth ->
        let tag = "235=LASTMONTH"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.ClosingYieldMostRecentQuarter ->
        let tag = "235=LASTQUARTER"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.ClosingYieldMostRecentYear ->
        let tag = "235=LASTYEAR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.YieldToLongestAverageLife ->
        let tag = "235=LONGAVGLIFE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.MarkToMarketYield ->
        let tag = "235=MARK"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.YieldToMaturity ->
        let tag = "235=MATURITY"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.YieldToNextRefund ->
        let tag = "235=NEXTREFUND"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.OpenAverageYield ->
        let tag = "235=OPENAVG"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.YieldToNextPut ->
        let tag = "235=PUT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.PreviousCloseYield ->
        let tag = "235=PREVCLOSE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.ProceedsYield ->
        let tag = "235=PROCEEDS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.SemiAnnualYield ->
        let tag = "235=SEMIANNUAL"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.YieldToShortestAverageLife ->
        let tag = "235=SHORTAVGLIFE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.SimpleYield ->
        let tag = "235=SIMPLE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.TaxEquivalentYield ->
        let tag = "235=TAXEQUIV"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.YieldToTenderDate ->
        let tag = "235=TENDER"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.TrueYield ->
        let tag = "235=TRUE"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.YieldValueOf132 ->
        let tag = "235=VALUE1_32"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | YieldType.YieldToWorst ->
        let tag = "235=WORST"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteYield (dest:byte []) (pos:int) (valIn:Yield) : int = 
    WriteFieldDecimal dest pos "236="B valIn


let WriteTotalTakedown (dest:byte []) (pos:int) (valIn:TotalTakedown) : int = 
    WriteFieldDecimal dest pos "237="B valIn


let WriteConcession (dest:byte []) (pos:int) (valIn:Concession) : int = 
    WriteFieldDecimal dest pos "238="B valIn


let WriteRepoCollateralSecurityType (dest:byte []) (pos:int) (valIn:RepoCollateralSecurityType) : int = 
    WriteFieldInt dest pos "239="B valIn


let WriteRedemptionDate (dest:byte []) (pos:int) (valIn:RedemptionDate) : int = 
    WriteFieldLocalMktDate dest pos "240="B valIn


let WriteUnderlyingCouponPaymentDate (dest:byte []) (pos:int) (valIn:UnderlyingCouponPaymentDate) : int = 
    WriteFieldLocalMktDate dest pos "241="B valIn


let WriteUnderlyingIssueDate (dest:byte []) (pos:int) (valIn:UnderlyingIssueDate) : int = 
    WriteFieldLocalMktDate dest pos "242="B valIn


let WriteUnderlyingRepoCollateralSecurityType (dest:byte []) (pos:int) (valIn:UnderlyingRepoCollateralSecurityType) : int = 
    WriteFieldInt dest pos "243="B valIn


let WriteUnderlyingRepurchaseTerm (dest:byte []) (pos:int) (valIn:UnderlyingRepurchaseTerm) : int = 
    WriteFieldInt dest pos "244="B valIn


let WriteUnderlyingRepurchaseRate (dest:byte []) (pos:int) (valIn:UnderlyingRepurchaseRate) : int = 
    WriteFieldDecimal dest pos "245="B valIn


let WriteUnderlyingFactor (dest:byte []) (pos:int) (valIn:UnderlyingFactor) : int = 
    WriteFieldDecimal dest pos "246="B valIn


let WriteUnderlyingRedemptionDate (dest:byte []) (pos:int) (valIn:UnderlyingRedemptionDate) : int = 
    WriteFieldLocalMktDate dest pos "247="B valIn


let WriteLegCouponPaymentDate (dest:byte []) (pos:int) (valIn:LegCouponPaymentDate) : int = 
    WriteFieldLocalMktDate dest pos "248="B valIn


let WriteLegIssueDate (dest:byte []) (pos:int) (valIn:LegIssueDate) : int = 
    WriteFieldLocalMktDate dest pos "249="B valIn


let WriteLegRepoCollateralSecurityType (dest:byte []) (pos:int) (valIn:LegRepoCollateralSecurityType) : int = 
    WriteFieldInt dest pos "250="B valIn


let WriteLegRepurchaseTerm (dest:byte []) (pos:int) (valIn:LegRepurchaseTerm) : int = 
    WriteFieldInt dest pos "251="B valIn


let WriteLegRepurchaseRate (dest:byte []) (pos:int) (valIn:LegRepurchaseRate) : int = 
    WriteFieldDecimal dest pos "252="B valIn


let WriteLegFactor (dest:byte []) (pos:int) (valIn:LegFactor) : int = 
    WriteFieldDecimal dest pos "253="B valIn


let WriteLegRedemptionDate (dest:byte []) (pos:int) (valIn:LegRedemptionDate) : int = 
    WriteFieldLocalMktDate dest pos "254="B valIn


let WriteCreditRating (dest:byte []) (pos:int) (valIn:CreditRating) : int = 
    WriteFieldStr dest pos "255="B valIn


let WriteUnderlyingCreditRating (dest:byte []) (pos:int) (valIn:UnderlyingCreditRating) : int = 
    WriteFieldStr dest pos "256="B valIn


let WriteLegCreditRating (dest:byte []) (pos:int) (valIn:LegCreditRating) : int = 
    WriteFieldStr dest pos "257="B valIn


let WriteTradedFlatSwitch (dest:byte []) (pos:int) (valIn:TradedFlatSwitch) : int = 
    WriteFieldBool dest pos "258="B valIn


let WriteBasisFeatureDate (dest:byte []) (pos:int) (valIn:BasisFeatureDate) : int = 
    WriteFieldLocalMktDate dest pos "259="B valIn


let WriteBasisFeaturePrice (dest:byte []) (pos:int) (valIn:BasisFeaturePrice) : int = 
    WriteFieldDecimal dest pos "260="B valIn


let WriteMDReqID (dest:byte []) (pos:int) (valIn:MDReqID) : int = 
    WriteFieldStr dest pos "262="B valIn


let WriteSubscriptionRequestType (dest:byte array) (nextFreeIdx:int) (xxIn:SubscriptionRequestType) : int =
    match xxIn with
    | SubscriptionRequestType.Snapshot ->
        let tag = "263=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SubscriptionRequestType.SnapshotPlusUpdates ->
        let tag = "263=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SubscriptionRequestType.DisablePreviousSnapshotPlusUpdateRequest ->
        let tag = "263=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMarketDepth (dest:byte []) (pos:int) (valIn:MarketDepth) : int = 
    WriteFieldInt dest pos "264="B valIn


let WriteMDUpdateType (dest:byte array) (nextFreeIdx:int) (xxIn:MDUpdateType) : int =
    match xxIn with
    | MDUpdateType.FullRefresh ->
        let tag = "265=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDUpdateType.IncrementalRefresh ->
        let tag = "265=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteAggregatedBook (dest:byte []) (pos:int) (valIn:AggregatedBook) : int = 
    WriteFieldBool dest pos "266="B valIn


let WriteNoMDEntryTypes (dest:byte []) (pos:int) (valIn:NoMDEntryTypes) : int = 
    WriteFieldInt dest pos "267="B valIn


let WriteNoMDEntries (dest:byte []) (pos:int) (valIn:NoMDEntries) : int = 
    WriteFieldInt dest pos "268="B valIn


let WriteMDEntryType (dest:byte array) (nextFreeIdx:int) (xxIn:MDEntryType) : int =
    match xxIn with
    | MDEntryType.Bid ->
        let tag = "269=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDEntryType.Offer ->
        let tag = "269=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDEntryType.Trade ->
        let tag = "269=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDEntryType.IndexValue ->
        let tag = "269=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDEntryType.OpeningPrice ->
        let tag = "269=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDEntryType.ClosingPrice ->
        let tag = "269=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDEntryType.SettlementPrice ->
        let tag = "269=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDEntryType.TradingSessionHighPrice ->
        let tag = "269=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDEntryType.TradingSessionLowPrice ->
        let tag = "269=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDEntryType.TradingSessionVwapPrice ->
        let tag = "269=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDEntryType.Imbalance ->
        let tag = "269=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDEntryType.TradeVolume ->
        let tag = "269=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDEntryType.OpenInterest ->
        let tag = "269=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMDEntryPx (dest:byte []) (pos:int) (valIn:MDEntryPx) : int = 
    WriteFieldDecimal dest pos "270="B valIn


let WriteMDEntrySize (dest:byte []) (pos:int) (valIn:MDEntrySize) : int = 
    WriteFieldDecimal dest pos "271="B valIn


let WriteMDEntryDate (dest:byte []) (pos:int) (valIn:MDEntryDate) : int = 
    WriteFieldUTCDate dest pos "272="B valIn


let WriteMDEntryTime (dest:byte []) (pos:int) (valIn:MDEntryTime) : int = 
    WriteFieldUTCTimeOnly dest pos "273="B valIn


let WriteTickDirection (dest:byte array) (nextFreeIdx:int) (xxIn:TickDirection) : int =
    match xxIn with
    | TickDirection.PlusTick ->
        let tag = "274=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TickDirection.ZeroPlusTick ->
        let tag = "274=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TickDirection.MinusTick ->
        let tag = "274=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TickDirection.ZeroMinusTick ->
        let tag = "274=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMDMkt (dest:byte []) (pos:int) (valIn:MDMkt) : int = 
    WriteFieldStr dest pos "275="B valIn


let WriteQuoteCondition (dest:byte array) (nextFreeIdx:int) (xxIn:QuoteCondition) : int =
    match xxIn with
    | QuoteCondition.OpenActive ->
        let tag = "276=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteCondition.ClosedInactive ->
        let tag = "276=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteCondition.ExchangeBest ->
        let tag = "276=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteCondition.ConsolidatedBest ->
        let tag = "276=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteCondition.Locked ->
        let tag = "276=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteCondition.Crossed ->
        let tag = "276=F"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteCondition.Depth ->
        let tag = "276=G"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteCondition.FastTrading ->
        let tag = "276=H"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteCondition.NonFirm ->
        let tag = "276=I"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTradeCondition (dest:byte array) (nextFreeIdx:int) (xxIn:TradeCondition) : int =
    match xxIn with
    | TradeCondition.CashMarket ->
        let tag = "277=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.AveragePriceTrade ->
        let tag = "277=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.CashTrade ->
        let tag = "277=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.NextDayMarket ->
        let tag = "277=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.OpeningReopeningTradeDetail ->
        let tag = "277=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.IntradayTradeDetail ->
        let tag = "277=F"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.Rule127 ->
        let tag = "277=G"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.Rule155 ->
        let tag = "277=H"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.SoldLast ->
        let tag = "277=I"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.NextDayTrade ->
        let tag = "277=J"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.Opened ->
        let tag = "277=K"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.Seller ->
        let tag = "277=L"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.Sold ->
        let tag = "277=M"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.StoppedStock ->
        let tag = "277=N"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.ImbalanceMoreBuyers ->
        let tag = "277=P"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.ImbalanceMoreSellers ->
        let tag = "277=Q"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeCondition.OpeningPrice ->
        let tag = "277=R"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMDEntryID (dest:byte []) (pos:int) (valIn:MDEntryID) : int = 
    WriteFieldStr dest pos "278="B valIn


let WriteMDUpdateAction (dest:byte array) (nextFreeIdx:int) (xxIn:MDUpdateAction) : int =
    match xxIn with
    | MDUpdateAction.New ->
        let tag = "279=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDUpdateAction.Change ->
        let tag = "279=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDUpdateAction.Delete ->
        let tag = "279=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMDEntryRefID (dest:byte []) (pos:int) (valIn:MDEntryRefID) : int = 
    WriteFieldStr dest pos "280="B valIn


let WriteMDReqRejReason (dest:byte array) (nextFreeIdx:int) (xxIn:MDReqRejReason) : int =
    match xxIn with
    | MDReqRejReason.UnknownSymbol ->
        let tag = "281=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDReqRejReason.DuplicateMdreqid ->
        let tag = "281=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDReqRejReason.InsufficientBandwidth ->
        let tag = "281=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDReqRejReason.InsufficientPermissions ->
        let tag = "281=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDReqRejReason.UnsupportedSubscriptionrequesttype ->
        let tag = "281=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDReqRejReason.UnsupportedMarketdepth ->
        let tag = "281=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDReqRejReason.UnsupportedMdupdatetype ->
        let tag = "281=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDReqRejReason.UnsupportedAggregatedbook ->
        let tag = "281=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDReqRejReason.UnsupportedMdentrytype ->
        let tag = "281=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDReqRejReason.UnsupportedTradingsessionid ->
        let tag = "281=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDReqRejReason.UnsupportedScope ->
        let tag = "281=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDReqRejReason.UnsupportedOpenclosesettleflag ->
        let tag = "281=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MDReqRejReason.UnsupportedMdimplicitdelete ->
        let tag = "281=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMDEntryOriginator (dest:byte []) (pos:int) (valIn:MDEntryOriginator) : int = 
    WriteFieldStr dest pos "282="B valIn


let WriteLocationID (dest:byte []) (pos:int) (valIn:LocationID) : int = 
    WriteFieldStr dest pos "283="B valIn


let WriteDeskID (dest:byte []) (pos:int) (valIn:DeskID) : int = 
    WriteFieldStr dest pos "284="B valIn


let WriteDeleteReason (dest:byte array) (nextFreeIdx:int) (xxIn:DeleteReason) : int =
    match xxIn with
    | DeleteReason.CancelationTradeBust ->
        let tag = "285=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DeleteReason.Error ->
        let tag = "285=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteOpenCloseSettlFlag (dest:byte array) (nextFreeIdx:int) (xxIn:OpenCloseSettlFlag) : int =
    match xxIn with
    | OpenCloseSettlFlag.DailyOpenCloseSettlementEntry ->
        let tag = "286=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OpenCloseSettlFlag.SessionOpenCloseSettlementEntry ->
        let tag = "286=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OpenCloseSettlFlag.DeliverySettlementEntry ->
        let tag = "286=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OpenCloseSettlFlag.ExpectedEntry ->
        let tag = "286=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OpenCloseSettlFlag.EntryFromPreviousBusinessDay ->
        let tag = "286=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OpenCloseSettlFlag.TheoreticalPriceValue ->
        let tag = "286=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSellerDays (dest:byte []) (pos:int) (valIn:SellerDays) : int = 
    WriteFieldInt dest pos "287="B valIn


let WriteMDEntryBuyer (dest:byte []) (pos:int) (valIn:MDEntryBuyer) : int = 
    WriteFieldStr dest pos "288="B valIn


let WriteMDEntrySeller (dest:byte []) (pos:int) (valIn:MDEntrySeller) : int = 
    WriteFieldStr dest pos "289="B valIn


let WriteMDEntryPositionNo (dest:byte []) (pos:int) (valIn:MDEntryPositionNo) : int = 
    WriteFieldInt dest pos "290="B valIn


let WriteFinancialStatus (dest:byte array) (nextFreeIdx:int) (xxIn:FinancialStatus) : int =
    match xxIn with
    | FinancialStatus.Bankrupt ->
        let tag = "291=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | FinancialStatus.PendingDelisting ->
        let tag = "291=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCorporateAction (dest:byte array) (nextFreeIdx:int) (xxIn:CorporateAction) : int =
    match xxIn with
    | CorporateAction.ExDividend ->
        let tag = "292=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CorporateAction.ExDistribution ->
        let tag = "292=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CorporateAction.ExRights ->
        let tag = "292=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CorporateAction.New ->
        let tag = "292=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CorporateAction.ExInterest ->
        let tag = "292=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteDefBidSize (dest:byte []) (pos:int) (valIn:DefBidSize) : int = 
    WriteFieldDecimal dest pos "293="B valIn


let WriteDefOfferSize (dest:byte []) (pos:int) (valIn:DefOfferSize) : int = 
    WriteFieldDecimal dest pos "294="B valIn


let WriteNoQuoteEntries (dest:byte []) (pos:int) (valIn:NoQuoteEntries) : int = 
    WriteFieldInt dest pos "295="B valIn


let WriteNoQuoteSets (dest:byte []) (pos:int) (valIn:NoQuoteSets) : int = 
    WriteFieldInt dest pos "296="B valIn


let WriteQuoteStatus (dest:byte array) (nextFreeIdx:int) (xxIn:QuoteStatus) : int =
    match xxIn with
    | QuoteStatus.Accepted ->
        let tag = "297=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.CanceledForSymbol ->
        let tag = "297=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.CanceledForSecurityType ->
        let tag = "297=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.CanceledForUnderlying ->
        let tag = "297=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.CanceledAll ->
        let tag = "297=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.Rejected ->
        let tag = "297=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.RemovedFromMarket ->
        let tag = "297=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.Expired ->
        let tag = "297=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.Query ->
        let tag = "297=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.QuoteNotFound ->
        let tag = "297=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.Pending ->
        let tag = "297=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.Pass ->
        let tag = "297=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.LockedMarketWarning ->
        let tag = "297=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.CrossMarketWarning ->
        let tag = "297=13"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.CanceledDueToLockMarket ->
        let tag = "297=14"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteStatus.CanceledDueToCrossMarket ->
        let tag = "297=15"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteQuoteCancelType (dest:byte array) (nextFreeIdx:int) (xxIn:QuoteCancelType) : int =
    match xxIn with
    | QuoteCancelType.CancelForSymbol ->
        let tag = "298=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteCancelType.CancelForSecurityType ->
        let tag = "298=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteCancelType.CancelForUnderlyingSymbol ->
        let tag = "298=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteCancelType.CancelAllQuotes ->
        let tag = "298=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteQuoteEntryID (dest:byte []) (pos:int) (valIn:QuoteEntryID) : int = 
    WriteFieldStr dest pos "299="B valIn


let WriteQuoteRejectReason (dest:byte array) (nextFreeIdx:int) (xxIn:QuoteRejectReason) : int =
    match xxIn with
    | QuoteRejectReason.UnknownSymbol ->
        let tag = "300=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRejectReason.ExchangeClosed ->
        let tag = "300=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRejectReason.QuoteRequestExceedsLimit ->
        let tag = "300=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRejectReason.TooLateToEnter ->
        let tag = "300=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRejectReason.UnknownQuote ->
        let tag = "300=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRejectReason.DuplicateQuote ->
        let tag = "300=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRejectReason.InvalidBidAskSpread ->
        let tag = "300=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRejectReason.InvalidPrice ->
        let tag = "300=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRejectReason.NotAuthorizedToQuoteSecurity ->
        let tag = "300=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRejectReason.Other ->
        let tag = "300=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteQuoteResponseLevel (dest:byte array) (nextFreeIdx:int) (xxIn:QuoteResponseLevel) : int =
    match xxIn with
    | QuoteResponseLevel.NoAcknowledgement ->
        let tag = "301=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteResponseLevel.AcknowledgeOnlyNegativeOrErroneousQuotes ->
        let tag = "301=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteResponseLevel.AcknowledgeEachQuoteMessages ->
        let tag = "301=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteQuoteSetID (dest:byte []) (pos:int) (valIn:QuoteSetID) : int = 
    WriteFieldStr dest pos "302="B valIn


let WriteQuoteRequestType (dest:byte array) (nextFreeIdx:int) (xxIn:QuoteRequestType) : int =
    match xxIn with
    | QuoteRequestType.Manual ->
        let tag = "303=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRequestType.Automatic ->
        let tag = "303=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTotNoQuoteEntries (dest:byte []) (pos:int) (valIn:TotNoQuoteEntries) : int = 
    WriteFieldInt dest pos "304="B valIn


let WriteUnderlyingSecurityIDSource (dest:byte []) (pos:int) (valIn:UnderlyingSecurityIDSource) : int = 
    WriteFieldStr dest pos "305="B valIn


let WriteUnderlyingIssuer (dest:byte []) (pos:int) (valIn:UnderlyingIssuer) : int = 
    WriteFieldStr dest pos "306="B valIn


let WriteUnderlyingSecurityDesc (dest:byte []) (pos:int) (valIn:UnderlyingSecurityDesc) : int = 
    WriteFieldStr dest pos "307="B valIn


let WriteUnderlyingSecurityExchange (dest:byte []) (pos:int) (valIn:UnderlyingSecurityExchange) : int = 
    WriteFieldStr dest pos "308="B valIn


let WriteUnderlyingSecurityID (dest:byte []) (pos:int) (valIn:UnderlyingSecurityID) : int = 
    WriteFieldStr dest pos "309="B valIn


let WriteUnderlyingSecurityType (dest:byte []) (pos:int) (valIn:UnderlyingSecurityType) : int = 
    WriteFieldStr dest pos "310="B valIn


let WriteUnderlyingSymbol (dest:byte []) (pos:int) (valIn:UnderlyingSymbol) : int = 
    WriteFieldStr dest pos "311="B valIn


let WriteUnderlyingSymbolSfx (dest:byte []) (pos:int) (valIn:UnderlyingSymbolSfx) : int = 
    WriteFieldStr dest pos "312="B valIn


let WriteUnderlyingMaturityMonthYear (dest:byte []) (pos:int) (valIn:UnderlyingMaturityMonthYear) : int = 
    WriteFieldMonthYear dest pos "313="B valIn


let WriteUnderlyingPutOrCall (dest:byte array) (nextFreeIdx:int) (xxIn:UnderlyingPutOrCall) : int =
    match xxIn with
    | UnderlyingPutOrCall.Put ->
        let tag = "315=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | UnderlyingPutOrCall.Call ->
        let tag = "315=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteUnderlyingStrikePrice (dest:byte []) (pos:int) (valIn:UnderlyingStrikePrice) : int = 
    WriteFieldDecimal dest pos "316="B valIn


let WriteUnderlyingOptAttribute (dest:byte []) (pos:int) (valIn:UnderlyingOptAttribute) : int = 
    WriteFieldChar dest pos "317="B valIn


let WriteUnderlyingCurrency (dest:byte []) (pos:int) (valIn:UnderlyingCurrency) : int = 
    WriteFieldStr dest pos "318="B valIn


let WriteSecurityReqID (dest:byte []) (pos:int) (valIn:SecurityReqID) : int = 
    WriteFieldStr dest pos "320="B valIn


let WriteSecurityRequestType (dest:byte array) (nextFreeIdx:int) (xxIn:SecurityRequestType) : int =
    match xxIn with
    | SecurityRequestType.RequestSecurityIdentityAndSpecifications ->
        let tag = "321=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityRequestType.RequestSecurityIdentityForTheSpecificationsProvided ->
        let tag = "321=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityRequestType.RequestListSecurityTypes ->
        let tag = "321=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityRequestType.RequestListSecurities ->
        let tag = "321=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSecurityResponseID (dest:byte []) (pos:int) (valIn:SecurityResponseID) : int = 
    WriteFieldStr dest pos "322="B valIn


let WriteSecurityResponseType (dest:byte array) (nextFreeIdx:int) (xxIn:SecurityResponseType) : int =
    match xxIn with
    | SecurityResponseType.AcceptSecurityProposalAsIs ->
        let tag = "323=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityResponseType.AcceptSecurityProposalWithRevisionsAsIndicatedInTheMessage ->
        let tag = "323=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityResponseType.ListOfSecurityTypesReturnedPerRequest ->
        let tag = "323=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityResponseType.ListOfSecuritiesReturnedPerRequest ->
        let tag = "323=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityResponseType.RejectSecurityProposal ->
        let tag = "323=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityResponseType.CanNotMatchSelectionCriteria ->
        let tag = "323=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSecurityStatusReqID (dest:byte []) (pos:int) (valIn:SecurityStatusReqID) : int = 
    WriteFieldStr dest pos "324="B valIn


let WriteUnsolicitedIndicator (dest:byte []) (pos:int) (valIn:UnsolicitedIndicator) : int = 
    WriteFieldBool dest pos "325="B valIn


let WriteSecurityTradingStatus (dest:byte array) (nextFreeIdx:int) (xxIn:SecurityTradingStatus) : int =
    match xxIn with
    | SecurityTradingStatus.OpeningDelay ->
        let tag = "326=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.TradingHalt ->
        let tag = "326=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.Resume ->
        let tag = "326=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.NoOpenNoResume ->
        let tag = "326=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.PriceIndication ->
        let tag = "326=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.TradingRangeIndication ->
        let tag = "326=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.MarketImbalanceBuy ->
        let tag = "326=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.MarketImbalanceSell ->
        let tag = "326=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.MarketOnCloseImbalanceBuy ->
        let tag = "326=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.MarketOnCloseImbalanceSell ->
        let tag = "326=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.NotAssigned ->
        let tag = "326=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.NoMarketImbalance ->
        let tag = "326=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.NoMarketOnCloseImbalance ->
        let tag = "326=13"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.ItsPreOpening ->
        let tag = "326=14"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.NewPriceIndication ->
        let tag = "326=15"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.TradeDisseminationTime ->
        let tag = "326=16"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.ReadyToTradeStartOfSession ->
        let tag = "326=17"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.NotAvailableForTradingEndOfSession ->
        let tag = "326=18"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.NotTradedOnThisMarket ->
        let tag = "326=19"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.UnknownOrInvalid ->
        let tag = "326=20"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.PreOpen ->
        let tag = "326=21"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.OpeningRotation ->
        let tag = "326=22"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityTradingStatus.FastMarket ->
        let tag = "326=23"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteHaltReason (dest:byte array) (nextFreeIdx:int) (xxIn:HaltReason) : int =
    match xxIn with
    | HaltReason.OrderImbalance ->
        let tag = "327=I"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | HaltReason.EquipmentChangeover ->
        let tag = "327=X"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | HaltReason.NewsPending ->
        let tag = "327=P"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | HaltReason.NewsDissemination ->
        let tag = "327=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | HaltReason.OrderInflux ->
        let tag = "327=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | HaltReason.AdditionalInformation ->
        let tag = "327=M"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteInViewOfCommon (dest:byte []) (pos:int) (valIn:InViewOfCommon) : int = 
    WriteFieldBool dest pos "328="B valIn


let WriteDueToRelated (dest:byte []) (pos:int) (valIn:DueToRelated) : int = 
    WriteFieldBool dest pos "329="B valIn


let WriteBuyVolume (dest:byte []) (pos:int) (valIn:BuyVolume) : int = 
    WriteFieldDecimal dest pos "330="B valIn


let WriteSellVolume (dest:byte []) (pos:int) (valIn:SellVolume) : int = 
    WriteFieldDecimal dest pos "331="B valIn


let WriteHighPx (dest:byte []) (pos:int) (valIn:HighPx) : int = 
    WriteFieldDecimal dest pos "332="B valIn


let WriteLowPx (dest:byte []) (pos:int) (valIn:LowPx) : int = 
    WriteFieldDecimal dest pos "333="B valIn


let WriteAdjustment (dest:byte array) (nextFreeIdx:int) (xxIn:Adjustment) : int =
    match xxIn with
    | Adjustment.Cancel ->
        let tag = "334=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Adjustment.Error ->
        let tag = "334=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Adjustment.Correction ->
        let tag = "334=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTradSesReqID (dest:byte []) (pos:int) (valIn:TradSesReqID) : int = 
    WriteFieldStr dest pos "335="B valIn


let WriteTradingSessionID (dest:byte []) (pos:int) (valIn:TradingSessionID) : int = 
    WriteFieldStr dest pos "336="B valIn


let WriteContraTrader (dest:byte []) (pos:int) (valIn:ContraTrader) : int = 
    WriteFieldStr dest pos "337="B valIn


let WriteTradSesMethod (dest:byte array) (nextFreeIdx:int) (xxIn:TradSesMethod) : int =
    match xxIn with
    | TradSesMethod.Electronic ->
        let tag = "338=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradSesMethod.OpenOutcry ->
        let tag = "338=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradSesMethod.TwoParty ->
        let tag = "338=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTradSesMode (dest:byte array) (nextFreeIdx:int) (xxIn:TradSesMode) : int =
    match xxIn with
    | TradSesMode.Testing ->
        let tag = "339=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradSesMode.Simulated ->
        let tag = "339=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradSesMode.Production ->
        let tag = "339=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTradSesStatus (dest:byte array) (nextFreeIdx:int) (xxIn:TradSesStatus) : int =
    match xxIn with
    | TradSesStatus.Unknown ->
        let tag = "340=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradSesStatus.Halted ->
        let tag = "340=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradSesStatus.Open ->
        let tag = "340=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradSesStatus.Closed ->
        let tag = "340=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradSesStatus.PreOpen ->
        let tag = "340=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradSesStatus.PreClose ->
        let tag = "340=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradSesStatus.RequestRejected ->
        let tag = "340=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTradSesStartTime (dest:byte []) (pos:int) (valIn:TradSesStartTime) : int = 
    WriteFieldUTCTimestamp dest pos "341="B valIn


let WriteTradSesOpenTime (dest:byte []) (pos:int) (valIn:TradSesOpenTime) : int = 
    WriteFieldUTCTimestamp dest pos "342="B valIn


let WriteTradSesPreCloseTime (dest:byte []) (pos:int) (valIn:TradSesPreCloseTime) : int = 
    WriteFieldUTCTimestamp dest pos "343="B valIn


let WriteTradSesCloseTime (dest:byte []) (pos:int) (valIn:TradSesCloseTime) : int = 
    WriteFieldUTCTimestamp dest pos "344="B valIn


let WriteTradSesEndTime (dest:byte []) (pos:int) (valIn:TradSesEndTime) : int = 
    WriteFieldUTCTimestamp dest pos "345="B valIn


let WriteNumberOfOrders (dest:byte []) (pos:int) (valIn:NumberOfOrders) : int = 
    WriteFieldInt dest pos "346="B valIn


let WriteMessageEncoding (dest:byte array) (nextFreeIdx:int) (xxIn:MessageEncoding) : int =
    match xxIn with
    | MessageEncoding.Iso2022Jp ->
        let tag = "347=ISO-2022-JP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MessageEncoding.EucJp ->
        let tag = "347=EUC-JP"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MessageEncoding.ShiftJis ->
        let tag = "347=SHIFT_JIS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MessageEncoding.Utf8 ->
        let tag = "347=UTF-8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteEncodedIssuer (dest:byte []) (pos:int) (fld:EncodedIssuer) : int =
    WriteFieldLengthData dest pos "348="B "349="B fld


// compound write, of a length field and the corresponding string field
let WriteEncodedSecurityDesc (dest:byte []) (pos:int) (fld:EncodedSecurityDesc) : int =
    WriteFieldLengthData dest pos "350="B "351="B fld


// compound write, of a length field and the corresponding string field
let WriteEncodedListExecInst (dest:byte []) (pos:int) (fld:EncodedListExecInst) : int =
    WriteFieldLengthData dest pos "352="B "353="B fld


// compound write, of a length field and the corresponding string field
let WriteEncodedText (dest:byte []) (pos:int) (fld:EncodedText) : int =
    WriteFieldLengthData dest pos "354="B "355="B fld


// compound write, of a length field and the corresponding string field
let WriteEncodedSubject (dest:byte []) (pos:int) (fld:EncodedSubject) : int =
    WriteFieldLengthData dest pos "356="B "357="B fld


// compound write, of a length field and the corresponding string field
let WriteEncodedHeadline (dest:byte []) (pos:int) (fld:EncodedHeadline) : int =
    WriteFieldLengthData dest pos "358="B "359="B fld


// compound write, of a length field and the corresponding string field
let WriteEncodedAllocText (dest:byte []) (pos:int) (fld:EncodedAllocText) : int =
    WriteFieldLengthData dest pos "360="B "361="B fld


// compound write, of a length field and the corresponding string field
let WriteEncodedUnderlyingIssuer (dest:byte []) (pos:int) (fld:EncodedUnderlyingIssuer) : int =
    WriteFieldLengthData dest pos "362="B "363="B fld


// compound write, of a length field and the corresponding string field
let WriteEncodedUnderlyingSecurityDesc (dest:byte []) (pos:int) (fld:EncodedUnderlyingSecurityDesc) : int =
    WriteFieldLengthData dest pos "364="B "365="B fld


let WriteAllocPrice (dest:byte []) (pos:int) (valIn:AllocPrice) : int = 
    WriteFieldDecimal dest pos "366="B valIn


let WriteQuoteSetValidUntilTime (dest:byte []) (pos:int) (valIn:QuoteSetValidUntilTime) : int = 
    WriteFieldUTCTimestamp dest pos "367="B valIn


let WriteQuoteEntryRejectReason (dest:byte array) (nextFreeIdx:int) (xxIn:QuoteEntryRejectReason) : int =
    match xxIn with
    | QuoteEntryRejectReason.UnknownSymbol ->
        let tag = "368=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteEntryRejectReason.ExchangeClosed ->
        let tag = "368=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteEntryRejectReason.QuoteExceedsLimit ->
        let tag = "368=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteEntryRejectReason.TooLateToEnter ->
        let tag = "368=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteEntryRejectReason.UnknownQuote ->
        let tag = "368=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteEntryRejectReason.DuplicateQuote ->
        let tag = "368=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteEntryRejectReason.InvalidBidAskSpread ->
        let tag = "368=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteEntryRejectReason.InvalidPrice ->
        let tag = "368=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteEntryRejectReason.NotAuthorizedToQuoteSecurity ->
        let tag = "368=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteLastMsgSeqNumProcessed (dest:byte []) (pos:int) (valIn:LastMsgSeqNumProcessed) : int = 
    WriteFieldUint32 dest pos "369="B valIn


let WriteRefTagID (dest:byte []) (pos:int) (valIn:RefTagID) : int = 
    WriteFieldInt dest pos "371="B valIn


let WriteRefMsgType (dest:byte []) (pos:int) (valIn:RefMsgType) : int = 
    WriteFieldStr dest pos "372="B valIn


let WriteSessionRejectReason (dest:byte array) (nextFreeIdx:int) (xxIn:SessionRejectReason) : int =
    match xxIn with
    | SessionRejectReason.InvalidTagNumber ->
        let tag = "373=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.RequiredTagMissing ->
        let tag = "373=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.TagNotDefinedForThisMessageType ->
        let tag = "373=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.UndefinedTag ->
        let tag = "373=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.TagSpecifiedWithoutAValue ->
        let tag = "373=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.ValueIsIncorrect ->
        let tag = "373=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.IncorrectDataFormatForValue ->
        let tag = "373=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.DecryptionProblem ->
        let tag = "373=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.SignatureProblem ->
        let tag = "373=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.CompidProblem ->
        let tag = "373=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.SendingtimeAccuracyProblem ->
        let tag = "373=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.InvalidMsgtype ->
        let tag = "373=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.XmlValidationError ->
        let tag = "373=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.TagAppearsMoreThanOnce ->
        let tag = "373=13"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.TagSpecifiedOutOfRequiredOrder ->
        let tag = "373=14"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.RepeatingGroupFieldsOutOfOrder ->
        let tag = "373=15"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.IncorrectNumingroupCountForRepeatingGroup ->
        let tag = "373=16"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.NonDataValueIncludesFieldDelimiter ->
        let tag = "373=17"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SessionRejectReason.Other ->
        let tag = "373=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteBidRequestTransType (dest:byte array) (nextFreeIdx:int) (xxIn:BidRequestTransType) : int =
    match xxIn with
    | BidRequestTransType.New ->
        let tag = "374=N"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BidRequestTransType.Cancel ->
        let tag = "374=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteContraBroker (dest:byte []) (pos:int) (valIn:ContraBroker) : int = 
    WriteFieldStr dest pos "375="B valIn


let WriteComplianceID (dest:byte []) (pos:int) (valIn:ComplianceID) : int = 
    WriteFieldStr dest pos "376="B valIn


let WriteSolicitedFlag (dest:byte []) (pos:int) (valIn:SolicitedFlag) : int = 
    WriteFieldBool dest pos "377="B valIn


let WriteExecRestatementReason (dest:byte array) (nextFreeIdx:int) (xxIn:ExecRestatementReason) : int =
    match xxIn with
    | ExecRestatementReason.GtCorporateAction ->
        let tag = "378=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecRestatementReason.GtRenewalRestatement ->
        let tag = "378=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecRestatementReason.VerbalChange ->
        let tag = "378=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecRestatementReason.RepricingOfOrder ->
        let tag = "378=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecRestatementReason.BrokerOption ->
        let tag = "378=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecRestatementReason.PartialDeclineOfOrderqty ->
        let tag = "378=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecRestatementReason.CancelOnTradingHalt ->
        let tag = "378=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecRestatementReason.CancelOnSystemFailure ->
        let tag = "378=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecRestatementReason.MarketOption ->
        let tag = "378=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecRestatementReason.CanceledNotBest ->
        let tag = "378=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteBusinessRejectRefID (dest:byte []) (pos:int) (valIn:BusinessRejectRefID) : int = 
    WriteFieldStr dest pos "379="B valIn


let WriteBusinessRejectReason (dest:byte array) (nextFreeIdx:int) (xxIn:BusinessRejectReason) : int =
    match xxIn with
    | BusinessRejectReason.Other ->
        let tag = "380=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BusinessRejectReason.UnkownId ->
        let tag = "380=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BusinessRejectReason.UnknownSecurity ->
        let tag = "380=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BusinessRejectReason.UnsupportedMessageType ->
        let tag = "380=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BusinessRejectReason.ApplicationNotAvailable ->
        let tag = "380=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BusinessRejectReason.ConditionallyRequiredFieldMissing ->
        let tag = "380=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BusinessRejectReason.NotAuthorized ->
        let tag = "380=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BusinessRejectReason.DelivertoFirmNotAvailableAtThisTime ->
        let tag = "380=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteGrossTradeAmt (dest:byte []) (pos:int) (valIn:GrossTradeAmt) : int = 
    WriteFieldDecimal dest pos "381="B valIn


let WriteNoContraBrokers (dest:byte []) (pos:int) (valIn:NoContraBrokers) : int = 
    WriteFieldInt dest pos "382="B valIn


let WriteMaxMessageSize (dest:byte []) (pos:int) (valIn:MaxMessageSize) : int = 
    WriteFieldUint32 dest pos "383="B valIn


let WriteNoMsgTypes (dest:byte []) (pos:int) (valIn:NoMsgTypes) : int = 
    WriteFieldInt dest pos "384="B valIn


let WriteMsgDirection (dest:byte array) (nextFreeIdx:int) (xxIn:MsgDirection) : int =
    match xxIn with
    | MsgDirection.Send ->
        let tag = "385=S"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgDirection.Receive ->
        let tag = "385=R"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoTradingSessions (dest:byte []) (pos:int) (valIn:NoTradingSessions) : int = 
    WriteFieldInt dest pos "386="B valIn


let WriteTotalVolumeTraded (dest:byte []) (pos:int) (valIn:TotalVolumeTraded) : int = 
    WriteFieldDecimal dest pos "387="B valIn


let WriteDiscretionInst (dest:byte array) (nextFreeIdx:int) (xxIn:DiscretionInst) : int =
    match xxIn with
    | DiscretionInst.RelatedToDisplayedPrice ->
        let tag = "388=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionInst.RelatedToMarketPrice ->
        let tag = "388=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionInst.RelatedToPrimaryPrice ->
        let tag = "388=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionInst.RelatedToLocalPrimaryPrice ->
        let tag = "388=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionInst.RelatedToMidpointPrice ->
        let tag = "388=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionInst.RelatedToLastTradePrice ->
        let tag = "388=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionInst.RelatedToVwap ->
        let tag = "388=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteDiscretionOffsetValue (dest:byte []) (pos:int) (valIn:DiscretionOffsetValue) : int = 
    WriteFieldDecimal dest pos "389="B valIn


let WriteBidID (dest:byte []) (pos:int) (valIn:BidID) : int = 
    WriteFieldStr dest pos "390="B valIn


let WriteClientBidID (dest:byte []) (pos:int) (valIn:ClientBidID) : int = 
    WriteFieldStr dest pos "391="B valIn


let WriteListName (dest:byte []) (pos:int) (valIn:ListName) : int = 
    WriteFieldStr dest pos "392="B valIn


let WriteTotNoRelatedSym (dest:byte []) (pos:int) (valIn:TotNoRelatedSym) : int = 
    WriteFieldInt dest pos "393="B valIn


let WriteBidType (dest:byte array) (nextFreeIdx:int) (xxIn:BidType) : int =
    match xxIn with
    | BidType.NonDisclosed ->
        let tag = "394=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BidType.DisclosedStyle ->
        let tag = "394=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BidType.NoBiddingProcess ->
        let tag = "394=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNumTickets (dest:byte []) (pos:int) (valIn:NumTickets) : int = 
    WriteFieldInt dest pos "395="B valIn


let WriteSideValue1 (dest:byte []) (pos:int) (valIn:SideValue1) : int = 
    WriteFieldDecimal dest pos "396="B valIn


let WriteSideValue2 (dest:byte []) (pos:int) (valIn:SideValue2) : int = 
    WriteFieldDecimal dest pos "397="B valIn


let WriteNoBidDescriptors (dest:byte []) (pos:int) (valIn:NoBidDescriptors) : int = 
    WriteFieldInt dest pos "398="B valIn


let WriteBidDescriptorType (dest:byte array) (nextFreeIdx:int) (xxIn:BidDescriptorType) : int =
    match xxIn with
    | BidDescriptorType.Sector ->
        let tag = "399=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BidDescriptorType.Ccountry ->
        let tag = "399=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BidDescriptorType.Index ->
        let tag = "399=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteBidDescriptor (dest:byte []) (pos:int) (valIn:BidDescriptor) : int = 
    WriteFieldStr dest pos "400="B valIn


let WriteSideValueInd (dest:byte array) (nextFreeIdx:int) (xxIn:SideValueInd) : int =
    match xxIn with
    | SideValueInd.Sidevalue1 ->
        let tag = "401=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SideValueInd.Sidevalue2 ->
        let tag = "401=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteLiquidityPctLow (dest:byte []) (pos:int) (valIn:LiquidityPctLow) : int = 
    WriteFieldDecimal dest pos "402="B valIn


let WriteLiquidityPctHigh (dest:byte []) (pos:int) (valIn:LiquidityPctHigh) : int = 
    WriteFieldDecimal dest pos "403="B valIn


let WriteLiquidityValue (dest:byte []) (pos:int) (valIn:LiquidityValue) : int = 
    WriteFieldDecimal dest pos "404="B valIn


let WriteEFPTrackingError (dest:byte []) (pos:int) (valIn:EFPTrackingError) : int = 
    WriteFieldDecimal dest pos "405="B valIn


let WriteFairValue (dest:byte []) (pos:int) (valIn:FairValue) : int = 
    WriteFieldDecimal dest pos "406="B valIn


let WriteOutsideIndexPct (dest:byte []) (pos:int) (valIn:OutsideIndexPct) : int = 
    WriteFieldDecimal dest pos "407="B valIn


let WriteValueOfFutures (dest:byte []) (pos:int) (valIn:ValueOfFutures) : int = 
    WriteFieldDecimal dest pos "408="B valIn


let WriteLiquidityIndType (dest:byte array) (nextFreeIdx:int) (xxIn:LiquidityIndType) : int =
    match xxIn with
    | LiquidityIndType.FivedayMovingAverage ->
        let tag = "409=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | LiquidityIndType.TwentydayMovingAverage ->
        let tag = "409=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | LiquidityIndType.NormalMarketSize ->
        let tag = "409=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | LiquidityIndType.Other ->
        let tag = "409=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteWtAverageLiquidity (dest:byte []) (pos:int) (valIn:WtAverageLiquidity) : int = 
    WriteFieldDecimal dest pos "410="B valIn


let WriteExchangeForPhysical (dest:byte []) (pos:int) (valIn:ExchangeForPhysical) : int = 
    WriteFieldBool dest pos "411="B valIn


let WriteOutMainCntryUIndex (dest:byte []) (pos:int) (valIn:OutMainCntryUIndex) : int = 
    WriteFieldDecimal dest pos "412="B valIn


let WriteCrossPercent (dest:byte []) (pos:int) (valIn:CrossPercent) : int = 
    WriteFieldDecimal dest pos "413="B valIn


let WriteProgRptReqs (dest:byte array) (nextFreeIdx:int) (xxIn:ProgRptReqs) : int =
    match xxIn with
    | ProgRptReqs.BuysideExplicitlyRequestsStatusUsingStatusrequest ->
        let tag = "414=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ProgRptReqs.SellsidePeriodicallySendsStatusUsingListstatus ->
        let tag = "414=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ProgRptReqs.RealTimeExecutionReports ->
        let tag = "414=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteProgPeriodInterval (dest:byte []) (pos:int) (valIn:ProgPeriodInterval) : int = 
    WriteFieldInt dest pos "415="B valIn


let WriteIncTaxInd (dest:byte array) (nextFreeIdx:int) (xxIn:IncTaxInd) : int =
    match xxIn with
    | IncTaxInd.Net ->
        let tag = "416=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | IncTaxInd.Gross ->
        let tag = "416=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNumBidders (dest:byte []) (pos:int) (valIn:NumBidders) : int = 
    WriteFieldInt dest pos "417="B valIn


let WriteBidTradeType (dest:byte array) (nextFreeIdx:int) (xxIn:BidTradeType) : int =
    match xxIn with
    | BidTradeType.RiskTrade ->
        let tag = "418=R"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BidTradeType.VwapGuarantee ->
        let tag = "418=G"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BidTradeType.Agency ->
        let tag = "418=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BidTradeType.GuaranteedClose ->
        let tag = "418=J"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteBasisPxType (dest:byte array) (nextFreeIdx:int) (xxIn:BasisPxType) : int =
    match xxIn with
    | BasisPxType.ClosingPriceAtMorningSession ->
        let tag = "419=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BasisPxType.ClosingPrice ->
        let tag = "419=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BasisPxType.CurrentPrice ->
        let tag = "419=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BasisPxType.Sq ->
        let tag = "419=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BasisPxType.VwapThroughADay ->
        let tag = "419=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BasisPxType.VwapThroughAMorningSession ->
        let tag = "419=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BasisPxType.VwapThroughAnAfternoonSession ->
        let tag = "419=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BasisPxType.VwapThroughADayExceptYori ->
        let tag = "419=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BasisPxType.VwapThroughAMorningSessionExceptYori ->
        let tag = "419=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BasisPxType.VwapThroughAnAfternoonSessionExceptYori ->
        let tag = "419=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BasisPxType.Strike ->
        let tag = "419=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BasisPxType.Open ->
        let tag = "419=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BasisPxType.Others ->
        let tag = "419=Z"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoBidComponents (dest:byte []) (pos:int) (valIn:NoBidComponents) : int = 
    WriteFieldInt dest pos "420="B valIn


let WriteCountry (dest:byte []) (pos:int) (valIn:Country) : int = 
    WriteFieldStr dest pos "421="B valIn


let WriteTotNoStrikes (dest:byte []) (pos:int) (valIn:TotNoStrikes) : int = 
    WriteFieldInt dest pos "422="B valIn


let WritePriceType (dest:byte array) (nextFreeIdx:int) (xxIn:PriceType) : int =
    match xxIn with
    | PriceType.Percentage ->
        let tag = "423=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PriceType.PerUnit ->
        let tag = "423=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PriceType.FixedAmount ->
        let tag = "423=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PriceType.Discount ->
        let tag = "423=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PriceType.Premium ->
        let tag = "423=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PriceType.Spread ->
        let tag = "423=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PriceType.TedPrice ->
        let tag = "423=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PriceType.TedYield ->
        let tag = "423=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PriceType.Yield ->
        let tag = "423=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PriceType.FixedCabinetTradePrice ->
        let tag = "423=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PriceType.VariableCabinetTradePrice ->
        let tag = "423=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteDayOrderQty (dest:byte []) (pos:int) (valIn:DayOrderQty) : int = 
    WriteFieldDecimal dest pos "424="B valIn


let WriteDayCumQty (dest:byte []) (pos:int) (valIn:DayCumQty) : int = 
    WriteFieldDecimal dest pos "425="B valIn


let WriteDayAvgPx (dest:byte []) (pos:int) (valIn:DayAvgPx) : int = 
    WriteFieldDecimal dest pos "426="B valIn


let WriteGTBookingInst (dest:byte array) (nextFreeIdx:int) (xxIn:GTBookingInst) : int =
    match xxIn with
    | GTBookingInst.BookOutAllTradesOnDayOfExecution ->
        let tag = "427=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | GTBookingInst.AccumulateExecutionsUntilOrderIsFilledOrExpires ->
        let tag = "427=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | GTBookingInst.AccumulateUntilVerballyNotifiedOtherwise ->
        let tag = "427=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoStrikes (dest:byte []) (pos:int) (valIn:NoStrikes) : int = 
    WriteFieldInt dest pos "428="B valIn


let WriteListStatusType (dest:byte array) (nextFreeIdx:int) (xxIn:ListStatusType) : int =
    match xxIn with
    | ListStatusType.Ack ->
        let tag = "429=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListStatusType.Response ->
        let tag = "429=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListStatusType.Timed ->
        let tag = "429=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListStatusType.Execstarted ->
        let tag = "429=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListStatusType.Alldone ->
        let tag = "429=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListStatusType.Alert ->
        let tag = "429=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNetGrossInd (dest:byte array) (nextFreeIdx:int) (xxIn:NetGrossInd) : int =
    match xxIn with
    | NetGrossInd.Net ->
        let tag = "430=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | NetGrossInd.Gross ->
        let tag = "430=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteListOrderStatus (dest:byte array) (nextFreeIdx:int) (xxIn:ListOrderStatus) : int =
    match xxIn with
    | ListOrderStatus.Inbiddingprocess ->
        let tag = "431=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListOrderStatus.Receivedforexecution ->
        let tag = "431=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListOrderStatus.Executing ->
        let tag = "431=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListOrderStatus.Canceling ->
        let tag = "431=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListOrderStatus.Alert ->
        let tag = "431=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListOrderStatus.AllDone ->
        let tag = "431=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListOrderStatus.Reject ->
        let tag = "431=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteExpireDate (dest:byte []) (pos:int) (valIn:ExpireDate) : int = 
    WriteFieldLocalMktDate dest pos "432="B valIn


let WriteListExecInstType (dest:byte array) (nextFreeIdx:int) (xxIn:ListExecInstType) : int =
    match xxIn with
    | ListExecInstType.Immediate ->
        let tag = "433=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListExecInstType.WaitForExecuteInstruction ->
        let tag = "433=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListExecInstType.ExchangeSwitchCivOrderSellDriven ->
        let tag = "433=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListExecInstType.ExchangeSwitchCivOrderBuyDrivenCashTopUp ->
        let tag = "433=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ListExecInstType.ExchangeSwitchCivOrderBuyDrivenCashWithdraw ->
        let tag = "433=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCxlRejResponseTo (dest:byte array) (nextFreeIdx:int) (xxIn:CxlRejResponseTo) : int =
    match xxIn with
    | CxlRejResponseTo.OrderCancelRequest ->
        let tag = "434=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CxlRejResponseTo.OrderCancelReplaceRequest ->
        let tag = "434=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteUnderlyingCouponRate (dest:byte []) (pos:int) (valIn:UnderlyingCouponRate) : int = 
    WriteFieldDecimal dest pos "435="B valIn


let WriteUnderlyingContractMultiplier (dest:byte []) (pos:int) (valIn:UnderlyingContractMultiplier) : int = 
    WriteFieldDecimal dest pos "436="B valIn


let WriteContraTradeQty (dest:byte []) (pos:int) (valIn:ContraTradeQty) : int = 
    WriteFieldDecimal dest pos "437="B valIn


let WriteContraTradeTime (dest:byte []) (pos:int) (valIn:ContraTradeTime) : int = 
    WriteFieldUTCTimestamp dest pos "438="B valIn


let WriteLiquidityNumSecurities (dest:byte []) (pos:int) (valIn:LiquidityNumSecurities) : int = 
    WriteFieldInt dest pos "441="B valIn


let WriteMultiLegReportingType (dest:byte array) (nextFreeIdx:int) (xxIn:MultiLegReportingType) : int =
    match xxIn with
    | MultiLegReportingType.SingleSecurity ->
        let tag = "442=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MultiLegReportingType.IndividualLegOfAMultiLegSecurity ->
        let tag = "442=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MultiLegReportingType.MultiLegSecurity ->
        let tag = "442=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteStrikeTime (dest:byte []) (pos:int) (valIn:StrikeTime) : int = 
    WriteFieldUTCTimestamp dest pos "443="B valIn


let WriteListStatusText (dest:byte []) (pos:int) (valIn:ListStatusText) : int = 
    WriteFieldStr dest pos "444="B valIn


// compound write, of a length field and the corresponding string field
let WriteEncodedListStatusText (dest:byte []) (pos:int) (fld:EncodedListStatusText) : int =
    WriteFieldLengthData dest pos "445="B "446="B fld


let WritePartyIDSource (dest:byte array) (nextFreeIdx:int) (xxIn:PartyIDSource) : int =
    match xxIn with
    | PartyIDSource.Bic ->
        let tag = "447=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.GenerallyAcceptedMarketParticipantIdentifier ->
        let tag = "447=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.ProprietaryCustomCode ->
        let tag = "447=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.IsoCountryCode ->
        let tag = "447=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.SettlementEntityLocation ->
        let tag = "447=F"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.Mic ->
        let tag = "447=G"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.CsdParticipantMemberCode ->
        let tag = "447=H"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.KoreanInvestorId ->
        let tag = "447=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.TaiwaneseQualifiedForeignInvestorIdQfiiFid ->
        let tag = "447=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.TaiwaneseTradingAccount ->
        let tag = "447=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.MalaysianCentralDepositoryNumber ->
        let tag = "447=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.ChineseBShare ->
        let tag = "447=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.UkNationalInsuranceOrPensionNumber ->
        let tag = "447=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.UsSocialSecurityNumber ->
        let tag = "447=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.UsEmployerIdentificationNumber ->
        let tag = "447=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.AustralianBusinessNumber ->
        let tag = "447=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.AustralianTaxFileNumber ->
        let tag = "447=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyIDSource.DirectedBroker ->
        let tag = "447=I"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePartyID (dest:byte []) (pos:int) (valIn:PartyID) : int = 
    WriteFieldStr dest pos "448="B valIn


let WriteNetChgPrevDay (dest:byte []) (pos:int) (valIn:NetChgPrevDay) : int = 
    WriteFieldDecimal dest pos "451="B valIn


let WritePartyRole (dest:byte array) (nextFreeIdx:int) (xxIn:PartyRole) : int =
    match xxIn with
    | PartyRole.ExecutingFirm ->
        let tag = "452=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.BrokerOfCredit ->
        let tag = "452=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.ClientId ->
        let tag = "452=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.ClearingFirm ->
        let tag = "452=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.InvestorId ->
        let tag = "452=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.IntroducingFirm ->
        let tag = "452=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.EnteringFirm ->
        let tag = "452=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.LocateLendingFirm ->
        let tag = "452=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.FundManagerClientId ->
        let tag = "452=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.SettlementLocation ->
        let tag = "452=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.OrderOriginationTrader ->
        let tag = "452=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.ExecutingTrader ->
        let tag = "452=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.OrderOriginationFirm ->
        let tag = "452=13"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.GiveupClearingFirm ->
        let tag = "452=14"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.CorrespondantClearingFirm ->
        let tag = "452=15"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.ExecutingSystem ->
        let tag = "452=16"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.ContraFirm ->
        let tag = "452=17"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.ContraClearingFirm ->
        let tag = "452=18"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.SponsoringFirm ->
        let tag = "452=19"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.UnderlyingContraFirm ->
        let tag = "452=20"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.ClearingOrganization ->
        let tag = "452=21"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.Exchange ->
        let tag = "452=22"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.CustomerAccount ->
        let tag = "452=24"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.CorrespondentClearingOrganization ->
        let tag = "452=25"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.CorrespondentBroker ->
        let tag = "452=26"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.BuyerSeller ->
        let tag = "452=27"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.Custodian ->
        let tag = "452=28"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.Intermediary ->
        let tag = "452=29"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.Agent ->
        let tag = "452=30"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.SubCustodian ->
        let tag = "452=31"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.Beneficiary ->
        let tag = "452=32"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.InterestedParty ->
        let tag = "452=33"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.RegulatoryBody ->
        let tag = "452=34"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.LiquidityProvider ->
        let tag = "452=35"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.EnteringTrader ->
        let tag = "452=36"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.ContraTrader ->
        let tag = "452=37"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PartyRole.PositionAccount ->
        let tag = "452=38"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoPartyIDs (dest:byte []) (pos:int) (valIn:NoPartyIDs) : int = 
    WriteFieldInt dest pos "453="B valIn


let WriteNoSecurityAltID (dest:byte []) (pos:int) (valIn:NoSecurityAltID) : int = 
    WriteFieldInt dest pos "454="B valIn


let WriteSecurityAltID (dest:byte []) (pos:int) (valIn:SecurityAltID) : int = 
    WriteFieldStr dest pos "455="B valIn


let WriteSecurityAltIDSource (dest:byte []) (pos:int) (valIn:SecurityAltIDSource) : int = 
    WriteFieldStr dest pos "456="B valIn


let WriteNoUnderlyingSecurityAltID (dest:byte []) (pos:int) (valIn:NoUnderlyingSecurityAltID) : int = 
    WriteFieldInt dest pos "457="B valIn


let WriteUnderlyingSecurityAltID (dest:byte []) (pos:int) (valIn:UnderlyingSecurityAltID) : int = 
    WriteFieldStr dest pos "458="B valIn


let WriteUnderlyingSecurityAltIDSource (dest:byte []) (pos:int) (valIn:UnderlyingSecurityAltIDSource) : int = 
    WriteFieldStr dest pos "459="B valIn


let WriteProduct (dest:byte array) (nextFreeIdx:int) (xxIn:Product) : int =
    match xxIn with
    | Product.Agency ->
        let tag = "460=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Product.Commodity ->
        let tag = "460=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Product.Corporate ->
        let tag = "460=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Product.Currency ->
        let tag = "460=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Product.Equity ->
        let tag = "460=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Product.Government ->
        let tag = "460=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Product.Index ->
        let tag = "460=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Product.Loan ->
        let tag = "460=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Product.Moneymarket ->
        let tag = "460=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Product.Mortgage ->
        let tag = "460=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Product.Municipal ->
        let tag = "460=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Product.Other ->
        let tag = "460=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Product.Financing ->
        let tag = "460=13"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCFICode (dest:byte []) (pos:int) (valIn:CFICode) : int = 
    WriteFieldStr dest pos "461="B valIn


let WriteUnderlyingProduct (dest:byte []) (pos:int) (valIn:UnderlyingProduct) : int = 
    WriteFieldInt dest pos "462="B valIn


let WriteUnderlyingCFICode (dest:byte []) (pos:int) (valIn:UnderlyingCFICode) : int = 
    WriteFieldStr dest pos "463="B valIn


let WriteTestMessageIndicator (dest:byte []) (pos:int) (valIn:TestMessageIndicator) : int = 
    WriteFieldBool dest pos "464="B valIn


let WriteQuantityType (dest:byte array) (nextFreeIdx:int) (xxIn:QuantityType) : int =
    match xxIn with
    | QuantityType.Shares ->
        let tag = "465=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuantityType.Bonds ->
        let tag = "465=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuantityType.Currentface ->
        let tag = "465=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuantityType.Originalface ->
        let tag = "465=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuantityType.Currency ->
        let tag = "465=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuantityType.Contracts ->
        let tag = "465=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuantityType.Other ->
        let tag = "465=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuantityType.Par ->
        let tag = "465=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteBookingRefID (dest:byte []) (pos:int) (valIn:BookingRefID) : int = 
    WriteFieldStr dest pos "466="B valIn


let WriteIndividualAllocID (dest:byte []) (pos:int) (valIn:IndividualAllocID) : int = 
    WriteFieldStr dest pos "467="B valIn


let WriteRoundingDirection (dest:byte array) (nextFreeIdx:int) (xxIn:RoundingDirection) : int =
    match xxIn with
    | RoundingDirection.RoundToNearest ->
        let tag = "468=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RoundingDirection.RoundDown ->
        let tag = "468=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RoundingDirection.RoundUp ->
        let tag = "468=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteRoundingModulus (dest:byte []) (pos:int) (valIn:RoundingModulus) : int = 
    WriteFieldDecimal dest pos "469="B valIn


let WriteCountryOfIssue (dest:byte []) (pos:int) (valIn:CountryOfIssue) : int = 
    WriteFieldStr dest pos "470="B valIn


let WriteStateOrProvinceOfIssue (dest:byte []) (pos:int) (valIn:StateOrProvinceOfIssue) : int = 
    WriteFieldStr dest pos "471="B valIn


let WriteLocaleOfIssue (dest:byte []) (pos:int) (valIn:LocaleOfIssue) : int = 
    WriteFieldStr dest pos "472="B valIn


let WriteNoRegistDtls (dest:byte []) (pos:int) (valIn:NoRegistDtls) : int = 
    WriteFieldInt dest pos "473="B valIn


let WriteMailingDtls (dest:byte []) (pos:int) (valIn:MailingDtls) : int = 
    WriteFieldStr dest pos "474="B valIn


let WriteInvestorCountryOfResidence (dest:byte []) (pos:int) (valIn:InvestorCountryOfResidence) : int = 
    WriteFieldStr dest pos "475="B valIn


let WritePaymentRef (dest:byte []) (pos:int) (valIn:PaymentRef) : int = 
    WriteFieldStr dest pos "476="B valIn


let WriteDistribPaymentMethod (dest:byte array) (nextFreeIdx:int) (xxIn:DistribPaymentMethod) : int =
    match xxIn with
    | DistribPaymentMethod.Crest ->
        let tag = "477=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DistribPaymentMethod.Nscc ->
        let tag = "477=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DistribPaymentMethod.Euroclear ->
        let tag = "477=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DistribPaymentMethod.Clearstream ->
        let tag = "477=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DistribPaymentMethod.Cheque ->
        let tag = "477=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DistribPaymentMethod.TelegraphicTransfer ->
        let tag = "477=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DistribPaymentMethod.Fedwire ->
        let tag = "477=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DistribPaymentMethod.DirectCredit ->
        let tag = "477=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DistribPaymentMethod.AchCredit ->
        let tag = "477=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DistribPaymentMethod.Bpay ->
        let tag = "477=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DistribPaymentMethod.HighValueClearingSystem ->
        let tag = "477=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DistribPaymentMethod.ReinvestInFund ->
        let tag = "477=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCashDistribCurr (dest:byte []) (pos:int) (valIn:CashDistribCurr) : int = 
    WriteFieldStr dest pos "478="B valIn


let WriteCommCurrency (dest:byte []) (pos:int) (valIn:CommCurrency) : int = 
    WriteFieldStr dest pos "479="B valIn


let WriteCancellationRights (dest:byte array) (nextFreeIdx:int) (xxIn:CancellationRights) : int =
    match xxIn with
    | CancellationRights.Yes ->
        let tag = "480=Y"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CancellationRights.NoExecutionOnly ->
        let tag = "480=N"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CancellationRights.NoWaiverAgreement ->
        let tag = "480=M"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CancellationRights.NoInstitutional ->
        let tag = "480=O"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMoneyLaunderingStatus (dest:byte array) (nextFreeIdx:int) (xxIn:MoneyLaunderingStatus) : int =
    match xxIn with
    | MoneyLaunderingStatus.Passed ->
        let tag = "481=Y"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MoneyLaunderingStatus.NotChecked ->
        let tag = "481=N"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MoneyLaunderingStatus.ExemptBelowTheLimit ->
        let tag = "481=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MoneyLaunderingStatus.ExemptClientMoneyTypeExemption ->
        let tag = "481=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MoneyLaunderingStatus.ExemptAuthorisedCreditOrFinancialInstitution ->
        let tag = "481=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMailingInst (dest:byte []) (pos:int) (valIn:MailingInst) : int = 
    WriteFieldStr dest pos "482="B valIn


let WriteTransBkdTime (dest:byte []) (pos:int) (valIn:TransBkdTime) : int = 
    WriteFieldUTCTimestamp dest pos "483="B valIn


let WriteExecPriceType (dest:byte array) (nextFreeIdx:int) (xxIn:ExecPriceType) : int =
    match xxIn with
    | ExecPriceType.BidPrice ->
        let tag = "484=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecPriceType.CreationPrice ->
        let tag = "484=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecPriceType.CreationPricePlusAdjustmentPercent ->
        let tag = "484=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecPriceType.CreationPricePlusAdjustmentAmount ->
        let tag = "484=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecPriceType.OfferPrice ->
        let tag = "484=O"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecPriceType.OfferPriceMinusAdjustmentPercent ->
        let tag = "484=P"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecPriceType.OfferPriceMinusAdjustmentAmount ->
        let tag = "484=Q"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExecPriceType.SinglePrice ->
        let tag = "484=S"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteExecPriceAdjustment (dest:byte []) (pos:int) (valIn:ExecPriceAdjustment) : int = 
    WriteFieldDecimal dest pos "485="B valIn


let WriteDateOfBirth (dest:byte []) (pos:int) (valIn:DateOfBirth) : int = 
    WriteFieldLocalMktDate dest pos "486="B valIn


let WriteTradeReportTransType (dest:byte array) (nextFreeIdx:int) (xxIn:TradeReportTransType) : int =
    match xxIn with
    | TradeReportTransType.New ->
        let tag = "487=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportTransType.Cancel ->
        let tag = "487=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportTransType.Replace ->
        let tag = "487=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportTransType.Release ->
        let tag = "487=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportTransType.Reverse ->
        let tag = "487=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCardHolderName (dest:byte []) (pos:int) (valIn:CardHolderName) : int = 
    WriteFieldStr dest pos "488="B valIn


let WriteCardNumber (dest:byte []) (pos:int) (valIn:CardNumber) : int = 
    WriteFieldStr dest pos "489="B valIn


let WriteCardExpDate (dest:byte []) (pos:int) (valIn:CardExpDate) : int = 
    WriteFieldLocalMktDate dest pos "490="B valIn


let WriteCardIssNum (dest:byte []) (pos:int) (valIn:CardIssNum) : int = 
    WriteFieldStr dest pos "491="B valIn


let WritePaymentMethod (dest:byte array) (nextFreeIdx:int) (xxIn:PaymentMethod) : int =
    match xxIn with
    | PaymentMethod.Crest ->
        let tag = "492=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.Nscc ->
        let tag = "492=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.Euroclear ->
        let tag = "492=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.Clearstream ->
        let tag = "492=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.Cheque ->
        let tag = "492=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.TelegraphicTransfer ->
        let tag = "492=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.Fedwire ->
        let tag = "492=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.DebitCard ->
        let tag = "492=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.DirectDebit ->
        let tag = "492=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.DirectCredit ->
        let tag = "492=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.CreditCard ->
        let tag = "492=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.AchDebit ->
        let tag = "492=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.AchCredit ->
        let tag = "492=13"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.Bpay ->
        let tag = "492=14"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PaymentMethod.HighValueClearingSystem ->
        let tag = "492=15"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteRegistAcctType (dest:byte []) (pos:int) (valIn:RegistAcctType) : int = 
    WriteFieldStr dest pos "493="B valIn


let WriteDesignation (dest:byte []) (pos:int) (valIn:Designation) : int = 
    WriteFieldStr dest pos "494="B valIn


let WriteTaxAdvantageType (dest:byte array) (nextFreeIdx:int) (xxIn:TaxAdvantageType) : int =
    match xxIn with
    | TaxAdvantageType.NNone ->
        let tag = "495=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TaxAdvantageType.MaxiIsa ->
        let tag = "495=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TaxAdvantageType.Tessa ->
        let tag = "495=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TaxAdvantageType.MiniCashIsa ->
        let tag = "495=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TaxAdvantageType.MiniStocksAndSharesIsa ->
        let tag = "495=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TaxAdvantageType.MiniInsuranceIsa ->
        let tag = "495=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TaxAdvantageType.CurrentYearPayment ->
        let tag = "495=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TaxAdvantageType.PriorYearPayment ->
        let tag = "495=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TaxAdvantageType.AssetTransfer ->
        let tag = "495=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TaxAdvantageType.EmployeePriorYear ->
        let tag = "495=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TaxAdvantageType.Other ->
        let tag = "495=999"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteRegistRejReasonText (dest:byte []) (pos:int) (valIn:RegistRejReasonText) : int = 
    WriteFieldStr dest pos "496="B valIn


let WriteFundRenewWaiv (dest:byte array) (nextFreeIdx:int) (xxIn:FundRenewWaiv) : int =
    match xxIn with
    | FundRenewWaiv.Yes ->
        let tag = "497=Y"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | FundRenewWaiv.No ->
        let tag = "497=N"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCashDistribAgentName (dest:byte []) (pos:int) (valIn:CashDistribAgentName) : int = 
    WriteFieldStr dest pos "498="B valIn


let WriteCashDistribAgentCode (dest:byte []) (pos:int) (valIn:CashDistribAgentCode) : int = 
    WriteFieldStr dest pos "499="B valIn


let WriteCashDistribAgentAcctNumber (dest:byte []) (pos:int) (valIn:CashDistribAgentAcctNumber) : int = 
    WriteFieldStr dest pos "500="B valIn


let WriteCashDistribPayRef (dest:byte []) (pos:int) (valIn:CashDistribPayRef) : int = 
    WriteFieldStr dest pos "501="B valIn


let WriteCashDistribAgentAcctName (dest:byte []) (pos:int) (valIn:CashDistribAgentAcctName) : int = 
    WriteFieldStr dest pos "502="B valIn


let WriteCardStartDate (dest:byte []) (pos:int) (valIn:CardStartDate) : int = 
    WriteFieldLocalMktDate dest pos "503="B valIn


let WritePaymentDate (dest:byte []) (pos:int) (valIn:PaymentDate) : int = 
    WriteFieldLocalMktDate dest pos "504="B valIn


let WritePaymentRemitterID (dest:byte []) (pos:int) (valIn:PaymentRemitterID) : int = 
    WriteFieldStr dest pos "505="B valIn


let WriteRegistStatus (dest:byte array) (nextFreeIdx:int) (xxIn:RegistStatus) : int =
    match xxIn with
    | RegistStatus.Accepted ->
        let tag = "506=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistStatus.Rejected ->
        let tag = "506=R"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistStatus.Held ->
        let tag = "506=H"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistStatus.Reminder ->
        let tag = "506=N"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteRegistRejReasonCode (dest:byte array) (nextFreeIdx:int) (xxIn:RegistRejReasonCode) : int =
    match xxIn with
    | RegistRejReasonCode.InvalidUnacceptableAccountType ->
        let tag = "507=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableTaxExemptType ->
        let tag = "507=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableOwnershipType ->
        let tag = "507=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableNoRegDetls ->
        let tag = "507=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableRegSeqNo ->
        let tag = "507=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableRegDtls ->
        let tag = "507=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableMailingDtls ->
        let tag = "507=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableMailingInst ->
        let tag = "507=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableInvestorId ->
        let tag = "507=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableInvestorIdSource ->
        let tag = "507=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableDateOfBirth ->
        let tag = "507=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableInvestorCountryOfResidence ->
        let tag = "507=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableNodistribinstns ->
        let tag = "507=13"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableDistribPercentage ->
        let tag = "507=14"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableDistribPaymentMethod ->
        let tag = "507=15"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableCashDistribAgentAcctName ->
        let tag = "507=16"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableCashDistribAgentCode ->
        let tag = "507=17"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.InvalidUnacceptableCashDistribAgentAcctNum ->
        let tag = "507=18"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistRejReasonCode.Other ->
        let tag = "507=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteRegistRefID (dest:byte []) (pos:int) (valIn:RegistRefID) : int = 
    WriteFieldStr dest pos "508="B valIn


let WriteRegistDtls (dest:byte []) (pos:int) (valIn:RegistDtls) : int = 
    WriteFieldStr dest pos "509="B valIn


let WriteNoDistribInsts (dest:byte []) (pos:int) (valIn:NoDistribInsts) : int = 
    WriteFieldInt dest pos "510="B valIn


let WriteRegistEmail (dest:byte []) (pos:int) (valIn:RegistEmail) : int = 
    WriteFieldStr dest pos "511="B valIn


let WriteDistribPercentage (dest:byte []) (pos:int) (valIn:DistribPercentage) : int = 
    WriteFieldDecimal dest pos "512="B valIn


let WriteRegistID (dest:byte []) (pos:int) (valIn:RegistID) : int = 
    WriteFieldStr dest pos "513="B valIn


let WriteRegistTransType (dest:byte array) (nextFreeIdx:int) (xxIn:RegistTransType) : int =
    match xxIn with
    | RegistTransType.New ->
        let tag = "514=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistTransType.Replace ->
        let tag = "514=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | RegistTransType.Cancel ->
        let tag = "514=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteExecValuationPoint (dest:byte []) (pos:int) (valIn:ExecValuationPoint) : int = 
    WriteFieldUTCTimestamp dest pos "515="B valIn


let WriteOrderPercent (dest:byte []) (pos:int) (valIn:OrderPercent) : int = 
    WriteFieldDecimal dest pos "516="B valIn


let WriteOwnershipType (dest:byte array) (nextFreeIdx:int) (xxIn:OwnershipType) : int =
    match xxIn with
    | OwnershipType.JointInvestors ->
        let tag = "517=J"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnershipType.TenantsInCommon ->
        let tag = "517=T"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnershipType.JointTrustees ->
        let tag = "517=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoContAmts (dest:byte []) (pos:int) (valIn:NoContAmts) : int = 
    WriteFieldInt dest pos "518="B valIn


let WriteContAmtType (dest:byte array) (nextFreeIdx:int) (xxIn:ContAmtType) : int =
    match xxIn with
    | ContAmtType.CommissionAmount ->
        let tag = "519=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ContAmtType.CommissionPercent ->
        let tag = "519=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ContAmtType.InitialChargeAmount ->
        let tag = "519=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ContAmtType.InitialChargePercent ->
        let tag = "519=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ContAmtType.DiscountAmount ->
        let tag = "519=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ContAmtType.DiscountPercent ->
        let tag = "519=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ContAmtType.DilutionLevyAmount ->
        let tag = "519=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ContAmtType.DilutionLevyPercent ->
        let tag = "519=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ContAmtType.ExitChargeAmount ->
        let tag = "519=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteContAmtValue (dest:byte []) (pos:int) (valIn:ContAmtValue) : int = 
    WriteFieldDecimal dest pos "520="B valIn


let WriteContAmtCurr (dest:byte []) (pos:int) (valIn:ContAmtCurr) : int = 
    WriteFieldStr dest pos "521="B valIn


let WriteOwnerType (dest:byte array) (nextFreeIdx:int) (xxIn:OwnerType) : int =
    match xxIn with
    | OwnerType.IndividualInvestor ->
        let tag = "522=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnerType.PublicCompany ->
        let tag = "522=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnerType.PrivateCompany ->
        let tag = "522=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnerType.IndividualTrustee ->
        let tag = "522=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnerType.CompanyTrustee ->
        let tag = "522=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnerType.PensionPlan ->
        let tag = "522=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnerType.CustodianUnderGiftsToMinorsAct ->
        let tag = "522=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnerType.Trusts ->
        let tag = "522=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnerType.Fiduciaries ->
        let tag = "522=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnerType.NetworkingSubAccount ->
        let tag = "522=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnerType.NonProfitOrganization ->
        let tag = "522=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnerType.CorporateBody ->
        let tag = "522=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OwnerType.Nominee ->
        let tag = "522=13"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePartySubID (dest:byte []) (pos:int) (valIn:PartySubID) : int = 
    WriteFieldStr dest pos "523="B valIn


let WriteNestedPartyID (dest:byte []) (pos:int) (valIn:NestedPartyID) : int = 
    WriteFieldStr dest pos "524="B valIn


let WriteNestedPartyIDSource (dest:byte []) (pos:int) (valIn:NestedPartyIDSource) : int = 
    WriteFieldChar dest pos "525="B valIn


let WriteSecondaryClOrdID (dest:byte []) (pos:int) (valIn:SecondaryClOrdID) : int = 
    WriteFieldStr dest pos "526="B valIn


let WriteSecondaryExecID (dest:byte []) (pos:int) (valIn:SecondaryExecID) : int = 
    WriteFieldStr dest pos "527="B valIn


let WriteOrderCapacity (dest:byte array) (nextFreeIdx:int) (xxIn:OrderCapacity) : int =
    match xxIn with
    | OrderCapacity.Agency ->
        let tag = "528=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderCapacity.Proprietary ->
        let tag = "528=G"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderCapacity.Individual ->
        let tag = "528=I"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderCapacity.Principal ->
        let tag = "528=P"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderCapacity.RisklessPrincipal ->
        let tag = "528=R"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderCapacity.AgentForOtherMember ->
        let tag = "528=W"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteOrderRestrictions (dest:byte array) (nextFreeIdx:int) (xxIn:OrderRestrictions) : int =
    match xxIn with
    | OrderRestrictions.ProgramTrade ->
        let tag = "529=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderRestrictions.IndexArbitrage ->
        let tag = "529=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderRestrictions.NonIndexArbitrage ->
        let tag = "529=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderRestrictions.CompetingMarketMaker ->
        let tag = "529=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderRestrictions.ActingAsMarketMakerOrSpecialistInTheSecurity ->
        let tag = "529=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderRestrictions.ActingAsMarketMakerOrSpecialistInTheUnderlyingSecurityOfADerivativeSecurity ->
        let tag = "529=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderRestrictions.ForeignEntity ->
        let tag = "529=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderRestrictions.ExternalMarketParticipant ->
        let tag = "529=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderRestrictions.ExternalInterConnectedMarketLinkage ->
        let tag = "529=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | OrderRestrictions.RisklessArbitrage ->
        let tag = "529=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMassCancelRequestType (dest:byte array) (nextFreeIdx:int) (xxIn:MassCancelRequestType) : int =
    match xxIn with
    | MassCancelRequestType.CancelOrdersForASecurity ->
        let tag = "530=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelRequestType.CancelOrdersForAnUnderlyingSecurity ->
        let tag = "530=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelRequestType.CancelOrdersForAProduct ->
        let tag = "530=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelRequestType.CancelOrdersForACficode ->
        let tag = "530=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelRequestType.CancelOrdersForASecuritytype ->
        let tag = "530=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelRequestType.CancelOrdersForATradingSession ->
        let tag = "530=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelRequestType.CancelAllOrders ->
        let tag = "530=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMassCancelResponse (dest:byte array) (nextFreeIdx:int) (xxIn:MassCancelResponse) : int =
    match xxIn with
    | MassCancelResponse.CancelRequestRejected ->
        let tag = "531=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelResponse.CancelOrdersForASecurity ->
        let tag = "531=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelResponse.CancelOrdersForAnUnderlyingSecurity ->
        let tag = "531=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelResponse.CancelOrdersForAProduct ->
        let tag = "531=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelResponse.CancelOrdersForACficode ->
        let tag = "531=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelResponse.CancelOrdersForASecuritytype ->
        let tag = "531=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelResponse.CancelOrdersForATradingSession ->
        let tag = "531=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelResponse.CancelAllOrders ->
        let tag = "531=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMassCancelRejectReason (dest:byte array) (nextFreeIdx:int) (xxIn:MassCancelRejectReason) : int =
    match xxIn with
    | MassCancelRejectReason.MassCancelNotSupported ->
        let tag = "532=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelRejectReason.InvalidOrUnknownSecurity ->
        let tag = "532=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelRejectReason.InvalidOrUnknownUnderlying ->
        let tag = "532=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelRejectReason.InvalidOrUnknownProduct ->
        let tag = "532=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelRejectReason.InvalidOrUnknownCficode ->
        let tag = "532=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelRejectReason.InvalidOrUnknownSecurityType ->
        let tag = "532=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelRejectReason.InvalidOrUnknownTradingSession ->
        let tag = "532=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassCancelRejectReason.Other ->
        let tag = "532=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTotalAffectedOrders (dest:byte []) (pos:int) (valIn:TotalAffectedOrders) : int = 
    WriteFieldInt dest pos "533="B valIn


let WriteNoAffectedOrders (dest:byte []) (pos:int) (valIn:NoAffectedOrders) : int = 
    WriteFieldInt dest pos "534="B valIn


let WriteAffectedOrderID (dest:byte []) (pos:int) (valIn:AffectedOrderID) : int = 
    WriteFieldStr dest pos "535="B valIn


let WriteAffectedSecondaryOrderID (dest:byte []) (pos:int) (valIn:AffectedSecondaryOrderID) : int = 
    WriteFieldStr dest pos "536="B valIn


let WriteQuoteType (dest:byte array) (nextFreeIdx:int) (xxIn:QuoteType) : int =
    match xxIn with
    | QuoteType.Indicative ->
        let tag = "537=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteType.Tradeable ->
        let tag = "537=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteType.RestrictedTradeable ->
        let tag = "537=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteType.Counter ->
        let tag = "537=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNestedPartyRole (dest:byte []) (pos:int) (valIn:NestedPartyRole) : int = 
    WriteFieldInt dest pos "538="B valIn


let WriteNoNestedPartyIDs (dest:byte []) (pos:int) (valIn:NoNestedPartyIDs) : int = 
    WriteFieldInt dest pos "539="B valIn


let WriteTotalAccruedInterestAmt (dest:byte []) (pos:int) (valIn:TotalAccruedInterestAmt) : int = 
    WriteFieldDecimal dest pos "540="B valIn


let WriteMaturityDate (dest:byte []) (pos:int) (valIn:MaturityDate) : int = 
    WriteFieldLocalMktDate dest pos "541="B valIn


let WriteUnderlyingMaturityDate (dest:byte []) (pos:int) (valIn:UnderlyingMaturityDate) : int = 
    WriteFieldLocalMktDate dest pos "542="B valIn


let WriteInstrRegistry (dest:byte []) (pos:int) (valIn:InstrRegistry) : int = 
    WriteFieldStr dest pos "543="B valIn


let WriteCashMargin (dest:byte array) (nextFreeIdx:int) (xxIn:CashMargin) : int =
    match xxIn with
    | CashMargin.Cash ->
        let tag = "544=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CashMargin.MarginOpen ->
        let tag = "544=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CashMargin.MarginClose ->
        let tag = "544=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNestedPartySubID (dest:byte []) (pos:int) (valIn:NestedPartySubID) : int = 
    WriteFieldStr dest pos "545="B valIn


let WriteScope (dest:byte array) (nextFreeIdx:int) (xxIn:Scope) : int =
    match xxIn with
    | Scope.Local ->
        let tag = "546=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Scope.National ->
        let tag = "546=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | Scope.Global ->
        let tag = "546=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMDImplicitDelete (dest:byte []) (pos:int) (valIn:MDImplicitDelete) : int = 
    WriteFieldBool dest pos "547="B valIn


let WriteCrossID (dest:byte []) (pos:int) (valIn:CrossID) : int = 
    WriteFieldStr dest pos "548="B valIn


let WriteCrossType (dest:byte array) (nextFreeIdx:int) (xxIn:CrossType) : int =
    match xxIn with
    | CrossType.CrossTradeWhichIsExecutedCompletelyOrNot ->
        let tag = "549=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CrossType.CrossTradeWhichIsExecutedPartiallyAndTheRestIsCancelled ->
        let tag = "549=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CrossType.CrossTradeWhichIsPartiallyExecutedWithTheUnfilledPortionsRemainingActive ->
        let tag = "549=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CrossType.CrossTradeIsExecutedWithExistingOrdersWithTheSamePrice ->
        let tag = "549=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCrossPrioritization (dest:byte array) (nextFreeIdx:int) (xxIn:CrossPrioritization) : int =
    match xxIn with
    | CrossPrioritization.NNone ->
        let tag = "550=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CrossPrioritization.BuySideIsPrioritized ->
        let tag = "550=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CrossPrioritization.SellSideIsPrioritized ->
        let tag = "550=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteOrigCrossID (dest:byte []) (pos:int) (valIn:OrigCrossID) : int = 
    WriteFieldStr dest pos "551="B valIn


let WriteNoSides (dest:byte array) (nextFreeIdx:int) (xxIn:NoSides) : int =
    match xxIn with
    | NoSides.OneSide ->
        let tag = "552=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | NoSides.BothSides ->
        let tag = "552=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteUsername (dest:byte []) (pos:int) (valIn:Username) : int = 
    WriteFieldStr dest pos "553="B valIn


let WritePassword (dest:byte []) (pos:int) (valIn:Password) : int = 
    WriteFieldStr dest pos "554="B valIn


let WriteNoLegs (dest:byte []) (pos:int) (valIn:NoLegs) : int = 
    WriteFieldInt dest pos "555="B valIn


let WriteLegCurrency (dest:byte []) (pos:int) (valIn:LegCurrency) : int = 
    WriteFieldStr dest pos "556="B valIn


let WriteTotNoSecurityTypes (dest:byte []) (pos:int) (valIn:TotNoSecurityTypes) : int = 
    WriteFieldInt dest pos "557="B valIn


let WriteNoSecurityTypes (dest:byte []) (pos:int) (valIn:NoSecurityTypes) : int = 
    WriteFieldInt dest pos "558="B valIn


let WriteSecurityListRequestType (dest:byte array) (nextFreeIdx:int) (xxIn:SecurityListRequestType) : int =
    match xxIn with
    | SecurityListRequestType.Symbol ->
        let tag = "559=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityListRequestType.SecuritytypeAndOrCficode ->
        let tag = "559=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityListRequestType.Product ->
        let tag = "559=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityListRequestType.Tradingsessionid ->
        let tag = "559=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityListRequestType.AllSecurities ->
        let tag = "559=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSecurityRequestResult (dest:byte array) (nextFreeIdx:int) (xxIn:SecurityRequestResult) : int =
    match xxIn with
    | SecurityRequestResult.ValidRequest ->
        let tag = "560=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityRequestResult.InvalidOrUnsupportedRequest ->
        let tag = "560=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityRequestResult.NoInstrumentsFoundThatMatchSelectionCriteria ->
        let tag = "560=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityRequestResult.NotAuthorizedToRetrieveInstrumentData ->
        let tag = "560=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityRequestResult.InstrumentDataTemporarilyUnavailable ->
        let tag = "560=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SecurityRequestResult.RequestForInstrumentDataNotSupported ->
        let tag = "560=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteRoundLot (dest:byte []) (pos:int) (valIn:RoundLot) : int = 
    WriteFieldDecimal dest pos "561="B valIn


let WriteMinTradeVol (dest:byte []) (pos:int) (valIn:MinTradeVol) : int = 
    WriteFieldDecimal dest pos "562="B valIn


let WriteMultiLegRptTypeReq (dest:byte array) (nextFreeIdx:int) (xxIn:MultiLegRptTypeReq) : int =
    match xxIn with
    | MultiLegRptTypeReq.ReportByMulitlegSecurityOnly ->
        let tag = "563=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MultiLegRptTypeReq.ReportByMultilegSecurityAndByInstrumentLegsBelongingToTheMultilegSecurity ->
        let tag = "563=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MultiLegRptTypeReq.ReportByInstrumentLegsBelongingToTheMultilegSecurityOnly ->
        let tag = "563=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteLegPositionEffect (dest:byte []) (pos:int) (valIn:LegPositionEffect) : int = 
    WriteFieldChar dest pos "564="B valIn


let WriteLegCoveredOrUncovered (dest:byte []) (pos:int) (valIn:LegCoveredOrUncovered) : int = 
    WriteFieldInt dest pos "565="B valIn


let WriteLegPrice (dest:byte []) (pos:int) (valIn:LegPrice) : int = 
    WriteFieldDecimal dest pos "566="B valIn


let WriteTradSesStatusRejReason (dest:byte array) (nextFreeIdx:int) (xxIn:TradSesStatusRejReason) : int =
    match xxIn with
    | TradSesStatusRejReason.UnknownOrInvalidTradingsessionid ->
        let tag = "567=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTradeRequestID (dest:byte []) (pos:int) (valIn:TradeRequestID) : int = 
    WriteFieldStr dest pos "568="B valIn


let WriteTradeRequestType (dest:byte array) (nextFreeIdx:int) (xxIn:TradeRequestType) : int =
    match xxIn with
    | TradeRequestType.AllTrades ->
        let tag = "569=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestType.MatchedTradesMatchingCriteriaProvidedOnRequest ->
        let tag = "569=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestType.UnmatchedTradesThatMatchCriteria ->
        let tag = "569=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestType.UnreportedTradesThatMatchCriteria ->
        let tag = "569=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestType.AdvisoriesThatMatchCriteria ->
        let tag = "569=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePreviouslyReported (dest:byte []) (pos:int) (valIn:PreviouslyReported) : int = 
    WriteFieldBool dest pos "570="B valIn


let WriteTradeReportID (dest:byte []) (pos:int) (valIn:TradeReportID) : int = 
    WriteFieldStr dest pos "571="B valIn


let WriteTradeReportRefID (dest:byte []) (pos:int) (valIn:TradeReportRefID) : int = 
    WriteFieldStr dest pos "572="B valIn


let WriteMatchStatus (dest:byte array) (nextFreeIdx:int) (xxIn:MatchStatus) : int =
    match xxIn with
    | MatchStatus.ComparedMatchedOrAffirmed ->
        let tag = "573=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MatchStatus.UncomparedUnmatchedOrUnaffirmed ->
        let tag = "573=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MatchStatus.AdvisoryOrAlert ->
        let tag = "573=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteMatchType (dest:byte []) (pos:int) (valIn:MatchType) : int = 
    WriteFieldStr dest pos "574="B valIn


let WriteOddLot (dest:byte []) (pos:int) (valIn:OddLot) : int = 
    WriteFieldBool dest pos "575="B valIn


let WriteNoClearingInstructions (dest:byte []) (pos:int) (valIn:NoClearingInstructions) : int = 
    WriteFieldInt dest pos "576="B valIn


let WriteClearingInstruction (dest:byte array) (nextFreeIdx:int) (xxIn:ClearingInstruction) : int =
    match xxIn with
    | ClearingInstruction.ProcessNormally ->
        let tag = "577=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingInstruction.ExcludeFromAllNetting ->
        let tag = "577=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingInstruction.BilateralNettingOnly ->
        let tag = "577=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingInstruction.ExClearing ->
        let tag = "577=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingInstruction.SpecialTrade ->
        let tag = "577=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingInstruction.MultilateralNetting ->
        let tag = "577=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingInstruction.ClearAgainstCentralCounterparty ->
        let tag = "577=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingInstruction.ExcludeFromCentralCounterparty ->
        let tag = "577=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingInstruction.ManualMode ->
        let tag = "577=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingInstruction.AutomaticPostingMode ->
        let tag = "577=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingInstruction.AutomaticGiveUpMode ->
        let tag = "577=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingInstruction.QualifiedServiceRepresentative ->
        let tag = "577=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingInstruction.CustomerTrade ->
        let tag = "577=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingInstruction.SelfClearing ->
        let tag = "577=13"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTradeInputSource (dest:byte []) (pos:int) (valIn:TradeInputSource) : int = 
    WriteFieldStr dest pos "578="B valIn


let WriteTradeInputDevice (dest:byte []) (pos:int) (valIn:TradeInputDevice) : int = 
    WriteFieldStr dest pos "579="B valIn


let WriteNoDates (dest:byte []) (pos:int) (valIn:NoDates) : int = 
    WriteFieldInt dest pos "580="B valIn


let WriteAccountType (dest:byte array) (nextFreeIdx:int) (xxIn:AccountType) : int =
    match xxIn with
    | AccountType.AccountIsCarriedOnCustomerSideOfBooks ->
        let tag = "581=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AccountType.AccountIsCarriedOnNonCustomerSideOfBooks ->
        let tag = "581=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AccountType.HouseTrader ->
        let tag = "581=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AccountType.FloorTrader ->
        let tag = "581=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AccountType.AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined ->
        let tag = "581=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AccountType.AccountIsHouseTraderAndIsCrossMargined ->
        let tag = "581=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AccountType.JointBackofficeAccount ->
        let tag = "581=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCustOrderCapacity (dest:byte array) (nextFreeIdx:int) (xxIn:CustOrderCapacity) : int =
    match xxIn with
    | CustOrderCapacity.MemberTradingForTheirOwnAccount ->
        let tag = "582=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CustOrderCapacity.ClearingFirmTradingForItsProprietaryAccount ->
        let tag = "582=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CustOrderCapacity.MemberTradingForAnotherMember ->
        let tag = "582=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CustOrderCapacity.AllOther ->
        let tag = "582=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteClOrdLinkID (dest:byte []) (pos:int) (valIn:ClOrdLinkID) : int = 
    WriteFieldStr dest pos "583="B valIn


let WriteMassStatusReqID (dest:byte []) (pos:int) (valIn:MassStatusReqID) : int = 
    WriteFieldStr dest pos "584="B valIn


let WriteMassStatusReqType (dest:byte array) (nextFreeIdx:int) (xxIn:MassStatusReqType) : int =
    match xxIn with
    | MassStatusReqType.StatusForOrdersForASecurity ->
        let tag = "585=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassStatusReqType.StatusForOrdersForAnUnderlyingSecurity ->
        let tag = "585=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassStatusReqType.StatusForOrdersForAProduct ->
        let tag = "585=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassStatusReqType.StatusForOrdersForACficode ->
        let tag = "585=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassStatusReqType.StatusForOrdersForASecuritytype ->
        let tag = "585=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassStatusReqType.StatusForOrdersForATradingSession ->
        let tag = "585=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassStatusReqType.StatusForAllOrders ->
        let tag = "585=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MassStatusReqType.StatusForOrdersForAPartyid ->
        let tag = "585=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteOrigOrdModTime (dest:byte []) (pos:int) (valIn:OrigOrdModTime) : int = 
    WriteFieldUTCTimestamp dest pos "586="B valIn


let WriteLegSettlType (dest:byte []) (pos:int) (valIn:LegSettlType) : int = 
    WriteFieldChar dest pos "587="B valIn


let WriteLegSettlDate (dest:byte []) (pos:int) (valIn:LegSettlDate) : int = 
    WriteFieldLocalMktDate dest pos "588="B valIn


let WriteDayBookingInst (dest:byte array) (nextFreeIdx:int) (xxIn:DayBookingInst) : int =
    match xxIn with
    | DayBookingInst.CanTriggerBookingWithoutReferenceToTheOrderInitiator ->
        let tag = "589=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DayBookingInst.SpeakWithOrderInitiatorBeforeBooking ->
        let tag = "589=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DayBookingInst.Accumulate ->
        let tag = "589=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteBookingUnit (dest:byte array) (nextFreeIdx:int) (xxIn:BookingUnit) : int =
    match xxIn with
    | BookingUnit.EachPartialExecutionIsABookableUnit ->
        let tag = "590=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BookingUnit.AggregatePartialExecutionsOnThisOrderAndBookOneTradePerOrder ->
        let tag = "590=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BookingUnit.AggregateExecutionsForThisSymbolSideAndSettlementDate ->
        let tag = "590=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePreallocMethod (dest:byte array) (nextFreeIdx:int) (xxIn:PreallocMethod) : int =
    match xxIn with
    | PreallocMethod.ProRata ->
        let tag = "591=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PreallocMethod.DoNotProRata ->
        let tag = "591=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteUnderlyingCountryOfIssue (dest:byte []) (pos:int) (valIn:UnderlyingCountryOfIssue) : int = 
    WriteFieldStr dest pos "592="B valIn


let WriteUnderlyingStateOrProvinceOfIssue (dest:byte []) (pos:int) (valIn:UnderlyingStateOrProvinceOfIssue) : int = 
    WriteFieldStr dest pos "593="B valIn


let WriteUnderlyingLocaleOfIssue (dest:byte []) (pos:int) (valIn:UnderlyingLocaleOfIssue) : int = 
    WriteFieldStr dest pos "594="B valIn


let WriteUnderlyingInstrRegistry (dest:byte []) (pos:int) (valIn:UnderlyingInstrRegistry) : int = 
    WriteFieldStr dest pos "595="B valIn


let WriteLegCountryOfIssue (dest:byte []) (pos:int) (valIn:LegCountryOfIssue) : int = 
    WriteFieldStr dest pos "596="B valIn


let WriteLegStateOrProvinceOfIssue (dest:byte []) (pos:int) (valIn:LegStateOrProvinceOfIssue) : int = 
    WriteFieldStr dest pos "597="B valIn


let WriteLegLocaleOfIssue (dest:byte []) (pos:int) (valIn:LegLocaleOfIssue) : int = 
    WriteFieldStr dest pos "598="B valIn


let WriteLegInstrRegistry (dest:byte []) (pos:int) (valIn:LegInstrRegistry) : int = 
    WriteFieldStr dest pos "599="B valIn


let WriteLegSymbol (dest:byte []) (pos:int) (valIn:LegSymbol) : int = 
    WriteFieldStr dest pos "600="B valIn


let WriteLegSymbolSfx (dest:byte []) (pos:int) (valIn:LegSymbolSfx) : int = 
    WriteFieldStr dest pos "601="B valIn


let WriteLegSecurityID (dest:byte []) (pos:int) (valIn:LegSecurityID) : int = 
    WriteFieldStr dest pos "602="B valIn


let WriteLegSecurityIDSource (dest:byte []) (pos:int) (valIn:LegSecurityIDSource) : int = 
    WriteFieldStr dest pos "603="B valIn


let WriteNoLegSecurityAltID (dest:byte []) (pos:int) (valIn:NoLegSecurityAltID) : int = 
    WriteFieldInt dest pos "604="B valIn


let WriteLegSecurityAltID (dest:byte []) (pos:int) (valIn:LegSecurityAltID) : int = 
    WriteFieldStr dest pos "605="B valIn


let WriteLegSecurityAltIDSource (dest:byte []) (pos:int) (valIn:LegSecurityAltIDSource) : int = 
    WriteFieldStr dest pos "606="B valIn


let WriteLegProduct (dest:byte []) (pos:int) (valIn:LegProduct) : int = 
    WriteFieldInt dest pos "607="B valIn


let WriteLegCFICode (dest:byte []) (pos:int) (valIn:LegCFICode) : int = 
    WriteFieldStr dest pos "608="B valIn


let WriteLegSecurityType (dest:byte []) (pos:int) (valIn:LegSecurityType) : int = 
    WriteFieldStr dest pos "609="B valIn


let WriteLegMaturityMonthYear (dest:byte []) (pos:int) (valIn:LegMaturityMonthYear) : int = 
    WriteFieldMonthYear dest pos "610="B valIn


let WriteLegMaturityDate (dest:byte []) (pos:int) (valIn:LegMaturityDate) : int = 
    WriteFieldLocalMktDate dest pos "611="B valIn


let WriteLegStrikePrice (dest:byte []) (pos:int) (valIn:LegStrikePrice) : int = 
    WriteFieldDecimal dest pos "612="B valIn


let WriteLegOptAttribute (dest:byte []) (pos:int) (valIn:LegOptAttribute) : int = 
    WriteFieldChar dest pos "613="B valIn


let WriteLegContractMultiplier (dest:byte []) (pos:int) (valIn:LegContractMultiplier) : int = 
    WriteFieldDecimal dest pos "614="B valIn


let WriteLegCouponRate (dest:byte []) (pos:int) (valIn:LegCouponRate) : int = 
    WriteFieldDecimal dest pos "615="B valIn


let WriteLegSecurityExchange (dest:byte []) (pos:int) (valIn:LegSecurityExchange) : int = 
    WriteFieldStr dest pos "616="B valIn


let WriteLegIssuer (dest:byte []) (pos:int) (valIn:LegIssuer) : int = 
    WriteFieldStr dest pos "617="B valIn


// compound write, of a length field and the corresponding string field
let WriteEncodedLegIssuer (dest:byte []) (pos:int) (fld:EncodedLegIssuer) : int =
    WriteFieldLengthData dest pos "618="B "619="B fld


let WriteLegSecurityDesc (dest:byte []) (pos:int) (valIn:LegSecurityDesc) : int = 
    WriteFieldStr dest pos "620="B valIn


// compound write, of a length field and the corresponding string field
let WriteEncodedLegSecurityDesc (dest:byte []) (pos:int) (fld:EncodedLegSecurityDesc) : int =
    WriteFieldLengthData dest pos "621="B "622="B fld


let WriteLegRatioQty (dest:byte []) (pos:int) (valIn:LegRatioQty) : int = 
    WriteFieldDecimal dest pos "623="B valIn


let WriteLegSide (dest:byte []) (pos:int) (valIn:LegSide) : int = 
    WriteFieldChar dest pos "624="B valIn


let WriteTradingSessionSubID (dest:byte []) (pos:int) (valIn:TradingSessionSubID) : int = 
    WriteFieldStr dest pos "625="B valIn


let WriteAllocType (dest:byte array) (nextFreeIdx:int) (xxIn:AllocType) : int =
    match xxIn with
    | AllocType.Calculated ->
        let tag = "626=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocType.Preliminary ->
        let tag = "626=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocType.ReadyToBookSingleOrder ->
        let tag = "626=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocType.WarehouseInstruction ->
        let tag = "626=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocType.RequestToIntermediary ->
        let tag = "626=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoHops (dest:byte []) (pos:int) (valIn:NoHops) : int = 
    WriteFieldInt dest pos "627="B valIn


let WriteHopCompID (dest:byte []) (pos:int) (valIn:HopCompID) : int = 
    WriteFieldStr dest pos "628="B valIn


let WriteHopSendingTime (dest:byte []) (pos:int) (valIn:HopSendingTime) : int = 
    WriteFieldUTCTimestamp dest pos "629="B valIn


let WriteHopRefID (dest:byte []) (pos:int) (valIn:HopRefID) : int = 
    WriteFieldUint32 dest pos "630="B valIn


let WriteMidPx (dest:byte []) (pos:int) (valIn:MidPx) : int = 
    WriteFieldDecimal dest pos "631="B valIn


let WriteBidYield (dest:byte []) (pos:int) (valIn:BidYield) : int = 
    WriteFieldDecimal dest pos "632="B valIn


let WriteMidYield (dest:byte []) (pos:int) (valIn:MidYield) : int = 
    WriteFieldDecimal dest pos "633="B valIn


let WriteOfferYield (dest:byte []) (pos:int) (valIn:OfferYield) : int = 
    WriteFieldDecimal dest pos "634="B valIn


let WriteClearingFeeIndicator (dest:byte array) (nextFreeIdx:int) (xxIn:ClearingFeeIndicator) : int =
    match xxIn with
    | ClearingFeeIndicator.CboeMember ->
        let tag = "635=B"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingFeeIndicator.NonMemberAndCustomer ->
        let tag = "635=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingFeeIndicator.EquityMemberAndClearingMember ->
        let tag = "635=E"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingFeeIndicator.FullAndAssociateMemberTradingForOwnAccountAndAsFloorBrokers ->
        let tag = "635=F"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingFeeIndicator.Firms106hAnd106j ->
        let tag = "635=H"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingFeeIndicator.GimIdemAndComMembershipInterestHolders ->
        let tag = "635=I"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingFeeIndicator.LesseeAnd106fEmployees ->
        let tag = "635=L"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ClearingFeeIndicator.AllOtherOwnershipTypes ->
        let tag = "635=M"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteWorkingIndicator (dest:byte []) (pos:int) (valIn:WorkingIndicator) : int = 
    WriteFieldBool dest pos "636="B valIn


let WriteLegLastPx (dest:byte []) (pos:int) (valIn:LegLastPx) : int = 
    WriteFieldDecimal dest pos "637="B valIn


let WritePriorityIndicator (dest:byte array) (nextFreeIdx:int) (xxIn:PriorityIndicator) : int =
    match xxIn with
    | PriorityIndicator.PriorityUnchanged ->
        let tag = "638=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PriorityIndicator.LostPriorityAsResultOfOrderChange ->
        let tag = "638=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePriceImprovement (dest:byte []) (pos:int) (valIn:PriceImprovement) : int = 
    WriteFieldDecimal dest pos "639="B valIn


let WritePrice2 (dest:byte []) (pos:int) (valIn:Price2) : int = 
    WriteFieldDecimal dest pos "640="B valIn


let WriteLastForwardPoints2 (dest:byte []) (pos:int) (valIn:LastForwardPoints2) : int = 
    WriteFieldDecimal dest pos "641="B valIn


let WriteBidForwardPoints2 (dest:byte []) (pos:int) (valIn:BidForwardPoints2) : int = 
    WriteFieldDecimal dest pos "642="B valIn


let WriteOfferForwardPoints2 (dest:byte []) (pos:int) (valIn:OfferForwardPoints2) : int = 
    WriteFieldDecimal dest pos "643="B valIn


let WriteRFQReqID (dest:byte []) (pos:int) (valIn:RFQReqID) : int = 
    WriteFieldStr dest pos "644="B valIn


let WriteMktBidPx (dest:byte []) (pos:int) (valIn:MktBidPx) : int = 
    WriteFieldDecimal dest pos "645="B valIn


let WriteMktOfferPx (dest:byte []) (pos:int) (valIn:MktOfferPx) : int = 
    WriteFieldDecimal dest pos "646="B valIn


let WriteMinBidSize (dest:byte []) (pos:int) (valIn:MinBidSize) : int = 
    WriteFieldDecimal dest pos "647="B valIn


let WriteMinOfferSize (dest:byte []) (pos:int) (valIn:MinOfferSize) : int = 
    WriteFieldDecimal dest pos "648="B valIn


let WriteQuoteStatusReqID (dest:byte []) (pos:int) (valIn:QuoteStatusReqID) : int = 
    WriteFieldStr dest pos "649="B valIn


let WriteLegalConfirm (dest:byte []) (pos:int) (valIn:LegalConfirm) : int = 
    WriteFieldBool dest pos "650="B valIn


let WriteUnderlyingLastPx (dest:byte []) (pos:int) (valIn:UnderlyingLastPx) : int = 
    WriteFieldDecimal dest pos "651="B valIn


let WriteUnderlyingLastQty (dest:byte []) (pos:int) (valIn:UnderlyingLastQty) : int = 
    WriteFieldDecimal dest pos "652="B valIn


let WriteLegRefID (dest:byte []) (pos:int) (valIn:LegRefID) : int = 
    WriteFieldStr dest pos "654="B valIn


let WriteContraLegRefID (dest:byte []) (pos:int) (valIn:ContraLegRefID) : int = 
    WriteFieldStr dest pos "655="B valIn


let WriteSettlCurrBidFxRate (dest:byte []) (pos:int) (valIn:SettlCurrBidFxRate) : int = 
    WriteFieldDecimal dest pos "656="B valIn


let WriteSettlCurrOfferFxRate (dest:byte []) (pos:int) (valIn:SettlCurrOfferFxRate) : int = 
    WriteFieldDecimal dest pos "657="B valIn


let WriteQuoteRequestRejectReason (dest:byte array) (nextFreeIdx:int) (xxIn:QuoteRequestRejectReason) : int =
    match xxIn with
    | QuoteRequestRejectReason.UnknownSymbol ->
        let tag = "658=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRequestRejectReason.ExchangeClosed ->
        let tag = "658=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRequestRejectReason.QuoteRequestExceedsLimit ->
        let tag = "658=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRequestRejectReason.TooLateToEnter ->
        let tag = "658=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRequestRejectReason.InvalidPrice ->
        let tag = "658=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRequestRejectReason.NotAuthorizedToRequestQuote ->
        let tag = "658=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRequestRejectReason.NoMatchForInquiry ->
        let tag = "658=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRequestRejectReason.NoMarketForInstrument ->
        let tag = "658=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRequestRejectReason.NoInventory ->
        let tag = "658=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRequestRejectReason.Pass ->
        let tag = "658=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRequestRejectReason.Other ->
        let tag = "658=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSideComplianceID (dest:byte []) (pos:int) (valIn:SideComplianceID) : int = 
    WriteFieldStr dest pos "659="B valIn


let WriteAcctIDSource (dest:byte array) (nextFreeIdx:int) (xxIn:AcctIDSource) : int =
    match xxIn with
    | AcctIDSource.Bic ->
        let tag = "660=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AcctIDSource.SidCode ->
        let tag = "660=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AcctIDSource.Tfm ->
        let tag = "660=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AcctIDSource.Omgeo ->
        let tag = "660=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AcctIDSource.DtccCode ->
        let tag = "660=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AcctIDSource.Other ->
        let tag = "660=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteAllocAcctIDSource (dest:byte []) (pos:int) (valIn:AllocAcctIDSource) : int = 
    WriteFieldInt dest pos "661="B valIn


let WriteBenchmarkPrice (dest:byte []) (pos:int) (valIn:BenchmarkPrice) : int = 
    WriteFieldDecimal dest pos "662="B valIn


let WriteBenchmarkPriceType (dest:byte []) (pos:int) (valIn:BenchmarkPriceType) : int = 
    WriteFieldInt dest pos "663="B valIn


let WriteConfirmID (dest:byte []) (pos:int) (valIn:ConfirmID) : int = 
    WriteFieldStr dest pos "664="B valIn


let WriteConfirmStatus (dest:byte array) (nextFreeIdx:int) (xxIn:ConfirmStatus) : int =
    match xxIn with
    | ConfirmStatus.Received ->
        let tag = "665=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ConfirmStatus.MismatchedAccount ->
        let tag = "665=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ConfirmStatus.MissingSettlementInstructions ->
        let tag = "665=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ConfirmStatus.Confirmed ->
        let tag = "665=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ConfirmStatus.RequestRejected ->
        let tag = "665=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteConfirmTransType (dest:byte array) (nextFreeIdx:int) (xxIn:ConfirmTransType) : int =
    match xxIn with
    | ConfirmTransType.New ->
        let tag = "666=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ConfirmTransType.Replace ->
        let tag = "666=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ConfirmTransType.Cancel ->
        let tag = "666=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteContractSettlMonth (dest:byte []) (pos:int) (valIn:ContractSettlMonth) : int = 
    WriteFieldMonthYear dest pos "667="B valIn


let WriteDeliveryForm (dest:byte array) (nextFreeIdx:int) (xxIn:DeliveryForm) : int =
    match xxIn with
    | DeliveryForm.Bookentry ->
        let tag = "668=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DeliveryForm.Bearer ->
        let tag = "668=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteLastParPx (dest:byte []) (pos:int) (valIn:LastParPx) : int = 
    WriteFieldDecimal dest pos "669="B valIn


let WriteNoLegAllocs (dest:byte []) (pos:int) (valIn:NoLegAllocs) : int = 
    WriteFieldInt dest pos "670="B valIn


let WriteLegAllocAccount (dest:byte []) (pos:int) (valIn:LegAllocAccount) : int = 
    WriteFieldStr dest pos "671="B valIn


let WriteLegIndividualAllocID (dest:byte []) (pos:int) (valIn:LegIndividualAllocID) : int = 
    WriteFieldStr dest pos "672="B valIn


let WriteLegAllocQty (dest:byte []) (pos:int) (valIn:LegAllocQty) : int = 
    WriteFieldDecimal dest pos "673="B valIn


let WriteLegAllocAcctIDSource (dest:byte []) (pos:int) (valIn:LegAllocAcctIDSource) : int = 
    WriteFieldStr dest pos "674="B valIn


let WriteLegSettlCurrency (dest:byte []) (pos:int) (valIn:LegSettlCurrency) : int = 
    WriteFieldStr dest pos "675="B valIn


let WriteLegBenchmarkCurveCurrency (dest:byte []) (pos:int) (valIn:LegBenchmarkCurveCurrency) : int = 
    WriteFieldStr dest pos "676="B valIn


let WriteLegBenchmarkCurveName (dest:byte []) (pos:int) (valIn:LegBenchmarkCurveName) : int = 
    WriteFieldStr dest pos "677="B valIn


let WriteLegBenchmarkCurvePoint (dest:byte []) (pos:int) (valIn:LegBenchmarkCurvePoint) : int = 
    WriteFieldStr dest pos "678="B valIn


let WriteLegBenchmarkPrice (dest:byte []) (pos:int) (valIn:LegBenchmarkPrice) : int = 
    WriteFieldDecimal dest pos "679="B valIn


let WriteLegBenchmarkPriceType (dest:byte []) (pos:int) (valIn:LegBenchmarkPriceType) : int = 
    WriteFieldInt dest pos "680="B valIn


let WriteLegBidPx (dest:byte []) (pos:int) (valIn:LegBidPx) : int = 
    WriteFieldDecimal dest pos "681="B valIn


let WriteLegIOIQty (dest:byte []) (pos:int) (valIn:LegIOIQty) : int = 
    WriteFieldStr dest pos "682="B valIn


let WriteNoLegStipulations (dest:byte []) (pos:int) (valIn:NoLegStipulations) : int = 
    WriteFieldInt dest pos "683="B valIn


let WriteLegOfferPx (dest:byte []) (pos:int) (valIn:LegOfferPx) : int = 
    WriteFieldDecimal dest pos "684="B valIn


let WriteLegOrderQty (dest:byte []) (pos:int) (valIn:LegOrderQty) : int = 
    WriteFieldDecimal dest pos "685="B valIn


let WriteLegPriceType (dest:byte []) (pos:int) (valIn:LegPriceType) : int = 
    WriteFieldInt dest pos "686="B valIn


let WriteLegQty (dest:byte []) (pos:int) (valIn:LegQty) : int = 
    WriteFieldDecimal dest pos "687="B valIn


let WriteLegStipulationType (dest:byte []) (pos:int) (valIn:LegStipulationType) : int = 
    WriteFieldStr dest pos "688="B valIn


let WriteLegStipulationValue (dest:byte []) (pos:int) (valIn:LegStipulationValue) : int = 
    WriteFieldStr dest pos "689="B valIn


let WriteLegSwapType (dest:byte array) (nextFreeIdx:int) (xxIn:LegSwapType) : int =
    match xxIn with
    | LegSwapType.ParForPar ->
        let tag = "690=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | LegSwapType.ModifiedDuration ->
        let tag = "690=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | LegSwapType.Risk ->
        let tag = "690=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | LegSwapType.Proceeds ->
        let tag = "690=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePool (dest:byte []) (pos:int) (valIn:Pool) : int = 
    WriteFieldStr dest pos "691="B valIn


let WriteQuotePriceType (dest:byte array) (nextFreeIdx:int) (xxIn:QuotePriceType) : int =
    match xxIn with
    | QuotePriceType.Percent ->
        let tag = "692=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuotePriceType.PerShare ->
        let tag = "692=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuotePriceType.FixedAmount ->
        let tag = "692=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuotePriceType.Discount ->
        let tag = "692=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuotePriceType.Premium ->
        let tag = "692=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuotePriceType.BasisPointsRelativeToBenchmark ->
        let tag = "692=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuotePriceType.TedPrice ->
        let tag = "692=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuotePriceType.TedYield ->
        let tag = "692=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuotePriceType.YieldSpread ->
        let tag = "692=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuotePriceType.Yield ->
        let tag = "692=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteQuoteRespID (dest:byte []) (pos:int) (valIn:QuoteRespID) : int = 
    WriteFieldStr dest pos "693="B valIn


let WriteQuoteRespType (dest:byte array) (nextFreeIdx:int) (xxIn:QuoteRespType) : int =
    match xxIn with
    | QuoteRespType.HitLift ->
        let tag = "694=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRespType.Counter ->
        let tag = "694=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRespType.Expired ->
        let tag = "694=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRespType.Cover ->
        let tag = "694=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRespType.DoneAway ->
        let tag = "694=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QuoteRespType.Pass ->
        let tag = "694=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteQuoteQualifier (dest:byte []) (pos:int) (valIn:QuoteQualifier) : int = 
    WriteFieldChar dest pos "695="B valIn


let WriteYieldRedemptionDate (dest:byte []) (pos:int) (valIn:YieldRedemptionDate) : int = 
    WriteFieldLocalMktDate dest pos "696="B valIn


let WriteYieldRedemptionPrice (dest:byte []) (pos:int) (valIn:YieldRedemptionPrice) : int = 
    WriteFieldDecimal dest pos "697="B valIn


let WriteYieldRedemptionPriceType (dest:byte []) (pos:int) (valIn:YieldRedemptionPriceType) : int = 
    WriteFieldInt dest pos "698="B valIn


let WriteBenchmarkSecurityID (dest:byte []) (pos:int) (valIn:BenchmarkSecurityID) : int = 
    WriteFieldStr dest pos "699="B valIn


let WriteReversalIndicator (dest:byte []) (pos:int) (valIn:ReversalIndicator) : int = 
    WriteFieldBool dest pos "700="B valIn


let WriteYieldCalcDate (dest:byte []) (pos:int) (valIn:YieldCalcDate) : int = 
    WriteFieldLocalMktDate dest pos "701="B valIn


let WriteNoPositions (dest:byte []) (pos:int) (valIn:NoPositions) : int = 
    WriteFieldInt dest pos "702="B valIn


let WritePosType (dest:byte array) (nextFreeIdx:int) (xxIn:PosType) : int =
    match xxIn with
    | PosType.TransactionQuantity ->
        let tag = "703=TQ"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.IntraSpreadQty ->
        let tag = "703=IAS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.InterSpreadQty ->
        let tag = "703=IES"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.EndOfDayQty ->
        let tag = "703=FIN"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.StartOfDayQty ->
        let tag = "703=SOD"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.OptionExerciseQty ->
        let tag = "703=EX"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.OptionAssignment ->
        let tag = "703=AS"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.TransactionFromExercise ->
        let tag = "703=TX"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.TransactionFromAssignment ->
        let tag = "703=TA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.PitTradeQty ->
        let tag = "703=PIT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.TransferTradeQty ->
        let tag = "703=TRF"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.ElectronicTradeQty ->
        let tag = "703=ETR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.AllocationTradeQty ->
        let tag = "703=ALC"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.AdjustmentQty ->
        let tag = "703=PA"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.AsOfTradeQty ->
        let tag = "703=ASF"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.DeliveryQty ->
        let tag = "703=DLV"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.TotalTransactionQty ->
        let tag = "703=TOT"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.CrossMarginQty ->
        let tag = "703=XM"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosType.IntegralSplit ->
        let tag = "703=SPL"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteLongQty (dest:byte []) (pos:int) (valIn:LongQty) : int = 
    WriteFieldDecimal dest pos "704="B valIn


let WriteShortQty (dest:byte []) (pos:int) (valIn:ShortQty) : int = 
    WriteFieldDecimal dest pos "705="B valIn


let WritePosQtyStatus (dest:byte array) (nextFreeIdx:int) (xxIn:PosQtyStatus) : int =
    match xxIn with
    | PosQtyStatus.Submitted ->
        let tag = "706=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosQtyStatus.Accepted ->
        let tag = "706=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosQtyStatus.Rejected ->
        let tag = "706=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePosAmtType (dest:byte array) (nextFreeIdx:int) (xxIn:PosAmtType) : int =
    match xxIn with
    | PosAmtType.FinalMarkToMarketAmount ->
        let tag = "707=FMTM"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosAmtType.IncrementalMarkToMarketAmount ->
        let tag = "707=IMTM"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosAmtType.TradeVariationAmount ->
        let tag = "707=TVAR"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosAmtType.StartOfDayMarkToMarketAmount ->
        let tag = "707=SMTM"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosAmtType.PremiumAmount ->
        let tag = "707=PREM"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosAmtType.CashResidualAmount ->
        let tag = "707=CRES"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosAmtType.CashAmount ->
        let tag = "707=CASH"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosAmtType.ValueAdjustedAmount ->
        let tag = "707=VADJ"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePosAmt (dest:byte []) (pos:int) (valIn:PosAmt) : int = 
    WriteFieldDecimal dest pos "708="B valIn


let WritePosTransType (dest:byte array) (nextFreeIdx:int) (xxIn:PosTransType) : int =
    match xxIn with
    | PosTransType.Exercise ->
        let tag = "709=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosTransType.DoNotExercise ->
        let tag = "709=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosTransType.PositionAdjustment ->
        let tag = "709=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosTransType.PositionChangeSubmissionMarginDisposition ->
        let tag = "709=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosTransType.Pledge ->
        let tag = "709=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePosReqID (dest:byte []) (pos:int) (valIn:PosReqID) : int = 
    WriteFieldStr dest pos "710="B valIn


let WriteNoUnderlyings (dest:byte []) (pos:int) (valIn:NoUnderlyings) : int = 
    WriteFieldInt dest pos "711="B valIn


let WritePosMaintAction (dest:byte array) (nextFreeIdx:int) (xxIn:PosMaintAction) : int =
    match xxIn with
    | PosMaintAction.New ->
        let tag = "712=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosMaintAction.Replace ->
        let tag = "712=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosMaintAction.Cancel ->
        let tag = "712=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteOrigPosReqRefID (dest:byte []) (pos:int) (valIn:OrigPosReqRefID) : int = 
    WriteFieldStr dest pos "713="B valIn


let WritePosMaintRptRefID (dest:byte []) (pos:int) (valIn:PosMaintRptRefID) : int = 
    WriteFieldStr dest pos "714="B valIn


let WriteClearingBusinessDate (dest:byte []) (pos:int) (valIn:ClearingBusinessDate) : int = 
    WriteFieldLocalMktDate dest pos "715="B valIn


let WriteSettlSessID (dest:byte []) (pos:int) (valIn:SettlSessID) : int = 
    WriteFieldStr dest pos "716="B valIn


let WriteSettlSessSubID (dest:byte []) (pos:int) (valIn:SettlSessSubID) : int = 
    WriteFieldStr dest pos "717="B valIn


let WriteAdjustmentType (dest:byte array) (nextFreeIdx:int) (xxIn:AdjustmentType) : int =
    match xxIn with
    | AdjustmentType.ProcessRequestAsMarginDisposition ->
        let tag = "718=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AdjustmentType.DeltaPlus ->
        let tag = "718=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AdjustmentType.DeltaMinus ->
        let tag = "718=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AdjustmentType.Final ->
        let tag = "718=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteContraryInstructionIndicator (dest:byte []) (pos:int) (valIn:ContraryInstructionIndicator) : int = 
    WriteFieldBool dest pos "719="B valIn


let WritePriorSpreadIndicator (dest:byte []) (pos:int) (valIn:PriorSpreadIndicator) : int = 
    WriteFieldBool dest pos "720="B valIn


let WritePosMaintRptID (dest:byte []) (pos:int) (valIn:PosMaintRptID) : int = 
    WriteFieldStr dest pos "721="B valIn


let WritePosMaintStatus (dest:byte array) (nextFreeIdx:int) (xxIn:PosMaintStatus) : int =
    match xxIn with
    | PosMaintStatus.Accepted ->
        let tag = "722=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosMaintStatus.AcceptedWithWarnings ->
        let tag = "722=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosMaintStatus.Rejected ->
        let tag = "722=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosMaintStatus.Completed ->
        let tag = "722=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosMaintStatus.CompletedWithWarnings ->
        let tag = "722=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePosMaintResult (dest:byte array) (nextFreeIdx:int) (xxIn:PosMaintResult) : int =
    match xxIn with
    | PosMaintResult.SuccessfulCompletionNoWarningsOrErrors ->
        let tag = "723=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosMaintResult.Rejected ->
        let tag = "723=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosMaintResult.Other ->
        let tag = "723=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePosReqType (dest:byte array) (nextFreeIdx:int) (xxIn:PosReqType) : int =
    match xxIn with
    | PosReqType.Positions ->
        let tag = "724=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosReqType.Trades ->
        let tag = "724=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosReqType.Exercises ->
        let tag = "724=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosReqType.Assignments ->
        let tag = "724=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteResponseTransportType (dest:byte array) (nextFreeIdx:int) (xxIn:ResponseTransportType) : int =
    match xxIn with
    | ResponseTransportType.Inband ->
        let tag = "725=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ResponseTransportType.OutOfBand ->
        let tag = "725=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteResponseDestination (dest:byte []) (pos:int) (valIn:ResponseDestination) : int = 
    WriteFieldStr dest pos "726="B valIn


let WriteTotalNumPosReports (dest:byte []) (pos:int) (valIn:TotalNumPosReports) : int = 
    WriteFieldInt dest pos "727="B valIn


let WritePosReqResult (dest:byte array) (nextFreeIdx:int) (xxIn:PosReqResult) : int =
    match xxIn with
    | PosReqResult.ValidRequest ->
        let tag = "728=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosReqResult.InvalidOrUnsupportedRequest ->
        let tag = "728=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosReqResult.NoPositionsFoundThatMatchCriteria ->
        let tag = "728=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosReqResult.NotAuthorizedToRequestPositions ->
        let tag = "728=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosReqResult.RequestForPositionNotSupported ->
        let tag = "728=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosReqResult.Other ->
        let tag = "728=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePosReqStatus (dest:byte array) (nextFreeIdx:int) (xxIn:PosReqStatus) : int =
    match xxIn with
    | PosReqStatus.Completed ->
        let tag = "729=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosReqStatus.CompletedWithWarnings ->
        let tag = "729=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PosReqStatus.Rejected ->
        let tag = "729=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSettlPrice (dest:byte []) (pos:int) (valIn:SettlPrice) : int = 
    WriteFieldDecimal dest pos "730="B valIn


let WriteSettlPriceType (dest:byte array) (nextFreeIdx:int) (xxIn:SettlPriceType) : int =
    match xxIn with
    | SettlPriceType.Final ->
        let tag = "731=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlPriceType.Theoretical ->
        let tag = "731=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteUnderlyingSettlPrice (dest:byte []) (pos:int) (valIn:UnderlyingSettlPrice) : int = 
    WriteFieldDecimal dest pos "732="B valIn


let WriteUnderlyingSettlPriceType (dest:byte []) (pos:int) (valIn:UnderlyingSettlPriceType) : int = 
    WriteFieldInt dest pos "733="B valIn


let WritePriorSettlPrice (dest:byte []) (pos:int) (valIn:PriorSettlPrice) : int = 
    WriteFieldDecimal dest pos "734="B valIn


let WriteNoQuoteQualifiers (dest:byte []) (pos:int) (valIn:NoQuoteQualifiers) : int = 
    WriteFieldInt dest pos "735="B valIn


let WriteAllocSettlCurrency (dest:byte []) (pos:int) (valIn:AllocSettlCurrency) : int = 
    WriteFieldStr dest pos "736="B valIn


let WriteAllocSettlCurrAmt (dest:byte []) (pos:int) (valIn:AllocSettlCurrAmt) : int = 
    WriteFieldDecimal dest pos "737="B valIn


let WriteInterestAtMaturity (dest:byte []) (pos:int) (valIn:InterestAtMaturity) : int = 
    WriteFieldDecimal dest pos "738="B valIn


let WriteLegDatedDate (dest:byte []) (pos:int) (valIn:LegDatedDate) : int = 
    WriteFieldLocalMktDate dest pos "739="B valIn


let WriteLegPool (dest:byte []) (pos:int) (valIn:LegPool) : int = 
    WriteFieldStr dest pos "740="B valIn


let WriteAllocInterestAtMaturity (dest:byte []) (pos:int) (valIn:AllocInterestAtMaturity) : int = 
    WriteFieldDecimal dest pos "741="B valIn


let WriteAllocAccruedInterestAmt (dest:byte []) (pos:int) (valIn:AllocAccruedInterestAmt) : int = 
    WriteFieldDecimal dest pos "742="B valIn


let WriteDeliveryDate (dest:byte []) (pos:int) (valIn:DeliveryDate) : int = 
    WriteFieldLocalMktDate dest pos "743="B valIn


let WriteAssignmentMethod (dest:byte array) (nextFreeIdx:int) (xxIn:AssignmentMethod) : int =
    match xxIn with
    | AssignmentMethod.Random ->
        let tag = "744=R"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AssignmentMethod.Prorata ->
        let tag = "744=P"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteAssignmentUnit (dest:byte []) (pos:int) (valIn:AssignmentUnit) : int = 
    WriteFieldDecimal dest pos "745="B valIn


let WriteOpenInterest (dest:byte []) (pos:int) (valIn:OpenInterest) : int = 
    WriteFieldDecimal dest pos "746="B valIn


let WriteExerciseMethod (dest:byte array) (nextFreeIdx:int) (xxIn:ExerciseMethod) : int =
    match xxIn with
    | ExerciseMethod.Automatic ->
        let tag = "747=A"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExerciseMethod.Manual ->
        let tag = "747=M"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTotNumTradeReports (dest:byte []) (pos:int) (valIn:TotNumTradeReports) : int = 
    WriteFieldInt dest pos "748="B valIn


let WriteTradeRequestResult (dest:byte array) (nextFreeIdx:int) (xxIn:TradeRequestResult) : int =
    match xxIn with
    | TradeRequestResult.Successful ->
        let tag = "749=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestResult.InvalidOrUnknownInstrument ->
        let tag = "749=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestResult.InvalidTypeOfTradeRequested ->
        let tag = "749=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestResult.InvalidParties ->
        let tag = "749=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestResult.InvalidTransportTypeRequested ->
        let tag = "749=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestResult.InvalidDestinationRequested ->
        let tag = "749=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestResult.TraderequesttypeNotSupported ->
        let tag = "749=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestResult.UnauthorizedForTradeCaptureReportRequest ->
        let tag = "749=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestResult.Yield ->
        let tag = "749=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTradeRequestStatus (dest:byte array) (nextFreeIdx:int) (xxIn:TradeRequestStatus) : int =
    match xxIn with
    | TradeRequestStatus.Accepted ->
        let tag = "750=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestStatus.Completed ->
        let tag = "750=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeRequestStatus.Rejected ->
        let tag = "750=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTradeReportRejectReason (dest:byte array) (nextFreeIdx:int) (xxIn:TradeReportRejectReason) : int =
    match xxIn with
    | TradeReportRejectReason.Successful ->
        let tag = "751=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportRejectReason.InvalidPartyInformation ->
        let tag = "751=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportRejectReason.UnknownInstrument ->
        let tag = "751=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportRejectReason.UnauthorizedToReportTrades ->
        let tag = "751=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportRejectReason.InvalidTradeType ->
        let tag = "751=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportRejectReason.Yield ->
        let tag = "751=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSideMultiLegReportingType (dest:byte array) (nextFreeIdx:int) (xxIn:SideMultiLegReportingType) : int =
    match xxIn with
    | SideMultiLegReportingType.SingleSecurity ->
        let tag = "752=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SideMultiLegReportingType.IndividualLegOfAMultiLegSecurity ->
        let tag = "752=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SideMultiLegReportingType.MultiLegSecurity ->
        let tag = "752=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoPosAmt (dest:byte []) (pos:int) (valIn:NoPosAmt) : int = 
    WriteFieldInt dest pos "753="B valIn


let WriteAutoAcceptIndicator (dest:byte []) (pos:int) (valIn:AutoAcceptIndicator) : int = 
    WriteFieldBool dest pos "754="B valIn


let WriteAllocReportID (dest:byte []) (pos:int) (valIn:AllocReportID) : int = 
    WriteFieldStr dest pos "755="B valIn


let WriteNoNested2PartyIDs (dest:byte []) (pos:int) (valIn:NoNested2PartyIDs) : int = 
    WriteFieldInt dest pos "756="B valIn


let WriteNested2PartyID (dest:byte []) (pos:int) (valIn:Nested2PartyID) : int = 
    WriteFieldStr dest pos "757="B valIn


let WriteNested2PartyIDSource (dest:byte []) (pos:int) (valIn:Nested2PartyIDSource) : int = 
    WriteFieldChar dest pos "758="B valIn


let WriteNested2PartyRole (dest:byte []) (pos:int) (valIn:Nested2PartyRole) : int = 
    WriteFieldInt dest pos "759="B valIn


let WriteNested2PartySubID (dest:byte []) (pos:int) (valIn:Nested2PartySubID) : int = 
    WriteFieldStr dest pos "760="B valIn


let WriteBenchmarkSecurityIDSource (dest:byte []) (pos:int) (valIn:BenchmarkSecurityIDSource) : int = 
    WriteFieldStr dest pos "761="B valIn


let WriteSecuritySubType (dest:byte []) (pos:int) (valIn:SecuritySubType) : int = 
    WriteFieldStr dest pos "762="B valIn


let WriteUnderlyingSecuritySubType (dest:byte []) (pos:int) (valIn:UnderlyingSecuritySubType) : int = 
    WriteFieldStr dest pos "763="B valIn


let WriteLegSecuritySubType (dest:byte []) (pos:int) (valIn:LegSecuritySubType) : int = 
    WriteFieldStr dest pos "764="B valIn


let WriteAllowableOneSidednessPct (dest:byte []) (pos:int) (valIn:AllowableOneSidednessPct) : int = 
    WriteFieldDecimal dest pos "765="B valIn


let WriteAllowableOneSidednessValue (dest:byte []) (pos:int) (valIn:AllowableOneSidednessValue) : int = 
    WriteFieldDecimal dest pos "766="B valIn


let WriteAllowableOneSidednessCurr (dest:byte []) (pos:int) (valIn:AllowableOneSidednessCurr) : int = 
    WriteFieldStr dest pos "767="B valIn


let WriteNoTrdRegTimestamps (dest:byte []) (pos:int) (valIn:NoTrdRegTimestamps) : int = 
    WriteFieldInt dest pos "768="B valIn


let WriteTrdRegTimestamp (dest:byte []) (pos:int) (valIn:TrdRegTimestamp) : int = 
    WriteFieldUTCTimestamp dest pos "769="B valIn


let WriteTrdRegTimestampType (dest:byte array) (nextFreeIdx:int) (xxIn:TrdRegTimestampType) : int =
    match xxIn with
    | TrdRegTimestampType.ExecutionTime ->
        let tag = "770=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdRegTimestampType.TimeIn ->
        let tag = "770=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdRegTimestampType.TimeOut ->
        let tag = "770=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdRegTimestampType.BrokerReceipt ->
        let tag = "770=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdRegTimestampType.BrokerExecution ->
        let tag = "770=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTrdRegTimestampOrigin (dest:byte []) (pos:int) (valIn:TrdRegTimestampOrigin) : int = 
    WriteFieldStr dest pos "771="B valIn


let WriteConfirmRefID (dest:byte []) (pos:int) (valIn:ConfirmRefID) : int = 
    WriteFieldStr dest pos "772="B valIn


let WriteConfirmType (dest:byte array) (nextFreeIdx:int) (xxIn:ConfirmType) : int =
    match xxIn with
    | ConfirmType.Status ->
        let tag = "773=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ConfirmType.Confirmation ->
        let tag = "773=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ConfirmType.ConfirmationRequestRejected ->
        let tag = "773=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteConfirmRejReason (dest:byte array) (nextFreeIdx:int) (xxIn:ConfirmRejReason) : int =
    match xxIn with
    | ConfirmRejReason.MismatchedAccount ->
        let tag = "774=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ConfirmRejReason.MissingSettlementInstructions ->
        let tag = "774=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ConfirmRejReason.Other ->
        let tag = "774=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteBookingType (dest:byte array) (nextFreeIdx:int) (xxIn:BookingType) : int =
    match xxIn with
    | BookingType.RegularBooking ->
        let tag = "775=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BookingType.Cfd ->
        let tag = "775=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BookingType.TotalReturnSwap ->
        let tag = "775=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteIndividualAllocRejCode (dest:byte []) (pos:int) (valIn:IndividualAllocRejCode) : int = 
    WriteFieldInt dest pos "776="B valIn


let WriteSettlInstMsgID (dest:byte []) (pos:int) (valIn:SettlInstMsgID) : int = 
    WriteFieldStr dest pos "777="B valIn


let WriteNoSettlInst (dest:byte []) (pos:int) (valIn:NoSettlInst) : int = 
    WriteFieldInt dest pos "778="B valIn


let WriteLastUpdateTime (dest:byte []) (pos:int) (valIn:LastUpdateTime) : int = 
    WriteFieldUTCTimestamp dest pos "779="B valIn


let WriteAllocSettlInstType (dest:byte array) (nextFreeIdx:int) (xxIn:AllocSettlInstType) : int =
    match xxIn with
    | AllocSettlInstType.UseDefaultInstructions ->
        let tag = "780=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocSettlInstType.DeriveFromParametersProvided ->
        let tag = "780=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocSettlInstType.FullDetailsProvided ->
        let tag = "780=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocSettlInstType.SsiDbIdsProvided ->
        let tag = "780=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocSettlInstType.PhoneForInstructions ->
        let tag = "780=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoSettlPartyIDs (dest:byte []) (pos:int) (valIn:NoSettlPartyIDs) : int = 
    WriteFieldInt dest pos "781="B valIn


let WriteSettlPartyID (dest:byte []) (pos:int) (valIn:SettlPartyID) : int = 
    WriteFieldStr dest pos "782="B valIn


let WriteSettlPartyIDSource (dest:byte []) (pos:int) (valIn:SettlPartyIDSource) : int = 
    WriteFieldChar dest pos "783="B valIn


let WriteSettlPartyRole (dest:byte []) (pos:int) (valIn:SettlPartyRole) : int = 
    WriteFieldInt dest pos "784="B valIn


let WriteSettlPartySubID (dest:byte []) (pos:int) (valIn:SettlPartySubID) : int = 
    WriteFieldStr dest pos "785="B valIn


let WriteSettlPartySubIDType (dest:byte []) (pos:int) (valIn:SettlPartySubIDType) : int = 
    WriteFieldInt dest pos "786="B valIn


let WriteDlvyInstType (dest:byte array) (nextFreeIdx:int) (xxIn:DlvyInstType) : int =
    match xxIn with
    | DlvyInstType.Securities ->
        let tag = "787=S"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DlvyInstType.Cash ->
        let tag = "787=C"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTerminationType (dest:byte array) (nextFreeIdx:int) (xxIn:TerminationType) : int =
    match xxIn with
    | TerminationType.Overnight ->
        let tag = "788=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TerminationType.Term ->
        let tag = "788=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TerminationType.Flexible ->
        let tag = "788=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TerminationType.Open ->
        let tag = "788=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNextExpectedMsgSeqNum (dest:byte []) (pos:int) (valIn:NextExpectedMsgSeqNum) : int = 
    WriteFieldUint32 dest pos "789="B valIn


let WriteOrdStatusReqID (dest:byte []) (pos:int) (valIn:OrdStatusReqID) : int = 
    WriteFieldStr dest pos "790="B valIn


let WriteSettlInstReqID (dest:byte []) (pos:int) (valIn:SettlInstReqID) : int = 
    WriteFieldStr dest pos "791="B valIn


let WriteSettlInstReqRejCode (dest:byte array) (nextFreeIdx:int) (xxIn:SettlInstReqRejCode) : int =
    match xxIn with
    | SettlInstReqRejCode.UnableToProcessRequest ->
        let tag = "792=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlInstReqRejCode.UnknownAccount ->
        let tag = "792=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlInstReqRejCode.NoMatchingSettlementInstructionsFound ->
        let tag = "792=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | SettlInstReqRejCode.Other ->
        let tag = "792=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSecondaryAllocID (dest:byte []) (pos:int) (valIn:SecondaryAllocID) : int = 
    WriteFieldStr dest pos "793="B valIn


let WriteAllocReportType (dest:byte array) (nextFreeIdx:int) (xxIn:AllocReportType) : int =
    match xxIn with
    | AllocReportType.SellsideCalculatedUsingPreliminary ->
        let tag = "794=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocReportType.SellsideCalculatedWithoutPreliminary ->
        let tag = "794=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocReportType.WarehouseRecap ->
        let tag = "794=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocReportType.RequestToIntermediary ->
        let tag = "794=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteAllocReportRefID (dest:byte []) (pos:int) (valIn:AllocReportRefID) : int = 
    WriteFieldStr dest pos "795="B valIn


let WriteAllocCancReplaceReason (dest:byte array) (nextFreeIdx:int) (xxIn:AllocCancReplaceReason) : int =
    match xxIn with
    | AllocCancReplaceReason.OriginalDetailsIncompleteIncorrect ->
        let tag = "796=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocCancReplaceReason.ChangeInUnderlyingOrderDetails ->
        let tag = "796=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCopyMsgIndicator (dest:byte []) (pos:int) (valIn:CopyMsgIndicator) : int = 
    WriteFieldBool dest pos "797="B valIn


let WriteAllocAccountType (dest:byte array) (nextFreeIdx:int) (xxIn:AllocAccountType) : int =
    match xxIn with
    | AllocAccountType.AccountIsCarriedOnCustomerSideOfBooks ->
        let tag = "798=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocAccountType.AccountIsCarriedOnNonCustomerSideOfBooks ->
        let tag = "798=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocAccountType.HouseTrader ->
        let tag = "798=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocAccountType.FloorTrader ->
        let tag = "798=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocAccountType.AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined ->
        let tag = "798=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocAccountType.AccountIsHouseTraderAndIsCrossMargined ->
        let tag = "798=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocAccountType.JointBackofficeAccount ->
        let tag = "798=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteOrderAvgPx (dest:byte []) (pos:int) (valIn:OrderAvgPx) : int = 
    WriteFieldDecimal dest pos "799="B valIn


let WriteOrderBookingQty (dest:byte []) (pos:int) (valIn:OrderBookingQty) : int = 
    WriteFieldDecimal dest pos "800="B valIn


let WriteNoSettlPartySubIDs (dest:byte []) (pos:int) (valIn:NoSettlPartySubIDs) : int = 
    WriteFieldInt dest pos "801="B valIn


let WriteNoPartySubIDs (dest:byte []) (pos:int) (valIn:NoPartySubIDs) : int = 
    WriteFieldInt dest pos "802="B valIn


let WritePartySubIDType (dest:byte []) (pos:int) (valIn:PartySubIDType) : int = 
    WriteFieldInt dest pos "803="B valIn


let WriteNoNestedPartySubIDs (dest:byte []) (pos:int) (valIn:NoNestedPartySubIDs) : int = 
    WriteFieldInt dest pos "804="B valIn


let WriteNestedPartySubIDType (dest:byte []) (pos:int) (valIn:NestedPartySubIDType) : int = 
    WriteFieldInt dest pos "805="B valIn


let WriteNoNested2PartySubIDs (dest:byte []) (pos:int) (valIn:NoNested2PartySubIDs) : int = 
    WriteFieldInt dest pos "806="B valIn


let WriteNested2PartySubIDType (dest:byte []) (pos:int) (valIn:Nested2PartySubIDType) : int = 
    WriteFieldInt dest pos "807="B valIn


let WriteAllocIntermedReqType (dest:byte array) (nextFreeIdx:int) (xxIn:AllocIntermedReqType) : int =
    match xxIn with
    | AllocIntermedReqType.PendingAccept ->
        let tag = "808=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocIntermedReqType.PendingRelease ->
        let tag = "808=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocIntermedReqType.PendingReversal ->
        let tag = "808=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocIntermedReqType.Accept ->
        let tag = "808=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocIntermedReqType.BlockLevelReject ->
        let tag = "808=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocIntermedReqType.AccountLevelReject ->
        let tag = "808=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteUnderlyingPx (dest:byte []) (pos:int) (valIn:UnderlyingPx) : int = 
    WriteFieldDecimal dest pos "810="B valIn


let WritePriceDelta (dest:byte []) (pos:int) (valIn:PriceDelta) : int = 
    WriteFieldDecimal dest pos "811="B valIn


let WriteApplQueueMax (dest:byte []) (pos:int) (valIn:ApplQueueMax) : int = 
    WriteFieldInt dest pos "812="B valIn


let WriteApplQueueDepth (dest:byte []) (pos:int) (valIn:ApplQueueDepth) : int = 
    WriteFieldInt dest pos "813="B valIn


let WriteApplQueueResolution (dest:byte array) (nextFreeIdx:int) (xxIn:ApplQueueResolution) : int =
    match xxIn with
    | ApplQueueResolution.NoActionTaken ->
        let tag = "814=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ApplQueueResolution.QueueFlushed ->
        let tag = "814=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ApplQueueResolution.OverlayLast ->
        let tag = "814=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ApplQueueResolution.EndSession ->
        let tag = "814=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteApplQueueAction (dest:byte array) (nextFreeIdx:int) (xxIn:ApplQueueAction) : int =
    match xxIn with
    | ApplQueueAction.NoActionTaken ->
        let tag = "815=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ApplQueueAction.QueueFlushed ->
        let tag = "815=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ApplQueueAction.OverlayLast ->
        let tag = "815=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ApplQueueAction.EndSession ->
        let tag = "815=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoAltMDSource (dest:byte []) (pos:int) (valIn:NoAltMDSource) : int = 
    WriteFieldInt dest pos "816="B valIn


let WriteAltMDSourceID (dest:byte []) (pos:int) (valIn:AltMDSourceID) : int = 
    WriteFieldStr dest pos "817="B valIn


let WriteSecondaryTradeReportID (dest:byte []) (pos:int) (valIn:SecondaryTradeReportID) : int = 
    WriteFieldStr dest pos "818="B valIn


let WriteAvgPxIndicator (dest:byte array) (nextFreeIdx:int) (xxIn:AvgPxIndicator) : int =
    match xxIn with
    | AvgPxIndicator.NoAveragePricing ->
        let tag = "819=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AvgPxIndicator.TradeIsPartOfAnAveragePriceGroupIdentifiedByTheTradelinkid ->
        let tag = "819=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AvgPxIndicator.LastTradeInTheAveragePriceGroupIdentifiedByTheTradelinkid ->
        let tag = "819=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTradeLinkID (dest:byte []) (pos:int) (valIn:TradeLinkID) : int = 
    WriteFieldStr dest pos "820="B valIn


let WriteOrderInputDevice (dest:byte []) (pos:int) (valIn:OrderInputDevice) : int = 
    WriteFieldStr dest pos "821="B valIn


let WriteUnderlyingTradingSessionID (dest:byte []) (pos:int) (valIn:UnderlyingTradingSessionID) : int = 
    WriteFieldStr dest pos "822="B valIn


let WriteUnderlyingTradingSessionSubID (dest:byte []) (pos:int) (valIn:UnderlyingTradingSessionSubID) : int = 
    WriteFieldStr dest pos "823="B valIn


let WriteTradeLegRefID (dest:byte []) (pos:int) (valIn:TradeLegRefID) : int = 
    WriteFieldStr dest pos "824="B valIn


let WriteExchangeRule (dest:byte []) (pos:int) (valIn:ExchangeRule) : int = 
    WriteFieldStr dest pos "825="B valIn


let WriteTradeAllocIndicator (dest:byte array) (nextFreeIdx:int) (xxIn:TradeAllocIndicator) : int =
    match xxIn with
    | TradeAllocIndicator.AllocationNotRequired ->
        let tag = "826=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeAllocIndicator.AllocationRequired ->
        let tag = "826=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeAllocIndicator.UseAllocationProvidedWithTheTrade ->
        let tag = "826=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteExpirationCycle (dest:byte array) (nextFreeIdx:int) (xxIn:ExpirationCycle) : int =
    match xxIn with
    | ExpirationCycle.ExpireOnTradingSessionClose ->
        let tag = "827=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ExpirationCycle.ExpireOnTradingSessionOpen ->
        let tag = "827=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTrdType (dest:byte array) (nextFreeIdx:int) (xxIn:TrdType) : int =
    match xxIn with
    | TrdType.RegularTrade ->
        let tag = "828=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdType.BlockTrade ->
        let tag = "828=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdType.Efp ->
        let tag = "828=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdType.Transfer ->
        let tag = "828=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdType.LateTrade ->
        let tag = "828=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdType.TTrade ->
        let tag = "828=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdType.WeightedAveragePriceTrade ->
        let tag = "828=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdType.BunchedTrade ->
        let tag = "828=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdType.LateBunchedTrade ->
        let tag = "828=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdType.PriorReferencePriceTrade ->
        let tag = "828=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdType.AfterHoursTrade ->
        let tag = "828=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTrdSubType (dest:byte []) (pos:int) (valIn:TrdSubType) : int = 
    WriteFieldInt dest pos "829="B valIn


let WriteTransferReason (dest:byte []) (pos:int) (valIn:TransferReason) : int = 
    WriteFieldStr dest pos "830="B valIn


let WriteAsgnReqID (dest:byte []) (pos:int) (valIn:AsgnReqID) : int = 
    WriteFieldStr dest pos "831="B valIn


let WriteTotNumAssignmentReports (dest:byte []) (pos:int) (valIn:TotNumAssignmentReports) : int = 
    WriteFieldInt dest pos "832="B valIn


let WriteAsgnRptID (dest:byte []) (pos:int) (valIn:AsgnRptID) : int = 
    WriteFieldStr dest pos "833="B valIn


let WriteThresholdAmount (dest:byte []) (pos:int) (valIn:ThresholdAmount) : int = 
    WriteFieldDecimal dest pos "834="B valIn


let WritePegMoveType (dest:byte array) (nextFreeIdx:int) (xxIn:PegMoveType) : int =
    match xxIn with
    | PegMoveType.Floating ->
        let tag = "835=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PegMoveType.Fixed ->
        let tag = "835=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePegOffsetType (dest:byte array) (nextFreeIdx:int) (xxIn:PegOffsetType) : int =
    match xxIn with
    | PegOffsetType.Price ->
        let tag = "836=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PegOffsetType.BasisPoints ->
        let tag = "836=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PegOffsetType.Ticks ->
        let tag = "836=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PegOffsetType.PriceTierLevel ->
        let tag = "836=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePegLimitType (dest:byte array) (nextFreeIdx:int) (xxIn:PegLimitType) : int =
    match xxIn with
    | PegLimitType.OrBetter ->
        let tag = "837=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PegLimitType.Strict ->
        let tag = "837=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PegLimitType.OrWorse ->
        let tag = "837=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePegRoundDirection (dest:byte array) (nextFreeIdx:int) (xxIn:PegRoundDirection) : int =
    match xxIn with
    | PegRoundDirection.MoreAggressive ->
        let tag = "838=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PegRoundDirection.MorePassive ->
        let tag = "838=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePeggedPrice (dest:byte []) (pos:int) (valIn:PeggedPrice) : int = 
    WriteFieldDecimal dest pos "839="B valIn


let WritePegScope (dest:byte array) (nextFreeIdx:int) (xxIn:PegScope) : int =
    match xxIn with
    | PegScope.Local ->
        let tag = "840=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PegScope.National ->
        let tag = "840=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PegScope.Global ->
        let tag = "840=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | PegScope.NationalExcludingLocal ->
        let tag = "840=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteDiscretionMoveType (dest:byte array) (nextFreeIdx:int) (xxIn:DiscretionMoveType) : int =
    match xxIn with
    | DiscretionMoveType.Floating ->
        let tag = "841=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionMoveType.Fixed ->
        let tag = "841=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteDiscretionOffsetType (dest:byte array) (nextFreeIdx:int) (xxIn:DiscretionOffsetType) : int =
    match xxIn with
    | DiscretionOffsetType.Price ->
        let tag = "842=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionOffsetType.BasisPoints ->
        let tag = "842=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionOffsetType.Ticks ->
        let tag = "842=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionOffsetType.PriceTierLevel ->
        let tag = "842=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteDiscretionLimitType (dest:byte array) (nextFreeIdx:int) (xxIn:DiscretionLimitType) : int =
    match xxIn with
    | DiscretionLimitType.OrBetter ->
        let tag = "843=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionLimitType.Strict ->
        let tag = "843=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionLimitType.OrWorse ->
        let tag = "843=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteDiscretionRoundDirection (dest:byte array) (nextFreeIdx:int) (xxIn:DiscretionRoundDirection) : int =
    match xxIn with
    | DiscretionRoundDirection.MoreAggressive ->
        let tag = "844=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionRoundDirection.MorePassive ->
        let tag = "844=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteDiscretionPrice (dest:byte []) (pos:int) (valIn:DiscretionPrice) : int = 
    WriteFieldDecimal dest pos "845="B valIn


let WriteDiscretionScope (dest:byte array) (nextFreeIdx:int) (xxIn:DiscretionScope) : int =
    match xxIn with
    | DiscretionScope.Local ->
        let tag = "846=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionScope.National ->
        let tag = "846=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionScope.Global ->
        let tag = "846=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DiscretionScope.NationalExcludingLocal ->
        let tag = "846=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTargetStrategy (dest:byte []) (pos:int) (valIn:TargetStrategy) : int = 
    WriteFieldInt dest pos "847="B valIn


let WriteTargetStrategyParameters (dest:byte []) (pos:int) (valIn:TargetStrategyParameters) : int = 
    WriteFieldStr dest pos "848="B valIn


let WriteParticipationRate (dest:byte []) (pos:int) (valIn:ParticipationRate) : int = 
    WriteFieldDecimal dest pos "849="B valIn


let WriteTargetStrategyPerformance (dest:byte []) (pos:int) (valIn:TargetStrategyPerformance) : int = 
    WriteFieldDecimal dest pos "850="B valIn


let WriteLastLiquidityInd (dest:byte array) (nextFreeIdx:int) (xxIn:LastLiquidityInd) : int =
    match xxIn with
    | LastLiquidityInd.AddedLiquidity ->
        let tag = "851=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | LastLiquidityInd.RemovedLiquidity ->
        let tag = "851=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | LastLiquidityInd.LiquidityRoutedOut ->
        let tag = "851=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WritePublishTrdIndicator (dest:byte []) (pos:int) (valIn:PublishTrdIndicator) : int = 
    WriteFieldBool dest pos "852="B valIn


let WriteShortSaleReason (dest:byte array) (nextFreeIdx:int) (xxIn:ShortSaleReason) : int =
    match xxIn with
    | ShortSaleReason.DealerSoldShort ->
        let tag = "853=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ShortSaleReason.DealerSoldShortExempt ->
        let tag = "853=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ShortSaleReason.SellingCustomerSoldShort ->
        let tag = "853=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ShortSaleReason.SellingCustomerSoldShortExempt ->
        let tag = "853=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ShortSaleReason.QualifedServiceRepresentativeOrAutomaticGiveupContraSideSoldShort ->
        let tag = "853=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | ShortSaleReason.QsrOrAguContraSideSoldShortExempt ->
        let tag = "853=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteQtyType (dest:byte array) (nextFreeIdx:int) (xxIn:QtyType) : int =
    match xxIn with
    | QtyType.Units ->
        let tag = "854=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | QtyType.Contracts ->
        let tag = "854=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSecondaryTrdType (dest:byte []) (pos:int) (valIn:SecondaryTrdType) : int = 
    WriteFieldInt dest pos "855="B valIn


let WriteTradeReportType (dest:byte array) (nextFreeIdx:int) (xxIn:TradeReportType) : int =
    match xxIn with
    | TradeReportType.Submit ->
        let tag = "856=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportType.Alleged ->
        let tag = "856=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportType.Accept ->
        let tag = "856=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportType.Decline ->
        let tag = "856=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportType.Addendum ->
        let tag = "856=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportType.NoWas ->
        let tag = "856=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportType.TradeReportCancel ->
        let tag = "856=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TradeReportType.LockedInTradeBreak ->
        let tag = "856=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteAllocNoOrdersType (dest:byte array) (nextFreeIdx:int) (xxIn:AllocNoOrdersType) : int =
    match xxIn with
    | AllocNoOrdersType.NotSpecified ->
        let tag = "857=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AllocNoOrdersType.ExplicitListProvided ->
        let tag = "857=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteSharedCommission (dest:byte []) (pos:int) (valIn:SharedCommission) : int = 
    WriteFieldDecimal dest pos "858="B valIn


let WriteConfirmReqID (dest:byte []) (pos:int) (valIn:ConfirmReqID) : int = 
    WriteFieldStr dest pos "859="B valIn


let WriteAvgParPx (dest:byte []) (pos:int) (valIn:AvgParPx) : int = 
    WriteFieldDecimal dest pos "860="B valIn


let WriteReportedPx (dest:byte []) (pos:int) (valIn:ReportedPx) : int = 
    WriteFieldDecimal dest pos "861="B valIn


let WriteNoCapacities (dest:byte []) (pos:int) (valIn:NoCapacities) : int = 
    WriteFieldInt dest pos "862="B valIn


let WriteOrderCapacityQty (dest:byte []) (pos:int) (valIn:OrderCapacityQty) : int = 
    WriteFieldDecimal dest pos "863="B valIn


let WriteNoEvents (dest:byte []) (pos:int) (valIn:NoEvents) : int = 
    WriteFieldInt dest pos "864="B valIn


let WriteEventType (dest:byte array) (nextFreeIdx:int) (xxIn:EventType) : int =
    match xxIn with
    | EventType.Put ->
        let tag = "865=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | EventType.Call ->
        let tag = "865=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | EventType.Tender ->
        let tag = "865=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | EventType.SinkingFundCall ->
        let tag = "865=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | EventType.Other ->
        let tag = "865=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteEventDate (dest:byte []) (pos:int) (valIn:EventDate) : int = 
    WriteFieldLocalMktDate dest pos "866="B valIn


let WriteEventPx (dest:byte []) (pos:int) (valIn:EventPx) : int = 
    WriteFieldDecimal dest pos "867="B valIn


let WriteEventText (dest:byte []) (pos:int) (valIn:EventText) : int = 
    WriteFieldStr dest pos "868="B valIn


let WritePctAtRisk (dest:byte []) (pos:int) (valIn:PctAtRisk) : int = 
    WriteFieldDecimal dest pos "869="B valIn


let WriteNoInstrAttrib (dest:byte []) (pos:int) (valIn:NoInstrAttrib) : int = 
    WriteFieldInt dest pos "870="B valIn


let WriteInstrAttribType (dest:byte array) (nextFreeIdx:int) (xxIn:InstrAttribType) : int =
    match xxIn with
    | InstrAttribType.Flat ->
        let tag = "871=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.ZeroCoupon ->
        let tag = "871=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.InterestBearing ->
        let tag = "871=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.NoPeriodicPayments ->
        let tag = "871=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.VariableRate ->
        let tag = "871=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.LessFeeForPut ->
        let tag = "871=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.SteppedCoupon ->
        let tag = "871=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.CouponPeriod ->
        let tag = "871=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.WhenAndIfIssued ->
        let tag = "871=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.OriginalIssueDiscount ->
        let tag = "871=10"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.CallablePuttable ->
        let tag = "871=11"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.EscrowedToMaturity ->
        let tag = "871=12"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.EscrowedToRedemptionDate ->
        let tag = "871=13"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.PreRefunded ->
        let tag = "871=14"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.InDefault ->
        let tag = "871=15"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.Unrated ->
        let tag = "871=16"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.Taxable ->
        let tag = "871=17"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.Indexed ->
        let tag = "871=18"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.SubjectToAlternativeMinimumTax ->
        let tag = "871=19"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.OriginalIssueDiscountPrice ->
        let tag = "871=20"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.CallableBelowMaturityValue ->
        let tag = "871=21"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.CallableWithoutNoticeByMailToHolderUnlessRegistered ->
        let tag = "871=22"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | InstrAttribType.Text ->
        let tag = "871=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteInstrAttribValue (dest:byte []) (pos:int) (valIn:InstrAttribValue) : int = 
    WriteFieldStr dest pos "872="B valIn


let WriteDatedDate (dest:byte []) (pos:int) (valIn:DatedDate) : int = 
    WriteFieldLocalMktDate dest pos "873="B valIn


let WriteInterestAccrualDate (dest:byte []) (pos:int) (valIn:InterestAccrualDate) : int = 
    WriteFieldLocalMktDate dest pos "874="B valIn


let WriteCPProgram (dest:byte []) (pos:int) (valIn:CPProgram) : int = 
    WriteFieldInt dest pos "875="B valIn


let WriteCPRegType (dest:byte []) (pos:int) (valIn:CPRegType) : int = 
    WriteFieldStr dest pos "876="B valIn


let WriteUnderlyingCPProgram (dest:byte []) (pos:int) (valIn:UnderlyingCPProgram) : int = 
    WriteFieldStr dest pos "877="B valIn


let WriteUnderlyingCPRegType (dest:byte []) (pos:int) (valIn:UnderlyingCPRegType) : int = 
    WriteFieldStr dest pos "878="B valIn


let WriteUnderlyingQty (dest:byte []) (pos:int) (valIn:UnderlyingQty) : int = 
    WriteFieldDecimal dest pos "879="B valIn


let WriteTrdMatchID (dest:byte []) (pos:int) (valIn:TrdMatchID) : int = 
    WriteFieldStr dest pos "880="B valIn


let WriteSecondaryTradeReportRefID (dest:byte []) (pos:int) (valIn:SecondaryTradeReportRefID) : int = 
    WriteFieldStr dest pos "881="B valIn


let WriteUnderlyingDirtyPrice (dest:byte []) (pos:int) (valIn:UnderlyingDirtyPrice) : int = 
    WriteFieldDecimal dest pos "882="B valIn


let WriteUnderlyingEndPrice (dest:byte []) (pos:int) (valIn:UnderlyingEndPrice) : int = 
    WriteFieldDecimal dest pos "883="B valIn


let WriteUnderlyingStartValue (dest:byte []) (pos:int) (valIn:UnderlyingStartValue) : int = 
    WriteFieldDecimal dest pos "884="B valIn


let WriteUnderlyingCurrentValue (dest:byte []) (pos:int) (valIn:UnderlyingCurrentValue) : int = 
    WriteFieldDecimal dest pos "885="B valIn


let WriteUnderlyingEndValue (dest:byte []) (pos:int) (valIn:UnderlyingEndValue) : int = 
    WriteFieldDecimal dest pos "886="B valIn


let WriteNoUnderlyingStips (dest:byte []) (pos:int) (valIn:NoUnderlyingStips) : int = 
    WriteFieldInt dest pos "887="B valIn


let WriteUnderlyingStipType (dest:byte []) (pos:int) (valIn:UnderlyingStipType) : int = 
    WriteFieldStr dest pos "888="B valIn


let WriteUnderlyingStipValue (dest:byte []) (pos:int) (valIn:UnderlyingStipValue) : int = 
    WriteFieldStr dest pos "889="B valIn


let WriteMaturityNetMoney (dest:byte []) (pos:int) (valIn:MaturityNetMoney) : int = 
    WriteFieldDecimal dest pos "890="B valIn


let WriteMiscFeeBasis (dest:byte array) (nextFreeIdx:int) (xxIn:MiscFeeBasis) : int =
    match xxIn with
    | MiscFeeBasis.Absolute ->
        let tag = "891=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MiscFeeBasis.PerUnit ->
        let tag = "891=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MiscFeeBasis.Percentage ->
        let tag = "891=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTotNoAllocs (dest:byte []) (pos:int) (valIn:TotNoAllocs) : int = 
    WriteFieldInt dest pos "892="B valIn


let WriteLastFragment (dest:byte []) (pos:int) (valIn:LastFragment) : int = 
    WriteFieldBool dest pos "893="B valIn


let WriteCollReqID (dest:byte []) (pos:int) (valIn:CollReqID) : int = 
    WriteFieldStr dest pos "894="B valIn


let WriteCollAsgnReason (dest:byte array) (nextFreeIdx:int) (xxIn:CollAsgnReason) : int =
    match xxIn with
    | CollAsgnReason.Initial ->
        let tag = "895=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnReason.Scheduled ->
        let tag = "895=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnReason.TimeWarning ->
        let tag = "895=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnReason.MarginDeficiency ->
        let tag = "895=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnReason.MarginExcess ->
        let tag = "895=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnReason.ForwardCollateralDemand ->
        let tag = "895=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnReason.EventOfDefault ->
        let tag = "895=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnReason.AdverseTaxEvent ->
        let tag = "895=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCollInquiryQualifier (dest:byte array) (nextFreeIdx:int) (xxIn:CollInquiryQualifier) : int =
    match xxIn with
    | CollInquiryQualifier.Tradedate ->
        let tag = "896=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryQualifier.GcInstrument ->
        let tag = "896=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryQualifier.Collateralinstrument ->
        let tag = "896=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryQualifier.SubstitutionEligible ->
        let tag = "896=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryQualifier.NotAssigned ->
        let tag = "896=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryQualifier.PartiallyAssigned ->
        let tag = "896=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryQualifier.FullyAssigned ->
        let tag = "896=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryQualifier.OutstandingTrades ->
        let tag = "896=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoTrades (dest:byte []) (pos:int) (valIn:NoTrades) : int = 
    WriteFieldInt dest pos "897="B valIn


let WriteMarginRatio (dest:byte []) (pos:int) (valIn:MarginRatio) : int = 
    WriteFieldDecimal dest pos "898="B valIn


let WriteMarginExcess (dest:byte []) (pos:int) (valIn:MarginExcess) : int = 
    WriteFieldDecimal dest pos "899="B valIn


let WriteTotalNetValue (dest:byte []) (pos:int) (valIn:TotalNetValue) : int = 
    WriteFieldDecimal dest pos "900="B valIn


let WriteCashOutstanding (dest:byte []) (pos:int) (valIn:CashOutstanding) : int = 
    WriteFieldDecimal dest pos "901="B valIn


let WriteCollAsgnID (dest:byte []) (pos:int) (valIn:CollAsgnID) : int = 
    WriteFieldStr dest pos "902="B valIn


let WriteCollAsgnTransType (dest:byte array) (nextFreeIdx:int) (xxIn:CollAsgnTransType) : int =
    match xxIn with
    | CollAsgnTransType.New ->
        let tag = "903=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnTransType.Replace ->
        let tag = "903=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnTransType.Cancel ->
        let tag = "903=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnTransType.Release ->
        let tag = "903=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnTransType.Reverse ->
        let tag = "903=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCollRespID (dest:byte []) (pos:int) (valIn:CollRespID) : int = 
    WriteFieldStr dest pos "904="B valIn


let WriteCollAsgnRespType (dest:byte array) (nextFreeIdx:int) (xxIn:CollAsgnRespType) : int =
    match xxIn with
    | CollAsgnRespType.Received ->
        let tag = "905=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnRespType.Accepted ->
        let tag = "905=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnRespType.Declined ->
        let tag = "905=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnRespType.Rejected ->
        let tag = "905=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCollAsgnRejectReason (dest:byte array) (nextFreeIdx:int) (xxIn:CollAsgnRejectReason) : int =
    match xxIn with
    | CollAsgnRejectReason.UnknownDeal ->
        let tag = "906=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnRejectReason.UnknownOrInvalidInstrument ->
        let tag = "906=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnRejectReason.UnauthorizedTransaction ->
        let tag = "906=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnRejectReason.InsufficientCollateral ->
        let tag = "906=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnRejectReason.InvalidTypeOfCollateral ->
        let tag = "906=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnRejectReason.ExcessiveSubstitution ->
        let tag = "906=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAsgnRejectReason.Other ->
        let tag = "906=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCollAsgnRefID (dest:byte []) (pos:int) (valIn:CollAsgnRefID) : int = 
    WriteFieldStr dest pos "907="B valIn


let WriteCollRptID (dest:byte []) (pos:int) (valIn:CollRptID) : int = 
    WriteFieldStr dest pos "908="B valIn


let WriteCollInquiryID (dest:byte []) (pos:int) (valIn:CollInquiryID) : int = 
    WriteFieldStr dest pos "909="B valIn


let WriteCollStatus (dest:byte array) (nextFreeIdx:int) (xxIn:CollStatus) : int =
    match xxIn with
    | CollStatus.Unassigned ->
        let tag = "910=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollStatus.PartiallyAssigned ->
        let tag = "910=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollStatus.AssignmentProposed ->
        let tag = "910=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollStatus.Assigned ->
        let tag = "910=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollStatus.Challenged ->
        let tag = "910=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTotNumReports (dest:byte []) (pos:int) (valIn:TotNumReports) : int = 
    WriteFieldInt dest pos "911="B valIn


let WriteLastRptRequested (dest:byte []) (pos:int) (valIn:LastRptRequested) : int = 
    WriteFieldBool dest pos "912="B valIn


let WriteAgreementDesc (dest:byte []) (pos:int) (valIn:AgreementDesc) : int = 
    WriteFieldStr dest pos "913="B valIn


let WriteAgreementID (dest:byte []) (pos:int) (valIn:AgreementID) : int = 
    WriteFieldStr dest pos "914="B valIn


let WriteAgreementDate (dest:byte []) (pos:int) (valIn:AgreementDate) : int = 
    WriteFieldLocalMktDate dest pos "915="B valIn


let WriteStartDate (dest:byte []) (pos:int) (valIn:StartDate) : int = 
    WriteFieldLocalMktDate dest pos "916="B valIn


let WriteEndDate (dest:byte []) (pos:int) (valIn:EndDate) : int = 
    WriteFieldLocalMktDate dest pos "917="B valIn


let WriteAgreementCurrency (dest:byte []) (pos:int) (valIn:AgreementCurrency) : int = 
    WriteFieldStr dest pos "918="B valIn


let WriteDeliveryType (dest:byte array) (nextFreeIdx:int) (xxIn:DeliveryType) : int =
    match xxIn with
    | DeliveryType.VersusPayment ->
        let tag = "919=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DeliveryType.Free ->
        let tag = "919=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DeliveryType.TriParty ->
        let tag = "919=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | DeliveryType.HoldInCustody ->
        let tag = "919=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteEndAccruedInterestAmt (dest:byte []) (pos:int) (valIn:EndAccruedInterestAmt) : int = 
    WriteFieldDecimal dest pos "920="B valIn


let WriteStartCash (dest:byte []) (pos:int) (valIn:StartCash) : int = 
    WriteFieldDecimal dest pos "921="B valIn


let WriteEndCash (dest:byte []) (pos:int) (valIn:EndCash) : int = 
    WriteFieldDecimal dest pos "922="B valIn


let WriteUserRequestID (dest:byte []) (pos:int) (valIn:UserRequestID) : int = 
    WriteFieldStr dest pos "923="B valIn


let WriteUserRequestType (dest:byte array) (nextFreeIdx:int) (xxIn:UserRequestType) : int =
    match xxIn with
    | UserRequestType.Logonuser ->
        let tag = "924=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | UserRequestType.Logoffuser ->
        let tag = "924=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | UserRequestType.Changepasswordforuser ->
        let tag = "924=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | UserRequestType.RequestIndividualUserStatus ->
        let tag = "924=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNewPassword (dest:byte []) (pos:int) (valIn:NewPassword) : int = 
    WriteFieldStr dest pos "925="B valIn


let WriteUserStatus (dest:byte array) (nextFreeIdx:int) (xxIn:UserStatus) : int =
    match xxIn with
    | UserStatus.LoggedIn ->
        let tag = "926=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | UserStatus.NotLoggedIn ->
        let tag = "926=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | UserStatus.UserNotRecognised ->
        let tag = "926=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | UserStatus.PasswordIncorrect ->
        let tag = "926=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | UserStatus.PasswordChanged ->
        let tag = "926=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | UserStatus.Other ->
        let tag = "926=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteUserStatusText (dest:byte []) (pos:int) (valIn:UserStatusText) : int = 
    WriteFieldStr dest pos "927="B valIn


let WriteStatusValue (dest:byte array) (nextFreeIdx:int) (xxIn:StatusValue) : int =
    match xxIn with
    | StatusValue.Connected ->
        let tag = "928=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StatusValue.NotConnectedDownExpectedUp ->
        let tag = "928=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StatusValue.NotConnectedDownExpectedDown ->
        let tag = "928=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | StatusValue.InProcess ->
        let tag = "928=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteStatusText (dest:byte []) (pos:int) (valIn:StatusText) : int = 
    WriteFieldStr dest pos "929="B valIn


let WriteRefCompID (dest:byte []) (pos:int) (valIn:RefCompID) : int = 
    WriteFieldStr dest pos "930="B valIn


let WriteRefSubID (dest:byte []) (pos:int) (valIn:RefSubID) : int = 
    WriteFieldStr dest pos "931="B valIn


let WriteNetworkResponseID (dest:byte []) (pos:int) (valIn:NetworkResponseID) : int = 
    WriteFieldStr dest pos "932="B valIn


let WriteNetworkRequestID (dest:byte []) (pos:int) (valIn:NetworkRequestID) : int = 
    WriteFieldStr dest pos "933="B valIn


let WriteLastNetworkResponseID (dest:byte []) (pos:int) (valIn:LastNetworkResponseID) : int = 
    WriteFieldStr dest pos "934="B valIn


let WriteNetworkRequestType (dest:byte array) (nextFreeIdx:int) (xxIn:NetworkRequestType) : int =
    match xxIn with
    | NetworkRequestType.Snapshot ->
        let tag = "935=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | NetworkRequestType.Subscribe ->
        let tag = "935=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | NetworkRequestType.StopSubscribing ->
        let tag = "935=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | NetworkRequestType.LevelOfDetail ->
        let tag = "935=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoCompIDs (dest:byte []) (pos:int) (valIn:NoCompIDs) : int = 
    WriteFieldInt dest pos "936="B valIn


let WriteNetworkStatusResponseType (dest:byte array) (nextFreeIdx:int) (xxIn:NetworkStatusResponseType) : int =
    match xxIn with
    | NetworkStatusResponseType.Full ->
        let tag = "937=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | NetworkStatusResponseType.IncrementalUpdate ->
        let tag = "937=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteNoCollInquiryQualifier (dest:byte []) (pos:int) (valIn:NoCollInquiryQualifier) : int = 
    WriteFieldInt dest pos "938="B valIn


let WriteTrdRptStatus (dest:byte array) (nextFreeIdx:int) (xxIn:TrdRptStatus) : int =
    match xxIn with
    | TrdRptStatus.Accepted ->
        let tag = "939=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | TrdRptStatus.Rejected ->
        let tag = "939=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteAffirmStatus (dest:byte array) (nextFreeIdx:int) (xxIn:AffirmStatus) : int =
    match xxIn with
    | AffirmStatus.Received ->
        let tag = "940=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AffirmStatus.ConfirmRejected ->
        let tag = "940=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | AffirmStatus.Affirmed ->
        let tag = "940=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteUnderlyingStrikeCurrency (dest:byte []) (pos:int) (valIn:UnderlyingStrikeCurrency) : int = 
    WriteFieldStr dest pos "941="B valIn


let WriteLegStrikeCurrency (dest:byte []) (pos:int) (valIn:LegStrikeCurrency) : int = 
    WriteFieldStr dest pos "942="B valIn


let WriteTimeBracket (dest:byte []) (pos:int) (valIn:TimeBracket) : int = 
    WriteFieldStr dest pos "943="B valIn


let WriteCollAction (dest:byte array) (nextFreeIdx:int) (xxIn:CollAction) : int =
    match xxIn with
    | CollAction.Retain ->
        let tag = "944=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAction.Add ->
        let tag = "944=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollAction.Remove ->
        let tag = "944=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCollInquiryStatus (dest:byte array) (nextFreeIdx:int) (xxIn:CollInquiryStatus) : int =
    match xxIn with
    | CollInquiryStatus.Accepted ->
        let tag = "945=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryStatus.AcceptedWithWarnings ->
        let tag = "945=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryStatus.Completed ->
        let tag = "945=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryStatus.CompletedWithWarnings ->
        let tag = "945=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryStatus.Rejected ->
        let tag = "945=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteCollInquiryResult (dest:byte array) (nextFreeIdx:int) (xxIn:CollInquiryResult) : int =
    match xxIn with
    | CollInquiryResult.Successful ->
        let tag = "946=0"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryResult.InvalidOrUnknownInstrument ->
        let tag = "946=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryResult.InvalidOrUnknownCollateralType ->
        let tag = "946=2"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryResult.InvalidParties ->
        let tag = "946=3"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryResult.InvalidTransportTypeRequested ->
        let tag = "946=4"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryResult.InvalidDestinationRequested ->
        let tag = "946=5"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryResult.NoCollateralFoundForTheTradeSpecified ->
        let tag = "946=6"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryResult.NoCollateralFoundForTheOrderSpecified ->
        let tag = "946=7"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryResult.CollateralInquiryTypeNotSupported ->
        let tag = "946=8"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryResult.UnauthorizedForCollateralInquiry ->
        let tag = "946=9"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | CollInquiryResult.Other ->
        let tag = "946=99"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteStrikeCurrency (dest:byte []) (pos:int) (valIn:StrikeCurrency) : int = 
    WriteFieldStr dest pos "947="B valIn


let WriteNoNested3PartyIDs (dest:byte []) (pos:int) (valIn:NoNested3PartyIDs) : int = 
    WriteFieldInt dest pos "948="B valIn


let WriteNested3PartyID (dest:byte []) (pos:int) (valIn:Nested3PartyID) : int = 
    WriteFieldStr dest pos "949="B valIn


let WriteNested3PartyIDSource (dest:byte []) (pos:int) (valIn:Nested3PartyIDSource) : int = 
    WriteFieldChar dest pos "950="B valIn


let WriteNested3PartyRole (dest:byte []) (pos:int) (valIn:Nested3PartyRole) : int = 
    WriteFieldInt dest pos "951="B valIn


let WriteNoNested3PartySubIDs (dest:byte []) (pos:int) (valIn:NoNested3PartySubIDs) : int = 
    WriteFieldInt dest pos "952="B valIn


let WriteNested3PartySubID (dest:byte []) (pos:int) (valIn:Nested3PartySubID) : int = 
    WriteFieldStr dest pos "953="B valIn


let WriteNested3PartySubIDType (dest:byte []) (pos:int) (valIn:Nested3PartySubIDType) : int = 
    WriteFieldInt dest pos "954="B valIn


let WriteLegContractSettlMonth (dest:byte []) (pos:int) (valIn:LegContractSettlMonth) : int = 
    WriteFieldMonthYear dest pos "955="B valIn


let WriteLegInterestAccrualDate (dest:byte []) (pos:int) (valIn:LegInterestAccrualDate) : int = 
    WriteFieldLocalMktDate dest pos "956="B valIn


