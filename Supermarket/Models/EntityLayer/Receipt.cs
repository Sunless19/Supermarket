using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class Receipt
    {
        public Receipt()
        {
            ReceiptItems = new HashSet<ReceiptItems>();
        }

        public int ReceiptId { get; set; }
        public DateTime? Date { get; set; }
        public int AccountId { get; set; }
        public decimal? Amount { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<ReceiptItems> ReceiptItems { get; set; }
    }
}
