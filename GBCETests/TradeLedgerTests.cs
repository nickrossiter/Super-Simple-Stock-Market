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
    public class TradeLedgerTests
    {
        [TestMethod()]
        public void BuyTest_WhenStockExists()
        {
            // Arrange
            var stocklist = new StockCollection();
            stocklist.AddStock(GetNewStock()); // TEA stock
            var tradeLedger = new TradeLedger(stocklist);

            try
            {
                // Act
                tradeLedger.Buy("TEA", DateTime.Now, 1000, 50);
            }
            catch (Exception ex)
            {
                // Assert

                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void BuyTest_WhenStockDoesntExists()
        {
            // Arrange
            var stocklist = new StockCollection();
            stocklist.AddStock(GetNewStock()); // TEA stock
            var tradeLedger = new TradeLedger(stocklist);

            try
            {
                // Act
                tradeLedger.Buy("POP", DateTime.Now, 1000, 50);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.InnerException.Message, TradeLedger.StockDoesNotExistInStockList);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }


        [TestMethod()]
        public void SellTest_WhenStockExists()
        {
            // Arrange
            var stocklist = new StockCollection();
            stocklist.AddStock(GetNewStock()); // TEA stock
            var tradeLedger = new TradeLedger(stocklist);

            try
            {
                // Act
                tradeLedger.Sell("TEA", DateTime.Now, 1000, 50);
            }
            catch (Exception ex)
            {
                // Assert

                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void SellTest_WhenStockDoesntExists()
        {
            // Arrange
            var stocklist = new StockCollection();
            stocklist.AddStock(GetNewStock()); // TEA stock
            var tradeLedger = new TradeLedger(stocklist);

            try
            {
                // Act
                tradeLedger.Sell("POP", DateTime.Now, 1000, 50);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.InnerException.Message, TradeLedger.StockDoesNotExistInStockList);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }


        private Stock GetNewStock()
        {
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0;
            stock.FixedDividend = null;
            stock.ParValue = 100;
            return stock;
        }
    }
}