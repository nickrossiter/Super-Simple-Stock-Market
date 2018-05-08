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
        public decimal FixedDividend { get; set; }
        public decimal ParValue { get; set; }

        public decimal CalculateDividendYieldForPrice(decimal price)
        {
            try
            {
                var dividendYield = 0m;
                if (StockType == GBCEStockType.Common)
                {
                    dividendYield = LastDividend / price;
                }
                if (StockType == GBCEStockType.Preferred)
                {
                    dividendYield = FixedDividend / 100 * ParValue / price;
                }
                return dividendYield;

            }
            catch (DivideByZeroException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in Stock.CalculateDividendYieldForPrice", ex);
            }
        }

        public decimal CalculatePERatioForPrice(decimal price)
        {
            try
            {
                var peRatio = price / LastDividend;

                return peRatio;

            }
            catch (DivideByZeroException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in Stock.CalculatePERatioForPrice", ex);
            }
        }
    }
}
