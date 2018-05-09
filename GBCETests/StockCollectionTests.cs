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
    public class StockCollectionTests
    {
        [TestMethod()]
        public void AddStock_WhenStockDoesntExists()
        {
            // Arrange
            var stockCollection = new StockCollection();
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0;
            stock.FixedDividend = 2;
            stock.ParValue = 100;

            // Act
            try
            {
                stockCollection.AddStock(stock);
            }
            catch
            {
                // Assert
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void AddStock_WhenStockExists_ShouldThrowException()
        {
            // Arrange
            var stockCollection = new StockCollection();
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0;
            stock.FixedDividend = 2;
            stock.ParValue = 100;

            try
            {
                // Act
                stockCollection.AddStock(stock);
                stockCollection.AddStock(stock);
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, StockCollection.StockAlreadyExists);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }

        [TestMethod()]
        public void CheckStockExists_WhenStockExists()
        {
            // Arrange
            var stockCollection = new StockCollection();
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0;
            stock.FixedDividend = 2;
            stock.ParValue = 100;

            //Act
            stockCollection.AddStock(stock);

            // Assert
            Assert.IsTrue(stockCollection.StockExists("TEA"));

        }

        [TestMethod()]
        public void CheckStockExists_WhenStockDoesntExists()
        {
            // Arrange
            var stockCollection = new StockCollection();
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0;
            stock.FixedDividend = 2;
            stock.ParValue = 100;

            //Act
            stockCollection.AddStock(stock);

            // Assert
            Assert.IsFalse(stockCollection.StockExists("POP"));

        }



        [TestMethod()]
        public void GetStock_WhenStockExists()
        {
            // Arrange
            var stockCollection = new StockCollection();
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0;
            stock.FixedDividend = 2;
            stock.ParValue = 100;

            try
            {
                //Act
                stockCollection.AddStock(stock);
                stockCollection.GetStock("TEA");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail();
            }
            
        }

        [TestMethod()]
        public void GetStock_WhenStockDoesNotExists_ThrowsException()
        {
            // Arrange
            var stockCollection = new StockCollection();
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0;
            stock.FixedDividend = 2;
            stock.ParValue = 100;

            try
            {
                // Act
                stockCollection.AddStock(stock);
                stockCollection.GetStock("POP");
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, StockCollection.StockNotFound);
                return;
            }

            Assert.Fail("Expected Exception not thrown");
        }

        [TestMethod()]
        public void RemoveStock_WhenStockExists()
        {
            // Arrange
            var stockCollection = new StockCollection();
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0;
            stock.FixedDividend = 2;
            stock.ParValue = 100;

            try
            {
                // Act
                stockCollection.AddStock(stock);
                stockCollection.RemoveStock("TEA");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void RemoveStock_WhenStockDoesNotExists_ThrowsException()
        {
            // Arrange
            var stockCollection = new StockCollection();
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0;
            stock.FixedDividend = 2;
            stock.ParValue = 100;

            try
            {
                // Act
                stockCollection.AddStock(stock);
                stockCollection.RemoveStock("POP");
            }
            catch (Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, StockCollection.StockNotFound);
                return;
            }

            Assert.Fail("Expected Exception not thrown");
        }

        [TestMethod()]
        public void UpdateStock_WhenStockExists()
        {
            // Arrange
            var stockCollection = new StockCollection();
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0;
            stock.FixedDividend = 2;
            stock.ParValue = 100;

            var stockUpdate = new Stock();
            stockUpdate.StockSymbol = "TEA";
            stockUpdate.StockType = GBCEStockType.Common;
            stockUpdate.LastDividend = 10;
            stockUpdate.FixedDividend = null;
            stockUpdate.ParValue = 100;

            // Act
            stockCollection.AddStock(stock);
            stockCollection.UpdateStock(stockUpdate);
            var updatedStock = stockCollection.GetStock(stock.StockSymbol);

            // Assert
            Assert.AreEqual(stockUpdate.StockSymbol, updatedStock.StockSymbol);
            Assert.AreEqual(stockUpdate.StockType, updatedStock.StockType);
            Assert.AreEqual(stockUpdate.LastDividend, updatedStock.LastDividend);
            Assert.AreEqual(stockUpdate.FixedDividend, updatedStock.FixedDividend);
            Assert.AreEqual(stockUpdate.ParValue, updatedStock.ParValue);

        }

        [TestMethod()]
        public void UpdateStock_WhenStockDoesNotExists_ThrowsException()
        {
            // Arrange
            var stockCollection = new StockCollection();
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0;
            stock.FixedDividend = 2;
            stock.ParValue = 100;

            var stockUpdate = new Stock();
            stockUpdate.StockSymbol = "POP";
            stockUpdate.StockType = GBCEStockType.Common;
            stockUpdate.LastDividend = 10;
            stockUpdate.FixedDividend = null;
            stockUpdate.ParValue = 100;

            try
            {
                // Act
                stockCollection.AddStock(stock);
                stockCollection.UpdateStock(stockUpdate);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, StockCollection.StockNotFound);
                return;
            }

            Assert.Fail("Expected Exception not thrown");
        }
    }
}