using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh_Web_Ver5.Models
{
    public class Cart
    {
        WebsiteDbContext db = new WebsiteDbContext();

        //Create Temporary Object for Database Connection

        public int TempID { set; get; }

        public string TempName { set; get; }

        public string TempPic { set; get; }

        public Double TempPrice { set; get; }

        public int TempAmount { set; get; }

        public Double TempTotal {
            get { return TempAmount * TempPrice; }
        }


        //Create cart
        public Cart(int id)
        {
            TempID = id;
            Product product = db.Products.Single(n => n.PrID == TempID);
            TempName = product.PrName;
            TempPic = product.Pic;
            TempPrice = double.Parse(product.Price.ToString());
            TempAmount = 1;

        }
    }
}