using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh_Web_Ver5.Models
{
    [Table("FeedBack")]
    public class FeedBack
    {
        [Key, Column(Order = 1)]
        public int PrID { get; set; }

        [Key, Column(Order = 2)]
        public int CtmID { get; set; }

        public string FbContent { get; set; }

        public int Rating { get; set; }

        [ForeignKey("PrID")]
        public virtual Product Products { get; set; }

        [ForeignKey("CtmID")]
        public virtual Customer Customers { get; set; }
    }
}