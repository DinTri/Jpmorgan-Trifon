using Jpmorgan_TrifonTest.SuperSimpleStocks.Utils;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.Model
{
   
    public enum StockType
    {
        Common, Preferred
    }
    public abstract class Stock
    {
        protected Stock(string symbol, double lastDividend, double parValue)
        {
            Symbol = symbol;
            LastDividend = lastDividend;
            ParValue = parValue;
        }

        public string Symbol { get; }

        public abstract StockType StockType { get; }

        protected double LastDividend { get; }

        protected double ParValue { get; }

        public abstract double CalculateDividendYield(double price);

        public double CalculatePeRatio(double price)
        {
            return MathFormulaCalculations.PeRatio(price, CalculateDividendYield(price));
        }
        
    }
}
