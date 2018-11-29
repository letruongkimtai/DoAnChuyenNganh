using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh_Web_Ver5.Models
{
    [Serializable]
    public class CartItem
    {
        public Product product { get; set; }
        public int Quantity { get; set; }

    }
}