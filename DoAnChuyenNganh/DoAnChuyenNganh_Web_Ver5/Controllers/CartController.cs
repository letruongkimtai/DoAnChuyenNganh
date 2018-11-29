using DoAnChuyenNganh_Web_Ver5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnChuyenNganh_Web_Ver5.Controllers
{
    public class CartController : Controller
    {
        WebsiteDbContext db = new WebsiteDbContext();
        private const string CartSession = "CartSession";//Khai báo hằng chứa key session
        // GET: Cart

        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return View(list);
        }

        //Thêm sản phẩm vào giỏ hàng
        public ActionResult AddItem(int id, int quantity)    //Hàm Thêm item có tham số mã sp và số lượng
        {

            var product = ViewDetail(id);
            var cart = Session[CartSession];    //Khai báo session
            if (cart != null)
            {
                var list = (List<CartItem>)cart; //tạo list ép kiểu list<cartitem> cho biến cart

                //nếu cart có tồn tại item với id = prid thì tăng quantity lên 
                if (list.Exists(x => x.product.PrID == id))
                {
                    foreach (var item in list)  
                    {
                        if (item.product.PrID == id)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //Tạo mới đối tượng cart item
                    var item = new CartItem();  //Tạo đối tượng item với class cartitem
                    item.product = product;  //Khai báo biến id truyên vào = PrID trong CartItem
                    item.Quantity = quantity;  //Khai báo biến quantity truyên vào = Quantity trong CartItem
                    list.Add(item);

                }

            }
            else
            {
                //Tạo mới đối tượng cart item
                var item = new CartItem();  //Tạo đối tượng item với class cartitem
                item.product = product;  //Khai báo biến id truyên vào = PrID trong CartItem
                item.Quantity = quantity;  //Khai báo biến quantity truyên vào = Quantity trong CartItem
                var list = new List<CartItem>();
                list.Add(item);

                //Gán vào session
                Session[CartSession] = list;
            }

            return RedirectToAction("Index");
        }

        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
    }
}