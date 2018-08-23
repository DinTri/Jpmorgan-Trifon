using System;
using System.Collections.Generic;
using System.Linq;
using Jpmorgan_TrifonTest.SuperSimpleStocks.Contracts;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.Repositories
{
   public class Trade : ITrade
   {
       private readonly List<Model.Trade> _trades;

       public Trade(List<Model.Trade> trades)
       {
           _trades = trades;
       }

       public Trade()
       {
           _trades = new List<Model.Trade>();
       }

        public void AddTrade(Model.Trade trade) => _trades.Add(trade);

        public IEnumerable<Model.Trade> GetAllTrades()
        {
            return _trades;
        }

        public IEnumerable<Model.Trade> GetAllTradesByStockAndDate(string stockSymbol, DateTime dateTime)
        {
            return _trades.Where(t => t.StockSymbol == stockSymbol && t.Timestamp >= dateTime);
        }

        public IEnumerable<Model.Trade> GetAllTradesByDate(DateTime dateTime)
        {
            return _trades.Where(t => t.Timestamp >= dateTime);
        }

        public IEnumerable<Model.Trade> GetAllTradesByStock(string stockSymbol)
        {
           return  _trades.Where(t => t.StockSymbol == stockSymbol);
        }
    }
}
