using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eticaret.MvcWebUI.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){Name = "Telefon",Description = "Telefon Ürünleri"},
                new Category(){Name = "Bilgisayar",Description = "Bilgisayar Ürünleri"},
                new Category(){Name = "Kamera",Description = "Kamera Ürünleri"},
                new Category(){Name = "Beyaz Eşya",Description = "Beyaz Eşya Ürünleri"}
            };
            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();
            List<Product> products = new List<Product>()
            {
                new Product(){Name="Iphone 6",Description="Apple Product",Price=4500,Stock=400,IsApproved=true,CategoryId=1,IsHome=true,Image="1.jpg"},
                new Product(){Name = "SAMSUNG GALAXY A20S ",Description = "6.5 Sonsuz-V Ekran",Price = 1799,Stock = 200, IsApproved = true,CategoryId = 1,IsHome=true,Image="2.jpg"},
                new Product(){Name = "SAMSUNG GALAXY A30S ",Description = "7.5 Sonsuz-V Ekran",Price = 1900,Stock = 110, IsApproved = true,CategoryId = 1,Image="3.jpg"},
                new Product(){Name = "Asus Laptop ",Description = "",Price = 2799,Stock = 12, IsApproved = true,CategoryId = 2,IsHome=true,Image="1.jpg"},
                new Product(){Name = "Lenovo Laptop ",Description = "",Price = 3799,Stock = 23, IsApproved = true,CategoryId = 2,Image="2.jpg"},
                new Product(){Name = "Canon ",Description = "",Price = 1799,Stock = 25, IsApproved = true,CategoryId = 3,IsHome=true,Image="1.jpg"},
                new Product(){Name = "Nixon ",Description = "",Price = 1799,Stock = 4, IsApproved = true,CategoryId = 3,Image="2.jpg"}
            };

            foreach (var item in products)
            {
                context.Products.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}