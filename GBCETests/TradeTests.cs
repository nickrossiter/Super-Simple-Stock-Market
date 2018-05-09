using Microsoft.VisualStudio.TestTools.UnitTesting;
using GBCE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBCE.Tests
{
    [TestClass()]
    public class TradeTests
    {
        [TestMethod()]
        public void CreateBuyTrade_ValidParameters()
        {
            // Arrange
            string stockSymbol = "TEA";
            DateTime? tradeDate = DateTime.Now;
            decimal quantity = 125m;
            TradeType tradeType = TradeType.Buy;
            decimal price = 178m;


            // Act
            try
            {
                var trade = new Trade(stockSymbol, tradeDate, quantity, tradeType, price);
            }
            catch
            {
                // Assert
                Assert.Fail();
            }
        }

        
        [TestMethod()]
        public void CreateBuyTrade_InvalidStockSymbol()
        {
            // Arrange
            string stockSymbol = "";
            DateTime? tradeDate = DateTime.Now;
            decimal quantity = 125m;
            TradeType tradeType = TradeType.Buy;
            decimal price = 178m;


            // Act
            try
            {
                var trade = new Trade(stockSymbol, tradeDate, quantity, tradeType, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.InnerException.Message, Trade.StockSymbolHasNotBeenSet);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }

        [TestMethod()]
        public void CreateBuyTrade_TradeDateHasNotBeenSet()
        {
            // Arrange
            string stockSymbol = "TEA";
            DateTime? tradeDate = null;
            decimal quantity = 125m;
            TradeType tradeType = TradeType.Buy;
            decimal price = 178m;


            // Act
            try
            {
                var trade = new Trade(stockSymbol, tradeDate, quantity, tradeType, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.InnerException.Message, Trade.TradeDateHasNotBeenSet);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }

        [TestMethod()]
        public void CreateBuyTrade_TradeQuantityCannotBeZero()
        {
            // Arrange
            string stockSymbol = "TEA";
            DateTime? tradeDate = DateTime.Now;
            decimal quantity = 0m;
            TradeType tradeType = TradeType.Buy;
            decimal price = 178m;


            // Act
            try
            {
                var trade = new Trade(stockSymbol, tradeDate, quantity, tradeType, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.InnerException.Message, Trade.TradeQuantityCannotBeZero);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }

        [TestMethod()]
        public void CreateBuyTrade_TradePriceCannotBeNegative()
        {
            // Arrange
            string stockSymbol = "TEA";
            DateTime? tradeDate = DateTime.Now;
            decimal quantity = 125m;
            TradeType tradeType = TradeType.Buy;
            decimal price = -178m;


            // Act
            try
            {
                var trade = new Trade(stockSymbol, tradeDate, quantity, tradeType, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.InnerException.Message, Trade.TradePriceCannotBeNegative);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }

        [TestMethod()]
        public void CreateBuyTrade_TradePriceCannotBeZero()
        {
            // Arrange
            string stockSymbol = "TEA";
            DateTime? tradeDate = DateTime.Now;
            decimal quantity = 125m;
            TradeType tradeType = TradeType.Buy;
            decimal price = 0m;


            // Act
            try
            {
                var trade = new Trade(stockSymbol, tradeDate, quantity, tradeType, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.InnerException.Message, Trade.TradePriceCannotBeZero);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }

        [TestMethod()]
        public void CreateSellTrade_ValidParameters()
        {
            // Arrange
            string stockSymbol = "TEA";
            DateTime? tradeDate = DateTime.Now;
            decimal quantity = 125m;
            TradeType tradeType = TradeType.Sell;
            decimal price = 178m;


            // Act
            try
            {
                var trade = new Trade(stockSymbol, tradeDate, quantity, tradeType, price);
            }
            catch
            {
                // Assert
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CreateSellTrade_InvalidStockSymbol()
        {
            // Arrange
            string stockSymbol = "";
            DateTime? tradeDate = DateTime.Now;
            decimal quantity = 125m;
            TradeType tradeType = TradeType.Sell;
            decimal price = 178m;


            // Act
            try
            {
                var trade = new Trade(stockSymbol, tradeDate, quantity, tradeType, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.InnerException.Message, Trade.StockSymbolHasNotBeenSet);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }

        [TestMethod()]
        public void CreateSellTrade_TradeDateHasNotBeenSet()
        {
            // Arrange
            string stockSymbol = "TEA";
            DateTime? tradeDate = null;
            decimal quantity = 125m;
            TradeType tradeType = TradeType.Sell;
            decimal price = 178m;


            // Act
            try
            {
                var trade = new Trade(stockSymbol, tradeDate, quantity, tradeType, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.InnerException.Message, Trade.TradeDateHasNotBeenSet);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }

        [TestMethod()]
        public void CreateSellTrade_TradeQuantityCannotBeZero()
        {
            // Arrange
            string stockSymbol = "TEA";
            DateTime? tradeDate = DateTime.Now;
            decimal quantity = 0m;
            TradeType tradeType = TradeType.Sell;
            decimal price = 178m;


            // Act
            try
            {
                var trade = new Trade(stockSymbol, tradeDate, quantity, tradeType, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.InnerException.Message, Trade.TradeQuantityCannotBeZero);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }

        [TestMethod()]
        public void CreateSellTrade_TradePriceCannotBeNegative()
        {
            // Arrange
            string stockSymbol = "TEA";
            DateTime? tradeDate = DateTime.Now;
            decimal quantity = 125m;
            TradeType tradeType = TradeType.Sell;
            decimal price = -178m;


            // Act
            try
            {
                var trade = new Trade(stockSymbol, tradeDate, quantity, tradeType, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.InnerException.Message, Trade.TradePriceCannotBeNegative);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }

        [TestMethod()]
        public void CreateSellTrade_TradePriceCannotBeZero()
        {
            // Arrange
            string stockSymbol = "TEA";
            DateTime? tradeDate = DateTime.Now;
            decimal quantity = 125m;
            TradeType tradeType = TradeType.Sell;
            decimal price = 0m;


            // Act
            try
            {
                var trade = new Trade(stockSymbol, tradeDate, quantity, tradeType, price);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.InnerException.Message, Trade.TradePriceCannotBeZero);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }

    }
}