using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBCE
{
    public enum GBCEStockType
    {
        Common,
        Preferred
    }

    public class Stock
    {
        public string StockSymbol { get; set; }
        public GBCEStockType StockType { get; set; }
        public decimal LastDividend { get; set; }
        public decimal? FixedDividend { get; set; }
        public decimal ParValue { get; set; }

        public const string LastDividendIsZero = "Last Dividend is zero";
        public const string FixedDividendHasNoValue = "Fixed Dividend has no value";

        /// <summary>
        /// Calculates the Dividend Yield of the stock for the supplied price
        /// If the stock is of type Common and the LastDividend value is zero, an ArgumentOutOfRangeException exception is thrown.
        /// If the stock is of type Preferred and the FixedDividend does not have a value, an ArgumentOutOfRangeException exception is thrown
        /// </summary>
        /// <param name="price"></param>
        /// <returns>the Dividen Yield as a decimal type</returns>
        public decimal CalculateDividendYieldForPrice(decimal price)
        {
            var dividendYield = 0m;
            if (StockType == GBCEStockType.Common)
            {
                if (LastDividend == 0)
                {
                    throw new ArgumentOutOfRangeException("LastDividend", LastDividend, LastDividendIsZero);
                }
                dividendYield = LastDividend / price;
            }
            if (StockType == GBCEStockType.Preferred)
            {
                if (FixedDividend.HasValue)
                {
                    dividendYield = FixedDividend.Value / 100 * ParValue / price;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("FixedDividend", FixedDividend, FixedDividendHasNoValue);
                }
            }
            return dividendYield;

        }

        /// <summary>
        /// Calculates the P/E ratio of a stock for a given price using the LastDividend amount for both Common and Preferred stock type (is this correct?)
        /// Throws an ArgumentOutOfRangeException if the LastDividend amount is zero 
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public decimal CalculatePERatioForPrice(decimal price)
        {
            if (LastDividend == 0)
            {
                throw new ArgumentOutOfRangeException("LastDividend", LastDividend, LastDividendIsZero);
            }
            var peRatio = price / LastDividend;

            return peRatio;

        }
    }
}
