﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DoAnChuyenNganh_Web_Ver4.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int PrID { get; set; }

        public int Quantity { get; set; }

        public Decimal Total { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Orders { get; set; }

        [ForeignKey("PrID")]
        public virtual Customer Customer { get; set; }
    }
}