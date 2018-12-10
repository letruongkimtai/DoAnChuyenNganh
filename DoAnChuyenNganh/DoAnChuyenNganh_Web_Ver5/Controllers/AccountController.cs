using DoAnChuyenNganh_Web_Ver5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnChuyenNganh_Web_Ver5.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        WebsiteDbContext db = new WebsiteDbContext();

        /*----------------------------------SIGN UP-----------------------------------*/

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(FormCollection collection, Customer customer)
        {
            var username = collection.Get("UserName");
            var passwords = collection.Get("Passwords");
            var name = collection.Get("CtmName");
            var bday = String.Format("{0:MM/dd/yyyy }", collection.Get("Bdate"));
            var address = collection.Get("Addr");
            var tell = collection.Get("Tell");
            var email = collection.Get("Eaddr");

            customer.UserName = username;
            customer.Passwords = passwords;
            customer.CtmName = name;
            customer.BDate = DateTime.Parse(bday);
            customer.Addr = address;
            customer.Tell = tell;
            customer.Eaddr = email;
            db.Customers.Add(customer);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        /*---------------------------------------Login----------------------------------------------*/

        [HttpGet]
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var username = collection["UserName"];
            var passwords = collection["Passwords"];

            Customer cus = db.Customers.SingleOrDefault(n => n.UserName == username && n.Passwords == passwords);
            if (cus != null)
            {
                Session["Customer"] = cus.UserName;
                Session["CustomerObject"] = cus;
                Session["CustomerID"] = cus.CtmID;
            }


            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogOut()
        {
            Session["Customer"] = null;
            return PartialView();
        }

        /*Account Detail*/
        public ActionResult AccountDetail()
        {
            return View();
        }

        public ActionResult OrderList()
        {
            int ctmId = (int)Session["CustomerID"];
            var order = db.Orders.Where(n => n.CtmID == ctmId);
            return View(order);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            int id = (int)Session["CustomerID"];
            Customer cus = db.Customers.Find(id);

            cus.CtmName = collection["CtmName"];
            cus.Addr = collection["Addr"];
            cus.Tell = collection["Tell"];
            cus.Eaddr = collection["Eaddr"];
            db.SaveChanges();
            return RedirectToAction("AccountDetail", "Account");
        }
    }

}