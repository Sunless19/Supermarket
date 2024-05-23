using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class Receipt
    {
        public Receipt()
        {
        }

        public DateTime Date { get; set; }
        public int ReceiptId { get; set; }
        public int CasherID { get; set; }
        public decimal Total { get; set; }
        public bool Deleted;
    }
}
