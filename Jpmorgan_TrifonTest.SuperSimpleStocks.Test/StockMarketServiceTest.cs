using System;
using Jpmorgan_TrifonTest.SuperSimpleStocks.Contracts;
using Jpmorgan_TrifonTest.SuperSimpleStocks.Services;
using Jpmorgan_TrifonTest.SuperSimpleStocks.Test.TestData;
using Moq;
using Xunit;
using Trade = Jpmorgan_TrifonTest.SuperSimpleStocks.Model.Trade;

namespace Jpmorgan_TrifonTest.SuperSimpleStocks.Test
{
    
    public class StockMarketServiceTest
    {
        private readonly StockMarketService _stockMarketService;

        
        
        public StockMarketServiceTest()
        {
            _stockMarketService = new StockMarketService(new Repositories.Trade(), DataToTest.Stocks());
        }

        [Fact]
        public void Buy_Stock_Add_Trade()
        {
            //Arrange
            var mockRepository = new Mock<ITrade>();

            mockRepository.Setup(x => x.AddTrade(It.IsAny<Trade>()));

            var tradeService = new StockMarketService(mockRepository.Object, DataToTest.Stocks());


            //Act
            tradeService.BuyStock(DataToTest.Tea.Symbol, 0.75, 2);

            //Assert
            mockRepository.Verify(x => x.AddTrade(It.IsAny<Trade>()));

        }

        [Fact]
        public void Sell_Stock_Add_Trade()
        {
            //Arrange
            var mockRepository = new Mock<ITrade>();

            mockRepository.Setup(x => x.AddTrade(It.IsAny<Trade>()));

            var tradeService = new StockMarketService(mockRepository.Object, DataToTest.Stocks());


            //Act
            tradeService.SellStock(DataToTest.Tea.Symbol, 0.75, 2);

            //Assert
            mockRepository.Verify(x => x.AddTrade(It.IsAny<Trade>()));
        }

        [Fact]
        public void Sell_Stock_If_Invalid_Stock_Throws_An_Error()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                _stockMarketService.SellStock("FantasticBeer", 0.75, 2); });
            Assert.Equal("FantasticBeer is not a tradable stock.", ex.Message);
            
        }

        [Fact]
        public void Buy_Stock_If_Invalid_Stock_Throws_An_Error()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                _stockMarketService.BuyStock("FantasticBeer", 0.75, 2); });
            Assert.Equal("FantasticBeer is not a tradable stock.", ex.Message);
            
        }

        [Fact]
        public void Calculate_Common_Dividends_For_Invalid_Stock_Throws_Exception()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                _stockMarketService.CalculateDividendYield("FantasticBeer", 5); });
            Assert.Equal("FantasticBeer is not a tradable stock.", ex.Message);
           
        }

        [Fact]
        public void Can_Calculate_Common_Dividends()
        {
            Assert.Equal(0, _stockMarketService.CalculateDividendYield(DataToTest.Tea.Symbol, 5));
        }

        [Fact]
        public void Can_Calculate_Preferred_Dividends()
        {
            Assert.Equal(40, _stockMarketService.CalculateDividendYield(DataToTest.Gin.Symbol, 5));
        }

        [Fact]
        public void Calculate_Pe_Ratio_If_Invalid_Stock_Throws_An_Error()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                _stockMarketService.CalcPeRatio("FantasticBeer", 5); });
            Assert.Equal("FantasticBeer is not a tradable stock.", ex.Message);
           
        }

        [Fact]
        public void Can_Calculate_Pe_Ratio()
        {
            Assert.Equal(0.125, _stockMarketService.CalcPeRatio(DataToTest.Gin.Symbol, 5));
        }

        [Fact]
        public void Calculate_Stock_Price_If_Invalid_Stock_Throws_An_Error()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                _stockMarketService.CalculateVolumeWeightedStockPrice("FantasticBeer"); });
            Assert.Equal("FantasticBeer is not a tradable stock.", ex.Message);
            
        }

        [Fact]
        public void Calculate_Stock_Price_If_No_Trades_For_Stock_Returns_Zero()
        {
            _stockMarketService.BuyStock(DataToTest.Tea.Symbol, 0.75, 2);
            _stockMarketService.BuyStock(DataToTest.Pop.Symbol, 0.80, 3);
            _stockMarketService.BuyStock(DataToTest.Joe.Symbol, 0.85, 4);

            Assert.Equal(0, _stockMarketService.CalculateVolumeWeightedStockPrice(DataToTest.Gin.Symbol));
        }

        [Fact]
        public void Can_Calculate_Stock_Price()
        {
            _stockMarketService.BuyStock(DataToTest.Tea.Symbol, 0.75, 2);
            _stockMarketService.BuyStock(DataToTest.Pop.Symbol, 0.80, 3);
            _stockMarketService.BuyStock(DataToTest.Joe.Symbol, 0.85, 4);
            _stockMarketService.BuyStock(DataToTest.Pop.Symbol, 0.90, 7);

            Assert.Equal(0.87, Math.Round(_stockMarketService.CalculateVolumeWeightedStockPrice(DataToTest.Pop.Symbol), 2));
        }

        [Fact]
        public void Calculate_Stock_Price_When_No_Trade_Doesnt_Throw_An_Error()
        {
            Assert.Equal(0,_stockMarketService.CalculateVolumeWeightedStockPrice(DataToTest.Pop.Symbol));
        }
    }
}
