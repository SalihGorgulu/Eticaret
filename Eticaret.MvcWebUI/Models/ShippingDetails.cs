using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eticaret.MvcWebUI.Models
{
    public class ShippingDetails
    {
     
        public string UserName { get; set; }//Sistem aldığımız için required gerekli değil
        [Required(ErrorMessage ="Lütfen Adres Tanımı Giriniz.")]
        public string AdresBasligi { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string Sehir { get; set; }
        [Required]
        public string Semt { get; set; }
        [Required]
        public string Mahalle { get; set; }

        public string PostaKodu { get; set; }
    }
}