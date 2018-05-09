using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBCE
{
    public class TradeLedger
    {
        public List<Trade> Trades { get; set; }

        public void Buy(string stockSymbol, decimal quantity, decimal price)
        {
            try
            {
                var trade = new Trade(stockSymbol, DateTime.Now, quantity, TradeType.Buy, price);
                Trades.Add(trade);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in TradeLedger.Buy", ex);
            }
        }

        public void Sell(string stockSymbol, decimal quantity, decimal price)
        {
            try
            {
                var trade = new Trade(stockSymbol, DateTime.Now, quantity, TradeType.Sell, price);
                Trades.Add(trade);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in TradeLedger.Sell", ex);
            }
        }

        public decimal GetVolumeWeightedStockPrice(string stockSymbol)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(stockSymbol))
                {
                    throw new Exception("StockSymbol has not been provided");
                }

                var tradeRange = Trades.Where(t => t.StockSymbol == stockSymbol && t.TradeDate >= DateTime.Now.AddMinutes(-5));

                if (tradeRange.Count() == 0)
                {
                    return 0m;
                }

                var denominator = 0m;
                var numerator = 0m;

                foreach (var trade in tradeRange)
                {
                    denominator += trade.Price * trade.Quantity;
                    numerator += trade.Quantity;
                }

                var volumeWeightedStockPrice = denominator / numerator;

                return volumeWeightedStockPrice;


            }
            catch (DivideByZeroException)
            {
                return 0;
            }

            catch(Exception ex)
            {
                throw new Exception("Exception in TradeLedger.GetVolumeWeightedStockPrice");
            }
        }
    }
}
