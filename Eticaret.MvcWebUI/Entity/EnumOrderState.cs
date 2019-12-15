using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eticaret.MvcWebUI.Entity
{
    public enum EnumOrderState
    {
        [Display(Name ="Onay Bekleniyor")]
        Waiting,
        [Display(Name ="Tamamlandı")]
        Completed
    }
}