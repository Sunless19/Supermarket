using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class Producer
    {
        public Producer()
        {
            Product = new HashSet<Product>();
        }

        public int ProducerId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public bool isDeleted {  get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
