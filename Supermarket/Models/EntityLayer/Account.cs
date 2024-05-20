using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class Account 
    {
        public Account()
        {
            Receipt = new HashSet<Receipt>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Name { get; set; }
        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
