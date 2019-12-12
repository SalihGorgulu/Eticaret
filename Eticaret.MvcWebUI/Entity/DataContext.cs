using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eticaret.MvcWebUI.Entity
{
    public class DataContext:DbContext
    {
        public DataContext() : base("Eticaret")
        {
         
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
    }
}