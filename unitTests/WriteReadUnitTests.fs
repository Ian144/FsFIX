module WriteReadUnitTests

open Xunit
open Swensen.Unquote

open Fix44.Fields
open Fix44.CompoundItems
open Fix44.CompoundItemReadFuncs
open Fix44.CompoundItemWriteFuncs
open Fix44.Messages
open Fix44.MsgReadFuncs
open Fix44.MsgWriteFuncs




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
    let posR, xOut = ReadMassQuoteNoQuoteEntriesGrp 0 bs
    posW =! posR
    xIn =! xOut



 


[<Fact>]
let MarketDataIncrementalRefreshNoMDEntriesGrp () =
    let bs = Array.zeroCreate<byte> 1024    
    let tm = FIXDateTime.MakeUTCTimeOnly.Make (13, 59, 25, 377)
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
    let posR, xOut = ReadMarketDataIncrementalRefreshNoMDEntriesGrp 0 bs
    posW =! posR
    xIn =! xOut