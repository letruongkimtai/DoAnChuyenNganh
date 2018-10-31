using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace DoAnChuyenNganh_Web_Ver4.Models
{
    public class WebsiteDbContext : DbContext
    {
        public WebsiteDbContext() : base("WebsiteDB")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}