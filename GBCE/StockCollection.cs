using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBCE
{
    public class StockCollection
    {
        public StockCollection()
        {
            Stocks = new Dictionary<string, Stock>();
        }

        public Dictionary<string, Stock> Stocks { get; set; }

        public const string StockAlreadyExists = "Stock Already Exists";
        public const string StockNotFound = "Stock Not Found";

        /// <summary>
        /// Determines whether a stock with the supplied stockSymbol exists in the Stock Dictionary
        /// </summary>
        /// <param name="stockSymbol"></param>
        /// <returns></returns>
        public bool StockExists(string stockSymbol)
        {
            if (Stocks.ContainsKey(stockSymbol))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a Stock from the Stocks Dictionary using the stock Symbol to find the stock
        /// If there is no matching stock, an exception is thrown.
        /// </summary>
        /// <param name="stockSymbol"></param>
        /// <returns>The found Stock object </returns>
        public Stock GetStock(string stockSymbol)
        {
            Stock existingStock = null;
            if (Stocks.TryGetValue(stockSymbol, out existingStock))
            {
                return existingStock;
            }
            else
            {
                throw new Exception(StockNotFound);
            }
        }

        /// <summary>
        /// Adds a Stock object to the Stocks Dictionary
        /// If a stock already exists with the same stock symbol an exception is thrown.
        /// </summary>
        /// <param name="stock"></param>
        public void AddStock(Stock stock)
        {
            if (Stocks.Keys.Contains(stock.StockSymbol))
            {
                throw new Exception(StockAlreadyExists);
            }

            Stocks.Add(stock.StockSymbol, stock);
        }

        /// <summary>
        /// Removes a Stock from the Stocks Dictionary using the stock Symbol to find the stock
        /// If there is no matching stock, an exception is thrown.
        /// </summary>
        /// <param name="stockSymbol"></param>
        public void RemoveStock(string stockSymbol)
        {
            if (Stocks.Keys.Contains(stockSymbol))
            {
                Stocks.Remove(stockSymbol);
            }
            else
            {
                throw new Exception(StockNotFound);
            }

        }

        /// <summary>
        /// Updates an existing Stock in the Stocks Dictionary, found using the stock Symbol, with the values of the suppplied stock
        /// If there is no matching stock, an exception is thrown.
        /// </summary>
        /// <param name="stock"></param>
        public void UpdateStock(Stock stock)
        {
            Stock existingStock = null;
            if (Stocks.TryGetValue(stock.StockSymbol, out existingStock))
            {
                existingStock.StockType = stock.StockType;
                existingStock.LastDividend = stock.LastDividend;
                existingStock.FixedDividend = stock.FixedDividend;
                existingStock.ParValue = stock.ParValue;
            }
            else
            {
                throw new Exception(StockNotFound);
            }
        }
    }
}
