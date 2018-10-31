using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DoAnChuyenNganh_Web_Ver4.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// Auto ID
        public int PrID { get; set; }

        public string PrName { get; set; }

        public DateTime SellDate { get; set; }

        public decimal Price { get; set; }

        public string Pic { get; set; }

        public string Status { get; set; }

        public string Describe { get; set; }


        public int TypeID { get; set; }
        public virtual ProductType ProductTypes { get; set; }

    }
}