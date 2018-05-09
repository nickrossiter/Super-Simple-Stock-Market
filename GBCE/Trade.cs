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
                    throw new Exception("StockSymbol has not been set");
                }
                if (TradeDate == null)
                {
                    throw new Exception("TradeDate has not been set");
                }
                if (Quantity == 0)
                {
                    throw new Exception("Trade Quantity cannot be zero");
                }
                if (Price < 0)
                {
                    throw new Exception("Trade Price cannot be negative");
                }
                if (Price == 0)
                {
                    throw new Exception("Price cannot be zero");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception validating Trade", ex);
            }
        }
    }
}
