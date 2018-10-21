using DoAnChuyenNganh_Ver2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh_Ver2.Models
{
    public class DataDbContext: DbContext
    {
        public DataDbContext():base("DoAnChuyenNganhConnection")
        {

        }

        public DbSet<CTmonan> CTmonans { get; set; }
        public DbSet<LoaiMon> LoaiMons { get; set; }
    }
}