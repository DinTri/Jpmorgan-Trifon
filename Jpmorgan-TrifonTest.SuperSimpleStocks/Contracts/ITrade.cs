using System;
using System.Collections.Generic;
using Jpmorgan_TrifonTest.SuperSimpleStocks.Model;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.Contracts
{
    public interface ITrade
    {
        void AddTrade(Trade trade);

        IEnumerable<Trade> GetAllTrades();

        IEnumerable<Trade> GetAllTradesByStockAndDate(string stockSymbol, DateTime dateTime);
        
        IEnumerable<Trade> GetAllTradesByDate(DateTime dateTime);

        IEnumerable<Trade> GetAllTradesByStock(string stockSymbol);
    }
}
