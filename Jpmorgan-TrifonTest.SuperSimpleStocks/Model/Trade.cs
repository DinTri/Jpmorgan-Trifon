using System;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.Model
{
    public enum TradeIndicators
    {
        Buy, Sell
    }

    public class Trade
    {
        public readonly DateTime Timestamp;

        public readonly string StockSymbol;

        private readonly TradeIndicators _tradeTypes;

        public readonly int Quantity;

        public readonly double Price;

        public Trade()
        {
        }

        public Trade(Stock stock, TradeIndicators tradeType, double price, int quantity)
            : this(stock, tradeType, price, quantity, DateTime.UtcNow)
        {
        }

        public Trade(Stock stock, TradeIndicators tradeType, double price, int quantity, DateTime utcNow)
        {
            StockSymbol = stock.Symbol;
            _tradeTypes = tradeType;
            Price = price;
            Quantity = quantity;
            Timestamp = utcNow;
        }

        public override string ToString()
        {
            return $"{Timestamp} TRADE-TYPE:{_tradeTypes} STOCK-TYPE: {StockSymbol} QTY: {Quantity} PRICE: {Price}";
        }
    }
}
