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
    public class ExchangeTests
    {
        [TestMethod]
        public void VolumeWeightedStockPriceCheck()
        {
            // Arrange
            var exchange = new Exchange();
            PopulateStocks(exchange);
            AddTrades(exchange);

            // Act
            var volumeWeightedStockPrice = exchange.Trades.GetVolumeWeightedStockPrice("POP");

            // expectedVolumeWeightedStockPrice for 'POP' trades within last 5 minutes calculated as follows

            var expectedVolumeWeightedStockPrice = ((1000m * 75m) + (500m * 78m) + (2500m * 74m) + (500m * 77m) + (500m * 79m) + (5000m * 81m)) / (1000m + 500m + 2500m + 500m + 500m + 5000m);

            // Assert
            Assert.AreEqual(expectedVolumeWeightedStockPrice, volumeWeightedStockPrice);
        }

        [TestMethod]
        public void VolumeWeightedStockPriceCheck_NoStockSymbol_ExceptionExpected()
        {
            // Arrange
            var exchange = new Exchange();
            PopulateStocks(exchange);
            AddTrades(exchange);

            try
            {
                // Act
                var volumeWeightedStockPrice = exchange.Trades.GetVolumeWeightedStockPrice("");
            }
            catch(Exception ex)
            {
                // Assert
                StringAssert.Contains(ex.InnerException.Message, TradeLedger.StockSymbolHasNotBeenProvided);
                return;
            }

            Assert.Fail("Expected exception was not thrown");
        }

        [TestMethod]
        public void VolumeWeightedStockPriceCheck_NoStockExistsForStockSymbol_ExceptionExpected()
        {
            // Arrange
            var exchange = new Exchange();
            PopulateStocks(exchange);
            AddTrades(exchange);

            try
            {
                // Act
                var volumeWeightedStockPrice = exchange.Trades.GetVolumeWeightedStockPrice("J2O");
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
        public void CalculateAllShareIndex()
        {
            // Arrange
            var exchange = new Exchange();
            PopulateStocks(exchange);
            AddTrades(exchange);

            // expectedVolumeWeightedStockPrice for POP trades in last five minutes is 78.2
            // expectedVolumeWeightedStockPrice for ALE trades in last five minutes is 165.11
            // Geometric mean is square root of 165.11*78.2 = 113.629230394296

            var expectedAllShareIndex = Math.Sqrt(78.2d * 165.11d);

            // Act
            var allShareIndex = exchange.CalculateAllShareIndex();
            var difference = expectedAllShareIndex - allShareIndex;

            // Assert
            Assert.IsTrue(difference < 0.0000000000001);

        }

        

        private void PopulateStocks(Exchange exchange)
        {
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0;
            stock.FixedDividend = null;
            stock.ParValue = 100;

            exchange.Stocks.AddStock(stock);

            stock = new Stock();
            stock.StockSymbol = "POP";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 8;
            stock.FixedDividend = null;
            stock.ParValue = 100;

            exchange.Stocks.AddStock(stock);

            stock = new Stock();
            stock.StockSymbol = "ALE";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 23;
            stock.FixedDividend = null;
            stock.ParValue = 60;

            exchange.Stocks.AddStock(stock);

            stock = new Stock();
            stock.StockSymbol = "GIN";
            stock.StockType = GBCEStockType.Preferred;
            stock.LastDividend = 8;
            stock.FixedDividend = 2;
            stock.ParValue = 100;

            exchange.Stocks.AddStock(stock);

            stock = new Stock();
            stock.StockSymbol = "JOE";
            stock.StockType = GBCEStockType.Preferred;
            stock.LastDividend = 13;
            stock.FixedDividend = null;
            stock.ParValue = 250;

            exchange.Stocks.AddStock(stock);
        }

        private void AddTrades(Exchange exchange)
        {
            var currentDateTime = DateTime.Now;
            exchange.Trades.Buy("POP", currentDateTime, 1000, 75);
            exchange.Trades.Buy("POP", currentDateTime, 500, 78);
            exchange.Trades.Buy("POP", currentDateTime, 2500, 74);
            exchange.Trades.Buy("POP", currentDateTime, 500, 77);
            exchange.Trades.Sell("POP", currentDateTime, 500, 79);
            exchange.Trades.Sell("POP", currentDateTime, 5000, 81);
            exchange.Trades.Sell("POP", currentDateTime.AddMinutes(-6), 6000, 73); // not in last five minutes
            exchange.Trades.Sell("ALE", currentDateTime, 5000, 165);
            exchange.Trades.Sell("ALE", currentDateTime, 2000, 164);
            exchange.Trades.Sell("ALE", currentDateTime, 1000, 163);
            exchange.Trades.Sell("ALE", currentDateTime, 900, 167);
            exchange.Trades.Sell("ALE", currentDateTime, 1100, 168);
            exchange.Trades.Sell("ALE", currentDateTime.AddMinutes(-6), 2500, 164); // not in last 5 minutes
        }
    }
}