using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret.MvcWebUI.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }

        public List<OrderLine> OrderLine { get; set; }

   
        //Şipariş verilen adresi tutmak için buraya ekledik.
        public string UserName { get; set; }      
        public string AdresBasligi { get; set; }   
        public string Adres { get; set; }    
        public string Sehir { get; set; }     
        public string Semt { get; set; }    
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }
    }
    public class OrderLine//Sipariş Satırı
    {
        //Orderline gelen tamamlanmış bir kayıt
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order  Order{ get; set; } //Lazy loading etkin hale getirmek için virtual yapıyoruz. Orderline tablosunda ordera gidebilmemizi sağlıyor
        
        public int Quantity { get; set; }
        public double Price { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}