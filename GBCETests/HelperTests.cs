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
    public class HelperTests
    {
        [TestMethod()]
        public void GetGeometricMeanTest()
        {
            // Arrange
            var values = new List<double>() { 10d, 20d, 30d, 40d, 50d };

            var actualMean = Helper.GetGeometricMeanUsingLog(values);
            var expectedMean = 26.0517108469735d;

            var difference = expectedMean - actualMean;

            Assert.IsTrue(difference < 0.00000000001d);
        }
    }
}