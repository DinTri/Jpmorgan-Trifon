using Jpmorgan_TrifonTest.SuperSimpleStocks.Utils;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.Model
{
    public class CommonStock : Stock
    {
        public CommonStock(string symbol, double lastDividend, double parValue) : base(symbol, lastDividend, parValue)
        {
        }

        public override StockType StockType => StockType.Common;

        public override double CalculateDividendYield(double price)
        {
            return MathFormulaCalculations.DividendYield(LastDividend,price);
        }
    }
}
