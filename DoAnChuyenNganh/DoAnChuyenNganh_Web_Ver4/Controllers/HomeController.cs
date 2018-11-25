using DoAnChuyenNganh_Web_Ver4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnChuyenNganh_Web_Ver4.Controllers
{
    public class HomeController : Controller
    {
        WebsiteDbContext db = new WebsiteDbContext();
        // GET: Home
        public ActionResult Index()
        {
            var list = db.Products.OrderByDescending(a => a.SellDate).ToList();
            return View(list.Take(4));
        }


    }
}