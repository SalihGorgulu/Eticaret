using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret.MvcWebUI.Entity;
using Eticaret.MvcWebUI.Models;

namespace Eticaret.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DataContext _contex = new DataContext();
     
        public ActionResult Index()
        {
            var products = _contex.Products.Where(p => p.IsHome && p.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name.Length>50?i.Name.Substring(0,47)+"...":i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price=i.Price,
                Stock=i.Stock,
                Image=i.Image??"1.jpg",
                CategoryId=i.CategoryId
            }).ToList();
            return View(products);
        }
        public ActionResult Details(int id)
        {
            var product = _contex.Products.Where(p=>p.Id==id).SingleOrDefault();
            return View(product);
        }
        public ActionResult List(int? id)
        {
            var products = _contex.Products.Where(p=>p.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                Stock = i.Stock,
                Image = i.Image,
                CategoryId = i.CategoryId
            }).AsQueryable();//Yazılmış olan sorguya yeni sorgu eklenebilir

            if (id!=null)
            {
                products=products.Where(i => i.CategoryId == id);
            }
            return View(products.ToList());
        }
        public ActionResult GetCategories()
        {
            return PartialView(_contex.Categories.ToList());
        }
    }
}