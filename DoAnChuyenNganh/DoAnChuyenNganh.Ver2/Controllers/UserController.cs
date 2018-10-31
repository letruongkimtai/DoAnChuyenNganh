
using DoAnChuyenNganh_Ver2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnChuyenNganh_Ver2.Controllers
{
    public class UserController : Controller
    {
        DataDbContext data = new DataDbContext();
        // GET: Index
        

        public ActionResult Index()
        {
            var list = data.CTmonans.OrderByDescending(a => a.Ngayban).ToList();
            return View(list.Take(4));
        }

        public ActionResult Chitiet(int id)
        {
            var mon = from s in data.CTmonans
                      where s.Mamon == id
                      select s;
            return View(mon.Single());
        }

        public ActionResult MainMenu()
        {
            return View();
        }

        public ActionResult TypeMenu()
        {
          
            return PartialView(data.LoaiMons);
        }

        public ActionResult Menu()
        {
           
            return PartialView();
        }

       

       

        
    }
}