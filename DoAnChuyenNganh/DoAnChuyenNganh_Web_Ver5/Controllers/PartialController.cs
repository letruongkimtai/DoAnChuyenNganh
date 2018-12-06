using DoAnChuyenNganh_Web_Ver5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnChuyenNganh_Web_Ver5.Controllers
{
    public class PartialController : Controller
    {
        WebsiteDbContext db = new WebsiteDbContext(); 
        // GET: Partial
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuPartial()
        {
            return PartialView(db.ProductTypes);
        }

        public ActionResult Search()
        {
            return PartialView();
        }
        public ActionResult SearchResult(FormCollection formCollection)
        {
            string value = formCollection["Search"];
            var result = db.Products.Where(x => x.PrName.Contains(value)).ToList();

            return View(result);
        }

        public ActionResult BannerPartial()
        {
            var list = db.Banners.OrderByDescending(a => a.RelsDay).ToList();
            return PartialView(list.Take(1));
        }
    }
}