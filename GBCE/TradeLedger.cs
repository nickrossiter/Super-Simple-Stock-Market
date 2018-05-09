using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBCE
{
    public class TradeLedger
    {
        public const string StockSymbolHasNotBeenProvided = "StockSymbol has not been provided";
        public const string StockDoesNotExistInStockList = "Stock does not exist in StockList";

        public List<Trade> Trades { get; set; }

        public StockCollection Stocks { get; set; }

        public TradeLedger(StockCollection stockCollection)
        {
            Trades = new List<Trade>();
            Stocks = stockCollection;
        }

        /// <summary>
        /// Creates a Buy trade in the Trades list using the supplied stockSymbol
        /// An exception will be thrown if a stock with the supplied stockSymbol does not exist in the Stocks StockCollection
        /// </summary>
        /// <param name="stockSymbol"></param>
        /// <param name="tradeDate"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        public void Buy(string stockSymbol, DateTime tradeDate, decimal quantity, decimal price)
        {
            try
            {
                if (!Stocks.StockExists(stockSymbol))
                {
                    throw new Exception(StockDoesNotExistInStockList);
                }

                var trade = new Trade(stockSymbol, tradeDate, quantity, TradeType.Buy, price);
                Trades.Add(trade);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in TradeLedger.Buy", ex);
            }
        }

        /// <summary>
        /// Creates a Sell trade in the Trades list using the supplied stockSymbol
        /// An exception will be thrown if a stock with the supplied stockSymbol does not exist in the Stocks StockCollection        
        /// </summary>
        /// <param name="stockSymbol"></param>
        /// <param name="tradeDate"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        public void Sell(string stockSymbol, DateTime tradeDate, decimal quantity, decimal price)
        {
            try
            {
                if (!Stocks.StockExists(stockSymbol))
                {
                    throw new Exception(StockDoesNotExistInStockList);
                }

                var trade = new Trade(stockSymbol, tradeDate, quantity, TradeType.Sell, price);
                Trades.Add(trade);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in TradeLedger.Sell", ex);
            }
        }

        /// <summary>
        /// Gets the Volume Weighted Stock Price for stocks with the supplied stockSymbol that have a trade date within the last five minutes
        /// Throws an exception if the supplied stockSymbol is blank
        /// Throws an exception if there is not a stock in the Stocks StockCollection which matches the supplied stockSymbol
        /// </summary>
        /// <param name="stockSymbol"></param>
        /// <returns></returns>
        public decimal GetVolumeWeightedStockPrice(string stockSymbol)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(stockSymbol))
                {
                    throw new Exception(StockSymbolHasNotBeenProvided);
                }

                if (!Stocks.StockExists(stockSymbol))
                {
                    throw new Exception(StockDoesNotExistInStockList);
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
                throw new Exception("Exception in TradeLedger.GetVolumeWeightedStockPrice",ex);
            }
        }
    }
}
