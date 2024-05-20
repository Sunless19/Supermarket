using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Supermarket.Models;

namespace Supermarket.DBContext
{
    public partial class supermarketDBContext : DbContext
    {
        public supermarketDBContext()
        {
        }

        public supermarketDBContext(DbContextOptions<supermarketDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<ReceiptItems> ReceiptItems { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }

        

    }
}
