using System;
using System.Collections.Generic;
using System.Linq;
using Jpmorgan_TrifonTest.SuperSimpleStocks.ErrorLog;
using Jpmorgan_TrifonTest.SuperSimpleStocks.Model;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.Utils
{
    public static class MathFormulaCalculations
    {
       
        public static double DividendYield(double lastDividend, double price)
        {
            //return  lastDividend / price;
            // try
           // {
                if (Convert.ToInt32(price) == 0)
                {
                    throw new ArgumentException("Price cannot be zero!");
                }

                var dividendYield = lastDividend / price;
            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}

            return dividendYield;

        }

        public static double FixedDividend(double fixedDividend, double parValue, double price)
        {
            double returnValue = 0;
            //try
            //{
                if (Convert.ToInt32(price) == 0)
                {
                    throw new ArgumentException("Price cannot be zero!");
                }
                returnValue = (fixedDividend * parValue) / price;
            //}
            //catch (Exception e)
            //{
            //    ErrorLogs.CreateLogFile(ErrorLogs.ErrorMessage(e));
            //}

            return returnValue;
            //return (fixedDividend * parValue) / price;

        }

        public static double PeRatio(double price, double dividend)
        {
            //return price / dividend;
            double returnValue = 0;
            //try
            //{
                if (Convert.ToInt32(price) == 0 || Convert.ToInt32(dividend) == 0)
                {
                    throw new ArgumentException("Price or Divident cannot be zero!");
                }
                returnValue = price / dividend;
            //}
            //catch (Exception e)
            //{
            //    ErrorLogs.CreateLogFile(ErrorLogs.ErrorMessage(e));
            //}

            return returnValue;
        }

        public static double GeometricMean(IList<double> values)
        {
            //double sum = 1;
            //foreach (var value in values) sum = sum * value;
            //return Math.Pow(sum, 1.0 / values.Count);
            double returnValue = 0;
            //try
            //{
                if (!values.Any())
                {
                    throw new ArgumentException("Values must be not zero");
                }

                double sum = 1;
                foreach (var value in values) sum = sum * value;
                returnValue = Math.Pow(sum, 1.0 / values.Count);
            //}
            //catch (Exception e)
            //{
            //    ErrorLogs.CreateLogFile(ErrorLogs.ErrorMessage(e));
            //}

            return returnValue;
        }

        public static double VolumeWeightedStockPrice(IList<Trade> trades)
        {
            return trades.Sum(t => t.Price * t.Quantity) / trades.Sum(t => t.Quantity);
        }
    }
}
