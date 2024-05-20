using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class Product
    {
        public Product()
        {
            ReceiptItems = new HashSet<ReceiptItems>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public int CategoryId { get; set; }
        public int ProducerId { get; set; }
        public bool? InStock { get; set; }

        public virtual Category Category { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual ICollection<ReceiptItems> ReceiptItems { get; set; }
    }
}
