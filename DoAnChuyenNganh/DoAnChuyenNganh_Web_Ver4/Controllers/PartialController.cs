using DoAnChuyenNganh_Web_Ver4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnChuyenNganh_Web_Ver4.Controllers
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
    }
}