using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBCE
{
    public class StockCollection
    {
        public Dictionary<string, Stock> Stocks { get; set; }

        public const string StockAlreadyExists = "Stock Already Exists";
        public const string StockNotFound = "Stock Not Found";

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

        public void AddStock(Stock stock)
        {
            if (Stocks.Keys.Contains(stock.StockSymbol))
            {
                throw new Exception(StockAlreadyExists);
            }

            Stocks.Add(stock.StockSymbol, stock);
        }

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
