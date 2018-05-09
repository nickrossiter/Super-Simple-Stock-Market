using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBCE
{
    public enum TradeType
    {
        Buy,
        Sell
    }

    public class Trade
    {
        public const string StockSymbolHasNotBeenSet = "StockSymbol has not been set";
        public const string TradeDateHasNotBeenSet = "TradeDate has not been set";
        public const string TradeQuantityCannotBeZero = "Trade Quantity cannot be zero";
        public const string TradePriceCannotBeNegative = "Trade Price cannot be negative";
        public const string TradePriceCannotBeZero = "Trade Price cannot be zero";

        public string StockSymbol { get; set; }
        public DateTime? TradeDate { get; set; }
        public decimal Quantity { get; set; }
        public TradeType TypeOfTrade { get; set; }
        public decimal Price { get; set; }

        public Trade(string stockSymbol, DateTime? tradeDate, decimal quantity, TradeType tradeType, decimal price )
        {
            StockSymbol = stockSymbol;
            TradeDate = tradeDate;
            Quantity = quantity;
            TypeOfTrade = tradeType;
            Price = price;
            Validate();
        }

        public void Validate()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(StockSymbol))
                {
                    throw new Exception(StockSymbolHasNotBeenSet);
                }
                if (TradeDate == null)
                {
                    throw new Exception(TradeDateHasNotBeenSet);
                }
                if (Quantity == 0)
                {
                    throw new Exception(TradeQuantityCannotBeZero);
                }
                if (Price < 0)
                {
                    throw new Exception(TradePriceCannotBeNegative);
                }
                if (Price == 0)
                {
                    throw new Exception(TradePriceCannotBeZero);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception validating Trade", ex);
            }
        }
    }
}
