using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class ReceiptItems
    {
        public int ReceiptId { get; set; }
        public string ProductName { get; set; }

        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Subtotal { get; set; }

        
    }
}
