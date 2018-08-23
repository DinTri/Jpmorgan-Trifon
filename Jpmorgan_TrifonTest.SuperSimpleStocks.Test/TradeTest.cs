using System;
using System.Collections.Generic;
using System.Linq;
using Jpmorgan_TrifonTest.SuperSimpleStocks.Model;
using Jpmorgan_TrifonTest.SuperSimpleStocks.Test.TestData;
using Xunit;
using Trade = Jpmorgan_TrifonTest.SuperSimpleStocks.Repositories.Trade;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.Test
{
    
    public class TradeTest
    {
        private readonly Trade _trades;

       private readonly Dictionary<string, Stock> _stockToTrade;

        
        public TradeTest()
        {
            _trades = new Trade();
            _stockToTrade = DataToTest.Stocks();
        }

        [Fact]
        public void Can_Add_Single_Trade()
        {
            var trade = new Model.Trade(DataToTest.Pop, TradeIndicators.Buy, 50, 1);
            
              Assert.Empty(_trades.GetAllTrades());
            _trades.AddTrade(trade);
            Assert.Single(_trades.GetAllTrades());
        }
        
        [Fact]
        public void Can_Return_All_Trades()
        {
           Assert.Empty(_trades.GetAllTrades());

            foreach (var trade in DataToTest.Stocks().Select(stock => new Model.Trade(stock.Value, TradeIndicators.Buy, 50, 1)))
            {
                _trades.AddTrade(trade);
            }

            Assert.Equal(_stockToTrade.Count, _trades.GetAllTrades().Count());
        }

        [Fact]
        public void Can_Return_All_Trades_For_Given_Time()
        {
            var startDateTime = DateTime.UtcNow;

            //Trade should be empty
            Assert.Empty(_trades.GetAllTrades());

            var oldTrade = new Model.Trade(DataToTest.Tea, TradeIndicators.Buy, 5, 2, DateTime.MinValue);
            _trades.AddTrade(oldTrade);

            var newTrade = new Model.Trade(DataToTest.Pop, TradeIndicators.Buy, 10, 5, DateTime.UtcNow);
            _trades.AddTrade(newTrade);

            Assert.Equal(2, _trades.GetAllTrades().Count());
            
            Assert.Single(_trades.GetAllTradesByDate(startDateTime));

            Assert.Equal(DataToTest.Pop.Symbol, _trades.GetAllTradesByDate(startDateTime).First().StockSymbol);
            
            Assert.Empty(_trades.GetAllTradesByStockAndDate(DataToTest.Tea.Symbol, startDateTime));
            
            Assert.Single(_trades.GetAllTradesByStockAndDate(DataToTest.Pop.Symbol, startDateTime));
        }
    }
}
