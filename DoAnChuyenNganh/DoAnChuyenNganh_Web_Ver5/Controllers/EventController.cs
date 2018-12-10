using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnChuyenNganh_Web_Ver5.Models;
using PagedList;

namespace DoAnChuyenNganh_Web_Ver5.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        WebsiteDbContext db = new WebsiteDbContext();
        public ActionResult Index(int? page)
        {
            int pageSize = 6; //Số mục hiện trên 1 trang
            int pageNumber = (page ?? 1); //Mặc định vào sẽ ở trang 1
            var allPost = db.Events.OrderByDescending(a => a.StartDay).ToList();
            return View(allPost.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Post(int id)
        {
            var p = from s in db.Events
                    where id == s.EventID
                    select s;
            return View(p.Single());
        }

    }
}