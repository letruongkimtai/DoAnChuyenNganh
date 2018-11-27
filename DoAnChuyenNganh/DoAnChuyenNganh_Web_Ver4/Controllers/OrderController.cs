using DoAnChuyenNganh_Web_Ver4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnChuyenNganh_Web_Ver4.Controllers
{
    public class OrderController : Controller
    {
        WebsiteDbContext db = new WebsiteDbContext();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        /*---------------------------Order Section----------------------------------------*/
        public ActionResult Cart()
        {
            List<Cart> orders = GetList();
            if(orders.Count==0)
            {
                return RedirectToAction("Error", "Partial");
            }
            ViewBag.CartTotal = CartTotal();
            ViewBag.Shipping = Shipping();
            if(CartTotal() <= OrderTotal())
            {
                ViewBag.Discount = 0;
            }
            else
            {
                ViewBag.Discount =  CartTotal() - OrderTotal();
            }
            ViewBag.OrderTotal = OrderTotal();


            return View(orders);
        }


        public ActionResult Discount()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Discount(FormCollection collection)
        {
            double dc = 0;
            double d = OrderTotal();
            var couponcode = collection["Coupon"];
            Coupon cp = new Coupon();
            if (Equals(couponcode, cp.CouponID) == true)
            {
                dc = cp.Discount;
                d = Shipping() + dc + OrderTotal();
            }
            else
            {
                ViewBag.Error = "Coupon không tồn tại!";
            }

            return PartialView();
        }


        public ActionResult CartPartial()
        {
           
            ViewBag.Amount = Amount();
            return PartialView();
        }
        /*---------------------------Payment Section-------------------------------------*/

        public ActionResult CustomerInfo()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult CheckOut()
        {
            if(Session["Customer"]==null||Session["Customer"].ToString()=="")
            {
                return RedirectToAction("Login", "Account");
            }
            if(Session["Cart"]==null)
            {
                return RedirectToAction("Error", "Partial");
            }

            List<Cart> orders = GetList();
            ViewBag.CartTotal = CartTotal();
            ViewBag.Shipping = Shipping();
            ViewBag.OrderTotal = OrderTotal();

            return View(orders);
        }
        [HttpPost]
        public ActionResult CheckOut(FormCollection collection)
        {
            if (Session["Customer"] == null || Session["Customer"].ToString() == "")
            {
                return RedirectToAction("Login", "Account");
            }
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Error", "Partial");
            }
            Order bill = new Order();
            Customer customer = (Customer)Session["CustomerObject"];
            List<Cart> orders = GetList();

            bill.CtmID = customer.CtmID;
            bill.Odate = DateTime.Now;
            bill.DeliveryStatus = false;
            bill.PaymentCheck = false;

            db.Orders.Add(bill);
            db.SaveChanges();

            foreach (var item in orders)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderID = bill.OrderID;
                orderDetail.PrID = item.TempID;
                orderDetail.Quantity = item.TempAmount;
                orderDetail.Total =(decimal) item.TempTotal;
                db.OrderDetails.Add(orderDetail);
            }

            db.SaveChanges();
            Session["Cart"] = null;
            return RedirectToAction("Confirm", "Partial");
        }



        /*---------------------------------Function-------------------------------------*/
        public List<Cart> GetList()
        {
            List<Cart> orders = Session["Cart"] as List<Cart>;
            if (orders == null)
            {
                orders = new List<Cart>();
                Session["Cart"] = orders;
            }

            return orders;
        }

        private int Amount()
        {
            int Amt = 0;
            List<Cart> orders = Session["Cart"] as List<Cart>;
            if(orders!=null)
            {
                Amt = orders.Sum(n => n.TempAmount);
            }
            return Amt;
        }

        private double CartTotal()
        {
            double Ttal = 0;
            List<Cart> orders = Session["Cart"] as List<Cart>;
            if (orders != null)
            {
                Ttal = orders.Sum(n => n.TempTotal);
            }
            return Ttal;
        }

        private double Shipping()
        {
           
            double Ship;
            if(Amount()<5)
            {
                Ship = 15000;
            }
            else
            {
                Ship = 0;
            }
            return Ship;
            
        }

        private double OrderTotal()
        {
            double total = Shipping() + CartTotal();
            return total;
        }
        public ActionResult AddToCart(int id, string URL)
        {
            List<Cart> orders = GetList();

            Cart product = orders.Find(n => n.TempID == id);
            if (product == null)
            {
                product = new Cart(id);
                orders.Add(product);
                return Redirect(URL);
            }
            else
            {
                product.TempAmount++;
                return Redirect(URL);
            }
        }

        public ActionResult DeleteItem(int id)
        {
            List<Cart> orders = GetList();
            Cart product = orders.SingleOrDefault(n => n.TempID == id);

            if(product!=null)
            {
                orders.RemoveAll(n => n.TempID == id);
                return RedirectToAction("Cart");
            }

            return RedirectToAction("Cart");
        }

        public ActionResult UpdateCart(int id, FormCollection form)
        {
            List<Cart> order = GetList();
            Cart product = order.SingleOrDefault(n => n.TempID == id);

            if(product != null)
            {
                product.TempAmount = int.Parse(form["Quantity"].ToString());
            }
            return RedirectToAction("Cart");
        }

        public ActionResult DeleteCart(int id)
        {
            List<Cart> orders = GetList();
            orders.Clear();

            return RedirectToAction("Index","Home");
        }




    }
}