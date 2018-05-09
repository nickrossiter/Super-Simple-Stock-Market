using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBCE
{
    public class Exchange
    {
        public StockCollection StockList { get; set; }

        public TradeLedger Trades { get; set; }

        public double CalculateAllShareIndex()
        {
            try
            {
                var powerCount = 0;
                var priceProduct = 1m;
                var shareIndex = 0d;

                foreach (var stock in StockList.Stocks)
                {
                    var volumeWeightedStockPrice = Trades.GetVolumeWeightedStockPrice(stock.Value.StockSymbol);
                    if (volumeWeightedStockPrice != 0)
                    {
                        powerCount++;
                        priceProduct *= volumeWeightedStockPrice;
                    }
                }
                if (powerCount > 0)
                {
                    shareIndex = Math.Pow(Convert.ToDouble(priceProduct), Convert.ToDouble(1 / powerCount));
                }
                return shareIndex;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in Exchange.CalculateAllShareIndex", ex);
            }
        }

    }
}
