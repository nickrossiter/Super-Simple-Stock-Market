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
    public class StockTests
    {
        [TestMethod()]
        public void DividendCalculationForCommonStock_WithValidDividend_GivesCorrectValue()
        {
            // Arrange 
            var stock = new Stock();
            stock.StockSymbol = "POP";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 8m;
            stock.FixedDividend = null;
            stock.ParValue = 100m;

            var price = 80m;
            var expectedDividendYield = 0.1m;

            // Act
            var actualDividendYield = stock.CalculateDividendYieldForPrice(price);

            // Assert
            Assert.AreEqual(expectedDividendYield, actualDividendYield);
        }

        [TestMethod()]
        public void DividendCalculationForPreferredStock_WithValidFixedDividend_GivesCorrectValue()
        {
            // Arrange 
            var stock = new Stock();
            stock.StockSymbol = "GIN";
            stock.StockType = GBCEStockType.Preferred;
            stock.LastDividend = 8m;
            stock.FixedDividend = 2m;
            stock.ParValue = 100m;

            var price = 20m;
            var expectedDividendYield = 0.1m;

            // Act
            var actualDividendYield = stock.CalculateDividendYieldForPrice(price);

            // Assert
            Assert.AreEqual(expectedDividendYield, actualDividendYield);
        }

        [TestMethod()]
        public void DividendCalculationForCommonStock_WithInvalidDividend_ShouldThrowArgumentOutOfRange()
        {
            // Arrange 
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0m;
            stock.FixedDividend = null;
            stock.ParValue = 100m;

            var price = 80m;

            // Act
            try
            {
                var expectedDividendYield = stock.CalculateDividendYieldForPrice(price);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, Stock.LastDividendIsZero);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }

        [TestMethod()]
        public void DividendCalculationForPreferredStock_WithInvalidFixedDividend_ShouldThrowArgumentOutOfRange()
        {
            // Arrange 
            var stock = new Stock();
            stock.StockSymbol = "GIN";
            stock.StockType = GBCEStockType.Preferred;
            stock.LastDividend = 8m;
            stock.FixedDividend = null;
            stock.ParValue = 100m;

            var price = 80m;

            // Act
            try
            {
                var expectedDividendYield = stock.CalculateDividendYieldForPrice(price);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, Stock.FixedDividendHasNoValue);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }

        [TestMethod()]
        public void PERatioCalculationForCommonStock_WithValidDividend_GivesCorrectValue()
        {
            // Arrange 
            var stock = new Stock();
            stock.StockSymbol = "POP";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 8m;
            stock.FixedDividend = null;
            stock.ParValue = 100m;

            var price = 80m;
            var expectedPERatio = 10m;

            // Act
            var actualPERatio = stock.CalculatePERatioForPrice(price);

            // Assert
            Assert.AreEqual(expectedPERatio, actualPERatio);
        }

        [TestMethod()]
        public void PERatioCalculationForCommonStock_WithInvalidDividend_ShouldThrowArgumentOutOfRange()
        {
            // Arrange 
            var stock = new Stock();
            stock.StockSymbol = "TEA";
            stock.StockType = GBCEStockType.Common;
            stock.LastDividend = 0m;
            stock.FixedDividend = null;
            stock.ParValue = 100m;

            var price = 80m;

            // Act
            try
            {
                var expectedDividendYield = stock.CalculatePERatioForPrice(price);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, Stock.LastDividendIsZero);
                return;
            }
            Assert.Fail("Expected exception was not thrown");
        }
    }
}