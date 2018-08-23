using System;
using System.Collections.Generic;
using System.Linq;
using Jpmorgan_TrifonTest.SuperSimpleStocks.Contracts;
using Jpmorgan_TrifonTest.SuperSimpleStocks.Model;
using Jpmorgan_TrifonTest.SuperSimpleStocks.Utils;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.Services
{
    public class StockMarketService
    {
        private readonly Dictionary<string, Stock> _tradeablesStocks;

        private readonly ITrade _trade;

        public StockMarketService(ITrade trade, Dictionary<string, Stock> tradeableStocks)
        {
            _trade = trade;
            _tradeablesStocks = tradeableStocks;
        }
        
        public double CalculateSharedIndex()
        {
           var stockPrices = _tradeablesStocks.Select(s => CalculateVolumeWeightedStockPrice(s.Key)).ToList();

            return MathFormulaCalculations.GeometricMean(stockPrices);
        }

        public double CalculateDividendYield(string stockSymbol, double price)
        {
            return DoCalculate(stockSymbol, stock => stock.CalculateDividendYield(price));
        }

        public double CalcPeRatio(string stockSymbol, double price)
        {
            return DoCalculate(stockSymbol, stock => stock.CalculatePeRatio(price));
        }
        public double CalculateVolumeWeightedStockPrice(string stockSymbol, int timeFilter = 5) => DoCalculate(
                stockSymbol,
                stock =>
                {
                    var fromDateTime = DateTime.UtcNow.Subtract(new TimeSpan(0, timeFilter, 0));
                    var stockTrades = _trade.GetAllTradesByStockAndDate(stock.Symbol, fromDateTime).ToList();

                    return stockTrades.Any()
                        ? MathFormulaCalculations.VolumeWeightedStockPrice(stockTrades)
                        : 0;
                });

        private double DoCalculate(string stockSymbol, Func<Stock, double> calculationFunc)
        {
            var stock = GetStock(stockSymbol);
            if (stock == null)
            {
                throw new ArgumentException($"{stockSymbol} is not a tradable stock.");
            }

            return calculationFunc(_tradeablesStocks[stockSymbol]);
        }

        private Stock GetStock(string stockSymbol)
        {
            return _tradeablesStocks.ContainsKey(stockSymbol) 
                ? _tradeablesStocks[stockSymbol] 
                : null;
        }

        private void DoTrade(string stockSymbol, double price, int quantity, TradeIndicators tradeType)
        {
            var stock = GetStock(stockSymbol);
            if (stock == null)
            {
                throw new ArgumentException($"{stockSymbol} is not a tradable stock.");
            }
            
            var trade = new Trade(stock, tradeType, price, quantity);
            _trade.AddTrade(trade);
        }

        public void BuyStock(string stockSymbol, double price, int quantity)
        {
            DoTrade(stockSymbol, price, quantity, TradeIndicators.Buy);
        }

        public void SellStock(string stockSymbol, double price, int quantity)
        {
            DoTrade(stockSymbol, price, quantity, TradeIndicators.Sell);
        }

    }
}
