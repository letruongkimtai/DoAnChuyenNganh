using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace DoAnChuyenNganh_Web_Ver5.Models
{
    public class WebsiteDbContext : DbContext
    {
        public WebsiteDbContext() : base("WebsiteDB2")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<EventEmail> EventEmails { get; set; }
    }
}