using Jpmorgan_TrifonTest.SuperSimpleStocks.Utils;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.Model
{
    public class PreferredStock : Stock
    {
        private readonly double _fixedDividend;
        public PreferredStock(string symbol, double lastDividend, double parValue, double fixedDividend) : base(symbol, lastDividend, parValue)
        {
            _fixedDividend = fixedDividend;
        }

        public override StockType StockType => StockType.Preferred;

        public override double CalculateDividendYield(double price)
        {
            return MathFormulaCalculations.FixedDividend(_fixedDividend, ParValue, price);
        }
    }
}
