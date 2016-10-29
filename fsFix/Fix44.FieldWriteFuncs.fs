module Fix44.FieldWriteFuncs


open System
open System.IO
open Fix44.Fields
open Conversions
open FieldFuncs


let WriteAccount (dest:byte []) (nextFreeIdx:int) (valIn:Account) : int = 
   let tag = "1="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAdvId (dest:byte []) (nextFreeIdx:int) (valIn:AdvId) : int = 
   let tag = "2="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAdvRefID (dest:byte []) (nextFreeIdx:int) (valIn:AdvRefID) : int = 
   let tag = "3="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteAvgPx (dest:byte []) (nextFreeIdx:int) (valIn:AvgPx) : int = 
   let tag = "6="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBeginSeqNo (dest:byte []) (nextFreeIdx:int) (valIn:BeginSeqNo) : int = 
   let tag = "7="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBeginString (dest:byte []) (nextFreeIdx:int) (valIn:BeginString) : int = 
   let tag = "8="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBodyLength (dest:byte []) (nextFreeIdx:int) (valIn:BodyLength) : int = 
   let tag = "9="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCheckSum (dest:byte []) (nextFreeIdx:int) (valIn:CheckSum) : int = 
   let tag = "10="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteClOrdID (dest:byte []) (nextFreeIdx:int) (valIn:ClOrdID) : int = 
   let tag = "11="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCommission (dest:byte []) (nextFreeIdx:int) (valIn:Commission) : int = 
   let tag = "12="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteCumQty (dest:byte []) (nextFreeIdx:int) (valIn:CumQty) : int = 
   let tag = "14="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCurrency (dest:byte []) (nextFreeIdx:int) (valIn:Currency) : int = 
   let tag = "15="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteEndSeqNo (dest:byte []) (nextFreeIdx:int) (valIn:EndSeqNo) : int = 
   let tag = "16="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteExecID (dest:byte []) (nextFreeIdx:int) (valIn:ExecID) : int = 
   let tag = "17="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteExecRefID (dest:byte []) (nextFreeIdx:int) (valIn:ExecRefID) : int = 
   let tag = "19="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteIOIid (dest:byte []) (nextFreeIdx:int) (valIn:IOIid) : int = 
   let tag = "23="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteIOIRefID (dest:byte []) (nextFreeIdx:int) (valIn:IOIRefID) : int = 
   let tag = "26="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteIOIQty (dest:byte []) (nextFreeIdx:int) (valIn:IOIQty) : int = 
   let tag = "27="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteLastMkt (dest:byte []) (nextFreeIdx:int) (valIn:LastMkt) : int = 
   let tag = "30="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLastPx (dest:byte []) (nextFreeIdx:int) (valIn:LastPx) : int = 
   let tag = "31="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLastQty (dest:byte []) (nextFreeIdx:int) (valIn:LastQty) : int = 
   let tag = "32="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLinesOfText (dest:byte []) (nextFreeIdx:int) (valIn:LinesOfText) : int = 
   let tag = "33="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMsgSeqNum (dest:byte []) (nextFreeIdx:int) (valIn:MsgSeqNum) : int = 
   let tag = "34="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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
    | MsgType.OrderSingle ->
        let tag = "35=D"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | MsgType.OrderList ->
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
    | MsgType.MultilegOrderCancelReplace ->
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
    | MsgType.RfqRequest ->
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


let WriteNewSeqNo (dest:byte []) (nextFreeIdx:int) (valIn:NewSeqNo) : int = 
   let tag = "36="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOrderID (dest:byte []) (nextFreeIdx:int) (valIn:OrderID) : int = 
   let tag = "37="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOrderQty (dest:byte []) (nextFreeIdx:int) (valIn:OrderQty) : int = 
   let tag = "38="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteOrigClOrdID (dest:byte []) (nextFreeIdx:int) (valIn:OrigClOrdID) : int = 
   let tag = "41="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOrigTime (dest:byte []) (nextFreeIdx:int) (valIn:OrigTime) : int = 
   let tag = "42="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePossDupFlag (dest:byte []) (nextFreeIdx:int) (valIn:PossDupFlag) : int = 
   let tag = "43="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePrice (dest:byte []) (nextFreeIdx:int) (valIn:Price) : int = 
   let tag = "44="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRefSeqNum (dest:byte []) (nextFreeIdx:int) (valIn:RefSeqNum) : int = 
   let tag = "45="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSecurityID (dest:byte []) (nextFreeIdx:int) (valIn:SecurityID) : int = 
   let tag = "48="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSenderCompID (dest:byte []) (nextFreeIdx:int) (valIn:SenderCompID) : int = 
   let tag = "49="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSenderSubID (dest:byte []) (nextFreeIdx:int) (valIn:SenderSubID) : int = 
   let tag = "50="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSendingTime (dest:byte []) (nextFreeIdx:int) (valIn:SendingTime) : int = 
   let tag = "52="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteQuantity (dest:byte []) (nextFreeIdx:int) (valIn:Quantity) : int = 
   let tag = "53="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteSymbol (dest:byte []) (nextFreeIdx:int) (valIn:Symbol) : int = 
   let tag = "55="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTargetCompID (dest:byte []) (nextFreeIdx:int) (valIn:TargetCompID) : int = 
   let tag = "56="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTargetSubID (dest:byte []) (nextFreeIdx:int) (valIn:TargetSubID) : int = 
   let tag = "57="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteText (dest:byte []) (nextFreeIdx:int) (valIn:Text) : int = 
   let tag = "58="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteTransactTime (dest:byte []) (nextFreeIdx:int) (valIn:TransactTime) : int = 
   let tag = "60="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteValidUntilTime (dest:byte []) (nextFreeIdx:int) (valIn:ValidUntilTime) : int = 
   let tag = "62="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteSettlDate (dest:byte []) (nextFreeIdx:int) (valIn:SettlDate) : int = 
   let tag = "64="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteListID (dest:byte []) (nextFreeIdx:int) (valIn:ListID) : int = 
   let tag = "66="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteListSeqNo (dest:byte []) (nextFreeIdx:int) (valIn:ListSeqNo) : int = 
   let tag = "67="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTotNoOrders (dest:byte []) (nextFreeIdx:int) (valIn:TotNoOrders) : int = 
   let tag = "68="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteListExecInst (dest:byte []) (nextFreeIdx:int) (valIn:ListExecInst) : int = 
   let tag = "69="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllocID (dest:byte []) (nextFreeIdx:int) (valIn:AllocID) : int = 
   let tag = "70="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteRefAllocID (dest:byte []) (nextFreeIdx:int) (valIn:RefAllocID) : int = 
   let tag = "72="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoOrders (dest:byte []) (nextFreeIdx:int) (valIn:NoOrders) : int = 
   let tag = "73="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAvgPxPrecision (dest:byte []) (nextFreeIdx:int) (valIn:AvgPxPrecision) : int = 
   let tag = "74="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradeDate (dest:byte []) (nextFreeIdx:int) (valIn:TradeDate) : int = 
   let tag = "75="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoAllocs (dest:byte []) (nextFreeIdx:int) (valIn:NoAllocs) : int = 
   let tag = "78="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllocAccount (dest:byte []) (nextFreeIdx:int) (valIn:AllocAccount) : int = 
   let tag = "79="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllocQty (dest:byte []) (nextFreeIdx:int) (valIn:AllocQty) : int = 
   let tag = "80="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoRpts (dest:byte []) (nextFreeIdx:int) (valIn:NoRpts) : int = 
   let tag = "82="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRptSeq (dest:byte []) (nextFreeIdx:int) (valIn:RptSeq) : int = 
   let tag = "83="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCxlQty (dest:byte []) (nextFreeIdx:int) (valIn:CxlQty) : int = 
   let tag = "84="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoDlvyInst (dest:byte []) (nextFreeIdx:int) (valIn:NoDlvyInst) : int = 
   let tag = "85="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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
let WriteSignature (dest:byte []) (nextFreeIdx:int) (fld:Signature) : int =
    // write the string length part of the compound msg
    let lenTag = "93="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "89="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteSecureData (dest:byte []) (nextFreeIdx:int) (fld:SecureData) : int =
    // write the string length part of the compound msg
    let lenTag = "90="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "91="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


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
let WriteRawData (dest:byte []) (nextFreeIdx:int) (fld:RawData) : int =
    // write the string length part of the compound msg
    let lenTag = "95="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "96="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


let WritePossResend (dest:byte []) (nextFreeIdx:int) (valIn:PossResend) : int = 
   let tag = "97="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteStopPx (dest:byte []) (nextFreeIdx:int) (valIn:StopPx) : int = 
   let tag = "99="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteExDestination (dest:byte []) (nextFreeIdx:int) (valIn:ExDestination) : int = 
   let tag = "100="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteWaveNo (dest:byte []) (nextFreeIdx:int) (valIn:WaveNo) : int = 
   let tag = "105="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteIssuer (dest:byte []) (nextFreeIdx:int) (valIn:Issuer) : int = 
   let tag = "106="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSecurityDesc (dest:byte []) (nextFreeIdx:int) (valIn:SecurityDesc) : int = 
   let tag = "107="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteHeartBtInt (dest:byte []) (nextFreeIdx:int) (valIn:HeartBtInt) : int = 
   let tag = "108="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMinQty (dest:byte []) (nextFreeIdx:int) (valIn:MinQty) : int = 
   let tag = "110="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMaxFloor (dest:byte []) (nextFreeIdx:int) (valIn:MaxFloor) : int = 
   let tag = "111="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTestReqID (dest:byte []) (nextFreeIdx:int) (valIn:TestReqID) : int = 
   let tag = "112="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteReportToExch (dest:byte []) (nextFreeIdx:int) (valIn:ReportToExch) : int = 
   let tag = "113="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLocateReqd (dest:byte []) (nextFreeIdx:int) (valIn:LocateReqd) : int = 
   let tag = "114="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOnBehalfOfCompID (dest:byte []) (nextFreeIdx:int) (valIn:OnBehalfOfCompID) : int = 
   let tag = "115="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOnBehalfOfSubID (dest:byte []) (nextFreeIdx:int) (valIn:OnBehalfOfSubID) : int = 
   let tag = "116="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteQuoteID (dest:byte []) (nextFreeIdx:int) (valIn:QuoteID) : int = 
   let tag = "117="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNetMoney (dest:byte []) (nextFreeIdx:int) (valIn:NetMoney) : int = 
   let tag = "118="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlCurrAmt (dest:byte []) (nextFreeIdx:int) (valIn:SettlCurrAmt) : int = 
   let tag = "119="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlCurrency (dest:byte []) (nextFreeIdx:int) (valIn:SettlCurrency) : int = 
   let tag = "120="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteForexReq (dest:byte []) (nextFreeIdx:int) (valIn:ForexReq) : int = 
   let tag = "121="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOrigSendingTime (dest:byte []) (nextFreeIdx:int) (valIn:OrigSendingTime) : int = 
   let tag = "122="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteGapFillFlag (dest:byte []) (nextFreeIdx:int) (valIn:GapFillFlag) : int = 
   let tag = "123="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoExecs (dest:byte []) (nextFreeIdx:int) (valIn:NoExecs) : int = 
   let tag = "124="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteExpireTime (dest:byte []) (nextFreeIdx:int) (valIn:ExpireTime) : int = 
   let tag = "126="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteDeliverToCompID (dest:byte []) (nextFreeIdx:int) (valIn:DeliverToCompID) : int = 
   let tag = "128="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteDeliverToSubID (dest:byte []) (nextFreeIdx:int) (valIn:DeliverToSubID) : int = 
   let tag = "129="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteIOINaturalFlag (dest:byte []) (nextFreeIdx:int) (valIn:IOINaturalFlag) : int = 
   let tag = "130="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteQuoteReqID (dest:byte []) (nextFreeIdx:int) (valIn:QuoteReqID) : int = 
   let tag = "131="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBidPx (dest:byte []) (nextFreeIdx:int) (valIn:BidPx) : int = 
   let tag = "132="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOfferPx (dest:byte []) (nextFreeIdx:int) (valIn:OfferPx) : int = 
   let tag = "133="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBidSize (dest:byte []) (nextFreeIdx:int) (valIn:BidSize) : int = 
   let tag = "134="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOfferSize (dest:byte []) (nextFreeIdx:int) (valIn:OfferSize) : int = 
   let tag = "135="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoMiscFees (dest:byte []) (nextFreeIdx:int) (valIn:NoMiscFees) : int = 
   let tag = "136="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMiscFeeAmt (dest:byte []) (nextFreeIdx:int) (valIn:MiscFeeAmt) : int = 
   let tag = "137="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMiscFeeCurr (dest:byte []) (nextFreeIdx:int) (valIn:MiscFeeCurr) : int = 
   let tag = "138="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WritePrevClosePx (dest:byte []) (nextFreeIdx:int) (valIn:PrevClosePx) : int = 
   let tag = "140="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteResetSeqNumFlag (dest:byte []) (nextFreeIdx:int) (valIn:ResetSeqNumFlag) : int = 
   let tag = "141="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSenderLocationID (dest:byte []) (nextFreeIdx:int) (valIn:SenderLocationID) : int = 
   let tag = "142="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTargetLocationID (dest:byte []) (nextFreeIdx:int) (valIn:TargetLocationID) : int = 
   let tag = "143="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOnBehalfOfLocationID (dest:byte []) (nextFreeIdx:int) (valIn:OnBehalfOfLocationID) : int = 
   let tag = "144="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteDeliverToLocationID (dest:byte []) (nextFreeIdx:int) (valIn:DeliverToLocationID) : int = 
   let tag = "145="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoRelatedSym (dest:byte []) (nextFreeIdx:int) (valIn:NoRelatedSym) : int = 
   let tag = "146="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSubject (dest:byte []) (nextFreeIdx:int) (valIn:Subject) : int = 
   let tag = "147="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteHeadline (dest:byte []) (nextFreeIdx:int) (valIn:Headline) : int = 
   let tag = "148="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteURLLink (dest:byte []) (nextFreeIdx:int) (valIn:URLLink) : int = 
   let tag = "149="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteLeavesQty (dest:byte []) (nextFreeIdx:int) (valIn:LeavesQty) : int = 
   let tag = "151="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCashOrderQty (dest:byte []) (nextFreeIdx:int) (valIn:CashOrderQty) : int = 
   let tag = "152="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllocAvgPx (dest:byte []) (nextFreeIdx:int) (valIn:AllocAvgPx) : int = 
   let tag = "153="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllocNetMoney (dest:byte []) (nextFreeIdx:int) (valIn:AllocNetMoney) : int = 
   let tag = "154="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlCurrFxRate (dest:byte []) (nextFreeIdx:int) (valIn:SettlCurrFxRate) : int = 
   let tag = "155="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNumDaysInterest (dest:byte []) (nextFreeIdx:int) (valIn:NumDaysInterest) : int = 
   let tag = "157="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAccruedInterestRate (dest:byte []) (nextFreeIdx:int) (valIn:AccruedInterestRate) : int = 
   let tag = "158="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAccruedInterestAmt (dest:byte []) (nextFreeIdx:int) (valIn:AccruedInterestAmt) : int = 
   let tag = "159="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteAllocText (dest:byte []) (nextFreeIdx:int) (valIn:AllocText) : int = 
   let tag = "161="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlInstID (dest:byte []) (nextFreeIdx:int) (valIn:SettlInstID) : int = 
   let tag = "162="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteEmailThreadID (dest:byte []) (nextFreeIdx:int) (valIn:EmailThreadID) : int = 
   let tag = "164="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteEffectiveTime (dest:byte []) (nextFreeIdx:int) (valIn:EffectiveTime) : int = 
   let tag = "168="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteStandInstDbName (dest:byte []) (nextFreeIdx:int) (valIn:StandInstDbName) : int = 
   let tag = "170="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteStandInstDbID (dest:byte []) (nextFreeIdx:int) (valIn:StandInstDbID) : int = 
   let tag = "171="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteBidSpotRate (dest:byte []) (nextFreeIdx:int) (valIn:BidSpotRate) : int = 
   let tag = "188="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBidForwardPoints (dest:byte []) (nextFreeIdx:int) (valIn:BidForwardPoints) : int = 
   let tag = "189="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOfferSpotRate (dest:byte []) (nextFreeIdx:int) (valIn:OfferSpotRate) : int = 
   let tag = "190="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOfferForwardPoints (dest:byte []) (nextFreeIdx:int) (valIn:OfferForwardPoints) : int = 
   let tag = "191="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOrderQty2 (dest:byte []) (nextFreeIdx:int) (valIn:OrderQty2) : int = 
   let tag = "192="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlDate2 (dest:byte []) (nextFreeIdx:int) (valIn:SettlDate2) : int = 
   let tag = "193="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLastSpotRate (dest:byte []) (nextFreeIdx:int) (valIn:LastSpotRate) : int = 
   let tag = "194="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLastForwardPoints (dest:byte []) (nextFreeIdx:int) (valIn:LastForwardPoints) : int = 
   let tag = "195="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllocLinkID (dest:byte []) (nextFreeIdx:int) (valIn:AllocLinkID) : int = 
   let tag = "196="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteSecondaryOrderID (dest:byte []) (nextFreeIdx:int) (valIn:SecondaryOrderID) : int = 
   let tag = "198="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoIOIQualifiers (dest:byte []) (nextFreeIdx:int) (valIn:NoIOIQualifiers) : int = 
   let tag = "199="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMaturityMonthYear (dest:byte []) (nextFreeIdx:int) (valIn:MaturityMonthYear) : int = 
   let tag = "200="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteStrikePrice (dest:byte []) (nextFreeIdx:int) (valIn:StrikePrice) : int = 
   let tag = "202="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteOptAttribute (dest:byte []) (nextFreeIdx:int) (valIn:OptAttribute) : int = 
   let tag = "206="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSecurityExchange (dest:byte []) (nextFreeIdx:int) (valIn:SecurityExchange) : int = 
   let tag = "207="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNotifyBrokerOfCredit (dest:byte []) (nextFreeIdx:int) (valIn:NotifyBrokerOfCredit) : int = 
   let tag = "208="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteMaxShow (dest:byte []) (nextFreeIdx:int) (valIn:MaxShow) : int = 
   let tag = "210="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePegOffsetValue (dest:byte []) (nextFreeIdx:int) (valIn:PegOffsetValue) : int = 
   let tag = "211="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteXmlData (dest:byte []) (nextFreeIdx:int) (fld:XmlData) : int =
    // write the string length part of the compound msg
    let lenTag = "212="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "213="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


let WriteSettlInstRefID (dest:byte []) (nextFreeIdx:int) (valIn:SettlInstRefID) : int = 
   let tag = "214="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoRoutingIDs (dest:byte []) (nextFreeIdx:int) (valIn:NoRoutingIDs) : int = 
   let tag = "215="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteRoutingID (dest:byte []) (nextFreeIdx:int) (valIn:RoutingID) : int = 
   let tag = "217="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSpread (dest:byte []) (nextFreeIdx:int) (valIn:Spread) : int = 
   let tag = "218="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBenchmarkCurveCurrency (dest:byte []) (nextFreeIdx:int) (valIn:BenchmarkCurveCurrency) : int = 
   let tag = "220="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteBenchmarkCurvePoint (dest:byte []) (nextFreeIdx:int) (valIn:BenchmarkCurvePoint) : int = 
   let tag = "222="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCouponRate (dest:byte []) (nextFreeIdx:int) (valIn:CouponRate) : int = 
   let tag = "223="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCouponPaymentDate (dest:byte []) (nextFreeIdx:int) (valIn:CouponPaymentDate) : int = 
   let tag = "224="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteIssueDate (dest:byte []) (nextFreeIdx:int) (valIn:IssueDate) : int = 
   let tag = "225="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRepurchaseTerm (dest:byte []) (nextFreeIdx:int) (valIn:RepurchaseTerm) : int = 
   let tag = "226="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRepurchaseRate (dest:byte []) (nextFreeIdx:int) (valIn:RepurchaseRate) : int = 
   let tag = "227="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteFactor (dest:byte []) (nextFreeIdx:int) (valIn:Factor) : int = 
   let tag = "228="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradeOriginationDate (dest:byte []) (nextFreeIdx:int) (valIn:TradeOriginationDate) : int = 
   let tag = "229="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteExDate (dest:byte []) (nextFreeIdx:int) (valIn:ExDate) : int = 
   let tag = "230="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteContractMultiplier (dest:byte []) (nextFreeIdx:int) (valIn:ContractMultiplier) : int = 
   let tag = "231="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoStipulations (dest:byte []) (nextFreeIdx:int) (valIn:NoStipulations) : int = 
   let tag = "232="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteYield (dest:byte []) (nextFreeIdx:int) (valIn:Yield) : int = 
   let tag = "236="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTotalTakedown (dest:byte []) (nextFreeIdx:int) (valIn:TotalTakedown) : int = 
   let tag = "237="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteConcession (dest:byte []) (nextFreeIdx:int) (valIn:Concession) : int = 
   let tag = "238="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRepoCollateralSecurityType (dest:byte []) (nextFreeIdx:int) (valIn:RepoCollateralSecurityType) : int = 
   let tag = "239="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRedemptionDate (dest:byte []) (nextFreeIdx:int) (valIn:RedemptionDate) : int = 
   let tag = "240="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingCouponPaymentDate (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingCouponPaymentDate) : int = 
   let tag = "241="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingIssueDate (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingIssueDate) : int = 
   let tag = "242="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingRepoCollateralSecurityType (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingRepoCollateralSecurityType) : int = 
   let tag = "243="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingRepurchaseTerm (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingRepurchaseTerm) : int = 
   let tag = "244="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingRepurchaseRate (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingRepurchaseRate) : int = 
   let tag = "245="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingFactor (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingFactor) : int = 
   let tag = "246="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingRedemptionDate (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingRedemptionDate) : int = 
   let tag = "247="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegCouponPaymentDate (dest:byte []) (nextFreeIdx:int) (valIn:LegCouponPaymentDate) : int = 
   let tag = "248="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegIssueDate (dest:byte []) (nextFreeIdx:int) (valIn:LegIssueDate) : int = 
   let tag = "249="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegRepoCollateralSecurityType (dest:byte []) (nextFreeIdx:int) (valIn:LegRepoCollateralSecurityType) : int = 
   let tag = "250="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegRepurchaseTerm (dest:byte []) (nextFreeIdx:int) (valIn:LegRepurchaseTerm) : int = 
   let tag = "251="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegRepurchaseRate (dest:byte []) (nextFreeIdx:int) (valIn:LegRepurchaseRate) : int = 
   let tag = "252="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegFactor (dest:byte []) (nextFreeIdx:int) (valIn:LegFactor) : int = 
   let tag = "253="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegRedemptionDate (dest:byte []) (nextFreeIdx:int) (valIn:LegRedemptionDate) : int = 
   let tag = "254="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCreditRating (dest:byte []) (nextFreeIdx:int) (valIn:CreditRating) : int = 
   let tag = "255="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingCreditRating (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingCreditRating) : int = 
   let tag = "256="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegCreditRating (dest:byte []) (nextFreeIdx:int) (valIn:LegCreditRating) : int = 
   let tag = "257="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradedFlatSwitch (dest:byte []) (nextFreeIdx:int) (valIn:TradedFlatSwitch) : int = 
   let tag = "258="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBasisFeatureDate (dest:byte []) (nextFreeIdx:int) (valIn:BasisFeatureDate) : int = 
   let tag = "259="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBasisFeaturePrice (dest:byte []) (nextFreeIdx:int) (valIn:BasisFeaturePrice) : int = 
   let tag = "260="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMDReqID (dest:byte []) (nextFreeIdx:int) (valIn:MDReqID) : int = 
   let tag = "262="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteMarketDepth (dest:byte []) (nextFreeIdx:int) (valIn:MarketDepth) : int = 
   let tag = "264="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteAggregatedBook (dest:byte []) (nextFreeIdx:int) (valIn:AggregatedBook) : int = 
   let tag = "266="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoMDEntryTypes (dest:byte []) (nextFreeIdx:int) (valIn:NoMDEntryTypes) : int = 
   let tag = "267="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoMDEntries (dest:byte []) (nextFreeIdx:int) (valIn:NoMDEntries) : int = 
   let tag = "268="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteMDEntryPx (dest:byte []) (nextFreeIdx:int) (valIn:MDEntryPx) : int = 
   let tag = "270="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMDEntrySize (dest:byte []) (nextFreeIdx:int) (valIn:MDEntrySize) : int = 
   let tag = "271="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMDEntryDate (dest:byte []) (nextFreeIdx:int) (valIn:MDEntryDate) : int = 
   let tag = "272="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMDEntryTime (dest:byte []) (nextFreeIdx:int) (valIn:MDEntryTime) : int = 
   let tag = "273="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteMDMkt (dest:byte []) (nextFreeIdx:int) (valIn:MDMkt) : int = 
   let tag = "275="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteMDEntryID (dest:byte []) (nextFreeIdx:int) (valIn:MDEntryID) : int = 
   let tag = "278="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteMDEntryRefID (dest:byte []) (nextFreeIdx:int) (valIn:MDEntryRefID) : int = 
   let tag = "280="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteMDEntryOriginator (dest:byte []) (nextFreeIdx:int) (valIn:MDEntryOriginator) : int = 
   let tag = "282="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLocationID (dest:byte []) (nextFreeIdx:int) (valIn:LocationID) : int = 
   let tag = "283="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteDeskID (dest:byte []) (nextFreeIdx:int) (valIn:DeskID) : int = 
   let tag = "284="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteSellerDays (dest:byte []) (nextFreeIdx:int) (valIn:SellerDays) : int = 
   let tag = "287="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMDEntryBuyer (dest:byte []) (nextFreeIdx:int) (valIn:MDEntryBuyer) : int = 
   let tag = "288="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMDEntrySeller (dest:byte []) (nextFreeIdx:int) (valIn:MDEntrySeller) : int = 
   let tag = "289="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMDEntryPositionNo (dest:byte []) (nextFreeIdx:int) (valIn:MDEntryPositionNo) : int = 
   let tag = "290="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteDefBidSize (dest:byte []) (nextFreeIdx:int) (valIn:DefBidSize) : int = 
   let tag = "293="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteDefOfferSize (dest:byte []) (nextFreeIdx:int) (valIn:DefOfferSize) : int = 
   let tag = "294="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoQuoteEntries (dest:byte []) (nextFreeIdx:int) (valIn:NoQuoteEntries) : int = 
   let tag = "295="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoQuoteSets (dest:byte []) (nextFreeIdx:int) (valIn:NoQuoteSets) : int = 
   let tag = "296="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteQuoteEntryID (dest:byte []) (nextFreeIdx:int) (valIn:QuoteEntryID) : int = 
   let tag = "299="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteQuoteSetID (dest:byte []) (nextFreeIdx:int) (valIn:QuoteSetID) : int = 
   let tag = "302="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteTotNoQuoteEntries (dest:byte []) (nextFreeIdx:int) (valIn:TotNoQuoteEntries) : int = 
   let tag = "304="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingSecurityIDSource (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingSecurityIDSource) : int = 
   let tag = "305="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingIssuer (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingIssuer) : int = 
   let tag = "306="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingSecurityDesc (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingSecurityDesc) : int = 
   let tag = "307="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingSecurityExchange (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingSecurityExchange) : int = 
   let tag = "308="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingSecurityID (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingSecurityID) : int = 
   let tag = "309="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingSecurityType (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingSecurityType) : int = 
   let tag = "310="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingSymbol (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingSymbol) : int = 
   let tag = "311="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingSymbolSfx (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingSymbolSfx) : int = 
   let tag = "312="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingMaturityMonthYear (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingMaturityMonthYear) : int = 
   let tag = "313="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteUnderlyingStrikePrice (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingStrikePrice) : int = 
   let tag = "316="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingOptAttribute (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingOptAttribute) : int = 
   let tag = "317="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingCurrency (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingCurrency) : int = 
   let tag = "318="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSecurityReqID (dest:byte []) (nextFreeIdx:int) (valIn:SecurityReqID) : int = 
   let tag = "320="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteSecurityResponseID (dest:byte []) (nextFreeIdx:int) (valIn:SecurityResponseID) : int = 
   let tag = "322="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteSecurityStatusReqID (dest:byte []) (nextFreeIdx:int) (valIn:SecurityStatusReqID) : int = 
   let tag = "324="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnsolicitedIndicator (dest:byte []) (nextFreeIdx:int) (valIn:UnsolicitedIndicator) : int = 
   let tag = "325="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteInViewOfCommon (dest:byte []) (nextFreeIdx:int) (valIn:InViewOfCommon) : int = 
   let tag = "328="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteDueToRelated (dest:byte []) (nextFreeIdx:int) (valIn:DueToRelated) : int = 
   let tag = "329="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBuyVolume (dest:byte []) (nextFreeIdx:int) (valIn:BuyVolume) : int = 
   let tag = "330="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSellVolume (dest:byte []) (nextFreeIdx:int) (valIn:SellVolume) : int = 
   let tag = "331="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteHighPx (dest:byte []) (nextFreeIdx:int) (valIn:HighPx) : int = 
   let tag = "332="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLowPx (dest:byte []) (nextFreeIdx:int) (valIn:LowPx) : int = 
   let tag = "333="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteTradSesReqID (dest:byte []) (nextFreeIdx:int) (valIn:TradSesReqID) : int = 
   let tag = "335="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradingSessionID (dest:byte []) (nextFreeIdx:int) (valIn:TradingSessionID) : int = 
   let tag = "336="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteContraTrader (dest:byte []) (nextFreeIdx:int) (valIn:ContraTrader) : int = 
   let tag = "337="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteTradSesStartTime (dest:byte []) (nextFreeIdx:int) (valIn:TradSesStartTime) : int = 
   let tag = "341="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradSesOpenTime (dest:byte []) (nextFreeIdx:int) (valIn:TradSesOpenTime) : int = 
   let tag = "342="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradSesPreCloseTime (dest:byte []) (nextFreeIdx:int) (valIn:TradSesPreCloseTime) : int = 
   let tag = "343="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradSesCloseTime (dest:byte []) (nextFreeIdx:int) (valIn:TradSesCloseTime) : int = 
   let tag = "344="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradSesEndTime (dest:byte []) (nextFreeIdx:int) (valIn:TradSesEndTime) : int = 
   let tag = "345="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNumberOfOrders (dest:byte []) (nextFreeIdx:int) (valIn:NumberOfOrders) : int = 
   let tag = "346="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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
let WriteEncodedIssuer (dest:byte []) (nextFreeIdx:int) (fld:EncodedIssuer) : int =
    // write the string length part of the compound msg
    let lenTag = "348="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "349="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteEncodedSecurityDesc (dest:byte []) (nextFreeIdx:int) (fld:EncodedSecurityDesc) : int =
    // write the string length part of the compound msg
    let lenTag = "350="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "351="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteEncodedListExecInst (dest:byte []) (nextFreeIdx:int) (fld:EncodedListExecInst) : int =
    // write the string length part of the compound msg
    let lenTag = "352="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "353="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteEncodedText (dest:byte []) (nextFreeIdx:int) (fld:EncodedText) : int =
    // write the string length part of the compound msg
    let lenTag = "354="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "355="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteEncodedSubject (dest:byte []) (nextFreeIdx:int) (fld:EncodedSubject) : int =
    // write the string length part of the compound msg
    let lenTag = "356="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "357="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteEncodedHeadline (dest:byte []) (nextFreeIdx:int) (fld:EncodedHeadline) : int =
    // write the string length part of the compound msg
    let lenTag = "358="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "359="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteEncodedAllocText (dest:byte []) (nextFreeIdx:int) (fld:EncodedAllocText) : int =
    // write the string length part of the compound msg
    let lenTag = "360="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "361="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteEncodedUnderlyingIssuer (dest:byte []) (nextFreeIdx:int) (fld:EncodedUnderlyingIssuer) : int =
    // write the string length part of the compound msg
    let lenTag = "362="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "363="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteEncodedUnderlyingSecurityDesc (dest:byte []) (nextFreeIdx:int) (fld:EncodedUnderlyingSecurityDesc) : int =
    // write the string length part of the compound msg
    let lenTag = "364="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "365="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


let WriteAllocPrice (dest:byte []) (nextFreeIdx:int) (valIn:AllocPrice) : int = 
   let tag = "366="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteQuoteSetValidUntilTime (dest:byte []) (nextFreeIdx:int) (valIn:QuoteSetValidUntilTime) : int = 
   let tag = "367="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteLastMsgSeqNumProcessed (dest:byte []) (nextFreeIdx:int) (valIn:LastMsgSeqNumProcessed) : int = 
   let tag = "369="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRefTagID (dest:byte []) (nextFreeIdx:int) (valIn:RefTagID) : int = 
   let tag = "371="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRefMsgType (dest:byte []) (nextFreeIdx:int) (valIn:RefMsgType) : int = 
   let tag = "372="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteContraBroker (dest:byte []) (nextFreeIdx:int) (valIn:ContraBroker) : int = 
   let tag = "375="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteComplianceID (dest:byte []) (nextFreeIdx:int) (valIn:ComplianceID) : int = 
   let tag = "376="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSolicitedFlag (dest:byte []) (nextFreeIdx:int) (valIn:SolicitedFlag) : int = 
   let tag = "377="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteBusinessRejectRefID (dest:byte []) (nextFreeIdx:int) (valIn:BusinessRejectRefID) : int = 
   let tag = "379="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteGrossTradeAmt (dest:byte []) (nextFreeIdx:int) (valIn:GrossTradeAmt) : int = 
   let tag = "381="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoContraBrokers (dest:byte []) (nextFreeIdx:int) (valIn:NoContraBrokers) : int = 
   let tag = "382="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMaxMessageSize (dest:byte []) (nextFreeIdx:int) (valIn:MaxMessageSize) : int = 
   let tag = "383="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoMsgTypes (dest:byte []) (nextFreeIdx:int) (valIn:NoMsgTypes) : int = 
   let tag = "384="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoTradingSessions (dest:byte []) (nextFreeIdx:int) (valIn:NoTradingSessions) : int = 
   let tag = "386="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTotalVolumeTraded (dest:byte []) (nextFreeIdx:int) (valIn:TotalVolumeTraded) : int = 
   let tag = "387="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteDiscretionOffsetValue (dest:byte []) (nextFreeIdx:int) (valIn:DiscretionOffsetValue) : int = 
   let tag = "389="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBidID (dest:byte []) (nextFreeIdx:int) (valIn:BidID) : int = 
   let tag = "390="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteClientBidID (dest:byte []) (nextFreeIdx:int) (valIn:ClientBidID) : int = 
   let tag = "391="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteListName (dest:byte []) (nextFreeIdx:int) (valIn:ListName) : int = 
   let tag = "392="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTotNoRelatedSym (dest:byte []) (nextFreeIdx:int) (valIn:TotNoRelatedSym) : int = 
   let tag = "393="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNumTickets (dest:byte []) (nextFreeIdx:int) (valIn:NumTickets) : int = 
   let tag = "395="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSideValue1 (dest:byte []) (nextFreeIdx:int) (valIn:SideValue1) : int = 
   let tag = "396="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSideValue2 (dest:byte []) (nextFreeIdx:int) (valIn:SideValue2) : int = 
   let tag = "397="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoBidDescriptors (dest:byte []) (nextFreeIdx:int) (valIn:NoBidDescriptors) : int = 
   let tag = "398="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBidDescriptorType (dest:byte array) (nextFreeIdx:int) (xxIn:BidDescriptorType) : int =
    match xxIn with
    | BidDescriptorType.Sector ->
        let tag = "399=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter
    | BidDescriptorType.Country ->
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


let WriteBidDescriptor (dest:byte []) (nextFreeIdx:int) (valIn:BidDescriptor) : int = 
   let tag = "400="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteLiquidityPctLow (dest:byte []) (nextFreeIdx:int) (valIn:LiquidityPctLow) : int = 
   let tag = "402="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLiquidityPctHigh (dest:byte []) (nextFreeIdx:int) (valIn:LiquidityPctHigh) : int = 
   let tag = "403="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLiquidityValue (dest:byte []) (nextFreeIdx:int) (valIn:LiquidityValue) : int = 
   let tag = "404="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteEFPTrackingError (dest:byte []) (nextFreeIdx:int) (valIn:EFPTrackingError) : int = 
   let tag = "405="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteFairValue (dest:byte []) (nextFreeIdx:int) (valIn:FairValue) : int = 
   let tag = "406="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOutsideIndexPct (dest:byte []) (nextFreeIdx:int) (valIn:OutsideIndexPct) : int = 
   let tag = "407="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteValueOfFutures (dest:byte []) (nextFreeIdx:int) (valIn:ValueOfFutures) : int = 
   let tag = "408="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteWtAverageLiquidity (dest:byte []) (nextFreeIdx:int) (valIn:WtAverageLiquidity) : int = 
   let tag = "410="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteExchangeForPhysical (dest:byte []) (nextFreeIdx:int) (valIn:ExchangeForPhysical) : int = 
   let tag = "411="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOutMainCntryUIndex (dest:byte []) (nextFreeIdx:int) (valIn:OutMainCntryUIndex) : int = 
   let tag = "412="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCrossPercent (dest:byte []) (nextFreeIdx:int) (valIn:CrossPercent) : int = 
   let tag = "413="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteProgPeriodInterval (dest:byte []) (nextFreeIdx:int) (valIn:ProgPeriodInterval) : int = 
   let tag = "415="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNumBidders (dest:byte []) (nextFreeIdx:int) (valIn:NumBidders) : int = 
   let tag = "417="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoBidComponents (dest:byte []) (nextFreeIdx:int) (valIn:NoBidComponents) : int = 
   let tag = "420="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCountry (dest:byte []) (nextFreeIdx:int) (valIn:Country) : int = 
   let tag = "421="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTotNoStrikes (dest:byte []) (nextFreeIdx:int) (valIn:TotNoStrikes) : int = 
   let tag = "422="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteDayOrderQty (dest:byte []) (nextFreeIdx:int) (valIn:DayOrderQty) : int = 
   let tag = "424="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteDayCumQty (dest:byte []) (nextFreeIdx:int) (valIn:DayCumQty) : int = 
   let tag = "425="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteDayAvgPx (dest:byte []) (nextFreeIdx:int) (valIn:DayAvgPx) : int = 
   let tag = "426="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoStrikes (dest:byte []) (nextFreeIdx:int) (valIn:NoStrikes) : int = 
   let tag = "428="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteExpireDate (dest:byte []) (nextFreeIdx:int) (valIn:ExpireDate) : int = 
   let tag = "432="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteUnderlyingCouponRate (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingCouponRate) : int = 
   let tag = "435="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingContractMultiplier (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingContractMultiplier) : int = 
   let tag = "436="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteContraTradeQty (dest:byte []) (nextFreeIdx:int) (valIn:ContraTradeQty) : int = 
   let tag = "437="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteContraTradeTime (dest:byte []) (nextFreeIdx:int) (valIn:ContraTradeTime) : int = 
   let tag = "438="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLiquidityNumSecurities (dest:byte []) (nextFreeIdx:int) (valIn:LiquidityNumSecurities) : int = 
   let tag = "441="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteStrikeTime (dest:byte []) (nextFreeIdx:int) (valIn:StrikeTime) : int = 
   let tag = "443="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteListStatusText (dest:byte []) (nextFreeIdx:int) (valIn:ListStatusText) : int = 
   let tag = "444="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteEncodedListStatusText (dest:byte []) (nextFreeIdx:int) (fld:EncodedListStatusText) : int =
    // write the string length part of the compound msg
    let lenTag = "445="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "446="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


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


let WritePartyID (dest:byte []) (nextFreeIdx:int) (valIn:PartyID) : int = 
   let tag = "448="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNetChgPrevDay (dest:byte []) (nextFreeIdx:int) (valIn:NetChgPrevDay) : int = 
   let tag = "451="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoPartyIDs (dest:byte []) (nextFreeIdx:int) (valIn:NoPartyIDs) : int = 
   let tag = "453="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoSecurityAltID (dest:byte []) (nextFreeIdx:int) (valIn:NoSecurityAltID) : int = 
   let tag = "454="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSecurityAltID (dest:byte []) (nextFreeIdx:int) (valIn:SecurityAltID) : int = 
   let tag = "455="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSecurityAltIDSource (dest:byte []) (nextFreeIdx:int) (valIn:SecurityAltIDSource) : int = 
   let tag = "456="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoUnderlyingSecurityAltID (dest:byte []) (nextFreeIdx:int) (valIn:NoUnderlyingSecurityAltID) : int = 
   let tag = "457="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingSecurityAltID (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingSecurityAltID) : int = 
   let tag = "458="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingSecurityAltIDSource (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingSecurityAltIDSource) : int = 
   let tag = "459="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteCFICode (dest:byte []) (nextFreeIdx:int) (valIn:CFICode) : int = 
   let tag = "461="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingProduct (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingProduct) : int = 
   let tag = "462="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingCFICode (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingCFICode) : int = 
   let tag = "463="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTestMessageIndicator (dest:byte []) (nextFreeIdx:int) (valIn:TestMessageIndicator) : int = 
   let tag = "464="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteBookingRefID (dest:byte []) (nextFreeIdx:int) (valIn:BookingRefID) : int = 
   let tag = "466="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteIndividualAllocID (dest:byte []) (nextFreeIdx:int) (valIn:IndividualAllocID) : int = 
   let tag = "467="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteRoundingModulus (dest:byte []) (nextFreeIdx:int) (valIn:RoundingModulus) : int = 
   let tag = "469="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCountryOfIssue (dest:byte []) (nextFreeIdx:int) (valIn:CountryOfIssue) : int = 
   let tag = "470="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteStateOrProvinceOfIssue (dest:byte []) (nextFreeIdx:int) (valIn:StateOrProvinceOfIssue) : int = 
   let tag = "471="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLocaleOfIssue (dest:byte []) (nextFreeIdx:int) (valIn:LocaleOfIssue) : int = 
   let tag = "472="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoRegistDtls (dest:byte []) (nextFreeIdx:int) (valIn:NoRegistDtls) : int = 
   let tag = "473="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMailingDtls (dest:byte []) (nextFreeIdx:int) (valIn:MailingDtls) : int = 
   let tag = "474="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteInvestorCountryOfResidence (dest:byte []) (nextFreeIdx:int) (valIn:InvestorCountryOfResidence) : int = 
   let tag = "475="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePaymentRef (dest:byte []) (nextFreeIdx:int) (valIn:PaymentRef) : int = 
   let tag = "476="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteCashDistribCurr (dest:byte []) (nextFreeIdx:int) (valIn:CashDistribCurr) : int = 
   let tag = "478="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCommCurrency (dest:byte []) (nextFreeIdx:int) (valIn:CommCurrency) : int = 
   let tag = "479="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteMailingInst (dest:byte []) (nextFreeIdx:int) (valIn:MailingInst) : int = 
   let tag = "482="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTransBkdTime (dest:byte []) (nextFreeIdx:int) (valIn:TransBkdTime) : int = 
   let tag = "483="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteExecPriceAdjustment (dest:byte []) (nextFreeIdx:int) (valIn:ExecPriceAdjustment) : int = 
   let tag = "485="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteDateOfBirth (dest:byte []) (nextFreeIdx:int) (valIn:DateOfBirth) : int = 
   let tag = "486="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteCardHolderName (dest:byte []) (nextFreeIdx:int) (valIn:CardHolderName) : int = 
   let tag = "488="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCardNumber (dest:byte []) (nextFreeIdx:int) (valIn:CardNumber) : int = 
   let tag = "489="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCardExpDate (dest:byte []) (nextFreeIdx:int) (valIn:CardExpDate) : int = 
   let tag = "490="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCardIssNum (dest:byte []) (nextFreeIdx:int) (valIn:CardIssNum) : int = 
   let tag = "491="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteRegistAcctType (dest:byte []) (nextFreeIdx:int) (valIn:RegistAcctType) : int = 
   let tag = "493="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteDesignation (dest:byte []) (nextFreeIdx:int) (valIn:Designation) : int = 
   let tag = "494="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteRegistRejReasonText (dest:byte []) (nextFreeIdx:int) (valIn:RegistRejReasonText) : int = 
   let tag = "496="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteCashDistribAgentName (dest:byte []) (nextFreeIdx:int) (valIn:CashDistribAgentName) : int = 
   let tag = "498="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCashDistribAgentCode (dest:byte []) (nextFreeIdx:int) (valIn:CashDistribAgentCode) : int = 
   let tag = "499="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCashDistribAgentAcctNumber (dest:byte []) (nextFreeIdx:int) (valIn:CashDistribAgentAcctNumber) : int = 
   let tag = "500="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCashDistribPayRef (dest:byte []) (nextFreeIdx:int) (valIn:CashDistribPayRef) : int = 
   let tag = "501="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCashDistribAgentAcctName (dest:byte []) (nextFreeIdx:int) (valIn:CashDistribAgentAcctName) : int = 
   let tag = "502="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCardStartDate (dest:byte []) (nextFreeIdx:int) (valIn:CardStartDate) : int = 
   let tag = "503="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePaymentDate (dest:byte []) (nextFreeIdx:int) (valIn:PaymentDate) : int = 
   let tag = "504="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePaymentRemitterID (dest:byte []) (nextFreeIdx:int) (valIn:PaymentRemitterID) : int = 
   let tag = "505="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteRegistRefID (dest:byte []) (nextFreeIdx:int) (valIn:RegistRefID) : int = 
   let tag = "508="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRegistDtls (dest:byte []) (nextFreeIdx:int) (valIn:RegistDtls) : int = 
   let tag = "509="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoDistribInsts (dest:byte []) (nextFreeIdx:int) (valIn:NoDistribInsts) : int = 
   let tag = "510="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRegistEmail (dest:byte []) (nextFreeIdx:int) (valIn:RegistEmail) : int = 
   let tag = "511="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteDistribPercentage (dest:byte []) (nextFreeIdx:int) (valIn:DistribPercentage) : int = 
   let tag = "512="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRegistID (dest:byte []) (nextFreeIdx:int) (valIn:RegistID) : int = 
   let tag = "513="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteExecValuationPoint (dest:byte []) (nextFreeIdx:int) (valIn:ExecValuationPoint) : int = 
   let tag = "515="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOrderPercent (dest:byte []) (nextFreeIdx:int) (valIn:OrderPercent) : int = 
   let tag = "516="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoContAmts (dest:byte []) (nextFreeIdx:int) (valIn:NoContAmts) : int = 
   let tag = "518="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteContAmtValue (dest:byte []) (nextFreeIdx:int) (valIn:ContAmtValue) : int = 
   let tag = "520="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteContAmtCurr (dest:byte []) (nextFreeIdx:int) (valIn:ContAmtCurr) : int = 
   let tag = "521="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WritePartySubID (dest:byte []) (nextFreeIdx:int) (valIn:PartySubID) : int = 
   let tag = "523="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNestedPartyID (dest:byte []) (nextFreeIdx:int) (valIn:NestedPartyID) : int = 
   let tag = "524="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNestedPartyIDSource (dest:byte []) (nextFreeIdx:int) (valIn:NestedPartyIDSource) : int = 
   let tag = "525="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSecondaryClOrdID (dest:byte []) (nextFreeIdx:int) (valIn:SecondaryClOrdID) : int = 
   let tag = "526="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSecondaryExecID (dest:byte []) (nextFreeIdx:int) (valIn:SecondaryExecID) : int = 
   let tag = "527="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteTotalAffectedOrders (dest:byte []) (nextFreeIdx:int) (valIn:TotalAffectedOrders) : int = 
   let tag = "533="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoAffectedOrders (dest:byte []) (nextFreeIdx:int) (valIn:NoAffectedOrders) : int = 
   let tag = "534="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAffectedOrderID (dest:byte []) (nextFreeIdx:int) (valIn:AffectedOrderID) : int = 
   let tag = "535="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAffectedSecondaryOrderID (dest:byte []) (nextFreeIdx:int) (valIn:AffectedSecondaryOrderID) : int = 
   let tag = "536="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNestedPartyRole (dest:byte []) (nextFreeIdx:int) (valIn:NestedPartyRole) : int = 
   let tag = "538="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoNestedPartyIDs (dest:byte []) (nextFreeIdx:int) (valIn:NoNestedPartyIDs) : int = 
   let tag = "539="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTotalAccruedInterestAmt (dest:byte []) (nextFreeIdx:int) (valIn:TotalAccruedInterestAmt) : int = 
   let tag = "540="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMaturityDate (dest:byte []) (nextFreeIdx:int) (valIn:MaturityDate) : int = 
   let tag = "541="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingMaturityDate (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingMaturityDate) : int = 
   let tag = "542="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteInstrRegistry (dest:byte []) (nextFreeIdx:int) (valIn:InstrRegistry) : int = 
   let tag = "543="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNestedPartySubID (dest:byte []) (nextFreeIdx:int) (valIn:NestedPartySubID) : int = 
   let tag = "545="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteMDImplicitDelete (dest:byte []) (nextFreeIdx:int) (valIn:MDImplicitDelete) : int = 
   let tag = "547="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCrossID (dest:byte []) (nextFreeIdx:int) (valIn:CrossID) : int = 
   let tag = "548="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteOrigCrossID (dest:byte []) (nextFreeIdx:int) (valIn:OrigCrossID) : int = 
   let tag = "551="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteUsername (dest:byte []) (nextFreeIdx:int) (valIn:Username) : int = 
   let tag = "553="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePassword (dest:byte []) (nextFreeIdx:int) (valIn:Password) : int = 
   let tag = "554="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoLegs (dest:byte []) (nextFreeIdx:int) (valIn:NoLegs) : int = 
   let tag = "555="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegCurrency (dest:byte []) (nextFreeIdx:int) (valIn:LegCurrency) : int = 
   let tag = "556="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTotNoSecurityTypes (dest:byte []) (nextFreeIdx:int) (valIn:TotNoSecurityTypes) : int = 
   let tag = "557="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoSecurityTypes (dest:byte []) (nextFreeIdx:int) (valIn:NoSecurityTypes) : int = 
   let tag = "558="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteRoundLot (dest:byte []) (nextFreeIdx:int) (valIn:RoundLot) : int = 
   let tag = "561="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMinTradeVol (dest:byte []) (nextFreeIdx:int) (valIn:MinTradeVol) : int = 
   let tag = "562="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteLegPositionEffect (dest:byte []) (nextFreeIdx:int) (valIn:LegPositionEffect) : int = 
   let tag = "564="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegCoveredOrUncovered (dest:byte []) (nextFreeIdx:int) (valIn:LegCoveredOrUncovered) : int = 
   let tag = "565="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegPrice (dest:byte []) (nextFreeIdx:int) (valIn:LegPrice) : int = 
   let tag = "566="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradSesStatusRejReason (dest:byte array) (nextFreeIdx:int) (xxIn:TradSesStatusRejReason) : int =
    match xxIn with
    | TradSesStatusRejReason.UnknownOrInvalidTradingsessionid ->
        let tag = "567=1"B
        Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
        let nextFreeIdx2 = nextFreeIdx + tag.Length
        dest.[nextFreeIdx2] <- 1uy // write the SOH field delimeter
        nextFreeIdx2 + 1 // +1 to include the delimeter


let WriteTradeRequestID (dest:byte []) (nextFreeIdx:int) (valIn:TradeRequestID) : int = 
   let tag = "568="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WritePreviouslyReported (dest:byte []) (nextFreeIdx:int) (valIn:PreviouslyReported) : int = 
   let tag = "570="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradeReportID (dest:byte []) (nextFreeIdx:int) (valIn:TradeReportID) : int = 
   let tag = "571="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradeReportRefID (dest:byte []) (nextFreeIdx:int) (valIn:TradeReportRefID) : int = 
   let tag = "572="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteMatchType (dest:byte []) (nextFreeIdx:int) (valIn:MatchType) : int = 
   let tag = "574="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOddLot (dest:byte []) (nextFreeIdx:int) (valIn:OddLot) : int = 
   let tag = "575="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoClearingInstructions (dest:byte []) (nextFreeIdx:int) (valIn:NoClearingInstructions) : int = 
   let tag = "576="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteTradeInputSource (dest:byte []) (nextFreeIdx:int) (valIn:TradeInputSource) : int = 
   let tag = "578="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradeInputDevice (dest:byte []) (nextFreeIdx:int) (valIn:TradeInputDevice) : int = 
   let tag = "579="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoDates (dest:byte []) (nextFreeIdx:int) (valIn:NoDates) : int = 
   let tag = "580="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteClOrdLinkID (dest:byte []) (nextFreeIdx:int) (valIn:ClOrdLinkID) : int = 
   let tag = "583="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMassStatusReqID (dest:byte []) (nextFreeIdx:int) (valIn:MassStatusReqID) : int = 
   let tag = "584="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteOrigOrdModTime (dest:byte []) (nextFreeIdx:int) (valIn:OrigOrdModTime) : int = 
   let tag = "586="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegSettlType (dest:byte []) (nextFreeIdx:int) (valIn:LegSettlType) : int = 
   let tag = "587="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegSettlDate (dest:byte []) (nextFreeIdx:int) (valIn:LegSettlDate) : int = 
   let tag = "588="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteUnderlyingCountryOfIssue (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingCountryOfIssue) : int = 
   let tag = "592="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingStateOrProvinceOfIssue (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingStateOrProvinceOfIssue) : int = 
   let tag = "593="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingLocaleOfIssue (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingLocaleOfIssue) : int = 
   let tag = "594="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingInstrRegistry (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingInstrRegistry) : int = 
   let tag = "595="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegCountryOfIssue (dest:byte []) (nextFreeIdx:int) (valIn:LegCountryOfIssue) : int = 
   let tag = "596="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegStateOrProvinceOfIssue (dest:byte []) (nextFreeIdx:int) (valIn:LegStateOrProvinceOfIssue) : int = 
   let tag = "597="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegLocaleOfIssue (dest:byte []) (nextFreeIdx:int) (valIn:LegLocaleOfIssue) : int = 
   let tag = "598="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegInstrRegistry (dest:byte []) (nextFreeIdx:int) (valIn:LegInstrRegistry) : int = 
   let tag = "599="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegSymbol (dest:byte []) (nextFreeIdx:int) (valIn:LegSymbol) : int = 
   let tag = "600="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegSymbolSfx (dest:byte []) (nextFreeIdx:int) (valIn:LegSymbolSfx) : int = 
   let tag = "601="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegSecurityID (dest:byte []) (nextFreeIdx:int) (valIn:LegSecurityID) : int = 
   let tag = "602="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegSecurityIDSource (dest:byte []) (nextFreeIdx:int) (valIn:LegSecurityIDSource) : int = 
   let tag = "603="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoLegSecurityAltID (dest:byte []) (nextFreeIdx:int) (valIn:NoLegSecurityAltID) : int = 
   let tag = "604="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegSecurityAltID (dest:byte []) (nextFreeIdx:int) (valIn:LegSecurityAltID) : int = 
   let tag = "605="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegSecurityAltIDSource (dest:byte []) (nextFreeIdx:int) (valIn:LegSecurityAltIDSource) : int = 
   let tag = "606="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegProduct (dest:byte []) (nextFreeIdx:int) (valIn:LegProduct) : int = 
   let tag = "607="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegCFICode (dest:byte []) (nextFreeIdx:int) (valIn:LegCFICode) : int = 
   let tag = "608="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegSecurityType (dest:byte []) (nextFreeIdx:int) (valIn:LegSecurityType) : int = 
   let tag = "609="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegMaturityMonthYear (dest:byte []) (nextFreeIdx:int) (valIn:LegMaturityMonthYear) : int = 
   let tag = "610="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegMaturityDate (dest:byte []) (nextFreeIdx:int) (valIn:LegMaturityDate) : int = 
   let tag = "611="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegStrikePrice (dest:byte []) (nextFreeIdx:int) (valIn:LegStrikePrice) : int = 
   let tag = "612="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegOptAttribute (dest:byte []) (nextFreeIdx:int) (valIn:LegOptAttribute) : int = 
   let tag = "613="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegContractMultiplier (dest:byte []) (nextFreeIdx:int) (valIn:LegContractMultiplier) : int = 
   let tag = "614="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegCouponRate (dest:byte []) (nextFreeIdx:int) (valIn:LegCouponRate) : int = 
   let tag = "615="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegSecurityExchange (dest:byte []) (nextFreeIdx:int) (valIn:LegSecurityExchange) : int = 
   let tag = "616="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegIssuer (dest:byte []) (nextFreeIdx:int) (valIn:LegIssuer) : int = 
   let tag = "617="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteEncodedLegIssuer (dest:byte []) (nextFreeIdx:int) (fld:EncodedLegIssuer) : int =
    // write the string length part of the compound msg
    let lenTag = "618="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "619="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


let WriteLegSecurityDesc (dest:byte []) (nextFreeIdx:int) (valIn:LegSecurityDesc) : int = 
   let tag = "620="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


// compound write, of a length field and the corresponding string field
let WriteEncodedLegSecurityDesc (dest:byte []) (nextFreeIdx:int) (fld:EncodedLegSecurityDesc) : int =
    // write the string length part of the compound msg
    let lenTag = "621="B
    Buffer.BlockCopy (lenTag, 0, dest, nextFreeIdx, lenTag.Length)
    let nextFreeIdx2 = nextFreeIdx + lenTag.Length
    let lenBs = ToBytes.Convert fld.Value.Length
    Buffer.BlockCopy (lenBs, 0, dest, nextFreeIdx2, lenBs.Length)
    let nextFreeIdx3 = nextFreeIdx2 + lenBs.Length
    dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
    let nextFreeIdx4 = nextFreeIdx3 + 1 // +1 to include the delimeter
    // write the string part of the compound msg
    let dataTag = "622="B // i.e. tag for the data field of the compound msg
    Buffer.BlockCopy (dataTag, 0, dest, nextFreeIdx4, dataTag.Length)
    let nextFreeIdx5 = nextFreeIdx4 + dataTag.Length
    let dataBs = fld.Value
    Buffer.BlockCopy (dataBs, 0, dest, nextFreeIdx5, dataBs.Length)
    let nextFreeIdx6 = nextFreeIdx5 + dataBs.Length
    dest.[nextFreeIdx6] <- 1uy // write the SOH field delimeter
    nextFreeIdx6 + 1 // +1 to include the delimeter


let WriteLegRatioQty (dest:byte []) (nextFreeIdx:int) (valIn:LegRatioQty) : int = 
   let tag = "623="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegSide (dest:byte []) (nextFreeIdx:int) (valIn:LegSide) : int = 
   let tag = "624="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradingSessionSubID (dest:byte []) (nextFreeIdx:int) (valIn:TradingSessionSubID) : int = 
   let tag = "625="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoHops (dest:byte []) (nextFreeIdx:int) (valIn:NoHops) : int = 
   let tag = "627="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteHopCompID (dest:byte []) (nextFreeIdx:int) (valIn:HopCompID) : int = 
   let tag = "628="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteHopSendingTime (dest:byte []) (nextFreeIdx:int) (valIn:HopSendingTime) : int = 
   let tag = "629="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteHopRefID (dest:byte []) (nextFreeIdx:int) (valIn:HopRefID) : int = 
   let tag = "630="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMidPx (dest:byte []) (nextFreeIdx:int) (valIn:MidPx) : int = 
   let tag = "631="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBidYield (dest:byte []) (nextFreeIdx:int) (valIn:BidYield) : int = 
   let tag = "632="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMidYield (dest:byte []) (nextFreeIdx:int) (valIn:MidYield) : int = 
   let tag = "633="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOfferYield (dest:byte []) (nextFreeIdx:int) (valIn:OfferYield) : int = 
   let tag = "634="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteWorkingIndicator (dest:byte []) (nextFreeIdx:int) (valIn:WorkingIndicator) : int = 
   let tag = "636="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegLastPx (dest:byte []) (nextFreeIdx:int) (valIn:LegLastPx) : int = 
   let tag = "637="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WritePriceImprovement (dest:byte []) (nextFreeIdx:int) (valIn:PriceImprovement) : int = 
   let tag = "639="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePrice2 (dest:byte []) (nextFreeIdx:int) (valIn:Price2) : int = 
   let tag = "640="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLastForwardPoints2 (dest:byte []) (nextFreeIdx:int) (valIn:LastForwardPoints2) : int = 
   let tag = "641="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBidForwardPoints2 (dest:byte []) (nextFreeIdx:int) (valIn:BidForwardPoints2) : int = 
   let tag = "642="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOfferForwardPoints2 (dest:byte []) (nextFreeIdx:int) (valIn:OfferForwardPoints2) : int = 
   let tag = "643="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRFQReqID (dest:byte []) (nextFreeIdx:int) (valIn:RFQReqID) : int = 
   let tag = "644="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMktBidPx (dest:byte []) (nextFreeIdx:int) (valIn:MktBidPx) : int = 
   let tag = "645="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMktOfferPx (dest:byte []) (nextFreeIdx:int) (valIn:MktOfferPx) : int = 
   let tag = "646="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMinBidSize (dest:byte []) (nextFreeIdx:int) (valIn:MinBidSize) : int = 
   let tag = "647="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMinOfferSize (dest:byte []) (nextFreeIdx:int) (valIn:MinOfferSize) : int = 
   let tag = "648="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteQuoteStatusReqID (dest:byte []) (nextFreeIdx:int) (valIn:QuoteStatusReqID) : int = 
   let tag = "649="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegalConfirm (dest:byte []) (nextFreeIdx:int) (valIn:LegalConfirm) : int = 
   let tag = "650="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingLastPx (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingLastPx) : int = 
   let tag = "651="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingLastQty (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingLastQty) : int = 
   let tag = "652="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegRefID (dest:byte []) (nextFreeIdx:int) (valIn:LegRefID) : int = 
   let tag = "654="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteContraLegRefID (dest:byte []) (nextFreeIdx:int) (valIn:ContraLegRefID) : int = 
   let tag = "655="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlCurrBidFxRate (dest:byte []) (nextFreeIdx:int) (valIn:SettlCurrBidFxRate) : int = 
   let tag = "656="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlCurrOfferFxRate (dest:byte []) (nextFreeIdx:int) (valIn:SettlCurrOfferFxRate) : int = 
   let tag = "657="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteSideComplianceID (dest:byte []) (nextFreeIdx:int) (valIn:SideComplianceID) : int = 
   let tag = "659="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteAllocAcctIDSource (dest:byte []) (nextFreeIdx:int) (valIn:AllocAcctIDSource) : int = 
   let tag = "661="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBenchmarkPrice (dest:byte []) (nextFreeIdx:int) (valIn:BenchmarkPrice) : int = 
   let tag = "662="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBenchmarkPriceType (dest:byte []) (nextFreeIdx:int) (valIn:BenchmarkPriceType) : int = 
   let tag = "663="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteConfirmID (dest:byte []) (nextFreeIdx:int) (valIn:ConfirmID) : int = 
   let tag = "664="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteContractSettlMonth (dest:byte []) (nextFreeIdx:int) (valIn:ContractSettlMonth) : int = 
   let tag = "667="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteLastParPx (dest:byte []) (nextFreeIdx:int) (valIn:LastParPx) : int = 
   let tag = "669="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoLegAllocs (dest:byte []) (nextFreeIdx:int) (valIn:NoLegAllocs) : int = 
   let tag = "670="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegAllocAccount (dest:byte []) (nextFreeIdx:int) (valIn:LegAllocAccount) : int = 
   let tag = "671="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegIndividualAllocID (dest:byte []) (nextFreeIdx:int) (valIn:LegIndividualAllocID) : int = 
   let tag = "672="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegAllocQty (dest:byte []) (nextFreeIdx:int) (valIn:LegAllocQty) : int = 
   let tag = "673="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegAllocAcctIDSource (dest:byte []) (nextFreeIdx:int) (valIn:LegAllocAcctIDSource) : int = 
   let tag = "674="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegSettlCurrency (dest:byte []) (nextFreeIdx:int) (valIn:LegSettlCurrency) : int = 
   let tag = "675="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegBenchmarkCurveCurrency (dest:byte []) (nextFreeIdx:int) (valIn:LegBenchmarkCurveCurrency) : int = 
   let tag = "676="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegBenchmarkCurveName (dest:byte []) (nextFreeIdx:int) (valIn:LegBenchmarkCurveName) : int = 
   let tag = "677="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegBenchmarkCurvePoint (dest:byte []) (nextFreeIdx:int) (valIn:LegBenchmarkCurvePoint) : int = 
   let tag = "678="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegBenchmarkPrice (dest:byte []) (nextFreeIdx:int) (valIn:LegBenchmarkPrice) : int = 
   let tag = "679="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegBenchmarkPriceType (dest:byte []) (nextFreeIdx:int) (valIn:LegBenchmarkPriceType) : int = 
   let tag = "680="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegBidPx (dest:byte []) (nextFreeIdx:int) (valIn:LegBidPx) : int = 
   let tag = "681="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegIOIQty (dest:byte []) (nextFreeIdx:int) (valIn:LegIOIQty) : int = 
   let tag = "682="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoLegStipulations (dest:byte []) (nextFreeIdx:int) (valIn:NoLegStipulations) : int = 
   let tag = "683="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegOfferPx (dest:byte []) (nextFreeIdx:int) (valIn:LegOfferPx) : int = 
   let tag = "684="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegOrderQty (dest:byte []) (nextFreeIdx:int) (valIn:LegOrderQty) : int = 
   let tag = "685="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegPriceType (dest:byte []) (nextFreeIdx:int) (valIn:LegPriceType) : int = 
   let tag = "686="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegQty (dest:byte []) (nextFreeIdx:int) (valIn:LegQty) : int = 
   let tag = "687="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegStipulationType (dest:byte []) (nextFreeIdx:int) (valIn:LegStipulationType) : int = 
   let tag = "688="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegStipulationValue (dest:byte []) (nextFreeIdx:int) (valIn:LegStipulationValue) : int = 
   let tag = "689="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WritePool (dest:byte []) (nextFreeIdx:int) (valIn:Pool) : int = 
   let tag = "691="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteQuoteRespID (dest:byte []) (nextFreeIdx:int) (valIn:QuoteRespID) : int = 
   let tag = "693="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteQuoteQualifier (dest:byte []) (nextFreeIdx:int) (valIn:QuoteQualifier) : int = 
   let tag = "695="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteYieldRedemptionDate (dest:byte []) (nextFreeIdx:int) (valIn:YieldRedemptionDate) : int = 
   let tag = "696="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteYieldRedemptionPrice (dest:byte []) (nextFreeIdx:int) (valIn:YieldRedemptionPrice) : int = 
   let tag = "697="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteYieldRedemptionPriceType (dest:byte []) (nextFreeIdx:int) (valIn:YieldRedemptionPriceType) : int = 
   let tag = "698="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBenchmarkSecurityID (dest:byte []) (nextFreeIdx:int) (valIn:BenchmarkSecurityID) : int = 
   let tag = "699="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteReversalIndicator (dest:byte []) (nextFreeIdx:int) (valIn:ReversalIndicator) : int = 
   let tag = "700="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteYieldCalcDate (dest:byte []) (nextFreeIdx:int) (valIn:YieldCalcDate) : int = 
   let tag = "701="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoPositions (dest:byte []) (nextFreeIdx:int) (valIn:NoPositions) : int = 
   let tag = "702="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteLongQty (dest:byte []) (nextFreeIdx:int) (valIn:LongQty) : int = 
   let tag = "704="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteShortQty (dest:byte []) (nextFreeIdx:int) (valIn:ShortQty) : int = 
   let tag = "705="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WritePosAmt (dest:byte []) (nextFreeIdx:int) (valIn:PosAmt) : int = 
   let tag = "708="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WritePosReqID (dest:byte []) (nextFreeIdx:int) (valIn:PosReqID) : int = 
   let tag = "710="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoUnderlyings (dest:byte []) (nextFreeIdx:int) (valIn:NoUnderlyings) : int = 
   let tag = "711="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteOrigPosReqRefID (dest:byte []) (nextFreeIdx:int) (valIn:OrigPosReqRefID) : int = 
   let tag = "713="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePosMaintRptRefID (dest:byte []) (nextFreeIdx:int) (valIn:PosMaintRptRefID) : int = 
   let tag = "714="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteClearingBusinessDate (dest:byte []) (nextFreeIdx:int) (valIn:ClearingBusinessDate) : int = 
   let tag = "715="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlSessID (dest:byte []) (nextFreeIdx:int) (valIn:SettlSessID) : int = 
   let tag = "716="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlSessSubID (dest:byte []) (nextFreeIdx:int) (valIn:SettlSessSubID) : int = 
   let tag = "717="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteContraryInstructionIndicator (dest:byte []) (nextFreeIdx:int) (valIn:ContraryInstructionIndicator) : int = 
   let tag = "719="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePriorSpreadIndicator (dest:byte []) (nextFreeIdx:int) (valIn:PriorSpreadIndicator) : int = 
   let tag = "720="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePosMaintRptID (dest:byte []) (nextFreeIdx:int) (valIn:PosMaintRptID) : int = 
   let tag = "721="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteResponseDestination (dest:byte []) (nextFreeIdx:int) (valIn:ResponseDestination) : int = 
   let tag = "726="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTotalNumPosReports (dest:byte []) (nextFreeIdx:int) (valIn:TotalNumPosReports) : int = 
   let tag = "727="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteSettlPrice (dest:byte []) (nextFreeIdx:int) (valIn:SettlPrice) : int = 
   let tag = "730="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteUnderlyingSettlPrice (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingSettlPrice) : int = 
   let tag = "732="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingSettlPriceType (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingSettlPriceType) : int = 
   let tag = "733="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePriorSettlPrice (dest:byte []) (nextFreeIdx:int) (valIn:PriorSettlPrice) : int = 
   let tag = "734="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoQuoteQualifiers (dest:byte []) (nextFreeIdx:int) (valIn:NoQuoteQualifiers) : int = 
   let tag = "735="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllocSettlCurrency (dest:byte []) (nextFreeIdx:int) (valIn:AllocSettlCurrency) : int = 
   let tag = "736="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllocSettlCurrAmt (dest:byte []) (nextFreeIdx:int) (valIn:AllocSettlCurrAmt) : int = 
   let tag = "737="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteInterestAtMaturity (dest:byte []) (nextFreeIdx:int) (valIn:InterestAtMaturity) : int = 
   let tag = "738="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegDatedDate (dest:byte []) (nextFreeIdx:int) (valIn:LegDatedDate) : int = 
   let tag = "739="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegPool (dest:byte []) (nextFreeIdx:int) (valIn:LegPool) : int = 
   let tag = "740="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllocInterestAtMaturity (dest:byte []) (nextFreeIdx:int) (valIn:AllocInterestAtMaturity) : int = 
   let tag = "741="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllocAccruedInterestAmt (dest:byte []) (nextFreeIdx:int) (valIn:AllocAccruedInterestAmt) : int = 
   let tag = "742="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteDeliveryDate (dest:byte []) (nextFreeIdx:int) (valIn:DeliveryDate) : int = 
   let tag = "743="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteAssignmentUnit (dest:byte []) (nextFreeIdx:int) (valIn:AssignmentUnit) : int = 
   let tag = "745="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOpenInterest (dest:byte []) (nextFreeIdx:int) (valIn:OpenInterest) : int = 
   let tag = "746="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteTotNumTradeReports (dest:byte []) (nextFreeIdx:int) (valIn:TotNumTradeReports) : int = 
   let tag = "748="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoPosAmt (dest:byte []) (nextFreeIdx:int) (valIn:NoPosAmt) : int = 
   let tag = "753="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAutoAcceptIndicator (dest:byte []) (nextFreeIdx:int) (valIn:AutoAcceptIndicator) : int = 
   let tag = "754="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllocReportID (dest:byte []) (nextFreeIdx:int) (valIn:AllocReportID) : int = 
   let tag = "755="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoNested2PartyIDs (dest:byte []) (nextFreeIdx:int) (valIn:NoNested2PartyIDs) : int = 
   let tag = "756="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNested2PartyID (dest:byte []) (nextFreeIdx:int) (valIn:Nested2PartyID) : int = 
   let tag = "757="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNested2PartyIDSource (dest:byte []) (nextFreeIdx:int) (valIn:Nested2PartyIDSource) : int = 
   let tag = "758="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNested2PartyRole (dest:byte []) (nextFreeIdx:int) (valIn:Nested2PartyRole) : int = 
   let tag = "759="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNested2PartySubID (dest:byte []) (nextFreeIdx:int) (valIn:Nested2PartySubID) : int = 
   let tag = "760="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteBenchmarkSecurityIDSource (dest:byte []) (nextFreeIdx:int) (valIn:BenchmarkSecurityIDSource) : int = 
   let tag = "761="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSecuritySubType (dest:byte []) (nextFreeIdx:int) (valIn:SecuritySubType) : int = 
   let tag = "762="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingSecuritySubType (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingSecuritySubType) : int = 
   let tag = "763="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegSecuritySubType (dest:byte []) (nextFreeIdx:int) (valIn:LegSecuritySubType) : int = 
   let tag = "764="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllowableOneSidednessPct (dest:byte []) (nextFreeIdx:int) (valIn:AllowableOneSidednessPct) : int = 
   let tag = "765="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllowableOneSidednessValue (dest:byte []) (nextFreeIdx:int) (valIn:AllowableOneSidednessValue) : int = 
   let tag = "766="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAllowableOneSidednessCurr (dest:byte []) (nextFreeIdx:int) (valIn:AllowableOneSidednessCurr) : int = 
   let tag = "767="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoTrdRegTimestamps (dest:byte []) (nextFreeIdx:int) (valIn:NoTrdRegTimestamps) : int = 
   let tag = "768="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTrdRegTimestamp (dest:byte []) (nextFreeIdx:int) (valIn:TrdRegTimestamp) : int = 
   let tag = "769="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteTrdRegTimestampOrigin (dest:byte []) (nextFreeIdx:int) (valIn:TrdRegTimestampOrigin) : int = 
   let tag = "771="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteConfirmRefID (dest:byte []) (nextFreeIdx:int) (valIn:ConfirmRefID) : int = 
   let tag = "772="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteIndividualAllocRejCode (dest:byte []) (nextFreeIdx:int) (valIn:IndividualAllocRejCode) : int = 
   let tag = "776="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlInstMsgID (dest:byte []) (nextFreeIdx:int) (valIn:SettlInstMsgID) : int = 
   let tag = "777="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoSettlInst (dest:byte []) (nextFreeIdx:int) (valIn:NoSettlInst) : int = 
   let tag = "778="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLastUpdateTime (dest:byte []) (nextFreeIdx:int) (valIn:LastUpdateTime) : int = 
   let tag = "779="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoSettlPartyIDs (dest:byte []) (nextFreeIdx:int) (valIn:NoSettlPartyIDs) : int = 
   let tag = "781="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlPartyID (dest:byte []) (nextFreeIdx:int) (valIn:SettlPartyID) : int = 
   let tag = "782="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlPartyIDSource (dest:byte []) (nextFreeIdx:int) (valIn:SettlPartyIDSource) : int = 
   let tag = "783="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlPartyRole (dest:byte []) (nextFreeIdx:int) (valIn:SettlPartyRole) : int = 
   let tag = "784="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlPartySubID (dest:byte []) (nextFreeIdx:int) (valIn:SettlPartySubID) : int = 
   let tag = "785="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlPartySubIDType (dest:byte []) (nextFreeIdx:int) (valIn:SettlPartySubIDType) : int = 
   let tag = "786="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNextExpectedMsgSeqNum (dest:byte []) (nextFreeIdx:int) (valIn:NextExpectedMsgSeqNum) : int = 
   let tag = "789="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOrdStatusReqID (dest:byte []) (nextFreeIdx:int) (valIn:OrdStatusReqID) : int = 
   let tag = "790="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSettlInstReqID (dest:byte []) (nextFreeIdx:int) (valIn:SettlInstReqID) : int = 
   let tag = "791="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteSecondaryAllocID (dest:byte []) (nextFreeIdx:int) (valIn:SecondaryAllocID) : int = 
   let tag = "793="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteAllocReportRefID (dest:byte []) (nextFreeIdx:int) (valIn:AllocReportRefID) : int = 
   let tag = "795="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteCopyMsgIndicator (dest:byte []) (nextFreeIdx:int) (valIn:CopyMsgIndicator) : int = 
   let tag = "797="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteOrderAvgPx (dest:byte []) (nextFreeIdx:int) (valIn:OrderAvgPx) : int = 
   let tag = "799="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOrderBookingQty (dest:byte []) (nextFreeIdx:int) (valIn:OrderBookingQty) : int = 
   let tag = "800="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoSettlPartySubIDs (dest:byte []) (nextFreeIdx:int) (valIn:NoSettlPartySubIDs) : int = 
   let tag = "801="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoPartySubIDs (dest:byte []) (nextFreeIdx:int) (valIn:NoPartySubIDs) : int = 
   let tag = "802="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePartySubIDType (dest:byte []) (nextFreeIdx:int) (valIn:PartySubIDType) : int = 
   let tag = "803="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoNestedPartySubIDs (dest:byte []) (nextFreeIdx:int) (valIn:NoNestedPartySubIDs) : int = 
   let tag = "804="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNestedPartySubIDType (dest:byte []) (nextFreeIdx:int) (valIn:NestedPartySubIDType) : int = 
   let tag = "805="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoNested2PartySubIDs (dest:byte []) (nextFreeIdx:int) (valIn:NoNested2PartySubIDs) : int = 
   let tag = "806="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNested2PartySubIDType (dest:byte []) (nextFreeIdx:int) (valIn:Nested2PartySubIDType) : int = 
   let tag = "807="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteUnderlyingPx (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingPx) : int = 
   let tag = "810="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePriceDelta (dest:byte []) (nextFreeIdx:int) (valIn:PriceDelta) : int = 
   let tag = "811="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteApplQueueMax (dest:byte []) (nextFreeIdx:int) (valIn:ApplQueueMax) : int = 
   let tag = "812="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteApplQueueDepth (dest:byte []) (nextFreeIdx:int) (valIn:ApplQueueDepth) : int = 
   let tag = "813="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoAltMDSource (dest:byte []) (nextFreeIdx:int) (valIn:NoAltMDSource) : int = 
   let tag = "816="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAltMDSourceID (dest:byte []) (nextFreeIdx:int) (valIn:AltMDSourceID) : int = 
   let tag = "817="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSecondaryTradeReportID (dest:byte []) (nextFreeIdx:int) (valIn:SecondaryTradeReportID) : int = 
   let tag = "818="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteTradeLinkID (dest:byte []) (nextFreeIdx:int) (valIn:TradeLinkID) : int = 
   let tag = "820="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOrderInputDevice (dest:byte []) (nextFreeIdx:int) (valIn:OrderInputDevice) : int = 
   let tag = "821="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingTradingSessionID (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingTradingSessionID) : int = 
   let tag = "822="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingTradingSessionSubID (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingTradingSessionSubID) : int = 
   let tag = "823="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTradeLegRefID (dest:byte []) (nextFreeIdx:int) (valIn:TradeLegRefID) : int = 
   let tag = "824="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteExchangeRule (dest:byte []) (nextFreeIdx:int) (valIn:ExchangeRule) : int = 
   let tag = "825="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteTrdSubType (dest:byte []) (nextFreeIdx:int) (valIn:TrdSubType) : int = 
   let tag = "829="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTransferReason (dest:byte []) (nextFreeIdx:int) (valIn:TransferReason) : int = 
   let tag = "830="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAsgnReqID (dest:byte []) (nextFreeIdx:int) (valIn:AsgnReqID) : int = 
   let tag = "831="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTotNumAssignmentReports (dest:byte []) (nextFreeIdx:int) (valIn:TotNumAssignmentReports) : int = 
   let tag = "832="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAsgnRptID (dest:byte []) (nextFreeIdx:int) (valIn:AsgnRptID) : int = 
   let tag = "833="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteThresholdAmount (dest:byte []) (nextFreeIdx:int) (valIn:ThresholdAmount) : int = 
   let tag = "834="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WritePeggedPrice (dest:byte []) (nextFreeIdx:int) (valIn:PeggedPrice) : int = 
   let tag = "839="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteDiscretionPrice (dest:byte []) (nextFreeIdx:int) (valIn:DiscretionPrice) : int = 
   let tag = "845="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteTargetStrategy (dest:byte []) (nextFreeIdx:int) (valIn:TargetStrategy) : int = 
   let tag = "847="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTargetStrategyParameters (dest:byte []) (nextFreeIdx:int) (valIn:TargetStrategyParameters) : int = 
   let tag = "848="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteParticipationRate (dest:byte []) (nextFreeIdx:int) (valIn:ParticipationRate) : int = 
   let tag = "849="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTargetStrategyPerformance (dest:byte []) (nextFreeIdx:int) (valIn:TargetStrategyPerformance) : int = 
   let tag = "850="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WritePublishTrdIndicator (dest:byte []) (nextFreeIdx:int) (valIn:PublishTrdIndicator) : int = 
   let tag = "852="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteSecondaryTrdType (dest:byte []) (nextFreeIdx:int) (valIn:SecondaryTrdType) : int = 
   let tag = "855="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteSharedCommission (dest:byte []) (nextFreeIdx:int) (valIn:SharedCommission) : int = 
   let tag = "858="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteConfirmReqID (dest:byte []) (nextFreeIdx:int) (valIn:ConfirmReqID) : int = 
   let tag = "859="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAvgParPx (dest:byte []) (nextFreeIdx:int) (valIn:AvgParPx) : int = 
   let tag = "860="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteReportedPx (dest:byte []) (nextFreeIdx:int) (valIn:ReportedPx) : int = 
   let tag = "861="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoCapacities (dest:byte []) (nextFreeIdx:int) (valIn:NoCapacities) : int = 
   let tag = "862="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteOrderCapacityQty (dest:byte []) (nextFreeIdx:int) (valIn:OrderCapacityQty) : int = 
   let tag = "863="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoEvents (dest:byte []) (nextFreeIdx:int) (valIn:NoEvents) : int = 
   let tag = "864="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteEventDate (dest:byte []) (nextFreeIdx:int) (valIn:EventDate) : int = 
   let tag = "866="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteEventPx (dest:byte []) (nextFreeIdx:int) (valIn:EventPx) : int = 
   let tag = "867="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteEventText (dest:byte []) (nextFreeIdx:int) (valIn:EventText) : int = 
   let tag = "868="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WritePctAtRisk (dest:byte []) (nextFreeIdx:int) (valIn:PctAtRisk) : int = 
   let tag = "869="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoInstrAttrib (dest:byte []) (nextFreeIdx:int) (valIn:NoInstrAttrib) : int = 
   let tag = "870="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteInstrAttribValue (dest:byte []) (nextFreeIdx:int) (valIn:InstrAttribValue) : int = 
   let tag = "872="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteDatedDate (dest:byte []) (nextFreeIdx:int) (valIn:DatedDate) : int = 
   let tag = "873="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteInterestAccrualDate (dest:byte []) (nextFreeIdx:int) (valIn:InterestAccrualDate) : int = 
   let tag = "874="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCPProgram (dest:byte []) (nextFreeIdx:int) (valIn:CPProgram) : int = 
   let tag = "875="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCPRegType (dest:byte []) (nextFreeIdx:int) (valIn:CPRegType) : int = 
   let tag = "876="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingCPProgram (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingCPProgram) : int = 
   let tag = "877="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingCPRegType (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingCPRegType) : int = 
   let tag = "878="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingQty (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingQty) : int = 
   let tag = "879="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTrdMatchID (dest:byte []) (nextFreeIdx:int) (valIn:TrdMatchID) : int = 
   let tag = "880="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteSecondaryTradeReportRefID (dest:byte []) (nextFreeIdx:int) (valIn:SecondaryTradeReportRefID) : int = 
   let tag = "881="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingDirtyPrice (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingDirtyPrice) : int = 
   let tag = "882="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingEndPrice (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingEndPrice) : int = 
   let tag = "883="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingStartValue (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingStartValue) : int = 
   let tag = "884="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingCurrentValue (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingCurrentValue) : int = 
   let tag = "885="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingEndValue (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingEndValue) : int = 
   let tag = "886="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoUnderlyingStips (dest:byte []) (nextFreeIdx:int) (valIn:NoUnderlyingStips) : int = 
   let tag = "887="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingStipType (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingStipType) : int = 
   let tag = "888="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUnderlyingStipValue (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingStipValue) : int = 
   let tag = "889="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMaturityNetMoney (dest:byte []) (nextFreeIdx:int) (valIn:MaturityNetMoney) : int = 
   let tag = "890="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteTotNoAllocs (dest:byte []) (nextFreeIdx:int) (valIn:TotNoAllocs) : int = 
   let tag = "892="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLastFragment (dest:byte []) (nextFreeIdx:int) (valIn:LastFragment) : int = 
   let tag = "893="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCollReqID (dest:byte []) (nextFreeIdx:int) (valIn:CollReqID) : int = 
   let tag = "894="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoTrades (dest:byte []) (nextFreeIdx:int) (valIn:NoTrades) : int = 
   let tag = "897="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMarginRatio (dest:byte []) (nextFreeIdx:int) (valIn:MarginRatio) : int = 
   let tag = "898="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteMarginExcess (dest:byte []) (nextFreeIdx:int) (valIn:MarginExcess) : int = 
   let tag = "899="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTotalNetValue (dest:byte []) (nextFreeIdx:int) (valIn:TotalNetValue) : int = 
   let tag = "900="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCashOutstanding (dest:byte []) (nextFreeIdx:int) (valIn:CashOutstanding) : int = 
   let tag = "901="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCollAsgnID (dest:byte []) (nextFreeIdx:int) (valIn:CollAsgnID) : int = 
   let tag = "902="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteCollRespID (dest:byte []) (nextFreeIdx:int) (valIn:CollRespID) : int = 
   let tag = "904="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteCollAsgnRefID (dest:byte []) (nextFreeIdx:int) (valIn:CollAsgnRefID) : int = 
   let tag = "907="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCollRptID (dest:byte []) (nextFreeIdx:int) (valIn:CollRptID) : int = 
   let tag = "908="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteCollInquiryID (dest:byte []) (nextFreeIdx:int) (valIn:CollInquiryID) : int = 
   let tag = "909="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteTotNumReports (dest:byte []) (nextFreeIdx:int) (valIn:TotNumReports) : int = 
   let tag = "911="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLastRptRequested (dest:byte []) (nextFreeIdx:int) (valIn:LastRptRequested) : int = 
   let tag = "912="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAgreementDesc (dest:byte []) (nextFreeIdx:int) (valIn:AgreementDesc) : int = 
   let tag = "913="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAgreementID (dest:byte []) (nextFreeIdx:int) (valIn:AgreementID) : int = 
   let tag = "914="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAgreementDate (dest:byte []) (nextFreeIdx:int) (valIn:AgreementDate) : int = 
   let tag = "915="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteStartDate (dest:byte []) (nextFreeIdx:int) (valIn:StartDate) : int = 
   let tag = "916="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteEndDate (dest:byte []) (nextFreeIdx:int) (valIn:EndDate) : int = 
   let tag = "917="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteAgreementCurrency (dest:byte []) (nextFreeIdx:int) (valIn:AgreementCurrency) : int = 
   let tag = "918="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteEndAccruedInterestAmt (dest:byte []) (nextFreeIdx:int) (valIn:EndAccruedInterestAmt) : int = 
   let tag = "920="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteStartCash (dest:byte []) (nextFreeIdx:int) (valIn:StartCash) : int = 
   let tag = "921="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteEndCash (dest:byte []) (nextFreeIdx:int) (valIn:EndCash) : int = 
   let tag = "922="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteUserRequestID (dest:byte []) (nextFreeIdx:int) (valIn:UserRequestID) : int = 
   let tag = "923="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNewPassword (dest:byte []) (nextFreeIdx:int) (valIn:NewPassword) : int = 
   let tag = "925="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteUserStatusText (dest:byte []) (nextFreeIdx:int) (valIn:UserStatusText) : int = 
   let tag = "927="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteStatusText (dest:byte []) (nextFreeIdx:int) (valIn:StatusText) : int = 
   let tag = "929="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRefCompID (dest:byte []) (nextFreeIdx:int) (valIn:RefCompID) : int = 
   let tag = "930="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteRefSubID (dest:byte []) (nextFreeIdx:int) (valIn:RefSubID) : int = 
   let tag = "931="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNetworkResponseID (dest:byte []) (nextFreeIdx:int) (valIn:NetworkResponseID) : int = 
   let tag = "932="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNetworkRequestID (dest:byte []) (nextFreeIdx:int) (valIn:NetworkRequestID) : int = 
   let tag = "933="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLastNetworkResponseID (dest:byte []) (nextFreeIdx:int) (valIn:LastNetworkResponseID) : int = 
   let tag = "934="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoCompIDs (dest:byte []) (nextFreeIdx:int) (valIn:NoCompIDs) : int = 
   let tag = "936="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteNoCollInquiryQualifier (dest:byte []) (nextFreeIdx:int) (valIn:NoCollInquiryQualifier) : int = 
   let tag = "938="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteUnderlyingStrikeCurrency (dest:byte []) (nextFreeIdx:int) (valIn:UnderlyingStrikeCurrency) : int = 
   let tag = "941="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegStrikeCurrency (dest:byte []) (nextFreeIdx:int) (valIn:LegStrikeCurrency) : int = 
   let tag = "942="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteTimeBracket (dest:byte []) (nextFreeIdx:int) (valIn:TimeBracket) : int = 
   let tag = "943="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


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


let WriteStrikeCurrency (dest:byte []) (nextFreeIdx:int) (valIn:StrikeCurrency) : int = 
   let tag = "947="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoNested3PartyIDs (dest:byte []) (nextFreeIdx:int) (valIn:NoNested3PartyIDs) : int = 
   let tag = "948="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNested3PartyID (dest:byte []) (nextFreeIdx:int) (valIn:Nested3PartyID) : int = 
   let tag = "949="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNested3PartyIDSource (dest:byte []) (nextFreeIdx:int) (valIn:Nested3PartyIDSource) : int = 
   let tag = "950="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNested3PartyRole (dest:byte []) (nextFreeIdx:int) (valIn:Nested3PartyRole) : int = 
   let tag = "951="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNoNested3PartySubIDs (dest:byte []) (nextFreeIdx:int) (valIn:NoNested3PartySubIDs) : int = 
   let tag = "952="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNested3PartySubID (dest:byte []) (nextFreeIdx:int) (valIn:Nested3PartySubID) : int = 
   let tag = "953="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteNested3PartySubIDType (dest:byte []) (nextFreeIdx:int) (valIn:Nested3PartySubIDType) : int = 
   let tag = "954="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegContractSettlMonth (dest:byte []) (nextFreeIdx:int) (valIn:LegContractSettlMonth) : int = 
   let tag = "955="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


let WriteLegInterestAccrualDate (dest:byte []) (nextFreeIdx:int) (valIn:LegInterestAccrualDate) : int = 
   let tag = "956="B
   Buffer.BlockCopy (tag, 0, dest, nextFreeIdx, tag.Length)
   let nextFreeIdx2 = nextFreeIdx + tag.Length
   let bs = ToBytes.Convert(valIn.Value)
   Buffer.BlockCopy (bs, 0, dest, nextFreeIdx2, bs.Length)
   let nextFreeIdx3 = nextFreeIdx2 + bs.Length
   dest.[nextFreeIdx3] <- 1uy // write the SOH field delimeter
   nextFreeIdx3 + 1 // +1 to include the delimeter


