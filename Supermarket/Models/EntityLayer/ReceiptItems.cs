using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class ReceiptItems
    {
        public ReceiptItems() { }
        public string ProductName { get; set; }
        public int ReceiptId { get; set; }
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public bool Deleted;
    }
}
