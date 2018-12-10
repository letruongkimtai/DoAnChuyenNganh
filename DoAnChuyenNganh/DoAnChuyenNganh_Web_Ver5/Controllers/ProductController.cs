
using DoAnChuyenNganh_Web_Ver5.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnChuyenNganh_Web_Ver5.Controllers
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
            var item = from s in db.Products where s.TypeID == id select s;
            Session["ProductID"] = id;
            return View(item);
        }

        public ActionResult ShowAllProduct(int? page)
        {
            int pageSize = 9; //Số mục hiện trên 1 trang
            int pageNumber = (page ?? 1); //Mặc định vào sẽ ở trang 1
            var allProduct = db.Products.OrderByDescending(a => a.PrName).ToList();
            return View(allProduct.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AlsoWant()
        {
            int id = (int)Session["ProductID"];
            var list = db.Products.Where(a => a.TypeID == id).ToList();
            return PartialView(list.Take(3));
        }
    }
}