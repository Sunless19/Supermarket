using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class Product
    {
        public Product()
        {
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public int CategoryId { get; set; }
        public int ProducerId { get; set; }
        public bool isDeleted { get; set; }

        public int Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal SellingPrice { get; set; }

    }
}
