using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eticaret.MvcWebUI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public int CategoryId { get; set; }//Yabancıl Anahtar
        //public int? CategoryId { get; set; }//Eklenen ürünün kategori olması zorunluluğu yoksa soru işareti konulur.(Nullable)
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}