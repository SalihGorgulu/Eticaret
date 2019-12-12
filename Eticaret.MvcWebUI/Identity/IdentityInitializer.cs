using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Eticaret.MvcWebUI.Identity
{
    public class IdentityInitializer:CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager =new  RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name= "admin", Description="yönetici rolü" };
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() {Name="user",Description= "kullanıcı rolü" };
                manager.Create(role);
            }
            if (!context.Users.Any(i => i.Name == "turgutozakman"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() {Name="turgut",Surname="özakman" ,UserName="turgutozakman",Email="turgutozakman@gmail.com"};

                manager.Create(user,"123456");
                manager.AddToRole(user.Id,"admin");
                manager.AddToRole(user.Id,"user");
            }
            if (!context.Users.Any(i => i.Name == "adamfawer"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "adam", Surname = "fawer", UserName = "adamfawer", Email = "adamfawer@gmail.com" };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "user");
            }
            base.Seed(context); 
        }

    }
}