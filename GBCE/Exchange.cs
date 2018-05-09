using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBCE
{
    public class Exchange
    {
        public StockCollection Stocks { get; set; }

        public TradeLedger Trades { get; set; }

        public Exchange()
        {
            Stocks = new StockCollection();
            Trades = new TradeLedger(Stocks);
        }

        /// <summary>
        /// Calculates the All Share Index for all the stocks in the Exchange
        /// using the geometric mean of the Volume Weighted Stock Price of each stock
        /// </summary>
        /// <returns></returns>
        public double CalculateAllShareIndex()
        {
            try
            {
                var shareIndex = 0d;

                var values = new List<double>();

                foreach (var stock in Stocks.Stocks)
                {
                    var volumeWeightedStockPrice = Trades.GetVolumeWeightedStockPrice(stock.Value.StockSymbol);
                    if (volumeWeightedStockPrice != 0)
                    {
                        values.Add(Convert.ToDouble(volumeWeightedStockPrice));
                    }
                }

                shareIndex = Helper.GetGeometricMeanUsingLog(values);


                return shareIndex;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in Exchange.CalculateAllShareIndex", ex);
            }
        }

       
    }
}
