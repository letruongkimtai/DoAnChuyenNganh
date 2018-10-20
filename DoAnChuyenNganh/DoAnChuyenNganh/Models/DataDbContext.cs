using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh.Models
{
    public class DataDbContext : DbContext
    {
        //Contructor
        public DataDbContext() : base("DoAnChuyenNganhConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Ctmonan> Ctmonans { get; set; }

    }
}