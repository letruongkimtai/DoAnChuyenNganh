using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh_Web_Ver5.Models
{
    [Table("Coupons")]
    public class Coupon
    {
        [Key]
        public string CouponID { get; set; }

        public int Discount { get; set; }
    }
}