using DoAnChuyenNganh_Web_Ver4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnChuyenNganh_Web_Ver4.Controllers
{
    public class ProductController : Controller
    {
        WebsiteDbContext db = new WebsiteDbContext();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var p = from s in db.Products
                    where id == s.PrID
                    select s;
            return View(p.Single());
        }

        public ActionResult Menu(int id)
        {

            if (id == 6)
                 return View(db.Products);
             else
             {
                 var item = from s in db.Products where s.TypeID == id select s;
                 return View(item);
             }

        }
    }
}