using Jpmorgan_TrifonTest.SuperSimpleStocks.Model;
using System.Collections.Generic;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.Test.TestData
{
    public class DataToTest
    {
        public static Stock Tea => new CommonStock("TEA", 0, 100);

        public static Stock Pop => new CommonStock("POP", 8, 100);

        public static Stock Ale => new CommonStock("ALE", 23, 60);

        public static Stock Gin => new PreferredStock("GIN", 8, 100, 2);

        public static Stock Joe => new CommonStock("JOE", 13, 250);

        public static Dictionary<string, Stock> Stocks()
        {
            return new Dictionary<string, Stock>
            {
                { Tea.Symbol, Tea },
                { Pop.Symbol, Pop },
                { Ale.Symbol, Ale },
                { Gin.Symbol, Gin },
                { Joe.Symbol, Joe },
            };
        }
    }
}
