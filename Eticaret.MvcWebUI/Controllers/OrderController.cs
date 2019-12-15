using Eticaret.MvcWebUI.Entity;
using Eticaret.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.MvcWebUI.Controllers
{
    
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        [Authorize(Roles ="admin")]
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i=> new AdminOrderModel
            { 
                Id=i.Id,
                OrderNumber=i.OrderNumber,
                OrderDate=i.OrderDate,
                OrderState=i.OrderState,
                Total=i.Total,
                Count=i.OrderLine.Count
            }).OrderByDescending(a=>a.OrderDate).ToList();
            return View(orders);
        }
        public ActionResult Details(int id)
        {

            var details = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    UserName=i.UserName,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Sehir = i.Sehir,
                    Semt = i.Semt,
                    Mahalle = i.Mahalle,
                    PostaKodu = i.PostaKodu,
                    OrderLine = i.OrderLine.Select(a => new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name.Length > 50 ? a.Product.Name.Substring(0, 47) + "..." : a.Product.Name,
                        Image = a.Product.Image,
                        Quantity = a.Quantity,
                        Price = a.Price

                    }).ToList()
                }).FirstOrDefault();
            return View(details);
        }

        public ActionResult UpdateOrderState(int OrderId,EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i=>i.Id==OrderId);
            if (order!=null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["message"] = "Bilgilreniz Kayıt Edildi";
                return RedirectToAction("Details", new { id=OrderId });
            }
            return View();
        }
    }
}