using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class Stock
    {
        public int StockId { get; set; }
        public string BarCode { get; set; }
        public int? Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime? DateOfSupply { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SelllingPrice { get; set; }
        public bool isDeleted { get; set; }
    }
}
