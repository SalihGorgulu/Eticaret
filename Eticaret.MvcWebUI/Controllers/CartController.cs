using Eticaret.MvcWebUI.Entity;
using Eticaret.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        public ActionResult Index()
        { 
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            var cart = GetCart();

            if (cart.CartLines.Count() == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    OrderNumber = "A" + (new Random()).Next(111111, 999999).ToString(),
                    Total = cart.Total(),
                    OrderDate = DateTime.Now,
                    OrderState=EnumOrderState.Waiting,//-->
                    UserName=User.Identity.Name,

                    AdresBasligi=shippingDetails.AdresBasligi,
                    Sehir=shippingDetails.Sehir,
                    Semt = shippingDetails.Semt,
                    Mahalle = shippingDetails.Mahalle,
                    PostaKodu = shippingDetails.PostaKodu
                };
                order.OrderLine = new List<OrderLine>();

                foreach (var item in cart.CartLines)
                {
                    var orderLine = new OrderLine()
                    {
                        Quantity = item.Quantity,
                        Price=item.Quantity*item.Product.Price,
                        ProductId=item.Product.Id
                        
                    };
                    order.OrderLine.Add(orderLine);
                }

                db.Orders.Add(order);
                db.SaveChanges();

                //cart sıfırladık
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}