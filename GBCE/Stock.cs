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
