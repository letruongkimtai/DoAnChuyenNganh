using DoAnChuyenNganh_Web_Ver4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnChuyenNganh_Web_Ver4.Controllers
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


            if (String.IsNullOrEmpty(username))
                ViewData["Error1"] = "Tên đăng nhập không được để trống";
            else if(String.IsNullOrEmpty(passwords))
                ViewData["Error2"] = "Mật khẩu đăng nhập không được để trống";
            else if(String.IsNullOrEmpty(name))
                ViewData["Error3"] = "Họ tên không được để trống";
            else if(String.IsNullOrEmpty(address))
                ViewData["Error4"] = "Địa chỉ không được để trống";
            else if(String.IsNullOrEmpty(tell))
                ViewData["Error5"] = "Số điện thoại không được để trống";
            else if(String.IsNullOrEmpty(email))
                ViewData["Error6"] = "Email không được để trống";


            else
            {
                customer.UserName = username;
                customer.Passwords = passwords;
                customer.CtmName = name;
                customer.BDate = DateTime.Parse(bday);
                customer.Addr = address;
                customer.Tell = tell;
                customer.Eaddr = email;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return Signup();
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

            if (username != "" && passwords != "")
            {
                Customer cus = db.Customers.SingleOrDefault(n => n.UserName == username && n.Passwords == passwords);
                if (cus != null)
                {
                    ViewBag.Noti = "Login Successfully";
                    Session["Customer"] = cus;
                }
                else
                    ViewBag.Noti = "Access Denied...!Username or password incorrect!";

            }
            else
                ViewData["Error"] = "Username and Passwords must not null!";

            return View();
        }

        public ActionResult LoginStatus()
        {
            return View();
        }


    }
}