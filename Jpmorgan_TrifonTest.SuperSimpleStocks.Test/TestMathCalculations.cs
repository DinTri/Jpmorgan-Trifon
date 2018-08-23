using System;
using System.Collections.Generic;
using Jpmorgan_TrifonTest.SuperSimpleStocks.Model;
using Jpmorgan_TrifonTest.SuperSimpleStocks.Utils;
using Xunit;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.Test
{
    public class TestMathCalculations
    {
        [Fact]
        public void Last_Dividend_Yield_Throws_When_Price_Is_Zero()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => { MathFormulaCalculations.DividendYield(5, 0); });
            Assert.Equal("Price cannot be zero!", ex.Message);
        }

        [Fact]
        public void Last_Dividend_Yield_Throws_When_Price_Is_Zero_And_Double()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                MathFormulaCalculations.DividendYield(5, 0.0);
            });
            Assert.Equal("Price cannot be zero!", ex.Message);
        }

        [Fact]
        public void Last_Dividend_Yield_Returns_Double_Result_When_Params_Are_Valid()
        {
            Assert.Equal(10, MathFormulaCalculations.DividendYield(10, 1));
            Assert.Equal(5, MathFormulaCalculations.DividendYield(10, 2));
            Assert.Equal(0, MathFormulaCalculations.DividendYield(0, -1));
        }

        [Fact]
        public void Fixed_Dividend_Yield_Throws_When_Price_Is_Zero()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => { MathFormulaCalculations.DividendYield(10, 0); });
            Assert.Equal("Price cannot be zero!", ex.Message);
        }

        [Fact]
        public void Fixed_Dividend_Yield_Throws_When_Price_Is_Zero_And_Double()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                MathFormulaCalculations.FixedDividend(5, 2, 0.0);
            });
            Assert.Equal("Price cannot be zero!", ex.Message);
        }

        [Fact]
        public void Fixed_Dividend_Yield__Returns_Double_Result_When_Params_Are_Valid()
        {
            Assert.Equal(0.0, MathFormulaCalculations.FixedDividend(5, 0, 1));
            Assert.Equal(5.0, MathFormulaCalculations.FixedDividend(5, 2, 2));
            Assert.Equal(5, MathFormulaCalculations.FixedDividend(10, 1, 2));
        }

        [Fact]
        public void Pe_Ratio_Throws_Exception_When_Dividend_Is_Zero()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                MathFormulaCalculations.PeRatio(5, 0);

            });
            Assert.Equal("Price or Divident cannot be zero!", ex.Message);
        }

        [Fact]
        public void Pe_Ratio_Throws_Exception_When_Dividend_Is_Zero_And_Double()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => 
                { MathFormulaCalculations.PeRatio(10, 0.0); });
            Assert.Equal("Price or Divident cannot be zero!", ex.Message);
        }

        [Fact]
        public void Pe_Ratio_Returns_Result_When_Params_Are_Valid()
        {
            //Result should be 10/1 = 10
            Assert.Equal(10, MathFormulaCalculations.PeRatio(10, 1));
            //Result should be 10/2 = 5
            Assert.Equal(5, MathFormulaCalculations.PeRatio(10, 2));
        }

        [Fact]
        public void Volume_Weighted_Stock_Price_Single_Trade_Sum_Is_Correct()
        {
            const double manualCalculation = (5.0 * 1.0) / 1.0;

            var trades = new List<Trade>
            {
                new Trade(new CommonStock("NewYork", 5, 5), TradeIndicators.Buy, 5, 1)
            };

            Assert.Equal(manualCalculation, MathFormulaCalculations.VolumeWeightedStockPrice(trades));
        }

        [Fact]
        public void Volume_Weighted_Stock_Price_Two_Trades_Sum_Is_Correct()
        {
            const double manualCalculation = ((5.0 * 1.0) + (7.0 * 2.0)) / (1.0 + 2.0);

            var trades = new List<Trade>
            {
                new Trade(new CommonStock("NewYork1", 5, 5), TradeIndicators.Buy, 5, 1),
                new Trade(new CommonStock("NewYork2", 10, 5), TradeIndicators.Buy, 7, 2)
            };

            Assert.Equal(manualCalculation, MathFormulaCalculations.VolumeWeightedStockPrice(trades));
        }

        [Fact]
        public void Geometric_Mean_Of_List_With_One_Value()
        {
            var values = new List<double> { 2.0 };

            Assert.Equal(2, MathFormulaCalculations.GeometricMean(values));
        }

        [Fact]
        public void Geometric_Mean_Of_Empty_List_Throws_Exception()
        {
            var values = new List<double>();
            ArgumentException ex = Assert.Throws<ArgumentException>(testCode: () =>
            {
                MathFormulaCalculations.GeometricMean(values: values); });
            Assert.Equal(expected: "Values must be not zero", actual: ex.Message);
        }

        [Fact]
        public void Geometric_Mean_Of_List_With_Two_Values()
        {
            var values = new List<double> { 2.0, 4.5 };

            Assert.Equal(3, MathFormulaCalculations.GeometricMean(values));
        }

        [Fact]
        public void Geometric_Mean_Of_List_With_Three_Values()
        {
            var values = new List<double> { 2.0, 4.0, 6.0 };

            Assert.Equal(3.63, Math.Round(MathFormulaCalculations.GeometricMean(values), 2));
        }
    }
}
